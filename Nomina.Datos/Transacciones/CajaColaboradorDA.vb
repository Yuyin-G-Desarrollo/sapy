Imports System.Data.SqlClient

Public Class CajaColaboradorDA

    Public Function ListaCajaColaborador(ByVal Nombre As String, ByVal IdCaja As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'Dim consulta As String = " SELECT * FROM CajaAhorro.CajaColaborador as a " +
        '   " LEFT JOIN Nomina.Colaborador as b on (a.cajc_ColaboradorId = b.codr_colaboradorid) " +
        '   " LEFT JOIN Nomina.ColaboradorReal as c ON (c.real_colaboradorid=b.codr_colaboradorid) " +
        '   "LEFT JOIN Nomina.ColaboradorLaboral as d ON (b.codr_colaboradorid = d.labo_colaboradorid) " +
        '   " LEFT JOIN Framework.Grupos as e on (e.grup_grupoid=d.labo_departamentoid) join Nomina.Areas as w on(e.grup_areaid=w.area_areaid) "


        'consulta += " WHERE cajc_CajaAhorroId = cajc_cajaAhorroId "
        'consulta += " AND (b.codr_nombre +' '+ b.codr_apellidopaterno + ' ' + b.codr_apellidomaterno) LIKE '%" + Nombre.Replace(" ", "%") + "%' "
        'consulta += "AND a.cajc_cajaahorroid= " + IdCaja.ToString
        'consulta += " AND b.codr_activo=1 "
        'consulta += " order by real_fecha asc "
        'Return operaciones.EjecutaConsulta(consulta)

        parametro.ParameterName = "CajaAhorroId"
        parametro.Value = IdCaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[CajaAhorro].[SP_ListaCajaColaboradorAsignados]", listaParametros)
    End Function

    Public Function LiscaAcumuladoCajaAhorro(ByVal CajaId As Integer, ByVal colaboradorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = " select SUM(ccpc_MontoAhorro) as ccpc_MontoAhorro from CajaAhorro.ColaboradorPeriodoCaja "
        consulta += " where ccpc_CajaAhorroId=" + CajaId.ToString
        consulta += " and ccpc_ColaboradorId=" + colaboradorID.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaCajaColaboradoresNoAsignados(ByVal Nombre As String, ByVal CajaId As Integer, ByVal naveid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        'Dim consulta As String = "SELECT * FROM Nomina.Colaborador c " +
        ' "INNER JOIN Nomina.ColaboradorLaboral cl ON c.codr_colaboradorid=cl.labo_colaboradorid " +
        ' "INNER JOIN Framework.Grupos g ON cl.labo_departamentoid = g.grup_grupoid AND cl.labo_naveid=g.grup_naveid  left join Nomina.Areas as ar on area_areaid=labo_areaid left join Nomina.Puestos as pu on (labo_puestoid=pu.pues_puestoid)" +
        ' "LEFT JOIN Nomina.ColaboradorReal r ON c.codr_colaboradorid = real_colaboradorid " +
        ' "LEFT JOIN CajaAhorro.CajaColaborador cc ON c.codr_colaboradorid = cajc_ColaboradorId AND cc.cajc_Estatus='A' " +
        ' "WHERE(cl.labo_naveid = " + naveid.ToString + ") " +
        '   "AND c.codr_activo = 1 AND cl.labo_reportes=1" +
        '"AND (c.codr_nombre +' '+ c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno) LIKE '%" + Nombre.Replace(" ", "%") + "%' " +
        '  "AND codr_colaboradorid NOT IN (SELECT cajc_ColaboradorId FROM CajaAhorro.CajaColaborador WHERE cajc_CajaAhorroId = " + CajaId.ToString + ")"

        'Return operaciones.EjecutaConsulta(consulta)
        parametro.ParameterName = "CajaAhorroId"
        parametro.Value = CajaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[CajaAhorro].[SP_ListaCajaColaboradorNoAsignados]", listaParametros)
    End Function

    Public Sub AltasCajaAhorro(ByVal caja As Entidades.CajaColaborador)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "IdColaborador"
        parametro.Value = caja.Colaborador.PColaboradorid.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCajaAhorro"
        parametro.Value = caja.PcajaAhorro.pCajaAhorroId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MontoAhorro"
        parametro.Value = caja.MontoAhorro
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "MontoAcumulado"
        parametro.Value = caja.MontoAcumulado
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = caja.Estatus
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("CajaAhorro.SP_altas_CajaColaborador", listaParametros)

    End Sub
    Public Sub EditarCajaAhorro(ByVal cajaUpdate As Entidades.CajaColaborador)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "IdColaborador"
        parametro.Value = cajaUpdate.Colaborador.PColaboradorid.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdCajaAhorro"
        parametro.Value = cajaUpdate.PcajaAhorro.pCajaAhorroId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MontoAhorro"
        parametro.Value = cajaUpdate.MontoAhorro
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "MontoAcumulado"
        parametro.Value = cajaUpdate.MontoAcumulado
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = cajaUpdate.Estatus
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("CajaAhorro.SP_Editar_CajaColaborador", listaParametros)

    End Sub

    Public Sub InsertCajaC(ByVal IdColaborador As Int32, ByVal MontoAcumulado As Double, ByVal MontoAhorro As Double, ByVal Status As String)
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty

        Consulta = "insert into CajaAhorro.CajaColaborador(cajc_ColaboradorId,cajc_MontoAhorro,cajc_MontoAhorroAcumulado,cajc_Estatus,cajc_usuariocreoid,cajc_fechacreacion, "
        Consulta += " values ("
        Consulta += IdColaborador.ToString + "," + MontoAcumulado.ToString + "," + "0," + MontoAhorro.ToString + "," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", (select getdate())," + Status.ToString + ")"
        ObjPersistencia.EjecutaConsulta(Consulta)
    End Sub


    Public Function ConsultarCajaDeAhorroSaldo(ByVal Colaboradorid As Int32, ByVal NaveID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = "select ccpc_montoahorro from CajaAhorro.ColaboradorPeriodoCaja " +
         "join CajaAhorro.CajaAhorro on ccpc_CajaAhorroId=caja_CajaAhorroId " +
         "where caja_estado='A' and caja_NaveId=" + NaveID.ToString + " and ccpc_ColaboradorId=" + Colaboradorid.ToString

        Return operaciones.EjecutaConsulta(consulta)
    End Function
End Class
