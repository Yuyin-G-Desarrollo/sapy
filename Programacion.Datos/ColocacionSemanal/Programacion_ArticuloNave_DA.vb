Imports System.Data.SqlClient

Public Class Programacion_ArticuloNave_DA
    Public Function ObtenerArticulosNoAsignadasPorNave(ByVal IdNaveSay As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveIdSAY"
        parametro.Value = IdNaveSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ConsultaArticulosNoAsignadosNave]", listaParametros)

    End Function
    Public Sub InsertarArticulosNave(ByVal UsuarioId As Integer, ByVal IdNaveSay As Integer, ByVal IdArticulos As String, ByVal Fecha As Date, ByVal SiguienteFechaAsignar As Date, ByVal GuardarFechaAsignar As Boolean)
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
        parametro.ParameterName = "@ArticulosIdSAY"
        parametro.Value = IdArticulos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProgramarDesde"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SiguienteFechaAsignar"
        parametro.Value = SiguienteFechaAsignar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@GuardarFechaAsignar"
        parametro.Value = GuardarFechaAsignar
        listaParametros.Add(parametro)



        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_InsertarArticuloNave]", listaParametros)

    End Sub
    Public Function ConsultarArticulosAsignadasPorNave(ByVal IdNaveSay As Integer, ByVal Activo As Integer) As DataTable
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

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ConsultarArticulosAsignadosPorNave]", listaParametros)

    End Function
    Public Sub EditarPrioridadArticulos(ByVal pXmlCeldas As String, ByVal activo As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = activo
        listaparametros.Add(parametro)
        Dim consulta As DataTable = objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ActualizaPrioridadArticuloNave]", listaparametros)

    End Sub
    Public Sub DesasignarArticulosNave(ByVal pXmlCeldas As String, ByVal Fecha As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaDesasignacion"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_DesasignarArticuloNave]", listaParametros)

    End Sub
    Public Sub TransferirArticulosNave(ByVal IdNuevaNave As Integer, ByVal pXmlCeldas As String, ByVal FechaHasta As Date, ByVal FechaDesde As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveNuevaIdSAY"
        parametro.Value = IdNuevaNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaHasta"
        parametro.Value = FechaHasta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaDesde"
        parametro.Value = FechaDesde
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_TransferirArticuloNave]", listaParametros)

    End Sub
    Public Sub EditarArticulosNave(ByVal pXmlCeldas As String, ByVal Fecha As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProgramarDesde"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_EditarArticuloNave]", listaParametros)

    End Sub
    Public Function ValidarFecha(ByVal pXmlCeldas As String, ByVal Fecha As Date, ByVal tipoFecha As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Fecha"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoFecha"
        parametro.Value = tipoFecha
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Programacion_ValidarFechaProgramacion]", listaParametros)
    End Function
End Class
