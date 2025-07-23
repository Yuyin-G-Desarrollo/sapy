Imports System.Data.SqlClient

Public Class CatalogoTiposDeTiendaDA

    ''Funcion para consultar los datos de la tabla rutas y enviarlos al grid
    Public Function ListaTipoTiendas(activo As Boolean, ByVal NombreTipoTienda As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT titi_tipotiendaid AS ID" +
                ", UPPER(titi_nombre) AS Nombre" +
                ", titi_activo AS Activo" +
                " FROM Cliente.TipoTienda" +
                " WHERE titi_nombre LIKE '%" + NombreTipoTienda + "%'" +
                " AND titi_activo ='" + activo.ToString + "' order by Nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''metodo para agregar rutas
    Public Sub AgregarTipoTienda(ByVal Tiendas As Entidades.CatalogoTiposDeTienda)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@titi_nombre"
        parametro.Value = Tiendas.PNombreTipoTienda
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@titi_activo"
        parametro.Value = Tiendas.PActivo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@titi_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Cliente.SP_Alta_TipoTienda", ListaParametros)

    End Sub

    ''MEtodo para editar
    Public Sub EditarTipoTiendas(ByVal Tiendas As Entidades.CatalogoTiposDeTienda)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@titi_nombre"
        parametro.Value = Tiendas.PNombreTipoTienda
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@titi_activo"
        parametro.Value = Tiendas.PActivo
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@titi_tipotiendaid"
        parametro.Value = Tiendas.PIdTipoTienda
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@titi_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParmetros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_TipoTienda", listaParmetros)

    End Sub
End Class
