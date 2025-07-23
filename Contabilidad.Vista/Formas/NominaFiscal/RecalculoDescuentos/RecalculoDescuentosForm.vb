Imports System.Drawing
Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report

Public Class RecalculoDescuentosForm
    Private Sub RecalculoDescuentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        cargarComboEmpresaPatron()

        RecalculoDescuentosArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("REC_DESCUENTOS", "MODIF_WORD_RD")
        RecalculoDescuentosPropuestaToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("REC_DESCUENTOS", "PROPUESTA_RD")
    End Sub

    Private Sub configuracionPermisosBotones()
        pnlCalcular.Visible = PermisosUsuarioBU.ConsultarPermiso("REC_DESCUENTOS", "RD_CALCULAR")
        pnlCalcular.Enabled = PermisosUsuarioBU.ConsultarPermiso("REC_DESCUENTOS", "RD_CALCULAR")
        pnlAutorizar.Visible = PermisosUsuarioBU.ConsultarPermiso("REC_DESCUENTOS", "RD_AUTORIZAR")
        pnlAutorizar.Enabled = PermisosUsuarioBU.ConsultarPermiso("REC_DESCUENTOS", "RD_AUTORIZAR")
    End Sub

    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.ReporteAcumuladoSueldosSalariosBU
        Dim dtEmpresa As New DataTable
        dtEmpresa = objBu.consultarPatronEmpresaBU()
        If dtEmpresa.Rows.Count > 0 Then
            If dtEmpresa.Rows.Count = 1 Then
                Dim dtRow As DataRow = dtEmpresa.NewRow
                dtRow("ID") = 0
                dtRow("PATRON") = ""
                dtEmpresa.Rows.InsertAt(dtRow, 0)
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
                cmbPatron.SelectedIndex = 1
            Else
                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"
            End If
        End If
    End Sub

    Private Sub llenarComboAnios()
        Dim objMsjError As New Tools.ErroresForm
        Dim objBU As New Negocios.RecalculosBU
        Dim dtListado As New DataTable
        cmbAnio.DataSource = Nothing

        Try
            If Not cmbPatron Is Nothing Then
                If cmbPatron.SelectedIndex <> 0 Then
                    dtListado = objBU.obtenerAniosPatron(cmbPatron.SelectedValue)
                    If Not dtListado Is Nothing Then
                        If dtListado.Rows.Count > 0 Then
                            cmbAnio.DataSource = dtListado
                            cmbAnio.DisplayMember = "Anios"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            objMsjError.mensaje = ex.Message
            objMsjError.ShowDialog()
        End Try
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        llenarComboAnios()
        configuracionPermisosBotones()
        grdListado.DataSource = Nothing
        lblSalarioMinimo.Text = "0"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarListado()
    End Sub

    Private Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        grdListado.DataSource = Nothing
        lblSalarioMinimo.Text = "0"
        Try
            If validarFiltros() Then
                Dim objBU As New Negocios.RecalculosBU
                Dim dtListado As New DataTable
                Dim patronId As Integer = cmbPatron.SelectedValue
                Dim anio As Integer = CInt(cmbAnio.Text)
                Dim tipo As Int16 = 0
                If rdoReal.Checked Then
                    tipo = 1
                End If

                dtListado = objBU.consultarRecalculosDescuentos(patronId, anio, tipo)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        grdListado.DataSource = dtListado
                        formatoGrid()
                        EncabezadoGrid(grdListado)
                        deshabilitarBotones()

                        lblSalarioMinimo.Text = dtListado.Rows(0)("UMAUtilizado").ToString
                        dtpFechaCalculo.Value = CDate(dtListado.Rows(0)("fechacreacion"))
                    Else
                        objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                        objMensajeAdv.Show()
                    End If
                Else
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.Show()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar la información de recálculo anual."
            objMensajeError.ShowDialog()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub deshabilitarBotones()
        Dim patronId As Integer = cmbPatron.SelectedValue
        Dim anio As Integer = CInt(cmbAnio.Text)
        Dim objBU As New Negocios.RecalculosBU
        Dim habilitar As Boolean = False

        habilitar = objBU.validaAutorizado(patronId, anio)

        pnlCalcular.Enabled = Not habilitar
        pnlAutorizar.Enabled = Not habilitar

    End Sub

    Public Sub formatoGrid()
        With grdListado.DisplayLayout.Bands(0)

            .Columns("ColaboradorId").Hidden = True
            .Columns("UMAUtilizado").Hidden = True
            .Columns("fechacreacion").Hidden = True

            .Columns("CodigoEmp").Header.Caption = "Código Empleado"
            .Columns("NumCredito").Header.Caption = "Número de Crédito"
            .Columns("TipoDescuento").Header.Caption = "Tipo de Descuento"
            .Columns("ValorDescuento").Header.Caption = "Valor de Descuento"
            .Columns("ImssAnterior").Header.Caption = "Anterior"
            .Columns("ImssActual").Header.Caption = "Actual"
            .Columns("ImssDif").Header.Caption = "Diferencia"
            .Columns("InfonavitAnt").Header.Caption = "Anterior"
            .Columns("InfonavitAct").Header.Caption = "Actual"
            .Columns("InfonavitDif").Header.Caption = "Diferencia"
            .Columns("ISRAnterior").Header.Caption = "Anterior"
            .Columns("ISRActual").Header.Caption = "Actual"
            .Columns("ISRDif").Header.Caption = "Diferencia"
            .Columns("TotalAnterior").Header.Caption = "Anterior"
            .Columns("TotalActual").Header.Caption = "Actual"
            .Columns("TotalDif").Header.Caption = "Diferencia"

            .Columns("CodigoEmp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NSS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NumCredito").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TipoDescuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ValorDescuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SBC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ImssAnterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ImssActual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ImssDif").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("InfonavitAnt").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("InfonavitAct").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("InfonavitDif").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ISRAnterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ISRActual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ISRDif").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TotalAnterior").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TotalActual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TotalDif").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ValorDescuento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("SBC").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ImssAnterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ImssActual").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ImssDif").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("InfonavitAnt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("InfonavitAct").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("InfonavitDif").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ISRAnterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ISRActual").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ISRDif").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TotalAnterior").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TotalActual").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TotalDif").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


            .Columns("ValorDescuento").Format = "##,##0.00"
            .Columns("SBC").Format = "##,##0.00"
            .Columns("ImssAnterior").Format = "##,##0"
            .Columns("ImssActual").Format = "##,##0"
            .Columns("ImssDif").Format = "##,##0"
            .Columns("InfonavitAnt").Format = "##,##0"
            .Columns("InfonavitAct").Format = "##,##0"
            .Columns("InfonavitDif").Format = "##,##0"
            .Columns("ISRAnterior").Format = "##,##0"
            .Columns("ISRActual").Format = "##,##0"
            .Columns("ISRDif").Format = "##,##0"
            .Columns("TotalAnterior").Format = "##,##0"
            .Columns("TotalActual").Format = "##,##0"
            .Columns("TotalDif").Format = "##,##0" '"##,##0.00"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        Dim sumuno As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("ImssAnterior"))
        Dim sumSeptimo As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("ImssActual"))
        Dim sumComisiones As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("ImssDif"))
        Dim sumdos As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("InfonavitAnt"))
        Dim sumtres As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("InfonavitAct"))
        Dim sumspe As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("InfonavitDif"))
        Dim sumotrosPagos As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("ISRAnterior"))
        Dim sumtotp As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("ISRActual"))
        Dim sumisr As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("ISRDif"))
        Dim sumimssDetalle As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("TotalAnterior"))
        Dim sumAfore As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("TotalActual"))
        Dim suminofo As SummarySettings = grdListado.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdListado.DisplayLayout.Bands(0).Columns("TotalDif"))


        sumuno.DisplayFormat = "{0:#,##0}"
        sumuno.Appearance.TextHAlign = HAlign.Right
        sumSeptimo.DisplayFormat = "{0:#,##0}"
        sumSeptimo.Appearance.TextHAlign = HAlign.Right
        sumComisiones.DisplayFormat = "{0:#,##0}"
        sumComisiones.Appearance.TextHAlign = HAlign.Right
        sumdos.DisplayFormat = "{0:#,##0}"
        sumdos.Appearance.TextHAlign = HAlign.Right
        sumtres.DisplayFormat = "{0:#,##0}"
        sumtres.Appearance.TextHAlign = HAlign.Right
        sumspe.DisplayFormat = "{0:#,##0}"
        sumspe.Appearance.TextHAlign = HAlign.Right
        sumotrosPagos.DisplayFormat = "{0:#,##0}"
        sumotrosPagos.Appearance.TextHAlign = HAlign.Right
        sumtotp.DisplayFormat = "{0:#,##0}"
        sumtotp.Appearance.TextHAlign = HAlign.Right
        sumisr.DisplayFormat = "{0:#,##0}"
        sumisr.Appearance.TextHAlign = HAlign.Right

        sumimssDetalle.DisplayFormat = "{0:#,##0}"
        sumimssDetalle.Appearance.TextHAlign = HAlign.Right
        sumAfore.DisplayFormat = "{0:#,##0}"
        sumAfore.Appearance.TextHAlign = HAlign.Right

        suminofo.DisplayFormat = "{0:#,##0}"
        suminofo.Appearance.TextHAlign = HAlign.Right


        grdListado.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


        grdListado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListado.DisplayLayout.Override.RowSelectorWidth = 35
        grdListado.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdListado.DisplayLayout.Bands(0).Columns("CodigoEmp").Width = 65

        grdListado.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub EncabezadoGrid(ByVal grid As UltraGrid)
        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = grid.DisplayLayout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 2 To rootBand.Columns.Count - 1 Step 1

            If (n < 9) Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo

            Else
                If n >= 9 And n <= 11 Then
                    If n = 9 Then
                        Dim NombreColumna As String
                        NombreColumna = "IMSS"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("IMSS")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                ElseIf n >= 12 And n <= 14 Then
                    If n = 12 Then
                        Dim NombreColumna As String
                        NombreColumna = "INFONAVIT"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("INFONAVIT")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                ElseIf n >= 15 And n <= 17 Then
                    If n = 15 Then
                        Dim NombreColumna As String
                        NombreColumna = "ISR"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("ISR")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                ElseIf n >= 18 And n <= 20 Then
                    If n = 18 Then
                        Dim NombreColumna As String
                        NombreColumna = "TOTAL DESCUENTOS"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Total Descuentos")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If

                End If
            End If
        Next
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If cmbAnio.Items.Count > 1 And cmbAnio.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un año."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        Return True
    End Function

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeConf As New Tools.ConfirmarForm

        If validarFiltros() Then
            Dim objBU As New Negocios.RecalculosBU
            Dim patronId As Integer = cmbPatron.SelectedValue
            Dim anio As Integer = CInt(cmbAnio.Text)
            Dim mensaje As String = String.Empty

            If objBU.validaExisteRecalculo(patronId, anio) Then
                objMensajeConf.mensaje = "Se eliminará el recálculo anterior. ¿Desea continuar?."
            Else
                objMensajeConf.mensaje = "Se realizará el recálculo anual de descuentos. ¿Está seguro de continuar?."
            End If

            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor

                mensaje = objBU.recalcularDescuentos(patronId)

                If mensaje = "EXITO" Then
                    objMensajeExito.mensaje = "Se guardó correctamente el recálculo."
                    objMensajeExito.ShowDialog()
                Else
                    objMensajeError.mensaje = mensaje
                    objMensajeError.ShowDialog()
                End If

                cargarListado()
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Try
            Dim objMensajeCoinf As New Tools.ConfirmarForm
            Dim resultado As String = String.Empty

            If validarFiltros() AndAlso Not grdListado.DataSource Is Nothing Then
                objMensajeCoinf.mensaje = "¿Está seguro de autorizar el recálculo?. Este proceso no podrá revertirse."
                If objMensajeCoinf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor

                    Dim objBU As New Negocios.RecalculosBU
                    Dim patronId As Integer = cmbPatron.SelectedValue
                    Dim anio As Integer = CInt(cmbAnio.Text)

                    resultado = objBU.autorizarRealculo(patronId, anio)
                    If resultado = "EXITO" Then
                        Dim objMensajeExito As New Tools.ExitoForm
                        enviarcorreo()

                        objMensajeExito.mensaje = "Se ha autorizado correctamente el recálculo"
                        objMensajeExito.ShowDialog()

                        cargarListado()
                    Else
                        Dim objMensajeError As New Tools.ErroresForm
                        objMensajeError.mensaje = resultado
                        objMensajeError.ShowDialog()
                    End If

                    Me.Cursor = Cursors.Default
                End If

            End If

        Catch ex As Exception
            Dim objMensajeError As New Tools.ErroresForm
            objMensajeError.mensaje = "Ocurrió un error al intentar autorizar el recálculo."
            objMensajeError.ShowDialog()
        End Try

    End Sub

    Private Sub enviarcorreo()
        Dim nombreArchivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments.Trim + "\" + "RecálculoDescuentos.xlsx"

        Try
            My.Computer.FileSystem.DeleteFile(nombreArchivo)
        Catch ex As Exception
        End Try

        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        rdoReal.Checked = True

        gridExcelExporter.Export(grdListado, nombreArchivo)

        System.Threading.Thread.Sleep(3000)

        'enviar_correo(NaveID, "ENVIO_DEPOSITO_CUENTAS")               
        Dim archivoAdjunto = New System.Net.Mail.Attachment(nombreArchivo)


        Dim objBU As New Negocios.RecalculosBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = objBU.obtieneDestinosCorreo(cmbPatron.SelectedValue)

        If destinatarios <> "" Then

            Dim Email As String = ""
            Email += "<html>"
            Email &= "<head>"
            Email &= "<style type ='text/css'>" &
                    "body {display:block; margin:8px; background:#FFFFFF;}" &
                    "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                    "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                    "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                    "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                    "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                    "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                    ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                    ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                    ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                    "A:link {text-decoration:none; color:#FFFFFF;}" &
                    "A:visited {text-decoration:none; color:#FFFFFF;}" &
                    "A:active {text-decoration:none; color:#FFFFFF;}" &
                    "A:hover {text-decoration:none;color:#006699;} "
            Email &= "</style>"
            Email &= "</head>"
            Email &= "<body>"
            Email &= "<div id='wrapper'>" &
                    "<div id='header'>" &
                    "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Recálculo de Descuentos " & cmbAnio.Text &
                    "</div>" &
                    "<div id='leftcolumn'></div>" &
                    "<div id='rightcolumn'></div>"
            Email &= "<div id='content'>" &
                    "<p>Se ha autorizado el recálculo de descuentos " & cmbAnio.Text & ".</p>" &
                    "<p>Los nuevos descuentos que se anexan en el archivo adjunto se aplicarán a partir de la siguiente elaboración de nómina.</p>"
            Email &= "</div>"
            Email &= "<div id='footer'></div>"
            Email &= "</div>"
            Email &= "</body>"
            Email &= "</html>"

            correo.EnviarCorreoHtmlArchivoAdjunto(destinatarios, "say_contabilidad@grupoyuyin.com.mx", "Recálculo de Descuentos ", Email, archivoAdjunto)
        End If

        Try
            My.Computer.FileSystem.DeleteFile(nombreArchivo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If grdListado.Rows.Count > 0 Then
                imprimirReporte()
            Else
                Dim objMensajeAdv As New Tools.AdvertenciaForm
                objMensajeAdv.mensaje = "No hay información para imprimir."
                objMensajeAdv.ShowDialog()
            End If
        Catch ex As Exception
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Intente nuevamente."
            objMensaje.ShowDialog()
        End Try
    End Sub

    Private Sub imprimirReporte()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objBU As New Negocios.RecalculosBU
        Dim dtEmpresa As New DataTable
        Dim patron As String = String.Empty
        Dim nave As String = String.Empty

        Try
            dtEmpresa = objBU.datosEmpresa(cmbPatron.SelectedValue)

            If Not dtEmpresa Is Nothing AndAlso dtEmpresa.Rows.Count > 0 Then
                patron = dtEmpresa.Rows(0).Item("Patron")
                nave = dtEmpresa.Rows(0).Item("Nave")
            Else
                objMensajeAdv.mensaje = "No se pudo recuperar la información de la empresa."
                objMensajeAdv.ShowDialog()
                Exit Sub
            End If

            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim reporte As New StiReport
            EntidadReporte = objReporte.LeerReporteporClave("REPORTE_RECALCULO_DEDUCCIONES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre.Trim & ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()

            Dim dtListado = New DataTable("dtRecalculoDescuentos")
            With dtListado
                .Columns.Add("CodigoEmp")
                .Columns.Add("Colaborador")
                .Columns.Add("NSS")
                .Columns.Add("NumCredito")
                .Columns.Add("TipoDescuento")
                .Columns.Add("ValorDescuento")
                .Columns.Add("SBC")
                .Columns.Add("ImssAnterior")
                .Columns.Add("ImssActual")
                .Columns.Add("ImssDif")
                .Columns.Add("InfonavitAnt")
                .Columns.Add("InfonavitAct")
                .Columns.Add("InfonavitDif")
                .Columns.Add("ISRAnterior")
                .Columns.Add("ISRActual")
                .Columns.Add("ISRDif")
                .Columns.Add("TotalAnterior")
                .Columns.Add("TotalActual")
                .Columns.Add("TotalDif")
            End With

            For Each item As UltraGridRow In grdListado.Rows
                dtListado.Rows.Add(
                    item.Cells("CodigoEmp").Value.ToString(),
                    item.Cells("Colaborador").Value.ToString(),
                    item.Cells("NSS").Value.ToString(),
                    item.Cells("NumCredito").Value.ToString(),
                    item.Cells("TipoDescuento").Value.ToString(),
                    CDbl(item.Cells("ValorDescuento").Value.ToString()),
                    CDbl(item.Cells("SBC").Value.ToString()),
                    CDbl(item.Cells("ImssAnterior").Value.ToString()),
                    CDbl(item.Cells("ImssActual").Value.ToString()),
                    CDbl(item.Cells("ImssDif").Value.ToString()),
                    CDbl(item.Cells("InfonavitAnt").Value.ToString()),
                    CDbl(item.Cells("InfonavitAct").Value.ToString()),
                    CDbl(item.Cells("InfonavitDif").Value.ToString()),
                    CDbl(item.Cells("ISRAnterior").Value.ToString()),
                    CDbl(item.Cells("ISRActual").Value.ToString()),
                    CDbl(item.Cells("ISRDif").Value.ToString()),
                    CDbl(item.Cells("TotalAnterior").Value.ToString()),
                    CDbl(item.Cells("TotalActual").Value.ToString()),
                    CDbl(item.Cells("TotalDif").Value.ToString())
                )
            Next

            reporte("Empresa") = patron
            reporte("Nave") = nave
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("Año") = CInt(cmbAnio.Text)

            reporte.RegData(dtListado)
            reporte.Show()
            'reporte.Render()
        Catch ex As Exception
            objMensajeError.mensaje = "Error al imprimir."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdListado.Rows.Count > 0 Then
            Try
                Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        If rdoFiscal.Checked Then
                            archivo = "Recálculo_Fiscal_" & cmbAnio.Text & "_" & fecha_hora & ".xlsx"
                        Else
                            archivo = "Recálculo_" & cmbAnio.Text & "_" & fecha_hora & ".xlsx"
                        End If

                        gridExcelExporter.Export(grdListado, .SelectedPath & "\" & archivo)

                        cargarListado()

                        objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                        objMensajeExito.ShowDialog()
                        Try
                            Process.Start(.SelectedPath & "\" & archivo)
                        Catch ex As Exception
                        End Try

                    End If
                    .Dispose()
                End With

            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            Finally
                cargarListado()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If

    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbPatron.SelectedIndex = 0
        grdListado.DataSource = Nothing
        configuracionPermisosBotones()
        lblSalarioMinimo.Text = "0"
        dtpFechaCalculo.Value = CDate("01/01/" & Now.Year.ToString)
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged

        Try
            If cmbAnio.Text.ToString <> "" And cmbAnio.Text.ToString <> "System.Data.DataRowView" Then
                dtpFechaCalculo.Value = CDate("01/01/" & cmbAnio.Text)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub rdoFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFiscal.CheckedChanged, rdoReal.CheckedChanged
        If cmbPatron.Items.Count > 1 Then
            cargarListado()
        End If
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaRecalculoDescuentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaRecalculoDescuentosToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_RecalculoDescuentos_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_RecalculoDescuentos_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RecalculoDescuentosArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecalculoDescuentosArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_RecalculoDescuentos_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_RecalculoDescuentos_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RecalculoDescuentosPropuestaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecalculoDescuentosPropuestaToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "Contabilidad_SAY_Recalculos_Oct2019_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\Contabilidad_SAY_Recalculos_Oct2019_V1.docx")
        Catch ex As Exception
        End Try
    End Sub
End Class