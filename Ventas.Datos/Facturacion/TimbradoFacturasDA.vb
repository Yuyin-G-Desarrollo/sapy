Imports System.Data.SqlClient

Public Class TimbradoFacturasDA

    Public Function ConsultarRutaPDFFactura(ByVal DocumentoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DocumentoId"
        parametro.Value = DocumentoID
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
End Class
