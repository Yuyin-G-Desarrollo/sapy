Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports DevExpress.XtraGrid
Imports Tools.modMensajes
Imports DevExpress.XtraPrinting
Imports System.Globalization
Imports Framework.Negocios
Imports Tools
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base

Public Class ComprasDePTIngresadoForm
#Region "Properties"
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Private objBU As New Proveedores.BU.ConsultaComprasPT_BU
    Dim CEDISID As Integer = 0
#End Region

    Private Sub ComprasDePTIngresadoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        ConfiguracionPermisosBotones()
        ObtenerCEDISUsuario()
        ' CEDISID = cmbCEDIS.SelectedValue
    End Sub
    Private Sub ObtenerCEDISUsuario()
        ' cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)
    End Sub
    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 0
        listado.tipo_Nave = 0 'Nave NO es Maquila 

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        LimpiarGridReporte()
        grdNaves.DataSource = listado.listaParametros
        grid_diseño(grdNaves)
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim fechaInicioIngreso As Date = dtpFechaInicio.Value.ToShortDateString
            Dim fechaFinIngreso As Date = dtpFechaFin.Value.ToShortDateString
            'Dim CEDISID As Integer = cmbCEDIS.SelectedValue
            Dim obj As New Proveedores.BU.ConsultaComprasPT_BU
            Dim navesId As String = Filtros(grdNaves)
            Dim marcasId As String = Filtros(grdMarcas)
            Dim tabla As DataTable = obj.ObtenerCompradeProductoIngresado(fechaInicioIngreso, fechaFinIngreso, navesId, marcasId)
            If fechaFinIngreso >= fechaInicioIngreso Then
                If tabla.Rows.Count > 0 Then
                    grdReporte.DataSource = tabla
                    DisenioGrid()
                    lblFechaUltimaActualización.Text = Date.Now.ToString
                    lblNumRegistros.Text = tabla.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                    pnlParametros.Height = 27
                Else
                    msgAdvertencia.mensaje = "No se encontró información."
                    msgAdvertencia.ShowDialog()

                End If
            Else
                msgAdvertencia.mensaje = "La fecha de fin debe ser mayor a la de inicio."
                msgAdvertencia.ShowDialog()
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#Region "DISEÑO GRID"
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next
        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub
    Private Sub DisenioGrid()
        vwReporte.BestFitColumns()
        'vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.Columns.ColumnByFieldName("ProductoEstiloId").Width = 120
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.RowAutoHeight = True

        'vwReporte.Columns.ColumnByFieldName("Razón Social").Visible = False
        vwReporte.Columns.ColumnByFieldName("Receptor").Visible = False
        'vwReporte.Columns.ColumnByFieldName("Es Maquila").Visible = False
        vwReporte.Columns.ColumnByFieldName("ReceptorId").Visible = False
        vwReporte.Columns.ColumnByFieldName("EmisorId").Visible = False
        vwReporte.Columns.ColumnByFieldName("NaveIdSAY").Visible = False
        vwReporte.Columns.ColumnByFieldName("MarcaIdSAY").Visible = False
        vwReporte.Columns.ColumnByFieldName("FechaEntradaAlmacen").Visible = False
        vwReporte.Columns.ColumnByFieldName("Facturado").Visible = False
        vwReporte.Columns.ColumnByFieldName("documentoid").Visible = False

        vwReporte.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Subtotal").DisplayFormat.FormatString = "N2"
        vwReporte.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("IVA").DisplayFormat.FormatString = "N2"
        vwReporte.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("ParesF") Or col.FieldName.Contains("Total") Or col.FieldName.Contains("Subtotal") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "ParesF")) = True And col.FieldName = "ParesF" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
    End Sub

    Private Sub vwReporte_RowCellStyle(sender As Object, e As Views.Grid.RowCellStyleEventArgs) Handles vwReporte.RowCellStyle
        Try
            Dim currentView As GridView
            currentView = sender
            If e.Column.FieldName = "F" And e.RowHandle >= 0 Then
                Dim value As Boolean
                value = currentView.GetRowCellValue(e.RowHandle, "Facturado").ToString()
                If value Then
                    e.Appearance.BackColor = Color.Green
                End If
                e.Appearance.ForeColor = Color.Transparent
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub limpiarGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DataSource = Nothing
    End Sub
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(" ").Value Then lista.Add(Row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnLimNave_Click(sender As Object, e As EventArgs) Handles btnLimNave.Click
        limpiarGrid(grdNaves)
        LimpiarGridReporte()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "ComprasPTIngresado"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta "
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "\" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With

            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo.")
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Dim Facturado As Integer = vwReporte.GetRowCellValue(e.RowHandle, "Facturado")
        Try

            If e.ColumnFieldName = "F" Then
                If Facturado Then
                    e.Formatting.BackColor = Color.Green
                End If
            End If

        Catch ex As Exception
            Show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 163
    End Sub

    Private Sub grdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNaves.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnLimMarca_Click(sender As Object, e As EventArgs) Handles btnLimMarca.Click
        limpiarGrid(grdMarcas)
        LimpiarGridReporte()
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click

        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 1 'Marcas

        Dim listaParametroId As New List(Of String)

        For Each row As UltraGridRow In grdMarcas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroId.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroId
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdMarcas.DataSource = listado.listaParametros
        grid_diseño(grdMarcas)
        With grdMarcas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marcas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

#Region "Methods"
    Private Sub ConfiguracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("Compras PT Ingresado", "PI_FACTURAR") Then
            pnlFacturar.Visible = True
            If dtpFechaInicio.Value >= New Date(2020, 7, 11) Then
                btnFacturar.Visible = True
                lblFacturar.Visible = True
            Else
                btnFacturar.Visible = False
                lblFacturar.Visible = False
            End If
        Else
            pnlFacturar.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("Compras PT Ingresado", "PI_EXISTENCIA_SAP") Then
            pnlExistenciaSAP.Visible = True
        Else

            pnlExistenciaSAP.Visible = False
        End If

    End Sub

    Public Sub Show_message(ByVal tipo As String, ByVal mensaje As String)
        Dim objMensaje As Object

        Select Case tipo
            Case "Advertencia"
                objMensaje = New AdvertenciaForm
            Case "Aviso"
                objMensaje = New AvisoForm
            Case "Error"
                objMensaje = New ErroresForm
            Case "Exito"
                objMensaje = New ExitoForm
            Case "Confirmar"
                objMensaje = New ConfirmarForm
            Case "AdvertenciaGrande"
                objMensaje = New AdvertenciaFormGrande
            Case Else
                objMensaje = New AvisoForm
        End Select

        objMensaje.mensaje = mensaje
        objMensaje.ShowDialog()
    End Sub

    Private Function ValidarDatos() As Boolean
        'If grdNaves.Rows.Count = 0 Then
        '    Show_message("Advertencia", "Debe de seleccionar al menos una nave.")
        '    Return False
        '    'ElseIf grdNaves.Rows.Count > 1 Then
        '    '    Show_message("Advertencia", "DEbe seleccionar solo una nave.")
        '    '    Return False
        'End If

        If vwReporte.RowCount = 0 Then
            Show_message("Advertencia", "No hay productos para facturar.")
            Return False
        End If

        'For i As Integer = 0 To vwReporte.RowCount - 1
        '    If vwReporte.GetRowCellValue(i, "Precio") Is DBNull.Value Then
        '        Show_message("Advertencia", "Uno o más productos no tiene precio capturado.")
        '        Return False
        '    End If
        'Next

        Return True
    End Function

    Private Sub LimpiarGridReporte()
        grdReporte.DataSource = Nothing
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function
#End Region

#Region "Events"
    Private Sub BtnFacturar_Click(sender As Object, e As EventArgs) Handles lblFacturar.Click, btnFacturar.Click
        Try
            If ValidarDatos() Then
                Dim objForm As New ComprasPTIngresado_ResumenFacturasForm
                If Not CheckForm(objForm) Then
                    Me.Cursor = Cursors.WaitCursor
                    objForm.fechaInicio = dtpFechaInicio.Value.ToShortDateString
                    objForm.fechaFin = dtpFechaFin.Value.ToShortDateString
                    objForm.navesId = Filtros(grdNaves)
                    objForm.marcasId = Filtros(grdMarcas)
                    'objForm.CEDIS = cmbCEDIS.SelectedValue
                    objForm.ShowDialog()
                    If objForm.reload Then
                        btnMostrar_Click(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception
            Show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        LimpiarGridReporte()
        If dtpFechaInicio.Value >= New Date(2020, 7, 11) And pnlFacturar.Visible Then
            btnFacturar.Visible = True
            lblFacturar.Visible = True
        Else
            btnFacturar.Visible = False
            lblFacturar.Visible = False
        End If

        If dtpFechaInicio.Value >= dtpFechaFin.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
    End Sub

    Private Sub DtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        LimpiarGridReporte()
        If dtpFechaInicio.Value >= dtpFechaFin.Value Then
            dtpFechaInicio.Value = dtpFechaFin.Value
        End If
    End Sub

    Private Sub lblExportar_Click(sender As Object, e As EventArgs) Handles lblExportar.Click

    End Sub

    Private Sub btnExistenciaSAP_Click(sender As Object, e As EventArgs) Handles btnExistenciaSAP.Click
        Dim ventana As New ComprasPTIngresado_VerificarExistenciasSAP_Form With {
           .MdiParent = Me.MdiParent
       }
        ventana.Show()
    End Sub

    Private Sub grdReporte_Click(sender As Object, e As EventArgs) Handles grdReporte.Click

    End Sub


#End Region
End Class