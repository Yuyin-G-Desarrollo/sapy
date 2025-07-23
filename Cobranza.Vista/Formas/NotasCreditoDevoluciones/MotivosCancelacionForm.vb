Imports Cobranza.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class MotivosCancelacionForm
    Dim motivoId As Integer = 0
    Dim tipoActivo As Boolean
    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim altaMotivoCancelacion As New AltaMotivoCancelacionForm
        altaMotivoCancelacion.motivoId = 0
        altaMotivoCancelacion.ShowDialog()
    End Sub
    Private Sub diseñoGridCatalogoMotivos(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvMotivosCancelaciones) '' pone color a las filas del gridview
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvMotivosCancelaciones.Columns
            If col.FieldName = " " Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 5
            End If
            If col.FieldName = "Id" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 15
            End If
            If col.FieldName = "Descripcion" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 90
            End If
            If col.FieldName = "Usuario Creo" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Fecha Creación" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 60
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvMotivosCancelaciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.IndicatorWidth = 30
    End Sub
    Private Sub wvMotivosCancelaciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles wvMotivosCancelaciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnCerrarMotivos_Click(sender As Object, e As EventArgs) Handles btnCerrarMotivos.Click
        Me.Close()
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editarMotivoCancelacion()
    End Sub
    Private Sub editarMotivoCancelacion()
        Dim objMotivoEdicion As New NotaCreditoDevolucionesBU
        Dim dtMotivoEdicion As New DataTable
        Dim altaMotivoCancelacion As New AltaMotivoCancelacionForm
        If wvMotivosCancelaciones.RowCount > 0 Then
            validarSeleccionMotivo()
            If motivoId > 0 Then
                dtMotivoEdicion = objMotivoEdicion.obtenerMotivoCancelacionEdicion(motivoId)
                If dtMotivoEdicion.Rows.Count > 0 Then
                    altaMotivoCancelacion.motivoDescripcion = dtMotivoEdicion.Rows(0).Item(0)
                    altaMotivoCancelacion.activo = dtMotivoEdicion.Rows(0).Item(1)
                    altaMotivoCancelacion.motivoId = motivoId
                    altaMotivoCancelacion.ShowDialog()
                End If
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay registros para editar.")
        End If
    End Sub
    Private Function validarSeleccionMotivo()
        Dim numeroFilas As Integer
        Dim FilasSeleccionadas As Integer = 0
        numeroFilas = wvMotivosCancelaciones.DataRowCount
        For index As Integer = 0 To numeroFilas Step 1
            If CBool(wvMotivosCancelaciones.GetRowCellValue(wvMotivosCancelaciones.GetVisibleRowHandle(index), " ") = True) Then
                FilasSeleccionadas += 1
                motivoId = CInt(wvMotivosCancelaciones.GetRowCellValue(wvMotivosCancelaciones.GetVisibleRowHandle(index), "Id")).ToString()
            End If
        Next
        If FilasSeleccionadas = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Debe de seleccionar al menos un registro.")
            motivoId = 0
        End If
        If FilasSeleccionadas > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Solo se puede editar un motivo de cancelación a la vez.")
            motivoId = 0
        End If
        Return motivoId
    End Function
    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Dim Confirmar As New ConfirmarForm
        tipoActivo = 0
        Confirmar.mensaje = "¿Desea desactivar el motivo de cancelación?"
        If Confirmar.ShowDialog() = DialogResult.OK Then
            activaDesactivaMotivoCancelacion()
        End If
    End Sub
    Private Sub activaDesactivaMotivoCancelacion()
        Dim objActivaDesactiva As New NotaCreditoDevolucionesBU
        Dim Confirmar As New ConfirmarForm
        validarSeleccionMotivo()
        If motivoId > 0 Then
            objActivaDesactiva.activaDesactivarMotivoCancelacion(motivoId, tipoActivo)
            If tipoActivo = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Motivo Desactivado Correctamente.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Motivo Activo Correctamente.")
            End If
        End If
    End Sub
    Private Sub btnActivar_Click(sender As Object, e As EventArgs) Handles btnActivar.Click
        Dim Confirmar As New ConfirmarForm
        tipoActivo = 1
        Confirmar.mensaje = "¿Desea activar el motivo de cancelación?"
        If Confirmar.ShowDialog() = DialogResult.OK Then
            activaDesactivaMotivoCancelacion()
        End If
    End Sub
    Private Sub btnMostrarMotivos_Click(sender As Object, e As EventArgs) Handles btnMostrarMotivos.Click
        mostrarCatalogoMotivosCancelacion()
    End Sub
    Private Sub mostrarCatalogoMotivosCancelacion()
        Dim objMotivos As New NotaCreditoDevolucionesBU
        Dim dtMotivosCancelacion As New DataTable
        Dim tipoActivo As Boolean
        If rpActivoSi.Checked = False And rpActivoNo.Checked = False Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario seleccionar un tipo de activación.")
        Else
            If rpActivoSi.Checked = True Then
                tipoActivo = True
            Else
                tipoActivo = False
            End If
            dtMotivosCancelacion = objMotivos.consultaCatalogoMotivosCancelacion(tipoActivo)
            If dtMotivosCancelacion.Rows.Count > 0 Then
                grdMotivosCancelacion.DataSource = dtMotivosCancelacion
                lblTotalRegistros.Text = dtMotivosCancelacion.Rows.Count
                diseñoGridCatalogoMotivos(wvMotivosCancelaciones)
                lblfechaUltimaActualizacion.Text = Now
                lblfechaUltimaActualizacion.Visible = True
                If rpActivoSi.Checked = True Then
                    btnDesactivar.Enabled = True
                    lbldesactivar.Enabled = True
                    btnActivar.Enabled = False
                    lblActivar.Enabled = False
                    btnEditar.Enabled = True
                    lblEditar.Enabled = True
                Else
                    btnDesactivar.Enabled = False
                    lbldesactivar.Enabled = False
                    btnActivar.Enabled = True
                    lblActivar.Enabled = True
                    btnEditar.Enabled = False
                    lblEditar.Enabled = False
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontrarón registros.")
                wvMotivosCancelaciones.Columns.Clear()
                grdMotivosCancelacion.DataSource = Nothing
            End If
        End If

    End Sub
    Private Sub MotivosCancelacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnActivar.Enabled = False
        lblActivar.Enabled = False
        btnDesactivar.Enabled = False
        lbldesactivar.Enabled = False
    End Sub
End Class