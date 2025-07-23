Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades

Public Class CatalogosDiasDA


    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de dias por filtro.
    '''</comentario> 
    '''<parametro1>Activo</parametro1> 
    '''<parametro2>Nombre del día</parametro2>
    '''<retorno>ejecusion de Consulta SQL para seleccionar Dias por filtro</retorno>
    Public Function ListaDias(ByVal activo As Boolean, ByVal nombreDia As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "  Select dias_diaid AS ID, UPPER(dias_nombre) as Nombre, dias_activo as Activo from  Framework.Dias "
        consulta += " Where dias_activo ='" + activo.ToString + "'"
        consulta += " AND dias_nombre like '%" + nombreDia + "%'"
        consulta += " Order by Nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para dar de alta un registro de días.
    '''</comentario> 
    '''<parametro1>Nombre del día</parametro1> 
    '''<parametro2>Activo</parametro2>
    '''<parametro3>Id del usuario que creo el registro</parametro3>
    Public Sub AltaDias(ByVal Dias As Entidades.CatalogosDias)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@dias_nombre"
        parametro.Value = Dias.PNombreDia
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dias_activo"
        parametro.Value = Dias.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dias_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Agregar_Dia", listaparametros)
    End Sub


    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para actualizar un registro de días.
    '''</comentario> 
    '''<parametro1>Id del dia a actualizar</parametro1> 
    '''<parametro1>Nombre del día</parametro1> 
    '''<parametro2>Activo</parametro2>
    '''<parametro3>Id del usuario que modifico</parametro3>
    Public Sub EditarDias(ByVal Dias As Entidades.CatalogosDias)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@dias_diaid"
        parametro.Value = Dias.PIdDia

        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dias_nombre"
        parametro.Value = Dias.PNombreDia
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dias_activo"
        parametro.Value = Dias.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@dias_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Dias", listaparametros)


    End Sub


    

End Class
