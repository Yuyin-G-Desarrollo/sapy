Imports System.Data.SqlClient

Public Class CatalogoClasificacionClienteDA


    ''Funcion para consultar los datos de la tabla rutas y enviarlos al grid
    Public Function ListaClasificacionClientes(ByVal activo As Boolean, ByVal NombreClasificacion As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "Select clas_clasificacioclientenid As Id" +
            ", UPPER(clas_nombre) AS Nombre " +
            ", clas_ranking AS Ranking" +
            ", clas_activo AS Activo" +
            " FROM Cliente.Clasificaciones" +
            " WHERE clas_nombre LIKE '%" + NombreClasificacion + "%' " +
            " AND clas_activo ='" + activo.ToString + "' Order By Nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaValidarExistencia(ByVal IdClasificacion As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("Select clas_nombre from Cliente.Clasificaciones " +
                                           " where clas_clasificacioclientenid = '" + IdClasificacion + "'")
    End Function

    ''metodo para agregar 
    Public Sub AgregarClasificacionCLiente(ByVal ClasificacionCliente As Entidades.CatalogoClasificacionesCliente)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clas_clasificacioclientenid"
        parametro.Value = ClasificacionCliente.PIdClasificacion
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clas_nombre"
        parametro.Value = ClasificacionCliente.PNombre
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clas_activo"
        parametro.Value = ClasificacionCliente.PActivo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clas_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Cliente.SP_Alta_ClasificacionesCientes", ListaParametros)

    End Sub

    ''MEtodo para editar
    Public Sub EditarClasificacionCliente(ByVal ClasificacionCliente As Entidades.CatalogoClasificacionesCliente)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@clas_nombre"
        parametro.Value = ClasificacionCliente.PNombre
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clas_clasificacioclientenid"
        parametro.Value = ClasificacionCliente.PIdClasificacion
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clas_activo"
        parametro.Value = ClasificacionCliente.PActivo
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clas_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParmetros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_ClasificacionesClientes", listaParmetros)

    End Sub


End Class
