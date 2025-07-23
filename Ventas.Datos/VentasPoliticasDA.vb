Imports Persistencia
Imports System.Data.SqlClient

Public Class VentasPoliticasDA

    Public Sub editarVentasPoliticas(ByVal PoliticaVenta As Entidades.PoliticaVenta, bandera As Integer)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "bandera"
        parametro.Value = bandera
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "confirmarpedido"
        If IsNothing(PoliticaVenta.confirmarpedido) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.confirmarpedido
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "horasconfirmapedido"
        If IsNothing(PoliticaVenta.horasconfirmapedido) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaVenta.horasconfirmapedido
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importemaxventa"
        If IsNothing(PoliticaVenta.importemaxventa) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaVenta.importemaxventa
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "unidadventaid"
        If IsNothing(PoliticaVenta.unidadventa) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaVenta.unidadventa.unidadventaid
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ventaminima"
        parametro.Value = PoliticaVenta.ventaminima
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "notasventas"
        If String.IsNullOrWhiteSpace(PoliticaVenta.notasventas) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaVenta.notasventas
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "citaentrega"
        If IsNothing(PoliticaVenta.citaentrega) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.citaentrega
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tiempoanticipacionentrega"
        If String.IsNullOrWhiteSpace(PoliticaVenta.tiempoanticipacionentrega) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaVenta.tiempoanticipacionentrega
        End If
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "incoterm"
        'If String.IsNullOrWhiteSpace(PoliticaVenta.incoterm) Then
        '    parametro.Value = String.Empty
        'Else
        '    parametro.Value = PoliticaVenta.incoterm
        'End If
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "validarcodigoetiqueta"
        If Not PoliticaVenta.validarcodigoetiqueta Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.validarcodigoetiqueta
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoAMECE"
        If Not PoliticaVenta.CodigoAMECE Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.CodigoAMECE
        End If
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "entregamercanciasinfacturar"
        If Not PoliticaVenta.entregamercanciasinfacturar Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.entregamercanciasinfacturar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imprimirdirecciontienda"
        If Not PoliticaVenta.imprimirdirecciontienda Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.imprimirdirecciontienda
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imprimirocfacturar"
        If Not PoliticaVenta.imprimirocfacturar Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.imprimirocfacturar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "imprimirtiendafacturar"
        If Not PoliticaVenta.imprimirtiendafacturar Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.imprimirtiendafacturar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = PoliticaVenta.cliente.clienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "correoconfirmarpedido"
        If IsNothing(PoliticaVenta.correoConfirmacionPedido) Then
            parametro.Value = False
        Else
            parametro.Value = PoliticaVenta.correoConfirmacionPedido
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoapartado"
        If IsNothing(PoliticaVenta.tipoApartado) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaVenta.tipoApartado
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "notasapartado"
        If IsNothing(PoliticaVenta.notasApartado) Then
            parametro.Value = String.Empty
        Else
            parametro.Value = PoliticaVenta.notasApartado
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "renglonesFacturar"
        If IsNothing(PoliticaVenta.renglonesFacturar) Then
            parametro.Value = 0
        Else
            parametro.Value = PoliticaVenta.renglonesFacturar
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DescripcionEspecialDocumento"
        parametro.Value = PoliticaVenta.DescripcionEspecialDocumento
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_Politicas_Venta", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function TablaDocumentosSegunClaseDocumento(claseDocumento As String, clienteID As Integer, AreaOperativa As Integer) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                " docl_documentosclienteid" +
                                ", tido_tipodocumentoid" +
                                ", LTRIM(RTRIM(UPPER(tido_nombre))) AS tido_nombre" +
                                ", docl_numerocopias" +
                                ", clie_clienteid" +
                                ", LTRIM(RTRIM(UPPER(clie_nombregenerico))) AS clie_nombregenerico" +
                                ", pers_personaid" +
                                ", docl_activo as 'ACTIVO'" +
                                " FROM Ventas.DocumentosCliente" +
                                " JOIN Ventas.TipoDocumento ON tido_tipodocumentoid = docl_tipodocumentoid" +
                                " JOIN Cliente.Cliente ON clie_clienteid = docl_clienteid" +
                                " JOIN Framework.Persona ON pers_personaid = clie_personaidcliente" +
                                " WHERE tido_clasedocumento = '" + claseDocumento + "' AND clie_clienteid = " + clienteID.ToString +
                                " order by docl_activo desc, tido_nombre "

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function TablaTipoDocumentosSegunClaseDocumento(claseDocumento As String, AreaOperativa As Integer) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT tido_tipodocumentoid, LTRIM(RTRIM(UPPER(tido_nombre))) AS tido_nombre" +
                                " FROM Ventas.TipoDocumento WHERE tido_clasedocumento ='" + claseDocumento + " ' AND tido_activo = 1 ORDER BY tido_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub altaDocumentosCliente(documento As Entidades.Documento, cliente As Entidades.Cliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@tipodocumentoid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "tipodocumentoid"
        parametro.Value = documento.tipodocumento.tipodocumentoid
        listaParametros.Add(parametro)

        ',@numerocopias AS  INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "numerocopias"
        parametro.Value = documento.numerocopias
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_DocumentosCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub editarDocumentosCliente(documento As Entidades.Documento, cliente As Entidades.Cliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        '@documentosclienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "documentosclienteid"
        parametro.Value = documento.documentosclienteid
        listaParametros.Add(parametro)

        '@tipodocumentoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipodocumentoid"
        parametro.Value = documento.tipodocumento.tipodocumentoid
        listaParametros.Add(parametro)

        ',@numerocopias AS  INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "numerocopias"
        parametro.Value = documento.numerocopias
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BOOLEAN
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = documento.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_DocumentosCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaEtiquetasCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   etcl_etiquetaclienteid " +
                                " , LTRIM(RTRIM(UPPER(tiet_nombre))) AS tiet_nombre" +
                                " , etcl_imprimeenyuyin" +
                                " , LTRIM(RTRIM(UPPER(fiet_nombre))) AS fiet_nombre" +
                                " , LTRIM(RTRIM(LOWER(etcl_rutaimagen))) AS etcl_rutaimagen" +
                                " , etcl_clienteid, etcl_activo AS 'Activo', ' ' as 'imagen_archivo',etcl_tipoetiquetaid " +
                                " FROM Ventas.EtiquetaCliente" +
                                " JOIN Ventas.TipoEtiqueta ON tiet_tipoetiquetaespecialid = etcl_tipoetiquetaid" +
                                " JOIN Ventas.FuenteInformacionEtiqueta ON fiet_fuenteinformacionetiquetaid = etcl_fuenteinformacionetiquetaid" +
                                " WHERE etcl_clienteid = " + clienteID.ToString +
                                " order by etcl_activo desc, tiet_nombre "

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function Datos_TablaTipoEtiquetasCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tiet_tipoetiquetaespecialid " +
                                " , LTRIM(RTRIM(UPPER(tiet_nombre))) AS tiet_nombre " +
                                " FROM Ventas.TipoEtiqueta " +
                                "where tiet_activo=1 and tiet_etiquetaporcliente=1 " +
                                "order by tiet_etiquetaespecial,tiet_nombre "


        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaFuenteInformacionEtiquetasCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   fiet_fuenteinformacionetiquetaid " +
                                " , LTRIM(RTRIM(UPPER(fiet_nombre))) AS fiet_nombre " +
                                " FROM Ventas.FuenteInformacionEtiqueta " +
                                " ORDER BY fiet_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaTamanoEtiquetasCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "  taet_tamanoetiquetaid " +
                                " , LTRIM(RTRIM(UPPER(taet_nombre))) AS taet_nombre " +
                                " FROM Ventas.TamanoEtiqueta " +
                                " ORDER BY taet_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaUbicacionEtiquetasCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   ubet_ubicacionetiquetaid " +
                                " , LTRIM(RTRIM(UPPER(ubet_nombre))) AS ubet_nombre " +
                                " FROM Ventas.UbicacionEtiqueta " +
                                " ORDER BY ubet_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_UltimaEtiquetaCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT MAX(etcl_etiquetaclienteid) FROM Ventas.EtiquetaCliente"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_UltimaEtiquetaCliente_mas1() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT MAX(etcl_etiquetaclienteid) + 1 FROM Ventas.EtiquetaCliente"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaEtiquetaCliente(etiqueta As Entidades.EtiquetaCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@tipoetiquetaid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "tipoetiquetaid"
        parametro.Value = etiqueta.tipoetiquetaespecial.tipoetiquetaespecialid
        listaParametros.Add(parametro)

        ',@imprimeenyuyin AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "imprimeenyuyin"
        parametro.Value = etiqueta.imprimeenyuyin
        listaParametros.Add(parametro)

        ',@fuenteinformacionetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "fuenteinformacionetiquetaid"
        parametro.Value = etiqueta.fuenteinformacionetiqueta.fuenteinformacionetiquetaid
        listaParametros.Add(parametro)

        ',@tamanoetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tamanoetiquetaid"
        'parametro.Value = etiqueta.tamanoetiqueta.tamanoetiquetaid
        parametro.Value = Nothing
        listaParametros.Add(parametro)

        ',@ubicacionetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ubicacionetiquetaid"
        'parametro.Value = etiqueta.ubicacionetiqueta.ubicacionetiquetaid
        parametro.Value = Nothing
        listaParametros.Add(parametro)

        ',@rutaimagen AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "rutaimagen"
        'parametro.Value = etiqueta.rutaimagen
        parametro.Value = Nothing
        listaParametros.Add(parametro)

        ',@clienteid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = etiqueta.cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER 
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_EtiquetaCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarEtiquetaCliente(etiqueta As Entidades.EtiquetaCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@etiquetaclienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "etiquetaclienteid"
        parametro.Value = etiqueta.etiquetaclienteid
        listaParametros.Add(parametro)

        ',@tipoetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tipoetiquetaid"
        parametro.Value = etiqueta.tipoetiquetaespecial.tipoetiquetaespecialid
        listaParametros.Add(parametro)

        ',@imprimeenyuyin AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "imprimeenyuyin"
        parametro.Value = etiqueta.imprimeenyuyin
        listaParametros.Add(parametro)

        ',@fuenteinformacionetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "fuenteinformacionetiquetaid"
        parametro.Value = etiqueta.fuenteinformacionetiqueta.fuenteinformacionetiquetaid
        listaParametros.Add(parametro)

        ',@tamanoetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "tamanoetiquetaid"
        parametro.Value = Nothing 'etiqueta.tamanoetiqueta.tamanoetiquetaid
        listaParametros.Add(parametro)

        ',@ubicacionetiquetaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "ubicacionetiquetaid"
        parametro.Value = Nothing 'etiqueta.ubicacionetiqueta.ubicacionetiquetaid
        listaParametros.Add(parametro)

        ',@rutaimagen AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "rutaimagen"
        parametro.Value = Nothing 'etiqueta.rutaimagen
        listaParametros.Add(parametro)

        ',@clienteid AS VARCHAR(50)
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = etiqueta.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = etiqueta.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_EtiquetaCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaRequerimientosEspecialesCliente(clienteID As Integer, areaOperativa As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   clie_clienteid" +
                                " , recl_requerimientoespecialclienteid" +
                                " , LTRIM(RTRIM(UPPER(tres_nombre))) AS tres_nombre" +
                                " , LTRIM(RTRIM(UPPER(rees_nombre))) AS rees_nombre" +
                                " , LTRIM(RTRIM(UPPER(recl_valor))) AS recl_valor" +
                                " , LTRIM(RTRIM(UPPER(recl_descripcion))) AS recl_descripcion, recl_activo  as 'Activo'" +
                                " FROM Ventas.RequerimientoEspecialCliente" +
                                " JOIN Ventas.RequerimientoEspecial ON rees_requerimientoespecialid = recl_requerimientoespecialid" +
                                " JOIN Ventas.TipoRequerimientoEspecial ON tres_tiporequerimientoespecialid = rees_tiporequerimientoespecialid" +
                                " JOIN Cliente.Cliente ON clie_clienteid = recl_clienteid" +
                                " WHERE clie_clienteid = " + clienteID.ToString +
                                " order by recl_activo desc,tres_nombre,rees_nombre "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaRequerimientosCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   rees_requerimientoespecialid" +
                                " , LTRIM(RTRIM(UPPER(rees_nombre))) AS rees_nombre" +
                                " FROM Ventas.RequerimientoEspecial" +
                                " ORDER BY rees_nombre "
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Datos_TablaTipoRequerimientosCliente() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT " +
                                "   tres_tiporequerimientoespecialid" +
                                " , LTRIM(RTRIM(UPPER(tres_nombre))) AS tres_nombre" +
                                " FROM Ventas.TipoRequerimientoEspecial" +
                                " ORDER BY tres_nombre"
        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub AltaRequerimientoCliente(requerimiento As Entidades.RequerimientoEspCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@valor AS VARCHAR(10)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "valor"
        parametro.Value = requerimiento.valor
        listaParametros.Add(parametro)

        ',@descripcion AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = requerimiento.descripcion
        listaParametros.Add(parametro)

        ',@requerimientoespecialid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "requerimientoespecialid"
        parametro.Value = requerimiento.requerimientoespecial.requerimientoespecialid
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = requerimiento.cliente.clienteid
        listaParametros.Add(parametro)

        ',@usuariocreoid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Ventas.SP_Alta_RequerimientoEspecialCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Sub EditarRequerimientoCliente(requerimiento As Entidades.RequerimientoEspCliente)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        ',@requerimientoespecialclienteid AS INTEGER
        Dim parametro As New SqlParameter
        parametro.ParameterName = "requerimientoespecialclienteid"
        parametro.Value = requerimiento.requerimientoespecialclienteid
        listaParametros.Add(parametro)

        ',@valor AS VARCHAR(10)
        parametro = New SqlParameter
        parametro.ParameterName = "valor"
        parametro.Value = requerimiento.valor
        listaParametros.Add(parametro)

        ',@descripcion AS VARCHAR(100)
        parametro = New SqlParameter
        parametro.ParameterName = "descripcion"
        parametro.Value = requerimiento.descripcion
        listaParametros.Add(parametro)

        ',@requerimientoespecialid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "requerimientoespecialid"
        parametro.Value = requerimiento.requerimientoespecial.requerimientoespecialid
        listaParametros.Add(parametro)

        ',@clienteid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "clienteid"
        parametro.Value = requerimiento.cliente.clienteid
        listaParametros.Add(parametro)

        ',@activo AS BIT
        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = requerimiento.activo
        listaParametros.Add(parametro)

        ',@usuariomodificaid AS INTEGER
        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificaid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Ventas.SP_Editar_RequerimientoEspecialCliente", listaParametros)
        Console.WriteLine("Mando la sentencia")

    End Sub

    Public Function Datos_TablaPoliticaVenta(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT * FROM Ventas.PoliticaVenta where pove_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    ''' <summary>
    ''' CONSULTA EL TIPO DE ETIQUETA DE CLIENTE ESPECIAL
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Consultar_Nombre_Etiqueta_Cliente() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Dim Consulta As String = "select tiet_nombre from Ventas.TipoEtiqueta where tiet_activo = 1 and tiet_etiquetaespecial = 1"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function


    Public Sub ActualizarRutaArchivoPDF_FTC_Etiquetado(ByVal Ruta_PDF As String, ByVal IdCLienteSay As Integer, ByVal Alta_Baja_Archivo As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        If Alta_Baja_Archivo = True Then
            consulta = "update ventas.InfoCliente" +
                    " set  ivcl_rutafichatecnicaetiquetado = '" + Ruta_PDF + "'," +
                    " ivcl_usuariomodificaid =" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " ," +
                    " ivcl_fechamodificacion = (select GETDATE())" +
                    " where ivcl_clienteid = " + IdCLienteSay.ToString
        Else
            consulta = "update ventas.InfoCliente" +
                    " set  ivcl_rutafichatecnicaetiquetado = '" + Ruta_PDF + "'," +
                    " ivcl_usuariomodificaid =" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + " ," +
                    " ivcl_fechamodificacion = (select GETDATE())" +
                    " where ivcl_clienteid = " + IdCLienteSay.ToString
        End If


        objPersistencia.EjecutaConsulta(consulta)
    End Sub


    Public Function ConsultarRutaFTCEtiqueta(ByVal IdClienteSAY As Integer)
        Dim objPersistencia As New OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = "select ivcl_rutafichatecnicaetiquetado from ventas.InfoCliente where ivcl_clienteid = " + IdClienteSAY.ToString

        Return objPersistencia.EjecutaConsulta(consulta)

    End Function


    Public Sub EliminarRutaEtiquetaespecial(ByVal IdClienteSAY As Integer)

        Dim objPersistencia As New OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = " update ventas.InfoCliente" +
                    " set ivcl_rutafichatecnicaetiquetado = ''" +
                    "       , ivcl_usuariomodificaid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    "       , ivcl_fechamodificacion = (select GETDATE())" +
                    " where ivcl_clienteid = " + IdClienteSAY.ToString

        objPersistencia.EjecutaConsulta(consulta)

    End Sub


    Public Function ConsultarCorridasExtranjeras(Cliente As Integer) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = Cliente
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Cliente].[SP_FTC_ConsultarTallasExtranjeras]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarCorridaExtranjeraCliente(TallasExtranjeras As Entidades.TallasExtranjerasCliente, Seleccionado As Integer)
        Dim Persistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@PaisID"
            parametro.Value = TallasExtranjeras.Pais
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = TallasExtranjeras.Cliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuaroCreoID"
            parametro.Value = TallasExtranjeras.UsuarioCreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Seleccionado"
            parametro.Value = Seleccionado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioModificoID"
            parametro.Value = TallasExtranjeras.UsuarioModifico
            listaParametros.Add(parametro)

            Persistencia.EjecutarConsultaSP("[Cliente].[SP_Inserta_TallaExtranjeraCliEnte]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultaEtiquetaAutorizada(ByVal clienteID As Integer) As DataTable
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = clienteID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("programacion.SP_Etiquetas_ConsultaAutorizacion", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EliminaEtiquetaFichaTecnica(ByVal clienteID As Integer, ByVal usuarioID As Integer, ByVal tipoEtiqueta As Integer, ByVal NombreEtiqueta As String)
        Dim objPersistencia As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@clienteID"
        parametro.Value = clienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = usuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoEtiqueta"
        parametro.Value = tipoEtiqueta
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@nombreEtiqueta"
        parametro.Value = NombreEtiqueta
        listaParametros.Add(parametro)


        objPersistencia.EjecutarConsultaSP("Programacion.SP_EliminaEtiquetaFichaTecnica", listaParametros)
    End Sub
End Class
