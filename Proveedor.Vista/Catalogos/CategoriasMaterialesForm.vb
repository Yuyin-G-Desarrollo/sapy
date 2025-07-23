Imports Proveedores.BU
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing

Public Class CategoriasMaterialesForm
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim id As Integer = 0
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub
    Private Sub CategoriasMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New CategoriasMaterialesBU
            grdCategorias.DataSource = obj.getCategoriasMateriales(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdCategorias.DisplayLayout.Bands(0)
            .Columns("Código").Width = 35
            .Columns("Código").Header.Caption = "ID"
        End With
        grdCategorias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdCategorias.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdCategorias.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub


    Private Sub grdCategorias_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCategorias.ClickCell
        Try
            grdCategorias.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdCategorias_DoubleClick(sender As Object, e As EventArgs) Handles grdCategorias.DoubleClick
        Try
            grdCategorias.ActiveRow.Selected = True

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        insertar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If grdCategorias.Rows.Count > 0 Then
            If grdCategorias.ActiveRow.Selected Then
                  actualizar()
            End If
        End If
    End Sub

    Public Sub insertar()
        Dim obj As New CategoriasMaterialesBU
        Dim form As New AltaCampos
        Dim dtGiros As New DataTable

        dtGiros = obj.ObtieneGiroDeNave()

        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.cmbClasificacion.Visible = False
        form.lblClasificacion.Visible = False
        form.pnlGrid.Visible = False
        form.MaximizeBox = False
        form.MinimizeBox = False
        'form.lblCat.Visible = True
        form.lblCatego.Visible = True
        form.Size = New Drawing.Size(423, 300)
        form.lblTitulo.Text = "Alta/Edición de Categorías"
        form.lblTitulo.Location = New Point(130, 23)
        form.lblDescripcion.Text = "  Categoría"

        If dtGiros.Rows.Count > 0 Then
            form.lblGiro.Visible = True
            form.cmbGiro.Visible = True
            dtGiros.Rows.InsertAt(dtGiros.NewRow, 0)
            form.cmbGiro.DataSource = dtGiros
            form.cmbGiro.ValueMember = "ID"
            form.cmbGiro.DisplayMember = "GIRO"
        End If

        form.ShowDialog()

        If form.cerrado = 1 Then
            If obj.verificarCategoria(form.txtDescripcion.Text).Rows.Count > 0 Then
                adv.mensaje = "La categoría ya está registrada."
                adv.ShowDialog()
            Else

                If form.cmbGiro.SelectedIndex <> 0 Then
                    obj.inserCategoriasMateriales(form.txtDescripcion.Text, form.cmbGiro.SelectedValue, 0)
                    exito.mensaje = "Categoría registrada con éxito."
                    exito.ShowDialog()
                    llenarGrid()
                Else
                    Tools.MostrarMensaje(Mensajes.Warning, "Seleccione un giro para la categoría.")
                    Exit Sub
                End If


            End If
        End If

    End Sub
    Public Sub actualizar()
        Dim obj As New CategoriasMaterialesBU
        Dim form As New AltaCampos
        Dim dtGiros As New DataTable

        dtGiros = obj.ObtieneGiroDeNave()
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.cmbClasificacion.Visible = False
        form.lblClasificacion.Visible = False
        form.pnlGrid.Visible = False
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblGiro.Visible = True
        form.cmbGiro.Visible = True
        'form.lblCat.Visible = True
        form.lblCatego.Visible = True
        form.lblDescripcion.Text = "  Categoría"
        form.Size = New Drawing.Size(423, 300)
        form.lblTitulo.Text = "Alta/Edición de Categorías"
        form.lblTitulo.Location = New Point(130, 23)
        form.txtId.Text = grdCategorias.ActiveRow.Cells("Código").Text
        form.txtDescripcion.Text = grdCategorias.ActiveRow.Cells("Categoría").Text

        If grdCategorias.ActiveRow.Cells("Activo").Value Then
            form.rdboActivo.Checked = True
            form.rdboInactivo.Checked = False
        Else
            form.rdboActivo.Checked = False
            form.rdboInactivo.Checked = True

        End If

        If dtGiros.Rows.Count > 0 Then
            form.lblGiro.Visible = True
            form.cmbGiro.Visible = True
            'dtGiros.Rows.InsertAt(dtGiros.NewRow, 0)
            form.cmbGiro.DataSource = dtGiros
            form.cmbGiro.ValueMember = "ID"
            form.cmbGiro.DisplayMember = "GIRO"
            form.cmbGiro.Text = grdCategorias.ActiveRow.Cells("Giro").Text
        End If

        form.ShowDialog()

        Dim status As Integer = 1
        If form.rdboActivo.Checked Then
            status = 1
        Else
            status = 0
        End If
        If form.cerrado = 1 Then
            Dim Giro As Integer = 0

            If form.cmbGiro.SelectedIndex <> 0 Or form.cmbGiro.Text <> "" Then
                Giro = form.cmbGiro.SelectedValue
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione un Giro para el material.")
            End If

            obj.updateCategoriasMateriales(form.txtId.Text, form.txtDescripcion.Text, status, Giro)
            exito.mensaje = "Categoría actualizada con éxito."
            exito.ShowDialog()
            llenarGrid()

        End If
    End Sub

    Private Sub grdCategorias_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdCategorias.DoubleClickCell
        Try
            If grdCategorias.Rows.Count > 0 Then
                If grdCategorias.ActiveRow.Selected Then
                    actualizar()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class