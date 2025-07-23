Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Cobranza_AdministradorDocumentos_Detalles
    Public DocumentoID As String = String.Empty
    Public Año As String = String.Empty
    Public ClienteSICYID As String = String.Empty


    Private Sub Cobranza_AdministradorDocumentos_Detalles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Normal
        CargarNC()
    End Sub

    Public Sub CargarNC()
        Dim objBU As New Negocios.ConsultaDocumentosBU
        Dim dtObtieneNC As New DataTable


        dtObtieneNC = objBU.ObtieneNCDocumentos(DocumentoID, Año, ClienteSICYID)

        If dtObtieneNC.Rows.Count > 0 Then
            grdNotasCredito.DataSource = dtObtieneNC
            DiseñoGrid()
        Else

        End If

    End Sub


    Public Sub DiseñoGrid()
        MVNotasCredito.OptionsView.ColumnAutoWidth = False
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVNotasCredito.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next


        MVNotasCredito.Columns.ColumnByFieldName("ClienteID").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVNotasCredito.Columns.ColumnByFieldName("IdRemision").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVNotasCredito.Columns.ColumnByFieldName("ImporteNC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        MVNotasCredito.Columns.ColumnByFieldName("FechaAplicada").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        MVNotasCredito.Columns.ColumnByFieldName("Año").DisplayFormat.FormatString = "N0"
        MVNotasCredito.Columns.ColumnByFieldName("FechaAplicada").DisplayFormat.FormatString = "dd/MM/yyyy"


        MVNotasCredito.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(MVNotasCredito.Columns("ImporteNC").Summary.FirstOrDefault(Function(x) x.FieldName = "ImporteNC")) = True Then
            MVNotasCredito.Columns("ImporteNC").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ImporteNC", "{0:C2}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "TotalDocumento"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            MVNotasCredito.GroupSummary.Add(item2)
        End If
        MVNotasCredito.BestFitColumns()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class