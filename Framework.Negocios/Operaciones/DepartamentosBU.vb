Imports Framework.Datos

Public Class DepartamentosBU
    Public Function listaDepartamentosActivos() As DataTable
        Dim objDA As New Datos.DepartamentosDA
        Return objDA.listaDepartamentosActivos()
    End Function
	Public Function listaDepartamentos(ByVal nombre As String, ByVal activo As Boolean, ByVal Naves As Integer, ByVal areas As Int32) As List(Of Entidades.Departamentos)
		Dim objDA As New Datos.DepartamentosDA
		Dim tabla As New DataTable

		listaDepartamentos = New List(Of Entidades.Departamentos)

		tabla = objDA.listaDepartamentos(nombre, activo, Naves, areas)
		For Each fila As DataRow In tabla.Rows
			Dim departamento As New Entidades.Departamentos

			departamento.Ddepartamentoid = CInt(fila("grup_grupoid"))
			departamento.DNombre = CStr(fila("grup_name"))
			departamento.DActivo = CBool(fila("grup_activo"))

			Dim nave As New Entidades.Naves
			nave.PNaveId = CInt(fila("nave_naveid"))
			nave.PNombre = CStr(fila("nave_nombre"))
			departamento.PNave = nave


			Dim area As New Entidades.Areas
			area.PAreaid = CInt(fila("area_areaid"))
			area.PNombre = CStr(fila("area_nombre"))
			area.PActivo = CBool(fila("area_activo"))

			departamento.DAreas = area

			listaDepartamentos.Add(departamento)
		Next
	End Function

    Public Sub editarDepartamento(ByVal Departamento As Entidades.Departamentos)
        Dim objDepartamentosDA As New DepartamentosDA
        objDepartamentosDA.editarDepartamento(Departamento)

    End Sub

    Public Sub guardarDepartamento(ByVal Departamento As Entidades.Departamentos)
        Dim objDepartamento As New DepartamentosDA
        objDepartamento.guardarDepartamento(Departamento)
    End Sub
    Public Function buscarDepartamento(ByVal departamentoid As Int32) As Entidades.Departamentos

        Dim objDepartamentoDA As New Datos.DepartamentosDA
        Dim departamento As New Entidades.Departamentos
        Dim tablaDepartamento As New DataTable
        tablaDepartamento = objDepartamentoDA.buscarDepartamento(departamentoid)

        For Each fila As DataRow In tablaDepartamento.Rows
            departamento.DNombre = CStr(fila("grup_name"))
            departamento.DActivo = CBool(fila("grup_activo"))
			departamento.Ddepartamentoid = CInt(fila("grup_grupoid"))

			Dim nave As New Entidades.Naves
			nave.PNaveId = CInt(fila("nave_naveid"))
			nave.PNombre = CStr(fila("nave_nombre"))
			departamento.PNave = nave

			Dim area As New Entidades.Areas
			area.PAreaid = CInt(fila("area_areaid"))
			area.PNombre = CStr(fila("area_nombre"))
			area.PActivo = CBool(fila("area_activo"))

			departamento.DAreas = area

        Next

        Return departamento
    End Function

    Public Function listaDepartamentosPorNavesUsuario(ByVal usuarioid As Int32) As DataTable
        Dim objDA As New Datos.DepartamentosDA
        Return objDA.listaDepartamentosPorNavesUsuario(usuarioid)
    End Function


    Public Function listaDepartamentosSegunNave(ByVal IDNave As Int32) As DataTable
        Dim ObjDA As New Datos.DepartamentosDA
        Return ObjDA.listaDepartamentosSegunNave(IDNave)
    End Function

	Public Function listaDepartamentosSegunArea(ByVal IDArea As Int32) As DataTable
		Dim ObjDA As New Datos.DepartamentosDA
		Return ObjDA.listaDepartamentosSegunArea(IDArea)
	End Function

	Public Function ListaDepartamentosSegunPerfiles(ByVal nombre As String, ByVal idperfil As Integer) As List(Of Entidades.Departamentos)
		Dim objDA As New Datos.DepartamentosDA
		Dim tabla As New DataTable
		ListaDepartamentosSegunPerfiles = New List(Of Entidades.Departamentos)
		tabla = objDA.ListaDepartamentossegunperfiles(nombre, idperfil)
		For Each fila As DataRow In tabla.Rows
			Dim deptop As New Entidades.Departamentos
			deptop.DNombre = CStr(fila("grup_name"))
			deptop.Ddepartamentoid = CInt(fila("grup_grupoid"))
			ListaDepartamentosSegunPerfiles.Add(deptop)
		Next
	End Function
End Class
