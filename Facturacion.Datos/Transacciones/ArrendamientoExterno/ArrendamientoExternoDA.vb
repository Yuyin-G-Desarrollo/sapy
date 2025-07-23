Imports System.Data.SqlClient
Public Class ArrendamientoExternoDA
    Public Function consultarListadoEmpresas(ByVal usuario As String, ByVal passwordMd5 As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "username"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "password"
        parametro.Value = passwordMd5
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Facturacion.SP_ArrendamientoExterno_ConsultaListadoEmpresas", listaParametros)
    End Function

    Public Function validaLogin(ByVal usuario As String, ByVal passwordMd5 As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT [Facturacion].[Fn_ArrendamientoExterno_ValidaLogin]('" & usuario & "', '" & passwordMd5 & "') AS Resultado"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaDatosEmpresa(ByVal empresaId As Integer, ByVal pruebas As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "empresaId"
        parametro.Value = empresaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pruebas"
        parametro.Value = pruebas
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Facturacion.SP_ArrendamientoExterno_ConsultaDatosEmpresa", listaParametros)
    End Function
End Class
