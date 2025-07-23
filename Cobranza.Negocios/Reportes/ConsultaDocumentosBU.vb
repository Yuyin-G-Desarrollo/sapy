Public Class ConsultaDocumentosBU
    Public Function ConsultaDocumentos(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal clienteID As String, ByVal estatus As String, ByVal UsuarioID As Integer) As DataTable
        Dim datos As New Datos.ConsultaDocumentosDA
        ConsultaDocumentos = datos.ConsultaDocumentos(fechaInicio, fechaFin, clienteID, estatus, UsuarioID)
        Return ConsultaDocumentos
    End Function

    Public Function ConsultaClientes(ByVal UsuarioID As Integer) As DataTable
        Dim datos As New Datos.ConsultaDocumentosDA
        ConsultaClientes = datos.ConsultaClientes(UsuarioID)
        Return ConsultaClientes
    End Function

    Public Sub ActualizarObsevaciones(ByVal observaciones As String, ByVal idRemision As Integer, ByVal anio As Int16)
        Dim datos As New Datos.ConsultaDocumentosDA
        datos.ActualizarObsevaciones(observaciones, idRemision, anio)
    End Sub

    Public Function ObtieneNCDocumentos(ByVal DocumentoID As String, ByVal Año As String, ByVal ClienteSICYID As String) As DataTable
        Dim datos As New Datos.ConsultaDocumentosDA
        Return datos.ObtieneNCDocumentos(DocumentoID, Año, ClienteSICYID)
    End Function


    Public Function ObtieneInformacionReporte(ByVal CadenaID As String, ByVal fechaInicio As Date, ByVal fechaFin As Date) As DataTable
        Dim datos As New Datos.ConsultaDocumentosDA
        Return datos.ObtieneInformacionReporte(CadenaID, fechaInicio, fechaFin)
    End Function

    Public Function ObtieneInformacionReportePagos(ByVal CadenaID As String, ByVal Agentes As String, ByVal Empresas As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal tipoReporte As Integer) As DataTable
        Dim datos As New Datos.ConsultaDocumentosDA
        Return datos.ObtieneInformacionReportePagos(CadenaID, Agentes, Empresas, fechaInicio, fechaFin, tipoReporte)
    End Function
End Class
