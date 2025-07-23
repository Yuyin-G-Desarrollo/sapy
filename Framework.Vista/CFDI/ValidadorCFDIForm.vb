'Imports HyperSoft.Shared
'Imports HyperSoft.ElectronicDocument.Validator
Imports System.Text
'Imports HyperSoft.ElectronicDocument.Validator.Base
Imports System.IO
Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports System.Threading
Imports System.Xml
Imports Tools

Public Class ValidadorCFDIForm
    Dim emails As New DescargarEMailsBU
    Dim listauuids As New List(Of String)
    Dim listaFolios As New List(Of String)
    Dim rutaComprobantes As String = "C:\Emails\Nuevos\"
    Private Const Separator As String = "========================================================================"
    Dim tipoFacturas As Integer = 3
    Dim naveSICYid As Integer


    Private Sub btnRecibir_Click(sender As Object, e As EventArgs) Handles btnRecibir.Click
        'Pasar factura a carpeta de recibidos e insertar en tabla cfdsValidador IMPORTANTE INSERTAR EN 2.5
        Dim objMensaje As New Tools.ConfirmarForm
        Dim continuarOperacion As Boolean = False
        Dim longitud As Integer = 0
        Dim sc As String = ""


        If grdListas.Rows.Count > 0 Then
            If validarFacturasSeleccionadas() Then
                objMensaje.mensaje = "¿Está seguro que desea recibir las facturas seleccionadas?"
            Else
                objMensaje.mensaje = "Existen facturas erróneas ¿Está seguro que desea recibir las facturas seleccionadas?"
            End If
            If objMensaje.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                continuarOperacion = True
            End If
        End If

        If continuarOperacion Then
            Dim obj As New CFDIBU
            Dim tabla As New DataTable
            Dim datosConfigNave As New DataTable
            Dim mensaje As String = ""
            tabla = CType(grdListas.DataSource, DataTable)
            For Each row As DataRow In tabla.Rows
                If CBool(row("AUTORIZAR")) Then
                    datosConfigNave = obj.getConfiguracionNave(CInt(cmbNave.SelectedValue))
                    longitud = row("RS_NUEVA").ToString.Length
                    sc = row("RS_NUEVA").ToString.Substring(longitud - 2, 2)
                    'Validación para comprobar que sea un receptor válido
                    If (Not obj.validarReceptor(row("RFC EMPRESA").ToString)) Then
                        mensaje = "No se puede autorizar, el receptor no se encuentra en la base de datos."
                        MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    ElseIf (row("RFC PROVEEDOR2").ToString.Equals("")) Then
                        mensaje = "No se puede autorizar hasta que se registre el RFC del proveedor."
                        MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                        'ElseIf (row("VERSION").ToString.Equals("3.3") And CDate(row("FECHA FACTURA")) > CDate("01/07/2022")) Then 'hasta enero 2023
                        '    mensaje = "Facturas versión 3.3 no se pueden Autorizar con fecha mayor al 30/06/2022"
                        '    MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '    Exit Sub

                    ElseIf (row("Regimen").ToString.Equals("601") And row("VERSION").ToString.Equals("3.3") And (InStr(1, row("RS_NUEVA").ToString, "SADECV") <= 0 And InStr(1, row("RS_NUEVA").ToString, "SACV") <= 0 And InStr(1, row("RS_NUEVA").ToString, "SDERLDECV") <= 0 And InStr(1, sc, "SC") <= 0) And (InStr(1, row("RS_RECEPTOR").ToString, "SADECV") <= 0 And InStr(1, row("RS_RECEPTOR").ToString, "SACV") <= 0)) Then
                        mensaje = "Razón Social en base de datos incorrecta falta SA de CV"
                        MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    Dim xml As String = ""
                    Dim pdf As String = ""
                    For Each row2 As DataRow In datosConfigNave.Rows
                        xml = CopiarArchivos(row("RUTA").ToString, row("UUID").ToString, "XML", row2("fac_rutaFacturas").ToString)
                        pdf = CopiarArchivos(row("RUTA").ToString.ToUpper.Trim.Replace(".XML", ".PDF"), row("UUID").ToString, "PDF", row2("fac_rutaFacturas").ToString)
                    Next

                    Try
                        ' System.IO.File.Move(row("RUTA").ToString, "C:\Emails\Recibidos\" & row("UUID").ToString & ".xml")
                        ' System.IO.File.Move(row("RUTA").ToString.ToUpper.Trim.Replace(".XML", ".PDF"), "C:\Emails\Recibidos\" & row("UUID").ToString & ".pdf")
                    Catch ex As Exception
                    End Try
                    'obj.actualizarRutadeFactura(CInt(row("idFactura")), xml, pdf)
                    mensaje = ""
                    mensaje = obj.recibirFacturaInsertarCFDS(CInt(row("idFactura")))
                    Dim idFacturaSICY As Integer = 0
                    If Not mensaje.ToUpper.Trim.Contains("ERROR") Then
                        'Agregar insercion al say cfdsOrdenCompra
                        Dim xmlentidad As New Entidades.xml
                        Try
                            idFacturaSICY = CInt(mensaje)
                        Catch ex As Exception
                        End Try
                        'xmlentidad = obj.getDatosFacturaValidada(CInt(row("idFactura")))
                        'xmlentidad.idComprobantesicy = idFacturaSICY
                        'obj.insertarFacturaEnSAY(xmlentidad)
                        'recibirFacturaSAY(CInt(row("idFactura")))
                        obj.recibirFacturaEstatusValidador(CInt(row("idFactura")))
                    Else
                        If mensaje.Contains("cfdIdProveedor") Then
                            MessageBox.Show("No es posible recibir la factura, registre el proveedor " & row("PROVEEDOR").ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Else
                            MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If

                    End If
                End If
            Next
            llenarGrid()
        End If
    End Sub
    Public Sub recibirFacturaSAY(idFacturaSicy As Integer)

    End Sub

    Function validarFacturasSeleccionadas() As Boolean
        Dim tabla As New DataTable
        tabla = CType(grdListas.DataSource, DataTable)
        For Each row As DataRow In tabla.Rows
            If CBool(row("AUTORIZAR")) Then
                If Not CBool(row("CORRECTA")) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    'Private Sub validar(ByVal ruta As String)
    '    'Dim obj As New ValidadorCFDIBU
    '    Chronometer.Instance.StartWithCursor()
    '    Try
    '        ' Invocamos este método para validar el archivo
    '        Dim report As Report = ValidarArchivo(ruta)
    '        Chronometer.Instance.[Stop]()
    '        ' Mostrar el resultado en pantalla
    '        MostrarResultado(report)
    '    Finally
    '        Chronometer.Instance.Clear()
    '    End Try
    'End Sub



    Private Sub SetTitle(title As String, builder As StringBuilder)
        If builder.Length <> 0 Then
            builder.AppendLine()
            builder.AppendLine()
        End If

        builder.AppendLine(Separator)
        builder.AppendLine(title)
        builder.AppendLine(Separator)
    End Sub






    Public Sub leerCorreo()
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New CFDIBU
        Dim datosConfigNave As New DataTable
        Dim bandera As Boolean = False
        datosConfigNave = obj.getConfiguracionNave(CInt(cmbNave.SelectedValue))
        Dim lista As New List(Of String)
        'Recuperar Nave para traer configuracion
        For Each row As DataRow In datosConfigNave.Rows()
            emails._password = row("fac_contrasena").ToString
            emails._server = row("fac_serverEntrada").ToString
            emails._user = row("fac_correo").ToString
            emails._port = CInt(row("fac_puertoEntrada").ToString)
            bandera = True
        Next
        If bandera Then
            'lista = emails.getRutasXMLleerCorreoNoVistosPop3()
            'agregarRegistrosXML(lista)
            'llenarGrid()
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "No hay una configuración de correo para la nave seleccionada"
            adv.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub ValidadorCFDIForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        'crearCarpetas() 'Crea carpetas necesarias para el validador
        'getSemanaActual()
        llenarComboNaves()
        aplicarpermisos()
    End Sub
    Public Sub getSemanaActual()
        'Dim obj As New CFDIBU
        'Dim datos As New DataTable
        'datos = obj.getSemanaActual
        'For Each row As DataRow In datos.Rows
        '    txtSemana.Text = row("numsem").ToString
        '    dtp1.Value = CDate(row("FecIni"))
        '    dtp2.Value = CDate(row("FecFin"))
        'Next
    End Sub
    Public Sub aplicarpermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Validador", "AUTORIZAR") Then
            pnlAutoriza.Visible = True
        Else
            pnlAutoriza.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Validador", "ELIMINAR") Then
            pnlElimina.Visible = True
        Else
            pnlElimina.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Validador", "LEERCORREO") Then
            pnlLeeCorreo.Visible = True
        Else
            pnlLeeCorreo.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Validador", "CAMBIOPROVEEDOR") Then
            Panel4.Visible = True
        Else
            Panel4.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Validador", "EDITARDATOS") Then
            Panel5.Visible = True
        Else
            Panel5.Visible = False
        End If

    End Sub

    Public Sub llenarComboNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count > 1 Then
            cmbNave.SelectedIndex = 1
            'llenarGrid() 'Cargar facturas de la tabla cfdsValidador
            If cmbNave.Items.Count = 2 Then
                cmbNave.Enabled = False
            End If
        End If
    End Sub
    Public Sub diseñoGrid()
        Try
            With grdListas.DisplayLayout.Bands(0)
                .Columns("AUTORIZAR").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("AUTORIZAR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("AUTORIZAR").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("UUID").Hidden = True
                .Columns("RFC PROVEEDOR").Hidden = False
                .Columns("RFC PROVEEDOR2").Hidden = True
                .Columns("RFC EMPRESA").Hidden = False
                .Columns("TOTAL").Format = "##,##0.00"
                .Columns("FECHA REGISTRO").Format = "dd/MM/yyyy HH:mm:ss"
                .Columns("RUTA").Hidden = False
                .Columns("idNave").Hidden = True
                .Columns("AUTORIZAR").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("IMAGEN").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                .Columns("idFactura").Hidden = True
                .Columns("PROVEEDOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("RFC PROVEEDOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("RFC EMPRESA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FECHA REGISTRO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FECHA FACTURA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("SERIE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FOLIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("TOTAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("RUTA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("CORRECTA").Hidden = True
                .Columns("IMAGEN").Header.Caption = ""
                .Columns("IMAGEN").Width = 50
                .Columns("IMAGEN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("TOTAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("VERSION").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("VERSION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("VERSION").Hidden = False
                .Columns("VERSION").Header.Caption = "Ver."
                .Columns("Regimen").Hidden = True
                .Columns("RS_NUEVA").Hidden = True
                .Columns("RS_RECEPTOR").Hidden = True


            End With
            grdListas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdListas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        Catch ex As Exception
        End Try
    End Sub
    Public Sub llenarGrid()
        Dim obj As New CFDIBU
        Dim facturas As New DataTable
        Dim facturasRecibidas As New DataTable
        Dim folioNuevo As String = ""


        Try
            facturas = obj.getCFDISinRecibir(CInt(cmbNave.SelectedValue))
            facturasRecibidas = obj.getCFDIRecibidas(CInt(cmbNave.SelectedValue), dtp1.Value, dtp2.Value)
            grdListas.DataSource = Nothing
            grdListas.DataSource = facturas
            listauuids.Clear()
            listaFolios.Clear()
            For Each row As DataRow In facturas.Rows
                listauuids.Add(row("UUID").ToString)
            Next
            For Each row As DataRow In facturasRecibidas.Rows
                listauuids.Add(row("UUID").ToString)
            Next

            diseñoGrid()
            validarRFC()
            validarRazonSocial()
        Catch ex As Exception
        End Try
    End Sub
    Function eliminarCerosIzquierda(ByVal cadena As String) As String
        If cadena.Substring(0, 1).Contains("0") Then
            cadena = cadena.Substring(1, cadena.Length - 1)
            cadena = eliminarCerosIzquierda(cadena)
        Else
            Return cadena
        End If
        Return cadena
    End Function

    Public Sub addRowGrid(idFactura As Integer, proveedor As String, rfcEmpresa As String, rfcProveedor As String, fechacaptura As String,
                          total As Double, serie As String, ruta As String, folio As String, uuid As String, errores As Integer, idNave As Integer, Version As String)
        Try
            Dim row As UltraGridRow = Me.grdListas.DisplayLayout.Bands(0).AddNew()
            row.Cells("idFactura").Value = idFactura
            row.Cells("AUTORIZAR").Value = 0
            row.Cells("PROVEEDOR").Value = proveedor
            row.Cells("RFC EMPRESA").Value = rfcEmpresa
            row.Cells("RFC PROVEEDOR").Value = rfcProveedor
            row.Cells("FECHA FACTURA").Value = fechacaptura
            row.Cells("TOTAL").Value = total
            row.Cells("SERIE").Value = serie
            row.Cells("RUTA").Value = ruta
            row.Cells("FOLIO").Value = folio
            row.Cells("idNave").Value = idNave
            If CInt(errores) > 0 Then
                row.Cells("CORRECTA").Value = 0
            Else
                row.Cells("CORRECTA").Value = 1
            End If
            row.Cells("UUID").Value = uuid


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If CInt(cmbNave.SelectedValue) > 0 Then
            Dim diferenteNave As Boolean = False
            For Each row As DataRow In CType(grdListas.DataSource, DataTable).Rows
                Dim obj As New CFDIBU
                naveSICYid = obj.getNaveSIcy(CInt(cmbNave.SelectedValue))
                If CInt(row("idNave")) = naveSICYid Then
                    diferenteNave = False
                Else
                    diferenteNave = True
                End If
                Exit For
            Next

            'If diferenteNave Then
            '    llenarGrid()
            'End If
            'If CType(grdListas.DataSource, DataTable).Rows.Count = 0 Then
            '    llenarGrid()
            'End If
            'leerCorreo()

            getFacturasOpenPop()
            llenarGrid()
            diseñoGrid()
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Selecciona una nave"
            adv.ShowDialog()
        End If
    End Sub

    Private Sub grdListas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdListas.DoubleClickCell
        'Try
        '    If Not CBool(grdListas.ActiveRow.Cells("CORRECTA").Value) Then
        '        Me.Cursor = Cursors.WaitCursor
        '        'Dim report As New Report(grdListas.ActiveRow.Cells("RUTA").Value.ToString)
        '        'report = ValidarArchivo(grdListas.ActiveRow.Cells("RUTA").Value.ToString)
        '        Dim xml As New Entidades.xml

        '        If Not report.TotalErrors = 0 Then
        '            If report.TotalErrors = 1 Then
        '                Dim totalError As Integer = 0
        '                Dim totalWarning As Integer = 0
        '                Dim totalSuggestion As Integer = 0
        '                report.TimbreValidation.Count(totalError, totalWarning, totalSuggestion)
        '                If totalError > 0 Then
        '                    xml.estatusValidacion = True
        '                Else
        '                    xml.estatusValidacion = False
        '                End If
        '            Else
        '                xml.estatusValidacion = False
        '            End If
        '        End If
        '        Me.Cursor = Cursors.Default

        '    End If
        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        'End Try

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim editarFactura As New EditarfacturaProveedorForm
        editarFactura.ProveedorNombre = grdAutorizadas.ActiveRow.Cells(1).Text
        editarFactura.Folio = grdAutorizadas.ActiveRow.Cells(7).Text
        editarFactura.FolioAnterior = grdAutorizadas.ActiveRow.Cells(7).Text
        editarFactura.NaveID = CInt(grdAutorizadas.ActiveRow.Cells(12).Text)
        editarFactura.ProveedorAnteriorID = CInt(grdAutorizadas.ActiveRow.Cells(13).Text)
        editarFactura.NaveAnteriorID = CInt(grdAutorizadas.ActiveRow.Cells(12).Text)
        editarFactura.Serie = grdAutorizadas.ActiveRow.Cells(6).Text
        editarFactura.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        'Pasar factura a carpeta de eliminados e actualizar en tabla cfdsValidador campo de eliminado a 1
        If grdListas.Rows.Count > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Está seguro que desea eliminar las facturas seleccionadas?"
            If objMensaje.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Dim obj As New CFDIBU
                Dim tabla As New DataTable
                tabla = CType(grdListas.DataSource, DataTable)
                For Each row As DataRow In tabla.Rows
                    If CBool(row("AUTORIZAR")) Then
                        obj.eliminarFactura(CInt(row("idFactura")), row("RUTA").ToString)
                        Try
                            'System.IO.File.Copy(row("RUTA").ToString, rutaComprobantes.Replace("C:\Emails\Eliminados\", "") & row("UUID").ToString & ".XML")
                            'System.IO.File.Delete(row("RUTA").ToString)
                            'System.IO.File.Copy(row("RUTA").ToString.ToUpper.Trim.Replace(".XML", ".PDF"), "C:\Emails\Eliminados\" & row("UUID").ToString)
                            'System.IO.File.Delete(row("RUTA").ToString.ToUpper.Trim.Replace(".XML", ".PDF"))
                        Catch ex As Exception
                        End Try
                    End If
                Next
                llenarGrid()
            End If
        End If
    End Sub
    Function concatenarFecha(ByVal fecha As Date) As String
        Dim cadena As String
        If fecha.Month < 10 Then
            cadena = "0" & fecha.Month & "" & fecha.Year
        Else
            cadena = "" & fecha.Month & "" & fecha.Year
        End If
        Return cadena
    End Function
    Function CopiarArchivos(ByVal ruta As String, ByVal nombreArchivo As String, ByVal ext As String, ByVal rutanombreNave As String) As String
        Try
            Dim fecha As New Date
            fecha = Date.Today
            Dim fechaCarpeta As String = concatenarFecha(fecha)
            If Not Directory.Exists(rutanombreNave) Then
                Directory.CreateDirectory(rutanombreNave)
                If Not Directory.Exists(rutanombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutanombreNave & "\" & fechaCarpeta)
                    If ruta.Length > 0 Then
                        System.IO.File.Copy(ruta, rutanombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                End If
            Else
                If Not Directory.Exists(rutanombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutanombreNave & "\" & fechaCarpeta)
                    If ruta.Length > 0 Then
                        System.IO.File.Copy(ruta, rutanombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                Else
                    If ruta.Length > 0 Then
                        System.IO.File.Copy(ruta, rutanombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                End If
            End If
            If ruta.Length > 0 Then
                Dim rutatmp As String = fechaCarpeta & "\" & nombreArchivo & "." & ext
                Return rutatmp
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        llenarGrid()
        llenarFacturasAutorizadas()
        llenarFacturasEliminadas()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdListas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListas.InitializeRow
        Me.Cursor = Cursors.WaitCursor
        If e.Row.Cells.Exists("IMAGEN") Then
            Try
                If CBool(e.Row.Cells("CORRECTA").Value) Then
                    e.Row.Cells("IMAGEN").Appearance.ImageBackground = Global.Framework.Vista.SAPY.My.Resources.Resources.correcta
                Else
                    e.Row.Cells("IMAGEN").Appearance.ImageBackground = Global.Framework.Vista.SAPY.My.Resources.Resources.incorrecta
                End If
            Catch ex As Exception
                e.Row.Cells("IMAGEN").Appearance.ImageBackground = Global.Framework.Vista.SAPY.My.Resources.Resources.incorrecta
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        If TabControl1.SelectedIndex = 0 Then
            If grdListas.Rows.Count > 0 Then
                Try
                    grdListas.ActiveRow.Selected = True
                    If grdListas.ActiveRow.Selected Then
                        Try
                            grdListas.ActiveRow.Selected = True

                            Process.Start((grdListas.ActiveRow.Cells("RUTA").Value.ToString.Trim.ToUpper.Replace("XML", "PDF")))
                        Catch ex As Exception
                            If ex.Message.Contains("no puede encontrar") Then
                                Dim form As New AdvertenciaForm
                                form.mensaje = ex.Message
                                form.ShowDialog()
                            End If
                        End Try
                    End If
                Catch ex As Exception

                End Try
            End If
        ElseIf TabControl1.SelectedIndex = 1 Then
            If grdAutorizadas.Rows.Count > 0 Then
                Try
                    grdAutorizadas.ActiveRow.Selected = True
                    If grdAutorizadas.ActiveRow.Selected Then
                        Try
                            grdAutorizadas.ActiveRow.Selected = True
                            Dim datosConfigNave As DataTable
                            Dim obj As New CFDIBU
                            datosConfigNave = obj.getConfiguracionNave(CInt(cmbNave.SelectedValue))
                            Process.Start(grdAutorizadas.ActiveRow.Cells("RUTAPDF").Value.ToString)
                        Catch ex As Exception
                            If ex.Message.Contains("no puede encontrar") Then
                                Dim form As New AdvertenciaForm
                                form.mensaje = ex.Message
                                form.ShowDialog()
                            End If

                        End Try
                    End If
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnXML.Click
        If TabControl1.SelectedIndex = 0 Then
            If grdListas.Rows.Count > 0 Then
                Try
                    grdListas.ActiveRow.Selected = True
                    If grdListas.ActiveRow.Selected Then
                        Try
                            grdListas.ActiveRow.Selected = True
                            Process.Start(grdListas.ActiveRow.Cells("RUTA").Value.ToString)
                        Catch ex As Exception
                            If ex.Message.Contains("no puede encontrar") Then
                                Dim form As New AdvertenciaForm
                                form.mensaje = ex.Message
                                form.ShowDialog()
                            End If
                        End Try
                    End If
                Catch ex As Exception

                End Try
            End If
        ElseIf TabControl1.SelectedIndex = 1 Then
            If grdAutorizadas.Rows.Count > 0 Then
                Try
                    grdAutorizadas.ActiveRow.Selected = True
                    If grdAutorizadas.ActiveRow.Selected Then
                        Try
                            grdAutorizadas.ActiveRow.Selected = True
                            Dim datosConfigNave As DataTable
                            Dim obj As New CFDIBU
                            datosConfigNave = obj.getConfiguracionNave(CInt(cmbNave.SelectedValue))
                            Process.Start(grdAutorizadas.ActiveRow.Cells("RUTAXML").Value.ToString.ToUpper.Trim)
                        Catch ex As Exception
                            If ex.Message.Contains("no puede encontrar") Then
                                Dim form As New AdvertenciaForm
                                form.mensaje = ex.Message
                                form.ShowDialog()
                            End If
                        End Try
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            lbl1.Visible = False
            lbl2.Visible = False
            dtp1.Visible = False
            dtp2.Visible = False
            btnMostrar.Visible = False
            lblMostrar.Visible = False
            txtSemana.Visible = False
            lblSemana.Visible = False
        Else
            lblSemana.Visible = True
            txtSemana.Visible = True
            lbl1.Visible = True
            lbl2.Visible = True
            dtp1.Visible = True
            dtp2.Visible = True
            btnMostrar.Visible = True
            lblMostrar.Visible = True
            If grdAutorizadas.Rows.Count = 0 Then
                llenarFacturasAutorizadas()
            End If
            If grdEliminadas.Rows.Count = 0 Then
                llenarFacturasEliminadas()
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        If TabControl1.SelectedIndex = 1 Then
            llenarFacturasAutorizadas()
        ElseIf TabControl1.SelectedIndex = 2 Then
            llenarFacturasEliminadas()
        ElseIf TabControl1.SelectedIndex = 0 Then
            llenarGrid()
            diseñoGrid()
        End If

    End Sub
    Public Sub llenarFacturasEliminadas()
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New CFDIBU

        Try
            grdEliminadas.DataSource = Nothing
            grdEliminadas.DataSource = obj.getFacturasEliminadas(CInt(cmbNave.SelectedValue), dtp1.Value, dtp2.Value)
            With grdEliminadas.DisplayLayout.Bands(0)
                .Columns("RFC PROVEEDOR").Hidden = True
                .Columns("TOTAL").Format = "##,##0.00"
                .Columns("ELIMINADA").Format = "dd/MM/yyyy HH:mm"
                .Columns("PROVEEDOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("RFC EMPRESA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FECHA FACTURA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("SERIE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FOLIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("TOTAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("TOTAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With

            grdEliminadas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdEliminadas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub llenarFacturasAutorizadas()
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New CFDIBU


        Try
            grdAutorizadas.DataSource = Nothing
            grdAutorizadas.DataSource = obj.getCFDIRecibidas(CInt(cmbNave.SelectedValue), dtp1.Value, dtp2.Value)
            'grdListas.DataSource = obj.getCFDISinRecibir(CInt(cmbNave.SelectedValue))
            With grdAutorizadas.DisplayLayout.Bands(0)
                '.Columns(" ").Width = 20
                .Columns("#").Width = 30
                .Columns("FECHA FACTURA").Width = 80
                .Columns("AUTORIZADA").Width = 80
                .Columns("SERIE").Width = 40
                .Columns("FOLIO").Width = 60
                .Columns("TOTAL").Width = 60
                .Columns("RFC PROVEEDOR").Hidden = True
                '.Columns("CORRECTA").Hidden = True
                '.Columns("RUTA").Hidden = True
                .Columns("NAVEID").Hidden = True
                .Columns("PROVEEDORID").Hidden = True
                .Columns("TOTAL").Format = "##,##0.00"
                .Columns("AUTORIZADA").Format = "dd/MM/yyyy HH:mm"
                .Columns("PROVEEDOR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                '.Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("RFC EMPRESA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FECHA FACTURA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("SERIE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("FOLIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("TOTAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("AUTORIZADA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("UUID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("rutaXML").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("rutaPDF").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                .Columns("TOTAL").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                ' .Columns("IMAGEN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                '.Columns("IMAGEN").Header.Caption = ""
                '.Columns("IMAGEN").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
                ' .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                '.Columns("IMAGEN").Width = 50
                '.Columns("IMAGEN").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            End With

            grdAutorizadas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdAutorizadas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        Catch ex As Exception
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Dim c As Integer = 0
    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        c += 1
        If c = 25 Then
            Panel2.Visible = False
        Else
            Panel2.Visible = True
        End If
        'getRutaReal("")
    End Sub

    Function getDatosXML(ruta As String) As Entidades.xml
        Dim datosxml As New Entidades.xml
        Dim reader As XmlTextReader = New XmlTextReader(ruta)
        Try
            Do While (reader.Read())
                If reader.Name = "cfdi:Comprobante" Or reader.Name = "Comprobante" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name.ToUpper = "SERIE" Or reader.Name = "Serie" Then
                                datosxml.serie = reader.Value
                            ElseIf reader.Name.ToUpper = "FOLIO" Or reader.Name = "Folio" Then
                                datosxml.folio = reader.Value
                            ElseIf reader.Name.ToUpper = "SUBTOTAL" Or reader.Name = "SubTotal" Then
                                datosxml.subTotal = CDbl(reader.Value)
                            ElseIf reader.Name.ToUpper = "TOTAL" Or reader.Name = "Total" Then
                                datosxml.total = CDbl(reader.Value)
                            ElseIf reader.Name.ToUpper = "FECHA" Or reader.Name = "Fecha" Then
                                datosxml.fechaxml = CDate(reader.Value)
                            ElseIf reader.Name.ToUpper = "VERSION" Or reader.Name = "Version" Then
                                datosxml.version = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Emisor" Or reader.Name = "Emisor" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name.ToUpper = "RFC" Or reader.Name = "Rfc" Then
                                datosxml.rfcEmisor = reader.Value
                            ElseIf reader.Name.ToUpper = "NOMBRE" Or reader.Name = "Nombre" Then
                                datosxml.razonSocEmisor = reader.Value
                            ElseIf reader.Name.ToUpper = "REGIMENFISCAL" Or reader.Name = "RegimenFiscal" Then
                                datosxml.RegimenFiscal = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Receptor" Or reader.Name = "Receptor" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name.ToUpper = "RFC" Or reader.Name = "Rfc" Then
                                datosxml.rfcReceptor = reader.Value
                            ElseIf reader.Name.ToUpper = "NOMBRE" Or reader.Name = "Nombre" Then
                                datosxml.razonSocReceptor = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Traslado" Or reader.Name = "Traslado" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name.ToUpper = "IMPORTE" Or reader.Name = "Importe" Then
                                datosxml.iva = CDbl(reader.Value)
                            End If
                        End While
                    End If
                End If
                If reader.Name = "tfd:TimbreFiscalDigital" Or reader.Name = "TimbreFiscalDigital" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name.ToUpper = "UUID" Or reader.Name = "uuid" Then
                                datosxml.uuid = reader.Value
                            End If
                        End While
                    End If
                End If
            Loop
            reader.Close()
        Catch ex As Exception
        End Try
        Return datosxml
    End Function


    Private Sub ValidadorCFDIForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Application.Exit()
    End Sub

    Private Sub grdAutorizadas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdAutorizadas.InitializeRow
        Me.Cursor = Cursors.WaitCursor
        If e.Row.Cells.Exists("IMAGEN") Then
            Try
                If CBool(e.Row.Cells("CORRECTA").Value) Then
                    e.Row.Cells("IMAGEN").Appearance.ImageBackground = Global.Framework.Vista.SAPY.My.Resources.Resources.correcta
                Else
                    e.Row.Cells("IMAGEN").Appearance.ImageBackground = Global.Framework.Vista.SAPY.My.Resources.Resources.incorrecta
                End If
            Catch ex As Exception
                e.Row.Cells("IMAGEN").Appearance.ImageBackground = Global.Framework.Vista.SAPY.My.Resources.Resources.incorrecta
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdAutorizadas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdAutorizadas.DoubleClickCell
        'Try
        '    If Not CBool(grdAutorizadas.ActiveRow.Cells("CORRECTA").Value) Then
        '        Me.Cursor = Cursors.WaitCursor
        '        Dim report As New Report(grdAutorizadas.ActiveRow.Cells("RUTA").Value.ToString)
        '        report = ValidarArchivo(grdAutorizadas.ActiveRow.Cells("RUTA").Value.ToString)
        '        Me.Cursor = Cursors.Default
        '        MostrarResultado(report)
        '    End If

        'Catch ex As Exception
        '    Me.Cursor = Cursors.Default
        'End Try
    End Sub

    Private Sub txtSemana_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSemana.KeyPress
        Try
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSemana_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSemana.KeyDown
        'Try
        '    If e.KeyCode = System.Windows.Forms.Keys.Enter Then
        '        'Recuperar datos de semana
        '        Dim semana As Integer = CInt(txtSemana.Text)
        '        Dim obj As New CFDIBU
        '        Dim datos As New DataTable
        '        datos = obj.getDatosSemana(semana)

        '        For Each row As DataRow In datos.Rows
        '            dtp1.Value = CDate(row("FecIni"))
        '            dtp2.Value = CDate(row("FecFin"))
        '            llenarFacturasAutorizadas()
        '            llenarFacturasEliminadas()
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub rdo1_CheckedChanged(sender As Object, e As EventArgs) Handles rdo1.CheckedChanged
        If rdo1.Checked Then
            tipoFacturas = 1
            llenarFacturasAutorizadas()
            llenarGrid()

        End If
    End Sub

    Private Sub rdo2_CheckedChanged(sender As Object, e As EventArgs) Handles rdo2.CheckedChanged
        If rdo2.Checked Then
            tipoFacturas = 2
            llenarFacturasAutorizadas()
            llenarGrid()
        End If
    End Sub

    'No sabemos paea que sirve 
    'Private Sub rdo3_CheckedChanged(sender As Object, e As EventArgs) Handles rdo3.CheckedChanged
    '    If rdo3.Checked Then
    '        tipoFacturas = 3
    '        llenarFacturasAutorizadas()
    '        llenarGrid()
    '    End If
    'End Sub


    ' ''' <summary>
    ' ''' Este metodo no se usa es de prueba
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub btnTest_Click(sender As Object, e As EventArgs)
    '    Dim report As New Report("C:\VIOA790827JIA_AA3607.XML")
    '    report = ValidarArchivo("C:\VIOA790827JIA_AA3607.XML")
    '    Dim xml As New Entidades.xml
    '    If report.TotalErrors = 0 Then
    '        xml.estatusValidacion = True
    '    Else
    '        If report.TotalErrors = 1 Then
    '            Dim totalError As Integer = 0
    '            Dim totalWarning As Integer = 0
    '            Dim totalSuggestion As Integer = 0
    '            report.TimbreValidation.Count(totalError, totalWarning, totalSuggestion)
    '            If totalError > 0 Then
    '                xml.estatusValidacion = True
    '            Else
    '                xml.estatusValidacion = False
    '            End If
    '        Else
    '            xml.estatusValidacion = False
    '        End If
    '    End If
    'End Sub

    ''' <summary>
    ''' @autor Juana Guerrero
    ''' @Marco Arredondo
    ''' 14feb2017
    ''' Implementar descargar adjuntos de correo con librería openpop
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getFacturasOpenPop()
        Cursor = Cursors.WaitCursor
        Dim cliente As New OpenPop.Pop3.Pop3Client
        Dim obj As New CFDIBU
        Dim datosConfigNave As New DataTable
        Dim bandera As Boolean = False
        Dim emailAddress As String = ""
        Dim Password As String = ""
        Dim popServer As String = "pop.secureserver.net"
        Dim puerto As String = ""

        Dim hayConfig As Boolean
        Try
            datosConfigNave = obj.getConfiguracionNave(CInt(cmbNave.SelectedValue))
            For Each row As DataRow In datosConfigNave.Rows()
                Password = row("fac_contrasena").ToString
                popServer = row("fac_serverEntrada").ToString
                emailAddress = row("fac_correo").ToString
                puerto = row("fac_puertoEntrada").ToString
                rutaComprobantes = row("fac_rutaFacturasPorAutorizar").ToString
                hayConfig = True
            Next
        Catch ex As Exception
            Dim adv As New AdvertenciaForm
            adv.mensaje = "No hay una configuración de correo para la nave seleccionada"
            adv.ShowDialog()
        End Try

        If hayConfig Then
            Try
                cliente.Connect(popServer, CInt(puerto), False)
                cliente.Authenticate(emailAddress, Password)
                Dim messagecount As Integer = cliente.GetMessageCount
                Dim messages As New List(Of OpenPop.Mime.Message)
                Dim lista As New List(Of String)

                For i As Integer = 1 To messagecount
                    Try
                        Dim mensaje As OpenPop.Mime.Message = cliente.GetMessage(i)
                        messages.Add(mensaje)

                    Catch e As Exception
                        '  MsgBox(e.ToString)
                    End Try

                Next

                'Descarga comprobantes y los guarda en la ruta
                'Dim contadorCorreos As Integer = 1
                Dim contadorCorreos As Integer = 0
                For Each msg As OpenPop.Mime.Message In messages
                    Dim idFactura As Integer
                    Dim contadorArchivos, contadorInserciones As Integer

                    'FOR DE DESCARGA DE TODOS LOS ARCHIVOS ADJUNTOS
                    For Each attachment As OpenPop.Mime.MessagePart In msg.FindAllAttachments
                        If (attachment.FileName.ToUpper.Contains(".XML") Or attachment.FileName.ToUpper.Contains(".PDF")) Then
                            attachment.Save(New System.IO.FileInfo(System.IO.Path.Combine(rutaComprobantes, attachment.FileName)))
                        End If

                        'Valida si es xml y agrega la ruta donde se descargó el archivo
                        If attachment.FileName.Contains(".XML") Or attachment.FileName.Contains(".xml") Then
                            'lista.Add(rutaComprobantes + "\" + attachment.FileName)
                            idFactura = insertarRegistrosXML(System.IO.Path.Combine(rutaComprobantes, attachment.FileName))

                            'Borrar correos
                            'contadorArchivos += 1
                            If idFactura <> 0 Then
                                contadorArchivos += 1
                                contadorInserciones += 1
                            End If
                        End If



                    Next
                    'Si el número de xml descargados el número de inserciones son el mismo se borra el correo
                    contadorCorreos += 1
                    If contadorArchivos = contadorInserciones And contadorArchivos > 0 Then
                        cliente.DeleteMessage(contadorCorreos)
                        contadorArchivos = 0
                        contadorInserciones = 0
                    End If

                    'contadorCorreos += 1
                Next

                cliente.Disconnect()
                'INSERTA EN CFDVALIDADOR Y AGREGA ROW AL GRID
                'Método de inserción a la BD de basado en los attachments del correo
                ''insertarRegistrosXML(lista.ru)

            Catch ex As Exception
                'Si cae en la excepción no debe de borrar la bandeja de entrada del correo
                'MsgBox("Ocurrió un error al leer correo.")
                ' MsgBox(ex.ToString)
                'Try
                '    Dim objHistorialBu As New HistorialBU
                '    Dim hist As New Entidades.Historial
                '    hist.PHistFecha = DateTime.Today
                '    hist.PHistMensaje = "NAVE: " + cmbNave.SelectedText.ToString + " Error: " + ex.Message.ToString
                '    hist.PHistSentencia = " "
                '    hist.PHistUsuarioId = SesionUsuarios.usuarioid

                'Catch ex2 As Exception
                '    '
                'End Try
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    'NO USAR MÁS POR QUE ES EL QUE MARCA LOS ERRORES
    'Private Sub insertarRegistrosXML(lista As List(Of String))
    '    Dim xml As New Entidades.xml
    '    Dim obj As New CFDIBU

    '    Try
    '        For Each ruta As String In lista
    '            Dim reporte As New Report(ruta)
    '            reporte = ValidarArchivo(ruta)

    '            Dim idFactura As Integer = 0
    '            Dim serie As String = ""
    '            Dim folio As String = ""

    '            'Valida si no existe ya un registro en la BD de la factura
    '            'If Not existeEnBD(reporte.BaseInformation.TimbreUuid.TrimValue) Then
    '            'Inserta en CFDS VALIDADOR

    '            'Agregar modificacion de acuerdo a lo que mencionó Juanita con los datos XML igual que se usan en AltaPolizaForm -> Extraer UUID
    '            If Not reporte.BaseInformation.TimbreUuid Is Nothing Then
    '                If Not listauuids.Contains(reporte.BaseInformation.TimbreUuid.TrimValue) Then
    '                    If Not reporte.BaseInformation.Serie Is Nothing Then
    '                        serie = reporte.BaseInformation.Serie.TrimValue
    '                    End If
    '                    xml.rfcReceptor = reporte.BaseInformation.Receptor.Rfc.TrimValue
    '                    xml.rfcEmisor = reporte.BaseInformation.Emisor.Rfc.TrimValue
    '                    xml.fechaxml = CDate(reporte.BaseInformation.FechaDocumento.TrimValue)
    '                    xml.version = reporte.BaseInformation.Version.ToString
    '                    xml.serie = serie.ToUpper
    '                    If Not reporte.BaseInformation.Folio Is Nothing Then
    '                        folio = reporte.BaseInformation.Folio.TrimValue
    '                    Else
    '                      
    '                    End If
    '                    xml.folio = folio
    '                    xml.total = CDbl(reporte.BaseInformation.Total.TrimValue)
    '                    xml.subTotal = CDbl(reporte.BaseInformation.SubTotal.TrimValue)
    '                    'Revisar que pasa con esto
    '                    'xml.moneda = reporte.BaseInformation.Moneda.TrimValue
    '                    xml.rutaxml = ruta.ToUpper.Trim
    '                    xml.rutapdf = ruta.ToUpper.Trim.Replace(".XML", ".PDF")
    '                    xml.uuid = reporte.BaseInformation.TimbreUuid.TrimValue
    '                    xml.razonSocEmisor = reporte.BaseInformation.Emisor.Nombre.TrimValue
    '                    listauuids.Add(reporte.BaseInformation.TimbreUuid.TrimValue)
    '                    If reporte.TotalErrors = 0 Then
    '                        xml.estatusValidacion = True
    '                    Else
    '                        If reporte.TotalErrors = 1 Then
    '                            Dim totalError As Integer = 0
    '                            Dim totalWarning As Integer = 0
    '                            Dim totalSuggestion As Integer = 0
    '                            reporte.TimbreValidation.Count(totalError, totalWarning, totalSuggestion)
    '                            If totalError > 0 Then
    '                                xml.estatusValidacion = True
    '                            Else
    '                                xml.estatusValidacion = False
    '                            End If
    '                        Else
    '                            xml.estatusValidacion = False
    '                        End If
    '                    End If
    '                    xml.idNave = CInt(cmbNave.SelectedValue)
    '                    idFactura = obj.insertarFactura(xml)

    '                    'addRowGrid(idFactura, reporte.BaseInformation.Emisor.Nombre.TrimValue,
    '                    '           reporte.BaseInformation.Receptor.Rfc.TrimValue,
    '                    '           reporte.BaseInformation.Emisor.Rfc.TrimValue, reporte.BaseInformation.FechaDocumento.TrimValue,
    '                    '           CDbl(reporte.BaseInformation.Total.TrimValue), serie, ruta, reporte.BaseInformation.Folio.TrimValue,
    '                    '           reporte.BaseInformation.TimbreUuid.TrimValue, reporte.TotalErrors, obj.getNaveSIcy(xml.idNave))
    '                End If
    '            Else
    '                xml = getDatosXML(ruta)
    '                If Not xml.folio Is Nothing Then
    '                    xml.idNave = CInt(cmbNave.SelectedValue)
    '                    xml.estatusValidacion = False
    '                    xml.rutaxml = ruta.ToUpper
    '                    xml.rutapdf = ruta.ToUpper.Replace(".XML", ".PDF")
    '                    If Not xml.serie Is Nothing Then
    '                        serie = xml.serie
    '                    End If
    '                    idFactura = obj.insertarFactura(xml)
    '                    'addRowGrid(idFactura, xml.razonSocEmisor,
    '                    '           xml.rfcReceptor,
    '                    '           xml.rfcEmisor, CStr(xml.fechaxml),
    '                    '           CDbl(xml.total), serie, ruta, xml.folio,
    '                    '           xml.uuid, 1, obj.getNaveSIcy(xml.idNave))
    '                End If
    '            End If

    '            ' End If
    '        Next
    '        llenarGrid()
    '    Catch ex As Exception
    '        MsgBox("Ha ocurrido un error al insertar los registros en la base de datos.")
    '        MsgBox(ex.ToString)
    '    End Try

    'End Sub

    Private Function insertarRegistrosXML(ByVal rutaXML As String) As Integer
        Dim xml As New Entidades.xml
        Dim obj As New CFDIBU
        Dim advertencia As New Tools.AdvertenciaForm
        Dim mensaje As String = ""

        Try
            xml = getDatosXML(rutaXML)
            xml.idNave = CInt(cmbNave.SelectedValue)
            xml.rutaxml = rutaXML
            xml.rutapdf = rutaXML.ToUpper.Replace(".XML", ".PDF")


            'SE COMENTÓ PORQUE SE REALIZA DESDE EL PROCEDIMIENTO ALMACENADO -> [dbo].[insertCFDIValidada]'
            If xml.folio Is Nothing Then
                'xml.folio = xml.uuid.Substring(0, 8)
                xml.folio = ""
            End If


            'No modificar esta parte del código, Ya que es correcto cuando no tiene serie pero folio si'
            If xml.serie Is Nothing Then
                xml.serie = ""
            End If



            'AL IMPLEMENTAR SERVICIO DE VALIDACIÓN REEMPLAZAR ESTA LINEA (ESPERARA A JOSÉ)
            'SI LA CANTIDAD DE ERRORES ES 0 ES TRUE, SI NO ES FALSE
            xml.estatusValidacion = True

            'VALIDAR QUE NO EXISTA EN LA BASE DE DATOS
            If Not xml.uuid Is Nothing Then
                '    If Not existeEnBD(xml.uuid.ToString) Then
                '        Return obj.insertarFactura(xml)
                '    Else
                '        Return 1
                '    End If
                'Else
                '    Return 0
                'End If
                mensaje = existeEnBD(xml.uuid.ToString)

                If mensaje = "" Then
                    Return obj.insertarFactura(xml)
                Else
                    MessageBox.Show(mensaje.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return 1
                End If

            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Ha ocurrido un error. \n" + ex.ToString)
            Return 0
        End Try
    End Function
    Private Function existeEnBD(ByVal uuid As String) As String
        Dim obj As New CFDIBU
        Return obj.validarExistenciaFactura(uuid)

    End Function
    Private Sub validarRFC()
        For i = 0 To grdListas.Rows.Count - 1
            If grdListas.Rows(i).Cells(4).Value.ToString.Equals("") Then
                grdListas.Rows(i).Appearance.BackColor = Color.LightCoral
            End If
        Next
    End Sub

    Private Sub validarRazonSocial()
        Dim longitud As Integer = 0
        Dim sc As String

        For i = 0 To grdListas.Rows.Count - 1
            If grdListas.Rows(i).Cells(17).Value.ToString.Equals("601") And grdListas.Rows(i).Cells(12).Value.ToString.Equals("3.3") Then
                If InStr(1, grdListas.Rows(i).Cells(18).Value.ToString, "SADECV") > 0 Or InStr(1, grdListas.Rows(i).Cells(18).Value.ToString, "SACV") > 0 Or InStr(1, grdListas.Rows(i).Cells(18).Value.ToString, "SDERLDECV") > 0 Or InStr(1, sc, "SC") > 0 And InStr(1, grdListas.Rows(i).Cells(19).Value.ToString, "SADECV") > 0 Or InStr(1, grdListas.Rows(i).Cells(19).Value.ToString, "SACV") > 0 Then
                    ' grdListas.Rows(i).Appearance.BackColor = Color.LightPink
                Else
                    grdListas.Rows(i).Appearance.BackColor = Color.Plum
                End If
            End If

        Next
    End Sub

    Private Sub btnCambioProveedor_Click(sender As Object, e As EventArgs) Handles btnCambioProveedor.Click
        Dim ActualizarProveedor As New ActualizaProveedorCFDIForm
        ActualizarProveedor.ProveedorNombre = grdAutorizadas.ActiveRow.Cells(1).Text
        ActualizarProveedor.Folio = grdAutorizadas.ActiveRow.Cells(7).Text
        ActualizarProveedor.NaveID = CInt(grdAutorizadas.ActiveRow.Cells(13).Text)
        ActualizarProveedor.ProveedorAnteriorID = CInt(grdAutorizadas.ActiveRow.Cells(14).Text)
        ActualizarProveedor.Serie = grdAutorizadas.ActiveRow.Cells(6).Text
        ActualizarProveedor.ShowDialog()
        btnMostrar_Click(Nothing, Nothing)
    End Sub
End Class