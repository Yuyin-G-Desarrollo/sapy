Imports System.Data.SqlClient

Public Class SesionError
	Public Shared Sentencia As String
	Public Shared Mensaje As String
	Public Shared Comando As SqlClient.SqlCommand
	Public Shared Parametros As List(Of SqlParameter)
	Public Shared SqlException As SqlClient.SqlException
	Public Shared Excepcion As Exception

	Public Shared Sub CargarError(ByVal psentencia As String, ByVal pmensaje As String, ByVal pcomando As SqlClient.SqlCommand, ByVal pparametros As List(Of SqlParameter))
		Sentencia = psentencia
		Mensaje = pmensaje
		Comando = pcomando
		Parametros = pparametros
	End Sub

	Public Shared Sub CargarError(ByVal psentencia As String, ByVal pparametros As List(Of SqlParameter))
		Sentencia = psentencia
		Parametros = pparametros
	End Sub

	Public Shared Sub CargarError(ByVal psentencia As String, ByVal ex As SqlClient.SqlException)
		Sentencia = psentencia
		SqlException = ex
	End Sub

	Public Shared Sub CargarError(ByVal psentencia As String, ByVal pparametros As List(Of SqlParameter), ByVal ex As SqlClient.SqlException)
		Sentencia = psentencia
		Parametros = pparametros
		SqlException = ex
	End Sub

End Class
