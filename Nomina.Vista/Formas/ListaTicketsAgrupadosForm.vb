Public Class ListaTicketsAgrupadosForm
    Public colaboradorid As Integer
    Public periodoid As Integer
    Public nombrecolaborador As String
    Private Sub ListaTicketsAgrupadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblColaborador.Text = nombrecolaborador.ToUpper
        Dim ticketsBU As New Negocios.TicketsBU
        Dim tablaTickets As New DataTable
        tablaTickets = ticketsBU.ListaTicketsAgrupados(colaboradorid, periodoid)
        grdTicketsAgrupados.DataSource = tablaTickets

        grdTicketsAgrupados.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    End Sub
End Class