Imports Nomina.Datos
Imports Entidades

Public Class CelulasBU

	Public Function listaCelulas(ByVal nombre As String, ByVal nave As Int32, ByVal departamento As Int32, ByVal activo As Boolean) As List(Of Entidades.Celulas)
		Dim objDA As New Datos.CelulasDA
		Dim tabla As New DataTable
		listaCelulas = New List(Of Entidades.Celulas)
		tabla = objDA.listaCelulas(nombre, nave, departamento, activo)
		For Each fila As DataRow In tabla.Rows
			Dim celula As New Entidades.Celulas
			celula.PcelulaID = CInt(fila("celu_celulaid"))
			celula.Pnombre = CStr(fila("celu_nombre"))
			'celula.PDepartamento.PNave = CInt(fila("grup_naveid"))
			'celula.Pdepartamento = CInt(fila("celu_grupoid"))
			celula.Pactivo = CBool(fila("celu_activo"))

			Dim grupo As New Departamentos

			grupo.Ddepartamentoid = CInt(fila("grup_grupoid"))
			grupo.DNombre = CStr(fila("grup_name"))
			grupo.DActivo = CBool(fila("grup_activo"))

			celula.PDepartamento = grupo

			Dim naves As New Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))
			naves.PActivo = CBool(fila("nave_activo"))

			celula.PDepartamento.PNave = naves


			listaCelulas.Add(celula)
		Next
	End Function


	Public Sub altasCelulas(ByVal celula As Entidades.Celulas)
		Dim objcelulalDA As New CelulasDA
		objcelulalDA.AltasCelulas(celula)
	End Sub

	Public Sub editarCelulas(ByVal celula As Entidades.Celulas)
		Dim objcelulaDA As New CelulasDA
		objcelulaDA.editarCelulas(celula)
	End Sub

	Public Function buscarcelula(ByVal celulaid As Int32) As Entidades.Celulas
		Dim objcelulalDA As New CelulasDA
		Dim celula As New Entidades.Celulas
		Dim tablaSucursales As New DataTable
		tablaSucursales = objcelulalDA.buscarCelula(celulaid)

		For Each fila As DataRow In tablaSucursales.Rows



			celula.PCelulaid = CInt(fila("celu_celulaid"))
			celula.PNombre = CStr(fila("celu_nombre"))
			'celula.Pnave = CInt(fila("grup_naveid"))
			'celula.PDepartamento.PNave = CInt(fila("celu_grupoid"))
			celula.PActivo = CBool(fila("celu_activo"))


			Dim grupo As New Departamentos

			grupo.Ddepartamentoid = CInt(fila("grup_grupoid"))
			grupo.DNombre = CStr(fila("grup_name"))
			grupo.DActivo = CBool(fila("grup_activo"))

            celula.PDepartamento = grupo
            If IsDBNull(fila("celu_orden")) Then
            Else
                celula.POrden = CInt(fila("celu_orden"))
            End If

            Dim naves As New Naves

            naves.PNaveId = CInt(fila("nave_naveid"))
            naves.PNombre = CStr(fila("nave_nombre"))
            naves.PActivo = CBool(fila("nave_activo"))

            celula.PDepartamento.PNave = naves


        Next

		Return celula
	End Function

	Public Function listaCelulasActivas() As DataTable
		Dim objDA As New Datos.CelulasDA
        Return objDA.listaCelulasActivas
	End Function



	Public Function ListaCelulasGrupos(ByVal gruposid As Integer) As DataTable
		Dim objDA As New Datos.CelulasDA
		Return objDA.listaCelulas(0, "", gruposid, True)
	End Function
	Public Function ListaCelulasNaves(ByVal navesid As Integer) As DataTable
		Dim objDA As New Datos.CelulasDA
		Return objDA.listaCelulas(0, "", navesid, True)
	End Function

    Public Function ListaCelulasegunDepartamento(ByVal Idepartamento) As DataTable
        Dim objDa As New Datos.CelulasDA
        Return objDa.CelulaSegunDepartamento(Idepartamento)
    End Function

End Class





