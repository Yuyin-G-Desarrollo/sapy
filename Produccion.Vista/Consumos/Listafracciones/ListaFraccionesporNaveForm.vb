Imports DevExpress.Data.XtraReports.Wizard
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools
Imports DevExpress.XtraPrinting
Imports System.Globalization
Imports DevExpress.XtraGrid

Public Class ListaFraccionesporNaveForm
    Dim msgAdvertencia As New Tools.AdvertenciaForm

    Dim lsta As New DataTable
    Private Sub ListaFraccionesporNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized


    End Sub


    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 0
        listado.tipo_Nave = 0 'Nave NO es Maquila 

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        'LimpiarGridReporte()
        grdNave.DataSource = listado.listaParametros
        grid_diseño(grdNave)
        With grdNave
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 1 'Marcas

        Dim listaParametroId As New List(Of String)

        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroId.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroId
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listaParametros
        grid_diseño(grdMarca)
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marcas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
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

    Private Sub limpiarGrid(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DataSource = Nothing
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
    End Sub
    Private Sub btnEstatus_Click(sender As Object, e As EventArgs) Handles btnEstatus.Click
        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 3 'Estatus

        Dim listaParametroId As New List(Of String)

        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroId.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroId
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdEstatus.DataSource = listado.listaParametros
        grid_diseño(grdEstatus)
        With grdEstatus
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        LlenarGridFiltro(grdColeccion, "Colección", 2)
    End Sub

    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListaParametrosForm
        listado.tipo_busqueda = 2 'Colecciones

        Dim listaParametroId As New List(Of String)

        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroId.Add(parametro)
        Next
        listado.listaPatametroID = listaParametroId
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listaParametros
        grid_diseño(grdColeccion)
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimMarca_Click(sender As Object, e As EventArgs) Handles btnLimMarca.Click
        limpiarGrid(grdMarca)
    End Sub

    Private Sub btnlimNave_Click(sender As Object, e As EventArgs) Handles btnlimNave.Click
        limpiarGrid(grdNave)
    End Sub

    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        limpiarGrid(grdColeccion)
    End Sub

    Private Sub btnLimEstatus_Click(sender As Object, e As EventArgs) Handles btnLimEstatus.Click
        limpiarGrid(grdEstatus)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdNave.DataSource = Nothing
        grdMarca.DataSource = Nothing
        grdColeccion.DataSource = Nothing
        grdEstatus.DataSource = Nothing
        grdfraccionespornave.DataSource = Nothing


    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        grdfraccionespornave.DataSource = Nothing
        vwReporte.Columns.Clear()
        lblNumRegistros.Text = "0"

        Me.Cursor = Cursors.WaitCursor
        Dim nave As String
        If grdNave.Rows.Count > 0 Then
            Try
                Dim obj As New ListaFraccionesporNaveBU

                Dim navesId As String = Filtro(grdNave)
                Dim marcaId As String = Filtro(grdMarca)
                Dim Estatus As String = FiltroEstatus(grdEstatus)
                Dim coleccionId As String = Filtro(grdColeccion)

                If grdNave.Rows.Count = 1 Then
                    nave = "1"
                Else
                    nave = "0"
                End If


                Dim tabla As DataTable = obj.ObtenerInformacionFracciones(navesId, marcaId, coleccionId, Estatus, nave)
                grdfraccionespornave.DataSource = tabla
                diseñogrid()


                lblFechaUltimaActualización.Text = Date.Now.ToString
                lblNumRegistros.Text = tabla.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
                btnArriba.PerformClick()


            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Me.Cursor = Cursors.Default
            msgAdvertencia.mensaje = "Debe seleccionar por lo menos una Nave."
            msgAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub diseñogrid()



        'For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
        '    col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        '    If col.FieldName.Contains("ModeloSay") Then
        '        col.Visible = False
        '    End If
        'Next

        vwReporte.Columns.ColumnByFieldName("ModeloSay").Visible = False
        '    vwReporte.Columns.ColumnByFieldName("Estatus").Visible = False

        vwReporte.IndicatorWidth = 50

        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsView.EnableAppearanceOddRow = True
        vwReporte.OptionsView.ShowIndicator = True
        vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsView.ShowAutoFilterRow = True
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.Columns.ColumnByFieldName("Corrida").Width = 55
        vwReporte.Columns.ColumnByFieldName("Orden").Width = 40
        vwReporte.Columns.ColumnByFieldName("Horas").Width = 43
        vwReporte.Columns.ColumnByFieldName("Minutos").Width = 45
        vwReporte.Columns.ColumnByFieldName("Segundos").Width = 45
        vwReporte.Columns.ColumnByFieldName("Costo").Width = 60
        vwReporte.Columns.ColumnByFieldName("PielColor").Width = 150
        vwReporte.Columns.ColumnByFieldName("Fracción").Width = 200
        vwReporte.Columns.ColumnByFieldName("status").Width = 130
        vwReporte.Columns.ColumnByFieldName("ModeloSICY").Width = 70
        vwReporte.Columns.ColumnByFieldName("MarcaSAY").Width = 70






        vwReporte.OptionsSelection.EnableAppearanceFocusedCell = False
        vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns

            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

        Next
        With vwReporte.Appearance
            .SelectedRow.Options.UseBackColor = True
            .SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
            .EvenRow.BackColor = Color.White
            .OddRow.BackColor = SystemColors.ActiveCaption
            .FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
            .FocusedRow.ForeColor = Color.White
            .HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        End With
        vwReporte.ClearColumnsFilter()

    End Sub

    Private Function FiltroEstatus(ByVal grid As UltraGrid) As String
        Dim lista As New List(Of String)


        For Each row As UltraGridRow In grid.Rows
            If row.Cells(" ").Value Then
                Select Case (row.Cells(0).Value)
                    Case "1"
                        lista.Add("DESARROLLO")
                    Case "2"
                        lista.Add("AUTORIZADO DESARROLLO")
                    Case "3"
                        lista.Add("AUTORIZADO PRODUCCIÓN")
                    Case "4"
                        lista.Add("INAVTIVO NAVE")
                    Case "5"
                        lista.Add("DESCONTINUADO")
                    Case Else
                End Select

            End If
        Next
        'lsta.Rows.Add(New Object() {"1", False, "DESARROLLO"})
        'lsta.Rows.Add(New Object() {"2", False, "AUTORIZADO DESARROLLO"})
        'lsta.Rows.Add(New Object() {"3", False, "AUTORIZADO PRODUCCIÓN"})
        'lsta.Rows.Add(New Object() {"4", False, "INACTIVO NAVE"})
        'lsta.Rows.Add(New Object() {"5", False, "DESCONTINUADO"})
        Return String.Join(",", lista).ToString
    End Function
    Private Function Filtro(ByVal grid As UltraGrid) As String
        Dim lista As New List(Of Integer)


        For Each row As UltraGridRow In grid.Rows
            If row.Cells(" ").Value Then lista.Add(row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then

                nombreReporte = "FraccionesenPTporNave"
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


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 163
    End Sub

    Private Sub grdNave_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNave.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarca_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarca.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdColeccion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColeccion.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdEstatus_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdEstatus.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub



#End Region

End Class