
Imports System.Data.SqlClient

Public Class CatalogoRutasDA

    ''Funcion para consultar los datos de la tabla rutas y enviarlos al grid
    Public Function ListaRutas(ByVal nombreRuta As String, activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT ruta_rutaid AS Id" +
                    ", UPPER(ruta_nombre) as Nombre" +
                    ", ruta_activo as Activo" +
                    " FROM Ventas.Rutas" +
                    " WHERE ruta_nombre LIKE '%" + nombreRuta + "%'" +
                    " AND  ruta_activo = '" + activo.ToString + "' order by Nombre"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    ''metodo para agregar rutas
    Public Sub AltaRutas(ByVal Rutas As Entidades.CatalogoRutas)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ruta_nombre"
        parametro.Value = Rutas.PNombreRuta
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ruta_activo"
        parametro.Value = Rutas.PActivo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ruta_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_Rutas", ListaParametros)

    End Sub

    ''MEtodo para editar
    Public Sub EditarRutas(ByVal Rutas As Entidades.CatalogoRutas)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParmetros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ruta_nombre"
        parametro.Value = Rutas.PNombreRuta
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ruta_activo"
        parametro.Value = Rutas.PActivo
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ruta_rutaid"
        parametro.Value = Rutas.PRutaId
        listaParmetros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ruta_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParmetros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_Rutas", listaParmetros)

    End Sub


End Class
