Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class frmConsultaListaVentasCliente

    Dim inactiva As Boolean = False

    Public Sub llenarComboListasPrecios()
        Dim objLPBC As New Negocios.ListaBaseBU
        Dim dtDatosListaPrecios As New DataTable
        dtDatosListaPrecios = objLPBC.verListaPreciosActivaAutorizada
        If dtDatosListaPrecios.Rows.Count > 0 Then
            Dim newRow As DataRow = dtDatosListaPrecios.NewRow
            dtDatosListaPrecios.Rows.InsertAt(newRow, 0)
            cmbEstatusLista.DataSource = dtDatosListaPrecios
            cmbEstatusLista.DisplayMember = "LISTABASE"
            cmbEstatusLista.ValueMember = "lpba_listapreciosbaseid"
            cmbEstatusLista.SelectedIndex = 0
        End If
    End Sub

    Public Sub llenarComboListaVentas()
        If cmbEstatusLista.SelectedIndex > 0 Then
            Dim objLPVP As New Negocios.ListaVentasBU
            Dim dtDatosListaVentas As New DataTable
            dtDatosListaVentas = objLPVP.consultaListasVentaLB(cmbEstatusLista.SelectedValue)
            consultaDatosListaBase(cmbEstatusLista.SelectedValue)
            If dtDatosListaVentas.Rows.Count > 0 Then
                Dim newRow As DataRow = dtDatosListaVentas.NewRow
                dtDatosListaVentas.Rows.InsertAt(newRow, 0)
                cmbListaVentas.DataSource = dtDatosListaVentas
                cmbListaVentas.DisplayMember = "lpvt_descripcion"
                cmbListaVentas.ValueMember = "lpvt_listaprecioventaid"
            Else
                cmbListaVentas.DataSource = Nothing
                cmbListaVentas.Items.Clear()
            End If
        Else
            cmbListaVentas.DataSource = Nothing
            cmbListaVentas.Items.Clear()
            dttInicioVigenciaLB.Value = Date.Now
            dttFinVigenciaLB.Value = Date.Now
        End If
    End Sub

    Public Sub llenarComboClientes()
        If cmbEstatusLista.SelectedIndex > 0 Then
            If cmbListaVentas.SelectedIndex > 0 Then
                Dim objLVC As New Negocios.ListaVentasClienteBU
                Dim dtListaVentasCliente As New DataTable
                dtListaVentasCliente = objLVC.consultaListaVentasClienteLV(0, cmbListaVentas.SelectedValue, False, True)
                If dtListaVentasCliente.Rows.Count > 0 Then
                    Dim newRow As DataRow = dtListaVentasCliente.NewRow
                    dtListaVentasCliente.Rows.InsertAt(newRow, 0)
                    cmbListaVentaClientes.DataSource = dtListaVentasCliente
                    cmbListaVentaClientes.DisplayMember = "clie_nombregenerico"
                    cmbListaVentaClientes.ValueMember = "lvcl_listaventasclienteid"
                Else
                    cmbListaVentaClientes.DataSource = Nothing
                    cmbListaVentaClientes.Items.Clear()
                End If
            Else
                cmbListaVentaClientes.DataSource = Nothing
                cmbListaVentaClientes.Items.Clear()
                Dim objLVC As New Negocios.ListaVentasClienteBU
                Dim dtListaVentasCliente As New DataTable
                dtListaVentasCliente = objLVC.consultaListaVentasClienteLV(cmbEstatusLista.SelectedValue, 0, False, True)
                If dtListaVentasCliente.Rows.Count > 0 Then
                    Dim newRow As DataRow = dtListaVentasCliente.NewRow
                    dtListaVentasCliente.Rows.InsertAt(newRow, 0)
                    cmbListaVentaClientes.DataSource = dtListaVentasCliente
                    cmbListaVentaClientes.DisplayMember = "clie_nombregenerico"
                    cmbListaVentaClientes.ValueMember = "lvcl_listaventasclienteid"
                Else
                    cmbListaVentaClientes.DataSource = Nothing
                    cmbListaVentaClientes.Items.Clear()
                End If

            End If
        Else
            cmbListaVentaClientes.DataSource = Nothing
            cmbListaVentaClientes.Items.Clear()
        End If
    End Sub

    Public Sub llenarComboEstatus()
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtEstatus As New DataTable
        dtEstatus = objLVC.consultaEstatusListaVentasClientePrecios("")
        dtEstatus.Rows.InsertAt(dtEstatus.NewRow, 0)
        cmbEstatus.DataSource = dtEstatus
        cmbEstatus.DisplayMember = "esta_nombre"
        cmbEstatus.ValueMember = "esta_estatusid"
    End Sub

    Private Sub permisosPerfil()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_PRECIOSCLIENTE", "ADD_UPD_LPC") = False Then

            pnlBotonesRegistro.Visible = False
            Panel4.Visible = False
            pnlCambiarEstatus.Visible = False
            pnlLigarLista.Visible = False
        End If
    End Sub

    Public Sub llenarDatosListaVentas()
        If cmbListaVentas.SelectedIndex > 0 Then
            Dim objLVC As New Negocios.ListaVentasClienteBU
            Dim dtListaVentasCliente As New DataTable
            Dim listaVentaItem As New Object
            Dim dtListaVentasTipoIva As New DataTable
            Dim dtListaVentasTipoFlete As New DataTable
            listaVentaItem = cmbListaVentas.SelectedItem
            txtDescuentoInicio.Text = CDbl(listaVentaItem("lpvt_descuentoinicio")).ToString("N2")
            txtDescuentoFin.Text = CDbl(listaVentaItem("lpvt_descuentofin")).ToString("N2")
            txtFacturaInicio.Text = CDbl(listaVentaItem("lpvt_facturacioninicio")).ToString("N2")
            txtFacturaFin.Text = CDbl(listaVentaItem("lpvt_facturacionfin")).ToString("N2")
            txtIncrementoPPar.Text = CDbl(listaVentaItem("lpvt_incrementoporpar")).ToString("N2")
            dttInicioVigenciaLV.Value = listaVentaItem("lpvt_vigenciainicio").ToString
            dttFinVigenciaLV.Value = listaVentaItem("lpvt_vigenciafin").ToString
            dtListaVentasTipoIva = objLVC.consultaIVAconf(cmbListaVentas.SelectedValue)
            dtListaVentasTipoFlete = objLVC.consultaFleteconf(cmbListaVentas.SelectedValue)
            txtIVA.Text = ""
            txtFlete.Text = ""
            For Each rowIVA As DataRow In dtListaVentasTipoIva.Rows
                If txtIVA.Text = "" Then
                    txtIVA.Text = rowIVA.Item("tiva_nombre").ToString.Trim
                Else
                    txtIVA.Text = txtIVA.Text + ", " + rowIVA.Item("tiva_nombre").ToString.Trim
                End If

            Next
            For Each rowFlete As DataRow In dtListaVentasTipoFlete.Rows
                If txtFlete.Text = "" Then
                    txtFlete.Text = rowFlete.Item("tifl_nombre").ToString.Trim
                Else
                    txtFlete.Text = txtFlete.Text + ", " + rowFlete.Item("tifl_nombre").ToString.Trim
                End If
            Next
        Else
            txtDescuentoInicio.Text = ""
            txtDescuentoFin.Text = ""
            txtFacturaInicio.Text = ""
            txtFacturaFin.Text = ""
            txtIncrementoPPar.Text = ""
            txtIVA.Text = ""
            txtFlete.Text = ""
            dttInicioVigenciaLV.Value = Date.Now
            dttFinVigenciaLV.Value = Date.Now
        End If
    End Sub

    Public Sub llenarListaVentasClientePrecios()
        grdClientes.DataSource = Nothing
        lblContClientes.Text = "0"
        chkSeleccionarFiltrados.Checked = False
        Dim objLVC As New Negocios.ListaVentasClienteBU
        Dim dtListasVTCP As New DataTable
        Dim idListaVentasSel As Int32 = 0
        Dim idEstatusLVCL As Int32 = 0
        Me.Cursor = Cursors.WaitCursor
        If cmbListaVentas.SelectedIndex > 0 Then
            idListaVentasSel = cmbListaVentas.SelectedValue
        End If

        If cmbEstatus.SelectedIndex > 0 Then
            idEstatusLVCL = cmbEstatus.SelectedValue
        End If

        If cmbListaVentaClientes.SelectedIndex > 0 Then
            Dim itemClienteid As Object
            itemClienteid = cmbListaVentaClientes.SelectedItem
            dtListasVTCP = objLVC.consultaListasVentasClientePrecios(cmbEstatusLista.SelectedValue, idListaVentasSel, itemClienteid("lvcl_clienteid").ToString(), idEstatusLVCL, chkSiLigar.Checked, chkNoLigar.Checked)
        Else
            dtListasVTCP = objLVC.consultaListasVentasClientePrecios(cmbEstatusLista.SelectedValue, idListaVentasSel, 0, idEstatusLVCL, chkSiLigar.Checked, chkNoLigar.Checked)
        End If
        If dtListasVTCP.Rows.Count > 0 Then
            grdClientes.DataSource = dtListasVTCP
            formatoGrids()

        Else
            grdClientes.DataSource = Nothing
        End If
        Me.Cursor = Cursors.Default
        lblUltimaActualizacion.Text = Date.Now
    End Sub

    Public Sub BloquearComponentesListasInactivas()
        pnlBotonesRegistro.Enabled = False
        Panel4.Enabled = False
        pnlCambiarEstatus.Enabled = False
        pnlLigarLista.Enabled = False
        GroupBox1.Enabled = False
        inactiva = True
    End Sub

    Public Sub DesbloquearComponentesListasInactivas()
        pnlBotonesRegistro.Enabled = True
        Panel4.Enabled = True
        GroupBox1.Enabled = True
        inactiva = False
    End Sub

    Public Sub consultaDatosListaBase(ByVal idListaBase As Int32)
        Dim objLBBU As New Negocios.ListaBaseBU
        Dim dtDatosListaBase As New DataTable
        dtDatosListaBase = objLBBU.verListaPBase(idListaBase)
        If dtDatosListaBase.Rows.Count > 0 Then
            If dtDatosListaBase.Rows(0).Item("lpba_estatus") = 1 Then
                lblEstatus.Text = "ACTIVA"
                lblEstatus.ForeColor = Color.DarkOrange
                DesbloquearComponentesListasInactivas()
            ElseIf dtDatosListaBase.Rows(0).Item("lpba_estatus") = 2 Then
                lblEstatus.Text = "AUTORIZADA"
                lblEstatus.ForeColor = Color.LimeGreen
                DesbloquearComponentesListasInactivas()
            Else
                lblEstatus.Text = "INACTIVA"
                lblEstatus.ForeColor = Color.Red
                BloquearComponentesListasInactivas()
            End If
            dttInicioVigenciaLB.Value = dtDatosListaBase.Rows(0).Item("lpba_vigenciainicio").ToString
            dttFinVigenciaLB.Value = dtDatosListaBase.Rows(0).Item("lpba_vigenciafin").ToString
        End If
    End Sub

    Public Sub formatoGrids()
        With grdClientes.DisplayLayout.Bands(0)

            .Columns("lpvt_vigenciainicio").Hidden = True
            .Columns("lpvt_vigenciafin").Hidden = True
            .Columns("lvcp_monedaid").Hidden = True
            .Columns("lvcp_incotermsid").Hidden = True
            .Columns("lvcp_fleteid").Hidden = True
            .Columns("lvcp_ivaid").Hidden = True
            .Columns("lvcp_incotermsid").Hidden = True
            .Columns("lvcp_estatusid").Hidden = True
            .Columns("idListaVentas").Hidden = True
            .Columns("idListaBase").Hidden = True
            .Columns("idListaVentasClientePrecio").Hidden = True
            .Columns("idListaVentasCliente").Hidden = True
            .Columns("tipoCliente").Hidden = True
            .Columns("lvcp_listaventasclienteprecioid_original").Hidden = True
            .Columns("fc").Hidden = True
            .Columns("mone_nombre").Hidden = True
            .Columns("lvcp_paridad").Hidden = True
            .Columns("lvcp_fechaparidad").Hidden = True

            .Columns("idsay").Header.Caption = "Id SAY"
            .Columns("idsicy").Header.Caption = "Id SICY"
            .Columns("Cliente").Header.Caption = "Cliente"
            .Columns("listabase").Header.Caption = "L.Base"
            .Columns("listaVentas").Header.Caption = "L.Ventas"
            .Columns("inxpar").Header.Caption = "IxP"
            .Columns("lvcp_descripcion").Header.Caption = "L. de Precios"
            .Columns("esta_nombre").Header.Caption = "Estatus"
            .Columns("NArt").Header.Caption = "#Arts."
            .Columns("lvcp_vigenciainicio").Header.Caption = "Inicio"
            .Columns("lvcp_vigenciafin").Header.Caption = "Fin"
            .Columns("lvcp_fechamodifico").Header.Caption = "Ultima Modificación"
            .Columns("user_username").Header.Caption = "Modificó"
            .Columns("mone_nombre").Header.Caption = "Moneda"
            .Columns("lvcp_paridad").Header.Caption = "Paridad"
            .Columns("lvcp_fechaparidad").Header.Caption = "F.Paridad"
            .Columns("incoterm").Header.Caption = "Incoterm"
            .Columns("lvcp_descuento").Header.Caption = "% Desc"
            .Columns("lvcp_facturacion").Header.Caption = "% Fact"
            .Columns("tifl_nombre").Header.Caption = "Flete"
            .Columns("tiva_nombre").Header.Caption = "IVA"
            .Columns("fchr").Header.Caption = "Creación(HR)"
            .Columns("fc").Header.Caption = "Creación"
            .Columns("LORIGINAL").Header.Caption = "Lista Original"
            .Columns("lvcp_ligarlistaoriginal").Header.Caption = "LLO"

            .Columns("idsay").CellActivation = Activation.NoEdit
            .Columns("idsicy").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("listabase").CellActivation = Activation.NoEdit
            .Columns("listaVentas").CellActivation = Activation.NoEdit
            .Columns("inxpar").CellActivation = Activation.NoEdit
            .Columns("lvcp_descripcion").CellActivation = Activation.NoEdit
            .Columns("esta_nombre").CellActivation = Activation.NoEdit
            .Columns("lvcp_vigenciainicio").CellActivation = Activation.NoEdit
            .Columns("lvcp_vigenciafin").CellActivation = Activation.NoEdit
            .Columns("lvcp_fechamodifico").CellActivation = Activation.NoEdit
            .Columns("user_username").CellActivation = Activation.NoEdit
            .Columns("mone_nombre").CellActivation = Activation.NoEdit
            .Columns("lvcp_paridad").CellActivation = Activation.NoEdit
            .Columns("lvcp_fechaparidad").CellActivation = Activation.NoEdit
            .Columns("incoterm").CellActivation = Activation.NoEdit
            .Columns("lvcp_descuento").CellActivation = Activation.NoEdit
            .Columns("lvcp_facturacion").CellActivation = Activation.NoEdit
            .Columns("tifl_nombre").CellActivation = Activation.NoEdit
            .Columns("fchr").CellActivation = Activation.NoEdit
            .Columns("fc").CellActivation = Activation.NoEdit
            .Columns("LORIGINAL").CellActivation = Activation.NoEdit
            .Columns("NArt").CellActivation = Activation.NoEdit
            .Columns("lvcp_ligarlistaoriginal").CellActivation = Activation.NoEdit

            .Columns("idsay").CellAppearance.TextHAlign = HAlign.Right
            .Columns("idsicy").CellAppearance.TextHAlign = HAlign.Right
            .Columns("inxpar").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lvcp_descuento").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lvcp_facturacion").CellAppearance.TextHAlign = HAlign.Right
            .Columns("lvcp_paridad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("NArt").CellAppearance.TextHAlign = HAlign.Right

            .Columns("lvcp_fechamodifico").Format = "dd/MM/yyyy HH:mm:ss"
            .Columns("fchr").Format = "dd/MM/yyyy HH:mm:ss"
            .Columns("NArt").Format = "###,###,##0"

            .Columns("esta_nombre").CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        End With

        Dim colSeleccion As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns("Seleccion")
        colSeleccion.DefaultCellValue = False
        colSeleccion.Header.Caption = ""
        colSeleccion.Style = ColumnStyle.CheckBox

        grdClientes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClientes.DisplayLayout.Override.RowSelectorWidth = 35
        grdClientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdClientes.Rows(0).Selected = True
        grdClientes.DisplayLayout.Bands(0).Columns("listabase").Header.VisiblePosition = grdClientes.DisplayLayout.Bands(0).Columns.Count - 1
        grdClientes.DisplayLayout.Bands(0).Columns("listabase").Width = 5
        grdClientes.DisplayLayout.Bands(0).Columns("incoterm").Width = 25

        If inactiva = True Then
            grdClientes.DisplayLayout.Bands(0).Columns("tiva_nombre").CellActivation = Activation.NoEdit
        End If
    End Sub

    Private Sub frmConsultaListaVentasCliente_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If cmbEstatusLista.SelectedIndex > 0 Then
            llenarListaVentasClientePrecios()
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
                gr = grdClientes
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(gr, fileName)
                Me.Cursor = Cursors.Default
                Me.Cursor = Cursors.WaitCursor
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
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
            gr = grdClientes
            ugde.Export(gr, sec)
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

    Public Sub cambiarEstatusVariasListas()
        Dim contSeleccionados As Int32 = 0
        Dim objCmEsts As New frmCambiarEstatusVariasListasCliente
        Dim nuevoidEstatus As Int32 = 0
        Dim objLVCL As New Negocios.ListaPreciosVentaClienteBU

        For Each rowGR As UltraGridRow In grdClientes.Rows
            If CBool(rowGR.Cells("Seleccion").Value) = True Then
                If validarFechaCambiarEstatus(rowGR.Cells("Cliente").Value.ToString, rowGR.Cells("idListaVentasCliente").Value, rowGR.Cells("idListaVentasClientePrecio").Value, rowGR.Cells("lvcp_vigenciainicio").Value.ToString, rowGR.Cells("lvcp_vigenciafin").Value.ToString) = False Then
                    rowGR.Cells("Seleccion").Value = False
                    If 0 = rowGR.Index Mod 2 Then
                        rowGR.Cells("Seleccion").Appearance.BackColor = Color.White
                    Else
                        rowGR.Cells("Seleccion").Appearance.BackColor = Color.LightSteelBlue
                    End If

                    lblContClientes.Text = CInt(lblContClientes.Text) - 1

                    Dim objMensajeGuardar As New Tools.AdvertenciaForm
                    objMensajeGuardar.mensaje = "La lista del cliente " + rowGR.Cells("Cliente").Value.ToString + " no puede cambiar de estatus debido a que tiene otra lista de precios de cliente con una vigencia que se traslapa y debe modificarse directamente."
                    objMensajeGuardar.ShowDialog()
                End If
            End If
        Next

        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            If rowGR.Cells("Seleccion").Value = True Then
                contSeleccionados += 1
            End If
        Next
        If contSeleccionados > 0 Then
            objCmEsts.idEstatusOriginal = cmbEstatus.SelectedValue
            objCmEsts.EstatusOriginalCad = cmbEstatus.Text
            objCmEsts.contCambios = contSeleccionados
            objCmEsts.listasSeleccionadas = CInt(lblContClientes.Text)
            If objCmEsts.ShowDialog = Windows.Forms.DialogResult.OK Then
                nuevoidEstatus = objCmEsts.nuevoEstatus
                If nuevoidEstatus > 0 Then
                    For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
                        If rowGR.Cells("Seleccion").Value = True Then
                            objLVCL.cambiarEstatusListaPreciosCLiente(rowGR.Cells("idListaVentasClientePrecio").Value, nuevoidEstatus)
                        End If
                    Next
                Else
                    Dim objMensaje As New Tools.AvisoForm
                    objMensaje.mensaje = "No se pudo realizar el cambio de estatus."
                    objMensaje.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AvisoForm
                objMensaje.mensaje = "Se cancelo la transaccion y no se guardará ningún cambio."
                objMensaje.ShowDialog()
            End If

        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Debe seleccionar al menos una lista de precios de cliente"
            objMensaje.ShowDialog()
        End If
    End Sub

    Public Sub actualizarLigaListaOriginal()
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim bitCambio As Boolean = True
        Dim contSeleccionados As Int32 = 0
        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            If rowGR.Cells("Seleccion").Value = True And rowGR.Cells("lvcp_listaventasclienteprecioid_original").Value.ToString <> "" Then
                contSeleccionados += 1
            End If
        Next
        If chkSiLigar.Checked = True Then
            bitCambio = False
        Else
            bitCambio = True
        End If
        If contSeleccionados > 0 Then
            Dim objM As New Tools.ConfirmarForm
            If bitCambio = True Then
                objM.mensaje = "¿Está seguro de ligar la(s) lista(s) de precios de los clientes seleccionados con la lista de precios de cliente original?"
            Else
                objM.mensaje = "¿Está seguro de quitar la liga de la(s) lista(s) de precios de los clientes seleccionados con la lista de cliente original?"
            End If

            If objM.ShowDialog = Windows.Forms.DialogResult.OK Then
                If chkSiLigar.Checked = True Then
                    bitCambio = False
                Else
                    bitCambio = True
                End If
                For Each rowGr As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
                    If rowGr.Cells("Seleccion").Value = True And rowGr.Cells("lvcp_listaventasclienteprecioid_original").Value.ToString <> "" Then

                        objLVC.cambiarEstatusLigaListaOriginal(rowGr.Cells("idListaVentasClientePrecio").Value, bitCambio)

                    End If
                Next
                llenarListaVentasClientePrecios()
                Dim objExito As New Tools.ExitoForm
                objExito.mensaje = "Registro correcto"
                objExito.ShowDialog()
            End If

        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Debe seleccionar al menos una lista de precios de cliente"
            objMensaje.ShowDialog()
        End If
    End Sub

    Public Function validarClienteListaCopia(ByVal idCliente As Int32) As Boolean
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dt As New DataTable
        Dim mensaje As String = ""
        dt = objLVC.validarClienteListaOriginal(idCliente)
        If dt.Rows.Count > 0 Then
            Dim objMensaje As New Tools.AvisoForm
            If dt.Rows(0).Item(0).ToString <> "1" Then
                objMensaje.mensaje = "No puede copiar listas de un cliente extranjero a otro cliente."
                objMensaje.ShowDialog()

                Return False
            End If
            If dt.Rows(0).Item(1).ToString <> "1" Then
                objMensaje.mensaje = "No puede copiar una lista con moneda diferente a pesos."
                objMensaje.ShowDialog()

                Return False
            End If
            If dt.Rows(0).Item(2) > 0 Or dt.Rows(0).Item(3) > 0 Then
                objMensaje.mensaje = "No puede copiar listas de un cliente con marcas y/o colecciones especiales a otro cliente."
                objMensaje.ShowDialog()
                Return False
            End If
        Else
            Return False
        End If
        Return True
    End Function

    Public Sub copiarListaVariosClientes()
        Try
            If grdClientes.Rows.Count > 0 Then
                If grdClientes.ActiveRow.IsFilterRow = False Then
                    If grdClientes.ActiveRow.Cells("lvcp_estatusid").Value = "26" Or grdClientes.ActiveRow.Cells("lvcp_estatusid").Value = "28" Then

                        If validarClienteListaCopia(grdClientes.ActiveRow.Cells("idsay").Value) = True Then

                            Dim objCopLCL As New frmListaClientesPosibleCopia
                            objCopLCL.idListaVentasClienteProd = grdClientes.ActiveRow.Cells("idListaVentasClientePrecio").Value
                            objCopLCL.idListaVentas = grdClientes.ActiveRow.Cells("idListaVentas").Value
                            objCopLCL.idCliente = grdClientes.ActiveRow.Cells("idsay").Value
                            objCopLCL.nombreCliente = grdClientes.ActiveRow.Cells("Cliente").Value
                            objCopLCL.vigenciaInicio = grdClientes.ActiveRow.Cells("lvcp_vigenciainicio").Value
                            objCopLCL.vigenciaFin = grdClientes.ActiveRow.Cells("lvcp_vigenciafin").Value
                            objCopLCL.modificado = grdClientes.ActiveRow.Cells("lvcp_fechamodifico").Value
                            objCopLCL.usuarioModifico = grdClientes.ActiveRow.Cells("user_username").Value
                            objCopLCL.estatusCad = grdClientes.ActiveRow.Cells("esta_nombre").Value
                            objCopLCL.idEstatus = grdClientes.ActiveRow.Cells("lvcp_estatusid").Value
                            objCopLCL.cantArticulos = grdClientes.ActiveRow.Cells("NArt").Value
                            objCopLCL.idListaBase = grdClientes.ActiveRow.Cells("idListaBase").Value
                            objCopLCL.estatusLB = lblEstatus.Text
                            objCopLCL.nombreListaCliente = cmbEstatusLista.Text + " " + grdClientes.ActiveRow.Cells("lvcp_descripcion").Value
                            'objCopLCL.MdiParent = MdiParent
                            objCopLCL.ShowDialog()
                            llenarListaVentasClientePrecios()
                            'Else
                            'Dim objMensaje As New Tools.AvisoForm
                            'objMensaje.mensaje = "Asegúrese que el cliente:" + vbCrLf +
                            '    "1.- No sea Extranjero." + vbCrLf +
                            '    "2.- Moneda Pesos." + vbCrLf +
                            '    "3.- No marcas exclusivas." + vbCrLf +
                            '    "4.- No colecciones exclusivas"
                            'objMensaje.ShowDialog()
                        End If
                    Else
                        Dim objMensaje As New Tools.AvisoForm
                        objMensaje.mensaje = "No puede copiar listas en estatus CAPTURADA o DESCARTADA para varios clientes. Seleccione una lista ACEPTADA o CERRADA."
                        objMensaje.ShowDialog()
                    End If
                Else
                    Dim objMensaje As New Tools.AvisoForm
                    objMensaje.mensaje = "Seleccione una lista."
                    objMensaje.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AvisoForm
                objMensaje.mensaje = "Debe seleccionar una lista de ventas de cliente"
                objMensaje.ShowDialog()
            End If
        Catch ex As Exception
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Debe seleccionar una lista de ventas de cliente"
            objMensaje.ShowDialog()
        End Try
    End Sub

    Public Function validarFechaCambiarEstatus(ByVal nombreCliente As String,
                                               ByVal listaventasclienteid As Int32,
                                               ByVal listaventasclienteprecioid As Int32,
                                               ByVal VigenciaInicio As String,
                                               ByVal VigenciaFin As String) As Boolean
        Dim objLVCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dt As New DataTable
        dt = objLVCBU.consultaValidarVigenciaPorListaCliente(listaventasclienteid, listaventasclienteprecioid)
        Dim FechaMinima As Date
        Dim FechaMaxima As Date
        If dt.Rows.Count > 0 Then
            FechaMinima = CDate(dt.Rows(0).Item("lvcp_vigenciainicio").ToString)
            FechaMaxima = CDate(dt.Rows(0).Item("lvcp_vigenciafin").ToString)
            If (CDate(VigenciaInicio) <= FechaMinima And CDate(VigenciaFin) <= FechaMinima) Or (CDate(VigenciaInicio) >= FechaMaxima And CDate(VigenciaFin) >= FechaMaxima) Then
                Return True
            Else
                Return False
            End If
        End If
        Return True
    End Function

    ' ' --------------------------------------------------------------------------------------------


    Private Sub frmConsultaListaVentasCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        lblEstatus.Text = ""
        llenarComboEstatus()
        llenarComboListasPrecios()
        permisosPerfil()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmbEstatusLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatusLista.SelectedIndexChanged
        lblEstatus.Text = ""
        llenarComboListaVentas()
        llenarComboClientes()
        llenarDatosListaVentas()
        cmbEstatus.SelectedIndex = 0
        ' ''chkSeleccionarFiltrados.Checked = False
    End Sub

    Private Sub cmbListaVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentas.SelectedIndexChanged
        If cmbListaVentas.SelectedIndex > 0 Then
            If cmbListaVentaClientes.SelectedIndex <= 0 Then
                llenarComboClientes()
            Else
                Dim itemClienteid As Object
                itemClienteid = cmbListaVentaClientes.SelectedItem
                If itemClienteid("lvcl_listaprecioventasid").ToString <> cmbListaVentas.SelectedValue Then
                    llenarComboClientes()
                End If
            End If
        Else
            llenarComboClientes()
        End If
        llenarDatosListaVentas()
        cmbEstatus.SelectedIndex = 0
        ' ''chkSeleccionarFiltrados.Checked = False
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbEstatusLista.SelectedIndex > 0 Then
            lblContClientes.Text = "0"
            llenarListaVentasClientePrecios()
        Else
            Dim objMensaje As New Tools.AvisoForm
            objMensaje.mensaje = "Para mostrar informacion, es necesario seleccionar una lista base."
            objMensaje.ShowDialog()
        End If

        If inactiva = True Then
            pnlCambiarEstatus.Enabled = False
        Else
            If chkSiLigar.Checked = True And chkNoLigar.Checked = True Then
                pnlLigarLista.Enabled = False
            ElseIf chkSiLigar.Checked = False And chkNoLigar.Checked = False Then
                pnlLigarLista.Enabled = False
            Else
                pnlLigarLista.Enabled = True
            End If
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdClientes.DataSource = Nothing
        cmbEstatusLista.SelectedIndex = 0
        chkSeleccionarFiltrados.Checked = False
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        If cmbEstatusLista.SelectedIndex > 0 And cmbListaVentas.SelectedIndex <= 0 And cmbListaVentaClientes.SelectedIndex > 0 Then
            If cmbListaVentaClientes.SelectedIndex > 0 Then
                Dim itemClienteid As Object
                itemClienteid = cmbListaVentaClientes.SelectedItem
                If itemClienteid("lvcl_listaprecioventasid").ToString <> "" Then
                    Dim COSA As String = itemClienteid("lvcl_listaprecioventasid").ToString
                    cmbListaVentas.SelectedValue = itemClienteid("lvcl_listaprecioventasid").ToString
                End If
            End If

        End If
        If cmbEstatusLista.SelectedIndex > 0 And cmbListaVentaClientes.SelectedIndex > 0 And cmbListaVentas.SelectedIndex > 0 Then
            Dim objLVPC As New Negocios.ListaPreciosVentaClienteBU
            Dim objFormAltaLVC As New AltaConfiguracionListaPreciosCliente
            Dim contLVCP As Int32 = 0
            contLVCP = objLVPC.consultaValidarListasCapturadas(cmbListaVentaClientes.SelectedValue)

            If contLVCP <= 1 Then
                Dim itemClienteid As Object
                itemClienteid = cmbListaVentaClientes.SelectedItem

                Dim itemLVentas As Object
                itemLVentas = cmbListaVentas.SelectedItem

                objFormAltaLVC.idListaBase = cmbEstatusLista.SelectedValue
                objFormAltaLVC.nombreListaBase = cmbEstatusLista.Text

                objFormAltaLVC.idListaPreciosVentas = cmbListaVentas.SelectedValue
                objFormAltaLVC.nombreListaPreciosVentas = cmbListaVentas.Text
                objFormAltaLVC.incrementoListaVentas = itemLVentas("lpvt_incrementoporpar").ToString

                objFormAltaLVC.idListaVentasCliente = cmbListaVentaClientes.SelectedValue
                objFormAltaLVC.nombreCliente = cmbListaVentaClientes.Text

                objFormAltaLVC.tipoClienteId = itemClienteid("clie_tipoclienteid").ToString()
                objFormAltaLVC.idClienteFTC = itemClienteid("lvcl_clienteid").ToString()

                objFormAltaLVC.fechaMin = itemLVentas("lpvt_vigenciainicio").ToString
                objFormAltaLVC.fechaMax = itemLVentas("lpvt_vigenciafin").ToString

                objFormAltaLVC.accionPantalla = "ALTA"

                objFormAltaLVC.estatusLB = lblEstatus.Text
                objFormAltaLVC.MdiParent = MdiParent
                objFormAltaLVC.Show()
            Else
                Dim objAdMensaje As New Tools.AdvertenciaForm
                objAdMensaje.mensaje = "El cliente no puede tener mas de 2 listas en estatus ACEPTADA-CAPTURADA."
                objAdMensaje.ShowDialog()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Para dar de alta una nueva lista de precios de cliente es necesario seleccionar un cliente y su lista de ventas."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub grdClientes_CellChange(sender As Object, e As CellEventArgs) Handles grdClientes.CellChange
        If e.Cell.Column.Key = "Seleccion" And e.Cell.Row.Index <> grdClientes.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            If CBool(e.Cell.Text) = True Then
                e.Cell.Appearance.BackColor = Color.LimeGreen
            Else
                If 0 = e.Cell.Row.Index Mod 2 Then
                    e.Cell.Appearance.BackColor = Color.White
                Else
                    e.Cell.Appearance.BackColor = Color.LightSteelBlue
                End If
            End If
            If CBool(e.Cell.Text) = True Then
                lblContClientes.Text = CInt(lblContClientes.Text) + 1
            Else
                lblContClientes.Text = CInt(lblContClientes.Text) - 1
            End If
        End If
    End Sub

    Private Sub grdClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdClientes.ClickCell
        If e.Cell.Column.ToString <> "Seleccion" Then
            If e.Cell.Row.IsFilterRow = False Then

                Dim objLVCBU As New Negocios.ListaPreciosVentaClienteBU
                Dim dtLV As New DataTable
                dtLV = objLVCBU.verListaVentasClienteActual(grdClientes.ActiveRow.Cells("idListaBase").Value, grdClientes.ActiveRow.Cells("idsay").Value)
                If dtLV.Rows.Count > 0 Then
                    cmbListaVentas.SelectedValue = dtLV.Rows(0).Item("lpvt_listaprecioventaid").ToString
                    cmbListaVentaClientes.SelectedValue = dtLV.Rows(0).Item("lvcl_listaventasclienteid").ToString
                Else
                    cmbListaVentas.SelectedIndex = 0
                End If

            Else
                If cmbListaVentas.SelectedIndex > 0 Then
                    cmbListaVentas.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub grdClientes_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles grdClientes.DoubleClickRow
        If cmbEstatusLista.SelectedIndex > 0 Then
            Dim objFormAltaLVC As New AltaConfiguracionListaPreciosCliente

            objFormAltaLVC.idListaBase = e.Row.Cells("idListaBase").Value
            objFormAltaLVC.nombreListaBase = e.Row.Cells("listabase").Value

            objFormAltaLVC.idListaPreciosVentas = e.Row.Cells("idListaVentas").Value
            objFormAltaLVC.nombreListaPreciosVentas = e.Row.Cells("listaVentas").Value
            objFormAltaLVC.incrementoListaVentas = e.Row.Cells("inxpar").Value

            objFormAltaLVC.idListaVentasCliente = e.Row.Cells("idListaVentasCliente").Value
            objFormAltaLVC.nombreCliente = e.Row.Cells("Cliente").Value

            objFormAltaLVC.tipoClienteId = e.Row.Cells("tipoCliente").Value
            objFormAltaLVC.idClienteFTC = e.Row.Cells("idsay").Value

            objFormAltaLVC.idListaVentasClientePrecio = e.Row.Cells("idListaVentasClientePrecio").Value

            objFormAltaLVC.fechaMin = e.Row.Cells("lpvt_vigenciainicio").Value
            objFormAltaLVC.fechaMax = e.Row.Cells("lpvt_vigenciafin").Value

            objFormAltaLVC.accionPantalla = "EDITAR"

            objFormAltaLVC.estatusLB = lblEstatus.Text
            objFormAltaLVC.MdiParent = MdiParent
            objFormAltaLVC.inactiva = inactiva
            objFormAltaLVC.Show()
        End If
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        Me.grdClientes.DisplayLayout.GroupByBox.Prompt = "Arrastra para agrupar datos."
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
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub grdClientes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdClientes.InitializeRow
        If e.Row.Cells("lvcp_estatusid").Value.ToString = "25" Then
            e.Row.Cells("esta_nombre").Appearance.ForeColor = Color.CornflowerBlue
            e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
        ElseIf e.Row.Cells("lvcp_estatusid").Value.ToString = "26" Then
            e.Row.Cells("esta_nombre").Appearance.ForeColor = Color.LimeGreen
            e.Row.Cells("Seleccion").Activation = Activation.AllowEdit
        ElseIf e.Row.Cells("lvcp_estatusid").Value.ToString = "27" Then
            e.Row.Cells("esta_nombre").Appearance.ForeColor = Color.Red
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        ElseIf e.Row.Cells("lvcp_estatusid").Value.ToString = "28" Then
            e.Row.Cells("esta_nombre").Appearance.ForeColor = Color.DarkOrange
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        End If
        If inactiva = True Then
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlDatos.Height = 23
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlDatos.Height = 130
    End Sub

    Private Sub btnCopiarLista_Click(sender As Object, e As EventArgs) Handles btnCopiarLista.Click
        If cmbEstatusLista.SelectedIndex > 0 And cmbListaVentas.SelectedIndex <= 0 And cmbListaVentaClientes.SelectedIndex > 0 Then
            If cmbListaVentaClientes.SelectedIndex > 0 Then
                Dim itemClienteid As Object
                itemClienteid = cmbListaVentaClientes.SelectedItem
                If itemClienteid("lvcl_listaprecioventasid").ToString <> "" Then
                    cmbListaVentas.SelectedValue = itemClienteid("lvcl_listaprecioventasid").ToString
                End If
            End If
        End If
        If grdClientes.Rows.Count > 0 Then
            If cmbEstatusLista.SelectedIndex > 0 And cmbListaVentaClientes.SelectedIndex > 0 Then
                Dim objLVPC As New Negocios.ListaPreciosVentaClienteBU
                Dim objFormAltaLVC As New AltaConfiguracionListaPreciosCliente
                Dim contLVCP As Int32 = 0
                contLVCP = objLVPC.consultaValidarListasCapturadas(cmbListaVentaClientes.SelectedValue)

                If contLVCP <= 1 Then
                    Dim itemClienteid As Object
                    itemClienteid = cmbListaVentaClientes.SelectedItem
                    If itemClienteid("lvcl_clienteid").ToString() = grdClientes.ActiveRow.Cells("idsay").Value.ToString Then

                        Dim itemLVentas As Object
                        itemLVentas = cmbListaVentas.SelectedItem

                        objFormAltaLVC.idListaBase = cmbEstatusLista.SelectedValue
                        objFormAltaLVC.nombreListaBase = cmbEstatusLista.Text

                        objFormAltaLVC.idListaPreciosVentas = cmbListaVentas.SelectedValue
                        objFormAltaLVC.nombreListaPreciosVentas = cmbListaVentas.Text
                        objFormAltaLVC.incrementoListaVentas = itemLVentas("lpvt_incrementoporpar").ToString

                        objFormAltaLVC.idListaVentasCliente = cmbListaVentaClientes.SelectedValue
                        objFormAltaLVC.nombreCliente = cmbListaVentaClientes.Text

                        objFormAltaLVC.tipoClienteId = itemClienteid("clie_tipoclienteid").ToString()
                        objFormAltaLVC.idClienteFTC = itemClienteid("lvcl_clienteid").ToString()

                        objFormAltaLVC.fechaMin = itemLVentas("lpvt_vigenciainicio").ToString
                        objFormAltaLVC.fechaMax = itemLVentas("lpvt_vigenciafin").ToString

                        objFormAltaLVC.idListaVentasClientePrecioCOPIA = grdClientes.ActiveRow.Cells("idListaVentasClientePrecio").Value
                        objFormAltaLVC.idListaPreciosVentasCOPIA = grdClientes.ActiveRow.Cells("idListaVentas").Value
                        objFormAltaLVC.accionPantalla = "COPIAR"

                        objFormAltaLVC.estatusLB = lblEstatus.Text
                        objFormAltaLVC.MdiParent = MdiParent
                        objFormAltaLVC.Show()
                    Else
                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.mensaje = "Solo puede copiar a un cliente sus propias listas."
                        objMensaje.ShowDialog()
                    End If
                Else
                    Dim objAdMensaje As New Tools.AdvertenciaForm
                    objAdMensaje.mensaje = "El cliente no puede tener mas de 2 listas en estatus ACEPTADA-CAPTURADA."
                    objAdMensaje.ShowDialog()
                End If
            Else
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Para COPIAR una lista de precios de cliente es necesario seleccionar al cliente."
                objMensaje.ShowDialog()
            End If
        Else
            Dim objAdMensaje As New Tools.AdvertenciaForm
            objAdMensaje.mensaje = "Seleccionar una lista para copiarla."
            objAdMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdClientes.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnExportarPDF_Click(sender As Object, e As EventArgs) Handles btnExportarPDF.Click
        If grdClientes.Rows.Count > 0 Then
            exportarPDF()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub cmbListaVentaClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentaClientes.SelectedIndexChanged
        cmbEstatus.SelectedIndex = 0
        ' ''chkSeleccionarFiltrados.Checked = False
    End Sub

    Private Sub btnCopiarListaVariosClientes_Click(sender As Object, e As EventArgs) Handles btnCopiarListaVariosClientes.Click
        copiarListaVariosClientes()
    End Sub

    Private Sub btnCambiarEstatus_Click(sender As Object, e As EventArgs) Handles btnCambiarEstatus.Click

        cambiarEstatusVariasListas()
        llenarListaVentasClientePrecios()
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstatus.SelectedIndexChanged
        If inactiva = True Then
            pnlCambiarEstatus.Enabled = False
        Else
            If cmbEstatus.SelectedIndex > 0 Then
                If cmbEstatus.SelectedValue = 25 Or cmbEstatus.SelectedValue = 26 Then
                    pnlCambiarEstatus.Enabled = True
                Else
                    pnlCambiarEstatus.Enabled = False
                End If
                If cmbEstatusLista.SelectedIndex > 0 Then
                    llenarListaVentasClientePrecios()
                    If chkSiLigar.Checked = True And chkNoLigar.Checked = True Then
                        pnlLigarLista.Enabled = False
                    ElseIf chkSiLigar.Checked = False And chkNoLigar.Checked = False Then
                        pnlLigarLista.Enabled = False
                    Else
                        pnlLigarLista.Enabled = True
                    End If
                Else
                    Dim objMensaje As New Tools.AvisoForm
                    objMensaje.mensaje = "Para mostrar informacion, es necesario seleccionar una lista base."
                    objMensaje.ShowDialog()
                End If
            Else
                pnlCambiarEstatus.Enabled = False
            End If
        End If
    End Sub

    Private Sub chkSeleccionarFiltrados_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarFiltrados.CheckedChanged
        Dim contadorSeleccion As Int32 = 0
        For Each rowGR As UltraGridRow In grdClientes.Rows.GetFilteredInNonGroupByRows
            If rowGR.Cells("lvcp_estatusid").Value = "25" Or rowGR.Cells("lvcp_estatusid").Value = "26" Then
                If chkSeleccionarFiltrados.Checked = True Then
                    rowGR.Cells("Seleccion").Value = True
                Else
                    rowGR.Cells("Seleccion").Value = False
                End If
            End If
        Next

        For Each rowGR As UltraGridRow In grdClientes.Rows
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                contadorSeleccion += 1
            End If
            If CBool(rowGR.Cells("Seleccion").Text) = True Then
                rowGR.Cells("Seleccion").Appearance.BackColor = Color.LimeGreen
            Else
                If 0 = rowGR.Index Mod 2 Then
                    rowGR.Cells("Seleccion").Appearance.BackColor = Color.White
                Else
                    rowGR.Cells("Seleccion").Appearance.BackColor = Color.LightSteelBlue
                End If
            End If
        Next

        lblContClientes.Text = contadorSeleccion.ToString("N0")
    End Sub

    Private Sub lblContClientes_Click(sender As Object, e As EventArgs) Handles lblContClientes.Click

    End Sub

    Private Sub lblContClientes_TextChanged(sender As Object, e As EventArgs) Handles lblContClientes.TextChanged

    End Sub

    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        If cmbEstatusLista.SelectedIndex > 0 Or cmbListaVentas.SelectedIndex > 0 Then
            Dim idLVC As String = ""
            Dim objFiltroFrm As New frmFiltroClientes
            objFiltroFrm.accion = "CONSULTALC"

            If cmbEstatusLista.SelectedIndex > 0 Then
                objFiltroFrm.idLb = cmbEstatusLista.SelectedValue
            End If
            If cmbListaVentas.SelectedIndex > 0 Then
                objFiltroFrm.idLv = cmbListaVentas.SelectedValue
            End If

            objFiltroFrm.ShowDialog()
            idLVC = objFiltroFrm.idLVC
            cmbListaVentaClientes.SelectedValue = idLVC
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Debe seleccionar la Lista de Precios Base"
            objMensajeGuardar.ShowDialog()
        End If

    End Sub

    Private Sub btnCambiarListaOriginal_Click(sender As Object, e As EventArgs) Handles btnCambiarListaOriginal.Click
        actualizarLigaListaOriginal()
    End Sub

    Private Sub chkSiLigar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSiLigar.CheckedChanged

    End Sub

    Private Sub chkNoLigar_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoLigar.CheckedChanged

    End Sub
End Class