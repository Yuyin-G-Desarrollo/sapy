Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class Ajustes_ComplementoPagoCompensacion_Form
    Dim listaInicial As New List(Of String)
    Dim objadvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim confirmar As New Tools.ConfirmarForm
    Public FClientes As String = String.Empty

    Private Sub Ajustes_ComplementoPagoCompensacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdClientes.DataSource = listaInicial
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        dtpFechaFin.Value = Date.Now
        lblTotalRegistros.Text = 0
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.AdministrarComplementoPagoCompensacionBU
        Dim dtAjustesPorCompensacion As New DataTable
        Dim TipoPago As Integer = 1

        Try

            If rdoAjustes.Checked Then
                TipoPago = 1 'Ajustes
            Else
                TipoPago = 2 'Compensación 
            End If

            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                objadvertencia.mensaje = "La fecha inicial no puede ser mayor a la fecha final."
                objadvertencia.ShowDialog()
                dtpFechaInicio.Focus()
            End If

            grdAjuste.DataSource = Nothing
            MVAjuste.Columns.Clear()
            FClientes = ObtenerFiltrosGrid(grdClientes)
            Cursor = Cursors.WaitCursor

            dtAjustesPorCompensacion = objBU.obtenerAjustesPorCompensacion(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FClientes, TipoPago)

            If dtAjustesPorCompensacion.Rows.Count > 0 Then
                grdAjuste.DataSource = dtAjustesPorCompensacion
                DiseñoGrid()
                lblFechaUltimaActualización.Text = Date.Now
                lblTotalRegistros.Text = CDbl(MVAjuste.RowCount.ToString()).ToString("n0")
            Else
                objadvertencia.mensaje = "No existe información de este Cliente."
                objadvertencia.ShowDialog()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub DiseñoGrid()
        MVAjuste.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVAjuste.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVAjuste.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVAjuste.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVAjuste.Columns.Item("#").VisibleIndex = 0
            MVAjuste.Columns.ColumnByFieldName("#").Width = 10
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVAjuste.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName = " " Then

            Else
                col.OptionsColumn.AllowEdit = False
            End If

        Next

        MVAjuste.Columns.ColumnByFieldName("TD").Caption = "Tipo Docto"
        MVAjuste.Columns.ColumnByFieldName("idfactura").Caption = "Factura"
        MVAjuste.Columns.ColumnByFieldName("fechaventa").Caption = "F. Docto"
        MVAjuste.Columns.ColumnByFieldName("idcadena").Caption = "Cliente ID"
        MVAjuste.Columns.ColumnByFieldName("cte").Caption = "Cliente"
        MVAjuste.Columns.ColumnByFieldName("razonsocial").Caption = "Razón Social"
        MVAjuste.Columns.ColumnByFieldName("Fechaaplicacion").Caption = "Fecha Recibo"
        MVAjuste.Columns.ColumnByFieldName("tipocobro").Caption = "Tipo Cobro"
        'MVAjuste.Columns.ColumnByFieldName("Folio").Caption = "Recibo"
        MVAjuste.Columns.ColumnByFieldName("importe").Caption = "Importe"

        MVAjuste.Columns.ColumnByFieldName(" ").Width = 30
        MVAjuste.Columns.ColumnByFieldName("TD").Width = 60
        MVAjuste.Columns.ColumnByFieldName("idfactura").Width = 60
        MVAjuste.Columns.ColumnByFieldName("fechaventa").Width = 100
        MVAjuste.Columns.ColumnByFieldName("idcadena").Width = 60
        MVAjuste.Columns.ColumnByFieldName("cte").Width = 150
        MVAjuste.Columns.ColumnByFieldName("razonsocial").Width = 230
        MVAjuste.Columns.ColumnByFieldName("Fechaaplicacion").Width = 100
        MVAjuste.Columns.ColumnByFieldName("tipocobro").Width = 100
        'MVAjuste.Columns.ColumnByFieldName("Folio").Width = 50
        MVAjuste.Columns.ColumnByFieldName("importe").Width = 80

        MVAjuste.Columns.ColumnByFieldName("CobroID").Visible = False

        MVAjuste.Columns.ColumnByFieldName("importe").DisplayFormat.FormatString = "N2"
        MVAjuste.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(MVAjuste.Columns("importe").Summary.FirstOrDefault(Function(x) x.FieldName = "importe")) = True Then
            MVAjuste.Columns("importe").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "importe", "{0:N2}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "importe"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVAjuste.GroupSummary.Add(item)
        End If

    End Sub


    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVAjuste.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdClientes.DataSource = listaInicial
        grdAjuste.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
        dtpFechaFin.Value = Date.Now.ToString
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click

        Dim listado As New ListadoParametros_AjustePorCompensacion
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listaParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listaInicial
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = MVAjuste.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                MVAjuste.SetRowCellValue(MVAjuste.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next
        Return Resultado
    End Function

    Private Sub btnCompensacion_Click(sender As Object, e As EventArgs) Handles btnCompensacion.Click
        Dim NumeroFilas As Integer = MVAjuste.DataRowCount
        Dim objBU As New Negocios.AdministrarComplementoPagoCompensacionBU


        Try
            confirmar.mensaje = "¿Está seguro de actualizar el tipo cobro a compensación?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor

                Dim VXmlCeldas As XElement = New XElement("Celdas")
                For index As Integer = 0 To NumeroFilas Step 1
                    If CBool(MVAjuste.GetRowCellValue(MVAjuste.GetVisibleRowHandle(index), " ")) = True Then
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("PCobroID", MVAjuste.GetRowCellValue(MVAjuste.GetVisibleRowHandle(index), "CobroID")))
                        VXmlCeldas.Add(vNodo)
                    End If
                Next


                objBU.CambiarTipoCobroAjuste(VXmlCeldas.ToString())
                objExito.mensaje = "Se realizaron las acciones con éxito."
                objExito.ShowDialog()
            Else
                objadvertencia.mensaje = "Se canceló el cambio."
                objadvertencia.ShowDialog()
            End If

        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
        btnMostrar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        pnlFiltros.Height = 206
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        pnlFiltros.Height = 27
    End Sub

    Private Sub rdoCompensacion_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCompensacion.CheckedChanged
        btnMostrar_Click(Nothing, Nothing)
    End Sub
End Class