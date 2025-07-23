Imports System.Data.SqlClient

Public Class TicketsDA

    Public Function BuscarTicket(ByVal NoTicket As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String

        Dim LetraCodigo As String = NoTicket.Substring(0, 1).ToString
        Dim loteStr, anio, naveSAY, idfraccionStr As String
        Dim idFraccion, lote As Integer

        If LetraCodigo = "N" Then 'Es un ticket de SAY
            naveSAY = NoTicket.Substring(1, 2).ToString
            loteStr = NoTicket.Substring(3, 5).ToString
            anio = NoTicket.Substring(8, 2).ToString
            idfraccionStr = NoTicket.Substring(10, 5).ToString
            idFraccion = CInt(idfraccionStr)
            lote = CInt(loteStr)


            Consulta = " Select l.lote_pares 'Pares',CONVERT(DECIMAL(10,3),f.fd_costo) 'Costo', cf.frap_descripcion + ' ' + f.fd_observaciones 'Descripcion_Fraccion'," +
            " l.lote_pares * (CONVERT(DECIMAL(10,3),f.fd_costo)) 'Pago', l.lote_año 'Año', l.lote_lote 'Lote',l.lote_navesayid 'NaveSAY', l.lote_navesicyid 'Nave', " +
            " '" + NoTicket.ToString + "' AS 'Barcode', cf.frap_fraccionid " +
            " FROM Produccion.LoteProduccionSicy AS l left join Produccion.FraccionesDesarrollo AS f ON f.fd_productoestiloid=l.lote_productoestiloid" +
            " INNER JOIN Produccion.FraccionOrdenamiento AS fo ON f.fd_fracciondesarrolloid=fo.fror_fraccionid" +
            " left join Produccion.CatalagoFracciones AS cf ON cf.frap_fraccionid=f.fd_fraccionid" +
            " left join Produccion.MaquinariaProduccion AS m ON m.mapr_maquinaid=f.fd_maquinaid" +
            " WHERE l.lote_lote='" + lote.ToString + "' AND  l.lote_navesayid=" + naveSAY.ToString + " AND l.lote_año=20" + anio.ToString + " AND f.fd_fraccionid=" + idFraccion.ToString +
            " AND f.fd_pagar=1 AND f.fd_activo=1"
            Return operacionesSAY.EjecutaConsulta(Consulta)
        Else
            'Es un ticket de SICY
            Consulta = "select * from pdExplosionManoObra where Barcode ='" + NoTicket.ToString + "'"
            Return operaciones.EjecutaConsulta(Consulta)
        End If
    End Function

    Public Function BuscarTicketSAY(ByVal NoTicket As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Barcode"
        parametro.Value = NoTicket
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Produccion.SP_ObtieneTicket", listaparametros)
    End Function


    Public Function obtenerEstatusPeriodo(ByVal idPeriodo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "Select * from Nomina.PeriodosNomina where pnom_PeriodoNomId ='" + idPeriodo.ToString + "'"
        Return operaciones.EjecutaConsulta(Consulta)
    End Function


    Public Function obtenerDiasHabilesNave(ByVal nave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "SELECT conf_diasHabilesTicket FROM Nomina.ConfiguracionNaveNomina WHERE conf_naveid = '" + nave.ToString + "'"
        Return operaciones.EjecutaConsulta(Consulta)
    End Function
    Public Function bDiasHabiles(ByVal lote As Integer, ByVal nave As Integer, ByVal anio As Integer, ByVal top As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "top"
        parametro.Value = top
        listaParametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = nave
        listaParametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "lote"
        parametro.Value = lote
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("SP_obtenerDiasHabilesTicket", listaParametros)
    End Function
    Public Function bDepartamento(ByVal idDepartamento As Integer, ByVal fraccion As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select * from nomina.DestajosAsignacionFracciones where deaf_departamentoid=" + idDepartamento.ToString + " and deaf_fraccion like '" + Trim(fraccion.ToString) + "'"
        Return operaciones.EjecutaConsulta(Consulta)
    End Function
    Public Function SemenaNominaActiva(ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select pnom_PeriodoNomId from Nomina.PeriodosNomina where pnom_stPeriodoNomina = 'A' and pnom_NaveId=" + Naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub InsertarTickets(ByVal Registro As Entidades.Ticket, ByVal ColaboradorID As Int32)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "dest_codigo"
        parametro.Value = Registro.PNoTicket
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dest_colaboradorid"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dest_periodonominaid"
        parametro.Value = Registro.PPeriodoNomina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dest_descripcion"
        parametro.Value = Registro.PDescripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dest_pares"
        parametro.Value = Registro.PCantidadPares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dest_costopar"
        parametro.Value = Registro.PCostoPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "dest_montoticket"
        parametro.Value = Registro.PTotal
        listaParametros.Add(parametro)


        objOperaciones.EjecutarSentenciaSP("Nomina.SP_RegistrarTickets", listaParametros)
    End Sub

    Public Function VerificarRegistro(ByVal NoTicket As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select * from Nomina.Destajos Left join Nomina.Colaborador on(dest_colaboradorid=codr_colaboradorid) INNER jOIN Nomina.PeriodosNomina ON (dest_periodonominaid = pnom_PeriodoNomId) where dest_codigo = '" + NoTicket.ToString + "'"
        Return operaciones.EjecutaConsulta(Consulta)
    End Function


    Public Function ListaRegistrados(ByVal ColaboradorId As Int32, ByVal PeriododeNomina As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select * from Nomina.Destajos where dest_colaboradorid = " + ColaboradorId.ToString + " and dest_periodonominaid = " + PeriododeNomina.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function


    Public Function ListaRegistradosGeneral(ByVal ColaboradorId As Int32, ByVal PeriododeNomina As Int32, ByVal naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Query As String = "select * from Nomina.Destajos join Nomina.Colaborador on (codr_colaboradorid=dest_colaboradorid) join Nomina.ColaboradorLaboral on (dest_colaboradorid= labo_colaboradorid) "
        If naveid > 0 Then
            Query += " where labo_naveid=" + naveid.ToString
            If ColaboradorId > 0 Then
                Query += " and dest_colaboradorid=" + ColaboradorId.ToString
            End If
        End If
        '
        Dim Consulta As String = "select * from Nomina.Destajos where  dest_periodonominaid = " + PeriododeNomina.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function


    'Public Function ListaTicketsDeColaborador(ByVal ColaboradorId As Int32, ByVal PeriododeNomina As Int32) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientos

    '    Dim Consulta As String = "select * from Nomina.Destajos where  dest_periodonominaid = " + PeriododeNomina.ToString + "and dest_colaboradorid=" + ColaboradorId.ToString
    '    Return operaciones.EjecutaConsulta(Consulta)
    'End Function

    Public Function ListaTicketsDeColaborador(ByVal ColaboradorId As Integer, ByVal PeriododeNomina As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ColaboradorId"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PeriodoNomina"
        parametro.Value = PeriododeNomina
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ListaTicketDeColaborador_Nombre]", listaParametros)

    End Function

    Public Function TransferirTicket(ByVal ColaboradorId As Int32, ByVal NoTicket As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "update Nomina.Destajos set dest_colaboradorid=" + ColaboradorId.ToString + " where dest_codigo='" + NoTicket.ToString + "'"
        'Return operaciones.EjecutaConsulta(Consulta)

        'Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro = New SqlParameter("@ColaboradorId", ColaboradorId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Ticket", NoTicket)
        listaParametros.Add(parametro)

        'parametro = New SqlParameter("@PeriodoNominaID", PeriodoNominaID)
        'listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[TransferirTicketAColaborador]", listaParametros)

    End Function

    Public Function ListaTotalesColaboradoresTickets(ByVal PeriodoNominaId As Int32, ByVal Nombre As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select distinct b.codr_colaboradorid, "
        Consulta += " (select sum(dest_montoticket) from Nomina.Destajos as c join Nomina.Colaborador as b1 on(c.dest_colaboradorid=b1.codr_colaboradorid) where a.dest_colaboradorid=b1.codr_colaboradorid and c.dest_periodonominaid=" + PeriodoNominaId.ToString + ") as monto,"
        Consulta += "  (select count(dest_codigo) from Nomina.Destajos as b2 join Nomina.colaborador as a2 on (b2.dest_colaboradorid=a2.codr_colaboradorid) where a.dest_colaboradorid=a2.codr_colaboradorid and  b2.dest_periodonominaid=" + PeriodoNominaId.ToString + ") as totalTickets "
        Consulta += " ,(b.codr_apellidopaterno +' '+b.codr_apellidomaterno+' ' +b.codr_nombre)as nombre, area_nombre, z.celu_nombre, x.grup_name"
        Consulta += " from Nomina.Destajos as a join Nomina.Colaborador as b on (a.dest_colaboradorid=b.codr_colaboradorid) join Nomina.ColaboradorLaboral as w on (b.codr_colaboradorid=w.labo_colaboradorid) left join Nomina.Areas as y on (w.labo_areaid=y.area_areaid) left join Nomina.Celulas as z on (w.labo_celulaid=z.celu_celulaid) left join Framework.Grupos as x on(w.labo_departamentoid=x.grup_grupoid) where a.dest_periodonominaid=" + PeriodoNominaId.ToString + " and (codr_nombre +' ' +codr_apellidopaterno+' ' + codr_apellidomaterno) like '%" + Nombre.Replace(" ", "%") + "%'"
        Consulta += " order by b.codr_colaboradorid"
        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function ListaTicketsDeColaboradorAgrupados(ByVal ColaboradorId As Int32, ByVal PeriododeNomina As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "select  dest_descripcion as Fracción, count(dest_codigo) as [No. Tickets], dest_costopar as Costo,sum(dest_pares) as Pares,dest_costopar*(sum(dest_pares)) as Total  from Nomina.Destajos where  dest_periodonominaid = " + PeriododeNomina.ToString + " and dest_colaboradorid=" + ColaboradorId.ToString + " group by dest_descripcion, dest_costopar order by dest_costopar"
        'Return operaciones.EjecutaConsulta(Consulta)
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoid"
        parametro.Value = PeriododeNomina
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_CONSULTA_TICKETS_AGRUPADOS", listaParametros)

    End Function

    Public Function obtenerTicketsColaborador(ByVal ColaboradorId As Integer, ByVal periodoNominalId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim sqlQuery As String = ""
        sqlQuery = "SELECT dest_detajoid,dest_codigo,convert(VARCHAR(19),dest_fecha,103) as dest_fecha, dest_descripcion, dest_costopar, dest_pares, dest_montoticket FROM Nomina.Destajos WHERE dest_colaboradorid = " + ColaboradorId.ToString + " AND dest_periodonominaid = " + periodoNominalId.ToString + " order BY dest_fecha desc"
        Return operaciones.EjecutaConsulta(sqlQuery)
    End Function
    Public Function eliminarTicketColaborador(ByVal idTicket As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idTicket"
        parametro.Value = idTicket
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_eliminarTicket", listaParametros)
    End Function

    Public Function ListaTicketsAgrupadosSupervisor(ByVal colaboradorid As Integer, ByVal periodid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = colaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoid"
        parametro.Value = periodid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_CONSULTA_TICKETS_AGRUPADOS_SUPERVISOR]", listaParametros)

    End Function

    Public Function ConsultarTicketsPorNave(ByVal PeriodoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@PeriodoNomina"
        parametro.Value = PeriodoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ConsultarTicketsCobradosPorNave_tiempo]", listaParametros)

    End Function

    Public Function ConsultarTicketsPorColaborador(ByVal Colaborador As Integer, ByVal PeriodoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Colaborador"
        parametro.Value = Colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PeriodoNomina"
        parametro.Value = PeriodoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_Consulta_TicketsCobradosPorColaborador_tiempo]", listaParametros)

    End Function
End Class
