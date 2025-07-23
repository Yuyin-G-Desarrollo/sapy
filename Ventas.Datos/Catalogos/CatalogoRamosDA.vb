
Imports System.Data.SqlClient

Public Class CatalogoRamosDA

    ''Consultar los datos de los Ramos
    Public Function ListaRamos(ByVal Activo As Boolean, Nombre As String, NombreCorto As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = " Select ramo_ramoid as Id" +
            ", UPPER(ramo_nombre) as Nombre" +
            ", UPPER(ramo_nombrecorto) as Nombre_corto" +
            ", ramo_activo as Estado" +
            ", ramo_ramoidsicy as SicyID" +
            " FROM cliente.Ramos" +
            " where ramo_nombre like '%" + Nombre + "%'  " +
            " and ramo_nombrecorto like '%" + NombreCorto + "%'" +
            " and ramo_activo = '" + Activo.ToString + "' Order By Nombre"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''Consultar los datos de los Ramos
    Public Function ListaRamos_Sicy() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT IdRamo, Ramo FROM Ramos"

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    ''Procedimiento para alta de Materiales
    Public Sub AltaRamos(ByVal Ramos As Entidades.CatalogoRamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ramo_nombre"
        parametro.Value = Ramos.PRamoNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_nombrecorto"
        parametro.Value = Ramos.PRamoNombreCorto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_activo"
        parametro.Value = Ramos.PRamoActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_sicyid"
        parametro.Value = Ramos.PRamoSicyID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        ''Ejecutamos procedimiento almacenado.
        operaciones.EjecutarSentenciaSP("Cliente.SP_Alta_Ramos", listaparametros)
    End Sub

    ''Procedimiento para actualizar datos de dias.
    Public Sub editarRamos(ByVal Ramos As Entidades.CatalogoRamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ramo_ramoid"
        parametro.Value = Ramos.PRamoId

        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_nombre"
        parametro.Value = Ramos.PRamoNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_nombrecorto"
        parametro.Value = Ramos.PRamoNombreCorto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_activo"
        parametro.Value = Ramos.PRamoActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_sicyid"
        parametro.Value = Ramos.PRamoSicyID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ramo_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_Ramos", listaparametros)


    End Sub


End Class
