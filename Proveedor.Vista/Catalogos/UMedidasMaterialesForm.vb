Imports Proveedores.BU
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing

Public Class UMedidasMaterialesForm
    Dim adv As New AdvertenciaForm
    Dim id As New Integer
    Dim exito As New ExitoForm
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub UMedidasMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New UnidadDeMedidaMaterialesBU
            grdUnidadMedida.DataSource = obj.getUnidadesMedidas(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdUnidadMedida.DisplayLayout.Bands(0)
            .Columns("Código").Width = 35
            .Columns("Código").Header.Caption = "ID"
        End With
        grdUnidadMedida.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdUnidadMedida.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub grdUnidadMedida_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdUnidadMedida.ClickCell
        Try
            grdUnidadMedida.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If grdUnidadMedida.Rows.Count > 0 Then
            If grdUnidadMedida.ActiveRow.Selected Then
                actualizar()
            End If
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        insertar()
    End Sub
    Public Sub insertar()
        Dim obj As New UnidadDeMedidaMaterialesBU
        Dim form As New AltaCampos
        form.lblsicy.Visible = False
        form.txtSicy.Visible = False
        form.lblsku.Visible = False
        form.txtsku.Visible = False
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.cmbClasificacion.Visible = False
        form.lblClasificacion.Visible = False
        form.pnlGrid.Visible = False
        form.lblDescripcion.Text = "Unidad de Medida"
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblUm.Visible = True
        form.lblTitulo.Text = "Alta/Edición Unidad de Medida"
        form.lblTitulo.Location = New Point(90, 23)
        form.Size = New Drawing.Size(423, 300)
        form.ShowDialog()
        If form.cerrado = 1 Then
            If obj.verificarUnidadesMedidas(form.txtDescripcion.Text).Rows.Count > 0 Then
                adv.mensaje = "La unidad de medida ya está registrada."
                adv.ShowDialog()
            Else
                obj.insertUnidadesMedidas(form.txtDescripcion.Text)
                exito.mensaje = "Unidad de medida registrada con éxito."
                exito.ShowDialog()
                llenarGrid()
            End If

        End If
    End Sub
    Public Sub actualizar()
        Dim obj As New UnidadDeMedidaMaterialesBU
        Dim form As New AltaCampos
        form.lblsicy.Visible = False
        form.txtSicy.Visible = False
        form.lblsku.Visible = False
        form.txtsku.Visible = False
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.cmbClasificacion.Visible = False
        form.lblClasificacion.Visible = False
        form.pnlGrid.Visible = False
        form.lblDescripcion.Text = "Unidad de Medida"
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblUm.Visible = True
        form.Size = New Drawing.Size(423, 300)
        form.lblTitulo.Text = "Alta/Edición Unidad de Medida"
        form.lblTitulo.Location = New Point(90, 23)
        form.txtId.Text = grdUnidadMedida.ActiveRow.Cells("Código").Text
        form.txtDescripcion.Text = grdUnidadMedida.ActiveRow.Cells("Unidad de Medida").Text
        If grdUnidadMedida.ActiveRow.Cells("Activo").Value Then
            form.rdboActivo.Checked = True
            form.rdboInactivo.Checked = False
        Else
            form.rdboActivo.Checked = False
            form.rdboInactivo.Checked = True
        End If
        form.ShowDialog()
        Dim status As Integer = 1
        If form.rdboActivo.Checked Then
            status = 1
        Else
            status = 0
        End If
        If form.cerrado = 1 Then
            obj.updateUnidadesMedidas(form.txtId.Text, form.txtDescripcion.Text, status)
            exito.mensaje = "Unidad de medida actualizada con éxito."
            exito.ShowDialog()
            llenarGrid()
        End If
    End Sub

    Private Sub grdUnidadMedida_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdUnidadMedida.DoubleClickCell
        If grdUnidadMedida.Rows.Count > 0 Then
            If grdUnidadMedida.ActiveRow.Selected Then
                actualizar()
            End If
        End If
    End Sub
End Class