Imports Persistencia
Imports System.Data.SqlClient

Public Class PersonasDA

    Public Sub AltaPersona(ByVal persona As Entidades.Persona, cliente As Entidades.Cliente, clienteRFC As Entidades.ClienteRFC, tipoPersona As Entidades.TipoPersona, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = cliente.clienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienterfcid"
        If Not clienteRFC Is Nothing Then
            If clienteRFC.clienterfcid = 0 Then
                parametro.Value = 0
            Else
                parametro.Value = clienteRFC.clienterfcid
            End If
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = persona.nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        If persona.personaid = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = persona.personaid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        If Not tipoPersona Is Nothing Then
            If tipoPersona.clasificacionpersona.clasificacionpersonaid = 0 Then
                parametro.Value = 1
            Else
                parametro.Value = tipoPersona.clasificacionpersona.clasificacionpersonaid
            End If
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = persona.activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sicyid"
        If IsNothing(persona.SicyID) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.SicyID
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@regimenFiscalID"
        parametro.Value = tipoPersona.regimenFiscalId
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Persona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub
    Public Sub EditarPersona(ByVal persona As Entidades.Persona, clienteID As Integer, email As Entidades.Email, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = clienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        If IsNothing(persona.nombre) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.nombre
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "apaterno"
        If IsNothing(persona.apaterno) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.apaterno
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "amaterno"
        If IsNothing(persona.amaterno) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.amaterno
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CURP"
        If IsNothing(persona.CURP) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.CURP
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        If IsNothing(persona.razonsocial) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.razonsocial
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paginaweb"
        If IsNothing(persona.paginaweb) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.paginaweb
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechanacimiento"
        If persona.fechanacimiento = DateTime.MinValue Then
            parametro.Value = 0
        Else
            parametro.Value = persona.fechanacimiento
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personafisica"
        parametro.Value = persona.personafisica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = persona.activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "emailid"
        If IsNothing(email) Then
            parametro.Value = 0
        Else
            parametro.Value = email.emailpersonasid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "email"
        If IsNothing(email) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = email.email
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sicyid"
        If IsNothing(persona.SicyID) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = persona.SicyID
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Persona", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub
    Public Function Datos_TablaPersona(personaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * " +
                                " FROM Framework.Persona" +
                                " LEFT JOIN Framework.EmailPersonas ON empe_personaid = pers_personaid" +
                                " WHERE pers_personaid = " + personaID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function
    Public Function ClasePersona() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                "SELECT * FROM Framework.ClasePersona where cper_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ClasePersonaCMB() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutarConsultaSP("Framework.SP_ConsultarTipoPersonas", New List(Of SqlClient.SqlParameter))

    End Function
    Public Function ClasificacionPersona(ByVal idClasePersona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                "SELECT * FROM Framework.ClasificacionPersona where clpe_clasepersonaid =" + idClasePersona.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub AltaPersonaGeneral(ByVal persona As Entidades.Persona)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@pers_nombre nvarchar(150),
        '@pers_apaterno nvarchar(50),
        '@pers_amaterno nvarchar(50),
        '@pers_CURP nvarchar(20),
        '@pers_razonsocial nvarchar(100),
        '@pers_paginaweb nvarchar(50),
        '@pers_fechanacimiento smalldatetime,
        '@pers_personafisica bit,
        '@pers_activo bit,
        '@pers_usuariocreoid int,
        '@pers_fechacreacion smalldatetime,
        '@idSicy varchar(50)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pers_nombre"
        parametro.Value = persona.nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_apaterno"
        If persona.apaterno = Nothing Or persona.apaterno = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.apaterno
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_amaterno"
        If persona.amaterno = Nothing Or persona.amaterno = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.amaterno
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_CURP"
        If persona.CURP = Nothing Or persona.CURP = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.CURP
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_razonsocial"
        If persona.razonsocial = Nothing Or persona.razonsocial = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.razonsocial
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_paginaweb"
        If persona.paginaweb = Nothing Or persona.paginaweb = "" Then
            parametro.Value = persona.paginaweb
        Else

            parametro.Value = persona.paginaweb
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_fechanacimiento"
        If persona.fechanacimiento = Date.Today Then
            parametro.Value = DBNull.Value
        Else

            parametro.Value = persona.fechanacimiento
        End If


        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_personafisica"
        parametro.Value = persona.personafisica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_activo"
        parametro.Value = persona.activo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "idSicy"
        If persona.SicyID = Nothing Or persona.SicyID <= 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.SicyID
        End If

        listaParametros.Add(parametro)



        parametro = New SqlParameter
        parametro.ParameterName = "pers_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AltaPersonas", listaParametros)


    End Sub
    Public Sub EditarPersonas(ByVal persona As Entidades.Persona)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@pers_nombre nvarchar(150),
        '@pers_apaterno nvarchar(50),
        '@pers_amaterno nvarchar(50),
        '@pers_CURP nvarchar(20),
        '@pers_razonsocial nvarchar(100),
        '@pers_paginaweb nvarchar(50),
        '@pers_fechanacimiento smalldatetime,
        '@pers_personafisica bit,
        '@pers_activo bit,
        '@pers_usuariocreoid int,
        '@pers_fechacreacion smalldatetime,
        '@idSicy varchar(50)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pers_nombre"
        parametro.Value = persona.nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_apaterno"
        If persona.apaterno = Nothing Or persona.apaterno = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.apaterno
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_amaterno"
        If persona.amaterno = Nothing Or persona.amaterno = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.amaterno
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_CURP"
        If persona.CURP = Nothing Or persona.CURP = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.CURP
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_razonsocial"
        If persona.razonsocial = Nothing Or persona.razonsocial = "" Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.razonsocial
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_paginaweb"
        If persona.paginaweb = Nothing Or persona.paginaweb = "" Then
            parametro.Value = persona.paginaweb
        Else

            parametro.Value = persona.paginaweb
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_fechanacimiento"
        If persona.fechanacimiento = Date.Today Then
            parametro.Value = DBNull.Value
        Else

            parametro.Value = persona.fechanacimiento
        End If


        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_personafisica"
        parametro.Value = persona.personafisica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_activo"
        parametro.Value = persona.activo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "idSicy"
        If persona.SicyID = Nothing Or persona.SicyID <= 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = persona.SicyID
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pers_usuariomodifica"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PersonaID"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_EditarPersonas", listaParametros)


    End Sub
    Public Function GetIDPersonaRecienInsertado() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                "SELECT top 1 (pers_personaid) from Framework.Persona order by pers_personaid DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub AltaTipoPersona(ByVal personaid As Int32, ByVal ClasificacionPersona As Int32)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@tipe_personaid int,
        '@tipe_clasificacionpersonaid int,
        '@tipe_usuariocreoid int

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PersonaID"
        parametro.Value = personaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ClasificacionPersona"
        parametro.Value = ClasificacionPersona
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioCreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_AltaTipoPersona", listaParametros)


    End Sub
    Public Function ListaPersonas(ByVal TipoPersona As Int32, ByVal ClasePersona As Int32, ByVal Activo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim strg As String = ""
        strg = "select c.clpe_clasificacionpersonaid as ClasificacionPersona, a.pers_personaid as PersonaID, d.cper_nombre as Tipo, c.clpe_nombre as Clasificacion, a.pers_nombre as Nombre, a.pers_apaterno as 'A Paterno', a.pers_amaterno as 'A Materno', " +
            "a.pers_razonsocial as 'Razon Social', a.pers_activo as Activo from Framework.Persona as a " +
            "JOIN Framework.TiposPersonas as b on (a.pers_personaid = b.tipe_personaid)" +
            "JOIN Framework.ClasificacionPersona as c on (b.tipe_clasificacionpersonaid= c.clpe_clasificacionpersonaid)" +
            "join Framework.ClasePersona  as d on (c.clpe_clasepersonaid= d.cper_clasepersonaid) "
        If TipoPersona > 0 Then
            strg += " where d.cper_clasepersonaid =" + TipoPersona.ToString
            If ClasePersona > 0 Then
                strg += " and c.clpe_clasificacionpersonaid=" + ClasePersona.ToString
            End If
        End If
        strg += "and a.pers_activo='" + Activo.ToString + "' order by Nombre"
        Return operaciones.EjecutaConsulta(strg)

    End Function
    Public Function CargarDatosPersona(ByVal IDPersona As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim strg As String = ""
        strg = "select * from Framework.Persona where pers_personaid =" + IDPersona.ToString
        Return operaciones.EjecutaConsulta(strg)
    End Function


    Public Function regimenPersonaMoralFisica(tipoPersona As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        If tipoPersona = True Then            
            'persona Física
            consulta = "select clrf_regimenfiscalid as idRegimenfiscal,clrf_regimenfiscal_clavesat+' - '+clrf_nombre as Regimen from cliente.RegimenFiscal " +
            " where clrf_personafisica=1 and clrf_activo=1 order by clrf_regimenfiscal_clavesat+' - '+clrf_nombre"

        ElseIf tipoPersona = False Then            
            'Persona Moral
            consulta += "select clrf_regimenfiscalid as idRegimenfiscal,clrf_regimenfiscal_clavesat+' - '+clrf_nombre as Regimen from cliente.RegimenFiscal " +
            " where clrf_personamoral=1 and clrf_activo=1 order by clrf_regimenfiscal_clavesat+' - '+clrf_nombre"

        End If
        
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function regimenPersonaMoralFisicaId(personaId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "select crfc_regimenfiscalid from Cliente.ClienteRFC where crfc_personaid = " + personaId.ToString + " "

        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
