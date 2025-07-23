Imports System.Data.SqlClient
Public Class SolicitudPrestamoDA
    ''OBITIENE LAS CONFIGURACIONES YA GUARDADAS DE LAS NAVES
    Public Function DatosConfiguracion(ByVal idNave As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT *"
        consulta += " FROM         Prestamos.ConfiguracionPrestamos "
        consulta += " WHERE     (cpre_naveid = " + idNave.ToString + ")"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    ''VALIDACION PARA VER SI EL COLABORADOR TIENE PRESTAMOS POR AUTORIZAR
    Public Function ValidacionPrestamos(ByVal idColaborador As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select  pres_prestamoid, pres_colaboradorid from Prestamos.Prestamos "
        consulta += " where (pres_colaboradorid = " + idColaborador.ToString + ") and (pres_estatus = 'A' OR pres_estatus ='B' OR pres_estatus ='C' OR pres_estatus ='P')"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


    ''GUARDA LA SOLICITUD DEL PRESTAMO
    Public Sub PrestamoGuardar(ByVal SolicitudPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_colaboradorid"
        parametro.Value = SolicitudPrestamos.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_usuariocreoid"
        parametro.Value = SolicitudPrestamos.Pusuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_montoprestamo"
        parametro.Value = SolicitudPrestamos.Pmontoprestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_interes"
        parametro.Value = SolicitudPrestamos.Pinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_motivoprestamoid"
        parametro.Value = SolicitudPrestamos.Pmotivoprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_semanas"
        parametro.Value = SolicitudPrestamos.Psemanas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = SolicitudPrestamos.Pestatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_saldo"
        parametro.Value = SolicitudPrestamos.Psaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_justificacion"
        parametro.Value = SolicitudPrestamos.Pjustificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_abono"
        parametro.Value = SolicitudPrestamos.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_tipointeres"
        parametro.Value = SolicitudPrestamos.Ptipointeres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_totalintereses"
        parametro.Value = SolicitudPrestamos.Ptotalinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_naveid"
        parametro.Value = SolicitudPrestamos.Pcolaborador.PNaveID
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Guardar_Prestamo", listaParametros)

    End Sub


    Public Sub PrestamoGuardarPrestamoEspecial(ByVal SolicitudPrestamos As Entidades.SolicitudPrestamo, ByVal PrestamoEspecial As Integer, ByVal PagoSemanalQuincenal As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_colaboradorid"
        parametro.Value = SolicitudPrestamos.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_usuariocreoid"
        parametro.Value = SolicitudPrestamos.Pusuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_montoprestamo"
        parametro.Value = SolicitudPrestamos.Pmontoprestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_interes"
        parametro.Value = SolicitudPrestamos.Pinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_motivoprestamoid"
        parametro.Value = SolicitudPrestamos.Pmotivoprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_semanas"
        parametro.Value = SolicitudPrestamos.Psemanas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = SolicitudPrestamos.Pestatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_saldo"
        parametro.Value = SolicitudPrestamos.Psaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_justificacion"
        parametro.Value = SolicitudPrestamos.Pjustificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_abono"
        parametro.Value = SolicitudPrestamos.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_tipointeres"
        parametro.Value = SolicitudPrestamos.Ptipointeres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_totalintereses"
        parametro.Value = SolicitudPrestamos.Ptotalinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_naveid"
        parametro.Value = SolicitudPrestamos.Pcolaborador.PNaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PrestamoEspecial"
        parametro.Value = PrestamoEspecial
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PagoSemanalQuincenal"
        parametro.Value = PagoSemanalQuincenal
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Guardar_PrestamoEspecial", listaParametros)

    End Sub


    ''ACTUALIZA UN PRESTAMO
    Public Sub PrestamoActualizar(ByVal SolicitudPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@abonoEditar"
        parametro.Value = SolicitudPrestamos.PeditarAbono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@montoEditar"
        parametro.Value = SolicitudPrestamos.PeditarMonto
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_prestamoid "
        parametro.Value = SolicitudPrestamos.Pprestamoid
        listaParametros.Add(parametro)        

        parametro = New SqlParameter
        parametro.ParameterName = "pres_usuariomodificoid"
        parametro.Value = SolicitudPrestamos.Pusuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_montoautorizado"
        parametro.Value = SolicitudPrestamos.Pmontoprestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_interesautorizado"
        parametro.Value = SolicitudPrestamos.Pinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_semanasautorizadas"
        parametro.Value = SolicitudPrestamos.Psemanas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_abonoautorizado"
        parametro.Value = SolicitudPrestamos.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_tipointeresautorizado"
        parametro.Value = SolicitudPrestamos.Ptipointeres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_justificacion"
        parametro.Value = SolicitudPrestamos.Pjustificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_totalintereses"
        parametro.Value = SolicitudPrestamos.Ptotalinteres
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Actualizar_Prestamo", listaParametros)

    End Sub

    ''GUARDA EL ID DE LA SOLICITUD A CAJA CHICA
    Public Sub guardarSolicitudPrestamoID(ByVal SolicitudPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_solicitudfinanzasid "
        parametro.Value = SolicitudPrestamos.Psolicitudid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_prestamoid "
        parametro.Value = SolicitudPrestamos.Pprestamoid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Solicitud_Finanzas", listaParametros)

    End Sub

    ''METODOS DE INTERFAZ AUTORIZACION PRESTAMO
    Public Function NavesColaborador(ByVal idColaborador As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select *  "
        consulta += " from Framework.Naves "
        consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
        consulta += " where nave_naveid in (select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + idColaborador.ToString + ") AND nave_activo=1"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function NavesColaboradores(ByVal idColaborador As Int32) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select upper(nave_nombre) as nave_nombre,  upper(nave_naveid) as nave_naveid "
        consulta += " from Framework.Naves "
        consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
        consulta += " where nave_naveid in (select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + idColaborador.ToString + ") AND nave_activo=1"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function






    Public Function ListaNaves(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " nave_naveid, cpre_configuracionprestamoid, nave_nombre,  cpre_autorizaciongerente, cpre_autorizaciondirector, cpre_interes, cpre_montomaximonave, cpre_montomaximocolaborador, cpre_semanasmaximo  "
        consulta += " from Framework.Naves "
        consulta += " left join Prestamos.ConfiguracionPrestamos on cpre_naveid=nave_naveid "
        consulta += " where nave_naveid in (select naus_naveid from Framework.NavesUsuario where naus_usuarioid=" + idNave.ToString + ") AND nave_activo=1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Function ListaPrestamos(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "    SELECT * FROM Prestamos.Prestamos AS A"
        consulta += " JOIN Nomina.Colaborador as B on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on B.codr_colaboradorid=C.labo_colaboradorid"
        consulta += " where labo_naveid=" + idNave.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function



    Public Sub AutorizacionGerenteGuardar(ByVal AutorizacionPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = AutorizacionPrestamos.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_gerenteid"
        parametro.Value = AutorizacionPrestamos.PgerenteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_directorid"
        parametro.Value = 0
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = AutorizacionPrestamos.Pestatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_PrestamoGuardarAutorizacion", listaParametros)
    End Sub



    Public Sub AutorizacionDirectorGuardar(ByVal AutorizacionPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = AutorizacionPrestamos.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_gerenteid"
        parametro.Value = 0
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "pres_directorid"
        parametro.Value = AutorizacionPrestamos.PdirectorId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = AutorizacionPrestamos.Pestatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_PrestamoGuardarAutorizacion", listaParametros)
    End Sub
    ''TEMINAN METODOS DE AUTORIZACION PRESTAMO
    ''inicia metodos para cancelar prestamos

    Public Function ListaPrestamosCancelar(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "   SELECT * FROM Prestamos.Prestamos AS A"
        consulta += "  JOIN Nomina.Colaborador as B on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on B.codr_colaboradorid=C.labo_colaboradorid"
        consulta += "   where labo_naveid= " + idNave.ToString + " and pres_estatus= 'A'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub PrestamoCancelarGuardar(ByVal CancelarPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = CancelarPrestamos.Pprestamoid
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "pres_usuariomodificoid"
        parametro.Value = CancelarPrestamos.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = CancelarPrestamos.Pestatus
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Prestamos.SP_Actualizar_Estatus", listaParametros)

    End Sub

    ''teminan metodos para cancelar prestamos


    ''inicia metodos para cambiar el estatus de DE DINERO RECIBIDO A LA NAVE
    Public Sub confirmacionPrestamoRecibidoNave(ByVal CancelarPrestamos As Entidades.SolicitudPrestamo)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = CancelarPrestamos.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = CancelarPrestamos.Pestatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_usuariomodificoid"
        parametro.Value = CancelarPrestamos.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Prestamos.SP_Actualizar_Estatus", listaParametros)

    End Sub

    Public Sub guardarEntregaDePrestamo(ByVal CancelarPrestamos As Entidades.SolicitudPrestamo, ByVal fechas As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = CancelarPrestamos.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_estatus"
        parametro.Value = CancelarPrestamos.Pestatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_usuariomodificoid"
        parametro.Value = CancelarPrestamos.PgerenteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_fechaentrega"
        parametro.Value = fechas
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Pagar_Colaborador", listaParametros)

    End Sub

    ''TERMINA metodos para cambiar el estatus de DE DINERO RECIBIDO A LA NAVE


    '' INICIA  FILTRO DE PRESTAMOS
    Public Function ListaPrestamosFiltro(ByVal idNave As Int32, ByVal estatus As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal tipo As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " "
        consulta += "   SELECT CAST(pres_fechaentrega AS date) as fechaEntrega,* FROM Prestamos.Prestamos AS A"
        consulta += " JOIN Nomina.Colaborador as B on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on B.codr_colaboradorid=C.labo_colaboradorid"
        consulta += " where labo_naveid=" + idNave.ToString + " "

        If estatus <> "" Then
            consulta += "and pres_estatus='" + estatus + "'"
        End If

        If FechaInicio <> "" And FechaFin <> "" Then
            If tipo = 1 Then
                consulta += " AND (pres_fechasolicitud >='" + FechaInicio + "' and pres_fechasolicitud <='" + FechaFin + "')"
            ElseIf tipo = 2 Then
                consulta += " AND (pres_fechaentrega >='" + FechaInicio + "' and pres_fechaentrega <='" + FechaFin + "')"
            End If

        End If
        If tipo = 0 Then
            consulta += " ORDER BY A.pres_fechasolicitud DESC"
        ElseIf tipo = 1 Then
            consulta += " ORDER BY A.pres_fechasolicitud DESC"
        Else

            consulta += " ORDER BY A.pres_fechaentrega DESC"
        End If


        Return objOperaciones.EjecutaConsulta(consulta)
    End Function
    ''TERMINA FILTRO DE PRESTAMOIS
    Public Function FechasPeriodoNomina(ByVal idPeriodo As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from nomina.PeriodosNomina "
        consulta += " where pnom_PeriodoNomId= " + idPeriodo.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CajaDeAhorro(ByVal idNave As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from CajaAhorro.CajaAhorro"
        consulta += " where caja_NaveId =" + idNave.ToString
        consulta += "and caja_estado='A'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function CajaDeAhorroMonto(ByVal idColaborador As Integer, ByVal idCaja As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from CajaAhorro.ColaboradorPeriodoCaja "
        consulta += " where ccpc_ColaboradorId=" + idColaborador.ToString
        consulta += " and ccpc_CajaAhorroId=" + idCaja.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    ''INICIA LISTA PRESTAMOS POR COBRAR


    Public Function ListaPrestamosCobrar(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = " select *, (SELECT COUNT(*)+1 AS NumPago from Prestamos.PagoPrestamos where pagop_prestamoid=a.pres_prestamoid) as numPago from prestamos.Prestamos as A  "
        'consulta += " JOIN Nomina.Colaborador as c on A.pres_colaboradorid=codr_colaboradorid "
        'consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid "
        'consulta += " where b.labo_naveid=" + idNave.ToString + " and (a.pres_estatus='G' or a.pres_estatus='F') and a.pres_saldo>0 order by A.pres_saldo "
        'Return objOperaciones.EjecutaConsulta(consulta)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("Prestamos.SP_ListaPrestamosCobrar", listaParametros)

    End Function




    ''TERMINA LISTA PRESTAMOS POR COBRAR



    ''Calculo de faltas en un mes
    Public Function ListaFaltasMes(ByVal idColaborador As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = "select top 4 * from ControlAsistencia.CorteChecador where ccheck_colaborador=" + idColaborador.ToString + " order by  ccheck_periodo_id desc"
        Return objOperaciones.EjecutaConsulta(Consulta)
    End Function

    Public Function ConcentradoPrestamos(ByVal idNave As Integer, ByVal fechaInicial As DateTime, ByVal fechaFinal As DateTime) As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Prestamos.Prestamos AS A "
        consulta += " JOIN Nomina.Colaborador as B on A.pres_colaboradorid=codr_colaboradorid  "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on B.codr_colaboradorid=C.labo_colaboradorid"
        consulta += " JOIN Nomina.ColaboradorReal as D on D.real_colaboradorid=B.codr_colaboradorid"
        consulta += " where(labo_naveid = " + idNave.ToString + ") "
        consulta += " and labo_reportes='True'"
        consulta += " and (A.pres_estatus='D' or A.pres_estatus='E' or A.pres_estatus='F' or A.pres_estatus='G') "
        consulta += " and (pres_fechasolicitud>= '" + fechaInicial.ToShortDateString + "' and pres_fechasolicitud<=DATEADD(DAY, 1, '" + fechaFinal.ToShortDateString + "'))"
        Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ListaPreSolicitudesPrestamos(ByVal idNave As Int32, ByVal Estatus As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "    SELECT * FROM Prestamos.Prestamos AS A"
        consulta += " JOIN Nomina.Colaborador as B on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " JOIN Nomina.ColaboradorLaboral as C on B.codr_colaboradorid=C.labo_colaboradorid"
        consulta += " where labo_naveid=" + idNave.ToString
        consulta += " AND pres_estatus='" + Estatus.ToString + "'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function FechasCajaAhorro(ByVal NaveID As Integer) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * from CajaAhorro.CajaAhorro"
        consulta += " where caja_NaveId =" + NaveID.ToString
        consulta += " and caja_estado='A'"
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function editarPrestamo(ByVal prestamoID As Integer, ByVal colaboradorID As Integer) As DataTable
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta += " SELECT "
        'consulta += " pres_prestamoid,"
        'consulta += " pres_colaboradorid,"
        'consulta += " pres_montoautorizado,"
        'consulta += " pres_motivoprestamoid,"
        'consulta += " pres_semanasautorizadas,"
        'consulta += " pres_saldo,"
        'consulta += " pres_justificacion,"
        'consulta += " pres_abonoautorizado,"
        'consulta += " pres_tipointeresautorizado,"
        'consulta += " pres_interesautorizado,"
        'consulta += " ISNUL(pres_prestamoEspecial,0) pres_prestamoEspecial"
        'consulta += " FROM Prestamos.Prestamos"
        'consulta += " where pres_prestamoid = " + prestamoID.ToString
        'consulta += " and pres_colaboradorid=" + colaboradorID.ToString
        'Return objoperaciones.EjecutaConsulta(consulta)

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@prestamoID"
        parametro.Value = prestamoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorID"
        parametro.Value = colaboradorID
        listaParametros.Add(parametro)

        Return objoperaciones.EjecutarConsultaSP("Prestamos.SP_ConsultarPrestamoEditarPrestamo", listaParametros)

    End Function
    Public Function obtnerPeriodoCaja(ByVal fecha As String, ByVal naveid As String) As DataTable
        Dim objoperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT top 1 pnom_NoSemanaCajaAhorro from Nomina.PeriodosNomina WHERE pnom_FechaFinal <= '" + fecha + "'  and pnom_NaveId=" + naveid + " ORDER by pnom_FechaInicial desc"
        Return objoperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerMontoAhorro(ByVal idColaborador As Int32, idCajaAhorro As Int32) As DataTable
        Dim consulta As String = ""
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        consulta = "SELECT isnull(SUM(ccpc_MontoAhorro),0) as monto FROM CajaAhorro.ColaboradorPeriodoCaja WHERE ccpc_CajaAhorroId=" + idCajaAhorro.ToString + " AND ccpc_ColaboradorId= " + idColaborador.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function mostraDatosPrestamo(ByVal idNave As Int32, ByVal estatus As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal tipo As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipo"
        parametro.Value = tipo
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Prestamos].[SP_Consulta_DatosPrestamos]", listaParametros)

        'Dim consulta As String = " "
        'consulta += " SELECT cons.seleccion,color,cons.nombre,cons.estatus,cons.idprestamo,idcolaborador,cons.interes,cons.tipoInteres, case  when ROUND(((cons.dias % 365) / 30.4 ),0) = 12 THEN"
        'consulta += " (cons.dias / 365) +1 ELSE (cons.dias / 365) END as anios,"
        'consulta += " case when ROUND(((cons.dias % 365) / 30.4 ),0) = 12 THEN"
        'consulta += " 0 ELSE cast (ROUND(((cons.dias % 365) / 30.4), 0) AS int) END  as meses,"
        'consulta += " cons.faltas,cons.fecha,cons.fechaEntrega,periodo,cons.prestamo,cons.Intereses,cons.abono,cons.saldo,saldotermino,caja,estatus2,estatusreal,activo"
        'consulta += " FROM("
        'consulta += " SELECT c.codr_colaboradorid idcolaborador,p.pres_prestamoid as idprestamo, 0 as seleccion,'' color, p.pres_estatus estatus, (c.codr_nombre + ' ' + c.codr_apellidopaterno + ' ' + c.codr_apellidomaterno ) nombre"
        'consulta += " ,cr.real_fecha, DATEDIFF(day,cr.real_fecha,GETDATE())dias,p.pres_fechasolicitud,CAST(pres_fechasolicitud AS date)  AS fecha, '' saldotermino, '' caja,"
        'consulta += " ISNULL((SELECT sum (ccheck_inasistencia) FROM ControlAsistencia.CorteChecador cc WHERE cc.ccheck_colaborador=c.codr_colaboradorid AND cc.ccheck_fecha_creo BETWEEN cast(DATEADD(dd,-30,getdate()) as date) AND CAST(GETDATE() as date) ),0 )faltas"
        'consulta += " ,CAST(p.pres_fechaentrega as date) fechaEntrega, '' estatus2, p.pres_montoautorizado AS prestamo, '' estatusReal, cast (DATEPART(WEEK, p.pres_fechaentrega  )as varchar) as periodo"
        'consulta += " ,p.pres_abonoautorizado abono, p.pres_saldo saldo, p.pres_tipointeres tipoInteres, p.pres_interes interes,p.pres_totalintereses Intereses , c.codr_activo as activo"
        'consulta += "  FROM Prestamos.Prestamos p INNER JOIN Nomina.Colaborador c on p.pres_colaboradorid=c.codr_colaboradorid"
        'consulta += " INNER JOIN Nomina.ColaboradorReal cr on cr.real_colaboradorid=c.codr_colaboradorid"
        'consulta += " INNER JOIN Nomina.ColaboradorLaboral cl on cl.labo_colaboradorid=c.codr_colaboradorid"
        'consulta += " where labo_naveid=" + idNave.ToString + " "


        'If estatus <> "" Then
        '    consulta += "and pres_estatus='" + estatus + "'"
        'End If

        'If FechaInicio <> "" And FechaFin <> "" Then
        '    If tipo = 1 Then
        '        consulta += " AND (pres_fechasolicitud >='" + FechaInicio + "' and pres_fechasolicitud <='" + FechaFin + "')"
        '    ElseIf tipo = 2 Then
        '        consulta += " AND (pres_fechaentrega >='" + FechaInicio + "' and pres_fechaentrega <='" + FechaFin + "')"
        '    End If

        'End If
        'consulta += " )cons"
        'If tipo = 0 Then
        '    consulta += " ORDER BY pres_fechasolicitud DESC"
        'ElseIf tipo = 1 Then
        '    consulta += " ORDER BY pres_fechasolicitud DESC"
        'Else

        '    consulta += " ORDER BY fechaentrega DESC"
        'End If



        'Return objOperaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub CambiarEstatusDineroDevuelto(ByVal idPrestamo As Int32, ByVal estatus As String, ByVal usuario As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@pres_prestamoid"
        parametro.Value = idPrestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pres_usuariomodificoid"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pres_estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Devolver_DineroFinanzas", listaParametros)
    End Sub

    Public Function ValidarPerfilUsuarioFinazas(ByVal UsuarioId As Integer)
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT peus_perfilid FROM Framework.PerfilesUsuario WHERE (peus_usuarioid = " + UsuarioId.ToString + ")"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function llenarTablaPrestaciones(ByVal idNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal Colaborador As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", idNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AreaID", idArea)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@DepartamentoID", idDepartamento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Colaborador", Colaborador)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Prestamos].[SP_ObtieneListaColaboradores_PrestacionesSAY]", listaParametros)

    End Function

    Public Function ObtenerConceptosPrestaciones(ByVal NaveID As Integer, ByVal Accion As Integer, ByVal Concepto As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Concepto", Concepto)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Prestamos].[SP_ObtieneDatosConfiguracion_Prestaciones]", listaParametros)

    End Function

    Public Function GuardarPrestacionesSAY(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Prestamos].[SP_InsertaPrestaciones_Colaboradores]", listaParametros)

    End Function

    Public Function ObtieneInformacionPrestacionesCajaChica(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Prestamos].[SP_ObtieneInformacion_SalidasCajaChica_Prestaciones]", listaParametros)
    End Function

    Public Function EnviarSolicitudesPrestacionesCaja(ByVal IdCaja As Int32, ByVal FormaPago As String, ByVal Cantidad As Double, ByVal Beneficiacio As String,
                                 ByVal Observaciones As String, ByVal ReposicionCajaChica As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "DECLARE @Mensaje int "
        consulta += "EXEC usp_AltaPrestamoCajaChicaPrestacionesSAY @Mensaje OUTPUT," + IdCaja.ToString + ",'" + FormaPago + "'," + Cantidad.ToString + ",'" + Beneficiacio + "','" + Observaciones + "','" + ReposicionCajaChica.ToString + "' SELECT @Mensaje"

        EnviarSolicitudesPrestacionesCaja = operaciones.EjecutaConsulta(consulta)
        Return EnviarSolicitudesPrestacionesCaja
    End Function

    Public Function guardarSolicitudPrestacionID(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Prestamos].[SP_ActualizaDatosPrestaciones_SolicitudCajaChicaID]", listaParametros)
    End Function

End Class

