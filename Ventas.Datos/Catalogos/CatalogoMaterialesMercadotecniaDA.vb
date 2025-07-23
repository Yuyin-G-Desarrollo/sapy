Imports System.Data.SqlClient

Public Class CatalogoMaterialesMercadotecniaDA

    ''Consultar los datos de los productos Mercadotecnia
    Public Function ListaMaterialesMercadotecnia(ByVal Activo As Boolean, Nombre As String, tipo As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "  select mame.mame_materialmercadotecniaid as Id, " +
            "tmme_tipomaterialmercadotecniaid, " +
            "Upper(LTRIM(RTRIM(mame.mame_nombre))) as Nombre, " +
            "Upper(LTRIM(RTRIM(tmme.tmme_nombre))) as Tipo, " +
            "mame.mame_activo as Estado " +
            "From ventas.MaterialMercadotecnia mame " +
            "Inner Join ventas.TipoMaterialMercadotecnia tmme " +
            "on mame.mame_tipomaterialmercadotecniaid = tmme.tmme_tipomaterialmercadotecniaid " +
            "where  mame.mame_nombre  like  '%" + Nombre + "%' " +
            "And mame.mame_activo = '" + Activo.ToString + "'" +
            " And tmme.tmme_nombre like '%" + tipo + "%' Order by Nombre"


        Return operaciones.EjecutaConsulta(consulta)

    End Function

    'Consulta para llenar el combobox con el tipo de materiales
    Public Function ListaTipoMateriales() As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "Select tmme_tipomaterialmercadotecniaid, Upper(LTRIM(RTRIM(tmme_nombre))) as tmme_nombre " +
                                            " from ventas.TipoMaterialMercadotecnia"
        consulta += " ORDER BY tmme_nombre"
        Return opereciones.EjecutaConsulta(consulta)
    End Function

    ''Procedimiento para alta de Materiales
    Public Sub AltaMateriales(ByVal Materiales As Entidades.CatalogoMaterialesMercadotecnia)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@mame_nombre"
        parametro.Value = Materiales.PmameNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_tipomaterialmercadotecniaid"
        parametro.Value = Materiales.PmameTipoId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_activo"
        parametro.Value = Materiales.Pmameactivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_MaterialesMercadotecnia", listaparametros)
    End Sub

    ''Procedimiento para actualizar datos de dias.
    Public Sub editarMateriales(ByVal Materiales As Entidades.CatalogoMaterialesMercadotecnia)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@mame_materialmercadotecniaid"
        parametro.Value = Materiales.PmameID

        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_nombre"
        parametro.Value = Materiales.PmameNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_tipomaterialmercadotecniaid"
        parametro.Value = Materiales.PmameTipoId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_activo"
        parametro.Value = Materiales.Pmameactivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mame_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_MaterialesMercadotecnia", listaparametros)


    End Sub



End Class
