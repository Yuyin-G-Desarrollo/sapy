Imports System.Data.SqlClient

Public Class ControlDePeriodosDA
	Public Function ListaPeriodosNomina(ByVal Nave As Int32, ByVal FechaI As Date, ByVal fechaF As Date, ByVal fechaseleccionada As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = ("select * FROM Nomina.PeriodosNomina as a JOIN Framework.Naves as  b on (pnom_NaveId = b.nave_naveid)")

		If (Nave > 0) Then
			consulta += " where pnom_naveid =" + Nave.ToString
		End If


		If fechaseleccionada Then
			consulta += "  and  pnom_fechainicial BETWEEN '" + FechaI.Day.ToString + "/" + FechaI.Month.ToString + "/" + FechaI.Year.ToString + " 00:00:01' " + " and '" + fechaF.Day.ToString + "/" + fechaF.Month.ToString + "/" + fechaF.Year.ToString + " 00:00:01' "
		End If

		consulta += " order BY pnom_FechaInicial, pnom_FechaFinal ,pnom_NoSemanaNomina"

		'consulta += "And pnom_stperiodonomina like '%" + Estado + "%'"


		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Function AltaPeriodosNomina(ByVal Nave As Int32, ByVal FechaI As Date, ByVal fechaF As Date, ByVal fechaseleccionada As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = ("select pnom_nosemananomina, pnom_fechainicial, pnom_fechafinal, pnom_stperiodonomina , pnom_stPeriodoCajaAhorro,pnom_stPeriodoAsistencia,  FROM Nomina.PeriodosNomina as a JOIN Framework.Naves as  b on (pnom_NaveId = b.nave_naveid)")



		'Dim consulta As String = ("select  DATEADD(day, +7, pnom_fechainicial)FROM Nomina.PeriodosNomina")

		If (Nave > 0) Then
			consulta += " where pnom_naveid =" + Nave.ToString
		End If


		If fechaseleccionada Then
			consulta += " and pnom_fechainicial='" + FechaI.ToString + "'"
		End If
		If fechaseleccionada Then
			consulta += " and pnom_FechaFinal='" + fechaF.ToString + "'"
		End If
		'consulta += "And pnom_stperiodonomina like '%" + Estado + "%'"


		Return operaciones.EjecutaConsulta(consulta)
	End Function
	Public Function BuscarPeriodoSeleccionado(ByVal idPeriodo As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("select a.*, b.*  FROM Nomina.PeriodosNomina as a JOIN Framework.Naves as  b on (pnom_NaveId = b.nave_naveid) where pnom_PeriodoNomId= " + idPeriodo.ToString)

	End Function

	Public Sub altas(ByVal periodo As Entidades.PeriodosNomina)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "Nave"
		parametro.Value = periodo.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FechaI"
		parametro.Value = periodo.PFechaInicio
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FechaF"
		parametro.Value = periodo.PFechaFin
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Concepto"
		parametro.Value = periodo.PConcepto
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Status"
		parametro.Value = periodo.PEstadoPeriodoDeNomina
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "StAhorro"
		parametro.Value = periodo.pStCajaAhorro
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "StAsistencia"
		parametro.Value = periodo.pAsistencia
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "semana"
		parametro.Value = periodo.PsemanaNomina
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_PeriodosNomina", listaParametros)

	End Sub
	Public Sub EditarPeriodosNomina(ByVal periodo As Entidades.PeriodosNomina)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "periodoID"
		parametro.Value = periodo.PPeriodoId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Nave"
		parametro.Value = periodo.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FechaI"
		parametro.Value = periodo.PFechaInicio
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "FechaF"
		parametro.Value = periodo.PFechaFin
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Concepto"
		parametro.Value = periodo.PConcepto
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "semana"
		parametro.Value = periodo.PsemanaNomina
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)



		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_PeriodosNomina", listaParametros)

	End Sub
	Public Sub eliminarperiodos(ByVal periodos As Int32, ByVal naves As Int32)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)



		Dim valores As New SqlParameter
		valores.ParameterName = "semanas"
		valores.Value = periodos
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "naves"
		valores.Value = naves
		listaValores.Add(valores)



		operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_PeriodosNomina", listaValores)

	End Sub
	Public Function Periodos(ByVal obj As Entidades.PeriodosNomina) As Int32
		Dim consulta As String
		Dim Operaciones As New Persistencia.OperacionesProcedimientos


		'consulta = String.Empty
		'consulta += "Select COUNT(*) Cuenta from Nomina.PeriodosNomina where (pnom_FechaInicial >= '" + Format(obj.PFechaFin, "dd/MM/yyyy").ToString + " 00:00:00" + "' AND pnom_FechaInicial<= '" + Format(obj.PFechaFin, "dd/MM/yyyy").ToString + " 23:59:59" + "' " + vbCrLf
		'consulta += "OR pnom_FechaFinal>='" + Format(obj.PFechaInicio, "dd/MM/yyyy").ToString + " 00:00:00" + "' AND pnom_FechaInicial <= '" + Format(obj.PFechaFin, "dd/MM/yyyy").ToString + " 23:59:59" + "') AND pnom_NaveId= " + obj.PNave.PNaveId.ToString + " " + vbCrLf


		consulta = String.Empty
		consulta += "Select COUNT(*) Cuenta from Nomina.PeriodosNomina where (CONVERT(date, pnom_FechaInicial, 103)<= CONVERT(date, '" + Format(obj.PFechaInicio, "dd/MM/yyyy").ToString + "', 103) AND CONVERT(date, pnom_FechaFinal, 103)>= CONVERT(date, '" + Format(obj.PFechaInicio, "dd/MM/yyyy").ToString + "', 103) " + vbCrLf
		consulta += "OR CONVERT(date, pnom_FechaInicial, 103)<=CONVERT(date,'" + Format(obj.PFechaFin, "dd/MM/yyyy").ToString + "', 103) AND CONVERT(date, pnom_FechaFinal, 103) >= CONVERT(date, '" + Format(obj.PFechaFin, "dd/MM/yyyy").ToString + "', 103)) AND  pnom_NaveId= " + obj.PNave.PNaveId.ToString + " " + vbCrLf


		Periodos = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

	End Function
	Public Function Periodos(ByVal objperiodo As Entidades.PeriodosNomina, ByVal Editar As Boolean) As Int32
		Dim consulta As String
		Dim Operaciones As New Persistencia.OperacionesProcedimientos


		consulta = String.Empty
		consulta += "Select COUNT(*) Cuenta from Nomina.PeriodosNomina where (pnom_FechaInicial >= '" + Format(objperiodo.PFechaFin, "dd/MM/yyyy").ToString + " 00:00:00" + "' AND pnom_FechaInicial<= '" + Format(objperiodo.PFechaFin, "dd/MM/yyyy").ToString + " 23:59:59" + "' " + vbCrLf
		consulta += "OR pnom_FechaFinal>='" + Format(objperiodo.PFechaInicio, "dd/MM/yyyy").ToString + " 00:00:00" + "' AND pnom_FechaFinal <= '" + Format(objperiodo.PFechaFin, "dd/MM/yyyy").ToString + " 23:59:59" + "') AND pnom_NaveId= " + objperiodo.PNave.PNaveId.ToString + " AND caja_cajaahorroid not IN (" + objperiodo.PPeriodoId.ToString + ") " + vbCrLf

		Periodos = Operaciones.EjecutaConsulta(consulta).Rows(0)("Cuenta")

	End Function


    Public Function buscarPeriodoEsActivoAsistencia(ByVal periodoID As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Return operaciones.EjecutaConsulta("SELECT pnom_stPeriodoAsistencia FROM Nomina.PeriodosNomina WHERE pnom_PeriodoNomId = " + periodoID.ToString)

    End Function

    Public Function buscarPeriodoSegunNavesSegunAsistencia(ByVal naveID As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT TOP 52 * FROM Nomina.PeriodosNomina WHERE pnom_NaveId = " + naveID.ToString + " AND (pnom_stPeriodoNomina='A' or pnom_stPeriodoNomina='C') ORDER BY pnom_FechaInicial DESC"
        Return operaciones.EjecutaConsulta(cadena)

    End Function

    Public Function buscarPeriodoSegunNavesSegunAsistenciaAnio(ByVal naveID As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT TOP 52 pnom_PeriodoNomId, pnom_NaveId, pnom_FechaInicial, pnom_FechaFinal, pnom_Concepto FROM Nomina.PeriodosNomina WHERE pnom_NaveId = " + naveID.ToString + " AND (pnom_stPeriodoNomina='A' or pnom_stPeriodoNomina='C') ORDER BY pnom_FechaInicial DESC"
        Return operaciones.EjecutaConsulta(cadena)

    End Function

    Public Function buscarPeriodoSegunNavesSegunAsistenciaControlAsistencia(ByVal naveID As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Return operaciones.EjecutaConsulta("SELECT * FROM Nomina.PeriodosNomina WHERE pnom_NaveId = " + naveID.ToString +
                                           "ORDER BY pnom_FechaInicial DESC")

    End Function

    Public Function buscarPeriodoSegunNaves_Top10(ByVal naveID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta += " " +
                    " SELECT" +
                    "  	TOP 10 *" +
                    " FROM Nomina.PeriodosNomina" +
                    " WHERE pnom_PeriodoNomId <= ( " +
                    "                               SELECT " +
                    "                                   pnom_PeriodoNomId" +
                    "                               FROM Nomina.PeriodosNomina" +
                    "                               WHERE pnom_NaveId = " + naveID.ToString +
                    "                               AND GETDATE() BETWEEN pnom_FechaInicial AND CONVERT(datetime, pnom_FechaFinal+ ' 23:59:50')" +
                    "                            )" +
                    " AND pnom_NaveId = " + naveID.ToString +
                    " ORDER BY pnom_FechaInicial DESC"


        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarPeriodoSegunNaves_PeriodoActual_Hacia_Atras(ByVal naveID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta += " " +
                    " SELECT" +
                    "  	*" +
                    " FROM Nomina.PeriodosNomina" +
                    " WHERE pnom_PeriodoNomId <= ( " +
                    "                               SELECT " +
                    "                                   pnom_PeriodoNomId" +
                    "                               FROM Nomina.PeriodosNomina" +
                    "                               WHERE pnom_NaveId = " + naveID.ToString +
                    "                               AND GETDATE() BETWEEN pnom_FechaInicial AND CONVERT(datetime, pnom_FechaFinal+ ' 23:59:50')" +
                    "                            )" +
                    " AND pnom_NaveId = " + naveID.ToString +
                    " ORDER BY pnom_FechaInicial DESC"


        Return operaciones.EjecutaConsulta(consulta)

    End Function
    Public Function periodoSegunNaveSegunAsistenciaActual(ByVal naveId As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Return operaciones.EjecutaConsulta("SELECT pnom_PeriodoNomId FROM Nomina.PeriodosNomina WHERE pnom_NaveId = " + naveId.ToString + " AND pnom_stPeriodoNomina = 'A'")

    End Function

    Public Function buscarRangoPeriodoSegunNavesSegunAsistencia(ByVal periodoNomID As Int32) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Return operaciones.EjecutaConsulta("SELECT pnom_FechaInicial, pnom_FechaFinal FROM Nomina.PeriodosNomina WHERE pnom_PeriodoNomId = " + periodoNomID.ToString)

    End Function

    Public Function ListarPeriodosdeNomina(ByVal IdCajaAhorro As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        'Dim procedimiento As String = String.Empty

        'procedimiento = "cajaahorro.SP_EstatusCajaAhorro"

        ListarPeriodosdeNomina = New DataTable
        ListarPeriodosdeNomina = Operaciones.EjecutaConsulta("select pnom_periodonomid, pnom_concepto FROM Nomina.periodosnomina where pnom_periodonomid IN (SELECT DISTINCT ccpc_periodoid from cajaahorro.colaboradorperiodocaja WHERE ccpc_cajaahorroid= " + IdCajaAhorro.ToString + " )")

    End Function

End Class
