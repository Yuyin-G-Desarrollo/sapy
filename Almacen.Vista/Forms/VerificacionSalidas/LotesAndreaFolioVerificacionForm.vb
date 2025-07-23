Imports DevExpress.XtraGrid.Views.Base
Imports Tools

Public Class LotesAndreaFolioVerificacionForm

    Public FolioVerificacionId As Integer = 0
    Dim ObjBU As New Negocios.VerificacionSalidasBU
    Dim ListaLotes As New List(Of Entidades.LotesAndreaFolioVerificacion)

    Private Sub LotesAndreaFolioVerificacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarPantalla()

    End Sub

    Public Sub CargarPantalla()

        ListaLotes = ObjBU.ConsultaLotesAndrea(FolioVerificacionId)
        grdLotesAndrea.DataSource = ListaLotes

        DiseñoGrid.DiseñoBaseGrid(viewLotesAndrea)
        viewLotesAndrea.BestFitColumns()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        Dim formaConfirmacion As New ConfirmarForm

        Try
            Cursor = Cursors.WaitCursor

            If ListaLotes.Where(Function(x) x.Seleccionar = True).Count > 0 Then


                formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
                formaConfirmacion.mensaje = "¿Estas seguro  de eliminar los lotes seleccionados?"

                If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim Elementos = ListaLotes.Where(Function(x) x.Seleccionar = True)

                    For Each Elemento As Entidades.LotesAndreaFolioVerificacion In Elementos
                        ObjBU.QuitarLotesAndrea(FolioVerificacionId, Elemento.OrdenTrabajoID, Elemento.LoteAndrea)
                    Next

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han eliminado los lotes correctamente.")
                    Me.Close()
                End If


            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Se debe de seleccionar al menos un lote.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each item As Entidades.LotesAndreaFolioVerificacion In ListaLotes
            item.Seleccionar = chkSeleccionar.Checked
        Next

        grdLotesAndrea.RefreshDataSource()
    End Sub

    Private Sub viewLotesAndrea_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles viewLotesAndrea.CellValueChanged

        Dim LoteAndrea As Integer = viewLotesAndrea.GetRowCellValue(e.RowHandle, "LoteAndrea")
        Dim Seleccionar As Boolean = viewLotesAndrea.GetRowCellValue(e.RowHandle, "Seleccionar")

        Dim EntidadOT As Entidades.LotesAndreaFolioVerificacion = ListaLotes.Where(Function(x) x.LoteAndrea = LoteAndrea).FirstOrDefault
        EntidadOT.Seleccionar = Seleccionar

        lblTotalSeleccionados.Text = CDbl(viewLotesAndrea.RowCount).ToString("N0")

    End Sub
End Class