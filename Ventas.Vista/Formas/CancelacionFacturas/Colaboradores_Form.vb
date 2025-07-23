Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base

Public Class Colaboradores_Form
    Public idColaborador As Integer
    Public nombreColaborador As String

    Private Sub Colaboradores_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obBu As New Negocios.SolicitarCancelacionBU
        Dim dtResultado As DataTable = obBu.ConsultarColaboradores()
        If dtResultado.Rows.Count > 0 Then
            grdColaboradores.DataSource = Nothing
            vwColaboradores.Columns.Clear()
            grdColaboradores.DataSource = dtResultado
            DiseñoGrid()

            'vwColaboradores.OptionsNavigation.UseTabKey = True
            'vwColaboradores.SetFocusedRowCellValue("nombreCompleto", True)

            'vwColaboradores.OptionsNavigation.AutoMoveRowFocus

            'SendKeys.Send()


            'grdColaboradores.FocusedView()


            'Dim View As ColumnView = grdColaboradores.FocusedView
            'Dim column As GridColumn = View.Columns("nombreCompleto")

            'If Not column Is Nothing Then
            '    ' locating the row

            '    View.FocusedRowHandle = 1
            '    View.FocusedColumn = column

            'End If

            ' DiseñoGrid()
        End If
    End Sub

    Private Sub DiseñoGrid()

        grdColaboradores.ForceInitialize()
        vwColaboradores.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle

        vwColaboradores.Columns.ColumnByFieldName("idColaborador").Visible = False
        vwColaboradores.Columns.ColumnByFieldName("nombreCompleto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub
    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub vwColaboradores_KeyDown(sender As Object, e As KeyEventArgs) Handles vwColaboradores.KeyDown
        If e.KeyCode = Keys.Enter Then
            nombreColaborador = Convert.ToString(vwColaboradores.GetFocusedRowCellValue("nombreCompleto"))
            idColaborador = Convert.ToInt32(vwColaboradores.GetFocusedRowCellValue("idColaborador"))
            Close()
        End If
    End Sub

    Private Sub Colaboradores_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class