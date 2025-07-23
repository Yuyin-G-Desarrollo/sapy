Imports Framework.Datos
Imports Entidades

Public Class AccionesBU
	Public Function listaAcciones() As List(Of Entidades.Acciones)
		Dim objDA As New Datos.AccionesDA
		Dim tablas As New DataTable
		Dim objModulosBU As New ModulosBU
		listaAcciones = New List(Of Entidades.Acciones)
		tablas = objDA.listaAcciones

		For Each row As DataRow In tablas.Rows
			Dim accion As New Entidades.Acciones
			accion.PNombre = CStr(row("acmo_nombre"))
			accion.PModulo = objModulosBU.BuscarModulo(CInt(row("acmo_moduloid")))
			accion.PClave = CStr(row("acmo_clave"))
			If Not IsDBNull(row("acmo_componente")) Then
				accion.PComponente = CStr(row("acmo_componente"))
			End If

			If Not IsDBNull(row("acmo_icono")) Then
				accion.PIcono = CStr(row("acmo_icono"))
			End If
			accion.PTipo = CInt(row("acmo_tipo"))
			accion.PActivo = CBool(row("acmo_activo"))

			listaAcciones.Add(accion)
		Next
		Return listaAcciones
	End Function
	Public Function listaAccionesActivos() As DataTable
		Dim objDA As New Datos.AccionesDA
		Return objDA.listaAcciones()

		'Return objDA.listaAcciones("", 0, "", 0, True)
	End Function
	Public Function ListaAccionesSegunModulo(ByVal moduloid As Integer) As List(Of Entidades.Acciones)
		Dim objDA As New Datos.AccionesDA
		Dim tabla As New DataTable
		ListaAccionesSegunModulo = New List(Of Entidades.Acciones)
		tabla = objDA.ListaAccionessegunmodulo(moduloid)
		For Each fila As DataRow In tabla.Rows
			Dim acmo As New Entidades.Acciones
			acmo.PNombre = CStr(fila("acmo_nombre"))
			acmo.PAccionId = CInt(fila("acmo_accionmoduloid"))
			ListaAccionesSegunModulo.Add(acmo)
		Next
	End Function
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	Public Function listaAccionesModulos(ByVal Nombre As String, ByVal Clave As String, ByVal Modulo As Int32, ByVal Tipo As Int32, ByVal Activo As Boolean) As List(Of Entidades.Acciones)

		Dim objDA As New Datos.AccionesDA
		Dim tabla As New DataTable
		Dim objModulosBU As New ModulosBU
		listaAccionesModulos = New List(Of Entidades.Acciones)

		tabla = objDA.listaAccionesModulos(Nombre, Clave, Modulo, Tipo, Activo)
		For Each fila As DataRow In tabla.Rows
			Dim Accion As New Entidades.Acciones
			Accion.PAccionId = CInt(fila("acmo_accionmoduloid"))
			Accion.PNombre = CStr(fila("acmo_nombre"))
			Accion.PClave = CStr(fila("acmo_clave"))
			Accion.PTipo = CInt(fila("acmo_tipo"))
			Accion.PActivo = CBool(fila("acmo_activo"))

			Dim modulos As New Modulos

			modulos.PModuloid = CInt(fila("modu_moduloid"))
			modulos.PNombre = CStr(fila("modu_nombre"))
			modulos.PActivo = CBool(fila("modu_activo"))

			Accion.PModulo = modulos


			'Dim acciones As New Acciones

			'Accion.PAccionId = CInt(fila("acmo_accionmoduloid"))
			'Accion.PNombre = CStr(fila("acmo_nombre"))








			listaAccionesModulos.Add(Accion)
		Next
	End Function
	Public Function buscarAccionesModulo(ByVal idAcciones As Int32) As Entidades.Acciones

		Dim objDA As New Datos.AccionesDA
		Dim Accion As New Entidades.Acciones
		Dim tabla As New DataTable
		Dim objModulosBU As New ModulosBU
		'buscarAccionesModulo = New List(Of Entidades.Acciones)

		tabla = objDA.buscarAccionesModulo(idAcciones)
		For Each fila As DataRow In tabla.Rows

			'Dim Acciones As New Entidades.Acciones

			Accion.PAccionId = CInt(fila("acmo_accionmoduloid"))
			Accion.PNombre = CStr(fila("acmo_nombre"))
			Accion.PClave = CStr(fila("acmo_clave"))
			Accion.PTipo = CInt(fila("acmo_tipo"))
			Accion.PActivo = CBool(fila("acmo_activo"))

			Dim modulos As New Modulos

			modulos.PModuloid = CInt(fila("modu_moduloid"))
			modulos.PNombre = CStr(fila("modu_nombre"))
			modulos.PActivo = CBool(fila("modu_activo"))

			Accion.PModulo = modulos

		Next

		Return Accion
	End Function
	Public Function AltasAcciones(ByVal Accion As Entidades.Acciones) As String
		''CAMBIO DE VALIDACIONES PARA QUE NO SE DUPIQUEN LOS DATOS 

		'Public Sub AltasAcciones(ByVal Accion As Entidades.Acciones) 
		''Dim objAccionesDA As New AccionesDA
		''objAccionesDA.AltasAcciones(Accion)
		'
		AltasAcciones = ""
		Dim objAccionesDA As New AccionesDA
		'consulta que evita datos duplicados
		Dim tablaAcciones As New DataTable
		tablaAcciones = objAccionesDA.listaAccionesModulos("", Accion.PClave, 0, Accion.PTipo, CBool(0))

		If (tablaAcciones.Rows.Count) <= 0 Then
			objAccionesDA.AltasAcciones(Accion)
		Else
			AltasAcciones = "Ya existe UN Tipo para esta Accion "
		End If
		Return AltasAcciones

    End Function
	Public Sub EditarAcciones(ByVal Accion As Entidades.Acciones)
		Dim objAccionesDA As New AccionesDA
		objAccionesDA.editarAcciones(Accion)
    End Sub

    ' ''-----------------------------------------------------------------------------------------------------------------------

    'Public Function obtenerIdModuloParaAccion(ByVal nomModuloNieto As String, ByVal nomModuloHijo As String, ByVal nomModuloPadre As String) As DataTable
    '    Dim objAccionesDA As New AccionesDA
    '    Return objAccionesDA.obtenerIdModuloParaAccion(nomModuloNieto, nomModuloHijo, nomModuloPadre)
    'End Function

    Public Function verAccionesPorModulo(ByVal idModulo As String) As DataTable
        Dim objAccionesDA As New AccionesDA
        Return objAccionesDA.verAccionesPorModulo(idModulo)
    End Function

    Public Function BuscarAccion(ByVal claveAccion As String, ByVal claveModulo As String) As Integer
        Dim objDA As New Datos.AccionesDA
        Dim tabla As New DataTable
        Dim objModulosBU As New ModulosBU
        Dim accionID As Integer = 0
        'buscarAccionesModulo = New List(Of Entidades.Acciones)

        tabla = objDA.BuscarAcciones(claveAccion, claveModulo)
        For Each fila As DataRow In tabla.Rows

            'Dim Acciones As New Entidades.Acciones

            accionID = CInt(fila("acmo_accionmoduloid"))

        Next

        Return accionID

    End Function

    Public Sub ModificarAcciones(ByVal Accion As Entidades.Acciones)
        Dim objAccionesDA As New AccionesDA
        objAccionesDA.ModificarAcciones(Accion)
    End Sub

End Class


