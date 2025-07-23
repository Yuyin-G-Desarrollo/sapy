Imports Nomina.Datos

Public Class MotivosPrestamoBU

	Public Function listaMotivosPrestamos(ByVal nombre As String, ByVal nave As Int32, ByVal activo As Boolean) As List(Of Entidades.MotivosPrestamo)
		Dim objDA As New Datos.MotivosPrestamoDA
		Dim tabla As New DataTable
		listaMotivosPrestamos = New List(Of Entidades.MotivosPrestamo)
		tabla = objDA.ListaMotivosPrestamos(nombre, nave, activo)
		For Each fila As DataRow In tabla.Rows
			Dim motivo As New Entidades.MotivosPrestamo
			motivo.PMotivoPrestamoId = CInt(fila("mpre_motivoprestamoid"))
			motivo.PNombre = CStr(fila("mpre_nombre"))
			'motivo.PNaveId.PNaveId = CInt(fila("mpre_naveid"))
			motivo.PActivo = CBool(fila("mpre_activo"))


			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))


			motivo.PNaveId = naves


			listaMotivosPrestamos.Add(motivo)

		Next
	End Function
	Public Sub ALtasMPRE(ByVal motivos As Entidades.MotivosPrestamo)
		Dim objMotivosDA As New MotivosPrestamoDA
		objMotivosDA.altasDeMotivos(motivos)
	End Sub

	Public Sub editarmoivos(ByVal motivos As Entidades.MotivosPrestamo)
		Dim objMotivosDA As New MotivosPrestamoDA
		objMotivosDA.editarMotivosPrestamo(motivos)
	End Sub
	Public Function BuscarMotivos(ByVal idmotivos As Int32) As Entidades.MotivosPrestamo

		Dim objMotivoDA As New Datos.MotivosPrestamoDA
		Dim motivo As New Entidades.MotivosPrestamo
		Dim tablaMotivo As New DataTable
		tablaMotivo = objMotivoDA.buscarMotivos(idmotivos)

		For Each fila As DataRow In tablaMotivo.Rows
			motivo.PMotivoPrestamoId = CInt(fila("mpre_motivoprestamoid"))
			motivo.PNombre = CStr(fila("mpre_nombre"))
			motivo.PActivo = CBool(fila("mpre_activo"))

			Dim Naves As New Entidades.Naves

			Naves.PNaveId = CInt(fila("nave_naveid"))
			Naves.PNombre = CStr(fila("nave_nombre"))

			motivo.PNaveId = Naves
		Next

		Return motivo
	End Function

	'Public Function listaPerfilesActivos() As DataTable
	'	Dim objDA As New Datos.PerfilesDA
	'	Return objDA.listaPerfiles("", 0, True)
	'End Function

	'Public Function listaPerfilesDepartamento(ByVal departamentoId As Integer) As DataTable
	'	Dim objDA As New Datos.PerfilesDA
	'	Return objDA.listaPerfiles("", departamentoId, True)
	'End Function

	' ''lista perfiles segun departamento'''
	'Public Function ListaPerfilesSegunDepartamentos(ByVal departamentoid As Integer) As List(Of Entidades.Perfiles)
	'	Dim objDA As New Datos.PerfilesDA
	'	Dim tabla As New DataTable
	'	ListaPerfilesSegunDepartamentos = New List(Of Entidades.Perfiles)
	'	tabla = objDA.ListaPerfilesSegunDepartamento(departamentoid)
	'	For Each fila As DataRow In tabla.Rows
	'		Dim perfil As New Entidades.Perfiles
	'		perfil.PNombre = CStr(fila("perf_nombre"))
	'		perfil.Pperfilid = CInt(fila("perf_perfilid"))
	'		ListaPerfilesSegunDepartamentos.Add(perfil)
	'	Next
    'End Function

    Public Function MotivosNave(ByRef idNave As Integer) As DataTable
        Dim objDA As New Datos.MotivosPrestamoDA
        Return objDA.MotivosPorNave(idNave)
    End Function











End Class






