Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Framework.Negocios
Imports Tools
Imports System.IO
Imports System.Drawing
Imports Stimulsoft.Report

Public Class ListaSolicitudesIncapacidadesForm
    Dim colaboradorIncId As Int32 = 0
    Dim fechaInicioInc As Date
    Dim fechaFinInc As Date
    Dim idIncGlobal As Int32 = 0

    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property

    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronEmpresa()
        If dtEmpresa.Rows.Count > 0 Then
            cmbPatron.DataSource = dtEmpresa
            cmbPatron.DisplayMember = "Patron"
            cmbPatron.ValueMember = "ID"
            cmbPatron.SelectedIndex = 0
        End If
    End Sub

    Public Sub mostrarListado()
        Dim objBu As New Negocios.IncapacidadesContabilidadBU
        Dim dtListado As New DataTable
        Dim idPatron As Int32 = 0
        Dim idEstatus As Int32 = 0
        Dim porFechas As Boolean = False
        Dim fechaInicio As String
        Dim fechaFin As String
        colaboradorIncId = 0
        Dim tipoIncapacidadid As Int32 = 0

        grdIncapacidades.DataSource = Nothing
        idPatron = cmbPatron.SelectedValue
        idEstatus = cmbEstatus.SelectedValue
        porFechas = chkPorFechas.Checked
        fechaInicio = "'" + dttInicio.Value.ToShortDateString + "'"
        fechaFin = "'" + dttFin.Value.ToShortDateString + " 23:59:00'"
        tipoIncapacidadid = cmbTipoIncapacidad.SelectedValue

        dtListado = objBu.listadoSolicitudesIncapacidades(idPatron, idEstatus, txtNombre.Text, porFechas, fechaInicio, fechaFin, tipoIncapacidadid)

        If dtListado.Rows.Count > 0 Then
            grdIncapacidades.DataSource = dtListado
            formatoGrid()
        Else
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "La consulta no devolvió resultados"
            advetencia.ShowDialog()
        End If
    End Sub

    Public Sub formatoGrid()
        With grdIncapacidades.DisplayLayout.Bands(0)

            .Columns("idColaborador").Hidden = True
            .Columns("idIncapacidad").Hidden = True
            .Columns("rojo").Hidden = True
            .Columns("existeCarta").Hidden = True
            .Columns("existest2").Hidden = True
            .Columns("existest7").Hidden = True
            .Columns("cartaIncapacidad").Hidden = True
            .Columns("formatost7").Hidden = True
            .Columns("formatost2").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("apaterno").Header.Caption = "A.Paterno"
            .Columns("aMaterno").Header.Caption = "A.Materno"
            .Columns("nombre").Header.Caption = "Nombre"
            .Columns("folio").Header.Caption = "Folio Inc."
            .Columns("diasAut").Header.Caption = "Días Autorizados"
            .Columns("fechaInicio").Header.Caption = "Fecha Inicio"
            .Columns("fechafin").Header.Caption = "Fecha Fin"
            .Columns("fechaSolicitud").Header.Caption = "Fecha Solicitud"
            .Columns("tipoIncapacidad").Header.Caption = "Tipo Incapacidad"
            .Columns("controlInc").Header.Caption = "Control Incapacidad"
            .Columns("motivo").Header.Caption = "Motivo"


            .Columns("apaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("aMaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("folio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasAut").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaInicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechafin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaSolicitud").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoIncapacidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("controlInc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("motivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit



            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        If chkTodos.Checked = True Then
            grdIncapacidades.DisplayLayout.Bands(0).Columns.Add("carta", "carta")
            Dim colCarta As UltraGridColumn = grdIncapacidades.DisplayLayout.Bands(0).Columns("carta")
            colCarta.AllowRowFiltering = DefaultableBoolean.False
            colCarta.Header.Caption = "Carta Incapacidad"
            colCarta.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            'colCarta.Width = 20

            grdIncapacidades.DisplayLayout.Bands(0).Columns.Add("st7", "st7")
            Dim colSt7 As UltraGridColumn = grdIncapacidades.DisplayLayout.Bands(0).Columns("st7")
            colSt7.AllowRowFiltering = DefaultableBoolean.False
            colSt7.Header.Caption = "Formato ST7"
            colSt7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            'colSt7.Width = 20

            grdIncapacidades.DisplayLayout.Bands(0).Columns.Add("st2", "st2")
            Dim colSt2 As UltraGridColumn = grdIncapacidades.DisplayLayout.Bands(0).Columns("st2")
            colSt2.AllowRowFiltering = DefaultableBoolean.False
            colSt2.Header.Caption = "Formato ST2"
            colSt2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            'colSt2.Width = 20
        Else
            If chkIncapacidad.Checked = True Then

                grdIncapacidades.DisplayLayout.Bands(0).Columns.Add("carta", "carta")
                Dim colCarta As UltraGridColumn = grdIncapacidades.DisplayLayout.Bands(0).Columns("carta")
                colCarta.AllowRowFiltering = DefaultableBoolean.False
                colCarta.Header.Caption = "Carta Incapacidad"
                colCarta.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            End If

            If chkFormatoSt7.Checked = True Then

                grdIncapacidades.DisplayLayout.Bands(0).Columns.Add("st7", "st7")
                Dim colSt7 As UltraGridColumn = grdIncapacidades.DisplayLayout.Bands(0).Columns("st7")
                colSt7.AllowRowFiltering = DefaultableBoolean.False
                colSt7.Header.Caption = "Formato ST7"
                colSt7.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image
            End If

            If chkFormatoSt2.Checked = True Then
                grdIncapacidades.DisplayLayout.Bands(0).Columns.Add("st2", "st2")
                Dim colSt2 As UltraGridColumn = grdIncapacidades.DisplayLayout.Bands(0).Columns("st2")
                colSt2.AllowRowFiltering = DefaultableBoolean.False
                colSt2.Header.Caption = "Formato ST2"
                colSt2.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Image

            End If
        End If




        grdIncapacidades.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdIncapacidades.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdIncapacidades.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdIncapacidades.DisplayLayout.Override.RowSelectorWidth = 35
        grdIncapacidades.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdIncapacidades.Rows(0).Selected = True

        grdIncapacidades.DisplayLayout.Bands(0).Columns("seleccion").Width = 35
        'grdIncapacidades.DisplayLayout.Bands(0).Columns("st2").Width = 50
        'grdIncapacidades.DisplayLayout.Bands(0).Columns("st7").Width = 50
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdIncapacidades.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("SOL_INC", "EDITAR_INC") Then
            pnlEditar.Visible = True
        Else
            pnlEditar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("SOL_INC", "EDITAR_INC") Then
            pnlEditar.Visible = True
        Else
            pnlEditar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("SOL_INC", "ALTAS_INC") Then
            pnlAltas.Visible = True
        Else
            pnlAltas.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("SOL_INC", "GENTXT_INC") Then
            pnlTXT.Visible = True
        Else
            pnlTXT.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("SOL_INC", "APLICAR_INC") Then
            pnlAplicar.Visible = True
            pnlAplicar.Visible = False
        Else
            pnlAplicar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("SOL_INC", "IMPRIMIR_INC") Then
            pnlImprimir.Visible = True
            pnlExportar.Visible = True
        Else
            pnlImprimir.Visible = False
            pnlExportar.Visible = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdIncapacidades.Height = 471
        grdIncapacidades.Top = 115
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 138
        grdIncapacidades.Height = 346
        grdIncapacidades.Top = 240
    End Sub

    Private Sub ListaSolicitudesIncapacidadesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        dttFin.Value = Today
        dttInicio.Value = Today
        dttInicio.Enabled = False
        dttFin.Enabled = False
        cargarComboEmpresaPatron()
        cargarComboEstatus()
        configurarPermisosBotonesEspeciales()
        llenarComboRamoDelSeguro()

        If pPatronId <> 0 And cmbPatron.Items.Count > 0 Then
            cmbPatron.SelectedValue = pPatronId
            If pEstatusId <> 0 Then
                cmbEstatus.SelectedValue = pEstatusId
            End If
            mostrarListado()
        End If
    End Sub


    Public Sub cargarComboEstatus()
        Dim objBu As New Negocios.UtileriasBU
        Dim dtEstatus As New DataTable
        dtEstatus = objBu.consultaListadoEstatus("INCAPACIDADES")

        If dtEstatus.Rows.Count > 0 Then
            cmbEstatus.DataSource = dtEstatus
            cmbEstatus.DisplayMember = "Estatus"
            cmbEstatus.ValueMember = "ID"
            cmbEstatus.SelectedValue = 110
        End If
    End Sub

    Public Sub limpiarCampos()
        grdIncapacidades.DataSource = Nothing
        cmbEstatus.SelectedValue = 110
        dttInicio.Value = Today
        dttFin.Value = Today
        txtNombre.Text = ""
        chkPorFechas.Checked = False
        chkFormatoSt2.Checked = False
        chkIncapacidad.Checked = False
        chkFormatoSt7.Checked = False
        chkTodos.Checked = False
        cmbPatron.SelectedIndex = 0
        colaboradorIncId = 0
        idIncGlobal = 0
    End Sub
    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        limpiarCampos()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            mostrarListado()
        End If
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        mostrarListado()
    End Sub

    Private Sub grdIncapacidades_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdIncapacidades.ClickCell
        With grdIncapacidades
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Dim rutaSplit As String()
        Dim col As Int32 = 0

        Dim ruta As String = String.Empty
        With grdIncapacidades
            col = .ActiveCell.Column.Index
        End With

        If col > 14 Then
            If chkTodos.Checked Then
                ruta = grdIncapacidades.ActiveRow.Cells(col - 3).Value
            Else
                If chkIncapacidad.Checked = True And chkFormatoSt7.Checked = True And chkFormatoSt2.Checked = True Then
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 3).Value
                ElseIf chkIncapacidad.Checked = True And chkFormatoSt7.Checked = True Then
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 3).Value
                ElseIf chkFormatoSt2.Checked = True And chkFormatoSt7.Checked = True Then
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 2).Value
                ElseIf chkIncapacidad.Checked = True And chkFormatoSt2.Checked = True Then
                    grdIncapacidades.ActiveRow.Cells("formatost7").Value = grdIncapacidades.ActiveRow.Cells("formatost2").Value
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 3).Value
                ElseIf chkIncapacidad.Checked Then
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 3).Value
                ElseIf chkFormatoSt7.Checked Then
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 2).Value
                ElseIf chkFormatoSt2.Checked Then
                    ruta = grdIncapacidades.ActiveRow.Cells(col - 1).Value
                End If

            End If
            If ruta <> "" Then
                rutaSplit = ruta.Split("/")
                abrirArchivo(rutaSplit(2), rutaSplit(0).ToString + "/" + rutaSplit(1).ToString)
                'descargarArchivo(rutaSplit(2), rutaSplit(0).ToString + "/" + rutaSplit(1).ToString)
            End If

            If ruta = "" Then
                colaboradorIncId = grdIncapacidades.ActiveRow.Cells("idColaborador").Value
                idIncGlobal = grdIncapacidades.ActiveRow.Cells("idIncapacidad").Value
                fechaInicioInc = grdIncapacidades.ActiveRow.Cells("fechaInicio").Value
                fechaFinInc = grdIncapacidades.ActiveRow.Cells("fechaFin").Value

            End If
        Else
            colaboradorIncId = grdIncapacidades.ActiveRow.Cells("idColaborador").Value
            idIncGlobal = grdIncapacidades.ActiveRow.Cells("idIncapacidad").Value
            fechaInicioInc = grdIncapacidades.ActiveRow.Cells("fechaInicio").Value
            fechaFinInc = grdIncapacidades.ActiveRow.Cells("fechaFin").Value

        End If

    End Sub

    Public Sub abrirArchivo(ByVal nombreArchivo As String, ByVal carpeta As String)
        Dim rutaD As String = String.Empty
        Try

            rutaD = rutaFTPHttp + carpeta + "/" + nombreArchivo
            If rutaD <> "" Then
                Process.Start(rutaD)
            End If
        Catch ex As Exception
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "No se encontro el archivo"
            advetencia.ShowDialog()
        End Try
    End Sub
    Public Sub descargarArchivo(ByVal nombreArchivo As String, ByVal rutaArchivo As String)
        Dim objTransferencias As New Tools.TransferenciaFTP
        Dim objFTP As New Tools.TransferenciaFTP


        guardarArchivo.RestoreDirectory = True
        guardarArchivo.Title = "Guardar en:"

        guardarArchivo.Filter = "JPEG|*.jpg"



        guardarArchivo.FileName = nombreArchivo
        Dim tabla() As String
        If guardarArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then

            tabla = Split(guardarArchivo.FileName, "\")
            Dim Rutaguardar As String = ""
            For n = 0 To UBound(tabla, 1)
                If UBound(tabla) = n Then
                Else
                    Rutaguardar += tabla(n) + "\"
                End If
            Next

            Dim Origen As String = ""
            Origen = rutaArchivo
            objFTP.DescargarArchivo(Origen, Rutaguardar, nombreArchivo)

            Dim exito As New ExitoForm
            exito.mensaje = "Se descargó correctamente el archivo"
            exito.ShowDialog()
        End If
    End Sub

    Public Sub consultarIncapacidad()
        Dim ObjEditar As New EditarIncapacidadesForm
        If colaboradorIncId <> 0 Then
            ObjEditar.btnGuardarEditar.Visible = False
            ObjEditar.btnEliminar.Visible = False
            ObjEditar.lblGuardarEditar.Visible = False
            ObjEditar.lblEliminar.Visible = False
            ObjEditar.btnAgregar.Visible = False
            ObjEditar.lblAgregar.Visible = False

            ObjEditar.colaboradorIncapacidadId = colaboradorIncId
            ObjEditar.fechaInicioInc = fechaInicioInc
            ObjEditar.fechaFinInc = fechaFinInc
            ObjEditar.Show()
        Else
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "Seleccione una incapacidad válida"
            advetencia.ShowDialog()
        End If
    End Sub

    Public Sub generartxt()
        Dim incapacidadesIds As String = String.Empty
        Dim incaIds As String = String.Empty
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim objBu As New Negocios.IncapacidadesContabilidadBU
        Dim dtSua As New DataTable
        Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")

        For Each row As UltraGridRow In grdIncapacidades.Rows

            If row.Cells("seleccion").Value Then
                incapacidadesIds &= row.Cells("idIncapacidad").Value & ","
                incaIds &= "(" & row.Cells("idIncapacidad").Value & "),"
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            incapacidadesIds = incapacidadesIds.Substring(0, incapacidadesIds.Length - 1)
            dtSua = objBu.consultarInformacionSUA(incapacidadesIds)

            If Not dtSua Is Nothing Then
                If dtSua.Rows.Count > 0 Then
                    If dtSua.Rows.Count = contSeleccionadas Then
                        Dim pathArchivo As String = String.Empty
                        Dim pathIncSua As String = String.Empty
                        pathArchivo = generarArchivoTXT(dtSua, fecha)
                        pathIncSua = generaTXTDatosIncapacidad(dtSua, fecha)
                        If pathArchivo <> "" And pathIncSua <> "" Then
                            incaIds = incaIds.Substring(0, incaIds.Length - 1)
                            objBu = New Negocios.IncapacidadesContabilidadBU
                            If objBu.cambiarEstatusIncapacidades(incaIds, 2) = "EXITO" Then
                                objMensajeExito.mensaje = "El archivo se generó correctamente con nombre: " & IO.Path.GetFileName(pathArchivo) & "."
                                objMensajeExito.ShowDialog()
                                mostrarListado()
                            Else
                                objMensajeError.mensaje = "No se pudieron procesar los movimientos seleccionados, favor de revisar los datos."
                                objMensajeError.ShowDialog()
                            End If
                        Else
                            objMensajeError.mensaje = "No se pudo generar el TXT de los movimientos seleccionados, favor de revisar los datos."
                            objMensajeError.ShowDialog()
                        End If

                    Else
                        objMensajeAdv.mensaje = "La consulta de la información para el archivo no arrojó todos los resultados, favor de revisar los datos."
                        objMensajeAdv.ShowDialog()
                    End If


                Else
                    objMensajeAdv.mensaje = "La consulta de la información para el archivo no arrojó ningún resultado, favor de revisar los datos."
                    objMensajeAdv.ShowDialog()
                End If
            Else
                objMensajeAdv.mensaje = "La consulta de la información para el archivo no arrojó ningún resultado, favor de revisar los datos."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If

    End Sub

    Private Function generaTXTDatosIncapacidad(ByVal dtSua As DataTable, ByVal fecha As String) As String
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = dtSua.Rows(0)("rutaDescarga").ToString & "inc_SUA_" & dtSua.Rows(0)("patr_nopatronal").ToString & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each item As DataRow In dtSua.Rows
            informacion &= item("patr_nopatronal").ToString
            informacion &= item("cono_nss").ToString
            informacion &= item("tipoIncidencia").ToString
            informacion &= item("fechaInicio").ToString
            informacion &= item("folio").ToString
            informacion &= item("diasSubsidiados").ToString
            informacion &= item("porcentaje").ToString
            informacion &= item("ramoClave").ToString
            informacion &= item("riesgoClave").ToString
            informacion &= item("secuelaClave").ToString
            informacion &= item("controliClave").ToString
            informacion &= item("fechaFin").ToString
            informacion &= vbCrLf
        Next

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        If existeArchivo(archivoTXT) Then
            Return archivoTXT
        Else
            Return ""
        End If
    End Function

    Private Function generarArchivoTXT(ByVal dtInformacion As DataTable, ByVal fecha As String) As String
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = dtInformacion.Rows(0)("rutaDescarga").ToString & "incapacidadesSUA_" & dtInformacion.Rows(0)("patr_nopatronal").ToString & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each item As DataRow In dtInformacion.Rows
            informacion &= item("patr_nopatronal").ToString
            informacion &= item("cono_nss").ToString
            informacion &= item("mov_clave").ToString
            informacion &= item("fechaMovimiento").ToString
            informacion &= item("folio").ToString
            informacion &= item("dias").ToString
            informacion &= item("sdi").ToString
            informacion &= vbCrLf
        Next

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        If existeArchivo(archivoTXT) Then
            Return archivoTXT
        Else
            Return ""
        End If
    End Function

    Public Sub aplicarIncapacidad()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim idsIncapacidades() As Integer
        Dim resultado As String = String.Empty
        Dim contAplicadas As Int32 = 0

        For Each row As UltraGridRow In grdIncapacidades.Rows
            If row.Cells("seleccion").Value Then
                ReDim Preserve idsIncapacidades(contSeleccionadas)
                idsIncapacidades(contSeleccionadas) = row.Cells("IdIncapacidad").Value
                'idsIncapacidades(contSeleccionadas) = "(" & row.Cells("IdIncapacidad").Value & "),"
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(1, idsIncapacidades) Then

                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de aplicar las " & contSeleccionadas & " incapacidades seleccionadas? Posteriormente no podrán realizarse cambios."

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For item As Integer = 0 To idsIncapacidades.Length - 1
                        Dim objBu As New Negocios.IncapacidadesContabilidadBU
                        resultado = objBu.cambiarEstatusIncapacidades(idsIncapacidades(item), 2)
                        'resultado = "EXITO"
                        If resultado = "EXITO" Then
                            contAplicadas += 1
                        End If
                    Next

                    If contSeleccionadas = contAplicadas Then
                        objMensajeExito.mensaje = "Incapacidades aplicadas correctamente."
                        objMensajeExito.ShowDialog()
                        mostrarListado()
                    ElseIf contAplicadas = 0 Then
                        objMensajeError.mensaje = "Error no se pudieron aplicar las incapacidades seleccionadas."
                        objMensajeError.ShowDialog()
                    ElseIf contSeleccionadas > contAplicadas Then
                        objMensajeError.mensaje = "Algunas incapacidades seleccionadas no se pudieron aplicar, el listado se actualizará favor de intentarlo nuevamente."
                        objMensajeError.ShowDialog()
                        mostrarListado()
                    End If

                End If
            Else
                objMensajeAdv.mensaje = "Las Incapacidades deben de estar en estatus EN PROCESO o APLICADO para Aplicarlos."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If

    End Sub

    Public Sub exportarReporte()
        Dim nombreDocumento As String = String.Empty
        Dim fecha As String = Date.Now.ToString("ddMMyyyy")
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim exito As New ExitoForm
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter

        nombreDocumento = "/Reporte_Incapacidades_"

        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(grdIncapacidades, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

                exito.mensaje = "Los datos se exportaron correctamente"
                exito.ShowDialog()
                .Dispose()
            End If

        End With
    End Sub

    Public Sub imprimirReporte()
        If grdIncapacidades.Rows.Count > 0 Then
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            EntidadReporte = objReporte.LeerReporteporClave("CON_REP_INCAPACIDADES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()

            Dim dtListado = New DataTable("dtIncapacidades")
            With dtListado
                .Columns.Add("nombre")
                .Columns.Add("folio")
                .Columns.Add("diasAut")
                .Columns.Add("fechaInicio")
                .Columns.Add("fechaFin")
                .Columns.Add("tipoInc")
                .Columns.Add("controlInc")
                .Columns.Add("motivo")
                .Columns.Add("nss")
            End With

            For Each item As UltraGridRow In grdIncapacidades.Rows
                dtListado.Rows.Add( _
                item.Cells("Apaterno").Value.ToString() & " " & item.Cells("Amaterno").Value.ToString() & " " & item.Cells("Nombre").Value.ToString(), _
                item.Cells("folio").Value.ToString(), _
                item.Cells("diasAut").Value.ToString(), _
                item.Cells("fechaInicio").Value.ToString(), _
                item.Cells("fechafin").Value.ToString(), _
                item.Cells("tipoIncapacidad").Value.ToString(), _
                item.Cells("controlInc").Value.ToString(), _
                item.Cells("motivo").Value.ToString(), _
                item.Cells("NSS").Value.ToString()
                )
            Next

            reporte("Empresa") = cmbPatron.Text
            reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

            If chkPorFechas.Checked Then
                reporte("Periodo") = "DEL: " & CDate(dttInicio.Text).ToString("dd/MM/yyyy") & " AL: " & CDate(dttFin.Text).ToString("dd/MM/yyyy")
            Else
                reporte("Periodo") = Date.Now.ToString("yyyy")
            End If

            reporte.RegData(dtListado)
            reporte.Show()

        End If
    End Sub
    Private Function validarEstatus(ByVal opcEstatus As Int16, ByVal idsIncapacidades() As Integer) As Boolean
        Dim objBU As New Negocios.IncapacidadesContabilidadBU
        Dim resultado As String = String.Empty

        For item As Integer = 0 To idsIncapacidades.Length - 1
            Dim dtValida As New DataTable
            dtValida = objBU.validarEstatus(idsIncapacidades(item), opcEstatus)
            resultado = dtValida.Rows(0).Item("mensaje")
            If resultado <> "CORRECTO" Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Private Sub grdIncapacidades_DoubleClick(sender As Object, e As EventArgs) Handles grdIncapacidades.DoubleClick
        consultarIncapacidad()
    End Sub

    Private Sub grdIncapacidades_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdIncapacidades.InitializeRow
        If e.Row.Cells.Exists("carta") Then
            If e.Row.Cells("existecarta").Value = True Then
                'e.Row.Cells("carta").ButtonAppearance.Image = Global.Contabilidad.Vista.My.Resources.descargar_inc
                e.Row.Cells("carta").Appearance.ImageBackground = Global.Contabilidad.Vista.My.Resources.descargar_inc
            Else
                e.Row.Cells("carta").Value = ""
            End If
        End If

        If e.Row.Cells.Exists("st7") Then
            If e.Row.Cells("existest7").Value = True Then
                e.Row.Cells("st7").Appearance.ImageBackground = Global.Contabilidad.Vista.My.Resources.descargar_inc
            Else
                e.Row.Cells("st7").Value = ""
            End If
        End If

        If e.Row.Cells.Exists("st2") Then
            If e.Row.Cells("existest2").Value = True Then
                e.Row.Cells("st2").Appearance.ImageBackground = Global.Contabilidad.Vista.My.Resources.descargar_inc
            Else
                e.Row.Cells("st2").Value = ""
            End If
        End If

        If e.Row.Cells("rojo").Value = 1 Then
            'e.Row.Cells(0).Appearance.ForeColor = Color.Red
            e.Row.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim Objalta As New AltaIncapacidadesForm
        Objalta.Show()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim ObjEditar As New EditarIncapacidadesForm
        Dim objBu As New Negocios.IncapacidadesContabilidadBU
        Dim dtEdita As New DataTable
        Dim resul As String = String.Empty

        If colaboradorIncId <> 0 Then
            dtEdita = objBu.validarEstatus(idIncGlobal, 2)
            resul = dtEdita.Rows(0).Item("mensaje")
            If resul = "CORRECTO" Then
                ObjEditar.colaboradorIncapacidadId = colaboradorIncId
                ObjEditar.fechaInicioInc = fechaInicioInc
                ObjEditar.fechaFinInc = fechaFinInc
                ObjEditar.Show()
            Else
                Dim advetencia As New AdvertenciaForm
                advetencia.mensaje = "No es posible editar una incapacidad que se encuentra aplicada"
                advetencia.ShowDialog()
            End If

        Else
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "Seleccione una incapacidad válida"
            advetencia.ShowDialog()
        End If
    End Sub

    Private Sub btnGenerarttx_Click(sender As Object, e As EventArgs) Handles btnGenerarttx.Click
        generartxt()
    End Sub

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
        aplicarIncapacidad()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarReporte()
    End Sub

    Private Sub chkPorFechas_Click(sender As Object, e As EventArgs) Handles chkPorFechas.Click
        If chkPorFechas.Checked Then
            dttInicio.Enabled = True
            dttFin.Enabled = True
        Else
            dttInicio.Enabled = False
            dttFin.Enabled = False

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimirReporte()
    End Sub

    Public Sub llenarComboRamoDelSeguro()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim RamoSeguro As New DataTable
        RamoSeguro = objBU.RamoDelSeguro()
        Dim dtRow As DataRow = RamoSeguro.NewRow
        dtRow("ramo_ramoseguroid") = 0
        dtRow("ramo_descripcion") = ""
        RamoSeguro.Rows.InsertAt(dtRow, 0)
        With cmbTipoIncapacidad
            .DisplayMember = "ramo_descripcion"
            .ValueMember = "ramo_ramoseguroid"
            .DataSource = RamoSeguro
        End With
    End Sub
End Class