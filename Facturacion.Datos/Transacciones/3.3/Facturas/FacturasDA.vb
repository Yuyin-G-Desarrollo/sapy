Imports System.Data.SqlClient

Public Class FacturasDA
    Public Function getDatosEmpresa(ByVal empresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdEmpresa"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarEmpresas", listaParametros)
        'Return operacion.EjecutaConsulta("EXEC Ventas.SP_Facturacion_ConsultarEmpresas")

        'consulta = "SELECT * " & _
        '   "FROM Framework.Empresas e "
        'Return operacion.EjecutaConsulta(consulta)

    End Function
    Public Function getDatosDocumento(ByVal idDocumento As Integer, ByVal tipoNodo As String, ByVal TipoComprobante As String) As DataTable
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
        parametro.ParameterName = "@tipoNodo"
        parametro.Value = tipoNodo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarDocumento", listaParametros)
    End Function
    Public Function getDatosDocumentoNumConceptos(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
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

        Return operacion.EjecutarConsultaSP("Ventas.SP_Facturacion_ConsultarDocumentoNumConceptos", listaParametros)
    End Function
    Public Function getDatosDocumentoConcepto(ByVal idDocumento As Integer, ByVal idConcepto As Integer, ByVal tipoNodo As String, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
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
    End Function

    Public Function ObtenerTipoComprobante(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)    

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerTipoComprobante]", listaParametros)
    End Function


    Public Function InsertarErrorAlTimbrar(ByVal idDocumento As Integer, ByVal TipoComprobante As String, ByVal ClaveError As String, ByVal DescripcionError As String) As DataTable
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

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbre_RegistroErrores_Documento]", listaParametros)
    End Function


    Public Function ObtenerTotalesDocumento(ByVal idDocumento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ValidarMontos]", listaParametros)
    End Function

    Public Function ActualizarInformacionDocumentoTimbrado(ByVal idDocumento As Integer, ByVal FechaTimbrado As String, ByVal UUID As String, ByVal RutaXML As String, ByVal RutaPDF As String, ByVal FechaTimbradoDT As String, ByVal CadenaOriginal As String, ByVal SelloSAT As String, ByVal SelloCFD As String, ByVal SerieCertificadoSAT As String, ByVal SerieCertificadoEmisor As String, ByVal EmpresaId As Integer) As DataTable
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

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizarEncabezado]", listaParametros)
    End Function


    Public Function ObtenerRutaArchivos(ByVal EmpresaID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_ObtenerRutaArchivos]", listaParametros)
    End Function


    Public Function ObtenerCFDIRelacionadosDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = idDocumento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerCFDIRelacionados]", listaParametros)
    End Function

    Public Function ObtenerRutaXMLSICY(ByVal EmpresaID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_XML_RutaSICY]", listaParametros)
    End Function

    Public Function ObtenerRutaPDFSICY(ByVal EmpresaID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_PDF_RutaSICY]", listaParametros)
    End Function

    Public Sub ActualizarInformacionCancelacionFactura(ByVal DocumentoID As Integer, ByVal FechaCancelacion As String, ByVal UsuarioCanceloID As Integer, ByVal TipoComprobante As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaCancelacion"
        parametro.Value = FechaCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCanceloID"
        parametro.Value = UsuarioCanceloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Cancelacion_ActualizarInformacion]", listaParametros)
    End Sub


    Public Sub ActualizarFacturaNoCancelada(ByVal DocumentoID As Integer, ByVal TipoComprobante As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoComprobante
        listaParametros.Add(parametro)


        operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Cancelacion_ActualizarFacturaNoCancelada]", listaParametros)

    End Sub

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClaveEnvio"
        parametro.Value = ClaveEnvio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDatosCorreosFacturacion", listaParametros)

    End Function


    Public Function consultaDatosDocumentoEnvioFactura(ByVal DocumentoId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "DocumentoId"
        parametro.Value = DocumentoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultarDatosEnvioCorreoPorDocumento", listaParametros)

    End Function

    Public Sub InsertarDatosCorreoEnviadoSICY(ByVal EnviadoA As String, ByVal Enviado As String, ByVal Usuario As String, ByVal Asunto As String, ByVal MotivoNoEnvio As String, ByVal RemisionId As Integer, ByVal TipoArchivo As String, ByVal Reenviado As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@enviadoA"
        parametro.Value = EnviadoA
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Enviado"
        parametro.Value = Enviado
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Usuario
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Asunto"
        parametro.Value = Asunto
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@MotivoNoEnvio"
        parametro.Value = MotivoNoEnvio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Remision"
        parametro.Value = RemisionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoArchivo"
        parametro.Value = TipoArchivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Reenviado"
        parametro.Value = Reenviado
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Correo_InsertarDatosEnvio]", listaParametros)

    End Sub

    Public Sub ActualizarStatusCorreoEnviadoSAY(ByVal DocumentoID As Integer, ByVal CorreoEnviado As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CorreoEnviado"
        parametro.Value = CorreoEnviado
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ActualizarStatusCorreo]", listaParametros)

    End Sub

    Public Function InformacionCorreoEnvioFacturacion() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Try


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_FacturacionCalzado_InformacionEnvioCorreo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerInformacionCorreoFacturacion(ByRef IdUnico As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@IdUnico"
            parametro.Value = IdUnico
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_FacturacionCalzado_ObtenerInformacionDocumento]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function ActualizarDoctosElectronicos(ByRef IdUnico As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@IdUnico"
            parametro.Value = IdUnico
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_EnvioCorreo_ActualizaCorreoEnviadoDoctosElectronicos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function InsertarLogMailDoctosElectronicos(ByRef IdUnico As Integer, ByVal EnviadoA As String, ByVal Enviado As String, ByVal Usuario As String, ByVal Asunto As String, ByVal MotivoNoenvio As String, ByVal remision As Integer, ByVal TipoArchivo As String, ByVal Reenviado As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@IdUnico"
            parametro.Value = IdUnico
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@enviadoA"
            parametro.Value = EnviadoA
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Enviado"
            parametro.Value = Enviado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Usuario"
            parametro.Value = Usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Asunto"
            parametro.Value = Asunto
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MotivoNoEnvio"
            parametro.Value = MotivoNoenvio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Remision"
            parametro.Value = remision
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoArchivo"
            parametro.Value = TipoArchivo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Reenviado"
            parametro.Value = Reenviado
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Correo_InsertarDatosEnvioReenvio]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function getNombreDocumento(ByVal DocumentoID As Integer, ByVal RFC As String, ByVal Folio As String, ByVal Serie As String, ByVal TipoComprobante As String, ByVal TipoDocumento As String, ByVal DocumentoCancelado As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@DocumentoID", DocumentoID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RFC", RFC)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Folio", Folio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Serie", Serie)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoComprobante", TipoComprobante)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoDocumento", TipoDocumento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DocumentoCancelado", DocumentoCancelado)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Facturacion.SP_getNombreDocumento", listaParametros)
    End Function

    Public Sub CancelarFacturaProductoTerminadoSICY(ByVal DocumentoID As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoIdSAY"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("[Proveedores].[SP_ComprasPT_CancelacionFactura]", listaParametros)
    End Sub

End Class
