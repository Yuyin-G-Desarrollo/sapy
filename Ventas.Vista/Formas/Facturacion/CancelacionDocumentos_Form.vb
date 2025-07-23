Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class CancelacionDocumentos_Form

#Region "VARIABLES GLOBALES"

    Public ClienteId As Integer = 0
    Public DocumentoId As Integer = 0

    Public UltimoDocumentoCancelado As Integer = 0
    Public UltimoClienteCancelado As Integer = 0
    Public UltimoSolicitanteCancelacion As String = ""
    Public UltimoMotivoCancelacionSeleccionado As Integer = 0
    Public UltimoRFCCancelacionSeleccionado As Integer = 0
    Public UltimaObservacionCancelacionSeleccionada As String = ""
    Public UltimoUsoCancelacionSeleccionado As String = ""
    Public UltimaOpcionSustitucionSeleccionada As Integer = 0
    Public VentanaAdministradorDocumentos As AdministradorFacturacion_Form
    Public EntDocumentoACancelar As New Entidades.FacturaCancelada
    Dim objBU As New Negocios.CancelacionDocumentosBU
    Dim dtDatosDocumentoCancelar As New DataTable
    Dim dtCFDIRelacionados As DataTable
    Dim DocumentoCancelable As String = String.Empty
    Dim ValorCelda As String = String.Empty
    Dim RequiereAutorizacion As Boolean = False
    Dim dtRelacionMotivoCancelacion As DataTable
    Dim dtRelacionMotivoCancelacionSolicitud As DataTable

    Public ConSolicitud As Int16 = 0
    Public Solicita As String = String.Empty
    Public ConRelacion As Boolean = False
    Public FolioSustitucion As String = ""
    Dim dtSolicitudDocumentoCancelar As New DataTable

    Public Observacion As String = String.Empty
#End Region

#Region "CARGA DE DATOS"

    Public Sub AsignarValorRadioButton()
        If ConRelacion = True Then
            rdbConRelacion.Checked = True
            rdbSinRelacion.Checked = False
            txtFolioSustitucion.Visible = True
            txtFolioSustitucion.Enabled = False
            txtFolioSustitucion.Text = FolioSustitucion
        Else
            rdbConRelacion.Checked = False
            rdbSinRelacion.Checked = True
            txtFolioSustitucion.Visible = False
        End If
    End Sub

    Private Sub CancelacionDocumentos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Cursor = Cursors.WaitCursor
            If ConSolicitud = 1 Then
                AsignarValorRadioButton()

                txtObservaciones.Enabled = False
                cmboxMotivoCancelacion.Enabled = False

                txtSolicita.Text = Solicita
                txtSolicita.Enabled = False
                Label49.Visible = False
                txtObservaciones.Text = Observacion
                dtDatosDocumentoCancelar = objBU.consultaInformacionDocumentoCancelar(ClienteId, DocumentoId)
                dtSolicitudDocumentoCancelar = objBU.ConsultarSolicitud(DocumentoId)
                dtRelacionMotivoCancelacionSolicitud = objBU.ObtenerRelacionaCFDISegunMotivoCancelacionSolicitud(DocumentoId)

                lblNombreCliente.Text = dtDatosDocumentoCancelar.Rows(0).Item("Cliente")
                lblRFCReceptor.Text = dtDatosDocumentoCancelar.Rows(0).Item("RFC")
                lblRazonSocial.Text = dtDatosDocumentoCancelar.Rows(0).Item("RFC_Nombre")
                lblRegimenFiscal.Text = dtDatosDocumentoCancelar.Rows(0).Item("RegimenFiscal")
                lblTipoDocumento.Text = dtDatosDocumentoCancelar.Rows(0).Item("TipoDocumento")
                DocumentoCancelable = IIf(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("DocumentoCancelable")), "", (dtDatosDocumentoCancelar.Rows(0).Item("DocumentoCancelable")).ToString.Trim)
                If DocumentoCancelable = "DOCUMENTO NO CANCELABLE" Then
                    lblDNCTitulo.Visible = True
                    lblDNCTexto.Visible = True
                    dtCFDIRelacionados = objBU.consultaFacturaDocumentosRelacionados(DocumentoId)
                    If Not IsNothing(dtCFDIRelacionados) Then
                        If dtCFDIRelacionados.Rows.Count > 0 Then
                            grdCfdiRelacionados.DataSource = dtCFDIRelacionados
                            DiseñoGrid.DiseñoBaseGrid(grdVCfdiRelacionados)
                        End If
                    End If
                    btnGuardar.Enabled = False
                Else
                    lblDNCTitulo.Visible = True
                    lblDNCTitulo.Text = "DOCUMENTO CANCELABLE"
                    lblDNCTitulo.ForeColor = Color.Green

                    dtCFDIRelacionados = objBU.consultaFacturaDocumentosRelacionados(DocumentoId)
                    If Not IsNothing(dtCFDIRelacionados) Then
                        If dtCFDIRelacionados.Rows.Count > 0 Then
                            grdCfdiRelacionados.DataSource = dtCFDIRelacionados
                            DiseñoGrid.DiseñoBaseGrid(grdVCfdiRelacionados)
                        End If
                    End If

                End If
                If lblTipoDocumento.Text = "FACTURA" Then
                    lblTipoDocumento.ForeColor = Color.Green
                Else
                    lblTipoDocumento.ForeColor = Color.Purple
                End If
                lblIdRemision.Text = dtDatosDocumentoCancelar.Rows(0).Item("Documento")
                lblFolioFactura.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("Folio")), "", dtDatosDocumentoCancelar.Rows(0).Item("Folio"))
                lblAño.Text = dtDatosDocumentoCancelar.Rows(0).Item("Año")
                lblFechaCaptura.Text = dtDatosDocumentoCancelar.Rows(0).Item("Fecha")
                lblUUID.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("UUID")), "", dtDatosDocumentoCancelar.Rows(0).Item("UUID"))
                lblTotalPares.Text = dtDatosDocumentoCancelar.Rows(0).Item("Pares")
                lblMonto.Text = Double.Parse(dtDatosDocumentoCancelar.Rows(0).Item("Monto")).ToString("n2")
                lblEmisor.Text = dtDatosDocumentoCancelar.Rows(0).Item("Emisor")
                lblUbicacionProducto.Text = dtDatosDocumentoCancelar.Rows(0).Item("Producto")
                If lblUbicacionProducto.Text = "EN ALMACÉN" Then
                    lblUbicacionProducto.ForeColor = Color.Green
                Else
                    lblUbicacionProducto.ForeColor = Color.Red
                End If
                lblRestriccionFacturacion.Text = dtDatosDocumentoCancelar.Rows(0).Item("RestriccionDocumento")
                lblMontoMaximoFacturacion.Text = Double.Parse(dtDatosDocumentoCancelar.Rows(0).Item("MaximoPorFacturarDocumento")).ToString("n2")
                lblMarcasFacturar.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcasDocumento")), "", dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcasDocumento"))
                ''PENDIENTE DE REVIZAR
                'rdbSiRequiereAutorizacionCliente.Checked = If(dtDatosDocumentoCancelar.Rows(0).Item("RequiereAutorizacionCliente") = 0, False, True)
                rdbNoRequiereAutorizacionCliente.Checked = 0 ''If(dtDatosDocumentoCancelar.Rows(0).Item("RequiereAutorizacionCliente") = 0, True, False) se quita ya que es una respuesta del say 
                lblRestriccionFacturacionActual.Text = dtDatosDocumentoCancelar.Rows(0).Item("RestriccionActual")
                lblMontoMaximoFacturacionActual.Text = Double.Parse(dtDatosDocumentoCancelar.Rows(0).Item("MontoMaximoFacturaActual")).ToString("n2")
                lblMarcasFacturarActual.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcaActual")), "", dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcaActual"))
                lblUsoCFDI.Text = dtDatosDocumentoCancelar.Rows(0).Item("UsoCFDI")
                ''Estas lineas se comentan ya que al enviar la solicitud al sat no dice si RequiereAutorizacion del cliente
                'RequiereAutorizacion = CBool(dtDatosDocumentoCancelar.Rows(0).Item("RequiereAutorizacionCliente"))
                'If RequiereAutorizacion Then
                '    rdbSIGenerarSustitucionInmediata.Checked = False
                '    rdbNoGenerarSustitucionInmediata.Checked = True
                '    rdbSIGenerarSustitucionInmediata.Enabled = False
                '    rdbNoGenerarSustitucionInmediata.Enabled = False
                'End If

                CargarMotivosCancelacion()
                cmboxMotivoCancelacion.SelectedItem = 0
                ''cmboxMotivoCancelacion.SelectedValue = 0
                CargarUsosPorDocumento()
                'cmbUsoCFDI.SelectedValue = 0

            Else ''CUANDO NO VIENE CON SOLICITUD
                dtDatosDocumentoCancelar = objBU.consultaInformacionDocumentoCancelar(ClienteId, DocumentoId)
                dtRelacionMotivoCancelacion = objBU.ObtenerRelacionaCFDISegunMotivoCancelacion
                dtRelacionMotivoCancelacionSolicitud = objBU.ObtenerRelacionaCFDISegunMotivoCancelacionSolicitud(DocumentoId)
                lblNombreCliente.Text = dtDatosDocumentoCancelar.Rows(0).Item("Cliente")
                lblRFCReceptor.Text = dtDatosDocumentoCancelar.Rows(0).Item("RFC")
                lblRazonSocial.Text = dtDatosDocumentoCancelar.Rows(0).Item("RFC_Nombre")
                lblRegimenFiscal.Text = dtDatosDocumentoCancelar.Rows(0).Item("RegimenFiscal")
                lblTipoDocumento.Text = dtDatosDocumentoCancelar.Rows(0).Item("TipoDocumento")
                DocumentoCancelable = IIf(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("DocumentoCancelable")), "", (dtDatosDocumentoCancelar.Rows(0).Item("DocumentoCancelable")).ToString.Trim)
                If DocumentoCancelable = "DOCUMENTO NO CANCELABLE" Then
                    lblDNCTitulo.Visible = True
                    lblDNCTexto.Visible = True
                    dtCFDIRelacionados = objBU.consultaFacturaDocumentosRelacionados(DocumentoId)
                    If Not IsNothing(dtCFDIRelacionados) Then
                        If dtCFDIRelacionados.Rows.Count > 0 Then
                            grdCfdiRelacionados.DataSource = dtCFDIRelacionados
                            DiseñoGrid.DiseñoBaseGrid(grdVCfdiRelacionados)
                        End If
                    End If
                    btnGuardar.Enabled = False
                Else
                    lblDNCTitulo.Visible = True
                    lblDNCTitulo.Text = "DOCUMENTO CANCELABLE"
                    lblDNCTitulo.ForeColor = Color.Green

                    dtCFDIRelacionados = objBU.consultaFacturaDocumentosRelacionados(DocumentoId)
                    If Not IsNothing(dtCFDIRelacionados) Then
                        If dtCFDIRelacionados.Rows.Count > 0 Then
                            grdCfdiRelacionados.DataSource = dtCFDIRelacionados
                            DiseñoGrid.DiseñoBaseGrid(grdVCfdiRelacionados)
                        End If
                    End If

                End If
                If lblTipoDocumento.Text = "FACTURA" Then
                    lblTipoDocumento.ForeColor = Color.Green
                Else
                    lblTipoDocumento.ForeColor = Color.Purple
                End If
                lblIdRemision.Text = dtDatosDocumentoCancelar.Rows(0).Item("Documento")
                lblFolioFactura.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("Folio")), "", dtDatosDocumentoCancelar.Rows(0).Item("Folio"))
                lblAño.Text = dtDatosDocumentoCancelar.Rows(0).Item("Año")
                lblFechaCaptura.Text = dtDatosDocumentoCancelar.Rows(0).Item("Fecha")
                lblUUID.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("UUID")), "", dtDatosDocumentoCancelar.Rows(0).Item("UUID"))
                lblTotalPares.Text = dtDatosDocumentoCancelar.Rows(0).Item("Pares")
                lblMonto.Text = Double.Parse(dtDatosDocumentoCancelar.Rows(0).Item("Monto")).ToString("n2")
                lblEmisor.Text = dtDatosDocumentoCancelar.Rows(0).Item("Emisor")
                lblUbicacionProducto.Text = dtDatosDocumentoCancelar.Rows(0).Item("Producto")
                If lblUbicacionProducto.Text = "EN ALMACÉN" Then
                    lblUbicacionProducto.ForeColor = Color.Green
                Else
                    lblUbicacionProducto.ForeColor = Color.Red
                End If
                lblRestriccionFacturacion.Text = dtDatosDocumentoCancelar.Rows(0).Item("RestriccionDocumento")
                lblMontoMaximoFacturacion.Text = Double.Parse(dtDatosDocumentoCancelar.Rows(0).Item("MaximoPorFacturarDocumento")).ToString("n2")
                lblMarcasFacturar.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcasDocumento")), "", dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcasDocumento"))
                rdbSiRequiereAutorizacionCliente.Checked = If(dtDatosDocumentoCancelar.Rows(0).Item("RequiereAutorizacionCliente") = 0, False, True)
                rdbNoRequiereAutorizacionCliente.Checked = 0 ''If(dtDatosDocumentoCancelar.Rows(0).Item("RequiereAutorizacionCliente") = 0, True, False)
                lblRestriccionFacturacionActual.Text = dtDatosDocumentoCancelar.Rows(0).Item("RestriccionActual")
                lblMontoMaximoFacturacionActual.Text = Double.Parse(dtDatosDocumentoCancelar.Rows(0).Item("MontoMaximoFacturaActual")).ToString("n2")
                lblMarcasFacturarActual.Text = If(IsDBNull(dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcaActual")), "", dtDatosDocumentoCancelar.Rows(0).Item("FacturarPorMarcaActual"))
                lblUsoCFDI.Text = dtDatosDocumentoCancelar.Rows(0).Item("UsoCFDI")
                'RequiereAutorizacion = CBool(dtDatosDocumentoCancelar.Rows(0).Item("RequiereAutorizacionCliente")) ''ESTO SE DEFINE EN LA RESPUESTA DEL SAT
                'If RequiereAutorizacion Then
                '    rdbSIGenerarSustitucionInmediata.Checked = False
                '    rdbNoGenerarSustitucionInmediata.Checked = True
                '    rdbSIGenerarSustitucionInmediata.Enabled = False
                '    rdbNoGenerarSustitucionInmediata.Enabled = False
                'End If

                CargarMotivosCancelacion()
                cmboxMotivoCancelacion.SelectedValue = 0
                CargarUsosPorDocumento()
                'cmbUsoCFDI.SelectedValue = 0

                If UltimoDocumentoCancelado <> 0 Then
                    cmboxMotivoCancelacion.SelectedValue = UltimoMotivoCancelacionSeleccionado
                    txtSolicita.Text = UltimoSolicitanteCancelacion
                    txtObservaciones.Text = UltimaObservacionCancelacionSeleccionada
                    'rdbSIGenerarSustitucionInmediata.Checked = If(UltimaOpcionSustitucionSeleccionada = 1, True, False)
                    'rdbNoGenerarSustitucionInmediata.Checked = If(UltimaOpcionSustitucionSeleccionada = 0, True, False)

                    If UltimoRFCCancelacionSeleccionado > 0 Then
                        ' cmbRFCNuevoDocumento.Visible = True
                        'rdbSIGenerarSustitucionInmediata.Checked = True
                        'cmbRFCNuevoDocumento.SelectedValue = UltimoRFCCancelacionSeleccionado
                    End If

                    If UltimoUsoCancelacionSeleccionado <> "" Then
                        ' cmbUsoCFDI.Visible = True
                        'rdbSIGenerarSustitucionInmediata.Checked = True
                        ' cmbUsoCFDI.SelectedValue = UltimoUsoCancelacionSeleccionado
                    End If

                End If

            End If


        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarMotivosCancelacion()
        Dim dtMotivos As DataTable
        If ConSolicitud = 1 Then
            dtMotivos = objBU.ObtenerRelacionaCFDISegunMotivoCancelacionSolicitud(DocumentoId)
            cmboxMotivoCancelacion.DataSource = dtMotivos
            cmboxMotivoCancelacion.DisplayMember = "nombre"
            cmboxMotivoCancelacion.ValueMember = "EstatusID"
        Else
            'dtMotivos = objBU.consultaMotivosCancelacion(If(lblTipoDocumento.Text = "FACTURA", "F", "R"), If(lblUUID.Text = "", 0, 1), lblUbicacionProducto.Text)
            dtMotivos = objBU.consultaMotivosCancelacion(lblTipoDocumento.Text, If(lblUUID.Text = "", 0, 1), lblUbicacionProducto.Text, ClienteId)
            dtMotivos.Rows.InsertAt(dtMotivos.NewRow, 0)
            cmboxMotivoCancelacion.DataSource = dtMotivos
            cmboxMotivoCancelacion.DisplayMember = "motivo"
            cmboxMotivoCancelacion.ValueMember = "id"
        End If




    End Sub

    Private Sub CargarRFCClienteMotivo()
        Dim dtRFC As DataTable
        dtRFC = objBU.consultarRFCPorDocumentoMotivo(ClienteId, If(lblTipoDocumento.Text = "FACTURA", "F", "R"), cmboxMotivoCancelacion.SelectedValue)
        dtRFC.Rows.InsertAt(dtRFC.NewRow, 0)
        'cmbRFCNuevoDocumento.DataSource = dtRFC
        'cmbRFCNuevoDocumento.DisplayMember = "RazonSocial"
        'cmbRFCNuevoDocumento.ValueMember = "ClienteRFCID"
    End Sub

    Private Sub CargarUsosPorDocumento()
        Dim dtUsos As DataTable
        dtUsos = objBU.consultarUsosPorDocumento(DocumentoId)
        dtUsos.Rows.InsertAt(dtUsos.NewRow, 0)
        'cmbUsoCFDI.DataSource = dtUsos
        'cmbUsoCFDI.DisplayMember = "UsoDescripcion"
        'cmbUsoCFDI.ValueMember = "ClaveUso"
    End Sub

    Public Sub cargarConsideracionesMotivo()
        Dim dtConsideraciones As New DataTable()
        dtConsideraciones = objBU.consultarConsideracionesPorMotivo(cmboxMotivoCancelacion.SelectedValue)
        txtConsideraciones.Text = Replace(dtConsideraciones.Rows(0).Item("esta_descripcion"), "'", "")
    End Sub

    Private Sub cmboxMotivoCancelacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxMotivoCancelacion.SelectedIndexChanged
        If cmboxMotivoCancelacion.SelectedIndex > 0 Then
            ObtenerSeleccionRelacionCDIFMotivoCancelacion(cmboxMotivoCancelacion.SelectedValue)

            cargarConsideracionesMotivo()
            If cmboxMotivoCancelacion.SelectedValue = 144 Or cmboxMotivoCancelacion.SelectedValue = 146 Or cmboxMotivoCancelacion.SelectedValue = 150 Then
                'lblTextoUsoCFDI.Visible = False
                'cmbUsoCFDI.Visible = False
                'cmbUsoCFDI.SelectedIndex = 0
                'If rdbNoGenerarSustitucionInmediata.Checked = False Then
                '    lblRFCNuevaFactura.Visible = True
                '    cmbRFCNuevoDocumento.Visible = True
                'End If
                CargarRFCClienteMotivo()

                'If Not RequiereAutorizacion Then
                '    rdbSIGenerarSustitucionInmediata.Enabled = True
                '    rdbNoGenerarSustitucionInmediata.Enabled = True
                'End If


            End If
            If cmboxMotivoCancelacion.SelectedValue = 147 Or cmboxMotivoCancelacion.SelectedValue = 145 Then
                'lblTextoUsoCFDI.Visible = False
                'cmbUsoCFDI.Visible = False
                'cmbUsoCFDI.SelectedIndex = 0
                'lblRFCNuevaFactura.Visible = False
                'cmbRFCNuevoDocumento.Visible = False
                'cmbRFCNuevoDocumento.SelectedIndex = -1
                'If Not RequiereAutorizacion Then
                '    rdbNoGenerarSustitucionInmediata.Checked = True
                '    rdbSIGenerarSustitucionInmediata.Enabled = False
                '    rdbNoGenerarSustitucionInmediata.Enabled = False
                'End If
            End If
            If cmboxMotivoCancelacion.SelectedValue = 148 Then
                'If rdbNoGenerarSustitucionInmediata.Checked = False Then
                '    lblTextoUsoCFDI.Visible = True
                '    cmbUsoCFDI.Visible = True
                'End If
                'lblRFCNuevaFactura.Visible = False
                'cmbRFCNuevoDocumento.Visible = False
                'cmbRFCNuevoDocumento.SelectedIndex = -1

                'If Not RequiereAutorizacion Then
                '    rdbSIGenerarSustitucionInmediata.Enabled = True
                '    rdbNoGenerarSustitucionInmediata.Enabled = True
                'End If
            End If
            ' If cmboxMotivoCancelacion.SelectedValue = 149 Or cmboxMotivoCancelacion.SelectedValue = 145 Then
            If cmboxMotivoCancelacion.SelectedValue = 149 Then
                'lblTextoUsoCFDI.Visible = False
                'cmbUsoCFDI.Visible = False
                'cmbUsoCFDI.SelectedIndex = 0
                'lblRFCNuevaFactura.Visible = False
                'cmbRFCNuevoDocumento.Visible = False
                'cmbRFCNuevoDocumento.SelectedIndex = -1
                'If Not RequiereAutorizacion Then
                '    rdbSIGenerarSustitucionInmediata.Enabled = True
                '    rdbNoGenerarSustitucionInmediata.Enabled = True
                'End If
            End If
        Else
            ObtenerSeleccionRelacionCDIFMotivoCancelacion(0)
        End If
    End Sub

#End Region

#Region "CANCELACIÓN"

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub CancelarDocumentoSinRelacion(DocumentoCancelar As Entidades.CancelacionDocumento, entDatosFactura As Entidades.DatosFactura)

        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim RutaPDFFactura As String = String.Empty
        Dim tipoCancelacion As String = dtSolicitudDocumentoCancelar.Rows(0).Item("ClaveSat") ''01: con relacion 02: sin relacion 03: no se llevo acabo la operacion
        Dim entFactura As New Entidades.DatosFactura

        If txtSolicita.Text <> "" And cmboxMotivoCancelacion.SelectedIndex >= 0 And txtObservaciones.Text <> "" Then
            DocumentoCancelar.DocumentoID = DocumentoId
            DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            DocumentoCancelar.Solicita = txtSolicita.Text
            DocumentoCancelar.MotivoID = cmboxMotivoCancelacion.SelectedValue
            DocumentoCancelar.Observaciones = txtObservaciones.Text
            DocumentoCancelar.SustitucionInmediata = 0 'If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)
            ''DocumentoCancelar.RequiereAutorizacionCliente = If(rdbSiRequiereAutorizacionCliente.Checked, 1, 0)
            'DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
            DocumentoCancelar.UsoCFDIID = "" ''If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
            DocumentoCancelar.ProductoAlCancelar = lblUbicacionProducto.Text

            Dim confirmacion As New Tools.ConfirmarForm
            confirmacion.mensaje = "¿Está seguro de cancelar este documento?"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor
                    'entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

                    btnGuardar.Enabled = False
                    lblGuardar.Enabled = False

                    If entDatosFactura.TipoComprobante = "F" Then
                        If EntDocumentoACancelar.EstatusID = 157 Or EntDocumentoACancelar.EstatusID = 167 Then
                            dtRespuestaCancelacionTimbrada = EnviarSolicitudCancelarSat(DocumentoCancelar, tipoCancelacion)

                            If dtRespuestaCancelacionTimbrada.Rows.Count > 0 Then
                                Dim estatus As String = dtRespuestaCancelacionTimbrada.Rows(0).Item("Mensaje")
                                Dim resultado As Int16 = dtRespuestaCancelacionTimbrada.Rows(0).Item("Resultado")
                                If resultado = 1 Then
                                    If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("107") = True Then
                                        DocumentoCancelar.RequiereAutorizacionCliente = 0
                                        ''cancelar say y sicy  regresar pares ot a por refacturar
                                        CancelarFacturaSaySicy(DocumentoCancelar)
                                        ''actualizar status de la solicitud 
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 472)

                                        If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoId, "FACTURACALZADO") = True Then
                                            RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoId)
                                            AbrirPDFFactura(RutaPDFFactura)
                                        End If
                                        objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
                                        entFactura = objBUTimbrado.ConsultarRutasDocumento(DocumentoId)
                                        show_message("Exito", "Documento cancelado correctamente")
                                        Return
                                    End If
                                Else

                                    If estatus.Contains("104") = True Or estatus.Contains("105") = True Or estatus.Contains("106") = True Then ''documento pendiente de aceptacion
                                        DocumentoCancelar.RequiereAutorizacionCliente = 1 'EL DOCUMENTO DE STATUS A 191 -CANCELADA (ESPERA ACEPTACION)-
                                        objBU.cancelarDocumento(DocumentoCancelar) ''actualiza el documento a 191 e inserta en TBL_FacturacionCalzadoDocumento_Cancelacion
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 473) '' espera de aceptacion
                                        show_message("Aviso", "Documento en espera de aceptacion")
                                        Return
                                    Else
                                        ''ACTUALIZAR LA SOLICITUD A FALTA SAT 
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 485) '' FALTA SAT
                                        '' INSERTAR EN LA TABLA DE TBL_FacturacionCalzadoDocumento_Cancelacion
                                        InsertaCancelacion(DocumentoCancelar)
                                        show_message("Error", estatus)
                                        Return
                                    End If
                                End If

                            Else
                                ''ACTUALIZAR LA SOLICITUD A FALTA SAT 
                                ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 485) '' FALTA SAT
                                '' INSERTAR EN LA TABLA DE TBL_FacturacionCalzadoDocumento_Cancelacion
                                InsertaCancelacion(DocumentoCancelar)
                                show_message("Error", "Ocurrio un error al cancelar")
                                Return
                            End If

                        Else
                            objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
                            show_message("Exito", "Documento cancelado correctamente")
                        End If
                    End If

                Catch ex As Exception
                    show_message("Error", "Ocurrio un error al cancelar, intente de nuevo")
                End Try



            End If

        Else
            show_message("Advertencia", "Faltan datos por capturar, verifique por favor.")
        End If

    End Sub

    Public Sub CancelarDocumentoConRelacion(DocumentoCancelar As Entidades.CancelacionDocumento, entDatosFactura As Entidades.DatosFactura)

        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim RutaPDFFactura As String = String.Empty
        Dim tipoCancelacion As String = dtSolicitudDocumentoCancelar.Rows(0).Item("ClaveSat") ''01: con relacion 02: sin relacion 03: no se llevo acabo la operacion
        Dim entFactura As New Entidades.DatosFactura

        If txtSolicita.Text <> "" And cmboxMotivoCancelacion.SelectedIndex >= 0 And cmboxMotivoCancelacion.SelectedIndex >= 0 And txtObservaciones.Text <> "" Then
            DocumentoCancelar.DocumentoID = DocumentoId
            DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            DocumentoCancelar.Solicita = txtSolicita.Text
            DocumentoCancelar.MotivoID = cmboxMotivoCancelacion.SelectedValue
            DocumentoCancelar.Observaciones = txtObservaciones.Text
            DocumentoCancelar.SustitucionInmediata = 0 'If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)
            ''DocumentoCancelar.RequiereAutorizacionCliente = If(rdbSiRequiereAutorizacionCliente.Checked, 1, 0)
            'DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
            DocumentoCancelar.UsoCFDIID = "" ''If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
            DocumentoCancelar.ProductoAlCancelar = lblUbicacionProducto.Text


            Dim confirmacion As New Tools.ConfirmarForm
            confirmacion.mensaje = "¿Está seguro de cancelar este documento?"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor
                    'entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

                    btnGuardar.Enabled = False
                    lblGuardar.Enabled = False
                    If entDatosFactura.TipoComprobante = "F" Then
                        If EntDocumentoACancelar.EstatusID = 157 Or EntDocumentoACancelar.EstatusID = 167 Then
                            dtRespuestaCancelacionTimbrada = EnviarSolicitudCancelarSat(DocumentoCancelar, tipoCancelacion)

                            If dtRespuestaCancelacionTimbrada.Rows.Count > 0 Then
                                Dim estatus As String = dtRespuestaCancelacionTimbrada.Rows(0).Item("Mensaje")
                                Dim resultado As Int16 = dtRespuestaCancelacionTimbrada.Rows(0).Item("Resultado")

                                If resultado = 1 Then
                                    If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("107") = True Then
                                        DocumentoCancelar.RequiereAutorizacionCliente = 0
                                        ''cancelar say y sicy  regresar pares ot a por refacturar
                                        CancelarFacturaSaySicy(DocumentoCancelar)
                                        ''actualizar status de la solicitud 
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 472)

                                        If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoId, "FACTURACALZADO") = True Then
                                            RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoId)
                                            AbrirPDFFactura(RutaPDFFactura)
                                        End If
                                        objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
                                        entFactura = objBUTimbrado.ConsultarRutasDocumento(DocumentoId)
                                        show_message("Exito", "Documento cancelado correctamente")
                                    End If
                                Else

                                    If estatus.Contains("104") = True Or estatus.Contains("105") = True Or estatus.Contains("106") = True Then ''documento pendiente de aceptacion
                                        DocumentoCancelar.RequiereAutorizacionCliente = 1 'EL DOCUMENTO DE STATUS A 191 -CANCELADA (ESPERA ACEPTACION)-
                                        objBU.cancelarDocumento(DocumentoCancelar) ''actualiza el documento a 191 e inserta en TBL_FacturacionCalzadoDocumento_Cancelacion
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 473) '' espera de aceptacion
                                        show_message("Aviso", "Documento en espera de aceptacion")
                                    Else
                                        ''ACTUALIZAR LA SOLICITUD A FALTA SAT 
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 485) '' FALTA SAT
                                        '' INSERTAR EN LA TABLA DE TBL_FacturacionCalzadoDocumento_Cancelacion
                                        InsertaCancelacion(DocumentoCancelar)
                                        show_message("Error", estatus)
                                    End If
                                End If

                            Else
                                ''ACTUALIZAR LA SOLICITUD A FALTA SAT 
                                ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 485) '' FALTA SAT
                                '' INSERTAR EN LA TABLA DE TBL_FacturacionCalzadoDocumento_Cancelacion
                                InsertaCancelacion(DocumentoCancelar)
                                show_message("Error", "Ocurrio un error al cancelar")
                            End If

                        Else
                            objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
                            show_message("Exito", "Documento cancelado correctamente")
                        End If

                    End If
            Catch ex As Exception

            End Try
        End If

        Else
        show_message("Advertencia", "Faltan datos por capturar, verifique por favor.")
        End If
    End Sub

    Public Sub CancelarDocumentoOperacion(DocumentoCancelar As Entidades.CancelacionDocumento, entDatosFactura As Entidades.DatosFactura)

        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim RutaPDFFactura As String = String.Empty
        Dim tipoCancelacion As String = dtSolicitudDocumentoCancelar.Rows(0).Item("ClaveSat") ''01: con relacion 02: sin relacion 03: no se llevo acabo la operacion
        Dim entFactura As New Entidades.DatosFactura

        If txtSolicita.Text <> "" And cmboxMotivoCancelacion.SelectedIndex >= 0 And cmboxMotivoCancelacion.SelectedIndex >= 0 And txtObservaciones.Text <> "" Then
            DocumentoCancelar.DocumentoID = DocumentoId
            DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            DocumentoCancelar.Solicita = txtSolicita.Text
            DocumentoCancelar.MotivoID = cmboxMotivoCancelacion.SelectedValue
            DocumentoCancelar.Observaciones = txtObservaciones.Text
            DocumentoCancelar.SustitucionInmediata = 0 'If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)
            ''DocumentoCancelar.RequiereAutorizacionCliente = If(rdbSiRequiereAutorizacionCliente.Checked, 1, 0)
            'DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
            DocumentoCancelar.UsoCFDIID = "" ''If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
            DocumentoCancelar.ProductoAlCancelar = lblUbicacionProducto.Text


            Dim confirmacion As New Tools.ConfirmarForm
            confirmacion.mensaje = "¿Está seguro de cancelar este documento?"
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Cursor = Cursors.WaitCursor
                    'entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

                    btnGuardar.Enabled = False
                    lblGuardar.Enabled = False
                    If entDatosFactura.TipoComprobante = "F" Then
                        If EntDocumentoACancelar.EstatusID = 157 Or EntDocumentoACancelar.EstatusID = 167 Then
                            dtRespuestaCancelacionTimbrada = EnviarSolicitudCancelarSat(DocumentoCancelar, tipoCancelacion)

                            If dtRespuestaCancelacionTimbrada.Rows.Count > 0 Then
                                Dim estatus As String = dtRespuestaCancelacionTimbrada.Rows(0).Item("Mensaje")
                                Dim resultado As Int16 = dtRespuestaCancelacionTimbrada.Rows(0).Item("Resultado")

                                If resultado = 1 Then
                                    If estatus.Contains("201") = True Or estatus.Contains("202") = True Or estatus.Contains("107") = True Then
                                        DocumentoCancelar.RequiereAutorizacionCliente = 0
                                        ''cancelar say y sicy  regresar pares ot a por refacturar
                                        CancelarFacturaSaySicyOperacion(DocumentoCancelar)
                                        ''actualizar status de la solicitud 
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 472)

                                        If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoId, "FACTURACALZADO") = True Then
                                            RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoId)
                                            AbrirPDFFactura(RutaPDFFactura)
                                        End If
                                        objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
                                        entFactura = objBUTimbrado.ConsultarRutasDocumento(DocumentoId)
                                        show_message("Exito", "Documento cancelado correctamente")
                                    End If
                                Else
                                    If estatus.Contains("104") = True Or estatus.Contains("105") = True Or estatus.Contains("106") = True Then ''documento pendiente de aceptacion
                                        DocumentoCancelar.RequiereAutorizacionCliente = 1 'EL DOCUMENTO DE STATUS A 191 -CANCELADA (ESPERA ACEPTACION)-
                                        objBU.cancelarDocumento(DocumentoCancelar) ''actualiza el documento a 191 e inserta en TBL_FacturacionCalzadoDocumento_Cancelacion
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 473) '' espera de aceptacion
                                        show_message("Aviso", "Documento en espera de aceptacion")
                                    Else
                                        ''ACTUALIZAR LA SOLICITUD A "FALTA SAT "
                                        ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 485)
                                        '' INSERTAR EN LA TABLA DE TBL_FacturacionCalzadoDocumento_Cancelacion
                                        InsertaCancelacion(DocumentoCancelar)
                                        show_message("Error", estatus)
                                    End If
                                End If

                            Else
                                ''ACTUALIZAR LA SOLICITUD A FALTA SAT 
                                ActualizarStatusSolicitud(DocumentoCancelar.DocumentoID, 485) '' FALTA SAT
                                '' INSERTAR EN LA TABLA DE TBL_FacturacionCalzadoDocumento_Cancelacion
                                InsertaCancelacion(DocumentoCancelar)
                                show_message("Error", "Ocurrio un error al cancelar")
                            End If
                        Else
                            objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
                            show_message("Exito", "Documento cancelado correctamente")
                        End If

                    End If
                Catch ex As Exception

                End Try
            End If

        Else
            show_message("Advertencia", "Faltan datos por capturar, verifique por favor.")
        End If
    End Sub



    Private Sub Guardar()

        'Cursor = Cursors.WaitCursor

        Dim DocumentoCancelar As New Entidades.CancelacionDocumento
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        'Dim CancelacionTimbrada As Boolean = False
        Dim RutaPDFFactura As String = String.Empty
        Dim entFactura As New Entidades.DatosFactura
        Dim entFacturaCancelacion As New Entidades.DatosFactura
        Dim dtinformacionMotivo As New DataTable
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim entCancelacionSICY As New Entidades.CancelacionDocumento
        Dim seRelaciona As Int32 = dtSolicitudDocumentoCancelar.Rows(0).Item("seRelaciona")
        Dim tipoCancelacion As String = dtSolicitudDocumentoCancelar.Rows(0).Item("ClaveSat") ''01: con relacion 02: sin relacion 03: no se llevo acabo la operacion
        Dim dtRespuestaCancelacionTimbrada As New DataTable

        entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

        If entFactura.TipoComprobante = "R" Then
            objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
            show_message("Exito", "Documento cancelado correctamente")
            Cursor = Cursors.Default
            Return
        ElseIf tipoCancelacion = "02" Then '' Comprobante emitido con errores sin relación
            CancelarDocumentoSinRelacion(DocumentoCancelar, entDatosFactura)
        ElseIf tipoCancelacion = "01" Then
            CancelarDocumentoConRelacion(DocumentoCancelar, entDatosFactura)
        ElseIf tipoCancelacion = "03" Then
            CancelarDocumentoOperacion(DocumentoCancelar, entDatosFactura)
        End If


        Cursor = Cursors.Default
    End Sub

    Public Function EnviarSolicitudCancelarSat(ByVal DocumentoCancelar As Entidades.CancelacionDocumento, ByVal Motivoid As String) As DataTable
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim dtRespuestaCancelacionTimbrada As New DataTable
        dtRespuestaCancelacionTimbrada = objBUTimbrado.CancelarFacturaSolicitud4_0(EntDocumentoACancelar.DocumentoID, EntDocumentoACancelar.UUID, EntDocumentoACancelar.EmpresaID, EntDocumentoACancelar.TipoComprobante, EntDocumentoACancelar.UsuarioID, Motivoid)
        Return dtRespuestaCancelacionTimbrada
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
#Region "Cancelar anterior"

        ''Cursor = Cursors.WaitCursor

        'Dim DocumentoCancelar As New Entidades.CancelacionDocumento
        'Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        'Dim CancelacionTimbrada As Boolean = False
        'Dim RutaPDFFactura As String = String.Empty
        'Dim entFactura As New Entidades.DatosFactura
        'Dim entFacturaCancelacion As New Entidades.DatosFactura
        'Dim dtinformacionMotivo As New DataTable
        'Dim entDatosFactura As New Entidades.DatosFactura
        'Dim entCancelacionSICY As New Entidades.CancelacionDocumento


        'If txtSolicita.Text <> "" And cmboxMotivoCancelacion.SelectedIndex > 0 And If((cmbRFCNuevoDocumento.Visible And cmbRFCNuevoDocumento.SelectedIndex > 0) Or (cmbRFCNuevoDocumento.Visible = False), True, False) And If((cmbUsoCFDI.Visible And cmbUsoCFDI.SelectedIndex > 0) Or (cmbUsoCFDI.Visible = False), True, False) And txtObservaciones.Text <> "" Then
        '    DocumentoCancelar.DocumentoID = DocumentoId
        '    DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        '    DocumentoCancelar.Solicita = txtSolicita.Text
        '    DocumentoCancelar.MotivoID = cmboxMotivoCancelacion.SelectedValue
        '    DocumentoCancelar.Observaciones = txtObservaciones.Text
        '    DocumentoCancelar.SustitucionInmediata = If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)
        '    DocumentoCancelar.RequiereAutorizacionCliente = If(rdbSiRequiereAutorizacionCliente.Checked, 1, 0)
        '    DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
        '    DocumentoCancelar.UsoCFDIID = If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
        '    DocumentoCancelar.ProductoAlCancelar = lblUbicacionProducto.Text

        '    If rdbSIGenerarSustitucionInmediata.Checked Then
        '        Dim confirmaCaptcha As New Tools.frmCaptcha
        '        ' confirmaCaptcha.mensaje = If(lblUbicacionProducto.Text = "ENTREGADO", "La mercancía no regresará al inventario.", "")
        '        confirmaCaptcha.mensaje = ""
        '        confirmaCaptcha.facturacion = 1
        '        'confirmaCaptcha.Tamaño_Letra = 11
        '        If confirmaCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
        '            Try
        '                Cursor = Cursors.WaitCursor
        '                'Cancelacion SAY
        '                objBU.cancelarDocumento(DocumentoCancelar)
        '                objBU.EnviarParesRefacturarOT(DocumentoCancelar.DocumentoID)
        '                'Cancelacion SICY                        
        '                dtinformacionMotivo = objBU.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
        '                entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

        '                entCancelacionSICY.DocumentoID = DocumentoId
        '                entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
        '                entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
        '                entCancelacionSICY.Año = entDatosFactura.Año
        '                entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
        '                entCancelacionSICY.MotivoSICYID = dtinformacionMotivo.Rows(0).Item("esta_statussicy")
        '                entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("esta_nombre")
        '                entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
        '                entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        '                'Descomentar para produccion
        '                objBU.CancelarDocumentoSICY(entCancelacionSICY)
        '                '------------------------

        '                btnGuardar.Enabled = False
        '                lblGuardar.Enabled = False
        '                VentanaAdministradorDocumentos.UltimoDocumentoCancelado = DocumentoCancelar.DocumentoID
        '                VentanaAdministradorDocumentos.UltimoClienteCancelado = ClienteId
        '                VentanaAdministradorDocumentos.UltimoSolicitanteCancelacion = DocumentoCancelar.Solicita
        '                VentanaAdministradorDocumentos.UltimoMotivoCancelacionSeleccionado = DocumentoCancelar.MotivoID
        '                VentanaAdministradorDocumentos.UltimoRFCCancelacionSeleccionado = DocumentoCancelar.NuevoRFCID
        '                VentanaAdministradorDocumentos.UltimaObservacionCancelacionSeleccionada = DocumentoCancelar.Observaciones
        '                VentanaAdministradorDocumentos.UltimoUsoCancelacionSeleccionado = DocumentoCancelar.UsoCFDIID
        '                VentanaAdministradorDocumentos.UltimaOpcionSustitucionSeleccionada = If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)

        '                If entDatosFactura.TipoComprobante = "F" Then
        '                    If EntDocumentoACancelar.EstatusID = 157 Or EntDocumentoACancelar.EstatusID = 167 Then
        '                        'Timbrar la cancelacion del documento
        '                        CancelacionTimbrada = objBUTimbrado.CancelarFactura(EntDocumentoACancelar.DocumentoID, EntDocumentoACancelar.UUID, EntDocumentoACancelar.EmpresaID, EntDocumentoACancelar.TipoComprobante, EntDocumentoACancelar.UsuarioID)
        '                        If CancelacionTimbrada = True Then
        '                            If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoId, "FACTURACALZADO") = True Then
        '                                RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoId)
        '                                AbrirPDFFactura(RutaPDFFactura)
        '                            End If
        '                            entFactura = objBUTimbrado.ConsultarRutasDocumento(DocumentoId)
        '                            objBUTimbrado.CancelarDocumentoSICY(entFactura.RemisionID, entFactura.Año, entFactura.UUID, entFactura.RutaXML, entFactura.RutaPDF)
        '                            '    objBU.cambiarStatusDocumentoCanceladoSAT(DocumentoCancelar.DocumentoID)
        '                            show_message("Exito", "Documento cancelado correctamente")
        '                        Else
        '                            show_message("Advertencia", "El documento solo se canceló en SAY, no se realizó la cancelación ante el SAT, intente más tarde")
        '                        End If
        '                    Else
        '                        objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
        '                        show_message("Exito", "Documento cancelado correctamente")
        '                    End If

        '                ElseIf entDatosFactura.TipoComprobante = "R" Then
        '                    objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
        '                    show_message("Exito", "Documento cancelado correctamente")
        '                End If
        '                objBU.EliminarRegistroSalidaNoEmbarcado(DocumentoCancelar.DocumentoID)
        '            Catch ex As Exception
        '                show_message("Error", "Ocurrio un error al cancelar, intente de nuevo")
        '            End Try
        '        End If
        '    Else
        '        Dim confirmacion As New Tools.ConfirmarForm
        '        confirmacion.mensaje = "¿Está seguro de cancelar este documento sin generar el documento de sustitución en este momento? (Una vez realizada esta acción no se podrá revertir). La mercancía no regresará al inventario."
        '        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        '            Try
        '                Cursor = Cursors.WaitCursor
        '                'Cancelacion SAY
        '                objBU.cancelarDocumento(DocumentoCancelar)
        '                If rdbNoRequiereAutorizacionCliente.Checked Then
        '                    'Cancelacion SICY                        
        '                    dtinformacionMotivo = objBU.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
        '                    entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

        '                    entCancelacionSICY.DocumentoID = DocumentoId
        '                    entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
        '                    entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
        '                    entCancelacionSICY.Año = entDatosFactura.Año
        '                    entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
        '                    entCancelacionSICY.MotivoSICYID = dtinformacionMotivo.Rows(0).Item("esta_statussicy")
        '                    entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("esta_nombre")
        '                    entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
        '                    entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        '                    'descomentar para produccion
        '                    objBU.CancelarDocumentoSICY(entCancelacionSICY)
        '                    '------------------------

        '                    btnGuardar.Enabled = False
        '                    lblGuardar.Enabled = False
        '                    VentanaAdministradorDocumentos.UltimoDocumentoCancelado = DocumentoCancelar.DocumentoID
        '                    VentanaAdministradorDocumentos.UltimoClienteCancelado = ClienteId
        '                    VentanaAdministradorDocumentos.UltimoSolicitanteCancelacion = DocumentoCancelar.Solicita
        '                    VentanaAdministradorDocumentos.UltimoMotivoCancelacionSeleccionado = DocumentoCancelar.MotivoID
        '                    VentanaAdministradorDocumentos.UltimoRFCCancelacionSeleccionado = DocumentoCancelar.NuevoRFCID
        '                    VentanaAdministradorDocumentos.UltimaObservacionCancelacionSeleccionada = DocumentoCancelar.Observaciones
        '                    VentanaAdministradorDocumentos.UltimoUsoCancelacionSeleccionado = DocumentoCancelar.UsoCFDIID
        '                    VentanaAdministradorDocumentos.UltimaOpcionSustitucionSeleccionada = If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)

        '                    If entDatosFactura.TipoComprobante = "F" Then
        '                        If EntDocumentoACancelar.EstatusID = 157 Or EntDocumentoACancelar.EstatusID = 167 Then
        '                            'Timbrar la cancelacion del documento
        '                            CancelacionTimbrada = objBUTimbrado.CancelarFactura(EntDocumentoACancelar.DocumentoID, EntDocumentoACancelar.UUID, EntDocumentoACancelar.EmpresaID, EntDocumentoACancelar.TipoComprobante, EntDocumentoACancelar.UsuarioID)
        '                            If CancelacionTimbrada = True Then
        '                                If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoId, "FACTURACALZADO") = True Then
        '                                    RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoId)
        '                                    AbrirPDFFactura(RutaPDFFactura)
        '                                End If
        '                                '   objBU.cambiarStatusDocumentoCanceladoSAT(DocumentoCancelar.DocumentoID)
        '                                show_message("Exito", "Documento cancelado correctamente")
        '                            Else
        '                                show_message("Advertencia", "El documento solo se canceló en SAY, no se realizó la cancelación ante el SAT, intente más tarde")
        '                            End If
        '                        Else
        '                            objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
        '                            show_message("Exito", "Documento cancelado correctamente")
        '                        End If
        '                    ElseIf entFactura.TipoComprobante = "R" Then
        '                        objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
        '                        show_message("Exito", "Documento cancelado correctamente")
        '                    End If

        '                    objBU.EliminarRegistroSalidaNoEmbarcado(DocumentoCancelar.DocumentoID)

        '                ElseIf rdbSiRequiereAutorizacionCliente.Checked Then
        '                    'Cancelacion SICY                        
        '                    dtinformacionMotivo = objBU.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
        '                    entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

        '                    entCancelacionSICY.DocumentoID = DocumentoId
        '                    entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
        '                    entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
        '                    entCancelacionSICY.Año = entDatosFactura.Año
        '                    entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
        '                    entCancelacionSICY.MotivoSICYID = dtinformacionMotivo.Rows(0).Item("esta_statussicy")
        '                    entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("esta_nombre")
        '                    entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
        '                    entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        '                    'Se comento la cancelacion en Sicy y ya que se hara desde un sp
        '                    'objBU.CancelarDocumentoSICY(entCancelacionSICY)
        '                    '------------------------
        '                    btnGuardar.Enabled = False
        '                    lblGuardar.Enabled = False
        '                    VentanaAdministradorDocumentos.UltimoDocumentoCancelado = DocumentoCancelar.DocumentoID
        '                    VentanaAdministradorDocumentos.UltimoClienteCancelado = ClienteId
        '                    VentanaAdministradorDocumentos.UltimoSolicitanteCancelacion = DocumentoCancelar.Solicita
        '                    VentanaAdministradorDocumentos.UltimoMotivoCancelacionSeleccionado = DocumentoCancelar.MotivoID
        '                    VentanaAdministradorDocumentos.UltimoRFCCancelacionSeleccionado = DocumentoCancelar.NuevoRFCID
        '                    VentanaAdministradorDocumentos.UltimaObservacionCancelacionSeleccionada = DocumentoCancelar.Observaciones
        '                    VentanaAdministradorDocumentos.UltimoUsoCancelacionSeleccionado = DocumentoCancelar.UsoCFDIID
        '                    VentanaAdministradorDocumentos.UltimaOpcionSustitucionSeleccionada = If(rdbSIGenerarSustitucionInmediata.Checked, 1, 0)

        '                    If entDatosFactura.TipoComprobante = "F" Then
        '                        If EntDocumentoACancelar.EstatusID = 157 Or EntDocumentoACancelar.EstatusID = 167 Then
        '                            'Timbrar la cancelacion del documento
        '                            CancelacionTimbrada = objBUTimbrado.CancelarFactura(EntDocumentoACancelar.DocumentoID, EntDocumentoACancelar.UUID, EntDocumentoACancelar.EmpresaID, EntDocumentoACancelar.TipoComprobante, EntDocumentoACancelar.UsuarioID)
        '                            If CancelacionTimbrada = True Then
        '                                '---Se comenta PDF por que queda pendiente
        '                                'If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoId, "FACTURACALZADO") = True Then
        '                                '    RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoId)
        '                                '    AbrirPDFFactura(RutaPDFFactura)
        '                                'End If
        '                                '   objBU.cambiarStatusDocumentoCanceladoSAT(DocumentoCancelar.DocumentoID)
        '                                show_message("Exito", "Este documento requiere aceptación del cliente para su cancelación, indique a Atención a Clientes para solicitar al cliente sea aceptado cuanto antes y pueda volver a facturar si es necesario.")
        '                            Else
        '                                show_message("Advertencia", "El documento solo se canceló en SAY, no se realizó la cancelación ante el SAT, intente más tarde")
        '                            End If
        '                        Else
        '                            objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
        '                            show_message("Exito", "Documento cancelado correctamente")
        '                        End If
        '                    ElseIf entFactura.TipoComprobante = "R" Then
        '                        objBU.cambiarStatusDocumentoCancelado(DocumentoCancelar.DocumentoID)
        '                        show_message("Exito", "Documento cancelado correctamente")
        '                    End If
        '                End If

        '                objBU.EliminarRegistroSalidaNoEmbarcado(DocumentoCancelar.DocumentoID)
        '            Catch ex As Exception
        '                show_message("Error", "Ocurrio un error al cancelar, intente de nuevo")
        '            End Try
        '        End If
        '    End If
        'Else
        '    show_message("Advertencia", "Faltan datos por capturar, verifique por favor.")
        'End If

        'Cursor = Cursors.Default
#End Region
    End Sub
    'Private Sub rdbNoGenerarSustitucionInmediata_CheckedChanged(sender As Object, e As EventArgs)
    '    If cmbUsoCFDI.Visible = True Then
    '        lblTextoUsoCFDI.Visible = False
    '        cmbUsoCFDI.Visible = False
    '        cmbUsoCFDI.SelectedIndex = 0
    '    End If
    '    If lblRFCNuevaFactura.Visible = True Then
    '        lblRFCNuevaFactura.Visible = False
    '        cmbRFCNuevoDocumento.Visible = False
    '        cmbRFCNuevoDocumento.SelectedIndex = -1
    '    End If
    'End Sub

    'Private Sub rdbSIGenerarSustitucionInmediata_CheckedChanged(sender As Object, e As EventArgs)
    '    If cmboxMotivoCancelacion.SelectedValue = 144 Or cmboxMotivoCancelacion.SelectedValue = 146 Or cmboxMotivoCancelacion.SelectedValue = 150 Then
    '        lblRFCNuevaFactura.Visible = True
    '        cmbRFCNuevoDocumento.Visible = True
    '        CargarRFCClienteMotivo()
    '    End If
    '    If cmboxMotivoCancelacion.SelectedValue = 147 Then
    '        lblTextoUsoCFDI.Visible = False
    '        cmbUsoCFDI.Visible = False
    '        cmbUsoCFDI.SelectedIndex = 0
    '        lblRFCNuevaFactura.Visible = False
    '        cmbRFCNuevoDocumento.Visible = False
    '        cmbRFCNuevoDocumento.SelectedIndex = -1
    '    End If
    '    If cmboxMotivoCancelacion.SelectedValue = 148 Then
    '        lblTextoUsoCFDI.Visible = True
    '        cmbUsoCFDI.Visible = True
    '        lblRFCNuevaFactura.Visible = False
    '        cmbRFCNuevoDocumento.Visible = False
    '        cmbRFCNuevoDocumento.SelectedIndex = -1
    '    End If
    '    If cmboxMotivoCancelacion.SelectedValue = 149 Or cmboxMotivoCancelacion.SelectedValue = 145 Then
    '        lblTextoUsoCFDI.Visible = False
    '        cmbUsoCFDI.Visible = False
    '        cmbUsoCFDI.SelectedIndex = 0
    '        lblRFCNuevaFactura.Visible = False
    '        cmbRFCNuevoDocumento.Visible = False
    '        cmbRFCNuevoDocumento.SelectedIndex = -1
    '    End If
    'End Sub

    Private Sub CancelacionDocumentos_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        Try
            VentanaAdministradorDocumentos.WindowState = FormWindowState.Maximized
            VentanaAdministradorDocumentos.RecargarDatos()
        Catch

        End Try

    End Sub





#End Region

#Region "OTRAS FUNCIONES"

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If


        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

    End Sub

#End Region

    Private Sub AbrirPDFFactura(ByVal RutaPDF As String)
        Try
            'Dim objFTP As New Tools.TransferenciaFTP
            'objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Carga_Proyeccion_V1.pdf")
            Process.Start(RutaPDF)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdVCfdiRelacionados_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grdVCfdiRelacionados.CustomDrawCell
        ValorCelda = String.Empty
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Status" Then
                ValorCelda = IIf(IsDBNull(e.CellValue), "", e.CellValue.ToString.Trim)
                If ValorCelda = "ACTIVO" Then
                    e.Appearance.ForeColor = Color.Green
                Else
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Sub grdVCfdiRelacionados_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdVCfdiRelacionados.RowStyle
        ValorCelda = String.Empty
        If e.RowHandle >= 0 Then
            ValorCelda = grdVCfdiRelacionados.GetRowCellValue(e.RowHandle, "Status").ToString.Trim.ToUpper
            If ValorCelda = "CANCELADO" Then
                'bgvReporte.SetRowCellValue(e.RowHandle, "ART", "")
                e.Appearance.ForeColor = Color.Red
            End If
        End If

    End Sub

    Private Sub ObtenerSeleccionRelacionCDIFMotivoCancelacion(motivoCancelacionID As Integer)
        lblRelacionMotivo.Visible = False
        If ConSolicitud = 1 Then
            For index = 0 To dtRelacionMotivoCancelacionSolicitud.Rows.Count - 1
                If CInt(dtRelacionMotivoCancelacionSolicitud.Rows(index).Item("EstatusID").ToString) = motivoCancelacionID And lblTipoDocumento.Text.Equals("FACTURA") Then
                    lblRelacionMotivo.Visible = True
                    lblRelacionMotivo.Text = dtRelacionMotivoCancelacionSolicitud.Rows(index).Item("RelacionaCFDIPreviosTexto").ToString
                    lblRelacionMotivo.ForeColor = IIf(CInt(dtRelacionMotivoCancelacionSolicitud.Rows(index).Item("RelacionaCFDIPrevios").ToString) = 1, Color.Purple, Color.FromArgb(33, 97, 140S))
                End If
            Next
        Else
            For index = 0 To dtRelacionMotivoCancelacion.Rows.Count - 1
                If CInt(dtRelacionMotivoCancelacion.Rows(index).Item("EstatusID").ToString) = motivoCancelacionID And lblTipoDocumento.Text.Equals("FACTURA") Then
                    lblRelacionMotivo.Visible = True
                    lblRelacionMotivo.Text = dtRelacionMotivoCancelacion.Rows(index).Item("RelacionaCFDIPreviosTexto").ToString
                    lblRelacionMotivo.ForeColor = IIf(CInt(dtRelacionMotivoCancelacion.Rows(index).Item("RelacionaCFDIPrevios").ToString) = 1, Color.Purple, Color.FromArgb(33, 97, 140S))
                End If
            Next
        End If
    End Sub
    Private Sub CancelarFacturaSaySicy(DocumentoCancelar As Entidades.CancelacionDocumento)
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim dtinformacionMotivo As New DataTable
        Dim entCancelacionSICY As New Entidades.CancelacionDocumento

        Try
            'Cancelacion SAY
            objBU.cancelarDocumento(DocumentoCancelar)
            objBU.EnviarParesRefacturarOT(DocumentoCancelar.DocumentoID)
            'Cancelacion SICY                        
            'dtinformacionMotivo = objBU.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
            Dim objSolicitaCancelacion As New Ventas.Negocios.SolicitarCancelacionBU
            dtinformacionMotivo = objSolicitaCancelacion.ConsultarMotivosInternoEditar(DocumentoCancelar.MotivoID)

            entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

            entCancelacionSICY.DocumentoID = DocumentoId
            entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
            entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
            entCancelacionSICY.Año = entDatosFactura.Año
            entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoSICYID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("motivo")
            entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
            entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            'Descomentar para produccion
            objBU.CancelarDocumentoSICY(entCancelacionSICY)
        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
    End Sub


    Private Sub CancelarFacturaSaySicyOperacion(DocumentoCancelar As Entidades.CancelacionDocumento)
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim dtinformacionMotivo As New DataTable
        Dim entCancelacionSICY As New Entidades.CancelacionDocumento
        Dim dtRespuestaUbicacion As DataTable

        Try
            'Cancelacion SAY
            objBU.cancelarDocumento(DocumentoCancelar)

            ''si la ot esta en almacen volver la ot a refacturar en caso contrario no hacer nada
            dtRespuestaUbicacion = objBU.ConsultarUbicacionProducto(DocumentoCancelar.DocumentoID)
            If dtRespuestaUbicacion.Rows(0).Item("ubicacionProducto") <> "ENTREGADO" Then
                objBU.EnviarParesRefacturarOT(DocumentoCancelar.DocumentoID)
            End If
            'Cancelacion SICY                        
            'dtinformacionMotivo = objBU.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
            Dim objSolicitaCancelacion As New Ventas.Negocios.SolicitarCancelacionBU
            dtinformacionMotivo = objSolicitaCancelacion.ConsultarMotivosInternoEditar(DocumentoCancelar.MotivoID)

            entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoId)

            entCancelacionSICY.DocumentoID = DocumentoId
            entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
            entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
            entCancelacionSICY.Año = entDatosFactura.Año
            entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoSICYID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("motivo")
            entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
            entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            'Descomentar para produccion
            objBU.CancelarDocumentoSICY(entCancelacionSICY)
        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CancelacionConEsperaAceptacion()
        Try

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ActualizarStatusSolicitud(Documento As Integer, status As Integer)
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Negocios.SolicitarCancelacionBU
        objSolicitud.ActualizarEstatusSolicitud(Documento, status)
    End Sub

    Private Sub InsertaCancelacion(DocumentoCancelar As Entidades.CancelacionDocumento)
        Dim dtRespuesta As New DataTable
        Dim objSolicitud As New Ventas.Negocios.SolicitarCancelacionBU
        objSolicitud.InsertarCancelacion(DocumentoCancelar)

    End Sub

    Private Sub lblTextoUsoCFDI_Click(sender As Object, e As EventArgs)

    End Sub
End Class