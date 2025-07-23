Imports Framework.Datos
Imports Entidades

Public Class puestosBU


	Public Function listaPuestos(ByVal nombre As String, ByVal navesid As Int32, ByVal departamento As Int32, ByVal activo As Boolean, ByVal Area As Int32) As List(Of Entidades.Puestos)
		Dim objDA As New Datos.PuestosDA
		Dim tabla As New DataTable
		listaPuestos = New List(Of Puestos)
		tabla = objDA.ListaPuestos(nombre, navesid, departamento, activo, Area)
		For Each fila As DataRow In tabla.Rows
			Dim puesto As New Entidades.Puestos
			puesto.Ppuestosid = CInt(fila("pues_puestoid"))
			puesto.PNombre = CStr(fila("pues_nombre"))
			puesto.PActivo = CBool(fila("pues_activo"))

			Dim grupo As New Departamentos

			grupo.Ddepartamentoid = CInt(fila("grup_grupoid"))
			grupo.DNombre = CStr(fila("grup_name"))
			grupo.DActivo = CBool(fila("grup_activo"))

			puesto.PDepartamento = grupo

			Dim nave As New Naves

			nave.PNaveId = CInt(fila("nave_naveid"))
			nave.PNombre = CStr(fila("nave_nombre"))
			nave.PActivo = CBool(fila("nave_activo"))

			puesto.PNave = nave

			Dim areas As New Areas

			areas.PAreaid = CInt(fila("area_areaid"))
			areas.PNombre = CStr(fila("area_nombre"))
			areas.PActivo = CBool(fila("area_activo"))

            puesto.Pareas = areas
            If IsDBNull(fila("pues_orden")) Then
                puesto.POrden = 0
            Else
                puesto.POrden = CInt(fila("pues_orden"))
            End If

            listaPuestos.Add(puesto)
        Next
	End Function


	Public Sub guardarpuesto(ByVal puesto As Entidades.Puestos)
		Dim objpuestosDA As New PuestosDA
		objpuestosDA.guardarPuestos(puesto)
	End Sub

	Public Sub editarPuestos(ByVal puesto As Entidades.Puestos)
		Dim objpuestoDA As New PuestosDA
		objpuestoDA.editarPuestos(puesto)
	End Sub

	Public Function buscarPuesto(ByVal puestoid As Int32) As Entidades.Puestos
		Dim objPuestoDA As New Datos.PuestosDA
		Dim puesto As New Entidades.Puestos
		Dim tablaPuesto As New DataTable
		tablaPuesto = objPuestoDA.buscarPuesto(puestoid)

		For Each fila As DataRow In tablaPuesto.Rows
			puesto.Ppuestosid = CInt(fila("pues_puestoid"))
			puesto.PNombre = CStr(fila("pues_nombre"))
			puesto.PActivo = CBool(fila("pues_activo"))

			Dim grupo As New Departamentos

			grupo.Ddepartamentoid = CInt(fila("grup_grupoid"))
			grupo.DNombre = CStr(fila("grup_name"))
			grupo.DActivo = CBool(fila("grup_activo"))

			puesto.PDepartamento = grupo

			Dim nave As New Naves
			nave.PNaveId = CInt(fila("nave_naveid"))
			nave.PNombre = CStr(fila("nave_nombre"))
			nave.PActivo = CBool(fila("nave_activo"))
            puesto.PNave = nave
            If IsDBNull(fila("pues_orden")) Then
                puesto.POrden = 0
            Else
                puesto.POrden = CInt(fila("pues_orden"))
            End If
		Next

		Return puesto
	End Function

	Public Function listaPuestosActivos() As DataTable
		Dim objDA As New Datos.PuestosDA
        Return objDA.ListaPuestos()
    End Function


    Public Function listaPuestosSegunDepartamento(ByVal IdDepartemento As Int32) As DataTable
        Dim objDA As New Datos.PuestosDA
        listaPuestosSegunDepartamento = objDA.ListaPuestoSegunDepartamento(IdDepartemento)
        Return listaPuestosSegunDepartamento
    End Function


	Public Function listaPuestosNaves(ByVal Naveid As Integer, ByVal departamento As Int32, ByVal Area As Int32) As DataTable
		Dim objDA As New Datos.PuestosDA
		Return objDA.ListaPuestos("", Naveid, departamento, True, Area)
	End Function
End Class
