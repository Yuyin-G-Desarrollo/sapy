Imports System.Data.SqlClient

Public Class Pool

	Private _SqlConn As SqlConnection

    Public Sub New()
        Conexion()
    End Sub

    Public Sub New(ByVal blConectarSICY As Boolean)
        Conexion(True)
    End Sub

    Public Sub New(ByVal blConectarSICY As String)
        Conexion("")
    End Sub

    Public Sub New(ByVal blConectarSICY As Integer)
        Conexion(0)
    End Sub

    Public Sub New(ByVal blConectarContpaq As Double)
        Conexion(1.2)
    End Sub

	Public Property SQLConn() As SqlConnection
		Get
			Return _SqlConn
		End Get
		Set(ByVal Value As SqlConnection)
			_SqlConn = Value
		End Set
	End Property

	Private Function StrConexion() As String
		Try
			Dim strConn As String
			strConn = My.Settings.CadenaConexionPool

			Return strConn
		Catch ex As Exception
			Throw ex
		End Try
    End Function

    Private Function StrConexion(ByVal blConectarSICY As Boolean) As String
        Try
            Dim strConn As String
            strConn = My.Settings.CadenaConexionPoolSICY

            Return strConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function StrConexion(ByVal blConectarSICY As String) As String
        Try
            Dim strConn As String
            strConn = My.Settings.CadenaConexionPoolSICYTEST

            Return strConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function StrConexion(ByVal blConectarSAYDesarrollo As Integer) As String
        Try
            Dim strConn As String
            strConn = My.Settings.CadenaConexionPoolPruebas

            Return strConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function StrConexion(ByVal blConectarSAYDesarrollo As Double) As String
        Try
            Dim strConn As String
            strConn = My.Settings.CadenaConexionContpaq

            Return strConn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

	Private Sub Conexion()
		_SqlConn = New SqlConnection(Me.StrConexion)
    End Sub

    Private Sub Conexion(ByVal lbConectarSICY As Boolean)
        _SqlConn = New SqlConnection(Me.StrConexion(True))
    End Sub

    Private Sub Conexion(ByVal lbConectarSICY As String)
        _SqlConn = New SqlConnection(Me.StrConexion(""))
    End Sub

    Private Sub Conexion(ByVal lbConectarSICY As Integer)
        _SqlConn = New SqlConnection(Me.StrConexion(0))
    End Sub

    Private Sub Conexion(ByVal lbConectarSICY As Double)
        _SqlConn = New SqlConnection(Me.StrConexion(0.5))
    End Sub

End Class

