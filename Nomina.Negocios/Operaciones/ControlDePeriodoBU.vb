Imports Nomina.Datos

Public Class ControlDePeriodoBU
	Private pResultado As String = String.Empty

	Public Property Resultado As String
		Get
			Return pResultado
		End Get
		Set(ByVal value As String)
			pResultado = value
		End Set
	End Property
	Public Function ListaPeriodosDeNomina(ByVal Nave As Int32, ByVal FechaI As Date, ByVal fechaF As Date, ByVal fechaseleccionada As Boolean) As List(Of Entidades.PeriodosNomina)
		Dim objDA As New Datos.ControlDePeriodosDA
		Dim tabla As New DataTable
		ListaPeriodosDeNomina = New List(Of Entidades.PeriodosNomina)
		tabla = objDA.ListaPeriodosNomina(Nave, FechaI.ToString("yyyy-MM-dd"), fechaF.ToString("yyyy-MM-dd"), fechaseleccionada)
		For Each fila As DataRow In tabla.Rows
			Dim exe As New Entidades.PeriodosNomina
			exe.PeriodoId = CInt(fila("pnom_PeriodoNomId"))
			exe.PFechaInicio = CStr(fila("pnom_FechaInicial"))
			exe.FechaFin = CStr(fila("pnom_FechaFinal"))
			exe.EstadoPeriodoNomina = CStr(fila("pnom_stPeriodoNomina"))
			exe.PsemanaNomina = CInt(fila("pnom_nosemananomina"))
			exe.Asistencia = CStr(fila("pnom_stPeriodoAsistencia"))
			exe.StCajaAhorro = CStr(fila("pnom_stPeriodoCajaAhorro"))
			exe.PConcepto = CStr(fila("pnom_Concepto"))


			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))


			exe.PNave = naves


			ListaPeriodosDeNomina.Add(exe)

		Next
	End Function
	Public Function AltasPeriodosDeNomina(ByVal Nave As Int32, ByVal FechaI As Date, ByVal fechaF As Date, ByVal fechaseleccionada As Boolean) As List(Of Entidades.PeriodosNomina)
		Dim objDA As New Datos.ControlDePeriodosDA
		Dim tabla As New DataTable
		AltasPeriodosDeNomina = New List(Of Entidades.PeriodosNomina)
		tabla = objDA.ListaPeriodosNomina(Nave, FechaI.ToString("yyyy-MM-dd"), fechaF.ToString("yyyy-MM-dd"), fechaseleccionada)
		For Each fila As DataRow In tabla.Rows
			Dim exe As New Entidades.PeriodosNomina
			exe.PeriodoId = CInt(fila("pnom_PeriodoNomId"))
			exe.PFechaInicio = CStr(fila("pnom_FechaInicial"))
			exe.FechaFin = CStr(fila("pnom_fechafinal"))
			exe.EstadoPeriodoNomina = CStr(fila("pnom_stPeriodoNomina"))
			exe.PsemanaNomina = CInt(fila("pnom_nosemananomina"))
			exe.Asistencia = CStr(fila("pnom_stPeriodoAsistencia"))
			exe.StCajaAhorro = CStr(fila("pnom_stPeriodoCajaAhorro"))
			exe.PConcepto = CStr(fila("pnom_Concepto"))

			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))


			exe.PNave = naves


			AltasPeriodosDeNomina.Add(exe)

		Next
	End Function
	Public Function BuscarPeridosSeleccionados(ByVal idPeriodos As Int32) As Entidades.PeriodosNomina


		Dim objDA As New Datos.ControlDePeriodosDA
		Dim periodos As New Entidades.PeriodosNomina
		Dim tabla As New DataTable
		tabla = objDA.BuscarPeriodoSeleccionado(idPeriodos)
		For Each fila As DataRow In tabla.Rows
			periodos.PeriodoId = CInt(fila("pnom_PeriodoNomId"))
			periodos.PConcepto = CStr(fila("pnom_concepto"))
			periodos.PFechaInicio = CStr(fila("pnom_FechaInicial"))
			periodos.FechaFin = CStr(fila("pnom_fechafinal"))
			periodos.EstadoPeriodoNomina = CStr(fila("pnom_stPeriodoNomina"))
			periodos.PsemanaNomina = CInt(fila("pnom_nosemananomina"))
			periodos.Asistencia = CStr(fila("pnom_stPeriodoAsistencia"))
			periodos.StCajaAhorro = CStr(fila("pnom_stPeriodoCajaAhorro"))
			periodos.PConcepto = CStr(fila("pnom_Concepto"))



			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))


			periodos.PNave = naves


		Next

		Return periodos
	End Function
	Public Sub Alta(ByVal periodo As Entidades.PeriodosNomina)
		'Resultado = VerificaPeriodo(periodo)

		'If Resultado.Length = 0 Then
		Dim objperiodo As New ControlDePeriodosDA
		objperiodo.altas(periodo)
		'End If
	End Sub
	Public Sub editarPeriodosNomina(ByVal periodo As Entidades.PeriodosNomina)
		Dim objperiodo As New ControlDePeriodosDA
		objperiodo.EditarPeriodosNomina(periodo)

	End Sub
	Public Sub eliminarPer(ByVal semanas As Int32, ByVal naves As Int32)
		Dim objperDA As New ControlDePeriodosDA
		objperDA.eliminarperiodos(semanas, naves)
	End Sub
	Public Function VerificaPeriodo(ByVal objperiodo As Entidades.PeriodosNomina) As String

		Dim objDA As New Nomina.Datos.ControlDePeriodosDA

		VerificaPeriodo = ""
		Resultado = ""
		If objDA.Periodos(objperiodo) > 0 Then
			VerificaPeriodo += "El Periodo de nomina coincide con un rango anterior"
			Resultado += "El Periodo de nomina coincide con un rango anterior"
		End If

	End Function

	Public Function VerificaPeriodo(ByVal periodo As Entidades.PeriodosNomina, ByVal Editar As Boolean) As String

		Dim objCajaAhorroDA As New Nomina.Datos.ControlDePeriodosDA

		VerificaPeriodo = ""

		If objCajaAhorroDA.Periodos(periodo, Editar) > 0 Then
			VerificaPeriodo += "El rango introducido coincide con algun rango previo, verifique la informacion."
		End If
    End Function

    Public Function buscarPeriodoEsActivoAsistencia(ByVal periodoID As Integer) As Boolean


        Dim objDA As New Datos.ControlDePeriodosDA
        Dim tabla As New DataTable

        tabla = objDA.buscarPeriodoEsActivoAsistencia(periodoID)

        For Each fila As DataRow In tabla.Rows

            If fila(0).ToString <> "C" Then

                Return True

            Else

                Return False

            End If

        Next

        Return False

    End Function


    Public Function buscarPeriodoSegunNaveSegunAsistencia(ByVal naveID As Integer) As DataTable

        Dim objDA As New Datos.ControlDePeriodosDA
        Return objDA.buscarPeriodoSegunNavesSegunAsistencia(naveID)

    End Function

    Public Function buscarPeriodoSegunNavesSegunAsistenciaAnio(ByVal naveID As Int32) As DataTable
        Dim objDA As New Datos.ControlDePeriodosDA
        Return objDA.buscarPeriodoSegunNavesSegunAsistenciaAnio(naveID)
    End Function

    Public Function buscarPeriodoSegunNaveSegunAsistenciaControlAsistencia(ByVal naveID As Integer) As DataTable

        Dim objDA As New Datos.ControlDePeriodosDA
        Return objDA.buscarPeriodoSegunNavesSegunAsistenciaControlAsistencia(naveID)

    End Function

    Public Function buscarPeriodoSegunNaves_Top10(ByVal naveID As Integer) As DataTable

        Dim objDA As New Datos.ControlDePeriodosDA
        Return objDA.buscarPeriodoSegunNaves_Top10(naveID)

    End Function

    Public Function buscarPeriodoSegunNaves_PeriodoActual_Hacia_Atras(ByVal naveID As Integer) As DataTable

        Dim objDA As New Datos.ControlDePeriodosDA
        Return objDA.buscarPeriodoSegunNaves_PeriodoActual_Hacia_Atras(naveID)

    End Function

    Public Function periodoSegunNaveSegunAsistenciaActual(ByVal naveId As Integer) As DataTable

        Dim objDA As New Datos.ControlDePeriodosDA
        Return objDA.periodoSegunNaveSegunAsistenciaActual(naveId)

    End Function

    Public Function buscarRangosPeriodoSegunNaveSegunAsistencia(ByVal periodoNomID As Integer) As Entidades.PeriodosNomina


        Dim objDA As New Datos.ControlDePeriodosDA
        Dim periodos As New Entidades.PeriodosNomina
        Dim tabla As New DataTable
        tabla = objDA.buscarRangoPeriodoSegunNavesSegunAsistencia(periodoNomID)
        For Each fila As DataRow In tabla.Rows
            'periodos.PeriodoId = CInt(fila("pnom_PeriodoNomId"))
            periodos.PFechaInicio = CStr(fila("pnom_FechaInicial"))
            periodos.FechaFin = CStr(fila("pnom_fechafinal"))

            'Dim naves As New Entidades.Naves

            'naves.PNaveId = CInt(fila("nave_naveid"))
            'naves.PNombre = CStr(fila("nave_nombre"))

            'periodos.PNave = naves

        Next

        Return periodos

    End Function

    Public Function ListarPeriodosdeNomina(ByVal IdCajaAhorro As Int32) As DataTable
        ListarPeriodosdeNomina = New DataTable

        Dim objControldePeriodosDA = New Nomina.Datos.ControlDePeriodosDA

        ListarPeriodosdeNomina = objControldePeriodosDA.ListarPeriodosdeNomina(IdcajaAhorro)

    End Function

End Class
