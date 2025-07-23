Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class grupoRapidoForm
    Private codGrupo As Int32
    Private nombreGrupo As String

    Public Property PcodGrupo As Int32
        Get
            Return codGrupo
        End Get
        Set(value As Int32)
            codGrupo = value
        End Set
    End Property

    Public Property PnombreGrupo As String
        Get
            Return nombreGrupo
        End Get
        Set(value As String)
            nombreGrupo = value
        End Set
    End Property

    Public Sub llenarTablaGrupos()
        Dim objGrupo As New Programacion.Negocios.GruposBU
        Dim dtDatosGrupos As New DataTable
        dtDatosGrupos = objGrupo.verComboGrupos("")

        Me.grdGrupos.DisplayLayout.Bands(0).Columns.Add("selectGrupo", "")
        Dim colckbCr As UltraGridColumn = grdGrupos.DisplayLayout.Bands(0).Columns("selectGrupo")
        colckbCr.Style = ColumnStyle.Image

        grdGrupos.DataSource = dtDatosGrupos

        With grdGrupos.DisplayLayout.Bands(0)
            .Columns("grpo_grupoid").Header.Caption = "Código"
            .Columns("grpo_descripcion").Header.Caption = "Grupo"
            .Columns("grpo_grupoid").CellActivation = Activation.NoEdit
            .Columns("grpo_descripcion").CellActivation = Activation.NoEdit
            .Columns("grpo_grupoid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("selectGrupo").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdGrupos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Public Function validarVacio() As Boolean
        If (txtNombreGrupo.Text = "") Then
            Return False
        End If
        Return True
    End Function

    Public Sub registratGrupo()
        Dim objGrupo As New Programacion.Negocios.GruposBU
        Dim entGrupo As New Entidades.Grupos
        entGrupo.PGActivo = True
        entGrupo.PGDescripcion = txtNombreGrupo.Text
        objGrupo.RegistrarGrupo(entGrupo)
        Dim dtDAosRegistrados As DataTable = objGrupo.VerIdMaximoGrupos()
        PcodGrupo = dtDAosRegistrados.Rows(0)(0).ToString
        PnombreGrupo = dtDAosRegistrados.Rows(0)(1).ToString
    End Sub

    Private Sub grupoRapidoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarTablaGrupos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If (validarVacio() = True) Then
            Dim objMensajeAceptar As New ConfirmarForm
            objMensajeAceptar.mensaje = "Esta seguro de guardar cambios."
            If objMensajeAceptar.ShowDialog = Windows.Forms.DialogResult.OK Then
                registratGrupo()
                Me.Close()
            End If
        ElseIf (validarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)
        llenarTablaGrupos()
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            llenarTablaGrupos()
        End If
    End Sub

    Private Sub txtNombreGrupo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombreGrupo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreGrupo.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreGrupo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        txtNombreGrupo.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27
    End Sub

    Private Sub grdGrupos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdGrupos.ClickCell
        If e.Cell.Column.Key = "selectGrupo" And e.Cell.Row.Index <> grdGrupos.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PcodGrupo = grdGrupos.Rows(fila).Cells("grpo_grupoid").Value.ToString
            PnombreGrupo = grdGrupos.Rows(fila).Cells("grpo_descripcion").Value.ToString
            Me.Close()
        End If

    End Sub

    Private Sub grdGrupos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdGrupos.InitializeRow
        If e.Row.Cells.Exists("selectGrupo") Then
            e.Row.Cells("selectGrupo").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub
End Class