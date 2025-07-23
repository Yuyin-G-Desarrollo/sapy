Imports Framework.Datos

Public Class SucursalesBU
    Public Function listaSucursales(ByVal numero As String, ByVal nombre As String, ByVal IdBanco As Int32, ByVal Idciudad As Int32, ByVal activo As Boolean) As DataTable

        Dim objDA As New Datos.SucursalesDA
        listaSucursales = objDA.ListaSucursales(numero, nombre, IdBanco, Idciudad, activo)
        Return listaSucursales
    End Function


	Public Sub guardarSucursal(ByVal sucursal As Entidades.Sucursales)
		Dim objSucursalDA As New SucursalesDA
		objSucursalDA.AltasSucursales(sucursal)
	End Sub

	Public Sub editarsucursales(ByVal sucursal As Entidades.Sucursales)
		Dim objsucursalDA As New SucursalesDA
		objsucursalDA.editarSucursales(sucursal)
	End Sub

	Public Function buscarsucuirsal(ByVal idsucursal As Int32) As Entidades.Sucursales
		Dim objsucursalDA As New Datos.SucursalesDA
		Dim sucursal As New Entidades.Sucursales
		Dim tablaSucursales As New DataTable
		tablaSucursales = objsucursalDA.buscarSucursal(idsucursal)
		
		For Each fila As DataRow In tablaSucursales.Rows


			sucursal.Pidsucursales = CInt(fila("sucu_sucursalid"))
			sucursal.Pnumero = CStr(fila("sucu_numero"))
			sucursal.Pnombre = CStr(fila("sucu_nombre"))
			sucursal.Pbanco = CInt(fila("sucu_bancoid"))
			sucursal.Pciudad = CInt(fila("sucu_ciudadid"))
			sucursal.Pactivo = CBool(fila("sucu_activo"))

		Next

		Return sucursal
	End Function

	Public Function listaSucursalesActivos() As DataTable
		Dim objDA As New Datos.SucursalesDA
		Return objDA.ListaSucursales("", "", 0, 0, True)
	End Function

	Public Function ListaSursalesBancos(ByVal bancosid As Integer) As DataTable
		Dim objDA As New Datos.SucursalesDA
		Return objDA.ListaSucursales("", "", bancosid, 0, True)
	End Function

	Public Function ListaSucursalesCiudades(ByVal ciudadid As Integer) As DataTable
		Dim objDA As New Datos.SucursalesDA
		Return objDA.ListaSucursales("", "", ciudadid, 0, True)
	End Function
End Class


