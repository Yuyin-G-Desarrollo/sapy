Imports Framework.Datos

Public Class BancosBU
	Public Function listaBancosActivos() As DataTable
		Dim objDA As New Datos.BancosDA
		Return objDA.listaBancosActivos()
	End Function

	Public Function listaBancos(ByVal nombre As String, ByVal activo As Boolean) As List(Of Entidades.Bancos)
		Dim objDA As New Datos.BancosDA
		Dim tabla As New DataTable
		listaBancos = New List(Of Entidades.Bancos)
		tabla = objDA.listaBancos(nombre, activo)
		For Each fila As DataRow In tabla.Rows
			Dim banco As New Entidades.Bancos

			banco.PBancosId = CInt(fila("banc_bancoid"))
			banco.PNombre = CStr(fila("banc_nombre"))
			banco.PActivo = CBool(fila("banc_activo"))

			listaBancos.Add(banco)

		Next
	End Function
	Public Sub editarBancos(ByVal banco As Entidades.Bancos)
		Dim ObjNave As New BancosDA
		ObjNave.editarBancos(banco)

	End Sub
	Public Sub AltasBancos(ByVal banco As Entidades.Bancos)
		Dim objBanco As New BancosDA
		objBanco.AltasBancos(banco)

	End Sub

	Public Function buscarBancos(ByVal bancosid As Int32) As Entidades.Bancos
		Dim objBancosDA As New Datos.BancosDA
		Dim banco As New Entidades.Bancos
		Dim tablaBanco As New DataTable
		tablaBanco = objBancosDA.buscarBancos(bancosid)

		For Each fila As DataRow In tablaBanco.Rows


			banco.PBancosId = CInt(fila("banc_bancoid"))
			banco.PNombre = CStr(fila("banc_nombre"))
			banco.PActivo = CBool(fila("banc_activo"))
		Next


		Return banco
	End Function


End Class




