Imports Entidades
Imports Produccion.Negocios


Public Class AdmonAvancesDetalleForm

    Public Sub SeleccionarItem(ByVal vAño As Int32, ByVal vNave As Int32, ByVal vLote As Int32)
        Dim ListaLotes As New List(Of Lote)
        Dim objBU As New LotesAvancesBU

        ListaLotes = objBU.MostrarInfoLote(vAño, vNave, vLote)

        If ListaLotes.Count > 0 Then
            txtNoLote.Text = ListaLotes(0).PLoteNumero
            txtPrograma.Text = FormatDateTime(ListaLotes(0).PLoteFecha.ToString, DateFormat.ShortDate)
            txtModelo.Text = ListaLotes(0).PLoteModelo
            txtTalla.Text = ListaLotes(0).PLoteTalla
            For Each lote As Lote In ListaLotes
                grdDetalles.AddItem("" + ControlChars.Tab + lote.PLoteDepartamentoAvance + ControlChars.Tab + lote.PLoteFechaAvance.ToString + ControlChars.Tab + lote.PLoteUsuarioAvance)
            Next
            If ListaLotes(0).PLoteFechaEmbarque <> "01/01/1900 00:00:00" Then
                grdDetalles.AddItem("" + ControlChars.Tab + "EMBARQUE" + ControlChars.Tab + ListaLotes(0).PLoteFechaEmbarque.ToString + ControlChars.Tab + "")
            End If
        End If

    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Hide()
    End Sub


    Private Sub AdmonAvancesDetalleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class