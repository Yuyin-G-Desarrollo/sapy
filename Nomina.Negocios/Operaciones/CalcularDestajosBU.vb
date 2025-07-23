Public Class CalcularDestajosBU

    Public Sub CambiarSemanaDestajos(ByVal IDSemanaNomina As Entidades.CalcularDestajos)
        Dim objNomina As New Datos.CalcularDestajosDA
        objNomina.CambiarSemanaDestajos(IDSemanaNomina)
    End Sub

End Class
