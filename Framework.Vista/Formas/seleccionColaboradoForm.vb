Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class seleccionColaboradoForm
    Private ColabId As String = ""
    Private NombreCol As String = ""

    Public Property PidColaborador As String
        Get
            Return ColabId
        End Get
        Set(ByVal value As String)
            ColabId = value
        End Set
    End Property

    Public Property PnombeColaborador As String
        Get
            Return NombreCol
        End Get
        Set(ByVal value As String)
            NombreCol = value
        End Set
    End Property


    'Public Sub llenarTablaColaborador()
    '    Dim objColaborador As New Framework.Negocios.ModulosBU
    '    Dim dtDatosColaborador As New DataTable
    '    dtDatosColaborador = objColaborador.verColaboradoresCombo

    '    With grdColaboradores
    '        .DataSource = dtDatosColaborador
    '        .Columns(0).Width = 50
    '        .Columns(2).ReadOnly = True
    '        .Columns(2).HeaderText = "Colaborador"
    '        .Columns(1).Visible = False
    '    End With

    'End Sub

    Public Sub llenarTablaColaboradorUltra()
        Dim objColaborador As New Framework.Negocios.ModulosBU
        Dim dtDatosColaborador As New DataTable
        dtDatosColaborador = objColaborador.verColaboradoresCombo


        With grdDatosColaborador
            grdDatosColaborador.DisplayLayout.Bands(0).Columns.Add("select", "")
            grdDatosColaborador.DisplayLayout.Bands(0).Columns("select").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
            grdDatosColaborador.Rows.Band.Columns("select").ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
            grdDatosColaborador.DisplayLayout.Bands(0).Columns("select").Header.VisiblePosition = 0

            .DataSource = dtDatosColaborador
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Colaborador"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Width = 300
            .DisplayLayout.Bands(0).Columns(2).Width = 50
            .DisplayLayout.Bands(0).Columns(1).CellActivation = Activation.NoEdit

            '.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            '.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
            '.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            '.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]


            'Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
            'Appearance22.ForeColor = System.Drawing.Color.White
            'Appearance22.ImageBackgroundStretchMargins = New Infragistics.Win.ImageBackgroundStretchMargins(1, 1, 1, 4)
            'Appearance22.ImageBackgroundStyle = Infragistics.Win.ImageBackgroundStyle.Stretched
            '.DisplayLayout.Override.SelectedRowAppearance = Appearance22
            '.DisplayLayout.Bands(0).Summaries.Clear()

            '.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.AliceBlue
            '.DisplayLayout.Override.RowAlternateAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
            '.DisplayLayout.Bands(0).Columns(2).AllowRowFiltering = DefaultableBoolean.False
            '.DisplayLayout.Appearance.BackColor = Color.LightSteelBlue
            '.DisplayLayout.Appearance.BorderColor = Color.DarkGray
        End With

    End Sub

    Private Sub seleccionColaboradoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarTablaColaboradorUltra()
    End Sub



    'Private Sub grdColaboradores_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 AndAlso sender.columns(e.ColumnIndex).GetType() = GetType(DataGridViewButtonColumn) Then
    '        PidColaborador = grdColaboradores.Item(1, e.ColumnIndex).Value.ToString
    '        PnombeColaborador = grdColaboradores.Item(2, e.ColumnIndex).Value.ToString
    '        Me.Close()
    '    End If
    'End Sub

    Private Sub grdDatosColaborador_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles grdDatosColaborador.ClickCellButton
        PidColaborador = grdDatosColaborador.Rows(e.Cell.Row.Index).Cells(0).Value.ToString
        PnombeColaborador = grdDatosColaborador.Rows(e.Cell.Row.Index).Cells(1).Value.ToString
        Me.Close()
    End Sub
End Class