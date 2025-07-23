Public Class RelacionNavePatronBU

    Public Function cargarListaPatrones() As DataTable
        Dim objDA As New Datos.RelacionNavePatronDA
        Return objDA.cargarListaPatrones
    End Function

    Public Function cargarNavesRelacion(ByVal patronId As Integer) As DataTable
        Dim objDA As New Datos.RelacionNavePatronDA
        Return objDA.cargarNavesRelacion(patronId)
    End Function

    Public Function editarRelacion(ByVal patronId As Integer, ByVal naveId As Integer, ByVal relacionar As Boolean) As DataTable
        Dim objDA As New Datos.RelacionNavePatronDA
        Return objDA.editarRelacion(patronId, naveId, relacionar)
    End Function


End Class
