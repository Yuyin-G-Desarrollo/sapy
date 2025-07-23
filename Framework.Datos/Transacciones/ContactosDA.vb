Imports Persistencia
Imports System.Data.SqlClient

Public Class ContactosDA
    Public Function ConsultarContactosAreaOperativa(PersonaID As Integer, AreaOperativaID As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@PersonaID", PersonaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AreaOperativaID", AreaOperativaID)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Framework].[SP_ObtenerContactos_SegunAreaOperativa]", listaParametros)
    End Function
    Public Function TablaCargosSegunAreaOperativa(AreaOperativaID As Integer) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT coao_clasificacionpersonaid, LTRIM(RTRIM(UPPER(clpe_nombre))) AS clpe_nombre FROM Framework.ContactoAreaOperativa " +
                                " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = coao_clasificacionpersonaid " +
                                " WHERE coao_activo = 1 and clpe_activo = 1 AND coao_areaoperativaid = " + AreaOperativaID.ToString +
                                " ORDER BY clpe_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


    Public Function TablaCargosSinAreaOperativa() As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT clpe_clasificacionpersonaid, LTRIM(RTRIM(UPPER(clpe_nombre))) AS clpe_nombre" +
            " FROM Framework.ClasificacionPersona where clpe_clasepersonaid IN (2, 3) AND clpe_activo = 1" +
            " ORDER BY clpe_nombre ASC"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function consultarClasificacionPersona() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos

        Return objOperaciones.EjecutaConsulta("[Framework].[SP_ConsultaClasificacion_TipoPersona]")
    End Function

    Public Function TablaTipoTelefonos() As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT tite_tipotelefonoid, LTRIM(RTRIM(UPPER(tite_nombre))) AS tite_nombre FROM Framework.TipoTelefono WHERE tite_activo = 1 ORDER BY tite_nombre "

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaContacto_PantallaContacto(ByVal nombre As String, ByVal IdClasePersona As Integer, ByVal cliente_IdPersona As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @nombregenerico AS VARCHAR(100)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombregenerico"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        ',@clasificacionpersonaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = IdClasePersona
        listaParametros.Add(parametro)

        ',@cliente_personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "cliente_personaid"
        parametro.Value = cliente_IdPersona
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AltaContacto", listaParametros)
    End Sub

    ''METODO PARA AGREGAR CONTACTOS DESDE UN GRID DE CONTACTOS
    'Public Sub AltaContacto(persona As Entidades.Persona, _
    '                       clasificacionpersona As Entidades.ClasificacionPersona, _
    '                       cliente_persona As Entidades.Persona, _
    '                       cliente As Entidades.Cliente, _
    '                       email As Entidades.Email, _
    '                       telefono As Entidades.Telefono, _
    '                       tipoTelefono As Entidades.TipoTelefono)

    '    Dim operaciones As New OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlParameter)

    '    ' @nombregenerico AS VARCHAR(100)
    '    Dim parametro As New SqlParameter
    '    parametro.ParameterName = "nombregenerico"
    '    parametro.Value = persona.nombre
    '    listaParametros.Add(parametro)

    '    ',@clasificacionpersonaid AS INTEGER
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "clasificacionpersonaid"
    '    parametro.Value = clasificacionpersona.clasificacionpersonaid
    '    listaParametros.Add(parametro)

    '    ',@cliente_personaid AS INTEGER
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "cliente_personaid"
    '    parametro.Value = cliente_persona.personaid
    '    listaParametros.Add(parametro)

    '    ',@cliente_clasificacionpersonaid AS INTEGER
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "cliente_clasificacionpersonaid"
    '    parametro.Value = cliente.clasificacionpersona.clasificacionpersonaid
    '    listaParametros.Add(parametro)

    '    ',@email AS VARCHAR(50)
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "email"
    '    parametro.Value = email.email
    '    listaParametros.Add(parametro)

    '    ',@telefono AS VARCHAR(50)
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "telefono"
    '    parametro.Value = telefono.telefono
    '    listaParametros.Add(parametro)

    '    ',@tipotelefonoid AS INTEGER
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "tipotelefonoid"
    '    parametro.Value = tipoTelefono.tipotelefonoid
    '    listaParametros.Add(parametro)

    '    ',@extension AS  VARCHAR(50)
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "extension"
    '    parametro.Value = telefono.extension
    '    listaParametros.Add(parametro)

    '    ',@usuariocreoid AS INTEGER
    '    parametro = New SqlParameter
    '    parametro.ParameterName = "usuariocreoid"
    '    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    '    listaParametros.Add(parametro)

    '    operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Contacto_AreaOperativa", listaParametros)
    '    Console.WriteLine("Mando la sentencia")

    'End Sub


    Public Sub EditarContacto(bandera As Integer, clasificacionpersona As Entidades.ClasificacionPersona, _
                              persona As Entidades.Persona, _
                              email As Entidades.Email, _
                              telefono As Entidades.Telefono, _
                              tipoTelefono As Entidades.TipoTelefono)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@clasificacionpersonaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        '@persona_activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "persona_activo"
        If Not persona.activo Then
            parametro.Value = False
        Else
            parametro.Value = True
        End If
        listaParametros.Add(parametro)

        ',@nombre AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = persona.nombre
        listaParametros.Add(parametro)

        ',@emailid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "emailid"
        parametro.Value = email.emailpersonasid
        listaParametros.Add(parametro)

        ',@email AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "email"
        parametro.Value = email.email
        listaParametros.Add(parametro)

        '@email_activo
        parametro = New SqlParameter
        parametro.ParameterName = "email_activo"
        If Not email.activo Then
            parametro.Value = False
        Else
            parametro.Value = True
        End If
        listaParametros.Add(parametro)

        ',@telefonoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "telefonoid"
        parametro.Value = telefono.telefonoid
        listaParametros.Add(parametro)

        ',@telefono AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = telefono.telefono
        listaParametros.Add(parametro)

        ',@extension AS  VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "extension"
        parametro.Value = telefono.extension
        listaParametros.Add(parametro)

        '@telefono_activo
        parametro = New SqlParameter
        parametro.ParameterName = "telefono_activo"
        If Not telefono.activo Then
            parametro.Value = False
        Else
            parametro.Value = True
        End If
        listaParametros.Add(parametro)

        ',@tipotelefonoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipotelefonoid"
        parametro.Value = tipoTelefono.tipotelefonoid
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Edita_Contacto_AreaOperativa", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    ''Consulta de contactos sin contar Area Operativa


    Public Function TablaContactosSinAreaOperativa(PersonaID As Integer, AreaOperativaID As Integer) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT clpe_clasificacionpersonaid, LTRIM(RTrim(UPPER(clpe_nombre))) As clpe_nombre, " +
                                " pers_personaid, LTRIM(RTRIM(UPPER(" +
                                " (CASE WHEN pers_razonsocial IS NOT NULL THEN (CAST((pers_razonsocial) AS VARCHAR)) ELSE (CAST((pers_nombre) AS VARCHAR)) END) " +
                                " ))) AS pers_nombre, " +
                                " empe_emailpersonasid, LTRIM(RTrim(LOWER(empe_email))) As empe_email, " +
                                " tele_telefonoid, tele_telefono, " +
                                " tite_tipotelefonoid, LTRIM(RTrim(UPPER(tite_nombre))) As tite_nombre , tele_extension " +
                                " FROM Framework.RelacionesPersonas " +
                                " JOIN Framework.Persona ON repe_personaid1 = pers_personaid " +
                                " JOIN Framework.TiposPersonas ON tipe_personaid = repe_personaid1 " +
                                " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tipe_clasificacionpersonaid " +
                                " JOIN Framework.EmailPersonas ON empe_personaid = pers_personaid " +
                                " JOIN Framework.Telefono ON tele_personaid = pers_personaid " +
                                " JOIN Framework.TipoTelefono ON tite_tipotelefonoid = tele_tipotelefonoid " +
                                " JOIN Framework.ContactoAreaOperativa ON coao_clasificacionpersonaid = clpe_clasificacionpersonaid " +
                                " WHERE " +
                                "  Framework.RelacionesPersonas.repe_persona2 = " + PersonaID.ToString +
                                " AND repe_activo = 1 AND clpe_activo = 1 AND pers_activo = 1 AND empe_activo = 1 AND tele_activo = 1"

        '(CASE WHEN pers_razonsocial IS NOT NULL THEN (CAST((pers_nombre + ' ' +  pers_razonsocial) AS VARCHAR)) ELSE (CAST((pers_nombre + ' ' + pers_apaterno +' '+ pers_amaterno) AS VARCHAR))END)

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


    Public Function ListaAgentes_de_cliente(ByVal IdCLiente_say As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT DISTINCT cmae_colaboradorid_agente AS 'ID', " +
            " UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(250))) AS 'AGENTE DE VENTAS'" +
            " FROM Cliente.ClienteMarcaAgenteEmpresa" +
            " JOIN Nomina.Colaborador ON codr_colaboradorid = cmae_colaboradorid_agente" +
            " JOIN Framework.Empresas ON empr_empresaid = cmae_empresaid" +
            " WHERE cmae_clienteid = " + IdCLiente_say.ToString +
            " ORDER BY [AGENTE DE VENTAS],cmae_colaboradorid_agente"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ObtenerContactosReferenciasComerciales(ByVal IdPersonaClienteSay As Integer, ByVal permiso As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@clienteSayId", IdPersonaClienteSay)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@permiso", permiso)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Framework].[SP_Contactos_ReferencialesComerciales]", listaParametros)

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IdPersonaClienteSay"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function lista_Asignaciones_De_Contacto_Activas(ByVal IdPersonaClienteSay As Integer, ByVal IdPersonaContactoSay As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@personaId", IdPersonaContactoSay)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@personaClienteSAYId", IdPersonaClienteSay)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Ventas].[SP_lista_Asignaciones_De_Contacto_Activas]", listaParametros)
    End Function


    Public Function Lista_Contactos_Activos(ByVal IdPersonaCliente As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from (SELECT pers_personaid AS 'Id'," +
                                " 	CASE WHEN pers_razonsocial IS NOT NULL THEN UPPER((CAST ((pers_razonsocial) AS varchar))) ELSE UPPER((CAST ((pers_nombre) AS varchar (250)))) END AS 'Nombre'" +
                                " FROM Framework.RelacionesPersonas" +
                                " JOIN Framework.Persona ON repe_personaid1 = pers_personaid" +
                                " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = repe_clasificacionpersonaid1" +
                                " WHERE repe_activo = 1" +
                                " AND clpe_activo = 1  and pers_activo = 1" +
                                " AND clpe_clasepersonaid  in(2,3)" +
                                " AND Framework.RelacionesPersonas.repe_persona2 in (" + IdPersonaCliente.ToString + "))  as cons" +
                                " group by  Id, nombre order by Nombre "
        Return objpersistencia.EjecutaConsulta(consulta)
    End Function


    Public Function Lista_Tipo_Telefono_Activo() As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  select tite_tipotelefonoid as 'Id', UPPER(tite_nombre) AS 'tite_nombre' " +
                                " from Framework.TipoTelefono where tite_activo = 1 order by tite_nombre "
        Return objpersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Id_PersonaContacto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listaAsignacionesdeContacto(ByVal Id_PersonaContacto As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim consulta As String = "SELECT pers_personaid, repe_relacionespersonaid, UPPER(clpe_nombre) AS 'Cargos', repe_activo AS 'Activo', UPPER(pers_nombre) AS 'Nombre'," +
                " case when repe_fechamodificacion is null then repe_fechacreacion else repe_fechamodificacion end as 'Modificación'," +
                " case when repe_usuariomodificoid is null then (select user_username from Framework.Usuarios where user_usuarioid = repe_usuariocreoid)" +
                " else (select user_username from Framework.Usuarios where user_usuarioid = repe_usuariomodificoid) end as 'Usuario'" +
            " FROM Framework.RelacionesPersonas" +
            " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = repe_clasificacionpersonaid1" +
            " JOIN Framework.Persona ON repe_personaid1 = pers_personaid" +
            " where repe_personaid1 in (" + Id_PersonaContacto + ")"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function
    Public Function ConsultarListaTelefonosdeContacto(ByVal Id_PersonaContacto As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@Id_PersonaContacto", Id_PersonaContacto)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Framework].[SP_ListaTelefonosdeContacto]", listaParametros)

    End Function
    Public Function ListaCorreosdeContacto(ByVal Id_PersonaContacto As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim consulta As String = "SELECT empe_emailpersonasid AS 'Id'," +
                                "	LOWER(empe_email) AS 'Correo Electrónico'," +
                                "	empe_activo AS 'Activo'," +
                                "	UPPER(pers_nombre) AS 'Nombre'," +
                                "	UPPER(clpe_nombre) as 'Cargo'," +
                                "   case when empe_fechamodificacion is null then empe_fechacreacion else empe_fechamodificacion end as  'Modificación'," +
                                "   case when empe_usuariomodificoid is null then  (select user_username from Framework.Usuarios where user_usuarioid = empe_usuariocreoid)" +
                                "   else  (select user_username from Framework.Usuarios where user_usuarioid = empe_usuariomodificoid) end as 'Usuario'" +
                                " FROM Framework.EmailPersonas" +
                                " JOIN Framework.Persona ON empe_personaid = pers_personaid" +
                                " join Framework.ClasificacionPersona on empe_clasificacionpersonaid = clpe_clasificacionpersonaid" +
                                " WHERE empe_personaid IN (" + Id_PersonaContacto + ")" +
                                " AND empe_clasificacionpersonaid IN (SELECT DISTINCT clpe_clasificacionpersonaid FROM Framework.ClasificacionPersona WHERE clpe_clasepersonaid IN (2, 3))"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub ActualizarContacto(ByVal IdContacto_Persona As Integer, ByVal Nombre As String, ByVal Activo As Boolean)
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  update Framework.Persona" +
                                "   set pers_nombre = '" + Nombre + "'," +
                                " 	pers_activo = '" + Activo.ToString + "'," +
                                " 	pers_fechamodificacion = GETDATE()," +
                                "   pers_usuariomodificaid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                                "   where pers_personaid = " + IdContacto_Persona.ToString

        objpersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Sub GuardarCargoContacto(relacion As Entidades.RelacionesPersonas)
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " INSERT INTO [Framework].[RelacionesPersonas]" +
            " ([repe_personaid1]" +
            " ,[repe_clasificacionpersonaid1]" +
            " ,[repe_persona2]" +
            " ,[repe_clasificacionpersona2]" +
            " ,[repe_activo]" +
            " ,[repe_usuariocreoid]" +
            " ,[repe_fechacreacion])" +
            " VALUES " +
            " (" + relacion.PPersonaId.ToString +
            " ," + relacion.PCLasificacionPersona1.ToString +
            " ," + relacion.PPersona2_Id.ToString +
            " ," + relacion.PClasificacionPersona2.ToString +
            " , 1 " +
            " , " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            " , getdate())"
        objpersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Sub ActualizarCargosContacto(ByVal IdRelacioPersona As Integer, ByVal Activo As Boolean)
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  update Framework.RelacionesPersonas set repe_activo = '" + Activo.ToString + "'" +
                                    ", repe_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                                    ", repe_fechamodificacion = getdate()" +
                                    " where repe_relacionespersonaid = " + IdRelacioPersona.ToString
        objpersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Function GuardarTelefonoContacto(ByVal telefono As Entidades.Telefono) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@telefonoid", telefono.telefonoid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@telefono", telefono.telefono)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@extension", telefono.extension)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipotelefonoid", telefono.tipotelefono.tipotelefonoid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@personaid", telefono.persona.personaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clasificacionpersonaid", telefono.clasificacionpersona.clasificacionpersonaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@activo", telefono.activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioid", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@eswhatsapp", telefono.whatsaap)
        listaParametros.Add(parametro)
        Return objOperaciones.EjecutarConsultaSP("[Framework].[SP_AltaEdicionTelefonoContacto]", listaParametros)

    End Function
    Public Sub GuardarCorreoContacto(ByVal email As Entidades.Email)
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " INSERT INTO [Framework].[EmailPersonas]" +
        "   ([empe_email]" +
        "   ,[empe_personaid]" +
        "   ,[empe_clasificacionpersonaid]" +
        "   ,[empe_activo]" +
        "   ,[empe_usuariocreoid]" +
        "   ,[empe_fechacreacion])" +
        "VALUES" +
        "   ( '" + email.email + "'" +
        "   , " + email.persona.personaid.ToString +
        "   , " + email.clasificacionpersona.clasificacionpersonaid.ToString +
        "   , '" + email.activo.ToString + "'" +
        "   , " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
        "   , GETDATE() )"

        objpersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Sub ActualizarCorreoContacto(ByVal email As Entidades.Email)
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " update Framework.EmailPersonas " +
                                    " set empe_email = '" + email.email + "'"
        If email.persona.personaid > 0 Then
            consulta += "	,empe_personaid = " + email.persona.personaid.ToString
        End If
        If email.clasificacionpersona.clasificacionpersonaid > 0 Then
            consulta += "	,empe_clasificacionpersonaid = " + email.clasificacionpersona.clasificacionpersonaid.ToString
        End If

        consulta += "	, empe_activo = '" + email.activo.ToString + "'" +
                    "	,empe_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    "	,empe_fechamodificacion = GETDATE()" +
                    " WHERE empe_emailpersonasid =" + email.emailpersonasid.ToString
        objpersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Function Lista_ClasificacionPersona_Activos_Sin_Asignar(ByVal IdPersona_Contacto As Integer, ByVal IdPersona_Cliente As Integer) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT clpe_clasificacionpersonaid AS 'Id'," +
                                " UPPER(clpe_nombre) AS 'Nombre'" +
                                " FROM Framework.ClasificacionPersona" +
                                " WHERE clpe_clasepersonaid IN (2, 3)" +
                                " AND clpe_activo = 1" +
                                " and clpe_clasificacionpersonaid not in (select distinct repe_clasificacionpersonaid1 " +
                                " from Framework.RelacionesPersonas" +
                                " where repe_personaid1 = " + IdPersona_Contacto.ToString +
                                " and repe_persona2 = " + IdPersona_Cliente.ToString + ")" +
                                " ORDER BY clpe_nombre"
        Return objpersistencia.EjecutaConsulta(consulta)
    End Function
    Public Function ConsultarRegistroExistenteTelefono(ByVal Telefono As Entidades.Telefono, ByVal Original As Boolean) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@original", Original)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@telefono", Telefono.telefono)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@telefonoid", Telefono.telefonoid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@extension", Telefono.extension)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipotelefonoid", Telefono.tipotelefono.tipotelefonoid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@personaid", Telefono.persona.personaid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@clasificacionpersonaid", Telefono.clasificacionpersona.clasificacionpersonaid)
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Framework].[SP_RecuperarRegistroExistente_Telefono]", listaParametros)

    End Function
    Public Function RecuperarRegistroExistente_Correo(ByVal Correo As Entidades.Email, ByVal Original As Boolean) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT empe_emailpersonasid , LOWER(empe_email) ,empe_personaid ,empe_clasificacionpersonaid ,empe_activo" +
            " FROM Framework.EmailPersonas"
        If Original = True Then
            consulta += " where empe_emailpersonasid = " + Correo.emailpersonasid.ToString
        Else
            consulta += " where empe_email= '" + Correo.email + "'" +
                        " and empe_personaid=" + Correo.persona.personaid.ToString +
                        " and empe_clasificacionpersonaid = " + Correo.clasificacionpersona.clasificacionpersonaid.ToString
            If Correo.emailpersonasid > 0 Then
                consulta += " and empe_emailpersonasid <> " + Correo.emailpersonasid.ToString
            End If
        End If

        Return objpersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarRegistroExistente_Asignacion(ByVal Asignacion As Entidades.RelacionesPersonas, ByVal Original As Boolean) As DataTable
        Dim objpersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        If Original = True Then
            consulta = " SELECT [repe_relacionespersonaid],[repe_personaid1],[repe_clasificacionpersonaid1],[repe_persona2],[repe_clasificacionpersona2],[repe_activo]" +
                " FROM [Framework].[RelacionesPersonas]" +
                " where [repe_relacionespersonaid] = " + Asignacion.PrelacionPersonaId.ToString
        Else
            consulta = " SELECT [repe_relacionespersonaid],[repe_personaid1],[repe_clasificacionpersonaid1],[repe_persona2],[repe_clasificacionpersona2],[repe_activo]" +
                " FROM [Framework].[RelacionesPersonas]" +
                " where [repe_personaid1] = " + Asignacion.PPersonaId.ToString +
                " and [repe_clasificacionpersonaid1] = " + Asignacion.PCLasificacionPersona1.ToString +
                " and [repe_persona2] = " + Asignacion.PPersona2_Id.ToString +
                " and [repe_clasificacionpersona2] = " + Asignacion.PClasificacionPersona2.ToString
            If Asignacion.PrelacionPersonaId > 0 Then
                consulta += "[repe_relacionespersonaid] <>" + Asignacion.PrelacionPersonaId.ToString
            End If
        End If

        Return objpersistencia.EjecutaConsulta(consulta)
    End Function

End Class
