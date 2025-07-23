Imports Contabilidad.Negocios

Public Class TestForm

    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New PolizaBU
        grdPrueba.DataSource = objBU.consultacolaboradoresPrueba
    End Sub
End Class