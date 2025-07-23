Imports Proveedores.BU
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing

Public Class TiposMaterialesForm
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim id As Integer = 0
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub TiposMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New TiposMaterialesBU
            grdTiposMateriales.DataSource = obj.getTiposMateriales(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdTiposMateriales.DisplayLayout.Bands(0)
            .Columns("Código").Width = 35
            .Columns("Código").Header.Caption = "ID"
        End With
        grdTiposMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdTiposMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub
    Public Sub insertar()
        Dim obj As New TiposMaterialesBU
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
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblTipoMaterial.Visible = True
        form.lblDescripcion.Text = "Tipo Material"
        form.Size = New Drawing.Size(423, 300)
        form.lblTitulo.Text = "Alta/Edición Tipo Material"
        form.lblTitulo.Location = New Point(130, 23)
        form.ShowDialog()
        If form.cerrado = 1 Then
            If obj.verificarTiposMateriales(form.txtDescripcion.Text).Rows.Count > 0 Then
                adv.mensaje = "El tipo de material ya está registrado."
                adv.ShowDialog()
            Else
                obj.insertTiposMateriales(form.txtDescripcion.Text)
                exito.mensaje = "Tipo de material registrado con éxito."
                exito.ShowDialog()
                llenarGrid()
            End If

        End If
    End Sub
    Public Sub actualizar()
        Dim obj As New TiposMaterialesBU
        Dim status As Integer = 1
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
        form.MaximizeBox = False
        form.lblTipoMaterial.Visible = True
        form.lblDescripcion.Text = "Tipo Material"
        form.MinimizeBox = False
        form.lblTitulo.Text = "Alta/Edición Tipo Material"
        form.lblTitulo.Location = New Point(130, 23)
        form.Size = New Drawing.Size(423, 300)
        If grdTiposMateriales.Rows.Count > 0 Then
            If grdTiposMateriales.ActiveRow.Selected Then
                form.txtId.Text = grdTiposMateriales.ActiveRow.Cells("Código").Text
                form.txtDescripcion.Text = grdTiposMateriales.ActiveRow.Cells("Tipo").Text
                If grdTiposMateriales.ActiveRow.Cells("Activo").Value Then
                    form.rdboActivo.Checked = True
                    form.rdboInactivo.Checked = False
                Else
                    form.rdboActivo.Checked = False
                    form.rdboInactivo.Checked = True
                End If

                form.ShowDialog()
                If form.rdboActivo.Checked Then
                    status = 1
                Else
                    status = 0
                End If
                If form.cerrado = 1 Then
                    obj.updateTiposMateriales(form.txtId.Text, form.txtDescripcion.Text, status)
                    exito.mensaje = "Tipo de material registrado con éxito."
                    exito.ShowDialog()
                End If

            End If
        End If

    End Sub


    Private Sub grdTiposMateriales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdTiposMateriales.ClickCell
        Try
            grdTiposMateriales.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdTiposMateriales_DoubleClick(sender As Object, e As EventArgs) Handles grdTiposMateriales.DoubleClick
        Try
            grdTiposMateriales.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        actualizar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        insertar()
        llenarGrid()
    End Sub

    Private Sub grdTiposMateriales_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdTiposMateriales.DoubleClickCell
        actualizar()
    End Sub
End Class