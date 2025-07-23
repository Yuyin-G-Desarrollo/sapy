Imports System.Data.SqlClient

Public Class ConsultaPrestamosDA

    Public Function ListaPagos(ByVal IDColaborador As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select * from Prestamos.Prestamos left join Prestamos.PagoPrestamos on (pres_prestamoid = pagop_prestamoid) where pres_colaboradorid=" + IDColaborador.ToString + "and pres_estatus='G'"
        Return Operaciones.EjecutaConsulta(Consulta)
    End Function
    Public Function ListaPagosPrestamo(ByVal IDColaborador As Int32, ByVal idPrestamo As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@idColaborador"
        parametro.Value = IDColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idPrestamo"
        parametro.Value = idPrestamo
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Prestamos].[SP_Consulta_PagosPrestamo]", listaParametros)

        'Dim Operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "select * from Prestamos.Prestamos left join Prestamos.PagoPrestamos on (pres_prestamoid = pagop_prestamoid) left JOIN Nomina.PeriodosNomina ON(pagop_semananominaid = pnom_PeriodoNomId) where pres_colaboradorid=" + IDColaborador.ToString + "and pres_prestamoid = " + idPrestamo.ToString
        'Return Operaciones.EjecutaConsulta(Consulta)


    End Function

    Public Function CalculoIntereses(ByVal IDCOlaborador As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = "select pres_interes, pres_semanas,pres_estatus, pres_tipointeres, pres_interesautorizado,pres_tipointeresautorizado, pres_totalintereses from Prestamos.Prestamos where pres_colaboradorid=" + IDCOlaborador.ToString
        Return Operaciones.EjecutaConsulta(Consulta)
    End Function
    Public Function obtenerInteresSobrePrestamos(ByVal IDColaborador As Integer, ByVal IdPrestamos As Integer) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        'Dim Consulta As String = "SELECT DISTINCT(pres_interes) pres_interes , pres_tipointeresautorizado FROM Prestamos.Prestamos where pres_colaboradorid=" + IDColaborador.ToString + " AND pres_prestamoid = " + IdPrestamos.ToString
        Dim Consulta As String = "SELECT DISTINCT(pres_interes) pres_interes , pres_tipointeresautorizado,isnull(pres_pagosSemanaQuincenal,0) pres_pagosSemanaQuincenal FROM Prestamos.Prestamos where pres_colaboradorid=" + IDColaborador.ToString + " AND pres_prestamoid = " + IdPrestamos.ToString
        Return Operaciones.EjecutaConsulta(Consulta)
    End Function
    Public Function SemenaNominaActiva(ByVal Naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select pnom_PeriodoNomId from Nomina.PeriodosNomina where pnom_stPeriodoNomina = 'A' and pnom_NaveId=" + Naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ActualizarInteresPrestamo(ByVal IDColaborador As Int32, ByVal idPrestamo As Integer, ByVal Interes As Double) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@pres_colaboradorid"
        parametro.Value = IDColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pres_prestamoid"
        parametro.Value = idPrestamo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pres_intereses"
        parametro.Value = Interes
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("[Prestamos].[SP_Actualizar_InteresPrestamo]", listaParametros)
    End Function


    Public Function ImprimirConcentradoAbonosExtraordinarios(ByVal FechaInicio As Date, ByVal FechaFin As Date, NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Prestamos].[SP_ObtieneReporte_AbonosExtraordinarios]", listaParametros)

    End Function


    Public Function ImprimirReporteConcentradoPrestamoseIntereses(ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_Prestamos_ConsultaReporteConcentradoPrestamos]", listaParametros)

    End Function

    Public Function ImprimirReportePrestamosIntereses(ByVal NaveID As Integer, ByVal CajaId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CajaId"
        parametro.Value = CajaId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_Prestamos_ConsultaReporteReportePrestamosIntereses]", listaParametros)

    End Function

    Public Function ObtenerNaves() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT DISTINCT N.nave_naveid NaveID, N.nave_nombre Nave FROM Framework.Naves N JOIN Nomina.PeriodosNomina P ON N.nave_naveid = P.pnom_NaveId  WHERE nave_activo=1 ORDER BY nave_nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function InsertarConfPrestamosEspeciales(ByVal Concepto As String, ByVal NaveID As Integer, ByVal UsuarioID As Integer, ByVal Accion As Integer, ByVal ConceptoID As Integer, ByVal Activo As Integer, ByVal PorcentajeCC As Integer, ByVal Semanas As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Concepto", Concepto)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ConceptoID", ConceptoID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Activo", Activo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PorcentajeCC", PorcentajeCC)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semanas", Semanas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarSentenciaSP("[Nomina].[SP_Prestamos_AltaEdicionConfPrestamosEspeciales]", listaParametros)

    End Function

    Public Function MostrarConfiguracionPorNave(ByVal NaveID As Integer, ByVal Activo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Activo", Activo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Nomina].[SP_Prestamos_ConfiguracionPrestamosEspeciales]", listaParametros)

    End Function

    Public Function CargarConfConcepto(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim consulta As String

        consulta = "SELECT presespconf_ConceptoID ConceptoID, presespconf_Concepto Concepto  FROM Nomina.Configuracion_ConceptoPrestamosEspeciales WHERE presespconf_estatus=1 AND presespconf_NaveID =" + NaveID.ToString + "ORDER BY presespconf_Concepto "

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerSaldosPrestamosExtraordinariosCaja(ByVal idCajaAhorro As Int32, ByVal idNave As Int32) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter

            parametro.ParameterName = "@NaveID"
            parametro.Value = idNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CajaId"
            parametro.Value = idCajaAhorro
            listaParametros.Add(parametro)



            Return operacion.EjecutarConsultaSP("Nomina.SP_Prestamos_ConsultaPrestamosInteresesExtraordinariosDeCaja", listaParametros)

        Catch ex As Exception

        End Try

    End Function

    Public Function ConsultarAbonosExtraordinarios(ByVal idNave As Int32, ByVal idCajaAhorro As Int32) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter

            parametro.ParameterName = "@NaveID"
            parametro.Value = idNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CajaId"
            parametro.Value = idCajaAhorro
            listaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("Nomina.SP_Prestamos_ConsultaAbonosPrestamoExtraordinarioCaja", listaParametros)
        Catch ex As Exception

        End Try


    End Function

    Public Function obtenerSaldosCierreCaja(ByVal idCajaAhorro As Int32, ByVal idNave As Int32) As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter

            parametro.ParameterName = "@NaveID"
            parametro.Value = idNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CajaId"
            parametro.Value = idCajaAhorro
            listaParametros.Add(parametro)



            Return operacion.EjecutarConsultaSP("Nomina.SP_Prestamos_ConsultaPrestamosInteresesExtraordinariosDeCaja_AntesdeCierreNomina", listaParametros)

        Catch ex As Exception

        End Try

    End Function




End Class
