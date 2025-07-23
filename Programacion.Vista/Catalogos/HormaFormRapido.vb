Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class HormaFormRapido
    Private nombreHorma As String
    Private idHorma As String


    Public Property PnombreHorma As String
        Get
            Return nombreHorma
        End Get
        Set(ByVal value As String)
            nombreHorma = value
        End Set
    End Property

    Public Property PidHorma As String
        Get
            Return idHorma
        End Get
        Set(ByVal value As String)
            idHorma = value
        End Set
    End Property

    Public Sub llenarTablaHormas()
        Dim objHormas As New Programacion.Negocios.HormasBU
        Dim dtDAtosHormas As New DataTable
        dtDAtosHormas = objHormas.verListaHormas("", "", True)

        Me.grdHormas.DisplayLayout.Bands(0).Columns.Add("selectHorma", "")
        Dim colckbCr As UltraGridColumn = grdHormas.DisplayLayout.Bands(0).Columns("selectHorma")
        colckbCr.Style = ColumnStyle.Image
        grdHormas.DataSource = dtDAtosHormas

        With grdHormas.DisplayLayout.Bands(0)
            .Columns("horma_hormaid").Header.Caption = "Código"
            .Columns("horma_descripcion").Header.Caption = "Horma"
            .Columns("horma_activo").Hidden = True
            .Columns("horma_hormaid").CellActivation = Activation.NoEdit
            .Columns("horma_descripcion").CellActivation = Activation.NoEdit
            .Columns("horma_hormaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("selectHorma").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdHormas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub HormaFormRapido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarTablaHormas()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If (txtNombreHorma.Text <> Nothing) Then
            Dim objMensajeAceptar As New ConfirmarForm
            objMensajeAceptar.mensaje = "Esta seguro de guardar cambios."
            If objMensajeAceptar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objHorma As New Programacion.Negocios.HormasBU
                Dim entHorma As New Entidades.Hormas
                Dim dtIdMaximoHorma As New DataTable
                Dim dtDatosHorma As New DataTable
                entHorma.PHorma = txtNombreHorma.Text
                entHorma.PActivoHorma = True
                objHorma.guardarHorma(entHorma)
                dtIdMaximoHorma = objHorma.idMaximohorma
                PidHorma = dtIdMaximoHorma.Rows(0)(0).ToString
                dtDatosHorma = objHorma.verHormaId(idHorma)
                PnombreHorma = dtDatosHorma.Rows(0)(1).ToString
                Me.Close()
            Else

            End If
        Else
            MsgBox("Debe ingresar la descripción de la horma.")
        End If

    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        llenarTablaHormas()
    End Sub

    Private Sub txtNombreHorma_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreHorma.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreHorma.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreHorma.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        txtNombreHorma.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27
    End Sub

    Private Sub grdHormas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdHormas.ClickCell
        If e.Cell.Column.Key = "selectHorma" And e.Cell.Row.Index <> grdHormas.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PidHorma = grdHormas.Rows(fila).Cells("horma_hormaid").Value.ToString
            PnombreHorma = grdHormas.Rows(fila).Cells("horma_descripcion").Value.ToString
            Me.Close()
        End If

    End Sub

    Private Sub grdHormas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdHormas.InitializeRow
        If e.Row.Cells.Exists("selectHorma") Then
            e.Row.Cells("selectHorma").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub grdHormas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdHormas.InitializeLayout

    End Sub
End Class