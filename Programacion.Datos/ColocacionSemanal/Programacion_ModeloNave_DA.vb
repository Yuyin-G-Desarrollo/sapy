Imports System.Data.SqlClient

Public Class Programacion_ModeloNave_DA
    Public Function ObtenerModelosNoAsignadosPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveIdSAY"
        parametro.Value = IdNaveSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ConsultaModelosNoAsignadosNave]", listaParametros)

    End Function
    Public Sub InsertarModelosNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdModelos As String)
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
        parametro.ParameterName = "@ModelosIdSAY"
        parametro.Value = IdModelos
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_InsertarModeloNave]", listaParametros)

    End Sub
    Public Function ConsultarModelosAsignadosPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
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

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ConsultarModelosAsignadosPorNave]", listaParametros)

    End Function
    Public Sub EditarModelosAsignadosPorNave(ByVal pXmlCeldas As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaparametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ActualizaModeloNave]", listaparametros)

    End Sub
End Class
