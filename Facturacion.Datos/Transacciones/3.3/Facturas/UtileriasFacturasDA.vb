Imports System.Data.SqlClient

Public Class UtileriasFacturasDA


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

   
End Class
