Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Programacion.Negocios
Imports Tools

Public Class CatalogoJustificacionesForm


    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        ConfigurarSeguridad()
        LlenarTabla()
    End Sub

    Private Sub ConfigurarSeguridad()
        'Dim permiso As Boolean
        'permiso = PermisosUsuarioBU.ConsultarPermiso("PRG_AUTORIZAR", "WRITE")
        'btnAutorizar.Visible = permiso
        'lblAutorizar.Visible = permiso
    End Sub

    Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click
        Alta()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        editarJustificacion()
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnQuitar.Click
        With grdDatos
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Eliminar()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub





    Private Sub LlenarTabla()
        Dim vErrorForm As New ErroresForm
        Dim vCatJus As New CatalogoJustificacionesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vCatJus.JustificacionesTabla
            formatotabla()
        Catch ex As Exception
            vErrorForm.Text = "Justificaciones"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Public Sub formatotabla()
        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("id_").CellActivation = Activation.NoEdit
            .Columns("Mensaje").CellActivation = Activation.NoEdit
            .Columns("id_").CellAppearance.TextHAlign = HAlign.Right
            .Columns("id_").Header.Caption = ""
            .Columns("Mensaje").Header.Caption = ""
            .Columns("id_").Hidden = True
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdDatos.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag

        band.Columns("id_").Width = 15
    End Sub



    Public Sub editarJustificacion()
        Dim vPedirJustificacion As New PedirJustificacion
        Dim vDialogResult As New DialogResult
        Dim vExitoForm As New ExitoForm
        Dim vErrorForm As New ErroresForm
        Try
            vPedirJustificacion.pId = grdDatos.ActiveRow.Cells("id_").Value
            vPedirJustificacion.pJustificacion = grdDatos.ActiveRow.Cells("Mensaje").Value
            vDialogResult = vPedirJustificacion.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vExitoForm.Text = "Justificaciones"
                vExitoForm.mensaje = "Registro modificado con éxito"
                vExitoForm.ShowDialog()
                LlenarTabla()
            End If
        Catch ex As Exception
            vErrorForm.Text = "Justificaciones"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        End Try

    End Sub
    Private Sub Alta()
        Dim vPedirJustificacion As New PedirJustificacion
        Dim vDialogResult As New DialogResult
        Dim vExitoForm As New ExitoForm
        Dim vErrorForm As New ErroresForm
        vPedirJustificacion.pJustificacion = ""
        vPedirJustificacion.pId = 0
        Try
            vDialogResult = vPedirJustificacion.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vExitoForm.Text = "Justificaciones"
                vExitoForm.mensaje = "Registro guardado con éxito"
                vExitoForm.ShowDialog()
                LlenarTabla()
            End If
        Catch ex As Exception
            vErrorForm.Text = "Justificaciones"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        End Try
    End Sub

    Private Sub Eliminar()
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vCatJus As New CatalogoJustificacionesBU
        Dim vConfirmarForm As New ConfirmarForm
        Dim vDialogResult As New DialogResult
        Dim vExitoForm As New ExitoForm
        Dim vErrorForm As New ErroresForm
        Try
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Justificaciones"
            vConfirmarForm.mensaje = "¿ Desea eliminar el registro ?"
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vCatJus.Eliminar(grdDatos.ActiveRow.Cells("id_").Value)
                vExitoForm.Text = "Justificaciones"
                vExitoForm.mensaje = "Registro eliminado con éxito"
                vExitoForm.ShowDialog()
                LlenarTabla()
            End If



        Catch ex As Exception
            vErrorForm.Text = "Justificaciones"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class