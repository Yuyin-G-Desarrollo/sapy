Imports System.Data.SqlClient

Public Class ReportesSuelaDA

    Public Function ObtenerConcentradoSuela(ByVal FechaPrograma As Date, ByVal IdNaves As String, ByVal IdUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaves"
        parametro.Value = IdNaves
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = IdUsuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtieneReporteProduccionConcentradoSuela]", listaparametros)

    End Function

    Public Function ObtenerDesglosadoSuela(ByVal FechaPrograma As Date, ByVal IdNaves As String, ByVal IdUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaves"
        parametro.Value = IdNaves
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = IdUsuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtieneReporteProduccionDesglosadoSuela]", listaparametros)

    End Function

    Public Function ObtenerProduccionSuela(ByVal FechaPrograma As Date, ByVal IdNaves As String, ByVal IdUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaPrograma"
        parametro.Value = FechaPrograma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNaves"
        parametro.Value = IdNaves
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = IdUsuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ObtieneReporteProduccionSuela]", listaparametros)

    End Function
End Class
