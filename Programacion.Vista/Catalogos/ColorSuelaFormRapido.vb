Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class ColorSuelaFormRapido
    Private IdSuelaColor As Int32
    Private NombreColor As String

    Public Property PIdSuelaColor As Int32
        Get
            Return IdSuelaColor
        End Get
        Set(value As Int32)
            IdSuelaColor = value
        End Set
    End Property

    Public Property PNombreColor As String
        Get
            Return NombreColor
        End Get
        Set(value As String)
            NombreColor = value
        End Set
    End Property

    Public Sub llenarListaColorSuela()
        Dim objCatBU As New Negocios.CategoriasBU
        Dim dtListaColorSuela As New DataTable
        dtListaColorSuela = objCatBU.verListaColorSuela(True)
        grdListaColorSuelas.DataSource = dtListaColorSuela

        Me.grdListaColorSuelas.DisplayLayout.Bands(0).Columns.Add("selectCategoria", "")
        Dim colckbCr As UltraGridColumn = grdListaColorSuelas.DisplayLayout.Bands(0).Columns("selectCategoria")
        colckbCr.Style = ColumnStyle.Image

        With grdListaColorSuelas.DisplayLayout.Bands(0)
            .Columns("cosu_colorsuelaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cosu_nombrecolor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cosu_colorsuelaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("cosu_colorsuelaid").Header.Caption = "ID"
            .Columns("cosu_nombrecolor").Header.Caption = "Descripción"
            .Columns("cosu_activo").Hidden = True
            .Columns("selectCategoria").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With
        grdListaColorSuelas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub grdListaColorSuelas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaColorSuelas.ClickCell
        If e.Cell.Column.Key = "selectCategoria" And e.Cell.Row.Index <> grdListaColorSuelas.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PIdSuelaColor = grdListaColorSuelas.Rows(fila).Cells("cosu_colorsuelaid").Value.ToString
            PNombreColor = grdListaColorSuelas.Rows(fila).Cells("cosu_nombrecolor").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdListaColorSuelas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaColorSuelas.InitializeRow
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
                PIdSuelaColor = dtIdMaximoCategoria.Rows(0)(0).ToString
                dtDatosCategoria = objCategorias.verCategoriaRapido(PIdSuelaColor)
                PNombreColor = dtDatosCategoria.Rows(0)(1).ToString
                Me.Close()
            Else
            End If
        Else
            MsgBox("Debe ingresar la descripción del Color de la Suela.")
        End If
    End Sub

    Private Sub ColorSuelaFormRapido_Load(sender As Object, e As EventArgs) Handles Me.Load
        llenarListaColorSuela()
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs)
        txtNombreCategoria.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        pnlHeader.Height = 27
    End Sub
End Class