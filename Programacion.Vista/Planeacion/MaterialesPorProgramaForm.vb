Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class MaterialesPorProgramaForm
    Dim vFiltroProveedor As String = Nothing
    Dim vFiltroClasificacion As String = Nothing
    Dim vFiltroColeccion As String = Nothing
    Dim vFiltroModelo As String = Nothing
    Dim vFiltroPielColor As String = Nothing
    Dim vFiltroCorrida As String = Nothing
    Dim vFiltroFechaInicio As String = Nothing
    Dim vFiltroFechaFin As String = Nothing
    Dim vFiltroNave As Integer = 0
    Dim dtResultadoConsulta As New DataTable


    Private Sub MaterialesPorProgramaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        dtpFechaInicio.MinDate = "01/01/2018"
        dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()

        CargarNAves()

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        Dim obj As New MaterialesPorProgramaBU
        Dim vSpid As Integer = 0
        dtResultadoConsulta.Clear()
        dtResultadoConsulta.Columns.Clear()
        obtenerFiltros()

        dtResultadoConsulta = obj.ObtenerMaterialesPorPrograma(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion)

        If dtResultadoConsulta.Rows.Count > 0 Then

            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            grdReporte.DataSource = dtResultadoConsulta
            DiseñoGrid()
            btnArriba_Click(Nothing, Nothing)
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "No hay datos para mostrar"
            mensajeAdvertencia.ShowDialog()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 290
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimProveedor_Click(sender As Object, e As EventArgs) Handles btnLimProveedor.Click
        grdProveedor.DataSource = Nothing
    End Sub

    Private Sub btnLimMaterial_Click(sender As Object, e As EventArgs) Handles btnLimMaterial.Click
        grdMaterial.DataSource = Nothing
    End Sub

    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        grdColeccion.DataSource = Nothing
    End Sub

    Private Sub btnLimPielColor_Click(sender As Object, e As EventArgs) Handles btnLimPielColor.Click
        grdPielColor.DataSource = Nothing
    End Sub

    Private Sub btnLimCorrida_Click(sender As Object, e As EventArgs) Handles btnLimCorrida.Click
        grdCorrida.DataSource = Nothing
    End Sub

    Private Sub btnLimModelo_Click(sender As Object, e As EventArgs) Handles btnLimModelo.Click
        grdModelo.DataSource = Nothing
    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        LlenarGridFiltro(grdProveedor, "Proveedor", 9)
    End Sub

    Private Sub btnMaterial_Click(sender As Object, e As EventArgs) Handles btnMaterial.Click
        LlenarGridFiltro(grdMaterial, "Material", 8)
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        LlenarGridFiltro(grdColeccion, "Colección", 2)
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        LlenarGridFiltro(grdModelo, "Modelo", 3)
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        LlenarGridFiltro(grdCorrida, "Corrida", 6)
    End Sub

    Private Sub btnPielColor_Click(sender As Object, e As EventArgs) Handles btnPielColor.Click
        LlenarGridFiltro(grdPielColor, "Piel / Color", 7)
    End Sub

    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltradoForm
        listado.tipo_busqueda = pTipoBusqueda
        listado.vIdNave = IIf(cmbNave.Text <> "", cmbNave.SelectedValue, Nothing)

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In pGrid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        pGrid.DataSource = listado.listParametros

        With pGrid
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub grdProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProveedor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdProveedor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMaterial_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMaterial.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMaterial.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub
    Private Sub grdPielColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPielColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPielColor.DeleteSelectedRows(False)
    End Sub
    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub
    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub CargarNAves()

        Dim lstNavesCombo As New List(Of Entidades.Naves)
        Dim lstNavesMostrar As New List(Of Integer)
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbNave.ValueMember = "PNaveId"
        cmbNave.DisplayMember = "PNombre"

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged

        If dtpFechaFin.MinDate > "31/12/" + dtpFechaInicio.Value.Year.ToString() Then
            dtpFechaFin.MinDate = dtpFechaInicio.Value
            dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()
        Else
            dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()
            dtpFechaFin.MinDate = dtpFechaInicio.Value
        End If

    End Sub

    Private Sub obtenerFiltros()

        vFiltroNave = If(cmbNave.SelectedIndex >= 0, cmbNave.SelectedValue, 0)
        vFiltroFechaInicio = dtpFechaInicio.Value
        vFiltroFechaFin = dtpFechaFin.Value
        vFiltroProveedor = Filtros(grdProveedor)
        vFiltroClasificacion = Filtros(grdMaterial)
        vFiltroColeccion = Filtros(grdColeccion)
        vFiltroCorrida = Filtros(grdCorrida)
        vFiltroPielColor = Filtros(grdPielColor)
        vFiltroModelo = Filtros(grdModelo)

    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim vDatosFiltrados As String = Nothing
        For Each Row As UltraGridRow In grid.Rows
            If vDatosFiltrados <> Nothing Then
                vDatosFiltrados += ","
            End If
            vDatosFiltrados += Row.Cells("Parametro").Value.ToString()
        Next
        Return vDatosFiltrados
    End Function
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

    Private Sub grdProveedor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProveedor.InitializeLayout
        grid_diseño(grdProveedor)
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMaterial.InitializeLayout
        grid_diseño(grdMaterial)
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
    End Sub

    Private Sub grdPielColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout
        grid_diseño(grdPielColor)
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "N0"
            End If
            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwReporte_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle

        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Materiales_Por_Programa"

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", ExportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub

    Public Sub DiseñoGrid()
        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns

            vColumna.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If vColumna.FieldName.Contains("FechaPrograma") Then
                vColumna.Width = 100
                vColumna.Caption = "Fecha Programa"

            ElseIf vColumna.FieldName.Contains("Nave") = True Then
                vColumna.Width = 80

            ElseIf vColumna.FieldName.Contains("NaveId") = True Then
                vColumna.Width = 80
                vColumna.Caption = "ID Nave"

            ElseIf vColumna.FieldName.Contains("Lote") = True Then
                vColumna.Width = 100

            ElseIf vColumna.FieldName.Contains("Marca") = True Then
                vColumna.Visible = False

            ElseIf vColumna.FieldName.Contains("Coleccion") = True Then
                vColumna.Width = 180
                vColumna.Caption = "Colección"

            ElseIf vColumna.FieldName.Contains("Pares") = True Then
                vColumna.Width = 60
                vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            ElseIf vColumna.FieldName.Contains("ModeloSAY") = True Then
                vColumna.Width = 140
                vColumna.Caption = "Modelo SAY"

            ElseIf vColumna.FieldName.Contains("ModeloSICY") = True Then
                vColumna.Width = 140
                vColumna.Caption = "Modelo SICY"

            ElseIf vColumna.FieldName.Contains("PielColor") = True Then
                vColumna.Width = 140
                vColumna.Caption = "Piel/Color"

            ElseIf vColumna.FieldName.Contains("Talla") = True Then
                vColumna.Width = 80
                vColumna.Caption = "Corrida"

            ElseIf vColumna.FieldName.Contains("Horma") = True Then
                vColumna.Width = 100

            ElseIf vColumna.FieldName.Contains("Temporada") = True Then
                vColumna.Width = 150

            ElseIf vColumna.FieldName.Contains("Orden") = True Then
                vColumna.Width = 100

            ElseIf vColumna.FieldName.Contains("Componente") = True Then
                vColumna.Width = 140

            ElseIf vColumna.FieldName.Contains("Clasificacion") = True Then
                vColumna.Width = 100
                vColumna.Caption = "Clasificación"

            ElseIf vColumna.FieldName.Contains("SKU") = True Then
                vColumna.Width = 100

            ElseIf vColumna.FieldName.Contains("Material") = True Then
                vColumna.Width = 240

            ElseIf vColumna.FieldName.Contains("Consumo") = True Then
                vColumna.Width = 140

            ElseIf vColumna.FieldName.Contains("UnidadCompra") = True Then
                vColumna.Width = 100
                vColumna.Caption = "Unidad Compra"

            ElseIf vColumna.FieldName.Contains("Proveedor") = True Then
                vColumna.Width = 350

            ElseIf vColumna.FieldName.Contains("PrecioCompra") = True Then
                vColumna.Width = 100
                vColumna.Caption = "Precio Compra"

            ElseIf vColumna.FieldName.Contains("UnidadProduccion") = True Then
                vColumna.Width = 100
                vColumna.Caption = "Unidad Producción"

            ElseIf vColumna.FieldName.Contains("Factor") = True Then
                vColumna.Width = 80

            ElseIf vColumna.FieldName.Contains("PrecioUM") = True Then
                vColumna.Width = 50
                vColumna.Caption = "Precio UMC"

            ElseIf vColumna.FieldName.Contains("CostoXPar") = True Then
                vColumna.Width = 80
                vColumna.Caption = "Costo X Par"

            ElseIf vColumna.FieldName.Contains("TiempoEntrega") = True Then
                vColumna.Width = 80
                'vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                vColumna.Caption = "Tiempo Entrega"

            Else
                vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vColumna.DisplayFormat.FormatString = "##,##0.0"

            End If

            vColumna.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True

    End Sub


End Class