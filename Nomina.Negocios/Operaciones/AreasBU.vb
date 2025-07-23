Imports Nomina.Datos
Imports Entidades

Public Class AreasBU
	Public Function listaAreas(ByVal Nombre As String, ByVal Nave As Int32, ByVal Activo As Boolean) As List(Of Entidades.Areas)
		Dim objDA As New Datos.AreasDA
		Dim tabla As New DataTable
		listaAreas = New List(Of Entidades.Areas)
		tabla = objDA.ListaAreas(Nombre, Nave, Activo)
		For Each fila As DataRow In tabla.Rows
			Dim area As New Entidades.Areas
			area.PAreaid = CInt(fila("area_areaid"))
			area.PNombre = CStr(fila("area_nombre"))
			'motivo.PNaveId.PNaveId = CInt(fila("mpre_naveid"))
			area.PActivo = CBool(fila("area_activo"))


			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))
			naves.PActivo = CBool(fila("nave_activo"))

			area.PNave = naves

			'Dim grupo As New Entidades.Departamentos

			'grupo.Ddepartamentoid = CInt(fila("grup_grupoid"))
			'grupo.DNombre = CStr(fila("grup_name"))
			'grupo.DActivo = CBool(fila("grup_activo"))

			'area.PDepartamento = grupo

			listaAreas.Add(area)

		Next
	End Function
	Public Function guardar(ByVal area As Entidades.Areas) As String
		guardar = ""
		Dim objareaDA As New AreasDA
		'consulta que evita datos duplicados
		Dim tabla As New DataTable
		tabla = objareaDA.ListaAreas(area.PNombre, area.PNave.PNaveId, area.PActivo)

		If (tabla.Rows.Count) <= 0 Then
			objareaDA.Altas(area)
		Else
			guardar = ("Ya existe el área para la nave seleccionada ")
		End If

		Return guardar
	End Function
	Public Sub editarAreas(ByVal area As Entidades.Areas)
		Dim objDA As New AreasDA
		objDA.editarAreas(area)
	End Sub

	Public Function buscar(ByVal areaid As Int32) As Entidades.Areas
		Dim objareaDA As New Datos.AreasDA
		Dim areass As New Entidades.Areas
		Dim tablaareas As New DataTable
		tablaareas = objareaDA.buscarAreas(areaid)

		For Each fila As DataRow In tablaareas.Rows
			areass.PAreaid = CInt(fila("area_areaid"))
			areass.PNombre = CStr(fila("area_nombre"))
			areass.PActivo = CBool(fila("area_activo"))

			'Dim grupo As New Departamentos

			'grupo.Ddepartamentoid = CInt(fila("grup_grupoid"))
			'grupo.DNombre = CStr(fila("grup_name"))
			'grupo.DActivo = CBool(fila("grup_activo"))

			'areass.PDepartamento = grupo

			Dim nave As New Naves
			nave.PNaveId = CInt(fila("nave_naveid"))
			nave.PNombre = CStr(fila("nave_nombre"))
			nave.PActivo = CBool(fila("nave_activo"))
			areass.PNave = nave
		Next

		Return areass
	End Function


	Public Function listaAreasSegunNave(ByVal IDNave As Int32) As DataTable
		Dim ObjDA As New Datos.AreasDA
		Return ObjDA.listaAreasSegunNave(IDNave)
    End Function


	' ''Public Sub guardar(ByVal area As Entidades.Areas)
	' ''	Dim objDA As New AreasDA
	' ''	objDA.Altas(area)
	' ''End Sub

End Class
