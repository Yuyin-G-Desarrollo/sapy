Imports Infragistics.Win.UltraWinGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools
Imports Infragistics.Win
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports System.IO
Imports System.Xml
Imports Facturacion.Negocios

Public Class AdministradorFacturacion_Form

#Region "VARIABLES GLOBALES"

    Dim ObjBU As New Negocios.AdministradorDocumentosBU
    Dim lstInicial As New List(Of String)
    Dim lstFiltroDocumento As New List(Of String)
    Dim lstFiltroFactura As New List(Of String)
    Dim lstFiltroFolioOT As New List(Of String)


    Dim DocumentoSeleccionadoParaVerOTs As Integer = 0
    Dim FilasSeleccionadas As Integer = 0

    Dim DocumentoSeleccionadoParaCancelar As Integer = 0
    Dim ClienteSeleccionadoParaCancelar As Integer = 0


    Public UltimoDocumentoCancelado As Integer = 0
    Public UltimoClienteCancelado As Integer = 0
    Public UltimoSolicitanteCancelacion As String = ""
    Public UltimoMotivoCancelacionSeleccionado As Integer = 0
    Public UltimoRFCCancelacionSeleccionado As Integer = 0
    Public UltimaObservacionCancelacionSeleccionada As String = ""
    Public UltimoUsoCancelacionSeleccionado As String = ""
    Public UltimaOpcionSustitucionSeleccionada As Integer = 0
    Public ParidadDocumetoExtranjero As Decimal = 1

    Dim errores As Integer = 0

#End Region

    Private Sub btnGenerarArchivo_Click(sender As Object, e As EventArgs) Handles btnImprimirPDF.Click

        cmsTipoImpresion.Show(MousePosition)

    End Sub

    Public Sub SeleccionCheckMostrarOT()
        If grdFolioOT.Rows.Count > 0 Then
            chkMostrarOT.Checked = True
        End If
    End Sub

    Private Sub AdministradorFacturacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Cursor = Cursors.WaitCursor

        ObtenerCEDISUsuario()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_VER_SOLO_FACTURAS") Then
            pnlImprimirPDF.Visible = False
            pnlTimbrarDocumento.Visible = False
            pnlCancelar.Visible = False
            pnlReintentarCancelacionSAT.Visible = False
            pnlEnvioCorreo.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_ATN_CLIENTES") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_ATN_CLIENTES_EXTERNO") Then
            cmsTipoImpresion.Items(0).Visible = False
            pnlTimbrarDocumento.Visible = False
            pnlCancelar.Visible = False
            pnlReintentarCancelacionSAT.Visible = False
            pnlEnvioCorreo.Visible = False
            PnlGenerarAddenda.Visible = False
            pnlAnexarArchivos.Visible = False

            pnlCancelar.Visible = True
            pnlReintentarCancelacionSAT.Visible = True
            pnlEnvioCorreo.Visible = True

        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_TIMBRAR") Then
            pnlTimbrarDocumento.Visible = True
            cmsTipoImpresion.Items(0).Visible = True
            PnlGenerarAddenda.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_REFACTURAR") Then
            pnlRefacturar.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_REPLICASAP") Then
            pnlGenerarXMLSap.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_ANEXAR_ARCHIVOS") Then
            pnlAnexarArchivos.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_SOLICITAR_CANCELACION") Then
            pnlSolicitudCancelacion.Visible = True
        End If


        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        grdStatus.DataSource = lstInicial
        grdFiltroDocumento.DataSource = lstInicial
        grdFactura.DataSource = lstInicial
        grdFolioOT.DataSource = lstInicial
        grdCliente.DataSource = lstInicial
        grdEmisor.DataSource = lstInicial

        'pnlCancelar.Visible = False
        'pnlReintentarCancelacionSAT.Visible = False
        Cursor = Cursors.Default



    End Sub

#Region "CONSULTA DATOS"

    Private Sub ConsultaAdministradorDocumentos()

        Dim dtResultadoAdministrador As New DataTable
        Dim objFiltrosAdministrador = obtenerFiltrosAdministradorDocumentos()
        Dim dtActualiza As New DataTable

        dtActualiza = ObjBU.actualizarSaldosSicySay() '' ACTUALIZA SALDOS DE SICY EN SAY

        dtResultadoAdministrador = ObjBU.consultaAdministradorDocumentos(objFiltrosAdministrador)
        grdDocumentos.DataSource = Nothing

        If dtResultadoAdministrador.Rows.Count > 0 Then
            grdDocumentos.DataSource = dtResultadoAdministrador
            DiseñoGridDocumentos()
        Else
            show_message("Aviso", "No hay datos para mostrar.")
        End If

        lblTotalRegistros.Text = dtResultadoAdministrador.Rows.Count.ToString("N0")

    End Sub

    Private Function obtenerFiltrosAdministradorDocumentos() As Entidades.FiltrosAdministradorDocumentos

        Dim objFiltrosAdministrador As New Entidades.FiltrosAdministradorDocumentos

        objFiltrosAdministrador.TipoFecha = If(rdoFechaFacturacion.Checked, 1, (If(rdoFechaCancelacion.Checked, 2, 0)))
        objFiltrosAdministrador.FechaInicio = dtpFechaInicio.Value.ToShortDateString()
        objFiltrosAdministrador.FechaTermino = dtpFechaFin.Value.ToShortDateString()
        objFiltrosAdministrador.StatusID = ObtenerFiltrosGrid(grdStatus)
        objFiltrosAdministrador.DocumentoId = ObtenerFiltrosGrid(grdFiltroDocumento)
        objFiltrosAdministrador.FacturaId = ObtenerFiltrosGrid(grdFactura)
        objFiltrosAdministrador.FolioOT = ObtenerFiltrosGrid(grdFolioOT)
        objFiltrosAdministrador.ClienteId = ObtenerFiltrosGrid(grdCliente)
        objFiltrosAdministrador.EmisorId = ObtenerFiltrosGrid(grdEmisor)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_VER_SOLO_FACTURAS") Then
            objFiltrosAdministrador.ConsultaContabilidad = 1
        Else
            objFiltrosAdministrador.ConsultaContabilidad = 0
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Facturacion_Admin_Documentos", "ADMIN_DOC_ATN_CLIENTES_EXTERNO") Then
            objFiltrosAdministrador.UsuarioConsultaId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Else
            objFiltrosAdministrador.UsuarioConsultaId = 0
        End If

        If chkMostrarOT.Checked = True Then
            objFiltrosAdministrador.MostrarOT = 1
        Else
            objFiltrosAdministrador.MostrarOT = 0
        End If

        objFiltrosAdministrador.CEDISID = cmbCEDIS.SelectedValue

        Return objFiltrosAdministrador

    End Function

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String

        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return Resultado

    End Function
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor

        ConsultaAdministradorDocumentos()

        Cursor = Cursors.Default
    End Sub

#End Region


    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

#Region "DISEÑO"

    Private Sub DiseñoGridDocumentos()
        bgvDocumentos.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDocumentos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvDocumentos.Columns.ColumnByFieldName("status_id").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("cliente_id").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("emisor_id").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("tabla_documentoid").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("IdDocumento").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("EmpresaID").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("Correo enviado").Visible = False
        bgvDocumentos.Columns.ColumnByFieldName("Saldo").Visible = False

        bgvDocumentos.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDocumentos.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDocumentos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'bgvDocumentos.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvDocumentos.Columns.ColumnByFieldName("F Captura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        bgvDocumentos.Columns.ColumnByFieldName("Cantidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvDocumentos.Columns.ColumnByFieldName("Cancelados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvDocumentos.Columns.ColumnByFieldName("Total").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvDocumentos.Columns.ColumnByFieldName("Monto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvDocumentos.Columns.ColumnByFieldName("Tipo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvDocumentos.Columns.ColumnByFieldName("Notas de Crédito").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Saldo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvDocumentos.Columns.ColumnByFieldName("Docto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("OT").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Razón Social").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("RFC Emisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("RFC Receptor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Capturó").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Moneda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Uso").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Folio Fiscal").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Canceló").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Motivo Cancelación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Observación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Producto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Solicita").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Relación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvDocumentos.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        bgvDocumentos.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"
        bgvDocumentos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N0"
        bgvDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatString = "N2"
        'bgvDocumentos.Columns.ColumnByFieldName("Saldo").DisplayFormat.FormatString = "N2"

        bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        bgvDocumentos.Columns.ColumnByFieldName(" ").Width = 30
        bgvDocumentos.Columns.ColumnByFieldName("Tipo").Width = 35
        bgvDocumentos.Columns.ColumnByFieldName("Docto").Width = 60
        bgvDocumentos.Columns.ColumnByFieldName("Factura").Width = 60
        bgvDocumentos.Columns.ColumnByFieldName("OT").Width = 60
        bgvDocumentos.Columns.ColumnByFieldName("Cliente").Width = 250
        bgvDocumentos.Columns.ColumnByFieldName("Razón Social").Width = 300
        bgvDocumentos.Columns.ColumnByFieldName("RFC Emisor").Width = 100
        bgvDocumentos.Columns.ColumnByFieldName("RFC Receptor").Width = 100
        bgvDocumentos.Columns.ColumnByFieldName("F Captura").Width = 120
        bgvDocumentos.Columns.ColumnByFieldName("Capturó").Width = 80
        bgvDocumentos.Columns.ColumnByFieldName("Cantidad").Width = 60
        bgvDocumentos.Columns.ColumnByFieldName("Cancelados").Width = 60
        bgvDocumentos.Columns.ColumnByFieldName("Total").Width = 60
        bgvDocumentos.Columns.ColumnByFieldName("Monto").Width = 90
        bgvDocumentos.Columns.ColumnByFieldName("Moneda").Width = 80
        bgvDocumentos.Columns.ColumnByFieldName("Uso").Width = 250
        bgvDocumentos.Columns.ColumnByFieldName("Folio Fiscal").Width = 250
        bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").Width = 120
        bgvDocumentos.Columns.ColumnByFieldName("Canceló").Width = 80
        bgvDocumentos.Columns.ColumnByFieldName("Motivo Cancelación").Width = 300
        bgvDocumentos.Columns.ColumnByFieldName("Observación").Width = 180
        bgvDocumentos.Columns.ColumnByFieldName("Producto").Width = 90
        bgvDocumentos.Columns.ColumnByFieldName("Solicita").Width = 100
        bgvDocumentos.Columns.ColumnByFieldName("Relación").Width = 250
        bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").Width = 250
        bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").Width = 250
        bgvDocumentos.Columns.ColumnByFieldName("Notas de Crédito").Width = 200
        'bgvDocumentos.Columns.ColumnByFieldName("Saldo").Width = 70

        bgvDocumentos.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Docto").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Factura").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Razón Social").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("RFC Emisor").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("RFC Receptor").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("F Captura").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Capturó").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Cancelados").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Total").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Monto").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Moneda").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Uso").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Folio Fiscal").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Canceló").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Motivo Cancelación").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Observación").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Producto").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Solicita").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Relación").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Correo enviado").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Id SAY").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Notas de Crédito").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("FA").OptionsColumn.AllowEdit = False
        bgvDocumentos.Columns.ColumnByFieldName("Cargo Adicional").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Saldo").OptionsColumn.AllowEdit = False

        bgvDocumentos.Columns.ColumnByFieldName("F Captura").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"


        bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").Caption = "Folios relacionados"
        bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").Caption = "Folios que sustituyen"


        bgvDocumentos.IndicatorWidth = 40

        bgvDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(bgvDocumentos.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            bgvDocumentos.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Cantidad"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvDocumentos.GroupSummary.Add(item)
        End If

        If IsNothing(bgvDocumentos.Columns("Cancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "Cancelados")) = True Then
            bgvDocumentos.Columns("Cancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Cancelados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            bgvDocumentos.GroupSummary.Add(item2)
        End If

        If IsNothing(bgvDocumentos.Columns("Total").Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True Then
            bgvDocumentos.Columns("Total").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:N0}")
            Dim item3 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item3.FieldName = "Total"
            item3.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item3.DisplayFormat = "{0}"
            bgvDocumentos.GroupSummary.Add(item3)
        End If
        'If IsNothing(bgvDocumentos.Columns("Saldo").Summary.FirstOrDefault(Function(x) x.FieldName = "Saldo")) = True Then
        '    bgvDocumentos.Columns("Saldo").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:N0}")
        '    Dim item4 As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item4.FieldName = "Saldo"
        '    item4.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item4.DisplayFormat = "{0}"
        '    bgvDocumentos.GroupSummary.Add(item4)
        'End If
    End Sub

    Private Sub bgvDocumentos_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles bgvDocumentos.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim StatusCorreo As String = String.Empty
        Dim TipoDocumento As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'Id SAY
            StatusCorreo = currentView.GetRowCellValue(e.RowHandle, "Correo enviado")
            TipoDocumento = currentView.GetRowCellValue(e.RowHandle, "Tipo")
            If e.Column.FieldName = "Id SAY" Then
                If TipoDocumento = "F" Then
                    If StatusCorreo = "NO" Then
                        e.Appearance.BackColor = pnlCorreoNoEnviado.BackColor
                    End If
                End If
            End If
            If e.Column.FieldName = "FA" Then
                If e.CellValue = "SI" Then
                    e.Appearance.BackColor = pnlColorFA.BackColor
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub bgvDocumentos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvDocumentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvDocumentos_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvDocumentos.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id")) = False Then
                If bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 158 Then
                    e.Appearance.ForeColor = lblDiseñoCancelado.ForeColor
                ElseIf bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 167 Then
                    e.Appearance.ForeColor = lblDiseñoCanceladoFaltaSAT.ForeColor
                    e.Appearance.BackColor = pnlCanceladoFaltaSAT.BackColor
                ElseIf bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 191 Then
                    e.Appearance.ForeColor = lblCanceladaEsperaAceptacion.ForeColor
                    e.Appearance.BackColor = pnlCanceladaEsperaAceptacion.BackColor
                End If
            End If
            'Regenerar xml
            If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "Folio Fiscal")) = True Or bgvDocumentos.GetRowCellValue(e.RowHandle, "Folio Fiscal") = "" Then
                If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo")) = False And bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo") = "F" Then
                    'Dim var = bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id")

                    If bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") <> 158 And bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") <> 167 Then
                        e.Appearance.BackColor = pnlStatusNoTimbrado.BackColor
                    End If
                End If
            End If

            If Not IsDBNull((bgvDocumentos.GetRowCellValue(e.RowHandle, "EstatusCancelacion"))) Then
                If (bgvDocumentos.GetRowCellValue(e.RowHandle, "EstatusCancelacion")).ToString.Trim = "RECHAZADA" Then
                    e.Appearance.BackColor = pnlEstatusCancelacion.BackColor
                End If
            End If
        End If
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

    Private Sub grdStatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatus.InitializeLayout
        grid_diseño(grdStatus)
        grdStatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status"
    End Sub

    Private Sub grdFiltroDocumento_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroDocumento.InitializeLayout
        grid_diseño(grdFiltroDocumento)
        grdFiltroDocumento.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Docto"
    End Sub

    Private Sub grdFactura_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFactura.InitializeLayout
        grid_diseño(grdFactura)
        grdFactura.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Factura"
    End Sub

    Private Sub grdFolioOT_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioOT.InitializeLayout
        SeleccionCheckMostrarOT()
        grid_diseño(grdFolioOT)
        grdFolioOT.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio OT"
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdEmisor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmisor.InitializeLayout
        grid_diseño(grdEmisor)
        grdEmisor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Emisor"
    End Sub


#End Region

#Region "OTRAS FUNCIONES"

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
            NumeroFilas = bgvDocumentos.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                bgvDocumentos.SetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)

                If CBool(chboxSeleccionarTodo.Checked) = False Then
                    bgvDocumentos.SetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "%", 0)
                End If

            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
        pnPBar.Left = (grdDocumentos.Width - pnPBar.Width) / 2
        pnPBar.Top = (grdDocumentos.Height - pnPBar.Height) / 2
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 197
        pnPBar.Left = (grdDocumentos.Width - pnPBar.Width) / 2
        pnPBar.Top = (grdDocumentos.Height - pnPBar.Height) / 2
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdStatus.DataSource = lstInicial
        grdFiltroDocumento.DataSource = lstInicial
        grdFactura.DataSource = lstInicial
        grdFolioOT.DataSource = lstInicial
        grdCliente.DataSource = lstInicial
        grdEmisor.DataSource = lstInicial
        grdDocumentos.DataSource = Nothing
    End Sub

#End Region

#Region "FILTROS"

    Private Sub btnAgregarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroStatus.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 15
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatus.DataSource = listado.listParametros
        With grdStatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
        End With
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
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
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnAgregarFiltroEmisor_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEmisor.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 14
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdEmisor.DataSource = listado.listParametros
        With grdEmisor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Emisor"
        End With
    End Sub

    Private Sub txtFiltroDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroDocumento.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroDocumento.Text) Then Return

            lstFiltroDocumento.Add(txtFiltroDocumento.Text)
            grdFiltroDocumento.DataSource = Nothing
            grdFiltroDocumento.DataSource = lstFiltroDocumento

            txtFiltroDocumento.Text = String.Empty

        End If
    End Sub

    Private Sub txtFiltroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFactura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFactura.Text) Then Return

            lstFiltroFactura.Add(txtFiltroFactura.Text)
            grdFactura.DataSource = Nothing
            grdFactura.DataSource = lstFiltroFactura

            txtFiltroFactura.Text = String.Empty

        End If
    End Sub

    Private Sub txtFiltroFolioOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioOT.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioOT.Text) Then Return

            lstFiltroFolioOT.Add(txtFiltroFolioOT.Text)
            grdFolioOT.DataSource = Nothing
            grdFolioOT.DataSource = lstFiltroFolioOT

            txtFiltroFolioOT.Text = String.Empty

        End If
    End Sub

    Private Sub grdStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatus.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroDocumento_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroDocumento.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroDocumento.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFolioOT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioOT.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioOT.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdEmisor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEmisor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEmisor.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click
        grdStatus.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroEmisore_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroEmisor.Click
        grdEmisor.DataSource = lstInicial
    End Sub

#End Region

#Region "EXPORTAR EXCEL"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvDocumentos.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty

            Try

                bgvDocumentos.Columns.ColumnByFieldName(" ").Visible = False
                nombreReporte = "\AdministradorDocumentos_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvDocumentos.GroupCount > 0 Then
                            bgvDocumentos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            exportOptions.ShowColumnHeaders = False
                            grdDocumentos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

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


        bgvDocumentos.Columns.ColumnByFieldName(" ").Visible = True

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try

            If e.RowHandle >= 0 Then
                If e.AreaType <> DevExpress.Export.SheetAreaType.Header Then

                    If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id")) = False Then
                        If bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 158 Then
                            e.Formatting.Font.Color = lblDiseñoCancelado.ForeColor
                        ElseIf bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 167 Then
                            e.Formatting.Font.Color = lblDiseñoCanceladoFaltaSAT.ForeColor
                            e.Formatting.BackColor = pnlCanceladoFaltaSAT.BackColor
                        ElseIf bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 191 Then
                            e.Formatting.Font.Color = lblCanceladaEsperaAceptacion.ForeColor
                            e.Formatting.BackColor = pnlCanceladaEsperaAceptacion.BackColor
                        End If
                    End If

                    If e.ColumnFieldName = "Id SAY" Then
                        If bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo") = "F" Then
                            If bgvDocumentos.GetRowCellValue(e.RowHandle, "Correo enviado") = "NO" Then
                                e.Formatting.BackColor = pnlCorreoNoEnviado.BackColor
                            End If
                        End If
                    End If
                    If e.ColumnFieldName = "FA" Then
                        If bgvDocumentos.GetRowCellValue(e.RowHandle, "FA") = "SI" Then
                            e.Formatting.BackColor = pnlColorFA.BackColor
                        End If
                    End If
                    If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "Folio Fiscal")) = True Or bgvDocumentos.GetRowCellValue(e.RowHandle, "Folio Fiscal") = "" Then
                        If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo")) = False And bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo") = "F" Then
                            'Dim var = bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id")

                            If bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") <> 158 And bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") <> 167 Then
                                e.Formatting.BackColor = pnlStatusNoTimbrado.BackColor
                            End If
                        End If
                    End If

                    If Not IsDBNull((bgvDocumentos.GetRowCellValue(e.RowHandle, "EstatusCancelacion"))) Then
                        If (bgvDocumentos.GetRowCellValue(e.RowHandle, "EstatusCancelacion")).ToString.Trim = "RECHAZADA" Then
                            e.Formatting.BackColor = pnlEstatusCancelacion.BackColor
                        End If
                    End If
                    If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id")) = False Then
                        If bgvDocumentos.GetRowCellValue(e.RowHandle, "status_id") = 158 Then
                            e.Formatting.Font.Color = lblDiseñoCancelado.ForeColor
                        End If
                    End If

                    If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "Folio Fiscal")) = True Or bgvDocumentos.GetRowCellValue(e.RowHandle, "Folio Fiscal") = "" Then
                        If IsDBNull(bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo")) = False And bgvDocumentos.GetRowCellValue(e.RowHandle, "Tipo") = "F" Then
                            e.Formatting.BackColor = pnlStatusNoTimbrado.BackColor
                        End If
                    End If
                End If



            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

#End Region

    Private Sub grdDocumentos_MouseClick(sender As Object, e As MouseEventArgs) Handles grdDocumentos.MouseClick
        Dim AltaCita As New AltaCitaEntregaForm
        Dim TextoTieneCita As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        DocumentoSeleccionadoParaVerOTs = 0

        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then

                Cursor = Cursors.WaitCursor

                ' Add the selected rows to the list.
                Dim I As Integer
                For I = 0 To bgvDocumentos.RowCount - 1

                    If bgvDocumentos.IsRowSelected(bgvDocumentos.GetVisibleRowHandle(I)) = True Then
                        FilasSeleccionadas += 1
                        DocumentoSeleccionadoParaVerOTs = (bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(I), "tabla_documentoid"))
                    End If


                Next

                If FilasSeleccionadas > 0 Then

                End If

                cmsVerOTs.Show(MousePosition)



                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub tsmVerOts_Click(sender As Object, e As EventArgs) Handles tsmVerOts.Click
        Dim ventana As New OrdenesTrabajoPorDocumento
        ventana.IdDocumento = DocumentoSeleccionadoParaVerOTs
        ventana.ShowDialog()
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        Dim DocumentoId As String = ""
        Dim ventanaDetalles As New ConsultaDetallesDocumentosGuardados_Form

        DocumentoId = obtenerDocumentosSeleccionados()

        If FilasSeleccionadas = 1 Then
            ventanaDetalles.IdDocumento = Integer.Parse(DocumentoId)
            'ventanaDetalles.MdiParent = Me.MdiParent
            'Me.WindowState = FormWindowState.Minimized
            ventanaDetalles.ShowDialog()
        Else
            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "Debe seleccionar un documento para ver detalles.")
            Else
                'show_message("Advertencia", "Solo se puede consultar un documento a la vez.")
                Dim DetallesDocumentos As New DetallesDocumentosForm
                DetallesDocumentos.Documentos = DocumentoId
                DetallesDocumentos.ShowDialog()
            End If

        End If

    End Sub

    Private Function obtenerDocumentosSeleccionados() As String
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        FilasSeleccionadas = 0

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1

                    If documentosSeleccionados = String.Empty Then
                        documentosSeleccionados = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "tabla_documentoid").ToString()
                    Else
                        documentosSeleccionados = documentosSeleccionados & "," & bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "tabla_documentoid").ToString()
                    End If
                End If
            Next

        Catch

            show_message("Error", "Ocurrio un error al seleccionar el documento. Por favor intente de nuevo")

        End Try

        Cursor = Cursors.Default

        Return documentosSeleccionados

    End Function

    Private Sub Cancelar()
        Cursor = Cursors.WaitCursor
        Try
            Dim objBUCancelacionCoppel As New Negocios.CancelacionDocumentosBU
            Dim dtResultado As New DataTable()
            Dim abrirVentana As Boolean = True
            Dim entDocumentoCancelar As New Entidades.FacturaCancelada
            'If SeSeleccionoFactura() = False Then -- validacion cancelar facturas diferentes a facturas 
            obtenerDocumentoClienteSeleccionado() '' validaciones de seleccion de facturas
            If DocumentoSeleccionadoParaCancelar > 0 And ClienteSeleccionadoParaCancelar > 0 Then
                If Not ValidarConfirmacionOTCoppel(DocumentoSeleccionadoParaCancelar) Then
                    show_message("Advertencia", "Este documento Coppel tiene pares confirmados o embarcados, favor de intentar cancelar primero la OT Coppel")
                    Return
                End If
                dtResultado = objBUCancelacionCoppel.consultaInformacionDocumentoCancelar(ClienteSeleccionadoParaCancelar, DocumentoSeleccionadoParaCancelar)
                If ClienteSeleccionadoParaCancelar = 763 And dtResultado.Rows(0).Item("Producto") <> "EN ALMACÉN" Then
                    abrirVentana = False
                End If

                If abrirVentana Then
                    'validar si tiene el permiso y la solicitud confirmada 
                    Dim dtPermiso As New DataTable
                    dtPermiso = ObjBU.ObtenerPermisoCancelacion(DocumentoSeleccionadoParaCancelar)
                    If dtPermiso.Rows(0).Item("resultado") = 0 Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, dtPermiso.Rows(0).Item("respuesta").ToString)
                        Return
                    Else '' si tiene permiso
                        ''cargar los datos de la solcitud
                        Dim dtSolicitud As New DataTable
                        dtSolicitud = ObjBU.ConsultarSolicitud(DocumentoSeleccionadoParaCancelar)
                        ''SI ES SOLICITUD CON RELACION: VALIDAR QUE TENGA EL UUI DE LA FACTURA B PARA PODERLA RELACIONAR SI NO MSJ ERRROR
                        Dim seRelaciona As Boolean
                        seRelaciona = dtSolicitud.Rows(0).Item("seRelaciona")
                        If seRelaciona = True Then
                            Dim folioNuevaFactura As String = IIf(dtSolicitud.Rows(0).Item("folioFiscal") Is DBNull.Value, "", dtSolicitud.Rows(0).Item("folioFiscal"))
                            If folioNuevaFactura = "" Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se puede cancelar porque aún no tiene un documento relacionado")
                                Return
                            End If
                        End If



                        entDocumentoCancelar = ObtenerInformacionDocumentoCancelar(DocumentoSeleccionadoParaCancelar)

                            Dim ventanaCancelacion As New CancelacionDocumentos_Form
                            ventanaCancelacion.DocumentoId = DocumentoSeleccionadoParaCancelar
                            ventanaCancelacion.ClienteId = ClienteSeleccionadoParaCancelar
                            ventanaCancelacion.VentanaAdministradorDocumentos = Me
                            If UltimoClienteCancelado = ClienteSeleccionadoParaCancelar Then
                                ventanaCancelacion.UltimoDocumentoCancelado = UltimoDocumentoCancelado
                                ventanaCancelacion.UltimoClienteCancelado = UltimoClienteCancelado
                                ventanaCancelacion.UltimoSolicitanteCancelacion = UltimoSolicitanteCancelacion
                                ventanaCancelacion.UltimoMotivoCancelacionSeleccionado = UltimoMotivoCancelacionSeleccionado
                                ventanaCancelacion.UltimoRFCCancelacionSeleccionado = UltimoRFCCancelacionSeleccionado
                                ventanaCancelacion.UltimaObservacionCancelacionSeleccionada = UltimaObservacionCancelacionSeleccionada
                                ventanaCancelacion.UltimoUsoCancelacionSeleccionado = UltimoUsoCancelacionSeleccionado
                            End If
                            ventanaCancelacion.EntDocumentoACancelar = entDocumentoCancelar
                            ventanaCancelacion.ConSolicitud = 1
                            ventanaCancelacion.Solicita = dtSolicitud.Rows(0).Item("Solicita").ToString
                        ventanaCancelacion.Observacion = dtSolicitud.Rows(0).Item("Observacion").ToString
                        ventanaCancelacion.ConRelacion = dtSolicitud.Rows(0).Item("seRelaciona").ToString
                        ventanaCancelacion.FolioSustitucion = dtSolicitud.Rows(0).Item("folioFiscal").ToString


                        ventanaCancelacion.MdiParent = Me.MdiParent
                            Me.WindowState = FormWindowState.Minimized
                            ventanaCancelacion.Show()

                            ConsultaAdministradorDocumentos()
                        End If

                        Else
                    show_message("Advertencia", "Solo se pueden cancelar documentos de producto no entregado para el cliente COPPEL.")
                End If
            End If
            'End If

        Catch ex As Exception

        End Try


        Cursor = Cursors.Default

    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Dim PRUEBA As New TimbradoBU(0)

        'PRUEBA.CANCELADODEPRUEBA()
        Cancelar()

#Region "Cancelacion antes"
        'Cursor = Cursors.WaitCursor

        'Dim objBUCancelacionCoppel As New Negocios.CancelacionDocumentosBU
        'Dim dtResultado As New DataTable()
        'Dim abrirVentana As Boolean = True
        'Dim entDocumentoCancelar As New Entidades.FacturaCancelada
        'Try

        '    If SeSeleccionoFactura() = False Then
        '        obtenerDocumentoClienteSeleccionado()
        '        If DocumentoSeleccionadoParaCancelar > 0 And ClienteSeleccionadoParaCancelar > 0 Then

        '            If Not ValidarConfirmacionOTCoppel(DocumentoSeleccionadoParaCancelar) Then
        '                show_message("Advertencia", "Este documento Coppel tiene pares confirmados o embarcados, favor de intentar cancelar primero la OT Coppel")
        '                Return
        '            End If

        '            dtResultado = objBUCancelacionCoppel.consultaInformacionDocumentoCancelar(ClienteSeleccionadoParaCancelar, DocumentoSeleccionadoParaCancelar)
        '            If ClienteSeleccionadoParaCancelar = 763 And dtResultado.Rows(0).Item("Producto") <> "EN ALMACÉN" Then
        '                abrirVentana = False
        '            End If

        '            If abrirVentana Then
        '                entDocumentoCancelar = ObtenerInformacionDocumentoCancelar(DocumentoSeleccionadoParaCancelar)

        '                Dim ventanaCancelacion As New CancelacionDocumentos_Form
        '                ventanaCancelacion.DocumentoId = DocumentoSeleccionadoParaCancelar
        '                ventanaCancelacion.ClienteId = ClienteSeleccionadoParaCancelar
        '                ventanaCancelacion.VentanaAdministradorDocumentos = Me
        '                If UltimoClienteCancelado = ClienteSeleccionadoParaCancelar Then
        '                    ventanaCancelacion.UltimoDocumentoCancelado = UltimoDocumentoCancelado
        '                    ventanaCancelacion.UltimoClienteCancelado = UltimoClienteCancelado
        '                    ventanaCancelacion.UltimoSolicitanteCancelacion = UltimoSolicitanteCancelacion
        '                    ventanaCancelacion.UltimoMotivoCancelacionSeleccionado = UltimoMotivoCancelacionSeleccionado
        '                    ventanaCancelacion.UltimoRFCCancelacionSeleccionado = UltimoRFCCancelacionSeleccionado
        '                    ventanaCancelacion.UltimaObservacionCancelacionSeleccionada = UltimaObservacionCancelacionSeleccionada
        '                    ventanaCancelacion.UltimoUsoCancelacionSeleccionado = UltimoUsoCancelacionSeleccionado
        '                End If
        '                ventanaCancelacion.EntDocumentoACancelar = entDocumentoCancelar
        '                ventanaCancelacion.MdiParent = Me.MdiParent
        '                Me.WindowState = FormWindowState.Minimized
        '                ventanaCancelacion.Show()

        '                ConsultaAdministradorDocumentos()
        '            Else

        '                show_message("Advertencia", "Solo se pueden cancelar documentos de producto no entregado para el cliente COPPEL.")

        '            End If
        '        End If

        '    End If


        'Catch ex As Exception
        '    ConsultaAdministradorDocumentos()
        'End Try

        'Cursor = Cursors.Default
#End Region
    End Sub


    Private Sub grdDocumentos_DoubleClick(sender As Object, e As EventArgs) Handles grdDocumentos.DoubleClick
        Dim AltaCita As New AltaCitaEntregaForm
        Dim TextoTieneCita As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0

        Try

            Cursor = Cursors.WaitCursor

            ' Add the selected rows to the list.
            Dim I As Integer
            For I = 0 To bgvDocumentos.RowCount - 1

                If bgvDocumentos.IsRowSelected(bgvDocumentos.GetVisibleRowHandle(I)) = True Then
                    FilasSeleccionadas += 1
                    bgvDocumentos.SetRowCellValue(bgvDocumentos.GetVisibleRowHandle(I), " ", True)
                    btnVerDetalles_Click(Nothing, Nothing)
                    bgvDocumentos.SetRowCellValue(bgvDocumentos.GetVisibleRowHandle(I), " ", False)
                End If


            Next


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Function validarDocumentoFAParaCancelar(ByVal OT As Integer) As Boolean

        Dim ObjBUCancelacion As New Negocios.CancelacionDocumentosBU
        Dim estatusID As Integer

        estatusID = ObjBUCancelacion.validarEstatusOTParaCancelar(OT)

        If estatusID = 125 Or estatusID = 121 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub obtenerDocumentoClienteSeleccionado()

        'Dim ObjBUCancelacion As New Negocios.CancelacionDocumentosBU

        'DocumentoSeleccionadoParaCancelar = 0
        'ClienteSeleccionadoParaCancelar = 0
        'Dim NumeroFilas As Integer
        'Dim FilasSeleccionadasCancelacion As Integer = 0
        'Dim FilasSeleccionadasNoCancelables As Integer = 0
        'Dim FilasSeleccionadasNoCancelablesFA As Integer = 0 'FA = FACTURACIÓN ANTICIPADA

        'Dim DocumentoIdSeleccionado As Integer = 0
        'Dim IdSaySeleccionado As Integer = 0
        'Dim FolioFacturaSeleccionado As String = String.Empty
        'Dim NombreClienteSeleccionado As String = String.Empty

        'Dim FechaEmisionSeleccionado As String = String.Empty
        'Dim TipoDocumentoSeleccionado As String = String.Empty

        'Dim MesEmisionSeleccionado As Integer = 0
        'Dim AnioEmisionSeleccionado As Integer = 0

        'Dim mesActual As Integer = Month(DateTime.Now)
        'Dim AnioActual As Integer = Year(DateTime.Now)
        'Dim OTID As Integer


        'Cursor = Cursors.WaitCursor

        'Try

        '    NumeroFilas = bgvDocumentos.DataRowCount
        '    For index As Integer = 0 To NumeroFilas Step 1

        '        If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
        '            FilasSeleccionadasCancelacion += 1

        '            DocumentoIdSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Docto")
        '            IdSaySeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Id SAY")
        '            FolioFacturaSeleccionado = If(IsDBNull(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Factura")), "", bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Factura"))
        '            NombreClienteSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Cliente")
        '            FechaEmisionSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "F Captura")
        '            TipoDocumentoSeleccionado = If(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo") = "F", "FACTURA", "REMISIÓN")

        '            If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id") <> 156 And bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id") <> 157 Then
        '                FilasSeleccionadasNoCancelables += 1
        '            Else
        '                MesEmisionSeleccionado = Month(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "F Captura"))
        '                AnioEmisionSeleccionado = Year(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "F Captura"))
        '            End If

        '            If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "FA") = "SI" Then
        '                Dim otv As String = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "OT").ToString
        '                Dim cancel = Int64.TryParse(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "OT").ToString, OTID)
        '                OTID = If(cancel, Int64.Parse(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "OT")), 0)
        '                If validarDocumentoFAParaCancelar(OTID) = False Then
        '                    FilasSeleccionadasNoCancelablesFA += 1
        '                End If
        '            End If

        '            DocumentoSeleccionadoParaCancelar = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "tabla_documentoid")

        '            ClienteSeleccionadoParaCancelar = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "cliente_id")

        '        End If
        '    Next

        '    If FilasSeleccionadasCancelacion = 0 Then
        '        show_message("Advertencia", "Debe seleccionar un documento para cancelar")
        '        DocumentoSeleccionadoParaCancelar = 0
        '        ClienteSeleccionadoParaCancelar = 0
        '        Cursor = Cursors.Default

        '        Exit Sub
        '    End If

        '    If FilasSeleccionadasCancelacion > 1 Then
        '        show_message("Advertencia", "Solo se puede cancelar un documento a la vez")
        '        DocumentoSeleccionadoParaCancelar = 0
        '        ClienteSeleccionadoParaCancelar = 0
        '        Cursor = Cursors.Default

        '        Exit Sub
        '    End If

        '    ''validar si el documento tiene una solicitud en proceso o que la solicituda ya este confirmada
        '    Dim dtSolcititud As New DataTable
        '    Dim objSolicitud As New Negocios.SolicitarCancelacionBU
        '    dtSolcititud = objSolicitud.tieneSolicitudesEnProceso(IdSaySeleccionado)
        '    If FilasSeleccionadasCancelacion = 1 And dtSolcititud.Rows(0).Item("respuesta") = 1 Then
        '        'Utilerias.show_message(Utilerias.TipoMensaje.Errores, "El documento tiene solicitudes pendientes")
        '        show_message("Advertencia", "El documento no tiene una solicitud aceptada")
        '        DocumentoSeleccionadoParaCancelar = 0
        '        ClienteSeleccionadoParaCancelar = 0
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If


        '    If FilasSeleccionadasCancelacion = 1 And FilasSeleccionadasNoCancelables > 0 Then
        '        If TipoDocumentoSeleccionado = "REMISIÓN" Then
        '            show_message("Advertencia", "El documento #" + DocumentoIdSeleccionado.ToString() + " del cliente " + NombreClienteSeleccionado + " ya está CANCELADO.")
        '        Else
        '            show_message("Advertencia", "El documento #" + DocumentoIdSeleccionado.ToString() + " (Factura: " + FolioFacturaSeleccionado + ") del cliente " + NombreClienteSeleccionado + " ya está CANCELADO.")
        '        End If
        '        DocumentoSeleccionadoParaCancelar = 0
        '        ClienteSeleccionadoParaCancelar = 0
        '        Cursor = Cursors.Default

        '        Exit Sub
        '    End If

        '    If FilasSeleccionadasCancelacion = 1 And FilasSeleccionadasNoCancelablesFA > 0 Then
        '        show_message("Advertencia", "No puede cancelar un documento de Facturación Anticipada que ya ha sido confirmado, TI le indicará como hacer la cancelación.")
        '        DocumentoSeleccionadoParaCancelar = 0
        '        ClienteSeleccionadoParaCancelar = 0
        '        Exit Sub
        '    End If



        '    If ObjBUCancelacion.ValidarCancelacion(IdSaySeleccionado) Then

        '    Else
        '        If MesEmisionSeleccionado > 0 And MesEmisionSeleccionado < mesActual Or AnioEmisionSeleccionado < AnioActual Then
        '            If TipoDocumentoSeleccionado = "REMISIÓN" Then
        '                show_message("AdvertenciaGrande", "El documento se emitió en un mes anterior al actual." + vbLf + "Favor de comunicarse al departamento de Cobranza, proporcione la siguiente información:" + vbLf +
        '                                        "Cliente: " + NombreClienteSeleccionado + "" + vbLf +
        '                                        "Tipo: " + TipoDocumentoSeleccionado + "" + vbLf +
        '                                        "Fecha de emisión: " + DateTime.Parse(FechaEmisionSeleccionado).ToString("dd/MM/yyyy") + "" + vbLf +
        '                                        "Documento: " + DocumentoIdSeleccionado.ToString() + "")
        '                DocumentoSeleccionadoParaCancelar = 0
        '                ClienteSeleccionadoParaCancelar = 0
        '                Exit Sub
        '            Else
        '                ''SE COMENTA YA QUE ESTA VALIDACION VIENE DESDE LA SOLICITUD DE CANCELACION 
        '                'show_message("AdvertenciaGrande", "El documento se emitió en un mes anterior al actual." + vbLf + "Favor de comunicarse al departamento de Cobranza, proporcione la siguiente información:" + vbLf +
        '                '                        "Cliente: " + NombreClienteSeleccionado + "" + vbLf +
        '                '                        "Tipo: " + TipoDocumentoSeleccionado + "" + vbLf +
        '                '                        "Fecha de emisión: " + DateTime.Parse(FechaEmisionSeleccionado).ToString("dd/MM/yyyy") + "" + vbLf +
        '                '                        "Documento: " + DocumentoIdSeleccionado.ToString() + "" + vbLf +
        '                '                        "Folio Factura: " + FolioFacturaSeleccionado + "")
        '            End If
        '            'DocumentoSeleccionadoParaCancelar = 0
        '            'ClienteSeleccionadoParaCancelar = 0
        '            Cursor = Cursors.Default

        '            'Exit Sub
        '        End If

        '    End If

        '    If ObjBUCancelacion.consultaMovimientosPorDocumento(DocumentoIdSeleccionado, Year(FechaEmisionSeleccionado)).Rows(0).Item("Movimientos") > 0 Then

        '        If TipoDocumentoSeleccionado = "REMISIÓN" Then
        '            show_message("AdvertenciaGrande", "El documento tiene notas de crédito/cargo, ajustes y/o pagos relacionados. Es necesario cancelar primero las notas/pagos/aplicaciones. Favor de comunicarse al departamento de Cobranza, proporcione la siguiente información:" + vbLf +
        '                                            "Cliente: " + NombreClienteSeleccionado + "" + vbLf +
        '                                            "Tipo: " + TipoDocumentoSeleccionado + "" + vbLf +
        '                                            "Documento: " + DocumentoIdSeleccionado.ToString() + "")
        '        Else
        '            show_message("AdvertenciaGrande", "El documento tiene notas de crédito/cargo, ajustes y/o pagos relacionados. Es necesario cancelar primero las notas/pagos/aplicaciones. Favor de comunicarse al departamento de Cobranza, proporcione la siguiente información:" + vbLf +
        '                                            "Cliente: " + NombreClienteSeleccionado + "" + vbLf +
        '                                            "Tipo: " + TipoDocumentoSeleccionado + "" + vbLf +
        '                                            "Documento: " + DocumentoIdSeleccionado.ToString() + "" + vbLf +
        '                                            "Folio Factura: " + FolioFacturaSeleccionado + "")
        '        End If

        '        DocumentoSeleccionadoParaCancelar = 0
        '        ClienteSeleccionadoParaCancelar = 0
        '        Cursor = Cursors.Default

        '        Exit Sub

        '    End If


        'Catch

        '    show_message("Error", "Ocurrio un error al seleccionar el documento. Por favor intente de nuevo")

        'End Try

        'Cursor = Cursors.Default

    End Sub

    Public Sub RecargarDatos()
        btnAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnReintentarCancelacion_Click(sender As Object, e As EventArgs) Handles btnReintentarCancelacion.Click
        Dim CancelacionTimbrada As Boolean = False
        Dim ObjBU As New Negocios.CancelacionDocumentosBU
        Dim DocumentoSeleccionadoCancelar As New List(Of Entidades.FacturaCancelada)
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim DocumentosCancelados As Integer = 0
        Dim DocuemntosNoCancelados As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim RutaPDFFactura As String = String.Empty
        Dim entFactura As New Entidades.DatosFactura


        DocumentoSeleccionadoCancelar = obtenerDocumentoReintentarCancelacion()

        Cursor = Cursors.WaitCursor


        If DocumentoSeleccionadoCancelar.Count <> 0 Then
            Dim confirmacion As New Tools.ConfirmarForm
            confirmacion.mensaje = "¿Está seguro de reintentar la cancelación ante el SAT de la factura seleccionada?."
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    For Each Fila As Entidades.FacturaCancelada In DocumentoSeleccionadoCancelar
                        FilasSeleccionadas += 1
                        If objBUTimbrado.CancelarFactura(Fila.DocumentoID, Fila.UUID, Fila.EmpresaID, Fila.TipoComprobante, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) = True Then
                            'ObjBU.cambiarStatusDocumentoCanceladoSAT(Fila.DocumentoID)
                            If objBUTimbrado.GenerarPDFFacturaCancelada(Fila.DocumentoID, "FACTURACALZADO") = True Then
                                RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(Fila.DocumentoID)
                                AbrirPDFFactura(RutaPDFFactura)
                            End If
                            entFactura = objBUTimbrado.ConsultarRutasDocumento(Fila.DocumentoID)
                            objBUTimbrado.CancelarDocumentoSICY(entFactura.RemisionID, entFactura.Año, entFactura.UUID, entFactura.RutaXML, entFactura.RutaPDF)

                            DocumentosCancelados += 1
                        Else
                            DocuemntosNoCancelados += 1
                        End If
                    Next
                    If FilasSeleccionadas > 0 Then
                        If DocuemntosNoCancelados > 0 Then
                            show_message("Exito", "Se han cancelado " & DocumentosCancelados.ToString() & " de " & FilasSeleccionadas.ToString() & ".")
                        Else
                            show_message("Exito", "Documentos cancelados correctamente ante SAT")
                        End If
                    Else
                        show_message("Advertencia", "No se ha seleccionado un documento para cancelar.")
                    End If


                    ''CancelacionTimbrada = "AGREGAR AQUI FUNCION DE CANCELACION"
                    'If CancelacionTimbrada = True Then

                    '    ObjBU.cambiarStatusDocumentoCanceladoSAT(DocumentoSeleccionadoCancelar)
                    '    show_message("Exito", "Documento cancelado correctamente ante SAT")
                    '    btnAceptar_Click(Nothing, Nothing)
                    'Else

                    '    show_message("Advertencia", "La cancelación ante el SAT no se pudo realizar, intente más tarde")

                    'End If

                    btnAceptar_Click(Nothing, Nothing)
                Catch ex As Exception
                    show_message("Error", "Ocurrio un error al cancelar, intente de nuevo")
                End Try
            End If
        End If

        Cursor = Cursors.Default

    End Sub

    'Private Function obtenerDocumentoReintentarCancelacion() As Integer

    '    Dim DocumentoIdSeleccionadoParaReintentarCancelacion As Integer = 0

    '    Dim NumeroFilas As Integer
    '    Dim FilasSeleccionadasReintentarCancelacion As Integer = 0
    '    Dim FilasSeleccionadasNoPosibleReintentarCancelacion As Integer = 0

    '    Cursor = Cursors.WaitCursor

    '    Try

    '        NumeroFilas = bgvDocumentos.DataRowCount
    '        For index As Integer = 0 To NumeroFilas Step 1

    '            If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
    '                If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo") = "F" Then

    '                    FilasSeleccionadasReintentarCancelacion += 1

    '                    If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id") <> 167 Then
    '                        FilasSeleccionadasNoPosibleReintentarCancelacion += 1
    '                    End If

    '                    DocumentoIdSeleccionadoParaReintentarCancelacion = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "tabla_documentoid")
    '                End If
    '            End If
    '        Next

    '        If FilasSeleccionadasReintentarCancelacion = 0 Then
    '            show_message("Advertencia", "Debe seleccionar una factura para reintentar cancelación en SAT.")
    '            Cursor = Cursors.Default

    '            Return 0

    '            Exit Function
    '        End If

    '        If FilasSeleccionadasReintentarCancelacion > 1 Then
    '            show_message("Advertencia", "Solo se puede reintentar cancelar en SAT una factura a la vez")
    '            Cursor = Cursors.Default

    '            Return 0

    '            Exit Function
    '        End If

    '        If FilasSeleccionadasReintentarCancelacion = 1 And FilasSeleccionadasNoPosibleReintentarCancelacion Then
    '            show_message("Advertencia", "Solo se puede reintentar cancelar en SAT las facturas en status ""CANCELADA (FALTA SAT)"". ")
    '            Cursor = Cursors.Default

    '            Return 0

    '            Exit Function
    '        End If


    '    Catch

    '        show_message("Error", "Ocurrio un error al seleccionar el documento. Por favor intente de nuevo")

    '    End Try

    '    Cursor = Cursors.Default

    '    Return DocumentoIdSeleccionadoParaReintentarCancelacion

    'End Function

    Private Function obtenerDocumentoReintentarCancelacion() As List(Of Entidades.FacturaCancelada)

        Dim DocumentoIdSeleccionadoParaReintentarCancelacion As Integer = 0
        Dim DocumentoCancelar As New Entidades.FacturaCancelada
        Dim ListaDocumentoCancelar As New List(Of Entidades.FacturaCancelada)
        Dim NumeroFilas As Integer
        Dim FilasSeleccionadasReintentarCancelacion As Integer = 0
        Dim FilasSeleccionadasNoPosibleReintentarCancelacion As Integer = 0

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo") = "F" Then

                        FilasSeleccionadasReintentarCancelacion += 1

                        If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id") <> 167 Then
                            FilasSeleccionadasNoPosibleReintentarCancelacion += 1
                        ElseIf bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id") = 167 Then
                            DocumentoCancelar.DocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                            DocumentoCancelar.UUID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Folio Fiscal")
                            DocumentoCancelar.EmpresaID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "EmpresaID")
                            DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                            DocumentoCancelar.TipoComprobante = "    FACTURACALZADO"
                            ListaDocumentoCancelar.Add(DocumentoCancelar)
                        End If
                        DocumentoIdSeleccionadoParaReintentarCancelacion = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "tabla_documentoid")
                    End If
                End If
            Next

            If FilasSeleccionadasReintentarCancelacion = 0 Then
                show_message("Advertencia", "Debe seleccionar una factura para reintentar cancelación en SAT.")
                Cursor = Cursors.Default
                ListaDocumentoCancelar.Clear()
                Return ListaDocumentoCancelar

                Exit Function
            End If

            If FilasSeleccionadasReintentarCancelacion > 1 Then
                show_message("Advertencia", "Solo se puede reintentar cancelar en SAT una factura a la vez")
                Cursor = Cursors.Default
                ListaDocumentoCancelar.Clear()
                Return ListaDocumentoCancelar

                Exit Function
            End If

            If FilasSeleccionadasReintentarCancelacion = 1 And FilasSeleccionadasNoPosibleReintentarCancelacion Then
                show_message("Advertencia", "Solo se puede reintentar cancelar en SAT las facturas en status ""CANCELADA (FALTA SAT)"". ")
                Cursor = Cursors.Default
                ListaDocumentoCancelar.Clear()
                Return ListaDocumentoCancelar

                Exit Function
            End If


        Catch

            show_message("Error", "Ocurrio un error al seleccionar el documento. Por favor intente de nuevo")

        End Try

        Cursor = Cursors.Default

        Return ListaDocumentoCancelar

    End Function


    Private Sub tsmiRegenerarPDF_Click(sender As Object, e As EventArgs) Handles tsmiRegenerarPDF.Click
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim DocumentoID As Integer = 0
        Dim RutaPDF As String = String.Empty
        Dim PDFGeneradosCorretamente As Integer = 0
        Dim PDFNoGenerados As Integer = 0
        Dim TipoComprobante As String = String.Empty
        Dim PDFGenerado As Boolean = False
        Dim DocumentoStatus As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    DocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                    TipoComprobante = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")
                    DocumentoStatus = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id")

                    If TipoComprobante = "F" Then
                        TipoComprobante = "FACTURACALZADO"
                    ElseIf TipoComprobante = "R" Then
                        TipoComprobante = "REMISION"
                    End If

                    If TipoComprobante = "FACTURACALZADO" Then
                        If DocumentoStatus = 158 Then
                            PDFGenerado = objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoID, TipoComprobante)
                        ElseIf DocumentoStatus = 157 Then
                            PDFGenerado = objBUTimbrado.GenerarPDFFactura(DocumentoID, TipoComprobante)
                        End If

                        If PDFGenerado = True Then
                            RutaPDF = objBUTimbrado.ObtenerRutaPDFFactura(DocumentoID)
                            If String.IsNullOrEmpty(RutaPDF) = False Then
                                AbrirPDFFactura(RutaPDF)
                                PDFGeneradosCorretamente += 1
                            Else
                                PDFNoGenerados += 1
                            End If
                        Else
                            PDFNoGenerados += 1
                        End If

                    ElseIf TipoComprobante = "REMISION" Then
                        If DocumentoStatus = 158 Then
                            If objBUTimbrado.ImprimirRemisionCancelada(DocumentoID) = True Then
                                PDFGeneradosCorretamente += 1
                            Else
                                PDFNoGenerados += 1
                            End If
                        ElseIf DocumentoStatus = 157 Then
                            If objBUTimbrado.ImprimirRemision(DocumentoID) = True Then
                                PDFGeneradosCorretamente += 1
                            Else
                                PDFNoGenerados += 1
                            End If
                        End If
                    End If
                End If
            Next

            Dim Mensaje As String = String.Empty
            If FilasSeleccionadas > 0 Then
                If PDFNoGenerados > 0 Then
                    Mensaje = "PDF no generados: " & PDFNoGenerados.ToString() & "."
                    show_message("Advertencia", Mensaje)
                Else
                    '  show_message("Exito", "Los documentos seleccionados no se timbraron, intente mas tarde o cancele el documento.")
                End If
            Else
                show_message("Advertencia", "No se han seleccionado documentos para timbrar.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tsmiReimprimirPDF_Click(sender As Object, e As EventArgs) Handles tsmiReimprimirPDF.Click
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim DocumentoID As Integer = 0
        Dim RutaPDF As String = String.Empty
        Dim PDFGeneradosCorretamente As Integer = 0
        Dim PDFNoGenerados As Integer = 0
        Dim TipoComprobante As String = String.Empty
        Dim DocumentoStatus As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    DocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                    TipoComprobante = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")
                    DocumentoStatus = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id")

                    If TipoComprobante = "F" Then
                        TipoComprobante = "FACTURACALZADO"
                    ElseIf TipoComprobante = "R" Then
                        TipoComprobante = "REMISION"
                    End If

                    If TipoComprobante = "FACTURACALZADO" Then
                        RutaPDF = objBUTimbrado.ObtenerRutaPDFFactura(DocumentoID)
                        If String.IsNullOrEmpty(RutaPDF) = False Then
                            AbrirPDFFactura(RutaPDF)
                            PDFGeneradosCorretamente += 1
                        Else
                            PDFNoGenerados += 1
                        End If
                    ElseIf TipoComprobante = "REMISION" Then
                        If DocumentoStatus = 157 Then
                            If objBUTimbrado.ImprimirRemision(DocumentoID) = True Then
                                PDFGeneradosCorretamente += 1
                            Else
                                PDFNoGenerados += 1
                            End If
                        ElseIf DocumentoStatus = 158 Then
                            If objBUTimbrado.ImprimirRemisionCancelada(DocumentoID) = True Then
                                PDFGeneradosCorretamente += 1
                            Else
                                PDFNoGenerados += 1
                            End If
                        End If


                    End If
                End If
            Next

            Dim Mensaje As String = String.Empty
            If FilasSeleccionadas > 0 Then
                If PDFNoGenerados > 0 Then
                    Mensaje = "PDF no generados: " & PDFNoGenerados.ToString() & "."
                    show_message("Advertencia", Mensaje)
                    'Else
                    '    show_message("Exito", "Los documentos seleccionados no se timbraron, intente mas tarde o cancele el documento.")
                End If
            Else
                show_message("Advertencia", "No se han seleccionado documentos para reimprimir.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnTimbrarDocumento_Click(sender As Object, e As EventArgs) Handles btnTimbrarDocumento.Click
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim DocumentoIDSeleccionado As Integer = 0
        Dim TipoComprobante As String = String.Empty
        Dim ResultadoTimbrado As Boolean = False
        Dim FacturasTimbradas As Integer = 0
        Dim FacturasNoTimbradas As Integer = 0
        Dim ClienteID As Integer = 0
        Dim RutaPDFFactura As String = String.Empty
        Dim EmpresaDocumentoID As Integer = 0
        Dim TipoDocumento As String = String.Empty
        Dim FilasRemisiones As Integer = 0
        Dim StatusDocumento As Integer = 0
        Dim RemisionID As Integer = 0
        Dim objBuVistaPrevia As New Negocios.VistaPreviaDocumentosBU
        Dim dtRemision As New DataTable
        Dim DocumentosErrorTimbrado As Integer = 0
        Dim DocumentoNoTimbrados As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            btnTimbrarDocumento.Enabled = False
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    DocumentoIDSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                    ClienteID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "cliente_id")
                    EmpresaDocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "EmpresaID")
                    TipoDocumento = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")
                    StatusDocumento = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id")
                    RemisionID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Docto")

                    If TipoDocumento = "F" Then
                        If RemisionID = 0 Then
                            dtRemision = objBuVistaPrevia.ReplicarDocumentos_SAY_SICY(DocumentoIDSeleccionado, ParidadDocumetoExtranjero)

                            If dtRemision.Rows.Count > 0 Then
                                RemisionID = dtRemision.Rows(0).Item(0)
                            Else
                                RemisionID = 0
                            End If
                        End If
                    Else
                        FilasRemisiones += 1
                    End If


                    If RemisionID > 0 Then
                        If TipoDocumento = "F" Then
                            If StatusDocumento = 156 Then 'Por timbrar
                                'Genera la informacion para el timbrado y realiza el timbre
                                objBUTimbrado.GenerarInformacionTimbrado(DocumentoIDSeleccionado, "F")
                                ResultadoTimbrado = objBUTimbrado.TimbrarFactura(DocumentoIDSeleccionado, EmpresaDocumentoID, "FACTURACALZADO")
                                If ResultadoTimbrado = True Then
                                    FacturasTimbradas += 1
                                    'Si es COPPEL Agregar Addenda 
                                    If ClienteID = 763 Then
                                        objBUTimbrado.GenerarAddendaCOPPEL(DocumentoIDSeleccionado, "FACTURACALZADO")
                                    Else
                                        objBuVistaPrevia.GeneraRegistgrosSalidaDocumento(DocumentoIDSeleccionado)
                                    End If
                                    'Generar PDF                                                                        
                                    If objBUTimbrado.GenerarPDFFactura(DocumentoIDSeleccionado, "FACTURACALZADO") = True Then
                                        RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(DocumentoIDSeleccionado)
                                        AbrirPDFFactura(RutaPDFFactura)
                                        'Enviar Correo
                                        enviarCorreoFacturacionCliente(DocumentoIDSeleccionado)
                                    End If
                                Else
                                    If DocumentoNoTimbrados = String.Empty Then
                                        DocumentoNoTimbrados = DocumentoIDSeleccionado.ToString()
                                    Else
                                        DocumentoNoTimbrados &= "," & DocumentoIDSeleccionado.ToString()
                                    End If

                                    FacturasNoTimbradas += 1
                                End If
                            End If
                        Else
                            FilasRemisiones += 1
                        End If

                    Else

                        FacturasNoTimbradas += 1
                        If DocumentoNoTimbrados = String.Empty Then
                            DocumentoNoTimbrados = DocumentoIDSeleccionado.ToString()
                        Else
                            DocumentoNoTimbrados &= "," & DocumentoIDSeleccionado.ToString()
                        End If
                        objBUTimbrado.InsertarErrorAlTimbrar(DocumentoIDSeleccionado, "FACTURACALZADO", "NA", "No se genero un número de remisión.")
                        show_message("Advertencia", "Error al generar la remision.")
                    End If

                End If
            Next

            If FilasSeleccionadas > 0 Then
                If FilasSeleccionadas = FilasRemisiones Then
                    show_message("Advertencia", "Solo se pueden timbrar los tipos de documento factura.")
                Else
                    If FacturasTimbradas > 0 Then
                        If FacturasNoTimbradas > 0 Then
                            show_message("Exito", "Se han timbrado " & FacturasTimbradas.ToString & " de " & FilasSeleccionadas.ToString())
                        Else
                            show_message("Exito", "Se han timbrado " & FacturasTimbradas.ToString)
                        End If
                    Else
                        show_message("Advertencia", "No se timbro los documentos seleccionados.")
                    End If
                End If

                'Mostrar los documentos no timbrados
                If FacturasNoTimbradas > 0 Then
                    Dim form As New ErroresTimbradoForm
                    form.DocumentoID = DocumentoNoTimbrados
                    form.TipoComprobante = "FACTURACALZADO"
                    form.Show()
                End If
            End If
            ConsultaAdministradorDocumentos()
            btnTimbrarDocumento.Enabled = True
            Cursor = Cursors.Default
        Catch ex As Exception
            btnTimbrarDocumento.Enabled = True
            show_message("Error", ex.Message.ToString())
            ConsultaAdministradorDocumentos()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Function ObtenerInformacionDocumentoCancelar(ByVal DocumentoId As Integer) As Entidades.FacturaCancelada
        Dim ent As New Entidades.FacturaCancelada
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim DocumentoIDSeleccionado As Integer = 0
        Dim TipoComprobante As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    DocumentoIDSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                    If DocumentoId = DocumentoIDSeleccionado Then
                        ent.DocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                        ent.UUID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Folio Fiscal")
                        TipoComprobante = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")
                        ent.EmpresaID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "EmpresaID")
                        ent.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        ent.EstatusID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id")

                        If TipoComprobante = "F" Then
                            TipoComprobante = "FACTURACALZADO"
                        ElseIf TipoComprobante = "R" Then
                            TipoComprobante = "REMISION"
                        End If
                        ent.TipoComprobante = TipoComprobante
                    End If

                End If
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
        Return ent
    End Function

    Private Sub AbrirPDFFactura(ByVal RutaPDF As String)
        Try
            'Dim objFTP As New Tools.TransferenciaFTP
            'objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Carga_Proyeccion_V1.pdf")
            Process.Start(RutaPDF)
        Catch ex As Exception
        End Try
    End Sub





    Private Function enviarCorreoFacturacionCliente(ByVal IdDocumento As Integer) As Boolean
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New Negocios.VistaPreviaDocumentosBU
        Dim dtDatosDocumento As New DataTable()
        Dim folioFactura As String = String.Empty
        Dim nombreCliente As String = String.Empty
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Dim correoCliente As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim objTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim StatusCorreo As Boolean = False


        Try
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            dtDatosDocumento = objBU.consultaDatosDocumentoEnvioFactura(IdDocumento)


            folioFactura = dtDatosDocumento.Rows(0).Item("FolioFactura")
            nombreCliente = dtDatosDocumento.Rows(0).Item("NombreCliente")
            rutaArchivoPDF = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RutaPDF")), "", dtDatosDocumento.Rows(0).Item("RutaPDF"))
            rutaArchivoXML = If(IsDBNull(dtDatosDocumento.Rows(0).Item("RutaXML")), "", dtDatosDocumento.Rows(0).Item("RutaXML"))
            correoCliente = dtDatosDocumento.Rows(0).Item("CorreoReceptor")

            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()

            'rutaArchivoPDF = "\\192.168.2.2\bin\TASFE\MafraMCV0902263W7\FACTURAS33\PDF\112017\MCV0902263W7F1FAC42781.pdf"
            'archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
            'lstArchivoAdjuntos.Add(archivoAdjunto)

            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If correoCliente <> String.Empty Then
                If destinatarios <> String.Empty Then
                    destinatarios = destinatarios & "," & correoCliente
                Else
                    destinatarios = correoCliente
                End If
            End If

            asuntoCorreo = "FACTURA " + folioFactura + " CLIENTE " + nombreCliente + ""
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en facturación, ya sea por Razón Social, Domicilio Fiscal, Forma de Pago, Importe máximo de facturación etc. se realizará UNICAMENTE dentro de los primeros 7 días posteriores a la expedición de la factura; pasando este lapso de días no se harán cambios. </li>" +
                            "<li> En caso de errores en el domicilio fiscal solo verá reflejados los cambios en el archivo PDF, ya que de acuerdo a disposición del SAT en el archivo XML estos campos ya no existen. </li>" +
                            "<li> No se podrá hacer cancelaciones de facturas que ya hayan sido pagadas. </li>" +
                            "<li> No procederá la cancelación de un CFDI que se haya facturado conforme a los datos proporcionados por usted al momento de hacer su pedido. </li>" +
                            "<li> De acuerdo a lo establecido en la guía del llenado de los comprobantes fiscales del ""Anexo 20 SAT"" cuando la clave de uso registrada en el CFDI es incorrecta no será motivo de cancelación ni afectará para deducción o acreditamiento. Sin embargo, se recomienda que en el momento que se percaten del error soliciten su corrección para la siguiente facturación.</li>" +
                            "<li> No procederá hacer cancelaciones de cambios en la Clave del producto ya que está es asignada por la empresa que emite el CFDI, por lo tanto es nuestra responsabilidad que este indicada correctamente.</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(destinatarios, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

            If entCorreo.CorreoEnviado = True Then
                CorreoEnviado = "S"
                StatusCorreo = True
            Else
                CorreoEnviado = "N"
                StatusCorreo = False
            End If
            'Obtiene los datos de la factura
            'entDatosFactura = objTimbrado.ConsultarInformacionDocumentoFactura(IdDocumento)

            'Actualizar Status Correo Enviado SAY
            objBU.ActualizarStatusCorreoEnviadoSAY(IdDocumento, entCorreo.CorreoEnviado)

            'Insettar los datos de envio en el SICY
            If rutaArchivoPDF <> String.Empty Then
                objBU.InsertarDatosCorreoEnviadoSICY(destinatarios, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, asuntoCorreo, entCorreo.DescripcionStatusCorreo, entDatosFactura.RemisionID, "PDF", False)
            End If

            If rutaArchivoXML <> String.Empty Then
                objBU.InsertarDatosCorreoEnviadoSICY(destinatarios, CorreoEnviado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, asuntoCorreo, entCorreo.DescripcionStatusCorreo, entDatosFactura.RemisionID, "XML", False)
            End If

        Catch ex As Exception
            StatusCorreo = False
        End Try

        Return StatusCorreo

    End Function

    Private Sub btnEnvioCorreo_Click_1(sender As Object, e As EventArgs) Handles btnEnvioCorreo.Click
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim DocumentoID As Integer = 0
        Dim RutaPDF As String = String.Empty
        Dim PDFGeneradosCorretamente As Integer = 0
        Dim PDFNoGenerados As Integer = 0
        Dim TipoComprobante As String = String.Empty
        Dim CorreoEnviado As Integer = 0
        Dim DocumentosRemisiones As Integer = 0
        Dim CorreoNoEnviado As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    DocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                    TipoComprobante = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")

                    If TipoComprobante = "F" Then
                        TipoComprobante = "FACTURACALZADO"
                    ElseIf TipoComprobante = "R" Then
                        TipoComprobante = "REMISION"
                    End If

                    If TipoComprobante = "FACTURACALZADO" Then
                        'If enviarCorreoFacturacionCliente(DocumentoID) = True Then
                        If objBUTimbrado.EnviarCorreoFactura(DocumentoID) = True Then
                            CorreoEnviado += 1
                        Else
                            CorreoNoEnviado += 1
                        End If
                    ElseIf TipoComprobante = "REMISION" Then
                        DocumentosRemisiones += 1
                    End If
                End If
            Next

            If FilasSeleccionadas = 0 Then
                show_message("Advertencia", "Se debe de seleccionar una Factura.")
            ElseIf FilasSeleccionadas = DocumentosRemisiones Then
                show_message("Advertencia", "Solo los documentos de tipo factura se pueden enviar por correo.")
            ElseIf FilasSeleccionadas = CorreoNoEnviado Then
                show_message("Advertencia", "El correo de los documentos seleccionados no fue enviado. Asegurese que la dirección de correo es correcta.")
            Else
                If CorreoNoEnviado > 0 And CorreoEnviado > 0 Then
                    show_message("Exito", "Se han enviado " & CorreoEnviado.ToString & " correos " & vbCrLf & " Correos no enviados: " & CorreoNoEnviado.ToString)
                ElseIf CorreoNoEnviado > 0 Then
                    show_message("Advertencia", "Correo no enviado asegurese que los documentos son de tipo factura.")
                Else
                    show_message("Exito", "Se han enviado " & CorreoEnviado.ToString & " correos.")
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
    End Sub



    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    Dim OBJ As New Facturacion.Negocios.FacturasBU
    '    OBJ.cancelarfac("81f97868-f91e-4d6b-960b-5bd87323df92")
    'End Sub

    Private Sub btnGeneraAddenda_Click(sender As Object, e As EventArgs) Handles btnGeneraAddenda.Click
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim DocumentoIDSeleccionado As Integer = 0
        Dim TipoComprobante As String = String.Empty
        Dim ResultadoTimbrado As Boolean = False
        Dim FacturasTimbradas As Integer = 0
        Dim FacturasNoTimbradas As Integer = 0
        Dim ClienteID As Integer = 0
        Dim RutaPDFFactura As String = String.Empty
        Dim EmpresaDocumentoID As Integer = 0
        Dim TipoDocumento As String = String.Empty
        Dim FilasRemisiones As Integer = 0
        Dim StatusDocumento As Integer = 0
        Dim generados As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            btnTimbrarDocumento.Enabled = False
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    DocumentoIDSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "IdDocumento")
                    ClienteID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "cliente_id")
                    EmpresaDocumentoID = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "EmpresaID")
                    TipoDocumento = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")
                    StatusDocumento = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "status_id")

                    If ClienteID = 763 Then
                        objBUTimbrado.GenerarAddendaCOPPEL(DocumentoIDSeleccionado, "FACTURACALZADO")
                        generados += 1
                    End If

                End If
            Next
            If generados > 0 Then
                show_message("Exito", "Se ha generado la addenda de: " & generados.ToString)
            Else
                show_message("Advertencia", "Solo se puede generar las addendas de coppel.")
            End If

            btnTimbrarDocumento.Enabled = True
            Cursor = Cursors.Default
        Catch ex As Exception
            btnTimbrarDocumento.Enabled = True
            show_message("Error", ex.Message.ToString())
            ConsultaAdministradorDocumentos()
            Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub btnExportarReporte_Click(sender As Object, e As EventArgs) Handles btnExportarReporte.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Dim nombreReporteParaExportacion As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            CargarInformacionReporteFacturas()
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "\ReporteFacturas_"

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

                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        End If
                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                show_message("Aviso", "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub CargarInformacionReporteFacturas()
        Dim objFiltrosAdministrador = obtenerFiltrosAdministradorDocumentos()
        With objFiltrosAdministrador
            grdReporte.DataSource = ObjBU.ConsultarReporteFacturas(.DocumentoId, .StatusID, .FolioOT, .ClienteId, .EmisorId, .FechaInicio, .FechaTermino)
        End With
    End Sub

    Public Sub EnviarRefacturar()
        Dim NumeroFilas = bgvDocumentos.DataRowCount
        Dim seleccionados As Int16 = 0
        Dim indexSeleccionado As Integer = 0
        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                seleccionados += 1
                indexSeleccionado = index
                If seleccionados > 1 Then
                    Dim FormularioAlerta As New AdvertenciaForm
                    FormularioAlerta.mensaje = "Hay más de un documento seleccionado. Esta operación solo se puede realizar con un registro a la vez"
                    FormularioAlerta.ShowDialog()
                    Return
                End If
            End If
        Next

        If seleccionados = 0 Then
            Dim FormularioAlerta As New AdvertenciaForm
            FormularioAlerta.mensaje = "No se ha seleccionado ningún documento"
            FormularioAlerta.ShowDialog()
        ElseIf bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "RNC") = "NO" And bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "SNC") = "SI" And bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Notas de Crédito").ToString.Length > 0 Then
            Dim cliente As String = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Cliente").ToString
            Dim doctoSay As String = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Docto").ToString
            Dim remisionFactura As String
            Dim idRemision As Integer = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Docto")
            Dim anio As Integer = Year(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "F Captura"))
            If bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Tipo").ToString = "R" Then
                remisionFactura = "-Remisión: " & bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Docto").ToString & "-" & anio
            Else
                remisionFactura = "-Factura: " & bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(indexSeleccionado), "Factura").ToString
            End If

            Dim FormularioConfirmar As New confirmarFormGrande
            FormularioConfirmar.mensaje = "Esta acción enviará los pares de las OT del documento seleccionado a POR FACTURAR/ REFACTURAR " & vbCrLf &
                                        "-Cliente: " & cliente & vbCrLf &
                                        "-DoctoSAY:" & doctoSay & vbCrLf &
                                        "" & remisionFactura & vbCrLf &
                                        "Será necesario solicitar a Facturación que genere nuevamente el documento" & vbCrLf &
                                        "¿ Desea continuar ?" & vbCrLf &
                                        "(Una vez realizada esta acción, no se podrá revertir)"
            FormularioConfirmar.ShowDialog()
            If FormularioConfirmar.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim objBu As New Negocios.AdministradorDocumentosBU()
                objBu.EnviarRefacturar(idRemision, anio)
                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Documento cambiado a refacturar"
                FormularioMensaje.ShowDialog()
            End If
        Else
            Dim FormularioAlerta As New AdvertenciaForm
            FormularioAlerta.mensaje = "Solo puede enviar a refacturar documentos con RNC=NO, SNC=SI y al menos una nota de crédito"
            FormularioAlerta.ShowDialog()
        End If
    End Sub

    Private Sub btnActualizarEstatusCancelacionSAT_Click(sender As Object, e As EventArgs) Handles btnActualizarEstatusCancelacionSAT.Click
        Dim dt As DataTable
        Dim DocumentoID, empresaID As Integer
        Dim UUID As String = String.Empty
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU

        Try
            Me.Cursor = Cursors.WaitCursor
            btnActualizarEstatusCancelacionSAT.Enabled = False
            pnPBar.Left = (grdDocumentos.Width - pnPBar.Width) / 2
            pnPBar.Top = (grdDocumentos.Height - pnPBar.Height) / 2
            pnPBar.Visible = True
            lblInfo.Text = "Conectando a SAT... recuperando respuestas de cancelaciones en espera de aceptación…"

            'lblInfo.Left = (pnPBar.Width - lblInfo.Width) / 2
            'lblInfo.Top = (pnPBar.Height - lblInfo.Height) / 2
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
            dt = ObjBU.ConsultaCancelacionEstatusSAT
            For Each row As DataRow In dt.Rows
                DocumentoID = 0
                empresaID = 0
                UUID = String.Empty
                DocumentoID = IIf(IsDBNull(row.Item("documentoid")), 0, row.Item("documentoid"))
                UUID = IIf(IsDBNull(row.Item("uuid")), "", row.Item("uuid"))
                empresaID = row.Item("EmpresaID") '- -IIf(IsDBNull(row.Item("EmpresaID")), 0, IsDBNull(row.Item("EmpresaID")))
                If objBUTimbrado.CancelarFactura(DocumentoID, UUID, empresaID, "FACTURACALZADO", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) Then
                    If objBUTimbrado.GenerarPDFFacturaCancelada(DocumentoID, "FACTURACALZADO") = True Then
                    End If
                End If
            Next
            objCancelacion.EjecutaRevisionCancelacionesPendientes()
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
            pnPBar.Visible = False
            Controles.Mensajes_Y_Alertas("EXITO", "Proceso terminado.")
            btnAceptar_Click(Nothing, Nothing)
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            btnActualizarEstatusCancelacionSAT.Enabled = True
            pnPBar.Visible = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCargarPDF_XML_Click(sender As Object, e As EventArgs) Handles btnCargarPDF_XML.Click
        Dim AnexarArchivo As New AnexarArchivosDocumentosExternosForm
        Dim objBU As New Negocios.AdministradorOTFacturacionBU
        Dim Filas As Integer = 0
        Dim entCliente As Entidades.Cliente
        Dim FilaSel As Integer

        Dim NumeroFilas = bgvDocumentos.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                Filas += 1
                If Filas = 1 Then
                    FilaSel = bgvDocumentos.FocusedRowHandle
                End If
            End If
        Next

        If Filas > 1 Then
            show_message("Advertencia", "Solo se permite anexar los archivos de un solo documento.")
            Return
        ElseIf Filas = 0 Then
            show_message("Advertencia", "Debe seleccionar un documento de un cliente extranjero para anexar archivos.")
            Return
        End If

        entCliente = objBU.ObtenerInfomracionCliente(bgvDocumentos.GetRowCellValue(FilaSel, "cliente_id"))

        If entCliente.tipocliente.tipoclienteid <> 2 Then
            show_message("Advertencia", "Solo se permiten anexar archivos de clientes extranjeros.")
            Return
        End If

        AnexarArchivo.DocumentoID = bgvDocumentos.GetRowCellValue(FilaSel, "tabla_documentoid")
        AnexarArchivo.TotalFactura = bgvDocumentos.GetRowCellValue(FilaSel, "Monto")
        AnexarArchivo.entCliente = entCliente
        AnexarArchivo.ShowDialog()
        btnAceptar_Click(Nothing, Nothing)

    End Sub

    Private Sub btnRefacturar_Click(sender As Object, e As EventArgs) Handles btnRefacturar.Click
        EnviarRefacturar()
    End Sub

    Private Sub grdFolioOT_AfterRowsDeleted(sender As Object, e As EventArgs) Handles grdFolioOT.AfterRowsDeleted
        SeleccionCheckMostrarOT()
    End Sub

    Private Sub chkMostrarOT_Click(sender As Object, e As EventArgs) Handles chkMostrarOT.Click
        SeleccionCheckMostrarOT()
    End Sub

    Private Sub btnGenerarXMLSap_Click(sender As Object, e As EventArgs) Handles btnGenerarXMLSap.Click
        Cursor = Cursors.WaitCursor
        GenerarXMLSAP()
        Cursor = Cursors.Default
    End Sub

    Public Sub GenerarXMLSAP()
        Dim objBU As New Negocios.AdministradorDocumentosBU
        Dim dtArchivosXML As New DataTable
        Dim fecha As Date = Date.Now
        Dim archivoXML As String
        Dim contador As Integer = 1
        Dim FechaInicio As Date
        Dim FechaFin As Date
        Dim documentosSeleccionados As String = String.Empty


        FechaInicio = dtpFechaInicio.Value.ToShortDateString()
        FechaFin = dtpFechaFin.Value.ToShortDateString()

        documentosSeleccionados = obtenerDocumentosSeleccionados()

        If documentosSeleccionados <> "" Then
            dtArchivosXML = objBU.ObtenerArchivosXMLSAP(FechaInicio, FechaFin, documentosSeleccionados)
        Else
            dtArchivosXML = objBU.ObtenerArchivosXMLSAP(FechaInicio, FechaFin, "")
        End If

        If dtArchivosXML.Rows.Count > 0 Then
            Try
                For Each xml As DataRow In dtArchivosXML.Rows()

                    archivoXML = "C:\XML SAP\Facturas" + Replace(Date.Now.ToShortDateString(), "/", "") + Replace(Replace(Replace(Date.Now.ToShortTimeString(), " a. m.", ""), " p. m.", ""), ":", "") + "_" + xml.Item("Folio").ToString() + ".XML"


                    If Not System.IO.Directory.Exists("C:\XML SAP\") Then
                        Directory.CreateDirectory("C:\XML SAP\")
                    End If
                    Dim fsXML As Stream = File.Create(archivoXML)
                    Dim swXML As New System.IO.StreamWriter(fsXML)
                    Dim factura As String = String.Empty

                    If xml.Item("xml_factura").ToString.Trim.Length > 0 Then

                        factura = String.Empty
                        factura = xml.Item("xml_factura").ToString.Trim
                        'factura = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + "encoding=" + Chr(34) + "ISO-8859-1" + Chr(34) + "?>" + factura
                        'swXML.WriteLine("<?xml version=" + Chr(34) + "1.0" + Chr(34) + "encoding=" + Chr(34) + "ISO-8859-1" + Chr(34) + "?>")
                        swXML.WriteLine(XElement.Parse(factura))
                    End If
                    swXML.Close()

                    contador += 1

                Next

                contador -= 1

                show_message("Exito", "Se generaron correctamente " + contador.ToString() + " archivos XML")
                btnAceptar_Click(Nothing, Nothing)
            Catch ex As Exception
                Throw ex
                show_message("Error", ex.Message)
            End Try
        Else
            show_message("Advertencia", "No hay facturas por replicar")
        End If
    End Sub




    Private Function ValidarConfirmacionOTCoppel(documentoId As Integer) As Boolean
        Dim objBuC As New Negocios.FacturacionAnticipadaCoppelBU
        Dim correcto As Boolean = 0
        correcto = objBuC.ConsultarConfirmacionDocumento(documentoId)

        Return correcto
    End Function

    Private Sub ObtenerCEDISUsuario()
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

    End Sub

    Private Function SeSeleccionoFactura() As Boolean
        Dim ObjBUCancelacion As New Negocios.CancelacionDocumentosBU
        Dim NumeroFilas As Integer
        Dim FilasSeleccionadasCancelacion As Integer = 0
        Dim FilasSeleccionadasNoCancelables As Integer = 0
        Dim FilasSeleccionadasNoCancelablesFA As Integer = 0 'FA = FACTURACIÓN ANTICIPADA
        Dim ExisteFActura As Boolean = False
        Dim TipoDocumentoSeleccionado As String = String.Empty

        Cursor = Cursors.WaitCursor

        Try
            NumeroFilas = bgvDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadasCancelacion += 1

                    TipoDocumentoSeleccionado = bgvDocumentos.GetRowCellValue(bgvDocumentos.GetVisibleRowHandle(index), "Tipo")
                    If TipoDocumentoSeleccionado = "F" Then
                        ExisteFActura = True
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

        If ExisteFActura = True Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pueden cancelar documentos de tipo Factura")
        End If

        Cursor = Cursors.Default
        Return ExisteFActura

    End Function

    Private Sub btnSolicitarCancelacion_Click(sender As Object, e As EventArgs) Handles btnSolicitarCancelacion.Click
        mostrarPantallaSolicitaCancelacion()
    End Sub
    Public Sub mostrarPantallaSolicitaCancelacion()
        Dim Filas As Integer = 0
        Dim tipo As String = String.Empty
        Dim obDocumneto As New Entidades.DocumentoFactura
        Dim ObjBU As New Negocios.AdministradorOTFacturacionBU
        Dim DocumentoSeleccionado As New Entidades.DocumentoFactura

        Try


            Dim FilaSeleccionada = ObtenerDocumentoSeleccionado()
            If IsNothing(FilaSeleccionada) = False Then
                DocumentoSeleccionado = ObtenerInformacionDocumentoSeleccionado(FilaSeleccionada)
                If DocumentoSeleccionado.IdDocumentoSAY > 0 Then
                    If ValidarDocumentoSeleccionado(DocumentoSeleccionado) = True Then
                        MostrarSolicitud(DocumentoSeleccionado)
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Documento invalido.")
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Function ObtenerInformacionDocumentoSeleccionado(ByVal RowDocumentoSelecionado As DataRow) As Entidades.DocumentoFactura
        Dim EntidadDocumento As New Entidades.DocumentoFactura

        EntidadDocumento.IdDocumentoSAY = RowDocumentoSelecionado.Item("Id SAY")
        EntidadDocumento.Factura = RowDocumentoSelecionado.Item("Factura")
        EntidadDocumento.ClienteId = RowDocumentoSelecionado.Item("cliente_id")
        EntidadDocumento.EmpresaId = RowDocumentoSelecionado.Item("EmpresaID")
        EntidadDocumento.MetodoPago = RowDocumentoSelecionado.Item("metodoPago")
        EntidadDocumento.NombreEmpresa = RowDocumentoSelecionado.Item("nomEmpresa")
        EntidadDocumento.Receptorid = RowDocumentoSelecionado.Item("receptor_id")
        EntidadDocumento.Cliente = RowDocumentoSelecionado.Item("Cliente")
        EntidadDocumento.Tipo = RowDocumentoSelecionado.Item("Tipo")
        EntidadDocumento.StatusID = RowDocumentoSelecionado.Item("status_id")

        Return EntidadDocumento

    End Function

    Private Sub MostrarSolicitud(ByVal DocumentoSeleccionado As Entidades.DocumentoFactura)
        'Dim SolicitarCancelacion As New SolicitudCancelacion
        'Dim InfoCliente As New Entidades.Cliente
        'Dim ObjBU As New Negocios.AdministradorOTFacturacionBU
        'With DocumentoSeleccionado

        '    InfoCliente = ObjBU.ObtenerInfomracionCliente(DocumentoSeleccionado.ClienteId)
        '    SolicitarCancelacion.entCliente = InfoCliente
        '    SolicitarCancelacion.DocumentoID = .IdDocumentoSAY
        '    SolicitarCancelacion.Folio = .Factura
        '    SolicitarCancelacion.MetodoPago = .MetodoPago
        '    SolicitarCancelacion.RfcEmisor = .NombreEmpresa
        '    SolicitarCancelacion.RfcReceptor = DocumentoSeleccionado.Cliente
        '    SolicitarCancelacion.RfcEmisorID = .EmpresaId
        '    SolicitarCancelacion.RfcReceptorID = .Receptorid
        '    SolicitarCancelacion.Cliente = .Cliente
        '    SolicitarCancelacion.ShowDialog()
        'End With
    End Sub

    Private Function ValidarDocumentoSeleccionado(ByVal DocumentoSeleccionado As Entidades.DocumentoFactura) As Boolean
        Dim ObjBU As New Negocios.AdministradorOTFacturacionBU
        Dim ResultadoValidacion As Boolean = False
        Dim dtValidacion As DataTable

        If DocumentoSeleccionado.IdDocumentoSAY > 0 Then


            If DocumentoSeleccionado.Tipo <> "F" Then
                show_message("Advertencia", "Debe seleccionar un documento tipo factura.")
                ResultadoValidacion = False
                Return ResultadoValidacion
            End If

            If DocumentoSeleccionado.StatusID <> 157 Then
                show_message("Advertencia", "Debe seleccionar un documento activo.")
                ResultadoValidacion = False
                Return ResultadoValidacion
            End If

            ''validacion: si el documneto tiene una solicitud activa no puede solictar otra, SI EL MES ANTERIOR YA CUENTA CON 3 DECLARACIONES YA NO SE PUEDE SOLICITAR LA CANCELACION 
            dtValidacion = ObjBU.TieneSolocitudCancelacionActiva(DocumentoSeleccionado.IdDocumentoSAY)

            If dtValidacion.Rows(0).Item("respuesta").ToString = "SI" Then
                ResultadoValidacion = True
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, dtValidacion.Rows(0).Item("msj").ToString)
            End If
        End If
        Return ResultadoValidacion

    End Function


    Private Function ObtenerDocumentoSeleccionado() As DataRow
        Dim FilaSeleccionada As DataRow
        Dim NumeroFilasSeleccionadas As Integer = 0

        Dim DVListadoDocumento As DataView = CType(bgvDocumentos.DataSource, DataView)
        Dim DTResultado As DataTable = DVListadoDocumento.Table.Copy()

        NumeroFilasSeleccionadas = DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item(" ")) = True).Count

        If NumeroFilasSeleccionadas > 1 Then
            show_message("Advertencia", "Solo se permite solicitar cancelación de un solo documento.")
            Return Nothing
        ElseIf NumeroFilasSeleccionadas = 0 Then
            show_message("Advertencia", "Debe seleccionar un documento para solicitar la cancelación.")
            Return Nothing
        End If

        FilaSeleccionada = DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item(" ")) = True).FirstOrDefault()

        Return FilaSeleccionada
    End Function


End Class