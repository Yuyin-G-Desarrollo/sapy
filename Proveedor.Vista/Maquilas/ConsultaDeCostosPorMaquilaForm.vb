Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Vista
Imports Tools.modMensajes

Public Class ConsultaDeCostosPorMaquilaForm
    Dim dtResultadoConsulta As New DataTable
    Dim msgAdvertencia As New Tools.AdvertenciaForm
    Private Sub ComprasDePTIngresadoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        nud_Año.Value = Now.Date.Year
        fechasAnioBisiesto()
        Dim numeroSemanas As Int32 = Convert.ToInt32(DateTime.Now.DayOfYear / 7)
        lbl_semanaActual.Text = numeroSemanas
    End Sub

    Private Sub fechasAnioBisiesto()
        'Calcular si el año es bisiesto y asignar el numero de semanas correspondientes
        If (nud_Año.Value Mod 4 = 0 And nud_Año.Value Mod 100 <> 0 Or nud_Año.Value Mod 400 = 0) Then
            nud_SemInicio.Maximum = 53
            nud_SemFin.Maximum = 53
            nud_SemInicio.Value = If(DateTime.Now.DayOfYear / 7 < 1, 1, DateTime.Now.DayOfYear / 7)
            nud_SemFin.Value = If(DateTime.Now.DayOfYear / 7 < 1, 1, DateTime.Now.DayOfYear / 7)
        Else
            nud_SemInicio.Maximum = 52
            nud_SemFin.Maximum = 52
            nud_SemInicio.Value = If(DateTime.Now.DayOfYear / 7 < 1, 1, DateTime.Now.DayOfYear / 7)
            nud_SemFin.Value = If(DateTime.Now.DayOfYear / 7 < 1, 1, DateTime.Now.DayOfYear / 7)
        End If
    End Sub

    Private Sub btnExportar_Click_2(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "Consulta de costos por maquila"
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

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Me.grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            lbl_TotalRegistros.Text = 0
            Dim Año As Integer = nud_Año.Value
            Dim SemanaInicio As Integer = nud_SemInicio.Value
            Dim SemanaFin As Integer = nud_SemFin.Value
            Dim MaquilaId As String = Filtros(grdNaves)
            Dim obj As New Proveedores.BU.ConsultasComprasPorMaquila_BU
            Dim tabla As DataTable = obj.ObtenerComprasPorMaquila(Año, SemanaInicio, SemanaFin, MaquilaId)

            If Año <> 0 And SemanaInicio <> 0 And SemanaFin <> 0 Then
                If Año > 0 And SemanaInicio <= SemanaFin Then
                    If tabla.Rows.Count > 0 Then
                        lbl_TotalRegistros.Text = Convert.ToInt32(tabla.Rows.Count)
                        grdReporte.DataSource = tabla
                        DisenioGrid()
                    Else
                        msgAdvertencia.mensaje = "No se encontró información"
                        msgAdvertencia.ShowDialog()
                    End If
                Else
                    msgAdvertencia.mensaje = "La semana de fin debe ser mayor a la de inicio."
                    msgAdvertencia.ShowDialog()
                End If
            Else
                msgAdvertencia.mensaje = "Ingrese fechas"
                msgAdvertencia.ShowDialog()
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(" ").Value Then lista.Add(Row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function

    Private Sub DisenioGrid()
        vwReporte.BestFitColumns()
        vwReporte.OptionsView.ColumnAutoWidth = False
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.IndicatorWidth = 30
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.RowAutoHeight = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            If col.FieldName.Contains("Semana") = False Then
                If col.FieldName.Contains("Pares") Then
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N0"
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                Else
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "N2"
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If

            End If
        Next

    End Sub

    Private Sub grdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs)
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnLimNave_Click_2(sender As Object, e As EventArgs) Handles btnLimNave.Click
        limpiarGrid(grdNaves)
    End Sub

    Private Sub limpiarGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DataSource = Nothing
    End Sub

    Private Sub btnCerrar_Click_2(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListaParametrosForm

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_Nave = 1
        listado.listaPatametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listaParametros
        grid_diseño(grdNaves)
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

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

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 163
    End Sub

    Private Sub nud_Año_MouseUp(sender As Object, e As MouseEventArgs) Handles nud_Año.MouseUp
        nud_Año.Minimum = 2019
        fechasAnioBisiesto()
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub nud_SemInicio_MouseUp(sender As Object, e As MouseEventArgs) Handles nud_SemInicio.MouseUp
        If (nud_SemInicio.Value > nud_SemFin.Value) Then
            nud_SemFin.Value = nud_SemInicio.Value
        End If
    End Sub
End Class