Imports System.Data.SqlClient

Public Class VigenciaArticulosDA


    Public Function ObtenerInformacionArticulos(ByVal FMarca As String, ByVal FColeccion As String,
                                               ByVal TipoEstatusArticulo As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FMarca", FMarca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FColeccion", FColeccion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoEstatusArticulo", TipoEstatusArticulo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VigenciaArticulos_ObtieneListaArticulos]", listaParametros)

    End Function

    Public Function GuardarFechaVigencia_ArticulosSeleccionados(ByVal ProductoEstilosSeleccionados As String, ByVal FechaVigencia As Date, ByVal Observaciones As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstilosSeleccionados", ProductoEstilosSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaVigencia", FechaVigencia)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Observaciones", Observaciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VigenciaArticulos_AltaEdicionFechaVigencia]", listaParametros)

    End Function


    Public Function ObtieneArticulos_FechaVigencia() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VigenciaArticulos_ObtieneArticulosConFechaVigencia]", listaParametros)
    End Function

    Public Function RevertirFechaVigencia_ArticulosSeleccionados(ByVal productoEstiloSeleccionados As String, ByVal usuario As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstilosSeleccionados", productoEstiloSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", usuario)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VigenciaArticulos_RevertirFechaVigencia]", listaParametros)

    End Function

    Public Function CancelarSolicitudVencimiento(ByVal ProductoEstiloSeleccionados As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstilosSeleccionados", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_VigenciaArticulos_CancelarSolicitudVencimiento]", listaParametros)
    End Function

End Class
