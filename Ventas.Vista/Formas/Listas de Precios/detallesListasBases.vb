Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports Infragistics.Win
Imports System.Drawing

Public Class detallesListasBases
    Public idLista As Int32
    Public estatus As String
    Dim idEstatus As Int32
    Dim esListaActual As Boolean

    Dim fechaInicialINICIO As String
    Dim fechaInicialFIN As String
    Dim nombreListaInicial As String

    Dim dtFiltroMarca As DataTable
    Dim dtFiltroColeccion As DataTable
    Dim dtFiltroPiel As DataTable
    Dim cadenaMarca As String
    Dim modelosNuevos As Boolean
    Dim dtFiltroColor As DataTable

    Dim endEdit As Boolean = True

    Private Sub detallesListasBases_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarDatosPrincipales()

    End Sub

    Public Sub llenarDatosPrincipales()
        Dim objProd As New Ventas.Negocios.ListaBaseBU
        modelosNuevos = False
        Dim dtDatosLista As New DataTable
        Dim dtlimitesVigencias As New DataTable
        dtDatosLista = objProd.verListaPBase(idLista)
        dtlimitesVigencias = objProd.consultarLimitesVigenciasPorListasVentas(idLista)
        idEstatus = CInt(dtDatosLista.Rows(0)("lpba_estatus").ToString())
        If idEstatus = 2 Then
            esListaActual = True
        Else
            esListaActual = False
        End If
        nombreListaInicial = dtDatosLista.Rows(0)("lpba_nombreLista").ToString
        fechaInicialINICIO = dtDatosLista.Rows(0)("lpba_vigenciainicio").ToString
        fechaInicialFIN = dtDatosLista.Rows(0)("lpba_vigenciafin").ToString
        If idEstatus = 1 Then
            lblEstatus.ForeColor = Color.DarkOrange
            lblEstatus.Text = "ACTIVA"
        ElseIf idEstatus = 2 Then
            lblEstatus.Text = "AUTORIZADA"
        Else
            lblEstatus.Text = "INACTIVA"
            lblEstatus.ForeColor = Color.Red
        End If

        txtNombreLista.Text = dtDatosLista.Rows(0)("lpba_nombreLista").ToString
        txtCodigo.Text = dtDatosLista.Rows(0)("lpba_codigolistabase").ToString
        dttFechaInicio.Value = dtDatosLista.Rows(0)("lpba_vigenciainicio").ToString
        dttFechaFin.Value = dtDatosLista.Rows(0)("lpba_vigenciafin").ToString
        'COMENTADO AVV 25/09/2015
        'If dtlimitesVigencias.Rows(0).Item("INICIO").ToString <> "" And dtlimitesVigencias.Rows(0).Item("FIN").ToString <> "" Then
        '    dttFechaInicio.MaxDate = CDate(dtlimitesVigencias.Rows(0).Item("INICIO").ToString).ToShortDateString
        '    dttFechaFin.MinDate = CDate(dtlimitesVigencias.Rows(0).Item("FIN").ToString).ToShortDateString
        'End If
        chkModelosConPrecio.Checked = True
        chkCargarModelosSinPrecio.Checked = True
        chkEstatusActivo.Checked = True
        If idEstatus <> 3 Then
            chkCargarModelosSinPrecio.Visible = True
            btnEditar.Enabled = True
            lblEditar.Enabled = True
        End If
        grdDatosProductos.DisplayLayout.Bands(0).Columns("PrecioAnterior").Hidden = True

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "SOLO_CONSULTA") Then
            btnEditarDatosLista.Enabled = False
            btnEditar.Enabled = False
        Else
            btnEditarDatosLista.Enabled = True
            btnEditar.Enabled = True
        End If
    End Sub


    Public Sub llenarListaDeModelos()
        Dim objProd As New Ventas.Negocios.ListaBaseBU
        Dim dtDatosModelos As New DataTable
        Dim gridvalido As Boolean = True
        lblConPrecio.Text = "0"
        lblPrecioModificado.Text = "0"
        lblSinPrecio.Text = "0"
        Me.Cursor = Cursors.WaitCursor
        grdDatosProductos.DataSource = Nothing
        If CBool(chkModelosConPrecio.Checked) = False And CBool(chkCargarModelosSinPrecio.Checked) = False Then
            gridvalido = False
        End If

        If CBool(chkEstatusActivo.Checked) = False And CBool(chkDescontinuados.Checked) = False Then
            gridvalido = False
        End If

        If gridvalido = True Then
            Dim contArticulosCPrecio As Int32 = 0
            dtDatosModelos = objProd.verDetallesListaPrecios(idLista, chkModelosConPrecio.Checked, chkCargarModelosSinPrecio.Checked, chkEstatusActivo.Checked, chkDescontinuados.Checked)
            If dtDatosModelos.Rows.Count > 0 Then
                grdDatosProductos.DataSource = dtDatosModelos
                lblTotalArticulos.Text = dtDatosModelos.Rows.Count.ToString("N0")

                For Each rowDt As DataRow In dtDatosModelos.Rows
                    If rowDt.Item("PrecioAnterior") > 0 Then
                        contArticulosCPrecio += 1
                    End If
                Next
                lblArticulosConPrecio.Text = contArticulosCPrecio.ToString("N0")
                formatosGrid()
                endEdit = False
            End If

        End If

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub formatosGrid()
        lblConPrecio.Text = "0"
        lblPrecioModificado.Text = "0"
        lblSinPrecio.Text = "0"
        With grdDatosProductos.DisplayLayout.Bands(0)
            .Columns("lpbp_listapreciosbaseid").Hidden = True
            .Columns("lpbp_listapreciobaseproductoid").Hidden = True
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOBASE", "VER_COL_PRD_STY") Then
                .Columns("pres_productoestiloid").Hidden = False
            Else
                .Columns("pres_productoestiloid").Hidden = True
            End If

            .Columns("cole_coleccionid").Hidden = True
            .Columns("marc_marcaid").Hidden = True
            .Columns("piel_pielid").Hidden = True
            .Columns("color_colorid").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("pres_activo").Hidden = True
            .Columns("fami_familiaid").Hidden = True
            .Columns("linea_lineaid").Hidden = True
            .Columns("stpr_productoStatusId").Hidden = True
            .Columns("marc_decimales").Hidden = True
            .Columns("prod_descripcion").Hidden = True
            .Columns("pres_codSicy").Hidden = True

            .Columns("prod_codigo").Header.Caption = "Modelo SAY"
            .Columns("prod_modelo").Header.Caption = "Modelo SICY"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("pres_productoestiloid").Header.Caption = "ProductoEstiloID"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("pres_codSicy").Header.Caption = "SICY"
            .Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("linea_descripcion").Header.Caption = "Linea"
            .Columns("stpr_descripcion").Header.Caption = "Estatus"

            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("pres_productoestiloid").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("pres_codSicy").CellActivation = Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Activation.NoEdit
            .Columns("stpr_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_decimales").CellActivation = Activation.NoEdit
            .Columns("prod_modelo").CellActivation = Activation.NoEdit

            .Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("talla_descripcion").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prod_modelo").CellAppearance.TextHAlign = HAlign.Right
        End With

        grdDatosProductos.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
        Dim colSeleccion As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = ""
        colSeleccion.Header.VisiblePosition = 0
        colSeleccion.Style = ColumnStyle.CheckBox
        colSeleccion.Width = 50

        grdDatosProductos.DisplayLayout.Bands(0).Columns.Add("Estado", "Estado")
        Dim colEstado As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Estado")
        colEstado.DefaultCellValue = False
        colEstado.CellAppearance.TextHAlign = HAlign.Center
        colEstado.Header.VisiblePosition = 1
        colEstado.Header.Caption = ""
        colEstado.Width = 50
        colEstado.CellActivation = Activation.NoEdit

        Dim colPrecioAntes As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("PrecioAnterior")
        colPrecioAntes.Style = ColumnStyle.CurrencyNonNegative
        colPrecioAntes.MaskInput = "nnnn.nn"
        colPrecioAntes.CellAppearance.TextHAlign = HAlign.Right
        colPrecioAntes.Header.Caption = "P. Original"
        colPrecioAntes.FilterOperandStyle = FilterOperandStyle.Edit
        colPrecioAntes.CellActivation = Activation.NoEdit
        colPrecioAntes.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals

        Dim colPrecio As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Precio")
        colPrecio.Header.Caption = "*Precio"
        colPrecio.Style = ColumnStyle.CurrencyNonNegative
        colPrecio.CellAppearance.TextHAlign = HAlign.Right
        colPrecio.FilterOperandStyle = FilterOperandStyle.Edit
        colPrecio.CellActivation = Activation.NoEdit
        colPrecio.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals

        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
            rowGR.Cells("Seleccion").Value = False
            If rowGR.Cells("PrecioAnterior").Value = 0 Then
                rowGR.Cells("Estado").Appearance.BackColor = Color.Red
            ElseIf rowGR.Cells("PrecioAnterior").Value > 0 Then
                rowGR.Cells("Estado").Appearance.BackColor = Color.DodgerBlue
            End If
        Next

        For Each rowgr As UltraGridRow In grdDatosProductos.Rows
            If rowgr.Cells("Precio").Value <> rowgr.Cells("PrecioAnterior").Value Then
                rowgr.Cells("Estado").Appearance.BackColor = Color.Lime
                rowgr.Cells("Estado").Value = "D"
                lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                If rowgr.Cells("Precio").Value < rowgr.Cells("PrecioAnterior").Value Then
                    rowgr.Cells("Precio").Appearance.ForeColor = Color.Red
                    rowgr.Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                End If
            Else
                If rowgr.Cells("PrecioAnterior").Value = 0 Then
                    rowgr.Cells("Estado").Appearance.BackColor = Color.Red
                    rowgr.Cells("Estado").Value = "N"
                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")

                ElseIf rowgr.Cells("PrecioAnterior").Value > 0 Then
                    rowgr.Cells("Estado").Appearance.BackColor = Color.DodgerBlue
                    rowgr.Cells("Estado").Value = "P"
                    lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                End If
            End If
        Next
        grdDatosProductos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatosProductos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatosProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosProductos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatosProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatosProductos.Rows(0).Selected = True
    End Sub

    Public Sub exportarPDF()
        Dim gr As New UltraGrid
        Dim sfd As New SaveFileDialog
        Dim ugde As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter()
        sfd.DefaultExt = "pdf"
        sfd.Filter = "PDF files (*.pdf)|*.pdf"
        Dim result As DialogResult = sfd.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim fileName As String = sfd.FileName
            ugde.AutoSize = Infragistics.Win.UltraWinGrid.DocumentExport.AutoSize.SizeColumnsToContent
            ugde.TargetPaperOrientation = PageOrientation.Portrait
            ugde.TargetPaperSize = PageSizes.A4
            Dim r As Report = New Report()

            Dim sec As ISection = r.AddSection()
            Dim img As Infragistics.Documents.Reports.Graphics.Image = New Infragistics.Documents.Reports.Graphics.Image(Global.Ventas.Vista.My.Resources.Resources.yuyin)

            Dim sectionHeader As Infragistics.Documents.Reports.Report.Section.ISectionHeader = sec.AddHeader()
            sectionHeader.Repeat = True
            sectionHeader.Height = 100

            Dim sectionHeaderImg As Infragistics.Documents.Reports.Report.IImage = sectionHeader.AddImage(img, 0, 0)
            sectionHeaderImg.Paddings.All = 10

            Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(0, 0)
            sectionHeaderText.Paddings.Top = 60
            sectionHeaderText.Alignment = New TextAlignment(Alignment.Center)
            sectionHeaderText.AddContent("Listas")

            Dim sectionHeaderDate As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(0, 0)
            sectionHeaderDate.Paddings.Top = 60
            sectionHeaderDate.Alignment = New TextAlignment(Alignment.Left)
            sectionHeaderDate.AddContent(DateTime.Now.ToString("d"))

            Dim sectionFooter As Infragistics.Documents.Reports.Report.Section.ISectionFooter = sec.AddFooter()
            sectionFooter.Repeat = True
            sectionFooter.Height = 60

            Dim sectionFooterText As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooterText.Alignment = New TextAlignment(Alignment.Left)
            sectionFooterText.AddContent("Página: ")
            sectionFooterText.AddPageNumber(PageNumberFormat.Decimal)
            gr = grdDatosProductos
            gr.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
            gr.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
            ugde.Export(gr, sec)
            gr.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = False
            gr.DisplayLayout.Bands(0).Columns("Estado").Hidden = False
            Me.Cursor = Cursors.Default
            MsgBox("Se exportó correctamente.", MsgBoxStyle.Information, "")
            Try
                r.Publish(fileName, FileFormat.PDF)
                Process.Start(fileName)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento PDF " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try

        End If
    End Sub

    Public Sub restauraraDAtosGuardar()
        txtPrecioMultiple.Text = String.Empty
        txtPrecioMultiple.Enabled = False
        btnCargarPrecioMultiple.Enabled = False
        chkSeleccionarFiltrados.Enabled = False
        Dim colckbPl As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Precio")
        colckbPl.CellActivation = Activation.NoEdit
        chkCargarModelosSinPrecio.Enabled = True
        chkEstatusActivo.Enabled = True
        btnEditar.Enabled = True
        lblEditar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        lblGuardar.Enabled = False
        lblCancelar.Enabled = False
        dttFechaInicio.Enabled = False
        dttFechaFin.Enabled = False
        txtNombreLista.Enabled = False
        If chkModelosConPrecio.Checked = True Then
            llenarListaDeModelos()
        Else
            chkModelosConPrecio.Checked = True
        End If
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReportePDF.Click
        If grdDatosProductos.Rows.Count > 0 Then
            exportarPDF()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub grdDatosProductos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosProductos.AfterCellUpdate
        If endEdit = False Then
            If (e.Cell.Column.ToString = "Precio" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index) Then
                If e.Cell.Value.ToString = "" Then
                    e.Cell.Value = 0
                ElseIf e.Cell.Value > 9999 Then
                    e.Cell.Value = 0
                End If
            End If
        End If

        If (e.Cell.Column.ToString = "Precio" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index) Then
            Dim PrecioAnterior As String = e.Cell.OriginalValue.ToString
            Dim contAnt As Int32 = 0
            Dim contNuevo As Int32 = 0

            If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value <> e.Cell.Value Then
                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Lime
                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "D"
                If e.Cell.Value > 0 Then
                    If PrecioAnterior = "0" Then
                        If CInt(lblSinPrecio.Text) > 0 Then
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                        End If
                        lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                    ElseIf PrecioAnterior = grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                        lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) + 1).ToString("N0")
                    End If
                End If
                If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Red
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                Else
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Black
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.False
                End If
            Else
                If e.Cell.Value = 0 Then
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
                    If PrecioAnterior = grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")

                    ElseIf PrecioAnterior <> grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                        lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")

                    End If
                    If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Red
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                    Else
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Black
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.False
                    End If
                ElseIf e.Cell.Value > 0 Then
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.DodgerBlue
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "P"
                    If PrecioAnterior = "0" Then
                        If CInt(lblSinPrecio.Text) > 0 Then
                            lblSinPrecio.Text = (CInt(lblSinPrecio.Text) - 1).ToString("N0")
                        End If
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                    ElseIf PrecioAnterior <> grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                        lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                        lblConPrecio.Text = (CInt(lblConPrecio.Text) + 1).ToString("N0")
                    End If
                    If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Red
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                    Else
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Black
                        grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.False
                    End If
                End If
            End If
            If e.Cell.Value = 0 And grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > 0 Then
                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Appearance.BackColor = Color.Red
                grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Estado").Value = "N"
                If PrecioAnterior = grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                    lblConPrecio.Text = (CInt(lblConPrecio.Text) - 1).ToString("N0")
                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                ElseIf PrecioAnterior <> grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value Then
                    lblPrecioModificado.Text = (CInt(lblPrecioModificado.Text) - 1).ToString("N0")
                    lblSinPrecio.Text = (CInt(lblSinPrecio.Text) + 1).ToString("N0")
                End If
                If grdDatosProductos.Rows(e.Cell.Row.Index).Cells("PrecioAnterior").Value > e.Cell.Value Then
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Red
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.True
                Else
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.ForeColor = Color.Black
                    grdDatosProductos.Rows(e.Cell.Row.Index).Cells("Precio").Appearance.FontData.Bold = DefaultableBoolean.False
                End If
            End If
        End If
    End Sub

    Private Sub grdDatosProductos_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles grdDatosProductos.DoubleClickHeader

    End Sub

    Private Sub grdDatosProductos_DragDrop(sender As Object, e As DragEventArgs) Handles grdDatosProductos.DragDrop
        Dim dropIndex As Integer

        Dim uieOver As UIElement = grdDatosProductos.DisplayLayout.UIElement.ElementFromPoint(grdDatosProductos.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdDatosProductos.Rows.Move(aRow, dropIndex)
            Next
        End If
    End Sub

    Private Sub grdDatosProductos_DragOver(sender As Object, e As DragEventArgs) Handles grdDatosProductos.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdDatosProductos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdDatosProductos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdDatosProductos_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatosProductos.SelectionDrag
        grdDatosProductos.DoDragDrop(grdDatosProductos.Selected.Rows, DragDropEffects.Move)
    End Sub

    Public Function validaCeros() As Boolean
        Dim cont As Int32 = 0
        For Each rowP As UltraGridRow In grdDatosProductos.Rows
            If rowP.Cells("Precio").Value = 0 Then
                rowP.Appearance.BackColor = Color.PaleTurquoise
                cont = cont + 1
            Else
                rowP.Appearance.BackColor = Nothing
            End If
        Next
        If cont > 0 Then
            Return False
        End If
        Return True
    End Function

    Public Sub editarPrecios()
        Dim objListaBu As New Negocios.ListaBaseBU
        Dim dtListaArticulosLVCPS As New DataTable
        Dim objfrmMPBLVCPS As New frmModificacionPrecioBase
        For Each rowDT As UltraGridRow In grdDatosProductos.Rows
            If rowDT.Cells("PrecioAnterior").Value <> rowDT.Cells("Precio").Value Then
                'If idEstatus = 1 Then
                dtListaArticulosLVCPS = New DataTable
                dtListaArticulosLVCPS = objListaBu.consultaListaPreciosClientesPrecioArticulo(idLista, CInt(rowDT.Cells("pres_productoestiloid").Value))
                If dtListaArticulosLVCPS.Rows.Count > 0 Then
                    objfrmMPBLVCPS = New frmModificacionPrecioBase
                    objfrmMPBLVCPS.idListaBase = idLista
                    objfrmMPBLVCPS.idProductoEstilo = CInt(rowDT.Cells("pres_productoestiloid").Value)
                    objfrmMPBLVCPS.nombreListaBase = txtNombreLista.Text.Trim
                    objfrmMPBLVCPS.descripcionArticulo = rowDT.Cells("prod_descripcion").Value + " (" + rowDT.Cells("prod_codigo").Value + ") - " + rowDT.Cells("piel_descripcion").Value + " - " + rowDT.Cells("color_descripcion").Value + " - " + rowDT.Cells("talla_descripcion").Value + " - " + rowDT.Cells("pres_codSicy").Value
                    objfrmMPBLVCPS.precioAnterior = CDec(rowDT.Cells("PrecioAnterior").Value)
                    objfrmMPBLVCPS.precioNuevo = CDec(rowDT.Cells("Precio").Value)
                    objfrmMPBLVCPS.estatusListaBase = lblEstatus.Text
                    objfrmMPBLVCPS.dtDatosLVCPS = dtListaArticulosLVCPS
                    objfrmMPBLVCPS.ShowDialog()
                End If
                'End If
                objListaBu.EditarListaBasePrecios(idLista, CInt(rowDT.Cells("pres_productoestiloid").Value), CDec(rowDT.Cells("Precio").Value), CBool(rowDT.Cells("marc_decimales").Value))
            End If
        Next
    End Sub

    Private Sub grdDatosProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosProductos.InitializeLayout
        Me.grdDatosProductos.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        chkCargarModelosSinPrecio.Checked = True
        chkEstatusActivo.Checked = True
        chkCargarModelosSinPrecio.Enabled = False
        chkEstatusActivo.Enabled = False

        btnEditar.Enabled = False
        lblEditar.Enabled = False
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        lblGuardar.Enabled = True
        lblCancelar.Enabled = True
        btnCargarPrecioMultiple.Visible = True
        lblCargarPrecios.Visible = True
        txtPrecioMultiple.Visible = True

        chkSeleccionarFiltrados.Enabled = True
        btnCargarPrecioMultiple.Enabled = True
        txtPrecioMultiple.Enabled = True
        Dim colckbPl As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Precio")
        colckbPl.CellActivation = Activation.AllowEdit

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        txtPrecioMultiple.Text = String.Empty
        txtPrecioMultiple.Enabled = False
        btnCargarPrecioMultiple.Enabled = False
        chkSeleccionarFiltrados.Enabled = False
        chkCargarModelosSinPrecio.Enabled = True
        chkEstatusActivo.Enabled = True
        btnEditar.Enabled = True
        lblEditar.Enabled = True
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        lblGuardar.Enabled = False
        lblCancelar.Enabled = False
        dttFechaInicio.Enabled = False
        dttFechaFin.Enabled = False
        txtNombreLista.Enabled = False
        If chkModelosConPrecio.Checked = True Then
            llenarListaDeModelos()
        Else
            chkModelosConPrecio.Checked = True
        End If
        Dim colckbPl As UltraGridColumn = grdDatosProductos.DisplayLayout.Bands(0).Columns("Precio")
        colckbPl.CellActivation = Activation.NoEdit
    End Sub

    Public Function validarVacios() As Boolean
        If txtNombreLista.Text = "" Then
            lblNombreLista.ForeColor = Color.Red
            Return False
        End If
        Return True
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCargarPrecioMultiple_Click(sender As Object, e As EventArgs) Handles btnCargarPrecioMultiple.Click

        asignarPrecios()

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarFechas() = True Then
            If validarVacios() = True Then
                Dim objCaptcha As New Tools.frmCaptcha
                objCaptcha.mensaje = ""
                If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    editarPrecios()
                    Me.Cursor = Cursors.Default
                    Dim objMsj As New Tools.ExitoForm
                    objMsj.mensaje = "Registro correcto."
                    objMsj.ShowDialog()
                    restauraraDAtosGuardar()
                Else
                    Dim objMsj As New Tools.AdvertenciaForm
                    objMsj.mensaje = "Sin completar el captcha los datos no se guardan."
                    objMsj.ShowDialog()
                End If
            Else
                Dim objMsj As New Tools.AdvertenciaForm
                objMsj.mensaje = "Debe ingresar un nombre para la lista."
                objMsj.ShowDialog()
            End If
        Else
            Dim objMsj As New Tools.AdvertenciaForm
            objMsj.mensaje = "La Fecha Fin no es valida"
            objMsj.ShowDialog()
        End If

    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        Dim gr As New UltraGrid
        If result = Windows.Forms.DialogResult.OK Then
            Try
                gr = grdDatosProductos
                gr.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = True
                gr.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(gr, fileName)
                Me.Cursor = Cursors.Default
                gr.DisplayLayout.Bands(0).Columns("Seleccion").Hidden = False
                gr.DisplayLayout.Bands(0).Columns("Estado").Hidden = False
                Me.Cursor = Cursors.WaitCursor
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub
    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdDatosProductos.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnEditarDatosLista_Click(sender As Object, e As EventArgs) Handles btnEditarDatosLista.Click
        If idEstatus <> 3 Then
            txtNombreLista.Enabled = True
            lblNombreLista.Enabled = True
            dttFechaInicio.Enabled = True
            lblFechaInicio.Enabled = True
            dttFechaFin.Enabled = True
            lblFechaFin.Enabled = True

            btnGuardarLista.Enabled = True
            lblGuardarLista.Enabled = True
            btnCancelarCambiosLista.Enabled = True
            lblCancelarCambioLista.Enabled = True
            btnEditarDatosLista.Enabled = False
            lblEditarLista.Enabled = False
        End If
    End Sub

    Private Sub btnGuardarLista_Click(sender As Object, e As EventArgs) Handles btnGuardarLista.Click

        guardarCambiosDatosLista()
        'Dim llp As New ListaPreciosForm
        'llp.llenarListasBaseActivas()
        'llp.formatoGrids()


    End Sub

    Private Sub btnCancelarCambiosLista_Click(sender As Object, e As EventArgs) Handles btnCancelarCambiosLista.Click

        txtNombreLista.Enabled = False
        txtNombreLista.Text = nombreListaInicial
        lblNombreLista.Enabled = False

        dttFechaInicio.Enabled = False
        dttFechaInicio.Value = CDate(fechaInicialINICIO).ToShortDateString
        lblFechaInicio.Enabled = False

        dttFechaFin.Enabled = False
        dttFechaFin.Value = CDate(fechaInicialFIN).ToShortDateString
        lblFechaFin.Enabled = False

        btnGuardarLista.Enabled = False
        lblGuardarLista.Enabled = False
        btnCancelarCambiosLista.Enabled = False
        lblCancelarCambioLista.Enabled = False
        btnEditarDatosLista.Enabled = True
        lblEditarLista.Enabled = True

    End Sub

    Public Function validarFechas() As Boolean
        If dttFechaFin.Value.Date <= dttFechaInicio.Value.Date Then
            lblFechaFin.ForeColor = Color.Red
            Return False
        Else
            lblFechaFin.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function validarFechaFin()
        If dttFechaFin.Value.Date <= Date.Today Then
            If idEstatus = 1 Then
                MsgBox("La fecha fin de vigencia no es válida, agregue más tiempo a la vigencia de fin.")
                Return False
            ElseIf idEstatus = 2 Then
                MsgBox("La fecha fin de vigencia no es válida, agregue más tiempo a la vigencia de fin.")
                Return False
            End If
        End If
        Return True
    End Function

    Public Sub asignarPrecios()
        If txtPrecioMultiple.Text.Length > 0 Then
            If CDec(txtPrecioMultiple.Text) > 0 Then
                Dim contFilasCambio As Int32 = 0
                For Each rowGR As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
                    If CBool(rowGR.Cells("Seleccion").Text) = True Then
                        contFilasCambio += 1
                    End If
                Next
                If contFilasCambio > 0 Then
                    Dim objCaptcha As New Tools.frmCaptcha
                    objCaptcha.mensaje = "Registros por actualizar: " + contFilasCambio.ToString

                    If objCaptcha.ShowDialog = Windows.Forms.DialogResult.OK Then
                        For Each rowLB As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
                            If CBool(rowLB.Cells("Seleccion").Text) = True Then
                                If CBool(rowLB.Cells("marc_decimales").Value) = False Then
                                    rowLB.Cells("precio").Value = Math.Round(CDbl(txtPrecioMultiple.Text))
                                Else
                                    rowLB.Cells("precio").Value = txtPrecioMultiple.Text
                                End If
                            End If
                        Next
                        Dim contadorPrecio As Int32 = 0
                        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
                            If rowGR.Cells("Precio").Value > 0 Then
                                contadorPrecio += 1
                            End If
                        Next
                        lblArticulosConPrecio.Text = contadorPrecio.ToString("N0")
                        chkSeleccionarFiltrados.Checked = False
                        For Each rowGr As UltraGridRow In grdDatosProductos.Rows
                            rowGr.Cells("Seleccion").Value = False
                        Next
                        lblTotalSeleccionados.Text = "0"
                    End If
                Else
                    MsgBox("Debe seleccionar al menos un registro", MsgBoxStyle.Information, "Atención")
                End If
            End If
        End If
    End Sub


    Public Sub guardarCambiosDatosLista()
        If validarFechas() = True Then
            If validarFechaFin() = True Then
                Dim objListaBu As New Negocios.ListaBaseBU
                Dim entListaBase As New Entidades.ListaBase
                Dim objMensajeConfirma As New Tools.confirmarFormGrande

                If CDate(fechaInicialINICIO).ToShortDateString <> CDate(dttFechaInicio.Text).ToShortDateString Or CDate(fechaInicialFIN).ToShortDateString <> CDate(dttFechaFin.Text).ToShortDateString Then

                    objMensajeConfirma.mensaje = "¿Está seguro de guardar los cambios? (Al cambiar la fecha de vigencia -inicio o fin- se cambiará la vigencia de todas las listas de venta y de cliente derivadas de esta lista base para todas aquellas que tengan el mismo periodo de tiempo)"
                Else

                    objMensajeConfirma.mensaje = "¿Está seguro de guardar los cambios? "
                End If
                If objMensajeConfirma.ShowDialog = Windows.Forms.DialogResult.OK Then
                    entListaBase.PListaBaseId = idLista
                    entListaBase.PListaBaseNombre = txtNombreLista.Text
                    entListaBase.PVigenciaInicio = dttFechaInicio.Text
                    entListaBase.PVigenciaFin = dttFechaFin.Text

                    objListaBu.EditarListaBase(entListaBase, "")

                    txtNombreLista.Enabled = False
                    lblNombreLista.Enabled = False
                    dttFechaInicio.Enabled = False
                    lblFechaInicio.Enabled = False
                    dttFechaFin.Enabled = False
                    lblFechaFin.Enabled = False

                    btnGuardarLista.Enabled = False
                    lblGuardarLista.Enabled = False
                    btnCancelarCambiosLista.Enabled = False
                    lblCancelarCambioLista.Enabled = False
                    btnEditarDatosLista.Enabled = True
                    lblEditarLista.Enabled = True
                    Dim objMensajeExito As New Tools.ExitoForm
                    objMensajeExito.mensaje = "Registro correcto"
                    objMensajeExito.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub chkModelosConPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkModelosConPrecio.CheckedChanged
        If btnEditar.Enabled = True Then
            Dim objMAlert As New Tools.AdvertenciaForm
            objMAlert.mensaje = "Recuerde que al cambiar los filtros se "
        End If
        llenarListaDeModelos()
    End Sub

    Private Sub chkCargarModelosSinPrecio_CheckedChanged(sender As Object, e As EventArgs) Handles chkCargarModelosSinPrecio.CheckedChanged
        llenarListaDeModelos()
    End Sub

    Private Sub chkEstatusActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstatusActivo.CheckedChanged
        llenarListaDeModelos()
    End Sub

    Private Sub chkDescontinuados_CheckedChanged(sender As Object, e As EventArgs) Handles chkDescontinuados.CheckedChanged
        llenarListaDeModelos()
    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        For Each rowGr As UltraGridRow In grdDatosProductos.Rows.GetFilteredInNonGroupByRows
            rowGr.Cells("Seleccion").Value = CBool(chkSeleccionarFiltrados.Checked)
        Next

        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdDatosProductos.Rows
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                contadorSeleccion += 1
            End If
        Next
        lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub grdDatosProductos_CellChange(sender As Object, e As CellEventArgs) Handles grdDatosProductos.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            If CBool(e.Cell.Text) = True Then
                lblTotalSeleccionados.Text = CInt(lblTotalSeleccionados.Text) + 1
            Else
                lblTotalSeleccionados.Text = CInt(lblTotalSeleccionados.Text) - 1
            End If
        End If

        ' ''If e.Cell.Column.Key = "Precio" And e.Cell.Row.Index <> grdDatosProductos.Rows.FilterRow.Index Then
        ' ''    Dim contadorPrecio As Int32 = 0
        ' ''    For Each rowGR As UltraGridRow In grdDatosProductos.Rows
        ' ''        If (rowGR.Cells("Precio").Text.Replace("_", "")).Replace("$", "") <> "." And (rowGR.Cells("Precio").Text.Replace("_", "")).Replace("$", "") <> "" Then
        ' ''            If CDbl((rowGR.Cells("Precio").Text.Replace("_", "")).Replace("$", "")) > 0 Then
        ' ''                contadorPrecio += 1
        ' ''            End If
        ' ''        End If
        ' ''    Next
        ' ''    lblArticulosConPrecio.Text = contadorPrecio.ToString("N0")
        ' ''End If

    End Sub

    Private Sub grdDatosProductos_Error(sender As Object, e As ErrorEventArgs) Handles grdDatosProductos.Error
        If grdDatosProductos.ActiveRow.Index Mod 2 = 0 Then
            grdDatosProductos.ActiveRow.Appearance.BackColor = Color.White
        Else
            grdDatosProductos.ActiveRow.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub

    Private Sub grdDatosProductos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdDatosProductos.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.Key = "Precio" Then
                If e.NewValue.ToString = "" Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub pnlEstado_Paint(sender As Object, e As PaintEventArgs) Handles pnlEstado.Paint

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlGrups.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlGrups.Visible = True
    End Sub

    Private Sub grdDatosProductos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatosProductos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdDatosProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDatosProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdDatosProductos.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdDatosProductos.DisplayLayout.Bands(0)
            If grdDatosProductos.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdDatosProductos.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdDatosProductos.ActiveCell = nextRow.Cells(grdDatosProductos.ActiveCell.Column)
                e.Handled = True
                grdDatosProductos.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub txtPrecioMultiple_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioMultiple.KeyDown
        If e.KeyCode = Keys.Enter Then
            asignarPrecios()
        End If
    End Sub

    Private Sub grdDatosProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdDatosProductos.InitializeRow
        If CBool(e.Row.Cells("marc_decimales").Value) = False Then
            e.Row.Cells("Precio").Style = ColumnStyle.Integer
        Else
            e.Row.Cells("Precio").Style = ColumnStyle.Double
        End If
    End Sub

    Private Sub chkVerPrecioOriginal_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerPrecioOriginal.CheckedChanged
        If chkVerPrecioOriginal.Checked = True Then
            grdDatosProductos.DisplayLayout.Bands(0).Columns("PrecioAnterior").Hidden = False
        Else
            grdDatosProductos.DisplayLayout.Bands(0).Columns("PrecioAnterior").Hidden = True
        End If
    End Sub
End Class