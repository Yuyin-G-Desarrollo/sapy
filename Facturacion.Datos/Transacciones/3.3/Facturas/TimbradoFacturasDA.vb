Imports System.Data.SqlClient

Public Class TimbradoFacturasDA

    Public Function ConsultarRutaPDFFactura(ByVal DocumentoID As String, TipoComprobante As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter With {
            .ParameterName = "@DocumentoId",
            .Value = DocumentoID
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@TipoComprobante",
            .Value = TipoComprobante
        }
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerRutaPDFDocumento]", listaParametros)

        Return dtResultadoConsulta

    End Function



    Public Function ObtenerRutaPDFFactura(ByVal DocumentoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_PDF_RutaDocumento]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ObtenerRutaXMLFactura(ByVal DocumentoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_XML_RutaDocumento]", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ObtenerRutaLogoEmpresa(ByVal EmpresaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_PDF_ObtenerLogoEmpresa]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function ObtenerEmpresaFactura(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ObtenerEmpresaIDFactura]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function GenerarInformacionTimbrado(ByVal DocumentoID As Integer, ByVal TipoDocumento As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoComprobante"
        parametro.Value = TipoDocumento
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_InsertarInformacion]", listaParametros)

    End Function

    Public Function ObtenerInformacionParesImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocumentoRemision_InformacionPares]", listaParametros)

    End Function

    Public Function ObtenerInformacionEncabezadoImpresion(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocumentoRemision_InformacionEncabezado]", listaParametros)

    End Function

    Public Function ObtenerDetalleAddenda(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Addenda_ConsultaInformacionPartidaTallas]", listaParametros)
    End Function


    Public Function ConsultarEncabezadoAddendaCOPPEL(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Addenda_ConsultaEncabezado]", listaParametros)

        Return dtResultadoConsulta

    End Function


    Public Function ConsultarRutasDocumento(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ObtenerRutaDocumento]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Function CancelarDocumentoSICY(ByVal RemisionID As Integer, ByVal Año As Integer, ByVal UUID As String, ByVal RutaXML As String, ByVal RutaPDF As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@RemisionID"
        parametro.Value = RemisionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
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

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_CancelacionDocumento_SICY]", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub ActualizarRutaDocumentoSICY(ByVal RemisionID As Integer, ByVal Año As Integer, ByVal RutaXML As String, ByVal RutaPDF As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@RemisionID"
        parametro.Value = RemisionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RutaXML"
        parametro.Value = RutaXML
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RutaPDF"
        parametro.Value = RutaPDF
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_ActualizarRutas_SICY]", listaParametros)


    End Sub

    Public Function ConsultarInformacionDocumentoFactura(ByVal DocumentoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_ObtenerInformacionDocumento]", listaParametros)

        Return dtResultadoConsulta

    End Function


    ''' <summary>
    ''' Obtiene la ruta del servidor REST
    ''' </summary>
    ''' <returns>Data table con la ruta del REST</returns>
    ''' <remarks></remarks>
    Public Function ObtenerRutaServidorREST() As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_Configuracion_ObtenerServidorREST]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Obtiene la ruta del servidor REST
    ''' </summary>
    ''' <returns>Data table con la ruta del REST</returns>
    ''' <remarks></remarks>
    Public Function ConsultarErroresTimbrado(ByVal DocumentoID As String, ByVal TipoComprobante As String) As DataTable
        Try
            Dim dtResultadoConsulta As New DataTable
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter

            parametro.ParameterName = "@DocumentoId"
            parametro.Value = DocumentoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoComprobante"
            parametro.Value = TipoComprobante
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ErroresTimbrado]", listaParametros)
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

    Public Function ValidarMontosDocumento(ByVal idDocumento As Integer, ByVal TipoComprobante As String) As DataTable
        Try
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


            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ValidarMontos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub RecalcularMontos(ByVal idDocumento As Integer)
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@DocumentoID"
            parametro.Value = idDocumento
            listaParametros.Add(parametro)

            operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_EnviarDocumentosSAY_RecalcularMontos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
