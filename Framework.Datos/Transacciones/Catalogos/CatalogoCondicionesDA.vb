Imports System.Data.SqlClient


Public Class CatalogoCondicionesDA

    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de los tipos de Politica(condicion).
    '''<retorno>ejecusion de Consulta SQL para seleccionar todas las condiciones existentes</retorno>
    '''</comentario> 
    Public Function ListaTipoCondicion() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = " select tico_tipocondicionid as Id, UPPER(LTRIM(RTRIM(tico_nombre))) as Tipo, tico_activo as Activo " +
            " From Framework.TipoCondicion  order by Tipo"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de las politicas(condiciones).
    '''</comentario> 
    '''<parametro1>IdTipo, que este parametro es la llave foranea que coneta con la tabla TipoCondicion</parametro1>
    '''<retorno>Ejecusion de Consulta SQL para seleccionar las condiciones que pertenecen a cierto tipo de politica.</retorno>
    Public Function ListaCondicion(ByVal IdTipo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "Select cond_condicionid as Id, upper(cond_nombre) as Nombre, cond_activo as Activo " +
            " From Framework.Condicion " +
            " where cond_tipocondicionid = " + IdTipo.ToString +
            " order by Nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de los catalogos por politica(condicion).
    '''</comentario> 
    '''<parametro1>IdCondicion, que este parametro es la llave foranea que coneta con la tabla Condicion</parametro1>
    '''<retorno>Ejecusion de Consulta SQL para seleccionar los catalogos que pertenencen a cierto tipo de condicion.</retorno>
    Public Function ListaCondicionCatalogo(ByVal IdCondicion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "Select  coca_condicioncatalogoid As Id, " +
            "upper(coca_descripcion) as Descripción, " +
            "coca_opciondefault as Opción_Default, " +
            "coca_activo as Activo " +
            "From Framework.CondicionCatalogo " +
            "where coca_condicionid = " + IdCondicion.ToString +
            " order by Descripción"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de las areas operativas en las que se aplica la condicion.
    '''</comentario> 
    '''<parametro1>IdTipo, que este parametro es la llave foranea que coneta con la tabla TipoCondicion</parametro1>
    '''<retorno>Ejecusion de Consulta SQL para seleccionar las areas en las que aplica la condicion</retorno>
    Public Function ListaAreaOperativa(ByVal IdCondicion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT arop.arop_areaoperativaid as Id , coao_activo as ' ' , arop.arop_nombre as 'Área Operativa'" +
            ", coao.coao_controla as 'Controla?' , arop.arop_activo as Activo" +
            " FROM Framework.AreaOperativa arop" +
            " INNER JOIN framework.CondicionAreaOperativa coao on arop.arop_areaoperativaid = coao.coao_areaoperativaid" +
            " where coao_condicionid = " + IdCondicion.ToString + " and coao_activo = 1 AND arop.arop_activo = 1 UNION ALL SELECT arop.arop_areaoperativaid as Id , 0 as ' ' , arop.arop_nombre as 'Área Operativa'," +
            " 0 as 'Controla?' , arop.arop_activo as Activo  " +
            "FROM Framework.AreaOperativa arop " +
            "where arop.arop_areaoperativaid NOT IN(SELECT arop.arop_areaoperativaid as id  FROM Framework.AreaOperativa arop " +
            "INNER JOIN framework.CondicionAreaOperativa coao on arop.arop_areaoperativaid = coao.coao_areaoperativaid " +
            "where coao_condicionid = " + IdCondicion.ToString + " and coao_activo = 1 AND arop.arop_activo = 1) and arop.arop_activo = 1 ORDER BY arop_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de las areas operativas en las que se aplica la condicion 
    ''' para llenarlas en la tabla de consulta.
    '''</comentario> 
    '''<parametro1>IdTipo, que este parametro es la llave foranea que coneta con la tabla TipoCondicion</parametro1>
    '''<retorno>Ejecusion de Consulta SQL para seleccionar las areas en las que aplica la condicion</retorno>
    Public Function ListaAreaOperativaConsulta(ByVal IdCondicion As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "Select coao.coao_condicionareaoperativaid as Id" +
            ", upper(arop.arop_nombre) as Área_operativa" +
            ", upper(coao.coao_controla) as Controla" +
            ", coao.coao_activo as Activo" +
            ", 1 as seleccionar " +
            " From Framework.CondicionAreaOperativa as coao " +
            " INNER JOIN framework.AreaOperativa as arop on arop.arop_areaoperativaid = coao.coao_areaoperativaid " +
            " where coao_condicionid = " + IdCondicion.ToString + " AND coao_activo = 1 order by Área_operativa"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Funcion que realiza la consulta del Tipo de condicion y de la tabal condicion.
    '''</comentario> 
    '''<retorno>Ejecusion de Consulta SQL para seleccionar </retorno>
    Public Function ListaCatalogoCondiciones() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "Select tico_tipocondicionid as Id, LTRIM(RTRIM(tico_nombre)) as Tipo,cond_condicionid as Id_Política," +
            " LTRIM(RTRIM(cond_nombre))as Política,coca_condicioncatalogoid as IdCatalogo, null as Catalogo, null as Área_Operativa" +
            ", cond_Activo as Activo from Framework.TipoCondicion JOIN Framework.Condicion on cond_tipocondicionid = tico_tipocondicionid " +
            " JOin Framework.CondicionCatalogo on coca_opciondefault = 1 AND coca_condicionid = cond_condicionid UNION ALL Select tico_tipocondicionid as Id" +
            ", LTRIM(RTRIM(tico_nombre)) as Tipo, cond_condicionid as Id_Política, LTRIM(RTRIM(cond_nombre))as Política, 0 as IdCatalogo, null as Catalogo," +
            " null as Área_Operativa, cond_Activo as Activo from Framework.TipoCondicion" +
            " JOIN Framework.Condicion on cond_tipocondicionid = tico_tipocondicionid WHERE Condicion.cond_condicionid NOT IN (Select cond_condicionid" +
            " from Framework.TipoCondicion JOIN Framework.Condicion on cond_tipocondicionid = tico_tipocondicionid " +
            " JOin Framework.CondicionCatalogo on coca_opciondefault = 1 AND coca_condicionid = cond_condicionid) ORDER BY tIPO ,Política "
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    '''<comentario> 
    ''' Funcion que realiza la consulta del Tipo de condicion y de la tabal condicion.
    '''</comentario> 
    '''<retorno>Ejecusion de Consulta SQL para seleccionar </retorno>
    Public Function ConteoCatalogoClientes(ByVal IdCatalogo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "select count (a.cope_condicioncatalogoid) as Existe from Framework.CondicionPersona as a" +
            " where cope_condicioncatalogoid = " + IdCatalogo.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para dar de alta un registro de TipoCondicion.
    '''</comentario> 
    '''<parametro1>Nombre, Nombre de la condicion(Politica)</parametro1> 
    '''<parametro2>Activo, Estado Activo/Inactivo</parametro2>
    '''<parametro3>Id del usuario que creo el registro</parametro3>
    Public Sub AltaTipo(ByVal TipoCondicion As Entidades.CatalogoCondicionesTipo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@tico_nombre"
        parametro.Value = TipoCondicion.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_activo"
        parametro.Value = TipoCondicion.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_TipoCondicion", listaparametros)
    End Sub

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para actualizar un registro de "TipoCondicion".
    '''</comentario> 
    '''<parametro1>Id, del tipo de condicion para identificar que esa sera modificada</parametro1> 
    '''<parametro1>Nombre</parametro1> 
    '''<parametro2>Activo, Estado Activo/Inactivo del registro</parametro2>
    '''<parametro3>Id del usuario que modifico</parametro3>
    Public Sub EditarTipo(ByVal TipoCondicion As Entidades.CatalogoCondicionesTipo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@tico_tipocondicionid"
        parametro.Value = TipoCondicion.PIdTipo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_nombre"
        parametro.Value = TipoCondicion.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_activo"
        parametro.Value = TipoCondicion.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tico_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_TipoCondicion", listaparametros)
    End Sub

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para dar de alta una condicion.
    '''</comentario> 
    '''<parametro1>PNombre, Nombre de la condicion(Politica)</parametro1> 
    '''<parametro2>IdTIpo, Tipo de condicion</parametro2>
    '''<parametro3>PActivo, Estado Activo/Inactivo</parametro3>
    ''' '''<parametro4>Id del usuario que creo el registro</parametro4>
    Public Sub AltaCondicion(ByVal Condicion As Entidades.CatalogoCondicionesCondicion)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cond_nombre"
        parametro.Value = Condicion.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_tipocondicionid"
        parametro.Value = Condicion.PIdTipo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_activo"
        parametro.Value = Condicion.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Condicion", listaparametros)
    End Sub

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para actualizar un registro de la tabla "Condicion".
    '''</comentario> 
    '''<parametro1>PIdCondicion... del tipo de condicion para identificar que esa sera modificada</parametro1> 
    '''<parametro2>PNombre... NOmbre de la condicion</parametro2> 
    '''<parametro3>PIdTipo, Llave foranea que enlasa con la tabla TipoCondicion</parametro3>
    '''<parametro4>Id del usuario que modifico</parametro4>
    Public Sub EditarCondicion(ByVal Condicion As Entidades.CatalogoCondicionesCondicion)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cond_condicionid"
        parametro.Value = Condicion.PIdCondicion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_nombre"
        parametro.Value = Condicion.PNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_tipocondicionid"
        parametro.Value = Condicion.PIdTipo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_activo"
        parametro.Value = Condicion.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cond_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Condicion", listaparametros)
    End Sub

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para dar un registro en la tabla "Condicion".
    '''</comentario> 
    '''<parametro1>PDescripcion, Descripcion de opcion la condicion(Politica)</parametro1> 
    '''<parametro2>PIdCondicion, Llave foranea que conecta con la tabla "Condicion"</parametro2>
    '''<parametro3>PActivo, Estado Activo/Inactivo</parametro3>
    '''<parametro4>Id del usuario que creo el registro</parametro4>
    Public Sub AltaCatalogo(ByVal Catalogo As Entidades.CatalogoCondicionesCatalogo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@coca_descripcion"
        parametro.Value = Catalogo.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coca_condicionid"
        parametro.Value = Catalogo.PIdCondicion
        listaparametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@coca_activo"
        parametro.Value = Catalogo.PActivo
        listaparametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@coca_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_CondicionCatalogo", listaparametros)
    End Sub

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para actualizar un registro dela tabla "CondicionCatalogo".
    '''</comentario> 
    '''<parametro1>PIdCatalogo...  Llave primaria para ubicar el registro a modificar</parametro1> 
    '''<parametro2>PDescripcion...  Descripción de la politica</parametro2>
    '''<parametro3>PIdCondicion...  Llave foranea, conecta con la tabla condiciones.</parametro3> 
    '''<parametro4>POpcionDefault...  Seleccionar una opcion por default de todas en el catalogo..</parametro4> 
    '''<parametro5>PActivo, Estado Activo/Inactivo del registro</parametro5>
    '''<parametro6>Id del usuario que modifico</parametro6>
    Public Sub EditarCatalogo(ByVal Catalogo As Entidades.CatalogoCondicionesCatalogo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@coca_condicioncatalogoid"
        parametro.Value = Catalogo.PIdCatalogo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coca_descripcion"
        parametro.Value = Catalogo.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coca_condicionid"
        parametro.Value = Catalogo.PIdCondicion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coca_opciondefault"
        parametro.Value = Catalogo.POpcionDefault
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coca_activo"
        parametro.Value = Catalogo.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coca_usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_CondicionCatalogo", listaparametros)
    End Sub


    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de una politica(condicion) en especifico.
    '''</comentario> 
    '''<retorno>Ejecusion de Consulta SQL para seleccionar la condicion buscada</retorno>
    Public Function RecuperarCondicion() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT TOP 1 cond_condicionid, cond_nombre, cond_tipocondicionid, cond_activo" +
            " FROM Framework.Condicion " +
            " ORDER BY cond_fechacreacion DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Funcion que realiza la consulta para la busqueda de el catalogodecondiciones en especifico.
    '''</comentario> 
    '''<retorno>Ejecusion de Consulta SQL</retorno>
    Public Function RecuperarCatalogo() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "SELECT TOP 1 coca_condicioncatalogoid, coca_descripcion, coca_activo" +
            " FROM Framework.CondicionCatalogo " +
            " ORDER BY coca_fechacreacion DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    '''<comentario> 
    ''' Ejecuta el procedimiento almacenado para asignar una condicion nueva a cada cliente.
    '''</comentario> 
    '''<parametro1>PIdCondicion, Id la condicion(Politica)</parametro1> 
    Public Sub AltaCondicionCliente(ByVal IdCatalogo As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@gIDCatalogo"
        parametro.Value = IdCatalogo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AsignarPolitica", listaparametros)
    End Sub

    '''<comentario> 
    ''' Ejecuta el procedimiento para actualizar las Áres operativas pertenencientes a cierta condición.
    '''</comentario> 
    '''<parametro1>PIdCondicion, Id la condicion(Politica)</parametro1> 
    '''<parametro2>PArea, Nombre del Área Operativa</parametro2> 
    '''<parametro3>PControla, Indica que el Área Operativa controla la politica</parametro3> 
    '''<parametro4>PActivo, Indica que el área operativa cuenta con la condicion</parametro4> 
    '''<parametro5>@Usuario, Id del usuario que crea o modifica.</parametro5> 
    Public Sub ActualizarCondicionAreaOperativa(ByVal AreaOperativa As Entidades.CatalogoCondicionesAreaOperativa)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdCondicion"
        parametro.Value = AreaOperativa.PIdCondicion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdAreaOp"
        parametro.Value = AreaOperativa.PIdArea
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Controla"
        parametro.Value = AreaOperativa.PControla
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Activo"
        parametro.Value = AreaOperativa.PActivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AgregarCondicionAreaOperativa", listaparametros)
    End Sub

    ''' <summary>
    ''' BUSCA EL ID DE UNA CONDICION MEDIANTE EL NOMBRE
    ''' </summary>
    ''' <param name="Nombre"></param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function BuscarCondicion(ByVal Nombre As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  "
        consulta = "Select cond_condicionid as Id From Framework.Condicion " +
            " where RTRIM(LTRIM(cond_nombre)) = '" + Nombre + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Sub ActualizarCondicionClientes(ByVal IdCondicion As Integer, Activo As Boolean)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@gIDCatalogo"
        parametro.Value = IdCondicion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@gActivo"
        parametro.Value = Activo
        listaparametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_ModificarCondicionPersona", listaparametros)
    End Sub

End Class
