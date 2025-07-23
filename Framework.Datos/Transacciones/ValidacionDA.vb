Imports Persistencia
Imports System.Data.SqlClient

Public Class ValidacionDA

    Public Function Usuario_Validacion(usuarioID As Integer, tipoValidacion As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT  " +
                                " vati_colaboradorid" +
                                " FROM Framework.ValidacionUsuario" +
                                " JOIN Framework.Usuarios ON user_colaboradorid = vati_colaboradorid" +
                                " WHERE vati_validaciontipoid = " + tipoValidacion.ToString + " AND vaus_activo = 1 AND user_usuarioid = " + usuarioID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function Cliente_Info_Obligatoria_Completa(personaID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT  " +
                                " DISTINCT(inob_personaid)" +
                                " FROM Framework.InformacionObligatoria" +
                                " WHERE inob_areaoperativaid IN (1,2,3,7) AND inob_capturado = 1" +
                                " AND inob_personaid = " + personaID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function


    Public Function Validacion_Cliente(clienteID As Integer, TipoValidacion As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT" +
                                "   v.vali_validaciontipoid,clie_clienteid" +
                                "   ,e.vaes_nombre" +
                                " , clie_validacionstatusid_ventas " +
                                " , clie_validacionfecha_ventas " +
                                " , clie_validacionstatusid_credcobr " +
                                " , clie_validacionfecha_credcobr " +
                                " , v.vaes_validacionestatusid " +
                                " , vali_colaboradorid" +
                                " , vali_fechavalidacion" +
                                " , vali_comentario" +
                                " FROM Cliente.Cliente JOIN Framework.Validacion v ON vali_registroid = clie_clienteid" +
                                " inner join Framework.ValidacionEstatus e on v.vaes_validacionestatusid= e.vaes_validacionestatusid" +
                                " WHERE vali_validacionid = (" +
                                "							SELECT MAX (vali_validacionid) FROM Framework.Validacion" +
                                "							WHERE vali_registroid = " + clienteID.ToString + " AND vali_validaciontipoid =" + TipoValidacion.ToString +
                                "                           )" +
                                " AND clie_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function
    Public Function Validacion_InformacionCliente(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT" +
                                "   v.vali_validaciontipoid,clie_clienteid" +
                                "   ,e.vaes_nombre" +
                                " , clie_validacionstatusid_ventas " +
                                " , clie_validacionfecha_ventas " +
                                " , clie_validacionstatusid_credcobr " +
                                " , clie_validacionfecha_credcobr " +
                                " , v.vaes_validacionestatusid " +
                                " , vali_colaboradorid" +
                                " , vali_fechavalidacion" +
                                " , vali_comentario" +
                                " FROM Cliente.Cliente JOIN Framework.Validacion v ON vali_registroid = clie_clienteid" +
                                " inner join Framework.ValidacionEstatus e on v.vaes_validacionestatusid= e.vaes_validacionestatusid" +
                                " WHERE vali_validacionid = (" +
                                "							SELECT MAX (vali_validacionid) FROM Framework.Validacion" +
                                "							WHERE vali_registroid = " + clienteID.ToString + " AND vali_validaciontipoid  in (1,2)" +
                                "                           )" +
                                " AND clie_clienteid = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function
    Public Function Datos_TablaValidacion_Cliente(clienteID As Integer, TipoValidacion As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " " +
                                " SELECT " +
                                " V.vaes_nombre" +
                               " AS vaes_validacionestatusid," +
                                " 	UPPER(CAST(codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS varchar(150))) AS codr_nombre_completo, " +
                                " 	vali_fechavalidacion, " +
                                " 	vali_comentario 	,vali_activo AS 'ACTIVO'" +
                                " FROM Cliente.Cliente " +
                                " JOIN Framework.Validacion VA ON vali_registroid = clie_clienteid " +
                                " JOIN Nomina.Colaborador ON codr_colaboradorid = vali_colaboradorid  INNER JOIN Framework.ValidacionEstatus V ON V.vaes_validacionestatusid=VA.vaes_validacionestatusid" +
                                " WHERE clie_clienteid = " + clienteID.ToString +
                                " AND vali_validaciontipoid = " + TipoValidacion.ToString +
                                " ORDER BY vali_validacionid DESC "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function verifica_Pedidos_Pendientes(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT * FROM pedidos WHERE Estatus NOT IN ('Entregado','Cancelado') AND idcadena = " + clienteID.ToString

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function verifica_Saldo_Pendiente(clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " " +
                                " SELECT" +
                                " CASE ISNULL(idfactura, 0)" +
                                "   WHEN 0 THEN 2" +
                                "   ELSE 1" +
                                " END," +
                                " v.IdRemision," +
                                " v.Año," +
                                " IdFactura," +
                                " C.IdCobro," +
                                " c.FechaAplicacion," +
                                " FechaVenta," +
                                " FechaVenta + 75 AS Fechavence," +
                                " Total AS ImporteTotal," +
                                " c.Importe," +
                                " v.Saldo," +
                                " v.estatus," +
                                " CASE ISNULL(idfactura, 0)" +
                                "   WHEN 0 THEN 0" +
                                "   ELSE 1" +
                                " END AS Tipo," +
                                " c.concepto," +
                                " dv.RazonSocial," +
                                " c.TipoCobro," +
                                " C.IdCheque," +
                                " C.IdDeposito," +
                                " C.IdDevolucion," +
                                " c.Aplicado," +
                                " cl.Nombre," +
                                " CASE" +
                                "   WHEN c.DiasTranscurridos < 0 THEN 0" +
                                "   ELSE c.DiasTranscurridos" +
                                " END DiasTranscurridos" +
                                " FROM (Cobros c" +
                                " RIGHT OUTER JOIN (Ventas v" +
                                " INNER JOIN Clientes cl" +
                                "       ON v.idcliente = cl.idcliente" +
                                " LEFT OUTER JOIN (Facturas f" +
                                "       INNER JOIN DoctosVentas dv" +
                                " ON f.IdDocumento = dv.IdDocumento)" +
                                " ON f.idremision = v.idremision" +
                                " AND f.año = v.año)" +
                                " ON c.IdRemision = v.IdRemision" +
                                " AND c.Año = v.Año)" +
                                " WHERE FechaVenta >= '01/11/2006'" +
                                " AND v.idcadena = 1" +
                                " AND v.Estatus = 'CXC'" +
                                " AND v.SALDO > 0 and c.IdCadena = " + clienteID.ToString +
                                " ORDER BY FechaVenta, v.IdRemision"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
