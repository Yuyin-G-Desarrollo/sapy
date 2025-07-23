Public Class FacturacionBU

    Public Function ConsultarDocumentos(fechaInicio As DateTime,
                                        fechaFin As DateTime,
                                        usuarioConsultaID As Integer,
                                        permiso As Integer,
                                        entregados As Integer,
                                        filtroCliente As String,
                                        cedis As Integer) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarDocumentos(fechaInicio, fechaFin, usuarioConsultaID, permiso, entregados, filtroCliente, cedis)
        Return tabla
    End Function

    Public Function ConsultarDocumentosCobranza(fechaInicio As DateTime,
                                        fechaFin As DateTime,
                                        usuarioConsultaID As Integer,
                                        permiso As Integer,
                                        entregados As Integer,
                                        recibidos As Integer,
                                        filtroCliente As String,
                                        cedis As Integer) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarDocumentosCobranza(fechaInicio, fechaFin, usuarioConsultaID, permiso, entregados, recibidos, filtroCliente, cedis)
        Return tabla
    End Function

    Public Function ConsultarCatalogoTipoComprobante() As DataTable
        Dim objDA As New Datos.FacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarCatalogoTipoComprobante()
        Return tabla
    End Function

    Public Function ConsultarCatalogoMotivosNoEntrega() As DataTable
        Dim objDA As New Datos.FacturacionDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarCatalogoMotivosNoEntrega()
        Return tabla
    End Function

    Public Function RegistrarEntregadoDocumento(documentoId As Integer, tipoComprobanteId As Integer, motivoNoEntrega As Integer, usuarioCaptura As Integer) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Return objDA.RegistrarEntregadoDocumento(documentoId, tipoComprobanteId, motivoNoEntrega, usuarioCaptura)
    End Function

    Public Function RegistrarEntregadoDocumento_SICY(remisionId As Integer, anioRemision As Integer, tipoComprobanteId As String, motivoNoEntrega As String, usuarioCaptura As String) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Return objDA.RegistrarEntregadoDocumento_SICY(remisionId, anioRemision, tipoComprobanteId, motivoNoEntrega, usuarioCaptura)
    End Function

    Public Function CancelarEntregadoDocumento(documentoId As Integer, usuarioCaptura As Integer) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Return objDA.CancelarEntregadoDocumento(documentoId, usuarioCaptura)
    End Function

    Public Function CancelarEntregadoDocumento_Cobranza(documentoId As Integer, usuarioCaptura As Integer) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Return objDA.CancelarEntregadoDocumento_Cobranza(documentoId, usuarioCaptura)
    End Function

    Public Function RegistrarRecibidoDocumento(documentoId As Integer, usuarioCaptura As Integer) As DataTable
        Dim objDA As New Datos.FacturacionDA
        Return objDA.RegistrarRecibidoDocumento(documentoId, usuarioCaptura)
    End Function
End Class
