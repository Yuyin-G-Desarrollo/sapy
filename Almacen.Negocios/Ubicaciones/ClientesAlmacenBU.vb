Imports Almacen.Datos

Public Class ClientesAlmacenBU
    Public Function GenerarUbicacion()
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim resultadoOk As Boolean = 0
        resultadoOk = objbu.GenerarUbicacion()
        Return resultadoOk
    End Function

    Public Function ConvertirParesAtado()
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim resultadoOk As Boolean = 0
        resultadoOk = objbu.ConvertirParesAtado()
        Return resultadoOk
    End Function

    Public Function LimpiarPlataforma() As Boolean
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim resultadoOk As Boolean = 0
        resultadoOk = objbu.LimpiarPlataforma()
        Return resultadoOk
    End Function

    Public Function CargarClientes() As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.CargarClientes
        Return tabla
    End Function

    Public Function ListadoParametroUbicacion(tipo_busqueda As Integer, id_parametros As String) As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.ListadoParametroUbicacion(tipo_busqueda, id_parametros)
        Return tabla
    End Function

    Public Function LocalizarProducto(Filtros As Entidades.LocalizacionProducto)
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.LocalizarProducto(Filtros)
        Return tabla
    End Function

    'YA ESTA LISTO no necesita filtros
    Public Function ListadoUbicacion_SinFiltros(nave As String, almacen As String, mostrar_todo As Boolean,
                                          filtroFechas As Boolean, fechaInicio As String, fechaTermino As String, Con_Sin_Ubicacion As Integer,
                                          filtroFechaEntregaP As Boolean, fechaInicioEntregaP As String, fechaTerminoEntregaP As String) As DataTable

        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable

        Dim consultaPar As String = String.Empty
        Dim consultaAtado As String = String.Empty
        Dim consultaErrores As String = String.Empty


        consultaPar += " SELECT " +
                       "   'P' AS 'P/A'" +
                        " , CASE" +
                       "        WHEN ubpa_statuscodigo = '1' THEN CAST('ALMACÉN' AS varchar)" +
                       " 	    ELSE (" +
                       " 		    	CASE" +
                       " 			    WHEN ubpa_statuscodigo = '2' THEN CAST('EXTERNO' AS VARCHAR)" +
                       "     			ELSE (" +
                       " 		    	        CASE" +
                       " 			            WHEN ubpa_statuscodigo = '0' THEN CAST('EN PRODUCCION' AS VARCHAR)" +
                       "     			        ELSE (" +
                       " 		    	                CASE" +
                       " 			                    WHEN ubpa_statuscodigo = 'R' THEN CAST('ALMACÉN' AS VARCHAR)" +
                       "                                ELSE CAST('PRUEBAS DESTRUCTIVAS' AS VARCHAR)" +
                       "                        END) " +
                       " 	    	        END) " +
                       " 	    	 END) " +
                       "   END AS 'Proceso'" +
    " , CAST (ubpa_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ubpa_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ubpa_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ubpa_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ubpa_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ubpa_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (ubpa_validado AS varchar(2)) AS 'V'" +
                       " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                       " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
                       " , codr_nombrecorto AS 'Operador'" +
                       " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                       " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                       " , bahi_bloque AS 'Bloque'" +
                       " , bahi_nivel AS 'Nivel'" +
                       " , bahi_posicion AS 'Posicion'" +
                       " , bahi_color AS 'Color'" +
                       " , ubpa_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                       " , ubpa_codigopar AS 'Par'" +
                       " , ubpa_codigoatado AS 'Atado'" +
                       " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                       " , ubpa_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                       " , ubpa_modelo AS 'Modelo'" +
                       " , ubpa_descripcionproducto AS 'Producto'" +
                       " , ubpa_corrida AS 'Corrida'" +
                       " , CAST(ubpa_talla AS VARCHAR) AS 'Talla'" +
    " , ubpa_pedidoorigen AS 'Pedido Origen'" +
                           " , ubpa_pedido AS 'Pedido'" +
    " , ubpa_referenciaclientepedido as 'OrdenCte'" +
    " , ISNULL(CONVERT(varchar(20), ubpa_fechaentregapedido, 103), '') AS 'FEntrega'" +
                       " , CAST(ubpa_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                       " , CAST(ubpa_apartado AS VARCHAR) AS 'Apartado'" +
                       " , ubpa_clientenombre AS 'Cliente'" +
                       " , ubpa_agenteinicial AS 'Agte'" +
                       " , ubpa_lote AS 'Lote'" +
                      " , ubpa_aniolote AS 'Año'" +
                           " , ubpa_nombrenave AS 'Nave'" +
    " , ubpa_lotecliente AS 'Lote Cliente'" +
                           " , ubpa_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
                        " , isnull(otcod_idotCoppel,'') AS OT" +
                       " , ubpa_origenubicacion AS 'Origen'" +
                       " , ubpa_fechamodificacion AS 'Fecha Ubicación'" +
                       " , ubpa_fechasalidanave AS 'Salida de Nave'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubpa_estibaanterior AS 'Estiba Ant.'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubpa_origenanterior AS 'Origen Ant.'" +
                       " FROM Almacen.UbicacionPares"
        If Con_Sin_Ubicacion = 1 Then
            consultaPar += " JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaPar += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
            End If
        End If
        consultaPar += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                        " LEFT JOIN Pedidos ON IdPedido = ubpa_pedido" +
                        " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubpa_colaboradormodificaid"
        consultaPar += " LEFT JOIN Almacen.OtCoppelDetallesPares   on ubpa_codigopar=otdp_idPar" +
        " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaPar += " WHERE (ubpa_activo = 1 AND ubpa_estibaid IS NULL) "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaPar += " WHERE ((ubpa_activo = 1 AND ubpa_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ubpa_activo = 1))"
            Else
                consultaPar += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubpa_activo = 1) "
            End If
        End If
        If filtroFechas Then
            consultaPar += " AND ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            consultaPar += " AND ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
        End If


        consultaErrores += " SELECT " +
                          "   'E' AS 'P/A'" +
                          " , CASE" +
                          "	    WHEN ersp_statuscodigo = 1 THEN CAST('ALMACÉN' AS varchar)" +
                          "		ELSE (CASE" +
                          "			  WHEN ersp_statuscodigo = 2 AND ersp_idcadena = 947 THEN CAST('EXTERNO (Coppel)' AS varchar)" +
                          "			  ELSE (CASE" +
                          "					WHEN ersp_statuscodigo = 2 THEN CAST('EXTERNO' AS varchar)" +
                          "					ELSE (CASE" +
                          "						  WHEN ersp_statuscodigo = 0 THEN CAST('EN PRODUCCION' AS varchar)" +
                          "						  ELSE CAST('PRUEBAS DESTRUCTIVAS' AS varchar)" +
                          "						  END)" +
                          "		            END)" +
                          "	          END)" +
                          "     END AS 'Proceso'" +
    " , CAST (ersp_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ersp_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ersp_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ersp_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ersp_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ersp_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (0 AS varchar(2)) AS 'V'" +
                          " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                          " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                          " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                          " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                          " , bahi_bloque AS 'Bloque'" +
                          " , bahi_nivel AS 'Nivel'" +
                          " , bahi_posicion AS 'Posicion'" +
                          " , bahi_color AS 'Color'" +
                          " , ersp_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                          " , ersp_codigopar AS 'Par'" +
                          " , ersp_codigoatado AS 'Atado'" +
                          " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                          " , ersp_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                          " , ersp_modelo AS 'Modelo'" +
                          " , ersp_descripcionproducto AS 'Producto'" +
                          " , ersp_corrida AS 'Corrida'" +
                          " , CAST(ersp_talla AS VARCHAR) AS 'Talla'" +
    " , ersp_pedidoorigen AS 'Pedido Origen'" +
                           " , ersp_pedido AS 'Pedido'" +
    " , ersp_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ersp_fechaentregapedido, 103),'') as FEntrega" +
                          " , CAST(ersp_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                          " , CAST(ersp_apartado AS VARCHAR) AS 'Apartado'" +
                          " , ersp_clientenombre AS 'Cliente'" +
                          " , ersp_agenteinicial AS 'Agte'" +
                          " , ersp_lote AS 'Lote'" +
    " , ersp_aniolote AS 'Año'" +
                           " , ersp_nombrenave AS 'Nave'" +
    " , ersp_lotecliente AS 'Lote Cliente'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
                          " , 0 AS OT" +
                         " , ersp_origenubicacion AS 'Origen'" +
                          " , ersp_fechamodificacion AS 'Fecha Ubicación'" +
                          " , ersp_fechasalidanave AS 'Salida de Nave'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ersp_estibaanterior AS 'Estiba Ant.'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ersp_origenanterior AS 'Origen Ant.'" +
                      " FROM Almacen.ErroresStatusPar"
        If Con_Sin_Ubicacion = 1 Then
            consultaErrores += " JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaErrores += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
            End If
        End If
        consultaErrores += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                      " LEFT JOIN Pedidos ON IdPedido = ersp_pedido" +
                      " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ersp_colaboradormodificaid"
        If Con_Sin_Ubicacion = 2 Then
            consultaErrores += " WHERE (ersp_activo = 1 AND ersp_estibaid IS NULL) "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaErrores += " WHERE ((ersp_activo = 1 AND ersp_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ersp_activo = 1))"
            Else
                consultaErrores += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ersp_activo = 1) "
            End If
        End If
        If filtroFechas Then
            consultaErrores += " AND ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            consultaErrores += " AND ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
        End If

        consultaAtado += " SELECT " +
                      "   'A' AS 'P/A'" +
                      " , 'ALMACÉN'   AS 'Status'" +
    " , '--' AS 'D'" +
    " , '--' AS 'A'" +
    " , '--' AS 'C'" +
    " , '--' AS 'B'" +
    " , '--' AS 'R'" +
    " , '--' AS 'P'" +
    " , '--' AS 'V'" +
                      " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                      " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                      " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                      " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                      " , ubat_fechamodificacion As 'Fecha Ubicación(hr)'" +
                      " , '   --  ' AS 'Par'" +
                      " , ubat_codigoatado AS 'Atado'" +
                      " , CAST(ubat_pares AS VARCHAR) AS 'Prs'" +
                      " , ubat_tiponumeracion AS 'Tipo'" +
                      " , isnull(ubat_tipoatado,'') AS 'Tipo Atado' " +
                      " , isnull(ubat_numeroatado,'') AS 'NumAt' " +
                      " , case when ubat_stock = 1 Then 'SI' else 'NO' end AS 'AtStock' " +
                      " , ubat_modelo AS 'Modelo'" +
                      " , ubat_descripcionproducto AS 'Producto'" +
                      " , ubat_corrida AS 'Corrida'" +
                      " , '   --  ' AS 'Talla'" +
    " , ubat_pedidoorigen AS 'Pedido Origen'" +
                         " , ubat_pedido AS 'Pedido'" +
    " , ubat_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ubat_fechaentregapedido, 103),'') as 'FEntrega'" +
                      " , '   --  '  AS 'Tienda'" +
                      " , '   --  '  AS 'Apartado'" +
                      " , ubat_clientenombre AS 'Cliente'" +
                      " , ubat_agenteinicial AS 'Agte'" +
                      " , ubat_lote AS 'Lote'" +
    " , ubat_aniolote AS 'Año'" +
                         " , ubat_nombrenave AS 'Nave'" +
    " , ubat_lotecliente AS 'Lote Cliente'" +
                         " , ubat_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
                      " ,isnull(otcod_idotCoppel,'') AS OT" +
                      " , ubat_origenubicacion AS 'Origen'" +
                      " , ubat_fechamodificacion AS 'Fecha Ubicación'" +
                      " , ubat_fechasalidanave AS 'Salida de Nave'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubat_estibaanterior AS 'Estiba Ant.'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubat_origenanterior AS 'Origen Ant.'" +
                      " FROM Almacen.UbicacionAtados"
        If Con_Sin_Ubicacion = 1 Then
            consultaAtado += " JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaAtado += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid AND esti_activo = 1"
            End If
        End If
        consultaAtado += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                      " LEFT JOIN Pedidos ON (IdPedido = ubat_pedido)" +
                      " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubat_colaboradormodificaid"
        consultaAtado += " left join Almacen.ContenidoAtados on ubat_codigoatado=coat_codigoatado" +
                    " left join Almacen.OtCoppelDetallesPares on coat_codigopar=otdp_idPar" +
                    " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaAtado += " WHERE (ubat_activo = 1 AND ubat_estibaid IS NULL) "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaAtado += " WHERE ((ubat_activo = 1 AND ubat_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ubat_activo = 1))"
            Else
                consultaAtado += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubat_activo = 1) "
            End If
        End If
        If filtroFechas Then
            consultaAtado += " AND ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            consultaAtado += " AND ubat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
        End If

        'consultaAtado += " AND esti_activo = 1 AND bahi_activo = 1"


        tabla = objbu.ListadoUbicacionAtado(mostrar_todo, consultaPar, consultaErrores, consultaAtado, String.Empty, False)

        Return tabla

    End Function

    'YA ESTA LISTO este si
    Public Function ListadoUbicacion_UbPar_UbAtado(nave As String, almacen As String, mostrar_todo As Boolean,
                                              lAtado As String, lLote As String, AnioLote As String, lNave As String, lPedidoOrigen As String, lOrdenCliente As String,
                                              lBahia As String, lDescripcionBahia As String, lColaborador As String,
                                              lAgente As String, lProducto As String, lCorrida As String, lLoteCliente As String, lFiltroEstatus As String,
                                              bY_O As Boolean,
                                              filtroFechas As Boolean, fechaInicio As String, fechaTermino As String, Con_Sin_Ubicacion As Integer,
                                              filtroFechaEntregaP As Boolean, fechaInicioEntregaP As String, fechaTerminoEntregaP As String) As DataTable

        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        Dim primerCondicion As Boolean = True

        Dim consultaPar As String = String.Empty
        Dim consultaAtado As String = String.Empty
        Dim consultaErrores As String = String.Empty

        consultaPar += " SELECT " +
                       "   'P' AS 'P/A'" +
                        " , CASE" +
                       "        WHEN ubpa_statuscodigo = '1' THEN CAST('ALMACÉN' AS varchar)" +
                       " 	    ELSE (" +
                       " 		    	CASE" +
                       " 			    WHEN ubpa_statuscodigo = '2' THEN CAST('EXTERNO' AS VARCHAR)" +
                       "     			ELSE (" +
                       " 		    	        CASE" +
                       " 			            WHEN ubpa_statuscodigo = '0' THEN CAST('EN PRODUCCION' AS VARCHAR)" +
                       "     			        ELSE (" +
                       " 		    	                CASE" +
                       " 			                    WHEN ubpa_statuscodigo = 'R' THEN CAST('ALMACÉN' AS VARCHAR)" +
                       "                                ELSE CAST('PRUEBAS DESTRUCTIVAS' AS VARCHAR)" +
                       "                        END) " +
                       " 	    	        END) " +
                       " 	    	 END) " +
                       "   END AS 'Proceso'" +
    " , CAST (ubpa_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ubpa_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ubpa_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ubpa_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ubpa_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ubpa_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (ubpa_validado AS varchar(2)) AS 'V'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                           " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                           " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                           " , ubpa_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                           " , ubpa_codigopar AS 'Par'" +
                           " , ubpa_codigoatado AS 'Atado'" +
                           " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                           " , ubpa_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                           " , ubpa_modelo AS 'Modelo'" +
                           " , ubpa_descripcionproducto AS 'Producto'" +
                           " , ubpa_corrida AS 'Corrida'" +
                           " , CAST(ubpa_talla AS VARCHAR) AS 'Talla'" +
    " , ubpa_pedidoorigen AS 'Pedido Origen'" +
                           " , ubpa_pedido AS 'Pedido'" +
    " , ubpa_referenciaclientepedido as 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ubpa_fechaentregapedido, 103), '') as 'FEntrega'" +
                           " , CAST(ubpa_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                           " , CAST(ubpa_apartado AS VARCHAR) AS 'Apartado'" +
                           " , ubpa_clientenombre AS 'Cliente'" +
                           " , ubpa_agenteinicial AS 'Agte'" +
                           " , ubpa_lote AS 'Lote'" +
    " , ubpa_aniolote AS 'Año'" +
                           " , ubpa_nombrenave AS 'Nave'" +
    " , ubpa_lotecliente AS 'Lote Cliente'" +
                           " , ubpa_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
     " , isnull(otcod_idotCoppel,'') AS OT" +
                           " , ubpa_origenubicacion AS 'Origen'" +
                           " , ubpa_fechamodificacion AS 'Fecha Ubicación'" +
                           " , ubpa_fechasalidanave AS 'Salida de Nave'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubpa_estibaanterior AS 'Estiba Ant.'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubpa_origenanterior AS 'Origen Ant.'" +
                           " FROM Almacen.UbicacionPares"
        If Con_Sin_Ubicacion = 1 Then
            consultaPar += " JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaPar += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
            End If
        End If
        consultaPar += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                        " LEFT JOIN Pedidos ON IdPedido = ubpa_pedido" +
                        " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubpa_colaboradormodificaid"
        consultaPar += " left join Almacen.OtCoppelDetallesPares   on ubpa_codigopar=otdp_idPar" +
        " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaPar += " WHERE (ubpa_activo = 1 AND ubpa_estibaid IS NULL) AND ( "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaPar += " WHERE ((ubpa_activo = 1 AND ubpa_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ubpa_activo = 1)) AND ( "
            Else
                consultaPar += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubpa_activo = 1) AND ( "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaPar += " ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaPar += " OR ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaPar += " ubpa_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_codigoatado IN (" + lAtado + ")"
                Else
                    consultaPar += " OR ubpa_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaPar += " ubpa_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_lote IN (" + lLote + ")"
                Else
                    consultaPar += " OR ubpa_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaPar += " ubpa_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_aniolote IN (" + AnioLote + ")"
                Else
                    consultaPar += " OR ubpa_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaPar += " ubpa_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_nave IN (" + lNave + ")"
                Else
                    consultaPar += " OR ubpa_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaPar += " ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaPar += " OR ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaPar += " ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaPar += " OR ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaPar += " ubpa_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaPar += " OR ubpa_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaPar += " bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaPar += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaPar += " bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaPar += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaPar += " Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaPar += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaPar += " ubpa_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idagente IN (" + lAgente + ")"
                Else
                    consultaPar += " OR ubpa_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaPar += " ubpa_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_producto IN (" + lProducto + ")"
                Else
                    consultaPar += " OR ubpa_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaPar += " ubpa_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaPar += " OR ubpa_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaPar += " ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaPar += " OR ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaPar += " OR ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        consultaPar += ") "

        primerCondicion = True

        consultaErrores += " SELECT " +
                           "   'E' AS 'P/A'" +
                           " , CASE" +
                           "	    WHEN ersp_statuscodigo = 1 THEN CAST('ALMACÉN' AS varchar)" +
                           "		ELSE (CASE" +
                           "			  WHEN ersp_statuscodigo = 2 AND ersp_idcadena = 947 THEN CAST('EXTERNO (Coppel)' AS varchar)" +
                           "			  ELSE (CASE" +
                           "					WHEN ersp_statuscodigo = 2 THEN CAST('EXTERNO' AS varchar)" +
                           "					ELSE (CASE" +
                           "						  WHEN ersp_statuscodigo = 0 THEN CAST('EN PRODUCCION' AS varchar)" +
                           "						  ELSE CAST('PRUEBAS DESTRUCTIVAS' AS varchar)" +
                           "						  END)" +
                           "		            END)" +
                           "	          END)" +
                           "     END AS 'Proceso'" +
    " , CAST (ersp_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ersp_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ersp_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ersp_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ersp_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ersp_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (0 AS varchar(2)) AS 'V'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                           " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                           " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                           " , ersp_codigopar AS 'Par'" +
                           " , ersp_codigoatado AS 'Atado'" +
                           " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                           " , ersp_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                           " , ersp_modelo AS 'Modelo'" +
                           " , ersp_descripcionproducto AS 'Producto'" +
                           " , ersp_corrida AS 'Corrida'" +
                           " , CAST(ersp_talla AS VARCHAR) AS 'Talla'" +
    " , ersp_pedidoorigen AS 'Pedido Origen'" +
                           " , ersp_pedido AS 'Pedido'" +
    " , ersp_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ersp_fechaentregapedido, 103), '') as FEntrega" +
                           " , CAST(ersp_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                           " , CAST(ersp_apartado AS VARCHAR) AS 'Apartado'" +
                           " , ersp_clientenombre AS 'Cliente'" +
                           " , ersp_agenteinicial AS 'Agte'" +
                           " , ersp_lote AS 'Lote'" +
    " , ersp_aniolote AS 'Año'" +
                           " , ersp_nombrenave AS 'Nave'" +
    " , ersp_lotecliente AS 'Lote Cliente'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    " , 0 AS OT" +
                           " , ersp_origenubicacion AS 'Origen'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ersp_estibaanterior AS 'Estiba Ant.'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ersp_origenanterior AS 'Origen Ant.'" +
                           " FROM Almacen.ErroresStatusPar"
        If Con_Sin_Ubicacion = 1 Then
            consultaErrores += " JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaErrores += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
            End If
        End If
        consultaErrores += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                      " LEFT JOIN Pedidos ON IdPedido = ersp_pedido" +
                      " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ersp_colaboradormodificaid"
        If Con_Sin_Ubicacion = 2 Then
            consultaErrores += " WHERE (ersp_activo = 1 AND ersp_estibaid IS NULL) AND ( "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaErrores += " WHERE ((ersp_activo = 1 AND ersp_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ersp_activo = 1)) AND ( "
            Else
                consultaErrores += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ersp_activo = 1) AND ( "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaErrores += " ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaErrores += " OR ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaErrores += " ersp_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_codigoatado IN (" + lAtado + ")"
                Else
                    consultaErrores += " OR ersp_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaErrores += " ersp_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_lote IN (" + lLote + ")"
                Else
                    consultaErrores += " OR ersp_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaErrores += " ersp_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_aniolote IN (" + AnioLote + ")"
                Else
                    consultaErrores += " OR ersp_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaErrores += " ersp_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_nave IN (" + lNave + ")"
                Else
                    consultaErrores += " OR ersp_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaErrores += " ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaErrores += " OR ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaErrores += " ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaErrores += " OR ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaErrores += " ersp_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaErrores += " OR ersp_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaErrores += " bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaErrores += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaErrores += " bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaErrores += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaErrores += " Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaErrores += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaErrores += " ersp_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idagente IN (" + lAgente + ")"
                Else
                    consultaErrores += " OR ersp_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaErrores += " ersp_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_producto IN (" + lProducto + ")"
                Else
                    consultaErrores += " OR ersp_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaErrores += " ersp_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaErrores += " OR ersp_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaErrores += " ersp_idtblmovimiento IN (" + lFiltroEstatus + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idtblmovimiento IN (" + lFiltroEstatus + ")"
                Else
                    consultaErrores += " OR ersp_idtblmovimiento IN (" + lFiltroEstatus + ")"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaErrores += " OR ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        'If Not primerCondicion Then
        consultaErrores += ") "
        'End If

        primerCondicion = True

        consultaAtado += " SELECT " +
                         "   'A' AS 'P/A'" +
                         " , 'ALMACÉN'   AS 'Status'" +
    " , '--' AS 'D'" +
    " , '--' AS 'A'" +
    " , '--' AS 'C'" +
    " , '--' AS 'B'" +
    " , '--' AS 'R'" +
    " , '--' AS 'P'" +
    " , '--' AS 'V'" +
                         " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                         " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                         " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                         " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                         " , bahi_bloque AS 'Bloque'" +
                         " , bahi_nivel AS 'Nivel'" +
                         " , bahi_posicion AS 'Posicion'" +
                         " , bahi_color AS 'Color'" +
                         " , ubat_fechamodificacion As 'Fecha Ubicación(hr)'" +
                         " , '   --  ' AS 'Par'" +
                         " , ubat_codigoatado AS 'Atado'" +
                         " , CAST(ubat_pares AS VARCHAR) AS 'Prs'" +
                         " , ubat_tiponumeracion AS 'Tipo'" +
                      " , isnull(ubat_tipoatado,'') AS 'Tipo Atado' " +
                      " , isnull(ubat_numeroatado,'') AS 'NumAt' " +
                      " , case when ubat_stock = 1 Then 'SI' else 'NO' end AS 'AtStock' " +
                         " , ubat_modelo AS 'Modelo'" +
                         " , ubat_descripcionproducto AS 'Producto'" +
                         " , ubat_corrida AS 'Corrida'" +
                         " , '   --  ' AS 'Talla'" +
    " , ubat_pedidoorigen AS 'Pedido Origen'" +
                         " , ubat_pedido AS 'Pedido'" +
    " , ubat_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ubat_fechaentregapedido, 103), '') as 'FEntrega'" +
                         " , '   --  '  AS 'Tienda'" +
                         " , '   --  '  AS 'Apartado'" +
                         " , ubat_clientenombre AS 'Cliente'" +
                         " , ubat_agenteinicial AS 'Agte'" +
                         " , ubat_lote AS 'Lote'" +
    " , ubat_aniolote AS 'Año'" +
                         " , ubat_nombrenave AS 'Nave'" +
    " , ubat_lotecliente AS 'Lote Cliente'" +
                         " , ubat_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    " , isnull(otcod_idotCoppel,'') AS OT" +
                         " , ubat_origenubicacion AS 'Origen'" +
                         " , ubat_fechamodificacion AS 'Fecha Ubicación'" +
                         " , ubat_fechasalidanave AS 'Salida de Nave'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubat_estibaanterior AS 'Estiba Ant.'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubat_origenanterior AS 'Origen Ant.'" +
                         " FROM Almacen.UbicacionAtados"
        If Con_Sin_Ubicacion = 1 Then
            consultaAtado += " JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaAtado += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid AND esti_activo = 1"
            End If
        End If
        consultaAtado += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                      " LEFT JOIN Pedidos ON (IdPedido = ubat_pedido)" +
                      " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubat_colaboradormodificaid"
        consultaAtado += " left join Almacen.ContenidoAtados on ubat_codigoatado=coat_codigoatado" +
                    " left join Almacen.OtCoppelDetallesPares on coat_codigopar=otdp_idPar" +
                    " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaAtado += " WHERE (ubat_activo = 1 AND ubat_estibaid IS NULL) AND ( "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaAtado += " WHERE ((ubat_activo = 1 AND ubat_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ubat_activo = 1)) AND ( "
            Else
                consultaAtado += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubat_activo = 1) AND ( "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaAtado += " ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaAtado += " OR ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaAtado += " ubat_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_codigoatado IN (" + lAtado + ")"
                Else
                    consultaAtado += " OR ubat_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaAtado += " ubat_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_lote IN (" + lLote + ")"
                Else
                    consultaAtado += " OR ubat_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaAtado += " ubat_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_aniolote IN (" + AnioLote + ")"
                Else
                    consultaAtado += " OR ubat_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If


        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaAtado += " ubat_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_nave IN (" + lNave + ")"
                Else
                    consultaAtado += " OR ubat_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaAtado += " ubat_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaAtado += " OR ubat_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaAtado += " ubat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaAtado += " OR ubat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaAtado += " ubat_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaAtado += " OR ubat_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaAtado += " bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaAtado += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaAtado += " bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaAtado += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaAtado += " Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaAtado += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaAtado += " ubat_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_idagente IN (" + lAgente + ")"
                Else
                    consultaAtado += " OR ubat_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaAtado += " ubat_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_producto IN (" + lProducto + ")"
                Else
                    consultaAtado += " OR ubat_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaAtado += " ubat_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaAtado += " OR ubat_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaAtado += " AND ( ubat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaAtado += " AND ubat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaAtado += " OR ubat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        consultaAtado += ") "

        tabla = objbu.ListadoUbicacionAtado(mostrar_todo, consultaPar, consultaErrores, consultaAtado, String.Empty, False)

        Return tabla
    End Function

    'YA ESTA LISTO este si
    Public Function ListadoUbicacion_Completo(nave As String, almacen As String, mostrar_todo As Boolean,
                                                   lPar As String, lAtado As String, lLote As String, AnioLote As String, lNave As String, lPedidoOrigen As String, lOrdenCliente As String,
                                                   lCliente As String, lTienda As String, lPedido As String, lApartado As String,
                                                   lBahia As String, lDescripcionBahia As String, lColaborador As String, lAgente As String,
                                                   lProducto As String, lCorrida As String, lTalla As String, lLoteCliente As String, lFiltroEstatus As String,
                                                   bY_O As Boolean,
                                                   filtroFechas As Boolean, fechaInicio As String, fechaTermino As String, Con_Sin_Ubicacion As Integer,
                                                   filtroFechaEntregaP As Boolean, fechaInicioEntregaP As String, fechaTerminoEntregaP As String) As DataTable

        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        Dim primerCondicion As Boolean = True

        Dim consultaPar As String = String.Empty
        Dim consultaErrores As String = String.Empty
        Dim consultaContenidoAtado As String = String.Empty


        'If Not String.IsNullOrEmpty(lPar) Then
        consultaPar += " SELECT " +
                       "   'P' AS 'P/A'" +
                        " , CASE" +
                       "        WHEN ubpa_statuscodigo = '1' THEN CAST('ALMACÉN' AS varchar)" +
                       " 	    ELSE (" +
                       " 		    	CASE" +
                       " 			    WHEN ubpa_statuscodigo = '2' THEN CAST('EXTERNO' AS VARCHAR)" +
                       "     			ELSE (" +
                       " 		    	        CASE" +
                       " 			            WHEN ubpa_statuscodigo = '0' THEN CAST('EN PRODUCCION' AS VARCHAR)" +
                       "     			        ELSE (" +
                       " 		    	                CASE" +
                       " 			                    WHEN ubpa_statuscodigo = 'R' THEN CAST('ALMACÉN' AS VARCHAR)" +
                       "                                ELSE CAST('PRUEBAS DESTRUCTIVAS' AS VARCHAR)" +
                       "                        END) " +
                       " 	    	        END) " +
                       " 	    	 END) " +
                       "   END AS 'Proceso'" +
    " , CAST (ubpa_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ubpa_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ubpa_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ubpa_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ubpa_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ubpa_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (ubpa_validado AS varchar(2)) AS 'V'" +
                       " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                       " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                       " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                       " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                       " , bahi_bloque AS 'Bloque'" +
                       " , bahi_nivel AS 'Nivel'" +
                       " , bahi_posicion AS 'Posicion'" +
                       " , bahi_color AS 'Color'" +
                       " , ubpa_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                       " , ubpa_codigopar AS 'Par'" +
                       " , ubpa_codigoatado AS 'Atado'" +
                       " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                       " , ubpa_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                       " , ubpa_modelo AS 'Modelo'" +
                       " , ubpa_descripcionproducto AS 'Producto'" +
                       " , ubpa_corrida AS 'Corrida'" +
                       " , CAST(ubpa_talla AS VARCHAR) AS 'Talla'" +
    " , ubpa_pedidoorigen AS 'Pedido Origen'" +
                           " , ubpa_pedido AS 'Pedido'" +
    " , ubpa_referenciaclientepedido as 'OrdenCte'" +
    " , ISNULL(CONVERT(varchar(20), ubpa_fechaentregapedido, 103), '') AS 'FEntrega'" +
                       " , CAST(ubpa_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                       " , CAST(ubpa_apartado AS VARCHAR) AS 'Apartado'" +
                       " , ubpa_clientenombre AS 'Cliente'" +
                       " , ubpa_agenteinicial AS 'Agte'" +
                       " , ubpa_lote AS 'Lote'" +
    " , ubpa_aniolote AS 'Año'" +
                           " , ubpa_nombrenave AS 'Nave'" +
    " , ubpa_lotecliente AS 'Lote Cliente'" +
                           " , ubpa_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    " ,isnull(otcod_idotCoppel,'') AS OT" +
                       " , ubpa_origenubicacion AS 'Origen'" +
                       " , ubpa_fechamodificacion AS 'Fecha Ubicación'" +
                       " , ubpa_fechasalidanave AS 'Salida de Nave'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubpa_estibaanterior AS 'Estiba Ant.'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubpa_origenanterior AS 'Origen Ant.'" +
                       " FROM Almacen.UbicacionPares"
        If Con_Sin_Ubicacion = 1 Then
            consultaPar += " JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaPar += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
            End If
        End If
        consultaPar += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                        " LEFT JOIN Pedidos ON IdPedido = ubpa_pedido" +
                        " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubpa_colaboradormodificaid"
        consultaPar += " LEFT JOIN Almacen.OtCoppelDetallesPares   on ubpa_codigopar=otdp_idPar" +
        " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaPar += " WHERE (ubpa_activo = 1 AND ubpa_estibaid IS NULL) AND ( "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaPar += " WHERE ((ubpa_activo = 1 AND ubpa_estibaid IS NULL) OR (bahi_nave =  " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ubpa_activo = 1)) AND ( "
            Else
                consultaPar += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubpa_activo = 1) AND ( "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaPar += " ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaPar += " OR ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPar) Then
            If primerCondicion Then
                consultaPar += " ubpa_codigopar IN (" + lPar + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_codigopar IN (" + lPar + ")"
                Else
                    consultaPar += " OR ubpa_codigopar IN (" + lPar + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaPar += " ubpa_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_codigoatado IN (" + lAtado + ")"
                Else
                    consultaPar += " OR ubpa_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaPar += " ubpa_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_lote IN (" + lLote + ")"
                Else
                    consultaPar += " OR ubpa_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaPar += " ubpa_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_aniolote IN (" + AnioLote + ")"
                Else
                    consultaPar += " OR ubpa_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaPar += " ubpa_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_nave IN (" + lNave + ")"
                Else
                    consultaPar += " OR ubpa_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaPar += " ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaPar += " OR ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaPar += " ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaPar += " OR ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaPar += " ubpa_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaPar += " OR ubpa_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCliente) Then
            If primerCondicion Then
                consultaPar += " ubpa_idcadena IN (" + lCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idcadena IN (" + lCliente + ")"
                Else
                    consultaPar += " OR ubpa_idcadena IN (" + lCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTienda) Then
            If primerCondicion Then
                consultaPar += " ubpa_idtienda IN (" + lTienda + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idtienda IN (" + lTienda + ")"
                Else
                    consultaPar += " OR ubpa_idtienda IN (" + lTienda + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPedido) Then
            If primerCondicion Then
                consultaPar += " ubpa_pedido IN (" + lPedido + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_pedido IN (" + lPedido + ")"
                Else
                    consultaPar += " OR ubpa_pedido IN (" + lPedido + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lApartado) Then
            If primerCondicion Then
                consultaPar += " ubpa_apartado IN (" + lApartado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_apartado IN (" + lApartado + ")"
                Else
                    consultaPar += " OR ubpa_apartado IN (" + lApartado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaPar += " bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaPar += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaPar += " bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaPar += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaPar += " Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaPar += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaPar += " ubpa_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idagente IN (" + lAgente + ")"
                Else
                    consultaPar += " OR ubpa_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaPar += " ubpa_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_producto IN (" + lProducto + ")"
                Else
                    consultaPar += " OR ubpa_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaPar += " ubpa_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaPar += " OR ubpa_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTalla) Then
            If primerCondicion Then
                consultaPar += " ubpa_talla IN (" + lTalla + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_talla IN (" + lTalla + ")"
                Else
                    consultaPar += " OR ubpa_talla IN (" + lTalla + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaPar += " ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaPar += " OR ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaPar += " OR ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        consultaPar += ") "

        primerCondicion = True

        consultaErrores += " SELECT " +
                           "   'E' AS 'P/A'" +
                           " , CASE" +
                           "	    WHEN ersp_statuscodigo = 1 THEN CAST('ALMACÉN' AS varchar)" +
                           "		ELSE (CASE" +
                           "			  WHEN ersp_statuscodigo = 2 AND ersp_idcadena = 947 THEN CAST('EXTERNO (Coppel)' AS varchar)" +
                           "			  ELSE (CASE" +
                           "					WHEN ersp_statuscodigo = 2 THEN CAST('EXTERNO' AS varchar)" +
                           "					ELSE (CASE" +
                           "						  WHEN ersp_statuscodigo = 0 THEN CAST('EN PRODUCCION' AS varchar)" +
                           "						  ELSE CAST('PRUEBAS DESTRUCTIVAS' AS varchar)" +
                           "						  END)" +
                           "		            END)" +
                           "	          END)" +
                           "     END AS 'Proceso'" +
    " , CAST (ersp_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ersp_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ersp_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ersp_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ersp_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ersp_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (0 AS varchar(2)) AS 'V'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                           " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                           " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                           " , ersp_codigopar AS 'Par'" +
                           " , ersp_codigoatado AS 'Atado'" +
                           " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                           " , ersp_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                           " , ersp_modelo AS 'Modelo'" +
                           " , ersp_descripcionproducto AS 'Producto'" +
                           " , ersp_corrida AS 'Corrida'" +
                           " , CAST(ersp_talla AS VARCHAR) AS 'Talla'" +
    " , ersp_pedidoorigen AS 'Pedido Origen'" +
                           " , ersp_pedido AS 'Pedido'" +
    " , ersp_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ersp_fechaentregapedido, 103),'') as FEntrega" +
                           " , CAST(ersp_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                           " , CAST(ersp_apartado AS VARCHAR) AS 'Apartado'" +
                           " , ersp_clientenombre AS 'Cliente'" +
                           " , ersp_agenteinicial AS 'Agte'" +
                           " , ersp_lote AS 'Lote'" +
    " , ersp_aniolote AS 'Año'" +
                           " , ersp_nombrenave AS 'Nave'" +
    " , ersp_lotecliente AS 'Lote Cliente'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    " , 0 AS OT" +
                           " , ersp_origenubicacion AS 'Origen'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ersp_estibaanterior AS 'Estiba Ant.'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ersp_origenanterior AS 'Origen Ant.'" +
                           " FROM Almacen.ErroresStatusPar"
        If Con_Sin_Ubicacion = 1 Then
            consultaErrores += " JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaErrores += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
            End If
        End If
        consultaErrores += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                      " LEFT JOIN Pedidos ON IdPedido = ersp_pedido" +
                      " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ersp_colaboradormodificaid"
        If Con_Sin_Ubicacion = 2 Then
            consultaErrores += " WHERE (ersp_activo = 1 AND ersp_estibaid IS NULL) AND ( "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaErrores += " WHERE ((ersp_activo = 1 AND ersp_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ersp_activo = 1)) AND ( "
            Else
                consultaErrores += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ersp_activo = 1)  AND ( "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaErrores += " ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaErrores += " OR ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPar) Then
            If primerCondicion Then
                consultaErrores += " ersp_codigopar IN (" + lPar + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_codigopar IN (" + lPar + ")"
                Else
                    consultaErrores += " OR ersp_codigopar IN (" + lPar + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaErrores += " ersp_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_codigoatado IN (" + lAtado + ")"
                Else
                    consultaErrores += " OR ersp_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaErrores += " ersp_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_lote IN (" + lLote + ")"
                Else
                    consultaErrores += " OR ersp_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaErrores += " ersp_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_aniolote IN (" + AnioLote + ")"
                Else
                    consultaErrores += " OR ersp_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaErrores += " ersp_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_nave IN (" + lNave + ")"
                Else
                    consultaErrores += " OR ersp_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaErrores += " ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaErrores += " OR ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaErrores += " ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaErrores += " OR ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaErrores += " ersp_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaErrores += " OR ersp_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCliente) Then
            If primerCondicion Then
                consultaErrores += " ersp_idcadena IN (" + lCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idcadena IN (" + lCliente + ")"
                Else
                    consultaErrores += " OR ersp_idcadena IN (" + lCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTienda) Then
            If primerCondicion Then
                consultaErrores += " ersp_idtienda IN (" + lTienda + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idtienda IN (" + lTienda + ")"
                Else
                    consultaErrores += " OR ersp_idtienda IN (" + lTienda + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPedido) Then
            If primerCondicion Then
                consultaErrores += " ersp_pedido IN (" + lPedido + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_pedido IN (" + lPedido + ")"
                Else
                    consultaErrores += " OR ersp_pedido IN (" + lPedido + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lApartado) Then
            If primerCondicion Then
                consultaErrores += " ersp_apartado IN (" + lApartado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_apartado IN (" + lApartado + ")"
                Else
                    consultaErrores += " OR ersp_apartado IN (" + lApartado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaErrores += " bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaErrores += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaErrores += " bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaErrores += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaErrores += " Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaErrores += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaErrores += " ersp_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idagente IN (" + lAgente + ")"
                Else
                    consultaErrores += " OR ersp_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaErrores += " ersp_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_producto IN (" + lProducto + ")"
                Else
                    consultaErrores += " OR ersp_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaErrores += " ersp_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaErrores += " OR ersp_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTalla) Then
            If primerCondicion Then
                consultaErrores += " ersp_talla IN (" + lTalla + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_talla IN (" + lTalla + ")"
                Else
                    consultaErrores += " OR ersp_talla IN (" + lTalla + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaErrores += " ersp_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaErrores += " OR ersp_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaErrores += " OR ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        If Not primerCondicion Then
            consultaErrores += ") "
        End If

        primerCondicion = True

        consultaContenidoAtado += " SELECT " +
                                  "   'A' AS 'P/A'" +
                                  " , 'ALMACÉN'  AS 'Status'" +
    " , '--' AS 'D'" +
    " , '--' AS 'A'" +
    " , '--' AS 'C'" +
    " , '--' AS 'B'" +
    " , '--' AS 'R'" +
    " , '--' AS 'P'" +
    " , '--' AS 'V'" +
                                  " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                                  " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                                  " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                                  " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                                  " , bahi_bloque AS 'Bloque'" +
                                  " , bahi_nivel AS 'Nivel'" +
                                  " , bahi_posicion AS 'Posicion'" +
                                  " , bahi_color AS 'Color'" +
                                  " , ubat_fechamodificacion As 'Fecha Ubicación(hr)'" +
                                  " , coat_codigopar AS 'Par'" +
                                  " , ubat_codigoatado AS 'Atado'" +
                                  " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                                  " , ubat_tiponumeracion AS 'Tipo'" +
                      " , isnull(ubat_tipoatado,'') AS 'Tipo Atado' " +
                      " , isnull(ubat_numeroatado,'') AS 'NumAt' " +
                      " , case when ubat_stock = 1 Then 'SI' else 'NO' end AS 'AtStock' " +
                                  " , coat_modelo AS 'Modelo'" +
                                  " , coat_descripcionproducto AS 'Producto'" +
                                  " , coat_corrida AS 'Corrida'" +
                                  " , coat_talla AS 'Talla'" +
    " , ubat_pedidoorigen AS 'Pedido Origen'" +
                         " , ubat_pedido AS 'Pedido'" +
    " , ubat_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), coat_fechaentregapedido, 103),'') as 'FEntrega'" +
                                  " , coat_tiendadescripcion AS 'Tienda'" +
                                  " , coat_idapartado  AS 'Apartado'" +
                                  " , coat_clientenombre AS 'Cliente'" +
                                  " , coat_agenteinicial AS 'Agte'" +
                                  " , ubat_lote AS 'Lote'" +
    " , ubat_aniolote AS 'Año'" +
                         " , ubat_nombrenave AS 'Nave'" +
    " , ubat_lotecliente AS 'Lote Cliente'" +
                         " , ubat_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    ", isnull(otcod_idotCoppel,'') AS OT" +
                                  " , coat_origenubicacion AS 'Origen'" +
                                  " , coat_fechamodificacion AS 'Fecha Ubicación'" +
                                  " , coat_fechasalidanave AS 'Salida de Nave'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubat_estibaanterior AS 'Estiba Ant.'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubat_origenanterior AS 'Origen Ant.'" +
                                  " FROM Almacen.ContenidoAtados" +
                                  " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = coat_codigoatado"
        If Con_Sin_Ubicacion = 1 Then
            consultaContenidoAtado += " JOIN Almacen.Estiba ON esti_estibaid = coat_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaContenidoAtado += " LEFT JOIN Almacen.Estiba ON esti_estibaid = coat_estibaid AND esti_activo = 1"
            End If
        End If
        consultaContenidoAtado += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                                  " LEFT JOIN Pedidos ON IdPedido = ubat_pedido" +
                                  " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubat_colaboradormodificaid"
        consultaContenidoAtado += " left join Almacen.OtCoppelDetallesPares on coat_codigopar=otdp_idPar" +
                                  " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaContenidoAtado += " WHERE (coat_activo = 1 AND coat_estibaid IS NULL) AND ( "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaContenidoAtado += " WHERE ((coat_activo = 1 AND coat_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND coat_activo = 1)) AND ( "
            Else
                consultaContenidoAtado += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND coat_activo = 1) AND ( "
            End If
        End If

        If filtroFechas Then
            If primerCondicion Then
                consultaContenidoAtado += " ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaContenidoAtado += " OR ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPar) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_codigopar IN (" + lPar + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_codigopar IN (" + lPar + ")"
                Else
                    consultaContenidoAtado += " OR coat_codigopar IN (" + lPar + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_codigoatado IN (" + lAtado + ")"
                Else
                    consultaContenidoAtado += " OR coat_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaContenidoAtado += " ubat_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_lote IN (" + lLote + ")"
                Else
                    consultaContenidoAtado += " OR ubat_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaContenidoAtado += " ubat_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_aniolote IN (" + AnioLote + ")"
                Else
                    consultaContenidoAtado += " OR ubat_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If


        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_nave IN (" + lNave + ")"
                Else
                    consultaContenidoAtado += " OR coat_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaContenidoAtado += " OR coat_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaContenidoAtado += " OR coat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaContenidoAtado += " OR coat_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCliente) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_idcadena IN (" + lCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idcadena IN (" + lCliente + ")"
                Else
                    consultaContenidoAtado += " OR coat_idcadena IN (" + lCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTienda) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_idtienda IN (" + lTienda + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idtienda IN (" + lTienda + ")"
                Else
                    consultaContenidoAtado += " OR coat_idtienda IN (" + lTienda + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPedido) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_idpedido IN (" + lPedido + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idpedido IN (" + lPedido + ")"
                Else
                    consultaContenidoAtado += " OR coat_idpedido IN (" + lPedido + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lApartado) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_idapartado IN (" + lApartado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idapartado IN (" + lApartado + ")"
                Else
                    consultaContenidoAtado += " OR coat_idapartado IN (" + lApartado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaContenidoAtado += " bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaContenidoAtado += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaContenidoAtado += " bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaContenidoAtado += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaContenidoAtado += " Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaContenidoAtado += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idagente IN (" + lAgente + ")"
                Else
                    consultaContenidoAtado += " OR coat_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_producto IN (" + lProducto + ")"
                Else
                    consultaContenidoAtado += " OR coat_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaContenidoAtado += " ubat_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaContenidoAtado += " OR ubat_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTalla) Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_talla IN (" + lTalla + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_talla IN (" + lTalla + ")"
                Else
                    consultaContenidoAtado += " OR coat_talla IN (" + lTalla + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaContenidoAtado += " coat_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaContenidoAtado += " OR coat_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaContenidoAtado += " OR coat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        consultaContenidoAtado += ") "

        tabla = objbu.ListadoUbicacionAtado(mostrar_todo, consultaPar, consultaErrores, String.Empty, consultaContenidoAtado, False)

        Return tabla

    End Function

    'YA ESTA LISTO no necesita filtros
    Public Function ListadoUbicacion_SinFiltros_CargaArchivo(nave As String, almacen As String, mostrar_todo As Boolean,
                                          filtroFechas As Boolean, fechaInicio As String, fechaTermino As String, lColaborador As String) As DataTable

        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable

        Dim consultaPar As String = String.Empty
        Dim consultaAtado As String = String.Empty
        Dim consultaErrores As String = String.Empty


        consultaPar += " SELECT " +
                        "   'P' AS 'P/A'" +
                        " , CASE" +
                       "        WHEN ubpa_statuscodigo = '1' THEN CAST('ALMACÉN' AS varchar)" +
                       " 	    ELSE (" +
                       " 		    	CASE" +
                       " 			    WHEN ubpa_statuscodigo = '2' THEN CAST('EXTERNO' AS VARCHAR)" +
                       "     			ELSE (" +
                       " 		    	        CASE" +
                       " 			            WHEN ubpa_statuscodigo = '0' THEN CAST('EN PRODUCCION' AS VARCHAR)" +
                       "     			        ELSE (" +
                       " 		    	                CASE" +
                       " 			                    WHEN ubpa_statuscodigo = 'R' THEN CAST('ALMACÉN' AS VARCHAR)" +
                       "                                ELSE CAST('PRUEBAS DESTRUCTIVAS' AS VARCHAR)" +
                       "                        END) " +
                       " 	    	        END) " +
                       " 	    	 END) " +
                       "   END AS 'Proceso'" +
    " , CAST (ubpa_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ubpa_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ubpa_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ubpa_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ubpa_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ubpa_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (ubpa_validado AS varchar(2)) AS 'V'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
     " , codr_nombrecorto AS 'Operador'" +
                           " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                           " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                           " , ubpa_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                           " , ubpa_codigopar AS 'Par'" +
                           " , ubpa_codigoatado AS 'Atado'" +
                           " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                           " , ubpa_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                           " , ubpa_modelo AS 'Modelo'" +
                           " , ubpa_descripcionproducto AS 'Producto'" +
                           " , ubpa_corrida AS 'Corrida'" +
                           " , CAST(ubpa_talla AS VARCHAR) AS 'Talla'" +
    " , ubpa_pedidoorigen AS 'Pedido Origen'" +
                           " , ubpa_pedido AS 'Pedido'" +
    " , ubpa_referenciaclientepedido as 'OrdenCte'" +
    " , ISNULL(CONVERT(varchar(20), ubpa_fechaentregapedido, 103), '') AS 'FEntrega'" +
                           " , CAST(ubpa_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                           " , CAST(ubpa_apartado AS VARCHAR) AS 'Apartado'" +
                           " , ubpa_clientenombre AS 'Cliente'" +
                           " , ubpa_agenteinicial AS 'Agte'" +
                           " , ubpa_lote AS 'Lote'" +
    " , ubpa_aniolote AS 'Año'" +
                           " , ubpa_nombrenave AS 'Nave'" +
    " , ubpa_lotecliente AS 'Lote Cliente'" +
                           " , ubpa_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    ", isnull(otcod_idotCoppel,'') AS OT" +
                           " , ubpa_origenubicacion AS 'Origen'" +
                           " , ubpa_fechamodificacion AS 'Fecha Ubicación'" +
                           " , ubpa_fechasalidanave AS 'Salida de Nave'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubpa_estibaanterior AS 'Estiba Ant.'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubpa_origenanterior AS 'Origen Ant.'" +
                           " FROM Almacen.UbicacionPares" +
                           " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1" +
                           " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                           " LEFT JOIN Pedidos ON IdPedido = ubpa_pedido" +
                           " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubpa_colaboradormodificaid" +
                           " left join Almacen.OtCoppelDetallesPares   on ubpa_codigopar=otdp_idPar" +
                           " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles " +
                           " WHERE bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubpa_activo = 1 AND ubpa_origenubicacion = 'A'" +
                           " AND ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'" +
                           " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"

        consultaErrores += " SELECT " +
                           "   'E' AS 'P/A'" +
                           " , CASE" +
                           "	    WHEN ersp_statuscodigo = 1 THEN CAST('ALMACÉN' AS varchar)" +
                           "		ELSE (CASE" +
                           "			  WHEN ersp_statuscodigo = 2 AND ersp_idcadena = 947 THEN CAST('EXTERNO (Coppel)' AS varchar)" +
                           "			  ELSE (CASE" +
                           "					WHEN ersp_statuscodigo = 2 THEN CAST('EXTERNO' AS varchar)" +
                           "					ELSE (CASE" +
                           "						  WHEN ersp_statuscodigo = 0 THEN CAST('EN PRODUCCION' AS varchar)" +
                           "						  ELSE CAST('PRUEBAS DESTRUCTIVAS' AS varchar)" +
                           "						  END)" +
                           "		            END)" +
                           "	          END)" +
                           "     END AS 'Proceso'" +
    " , CAST (ersp_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ersp_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ersp_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ersp_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ersp_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ersp_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (0 AS varchar(2)) AS 'V'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
" , codr_nombrecorto AS 'Operador'" +
                           " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                           " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                           " , ersp_codigopar AS 'Par'" +
                           " , ersp_codigoatado AS 'Atado'" +
                           " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                           " , ersp_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                           " , ersp_modelo AS 'Modelo'" +
                           " , ersp_descripcionproducto AS 'Producto'" +
                           " , ersp_corrida AS 'Corrida'" +
                           " , CAST(ersp_talla AS VARCHAR) AS 'Talla'" +
    " , ersp_pedidoorigen AS 'Pedido Origen'" +
                           " , ersp_pedido AS 'Pedido'" +
    " , ersp_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ersp_fechaentregapedido, 103),'') as FEntrega" +
                           " , CAST(ersp_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                           " , CAST(ersp_apartado AS VARCHAR) AS 'Apartado'" +
                           " , ersp_clientenombre AS 'Cliente'" +
                           " , ersp_agenteinicial AS 'Agte'" +
                           " , ersp_lote AS 'Lote'" +
    " , ersp_aniolote AS 'Año'" +
                           " , ersp_nombrenave AS 'Nave'" +
    " , ersp_lotecliente AS 'Lote Cliente'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    ", 0 AS OT" +
                           " , ersp_origenubicacion AS 'Origen'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ersp_estibaanterior AS 'Estiba Ant.'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ersp_origenanterior AS 'Origen Ant.'" +
                           " FROM Almacen.ErroresStatusPar" +
                           " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1" +
                           " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                           " LEFT JOIN Pedidos ON IdPedido = ersp_pedido" +
                           " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ersp_colaboradormodificaid" +
                           " WHERE bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ersp_activo = 1 AND ersp_origenubicacion = 'A'" +
                           " AND ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'" +
                           " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"

        consultaAtado += " SELECT " +
                         "   'A' AS 'P/A'" +
                         " , 'ALMACÉN'   AS 'Status'" +
    " , '--' AS 'D'" +
    " , '--' AS 'A'" +
    " , '--' AS 'C'" +
    " , '--' AS 'B'" +
    " , '--' AS 'R'" +
    " , '--' AS 'P'" +
    " , '--' AS 'V'" +
                         " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                         " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                         " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                         " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                         " , bahi_bloque AS 'Bloque'" +
                         " , bahi_nivel AS 'Nivel'" +
                         " , bahi_posicion AS 'Posicion'" +
                         " , bahi_color AS 'Color'" +
                         " , ubat_fechamodificacion As 'Fecha Ubicación (hr)'" +
                         " , '   --  ' AS 'Par'" +
                         " , ubat_codigoatado AS 'Atado'" +
                         " , CAST(ubat_pares AS VARCHAR) AS 'Prs'" +
                         " , ubat_tiponumeracion AS 'Tipo'" +
                      " , isnull(ubat_tipoatado,'') AS 'Tipo Atado' " +
                      " , isnull(ubat_numeroatado,'') AS 'NumAt' " +
                      " , case when ubat_stock = 1 Then 'SI' else 'NO' end AS 'AtStock' " +
                         " , ubat_modelo AS 'Modelo'" +
                         " , ubat_descripcionproducto AS 'Producto'" +
                         " , ubat_corrida AS 'Corrida'" +
                         " , '   --  ' AS 'Talla'" +
    " , ubat_pedidoorigen AS 'Pedido Origen'" +
                         " , ubat_pedido AS 'Pedido'" +
    " , ubat_referenciaclientepedido AS 'OrdenCte'" +
    " , isnull(CONVERT(varchar(20), ubat_fechaentregapedido, 103),'') as 'FEntrega'" +
                         " , '   --  '  AS 'Tienda'" +
                         " , '   --  '  AS 'Apartado'" +
                         " , ubat_clientenombre AS 'Cliente'" +
                         " , ubat_agenteinicial AS 'Agte'" +
                         " , ubat_lote AS 'Lote'" +
    " , ubat_aniolote AS 'Año'" +
                         " , ubat_nombrenave AS 'Nave'" +
    " , ubat_lotecliente AS 'Lote Cliente'" +
                         " , ubat_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    " , isnull(otcod_idotCoppel,'') AS OT" +
                         " , ubat_origenubicacion AS 'Origen'" +
                         " , ubat_fechamodificacion AS 'Fecha Ubicación'" +
                         " , ubat_fechasalidanave AS 'Salida de Nave'" +
    " , ubat_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubat_estibaanterior AS 'Estiba Ant.'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubat_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubat_origenanterior AS 'Origen Ant.'" +
                         " FROM Almacen.UbicacionAtados" +
                         " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid AND esti_activo = 1" +
                         " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                         " LEFT JOIN Pedidos ON (IdPedido = ubat_pedido)" +
                         " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubat_colaboradormodificaid" +
                         " left join Almacen.ContenidoAtados on ubat_codigoatado=coat_codigoatado" +
                         " left join Almacen.OtCoppelDetallesPares on coat_codigopar=otdp_idPar" +
                         " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles " +
                         " WHERE bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubat_activo = 1 AND ubat_origenubicacion = 'A'" +
                         " AND ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'" +
                         " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"

        tabla = objbu.ListadoUbicacionAtado(mostrar_todo, consultaPar, consultaErrores, consultaAtado, String.Empty, False)

        Return tabla
    End Function

    'YA ESTA LISTO este si
    Public Function ListadoUbicacion_Completo_ContenidoAtado(nave As String, almacen As String, mostrar_todo As Boolean,
                                                   lPar As String, lAtado As String, lLote As String, AnioLote As String, lNave As String, lPedidoOrigen As String, lOrdenCliente As String,
                                                   lCliente As String, lTienda As String, lPedido As String, lApartado As String,
                                                   lBahia As String, lDescripcionBahia As String, lColaborador As String, lAgente As String,
                                                   lProducto As String, lCorrida As String, lTalla As String, lLoteCliente As String, lFiltroEstatus As String,
                                                   bY_O As Boolean,
                                                   filtroFechas As Boolean, fechaInicio As String, fechaTermino As String, Con_Sin_Ubicacion As Integer,
                                                   filtroFechaEntregaP As Boolean, fechaInicioEntregaP As String, fechaTerminoEntregaP As String) As DataTable

        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        Dim primerCondicion As Boolean = True

        Dim consultaPar As String = String.Empty
        Dim consultaErrores As String = String.Empty
        Dim consultaContenidoAtado As String = String.Empty

        'If Not String.IsNullOrEmpty(lPar) Then
        consultaPar += " SELECT " +
                       "   'P' AS 'P/A'" +
                        " , CASE" +
                       "        WHEN ubpa_statuscodigo = '1' THEN CAST('ALMACÉN' AS varchar)" +
                       " 	    ELSE (" +
                       " 		    	CASE" +
                       " 			    WHEN ubpa_statuscodigo = '2' THEN CAST('EXTERNO' AS VARCHAR)" +
                       "     			ELSE (" +
                       " 		    	        CASE" +
                       " 			            WHEN ubpa_statuscodigo = '0' THEN CAST('EN PRODUCCION' AS VARCHAR)" +
                       "     			        ELSE (" +
                       " 		    	                CASE" +
                       " 			                    WHEN ubpa_statuscodigo = 'R' THEN CAST('ALMACÉN' AS VARCHAR)" +
                       "                                ELSE CAST('PRUEBAS DESTRUCTIVAS' AS VARCHAR)" +
                       "                        END) " +
                       " 	    	        END) " +
                       " 	    	 END) " +
                       "   END AS 'Proceso'" +
    " , CAST (ubpa_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ubpa_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ubpa_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ubpa_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ubpa_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ubpa_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (ubpa_validado AS varchar(2)) AS 'V'" +
                       " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                       " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
                       " , codr_nombrecorto AS 'Operador'" +
                       " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                       " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                       " , bahi_bloque AS 'Bloque'" +
                       " , bahi_nivel AS 'Nivel'" +
                       " , bahi_posicion AS 'Posicion'" +
                       " , bahi_color AS 'Color'" +
                       " , ubpa_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                       " , ubpa_codigopar AS 'Par'" +
                       " , ubpa_codigoatado AS 'Atado'" +
                       " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                       " , ubpa_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                       " , ubpa_modelo AS 'Modelo'" +
                       " , ubpa_descripcionproducto AS 'Producto'" +
                       " , ubpa_corrida AS 'Corrida'" +
                       " , CAST(ubpa_talla AS VARCHAR) AS 'Talla'" +
    " , ubpa_pedidoorigen AS 'Pedido Origen'" +
                       " , ubpa_pedido AS 'Pedido'" +
    " , ubpa_referenciaclientepedido as 'OrdenCte'" +
    ",isnull(CONVERT(varchar(20), ubpa_fechaentregapedido, 103),'') as 'FEntrega'" +
                       " , CAST(ubpa_tiendadescripcion  AS VARCHAR) AS 'Tienda'" +
                       " , CAST(ubpa_apartado AS VARCHAR) AS 'Apartado'" +
                       " , ubpa_clientenombre AS 'Cliente'" +
                       " , ubpa_agenteinicial AS 'Agte'" +
                       " , ubpa_lote AS 'Lote'" +
    " , ubpa_aniolote AS 'Año'" +
                       " , ubpa_nombrenave AS 'Nave'" +
    " , ubpa_lotecliente AS 'Lote Cliente'" +
                       " , ubpa_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    ",isnull(otcod_idotCoppel,'') AS OT" +
                       " , ubpa_origenubicacion AS 'Origen'" +
                       " , ubpa_fechamodificacion AS 'Fecha Ubicación'" +
                       " , ubpa_fechasalidanave AS 'Salida de Nave'" +
    " , ubpa_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , ubpa_estibaanterior AS 'Estiba Ant.'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , ubpa_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , ubpa_origenanterior AS 'Origen Ant.'" +
                       " FROM Almacen.UbicacionPares"
        If Con_Sin_Ubicacion = 1 Then
            consultaPar += " JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaPar += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid AND esti_activo = 1"
            End If
        End If
        consultaPar += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                        " LEFT JOIN Pedidos ON IdPedido = ubpa_pedido" +
                        " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubpa_colaboradormodificaid"
        consultaPar += " left join Almacen.OtCoppelDetallesPares   on ubpa_codigopar=otdp_idPar" +
        " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaPar += " WHERE (ubpa_activo = 1 AND ubpa_estibaid IS NULL)"
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaPar += " WHERE ((ubpa_activo = 1 AND ubpa_estibaid IS NULL) OR (bahi_nave =  " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ubpa_activo = 1))"
            Else
                consultaPar += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ubpa_activo = 1) "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaPar += " OR ubpa_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPar) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_codigopar IN (" + lPar + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_codigopar IN (" + lPar + ")"
                Else
                    consultaPar += " OR ubpa_codigopar IN (" + lPar + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_codigoatado IN (" + lAtado + ")"
                Else
                    consultaPar += " OR ubpa_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_lote IN (" + lLote + ")"
                Else
                    consultaPar += " OR ubpa_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_aniolote IN (" + AnioLote + ")"
                Else
                    consultaPar += " OR ubpa_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_nave IN (" + lNave + ")"
                Else
                    consultaPar += " OR ubpa_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaPar += " OR ubpa_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaPar += " OR ubpa_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaPar += " OR ubpa_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCliente) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_idcadena IN (" + lCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idcadena IN (" + lCliente + ")"
                Else
                    consultaPar += " OR ubpa_idcadena IN (" + lCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTienda) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_idtienda IN (" + lTienda + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idtienda IN (" + lTienda + ")"
                Else
                    consultaPar += " OR ubpa_idtienda IN (" + lTienda + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPedido) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_pedido IN (" + lPedido + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_pedido IN (" + lPedido + ")"
                Else
                    consultaPar += " OR ubpa_pedido IN (" + lPedido + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lApartado) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_apartado IN (" + lApartado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_apartado IN (" + lApartado + ")"
                Else
                    consultaPar += " OR ubpa_apartado IN (" + lApartado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaPar += " AND ( bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaPar += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaPar += " AND ( bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaPar += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaPar += " AND ( Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaPar += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idagente IN (" + lAgente + ")"
                Else
                    consultaPar += " OR ubpa_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_producto IN (" + lProducto + ")"
                Else
                    consultaPar += " OR ubpa_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaPar += " OR ubpa_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTalla) Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_talla IN (" + lTalla + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_talla IN (" + lTalla + ")"
                Else
                    consultaPar += " OR ubpa_talla IN (" + lTalla + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaPar += " OR ubpa_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaPar += " AND ( ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaPar += " AND ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaPar += " OR ubpa_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        If Not primerCondicion Then
            consultaPar += ") "
        End If

        primerCondicion = True

        consultaErrores += " SELECT " +
                           "   'E' AS 'P/A'" +
                           " , CASE" +
                           "	    WHEN ersp_statuscodigo = 1 THEN CAST('ALMACÉN' AS varchar)" +
                           "		ELSE (CASE" +
                           "			  WHEN ersp_statuscodigo = 2 AND ersp_idcadena = 947 THEN CAST('EXTERNO (Coppel)' AS varchar)" +
                           "			  ELSE (CASE" +
                           "					WHEN ersp_statuscodigo = 2 THEN CAST('EXTERNO' AS varchar)" +
                           "					ELSE (CASE" +
                           "						  WHEN ersp_statuscodigo = 0 THEN CAST('EN PRODUCCION' AS varchar)" +
                           "						  ELSE CAST('PRUEBAS DESTRUCTIVAS' AS varchar)" +
                           "						  END)" +
                           "		            END)" +
                           "	          END)" +
                           "     END AS 'Proceso'" +
    " , CAST (ersp_disponible AS varchar(2)) AS 'D'" +
    " , CAST (ersp_asignado AS varchar(2)) AS 'A'" +
    " , CAST (ersp_calidad AS varchar(2)) AS 'C'" +
    " , CAST (ersp_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (ersp_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (ersp_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (0 AS varchar(2)) AS 'V'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                           " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                           " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                           " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                           " , bahi_bloque AS 'Bloque'" +
                           " , bahi_nivel AS 'Nivel'" +
                           " , bahi_posicion AS 'Posicion'" +
                           " , bahi_color AS 'Color'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación(hr)'" +
                           " , ersp_codigopar AS 'Par'" +
                           " , ersp_codigoatado AS 'Atado'" +
                           " , CAST('1' AS VARCHAR)  AS 'Prs'" +
                           " , ersp_tiponumeracion AS 'Tipo'" +
                       " , 'DESTALLADO' AS 'Tipo Atado'" +
                       " , '' AS 'NumAt'" +
                      " , '' AS 'AtStock' " +
                           " , ersp_modelo AS 'Modelo'" +
                           " , ersp_descripcionproducto AS 'Producto'" +
                           " , ersp_corrida AS 'Corrida'" +
                           " , CAST(ersp_talla AS VARCHAR) AS 'Talla'" +
     " , ersp_pedidoorigen AS 'Pedido Origen'" +
                           " , ersp_pedido AS 'Pedido'" +
    " , ersp_referenciaclientepedido AS 'OrdenCte'" +
    ",isnull(CONVERT(varchar(20), ersp_fechaentregapedido, 103),'') as FEntrega" +
                           " , CAST(ersp_tiendadescripcion AS VARCHAR) AS 'Tienda'" +
                           " , CAST(ersp_apartado AS VARCHAR) AS 'Apartado'" +
                           " , ersp_clientenombre AS 'Cliente'" +
                           " , ersp_agenteinicial AS 'Agte'" +
                           " , ersp_lote AS 'Lote'" +
    " , ersp_aniolote AS 'Año'" +
                           " , ersp_nombrenave AS 'Nave'" +
    " , ersp_lotecliente AS 'Lote Cliente'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , ersp_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    " , 0 AS OT" +
                           " , ersp_origenubicacion AS 'Origen'" +
                           " , ersp_fechamodificacion AS 'Fecha Ubicación'" +
                           " , ersp_fechasalidanave AS 'Salida de Nave'" +
" , ersp_fechaentradaalmacen AS 'Entrada Almacén'" +
" , ersp_estibaanterior AS 'Estiba Ant.'" +
" , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
" , ersp_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
" , ersp_origenanterior AS 'Origen Ant.'" +
                           " FROM Almacen.ErroresStatusPar"
        If Con_Sin_Ubicacion = 1 Then
            consultaErrores += " JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaErrores += " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid AND esti_activo = 1"
            End If
        End If
        consultaErrores += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                      " LEFT JOIN Pedidos ON IdPedido = ersp_pedido" +
                      " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ersp_colaboradormodificaid"
        If Con_Sin_Ubicacion = 2 Then
            consultaErrores += " WHERE (ersp_activo = 1 AND ersp_estibaid IS NULL)  "
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaErrores += " WHERE ((ersp_activo = 1 AND ersp_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND ersp_activo = 1)) "
            Else
                consultaErrores += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND ersp_activo = 1) "
            End If
        End If
        If filtroFechas Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaErrores += " OR ersp_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaErrores += " OR ersp_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPar) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_codigopar IN (" + lPar + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_codigopar IN (" + lPar + ")"
                Else
                    consultaErrores += " OR ersp_codigopar IN (" + lPar + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_codigoatado IN (" + lAtado + ")"
                Else
                    consultaErrores += " OR ersp_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_lote IN (" + lLote + ")"
                Else
                    consultaErrores += " OR ersp_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_aniolote IN (" + AnioLote + ")"
                Else
                    consultaErrores += " OR ersp_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_nave IN (" + lNave + ")"
                Else
                    consultaErrores += " OR ersp_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaErrores += " OR ersp_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaErrores += " OR ersp_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaErrores += " OR ersp_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCliente) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_idcadena IN (" + lCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idcadena IN (" + lCliente + ")"
                Else
                    consultaErrores += " OR ersp_idcadena IN (" + lCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTienda) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_idtienda IN (" + lTienda + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idtienda IN (" + lTienda + ")"
                Else
                    consultaErrores += " OR ersp_idtienda IN (" + lTienda + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPedido) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_pedido IN (" + lPedido + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_pedido IN (" + lPedido + ")"
                Else
                    consultaErrores += " OR ersp_pedido IN (" + lPedido + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lApartado) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_apartado IN (" + lApartado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_apartado IN (" + lApartado + ")"
                Else
                    consultaErrores += " OR ersp_apartado IN (" + lApartado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaErrores += " AND ( bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaErrores += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaErrores += " AND ( bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaErrores += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaErrores += " AND ( Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaErrores += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idagente IN (" + lAgente + ")"
                Else
                    consultaErrores += " OR ersp_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_producto IN (" + lProducto + ")"
                Else
                    consultaErrores += " OR ersp_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaErrores += " OR ersp_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTalla) Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_talla IN (" + lTalla + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_talla IN (" + lTalla + ")"
                Else
                    consultaErrores += " OR ersp_talla IN (" + lTalla + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaErrores += " AND ( ersp_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaErrores += " AND ersp_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaErrores += " OR ersp_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        If Not primerCondicion Then
            consultaErrores += ") "
        End If

        primerCondicion = True

        consultaContenidoAtado += " SELECT " +
                                  "   'A' AS 'P/A'" +
                                  " , 'ALMACÉN'  AS 'Status'" +
    " , CAST (coat_disponible AS varchar(2)) AS 'D'" +
    " , CAST (coat_asignado AS varchar(2)) AS 'A'" +
    " , CAST (coat_calidad AS varchar(2)) AS 'C'" +
    " , CAST (coat_bloqueado AS varchar(2)) AS 'B'" +
    " , CAST (coat_reproceso AS varchar(2)) AS 'R'" +
    " , CAST (coat_proyectado AS varchar(2)) AS 'P'" +
    " , CAST (coat_validado AS varchar(2)) AS 'V'" +
                                  " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS VARCHAR) ELSE esti_estibaid END AS 'Estiba ID'" +
                                  " , CASE WHEN esti_estibaid IS NULL THEN CAST('SIN ESTIBA' AS varchar) ELSE LEFT(esti_estibaid, CHARINDEX('-', esti_estibaid) - 1) END AS 'Estiba'" +
    " , codr_nombrecorto AS 'Operador'" +
                                  " , CASE WHEN bahi_bahiaid IS NULL THEN CAST('SIN BAHÍA' AS VARCHAR) ELSE bahi_bahiaid END AS 'Bahía ID'" +
                                  " , LEFT(bahi_bahiaid, CHARINDEX('-', bahi_bahiaid) - 1) AS 'Bahía'" +
                                  " , bahi_bloque AS 'Bloque'" +
                                  " , bahi_nivel AS 'Nivel'" +
                                  " , bahi_posicion AS 'Posicion'" +
                                  " , bahi_color AS 'Color'" +
                                  " , ubat_fechamodificacion As 'Fecha Ubicación(hr)'" +
                                  " , coat_codigopar AS 'Par'" +
                                  " , ubat_codigoatado AS 'Atado'" +
                                  " , '1' AS 'Prs'" +
                                  " , ubat_tiponumeracion AS 'Tipo'" +
                      " , isnull(ubat_tipoatado,'') AS 'Tipo Atado' " +
                      " , isnull(ubat_numeroatado,'') AS 'NumAt' " +
                      " , case when ubat_stock = 1 Then 'SI' else 'NO' end AS 'AtStock' " +
                                  " , coat_modelo AS 'Modelo'" +
                                  " , coat_descripcionproducto AS 'Producto'" +
                                  " , coat_corrida AS 'Corrida'" +
                                  " , coat_talla AS 'Talla'" +
    " , coat_pedidoorigen AS 'Pedido Origen'" +
                                  " , coat_idpedido AS 'Pedido'" +
    " , coat_referenciaclientepedido AS 'OrdenCte'" +
    ",isnull(CONVERT(varchar(20), coat_fechaentregapedido, 103),'') as 'FEntrega'" +
                                  " , coat_tiendadescripcion AS 'Tienda'" +
                                  " , coat_idapartado  AS 'Apartado'" +
                                  " , coat_clientenombre AS 'Cliente'" +
                                  " , coat_agenteinicial AS 'Agte'" +
                                  " , ubat_lote AS 'Lote'" +
    " , coat_aniolote AS 'Año'" +
                                  " , coat_nombrenave AS 'Nave'" +
    " , coat_lotecliente AS 'Lote Cliente'" +
                                  " , coat_fechasalidanave AS 'Salida de Nave (hr)'" +
    " , coat_fechaentradaalmacen AS 'Entrada Almacén (hr)'" +
    ", isnull(otcod_idotCoppel,'') AS OT" +
                                  " , coat_origenubicacion AS 'Origen'" +
                                  " , coat_fechamodificacion AS 'Fecha Ubicación'" +
                                  " , coat_fechasalidanave AS 'Salida de Nave'" +
    " , coat_fechaentradaalmacen AS 'Entrada Almacén'" +
    " , coat_estibaanterior AS 'Estiba Ant.'" +
    " , coat_fechaubicacionanterior AS 'Fecha Ubicación Ant. (Hr)'" +
    " , coat_fechaubicacionanterior AS 'Fecha Ubicación Ant.'" +
    " , coat_origenanterior AS 'Origen Ant.'" +
                                  " FROM Almacen.ContenidoAtados" +
                                  " JOIN Almacen.UbicacionAtados ON ubat_codigoatado = coat_codigoatado"
        If Con_Sin_Ubicacion = 1 Then
            consultaContenidoAtado += " JOIN Almacen.Estiba ON esti_estibaid = coat_estibaid AND esti_activo = 1"
        Else
            If Con_Sin_Ubicacion = 2 Or Con_Sin_Ubicacion = 3 Then
                consultaContenidoAtado += " LEFT JOIN Almacen.Estiba ON esti_estibaid = coat_estibaid AND esti_activo = 1"
            End If
        End If
        consultaContenidoAtado += " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid AND bahi_activo = 1" +
                                  " LEFT JOIN Pedidos ON IdPedido = ubat_pedido" +
                                  " LEFT JOIN Nomina.Colaborador ON Colaborador.codr_colaboradorid = ubat_colaboradormodificaid"
        consultaContenidoAtado += " left join Almacen.OtCoppelDetallesPares on coat_codigopar=otdp_idPar" +
        " left join Almacen.OtCoppelDetalles on otdp_idOtCoppelDetalle=otcod_idOtCoppelDetalles "
        If Con_Sin_Ubicacion = 2 Then
            consultaContenidoAtado += " WHERE (coat_activo = 1 AND coat_estibaid IS NULL)"
        Else
            If Con_Sin_Ubicacion = 3 Then
                consultaContenidoAtado += " WHERE ((coat_activo = 1 AND coat_estibaid IS NULL) OR (bahi_nave = " & nave.ToString & " AND bahi_almacen = " & almacen.ToString & " AND coat_activo = 1))"
            Else
                consultaContenidoAtado += " WHERE (bahi_nave = " + nave + " AND bahi_almacen = " + almacen + " AND coat_activo = 1)"
            End If
        End If

        If filtroFechas Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                Else
                    consultaContenidoAtado += " OR ubat_fechamodificacion BETWEEN '" + fechaInicio + "' AND '" + fechaTermino + "'"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPar) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_codigopar IN (" + lPar + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_codigopar IN (" + lPar + ")"
                Else
                    consultaContenidoAtado += " OR coat_codigopar IN (" + lPar + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAtado) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_codigoatado IN (" + lAtado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_codigoatado IN (" + lAtado + ")"
                Else
                    consultaContenidoAtado += " OR coat_codigoatado IN (" + lAtado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lLote) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( ubat_lote IN (" + lLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_lote IN (" + lLote + ")"
                Else
                    consultaContenidoAtado += " OR ubat_lote IN (" + lLote + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro aniolote
        If Not String.IsNullOrEmpty(AnioLote) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( ubat_aniolote IN (" + AnioLote + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_aniolote IN (" + AnioLote + ")"
                Else
                    consultaContenidoAtado += " OR ubat_aniolote IN (" + AnioLote + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lNave) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_nave IN (" + lNave + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_nave IN (" + lNave + ")"
                Else
                    consultaContenidoAtado += " OR coat_nave IN (" + lNave + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Pedido Origen
        If Not String.IsNullOrEmpty(lPedidoOrigen) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_pedidoorigen IN (" + lPedidoOrigen + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_pedidoorigen IN (" + lPedidoOrigen + ")"
                Else
                    consultaContenidoAtado += " OR coat_pedidoorigen IN (" + lPedidoOrigen + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Orden Cliente
        If Not String.IsNullOrEmpty(lOrdenCliente) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                Else
                    consultaContenidoAtado += " OR coat_referenciaclientepedido IN (" + lOrdenCliente + ")"
                End If
            End If
        End If

        ' '' Se agrego filtro Lote Cliente
        If Not String.IsNullOrEmpty(lLoteCliente) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_lotecliente IN (" + lLoteCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_lotecliente IN (" + lLoteCliente + ")"
                Else
                    consultaContenidoAtado += " OR coat_lotecliente IN (" + lLoteCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCliente) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_idcadena IN (" + lCliente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idcadena IN (" + lCliente + ")"
                Else
                    consultaContenidoAtado += " OR coat_idcadena IN (" + lCliente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTienda) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_idtienda IN (" + lTienda + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idtienda IN (" + lTienda + ")"
                Else
                    consultaContenidoAtado += " OR coat_idtienda IN (" + lTienda + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lPedido) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_idpedido IN (" + lPedido + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idpedido IN (" + lPedido + ")"
                Else
                    consultaContenidoAtado += " OR coat_idpedido IN (" + lPedido + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lApartado) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_idapartado IN (" + lApartado + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idapartado IN (" + lApartado + ")"
                Else
                    consultaContenidoAtado += " OR coat_idapartado IN (" + lApartado + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lBahia) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( bahi_bahiaid IN (" + lBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND bahi_bahiaid IN (" + lBahia + ")"
                Else
                    consultaContenidoAtado += " OR bahi_bahiaid IN (" + lBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lDescripcionBahia) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( bahi_descripcion IN (" + lDescripcionBahia + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND bahi_descripcion IN (" + lDescripcionBahia + ")"
                Else
                    consultaContenidoAtado += " OR bahi_descripcion IN (" + lDescripcionBahia + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lColaborador) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                Else
                    consultaContenidoAtado += " OR Colaborador.codr_colaboradorid IN (" + lColaborador + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lAgente) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_idagente IN (" + lAgente + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idagente IN (" + lAgente + ")"
                Else
                    consultaContenidoAtado += " OR coat_idagente IN (" + lAgente + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lProducto) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_producto IN (" + lProducto + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_producto IN (" + lProducto + ")"
                Else
                    consultaContenidoAtado += " OR coat_producto IN (" + lProducto + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lCorrida) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( ubat_idcorrida IN (" + lCorrida + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND ubat_idcorrida IN (" + lCorrida + ")"
                Else
                    consultaContenidoAtado += " OR ubat_idcorrida IN (" + lCorrida + ")"
                End If
            End If
        End If

        If Not String.IsNullOrEmpty(lTalla) Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_talla IN (" + lTalla + ")"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_talla IN (" + lTalla + ")"
                Else
                    consultaContenidoAtado += " OR coat_talla IN (" + lTalla + ")"
                End If
            End If
        End If

        If lFiltroEstatus <> "" And lFiltroEstatus <> "0" Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                Else
                    consultaContenidoAtado += " OR coat_idtblmovimiento IN ('" + lFiltroEstatus + "')"
                End If
            End If
        End If

        ''se agrega condicion de fecha entrega de pedido
        If filtroFechaEntregaP Then
            If primerCondicion Then
                consultaContenidoAtado += " AND ( coat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                primerCondicion = False
            Else
                If bY_O Then
                    consultaContenidoAtado += " AND coat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                Else
                    consultaContenidoAtado += " OR coat_fechaentregapedido BETWEEN '" + fechaInicioEntregaP + "' AND '" + fechaTerminoEntregaP + "'"
                End If
            End If
        End If

        If Not primerCondicion Then
            consultaContenidoAtado += ") "
        End If


        tabla = objbu.ListadoUbicacionAtado(mostrar_todo, consultaPar, consultaErrores, String.Empty, consultaContenidoAtado, True)

        Return tabla

    End Function


    Public Sub AltaBahiaCliente(ByVal bahiacliente As Entidades.Bahia)
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        objbu.AltaBahiaCliente(bahiacliente)
    End Sub

    Public Function ListadoCarritos(estatus As Integer, naveID As Integer, almacenID As Integer) As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.ListadoCarritos(estatus, naveID, almacenID)
        Return tabla
    End Function

    Public Function ListaTiposCarritos() As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.ListaTiposCarritos()
        Return tabla
    End Function

    Public Sub Alta_Editar_Carrito(ByVal carrito As Entidades.Carrito)
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        objbu.Alta_Editar_Carrito(carrito)
    End Sub

    Public Function Almacen_ReporteProductividadPlataforma(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String, ByVal CEDISID As Integer) As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable

        tabla = objbu.Almacen_ReporteProductividadPlataforma(fecha_inicio, fecha_termino, list_colaboradorID, CEDISID)
        Return tabla
    End Function

    Public Function Almacen_ReporteHistoricoUbicaciones(tipo_busqueda_par As Boolean, list_codigos As String, naveid As String, almacenid As String) As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        Dim consulta As String = String.Empty

        tabla = objbu.Almacen_ReporteHistoricoUbicaciones(tipo_busqueda_par, list_codigos, naveid)

        Return tabla


        'If tipo_busqueda_par Then ''BUSQUEDA DE PAR
        '    Dim i As Integer = 1
        '    For Each item In list_codigos

        '        If Not String.IsNullOrEmpty(consulta) Then
        '            consulta += " UNION "
        '        End If

        '        consulta += " " +
        '                  " SELECT " +
        '                  "   'P' AS 'P/A'" +
        '                  " , CASE WHEN ubpa_ubicacionparesid > 0 THEN 'PAR' END AS 'Unidad'" +
        '                  " , ubpa_codigopar AS 'Código'" +
        '                  " , IdModelo as 'Modelo'" +
        '                  " , Descripcion AS 'Descripción Producto'" +
        '                  " , Talla as 'Corrida'" +
        '                  " , ubpa_talla as 'Talla'" +
        '                  " , NULL AS 'Ubicación Anterior'" +
        '                  " , LEFT(ubpa_estibaid, CHARINDEX('-', ubpa_estibaid) - 1)  AS 'Ubicación Actual'" +
        '                  " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                  " , ubpa_origenubicacion AS 'Origen'" +
        '                  " , ubpa_fechamodificacion AS 'Última Modificación'" +
        '                  " FROM Almacen.UbicacionPares" +
        '                  " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubpa_estibaid" +
        '                  " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                  " JOIN Nomina.Colaborador ON codr_colaboradorid = ubpa_colaboradormodificaid" +
        '                  " JOIN vEstilos  on IdCodigo = ubpa_producto" +
        '                  " JOIN Tallas ON IdTalla= ubpa_idcorrida" +
        '                  " WHERE ubpa_codigopar = '" + item + "' AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid

        '        consulta += " UNION "

        '        consulta += " " +
        '                  " SELECT " +
        '                  "   'E' AS 'P/A'" +
        '                  " , CASE WHEN ersp_erroresstatusparid > 0 THEN 'PAR' END AS 'Unidad'" +
        '                  " , ersp_codigopar AS 'Código'" +
        '                  " , IdModelo as 'Modelo'" +
        '                  " , Descripcion AS 'Descripción Producto'" +
        '                  " , Talla as 'Corrida'" +
        '                  " , ersp_talla as 'Talla'" +
        '                  " , NULL AS 'Ubicación Anterior'" +
        '                  " , LEFT(ersp_estibaid, CHARINDEX('-', ersp_estibaid) - 1)  AS 'Ubicación Actual'" +
        '                  " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                  " , ersp_origenubicacion AS 'Origen'" +
        '                  " , ersp_fechamodificacion AS 'Última Modificación'" +
        '                  " FROM Almacen.ErroresStatusPar" +
        '                  " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersp_estibaid" +
        '                  " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                  " JOIN Nomina.Colaborador ON codr_colaboradorid = ersp_colaboradormodificaid" +
        '                  " JOIN vEstilos  on IdCodigo = ersp_producto" +
        '                  " JOIN Tallas ON IdTalla= ersp_idcorrida" +
        '                  " WHERE ersp_codigopar = '" + item + "' AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid

        '        consulta += " UNION "


        '        consulta += " " +
        '                    " SELECT " +
        '                    "   'P' AS 'P/A'" +
        '                    " , CASE WHEN ubph_ubicacionpareshist_id > 0 THEN 'PAR' END AS 'Unidad'" +
        '                    " , ubph_codigopar AS 'Código'" +
        '                    " , IdModelo as 'Modelo'" +
        '                    " , Descripcion AS 'Descripción Producto'" +
        '                    " , Talla as 'Corrida'" +
        '                    " , ubph_talla as 'Talla'" +
        '                    " , LEFT(ubph_estibaid, CHARINDEX('-', ubph_estibaid) - 1) AS 'Ubicación Anterior'" +
        '                    " , NULL AS 'Ubicación Actual'" +
        '                    " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                    " , ubph_origenubicacion AS 'Origen'" +
        '                    " , ubph_fechamodificacion AS 'Última Modificación'" +
        '                    " FROM Almacen.UbicacionPares_Hist" +
        '                    " JOIN Nomina.Colaborador ON codr_colaboradorid = ubph_colaboradormodificaid" +
        '                    " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubph_estibaid" +
        '                    " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                    " JOIN vEstilos  on IdCodigo = ubph_producto" +
        '                    " JOIN Tallas ON IdTalla= ubph_idcorrida" +
        '                    " WHERE ubph_codigopar = '" + item + "' AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid

        '        consulta += " UNION "

        '        consulta += " " +
        '                 " SELECT " +
        '                 "   'E' AS 'P/A'" +
        '                 " , CASE WHEN ersh_erroresstatusparid > 0 THEN 'PAR' END AS 'Unidad'" +
        '                 " , ersh_codigopar AS 'Código'" +
        '                 " , IdModelo as 'Modelo'" +
        '                 " , Descripcion AS 'Descripción Producto'" +
        '                 " , Talla as 'Corrida'" +
        '                 " , ersh_talla as 'Talla'" +
        '                 " , NULL AS 'Ubicación Anterior'" +
        '                 " , LEFT(ersh_estibaid, CHARINDEX('-', ersh_estibaid) - 1)  AS 'Ubicación Actual'" +
        '                 " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                 " , ersh_origenubicacion AS 'Origen'" +
        '                 " , ersh_fechamodificacion AS 'Última Modificación'" +
        '                 " FROM Almacen.ErroresStatusPar_Hist" +
        '                 " LEFT JOIN Almacen.Estiba ON esti_estibaid = ersh_estibaid" +
        '                 " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                 " JOIN Nomina.Colaborador ON codr_colaboradorid = ersh_colaboradormodificaid" +
        '                 " JOIN vEstilos  on IdCodigo = ersh_producto" +
        '                 " JOIN Tallas ON IdTalla= ersh_idcorrida" +
        '                 " WHERE ersh_codigopar = '" + item + "' AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid

        '        consulta += " UNION "

        '        consulta += " " +
        '                  " SELECT " +
        '                  "   'A' AS 'P/A'" +
        '                  " , CASE WHEN ubat_ubicacionatadosid > 0 THEN 'ATADO' END AS 'Unidad'" +
        '                  " , ubat_codigoatado AS 'Código'" +
        '                  " , IdModelo as 'Modelo'" +
        '                  " , Descripcion AS 'Descripción Producto'" +
        '                  " , Talla as 'Corrida'" +
        '                  " , '---' as 'Talla'" +
        '                  " , LEFT(ubat_estibaid, CHARINDEX('-', ubat_estibaid) - 1)  AS 'Ubicación Anterior'" +
        '                  " , NULL AS 'Ubicación Actual'" +
        '                  " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                  " , ubat_origenubicacion AS 'Origen'" +
        '                  " , ubat_fechamodificacion AS 'Última Modificación'" +
        '                  " FROM Almacen.UbicacionAtados" +
        '                  " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid" +
        '                  " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                  " JOIN Nomina.Colaborador ON codr_colaboradorid = ubat_colaboradormodificaid" +
        '                  " JOIN vEstilos  on IdCodigo = ubat_producto" +
        '                  " JOIN Tallas ON IdTalla= ubat_idcorrida" +
        '                  " WHERE ubat_codigoatado = (SELECT ubpa_codigoatado FROM Almacen.UbicacionPares WHERE ubpa_codigopar = '" + item + "') " +
        '                  " AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid

        '        consulta += "UNION "

        '        consulta += " " +
        '                    " SELECT " +
        '                    "  'A' AS 'P/A'" +
        '                    " , CASE WHEN ubah_ubicacionatadoshist_id > 0 THEN 'ATADO' END AS 'Unidad'" +
        '                    " , ubah_codigoatado AS 'Código'" +
        '                    " , IdModelo as 'Modelo'" +
        '                    " , Descripcion AS 'Descripción Producto'" +
        '                    " , Talla as 'Corrida'" +
        '                    " , '---' as 'Talla'" +
        '                    " , LEFT(ubah_estibaid, CHARINDEX('-', ubah_estibaid) - 1)  AS 'Ubicación Anterior'" +
        '                    " , NULL AS 'Ubicación Actual'" +
        '                    " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                    " , ubah_origenubicacion AS 'Origen'" +
        '                    " , ubah_fechamodificacion AS 'Última Modificación'" +
        '                    " FROM Almacen.UbicacionAtados_Hist" +
        '                    " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubah_estibaid" +
        '                    " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                    " JOIN Nomina.Colaborador ON codr_colaboradorid = ubah_colaboradormodificaid" +
        '                    " JOIN vEstilos  on IdCodigo = ubah_producto" +
        '                    " JOIN Tallas ON IdTalla= ubah_idcorrida" +
        '                    " WHERE ubah_codigoatado = (SELECT ubpa_codigoatado FROM Almacen.UbicacionPares WHERE ubpa_codigopar = '" + item + "') " +
        '                    " AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid


        '        If i = list_codigos.Count Then
        '            consulta += " ORDER BY 'Última Modificación' DESC"
        '        End If

        '        i += 1
        '    Next
        'Else ''BUSQUEDA DE ATADO


        '    Dim i As Integer = 1
        '    For Each item In list_codigos

        '        If Not String.IsNullOrEmpty(consulta) Then
        '            consulta += " UNION "
        '        End If

        '        consulta += " " +
        '                  " SELECT " +
        '                  "   'A' AS 'P/A'" +
        '                  " , CASE WHEN ubat_ubicacionatadosid > 0 THEN 'ATADO' END AS 'Unidad'" +
        '                  " , ubat_codigoatado AS 'Código'" +
        '                  " , IdModelo as 'Modelo'" +
        '                  " , Descripcion AS 'Descripción Producto'" +
        '                  " , Talla as 'Corrida'" +
        '                  " , '---' as 'Talla'" +
        '                  " , NULL AS 'Ubicación Anterior'" +
        '                  " , LEFT(ubat_estibaid, CHARINDEX('-', ubat_estibaid) - 1)  AS 'Ubicación Actual'" +
        '                  " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                  " , ubat_origenubicacion AS 'Origen'" +
        '                  " , ubat_fechamodificacion AS 'Última Modificación'" +
        '                  " FROM Almacen.UbicacionAtados" +
        '                  " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubat_estibaid" +
        '                  " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                  " JOIN Nomina.Colaborador ON codr_colaboradorid = ubat_colaboradormodificaid" +
        '                  " JOIN vEstilos  on IdCodigo = ubat_producto" +
        '                  " JOIN Tallas ON IdTalla= ubat_idcorrida" +
        '                  " WHERE ubat_codigoatado = '" + item + "' AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid

        '        consulta += "UNION "

        '        consulta += " " +
        '                    " SELECT " +
        '                    "  'A' AS 'P/A'" +
        '                    " , CASE WHEN ubah_ubicacionatadoshist_id > 0 THEN 'ATADO' END AS 'Unidad'" +
        '                    " , ubah_codigoatado AS 'Código'" +
        '                    " , IdModelo as 'Modelo'" +
        '                    " , Descripcion AS 'Descripción Producto'" +
        '                    " , Talla as 'Corrida'" +
        '                    " , '---' as 'Talla'" +
        '                    " , LEFT(ubah_estibaid, CHARINDEX('-', ubah_estibaid) - 1)  AS 'Ubicación Anterior'" +
        '                    " , NULL AS 'Ubicación Actual'" +
        '                    " , CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(200)) AS 'Operador'" +
        '                    " , ubah_origenubicacion AS 'Origen'" +
        '                    " , ubah_fechamodificacion AS 'Última Modificación'" +
        '                    " FROM Almacen.UbicacionAtados_Hist" +
        '                    " LEFT JOIN Almacen.Estiba ON esti_estibaid = ubah_estibaid" +
        '                    " LEFT JOIN Almacen.Bahia ON bahi_bahiaid = esti_bahiaid" +
        '                    " JOIN Nomina.Colaborador ON codr_colaboradorid = ubah_colaboradormodificaid" +
        '                    " JOIN vEstilos  on IdCodigo = ubah_producto" +
        '                    " JOIN Tallas ON IdTalla= ubah_idcorrida" +
        '                    " WHERE ubah_codigoatado = '" + item + "' AND bahi_nave = " + naveid + " AND bahi_almacen = " + almacenid


        '        If i = list_codigos.Count Then
        '            consulta += " ORDER BY 'Última Modificación' DESC"
        '        End If

        '        i += 1
        '    Next
        'End If


    End Function

    Public Function Almacen_ReporteInventarioInicial(fecha_inicio As DateTime, fecha_termino As DateTime, naveid As String, almacenid As String) As DataTable
        Dim objbu As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        Dim consulta As String = String.Empty

        consulta += " " +
                           " SELECT" +
                           "   reua_fecha" +
                           " , ISNULL(reua_inventarioinicialsicy, 0) AS reua_inventarioinicialsicy" +
                           " , ISNULL(reua_inventarioinicialsicy_conubicacion, 0) AS reua_inventarioinicialsicy_conubicacion" +
                           " , ISNULL(reua_inventarioinicialsicy_sinubicacion, 0) AS reua_inventarioinicialsicy_sinubicacion" +
                           " , ISNULL(reua_inventacioinicialsay_error, 0) AS reua_inventacioinicialsay_error" +
                           " , ISNULL(reua_paresingresados, 0) AS reua_paresingresados" +
                           " , ISNULL(reua_paresingresados_entreganave, 0) AS reua_paresingresados_entreganave" +
                           " , ISNULL(reua_paresingresados_entreganave_conubicacion, 0) AS reua_paresingresados_entreganave_conubicacion" +
                           " , ISNULL(reua_paresingresados_entreganave_sinubicacion, 0) AS reua_paresingresados_entreganave_sinubicacion" +
                           " , ISNULL(reua_paresingresados_otrasentradas, 0) AS reua_paresingresados_otrasentradas" +
                           " , ISNULL(reua_paresingresados_otrasentradas_conubicacion, 0) AS reua_paresingresados_otrasentradas_conubicacion" +
                           " , ISNULL(reua_paresingresados_otrasentradas_sinubicacion, 0) AS reua_paresingresados_otrasentradas_sinubicacion" +
                           " , ISNULL(reua_paressalidas, 0) AS reua_paressalidas" +
                           " , ISNULL(reua_paressalidas_ventas, 0) AS reua_paressalidas_ventas" +
                           " , ISNULL(reua_paressalidas_otrassalidas, 0) AS reua_paressalidas_otrassalidas" +
                           " , ISNULL(reua_paressalidas_conubicacion, 0) AS reua_paressalidas_conubicacion" +
                           " , ISNULL(reua_paressalidas_sinubicacion, 0) AS reua_paressalidas_sinubicacion" +
                           " , ISNULL(reua_movimientosalmacen, 0) AS reua_movimientosalmacen" +
                           " , ISNULL(reua_inventariofinalsicy, 0) AS reua_inventariofinalsicy" +
                           " , ISNULL(reua_inventariofinalsicy_conubicacion, 0) AS reua_inventariofinalsicy_conubicacion" +
                           " , ISNULL(reua_inventariofinalsicy_sinubicacion, 0) AS reua_inventariofinalsicy_sinubicacion" +
                           " , ISNULL(reua_inventaciofinalsay_error, 0) AS reua_inventaciofinalsay_error " +
                           " FROM Almacen.ResumenEstadoUbicacionAlmacen" +
                           " WHERE reua_activo = 1" +
                           " AND reua_fecha BETWEEN '" + fecha_inicio + "' AND '" + fecha_termino + "'"


        tabla = objbu.Almacen_ReporteInventarioInicial(consulta)

        Return tabla
    End Function

    Public Function Obtener_Datetime_Servidor() As DateTime
        Dim objDA As New ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Obtener_Datetime_Servidor()

        If tabla.Rows.Count > 0 Then
            Obtener_Datetime_Servidor = CStr(tabla.Rows(0).Item(0))
        Else
            Obtener_Datetime_Servidor = String.Empty
        End If

    End Function

    Public Function Pares_en_SICY(nave As String, almacen As String) As Integer
        Dim objDA As New ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Pares_en_SICY(nave, almacen)

        If tabla.Rows.Count > 0 Then
            Pares_en_SICY = CInt(tabla.Rows(0).Item(0))
        Else
            Pares_en_SICY = 0
        End If

    End Function

    Public Function Pares_en_SAY(nave As String, almacen As String) As Integer
        Dim objDA As New ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Pares_en_SAY(nave, almacen)

        If tabla.Rows.Count > 0 Then
            Pares_en_SAY = CInt(tabla.Rows(0).Item(0))
        Else
            Pares_en_SAY = 0
        End If

    End Function

    Public Sub ValidarPlataformas()
        Dim objDA As New ClientesAlmacenDA
        objDA.ValidarPlataformas()
    End Sub
    Public Sub actualizarContenidoAtadosUbicacionPares()
        Dim objDA As New ClientesAlmacenDA
        objDA.actualizarContenidoAtadosUbicacionPares()
    End Sub

    Public Function Almacen_ReporteOTCoppelAvancePedido(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Almacen_ReporteOTCoppelAvancePedido(fecha_inicio, fecha_termino, list_colaboradorID)
        Return tabla
    End Function

    Public Function Almacen_ReporteOTCoppelIncidenciasPedido(fecha_inicio As DateTime, fecha_termino As DateTime) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Almacen_ReporteOTCoppelIncidenciasPedido(fecha_inicio, fecha_termino)
        Return tabla
    End Function

    Public Function Almacen_ReporteOTCoppelIncidenciasUsuario(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Almacen_ReporteOTCoppelIncidenciasUsuario(fecha_inicio, fecha_termino, list_colaboradorID)
        Return tabla
    End Function

    Public Function Almacen_ReporteOTCoppelIncidenciasUsuarioFecha(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Almacen_ReporteOTCoppelIncidenciasUsuarioFecha(fecha_inicio, fecha_termino, list_colaboradorID)
        Return tabla
    End Function

    Public Function Almacen_ReporteOTCoppelOTConfirmadasUsuarioFecha(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Almacen_ReporteOTCoppelOTConfirmadasUsuarioFecha(fecha_inicio, fecha_termino, list_colaboradorID)
        Return tabla
    End Function

    Public Function Almacen_ReporteOTCoppelParesUsuarioFecha(fecha_inicio As DateTime, fecha_termino As DateTime, list_colaboradorID As String) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.Almacen_ReporteOTCoppelParesUsuarioFecha(fecha_inicio, fecha_termino, list_colaboradorID)
        Return tabla
    End Function

    Public Function Almacen_ActualizaStock() As Boolean
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim resultado As Boolean
        resultado = objDA.Almacen_ActualizaStock()
        Return resultado
    End Function

    Public Function localizarProductoEnAlmacenPorAgrupamiento(ByVal nave As String, ByVal almacen As String, ByVal Con_Sin_Ubicacion As Int16, ByVal tipo_Agrupacion As Int16, ByVal bY_O As String,
                                                              ByVal cadPares As String, ByVal cadLotes As String, ByVal cadAtados As String, ByVal cadAniosLotes As String, ByVal cadLotesCliente As String, ByVal cadNaves As String, ByVal cadPedidosOrigen As String, ByVal cadPedidos As String,
                                                              ByVal cadClientes As String, ByVal cadTiendas As String, ByVal cadAgentes As String, ByVal cadOrdenesCliente As String, ByVal cadApartados As String,
                                                              ByVal cadProductos As String, ByVal cadCorridas As String, ByVal cadTallas As String, ByVal cadBahias As String, ByVal cadDescripcionesBahia As String, ByVal cadColaboradores As String,
                                                              ByVal cadEstatus As String, ByVal filtroFechas As Boolean, ByVal fechaInicio As String, ByVal fechaTermino As String,
                                                              ByVal filtroFechasEntregaP As Boolean, ByVal fechaInicioEntregaP As String, ByVal fechaTerminoEntregaP As String) As DataTable
        Dim objDA As New Datos.ClientesAlmacenDA

        Return objDA.localizarProductoEnAlmacenPorAgrupamiento(nave, almacen, Con_Sin_Ubicacion, tipo_Agrupacion, bY_O,
                                                               cadPares, cadLotes, cadAtados, cadAniosLotes, cadLotesCliente, cadNaves, cadPedidosOrigen, cadPedidos,
                                                               cadClientes, cadTiendas, cadAgentes, cadOrdenesCliente, cadApartados,
                                                               cadProductos, cadCorridas, cadTallas, cadBahias, cadDescripcionesBahia, cadColaboradores,
                                                               cadEstatus, filtroFechas, fechaInicio, fechaTermino,
                                                               filtroFechasEntregaP, fechaInicioEntregaP, fechaTerminoEntregaP)
    End Function

#Region "Reportes Apartados"
    Public Function comboReporteApartadosSegunUsuario(ByVal idUsuario As Int32) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim dtReportes As New DataTable
        dtReportes = objDA.comboReporteApartadosSegunUsuario(idUsuario)
        Return dtReportes
    End Function

    Public Function reporteAvancePorFechaPreparacion(ByVal filtroClientes As String, filtroPedidos As String, ByVal filtroApartados As String,
                                                     ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable

        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim dtReporteFechaP As New DataTable
        dtReporteFechaP = objDA.reporteAvancePorFechaPreparacion(filtroClientes, filtroPedidos, filtroApartados, fechaInicio, fechaFin, CEDISID)
        Return dtReporteFechaP
    End Function

    Public Function reporteApartadoPorEstatus(ByVal filtroClientes As String, ByVal filtroPedidos As String, ByVal filtroApartados As String,
                                              ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable

        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim dtReporteEstatus As New DataTable
        dtReporteEstatus = objDA.reporteApartadoPorEstatus(filtroClientes, filtroPedidos, filtroApartados, fechaInicio, fechaFin, CEDISID)
        Return dtReporteEstatus
    End Function

    Public Function reportePares_ConfirmadoPorFechaUsuario(ByVal filtroClientes As String, ByVal filtroPedidos As String, ByVal filtroApartados As String,
                                                               ByVal filtroOperador As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim dtReporteConfirmado As New DataTable
        dtReporteConfirmado = objDA.reportePares_ConfirmadoPorFechaUsuario(filtroClientes, filtroPedidos, filtroApartados, filtroOperador, fechaInicio, fechaFin, CEDISID)
        Return dtReporteConfirmado
    End Function

    Public Function reporteApartados_ConfirmadoPorFechaUsuario(ByVal filtroClientes As String, ByVal filtroPedidos As String, ByVal filtroApartados As String,
                                                              ByVal filtroOperador As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim dtReporteConfirmado As New DataTable
        dtReporteConfirmado = objDA.reporteApartados_ConfirmadoPorFechaUsuario(filtroClientes, filtroPedidos, filtroApartados, filtroOperador, fechaInicio, fechaFin, CEDISID)
        Return dtReporteConfirmado
    End Function
#End Region

    Public Function ReporteInventario(ByVal fechaDesde As String, ByVal fechaHasta As String, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.ClientesAlmacenDA
        Dim tabla As New DataTable
        Dim tablaResulFinal As New DataTable

        tabla = objDA.ReporteInventario(fechaDesde, fechaHasta, ComercializadoraId)
        tablaResulFinal = tabla
        For index As Integer = 0 To tabla.Rows.Count - 1
            If index < 4 Or index > 14 Then
                Dim total As Integer = tabla.Rows(index).Item(fechaHasta)
                tablaResulFinal.Rows(index).Item("Total") = total
            End If
        Next

        Return tablaResulFinal
    End Function
End Class
