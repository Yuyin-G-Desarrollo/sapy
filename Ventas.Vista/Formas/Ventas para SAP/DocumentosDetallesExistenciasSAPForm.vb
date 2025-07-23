
Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Documents.Excel
Imports Tools
Imports Ventas.Negocios

Public Class DocumentosDetallesExistenciasSAPForm
    Private _Documentos As String
    Dim tblDatosDetallesFaltantes As New DataTable
    Public Property Documentos() As String
        Get
            Return _Documentos
        End Get
        Set(ByVal value As String)
            _Documentos = value
        End Set
    End Property
    Private fechaInicio As Date
    Public Property FechaInicioSAP() As Date
        Get
            Return fechaInicio
        End Get
        Set(ByVal value As Date)
            fechaInicio = value
        End Set
    End Property
    Private fechaFinal As Date
    Public Property FechaFinalSAP() As Date
        Get
            Return fechaFinal
        End Get
        Set(ByVal value As Date)
            fechaFinal = value
        End Set
    End Property
    Private facturasIds As String
    Public Property FacturasIdsSAP() As String
        Get
            Return facturasIds
        End Get
        Set(ByVal value As String)
            facturasIds = value
        End Set
    End Property
    Private razonSocial As Integer
    Public Property razonSocialSap() As Integer
        Get
            Return razonSocial
        End Get
        Set(ByVal value As Integer)
            razonSocial = value
        End Set
    End Property
    Private Sub DocumentosDetallesExistenciasSAPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosDetallesFaltantesSAP()
    End Sub
    Private Sub CargarDatosDetallesFaltantesSAP()
        Dim objTblDetalles As New RegistrarInventarioSAPBU

        tblDatosDetallesFaltantes = objTblDetalles.ConsultarDocumentosFaltantesSAP(_Documentos, FechaInicioSAP, FechaFinalSAP, razonSocial, facturasIds)

        If tblDatosDetallesFaltantes.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para mostrar.")
        Else
            GrdDocumentosDetallesExistenciasSAP.DataSource = tblDatosDetallesFaltantes
            lblRegistros.Text = tblDatosDetallesFaltantes.Rows.Count.ToString("N0")
            DiseñoGridSAP(vwDocumentosDetallesExistenciasSAP)
        End If
    End Sub
    Private Sub vwDocumentosDetallesExistenciasSAP_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwDocumentosDetallesExistenciasSAP.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub DiseñoGridSAP(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(vwDocumentosDetallesExistenciasSAP) '' pone color a las filas del gridview
        vwDocumentosDetallesExistenciasSAP.OptionsBehavior.Editable = False
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDocumentosDetallesExistenciasSAP.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        Grid.IndicatorWidth = 30
        vwDocumentosDetallesExistenciasSAP.Columns.ColumnByFieldName("IDSAY").Width = 40
        vwDocumentosDetallesExistenciasSAP.Columns.ColumnByFieldName("Factura").Width = 48
        vwDocumentosDetallesExistenciasSAP.Columns.ColumnByFieldName("Id Articulo").Width = 60
        vwDocumentosDetallesExistenciasSAP.Columns.ColumnByFieldName("Articulo").Width = 190
        vwDocumentosDetallesExistenciasSAP.Columns.ColumnByFieldName("Clave SAT").Width = 58
        vwDocumentosDetallesExistenciasSAP.Columns.ColumnByFieldName("Pares Facturados").Width = 80
        vwDocumentosDetallesExistenciasSAP.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
        If IsNothing(vwDocumentosDetallesExistenciasSAP.Columns("Pares Facturados").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares Facturados")) = True Then
            vwDocumentosDetallesExistenciasSAP.Columns("Pares Facturados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares Facturados", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares Facturados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwDocumentosDetallesExistenciasSAP.GroupSummary.Add(item)
        End If

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

End Class