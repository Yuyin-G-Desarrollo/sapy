Imports Entidades
Imports Framework.Datos

Public Class HistorialBU
	Public Shared Function GuardaError(ByVal Mensaje As String) As String
		Try
			Dim Sentencia As String = ""
			Dim ObjHistorial As New Historial
			If Not IsNothing(SesionUsuario.UsuarioSesion) Then
				ObjHistorial.PHistUsuarioId = SesionUsuario.UsuarioSesion.PUserUsuarioid
			Else
				ObjHistorial.PHistUsuarioId = vbNull
			End If

			ObjHistorial.PHistMensaje = Mensaje
			ObjHistorial.PHistFecha = Fechas.now()
			If IsNothing(SesionError.Parametros) Then
				Sentencia = "Sentencia : " + SesionError.Sentencia
			End If
			If Not IsNothing(SesionError.Comando) Then
				Sentencia = "Comando : " + SesionError.Comando.CommandText
			End If


			If Not IsNothing(SesionError.Parametros) Then
				Sentencia += " - Parametros: "
				For Each param In SesionError.Parametros
					Sentencia += "{" + param.ParameterName + "," + param.Value.ToString + "}"
				Next
			End If
			ObjHistorial.PHistSentencia = Sentencia
			Dim ObjHistorialDA As New HistorialDA
			Return "Ocurrió un error inesperado. Comuníquese con el administrador del sistema y dele a conocer la siguiente clave: " + ObjHistorialDA.Guardar(ObjHistorial).ToString
		Catch
			Return "Ocurrió un error inesperado. Comuníquese con el administrador del sistema"
		End Try
	End Function
End Class
