Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Tools
Imports System

Public Class EnvioEstadosCuentaForm
    Dim listaInicial As New List(Of String)
    Dim advertencia As New AdvertenciaForm
    Dim destinosNotificaFallo As String = String.Empty

    Public Enum ErroresEnvio As Integer
        SinError = 0
        SinDocumentosCXC = 1
        SinDestinoConfigurado = 2
        ErrorGenerarPDF = 3
        ErrorDeEnvio = 4 ''Que ocurrió un error al enviar el correo
    End Enum

    Private Sub EnvioEstadosCuentaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized 'MAXIMIZA PANTALLA'
        dtpFechaFin.Value = Date.Now
        dtpFechaInicio.Value = Date.Now
        DeshabilitarBotones()
        obtenerCorreodeFallos() '' se obtiene el correo de fallos cobranza@villagonti.com
    End Sub

    Private Sub DeshabilitarBotones()
        rdTodos.Checked = True
        rdporenviar.Checked = False
        rdEnviados.Checked = False
        btnEnviar.Enabled = False
        lblenviar.Enabled = False
        lblgeneracion.Enabled = False
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        consultarReporteEnviosEstadosCuenta()
    End Sub

    Private Sub consultarReporteEnviosEstadosCuenta()
        Dim objBU As New EstadosDeCuentaReporteBU
        Dim dtObtenerReporte As New DataTable
        Dim lstClientes As String = String.Empty
        Dim lstRazonSocial As String = String.Empty
        Dim estatus As Integer = 0

        Try
            grdEnvioEstadosCuenta.DataSource = Nothing
            vwEnvioEstadosCuenta.Columns.Clear()
            lstClientes = ObtenerFiltrosClientes(grdClientes)
            lstRazonSocial = ObtenerFiltrosRazonesSociales(grdRazonSocial)
            If rdEnviados.Checked = True Then ''enviados
                estatus = 1
                btnEnviar.Enabled = False
            Else
                If rdporenviar.Checked = True Then ''por enviar
                    estatus = 0
                    btnEnviar.Enabled = True
                Else
                    If rdTodos.Checked = True Then ''todos
                        estatus = 2
                        btnEnviar.Enabled = True
                    End If
                End If
            End If
            Cursor = Cursors.WaitCursor
            dtObtenerReporte = objBU.consultarReporteHistoricoEstadosCuenta(lstClientes, lstRazonSocial, estatus)
            If dtObtenerReporte.Rows.Count > 0 Then
                grdEnvioEstadosCuenta.DataSource = dtObtenerReporte
                diseñoGridEnvioEstadosdeCuenta(vwEnvioEstadosCuenta)
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay información para mostrar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al consultar el reporte.")
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnSeleccionarCliente_Click(sender As Object, e As EventArgs) Handles btnSeleccionarCliente.Click
        ObtenerClientes()
    End Sub

    Private Sub ObtenerClientes()
        Dim listado As New ListadoParametrosProyeccionCobranza
        Dim listaParametroID As New List(Of String)
        listado.tipo_busqueda = 1
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listaParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub
    Private Sub btnLimpiarCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarCliente.Click
        grdClientes.DataSource = listaInicial
    End Sub
    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub btnSeleccionarRazonSocial_Click(sender As Object, e As EventArgs) Handles btnSeleccionarRazonSocial.Click
        ConsultarRazonesSociales()
    End Sub

    Private Sub ConsultarRazonesSociales()
        Dim listado As New ListadoParametrosProyeccionCobranza
        Dim listaParametroID As New List(Of String)
        listado.tipo_busqueda = 2
        For Each row As UltraGridRow In grdRazonSocial.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdRazonSocial.DataSource = listado.listaParametros
        With grdRazonSocial
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Razón Social"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub grdRazonSocial_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRazonSocial.InitializeLayout
        grid_diseño(grdRazonSocial)
        grdRazonSocial.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Razón Social"
    End Sub

    Private Sub btnLimpiarRazonSocial_Click(sender As Object, e As EventArgs) Handles btnLimpiarRazonSocial.Click
        grdRazonSocial.DataSource = listaInicial
    End Sub

    Public Function ObtenerFiltrosClientes(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next
        Return Resultado
    End Function

    Public Function ObtenerFiltrosRazonesSociales(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next
        Return Resultado
    End Function

    Private Sub diseñoGridEnvioEstadosdeCuenta(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.IndicatorWidth = 30
        DiseñoGrid.AlternarColorEnFilas(vwEnvioEstadosCuenta)
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Fecha").DisplayFormat.FormatString = "{dd/MM/yyyy  HH: mm: ss}"
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Fecha").Width = 115
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Fecha").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Estado").Width = 50
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Estado").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Cliente").Width = 205
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Razón Social").Width = 215
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Razón Social").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("TipoDocumento").Width = 70
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("TipoDocumento").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Email").Width = 210
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Email").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Razón Fallo").Width = 150
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Razón Fallo").OptionsColumn.AllowEdit = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("Enviar").Width = 45
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("IdCliente").Visible = False
        vwEnvioEstadosCuenta.Columns.ColumnByFieldName("IdEmpresa").Visible = False
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwEnvioEstadosCuenta.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center ''centra los textos de los encabezados
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next
        vwEnvioEstadosCuenta.IndicatorWidth = 37
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFormulario()
    End Sub
    Private Sub limpiarFormulario()
        grdEnvioEstadosCuenta.DataSource = Nothing
        vwEnvioEstadosCuenta.Columns.Clear()
        dtpFechaInicio.Value = Date.Now.ToString
        dtpFechaFin.Value = Date.Now.ToString
        rdTodos.Checked = True
        grdRazonSocial.DataSource = Nothing
        grdClientes.DataSource = Nothing
        btnEnviar.Enabled = False
    End Sub

    ''' <summary>
    ''' deshabilita mensaje de confirmacion de fila en un ULTRAGRID
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub grdRazonSocial_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdRazonSocial.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub vwEnvioEstadosCuenta_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles vwEnvioEstadosCuenta.RowCellStyle
        Dim valorCelda As String
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Estado" Then
                valorCelda = vwEnvioEstadosCuenta.GetRowCellValue(e.RowHandle, "Estado").ToString
                If valorCelda.Equals("NO") Then
                    e.Appearance.BackColor = lblcorreoNoEnviado.BackColor
                    e.Appearance.ForeColor = Color.Transparent
                Else
                    e.Appearance.BackColor = lblcorreoEnviado.BackColor
                    e.Appearance.ForeColor = Color.Transparent
                End If
            End If
        End If
    End Sub

    Private Sub BtnGeneracionAutomatica_Click(sender As Object, e As EventArgs) Handles BtnGeneracionAutomatica.Click
        Dim GeneracionEstadosCuenta As New EstadosCuentaGeneracionManualForm
        GeneracionEstadosCuenta.ShowDialog()
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        enviarCorreosReportesEstadosdeCuenta()
    End Sub

    Private Sub enviarCorreosReportesEstadosdeCuenta()
        Dim lstCorreosEnviar As New List(Of Net.Mail.Attachment)
        Dim lstArchivosPDF As New List(Of String)
        Dim objMensaje As New Tools.ConfirmarForm
        If verificarEstadosSeleccionados() Then ''valida que se haya seleccionado al menos un registro
            objMensaje.mensaje = " ¿Está seguro(a) de enviar los estados de cuenta seleccionados?."
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                ConsultarReporteEstadosdeCuenta() '' consulta los estados de cuenta
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe de seleccionar al menos un registro.")
        End If
    End Sub

    Private Function verificarEstadosSeleccionados()
        Dim seleccion As Boolean
        Dim i As Integer = 0
        For i = 0 To vwEnvioEstadosCuenta.RowCount - 1
            If (vwEnvioEstadosCuenta.GetRowCellValue(vwEnvioEstadosCuenta.GetVisibleRowHandle(i), "Enviar")) = 0 Then
                seleccion = False
            Else
                seleccion = True
                Exit For
            End If
        Next
        Return seleccion
    End Function

    Private Sub ConsultarReporteEstadosdeCuenta()
        Dim enviarCorreo As Boolean = 0

        Try
            Cursor = Cursors.WaitCursor

            For index As Integer = 0 To vwEnvioEstadosCuenta.DataRowCount Step 1
                enviarCorreo = CBool(vwEnvioEstadosCuenta.GetRowCellValue(vwEnvioEstadosCuenta.GetVisibleRowHandle(index), "Enviar"))

                If enviarCorreo = True Then '' verifica que correos estan seleccionados para mandarlos
                    Dim objBU As New EstadosDeCuentaReporteBU
                    Dim tipoDocumento As String = String.Empty
                    Dim clienteId As Integer = 0
                    Dim empresaId As Integer = 0
                    Dim cliente As String = String.Empty
                    Dim tipo As Integer = 0

                    Dim dtReporte As New DataTable
                    Dim dtCuentasDeposito As New DataTable
                    Dim dtDatosCliente As New DataTable
                    Dim nombreArchivo As String = String.Empty
                    Dim errorEnviar As ErroresEnvio

                    tipoDocumento = vwEnvioEstadosCuenta.GetRowCellValue(vwEnvioEstadosCuenta.GetVisibleRowHandle(index), "TipoDocumento")
                    clienteId = vwEnvioEstadosCuenta.GetRowCellValue(vwEnvioEstadosCuenta.GetVisibleRowHandle(index), "IdCliente")
                    empresaId = vwEnvioEstadosCuenta.GetRowCellValue(vwEnvioEstadosCuenta.GetVisibleRowHandle(index), "IdEmpresa")
                    cliente = vwEnvioEstadosCuenta.GetRowCellValue(vwEnvioEstadosCuenta.GetVisibleRowHandle(index), "Cliente")

                    If tipoDocumento = "F" Then
                        tipo = EstadosCuentaGeneracionManualForm.CONSULTAR_FACTURAS ' tipo de documento "F"'
                    Else
                        tipo = EstadosCuentaGeneracionManualForm.CONSULTAR_REMISIONES 'tipo de documento "R"'
                    End If

                    dtReporte = objBU.consultarReporteEstadosReenviar(clienteId, empresaId, tipo) ''reporte facturas, remisiones
                    dtCuentasDeposito = objBU.consultaCuentasDepositosCobranza(empresaId, tipo) '' cuentas de deposito
                    dtDatosCliente = objBU.obtenerDatosClienteEstadosCuenta(clienteId, empresaId, tipoDocumento) '' datos de envio del cliente

                    ''Validar si se generará o no reporte
                    If dtReporte.Rows.Count > 0 Then
                        If dtDatosCliente.Rows(0).Item("destinos").ToString <> "" Then
                            nombreArchivo = generarFormatoEstadosdeCuenta(dtReporte, dtCuentasDeposito, dtDatosCliente, cliente, clienteId) '' genera el formato de los estados de cuenta

                            If nombreArchivo = "" Then
                                errorEnviar = ErroresEnvio.ErrorGenerarPDF

                            End If
                        Else
                            errorEnviar = ErroresEnvio.SinDestinoConfigurado

                        End If
                    Else
                        errorEnviar = ErroresEnvio.SinDocumentosCXC
                    End If
                    enviarCorreoEstadosdeCuenta(nombreArchivo, clienteId, empresaId, tipoDocumento, dtDatosCliente, errorEnviar)
                End If
            Next
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han enviado los correos.")
            consultarReporteEnviosEstadosCuenta()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function generarFormatoEstadosdeCuenta(ByVal tblReporte As DataTable, ByVal tblCuentasDeposito As DataTable, ByVal tblDatosCliente As DataTable,
                                              ByVal cliente As String, ByVal clienteId As Integer) As String

        Dim dsdatosReporte As New DataSet("dsEnvioEdoCta")
        Dim dtCuentasDeposito As New DataTable
        Dim dtEdoCta As New DataTable
        Dim rutaArchivo As String = String.Empty
        Dim nombreArchivo As String = String.Empty
        Dim strFecha As String = String.Empty

        Try
            rutaArchivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Cobranza\EstadosDeCuenta"

            If Not System.IO.Directory.Exists(rutaArchivo) Then ''verifica que exista ruta
                System.IO.Directory.CreateDirectory(rutaArchivo) '' crea directorio en C:
            End If

            Me.Cursor = Cursors.WaitCursor
            dtCuentasDeposito = tblCuentasDeposito
            dtEdoCta = tblReporte

            tblCuentasDeposito.TableName = "dtCuentasDeposito"
            tblReporte.TableName = "dtEdoCta"

            dsdatosReporte.Tables.Add(tblCuentasDeposito)
            dsdatosReporte.Tables.Add(tblReporte)

            Dim objConsultaReporteBU As New ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = objConsultaReporteBU.LeerReporteporClave("REPORTE_EDOCTA_COBRANZA")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                   EntidadReporte.Pnombre
            My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
            Dim reporteCobranza As New StiReport
            reporteCobranza.Load((archivo + ".mrt"))
            reporteCobranza.Compile()
            reporteCobranza("Cliente") = cliente
            reporteCobranza("fechaAnalisis") = DateTime.Now
            reporteCobranza("descuento") = CDbl(tblDatosCliente.Rows(0).Item("descuento"))
            reporteCobranza("diasplazo") = CInt(tblDatosCliente.Rows(0).Item("diasplazo"))
            reporteCobranza("referencia") = tblDatosCliente.Rows(0).Item("referencia").ToString
            reporteCobranza("convenio") = tblDatosCliente.Rows(0).Item("convenio").ToString
            reporteCobranza("urlImagen") = tblDatosCliente.Rows(0).Item("rutalogo").ToString
            reporteCobranza("mostrarcuentas") = CBool(tblDatosCliente.Rows(0).Item("mostrarcuentasdeposito").ToString)
            reporteCobranza.Dictionary.Clear()
            reporteCobranza.RegData(dsdatosReporte)
            reporteCobranza.Dictionary.Synchronize()
            reporteCobranza.Render()
            strFecha = (CStr(clienteId)) & "_" & Now.Year.ToString & Now.Month.ToString & Now.Day.ToString & "_" & Now.Hour.ToString & Now.Minute.ToString
            nombreArchivo = rutaArchivo + "\Estado de Cuenta " + strFecha + ".pdf"

            reporteCobranza.ExportDocument(StiExportFormat.Pdf, nombreArchivo)
            reporteCobranza.Dispose()

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            nombreArchivo = "" 'En caso de error devuelve cadena vacía
        Finally
            Me.Cursor = Cursors.Default
        End Try

        Return nombreArchivo
    End Function

    Private Sub enviarCorreoEstadosdeCuenta(ByVal nombreArchivoEnviar As String, ByVal clienteID As Integer, ByVal empresaId As Integer,
                                            ByVal tipoDocumento As String, ByVal dtDatosCliente As DataTable, ByVal errorNotificar As ErroresEnvio)
        Dim correoRemitente As String = String.Empty
        Dim CorreosDestinatariosCliente As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim enviarCorreo As New Entidades.DatosCorreo

        Dim archivoAdjunto As Net.Mail.Attachment
        Dim lstArchivoAdjuntos As New List(Of Net.Mail.Attachment)

        Dim mensajeCorreo As String = String.Empty
        Dim correo As New Tools.Correo

        Dim objBU As New EstadosDeCuentaReporteBU
        Dim dtInsertaMsgEstadoCta As New DataTable
        Dim envioMsg As String = String.Empty

        Dim otrosErrores As String = String.Empty
        Dim enviadoCliente As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor


            CorreosDestinatariosCliente = dtDatosCliente.Rows(0).Item("destinos").ToString

            If errorNotificar = ErroresEnvio.SinError Then
                asuntoCorreo = "Edo de Cuenta " & dtDatosCliente.Rows(0).Item("cliente").ToString & " al " & Date.Today.ToString("dd/MM/yyyy")
                correoRemitente = dtDatosCliente.Rows(0).Item("correo remitente").ToString
                enviarCorreo.Destinatarios = dtDatosCliente.Rows(0).Item("destinos").ToString 'CorreosDestinatariosCliente
            Else
                asuntoCorreo = "Error al enviar Edo de Cuenta " & dtDatosCliente.Rows(0).Item("cliente").ToString & " al " & Date.Today.ToString("dd/MM/yyyy")
                correoRemitente = dtDatosCliente.Rows(0).Item("correo remitente").ToString
                enviarCorreo.Destinatarios = destinosNotificaFallo  'ddesarrollo.ti@grupoyuyin.com.mx' 'destinosNotificaFallo '---> cobranza@villagonti.com
            End If

            enviarCorreo.From = correoRemitente
            enviarCorreo.Asunto = asuntoCorreo
            enviarCorreo.Mensaje = ObtenerMensajeCorreos(dtDatosCliente.Rows(0).Item("cliente").ToString, tipoDocumento, dtDatosCliente.Rows(0).Item("razonSocialEnvia").ToString, errorNotificar, "")

            If nombreArchivoEnviar <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(nombreArchivoEnviar)
                lstArchivoAdjuntos.Add(archivoAdjunto) 'adjunta el archivo a enviar'
            End If

            ''Realiza el envío del correo
            enviarCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(enviarCorreo.Destinatarios, enviarCorreo.From, enviarCorreo.Asunto, enviarCorreo.Mensaje, lstArchivoAdjuntos)

            ''Verifica si se insertará error en histórico de envío
            Select Case errorNotificar
                Case ErroresEnvio.SinError
                    enviadoCliente = enviarCorreo.CorreoEnviado
                    otrosErrores = enviarCorreo.DescripcionStatusCorreo
                Case ErroresEnvio.SinDocumentosCXC
                    otrosErrores = "EL CLIENTE NO TIENE DOCUMENTOS CON SALDO (CXC)."
                Case ErroresEnvio.SinDestinoConfigurado
                    otrosErrores = "EL CLIENTE NO TIENE CORREOS DE DESTINO CONFIGURADOS."
                Case ErroresEnvio.ErrorGenerarPDF
                    otrosErrores = "OCURRIÓ UN ERROR AL GENERAR EL PDF."
            End Select

            dtInsertaMsgEstadoCta = objBU.insertarRegistroHistoricoEstadosdeCuenta(clienteID, empresaId, tipoDocumento, enviadoCliente, CorreosDestinatariosCliente, otrosErrores)

            If enviarCorreo.CorreoEnviado = False And errorNotificar = ErroresEnvio.SinError Then
                enviarCorreo.Asunto = "Error al enviar correo de estado de cuenta."
                enviarCorreo.Mensaje = ObtenerMensajeCorreos(dtDatosCliente.Rows(0).Item("cliente").ToString, tipoDocumento, dtDatosCliente.Rows(0).Item("razonsocialenvia").ToString, ErroresEnvio.ErrorDeEnvio, enviarCorreo.DescripcionStatusCorreo)
                enviarCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(destinosNotificaFallo, "servicioselectronicos@grupoyuyin.com.mx", enviarCorreo.Asunto, enviarCorreo.Mensaje, lstArchivoAdjuntos)

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Function ObtenerMensajeCorreos(ByVal cliente As String, ByVal tipoDocumento As String, ByVal empresaEnvia As String, ByVal errorNotificar As ErroresEnvio, ByVal mensajeError As String)
        Dim Mensaje As String = ""
        Mensaje += "<!DOCTYPE html>"
        Mensaje += "<html> "
        Mensaje += "<head> "
        Mensaje += "<style type = '" + "text/css" + "'>"
        Mensaje += "body {display: block; margin: 8px; background: #FFFFFF;}"
        Mensaje += "#header{	position: absolute;"
        Mensaje += "height: 62px;"
        Mensaje += "top: 0;"
        Mensaje += "left: 0;"
        Mensaje += "right: 0;"
        Mensaje += "color: #002060;"
        Mensaje += "font-family: Calibri Light;"
        Mensaje += "font-size: 14px;}"
        Mensaje += "</style> "
        Mensaje += "</head> "
        Mensaje += "<body> "
        Mensaje += "<div id='" + "header" + "' >"


        If errorNotificar = ErroresEnvio.SinError Then
            Mensaje += "<p>Estimado Cliente.</p>"
            Mensaje += "<p>Reciba un cordial saludo"

            If tipoDocumento = "F" Then
                Mensaje += " de parte de Grupo Yuyin"
            End If

            Mensaje += "; anexo encontrará su Estado de Cuenta actualizado al " + Date.Today.ToString("dd/MM/yyyy")

            If tipoDocumento = "F" Then
                Mensaje += " de la empresa " + empresaEnvia
            End If

            Mensaje += "</p>"
            Mensaje += "<p>Si usted detecta alguna discrepancia en la información anexa (pagos no considerados) o facturas que no concuerden con su estado de cuenta, "
            Mensaje += "le pedimos que envíe su comprobante de pago y/o reporte estas diferencias a la brevedad posible, a los siguientes correos: cobranza@villagonti.com y acobranza@villagonti.com, "
            Mensaje += "o comunicarse al teléfono <b>477 808 12 97</b> con nuestro departamento de Crédito y Cobranza.</p>"

            Mensaje += "<p>De antemano le agradecemos la atención a la presente, le enviamos un afectuoso saludo y quedamos a sus órdenes para cualquier duda o aclaración.</p>"

        Else
            Mensaje += "<p><i>Confirmación de error en envío de estado de cuenta: </i></p>"

            Select Case errorNotificar
                Case ErroresEnvio.SinDocumentosCXC
                    Mensaje += "<p>No se encontró información de cuentas por cobrar del cliente " + cliente + " para la fecha de corte del " + Date.Today.ToString("dd/MM/yyyy") + "</p>"
                    Mensaje += "<p>Verifique esta información y en caso de cualquier duda comunicarse al departamento de sistemas.</p>"
                Case ErroresEnvio.SinDestinoConfigurado
                    Mensaje += "<p>No se encontró información de destinatarios configurada para el cliente " + cliente + ".</p>"
                    Mensaje += "<p>Verifique esta información y en caso de cualquier duda comunicarse al departamento de sistemas.</p>"
                Case ErroresEnvio.ErrorGenerarPDF
                    Mensaje += "<p>Ocurrió un error al generar el PDF del estado de cuenta de cliente " + cliente + ", si es necesario intente el envío nuevamente.</p>"
                    Mensaje += "<p>Si el error persiste, favor de comunicarse al departamento de sistemas.</p>"
                Case ErroresEnvio.ErrorDeEnvio
                    Mensaje += "<p>Ocurrió un error al enviar el correo del estado de cuenta del cliente " + cliente + " para la fecha de corte del " + Date.Today.ToString("dd/MM/yyyy") + ".</p>"
                    Mensaje += "<p>Error: " + mensajeError + "</p>"
                    Mensaje += "<p>Si es necesario intente el envío nuevamente.</p>"
                    Mensaje += "<p>Si el error persiste, favor de comunicarse al departamento de sistemas.</p>"
            End Select
        End If

        Mensaje += "</div>"
        Mensaje += "</body> "
        Mensaje += "</html> "

        Return Mensaje
    End Function

    Private Sub obtenerCorreodeFallos()
        Dim objObtenerCorreo As New EstadosDeCuentaReporteBU
        Dim dtCorreoFallido As New DataTable
        dtCorreoFallido = objObtenerCorreo.ObtenerCorreoEnvioFallos("ERROR_ENVIO_ESTADO_CUENTA_COBRANZA")
        destinosNotificaFallo = dtCorreoFallido.Rows(0).Item("correo").ToString
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Cobranza/", "Descargas\Manuales\Ventas", "COVE_MAUS_Envío_EstadosCuenta_V3.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Envío_EstadosCuenta_V3.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlAcciones.Height = 32
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlAcciones.Height = 207
    End Sub
    Private Sub vwEnvioEstadosCuenta_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwEnvioEstadosCuenta.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class