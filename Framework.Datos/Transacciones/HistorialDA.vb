Imports Entidades
Imports Persistencia

Public Class HistorialDA
	Public Function Guardar(ByVal ObjHistorial As Historial) As Int32
		Try
			Dim IdHistorial As Int32 = 0
			Dim HistorialID As Int32 = 0
			Dim Sentencia As String = "INSERT INTO Framework.Historial ("
			Sentencia += "hist_usuarioid, hist_sentencia, hist_fecha, hist_mensaje)"
			Sentencia += "values("
			Sentencia += ObjHistorial.PHistUsuarioId.ToString + ","
			Sentencia += "'" + ObjHistorial.PHistSentencia + "',"
			Sentencia += "'" + Fechas.formatearFecha(ObjHistorial.PHistFecha, "yyyy-MM-dd HH:mm:ss") + "',"
			Sentencia += "'" + ObjHistorial.PHistMensaje + "')"

			Dim Operaciones As New OperacionesProcedimientos
			Operaciones.EjecutaSentencia("Set DateFormat MDY;" + Sentencia)
			IdHistorial = Me.ObtenerIdInsertado()
			Return IdHistorial
		Catch ex As Exception
			Return 0
		End Try

	End Function


	Public Function ObtenerIdInsertado() As Int32
		Try
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
		Catch ex As Exception
			SesionError.Excepcion = ex
			Throw ex
		End Try
	End Function
End Class
