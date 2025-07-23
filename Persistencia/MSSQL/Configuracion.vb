Public Class Configuracion

    Public Shared Sub cambiarConexion(ByVal conexionSAY As String, ByVal conexionSICY As String, ByVal conexionSICYPruebas As String)
        'My.Settings.CadenaConexionPool = conexionSAY
        'My.Settings.CadenaConexionPoolSICY = conexionSICY
        'My.Settings.CadenaConexionPoolPruebas = conexionSICYPruebas
    End Sub

    Public Shared Function CadenaConexionPool() As String
        Return My.Settings.CadenaConexionPool
    End Function

    Public Shared Function CadenaConexionPoolSICY() As String
        Return My.Settings.CadenaConexionPoolSICY
    End Function

    Public Shared Function CadenaConexionPoolPruebas() As String
        Return My.Settings.CadenaConexionPoolSICYTEST
    End Function

End Class
