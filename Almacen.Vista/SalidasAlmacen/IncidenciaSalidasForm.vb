Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class IncidenciaSalidasForm

    Private var_tipoConsulta As Integer
    Private var_idEmbarque As Integer
    Private var_cliente As String
    Private var_fechaEmbarque As String
    Private var_pares As Integer
    Private var_paresEmbarque As Integer
    Private var_paresEntregados As Integer
    Private var_paresFaltantes As Integer
    Private var_operador As Integer

    Sub New(ByVal tipoConsulta As Integer, ByVal idEmbarque As Integer, ByVal cliente As String, ByVal fechaEmbarque As String, ByVal pares As Integer, ByVal paresEmbarque As Integer, ByVal paresEntregados As Integer, ByVal paresFaltantes As Integer, ByVal operador As Integer)
        InitializeComponent()
        var_tipoConsulta = tipoConsulta ' 1 Generar Incidencias; 2 Consultar Incidencias
        var_idEmbarque = idEmbarque
        var_cliente = cliente
        var_fechaEmbarque = fechaEmbarque
        var_pares = pares
        var_paresEmbarque = paresEmbarque
        var_paresEntregados = paresEntregados
        var_paresFaltantes = paresFaltantes
        var_operador = operador
    End Sub

    Private Sub IncidenciaSalidasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Top = 0
        'Me.Left = 0
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim Tabla_ListadoParametros As New DataTable
        Dim tablaIncidencias As New DataTable
        Dim tblDatosEmbarque As New DataTable

        Cursor = Cursors.Default

        Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(2)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbOperadorReporta.DataSource = Tabla_ListadoParametros
        cmbOperadorReporta.DisplayMember = "Operador"
        cmbOperadorReporta.ValueMember = "ID"
        Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(4)
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbTipoIncidencia.DataSource = Tabla_ListadoParametros
        cmbTipoIncidencia.DisplayMember = "TipoIncidencia"
        cmbTipoIncidencia.ValueMember = "ID"

        txtParesEntregados.Text = "0"
        rdbNoOtraEntrega.Checked = True
        dtpFechaIncidencia.Value = Date.Now()
        txtObservaciones.Text = ""
        txtUbicacionMercancia.Text = ""

        If var_tipoConsulta = 2 Then
            dtpFechaIncidencia.Enabled = False
            rdbNoOtraEntrega.Enabled = False
            rdbSiOtraEntrega.Enabled = False
            chkFechaProximaEntrega.Enabled = False
            dtpFechaNuevaEntrega.Enabled = False
            dtHoraNuevaEntrega.Enabled = False
            btnAceptar.Enabled = False
            lblAceptar.Enabled = False
            txtObservaciones.Enabled = False
            txtParesEntregados.Enabled = False
            txtUbicacionMercancia.Enabled = False
            cmbOperadorReporta.Enabled = False
            cmbTipoIncidencia.Enabled = False
        End If

        lblIdEmbarque.Text = ""
        lblCliente.Text = ""
        lblFechaEmbarque.Text = ""
        lblPares.Text = ""
        lblTotalParesEmbarque.Text = ""
        lblParesEntregadosEmbarque.Text = ""
        lblParesFaltantesEmbarque.Text = ""

        rdbNoOtraEntrega.Checked = True

        tblDatosEmbarque = objBU.seleccionarDatosEmbarque(var_idEmbarque, var_cliente)

        lblIdEmbarque.Text = var_idEmbarque
        lblCliente.Text = var_cliente
        lblFechaEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_fechaembarque").ToString()
        lblPares.Text = tblDatosEmbarque.Rows(0)("sade_totalParesEmbarcados").ToString()
        lblTotalParesEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_totalParesEmbarcados").ToString()
        lblParesEntregadosEmbarque.Text = tblDatosEmbarque.Rows(0)("sade_totalParesEntregados").ToString()
        lblParesFaltantesEmbarque.Text = Integer.Parse(lblTotalParesEmbarque.Text) - Integer.Parse(lblParesEntregadosEmbarque.Text)


        'lblIdEmbarque.Text = var_idEmbarque
        'lblCliente.Text = var_cliente
        'lblFechaEmbarque.Text = var_fechaEmbarque
        'lblPares.Text = var_pares
        'lblTotalParesEmbarque.Text = var_paresEmbarque
        'lblParesEntregadosEmbarque.Text = var_paresEntregados
        'lblParesFaltantesEmbarque.Text = var_paresFaltantes

        chkFechaProximaEntrega.Enabled = False

        dtpFechaNuevaEntrega.Enabled = False
        dtpFechaNuevaEntrega.Value = Now.Date
        dtHoraNuevaEntrega.Enabled = False
        dtHoraNuevaEntrega.Value = Now.Date

        tablaIncidencias = objBU.seleccionarIncidencias(Integer.Parse(lblIdEmbarque.Text), lblCliente.Text)
        grdIncidencias.DataSource = tablaIncidencias

        gridIncidenciasDiseño(grdIncidencias)

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlCampos.Height = 26
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlCampos.Height = 191
    End Sub

    Private Sub rdbSiOtraEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles rdbSiOtraEntrega.CheckedChanged
        If rdbSiOtraEntrega.Checked Then
            'dtpFechaNuevaEntrega.Enabled = True
            'dtHoraNuevaEntrega.Enabled = True
            chkFechaProximaEntrega.Enabled = True
            chkFechaProximaEntrega.Checked = True
        Else
            'dtpFechaNuevaEntrega.Enabled = False
            'dtHoraNuevaEntrega.Enabled = False
            chkFechaProximaEntrega.Enabled = False
            chkFechaProximaEntrega.Checked = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdIncidencias
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then
            nombreDocumento = "\Incidencias_Embarque" + lblIdEmbarque.Text + "_"

            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    Dim mensajeExito As New ExitoForm
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim confirmacion As New ConfirmarForm
        Dim objBU As New Negocios.SalidasAlmacenBU
        Cursor = Cursors.WaitCursor
        If cmbOperadorReporta.SelectedIndex > 0 And cmbTipoIncidencia.SelectedIndex > 0 And txtObservaciones.Text <> "" And txtUbicacionMercancia.Text <> "" And txtParesEntregados.Text <> "" Then
            If (Integer.Parse(txtParesEntregados.Text) + Integer.Parse(lblParesEntregadosEmbarque.Text)) <= Integer.Parse(lblPares.Text) Then
                confirmacion.mensaje = "¿Desea guardar la incidencia al embarque " + var_idEmbarque.ToString + " del cliente " + lblCliente.Text + " con " + txtParesEntregados.Text + " pares entregados?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.Default
                    grdIncidencias.DataSource = Nothing
                    Dim resultadoGeneracionIncidencia As New DataTable
                    Dim objGeneracionIncidencias As New Entidades.GeneracionIncidencia

                    objGeneracionIncidencias.PCliente = lblCliente.Text
                    objGeneracionIncidencias.PfechaIncidencia = dtpFechaIncidencia.Value.ToShortDateString()
                    objGeneracionIncidencias.PColaboradOroperadorId = cmbOperadorReporta.SelectedValue
                    objGeneracionIncidencias.PParesEntregados = Integer.Parse(txtParesEntregados.Text)
                    objGeneracionIncidencias.PTipoIncidenciaId = cmbTipoIncidencia.SelectedValue
                    objGeneracionIncidencias.PObservaciones = txtObservaciones.Text
                    objGeneracionIncidencias.PUbicacionMercancia = txtUbicacionMercancia.Text
                    objGeneracionIncidencias.PProximaEntrega = If(rdbNoOtraEntrega.Checked, 0, 1)
                    objGeneracionIncidencias.PFechaProximaEntrega = If(chkFechaProximaEntrega.Checked, dtpFechaNuevaEntrega.Value.ToShortDateString() + " " + Replace(Replace(dtHoraNuevaEntrega.Value.ToShortTimeString(), " a. m.", ":00"), " p. m.", ":00"), "")
                    objGeneracionIncidencias.PSalidaVentasEmbarqueId = var_idEmbarque
                    objGeneracionIncidencias.PUsuarioCreoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                    resultadoGeneracionIncidencia = objBU.generarIncidencia(objGeneracionIncidencias)

                    show_message(resultadoGeneracionIncidencia.Rows(0).Item("tipoResultado"), resultadoGeneracionIncidencia.Rows(0).Item("resultado"))

                    If rdbNoOtraEntrega.Checked Then
                        Dim pantallaParesNoRecibidos As New DevolucionInformativaSalidaAlmacenForm(var_idEmbarque, var_cliente, var_fechaEmbarque, var_pares, var_paresEmbarque, var_paresEntregados, 1)
                        pantallaParesNoRecibidos.MdiParent = Me.MdiParent
                        Cursor = Cursors.Default
                        pantallaParesNoRecibidos.Show()
                        Me.Close()
                    Else
                        IncidenciaSalidasForm_Load(sender, e)
                    End If
                    Cursor = Cursors.Default
                End If
                Cursor = Cursors.Default
            Else
                Cursor = Cursors.Default
                show_message("Advertencia", "Los pares entregados deben ser menor o igual a los pares embarcados")
            End If
        Else
            Cursor = Cursors.Default
            show_message("Advertencia", "Debe proporcionar los datos completos para registrar la incidencia")
        End If
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

    Private Sub chkFechaProximaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaProximaEntrega.CheckedChanged
        If chkFechaProximaEntrega.Checked Then
            dtpFechaNuevaEntrega.Enabled = True
            dtHoraNuevaEntrega.Enabled = True
        Else
            dtpFechaNuevaEntrega.Enabled = False
            dtHoraNuevaEntrega.Enabled = False
        End If
    End Sub

    Private Sub gridIncidenciasDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        Dim totalPares As Integer = 0
        Dim totalParesFaltantes As Integer = 0

        grid.DisplayLayout.Bands(0).Columns("svin_fechaincidencia").Header.Caption = "Incidencia"
        grid.DisplayLayout.Bands(0).Columns("svin_fechaincidencia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("operador").Header.Caption = "Operador"
        grid.DisplayLayout.Bands(0).Columns("operador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("svin_paresEntregados").Header.Caption = "PrsEntregados"
        grid.DisplayLayout.Bands(0).Columns("svin_paresEntregados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("svin_paresEntregados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("tipoIncidencia").Header.Caption = "Tipo"
        grid.DisplayLayout.Bands(0).Columns("tipoIncidencia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("svin_observaciones").Header.Caption = "Observaciones"
        grid.DisplayLayout.Bands(0).Columns("svin_observaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("svin_fechaproximaentrega").Header.Caption = "ProxEntrega"
        grid.DisplayLayout.Bands(0).Columns("svin_fechaproximaentrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("svin_fechaproximaentrega").Format = "dd/MM/yyyy HH:mm:ss"

        grid.DisplayLayout.Bands(0).Columns("svin_ubicacionmercancia").Header.Caption = "Ubicación"
        grid.DisplayLayout.Bands(0).Columns("svin_ubicacionmercancia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("svin_paresEntregados"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If

        For Each row As UltraGridRow In grid.Rows
            totalPares += row.Cells("svin_paresEntregados").Value
        Next

        If totalPares > 0 Then
            lblParesEntregadosEmbarque.Text = totalPares.ToString("#,##0")
            totalParesFaltantes = Integer.Parse(lblPares.Text) - totalPares
            lblParesFaltantesEmbarque.Text = totalParesFaltantes.ToString("#,##0")
        End If

    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        'asignaFormato_Columna(grid)

    End Sub

    Private Sub grdIncidencias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdIncidencias.InitializeLayout
        grid_diseño(grdIncidencias)
    End Sub
End Class