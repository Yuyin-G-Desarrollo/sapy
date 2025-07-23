Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports System.Net
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools.WindowsApplication1

Public Class ResumenVentasSemanalForm

    Dim listInicial As New List(Of String)
    Dim filtro_Agente As String = String.Empty
    Dim filtro_Marca As String = String.Empty
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_Coleccion As String = String.Empty
    Dim filtro_Familia As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim filtro_AñoComparacion1 As Integer
    Dim filtro_AñoComparacion2 As Integer
    Dim tipoReporte As Integer = 0
    Dim perfilUsuario As Integer = 0
    Dim ListaColumnasGrid As New List(Of String)
    Dim objBU As New Negocios.CoberturaColeccionesBU
    Dim DTEncabezadoCobertura As DataTable
    Dim inicial As Integer = 0
    Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU
    Dim _Helper As MyCellMergeHelper
    Dim perfilId As Integer = 0
    Dim IdealSemanal As DataRow()

    Private Sub ResumenSemanaVentasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtResultadoPerfil As New DataTable

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        'dtpFechaDel.MinDate = Date.Parse("01/01/2013")
        'dtpFechaAl.MinDate = Date.Parse("01/01/2013")
        'dtpFechaDel.Value = Date.Parse("02/01/" + Date.Now.Year.ToString)
        ''dtpFechaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        'dtpFechaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()

        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU
        dtpFechaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()

        grdAgentes.DataSource = listInicial
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        grdFamiliaDeVentas.DataSource = listInicial

        dtResultadoPerfil = objResumenVentasBU.consultaPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilUsuario = dtResultadoPerfil.Rows(0).Item("perfilid")
            If dtResultadoPerfil.Rows(0).Item("perfilid") = 44 Then
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
        Renglon("Descripcion") = "Por Clasificación"
        dtReportes.Rows.Add(Renglon)

        Renglon = dtReportes.NewRow()
        Renglon("id") = 2
        Renglon("Descripcion") = "Por Clasificación Cliente"
        dtReportes.Rows.Add(Renglon)

        Renglon = dtReportes.NewRow()
        Renglon("id") = 3
        Renglon("Descripcion") = "Por Agente"
        dtReportes.Rows.Add(Renglon)

        Renglon = dtReportes.NewRow()
        Renglon("id") = 4
        Renglon("Descripcion") = "Frecuencia de Pedidos Por Agente X Semana"
        dtReportes.Rows.Add(Renglon)

        Renglon = dtReportes.NewRow()
        Renglon("id") = 5
        Renglon("Descripcion") = "Frecuencia de Pedidos Por Agente X Semana - Grupo Marcas"
        dtReportes.Rows.Add(Renglon)

        cmbReporte.DataSource = dtReportes
        cmbReporte.DisplayMember = "Descripcion"
        cmbReporte.ValueMember = "id"

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        If dtpFechaAl.MinDate > "31/12/" + dtpFechaDel.Value.Year.ToString Then
            dtpFechaAl.MinDate = dtpFechaDel.Value
            dtpFechaAl.MaxDate = "31/12/" + dtpFechaDel.Value.Year.ToString
        Else
            dtpFechaAl.MaxDate = "31/12/" + dtpFechaDel.Value.Year.ToString
            dtpFechaAl.MinDate = dtpFechaDel.Value
        End If
        lblAñoComparacion1.Text = (dtpFechaDel.Value.Year - 1).ToString
        lblAñoComparacion2.Text = (dtpFechaDel.Value.Year - 2).ToString
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Try
            ExportarAExcel(grdVReporte, "RepGeneralVentasSemanal" + cmbReporte.Text)
        Catch ex As Exception
            show_message("Error", "Ocurrió un error al exportar la información. " + ex.Message)
        End Try
    End Sub

    Private Sub btnExportarPDF_Click(sender As Object, e As EventArgs) Handles btnExportarPDF.Click
        Try
            ExportarAPDF(grdVReporte, "RepGeneralVentasSemanal" + cmbReporte.Text)
        Catch ex As Exception
            show_message("Error", "Ocurrió un error al exportar la información. " + ex.Message)
        End Try
    End Sub
    Public Sub ExportarAExcel(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = False
                Grid.OptionsPrint.UsePrintStyles = False
                'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                'Grid.OptionsPrint.EnableAppearanceOddRow = True
                'Grid.OptionsPrint.PrintHorzLines = False
                'Grid.OptionsPrint.PrintVertLines = False

                'Grid.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                'exportOptions.AllowConditionalFormatting = True
                'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                Grid.ExportToXlsx(FileName)

                show_message("Exito", "Los datos se exportaron correctamente.")
                objResumenVentasBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", "RepGeneralVentasSemanal " + cmbReporte.Text, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString)
                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            show_message("Exito", "No hay registros para exportar.")
        End If
    End Sub

    Public Sub ExportarAPDF(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "pdf files (*.pdf)|*.pdf"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".pdf"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = False
                Grid.OptionsPrint.UsePrintStyles = False
                'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                'Grid.OptionsPrint.EnableAppearanceOddRow = True
                'Grid.OptionsPrint.PrintHorzLines = False
                'Grid.OptionsPrint.PrintVertLines = False

                'Grid.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                'exportOptions.AllowConditionalFormatting = True
                'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                Grid.ExportToPdf(FileName)

                show_message("Exito", "Los datos se exportaron correctamente.")
                objResumenVentasBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", "RepGeneralVentasSemanal " + cmbReporte.Text, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString)
                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            show_message("Exito", "No hay registros para exportar.")
        End If
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

    Private Sub btnColecciones_Click(sender As Object, e As EventArgs)
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

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarColecciones_Click(sender As Object, e As EventArgs)
        grdColecciones.DataSource = listInicial
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub btnLimpiaFamilias_Click(sender As Object, e As EventArgs) Handles btnLimpiaFamilias.Click
        grdFamiliaDeVentas.DataSource = listInicial
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdAgentes.DataSource = listInicial
        grdReporte.DataSource = Nothing
        grdVReporte.Bands.Clear()
        grdVReporte.Columns.Clear()
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        grdFamiliaDeVentas.DataSource = listInicial
        dtpFechaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"
        btnAbajo_Click(sender, e)
    End Sub

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdColecciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs)
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFamiliaDeVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamiliaDeVentas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
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

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With


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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim dtReporte As DataTable
        Dim usuarioID As Integer

        lblFechaUltimaActualización.Text = Date.Now.ToString
        btnArriba_Click(Nothing, Nothing)

        If Not obtenerFiltros() Then Exit Sub

        grdReporte.DataSource = Nothing
        grdVReporte.Columns.Clear()
        grdVReporte.Bands.Clear()
        usuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        tipoReporte = cmbReporte.SelectedValue
        Me.Cursor = Cursors.WaitCursor
        Try

            dtReporte = objResumenVentasBU.ReporteGeneralVentasClasificacionCliente(tipoReporte, usuarioID, filtro_FechaInicio, filtro_FechaFin,
                                                            filtro_Cliente, filtro_Agente, filtro_Marca, filtro_Familia,
                                                            filtro_Coleccion, filtro_AñoComparacion1, filtro_AñoComparacion2)

            If dtReporte.Rows.Count > 0 Then
                Dim spid As Integer
                spid = dtReporte.Rows(0).Item(0)
                If tipoReporte = 1 Or tipoReporte = 2 Or tipoReporte = 3 Then
                    DiseñoGridBands(spid)
                Else
                    DiseñoGridSinBands(dtReporte, spid)
                    IdealSemanal = dtReporte.Select("PERIODO = 'IDEAL PED. SEMANAL'")
                End If
                grdReporte.DataSource = dtReporte
                grdVReporte.OptionsBehavior.ReadOnly = True
                'Dim RowCount = grdVReporte.RowCount - 1
                'grdVReporte.SetRowCellValue(RowCount, "CUA", "TOTAL")
                '_Helper = New MyCellMergeHelper(grdVReporte)
                '_Helper.AddMergedCell(i, grdVReporte.Columns.ColumnByFieldName("PERIODO").ColIndex, grdVReporte.Columns.ColumnByFieldName("PERIODO").ColIndex + 1, "CUMPLIMIENTO DE PROYECCIÓN" + Date.Now.Year.ToString)
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub DiseñoGridSinBands(ByVal dtReporte As DataTable, ByVal spid As Integer)
        'grdVReporte.OptionsView.ColumnAutoWidth = True
        'grdVReporte.BestFitColumns()

        If tipoReporte = 4 Then
            Dim Band As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            Band.Caption = Date.Now.ToString
            Band.Name = "Fecha"
            grdVReporte.Bands.Add(Band)
            grdVReporte.Bands.Item("Fecha").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            Band.Caption = "FRECUENCIA DE PEDIDO POR AGENTE X SEMANA"
            Band.Name = "Agentes"
            grdVReporte.Bands.Add(Band)
            grdVReporte.Bands.Item("Agentes").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            For Each col As DataColumn In dtReporte.Columns
                grdVReporte.Columns.AddField(col.Caption.ToUpper)
                grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).Name = col.Caption.ToUpper
                grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).Visible = True
                grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).OptionsColumn.AllowEdit = False
                If col.Ordinal <= 4 Then
                    grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).OwnerBand = grdVReporte.Bands("Fecha")
                ElseIf col.Ordinal > 4 Then
                    grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).OwnerBand = grdVReporte.Bands("Agentes")
                    grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdVReporte.Columns.ColumnByFieldName(col.Caption.ToUpper).DisplayFormat.FormatString = "N0"
                End If
            Next
            grdVReporte.Columns.ColumnByFieldName("SEMANA").Visible = False
            grdVReporte.Columns.ColumnByFieldName("ORDEN").Visible = False
            grdVReporte.Columns.ColumnByFieldName("CUATRIMESTRE").Visible = False
            grdVReporte.Columns.ColumnByFieldName("APLICAFORMATO").Visible = False
            grdVReporte.Columns.ColumnByFieldName("PERIODO").Caption = "AGENTE"
            grdVReporte.Columns.ColumnByFieldName("PERIODO").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            grdVReporte.Columns.ColumnByFieldName("PERIODO").Width = 200

        ElseIf tipoReporte = 5 Then
            Dim dtEncabezados As New DataTable
            dtEncabezados = objResumenVentasBU.ReporteGeneralVentas_Encabezados(spid)
            generarEncabezadosDosNiveles(dtEncabezados)
            grdVReporte.Bands.Item("SEMANA").Visible = False
            grdVReporte.Bands.Item("ORDEN").Visible = False
            grdVReporte.Bands.Item("CUATRIMESTRE").Visible = False
            grdVReporte.Bands.Item("APLICAFORMATO").Visible = False
            grdVReporte.Columns.ColumnByFieldName("PERIODO").Caption = "AGENTE"
            grdVReporte.Columns.ColumnByFieldName("PERIODO").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            grdVReporte.Columns.ColumnByFieldName("PERIODO").Width = 200
        End If

        grdVReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        grdVReporte.ColumnPanelRowHeight = 30

    End Sub

    Private Sub DiseñoGridBands(spid As Integer)
        Dim dtEncabezados As New DataTable

        dtEncabezados = objResumenVentasBU.ReporteGeneralVentas_Encabezados(spid)

        grdVReporte.OptionsView.AllowCellMerge = True
        grdVReporte.OptionsView.ColumnAutoWidth = False

        generarEncabezadosTresNiveles(dtEncabezados)

        grdVReporte.Bands.Item("").Children.Item("FRECUENCIA PEDIDOS").Caption = ""
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION1").Caption = lblAñoComparacion1.Text
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION2").Caption = lblAñoComparacion2.Text

        grdVReporte.Columns.ColumnByFieldName("ORDEN").Visible = False

        grdVReporte.Columns.ColumnByFieldName("CUA").Width = 45
        grdVReporte.Columns.ColumnByFieldName("SEM").Width = 45
        grdVReporte.Columns.ColumnByFieldName("PROYECCIÓN PRODUCCIÓN").Width = 80
        grdVReporte.Columns.ColumnByFieldName("PRODUCCIÓN REAL").Width = 80
        grdVReporte.Columns.ColumnByFieldName("% PROY VS PROD").Width = 60
        grdVReporte.Columns.ColumnByFieldName("PROY. VTA").Width = 50
        grdVReporte.Columns.ColumnByFieldName("VENTA (FACT)").Width = 50
        grdVReporte.Columns.ColumnByFieldName("% PROY VS VENTA").Width = 60
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION1").Width = 50
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION2").Width = 50
        grdVReporte.Columns.ColumnByFieldName("FRECUENCIA PEDIDOS").Width = 75

        grdVReporte.Columns.ColumnByFieldName("PROYECCIÓN PRODUCCIÓN").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("PROYECCIÓN PRODUCCIÓN").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("PRODUCCIÓN REAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("PRODUCCIÓN REAL").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("% PROY VS PROD").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("% PROY VS PROD").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("PROY. VTA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("PROY. VTA").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("VENTA (FACT)").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("VENTA (FACT)").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("% PROY VS VENTA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("% PROY VS VENTA").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION1").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION1").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION2").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("AÑO COMPARACION2").DisplayFormat.FormatString = "N0"
        grdVReporte.Columns.ColumnByFieldName("FRECUENCIA PEDIDOS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVReporte.Columns.ColumnByFieldName("FRECUENCIA PEDIDOS").DisplayFormat.FormatString = "N0"

        grdVReporte.Columns.ColumnByFieldName("CUA").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVReporte.Columns.ColumnByFieldName("SEM").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        grdVReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        grdVReporte.ColumnPanelRowHeight = 40

        grdVReporte.Bands("").Children.Item("CUMPLIMIENTO PROY. DE VENTA").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        grdVReporte.Bands("").Caption = Date.Now.ToString


    End Sub
    Private Sub generarEncabezadosTresNiveles(ByVal dtEncabezados As DataTable)

        Dim enumPadre = dtEncabezados.AsEnumerable.Select(Function(x) x.Item("spse_nivel1")).Distinct.ToList
        Dim enumHijo As List(Of Object)
        Dim enumColumnas As List(Of Object)
        Dim bandPadre As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim bandHijo As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        For Each FilaEncabezado As String In enumPadre
            bandPadre = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            bandPadre.Caption = FilaEncabezado
            bandPadre.Name = FilaEncabezado
            grdVReporte.Bands.Add(bandPadre)
            grdVReporte.Bands.Item(bandPadre.Name).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            enumHijo = dtEncabezados.AsEnumerable.Where(Function(x) x.Item("spse_nivel1") = FilaEncabezado).Select(Function(y) y.Item("spse_nivel2")).Distinct.ToList
            For Each FilaHijo As String In enumHijo
                bandHijo = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                bandHijo.Caption = FilaHijo
                bandHijo.Name = FilaHijo
                bandPadre.Children.Add(bandHijo)
                grdVReporte.Bands.Item(bandPadre.Name).Children(bandHijo.Name).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                enumColumnas = dtEncabezados.AsEnumerable.Where(Function(x) x.Item("spse_nivel2") = FilaHijo).Select(Function(y) y.Item("spse_nivel3")).Distinct.ToList
                For Each FilaColumnas As String In enumColumnas
                    If FilaColumnas.ToUpper = "PROY" Or FilaColumnas.ToUpper = "REAL" Then
                        grdVReporte.Columns.AddField(FilaHijo + " " + FilaColumnas)
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).Name = FilaHijo + " " + FilaColumnas
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).Caption = FilaColumnas
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).OwnerBand = bandHijo
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).Visible = True
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).Width = 50
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        grdVReporte.Columns.ColumnByFieldName(FilaHijo + " " + FilaColumnas).DisplayFormat.FormatString = "N0"
                    Else
                        grdVReporte.Columns.AddField(FilaColumnas)
                        grdVReporte.Columns.ColumnByFieldName(FilaColumnas).OwnerBand = bandHijo
                        grdVReporte.Columns.ColumnByFieldName(FilaColumnas).Visible = True
                        grdVReporte.Columns.ColumnByFieldName(FilaColumnas).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        grdVReporte.Columns.ColumnByFieldName(FilaColumnas).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        grdVReporte.Columns.ColumnByFieldName(FilaColumnas).DisplayFormat.FormatString = "N0"
                    End If

                Next
            Next
        Next

    End Sub
    Private Sub generarEncabezadosDosNiveles(ByVal dtEncabezados As DataTable)

        Dim enumPadre = dtEncabezados.AsEnumerable.Select(Function(x) x.Item("spse_nivel1")).Distinct.ToList
        Dim enumHijo As List(Of Object)
        Dim bandPadre As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        For Each FilaEncabezado As String In enumPadre
            bandPadre = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            bandPadre.Caption = FilaEncabezado
            bandPadre.Name = FilaEncabezado
            grdVReporte.Bands.Add(bandPadre)
            grdVReporte.Bands.Item(bandPadre.Name).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            enumHijo = dtEncabezados.AsEnumerable.Where(Function(x) x.Item("spse_nivel1") = FilaEncabezado).Select(Function(y) y.Item("spse_nivel2")).Distinct.ToList
            For Each FilaColumnas As String In enumHijo
                grdVReporte.Columns.AddField(FilaColumnas)
                grdVReporte.Columns.ColumnByFieldName(FilaColumnas).Name = FilaColumnas
                grdVReporte.Columns.ColumnByFieldName(FilaColumnas).Caption = FilaColumnas
                grdVReporte.Columns.ColumnByFieldName(FilaColumnas).OwnerBand = bandPadre
                grdVReporte.Columns.ColumnByFieldName(FilaColumnas).Visible = True
                grdVReporte.Columns.ColumnByFieldName(FilaColumnas).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                If grdVReporte.Bands(bandPadre.Name).Index > 0 Then
                    grdVReporte.Columns.ColumnByFieldName(FilaColumnas).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdVReporte.Columns.ColumnByFieldName(FilaColumnas).DisplayFormat.FormatString = "N0"
                End If

            Next
        Next

    End Sub

    Private Function obtenerFiltros() As Boolean

        Dim valida As Boolean = True

        filtro_Agente = ""
        filtro_Marca = ""
        filtro_Cliente = ""
        filtro_Coleccion = ""
        filtro_Familia = ""

        filtro_FechaInicio = dtpFechaDel.Value.ToShortDateString()
        filtro_FechaFin = dtpFechaAl.Value.ToShortDateString()
        filtro_AñoComparacion1 = CInt(lblAñoComparacion1.Text)
        filtro_AñoComparacion2 = CInt(lblAñoComparacion2.Text)

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

        Return valida

    End Function

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

    Private Sub grdVReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles grdVReporte.CustomDrawCell

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If tipoReporte = 1 Or tipoReporte = 2 Or tipoReporte = 3 Then
            If e.Column.FieldName.ToString.Contains("%") Then
                If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    e.DisplayText = (Integer.Parse(Trim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", ""))) / 100).ToString("p0")
                Else
                    currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                    e.DisplayText = 0
                End If
            End If

            If e.Column.Caption = "PROY" Or e.Column.Caption = "REAL" Then
                If currentView.GetRowCellValue(e.RowHandle, "ORDEN") = "3" Then
                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        e.DisplayText = (Integer.Parse(Trim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", ""))) / 100).ToString("p0")
                    Else
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                        e.DisplayText = 0
                    End If
                Else
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                        e.DisplayText = 0
                    End If
                End If
            End If
        End If
        If tipoReporte = 4 Or tipoReporte = 5 Then
            If currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption = "FRECUENCIA DE PEDIDO POR AGENTE X SEMANA" _
                    Or currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption.Contains("GRUPO") _
                    Or currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption = "" _
                    Or currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption = "CLIENTES A" Then
                If IsDBNull(e.CellValue) Then
                    currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                    e.DisplayText = 0
                End If
                If currentView.GetRowCellValue(e.RowHandle, "SEMANA") = 100 Then
                    e.DisplayText = ""
                End If
                If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "CUMP1" Or currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "CUMP2" Or currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "CUMP3" Then
                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        e.DisplayText = (Integer.Parse(Trim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", ""))) / 100).ToString("p0")
                    Else
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                        e.DisplayText = 0
                    End If
                End If
            End If
        End If

    End Sub


    Private Sub grdVReporte_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdVReporte.RowCellStyle
        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If tipoReporte = 1 Or tipoReporte = 2 Or tipoReporte = 3 Then
            If e.Column.FieldName.ToString.Contains("%") Then
                If Not currentView.GetRowCellValue(e.RowHandle, "SEM") = "TOTAL" Then

                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                        e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    Else
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                    End If
                End If
            End If

            If e.Column.Caption = "PROY" Or e.Column.Caption = "REAL" Then
                If currentView.GetRowCellValue(e.RowHandle, "ORDEN") = "3" Then
                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                        e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    Else
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                    End If
                Else
                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        If currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName) = 0 Then
                            e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                            e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                        End If
                    Else
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                    End If
                End If

            End If
            If e.Column.FieldName = "CUA" Then
                If e.CellValue = "1 C" Then
                    e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                End If
                If e.CellValue = "2 C" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
                End If
                If e.CellValue = "3 C" Then
                    e.Appearance.BackColor = Color.FromArgb(220, 230, 241)
                End If
                If e.CellValue = "" Then
                    e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                End If
            End If
        ElseIf tipoReporte = 4 Or tipoReporte = 5 Then
            If e.Column.FieldName = "PERIODO" Then
                If currentView.GetRowCellValue(e.RowHandle, "CUATRIMESTRE") = 1 And currentView.GetRowCellValue(e.RowHandle, "PERIODO") <> "IDEAL PED. SEMANAL" Then
                    e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
                End If
                If currentView.GetRowCellValue(e.RowHandle, "CUATRIMESTRE") = 2 And currentView.GetRowCellValue(e.RowHandle, "PERIODO") <> "IDEAL PED. SEMANAL" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
                End If
                If currentView.GetRowCellValue(e.RowHandle, "CUATRIMESTRE") = 3 And currentView.GetRowCellValue(e.RowHandle, "PERIODO") <> "IDEAL PED. SEMANAL" Then
                    e.Appearance.BackColor = Color.FromArgb(220, 230, 241)
                End If
            End If
            If currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption = "FRECUENCIA DE PEDIDO POR AGENTE X SEMANA" _
                    Or currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption.Contains("GRUPO") _
                    Or currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption = "" _
                    Or currentView.Columns.ColumnByFieldName(e.Column.FieldName).OwnerBand.Caption = "CLIENTES A" Then
                If currentView.GetRowCellValue(e.RowHandle, "APLICAFORMATO") = 1 Then
                    Dim value As Integer = IIf(Not IsDBNull(e.CellValue), e.CellValue, 0)
                    Dim cuatrimestre As Integer = CInt(grdVReporte.GetRowCellValue(e.RowHandle, "CUATRIMESTRE"))
                    Dim ValorIdealSemanal As Integer = 0
                    Dim uno = IdealSemanal.Select(Function(x) x.Item("CUATRIMESTRE") = cuatrimestre)
                    For Each row As DataRow In IdealSemanal
                        If row.Item("CUATRIMESTRE") = cuatrimestre Then
                            ValorIdealSemanal = IIf(Not IsDBNull(row.Item(e.Column.FieldName)), row.Item(e.Column.FieldName).ToString, 0)
                            If value < ValorIdealSemanal Then
                                e.Appearance.ForeColor = Color.Red
                            End If
                        End If
                    Next
                End If
                If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "CUMP1" Or currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "CUMP2" Or currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "CUMP3" Then
                    If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                        e.Appearance.BackColor = ObtenerColorCelda(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                        e.Appearance.ForeColor = ObtenerColorLetra(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                    Else
                        currentView.SetRowCellValue(e.RowHandle, e.Column, 0)
                    End If
                End If
            End If
        End If

    End Sub


    Private Sub grdVReporte_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdVReporte.RowStyle

        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If tipoReporte = 1 Or tipoReporte = 2 Or tipoReporte = 3 Then
            If currentView.GetRowCellValue(e.RowHandle, "SEM") = "1C" Then
                e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "SEM") = "2C" Then
                e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "SEM") = "3C" Then
                e.Appearance.BackColor = Color.FromArgb(220, 230, 241)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "SEM") = "TOTAL" Then
                'e.Appearance.BackColor = Color.FromArgb(193, 193, 193)
                e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
            End If
        ElseIf tipoReporte = 4 Or tipoReporte = 5 Then
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "IDEAL PED. SEMANAL" Then
                e.Appearance.BackColor = Color.FromArgb(204, 255, 204)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "SEMANA") = 100 Then
                e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL PEDIDOS C1" Then
                e.Appearance.BackColor = Color.FromArgb(216, 228, 188)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL PEDIDOS C2" Then
                e.Appearance.BackColor = Color.FromArgb(255, 255, 204)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL PEDIDOS C3" Then
                e.Appearance.BackColor = Color.FromArgb(220, 230, 241)
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL GENERAL" Then
                e.Appearance.BackColor = Color.FromArgb(193, 193, 193)
            End If
        End If


    End Sub

    Private Sub grdVReporte_CellMerge(sender As Object, e As CellMergeEventArgs) Handles grdVReporte.CellMerge
        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If tipoReporte = 1 Or tipoReporte = 2 Or tipoReporte = 3 Then
            If e.Column.FieldName = "CUA" Or (currentView.GetRowCellValue(e.RowHandle1, "SEM").ToString.Contains("C") And currentView.GetRowCellValue(e.RowHandle2, "SEM").ToString.Contains("C")) Or (currentView.GetRowCellValue(e.RowHandle1, "SEM") = "TOTAL" And currentView.GetRowCellValue(e.RowHandle2, "SEM") = "TOTAL") Then
                Dim Texto1 As String = currentView.GetRowCellDisplayText(e.RowHandle1, e.Column.FieldName)
                Dim Texto2 As String = currentView.GetRowCellDisplayText(e.RowHandle2, e.Column.FieldName)
                e.Merge = (Texto1 = Texto2)
                e.Handled = True
            Else
                e.Merge = False
                e.Handled = True
            End If

            If e.Column.Caption = "PROY" Or e.Column.Caption = "REAL" Then
                e.Merge = False
                e.Handled = True
            End If
        Else
            e.Merge = False
            e.Handled = True
        End If
    End Sub

    Private Sub grdVReporte_CalcRowHeight(sender As Object, e As RowHeightEventArgs) Handles grdVReporte.CalcRowHeight
        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        If tipoReporte = 1 Or tipoReporte = 2 Or tipoReporte = 3 Then
            If currentView.GetRowCellValue(e.RowHandle, "SEM") = "TOTAL" Then
                e.RowHeight = 35
            End If
        End If
        If tipoReporte = 4 Or tipoReporte = 5 Then
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "IDEAL PED. SEMANAL" Then
                e.RowHeight = 23
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL PEDIDOS C1" Then
                e.RowHeight = 23
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL PEDIDOS C2" Then
                e.RowHeight = 23
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL PEDIDOS C3" Then
                e.RowHeight = 23
            End If
            If currentView.GetRowCellValue(e.RowHandle, "PERIODO") = "TOTAL GENERAL" Then
                e.RowHeight = 30
            End If
        End If

    End Sub

    Private Sub grdVReporte_PrintInitialize(sender As Object, e As PrintInitializeEventArgs) Handles grdVReporte.PrintInitialize
        TryCast(e.PrintingSystem, PrintingSystemBase).PageSettings.Landscape = True
    End Sub


End Class