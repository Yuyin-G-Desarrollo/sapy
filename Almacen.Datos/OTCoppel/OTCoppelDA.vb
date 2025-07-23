Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class OTCoppelDA

    Public Function RecuperarTiendasPedido(ByVal idPedido As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        If idPedido > 0 Then
            consulta = "SELECT distinct idtblTienda as idDistribucion,Nombre_Tienda FROM vtaDistribuciones WHERE IdtblPedido= " + idPedido.ToString + " ORDER BY Nombre_Tienda"
        Else
            consulta = "SELECT distinct idDistribucion,Distribucion as Nombre_Tienda FROM vcadenasDistribucion WHERE idcadena = 947 ORDER BY Distribucion"
        End If
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function RecuperarFechaEntrega(ByVal idPedido As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "SELECT DISTINCT otco_fechaentrega FROM Almacen.OTCoppel WHERE otco_idpedido= " + idPedido.ToString
        consulta += " union " + Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function DetalleTiendasPedido(ByVal idOrdenTrabajo As String, ByVal idPedido As String, ByVal idDistribucion As String, ByVal estatus As String, ByVal fechaEntregaDe As String, ByVal fechaEntregaA As String) As DataTable
        'Dim objPersistencia As New Persistencia.OperacionesProcedimientosPruebas
        'Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'Dim banderaFiltros As Int32 = 0
        ''consulta = "SELECT 0 as seleccion, cons.estatus_facturado,cons.estatus_Confirmado,cons.estatus_Embarque, cons.estatus_i as estatus_Incidencias, ' ' as i ,cons.otco_idotcoppel,cons.otco_idpedido,cons.otco_idtienda,cons.NombreTienda,"
        ''consulta += " cons.otco_totalpares,cons.pares_Inventario,cons.pares_Confirmados, cons.otco_totalpares-cons.pares_Confirmados as pares_faltantes,cons.pares_salida,cons.estatus "
        ''consulta += ", cons.fechaFacturacion, cons.fechaConfirmacion, cons.colaboradorConfirmo, cons.fechaEmbarque, cons.texto_i as texto_Incidencias "

        ''consulta += " FROM(SELECT null as estatus_facturado, null as estatus_Confirmado, null as estatus_Embarque, ot.otco_idotcoppel,ot.otco_idpedido,ot.otco_idtienda,"
        ''consulta += " d.nombre as NombreTienda, ot.otco_totalpares, ISNULL((SELECT sum(pares) FROM tmpdocenaspares_Coppel tmp INNER JOIN Almacen.OtCoppelDetalles otd on otd.otcod_idpartida=tmp.idtblPartida"
        ''consulta += " and otd.otcod_idOtCoppel=ot.otco_idotcoppel AND ot.otco_idpedido=tmp.idtblPedido and otd.otcod_talla=tmp.Calce where idtblpedido=ot.otco_idpedido and idtblPartida=otd.otcod_idpartida ),0) as pares_Inventario,"
        ''consulta += " (select SUM(otcod_paresConfirmados) FROM Almacen.OtCoppelDetalles  WHERE otcod_idOtCoppel=ot.otco_idotcoppel GROUP by otcod_idOtCoppel) as pares_Confirmados ,"
        ''consulta += " ISNULL( (SELECT  COUNT(dp.otdp_idPar) FROM Almacen.OtCoppelDetallesPares dp INNER JOIN Almacen.OtCoppelDetalles d on d.otcod_idOtCoppelDetalles=dp.otdp_idOtCoppelDetalle"
        ''consulta += " where d.otcod_idotCoppel=ot.otco_idotcoppel AND dp.otdp_status=2),0) as pares_salida,ot.otco_estatus as estatus"

        ''consulta += ", ot.otco_fechafacturacion as fechaFacturacion, ot.otco_fechaconfirmacion as fechaConfirmacion, c.user_username as colaboradorConfirmo"
        ''consulta += ", (SELECT DISTINCT top 1 dp.otdp_FechaSalida FROM Almacen.OtCoppelDetallesPares dp INNER JOIN Almacen.OtCoppelDetalles cd on cd.otcod_idOtCoppelDetalles = dp.otdp_idOtCoppelDetalle WHERE cd.otcod_idotCoppel = ot.otco_idotcoppel) as fechaEmbarque "
        ''consulta += ", I.status_incidencias as estatus_i , I.texto_incidencias as texto_i"

        ''consulta += " FROM Almacen.OTCoppel ot INNER JOIN Distribuciones d on ot.otco_idtienda=d.IdDistribucion"

        ''consulta += " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = ot.otco_colaboradorconfirmoid "
        ''consulta += " LEFT JOIN (SELECT 1 AS status_incidencias, ocin_idotcoppel, 'De los '+ CAST(SUM(ocin_paresleidos) AS VARCHAR(10)) + ' pares leidos, ' + CAST(SUM(ocin_paresincorrectos) AS VARCHAR(10)) +' son incidencias'  as texto_incidencias FROM Almacen.OTCoppel_Incidencias group by ocin_idotcoppel) as I ON ot.otco_idotcoppel = I.ocin_idotcoppel "

        'consulta = "SELECT 0 as seleccion, cons.estatus_facturado,cons.estatus_Confirmado,cons.estatus_Embarque, cons.estatus_i as estatus_Incidencias, ' ' as i ,cons.otco_idotcoppel,cons.otco_idpedido,cons.otco_idtienda,cons.NombreTienda,"
        'consulta += " cons.otco_totalpares,cons.pares_Inventario,cons.pares_Confirmados,cons.pares_Correctos,cons.pares_Externos, cons.otco_totalpares-cons.pares_Confirmados as pares_faltantes,cons.pares_salida,cons.estatus "
        'consulta += ", cons.fechaFacturacion, cons.fechaConfirmacion, cons.colaboradorConfirmo, cons.fechaEmbarque, cons.texto_i as texto_Incidencias "

        'consulta += " FROM(SELECT null as estatus_facturado, null as estatus_Confirmado, null as estatus_Embarque, ot.otco_idotcoppel,ot.otco_idpedido,ot.otco_idtienda,"
        'consulta += " d.nombre as NombreTienda, ot.otco_totalpares, 0 as pares_Inventario,"
        'consulta += " ot.otco_paresconfirmados	AS pares_Confirmados,"
        'consulta += " ot.otco_parescorrectos AS pares_Correctos, ot.otco_paresexternos AS pares_Externos,"
        'consulta += " 	ot.otco_paressalidas AS pares_salida,ot.otco_estatus as estatus"

        'consulta += ", ot.otco_fechafacturacion as fechaFacturacion, ot.otco_fechaconfirmacion as fechaConfirmacion, c.user_username as colaboradorConfirmo"
        'consulta += ", ot.otco_fechaSalida	AS fechaEmbarque "
        'consulta += ", I.status_incidencias as estatus_i , I.texto_incidencias as texto_i"

        'consulta += " FROM Almacen.OTCoppel ot INNER JOIN Distribuciones d on ot.otco_idtienda=d.IdDistribucion"

        'consulta += " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios c on c.user_usuarioid = ot.otco_colaboradorconfirmoid "
        'consulta += " LEFT JOIN (SELECT 1 AS status_incidencias, ocin_idotcoppel, 'De los '+ CAST(SUM(ocin_paresleidos) AS VARCHAR(10)) + ' pares leidos, ' + CAST(SUM(ocin_paresincorrectos) AS VARCHAR(10)) +' son incidencias'  as texto_incidencias FROM Almacen.OTCoppel_Incidencias group by ocin_idotcoppel) as I ON ot.otco_idotcoppel = I.ocin_idotcoppel "



        'If Not String.IsNullOrEmpty(idOrdenTrabajo) Then
        '    consulta += " WHERE ot.otco_idotcoppel= " + idOrdenTrabajo.ToString
        '    banderaFiltros += 1
        'End If


        'If idPedido <> 0 Then
        '    If banderaFiltros > 0 Then
        '        consulta += " AND "
        '    Else
        '        consulta += " WHERE "
        '    End If
        '    consulta += " ot.otco_idpedido= " + idPedido.ToString
        '    banderaFiltros += 1
        'End If

        ''If estatus = "" Then
        ''    If idPedido <> 0 Then
        ''        consulta += " AND "
        ''    End If
        ''    consulta += " ot.otco_estatus in ('PF','S','PC')"
        ''End If

        'If idDistribucion > 0 Then
        '    If banderaFiltros > 0 Then
        '        consulta += " AND "
        '    Else
        '        consulta += " WHERE "
        '    End If
        '    consulta += " ot.otco_idtienda= " + idDistribucion.ToString
        '    banderaFiltros += 1
        'End If

        'If estatus <> "" Then

        '    If banderaFiltros > 0 Then
        '        consulta += " AND "
        '    Else
        '        consulta += " WHERE "
        '    End If
        '    consulta += " ot.otco_estatus='" + estatus + "'"
        '    banderaFiltros += 1
        'End If

        'If idDistribucion > 0 Or estatus <> "" Then
        '    If fechaEntregaDe <> "" And fechaEntregaA <> "" Then
        '        consulta += " AND ot.otco_fechaentrega BETWEEN '" + fechaEntregaDe + "' AND '" + fechaEntregaA + "'"
        '    End If
        'End If

        ''consulta += " ) as cons ORDER BY cons.otco_idotcoppel, cons.otco_idpedido, cons.NombreTienda"
        'consulta += " ) as cons"

        'consulta += " union " + Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")

        ''consulta = Replace(consulta, "[" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios", "[192.168.2.5].Yuyinerp19.Framework.Usuarios")

        ' Return objPersistencia.EjecutaConsulta(consulta)

        Dim obj = New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@OT"
            parametro.Value = idOrdenTrabajo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tiendas"
            parametro.Value = idDistribucion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedido"
            parametro.Value = idPedido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaEntregaDe
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaEntregaA
            listaParametros.Add(parametro)

            Return obj.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_Confirmacion_Consultar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DetalleParesAConfirmar(ByVal idOtCoppel As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        Dim consultaHistorico As String = ""
        consulta = "SELECT null as renglon, *,(cons.total - cons.otcod_paresConfirmados) as faltante, '' as estatus_Renglon,cons.otcod_paresConfirmados as confirmados_real FROM "
        consulta += " (SELECT ot.otcod_idOtCoppelDetalles ,otcod_idotCoppel,ot.otcod_idProducto, v.IdModelo,v.IdPiel,v.Color,ot.otcod_idTalla as idTalla, v.Descripcion,ot.otcod_talla,ot.otcod_pares as total,ot.otcod_paresConfirmados "
        consulta += " FROM Almacen.OtCoppelDetalles ot INNER JOIN vEstilos v on ot.otcod_idProducto=v.IdCodigo"
        consulta += " WHERE otcod_idotCoppel= " + idOtCoppel.ToString + "  ) cons "

        consultaHistorico = Replace(consulta, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")

        consulta += " union " + consultaHistorico

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ValidarParLeido(ByVal codigo As String, ByVal atado As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "codigo"
        parametro.Value = codigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsAtado"
        parametro.Value = atado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_ValidaParLeidoOTCoppel", listaParametros)
    End Function

    Public Sub InsertarDetalleParesOT(ByVal DetallePares As Entidades.ValidacionPar, ByVal IdOtCoppelDetalles As Int32, ByVal idOtCoppel As Integer,
                                      ByVal paresConfirmado As Integer, ByVal Usuario As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@otdp_tipoPar"
        parametro.Value = DetallePares.PTipoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idPar"
        parametro.Value = DetallePares.PIdPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idOtCoppelDetalle"
        parametro.Value = IdOtCoppelDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idDocena"
        parametro.Value = DetallePares.PIdDocena
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_status"
        parametro.Value = DetallePares.PEstatusPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idPartida"
        parametro.Value = DetallePares.PIdPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idPedido"
        parametro.Value = DetallePares.PIdPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idCliente"
        parametro.Value = DetallePares.PIdCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idNave"
        parametro.Value = DetallePares.PIdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@otdp_idLote"
        parametro.Value = DetallePares.PIdLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idotCoppel"
        parametro.Value = idOtCoppel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresconfirmado"
        parametro.Value = paresConfirmado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioCreo"
        parametro.Value = Usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = DetallePares.PAño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@entradaAlmacen"
        parametro.Value = DetallePares.PEntradaAlmacen
        listaParametros.Add(parametro)


        objPersistencia.EjecutarSentenciaSP("Almacen.SP_Inserta_DetallesPares_OTCoppel", listaParametros)
    End Sub

    Public Sub ActualizarDetallesOTCoppel(ByVal IdotCoppelDetalles As Int32, ByVal ParesConfirmados As Int32, ByVal usuario As String, ByVal estatusDetalle As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@otdp_idOtCoppelDetalle"
        parametro.Value = IdotCoppelDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresConfirmado"
        parametro.Value = ParesConfirmados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusDetalle"
        parametro.Value = estatusDetalle
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Almacen.SP_Actualizar_Detalles_OTCoppel", listaParametros)

    End Sub

    Public Sub ActualizarOTCoppel(ByVal IdOtCoppel As Int32, ByVal EstatusOt As String, ByVal paresConfirmados As Int32, ByVal usuario As String, ByVal paresCorrectos As Int32, ByVal paresExternos As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idOtCoppel"
        parametro.Value = IdOtCoppel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusOt"
        parametro.Value = EstatusOt
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresConfirmados"
        parametro.Value = paresConfirmados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresCorrectos"
        parametro.Value = paresCorrectos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresExternos"
        parametro.Value = paresExternos
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Almacen.SP_Actualizar_OTCoppel", listaParametros)

    End Sub

    Public Sub ActualizarEstatusOTCoppel(ByVal IdOtCoppel As Int32, ByVal ParesConfirmados As Int32, ByVal IdotCoppelDetalles As Int32, ByVal EstatusOt As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idOtCoppel"
        parametro.Value = IdOtCoppel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresConfirmado"
        parametro.Value = ParesConfirmados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idotCoppelDetalles"
        parametro.Value = IdotCoppelDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatusOt"
        parametro.Value = EstatusOt
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("Almacen.SP_Actualiza_Estatus_Pares_OTCoppel", listaParametros)

    End Sub

    Public Function VerDetallesGridConfirmacion(ByVal idOtCoppel As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim consultaHistorico As String = ""
        consulta = "SELECT null as #, otdp_tipoPar as TipoPar, otdp.otdp_idDocena as Atado, otdp.otdp_idPar Par ,v.Descripcion, '' as renglon, otd.otcod_talla Calce,"
        consulta += " otdp.otdp_idLote Lote, n.Nave as Nave, otdp.otdp_Año as Año, otdp.otdp_fechaEntradaAlmacen as EntradaAlmacen, otdp.otdp_idNave as idNave, otdp.otdp_fechaconfirmacion as confirmacion, usr.user_username as confirmo, "
        consulta += " otdp.otdp_idPartida as partida,otdp.otdp_idPedido as pedido,otdp.otdp_idCliente as cliente,otdp.otdp_status as estatusPar, "
        consulta += " otdp.otdp_idProducto as idproducto, "
        consulta += " otd.otcod_idTalla as idtbltalla, ot.otco_idpedido as idPedidoConfirmacion, ot.otco_idotcoppel as idOrdenTrabajoConfirmacion, d.nombre as TiendaConfirmacion"
        consulta += " FROM Almacen.OtCoppelDetallesPares otdp INNER JOIN Almacen.OtCoppelDetalles otd"
        consulta += " on otd.otcod_idOtCoppelDetalles=otdp.otdp_idOtCoppelDetalle INNER JOIN vEstilos v ON otd.otcod_idProducto=v.IdCodigo"
        consulta += " INNER JOIN dbo.Naves n on otdp.otdp_idNave = n.IdNave "
        consulta += " INNER JOIN Almacen.OTCoppel ot on otd.otcod_idotCoppel = ot.otco_idotcoppel "
        consulta += " INNER JOIN Distribuciones d on ot.otco_idtienda=d.IdDistribucion "
        consulta += " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios usr on usr.user_usuarioid = otdp.otdp_colaboradorconfirmoid"
        consulta += " WHERE otd.otcod_idotCoppel= " + idOtCoppel.ToString + " AND otdp.otdp_idPar is NOT NULL"

        consultaHistorico = Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetallesPares ", "Almacen.OtCoppelDetallesPares_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")

        consulta += " union " + consultaHistorico

        ' consulta = Replace(consulta, "[" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].Framework.Usuarios", "[192.168.2.5].Yuyinerp19.Framework.Usuarios")

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function imprimirOrdenTrabajoCoppel(ByVal idOtCoppel As String, ByVal tipoConsulta As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        Dim consultaHistorico As String = ""
        If tipoConsulta = 1 Then 'detalles
            consulta = "SELECT otd.otcod_idotCoppel,otd.otcod_idProducto, v.IdModelo, otd.otcod_idTalla as idTalla, "
            consulta += " v.Descripcion,otd.otcod_talla,otd.otcod_pares as total"
            ' consulta += ", ISNULL(stuff((select TOP 3 ','  +  CAST(ubpa_estibaid as varchar(10) )  from Almacen.vOTCoppel_ParesDisponibles where ubpa_producto = otd.otcod_idProducto AND ubpa_talla = otd.otcod_talla AND Pedido = ot.otco_idpedido ORDER by Pares for xml path('')),1,1,''),'') AS estiba"
            consulta += ", ISNULL(stuff((select ','+ CAST(BloqueFila as varchar(10)) from almacen.vOTCoppel_ParesDisponibles where ubpa_producto = otd.otcod_idProducto AND ubpa_talla = otd.otcod_talla AND Pedido = ot.otco_idpedido  GROUP BY BloqueFila, pares ORDER by Pares for xml path('')),1,1,''),'') 	AS estiba"
            consulta += " FROM Almacen.OtCoppelDetalles otd  INNER JOIN vEstilos v on otd.otcod_idProducto=v.IdCodigo"
            consulta += " INNER JOIN Almacen.OTCoppel ot on ot.otco_idotcoppel=otd.otcod_idotCoppel "
            consulta += " INNER JOIN Distribuciones d on d.IdDistribucion=ot.otco_idtienda "
            consulta += " INNER JOIN Pedidos p on p.IdPedido=ot.otco_idpedido "
            consulta += " WHERE otcod_idotCoppel in (" + idOtCoppel + ")"

            consultaHistorico = Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")
            consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")

            consulta += " union " + consultaHistorico
        Else 'ordenes de trabajo
            consulta = "SELECT ot.otco_idotCoppel,ot.otco_idpedido,p.Orden, d.nombre, ot.otco_fechaentrega, ot.otco_totalPares"
            consulta += " FROM Almacen.OTCoppel ot INNER JOIN Distribuciones d on d.IdDistribucion=ot.otco_idtienda "
            consulta += " INNER JOIN Pedidos p on p.IdPedido=ot.otco_idpedido "
            consulta += " WHERE otco_idotCoppel in (" + idOtCoppel + ")"

            consultaHistorico = Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")

            consulta += " union " + consultaHistorico
        End If
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub ActualizarQuitarPar(ByVal idPar As String, ByVal idotDetalles As Int32, ByVal idotCoppel As Int32,
                                   ByVal estatus As String, ByVal paresConf As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idOtCoppelDetalles"
        parametro.Value = idotDetalles
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idOtCoppel"
        parametro.Value = idotCoppel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idPar"
        parametro.Value = idPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresconfirmados"
        parametro.Value = paresConf
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Almacen.SP_ActualizarQuitarPar", listaParametros)

    End Sub

    Public Function CargarSalidasCoppel(ByVal estatus As String, ByVal idPedido As Int32, ByVal idTienda As Int32, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal filtro As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim consultaHistorico As String = ""
        consulta = "SELECT" +
        " 0 seleccion," +
        " * FROM (SELECT" +
        " ot.otco_idotcoppel 'Id OT'," +
        " ot.otco_idpedido Pedido," +
        " pd.pedidoSay PedidoSAY, " +
        " ot.otco_idtienda," +
        " d.nombre AS Tienda," +
        " ot.otco_totalpares 'Pares'," +
        " ot.otco_paresconfirmados AS pares_Confirmados, ISNULL(ot.otco_parescorrectos,0) AS pares_Correctos, ISNULL(ot.otco_paresexternos,0) AS pares_Externos,"
        '" (SELECT" +
        '" SUM(otcod_paresConfirmados)" +
        '" FROM Almacen.OtCoppelDetalles" +
        '" WHERE otcod_idOtCoppel = ot.otco_idotcoppel" +
        '" GROUP BY otcod_idOtCoppel)" +
        '" AS pares_Confirmados," +
        consulta += " ISNULL((SELECT" +
        " COUNT(dp.otdp_idPar)" +
        " FROM Almacen.OtCoppelDetallesPares dp" +
        " INNER JOIN Almacen.OtCoppelDetalles d" +
        " ON d.otcod_idOtCoppelDetalles = dp.otdp_idOtCoppelDetalle" +
        " WHERE d.otcod_idotCoppel = ot.otco_idotcoppel" +
        " AND dp.otdp_status = 2), 0) AS pares_salida," +
        " ot.otco_estatus AS estatus," +
        " ot.otco_fechaentrega Entrega," +
        "ot.otco_fechaconfirmacion 'Confirmación'," +
        " ot.otco_fechaSalida As Salida," +
        " u.user_username Usuario" +
        " FROM Almacen.OTCoppel ot" +
        " INNER JOIN Distribuciones d" +
        " ON ot.otco_idtienda = d.IdDistribucion " +
        " LEFT JOIN Pedidos pd on ot.otco_idpedido = pd.IdPedido " +
        " LEFT JOIN [" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Framework].[Usuarios] u " +
         " ON u.user_usuarioid=ot.otco_usuariosalidaid"

        If estatus = "" Then
            consulta += " where OT.otco_estatus in ('C','E') "
        ElseIf estatus.ToString.Equals("SIN SALIDA") Then
            consulta += " where OT.otco_estatus = 'C'"
        ElseIf estatus.ToString.Equals("CON SALIDA") Then
            consulta += " where OT.otco_estatus = 'E'"
        End If

        If idPedido <> 0 Then
            consulta += " and ot.otco_idpedido= " + idPedido.ToString
        End If
        If idTienda <> 0 Then
            consulta += " AND ot.otco_idtienda=" + idTienda.ToString
        End If
        consulta += " )cons "
        If filtro = True Then
            consulta += "  WHERE cons.Salida BETWEEN '" + fechaInicio + " 00:01' AND '" + fechaFin + " 23:59' "

        End If


        consultaHistorico = Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetallesPares ", "Almacen.OtCoppelDetallesPares_Hist ")

        consulta += " union " + consultaHistorico
        consulta += " ORDER BY cons.Tienda"

        'consulta = Replace(consulta, "[" + operacionesSAY.Servidor + "].[" + operacionesSAY.NombreDB + "].[Framework].[Usuarios]", "[192.168.2.5].Yuyinerp19.Framework.Usuarios")

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ParesADarSalida(ByVal idOtCoppel As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        Dim consultaHistorico As String = ""
        consulta = "SELECT dp.otdp_idPar FROM Almacen.OtCoppelDetallesPares dp inner join Almacen.OtCoppelDetalles otd"
        consulta += " ON otd.otcod_idOtCoppelDetalles=dp.otdp_idOtCoppelDetalle"
        consulta += " WHERE otcod_idotCoppel=" + idOtCoppel.ToString + " and otdp_idPar is not null"

        consultaHistorico = Replace(consulta, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetallesPares ", "Almacen.OtCoppelDetallesPares_Hist ")

        consulta += " union " + consultaHistorico

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub ActualizaEstatusParesSalidaOT(ByVal idOtCoppel As Int32)
        Dim objPersistencias As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idOTCoppel"
        parametro.Value = idOtCoppel
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@fechaSalida"
        'listaParametros.Add(parametro)

        objPersistencias.EjecutarConsultaSP("Almacen.SP_Actualiza_Estatus_Pares_SalidaOT", listaParametros)
    End Sub

    Public Sub ActualizaEstatusParesTmpdocenapares(ByVal idPar As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idPar"
        parametro.Value = idPar
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Almacen.SP_Actuliza_Salida_Pares_tmpdocenasPares", listaParametros)
    End Sub

    Public Sub ActualizaEstatusParesTmpdocenasparesCoppel(ByVal pares As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "update tmpdocenaspares_Coppel set status=2,asignado=0, idtblmovimiento=0 where ID_Par in ( " + pares + ")"
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    Public Function mostrarDetallesSalida(ByVal idsotcoppel As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        Dim consultaHistorico As String = ""
        consulta = "SELECT" +
        " otdp.otdp_idPedido 'Pedido'," +
        " oc.otco_fechaentrega 'Entrega'," +
        " ISNULL(d.nombre,'') Tienda," +
        " otd.otcod_idotCoppel 'OT'," +
        " otdp.otdp_tipoPar 'St'," +
        " otdp.otdp_idDocena AS Atado," +
        " otdp.otdp_idPar Par," +
        " v.IdModelo Modelo," +
        " v.Descripcion 'Descripción'," +
        " t.Talla AS Corrida," +
        " otd.otcod_talla Talla," +
        " otdp.otdp_idLote Lote," +
        " n.Nave AS Nave," +
        " otdp.otdp_año AS Año," +
        " oc.otco_fechaSalida AS Salida" +
        " FROM Almacen.OtCoppelDetallesPares otdp" +
        " INNER JOIN Almacen.OtCoppelDetalles otd" +
        " ON otd.otcod_idOtCoppelDetalles = otdp.otdp_idOtCoppelDetalle" +
        " INNER JOIN vEstilos v" +
        " ON otd.otcod_idProducto = v.IdCodigo" +
        " INNER JOIN Almacen.OTCoppel oc" +
        " ON oc.otco_idotcoppel=otd.otcod_idotCoppel" +
        " INNER JOIN Tallas t" +
        " ON t.IdTalla = otd.otcod_idTalla" +
        " LEFT JOIN  Distribuciones d" +
        " ON d.IdDistribucion=oc.otco_idtienda" +
        " LEFT JOIN Naves n" +
        " ON n.IdNave=otdp.otdp_idNave" +
        " WHERE otd.otcod_idotCoppel IN (" & idsotcoppel & ")" +
        " AND otdp.otdp_idPar IS NOT NULL"

        consultaHistorico = Replace(consulta, "Almacen.OTCoppel ", "Almacen.OTCoppel_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetalles ", "Almacen.OtCoppelDetalles_Hist ")
        consultaHistorico = Replace(consultaHistorico, "Almacen.OtCoppelDetallesPares ", "Almacen.OtCoppelDetallesPares_Hist ")

        consulta += " union " + consultaHistorico

        consulta += " order by Pedido,Tienda,OT"

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Sub InsertarIncidencias(ByVal idOtCoppel As Integer, ByVal Usuario As String, ByVal paresLeidos As Integer, ByVal paresIncorrectos As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro = New SqlParameter
        parametro.ParameterName = "@idotCoppel"
        parametro.Value = idOtCoppel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioIncidencia"
        parametro.Value = Usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresLeidos"
        parametro.Value = paresLeidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresIncorrectos"
        parametro.Value = paresIncorrectos
        listaParametros.Add(parametro)


        objPersistencia.EjecutarSentenciaSP("Almacen.SP_Inserta_Incidencias_OTCoppel", listaParametros)
    End Sub

    Public Sub ActualizaEstatusParesTmpdocenaparesCoppel(ByVal idPar As String, ByVal idOTCoppel As Int32)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idOTCoppel"
        parametro.Value = idOTCoppel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idPar"
        parametro.Value = idPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idusuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Almacen.SP_Actualiza_Salida_Pares_tmpdocenasParesCoppel", listaParametros)
    End Sub

    Public Function geTiendaCoppel() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "select  distinct IdDistribucion AS 'idtblTienda',distribucion AS 'Nombre_Tienda' from vCadenasDistribucion where IdCadena=947 order by distribucion asc"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function validaAtadoOTCoppel(ByVal NumeroAtado As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "codigo"
        parametro.Value = NumeroAtado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_ValidaAtadoLeidoOTCoppel", listaParametros)
    End Function

    Public Function CancelarConfirmacionOT(ordenTrabajo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@OT"
            parametro.Value = ordenTrabajo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_CancelarConfirmacionOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LimpiarOtCoppel(ByVal idOTCOppel As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim paranetro As New SqlParameter
        Dim listaParametros = New List(Of SqlParameter)

        Try
            paranetro.ParameterName = "@idOTCoppel"
            paranetro.Value = idOTCOppel
            listaParametros.Add(paranetro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_MesaDeAyuda_Coppel_LimpiarParesConfirmadosOT]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ActualizarParesEntregadosPedido(ByVal PedidoSICYID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim paranetro As New SqlParameter
        Dim listaParametros = New List(Of SqlParameter)

        Try
            paranetro.ParameterName = "@pedidoSICY"
            paranetro.Value = PedidoSICYID
            listaParametros.Add(paranetro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ActualizarParesEntregadosPedidos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReplicarEstatusSAY_SICY(ByVal PedidoSICYID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim paranetro As New SqlParameter
        Dim listaParametros = New List(Of SqlParameter)

        Try
            paranetro.ParameterName = "@PedidoSICY"
            paranetro.Value = PedidoSICYID
            listaParametros.Add(paranetro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ReplicarEstatusPedidos_SAY_SICY]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
