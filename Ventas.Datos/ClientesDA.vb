Imports Persistencia
Imports System.Data.SqlClient

Public Class ClientesDA

    Public Function buscarClientesNombreComercial(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                "   pers_personaid" +
                                " , clie_clienteid" +
                                " , UPPER(clie_statuscliente) AS clie_statuscliente" +
                                " , LTRIM(RTRIM ( UPPER(clie_nombregenerico))) AS clie_nombregenerico" +
                                " , clie_clasificacionpersonaid" +
                                " , UPPER(clie_razonsocial) AS clie_razonsocial" +
                                " , clie_ranking" +
                                " , clie_fechacreacion " +
                                " FROM Framework.Persona" +
                                " JOIN Cliente.Cliente ON clie_personaidcliente = pers_personaid" +
                                " WHERE clie_comercializadoraid = (SELECT cl.labo_naveid FROM Nomina.ColaboradorLaboral cl WHERE cl.labo_colaboradorid = (SELECT u.user_colaboradorid FROM Framework.Usuarios u WHERE u.user_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "))"

        If clienteID > 0 Then
            consulta += " WHERE clie_clienteid = " + clienteID.ToString
        End If

        consulta += " ORDER BY clie_nombregenerico"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarClientesNombreComercialXEstatus(ByVal activo As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                "   pers_personaid" +
                                " , clie_clienteid" +
                                " , UPPER(clie_statuscliente) AS clie_statuscliente" +
                                " , LTRIM(RTRIM ( UPPER(clie_nombregenerico))) AS clie_nombregenerico" +
                                " , clie_clasificacionpersonaid" +
                                " , UPPER(clie_razonsocial) AS clie_razonsocial" +
                                " , clie_ranking" +
                                " , clie_fechacreacion " +
                                " FROM Framework.Persona" +
                                " JOIN Cliente.Cliente ON clie_personaidcliente = pers_personaid" +
                                " WHERE clie_activo = '" + activo.ToString + "'" +
                                " AND clie_comercializadoraid = (SELECT cl.labo_naveid FROM Nomina.ColaboradorLaboral cl WHERE cl.labo_colaboradorid = (SELECT u.user_colaboradorid FROM Framework.Usuarios u WHERE u.user_usuarioid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "))" +
                                " ORDER BY clie_nombregenerico"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarUltimoCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT MAX(clie_clienteid) FROM Cliente.Cliente"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarUltimoCliente_mas1() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT MAX(clie_clienteid) + 1 FROM Cliente.Cliente"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaVendedor() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "  codr_colaboradorid " +
                                " , UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR(150))) AS codr_nombre_completo" +
                                " FROM Nomina.Colaborador" +
                                " JOIN Nomina.ColaboradorLaboral ON labo_colaboradorid =  codr_colaboradorid" +
                                " JOIN Nomina.Puestos ON pues_puestoid = labo_puestoid" +
                                " WHERE pues_puestoid IN (255, 274) AND codr_activo = 1 " +
                                " ORDER BY codr_nombre_completo"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaAtnClientes() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        'Dim consulta As String = "" +
        '                        " SELECT " +
        '                        "  codr_colaboradorid " +
        '                        " , UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR(150))) AS codr_nombre_completo" +
        '                        " FROM Nomina.Colaborador" +
        '                        " JOIN Nomina.ColaboradorLaboral ON labo_colaboradorid =  codr_colaboradorid" +
        '                        " JOIN Nomina.Puestos ON pues_puestoid = labo_puestoid" +
        '                        " WHERE pues_puestoid IN (274,792,81) AND codr_activo = 1 " +
        '                        " ORDER BY codr_nombre_completo"

        Return operaciones.EjecutarConsultaSP("[Cliente].[SP_FichaTecnica_ConsultarColaboradorAtencionClientes]", listaParametros)

    End Function

    Public Function buscarNombreCobradorSegunCliente(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        If clienteID > 0 Then
            consulta += "SELECT clie_colaboradorid_vendedor, UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR)) AS codr_nombre_completo FROM Cliente.Cliente " +
        "Join Nomina.Colaborador " +
        "ON Cliente.clie_colaboradorid_vendedor = Colaborador.codr_colaboradorid " +
        "WHERE clie_clienteid = " + clienteID.ToString
        ElseIf clienteID = 0 Then
            consulta += "SELECT labo_colaboradorlaboralid, UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR)) AS codr_nombre_completo " +
                "FROM Nomina.Colaborador " +
                "Join Nomina.ColaboradorLaboral " +
                "ON codr_colaboradorid =  labo_colaboradorlaboralid " +
                "WHERE labo_departamentoid = 93" +
                "AND codr_activo = 1"
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarColaboradorValidador(usuarioID As Integer, TipoValidacion As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT  " +
                                "   vati_colaboradorid" +
                                " , UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR(150))) AS codr_nombre_completo" +
                                " FROM Framework.ValidacionUsuario" +
                                " JOIN Framework.Usuarios ON user_colaboradorid = vati_colaboradorid" +
                                " JOIN Nomina.Colaborador ON codr_colaboradorid = user_colaboradorid" +
                                " WHERE vaus_activo = 1 AND vati_validaciontipoid = " + TipoValidacion.ToString

        If usuarioID > 0 Then
            consulta += " AND user_usuarioid = " + usuarioID.ToString
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaClasificacionCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                " clas_clasificacioclientenid " +
                                " , clas_nombre" +
                                ", clas_descripcion " +
                                " FROM Cliente.Clasificaciones" +
                                " WHERE clas_activo = 1"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaReordenamientoRanking(clasificacion As String, cliente As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@clasificacion"
        parametro.Value = clasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        'Dim consulta As String = " " +
        '                        " SELECT " +
        '                        " clie_clienteid AS 'SAY ID'" +
        '                        " ,clie_idsicy AS 'SICY ID'	" +
        '                        " ,clie_nombregenerico AS 'NOMBRE'	" +
        '                        " ,clie_clasificacionclienteid AS 'CLASIFICACIÓN ACTUAL'" +
        '                        " ,clie_ranking AS 'RANKING ACTUAL'" +
        '                        " ,clie_ranking AS 'RANKING NUEVO'" +
        '                        " FROM Cliente.Cliente" +
        '                        " WHERE clie_clasificacionclienteid IS NOT NULL AND clie_activo = 1" +
        '                        " AND clie_clasificacionclienteid like '%" + Trim(clasificacion) + "%'" +
        '                        " ORDER BY clie_clasificacionclienteid, clie_ranking"

        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_ReordenamientoRanking_Consultar]", listaParametros)

    End Function

    Public Function AsignarClasificacionRanking(clasificacion As String) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT (clas_ranking + 1) AS clas_ranking FROM Cliente.Clasificaciones WHERE clas_clasificacioclientenid = '" + clasificacion.ToString + "'"

        Return operaciones.EjecutaConsulta(consulta)

        '
    End Function

    Public Sub AltaCliente(ByVal cliente As Entidades.Cliente, ByVal ListaPeciosVentaId As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@idsicy AS INTEGER
        '@statuscliente AS NCHAR
        '@nombregenerico AS NCHAR
        '@razonsocial AS NCHAR
        '@ranking AS INTEGER
        '@clasificacionclienteid AS NCHAR
        '@personaidcliente AS INTEGER
        '@clasificacionpersonaid AS INTEGER
        '@rutaid AS INTEGER
        '@colaboradorid_atnc AS INTEGER
        '@usuariocreoid AS INTEGER

        Dim parametro As New SqlParameter
        parametro.ParameterName = "idsicy"
        parametro.Value = cliente.idsicy
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "statuscliente"
        parametro.Value = cliente.statuscliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombregenerico"
        parametro.Value = cliente.nombregenerico
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        parametro.Value = cliente.razonsocial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ranking"
        parametro.Value = cliente.ranking
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionclienteid"
        parametro.Value = cliente.clasificacioncliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = cliente.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaid"
        parametro.Value = cliente.ruta.rutaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid_atnc"
        parametro.Value = cliente.colaborador_atnc.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personafisica"
        parametro.Value = cliente.personacliente.personafisica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaPeciosVentaId"
        parametro.Value = ListaPeciosVentaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientePreferente"
        parametro.Value = cliente.clientepreferente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@comercializadoraid"
        parametro.Value = cliente.ComercializadoraId
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Alta_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarCliente(ByVal cliente As Entidades.Cliente, tipoPersona As Entidades.TipoPersona, ByVal bandera As Integer, ByVal PedidoVirtual As Boolean, ByVal PedidoEscaneado As Boolean)


        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@clienteID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteID"
        parametro.Value = cliente.clienteid
        listaParametros.Add(parametro)

        ',@idsicy AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "idsicy"
        If cliente.idsicy = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.idsicy
        End If
        listaParametros.Add(parametro)

        '@clienteespecial
        parametro = New SqlParameter
        parametro.ParameterName = "clienteespecial"
        If Not cliente.clienteespecial Then
            parametro.Value = False
        Else
            parametro.Value = cliente.clienteespecial
        End If
        listaParametros.Add(parametro)


        ',@precioespecial AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "precioespecial"
        If Not cliente.precioespecial Then
            parametro.Value = False
        Else
            parametro.Value = cliente.precioespecial
        End If
        listaParametros.Add(parametro)

        ',@nombregenerico AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "nombregenerico"
        If String.IsNullOrWhiteSpace(cliente.nombregenerico) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = cliente.nombregenerico
        End If
        listaParametros.Add(parametro)

        ',@razonsocial AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "razonsocial"
        If String.IsNullOrWhiteSpace(cliente.razonsocial) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = cliente.razonsocial
        End If
        listaParametros.Add(parametro)

        ', @personaID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaID"
        If IsNothing(cliente.personacliente) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.personacliente.personaid
        End If
        listaParametros.Add(parametro)

        ',@NuevoClasificacionPersonaID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "NuevoClasificacionPersonaID"
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

        ', @tipo_personafisica AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "tipo_personafisica"
        If IsNothing(cliente.personacliente) Then
            parametro.Value = False
        Else
            If Not cliente.personacliente.personafisica Then
                parametro.Value = False
            Else
                parametro.Value = cliente.personacliente.personafisica
            End If
        End If

        listaParametros.Add(parametro)

        ',@claveyuyinproveedor AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "claveyuyinproveedor"
        If cliente.claveyuyinproveedor = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.claveyuyinproveedor
        End If
        listaParametros.Add(parametro)

        ',@rutaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "rutaid"
        If IsNothing(cliente.ruta) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.ruta.rutaid
        End If
        listaParametros.Add(parametro)

        ',@colaboradorid_atnc AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid_atnc"
        If IsNothing(cliente.colaborador_atnc) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.colaborador_atnc.PColaboradorid
        End If
        listaParametros.Add(parametro)

        ',@comentarios AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "comentarios"
        If IsNothing(cliente.comentarios) Then
            parametro.Value = ""
        Else
            parametro.Value = cliente.comentarios
        End If
        listaParametros.Add(parametro)

        ',@empresaid  AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "empresaid"
        If IsNothing(cliente.empresa) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.empresa.Pempr_empresaid
        End If
        listaParametros.Add(parametro)

        ',@tipoclienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipoclienteid"
        If IsNothing(cliente.tipocliente) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.tipocliente.tipoclienteid
        End If
        listaParametros.Add(parametro)

        ', @clasificacionclienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionclienteid"
        If String.IsNullOrWhiteSpace(cliente.clasificacioncliente) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = cliente.clasificacioncliente
        End If
        listaParametros.Add(parametro)


        ', @ranking AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ranking"
        If IsNothing(cliente.ranking) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.ranking
        End If
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        ',@PedidosVirtuales as bit
        parametro = New SqlParameter
        parametro.ParameterName = "PedidosVirtuales"
        parametro.Value = PedidoVirtual
        listaParametros.Add(parametro)

        ',@PedidosEscaneados as bit
        parametro = New SqlParameter
        parametro.ParameterName = "PedidosEscaneados"
        parametro.Value = PedidoEscaneado
        listaParametros.Add(parametro)

        ',@PedidoStockWeb as bit
        parametro = New SqlParameter
        parametro.ParameterName = "PedidoStockWeb"
        parametro.Value = cliente.PedidoStockWeb
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clientePreferente"
        parametro.Value = cliente.clientepreferente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@comercializadoraid"
        parametro.Value = cliente.ComercializadoraId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PuedeApartar"
        parametro.Value = cliente.PuedeApartar
        listaParametros.Add(parametro)
        'asd
        operaciones.EjecutarSentenciaSP("[Cliente].[SP_Editar_Cliente_10_12_2018]", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarCliente_Ranking_Sicy(ByVal cliente As Entidades.Cliente, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@idsicy AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "idsicy"
        If cliente.idsicy = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.idsicy
        End If
        listaParametros.Add(parametro)

        ', @clasificacionclienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionclienteid"
        If String.IsNullOrWhiteSpace(cliente.clasificacioncliente) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = cliente.clasificacioncliente
        End If
        listaParametros.Add(parametro)


        ', @ranking AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ranking"
        If IsNothing(cliente.ranking) Then
            parametro.Value = 0
        Else
            parametro.Value = cliente.ranking
        End If
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("dbo.Editar_Cliente_Clasificacion_Ranking", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaValidacionCliente(ByVal validacion As Entidades.Validacion, NuevoClasificacionPersonaID As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @clienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = validacion.registro.clienteid
        listaParametros.Add(parametro)

        ',@colaboradorid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = validacion.colaborador.PColaboradorid
        listaParametros.Add(parametro)

        ',@validacionstatusid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "validacionstatusid"
        parametro.Value = validacion.validacionestatus
        listaParametros.Add(parametro)

        ',@validaciontipoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "validaciontipoid"
        parametro.Value = validacion.validaciontipo.validaciontipoid
        listaParametros.Add(parametro)

        ',@validacionfecha AS DATETIME
        parametro = New SqlParameter
        parametro.ParameterName = "validacionfecha"
        parametro.Value = validacion.fechavalidacion
        listaParametros.Add(parametro)

        ',@comentario AS VARCHAR(150)
        parametro = New SqlParameter
        parametro.ParameterName = "comentario"
        parametro.Value = validacion.comentario
        listaParametros.Add(parametro)

        ',@NuevoClasificacionPersonaID AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "NuevoClasificacionPersonaID"
        parametro.Value = NuevoClasificacionPersonaID
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)



        operaciones.EjecutarSentenciaSP("Cliente.SP_Alta_Validacion_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaCliente(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "" +
        '                        " SELECT * FROM Cliente.Cliente WHERE clie_clienteid = " + clienteID.ToString
        Dim consulta As String = "" +
                                "SELECT * FROM Cliente.Cliente c inner Join cliente.Clasificaciones cc " +
                                "ON c.clie_clasificacionclienteid = cc.clas_clasificacioclientenid WHERE clie_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function ListaCliente_Todos(texto As String, load As Boolean, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " " +
        '                        " SELECT DISTINCT" +
        '                        "   clie_clienteid  AS 'SAY ID'" +
        '                        " , clie_idsicy AS 'SICY ID'" +
        '                        " , Persona.pers_nombre AS CLIENTE" +
        '                        " , A.pers_nombre AS 'NOMBRE RFC'" +
        '                        " , B.pers_nombre AS 'TIENDA/EMBARQUE/CEDIS'" +
        '                        " , CONTACTO.pers_nombre AS CONTACTO" +
        '                        " , isnull ((select top 1  ListaPrecioCliente +' ('+ estatus +')' from Ventas.vListaPrecioCliente" +
        '                        " where InicioVigencia<=getdate() and FinVigencia>=GETDATE() and IdSAY=clie_clienteid order by InicioVigencia asc),'')" +
        '                        "         as ListaVigente" +
        '                        " FROM Cliente.Cliente" +
        '                        " LEFT JOIN Framework.Persona AS Persona ON Persona.pers_personaid = clie_personaidcliente" +
        '                        " JOIN Framework.TiposPersonas ON tipe_personaid = Persona.pers_personaid" +
        '                        " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tipe_clasificacionpersonaid" +
        '                        " LEFT JOIN Cliente.ClienteRFC AS C ON C.crfc_personaid = clie_personaidcliente" +
        '                        " LEFT JOIN Cliente.ClienteRFC AS D ON D.crfc_clienteid = clie_clienteid" +
        '                        " LEFT JOIN Framework.Persona AS A ON A.pers_personaid = D.crfc_personaid" +
        '                        " LEFT JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienterfcid = D.crfc_clienterfcid" +
        '                        " LEFT JOIN Framework.Persona AS B ON B.pers_personaid = tiec_personaid" +
        '                        " LEFT JOIN Framework.RelacionesPersonas ON repe_persona2 = Persona.pers_personaid " +
        '                        " LEFT JOIN Framework.Persona AS CONTACTO ON CONTACTO.pers_personaid = repe_personaid1" +
        '                        " LEFT JOIN ventas.vListaPrecioCliente on clie_clienteid=IdSAY "

        'If load Then
        '    consulta += " WHERE clie_clienteid = 0 "
        'Else
        '    consulta += " WHERE ((Persona.pers_nombre LIKE '%" + texto + "%' ) " +
        '        " OR (Persona.pers_razonsocial LIKE '%" + texto + "%' )" +
        '        " OR (A.pers_nombre LIKE '%" + texto + "%' ) " +
        '        " OR (B.pers_nombre LIKE '%" + texto + "%' ) " +
        '        " OR (CONTACTO.pers_nombre LIKE '%" + texto + "%' ))"
        '    If leerAsignados Then
        '        'consulta += " AND clie_colaboradorid_vendedor = " + vendedorID.ToString
        '        'consulta += " AND (clie_colaboradorid_vendedor = " + vendedorID.ToString + " or clie_colaboradorid_atnc = " + vendedorID.ToString + ")"
        '        consulta += " AND clie_clienteid IN (select cmfa_clienteid from Cliente.ClienteMarcaFamiliaProyeccionAgente where cmfa_activo=1 and cmfa_colaboradorid_agente IN (select agus_colaboradorid_vendedor from Ventas.AgentesUsuarios where agus_activo=1 and agus_usuarioid=" & usuarioID & "))"
        '    End If
        'End If

        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@texto"
        parametro.Value = texto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@load"
        parametro.Value = load
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@leerAsignados"
        parametro.Value = leerAsignados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = usuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ListaClientes_Consulta_TodosLosClientes]", listaParametros)
        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaCliente_Cliente(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " " +
        '                        " SELECT " +
        '                        "    distinct clie_clienteid  AS 'SAY ID'" +
        '                        "  , clie_idsicy AS 'SICY ID'" +
        '                        "  , A.pers_nombre AS CLIENTE" +
        '                        "  , (CAST(domi_calle + ' #' + domi_numexterior + '. ' + LTRIM(RTRIM(UPPER(city_nombre))) + ', ' + LTRIM(RTRIM(UPPER(esta_nombre))) + ', ' + LTRIM(RTRIM(UPPER(pais_nombre))) AS varchar(200))) AS DOMICILIO" +
        '                        "  , clpe_nombre AS 'TIPO'" +
        '                        "  ,isnull ((select top 1  ListaPrecioCliente +' ('+ estatus +')' from Ventas.vListaPrecioCliente" +
        '                        "  where InicioVigencia<=getdate() and FinVigencia>=GETDATE() and IdSAY=clie_clienteid order by InicioVigencia asc),'')" +
        '                        "  as ListaVigente " +
        '                        " FROM Cliente.Cliente" +
        '                        " JOIN Framework.Persona  AS A ON A.pers_personaid = clie_personaidcliente" +
        '                        " LEFT JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid  = clie_clasificacionpersonaid" +
        '                        " LEFT JOIN Framework.EmailPersonas ON empe_personaid = A.pers_personaid" +
        '                        " LEFT JOIN Framework.Domicilio ON domi_personaid = A.pers_personaid" +
        '                        " LEFT JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
        '                        " LEFT JOIN Framework.Estados ON esta_estadoid = city_estadoid" +
        '                        " LEFT JOIN Framework.Paises ON pais_paisid = esta_paisid" +
        '                        " LEFT JOIN ventas.vListaPrecioCliente on clie_clienteid=IdSAY " +
        '                        " WHERE A.pers_nombre LIKE '%" + texto + "%' "

        ''If texto.Length = 0 Then
        ''    consulta += " WHERE clie_clienteid = 0"
        ''Else
        ''    consulta += " WHERE A.pers_nombre LIKE '%" + texto + "%' "
        ''End If

        'If leerAsignados Then
        '    ' consulta += " AND (clie_colaboradorid_vendedor = " + vendedorID.ToString + " or clie_colaboradorid_atnc = " + vendedorID.ToString + ")"
        '    ' consulta += "AND (clie_colaboradorid_atnc = " + vendedorID.ToString + " or clie_clienteid IN" +
        '    ' "(select cmfa_clienteid from Cliente.ClienteMarcaFamiliaProyeccionAgente where cmfa_colaboradorid_agente = " + vendedorID.ToString + " and cmfa_activo = 1))"
        '    consulta += " AND clie_clienteid IN (select cmfa_clienteid from Cliente.ClienteMarcaFamiliaProyeccionAgente where cmfa_activo=1 and cmfa_colaboradorid_agente IN (select agus_colaboradorid_vendedor from Ventas.AgentesUsuarios where agus_activo=1 and agus_usuarioid=" & usuarioID & "))"
        'End If

        'Return operaciones.EjecutaConsulta(consulta)

        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@TextoNombre"
        parametro.Value = texto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SoloAsignados"
        parametro.Value = leerAsignados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = usuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ConsultaClientes_ListadoClientes]", listaParametros)


    End Function


    Public Function ListaCliente_RFC(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " " +
        '                        " SELECT " +
        '                        "   distinct clie_clienteid  AS 'SAY ID'" +
        '                        " , clie_idsicy AS 'SICY ID'" +
        '                        " , A.pers_nombre AS CLIENTE" +
        '                        " ,clpe_nombre AS 'TIPO'" +
        '                        " , B.pers_nombre AS 'NOMBRE'" +
        '                        " , crfc_RFC AS 'RFC'" +
        '                        " , B.pers_CURP AS 'CURP'" +
        '                        " , B.pers_razonsocial AS 'RAZÓN SOCIAL'" +
        '                        " , empe_email AS 'EMAIL'" +
        '                        " , (CAST(domi_calle + ' #' + domi_numexterior + '. ' + LTRIM(RTRIM(UPPER(city_nombre))) + ', ' + LTRIM(RTRIM(UPPER(esta_nombre))) + ', ' + LTRIM(RTRIM(UPPER(pais_nombre))) AS varchar(200))) AS DOMICILIO" +
        '                        " ,isnull ((select top 1  ListaPrecioCliente +' ('+ estatus +')' from Ventas.vListaPrecioCliente" +
        '                        " where InicioVigencia<=getdate() and FinVigencia>=GETDATE() and IdSAY=clie_clienteid order by InicioVigencia asc),'')" +
        '                        "                        as ListaVigente" +
        '                        " , (CASE" +
        '                        " 		WHEN crfc_activo = 0 THEN (CAST(0 AS BIT))" +
        '                        "		ELSE (CAST(1 AS BIT))" +
        '                        " 	END) AS 'ESTATUS'" +
        '                        " FROM Cliente.Cliente" +
        '                        " JOIN Framework.Persona  AS A ON A.pers_personaid = clie_personaidcliente" +
        '                        " JOIN Cliente.ClienteRFC ON crfc_clienteid= clie_clienteid" +
        '                        " JOIN Framework.Persona AS B ON B.pers_personaid = crfc_personaid" +
        '                        " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = crfc_clasificacionpersonaid" +
        '                        " LEFT JOIN Framework.EmailPersonas ON empe_personaid = B.pers_personaid " +
        '                        " LEFT JOIN Framework.Domicilio ON domi_personaid = B.pers_personaid" +
        '                        " LEFT JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
        '                        " LEFT JOIN Framework.Estados ON esta_estadoid = city_estadoid" +
        '                        " LEFT JOIN Framework.Paises ON pais_paisid = esta_paisid" +
        '                        " left JOIN ventas.vListaPrecioCliente on clie_clienteid=IdSAY " +
        '                        " WHERE B.pers_nombre LIKE '%" + texto + "%' "

        'If texto.Length = 0 Then
        '    consulta += " WHERE clie_clienteid = 0"
        'Else
        '    consulta += " WHERE B.pers_nombre LIKE '%" + texto + "%' "
        'End If

        'If leerAsignados Then
        '    'consulta += " AND clie_colaboradorid_vendedor = " + vendedorID.ToString
        '    'consulta += " AND (clie_colaboradorid_vendedor = " + vendedorID.ToString + " or clie_colaboradorid_atnc = " + vendedorID.ToString + ")"
        '    consulta += " AND clie_clienteid IN (select cmfa_clienteid from Cliente.ClienteMarcaFamiliaProyeccionAgente where cmfa_activo=1 and cmfa_colaboradorid_agente IN (select agus_colaboradorid_vendedor from Ventas.AgentesUsuarios where agus_activo=1 and agus_usuarioid=" & usuarioID & "))"
        'End If

        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@texto"
        parametro.Value = texto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@leerAsignados"
        parametro.Value = leerAsignados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = usuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ListaClientes_Consulta_RFC]", listaParametros)

        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaCliente_TEC(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " " +
        '                         " SELECT " +
        '                    "   distinct clie_clienteid  AS 'SAY ID'" +
        '                    " , clie_idsicy AS 'SICY ID'" +
        '                    " , A.pers_nombre AS CLIENTE" +
        '                    " ,clpe_nombre AS 'TIPO'" +
        '                    " , B.pers_nombre AS 'TIENDA/EMBARQUE/CEDIS'" +
        '                    " , 	CASE WHEN domi_poblacionid IS NULL THEN" +
        '                    " (CAST(domi_calle + ' #' + domi_numexterior + '. ' + LTRIM(RTRIM(UPPER(city_nombre))) + ', ' + LTRIM(RTRIM(UPPER(esta_nombre))) + ', ' +" +
        '                    " LTRIM(RTRIM(UPPER(pais_nombre))) AS varchar(200)))" +
        '                    " ELSE (CAST(domi_calle + ' #' + domi_numexterior + '. ' + LTRIM(RTRIM(UPPER((SELECT pobl_nombre FROM Framework.Poblaciones " +
        '                    " WHERE pobl_poblacionid = domi_poblacionid)))) + ', ' + LTRIM(RTRIM(UPPER(city_nombre))) + ', ' + LTRIM(RTRIM(UPPER(esta_nombre))) +" +
        '                    " ', ' + LTRIM(RTRIM(UPPER(pais_nombre))) AS varchar(200))) END AS DOMICILIO" +
        '                    " ,isnull ((select top 1  ListaPrecioCliente +' ('+ estatus +')' from Ventas.vListaPrecioCliente" +
        '                    " where InicioVigencia<=getdate() and FinVigencia>=GETDATE() and IdSAY=clie_clienteid order by InicioVigencia asc),'')" +
        '                    "                            as ListaVigente" +
        '                    " , (CASE" +
        '                    "		WHEN tiec_activo = 0 THEN (CAST(0 AS BIT))" +
        '                    "		ELSE (CAST(1 AS BIT))" +
        '                    "	END) AS 'ESTATUS' , clie_activo as 'CLIENTE ACTIVO'" +
        '                    " FROM Cliente.Cliente" +
        '                    " JOIN Framework.Persona  AS A ON A.pers_personaid = clie_personaidcliente" +
        '                    " JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienteid = clie_clienteid" +
        '                    " JOIN Framework.Persona AS B ON B.pers_personaid = tiec_personaid" +
        '                    " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tiec_clasificacionpersonaid" +
        '                    " LEFT JOIN Framework.Domicilio ON domi_personaid = B.pers_personaid" +
        '                    " LEFT JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
        '                    " LEFT JOIN Framework.Estados ON esta_estadoid = city_estadoid" +
        '                    " LEFT JOIN Framework.Paises ON pais_paisid = esta_paisid" +
        '                    " LEFT JOIN ventas.vListaPrecioCliente on clie_clienteid=IdSAY " +
        '                    " WHERE B.pers_nombre LIKE '%" + texto + "%' "

        'If texto.Length = 0 Then
        '    consulta += " WHERE clie_clienteid = 0"
        'Else
        '    consulta += " WHERE B.pers_nombre LIKE '%" + texto + "%' "
        'End If

        'If leerAsignados Then
        '    'consulta += " AND clie_colaboradorid_vendedor = " + vendedorID.ToString
        '    'consulta += " AND (clie_colaboradorid_vendedor = " + vendedorID.ToString + " or clie_colaboradorid_atnc = " + vendedorID.ToString + ")"
        '    consulta += " AND clie_clienteid IN (select cmfa_clienteid from Cliente.ClienteMarcaFamiliaProyeccionAgente where cmfa_activo=1 and cmfa_colaboradorid_agente IN (select agus_colaboradorid_vendedor from Ventas.AgentesUsuarios where agus_activo=1 and agus_usuarioid=" & usuarioID & "))"
        'End If

        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@texto"
        parametro.Value = texto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@leerAsignados"
        parametro.Value = leerAsignados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = usuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ListaClientes_Consulta_TEC]", listaParametros)

        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaCliente_Contacto(texto As String, leerAsignados As Boolean, usuarioID As Integer, cedis As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " " +
        '                       " SELECT " +
        '                       "  distinct clie_clienteid  AS 'SAY ID'" +
        '                       " , clie_idsicy AS 'SICY ID'" +
        '                       " , A.pers_nombre AS 'CLIENTE'" +
        '                       " , clpe_nombre AS 'TIPO'" +
        '                       " , B.pers_nombre AS 'CONTACTO'" +
        '                       " , empe_email AS 'EMAIL'" +
        '                       " ,isnull ((select top 1  ListaPrecioCliente +' ('+ estatus +')' from Ventas.vListaPrecioCliente" +
        '                       " where InicioVigencia<=getdate() and FinVigencia>=GETDATE() and IdSAY=clie_clienteid order by InicioVigencia asc),'')" +
        '                       "                         as ListaVigente" +
        '                       " , (CASE" +
        '                       " 		WHEN repe_activo = 0 THEN (CAST(0 AS BIT))" +
        '                       "		ELSE (CAST(1 AS BIT))" +
        '                       "	END) AS 'ACTIVO'" +
        '                       " FROM Cliente.Cliente" +
        '                       " JOIN Framework.Persona  AS A ON A.pers_personaid = clie_personaidcliente" +
        '                       " JOIN Framework.RelacionesPersonas ON repe_persona2 = A.pers_personaid " +
        '                       " JOIN Framework.Persona AS B ON B.pers_personaid = repe_personaid1" +
        '                       " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = repe_clasificacionpersonaid1" +
        '                       " JOIN Framework.EmailPersonas ON empe_personaid = B.pers_personaid" +
        '                       " LEFT JOIN ventas.vListaPrecioCliente on clie_clienteid=IdSAY " +
        '                       " WHERE B.pers_nombre LIKE '%" + texto + "%' and repe_activo=1 and clpe_activo=1"


        'If texto.Length = 0 Then
        '    consulta += " WHERE clie_clienteid = 0"
        'Else
        '    consulta += " WHERE B.pers_nombre LIKE '%" + texto + "%' "
        'End If

        'If leerAsignados Then
        '    'consulta += " AND clie_colaboradorid_vendedor = " + vendedorID.ToString
        '    'consulta += " AND (clie_colaboradorid_vendedor = " + vendedorID.ToString + " or clie_colaboradorid_atnc = " + vendedorID.ToString + ")"
        '    consulta += " AND clie_clienteid IN (select cmfa_clienteid from Cliente.ClienteMarcaFamiliaProyeccionAgente where cmfa_activo=1 and cmfa_colaboradorid_agente IN (select agus_colaboradorid_vendedor from Ventas.AgentesUsuarios where agus_activo=1 and agus_usuarioid=" & usuarioID & "))"
        'End If

        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@texto"
        parametro.Value = texto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@leerAsignados"
        parametro.Value = leerAsignados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioID"
        parametro.Value = usuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ListaClientes_Consulta_Contacto]", listaParametros)

        'Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaCliente_ActualizacionMasiva() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
        " SELECT CAST(0 AS bit) AS ' ', c.clie_idsicy AS 'ID SICY'," +
        " c.clie_clienteid AS 'ID SAY'," +
        " c.clie_nombregenerico AS 'CLIENTE'," +
        " ruta.ruta_nombre as Ruta," +
        " UPPER(CAST(Atn.codr_nombre + ' ' + Atn.codr_apellidopaterno + ' ' + Atn.codr_apellidomaterno AS varchar(250))) AS 'ATENCIÓN A CLIENTES'," +
        " c.clie_activo" +
        " FROM Cliente.Cliente c" +
        " JOIN Nomina.Colaborador AS Atn ON clie_colaboradorid_atnc = Atn.codr_colaboradorid" +
        " inner JOIN Ventas.Rutas as ruta" +
        " on ruta.ruta_rutaid=c.clie_rutaid" +
        " WHERE clie_activo = 1" +
        " ORDER BY 'ID SICY'"

        'sin ruta
        'SELECT CAST(0 AS bit) AS ' ', c.clie_idsicy AS 'ID SICY', c.clie_clienteid AS 'ID SAY', c.clie_nombregenerico AS 'CLIENTE', UPPER(CAST(Atn.codr_nombre + ' ' + Atn.codr_apellidopaterno + ' ' + Atn.codr_apellidomaterno AS varchar(250))) AS 'ATENCIÓN A CLIENTES', c.clie_activo FROM Cliente.Cliente c JOIN Nomina.Colaborador AS Atn ON clie_colaboradorid_atnc = Atn.codr_colaboradorid WHERE clie_activo = 1 ORDER BY 'ID SICY'

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub Asignacion_Masiva_Atn_Clientes(clienteid As Integer, colaboradorid As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @clienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        ',@colaboradorid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Asignacion_Masiva_Atn_Clientes", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Sub Asignacion_Masiva_Atn_Clientes_SICY(clientesicy_id As Integer, colaboradorid As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ' @clientesicy_id AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clientesicy_id"
        parametro.Value = clientesicy_id
        listaParametros.Add(parametro)

        ',@colaboradorid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("dbo.SP_Asignacion_Masiva_Atn_Clientes", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub Asignacion_Masiva_Agente_Ventas(clienteid As Integer, colaboradorid As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @clienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        ',@colaboradorid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Asignacion_Masiva_Agente_Ventas", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Sub Asignacion_Masiva_Agente_Ventas_SICY(clientesicy_id As Integer, colaboradorid As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ' @clientesicy_id AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clientesicy_id"
        parametro.Value = clientesicy_id
        listaParametros.Add(parametro)

        ',@colaboradorid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("dbo.SP_Asignacion_Masiva_Agente_Ventas", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub


    Public Sub Modificacion_Status_Cliente_SICY(clienteid_sicy As Integer, status_cliente As String)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        ',@clienteid_sicy AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clienteid_sicy"
        parametro.Value = clienteid_sicy
        listaParametros.Add(parametro)

        ',@status_cliente AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "status_cliente"
        parametro.Value = status_cliente
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("SP_Modificacion_Status_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function ListaMarca() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   marc_marcaid " +
                                " , LTRIM(RTRIM(UPPER(marc_descripcion))) marc_descripcion" +
                                " FROM Programacion.Marcas" +
                                " WHERE marc_activo = 1 " +
                                " ORDER BY marc_descripcion"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaEmpresa() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   empr_empresaid" +
                                " , LTRIM(RTRIM(UPPER(empr_nombre))) empr_nombre" +
                                " FROM Framework.Empresas" +
                                " WHERE empr_activo = 1 " +
                                " ORDER BY empr_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable

        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        If tipo_busqueda = 1 Then
            consulta += " SELECT IdCodigo AS 'Parámetro',  CAST(0 AS BIT) AS ' ', IdModelo AS 'Modelo',Descripcion AS 'Descripción'," +
                        "    Color AS 'Color', Coleccion AS 'Colección', Marca AS 'Marca'" +
                        " FROM vEstilos ORDER BY Descripcion, IdModelo, Color "
        Else
            If tipo_busqueda = 2 Then
                consulta += " SELECT IdCadena AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdCadena AS 'Cadena', nombre AS 'Nombre'" +
                            " FROM vCadenas "
                If operaciones.Servidor = operaciones_sicy.Servidor Then
                    consulta += " WHERE Activo = 'S' AND IdCadena NOT IN (" +
                                "   SELECT clie_idsicy FROM [" + operaciones.NombreDB + "].[Cliente].[Cliente]" +
                                "   WHERE clie_idsicy IS NOT NULL) ORDER BY nombre "
                Else
                    consulta += " WHERE Activo = 'S' AND IdCadena NOT IN (" +
                                "   SELECT clie_idsicy FROM [" + operaciones.Servidor + "].[" + operaciones.NombreDB + "].[Cliente].[Cliente]" +
                                "   WHERE clie_idsicy IS NOT NULL) ORDER BY nombre "
                End If

            Else
                If tipo_busqueda = 3 Then
                    consulta += " SELECT IdTalla AS 'Parámetro', CAST(0 AS BIT) AS ' ' , IdTalla AS 'Talla ID', Talla AS 'Talla' FROM tallas ORDER BY Talla "
                Else
                    If tipo_busqueda = 4 Then
                        Dim id_parametros_split As String() = id_parametros.ToString.Split(",")
                        consulta += " SELECT " +
                            "   bahi_bahiaid  AS 'Parámetro' " +
                            " , CAST(0 AS bit) AS ' ' " +
                            " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía' " +
                            " , bahi_bloque AS 'Bloque' " +
                            " , bahi_nivel 'Nivel' " +
                            " , bahi_fila AS 'Fila' " +
                            " , bahi_segmento AS 'Segmento' " +
                            " , bahi_bahiaid AS 'Clave' " +
                            " FROM Almacen.Bahia" +
                            " WHERE bahi_activo = 1 AND bahi_nave IN (" + id_parametros_split(0) + ") AND bahi_almacen IN (" + id_parametros_split(1) + ")" +
                            " ORDER BY bahi_bloque, bahi_nivel, bahi_segmento, bahi_bahiaid "
                    Else
                        If tipo_busqueda = 5 Then
                            consulta += " SELECT IdNave AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nave AS 'Nave' FROM Naves WHERE Activo = 1 ORDER BY Nave"
                        Else
                            If tipo_busqueda = 6 Then
                                consulta += " SELECT " +
                                    "   A.codr_colaboradorid AS 'Parámetro' " +
                                    " , CAST (0 AS bit) AS ' ' " +
                                    " , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS 'Operador' " +
                                    " FROM [Nomina].[Colaborador] AS A " +
                                    " JOIN [Nomina].[ColaboradorLaboral] AS B ON B.labo_colaboradorid = A.codr_colaboradorid " +
                                    " JOIN [Framework].[Grupos] AS C ON C.grup_grupoid = B.labo_departamentoid " +
                                    " WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 ORDER BY A.codr_nombre "
                            Else
                                If tipo_busqueda = 7 Then
                                    consulta += " SELECT IdAgente AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nombre AS 'Nombre',Iniciales AS 'Iniciales' FROM Agentes WHERE Activo = 1 ORDER BY Nombre "
                                Else
                                    If tipo_busqueda = 8 Then
                                        Dim id_parametros_split As String() = id_parametros.ToString.Split(",")
                                        consulta += " SELECT DISTINCT CAST(0 AS integer) AS 'Parámetro', CAST(0 AS bit) AS ' ', bahi_descripcion AS 'Descripción de Bahía' " +
                                            " FROM Almacen.Bahia WHERE bahi_activo = 1 AND bahi_nave IN (" + id_parametros_split(0) + ") AND bahi_almacen IN (" + id_parametros_split(1) + ")" +
                                            " ORDER BY bahi_descripcion"
                                    Else
                                        If tipo_busqueda = 9 Then
                                            consulta += " SELECT IdDistribucion AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdDistribucion AS 'ID', cadena AS 'Cliente', distribucion AS 'Tienda', ciudad AS 'Ciudad' " +
                                                    " FROM vCadenasDistribucion" +
                                                    " ORDER BY cliente, distribucion, Ciudad"
                                        Else
                                            If tipo_busqueda = 10 Then
                                                consulta += " SELECT calc_calce AS 'Parámetro', CAST(0 AS BIT) AS ' ', calc_calce AS 'Talla'" +
                                                     " FROM Programacion.Calce" +
                                                     " WHERE calc_activo = 1" +
                                                     " ORDER BY calc_calce"
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If tipo_busqueda = 6 Then
            Return operaciones.EjecutaConsulta(consulta)
        Else
            Return operaciones_sicy.EjecutaConsulta(consulta)
        End If

    End Function

    ''' <summary>
    ''' Recupera las listas de precios asignadas a un cliente
    ''' </summary>
    ''' <param name="clienteID">id del cliente del cual se recuperaran las listas de precio</param>
    ''' <returns>Datatable con la informacion recuperada en la ejecucion de la consulta</returns>
    ''' <remarks></remarks>
    Public Function buscarListasDePreciosDeCliente(ByVal clienteID As Integer, ByVal NoAsignadas As Boolean, ByVal LVasiganada As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        If NoAsignadas = False Then
            If clienteID > 0 Then
                If LVasiganada Then
                    consulta = "SELECT  v.lpvt_listaprecioventaid AS 'Id', b.lpba_nombrelista + '(' + b.lpba_codigolistabase + ') | ' + v.lpvt_descripcion + " +
                    " '(' + v.lpvt_codigolistaventa + ')' AS 'Lista' FROM Ventas.ListaPreciosVenta v " +
                    " INNER JOIN Ventas.ListaPreciosBase b ON v.lpvt_listapreciosbaseid = b.lpba_listapreciosbaseid " +
                    " INNER JOIN Ventas.ListaVentasCliente c ON c.lvcl_listaprecioventasid = v.lpvt_listaprecioventaid " +
                    " WHERE lpba_estatus = 2 and c.lvcl_clienteid = " + clienteID.ToString + " and c.lvcl_activo = 1  order by LISTA "
                Else
                    consulta = " IF ( SELECT COUNT(lpcp_listaprecioclienteproductoid) FROM Ventas.ListaPreciosBase" +
                    " JOIN Ventas.ListaPreciosVenta ON lpba_listapreciosbaseid = lpvt_listapreciosbaseid" +
                    " JOIN Ventas.ListaVentasCliente ON lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
                    " JOIN Ventas.ListaVentasClientePrecio ON lvcp_listaventasclienteid = lvcl_listaventasclienteid" +
                    " JOIN Ventas.ListaPrecioClienteProducto ON lpcp_listaventasclienteid = lvcp_listaventasclienteprecioid" +
                    " WHERE lpba_estatus = 2 AND lvcp_estatusid = 26 AND lvcl_clienteid = " + clienteID.ToString +
                    " )" +
                    " IS NOT NULL " +
                    " BEGIN" +
                    " 		IF (SELECT COUNT(lpcp_listaprecioclienteproductoid)" +
                    " 		FROM Ventas.ListaPreciosBase" +
                    " 		JOIN Ventas.ListaPreciosVenta ON lpba_listapreciosbaseid = lpvt_listapreciosbaseid" +
                    " 		JOIN Ventas.ListaVentasCliente ON lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
                    " 		JOIN Ventas.ListaVentasClientePrecio ON lvcp_listaventasclienteid = lvcl_listaventasclienteid" +
                    " 		JOIN Ventas.ListaPrecioClienteProducto ON lpcp_listaventasclienteid = lvcp_listaventasclienteprecioid" +
                    " 		WHERE lpba_estatus = 2 AND lvcp_estatusid = 26 AND lvcl_clienteid = " + clienteID.ToString +
                    " 		)" +
                      " 		> 0 " +
                  " 		BEGIN" +
                    " 				SELECT DISTINCT lpvt_listaprecioventaid AS 'Id',  lpba_nombrelista + '(' + lpba_codigolistabase + ') | ' + lpvt_descripcion + " +
                    " 				'(' + lpvt_codigolistaventa + ') | ' + lvcp_descripcion AS 'Lista',  lvcp_estatusid" +
                    " 				FROM Ventas.ListaPreciosBase" +
                    " 				JOIN Ventas.ListaPreciosVenta ON lpba_listapreciosbaseid = lpvt_listapreciosbaseid" +
                    " 				JOIN Ventas.ListaVentasCliente ON lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
                    " 				JOIN Ventas.ListaVentasClientePrecio ON lvcp_listaventasclienteid = lvcl_listaventasclienteid " +
                    " 				JOIN Ventas.ListaPrecioClienteProducto ON lpcp_listaventasclienteid = lvcp_listaventasclienteprecioid" +
                    " 				WHERE lpba_estatus = 2 AND lvcp_estatusid = 26 AND lvcl_clienteid = " + clienteID.ToString +
                    " 				GROUP BY	lvcl_listaventasclienteid,lpvt_listaprecioventaid,lpba_nombrelista,lpba_codigolistabase,lpvt_descripcion,lpvt_codigolistaventa,lvcp_estatusid,lvcp_descripcion" +
                    " 				ORDER BY LISTA" +
                    " 		END " +
                    " 		ELSE BEGIN" +
                    " 			SELECT DISTINCT lpvt_listaprecioventaid AS 'Id', lpba_nombrelista + '(' + lpba_codigolistabase + ') | ' + lpvt_descripcion + '(' + lpvt_codigolistaventa + ')' AS 'Lista'" +
                    " 			FROM Ventas.ListaPreciosBase" +
                    " 			JOIN Ventas.ListaPreciosVenta ON lpba_listapreciosbaseid = lpvt_listapreciosbaseid" +
                    " 			JOIN Ventas.ListaVentasCliente ON lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
                    " 			WHERE lpba_estatus = 2 AND lvcl_clienteid = " + clienteID.ToString +
                    " 			AND lpvt_activo = 1" +
                    " 			AND lvcl_activo = 1" +
                    " 			GROUP BY	lvcl_listaventasclienteid,lpvt_listaprecioventaid,lpba_nombrelista,lpba_codigolistabase,lpvt_descripcion,lpvt_codigolistaventa" +
                    " 			ORDER BY LISTA" +
                    " 		END" +
                    " END " +
                    " ELSE BEGIN" +
                    " 	SELECT DISTINCT lpvt_listaprecioventaid AS 'Id'," +
                    " 	lpba_nombrelista + '(' + lpba_codigolistabase + ') | ' + lpvt_descripcion + '(' + lpvt_codigolistaventa + ')' AS 'Lista'" +
                    " 	FROM Ventas.ListaPreciosBase" +
                    " 	JOIN Ventas.ListaPreciosVenta ON lpba_listapreciosbaseid = lpvt_listapreciosbaseid" +
                    " 	JOIN Ventas.ListaVentasCliente ON lvcl_listaprecioventasid = lpvt_listaprecioventaid" +
                    " 	WHERE lpba_estatus = 2 AND lpvt_estemporal = 0 AND lvcl_clienteid = " + clienteID.ToString + " AND lpvt_activo = 1 AND lvcl_activo = 1" +
                    " 	GROUP BY	lvcl_listaventasclienteid, lpvt_listaprecioventaid, lpba_nombrelista, lpba_codigolistabase, lpvt_descripcion, lpvt_codigolistaventa" +
                    " 	ORDER BY LISTA" +
                    " END"
                End If
            Else
                consulta = " SELECT lv.lpvt_listaprecioventaid AS 'Id', lb.lpba_nombrelista + '(' + lb.lpba_codigolistabase + ') | ' + " +
                            " lv.lpvt_descripcion + '(' + lv.lpvt_codigolistaventa + ')' AS 'Lista'" +
                            " FROM Ventas.ListaPreciosBase lb" +
                            " JOIN Ventas.ListaPreciosVenta lv ON lb.lpba_listapreciosbaseid = lv.lpvt_listapreciosbaseid" +
                            " WHERE lpba_estatus = 2 AND lv.lpvt_estemporal = 1 ORDER BY Lista"
            End If
        Else
            'consulta = "SELECT DISTINCT v.lpvt_listaprecioventaid AS 'Id', b.lpba_nombrelista + '(' + b.lpba_codigolistabase + ') | ' + " +
            '    " v.lpvt_descripcion + '(' + v.lpvt_codigolistaventa + ')' AS 'Lista' FROM Ventas.ListaPreciosVenta v " +
            '    " INNER JOIN Ventas.ListaPreciosBase b ON v.lpvt_listapreciosbaseid = b.lpba_listapreciosbaseid" +
            '    " INNER JOIN Ventas.ListaVentasCliente c ON c.lvcl_listaprecioventasid = v.lpvt_listaprecioventaid" +
            '    " WHERE lpba_estatus = 2 AND c.lvcl_activo = 1 AND lpvt_listaprecioventaid NOT IN (SELECT DISTINCT v.lpvt_listaprecioventaid " +
            '    " FROM Ventas.ListaPreciosVenta v" +
            '    " INNER JOIN Ventas.ListaPreciosBase b ON v.lpvt_listapreciosbaseid = b.lpba_listapreciosbaseid" +
            '    " INNER JOIN Ventas.ListaVentasCliente c ON c.lvcl_listaprecioventasid = v.lpvt_listaprecioventaid " +
            '    " WHERE lpba_estatus = 2 AND c.lvcl_clienteid = " + clienteID.ToString + " AND c.lvcl_activo = 1)"
            'consulta += " order by Lista"
            consulta = "SELECT DISTINCT v.lpvt_listaprecioventaid AS 'Id', b.lpba_nombrelista + '(' + b.lpba_codigolistabase + ') | ' + " +
                " v.lpvt_descripcion + '(' + v.lpvt_codigolistaventa + ')' AS 'Lista' FROM Ventas.ListaPreciosVenta v " +
                " INNER JOIN Ventas.ListaPreciosBase b ON v.lpvt_listapreciosbaseid = b.lpba_listapreciosbaseid" +
                " INNER JOIN Ventas.ListaVentasCliente c ON c.lvcl_listaprecioventasid = v.lpvt_listaprecioventaid" +
                " WHERE lpba_estatus = 2 /*AND c.lvcl_activo = 1*/ AND lpvt_listaprecioventaid NOT IN (SELECT DISTINCT v.lpvt_listaprecioventaid " +
                " FROM Ventas.ListaPreciosVenta v" +
                " INNER JOIN Ventas.ListaPreciosBase b ON v.lpvt_listapreciosbaseid = b.lpba_listapreciosbaseid" +
                " INNER JOIN Ventas.ListaVentasCliente c ON c.lvcl_listaprecioventasid = v.lpvt_listaprecioventaid " +
                " WHERE lpba_estatus = 2 AND c.lvcl_clienteid = " + clienteID.ToString + " AND c.lvcl_activo = 1)"
            consulta += " order by Lista"
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function recuperar_Informacion_Cliente_Para_LP(ByVal IdCliente As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT iccl_facturar,iccl_documentar,iccl_incrementopar_porcent,iccl_incrementopar_monto," +
            " iccl_monedaid,iccl_tipoivaid,iccl_tipofleteid,iccl_calcularpreciocondescuento," +
            " CASE WHEN iccl_incotermid IS NULL THEN 0 ELSE iccl_incotermid END AS 'IDINCOTERM'," +
            " CASE WHEN iccl_incotermid IS NULL THEN 'NO ASIGNADO' ELSE inco_claveincoterm END AS 'INCOTERM'," +
            " CASE WHEN iccl_incrementopar_monto IS NULL OR iccl_incrementopar_monto = 0 THEN '%' ELSE '$' END AS 'porcentaje_cantidad'," +
            " mone_abreviatura as 'MONEDA AV', tifl_nombre, tiva_nombre FROM cobranza.InfoCliente" +
            " LEFT JOIN Embarque.INCOTERMS ON inco_incotermsid = iccl_incotermid" +
            " LEFT JOIN Cobranza.TipoIVA ON iccl_tipoivaid = tiva_tipoivaid" +
            " LEFT JOIN Ventas.TipoFlete ON tifl_tipofleteid = iccl_tipofleteid" +
            " left join Framework.Moneda on mone_monedaid = iccl_monedaid WHERE iccl_clienteid =  " + IdCliente.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    ''' <summary>
    ''' recupera la lista de los clientes dependiendo del tipo de usuario logeado
    ''' </summary>
    ''' <param name="idUsuario"></param>
    ''' <returns>datatable con la lista de los clientes</returns>
    ''' <remarks></remarks>
    Public Function recuperarListaClientesUsuarioPedidosWeb(ByVal idUsuario As Int32, ByVal TipoComercializadora As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoComercializadora"
        parametro.Value = TipoComercializadora
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Ventas].SP_PedidosWeb_CargarListaClientes_28/10/2020", listaParametros)
    End Function
    Public Function verModelosGenerales(ByVal idCliente As Int32) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dato As Boolean = False
        Dim dt As New DataTable

        cadena = "SELECT clie_verproductosgenerales" +
                " FROM Cliente.Cliente" +
                " WHERE clie_clienteid = " + idCliente.ToString

        dt = operacion.EjecutaConsulta(cadena)

        If dt.Rows.Count > 0 Then
            dato = CBool(dt.Rows(0).Item(0).ToString)
        End If


        Return dato
    End Function

    Public Function ValidarListaDePrecios_Aceptada_o_capturada_asignadas(ByVal ClienteId As Integer)
        Dim objPersistencia As New OperacionesProcedimientos
        Dim Consulta As String = String.Empty

        Consulta = <Consulta> SELECT v.lpvt_listaprecioventaid AS 'Id', d.lvcp_descripcion, d.lvcp_estatusid
                    FROM Ventas.ListaPreciosVenta v
                    INNER JOIN Ventas.ListaPreciosBase b ON v.lpvt_listapreciosbaseid = b.lpba_listapreciosbaseid
                    INNER JOIN Ventas.ListaVentasCliente c ON c.lvcl_listaprecioventasid = v.lpvt_listaprecioventaid
                    JOIN Ventas.ListaVentasClientePrecio as d on d.lvcp_listaventasclienteid = c.lvcl_listaventasclienteid
                    JOIN Ventas.ListaPrecioClienteProducto as e on e.lpcp_listaventasclienteid = d.lvcp_listaventasclienteprecioid
                            WHERE lpba_estatus = 2
                    AND c.lvcl_clienteid = <%= ClienteId.ToString %>
                    AND c.lvcl_activo = 1
                    and d.lvcp_estatusid in (25, 26)
                    group by v.lpvt_listaprecioventaid , d.lvcp_descripcion, d.lvcp_estatusid</Consulta>.Value

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function RecuperarInformacion_ListaVEntasClienteCapturada(ByVal IdCliente As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = <Consulta>SELECT DISTINCT lpvt_listaprecioventaid AS 'Id', 
	                            lpba_nombrelista + '(' + lpba_codigolistabase + ')' , 
	                            lpvt_descripcion + '(' + lpvt_codigolistaventa + ')  ' , 
	                            lvcp_descripcion AS 'Lista', 
	                            lvcp_estatusid
                            FROM Ventas.ListaPreciosBase
                            JOIN Ventas.ListaPreciosVenta ON lpba_listapreciosbaseid = lpvt_listapreciosbaseid
                            JOIN Ventas.ListaVentasCliente ON lvcl_listaprecioventasid = lpvt_listaprecioventaid
                            JOIN Ventas.ListaVentasClientePrecio ON lvcp_listaventasclienteid = lvcl_listaventasclienteid
                            JOIN Ventas.ListaPrecioClienteProducto ON lpcp_listaventasclienteid = lvcp_listaventasclienteprecioid
                            WHERE lpba_estatus = 2 AND lvcp_estatusid = 25 AND lvcl_clienteid = <%= IdCliente.ToString %>  
                            GROUP BY lvcl_listaventasclienteid,
		                             lpvt_listaprecioventaid,
		                             lpba_nombrelista,
		                             lpba_codigolistabase,
		                             lpvt_descripcion,
	 	                             lpvt_codigolistaventa,
		                             lvcp_estatusid,
		                             lvcp_descripcion
                            ORDER BY LISTA</Consulta>.Value

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    '' Recupera la lista de rfc del cliente (pedidos web)
    Public Function recuperarListaRfcClientes(ByVal idCliente As Int32, ByVal PedidoId As Int32) As DataTable

        'consulta = <consulta> SELECT crfc_clienterfcid, 
        '            CASE WHEN crfc_clasificacionpersonaid = 14 THEN 'F -' 
        '            ELSE CASE WHEN crfc_clasificacionpersonaid = 13 THEN 'R - ' ELSE '? -' END 
        '            END + UPPER(pers_nombre) +' ('+crfc_RFC+')' AS 'Persona',pers_nombre,crfc_clasificacionpersonaid FROM Cliente.ClienteRFC 
        '            JOIN Framework.Persona ON crfc_personaid = pers_personaid where crfc_clienteid = <%= idCliente.ToString %>
        '             and crfc_activo = 1 ORDER BY pers_nombre
        '           </consulta>.Value

        Dim objPersistencia As New OperacionesProcedimientos
        'Dim consulta As String = String.Empty
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@clienteid"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAYid"
        parametro.Value = PedidoId
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_VentasRecuperarListaClienteRFC]", listaParametros)
    End Function

    'Recupera los datos generales del cliente (pedidos web)
    Public Function cargarInformacionCliente(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim Parametro As New SqlParameter

        Parametro.ParameterName = "@IdClienteSAY"
        Parametro.Value = idCliente
        listaParametros.Add(Parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_PedidosWEB_Recuperar_Informacion_General_de_Cliente_Para_Pedidos", listaParametros)

    End Function

    'Recupera los agentes asignados a cada cliente (pedidos web)
    Public Function recuperarAgentesCliente(ByVal idCliente As Int32, ByVal idUsuario As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim Parametro As New SqlParameter

        Parametro.ParameterName = "idCliente"
        Parametro.Value = idCliente
        listaParametros.Add(Parametro)

        Parametro = New SqlParameter

        Parametro.ParameterName = "idUsuario"
        Parametro.Value = idUsuario
        listaParametros.Add(Parametro)

        'Dim consulta As String = String.Empty
        'consulta = <consulta>
        '                select * from (
        '                        SELECT cmae_colaboradorid_agente, codr_nombre +' '+ codr_apellidopaterno +' '+ codr_apellidomaterno as 'codr_nombre'
        '                  FROM Cliente.ClienteMarcaAgenteEmpresa
        '                        JOIN Nomina.Colaborador on codr_colaboradorid = cmae_colaboradorid_agente
        '                        WHERE cmae_clienteid = <%= idCliente.ToString %>
        '                        AND codr_activo = 1 AND cmae_activo=1) as cons
        '                GROUP BY  cmae_colaboradorid_agente,codr_nombre
        '                ORDER BY codr_nombre
        '                                           </consulta>.Value
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaAgentesCliente", listaParametros)
        'Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    'Recupera las marcas que vende cada agente para cada cliente (pedidos web)
    Public Function recuperarMarcasAgenteCliente(ByVal idCliente As Int32, ByVal idAgente As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idAgente"
        parametros.Value = idAgente
        listaParametros.Add(parametros)
        'Dim consulta As String = String.Empty
        'consulta = <consulta>
        '  declare @idAgente as int
        '            set	@idAgente=<%= idAgente.ToString %>
        '            IF @idAgente = 0
        '            begin
        '            select cmae_marcaid, marc_descripcion   from Cliente.ClienteMarcaAgenteEmpresa
        '                 join Nomina.Colaborador on codr_colaboradorid = cmae_colaboradorid_agente
        '                 JOIN Programacion.Marcas ON marc_marcaid = cmae_marcaid
        '                 where cmae_clienteid = <%= idCliente.ToString %>
        '                 AND codr_activo = 1
        '                 and marc_activo = 1 and cmae_activo=1 order by marc_descripcion
        '            END
        '            ELSE
        '            BEGIN
        '            select cmae_marcaid, marc_descripcion   from Cliente.ClienteMarcaAgenteEmpresa
        '                 join Nomina.Colaborador on codr_colaboradorid = cmae_colaboradorid_agente
        '                 JOIN Programacion.Marcas ON marc_marcaid = cmae_marcaid
        '                 where cmae_clienteid =<%= idCliente.ToString %>
        '                 and cmae_colaboradorid_agente = @idAgente
        '                 AND codr_activo = 1
        '                 and marc_activo = 1 and cmae_activo=1 order by marc_descripcion
        '            END
        '           </consulta>.Value
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_RecuperarMarcasAgenteFamilia", listaParametros)
        'Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    'Recupera los ramos de un cliente (pedidos web)
    Public Function recuperarListaRamosCliente(ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = <consulta>
                      select racl_ramoid, ramo_nombre from (SELECT clie_clienteid , racl_ramoid , ramo_nombre, 
                        COUNT(tiec_tiendaembarquecedisid) AS tiec_numtiendas , racl_numtiendasreal
                        , racl_marcaje FROM Cliente.Cliente LEFT JOIN Cliente.ClienteRamos ON racl_clienteid = clie_clienteid
                        LEFT JOIN Cliente.ClienteRFC ON crfc_clienteid = racl_clienteid LEFT JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienterfcid = crfc_clienterfcid AND tiec_ramoid = racl_ramoid
                        LEFT JOIN Cliente.Ramos ON ramo_ramoid = racl_ramoid WHERE clie_clienteid = <%= idCliente.ToString %>
                        GROUP BY clie_clienteid, racl_ramoid, ramo_nombre, racl_numtiendasreal, racl_marcaje) as cons
                         where  tiec_numtiendas>0 or racl_numtiendasreal>0  ORDER BY ramo_nombre
                  </consulta>.Value
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''Recupera la vigencia y la lista de precios del cliente
    Public Function RecuperarFechaVigencia_ListaPrecioCliente(ByVal idCliente As Integer, ByVal fecha As Date)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        'consulta = <Consulta>
        '                SELECT 'Vigente del '+convert(varchar(10), InicioVigencia , 103)+' al ' +convert(varchar(10), FinVigencia , 103) as vigencia
        '                ,convert(varchar(10), InicioVigencia , 103) inicioVigencia, convert(varchar(10), FinVigencia , 103) finVigencia FROM Ventas.vListaPrecioCliente 
        '                WHERE idListaVentasClientePrecio = <%= IdListaVentasClientePrecio.ToString %>
        '           </Consulta>.Value


        ' consulta = <consulta>
        '                SELECT idListaVentas,idListaVentasClientePrecio, idListaBase,ListaPrecioCliente + ' ' + ListaBase as listaBase , ListaPrecioCliente, convert(varchar(10), InicioVigencia , 103)+' al ' +convert(varchar(10), FinVigencia , 103) as vigencia
        '                 ,convert(varchar(10), InicioVigencia , 103) inicioVigencia, convert(varchar(10), FinVigencia , 103) finVigencia 
        'FROM Ventas.vListaPrecioCliente WHERE IdSAY=<%= idCliente.ToString %> AND '<%= fecha.ToShortDateString %>' BETWEEN InicioVigencia AND FinVigencia
        '            </consulta>.Value

        ''Dim objPersistencia As New OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "fecha_vigencia"
        parametros.Value = fecha
        listaParametros.Add(parametros)
        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_ConsultarFechaVigencia_ListaPrecioCliente", listaParametros)
        ''Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    'Valida si existe una orden del cliente con ese numero (pedidos web)
    Public Function recuperarOrdenClientePedido(ByVal idCliente As Int32, ByVal orden As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idCliente", idCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@OrdenCliente", orden)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_RecuperaOrdenCliente]", listaParametros)

        'Dim consulta As String = String.Empty
        'consulta = <consulta>
        '                SELECT c.clie_clienteid,pedi_ordenpedidocliente,vo.clie_idsicy,  vo.pedi_pedidoid
        '                FROM  Ventas.vPedidosOrdenClienteV2 vo 
        '                        INNER JOIN Cliente.Cliente c on c.clie_idsicy= vo.clie_idsicy
        '                WHERE c.clie_clienteid=<%= idCliente.ToString %> AND pedi_ordenpedidocliente = '<%= orden.ToString %>'
        '                        and vo.pedi_pedidoid > 0
        '                GROUP BY c.clie_clienteid,pedi_ordenpedidocliente,vo.clie_idsicy, pedi_pedidoid
        '           </consulta>.Value
        'Return objPersistencia.EjecutaConsulta(consulta)

    End Function

    'Recupera la lista de clientes por usuario con filtro
    Public Function recuperarListaClientesUsuarioFiltroPedidosWeb(ByVal idUsuario As Int32, ByVal caracter As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "caracter"
        parametro.Value = caracter
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].SP_PedidosWeb_CargarListaClientesFiltro", listaParametros)
    End Function

    ''recupera los contactos de correo de pedido por agente
    Public Function recuperarContactosPedidoAgente(ByVal idCliente As Int32, ByVal marcasId As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "Cliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MarcasID"
        parametro.Value = marcasId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConcatenarContacto_Email", listaParametros)
    End Function

    ''recupera la consulta de familias asignadas al agente 
    Public Function recuperarFamiliaVentasAsignada(ByVal idCliente As Int32, ByVal idAgente As String) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaFamiliaMarcaAgente", listaParametros)
    End Function

    Public Sub actualizarClientesSICY()
        Dim objPersistencia As New OperacionesProcedimientosSICY

        objPersistencia.EjecutaConsulta("EXEC [Cliente].[SP_Replicar_Clientes_SAY_A_SICY]")
    End Sub

    ''recupera la consulta del cliente para saber si esta bloqueado
    Public Function recuperarInformacionBloqueoCliente(ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "IdClienteSAY"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWEB_Recuperar_InformacionBloqueoCliente", listaParametros)
    End Function

#Region "uso de cfdi"
    Public Function obtenerTipoPersonaCliente(ByVal clienteid As Int32) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_PedidosWEB_ConsultaTipoPersonaCliente", listaParametros)
    End Function

#End Region

    Public Function buscarClientesNombreComercial(ByVal Activo As Boolean, ByVal clienteID As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteID"
        parametro.Value = clienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Catalogos_ObtenerListadoClientes]", listaParametros)
    End Function

    Public Function EditarMarcaAgenteVentasBloqueo(ByVal id As Integer, ByVal cambio As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim Parametro As New SqlParameter("@idTabla", id)
        listaParametros.Add(Parametro)

        Parametro = New SqlParameter("@Cambio", cambio)
        listaParametros.Add(Parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_FTC_EditarMarcaAgenteVentasBloqueo]", listaParametros)

    End Function



End Class
