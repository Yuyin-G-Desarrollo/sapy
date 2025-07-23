Imports System.Data.SqlClient

Public Class DatosDocumentoDA
    Public Function getDatosEmpresa(ByVal empresaId As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@IdEmpresa"
            parametro.Value = empresaId
            listaParametros.Add(parametro)
            Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarEmpresas", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getDatosDocumento(ByVal idDocumento As Integer, ByVal tipoNodo As String, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoNodo"
            parametro.Value = tipoNodo
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarDocumento", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getDatosDocumentoNumConceptos(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter



        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarDocumentoNumConceptos", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function getDatosDocumentoNumComplementos(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarDocumentoNumComplementos", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function getDatosDocumentoConcepto(ByVal idDocumento As Integer, ByVal idConcepto As Integer, ByVal tipoNodo As String, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdConcepto"
            parametro.Value = idConcepto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoNodo"
            parametro.Value = tipoNodo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarDocumentoConcepto", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function getDatosDocumentoComplemento(ByVal idDocumento As Integer, ByVal idConcepto As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdConcepto"
            parametro.Value = idConcepto
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_ConsultarDocumentoComplemento]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerTipoComprobante(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@DocumentoId"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerTipoComprobante]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function InsertarErrorAlTimbrar(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal ClaveError As String, ByVal DescripcionError As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClaveError"
            parametro.Value = ClaveError
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@DescripcionError"
            parametro.Value = DescripcionError
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbre_RegistroErrores_Documento]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerTotalesDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@DocumentoId"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ValidarMontos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ActualizarInformacionDocumentoTimbrado(ByVal idDocumento As Integer, ByVal FechaTimbrado As String, ByVal UUID As String, ByVal RutaXML As String, ByVal RutaPDF As String, ByVal FechaTimbradoDT As String, ByVal CadenaOriginal As String, ByVal SelloSAT As String, ByVal SelloCFD As String, ByVal SerieCertificadoSAT As String, ByVal SerieCertificadoEmisor As String, ByVal EmpresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@DocumentoId"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaTimbrado"
            parametro.Value = FechaTimbrado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UUID"
            parametro.Value = UUID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaXML"
            parametro.Value = RutaXML
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaPDF"
            parametro.Value = RutaPDF
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaTimbradoDT"
            parametro.Value = FechaTimbradoDT
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaOriginal"
            parametro.Value = CadenaOriginal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SelloSAT"
            parametro.Value = SelloSAT
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SelloCFD"
            parametro.Value = SelloCFD
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SerieCertificadoSAT"
            parametro.Value = SerieCertificadoSAT
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SerieCertificadoEmisor"
            parametro.Value = SerieCertificadoEmisor
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@EmpresaID"
            parametro.Value = EmpresaId
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizarEncabezado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerRutaArchivos(ByVal EmpresaID As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@EmpresaID"
            parametro.Value = EmpresaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)


            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_ObtenerRutaArchivos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerCFDIRelacionadosDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DocumentoID"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerCFDIRelacionados]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerRutaXMLSICY(ByVal EmpresaID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@EmpresaID"
            parametro.Value = EmpresaID
            listaParametros.Add(parametro)
            Return operacion.EjecutarConsultaSP("[Ventas].[SP_NotaDeCredito_Timbrado_XML_RutaSICY]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReporteDocTimbradoNotaDeCredito(ByVal Accion As Int16, ByVal idNotaDeCredito As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "Accion"
            ParametroParaLista.Value = Accion
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "p_IdNotaCredito"
            ParametroParaLista.Value = idNotaDeCredito
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("[Cobranza].[sp_ReporteDocTimbradoNotaDeCredito]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtenerRutaPDFSICY(ByVal EmpresaID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)
        Return operacion.EjecutarConsultaSP("[Ventas].[SP_NotaCredito_Timbrado_PDF_RutaSICY]", listaParametros)
    End Function


    Public Shared Sub ActualizarDatosCancelacion(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal FechaCancelacion As String, ByVal EstatusCancelacionId As String, ByVal DescripcionEstatusCancelacion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaCancelacion"
        parametro.Value = FechaCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EstatusCancelacionID"
        parametro.Value = EstatusCancelacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DescripcionEsatusCancelacion"
        parametro.Value = DescripcionEstatusCancelacion
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizarDatosCancelacion]", listaParametros)
    End Sub


    Public Function ObtenerRutaCliente(ByVal EmpresaID As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoDocumento"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Documento_RutaCliente]", listaParametros)
    End Function

    'Public Shared Sub ActualizarDatosCancelacion(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal FechaCancelacion As String, ByVal EstatusCancelacionId As String, ByVal DescripcionEstatusCancelacion As String)
    '    Dim operacion As New Persistencia.OperacionesProcedimientos

    '    Dim listaParametros As New List(Of SqlParameter)
    '    Dim parametro As New SqlParameter
    '    parametro.ParameterName = "@DocumentoId"
    '    parametro.Value = idDocumento
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@TipoComprobante"
    '    parametro.Value = TipoComprobante
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@FechaCancelacion"
    '    parametro.Value = FechaCancelacion
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@EstatusCancelacionID"
    '    parametro.Value = EstatusCancelacionId
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@DescripcionEsatusCancelacion"
    '    parametro.Value = DescripcionEstatusCancelacion
    '    listaParametros.Add(parametro)

    '    operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerCFDIRelacionados]", listaParametros)
    'End Sub

    Public Function ObtenerDirectoriosDocumentosFacturacion(ByVal idDocumento As Integer, ByVal TipoComprobante As String, Optional ByVal TipoDocumento As String = "") As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@EmpresaID"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobanteId"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            If TipoDocumento <> "" Then
                parametro = New SqlParameter
                parametro.ParameterName = "@TipoDocumento"
                parametro.Value = TipoDocumento
                listaParametros.Add(parametro)
            End If

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Timbrado_Documento_Rutas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerTipoComprobanteId(ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter With {
            .ParameterName = "TipoComprobante",
            .Value = TipoComprobante
        }
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_Timbrado_ObtenerTipoComprobanteId", listaParametros)
    End Function
    Public Function getDatosDocumentoNotasCredito(ByVal idDocumento As Integer, ByVal tipoNodo As String, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoNodo"
            parametro.Value = tipoNodo
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerDocumentos_Timbrado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getDatosDocumentoNotasCreditoTraslados(ByVal idDocumento As Integer, ByVal tipoNodo As String, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdDocumento"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoNodo"
            parametro.Value = tipoNodo
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ObtenerDatosTraslados]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Sub ActualizarDatosCancelacionNotaCredito(ByVal idDocumento As Integer, ByVal FechaCancelacion As String, ByVal EstatusCancelacionId As String, ByVal DescripcionEstatusCancelacion As String, ByVal rutaXMLCancelacion As String, ByVal usuarioCancelo As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaCancelacion"
        parametro.Value = FechaCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EstatusCancelacionID"
        parametro.Value = EstatusCancelacionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DescripcionEsatusCancelacion"
        parametro.Value = DescripcionEstatusCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rutaXMLCancelacion"
        parametro.Value = rutaXMLCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioCancelo"
        parametro.Value = usuarioCancelo
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_Timbrado_ActualizaDatosCancelacion]", listaParametros)
    End Sub
End Class
