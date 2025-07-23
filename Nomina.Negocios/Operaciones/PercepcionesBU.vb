Public Class PercepcionesBU

    Public Sub guardarPrenominaPercepciones(ByVal nomina As Entidades.Percepciones)
        Dim objNomina As New Datos.PercepcionesDA
        objNomina.GuardarPercepcionesPreNomina(nomina)
    End Sub

End Class
