Imports System.Data.SqlClient

Public Class HormasCapacidadesDA
    Public Function TablaHormasDisponibles(naveID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL = <consulta>
                        select h.horma_hormaid,t.talla_tallaid,h.horma_descripcion,t.talla_descripcion from Programacion.Productos p
                        inner join Programacion.ProductoEstilo pe on p.prod_productoid=pe.pres_productoid
                        inner JOIN Programacion.Hormas h on pe.pres_horma=h.horma_hormaid
                        inner JOIN Programacion.EstilosProducto ep on ep.espr_estiloproductoid=pe.pres_estiloid
                        inner join Programacion.Tallas t on t.talla_tallaid=ep.espr_tallaid
                        where h.horma_activo = 1 And p.prod_activo = 1 And pe.pres_activo = 1 And t.talla_activo = 1 And p.prod_activo = 1 And pe.pres_activo = 1
                        EXCEPT
                         SELECT h.horma_hormaid,
                        t.talla_tallaid,
	                    h.horma_descripcion,
	                    t.talla_descripcion
                from Programacion.Hormas h
                INNER JOIN Programacion.HormasPorNave hn On hn.hona_hormaID = h.horma_hormaid
                INNER JOIN Programacion.Tallas t ON hn.hona_tallaid = t.talla_tallaid
                WHERE h.horma_activo = 1 and hn.hona_activo=1 and hn.hona_naveID =  <%= naveID.ToString %>
                        group BY h.horma_descripcion,t.talla_descripcion,h.horma_hormaid,t.talla_tallaid
                        order by h.horma_descripcion, t.talla_descripcion
               </consulta>.Value
         Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Sub AsigarHorma(naveID As Int32, hormaID As Int32, tallaID As Integer, capacidad As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim hona_hormaID As Integer
        Dim SQL As String = ""

        Dim existe As String = operaciones.EjecutaConsultaEscalar("SELECT	hona_hormaPorNaveID FROM Programacion.HormasPorNave WHERE hona_naveID =" & naveID & " and  hona_hormaid= " & hormaID & " and  hona_tallaid= " & tallaID)
   
        If existe = "" Then
            SQL = <consulta>
                INSERT INTO Programacion.HormasPorNave
                            (hona_naveID,hona_hormaID,hona_usuariocreoid,hona_tallaid,hona_capacidad, HONA_ACTIVO)
                VALUES(<%= naveID.ToString %>,<%= hormaID.ToString %>,<%= idUsuario.ToString %>,<%= tallaID.ToString %>,<%= capacidad.ToString %>,1) 
                 </consulta>.Value
        Else
            hona_hormaID = Int(existe.ToString)
            SQL += " UPDATE Programacion.HormasPorNave SET HONA_ACTIVO=1,hona_fechamodifico=GETDATE(),"
            SQL += " hona_usuariomodificoid= " & idUsuario.ToString & " "
            SQL += " WHERE hona_hormapornaveID=" & hona_hormaID
        End If
        operaciones.EjecutaSentencia(SQL)
    End Sub
    Public Function verificarHormaNave(naveID As Integer, hormaID As Integer, tallaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL = <consulta>
                    SELECT * FROM Programacion.HormasPorNave WHERE hona_naveID = <%= naveID.ToString %> AND hona_hormaID = <%= hormaID.ToString %> AND hona_tallaid = <%= tallaID.ToString %>
              </consulta>.Value
        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Sub actualizarHormaNave(naveID As Integer, hormaID As Integer, tallaID As Integer, capacidad As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        SQL = <consulta>
                    UPDATE Programacion.HormasPorNave SET hona_activo=1, hona_capacidad = <%= capacidad.ToString %>, hona_fechamodifico = GETDATE(), hona_usuariomodificoid = <%= idUsuario.ToString %> WHERE hona_naveID = <%= naveID.ToString %> AND hona_hormaID = <%= hormaID.ToString %> AND hona_tallaid = <%= tallaID.ToString %>
              </consulta>.Value
        operaciones.EjecutaConsulta(SQL)
    End Sub
    Public Function TablaHormasAsignadas(naveID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL = <consulta> SELECT
	hn.hona_hormaPorNaveID,
   	hn.hona_tallaid,
	hn.hona_hormaID,
	h.horma_descripcion,
	t.talla_descripcion,
	hn.hona_capacidad,
	(SELECT COUNT (DISTINCT hcs.horc_linpID) FROM Programacion.LineasProduccion lps 
JOIN Programacion.HormasCapacidad hcs ON hcs.horc_linpID = lps.linp_linpID
JOIN Programacion.NavesAux ns ON lps.linp_idNave = ns.nave_naveid
JOIN Programacion.HormasPorNave hns on hcs.horc_hormaID = hns.hona_hormaID AND hcs.horc_tallaid = hns.hona_tallaid AND ns.nave_naveid = hns.hona_naveID
WHERE lps.linp_activo = 1 AND ns.nave_activo = 1 AND ns.nave_naveid = <%= naveID.ToString %>
AND hcs.horc_hormaID = hn.hona_hormaID AND hcs.horc_tallaid = hn.hona_tallaid AND hcs.horc_activo = 1 AND hcs.horc_año >= DATEPART(YEAR, GETDATE())) as Celulas,
(SELECT COUNT (DISTINCT pnx.prna_productoEstiloID) FROM Programacion.LineasProduccion lpx 
JOIN Programacion.NavesAux nx ON lpx.linp_idNave = nx.nave_naveid
JOIN Programacion.ProductosNave pnx on nx.nave_naveid = pnx.prna_naveID
WHERE lpx.linp_activo = 1 AND nx.nave_activo = 1 AND pnx.prna_activo = 1 AND nx.nave_naveid =  <%= naveID.ToString %>
AND pnx.prna_hormaid = hn.hona_hormaID AND pnx.prna_tallaID = hn.hona_tallaid  ) as ProductoAsignados,
(SELECT COUNT (DISTINCT pcz.proc_productoEstiloId) FROM Programacion.LineasProduccion lpz 
JOIN Programacion.ProductosCapacidad pcz ON pcz.proc_linpID = lpz.linp_linpID
JOIN Programacion.NavesAux nz ON lpz.linp_idNave = nz.nave_naveid
JOIN Programacion.ProductosNave pnz on pcz.proc_productoEstiloId = pnz.prna_productoEstiloID AND nz.nave_naveid = pnz.prna_naveID
WHERE lpz.linp_activo = 1 AND nz.nave_activo = 1 AND pnz.prna_activo = 1 AND nz.nave_naveid =  <%= naveID.ToString %>
AND pcz.proc_hormaid = hn.hona_hormaID AND pcz.proc_tallaID =  hn.hona_tallaid  AND pcz.proc_activo = 1) ProductosCapacidad,
'NO' AS Elimina,
(SELECT TOP 1 CAST(hcx.horc_semanaelimina AS varchar(2)) + ' (' + CAST(hcx.horc_año AS varchar(4))+')'
FROM Programacion.HormasCapacidad hcx 
JOIN Programacion.LineasProduccion lpx ON lpx.linp_linpID = hcx.horc_linpID
WHERE hcx.horc_hormaID = hn.hona_hormaID AND hcx.horc_tallaid = hn.hona_tallaid 
AND lpx.linp_activo = 1 AND lpx.linp_idNave =  <%= naveID.ToString %>
AND hcx.horc_hormaID NOT IN (SELECT DISTINCT(hcy.horc_hormaID) 
FROM Programacion.HormasCapacidad hcy 
JOIN Programacion.LineasProduccion lpy ON lpy.linp_linpID = hcy.horc_linpID
WHERE hcy.horc_hormaID = hn.hona_hormaID AND hcy.horc_tallaid = hn.hona_tallaid
AND lpy.linp_activo = 1 AND lpy.linp_idNave =  <%= naveID.ToString %>
AND hcy.horc_semanaelimina IS NULL  AND  hcy.horc_activo = 1)  AND hcx.horc_activo = 1 ORDER BY horc_año DESC, hcx.horc_semanaelimina DESC) AS semanaElimina
FROM Programacion.Hormas h
INNER JOIN Programacion.HormasPorNave hn
	ON hn.hona_hormaID = h.horma_hormaid
INNER JOIN Programacion.Tallas t
	ON hn.hona_tallaid = t.talla_tallaid
WHERE h.horma_activo = 1
AND hn.hona_activo = 1
AND hn.hona_naveID =  <%= naveID.ToString %>
GROUP BY	h.horma_descripcion,
			t.talla_descripcion,
			hn.hona_hormaPorNaveID,
			hn.hona_capacidad,
			hn.hona_tallaid,
			hn.hona_hormaID
ORDER BY h.horma_descripcion, t.talla_descripcion
                </consulta>.Value
        
        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Function obtnerHormasNave(ByVal naveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = <consulta>
                       SELECT
	                        horma_hormaid,
	                        horma_descripcion
                        FROM Programacion.HormasPorNave
                        INNER JOIN Programacion.Hormas
	                        ON horma_hormaid = hona_hormaID
                        WHERE hona_naveID = <%= naveID.ToString %> and horma_activo = 1 and hona_activo=1
                        GROUP by horma_hormaid,horma_descripcion
                        ORDER by horma_descripcion
                   </consulta>.Value
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function obtnerTallasHormas(ByVal hormaID As Integer, ByVal naves As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        If hormaID = 0 Then
            consulta = <consulta>
                        SELECT
	                        talla_tallaid,
	                        talla_descripcion
                        FROM Programacion.HormasPorNave
                        INNER JOIN Programacion.Tallas
	                        ON hona_tallaid = talla_tallaid
                        WHERE  hona_naveID =  <%= naves.ToString %> and hona_activo=1
	                        GROUP by talla_tallaid, talla_descripcion
                        ORDER by talla_descripcion
                   </consulta>
        Else
            consulta = <consulta>
                        SELECT
	                        talla_tallaid,
	                        talla_descripcion
                        FROM Programacion.HormasPorNave
                        INNER JOIN Programacion.Tallas
	                        ON hona_tallaid = talla_tallaid
                        WHERE hona_hormaID = <%= hormaID.ToString %> and hona_naveID =  <%= naves.ToString %> and hona_activo=1
	                        GROUP by talla_tallaid, talla_descripcion
                        ORDER by talla_descripcion
                   </consulta>
        End If
       
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub actualizarCapacidasHormaAsignada(hormaAsignada As Integer, capacidad As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        SQL = "UPDATE programacion.hormaspornave SET hona_capacidad =" & capacidad.ToString & ",hona_fechamodifico=getdate() ,hona_usuariomodificoid=" & idUsuario.ToString & " WHERE hona_hormaPorNaveID =" & hormaAsignada.ToString
        operaciones.EjecutaSentencia(SQL)
    End Sub
    Public Function TablaHormasTodas(hormaID As Int32, tallaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL += " select DISTINCT nave_nombre Nave, nave_orden "
        SQL += " FROM Programacion.HormasPorNave"
        SQL += " inner JOIN Programacion.NavesAux on nave_naveid =hona_naveID"
        SQL += " where nave_activo=1 AND hona_activo = 1 and hona_hormaID = " & hormaID.ToString & " and hona_tallaid =" & tallaID.ToString
        SQL += " ORDER by nave_orden"
        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Sub DesasignarColeccion(ByVal conaID As Integer, ByVal tipo As Boolean, ByVal naveId As Integer, ByVal tallaID As Integer, ByVal hormaID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        If tipo Then
            '            SQL = <consulta>
            '                      DELETE from Programacion.ProductosNave WHERE prna_prnaID in(
            '                       SELECT
            '	                    prna_prnaID
            '                    FROM Programacion.ProductosNave
            '                    INNER JOIN vProductos
            '	                    ON v_prodID = prna_productoID
            '	                    AND v_productoEstiloID = prna_productoEstiloID
            '	                    AND v_tallaID = <%= tallaID.ToString %>
            'AND v_hormaId = <%= hormaID.ToString %>

            '                         INNER JOIN Programacion.Productos ON v_prodID = prod_productoid
            '        WHERE pres_activo = 1
            '                    AND prna_naveID = <%= naveId.ToString %>
            '                        )
            '                     </consulta>.Value
            SQL = <consulta>
                      update Programacion.ProductosNave set prna_activo=0, prna_fechamodificacion=getdate(), 
                prna_usuariomodificoid = <%= idUsuario.ToString %>, prna_orden=0 
                    WHERE prna_prnaID in(
                       SELECT
	                    prna_prnaID
                    FROM Programacion.ProductosNave
                    INNER JOIN vProductos
	                    ON v_prodID = prna_productoID
	                    AND v_productoEstiloID = prna_productoEstiloID
	                    AND v_tallaID = <%= tallaID.ToString %>
AND v_hormaId = <%= hormaID.ToString %>
                   
                         INNER JOIN Programacion.Productos ON v_prodID = prod_productoid
        WHERE pres_activo = 1
                    AND prna_naveID = <%= naveId.ToString %>
                        )
                     </consulta>.Value
            operaciones.EjecutaSentencia(SQL)
        End If
        ' SQL = "DELETE FROM programacion.HormasPorNave WHERE hona_hormaPorNaveID=" & conaID.ToString
        SQL = "update programacion.HormasPorNave set hona_activo=0,hona_fechamodifico=getdate(),hona_usuariomodificoid=" & idUsuario & "  WHERE hona_hormaPorNaveID=" & conaID.ToString

        operaciones.EjecutaSentencia(SQL)
    End Sub
    Public Function listaNaves() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select n.nave_naveid id_,n.nave_nombre from Framework.Naves n INNER JOIN Programacion.NavesAux na On n.nave_naveid = na.nave_naveid where na.nave_activo='True' order by na.nave_orden"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function TablaProductosDisponibles(hormaID As Int32, naveID As Int32, tallaID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = <consulta>
                       		SELECT
		ModSicy,
		Marca,
		Coleccion,
		CASE
			WHEN Modelo = '' THEN prod_codigo
			ELSE Modelo
		END Modelo,
		Piel,
		Color,
		Corrida,
		Horma,
		v_prodID,
		v_productoEstiloID,
		v_tallaID
	FROM vProductos
	INNER JOIN (SELECT
		pres_productoID,
		pres_productoEstiloID,
		espr_tallaID
	FROM programacion.ProductoEstilo
	INNER JOIN Programacion.EstilosProducto
		ON espr_estiloproductoid = pres_estiloID 
		INNER JOIN
	Programacion.HormasPorNave ON hona_hormaID = pres_horma and hona_tallaid = espr_tallaid
	WHERE hona_naveID = <%= naveID.ToString %> and hona_activo=1
	GROUP by pres_productoid, pres_productoestiloid,espr_tallaid
	EXCEPT SELECT
	                        prna_productoID,
	                        prna_productoEstiloID,
	                        prna_tallaID
                        FROM Programacion.ProductosNave
	WHERE prna_naveID = <%= naveID.ToString %> 
	AND PRNA_ACTIVO=1) AS ini
		ON v_productoEstiloID = pres_productoestiloID
	INNER JOIN Programacion.Productos
		ON v_prodID = prod_productoid
		AND v_prodID = pres_productoid
		AND v_tallaID = espr_tallaID
	WHERE pres_activo = 1 and Productos.prod_activo = 1 
	
	
                    </consulta>.Value
        If Not hormaID = 0 Then
            consulta += " AND v_hormaId =" + hormaID.ToString
        End If

        If Not tallaID = 0 Then
            consulta += " AND v_tallaID =" + tallaID.ToString
        End If
        consulta += " ORDER BY Marca, Coleccion, Modelo, Piel, Color, Corrida"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function TablaProductoAsignado(naveID As Int32, hormaID As Int32, ByVal idTalla As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = <consulta>
                       SELECT
	                    prna_prnaID,
	                    ModSicy,	
	                    CASE
		                    WHEN Modelo = '' THEN prod_codigo
		                    ELSE Modelo
	                    END Modelo,
	                    Corrida,
	                    Piel,
	                    Color,
	                    prna_capacidad,
                        prna_orden,
                        (SELECT
	                    COUNT (DISTINCT pcs.proc_linpID)
	                    FROM Programacion.LineasProduccion lps
	                    JOIN Programacion.ProductosCapacidad pcs ON pcs.proc_linpID = lps.linp_linpID
	                    JOIN Programacion.NavesAux ns ON lps.linp_idNave = ns.nave_naveid
	                    WHERE lps.linp_activo = 1 AND ns.nave_activo = 1 AND ns.nave_naveid = <%= naveID.ToString %> 
                        AND pcs.proc_activo = 1 AND pcs.proc_activo = 1
	                    AND pcs.proc_productoEstiloId = v_productoEstiloID) AS celulasCap,
                        'NO' AS puedeEliminar,
	                    (SELECT TOP 1 CAST(pcx.proc_semanaelimina AS varchar(2)) + ' (' + CAST(pcx.proc_año AS varchar(4))+')' FROM Programacion.ProductosCapacidad pcx
	                    JOIN Programacion.LineasProduccion lpx ON lpx.linp_linpID = pcx.proc_linpID
	                    WHERE pcx.proc_productoEstiloId = v_productoEstiloID
	                    AND lpx.linp_activo = 1 AND pcx.proc_activo = 1 AND lpx.linp_idNave = <%= naveID.ToString %> 
	                    AND pcx.proc_productoEstiloId NOT IN  (SELECT DISTINCT(pcy.proc_productoEstiloId) FROM Programacion.ProductosCapacidad pcy
	                    JOIN Programacion.LineasProduccion lpy ON lpy.linp_linpID = pcy.proc_linpID
	                    WHERE pcy.proc_productoEstiloId = v_productoEstiloID
	                    AND lpy.linp_activo = 1 AND pcy.proc_activo = 1 AND lpy.linp_idNave = <%= naveID.ToString %>
                        AND pcy.proc_semanaelimina IS NULL AND pcy.proc_año >= DATEPART(YEAR, GETDATE()))
	                    ORDER BY pcx.proc_año DESC, pcx.proc_semanaelimina DESC) AS Semana,
	                    Coleccion,
	                    Marca,
	                    Horma,
	                    prna_muestras,	                    
	                    v_hormaID,
	                    v_productoEstiloID,
	                    v_tallaID,
	                    v_prodID
                    FROM Programacion.ProductosNave
                    INNER JOIN vProductos
	                    ON v_prodID = prna_productoID
	                    AND v_productoEstiloID = prna_productoEstiloID
	                    AND v_tallaID = v_tallaID
                        
 </consulta>

        If idTalla <> 0 Then
            consulta += " AND v_tallaID = " + idTalla.ToString
        End If
        If Not hormaID = 0 Then
            consulta += "AND v_hormaId =" + hormaID.ToString
        End If
        consulta += <consulta>
                         INNER JOIN Programacion.Productos ON v_prodID = prod_productoid
        WHERE pres_activo = 1 and Productos.prod_activo = 1  AND PRNA_ACTIVO=1 
	
                    AND prna_naveID = <%= naveID.ToString %>
                        ORDER BY Marca, Coleccion, Modelo, Piel, Color, Corrida
                     </consulta>.Value
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Sub AsignarProducto(naveID As Int32, productoId As Int32, productoEstiloID As Int32, tallaID As Int32, capacidad As Integer, orden As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim prna_prnaID As Integer


        If capacidad = 0 Then
            'capacidad = operaciones.EjecutaConsultaEscalar("SELECT DISTINCT top 1 horc_1 FROM Programacion.HormasCapacidad where horc_año=datepart(year,getdate()) AND horc_linpID =(SELECT TOP 1 linp_linpID  FROM Programacion.LineasProduccion where linp_idNave =" & naveID & ") AND horc_hormaID =(SELECT TOP 1 v_hormaID  FROM vproductos where v_productoEstiloID = " & productoEstiloID & " AND v_tallaID =" & tallaID & ")")
            capacidad = operaciones.EjecutaConsultaEscalar("SELECT	hona_capacidad FROM Programacion.HormasPorNave WHERE  hona_naveID =" & naveID & " and   hona_tallaID = " & tallaID & " and hona_hormaID in (SELECT TOP 1	v_hormaID FROM vproductos WHERE v_productoEstiloID = " & productoEstiloID & " AND v_tallaID =" & tallaID & ")")
        End If
        Dim valorOrden As Integer = operaciones.EjecutaConsultaEscalar("(SELECT COALESCE((max(prna_orden)+1),1) orden_nave FROM Programacion.ProductosNave WHERE  prna_productoID = " & productoId & " and prna_productoEstiloID = " & productoEstiloID & " and prna_tallaID = " & tallaID & ")")
        Dim existe As String = operaciones.EjecutaConsultaEscalar("SELECT	Prna_prnaid FROM Programacion.ProductosNave WHERE prna_naveID =" & naveID & " and  prna_productoEstiloID= " & productoEstiloID & " AND prna_tallaID =" & tallaID)
        If orden = 0 Or orden >= valorOrden Then
            orden = valorOrden

        End If
        Dim prna_hormaID As Integer = operaciones.EjecutaConsultaEscalar("select pres_horma from Programacion.ProductoEstilo where pres_productoestiloid=" & productoEstiloID)

        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        If existe = "" Then

            SQL += " INSERT INTO Programacion.ProductosNave"
            SQL += " (prna_naveID,prna_productoID,prna_productoEstiloID,prna_tallaID,prna_capacidad,prna_fechacreacion,prna_usuariocreoid,prna_orden,prna_hormaid)"
            SQL += " VALUES"
            SQL += " (" & naveID & "," & productoId & "," & productoEstiloID & "," & tallaID & "," & capacidad & ",GETDATE()," + idUsuario.ToString + "," & orden.ToString & "," & prna_hormaID.ToString & ""
            SQL += "  )"
            operaciones.EjecutaSentencia(SQL)
            prna_prnaID = operaciones.EjecutaConsultaEscalar(" SELECT MAX(prna_prnaID) FROM Programacion.ProductosNave WHERE prna_naveID=" & naveID & " AND prna_productoEstiloID=" & productoEstiloID)
        Else
            prna_prnaID = Int(existe.ToString)
            SQL += " UPDATE Programacion.ProductosNave SET PRNA_ACTIVO=1,prna_fechamodificacion=GETDATE(),PRNA_CAPACIDAD= " & capacidad & ",PRNA_ORDEN=" & orden & ","
            SQL += " prna_usuariomodificoid= " & idUsuario.ToString & " "
            SQL += " WHERE Prna_prnaid=" & prna_prnaID
            operaciones.EjecutaSentencia(SQL)
        End If



        ordenes(orden, orden, prna_prnaID)

    End Sub
    Public Function verificarProductoAsignar(naveID As Int32, productoId As Int32, productoEstiloID As Int32, tallaID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL = <consulta>
                SELECT * FROM Programacion.ProductosNave 
                    WHERE prna_naveID = <%= naveID.ToString %> 
                        and prna_productoID = <%= productoId.ToString %> 
                        and prna_productoEstiloID = <%= productoEstiloID.ToString %> 
                        and prna_tallaID = <%= tallaID.ToString %>
              </consulta>.Value
        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Sub actualizarProductoAsignar(naveID As Int32, productoId As Int32, productoEstiloID As Int32, tallaID As Int32, capacidad As Integer, orden As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Dim SQL As String = ""
        SQL = <consulta>
                UPDATE Programacion.ProductosNave SET prna_capacidad = <%= capacidad.ToString %>,prna_activo=1,
prna_orden =<%= orden.ToString %>,prna_usuariomodificoid= <%= idUsuario.ToString %>,prna_fechamodificacion = GETDATE()
                     WHERE prna_naveID = <%= naveID.ToString %> 
                        and prna_productoID = <%= productoId.ToString %> 
                        and prna_productoEstiloID = <%= productoEstiloID.ToString %> 
                        and prna_tallaID = <%= tallaID.ToString %>
              </consulta>.Value
        operaciones.EjecutaConsulta(SQL)
        Dim prna_prnaID As Integer
        Dim prna_orden_anterior As Integer
        prna_prnaID = operaciones.EjecutaConsultaEscalar(" SELECT MAX(prna_prnaID) FROM Programacion.ProductosNave WHERE prna_naveID=" & naveID & " AND prna_productoEstiloID=" & productoEstiloID)
        prna_orden_anterior = operaciones.EjecutaConsultaEscalar(" SELECT MAX(prna_orden) FROM Programacion.ProductosNave WHERE prna_naveID=" & naveID & " AND prna_productoEstiloID=" & productoEstiloID)
        ordenes(prna_orden_anterior, orden, prna_prnaID)
    End Sub
    Public Sub DesasignarProducto(prna_prnaID As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        'SQL = "DELETE FROM Programacion.productosnave where prna_prnaID=" & prna_prnaID.ToString
        SQL = "update Programacion.productosnave set prna_activo=0,prna_orden=0, prna_usuariomodificoid=" & idUsuario & ",prna_fechamodificacion=getdate()  where prna_prnaID=" & prna_prnaID.ToString
        operaciones.EjecutaSentencia(SQL)
        ordenes(0, 0, prna_prnaID)
    End Sub
    Public Function obtenerOrdenNaves() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL = "select   nave_orden from Programacion.NavesAux where nave_activo =1 ORDER BY nave_orden"
        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Sub actualizarOrdenCantidadProducto(ByVal OrdenAnterior As Integer, ByVal aCantidad As Boolean, ByVal cantidad As Integer, ByVal aOrden As Boolean, ByVal orden As Integer, ByVal prnaID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        SQL = "UPDATE programacion.productosnave SET "
        If aCantidad Then
            SQL += "prna_capacidad = " + cantidad.ToString
        End If
        If aCantidad And aOrden Then
            SQL += " , "
        End If
        If aOrden Then

            SQL += "prna_orden = " + orden.ToString
        End If
        SQL += ", prna_usuariomodificoid = " + idUsuario.ToString + ",prna_fechamodificacion = GETDATE() "
        SQL += "WHERE prna_prnaID = " + prnaID.ToString
        operaciones.EjecutaConsulta(SQL)
        orden = ordenes(OrdenAnterior, orden, prnaID)

    End Sub
    Public Function ordenes(ByVal valorAnterior As Integer, ByVal valorNuevo As Integer, ByVal idPrna As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@NaveProductoID"
        ParametroParaLista.Value = idPrna
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@valorAnterior"
        ParametroParaLista.Value = valorAnterior
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@valorNuevo"
        ParametroParaLista.Value = valorNuevo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idUsuario"
        ParametroParaLista.Value = idUsuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_SimuladorPedidos_ActualizarOrdenNaves", ListaParametros)

        'If valorAnterior >= valorNuevo Then

        'End If

        'Dim consultas As String = <consulta>
        '                            SELECT
        '                            COALESCE((max(prna_orden)),1) orden_nave
        '                            FROM Programacion.ProductosNave
        '                            INNER JOIN (SELECT
        '                             prna_naveID,
        '                             prna_productoID,
        '                             prna_productoEstiloID,
        '                             prna_tallaID
        '                            FROM Programacion.ProductosNave
        '                            WHERE prna_prnaID = <%= idPrna.ToString %>) tabla
        '                             ON  tabla.prna_productoEstiloID = ProductosNave.prna_productoEstiloID 
        '                              and tabla.prna_productoID = ProductosNave.prna_productoID and tabla.prna_tallaID = ProductosNave.prna_tallaID
        '                            </consulta>.Value
        'Dim valorMaximo As Integer = operaciones.EjecutaConsultaEscalar(consultas)
        'Dim valorActual As Integer = operaciones.EjecutaConsultaEscalar("SELECT prna_orden FROM  Programacion.ProductosNave WHERE  prna_prnaID = " + idPrna.ToString + " ")
        'Dim valorMayo As String = ">="
        'If valorNuevo > valorActual Then
        '    'Se recorre posiciones superiores
        '    If valorNuevo > valorMaximo Then
        '        valorNuevo = valorMaximo
        '    End If
        '    Dim sql1 As String = <consulta>
        '                                     UPDATE n1
        '                                     SET n1.prna_orden = (tabla2.Row )
        '                                        FROM Programacion.ProductosNave n1
        '                                     INNER JOIN (
        '                                      SELECT
        '                                                ROW_NUMBER() OVER(ORDER BY prna_orden,prna_fechamodificacion asc ) AS Row, prna_orden, prna_prnaID
        '                                                FROM Programacion.ProductosNave
        '                                                INNER JOIN (SELECT
        '                                                 prna_naveID,
        '                                                 prna_productoID,
        '                                                 prna_productoEstiloID,
        '                                                 prna_tallaID
        '                                                FROM Programacion.ProductosNave
        '                                                WHERE prna_prnaID = <%= idPrna.ToString %>) tabla
        '                                                 ON  tabla.prna_productoEstiloID = ProductosNave.prna_productoEstiloID 
        '                                                  and tabla.prna_productoID = ProductosNave.prna_productoID and tabla.prna_tallaID = ProductosNave.prna_tallaID
        '                                        ) tabla2
        '                                     On n1.prna_prnaID = tabla2.prna_prnaID
        '                                     --WHERE tabla2.prna_orden <%= valorMayo %><%= valorActual.ToString %> and tabla2.prna_prnaID != <%= idPrna.ToString %>
        '                         </consulta>.Value
        '    operaciones.EjecutaSentencia(sql1)
        '    Return valorNuevo
        'Else
        '    valorMayo = "<="
        '    Dim sql1 As String = <consulta>
        '                                     UPDATE n1
        '                                     SET n1.prna_orden = (tabla2.Row )
        '                                        FROM Programacion.ProductosNave n1
        '                                     INNER JOIN (
        '                                      SELECT
        '                                                ROW_NUMBER() OVER(ORDER BY prna_orden,prna_fechamodificacion desc ) AS Row, prna_orden, prna_prnaID
        '                                                FROM Programacion.ProductosNave
        '                                                INNER JOIN (SELECT
        '                                                 prna_naveID,
        '                                                 prna_productoID,
        '                                                 prna_productoEstiloID,
        '                                                 prna_tallaID
        '                                                FROM Programacion.ProductosNave
        '                                                WHERE prna_prnaID = <%= idPrna.ToString %>) tabla
        '                                                 ON  tabla.prna_productoEstiloID = ProductosNave.prna_productoEstiloID 
        '                                                  and tabla.prna_productoID = ProductosNave.prna_productoID and tabla.prna_tallaID = ProductosNave.prna_tallaID
        '                                        ) tabla2
        '                                     On n1.prna_prnaID = tabla2.prna_prnaID
        '                                     --WHERE tabla2.prna_orden <%= valorMayo %><%= valorActual.ToString %> and tabla2.prna_prnaID != <%= idPrna.ToString %>
        '                         </consulta>.Value
        '    operaciones.EjecutaSentencia(sql1)
        '    Return valorNuevo
        'End If
    End Function
    Public Function TablaProductoTodo(productoID As Int32, productoEstiloID As Int32, tallaID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL += " SELECT distinct nave_nombre,prna_orden,prna_naveID,prna_productoEstiloID,prna_prnaID"
        SQL += " from"
        SQL += " Programacion.productosnave"
        SQL += " inner JOIN vProductos on v_productoEstiloID=prna_productoEstiloID AND v_prodID = prna_productoID AND prna_tallaId = v_tallaID"
        SQL += " inner join Programacion.NavesAux on nave_naveid=prna_naveID"
        SQL += " where prna_activo=1 and nave_activo=1 and prna_productoID = " & productoID & " AND prna_productoEstiloID=" & productoEstiloID & " and prna_tallaID  =" & tallaID & " "
        SQL += " Order by prna_orden"

        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Function InformacionNaveProductoDisponible(productoID As Int32, productoEstiloID As Int32, tallaID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("SELECT distinct nave_nombre from Programacion.productosnave inner JOIN Programacion.Productos on prod_productoid = prna_productoID inner join Framework.Naves on nave_naveid=prna_naveID where prna_productoID =" & productoID & " and prna_productoEstiloId=" & productoEstiloID & " and prna_tallaId=" & tallaID)
    End Function
    Public Sub actualizarOrdenProducto(ByVal anteriorOrden As Integer, ByVal nuevoOrden As Integer, ByVal idPrn As Integer)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        SQL = "UPDATE programacion.ProductosNave SET prna_orden = " + nuevoOrden.ToString + ", prna_usuariomodificoid = " + idUsuario.ToString + ",prna_fechamodificacion = GETDATE() where prna_prnaID = " + idPrn.ToString
        operaciones.EjecutaSentencia(SQL)
        nuevoOrden = ordenes(anteriorOrden, nuevoOrden, idPrn)
    End Sub
    Public Sub actualizarCapacidadProducto(ByVal capacidad As Integer, ByVal idPrn As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        SQL = "UPDATE programacion.ProductosNave SET prna_capacidad = " + capacidad.ToString + ", prna_usuariomodificoid = " + idUsuario.ToString + ",prna_fechamodificacion = GETDATE() where prna_prnaID = " + idPrn.ToString
        operaciones.EjecutaSentencia(SQL)
    End Sub
    Public Sub actualizarMuestraProducto(ByVal muestra As Integer, ByVal idPrn As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim SQL As String = ""
        SQL = "UPDATE programacion.ProductosNave SET prna_muestras = " + muestra.ToString + ", prna_usuariomodificoid = " + idUsuario.ToString + ",prna_fechamodificacion = GETDATE() where prna_prnaID = " + idPrn.ToString
        operaciones.EjecutaSentencia(SQL)
    End Sub
    Public Function obtenerTodasHormas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = ""
        sql = <consulta>
                  SELECT
	                horma_hormaid,
	                horma_descripcion
                        FROM  Programacion.Hormas
	                       
                        WHERE   horma_activo = 1
                        GROUP by horma_hormaid,horma_descripcion
                       
						EXCEPT
                       SELECT
	                        horma_hormaid,
	                        horma_descripcion
                        FROM Programacion.HormasPorNave
                        INNER JOIN Programacion.Hormas
	                        ON horma_hormaid = hona_hormaID
                        WHERE  horma_activo = 1 and hona_activo=1
                        GROUP by horma_hormaid,horma_descripcion
                        ORDER by horma_descripcion
                 
              </consulta>
        Return operaciones.EjecutaConsulta(sql)
    End Function
    Public Function obtnerProductosDisponiblesGeneral() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String
        sql = <consulta>
						SELECT
							ModSicy,
							Marca,
							Coleccion,
							CASE
								WHEN Modelo = '' THEN prod_codigo
								ELSE Modelo
							END Modelo,
							Piel,
							Color,
							Corrida,
							Horma,
							v_prodID,
							v_productoEstiloID,
							v_tallaID
						FROM vProductos
						INNER JOIN (SELECT
							pres_productoID,
							pres_productoEstiloID,
							espr_tallaID
						FROM programacion.ProductoEstilo
						INNER JOIN Programacion.EstilosProducto
							ON espr_estiloproductoid = pres_estiloID EXCEPT SELECT
							prna_productoID,
							prna_productoEstiloID,
							prna_tallaID
						FROM Programacion.ProductosNave
						) AS ini
							ON v_productoEstiloID = pres_productoestiloID
						INNER JOIN Programacion.Productos
							ON v_prodID = prod_productoid
							AND v_prodID = pres_productoid
							AND v_tallaID = espr_tallaID
						WHERE pres_activo = 1
						ORDER BY Marca, Coleccion, Modelo, Piel, Color, Corrida
              </consulta>
        Return operaciones.EjecutaConsulta(sql)
    End Function
    Public Function TablaProductosVerTodo() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL += " SELECT"
        SQL += " prna_prnaID ,nave_nombre ,ModSicy,Marca,Horma,Coleccion, prna_capacidad,CASE WHEN Modelo = '' THEN prod_codigo ELSE Modelo END Modelo,prna_muestras,Piel,Color,Corrida,prna_orden,prna_productoID,prna_tallaID,prna_productoEstiloID,prna_naveID,v_hormaID "
        SQL += " FROM"
        SQL += " Programacion.ProductosNave"
        SQL += " INNER JOIN vProductos on v_productoEstiloID =prna_productoEstiloID AND v_tallaID=prna_tallaID"
        SQL += " INNER JOIN Programacion.Productos ON v_prodID = prod_productoid "
        SQL += " inner JOIN Programacion.NavesAux on nave_naveid = prna_naveID where nave_activo=1 AND PRNA_ACTIVO=1"
        ' SQL += "    ORDER BY nave_nombre,Marca, Coleccion, Modelo, Piel, Color, Corrida"
        SQL += "    ORDER BY nave_orden,Marca, Coleccion, Modelo, Piel, Color, Corrida"
        Return operaciones.EjecutaConsulta(SQL)
    End Function
    Public Sub actualizarOrdenNaves(ByVal idPrna As Integer, ByVal norden As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim sql As String = ""
        sql = " UPDATE programacion.productosnave SET prna_orden = " + norden.ToString + ", prna_usuariomodificoid = " + idUsuario.ToString + ",prna_fechamodificacion = GETDATE() WHERE prna_prnaId = " + idPrna.ToString
        operaciones.EjecutaSentencia(sql)
    End Sub


    Public Function verificarHormaNave2(ByVal hormaID As Integer, ByVal naveId As Integer, ByVal tallaID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sql As String = ""
        sql = <consulta>
                       SELECT
	                    prna_prnaID,
	                    ModSicy,
	                    Marca,
	                    Coleccion,
	                    CASE WHEN Modelo = '' THEN prod_codigo ELSE Modelo END Modelo,
	                    Piel,
	                    Color,
	                    Corrida,
	                    Horma,
	                    prna_muestras,
	                    prna_capacidad ,
	                    prna_orden ,
	                    v_hormaID ,
	                    v_productoEstiloID,
	                    v_tallaID,
	                    v_prodID
                    FROM Programacion.ProductosNave
                    INNER JOIN vProductos
	                    ON v_prodID = prna_productoID
	                    AND v_productoEstiloID = prna_productoEstiloID
	                    AND v_tallaID = <%= tallaID.ToString %>
AND v_hormaId = <%= hormaID.ToString %>
                   
                         INNER JOIN Programacion.Productos ON v_prodID = prod_productoid
        WHERE pres_activo = 1 and Productos.prod_activo = 1
	
                    AND prna_naveID = <%= naveId.ToString %>
                        ORDER BY Marca, Coleccion, Modelo, Piel, Color, Corrida
                     </consulta>.Value

        Return operaciones.EjecutaConsulta(sql)
    End Function

    Public Function consultaHormaPorNave(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT hona_hormaPorNaveID, hona_naveID, hona_hormaID," +
        " hona_capacidad, hona_tallaid, hona_activo" +
        " FROM Programacion.HormasPorNave hn" +
        " WHERE hona_naveID = " + idNave.ToString +
        " AND hona_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaHormaPorNaveCapacidad(ByVal idNave As Int32,
                                         ByVal idLineaProduccion As Int32,
                                         ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT hona_hormaPorNaveID, hona_naveID, hona_hormaID," & _
            " hona_capacidad, hona_tallaid, hona_activo" & _
            " FROM Programacion.HormasPorNave hn WHERE hona_naveID = " + idNave.ToString & _
            " AND hn.hona_hormaPorNaveID NOT IN (SELECT DISTINCT horc_hormapornaveid " & _
            " FROM Programacion.HormasCapacidad WHERE " & _
            " horc_linpID = " + idLineaProduccion.ToString & _
            " AND horc_año = " + anio.ToString + ")" & _
            " AND hona_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaValidaExisteHormaSimulacion(ByVal entPC As Entidades.ProductoCapacidad,
                                                        ByVal linea As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim dato As Int32 = 0
        Dim cadena As String = ""
        cadena = "SELECT COUNT(0) as total FROM (" & _
        " SELECT horc_linpID, horc_hormaID, horc_tallaid, horc_año, " & _
        " horc_1, horc_2, horc_3, horc_4, horc_5, horc_6, horc_7, horc_8, horc_9, horc_10," & _
        " horc_11, horc_12, horc_13, horc_14, horc_15, horc_16, horc_17, horc_18, horc_19, horc_20," & _
        " horc_21, horc_22, horc_23, horc_24, horc_25, horc_26, horc_27, horc_28, horc_29, horc_30," & _
        " horc_31, horc_32, horc_33, horc_34, horc_35, horc_36, horc_37, horc_38, horc_39, horc_40," & _
        " horc_41, horc_42, horc_43, horc_44, horc_45, horc_46, horc_47, horc_48, horc_49, horc_50," & _
        " horc_51, horc_52" & _
        " FROM Programacion.HormasCapacidad" & _
        " WHERE horc_linpID = " + linea.ToString & _
        " AND horc_año = " + entPC.Anio.ToString & _
        " AND horc_hormaID = " + entPC.HormaId.ToString & _
        " AND horc_tallaid =" + entPC.TallaId.ToString & _
        " AND horc_activo = 1" & _
        " UNION ALL" & _
        " SELECT smhc_lineaId, smhc_hormaId, smhc_tallaid, smhc_anio," & _
        " smhc_1, smhc_2, smhc_3, smhc_4, smhc_5, smhc_6, smhc_7, smhc_8, smhc_9, smhc_10," & _
        " smhc_11, smhc_12, smhc_13, smhc_14, smhc_15, smhc_16, smhc_17, smhc_18, smhc_19, smhc_20," & _
        " smhc_21, smhc_22, smhc_23, smhc_24, smhc_25, smhc_26, smhc_27, smhc_28, smhc_29, smhc_30," & _
        " smhc_31, smhc_32, smhc_33, smhc_34, smhc_35, smhc_36, smhc_37, smhc_38, smhc_39, smhc_40," & _
        " smhc_41, smhc_42, smhc_43, smhc_44, smhc_45, smhc_46, smhc_47, smhc_48, smhc_49, smhc_50," & _
        " smhc_51, smhc_52" & _
        " FROM Programacion.simulacionHormasCapacidad WHERE " & _
        " smhc_lineaId = " + linea.ToString & _
        " AND smhc_anio = " + entPC.Anio.ToString & _
        " AND smhc_hormaId = " + entPC.HormaId.ToString & _
        " AND smhc_tallaid = " + entPC.TallaId.ToString & _
        " AND smhc_activo = 1) as cons"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            dato = CInt(dt.Rows(0).Item(0))
        End If
        Return dato
    End Function

    Public Sub insertarCapacidadSimulacion(ByVal idLinea As Int32, ByVal tipoAlta As Int32, ByVal idCopia As Int32,
                                          ByVal idCambio As Int32, ByVal idSimulacion As Int32,
                                          ByVal entHormsCap As Entidades.HormasCapacidad)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.simulacionHormasCapacidad (smhc_simulacionId, smhc_lineaId, smhc_hormaId, smhc_anio, " & _
        " smhc_tipoAlta, smhc_hormaCapacidadCopiaId, smhc_hormaCapacidadCambioId, smhc_tallaid," & _
        " smhc_1, smhc_2, smhc_3, smhc_4, smhc_5, smhc_6, smhc_7, smhc_8, smhc_9, smhc_10," & _
        " smhc_11, smhc_12, smhc_13, smhc_14, smhc_15, smhc_16, smhc_17, smhc_18, smhc_19, smhc_20," & _
        " smhc_21, smhc_22, smhc_23, smhc_24, smhc_25, smhc_26, smhc_27, smhc_28, smhc_29, smhc_30," & _
        " smhc_31, smhc_32, smhc_33, smhc_34, smhc_35, smhc_36, smhc_37, smhc_38, smhc_39, smhc_40," & _
        " smhc_41, smhc_42, smhc_43, smhc_44, smhc_45, smhc_46, smhc_47, smhc_48, smhc_49, smhc_50," & _
        " smhc_51, smhc_52, smhc_fechacreacion, smhc_usuariocreoid, smhc_activo)" & _
        " VALUES (" + idSimulacion.ToString + ", " + idLinea.ToString + ", " + entHormsCap.IdHorma.ToString + ", " + entHormsCap.Anio.ToString + ", " & _
        tipoAlta.ToString + ", " + IIf(idCopia = 0, "NULL", idCopia.ToString) + ", " + IIf(idCambio = 0, "NULL", idCambio.ToString) + ", " + entHormsCap.Talla.ToString + "," & _
        entHormsCap.Semana1.ToString + " , " + entHormsCap.Semana2.ToString + " , " + entHormsCap.Semana3.ToString + ", " + entHormsCap.Semana4.ToString + ", " + entHormsCap.Semana5.ToString + ", " + entHormsCap.Semana6.ToString + ", " + entHormsCap.Semana7.ToString + ", " + entHormsCap.Semana8.ToString + ", " + entHormsCap.Semana9.ToString + ", " + entHormsCap.Semana10.ToString + "," & _
        entHormsCap.Semana11.ToString + ", " + entHormsCap.Semana12.ToString + ", " + entHormsCap.Semana13.ToString + ", " + entHormsCap.Semana14.ToString + ", " + entHormsCap.Semana15.ToString + ", " + entHormsCap.Semana16.ToString + ", " + entHormsCap.Semana17.ToString + ", " + entHormsCap.Semana18.ToString + ", " + entHormsCap.Semana19.ToString + ", " + entHormsCap.Semana20.ToString + "," & _
        entHormsCap.Semana21.ToString + ", " + entHormsCap.Semana22.ToString + ", " + entHormsCap.Semana23.ToString + ", " + entHormsCap.Semana24.ToString + ", " + entHormsCap.Semana25.ToString + ", " + entHormsCap.Semana26.ToString + ", " + entHormsCap.Semana27.ToString + ", " + entHormsCap.Semana28.ToString + ", " + entHormsCap.Semana29.ToString + ", " + entHormsCap.Semana30.ToString + "," & _
        entHormsCap.Semana31.ToString + ", " + entHormsCap.Semana32.ToString + ", " + entHormsCap.Semana33.ToString + ", " + entHormsCap.Semana34.ToString + ", " + entHormsCap.Semana35.ToString + ", " + entHormsCap.Semana36.ToString + ", " + entHormsCap.Semana37.ToString + ", " + entHormsCap.Semana38.ToString + ", " + entHormsCap.Semana39.ToString + ", " + entHormsCap.Semana40.ToString + "," & _
        entHormsCap.Semana41.ToString + ", " + entHormsCap.Semana42.ToString + ", " + entHormsCap.Semana43.ToString + ", " + entHormsCap.Semana44.ToString + ", " + entHormsCap.Semana45.ToString + ", " + entHormsCap.Semana46.ToString + ", " + entHormsCap.Semana47.ToString + ", " + entHormsCap.Semana48.ToString + ", " + entHormsCap.Semana49.ToString + ", " + entHormsCap.Semana50.ToString + "," & _
        entHormsCap.Semana51.ToString + ", " + entHormsCap.Semana52.ToString + ", GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", 1)"
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaSimulacionHormasCapacidad(ByVal idSimulacion As Int32, ByVal idLinea As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT " & _
                " CAST(0 AS BIT) AS Sel, smhc_simulacionHormasCapacidadId, smhc_simulacionId, horma_descripcion, t.talla_descripcion," & _
                " smhc_lineaId, smhc_hormaId, smhc_anio, smhc_tipoAlta, smhc_hormaCapacidadCopiaId, smhc_hormaCapacidadCambioId, smhc_tallaid," & _
                " smhc_1, smhc_2, smhc_3, smhc_4, smhc_5, smhc_6, smhc_7, smhc_8, smhc_9, smhc_10," & _
                " smhc_11, smhc_12, smhc_13, smhc_14, smhc_15, smhc_16, smhc_17, smhc_18, smhc_19, smhc_20," & _
                " smhc_21, smhc_22, smhc_23, smhc_24, smhc_25, smhc_26, smhc_27, smhc_28, smhc_29, smhc_30," & _
                " smhc_31, smhc_32, smhc_33, smhc_34, smhc_35, smhc_36, smhc_37, smhc_38, smhc_39, smhc_40," & _
                " smhc_41, smhc_42, smhc_43, smhc_44, smhc_45, smhc_46, smhc_47, smhc_48, smhc_49, smhc_50," & _
                " smhc_51, smhc_52" & _
                " FROM Programacion.simulacionHormasCapacidad sh" & _
        " JOIN Programacion.Hormas h ON sh.smhc_hormaId = h.horma_hormaid" & _
        " JOIN Programacion.Tallas t ON sh.smhc_tallaid = t.talla_tallaid" & _
        " WHERE sh.smhc_activo = 1 AND sh.smhc_simulacionId = " + idSimulacion.ToString
        If idLinea > 0 Then
            cadena += " AND smhc_lineaId = " + idLinea.ToString
        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarHormaCapacidadSimulacion(ByVal idSimCapHorma As Int32,
                                              ByVal semanaInicio As Int32,
                                              ByVal semanaFin As Int32,
                                              ByVal cantidad As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.simulacionHormasCapacidad SET smhc_usuariomodificoid =" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            ", smhc_fechamodificacion = GETDATE()"
        For i As Int32 = semanaInicio To semanaFin
            cadena += ", smhc_" + i.ToString + "=" + cantidad.ToString
        Next
        cadena += " WHERE smhc_simulacionHormasCapacidadId = " + idSimCapHorma.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

End Class
