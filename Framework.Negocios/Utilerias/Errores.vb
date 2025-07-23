Public Class Errores

	Public Shared Function MensajeInterno(ex As Exception) As String
		MensajeInterno = String.Empty
		MensajeInterno = "Error: " + ex.Message
		MensajeInterno += "   Fuente: " + ex.Source
		MensajeInterno += "   StarkTrace: " + ex.StackTrace
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function


	Public Shared Function MensajeInterno(sqlex As SqlClient.SqlException) As String
		MensajeInterno = String.Empty
		MensajeInterno += "Linea: " & sqlex.LineNumber.ToString
		MensajeInterno += "Numero : " & sqlex.Number.ToString
		MensajeInterno += "Error: " & sqlex.Message
		MensajeInterno += "Procedimiento: " & sqlex.Procedure
		MensajeInterno += "Servidor: " & sqlex.Server
		MensajeInterno += "Fuente: " & sqlex.Source
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return (MensajeInterno)
	End Function

	Public Shared Function MensajeInterno(ex As SystemException) As String
		MensajeInterno = String.Empty
		MensajeInterno = "Error: " & ex.Message
		MensajeInterno += "Fuente: " & ex.Source
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function

	Public Shared Function MensajeInterno(ex As IndexOutOfRangeException) As String
		MensajeInterno = String.Empty
		MensajeInterno = " Error: " & ex.Message
		MensajeInterno += " Fuente: " & ex.Source
		MensajeInterno += " Metodo: " & ex.TargetSite.ToString
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function

	Public Shared Function MensajeInterno(ex As NullReferenceException) As String
		MensajeInterno = String.Empty
		MensajeInterno = " Error: " & ex.Message
		MensajeInterno += " Fuente: " & ex.Source
		MensajeInterno += " Metodo: " & ex.TargetSite.ToString
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function

	Public Shared Function MensajeInterno(ex As InvalidOperationException) As String
		MensajeInterno = String.Empty
		MensajeInterno = " Error: " & ex.Message
		MensajeInterno += " Fuente: " & ex.Source
		MensajeInterno += " Metodo: " & ex.TargetSite.ToString
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function

	Public Shared Function MensajeInterno(ex As ArgumentException) As String
		MensajeInterno = String.Empty
		MensajeInterno = " Error: " & ex.Message
		MensajeInterno += " Fuente: " & ex.Source
		MensajeInterno += " Metodo: " & ex.TargetSite.ToString
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function

	Public Shared Function MensajeInterno(ex As ArgumentNullException) As String
		MensajeInterno = String.Empty
		MensajeInterno = " Error: " & ex.Message
		MensajeInterno += " Fuente: " & ex.Source
		MensajeInterno += " Metodo: " & ex.TargetSite.ToString
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function

	Public Shared Function MensajeInterno(ex As ArgumentOutOfRangeException) As String
		MensajeInterno = String.Empty
		MensajeInterno = " Error: " & ex.Message
		MensajeInterno += " Fuente: " & ex.Source
		MensajeInterno += " Metodo: " & ex.TargetSite.ToString
		MensajeInterno = MensajeInterno.Replace("'", "").Replace("%", "")
		Return MensajeInterno
	End Function


End Class
