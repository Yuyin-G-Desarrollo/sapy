Public Class ConsultaDetalleProspectaForm
    Dim DataTableParesAtado As DataTable
  
 

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        Panel6.Height = 24        
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        Panel6.Height = 130
    End Sub

    'Private Sub LlenarGrid()
    '    Dim ObjPRospecta As New Ventas.Negocios.ProspectaBU()
    '    With gridListaProspecta
    '        .DataSource = ObjPRospecta.ConsultaProspecta(Date.Now)
    '    End With
    'End Sub

    'Private Sub ConsultaDetalleProspectaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    LlenarGrid()
    'End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click

    End Sub
End Class