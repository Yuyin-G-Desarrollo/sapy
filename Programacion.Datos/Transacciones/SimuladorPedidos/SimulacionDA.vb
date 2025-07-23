Public Class SimulacionDA

    Public Function verOpcionesSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                SELECT
                CAST(0 AS bit) as SEL,
	            OpcSim_OpcionSimuladorID,
	            OpcSim_Nombre,
	            OpcSim_Descripcion,
	            OpcSim_Status,
	            0 AS Orden
                FROM Programacion.OpcionesSimulacion
                WHERE OpcSim_Status = 1
                ORDER BY OpcSim_Nombre
                 </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verOpcionesConfiguradasSimulacion(ByVal idSimulacion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" & _
            " CAST(1 AS bit) AS Sel," & _
            " cmp.psmd_SimulacionMaestroId," & _
            " op.OpcSim_OpcionSimuladorID," & _
            " op.OpcSim_Nombre," & _
            " op.OpcSim_Descripcion," & _
            " op.OpcSim_Status," & _
            " cmp.psmd_OpcionSimConfiguracionId," & _
            " cmp.psmd_Orden AS Orden," & _
            " NULL AS ConfTemp" & _
            " FROM Programacion.OpcionesSimulacion op" & _
            " JOIN Programacion.ProcesoSimulacionMaestroDetalle cmp" & _
            " ON op.OpcSim_OpcionSimuladorID = cmp.psmd_OpciocionSimulacionId" & _
            " WHERE OpcSim_Status = 1 AND cmp.psmd_Activo = 1 And cmp.psmd_SimulacionMaestroId = " + idSimulacion.ToString & _
            " ORDER BY Sel desc, Orden"
        '" UNION" & _
        '" SELECT" & _
        '" CAST(0 AS bit) AS Sel," & _
        '" 0," & _
        '" OpcSim_OpcionSimuladorID," & _
        '" OpcSim_Nombre," & _
        '" OpcSim_Descripcion," & _
        '" OpcSim_Status," & _
        '" NULL AS conf," & _
        '" 0 AS Orden," & _
        '" NULL AS ConfTemp" & _
        '" FROM Programacion.OpcionesSimulacion" & _
        '" WHERE OpcSim_Status = 1" & _
        '" AND OpcSim_OpcionSimuladorID NOT IN (SELECT psmd_OpciocionSimulacionId FROM" & _
        '" Programacion.ProcesoSimulacionMaestroDetalle WHERE psmd_SimulacionMaestroId = " + idSimulacion.ToString + " AND psmd_Activo = 1)" & _
        '" ORDER BY Sel desc, Orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verConfiguracionOpionesSimulacion(ByVal idOpcion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     SELECT
                        OpcSim_OpcionSimuladorID,
                        OpcSimConf_OpcionSimConfigID,
                        OpcSimConf_Nombre,
                        OpcSimConf_Descripcion,
                        OpcSimConf_ConfiguracionActual
                        FROM Programacion.OpcionesSimulacionConfig
                        WHERE OpcSimConf_Estatus = 1
                        AND OpcSim_OpcionSimuladorID = <%= idOpcion.ToString %>
                        ORDER BY OpcSimConf_Nombre
                 </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaDatosUltimaConfiguracion()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     SELECT TOP 1
                        ProcSimMae_ProcSimuladorID,
                        ProcSimMae_Descripcion,
                        ProcSimMae_Estatus,
                        ProcSimMae_RangoSemanaInicio,
                        ProcSimMae_RangoSemanaFin,
                        ProcSimMae_RangoAnioInicio,
                        ProcSimMae_RangoAnioFin,
                        ProcSimMae_VerTodo
                        FROM Programacion.ProcesoSimulacionMaestro
                        WHERE ProcSimMae_Estatus = 1
                        ORDER BY ProcSimMae_ProcSimuladorID DESC
                 </cadena>.Value

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function rangoAnios() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT MIN(prog_año) inicio, MAX(prog_año) fin FROM Programacion.ProgramasRenglon"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarOrdenOpcion(ByVal idOpcion As Int32, ByVal orden As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.OpcionesSimulacion SET" & _
                " OpcSim_OrdenActual = " + orden.ToString & _
                " WHERE OpcSim_OpcionSimuladorID = " + idOpcion.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editaConfiguracionesOrden()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.OpcionesSimulacionConfig SET" & _
                " OpcSimConf_UsuarioModificacion = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", " & _
                " OpcSimConf_FechaModificacion = GETDATE(), OpcSimConf_ConfiguracionActual = 0"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub seleccionarOrdenOpcionConfiguracion(idConfiguracion As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.OpcionesSimulacionConfig SET" & _
          " OpcSimConf_UsuarioModificacion = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", " & _
          " OpcSimConf_FechaModificacion = GETDATE(), OpcSimConf_ConfiguracionActual = 1 WHERE OpcSimConf_OpcionSimConfigID = " + idConfiguracion.ToString

        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub inactivarConfiguracionAnterior()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.ProcesoSimulacionMaestro  SET ProcSimMae_UsuarioModifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "," & _
        " ProcSimMae_FechaModifico = GETDATE()," & _
        " ProcSimMae_Estatus = 0 WHERE ProcSimMae_Estatus = 1 "
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub guardarNuevaConfiguracionSimulacion(ByVal descripcion As String,
                                                   ByVal semanaInicio As Int32,
                                                   ByVal semanaFin As Int32,
                                                   ByVal anioinicio As Int32,
                                                   ByVal anioFin As Int32,
                                                   ByVal verTodo As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.ProcesoSimulacionMaestro " & _
                " (ProcSimMae_Descripcion, " & _
                " ProcSimMae_RangoSemanaInicio, " & _
                " ProcSimMae_RangoSemanaFin, " & _
                " ProcSimMae_RangoAnioInicio, " & _
                " ProcSimMae_RangoAnioFin, " & _
                " ProcSimMae_Estatus, " & _
                " ProcSimMae_FechaCreo, " & _
                " ProcSimMae_UsuarioCreo," & _
                " ProcSimMae_VerTodo)"

        cadena += " VALUES ('" + descripcion + "', " + semanaInicio.ToString + ", " + semanaFin.ToString + ", " + anioinicio.ToString + ", " + anioFin.ToString + ", 1, GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", '" + verTodo.ToString + "')"


        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function verIdRegistradoConf() As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim valor As Int32 = 0
        cadena = "SELECT MAX(ProcSimMae_ProcSimuladorID) FROM Programacion.ProcesoSimulacionMaestro"
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                valor = dt.Rows(0).Item(0)
            End If
        End If
        Return valor
    End Function

    Public Function consultaSimulacionTemporal() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
            SELECT
	NULL AS PrSt,
	0 AS Programado,
	tmps.tmpSim_programaID,
	tmps.tmpSim_FechaPedido,
	tmps.tmpSim_SimBloqueo,
	tmps.tmpSim_naveID,
	tmps.tmpSim_productoID,
	tmps.tmpSim_productoEstiloID,
	tmps.tmpSim_tallaID,
	tmps.tmpSim_IdPedido,
	tmps.tmpSim_IdRenglon,
	tmps.tmpSim_idLote,
	tmps.tmpSim_Cantidad,
	tmps.tmpSim_anio,
	tmps.tmpSim_tipo,
	tmps.tmpSim_idCadena,
	tmps.tmpSim_cerrado,
	tmps.tmpSim_idCliente,
	tmps.tmpSim_hormaid,
    tmpSim_ProgSemana,
	vp.prod_codigo,
	vp.modeloSICY,
	vp.prod_descripcion + ' ' + vp.pielColor + ' ' + vp.talla Modelo,
	cl.clie_nombregenerico,
    tmps.tmpSim_fechaCliente,
    ' ' AS Bitacora,
    vp.idGrupo
FROM Programacion.tmpSimulacionProc tmps
JOIN vProductoEstilos vp
	ON vp.pstilo = tmps.tmpSim_productoEstiloID
	AND vp.idTalla = tmps.tmpSim_tallaID
	AND vp.idHorma = tmps.tmpSim_hormaid
	JOIN Cliente.Cliente cl on cl.clie_idsicy = tmps.tmpSim_idCadena
ORDER BY tmps.tmpSim_programaID
                 </cadena>.Value

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaSimulacionTemporalNOProgramados() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = " SELECT" & _
    " NULL AS PrSt," & _
    " 0 AS Programado," & _
    " tmps.tmpSim_programaID," & _
    " tmps.tmpSim_FechaPedido," & _
    " tmps.tmpSim_SimBloqueo," & _
    " tmps.tmpSim_naveID," & _
    " tmps.tmpSim_productoID," & _
    " tmps.tmpSim_productoEstiloID," & _
    " tmps.tmpSim_tallaID," & _
    " tmps.tmpSim_IdPedido," & _
    " tmps.tmpSim_IdRenglon," & _
    " tmps.tmpSim_idLote," & _
    " tmps.tmpSim_Cantidad," & _
    " tmps.tmpSim_anio," & _
    " tmps.tmpSim_tipo," & _
    " tmps.tmpSim_idCadena," & _
    " tmps.tmpSim_cerrado," & _
    " tmps.tmpSim_idCliente," & _
    " tmps.tmpSim_hormaid," & _
    " tmpSim_ProgSemana," & _
    " vp.prod_codigo," & _
    " vp.modeloSICY," & _
    " vp.prod_descripcion + ' ' + vp.pielColor + ' ' + vp.talla Modelo," & _
    " cl.clie_nombregenerico," & _
    " tmps.tmpSim_fechaCliente," & _
        " ' ' AS Bitacora," & _
        " vp.idGrupo" & _
        " FROM Programacion.tmpSimulacionProc tmps" & _
        " JOIN vProductoEstilos vp" & _
        " ON vp.pstilo = tmps.tmpSim_productoEstiloID" & _
        " AND vp.idTalla = tmps.tmpSim_tallaID" & _
        " AND vp.idHorma = tmps.tmpSim_hormaid" & _
        " JOIN Cliente.Cliente cl on cl.clie_idsicy = tmps.tmpSim_idCadena" & _
        " WHERE tmps.tmpSim_ProgramaRenglonId IN (" & _
        " SELECT prog_programaID FROM Programacion.ProgramasRenglon WHERE prog_tipo <> 'P'" & _
        " )" & _
        " ORDER BY tmps.tmpSim_Orden, tmps.tmpSim_SubOrden"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function obtenerFolio() As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT ISNULL(MAX(bita_folio),0) + 1 FROM Programacion.BitacoraSimulacion"
        Dim dt As New DataTable
        Dim dato As Int32 = 0
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            dato = dt.Rows(0).Item(0)
        End If
        Return dato
    End Function

    Public Sub guardarRegistroBItacoraSimulacion(ByVal folio As Int32, ByVal idPedido As Int32, ByVal idRenglon As Int32,
                                   ByVal idProducto As Int32, ByVal pares As Int32, ByVal fecha As String,
                                   ByVal mensaje As String, ByVal tipo As String, ByVal pares_faltan As Int32,
                                   ByVal linea As Int32, ByVal prestilo As Int32, ByVal idTalla As Int32,
                                   ByVal origen As String, ByVal simulacionid As Int32, ByVal bita_pdetID As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.BitacoraSimulacion (bita_folio, bita_origen, bita_idPedido, bita_renglonID," & _
        " bita_productoID, bita_pares, bita_fecha, bita_mensaje," & _
        " bita_pc, bita_alta, bita_tipo, bita_pares_faltan," & _
        " bita_linpID, bita_productoEstiloID, bita_tallaID," & _
        " bita_simulacionID, bita_pdetID)" & _
        " VALUES (" + folio.ToString + ", '" + origen + "', " + idPedido.ToString + ", " + idRenglon.ToString & _
        ", " + idProducto.ToString + ", " + pares.ToString + ", '" + fecha + "'" & _
        ", '" + mensaje + "', '" + My.Computer.Name.ToString + "', GETDATE(), '" + tipo + "', " + pares_faltan.ToString & _
        ", " + linea.ToString + ", " + prestilo.ToString + ", " + idTalla.ToString & _
        ", " + simulacionid.ToString + ", " + bita_pdetID.ToString + ")"

        operacion.EjecutaSentencia(cadena)

    End Sub

    'Public Sub eliminarDatosSimulacionAnterior(ByVal idSimulacionMaestro As Int32)
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim cadena As String = ""
    '    'cadena = "DELETE FROM Programacion.SimulacionProgramasRenglon WHERE prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString
    '    cadena = "TRUNCATE TABLE Programacion.tmpSimulacionProc"
    '    operacion.EjecutaSentencia(cadena)
    'End Sub

    Public Function consultaExistenciaCapacidadArticuloAnioSimulacion(ByVal anio As Int32,
                                                        ByVal semana As Int32,
                                                        ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                        ByVal idTalla As Int32, ByVal idSimulacionMaestro As Int32,
                                                        ByVal simularCambio As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        If simularCambio = True Then
            cadena = "SELECT * FROM (  "
            'cadena = "SELECT Tipo, proc_prodID, proc_linpID, linp_idNave," & _
            '"Nave, " + semana.ToString + "_" + anio.ToString + ", prna_orden, prna_muestras, proc_productoEstiloId, proc_tallaID, tipoAlta, lineaOrigen, oran_orden	FROM (  "
        End If
        cadena += "SELECT 'Capacidad' Tipo, pc.proc_prodID, pc.proc_linpID,	lp.linp_idNave,	na.nave_nombre Nave,"


        cadena += " (pc.proc_" + semana.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + semana.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana_simulacion(" + anio.ToString + ", pc.proc_linpID, " + semana.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ", " + idSimulacionMaestro.ToString + "), 0) [" + semana.ToString + "_" + anio.ToString + "],"

        cadena += " prna_orden, prna_muestras, proc_productoEstiloId, proc_tallaID"
        If simularCambio = True Then
            cadena += " ,0 tipoAlta,0 lineaOrigen"
        End If

        cadena += " FROM Programacion.ProductosCapacidad pc" & _
            " INNER JOIN Programacion.LineasProduccion lp ON linp_linpID = proc_linpID" & _
            " INNER JOIN Programacion.ProductosNave pn ON pn.prna_productoID = pc.proc_prodID" & _
            " AND pn.prna_productoEstiloID = pc.proc_productoEstiloId	AND pc.proc_tallaID = pn.prna_tallaID " & _
            " AND pn.prna_naveID = lp.linp_idNave AND pn.prna_hormaid = pc.proc_hormaid	" & _
            " INNER JOIN Programacion.NavesAux na	ON nave_naveid = linp_idNave" & _
            " INNER JOIN vProductos vp ON vp.v_prodID = pc.proc_prodID" & _
            " AND vp.v_productoEstiloID = pc.proc_productoEstiloId AND vp.v_tallaID = pc.proc_tallaID" & _
            " AND vp.v_hormaID = PC.proc_hormaid " & _
            " WHERE pc.proc_año = " + anio.ToString & _
            " AND pc.proc_prodID = " + idProd.ToString & _
            " AND pc.proc_productoEstiloId = " + idEstilo.ToString & _
            " AND pc.proc_tallaID = " + idTalla.ToString & _
            " AND pc.proc_activo = 1" & _
            " AND lp.linp_activo = 1" & _
            " AND pn.prna_activo = 1" & _
            " AND na.nave_activo = 1" & _
            " AND vp.prod_activo = 1" & _
            " AND vp.pres_activo = 1" & _
            " GROUP BY	pc.proc_prodID," & _
            " pc.proc_linpID," & _
            " lp.linp_idNave," & _
            " pn.prna_orden," & _
            " pn.prna_muestras," & _
            " na.nave_nombre," & _
            " DescripcionCompleta," & _
            " pc.proc_productoEstiloId," &
            " pc.proc_tallaID"

        cadena += ", pc.proc_" + semana.ToString

        '" ) AS CONS"
        '" GROUP BY	proc_prodID," & _
        '" proc_linpID," & _
        '" linp_idNave," & _
        '" prna_orden," & _
        '" prna_muestras," & _
        '" nave," & _
        '" proc_productoEstiloId," & _
        '" proc_tallaID" & _
        If simularCambio = True Then
            cadena += " UNION ALL " & _
            " SELECT 'Capacidad' Tipo, smac_productoId, smac_lineaId, lp.linp_idNave, na.nave_nombre,"

            cadena += " (sm.smac_" + semana.ToString


            cadena += " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + semana.ToString + ", lp.linp_idNave)) - ISNULL(programacion.fdu_pares_semana_simulacion(" + anio.ToString + ", smac_lineaId, " + semana.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ", " + idSimulacionMaestro.ToString + "), 0) [" + semana.ToString + "_" + anio.ToString + "]," & _
            " os.oran_orden, 0, sm.smac_productoEstiloId," & _
            " sm.smac_tallaID, sm.smac_tipoAlta, ISNULL(sm.smac_artiuloCapacidadCopiaId, sm.smac_articuloCapacidadCambioId) lineaOrigen" & _
            " FROM Programacion.simulacionArticuloCapacidad sm" & _
            " JOIN Programacion.LineasProduccion lp ON sm.smac_lineaId = lp.linp_linpID" & _
            " JOIN Programacion.NavesAux na ON lp.linp_idNave = na.nave_naveid" & _
            " JOIN Programacion.OrdenArticuloNaveSimulacion os ON sm.smac_productoEstiloId = os.oran_productoEstiloId " & _
            " AND lp.linp_idNave = os.oran_naveId" & _
            " WHERE sm.smac_anio  = " + anio.ToString & _
            " AND smac_productoEstiloId = " + idEstilo.ToString & _
            " AND smac_simulacionId = " + idSimulacionMaestro.ToString & _
            " AND os.oran_simulacionId = " + idSimulacionMaestro.ToString & _
            " AND lp.linp_activo = 1" & _
            " AND na.nave_activo = 1" & _
            " AND os.oran_activo = 1" & _
            " AND sm.smac_activo = 1" & _
            " ) as cons" & _
                        " LEFT JOIN (SELECT oran_orden, oran_productoEstiloId, oran_naveId" & _
            " FROM Programacion.OrdenArticuloNaveSimulacion WHERE" & _
            " oran_simulacionId = " + idSimulacionMaestro.ToString + " AND" & _
            " oran_productoEstiloId = " + idEstilo.ToString & _
            "  AND oran_activo = 1)" & _
            " as subc on cons.proc_productoEstiloId= subc.oran_productoEstiloId AND cons.linp_idNave = subc.oran_naveId" & _
            " ORDER BY subc.oran_orden, cons.prna_orden"
        Else
            cadena += " ORDER BY pn.prna_orden"
        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaExistenciaCapacidadParesXArticuloAnioSimulacion(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                           ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32, ByVal idSimulacionMaestro As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "SELECT 'Pares' Tipo, proc_prodID,	prog_linpID, proc_linpID, linp_idNave, Nave, DescripcionCompleta,"

        If semanaFin >= semanaInicio Then
            For i As Int32 = semanaInicio To semanaFin
                'cadena += "SUM([" + i.ToString + "]) [" + i.ToString + "], "
                cadena += "SUM([" + i.ToString + "_" + anioInicio.ToString + "]) [" + i.ToString + "_" + anioInicio.ToString + "], "
            Next
        Else
            For i As Int32 = semanaInicio To 52
                cadena += "SUM([" + i.ToString + "_" + anioInicio.ToString + "]) [" + i.ToString + "_" + anioInicio.ToString + "], "
            Next

            For i As Int32 = 1 To semanaFin
                cadena += "SUM([" + i.ToString + "_" + anioFin.ToString + "]) [" + i.ToString + "_" + anioFin.ToString + "], "
            Next
        End If

        cadena += " 9999 orden,	CAST(0 AS bit) muestras" & _
            " FROM (SELECT	proc_prodID, prog_linpID, proc_linpID, linp_idNave,	nave_nombre Nave, DescripcionCompleta"


        If semanaFin >= semanaInicio Then
            For i As Int32 = semanaInicio To semanaFin
                'cadena += ", programacion.fdu_pares_semana(" + anioInicio.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ") [" + i.ToString + "] "
                cadena += ", programacion.fdu_pares_semana_simulacion(" + anioInicio.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ", " + idSimulacionMaestro.ToString + ") [" + i.ToString + "_" + anioInicio.ToString + "] "
            Next
        Else
            For i As Int32 = semanaInicio To 52
                cadena += ", programacion.fdu_pares_semana_simulacion(" + anioInicio.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ", " + idSimulacionMaestro.ToString + ") [" + i.ToString + "_" + anioInicio.ToString + "] "
            Next
            For i As Int32 = 1 To semanaFin
                cadena += ", programacion.fdu_pares_semana_simulacion(" + anioFin.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ", " + idSimulacionMaestro.ToString + ") [" + i.ToString + "_" + anioFin.ToString + "] "
            Next
        End If

        cadena += " FROM Programacion.ProductosCapacidad pc " & _
            " INNER JOIN Programacion.LineasProduccion lp	ON lp.linp_linpID = pc.proc_linpID" & _
            " INNER JOIN Programacion.NavesAux na	ON na.nave_naveid = lp.linp_idNave" & _
            " LEFT JOIN Programacion.ProgramasRenglon pr ON pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
            " AND pr.prog_productoID = proc_prodID" & _
            " AND pr.prog_productoEstiloID = pc.proc_productoEstiloId" & _
            " AND pr.prog_tallaID = pc.proc_tallaID	" & _
            " AND pr.prog_linpID = pc.proc_linpID" & _
            " INNER JOIN vProductos vp ON vp.v_prodID = pc.proc_prodID" & _
            " AND vp.v_productoEstiloID = pc.proc_productoEstiloId" & _
            " AND vp.v_tallaID = pc.proc_tallaID" & _
            " WHERE pc.proc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
            " AND pc.proc_prodID = " + idProd.ToString & _
            " AND pc.proc_productoEstiloId = " + idEstilo.ToString & _
            " AND pc.proc_tallaID = " + idTalla.ToString & _
            " AND pc.proc_activo = 1" & _
            " AND lp.linp_activo = 1" & _
            " AND na.nave_activo = 1" & _
            " AND vp.prod_activo = 1" & _
            " AND vp.pres_activo = 1" & _
            " GROUP BY	pc.proc_prodID," & _
            " pr.prog_linpID," & _
            " pc.proc_linpID," & _
            " lp.linp_idNave," & _
            " na.nave_nombre," & _
            " vp.DescripcionCompleta) AS CONS" & _
            " GROUP BY	proc_prodID," & _
            " prog_linpID," & _
            " proc_linpID," & _
            " linp_idNave," & _
            " nave," & _
            " DescripcionCompleta"

        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function consultaCapacidadHormaXArticuloSimulacion(ByVal anio As Int32,
                                                           ByVal semana As Int32,
                                                           ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32,
                                                           ByVal idLinea As Int32,
                                                           ByVal idHorma As Int32,
                                                           ByVal idSimulacionMaestro As Int32,
                                                           ByVal cambioArticulo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        If cambioArticulo = True Then
            cadena = " SELECT TOP 1 * FROM ("
        End If


        'If semanaFin >= semanaInicio Then
        '    For i As Int32 = semanaInicio To semanaFin
        '        cadena += "((SELECT TOP 1 horc_" + i.ToString + " FROM Programacion.HormasCapacidad hcx WHERE hcx.horc_año = " + anioInicio.ToString & _
        '            " AND hcx.horc_hormaID = " + idHorma.ToString + " AND hcx.horc_linpID = " + idLinea.ToString & _
        '            " AND hcx.horc_tallaid = " + idTalla.ToString + " AND hcx.horc_activo = 1" & _
        '            " AND hcx.horc_hormapornaveid = hc.horc_hormapornaveid) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString & _
        '            ", lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + i.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs" & _
        '            " JOIN Programacion.ProductosCapacidad pc ON prs.prog_productoEstiloID = pc.proc_productoEstiloId AND prs.prog_tallaID = pc.proc_tallaID" & _
        '            " WHERE prs.prog_año = " + anioInicio.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_hormaid = " + idHorma.ToString & _
        '            " AND pc.proc_año = " + anioInicio.ToString + " AND pc.proc_linpID = " + idLinea.ToString + " AND pc.proc_hormaid = " + idHorma.ToString & _
        '            " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + " AND pc.proc_activo = 1), 0) AS horc_" + i.ToString + "_" + anioInicio.ToString + ","
        '    Next

        'Else
        '    For i As Int32 = semanaInicio To 52
        '        cadena += "((SELECT TOP 1 horc_" + i.ToString + " FROM Programacion.HormasCapacidad hcx WHERE hcx.horc_año = " + anioInicio.ToString & _
        '            " AND hcx.horc_hormaID = " + idHorma.ToString + " AND hcx.horc_linpID = " + idLinea.ToString & _
        '            " AND hcx.horc_tallaid = " + idTalla.ToString + " AND hcx.horc_activo = 1" & _
        '            " AND hcx.horc_hormapornaveid = hc.horc_hormapornaveid) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString & _
        '            ", lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + i.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs" & _
        '            " JOIN Programacion.ProductosCapacidad pc ON prs.prog_productoEstiloID = pc.proc_productoEstiloId AND prs.prog_tallaID = pc.proc_tallaID" & _
        '            " WHERE prs.prog_año = " + anioInicio.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_hormaid = " + idHorma.ToString & _
        '            " AND pc.proc_año = " + anioInicio.ToString + " AND pc.proc_linpID = " + idLinea.ToString + " AND pc.proc_hormaid = " + idHorma.ToString & _
        '            " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + " AND pc.proc_activo = 1), 0) AS horc_" + i.ToString + "_" + anioInicio.ToString + ","
        '    Next

        '    For i As Int32 = 1 To semanaFin
        '        cadena += "((SELECT TOP 1 horc_" + i.ToString + " FROM Programacion.HormasCapacidad hcx WHERE hcx.horc_año = " + anioFin.ToString & _
        '            " AND hcx.horc_hormaID = " + idHorma.ToString + " AND hcx.horc_linpID = " + idLinea.ToString & _
        '            " AND hcx.horc_tallaid = " + idTalla.ToString + " AND hcx.horc_activo = 1" & _
        '            " AND hcx.horc_hormapornaveid = hc.horc_hormapornaveid) * programacion.fdu_dias_trabajo_nave_semana(" + anioFin.ToString + ", " + i.ToString & _
        '            ", lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + i.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs" & _
        '            " JOIN Programacion.ProductosCapacidad pc ON prs.prog_productoEstiloID = pc.proc_productoEstiloId AND prs.prog_tallaID = pc.proc_tallaID" & _
        '             " WHERE prs.prog_año = " + anioFin.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_hormaid = " + idHorma.ToString & _
        '            " AND pc.proc_año = " + anioFin.ToString + " AND pc.proc_linpID = " + idLinea.ToString + " AND pc.proc_hormaid = " + idHorma.ToString & _
        '            " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + " AND pc.proc_activo = 1), 0) AS horc_" + i.ToString + "_" + anioFin.ToString + ","
        '    Next

        'End If

        cadena += "SELECT TOP 1"

        cadena += "(SELECT TOP 1 hc.horc_" + semana.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + semana.ToString & _
                    ", lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + semana.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs" & _
                    " JOIN Programacion.ProductosCapacidad pc ON prs.prog_productoEstiloID = pc.proc_productoEstiloId AND prs.prog_tallaID = pc.proc_tallaID" & _
                    " WHERE prs.prog_año = " + anio.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_año = " + anio.ToString + " AND pc.proc_linpID = " + idLinea.ToString + " AND pc.proc_hormaid = " + idHorma.ToString & _
                    " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + " AND pc.proc_activo = 1), 0) AS horc_" + semana.ToString + "_" + anio.ToString + "," & _
                    " v_hormaID,  descripcionCompleta FROM vProductos cp" & _
                    " INNER JOIN Programacion.HormasCapacidad hc ON cp.v_hormaID = hc.horc_hormaID AND cp.v_tallaID = hc.horc_tallaid " & _
                    " INNER JOIN Programacion.LineasProduccion lp	ON lp.linp_linpID = hc.horc_linpID " & _
                    " WHERE cp.pres_activo = 1 AND cp.prod_activo = 1 AND cp.v_productoEstiloID =  " + idEstilo.ToString & _
                    " AND cp.v_tallaID =  " + idTalla.ToString & _
                    " AND cp.v_hormaID = " + idHorma.ToString & _
                    " AND lp.linp_activo = 1 " & _
                    " AND lp.linp_linpID = " + idLinea.ToString & _
                    " AND hc.horc_activo = 1" & _
                    " AND hc.horc_hormaID = " + idHorma.ToString & _
                    " AND hc.horc_linpID = " + idLinea.ToString & _
                    " AND hc.horc_año = " + anio.ToString
        If cambioArticulo = True Then
            cadena += " UNION ALL" & _
        " Select (shc.smhc_" + semana.ToString + " * Programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ",  " + semana.ToString + " , lp.linp_idNave))" & _
        " - ISNULL((SELECT SUM(prs.prog_" + semana.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs" & _
        " JOIN Programacion.ProductosCapacidad pc ON prs.prog_productoEstiloID = pc.proc_productoEstiloId AND prs.prog_tallaID = pc.proc_tallaID" & _
        " WHERE prs.prog_año =" + anio.ToString & _
        " AND prs.prog_linpID = " + idLinea.ToString & _
        " AND prs.prog_hormaid = " + idHorma.ToString & _
        " AND pc.proc_año = " + anio.ToString & _
        " AND pc.proc_linpID = " + idLinea.ToString & _
        " AND pc.proc_hormaid = " + idHorma.ToString & _
        " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString & _
        " AND pc.proc_activo = 1), 0) AS horc_" + semana.ToString + "_" + anio.ToString + "," & _
        " v_hormaID," & _
        " descripcionCompleta" & _
        " FROM vProductos cp" & _
        " INNER JOIN Programacion.simulacionHormasCapacidad shc ON cp.v_hormaID = shc.smhc_hormaId AND cp.v_tallaID = shc.smhc_tallaid " & _
        " INNER JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = shc.smhc_lineaId" & _
        " WHERE cp.pres_activo = 1" & _
        " AND cp.prod_activo = 1" & _
        " AND cp.v_productoEstiloID = " + idEstilo.ToString & _
        " AND cp.v_tallaID =" + idTalla.ToString & _
        " AND cp.v_hormaID = " + idHorma.ToString & _
        " AND lp.linp_activo = 1" & _
        " AND lp.linp_linpID = " + idLinea.ToString & _
        " AND shc.smhc_activo = 1" & _
        " AND shc.smhc_hormaId = " + idHorma.ToString & _
        " AND shc.smhc_lineaId = " + idLinea.ToString & _
        " AND shc.smhc_anio = " + anio.ToString & _
        " AND shc.smhc_simulacionId = " + idSimulacionMaestro.ToString + " ) AS CONS"
        End If
        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function consultaCapacidadLineaProduccionGruposXArticuloSimulacion(ByVal anio As Int32,
                                                   ByVal semana As Int32,
                                                   ByVal idEstilo As Int32,
                                                   ByVal idTalla As Int32,
                                                   ByVal idLinea As Int32,
                                                   ByVal idGrupo As Int32,
                                                   ByVal idSimulacionMaestro As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT"

        ''If semanaFin >= semanaInicio Then

        ''    For i As Int32 = semanaInicio To semanaFin
        ''        cadena += " (gcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + i.ToString + ")" & _
        ''            " FROM Programacion.SimulacionProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
        ''            " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + anioInicio.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + anioInicio.ToString & _
        ''            " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
        ''            " vpx.pres_activo = 1 AND vpx.idGrupo = " + idGrupo.ToString + " AND prx.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0) AS gcap_" + i.ToString + "_" + anioInicio.ToString + ","
        ''    Next

        ''Else
        ''    For i As Int32 = semanaInicio To 52
        ''        cadena += " (gcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + i.ToString + ")" & _
        ''            " FROM Programacion.SimulacionProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
        ''            " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + anioInicio.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + anioInicio.ToString & _
        ''            " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
        ''            " vpx.pres_activo = 1 AND vpx.idGrupo =  " + idGrupo.ToString + " AND prx.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0) AS gcap_" + i.ToString + "_" + anioInicio.ToString + ","
        ''    Next

        ''    For i As Int32 = 1 To semanaFin
        ''        cadena += " (gcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + semanaFin.ToString + ", " + i.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + i.ToString + ")" & _
        ''            " FROM Programacion.SimulacionProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
        ''            " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + semanaFin.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + semanaFin.ToString & _
        ''            " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
        ''            " vpx.pres_activo = 1 AND vpx.idGrupo =  " + idGrupo.ToString + " AND prx.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0) AS gcap_" + i.ToString + "_" + semanaFin.ToString + ","
        ''    Next

        ''End If

        cadena += " (gcap_" + semana.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + semana.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + semana.ToString + ")" & _
                   " FROM Programacion.SimulacionProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
                   " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + anio.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + anio.ToString & _
                   " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
                   " vpx.pres_activo = 1 AND vpx.idGrupo = " + idGrupo.ToString + " AND prx.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0) AS gcap_" + semana.ToString + "_" + anio.ToString + ","

        cadena += " idGrupo," & _
        " vp.prod_descripcion" & _
        " FROM vProductoEstilos vp" & _
        " INNER JOIN Programacion.GruposCapacidad gc ON vp.idGrupo = gc.gcap_grupoID" & _
        " JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = gc.gcap_linpID" & _
        " WHERE vp.pres_activo = 1" & _
        " AND vp.pres_activo = 1" & _
        " AND vp.pstilo = " + idEstilo.ToString & _
        " AND vp.idTalla = " + idTalla.ToString & _
        " AND vp.idGrupo = " + idGrupo.ToString & _
        " AND lp.linp_activo = 1" & _
        " AND lp.linp_linpID = " + idLinea.ToString & _
        " AND gc.gcap_activo = 1" & _
        " AND gcap_linpID = " + idLinea.ToString & _
        " AND gcap_grupoID = " + idGrupo.ToString & _
        " AND gc.gcap_año = " + anio.ToString

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaCapacidadLineaProduccionCelulaXArticuloSimulacion(ByVal anio As Int32,
                                                                    ByVal semana As Int32,
                                                                    ByVal idLinea As Int32,
                                                                    ByVal idSimulacionMaestro As Int32,
                                                                    ByVal limiteCapacidad As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT TOP 1"

        ''If semanaFin >= semanaInicio Then
        ''    For i As Int32 = semanaInicio To semanaFin
        ''        'cadena += "(lcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + i.ToString + " , linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr WHERE pr.prog_año = " + anio.ToString + " AND pr.prog_linpID = " + idLinea.ToString + "), 0) lcap_" + i.ToString + ", "
        ''        cadena += "((((SELECT lpx.lcap_" + i.ToString + " FROM Programacion.LineasProduccionCapacidad lpx WHERE lpx.lcap_linpID = " + idLinea.ToString + " AND lpx.lcap_año = " + anioInicio.ToString + " AND lpx.lcap_activo = 1) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + i.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs WHERE prs.prog_año = " + anioInicio.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0)) "
        ''        If limiteCapacidad = True Then
        ''            cadena += " - ISNULL((SELECT" & _
        ''            " CASE WHEN lmc.lmtc_porcentaje = 0 THEN lmc.lmtc_cantidad * lmc.lmtc_dias" & _
        ''            " ELSE FLOOR(((CAST(lnpx.lcap_" + i.ToString + " as float) / 100) * lmc.lmtc_cantidad) * lmc.lmtc_dias)" & _
        ''            " END AS lmt" & _
        ''            " FROM Programacion.LimiteCapacidad lmc" & _
        ''            " JOIN Programacion.LineasProduccionCapacidad lnpx ON lmc.lmtc_lineaId = lnpx.lcap_linpID" & _
        ''            " AND lmc.lmtc_anio = lnpx.lcap_año AND lmc.lmtc_semana = " + i.ToString & _
        ''            " WHERE lmc.lmtc_lineaId = " + idLinea.ToString + " And lmc.lmtc_simulacionMaestroId = " + idSimulacionMaestro.ToString & _
        ''            " AND lmc.lmtc_semana = " + i.ToString + " AND lmc.lmtc_anio = " + anioInicio.ToString + "), 0)"
        ''        End If
        ''        cadena += ") lcap_" + i.ToString + "_" + anioInicio.ToString + ","
        ''    Next
        ''Else
        ''    For i As Int32 = semanaInicio To 52
        ''        cadena += "((((SELECT lpx.lcap_" + i.ToString + " FROM Programacion.LineasProduccionCapacidad lpx WHERE lpx.lcap_linpID = " + idLinea.ToString + " AND lpx.lcap_año = " + anioInicio.ToString + " AND lpx.lcap_activo = 1) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + i.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs WHERE prs.prog_año = " + anioInicio.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0)) "
        ''        If limiteCapacidad = True Then
        ''            cadena += " - ISNULL((SELECT" & _
        ''           " CASE WHEN lmc.lmtc_porcentaje = 0 THEN lmc.lmtc_cantidad * lmc.lmtc_dias" & _
        ''           " ELSE FLOOR(((CAST(lnpx.lcap_" + i.ToString + " as float) / 100) * lmc.lmtc_cantidad) * lmc.lmtc_dias)" & _
        ''           " END AS lmt" & _
        ''           " FROM Programacion.LimiteCapacidad lmc" & _
        ''           " JOIN Programacion.LineasProduccionCapacidad lnpx ON lmc.lmtc_lineaId = lnpx.lcap_linpID" & _
        ''           " AND lmc.lmtc_anio = lnpx.lcap_año AND lmc.lmtc_semana = " + i.ToString & _
        ''           " WHERE lmc.lmtc_lineaId = " + idLinea.ToString + " And lmc.lmtc_simulacionMaestroId = " + idSimulacionMaestro.ToString & _
        ''           " AND lmc.lmtc_semana = " + i.ToString + " AND lmc.lmtc_anio = " + anioInicio.ToString + "), 0)"
        ''        End If
        ''        cadena += ") lcap_" + i.ToString + "_" + anioInicio.ToString + ","
        ''    Next

        ''    For i As Int32 = 1 To semanaFin
        ''        cadena += "((((SELECT lpx.lcap_" + i.ToString + " FROM Programacion.LineasProduccionCapacidad lpx WHERE lpx.lcap_linpID = " + idLinea.ToString + " AND lpx.lcap_año = " + anioFin.ToString + " AND lpx.lcap_activo = 1) * programacion.fdu_dias_trabajo_nave_semana(" + anioFin.ToString + ", " + i.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + i.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs WHERE prs.prog_año = " + anioFin.ToString + " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0)) "
        ''        If limiteCapacidad = True Then
        ''            cadena += " - ISNULL((SELECT" & _
        ''                       " CASE WHEN lmc.lmtc_porcentaje = 0 THEN lmc.lmtc_cantidad * lmc.lmtc_dias" & _
        ''                       " ELSE FLOOR(((CAST(lnpx.lcap_" + i.ToString + " as float) / 100) * lmc.lmtc_cantidad) * lmc.lmtc_dias)" & _
        ''                       " END AS lmt" & _
        ''                       " FROM Programacion.LimiteCapacidad lmc" & _
        ''                       " JOIN Programacion.LineasProduccionCapacidad lnpx ON lmc.lmtc_lineaId = lnpx.lcap_linpID" & _
        ''                       " AND lmc.lmtc_anio = lnpx.lcap_año AND lmc.lmtc_semana = " + i.ToString & _
        ''                       " WHERE lmc.lmtc_lineaId = " + idLinea.ToString + " And lmc.lmtc_simulacionMaestroId = " + idSimulacionMaestro.ToString & _
        ''                       " AND lmc.lmtc_semana = " + i.ToString + " AND lmc.lmtc_anio = " + anioFin.ToString + "), 0)"
        ''        End If
        ''        cadena += ") lcap_" + i.ToString + "_" + anioFin.ToString + ","
        ''    Next
        ''End If

        cadena += "(((lpc.lcap_" + semana.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString & _
            ", " + semana.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(prs.prog_" + semana.ToString + ") FROM Programacion.SimulacionProgramasRenglon prs WHERE prs.prog_año = " + anio.ToString & _
            " AND prs.prog_linpID = " + idLinea.ToString + " AND prs.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString + "), 0)) "
        If limiteCapacidad = True Then
            cadena += " - ISNULL((SELECT" & _
                       " CASE WHEN lmc.lmtc_porcentaje = 0 THEN lmc.lmtc_cantidad * lmc.lmtc_dias" & _
                       " ELSE FLOOR(((CAST(lnpx.lcap_" + semana.ToString + " as float) / 100) * lmc.lmtc_cantidad) * lmc.lmtc_dias)" & _
                       " END AS lmt" & _
                       " FROM Programacion.LimiteCapacidad lmc" & _
                       " JOIN Programacion.LineasProduccionCapacidad lnpx ON lmc.lmtc_lineaId = lnpx.lcap_linpID" & _
                       " AND lmc.lmtc_anio = lnpx.lcap_año AND lmc.lmtc_semana = " + semana.ToString & _
                       " WHERE lmc.lmtc_lineaId = " + idLinea.ToString + " And lmc.lmtc_simulacionMaestroId = " + idSimulacionMaestro.ToString & _
                       " AND lmc.lmtc_semana = " + semana.ToString + " AND lmc.lmtc_anio = " + anio.ToString + "), 0)"
        End If
        cadena += ") lcap_" + semana.ToString + "_" + anio.ToString + ","

        cadena += "  0 a FROM Programacion.LineasProduccionCapacidad lpc" & _
         " INNER JOIN Programacion.LineasProduccion lp ON linp_linpID = lcap_linpID " & _
         " WHERE lcap_año = " + anio.ToString + " AND lcap_linpID = " + idLinea.ToString + " AND lp.linp_activo = 1 AND lpc.lcap_activo = 1"

        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Sub guardarRenglonSimulacion(ByVal programaID As Int32, ByVal naveID As Int32, ByVal linpID As Int32, ByVal productoID As Int32,
                                        ByVal productoEstiloID As Int32, ByVal tallaID As Int32, ByVal IdPedido As Int32, ByVal IdRenglon As Int32,
                                        ByVal idLote As Int32, ByVal pdetID As Int32, ByVal anio As Int32, ByVal semana As Int32,
                                        ByVal idCadena As Int32, ByVal fecha_Entrega As String, ByVal pares_apartado As Int32,
                                        ByVal idCliente As Int32, ByVal hormaid As Int32, ByVal ProcSimuladorMaestroID As Int32,
                                        ByVal entregaCliente As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO programacion.SimulacionProgramasRenglon (" & _
        " prog_programaID, prog_naveID, prog_linpID, prog_productoID," & _
        " prog_productoEstiloID, prog_tallaID, prog_IdPedido, prog_IdRenglon," & _
        " prog_idLote, prog_pdetID, prog_año, prog_" + semana.ToString + "," & _
        " prog_idCadena, prog_fechaEntregaPedido, prog_pares_apartado, prog_semana," & _
        " prog_fechaCreacion, prog_usuarioCreo, prog_idCliente, prog_hormaid," & _
        " prog_ProcSimuladorMaestroID, prog_fechaCliente)" & _
        " VALUES(" & _
        " NULL, '" + naveID.ToString + "', '" + linpID.ToString + "', '" + productoID.ToString + "'," & _
        " '" + productoEstiloID.ToString + "', '" + tallaID.ToString + "', '" + IdPedido.ToString + "', '" + IdRenglon.ToString + "'," & _
        " '" + idLote.ToString + "', '" + pdetID.ToString + "', '" + anio.ToString + "', '" + pares_apartado.ToString + "'," & _
        " '" + idCadena.ToString + "', '" + CDate(fecha_Entrega.ToString).ToShortDateString + "', '" + pares_apartado.ToString + "', '" + semana.ToString + "'," & _
        " GETDATE(), '" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + "', '" + idCliente.ToString + "', '" + hormaid.ToString + "'," & _
        " '" + ProcSimuladorMaestroID.ToString + "', '" + CDate(entregaCliente).ToShortDateString + "')"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaSimulaciones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
            SELECT
            ProcSimMae_ProcSimuladorID,
            ProcSimMae_Descripcion,
            ProcSimMae_RangoSemanaInicio,
            ProcSimMae_RangoSemanaFin,
            ProcSimMae_RangoAnioInicio,
            ProcSimMae_RangoAnioFin,
            ProcSimMae_Estatus
            FROM Programacion.ProcesoSimulacionMaestro
            WHERE ProcSimMae_Estatus = 1
            ORDER BY ProcSimMae_FechaCreo DESC</cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub truncarTablaTemporalSimulacion()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "TRUNCATE TABLE Programacion.tmpSimulacionProc"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub truncarTablaSimulacionProceso()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "TRUNCATE TABLE Programacion.SimulacionProgramasRenglon"
        operacion.EjecutaSentencia(cadena)
    End Sub

    'Public Sub ordenarTablaTemporalSimulacion(ByVal opcion As Int32, ByVal idSimulacion As Int32)
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlClient.SqlParameter)

    '    Dim parametro As New SqlClient.SqlParameter
    '    parametro.ParameterName = "@opcionSimulador"
    '    parametro.Value = opcion
    '    listaParametros.Add(parametro)

    '    parametro = New SqlClient.SqlParameter
    '    parametro.ParameterName = "@simuIacionMaestroID"
    '    parametro.Value = idSimulacion
    '    listaParametros.Add(parametro)

    '    parametro = New SqlClient.SqlParameter
    '    parametro.ParameterName = "@usuario"
    '    parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    '    listaParametros.Add(parametro)

    '    operacion.EjecutarSentenciaSP("Programacion.SP_llenarTablaOrdenSimulacion", listaParametros)

    'End Sub

    Public Sub construirConsulta(ByVal opciones As Int32(), ByVal idSimulacion As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.tmpSimulacionProc(tmpSim_FechaPedido," & _
            " tmpSim_SimBloqueo, tmpSim_naveID, tmpSim_linpID," & _
            " tmpSim_productoID, tmpSim_productoEstiloID, tmpSim_tallaID," & _
            " tmpSim_IdPedido, tmpSim_IdRenglon, tmpSim_idLote," & _
            " tmpSim_Cantidad," & _
            " tmpSim_anio, tmpSim_tipo, tmpSim_idCadena," & _
            " tmpSim_cerrado, tmpSim_fechaCreacion, tmpSim_usuarioCreo," & _
            " tmpSim_idCliente, tmpSim_hormaid, tmpSim_ProgSemana," & _
            " tmpSim_ProgramaRenglonId, tmpSim_fechaCliente) SELECT pr.prog_fechaEntregaPedido," & _
            " 0, pr.prog_naveID, pr.prog_linpID, pr.prog_productoID, pr.prog_productoEstiloID, pr.prog_tallaID," & _
            " pr.prog_IdPedido, pr.prog_IdRenglon, pr.prog_idLote," & _
            " SUM(pr.prog_1 + pr.prog_2 + pr.prog_3 + pr.prog_4 + pr.prog_5 + pr.prog_6 + pr.prog_7 + pr.prog_8 +" & _
            " pr.prog_9 + pr.prog_10 + pr.prog_11 + pr.prog_12 + pr.prog_13 + pr.prog_14 + pr.prog_15 + pr.prog_16 +" & _
            " pr.prog_17 + pr.prog_18 + pr.prog_19 + pr.prog_20 + pr.prog_21 + pr.prog_22 + pr.prog_23 + pr.prog_24 +" & _
            " pr.prog_25 + pr.prog_26 + pr.prog_27 + pr.prog_28 + pr.prog_29 + pr.prog_30 + pr.prog_31 + pr.prog_32 +" & _
            " pr.prog_33 + pr.prog_34 + pr.prog_35 + pr.prog_36 + pr.prog_37 + pr.prog_38 + pr.prog_39 + pr.prog_40 +" & _
            " pr.prog_41 + pr.prog_42 + pr.prog_43 + pr.prog_44 + pr.prog_45 + pr.prog_46 + pr.prog_47 + pr.prog_48 +" & _
            " pr.prog_49 + pr.prog_50 + pr.prog_51 + pr.prog_52) AS Cantidad," & _
        " pr.prog_año, pr.prog_tipo, pr.prog_idCadena, pr.prog_cerrado, GETDATE(), 1, pr.prog_idCliente," & _
        " pr.prog_hormaid, pr.prog_semana, pr.prog_programaID, pr.prog_fechaCliente" & _
            " FROM Programacion.ProgramasRenglon pr"

        Dim complementoGroup As String = ""
        Dim complementoOrder As String = ""

        For Each opcion As Int32 In opciones
            If opcion = 2 Then
                cadena += " LEFT JOIN Programacion.SimulacionClientesEspeciales sc ON pr.prog_idCadena = sc.cesp_idCadena AND sc.cesp_simuIacionMaestroID = " + idSimulacion.ToString
                complementoGroup += ", sc.cesp_orden"
                complementoOrder += " ISNULL(sc.cesp_orden, 9999),"

            ElseIf opcion = 4 Then
                cadena += " LEFT JOIN Programacion.SimulacionClasificacionRanking scr ON pr.prog_idCadena = scr.sirc_cadenaId AND scr.sirc_simulacionMaestroId = " + idSimulacion.ToString
                complementoGroup += ", sirc_Clasificacion, sirc_Ranking"
                complementoOrder += " ISNULL(sirc_Clasificacion, 'Z'), ISNULL(sirc_Ranking, '9999'),"

            ElseIf opcion = 5 Then
                complementoOrder += " pr.prog_fechaEntregaPedido,"

            ElseIf opcion = 6 Then
                complementoOrder += " pr.prog_fechaCliente,"

            ElseIf opcion = 7 Then
                cadena += " LEFT JOIN Programacion.ordenNavesAux orn ON ORN.onax_naveAuxId = pr.prog_naveID AND  ORN.onax_activo = 1 AND ORN.onax_simulacionMaestroId = " + idSimulacion.ToString
                complementoGroup += ", orn.onax_orden"
                complementoOrder += "  ISNULL(orn.onax_orden, 9999),"

            ElseIf opcion = 8 Then
                cadena += " LEFT JOIN Programacion.ArticulosPreferentes ap ON pr.prog_productoEstiloID = ap.arpr_productoEstiloId AND ap.arpr_activo = 1 AND ap.arpr_simulacionMaestroID = " + idSimulacion.ToString
                complementoGroup += ", ap.arpr_orden"
                complementoOrder += "  ISNULL(ap.arpr_orden, 9999),"

            End If
        Next
        cadena += " GROUP BY pr.prog_fechaEntregaPedido, pr.prog_naveID, pr.prog_linpID, pr.prog_productoID, pr.prog_productoEstiloID, " & _
            " pr.prog_tallaID, pr.prog_IdPedido, pr.prog_IdRenglon, pr.prog_idLote, pr.prog_año, pr.prog_tipo, pr.prog_idCadena, " & _
            " pr.prog_cerrado, pr.prog_idCliente, pr.prog_hormaid, pr.prog_semana, pr.prog_programaID, pr.prog_fechaCliente" + complementoGroup

        cadena += " ORDER BY " + complementoOrder + " pr.prog_programaID"

         operaciones.EjecutaSentencia(cadena)


    End Sub

    Public Sub cargaInicialCatalogos(ByVal idSimulacion As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idSimulacionMaestro"
        parametro.Value = idSimulacion
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_CargaInicialPorOpcion", listaParametros)

    End Sub

    Public Function consultaListaClientesRankingSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
        SELECT
        tmpSim_ProgramaRenglonId,
        sp.tmpSim_IdPedido,
        sp.tmpSim_FechaPedido,	
        sp.tmpSim_idCadena,
        sp.tmpSim_idCliente,
        cl.clie_nombregenerico,
        sp.tmpSim_productoEstiloID,
        vpe.prod_descripcion + ' ' + vpe.pielColor + ' ' + vpe.talla AS Producto,
        sp.tmpSim_Cantidad,
        sp.tmpSim_anio,
        sp.tmpSim_tipo,
        sp.tmpSim_IdRenglon,
        sp.tmpSim_idLote,
        sp.tmpSim_linpID,
        sp.tmpSim_naveID,
        lp.linp_nombre,
        n.nave_nombre,
        sp.tmpSim_ProgSemana,
        sp.tmpSim_fechaCreacion
        FROM Programacion.tmpSimulacionProc sp
        JOIN Cliente.Cliente cl	ON sp.tmpSim_idCadena = cl.clie_idsicy
        JOIN vProductoEstilos vpe ON sp.tmpSim_productoEstiloID = vpe.pstilo
        JOIN Programacion.NavesAux n ON sp.tmpSim_naveID = n.nave_naveid
        JOIN Programacion.LineasProduccion lp ON sp.tmpSim_linpID = lp.linp_linpID AND sp.tmpSim_naveID = lp.linp_idNave
                 </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Sub guardarOpcionSimulacion(ByVal idSimulacion As Int32, ByVal idOpcion As Int32, ByVal idConfiguracion As Int32, ByVal orden As Int32)
        'CREATE PROCEDURE Programacion.SP_guardarConfiguracionOpcionSimulacion 
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParamtros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idSimulacionMaestro"
        parametro.Value = idSimulacion
        listaParamtros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idOpcion"
        parametro.Value = idOpcion
        listaParamtros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idConfiguracion"
        If idConfiguracion.ToString > 0 Then
            parametro.Value = idConfiguracion
        Else
            parametro.Value = DBNull.Value
        End If
        listaParamtros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@orden"
        parametro.Value = orden
        listaParamtros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParamtros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_guardarConfiguracionOpcionSimulacion", listaParamtros)
    End Sub

    Public Function consultaSimulacionMaestro() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT TOP 10 " & _
        " ProcSimMae_ProcSimuladorID," & _
        " ProcSimMae_Descripcion," & _
        " ProcSimMae_RangoSemanaInicio," & _
        " ProcSimMae_RangoSemanaFin," & _
        " ProcSimMae_RangoAnioInicio," & _
        " ProcSimMae_RangoAnioFin," & _
        " ProcSimMae_Estatus," & _
        " ProcSimMae_VerTodo" & _
        " FROM Programacion.ProcesoSimulacionMaestro" & _
        " ORDER BY ProcSimMae_Estatus DESC, ProcSimMae_ProcSimuladorID DESC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub moverDatosTablaHist(ByVal idSimulacion As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idSimulacion"
        parametro.Value = idSimulacion.ToString
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        listaParametros.Add(parametro)

        operacion.EjecutarConsultaSP("Programacion.SP_PasarTablaSimulacionProgramasRenglon", listaParametros)
    End Sub

    Public Function consultaFoliosSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT sm.ProcSimMae_ProcSimuladorID," & _
        " sf.sprf_simulacionFolioId, sf.sprf_folio, " & _
        " sm.ProcSimMae_Descripcion+' - Folio: '+CAST(sf.sprf_folio AS varchar(5)) AS 'Descripcion'" & _
        " FROM Programacion.ProcesoSimulacionMaestro sm" & _
        " JOIN Programacion.simulacionFolio sf" & _
        " ON sm.ProcSimMae_ProcSimuladorID = sf.sprf_simulacionMaestroId" & _
        " WHERE sf.sqrf_activo = 1" & _
        " ORDER BY sm.ProcSimMae_ProcSimuladorID DESC, sf.sprf_folio DESC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub eliminarSimulacion(ByVal idSimulacion As Int32, ByVal folio As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idSimulacion"
        parametro.Value = idSimulacion.ToString
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@folio"
        parametro.Value = folio.ToString
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_EliminarSimulacionHist", listaParametros)
    End Sub

    Public Sub quitarPedidosPendientesTmpSimulacion()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena = ""
        cadena = "DELETE FROM Programacion.tmpSimulacionProc WHERE tmpSim_IdPedido IN (" & _
                    "SELECT IdPedido FROM Programacion.vw_PedidosConfirmadosSinApartar)"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub insertarDatosProgramasRenglonSimulador_SinSimular(ByVal idSimulacion As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlClient.SqlParameter
        parametro.ParameterName = "@idSumulacionMaestroId"
        parametro.Value = idSimulacion.ToString
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Programacion.SP_PasarPedidosProgramasRenglon_A_Simulacion", listaParametros)

    End Sub

    Public Function consultaSimulacionPorSemana(ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                     ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                     ByVal idNave As Int32, ByVal idLinea As Int32,
                                                     ByVal idFolio As Int32, ByVal idSimulacion As Int32,
                                                     ByVal VerSoloConCantidad As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" & _
                " c.clie_clienteid, pr.prog_idCadena, c.clie_nombregenerico, prog_naveID, n.nave_nombre 'Nave', prog_linpID," & _
                " lp.linp_nombre 'Linea', pr.prog_productoID, pr.prog_productoEstiloID,	pr.prog_tallaID," & _
                " vp.prod_descripcion + ' ' + vp.pielColor + ' ' + vp.talla 'Producto'," & _
                " pr.prog_hormaid, vp.Horma, pr.prog_IdPedido, pr.prog_idLote, pr.prog_fechaEntregaPedido, pr.prog_fechaCliente," & _
                " pr.prog_año, pr.prog_semana"
        If VerSoloConCantidad = False Then
            cadena += ", pr.prog_1, pr.prog_2, pr.prog_3, pr.prog_4, pr.prog_5, pr.prog_6, pr.prog_7, pr.prog_8, pr.prog_9, pr.prog_10," & _
                            " pr.prog_11, pr.prog_12, pr.prog_13, pr.prog_14, pr.prog_15, pr.prog_16, pr.prog_17, pr.prog_18, pr.prog_19, pr.prog_20," & _
                            " pr.prog_21, pr.prog_22, pr.prog_23, pr.prog_24, pr.prog_25, pr.prog_26, pr.prog_27, pr.prog_28, pr.prog_29, pr.prog_30," & _
                            " pr.prog_31, pr.prog_32, pr.prog_33, pr.prog_34, pr.prog_35, pr.prog_36, pr.prog_37, pr.prog_38, pr.prog_39, pr.prog_40," & _
                            " pr.prog_41, pr.prog_42, pr.prog_43, pr.prog_44, pr.prog_45, pr.prog_46, pr.prog_47, pr.prog_48, pr.prog_49, pr.prog_50," & _
                            " pr.prog_51, pr.prog_52"
        Else
            For i As Int32 = semanaInicio To semanaFin
                cadena += ", pr.prog_" + i.ToString
            Next
        End If


        cadena += " FROM Programacion.SimulacionProgramasRenglonHist pr" & _
        " JOIN Cliente.Cliente c ON pr.prog_idCliente = c.clie_clienteid" & _
        " JOIN vProductoEstilos vp ON pr.prog_productoEstiloID = vp.pstilo" & _
        " JOIN Programacion.NavesAux n ON pr.prog_naveID = n.nave_naveid" & _
        " JOIN Programacion.LineasProduccion lp ON pr.prog_naveID = lp.linp_idNave	AND pr.prog_linpID = lp.linp_linpID" & _
                " WHERE c.clie_activo = 1" & _
        " And lp.linp_activo = 1" & _
                " AND n.nave_activo = 1" & _
                " AND pr.prog_semana BETWEEN " + semanaInicio.ToString + " AND " + semanaFin.ToString & _
                " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString

        If idNave > 0 Then
            cadena += " AND pr.prog_naveID = " + idNave.ToString
        End If

        If idLinea > 0 Then
            cadena += " AND pr.prog_linpID =" + idLinea.ToString
        End If

        cadena += " AND pr.prog_folio = " + idFolio.ToString & _
            " AND prog_ProcSimuladorMaestroID = " + idSimulacion.ToString & _
            " ORDER BY pr.prog_año, pr.prog_semana, prog_naveID, prog_linpID"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaEstatusSimulacionActual() As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim dato As Boolean = False
        cadena = "SELECT opci_valor_booleano FROM Programacion.Opciones WHERE opci_descripcion = 'estadoSimulacionActual'"
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            dato = CBool(dt.Rows(0).Item(0).ToString)
        End If
        Return dato
    End Function

    Public Sub editarEstatusSimulacionActual(ByVal valorBool As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.Opciones SET opci_valor_booleano = '" + valorBool.ToString + "'" & _
            ", opci_usuariomodificaid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            " , opci_fechamodificacion = GETDATE() WHERE opci_descripcion = 'estadoSimulacionActual'"
        operacion.EjecutaConsulta(cadena)
    End Sub

    Public Function consultaPermisoSimulador() As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim dato As Boolean = False
        cadena = "SELECT" & _
                " CASE" & _
                    " WHEN COUNT(paus_pausID) IS NULL THEN CAST(0 AS bit)" & _
                    " ELSE CAST(1 AS bit)" & _
                " END AS tienePersmiso" & _
                    " FROM Programacion.ProgramacionAutomaticaUsuarios" & _
            " WHERE paus_usuarioID = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            dato = CBool(dt.Rows(0).Item(0).ToString)
        End If
        Return dato
    End Function

    '' ------------------------------------------------------------------------------------------------->

    Public Function consultaExistenciaCapacidadArticuloAnioSimulacion(ByVal idSimulacionMaestro As Int32, ByVal simularCambio As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "SELECT ROW_NUMBER() OVER (ORDER BY id DESC) AS filaId, Tipo, proc_linpID, linp_idNave, Nave,"


        For i As Int32 = 1 To 52
            cadena += "Semana_" + i.ToString + ","
        Next

        If simularCambio = True Then
            cadena += " ISNULL((SELECT TOP 1 oran_orden FROM Programacion.OrdenArticuloNaveSimulacion  ora WHERE ora.oran_activo = 1 AND ora.oran_simulacionId = " + idSimulacionMaestro.ToString + " AND ora.oran_productoEstiloId = cons.proc_productoEstiloId AND ora.oran_naveId= cons.linp_idNave), cons.prna_orden) as prna_orden,"
        Else
            cadena += " prna_orden,	"
        End If


        cadena += "prna_muestras,	proc_prodID,	proc_productoEstiloId,	proc_tallaID,	proc_año"

        If simularCambio = True Then
            cadena += ", smac_tipoAlta, lineaOrigen"
        End If

        cadena += " FROM ( SELECT  0 AS id, 'Capacidad' Tipo,  pc.proc_linpID, lp.linp_idNave, na.nave_nombre Nave,"
        For i As Int32 = 1 To 52
            cadena += " (pc.proc_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = pc.proc_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0)) Semana_" + i.ToString + ","
            '(SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = pc.proc_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave))
        Next

        cadena += " prna_orden, prna_muestras, pc.proc_prodID,  pc.proc_productoEstiloId, proc_tallaID, pc.proc_año"

      


        If simularCambio = True Then
            cadena += " , 0 smac_tipoAlta, 0 lineaOrigen"
        End If


        cadena += " FROM Programacion.ProductosCapacidad pc" & _
        " INNER JOIN Programacion.LineasProduccion lp ON linp_linpID = proc_linpID" & _
        " INNER JOIN Programacion.ProductosNave pn ON pn.prna_productoID = pc.proc_prodID" & _
        " AND pn.prna_productoEstiloID = pc.proc_productoEstiloId AND pc.proc_tallaID = pn.prna_tallaID AND pn.prna_naveID = lp.linp_idNave" & _
        " AND pn.prna_hormaid = pc.proc_hormaid" & _
        " INNER JOIN Programacion.NavesAux na ON nave_naveid = linp_idNave" & _
        " INNER JOIN vProductos vp ON vp.v_prodID = pc.proc_prodID	AND vp.v_productoEstiloID = pc.proc_productoEstiloId" & _
        " AND vp.v_tallaID = pc.proc_tallaID	AND vp.v_hormaID = PC.proc_hormaid" & _
        " WHERE pc.proc_activo = 1" & _
        " AND lp.linp_activo = 1 AND pn.prna_activo = 1 AND na.nave_activo = 1 AND vp.prod_activo = 1" & _
        " AND vp.pres_activo = 1" & _
        " AND pc.proc_productoEstiloId IN (SELECT DISTINCT(tmpSim_productoEstiloID) FROM Programacion.tmpSimulacionProc)" & _
        " GROUP BY	pc.proc_prodID, pc.proc_linpID, lp.linp_idNave, pn.prna_orden, pn.prna_muestras, na.nave_nombre," & _
        " DescripcionCompleta, pc.proc_productoEstiloId, pc.proc_tallaID, pc.proc_año," & _
        " pc.proc_1, pc.proc_2, pc.proc_3, pc.proc_4, pc.proc_5, pc.proc_6, pc.proc_7, pc.proc_8, pc.proc_9, pc.proc_10," & _
        " pc.proc_11, pc.proc_12, pc.proc_13, pc.proc_14, pc.proc_15, pc.proc_16, pc.proc_17, pc.proc_18, pc.proc_19, pc.proc_20," & _
        " pc.proc_21, pc.proc_22, pc.proc_23, pc.proc_24, pc.proc_25, pc.proc_26, pc.proc_27, pc.proc_28, pc.proc_29, pc.proc_30," & _
        " pc.proc_31, pc.proc_32, pc.proc_33, pc.proc_34, pc.proc_35, pc.proc_36, pc.proc_37, pc.proc_38, pc.proc_39, pc.proc_40," & _
        " pc.proc_41, pc.proc_42, pc.proc_43, pc.proc_44, pc.proc_45, pc.proc_46, pc.proc_47, pc.proc_48, pc.proc_49, pc.proc_50, pc.proc_51, pc.proc_52"


        If simularCambio = True Then
            cadena += " UNION ALL" & _
            " SELECT 0 AS id, 'Capacidad' Tipo, sm.smac_lineaId, lp.linp_idNave, na.nave_nombre Nave,"

            For i As Int32 = 1 To 52
                cadena += " (sm.smac_" + i.ToString
                cadena += " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = sm.smac_anio AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0)) Semana_" + i.ToString + ", "
            Next

            cadena += " na.nave_orden, 0 as muestras, sm.smac_productoId, sm.smac_productoEstiloId, sm.smac_tallaID, sm.smac_anio," & _
            " sm.smac_tipoAlta, ISNULL(sm.smac_artiuloCapacidadCopiaId, sm.smac_articuloCapacidadCambioId) lineaOrigen" & _
            " FROM Programacion.simulacionArticuloCapacidad sm" & _
            " JOIN Programacion.LineasProduccion lp ON sm.smac_lineaId = lp.linp_linpID" & _
            " JOIN Programacion.NavesAux na ON lp.linp_idNave = na.nave_naveid" & _
            " WHERE lp.linp_activo = 1" & _
            " AND na.nave_activo = 1" & _
            " AND sm.smac_activo = 1" & _
            " AND sm.smac_productoEstiloId IN (SELECT DISTINCT (tmpSim_productoEstiloID) FROM Programacion.tmpSimulacionProc)" & _
            " AND sm.smac_simulacionId = " + idSimulacionMaestro.ToString
        End If


        cadena += " ) cons ORDER BY cons.proc_año, cons.proc_productoEstiloId, cons.prna_orden"
        '" ORDER BY pc.proc_año, pc.proc_productoEstiloId, pn.prna_orden" & _



        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaExistenciaHormasCapacidadSimulacion(ByVal idSimulacionMaestro As Int32, ByVal simularCambio As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = " SELECT  ROW_NUMBER() OVER (ORDER BY id DESC) AS filaId, horc_tallaid, horc_hormaID, horc_linpID,"
        For i As Int32 = 1 To 52
            cadena += " horc_Semana_" + i.ToString + ", "
        Next
        cadena += " horc_año"
        cadena += " FROM (SELECT  0 AS id, " & _
        " hc.horc_tallaid, hc.horc_hormaID, hc.horc_linpID, "
        For i As Int32 = 1 To 52
            cadena += " (SELECT TOP 1 hc.horc_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = hc.horc_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0)) AS horc_Semana_" + i.ToString + ", "
        Next

        cadena += " hc.horc_año " & _
        " FROM Programacion.HormasCapacidad hc" & _
        " INNER JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = hc.horc_linpID" & _
        " WHERE lp.linp_activo = 1" & _
        " AND hc.horc_activo = 1" & _
        " AND hc.horc_hormaID IN (SELECT DISTINCT (tmpSim_hormaid) FROM Programacion.tmpSimulacionProc) "

        If simularCambio = True Then
            cadena += " UNION ALL "
            cadena += " SELECT" & _
            " 0 AS id, hcs.smhc_tallaid, hcs.smhc_hormaID, hcs.smhc_lineaId, "
            For i As Int32 = 1 To 52
                cadena += " (SELECT TOP 1 hcs.smhc_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave" & _
                 " WHERE anio = hcs.smhc_anio AND semana = " + i.ToString + " AND nave = lps.linp_idNave), 0))" & _
                 " AS smhc_Semana_" + i.ToString + ","
            Next

            cadena += " hcs.smhc_anio" & _
            " FROM Programacion.simulacionHormasCapacidad hcs" & _
            " INNER JOIN Programacion.LineasProduccion lps	ON lps.linp_linpID = hcs.smhc_lineaId" & _
            " WHERE lps.linp_activo = 1" & _
            " AND hcs.smhc_activo = 1" & _
            " AND hcs.smhc_hormaId IN (SELECT DISTINCT (tmpSim_hormaid)" & _
            " FROM Programacion.tmpSimulacionProc)" & _
            " AND hcs.smhc_simulacionId = " + idSimulacionMaestro.ToString
        End If

        cadena += ") AS CONS"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    'Public Function consultaExistenciaHormasCapacidadSimulacionANTES(ByVal idSimulacionMaestro As Int32, ByVal simularCambio As Boolean) As DataTable
    'Dim operacion As New Persistencia.OperacionesProcedimientos
    'Dim cadena As String = " SELECT  ROW_NUMBER() OVER (ORDER BY id DESC) AS filaId, pstilo, idTalla, horc_hormaID, horc_linpID, horc_año,"
    '    For i As Int32 = 1 To 52
    '        cadena += " horc_Semana_" + i.ToString + ", "
    '    Next
    '    cadena += " descripcionCompleta"
    '    cadena += " FROM (SELECT  0 AS id, " & _
    '    " vp.pstilo, vp.idTalla, hc.horc_hormaID, hc.horc_linpID, hc.horc_año,"
    '    For i As Int32 = 1 To 52
    '        cadena += " (SELECT TOP 1 hc.horc_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = hc.horc_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0)) AS horc_Semana_" + i.ToString + ", "
    '    Next

    '    cadena += " vp.prod_descripcion+' ' +vp.pielColor+' '+vp.talla  descripcionCompleta" & _
    '    " FROM vProductoEstilos vp" & _
    '    " INNER JOIN Programacion.HormasCapacidad hc ON vp.idHorma = hc.horc_hormaID" & _
    '    " AND vp.idTalla = hc.horc_tallaid" & _
    '    " INNER JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = hc.horc_linpID" & _
    '    " WHERE vp.pres_activo = 1" & _
    '    " AND lp.linp_activo = 1" & _
    '    " AND hc.horc_activo = 1" & _
    '    " AND vp.pstilo IN (SELECT DISTINCT (tmpSim_productoEstiloID) FROM Programacion.tmpSimulacionProc) "

    '    If simularCambio = True Then
    '        cadena += " UNION ALL "
    '        cadena += " SELECT 0 AS id, vp.pstilo, vp.idTalla, hc.smhc_hormaID, hc.smhc_lineaId, hc.smhc_anio,"
    '        For i As Int32 = 1 To 52
    '            cadena += " (SELECT TOP 1 hc.smhc_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = hc.smhc_anio AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0))"
    '            cadena += " AS smhc_Semana_" + i.ToString + ","
    '        Next
    '        cadena += " vp.prod_descripcion + ' ' + vp.pielColor + ' ' + vp.talla descripcionCompleta" & _
    '        " FROM vProductoEstilos vp" & _
    '        " INNER JOIN Programacion.simulacionHormasCapacidad hc ON vp.idHorma = hc.smhc_hormaID AND vp.idTalla = hc.smhc_tallaid" & _
    '        " INNER JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = hc.smhc_lineaId" & _
    '        " WHERE vp.pres_activo = 1" & _
    '        " AND lp.linp_activo = 1" & _
    '        " AND hc.smhc_activo = 1" & _
    '        " AND vp.pstilo IN (SELECT DISTINCT (tmpSim_productoEstiloID) FROM Programacion.tmpSimulacionProc)" & _
    '        " AND hc.smhc_simulacionId =" + idSimulacionMaestro.ToString
    '    End If

    '    cadena += ") AS CONS"
    '    Return operacion.EjecutaConsulta(cadena)
    'End Function

    Public Function consultaExistenciaGruposCapacidadSimulacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT  ROW_NUMBER() OVER (ORDER BY id DESC) AS filaId," & _
        " gcap_grupoID, linp_linpID,"

        For i As Int32 = 1 To 52
            cadena += " gcap_Semana_" + i.ToString + ", "
        Next

        cadena += " gcap_año FROM (" & _
        " SELECT 0 AS id, gc.gcap_grupoID, lp.linp_linpID,"

        For i As Int32 = 1 To 52
            cadena += " (gc.gcap_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = gc.gcap_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0)) AS gcap_Semana_" + i.ToString + ","
        Next

        cadena += " gc.gcap_año" & _
        " FROM Programacion.GruposCapacidad gc" & _
        " JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = gc.gcap_linpID" & _
        " WHERE lp.linp_activo = 1" & _
        " AND gc.gcap_activo = 1" & _
        " AND gc.gcap_grupoID IN (SELECT DISTINCT(vps.idGrupo) FROM Programacion.tmpSimulacionProc tmp" & _
        " JOIN vProductoEstilos vps ON tmp.tmpSim_productoEstiloID = vps.pstilo AND tmp.tmpSim_tallaID = vps.idTalla)) AS cons"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    'Public Function consultaExistenciaGruposCapacidadSimulacionANTES() As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim cadena As String = "SELECT  ROW_NUMBER() OVER (ORDER BY id DESC) AS filaId," & _
    '    " gcap_grupoID,pstilo,idTalla,linp_linpID,gcap_año,"

    '    For i As Int32 = 1 To 52
    '        cadena += " gcap_Semana_" + i.ToString + ", "
    '    Next

    '    cadena += " prod_descripcion FROM (" & _
    '    " SELECT 0 AS id, gc.gcap_grupoID, vp.pstilo, vp.idTalla, lp.linp_linpID, gc.gcap_año,"

    '    For i As Int32 = 1 To 52
    '        cadena += " (gc.gcap_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = gc.gcap_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0)) AS gcap_Semana_" + i.ToString + ","
    '    Next

    '    cadena += " vp.prod_descripcion" & _
    '    " FROM vProductoEstilos vp" & _
    '    " INNER JOIN Programacion.GruposCapacidad gc ON vp.idGrupo = gc.gcap_grupoID" & _
    '    " JOIN Programacion.LineasProduccion lp ON lp.linp_linpID = gc.gcap_linpID" & _
    '    " WHERE vp.pres_activo = 1" & _
    '    " AND vp.pres_activo = 1" & _
    '    " AND lp.linp_activo = 1" & _
    '    " AND gc.gcap_activo = 1" & _
    '    " AND vp.pstilo IN (SELECT DISTINCT (tmpSim_productoEstiloID) FROM Programacion.tmpSimulacionProc)) as cons"
    '    Return operacion.EjecutaConsulta(cadena)
    'End Function

    Public Function consultaExistenciaLineaProduccionCapacidadSimulacion(ByVal idSimulacion As Int32, ByVal limiteCapacidad As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT ROW_NUMBER() OVER (ORDER BY id DESC) AS filaId, lcap_año,"
        For i As Int32 = 1 To 52
            cadena += "lcap_Semana_" + i.ToString + ", "
        Next

        cadena += "lcap_linpID FROM( SELECT 0 as id, lpc.lcap_año,"

        For i As Int32 = 1 To 52
            cadena += " ((lpc.lcap_" + i.ToString + " * ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = lpc.lcap_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0))"

            If limiteCapacidad = True Then
                cadena += "-" & _
                " ISNULL((SELECT TOP 1 CASE WHEN lmc.lmtc_porcentaje = 0 THEN lmc.lmtc_cantidad * lmc.lmtc_dias" & _
                " ELSE "
                'FLOOR(((CAST(lnpx.lcap_" + i.ToString + " AS float) / 100) * lmc.lmtc_cantidad) * lmc.lmtc_dias)" & _
                cadena += "CAST(FLOOR((ISNULL((SELECT TOP 1 dias FROM Programacion.diasTrabajoNave WHERE anio = lpc.lcap_año AND semana = " + i.ToString + " AND nave = lp.linp_idNave), 0) * ISNULL(lmc.lmtc_dias, 0) / 100) * ISNULL(lmc.lmtc_cantidad, 0)) AS varchar(25)) END AS lmt"
                cadena += " END AS lmt FROM Programacion.LimiteCapacidad lmc" & _
                " JOIN Programacion.LineasProduccionCapacidad lnpx ON lmc.lmtc_lineaId = lnpx.lcap_linpID" & _
                " AND lmc.lmtc_anio = lnpx.lcap_año AND lmc.lmtc_semana = " + i.ToString & _
                " WHERE lmc.lmtc_activo = 1 AND lnpx.lcap_activo = 1 AND lmc.lmtc_lineaId = lpc.lcap_linpID AND" & _
                " lmc.lmtc_simulacionMaestroId = " + idSimulacion.ToString + " AND lmc.lmtc_semana = " + i.ToString + " AND lmc.lmtc_anio =  lpc.lcap_año), 0)"
            End If

            cadena += ") lcap_Semana_" + i.ToString + ","
        Next

        cadena += " lpc.lcap_linpID" & _
        " FROM Programacion.LineasProduccionCapacidad lpc" & _
        " INNER JOIN Programacion.LineasProduccion lp	ON linp_linpID = lcap_linpID" & _
        " WHERE lp.linp_activo = 1 AND lpc.lcap_activo = 1) as CONS"

        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
