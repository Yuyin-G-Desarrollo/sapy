Imports Nomina.Datos

Public Class HorariosBU
	Public Function listaHorariosActivos() As DataTable
		Dim objDA As New Datos.HorariosDA
		Return objDA.listaHorariosActivos()
    End Function

    Public Function listaHorariosSegunNave(ByVal NaveId As Int32) As DataTable
        Dim objDA As New Datos.HorariosDA
        Return objDA.listaHorariosSegunNave(NaveId)
    End Function

    Public Function listaHorariosTabla(ByVal nave As Integer, ByVal activo As Boolean) As DataTable

        Dim objDA As New Datos.HorariosDA

        Return objDA.lista_Horarios(nave, activo)

    End Function

    'Public Function listaHorarios(ByVal nombre As String, ByVal Nave As Int32, ByVal activo As Boolean) As List(Of Entidades.Horarios)
    '	Dim objDA As New Datos.HorariosDA
    '	Dim tabla As New DataTable
    '	listaHorarios = New List(Of Entidades.Horarios)
    '	tabla = objDA.listaHorarios(nombre, nave, activo)
    '	For Each fila As DataRow In tabla.Rows
    '		Dim horario As New Entidades.Horarios
    '		horario.DHorariosid = CInt(fila("hora_horarioid"))
    '		horario.DNombre = CStr(fila("hora_nombre"))
    '		horario.DActivo = CBool(fila("hora_activo"))

    '		Dim Naves As New Entidades.Naves

    '		Naves.PNaveId = CInt(fila("nave_naveid"))
    '		Naves.PNombre = CStr(fila("nave_nombre"))

    '		horario.PNaves = Naves

    '		listaHorarios.Add(horario)
    '	Next
    'End Function

    Public Function listaHorarios(ByVal Nave As Int32, ByVal activo As Boolean) As List(Of Entidades.Horarios)

        Dim objDA As New Datos.HorariosDA
        Dim tabla As New DataTable
        listaHorarios = New List(Of Entidades.Horarios)
        'tabla = objDA.listaHorarios(nombre, Nave, activo)
        tabla = objDA.lista_Horarios(Nave, activo)
        For Each fila As DataRow In tabla.Rows
            Dim horario As New Entidades.Horarios
            horario.DHorariosid = CInt(fila("hora_horarioid"))
            horario.DNombre = CStr(fila("hora_nombre"))
            horario.DActivo = CBool(fila("hora_activo"))

            If IsDBNull(fila("hora_retardo")) Then
                horario.DRetardo = 0
            Else
                horario.DRetardo = CInt(fila("hora_retardo"))
            End If

            Dim Naves As New Entidades.Naves

            Naves.PNaveId = CInt(fila("nave_naveid"))
            Naves.PNombre = CStr(fila("nave_nombre"))

            horario.PNaves = Naves

            listaHorarios.Add(horario)

        Next

    End Function

	Public Sub editarHorarios(ByVal Horario As Entidades.Horarios)
		Dim objHorariosDA As New HorariosDA
		objHorariosDA.editarHorarios(Horario)

	End Sub
	Public Sub guardarHorarios(ByVal horario As Entidades.Horarios)
		Dim objHorario As New HorariosDA
		objHorario.guardarhorarios(horario)
	End Sub

	Public Sub altashorarios(ByVal horarios As Entidades.Horarios)
		Dim objaltashorarios As New HorariosDA
		objaltashorarios.Altashorarios(horarios)
	End Sub


	Public Function buscarHorario(ByVal horariosid As Int32) As Entidades.Horarios

		Dim objHorariosDA As New Datos.HorariosDA
		Dim horario As New Entidades.Horarios
		Dim tablaHorarios As New DataTable
		tablaHorarios = objHorariosDA.buscarHorarios(horariosid)

		For Each fila As DataRow In tablaHorarios.Rows

			horario.DHorariosid = CInt(fila("hora_horarioid"))
			horario.DNombre = CStr(fila("hora_nombre"))
			horario.DActivo = CBool(fila("hora_activo"))

			Dim Naves As New Entidades.Naves

			Naves.PNaveId = CInt(fila("nave_naveid"))
			Naves.PNombre = CStr(fila("nave_nombre"))

			horario.PNaves = Naves


		Next

		Return horario
	End Function

	Public Function buscarHorarioId() As Int32
		Dim objDA As New Datos.HorariosDA
		buscarHorarioId = 0
		Dim tabla As New DataTable
		tabla = objDA.buscarHorarioId
		For Each fila As DataRow In tabla.Rows
			buscarHorarioId = CInt(fila(0))
		Next
		Return buscarHorarioId
	End Function
End Class
