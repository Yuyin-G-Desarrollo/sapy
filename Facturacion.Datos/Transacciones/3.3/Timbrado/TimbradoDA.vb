Imports System.Data.SqlClient

Public Class TimbradoDA

    ''' <summary>
    ''' Obtiene la informacion del certificado, RFC de la Empresa 
    ''' </summary>
    ''' <param name="empresaId">EmpresaID</param>
    ''' <returns>DataTable con la informacion de la empresa.</returns>
    ''' <remarks></remarks>
    Public Function getDatosEmpresa(ByVal empresaId As Integer) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@IdEmpresa"
            parametro.Value = empresaId
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarEmpresas", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Obtiene las Rutas de archivos para realizar el timbrado
    ''' </summary>
    ''' <returns>DataTable con la información de configuracion.</returns>
    ''' <remarks></remarks>
    Public Function getDatosConfiguracionTimbrado() As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_Configuracion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Guarda los errores obtenidos durante el timbrado de la factura.
    ''' </summary>
    ''' <param name="idDocumento">Documentod ID de la factura o Nota de Credito</param>
    ''' <param name="TipoComprobante">FACTURACALZADO, NOTACREDITO</param>
    ''' <param name="ClaveError">Clave del error del web services de timbrado</param>
    ''' <param name="DescripcionError">Descripcion del Error.</param>    
    ''' <remarks></remarks>
    Public Sub InsertarErrorAlTimbrar(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal ClaveError As String, ByVal DescripcionError As String)
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
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

            operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbre_RegistroErrores_Documento]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza los datos del timbrado del documento 
    ''' </summary>
    ''' <param name="idDocumento">DocumentoID</param>
    ''' <param name="FechaTimbrado">Fecha en que fue timbrado formato yyyy-mm-dd T HH:mm:ss</param>
    ''' <param name="UUID">uuid del timbrado del documento</param>
    ''' <param name="RutaXML">Ruta del XML del documento</param>
    ''' <param name="RutaPDF">Ruta PDF del documento</param>
    ''' <param name="FechaTimbradoDT">Fecha en que fue timbrado formato yyyy-mm-dd HH:mm:ss</param>
    ''' <param name="CadenaOriginal">Cadena Original del documento XML</param>
    ''' <param name="SelloSAT">Sello del SAT del documento XML</param>
    ''' <param name="SelloCFD">Sello CFD obtenido del documento XML</param>
    ''' <param name="SerieCertificadoSAT">Serie del certificado SAT del documento XML</param>
    ''' <param name="SerieCertificadoEmisor">Serie del certificado del emisor del codumento XML</param>
    ''' <param name="EmpresaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ActualizarInformacionDocumentoTimbrado(ByVal idDocumento As Integer, ByVal FechaTimbrado As String, ByVal UUID As String, ByVal RutaXML As String, ByVal RutaPDF As String, ByVal FechaTimbradoDT As String, ByVal CadenaOriginal As String, ByVal SelloSAT As String, ByVal SelloCFD As String, ByVal SerieCertificadoSAT As String, ByVal SerieCertificadoEmisor As String, ByVal EmpresaId As Integer, ByVal TipoComprobante As String, ByVal CadenaOriginalComplemento As String, ByVal RFCProveedor As String) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
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

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaOriginalComplemento"
            parametro.Value = CadenaOriginalComplemento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RFCProvedor"
            parametro.Value = RFCProveedor
            listaParametros.Add(parametro)


            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizarEncabezado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function





    Public Sub ActualizarInformacionTimbradoSICY(ByVal DocumentoID As Integer, ByVal SelloCFD As String, ByVal FechaTimbrado As Date, ByVal CadenaOriginal As String, ByVal NoCertificadoSAT As String, ByVal FolioFiscal As String, ByVal Año As Integer, ByVal TipoDocumento As String)
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@DocumentoID"
            parametro.Value = DocumentoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SelloCFD"
            parametro.Value = SelloCFD
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaTimbrado"
            parametro.Value = FechaTimbrado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CadenaOriginal"
            parametro.Value = CadenaOriginal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NoCertificado"
            parametro.Value = NoCertificadoSAT
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FolioFiscal"
            parametro.Value = FolioFiscal
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)


            operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizarSICY]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Obtiene el DocumentoID a partir del UUID
    ''' </summary>
    ''' <param name="UUID">UUID</param>
    ''' <param name="TipoComprobante">FacturaCalzado, NotaCredito</param>
    ''' <returns>Data table con la informacion del documentoID</returns>
    ''' <remarks></remarks>
    Public Function ObtenerDocumentoID_UUID(ByVal UUID As String, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@UUID"
            parametro.Value = UUID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerDocumentoIDUUID]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub ActualizarRutaPDFFactura(ByVal idDocumento As Integer, RutaPDF As String, ByVal TipoComprobante As String, ByVal RutaPDFSICY As String)
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos

            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@DocumentoId"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaPDF"
            parametro.Value = RutaPDF
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaPDFsicy"
            parametro.Value = RutaPDFSICY
            listaParametros.Add(parametro)

            operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizaRutaPDF]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub ActualizarRutaXMLFactura(ByVal idDocumento As Integer, RutaXML As String, ByVal TipoComprobante As String, ByVal RutaXMLSICY As String)
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos

            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@DocumentoId"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaXML"
            parametro.Value = RutaXML
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RutaXMLsicy"
            parametro.Value = RutaXMLSICY
            listaParametros.Add(parametro)

            operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizaRutaXML]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerClaveTipoComprobante(ByVal tipoComprobante As String) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As SqlParameter

            parametro = New SqlParameter With {
                .ParameterName = "TipoComprobante",
                .Value = tipoComprobante
            }
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Ventas.Sp_Facturacion_Timbrado_ObtenerClaveTipoComprobante", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizaDatosTimbradoNotasCreditoDevolucion(ByVal idDocumento As Integer, ByVal UUID As String, ByVal FechaTimbrado As String, ByVal RutaXML As String, ByVal RutaPDF As String, ByVal CadenaOriginal As String, ByVal SelloSAT As String, ByVal SelloCFD As String, ByVal SerieCertificadoSAT As String, ByVal TipoComprobante As String, ByVal CadenaOriginalComplemento As String, ByVal RFCProveedor As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@IdDocumento", idDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@selloCFDI", SelloCFD)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Uuid", UUID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaTimbrado", FechaTimbrado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RfcProvCertif", RFCProveedor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NoCertificadoSAT", SerieCertificadoSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SelloSAT", SelloSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@CadenaOriginal", CadenaOriginal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cadenaOriginalComplemento", CadenaOriginalComplemento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rutaTimbradoXML", RutaXML)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ActualizaInformacionFacturaNotaCredito]", listaParametros)
    End Function
    Public Sub actualizaInformacionTimbradaAtributos(ByVal idDocumento As Integer, tipoDocumento As String, ByVal UUID As String, ByVal FechaTimbrado As String, ByVal SelloCFD As String, ByVal SelloSAT As String, ByVal CadenaOriginal As String, ByVal SerieCertificadoSAT As String, ByVal CadenaOriginalComplemento As String, ByVal certificadoEmisor As String)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@documentoId", idDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoDocumento", tipoDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UUID", UUID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@fechaTimbrado", FechaTimbrado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@selloCFDI", SelloCFD)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@selloSAT", SelloSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cadenaOriginal", CadenaOriginal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@certificadoSAT", SerieCertificadoSAT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@cadenaOriginalComplemento", CadenaOriginalComplemento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@certificadoEmisor", certificadoEmisor)
        listaParametros.Add(parametro)

        objOperaciones.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ActualizaInfoTimbradoAtributo]", listaParametros)
    End Sub
End Class
