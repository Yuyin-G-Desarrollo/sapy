Imports System.IO
Imports System.Net
Imports System.Text
Imports Programacion.Negocios
Imports Tools.modMensajes

Public Class EtiquetasPruebasEspecialesForm
    Dim accion As Integer
    Dim idCliente As Integer
    Dim Cliente As String
    Dim dtClietnes As New DataTable
    Dim dtEtiquetas As New DataTable
    Dim dtImpresoras As New DataTable
    Dim idEtiqueta As Integer
    Dim value As Object
    Dim lote As Integer
    Dim idNaveSay As Integer
    Dim anio As Integer

    ' Datos Etiqueta
    Dim etiqAncho As String
    Dim etiqAlto As String
    Dim ZPL203 As String
    Dim ZPL300 As String
    Dim tipoEtiqueta As Integer
    Dim nombreEtiqueta As String
    Dim datosParametros As New DataTable
    Dim usuario As String

    Dim listaParamEtiquetas As New List(Of String)

    Dim dt203Imprimir As New DataTable
    Dim dt300Imprimir As New DataTable
    Dim ZPL203Imprimir As String
    Dim ZPL300Imprimir As String
    Dim dtGRF As New DataTable
    Dim FotoBat203 As String
    Dim FotoBat300 As String
    Dim FotoLogoBat203 As String
    Dim FotoLogoBat300 As String

    Private Sub EtiquetasPruebasEspecialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim obj = New EtiquetasPruebasEspecialesBU
        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        Try
            accion = 1
            CargarClientes(accion)
            'cargarImpresoras()
            cargarImpresoras(cmbImpresoras)
            cboNave = Tools.Controles.ComboNavesSegunUsuario(cboNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Error " + ex.Message)
        End Try

    End Sub

    Private Sub CargarClientes(ByVal accion As Integer)
        Dim obj = New EtiquetasPruebasEspecialesBU
        dtClietnes = obj.consultaClientesEtiquetasDiseño(accion)
        dtClietnes.Rows.InsertAt(dtClietnes.NewRow, 0)
        cboCliente.DataSource = dtClietnes
        cboCliente.ValueMember = "IdCliente"
        cboCliente.DisplayMember = "NombreCliente"

    End Sub

    Private Sub etiquetasCliente(ByVal accion As Integer, ByVal idcliente As Integer)

        Dim obj = New EtiquetasPruebasEspecialesBU
        dtEtiquetas = obj.consultaEtiquetasClientesDiseño(accion, idcliente)
        cboEtiqueta.DataSource = dtEtiquetas
        cboEtiqueta.ValueMember = "idEtiqueta"
        cboEtiqueta.DisplayMember = "nombreEtiqueta"
        cargarListaParametros(idEtiqueta)
        accion = 1
    End Sub

    Private Sub cargarListaParametros(ByVal idetiqueta As Integer)
        Dim obj = New EtiquetasPruebasEspecialesBU
        Dim dtListaParametros As New DataTable
        datosParametros = New DataTable
        grdParametros.DataSource = Nothing
        grdVParametros.Columns.Clear()
        idetiqueta = cboEtiqueta.SelectedValue
        dtListaParametros = obj.consultaParametrosPorEtiquetaDiseño(idetiqueta)
        grdParametros.DataSource = dtListaParametros
        disenioGrid(grdVParametros)
    End Sub

    Private Sub disenioGrid(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView)

        With grid
            .Columns.ColumnByFieldName("rep_etiquetaid").Visible = False
            .Columns.ColumnByFieldName("DataImprimir").Visible = False

            .Columns.ColumnByFieldName("NumParametro").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Parametro").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Valor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Ejemplo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Entrada").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            .Columns.ColumnByFieldName("NumParametro").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Parametro").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Valor").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Ejemplo").OptionsColumn.AllowEdit = False

            .Columns.ColumnByFieldName("NumParametro").Width = 50
            .Columns.ColumnByFieldName("Parametro").Width = 285
            .Columns.ColumnByFieldName("Valor").Width = 80
            .Columns.ColumnByFieldName("Ejemplo").Width = 80
            .Columns.ColumnByFieldName("Entrada").Width = 150

            .Columns.ColumnByFieldName("NumParametro").Caption = "#Param"

        End With

        grdVParametros.OptionsView.EnableAppearanceEvenRow = True
        grdVParametros.OptionsView.EnableAppearanceOddRow = True
        grdVParametros.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVParametros.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVParametros.Appearance.SelectedRow.Options.UseBackColor = True

        grdVParametros.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVParametros.Appearance.EvenRow.BackColor = Color.White
        grdVParametros.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVParametros.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVParametros.Appearance.FocusedRow.ForeColor = Color.White

    End Sub

    'Private Sub cargarImpresoras()
    '    Dim obj = New EtiquetasPruebasEspecialesBU
    '    dtImpresoras = obj.ListaImpresoras()
    '    cmbImpresoras.DataSource = dtImpresoras
    '    cmbImpresoras.DisplayMember = "Nombre"
    '    cmbImpresoras.ValueMember = "IdImpresora"
    'End Sub

    Private Sub CargarImpresoras(ByVal cmb As ComboBox)
        Dim objBu As New EtiquetasPruebasEspecialesBU
        Dim DTImpresoras As DataTable
        DTImpresoras = objBU.ListaImpresoras()
        cmb.DataSource = DTImpresoras
        cmb.DisplayMember = "Nombre"
        cmb.ValueMember = "IdImpresora"
        Dim dt As DataTable
        dt = objBU.ConsultaImpresoraAsignada(My.Computer.Name)
        If Not IsNothing(dt) Then
            If dt.Rows.Count > 0 Then
                cmb.SelectedValue = dt.Rows(0).Item("IdImpresora")
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cboCliente.Text <> String.Empty Then
            idCliente = cboCliente.SelectedValue
            accion = 2
            cboEtiqueta.Enabled = True
            etiquetasCliente(accion, idCliente)
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione un cliente del combo")
        End If
    End Sub

    Private Sub cboEtiqueta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEtiqueta.SelectedIndexChanged
        value = cboEtiqueta.SelectedValue
        If (TypeOf value Is Integer) Then
            idEtiqueta = cboEtiqueta.SelectedValue
            cargarListaParametros(idEtiqueta)
        End If
    End Sub

    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged
        cboEtiqueta.Text = Nothing
        cboEtiqueta.Enabled = False
        grdParametros.DataSource = Nothing
        grdVParametros.Columns.Clear()
        txtAlto.Text = ""
        txtAncho.Text = ""
        pbxVistaPrevia.Image = My.Resources.imagen1
        gbxVistaPrevia.Enabled = False
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim obj = New EtiquetasPruebasEspecialesBU
        Try
            Cursor = Cursors.WaitCursor
            If cboNave.SelectedValue < 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione una nave del combo")
                Cursor = Cursors.Default
                Return
            Else
                idNaveSay = cboNave.SelectedValue
            End If
            If txtLote.Text = "" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Es necesario agregar en numero de lote")
                Cursor = Cursors.Default
                Return
            Else
                lote = CInt(txtLote.Text)
            End If
            anio = NUDAnio.Value
            grdParametros.DataSource = Nothing
            grdVParametros.Columns.Clear()
            datosParametros = New DataTable
            datosParametros = obj.consultaDatosParametrosEtiquetasPrueba(anio, idNaveSay, lote, usuario, idEtiqueta)
            If datosParametros.Rows.Count > 0 Then
                grdParametros.DataSource = datosParametros
                disenioGrid(grdVParametros)
                dtGRF = obj.ConsultaGRFPruebaEtiquetasEspecial(anio, idNaveSay, lote)
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No existe información para mostrar")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        Dim obj = New EtiquetasPruebasEspecialesBU
        Dim textobuscar As String
        Dim textoreemplazar As String
        Dim TextoImprimir As String
        Dim dt203Mostrar As New DataTable
        Dim dt300Mostrar As New DataTable

        Try
            idCliente = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("idCliente")).FirstOrDefault()
            Cliente = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("cliente")).FirstOrDefault()
            nombreEtiqueta = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("nombreEtiqueta")).FirstOrDefault()
            etiqAncho = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("etiqAncho")).FirstOrDefault()
            etiqAlto = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("etiqAlto")).FirstOrDefault()
            ZPL203 = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("zpl200")).FirstOrDefault()
            ZPL300 = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("zpl300")).FirstOrDefault()
            tipoEtiqueta = dtEtiquetas.AsEnumerable().Where(Function(y) y.Item("idEtiqueta").ToString = idEtiqueta).Select(Function(x) x.Item("idTipoEtiqueta")).FirstOrDefault()

            If ZPL203 = Nothing Or ZPL300 = Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Es necesario cargar arhcivo PRN (203 dpi o 300 pdi) en la pantalla 'Configuración de etiquetas especiales'")
            Else
                dt203Mostrar = obj.ReemplazaParametroGuion(ZPL203)
                dt300Mostrar = obj.ReemplazaParametroGuion(ZPL300)

                ZPL203 = dt203Mostrar.Rows(0).Item("ZPL")
                ZPL300 = dt300Mostrar.Rows(0).Item("ZPL")
                ZPL203Imprimir = dt203Mostrar.Rows(0).Item("ZPL")
                ZPL300Imprimir = dt300Mostrar.Rows(0).Item("ZPL")

                For item As Integer = 0 To grdVParametros.RowCount - 1
                    textobuscar = grdVParametros.GetRowCellValue(item, "Valor")
                    textoreemplazar = grdVParametros.GetRowCellValue(item, "Entrada")
                    ZPL203 = Replace(ZPL203, textobuscar, textoreemplazar)
                    ZPL300 = Replace(ZPL300, textobuscar, textoreemplazar)

                    TextoImprimir = textoreemplazar
                    If TextoImprimir Is Nothing Then
                        TextoImprimir = ""
                    End If

                    TextoImprimir = reemplazacaracteres(textobuscar, TextoImprimir)
                    grdVParametros.SetRowCellValue(item, "DataImprimir", TextoImprimir)
                Next

                For item As Integer = 0 To grdVParametros.RowCount - 1
                    textobuscar = grdVParametros.GetRowCellValue(item, "Valor")
                    If IsDBNull(grdVParametros.GetRowCellValue(item, "DataImprimir")) = False Then

                        If grdVParametros.GetRowCellValue(item, "DataImprimir").ToString <> "" Or
                       grdVParametros.GetRowCellValue(item, "DataImprimir").ToString <> Nothing Then
                            textoreemplazar = If(IsDBNull(grdVParametros.GetRowCellValue(item, "DataImprimir")), "", grdVParametros.GetRowCellValue(item, "DataImprimir"))
                            ZPL203Imprimir = Replace(ZPL203Imprimir, textobuscar, textoreemplazar)
                            If ZPL300Imprimir.Length > 0 Then
                                If textobuscar = "|param12|" Then
                                    ZPL300Imprimir = Replace(ZPL300Imprimir, textobuscar, "^XGR:" & (dtGRF.Rows(0).Item("NombreArchivo300")) & ",1,1")
                                ElseIf textobuscar = "|param67|" Then
                                    ZPL300Imprimir = Replace(ZPL300Imprimir, textobuscar, "^XGR:" & (dtGRF.Rows(0).Item("NombreArchivoLogo300")) & ",1,1")
                                Else
                                    ZPL300Imprimir = Replace(ZPL300Imprimir, textobuscar, textoreemplazar)
                                End If
                            End If

                        End If
                    End If
                Next


                listaParamEtiquetas.Add(ZPL203)
                listaParamEtiquetas.Add(ZPL300)
                listaParamEtiquetas.Add(ZPL203Imprimir)
                listaParamEtiquetas.Add(ZPL300Imprimir)

                txtAncho.Text = etiqAncho & " cm."
                txtAlto.Text = etiqAlto & " cm."

                ConsultarAPIObtenerImagenZPL(ZPL203, ZPL300)
                gbxVistaPrevia.Enabled = True
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try


    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLote.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            Tools.MostrarMensaje(Mensajes.Warning, "Solo se admite ingresar números enteros.")
        End If
    End Sub

    Private Function ConsultarAPIObtenerImagenZPL(ByVal ZPL203 As String, ByVal ZPL300 As String) As String
        Dim Imagen As String = String.Empty
        Dim ZPL200() As Byte = Encoding.UTF8.GetBytes(ZPL203)
        Dim RutaURL As String = String.Empty
        Dim AnchoPulgadas As Double = 0
        Dim AltoPulgadas As Double = 0
        Dim Resolucion As String

        If rdo203.Checked Then
            Resolucion = "203"
        ElseIf rdo300.Checked Then
            Resolucion = "300"
        End If

        AnchoPulgadas = Math.Round(CDbl(etiqAncho) * 0.3937, 2)
        AltoPulgadas = Math.Round(CDbl(etiqAlto) * 0.3937, 2)


        If Resolucion = "203" Then
            RutaURL = "http://api.labelary.com/v1/printers/8dpmm/labels/" & AnchoPulgadas.ToString() & "x" & AltoPulgadas.ToString & "/0/"
        Else
            RutaURL = "http://api.labelary.com/v1/printers/12dpmm/labels/" & AnchoPulgadas & "x" & AltoPulgadas.ToString() & "/0/"
        End If

        Dim request As HttpWebRequest = WebRequest.Create(RutaURL)

        request.Method = "POST"

        request.ContentType = "application/x-www-form-urlencoded"

        Dim requestStream As Stream = request.GetRequestStream()
        requestStream.Write(ZPL200, 0, ZPL200.Length)
        requestStream.Close()

        Dim g As Guid
        g = Guid.NewGuid()
        Dim id As String = g.ToString

        Try
            Dim response As HttpWebResponse = request.GetResponse()
            Dim responseStream As Stream = response.GetResponseStream()
            If Directory.Exists("c:\ZPL\") = False Then
                Directory.CreateDirectory("c:\ZPL\")
            End If
            Dim fileStream As Stream = File.Create("c:\ZPL\label_" + id + ".png") ' change file name for PNG images
            responseStream.CopyTo(fileStream)
            responseStream.Close()
            fileStream.Close()
            Imagen = "c:\ZPL\label_" + id + ".png"
            pbxVistaPrevia.Image = Image.FromFile(Imagen)


        Catch ex As WebException
            Imagen = "Error: " + ex.Message
        End Try

        Return Imagen

    End Function

    Private Function reemplazacaracteres(ByVal textobuscar As String, ByVal textoImprimir As String) As String
        Dim datoimprimir As String = String.Empty
        If textobuscar = "|param12|" Or textobuscar = "|param67|" Then
            datoimprimir = "^XGR:" & textoImprimir & ",1,1"
        Else
            datoimprimir = Replace(Replace(Replace(Replace(Replace(Replace(Replace(textoImprimir, "Á", "_c3_81"), "Í", "_c3_8d"), "É", "C3_89"), "Ó", "_c3_93"), "Ú", "_c3_9a"), "Ñ", "_c3_91"), "½", "\AB")
        End If
        Return datoimprimir
    End Function

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim CodigoZPLImpresion As String = String.Empty
        Dim Resolucion As String = String.Empty
        Try
            If rdo203.Checked Then
                CodigoZPLImpresion = ZPL203Imprimir 'ZPL203
            ElseIf rdo300.Checked Then
                CodigoZPLImpresion = ZPL300Imprimir 'ZPL300
            End If

            CodigoZPLImpresion = Replace(Replace(Replace(Replace(Replace(Replace(Replace(CodigoZPLImpresion, "Á", "_c3_81"), "Í", "_c3_8d"), "É", "C3_89"), "Ó", "_c3_93"), "Ú", "_c3_9a"), "Ñ", "_c3_91"), "½", "\AB")

            FotoBat203 = dtGRF.Rows(0).Item("ArchivoZebra200").ToString
            FotoBat300 = dtGRF.Rows(0).Item("ArchivoZebra300").ToString
            FotoLogoBat203 = dtGRF.Rows(0).Item("ArchivoZebraLogo200").ToString
            FotoLogoBat300 = dtGRF.Rows(0).Item("ArchivoZebraLogo300").ToString

            If CodigoZPLImpresion <> "" Then
                If Directory.Exists("c:\ZPL\TXT\") = False Then
                    Directory.CreateDirectory("c:\ZPL\TXT\")
                End If
                Dim g As Guid
                g = Guid.NewGuid()
                Dim id As String = g.ToString
                Dim ArchivoTxt As String = "c:\ZPL\TXT\Etiquetas_" + id + ".txt"
                Dim fileStream As Stream = File.Create(ArchivoTxt)
                Dim info() As Byte = New UTF8Encoding(True).GetBytes(CodigoZPLImpresion)

                For impresiones As Integer = 1 To NUD_Impresion.Value
                    fileStream.Write(info, 0, info.Length)
                Next

                fileStream.Close()
                Dim ArchivoBat As String = "c:\ZPL\TXT\Etiquetas_" + id + ".bat"
                fileStream = File.Create(ArchivoBat)
                Dim sw As New System.IO.StreamWriter(fileStream)

                If rdo203.Checked Then
                    sw.WriteLine(FotoBat203)
                    sw.WriteLine(FotoLogoBat203)
                ElseIf rdo300.Checked Then
                    sw.WriteLine(FotoBat300)
                    sw.WriteLine(FotoLogoBat300)
                End If

                sw.WriteLine("COPY " + ArchivoTxt + " C:\PRN")
                sw.Close()
                Shell(ArchivoBat)
                Tools.MostrarMensaje(Mensajes.Success, "Se ha impreso correctamente.")
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No se encontró información ZPL para imprimir.")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        CargarClientes(1)
        cboEtiqueta.Text = ""
        cboEtiqueta.SelectedValue = 0
        grdVParametros.Columns.Clear()
        listaParamEtiquetas.Clear()
        txtAlto.Text = ""
        txtAncho.Text = ""
        pbxVistaPrevia.Image = My.Resources.imagen1
        cboNave.Text = ""
        cboNave.SelectedValue = 0
        txtLote.Text = ""
    End Sub
End Class