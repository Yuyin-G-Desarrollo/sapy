Imports Entidades

Public Class FacturacionAnticipada_DetalleBodegaTiendaCoppel_Form

    Private bodega As BodegaCoppel
    Private tiendas As List(Of TiendaCoppel)
    Private objBu As New Negocios.FacturacionAnticipadaCoppelBU

    Private Sub FacturacionAnticipada_DetalleBodegaTiendaCoppel_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarForm()
    End Sub

    Private Sub BloquearControles()
        If bodega Is Nothing Then
            txtBodega.Enabled = True
        Else
            txtBodega.Enabled = False
        End If
    End Sub

    Private Sub CargarForm()
        BloquearControles()
        txtCliente.Text = "COPPEL"
        If bodega IsNot Nothing Then
            txtBodega.Text = bodega.Nombre
        End If
        CargarTiendas()
        Disenio_Grid()
    End Sub

    Private Sub Disenio_Grid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosTiendas)

        grdDatosTiendas.Columns(0).OptionsColumn.AllowEdit = True

        grdDatosTiendas.Columns("TiendaID").Visible = False
        grdDatosTiendas.Columns("BodegaID").Visible = False

        grdDatosTiendas.BestFitColumns()
    End Sub

    Public Sub PasarBodega(pbodega As BodegaCoppel)
        Me.bodega = pbodega
    End Sub

    Public Sub CargarTiendas()
        Dim dt As DataTable
        dt = objBu.ConsultarTiendas()

        If bodega IsNot Nothing Then
            For Each row In dt.Rows
                If row("BodegaID").ToString.Equals(bodega.Id.ToString) Then
                    row("Seleccionar") = 1
                End If
            Next

        End If

        grdTiendas.DataSource = dt

    End Sub

    Private Sub GuardarBodegaTienda()
        Dim nombreBodega As String = String.Empty
        Dim idTiendas As String = String.Empty
        Dim confirmar As New ConfirmarForm

        nombreBodega = txtBodega.Text

        For index = 0 To grdDatosTiendas.DataRowCount - 1
            If CBool(grdDatosTiendas.GetRowCellValue(index, "Seleccionar").ToString) Then
                If index = 0 Then
                    idTiendas += " " + Replace(grdDatosTiendas.GetRowCellValue(index, "TiendaID").ToString, ",", "")
                Else
                    idTiendas += ", " + Replace(grdDatosTiendas.GetRowCellValue(index, "TiendaID").ToString, ",", "")
                End If
            End If

        Next

        confirmar.mensaje = "Las tiendas seleccionadas ya vinculadas a otras bodegas se van a actualizar. ¿Desea guardar los cambios?"

        If confirmar.ShowDialog = DialogResult.OK Then
            objBu.RegistrarBodegaTienda(0, nombreBodega, idTiendas)
        End If

    End Sub

    Private Sub EditarBodegaTienda()
        Dim idBodega As Integer = 0
        Dim idTiendas As String = String.Empty
        Dim confirmar As New ConfirmarForm

        idBodega = bodega.Id

        For index = 0 To grdDatosTiendas.DataRowCount - 1
            If CBool(grdDatosTiendas.GetRowCellValue(index, "Seleccionar").ToString) Then
                If index = 0 Then
                    idTiendas += " " + Replace(grdDatosTiendas.GetRowCellValue(index, "TiendaID").ToString, ",", "")
                Else
                    idTiendas += ", " + Replace(grdDatosTiendas.GetRowCellValue(index, "TiendaID").ToString, ",", "")
                End If
            End If

        Next

        confirmar.mensaje = "Las tiendas seleccionadas ya vinculadas a otras bodegas se van a actualizar. ¿Desea guardar los cambios?"

        If confirmar.ShowDialog = DialogResult.OK Then
            objBu.RegistrarBodegaTienda(idBodega, "", idTiendas)
        End If
    End Sub

    Private Sub RegistrarInformacionBodega()
        If bodega Is Nothing Then
            GuardarBodegaTienda()
        Else
            EditarBodegaTienda()
        End If
        bodega = Nothing
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        RegistrarInformacionBodega()
        Me.Close()
    End Sub

    Private Sub grdDatosTiendas_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdDatosTiendas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class