Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CategoriaFormRapido
    Private idCategoria As Int32
    Private nombreCategoria As String

    Public Property PidCategoria As Int32
        Get
            Return idCategoria
        End Get
        Set(value As Int32)
            idCategoria = value
        End Set
    End Property

    Public Property PnombreCategoria As String
        Get
            Return nombreCategoria
        End Get
        Set(value As String)
            nombreCategoria = value
        End Set
    End Property


    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        txtNombreCategoria.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27
    End Sub

    Public Sub llenarListaCategorias()
        Dim objCatBU As New Negocios.CategoriasBU
        Dim dtListaCategorias As New DataTable
        dtListaCategorias = objCatBU.verListaCategorias(True)
        grdListaCategorias.DataSource = dtListaCategorias

        Me.grdListaCategorias.DisplayLayout.Bands(0).Columns.Add("selectCategoria", "")
        Dim colckbCr As UltraGridColumn = grdListaCategorias.DisplayLayout.Bands(0).Columns("selectCategoria")
        colckbCr.Style = ColumnStyle.Image

        With grdListaCategorias.DisplayLayout.Bands(0)
            .Columns("tica_tipocategoriaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tica_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tica_tipocategoriaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("tica_tipocategoriaid").Header.Caption = "Código"
            .Columns("tica_descripcion").Header.Caption = "Descripción"
            .Columns("tica_activo").Hidden = True
            .Columns("selectCategoria").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaCategorias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub CategoriaFormRapido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarListaCategorias()
    End Sub

    Private Sub grdListaCategorias_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaCategorias.ClickCell
        If e.Cell.Column.Key = "selectCategoria" And e.Cell.Row.Index <> grdListaCategorias.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PidCategoria = grdListaCategorias.Rows(fila).Cells("tica_tipocategoriaid").Value.ToString
            PnombreCategoria = grdListaCategorias.Rows(fila).Cells("tica_descripcion").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdListaCategorias_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaCategorias.InitializeRow
        If e.Row.Cells.Exists("selectCategoria") Then
            e.Row.Cells("selectCategoria").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub txtNombreCategoria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreCategoria.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreCategoria.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreCategoria.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txtNombreCategoria.Text <> Nothing) Then
            Dim objMensajeAceptar As New ConfirmarForm
            objMensajeAceptar.mensaje = "Esta seguro de guardar cambios."
            If objMensajeAceptar.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim objCategorias As New Programacion.Negocios.CategoriasBU
                Dim entCategoria As New Entidades.Categorias
                Dim dtIdMaximoCategoria As New DataTable
                Dim dtDatosCategoria As New DataTable
                entCategoria.PnombreCategoria = txtNombreCategoria.Text
                entCategoria.PactivoCategoria = True
                objCategorias.registrarEditaCategoria(entCategoria, True)
                dtIdMaximoCategoria = objCategorias.verIdMaxCategorias
                PidCategoria = dtIdMaximoCategoria.Rows(0)(0).ToString
                dtDatosCategoria = objCategorias.verCategoriaRapido(idCategoria)
                PnombreCategoria = dtDatosCategoria.Rows(0)(1).ToString

                Me.Close()
            Else

            End If
        Else
            MsgBox("Debe ingresar la descripción de la horma.")
        End If
    End Sub
End Class