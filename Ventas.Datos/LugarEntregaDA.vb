Public Class LugarEntregaDA

    Public Function ListadoLugarEntrega() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT luen_lugarentregaid, LTRIM(RTRIM(UPPER(luen_nombre))) AS luen_nombre FROM Ventas.LugarEntrega WHERE luen_activo = 1 ORDER BY luen_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function ListaDestinos_Sin_MensajeriaRelacionada() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT '' AS 'Población', 0 as 'IdPoblacion', upper(c.city_nombre) AS Ciudad, c.city_ciudadid as 'IdCiudad', " +
                                " 	upper(es.esta_nombre) AS Estado, es.esta_estadoid as 'IdEstado', upper(pa.pais_nombre) AS País, " +
                                " 	pa.pais_paisid as 'IdPais' ,COUNT(d.domi_domicilioid) AS contador" +
                                " FROM Framework.Ciudades c" +
                                " INNER JOIN Framework.Estados es ON es.esta_estadoid = c.city_estadoid" +
                                " INNER JOIN Framework.Paises pa ON es.esta_paisid = pa.pais_paisid" +
                                " INNER JOIN Framework.Domicilio d ON c.city_ciudadid = d.domi_ciudadid" +
                                " INNER JOIN Framework.Persona p ON p.pers_personaid = d.domi_personaid" +
                                " INNER JOIN Cliente.TiendaEmbarqueCEDIS tec ON tec.tiec_personaid = p.pers_personaid" +
                                " INNER JOIN Cliente.Cliente clie ON tec.tiec_clienteid = clie.clie_clienteid" +
                                "         WHERE(d.domi_poblacionid Is NULL Or d.domi_poblacionid = 0)" +
                                " AND domi_clasificacionpersonaid IN (15, 16, 17)" +
                                " AND d.domi_ciudadid NOT IN (SELECT dm.deme_ciudadid" +
                                " 	FROM Embarque.DestinoMensajeria dm" +
                                " 	INNER JOIN Embarque.CostoDestinoMensajeria cdm ON cdm.codm_destinomensajeriaid = dm.deme_destinomensajeriaid" +
                                " 	WHERE deme_activo = 1 AND codm_activo = 1 AND dm.deme_poblacionid IS NULL)" +
                                " AND tec.tiec_activo = 1 AND clie.clie_activo = 1" +
                                " GROUP BY c.city_nombre, c.city_ciudadid, es.esta_nombre, es.esta_estadoid, pa.pais_nombre, pa.pais_paisid" +
                                "         UNION" +
                                " SELECT upper(po.pobl_nombre) AS 'Población', po.pobl_poblacionid as 'IdPoblacion', upper(c.city_nombre) AS Ciudad," +
                                " 	c.city_ciudadid as 'IdCiudad', upper(es.esta_nombre) AS Estado, es.esta_estadoid as 'IdEstado',  " +
                                " 	upper(pa.pais_nombre) AS País, pa.pais_paisid as 'IdPais', COUNT(d.domi_domicilioid) AS contador" +
                                " FROM Framework.Ciudades c" +
                                " INNER JOIN Framework.Poblaciones po ON po.pobl_ciudadid = c.city_ciudadid" +
                                " INNER JOIN Framework.Estados es ON es.esta_estadoid = c.city_estadoid" +
                                " INNER JOIN Framework.Paises pa ON es.esta_paisid = pa.pais_paisid" +
                                " INNER JOIN Framework.Domicilio d ON c.city_ciudadid = d.domi_ciudadid" +
                                " INNER JOIN Framework.Persona p ON p.pers_personaid = d.domi_personaid" +
                                " INNER JOIN Cliente.TiendaEmbarqueCEDIS tec ON tec.tiec_personaid = p.pers_personaid" +
                                " INNER JOIN Cliente.Cliente clie ON tec.tiec_clienteid = clie.clie_clienteid" +
                                "         WHERE(d.domi_poblacionid Is Not NULL Or d.domi_poblacionid <> 0)" +
                                " AND domi_clasificacionpersonaid IN (15, 16, 17)" +
                                " AND d.domi_poblacionid NOT IN (SELECT dm.deme_poblacionid " +
                                " 	FROM Embarque.DestinoMensajeria dm" +
                                " 	INNER JOIN Embarque.CostoDestinoMensajeria cdm ON cdm.codm_destinomensajeriaid = dm.deme_destinomensajeriaid" +
                                " 	WHERE deme_activo = 1 AND codm_activo = 1 AND dm.deme_poblacionid IS NOT NULL)" +
                                " AND tec.tiec_activo = 1 AND clie.clie_activo = 1" +
                                " GROUP BY po.pobl_nombre, po.pobl_poblacionid, c.city_nombre, c.city_ciudadid, es.esta_nombre, es.esta_estadoid, pa.pais_nombre, pa.pais_paisid" +
                                " ORDER BY población, ciudad, estado, País"
        Return operaciones.EjecutaConsulta(consulta)
    End Function


End Class
