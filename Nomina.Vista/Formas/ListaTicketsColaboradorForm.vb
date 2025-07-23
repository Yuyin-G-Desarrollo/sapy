Public Class ListaTicketsColaboradorForm
    Dim Consecutivoin, Descendente As New Int32
    Private Colaboradorid As Int32
    Private PeriodoNomina As Int32
    Dim SumaTotales As Double

    Public Property PColaboradorid As Int32
        Get
            Return Colaboradorid
        End Get
        Set(ByVal value As Int32)
            Colaboradorid = value
        End Set
    End Property
    Public Property PPeriocoNomina As Int32
        Get
            Return PeriodoNomina
        End Get
        Set(ByVal value As Int32)
            PeriodoNomina = value
        End Set
    End Property
    Private Sub ListaTicketsColaboradorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenartabla()


        grdTickets.Rows.Add(0, "Total", "", "", 0.0, 0, 0, SumaTotales)
        grdTickets.Rows(grdTickets.Rows.Count - 1).Cells("NO").Style.ForeColor = Color.GreenYellow
        grdTickets.Rows(grdTickets.Rows.Count - 1).Cells("Colaborador").Style.ForeColor = Color.GreenYellow
        grdTickets.Rows(grdTickets.Rows.Count - 1).Cells("FechaCaptura").Style.ForeColor = Color.GreenYellow
        grdTickets.Rows(grdTickets.Rows.Count - 1).Cells("Descripcion").Style.ForeColor = Color.GreenYellow
        grdTickets.Rows(grdTickets.Rows.Count - 1).Cells("CostoPartida").Style.ForeColor = Color.GreenYellow
        grdTickets.Rows(grdTickets.Rows.Count - 1).Cells("NoPares").Style.ForeColor = Color.GreenYellow
        grdTickets.Rows(grdTickets.Rows.Count - 1).DefaultCellStyle.BackColor = Color.GreenYellow


    End Sub


    Public Sub llenartabla()

        Dim listaSolicitudes As New List(Of Entidades.Ticket)
        Dim objBU As New Negocios.TicketsBU
        Consecutivoin = 1

       
        listaSolicitudes = objBU.ListaTicketsColaborador(Colaboradorid, PeriodoNomina)
        Descendente = listaSolicitudes.Count
        For Each objeto As Entidades.Ticket In listaSolicitudes


            AgregarFila(objeto)
            Consecutivoin += 1
            Descendente -= 1
        Next
    End Sub


    Public Sub AgregarFila(ByVal Tickets As Entidades.Ticket)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow


        '1
        celda = New DataGridViewTextBoxCell
        celda.Value = Consecutivoin
        fila.Cells.Add(celda)

        '2
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PNoTicket
        fila.Cells.Add(celda)

        '3.5
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PNombreColaborador
        fila.Cells.Add(celda)

        '3
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PFecha.ToShortDateString
        fila.Cells.Add(celda)
        '4
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PDescripcion
        fila.Cells.Add(celda)
        '5

        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PCostoPartida
        fila.Cells.Add(celda)
        '6
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PCantidadPares
        fila.Cells.Add(celda)
        '7
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PTotal
        fila.Cells.Add(celda)
        SumaTotales += Tickets.PTotal
        '8
        celda = New DataGridViewTextBoxCell
        celda.Value = Tickets.PIDRegistro
        fila.Cells.Add(celda)


        grdTickets.Rows.Add(fila)



    End Sub
End Class