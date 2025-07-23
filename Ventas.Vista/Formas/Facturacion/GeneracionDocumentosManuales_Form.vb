Imports Tools
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.IO
Imports System.Xml
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository

Public Class GeneracionDocumentosManuales_Form

    Public SesionID As Integer = -1
    Public ClienteID As Integer = -1
    Public OTrajajo As String

    Dim OBJBU As New Ventas.Negocios.DocumentosDinamicosBU
    Dim dtInformacionSesion As DataTable
    Dim OTs As String = String.Empty
    Dim TotalDocumento As Double = 0
    Dim TotalPares As Integer = 0
    Dim RazonSocialEmisorID As Integer = 0
    Dim RazonSocialReceptorID As Integer = 0
    Dim DosNivelesPantalla As Boolean = False
    Dim TresNiveles As Boolean = False
    Dim DocumentoID As Integer = 0
    Dim emptyEditor As RepositoryItem
    Dim TipoIVA As Integer = 0
    Dim PrimeraCarga As Boolean = True
    Dim FormatoInvalido As Boolean = False
    Dim CorreoReceptor As String = ""
    Dim GObjent As Entidades.FacturacionDatosCliente
    Dim dtInformacionCliente As DataTable
    Dim Guardar As Boolean = False
    Dim ContadorPartidas As Integer = 0
    Public ParidadDocumentoExtranjero As String = "1"
    Public facturacionAnticipada As Boolean '0 = no, 1 = si


    Private Sub GeneracionDocumentosManuales_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim confirmar As New Tools.ConfirmarForm

        If Guardar = False Then
            confirmar.mensaje = "Los documentos mostrados en pantalla aún no se han guardado ¿Está seguro de cerrar la pantalla sin guardar los documentos?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Try
                    Cursor = Cursors.WaitCursor
                    OBJBU.BorrarDocumentosSession(SesionID)
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                End Try
            Else
                e.Cancel = True
            End If
        
        End If

      

       
    End Sub

    Private Sub GeneracionDocumentosManuales_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        'Primer nivel        
        SplitContainer1.SplitterDistance = SplitContainer1.Width + 1000
        SplitContainer3.SplitterDistance = SplitContainer3.Height
        SplitContainer3.Visible = False
        Panel8.Width = 0
        Panel7.Width = 0

      
        CargarPantalla()

        emptyEditor = New RepositoryItem()
        grdPartidasOT.RepositoryItems.Add(emptyEditor)

        PrimeraCarga = False

    End Sub

    Private Sub CargarInformacionCliente()


        dtInformacionCliente = OBJBU.ObtenerDatosClienteFacturacion(ClienteID, OTrajajo)
        GObjent = OBJBU.ObtenerDatosClienteFacturacionEntidad(ClienteID, OTrajajo)

        If dtInformacionCliente.Rows.Count > 0 Then
            lblNombreCliente.Text = dtInformacionCliente.Rows(0).Item("Cliente")
            Dim anchocliente As Integer = lblNombreCliente.Width
            If anchocliente > 295 Then
                'lblNombreCliente.MaximumSize = New Size(200, 16)
                lblNombreCliente.Font = New Font(Label1.Font.FontFamily, 7.0F)

            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("Restriccion")) = True Then
                lblRestriccion.Text = "---"
            Else
                lblRestriccion.Text = dtInformacionCliente.Rows(0).Item("Restriccion")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("MontoMaximoFactura")) = True Then
                lblMontoMax.Text = "0.00"
            Else
                lblMontoMax.Text = dtInformacionCliente.Rows(0).Item("MontoMaximoFactura")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("FacturarPorMarca")) = True Then
                lblRestriccionMarca.Text = "---"
            Else
                lblRestriccionMarca.Text = dtInformacionCliente.Rows(0).Item("FacturarPorMarca")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("EmpresaID")) = True Then
                RazonSocialEmisorID = 0
            Else
                RazonSocialEmisorID = dtInformacionCliente.Rows(0).Item("EmpresaID")
            End If


            If IsDBNull(dtInformacionCliente.Rows(0).Item("Empresa")) = True Then
                lblRazonSocialEmisor.Text = "---"
            Else
                lblRazonSocialEmisor.Text = dtInformacionCliente.Rows(0).Item("Empresa")
            End If


            If IsDBNull(dtInformacionCliente.Rows(0).Item("EmpresaRFC")) = True Then
                lblRFCEmisor.Text = "---"
            Else
                lblRFCEmisor.Text = dtInformacionCliente.Rows(0).Item("EmpresaRFC")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("TipoIvaID")) = True Then
                TipoIVA = 0
            Else
                TipoIVA = dtInformacionCliente.Rows(0).Item("TipoIvaID")
            End If

            'If IsDBNull(dtInformacionCliente.Rows(0).Item("CorreoReceptor")) = True Then
            '    CorreoReceptor = ""
            'Else
            '    CorreoReceptor = dtInformacionCliente.Rows(0).Item("CorreoReceptor")
            'End If

        End If

    End Sub

    Private Sub CargarRFCCliente()
        Dim dtRFC As DataTable
        dtRFC = OBJBU.ObtenerRFCOrdenTrabajo(ClienteID, OTs)
        dtRFC.Rows.InsertAt(dtRFC.NewRow, 0)
        cmbRazonSocial.DataSource = dtRFC
        cmbRazonSocial.DisplayMember = "razonsocial"
        cmbRazonSocial.ValueMember = "id"

    End Sub

    Private Sub ObtenerInformacionSesion()
        dtInformacionSesion = OBJBU.ObtenerInformacionSesion(SesionID)
        OTs = ""
        For Each fila As DataRow In dtInformacionSesion.Rows
            If OTs = "" Then
                OTs = fila.Item("OT")
            Else
                OTs &= "," & +fila.Item("OT")
            End If

        Next
        'If dtInformacionSesion.Rows.Count > 0 Then
        '    OTs = dtInformacionSesion.Rows(0).Item("OT")
        'End If

    End Sub

    Private Sub CargarPantalla()
        ObtenerInformacionSesion()
        CargarInformacionCliente()
        CargarRFCCliente()
        ObtenerUsoCFDI()
        CargarPartidas()
    End Sub

    Private Sub ObtenerUsoCFDI()
        Dim dtUsoCFDI As DataTable
        dtUsoCFDI = OBJBU.ObtenerUsoCFDISession(SesionID)
        If dtUsoCFDI.Rows.Count > 0 Then
            lblUsoCFDI.Text = dtUsoCFDI.Rows(0).Item(0)
        Else
            lblUsoCFDI.Text = "---"
        End If
    End Sub

    Private Sub cmbRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRazonSocial.SelectedIndexChanged

        Dim dtRFC As DataTable
        Dim splitcadena As String()
        If PrimeraCarga = False Then
            lblTipo.Text = "---"
            If cmbRazonSocial.SelectedIndex > 0 Then
                dtRFC = OBJBU.ObtenerRFC(cmbRazonSocial.SelectedValue)
                If dtRFC.Rows.Count > 0 Then
                    If IsDBNull(dtRFC.Rows(0).Item(0)) = False Then
                        If String.IsNullOrEmpty(dtRFC.Rows(0).Item(0)) = True Then
                            lblRFCReceptor.Text = "---"
                        Else
                            lblRFCReceptor.Text = dtRFC.Rows(0).Item(0)
                        End If
                    Else
                        lblRFCReceptor.Text = "---"
                    End If
                Else
                    lblRFCReceptor.Text = "---"
                End If

                splitcadena = Split(cmbRazonSocial.Text, "-")

                If splitcadena.Count > 0 Then

                    viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").VisibleIndex = 6
                    viewPartidas.Columns.ColumnByFieldName("Precio").VisibleIndex = 6

                    If splitcadena(0).Contains("F") = True Then
                        lblTipo.Text = "FACTURA"
                        If TipoIVA = 1 Then
                            viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = True
                            viewPartidas.Columns.ColumnByFieldName("Precio").Visible = False
                            
                        ElseIf TipoIVA = 2 Then
                            viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = False
                            viewPartidas.Columns.ColumnByFieldName("Precio").Visible = True
                        End If

                    ElseIf splitcadena(0).Contains("R") = True Then
                        lblTipo.Text = "REMISIÓN"
                        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = False
                        viewPartidas.Columns.ColumnByFieldName("Precio").Visible = True
                    Else
                        lblTipo.Text = "---"
                    End If

                End If
            Else
                lblRFCReceptor.Text = "---"
                If TipoIVA = 1 Then
                    viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = True
                    viewPartidas.Columns.ColumnByFieldName("Precio").Visible = False
                ElseIf TipoIVA = 2 Then
                    viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = False
                    viewPartidas.Columns.ColumnByFieldName("Precio").Visible = True
                End If
            End If

            CargarTotalesDocumento()
        End If

        If lblTipo.Text = "FACTURA" Then
            lblTipo.ForeColor = Color.Green
        ElseIf lblTipo.Text = "REMISIÓN" Then
            lblTipo.ForeColor = Color.Purple
        Else
            lblTipo.ForeColor = Color.Black
        End If

        
    End Sub

    Private Sub CargarPartidas()
        Dim dtinformacionPartidas As DataTable

        If ClienteID = 816 Then 'Andrea
            dtinformacionPartidas = OBJBU.ObtenerPartidasOTAndrea(OTs, SesionID)
        Else
            dtinformacionPartidas = OBJBU.ObtenerPartidasOT(OTs, SesionID)
        End If

        grdPartidasOT.DataSource = dtinformacionPartidas
        DiseñoGrid()
    End Sub

    Private Sub DiseñoGrid()
        viewPartidas.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewPartidas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        viewPartidas.IndicatorWidth = 28
        viewPartidas.Columns.ColumnByFieldName("Seleccionar").Caption = " "
        viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Caption = "OT"
        viewPartidas.Columns.ColumnByFieldName("Articulo").Caption = "Artículo"
        viewPartidas.Columns.ColumnByFieldName("Tienda").Caption = "Tienda"
        viewPartidas.Columns.ColumnByFieldName("OrdenCliente").Caption = "OC"
        viewPartidas.Columns.ColumnByFieldName("Precio").Caption = "Precio"
        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Caption = "Precio"
        viewPartidas.Columns.ColumnByFieldName("TotalPares").Caption = "Pares"
        viewPartidas.Columns.ColumnByFieldName("Documentado").Caption = "D"
        viewPartidas.Columns.ColumnByFieldName("Documentar").Caption = "*XD"
        viewPartidas.Columns.ColumnByFieldName("Ocultar").Visible = False


        viewPartidas.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewPartidas.Columns.ColumnByFieldName("Partida").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewPartidas.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewPartidas.Columns.ColumnByFieldName("Documentado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewPartidas.Columns.ColumnByFieldName("Documentar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        viewPartidas.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatString = "N0"
        viewPartidas.Columns.ColumnByFieldName("Documentado").DisplayFormat.FormatString = "N0"
        viewPartidas.Columns.ColumnByFieldName("Documentar").DisplayFormat.FormatString = "N0"
        viewPartidas.Columns.ColumnByFieldName("Partida").DisplayFormat.FormatString = "N0"
        viewPartidas.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "N2"
        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").DisplayFormat.FormatString = "N2"

       

        viewPartidas.Columns.ColumnByFieldName("Seleccionar").Width = 20
        viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Width = 50
        viewPartidas.Columns.ColumnByFieldName("Articulo").Width = 140
        viewPartidas.Columns.ColumnByFieldName("Tienda").Width = 140
        viewPartidas.Columns.ColumnByFieldName("OrdenCliente").Width = 60
        viewPartidas.Columns.ColumnByFieldName("Precio").Width = 40
        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Width = 40
        viewPartidas.Columns.ColumnByFieldName("TotalPares").Width = 40
        viewPartidas.Columns.ColumnByFieldName("Documentado").Width = 40
        viewPartidas.Columns.ColumnByFieldName("Documentar").Width = 40


        'viewPartidas.Columns.ColumnByFieldName("Seleccionar").Width = 20
        'viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Width = 50
        'viewPartidas.Columns.ColumnByFieldName("Precio").Width = 40
        'viewPartidas.Columns.ColumnByFieldName("TotalPares").Width = 40
        'viewPartidas.Columns.ColumnByFieldName("Documentado").Width = 40
        'viewPartidas.Columns.ColumnByFieldName("Documentar").Width = 40
        'viewPartidas.Columns.ColumnByFieldName("Articulo").Width = 140
        'viewPartidas.Columns.ColumnByFieldName("Tienda").Width = 140
        'viewPartidas.Columns.ColumnByFieldName("OrdenCliente").Width = 60
        'viewPartidas.Columns.ColumnByFieldName("Partida").Width = 30


        viewPartidas.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("Partida").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("OrdenCliente").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("Documentado").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("Documentar").OptionsColumn.AllowSize = True
        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").OptionsColumn.AllowSize = True


        viewPartidas.Columns.ColumnByFieldName("Articulo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewPartidas.Columns.ColumnByFieldName("Tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        viewPartidas.Columns.ColumnByFieldName("OrdenCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        viewPartidas.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("Partida").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("OrdenCliente").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("Documentado").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").OptionsColumn.AllowEdit = False

        viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoPartidaID").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoPartidaID").Visible = False

        viewPartidas.Columns.ColumnByFieldName("ProductoEstilo").OptionsColumn.AllowEdit = False
        viewPartidas.Columns.ColumnByFieldName("ProductoEstilo").Visible = False

        If TipoIVA = 1 Then
            viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = True
            viewPartidas.Columns.ColumnByFieldName("Precio").Visible = False
        ElseIf TipoIVA = 2 Then
            viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = False
            viewPartidas.Columns.ColumnByFieldName("Precio").Visible = True
        Else
            viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Visible = False
            viewPartidas.Columns.ColumnByFieldName("Precio").Visible = False
        End If

        viewPartidas.Columns.ColumnByFieldName("OrdentrabajoID").Visible = False
        viewPartidas.Columns.ColumnByFieldName("PedidoSAY").Visible = False

        viewPartidas.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(viewPartidas.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            viewPartidas.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "TotalPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewPartidas.GroupSummary.Add(item)
        End If


        If IsNothing(viewPartidas.Columns("Documentado").Summary.FirstOrDefault(Function(x) x.FieldName = "Documentado")) = True Then
            viewPartidas.Columns("Documentado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Documentado", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Documentado"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewPartidas.GroupSummary.Add(item)
        End If

        If IsNothing(viewPartidas.Columns("Documentar").Summary.FirstOrDefault(Function(x) x.FieldName = "Documentar")) = True Then
            viewPartidas.Columns("Documentar").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Documentar", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Documentar"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewPartidas.GroupSummary.Add(item)
        End If

    End Sub

    Private Sub viewPartidas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewPartidas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub



    Private Sub viewPartidas_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles viewPartidas.CustomRowCellEdit
        Dim View2 As GridView = sender
        Dim ParesDocumentados As Integer = 0
        Dim ParesPartidaOT As Integer = 0

        If (e.RowHandle >= 0) Then
            If e.Column.FieldName = "Seleccionar" Then
                ParesDocumentados = viewPartidas.GetRowCellValue(e.RowHandle, "Documentado")
                ParesPartidaOT = viewPartidas.GetRowCellValue(e.RowHandle, "TotalPares")

                If ParesDocumentados = ParesPartidaOT Then
                    e.RepositoryItem = emptyEditor
                End If

            End If
        End If
    End Sub

    Private Sub viewPartidas_CustomRowFilter(sender As Object, e As RowFilterEventArgs) Handles viewPartidas.CustomRowFilter
        Dim view As ColumnView = CType(sender, ColumnView)
        Dim OcultarFila As Integer = view.GetListSourceRowCellValue(e.ListSourceRow, "Ocultar").ToString()

        'Dim OcultarFila As Integer = view.GetRowCellValue(view.GetVisibleRowHandle(e.Handled), "Ocultar").ToString()
        ' Check whether the current row contains "USA" in the "Country" field.
        If OcultarFila > 0 Then
            ' Make the current row visible.
            e.Visible = False
            ' Prevent default processing, so the row will be visible 
            ' regardless of the view's filter.
            e.Handled = True
        End If
        '-------------------------------------------------------------------
        

    End Sub



    Private Sub viewPartidas_KeyUp(sender As Object, e As KeyEventArgs) Handles viewPartidas.KeyUp
        Dim IndexFila As Integer = -1
        If e.KeyCode = "13" Then
            If FormatoInvalido = False Then
                IndexFila = viewPartidas.FocusedRowHandle
                If IndexFila < viewPartidas.DataRowCount Then
                    ' viewPartidas.FocusedRowHandle = IndexFila + 1
                End If
                CargarTotalesDocumento()
            End If
        End If
    End Sub

    Private Sub viewPartidas_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles viewPartidas.RowCellClick
        Dim ParesPartidaOT As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPorDocumentar As Integer = 0
        Dim Precio As Double = 0
        Dim Total As Double = 0
        Dim ExisteParesDocumentar As Boolean = False

        Try

            If IsNumeric(viewPartidas.GetRowCellValue(e.RowHandle, "Documentar")) = True Then
                If viewPartidas.GetRowCellValue(e.RowHandle, "Documentar") > 0 Then
                    ExisteParesDocumentar = True
                End If

            End If

            If e.Column.FieldName = "Seleccionar" Then
                If CBool(viewPartidas.GetRowCellValue(e.RowHandle, "Seleccionar")) = True Then
                    viewPartidas.SetRowCellValue(e.RowHandle, "Seleccionar", False)
                    viewPartidas.SetRowCellValue(e.RowHandle, "Documentar", 0)
                    ContadorPartidas -= 1
                Else
                    viewPartidas.SetRowCellValue(e.RowHandle, "Seleccionar", True)
                    ParesPartidaOT = viewPartidas.GetRowCellValue(e.RowHandle, "TotalPares").ToString()
                    ParesDocumentados = viewPartidas.GetRowCellValue(e.RowHandle, "Documentado").ToString()
                    ParesPorDocumentar = ParesPartidaOT - ParesDocumentados

                    viewPartidas.SetRowCellValue(e.RowHandle, "Documentar", ParesPorDocumentar)
                    ContadorPartidas += 1

                End If

            Else
                If ExisteParesDocumentar = True Then
                    viewPartidas.SetRowCellValue(e.RowHandle, "Seleccionar", True)
                    ParesPartidaOT = viewPartidas.GetRowCellValue(e.RowHandle, "TotalPares").ToString()
                    ParesDocumentados = viewPartidas.GetRowCellValue(e.RowHandle, "Documentado").ToString()
                    ParesPorDocumentar = viewPartidas.GetRowCellValue(e.RowHandle, "Documentar").ToString()

                    viewPartidas.SetRowCellValue(e.RowHandle, "Documentar", ParesPorDocumentar)

                End If

            End If
            viewPartidas.UpdateSummary()
            CargarTotalesDocumento()
            lblTotalSeleccionados.Text = ContadorPartidas.ToString()
        Catch ex As Exception
            show_message("Error", "Ocurrio un error,asegurese que los datos son correctos.")
        End Try


    End Sub

    Private Function ObtenerTipoDocumento(ByVal RazonSocial As String) As String
        Dim splitcadena As String()
        Dim TipoDocumento As String = ""

        splitcadena = Split(RazonSocial, "-")

        If splitcadena.Count > 0 Then
            If splitcadena(0).Contains("F") = True Then
                TipoDocumento = "F"
            ElseIf splitcadena(0).Contains("R") = True Then
                TipoDocumento = "R"
            Else
                lblTipo.Text = "---"
            End If
        End If

        Return TipoDocumento

    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPorDocumentar As Integer = 0
        Dim OrdenTrabajoPartida As Integer = 0
        Dim ProductoEstilo As Integer = 0
        Dim PrecioPartida As Double = 0
        Dim dtinformacionrfc As DataTable
        Dim TipoDocumento As String = ""
        Dim UsoCFDI As String = ""

        NumeroFilas = viewPartidas.DataRowCount

        Try
            ContadorPartidas = 0
            lblTotalSeleccionados.Text = "0"

            If cmbRazonSocial.SelectedIndex > 0 Then

                If TotalPares = 0 Then
                    show_message("Advertencia", "No se han capturado los pares a generar en el documento.")
                    Return
                End If

                Cursor = Cursors.WaitCursor

                TipoDocumento = ObtenerTipoDocumento(cmbRazonSocial.Text)

                If lblUsoCFDI.Text = "POR DEFINIR" Then
                    UsoCFDI = "P01"
                End If

                Dim _Pares As Integer = 0
                Dim _PrecioUnitario As Double = 0
                Dim _PrecioUnitarioDocumento As Double = 0
                Dim _Subtotal As Double = 0
                Dim _Descuento As Double = 0
                Dim _Importe As Double = 0
                Dim _IVA As Double = 0
                Dim _MontoTotal As Double = 0
                Dim _PorcentajeDescuento As Double = 0
                Dim dtDescuentoCliente As DataTable
                Dim _PrecioDocumento As Double = 0

                Dim _TotalPares As Integer = 0
                Dim _TotalPrecioUnitario As Double = 0
                Dim _TotalPrecioUnitarioDocumento As Double = 0
                Dim _TotalSubtotal As Double = 0
                Dim _TotalDescuento As Double = 0
                Dim _TotalImporte As Double = 0
                Dim _TotalIVA As Double = 0
                Dim _TotalMontoTotal As Double = 0
                Dim EsDescuentoEncadenado As Boolean = False
                Dim _DescuentoNuevo As Double = 0
                Dim _SubtotalNuevo As Double = 0
                Dim _PrecioPEdido As Double = 0

                dtDescuentoCliente = OBJBU.ObtenerFactorDescuento(ClienteID)

                If IsNothing(dtDescuentoCliente) = True Then
                    _PorcentajeDescuento = 0
                Else
                    If dtDescuentoCliente.Rows.Count > 0 Then
                        _PorcentajeDescuento = dtDescuentoCliente.Rows(0).Item(0)
                    Else
                        _PorcentajeDescuento = 0
                    End If
                End If



                For index As Integer = 0 To NumeroFilas Step 1
                    _PrecioPEdido = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")


                    If TipoDocumento = "F" Then
                        If TipoIVA = 1 Then
                            PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "PrecioSinIVA")
                        ElseIf TipoIVA = 2 Then
                            PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                        End If
                    ElseIf TipoDocumento = "R" Then
                        PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                    End If

                    ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado")
                    If IsNumeric(viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
                        ParesPorDocumentar = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")
                    Else
                        ParesPorDocumentar = 0
                    End If

                    _PrecioPEdido = Math.Round(_PrecioPEdido, 2)
                    PrecioPartida = Math.Round(PrecioPartida, 2)

                    If ParesPorDocumentar > 0 Then

                        If TipoDocumento = "F" Then
                            If TipoIVA = 1 Then
                                _Pares = ParesPorDocumentar
                                _PrecioUnitario = _PrecioPEdido
                                _PrecioUnitarioDocumento = PrecioPartida
                                _Subtotal = _PrecioUnitarioDocumento * _Pares
                                _Descuento = Math.Round(_Subtotal * (_PorcentajeDescuento / 100), 2)
                                _Importe = _Subtotal - _Descuento
                                _IVA = Math.Round(_Importe * 0.16, 2)
                                _MontoTotal = _IVA + _Importe
                            ElseIf TipoIVA = 2 Then
                                _Pares = ParesPorDocumentar
                                _PrecioUnitario = _PrecioPEdido
                                _PrecioUnitarioDocumento = PrecioPartida
                                _Subtotal = _PrecioUnitarioDocumento * _Pares
                                _Descuento = Math.Round(_Subtotal * (_PorcentajeDescuento / 100), 2)
                                _Importe = _Subtotal - _Descuento
                                _IVA = Math.Round(_Importe * 0.16, 2)
                                _MontoTotal = _IVA + _Importe
                            End If
                        ElseIf TipoDocumento = "R" Then
                            _Pares = ParesPorDocumentar
                            _PrecioUnitario = _PrecioPEdido
                            _PrecioUnitarioDocumento = PrecioPartida
                            _Subtotal = _PrecioUnitarioDocumento * _Pares
                            _Descuento = Math.Round(_Subtotal * (_PorcentajeDescuento / 100), 2)
                            _Importe = _Subtotal - _Descuento
                            '_IVA = _Importe * 0.16
                            _IVA = 0
                            _MontoTotal = _IVA + _Importe
                        End If
                        _TotalPares += _Pares
                        _TotalPrecioUnitario += _PrecioUnitario
                        _TotalPrecioUnitarioDocumento += _PrecioUnitarioDocumento
                        '_TotalSubtotal += _Subtotal
                        '_TotalDescuento += _Descuento
                        '_TotalImporte += _Importe
                        '_TotalIVA += _IVA
                        '_TotalMontoTotal += _MontoTotal

                        _TotalSubtotal += Math.Round(_Subtotal, 2)
                        _TotalDescuento += Math.Round(_Descuento, 2)
                        _TotalImporte += Math.Round(_Importe, 2)
                        _TotalIVA += Math.Round(_IVA, 2)
                        _TotalMontoTotal += Math.Round(_MontoTotal, 2)
                    End If
                Next

                _TotalPares = _TotalPares
                _TotalPrecioUnitario = _TotalPrecioUnitario
                _TotalPrecioUnitarioDocumento = _TotalPrecioUnitarioDocumento
                _TotalSubtotal = _TotalSubtotal
                _TotalDescuento = _TotalDescuento
                _TotalImporte = _TotalImporte
                _TotalIVA = _TotalIVA
                _TotalMontoTotal = _TotalMontoTotal


                DocumentoID += 1

                dtinformacionrfc = OBJBU.InsertarDocumento(SesionID, ClienteID, TipoDocumento, RazonSocialEmisorID, cmbRazonSocial.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, _TotalPares, _TotalSubtotal, DocumentoID, UsoCFDI, _TotalDescuento, _TotalIVA, _TotalMontoTotal, _TotalImporte, DocumentoID, _PorcentajeDescuento)


                For index As Integer = 0 To NumeroFilas Step 1

                    _PrecioPEdido = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

                    OrdenTrabajoPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "OrdenTrabajoPartidaID")
                    ProductoEstilo = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "ProductoEstilo")

                    If TipoDocumento = "F" Then
                        If TipoIVA = 1 Then
                            PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "PrecioSinIVA")
                        ElseIf TipoIVA = 2 Then
                            PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                        End If
                    ElseIf TipoDocumento = "R" Then
                        PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                    End If

                    'PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

                    _PrecioPEdido = Math.Round(_PrecioPEdido, 2)
                    PrecioPartida = Math.Round(PrecioPartida, 2)

                    ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado")
                    If IsNumeric(viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
                        ParesPorDocumentar = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")
                    Else
                        ParesPorDocumentar = 0
                    End If

                    If ParesPorDocumentar > 0 Then
                        If dtinformacionrfc.Rows.Count > 0 Then
                            If TipoDocumento = "F" Then
                                If TipoIVA = 1 Then
                                    _Pares = ParesPorDocumentar
                                    _PrecioUnitario = _PrecioPEdido
                                    _PrecioUnitarioDocumento = PrecioPartida
                                    _Subtotal = _PrecioUnitarioDocumento * _Pares
                                    _Descuento = Math.Round(_Subtotal * (_PorcentajeDescuento / 100), 2)
                                    _Importe = _Subtotal - _Descuento
                                    _IVA = Math.Round(_Importe * 0.16, 2)
                                    _MontoTotal = _IVA + _Importe

                                ElseIf TipoIVA = 2 Then

                                    _Pares = ParesPorDocumentar
                                    _PrecioUnitario = _PrecioPEdido
                                    _PrecioUnitarioDocumento = PrecioPartida
                                    _Subtotal = _PrecioUnitarioDocumento * _Pares
                                    _Descuento = Math.Round(_Subtotal * (_PorcentajeDescuento / 100), 2)
                                    _Importe = _Subtotal - _Descuento
                                    _IVA = Math.Round(_Importe * 0.16, 2)
                                    _MontoTotal = _IVA + _Importe
                                End If
                            ElseIf TipoDocumento = "R" Then
                                _Pares = ParesPorDocumentar
                                _PrecioUnitario = _PrecioPEdido
                                _PrecioUnitarioDocumento = PrecioPartida
                                _Subtotal = _PrecioUnitarioDocumento * _Pares
                                '_Descuento = _Subtotal * _PorcentajeDescuento
                                _Descuento = Math.Round(_Subtotal * (_PorcentajeDescuento / 100), 2)
                                _Importe = _Subtotal - _Descuento
                                '_IVA = _Importe * 0.16
                                _IVA = 0
                                _MontoTotal = _IVA + _Importe
                            End If

                            _PrecioUnitario = Math.Round(_PrecioUnitario, 2)
                            _PrecioUnitarioDocumento = Math.Round(_PrecioUnitarioDocumento, 2)
                            _Subtotal = Math.Round(_Subtotal, 2)
                            _Descuento = Math.Round(_Descuento, 2)
                            _Importe = Math.Round(_Importe, 2)
                            _IVA = Math.Round(_IVA, 2)
                            _MontoTotal = Math.Round(_MontoTotal, 2)


                            OBJBU.InsertarDetallesDocumento(dtinformacionrfc.Rows(0).Item(0), OrdenTrabajoPartida, ProductoEstilo, ParesPorDocumentar, _PrecioPEdido, _PrecioUnitarioDocumento, _Subtotal, _Descuento, _Importe, _IVA, _MontoTotal, SesionID)
                        End If

                    End If

                    viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado", ParesDocumentados + ParesPorDocumentar)
                    viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar", 0)



                Next

                If dtinformacionrfc.Rows.Count > 0 Then
                    OBJBU.ActualizarOrdenCompraDocumento(SesionID, dtinformacionrfc.Rows(0).Item(0))
                    OBJBU.ActualizarTiendaDocumento(SesionID, dtinformacionrfc.Rows(0).Item(0))
                    OBJBU.ActualizarUsoDocumento(SesionID, dtinformacionrfc.Rows(0).Item(0))
                End If



                lblTotalPares.Text = "0"
                lblMontoDocumento.Text = "$ 0"
                TotalPares = 0
                TotalDocumento = 0


                CargarDocumentos()

                If DosNivelesPantalla = False Then
                    'Dos niveles
                    SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
                    SplitContainer3.SplitterDistance = SplitContainer4.Height - 4
                    SplitContainer4.SplitterDistance = 30
                    SplitContainer3.SplitterDistance = SplitContainer1.Height - 4
                    SplitContainer3.Visible = True
                    Panel8.Visible = False
                    DosNivelesPantalla = True

                    viewPartidas.Columns.ColumnByFieldName("Partida").Width = 30
                    viewPartidas.Columns.ColumnByFieldName("Precio").Width = 50
                    viewPartidas.Columns.ColumnByFieldName("PrecioSinIVA").Width = 50
                    viewPartidas.Columns.ColumnByFieldName("OrdenTrabajoSAYID").Width = 35

                    'viewPartidas.FocusedRowHandle


                End If

                Dim FilaFocus As Integer = 0

                NumeroFilas = viewPartidas.DataRowCount

                FilaFocus = viewPartidas.FocusedRowHandle
                viewPartidas.FocusedRowHandle = False
                viewPartidas.RefreshRow(FilaFocus)

                Cursor = Cursors.Default
                'show_message("Exito", "Se ha generado el documento.")
            Else
                show_message("Advertencia", "No se ha seleccionado una Razón Social.")
            End If


            OcultarFilas()

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al guardar la información asegurese que los datos son correctos.")
        End Try


    End Sub


    Private Sub OcultarFilas()
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim TotalPares As Integer = 0
        Dim OcultarFila As Integer = 0
        Dim Partida As Integer = 0
        Dim ListaRow As New List(Of Integer)
        Dim contador As Integer = 0
        Dim Index As Integer = 0
        Dim focus As Integer = 0
        NumeroFilas = viewPartidas.DataRowCount - 1

        While NumeroFilas >= Index
            ParesDocumentados = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(Index), "Documentado")
            TotalPares = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(Index), "TotalPares")
            Partida = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(Index), "Partida")

            OcultarFila = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(Index), "Ocultar")
            If ParesDocumentados = TotalPares Then
                viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(Index), "Ocultar", 1)
                ListaRow.Add(viewPartidas.GetVisibleRowHandle(Index))
                NumeroFilas -= 1
                Index -= 1
                viewPartidas.FocusedRowHandle = Index
            End If
            Index += 1
        End While

        viewPartidas.FocusedRowHandle = -1
      
    End Sub

    Private Sub QuitarFocusPartida()
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPorDocumentar As Integer = 0
        Dim Precio As Double = 0
        Dim TotalPartida As Double = 0
        Dim Total As Double = 0
        Dim TotalPares2 As Integer = 0
        Dim FilaFocus As Integer = 0

        NumeroFilas = viewPartidas.DataRowCount

        FilaFocus = viewPartidas.FocusedRowHandle
        viewPartidas.FocusedRowHandle = False
        viewPartidas.RefreshRow(FilaFocus)

        'For index As Integer = 0 To NumeroFilas Step 1

        '    viewPartidas.FocusedRowHandle

        '    viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")

        '    If IsNumeric(viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
        '        ParesPorDocumentar = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")
        '    Else
        '        ParesPorDocumentar = 0
        '    End If

        '    TotalPares2 += ParesPorDocumentar

        '    Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

        '    TotalPartida = ParesPorDocumentar * Precio
        '    Total += TotalPartida
        'Next

    End Sub

    Private Sub CargarTotalesDocumento(ByVal Fila As Integer, ByVal Valor As Integer)
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPorDocumentar As Integer = 0
        Dim Precio As Double = 0
        Dim TotalPartida As Double = 0
        Dim Total As Double = 0
        Dim TotalPares2 As Integer = 0
        Dim splitcadena As String()
        Dim TipoDocumento As String = ""

        splitcadena = Split(cmbRazonSocial.Text, "-")

        If splitcadena.Count > 0 Then

            If splitcadena(0).Contains("F") = True Then
                TipoDocumento = "F"
            ElseIf splitcadena(0).Contains("R") = True Then
                TipoDocumento = "R"
            Else
                lblTipo.Text = "---"
            End If

        End If

        NumeroFilas = viewPartidas.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            Precio = 0
            TotalPartida = 0
            If index = Fila Then
                ParesPorDocumentar = Valor
                TotalPares2 += ParesPorDocumentar

                If TipoDocumento = "F" Then
                    If TipoIVA = 1 Then
                        Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "PrecioSinIVA")
                    ElseIf TipoIVA = 2 Then
                        Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                    End If
                ElseIf TipoDocumento = "R" Then
                    Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                End If

                'Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

                TotalPartida = ParesPorDocumentar * Precio
                Total += TotalPartida

            Else
                viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")

                If IsNumeric(viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
                    ParesPorDocumentar = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")
                Else
                    ParesPorDocumentar = 0
                End If

                TotalPares2 += ParesPorDocumentar
                Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

                TotalPartida = ParesPorDocumentar * Precio
                Total += TotalPartida
            End If


        Next

        lblTotalPares.Text = CDbl(TotalPares2).ToString("N2")
        lblMontoDocumento.Text = "$ " & Total.ToString("N2")

        TotalDocumento = Total
        TotalPares = TotalPares2

    End Sub

    Private Sub CargarTotalesDocumento()
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPorDocumentar As Integer = 0
        Dim Precio As Double = 0
        Dim TotalPartida As Double = 0
        Dim Total As Double = 0
        Dim TotalPares2 As Integer = 0
        Dim TipoDocumento As String = ""


        TipoDocumento = ObtenerTipoDocumento(cmbRazonSocial.Text)

        NumeroFilas = viewPartidas.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            Precio = 0
            TotalPartida = 0

            viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")

            If IsNumeric(viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
                ParesPorDocumentar = viewPartidas.GetRowCellDisplayText(viewPartidas.GetVisibleRowHandle(index), "Documentar")
            Else
                ParesPorDocumentar = 0
            End If

            TotalPares2 += ParesPorDocumentar

            If TipoDocumento = "F" Then
                If TipoIVA = 1 Then
                    Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "PrecioSinIVA")
                ElseIf TipoIVA = 2 Then
                    Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
                End If
            ElseIf TipoDocumento = "R" Then
                Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
            End If

            'Precio = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

            TotalPartida = ParesPorDocumentar * Precio
            Total += Math.Round(TotalPartida, 2)
        Next

        lblTotalPares.Text = TotalPares2.ToString
        lblMontoDocumento.Text = "$ " & Total.ToString("N2")

        TotalDocumento = Total
        TotalPares = TotalPares2

    End Sub


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




    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged


        Dim ParesPartidaOT As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPorDocumentar As Integer = 0
        Dim Precio As Double = 0
        Dim Total As Double = 0
        Dim NumeroFilas As Integer = 0

        Try

            NumeroFilas = viewPartidas.DataRowCount
            If NumeroFilas > 0 Then
                NumeroFilas = NumeroFilas - 1
            End If


            For index As Integer = 0 To NumeroFilas Step 1
                If chboxSeleccionarTodo.Checked = True Then
                    viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Seleccionar", True)
                    ParesPartidaOT = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "TotalPares").ToString()
                    ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado").ToString()
                    ParesPorDocumentar = ParesPartidaOT - ParesDocumentados
                    viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar", ParesPorDocumentar)
                Else
                    viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Seleccionar", False)
                    viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar", 0)
                End If

            Next


            CargarTotalesDocumento()
            If chboxSeleccionarTodo.Checked = True Then
                ContadorPartidas = viewPartidas.DataRowCount.ToString()
                lblTotalSeleccionados.Text = ContadorPartidas.ToString()
            Else
                ContadorPartidas = 0
                lblTotalSeleccionados.Text = ContadorPartidas.ToString()
            End If

        Catch ex As Exception
            show_message("Error", ex.ToString)
        End Try
    End Sub

    Private Sub CargarDocumentos()
        Dim dtDocumentos As DataTable
        dtDocumentos = OBJBU.ObtenerDocumentosSession(SesionID)
        grdDocumentos.DataSource = dtDocumentos
        DiseñoGridDocumentos()
    End Sub


    Private Sub DiseñoGridDocumentos()
        viewDocumentos.OptionsView.ColumnAutoWidth = True
        viewDocumentos.BestFitColumns()
        viewDocumentos.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewDocumentos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        viewDocumentos.IndicatorWidth = 28

        viewDocumentos.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewDocumentos.Columns.ColumnByFieldName("SubTotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        viewDocumentos.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatString = "N0"
        viewDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatString = "N2"
        viewDocumentos.Columns.ColumnByFieldName("SubTotal").DisplayFormat.FormatString = "N2"

        viewDocumentos.Columns.ColumnByFieldName("#").Caption = "#"
        viewDocumentos.Columns.ColumnByFieldName("RazonSocial").Caption = "Razón Social"
        viewDocumentos.Columns.ColumnByFieldName("SubTotal").Caption = "Importe"
        viewDocumentos.Columns.ColumnByFieldName("TotalPares").Caption = "Pares"


        viewDocumentos.Columns.ColumnByFieldName("#").OptionsColumn.AllowSize = True
        viewDocumentos.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowSize = True
        viewDocumentos.Columns.ColumnByFieldName("RazonSocial").OptionsColumn.AllowSize = True
        viewDocumentos.Columns.ColumnByFieldName("RFC").OptionsColumn.AllowSize = True
        viewDocumentos.Columns.ColumnByFieldName("Uso").OptionsColumn.AllowSize = True
        viewDocumentos.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowSize = True
        viewDocumentos.Columns.ColumnByFieldName("SubTotal").OptionsColumn.AllowSize = True


        viewDocumentos.Columns.ColumnByFieldName("Importe").Visible = False
        viewDocumentos.Columns.ColumnByFieldName("IVA").Visible = False
        viewDocumentos.Columns.ColumnByFieldName("Monto").Visible = False

        'viewDocumentos.Columns.ColumnByFieldName("DocumentoID").Width = 10
        'viewDocumentos.Columns.ColumnByFieldName("Tipo").Width = 10
        'viewDocumentos.Columns.ColumnByFieldName("RazonSocial").Width = 100
        'viewDocumentos.Columns.ColumnByFieldName("RFC").Width = 80
        'viewDocumentos.Columns.ColumnByFieldName("Uso").Width = 80
        'viewDocumentos.Columns.ColumnByFieldName("Total").Width = 40
        'viewDocumentos.Columns.ColumnByFieldName("Monto").Width = 40


        viewDocumentos.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("RazonSocial").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("RFC").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("Uso").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("Monto").OptionsColumn.AllowEdit = False
        viewDocumentos.Columns.ColumnByFieldName("SubTotal").OptionsColumn.AllowEdit = False

        'viewDocumentos.Columns.ColumnByFieldName("DocumentoID").Visible = False
        viewDocumentos.Columns.ColumnByFieldName("documentoID").Visible = False
        viewDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(viewDocumentos.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            viewDocumentos.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "TotalPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewDocumentos.GroupSummary.Add(item)
        End If


        If IsNothing(viewDocumentos.Columns("SubTotal").Summary.FirstOrDefault(Function(x) x.FieldName = "SubTotal")) = True Then
            viewDocumentos.Columns("SubTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SubTotal", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "SubTotal"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewDocumentos.GroupSummary.Add(item)
        End If
    End Sub

    Private Sub CargarDetallesDocumento(ByVal DocumentoID As Integer)
        Dim dtDocumentosDetalle As DataTable
        dtDocumentosDetalle = OBJBU.ObtenerDetallesDocumentosSession(SesionID, DocumentoID)
        gridDetallesDocumento.DataSource = dtDocumentosDetalle
        DiseñoGridDocumentosDetalles()
    End Sub

    Private Sub DiseñoGridDocumentosDetalles()
        viewDetallesDocumento.OptionsView.ColumnAutoWidth = False
        viewDetallesDocumento.BestFitColumns()
        viewDetallesDocumento.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewDetallesDocumento.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        viewDetallesDocumento.IndicatorWidth = 28

        viewDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewDetallesDocumento.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewDetallesDocumento.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        viewDetallesDocumento.Columns.ColumnByFieldName("SubTotal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        viewDetallesDocumento.Columns.ColumnByFieldName("Precio").DisplayFormat.FormatString = "N2"
        viewDetallesDocumento.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"
        viewDetallesDocumento.Columns.ColumnByFieldName("SubTotal").DisplayFormat.FormatString = "N2"

        viewDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").Caption = "Doc"
        viewDetallesDocumento.Columns.ColumnByFieldName("Articulo").Caption = "Artículo"
        viewDetallesDocumento.Columns.ColumnByFieldName("Pares").Caption = "Pares"
        viewDetallesDocumento.Columns.ColumnByFieldName("SubTotal").Caption = "Importe"

        viewDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("OT").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("OC").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("Pares").OptionsColumn.AllowSize = True
        viewDetallesDocumento.Columns.ColumnByFieldName("SubTotal").OptionsColumn.AllowSize = True

        viewDetallesDocumento.Columns.ColumnByFieldName("Descuento").Visible = False
        viewDetallesDocumento.Columns.ColumnByFieldName("Importe").Visible = False
        viewDetallesDocumento.Columns.ColumnByFieldName("IVA").Visible = False
        viewDetallesDocumento.Columns.ColumnByFieldName("MontoTotal").Visible = False


        'viewDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").Width = 20
        'viewDetallesDocumento.Columns.ColumnByFieldName("OT").Width = 30
        ''        viewDetallesDocumento.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowSize = True
        ''viewDetallesDocumento.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowSize = True
        ''viewDetallesDocumento.Columns.ColumnByFieldName("OC").OptionsColumn.AllowSize = True
        'viewDetallesDocumento.Columns.ColumnByFieldName("Precio").Width = 40
        'viewDetallesDocumento.Columns.ColumnByFieldName("Pares").Width = 30
        'viewDetallesDocumento.Columns.ColumnByFieldName("Monto").Width = 30


        viewDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("Articulo").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("Tienda").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("OC").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("Precio").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("Pares").OptionsColumn.AllowEdit = False
        viewDetallesDocumento.Columns.ColumnByFieldName("SubTotal").OptionsColumn.AllowEdit = False

        'viewDetallesDocumento.Columns.ColumnByFieldName("DocumentoID").Visible = False
        viewDetallesDocumento.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(viewDetallesDocumento.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            viewDetallesDocumento.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewDetallesDocumento.GroupSummary.Add(item)
        End If


        If IsNothing(viewDetallesDocumento.Columns("SubTotal").Summary.FirstOrDefault(Function(x) x.FieldName = "SubTotal")) = True Then
            viewDetallesDocumento.Columns("SubTotal").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SubTotal", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "SubTotal"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            viewDetallesDocumento.GroupSummary.Add(item)
        End If
    End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)
    '    'Dos niveles
    '    SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
    '    SplitContainer3.SplitterDistance = SplitContainer4.Height - 4
    '    SplitContainer4.SplitterDistance = 30

    '    'If SplitContainer1.SplitterDistance = SplitContainer1.Width - 5 Then
    '    '    SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
    '    '    SplitContainer3.SplitterDistance = SplitContainer4.Height - 4
    '    '    SplitContainer4.SplitterDistance = 30
    '    'End If
    '    SplitContainer3.SplitterDistance = SplitContainer1.Height - 4
    '    Panel8.Visible = False
    'End Sub

    Private Sub viewDocumentos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewDocumentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub viewDocumentos_RowClick(sender As Object, e As RowClickEventArgs) Handles viewDocumentos.RowClick
        Dim DocumentoID As Integer = -1
        Try
            Cursor = Cursors.WaitCursor
            DocumentoID = viewDocumentos.GetRowCellValue(e.RowHandle, "documentoID").ToString()
            CargarDetallesDocumento(DocumentoID)
            If TresNiveles = False Then
                'Tres niveles
                SplitContainer3.SplitterDistance = SplitContainer1.Height / 2
                SplitContainer4.SplitterDistance = 30
                Panel8.Visible = True
                TresNiveles = True
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar los detalles del Documento.")
        End Try

    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs)
    '    'Tres niveles
    '    SplitContainer3.SplitterDistance = SplitContainer1.Height / 2
    '    SplitContainer4.SplitterDistance = 30
    '    Panel8.Visible = True
    'End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Try

            Me.Close()
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ha Ocurrido un error al cerrar la pantalla.")
        End Try

    End Sub

    Private Sub viewPartidas_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles viewPartidas.ShowingEditor
        Dim ParesPartidaOT As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim indexFila As Integer = 0

        ParesPartidaOT = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "TotalPares")
        ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "Documentado")

        If ParesPartidaOT = ParesDocumentados Then
            e.Cancel = True
        End If
    End Sub

    Private Sub viewPartidas_ShownEditor(sender As Object, e As EventArgs) Handles viewPartidas.ShownEditor


        'ParesPartidaOT = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "TotalPares")
        ''ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "Documentado")
        'If IsNumeric(e.Value) = False Then
        '    e.Valid = False
        '    e.ErrorText = "Formato invalido."
        'ElseIf e.Value < 0 Then
        '    e.Valid = False
        '    e.ErrorText = "El número de pares tiene que ser mayor a 0."
        'Else

        '    ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "Documentado")
        '    If e.Value > (ParesPartidaOT - ParesDocumentados) Then
        '        e.Valid = False
        '        e.ErrorText = "El valor no puede ser mayor a los pares de la partida."
        '    End If
        'End If

    End Sub


    Private Sub viewPartidas_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles viewPartidas.ValidatingEditor

        Dim ParesPartidaOT As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim indexFila As Integer = 0

        If viewPartidas.FocusedRowHandle >= 0 Then
            ParesPartidaOT = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "TotalPares")
            'ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "Documentado")
            If IsNumeric(e.Value) = False Then
                e.Valid = False
                e.ErrorText = "Formato invalido."
            ElseIf e.Value < 0 Then
                e.Valid = False
                e.ErrorText = "El número de pares tiene que ser mayor a 0."
            Else

                ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.FocusedRowHandle, "Documentado")
                If e.Value > (ParesPartidaOT - ParesDocumentados) Then
                    e.Valid = False
                    e.ErrorText = "El valor no puede ser mayor a los pares de la partida."
                End If
            End If

            If e.Valid = False Then
                FormatoInvalido = True


            Else
                FormatoInvalido = False
            End If

            If FormatoInvalido = False Then
                indexFila = viewPartidas.FocusedRowHandle
                CargarTotalesDocumento(viewPartidas.FocusedRowHandle, e.Value)
                If indexFila < viewPartidas.DataRowCount Then
                    viewPartidas.FocusedRowHandle = indexFila + 1
                End If


            End If
        End If

    End Sub

    Private Sub btnGuardarDocumentos_Click(sender As Object, e As EventArgs) Handles btnGuardarDocumentos.Click
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPartida As Integer = 0
        Dim TodosDocumentodGenerados As Boolean = True
        Dim dtinformacionencabezado As DataTable
        Dim form As New VistaPreviaFacturacion_Form

        'QUITAR FILTROS DEL GRID PARA VALIDAR TODOS LOS REGISTROS
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewPartidas.Columns
            col.FilterInfo = New ColumnFilterInfo("")
        Next

        NumeroFilas = viewPartidas.DataRowCount

        Try
            Cursor = Cursors.WaitCursor
            For index As Integer = 0 To NumeroFilas Step 1
                ParesPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "TotalPares")
                ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado")
                If ParesPartida <> ParesDocumentados Then
                    TodosDocumentodGenerados = False
                End If
            Next

            If TodosDocumentodGenerados = False Then
                show_message("Advertencia", "Faltan pares por documentar.")
            Else
                dtinformacionencabezado = OBJBU.GuardarEncabezadoFacturacion(ClienteID, OTs, GObjent.PorcentajeFacturacion, GObjent.PorcentajeRemision, 0, 0, GObjent.MontoMaximoFacturacion, GObjent.RestriccionID, GObjent.TipoIVA, GObjent.MonedaID, GObjent.ImprimirOC, GObjent.ImprimirTienda, GObjent.EmpresaID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, SesionID, False)
                Guardar = True
                Me.Close()

                OBJBU.GuardarDetallesFacturacion(SesionID, ClienteID)
                form.sesionFacturacionId = SesionID
                form.dtDatosCliente = dtInformacionCliente
                form.porcentajeFacturacionCapturadoUsuario = 0
                form.porcentajeRemisionCapturadoUsuario = 0
                form.porcentajePorRazonsocial = ""
                form.tipo_RazonSocial = ""
                form.ordenesTrabajoSeleccionadas = OTs
                form.tipoPantalla = 0
                form.ParidadDocumentoExtranjero = ParidadDocumentoExtranjero
                form.facturacionAnticipada = facturacionAnticipada
                form.Show()

                'GeneracionDocumentosManuales_Form_FormClosing(Nothing, Nothing)

                'If dtinformacionencabezado.Rows.Count > 0 Then
                '    OBJBU.GuardarDetallesFacturacion(SesionID, ClienteID)
                '    form.sesionFacturacionId = SesionID
                '    form.dtDatosCliente = dtInformacionCliente
                '    form.porcentajeFacturacionCapturadoUsuario = 0
                '    form.porcentajeRemisionCapturadoUsuario = 0
                '    form.porcentajePorRazonsocial = ""
                '    form.ordenesTrabajoSeleccionadas = OTs
                '    form.tipoPantalla = 0
                '    form.Show()

                '    show_message("Exito", "Se ha generado el documento.")
                'Else
                '    show_message("Advertencia", "Ocurrio un error al generar los datos.")
                'End If

            End If
            Cursor = Cursors.Default


        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al guardar la información asegurese que los datos son correctos.")
        End Try
    End Sub

    Private Sub BloquearEdicion()
        Dim NumeroFilas As Integer = 0
        Dim ParesDocumentados As Integer = 0
        Dim ParesPartida As Integer = 0
        Dim TodosDocumentodGenerados As Boolean = True

        NumeroFilas = viewPartidas.DataRowCount

        Try
            Cursor = Cursors.WaitCursor
            For index As Integer = 0 To NumeroFilas Step 1
                ParesPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "TotalPares")
                ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado")

            Next


            If TodosDocumentodGenerados = False Then
                show_message("Advertencia", "Faltan pares por documentar.")
            Else
                show_message("Exito", "Se ha generado el documento.")
            End If
            Cursor = Cursors.Default


        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al guardar la información asegurese que los datos son correctos.")
        End Try
    End Sub


    'Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
    '    Dim NumeroFilas As Integer = 0
    '    Dim ParesDocumentados As Integer = 0
    '    Dim ParesPorDocumentar As Integer = 0
    '    Dim OrdenTrabajoPartida As Integer = 0
    '    Dim ProductoEstilo As Integer = 0
    '    Dim PrecioPartida As Double = 0
    '    Dim dtinformacionrfc As DataTable
    '    Dim TipoDocumento As String = ""
    '    Dim splitcadena As String()
    '    Dim UsoCFDI As String = ""

    '    NumeroFilas = viewPartidas.DataRowCount

    '    Try
    '        If cmbRazonSocial.SelectedIndex > 0 Then

    '            If TotalPares = 0 Then
    '                show_message("Advertencia", "No se han capturado los pares a generar en el documento.")
    '                Return
    '            End If

    '            Cursor = Cursors.WaitCursor

    '            TipoDocumento = ObtenerTipoDocumento(cmbRazonSocial.Text)

    '            splitcadena = Split(cmbRazonSocial.Text, "-")

    '            If splitcadena.Count > 0 Then

    '                If splitcadena(0).Contains("F") = True Then
    '                    TipoDocumento = "F"
    '                ElseIf splitcadena(0).Contains("R") = True Then
    '                    TipoDocumento = "R"
    '                Else
    '                    lblTipo.Text = "---"
    '                End If

    '            End If

    '            If lblUsoCFDI.Text = "POR DEFINIR" Then
    '                UsoCFDI = "P01"
    '            End If

    '            Dim _Pares As Integer = 0
    '            Dim _PrecioUnitario As Double = 0
    '            Dim _PrecioUnitarioDocumento As Double = 0
    '            Dim _Subtotal As Double = 0
    '            Dim _Descuento As Double = 0
    '            Dim _Importe As Double = 0
    '            Dim _IVA As Double = 0
    '            Dim _MontoTotal As Double = 0
    '            Dim _PorcentajeDescuento As Double = 0
    '            Dim dtDescuentoCliente As DataTable
    '            Dim _PrecioDocumento As Double = 0

    '            Dim _TotalPares As Integer = 0
    '            Dim _TotalPrecioUnitario As Double = 0
    '            Dim _TotalPrecioUnitarioDocumento As Double = 0
    '            Dim _TotalSubtotal As Double = 0
    '            Dim _TotalDescuento As Double = 0
    '            Dim _TotalImporte As Double = 0
    '            Dim _TotalIVA As Double = 0
    '            Dim _TotalMontoTotal As Double = 0
    '            Dim EsDescuentoEncadenado As Boolean = False
    '            Dim _DescuentoNuevo As Double = 0
    '            Dim _SubtotalNuevo As Double = 0

    '            dtDescuentoCliente = OBJBU.ObtenerDescuentosClientes(ClienteID)
    '            If dtDescuentoCliente.Rows.Count > 0 Then
    '                For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                    If Fila.Item("Encadenado") = "NO" Then
    '                        _PorcentajeDescuento += Fila.Item("%")
    '                    ElseIf Fila.Item("Encadenado") = "SI" Then
    '                        EsDescuentoEncadenado = True
    '                    End If
    '                Next
    '            Else
    '                _PorcentajeDescuento = 0
    '            End If

    '            For index As Integer = 0 To NumeroFilas Step 1

    '                If TipoDocumento = "F" Then
    '                    If TipoIVA = 1 Then
    '                        PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "PrecioSinIVA")
    '                    ElseIf TipoIVA = 2 Then
    '                        PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
    '                    End If
    '                ElseIf TipoDocumento = "R" Then
    '                    PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
    '                End If

    '                ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado")
    '                If IsNumeric(viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
    '                    ParesPorDocumentar = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")
    '                Else
    '                    ParesPorDocumentar = 0
    '                End If

    '                If ParesPorDocumentar > 0 Then

    '                    If TipoDocumento = "F" Then
    '                        If TipoIVA = 1 Then
    '                            _Pares = ParesPorDocumentar
    '                            _PrecioUnitario = PrecioPartida
    '                            _PrecioUnitarioDocumento = (PrecioPartida / 1.16)
    '                            _Subtotal = _PrecioUnitarioDocumento * _Pares
    '                            _DescuentoNuevo = _Subtotal
    '                            _SubtotalNuevo = _Subtotal
    '                            If EsDescuentoEncadenado = True Then
    '                                For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                                    _Descuento = _SubtotalNuevo * Fila.Item("%") / 100
    '                                    _SubtotalNuevo = _SubtotalNuevo - _Descuento
    '                                Next
    '                                _Descuento = _Subtotal - _SubtotalNuevo
    '                            Else
    '                                _Descuento = _Subtotal * _PorcentajeDescuento
    '                            End If
    '                            _Importe = _Subtotal - _Descuento
    '                            _IVA = _Importe * 0.16
    '                            _MontoTotal = _IVA + _Importe
    '                        ElseIf TipoIVA = 2 Then
    '                            _Pares = ParesPorDocumentar
    '                            _PrecioUnitario = PrecioPartida
    '                            _PrecioUnitarioDocumento = PrecioPartida
    '                            _Subtotal = _PrecioUnitarioDocumento * _Pares
    '                            _DescuentoNuevo = _Subtotal
    '                            _SubtotalNuevo = _Subtotal
    '                            If EsDescuentoEncadenado = True Then
    '                                For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                                    _Descuento = _SubtotalNuevo * Fila.Item("%") / 100
    '                                    _SubtotalNuevo = _SubtotalNuevo - _Descuento
    '                                Next
    '                                _Descuento = _Subtotal - _SubtotalNuevo
    '                            Else
    '                                _Descuento = _Subtotal * _PorcentajeDescuento
    '                            End If
    '                            _Importe = _Subtotal - _Descuento
    '                            _IVA = _Importe * 0.16
    '                            _MontoTotal = _IVA + _Importe
    '                        End If
    '                    ElseIf TipoDocumento = "R" Then
    '                        _Pares = ParesPorDocumentar
    '                        _PrecioUnitario = PrecioPartida
    '                        _PrecioUnitarioDocumento = PrecioPartida
    '                        _Subtotal = _PrecioUnitarioDocumento * _Pares
    '                        _DescuentoNuevo = _Subtotal
    '                        _SubtotalNuevo = _Subtotal
    '                        If EsDescuentoEncadenado = True Then
    '                            For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                                _Descuento = _SubtotalNuevo * Fila.Item("%") / 100
    '                                _SubtotalNuevo = _SubtotalNuevo - _Descuento
    '                            Next
    '                            _Descuento = _Subtotal - _SubtotalNuevo
    '                        Else
    '                            _Descuento = _Subtotal * _PorcentajeDescuento
    '                        End If
    '                        _Importe = _Subtotal - _Descuento
    '                        _IVA = _Importe * 0.16
    '                        _MontoTotal = _IVA + _Importe
    '                    End If
    '                    _TotalPares += _Pares
    '                    _TotalPrecioUnitario += _PrecioUnitario
    '                    _TotalPrecioUnitarioDocumento += _PrecioUnitarioDocumento
    '                    _TotalSubtotal += _Subtotal
    '                    _TotalDescuento += _Descuento
    '                    _TotalImporte += _Importe
    '                    _TotalIVA += _IVA
    '                    _TotalMontoTotal += _MontoTotal
    '                End If
    '            Next

    '            _TotalPares = _TotalPares
    '            _TotalPrecioUnitario = _TotalPrecioUnitario
    '            _TotalPrecioUnitarioDocumento = _TotalPrecioUnitarioDocumento
    '            _TotalSubtotal = _TotalSubtotal
    '            _TotalDescuento = _TotalDescuento
    '            _TotalImporte = _TotalImporte
    '            _TotalIVA = _TotalIVA
    '            _TotalMontoTotal = _TotalMontoTotal


    '            DocumentoID += 1

    '            dtinformacionrfc = OBJBU.InsertarDocumento(SesionID, ClienteID, TipoDocumento, RazonSocialEmisorID, cmbRazonSocial.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, _TotalPares, _TotalSubtotal, DocumentoID, UsoCFDI, _TotalDescuento, _TotalIVA, _TotalMontoTotal, _TotalImporte, DocumentoID)


    '            For index As Integer = 0 To NumeroFilas Step 1

    '                OrdenTrabajoPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "OrdenTrabajoPartidaID")
    '                ProductoEstilo = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "ProductoEstilo")

    '                If TipoDocumento = "F" Then
    '                    If TipoIVA = 1 Then
    '                        PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "PrecioSinIVA")
    '                    ElseIf TipoIVA = 2 Then
    '                        PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
    '                    End If
    '                ElseIf TipoDocumento = "R" Then
    '                    PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")
    '                End If

    '                'PrecioPartida = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Precio")

    '                ParesDocumentados = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado")
    '                If IsNumeric(viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")) = True Then
    '                    ParesPorDocumentar = viewPartidas.GetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar")
    '                Else
    '                    ParesPorDocumentar = 0
    '                End If

    '                If ParesPorDocumentar > 0 Then
    '                    If dtinformacionrfc.Rows.Count > 0 Then
    '                        If TipoDocumento = "F" Then
    '                            If TipoIVA = 1 Then
    '                                _Pares = ParesPorDocumentar
    '                                _PrecioUnitario = PrecioPartida
    '                                _PrecioUnitarioDocumento = (PrecioPartida / 1.16)
    '                                _Subtotal = _PrecioUnitarioDocumento * _Pares
    '                                _DescuentoNuevo = _Subtotal
    '                                _SubtotalNuevo = _Subtotal
    '                                If EsDescuentoEncadenado = True Then
    '                                    For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                                        _Descuento = _SubtotalNuevo * Fila.Item("%") / 100
    '                                        _SubtotalNuevo = _SubtotalNuevo - _Descuento
    '                                    Next
    '                                    _Descuento = _Subtotal - _SubtotalNuevo
    '                                Else
    '                                    _Descuento = _Subtotal * _PorcentajeDescuento
    '                                End If
    '                                '_Descuento = _Subtotal * _PorcentajeDescuento
    '                                _Importe = _Subtotal - _Descuento
    '                                _IVA = _Importe * 0.16
    '                                _MontoTotal = _IVA + _Importe

    '                            ElseIf TipoIVA = 2 Then

    '                                _Pares = ParesPorDocumentar
    '                                _PrecioUnitario = PrecioPartida
    '                                _PrecioUnitarioDocumento = PrecioPartida
    '                                _Subtotal = _PrecioUnitarioDocumento * _Pares
    '                                '_Descuento = _Subtotal * _PorcentajeDescuento
    '                                _DescuentoNuevo = _Subtotal
    '                                _SubtotalNuevo = _Subtotal
    '                                If EsDescuentoEncadenado = True Then
    '                                    For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                                        _Descuento = _SubtotalNuevo * Fila.Item("%") / 100
    '                                        _SubtotalNuevo = _SubtotalNuevo - _Descuento
    '                                    Next
    '                                    _Descuento = _Subtotal - _SubtotalNuevo
    '                                Else
    '                                    _Descuento = _Subtotal * _PorcentajeDescuento
    '                                End If
    '                                _Importe = _Subtotal - _Descuento
    '                                _IVA = _Importe * 0.16
    '                                _MontoTotal = _IVA + _Importe
    '                            End If
    '                        ElseIf TipoDocumento = "R" Then
    '                            _Pares = ParesPorDocumentar
    '                            _PrecioUnitario = PrecioPartida
    '                            _PrecioUnitarioDocumento = PrecioPartida
    '                            _Subtotal = _PrecioUnitarioDocumento * _Pares
    '                            '_Descuento = _Subtotal * _PorcentajeDescuento
    '                            _DescuentoNuevo = _Subtotal
    '                            _SubtotalNuevo = _Subtotal
    '                            If EsDescuentoEncadenado = True Then
    '                                For Each Fila As DataRow In dtDescuentoCliente.Rows
    '                                    _Descuento = _SubtotalNuevo * Fila.Item("%") / 100
    '                                    _SubtotalNuevo = _SubtotalNuevo - _Descuento
    '                                Next
    '                                _Descuento = _Subtotal - _SubtotalNuevo
    '                            Else
    '                                _Descuento = _Subtotal * _PorcentajeDescuento
    '                            End If
    '                            _Importe = _Subtotal - _Descuento
    '                            _IVA = _Importe * 0.16
    '                            _MontoTotal = _IVA + _Importe
    '                        End If

    '                        _PrecioUnitario = _PrecioUnitario
    '                        _PrecioUnitarioDocumento = _PrecioUnitarioDocumento
    '                        _Subtotal = _Subtotal
    '                        _Descuento = _Descuento
    '                        _Importe = _Importe
    '                        _IVA = _IVA
    '                        _MontoTotal = _MontoTotal


    '                        OBJBU.InsertarDetallesDocumento(dtinformacionrfc.Rows(0).Item(0), OrdenTrabajoPartida, ProductoEstilo, ParesPorDocumentar, _PrecioUnitario, _PrecioUnitarioDocumento, _Subtotal, _Descuento, _Importe, _IVA, _MontoTotal, SesionID)
    '                    End If

    '                End If

    '                viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentado", ParesDocumentados + ParesPorDocumentar)
    '                viewPartidas.SetRowCellValue(viewPartidas.GetVisibleRowHandle(index), "Documentar", 0)
    '            Next

    '            If dtinformacionrfc.Rows.Count > 0 Then
    '                OBJBU.ActualizarOrdenCompraDocumento(SesionID, dtinformacionrfc.Rows(0).Item(0))
    '                OBJBU.ActualizarTiendaDocumento(SesionID, dtinformacionrfc.Rows(0).Item(0))
    '                OBJBU.ActualizarUsoDocumento(SesionID, dtinformacionrfc.Rows(0).Item(0))
    '            End If



    '            lblTotalPares.Text = "0"
    '            lblMontoDocumento.Text = "$ 0"
    '            TotalPares = 0
    '            TotalDocumento = 0


    '            CargarDocumentos()

    '            If DosNivelesPantalla = False Then
    '                'Dos niveles
    '                SplitContainer1.SplitterDistance = SplitContainer1.Width / 2
    '                SplitContainer3.SplitterDistance = SplitContainer4.Height - 4
    '                SplitContainer4.SplitterDistance = 30
    '                SplitContainer3.SplitterDistance = SplitContainer1.Height - 4
    '                SplitContainer3.Visible = True
    '                Panel8.Visible = False
    '                DosNivelesPantalla = True
    '            End If

    '            Cursor = Cursors.Default
    '            show_message("Exito", "Se ha generado el documento.")
    '        Else
    '            show_message("Advertencia", "No se ha seleccionado una Razón Social.")
    '        End If



    '    Catch ex As Exception
    '        Cursor = Cursors.Default
    '        show_message("Error", "Ocurrio un error al guardar la información asegurese que los datos son correctos.")
    '    End Try


    'End Sub

    Private Sub viewDetallesDocumento_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewDetallesDocumento.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

       
End Class