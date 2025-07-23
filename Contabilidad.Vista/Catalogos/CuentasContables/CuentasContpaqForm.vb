Imports Contabilidad.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraEditors.Repository

Public Class CuentasContpaqForm
    Public BD As String = String.Empty
    Dim objN As New CuentasContablesBU
    Dim tablaCuentas As New DataTable
    Public idCuenta As Integer
    Public idCodigo As String
    Public nombreCuentas As String

    Private Sub CuentasContpaqForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tablaCuentas = objN.ConsultaCuentasporEmpresa(BD)
        grdCuentas.DataSource = tablaCuentas
        If tablaCuentas.Rows.Count > 0 Then
            diseñoCuentas()
            formatos()
        End If
    End Sub

    Private Sub grdVCuentas_DoubleClick(sender As Object, e As EventArgs) Handles grdVCuentas.DoubleClick
        idCuenta = grdVCuentas.GetFocusedRowCellValue("Id")
        idCodigo = grdVCuentas.GetFocusedRowCellValue("Codigo")
        nombreCuentas = grdVCuentas.GetFocusedRowCellValue("Nombre")
        Me.Close()
    End Sub

    Public Sub diseñoCuentas()
        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New DevExpress.XtraEditors.FormatConditionRuleExpression()

        grdVCuentas.IndicatorWidth = 40

        grdVCuentas.Columns("Id").Visible = False

        grdVCuentas.Columns("Id").OptionsColumn.AllowEdit = False
        grdVCuentas.Columns("Codigo").OptionsColumn.AllowEdit = False
        grdVCuentas.Columns("Nombre").OptionsColumn.AllowEdit = False

        grdVCuentas.Columns("Codigo").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVCuentas.Columns("Nombre").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVCuentas.Columns("Id").Width = 10
        grdVCuentas.Columns("Codigo").Width = 20
        grdVCuentas.Columns("Nombre").Width = 50

        grdVCuentas.Columns("Codigo").Caption = "Código"
        grdVCuentas.Columns("Nombre").Caption = "Nombre"

        grdVCuentas.Columns.ColumnByFieldName("Codigo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVCuentas.Columns.ColumnByFieldName("Nombre").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        grdVCuentas.OptionsView.ShowAutoFilterRow = True

        grdVCuentas.OptionsView.EnableAppearanceEvenRow = True
        grdVCuentas.OptionsView.EnableAppearanceOddRow = True
        grdVCuentas.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVCuentas.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVCuentas.Appearance.SelectedRow.Options.UseBackColor = True

        grdVCuentas.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        grdVCuentas.Appearance.EvenRow.BackColor = Color.White
        grdVCuentas.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVCuentas.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVCuentas.Appearance.FocusedRow.ForeColor = Color.White
    End Sub


    Public Sub formatos()
        Dim textEdit = New RepositoryItemTextEdit()
        textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        textEdit.Mask.EditMask = "\w\w\w-\w\w\w\w-\w\w\w\w"
        textEdit.Mask.UseMaskAsDisplayFormat = True

        grdCuentas.RepositoryItems.Add(textEdit)
        grdVCuentas.Columns("Codigo").ColumnEdit = textEdit
    End Sub

    Private Sub grdVCuentas_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVCuentas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

End Class