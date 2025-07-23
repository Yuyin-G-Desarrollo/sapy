Imports Nomina.Datos

Public Class MotivosFiniquitoBU
	Public Function listaMotivosFiniquitos(ByVal nombre As String, ByVal nave As Int32, ByVal activo As Boolean) As List(Of Entidades.MotivosFiniquito)
		Dim objDA As New Datos.MotivosFiniquitoDA
		Dim tabla As New DataTable
		listaMotivosFiniquitos = New List(Of Entidades.MotivosFiniquito)
		tabla = objDA.ListaMotivosFiniquitos(nombre, nave, activo)
		For Each fila As DataRow In tabla.Rows
			Dim motivo As New Entidades.MotivosFiniquito
			motivo.PMotivoFiniquitoId = CInt(fila("mfin_motivofiniquitoid"))
			motivo.PNombre = CStr(fila("mfin_nombre"))
			'motivo.PNaveId.PNaveId = CInt(fila("mpre_naveid"))
			motivo.PActivo = CBool(fila("mfin_activo"))


			Dim naves As New Entidades.Naves

			naves.PNaveId = CInt(fila("nave_naveid"))
			naves.PNombre = CStr(fila("nave_nombre"))


			motivo.PNaveId = naves


			listaMotivosFiniquitos.Add(motivo)

		Next
	End Function
	Public Sub ALtasMfin(ByVal motivos As Entidades.MotivosFiniquito)
		Dim objMotivosDA As New MotivosFiniquitoDA
		objMotivosDA.altasDeMotivos(motivos)
	End Sub

	Public Sub EdiarMotivosFiniquitos(ByVal motivos As Entidades.MotivosFiniquito)

		Dim objMotivosDA As New MotivosFiniquitoDA
		objMotivosDA.editarMotivosFiniquitos(motivos)
	End Sub
	Public Function BuscarMotivos(ByVal idmotivos As Int32) As Entidades.MotivosFiniquito

		Dim objMotivoDA As New Datos.MotivosFiniquitoDA
		Dim motivo As New Entidades.MotivosFiniquito
		Dim tablaMotivo As New DataTable
		tablaMotivo = objMotivoDA.buscarMotivos(idmotivos)

		For Each fila As DataRow In tablaMotivo.Rows
			motivo.PMotivoFiniquitoId = CInt(fila("mfin_motivofiniquitoid"))
			motivo.PNombre = CStr(fila("mfin_nombre"))
			motivo.PActivo = CBool(fila("mfin_activo"))

			Dim Naves As New Entidades.Naves

			Naves.PNaveId = CInt(fila("nave_naveid"))
			Naves.PNombre = CStr(fila("nave_nombre"))

			motivo.PNaveId = Naves
		Next

		Return motivo
    End Function

    Public Function MotivosFiniquitoSegunNave(ByVal idNave As Int32) As List(Of Entidades.MotivosFiniquito)
        Dim objDA As New Datos.MotivosFiniquitoDA

        Dim tabla As New DataTable
        MotivosFiniquitoSegunNave = New List(Of Entidades.MotivosFiniquito)
        tabla = objDA.ListaMotivosFiniquitoSegunNave(idNave)

        For Each Fila As DataRow In tabla.Rows
            Dim motivo As New Entidades.MotivosFiniquito
            motivo.PMotivoFiniquitoId = CInt(Fila("mfin_motivofiniquitoid"))
            motivo.PNombre = CStr(Fila("mfin_nombre")).ToUpper
            MotivosFiniquitoSegunNave.Add(motivo)
        Next

        'Return MotivosFiniquitoSegunNave
    End Function

End Class
