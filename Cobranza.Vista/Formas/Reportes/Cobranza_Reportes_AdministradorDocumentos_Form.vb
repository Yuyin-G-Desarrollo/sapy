Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports System.Net
Imports System.Windows.Forms
Imports System.Drawing
Imports ColumnStyle = Infragistics.Win.UltraWinGrid.ColumnStyle
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.Data

Public Class Cobranza_Reportes_AdministradorDocumentos_Form

    Dim listInicial As New List(Of String)
    Dim ListaColumnasGrid As New List(Of String)
    Dim objBU As New Negocios.ConsultaDocumentosBU
    Dim DTEncabezadoCobertura As DataTable

    Dim emptyEditor As RepositoryItemPictureEdit
    Public enter As Boolean = False

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportes

        listado.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(2).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listaParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        bgvReporte.Columns.Clear()
        grdClientes.DataSource = listInicial
        dtpFechaFin.Value = Date.Now.ToString
        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"
        chkCancelado.Checked = False
        chkCXC.Checked = True
        chkSinSaldo.Checked = True
        btnAbajo_Click(sender, e)
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
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

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReporte.DataRowCount > 0 Then

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

                        If bgvReporte.GroupCount > 0 Then
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            'grdReporte.ExportToXlsx()

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()

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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim datos As New DataTable
        Dim objBU As New Negocios.ConsultaDocumentosBU
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Try
            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                dtpFechaInicio.Focus()
                Exit Sub
            End If

            grdReporte.DataSource = Nothing
            bgvReporte.Columns.Clear()

            Cursor = Cursors.WaitCursor
            pnPBar.Visible = True
            lblInfo.Text = "Ejecutando consulta, espere un momento por favor..."
            pBar.Minimum = 0
            pBar.ForeColor = Color.Blue
            System.Windows.Forms.Application.DoEvents()
            datos = objBU.ConsultaDocumentos(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, obtenerFiltros(grdClientes, "IdSICY"), CheckboxSeleccionados(), UsuarioID)

            If Not IsNothing(datos) Then
                If datos.Rows.Count > 0 Then
                    Dim Total As Integer = datos.Rows.Count
                    Dim Cont As Integer = 0
                    grdReporte.DataSource = datos
                    pBar.Maximum = Total

                    DiseñoGrid()
                    lblFechaUltimaActualización.Text = Date.Now.ToString
                    btnArriba_Click(Nothing, Nothing)
                    System.Windows.Forms.Application.DoEvents()
                    lblNumFiltrados.Text = CDbl(bgvReporte.RowCount.ToString()).ToString("n0")
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
        End Try
    End Sub

    Private Function obtenerFiltros(grid As UltraGrid, columna As String) As String
        Dim filtro As String = ""

        For Each Row As UltraGridRow In grid.Rows
            If filtro <> "" Then
                filtro += ","
            End If
            filtro += Row.Cells(columna).Value.ToString()
        Next
        Return filtro
    End Function

    Private Function CheckboxSeleccionados()
        Dim filtro As String = ""
        If chkCXC.Checked = True Then
            filtro += "CXC"
        End If

        If chkSinSaldo.Checked = True Then
            If filtro.Length > 0 Then
                filtro += ",PAGADO"
            Else
                filtro += "PAGADO"
            End If
        End If

        If chkCancelado.Checked = True Then
            If filtro.Length > 0 Then
                filtro += ",Cancelado"
            Else
                filtro += "Cancelado"
            End If

        End If
        Return filtro
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

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs)
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_SayWeb_EstadisticaVentasGeneral.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_SayWeb_EstadisticaVentasGeneral.pdf")
        Catch ex As Exception
        End Try

    End Sub

    Public Sub DiseñoGrid()
        bgvReporte.OptionsView.ColumnAutoWidth = False
        Dim editor As New RepositoryItemTextEdit
        'editor = (RepositoryItemTextEdit)grdReporte.RepositoryItems.Add("TextEdit")
        editor.CharacterCasing = CharacterCasing.Upper


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If col.FieldName.Equals("ObservacionesCobranza") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CBRNZA_CONSULTA_DOCS", "EDICION_OBSERVACIONES_COBRANZA") Then
                col.OptionsColumn.AllowEdit = True
                col.ColumnEdit = editor
            Else
                col.OptionsColumn.AllowEdit = False
            End If
        Next
        'bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        'bgvReporte.Columns.ColumnByFieldName("status_id").Visible = False
        bgvReporte.Columns.ColumnByFieldName(" ").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True


        bgvReporte.Columns.ColumnByFieldName("Agte").Fixed = Columns.FixedStyle.Left
        'bgvReporte.Columns.ColumnByFieldName("MarcaDocV").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("ClienteID").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("Cliente").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("IdDoctoSAY").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("IdRemision").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("Año").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("Serie").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("IdFactura").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("Orden").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("FDocumento").Fixed = Columns.FixedStyle.Left
        bgvReporte.Columns.ColumnByFieldName("NotasCredito").Fixed = Columns.FixedStyle.Left

        bgvReporte.Columns.ColumnByFieldName("NotasCredito").Caption = "Notas Crédito"

        bgvReporte.Columns.ColumnByFieldName("IdDoctoSAY").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("IdRemision").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("TotalDocumento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        'NUEVOS'
        bgvReporte.Columns.ColumnByFieldName("DcDOC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("DcCxC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("Imp Dc CxC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("PRP").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvReporte.Columns.ColumnByFieldName("DcDOC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("DcCxC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("Imp Dc CxC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("PRP").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvReporte.Columns.ColumnByFieldName("DcDOC").DisplayFormat.FormatString = "{0:0.00}%"
        bgvReporte.Columns.ColumnByFieldName("DcCxC").DisplayFormat.FormatString = "{0:0.00}%"
        bgvReporte.Columns.ColumnByFieldName("PRP").DisplayFormat.FormatString = "N0"

        bgvReporte.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways
        bgvReporte.OptionsView.ShowFooter = True
        bgvReporte.OptionsBehavior.SummariesIgnoreNullValues = True
        Dim caca = bgvReporte.Columns("PRP").SummaryItem
        caca.FieldName = "PRP"
        caca.SummaryType = SummaryItemType.Custom
        caca.DisplayFormat = "{0:0.00}"

        'TERMINA'

        bgvReporte.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("Plazo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("DV").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("DXV").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvReporte.Columns.ColumnByFieldName("FDocumento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvReporte.Columns.ColumnByFieldName("FVence").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvReporte.Columns.ColumnByFieldName("FVigenciaAPartir").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvReporte.Columns.ColumnByFieldName("FVigenciaNuevo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        bgvReporte.Columns.ColumnByFieldName("Año").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("Pares").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("Plazo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("Vencido").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("DV").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("DXV").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("PlazoNuevo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("FolioSustituye").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("FolioRelacionado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("NotasCredito").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvReporte.Columns.ColumnByFieldName("MotivoCambioVencimiento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals



        bgvReporte.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("IdDoctoSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("IdRemision").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("Serie").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("IdFactura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("Orden").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FDocumento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("Status").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("TotalDocumento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("Saldo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FVence").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FVigenciaAPartir").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FVigenciaNuevo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FCancel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("ObservacionesCobranza").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FolioSustituye").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("FolioRelacionado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("NotasCredito").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvReporte.Columns.ColumnByFieldName("MotivoCambioVencimiento").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains



        bgvReporte.Columns.ColumnByFieldName("Año").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("Plazo").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("DV").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("DXV").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("TotalDocumento").DisplayFormat.FormatString = "C2"
        bgvReporte.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatString = "C2"
        bgvReporte.Columns.ColumnByFieldName("Imp Dc CxC").DisplayFormat.FormatString = "C2"
        bgvReporte.Columns.ColumnByFieldName("DXV").DisplayFormat.FormatString = "N0"


        bgvReporte.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        '        bgvReporte.OptionsBehavior.Editable = False

        bgvReporte.Columns.ColumnByFieldName("FDocumento").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        bgvReporte.Columns.ColumnByFieldName("FVigenciaAPartir").DisplayFormat.FormatString = "dd/MM/yyyy"
        bgvReporte.Columns.ColumnByFieldName("FVigenciaNuevo").DisplayFormat.FormatString = "dd/MM/yyyy"
        bgvReporte.Columns.ColumnByFieldName("FVence").DisplayFormat.FormatString = "dd/MM/yyyy"

        bgvReporte.IndicatorWidth = 40

        bgvReporte.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(bgvReporte.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            bgvReporte.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("TotalDocumento").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalDocumento")) = True Then
            bgvReporte.Columns("TotalDocumento").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalDocumento", "{0:C2}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "TotalDocumento"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item2)
        End If

        If IsNothing(bgvReporte.Columns("Saldo").Summary.FirstOrDefault(Function(x) x.FieldName = "Saldo")) = True Then
            bgvReporte.Columns("Saldo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:C2}")
            Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item3.FieldName = "Saldo"
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item3.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item3)
        End If

        If IsNothing(bgvReporte.Columns("Imp Dc CxC").Summary.FirstOrDefault(Function(x) x.FieldName = "Imp Dc CxC")) = True Then
            bgvReporte.Columns("Imp Dc CxC").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Imp Dc CxC", "{0:C2}")
            Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item4.FieldName = "Imp Dc CxC"
            item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item4.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item4)
        End If


        bgvReporte.BestFitColumns()
        bgvReporte.Columns.ColumnByFieldName("Orden").Width = 100
    End Sub

    Private Sub Cobranza_Reportes_AdministradorDocumentos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtClientes As New DataTable
        Dim objBU As New Negocios.ConsultaDocumentosBU

        dtpFechaInicio.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        dtpFechaFin.Value = Date.Now
        Me.WindowState = FormWindowState.Maximized

        grdClientes.DataSource = listInicial

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

        Renglon = dtReportes.NewRow()
        Renglon("id") = 3
        Renglon("Descripcion") = "Mensual - Concentrado Total"
        dtReportes.Rows.Add(Renglon)

        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        pnPBar.Top = (Me.Height - pnPBar.Height) / 2

    End Sub

    Private Sub bgvReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvReporte_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles bgvReporte.RowCellStyle
        Dim Valor As String = String.Empty
        Dim estatus As String = String.Empty
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Vencido" Then
                e.Appearance.FontStyleDelta = FontStyle.Bold
                Valor = bgvReporte.GetRowCellValue(e.RowHandle, "Vencido").ToString.Trim.ToUpper

                If Valor.Equals("NO") Then
                    e.Appearance.ForeColor = Color.Green
                    e.Appearance.BackColor = Color.Transparent
                Else
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.BackColor = Color.Red
                End If
            End If

            If e.Column.FieldName = "NotasCredito" Then
                'e.Appearance.FontStyleDelta = FontStyle.Bold
                Valor = bgvReporte.GetRowCellValue(e.RowHandle, "NotasCredito").ToString.Trim.ToUpper

                If Valor.Equals("NO") Then
                    e.Appearance.ForeColor = Color.Black
                    e.Appearance.BackColor = Color.Transparent
                Else
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.BackColor = Color.Green
                End If

            End If

            estatus = bgvReporte.GetRowCellValue(e.RowHandle, "Status").ToString.Trim.ToUpper
            If estatus.Equals("CANCELADO") Then
                e.Appearance.ForeColor = Color.Red
                e.Appearance.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub bgvReporte_RowStyle(sender As Object, e As RowStyleEventArgs) Handles bgvReporte.RowStyle
        Dim Valor As String = String.Empty
        If e.RowHandle >= 0 Then
            Valor = bgvReporte.GetRowCellValue(e.RowHandle, "Status").ToString.Trim.ToUpper
            If Valor.Equals("CANCELADO") Then
                e.Appearance.ForeColor = Color.Red
                e.Appearance.BackColor = Color.Transparent
            End If
        End If
    End Sub

    Private Sub bgvReporte_KeyDown(sender As Object, e As KeyEventArgs) Handles bgvReporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            enter = True
        End If
    End Sub

    Private Sub bgvReporte_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles bgvReporte.CellValueChanged
        If enter = True Then
            Cursor = Cursors.WaitCursor
            Dim negocios As New Negocios.ConsultaDocumentosBU
            Dim observaciones As String = bgvReporte.GetRowCellValue(e.RowHandle, "ObservacionesCobranza")
            Dim idRemision As Integer = bgvReporte.GetRowCellValue(e.RowHandle, "IdRemision")
            Dim año As Integer = bgvReporte.GetRowCellValue(e.RowHandle, "Año")
            negocios.ActualizarObsevaciones(observaciones, idRemision, año)
            Cursor = Cursors.Default
            enter = False
        End If
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim Form As New Cobranza_AdministradorDocumentos_Detalles
        Dim NumeroFilas As Integer = bgvReporte.DataRowCount
        Dim DocumentoID As String = String.Empty
        Dim Año As String = String.Empty
        Dim ClienteSICYID As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvReporte.GetRowCellValue(bgvReporte.GetVisibleRowHandle(index), " ")) = True Or CBool(bgvReporte.IsRowSelected(bgvReporte.GetVisibleRowHandle(index))) = True Then

                    If DocumentoID = String.Empty Then
                        DocumentoID = bgvReporte.GetRowCellValue(bgvReporte.GetVisibleRowHandle(index), "IdRemision")
                        Año = bgvReporte.GetRowCellValue(bgvReporte.GetVisibleRowHandle(index), "Año")
                        ClienteSICYID = bgvReporte.GetRowCellValue(bgvReporte.GetVisibleRowHandle(index), "ClienteID")
                    End If
                End If
            Next

            If DocumentoID <> String.Empty Then
                Form.DocumentoID = DocumentoID
                Form.Año = Año
                Form.ClienteSICYID = ClienteSICYID
                Form.MdiParent = Me.MdiParent
                Form.Show()
            Else
                show_message("Advertencia", "No se ha seleccionado un documento.")
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub BgvReporte_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles bgvReporte.CustomSummaryCalculate
        Dim view As GridView = sender
        e.TotalValueReady = True
        If (e.SummaryProcess = CustomSummaryProcess.Finalize) Then
            e.TotalValue = CalcAverage(view, e.RowHandle)
        End If
    End Sub

    Private Function CalcAverage(view As GridView, eRowHandle As Integer)
        Dim sum As Decimal = 0
        Dim count As Integer = 0
        For index = 0 To bgvReporte.RowCount
            Dim value = CDec(bgvReporte.GetRowCellValue(index, "PRP"))
            If Not value = 0 Then
                count += 1
                sum += value
            End If
        Next

        Dim resultado = 0
        If Not count = 0 Then
            resultado = sum / count
        End If

        Return resultado
    End Function


End Class