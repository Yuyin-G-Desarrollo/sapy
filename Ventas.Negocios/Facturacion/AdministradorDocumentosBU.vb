Public Class AdministradorDocumentosBU
    Public Function ConsultaCancelacionEstatusSAT() As DataTable
        Dim dt As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Try
            dt = objDA.ConsultaCancelacionEstatusSAT()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultaAdministradorDocumentos(ByVal filtrosAdministradorDocumentos As Entidades.FiltrosAdministradorDocumentos) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaAdministradorDocumentos(filtrosAdministradorDocumentos)
        Return tabla
    End Function
    Public Function actualizarSaldosSicySay()
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Return objDA.actualizaSaldosSicySay
    End Function
    Public Function consultaOTPorDocumento(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaOTPorDocumento(DocumentoId)
        Return tabla
    End Function

    Public Function consultaEncabezadoPantallaVerDetalles(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaEncabezadoPantallaVerDetalles(DocumentoId)
        Return tabla
    End Function

    Public Function consultaDescuentosPantallaVerDetalles(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaDescuentosPantallaVerDetalles(DocumentoId)
        Return tabla
    End Function

    Public Function consultaDetallesDocumentoPantallaVerDetalles(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaDetallesDocumentoPantallaVerDetalles(DocumentoId)
        Return tabla
    End Function

    Public Function ConsultarReporteFacturas(ByVal DocumentoId As String, ByVal StatusId As String, ByVal FolioFactura As String, ByVal ClienteId As String, ByVal EmisorID As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objDA As New Ventas.Datos.AdministradorDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarReporteFacturas(DocumentoId, StatusId, FolioFactura, ClienteId, EmisorID, FechaInicio, FechaFin)
        Return tabla
    End Function

    Public Function ConsultarDetallesDocumentos(ByVal Documentos As String) As DataTable
        Dim ObjDa As New Datos.AdministradorDocumentosDA
        Try
            Return ObjDa.ConsultarDetallesDocumentos(Documentos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDetallesDocumentos_TotalParesPedido(ByVal Documentos As String) As DataTable
        Dim ObjDa As New Datos.AdministradorDocumentosDA
        Dim dt As DataTable
        Try
            dt = ObjDa.ConsultarDetallesDocumentos_TotalParesPedido(Documentos)
            'If dt.Rows.Count > 0 Then
            '    Return CInt(dt.Rows(0).Item(0).ToString)
            'Else
            '    Return 0
            'End If
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerRutas_PDF_XML_DocumentoExtanjero(ByVal DocumentoID As Integer) As DataTable
        Dim ObjDa As New Datos.AdministradorDocumentosDA
        Try
            Return ObjDa.ObtenerRutas_PDF_XML_DocumentoExtanjero(DocumentoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarRutaFacturaDocumentosExternos(ByVal DocumentoID As Integer, ByVal RutaPDF As String, ByVal RutaXML As String) As DataTable
        Dim ObjDa As New Datos.AdministradorDocumentosDA
        Try
            Return ObjDa.GuardarRutaFacturaDocumentosExternos(DocumentoID, RutaPDF, RutaXML)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviarRefacturar(ByVal idRemision As Integer, ByVal anio As Int16)
        Dim ObjDa As New Datos.AdministradorDocumentosDA
        Try
            ObjDa.EnviarRefacturar(idRemision, anio)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerArchivosXMLSAP(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal documentosSeleccionados As String) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Return objDA.ObtenerArchivosXMLSAP(FechaInicio, FechaFin, documentosSeleccionados)
    End Function

    Public Function ObtenerPermisoCancelacion(ByVal documentoid As Integer) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Return objDA.ObtenerPermisoCancelacion(documentoid)
    End Function

    Public Function ConsultarSolicitud(ByVal documentoid As Integer) As DataTable
        Dim objDA As New Datos.AdministradorDocumentosDA
        Return objDA.ConsultarSolicitud(documentoid)
    End Function

End Class
