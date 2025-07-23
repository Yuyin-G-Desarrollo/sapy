Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report

Public Class ConsultaSalidasProductoForm

    Private ObjBU As New Negocios.VerificacionSalidasBU
    Dim ListaFolio As New List(Of String)
    Dim ListaFolioOT As New List(Of String)
    Dim idNave As Integer



    Private Sub ConsultaSalidasProductoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim idUsuario As Int16 = 0

        Me.WindowState = FormWindowState.Maximized
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        chkFiltrarPorFecha.Checked = True
        lblTotalRegistros.Text = "0"
        idUsuario = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        idNave = ObjBU.ObtenerNaveUsuario(idUsuario)

        CargarFolios()
        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        pnPBar.Top = (Me.Height - pnPBar.Height) / 2
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)

    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim form As New DetallesFolioEmbarqueForm
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim FolioVerificacionID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = viewConsultaFolios.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewConsultaFolios.IsRowSelected(index)) = True Then
                    FilasSeleccionadas += 1
                    FolioVerificacionID = CInt(viewConsultaFolios.GetRowCellValue(viewConsultaFolios.GetVisibleRowHandle(index), "FolioVerificacionID"))
                End If
            Next

            If FolioVerificacionID > 0 Then
                form.FolioVerificacionID = FolioVerificacionID
                form.MdiParent = Me.MdiParent
                form.Show()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una fila.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub btnAltaFolio_Click(sender As Object, e As EventArgs) Handles btnAltaFolio.Click

        Dim form As New ValidaOperadorEmbarqueForm
        form.ShowDialog()


        ''CargarFolios()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CargarFolios()
        Dim dtResultado As DataTable
        Dim FiltrarPorFecha As Boolean = False
        Dim FechaInicio As Date
        Dim FechaFin As Date
        Dim FiltroFoliosVerificacion As String = String.Empty
        Dim FiltrosOT As String = String.Empty
        Dim FiltroEstatus As String = String.Empty
        Dim Cedis As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            FiltrarPorFecha = chkFiltrarPorFecha.Checked
            FechaInicio = dtpFechaInicio.Value
            FechaFin = dtpFechaFin.Value
            FiltroFoliosVerificacion = ObtenerFiltrosGrid(gridfiltroFolioVerificacion)
            FiltrosOT = ObtenerFiltrosGrid(grdFiltroOT)
            FiltroEstatus = ObtenerFiltrosGrid(grdStatusVerificacion)
            Cedis = cboxNaveAlmacen.SelectedValue

            'Actualizar los folios de embaque a facturado

            ObjBU.ActualizarFolioEmbarqueAFacturado(idNave)

            dtResultado = ObjBU.ConsultarFolios(FiltrarPorFecha, FechaInicio, FechaFin, FiltroEstatus, FiltroFoliosVerificacion, FiltrosOT, Cedis)
            grdConsultaFolios.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewConsultaFolios)

            viewConsultaFolios.Columns.ColumnByFieldName("FechaInicio").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            viewConsultaFolios.Columns.ColumnByFieldName("FechaFin").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            'viewConsultaFolios.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = "N0"
            viewConsultaFolios.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            DiseñoGrid.EstiloColumna(viewConsultaFolios, "FolioVerificacionID", "Folio Verificacion ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "FechaCaptura", "Fecha Captura", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "FechaInicio", "Fecha Inicio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "FechaFin", "Fecha Fin", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "Capturo", "Capturo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "NumeroOTs", "Número OTs", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "OperadorUnidad", "Operador de Unidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "Unidad", "Unidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "Mensajeria", "Mensajeria", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "StatusID", "StatusID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "Status", "Status", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "TotalPares", "Total Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
            DiseñoGrid.EstiloColumna(viewConsultaFolios, "FolioPaqueteria", "Folio Paqueteria", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")




            lblTotalRegistros.Text = CDbl(dtResultado.Rows.Count).ToString("N0")

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function

    Private Sub LimpiarFiltros()
        Try
            chkFiltrarPorFecha.Checked = True
            dtpFechaInicio.Value = Date.Now
            dtpFechaFin.Value = Date.Now
            gridfiltroFolioVerificacion.DataSource = Nothing
            grdFiltroOT.DataSource = Nothing
            grdStatusVerificacion.DataSource = Nothing
            grdConsultaFolios.DataSource = Nothing
            lblTotalRegistros.Text = "0"
            ListaFolio.Clear()
            ListaFolioOT.Clear()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarFiltros()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        Try
            Cursor = Cursors.WaitCursor
            If chkFiltrarPorFecha.Checked = True Then
                If dtpFechaInicio.Value <= dtpFechaFin.Value Then
                    CargarFolios()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor a la de fin.")
                End If
            Else
                CargarFolios()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdConsultaFolios.ExportToXlsx(.SelectedPath + "\Datos_FoliosVerificación_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdConsultaFolios.ExportToXlsx(.SelectedPath + "\Datos_FoliosVerificación_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_FoliosVerificación_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_FoliosVerificación_" + fecha_hora + ".xlsx")
                End If
            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        'Dim EstatusID As Integer = grdVentas.GetRowCellValue(e.RowHandle, "EstatusID")
        'Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        'Dim TotalErrores As Integer = 0
        'Dim TotalIncidencias As Integer = 0
        'Dim index As Integer = 0
        'Try



        '    If EstatusID = 130 Then
        '        e.Formatting.BackColor = pnlEstatusRechazada.BackColor
        '    ElseIf Bloqueado = "SI" Then
        '        e.Formatting.BackColor = Color.Salmon
        '    Else
        '        'If e.ColumnFieldName = "ColorEstatus" Then
        '        '    e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

        '        'End If
        '    End If

        '    If e.ColumnFieldName = "ColorEstatus" Then
        '        e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

        '    End If

        '    If TipoPerfil = 2 Then

        '        If chkDetallada.Checked = False Then
        '            If e.ColumnFieldName = "TotalErrores" Then
        '                TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
        '                If TotalErrores > 0 Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Black
        '                End If
        '            End If
        '        End If



        '        If e.ColumnFieldName = "TotalIncidencias" Then
        '            TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

        '            If TotalIncidencias > 0 Then
        '                e.Formatting.Font.Color = Color.Red
        '            Else
        '                e.Formatting.Font.Color = Color.Black
        '            End If
        '        End If

        '        If e.ColumnFieldName = "FechaValidoAlmacen" Then
        '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
        '                If EstatusID = "129" Or EstatusID = "130" Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Green
        '                End If
        '            End If

        '        End If

        '        If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
        '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
        '                If EstatusID = "129" Or EstatusID = "130" Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Green
        '                End If
        '            End If

        '        End If


        '    End If

        'Catch ex As Exception
        '    show_message("Error", ex.Message.ToString())
        'End Try



        e.Handled = True
    End Sub

    Private Sub chkFiltrarPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltrarPorFecha.CheckedChanged
        dtpFechaFin.Enabled = chkFiltrarPorFecha.Checked
        dtpFechaInicio.Enabled = chkFiltrarPorFecha.Checked
    End Sub

    Private Sub txtFolioVerificacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioVerificacion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioVerificacion.Text) Then Return

            ListaFolio.Add(txtFolioVerificacion.Text)
            gridfiltroFolioVerificacion.DataSource = Nothing
            gridfiltroFolioVerificacion.DataSource = ListaFolio

            txtFolioVerificacion.Text = String.Empty

        End If
    End Sub

    Private Sub txtFolioOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioOT.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioOT.Text) Then Return

            ListaFolioOT.Add(txtFolioOT.Text)
            grdFiltroOT.DataSource = Nothing
            grdFiltroOT.DataSource = ListaFolioOT

            txtFolioOT.Text = String.Empty

        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        imprimirReporte()
    End Sub

    Public Sub imprimirReporte()
        Dim dtFiniquitoFiscal As New DataTable
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsTotalEmbarque As New DataSet("dsTotalEmbarque")
        Dim dtTotalesEmbarque As New DataTable
        Dim dtInformacion As New DataTable
        Dim ReporteEmbarque As New StiReport
        Dim NumeroFilas As Integer = 0
        Dim FolioVerificacionID As Integer = 0
        Dim tool As New Tools.Controles

        Try

            Cursor = Cursors.WaitCursor

            NumeroFilas = viewConsultaFolios.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewConsultaFolios.IsRowSelected(index)) = True Then
                    FolioVerificacionID = CInt(viewConsultaFolios.GetRowCellValue(viewConsultaFolios.GetVisibleRowHandle(index), "FolioVerificacionID"))
                End If
            Next

            dtInformacion = ObjBU.ObtenerInformacionEncabezadoReporteFolio(FolioVerificacionID)
            dtTotalesEmbarque = ObjBU.ObtenerInformacionReporteFolio(FolioVerificacionID)

            entReporte = If(CInt(cboxNaveAlmacen.SelectedValue) = 43,
                objReporte.LeerReporteporClave("ALM_REPORTE_FOLIO_EMBARQUE"),
                objReporte.LeerReporteporClave("ALM_REPORTE_FOLIO_EMBARQUE_RE"))

            dsTotalEmbarque.Tables.Add(dtTotalesEmbarque)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

            ReporteEmbarque.Load(archivo)
            ReporteEmbarque.Compile()
            ReporteEmbarque.RegData(dsTotalEmbarque.Tables(0))
            ReporteEmbarque("TotalPares") = CDbl(dtInformacion.Rows(0).Item("TotalPares")).ToString("N0")
            ReporteEmbarque("TotalAtados") = CDbl(dtInformacion.Rows(0).Item("Atados")).ToString("N0")
            ReporteEmbarque("TotalOT") = dtInformacion.Rows(0).Item("TotalOT").ToString()
            ReporteEmbarque("Recibio") = dtInformacion.Rows(0).Item("Operador").ToString()
            ReporteEmbarque("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            ReporteEmbarque("NombreReporte") = "ReporteFolioEmbarque"
            ReporteEmbarque("FolioEmbarque") = FolioVerificacionID.ToString()
            ReporteEmbarque("Mensajeria") = dtInformacion.Rows(0).Item("Mensajeria").ToString()
            ReporteEmbarque("Operador") = dtInformacion.Rows(0).Item("Operador").ToString()
            ReporteEmbarque("Entrego") = dtInformacion.Rows(0).Item("Entrego").ToString()
            ReporteEmbarque("Transporte") = dtInformacion.Rows(0).Item("Unidad").ToString()
            ReporteEmbarque("FolioPaqueteria") = dtInformacion.Rows(0).Item("FolioPaqueteria").ToString()
            ReporteEmbarque("Cliente") = dtInformacion.Rows(0).Item("Cliente").ToString()
            If CInt(cboxNaveAlmacen.SelectedValue) = 82 Then
                ReporteEmbarque("FechaEntrega") = Convert.ToDateTime(dtInformacion.Rows(0).Item("FechaEntrega").ToString()).ToLongDateString()
            End If
            ReporteEmbarque.Dictionary.Clear()
            ReporteEmbarque.Dictionary.Synchronize()
            ReporteEmbarque.Render()
            ReporteEmbarque.Show()


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub grdFiltroOT_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroOT.InitializeLayout
        grid_diseño(grdFiltroOT)
        grdFiltroOT.DisplayLayout.Bands(0).Columns(0).Header.Caption = "OT"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
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

    'Asigna formato a columnas de ultragrid
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

    Private Sub grdStatusVerificacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusVerificacion.InitializeLayout
        grid_diseño(grdStatusVerificacion)
        grdStatusVerificacion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "OT"
    End Sub

    Private Sub gridfiltroFolioVerificacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridfiltroFolioVerificacion.InitializeLayout
        grid_diseño(gridfiltroFolioVerificacion)
        gridfiltroFolioVerificacion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Embarque"
    End Sub

    Private Sub grdFiltroOT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroOT.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroOT.DeleteSelectedRows(False)
    End Sub

    Private Sub grdStatusVerificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatusVerificacion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatusVerificacion.DeleteSelectedRows(False)
    End Sub

    Private Sub gridfiltroFolioVerificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles gridfiltroFolioVerificacion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridfiltroFolioVerificacion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnStatusVerificacion_Click(sender As Object, e As EventArgs) Handles btnStatusVerificacion.Click
        Dim listado As New ListadoParametrosForm
        listado.tipo_busqueda = 19

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatusVerificacion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusVerificacion.DataSource = listado.listParametros
        With grdStatusVerificacion
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnGenerarSalida_Click(sender As Object, e As EventArgs) Handles btnGenerarSalida.Click

        Try
            Cursor = Cursors.WaitCursor
            pnPBar.Visible = True
            pBar.Minimum = 0
            pBar.ForeColor = Color.Blue
            pBar.Maximum = 3
            lblInfo.Text = "Generando los detalles de las salidas."
            System.Windows.Forms.Application.DoEvents()
            ObjBU.GenerarDetallesSalidaVentas(idNave)
            pBar.Value = 1
            lblInfo.Text = "Generando el embarque y salida."
            System.Windows.Forms.Application.DoEvents()
            ObjBU.GenerarEmbarqueYSalida(idNave)
            pBar.Value = 2
            lblInfo.Text = "Actualizando las OTs a Entregado."
            System.Windows.Forms.Application.DoEvents()
            ObjBU.ActualizarOT_A_Entregado(idNave)
            pBar.Value = 3
            System.Windows.Forms.Application.DoEvents()
            Cursor = Cursors.Default
            pnPBar.Visible = False
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se actualizaron los registros de salidas.")
        Catch ex As Exception
            pnPBar.Visible = False
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub


    Private Sub btnAbajo_Click_1(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlAcciones.Height = 171
    End Sub

    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlAcciones.Height = 27
    End Sub

    Private Sub btnAndrea_Click(sender As Object, e As EventArgs) Handles btnAndrea.Click
        Dim FolioVerificacionId As Integer = 0
        Dim ColaboradorCapturo As Integer = 0
        Dim dtResultado As DataTable

        If ObjBU.SessionActivaAndrea() = True Then

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ya hay una sessión activa.")
            dtResultado = ObjBU.ConsultaFolioAndrea()

            FolioVerificacionId = dtResultado.Rows(0).Item(0)
            ColaboradorCapturo = dtResultado.Rows(0).Item(1)

            Dim LecturasParesForm As New LecturaParesSalidaForm
            LecturasParesForm.FolioVerificacionId = FolioVerificacionId
            LecturasParesForm.ColaboradorId = ColaboradorCapturo
            LecturasParesForm.EsAndrea = True
            LecturasParesForm.MdiParent = Me.MdiParent
            LecturasParesForm.Show()
            Me.Close()

        Else
            Dim form As New AndreaFechaEntregaForm
            form.MdiParent = Me.MdiParent
            form.Show()
        End If

    End Sub

    Private Sub btnDevoluciones_Click(sender As Object, e As EventArgs) Handles btnDevoluciones.Click
        Dim DevolucionForm As New SeleccionarDevolucionesForm
        DevolucionForm.ShowDialog()

    End Sub
End Class