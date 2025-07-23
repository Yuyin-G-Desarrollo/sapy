Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports Entidades
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Base
Imports ToolServicios
Imports Framework.Negocios
Imports Facturacion.Negocios
Imports DevExpress.XtraGrid
Imports Stimulsoft.Report

Public Class AdministradorNotasCreditoDevolucionForm
    Dim FolioSeleccionado As Boolean = False
    Dim folioAdmonSeleccionado As Boolean = False
    Dim lstInicial As New List(Of String)
    Dim lstFiltroFolio As New List(Of String)
    Dim cliente As String = String.Empty
    Dim tipoNC As String = String.Empty
    Dim emisor As String = String.Empty
    Dim folioAdmon As Integer = 0
    Dim foliodiaactual As Integer = 0
    Dim folioTimbrar As Integer = 0
    Dim rfcId As Integer = 0
    Dim estatusNC As String = String.Empty
    Dim empresaIdTimbrar As Integer = 0
    '' VARIABLES PARA PRUEBAS
    Dim pruebas As Boolean = False
    Dim local As Boolean = False
    Dim IdNotasCreditoSeleccionadosParaEnviar As String = String.Empty
    Dim idNotasCreditoTipoDocumento As String = String.Empty
    Dim nombreCliente As String = String.Empty
    Dim StatusCorreo As Boolean = False
    Dim folioCancelar As Integer = 0
    Dim folioTipoNC As String = String.Empty
    Dim folioPDF_Pruebas As String = String.Empty
    Private Sub AdministradorNotasCreditoDevolucionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cargarInformacionDelDia()
        rpAcumulado.Checked = True
        cmbTipoNC.Items.Add("FACTURA")
        cmbTipoNC.Items.Add("DOCUMENTO")
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub btnGenerarNC_Click(sender As Object, e As EventArgs) Handles btnGenerarNC.Click
        abrirFormularioNotaCredito()
    End Sub
    Private Sub abrirFormularioNotaCredito()
        Dim objFrmNotasCredito As New NotasCreditoDevolucionForm
        Dim idNCGenerado As Integer
        objFrmNotasCredito.ShowDialog()
        idNCGenerado = objFrmNotasCredito.idNotaCreditoGenerado
        cargaNotaCreditoGeneradaEnElDia(idNCGenerado)
    End Sub
    Private Sub cargarInformacionDelDia()
        Dim cargaIndromacionDelDia As New NotasCreditoDevoluciones
        Dim dtInformacionDia As New DataTable
        Dim objCargaNotas As New NotaCreditoDevolucionesBU
        dtInformacionDia = objCargaNotas.cargaInformacionDelDiaNotasCredito
        If dtInformacionDia.Rows.Count > 0 Then
            grdNotasCreditoDevoluciones.DataSource = dtInformacionDia
            diseñoGridAdministradorNotasCredito(wvNotasCreditoDevoluciones)
        End If
    End Sub
    Private Sub diseñoGridAdministradorNotasCredito(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvNotasCreditoDevoluciones) '' pone color a las filas del gridview
        wvNotasCreditoDevoluciones.BestFitColumns()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
            If col.FieldName = "#" Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 30
            End If
            If col.FieldName = "Nota Credito" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
            End If
            If col.FieldName = "Estatus" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 85
            End If
            If col.FieldName = "Tipo" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Tipo Concepto" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 85
            End If
            If col.FieldName = "Empresa Emisor" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 304
            End If
            If col.FieldName = "Cliente" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 310
            End If
            If col.FieldName = "Observaciones" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 180
            End If
            If col.FieldName = "Subtotal" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 77
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N2"
            End If
            If col.FieldName = "IVA" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 65
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N2"
            End If
            If col.FieldName = "Total" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 77
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "N2"
            End If
            If col.FieldName = "rfcId" Then
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "empresaId" Then
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "correo" Then
                col.Visible = False
            End If
            If col.FieldName = "ruta_xml" Then
                col.Visible = False
            End If
            If col.FieldName = "ruta_pdf" Then
                col.Visible = False
            End If
            If col.FieldName = "Folio_P" Then
                col.Visible = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("Subtotal") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("Total") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next
        Grid.IndicatorWidth = 30
    End Sub
    Private Sub wvNotasCreditoDevoluciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles wvNotasCreditoDevoluciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim documentoId As Integer = 0
        documentoId = folioSeleccionadoVerDiaActual()
        If FolioSeleccionado = True Then
            Dim frmDetallesNotaCredito As New DetallesNotaCreditoForm
            frmDetallesNotaCredito.notacreditoId = documentoId
            frmDetallesNotaCredito.cliente = cliente
            frmDetallesNotaCredito.tipoNC = tipoNC
            frmDetallesNotaCredito.ShowDialog()
        End If
    End Sub

    Private Function folioSeleccionadoVerDiaActual()
        Dim folio As Integer = 0
        Dim numeroFilas As Integer
        Dim serie As String = String.Empty
        Dim folioNC As Integer = 0
        Dim filasSeleccionadas As Integer = 0
        numeroFilas = wvNotasCreditoDevoluciones.DataRowCount

        If rpAcumulado.Checked = True Then
            For x As Integer = 0 To numeroFilas Step 1
                If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(x), " ")) = True Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(x), "#")) = True Then
                    filasSeleccionadas += 1
                End If
            Next
            If filasSeleccionadas > 1 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Favor de seleccionar solo una nota de crédito.")
                FolioSeleccionado = False
            Else
                If filasSeleccionadas = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Favor de seleccionar un registro.")
                    FolioSeleccionado = False
                Else
                    For index As Integer = 0 To numeroFilas Step 1
                        If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#")) = True Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ")) = True Then
                            folio = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito").ToString()
                            cliente = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Cliente").ToString()
                            serie = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Tipo").ToString()
                            'folioNC = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Folio").ToString()
                            If serie <> "" And folio <> 0 Then
                                tipoNC = "F"
                            Else
                                tipoNC = "R"
                            End If
                            FolioSeleccionado = True
                            Exit For
                        Else
                            FolioSeleccionado = False
                        End If
                    Next
                End If

            End If
        Else
            If rpAcumulado.Checked = True Then
                For x As Integer = 0 To numeroFilas Step 1
                    If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(x), " ")) = True Then
                        filasSeleccionadas += 1
                    End If
                Next
                If filasSeleccionadas > 1 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Favor de seleccionar solo una nota de crédito.")
                    FolioSeleccionado = False
                Else
                    If filasSeleccionadas = 0 Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Favor de seleccionar un registro.")
                        FolioSeleccionado = False
                    Else
                        For index As Integer = 0 To numeroFilas Step 1
                            If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ")) = True Then
                                folio = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Id SAY").ToString()
                                cliente = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Cliente").ToString()
                                serie = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Serie").ToString()
                                folioNC = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Folio").ToString()
                                If serie <> "" And folio <> 0 Then
                                    tipoNC = "F"
                                Else
                                    tipoNC = "R"
                                End If
                                FolioSeleccionado = True
                                Exit For
                            Else
                                FolioSeleccionado = False
                            End If
                        Next
                    End If
                End If
            Else
                For x As Integer = 0 To numeroFilas Step 1
                    If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(x), "#")) = True Then
                        filasSeleccionadas += 1
                    End If
                Next
                If filasSeleccionadas > 1 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Favor de seleccionar solo una nota de crédito.")
                    FolioSeleccionado = False
                Else
                    If filasSeleccionadas = 0 Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Favor de seleccionar un registro.")
                        FolioSeleccionado = False
                    Else
                        For index As Integer = 0 To numeroFilas Step 1
                            If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#")) = True Then
                                folio = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Credito").ToString()
                                cliente = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Cliente").ToString()
                                tipoNC = wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Tipo").ToString()
                                FolioSeleccionado = True
                                Exit For
                            Else
                                FolioSeleccionado = False
                            End If
                        Next
                    End If
                End If
            End If
        End If
        Return folio
    End Function

    Private Sub btnSeleccionarEstatus_Click(sender As Object, e As EventArgs) Handles btnSeleccionarEstatus.Click
        Dim listado As New ListadoParametrosProyeccionCobranza
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_busqueda = 60
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        grdEstatus.DataSource = listado.listaParametros
        With grdEstatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = False
            .DisplayLayout.Bands(0).Columns(1).Width = 52
        End With
    End Sub
    Private Sub btnEstatus_Click(sender As Object, e As EventArgs) Handles btnEstatus.Click
        grdEstatus.DataSource = lstInicial
        grdEstatus.DataSource = Nothing
    End Sub
    Private Sub grdEstatus_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdEstatus.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub btnSeleccionarCliente_Click(sender As Object, e As EventArgs) Handles btnSeleccionarCliente.Click
        Dim listado As New ListadoParametrosProyeccionCobranza
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_busqueda = 59
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        grdClientes.DataSource = listado.listaParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Width = 153
        End With
    End Sub
    Private Sub btnLImpiarCliente_Click(sender As Object, e As EventArgs) Handles btnLImpiarCliente.Click
        grdClientes.DataSource = lstInicial
        grdClientes.DataSource = Nothing
    End Sub
    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub txtFiltroFolioNC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioNC.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
                If String.IsNullOrEmpty(txtFiltroFolioNC.Text) Then Return

                lstFiltroFolio.Add(txtFiltroFolioNC.Text)
                grdFolioNC.DataSource = Nothing
                grdFolioNC.DataSource = lstFiltroFolio

                txtFiltroFolioNC.Text = String.Empty
            End If
        End If
    End Sub
    Private Sub grdFolioNC_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioNC.InitializeLayout
        grid_diseño(grdFolioNC)
        grdFolioNC.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio"
    End Sub
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20 ''---> tamaño selector ultragrid
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub
    Private Sub grdFolioNC_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFolioNC.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub btnAgregarRacSocEmisor_Click(sender As Object, e As EventArgs) Handles btnAgregarRacSocEmisor.Click
        Dim listado As New ListadoParametrosProyeccionCobranza
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_busqueda = 58
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        grdRazSocEmisor.DataSource = listado.listaParametros
        With grdRazSocEmisor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Width = 153
        End With
    End Sub
    Private Sub btnLimpiarRacZocEmisor_Click(sender As Object, e As EventArgs) Handles btnLimpiarRacZocEmisor.Click
        grdRazSocEmisor.DataSource = lstInicial
        grdRazSocEmisor.DataSource = Nothing
    End Sub
    Private Sub grdRazSocEmisor_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdRazSocEmisor.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
    Private Sub wvNotasCreditoDevoluciones_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles wvNotasCreditoDevoluciones.CustomDrawCell
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Estatus" Then
                If wvNotasCreditoDevoluciones.GetRowCellValue(e.RowHandle, "Estatus") = "TIMBRADA" Then
                    e.Appearance.BackColor = lblTimbradas.ForeColor
                    e.Appearance.ForeColor = Color.White
                End If
            End If
            If e.Column.FieldName = "Estatus" Then
                If wvNotasCreditoDevoluciones.GetRowCellValue(e.RowHandle, "Estatus") = "POR TIMBRAR" Then
                    e.Appearance.BackColor = lblDiseñoPorTimbrar.ForeColor
                    e.Appearance.ForeColor = Color.White
                End If
            End If
            If e.Column.FieldName = "Estatus" Then
                If wvNotasCreditoDevoluciones.GetRowCellValue(e.RowHandle, "Estatus") = "CANCELADA" Then
                    e.Appearance.BackColor = lblDiseñoCancelado.ForeColor
                    e.Appearance.ForeColor = Color.White
                End If
            End If
            If e.Column.FieldName = "correo enviado" Then
                If wvNotasCreditoDevoluciones.GetRowCellValue(e.RowHandle, "correo enviado") = "NO" Then
                    e.Appearance.BackColor = lblDiseñoCancelado.ForeColor
                    e.Appearance.ForeColor = Color.Orange
                End If
            End If
        End If
    End Sub
    Private Sub btnVerPDF_Click(sender As Object, e As EventArgs) Handles btnVerPDF.Click
        CrearArchivoPDF()
    End Sub
    Private Sub CrearArchivoPDF()
        Cursor = Cursors.WaitCursor
        Dim aviso As String = ""
        Dim documentoId As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        If rpAcumulado.Checked = True Or rpDetallado.Checked = True Then
            validaGenerarPDF_XML()
            If folioAdmonSeleccionado = True Then
                If folioTipoNC <> "" Then
                    CrearArchivoPDf(folioAdmon)
                Else
                    generarPDFRemision(foliodiaactual)
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar un registro para descargar el PDF.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No puede visualizar el PDF por que la nota de credito es un documento")
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Function validaGenerarPDF_XML() As Boolean
        Dim seleccionadas As Integer = 0
        Dim numeroFilas As Integer
        numeroFilas = wvNotasCreditoDevoluciones.DataRowCount
        For index As Integer = 0 To numeroFilas Step 1
            If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ")) = True Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#")) = True Then
                folioAdmon = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito")).ToString()
                folioTipoNC = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Tipo")).ToString()
                folioPDF_Pruebas = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Folio_P")).ToString()
                folioAdmonSeleccionado = True
                Exit For
            Else
                folioAdmonSeleccionado = False
            End If
        Next
        Return folioAdmonSeleccionado
    End Function
    Private Sub CrearArchivoPDf(ByVal documentoId As Integer)
        Dim rutasTimbrado As New NotasCreditoDevoluciones
        Dim objRutasTimbrado As New NotaCreditoDevolucionesBU
        Dim dtRutas As New DataTable
        Dim pdf As String = String.Empty
        Dim separador
        Dim archivoDescargar As String = ""
        rutasTimbrado.NotaCreditoId = documentoId
        rutasTimbrado.NotaCreditoConcepto = "NOTACREDITODEVOLUCION"
        rutasTimbrado.NotaCreditoTipo = "PDF"
        Dim objUtilerias As New TransferenciaFTP("ftp://192.168.2.4", "ftpaccess", "Yuyin2017""")
        dtRutas = objRutasTimbrado.obtenerRutasTimbradoXMLPDF(rutasTimbrado)
        Dim folder As New FolderBrowserDialog
        Dim ret As DialogResult
        Dim RutaSeleccionada As String = String.Empty

        With folder
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
            ret = .ShowDialog
            RutaSeleccionada = .SelectedPath
        End With

        If ret = Windows.Forms.DialogResult.OK Then
            If dtRutas.Rows.Count > 0 Then
                pdf = dtRutas.Rows(0).Item(0)
                separador = pdf.Split("\")
                'archivoDescargar = separador(9)
                archivoDescargar = "IIA040805DZ4FACNCD" + folioPDF_Pruebas + ".pdf"
                objUtilerias.DescargarArchivo("inetpub/wwwroot/ftpNotascreditodevoluciones/EMPRESAPRUEBAS/PDF/", RutaSeleccionada, archivoDescargar)
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El archivo PDF se descargo correctamente")
            End If
        End If

    End Sub
    Private Sub btnVerXML_Click(sender As Object, e As EventArgs) Handles btnVerXML.Click
        generarArchivoXML()
    End Sub
    Private Sub generarArchivoXML()
        Me.Cursor = Cursors.WaitCursor
        If rpAcumulado.Checked = True Or rpDetallado.Checked = True Then
            validaGenerarPDF_XML()
            If folioAdmonSeleccionado = True Then
                GenerarXML(folioAdmon)
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar un registro para descargar el XML.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No puede visualizar el XML por que la nota de credito es un documento")
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub GenerarXML(ByVal documentoId As Integer)
        Dim rutasTimbrado As New NotasCreditoDevoluciones
        Dim objRutasTimbrado As New NotaCreditoDevolucionesBU
        Dim dtRutas As New DataTable
        Dim xml As String = String.Empty
        Dim objUtilerias As New TransferenciaFTP("ftp://192.168.2.4", "ftpaccess", "Yuyin2017""")
        Dim separador
        Dim archivoDescargar As String = ""
        rutasTimbrado.NotaCreditoId = documentoId
        rutasTimbrado.NotaCreditoConcepto = "NOTACREDITODEVOLUCION"
        rutasTimbrado.NotaCreditoTipo = "XML"
        dtRutas = objRutasTimbrado.obtenerRutasTimbradoXMLPDF(rutasTimbrado)

        Dim folder As New FolderBrowserDialog
        Dim ret As DialogResult
        Dim RutaSeleccionada As String = String.Empty

        With folder
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
            ret = .ShowDialog
            RutaSeleccionada = .SelectedPath
        End With

        If ret = Windows.Forms.DialogResult.OK Then
            If dtRutas.Rows.Count > 0 Then
                xml = dtRutas.Rows(0).Item(0)
                separador = xml.Split("\")
                'archivoDescargar = separador(9)
                archivoDescargar = "IIA040805DZ4FACNCD" + folioPDF_Pruebas + ".xml"
                objUtilerias.DescargarArchivo("inetpub/wwwroot/ftpNotascreditodevoluciones/EMPRESAPRUEBAS/XML/", RutaSeleccionada, archivoDescargar)
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El archivo XML se descargo correctamente")
            End If
        End If
    End Sub
    Private Sub btnAgregarRazSocReceptor_Click(sender As Object, e As EventArgs) Handles btnAgregarRazSocReceptor.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEstatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_busqueda = 61
        listado.ClientesID = ""
        If cmbTipoNC.Text = "" And cmbTipoNC.Text = "" Then
            listado.TipoNC = ""
        ElseIf cmbTipoNC.Text = "FACTURA" Then
            listado.TipoNC = "F"
        ElseIf cmbTipoNC.Text = "DOCUMENTO" Then
            listado.TipoNC = "R"
        End If
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        grdRazSocReceptor.DataSource = listado.listParametros
        With grdRazSocReceptor
            .DisplayLayout.Bands(0).Columns("Parametro").Hidden = True
            .DisplayLayout.Bands(0).Columns("Cliente").Hidden = True
            .DisplayLayout.Bands(0).Columns("RFC Activo").Hidden = True
            .DisplayLayout.Bands(0).Columns("Cliente Activo").Hidden = True
            .DisplayLayout.Bands(0).Columns("RFC").Hidden = True
            .DisplayLayout.Bands(0).Columns("Razón Social").Width = 153
        End With
    End Sub
    Private Sub btnLImpiarRazSocReceptor_Click(sender As Object, e As EventArgs) Handles btnLImpiarRazSocReceptor.Click
        grdRazSocReceptor.DataSource = lstInicial
        grdRazSocReceptor.DataSource = Nothing
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dtpFechaInicio.Value = Now
        dtpFechaFinal.Value = Now
        grdEstatus.DataSource = Nothing
        grdFolioNC.DataSource = Nothing
        grdClientes.DataSource = Nothing
        grdRazSocEmisor.DataSource = Nothing
        grdRazSocReceptor.DataSource = Nothing
        grdNotasCreditoDevoluciones.DataSource = Nothing
        wvNotasCreditoDevoluciones.Columns.Clear()
        rpAcumulado.Checked = False
        rpDetallado.Checked = False
        btnDetalles.Enabled = True
        lblVerDetalles.Enabled = True
        'cargarInformacionDelDia()
        lblTotalRegistros.Text = 0
        cmbTipoNC.Text = ""
        rpAcumulado.Checked = True
        btnDetalles.Enabled = True
        lblVerDetalles.Enabled = True
        btnVerPDF.Enabled = True
        lblVerPDF.Enabled = True
        btnVerXML.Enabled = True
        lblVerXML.Enabled = True
        btnCancelarNC.Enabled = True
        lblCancelarNC.Enabled = True
        btnTimbrar.Enabled = True
        lblTextoTimbrar.Enabled = True
        btnEnviarCorreo.Enabled = True
        lblEnviarCorreo.Enabled = True
    End Sub
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarInformacionAdministrador()
    End Sub
    Private Sub MostrarInformacionAdministrador()
        Dim dtAdministrador As New DataTable
        Dim Admon As New NotasCreditoDevoluciones
        Dim objAdministrador As New NotaCreditoDevolucionesBU
        Dim fechaInicio As Date = dtpFechaInicio.Value
        Dim fechaFin As Date = dtpFechaFinal.Value
        Dim estatusIds As String = llenarFiltrosAdministradorNC(grdEstatus)
        Dim folios As String = llenarFiltrosAdministradorNC(grdFolioNC)
        Dim clientesIds As String = llenarFiltrosAdministradorNC(grdClientes)
        Dim emisorIds As String = llenarFiltrosAdministradorNC(grdRazSocEmisor)
        Dim receptorIds As String = llenarFiltrosAdministradorNC(grdRazSocReceptor)
        grdNotasCreditoDevoluciones.DataSource = Nothing
        wvNotasCreditoDevoluciones.Columns.Clear()

        Me.Cursor = Cursors.WaitCursor

        If rpAcumulado.Checked = True Or rpDetallado.Checked = True Then
            '' REPORTE ACUMULADO SIN TIPO DE NC
            If rpAcumulado.Checked = True And rpDetallado.Checked = False And cmbTipoNC.Text = "" Then
                dtAdministrador = objAdministrador.consultarAdministrador(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds)
            Else
                If rpAcumulado.Checked = False And rpDetallado.Checked = True And cmbTipoNC.Text = "" Then '' REPORTE DETALLADO SIN TIPO NC
                    dtAdministrador = objAdministrador.consultarAdministradorDetallado(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds)
                Else
                    If rpAcumulado.Checked = True And rpDetallado.Checked = False And cmbTipoNC.Text <> "" Then '' REPORTE ACUMULADO CON TIPO NC
                        If cmbTipoNC.Text = "FACTURA" Then
                            Admon.NotaCreditoTipo = "F"
                        Else
                            Admon.NotaCreditoTipo = "R"
                        End If
                        dtAdministrador = objAdministrador.consultarAdministradorConTipoNC(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds, Admon.NotaCreditoTipo)
                    Else
                        If rpAcumulado.Checked = False And rpDetallado.Checked = True And cmbTipoNC.Text <> "" Then ''REPORTE DETALLADO CON TIPO NC
                            If cmbTipoNC.Text = "FACTURA" Then
                                Admon.NotaCreditoTipo = "F"
                            Else
                                Admon.NotaCreditoTipo = "R"
                            End If
                            dtAdministrador = objAdministrador.consultarAdministradorDetalladoConTipoNC(fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds, folios, clientesIds, Admon.NotaCreditoTipo)
                        End If
                    End If
                End If
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Falta seleccionar el tipo de reporte a mostrar.")
        End If

        If dtAdministrador.Rows.Count > 0 Then
            grdNotasCreditoDevoluciones.DataSource = dtAdministrador
            If rpAcumulado.Checked = True Then
                diseñoGridAdministrador(wvNotasCreditoDevoluciones, estatusIds)
                lblTotalRegistros.Text = dtAdministrador.Rows.Count
                btnDetalles.Enabled = True
                lblVerDetalles.Enabled = True
                btnVerPDF.Enabled = True
                lblVerPDF.Enabled = True
                btnVerXML.Enabled = True
                lblVerXML.Enabled = True
                btnCancelarNC.Enabled = True
                lblCancelarNC.Enabled = True
                btnTimbrar.Enabled = True
                lblTextoTimbrar.Enabled = True
                btnEnviarCorreo.Enabled = True
                lblEnviarCorreo.Enabled = True
            Else
                diseñoGridAcumuladoDetalles(wvNotasCreditoDevoluciones)
                lblTotalRegistros.Text = dtAdministrador.Rows.Count
                btnDetalles.Enabled = False
                lblVerDetalles.Enabled = False
                btnVerPDF.Enabled = False
                lblVerPDF.Enabled = False
                btnVerXML.Enabled = False
                lblVerXML.Enabled = False
                btnCancelarNC.Enabled = False
                lblCancelarNC.Enabled = False
                btnTimbrar.Enabled = False
                lblTextoTimbrar.Enabled = False
                btnEnviarCorreo.Enabled = False
                lblEnviarCorreo.Enabled = False
            End If

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontró información con los filtros seleccionados.")
        End If
        Me.Cursor = Cursors.Default
    End Sub
    Private Function llenarFiltrosAdministradorNC(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As String
        Dim lista As New List(Of Integer)
        For Each Row As UltraGridRow In grid.Rows
            If Row.Cells(0).Value Then lista.Add(Row.Cells(0).Value)
        Next
        Return String.Join(",", lista).ToString
    End Function
    Private Sub diseñoGridAdministrador(Grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal estatusId As String)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvNotasCreditoDevoluciones) '' pone color a las filas del gridview
        wvNotasCreditoDevoluciones.BestFitColumns()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
            If col.FieldName = " " Then
                col.OptionsColumn.AllowEdit = True
                col.Width = 25
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Nota Crédito" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Fecha" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 90
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Emisor" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 270
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Serie" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Folio" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 40
            End If
            If col.FieldName = "Cliente" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 350
            End If
            If col.FieldName = "Facturas Aplicadas" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 140
            End If
            If col.FieldName = "Pares" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 55
            End If
            If col.FieldName = "Subtotal" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "IVA" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Total" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 70
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Folios" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 90
            End If
            If col.FieldName = "Fecha Timbró" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 90
            End If
            If col.FieldName = "Usuario Timbró" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 85
            End If
            If col.FieldName = "Estatus" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 75
            End If
            If col.FieldName = "Folios Devolución" Then
                col.OptionsColumn.AllowEdit = False
            End If
            If estatusId = "461" Or estatusId = "" Then
                If col.FieldName = "Fecha Cancelación" Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 100
                    col.Visible = False
                End If
                If col.FieldName = "Usuario Canceló" Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 85
                    col.Visible = False
                End If
            Else
                If col.FieldName = "Fecha Cancelación" Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 100
                    col.Visible = True
                End If
                If col.FieldName = "Usuario Canceló" Then
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 85
                    col.Visible = True
                End If
            End If

            If col.FieldName = "rfcId" Then
                col.Visible = False
            End If
            If col.FieldName = "correo" Then
                col.Visible = False
            End If
            If col.FieldName = "ruta_xml" Then
                col.Visible = False
            End If
            If col.FieldName = "ruta_pdf" Then
                col.Visible = False
            End If
            If col.FieldName = "empresaId" Then
                col.Visible = False
            End If
            If col.FieldName = "Id Say" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 45
            End If
            If col.FieldName = "Razón Social" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 350
            End If
            If col.FieldName = "sicyid" Then
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
            If col.FieldName = "Folio_P" Then
                col.OptionsColumn.AllowEdit = False
                col.Visible = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("Pares") Or col.FieldName.Contains("Subtotal") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("Total") Or col.FieldName.Contains("Pares devueltos") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True And col.FieldName = "Pares" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Pares devueltos")) = True And col.FieldName = "Pares devueltos" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
            End If
        Next
        Grid.IndicatorWidth = 30
    End Sub
    Private Sub diseñoGridAcumuladoDetalles(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Tools.DiseñoGrid.AlternarColorEnFilas(wvNotasCreditoDevoluciones) '' pone color a las filas del gridview
        wvNotasCreditoDevoluciones.BestFitColumns()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
            If col.FieldName = "Serie" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 50
            End If
            If col.FieldName = "Id Artículo" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 60
            End If
            If col.FieldName = "Descripcion Artículo" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 390
            End If
            If col.FieldName = "Clave SAT" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 72
            End If
            If col.FieldName = "Pares Devueltos" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 90
            End If
            If col.FieldName = "Costo Unitario" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 80
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Subtotal" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 75
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "IVA" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 58
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Total" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 75
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:N2}"
            End If
            If col.FieldName = "Id Say" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 50
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Cliente" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 300
                col.Fixed = Columns.FixedStyle.Left
            End If
            If col.FieldName = "Razón Social" Then
                col.OptionsColumn.AllowEdit = False
                col.Width = 300
                col.Fixed = Columns.FixedStyle.Left
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName.Contains("Pares Devueltos") Or col.FieldName.Contains("Costo Unitario") Or col.FieldName.Contains("Subtotal") Or col.FieldName.Contains("IVA") Or col.FieldName.Contains("Total") Then
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Pares Devueltos")) = True And col.FieldName = "Pares Devueltos" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Costo Unitario")) = True Or col.FieldName = "Costo Unitario" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Subtotal")) = True And col.FieldName = "Subtotal" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "IVA")) = True And col.FieldName = "IVA" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
                If IsNothing(col.Summary.FirstOrDefault(Function(x) x.FieldName = "Total")) = True And col.FieldName = "Total" Then
                    col.Summary.Clear()
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N2}")
                End If
            End If
        Next

        Grid.IndicatorWidth = 30
    End Sub
    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click
        timbrarFacturaNotaCredito()
    End Sub
    Private Sub timbrarFacturaNotaCredito()
        Dim dtResultado As New DataTable
        Dim NCTimbrar As New NotasCreditoDevoluciones
        Dim objgeneraInformacion As New NotaCreditoDevolucionesBU
        Dim Confirmar As New Tools.ConfirmarForm
        Dim strResultado As String
        Dim timbradas As Boolean = False
        Dim errorMsg As String = String.Empty
        Try
            If wvNotasCreditoDevoluciones.RowCount > 0 Then
                SeleccionaFolioTimbrar()
                If folioAdmonSeleccionado = True Then
                    Confirmar.mensaje = "¿Desea timbrar la nota de credito?"
                    If Confirmar.ShowDialog() = DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        NCTimbrar.NotaCreditoId = folioTimbrar
                        NCTimbrar.NotaCreditoRFCCliente = nombreCliente
                        NCTimbrar.NotaCreditoRFCClienteId = rfcId
                        NCTimbrar.NotaCreditoRazSocialId = empresaIdTimbrar
                        dtResultado = objgeneraInformacion.generaInformacionTimbrado(NCTimbrar)
                        If dtResultado.Rows(0).Item(0) = "EXITO" Then
                            strResultado = TimbrarFacturasNotasCredito(NCTimbrar)
                            If strResultado.Equals("EXITO") Then
                                timbradas = True
                                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "La nota de credito se timbró correctamente.")
                            End If
                        End If
                    End If
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay registros para timbrar.")
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "No se pudo timbrar la nota de crédito.")
            Me.Cursor = Cursors.Default
        Finally
        End Try
    End Sub
    Private Function SeleccionaFolioTimbrar() As Boolean
        Dim seleccionadas As Integer = 0
        Dim numeroFilas As Integer
        Dim filasSeleccionadas As Integer = 0
        numeroFilas = wvNotasCreditoDevoluciones.DataRowCount
        If rpAcumulado.Checked = True Or rpDetallado.Checked = False Then
            For x As Integer = 0 To numeroFilas Step 1 '' VALIDA EL CONTEO DE FILAS SELECCIONADAS
                If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(x), "#")) = True Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(x), " ")) = True Then
                    filasSeleccionadas += 1
                End If
            Next
        End If
        If filasSeleccionadas > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Solo se puede timbrar una nota de crédito a la vez.")
            FolioSeleccionado = False
        Else
            If filasSeleccionadas = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Es necesario seleccionar un registro, para realizar el timbrado.")
                FolioSeleccionado = False
            End If
        End If

        For index As Integer = 0 To numeroFilas Step 1 '' VALIDA EL ESTATUS QUE SEA POR TIMBRAR
            If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ")) = True Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#")) = True Then
                estatusNC = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Estatus")).ToString()
                If estatusNC = "POR TIMBRAR" Then
                    '' SE TIMBRAN LAS NOTAS DE CREDITO DE DIAS ANTERIORES
                    If rpDetallado.Checked = True Or rpAcumulado.Checked = True Then
                        If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ")) = True Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#")) = True Then
                            folioTimbrar = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito")).ToString()
                            rfcId = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Id Say")).ToString()
                            nombreCliente = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Razón Social")).ToString()
                            empresaIdTimbrar = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "empresaId")).ToString()
                            folioAdmonSeleccionado = True
                            Exit For
                        Else
                            folioAdmonSeleccionado = False
                        End If
                    End If
                Else
                    If estatusNC = "TIMBRADA" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La nota de credito ya se encuentra timbrada")
                    End If
                    If estatusNC = "CANCELADA" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La nota de credito esta cancelada")
                    End If
                    If estatusNC = "" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La nota de credito es de tipo documento y no puede ser timbrada.")
                    End If
                    folioAdmonSeleccionado = False
                    Exit For
                End If
            End If
        Next
        Return folioAdmonSeleccionado
    End Function
    Private Function TimbrarFacturasNotasCredito(ByVal notaCredito As NotasCreditoDevoluciones) As String
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String ''= IIf(local, ServidorRestPruebas, ServidorRest)
        Dim objUtilerias As New UtileriasFacturasBU
        Dim resultado As String = String.Empty
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim tipoComprbante = "NOTACREDITODEVOLUCION"
        Dim rutaXMLEnviar As String = String.Empty

        'Servidor = "http://localhost:7639/"
        Servidor = "http://192.168.2.4:8037/"
        'llamarServicio.url = Servidor & "NotasCreditoDevoluciones/Timbrado" &
        '                    "?DocumentoID=" & notaCredito.NotaCreditoId &
        '                    "&EmpresaID=" & notaCredito.NotaCreditoRazSocialId &
        '                    "&TipoComprobante=" & tipoComprbante &
        '                    "&TimbradoPrueba=" & pruebas.ToString

        llamarServicio.url = Servidor & "NotasCreditoDevoluciones/Timbrado" &
                            "?DocumentoID=" & notaCredito.NotaCreditoId &
                            "&EmpresaID=19" &
                            "&TipoComprobante=" & tipoComprbante &
                            "&TimbradoPrueba=" & pruebas.ToString
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo
        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            'mes = Month(Now)
            'anio = Year(Now)

            'If notaCredito.NotaCreditoRazSocialId = 19 Then
            '    objUtilerias.EnviarArchivo("inetpub\wwwroot\ftpNotascreditodevoluciones\EMPRESAPRUEBAS\XML\0" + mes + anio, RutaRest)
            '    'objUtilerias.EnviarArchivo(RutaCliente, RutaRest)

            'End If

            'objUtilerias.CrearDirectorio(RutaCliente)
            'objUtilerias.CrearDirectorio(RutaServidorSICY)
            'objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, True) ''pruebas)
            'rutaXMLEnviar = RutaServidorSICY
            'rutaXMLEnviar = RutaRest
            GenerarPDF(notaCredito.NotaCreditoId, rutaXMLEnviar, notaCredito.NotaCreditoRazSocialId)
            resultado = "EXITO"
        Else
            resultado = Respuesta.aviso & "(" & notaCredito.NotaCreditoId.ToString & ")"
            Try
                'Dim objBUAdmon As New AdmonDoctosComprasPT_BU
                'objBUAdmon.ActualizarMtvoSinTimbrarFacturaPIDocumento(documentoId, resultado)
            Catch ex As Exception
            End Try
        End If

        Return resultado
    End Function
    Private Sub GenerarPDF(ByVal documentoId As Integer, ByVal rutaXMLEnviar As String, ByVal empresaId As Integer)
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String ''= IIf(local, ServidorRestPruebas, ServidorRest)
        ' Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Dim objUtilerias As New TransferenciaFTP
        'Rutas
        Dim RutaRest As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim objCorreoEnviar As New NotaCreditoDevolucionesBU
        Dim dtCorreoEnviar As New DataTable
        Dim tipoComprbante = "NOTACREDITODEVOLUCION"
        'Dim mes As String = ""
        ' Dim anio As String = ""

        'Servidor = "http://localhost:7639/"
        Servidor = "http://192.168.2.4:8037/"
        llamarServicio.url = Servidor & "NotasCreditoDevoluciones/GeneraPDF" &
                            "?DocumentoID=" & documentoId &
                            "&TipoComprobante=" & tipoComprbante &
                             "&bPruebas=" & pruebas.ToString
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)

            'objUtilerias.EnviarArchivo("NOTACREDITODEVOLUCIONES33",)
            'objUtilerias.CrearDirectorio(RutaCliente)
            'objUtilerias.CrearDirectorio(RutaServidorSICY)
            'objUtilerias.CopiarArchivoSICY(RutaRest, RutaServidorSICY, RutaCliente, True) ''local ---> true es prueba)

            'mes = Month(Now)
            'anio = Year(Now)

            'If empresaId = 19 Then
            '    'objUtilerias.EnviarArchivo("bin/TASFE/EMPRESAPRUEBAS/NOTACREDITODEVOLUCIONES33/PDF/0" + mes + anio, RutaRest)
            '    objUtilerias.EnviarArchivo("C:\inetpub\wwwroot\ftpNotascreditodevoluciones\EMPRESAPRUEBAS\XML" + mes + anio, RutaRest)
            'End If

            dtCorreoEnviar = objCorreoEnviar.consultarCorreoFacturacionEnviar(documentoId)
            If dtCorreoEnviar.Rows.Count > 0 Then
                enviarCorreoNotasCreditoDevolucion(documentoId, dtCorreoEnviar.Rows(0).Item(0), rutaXMLEnviar, RutaServidorSICY) '' envia correo automaticamente
            End If
        End If
    End Sub
    Private Sub btnEnviarCorreo_Click(sender As Object, e As EventArgs) Handles btnEnviarCorreo.Click
        enviarCorreoFacturaNotaCredito()
    End Sub
    Private Sub enviarCorreoFacturaNotaCredito()
        Dim lstCorreosEnviar As New List(Of Net.Mail.Attachment)
        Dim lstArchivosPDF As New List(Of String)
        Dim objMensaje As New Tools.ConfirmarForm
        Dim numeroFilas As Integer = 0
        Dim RenglonEnviar As Integer = 0
        Dim correoEnviar As String = String.Empty
        Dim rutaXML As String = String.Empty
        Dim rutaPDF As String = String.Empty
        Dim cliente As String = String.Empty
        If wvNotasCreditoDevoluciones.RowCount > 0 Then
            ObtenerNotasCreditoSeleccionadas()
            If IdNotasCreditoSeleccionadosParaEnviar <> "" Then
                objMensaje.mensaje = "Se enviarán por correo las notas de credito seleccionadas. ¿Desea continuar?"
                If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                    numeroFilas = wvNotasCreditoDevoluciones.DataRowCount
                    If rpAcumulado.Checked = True Or rpDetallado.Checked = True Then
                        For index As Integer = 0 To numeroFilas Step 1
                            RenglonEnviar = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito"))
                            If Split(IdNotasCreditoSeleccionadosParaEnviar, ",").Contains(RenglonEnviar) Then
                                cliente = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Cliente"))
                                correoEnviar = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "correo"))
                                rutaXML = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "ruta_xml"))
                                rutaPDF = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "ruta_pdf"))
                                If correoEnviar = "" Then
                                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El cliente: " + cliente + " no tiene correo destinatario, favor de revisarlo")
                                Else
                                    enviarCorreoNotasCreditoDevolucion(RenglonEnviar, correoEnviar, rutaXML, rutaPDF)
                                    If StatusCorreo = True Then
                                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Las notas de crédito se enviaron correctamente.")
                                    End If
                                End If
                            End If
                        Next
                    End If
                    If rpDetallado.Checked = False And rpAcumulado.Checked = False Then
                        For index As Integer = 0 To numeroFilas Step 1
                            RenglonEnviar = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Credito"))
                            If Split(IdNotasCreditoSeleccionadosParaEnviar, ",").Contains(RenglonEnviar) Then
                                cliente = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Cliente"))
                                correoEnviar = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "correo"))
                                rutaXML = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "ruta_xml"))
                                rutaPDF = (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "ruta_pdf"))
                                If correoEnviar = "" Then
                                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El cliente: " + cliente + " no tiene correo destinatario, favor de revisarlo")
                                Else
                                    enviarCorreoNotasCreditoDevolucion(RenglonEnviar, correoEnviar, rutaXML, rutaPDF)
                                    If StatusCorreo = True Then
                                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Las notas de crédito se enviaron correctamente.")
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay registros para realizar el envío.")
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub ObtenerNotasCreditoSeleccionadas()
        Dim numeroFilas As Integer
        Dim FilasSeleccionadasEnviar As Integer = 0
        Dim filasSeleccionadasTimbradas As Integer = 0
        Dim filasSeleccionadasTipoDocumento As Integer = 0

        IdNotasCreditoSeleccionadosParaEnviar = ""
        idNotasCreditoTipoDocumento = ""
        numeroFilas = wvNotasCreditoDevoluciones.DataRowCount
        If rpAcumulado.Checked = True Or rpDetallado.Checked = True Then
            For index As Integer = 0 To numeroFilas Step 1
                If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ") = True) Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#") = True) Then
                    FilasSeleccionadasEnviar += 1
                    If IdNotasCreditoSeleccionadosParaEnviar <> "" Then
                        IdNotasCreditoSeleccionadosParaEnviar += ","
                    End If
                    If (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Estatus") = "TIMBRADA") Then
                        filasSeleccionadasTimbradas += 1
                        IdNotasCreditoSeleccionadosParaEnviar += Integer.Parse(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito")).ToString()
                    End If
                    If (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Serie") = "") Then
                        filasSeleccionadasTipoDocumento += 1
                        idNotasCreditoTipoDocumento += Integer.Parse(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito")).ToString()
                    End If
                End If
            Next
        End If
        If FilasSeleccionadasEnviar = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Debe de seleccionar al menos un registro para poder realizar el envío.")
            IdNotasCreditoSeleccionadosParaEnviar = ""
        End If
        If FilasSeleccionadasEnviar > 0 And filasSeleccionadasTimbradas = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La notas de crédito tienen que estar timbradas para que puedan ser enviadas por correo.")
        End If
    End Sub
    Private Function enviarCorreoNotasCreditoDevolucion(ByVal documentoId As Integer, CorreosDestinatario As String, rutaArchivoXML As String, rutaArchivoPDF As String) As Boolean
        Dim enviosCorreoBU As New EnviosCorreoBU
        Dim notacredito As New NotasCreditoDevoluciones
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New NotaCreditoDevolucionesBU
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty

        Cursor = Cursors.WaitCursor

        Try
            dtResultadoDatosCorreos = objBU.consultarCorreosRemitentes
            remitente = dtResultadoDatosCorreos.Rows(0).Item(0).ToString()
            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

            If rutaArchivoXML <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoXML)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If
            asuntoCorreo = "Asunto: CFDI de Nota de Credito"
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI de recibo de Nota de Crédito en formato PDF y XML.</p>"
            'cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            'cadenaCorreo += " <ol>" +
            '                "<li> Cualquier cambio en el recibo de pago, en caso de que este proceda se realizará Únicamente dentro de los primeros 7 días posteriores a la expedición del comprobante; pasando este lapso de días no se harán cambios.</li>" +
            '                "<li> No Procederá la cancelación de un CFDI de recibo de pago (CRP) que se haya facturado conforme a los datos proporcionados por usted mismo. </li>" +
            '                "<li> Los documentos relacionados que se tomarán en cuenta para realizar el CFDI de pago son aquellos que usted nos proporcionó en la notificación de pago, de no recibir la notificación el pago se aplicará a los CFDI pendientes de pago más antiguos de acuerdo a lo estipulado en la regla 2.7.1.35 de la RMF.</li>" +
            '                "<li> El recibo de pago (CRP) fue emitido solo con los datos obligatorios que actualmente se encuentran regulados por el SAT (Guía de llenado del ""Complemento para recepción de Pagos"") . Por lo tanto en el recibo no verán reflejados los datos bancarios (NumOperacion, RfcEmisorCtaOrd, CtaOrdenante, RfcEmisorCtaBen, CtaBeneficiario, TipoCadPago, CertPago, CadPago, SelloPago)</li>" +
            '                "</ol>" +
            '                "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "
            CorreosDestinatario = "ddesarrollo.ti@grupoyuyin.com.mx,ge_proyectos@villagonti.com"
            If lstArchivoAdjuntos.Count > 0 Then
                entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)
                If entCorreo.CorreoEnviado = True Then
                    CorreoEnviado = "SI"
                    StatusCorreo = True
                Else
                    CorreoEnviado = "NO"
                    StatusCorreo = False
                End If
                objBU.actualizaEstadoEnviosCorreos(documentoId)
                objBU.registraBitacoraEnvioCorreos(documentoId, CorreoEnviado)
            End If

        Catch ex As Exception
            StatusCorreo = False
        End Try

        Return StatusCorreo

        Cursor = Cursors.Default
    End Function
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarReporteFormatoExcel()
    End Sub
    Private Sub exportarReporteFormatoExcel()
        Dim fechaInicio As Date = dtpFechaInicio.Text
        Dim fechaFinal As Date = dtpFechaFinal.Text
        If wvNotasCreditoDevoluciones.DataRowCount > 0 Then
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In wvNotasCreditoDevoluciones.Columns
                col.AppearanceHeader.BackColor = Color.LightSkyBlue
            Next
            If rpAcumulado.Checked = True Then
                Tools.Excel.ExportarExcel(wvNotasCreditoDevoluciones, "Reporte Acumulado")
            Else
                Tools.Excel.ExportarExcel(wvNotasCreditoDevoluciones, "Reporte Detallado")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontrarón registros para exportar.")
        End If
    End Sub
    Private Sub btnCancelarNC_Click(sender As Object, e As EventArgs) Handles btnCancelarNC.Click
        cancelaNotaCredito()
    End Sub
    Private Sub cancelaNotaCredito()
        Dim frmCancelaNotaCredito As New CancelarNotaCreditoForm
        If wvNotasCreditoDevoluciones.RowCount > 0 Then
            obtenerSeleccionFolioCancelar()
            If folioCancelar <> 0 Then
                frmCancelaNotaCredito.documentoId = folioCancelar
                frmCancelaNotaCredito.ShowDialog()
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay registros para realizar la cancelación.")
        End If
    End Sub
    Private Function obtenerSeleccionFolioCancelar()
        Dim numeroFilas As Integer
        Dim FilasSeleccionadasCancelar As Integer = 0
        Dim filasSeleccionadasTimbradas As Integer = 0

        numeroFilas = wvNotasCreditoDevoluciones.DataRowCount
        If rpAcumulado.Checked = True Or rpDetallado.Checked = True Then
            For index As Integer = 0 To numeroFilas Step 1
                If CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "#") = True) Or CBool(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), " ") = True) Then
                    FilasSeleccionadasCancelar += 1
                    If IdNotasCreditoSeleccionadosParaEnviar <> "" Then
                        IdNotasCreditoSeleccionadosParaEnviar += ","
                    End If
                    If (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Estatus") = "TIMBRADA") Then
                        folioCancelar = CInt(wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Nota Crédito")).ToString()
                    End If
                    If (wvNotasCreditoDevoluciones.GetRowCellValue(wvNotasCreditoDevoluciones.GetVisibleRowHandle(index), "Estatus") <> "TIMBRADA") Then
                        filasSeleccionadasTimbradas += 1
                    End If
                End If
            Next
        End If


        If FilasSeleccionadasCancelar = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Debe de seleccionar al menos un registro para poder realizar el envío.")
            folioCancelar = 0
        End If
        If FilasSeleccionadasCancelar > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Solo se puede cancelar una nota de crédito a la vez.")
            folioCancelar = 0
        End If
        If filasSeleccionadasTimbradas > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La nota de crédito solo se puede cancelar cuando esta timbrada.")
            folioCancelar = 0
        End If
        Return folioCancelar
    End Function
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlAcciones.Height = 32
    End Sub
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlAcciones.Height = 210
    End Sub
    Private Sub generarPDFRemision(ByVal folioRemision As Integer)
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim objBU As New NotaCreditoDevolucionesBU
        Dim dtRemision As New DataSet("dtRemision")
        Dim ReporteRemision As New StiReport
        Dim dtInformacionPares As New DataTable

        Dim entReporte As New Entidades.Reportes
        Dim dtInformacionDetalles As New DataTable
        Dim dtInformacionEncabezado As DataTable
        Dim Pares As String = String.Empty
        Dim SubTotal As String = String.Empty
        Dim Total As String = String.Empty
        Dim RemissionId As String = String.Empty
        Dim Cliente As String = String.Empty
        'Dim MensajeImportante As String = String.Empty
        Dim PDFImpreso As Boolean = False
        Dim FechaEmision As String = String.Empty
        Dim DocumentoValido As Boolean = False
        Try

            With dtInformacionPares
                .Columns.Add("Cantidad")
                .Columns.Add("Descripcion")
                .Columns.Add("Estilo")
                .Columns.Add("Precio")
                .Columns.Add("Importe")
            End With

            entReporte = objReporte.LeerReporteporClave("RPT_REMISION_NOTACREDITO_DEVOLUCION")

            dtInformacionDetalles = objBU.obtenerDetallesRemision_PDF(folioRemision)
            dtInformacionEncabezado = objBU.obtenerEncabezadoRemision_PDF(folioRemision)


            If IsNothing(dtInformacionEncabezado) = False Then
                If dtInformacionEncabezado.Rows.Count > 0 Then
                    Pares = dtInformacionEncabezado.Rows(0).Item("Pares")
                    SubTotal = dtInformacionEncabezado.Rows(0).Item("SubTotal")
                    Total = dtInformacionEncabezado.Rows(0).Item("Total")
                    RemissionId = dtInformacionEncabezado.Rows(0).Item("IdRemision")
                    Cliente = dtInformacionEncabezado.Rows(0).Item("Cliente")
                    ' MensajeImportante = dtInformacionEncabezado.Rows(0).Item("Mensaje")
                    FechaEmision = dtInformacionEncabezado.Rows(0).Item("FechaEmision")
                    DocumentoValido = True
                End If
            End If

            If DocumentoValido = True Then
                For Each Fila As DataRow In dtInformacionDetalles.Rows
                    dtInformacionPares.Rows.Add(Fila.Item("Cantidad"), Fila.Item("Descripcion"), Fila.Item("Estilo"), Fila.Item("Precio"), Fila.Item("Importe"))
                Next

                dtInformacionPares.TableName = "dtContenidoRemision"
                dtRemision.Tables.Add(dtInformacionPares)

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

                Dim Fecha As String = String.Empty

                ReporteRemision.Load(archivo)
                ReporteRemision.Compile()
                ReporteRemision.RegData(dtRemision)
                'reporteUnaTiendaConCita("RutaImagen") = Tools.Controles.ObtenerLogoNave(43)
                ReporteRemision("SubTotal") = SubTotal
                ReporteRemision("Pares") = Pares
                ReporteRemision("Total") = Total
                'ReporteRemision("Fecha") = FormatoFechaImpresion()
                ReporteRemision("Fecha") = FechaEmision
                ReporteRemision("IdRemision") = RemissionId
                'ReporteRemision("MensajeImportante") = MensajeImportante
                ReporteRemision("Nombre") = Cliente
                ReporteRemision.Dictionary.Clear()
                ReporteRemision.Dictionary.Synchronize()
                'ReporteRemision.Render()
                ReporteRemision.Show()

                PDFImpreso = True
            Else
                PDFImpreso = False
            End If

        Catch ex As Exception
            PDFImpreso = False
        End Try
    End Sub
    Private Sub cargaNotaCreditoGeneradaEnElDia(ByVal idNotaCredito As Integer)
        Dim objBU As New NotaCreditoDevolucionesBU
        Dim dtGenerada As New DataTable
        dtGenerada = objBU.obtenerNotaCreditoGeneradaEnElDia(idNotaCredito)
        If dtGenerada.Rows.Count > 0 Then
            grdNotasCreditoDevoluciones.DataSource = dtGenerada
            diseñoGridAdministradorNotasCredito(wvNotasCreditoDevoluciones)
        End If
    End Sub
    Private Sub AdministradorNotasCreditoDevolucionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
        If e.KeyCode = Keys.F1 Then
            abrirFormularioNotaCredito()
        End If
        If e.KeyCode = Keys.F5 Then
            MostrarInformacionAdministrador()
        End If
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFinal.Value < dtpFechaInicio.Value Then
            dtpFechaFinal.Value = dtpFechaInicio.Value
        End If
        dtpFechaFinal.MinDate = dtpFechaInicio.Value
    End Sub

End Class