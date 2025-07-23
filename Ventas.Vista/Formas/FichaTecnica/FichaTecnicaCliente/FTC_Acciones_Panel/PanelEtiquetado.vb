Imports System.Net
Imports System.IO
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools.Controles

Partial Public Class FichaTecnicaClienteForm

    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena

    Dim Etiquetas_Especiales As Boolean = True '' Valor true para cuando el clliente ya tiene de alta etiquetas especiales.
    Dim ArchivoPDF_CargadoEnFTP As Boolean ''valor true para indicar que se ha cargado un archivo pdf al ftp
    Dim UltimoArchivo As String
    Dim dtEtiqeutas_Especiales_Nombres


    Private Sub btnGuardarPanelEtiquetado_Click(sender As Object, e As EventArgs) Handles btnGuardarEtiquetado.Click
        'If Etiquetas_Especiales = False Then
        '    show_message("Advertencia", "Carga el archivo PDF de la Ficha Técnica de Etiquetado para poder guardar.")
        '    Return
        'End If
        Try
            Guardar_Corridas_ExtranjerasCliente()
            editar_Etiquetado_PoliticaVenta()

        Catch ex As Exception
            show_message("Error", "Algo falló en la operación")
            Exit Sub
        End Try

        show_message("Exito", "Datos guardados con éxito")

        ModoEdicion_Etiquetado = False
        editando_politica = False
        poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)
        poblar_gridCorridasExtranjeras(CInt(lblClienteSAYID_Int.Text))
        CambiarElForeColorControles_Negro(pnlFormEtiquetado)
        CambiarElForeColorControles_DodgerBlue(pnlBotonesEtiquetado)
        CambiarElForeColorControles_DodgerBlue(pblFTC_Etiquetado)

        recuperar_datos_Panel_Etiquetado(CInt(lblClienteSAYID_Int.Text))
        ''btnEtiquetasVisualizar.Enabled = True
        chkCodigosAmece.Enabled = False

        Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
        Activar_Inactivar_grids(gridPolitica, ModoEdicion_Etiquetado)
        Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)
        Activar_Inactivar_grids(grdCorridasExtranjeras, ModoEdicion)

    End Sub

    Private Sub btnEditarEtiquetado_Click(sender As Object, e As EventArgs) Handles btnEditarEtiquetado.Click
        ModoEdicion_Etiquetado = True

        asignaStatusControles(pnlFormEtiquetado, True)

        cboxEtiquetadoProtectorFleje.Enabled = False
        cboxEtiquetadoProtectorFleje.DropDownStyle = ComboBoxStyle.Simple
        cboxEtiquetadoTipoFleje.Enabled = False
        cboxEtiquetadoTipoFleje.DropDownStyle = ComboBoxStyle.Simple

        btnEtiquetasCargarPDF.Enabled = True

        Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
        Activar_Inactivar_grids(gridPolitica, ModoEdicion_Etiquetado)
        Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)
        Activar_Inactivar_grids(grdCorridasExtranjeras, ModoEdicion_Etiquetado)

        Dim j As Integer = ContarEtiquetasEspeciales()
        If j > 0 Then
            btnEtiquetasVisualizar.Enabled = True
        Else
            btnEtiquetasVisualizar.Enabled = False
        End If

        If chboxEtiquetadoValidarCodigoEtiquetas.Checked Then
            chkCodigosAmece.Enabled = True
        Else
            chkCodigosAmece.Enabled = False
        End If

        If chboxEtiquetadoValidarCodigoEtiquetas.Checked = False Then
            btnCodigosCliente.Enabled = False
            lblCodigos.Enabled = False
            lblCodigos_Cliente.Enabled = False
        End If

    End Sub

    Private Sub btnCancelarEtiquetado_Click(sender As Object, e As EventArgs) Handles btnCancelarEtiquetado.Click
        If Mensajes_Y_Alertas("CONFIRMACION", "Los cambios realizados no se han guardado ¿Desea cancelar los cambios?") Then
            'If Etiquetas_Especiales = False Then
            '    show_message("Advertencia", "Carga el archivo PDF al servidor FTP antes de continuar usando la aplicacion ")
            'Else
            ModoEdicion_Etiquetado = False
            recuperar_datos_Panel_Etiquetado(CInt(lblClienteSAYID_Int.Text))
            CambiarElForeColorControles_Negro(pnlFormEtiquetado)
            CambiarElForeColorControles_DodgerBlue(pnlBotonesEtiquetado)
            CambiarElForeColorControles_DodgerBlue(pblFTC_Etiquetado)

            editando_politica = False
            chkCodigosAmece.Enabled = False
            poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)
            Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
            Activar_Inactivar_grids(gridPolitica, ModoEdicion_Etiquetado)
            Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)

            editando_politica = False
            chkCodigosAmece.Enabled = False
            poblar_gridPolitica(editando_politica, CInt(lblClienteSAYID_Int.Text), gridPolitica)
            poblar_gridCorridasExtranjeras(CInt(lblClienteSAYID_Int.Text))
            Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
            Activar_Inactivar_grids(gridPolitica, ModoEdicion_Etiquetado)
            Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)
            Activar_Inactivar_grids(grdCorridasExtranjeras, ModoEdicion_Etiquetado)

            'End If
        End If

    End Sub

    Public Sub editar_Etiquetado_PoliticaVenta()

        Dim PoliticasVentasBU As New Negocios.VentasPoliticasBU
        Dim PoliticasVentas As New Entidades.PoliticaVenta
        Dim cliente As New Entidades.Cliente

        PoliticasVentas.validarcodigoetiqueta = chboxEtiquetadoValidarCodigoEtiquetas.CheckState
        PoliticasVentas.CodigoAMECE = chkCodigosAmece.CheckState

        cliente.clienteid = cboxClienteCliente.SelectedValue
        PoliticasVentas.cliente = cliente
        Try
            PoliticasVentasBU.editarVentasPoliticas(PoliticasVentas, 2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Guardar_Corridas_ExtranjerasCliente()
        Dim ventas As New Negocios.VentasPoliticasBU
        Dim cliente As Integer = cboxClienteCliente.SelectedValue
        Dim pais As Integer
        Dim seleccionado As Integer

        Try

            For Each row As UltraGridRow In grdCorridasExtranjeras.Rows
                Dim TallasExtranjeras As New Entidades.TallasExtranjerasCliente

                pais = CInt(row.Cells("PaisID").Value)

                TallasExtranjeras.Pais = pais
                TallasExtranjeras.Cliente = cliente
                TallasExtranjeras.UsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                TallasExtranjeras.UsuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                If CBool(row.Cells("Activo").Value) = True Then
                    seleccionado = 1
                Else
                    seleccionado = 0
                End If

                ventas.GuardarCorridaExtranjeraCliente(TallasExtranjeras, seleccionado)

            Next

        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try

    End Sub

    Public Sub recuperar_datos_Panel_Etiquetado(clienteID As Integer)

        limpiarControles(pnlFormEtiquetado)
        asignaStatusControles(pnlFormEtiquetado, False)

        'If Not Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
        '    If Not Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
        '        btnEditarEtiquetado.Enabled = False
        '    Else
        '        btnEditarEtiquetado.Enabled = True
        '    End If
        'End If

        If rbtnClienteStatusInactivo.Checked Then
            btnEditarEtiquetado.Enabled = False
        Else
            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
                btnEditarEtiquetado.Enabled = True
            Else
                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
                    btnEditarEtiquetado.Enabled = True
                Else
                    btnEditarEtiquetado.Enabled = False
                End If
            End If
        End If


        ''POLITICA EMBARQUE

        Dim politicaEmbarqueBU As New Negocios.PoliticaEmbarqueBU
        Dim politicaEmbarque As New DataTable
        politicaEmbarque = politicaEmbarqueBU.Datos_TablaPoliticaEmbarque(clienteID)

        If politicaEmbarque.Rows.Count > 0 Then

            ListaTipoFleje(cboxEtiquetadoTipoFleje)
            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_tipoflejeid")) Then
                cboxEtiquetadoTipoFleje.Text = String.Empty
            Else
                cboxEtiquetadoTipoFleje.SelectedValue = CInt(politicaEmbarque.Rows(0).Item("poem_tipoflejeid"))
            End If

            ListaProtectorFleje(cboxEtiquetadoProtectorFleje)
            If IsDBNull(politicaEmbarque.Rows(0).Item("poem_protectorflejeid")) Then
                cboxEtiquetadoProtectorFleje.Text = String.Empty
            Else
                cboxEtiquetadoProtectorFleje.SelectedValue = CInt(politicaEmbarque.Rows(0).Item("poem_protectorflejeid"))
            End If



        End If


        ''POLITICA VENTAS

        Dim ventas As New Negocios.VentasPoliticasBU
        Dim politicaVentas As New DataTable
        politicaVentas = ventas.Datos_TablaPoliticaVenta(clienteID)

        If politicaVentas.Rows.Count > 0 Then

            If IsDBNull(politicaVentas.Rows(0).Item("pove_validarcodigoetiqueta")) Then
                chboxEtiquetadoValidarCodigoEtiquetas.Checked = False
            Else
                If CBool(politicaVentas.Rows(0).Item("pove_validarcodigoetiqueta")) Then
                    chboxEtiquetadoValidarCodigoEtiquetas.Checked = True
                Else
                    chboxEtiquetadoValidarCodigoEtiquetas.Checked = False
                End If
            End If

            If CBool(politicaVentas.Rows(0).Item("pove_codigosAmece")) Then
                chkCodigosAmece.Checked = True
            Else
                chkCodigosAmece.Checked = False
            End If

        End If

        btnEtiquetasVisualizar.Enabled = True
        ValidarFTC_EtiquetadoPendiente()


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "BOTON_CODIGO_CLIENTE") Then
            If chboxEtiquetadoValidarCodigoEtiquetas.Checked = True Then
                btnCodigosCliente.Visible = True
                lblCodigos.Visible = True
                lblCodigos_Cliente.Visible = True
            End If
        Else
            btnCodigosCliente.Visible = False
            lblCodigos.Visible = False
            lblCodigos_Cliente.Visible = False
        End If

    End Sub

    Private Sub CargarArchivoPDF(ByVal IdClienteSay As Integer)
        Dim request = DirectCast(WebRequest.Create(rutaFtp), FtpWebRequest)
        Dim Carpeta As String = "Ventas/FTC/Cliente_" + IdClienteSay.ToString + "/Etiquetado"
        Dim objFTP As New Tools.TransferenciaFTP

        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = "Archivos PDF (*.pdf)|*.pdf|Todo (*.*)|*.*"

        Try
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim viejoNombre As String
                Dim nuevoNombre As String
                Dim OrigenArchivo_Split() As String
                Dim Fecha_Archivo As New DateTime
                Dim archivo As String

                Fecha_Archivo = DateTime.Now

                OrigenArchivo_Split = Split(OpenFileDialog1.FileName, "\")

                If File.Exists("c:\Export_PDF") = False Then
                    Directory.CreateDirectory("c:\Export_PDF")
                End If

                viejoNombre = OpenFileDialog1.FileName
                nuevoNombre = "c:\Export_PDF\"

                archivo = "FTE_" + IdClienteSay.ToString + "_" + Fecha_Archivo.Year.ToString

                If Fecha_Archivo.Month < 10 Then
                    archivo += "0" + Fecha_Archivo.Month.ToString
                Else
                    archivo += Fecha_Archivo.Month.ToString
                End If

                If Fecha_Archivo.Day < 10 Then
                    archivo += "0" + Fecha_Archivo.Day.ToString
                Else
                    archivo += Fecha_Archivo.Day.ToString
                End If

                If Fecha_Archivo.Hour < 10 Then
                    archivo += "_0" + Fecha_Archivo.Hour.ToString
                Else
                    archivo += "_" + Fecha_Archivo.Hour.ToString
                End If

                If Fecha_Archivo.Minute < 10 Then
                    archivo += "0" + Fecha_Archivo.Minute.ToString
                Else
                    archivo += Fecha_Archivo.Minute.ToString
                End If

                If Fecha_Archivo.Second < 10 Then
                    archivo += "0" + Fecha_Archivo.Second.ToString + ".pdf"
                Else
                    archivo += Fecha_Archivo.Second.ToString + ".pdf"
                End If

                FileCopy(viejoNombre, nuevoNombre + archivo)
                objFTP.EnviarArchivo(Carpeta, nuevoNombre + archivo)
                UltimoArchivo = nuevoNombre
                ArchivoPDF_CargadoEnFTP = True
                My.Computer.FileSystem.DeleteFile(nuevoNombre + archivo, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)


                'ACTUALIZAMOS LA INFORMACION DE INFOCLIENTE
                Dim objBU As New Negocios.VentasPoliticasBU
                objBU.ActualizarRutaArchivoPDF_FTC_Etiquetado("Ventas/FTC/Cliente_" + IdClienteSay.ToString + "/Etiquetado/" + archivo, IdClienteSay, True)

                Dim objExito As New Tools.ExitoForm
                objExito.StartPosition = FormStartPosition.CenterScreen
                objExito.mensaje = "Archivo subido correctamente"
                objExito.ShowDialog()
                Etiquetas_Especiales = True

            End If



        Catch ex As Exception
            Dim objError As New Tools.ErroresForm
            objError.StartPosition = FormStartPosition.CenterScreen
            objError.mensaje = "Ocurrio un error inesperado: " + ex.Message
            objError.ShowDialog()

            If gridEtiquetadoEtiquetado.Rows.Count = 1 And ArchivoPDF_CargadoEnFTP = False Then
                ArchivoPDF_CargadoEnFTP = False
            End If


        End Try

    End Sub

    Private Sub btnVisualizar_Click(sender As Object, e As EventArgs) Handles btnEtiquetasVisualizar.Click
        If Etiquetas_Especiales = False Then
            show_message("Advertencia", "Aun no hay archivo PDF en el servidor")
        Else
            ConsultarPDF()
        End If
    End Sub

    Private Sub btnCargarPDF_Click(sender As Object, e As EventArgs) Handles btnEtiquetasCargarPDF.Click
        CargarArchivoPDF(CInt(lblClienteSAYID_Int.Text))
    End Sub

    Private Sub ValidarFTC_EtiquetadoPendiente()
        Dim objBU As New Negocios.VentasPoliticasBU
        Dim dtRutaEtiqueta As New DataTable

        Dim j As Integer = ContarEtiquetasEspeciales()
        dtRutaEtiqueta = objBU.ConsultarRutaFTCEtiqueta(CInt(lblClienteSAYID_Int.Text))

        If IsDBNull(dtRutaEtiqueta.Rows(0).Item(0)) Then
            If j > 0 Then
                Etiquetas_Especiales = False
            End If
        Else
            If j > 0 And dtRutaEtiqueta.Rows(0).Item(0) = "" Then
                Etiquetas_Especiales = False
            End If
        End If

        If IsDBNull(dtRutaEtiqueta.Rows(0).Item(0)) Then
            btnEtiquetasVisualizar.Enabled = False
        ElseIf dtRutaEtiqueta.Rows(0).Item(0) = "" Then
            btnEtiquetasVisualizar.Enabled = False
        End If


    End Sub

    Private Sub ValidarEtiqeutaEspecialAgregada()

        Dim i As Integer = 0
        Dim lsArchivos As New List(Of String)
        Dim objFTP As New Tools.TransferenciaFTP
        Dim objBU As New Negocios.VentasPoliticasBU
        Dim dtEtiquetaEspecial As New DataTable
        If Not IsNothing(gridEtiquetadoEtiquetado.DataSource) Then
            Dim j As Integer = ContarEtiquetasEspeciales()
            If j > 0 Then

                For Each row As DataRow In dtEtiqeutas_Especiales_Nombres.rows
                    If gridEtiquetadoEtiquetado.Rows((gridEtiquetadoEtiquetado.Rows.Count) - 1).Cells("tiet_nombre").Text = row.Item(0) Then
                        objBU.EliminarRutaEtiquetaespecial(CInt(lblClienteSAYID_Int.Text))

                        Etiquetas_Especiales = False
                        btnEditarEtiquetado.PerformClick()

                    End If
                Next
            Else
                Etiquetas_Especiales = True
                btnEtiquetasCargarPDF.Enabled = False
            End If



        Else
            Dim VentasBU As New Negocios.VentasPoliticasBU
            Dim dtTablaEtiquetas
            dtTablaEtiquetas = VentasBU.Datos_TablaEtiquetasCliente(CInt(lblClienteSAYID_Int.Text), AreaOperativa)
            If dtTablaEtiquetas.rows.count > 0 Then
                For Each row As DataRow In dtEtiqeutas_Especiales_Nombres.rows
                    If dtTablaEtiquetas.Rows((dtTablaEtiquetas.Rows.Count) - 1).item("tiet_nombre") = row.Item(0) And dtTablaEtiquetas.Rows((dtTablaEtiquetas.Rows.Count) - 1).Item("Activo") = "True" Then

                        dtEtiquetaEspecial = objBU.ConsultarRutaFTCEtiqueta(CInt(lblClienteSAYID_Int.Text))

                        If dtEtiquetaEspecial.Rows.Count = 0 Then
                            Etiquetas_Especiales = False
                        ElseIf IsDBNull(dtEtiquetaEspecial.Rows(0).Item(0)) Then
                            Etiquetas_Especiales = False
                        ElseIf dtEtiquetaEspecial.Rows(0).Item(0) = "" Then
                            Etiquetas_Especiales = False
                        End If
                        btnEditarEtiquetado.PerformClick()
                        ''btnEtiquetasCargarPDF.Enabled = True
                    End If
                Next
            Else
                Etiquetas_Especiales = True
            End If
        End If


    End Sub

    Private Function ContarEtiquetasEspeciales()
        Dim j As Integer = 0

        For Each fila As UltraGridRow In gridEtiquetadoEtiquetado.Rows
            For Each row As DataRow In dtEtiqeutas_Especiales_Nombres.rows
                If fila.Cells("tiet_nombre").Text = row.Item(0) And CBool(fila.Cells(6).Value) = True Then
                    j += 1
                End If
            Next
        Next

        Return j
    End Function

    Private Sub ConsultarPDF()
        Dim objFTP As New Tools.TransferenciaFTP
        Dim lsArchivos As New List(Of String)
        Dim Archivo_Split() As String
        Dim i As Integer = 0
        Dim CadenaActual As Integer
        Dim cadenaMayor As Integer
        Dim NombreArchivoPDF As String = String.Empty
        Dim j As Integer = ContarEtiquetasEspeciales()

        If j > 0 And Etiquetas_Especiales = True Then
            ''CONSULTAMOS EL PDF 
            lsArchivos = objFTP.ListarArchivos("Ventas/FTC/Cliente_" + lblClienteSAYID_Int.Text.ToString + "/Etiquetado")



            For Each item In lsArchivos

                If item.Contains(".pdf") And item.StartsWith("FTE_") Then
                    Archivo_Split = Split(item, "_")

                    If i = 0 Then
                        cadenaMayor = CInt(Archivo_Split(2) + CInt(Archivo_Split(3).Replace(".pdf", "")))
                        NombreArchivoPDF = item
                    Else
                        CadenaActual = CInt(Archivo_Split(2) + CInt(Archivo_Split(3).Replace(".pdf", "")))
                        If CadenaActual > cadenaMayor Then
                            NombreArchivoPDF = item
                        End If
                    End If
                    i += 1

                End If
            Next

            If i > 0 Then
                VisualizarPDF("Ventas/FTC/Cliente_" + lblClienteSAYID_Int.Text.ToString + "/Etiquetado", NombreArchivoPDF)
            Else
                show_message("Advertencia", "No se encontro archivo PDF de etiquetado en el servidor FTP.")
            End If
        Else
            show_message("Advertencia", "No es posible consultar el archivo PDF debido a que no se ha dado de alta ninguna etiqueta especial para este cliente ó no cuenta con Ficha Técnica de Etiquetado.")
        End If

    End Sub

    Private Sub Consultar_Nombre_EtiquetaEspecial()
        Dim PoliticasVentasBU As New Negocios.VentasPoliticasBU
        dtEtiqeutas_Especiales_Nombres = PoliticasVentasBU.Consultar_Nombre_TipoEtiqueta
    End Sub

    Private Sub VisualizarPDF(ByVal CarpetaOrigen As String, ByVal Archivo As String)
        Dim objFTP As New Tools.TransferenciaFTP
        Dim CarpetaDestino As String

        CarpetaDestino = Path.GetTempPath

        objFTP.DescargarArchivo(CarpetaOrigen, CarpetaDestino, Archivo)

        CarpetaDestino = CarpetaDestino + Archivo
        Process.Start(CarpetaDestino)
    End Sub


    Private Sub gboxEtiquetadoEtiquetado_mousedoubleclick(sender As Object, e As EventArgs) Handles gboxEtiquetadoEtiquetado.MouseDoubleClick
        If gboxEtiquetadoEtiquetado.Dock = DockStyle.Fill Then
            gboxEtiquetadoEtiquetado.Dock = DockStyle.None
            gboxEtiquetadoReqEspecial.Visible = True
            gboxEtiquetadoPoliticas.Visible = True
        Else
            gboxEtiquetadoEtiquetado.Dock = DockStyle.Fill
            gboxEtiquetadoReqEspecial.Visible = False
            gboxEtiquetadoPoliticas.Visible = False
        End If
    End Sub

    Private Sub gboxEtiquetadoReqEspecial_mousedoubleclick(sender As Object, e As EventArgs) Handles gboxEtiquetadoReqEspecial.MouseDoubleClick
        If gboxEtiquetadoReqEspecial.Dock = DockStyle.Fill Then
            gboxEtiquetadoReqEspecial.Dock = DockStyle.None
            gboxEtiquetadoPoliticas.Visible = True
            gboxEtiquetadoEtiquetado.Visible = True
        Else
            gboxEtiquetadoReqEspecial.Dock = DockStyle.Fill
            gboxEtiquetadoPoliticas.Visible = False
            gboxEtiquetadoEtiquetado.Visible = False
        End If
    End Sub

    Private Sub gboxEtiquetadoPoliticas_mousedoubleclick(sender As Object, e As EventArgs) Handles gboxEtiquetadoPoliticas.MouseDoubleClick
        If gboxEtiquetadoPoliticas.Dock = DockStyle.Fill Then
            gboxEtiquetadoPoliticas.Dock = DockStyle.None
            gboxEtiquetadoReqEspecial.Visible = True
            gboxEtiquetadoEtiquetado.Visible = True
        Else
            gboxEtiquetadoPoliticas.Dock = DockStyle.Fill
            gboxEtiquetadoReqEspecial.Visible = False
            gboxEtiquetadoEtiquetado.Visible = False
        End If
    End Sub

#Region "GRIDS"
#Region "ETIQUETADO"
    'ETIQUETADO ETIQUETADO
    Public Sub poblar_gridEtiquetadoEtiquetado(clienteID As Integer)

        gridEtiquetadoEtiquetado.DataSource = Nothing

        Dim VentasBU As New Negocios.VentasPoliticasBU
        Dim etiqueta As New DataTable
        Dim tipoEtiqueta As New DataTable
        Dim finfoEtiqueta As New DataTable
        Dim tamanoEtiqueta As New DataTable
        Dim ubicacionEtiqueta As New DataTable

        Dim vltipoEtiqueta As New ValueList
        Dim vlfinfoEtiqueta As New ValueList
        Dim vltamanoEtiqueta As New ValueList
        Dim vlubicacionEtiqueta As New ValueList

        etiqueta = VentasBU.Datos_TablaEtiquetasCliente(clienteID, AreaOperativa)

        tipoEtiqueta = VentasBU.Datos_TablaTipoEtiquetasCliente()
        finfoEtiqueta = VentasBU.Datos_TablaFuenteInformacionEtiquetasCliente()
        'tamanoEtiqueta = VentasBU.Datos_TablaTamanoEtiquetasCliente()
        'ubicacionEtiqueta = VentasBU.Datos_TablaUbicacionEtiquetasCliente()

        For Each fila As DataRow In tipoEtiqueta.Rows
            vltipoEtiqueta.ValueListItems.Add(fila.Item("tiet_tipoetiquetaespecialid"), fila.Item("tiet_nombre"))
        Next

        For Each fila As DataRow In finfoEtiqueta.Rows
            vlfinfoEtiqueta.ValueListItems.Add(fila.Item("fiet_fuenteinformacionetiquetaid"), fila.Item("fiet_nombre"))
        Next

        'For Each fila As DataRow In tamanoEtiqueta.Rows
        '    vltamanoEtiqueta.ValueListItems.Add(fila.Item("taet_tamanoetiquetaid"), fila.Item("taet_nombre"))
        'Next

        'For Each fila As DataRow In ubicacionEtiqueta.Rows
        '    vlubicacionEtiqueta.ValueListItems.Add(fila.Item("ubet_ubicacionetiquetaid"), fila.Item("ubet_nombre"))
        'Next

        gridEtiquetadoEtiquetado.DataSource = etiqueta
        gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(1).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(1).ValueList = vltipoEtiqueta
        gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(3).ValueList = vlfinfoEtiqueta
        'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(4).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(4).ValueList = vltamanoEtiqueta
        'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(5).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(5).ValueList = vlubicacionEtiqueta
        ''gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns.Add()

        gridEtiquetadoEtiquetadoDiseno(gridEtiquetadoEtiquetado)

    End Sub

    Private Sub gridEtiquetadoEtiquetadoDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(4).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(5).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(7).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(8).Hidden = True
        '=====================================================

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "*TIPO ETIQUETA"
        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "*IMPRIMIR EN YUYIN"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "*SISTEMA DE IMPRESIÓN"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "*IMAGEN"
        grid.DisplayLayout.Bands(0).Columns(6).Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub gridEtiquetadoEtiquetado_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridEtiquetadoEtiquetado.DoubleClickHeader

        If Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridEtiquetadoEtiquetado.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridEtiquetadoEtiquetado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridEtiquetadoEtiquetado.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If IsNothing(gridEtiquetadoEtiquetado.ActiveRow) Then Return

            gridEtiquetadoEtiquetado.ActiveRow.Cells("etcl_rutaimagen").Activated = True

            If ValidarCamposVacios_GridEtiquetado() Then Return
            Dim NextRowIndex As Integer = gridEtiquetadoEtiquetado.ActiveRow.Index + 1

            gridEtiquetadoEtiquetado.ActiveRow.Update()

            If NextRowIndex = gridEtiquetadoEtiquetado.Rows.Count And NextRowIndex > 0 Then
                gridEtiquetadoEtiquetado.DisplayLayout.Rows(NextRowIndex - 1).Activated = True
                gridEtiquetadoEtiquetado.DisplayLayout.Rows(NextRowIndex - 1).Selected = True
            Else
                gridEtiquetadoEtiquetado.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridEtiquetadoEtiquetado.DisplayLayout.Rows(NextRowIndex).Selected = True
            End If

        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridEtiquetadoEtiquetado(CInt(lblClienteSAYID_Int.Text))
            Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
        End If

    End Sub

    Private Sub gridEtiquetadoEtiquetado_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridEtiquetadoEtiquetado.CellChange

        Dim row As UltraGridRow = gridEtiquetadoEtiquetado.ActiveRow


        If e.Cell.Column.ToString = "tiet_nombre" Then

            ' MsgBox(row.Cells(1).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Text, 0))


            If gridEtiquetadoEtiquetado.ActiveRow.Cells(6).Value And gridEtiquetadoEtiquetado.ActiveRow.Cells(8).Value = 6 Then
                Dim objBU As New Ventas.Negocios.VentasPoliticasBU
                Dim dt As DataTable
                dt = objBU.ConsultaEtiquetaAutorizada(gridEtiquetadoEtiquetado.ActiveRow.Cells(5).Value)
                If CInt(dt.Rows(0).Item("Resultado")) = 1 Then
                    'MsgBox(gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Value.ToString)

                    If Not Mensajes_Y_Alertas("CONFIRMACION_G", "La etiqueta " + gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Value.ToString + " esta AUTORIZADA " +
                                        "en caso de que cambie el tipo de etiqueta,ésta sera rechazada para que PPCP verifique el diseño y autorice nuevamente" +
                                         "¿Desea cambiar el tipo de etiqueta ?") Then
                        gridEtiquetadoEtiquetado.ActiveCell.CancelUpdate()
                    Else
                        objBU.EliminaEtiquetaFichaTecnica(gridEtiquetadoEtiquetado.ActiveRow.Cells(5).Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, row.Cells(1).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Text, 0), e.Cell.Text.Trim)
                        Agregar_Actualizar_Etiquetas()
                        poblar_gridEtiquetadoEtiquetado(CInt(cboxClienteCliente.SelectedValue))
                        Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
                    End If
                End If
            End If
        End If
    End Sub


    Private Sub gridEtiquetadoEtiquetado_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridEtiquetadoEtiquetado.BeforeCellUpdate
        If gridEtiquetadoEtiquetado.ActiveRow.IsDataRow Then
            If e.Cell.Column.ToString = "*TIPO ETIQUETA" Then
                If gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Value = gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Text Then
                    e.Cancel = True
                End If
            ElseIf e.Cell.Column.ToString = "*FUENTE DE INFORMACIÓN" Then
                If gridEtiquetadoEtiquetado.ActiveRow.Cells(3).Value = gridEtiquetadoEtiquetado.ActiveRow.Cells(3).Text Then
                    e.Cancel = True
                End If
                'ElseIf e.Cell.Column.ToString = "*TAMAÑO" Then
                '    If gridEtiquetadoEtiquetado.ActiveRow.Cells(4).Value = gridEtiquetadoEtiquetado.ActiveRow.Cells(4).Text Then
                '        e.Cancel = True
                '    End If
                'ElseIf e.Cell.Column.ToString = "*UBICACIÓN" Then
                '    If gridEtiquetadoEtiquetado.ActiveRow.Cells(5).Value = gridEtiquetadoEtiquetado.ActiveRow.Cells(5).Text Then
                '        e.Cancel = True
                '    End If
            End If

            If e.Cell.Column.ToString = "Activo" Then
                If gridEtiquetadoEtiquetado.ActiveRow.Cells(0).Value = 0 Then
                    e.Cancel = True
                End If
            End If
        End If

    End Sub

    Private Sub gridEtiquetadoEtiquetado_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridEtiquetadoEtiquetado.BeforeRowDeactivate
        If gridEtiquetadoEtiquetado.ActiveRow.IsDataRow Then
            If gridEtiquetadoEtiquetado.ActiveRow.DataChanged Or gridEtiquetadoEtiquetado.ActiveRow.Cells(0).Value = 0 Then
                If ValidarCamposVacios_GridEtiquetado() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridEtiquetadoEtiquetado_Leave(sender As Object, e As EventArgs) Handles gridEtiquetadoEtiquetado.Leave
        If Not IsNothing(gridEtiquetadoEtiquetado.ActiveRow) Then
            If gridEtiquetadoEtiquetado.ActiveRow.IsDataRow Then
                If gridEtiquetadoEtiquetado.ActiveRow.DataChanged Or gridEtiquetadoEtiquetado.ActiveRow.Cells(0).Value = 0 Then
                    If ValidarCamposVacios_GridEtiquetado() = True Then
                        gridEtiquetadoEtiquetado.Focus()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gridEtiquetadoEtiquetado_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridEtiquetadoEtiquetado.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor

        If gridEtiquetadoEtiquetado.ActiveRow.IsDataRow Then
            If gridEtiquetadoEtiquetado.ActiveRow.DataChanged Then
                If gridEtiquetadoEtiquetado.ActiveRow.Cells("tiet_nombre").Value <> "--Selecciona--" _
                    And gridEtiquetadoEtiquetado.ActiveRow.Cells("fiet_nombre").Value <> "--Selecciona--" Then
                    'And gridEtiquetadoEtiquetado.ActiveRow.Cells("ubet_nombre").Value <> "--Selecciona--" _
                    'And gridEtiquetadoEtiquetado.ActiveRow.Cells("taet_nombre").Value <> "--Selecciona--" Then

                    Agregar_Actualizar_Etiquetas()

                    Dim j As Integer = ContarEtiquetasEspeciales()
                    If j > 0 Then
                        ValidarFTC_EtiquetadoPendiente()

                        btnEtiquetasVisualizar.Enabled = True
                        btnEtiquetasCargarPDF.Enabled = True
                    Else
                        ValidarFTC_EtiquetadoPendiente()
                        btnEtiquetasVisualizar.Enabled = False
                        btnEtiquetasCargarPDF.Enabled = False
                    End If

                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub gridEtiquetadoEtiquetado_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridEtiquetadoEtiquetado.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridEtiquetadoEtiquetado_ClickCellButton(sender As Object, e As CellEventArgs) Handles gridEtiquetadoEtiquetado.ClickCellButton

        Dim objBU As New Negocios.VentasPoliticasBU
        Dim row As UltraGridRow = gridEtiquetadoEtiquetado.ActiveRow
        If IsNothing(row) Then Return

        Dim ruta As String

        ofdFichaTecnica.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        'ofdFichaTecnica.Filter = "JPEG, PDF, DOC, DOCX, XLS, XLSX, PNG, GIF|*.pdf;*.jpg; *.doc; *.docx;*.xls; *.png;*.gif"
        ofdFichaTecnica.Filter = "JPEG|*.jpg"
        ofdFichaTecnica.FilterIndex = 3
        ofdFichaTecnica.ShowDialog()
        ruta = ofdFichaTecnica.FileName

        Dim archivo() As String
        archivo = Split(ruta, "\")

        For n = 0 To UBound(archivo, 1)

            If UBound(archivo) = n Then
                Archivos.PNombreArchivo = archivo(n)

            End If

        Next

        If CInt(gridEtiquetadoEtiquetado.ActiveRow.Cells(0).Value) = 0 Then
            Dim num As Integer = objBU.Datos_UltimaEtiquetaCliente_mas1()
            gridEtiquetadoEtiquetado.ActiveRow.Cells("etcl_rutaimagen").Value = num.ToString + ".jpg"
        Else
            gridEtiquetadoEtiquetado.ActiveRow.Cells("etcl_rutaimagen").Value = row.Cells(0).Text + ".jpg"
        End If

        gridEtiquetadoEtiquetado.ActiveRow.Cells("imagen_archivo").Value = ruta

    End Sub

    Private Sub Agregar_Actualizar_Etiquetas()
        If gridEtiquetadoEtiquetado.ActiveRow.DataChanged Then

            Dim etiqueta As New Entidades.EtiquetaCliente
            Dim tipoEtiqueta As New Entidades.TipoEtiqueta
            Dim finfoEtiqueta As New Entidades.FuenteInformacionEtiqueta
            Dim tamanoEtiqueta As New Entidades.TamanoEtiqueta
            Dim ubicacionEtiqueta As New Entidades.UbicacionEtiqueta
            Dim cliente As New Entidades.Cliente
            Dim objBU As New Negocios.VentasPoliticasBU
            Dim row As UltraGridRow = gridEtiquetadoEtiquetado.ActiveRow


            etiqueta.etiquetaclienteid = CInt(row.Cells(0).Value)

            tipoEtiqueta.tipoetiquetaespecialid = row.Cells(1).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Text, 0)
            etiqueta.tipoetiquetaespecial = tipoEtiqueta

            etiqueta.imprimeenyuyin = CBool(gridEtiquetadoEtiquetado.ActiveRow.Cells(2).Value)

            finfoEtiqueta.fuenteinformacionetiquetaid = row.Cells(3).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(3).Text, 0)
            etiqueta.fuenteinformacionetiqueta = finfoEtiqueta

            'tamanoEtiqueta.tamanoetiquetaid = row.Cells(4).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(4).Text, 0)
            'etiqueta.tamanoetiqueta = tamanoEtiqueta

            'ubicacionEtiqueta.ubicacionetiquetaid = row.Cells(5).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(5).Text, 0)
            'etiqueta.ubicacionetiqueta = ubicacionEtiqueta

            'If String.IsNullOrWhiteSpace(gridEtiquetadoEtiquetado.ActiveRow.Cells(4).Value.ToString) Then
            '    etiqueta.rutaimagen = String.Empty
            'Else
            '    etiqueta.rutaimagen = row.Cells("etcl_rutaimagen").Value.ToString
            'End If

            cliente.clienteid = CInt(row.Cells(5).Value)
            etiqueta.cliente = cliente

            etiqueta.activo = CBool(gridEtiquetadoEtiquetado.ActiveRow.Cells("Activo").Text)

            If etiqueta.etiquetaclienteid = 0 Then
                objBU.AltaEtiquetaCliente(etiqueta)
                ValidarEtiqeutaEspecialAgregada()
            Else
                objBU.EditarEtiquetaCliente(etiqueta)
                ValidarEtiqeutaEspecialAgregada()
            End If


            'If etiqueta.activo Then
            '    Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + cliente.clienteid.ToString + "/Etiquetado"
            '    Dim objFTP As New Tools.TransferenciaFTP
            '    If etiqueta.etiquetaclienteid = 0 Then
            '        If row.Cells(6).Text <> "" Then
            '            'objFTP.EnviarArchivo(CarpetaDestino, row.Cells(1).Value.ToString + "_" + etiqueta.etiquetaclienteid.ToString + ".jpg")
            '            objFTP.EnviarArchivo(RutaArchivo, row.Cells("imagen_archivo").Text)
            '            objFTP.RenombraArchivo(RutaArchivo, Archivos.PNombreArchivo, row.Cells(6).Value.ToString)
            '        End If
            '    Else
            '        If row.Cells(6).Text <> "" Then
            '            objFTP.BorraArchivo(RutaArchivo, row.Cells(6).Text)
            '            objFTP.EnviarArchivo(RutaArchivo, row.Cells("imagen_archivo").Text)
            '            objFTP.RenombraArchivo(RutaArchivo, Archivos.PNombreArchivo, row.Cells(6).Text)
            '        End If
            '    End If
            'End If

            poblar_gridEtiquetadoEtiquetado(CInt(cboxClienteCliente.SelectedValue))
            Activar_Inactivar_grids(gridEtiquetadoEtiquetado, ModoEdicion_Etiquetado)
        End If


    End Sub

    Private Sub btnEtiquetado_Etiquetado_Click(sender As Object, e As EventArgs) Handles btnEtiquetado_Etiquetado.Click
        Dim grid As DataTable = gridEtiquetadoEtiquetado.DataSource
        Dim row As UltraGridRow = gridEtiquetadoEtiquetado.ActiveRow

        'gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.Button
        gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.CheckBox

        gridEtiquetadoEtiquetado.Focus()
        LimpiarFiltrosGrid(gridEtiquetadoEtiquetado)

        grid.Rows.Add(0, "--Selecciona--", False, "--Selecciona--", " ", CInt(lblClienteSAYID_Int.Text), 1, " ", 0)

        gridEtiquetadoEtiquetado.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
        Try
            gridEtiquetadoEtiquetado.ActiveRow.Activation = Activation.AllowEdit
            gridEtiquetadoEtiquetado.ActiveCell = gridEtiquetadoEtiquetado.ActiveRow.Cells(3)
            gridEtiquetadoEtiquetado.ActiveCell.Activation = Activation.AllowEdit
        Catch ex As Exception

        End Try

        gridEtiquetadoEtiquetado.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridEtiquetadoEtiquetado.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End Sub

    Private Function ValidarCamposVacios_GridEtiquetado() As Boolean
        ValidarCamposVacios_GridEtiquetado = False

        If gridEtiquetadoEtiquetado.ActiveRow.Cells("tiet_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_GridEtiquetado = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccioner el tipo de etiqueta o presione  'ESCAPE' para cancelar esta acción.")
        ElseIf gridEtiquetadoEtiquetado.ActiveRow.Cells("fiet_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_GridEtiquetado = True
            Mensajes_Y_Alertas("ADVERTENCIA", "La fuente de información o 'ESCAPE' para cancelar esta acción.")
            'ElseIf gridEtiquetadoEtiquetado.ActiveRow.Cells("ubet_nombre").Value = "--Selecciona--" Then
            '    ValidarCamposVacios_GridEtiquetado = True
            '    Mensajes_Y_Alertas("ADVERTENCIA", "seleccione la ubicación de la etiqueta o presione  'ESCAPE' para cancelar esta acción.")
            'ElseIf gridEtiquetadoEtiquetado.ActiveRow.Cells("taet_nombre").Value = "--Selecciona--" Then
            '    ValidarCamposVacios_GridEtiquetado = True
            '    Mensajes_Y_Alertas("ADVERTENCIA", "seleccione el tamaño de la etiqueta o presione  'ESCAPE' para cancelar esta acción.")
        End If


        Return ValidarCamposVacios_GridEtiquetado
    End Function

    Private Sub gridEtiquetadoEtiquetado_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles gridEtiquetadoEtiquetado.MouseDoubleClick

        If IsNothing(gridEtiquetadoEtiquetado.ActiveRow) Then Return
        If gridEtiquetadoEtiquetado.ActiveRow.IsFilterRow Then Return

        Dim row As UltraGridRow = gridEtiquetadoEtiquetado.ActiveRow

        Dim galeriaForm As New GaleriaImagenesForm
        galeriaForm.RutaArchivo = "Ventas/FTC/Cliente_" + row.Cells(7).Text + "/Etiquetado/"
        galeriaForm.NombreArchivo = row.Cells(6).Text

        galeriaForm.Show()

    End Sub

    'Private Sub gridEtiquetadoEtiquetado_MouseClick(sender As Object, e As MouseEventArgs) Handles gridEtiquetadoEtiquetado.MouseClick

    '    If rbtnClienteStatusInactivo.Checked Then Return

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.gridEtiquetadoEtiquetado.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.gridEtiquetadoEtiquetado.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)

    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            Dim cms = New ContextMenuStrip
    '            Dim item1 = cms.Items.Add("Nueva etiqueta")
    '            item1.Tag = 1
    '            AddHandler item1.Click, AddressOf gridEtiquetadoEtiquetado_menuChoice

    '            Dim item2 = cms.Items.Add("Editar etiqueta")
    '            item2.Tag = 2
    '            AddHandler item2.Click, AddressOf gridEtiquetadoEtiquetado_menuChoice

    '            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '                cms.Show(Control.MousePosition)
    '            Else
    '                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '                    cms.Show(Control.MousePosition)
    '                End If
    '            End If

    '        End If
    '    End If

    'End Sub

    'Private Sub gridEtiquetadoEtiquetado_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVA ETIQUETA


    '    If selection = 2 Then ''EDITAR DOCUMENTO ACTUAL

    '        For Each row In gridEtiquetadoEtiquetado.Selected.Rows
    '            Dim i As Integer = gridEtiquetadoEtiquetado.Rows.Count
    '            gridEtiquetadoEtiquetado.DisplayLayout.Bands(0).Columns(6).Style = ColumnStyle.Button
    '            gridEtiquetadoEtiquetado.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridEtiquetadoEtiquetado.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridEtiquetadoEtiquetado_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridEtiquetadoEtiquetado.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridEtiquetadoEtiquetado.ActiveCell.Column.Index

    '        If gridEtiquetadoEtiquetado.ActiveRow.DataChanged Then

    '        Else
    '            If gridEtiquetadoEtiquetado.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridEtiquetadoEtiquetado.ActiveCell.Value) Then
    '                    poblar_gridEtiquetadoEtiquetado(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
    '                    gridEtiquetadoEtiquetado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub gridEtiquetadoEtiquetado_AfterRowActivate(sender As Object, e As EventArgs) Handles gridEtiquetadoEtiquetado.AfterRowActivate
    '    gridEtiquetadoEtiquetado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridEtiquetadoEtiquetado.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub

    'Private Sub gridEtiquetadoEtiquetado_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridEtiquetadoEtiquetado.BeforeRowDeactivate

    '    If gridEtiquetadoEtiquetado.ActiveRow.DataChanged Then

    '        Dim etiqueta As New Entidades.EtiquetaCliente
    '        Dim tipoEtiqueta As New Entidades.TipoEtiqueta
    '        Dim finfoEtiqueta As New Entidades.FuenteInformacionEtiqueta
    '        Dim tamanoEtiqueta As New Entidades.TamanoEtiqueta
    '        Dim ubicacionEtiqueta As New Entidades.UbicacionEtiqueta
    '        Dim cliente As New Entidades.Cliente
    '        Dim objBU As New Negocios.VentasPoliticasBU

    '        Dim row As UltraGridRow = gridEtiquetadoEtiquetado.ActiveRow

    '        'row.Cells(4).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(4).Value.ToString, 0)
    '        etiqueta.etiquetaclienteid = CInt(row.Cells(0).Value)

    '        tipoEtiqueta.tipoetiquetaespecialid = row.Cells(1).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(1).Text, 0)
    '        etiqueta.tipoetiquetaespecial = tipoEtiqueta

    '        etiqueta.imprimeenyuyin = CBool(gridEtiquetadoEtiquetado.ActiveRow.Cells(2).Value)

    '        finfoEtiqueta.fuenteinformacionetiquetaid = row.Cells(3).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(3).Text, 0)
    '        etiqueta.fuenteinformacionetiqueta = finfoEtiqueta

    '        tamanoEtiqueta.tamanoetiquetaid = row.Cells(4).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(4).Text, 0)
    '        etiqueta.tamanoetiqueta = tamanoEtiqueta

    '        ubicacionEtiqueta.ubicacionetiquetaid = row.Cells(5).Column.ValueList.GetValue(gridEtiquetadoEtiquetado.ActiveRow.Cells(5).Text, 0)
    '        etiqueta.ubicacionetiqueta = ubicacionEtiqueta

    '        If String.IsNullOrWhiteSpace(gridEtiquetadoEtiquetado.ActiveRow.Cells(6).Value.ToString) Then
    '            etiqueta.rutaimagen = String.Empty
    '        Else
    '            etiqueta.rutaimagen = row.Cells("etcl_rutaimagen").Value.ToString
    '        End If

    '        cliente.clienteid = CInt(row.Cells(7).Value)
    '        etiqueta.cliente = cliente

    '        'If tipoEtiqueta.tipoetiquetaespecialid = 0 Then
    '        '    etiqueta.activo = False
    '        'Else
    '        '    etiqueta.activo = True
    '        'End If

    '        etiqueta.activo = CBool(gridEtiquetadoEtiquetado.ActiveRow.Cells("Activo").Value)

    '        If etiqueta.etiquetaclienteid = 0 Then
    '            objBU.AltaEtiquetaCliente(etiqueta)
    '            ValidarEtiqeutaEspecialAgregada()
    '        Else
    '            objBU.EditarEtiquetaCliente(etiqueta)
    '            ValidarEtiqeutaEspecialAgregada()
    '        End If


    '        If etiqueta.activo Then
    '            Dim RutaArchivo As String = "Ventas/FTC/Cliente_" + cliente.clienteid.ToString + "/Etiquetado"
    '            Dim objFTP As New Tools.TransferenciaFTP
    '            If etiqueta.etiquetaclienteid = 0 Then
    '                'objFTP.EnviarArchivo(CarpetaDestino, row.Cells(1).Value.ToString + "_" + etiqueta.etiquetaclienteid.ToString + ".jpg")
    '                objFTP.EnviarArchivo(RutaArchivo, row.Cells("imagen_archivo").Text)
    '                objFTP.RenombraArchivo(RutaArchivo, Archivos.PNombreArchivo, row.Cells(6).Value.ToString)
    '            Else
    '                objFTP.BorraArchivo(RutaArchivo, row.Cells(6).Text)
    '                objFTP.EnviarArchivo(RutaArchivo, row.Cells("imagen_archivo").Text)
    '                objFTP.RenombraArchivo(RutaArchivo, Archivos.PNombreArchivo, row.Cells(6).Text)
    '            End If

    '        End If

    '        poblar_gridEtiquetadoEtiquetado(CInt(cboxClienteCliente.SelectedValue))

    '    Else

    '    End If

    '    gridEtiquetadoEtiquetado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    'End Sub

#End Region


#Region "REQUERIMIENTOS ESPECIALES"

    Public Sub poblar_gridEtiquetadoReqEspecial(clienteID As Integer)

        gridEtiquetadoReqEspecial.DataSource = Nothing

        Dim VentasBU As New Negocios.VentasPoliticasBU
        Dim requerimientoEspecial As New DataTable
        Dim tipoRequerimiento As New DataTable
        Dim requerimiento As New DataTable


        Dim vltipoRequerimiento As New ValueList
        Dim vlrequerimiento As New ValueList

        requerimientoEspecial = VentasBU.Datos_TablaRequerimientosEspecialesCliente(clienteID, AreaOperativa)

        tipoRequerimiento = VentasBU.Datos_TablaTipoRequerimientosCliente()
        requerimiento = VentasBU.Datos_TablaRequerimientosCliente()

        For Each fila As DataRow In tipoRequerimiento.Rows
            vltipoRequerimiento.ValueListItems.Add(fila.Item("tres_tiporequerimientoespecialid"), fila.Item("tres_nombre"))
        Next

        For Each fila As DataRow In requerimiento.Rows
            vlrequerimiento.ValueListItems.Add(fila.Item("rees_requerimientoespecialid"), fila.Item("rees_nombre"))
        Next


        gridEtiquetadoReqEspecial.DataSource = requerimientoEspecial
        gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(2).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(2).ValueList = vltipoRequerimiento
        gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
        gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(3).ValueList = vlrequerimiento

        gridEtiquetadoReqEspecialDiseno(gridEtiquetadoReqEspecial)

    End Sub

    Public Sub poblar_gridCorridasExtranjeras(ClienteID As Integer)
        grdCorridasExtranjeras.DataSource = Nothing

        Dim VentasBU As New Negocios.VentasPoliticasBU
        Dim dtCorridasExtranjeras As New DataTable

        Try
            dtCorridasExtranjeras = VentasBU.ConsultarCorridasExtranjeras(ClienteID)
            grdCorridasExtranjeras.DataSource = dtCorridasExtranjeras
            grdCorridasExtranjerasDiseno(grdCorridasExtranjeras)
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try

    End Sub

    Private Sub grdCorridasExtranjerasDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "CORRIDA"
        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "ABREV"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "ACTIVO"

        asignaFormato_Columna(grid)

        'grid.DisplayLayout.Bands(0).Columns(3).Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue


        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub gridEtiquetadoReqEspecialDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 30
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grid.DisplayLayout.Bands(0).Columns(0).Hidden = True '
        grid.DisplayLayout.Bands(0).Columns(1).Hidden = True
        grid.DisplayLayout.Bands(0).Columns(2).Hidden = True

        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "*TIPO REQUERIMIENTO"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "*REQUERIMIENTO"
        grid.DisplayLayout.Bands(0).Columns(4).Header.Caption = "*VALOR"
        grid.DisplayLayout.Bands(0).Columns(5).Header.Caption = "*DESCRIPCIÓN"
        grid.DisplayLayout.Bands(0).Columns("Activo").Header.Caption = "*ACTIVO"

        asignaFormato_Columna(grid)

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue


        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub

    Private Sub gridEtiquetadoReqEspecial_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridEtiquetadoReqEspecial.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub gridEtiquetadoReqEspecial_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridEtiquetadoReqEspecial.DoubleClickHeader
        If Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridEtiquetadoReqEspecial.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub

    Private Sub gridEtiquetadoReqEspecial_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridEtiquetadoReqEspecial.BeforeCellUpdate
        If gridEtiquetadoReqEspecial.ActiveRow.IsDataRow Then
            If e.Cell.Column.ToString = "rees_nombre" Then
                If gridEtiquetadoReqEspecial.ActiveRow.Cells("rees_nombre").Value = gridEtiquetadoReqEspecial.ActiveRow.Cells("rees_nombre").Text Then
                    e.Cancel = True
                End If
            End If

            If e.Cell.Column.ToString = "Activo" Then
                If gridEtiquetadoReqEspecial.ActiveRow.Cells(1).Value = 0 Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub gridEtiquetadoReqEspecial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridEtiquetadoReqEspecial.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then

            gridEtiquetadoReqEspecial.ActiveRow.Cells("ACTIVO").Activated = True

            If ValidarCamposVacios_GridRequerimientoEspecial() Then Return

            Dim NextRowIndex As Integer = gridEtiquetadoReqEspecial.ActiveRow.Index + 1
            gridEtiquetadoReqEspecial.ActiveRow.Update()

            If NextRowIndex = gridEtiquetadoReqEspecial.Rows.Count Then
                gridEtiquetadoReqEspecial.DisplayLayout.Rows(NextRowIndex - 1).Activated = True
                gridEtiquetadoReqEspecial.DisplayLayout.Rows(NextRowIndex - 1).Selected = True
            Else
                gridEtiquetadoReqEspecial.DisplayLayout.Rows(NextRowIndex).Activated = True
                gridEtiquetadoReqEspecial.DisplayLayout.Rows(NextRowIndex).Selected = True
            End If
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            poblar_gridEtiquetadoReqEspecial(cboxClienteCliente.SelectedValue)
            Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)
        End If

    End Sub

    Private Sub gridEtiquetadoReqEspecial_BeforeRowDeactivate(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridEtiquetadoReqEspecial.BeforeRowDeactivate
        If gridEtiquetadoReqEspecial.ActiveRow.IsDataRow Then
            If gridEtiquetadoReqEspecial.ActiveRow.DataChanged Or gridEtiquetadoReqEspecial.ActiveRow.Cells(1).Value = 0 Then
                If ValidarCamposVacios_GridRequerimientoEspecial() = True Then
                    e.Cancel = True
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub gridEtiquetadoReqEspecial_Leave(sender As Object, e As EventArgs) Handles gridEtiquetadoReqEspecial.Leave
        If Not IsNothing(gridEtiquetadoReqEspecial.ActiveRow) Then
            If gridEtiquetadoReqEspecial.ActiveRow.IsDataRow Then
                If gridEtiquetadoReqEspecial.ActiveRow.DataChanged Or gridEtiquetadoReqEspecial.ActiveRow.Cells(1).Value = 0 Then
                    If ValidarCamposVacios_GridRequerimientoEspecial() = True Then
                        gridEtiquetadoReqEspecial.Focus()
                        Return
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub gridEtiquetadoReqEspecial_BeforeRowUpdate(sender As Object, e As CancelableRowEventArgs) Handles gridEtiquetadoReqEspecial.BeforeRowUpdate
        Me.Cursor = Cursors.WaitCursor

        If gridEtiquetadoReqEspecial.ActiveRow.IsDataRow Then
            If gridEtiquetadoReqEspecial.ActiveRow.DataChanged Then
                If gridEtiquetadoReqEspecial.ActiveRow.Cells("rees_nombre").Value <> "--Selecciona--" Then
                    AgregarEditar_RequerimientosEspeciales()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ValidarCamposVacios_GridRequerimientoEspecial() As Boolean
        ValidarCamposVacios_GridRequerimientoEspecial = False

        If gridEtiquetadoReqEspecial.ActiveRow.Cells("rees_nombre").Value = "--Selecciona--" Then
            ValidarCamposVacios_GridRequerimientoEspecial = True
            Mensajes_Y_Alertas("ADVERTENCIA", "seleccione el requerimiento o presione  'ESCAPE' para cancelar esta acción.")
        End If

        Return ValidarCamposVacios_GridRequerimientoEspecial
    End Function

    Private Sub AgregarEditar_RequerimientosEspeciales()
        Dim requerimiento As New Entidades.RequerimientoEspCliente
        Dim requerimientoEspecial As New Entidades.RequerimientoEspecial
        Dim cliente As New Entidades.Cliente
        Dim objBU As New Negocios.VentasPoliticasBU

        Dim row As UltraGridRow = gridEtiquetadoReqEspecial.ActiveRow

        requerimiento.requerimientoespecialclienteid = CInt(gridEtiquetadoReqEspecial.ActiveRow.Cells(1).Value)
        requerimiento.valor = CStr(gridEtiquetadoReqEspecial.ActiveRow.Cells(4).Value)
        requerimiento.descripcion = CStr(gridEtiquetadoReqEspecial.ActiveRow.Cells(5).Value)
        requerimientoEspecial.requerimientoespecialid = row.Cells(3).Column.ValueList.GetValue(gridEtiquetadoReqEspecial.ActiveRow.Cells(3).Text, 0)
        requerimiento.requerimientoespecial = requerimientoEspecial
        cliente.clienteid = CInt(gridEtiquetadoReqEspecial.ActiveRow.Cells(0).Value)
        requerimiento.cliente = cliente
        requerimiento.activo = CBool(gridEtiquetadoReqEspecial.ActiveRow.Cells("Activo").Text)

        If requerimiento.requerimientoespecialclienteid = 0 Then
            objBU.AltaRequerimientoCliente(requerimiento)
        Else
            objBU.EditarRequerimientoCliente(requerimiento)
        End If

        poblar_gridEtiquetadoReqEspecial(CInt(cboxClienteCliente.SelectedValue))
        Activar_Inactivar_grids(gridEtiquetadoReqEspecial, ModoEdicion_Etiquetado)
    End Sub

    Private Sub btnEtiquetado_Requerimientos_Click(sender As Object, e As EventArgs) Handles btnEtiquetado_Requerimientos.Click
        Dim grid As DataTable = gridEtiquetadoReqEspecial.DataSource
        Dim row As UltraGridRow = gridEtiquetadoReqEspecial.ActiveRow
        Dim tipoRequerimiento As UltraGridColumn = gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(2)
        Dim requerimiento As UltraGridColumn = gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(3)

        gridEtiquetadoReqEspecial.Focus()
        LimpiarFiltrosGrid(gridEtiquetadoReqEspecial)

        grid.Rows.Add(CInt(cboxClienteCliente.SelectedValue), 0, tipoRequerimiento, "--Selecciona--", String.Empty, String.Empty, 1)
        gridEtiquetadoReqEspecial.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True

        Try
            gridEtiquetadoReqEspecial.ActiveRow.Activation = Activation.AllowEdit
            gridEtiquetadoReqEspecial.ActiveCell = gridEtiquetadoReqEspecial.ActiveRow.Cells(3)
            gridEtiquetadoReqEspecial.ActiveCell.Activation = Activation.AllowEdit
        Catch ex As Exception

        End Try

        gridEtiquetadoReqEspecial.PerformAction(UltraGridAction.ToggleCellSel, False, False)
        gridEtiquetadoReqEspecial.PerformAction(UltraGridAction.EnterEditMode, False, False)

    End Sub


    Private Sub chboxEtiquetadoValidarCodigoEtiquetas_CheckedChanged(sender As Object, e As EventArgs) Handles chboxEtiquetadoValidarCodigoEtiquetas.CheckedChanged
        If chboxEtiquetadoValidarCodigoEtiquetas.Checked = True Then
            chkCodigosAmece.Enabled = True

            btnCodigosCliente.Enabled = True
            lblCodigos.Enabled = True
            lblCodigos_Cliente.Enabled = True
        Else
            chkCodigosAmece.Enabled = False
            chkCodigosAmece.Checked = False

            btnCodigosCliente.Enabled = False
            lblCodigos.Enabled = False
            lblCodigos_Cliente.Enabled = False
        End If
    End Sub


    'Private Sub gridEtiquetadoReqEspecial_MouseClick(sender As Object, e As MouseEventArgs) Handles gridEtiquetadoReqEspecial.MouseClick

    '    If rbtnClienteStatusInactivo.Checked Then Return

    '    Dim mainElement As UIElement
    '    Dim element As UIElement
    '    Dim screenPoint As Point
    '    Dim clientPoint As Point
    '    Dim row As UltraGridRow
    '    Dim cell As UltraGridCell

    '    mainElement = Me.gridEtiquetadoReqEspecial.DisplayLayout.UIElement
    '    screenPoint = Control.MousePosition
    '    clientPoint = Me.gridEtiquetadoReqEspecial.PointToClient(screenPoint)
    '    element = mainElement.ElementFromPoint(clientPoint)

    '    If element Is Nothing Then Return

    '    row = element.GetContext(GetType(UltraGridRow))

    '    If Not row Is Nothing Then
    '        cell = element.GetContext(GetType(UltraGridCell))

    '        If Not cell Is Nothing Then

    '            If e.Button <> Windows.Forms.MouseButtons.Right Then Return
    '            Dim cms = New ContextMenuStrip
    '            Dim item1 = cms.Items.Add("Nuevo requerimiento")
    '            item1.Tag = 1
    '            AddHandler item1.Click, AddressOf gridEtiquetadoReqEspecial_menuChoice

    '            Dim item2 = cms.Items.Add("Editar requerimiento")
    '            item2.Tag = 2
    '            AddHandler item2.Click, AddressOf gridEtiquetadoReqEspecial_menuChoice

    '            If Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser = CInt(cboxClienteAtnClientes.SelectedValue) Then
    '                cms.Show(Control.MousePosition)
    '            Else
    '                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "EDITARCOMPLETA") Then
    '                    cms.Show(Control.MousePosition)
    '                End If
    '            End If

    '        End If
    '    End If

    'End Sub

    'Private Sub gridEtiquetadoReqEspecial_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item = CType(sender, ToolStripMenuItem)
    '    Dim selection = CInt(item.Tag)

    '    If selection = 1 Then ''AGREGAR NUEVO REQUERIMIENTO

    'Dim grid As DataTable = gridEtiquetadoReqEspecial.DataSource
    'Dim row As UltraGridRow = gridEtiquetadoReqEspecial.ActiveRow
    'Dim tipoRequerimiento As UltraGridColumn = gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(2)
    'Dim requerimiento As UltraGridColumn = gridEtiquetadoReqEspecial.DisplayLayout.Bands(0).Columns(3)

    '        If Not IsNothing(row) Then

    '            grid.Rows.Add(CInt(cboxClienteCliente.SelectedValue), 0, tipoRequerimiento, requerimiento, String.Empty, String.Empty)

    '            gridEtiquetadoReqEspecial.DisplayLayout.Rows(grid.Rows.Count - 1).Activated = True
    '            Try
    '                gridEtiquetadoReqEspecial.ActiveRow.Activation = Activation.AllowEdit
    '                gridEtiquetadoReqEspecial.ActiveCell = gridContacto.ActiveRow.Cells(3)
    '                gridEtiquetadoReqEspecial.ActiveCell.Activation = Activation.AllowEdit
    '            Catch ex As Exception

    '            End Try


    '            gridEtiquetadoReqEspecial.PerformAction(UltraGridAction.ToggleCellSel, False, False)
    '            gridEtiquetadoReqEspecial.PerformAction(UltraGridAction.EnterEditMode, False, False)

    '        End If

    '    End If

    '    If selection = 2 Then ''EDITAR REQUERIMIENTO

    '        For Each row In gridEtiquetadoReqEspecial.Selected.Rows
    '            Dim i As Integer = gridEtiquetadoReqEspecial.Rows.Count

    '            gridEtiquetadoReqEspecial.DisplayLayout.Rows(row.Index).Activation = Activation.AllowEdit
    '            gridEtiquetadoReqEspecial.DisplayLayout.Override.CellClickAction = CellClickAction.Edit

    '        Next

    '    End If

    'End Sub

    'Private Sub gridEtiquetadoReqEspecial_BeforeExitEditMode(sender As Object, e As UltraWinGrid.BeforeExitEditModeEventArgs) Handles gridEtiquetadoReqEspecial.BeforeExitEditMode
    '    Try
    '        Dim cellIndex As Integer = gridEtiquetadoReqEspecial.ActiveCell.Column.Index

    '        If gridEtiquetadoReqEspecial.ActiveRow.DataChanged Then

    '        Else
    '            If gridEtiquetadoReqEspecial.ActiveCell.DataChanged Then
    '            Else
    '                If String.IsNullOrWhiteSpace(gridEtiquetadoReqEspecial.ActiveCell.Value) Then
    '                    poblar_gridEtiquetadoReqEspecial(CInt(gridRFCRFC.ActiveRow.Cells(0).Value))
    '                    gridEtiquetadoReqEspecial.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Private Sub gridEtiquetadoReqEspecial_AfterRowActivate(sender As Object, e As EventArgs) Handles gridEtiquetadoReqEspecial.AfterRowActivate
    '    gridEtiquetadoReqEspecial.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    '    For Each row In gridEtiquetadoReqEspecial.Rows
    '        row.Activation = Activation.NoEdit
    '    Next
    'End Sub


#End Region

#End Region
    Private Sub btn_Etiquetado_EditarPoliticas_Click(sender As Object, e As EventArgs) Handles btn_Etiquetado_EditarPoliticas.Click
        btn_Etiquetado_EditarPoliticas.Enabled = False
        IniciarEdicionPoliticas()
    End Sub

    Private Sub btnCodigosCliente_Click(sender As Object, e As EventArgs) Handles btnCodigosCliente.Click
        Dim objCodigosCliente As New Programacion.Vista.ListaCodigosClientes
        Dim formCodigosEspeciales As New Programacion.Vista.CodsEspecialesClienteForm
        Dim objCodigosEspeciales As New Programacion.Negocios.CodigosEspecialesClienteBU

        If objCodigosEspeciales.BuscarClienteConCodsEspeciales(CInt(lblClienteSAYID_Int.Text)) Then
            'Formulario para clientes con códigos especiales 
            formCodigosEspeciales.idCliente = CInt(lblClienteSAYID_Int.Text)
            formCodigosEspeciales.txtCliente.Text = cboxClienteCliente.Text
            formCodigosEspeciales.ShowDialog()
        Else
            'Formulario para clientes sin códigos especiales
            objCodigosCliente.StartPosition = FormStartPosition.CenterScreen
            objCodigosCliente.IdClienteSAY = CInt(lblClienteSAYID_Int.Text)
            objCodigosCliente.NombreClienteSAy = cboxClienteCliente.Text
            objCodigosCliente.ValidarCodigoAmece = chkCodigosAmece.Checked
            objCodigosCliente.ShowDialog()
        End If

    End Sub

End Class
