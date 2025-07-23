Imports System.Data.SqlClient

Public Class CatalogoRequerimientosEspecialesDA

    Public Function listaRequerimientosEspeciales(Nombre As String, tipo As String, ByVal Activo As Boolean)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = "Select rees.rees_requerimientoespecialid as ID, " +
            "UPPER(rees.rees_nombre) as Nombre, " +
            "rees.rees_tiporequerimientoespecialid as Id_Tipo, " +
            "UPPER(tres.tres_nombre) as Tipo, " +
            "rees.rees_activo as Activo " +
            "From ventas.RequerimientoEspecial rees " +
            "INNER JOIN ventas.TipoRequerimientoEspecial tres " +
            " ON rees.rees_tiporequerimientoespecialid = tres.tres_tiporequerimientoespecialid " +
            " WHERE rees.rees_nombre like '%" + Nombre + "%' " +
            " AND rees.rees_activo = '" + Activo.ToString + "'" +
            " AND  tres.tres_nombre like '%" + tipo + "%' order by Nombre"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    'Consulta para llenar el combobox con el tipo de materiales
    Public Function ListaTipoRequerimiento() As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "Select tres_tiporequerimientoespecialid as ID, UPPER(tres_nombre) as Nombre from ventas.TipoRequerimientoEspecial "
        consulta += " ORDER BY tres_nombre"
        Return opereciones.EjecutaConsulta(consulta)
    End Function

    ''Procedimiento para alta 
    Public Sub AltaRequerimientos(ByVal Requerimiento As Entidades.CatalogoRequerimientosEspeciales)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@rees_nombre"
        parametro.Value = Requerimiento.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_tiporequerimientoespecialid"
        parametro.Value = Requerimiento.PIdTipo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_activo"
        parametro.Value = Requerimiento.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_RequerimientoEspecial", listaparametros)
    End Sub

    ''Procedimiento para actualizar
    Public Sub editarRequerimiento(ByVal Requerimiento As Entidades.CatalogoRequerimientosEspeciales)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@rees_requerimientoespecialid"
        parametro.Value = Requerimiento.PIdRequerimiento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_nombre"
        parametro.Value = Requerimiento.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_tiporequerimientoespecialid"
        parametro.Value = Requerimiento.PIdTipo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_activo"
        parametro.Value = Requerimiento.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@rees_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_RequerimientoEspecial", listaparametros)


    End Sub

End Class
