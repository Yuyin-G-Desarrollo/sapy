Imports Persistencia
Imports System.Data.SqlClient

Public Class ClientesDatosDA

    Public Function verCoordinadores() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT
	                                c.codr_colaboradorid AS 'ID_COORD'
	                               ,CONCAT(c.codr_nombre, ' ', c.codr_apellidopaterno, ' ', c.codr_apellidomaterno) AS 'NOMBRE_COLABORADOR'
                                FROM Nomina.Colaborador AS c
                                INNER JOIN Nomina.ColaboradorLaboral AS cl
	                                ON cl.labo_colaboradorid = c.codr_colaboradorid
                                LEFT JOIN Nomina.Puestos AS pu
	                                ON pu.pues_puestoid = cl.labo_puestoid
                                WHERE cl.labo_puestoid IN (1056, 1351)
                                AND pu.pues_activo = 1
                                AND c.codr_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub altaDomicilioCliente(ByVal domicilio As Entidades.Domicilio, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = domicilio.calle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numinterior"
        If String.IsNullOrWhiteSpace(domicilio.numinterior) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = domicilio.numinterior
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numexterior"
        parametro.Value = domicilio.numexterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = domicilio.colonia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = domicilio.cp
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "delegacion"
        If String.IsNullOrWhiteSpace(domicilio.delegacion) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = domicilio.delegacion
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = domicilio.ciudad.CciudadId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "estadoid"
        'parametro.Value = domicilio.estado.EIDDEstado
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "paisid"
        'parametro.Value = domicilio.pais.PIDPais
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "poblacionid"
        If IsNothing(domicilio.poblacion) Then
            parametro.Value = 0
        Else
            parametro.Value = domicilio.poblacion.poblacionid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        If IsNothing(domicilio.persona) Then
            parametro.Value = 0
        Else
            parametro.Value = domicilio.persona.personaid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = domicilio.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = 1
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Domicilio", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarDomicilioCliente(ByVal domicilio As Entidades.Domicilio, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@calle AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = domicilio.calle
        listaParametros.Add(parametro)

        ',@numinterior AS VARCHAR(50)--PERMITE NULO
        parametro = New SqlParameter
        parametro.ParameterName = "numinterior"
        If String.IsNullOrWhiteSpace(domicilio.numinterior) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = domicilio.numinterior
        End If
        listaParametros.Add(parametro)

        ',@numexterior AS VARCHAR(50) 
        parametro = New SqlParameter
        parametro.ParameterName = "numexterior"
        parametro.Value = domicilio.numexterior
        listaParametros.Add(parametro)

        ',@colonia AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = domicilio.colonia
        listaParametros.Add(parametro)

        ',@cp AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "cp"
        parametro.Value = domicilio.cp
        listaParametros.Add(parametro)

        ',@delegacion AS VARCHAR(50)--PERMITE NULO
        parametro = New SqlParameter
        parametro.ParameterName = "delegacion"
        If String.IsNullOrWhiteSpace(domicilio.delegacion) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = domicilio.delegacion
        End If
        listaParametros.Add(parametro)

        ',@ciudadid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = domicilio.ciudad.CciudadId
        listaParametros.Add(parametro)

        ',@poblacionid AS INTEGER--PERMITE NULO
        parametro = New SqlParameter
        parametro.ParameterName = "poblacionid"
        If IsNothing(domicilio.poblacion) Then
            parametro.Value = 0
        Else
            parametro.Value = domicilio.poblacion.poblacionid
        End If
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        If IsNothing(domicilio.persona) Then
            parametro.Value = 0
        Else
            parametro.Value = domicilio.persona.personaid
        End If
        listaParametros.Add(parametro)

        ',@clasificacionpersonaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = domicilio.clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = 1
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Domicilio", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarVentasInfoCliente(ByVal infoCliente As Entidades.InformacionClienteVentas, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@fechafundacion AS DATETIME
        parametro = New SqlParameter
        parametro.ParameterName = "fechafundacion"
        If infoCliente.fechafundacion = DateTime.MinValue Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.fechafundacion
        End If
        listaParametros.Add(parametro)

        ',@festejaaniversario AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "festejaaniversario"
        If Not infoCliente.festejaaniversario Then
            parametro.Value = False
        Else
            parametro.Value = infoCliente.festejaaniversario
        End If
        listaParametros.Add(parametro)

        ',@festejadiasfestivos AS  BIT
        parametro = New SqlParameter
        parametro.ParameterName = "festejadiasfestivos"
        If Not infoCliente.festejadiasfestivos Then
            parametro.Value = False
        Else
            parametro.Value = infoCliente.festejadiasfestivos
        End If
        listaParametros.Add(parametro)

        ',@capacidadcompratotal AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "capacidadcompratotal"
        If infoCliente.capacidadcompratotal = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.capacidadcompratotal
        End If
        listaParametros.Add(parametro)

        ',@capacidadcomprayuyin AS VARCHAR(10)
        parametro = New SqlParameter
        parametro.ParameterName = "capacidadcomprayuyin"
        If infoCliente.capacidadcomprayuyin = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.capacidadcomprayuyin
        End If
        listaParametros.Add(parametro)

        ',@publicidadcliente AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "publicidadcliente"
        If String.IsNullOrWhiteSpace(infoCliente.publicidadcliente) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = infoCliente.publicidadcliente
        End If
        listaParametros.Add(parametro)

        ',@nivelsocioeconomicoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "nivelsocioeconomicoid"
        If IsNothing(infoCliente.nivelsocioeconomico) Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.nivelsocioeconomico.nivelsocioeconomicoid
        End If
        listaParametros.Add(parametro)

        ',@contactoinicial AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "contactoinicial"
        If Not infoCliente.contactoinicial Then
            parametro.Value = False
        Else
            parametro.Value = infoCliente.contactoinicial
        End If
        listaParametros.Add(parametro)

        ',@buscamoscliente AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "buscamoscliente"
        If Not infoCliente.buscamoscliente Then
            parametro.Value = False
        Else
            parametro.Value = infoCliente.buscamoscliente
        End If
        listaParametros.Add(parametro)

        ',@tienepedidoinicial AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "tienepedidoinicial"
        If Not infoCliente.tienepedidoinicial Then
            parametro.Value = False
        Else
            parametro.Value = infoCliente.tienepedidoinicial
        End If
        listaParametros.Add(parametro)

        ',@articulospedidoinicial AS VARCHAR(200)
        parametro = New SqlParameter
        parametro.ParameterName = "articulospedidoinicial"
        If String.IsNullOrWhiteSpace(infoCliente.articulospedidoinicial) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = infoCliente.articulospedidoinicial
        End If
        listaParametros.Add(parametro)

        ',@fechaentregapedidoinicial AS DATETIME
        parametro = New SqlParameter
        parametro.ParameterName = "fechaentregapedidoinicial"
        If infoCliente.fechaentregapedidoinicial = DateTime.MinValue Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.fechaentregapedidoinicial
        End If
        listaParametros.Add(parametro)

        ',@parespedidoinicial AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "parespedidoinicial"
        If infoCliente.parespedidoinicial = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.parespedidoinicial
        End If
        listaParametros.Add(parametro)

        ',@sitioaccesoproveedor AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "sitioaccesoproveedor"
        If String.IsNullOrWhiteSpace(infoCliente.sitioaccesoproveedor) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = infoCliente.sitioaccesoproveedor
        End If
        listaParametros.Add(parametro)

        ',@usuarioproveedor AS VARCHAR(20)
        parametro = New SqlParameter
        parametro.ParameterName = "usuarioproveedor"
        If String.IsNullOrWhiteSpace(infoCliente.usuarioproveedor) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = infoCliente.usuarioproveedor
        End If
        listaParametros.Add(parametro)

        ',@contrasenaproveedor AS VARCHAR(20)
        parametro = New SqlParameter
        parametro.ParameterName = "contrasenaproveedor"
        If String.IsNullOrWhiteSpace(infoCliente.contrasenaproveedor) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = infoCliente.contrasenaproveedor
        End If
        listaParametros.Add(parametro)

        ',@almacenid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "almacenid"
        If IsNothing(infoCliente.almacen) Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.almacen.almacenid
        End If
        listaParametros.Add(parametro)

        ',@personaidconfirma AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaidconfirma"
        If IsNothing(infoCliente.persona) Then
            parametro.Value = 0
        Else
            parametro.Value = infoCliente.persona.personaid
        End If
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = infoCliente.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        If Not (infoCliente.activo) Then
            parametro.Value = False
        Else
            parametro.Value = infoCliente.activo
        End If
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_InfoCliente_Datos", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarCobranzaInfoCliente(ByVal infoCliente As Entidades.InformacionClienteCobranza, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "plazo"
        'If infoCliente.plazo = 0 Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = infoCliente.plazo
        'End If
        parametro.Value = infoCliente.plazo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "limitecredito"
        If infoCliente.limitecredito = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.limitecredito
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cuenta"
        If String.IsNullOrWhiteSpace(infoCliente.cuenta) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = infoCliente.cuenta
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "facturar"
        If infoCliente.facturar = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.facturar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "documentar"
        If infoCliente.documentar = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.documentar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "incrementoparporcent"
        If infoCliente.incrementoparporcent = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.incrementoparporcent
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "incrementoparmonto"
        If infoCliente.incrementoparmonto = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.incrementoparmonto
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porcfacturasugerido"
        If infoCliente.porcfacturasugerido = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.porcfacturasugerido
        End If
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "monedaid"
        'If IsNothing(infoCliente.moneda) Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = infoCliente.moneda.monedaid
        'End If
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "tipoivaid"
        'If IsNothing(infoCliente.tipoiva) Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = infoCliente.tipoiva.tipoivaid
        'End If
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montocreditoautorizado"
        If infoCliente.montocreditoautorizado = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = infoCliente.montocreditoautorizado
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = infoCliente.cliente.clienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cobranza.SP_Editar_InfoCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaCobranzaInfoCliente(clienteid As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Cobranza.InfoCliente WHERE iccl_clienteid =" + clienteid.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub editarClienteClienteRFC(clienteRFC As Entidades.ClienteRFC, tipoPersona As Entidades.TipoPersona, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = clienteRFC.persona.personaid
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


        ',@clasificacionpersonaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        If IsNothing(clienteRFC.clasificacionpersona) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.clasificacionpersona.clasificacionpersonaid
        End If
        listaParametros.Add(parametro)

        ',@ramoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ramoid"
        If IsNothing(clienteRFC.ramo) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.ramo.ramoid
        End If
        listaParametros.Add(parametro)

        '',@rutaid AS INTEGER
        'parametro = New SqlParameter
        'parametro.ParameterName = "rutaid"
        'If IsNothing(clienteRFC.ruta) Then
        '    parametro.Value = 0
        'Else
        '    parametro.Value = clienteRFC.ruta.rutaid
        'End If
        'listaParametros.Add(parametro)

        ',@RFC AS VARCHAR(13)
        parametro = New SqlParameter
        parametro.ParameterName = "RFC"
        If String.IsNullOrWhiteSpace(clienteRFC.RFC) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = clienteRFC.RFC
        End If
        listaParametros.Add(parametro)

        ',@porcentajefacturar AS DECIMAL(5,2)
        parametro = New SqlParameter
        parametro.ParameterName = "porcentajefacturar"
        If clienteRFC.porcentajefacturar = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = clienteRFC.porcentajefacturar
        End If
        listaParametros.Add(parametro)

        ',@porcentajeremisionar AS DECIMAL(5,2)
        parametro = New SqlParameter
        parametro.ParameterName = "porcentajeremisionar"
        If clienteRFC.porcentajeremisionar = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = clienteRFC.porcentajeremisionar
        End If
        listaParametros.Add(parametro)

        ',@comentarios AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "comentarios"
        If String.IsNullOrWhiteSpace(clienteRFC.comentarios) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = clienteRFC.comentarios
        End If
        listaParametros.Add(parametro)

        ',@clienterfcidafacturar AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienterfcidafacturar"
        If IsNothing(clienteRFC.clienterfcafacturar) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.clienterfcafacturar.clienterfcid
        End If
        listaParametros.Add(parametro)

        ',@incoterm AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "incoterm"
        If IsNothing(clienteRFC.incoterm) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.incoterm.incotermsid
        End If
        listaParametros.Add(parametro)

        ',@parcialidades1 AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "parcialidades1"
        If clienteRFC.parcialidades1 = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.parcialidades1
        End If
        listaParametros.Add(parametro)

        ',@parcialidadesx AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "parcialidadesx"
        If clienteRFC.parcialidadesx = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.parcialidadesx
        End If
        listaParametros.Add(parametro)

        ',@metodopagoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "metodopagoid"
        If IsNothing(clienteRFC.metodopago) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.metodopago.metodopagoid
        End If
        listaParametros.Add(parametro)

        ',@formapagoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "formapagoid"
        If IsNothing(clienteRFC.formapago) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.formapago.formapagoid
        End If
        listaParametros.Add(parametro)

        ',@cuenta AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "cuenta"
        If clienteRFC.cuenta = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.cuenta
        End If
        listaParametros.Add(parametro)

        ',@moneda AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "moneda"
        If IsNothing(clienteRFC.moneda) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.moneda.monedaid
        End If
        listaParametros.Add(parametro)

        ',@tipoivaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipoiva"
        If IsNothing(clienteRFC.tipoiva) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.tipoiva.tipoivaid
        End If
        listaParametros.Add(parametro)

        ',@tipoclienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipocliente"
        If IsNothing(clienteRFC.tipocliente) Then
            parametro.Value = 0
        Else
            parametro.Value = clienteRFC.tipocliente.tipoclienteid
        End If
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = clienteRFC.activo
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        If Not tipoPersona Is Nothing Then
            parametro = New SqlParameter
            parametro.ParameterName = "@regimenFiscalId"
            parametro.Value = tipoPersona.regimenFiscalId
            listaParametros.Add(parametro)
        Else
            parametro = New SqlParameter
            parametro.ParameterName = "@regimenFiscalId"
            parametro.Value = 0
            listaParametros.Add(parametro)
        End If
        

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_ClienteRFC", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaClienteRFC(personaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Cliente.ClienteRFC where crfc_personaid =" + personaID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub editarCedisClienteCEDIS(TEC As Entidades.TiendaEmbarqueCedis, tipoPersona As Entidades.TipoPersona, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tiendaembarquecedisid"
        If TEC.tiendaembarquecedisid = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.tiendaembarquecedisid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienterfcid"
        If Not TEC.clienterfc Is Nothing Then
            If TEC.clienterfc.clienterfcid = 0 Then
                parametro.Value = 0
            Else
                parametro.Value = TEC.clienterfc.clienterfcid
            End If
        Else
            parametro.Value = 0
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        If IsNothing(TEC.persona) Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.persona.personaid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        If IsNothing(TEC.clasificacionpersona) Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.clasificacionpersona.clasificacionpersonaid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ramoid"
        If IsNothing(TEC.ramo) Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.ramo.ramoid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "reembarcar"
        If Not (TEC.reembarcar) Then
            parametro.Value = False
        Else
            parametro.Value = TEC.reembarcar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "reembarcarporcobrar"
        If Not (TEC.reembarcarporcobrar) Then
            parametro.Value = False
        Else
            parametro.Value = TEC.reembarcarporcobrar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipofleteid"
        If IsNothing(TEC.tipoflete) Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.tipoflete.tipofleteid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conveniotransportes"
        If String.IsNullOrEmpty(TEC.conveniotransportes) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = TEC.conveniotransportes
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipovalorid"
        If IsNothing(TEC.tipovalor) Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.tipovalor.tipovalorid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "declararvalor"
        If Not (TEC.declararvalor) Then
            parametro.Value = False
        Else
            parametro.Value = TEC.declararvalor
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "declararenpesos"
        If Not (TEC.declararenpesos) Then
            parametro.Value = False
        Else
            parametro.Value = TEC.declararenpesos
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "valoradeclarar"
        If TEC.valoradeclarar = Decimal.Zero Then
            parametro.Value = Decimal.Zero
        Else
            parametro.Value = TEC.valoradeclarar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "comentarios"
        If String.IsNullOrWhiteSpace(TEC.comentarios) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = TEC.comentarios
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "notasempaque"
        If String.IsNullOrWhiteSpace(TEC.notasempaque) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = TEC.notasempaque
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "seguro"
        If String.IsNullOrWhiteSpace(TEC.seguro) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = TEC.seguro
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "poliza"
        If String.IsNullOrWhiteSpace(TEC.poliza) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = TEC.poliza
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoempaqueid"
        If IsNothing(TEC.tipoempaque) Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TEC.tipoempaque.tipoempaqueid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tamanoempaqueid"
        If IsNothing(TEC.tamanoempaque) Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TEC.tamanoempaque.tamanoempaqueid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "minimoparesempaque"
        If TEC.minimoparesempaque = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.minimoparesempaque
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "maximoparesempaque"
        If TEC.maximoparesempaque = 0 Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.maximoparesempaque
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipotiendaid"
        If IsNothing(TEC.tipotienda) Then
            parametro.Value = 0
        Else
            parametro.Value = TEC.tipotienda.tipotiendaid
        End If
        listaParametros.Add(parametro)

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


        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        If Not (TEC.activo) Then
            parametro.Value = False
        Else
            parametro.Value = TEC.activo
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "codigoTienda"
        If String.IsNullOrEmpty(TEC.codigoTienda) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = TEC.codigoTienda
        End If
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_CEDIS", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaClienteCEDIS(personaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Cliente.TiendaEmbarqueCEDIS JOIN Framework.Persona ON tiec_personaid = pers_personaid WHERE tiec_personaid = " + personaID.ToString
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoClienteRFCPersona(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT crfc_clienterfcid" +
                                " , LTRIM(RTRIM(UPPER(clpe_nombre))) + ' - ' + LTRIM(RTRIM(UPPER(pers_nombre))) + ' - ' + LTRIM(RTRIM(UPPER(pers_razonsocial))) + ' (' + LTRIM(RTRIM(UPPER(crfc_RFC))) + ')' AS pers_razonsocial," +
                                " LTRIM(RTRIM(UPPER(pers_nombre))) AS pers_nombre " +
                                " FROM Cliente.ClienteRFC " +
                                " JOIN Framework.Persona ON pers_personaid = crfc_personaid " +
                                " join Framework.ClasificacionPersona on clpe_clasificacionpersonaid = crfc_clasificacionpersonaid" +
                                " WHERE crfc_clienteid = " + clienteID.ToString + " AND crfc_RFC IS NOT NULL" +
                                " ORDER BY clpe_nombre, pers_razonsocial, crfc_RFC "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoTECClienteRFC(clienteRFCID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   pers_personaid" +
                                " , LTRIM(RTRIM ( UPPER(pers_nombre))) AS pers_nombre " +
                                " FROM Cliente.TiendaEmbarqueCEDIS " +
                                " JOIN Framework.Persona ON pers_personaid = tiec_personaid" +
                                " WHERE tiec_clienterfcid = " + clienteRFCID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListadoClienteRFCPersonaFactura(clienteRFC As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT " +
                                "   crfc_clienterfcid " +
                                " , LTRIM(RTRIM ( UPPER(crfc_RFC))) AS crfc_RFC" +
                                " , LTRIM(RTRIM ( UPPER(pers_nombre))) AS pers_nombre " +
                                " FROM Cliente.ClienteRFC " +
                                " JOIN Framework.Persona ON pers_personaid = crfc_personaid " +
                                " WHERE crfc_clienteid = " + clienteRFC.ToString +
                                " AND crfc_RFC IS NOT NULL " +
                                " AND crfc_clasificacionpersonaid = 14" +
                                " ORDER BY pers_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_Grid_ClienteRFC(clienteid As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT " +
                                "   pers_personaid" +
                                " , A.crfc_clienterfcid " +
                                " , clpe_clasificacionpersonaid" +
                                " , LTRIM(RTRIM(UPPER(clpe_nombre))) AS clpe_nombre" +
                                " , LTRIM(RTRIM(UPPER(pers_nombre))) AS pers_nombre" +
                                " , LTRIM(RTRIM(UPPER(pers_razonsocial))) AS pers_razonsocial" +
                                " , ( " +
                                     " CAST (" +
                                     " domi_calle + ' #' " +
                                     " + domi_numexterior +  '. ' " +
                                     " + LTRIM(RTRIM(UPPER(city_nombre))) + ', '" +
                                     " + LTRIM(RTRIM(UPPER(esta_nombre))) + ', '" +
                                     " + LTRIM(RTRIM(UPPER(pais_nombre)))" +
                                     " AS VARCHAR(200)) " +
                                "   ) AS domicilio" +
                                " , LTRIM(RTRIM(UPPER(A.crfc_RFC))) AS crfc_RFC" +
                                " , LTRIM(RTRIM(UPPER(pers_CURP))) AS pers_CURP" +
                                " , NULL" +
                                " , A.crfc_porcentajefacturar AS crfc_porcentajefacturar" +
                                " , LTRIM(RTRIM(UPPER(B.crfc_RFC))) AS crfc_clienterfcidafacturar" +
                                " ,  A.crfc_activo AS crfc_activo" +
                                " , A.crfc_parcialidades1" +
                                " , A.crfc_parcialidadesx" +
                                " , mepa_nombre" +
                                " , mone_nombre" +
                                " , tiva_nombre" +
                                " , ticl_nombre" +
                                " FROM Framework.Persona" +
                                " JOIN Framework.TiposPersonas ON tipe_personaid = pers_personaid" +
                                " JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tipe_clasificacionpersonaid" +
                                " JOIN Cliente.ClienteRFC AS A ON crfc_personaid = pers_personaid" +
                                " LEFT JOIN Cliente.ClienteRFC AS B ON B.crfc_clienterfcid = A.crfc_clienterfcidafacturar" +
                                " LEFT JOIN Framework.Domicilio ON domi_personaid = pers_personaid" +
                                " LEFT JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
                                " LEFT JOIN Framework.Estados ON esta_estadoid = city_estadoid" +
                                " LEFT JOIN Framework.Paises ON pais_paisid = esta_paisid" +
                                " LEFT JOIN Cobranza.MetodoPago ON mepa_metodopagoid = A.crfc_metodopagoid " +
                                " LEFT JOIN Framework.Moneda ON mone_monedaid = A.crfc_monedaid " +
                                " LEFT JOIN Cobranza.TipoIVA ON tiva_tipoivaid = A.crfc_tipoivaid" +
                                " LEFT JOIN Ventas.TipoCliente ON ticl_tipoclienteid = A.crfc_tipoclienteid" +
                                " WHERE A.crfc_clienteid = " + clienteid.ToString +
                                " ORDER BY clpe_nombre, pers_nombre, pers_razonsocial "

        '" , LTRIM(RTRIM(UPPER(empe_email))) AS empe_email" +
        '" LEFT JOIN Framework.EmailPersonas ON empe_personaid = pers_personaid" +

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function Datos_ClienteRFCCEDIS(personaID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tiec_personaid" +
                                " , tiec_tiendaembarquecedisid" +
                                " , crfc_clienterfcid" +
                                " , clie_clienteid" +
                                " , ramo_nombre" +
                                " , LTRIM(RTRIM(UPPER(pers_nombre))) AS pers_nombre" +
                                " , domi_ciudadid" +
                                " , domi_poblacionid" +
                                " ,	case WHEN domi_poblacionid is not NULL" +
                                 "   THEN" +
                                 "   (CAST(domi_calle + ' #' + domi_numexterior + '. ' + LTRIM(RTRIM(UPPER((select pobl_nombre from Framework.Poblaciones where pobl_poblacionid = domi_poblacionid)))) + ', ' + LTRIM(RTRIM(UPPER(city_nombre))) + ', ' + LTRIM(RTRIM(UPPER(esta_nombre))) + ', ' + LTRIM(RTRIM(UPPER(pais_nombre))) AS varchar(200))) " +
                                 "   else" +
                                 "   (CAST(domi_calle + ' #' + domi_numexterior + '. ' + LTRIM(RTRIM(UPPER(city_nombre))) + ', ' + LTRIM(RTRIM(UPPER(esta_nombre))) + ', ' + LTRIM(RTRIM(UPPER(pais_nombre))) AS varchar(200))) " +
                                 "   end AS domi_domicilio," +
                                "  (" +
                                "  	 CASE WHEN tiec_activo = 0" +
                                "  	 THEN (CAST(('INACTIVO') AS VARCHAR)) " +
                                " 	 ELSE (CAST(('ACTIVO') AS VARCHAR)) END" +
                                "   ) AS crfc_activo" +
                                " , LTRIM(RTRIM(UPPER(tifl_nombre))) AS tifl_nombre" +
                                " , (" +
                                "  	 CASE WHEN tiec_reembarcar= 0" +
                                " 	 THEN (CAST(('NO') AS VARCHAR)) " +
                                " 	 ELSE (CAST(('SI') AS VARCHAR)) END" +
                                "   ) AS crfc_activo" +
                                " , tiec_valoradeclarar AS tiec_valoradeclarar" +
                                " , LTRIM(RTRIM(UPPER(tiec_conveniotransportes))) AS tiec_conveniotransportes" +
                                " , LTRIM(RTRIM(UPPER(tiec_seguro))) AS tiec_seguro" +
                                " , LTRIM(RTRIM(UPPER(tiec_poliza))) AS tiec_poliza" +
                                " , LTRIM(RTRIM(UPPER(tiem_nombre))) AS tiem_nombre" +
                                " , LTRIM(RTRIM(UPPER(crfc_RFC))) AS crfc_RFC" +
                                " , tiec_activo as 'ACTIVO' " +
                                " FROM Cliente.TiendaEmbarqueCEDIS"
        If areaOperativa = 9 Then
            consulta += " JOIN Cliente.RFC_TiendaEmbarqueCEDIS ON rtec_tiendaembarquecedisid = tiec_tiendaembarquecedisid AND rtec_activo = 1"
        End If
        consulta += " JOIN Cliente.ClienteRFC ON tiec_clienterfcid = crfc_clienterfcid" +
                                " JOIN Cliente.Cliente ON crfc_clienteid = clie_clienteid" +
                                " JOIN Framework.Persona ON pers_personaid = tiec_personaid" +
                                " JOIN Framework.Domicilio ON domi_personaid = pers_personaid" +
                                " JOIN Framework.Ciudades ON city_ciudadid = domi_ciudadid" +
                                " JOIN Framework.Estados ON esta_estadoid = city_estadoid" +
                                " JOIN Framework.Paises ON pais_paisid = esta_paisid" +
                                " LEFT JOIN Ventas.TipoFlete ON tifl_tipofleteid = tiec_tipofleteid" +
                                " LEFT JOIN Ventas.TipoEmpaque ON tiem_tipoempaqueid = tiec_tipoempaqueid" +
                                " LEFT JOIN Cliente.Ramos ON ramo_ramoid = tiec_ramoid"


        If areaOperativa = 10 Then
            consulta += " WHERE clie_personaidcliente = " + personaID.ToString + "  ORDER BY  tiec_activo desc, ramo_nombre, pers_nombre, domi_domicilio, tifl_nombre "
        ElseIf areaOperativa = 9 Then
            consulta += " WHERE rtec_clienterfc_id = " + personaID.ToString + " ORDER BY  tiec_activo desc, ramo_nombre, pers_nombre, domi_domicilio, tifl_nombre "
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_ClienteRFCCEDIS_Mensajeria(cedisID As Integer, ciudadID As Integer, poblacionID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT * FROM (SELECT " +
                                " 	  tecm_prioridad  " +
                                " 	, prov_nombregenerico  " +
                                " 	, unid_nombre  " +
                                " 	, codm_costoporunidad  " +
                                " 	, tire_nombre " +
                                "   , tecm_tiendaeEmbCEDISmensajeriaid " +
                                "   , tecm_tiendaembarquecedisid " +
                                "   , codm_costodestinomensajeriaid, tecm_activo " +
                                " FROM Embarque.TiendaEmbCEDISMensajeria " +
                                " INNER JOIN Embarque.CostoDestinoMensajeria ON codm_costodestinomensajeriaid = tecm_costodestinomensajeriaid " +
                                " INNER JOIN Framework.Unidad ON unid_unidadid = codm_unidadid " +
                                " INNER JOIN Embarque.TipoReEmbarque ON tire_tiporeEmbarqueid = codm_tiporeEmbarqueid " +
                                " INNER JOIN Embarque.DestinoMensajeria ON deme_destinomensajeriaid = codm_destinomensajeriaid " +
                                " INNER JOIN Proveedor.Proveedor ON prov_proveedorid = deme_proveedorid " +
                                " WHERE tecm_activo = 1 and codm_activo=1 AND tecm_tiendaEmbarquecedisid = " + cedisID.ToString +
                                " UNION " +
                                " SELECT " +
                                " 	NULL  " +
                                " 	, prov_nombregenerico  " +
                                " 	, unid_nombre " +
                                " 	, codm_costoporunidad  " +
                                " 	, tire_nombre " +
                                "   , NULL " +
                                "   , NULL " +
                                "   , codm_costodestinomensajeriaid , codm_activo " +
                                " FROM Embarque.CostoDestinoMensajeria  " +
                                " INNER JOIN Framework.Unidad ON unid_unidadid = codm_unidadid " +
                                " INNER JOIN Embarque.TipoReEmbarque ON tire_tiporeEmbarqueid = codm_tiporeEmbarqueid " +
                                " INNER JOIN Embarque.DestinoMensajeria ON deme_destinomensajeriaid = codm_destinomensajeriaid " +
                                " INNER JOIN Proveedor.Proveedor ON prov_proveedorid = deme_proveedorid " +
                                " WHERE codm_activo = 1 "

        If poblacionID > 0 Then
            consulta += "AND deme_poblacionid = " + poblacionID.ToString
        Else
            consulta += "AND deme_ciudadid = " + ciudadID.ToString
        End If

        consulta += " " +
                                " AND codm_costodestinomensajeriaid NOT IN  " +
                                " 	( " +
                                " 		SELECT " +
                                " 			tecm_costodestinomensajeriaid " +
                                " 		FROM Embarque.TiendaEmbCEDISMensajeria " +
                                " 		WHERE tecm_tiendaEmbarquecedisid = " + cedisID.ToString +
                                " 	)) AS CONS ORDER BY CONS.tecm_activo DESC,CONS.tecm_prioridad,CONS.prov_nombregenerico, CONS.unid_nombre "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_ClienteRFCTelefonos(personaID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tele_telefonoid" +
                                " , LTRIM(RTRIM(UPPER(tele_telefono))) AS tele_telefono" +
                                " , LTRIM(RTRIM(UPPER(tele_extension))) AS tele_extension" +
                                " , tite_tipotelefonoid" +
                                " , LTRIM(RTRIM(UPPER(tite_nombre))) AS tite_nombre" +
                                " , pers_personaid, tele_activo" +
                                " FROM Framework.Telefono" +
                                " JOIN Framework.TipoTelefono ON tite_tipotelefonoid = tele_tipotelefonoid" +
                                " JOIN Framework.Persona ON pers_personaid = tele_personaid" +
                                " WHERE pers_personaid = " + personaID.ToString + " ORDER BY tele_activo desc,tele_telefono,tele_extension,TITE_NOMBRE "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_ClienteRFCEmails(personaID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT " +
                                "   empe_emailpersonasid" +
                                " , LTRIM(RTRIM(LOWER(empe_email))) AS empe_email, empe_activo" +
                                " FROM Framework.EmailPersonas" +
                                " JOIN Framework.Persona ON pers_personaid = empe_personaid" +
                                " WHERE  pers_personaid = " + personaID.ToString + " ORDER BY empe_activo desc, empe_email"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaTelefono(persona As Entidades.Persona, _
                           clasificacionpersona As Entidades.ClasificacionPersona, _
                           telefono As Entidades.Telefono, _
                           tipoTelefono As Entidades.TipoTelefono)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@clasificacionpersonaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        ',@telefono AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = telefono.telefono
        listaParametros.Add(parametro)

        ',@extension AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "extension"
        parametro.Value = telefono.extension
        listaParametros.Add(parametro)

        ',@tipotelefonoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipotelefonoid"
        parametro.Value = tipoTelefono.tipotelefonoid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Telefono", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarTelefono(persona As Entidades.Persona, _
                           clasificacionpersona As Entidades.ClasificacionPersona, _
                           telefono As Entidades.Telefono, _
                           tipoTelefono As Entidades.TipoTelefono)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@clasificacionpersonaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        ',@telefonoid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "telefonoid"
        parametro.Value = telefono.telefonoid
        listaParametros.Add(parametro)

        ',@telefono AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = telefono.telefono
        listaParametros.Add(parametro)

        ',@extension AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "extension"
        parametro.Value = telefono.extension
        listaParametros.Add(parametro)

        ',@tipotelefonoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipotelefonoid"
        parametro.Value = tipoTelefono.tipotelefonoid
        listaParametros.Add(parametro)

        ',@activo AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = telefono.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Telefono", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaEmail(persona As Entidades.Persona, _
                       clasificacionpersona As Entidades.ClasificacionPersona, _
                       email As Entidades.Email)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@clasificacionpersonaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        ',@email AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "email"
        parametro.Value = email.email
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Alta_Email", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarEmail(persona As Entidades.Persona, _
                           clasificacionpersona As Entidades.ClasificacionPersona, _
                           email As Entidades.Email)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@clasificacionpersonaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = clasificacionpersona.clasificacionpersonaid
        listaParametros.Add(parametro)

        ',@personaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "personaid"
        parametro.Value = persona.personaid
        listaParametros.Add(parametro)

        ',@emailid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "emailid"
        parametro.Value = email.emailpersonasid
        listaParametros.Add(parametro)

        ',@email AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "email"
        parametro.Value = email.email
        listaParametros.Add(parametro)


        ',@activo AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = email.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Email", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaContrarecibos(clienteID As Integer, AreaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tiho_tipohorarioid" +
                                " , LTRIM(RTRIM(UPPER(tiho_nombre))) AS tiho_nombre" +
                                " , dias_diaid" +
                                " , LTRIM(RTRIM(UPPER(dias_nombre))) AS dias_nombre" +
                                " , hocl_diascontrareciboid" +
                                " , LTRIM(RTRIM(UPPER(hocl_horario))) AS hocl_horario" +
                                " ,hocl_clienteid, hocl_activo " +
                                " FROM Ventas.HorariosCliente" +
                                " JOIN Framework.Dias ON hocl_diasid = dias_diaid" +
                                " JOIN Ventas.TipoHorario ON hocl_tipohorario =  tiho_tipohorarioid" +
                                " WHERE hocl_clienteid = " + clienteID.ToString +
                                "  "

        If AreaOperativa = 3 Then
            consulta += " AND tiho_tipohorarioid IN (1, 2) order by hocl_activo desc, tiho_nombre, dias_nombre, hocl_horario"
        ElseIf AreaOperativa = 1 Then
            consulta += " AND tiho_tipohorarioid = 3 order by hocl_activo desc, tiho_nombre, dias_nombre, hocl_horario"
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaTipoHorario(AreaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tiho_tipohorarioid" +
                                " , LTRIM(RTRIM(UPPER(tiho_nombre))) AS tiho_nombre" +
                                " FROM Ventas.TipoHorario "
        If AreaOperativa = 3 Then
            consulta += " WHERE tiho_tipohorarioid IN (1, 2)"
        ElseIf AreaOperativa = 1 Then
            consulta += " WHERE tiho_tipohorarioid = 3"
        End If
        consulta += " ORDER BY tiho_nombre"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaHorarioContrarecibo(horario As Entidades.HorarioContrarecibo)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@horario AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "horario"
        parametro.Value = horario.horario
        listaParametros.Add(parametro)

        ',@diasid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "diasid"
        parametro.Value = horario.dias.diaid
        listaParametros.Add(parametro)

        ',@tipohorario AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "tipohorario"
        parametro.Value = horario.tipohorario.tipohorarioid
        listaParametros.Add(parametro)

        ',@clienteid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = horario.cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_HorarioCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarHorarioContrarecibo(horario As Entidades.HorarioContrarecibo)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@@diascontrareciboid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "diascontrareciboid"
        parametro.Value = horario.diascontrareciboid
        listaParametros.Add(parametro)

        ',@horario AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "horario"
        parametro.Value = horario.horario
        listaParametros.Add(parametro)

        ',@diasid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "diasid"
        parametro.Value = horario.dias.diaid
        listaParametros.Add(parametro)

        ',@tipohorario AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "tipohorario"
        parametro.Value = horario.tipohorario.tipohorarioid
        listaParametros.Add(parametro)

        ',@clienteid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = horario.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = horario.activo
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_HorarioCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaDescuentosCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   decl_descuentosclienteid" +
                                " , mode_motivodescuentoid" +
                                " , LTRIM(RTRIM(UPPER(mode_nombre))) AS mode_nombre" +
                                " , lude_lugardescuentoid" +
                                " , LTRIM(RTRIM(UPPER(lude_nombre))) AS lude_nombre" +
                                " , decl_descuentoenporcentaje" +
                                " , decl_cantidaddescuento" +
                                " , decl_diasplazo" +
                                " , decl_aplicaencadenado" +
                                " , decl_clienteid, decl_activo as 'ACTIVO'" +
                                " FROM Cobranza.DescuentosCliente" +
                                " JOIN Cobranza.MotivoDescuento ON decl_motivodescuentoid = mode_motivodescuentoid" +
                                " JOIN Cobranza.LugarDescuento ON decl_lugardescuentoid = lude_lugardescuentoid" +
                                " WHERE decl_clienteid = " + clienteID.ToString +
                                " AND decl_activo = 1"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaMotivoDescuento() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   mode_motivodescuentoid" +
                                " , LTRIM(RTRIM(UPPER(mode_nombre))) AS mode_nombre" +
                                " FROM Cobranza.MotivoDescuento" +
                                " ORDER BY mode_nombre "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaLugarDescuento() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                " lude_lugardescuentoid" +
                                " , LTRIM(RTRIM(UPPER(lude_nombre))) AS lude_nombre" +
                                " FROM Cobranza.LugarDescuento" +
                                " ORDER BY lude_nombre "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaDescuentosCliente(descuento As Entidades.DescuentoCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@motivodescuentoid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "motivodescuentoid"
        parametro.Value = descuento.motivodescuento.motivodescuentoid
        listaParametros.Add(parametro)

        ',@lugardescuentoid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "lugardescuentoid"
        parametro.Value = descuento.lugardescuento.lugardescuentoid
        listaParametros.Add(parametro)

        ',@diasplazo AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "diasplazo"
        parametro.Value = descuento.diasplazo
        listaParametros.Add(parametro)

        ',@descuentoenporcentaje AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "descuentoenporcentaje"
        parametro.Value = descuento.descuentoenporcentaje
        listaParametros.Add(parametro)

        ',@cantidaddescuento AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "cantidaddescuento"
        parametro.Value = descuento.cantidaddescuento
        listaParametros.Add(parametro)

        ',@aplicaencadenado AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "aplicaencadenado"
        parametro.Value = descuento.aplicaencadenado
        listaParametros.Add(parametro)

        ',@clienteid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = descuento.cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cobranza.SP_Alta_Descuentos_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarDescuentosCliente(descuento As Entidades.DescuentoCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@descuentosclienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "descuentosclienteid"
        parametro.Value = descuento.descuentosclienteid
        listaParametros.Add(parametro)

        ',@motivodescuentoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "motivodescuentoid"
        parametro.Value = descuento.motivodescuento.motivodescuentoid
        listaParametros.Add(parametro)

        ',@lugardescuentoid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "lugardescuentoid"
        parametro.Value = descuento.lugardescuento.lugardescuentoid
        listaParametros.Add(parametro)

        ',@diasplazo AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "diasplazo"
        parametro.Value = descuento.diasplazo
        listaParametros.Add(parametro)

        ',@descuentoenporcentaje AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "descuentoenporcentaje"
        parametro.Value = descuento.descuentoenporcentaje
        listaParametros.Add(parametro)

        ',@cantidaddescuento AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "cantidaddescuento"
        parametro.Value = descuento.cantidaddescuento
        listaParametros.Add(parametro)

        ',@aplicaencadenado AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "aplicaencadenado"
        parametro.Value = descuento.aplicaencadenado
        listaParametros.Add(parametro)

        ',@clienteid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = descuento.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = descuento.activo
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cobranza.SP_Edita_Descuentos_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaRamoCliente(clienteID As Integer, areaOperativa As Integer, ByVal Modo_Edicion As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        If Modo_Edicion Then
            consulta = " SELECT " +
                            "   clie_clienteid " +
                            " , racl_ramoid" +
                            " , ramo_nombre" +
                            " , COUNT(tiec_tiendaembarquecedisid) AS tiec_numtiendas" +
                            " , racl_numtiendasreal" +
                            " , racl_marcaje" +
                            " FROM Cliente.Cliente" +
                            " LEFT JOIN Cliente.ClienteRamos ON racl_clienteid = clie_clienteid" +
                            " LEFT JOIN Cliente.ClienteRFC ON crfc_clienteid = racl_clienteid" +
                            " LEFT JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienterfcid = crfc_clienterfcid AND tiec_ramoid = racl_ramoid" +
                            " LEFT JOIN Cliente.Ramos ON ramo_ramoid = racl_ramoid" +
                            " WHERE clie_clienteid = " + clienteID.ToString +
                            " GROUP BY clie_clienteid, racl_ramoid, ramo_nombre, racl_numtiendasreal, racl_marcaje ORDER BY ramo_nombre"
        Else
            consulta = " select * from (SELECT " +
                        "   clie_clienteid " +
                        " , racl_ramoid" +
                        " , ramo_nombre" +
                        " , COUNT(tiec_tiendaembarquecedisid) AS tiec_numtiendas" +
                        " , racl_numtiendasreal" +
                        " , isnull(cast(racl_marcaje as decimal(18,2)),0) as racl_marcaje " +
                        " FROM Cliente.Cliente" +
                        " LEFT JOIN Cliente.ClienteRamos ON racl_clienteid = clie_clienteid" +
                        " LEFT JOIN Cliente.ClienteRFC ON crfc_clienteid = racl_clienteid" +
                        " LEFT JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienterfcid = crfc_clienterfcid AND tiec_ramoid = racl_ramoid" +
                        " LEFT JOIN Cliente.Ramos ON ramo_ramoid = racl_ramoid" +
                        " WHERE clie_clienteid = " + clienteID.ToString +
                        " GROUP BY clie_clienteid, racl_ramoid, ramo_nombre, racl_numtiendasreal, racl_marcaje) as consulta " +
                        " where  tiec_numtiendas>0 or racl_numtiendasreal>0  ORDER BY ramo_nombre"

        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub EditarRamoCliente(ramo As Entidades.ClienteRamo)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@numtiendasreal AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "numtiendasreal"
        parametro.Value = ramo.numtiendasreal
        listaParametros.Add(parametro)

        ',@marcaje AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "marcaje"
        parametro.Value = ramo.marcaje
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = ramo.cliente.clienteid
        listaParametros.Add(parametro)

        ',@ramoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ramoid"
        parametro.Value = ramo.ramo.ramoid
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_ClienteRamos", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Function Datos_TablaTiendaCliente(clienteID As Integer, areaOperativa As Integer, ByVal Modo_Edicion As Boolean) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        If Modo_Edicion Then
            consulta = "  SELECT " +
                        "   clie_clienteid" +
                        " , cltt_tipotiendaid" +
                        " , titi_nombre" +
                        " , COUNT(tiec_tiendaembarquecedisid) AS tiec_numtiendas" +
                        " , cltt_numtiendasreal" +
                        " , cltt_marcaje" +
                        " FROM Cliente.Cliente" +
                        " LEFT JOIN Cliente.ClienteTipoTienda ON cltt_clienteid = clie_clienteid" +
                        " LEFT JOIN Cliente.ClienteRFC ON crfc_clienteid = cltt_clienteid" +
                        " LEFT JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienterfcid = crfc_clienterfcid AND tiec_tipotiendaid = cltt_tipotiendaid" +
                        " LEFT JOIN Cliente.TipoTienda ON titi_tipotiendaid = cltt_tipotiendaid" +
                        " WHERE clie_clienteid = " + clienteID.ToString +
                        " GROUP BY clie_clienteid, cltt_tipotiendaid, titi_nombre, cltt_numtiendasreal, cltt_marcaje " +
                        " ORDER BY titi_nombre"
        Else
            consulta = " select * from ( SELECT " +
                        "   clie_clienteid" +
                        " , cltt_tipotiendaid" +
                        " , titi_nombre" +
                        " , COUNT(tiec_tiendaembarquecedisid) AS tiec_numtiendas" +
                        " , cltt_numtiendasreal" +
                        " , cltt_marcaje" +
                        " FROM Cliente.Cliente" +
                        " LEFT JOIN Cliente.ClienteTipoTienda ON cltt_clienteid = clie_clienteid" +
                        " LEFT JOIN Cliente.ClienteRFC ON crfc_clienteid = cltt_clienteid" +
                        " LEFT JOIN Cliente.TiendaEmbarqueCEDIS ON tiec_clienterfcid = crfc_clienterfcid AND tiec_tipotiendaid = cltt_tipotiendaid" +
                        " LEFT JOIN Cliente.TipoTienda ON titi_tipotiendaid = cltt_tipotiendaid" +
                        " WHERE clie_clienteid = " + clienteID.ToString +
                        " GROUP BY clie_clienteid, cltt_tipotiendaid, titi_nombre, cltt_numtiendasreal, cltt_marcaje) as Consulta" +
                        " where consulta.cltt_marcaje>0 or consulta.cltt_numtiendasreal>0 " +
                        " ORDER BY titi_nombre"
        End If

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub EditarTiendaCliente(tienda As Entidades.ClienteTienda)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@numtiendas AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "numtiendas"
        parametro.Value = tienda.numtiendasreal
        listaParametros.Add(parametro)

        ',@marcaje AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "marcaje"
        parametro.Value = tienda.marcaje
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = tienda.cliente.clienteid
        listaParametros.Add(parametro)

        ',@tipotiendaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipotiendaid"
        parametro.Value = tienda.tipotienda.tipotiendaid
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_ClienteTiendas", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Function Datos_TablaZapateriaCliente(clienteID As Integer, areaOperativa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   clie_clienteid " +
                                " , zacc_zapateriascompetenciaclienteid" +
                                " , zaco_zapateriasid" +
                                " , LTRIM(RTRIM(UPPER(zaco_nombre))) AS zaco_nombre" +
                                " , zaco_clienteyuyin, zacc_activo " +
                                " FROM Ventas.ZapateriasCompetenciaCliente" +
                                " JOIN Cliente.Cliente ON zacc_clienteid = clie_clienteid" +
                                " JOIN Ventas.ZapateriasCompetencia ON zaco_zapateriasid = zacc_zapateriasid" +
                                " WHERE clie_clienteid = " + clienteID.ToString +
                                " order by zacc_activo desc, zaco_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Datos_TablaZapateriaCompetencia() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   zaco_zapateriasid" +
                                " , LTRIM(RTRIM(UPPER(zaco_nombre))) AS zaco_nombre" +
                                " FROM Ventas.ZapateriasCompetencia WHERE zaco_activo = 1 " +
                                " ORDER BY zaco_nombre"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function Datos_Catalogo_ZapateriasCompetencia() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT zaco_zapateriasid, " +
        "    LTRIM(RTRIM(UPPER(zaco_nombre))) AS '*ZAPATERÍA', " +
        "    zaco_clienteyuyin AS '*CLIENTE YUYIN', " +
        "    zaco_activo AS '*ACTIVO' " +
        " FROM Ventas.ZapateriasCompetencia" +
        " ORDER BY zaco_activo DESC, zaco_nombre ASC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub AltaZapateriaCliente(zapateria As Entidades.ZapateriaCompetenciaCliente)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@clienteid AS INTEGER
        Dim parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = zapateria.cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        ', @IdZapateriaCompetencia as integer
        parametro = New SqlParameter
        parametro.ParameterName = "IdZapateriaCompetencia"
        parametro.Value = zapateria.zapateria.zapateriasid
        listaParametros.Add(parametro)

        ', @zacc_activo as bit
        parametro = New SqlParameter
        parametro.ParameterName = "zacc_activo"
        parametro.Value = zapateria.activo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_ZapateriasCompetencia_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub AltaZapateria(zapateria As Entidades.ZapateriaCompetencia)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @nombre AS VARCHAR(100)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = zapateria.nombre
        listaParametros.Add(parametro)

        ',@clienteyuyin AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "clienteyuyin"
        parametro.Value = zapateria.clienteyuyin
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        ', @zacc_activo as bit
        parametro = New SqlParameter
        parametro.ParameterName = "zacc_activo"
        parametro.Value = zapateria.activo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_ZapateriasCompetencia", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Sub EditarZapateriaCliente(zapateria As Entidades.ZapateriaCompetenciaCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@zapateriasCompetenciaClienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@zapateriasCompetenciaClienteid"
        parametro.Value = zapateria.zapateriascompetenciaclienteid
        listaParametros.Add(parametro)

        ',@zapateriasid AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "@zapateriasid"
        parametro.Value = zapateria.zapateria.zapateriasid
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = zapateria.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = zapateria.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_ZapateriasCompetencia_Cliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarZapateria(zapateria As Entidades.ZapateriaCompetencia)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@zapateriasid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "zapateriasid"
        parametro.Value = zapateria.zapateriasid
        listaParametros.Add(parametro)

        ',@nombre AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = zapateria.nombre
        listaParametros.Add(parametro)

        ',@clienteyuyin AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "clienteyuyin"
        parametro.Value = zapateria.clienteyuyin
        listaParametros.Add(parametro)


        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = zapateria.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_ZapateriasCompetencia", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub



    Public Function Datos_TablaMaterialMKTCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   mmcl_clienteid" +
                                " , mmcl_materialmercadotecniaclienteid" +
                                " , LTRIM(RTRIM(UPPER(tmme_nombre))) AS tmme_nombre" +
                                " , LTRIM(RTRIM(UPPER(mame_nombre))) AS mame_nombre" +
                                " , mmcl_activo" +
                                " FROM Ventas.MaterialMercadotecniaCliente" +
                                " JOIN Ventas.MaterialMercadotecnia ON mame_materialmercadotecniaid = mmcl_materialmercadotecniaid" +
                                " JOIN Ventas.TipoMaterialMercadotecnia ON tmme_tipomaterialmercadotecniaid = mame_tipomaterialmercadotecniaid" +
                                " WHERE mmcl_clienteid = " + clienteID.ToString +
                                " ORDER BY mmcl_activo desc,tmme_nombre,mame_nombre "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaTipoMaterialMKT() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tmme_tipomaterialmercadotecniaid" +
                                " , LTRIM(RTRIM(UPPER(tmme_nombre))) AS tmme_nombre" +
                                " FROM Ventas.TipoMaterialMercadotecnia" +
                                " ORDER BY tmme_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaMaterialMKT(tipoMaterial As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   mame_materialmercadotecniaid" +
                                " , LTRIM(RTRIM(UPPER(mame_nombre))) AS mame_nombre" +
                                " FROM Ventas.MaterialMercadotecnia"
        If tipoMaterial > 0 Then
            consulta += " WHERE mame_tipomaterialmercadotecniaid = " + tipoMaterial.ToString
        End If

        consulta += " ORDER BY mame_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaMaterialMKTCliente(materialMKT As Entidades.MaterialMKTCliente)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @materialmercadotecniaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "materialmercadotecniaid"
        parametro.Value = materialMKT.materialmercadotecnia.materialmercadotecniaid
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = materialMKT.cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_MaterialMKT", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarMaterialMKTCliente(materialMKT As Entidades.MaterialMKTCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @materialmercadotecniaclienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "materialmercadotecniaclienteid"
        parametro.Value = materialMKT.materialmercadotecniaclienteid
        listaParametros.Add(parametro)

        ',@materialmercadotecniaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "materialmercadotecniaid"
        parametro.Value = materialMKT.materialmercadotecnia.materialmercadotecniaid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = materialMKT.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_MaterialMKT", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaVentasInfoCliente(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Ventas.InfoCliente WHERE ivcl_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_Vinculacion_TEC_RFC(rfcID As Integer, clienteID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "" +
        '                        " WITH T AS (" +
        '                        " 	SELECT" +
        '                        " 	 tiec_tiendaembarquecedisid" +
        '                        " 	,tiec_personaid" +
        '                        " 	, A.pers_nombre" +
        '                        " 	,clie_clienteid" +
        '                        " 	,clie_nombregenerico" +
        '                        " 	,tiec_clasificacionpersonaid" +
        '                        " 	,clpe_nombre" +
        '                        " 	,rtec_rfc_tiendaembarquecedis_id" +
        '                        " 	,rtec_clienterfc_id" +
        '                        " 	,ROW_NUMBER() OVER (ORDER BY A.pers_personaid) AS eFila" +
        '                        " 	FROM Cliente.TiendaEmbarqueCEDIS" +
        '                        " 	LEFT JOIN Framework.Persona AS A ON A.pers_personaid = tiec_personaid" +
        '                        " 	LEFT JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tiec_clasificacionpersonaid" +
        '                        " 	LEFT JOIN Cliente.RFC_TiendaEmbarqueCEDIS ON tiec_tiendaembarquecedisid = rtec_tiendaembarquecedisid" +
        '                        " 	LEFT JOIN Cliente.Cliente ON clie_clienteid = tiec_clienteid " +
        '                        " 	LEFT JOIN Framework.Persona AS B ON B.pers_personaid = clie_personaidcliente" +
        '                        " 	WHERE tiec_clienteid = " + clienteID.ToString +
        '                        " 	AND rtec_clienterfc_id = " + rfcID.ToString +
        '                        " 	AND rtec_activo	= 1 OR rtec_activo IS NULL" +
        '                        " )," +
        '                        " F" +
        '                        " AS (" +
        '                        " 	SELECT " +
        '                        " 	 tiec_tiendaembarquecedisid	" +
        '                        " 	,tiec_personaid	" +
        '                        " 	,A.pers_nombre " +
        '                        " 	,clie_clienteid " +
        '                        " 	,clie_nombregenerico " +
        '                        " 	,tiec_clasificacionpersonaid" +
        '                        " 	,clpe_nombre " +
        '                        " 	,rtec_rfc_tiendaembarquecedis_id " +
        '                        " 	,rtec_clienterfc_id" +
        '                        " 	,ROW_NUMBER() OVER (ORDER BY A.pers_personaid) AS FFila" +
        '                        " 	FROM Cliente.TiendaEmbarqueCEDIS " +
        '                        " 	LEFT JOIN Framework.Persona AS A ON A.pers_personaid = tiec_personaid" +
        '                        " 	LEFT JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tiec_clasificacionpersonaid" +
        '                        " 	LEFT JOIN Cliente.RFC_TiendaEmbarqueCEDIS ON tiec_tiendaembarquecedisid = rtec_tiendaembarquecedisid" +
        '                        " 	LEFT JOIN Cliente.Cliente ON clie_clienteid = tiec_clienteid " +
        '                        " 	LEFT JOIN Framework.Persona AS B ON B.pers_personaid = clie_personaidcliente" +
        '                        " 	WHERE tiec_clienteid = " + clienteID.ToString +
        '                        " 	AND rtec_clienterfc_id <> " + rfcID.ToString +
        '                        " 	AND rtec_activo	= 1 OR rtec_activo IS NULL" +
        '                        " )" +
        '                        " SELECT" +
        '                        " 	COALESCE(T.tiec_tiendaembarquecedisid, F.tiec_tiendaembarquecedisid) AS tiec_tiendaembarquecedisid," +
        '                        " 	COALESCE(T.tiec_personaid, F.tiec_personaid) AS tiec_personaid," +
        '                        " 	COALESCE(T.pers_nombre, F.pers_nombre) AS 'TEC NOMBRE'," +
        '                        " 	COALESCE(T.clie_clienteid, F.clie_clienteid) AS clie_clienteid," +
        '                        " 	COALESCE(T.clie_nombregenerico, F.clie_nombregenerico) AS 'CLIENTE NOMBRE'," +
        '                        " 	COALESCE(T.tiec_clasificacionpersonaid, F.tiec_clasificacionpersonaid) AS tiec_clasificacionpersonaid," +
        '                        " 	COALESCE(T.clpe_nombre, F.clpe_nombre) AS 'TIPO TEC NOMBRE'," +
        '                        " 	COALESCE(T.rtec_rfc_tiendaembarquecedis_id, F.rtec_rfc_tiendaembarquecedis_id) AS rtec_rfc_tiendaembarquecedis_id," +
        '                        " 	COALESCE(T.rtec_clienterfc_id, F.rtec_clienterfc_id) AS rtec_clienterfc_id," +
        '                        " 	(" +
        '                        " 		CASE WHEN T.rtec_clienterfc_id IS NULL OR T.rtec_clienterfc_id <> " + rfcID.ToString + " THEN CAST(0 AS BIT)" +
        '                        " 		ELSE CAST(1 AS BIT) END" +
        '                        " 	) AS 'VINCULADO'" +
        '                        " FROM T" +
        '                        " FULL OUTER JOIN F ON T.tiec_tiendaembarquecedisid = F.tiec_tiendaembarquecedisid AND eFila = FFila"

        Dim consulta As String = "   WITH T AS ( SELECT tiec_tiendaembarquecedisid,  tiec_personaid, A.pers_IdSICY, A.pers_nombre, clie_clienteid, clie_nombregenerico, " +
                                 "                   tiec_clasificacionpersonaid, clpe_nombre, rtec_rfc_tiendaembarquecedis_id, rtec_clienterfc_id, rtec_activo, A.pers_activo," +
                                 "                   ROW_NUMBER() OVER (ORDER BY A.pers_personaid) AS eFila" +
                                 "               FROM Cliente.TiendaEmbarqueCEDIS" +
                                 "               LEFT JOIN Framework.Persona AS A ON A.pers_personaid = tiec_personaid" +
                                 "               LEFT JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tiec_clasificacionpersonaid" +
                                 "               LEFT JOIN Cliente.RFC_TiendaEmbarqueCEDIS ON tiec_tiendaembarquecedisid = rtec_tiendaembarquecedisid" +
                                 "               LEFT JOIN Cliente.Cliente ON clie_clienteid = tiec_clienteid" +
                                 "               LEFT JOIN Framework.Persona AS B ON B.pers_personaid = clie_personaidcliente" +
                                 "               WHERE tiec_clienteid = " + clienteID.ToString +
                                 "               AND rtec_clienterfc_id = " + rfcID.ToString +
                                 "               AND rtec_activo IS NOT NULL)," +
                                 "   F AS (		SELECT tiec_tiendaembarquecedisid,  tiec_personaid, A.pers_IdSICY, a.pers_nombre, clie_clienteid, clie_nombregenerico, " +
                                 "                   tiec_clasificacionpersonaid, clpe_nombre, NULL AS rtec_rfc_tiendaembarquecedis_id, NULL AS rtec_clienterfc_id, " +
                                 "                   NULL AS rtec_activo , A.pers_activo, ROW_NUMBER() OVER (ORDER BY A.pers_personaid) AS FFila" +
                                 "               FROM Cliente.TiendaEmbarqueCEDIS" +
                                 "               INNER JOIN Framework.Persona AS A ON A.pers_personaid = tiec_personaid" +
                                 "               INNER JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tiec_clasificacionpersonaid" +
                                 "               INNER JOIN Cliente.Cliente ON clie_clienteid = tiec_clienteid" +
                                 "               INNER JOIN Framework.Persona AS B ON B.pers_personaid = clie_personaidcliente" +
                                 "               WHERE tiec_clienteid = " + clienteID.ToString + " and tiec_tiendaembarquecedisid not in " +
                                 "                      (SELECT tiec_tiendaembarquecedisid FROM Cliente.TiendaEmbarqueCEDIS" +
                                 "                      LEFT JOIN Framework.Persona AS A ON A.pers_personaid = tiec_personaid" +
                                 "                      LEFT JOIN Framework.ClasificacionPersona ON clpe_clasificacionpersonaid = tiec_clasificacionpersonaid" +
                                 "                      LEFT JOIN Cliente.RFC_TiendaEmbarqueCEDIS ON tiec_tiendaembarquecedisid = rtec_tiendaembarquecedisid" +
                                 "                      LEFT JOIN Cliente.Cliente ON clie_clienteid = tiec_clienteid" +
                                 "                      LEFT JOIN Framework.Persona AS B ON B.pers_personaid = clie_personaidcliente" +
                                 "                      WHERE tiec_clienteid =  " + clienteID.ToString +
                                 "                      AND rtec_clienterfc_id = " + rfcID.ToString +
                                 "                      AND rtec_activo IS NOT NULL)) " +
                                 "   SELECT" +
                                 "       COALESCE(T.tiec_tiendaembarquecedisid, F.tiec_tiendaembarquecedisid) AS tiec_tiendaembarquecedisid," +
                                 "       COALESCE(T.tiec_personaid, F.tiec_personaid) AS 'SAY ID'," +
                                 "	     COALESCE(T.pers_IdSICY, F.pers_IdSICY) AS 'SICY ID'," +
                                 "       COALESCE(T.pers_nombre, F.pers_nombre) AS 'TEC NOMBRE'," +
                                 "       COALESCE(T.clie_clienteid, F.clie_clienteid) AS clie_clienteid," +
                                 "       COALESCE(T.clie_nombregenerico, F.clie_nombregenerico) AS 'CLIENTE NOMBRE'," +
                                 "       COALESCE(T.tiec_clasificacionpersonaid, F.tiec_clasificacionpersonaid) AS tiec_clasificacionpersonaid," +
                                 "       COALESCE(T.clpe_nombre, F.clpe_nombre) AS 'TIPO TEC NOMBRE'," +
                                 "       COALESCE(T.pers_activo, F.pers_activo) AS 'ACTIVO'," +
                                 "       COALESCE(T.rtec_rfc_tiendaembarquecedis_id, F.rtec_rfc_tiendaembarquecedis_id) AS rtec_rfc_tiendaembarquecedis_id," +
                                 "       COALESCE(T.rtec_clienterfc_id, F.rtec_clienterfc_id) AS rtec_clienterfc_id," +
                                 "       (CASE" +
                                 "           WHEN T.rtec_clienterfc_id IS NULL OR" +
                                 "               T.rtec_clienterfc_id <> " + rfcID.ToString + " OR" +
                                 "               (T.rtec_ACTIVO IS NULL OR" +
                                 "               T.rtec_ACTIVO = 0) THEN CAST(0 AS bit)" +
                                 "           ELSE CAST(1 AS bit)" +
                                 "       END) AS 'VINCULADO'" +
                                 "   FROM T" +
                                 "   FULL OUTER JOIN F" +
                                 "       ON T.tiec_tiendaembarquecedisid = F.tiec_tiendaembarquecedisid" +
                                 "       AND eFila = FFila" +
                                 "   ORDER BY VINCULADO DESC, [TEC NOMBRE]"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub Vinculacion_RFC_TEC(bandera As Integer, rfcid As Integer, _
                                   tecid As Integer, vinculacionid As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@rfcid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "rfcid"
        parametro.Value = rfcid
        listaParametros.Add(parametro)

        ',@tecid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tecid"
        parametro.Value = tecid
        listaParametros.Add(parametro)

        ',@vinculacionid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "vinculacionid"
        parametro.Value = vinculacionid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Vinculacion_RFC_TEC", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarPrioridadMensajerias(bandera As Integer, prioridad As Integer, tiendaembarquecedisid As Integer, costodestinomensajeriaid As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @bandera AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        ',@prioridad AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "prioridad"
        parametro.Value = prioridad
        listaParametros.Add(parametro)

        ',@tiendaembarquecedisid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tiendaembarquecedisid"
        parametro.Value = tiendaembarquecedisid
        listaParametros.Add(parametro)

        ',@costodestinomensajeriaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "costodestinomensajeriaid"
        parametro.Value = costodestinomensajeriaid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Embarque.SP_Editar_Prioridad_Mensajerias", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Desasignar_Prioridad_CedisMensajeria(ByVal tiendaembarquecedisid As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = " " +
        " DELETE FROM Embarque.TiendaEmbCEDISMensajeria" +
        " WHERE tecm_tiendaembarquecedisid = " + tiendaembarquecedisid.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function


    Public Function Datos_TablaVendedoresCliente(clienteID As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = "" +
        '                        " SELECT" +
        '                        "   cmae_clientemarcaagenteempresaid AS 'ID'" +
        '                        " , LTRIM(RTRIM(UPPER(marc_descripcion)))'MARCA'" +
        '                        " , UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR(250))) AS 'AGENTE DE VENTAS'" +
        '                        " , LTRIM(RTRIM(UPPER(empr_nombre))) AS 'EMPRESA'," +
        '                        " p.pers_nombre as CONTACTO,e.empe_email as EMAIL, cmae_activo AS 'ACTIVO'" +
        '                        " FROM Cliente.ClienteMarcaAgenteEmpresa" +
        '                        " JOIN Programacion.Marcas ON marc_marcaid = cmae_marcaid" +
        '                        " JOIN Nomina.Colaborador ON codr_colaboradorid = cmae_colaboradorid_agente" +
        '                        " JOIN Framework.Empresas ON empr_empresaid = cmae_empresaid" +
        '                        " left join Framework.EmailPersonas e on e.empe_emailpersonasid= cmae_emailpersonasid" +
        '                        " left join Framework.Persona p on p.pers_personaid=e.empe_personaid and e.empe_clasificacionpersonaid=23" +
        '                        " WHERE cmae_clienteid = " + clienteID.ToString +
        '                        " ORDER BY cmae_activo desc,[MARCA], [AGENTE DE VENTAS]"

        'Return operaciones.EjecutaConsulta(consulta)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @clienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteID"
        parametro.Value = clienteID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_FTC_Datos_TablaVendedoresCliente", listaParametros)

    End Function


    Public Sub Alta_ClienteMarcaAgenteEmpresa(clienteid As Integer, marcaid As Integer, colaboradorid_agente As Integer, empresaid As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ' @clienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        ',@marcaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "marcaid"
        parametro.Value = marcaid
        listaParametros.Add(parametro)

        ',@colaboradorid_agente AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid_agente"
        parametro.Value = colaboradorid_agente
        listaParametros.Add(parametro)

        ',@empresaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "empresaid"
        parametro.Value = empresaid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Alta_ClienteMarcaAgenteEmpresa", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub Editar_ClienteMarcaAgenteEmpresa(clientemarcaagenteempresaid As Integer, clienteid As Integer, marcaid As Integer, colaboradorid_agente As Integer, empresaid As Integer, activo As Boolean)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@clientemarcaagenteempresaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "clientemarcaagenteempresaid"
        parametro.Value = clientemarcaagenteempresaid
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        ',@marcaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "marcaid"
        parametro.Value = marcaid
        listaParametros.Add(parametro)

        ',@colaboradorid_agente AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid_agente"
        parametro.Value = colaboradorid_agente
        listaParametros.Add(parametro)

        ',@empresaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "empresaid"
        parametro.Value = empresaid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = activo
        listaParametros.Add(parametro)

        ',@usuariomodificoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Cliente.SP_Editar_ClienteMarcaAgenteEmpresa", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function ListaRFC_Sicy(clienteID As Integer, rfc_sicyID As Integer, editando As Boolean) As DataTable
        Dim operaciones_SAY As New Persistencia.OperacionesProcedimientos
        Dim operaciones_SICY As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""

        If editando Then

            consulta += " SELECT IdCliente, CASE (Tipo) WHEN 'R' THEN 'REMISIÓN' WHEN 'F' THEN 'FACTURA' End + ' - '+sucursal+' - ' + 	nombre  + CASE (Tipo) WHEN 'R' THEN '' WHEN 'F' THEN  '   ('+ 	rfc + ')  ' END as nombre" +
                " FROM Clientes where IdCadena=" + clienteID.ToString + " AND CAST(IdCliente AS VARCHAR(MAX)) NOT IN ("
            If operaciones_SICY.Servidor = operaciones_SAY.Servidor Then
                consulta += "                                           SELECT pers_IdSICY FROM [" + operaciones_SAY.NombreDB + "].[Framework].[Persona]" +
                                                                        " JOIN [" + operaciones_SAY.NombreDB + "].[Framework].[TiposPersonas] " +
                                                                        " ON tipe_personaid = pers_personaid" +
                                                                        " WHERE pers_IdSICY IS NOT NULL AND tipe_clasificacionpersonaid IN (13,14)"
            Else
                consulta += "                                           SELECT pers_IdSICY FROM [" + operaciones_SAY.Servidor + "].[" + operaciones_SAY.NombreDB + "].[Framework].[Persona]" +
                                                                        " JOIN [" + operaciones_SAY.Servidor + "].[" + operaciones_SAY.NombreDB + "].[Framework].[TiposPersonas] " +
                                                                        " ON tipe_personaid = pers_personaid" +
                                                                        " WHERE pers_IdSICY IS NOT NULL AND tipe_clasificacionpersonaid IN (13,14)"
            End If
            consulta += " ) " +
                        " OR IdCliente = " + rfc_sicyID.ToString + " order by Tipo,nombre,rfc"
        Else
            consulta += " SELECT IdCliente, CASE (Tipo) WHEN 'R' THEN 'REMISIÓN' WHEN 'F' THEN 'FACTURA' End + ' - '+sucursal+' - ' + 	nombre  + CASE (Tipo) WHEN 'R' THEN '' WHEN 'F' THEN  '   ('+ 	rfc + ')  ' END as nombre" +
                " FROM Clientes where IdCadena=" + clienteID.ToString + "  order by Tipo,nombre,rfc"
        End If

        Return operaciones_SICY.EjecutaConsulta(consulta)

    End Function

    Public Function ListaTEC_Sicy(clienteID As Integer, distribucion_sicyID As Integer, editando As Boolean) As DataTable
        Dim operaciones_SAY As New Persistencia.OperacionesProcedimientos
        Dim operaciones_SICY As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""

        If editando Then
            consulta += " SELECT IdDistribucion, ltrim(rtrim(upper(distribucion)))+'-'+ltrim(rtrim(upper(direccion)))+', '+ltrim(rtrim(upper(colonia))) as distribucion FROM vCadenasDistribucion WHERE IdCadena = " + clienteID.ToString +
                        " AND CAST(IdDistribucion AS VARCHAR(MAX)) NOT IN ("
            If operaciones_SAY.Servidor = operaciones_SICY.Servidor Then
                consulta += "                               SELECT pers_IdSICY FROM [" + operaciones_SAY.NombreDB + "].[Framework].[Persona]" +
                                                            " JOIN [" + operaciones_SAY.NombreDB + "].[Framework].[TiposPersonas] " +
                                                            " ON tipe_personaid = pers_personaid" +
                                                            " WHERE pers_IdSICY IS NOT NULL AND tipe_clasificacionpersonaid IN (15, 16, 17)"
            Else
                consulta += "                                                SELECT pers_IdSICY FROM [" + operaciones_SAY.Servidor + "].[" + operaciones_SAY.NombreDB + "].[Framework].[Persona]" +
                                                            " JOIN [" + operaciones_SAY.Servidor + "].[" + operaciones_SAY.NombreDB + "].[Framework].[TiposPersonas] " +
                                                            " ON tipe_personaid = pers_personaid" +
                                                            " WHERE pers_IdSICY IS NOT NULL AND tipe_clasificacionpersonaid IN (15, 16, 17)"
            End If
            consulta += " ) " +
                        " OR IdDistribucion = " + distribucion_sicyID.ToString
        Else
            consulta += " SELECT IdDistribucion, LTRIM(RTRIM(UPPER(distribucion)))+'-'+ltrim(rtrim(upper(direccion)))+', '+LTRIM(RTRIM(UPPER(colonia))) AS distribucion FROM vCadenasDistribucion WHERE IdCadena = " + clienteID.ToString
        End If

        Return operaciones_SICY.EjecutaConsulta(consulta)

    End Function

    Public Function AgenteClienteListaPrecios(ByVal idCliente As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " cmae_colaboradorid_agente," +
                                " UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(250))) AS 'AGENTE'" +
                        " FROM Cliente.ClienteMarcaAgenteEmpresa" +
                        " JOIN Nomina.Colaborador" +
                            " ON codr_colaboradorid = cmae_colaboradorid_agente" +
                        " JOIN Framework.Empresas" +
                            " ON empr_empresaid = cmae_empresaid" +
                        " WHERE cmae_clienteid = " + idCliente.ToString +
                        " GROUP BY	cmae_colaboradorid_agente," +
                                " codr_nombre, codr_apellidopaterno, codr_apellidomaterno" +
                        " ORDER BY codr_nombre, codr_apellidopaterno, codr_apellidomaterno"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    ''' <summary>
    ''' RECUPERA LA MONEDA DEL CLIENTE MAS LA MONEDA DE PESOS EN CASO DE SER MONEDA EXTRANJERA, DE LO CONTRARIO SOLO RECUPERA LA OMNEDA PESOS
    ''' </summary>
    ''' <param name="IdMonedaCliente">ID DE LA MONEDA DEL CLIENTE</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarMonedaDelClienteMasMonedaPeso(ByVal IdMonedaCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String
        If IdMonedaCliente = 1 Then
            cadena = "select mone_monedaid, mone_nombre from Framework.Moneda" +
                    " where mone_monedaid = " + IdMonedaCliente.ToString
        Else
            cadena = "select mone_monedaid, mone_nombre from Framework.Moneda" +
                   " where mone_monedaid in (1," + IdMonedaCliente.ToString + ")"

        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function Recuperar_NumeracionPais()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String

        cadena = "select pais_paisid, pais_nombre from Framework.Paises where pais_paisid in (select talla_paisid from Programacion.Tallas where talla_activo=1)"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function FiltroMarcaAgente(ByVal idCliente As Int32, ByVal idUsuario As Int32) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = idUsuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = idCliente
            listaParametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_ListaPrecioFoto_FiltroMarcaAgente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AgenteClienteMarcasListaPrecios(ByVal idCliente As Int32,
                                                    ByVal IdListaVentaClientePrecio As Integer,
                                                    ByVal conlista As Boolean,
                                                    ByVal marcaEspecial As Int32, ByVal idListaBase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadena As String = ""
        If conlista = True Then
            ' CAMBIO CONSULTA 20 ABRIL 2016, SE CAMBIO LA TABLA ClienteMarcaAgenteEmpresa POR ClienteMarcaFamiliaProyeccionAgente
            'cadena = "SELECT cmae_colaboradorid_agente, marc_descripcion AS MARCA, UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(250))) AS 'AGENTE'" +
            '    " FROM Cliente.ClienteMarcaAgenteEmpresa" +
            '    " JOIN Nomina.Colaborador ON codr_colaboradorid = cmae_colaboradorid_agente" +
            '    " JOIN Framework.Empresas ON empr_empresaid = cmae_empresaid" +
            '    " JOIN Programacion.Marcas ON cmae_marcaid = marc_marcaid" +
            '    " WHERE cmae_clienteid = " + idCliente.ToString +
            '    " AND cmae_marcaid IN (SELECT DISTINCT prod_marcaid" +
            '    " FROM Ventas.ListaPrecioClienteProducto" +
            '    " JOIN Programacion.ProductoEstilo ON pres_productoestiloid = lpcp_productoestiloid" +
            '    " JOIN Programacion.Productos ON prod_productoid = pres_productoid" +
            '    " JOIN Ventas.ListaVentasClientePrecio ON lvcp_listaventasclienteprecioid = lpcp_listaventasclienteid" +
            '    " JOIN Ventas.ListaVentasCliente ON lvcl_listaventasclienteid = lvcp_listaventasclienteid" +
            '    " WHERE lvcl_clienteid = " + idCliente.ToString +
            '    " AND lvcp_listaventasclienteprecioid = " + IdListaVentaClientePrecio.ToString + ")" +
            '    " GROUP BY cmae_colaboradorid_agente, codr_nombre, codr_apellidopaterno, codr_apellidomaterno, marc_descripcion" +
            '    " ORDER BY codr_nombre, codr_apellidopaterno, codr_apellidomaterno, marc_descripcion"
            cadena = "SELECT" & _
            " cmfa_colaboradorid_agente," & _
            " marc_marcaid, marc_descripcion AS MARCA," & _
            " UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(250))) AS 'AGENTE'" & _
                    " FROM Cliente.ClienteMarcaFamiliaProyeccionAgente" & _
                    " Join Nomina.Colaborador ON codr_colaboradorid = cmfa_colaboradorid_agente" & _
                    " Join Framework.Empresas	ON empr_empresaid = empr_empresaid" & _
                    " Join Programacion.Marcas ON cmfa_marcaid = marc_marcaid" & _
                    " WHERE cmfa_clienteid = " & idCliente.ToString & _
        " AND cmfa_marcaid IN (SELECT DISTINCT" & _
                    " prod_marcaid   FROM Ventas.ListaPrecioClienteProducto" & _
                    " Join Programacion.ProductoEstilo ON pres_productoestiloid = lpcp_productoestiloid" & _
                    " Join Programacion.Productos ON prod_productoid = pres_productoid" & _
                    " Join Ventas.ListaVentasClientePrecio ON lvcp_listaventasclienteprecioid = lpcp_listaventasclienteid" & _
                    " Join Ventas.ListaVentasCliente  ON lvcl_listaventasclienteid = lvcp_listaventasclienteid" & _
                    " WHERE lvcl_clienteid = " & idCliente.ToString & _
        " AND lvcp_listaventasclienteprecioid = " & IdListaVentaClientePrecio.ToString + ")" & _
        "and cmfa_activo=1" & _
        " GROUP BY	cmfa_colaboradorid_agente," & _
                    " codr_nombre," & _
                    " codr_apellidopaterno," & _
                    " codr_apellidomaterno," & _
                    " marc_marcaid, marc_descripcion" & _
        " ORDER BY codr_nombre, codr_apellidopaterno, codr_apellidomaterno, marc_descripcion"

        Else
            ' CAMBIO CONSULTA 20 ABRIL 2016, SE CAMBIO LA TABLA ClienteMarcaAgenteEmpresa POR ClienteMarcaFamiliaProyeccionAgente
            'cadena = "SELECT cmae_colaboradorid_agente, marc_descripcion AS MARCA," & _
            '" UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(250))) AS 'AGENTE'" & _
            '" FROM Programacion.Marcas" & _
            '" LEFT JOIN Cliente.ClienteMarcaAgenteEmpresa" & _
            '" ON cmae_marcaid = marc_marcaid AND cmae_activo = 1 AND cmae_clienteid = " + idCliente.ToString & _
            '" LEFT JOIN Nomina.Colaborador " & _
            '" ON codr_colaboradorid = cmae_colaboradorid_agente AND codr_activo = 1 " & _
            '" WHERE marc_marcaid IN (SELECT" & _
            '" DISTINCT(P.prod_marcaid)" & _
            '" FROM Ventas.ListaPreciosBase LB" & _
            '" JOIN Ventas.ListaPrecioBaseProducto LBP	ON LB.lpba_listapreciosbaseid = LBP.lpbp_listapreciosbaseid" & _
            '" JOIN Programacion.ProductoEstilo PR ON LBP.lpbp_productoestiloid = PR.pres_productoestiloid" & _
            '" JOIN Programacion.Productos P ON PR.pres_productoid = P.prod_productoid" & _
            '" JOIN Programacion.Marcas MX ON P.prod_marcaid = MX.marc_marcaid" & _
            '" WHERE LBP.lpbp_activo = 1 AND P.prod_activo = 1 AND PR.pres_activo = 1" & _
            '" AND (MX.marc_esCliente = 0 OR MX.marc_marcaid =" + marcaEspecial.ToString & _
            '" OR MX.marc_marcaid IN (SELECT DISTINCT clme_marcaid FROM Programacion.ClienteMarcaEspecial WHERE clme_activo = 1 AND clme_clienteid IN (" + idCliente.ToString + ")))" & _
            '" AND lb.lpba_listapreciosbaseid = " + idListaBase.ToString + ")" & _
            '" GROUP BY cmae_colaboradorid_agente, codr_nombre," & _
            '" codr_apellidopaterno, codr_apellidomaterno, marc_descripcion" & _
            '" ORDER BY marc_descripcion, codr_nombre, codr_apellidopaterno, codr_apellidomaterno"

            cadena = "SELECT ISNULL(cmfa_colaboradorid_agente, 0) cmfa_colaboradorid_agente, marc_marcaid, marc_descripcion AS MARCA, UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(250))) AS 'AGENTE'" & _
            " FROM Programacion.Marcas" & _
            " LEFT JOIN Cliente.ClienteMarcaFamiliaProyeccionAgente ON cmfa_marcaid = marc_marcaid AND cmfa_activo = 1 AND cmfa_clienteid = " & idCliente.ToString & _
            " LEFT JOIN Nomina.Colaborador ON codr_colaboradorid = cmfa_colaboradorid_agente AND codr_activo = 1" & _
            " WHERE marc_marcaid IN (SELECT DISTINCT (P.prod_marcaid) FROM Ventas.ListaPreciosBase LB " & _
            " JOIN Ventas.ListaPrecioBaseProducto LBP ON LB.lpba_listapreciosbaseid = LBP.lpbp_listapreciosbaseid" & _
            " JOIN Programacion.ProductoEstilo PR	ON LBP.lpbp_productoestiloid = PR.pres_productoestiloid" & _
            " JOIN Programacion.Productos P ON PR.pres_productoid = P.prod_productoid" & _
            " JOIN Programacion.Marcas MX ON P.prod_marcaid = MX.marc_marcaid" & _
            " WHERE LBP.lpbp_activo = 1 AND P.prod_activo = 1 AND PR.pres_activo = 1 AND (MX.marc_esCliente = 0 " & _
            " OR MX.marc_marcaid = " & marcaEspecial.ToString & _
            " OR MX.marc_marcaid IN (SELECT DISTINCT clme_marcaid FROM Programacion.ClienteMarcaEspecial WHERE clme_activo = 1 AND clme_clienteid IN (" & idCliente.ToString & ")))" & _
            " AND lb.lpba_listapreciosbaseid = " & idListaBase.ToString & ")" & _
            " GROUP BY cmfa_colaboradorid_agente, codr_nombre, codr_apellidopaterno, codr_apellidomaterno, marc_marcaid, marc_descripcion" & _
            " ORDER BY marc_descripcion, codr_nombre, codr_apellidopaterno, codr_apellidomaterno"

            '            cadena = "SELECT" & _
            '            " consUno.codr_colaboradorid AS cmfa_colaboradorid_agente," & _
            '                    " m.marc_marcaid," & _
            '                    " m.marc_descripcion 'MARCA'," & _
            '            " UPPER(CAST(consUno.codr_nombre + ' ' + consUno.codr_apellidopaterno + ' ' + consUno.codr_apellidomaterno AS varchar(250))) AS 'AGENTE'" & _
            '        " FROM Programacion.Marcas m" & _
            '        " CROSS JOIN (SELECT" & _
            '            " *" & _
            '        " FROM Nomina.Colaborador c" & _
            '        " JOIN Nomina.ColaboradorLaboral col" & _
            '            " ON c.codr_colaboradorid = col.labo_colaboradorid" & _
            '                    " WHERE col.labo_puestoid = 255" & _
            '        " AND c.codr_activo = 1) AS consUno" & _
            '        " WHERE m.marc_activo = 1 " & _
            '        "AND m.marc_marcaid IN" & _
            '        " (SELECT DISTINCT (P.prod_marcaid) FROM Ventas.ListaPreciosBase LB " & _
            '" JOIN Ventas.ListaPrecioBaseProducto LBP ON LB.lpba_listapreciosbaseid = LBP.lpbp_listapreciosbaseid" & _
            '" JOIN Programacion.ProductoEstilo PR ON LBP.lpbp_productoestiloid = PR.pres_productoestiloid" & _
            '" JOIN Programacion.Productos P ON PR.pres_productoid = P.prod_productoid" & _
            '" JOIN Programacion.Marcas MX ON P.prod_marcaid = MX.marc_marcaid " & _
            '" WHERE LBP.lpbp_activo = 1 AND P.prod_activo = 1 AND PR.pres_activo = 1 AND (MX.marc_esCliente = 0 OR MX.marc_marcaid = 7" & _
            '" OR MX.marc_marcaid IN (SELECT DISTINCT clme_marcaid FROM Programacion.ClienteMarcaEspecial WHERE clme_activo = 1 AND clme_clienteid IN (" & idCliente.ToString & ")))" & _
            '" AND lb.lpba_listapreciosbaseid = " & idListaBase.ToString & ")" & _
            '" ORDER BY MARCA, AGENTE"

        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function


    ''' <summary>
    ''' EJECUTA CONSULTA PARA RECUPERAR EL TIPO DE CLIENTE (NACIONAL O EXTRANJERO) DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACIÓN</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaClienteNacional_Extranjero(ByVal IdCliente As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select clie_tipoclienteid, ticl_nombre, clie_clienteid from cliente.Cliente " +
                    " join ventas.TipoCliente on clie_tipoclienteid = ticl_tipoclienteid " +
                    " where clie_clienteid =" + IdCliente.ToString + " and ticl_activo = 'true' "

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function RecuperarVentas_InfoCliente(ByVal IdCLiente As Integer) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select * from Ventas.InfoCliente where ivcl_clienteid =  " + IdCLiente.ToString

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS NOMBRES DE LOS AJENTES ASIGNADOS A UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdCLiente_say">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LOS DATOS DE SUS AGENTES DE VENTAS ASIGNADOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UN DATATABLE
    ''' </returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' RECUPERA LAS MARCAS DE UN AGENTE ASIGNADO A UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdClienteSay"> ID DEL CLIENTE DEL CUAL SE OBTENDRAN LAS MARCAS DE SU AGENTE ASIGNADO</param>
    ''' <param name="IdAgente">ID DEL AGENTE DEL CUAL SE OBTENDRAN LAS MARCAS ASIGNADAS PARA EL CLIENTE EN CUESTION</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaMarcas_De_Agente_de_cliente(ByVal IdClienteSay As Integer, ByVal IdAgente As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT cmae_clientemarcaagenteempresaid AS 'ID'," +
                " cast( 1 as bit) as ' '," +
                " LTrim(RTrim(UPPER(marc_descripcion))) 'MARCA'," +
                " cast(cmae_activo as bit) AS 'ACTIVO'" +
                " FROM Cliente.ClienteMarcaAgenteEmpresa" +
                " JOIN Programacion.Marcas ON marc_marcaid = cmae_marcaid" +
                " WHERE cmae_clienteid = " + IdClienteSay.ToString +
                " and cmae_colaboradorid_agente = " + IdAgente.ToString +
                " and cmae_activo = 1" +
                " ORDER BY MARCA asc"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function RelacionarContactoMarcaAgente(ByVal Bandera As Integer, ByVal EMail As String, ByVal IdEmailPersona As Integer,
        ByVal Contacto As String, ByVal IdPersona As Integer, ByVal IdsClienteMarcaAgenteEmpresa As String, ByVal IdClienteSAY As Integer) As DataTable
        Dim objOperaciones As New OperacionesProcedimientos
        Dim operaciones As New OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Bandera"
        parametro.Value = Bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EMail"
        parametro.Value = EMail
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdEmailPersona"
        parametro.Value = IdEmailPersona
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Contacto"
        parametro.Value = Contacto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdPersona"
        parametro.Value = IdPersona
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdsClienteMarcaAgenteEmpresa"
        parametro.Value = IdsClienteMarcaAgenteEmpresa
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdClienteSAY"
        parametro.Value = IdClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_Relacionar_ContactoMarcaAgente", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Function

    Public Function ValidarRelaciones_Zapaterias(ByVal IdZApateria As Integer)
        Dim objOperaciones As New OperacionesProcedimientos
        Dim consulta As String

        consulta = <consulta> SELECT CASE WHEN (SELECT
				COUNT(zacc_zapateriasid) AS n
        FROM Ventas.ZapateriasCompetenciaCliente
        WHERE zacc_zapateriasid = <%= IdZApateria.ToString %>
			AND zacc_activo = 1
			GROUP BY zacc_zapateriasid)
			IS NULL THEN 0
		ELSE (SELECT
				COUNT(zacc_zapateriasid) AS n
        FROM Ventas.ZapateriasCompetenciaCliente
        WHERE zacc_zapateriasid = <%= IdZApateria.ToString %>
			AND zacc_activo = 1
			GROUP BY zacc_zapateriasid)
        End </consulta>.Value

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function consultaAgenteMarcaClienteDemoWEB(ByVal idCliente As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                " marc_marcaid," +
                                " cmae_clientemarcaagenteempresaid AS 'ID'" +
                                " , LTRIM(RTRIM(UPPER(marc_descripcion)))'MARCA'" +
                                " , UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS VARCHAR(250))) AS 'AGENTE DE VENTAS'" +
                                " , LTRIM(RTRIM(UPPER(empr_nombre))) AS 'EMPRESA'," +
                                " p.pers_nombre as CONTACTO,e.empe_email as EMAIL, cmae_activo AS 'ACTIVO'" +
                                " FROM Cliente.ClienteMarcaAgenteEmpresa" +
                                " JOIN Programacion.Marcas ON marc_marcaid = cmae_marcaid" +
                                " JOIN Nomina.Colaborador ON codr_colaboradorid = cmae_colaboradorid_agente" +
                                " JOIN Framework.Empresas ON empr_empresaid = cmae_empresaid" +
                                " left join Framework.EmailPersonas e on e.empe_emailpersonasid= cmae_emailpersonasid" +
                                " left join Framework.Persona p on p.pers_personaid=e.empe_personaid and e.empe_clasificacionpersonaid=23" +
                                " WHERE cmae_clienteid = " + idCliente.ToString +
                                " ORDER BY cmae_activo desc,[MARCA], [AGENTE DE VENTAS]"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function consultaComboMarcasParaFamilia(ByVal idCliente As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_ConsultaMarcasParaFamilias", listaParametros)
    End Function

    Public Function consultaComboAgentesParaFamilia(ByVal idCliente As Int32, ByVal idMarca As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        parametros = New SqlParameter
        parametros.ParameterName = "idMarca"
        parametros.Value = idMarca
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_ConsultaAgentesParaFamilias", listaParametros)
    End Function

    Public Function consultaAgenteMarcaFamiliaAsignados(ByVal idCliente As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "idCliente"
        parametros.Value = idCliente
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_ConsultaMarcaFamiliaAgenteAsignados", listaParametros)
    End Function


    Public Function consultaAgenteSicy(ByVal idAgenteSay As Int32) As DataTable
        Dim consulta As String = "SELECT cast(IdAgente as varchar(200)) + ' - ' + Nombre as agenteSicy FROM Agentes WHERE Activo=1 AND codr_colaboradorid=" + idAgenteSay.ToString
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function consultaMarcasFamiliasPorAsignar(ByVal idCliente As Int32, ByVal idMarca As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarca"
        parametro.Value = idMarca
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Ventas.SP_ConsultaMarcaFamiliaAgentePorAsignar", listaParametros)
    End Function

    Public Sub insertaActualizaRelacionMarcaFamila(ByVal idCliente As Int32, ByVal idAgente As Int32, ByVal idFamilia As Int32, ByVal idMarca As Int32, ByVal idUsuario As Int32, ByVal operacion As Int32, idCoord As Int32)
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim pantallaOperacion As String = "FTC"


        parametro.ParameterName = "idCliente"
        parametro.Value = idCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAgente"
        parametro.Value = idAgente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idMarca"
        parametro.Value = idMarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idFamilia"
        parametro.Value = idFamilia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "operacion"
        parametro.Value = operacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCoord"
        parametro.Value = idCoord
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_InsertaActualizaRelacionMarcaFamilia", listaParametros)
    End Sub

    Public Function replica_ClienteMarcaFamiliaproyeccion_SAY_SICY()
        '(@idClienteSICY int,@idClienteSAY int,@idMarcaSICY varchar(2),@nombreUsuario varchar(30),@pantallaOperacion as varchar(40))

        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        'Return operacion.EjecutarConsultaSP("[192.168.2.2].[Yuyin_Respaldo].Cliente.[SP_Replicar_ClienteMarcaFamiliaProyeccion_SAY_A_SICY]", listaParametros)
        Return operacion.EjecutarConsultaSP("[Cliente].[SP_Replicar_ClienteMarcaFamiliaProyeccion_SAY_A_SICY]", listaParametros)
    End Function


    Public Function replica_ClienteMarcaAgentEmpresa_SAY_SICY(nombreUsuario As String, idClienteSAY As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@nombreUsuario"
        parametro.Value = nombreUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idClienteSAY"
        parametro.Value = idClienteSAY
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_ReplicaClienteMarcaAgenteEmpresa_SAY_SICY_Individual", listaParametros)
    End Function

    Public Function actualizaProspecta()
        '(@idClienteSICY int,@idClienteSAY int,@idMarcaSICY varchar(2),@nombreUsuario varchar(30),@pantallaOperacion as varchar(40))

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return operacion.EjecutarConsultaSP("Ventas.SP_actualizaProspecta", listaParametros)
    End Function

    Public Function actualizarInfoClientePago_NotaCredito(ByVal metodoPago As Int16, ByVal formaPago As Int16, ByVal clienteID As Int64)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@MetodoPagoID"
        parametro.Value = metodoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FormaPagoID"
        parametro.Value = formaPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteID"
        parametro.Value = clienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioModificoID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarSentenciaSP("[Cobranza].[SP_InfoCliente_EditarFormaMetodoPagoCliente_NotaCredito]", listaParametros)
    End Function

    Public Function quitaAgenteComision(idUsuario As Integer, nombreUsuario As String, idClienteSAY As Integer, idMarcaSAY As Integer, idAgenteSAY As Integer)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nombreUsuario"
        parametro.Value = nombreUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idClienteSAY"
        parametro.Value = idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idMarcaSAY"
        parametro.Value = idMarcaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgenteSAY"
        parametro.Value = idAgenteSAY
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_EliminaAgenteComisionDeAgenteVentas_SAY_SICY", listaParametros)
    End Function



#Region "Cambios FTC facturacion 3.3"
    Public Sub actualizaClaveSAT(clave As Int32, idClienteSAY As Integer)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@claveSAT"
        parametro.Value = clave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)



        operacion.EjecutarSentenciaSP("Ventas.SP_FTC_EditarClaveSAT", listaParametros)
    End Sub

    Public Function consultaUsoCFDI(ByVal personaFisica As Int32, ByVal personaMoral As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@personaFisica"
        parametro.Value = personaFisica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@personaMoral"
        parametro.Value = personaMoral
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_FTC_ConsultaUsodeCFDI", listaParametros)
    End Function

    Public Function consultaUsoCFDIPorCliente(ByVal clienteid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteId"
        parametro.Value = clienteid
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_FTC_ConsultaUsodeCFDICliente", listaParametros)
    End Function

    Public Sub editarUsoCFDICliente(ByVal clienteid As Int32, ByVal clave As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@claveCFDI"
        parametro.Value = clave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioModificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)



        operacion.EjecutarSentenciaSP("Ventas.SP_FTC_EditarUsodeCFDICliente", listaParametros)
    End Sub


    Public Function consultaRestriccionClienteMarca(ByVal clienteid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteId"
        parametro.Value = clienteid
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_FTC_ConsultaRestriccionFacturaClienteMarca", listaParametros)
    End Function

    Public Sub insertaActualizaMarcaPorFacturaCliente(ByVal clienteid As Int32, ByVal marcaid As Int32, ByVal operacionM As Int32,
                                                      ByVal seleccion As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteId"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@marcaid"
        parametro.Value = marcaid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@operacion"
        parametro.Value = operacionM
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@seleccion"
        parametro.Value = seleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_FTC_InsertaActualizaMarcaPorFacturaCliente", listaParametros)

    End Sub

    Public Function consultaMarcasConcatenadasRestriccionFactura(ByVal clienteid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@clienteid"
        parametro.Value = clienteid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_FTC_ConsultaMarcasConcatenadasRestriccionFactura", listaParametros)
    End Function

    Public Function consultaUsoCFDIPedidos(ByVal personaFisica As Int32, ByVal personaMoral As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@personaFisica"
        parametro.Value = personaFisica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@personaMoral"
        parametro.Value = personaMoral
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_PedidosWeb_ConsultaUsodeCFDI", listaParametros)
    End Function
#End Region

    Public Function ExisteTiendaEnPedidosActivos(ByVal PersonaID As Integer)


        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PersonaID"
        parametro.Value = PersonaID
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Cliente].[SP_FTC_TEC_ExisteTiendaEnPedidoActivo]", listaParametros)

    End Function

    Public Function ObtenerIdMarcaIdFamilia(ByVal xml As String)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@xmlCeldas", xml)
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_ObtenerIdMarcaIdFamilia]", listaParametros)
    End Function

    Public Function ConsultaPedidosCliente(ByVal idCliente As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@idCliente", idCliente)
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_ConsultaPedidosCliente]", listaParametros)
    End Function

    Public Function ConsultaPedidosDetalleCliente(ByVal idpedido As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@idPedido", idpedido)
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_ConsultaPedidosDetallesCliente]", listaParametros)
    End Function

    Public Function ValidaExistenArticulos(ByVal idPedido As Integer, ByVal idMarca As Integer, ByVal idFamilia As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@idPedido", idPedido)
        listaParametros.Add(parametro)
        'parametro = New SqlParameter("@idPE", idPE)
        'listaParametros.Add(parametro)
        parametro = New SqlParameter("@idMarca", idMarca)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@idFamilia", idFamilia)
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_ValidaExistenArticulos]", listaParametros)
    End Function

    Public Function Eliminarregistro(ByVal cadenaids As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter("@cadenaIds", cadenaids)
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_Eliminarregistro]", listaParametros)
    End Function

    Public Function GuardarBitacoraInactivos(ByVal id As Integer, ByVal idcliente As Integer, ByVal idmarca As Integer, ByVal idfamiliap As Integer,
                                             ByVal colaboradoridagente As Integer, ByVal usuarioinactivo As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@id", id)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@idcliente", idcliente)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@idmarca", idmarca)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@idfamiliap", idfamiliap)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@colaboradoridagente", colaboradoridagente)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@usuarioinactivo", usuarioinactivo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_GuardarBitacoraInactivados]", listaParametros)
    End Function

End Class
