Public Class CancelacionDocumentosBU
    Public Sub EjecutaRevisionCancelacionesPendientes()
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Try
            objDA.EjecutaRevisionCancelacionesPendientes()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function consultaInformacionDocumentoCancelar(ByVal ClienteId As Integer, ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaInformacionDocumentoCancelar(ClienteId, DocumentoId)
        Return tabla
    End Function

    Public Function consultaFacturaDocumentosRelacionados(ByVal DocumentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaFacturaDocumentosRelacionados(DocumentoId)
        Return tabla
    End Function

    Public Function consultaMovimientosPorDocumento(ByVal RemisionID As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaMovimientosPorDocumento(RemisionID, Año)
        Return tabla
    End Function

    Public Function consultaMotivosCancelacion(ByVal TipoDocumento As String, ByVal Timbrado As Integer, ByVal StatusProducto As String, ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultaMotivosCancelacion(TipoDocumento, Timbrado, StatusProducto, ClienteID)
        Return tabla
    End Function

    Public Function consultarConsideracionesPorMotivo(ByVal MotivoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarConsideracionesPorMotivo(MotivoId)
        Return tabla
    End Function

    Public Function consultarRFCPorDocumentoMotivo(ByVal ClienteID As Integer, ByVal TipoDocumento As String, ByVal MotivoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarRFCPorDocumentoMotivo(ClienteID, TipoDocumento, MotivoId)
        Return tabla
    End Function

    Public Function consultarUsosPorDocumento(ByVal DocumentoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.consultarUsosPorDocumento(DocumentoID)
        Return tabla
    End Function

    Public Function cancelarDocumento(ByVal DocumentoCancelar As Entidades.CancelacionDocumento) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA        
        Dim tabla As New DataTable        
        tabla = objDA.cancelarDocumento(DocumentoCancelar)

        Return tabla
    End Function

    Public Function cancelarRefacturacion(ByVal ordenTrabajoId As Integer, ByVal usuarioId As Integer, ByVal observacionesCancelacion As String) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.cancelarRefacturacion(ordenTrabajoId, usuarioId, observacionesCancelacion)
        Return tabla
    End Function

    Public Function cambiarStatusDocumentoCanceladoSAT(ByVal documentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.cambiarStatusDocumentoCanceladoSAT(documentoId)
        Return tabla
    End Function

    Public Function cambiarStatusDocumentoCancelado(ByVal documentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.cambiarStatusDocumentoCancelado(documentoId)
        Return tabla
    End Function

    Public Sub CancelarDocumentoSICY(ByVal DocumentoCancelar As Entidades.CancelacionDocumento)
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        objDA.cancelarDocumentoSICY(DocumentoCancelar)
    End Sub

    Public Function ObtenerInformacionMotivoCancelacionID(ByVal MotivoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.ObtenerInformacionMotivoCancelacionID(MotivoID)
        Return dtInformacion
    End Function

    Public Function validarEstatusOTParaCancelar(ByVal OT As Integer) As Integer
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.validarEstatusOTParaCancelar(OT)

        If dtInformacion.Rows.Count > 0 Then
            Return dtInformacion.Rows(0).Item(0)
        Else
            Return 0
        End If

    End Function

    Public Function ValidarCancelacion(ByVal Documento As Integer) As Boolean
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.ValidarCancelacion(Documento)
        Dim resp As Integer


        If IsNothing(dtInformacion) = False Then
            If dtInformacion.Rows.Count > 0 Then
                For Each Fila As DataRow In dtInformacion.Rows
                    resp = Fila.Item("Respuesta")
                Next
            End If
        End If

        If resp <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Public Function ObtenerRelacionaCFDISegunMotivoCancelacion() As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.ObtenerRelacionaCFDISegunMotivoCancelacion()

        Return dtInformacion

    End Function

    Public Sub EnviarParesRefacturarOT(ByVal DocumentoId As Integer)
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.EnviarParesRefacturarOT(DocumentoId)
    End Sub

    Public Sub EliminarRegistroSalidaNoEmbarcado(ByVal DocumentoSAYId As Integer)
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        objDA.EliminarRegistroSalidaNoEmbarcado(DocumentoSAYId)
    End Sub

    Public Function ObtenerRelacionaCFDISegunMotivoCancelacionSolicitud(ByVal DocumentoSAYId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.ObtenerRelacionaCFDISegunMotivoCancelacionSolicitud(DocumentoSAYId)

        Return dtInformacion

    End Function

    Public Function ConsultarSolicitud(ByVal documentoid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Return objDA.ConsultarSolicitud(documentoid)
    End Function

    Public Function ConsultarInformacionMotivoCancelacionIDSolicitud(ByVal MotivoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.ConsultarInfoMotivoCancelacionSAT(MotivoID)
        Return dtInformacion
    End Function

    Public Function ConsultarMotivoSatID(ByVal MotivoInterno As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim dtInformacion As New DataTable
        dtInformacion = objDA.ConsultarMotivoSatID(MotivoInterno)
        Return dtInformacion
    End Function

    Public Function cambiarStatusDocumentoConEsperaAceptacion(ByVal documentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.cambiarStatusDocumentoCancelado(documentoId)
        Return tabla
    End Function

    Public Function ConsultarUbicacionProducto(ByVal documentoId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CancelacionDocumentosDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarUbicacionProducto(documentoId)
        Return tabla
    End Function

End Class
