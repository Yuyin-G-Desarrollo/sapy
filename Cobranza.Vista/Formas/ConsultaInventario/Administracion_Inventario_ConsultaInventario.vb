Imports System.Drawing
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class Administracion_Inventario_ConsultaInventario
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm


    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Administracion_ConsultaInventarioBU
        Dim dtDatosFacturas As New DataTable
        Dim RazonSocialID As Integer = 0

        Try
            If cmbRazonSocial.SelectedIndex <> 0 Then
                RazonSocialID = cmbRazonSocial.SelectedValue
                MVConsultaInventario.Columns.Clear()
                grdConsultaInventario.DataSource = Nothing

                Cursor = Cursors.WaitCursor
                dtDatosFacturas = objBU.ObtenerInventarioInicial(RazonSocialID)

                If dtDatosFacturas.Rows.Count > 0 Then
                    grdConsultaInventario.DataSource = dtDatosFacturas
                    lblFechaUltimaActualización.Text = Date.Now
                    DiseñoGrid()
                    lblNumFiltrados.Text = CDbl(MVConsultaInventario.RowCount.ToString()).ToString("n0")
                Else
                    advertencia.mensaje = "No hay información para mostrar."
                    advertencia.ShowDialog()
                End If
            Else
                advertencia.mensaje = "Seleccione una razón social."
                advertencia.ShowDialog()
            End If


        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub MVConsultaInventario_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles MVConsultaInventario.RowCellStyle

        If e.Column.FieldName.Contains("Existencia") Then
            If Not IsDBNull(MVConsultaInventario.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                If CDbl(MVConsultaInventario.GetRowCellValue(e.RowHandle, e.Column.FieldName)) < 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
        End If
    End Sub

    Public Sub DiseñoGrid()
        MVConsultaInventario.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVConsultaInventario.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVConsultaInventario.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVConsultaInventario.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVConsultaInventario.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVConsultaInventario.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName = " " Then
                col.OptionsColumn.AllowEdit = True
            Else
                col.OptionsColumn.AllowEdit = False
            End If

        Next

        MVConsultaInventario.Columns.ColumnByFieldName(" ").Width = 30
        MVConsultaInventario.Columns.ColumnByFieldName("#").Width = 30
        MVConsultaInventario.Columns.ColumnByFieldName("ProductoEstiloID").Width = 60
        MVConsultaInventario.Columns.ColumnByFieldName("Marca").Width = 80
        MVConsultaInventario.Columns.ColumnByFieldName("Coleccion").Width = 200
        MVConsultaInventario.Columns.ColumnByFieldName("ModeloSAY").Width = 80
        MVConsultaInventario.Columns.ColumnByFieldName("ModeloSICY").Width = 80
        MVConsultaInventario.Columns.ColumnByFieldName("CodigoSICY").Width = 100
        MVConsultaInventario.Columns.ColumnByFieldName("Piel").Width = 100
        MVConsultaInventario.Columns.ColumnByFieldName("Color").Width = 100
        MVConsultaInventario.Columns.ColumnByFieldName("Corrida").Width = 80
        MVConsultaInventario.Columns.ColumnByFieldName("Ingresos").Width = 80
        MVConsultaInventario.Columns.ColumnByFieldName("Salidas").Width = 80
        MVConsultaInventario.Columns.ColumnByFieldName("Existencia").Width = 80

        MVConsultaInventario.Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo SAY"
        MVConsultaInventario.Columns.ColumnByFieldName("ModeloSICY").Caption = "Modelo SICY"
        MVConsultaInventario.Columns.ColumnByFieldName("CodigoSICY").Caption = "Código SICY"
        MVConsultaInventario.Columns.ColumnByFieldName("ProductoEstiloID").Caption = "ID"

        MVConsultaInventario.Columns.ColumnByFieldName("ProductoEstiloID").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVConsultaInventario.Columns.ColumnByFieldName("Ingresos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVConsultaInventario.Columns.ColumnByFieldName("Salidas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVConsultaInventario.Columns.ColumnByFieldName("Existencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        MVConsultaInventario.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(MVConsultaInventario.Columns("Ingresos").Summary.FirstOrDefault(Function(x) x.FieldName = "Ingresos")) = True Then
            MVConsultaInventario.Columns("Ingresos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Ingresos", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Ingresos"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVConsultaInventario.GroupSummary.Add(item)
        End If

        If IsNothing(MVConsultaInventario.Columns("Salidas").Summary.FirstOrDefault(Function(x) x.FieldName = "Salidas")) = True Then
            MVConsultaInventario.Columns("Salidas").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Salidas", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Salidas"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVConsultaInventario.GroupSummary.Add(item)
        End If

        If IsNothing(MVConsultaInventario.Columns("Existencia").Summary.FirstOrDefault(Function(x) x.FieldName = "Existencia")) = True Then
            MVConsultaInventario.Columns("Existencia").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Existencia", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Existencia"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVConsultaInventario.GroupSummary.Add(item)
        End If




    End Sub


    'Private Sub GridView1_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles MVConsultaInventario.CustomDrawCell
    '    Dim currentView As GridView = CType(sender, GridView)

    '    Try
    '        Cursor = Cursors.WaitCursor
    '        If e.Column.FieldName = "Existencia" < 0 Then
    '            e.Appearance.ForeColor = Color.Red
    '        Else
    '            e.Appearance.ForeColor = Color.Black
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Sub



    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVConsultaInventario.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim Form As New Administracion_Inventario_ConsultaInventarioDetalles
        Dim NumeroFilas As Integer = MVConsultaInventario.DataRowCount
        Dim ProductoEstiloID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(MVConsultaInventario.GetRowCellValue(MVConsultaInventario.GetVisibleRowHandle(index), " ")) = True Or CBool(MVConsultaInventario.IsRowSelected(MVConsultaInventario.GetVisibleRowHandle(index))) = True Then
                    ProductoEstiloID = MVConsultaInventario.GetRowCellValue(MVConsultaInventario.GetVisibleRowHandle(index), "ProductoEstiloID")
                End If
            Next

            If ProductoEstiloID <> 0 Then
                Form.ProductoEstiloID = ProductoEstiloID
                Form.MdiParent = Me.MdiParent
                Form.Show()
            Else
                advertencia.mensaje = "Seleccione un artículo para ver detalles."
                advertencia.ShowDialog()
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
        End Try

    End Sub


    Private Sub Administracion_Inventario_ConsultaInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PoblarRazonSocial()

    End Sub

    Public Sub PoblarRazonSocial()
        Dim objBU As New Administracion_ConsultaInventarioBU
        Dim dtRazonesSociales As New DataTable
        dtRazonesSociales = objBU.PoblarRazonSocial()
        dtRazonesSociales.Rows.InsertAt(dtRazonesSociales.NewRow, 0)
        cmbRazonSocial.DataSource = dtRazonesSociales
        cmbRazonSocial.DisplayMember = "Empresa"
        cmbRazonSocial.ValueMember = "EmpresaID"

    End Sub

    Private Sub btnExportar_Click_1(sender As Object, e As EventArgs) Handles btnExportar.Click
        If MVConsultaInventario.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = "Cobranza_ConsultaDocumentos_"
            Dim objBU As New Negocios.ConsultaDocumentosBU
            Dim exportOptions = New XlsxExportOptionsEx()

            Try
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If MVConsultaInventario.GroupCount > 0 Then
                            MVConsultaInventario.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            MVConsultaInventario.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            'grdReporte.ExportToXlsx()

                        End If

                        'exito("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        exito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        exito.ShowDialog()
                        .Dispose()

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                'show_message("Error", ex.Message.ToString())
            End Try
        Else
            'show_message("Aviso", "No hay datos para exportar.")
        End If
    End Sub
End Class