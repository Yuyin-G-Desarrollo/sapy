Imports System.Data.SqlClient

Public Class FacturasDA
    Public Function getDatosEmpresa(ByVal empresaId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

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

End Class
