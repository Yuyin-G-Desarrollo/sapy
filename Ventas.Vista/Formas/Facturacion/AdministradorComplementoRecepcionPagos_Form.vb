Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base

Public Class AdministradorComplementoRecepcionPagos_Form

#Region "VARIABLES GLOBALES"

    Dim lstInicial As New List(Of String)
    Dim lstFolioFactura As New List(Of String)
    Dim lstFolioCFDI As New List(Of String)
    Dim clientesSeleccionadosFiltro As String = String.Empty

    Dim dtDatosAdministradorSinDatosFacturas As New DataTable
    Dim dtDatosAdministradorConDatosFacturas As New DataTable

    Dim cliente_Filtro As String = String.Empty
    Dim RFCReceptor_Filtro As String = String.Empty
    Dim folioFactura_Filtro As String = String.Empty
    Dim folioCFDI_Filtro As String = String.Empty
    Dim razonSocialEmisor_Filtro As Integer = 0
    Dim estatusPago_Filtro As String = String.Empty
    Dim estatusCFDI_Filtro As Integer = 0
    Dim fechaInicioGeneracionCRP_Filtro As String = String.Empty
    Dim fechaFinGeneracionCRP_Filtro As String = String.Empty
    Dim idComplementosErrores As String = Nothing

    Dim CantidadComplementosSeleccionadosParaTimbrar As Integer = 0

    Dim IdComplementoPagoeleccionadoParaCancelar As Integer = 0
    Dim IdComplementosPagosSeleccionadosParaDescartar As String = String.Empty
    Dim IdComplementoPagoSeleccionadoParaTimbrar As String = String.Empty
    Dim IdComplementosPagosSeleccionadosParaEnviar As String = String.Empty

    Dim folioCRPSeleccionado As String = String.Empty
    Dim montoPagoSeleccionado As String = String.Empty
    Dim razonSocialClienteSeleccionado As String = String.Empty
    Dim fechaCRPSeleccionado As String = String.Empty
    Dim opcionCliente As String = Nothing
    Dim lstColumnasNoAgrupar As New List(Of String)

    Dim EsTimbrado As Integer = 0


#End Region

#Region "CARGA INICIAL DE DATOS"

    Private Sub AdministradorComplementoRecepcionPagos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtRazonesSociales As New DataTable
        Me.WindowState = FormWindowState.Maximized
        cmboxEstatusPago.SelectedIndex = 0
        cmbEstatusCFDI.SelectedIndex = 0
        grdCliente.DataSource = lstInicial
        grdRFC.DataSource = lstInicial
        grdFolioFactura.DataSource = lstInicial
        grdFolioCFDI.DataSource = lstInicial
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("COB_PAG_ADMIN_COMP_PAGOS", "VER_PAGOS_INTERNOS") Then
            opcionCliente = "Interno"
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("COB_PAG_ADMIN_COMP_PAGOS", "VER_PAGOS_EXTERNOS") Then
            opcionCliente = "Externo"
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("COB_PAG_ADMIN_COMP_PAGOS", "VER_PAGOS_INTERNOS_EXTERNOS") Then
            opcionCliente = "Ambos"
        End If
        cargaComboTipoCrp(opcionCliente)
        lstColumnasNoAgrupar.Add("Folio Factura")
        lstColumnasNoAgrupar.Add("Método de Pago")
        lstColumnasNoAgrupar.Add("F Factura")
        lstColumnasNoAgrupar.Add("Monto Original de la Factura")
        lstColumnasNoAgrupar.Add("Saldo Anterior")
        lstColumnasNoAgrupar.Add("Total Aplicado")
        lstColumnasNoAgrupar.Add("Saldo de la Factura")
        lstColumnasNoAgrupar.Add("No. Parcialidad")
        lstColumnasNoAgrupar.Add("Otros Pagos")
        lstColumnasNoAgrupar.Add("Saldo Final")

        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("COB_PAG_ADMIN_COMP_PAGOS", "ADMIN_PAGOS_CANCELAR_DESCARTAR") Then
            btnCancelarCRP.Visible = True
            lblTextoCancelar.Visible = True
            btnDescartar.Visible = True
            lblTextoDescartar.Visible = True
        Else
            btnCancelarCRP.Visible = False
            lblTextoCancelar.Visible = False
            btnDescartar.Visible = False
            lblTextoDescartar.Visible = False
        End If

        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        If (usuario = "MARIAA" Or usuario = "JGUERRERO") Then
            pnlTimbrarCoppel.Visible = True
            pnlPdf.Visible = True
        End If
    End Sub

#End Region

#Region "DISEÑO"

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

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub


    Private Sub grdRFC_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRFC.InitializeLayout
        grid_diseño(grdRFC)
        grdRFC.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Razón Social"
    End Sub

    Private Sub grdFolioFactura_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioFactura.InitializeLayout
        grid_diseño(grdFolioFactura)
        grdFolioFactura.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Factura"
    End Sub

    Private Sub grdFolioCFDI_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioCFDI.InitializeLayout
        grid_diseño(grdFolioCFDI)
        grdFolioCFDI.DisplayLayout.Bands(0).Columns(0).Header.Caption = "CFDI"
    End Sub


    Private Sub DiseñoGridDocumentos()
        bgvCFDI.OptionsView.ColumnAutoWidth = False


        If chboxVerFacturas.Checked = True Then
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCFDI.Columns
                If lstColumnasNoAgrupar.Contains(col.FieldName) = False Then
                    bgvCFDI.OptionsView.AllowCellMerge = True
                End If
            Next
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCFDI.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If col.FieldName <> " " And col.FieldName.Contains("XML") = False And col.FieldName.Contains("PDF") = False Then
                bgvCFDI.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowEdit = False
            End If
        Next

        bgvCFDI.Columns.ColumnByFieldName("RutaXML").Visible = False
        bgvCFDI.Columns.ColumnByFieldName("RutaPDF").Visible = False
        bgvCFDI.Columns.ColumnByFieldName("RutaXMLCancelacion").Visible = False
        bgvCFDI.Columns.ColumnByFieldName("RutaPDFCancelacion").Visible = False
        'bgvCFDI.Columns.ColumnByFieldName("Email").Visible = False

        bgvCFDI.Columns.ColumnByFieldName("#").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvCFDI.Columns.ColumnByFieldName("Monto Pago").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvCFDI.Columns.ColumnByFieldName("Fecha de Aplicación").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCFDI.Columns.ColumnByFieldName("Fecha de Timbrado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCFDI.Columns.ColumnByFieldName("F Pago").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCFDI.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        bgvCFDI.Columns.ColumnByFieldName("#").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvCFDI.Columns.ColumnByFieldName("Monto Pago").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvCFDI.Columns.ColumnByFieldName("Razón Social Receptor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        If CmBoxTipoCrp.Text = "CRP Cliente Externo" Then
            bgvCFDI.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvCFDI.Columns.ColumnByFieldName("Razón Social Emisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End If
        'bgvCFDI.Columns.ColumnByFieldName("Razón Social Emisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCFDI.Columns.ColumnByFieldName("Estatus").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCFDI.Columns.ColumnByFieldName("Folio").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvCFDI.Columns.ColumnByFieldName("#").DisplayFormat.FormatString = "N0"
        bgvCFDI.Columns.ColumnByFieldName("Monto Pago").DisplayFormat.FormatString = "N2"

        If chboxVerFacturas.Checked = False Then
            bgvCFDI.Columns.ColumnByFieldName(" ").Width = 30
        End If
        bgvCFDI.Columns.ColumnByFieldName("#").Width = 60
        bgvCFDI.Columns.ColumnByFieldName("Estatus").Width = 90
        If IsNothing(bgvCFDI.Columns.ColumnByFieldName("XML")) = False Then
            bgvCFDI.Columns.ColumnByFieldName("XML").Width = 30
        End If
        If IsNothing(bgvCFDI.Columns.ColumnByFieldName("PDF")) = False Then
            bgvCFDI.Columns.ColumnByFieldName("PDF").Width = 30
        End If
        bgvCFDI.Columns.ColumnByFieldName("Fecha de Aplicación").Width = 120
        bgvCFDI.Columns.ColumnByFieldName("Fecha de Timbrado").Width = 120
        bgvCFDI.Columns.ColumnByFieldName("Razón Social Receptor").Width = 270
        If CmBoxTipoCrp.Text = "CRP Cliente Externo" Then
            bgvCFDI.Columns.ColumnByFieldName("Cliente").Width = 270
            bgvCFDI.Columns.ColumnByFieldName("Razón Social Emisor").Width = 270
        End If

        bgvCFDI.Columns.ColumnByFieldName("Folio").Width = 80
        bgvCFDI.Columns.ColumnByFieldName("Monto Pago").Width = 100
        bgvCFDI.Columns.ColumnByFieldName("F Pago").Width = 80
        bgvCFDI.Columns.ColumnByFieldName("Forma Pago").Width = 250
        If IsNothing(bgvCFDI.Columns.ColumnByFieldName("XML Cancelación")) = False Then
            bgvCFDI.Columns.ColumnByFieldName("XML Cancelación").Width = 100
        End If
        If IsNothing(bgvCFDI.Columns.ColumnByFieldName("PDF Cancelación")) = False Then
            bgvCFDI.Columns.ColumnByFieldName("PDF Cancelación").Width = 100
        End If
        bgvCFDI.Columns.ColumnByFieldName("F Cancelación").Width = 120
        bgvCFDI.Columns.ColumnByFieldName("Motivo Cancelación").Width = 250
        bgvCFDI.Columns.ColumnByFieldName("Tipo Cancelacion").Width = 150



        bgvCFDI.Columns.ColumnByFieldName("F Pago").DisplayFormat.FormatString = "dd/MM/yyyy"
        bgvCFDI.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        bgvCFDI.Columns.ColumnByFieldName("Fecha de Aplicación").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        bgvCFDI.Columns.ColumnByFieldName("Fecha de Timbrado").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"


        If chboxVerFacturas.Checked Then
            bgvCFDI.Columns.ColumnByFieldName("Monto Original de la Factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvCFDI.Columns.ColumnByFieldName("Saldo Anterior").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvCFDI.Columns.ColumnByFieldName("Total Aplicado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvCFDI.Columns.ColumnByFieldName("Saldo de la Factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvCFDI.Columns.ColumnByFieldName("No. Parcialidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvCFDI.Columns.ColumnByFieldName("Otros Pagos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            If CmBoxTipoCrp.Text = "CRP Clientes Externos" Then
                bgvCFDI.Columns.ColumnByFieldName("Saldo Final").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            End If
            bgvCFDI.Columns.ColumnByFieldName("Monto Original de la Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            bgvCFDI.Columns.ColumnByFieldName("Saldo Anterior").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            bgvCFDI.Columns.ColumnByFieldName("Total Aplicado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            bgvCFDI.Columns.ColumnByFieldName("Saldo de la Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            bgvCFDI.Columns.ColumnByFieldName("No. Parcialidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            bgvCFDI.Columns.ColumnByFieldName("Otros Pagos").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            If CmBoxTipoCrp.Text = "CRP Clientes Externos" Then
                bgvCFDI.Columns.ColumnByFieldName("Saldo Final").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
            End If
            bgvCFDI.Columns.ColumnByFieldName("F Factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            bgvCFDI.Columns.ColumnByFieldName("F Factura").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            bgvCFDI.Columns.ColumnByFieldName("Folio Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            bgvCFDI.Columns.ColumnByFieldName("Monto Original de la Factura").DisplayFormat.FormatString = "N2"
            bgvCFDI.Columns.ColumnByFieldName("Saldo Anterior").DisplayFormat.FormatString = "N2"
            bgvCFDI.Columns.ColumnByFieldName("Total Aplicado").DisplayFormat.FormatString = "N2"
            bgvCFDI.Columns.ColumnByFieldName("Saldo de la Factura").DisplayFormat.FormatString = "N2"
            bgvCFDI.Columns.ColumnByFieldName("No. Parcialidad").DisplayFormat.FormatString = "N0"
            bgvCFDI.Columns.ColumnByFieldName("Otros Pagos").DisplayFormat.FormatString = "N2"
            If CmBoxTipoCrp.Text = "CRP Clientes Externos" Then
                bgvCFDI.Columns.ColumnByFieldName("Saldo Final").DisplayFormat.FormatString = "N2"
            End If
            bgvCFDI.Columns.ColumnByFieldName("Folio Factura").Width = 100
            bgvCFDI.Columns.ColumnByFieldName("Método de Pago").Width = 100
            bgvCFDI.Columns.ColumnByFieldName("F Factura").Width = 120
            bgvCFDI.Columns.ColumnByFieldName("Monto Original de la Factura").Width = 150
            bgvCFDI.Columns.ColumnByFieldName("Saldo Anterior").Width = 85
            bgvCFDI.Columns.ColumnByFieldName("Total Aplicado").Width = 75
            bgvCFDI.Columns.ColumnByFieldName("Saldo de la Factura").Width = 110
            bgvCFDI.Columns.ColumnByFieldName("No. Parcialidad").Width = 100
            bgvCFDI.Columns.ColumnByFieldName("Otros Pagos").Width = 80
            If CmBoxTipoCrp.Text = "CRP Clientes Externos" Then
                bgvCFDI.Columns.ColumnByFieldName("Saldo Final").Width = 110
            End If
            bgvCFDI.Columns.ColumnByFieldName("Folio Factura").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("Método de Pago").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("F Factura").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("Monto Original de la Factura").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("Saldo Anterior").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("Total Aplicado").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("Saldo de la Factura").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("No. Parcialidad").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            bgvCFDI.Columns.ColumnByFieldName("Otros Pagos").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            If CmBoxTipoCrp.Text = "CRP Clientes Externos" Then
                bgvCFDI.Columns.ColumnByFieldName("Saldo Final").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End If
        End If


        bgvCFDI.IndicatorWidth = 40

        bgvCFDI.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If chboxVerFacturas.Checked = False Then

            If IsNothing(bgvCFDI.Columns("Monto Pago").Summary.FirstOrDefault(Function(x) x.FieldName = "Monto Pago")) = True Then
                bgvCFDI.Columns("Monto Pago").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Monto Pago", "{0:N2}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = "Monto Pago"
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:N2}"
                bgvCFDI.GroupSummary.Add(item)
            End If

        End If

        If chboxVerFacturas.Checked Then

            If IsNothing(bgvCFDI.Columns("Total Aplicado").Summary.FirstOrDefault(Function(x) x.FieldName = "Total Aplicado")) = True Then
                bgvCFDI.Columns("Total Aplicado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Aplicado", "{0:N2}")
                Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
                item2.FieldName = "Total Aplicado"
                item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item2.DisplayFormat = "{0:N2}"
                bgvCFDI.GroupSummary.Add(item2)
            End If

        End If

    End Sub

    Public Sub AddGridColumnButton(ByVal FieldName As String)

        If bgvCFDI Is Nothing Then Exit Sub
        If bgvCFDI.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdCFDI.RepositoryItems.Add(_RIButton)

        bgvCFDI.Columns(FieldName).ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        bgvCFDI.Columns(FieldName).UnboundType = DevExpress.Data.UnboundColumnType.Object
        bgvCFDI.Columns(FieldName).ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Image = My.Resources._1373583708_10

        If FieldName = "XML" Or FieldName = "PDF" Then
            _RIButton.Buttons(0).Width = bgvCFDI.Columns(FieldName).Width - (bgvCFDI.Columns(FieldName).Width / 4)
        End If

        If FieldName = "XML Cancelación" Or FieldName = "PDF Cancelación" Then
            _RIButton.Buttons(0).Width = bgvCFDI.Columns(FieldName).Width - (bgvCFDI.Columns(FieldName).Width / 13)
        End If

        If FieldName = "XML" Then
            AddHandler _RIButton.ButtonClick, AddressOf ColumnaXML_Click
        End If
        If FieldName = "PDF" Then
            AddHandler _RIButton.ButtonClick, AddressOf ColumnaPDF_Click
        End If
        If FieldName = "XML Cancelación" Then
            AddHandler _RIButton.ButtonClick, AddressOf ColumnaXMLCancelacion_Click
        End If
        If FieldName = "PDF Cancelación" Then
            AddHandler _RIButton.ButtonClick, AddressOf ColumnaPDFCancelacion_Click
        End If

    End Sub

    Private Sub bgvCFDI_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvCFDI.RowStyle
        'If (e.RowHandle >= 0) Then
        '    If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus")) = False Then
        '        If bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus") = "POR TIMBRAR" Then
        '            e.Appearance.ForeColor = lblDiseñoPorTimbrar.ForeColor
        '        End If
        '    End If
        '    If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion")) = False Then
        '        If bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion") <> "" Then
        '            e.Appearance.ForeColor = lblDiseñoCancelado.ForeColor
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub bgvCFDI_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvCFDI.CustomDrawCell

        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Estatus" Then
                If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus")) = False Then
                    If bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus") = "POR TIMBRAR" Then
                        e.Appearance.ForeColor = lblDiseñoPorTimbrar.ForeColor
                    End If
                End If
                If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion")) = False Then
                    If bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion") <> "" Then
                        e.Appearance.ForeColor = lblDiseñoCancelado.ForeColor
                    End If
                End If
            End If
            If e.Column.FieldName = "Email" Then
                If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Email")) OrElse bgvCFDI.GetRowCellValue(e.RowHandle, "Email") = "" Then
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If chboxVerFacturas.Checked = True Then
                If lstColumnasNoAgrupar.Contains(e.Column.FieldName) Then
                    e.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If
        End If

    End Sub

#End Region

#Region "FILTROS"

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        Dim tipoCliente As String = Nothing
        If CmBoxTipoCrp.Text = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Falta seleccionar el tipo de cliente a mostrar.")
        Else
            If CmBoxTipoCrp.Text = "CRP Cliente Externo" Then
                listado.tipo_busqueda = 1
                listado.tipoCliente = "E"
            Else
                listado.tipo_busqueda = 1
                listado.tipoCliente = "I"
            End If

            Dim listaParametroID As New List(Of String)
            For Each row As UltraGridRow In grdCliente.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdCliente.DataSource = listado.listParametros
            With grdCliente
                If listado.tipoCliente = "I" Then '''''''' clientes internos
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                    '.DisplayLayout.Bands(0).Columns(3).Hidden = True
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente Interno"
                Else '''' clientes externos
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                    .DisplayLayout.Bands(0).Columns(3).Hidden = True
                    .DisplayLayout.Bands(0).Columns(4).Hidden = True
                    .DisplayLayout.Bands(0).Columns(5).Hidden = True
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
                End If

            End With
        End If
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = lstInicial
    End Sub

    Private Sub btnAgregarFiltroRFC_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroRFC.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        If CmBoxTipoCrp.Text = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Falta seleccionar el tipo de receptor a mostrar.")
        Else
            If CmBoxTipoCrp.Text = "CRP Cliente Externo" Then
                listado.tipoCliente = "E"
            Else
                listado.tipoCliente = "I"
            End If

            clientesSeleccionadosFiltro = ""
            If grdCliente.Rows.Count > 0 Then
                For Each row As UltraGridRow In grdCliente.Rows
                    If clientesSeleccionadosFiltro <> "" Then
                        clientesSeleccionadosFiltro += ","
                    End If
                    clientesSeleccionadosFiltro += row.Cells("Parametro").Value.ToString()
                Next
            End If

            listado.tipo_busqueda = 16
            listado.ClientesID = clientesSeleccionadosFiltro
            Dim listaParametroID As New List(Of String)
            For Each row As UltraGridRow In grdCliente.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdRFC.DataSource = listado.listParametros
            With grdRFC
                If listado.tipoCliente = "I" Then
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                    .DisplayLayout.Bands(0).Columns(3).Hidden = True
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Razón Social Interno"
                Else
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                    .DisplayLayout.Bands(0).Columns(3).Hidden = True
                    .DisplayLayout.Bands(0).Columns(4).Hidden = True
                    .DisplayLayout.Bands(0).Columns(5).Hidden = True
                    .DisplayLayout.Bands(0).Columns(6).Hidden = True
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Razón Social"
                End If
            End With
        End If
    End Sub

    Private Sub btnLimpiarFiltroRFC_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroRFC.Click
        grdRFC.DataSource = lstInicial
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdRFC_KeyDown(sender As Object, e As KeyEventArgs) Handles grdRFC.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdRFC.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFolioFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFolioCFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioCFDI.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioCFDI.DeleteSelectedRows(False)
    End Sub

    Private Sub txtFiltroFolioFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioFactura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioFactura.Text) Then Return

            lstFolioFactura.Add(txtFiltroFolioFactura.Text)
            grdFolioFactura.DataSource = Nothing
            grdFolioFactura.DataSource = lstFolioFactura

            txtFiltroFolioFactura.Text = String.Empty

        End If
    End Sub

    Private Sub txtFiltroFolioCFDI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioCFDI.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioCFDI.Text) Then Return

            lstFolioCFDI.Add(txtFiltroFolioCFDI.Text)
            grdFolioCFDI.DataSource = Nothing
            grdFolioCFDI.DataSource = lstFolioCFDI

            txtFiltroFolioCFDI.Text = String.Empty

        End If
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

#End Region

#Region "EJECUCIÓN CONSULTAS"

    Private Sub ejecutarConsultasAdministradorPagos()

        Dim objBU As New Negocios.AdministradorComplementoRecepcionPagosBU

        Cursor = Cursors.WaitCursor

        obtenerFiltroConsultaAdministrador()
        If CmBoxTipoCrp.Text = "CRP Cliente Externo" Then
            dtDatosAdministradorSinDatosFacturas = objBU.consultaAdministradorPagosSinDatosFactura(cliente_Filtro, RFCReceptor_Filtro, folioFactura_Filtro, folioCFDI_Filtro, razonSocialEmisor_Filtro, estatusPago_Filtro, estatusCFDI_Filtro, fechaInicioGeneracionCRP_Filtro, fechaFinGeneracionCRP_Filtro)
            dtDatosAdministradorConDatosFacturas = objBU.consultaAdministradorPagosConDatosFactura(cliente_Filtro, RFCReceptor_Filtro, folioFactura_Filtro, folioCFDI_Filtro, razonSocialEmisor_Filtro, estatusPago_Filtro, estatusCFDI_Filtro, fechaInicioGeneracionCRP_Filtro, fechaFinGeneracionCRP_Filtro)
        Else
            dtDatosAdministradorSinDatosFacturas = objBU.obtenerCRPPagosInternosSinFactura(cliente_Filtro, RFCReceptor_Filtro, folioFactura_Filtro, folioCFDI_Filtro, razonSocialEmisor_Filtro, estatusPago_Filtro, estatusCFDI_Filtro, fechaInicioGeneracionCRP_Filtro, fechaFinGeneracionCRP_Filtro)
            dtDatosAdministradorConDatosFacturas = objBU.obtenerCRPPagosInternosConFacturas(cliente_Filtro, RFCReceptor_Filtro, folioFactura_Filtro, folioCFDI_Filtro, razonSocialEmisor_Filtro, estatusPago_Filtro, estatusCFDI_Filtro, fechaInicioGeneracionCRP_Filtro, fechaFinGeneracionCRP_Filtro)
        End If

        If chboxVerFacturas.Checked Then
            grdCFDI.DataSource = Nothing
            bgvCFDI.Columns.Clear()
            grdCFDI.RepositoryItems.Clear()
            If dtDatosAdministradorConDatosFacturas.Rows.Count > 0 Then
                grdCFDI.DataSource = dtDatosAdministradorConDatosFacturas
                'AddGridColumnButton("XML")
                'AddGridColumnButton("PDF")
                'AddGridColumnButton("XML Cancelación")
                'AddGridColumnButton("PDF Cancelación")
                DiseñoGridDocumentos()
                lblTotalRegistros.Text = dtDatosAdministradorConDatosFacturas.Rows.Count.ToString()
            Else
                show_message("Aviso", "No hay datos para mostrar")
                lblTotalRegistros.Text = 0
            End If
        Else
            grdCFDI.DataSource = Nothing
            bgvCFDI.Columns.Clear()
            If dtDatosAdministradorSinDatosFacturas.Rows.Count > 0 Then
                grdCFDI.DataSource = dtDatosAdministradorSinDatosFacturas
                DiseñoGridDocumentos()
                grdCFDI.RepositoryItems.Clear()
                AddGridColumnButton("XML")
                AddGridColumnButton("PDF")
                AddGridColumnButton("XML Cancelación")
                AddGridColumnButton("PDF Cancelación")
                lblTotalRegistros.Text = dtDatosAdministradorSinDatosFacturas.Rows.Count.ToString()
            Else
                show_message("Aviso", "No hay datos para mostrar")
                lblTotalRegistros.Text = 0
            End If
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub obtenerFiltroConsultaAdministrador()

        cliente_Filtro = ""
        RFCReceptor_Filtro = ""
        folioFactura_Filtro = ""
        folioCFDI_Filtro = ""
        razonSocialEmisor_Filtro = 0
        estatusPago_Filtro = ""
        estatusCFDI_Filtro = 0
        fechaInicioGeneracionCRP_Filtro = ""
        fechaFinGeneracionCRP_Filtro = ""


        If grdCliente.Rows.Count > 0 Then
            For Each row As UltraGridRow In grdCliente.Rows
                If cliente_Filtro <> "" Then
                    cliente_Filtro += ","
                End If
                cliente_Filtro += row.Cells("Parametro").Value.ToString()
            Next
        End If

        If grdRFC.Rows.Count > 0 Then
            For Each row As UltraGridRow In grdRFC.Rows
                If RFCReceptor_Filtro <> "" Then
                    RFCReceptor_Filtro += ","
                End If
                RFCReceptor_Filtro += row.Cells("Parametro").Value.ToString()
            Next
        End If

        If grdFolioFactura.Rows.Count > 0 Then
            For Each row As UltraGridRow In grdFolioFactura.Rows
                If folioFactura_Filtro <> "" Then
                    folioFactura_Filtro += ","
                End If
                folioFactura_Filtro += row.Cells(0).Value.ToString()
            Next
        End If

        If grdFolioCFDI.Rows.Count > 0 Then
            For Each row As UltraGridRow In grdFolioCFDI.Rows
                If folioCFDI_Filtro <> "" Then
                    folioCFDI_Filtro += ","
                End If
                folioCFDI_Filtro += row.Cells(0).Value.ToString()
            Next
        End If

        If cmboxRazonSocial.SelectedIndex > 0 Then
            razonSocialEmisor_Filtro = cmboxRazonSocial.SelectedValue
        End If

        estatusPago_Filtro = cmboxEstatusPago.Text

        estatusCFDI_Filtro = cmbEstatusCFDI.SelectedIndex

        fechaInicioGeneracionCRP_Filtro = dtpFechaInicio.Value.ToShortDateString()
        fechaFinGeneracionCRP_Filtro = dtpFechaFin.Value.ToShortDateString()

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If CmBoxTipoCrp.Text = "" Then
            show_message("Aviso", "Falta seleccionar el tipo de cliente a mostrar")
        Else
            ejecutarConsultasAdministradorPagos()
            btnArriba_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub chboxVerFacturas_CheckedChanged(sender As Object, e As EventArgs) Handles chboxVerFacturas.CheckedChanged
        Cursor = Cursors.WaitCursor

        If chboxVerFacturas.Checked Then
            chboxSeleccionarTodo.Checked = False
            chboxSeleccionarTodo.Enabled = False
            grdCFDI.DataSource = Nothing
            bgvCFDI.Columns.Clear()
            grdCFDI.RepositoryItems.Clear()
            If dtDatosAdministradorConDatosFacturas.Rows.Count > 0 Then
                grdCFDI.DataSource = dtDatosAdministradorConDatosFacturas
                'AddGridColumnButton("XML")
                'AddGridColumnButton("PDF")
                'AddGridColumnButton("XML Cancelación")
                'AddGridColumnButton("PDF Cancelación")
                DiseñoGridDocumentos()
                lblTotalRegistros.Text = dtDatosAdministradorConDatosFacturas.Rows.Count.ToString()
            End If
        Else
            chboxSeleccionarTodo.Enabled = True
            grdCFDI.DataSource = Nothing
            bgvCFDI.Columns.Clear()
            grdCFDI.RepositoryItems.Clear()
            If dtDatosAdministradorSinDatosFacturas.Rows.Count > 0 Then
                grdCFDI.DataSource = dtDatosAdministradorSinDatosFacturas
                DiseñoGridDocumentos()
                AddGridColumnButton("XML")
                AddGridColumnButton("PDF")
                AddGridColumnButton("XML Cancelación")
                AddGridColumnButton("PDF Cancelación")
                lblTotalRegistros.Text = dtDatosAdministradorSinDatosFacturas.Rows.Count.ToString()
            End If
        End If

        Cursor = Cursors.Default

    End Sub

#End Region

#Region "OTRAS FUNCIONES"

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
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


        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvCFDI.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                bgvCFDI.SetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 181
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub bgvCFDI_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvCFDI.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub ColumnaXML_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

        DescargarArchivoComplementoPago("RutaXML")

    End Sub

    Private Sub ColumnaPDF_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

        DescargarArchivoComplementoPago("RutaPDF")

    End Sub

    Private Sub ColumnaXMLCancelacion_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

        DescargarArchivoComplementoPago("RutaXMLCancelacion")

    End Sub

    Private Sub ColumnaPDFCancelacion_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

        DescargarArchivoComplementoPago("RutaPDFCancelacion")

    End Sub

    Private Sub DescargarArchivoComplementoPago(ByVal tipoArchivo As String)
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvCFDI.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If bgvCFDI.IsRowSelected(bgvCFDI.GetVisibleRowHandle(index)) Then
                    'MessageBox.Show(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), tipoArchivo))
                    Process.Start(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), tipoArchivo))
                End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub bgvCFDI_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles bgvCFDI.CustomRowCellEdit
        If (e.Column.FieldName = "XML" Or e.Column.FieldName = "PDF") And bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus") = "POR TIMBRAR" Then
            Dim editor As New RepositoryItemButtonEdit
            editor.Assign(e.RepositoryItem)
            editor.Buttons(0).Visible = False
            e.RepositoryItem = editor

        End If
        If (e.Column.FieldName = "XML Cancelación" Or e.Column.FieldName = "PDF Cancelación") And bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion") = "" Then
            Dim editor As New RepositoryItemButtonEdit
            editor.Assign(e.RepositoryItem)
            editor.Buttons(0).Visible = False
            e.RepositoryItem = editor

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCliente.DataSource = lstInicial
        grdCFDI.DataSource = Nothing
        bgvCFDI.Columns.Clear()
        grdRFC.DataSource = lstInicial
        grdFolioFactura.DataSource = lstInicial
        grdFolioCFDI.DataSource = lstInicial
        cmboxRazonSocial.SelectedIndex = 0
        cmboxEstatusPago.SelectedIndex = 0
        cmbEstatusCFDI.SelectedIndex = 0
        chboxVerFacturas.Checked = False
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        ''CmBoxTipoCrp.Text = Nothing
        lblTotalRegistros.Text = 0
    End Sub

    Public Sub ActualizarAdministradorCRP()

        btnMostrar_Click(Nothing, Nothing)

    End Sub


#End Region

#Region "EXPORTACIÓN EXCEL"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvCFDI.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty

            Try

                If Not chboxVerFacturas.Checked Then
                    bgvCFDI.Columns.ColumnByFieldName(" ").Visible = False
                    bgvCFDI.Columns.ColumnByFieldName("XML").Visible = False
                    bgvCFDI.Columns.ColumnByFieldName("PDF").Visible = False
                    bgvCFDI.Columns.ColumnByFieldName("XML Cancelación").Visible = False
                    bgvCFDI.Columns.ColumnByFieldName("PDF Cancelación").Visible = False
                End If

                nombreReporte = "\AdministradorComplementoRecepcionPagos_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvCFDI.GroupCount > 0 Then
                            bgvCFDI.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell


                            grdCFDI.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

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

        If Not chboxVerFacturas.Checked Then
            bgvCFDI.Columns.ColumnByFieldName(" ").Visible = True
            bgvCFDI.Columns.ColumnByFieldName("XML").Visible = True
            bgvCFDI.Columns.ColumnByFieldName("PDF").Visible = True
            bgvCFDI.Columns.ColumnByFieldName("XML Cancelación").Visible = True
            bgvCFDI.Columns.ColumnByFieldName("PDF Cancelación").Visible = True
        End If

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try

            If (e.RowHandle >= 0) Then
                If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus")) = False Then
                    If bgvCFDI.GetRowCellValue(e.RowHandle, "Estatus") = "POR TIMBRAR" Then
                        e.Formatting.Font.Color = lblDiseñoPorTimbrar.ForeColor
                    End If
                End If
                If IsDBNull(bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion")) = False Then
                    If bgvCFDI.GetRowCellValue(e.RowHandle, "Tipo Cancelacion") <> "" Then
                        e.Formatting.Font.Color = lblDiseñoCancelado.ForeColor
                    End If
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

#End Region


#Region "CANCELAR"

    Private Sub btnCancelarCRP_Click(sender As Object, e As EventArgs) Handles btnCancelarCRP.Click
        obtenerDocumentoSeleccionado(1)
        If IdComplementoPagoeleccionadoParaCancelar > 0 Then
            Dim ventanaCancelacion As New CancelacionComplementoRecepcionPagos_Form
            ventanaCancelacion.idComplementoPago = IdComplementoPagoeleccionadoParaCancelar
            ventanaCancelacion.folioCRP = folioCRPSeleccionado
            ventanaCancelacion.montoPago = montoPagoSeleccionado
            ventanaCancelacion.razonSocialCliente = razonSocialClienteSeleccionado
            ventanaCancelacion.fechaCRP = fechaCRPSeleccionado
            ventanaCancelacion.ventanaAdministradorCRP = Me
            ventanaCancelacion.ShowDialog()
        End If
    End Sub

    Private Sub obtenerDocumentoSeleccionado(ByVal TipoOperacion As Integer)

        'TipoOperacion: 1 = Cancelación
        '               2 = Descartar
        '               3 = Timbrado
        '               4 = Enviar Correo

        Dim ObjBUCancelacion As New Negocios.CancelacionDocumentosBU

        IdComplementoPagoeleccionadoParaCancelar = 0
        IdComplementosPagosSeleccionadosParaDescartar = ""
        IdComplementosPagosSeleccionadosParaEnviar = ""
        Dim NumeroFilas As Integer
        Dim FilasSeleccionadasCancelacion As Integer = 0
        Dim FilasSeleccionadasNoCancelables As Integer = 0
        Dim FilasSeleccionadasDescartar As Integer = 0
        Dim FilasSeleccionadasNoDescartables As Integer = 0
        Dim FilasSeleccionadasEnviar As Integer = 0
        Dim FilasSeleccionadasNoEnviar As Integer = 0

        folioCRPSeleccionado = String.Empty
        montoPagoSeleccionado = String.Empty
        razonSocialClienteSeleccionado = String.Empty
        fechaCRPSeleccionado = String.Empty

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = bgvCFDI.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), " ")) = True Then

                    If TipoOperacion = 1 Then
                        FilasSeleccionadasCancelacion += 1

                        folioCRPSeleccionado = bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Folio")
                        montoPagoSeleccionado = Double.Parse(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Monto Pago").ToString()).ToString("N2")
                        razonSocialClienteSeleccionado = bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Razón Social Receptor")
                        fechaCRPSeleccionado = Date.Parse(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Fecha de Aplicación")).ToShortDateString

                        If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Motivo Cancelación")) = False Then
                            If bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Motivo Cancelación") <> "" Then
                                FilasSeleccionadasNoCancelables += 1
                            End If
                        End If

                        IdComplementoPagoeleccionadoParaCancelar = bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#")

                    End If
                    If TipoOperacion = 2 Or TipoOperacion = 3 Or TipoOperacion = 4 Then
                        FilasSeleccionadasDescartar += 1

                        If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Estatus")) = False Then
                            If bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Estatus") <> "POR TIMBRAR" Then
                                FilasSeleccionadasNoDescartables += 1
                                FilasSeleccionadasEnviar += 1
                            Else
                                FilasSeleccionadasNoEnviar += 1
                            End If
                        End If
                        If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Motivo Cancelación")) = False Then
                            If bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Motivo Cancelación") <> "" Then
                                FilasSeleccionadasNoDescartables += 1
                            End If
                        End If

                        If TipoOperacion = 2 Then
                            If IdComplementosPagosSeleccionadosParaDescartar <> "" Then
                                IdComplementosPagosSeleccionadosParaDescartar += ","
                            End If

                            IdComplementosPagosSeleccionadosParaDescartar += Integer.Parse(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#")).ToString()
                        ElseIf TipoOperacion = 3 Then
                            IdComplementoPagoSeleccionadoParaTimbrar = bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#")
                        Else
                            If IdComplementosPagosSeleccionadosParaEnviar <> "" Then
                                IdComplementosPagosSeleccionadosParaEnviar += ","
                            End If

                            IdComplementosPagosSeleccionadosParaEnviar += Integer.Parse(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#")).ToString()

                        End If



                    End If
                End If
            Next

            If TipoOperacion = 1 Then

                If FilasSeleccionadasCancelacion = 0 Then
                    show_message("Advertencia", "Debe seleccionar un complemento para cancelar.")
                    IdComplementoPagoeleccionadoParaCancelar = 0
                    Cursor = Cursors.Default

                    Exit Sub
                End If

                If FilasSeleccionadasCancelacion > 1 Then
                    show_message("Advertencia", "Solo se puede cancelar un complemento a la vez.")
                    IdComplementoPagoeleccionadoParaCancelar = 0
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                If FilasSeleccionadasNoCancelables > 0 Then
                    show_message("Advertencia", "Solo se pueden cancelar complementos no cancelados anteriormente.")
                    IdComplementoPagoeleccionadoParaCancelar = 0
                    Cursor = Cursors.Default
                    Exit Sub
                End If

            End If

            If TipoOperacion = 2 Or TipoOperacion = 3 Then

                If TipoOperacion = 3 Then
                    If FilasSeleccionadasDescartar > 1 Then
                        show_message("Advertencia", "Solo se puede timbrar un complemento a la vez.")
                        IdComplementoPagoSeleccionadoParaTimbrar = 0
                        Cursor = Cursors.Default

                        Exit Sub
                    End If
                End If

                If FilasSeleccionadasDescartar = 0 Then
                    If TipoOperacion = 2 Then
                        show_message("Advertencia", "Debe seleccionar un complemento para descartar.")
                        IdComplementosPagosSeleccionadosParaDescartar = ""
                    Else
                        show_message("Advertencia", "Debe seleccionar un complemento para timbrar.")
                        IdComplementoPagoSeleccionadoParaTimbrar = 0
                    End If
                    Cursor = Cursors.Default

                    Exit Sub
                End If

                If FilasSeleccionadasNoDescartables > 0 Then
                    If TipoOperacion = 2 Then
                        show_message("Advertencia", "Solo se pueden descartar complementos en estatus ""POR TIMBRAR"" ")
                        IdComplementosPagosSeleccionadosParaDescartar = ""
                    Else
                        show_message("Advertencia", "Solo se pueden timbrar complementos en estatus ""POR TIMBRAR"" ")
                        IdComplementoPagoSeleccionadoParaTimbrar = 0
                    End If
                    Cursor = Cursors.Default
                    Exit Sub
                End If

            End If


            If TipoOperacion = 4 Then
                If FilasSeleccionadasEnviar = 0 And FilasSeleccionadasNoEnviar = 0 Then
                    show_message("Advertencia", "Debe seleccionar al menos un complemento para enviar.")
                    IdComplementosPagosSeleccionadosParaEnviar = ""
                ElseIf FilasSeleccionadasNoEnviar > 0 Then
                    show_message("Advertencia", "Solo se pueden enviar complementos timbrados.")
                    IdComplementosPagosSeleccionadosParaEnviar = ""
                End If
            End If


        Catch

            show_message("Error", "Ocurrio un error al seleccionar el complemento. Por favor intente de nuevo")

        End Try

        Cursor = Cursors.Default

    End Sub

    Private Sub obtenerVariosDocumentosTimbrado()
        Dim NumeroFilas As Integer
        Dim FilasSeleccionadasNoTimbrar As Integer = 0
        CantidadComplementosSeleccionadosParaTimbrar = 0
        IdComplementoPagoSeleccionadoParaTimbrar = ""
        idComplementosErrores = ""
        Dim idcomplemento As Integer = 0
        Dim objConsultar As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtResultadoDetallesTimbrado As New DataTable
        NumeroFilas = bgvCFDI.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), " ")) = True Then


                If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Estatus")) = False Then
                    If bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Estatus") <> "POR TIMBRAR" Then
                        show_message("Advertencia", "Solo se pueden timbrar complementos en estatus ""POR TIMBRAR"" ")
                        IdComplementoPagoSeleccionadoParaTimbrar = ""

                        Exit Sub
                    Else
                        idcomplemento = Integer.Parse(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#"))
                        dtResultadoDetallesTimbrado = objConsultar.ConsultarComplementosDetallesInternosTimbrar(idcomplemento)
                        If dtResultadoDetallesTimbrado.Rows.Count > 0 Then
                            If IdComplementoPagoSeleccionadoParaTimbrar <> "" Then
                                IdComplementoPagoSeleccionadoParaTimbrar += ","
                            End If
                            IdComplementoPagoSeleccionadoParaTimbrar += idcomplemento.ToString()
                        Else
                            If idComplementosErrores <> "" Then
                                idComplementosErrores += ","
                            End If
                            idComplementosErrores += idcomplemento.ToString()
                        End If

                        CantidadComplementosSeleccionadosParaTimbrar += 1
                    End If
                End If
            End If
        Next

    End Sub

#End Region

    Private Sub btnDescartar_Click(sender As Object, e As EventArgs) Handles btnDescartar.Click

        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtResultadoDescartar As New DataTable
        Dim confirmacion As New Tools.ConfirmarForm
        Cursor = Cursors.WaitCursor

        obtenerDocumentoSeleccionado(2)
        If IdComplementosPagosSeleccionadosParaDescartar <> "" Then
            confirmacion.mensaje = "Se descartarán los complementos seleccionados, esta acción no puede revertirse. ¿Desea continuar?"
            If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dtResultadoDescartar = objBu.descartarComplementoPago(IdComplementosPagosSeleccionadosParaDescartar)

                show_message(dtResultadoDescartar.Rows(0).Item("Resultado").ToString(), dtResultadoDescartar.Rows(0).Item("Mensaje").ToString())

                btnMostrar_Click(Nothing, Nothing)

            End If
        End If
        Cursor = Cursors.Default

    End Sub

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click

        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtResultadoGenerarDatosTimbrado As New DataTable
        Dim confirmacion As New Tools.ConfirmarForm

        Dim complementosConError As String = String.Empty

        Try

            'obtenerDocumentoSeleccionado(3)
            obtenerVariosDocumentosTimbrado()

            If IdComplementoPagoSeleccionadoParaTimbrar <> "" Or idComplementosErrores <> "" Then

                If CantidadComplementosSeleccionadosParaTimbrar > 1 Then
                    confirmacion.mensaje = "Se timbrarán " + CantidadComplementosSeleccionadosParaTimbrar.ToString() + " complementos. ¿Desea continuar?"
                Else
                    confirmacion.mensaje = "Se timbrará el complemento #" + IdComplementoPagoSeleccionadoParaTimbrar.ToString() + ". ¿Desea continuar?"
                End If

                If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor

                    If IdComplementoPagoSeleccionadoParaTimbrar <> "" Then
                        If CmBoxTipoCrp.Text = "CRP Cliente Externo" Then
                            dtResultadoGenerarDatosTimbrado = objBu.generarDatosTimbrarVariosComplementos(IdComplementoPagoSeleccionadoParaTimbrar)
                        Else
                            dtResultadoGenerarDatosTimbrado = objBu.generarDatosPagosInternosTimbrarVariosComplementos(IdComplementoPagoSeleccionadoParaTimbrar)
                        End If
                    End If

                    If dtResultadoGenerarDatosTimbrado.Rows.Count > 0 Then
                        Dim resultado As String = String.Empty
                        Dim mensaje As String = String.Empty
                        Dim idEmpresa As Integer
                        Dim objComplemento As Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                        Dim idComplemento As Integer = 0

                        For Each row As DataRow In dtResultadoGenerarDatosTimbrado.Rows


                            resultado = row.Item("ResultadoTimbrado").ToString()
                            mensaje = row.Item("MensajeTimbrado").ToString()

                            If resultado = "Exito" Then
                                idEmpresa = CInt(row.Item("IdEmpresa"))
                                'idEmpresa = 19
                                idComplemento = CInt(row.Item("ComplementoId"))
                                objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                                objComplemento.FolioComplementoPago(idComplemento, idEmpresa) 'idEmpresa
                                Dim aviso As String = objComplemento.Aviso
                                Dim respuesta As Int16 = objComplemento.Respuesta
                                If respuesta = 1 Then
                                    aviso = ""
                                    respuesta = 0
                                    objComplemento.CopiarDocumento()
                                    aviso = objComplemento.Aviso
                                    respuesta = objComplemento.Respuesta
                                    If respuesta = 1 Then
                                        'Process.Start(objtimbradoBU.RutaCliente)
                                        objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                                        objComplemento.GenerarPdfComplementoPago(idComplemento)
                                        respuesta = 0
                                        aviso = String.Empty
                                        respuesta = objComplemento.Respuesta
                                        aviso = objComplemento.Aviso
                                        If respuesta = 1 Then
                                            aviso = ""
                                            respuesta = 0
                                            objComplemento.CopiarDocumento()
                                            aviso = objComplemento.Aviso
                                            respuesta = objComplemento.Respuesta
                                            If respuesta = 1 Then
                                                EsTimbrado = 1
                                                'btnEnviarCorreo_Click(Nothing, Nothing)

                                                Dim ajusteBU As New Negocios.AdministrarComplementoPagoCompensacionBU
                                                Dim stCobros As String = String.Empty

                                                stCobros = ajusteBU.generarCobros(idComplemento)
                                                If stCobros <> "EXITO" Then
                                                    'show_message("Error", stCobros)
                                                    row.Item("ResultadoTimbrado") = "ERROR"
                                                    row.Item("MensajeTimbrado") = stCobros
                                                End If

                                                'show_message("Exito", aviso)
                                                row.Item("ResultadoTimbrado") = "EXITO"
                                                row.Item("MensajeTimbrado") = aviso
                                            Else
                                                'MsgBox(aviso)
                                                row.Item("MensajeTimbrado") = aviso
                                            End If
                                        Else
                                            'MsgBox(aviso)
                                            row.Item("MensajeTimbrado") = aviso
                                        End If
                                    Else
                                        'MsgBox(aviso)
                                        row.Item("MensajeTimbrado") = aviso
                                    End If
                                Else
                                    'MsgBox(aviso)
                                    complementosConError += aviso
                                    row.Item("MensajeTimbrado") = aviso
                                End If
                            Else
                                'show_message("Error", mensaje)
                                row.Item("ResultadoTimbrado") = "ERROR"
                                row.Item("MensajeTimbrado") = mensaje
                            End If

                            If row.Item("ResultadoTimbrado") = "EXITO" Then
                                If IdComplementosPagosSeleccionadosParaEnviar <> "" Then
                                    IdComplementosPagosSeleccionadosParaEnviar += ","
                                End If

                                IdComplementosPagosSeleccionadosParaEnviar += idComplemento.ToString()

                            ElseIf row.Item("ResultadoTimbrado") = "ERROR" Then

                                If complementosConError <> "" Then
                                    complementosConError += ","
                                End If

                                complementosConError += idComplemento.ToString()
                            End If

                        Next

                        If IdComplementosPagosSeleccionadosParaEnviar <> "" Then
                            EsTimbrado = 1
                            btnEnviarCorreo_Click(Nothing, Nothing)
                        End If

                        If idComplementosErrores <> "" Then
                            If complementosConError <> "" Then
                                complementosConError += ","
                            End If

                            complementosConError += idComplementosErrores
                        End If

                        If complementosConError = "" Then
                            show_message("Exito", "Se timbraron correctamente los complementos seleccionados")
                        Else
                            MostrarMensajeErrorTimbrado(complementosConError)
                        End If

                    Else
                        If idComplementosErrores <> "" Then
                            MostrarMensajeErrorTimbrado(idComplementosErrores)
                        Else
                            show_message("Error", "Ocurrió un error, intente de nuevo.")
                        End If

                    End If

                    EsTimbrado = 0
                    btnMostrar_Click(Nothing, Nothing)

                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub MostrarMensajeErrorTimbrado(ByVal IdErrores As String)
        If IdErrores.Contains(",") Then
            show_message("Error", "Ocurrió un error al timbrar los complementos #" + IdErrores + ". Intente de nuevo")
        Else
            show_message("Error", "Ocurrió un error al timbrar el complemento #" + IdErrores + ". Intente de nuevo")
        End If
    End Sub



    Private Sub bgvCFDI_CellMerge(ByVal sender As Object, ByVal e As CellMergeEventArgs) Handles bgvCFDI.CellMerge
        If (e.Column.FieldName <> "#") Then
            Dim view As GridView = CType(sender, GridView)
            Dim val1 As String = view.GetRowCellValue(e.RowHandle1, "#")
            Dim val2 As String = view.GetRowCellValue(e.RowHandle2, "#")
            e.Merge = (val1 = val2)
            e.Handled = True
        End If
    End Sub

    Private Sub btnDescargarArchivos_Click(sender As Object, e As EventArgs) Handles btnDescargarArchivos.Click
        Dim NumeroFilas As Integer = 0
        Dim PedidosMuestrasNegocios As New Ventas.Negocios.PedidosMuestrasBU
        Dim arreglo As New ArrayList
        Dim ListaInt As New List(Of Integer)
        Dim RutaXML As String = String.Empty
        Dim RutaPDF As String = String.Empty
        Dim RutaXMLCancelacion As String = String.Empty
        Dim RutaPDFCancelacion As String = String.Empty
        Dim ret As DialogResult
        Dim RutaSeleccionada As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvCFDI.DataRowCount
            If NumeroFilas <= 0 Then
                show_message("Advertencia", "No se encontraron registros en la vista.")
                Exit Sub
            End If

            If NumeroFilas > 0 Then
                For index As Integer = 0 To NumeroFilas Step 1
                    If bgvCFDI.GetRowCellValue(index, " ") Then
                        ListaInt.Add(index)
                    End If
                Next
            End If

            If ListaInt.Count <= 0 Then
                show_message("Advertencia", "Selecciona al menos un registro.")
                Exit Sub
            Else
                Dim folder As New FolderBrowserDialog

                With folder
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    ret = .ShowDialog
                    RutaSeleccionada = .SelectedPath
                End With
                If ret = Windows.Forms.DialogResult.OK Then
                    For Each index As Integer In ListaInt
                        RutaXML = bgvCFDI.GetRowCellValue(index, "RutaXML").trim.ToString()
                        RutaPDF = bgvCFDI.GetRowCellValue(index, "RutaPDF").trim.ToString()
                        RutaXMLCancelacion = bgvCFDI.GetRowCellValue(index, "RutaXMLCancelacion").trim.ToString()
                        RutaPDFCancelacion = bgvCFDI.GetRowCellValue(index, "RutaPDFCancelacion").trim.ToString()
                        If RutaXML <> "" Then
                            If System.IO.File.Exists(RutaXML) Then
                                DescargaArchivo(RutaSeleccionada, RutaXML)
                            End If
                        End If
                        If RutaPDF <> "" Then
                            If System.IO.File.Exists(RutaPDF) Then
                                DescargaArchivo(RutaSeleccionada, RutaPDF)
                            End If
                        End If
                        If RutaXMLCancelacion <> "" Then
                            If System.IO.File.Exists(RutaXMLCancelacion) Then
                                DescargaArchivo(RutaSeleccionada, RutaXMLCancelacion)
                            End If
                        End If
                        If RutaPDFCancelacion <> "" Then
                            If System.IO.File.Exists(RutaPDFCancelacion) Then
                                DescargaArchivo(RutaSeleccionada, RutaPDFCancelacion)
                            End If
                        End If

                    Next


                    show_message("Exito", "Se descargaron los archivos en la ruta " & RutaSeleccionada)


                    For index As Integer = 0 To NumeroFilas Step 1
                        bgvCFDI.SetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), " ", False)
                    Next


                End If
            End If

            'For index As Integer = 0 To NumeroFilas Step 1
            '    If bgvCFDI.GetRowCellValue(index, " ") Then
            '        ' ListaInt.Add(CInt(grdVpedidosMuestras.GetRowCellValue(index, "Folio")))


            '    End If
            'Next
            'If ListaInt.Count > 0 Then
            '    Dim objMensajeQ As New ConfirmarForm
            '    objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
            '    If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
            '        For Each index As Integer In ListaInt
            '            PedidosMuestrasNegocios.EditarEstatusPedidoMuestra(index, True)
            '        Next
            '        Dim mensaje As New ExitoForm
            '        mensaje.mensaje = "El registro se realizó con éxito."
            '        mensaje.ShowDialog()
            '        LlenarGridPedidosMuestras()
            '    Else
            '    End If
            'Else
            '    ValidaSeleccion()
            'End If
            ''LlenarGridPedidosMuestras()
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            'LlenarGridPedidosMuestras()

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function DescargaArchivo(ByVal rutaLocal As String, ByVal rutaServidor As String) As Boolean
        Dim Archivo As String = String.Empty
        Dim Directorio As String = String.Empty
        Dim RutaFinal As String = String.Empty
        Dim myWebClient As New System.Net.WebClient()
        Try
            'Directorio = System.IO.Path.GetDirectoryName(rutaLocal)
            Directorio = rutaLocal
            Directorio &= "\"
            Archivo = System.IO.Path.GetFileName(rutaServidor)
            If System.IO.Directory.Exists(Directorio) = False Then
                System.IO.Directory.CreateDirectory(Directorio)
            End If
            RutaFinal = Directorio & Archivo
            myWebClient.DownloadFile(rutaServidor, RutaFinal)
            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click
        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtResultadoDescartar As New DataTable
        Dim confirmacion As New Tools.ConfirmarForm
        Dim NumeroFilas As Integer = 0
        Dim RenglonEnviar As Integer = 0
        Dim verificaVacios As Integer = 0
        Cursor = Cursors.WaitCursor
        Try
            If EsTimbrado = 0 Then
                obtenerDocumentoSeleccionado(4)

                If IdComplementosPagosSeleccionadosParaEnviar <> "" Then
                    confirmacion.mensaje = "Se enviarán por correo los complementos seleccionados. ¿Desea continuar?"
                    If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        'If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        NumeroFilas = bgvCFDI.DataRowCount

                        For index As Integer = 0 To NumeroFilas Step 1
                            RenglonEnviar = CInt(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#"))
                            If Split(IdComplementosPagosSeleccionadosParaEnviar, ",").Contains(RenglonEnviar) Then
                                If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Email")) OrElse bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Email") = "" Then
                                    verificaVacios += 1
                                Else
                                    enviarCorreoComplementoDePago(CInt(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#")), bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Email"), bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "RutaXML"), bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "RutaPDF"))
                                End If
                            End If
                        Next

                        'End If                        
                    End If
                End If

            Else

                NumeroFilas = bgvCFDI.DataRowCount

                For index As Integer = 0 To NumeroFilas Step 1
                    RenglonEnviar = CInt(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#"))
                    If Split(IdComplementosPagosSeleccionadosParaEnviar, ",").Contains(RenglonEnviar) Then
                        If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Email")) OrElse bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Email") = "" Then
                            verificaVacios += 1
                        Else
                            enviarCorreoComplementoDePago(CInt(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#")), bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Email"), bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "RutaXML"), bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "RutaPDF"))
                        End If
                    End If

                Next

            End If

            If EsTimbrado = 0 Then
                If Split(IdComplementosPagosSeleccionadosParaEnviar, ",").Count > 1 Then
                    If verificaVacios = Split(IdComplementosPagosSeleccionadosParaEnviar, ",").Count Then
                        show_message("Advertencia", "Los correos no fueron enviados, favor de verificar los datos de contacto del cliente.")
                    ElseIf verificaVacios > 0 Then
                        show_message("Advertencia", "Algunos correos no fueron enviados, favor de verificar los datos de contacto del cliente.")
                    ElseIf verificaVacios = 0 Then
                        show_message("Exito", "Los CRP se enviaron correctamente")
                    End If
                Else
                    If verificaVacios = Split(IdComplementosPagosSeleccionadosParaEnviar, ",").Count Then
                        show_message("Advertencia", "El correo no fue enviado, favor de verificar los datos de contacto del cliente.")
                    Else
                        show_message("Exito", "El CRP se envió correctamente")
                    End If
                End If
            End If

        Catch ex As Exception
            If EsTimbrado = 0 Then
                show_message("Error", "Ocurrio un error al enviar, intente de nuevo")
            End If
        End Try
        EsTimbrado = 0
        Cursor = Cursors.Default
    End Sub



    Private Function enviarCorreoComplementoDePago(ByVal IdComplemento As Integer, CorreosDestinatario As String, rutaArchivoXML As String, rutaArchivoPDF As String) As Boolean
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim StatusCorreo As Boolean = False


        Cursor = Cursors.WaitCursor

        Try

            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()

            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If


            asuntoCorreo = "Asunto: CFDI de Complemento de Recibo de Pago (CRP)"
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI de recibo de pago (CRP) en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en el recibo de pago, en caso de que este proceda se realizará Únicamente dentro de los primeros 7 días posteriores a la expedición del comprobante; pasando este lapso de días no se harán cambios.</li>" +
                            "<li> No Procederá la cancelación de un CFDI de recibo de pago (CRP) que se haya facturado conforme a los datos proporcionados por usted mismo. </li>" +
                            "<li> Los documentos relacionados que se tomarán en cuenta para realizar el CFDI de pago son aquellos que usted nos proporcionó en la notificación de pago, de no recibir la notificación el pago se aplicará a los CFDI pendientes de pago más antiguos de acuerdo a lo estipulado en la regla 2.7.1.35 de la RMF.</li>" +
                            "<li> El recibo de pago (CRP) fue emitido solo con los datos obligatorios que actualmente se encuentran regulados por el SAT (Guía de llenado del ""Complemento para recepción de Pagos"") . Por lo tanto en el recibo no verán reflejados los datos bancarios (NumOperacion, RfcEmisorCtaOrd, CtaOrdenante, RfcEmisorCtaBen, CtaBeneficiario, TipoCadPago, CertPago, CadPago, SelloPago)</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            If lstArchivoAdjuntos.Count > 0 Then
                entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)
                If entCorreo.CorreoEnviado = True Then
                    CorreoEnviado = "S"
                    StatusCorreo = True
                Else
                    CorreoEnviado = "N"
                    StatusCorreo = False
                End If

                'Actualizar Status Correo Enviado SAY
                objBU.ActualizarStatusCorreoEnviadoCRP(IdComplemento, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                objBU.RegistraBitacoraEnvio(IdComplemento, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Else
                'show_message("Advertencia", "El correo para el CRP:" + IdComplemento.ToString() + " correo no se pudo enviar, favor de intentarlo mas tarde.")

                CorreoEnviado = "N"
                StatusCorreo = False

                objBU.ActualizarStatusCorreoEnviadoCRP(IdComplemento, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                objBU.RegistraBitacoraEnvio(IdComplemento, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            End If

        Catch ex As Exception
            StatusCorreo = False
        End Try

        Return StatusCorreo

        Cursor = Cursors.Default

    End Function

    Private Sub btnTimbraCoppel_Click(sender As Object, e As EventArgs) Handles btnTimbraCoppel.Click, lblTimbrarCoppel.Click
        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtResultadoGenerarDatosTimbrado As New DataTable
        Dim confirmacion As New Tools.ConfirmarForm

        Try
            obtenerDocumentoSeleccionado(3)
            If IdComplementoPagoSeleccionadoParaTimbrar <> 0 Then
                confirmacion.mensaje = "Se timbrará el complemento #" + IdComplementoPagoSeleccionadoParaTimbrar.ToString() + ". ¿Desea continuar?"
                If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor

                    Dim idEmpresa = 7 'CInt(dtResultadoGenerarDatosTimbrado.Rows(0).Item("idEmpresa"))
                    Dim objComplemento As New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                    objComplemento.FolioComplementoPago(IdComplementoPagoSeleccionadoParaTimbrar, idEmpresa)
                    Dim aviso As String = objComplemento.Aviso
                    Dim respuesta As Int16 = objComplemento.Respuesta
                    If respuesta = 1 Then
                        aviso = ""
                        respuesta = 0
                        objComplemento.CopiarDocumento()
                        aviso = objComplemento.Aviso
                        respuesta = objComplemento.Respuesta
                        If respuesta = 1 Then
                            'Process.Start(objtimbradoBU.RutaCliente)
                            objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                            objComplemento.GenerarPdfComplementoPago(IdComplementoPagoSeleccionadoParaTimbrar)
                            respuesta = 0
                            aviso = String.Empty
                            respuesta = objComplemento.Respuesta
                            aviso = objComplemento.Aviso
                            If respuesta = 1 Then
                                aviso = ""
                                respuesta = 0
                                objComplemento.CopiarDocumento()
                                aviso = objComplemento.Aviso
                                respuesta = objComplemento.Respuesta
                                If respuesta = 1 Then
                                    EsTimbrado = 1
                                    btnEnviarCorreo_Click(Nothing, Nothing)
                                    show_message("Exito", aviso)
                                Else
                                    MsgBox(aviso)
                                End If
                            Else
                                MsgBox(aviso)
                            End If
                        Else
                            MsgBox(aviso)
                        End If
                    Else
                        MsgBox(aviso)
                    End If
                    btnMostrar_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub lblTextoTimbrar_Click(sender As Object, e As EventArgs) Handles lblTextoTimbrar.Click

    End Sub

    Private Sub btnPdf_Click(sender As Object, e As EventArgs) Handles btnPdf.Click, lblPdf.Click
        Dim aviso As String = ""
        If validaGenerarPDF() Then
            Cursor = Cursors.WaitCursor
            For index As Integer = 0 To bgvCFDI.DataRowCount Step 1
                If CBool(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), " ")) = True Then
                    Dim idComplementoPdf As Integer = CInt(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "#"))
                    Dim objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                    objComplemento.GenerarPdfComplementoPago(idComplementoPdf)
                    Dim respuesta = objComplemento.Respuesta
                    If respuesta = 1 Then
                        objComplemento.CopiarDocumento()
                        aviso = objComplemento.Aviso
                        respuesta = objComplemento.Respuesta
                        If respuesta <> 1 Then
                            aviso = objComplemento.Aviso
                            show_message("Error", aviso)
                            Exit Sub
                        End If
                    Else
                        aviso = objComplemento.Aviso
                        show_message("Error", aviso)
                        Exit Sub
                    End If
                End If
            Next
            show_message("Exito", aviso)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function validaGenerarPDF() As Boolean
        Dim seleccionadas As Integer = 0
        For index As Integer = 0 To bgvCFDI.DataRowCount Step 1
            If CBool(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), " ")) = True Then
                seleccionadas += 1
                If IsDBNull(bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Estatus")) = False Then
                    Dim status = bgvCFDI.GetRowCellValue(bgvCFDI.GetVisibleRowHandle(index), "Estatus")
                    If status <> "TIMBRADO" Then
                        show_message("Advertencia", "Solo se puede generar el PDF complementos en estatus ""TIMBRADO"".")
                        Return False
                    End If
                End If
            End If
        Next

        If seleccionadas = 0 Then
            show_message("Advertencia", "Favor de selaccionar al menos un registros.")
            Return False
        End If
        Return True
    End Function
    Private Sub cargaComboTipoCrp(ByVal opcionCliente As String)
        Dim lstTipoClientes As New DataTable
        Dim obtenerlst As New Negocios.AdministradorComplementoRecepcionPagosBU
        lstTipoClientes = obtenerlst.obtenerTipoClientes(opcionCliente)
        CmBoxTipoCrp.DataSource = lstTipoClientes
        CmBoxTipoCrp.ValueMember = "idtipo"
        CmBoxTipoCrp.DisplayMember = "tipoCliente"
        CmBoxTipoCrp.SelectedIndex = 0
    End Sub
    Private Sub CmBoxTipoCrp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmBoxTipoCrp.SelectedIndexChanged
        ObtenerRazonesSociales()
    End Sub

    Private Sub ObtenerRazonesSociales()
        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim dtRazonesSociales As New DataTable
        dtRazonesSociales = objBu.consultaFiltroRazonesSociales(CmBoxTipoCrp.Text)
        dtRazonesSociales.Rows.InsertAt(dtRazonesSociales.NewRow, 0)
        cmboxRazonSocial.DataSource = dtRazonesSociales
        If dtRazonesSociales.Rows.Count > 1 Then
            cmboxRazonSocial.ValueMember = "IdDocumento"
            cmboxRazonSocial.DisplayMember = "RazonSocial"
        End If
    End Sub

End Class