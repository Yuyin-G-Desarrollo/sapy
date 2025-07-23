Imports System.Data.SqlClient

Public Class CobranzaPrestamosDA

    ''INICIA SEMANA NOMINA ACTIVA
    Public Function SemanaNominaActiva(ByVal idNave As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT * from Nomina.PeriodosNomina as A "
        consulta += " INNER JOIN Framework.naves as B on B.nave_naveid= A.pnom_NaveId"
        consulta += " where  pnom_NaveId= " + idNave.ToString
        consulta += " and pnom_stPeriodoNomina = 'A' "

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function FechasSemanaNomina(ByVal IdSemanaNomina As Integer) As DataTable
        Dim ObjOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * from Nomina.PeriodosNomina"
        consulta += " where pnom_PeriodoNomId =" + IdSemanaNomina.ToString
        Return ObjOperaciones.EjecutaConsulta(consulta)
    End Function

    ''TERMINA SEMANA NOMINA ACTIVA


    ''INICIA GUARDAR COBRANZA PRESTAMOS
    Public Sub cobranzaGuardar(ByVal Cobranza As Entidades.CobranzaPrestamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "pagop_prestamoid"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_semananominaid"
        parametro.Value = Cobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_numeropago"
        parametro.Value = Cobranza.PnumPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_abonocapital"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_interes"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldoanterior"
        parametro.Value = Cobranza.PsaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldonuevo"
        parametro.Value = Cobranza.PSolicitudPrestamo.Psaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_liquidacion"
        parametro.Value = Cobranza.Pliquidacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_usuariomodificoid"
        parametro.Value = Cobranza.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_fechamodificacion"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pfechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_dentroNomina"
        parametro.Value = Cobranza.PTipoAbono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_naveid"
        parametro.Value = Cobranza.Pcolaborador.PNaveID
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_GuardarCobranza", listaParametros)
    End Sub
    ''TERMINA GUARDAR COBRANZA PRESTAMOS

    ''INICIA editar COBRANZA PRESTAMOS
    Public Sub cobranzaEditar(ByVal Cobranza As Entidades.CobranzaPrestamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "pagop_idpago"
        parametro.Value = Cobranza.PPagoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_abonocapital"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_interes"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldoanterior"
        parametro.Value = Cobranza.PsaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldonuevo"
        parametro.Value = Cobranza.PSolicitudPrestamo.Psaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_liquidacion"
        parametro.Value = Cobranza.Pliquidacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_fechamodificacion"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pfechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_usuariomodificoid"
        parametro.Value = Cobranza.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pres_prestamoid"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pprestamoid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Actualizar_Cobranza", listaParametros)
    End Sub
    ''TERMINA editar COBRANZA PRESTAMOS






    ''INICIA LISTA PRESTAMOS COBRADOS


    Public Function ListaPrestamosCobrados(ByVal semanaNominaID As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  SELECT * FROM Prestamos.Prestamos AS A  "
        consulta += " JOIN Nomina.Colaborador as c on A.pres_colaboradorid=c.codr_colaboradorid "
        consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid "
        consulta += " join Prestamos.PagoPrestamos AS d on d.pagop_prestamoid=a.pres_prestamoid "
        consulta += " JOIN Nomina.ColaboradorReal as E on E.real_colaboradorid = A.pres_colaboradorid"
        consulta += " WHERE pagop_semananominaid= " + semanaNominaID.ToString
        consulta += " and C.codr_activo=1 "
        consulta += " and (pagop_dentroNomina='A' or pagop_dentroNomina='B') "
        consulta += " order by E.real_fecha "

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function PrestamosActivos(ByVal idNave) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos

        Dim consulta As String = "SELECT pres_prestamoid, pres_semanasautorizadas, "
        consulta += " isnull(pagop_saldonuevo,(isnull(A.pres_montoautorizado,0.0)+isnull(A.pres_totalintereses,0.0))) pagop_saldonuevo, "
        consulta += " isnull(pagop_numeropago,0) pagop_numeropago, "
        consulta += " isnull(pagop_saldoanterior,(isnull(A.pres_montoautorizado,0.0)+isnull(A.pres_totalintereses,0.0))) pagop_saldoanterior, "
        consulta += " codr_nombre, codr_apellidopaterno, codr_apellidomaterno, pres_totalintereses, pres_montoautorizado, "
        consulta += " isnull(pagop_abonocapital,0.0) pagop_abonocapital, "
        consulta += " pres_tipointeresautorizado, isnull(pagop_interes,0.0) pagop_interes, "
        consulta += " pres_fechamodificacion FROM Prestamos.Prestamos AS A  "
        consulta += " JOIN Nomina.Colaborador as c on A.pres_colaboradorid=c.codr_colaboradorid "
        consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid  "
        consulta += " left join Prestamos.PagoPrestamos AS d on d.pagop_prestamoid=a.pres_prestamoid  "
        consulta += " JOIN Nomina.ColaboradorReal as E on E.real_colaboradorid = A.pres_colaboradorid "
        consulta += "  where labo_naveid = " + idNave.ToString
        consulta += " and (pres_estatus='G' or pres_estatus='F')"
        consulta += " and C.codr_activo=1 "
        consulta += " order by E.real_fecha "

        Return objOperaciones.EjecutaConsulta(consulta)
        ''TERMINA LISTA PRESTAMOS COBRADOS
    End Function

    Public Function ListaCobranzaEditar(ByVal semanaNominaID As Int32, ByVal idNAve As Integer, ByVal colaborador As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  SELECT * FROM Prestamos.Prestamos AS A  "
        consulta += " JOIN Nomina.Colaborador as c on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid "
        consulta += " join Prestamos.PagoPrestamos AS d on d.pagop_prestamoid=a.pres_prestamoid "
        consulta += " WHERE pagop_semananominaid= " + semanaNominaID.ToString
        consulta += " AND (labo_naveid = " + idNAve.ToString + ") "
        consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaCobranzaEditarNegativos(ByVal semanaNominaID As Int32, ByVal idNAve As Integer, ByVal colaboradorid As Integer) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  SELECT * FROM Prestamos.Prestamos AS A  "
        consulta += " JOIN Nomina.Colaborador as c on A.pres_colaboradorid=codr_colaboradorid "
        consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid "
        consulta += " join Prestamos.PagoPrestamos AS d on d.pagop_prestamoid=a.pres_prestamoid "
        consulta += " WHERE pagop_semananominaid= " + semanaNominaID.ToString
        consulta += " AND (labo_naveid = " + idNAve.ToString + ") "
        consulta += "and (labo_colaboradorid=" + colaboradorid.ToString + ")"
        ''consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaboradorid.Replace(" ", "%") + "%'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    ''INICIA GUARDAR ABONOS EXTRAORDINARIOS
    Public Sub AbonosExtraordinarios(ByVal Cobranza As Entidades.CobranzaPrestamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "pagop_prestamoid"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_semananominaid"
        parametro.Value = Cobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_numeropago"
        parametro.Value = Cobranza.PnumPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_abonocapital"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pabono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_interes"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pinteres
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldoanterior"
        parametro.Value = Cobranza.PsaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldonuevo"
        parametro.Value = Cobranza.PSolicitudPrestamo.Psaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_liquidacion"
        parametro.Value = Cobranza.Pliquidacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_usuariomodificoid"
        parametro.Value = Cobranza.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_fechamodificacion"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pfechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoAbono"
        parametro.Value = Cobranza.PTipoAbono
        listaParametros.Add(parametro)


        operaciones.EjecutarSentenciaSP("Prestamos.SP_ABONO_EXTRAORDINARIO", listaParametros)
    End Sub
    Public Sub agregarAbonoExtraoridinario(ByVal idPrestamo As Integer, ByVal idNave As Integer, ByVal abono As Integer, ByVal interes As Integer, ByVal saldo_anterior As Integer, ByVal saldonuevo As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "pagop_prestamoid"
        parametro.Value = idPrestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave_id"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_abonocapital"
        parametro.Value = abono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_interes"
        parametro.Value = interes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldoanterior"
        parametro.Value = saldo_anterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_saldonuevo"
        parametro.Value = saldonuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_usuariomodificoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pagop_extraordinario"
        parametro.Value = 1
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Abono_Extraordinario_Prestamo", listaParametros)
    End Sub


    ''TERMINA GUARDAR ABONOS EXTRAORDINARIOS

    Public Function ListaAbonosExtraordinarios(ByVal semanaNominaID As Int32, ByVal naveid As Integer, ByVal estatus As String, ByVal colaborador As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "  SELECT * FROM Prestamos.Prestamos AS A  "
        consulta += "   JOIN Nomina.Colaborador as c on A.pres_colaboradorid=c.codr_colaboradorid "
        consulta += " join nomina.ColaboradorLaboral as b on pres_colaboradorid= b.labo_colaboradorid "
        consulta += " join Prestamos.PagoPrestamos AS d on d.pagop_prestamoid=a.pres_prestamoid "
        consulta += " JOIN Nomina.ColaboradorReal as E on E.real_colaboradorid = A.pres_colaboradorid"
        consulta += " WHERE pagop_semananominaid =" + semanaNominaID.ToString
        consulta += " and C.codr_activo=1 "
        consulta += " and labo_naveid = " + naveid.ToString
        consulta += " and pagop_dentronomina='" + estatus.ToString + "' "
        consulta += " and (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + colaborador.Replace(" ", "%") + "%'"

        Return objOperaciones.EjecutaConsulta(consulta)
    End Function



    Public Function ValidarAbonosExtraordinarios(ByVal SemanaNomimaID As Int32, ByVal prestamoID As Int32, ByVal Estatus As String) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Prestamos.PagoPrestamos "
        consulta += " WHERE pagop_semananominaid =" + SemanaNomimaID.ToString
        consulta += " and pagop_prestamoid=" + prestamoID.ToString
        consulta += " and pagop_dentronomina='" + Estatus.ToString + "'"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function


    Public Sub EditarAbonosExtraordinarios(ByVal Cobranza As Entidades.CobranzaPrestamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pagop_prestamoid"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_semananominaid"
        parametro.Value = Cobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_abonocapital"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pabono
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_saldoanterior"
        parametro.Value = Cobranza.PsaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_saldonuevo"
        parametro.Value = Cobranza.PSolicitudPrestamo.Psaldo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@TipoAbono"
        parametro.Value = Cobranza.PTipoAbono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Delete"
        parametro.Value = Cobranza.PDelete
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Editar_Abono_Extraordinario", listaParametros)
    End Sub


    Public Sub EditarAbonosExtraordinariosFueraNomina(ByVal Cobranza As Entidades.CobranzaPrestamos)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@pagop_prestamoid"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pprestamoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_semananominaid"
        parametro.Value = Cobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_abonocapital"
        parametro.Value = Cobranza.PSolicitudPrestamo.Pabono
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_saldoanterior"
        parametro.Value = Cobranza.PsaldoAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pagop_saldonuevo"
        parametro.Value = Cobranza.PSolicitudPrestamo.Psaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaLiquidacion"
        parametro.Value = Cobranza.PfechaFinNomina
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@TipoAbono"
        parametro.Value = Cobranza.PTipoAbono
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Liquidacion"
        parametro.Value = Cobranza.Pliquidacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Delete"
        parametro.Value = Cobranza.PDelete
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Prestamos.SP_Editar_Abono_Extraordinario_FueraNomina", listaParametros)
    End Sub

    '' valida si la nave tiene prestamos en estatus entregado nave
    Public Function validarCierreSemanalEstatusEntregado(ByVal idnave As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta = "SELECT * FROM Prestamos.Prestamos p INNER JOIN Nomina.ColaboradorLaboral cl"
        consulta += " on cl.labo_colaboradorid=p.pres_colaboradorid WHERE pres_estatus='E' AND cl.labo_naveid= " + idnave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function guardarDatosReporteConcentradoPrestamos(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_Prestamos_InsertaReporteConcentradoPrestamos]", listaParametros)
    End Function

    Public Function validaPeriodoAnterior(ByVal periodoid As Integer, ByVal naveid As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PeriodoId"
        parametro.Value = periodoid
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_ValidaPeriodoAnteriorCerrado]", listaParametros)
    End Function


End Class

