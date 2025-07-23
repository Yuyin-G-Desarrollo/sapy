Imports Cobranza.Negocios
Imports Entidades
Imports Tools
Imports ToolServicios

Public Class CancelarNotaCreditoForm
    Dim camposValidados As Boolean = False
    Public documentoId As Integer
    '' VARIABLES PARA PRUEBAS
    Dim pruebas As Boolean = False
    Dim local As Boolean = False
    Private Sub CancelarNotaCreditoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarMotivosCancelaciones()
    End Sub
    Private Sub cargarMotivosCancelaciones()
        Dim dtMotivos As New DataTable
        Dim objCargaMotivos As New NotaCreditoDevolucionesBU
        dtMotivos = objCargaMotivos.consultarMotivosCancelacion
        dtMotivos.Rows.InsertAt(dtMotivos.NewRow, 0)
        cmbTipoMotivosCancelacion.DataSource = dtMotivos
        If dtMotivos.Rows.Count > 0 Then
            cmbTipoMotivosCancelacion.ValueMember = "Id"
            cmbTipoMotivosCancelacion.DisplayMember = "Descripcion"
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If validarCampos() = False Then
            Dim datosCancelarFactura As New NotasCreditoDevoluciones
            Dim objDatos As New NotaCreditoDevolucionesBU
            Dim dtDatosCancelacion As New DataTable
            Dim dtParesDevueltosCancelar As New DataTable
            Dim strResultado As String = String.Empty
            Dim strResultadoCancelacionPDF As String = String.Empty
            datosCancelarFactura.NotaCreditoId = documentoId
            datosCancelarFactura.NotaCreditoUsuarioTimbro = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            dtDatosCancelacion = objDatos.obtenerDatosFacturacionCancelacion(datosCancelarFactura)
            datosCancelarFactura.NotaCreditoUUID = dtDatosCancelacion.Rows(0).Item(0)
            datosCancelarFactura.NotaCreditoRazSocialId = dtDatosCancelacion.Rows(0).Item(1)
            If dtDatosCancelacion.Rows.Count > 0 Then
                strResultado = cancelarFacturaNotaCredito(datosCancelarFactura)
                If strResultado = "Cancelacion Exitosa" Then
                    strResultadoCancelacionPDF = cancelarGeneracionPDF(datosCancelarFactura)
                    If strResultadoCancelacionPDF = "Cancelacion PDF Existosa" Then
                        dtParesDevueltosCancelar = objDatos.obtenerParesDevueltosParaCancelar(documentoId)
                        For x As Integer = 0 To dtParesDevueltosCancelar.Rows.Count - 1
                            datosCancelarFactura.NotaCreditoDetalleDevolucionId = dtParesDevueltosCancelar.Rows(x).Item(0)
                            datosCancelarFactura.NotaCreditoFolio = dtParesDevueltosCancelar.Rows(x).Item(1)
                            datosCancelarFactura.NotaCreditoParesAplicar = dtParesDevueltosCancelar.Rows(x).Item(2)
                            datosCancelarFactura.NotaCreditoProductoEstiloId = dtParesDevueltosCancelar.Rows(x).Item(3)
                            objDatos.cancelarParesDevoluciones(datosCancelarFactura)
                        Next
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "La nota de crédito ha sido cancelada correctamente")
                        cmbTipoMotivosCancelacion.Text = ""
                        txtObservaciones.Text = ""
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub
    Private Function validarCampos()
        If cmbTipoMotivosCancelacion.Text = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario seleccionar un motivo de cancelación.")
            camposValidados = True
        End If
        If txtObservaciones.Text = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario describir el motivo de la cancelación.")
            camposValidados = True
        End If
        Return camposValidados
    End Function
    Private Function cancelarFacturaNotaCredito(ByVal datosCancelarFactura As NotasCreditoDevoluciones) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String ''= IIf(local, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "NOTACREDITODEVOLUCION"

        Servidor = "http://localhost:7639/"
        llamarServicio.url = Servidor & "NotasCreditoDevoluciones/cancelaFactura" &
                            "?DocumentoID=" & datosCancelarFactura.NotaCreditoId &
                            "&UUID=" & datosCancelarFactura.NotaCreditoUUID &
                            "&EmpresaID=" & datosCancelarFactura.NotaCreditoRazSocialId &
                            "&TipoComprobante=" & tipoComprbante &
                            "&TimbradoPrueba=" & pruebas.ToString &
                            "&usuarioCancelo=" & datosCancelarFactura.NotaCreditoUsuarioTimbro
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, True) ''pruebas)
            resultado = "Cancelacion Exitosa"
        Else
            resultado = Respuesta.aviso & "(" & datosCancelarFactura.NotaCreditoId.ToString & ")"
            Try
            Catch ex As Exception
            End Try
        End If
        Return resultado
    End Function
    Private Function cancelarGeneracionPDF(ByVal datosCancelarFactura As NotasCreditoDevoluciones) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String ''= IIf(local, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim resultado As String = String.Empty
        Dim tipoComprbante = "NOTACREDITODEVOLUCION"

        Servidor = "http://localhost:7639/"

        llamarServicio.url = Servidor & "NotasCreditoDevoluciones/GenerarPDFCancelacion" &
                            "?DocumentoID=" & documentoId &
                             "&bPruebas=" & pruebas.ToString
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            objUtilerias.CrearDirectorio(RutaCliente)
            objUtilerias.CrearDirectorio(RutaServidorSICY)
            objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, True) ''local ---> true es prueba)
            resultado = "Cancelacion PDF Existosa"
        End If
        Return resultado
    End Function
End Class