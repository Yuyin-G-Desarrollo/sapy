Imports System.Data.SqlClient

Public Class IncentivosDA


    Public Function ListaIncentivos(ByVal nombre As String, ByVal activo As Boolean, ByVal idNave As Int32) As DataTable ''declaramos el metodo como Datatable es nuestra consulta

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos ''Conexion y operaciones
        Dim consulta As String = "select * from Nomina.MotivosIncentivos a LEFT join Framework.Naves c on (moin_naveid=nave_naveid) LEFT join Framework.NavesUsuario on (nave_naveid= naus_naveid)" 'Consulta de todo haciendo Join en los motivos y las Naves
        consulta += "where moin_nombre like '%" + nombre.ToString + "%'" 'Like de consulta donde realizara la comparacion con lo que tenga la variable de nombre
        consulta += " and moin_activo ='" + activo.ToString + "' and naus_usuarioid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString 'Añadimos que que tambien realice la comparacion con los motivos activos

        If (idNave > 0) Then 'Condicional que nos permite entrar a esta parte del codigo solo si el Id de la Nave es mayor a 0
            consulta += " and moin_naveid= " + idNave.ToString
        End If

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function buscarMotivoIncentivo(ByVal motivoId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos ''Conexion y operaciones
        Dim consulta As String = "SELECT * FROM Nomina.MotivosIncentivos where moin_motivoincentivoid=" + motivoId.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaSolicitudesIncentivos(ByVal nombre As String, ByVal fecha As String, ByVal estatus As String, ByVal userid As Int32, ByVal SegundaFecha As String, ByVal NaveId As Int32, ByVal Accesototal As Boolean, ByVal PeriodoNomina As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = "select *,g.user_username as nombreAutorizo from Nomina.SolicitudIncentivos  "
        consulta += " join Framework.Usuarios on soin_usuariocreoid=user_usuarioid  "
        consulta += " JOIN nomina.MotivosIncentivos on soin_motivoincentivoid=moin_motivoincentivoid   "
        consulta += " JOIN Nomina.Colaborador on codr_colaboradorid=soin_colaboradorid  "
        consulta += " JOIN Nomina.ColaboradorLaboral on codr_colaboradorid=labo_colaboradorid"
        consulta += " JOIN Framework.Grupos ON grup_grupoid=labo_departamentoid  "
        consulta += " LEFT JOIN Framework.Usuarios as g ON soin_usuarioautorizo=g.user_usuarioid "
        consulta += " LEFT JOIN Nomina.Celulas as H 	on h.celu_celulaid=labo_celulaid "
        consulta += "where (codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%" + nombre.Replace(" ", "%") + "%' "

        If Accesototal = True Then

        Else
            consulta += "and soin_usuariocreoid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        End If

        'If fecha <> "" Then
        '    consulta += "AND soin_fechacreacion BETWEEN '" + fecha.ToString + " 00:00:01' and '" + SegundaFecha.ToString + " 23:59:59'"
        'End If
        If estatus <> "" Then
            consulta += " AND soin_estado='" + estatus.ToString + "' "
        End If
        If NaveId > 0 Then
            consulta += " and labo_naveid=" + NaveId.ToString
        End If
        If PeriodoNomina > 0 Then
            consulta += " AND soin_periodonominapagado=" + PeriodoNomina.ToString
        End If

        consulta += " order by grup_name, codr_nombre"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaSolicitudesIncentivosConsulta(ByVal nombre As String, ByVal estatus As String, ByVal userid As Int32, ByVal NaveId As Int32, ByVal Accesototal As Integer, ByVal PeriodoNomina As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Colaborador", nombre)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Estatus", estatus)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", userid)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AccesoTotal", Accesototal)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PeriodoNominaID", PeriodoNomina)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ListaSolicitudes_Gratificaciones]", listaParametros)


        'Dim objOperaciones As New Persistencia.OperacionesProcedimientos

        'Dim consulta As String = "SELECT CAST(0 AS BIT) AS Seleccion, sol.soin_estado, NULL as Color , sol.soin_solicitudincentivoid, co.codr_colaboradorid, codr_nombre + ' ' + codr_apellidopaterno + ' ' + codr_apellidomaterno AS NOMBRE," +
        '" grup_grupoid, grup_name AS DEPARTAMENTO, clu.celu_celulaid, clu.celu_nombre AS CELULA, sol.soin_justificación, " +
        '" sol.soin_motivoincentivoid AS MotUnoID, MI.moin_nombre AS MotUno, sol.soin_monto1 montouno, sol.soin_motivoincentivoid2 AS MotDosID," +
        '" MIDOS.moin_nombre AS MotDos, sol.soin_monto2 montodos, sol.soin_motivoincentivoid3 AS MotTresID, MITRES.moin_nombre AS MotTres, sol.soin_monto3 montotres, sol.soin_monto AS TOTAL, " +
        '" U.user_usuarioid AS IDSOLICITO, U.user_username AS USUARIOSOLICITO, sol.soin_fechacreacion AS FECHASOLICITO, " +
        '" ug.user_usuarioid AS IDAUTORIZO, ug.user_username AS USUARIOAUTORIZO, SOL.soin_fechaautorizacion AS FECHAAUTORIZO, " +
        '" mi.moin_diaadicional" +
        '" FROM Nomina.SolicitudIncentivos sol" +
        '" JOIN Framework.Usuarios u ON soin_usuariocreoid = user_usuarioid" +
        '" JOIN nomina.MotivosIncentivos mi ON sol.soin_motivoincentivoid = mi.moin_motivoincentivoid" +
        '" JOIN Nomina.Colaborador co ON co.codr_colaboradorid = sol.soin_colaboradorid" +
        '" JOIN Nomina.ColaboradorLaboral cl ON co.codr_colaboradorid = cl.labo_colaboradorid" +
        '" JOIN Framework.Grupos gr ON grup_grupoid = cl.labo_departamentoid" +
        '" LEFT JOIN Nomina.MotivosIncentivos MIDOS ON sol.soin_motivoincentivoid2 = MIDOS.moin_motivoincentivoid" +
        '" LEFT JOIN Nomina.MotivosIncentivos MITRES ON sol.soin_motivoincentivoid3 = MITRES.moin_motivoincentivoid" +
        '" LEFT JOIN Framework.Usuarios AS ug ON sol.soin_usuarioautorizo = ug.user_usuarioid" +
        '" LEFT JOIN Nomina.Celulas AS clu ON clu.celu_celulaid = cl.labo_celulaid" +
        '" where (codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%" + nombre.Replace(" ", "%") + "%' " +
        '" and grup_grupoid IN (SELECT dept_departamentoid" +
        '" FROM Nomina.encargadodepartamento" +
        '" WHERE dept_colaboradorid= " + Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser.ToString + ")"

        'If Accesototal = True Then

        'Else
        '    consulta += "and soin_usuariocreoid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        'End If

        ''If fecha <> "" Then
        ''    consulta += "AND soin_fechacreacion BETWEEN '" + fecha.ToString + " 00:00:01' and '" + SegundaFecha.ToString + " 23:59:59'"
        ''End If
        'If estatus <> "" Then
        '    consulta += " AND soin_estado='" + estatus.ToString + "' "
        'End If
        ''If NaveId > 0 Then
        ''    consulta += " and labo_naveid=" + NaveId.ToString
        ''End If
        'If PeriodoNomina > 0 Then
        '    consulta += " AND soin_periodonominapagado=" + PeriodoNomina.ToString
        'End If

        'consulta += " order by grup_name, codr_nombre"
        'Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaSolicitudesIncentivosSinFechas(ByVal nombre As String, ByVal estatus As String, ByVal userid As Int32, ByVal NaveId As Int32, ByVal Accesototal As Boolean, ByVal PeriodoNomina As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select *,g.user_username as nombreAutorizo from Nomina.SolicitudIncentivos"
        consulta += " LEFT join Framework.Usuarios on soin_usuariocreoid=user_usuarioid "
        consulta += " LEFT JOIN nomina.MotivosIncentivos on soin_motivoincentivoid=moin_motivoincentivoid "
        consulta += " LEFT JOIN Nomina.Colaborador on codr_colaboradorid=soin_colaboradorid"
        consulta += " LEFT JOIN Nomina.ColaboradorLaboral on codr_colaboradorid=labo_colaboradorid"
        consulta += " LEFT JOIN Framework.Grupos ON grup_grupoid=labo_departamentoid"
        consulta += " LEFT JOIN Framework.Usuarios as g ON soin_usuarioautorizo=g.user_usuarioid "
        consulta += " LEFT JOIN Nomina.Celulas as H ON H.celu_celulaid=labo_celulaid"
        consulta += " where  (codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%" + nombre.Replace(" ", "%") + "%' "
        If Accesototal = True Then

        Else
            consulta += "and soin_usuariocreoid=" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        End If

        If estatus <> "" Then
            consulta += " AND soin_estado='" + estatus.ToString + "' "
        End If
        If NaveId > 0 Then
            consulta += " and labo_naveid=" + NaveId.ToString
        End If
        If PeriodoNomina > 0 Then
            consulta += " or soin_periodonominapagado=" + PeriodoNomina.ToString
        End If
        consulta += " order by grup_name, codr_nombre"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function



    Public Function ValidacionSolicitudesIncentivos(ByVal nombre As String, ByVal fecha As String, ByVal estatus As String, ByVal userid As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.SolicitudIncentivos join Framework.Usuarios on soin_usuariocreoid=user_usuarioid JOIN nomina.MotivosIncentivos on soin_motivoincentivoid=moin_motivoincentivoid JOIN Nomina.Colaborador on codr_colaboradorid=soin_colaboradorid JOIN Nomina.ColaboradorLaboral on codr_colaboradorid=labo_colaboradorid"
        consulta += " JOIN Framework.Grupos ON grup_grupoid=labo_departamentoid LEFT JOIN Framework.Usuarios as g ON soin_usuarioautorizo=g.user_usuarioid where "
        consulta += "(codr_nombre + ' '+codr_apellidopaterno + ' ' + codr_apellidomaterno) like '%" + nombre.Replace(" ", "%") + "%'"
        If fecha <> "" Then
            consulta += "AND soin_fechacreacion BETWEEN '" + fecha.ToString + " 00:00:01' and '" + fecha.ToString + " 23:59:59'"
        End If
        If estatus <> "" Then
            consulta += " AND soin_estado='" + estatus.ToString + "' "
        End If

        If userid > 0 Then
            consulta += " And soin_colaboradorid =" + userid.ToString
        End If
        consulta += " order by soin_fechacreacion desc"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function



    Public Function ConcentradoGratificacionesAnual(ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Anio"
        parametro.Value = Today.Year
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = Naveid
        listaparametros.Add(parametro)
        Dim Tabla As DataTable
        Tabla = operaciones.EjecutarConsultaSP("Nomina.SP_ConcentradoGratificacionAnual", listaparametros)
        Return Tabla
    End Function




    Public Sub AltaIncentivo(ByVal Incentivo As Entidades.Incentivos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "moin_nombre"
        parametro.Value = Incentivo.INombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_descripcion"
        parametro.Value = Incentivo.IDescripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_naveid"
        parametro.Value = Incentivo.IIncentivosNaveId.PNaveId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_montomax"
        parametro.Value = Incentivo.IMontoMaximo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_activo"
        parametro.Value = Incentivo.IActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_pagoExtra"
        parametro.Value = Incentivo.IPagoDiaExtra
        listaparametros.Add(parametro)
        operaciones.EjecutarSentenciaSP("Nomina.SP_alta_motivo_incentivos", listaparametros)
    End Sub


    Public Sub EditarIncentivo(ByVal Incentivo As Entidades.Incentivos)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "moin_nombre"
        parametro.Value = Incentivo.INombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_descripcion"
        parametro.Value = Incentivo.IDescripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_naveid"
        parametro.Value = Incentivo.IIncentivosNaveId.PNaveId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_montomax"
        parametro.Value = Incentivo.IMontoMaximo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_activo"
        parametro.Value = Incentivo.IActivo
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_motivoincentivoid"
        parametro.Value = Incentivo.IIncentivoId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "moin_pagoextra"
        parametro.Value = Incentivo.IPagoDiaExtra
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_editar_motivos_incentivos", listaparametros)

    End Sub


    Public Sub CancelarSolicitudIncentivo(ByVal IdSolicitud As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.SolicitudIncentivos  set soin_estado='E' where  soin_solicitudincentivoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub


    Public Sub AceptarSolicitudIncentivo(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32, ByVal monto As Double)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.SolicitudIncentivos  set soin_estado='B', soin_usuarioautorizo=" + idAprobo.ToString + ", soin_fechaautorizacion= (select GETDATE()), soin_monto=" + monto.ToString + " where  soin_solicitudincentivoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub

    Public Sub SolicitarACajaChica(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32, ByVal monto As Double)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.SolicitudIncentivos  set soin_estado='F', soin_usuarioautorizo=" + idAprobo.ToString + ", soin_fechaautorizacion= (select GETDATE()), soin_monto=" + monto.ToString + " where  soin_solicitudincentivoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub


    Public Sub AgregarIdSolicitudCajaChica(ByVal IdSolicitud As Int32, ByVal idCaja As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.SolicitudIncentivos set soin_solicitudcajaid=" + idCaja.ToString + " where soin_solicitudincentivoid= " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub


    Public Sub AceptarSolicitudIncentivoDirector(ByVal IdSolicitud As Int32, ByVal idAprobo As Int32, ByVal monto As Double)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.SolicitudIncentivos  set soin_estado='C', soin_usuarioautorizo=" + idAprobo.ToString + ", soin_fechaautorizacion= (select GETDATE()), soin_monto=" + monto.ToString + " where  soin_solicitudincentivoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub


    Public Sub RechazarrSolicitudIncentivo(ByVal IdSolicitud As Int32, ByVal IdAprobo As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "update Nomina.SolicitudIncentivos  set soin_estado='D', soin_usuarioautorizo=" + IdAprobo.ToString + ", soin_fechaautorizacion= (select GETDATE()) where  soin_solicitudincentivoid = " + IdSolicitud.ToString
        operaciones.EjecutaConsulta(consulta)
    End Sub





    Public Function ListaIncentivosSegUser(ByVal IDUsuario As Integer) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.MotivosIncentivos join Framework.Naves on (moin_naveid = nave_naveid) join Framework.NavesUsuario on (nave_naveid=naus_naveid)"

        If IDUsuario > 0 Then
            consulta += " where naus_usuarioid=" + IDUsuario.ToString + "and moin_activo= 1 "
        End If

        Return opereciones.EjecutaConsulta(consulta)
    End Function



    Public Function ListaIncentivosSegUsuarioConsulta(ByVal IDUsuario As Integer, ByVal idNave As Int32) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.MotivosIncentivos join Framework.Naves on (moin_naveid = nave_naveid)" +
            " join Framework.NavesUsuario on (nave_naveid=naus_naveid) WHERE moin_activo = 1 AND moin_diaadicional = 0 "

        If IDUsuario > 0 Then
            consulta += " AND naus_usuarioid=" + IDUsuario.ToString + "and moin_activo= 1 and moin_naveid=" + idNave.ToString
        End If
        consulta += " ORDER BY 2"
        Return opereciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaIncentivosSegUsuario(ByVal IDUsuario As Integer, ByVal idNave As Int32) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.MotivosIncentivos join Framework.Naves on (moin_naveid = nave_naveid) join Framework.NavesUsuario on (nave_naveid=naus_naveid)"

        If IDUsuario > 0 Then
            consulta += " where naus_usuarioid=" + IDUsuario.ToString + "and moin_activo= 1 and moin_naveid=" + idNave.ToString
        End If
        consulta += " ORDER BY 2"
        Return opereciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaIncentivosSegUserImprimir(ByVal IDUsuario As Integer, ByVal FechaInicial As String, ByVal FechaDos As String, ByVal NaveId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select soin_colaboradorid, soin_monto,soin_justificación as Justificacion,moin_nombre,(codr_apellidopaterno+' ' + codr_apellidomaterno+ ' '  + codr_nombre) as Nombre from Nomina.SolicitudIncentivos LEFT join Framework.Usuarios on soin_usuariocreoid=user_usuarioid LEFT JOIN nomina.MotivosIncentivos on soin_motivoincentivoid=moin_motivoincentivoid  LEFT JOIN Nomina.Colaborador on codr_colaboradorid=soin_colaboradorid LEFT JOIN Nomina.ColaboradorLaboral on codr_colaboradorid=labo_colaboradorid"
        consulta += " LEFT JOIN Framework.Grupos ON grup_grupoid=labo_departamentoid LEFT JOIN Framework.Usuarios as g ON soin_usuarioautorizo=g.user_usuarioid where soin_estado='C'"

        If FechaInicial <> "" Then
            consulta += "AND soin_fechacreacion BETWEEN '" + FechaInicial.ToString + " 00:00:01' and '" + FechaDos.ToString + " 23:59:59'"
        End If

        If NaveId > 0 Then
            consulta += " and labo_naveid=" + NaveId.ToString
        End If

        consulta += " order by soin_fechacreacion desc"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function BuscarSolicitudIncetivo(ByVal SolicitudIncentivo As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.SolicitudIncentivos where soin_solicitudincentivoid=" + SolicitudIncentivo.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub EnviarSolicitud(ByVal EnviarSolIncentivo As Entidades.SolicitudIncentivos, ByVal Naveid As Int32, ByVal PeriodoNomina As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "soin_motivoincentivoid"
        parametro.Value = EnviarSolIncentivo.PMotivoID.IIncentivoId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_colaboradorid"
        parametro.Value = EnviarSolIncentivo.PColaboradorID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_monto"
        parametro.Value = EnviarSolIncentivo.PMonto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_justificacion"
        parametro.Value = EnviarSolIncentivo.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naveid"
        parametro.Value = Naveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodonomina"
        parametro.Value = PeriodoNomina
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_monto1" 'montos gratificaciones 2 y 3
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion1
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_motivoincentivoid2"
        If Not EnviarSolIncentivo.PMotivoID2 Is Nothing Then
            parametro.Value = EnviarSolIncentivo.PMotivoID2.IIncentivoId
        Else
            parametro.Value = DBNull.Value
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_monto2"
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion2
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_motivoincentivoid3"
        If Not EnviarSolIncentivo.PMotivoID3 Is Nothing Then
            parametro.Value = EnviarSolIncentivo.PMotivoID3.IIncentivoId
        Else
            parametro.Value = DBNull.Value
        End If
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_monto3"
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion3
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Nomina_solicitar_incentivo", listaparametros)
    End Sub

    Public Sub EditarSolicitud(ByVal EnviarSolIncentivo As Entidades.SolicitudIncentivos, ByVal idSolicitud As Int32)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idSolicitud"
        parametro.Value = idSolicitud
        listaparametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "idMotivoincentivo"
        parametro.Value = EnviarSolIncentivo.PMotivoID.IIncentivoId
        listaparametros.Add(parametro)
        'varias gratificaciones
        parametro = New SqlParameter
        parametro.ParameterName = "idmotivoincentivo2"
        parametro.Value = EnviarSolIncentivo.PMotivoID2.IIncentivoId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "idmotivoincentivo3"
        parametro.Value = EnviarSolIncentivo.PMotivoID3.IIncentivoId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "Monto"
        parametro.Value = EnviarSolIncentivo.PMonto
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "Monto1"
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion1
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "Monto2"
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion2
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "Monto3"
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion3
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "Justificacion"
        parametro.Value = EnviarSolIncentivo.PDescripcion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "usuarioModifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Editar_SolicitudIncentivo", listaparametros)
    End Sub

    Public Function BuscarFechaInicialPerdiodo(ByVal PeridodoNomina As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select pnom_FechaInicial from Nomina.PeriodosNomina where pnom_periodonomid=" + PeridodoNomina.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function BuscarFechaFinalPerdiodo(ByVal PeridodoNomina As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select pnom_FechaFinal from Nomina.PeriodosNomina where pnom_periodonomid=" + PeridodoNomina.ToString
        Return operaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function validarEstatusAutorizado(ByVal colaboradorid As Int32, ByVal solicituid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta = "SELECT soin_estado from Nomina.SolicitudIncentivos WHERE soin_colaboradorid=" + colaboradorid.ToString + "and soin_solicitudincentivoid=" + solicituid.ToString
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function validarConfiguracion(ByVal naveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * FROM Nomina.ConfiguracionGratificaciones"
        consulta += " where confgrat_naveid =" + naveID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub EnviarSolicitudDiaAdicional(ByVal EnviarSolIncentivo As Entidades.SolicitudIncentivos, ByVal Naveid As Int32, ByVal PeriodoNomina As Int32)
       
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "soin_motivoincentivoid"
        parametro.Value = EnviarSolIncentivo.PMotivoID.IIncentivoId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_colaboradorid"
        parametro.Value = EnviarSolIncentivo.PColaboradorID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_monto"
        parametro.Value = EnviarSolIncentivo.PMonto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_justificacion"
        parametro.Value = EnviarSolIncentivo.PDescripcion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naveid"
        parametro.Value = Naveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodonomina"
        parametro.Value = PeriodoNomina
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "soin_monto1"
        parametro.Value = EnviarSolIncentivo.PMontoGratificacion1
        listaparametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Nomina_solicitar_incentivo_Dia_Adicional", listaparametros)
    End Sub

    Public Function verIncentivosDiasAdicional(ByVal naveid As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT moin_motivoincentivoid, moin_nombre, moin_descripcion, moin_naveid," +
        " moin_montomax, moin_activo, moin_incluirnomina, moin_diaadicional" +
        " FROM Nomina.MotivosIncentivos" +
        " WHERE moin_activo = 1 And moin_diaadicional = 1" +
        " AND moin_naveid = " + naveid.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarDiaAdicionalColaborador(ByVal motivoid As Int32, ByVal colaboradorid As Int32, ByVal periodoid As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim contDA As Int32 = 0
        Dim cadena As String = "SELECT" +
        " COUNT(soin_solicitudincentivoid) AS Total" +
        " FROM Nomina.SolicitudIncentivos" +
        " WHERE soin_estado = 'B'" +
        " AND soin_motivoincentivoid = " + motivoid.ToString +
        " AND soin_colaboradorid = " + colaboradorid.ToString +
        " AND soin_periodonominapagado = " + periodoid.ToString
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            contDA = CInt(dt.Rows(0).Item(0))
        End If
        Return contDA
    End Function

End Class
