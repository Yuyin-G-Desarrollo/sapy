Imports System.Data.SqlClient

Public Class ProgramasDA

    Public Function importarProgramasRenglon(ByVal fechaInicio As Date, ByVal fechaFin As Date) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim dtDatos As New DataTable
        Dim dato As String = ""

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio.ToShortDateString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechaFin.ToShortDateString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        dtDatos = operacion.EjecutarConsultaSP("Programacion.SP_ImportarProgramasSICY", listaParametros)
        If dtDatos.Rows.Count > 0 Then
            dato = dtDatos.Rows(0).Item(0).ToString
        End If

        Return dato
    End Function

    Public Function consultaPedidosConfirmadosSinApartar() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                   SELECT
	vw.Programado,
	vw.IdPedido,
	vw.IdPartida,
	vw.idLote,
	vw.Entrega,
	vw.SICY,
	vw.SAY,
	Producto + ' ' + vp.pielColor + ' ' + vp.talla AS Producto,
	vw.Cantidad,
	vw.prod_productoid,
	vw.IdCadena,
	vw.Cliente,
	vw.Ranking,
	vw.Especial,
	vw.pstilo,
	vw.talla_tallaid,
	vw.Tipo,
	vw.estatus,
	CASE
		WHEN vw.bloqueo > 0 THEN CAST(1 AS bit)
		ELSE CAST(0 AS bit)
	END AS Bloqueo,
	vw.stLotesA,
	CASE
		WHEN (SELECT
				COUNT(proc_procID)
			FROM Programacion.ProductosCapacidad
			WHERE proc_productoEstiloId = vw.pstilo
			AND proc_año = DATEPART(YEAR, vw.Entrega)
			AND proc_activo = 1)
			> 0 THEN CAST(1 AS bit)
		ELSE CAST(0 AS bit)
	END AS capacidad,
	vw.clie_clienteid,
	vw.idHorma,
    vw.EntregaCliente,
    vp.idGrupo
FROM Programacion.vw_PedidosConfirmadosSinApartar vw
LEFT JOIN vProductoEstilos vp
	ON vp.pstilo = vw.pstilo
	AND vp.idTalla = vw.talla_tallaid
	AND vp.idHorma = vw.idHorma
</cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaPedidosSinProgramaAsignado() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>                     
          SELECT
	vw.Programado,
	vw.IdPedido,
	vw.IdPartida,
	vw.idLote,
	vw.Entrega,
	vw.SICY,
	vw.SAY,
	Producto + ' ' + vp.pielColor + ' ' + vp.talla AS Producto,
	vw.Cantidad,
	vw.prod_productoid,
	vw.IdCadena,
	vw.Cliente,
	vw.Ranking,
	vw.Especial,
	vw.pstilo,
	vw.talla_tallaid,
	vw.Tipo,
	vw.estatus,
	CASE
		WHEN vw.bloqueo > 0 THEN CAST(1 AS bit)
		ELSE CAST(0 AS bit)
	END AS Bloqueo,
	vw.stLotesA,
	CASE
		WHEN (SELECT
				COUNT(proc_procID)
			FROM Programacion.ProductosCapacidad
			WHERE proc_productoEstiloId = vw.pstilo
			AND proc_año = DATEPART(YEAR, vw.Entrega)
			AND proc_activo = 1)
			> 0 THEN CAST(1 AS bit)
		ELSE CAST(0 AS bit)
	END AS capacidad,
	vw.clie_clienteid,
	vw.idHorma,
    vw.EntregaCliente,
    vp.idGrupo
FROM Programacion.vw_PedidosSinProgramaAsignado vw
LEFT JOIN vProductoEstilos vp
	ON vp.pstilo = vw.pstilo
	AND vp.idTalla = vw.talla_tallaid
	AND vp.idHorma = vw.idHorma
</cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function obtenerFolio() As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim folio As Int32 = 1
        Dim cadena As String = ""

        cadena = <cadena>
                    SELECT ISNULL(MAX(bita_folio), 0) + 1 Nuevo FROM Programacion.Bitacoraprogramacion
                 </cadena>.Value

        dt = operacion.EjecutaConsulta(cadena)

        If dt.Rows.Count > 0 Then
            folio = dt.Rows(0).Item(0)
        End If

        Return folio

    End Function

    Public Sub guardarRegistroBItacora(ByVal folio As Int32, ByVal idPedido As Int32, ByVal idRenglon As Int32,
                                       ByVal idProducto As Int32, ByVal pares As Int32, ByVal fecha As String,
                                       ByVal mensaje As String, ByVal tipo As String, ByVal pares_faltan As Int32,
                                       ByVal linea As Int32, ByVal prestilo As Int32, ByVal idTalla As Int32,
                                       ByVal origen As String, ByVal simulacionid As Int32, ByVal bita_pdetID As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.BitacoraProgramacion (bita_folio, bita_idPedido, bita_renglonID," +
        " bita_productoID, bita_pares, bita_fecha, bita_mensaje, bita_tipo, bita_pares_faltan," +
        " bita_linpID, bita_productoEstiloID, bita_tallaID, bita_origen, bita_simulacionId, bita_pdetID, bita_pc)" +
        "VALUES ('" + folio.ToString + "', '" + idPedido.ToString + "', '" + idRenglon.ToString + "'" +
        ", '" + idProducto.ToString + "','" + pares.ToString + "','" + fecha + "'" +
        ", '" + mensaje + "','" + tipo + "','" + pares_faltan.ToString + "'" +
        ", '" + linea.ToString + "','" + prestilo.ToString + "','" + idTalla.ToString + "'" +
        ", '" + origen + "','" + simulacionid.ToString + "','" + bita_pdetID.ToString + "', '" + My.Computer.Name + "')"

        operacion.EjecutaSentencia(cadena)

    End Sub

    Public Function ObtenerOpcionFecha(ByVal opcion As String) As Date
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT opci_valor_date FROM programacion.opciones" +
            " WHERE opci_descripcion = '" + opcion + "' AND opci_activo = 1"
        Return CDate(operaciones.EjecutaConsultaEscalar(cadena))
    End Function

    Public Function ObtenerOpcionValorEntero(ByVal opcion As String) As Int32
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT opci_valor_entero FROM programacion.opciones" +
          " WHERE opci_descripcion = '" + opcion + "' AND opci_activo = 1"

        Return CInt(operaciones.EjecutaConsultaEscalar(cadena))
    End Function

    Public Function consultaExistenciaCapacidadArticuloAnio(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                           ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "SELECT 'Capacidad' Tipo, proc_prodID, proc_linpID, linp_idNave, nave, "

        If semanaFin >= semanaInicio Then
            For i As Int32 = semanaInicio To semanaFin
                'cadena += "SUM([" + i.ToString + "]) [" + i.ToString + "], "
                cadena += "SUM([" + i.ToString + "_" + anioInicio.ToString + "]) [" + i.ToString + "_" + anioInicio.ToString + "], "
            Next
        Else
            For i As Int32 = semanaInicio To 52
                'cadena += "SUM([" + i.ToString + "]) [" + i.ToString + "], "
                cadena += "SUM([" + i.ToString + "_" + anioInicio.ToString + "]) [" + i.ToString + "_" + anioInicio.ToString + "], "
            Next

            For i As Int32 = 1 To semanaFin
                'cadena += "SUM([" + i.ToString + "]) [" + i.ToString + "], "
                cadena += "SUM([" + i.ToString + "_" + anioFin.ToString + "]) [" + i.ToString + "_" + anioFin.ToString + "], "
            Next

        End If


        cadena += " prna_orden,  prna_muestras,  proc_productoEstiloId,  proc_tallaID" & _
        " FROM (SELECT pc.proc_prodID,	pc.proc_linpID,	lp.linp_idNave,	na.nave_nombre Nave, DescripcionCompleta Producto,"

        If semanaFin >= semanaInicio Then
            For i As Int32 = semanaInicio To semanaFin
                'cadena += " (MAX(proc_" + i.ToString + ") * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + i.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana(" + anio.ToString + ", pc.proc_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + "), 0) [" + i.ToString + "],"
                cadena += " ((SELECT x.proc_" + i.ToString + " FROM Programacion.ProductosCapacidad x WHERE x.proc_activo = 1 AND x.proc_año = " + anioInicio.ToString + " AND x.proc_linpID = pc.proc_linpID AND x.proc_productoEstiloId =  " + idEstilo.ToString + ") * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana(" + anioInicio.ToString + ", pc.proc_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + "), 0) [" + i.ToString + "_" + anioInicio.ToString + "],"
            Next
        Else
            For i As Int32 = semanaInicio To 52
                'cadena += " (MAX(proc_" + i.ToString + ") * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + i.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana(" + anio.ToString + ", pc.proc_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + "), 0) [" + i.ToString + "],"
                cadena += " ((SELECT x.proc_" + i.ToString + " FROM Programacion.ProductosCapacidad x WHERE x.proc_activo = 1 AND x.proc_año = " + anioInicio.ToString + " AND x.proc_linpID = pc.proc_linpID AND x.proc_productoEstiloId =  " + idEstilo.ToString + ") * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana(" + anioInicio.ToString + ", pc.proc_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + "), 0) [" + i.ToString + "_" + anioInicio.ToString + "],"
            Next

            For i As Int32 = 1 To semanaFin
                'cadena += " (MAX(proc_" + i.ToString + ") * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + i.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana(" + anio.ToString + ", pc.proc_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + "), 0) [" + i.ToString + "],"
                cadena += " ((SELECT x.proc_" + i.ToString + " FROM Programacion.ProductosCapacidad x WHERE x.proc_activo = 1 AND x.proc_año = " + anioFin.ToString + " AND x.proc_linpID = pc.proc_linpID AND x.proc_productoEstiloId =  " + idEstilo.ToString + ") * programacion.fdu_dias_trabajo_nave_semana(" + anioFin.ToString + ", " + i.ToString + ", linp_idNave)) - ISNULL(programacion.fdu_pares_semana(" + anioFin.ToString + ", pc.proc_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + "), 0) [" + i.ToString + "_" + anioFin.ToString + "],"
            Next
        End If



        cadena += " prna_orden, prna_muestras, proc_productoEstiloId, proc_tallaID" & _
            " FROM Programacion.ProductosCapacidad pc" & _
            " INNER JOIN Programacion.LineasProduccion lp ON linp_linpID = proc_linpID" & _
            " INNER JOIN Programacion.ProductosNave pn ON pn.prna_productoID = pc.proc_prodID" & _
            " AND pn.prna_productoEstiloID = pc.proc_productoEstiloId	AND pc.proc_tallaID = pn.prna_tallaID " & _
            " AND pn.prna_naveID = lp.linp_idNave AND pn.prna_hormaid = pc.proc_hormaid	" & _
            " INNER JOIN Programacion.NavesAux na	ON nave_naveid = linp_idNave" & _
            " INNER JOIN vProductos vp ON vp.v_prodID = pc.proc_prodID" & _
            " AND vp.v_productoEstiloID = pc.proc_productoEstiloId AND vp.v_tallaID = pc.proc_tallaID" & _
            " AND vp.v_hormaID = PC.proc_hormaid " & _
            " WHERE pc.proc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
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
            " pc.proc_linpID," & _
            " lp.linp_idNave," & _
            " pn.prna_orden," & _
            " pn.prna_muestras," & _
            " na.nave_nombre," & _
            " DescripcionCompleta," & _
            " pc.proc_productoEstiloId," &
            " pc.proc_tallaID) AS CONS" & _
            " GROUP BY	proc_prodID," & _
            " proc_linpID," & _
            " linp_idNave," & _
            " prna_orden," & _
            " prna_muestras," & _
            " nave," & _
            " proc_productoEstiloId," & _
            " proc_tallaID" & _
            " ORDER BY prna_orden"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaExistenciaCapacidadParesXArticuloAnio(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                           ByVal idProd As Int32, ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32) As DataTable
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
                cadena += ", programacion.fdu_pares_semana(" + anioInicio.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ") [" + i.ToString + "_" + anioInicio.ToString + "] "
            Next
        Else
            For i As Int32 = semanaInicio To 52
                cadena += ", programacion.fdu_pares_semana(" + anioInicio.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ") [" + i.ToString + "_" + anioInicio.ToString + "] "
            Next
            For i As Int32 = 1 To semanaFin
                cadena += ", programacion.fdu_pares_semana(" + anioFin.ToString + ", pr.prog_linpID, " + i.ToString + ", " + idProd.ToString + ", " + idEstilo.ToString + ", " + idTalla.ToString + ") [" + i.ToString + "_" + anioFin.ToString + "] "
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

    Public Function consultaCapacidadHormaXArticulo(ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32,
                                                           ByVal semanaFin As Int32,
                                                           ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32,
                                                           ByVal idLinea As Int32,
                                                           ByVal idHorma As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT TOP 1"

        If semanaFin >= semanaInicio Then
            For i As Int32 = semanaInicio To semanaFin
                cadena += "((SELECT TOP 1 horc_" + i.ToString + " FROM Programacion.HormasCapacidad hcx WHERE hcx.horc_año = " + anioInicio.ToString & _
                    " AND hcx.horc_hormaID = " + idHorma.ToString + " AND hcx.horc_linpID = " + idLinea.ToString & _
                    " AND hcx.horc_tallaid = " + idTalla.ToString + " AND hcx.horc_activo = 1" & _
                    " AND hcx.horc_hormapornaveid = hc.horc_hormapornaveid) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString & _
                    ", lp.linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr" & _
                    " JOIN Programacion.ProductosCapacidad pc ON pr.prog_productoEstiloID = pc.proc_productoEstiloId AND pr.prog_tallaID = pc.proc_tallaID" & _
                    " WHERE pr.prog_año = " + anioInicio.ToString + " AND pr.prog_linpID = " + idLinea.ToString + " AND pr.prog_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_año = " + anioInicio.ToString + " AND pc.proc_linpID = " + idLinea.ToString + "  AND pc.proc_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_activo = 1), 0) AS horc_" + i.ToString + "_" + anioInicio.ToString + ","
            Next

        Else
            For i As Int32 = semanaInicio To 52
                cadena += "((SELECT TOP 1 horc_" + i.ToString + " FROM Programacion.HormasCapacidad hcx WHERE hcx.horc_año = " + anioInicio.ToString & _
                    " AND hcx.horc_hormaID = " + idHorma.ToString + " AND hcx.horc_linpID = " + idLinea.ToString & _
                    " AND hcx.horc_tallaid = " + idTalla.ToString + " AND hcx.horc_activo = 1" & _
                    " AND hcx.horc_hormapornaveid = hc.horc_hormapornaveid) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString & _
                    ", lp.linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr" & _
                    " JOIN Programacion.ProductosCapacidad pc ON pr.prog_productoEstiloID = pc.proc_productoEstiloId AND pr.prog_tallaID = pc.proc_tallaID" & _
                    " WHERE pr.prog_año = " + anioInicio.ToString + " AND pr.prog_linpID = " + idLinea.ToString + " AND pr.prog_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_año = " + anioInicio.ToString + " AND pc.proc_linpID = " + idLinea.ToString + " AND pc.proc_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_activo = 1), 0) AS horc_" + i.ToString + "_" + anioInicio.ToString + ","
            Next

            For i As Int32 = 1 To semanaFin
                cadena += "((SELECT TOP 1 horc_" + i.ToString + " FROM Programacion.HormasCapacidad hcx WHERE hcx.horc_año = " + anioFin.ToString & _
                    " AND hcx.horc_hormaID = " + idHorma.ToString + " AND hcx.horc_linpID = " + idLinea.ToString & _
                    " AND hcx.horc_tallaid = " + idTalla.ToString + " AND hcx.horc_activo = 1" & _
                    " AND hcx.horc_hormapornaveid = hc.horc_hormapornaveid) * programacion.fdu_dias_trabajo_nave_semana(" + anioFin.ToString + ", " + i.ToString & _
                    ", lp.linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr" & _
                    " JOIN Programacion.ProductosCapacidad pc ON pr.prog_productoEstiloID = pc.proc_productoEstiloId AND pr.prog_tallaID = pc.proc_tallaID" & _
                    " WHERE pr.prog_año = " + anioFin.ToString + " AND pr.prog_linpID = " + idLinea.ToString + " AND pr.prog_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_año = " + anioFin.ToString + " AND pc.proc_linpID = " + idLinea.ToString + " AND pc.proc_hormaid = " + idHorma.ToString & _
                    " AND pc.proc_activo = 1), 0) AS horc_" + i.ToString + "_" + anioFin.ToString + ","
            Next

        End If


        cadena += " v_hormaID,  descripcionCompleta FROM vProductos cp" & _
        " INNER JOIN Programacion.HormasCapacidad hc ON cp.v_hormaID = hc.horc_hormaID AND cp.v_tallaID = hc.horc_tallaid " & _
        " INNER JOIN Programacion.LineasProduccion lp	ON lp.linp_linpID = hc.horc_linpID" & _
        " WHERE cp.pres_activo = 1 AND cp.prod_activo = 1 AND cp.v_productoEstiloID =  " + idEstilo.ToString & _
        " AND cp.v_tallaID =  " + idTalla.ToString & _
        " AND cp.v_hormaID = " + idHorma.ToString & _
        " AND lp.linp_activo = 1 " & _
        " AND lp.linp_linpID = " + idLinea.ToString & _
        " AND hc.horc_activo = 1 AND" & _
        " hc.horc_hormaID = " + idHorma.ToString & _
        " AND hc.horc_linpID = " + idLinea.ToString & _
        " AND hc.horc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString

        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function consultaCapacidadLineaProduccionCelulaXArticulo(ByVal anioInicio As Int32,
                                                                    ByVal anioFin As Int32,
                                                                    ByVal semanaInicio As Int32,
                                                                    ByVal semanaFin As Int32,
                                                                    ByVal idLinea As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT TOP 1"

        If semanaFin >= semanaInicio Then
            For i As Int32 = semanaInicio To semanaFin
                'cadena += "(lcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anio.ToString + ", " + i.ToString + " , linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr WHERE pr.prog_año = " + anio.ToString + " AND pr.prog_linpID = " + idLinea.ToString + "), 0) lcap_" + i.ToString + ", "
                cadena += "((SELECT lpx.lcap_" + i.ToString + " FROM Programacion.LineasProduccionCapacidad lpx WHERE lpx.lcap_linpID = " + idLinea.ToString + " AND lpx.lcap_año = " + anioInicio.ToString + " AND lpx.lcap_activo = 1) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr WHERE pr.prog_año = " + anioInicio.ToString + " AND pr.prog_linpID = " + idLinea.ToString + "), 0) lcap_" + i.ToString + "_" + anioInicio.ToString + ","
            Next
        Else
            For i As Int32 = semanaInicio To 52
                cadena += "((SELECT lpx.lcap_" + i.ToString + " FROM Programacion.LineasProduccionCapacidad lpx WHERE lpx.lcap_linpID = " + idLinea.ToString + " AND lpx.lcap_año = " + anioInicio.ToString + " AND lpx.lcap_activo = 1) * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr WHERE pr.prog_año = " + anioInicio.ToString + " AND pr.prog_linpID = " + idLinea.ToString + "), 0) lcap_" + i.ToString + "_" + anioInicio.ToString + ","
            Next

            For i As Int32 = 1 To semanaFin
                cadena += "((SELECT lpx.lcap_" + i.ToString + " FROM Programacion.LineasProduccionCapacidad lpx WHERE lpx.lcap_linpID = " + idLinea.ToString + " AND lpx.lcap_año = " + anioFin.ToString + " AND lpx.lcap_activo = 1) * programacion.fdu_dias_trabajo_nave_semana(" + anioFin.ToString + ", " + i.ToString + " , lp.linp_idNave)) - ISNULL((SELECT SUM(pr.prog_" + i.ToString + ") FROM Programacion.ProgramasRenglon pr WHERE pr.prog_año = " + anioFin.ToString + " AND pr.prog_linpID = " + idLinea.ToString + "), 0) lcap_" + i.ToString + "_" + anioFin.ToString + ","
            Next
        End If

        cadena += "  0 a FROM Programacion.LineasProduccionCapacidad lpc" & _
         " INNER JOIN Programacion.LineasProduccion lp ON linp_linpID = lcap_linpID " & _
         " WHERE lcap_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString + " AND lcap_linpID = " + idLinea.ToString + " AND lp.linp_activo = 1 AND lpc.lcap_activo = 1"

        Return operacion.EjecutaConsulta(cadena)

    End Function

    Public Function consultaCapacidadLineaProduccionGruposXArticulo(ByVal anioInicio As Int32,
                                                                    ByVal anioFin As Int32,
                                                           ByVal semanaInicio As Int32,
                                                           ByVal semanaFin As Int32,
                                                           ByVal idEstilo As Int32,
                                                           ByVal idTalla As Int32,
                                                           ByVal idLinea As Int32,
                                                           ByVal idGrupo As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT"

        If semanaFin >= semanaInicio Then

            For i As Int32 = semanaInicio To semanaFin
                cadena += " (gcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + i.ToString + ")" & _
                    " FROM Programacion.ProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
                    " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + anioInicio.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + anioInicio.ToString & _
                    " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
                    " vpx.pres_activo = 1 AND vpx.idGrupo = " + idGrupo.ToString + "), 0) AS gcap_" + i.ToString + "_" + anioInicio.ToString + ","
            Next

        Else
            For i As Int32 = semanaInicio To 52
                cadena += " (gcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + anioInicio.ToString + ", " + i.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + i.ToString + ")" & _
                    " FROM Programacion.ProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
                    " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + anioInicio.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + anioInicio.ToString & _
                    " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
                    " vpx.pres_activo = 1 AND vpx.idGrupo =  " + idGrupo.ToString + "), 0) AS gcap_" + i.ToString + "_" + anioInicio.ToString + ","
            Next

            For i As Int32 = 1 To semanaFin
                cadena += " (gcap_" + i.ToString + " * programacion.fdu_dias_trabajo_nave_semana(" + semanaFin.ToString + ", " + i.ToString + ", lp.linp_idNave)) - ISNULL((SELECT SUM(prx.prog_" + i.ToString + ")" & _
                    " FROM Programacion.ProgramasRenglon prx JOIN Programacion.ProductosCapacidad pcx ON prx.prog_productoEstiloID = pcx.proc_productoEstiloId AND prx.prog_tallaID = pcx.proc_tallaID JOIN vProductoEstilos vpx" & _
                    " ON prx.prog_productoEstiloID = vpx.pstilo AND prx.prog_tallaID = vpx.idTalla WHERE prx.prog_año = " + semanaFin.ToString + " AND prx.prog_linpID = " + idLinea.ToString + " AND pcx.proc_año = " + semanaFin.ToString & _
                    " AND pcx.proc_linpID = " + idLinea.ToString + " AND pcx.proc_activo = 1 AND" & _
                    " vpx.pres_activo = 1 AND vpx.idGrupo =  " + idGrupo.ToString + "), 0) AS gcap_" + i.ToString + "_" + semanaFin.ToString + ","
            Next

        End If

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
        " AND gc.gcap_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub guardarProgramaRenglonCompleto(ByVal idLinea As Int32,
                                              ByVal idProducto As Int32,
                                               ByVal idEstilo As Int32,
                                               ByVal idPedido As Int32,
                                               ByVal idRenglon As Int32,
                                               ByVal idLote As Int32,
                                               ByVal idTalla As Int32,
                                               ByVal idClienteCadena As String,
                                               ByVal cantidad As String,
                                               ByVal anio As Int32,
                                               ByVal semana As Int32,
                                               ByVal idClienteSAY As String,
                                               ByVal idNave As Int32,
                                               ByVal idHorma As String,
                                               ByVal fechaEntrega As String,
                                               ByVal entregaCliente As String,
                                               ByVal tipo As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "INSERT INTO programacion.programasrenglon (" & _
                " prog_linpID, " & _
                " prog_productoID, " & _
                " prog_IdPedido, " & _
                " prog_IdRenglon, " & _
                " prog_idLote," & _
                " prog_" + semana.ToString + ", " & _
                " prog_año, " & _
                " prog_productoEstiloID, " & _
                " prog_tallaID, " & _
                " prog_idCadena," & _
                " prog_usuarioCreo," & _
                " prog_fechaCreacion," & _
                " prog_idCliente," & _
                " prog_naveID," & _
                " prog_hormaid, " & _
                " prog_fechaEntregaPedido," & _
                " prog_semana," & _
                " prog_fechaCliente," & _
                " prog_tipo )" & _
                " VALUES('" + idLinea.ToString + "', '" & _
                idProducto.ToString + "', '" & _
                idPedido.ToString + "', '" & _
                idRenglon.ToString + "', '" & _
                idLote.ToString + "', '" & _
                cantidad + "', '" & _
                anio.ToString + "', '" & _
                idEstilo.ToString + "', '" & _
                idTalla.ToString + "','" & _
                idClienteCadena.ToString + "', " +
                Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                ", GETDATE(), '" & _
                idClienteSAY.ToString + "', '" & _
                idNave.ToString + "', '" & _
                idHorma + "', '" & _
                CDate(fechaEntrega.ToString).ToShortDateString + "', '" & _
                semana.ToString + "', '" & _
                CDate(entregaCliente).ToShortDateString + "', '" & _
                tipo + "')"



        operacion.EjecutaSentencia(cadena)
    End Sub

    'Public Function consultaMapaRenglon(ByVal anioInicio As Int32,
    '                                    ByVal anioFin As Int32,
    '                                    ByVal idNave As Int32,
    '                                    ByVal pedidos As Boolean,
    '                                    ByVal bloqueo As Boolean,
    '                                    ByVal ordenamiento As Int32) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim dt As New DataTable
    '    Dim dtReturn As New DataTable

    '    For i = anioInicio To anioFin
    '        Dim listaParametros As New List(Of SqlParameter)

    '        Dim parametro As New SqlParameter
    '        parametro.ParameterName = "@anio"
    '        parametro.Value = i.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@idNave"
    '        parametro.Value = idNave.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@pedidos"
    '        parametro.Value = pedidos.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@bloqueo"
    '        parametro.Value = bloqueo.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@ordenamiento"
    '        parametro.Value = ordenamiento.ToString
    '        listaParametros.Add(parametro)

    '        dt = operacion.EjecutarConsultaSP("Programacion.SP_ConsultaMapaProgramasRenglon", listaParametros)
    '        If dt.Rows.Count > 0 Then
    '            dtReturn.Merge(dt)
    '        End If
    '    Next

    '    Return dtReturn
    'End Function

    'Public Function consultaMapaRenglonSimulacion(ByVal anioInicio As Int32,
    '                                   ByVal anioFin As Int32,
    '                                   ByVal idNave As Int32,
    '                                   ByVal pedidos As Boolean,
    '                                   ByVal bloqueo As Boolean,
    '                                   ByVal ordenamiento As Int32,
    '                                   ByVal idSimulacionMaestro As Int32,
    '                                   ByVal folio As Int32) As DataTable
    'Dim operacion As New Persistencia.OperacionesProcedimientos
    'Dim dt As New DataTable
    'Dim dtReturn As New DataTable

    '    For i = anioInicio To anioFin
    'Dim listaParametros As New List(Of SqlParameter)

    'Dim parametro As New SqlParameter
    '        parametro.ParameterName = "@anio"
    '        parametro.Value = i.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@idNave"
    '        parametro.Value = idNave.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@pedidos"
    '        parametro.Value = pedidos.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@bloqueo"
    '        parametro.Value = bloqueo.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@ordenamiento"
    '        parametro.Value = ordenamiento.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@idSimulacionMaestro"
    '        parametro.Value = idSimulacionMaestro.ToString
    '        listaParametros.Add(parametro)

    '        parametro = New SqlParameter
    '        parametro.ParameterName = "@folio"
    '        parametro.Value = folio.ToString
    '        listaParametros.Add(parametro)

    '        dt = operacion.EjecutarConsultaSP("Programacion.SP_ConsultaMapaProgramasRenglonSimulacion", listaParametros)
    '        If dt.Rows.Count > 0 Then
    '            dtReturn.Merge(dt)
    '        End If
    '    Next

    '    Return dtReturn
    'End Function

    Public Function consultaRangoColoresMapa() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" & _
        " opci_opciID id, opci_descripcion opcion, opci_valor_numerico r1, opci_valor_numerico_2 r2, opci_valor_entero color" & _
        " FROM Programacion.Opciones" & _
        " WHERE opci_opciID IN (1003, 1004, 1005, 1006, 1002)"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaBitacora(ByVal folio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT bita_folio 'Folio', bita_idPedido 'Pedido', bita_mensaje 'Mensaje', bita_alta 'Fecha'" & _
        " FROM Programacion.BitacoraProgramacion WHERE bita_folio = " + folio.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub inactivarFechasImportacionAnterior()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.EncabezadoImportacion SET eirf_activo = 0, eirf_usuariomodifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", eirf_fechamoficiacion = GETDATE() WHERE eirf_activo = 1"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub guardarFechasImportacion(ByVal fechaInicio As Date, ByVal fechafin As Date,
                                        ByVal semanainicio As Int32, ByVal semanafin As Int32, ByVal anioinicio As Int32,
                                        ByVal aniofin As Int32, ByVal folio As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.EncabezadoImportacion (eirf_fechaInicio," & _
        " eirf_fechafin," & _
        " eirf_semanainicio," & _
        " eirf_semanafin," & _
        " eirf_anioinicio," & _
        " eirf_aniofin," & _
        " eirf_folio," & _
        " eirf_usuariocreo," & _
        " eirf_fechamoficiacion," & _
        " eirf_activo)" & _
        " VALUES ('" + fechaInicio.ToShortDateString + "', '" + fechafin.ToShortDateString + "', " + semanainicio.ToString + ", " + semanafin.ToString + ", " + anioinicio.ToString + ", " + aniofin.ToString + ", " + folio.ToString + ", " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", GETDATE(), 1)"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaRangosFechaTodo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     SELECT TOP 1
	                eirf_EncabezadoImportacionId,
	                eirf_fechaInicio,
	                eirf_fechafin,
	                eirf_semanainicio,
	                eirf_semanafin,
	                eirf_anioinicio,
	                eirf_aniofin,
	                eirf_folio,
	                eirf_activo
                FROM Programacion.EncabezadoImportacion WHERE eirf_activo = 1
                 </cadena>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaProgramaRenglonPorSemana(ByVal semanaInicio As Int32, ByVal semanaFin As Int32,
                                                     ByVal anioInicio As Int32, ByVal anioFin As Int32,
                                                     ByVal idNave As Int32, ByVal idLinea As Int32, ByVal VerSoloConCantidad As Boolean) As DataTable
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
        cadena += " FROM Programacion.ProgramasRenglon pr " & _
        " JOIN Cliente.Cliente c ON pr.prog_idCliente = c.clie_clienteid" & _
        " JOIN vProductoEstilos vp ON pr.prog_productoEstiloID = vp.pstilo" & _
        " JOIN Programacion.NavesAux n ON pr.prog_naveID = n.nave_naveid" & _
        " JOIN Programacion.LineasProduccion lp ON pr.prog_naveID = lp.linp_idNave AND pr.prog_linpID = lp.linp_linpID" & _
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

        cadena += " ORDER BY pr.prog_año, pr.prog_semana, prog_naveID, prog_linpID"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaAnioMaximoCapacidades() As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim valor As Int32 = Date.Now.Year
        cadena = "SELECT MAX(lcap_año) FROM Programacion.LineasProduccionCapacidad"
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                If dt.Rows(0).Item(0).ToString <> "" Then
                    valor = dt.Rows(0).Item(0)
                End If
            End If
        End If
        Return valor
    End Function


    Public Function consultaMapaSimulacionSegmentado(ByVal anioInicio As Int32,
                                       ByVal anioFin As Int32,
                                       ByVal semanaInicio As Int32,
                                       ByVal semanaFin As Int32,
                                       ByVal idNave As Int32,
                                       ByVal pedidos As Boolean,
                                       ByVal bloqueo As Boolean,
                                       ByVal ordenamiento As Int32,
                                       ByVal idSimulacionMaestro As Int32,
                                       ByVal folio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadenaCapacidad As String = ""
        Dim cadenaPares As String = ""
        Dim cadenaPorcentaje As String = ""
        Dim cadenaRestante As String = ""

        Dim dt As New DataTable

        If anioInicio = anioFin Then
            cadenaCapacidad = "SELECT nx.nave_nombre, lp.linp_nombre, 'Capacidad' AS Tipo, 1 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave, ISNULL(pr.prog_linpID, 0) prog_linpID," & _
            " nx.nave_idSicy, nx.nave_orden"

            For i As Int32 = semanaInicio To semanaFin
                cadenaCapacidad += ", CAST(ISNULL(Programacion.fdu_capacidad_linea(" + anioInicio.ToString + " , lp.linp_linpID, " + i.ToString + "), 0) AS varchar(10)) [" + anioInicio.ToString + "-" + i.ToString + "]"
            Next

        ElseIf anioInicio < anioFin Then

            cadenaCapacidad = "SELECT nx.nave_nombre, lp.linp_nombre, 'Capacidad' AS Tipo, 1 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave, ISNULL(pr.prog_linpID, 0) prog_linpID," & _
           " nx.nave_idSicy, nx.nave_orden"

            For i As Int32 = semanaInicio To 52
                cadenaCapacidad += ", CAST(ISNULL(Programacion.fdu_capacidad_linea(" + anioInicio.ToString + " , lp.linp_linpID, " + i.ToString + "), 0) AS varchar(10)) [" + anioInicio.ToString + "-" + i.ToString + "]"
            Next
            For j As Int32 = 1 To semanaFin
                cadenaCapacidad += ", CAST(ISNULL(Programacion.fdu_capacidad_linea(" + anioFin.ToString + " , lp.linp_linpID, " + j.ToString + "), 0) AS varchar(10)) [" + anioFin.ToString + "-" + j.ToString + "]"
            Next
        End If

        cadenaCapacidad += " FROM Programacion.NavesAux nx" & _
               " JOIN Programacion.LineasProduccion lp ON lp.linp_idNave = nx.nave_naveid" & _
               " LEFT JOIN Programacion.SimulacionProgramasRenglonHist pr ON pr.prog_linpID = lp.linp_linpID" & _
               " AND pr.prog_folio = " + folio.ToString & _
               " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
               " AND pr.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString & _
               " WHERE lp.linp_activo = 1 And nx.nave_activo = 1"
        If idNave > 0 Then
            cadenaCapacidad += " AND lp.linp_idNave = " + idNave.ToString
        End If

        cadenaCapacidad += " GROUP BY nx.nave_nombre, lp.linp_linpID, lp.linp_nombre, lp.linp_idNave, pr.prog_linpID, nx.nave_idSicy, nx.nave_orden "




        cadenaPares = "SELECT * FROM (SELECT n.nave_nombre, lp.linp_nombre, 'Pares' AS Tipo, 2 AS ORD, lp.linp_idNave, prog_linpID, n.nave_idSicy, n.nave_orden, CAST(pr.prog_año AS varchar(4)) + '-' + CAST(pr.prog_semana AS varchar(4)) AS SEMANA," & _
           " (pr.prog_1 + pr.prog_2 + pr.prog_3 + pr.prog_4 + pr.prog_5 + pr.prog_6 + pr.prog_7 + pr.prog_8 + pr.prog_9 + pr.prog_10 +" & _
           " pr.prog_11 + pr.prog_12 + pr.prog_13 + pr.prog_14 + pr.prog_15 + pr.prog_16 + pr.prog_17 + pr.prog_18 + pr.prog_19 + pr.prog_20 +" & _
           " pr.prog_21 + pr.prog_22 + pr.prog_23 + pr.prog_24 + pr.prog_25 + pr.prog_26 + pr.prog_27 + pr.prog_28 + pr.prog_29 + pr.prog_30 +" & _
           " pr.prog_31 + pr.prog_32 + pr.prog_33 + pr.prog_34 + pr.prog_35 + pr.prog_36 + pr.prog_37 + pr.prog_38 + pr.prog_39 + pr.prog_40 +" & _
           " pr.prog_41 + pr.prog_42 + pr.prog_43 + pr.prog_44 + pr.prog_45 + pr.prog_46 + pr.prog_47 + pr.prog_48 + pr.prog_49 + pr.prog_50 +" & _
           " pr.prog_51 + pr.prog_52) AS cantidad	" & _
           " FROM Programacion.LineasProduccion lp" & _
           " JOIN Programacion.NavesAux n ON n.nave_naveid = lp.linp_idNave AND n.nave_activo = 1" & _
           " LEFT JOIN Programacion.SimulacionProgramasRenglonHist pr ON pr.prog_naveID = lp.linp_idNave" & _
           " AND pr.prog_linpID = lp.linp_linpID" & _
           " AND lp.linp_activo = 1" & _
           " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
           " AND pr.prog_folio = " + folio.ToString & _
           " AND pr.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString & _
           " LEFT JOIN Cliente.Cliente c ON c.clie_clienteid = pr.prog_idCliente AND c.clie_activo = 1" & _
           " LEFT JOIN vProductoEstilos vp ON vp.pstilo = pr.prog_productoEstiloID" & _
           " LEFT JOIN Programacion.bloqueo bl ON bl.idCadena = pr.prog_idCadena"
     

        If bloqueo = False And pedidos = True Then
            cadenaPares += " AND bl.idtblMotivo <= 0 AND bl.Captura <= 0 AND bl.Programacion <=  0" & _
             " WHERE pr.prog_idCadena NOT IN (SELECT DISTINCT(idCadena) FROM SICY.yuyin.dbo.Bloqueo WHERE idtblMotivo > 0 OR Captura	> 0 OR Programacion > 0)"
            cadenaPares += " AND lp.linp_activo = 1 AND n.nave_activo = 1"
            If idNave > 0 Then
                cadenaPares += " AND lp.linp_idNave = " + idNave.ToString
            End If

        ElseIf bloqueo = True And pedidos = False Then
            cadenaPares += " WHERE (bl.idtblMotivo > 0 OR bl.Captura > 0 OR bl.Programacion > 0)"
            cadenaPares += " AND lp.linp_activo = 1 AND n.nave_activo = 1"
            If idNave > 0 Then
                cadenaPares += " AND lp.linp_idNave = " + idNave.ToString
            End If
        Else
            cadenaPares += " WHERE lp.linp_activo = 1 AND n.nave_activo = 1"
            If idNave > 0 Then
                cadenaPares += " AND lp.linp_idNave = " + idNave.ToString
            End If
        End If


        cadenaPares += ") AS cons PIVOT (SUM(cantidad) FOR SEMANA IN ("

            Dim CadAnioSemanaPPares As String = ""
            If anioInicio = anioFin Then
                For i As Int32 = semanaInicio To semanaFin
                    CadAnioSemanaPPares += "[" + anioInicio.ToString + "-" + i.ToString + "],"
                Next
            ElseIf anioInicio < anioFin Then
                For i As Int32 = semanaInicio To 52
                    CadAnioSemanaPPares += "[" + anioInicio.ToString + "-" + i.ToString + "],"
                Next
                For j As Int32 = 1 To semanaFin
                    CadAnioSemanaPPares += "[" + anioFin.ToString + "-" + j.ToString + "],"
                Next
            End If
            cadenaPares += CadAnioSemanaPPares.Substring(0, CadAnioSemanaPPares.Length - 1)
            cadenaPares += " )) AS pvot"






            cadenaPorcentaje = "SELECT nx.nave_nombre, lp.linp_nombre, 'Porcentaje' AS Tipo, 3 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave," & _
            " ISNULL(pr.prog_linpID, 0) prog_linpID, nx.nave_idSicy, nx.nave_orden,"

            Dim CadAnioSemanaPPorciento As String = ""
            If anioInicio = anioFin Then
                For i As Int32 = semanaInicio To semanaFin
                    CadAnioSemanaPPorciento += " 0.0 [" + anioInicio.ToString + "-" + i.ToString + "],"
                Next
            ElseIf anioInicio < anioFin Then
                For i As Int32 = semanaInicio To 52
                    CadAnioSemanaPPorciento += " 0.0 [" + anioInicio.ToString + "-" + i.ToString + "],"
                Next
                For j As Int32 = 1 To semanaFin
                    CadAnioSemanaPPorciento += " 0.0 [" + anioFin.ToString + "-" + j.ToString + "],"
                Next
            End If
            cadenaPorcentaje += CadAnioSemanaPPorciento.Substring(0, CadAnioSemanaPPorciento.Length - 1)
            cadenaPorcentaje += "FROM Programacion.NavesAux nx" & _
            " JOIN Programacion.LineasProduccion lp ON lp.linp_idNave = nx.nave_naveid" & _
            " LEFT JOIN Programacion.SimulacionProgramasRenglonHist pr ON pr.prog_linpID = lp.linp_linpID" & _
            " AND pr.prog_folio = " + folio.ToString & _
            " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
            " AND pr.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString & _
            " WHERE lp.linp_activo = 1 And nx.nave_activo = 1" & _
            " GROUP BY nx.nave_nombre, lp.linp_linpID, lp.linp_nombre, lp.linp_idNave, pr.prog_linpID, nx.nave_idSicy, nx.nave_orden"

            cadenaRestante = "SELECT nx.nave_nombre, lp.linp_nombre, 'Restante' AS Tipo, 4 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave," & _
            " ISNULL(pr.prog_linpID, 0) prog_linpID, nx.nave_idSicy, nx.nave_orden,"

            Dim CadAnioSemanaPRestante As String = ""
            If anioInicio = anioFin Then
                For i As Int32 = semanaInicio To semanaFin
                    CadAnioSemanaPRestante += " 0 [" + anioInicio.ToString + "-" + i.ToString + "],"
                Next
            ElseIf anioInicio < anioFin Then
                For i As Int32 = semanaInicio To 52
                    CadAnioSemanaPRestante += " 0 [" + anioInicio.ToString + "-" + i.ToString + "],"
                Next
                For j As Int32 = 1 To semanaFin
                    CadAnioSemanaPRestante += " 0 [" + anioFin.ToString + "-" + j.ToString + "],"
                Next
            End If
            cadenaRestante += CadAnioSemanaPRestante.Substring(0, CadAnioSemanaPRestante.Length - 1)
            cadenaRestante += "FROM Programacion.NavesAux nx" & _
            " JOIN Programacion.LineasProduccion lp ON lp.linp_idNave = nx.nave_naveid" & _
            " LEFT JOIN Programacion.SimulacionProgramasRenglonHist pr ON pr.prog_linpID = lp.linp_linpID" & _
            " AND pr.prog_folio = " + folio.ToString & _
            " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
            " AND pr.prog_ProcSimuladorMaestroID = " + idSimulacionMaestro.ToString & _
            " WHERE lp.linp_activo = 1 And nx.nave_activo = 1" & _
            " GROUP BY nx.nave_nombre, lp.linp_linpID, lp.linp_nombre, lp.linp_idNave, pr.prog_linpID, nx.nave_idSicy, nx.nave_orden"





            Dim cadenaConsulta As String = ""
        cadenaConsulta = cadenaCapacidad + " UNION ALL " + cadenaPares + " UNION ALL " + cadenaPorcentaje + " UNION ALL " + cadenaRestante

        If ordenamiento = 1 Then
            cadenaConsulta += " ORDER BY nx.nave_nombre, lp.linp_nombre, ORD"
        ElseIf ordenamiento = 2 Then
            cadenaConsulta += " ORDER BY nx.nave_orden, lp.linp_nombre, ORD"
        ElseIf ordenamiento = 3 Then
            cadenaConsulta += " ORDER BY nx.nave_idSicy, lp.linp_nombre, ORD"
        End If
      
            dt = operacion.EjecutaConsulta(cadenaConsulta)

            Dim dtClon As New DataTable

            For Each columna As DataColumn In dt.Columns
                dtClon.Columns.Add(columna.ColumnName, System.Type.GetType("System.String"))
            Next

            For Each fila As DataRow In dt.Rows
                dtClon.ImportRow(fila)
            Next

            Return dtClon
    End Function



    Public Function consultaMapaSegmentado(ByVal anioInicio As Int32,
                                       ByVal anioFin As Int32,
                                       ByVal semanaInicio As Int32,
                                       ByVal semanaFin As Int32,
                                       ByVal idNave As Int32,
                                       ByVal pedidos As Boolean,
                                       ByVal bloqueo As Boolean,
                                       ByVal ordenamiento As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadenaCapacidad As String = ""
        Dim cadenaPares As String = ""
        Dim cadenaPorcentaje As String = ""
        Dim cadenaRestante As String = ""

        Dim dt As New DataTable

        If anioInicio = anioFin Then
            cadenaCapacidad = "SELECT nx.nave_nombre, lp.linp_nombre, 'Capacidad' AS Tipo, 1 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave, ISNULL(pr.prog_linpID, 0) prog_linpID," & _
            " nx.nave_idSicy, nx.nave_orden"

            For i As Int32 = semanaInicio To semanaFin
                cadenaCapacidad += ", CAST(ISNULL(Programacion.fdu_capacidad_linea(" + anioInicio.ToString + " , lp.linp_linpID, " + i.ToString + "), 0) AS varchar(10)) [" + anioInicio.ToString + "-" + i.ToString + "]"
            Next

        ElseIf anioInicio < anioFin Then

            cadenaCapacidad = "SELECT nx.nave_nombre, lp.linp_nombre, 'Capacidad' AS Tipo, 1 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave, ISNULL(pr.prog_linpID, 0) prog_linpID," & _
           " nx.nave_idSicy, nx.nave_orden"

            For i As Int32 = semanaInicio To 52
                cadenaCapacidad += ", CAST(ISNULL(Programacion.fdu_capacidad_linea(" + anioInicio.ToString + " , lp.linp_linpID, " + i.ToString + "), 0) AS varchar(10)) [" + anioInicio.ToString + "-" + i.ToString + "]"
            Next
            For j As Int32 = 1 To semanaFin
                cadenaCapacidad += ", CAST(ISNULL(Programacion.fdu_capacidad_linea(" + anioFin.ToString + " , lp.linp_linpID, " + j.ToString + "), 0) AS varchar(10)) [" + anioFin.ToString + "-" + j.ToString + "]"
            Next
        End If

        cadenaCapacidad += " FROM Programacion.NavesAux nx" & _
               " JOIN Programacion.LineasProduccion lp ON lp.linp_idNave = nx.nave_naveid" & _
               " LEFT JOIN Programacion.ProgramasRenglon pr ON pr.prog_linpID = lp.linp_linpID" & _
               " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
               " WHERE lp.linp_activo = 1 And nx.nave_activo = 1"
        If idNave > 0 Then
            cadenaCapacidad += " AND lp.linp_idNave = " + idNave.ToString
        End If

        cadenaCapacidad += " GROUP BY nx.nave_nombre, lp.linp_linpID, lp.linp_nombre, lp.linp_idNave, pr.prog_linpID, nx.nave_idSicy, nx.nave_orden "

        cadenaPares = "SELECT * FROM (SELECT n.nave_nombre, lp.linp_nombre, 'Pares' AS Tipo, 2 AS ORD, lp.linp_idNave, prog_linpID, n.nave_idSicy, n.nave_orden, CAST(pr.prog_año AS varchar(4)) + '-' + CAST(pr.prog_semana AS varchar(4)) AS SEMANA," & _
           " (pr.prog_1 + pr.prog_2 + pr.prog_3 + pr.prog_4 + pr.prog_5 + pr.prog_6 + pr.prog_7 + pr.prog_8 + pr.prog_9 + pr.prog_10 +" & _
           " pr.prog_11 + pr.prog_12 + pr.prog_13 + pr.prog_14 + pr.prog_15 + pr.prog_16 + pr.prog_17 + pr.prog_18 + pr.prog_19 + pr.prog_20 +" & _
           " pr.prog_21 + pr.prog_22 + pr.prog_23 + pr.prog_24 + pr.prog_25 + pr.prog_26 + pr.prog_27 + pr.prog_28 + pr.prog_29 + pr.prog_30 +" & _
           " pr.prog_31 + pr.prog_32 + pr.prog_33 + pr.prog_34 + pr.prog_35 + pr.prog_36 + pr.prog_37 + pr.prog_38 + pr.prog_39 + pr.prog_40 +" & _
           " pr.prog_41 + pr.prog_42 + pr.prog_43 + pr.prog_44 + pr.prog_45 + pr.prog_46 + pr.prog_47 + pr.prog_48 + pr.prog_49 + pr.prog_50 +" & _
           " pr.prog_51 + pr.prog_52) AS cantidad	" & _
           " FROM Programacion.LineasProduccion lp" & _
           " JOIN Programacion.NavesAux n ON n.nave_naveid = lp.linp_idNave AND n.nave_activo = 1" & _
           " LEFT JOIN Programacion.ProgramasRenglon pr ON pr.prog_naveID = lp.linp_idNave" & _
           " AND pr.prog_linpID = lp.linp_linpID" & _
           " AND lp.linp_activo = 1" & _
           " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
           " LEFT JOIN Cliente.Cliente c ON c.clie_clienteid = pr.prog_idCliente AND c.clie_activo = 1" & _
           " LEFT JOIN vProductoEstilos vp ON vp.pstilo = pr.prog_productoEstiloID" & _
           " LEFT JOIN Programacion.bloqueo bl ON bl.idCadena = pr.prog_idCadena"


        If bloqueo = False And pedidos = True Then
            cadenaPares += " AND bl.idtblMotivo <= 0 AND bl.Captura <= 0 AND bl.Programacion <=  0" & _
             " WHERE pr.prog_idCadena NOT IN (SELECT DISTINCT(idCadena) FROM SICY.yuyin.dbo.Bloqueo WHERE idtblMotivo > 0 OR Captura	> 0 OR Programacion > 0)"
            cadenaPares += " AND lp.linp_activo = 1 AND n.nave_activo = 1"
            If idNave > 0 Then
                cadenaPares += " AND lp.linp_idNave = " + idNave.ToString
            End If

        ElseIf bloqueo = True And pedidos = False Then
            cadenaPares += " WHERE (bl.idtblMotivo > 0 OR bl.Captura > 0 OR bl.Programacion > 0)"
            cadenaPares += " AND lp.linp_activo = 1 AND n.nave_activo = 1"
            If idNave > 0 Then
                cadenaPares += " AND lp.linp_idNave = " + idNave.ToString
            End If
        Else
            cadenaPares += " WHERE lp.linp_activo = 1 AND n.nave_activo = 1"
            If idNave > 0 Then
                cadenaPares += " AND lp.linp_idNave = " + idNave.ToString
            End If
        End If

        cadenaPares += ") AS cons PIVOT (SUM(cantidad) FOR SEMANA IN ("

        Dim CadAnioSemanaPPares As String = ""
        If anioInicio = anioFin Then
            For i As Int32 = semanaInicio To semanaFin
                CadAnioSemanaPPares += "[" + anioInicio.ToString + "-" + i.ToString + "],"
            Next
        ElseIf anioInicio < anioFin Then
            For i As Int32 = semanaInicio To 52
                CadAnioSemanaPPares += "[" + anioInicio.ToString + "-" + i.ToString + "],"
            Next
            For j As Int32 = 1 To semanaFin
                CadAnioSemanaPPares += "[" + anioFin.ToString + "-" + j.ToString + "],"
            Next
        End If
        cadenaPares += CadAnioSemanaPPares.Substring(0, CadAnioSemanaPPares.Length - 1)
        cadenaPares += " )) AS pvot"

        cadenaPorcentaje = "SELECT nx.nave_nombre, lp.linp_nombre, 'Porcentaje' AS Tipo, 3 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave," & _
        " ISNULL(pr.prog_linpID, 0) prog_linpID, nx.nave_idSicy, nx.nave_orden,"

        Dim CadAnioSemanaPPorciento As String = ""
        If anioInicio = anioFin Then
            For i As Int32 = semanaInicio To semanaFin
                CadAnioSemanaPPorciento += " 0.0 [" + anioInicio.ToString + "-" + i.ToString + "],"
            Next
        ElseIf anioInicio < anioFin Then
            For i As Int32 = semanaInicio To 52
                CadAnioSemanaPPorciento += " 0.0 [" + anioInicio.ToString + "-" + i.ToString + "],"
            Next
            For j As Int32 = 1 To semanaFin
                CadAnioSemanaPPorciento += " 0.0 [" + anioFin.ToString + "-" + j.ToString + "],"
            Next
        End If
        cadenaPorcentaje += CadAnioSemanaPPorciento.Substring(0, CadAnioSemanaPPorciento.Length - 1)
        cadenaPorcentaje += "FROM Programacion.NavesAux nx" & _
        " JOIN Programacion.LineasProduccion lp ON lp.linp_idNave = nx.nave_naveid" & _
        " LEFT JOIN Programacion.ProgramasRenglon pr ON pr.prog_linpID = lp.linp_linpID" & _
        " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " WHERE lp.linp_activo = 1 And nx.nave_activo = 1" & _
        " GROUP BY nx.nave_nombre, lp.linp_linpID, lp.linp_nombre, lp.linp_idNave, pr.prog_linpID, nx.nave_idSicy, nx.nave_orden"

        cadenaRestante = "SELECT nx.nave_nombre, lp.linp_nombre, 'Restante' AS Tipo, 4 AS ORD, ISNULL(lp.linp_idNave, 0) linp_idNave," & _
        " ISNULL(pr.prog_linpID, 0) prog_linpID, nx.nave_idSicy, nx.nave_orden,"

        Dim CadAnioSemanaPRestante As String = ""
        If anioInicio = anioFin Then
            For i As Int32 = semanaInicio To semanaFin
                CadAnioSemanaPRestante += " 0 [" + anioInicio.ToString + "-" + i.ToString + "],"
            Next
        ElseIf anioInicio < anioFin Then
            For i As Int32 = semanaInicio To 52
                CadAnioSemanaPRestante += " 0 [" + anioInicio.ToString + "-" + i.ToString + "],"
            Next
            For j As Int32 = 1 To semanaFin
                CadAnioSemanaPRestante += " 0 [" + anioFin.ToString + "-" + j.ToString + "],"
            Next
        End If
        cadenaRestante += CadAnioSemanaPRestante.Substring(0, CadAnioSemanaPRestante.Length - 1)
        cadenaRestante += "FROM Programacion.NavesAux nx" & _
        " JOIN Programacion.LineasProduccion lp ON lp.linp_idNave = nx.nave_naveid" & _
        " LEFT JOIN Programacion.ProgramasRenglon pr ON pr.prog_linpID = lp.linp_linpID" & _
        " AND pr.prog_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " WHERE lp.linp_activo = 1 And nx.nave_activo = 1" & _
        " GROUP BY nx.nave_nombre, lp.linp_linpID, lp.linp_nombre, lp.linp_idNave, pr.prog_linpID, nx.nave_idSicy, nx.nave_orden"

        Dim cadenaConsulta As String = ""
        cadenaConsulta = cadenaCapacidad + " UNION ALL " + cadenaPares + " UNION ALL " + cadenaPorcentaje + " UNION ALL " + cadenaRestante

        If ordenamiento = 1 Then
            cadenaConsulta += " ORDER BY nx.nave_nombre, lp.linp_nombre, ORD"
        ElseIf ordenamiento = 2 Then
            cadenaConsulta += " ORDER BY nx.nave_orden, lp.linp_nombre, ORD"
        ElseIf ordenamiento = 3 Then
            cadenaConsulta += " ORDER BY nx.nave_idSicy, lp.linp_nombre, ORD"
        End If

        dt = operacion.EjecutaConsulta(cadenaConsulta)

        Dim dtClon As New DataTable

        For Each columna As DataColumn In dt.Columns
            dtClon.Columns.Add(columna.ColumnName, System.Type.GetType("System.String"))
        Next

        For Each fila As DataRow In dt.Rows
            dtClon.ImportRow(fila)
        Next

        Return dtClon
    End Function

End Class
