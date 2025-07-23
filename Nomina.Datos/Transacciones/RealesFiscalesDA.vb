Imports Persistencia
Imports System.Data.SqlClient
Imports Entidades
Imports Tools

Public Class RealesFiscalesDA

    '   [Nomina].[SP_Borrar_ColaboraresNoEncontradosNomina]
    '(
    '	@NaveID as int

    Public Function LimpiarColaboradoresNoEncontradosNomina(ByVal NaveID As Integer, ByVal Año As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = Año
        listaParametros.Add(parametro)



        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_Borrar_ColaboraresNoEncontradosNomina]", listaParametros)
    End Function


    Public Function getNaves() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select nave_naveid,nave_nombre from Framework.Naves;"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function validarTotalFiscales(ByVal anio As String, ByVal idNave As String) As Double
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim datos As DataTable
        Dim total As Double = 0
        consulta = "select isnull(Sum(agui_totalfiscal),0) from Nomina.Aguinaldos where agui_anio=" & anio & " AND agui_naveid=" & idNave & ""
        datos = operacion.EjecutaConsulta(consulta)
        total = datos.Rows(0).Item(0).ToString
        Return total
    End Function

    ''' <summary>
    ''' Si es true ya se guardo el total fiscal
    ''' </summary>
    ''' <param name="anio"></param>
    ''' <param name="idNave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function validarTotalFiscales2(ByVal anio As String, ByVal idNave As String) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim datos As DataTable
        Dim total As Double = 0
        If idNave <= 0 Then

            Return False
        Else
            consulta = "select COUNT(*) "
            consulta += "from Nomina.Aguinaldos "
            consulta += "where agui_anio=" + anio.ToString() + " AND agui_naveid='" + idNave.ToString() + "' "
            consulta += "and agui_totalfiscal is NULL "


            datos = operacion.EjecutaConsulta(consulta)
            total = datos.Rows(0).Item(0).ToString
            If total = 0 Then
                Return True
            Else
                Return False
            End If
        End If


    End Function


    Public Function countVacaciones(ByVal idNave As Integer, ByVal year As Integer) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim datos As DataTable
        Dim count As Integer = 0
        consulta = "select count(prim_primavacionalid) from Nomina.vacaciones where prim_anio=" & year & " and prim_naveid=" & idNave & ""
        datos = operacion.EjecutaConsulta(consulta)
        count = datos.Rows(0).Item(0).ToString
        Return count
    End Function
    Public Function countAguinaldos(ByVal idNave As Integer, ByVal year As Integer) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        Dim datos As DataTable
        Dim count As Integer = 0
        consulta = "select count(agui_aguinaldoid) from Nomina.aguinaldos where agui_anio=" & year & " and agui_naveid=" & idNave & ""
        datos = operacion.EjecutaConsulta(consulta)
        count = datos.Rows(0).Item(0)
        Return count
    End Function
    Public Function getDatos(ByVal idNave As Integer, ByVal year As Integer, ByVal Colaborador As String, ByVal soloVacaciones As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Year"
        parametro.Value = year
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Colaborador", Colaborador)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@soloVacaciones", soloVacaciones)
        listaparametros.Add(parametro)


        'Dim consulta As String

        'consulta = " SELECT a.codr_apellidopaterno 'Apellido Paterno', a.codr_apellidomaterno 'Apellido Materno', "
        'consulta += "a.codr_nombre Nombre, v.prim_primavacionalid, ag.agui_aguinaldoid, ag.agui_totalentregar 'Aguinaldo', "
        'consulta += "v.prim_totalentregar 'Vacaciones', (ag.agui_totalentregar + v.prim_totalentregar) 'Total', "
        'consulta += "ISNULL(avf.agui_netoAguiVac, 0.0) 'Total F', 0 'BanderaTotalFiscal', "
        'consulta += "CASE WHEN avf.agui_netoAguiVac is null then (ag.agui_totalentregar + v.prim_totalentregar) Else "
        'consulta += "CASE WHEN ((ag.agui_totalentregar + v.prim_totalentregar) - ISNULL(avf.agui_netoAguiVac, 0.0)) < 0 THEN 0 ELSE ((ag.agui_totalentregar + v.prim_totalentregar) - ISNULL(avf.agui_netoAguiVac, 0.0)) END "
        'consulta += " End 'Diferencia', "
        'consulta += "v.prim_subtotal, v.prim_primavacacional, a.codr_colaboradorid idColaborador  "
        'consulta += "FROM Nomina.Aguinaldos AS ag "
        'consulta += "INNER JOIN Nomina.Vacaciones AS v ON v.prim_colaboradorid = ag.agui_colaboradorid AND v.prim_anio = " + year.ToString() + " AND v.prim_naveid=" + idNave.ToString() + " "
        'consulta += "LEFT JOIN Nomina.Colaborador AS a ON ag.agui_colaboradorid = a.codr_colaboradorid  "
        'consulta += "JOIN nomina.ColaboradorReal AS c ON a.codr_colaboradorid = c.real_colaboradorid  "
        'consulta += "LEFT JOIN Contabilidad.TBL_AguinaldoVacacionesLeyISR avf ON avf.agui_colaboradorid = a.codr_colaboradorid and avf.agui_anio = ag.agui_anio and avf.agui_estatusid <> 171"
        'consulta += "WHERE ag.agui_anio = " + year.ToString() + " And ag.agui_naveid = " + idNave.ToString() + " "
        'consulta += "ORDER BY c.real_fecha ASC "

        'consulta = "SELECT" +
        '" a.codr_apellidopaterno 'Apellido Paterno'," +
        '" a.codr_apellidomaterno 'Apellido Materno'," +
        '" a.codr_nombre Nombre," +
        '" v.prim_primavacionalid," +
        '" ag.agui_aguinaldoid," +
        '" ag.agui_totalentregar 'Aguinaldo'," +
        '" v.prim_totalentregar 'Vacaciones'," +
        '" (ag.agui_totalentregar + v.prim_totalentregar) 'Total'," +
        '" ISNULL(v.prim_totalfiscal,0.00) 'Total F'," +
        '" ISNULL(v.prim_totalfiscal, 0.00) 'BanderaTotalFiscal'," +
        '" CASE WHEN v.prim_totalfiscal is null then (ag.agui_totalentregar + v.prim_totalentregar)" +
        '" Else ((ag.agui_totalentregar + v.prim_totalentregar)-v.prim_totalfiscal)  End 'Diferencia'," +
        '" v.prim_subtotal," +
        '" v.prim_primavacacional," +
        '" a.codr_colaboradorid idColaborador" +
        '" FROM Nomina.Colaborador AS a" +
        '" JOIN Nomina.ColaboradorLaboral AS b" +
        '" ON a.codr_colaboradorid = b.labo_colaboradorid" +
        '" JOIN nomina.ColaboradorReal AS c" +
        '" ON a.codr_colaboradorid = c.real_colaboradorid" +
        '" JOIN Nomina.Vacaciones AS v" +
        '" ON v.prim_colaboradorid = a.codr_colaboradorid" +
        '" AND v.prim_anio = " & year & "" +
        '" JOIN Nomina.Aguinaldos AS ag" +
        '" ON ag.agui_colaboradorid = a.codr_colaboradorid" +
        '" AND ag.agui_anio = " & year & "" +
        '" WHERE b.labo_naveid = " & idNave & "" +
        '" AND a.codr_activo = 1" +
        '" AND b.labo_reportes = 1" +
        '" ORDER BY c.real_fecha ASC"
        Return operacion.EjecutarConsultaSP("[Nomina].[SP_ObtieneDatos_AguinaldoVacacionesRF_Periodos]", listaparametros)
    End Function

    Public Function getTotalExternos(ByVal idNave As Integer, ByVal anio As Integer) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim total As Integer

        parametro.ParameterName = "@IdNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaparametros.Add(parametro)


        'Dim consulta As String
        'consulta = "SELECT 	Isnull(sum(avf.agui_netoAguiVac), 0)	" +
        '" FROM  Nomina.ColaboradorNomina AS cn " +
        '" join Nomina.Colaborador c on c.codr_colaboradorid=Cn.cono_colaboradorid " +
        '" join Nomina.ColaboradorLaboral cl on cl.labo_colaboradorid=cn.cono_colaboradorid " +
        '" LEFT JOIN Contabilidad.TBL_AguinaldoVacacionesLeyISR avf 	ON avf.agui_colaboradorid = cn.cono_colaboradorid	AND avf.agui_estatusid <> 171 " +
        '" join Contabilidad.RelacionNavePatron_Aguinaldos pat on pat.relnp_patronid=avf.agui_patronid " +
        '" WHERE avf.agui_anio = " + anio.ToString + " AND agui_colaboradorid not in " +
        '"(SELECT agui_colaboradorid FROM Nomina.Aguinaldos WHERE agui_anio = " + anio.ToString + " AND agui_naveid=" + idNave.ToString + ")" +
        '"and pat.relnp_naveid= " + idNave.ToString
        ''" WHERE avf.agui_anio = " + anio.ToString + " AND (cn.cono_externo=1 or (cn.cono_externo=0 and cl.labo_reportes=0))  and pat.relnp_naveid= " + idNave.ToString
        Dim datos As DataTable
        datos = operacion.EjecutarConsultaSP("[Nomina].[SP_ObtieneTotalExternos_AguinaldoVacacionesRF]", listaparametros)
        total = datos.Rows(0).Item(0).ToString
        Return total
    End Function
    Public Function getidCaja(ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        'consulta = "select usca_cajaid, usca_razonsocial from Nomina.UsuarioCaja where usca_naveid=" & idNave & " and usca_usuarioid=" +
        '" " & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid & ""
        consulta = "select TOP 1 usca_cajaid, usca_razonsocial from Nomina.UsuarioCaja where usca_naveid=" & idNave & "ORDER BY usca_usuariocajaid DESC"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function updateAguinaldo(ByVal idAguinaldo As Integer, ByVal totalFiscal As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update Nomina.Aguinaldos set agui_totalfiscal=" & totalFiscal & " where agui_aguinaldoid=" & idAguinaldo & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function updateVacaciones(ByVal idVacaciones As Integer, ByVal totalFiscal As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update Nomina.Vacaciones set prim_totalfiscal=" & totalFiscal & " where prim_primavacionalid=" & idVacaciones & ""
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function altaVacacionesAguinaldos(ByVal idCaja As Integer, ByVal tipoSolicitud As String, ByVal importe As Double,
                                                ByVal beneficiario As String, ByVal observaciones As String, ByVal razonsocial As String) As String
        Dim mensaje As String = "True"
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientosSICY
            Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
            Dim consulta As String = "DECLARE @Mensaje int "
            consulta += "EXEC usp_AltaVacacionesAguinaldosChequeFiscalCajaChica @Mensaje OUTPUT," + idCaja.ToString + ",'" + tipoSolicitud.ToString + "'," & importe & ",'" + beneficiario.ToString + "','" + observaciones.ToString + "','" + razonsocial.ToString + "' SELECT @Mensaje"
            operaciones.EjecutaConsulta(consulta)
        Catch ex As Exception
            Return ex.Message
        End Try
        Return mensaje
    End Function
    Public Function getDatosReporteVacAgui(ByVal idNave As Integer, ByVal year As Integer, ByVal soloVacaciones As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@year"
        parametro.Value = year
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@soloVacaciones"
        parametro.Value = soloVacaciones
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneDatosReporte_AguinaldoyVacaciones_soloVacaciones]", listaparametros)


        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String
        'consulta = "SELECT" +
        '" (a.codr_nombre + ' ' + a.codr_apellidopaterno + ' ' +" +
        '" a.codr_apellidomaterno) nombre," +
        '" ag.agui_totalentregar aguinaldo," +
        '" v.prim_totalentregar primaVacacional," +
        '" (ag.agui_totalentregar + v.prim_totalentregar) totalReal," +
        '" ISNULL(v.prim_totalfiscal, 0.00) totalFiscal," +
        '" CASE" +
        '" WHEN v.prim_totalfiscal IS NULL THEN (ag.agui_totalentregar + v.prim_totalentregar)" +
        '" ELSE ((ag.agui_totalentregar + v.prim_totalentregar) - v.prim_totalfiscal)" +
        '" END diferencia" +
        '" FROM Nomina.Colaborador AS a" +
        '" JOIN Nomina.ColaboradorLaboral AS b" +
        '" ON a.codr_colaboradorid = b.labo_colaboradorid" +
        '" JOIN nomina.ColaboradorReal AS c" +
        '" ON a.codr_colaboradorid = c.real_colaboradorid" +
        '" JOIN Nomina.Vacaciones AS v" +
        '" ON v.prim_colaboradorid = a.codr_colaboradorid" +
        '" AND v.prim_anio = " & year & "" +
        '" JOIN Nomina.Aguinaldos AS ag" +
        '" ON ag.agui_colaboradorid = a.codr_colaboradorid" +
        '" AND ag.agui_anio = " & year & "" +
        '" WHERE b.labo_naveid = " & idNave & "" +
        '" AND a.codr_activo = 1" +
        '" AND b.labo_reportes = 1" +
        '" ORDER BY c.real_fecha"
        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function insertarExcluidos(ByVal nombre As String, ByVal Materno As String, ByVal Paterno As String, ByVal TotalFiscal As Double, ByVal anio As String, ByVal idNave As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "insert into Nomina.IncorrectosAguinaldosVacaciones (incav_nombre, incav_año, incav_estatus, incav_naveid,incav_apaterno,incav_amaterno, incav_totalfiscal) values('" & nombre & "'," & anio & ",1," & idNave & ",'" + Paterno.Trim() + "','" + Materno.Trim() + "', '" + TotalFiscal.ToString() + "')"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function getExcluidos(ByVal anio As Integer, ByVal idNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT incav_nombre as Nombre, isnull(incav_apaterno,'') as Paterno,isnull( incav_amaterno,'') as Materno,  "
        consulta += "isnull(incav_totalfiscal ,0) as FiniquitoFiscal FROM Nomina.IncorrectosAguinaldosVacaciones WHERE incav_año = " & anio & " AND incav_naveid = " & idNave & " AND incav_estatus = 1 order by nombre "
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function eliminarExcluidos(ByVal anio As String, ByVal idNave As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "delete from Nomina.IncorrectosAguinaldosVacaciones where incav_año = " & anio & " and incav_naveid =" & idNave
        Return operacion.EjecutaConsulta(consulta)
    End Function

    'Prueba
    Public Function getExcluidos2(ByVal idNave As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ObtieneTotalChequeExterno_AguinaldoyVacaciones]", listaParametros)

    End Function



    Public Function ConsultaAguinaldoVacacionesNave(ByVal Año As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Anio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_NOMINA_AGUINALDO_VACACIONES_TOTALES_NAVE]", listaParametros)
    End Function

    Public Function ObtenerDatosExterno(ByVal NaveId As Integer, ByVal Anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = Anio
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ObtieneExternosAguinaldo]", listaparametros)

    End Function

    Public Function llenarComboAnio(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select DISTINCT prim_anio AÑO, prim_anio añoAVRF from Nomina.Vacaciones where prim_naveid =" + idNave.ToString + " ORDER BY Año"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function updateAguiVacFiscal(ByVal xmlAguinaldos As String, ByVal xmlVacaciones As String, ByVal naveId As Integer, ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLAguinaldos"
        parametro.Value = xmlAguinaldos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@XMLVacaciones"
        parametro.Value = xmlVacaciones
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ActualizaTotalFiscal_AguinaldoyVacaciones]", listaparametros)

    End Function

    Public Function updateVacacionesFiscal(ByVal xmlVacaciones As String, ByVal naveId As Integer, ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLVacaciones"
        parametro.Value = xmlVacaciones
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ActualizaTotalFiscal_Vacaciones]", listaparametros)

    End Function


    Public Function validarInfoVacaciones(ByVal naveId As Integer, ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = naveId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_ValidarInfoVacacionesRYF]", listaparametros)

    End Function
End Class