Imports Entidades
Imports System.Data.SqlClient
Public Class Programacion_FamiliaNave_DA
    Public Function ObtenerFamiliasNoAsignadasPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveIdSAY"
        parametro.Value = IdNaveSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ConsultaFamiliasNoAsignadasNave]", listaParametros)

    End Function
    Public Sub InsertarFamiliasNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdFamilias As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveIdSAY"
        parametro.Value = IdNaveSay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FamiliasIdSAY"
        parametro.Value = IdFamilias
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_InsertarFamiliaNave]", listaParametros)

    End Sub
    Public Function ConsultarFamiliasAsignadasPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveIdSAY"
        parametro.Value = IdNaveSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ConsultarFamiliasAsignadasPorNave]", listaParametros)

    End Function
    Public Sub EditarFamiliasAsignadasPorNave(ByVal pXmlCeldas As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ActualizaFamiliaNave]", listaparametros)

    End Sub
End Class
