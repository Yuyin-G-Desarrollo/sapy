Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports System.Net
Imports Stimulsoft.Report
Imports Infragistics.Documents.Excel
Imports DevExpress.Export


Public Class EstadisticasVentasForm

    Dim listInicial As New List(Of String)
    Dim filtro_Agente As String = String.Empty
    Dim filtro_Marca As String = String.Empty
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_Coleccion As String = String.Empty
    Dim filtro_Familia As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim filtro_EstatusArticulos As String = String.Empty
    Dim tipoReporte As Integer = 0
    Dim perfilUsuario As Integer = 0
    Dim ListaColumnasGrid As New List(Of String)
    Dim objBU As New Negocios.CoberturaColeccionesBU
    Dim DTEncabezadoCobertura As DataTable
    Dim dtReporte As DataTable


    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena
    Dim ruta As String = String.Empty
    Dim image As Image
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"

    Dim StreamFoto As System.IO.Stream



    Dim emptyEditor As RepositoryItemPictureEdit


    Private Sub CoberturaColeccionesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU

        'dtpFechaEntregaDel.MinDate = Date.Parse("01/01/2012")
        'dtpFechaEntregaAl.MinDate = Date.Parse("01/01/2012")
        'dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        ''dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        'dtpFechaEntregaAl.Value = New Negocios.ResumenVentasSemanalBU().ConsultarFechaFinEstadVentas_Semanal()

        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU
        dtpFechaEntregaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaEntregaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()


        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        grdAgentes.DataSource = listInicial
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        grdFamiliaDeVentas.DataSource = listInicial
        grdEstatusArticulos.DataSource = listInicial

        dtResultadoPerfil = objBU.reporteEstadisticaFamliasObtenerPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilUsuario = dtResultadoPerfil.Rows(0).Item("IdPerfil")
            If dtResultadoPerfil.Rows(0).Item("IdPerfil") = 44 Then
                grpboxagente.Enabled = False
                Dim objeBU As New Negocios.EstadisticoPedidosBU
                Dim Tabla_ListadoParametros As New DataTable

                Tabla_ListadoParametros = objeBU.ListadoParametrosReportes(8, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                grdAgentes.DataSource = Tabla_ListadoParametros

                With grdAgentes
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With

            End If
        End If

        'Creo mi datatable y columnas
        Dim dtReportes As New DataTable
        dtReportes.Columns.Add("id", GetType(Integer))
        dtReportes.Columns.Add("Descripcion")

        'Renglon es la variable que adicionara renglones a mi datatable
        Dim Renglon As DataRow = dtReportes.NewRow()

        Renglon = dtReportes.NewRow()
        Renglon("id") = 1
        Renglon("Descripcion") = "General - Concentrado Total"
        dtReportes.Rows.Add(Renglon)


        'Renglon = dtReportes.NewRow()
        'Renglon("id") = 2
        'Renglon("Descripcion") = "General - Separado por Cliente"
        'dtReportes.Rows.Add(Renglon)



        Renglon = dtReportes.NewRow()
        Renglon("id") = 3
        Renglon("Descripcion") = "Mensual - Concentrado Total"
        dtReportes.Rows.Add(Renglon)


        'Renglon = dtReportes.NewRow()
        'Renglon("id") = 4
        'Renglon("Descripcion") = "Mensual - Separado por Cliente"
        'dtReportes.Rows.Add(Renglon)



        cmbReporte.DataSource = dtReportes
        cmbReporte.DisplayMember = "Descripcion"
        cmbReporte.ValueMember = "id"

        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        pnPBar.Top = (Me.Height - pnPBar.Height) / 2

        pnlFiltroEstaus.Visible = False


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 260
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        'If dtpFechaEntregaAl.MinDate > "31/12/" + dtpFechaEntregaDel.Value.Year.ToString() Then
        '    dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
        '    dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
        'Else
        '    dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
        '    dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
        'End If
    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.idUsuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = listInicial
    End Sub

    Private Sub btnMarcas_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 3

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarcas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarcas.DataSource = listado.listParametros
        With grdMarcas()
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarColecciones_Click(sender As Object, e As EventArgs) Handles btnLimpiarColecciones.Click
        grdColecciones.DataSource = listInicial
    End Sub

    Private Sub btnColecciones_Click(sender As Object, e As EventArgs) Handles btnColecciones.Click
        Dim listado As New ListadoParametrosReportesForm
        If perfilUsuario <> 44 Then
            listado.tipo_busqueda = 5
        Else
            listado.tipo_busqueda = 6
        End If

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColecciones.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColecciones.DataSource = listado.listParametros
        With grdColecciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportesForm
        If perfilUsuario <> 44 And perfilUsuario <> 74 Then
            listado.tipo_busqueda = 2
        Else
            listado.tipo_busqueda = 4
        End If


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        If perfilUsuario <> 44 Then
            grdAgentes.DataSource = listInicial
        End If

        grdReporte.DataSource = Nothing
        'GridView1.Bands.Clear()
        'GridView1.Columns.Clear()
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        grdFamiliaDeVentas.DataSource = listInicial
        grdEstatusArticulos.DataSource = listInicial
        dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"
        btnAbajo_Click(sender, e)
    End Sub


    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdColecciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColecciones.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSlateGray
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        'For Each row In grid.Rows
        '    row.Activation = Activation.NoEdit
        'Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
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

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColecciones.InitializeLayout
        grid_diseño(grdColecciones)
        grdColecciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colecciones"
    End Sub

    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout
        grid_diseño(grdMarcas)
        grdMarcas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marcas"
    End Sub


    Private Sub grdFamiliaDeVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamiliaDeVentas.InitializeLayout
        grid_diseño(grdFamiliaDeVentas)
        grdFamiliaDeVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia de Ventas"
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReporte.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU
            Dim exportOptions = New XlsxExportOptionsEx()

            Try
                Dim Reporte As Int16 = cmbReporte.SelectedValue

                Select Case Reporte
                    Case 1
                        nombreReporte = "\General_Concentrado_Total"
                        nombreReporteParaExportacion = "GENEREAL CONCENTRADO TOTAL"
                        exportOptions.SheetName = "GeneralConcentradoTotal"
                    Case Else
                        nombreReporte = "\Reporte_"
                        nombreReporteParaExportacion = "Reporte"
                        exportOptions.SheetName = "Reporte"
                End Select


                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvReporte.GroupCount > 0 Then
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            'grdReporte.ExportToXlsx()

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If
    End Sub

    Public Sub ExportarReporteGeneral()
        If bgvReporte.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx" ';*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName

            Dim reporte As Integer = cmbReporte.SelectedIndex
            Me.Cursor = Cursors.WaitCursor

            If result = Windows.Forms.DialogResult.OK Then

                pnPBar.Visible = True
                lblInfo.Text = "Ejecutando consulta...."
                pBar.Minimum = 0
                pBar.ForeColor = Color.Gray
                System.Windows.Forms.Application.DoEvents()

                Try
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    Dim Total As Integer = dtReporte.Rows.Count
                    Dim Cont As Integer = 0

                    ' Create a merged region that will be a header to the column headers
                    Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 6)
                    ' Set the value of the merged region
                    mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                    worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                    worksheet.Rows(1).Cells.Item(0).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)


                    pBar.Maximum = Total
                    lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()
                    'CUANDO EL DATAGRID TIENE 15 COLUMNAS 
                    If bgvReporte.Columns.Count <= 16 Then
                        worksheet.Columns.Item(0).Width = 1825  '#
                        worksheet.Columns.Item(1).Width = 8000  'FAMILIA 
                        worksheet.Columns.Item(2).Width = 1825  'ART 9125
                        worksheet.Columns.Item(3).Width = 2500  'FOTO
                        worksheet.Columns.Item(4).Width = 9125  'COLECCION
                        worksheet.Columns.Item(5).Width = 1900  'MODELO
                        worksheet.Columns.Item(6).Width = 5600  'PIEL_COLOR

                        For i As Int16 = 7 To bgvReporte.Columns.Count - 7
                            worksheet.Columns.Item(i).Width = 1700 ' tallas
                        Next

                        Dim inicio As Integer = 2

                        worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
                        worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
                        worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
                        worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
                        worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
                        worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
                        worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR

                        ''FORMATO DE LAS COLUMNAS
                        For j As Int16 = 0 To 13 Step 1
                            worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        Next

                        ''TALLAS
                        Dim tallas As Int16 = 0 ''variable para saber cuantas columnas 
                        Dim terminaColumnasFacturacion As Boolean = False
                        For i As Int16 = 6 To bgvReporte.Columns.Count - 1

                            If Not terminaColumnasFacturacion Then
                                tallas = tallas + 1
                                If bgvReporte.Columns(i).FieldName.ToString() = "TOTALF" Then
                                    terminaColumnasFacturacion = True
                                End If
                            End If
                            worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                        Next


                        'col por facturar
                        Dim porFacturarInicio As Int16 = 6 + tallas + 1 ''variable para saber cuantas columnas 
                        Dim porFacturarFIN As Int16 = 0
                        Dim terminaColumnasPorFacturacion As Boolean = False
                        For i As Int16 = porFacturarInicio To bgvReporte.Columns.Count - 1

                            If Not terminaColumnasPorFacturacion Then
                                porFacturarFIN = porFacturarFIN + 1
                                If bgvReporte.Columns(i).FieldName.ToString() = "TOTALPF" Then
                                    terminaColumnasPorFacturacion = True
                                End If
                            End If

                            'worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                        Next


                        tallas = tallas - 1
                        Dim mergedRegionFacturado As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 7, 1, 7 + tallas)
                        mergedRegionFacturado.Value = "FACTURADO"

                        porFacturarFIN = porFacturarFIN - 1
                        Dim mergedRegionPorFacturar As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, porFacturarInicio, 1, porFacturarInicio + porFacturarFIN)
                        mergedRegionPorFacturar.Value = "POR FACTURAR"

                        worksheet.Rows.Item(1).Cells.Item(porFacturarInicio + porFacturarFIN + 1).Value = "TOTAL"

                        For i As Int16 = 1 To inicio Step 1
                            For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                                worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                            Next
                        Next


                        'FILAS DEL DATAGRID
                        For r As Integer = (0) To bgvReporte.RowCount - 1
                            worksheet.Rows.Item(r + inicio + 1).Height = 800

                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
                            ' worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(7).FieldName.ToString())   'PIEL_COLOR
                            '' worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA


                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
                            ' worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU 'COL
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString()) '%SKU 'COL

                            For i As Int16 = 7 To bgvReporte.Columns.Count - 1
                                If bgvReporte.Columns(i).FieldName.ToString = "%SKU" Or bgvReporte.Columns(i).FieldName.ToString = "%COL" Then
                                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
                                Else
                                    If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString)) Then
                                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = CInt(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString()))
                                        worksheet.Rows(r + inicio + 1).Cells(i).CellFormat.FormatString = "#,#"


                                        'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.
                                    End If
                                End If

                            Next




                            If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
                                Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))

                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                Else
                                    Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                End If

                                ' The top-left corner of the image should be at the 
                                ' top-left corner of cell A1
                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                ' The bottom-right corner of the image should be at 
                                ' the bottom-right corner of cell A1
                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                worksheet.Shapes.Add(imageShape)

                            End If
                            Cont += 1
                            pBar.Value = Cont
                        Next

                        For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
                            For j As Int16 = 0 To 15 Step 1
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                            Next
                        Next

                        'For r As Integer = (0) To bgvReporte.RowCount - 1
                        '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                        'Next

                        'worksheet.Columns.Item(0).Hidden = True

                    Else ' CUANDO EL DATATABLE TIENE MAS DE 15 COLUMNAS 
                        'MsgBox("Para las tallas")
                        Dim inicio As Integer = 2

                        Dim mergedRegion As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(0, 0, 0, 5)
                        ' Set the value of the merged region
                        mergedRegion.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                        worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center


                        worksheet.Columns.Item(0).Width = 1825  '#
                        worksheet.Columns.Item(1).Width = 8000  'FAMILIA 
                        worksheet.Columns.Item(2).Width = 1825  'ART 9125
                        worksheet.Columns.Item(3).Width = 2500  'FOTO
                        worksheet.Columns.Item(4).Width = 9125  'COLECCION
                        worksheet.Columns.Item(5).Width = 1900  'MODELO
                        worksheet.Columns.Item(6).Width = 5600  'PIEL_COLOR

                        For i As Int16 = 7 To bgvReporte.Columns.Count - 7
                            worksheet.Columns.Item(i).Width = 1700 ' tallas

                        Next

                        worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
                        worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
                        worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
                        worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
                        worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
                        worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
                        worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR

                        ''FORMATO DE LAS COLUMNAS
                        For j As Int16 = 0 To 13 Step 1
                            worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        Next
                        'MESES
                        Dim meses As Int16 = 0 ''variable para saber cuantas columnas 
                        Dim terminaColumnasFacturacion As Boolean = False
                        For i As Int16 = 6 To bgvReporte.Columns.Count - 1

                            If Not terminaColumnasFacturacion Then
                                meses = meses + 1
                                If bgvReporte.Columns(i).FieldName.ToString() = "TOTALF" Then
                                    terminaColumnasFacturacion = True
                                End If
                            End If

                            worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                        Next

                        'col por facturar
                        Dim porFacturarInicio As Int16 = 6 + meses + 1 ''variable para saber cuantas columnas 
                        Dim porFacturarFIN As Int16 = 0
                        Dim terminaColumnasPorFacturacion As Boolean = False
                        For i As Int16 = porFacturarInicio To bgvReporte.Columns.Count - 1

                            If Not terminaColumnasPorFacturacion Then
                                porFacturarFIN = porFacturarFIN + 1
                                If bgvReporte.Columns(i).FieldName.ToString() = "TOTALPF" Then
                                    terminaColumnasPorFacturacion = True
                                End If
                            End If

                            'worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                        Next

                        meses = meses - 1
                        Dim mergedRegionFacturado As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 7, 1, 7 + meses)
                        ' Set the value of the merged region
                        mergedRegionFacturado.Value = "FACTURADO"

                        porFacturarFIN = porFacturarFIN - 1
                        Dim mergedRegionPorFacturar As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, porFacturarInicio, 1, porFacturarInicio + porFacturarFIN)
                        ' Set the value of the merged region
                        mergedRegionPorFacturar.Value = "POR FACTURAR"

                        worksheet.Rows.Item(1).Cells.Item(porFacturarInicio + porFacturarFIN + 1).Value = "TOTAL"

                        For i As Int16 = 1 To inicio Step 1
                            For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                                worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next
                        'FILAS DEL DATAGRID
                        For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
                            worksheet.Rows.Item(r + inicio + 1).Height = 900 '1145

                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'PIEL_COLOR
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
                            ' worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU '%COL
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString())


                            For i As Int16 = 7 To bgvReporte.Columns.Count - 1
                                If bgvReporte.Columns(i).FieldName.ToString = "%SKU" Or bgvReporte.Columns(i).FieldName.ToString = "%COL" Then
                                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
                                Else
                                    If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString)) Then
                                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
                                        worksheet.Rows(r + inicio + 1).Cells(i).CellFormat.FormatString = "#,#"


                                        'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.
                                    End If
                                End If

                            Next


                            If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
                                Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))


                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                Else
                                    Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                End If

                                ' The top-left corner of the image should be at the 
                                ' top-left corner of cell A1
                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                ' The bottom-right corner of the image should be at 
                                ' the bottom-right corner of cell A1
                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                worksheet.Shapes.Add(imageShape)
                            End If
                            Cont += 1
                            pBar.Value = Cont
                            lblInfo.Text = "Exportando datos..." & Cont.ToString()
                            System.Windows.Forms.Application.DoEvents()

                        Next

                        lblInfo.Text = "Espere por favor..."
                        System.Windows.Forms.Application.DoEvents()

                        For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
                            For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1 '13

                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                            Next

                            'lblInfo.Text = "Exportando datos..." & i.ToString()
                            'System.Windows.Forms.Application.DoEvents()
                        Next

                        'For r As Integer = (0) To bgvReporte.RowCount - 1
                        '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                        'Next

                        'worksheet.Columns.Item(0).Hidden = True
                    End If
                    System.Windows.Forms.Application.DoEvents()


                    workbook.Save(fileName)

                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)

                Catch ex As Exception
                    Dim objMensajeError As New ErroresForm
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.mensaje = ex.Message
                    objMensajeError.ShowDialog()
                Finally
                    pBar.Value = pBar.Minimum
                    pnPBar.Visible = False
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        End If
    End Sub

    Public Sub ExportarReporteMensual()
        If bgvReporte.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx" ';*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName

            Dim reporte As Integer = cmbReporte.SelectedIndex
            Me.Cursor = Cursors.WaitCursor

            If result = Windows.Forms.DialogResult.OK Then

                pnPBar.Visible = True
                lblInfo.Text = "Ejecutando consulta...."
                pBar.Minimum = 0
                pBar.ForeColor = Color.Gray
                System.Windows.Forms.Application.DoEvents()

                Try
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    Dim Total As Integer = dtReporte.Rows.Count
                    Dim Cont As Integer = 0

                    pBar.Maximum = Total
                    lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()
                    'CUANDO EL DATAGRID TIENE 15 COLUMNAS 
                    If bgvReporte.Columns.Count <= 16 Then
                        worksheet.Columns.Item(0).Width = 1825  '#
                        worksheet.Columns.Item(1).Width = 9125  'FAMILIA 
                        worksheet.Columns.Item(2).Width = 1825  'ART 9125
                        worksheet.Columns.Item(3).Width = 2500  'FOTO
                        worksheet.Columns.Item(4).Width = 9125  'COLECCION
                        worksheet.Columns.Item(5).Width = 1825  'MODELO
                        worksheet.Columns.Item(6).Width = 1825  'CLASIF
                        worksheet.Columns.Item(7).Width = 5000  'PIEL_COLOR
                        worksheet.Columns.Item(8).Width = 2000  'CORRIDA
                        worksheet.Columns.Item(9).Width = 9125  'ESTATUS
                        worksheet.Columns.Item(10).Width = 5475  'F_VIGENCIA
                        worksheet.Columns.Item(11).Width = 2190 'TOTALF
                        worksheet.Columns.Item(12).Width = 2190 'TOTALPF
                        worksheet.Columns.Item(13).Width = 3000 'TOTAL
                        worksheet.Columns.Item(14).Width = 2190 '%SKU
                        worksheet.Columns.Item(15).Width = 2190 'COL

                        ' Create a merged region that will be a header to the column headers
                        Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 10)
                        ' Set the value of the merged region
                        mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                        worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(1).Cells.Item(0).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                        Dim inicio As Integer = 2

                        worksheet.Rows.Item(1).Cells.Item(11).Value = "FACTURADO"
                        worksheet.Rows.Item(1).Cells.Item(12).Value = "POR FACTURAR"
                        worksheet.Rows.Item(1).Cells.Item(13).Value = "TOTAL"
                        worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
                        worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
                        worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
                        worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
                        worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
                        worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
                        worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(6).FieldName.ToString() 'CLASIF
                        worksheet.Rows.Item(inicio).Cells.Item(7).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR
                        worksheet.Rows.Item(inicio).Cells.Item(8).Value = bgvReporte.Columns(8).FieldName.ToString() 'CORRIDA
                        worksheet.Rows.Item(inicio).Cells.Item(9).Value = bgvReporte.Columns(9).FieldName.ToString() 'ESTATUS
                        worksheet.Rows.Item(inicio).Cells.Item(10).Value = bgvReporte.Columns(10).FieldName.ToString() 'F_VIGENCIA
                        worksheet.Rows.Item(inicio).Cells.Item(11).Value = bgvReporte.Columns(11).FieldName.ToString() 'TOTALF
                        worksheet.Rows.Item(inicio).Cells.Item(12).Value = bgvReporte.Columns(12).FieldName.ToString() 'TOTALPF
                        worksheet.Rows.Item(inicio).Cells.Item(13).Value = bgvReporte.Columns(13).FieldName.ToString() 'TOTAL
                        worksheet.Rows.Item(inicio).Cells.Item(14).Value = bgvReporte.Columns(14).FieldName.ToString() '%SKU
                        worksheet.Rows.Item(inicio).Cells.Item(15).Value = bgvReporte.Columns(15).FieldName.ToString() 'COL

                        ''FORMATO DE LAS COLUMNAS
                        For j As Int16 = 0 To 13 Step 1 ''ENCABEZADO 1
                            worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(1).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        Next


                        For i As Int16 = inicio To inicio Step 1 ''ENCABEZADO 2
                            For j As Int16 = 0 To 15 Step 1
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next
                        'FILAS DEL DATAGRID
                        For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
                            worksheet.Rows.Item(r + inicio + 1).Height = 800 '1145

                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(7).FieldName.ToString())   'PIEL_COLOR
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA


                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU 'COL
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString()) '%SKU 'COL

                            If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
                                Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))

                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                Else
                                    Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                End If

                                ' The top-left corner of the image should be at the 
                                ' top-left corner of cell A1
                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                ' The bottom-right corner of the image should be at 
                                ' the bottom-right corner of cell A1
                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                worksheet.Shapes.Add(imageShape)

                            End If
                            Cont += 1
                            pBar.Value = Cont
                        Next

                        For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
                            For j As Int16 = 0 To 15 Step 1

                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)

                            Next
                        Next

                        'For r As Integer = (0) To bgvReporte.RowCount - 1
                        '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                        'Next

                        'worksheet.Columns.Item(0).Hidden = True

                    Else ' CUANDO EL DATATABLE TIENE MAS DE 15 COLUMNAS 
                        'MsgBox("Para las tallas")
                        Dim inicio As Integer = 2
                        If reporte = 1 Then ''seleccionaro reporte mensual
                            ' Create a merged region that will be a header to the column headers
                            Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 10)
                            ' Set the value of the merged region
                            mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                            worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center

                            worksheet.Columns.Item(0).Width = 1825  '#
                            worksheet.Columns.Item(1).Width = 8000  'FAMILIA 
                            worksheet.Columns.Item(2).Width = 1825  'ART 9125
                            worksheet.Columns.Item(3).Width = 2500  'FOTO
                            worksheet.Columns.Item(4).Width = 9125  'COLECCION
                            worksheet.Columns.Item(5).Width = 1900  'MODELO
                            worksheet.Columns.Item(6).Width = 1825  'CLASIF
                            worksheet.Columns.Item(7).Width = 5000  'PIEL_COLOR
                            worksheet.Columns.Item(8).Width = 2150  'CORRIDA
                            worksheet.Columns.Item(9).Width = 9125  'ESTATUS
                            worksheet.Columns.Item(10).Width = 5475  'F_VIGENCIA
                            'worksheet.Columns.Item(11).Width = 2190 'TOTALF
                            'worksheet.Columns.Item(12).Width = 2190 'TOTALPF
                            'worksheet.Columns.Item(13).Width = 3000 'TOTAL
                            'worksheet.Columns.Item(14).Width = 2190 '%SKU
                            'worksheet.Columns.Item(15).Width = 2190 'COL

                            worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
                            worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
                            worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
                            worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
                            worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
                            worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
                            worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(6).FieldName.ToString() 'CLASIF
                            worksheet.Rows.Item(inicio).Cells.Item(7).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR
                            worksheet.Rows.Item(inicio).Cells.Item(8).Value = bgvReporte.Columns(8).FieldName.ToString() 'CORRIDA
                            worksheet.Rows.Item(inicio).Cells.Item(9).Value = bgvReporte.Columns(9).FieldName.ToString() 'ESTATUS
                            worksheet.Rows.Item(inicio).Cells.Item(10).Value = bgvReporte.Columns(10).FieldName.ToString() 'F_VIGENCIA

                            For i As Int16 = 11 To bgvReporte.Columns.Count - 7
                                worksheet.Columns.Item(i).Width = 1500 ' tallas
                            Next

                            ''FORMATO DE LAS COLUMNAS
                            For j As Int16 = 0 To 13 Step 1
                                worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            Next
                            'MESES
                            Dim meses1 As Int16 = 0 ''variable para saber cuantas columnas 
                            Dim terminaColumnasFacturacion1 As Boolean = False
                            For i As Int16 = 11 To bgvReporte.Columns.Count - 1

                                If Not terminaColumnasFacturacion1 Then
                                    meses1 = meses1 + 1
                                    If bgvReporte.Columns(i).FieldName.ToString() = "TOTALF" Then
                                        terminaColumnasFacturacion1 = True
                                    End If
                                End If
                                worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                            Next
                            meses1 = meses1 - 1
                            Dim mergedRegionFacturado1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 11, 1, 11 + meses1)
                            ' Set the value of the merged region
                            mergedRegionFacturado1.Value = "FACTURADO"
                            worksheet.Rows.Item(1).Cells.Item(11 + meses1 + 1).Value = "POR FACTURAR"
                            worksheet.Rows.Item(1).Cells.Item(11 + meses1 + 2).Value = "TOTAL"

                            For i As Int16 = 1 To inicio Step 1
                                For j As Int16 = 0 To bgvReporte.Columns.Count Step 1
                                    worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                                    worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                    worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                    worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                    worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                Next
                            Next
                            'FILAS DEL DATAGRID
                            For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
                                worksheet.Rows.Item(r + inicio + 1).Height = 900 '1145

                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(7).FieldName.ToString())   'PIEL_COLOR
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU '%COL
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString())


                                For i As Int16 = 11 To bgvReporte.Columns.Count - 1
                                    If bgvReporte.Columns(i).FieldName.ToString = "%SKU" Or bgvReporte.Columns(i).FieldName.ToString = "%COL" Then
                                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
                                    Else
                                        If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString)) Then
                                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = CInt(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString()))
                                            worksheet.Rows(r + inicio + 1).Cells(i).CellFormat.FormatString = "#,#"
                                        End If

                                    End If

                                Next


                                If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
                                    Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))


                                    Dim Ancho As Double = imageShape.Image.Width
                                    Dim alto As Double = imageShape.Image.Height

                                    If imageShape.Image.Width > imageShape.Image.Height Then
                                        alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                    Else
                                        Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                    End If

                                    ' The top-left corner of the image should be at the 
                                    ' top-left corner of cell A1
                                    imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                    imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                    ' The bottom-right corner of the image should be at 
                                    ' the bottom-right corner of cell A1
                                    imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                    imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                    imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                    worksheet.Shapes.Add(imageShape)
                                End If
                                Cont += 1
                                pBar.Value = Cont
                                lblInfo.Text = "Exportando datos..." & Cont.ToString()
                                System.Windows.Forms.Application.DoEvents()

                            Next

                            lblInfo.Text = "Espere por favor..."
                            System.Windows.Forms.Application.DoEvents()

                            For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
                                For j As Int16 = 0 To bgvReporte.Columns.Count Step 1 '13

                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                    'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                    'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                    'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                Next

                                'lblInfo.Text = "Exportando datos..." & i.ToString()
                                'System.Windows.Forms.Application.DoEvents()
                            Next

                            'For r As Integer = (0) To bgvReporte.RowCount - 1
                            '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                            'Next

                            'worksheet.Columns.Item(0).Hidden = True


                        Else ''reporte general 
                            Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 6)
                            ' Set the value of the merged region
                            mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                            worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center


                            worksheet.Columns.Item(0).Width = 1825  '#
                            worksheet.Columns.Item(1).Width = 8000  'FAMILIA 
                            worksheet.Columns.Item(2).Width = 1825  'ART 9125
                            worksheet.Columns.Item(3).Width = 2500  'FOTO
                            worksheet.Columns.Item(4).Width = 9125  'COLECCION
                            worksheet.Columns.Item(5).Width = 1900  'MODELO
                            worksheet.Columns.Item(6).Width = 5600  'PIEL_COLOR

                            For i As Int16 = 7 To bgvReporte.Columns.Count - 7
                                worksheet.Columns.Item(i).Width = 1700 ' tallas

                            Next

                            worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
                            worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
                            worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
                            worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
                            worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
                            worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
                            worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR

                            ''FORMATO DE LAS COLUMNAS
                            For j As Int16 = 0 To 13 Step 1
                                worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            Next
                            'MESES
                            Dim meses As Int16 = 0 ''variable para saber cuantas columnas 
                            Dim terminaColumnasFacturacion As Boolean = False
                            For i As Int16 = 6 To bgvReporte.Columns.Count - 1

                                If Not terminaColumnasFacturacion Then
                                    meses = meses + 1
                                    If bgvReporte.Columns(i).FieldName.ToString() = "TOTALF" Then
                                        terminaColumnasFacturacion = True
                                    End If
                                End If

                                worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                            Next

                            'col por facturar
                            Dim porFacturarInicio As Int16 = 6 + meses + 1 ''variable para saber cuantas columnas 
                            Dim porFacturarFIN As Int16 = 0
                            Dim terminaColumnasPorFacturacion As Boolean = False
                            For i As Int16 = porFacturarInicio To bgvReporte.Columns.Count - 1

                                If Not terminaColumnasPorFacturacion Then
                                    porFacturarFIN = porFacturarFIN + 1
                                    If bgvReporte.Columns(i).FieldName.ToString() = "TOTALPF" Then
                                        terminaColumnasPorFacturacion = True
                                    End If
                                End If

                                'worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
                            Next

                            meses = meses - 1
                            Dim mergedRegionFacturado As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 7, 1, 7 + meses)
                            ' Set the value of the merged region
                            mergedRegionFacturado.Value = "FACTURADO"

                            porFacturarFIN = porFacturarFIN - 1
                            Dim mergedRegionPorFacturar As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, porFacturarInicio, 1, porFacturarInicio + porFacturarFIN)
                            ' Set the value of the merged region
                            mergedRegionPorFacturar.Value = "POR FACTURAR"

                            worksheet.Rows.Item(1).Cells.Item(porFacturarInicio + porFacturarFIN + 1).Value = "TOTAL"

                            For i As Int16 = 1 To inicio Step 1
                                For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1
                                    worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                    worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

                                    worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                    worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                    worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                    worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                Next
                            Next
                            'FILAS DEL DATAGRID
                            For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
                                worksheet.Rows.Item(r + inicio + 1).Height = 900 '1145

                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'PIEL_COLOR
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
                                ' worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU '%COL
                                'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString())


                                For i As Int16 = 7 To bgvReporte.Columns.Count - 1
                                    If bgvReporte.Columns(i).FieldName.ToString = "%SKU" Or bgvReporte.Columns(i).FieldName.ToString = "%COL" Then
                                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
                                    Else
                                        If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString)) Then
                                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = CInt(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString()))
                                            worksheet.Rows(r + inicio + 1).Cells(i).CellFormat.FormatString = "#,#"


                                            'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.
                                        End If
                                    End If

                                Next


                                If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
                                    Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))


                                    Dim Ancho As Double = imageShape.Image.Width
                                    Dim alto As Double = imageShape.Image.Height

                                    If imageShape.Image.Width > imageShape.Image.Height Then
                                        alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                    Else
                                        Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                    End If

                                    ' The top-left corner of the image should be at the 
                                    ' top-left corner of cell A1
                                    imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                    imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                    ' The bottom-right corner of the image should be at 
                                    ' the bottom-right corner of cell A1
                                    imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
                                    imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                    imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                    worksheet.Shapes.Add(imageShape)
                                End If
                                Cont += 1
                                pBar.Value = Cont
                                lblInfo.Text = "Exportando datos..." & Cont.ToString()
                                System.Windows.Forms.Application.DoEvents()

                            Next

                            lblInfo.Text = "Espere por favor..."
                            System.Windows.Forms.Application.DoEvents()

                            For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
                                For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1 '13

                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                    worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
                                Next

                                'lblInfo.Text = "Exportando datos..." & i.ToString()
                                'System.Windows.Forms.Application.DoEvents()
                            Next

                            'For r As Integer = (0) To bgvReporte.RowCount - 1
                            '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                            'Next

                            'worksheet.Columns.Item(0).Hidden = True


                        End If
                    End If
                    System.Windows.Forms.Application.DoEvents()


                    workbook.Save(fileName)

                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)

                Catch ex As Exception
                    Dim objMensajeError As New ErroresForm
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.mensaje = ex.Message
                    objMensajeError.ShowDialog()
                Finally
                    pBar.Value = pBar.Minimum
                    pnPBar.Visible = False
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        End If
    End Sub

    Private Sub btnExportarConFoto_Click(sender As Object, e As EventArgs) Handles btnExportarConFoto.Click

        If cmbReporte.SelectedIndex = 0 Then
            ExportarReporteGeneral()
        Else
            ExportarReporteMensual()
        End If

        'If bgvReporte.DataRowCount > 0 Then
        '    Dim sfd As New SaveFileDialog
        '    sfd.DefaultExt = "xls"
        '    sfd.Filter = "Excel Files|*.xls;*.xlsx" ';*.xlsm"

        '    Dim result As DialogResult = sfd.ShowDialog()
        '    Dim fileName As String = sfd.FileName

        '    Dim reporte As Integer = cmbReporte.SelectedIndex
        '    Me.Cursor = Cursors.WaitCursor

        '    If result = Windows.Forms.DialogResult.OK Then

        '        pnPBar.Visible = True
        '        lblInfo.Text = "Ejecutando consulta...."
        '        pBar.Minimum = 0
        '        pBar.ForeColor = Color.Gray
        '        System.Windows.Forms.Application.DoEvents()

        '        Try
        '            Dim workbook As New Infragistics.Documents.Excel.Workbook
        '            Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

        '            Dim Total As Integer = dtReporte.Rows.Count
        '            Dim Cont As Integer = 0

        '            pBar.Maximum = Total
        '            lblInfo.Text = "Espere por favor..."
        '            System.Windows.Forms.Application.DoEvents()
        '            'CUANDO EL DATAGRID TIENE 15 COLUMNAS 
        '            If bgvReporte.Columns.Count <= 16 Then
        '                worksheet.Columns.Item(0).Width = 1825  '#
        '                worksheet.Columns.Item(1).Width = 9125  'FAMILIA 
        '                worksheet.Columns.Item(2).Width = 1825  'ART 9125
        '                worksheet.Columns.Item(3).Width = 2500  'FOTO
        '                worksheet.Columns.Item(4).Width = 9125  'COLECCION
        '                worksheet.Columns.Item(5).Width = 1825  'MODELO
        '                worksheet.Columns.Item(6).Width = 1825  'CLASIF
        '                worksheet.Columns.Item(7).Width = 5000  'PIEL_COLOR
        '                worksheet.Columns.Item(8).Width = 2000  'CORRIDA
        '                worksheet.Columns.Item(9).Width = 9125  'ESTATUS
        '                worksheet.Columns.Item(10).Width = 5475  'F_VIGENCIA
        '                worksheet.Columns.Item(11).Width = 2190 'TOTALF
        '                worksheet.Columns.Item(12).Width = 2190 'TOTALPF
        '                worksheet.Columns.Item(13).Width = 3000 'TOTAL
        '                worksheet.Columns.Item(14).Width = 2190 '%SKU
        '                worksheet.Columns.Item(15).Width = 2190 'COL

        '                ' Create a merged region that will be a header to the column headers
        '                Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 10)
        '                ' Set the value of the merged region
        '                mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
        '                worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                worksheet.Rows(1).Cells.Item(0).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

        '                Dim inicio As Integer = 2

        '                worksheet.Rows.Item(1).Cells.Item(11).Value = "FACTURADO"
        '                worksheet.Rows.Item(1).Cells.Item(12).Value = "POR FACTURAR"
        '                worksheet.Rows.Item(1).Cells.Item(13).Value = "TOTAL"
        '                worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
        '                worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
        '                worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
        '                worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
        '                worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
        '                worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
        '                worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(6).FieldName.ToString() 'CLASIF
        '                worksheet.Rows.Item(inicio).Cells.Item(7).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR
        '                worksheet.Rows.Item(inicio).Cells.Item(8).Value = bgvReporte.Columns(8).FieldName.ToString() 'CORRIDA
        '                worksheet.Rows.Item(inicio).Cells.Item(9).Value = bgvReporte.Columns(9).FieldName.ToString() 'ESTATUS
        '                worksheet.Rows.Item(inicio).Cells.Item(10).Value = bgvReporte.Columns(10).FieldName.ToString() 'F_VIGENCIA
        '                worksheet.Rows.Item(inicio).Cells.Item(11).Value = bgvReporte.Columns(11).FieldName.ToString() 'TOTALF
        '                worksheet.Rows.Item(inicio).Cells.Item(12).Value = bgvReporte.Columns(12).FieldName.ToString() 'TOTALPF
        '                worksheet.Rows.Item(inicio).Cells.Item(13).Value = bgvReporte.Columns(13).FieldName.ToString() 'TOTAL
        '                worksheet.Rows.Item(inicio).Cells.Item(14).Value = bgvReporte.Columns(14).FieldName.ToString() '%SKU
        '                worksheet.Rows.Item(inicio).Cells.Item(15).Value = bgvReporte.Columns(15).FieldName.ToString() 'COL

        '                ''FORMATO DE LAS COLUMNAS
        '                For j As Int16 = 0 To 13 Step 1 ''ENCABEZADO 1
        '                    worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                    worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                    worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                    worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                    worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                    worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                    worksheet.Rows(1).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
        '                Next


        '                For i As Int16 = inicio To inicio Step 1 ''ENCABEZADO 2
        '                    For j As Int16 = 0 To 15 Step 1
        '                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
        '                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                        worksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
        '                    Next
        '                Next
        '                'FILAS DEL DATAGRID
        '                For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
        '                    worksheet.Rows.Item(r + inicio + 1).Height = 800 '1145

        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
        '                    'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(7).FieldName.ToString())   'PIEL_COLOR
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA


        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU 'COL
        '                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString()) '%SKU 'COL

        '                    If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
        '                        Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
        '                    New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))

        '                        Dim Ancho As Double = imageShape.Image.Width
        '                        Dim alto As Double = imageShape.Image.Height

        '                        If imageShape.Image.Width > imageShape.Image.Height Then
        '                            alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
        '                        Else
        '                            Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
        '                        End If

        '                        ' The top-left corner of the image should be at the 
        '                        ' top-left corner of cell A1
        '                        imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
        '                        imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

        '                        ' The bottom-right corner of the image should be at 
        '                        ' the bottom-right corner of cell A1
        '                        imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
        '                        imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

        '                        imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

        '                        worksheet.Shapes.Add(imageShape)

        '                    End If
        '                    Cont += 1
        '                    pBar.Value = Cont
        '                Next

        '                For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
        '                    For j As Int16 = 0 To 15 Step 1

        '                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                        worksheet.Rows(i).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                        'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                        'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                        'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                        'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)

        '                    Next
        '                Next

        '                'For r As Integer = (0) To bgvReporte.RowCount - 1
        '                '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
        '                'Next

        '                'worksheet.Columns.Item(0).Hidden = True

        '            Else ' CUANDO EL DATATABLE TIENE MAS DE 15 COLUMNAS 
        '                'MsgBox("Para las tallas")
        '                Dim inicio As Integer = 2
        '                If reporte = 1 Then ''seleccionaro reporte mensual
        '                    ' Create a merged region that will be a header to the column headers
        '                    Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 10)
        '                    ' Set the value of the merged region
        '                    mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
        '                    worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center

        '                    worksheet.Columns.Item(0).Width = 1825  '#
        '                    worksheet.Columns.Item(1).Width = 8000  'FAMILIA 
        '                    worksheet.Columns.Item(2).Width = 1825  'ART 9125
        '                    worksheet.Columns.Item(3).Width = 2500  'FOTO
        '                    worksheet.Columns.Item(4).Width = 9125  'COLECCION
        '                    worksheet.Columns.Item(5).Width = 1900  'MODELO
        '                    worksheet.Columns.Item(6).Width = 1825  'CLASIF
        '                    worksheet.Columns.Item(7).Width = 5000  'PIEL_COLOR
        '                    worksheet.Columns.Item(8).Width = 2150  'CORRIDA
        '                    worksheet.Columns.Item(9).Width = 9125  'ESTATUS
        '                    worksheet.Columns.Item(10).Width = 5475  'F_VIGENCIA
        '                    'worksheet.Columns.Item(11).Width = 2190 'TOTALF
        '                    'worksheet.Columns.Item(12).Width = 2190 'TOTALPF
        '                    'worksheet.Columns.Item(13).Width = 3000 'TOTAL
        '                    'worksheet.Columns.Item(14).Width = 2190 '%SKU
        '                    'worksheet.Columns.Item(15).Width = 2190 'COL

        '                    For i As Int16 = 11 To bgvReporte.Columns.Count - 7
        '                        worksheet.Columns.Item(i).Width = 1500 ' tallas
        '                    Next

        '                    ''FORMATO DE LAS COLUMNAS
        '                    For j As Int16 = 0 To 13 Step 1
        '                        worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                        worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                    Next
        '                    'MESES
        '                    Dim meses1 As Int16 = 0 ''variable para saber cuantas columnas 
        '                    Dim terminaColumnasFacturacion1 As Boolean = False
        '                    For i As Int16 = 11 To bgvReporte.Columns.Count - 1

        '                        If Not terminaColumnasFacturacion1 Then
        '                            meses1 = meses1 + 1
        '                            If bgvReporte.Columns(i).FieldName.ToString() = "TOTALF" Then
        '                                terminaColumnasFacturacion1 = True
        '                            End If
        '                        End If
        '                        worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
        '                    Next
        '                    meses1 = meses1 - 1
        '                    Dim mergedRegionFacturado1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 11, 1, 11 + meses1)
        '                    ' Set the value of the merged region
        '                    mergedRegionFacturado1.Value = "FACTURADO"
        '                    worksheet.Rows.Item(1).Cells.Item(11 + meses1 + 1).Value = "POR FACTURAR"
        '                    worksheet.Rows.Item(1).Cells.Item(11 + meses1 + 2).Value = "TOTAL"

        '                    For i As Int16 = 1 To inicio Step 1
        '                        For j As Int16 = 0 To bgvReporte.Columns.Count Step 1
        '                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
        '                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

        '                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        Next
        '                    Next
        '                    'FILAS DEL DATAGRID
        '                    For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
        '                        worksheet.Rows.Item(r + inicio + 1).Height = 900 '1145

        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(7).FieldName.ToString())   'PIEL_COLOR
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU '%COL
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString())


        '                        For i As Int16 = 11 To bgvReporte.Columns.Count - 1
        '                            If bgvReporte.Columns(i).FieldName.ToString = "%SKU" Or bgvReporte.Columns(i).FieldName.ToString = "%COL" Then
        '                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
        '                            Else
        '                                If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString)) Then
        '                                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = CInt(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString()))
        '                                End If


        '                            End If

        '                        Next


        '                        If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
        '                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
        '                    New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))


        '                            Dim Ancho As Double = imageShape.Image.Width
        '                            Dim alto As Double = imageShape.Image.Height

        '                            If imageShape.Image.Width > imageShape.Image.Height Then
        '                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
        '                            Else
        '                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
        '                            End If

        '                            ' The top-left corner of the image should be at the 
        '                            ' top-left corner of cell A1
        '                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
        '                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

        '                            ' The bottom-right corner of the image should be at 
        '                            ' the bottom-right corner of cell A1
        '                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
        '                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

        '                            imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

        '                            worksheet.Shapes.Add(imageShape)
        '                        End If
        '                        Cont += 1
        '                        pBar.Value = Cont
        '                        lblInfo.Text = "Exportando datos..." & Cont.ToString()
        '                        System.Windows.Forms.Application.DoEvents()

        '                    Next

        '                    lblInfo.Text = "Espere por favor..."
        '                    System.Windows.Forms.Application.DoEvents()

        '                    For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
        '                        For j As Int16 = 0 To bgvReporte.Columns.Count Step 1 '13

        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                            'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                            'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                            'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                            'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                        Next

        '                        'lblInfo.Text = "Exportando datos..." & i.ToString()
        '                        'System.Windows.Forms.Application.DoEvents()
        '                    Next

        '                    'For r As Integer = (0) To bgvReporte.RowCount - 1
        '                    '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
        '                    'Next

        '                    'worksheet.Columns.Item(0).Hidden = True


        '                Else ''reporte general 
        '                    Dim mergedRegion1 As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 0, 1, 6)
        '                    ' Set the value of the merged region
        '                    mergedRegion1.Value = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
        '                    worksheet.Rows.Item(1).Cells.Item(0).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center


        '                    worksheet.Columns.Item(0).Width = 1825  '#
        '                    worksheet.Columns.Item(1).Width = 8000  'FAMILIA 
        '                    worksheet.Columns.Item(2).Width = 1825  'ART 9125
        '                    worksheet.Columns.Item(3).Width = 2500  'FOTO
        '                    worksheet.Columns.Item(4).Width = 9125  'COLECCION
        '                    worksheet.Columns.Item(5).Width = 1900  'MODELO
        '                    worksheet.Columns.Item(6).Width = 5600  'PIEL_COLOR

        '                    For i As Int16 = 7 To bgvReporte.Columns.Count - 7
        '                        worksheet.Columns.Item(i).Width = 1700 ' tallas

        '                    Next

        '                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString() '#
        '                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString() 'FAMILIA
        '                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(2).FieldName.ToString() 'ART
        '                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(3).FieldName.ToString() 'FOTO
        '                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(4).FieldName.ToString() 'COLECCION
        '                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(5).FieldName.ToString() 'MODELO
        '                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(7).FieldName.ToString() 'PIEL_COLOR

        '                    ''FORMATO DE LAS COLUMNAS
        '                    For j As Int16 = 0 To 13 Step 1
        '                        worksheet.Rows(1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                        worksheet.Rows(1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                    Next
        '                    'MESES
        '                    Dim meses As Int16 = 0 ''variable para saber cuantas columnas 
        '                    Dim terminaColumnasFacturacion As Boolean = False
        '                    For i As Int16 = 6 To bgvReporte.Columns.Count - 1

        '                        If Not terminaColumnasFacturacion Then
        '                            meses = meses + 1
        '                            If bgvReporte.Columns(i).FieldName.ToString() = "TOTALF" Then
        '                                terminaColumnasFacturacion = True
        '                            End If
        '                        End If

        '                        worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
        '                    Next

        '                    'col por facturar
        '                    Dim porFacturarInicio As Int16 = 6 + meses + 1 ''variable para saber cuantas columnas 
        '                    Dim porFacturarFIN As Int16 = 0
        '                    Dim terminaColumnasPorFacturacion As Boolean = False
        '                    For i As Int16 = porFacturarInicio To bgvReporte.Columns.Count - 1

        '                        If Not terminaColumnasPorFacturacion Then
        '                            porFacturarFIN = porFacturarFIN + 1
        '                            If bgvReporte.Columns(i).FieldName.ToString() = "TOTALPF" Then
        '                                terminaColumnasPorFacturacion = True
        '                            End If
        '                        End If

        '                        'worksheet.Rows.Item(inicio).Cells.Item(i).Value = bgvReporte.Columns(i).FieldName.ToString()
        '                    Next

        '                    meses = meses - 1
        '                    Dim mergedRegionFacturado As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, 7, 1, 7 + meses)
        '                    ' Set the value of the merged region
        '                    mergedRegionFacturado.Value = "FACTURADO"

        '                    porFacturarFIN = porFacturarFIN - 1
        '                    Dim mergedRegionPorFacturar As Infragistics.Documents.Excel.WorksheetMergedCellsRegion = worksheet.MergedCellsRegions.Add(1, porFacturarInicio, 1, porFacturarInicio + porFacturarFIN)
        '                    ' Set the value of the merged region
        '                    mergedRegionPorFacturar.Value = "POR FACTURAR"

        '                    worksheet.Rows.Item(1).Cells.Item(porFacturarInicio + porFacturarFIN + 1).Value = "TOTAL"

        '                    For i As Int16 = 1 To inicio Step 1
        '                        For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1
        '                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.Gainsboro), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
        '                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)

        '                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
        '                        Next
        '                    Next
        '                    'FILAS DEL DATAGRID
        '                    For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
        '                        worksheet.Rows.Item(r + inicio + 1).Height = 900 '1145

        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString())   '#'
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())   'FAMILIA'
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(2).FieldName.ToString())   'ART                            
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())  'FOTO
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())   'COLECCION
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())   'MODELO
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'CLASIF
        '                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())   'PIEL_COLOR
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())   'CORRIDA
        '                        ' worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())   'ESTATUS
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())   'F_VIGENCIA
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALF").FieldName.ToString())   'TOTALF
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTALPF").FieldName.ToString()) 'TOTALPF
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("TOTAL").FieldName.ToString()) 'TOTAL  
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%SKU").FieldName.ToString()) '%SKU '%COL
        '                        'worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns("%COL").FieldName.ToString())


        '                        For i As Int16 = 7 To bgvReporte.Columns.Count - 1
        '                            If bgvReporte.Columns(i).FieldName.ToString = "%SKU" Or bgvReporte.Columns(i).FieldName.ToString = "%COL" Then
        '                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString())
        '                            Else
        '                                If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString)) Then
        '                                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = CInt(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(i).FieldName.ToString()))
        '                                    worksheet.Rows(r + inicio + 1).Cells(i).CellFormat.FormatString = "#,#"


        '                                    'worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.
        '                                End If
        '                            End If

        '                        Next


        '                        If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString())) Then
        '                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
        '                    New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(3).FieldName.ToString()))


        '                            Dim Ancho As Double = imageShape.Image.Width
        '                            Dim alto As Double = imageShape.Image.Height

        '                            If imageShape.Image.Width > imageShape.Image.Height Then
        '                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
        '                            Else
        '                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
        '                            End If

        '                            ' The top-left corner of the image should be at the 
        '                            ' top-left corner of cell A1
        '                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
        '                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

        '                            ' The bottom-right corner of the image should be at 
        '                            ' the bottom-right corner of cell A1
        '                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(3)
        '                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

        '                            imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

        '                            worksheet.Shapes.Add(imageShape)
        '                        End If
        '                        Cont += 1
        '                        pBar.Value = Cont
        '                        lblInfo.Text = "Exportando datos..." & Cont.ToString()
        '                        System.Windows.Forms.Application.DoEvents()

        '                    Next

        '                    lblInfo.Text = "Espere por favor..."
        '                    System.Windows.Forms.Application.DoEvents()

        '                    For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
        '                        For j As Int16 = 0 To bgvReporte.Columns.Count - 1 Step 1 '13

        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.VerticalAlignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Gray)
        '                        Next

        '                        'lblInfo.Text = "Exportando datos..." & i.ToString()
        '                        'System.Windows.Forms.Application.DoEvents()
        '                    Next

        '                    'For r As Integer = (0) To bgvReporte.RowCount - 1
        '                    '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
        '                    'Next

        '                    'worksheet.Columns.Item(0).Hidden = True


        '                End If
        '            End If
        '            System.Windows.Forms.Application.DoEvents()


        '            workbook.Save(fileName)

        '            Dim objMensajeExito As New ExitoForm
        '            objMensajeExito.StartPosition = FormStartPosition.CenterScreen
        '            objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
        '            objMensajeExito.ShowDialog()
        '            Process.Start(fileName)

        '        Catch ex As Exception
        '            Dim objMensajeError As New ErroresForm
        '            objMensajeError.StartPosition = FormStartPosition.CenterScreen
        '            objMensajeError.mensaje = ex.Message
        '            objMensajeError.ShowDialog()
        '        Finally
        '            pBar.Value = pBar.Minimum
        '            pnPBar.Visible = False
        '            Me.Cursor = Cursors.Default
        '        End Try
        '    End If

        'Else
        '    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        'End If

#Region "Otra forma de exportar a Excel"
        'If bgvReporte.DataRowCount > 0 Then

        '    Dim fbdUbicacionArchivo As New FolderBrowserDialog
        '    Dim nombreReporte As String = String.Empty
        '    Dim nombreReporteParaExportacion As String = String.Empty
        '    Dim objBU As New Negocios.EstadisticoPedidosBU
        '    Dim exportOptions = New XlsxExportOptionsEx()


        '    exportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG


        '    Try
        '        Dim Reporte As Int16 = cmbReporte.SelectedValue

        '        Select Case Reporte
        '            Case 1
        '                nombreReporte = "\General_Concentrado_Total"
        '                nombreReporteParaExportacion = "GENEREAL CONCENTRADO TOTAL"
        '                exportOptions.SheetName = "GeneralConcentradoTotal"
        '            Case Else
        '                nombreReporte = "\Reporte_"
        '                nombreReporteParaExportacion = "Reporte"
        '                exportOptions.SheetName = "Reporte"
        '        End Select


        '        With fbdUbicacionArchivo

        '            .Reset()
        '            .Description = " Seleccione una carpeta "
        '            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        '            .ShowNewFolderButton = True

        '            Dim ret As DialogResult = .ShowDialog
        '            Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

        '            If ret = Windows.Forms.DialogResult.OK Then

        '                If bgvReporte.GroupCount > 0 Then
        '                    bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
        '                Else
        '                    ExportSettings.DefaultExportType = ExportType.WYSIWYG
        '                    grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
        '                    'grdReporte.ExportToXlsx()

        '                End If

        '                show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

        '                .Dispose()

        '                objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

        '                Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
        '            End If



        '        End With
        '    Catch ex As Exception
        '        show_message("Error", ex.Message.ToString())
        '    End Try
        'Else
        '    show_message("Aviso", "No hay datos para exportar.")
        'End If
#End Region
    End Sub

    'Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
    '    Dim PorcentajeCliente As String = ""
    '    Dim FilaAnterior As Integer = 0
    '    Dim PorcentajeCoberturaCliente As Integer = 0
    '    Dim PorcentajeCoberturaActual As Integer = 0


    '    Try
    '        If e.RowHandle < 3 Then
    '            If DTEncabezadoCobertura.AsEnumerable().Where(Function(x) x.Item("ColumnaOrigen") = e.Value.ToString).Count > 0 Then
    '                Dim NombreColumna = DTEncabezadoCobertura.AsEnumerable().FirstOrDefault(Function(x) x.Item("ColumnaOrigen") = e.Value)
    '                e.Value = NombreColumna.Item("NombreColumna")
    '            End If
    '        End If

    '        If IsDBNull(e.Value) = False Then
    '            If IsNumeric(e.Value) = False Then
    '                If e.Value = "COLECCIONES NUEVAS" Then
    '                    e.Formatting.BackColor = Color.FromArgb(198, 224, 180)
    '                ElseIf e.Value = "COLECCIONES VIGENTES" Then
    '                    e.Formatting.BackColor = Color.FromArgb(255, 242, 204)
    '                End If
    '            End If


    '        End If



    '        If bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE") = "TOTAL GENERAL" Then
    '            e.Formatting.BackColor = Color.FromArgb(221, 235, 247)
    '            e.Formatting.Font.Bold = True
    '        Else
    '            'Poner Ceros a los espacios vacíos
    '            If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = True Then
    '                If e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "CIUDAD" AndAlso e.ColumnFieldName <> "EDO" AndAlso e.ColumnFieldName <> "CLASIF" AndAlso e.ColumnFieldName <> "TDAS" Then

    '                    PorcentajeCliente = bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE")

    '                    If PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = True OrElse PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True OrElse PorcentajeCliente.Contains("CLASIFICACIÓN DE LA COLECCIÓN") = True OrElse PorcentajeCliente.Contains("CLIENTES EN COBERTURA") = True Then
    '                        If e.ColumnFieldName.Contains("TOTAL") = False And e.ColumnFieldName.Contains("PORC") = False And e.ColumnFieldName.Contains("CTE") = False Then
    '                            e.Value = 0
    '                        End If
    '                        'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '                    Else
    '                        e.Formatting.BackColor = Color.Pink
    '                        e.Formatting.Font.Color = Color.Red

    '                        If e.ColumnFieldName.Contains("CTE") = True Then
    '                            e.Value = "0.00%"
    '                        Else
    '                            e.Value = "0"
    '                        End If

    '                        'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
    '                    End If
    '                End If
    '            Else
    '                If e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "CIUDAD" AndAlso e.ColumnFieldName <> "EDO" AndAlso e.ColumnFieldName <> "CLASIF" AndAlso e.ColumnFieldName <> "TDAS" Then
    '                    If IsNumeric(e.Value) = True Then
    '                        PorcentajeCliente = bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE")

    '                        If PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = False AndAlso PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = False AndAlso PorcentajeCliente.Contains("CLASIFICACIÓN DE LA COLECCIÓN") = False Then
    '                            If e.Value = 0 Then
    '                                e.Formatting.BackColor = Color.Pink
    '                                e.Formatting.Font.Color = Color.Red
    '                            End If
    '                        End If

    '                    End If

    '                End If
    '            End If

    '        End If


    '        If e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName.Contains("CTE") = False Then

    '            If IsNumeric(e.Value) = True Then

    '                e.Value = CDbl(e.Value).ToString("N0")
    '            End If

    '            PorcentajeCliente = bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE")

    '            If (PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = True Or PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True) And IsDBNull(e.Value) = False Then
    '                If e.Value.ToString.Contains("%") = False Then
    '                    e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
    '                End If

    '            End If

    '            If e.ColumnFieldName.Contains("PORC") = True AndAlso IsDBNull(e.Value) = False Then
    '                If e.Value.ToString.Contains("%") = False Then
    '                    e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
    '                End If

    '            End If

    '            If PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True AndAlso e.ColumnFieldName.Contains("TOTAL") = False AndAlso e.ColumnFieldName.Contains("PORC") = False Then
    '                FilaAnterior = e.RowHandle - 1

    '                If IsDBNull(e.Value) = True Then
    '                    PorcentajeCoberturaActual = 0
    '                Else
    '                    If e.Value.ToString.Contains("%") = True Then
    '                        PorcentajeCoberturaActual = e.Value.ToString.Replace("%", "").Trim
    '                    Else
    '                        PorcentajeCoberturaActual = e.Value
    '                    End If

    '                End If

    '                If IsDBNull(bgvReporte.GetRowCellValue(FilaAnterior, e.ColumnFieldName)) = True Then
    '                    PorcentajeCoberturaCliente = 0
    '                Else
    '                    PorcentajeCoberturaCliente = bgvReporte.GetRowCellValue(FilaAnterior, e.ColumnFieldName)
    '                End If

    '                If PorcentajeCoberturaActual >= PorcentajeCoberturaCliente Then
    '                    e.Formatting.BackColor = Color.LightGreen
    '                    e.Formatting.Font.Color = Color.Green
    '                Else

    '                    e.Formatting.BackColor = Color.Pink
    '                    e.Formatting.Font.Color = Color.Red
    '                End If
    '            End If

    '        End If

    '        'Formato porcentaje con decimales columna CTE
    '        If e.ColumnFieldName.Contains("CTE") = True AndAlso IsDBNull(e.Value) = False Then
    '            If e.Value.ToString.Contains("%") = False Then
    '                e.Value = e.Value & "%"
    '            End If

    '            'e.Formatting.Alignment.HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Right
    '        End If

    '    Catch ex As Exception
    '        show_message("Error", ex.Message.ToString())
    '    End Try

    '    e.Handled = True
    'End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim accion As Integer = 0
        Dim objBU As New Negocios.EstadisticasVentasBU

        lblFechaUltimaActualización.Text = Date.Now.ToString

        Try

            If CDate(dtpFechaEntregaDel.Value.ToShortDateString) > CDate(dtpFechaEntregaAl.Value.ToShortDateString) Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                dtpFechaEntregaDel.Focus()
                Exit Sub
            End If

            Dim reporteConventa As Int16 = 0 ''mostrara solo los productos con ventas si no mostrara los productos con y sin ventas( los productosq que no teienen venta solo en estatus autorizados para produccion y autorizados para venta)
            If rdoConVenta.Checked Then
                reporteConventa = 1
            Else
                reporteConventa = 0
            End If



            grdReporte.DataSource = Nothing
            bgvReporte.Bands.Clear()
            bgvReporte.Columns.Clear()

            Cursor = Cursors.WaitCursor
            If Not obtenerFiltros() Then Exit Sub
            pnPBar.Visible = True
            accion = cmbReporte.SelectedValue
            lblInfo.Text = "Ejecutando consulta, espere un momento por favor..."
            pBar.Minimum = 0
            pBar.ForeColor = Color.Gray
            System.Windows.Forms.Application.DoEvents()
            dtReporte = objBU.reporteGeneralConcentradoTotal(accion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid,
                                                            filtro_FechaInicio,
                                                            filtro_FechaFin,
                                                            filtro_Cliente,
                                                            filtro_Agente,
                                                            filtro_Marca,
                                                            filtro_Familia,
                                                            filtro_Coleccion,
                                                            filtro_EstatusArticulos,
                                                            reporteConventa
                                                           )

            If Not IsNothing(dtReporte) Then
                For Each row As DataRow In dtReporte.Rows
                    If row.Item(11).ToString.Length > 0 Then
                        If row.Item(11) = 1 Then
                            row.Item(11) = 0

                        End If
                    End If
                Next
            End If



            If Not IsNothing(dtReporte) Then
                If dtReporte.Rows.Count > 0 Then
                    dtReporte.Columns.Add("FOTO", GetType(Image))
                    Dim Total As Integer = dtReporte.Rows.Count
                    Dim Cont As Integer = 0

                    pBar.Maximum = Total

                    lblInfo.Text = "Descargando imagenes...."
                    System.Windows.Forms.Application.DoEvents()
                    Dim imagen As Image
                    For Each row As DataRow In dtReporte.Rows
                        ruta = IIf(IsDBNull(row.Item("FOTOMODELO")), "", row.Item("FOTOMODELO").ToString.Trim())
                        If ruta.Length > 0 Then
                            Try
                                image = Nothing
                                'StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                                StreamFoto = objFTP.StreamFile(Carpeta, ruta)
                                imagen = Bitmap.FromStream(StreamFoto)
                                'imagen = System.Drawing.Image.FromStream(StreamFoto)
                                'row.Item("FOTO") = image
                                If imagen.Width > 2000 Then
                                    image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.2, imagen.Height * 0.2))
                                    row.Item("FOTO") = image
                                Else
                                    image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.4, imagen.Height * 0.4))
                                    row.Item("FOTO") = image
                                End If


                            Catch ex As Exception
                                Try
                                    image = Nothing
                                    'StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                                    StreamFoto = objFTP.StreamFile(Carpeta, ruta)
                                    imagen = Bitmap.FromStream(StreamFoto)

                                    'imagen = System.Drawing.Image.FromStream(StreamFoto)
                                    'row.Item("FOTO") = image

                                    If imagen.Width > 2000 Then
                                        image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.2, imagen.Height * 0.2))
                                        row.Item("FOTO") = image
                                    Else
                                        image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.4, imagen.Height * 0.4))
                                        row.Item("FOTO") = image
                                    End If
                                Catch exe As Exception

                                End Try
                            End Try
                        Else
                            row.Item("FOTO") = Nothing
                            'request = WebRequest.Create("http://www.grupoyuyin.com/yuyinerp/say/programacion/modelos/12031/THUMBNAIL_ANDREA BOSKI MOCASIN 4382 FLOR ENTERA negro.JPG")
                            'response = request.GetResponse()
                            'StreamFoto = response.GetResponseStream()
                            'image = Nothing
                            ''image = Image.FromStream(StreamFoto)
                            'image = Bitmap.FromStream(StreamFoto)
                            'row.Item("FOTO") = image
                        End If
                        Cont += 1
                        pBar.Value = Cont
                    Next
                    System.Windows.Forms.Application.DoEvents()
                    diseñoGridResultado()
                    grdReporte.DataSource = dtReporte
                    btnArriba_Click(Nothing, Nothing)
                    System.Windows.Forms.Application.DoEvents()

                Else
                    Tools.Controles.Mensajes_Y_Alertas("INFORMACION", "No se encontraron datos con los filtros seleccionados.")
                End If
            Else

                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron datos con los filtros seleccionados.")
            End If
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            pBar.Value = pBar.Minimum
            pnPBar.Visible = False
            Cursor = Cursors.Default
            request = Nothing
            StreamFoto = Nothing
            image = Nothing

        End Try
    End Sub

    Private Function obtenerFiltros() As Boolean

        Dim valida As Boolean = True

        filtro_Agente = ""
        filtro_Marca = ""
        filtro_Cliente = ""
        filtro_Coleccion = ""
        filtro_Familia = ""
        filtro_EstatusArticulos = ""

        filtro_FechaInicio = dtpFechaEntregaDel.Value.ToShortDateString()
        filtro_FechaFin = dtpFechaEntregaAl.Value.ToShortDateString()


        For Each Row As UltraGridRow In grdFamiliaDeVentas.Rows
            If filtro_Familia <> "" Then
                filtro_Familia += ","
            End If
            filtro_Familia += Row.Cells(1).Value.ToString()
        Next


        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_Agente <> "" Then
                filtro_Agente += ","
            End If
            filtro_Agente += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdMarcas.Rows
            If filtro_Marca <> "" Then
                filtro_Marca += ","
            End If
            filtro_Marca += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdClientes.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next

        For Each Row As UltraGridRow In grdColecciones.Rows
            If filtro_Coleccion <> "" Then
                filtro_Coleccion += ","
            End If
            filtro_Coleccion += Row.Cells("Parametro").Value.ToString()
        Next

        If filtro_Agente.Trim = "" And
            filtro_Marca.Trim = "" And
            filtro_Cliente.Trim = "" And
            filtro_Coleccion.Trim = "" And
            filtro_Familia.Trim = "" Then
            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario al menos uno de los filtros de selección.")
            Return False
        End If

        For Each Row As UltraGridRow In grdEstatusArticulos.Rows
            If filtro_EstatusArticulos <> "" Then
                filtro_EstatusArticulos += ","
            End If
            filtro_EstatusArticulos += Row.Cells("Parametro").Value.ToString()
        Next

        Return valida

    End Function

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub



    Private Function ObtenerColorCelda(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Pink
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.LightGreen
        ElseIf Valor > 120 Then
            TipoColor = Color.Thistle
        End If

        Return TipoColor

    End Function


    Private Function ObtenerColorLetra(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Red
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.Green
        ElseIf Valor > 120 Then
            TipoColor = Color.Purple
        End If

        Return TipoColor

    End Function

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_SayWeb_EstadisticaVentasGeneral.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_SayWeb_EstadisticaVentasGeneral.pdf")
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnFamilias_Click(sender As Object, e As EventArgs) Handles btnFamilias.Click
        Dim listado As New Programacion.Vista.ListadoParametroForm
        listado.tipo_busueda_str = "FAMILIAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamiliaDeVentas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamiliaDeVentas.DataSource = listado.listParametros
        With grdFamiliaDeVentas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familias"
        End With
    End Sub

    Private Sub btnLimpiaFamilias_Click(sender As Object, e As EventArgs) Handles btnLimpiaFamilias.Click
        grdFamiliaDeVentas.DataSource = listInicial
    End Sub

    Private Sub grdFamiliaDeVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamiliaDeVentas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    Private Sub diseñoGridResultado()
        Dim objBu As New Negocios.SeguimientoVentasBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listBandsMarcas As New List(Of String)
        Dim dtEncabezados As New DataTable
        '  dtEncabezados = objBu.SeguimientoVentasObtenerEncabezadosTabla(spid)



        bgvReporte.OptionsView.AllowCellMerge = False
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre
        Dim ListaPrimerBanda As New List(Of String)
        ListaPrimerBanda.Add("FechaActualizacion")
        ListaPrimerBanda.Add("FACTURADO")
        ListaPrimerBanda.Add("POR FACTURAR")
        ListaPrimerBanda.Add("TOTAL")
        ListaPrimerBanda.Add("Vacio")


        Dim cadenas As String = ""

        For Each item As String In ListaPrimerBanda

            listBandsTextos.Add(item.Trim())
            band = bgvReporte.Bands.Add
            band.AppearanceHeader.Options.UseBackColor = True
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If item = "FechaActualizacion" Then
                band.Caption = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString

            ElseIf item = "FACTURADO" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(220, 230, 241)
                band.Caption = "FACTURADO"
            ElseIf item = "POR FACTURAR" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(255, 185, 170)
                band.Caption = "POR FACTURAR"
            ElseIf item = "TOTAL" Then
                band.Caption = "TOTAL"
            ElseIf item = "Vacio" Then
                band.Caption = ""
            End If


            listBands.Add(band)

        Next
        Try
            'vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").DisplayFormat.FormatString = "N0"
            Dim Contador As Int16 = 0
            Dim Facturado As Int16 = dtReporte.Columns.IndexOf("TOTALF")
            Dim PorFacturar As Int16 = dtReporte.Columns.IndexOf("TOTALPF")
            Dim Total As Int16 = dtReporte.Columns.IndexOf("TOTAL")
            Dim Foto As Int16 = dtReporte.Columns.IndexOf("FOTO")
            Dim value As Object = cmbReporte.SelectedValue
            For Each Columna As DataColumn In dtReporte.Columns
                If (TypeOf value Is Integer) Then
                    Select Case value
                        Case 1
                            If Contador <= 6 Then
                                If Contador = 3 Then
                                    bgvReporte.Columns.AddField(("FOTO").ToString().ToUpper)
                                    bgvReporte.Columns.ColumnByFieldName(("FOTO").ToString().ToUpper).OwnerBand = listBands(0)
                                    bgvReporte.Columns.ColumnByFieldName(("FOTO").ToString().ToUpper).Visible = True
                                    bgvReporte.Columns.ColumnByFieldName("FOTO").Caption = "FOTO"
                                Else
                                    bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                    bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(0)
                                    bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                    bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                End If


                            ElseIf Contador > 6 And Contador <= Facturado Then

                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(1)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            ElseIf Contador > Facturado And Contador <= PorFacturar Then
                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(2)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            ElseIf Contador = Total Then
                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(3)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            ElseIf Contador > Total And Contador <> Foto Then
                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(4)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                'bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                'bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            End If
                            Contador += 1
                        Case 2
                        Case 3
                            If Contador <= 10 Then
                                If Contador = 3 Then
                                    bgvReporte.Columns.AddField(("FOTO").ToString().ToUpper)
                                    bgvReporte.Columns.ColumnByFieldName(("FOTO").ToString().ToUpper).OwnerBand = listBands(0)
                                    bgvReporte.Columns.ColumnByFieldName(("FOTO").ToString().ToUpper).Visible = True
                                    bgvReporte.Columns.ColumnByFieldName("FOTO").Caption = "FOTO"
                                Else
                                    bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                    bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(0)
                                    bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                    bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                End If


                            ElseIf Contador > 10 And Contador <= Facturado Then

                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(1)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            ElseIf Contador > Facturado And Contador <= PorFacturar Then
                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(2)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            ElseIf Contador = Total Then
                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(3)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            ElseIf Contador > Total And Contador <> Foto Then
                                bgvReporte.Columns.AddField((Columna.ColumnName).ToString().ToUpper)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).OwnerBand = listBands(4)
                                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString().ToUpper).Visible = True
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                                'bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                'bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).DisplayFormat.FormatString = "N0"
                                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Width = 50
                            End If
                            Contador += 1
                        Case 4

                    End Select
                End If
            Next

            'bgvReporte.Columns.AddField(("#").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("#").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("#").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("#")).Caption = ("#")

            'bgvReporte.Columns.AddField(("FAMILIA").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("FAMILIA").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("FAMILIA").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("FAMILIA")).Caption = ("FAMILIA")

            'bgvReporte.Columns.AddField(("ART").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("ART").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("ART").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("ART")).Caption = ("ART")

            'bgvReporte.Columns.AddField(("FOTOMODELO").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("FOTOMODELO").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("FOTOMODELO").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("FOTOMODELO")).Caption = ("FOTOMODELO")

            'bgvReporte.Columns.AddField(("COLECCIÓN").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("COLECCIÓN").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("COLECCIÓN").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("COLECCIÓN")).Caption = ("COLECCIÓN")


            'bgvReporte.Columns.AddField(("MODELO").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("MODELO").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("MODELO").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("MODELO")).Caption = ("MODELO")


            'bgvReporte.Columns.AddField(("PIEL_COLOR").ToString().ToUpper)
            'bgvReporte.Columns.ColumnByFieldName(("PIEL_COLOR").ToString().ToUpper).OwnerBand = listBands(0)
            'bgvReporte.Columns.ColumnByFieldName(("PIEL_COLOR").ToString().ToUpper).Visible = True
            'bgvReporte.Columns.ColumnByFieldName(("PIEL_COLOR")).Caption = ("PIEL_COLOR")

            'Contador += 1

            'For Each row As DataRow In dtReporte.Columns





            '    'ListaColumnasGrid.Add(row.Item("ColumnaOrigen").ToString())
            '    'BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("Marca") And x.ParentBand.Caption = row.Item("Cuatrimestre"))

            '    'bgvReporte.Columns.AddField(row.Item("ColumnaOrigen").ToString().ToUpper)
            '    'bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OwnerBand = BandaAux
            '    'bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).Visible = True
            '    'bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen")).Caption = row.Item("NombreColumna")

            '    'If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
            '    '    bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            '    'End If
            '    'If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "INDICADOR" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
            '    '    bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            '    '    bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"
            '    'End If

            'Next

            'For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            '    If gridBand.Caption = "" Then
            '        gridBand.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
            '    End If
            '    If gridBand.Caption = "-" Then
            '        gridBand.Caption = ""
            '    End If
            '    'If gridBand.Caption.ToUpper.Contains("TOTAL") Then
            '    '    gridBand.Caption = ""
            '    'End If
            'Next

            'For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporte.Bands
            '    gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            '    gridband.AppearanceHeader.Options.UseBackColor = True
            '    If gridband.Caption = "CUATRIMESTRE 1" Then
            '        gridband.AppearanceHeader.BackColor = Color.FromArgb(216, 228, 188)
            '    ElseIf gridband.Caption = "CUATRIMESTRE 2" Then
            '        gridband.AppearanceHeader.BackColor = Color.FromArgb(255, 255, 204)
            '    ElseIf gridband.Caption = "CUATRIMESTRE 3" Then
            '        gridband.AppearanceHeader.BackColor = Color.FromArgb(220, 230, 241)
            '    End If


            'Next

            bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            bgvReporte.ColumnPanelRowHeight = 20

            bgvReporte.RowHeight = 50

            'For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.band
            '    'Col.Width = bgvReporte.Columns.ColumnByFieldName(Col.FieldName).GetBestWidth
            '    Col.BestFit()
            '    Col.Width = Col.GetBestWidth
            'Next
            Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(bgvReporte)

            For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns

                If Col.FieldName = "#" Then
                    Col.Width = 30
                End If

                If Col.FieldName = "FAMILIA" Then
                    Col.Width = 100
                End If

                If Col.FieldName = "ART" Then
                    Col.Width = 30
                End If

                If Col.FieldName = "COLECCIÓN" Then
                    Col.Width = 180
                End If

                If Col.FieldName = "MODELO" Then
                    Col.Width = 50
                End If

                If Col.FieldName = "CLASIF" Then
                    Col.Width = 50
                End If


                If Col.FieldName = "PIEL_COLOR" Then
                    Col.Width = 140
                End If


                If Col.FieldName = "CLIENTE" Then
                    Col.Width = 180
                End If

                If Col.FieldName = "ESTATUS" Then
                    Col.Width = 180
                End If


                If Col.FieldName = "F_VIGENCIA" Then
                    Col.Width = 80
                End If


                '    If Col.FieldName = "INDICADOR" Then
                '        If tipoReporte <> 4 And tipoReporte <> 6 Then
                '            Col.Width = 175
                '        Else
                '            Col.Width = 185
                '        End If
                '    End If
                '    If Col.FieldName = "MARCA" Then
                '        If tipoReporte <> 4 And tipoReporte <> 6 Then
                '            Col.Width = 100
                '        Else
                '            Col.Width = 90
                '        End If
                '    End If
                '    If Col.FieldName = "TOTAL" Then
                '        Col.Width = 100
                '    End If
                '    If Col.FieldName = "AGENTE" Then
                '        If tipoReporte <> 4 And tipoReporte <> 6 Then
                '            Col.Width = 170
                '        Else
                '            Col.Width = 185
                '        End If
                '    End If
                '    If Col.FieldName = "CLIENTE" Then
                '        Col.Width = 180

                '    End If

                '    If Col.FieldName = "CIUDAD" Then
                '        Col.Width = 140
                '        'Col.BestFit()
                '    End If

                '    If Col.FieldName = "RUTA" Then
                '        Col.Width = 120
                '    End If

                '    If Col.FieldName = "TDAS" Then
                '        Col.Width = 45
                '    End If

                '    If Col.FieldName = "CLASIF" Then
                '        Col.Width = 45
                '    End If

                '    If Col.FieldName = "EDO" Then
                '        Col.Width = 45
                '    End If

            Next


            bgvReporte.OptionsView.RowAutoHeight = False



        Catch ex As Exception

        End Try
    End Sub

    Private Sub bgvReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReporte.CustomDrawCell

        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "#" Then
                e.Appearance.BackColor = Color.FromArgb(234, 232, 232)
            End If
        End If

        If e.Column.FieldName = "TOTALF" Then
            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)
        End If

        If e.Column.FieldName = "TOTALPF" Then
            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)
        End If

        If e.Column.FieldName = "TOTAL" Then
            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)
        End If

        If e.Column.FieldName = "%COL" Then
            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)
        End If





        If e.Column.FieldName = "FOTO" Then
            If e.RowHandle >= 0 Then
                'If bgvReporte.GetRowCellValue(e.RowHandle, "FOTOMODELO").ToString = "" Then
                '    Exit Sub
                'End If
                emptyEditor = New RepositoryItemPictureEdit()
                emptyEditor.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
                emptyEditor.NullText = ""
                emptyEditor.CustomHeight = 50
                e.Column.ColumnEdit = emptyEditor

            End If
        End If
    End Sub

    Private Sub bgvReporte_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvReporte.RowStyle
        Dim Valor As String = String.Empty

        If e.RowHandle > 0 Then
            Valor = bgvReporte.GetRowCellValue(e.RowHandle, "FAMILIA").ToString.Trim.ToUpper
            If Valor.Contains("TOTAL") Then
                'bgvReporte.SetRowCellValue(e.RowHandle, "ART", "")
                e.Appearance.BackColor = Color.FromArgb(234, 232, 232)
            End If

            If Valor.Contains("TOTAL GENERAL") Then
                'bgvReporte.SetRowCellValue(e.RowHandle, "ART", "")
                e.Appearance.BackColor = Color.Gray
            End If

        End If


    End Sub

    Private Sub bgvReporte_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles bgvReporte.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "FOTO" Then
                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = bgvReporte.GetRowCellValue(e.RowHandle, "FOTOMODELO")
                'MostrarFoto.Marca = bgvReporte.GetRowCellValue(e.RowHandle, "Marca")
                MostrarFoto.Coleccion = bgvReporte.GetRowCellValue(e.RowHandle, "COLECCIÓN")
                MostrarFoto.ModeloSicy = bgvReporte.GetRowCellValue(e.RowHandle, "MODELO")
                'MostrarFoto.ModleoSay = bgvReporte.GetRowCellValue(e.RowHandle, "ModeloSay")
                MostrarFoto.Talla = bgvReporte.GetRowCellValue(e.RowHandle, "CORRIDA")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim punto As Point
        punto.X = btnImprimir.Location.X + btnImprimir.Width
        punto.Y = btnImprimir.Location.Y + (btnImprimir.Height + 35)
        cmsReporte.Show(punto)
    End Sub

    Private Sub reporte(ByVal action As Integer, ByVal anio As Integer)
        Dim objBU As New Negocios.EstadisticasVentasBU
        Dim ruta As String

        Dim tabla1 As New DataTable
        'Cambios
        Try
            ruta = "C:\Users\SISTEMAS15\Desktop\librootro.xls"
            Me.Cursor = Cursors.WaitCursor
            If CDate(dtpFechaEntregaDel.Value.ToShortDateString) > CDate(dtpFechaEntregaAl.Value.ToShortDateString) Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                dtpFechaEntregaDel.Focus()
                Exit Sub
            End If

            If Not obtenerFiltros() Then Exit Sub

            filtro_FechaInicio = "01-01-" + anio.ToString
            filtro_FechaFin = "31-12-" + anio.ToString

            tabla1 = objBU.reporteGeneralConcentradoTotal_Vista(action, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid,
                                                                filtro_FechaInicio,
                                                                filtro_FechaFin,
                                                                filtro_Cliente,
                                                                filtro_Agente,
                                                                filtro_Marca,
                                                                filtro_Familia,
                                                                filtro_Coleccion)


            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            If action = 1 Then
                EntidadReporte = OBJReporte.LeerReporteporClave("ESTADISTICO_VENTAS_GENERAL")
            ElseIf action = 3 Then
                EntidadReporte = OBJReporte.LeerReporteporClave("ESTADISTICO_VENTAS_MENSUAL")
            End If

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()

            reporte("log") = GetRutaLogoPorNave(43)
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("anio") = anio.ToString
            reporte("fecha") = Date.Now.ToShortDateString.ToString

            reporte.RegData(tabla1)

            reporte.Render()
            'reporte.ExportDocument(StiExportFormat.Excel, "C:\Users\SISTEMAS15\Desktop\ESTADISTICO_VENTAS_MENSUAL"&Date.Now.ToShortTimeString &".xls")

            reporte.Show()
            LimpiarMemoria()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GetRutaLogoPorNave(ByVal idNave As Integer) As String
        Return Tools.Controles.ObtenerLogoNave(idNave)
    End Function

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            reporte(1, 2019)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            reporte(1, 2020)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            reporte(1, 2021)
        Catch ex As Exception

        End Try
    End Sub

    Private Declare Auto Function SetProcessWorkingSetSize Lib “kernel32.dll” (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Public Sub LimpiarMemoria()
        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch ex As Exception
            'Control de errores
        End Try
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Try
            reporte(3, 2019)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        Try
            reporte(3, 2020)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Try
            reporte(3, 2021)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEstatusArticulos_Click(sender As Object, e As EventArgs) Handles btnEstatusArticulos.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 11

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEstatusArticulos.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdEstatusArticulos.DataSource = listado.listParametros
        With grdEstatusArticulos()
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus Articulos"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub grdEstatusArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEstatusArticulos.InitializeLayout
        grid_diseño(grdEstatusArticulos)
        grdEstatusArticulos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus Artículos"
    End Sub

    Private Sub btnLimpiarEstatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarEstatus.Click
        grdEstatusArticulos.DataSource = listInicial
    End Sub

    Private Sub grdEstatusArticulos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdEstatusArticulos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    Private Sub cmbReporte_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbReporte.SelectedValueChanged
        If cmbReporte.Items.Count > 0 Then
            If cmbReporte.SelectedIndex = "1" Then
                pnlFiltroEstaus.Visible = True
                pnlTipoReporte.Visible = True
            Else
                pnlFiltroEstaus.Visible = False
                pnlTipoReporte.Visible = False
            End If
        End If


    End Sub

End Class