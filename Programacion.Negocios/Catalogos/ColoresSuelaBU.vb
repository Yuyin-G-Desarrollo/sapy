
Public Class ColoresSuelaBU
    Public Function obtenerColoresSuelas(ByVal cosu_activo As Boolean) As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.obtenerColoresSuelas(cosu_activo)
    End Function

    Public Function ContarFilasColoresSuelas() As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.ContarFilasColoresSuelas()
    End Function

    Public Function VerMaximoIdColorSuela() As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.VerMaximoIdColorSuela()
    End Function

    Public Function VerCodigosDisponibles() As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.VerCodigosDisponibles()
    End Function

    Public Function registrarSuela(ByVal EntidadColorSuela As Entidades.ColorSuela, ByVal usuario As String)
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.registrarSuela(EntidadColorSuela, usuario)
    End Function

    Public Function EditarColorSuela(ByVal EntidadColorSuela As Entidades.ColorSuela, ByVal usuario As String)
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.EditarSuela(EntidadColorSuela, usuario)
    End Function

    Public Function ValidarRepetidos(ByVal colorsuelaId As String) As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.ValidarRepetidos(colorsuelaId)
    End Function


    Public Function verComboColorSuela() As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.verComboColorSuela()
    End Function

    Public Function verColorSuelaRegistradaRapido(ByVal IdsColorSuela As String) As DataTable
        Dim objDA As New Programacion.Datos.ColoresSuelaDA
        Return objDA.verColorSuelaRegistradaRapido(IdsColorSuela)
    End Function

    Public Function verColorSuelaId(ByVal ColorSuelaId As Integer) As DataTable
        Dim objColorSuelaDA As New Programacion.Datos.ColoresSuelaDA
        Try
            Return objColorSuelaDA.verColorSuelaId(ColorSuelaId)
        Catch ex As Exception

        End Try
    End Function

End Class
