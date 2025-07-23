Imports Entidades
Imports System.Data.SqlClient

Public Class ErroresPersistencia

	Public Shared Function MensajeInterno(ex As Exception) As String
		MensajeInterno = String.Empty
		MensajeInterno = "Error: " + ex.Message
		MensajeInterno += "   Fuente: " + ex.Source
		MensajeInterno += "   StarkTrace: " + ex.StackTrace
		Return MensajeInterno
	End Function


	Public Shared Function MensajeInterno(sqlex As SqlClient.SqlException) As String
		MensajeInterno = String.Empty
		MensajeInterno += "   StarkTrace: " + sqlex.StackTrace
		MensajeInterno += "Linea: " & sqlex.LineNumber.ToString
		MensajeInterno += "Numero : " & sqlex.Number.ToString
		MensajeInterno += "Error: " & sqlex.Message
		MensajeInterno += "Procedimiento: " & sqlex.Procedure
		MensajeInterno += "Servidor: " & sqlex.Server
		MensajeInterno += "Fuente: " & sqlex.Source
		Return (MensajeInterno)
	End Function

	Public Shared Function Guardar(sqlex As SqlClient.SqlException, SentenciaSQL As String, ByVal Parametros As List(Of SqlParameter)) As String
		Try
			Dim IdHistorial As Int32 = 0
			Dim HistorialID As Int32 = 0
			Dim Sentencia As String = "INSERT INTO Framework.Historial ("
			Sentencia += "hist_usuarioid, hist_sentencia, hist_fecha, hist_mensaje)"
			Sentencia += "values("
			Sentencia += SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ","
			Sentencia += "'" + SentenciaSQL + "',"
			Sentencia += "'" + Format(DateTime.Now, "yyyy-MM-dd HH:mm") + "',"
			Sentencia += "'" + ErroresPersistencia.MensajeInterno(sqlex).Replace("'", "") + "')"
			Dim Operaciones As New OperacionesProcedimientos
			Operaciones.EjecutaSentencia("Set DateFormat MDY;" + Sentencia)
			IdHistorial = ErroresPersistencia.ObtenerIdInsertado()
			Return "Ocurrió un error inesperado. Contacte al Administrador del sistema y muestre la clave: " + IdHistorial.ToString
		Catch ex As Exception
			Throw ex
		End Try
	End Function


	Public Shared Function ObtenerIdInsertado() As Int32
		ObtenerIdInsertado = 0
		Dim Operaciones As New OperacionesProcedimientos
		Dim dt As New DataTable

		Dim Sentencia As String = "SELECT max(hist_historialid) from Framework.Historial"
		dt = Operaciones.EjecutaConsulta(Sentencia)
		For Each row As DataRow In dt.Rows
			For Each col As DataColumn In dt.Columns
				ObtenerIdInsertado = CInt(row(col))
			Next
		Next
		Return ObtenerIdInsertado
	End Function
End Class
