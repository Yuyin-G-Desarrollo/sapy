Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class SuelaFormRapido

    Private IdSuela As Int32
    Private NombreSuela As String

    Public Property PIdSuela As Int32
        Get
            Return IdSuela
        End Get
        Set(value As Int32)
            IdSuela = value
        End Set
    End Property

    Public Property PNombreSuela As String
        Get
            Return NombreSuela
        End Get
        Set(value As String)
            NombreSuela = value
        End Set
    End Property


    Private Sub btnDown_Click(sender As Object, e As EventArgs)
        txtNombreCategoria.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs)
        pnlHeader.Height = 27
    End Sub

    Public Sub llenarListaSuelas()
        Dim objCatBU As New Negocios.CategoriasBU
        Dim dtListaSuelas As New DataTable
        dtListaSuelas = objCatBU.verListaSuelas(True)
        grdListaSuelas.DataSource = dtListaSuelas

        Me.grdListaSuelas.DisplayLayout.Bands(0).Columns.Add("selectCategoria", "")
        Dim colckbCr As UltraGridColumn = grdListaSuelas.DisplayLayout.Bands(0).Columns("selectCategoria")
        colckbCr.Style = ColumnStyle.Image

        With grdListaSuelas.DisplayLayout.Bands(0)
            .Columns("SuelaID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Suela").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SuelaID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("SuelaID").Header.Caption = "ID"
            .Columns("Suela").Header.Caption = "Descripción"
            .Columns("Activo").Hidden = True
            .Columns("selectCategoria").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListaSuelas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub grdListaSuelas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaSuelas.ClickCell
        If e.Cell.Column.Key = "selectCategoria" And e.Cell.Row.Index <> grdListaSuelas.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PIdSuela = grdListaSuelas.Rows(fila).Cells("SuelaID").Value.ToString
            PNombreSuela = grdListaSuelas.Rows(fila).Cells("Suela").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdListaSuelas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaSuelas.InitializeRow
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
                PIdSuela = dtIdMaximoCategoria.Rows(0)(0).ToString
                dtDatosCategoria = objCategorias.verCategoriaRapido(PIdSuela)
                PNombreSuela = dtDatosCategoria.Rows(0)(1).ToString
                Me.Close()
            Else

            End If
        Else
            MsgBox("Debe ingresar la descripción de la suela.")
        End If


    End Sub

    Private Sub SuelaFormRapido_Load(sender As Object, e As EventArgs) Handles Me.Load
        llenarListaSuelas()
    End Sub
End Class