Imports Framework.Datos
Public Class MigracionInfraestucturaBU
    Public Function obtenerAlertaMigracion(ByVal ordenPantalla As Integer) As DataTable
        Dim objalerta As New MigracionInfraestructuraDA
        Return objalerta.obtenerAlerta(ordenPantalla)
    End Function
End Class
