Imports System.Windows.Forms
Imports Framework.Negocios
Imports System.Drawing
Imports System.Net
Imports System.Xml
Imports System.IO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Shared
Imports Stimulsoft.Report
Imports ToolServicios
Imports Facturacion.Negocios


Public Class AdministradorTimbresForm
    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property

    Dim usuarioWS As String = String.Empty
    Dim contrasenaWS As String = String.Empty
    Dim identificadorWS As String = String.Empty
    Dim descargado As Boolean = False
    Dim colaboradorIds As String = String.Empty

    Dim pruebas As Boolean = False
    Dim local As Boolean = False
    Const claveDocumento As String = "RECIBODENOMINA"
    Dim rutas As Entidades.RutasDocumentosFacturacion

    Private rutaArchivos As String = String.Empty
    Private rutaArchivosCont As String = String.Empty
    Private rutaArchivosCont32 As String = "\\192.168.20.252\atenas-contabilidad\RecibosNominaFiscal\"
    'Const rutaArchivosPruebas As String = "\\192.168.7.16\f$\Pruebas\"
    'Const rutaArchivosContPruebas As String = "\\192.168.2.30\atenas\CONTABILIDAD\Contabilidad\Pruebas\"

    Private Sub AdministradorTimbresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        'If pruebas Then
        '    rutaArchivos = rutaArchivosPruebas
        '    rutaArchivosCont = rutaArchivosContPruebas
        'End If

        configuracionPermisosBotones()
        llenarComboEstatus()
        llenarComboEmpresa()
        If pPatronId <> 0 And cmbEmpresa.Items.Count > 0 Then
            cmbEmpresa.SelectedValue = pPatronId
            If pEstatusId <> 0 Then
                cmbEstatus.SelectedValue = pEstatusId
                cmbTimbrado.SelectedIndex = 1
                rdoRango.Checked = True
                dtpFechaFin.Value = Date.Now
            End If
            cargarListado()
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        'grbFiltros.Height = 43
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        'grbFiltros.Height = 108
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub configuracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("ADMON_REC_NOMINA_FISCAL", "DESCARGAR_RECNOM") Then
            pnlDescargarArchivos.Visible = True
        Else
            pnlDescargarArchivos.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("ADMON_REC_NOMINA_FISCAL", "TIMBRAR_RECNOM") Then
            pnlTimbrar.Visible = True
        Else
            pnlTimbrar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("ADMON_REC_NOMINA_FISCAL", "GENERARPDF_RECNOM") Then
            pnlGenerarPDF.Visible = True
        Else
            pnlGenerarPDF.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("ADMON_REC_NOMINA_FISCAL", "CANCELAR_RECNOM") Then
            pnlCancelar.Visible = True
        Else
            pnlCancelar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("ADMON_REC_NOMINA_FISCAL", "EXPORTAR_RECNOM") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("ADMON_REC_NOMINA_FISCAL", "IMPRIMIR_RECNOM") Then
            pnlImprimir.Visible = True
        Else
            pnlImprimir.Visible = False
        End If
    End Sub

    Private Sub llenarComboEstatus()
        Dim objBU As New Negocios.ReciboNominaBU
        Dim dtEstatus As New DataTable

        dtEstatus = objBU.obtenerEstatusRecibosNomina()
        If Not dtEstatus Is Nothing Then
            If dtEstatus.Rows.Count > 0 Then
                cmbEstatus.DataSource = dtEstatus
                cmbEstatus.ValueMember = "esta_estatusid"
                cmbEstatus.DisplayMember = "esta_nombre"
            Else
                cmbEstatus.DataSource = Nothing
            End If
        Else
            cmbEstatus.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresa()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        grdRecibos.DataSource = Nothing
        colaboradorIds = String.Empty
        pnlArchivoCargado.Visible = False

        llenarComboPeriodo()
    End Sub

    Private Sub llenarComboPeriodo()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            cmbPeriodo.DataSource = Nothing
            If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue) Then
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim dtListado As New DataTable

                dtListado = objBU.consultarPeriodoNomina(CInt(cmbEmpresa.SelectedValue.ToString))
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        cmbPeriodo.DataSource = dtListado
                        cmbPeriodo.ValueMember = "ID"
                        cmbPeriodo.DisplayMember = "DESCRIPCION"

                        If dtListado.Rows.Count > 1 Then
                            Dim dtRow As DataRow = dtListado.NewRow
                            dtRow("ID") = 0
                            dtRow("DESCRIPCION") = ""
                            dtListado.Rows.InsertAt(dtRow, 0)
                        End If

                        If rdoRango.Checked Then
                            cmbPeriodo.SelectedIndex = 0
                        End If
                    Else
                        objMensajeAdv.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                        objMensajeAdv.ShowDialog()
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblBuscar.Click
        cargarListado()
    End Sub

    Private Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        grdRecibos.DataSource = Nothing
        lblRecibos.Text = "0"
        lblTimbrados.Text = "0"
        lblNoTimbrados.Text = "0"
        lblTotal.Text = "0"
        Try
            If validarFiltros() Then
                Dim objBU As New Negocios.ReciboNominaBU
                Dim dtListado As New DataTable
                Dim dtTotales As New DataTable
                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim estatusId As Integer = cmbEstatus.SelectedValue
                Dim filtroTimbrado As Boolean = False
                Dim timbrado As Boolean = False
                Dim periodoId As Integer = cmbPeriodo.SelectedValue
                Dim rango As Boolean = rdoRango.Checked
                Dim fechaInicio As Date = dtpFechaInicio.Value.ToShortDateString
                Dim fechaFin As Date = dtpFechaFin.Value.ToShortDateString
                Dim tipo As String = cmbTipo.Text
                Dim objUtileriasBU As New UtileriasFacturasBU

                Select Case cmbTimbrado.SelectedIndex
                    Case 0
                        filtroTimbrado = False
                        timbrado = False
                    Case 1
                        filtroTimbrado = True
                        timbrado = False
                    Case 2
                        filtroTimbrado = True
                        timbrado = True
                End Select

                If tipo = "AGUINALDO Y VACACIONES" Then
                    tipo = "AGUINALDO_VACACIONES"
                End If

                dtListado = objBU.consultarListaRecibosNomina(patronId, estatusId, filtroTimbrado, timbrado, periodoId, rango, fechaInicio, fechaFin, tipo, colaboradorIds)
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        rutas = objUtileriasBU.ObtenerDirectoriosNomina(obtenerEmpresaId(patronId), 3, "AMBOS")
                        rutaArchivosCont = rutas.RutaContabilidad

                        grdRecibos.DataSource = dtListado
                        disenioGrid()

                        dtTotales = objBU.consultarRecibosTimbrados(patronId, estatusId, filtroTimbrado, timbrado, periodoId, rango, fechaInicio, fechaFin, tipo, colaboradorIds)
                        If Not dtTotales Is Nothing Then
                            If dtTotales.Rows.Count > 0 Then
                                lblRecibos.Text = dtTotales.Rows(0)("Recibos").ToString
                                lblTimbrados.Text = dtTotales.Rows(0)("Timbrados").ToString
                                lblNoTimbrados.Text = dtTotales.Rows(0)("NoTimbrados").ToString
                            End If
                        End If
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
            objMensajeError.mensaje = "Error al cargar listado de recibos nómina."
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If rdoPeriodo.Checked Then
            If cmbPeriodo.Items.Count > 1 And cmbPeriodo.SelectedIndex = 0 Then
                objMensajeAdv.mensaje = "Favor de seleccionar un Periodo de Nómina."
                objMensajeAdv.ShowDialog()
                Return False
            End If
        ElseIf rdoRango.Checked Then
            Dim entFechaInicio As Integer = 0
            Dim entFechaFin As Integer = 0
            entFechaInicio = CInt(dtpFechaInicio.Value.ToString("yyyyMMdd"))
            entFechaFin = CInt(dtpFechaFin.Value.ToString("yyyyMMdd"))

            If entFechaFin < entFechaInicio Then
                objMensajeAdv.mensaje = "La fecha inicial no puede ser mayor a la fecha final del filtro por periodo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Private Sub grdRecibos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRecibos.InitializeLayout
        Me.grdRecibos.UseAppStyling = False
        Me.grdRecibos.DisplayLayout.Bands(0).Columns("XML").Style = UltraWinGrid.ColumnStyle.Button
        Me.grdRecibos.DisplayLayout.Bands(0).Columns("PDF").Style = UltraWinGrid.ColumnStyle.Button
        Me.grdRecibos.DisplayLayout.Override.CellButtonAppearance.Image = Global.Contabilidad.Vista.My.Resources.Abrir24
        Me.grdRecibos.DisplayLayout.Override.CellButtonAppearance.ImageHAlign = HAlign.Center
        Me.grdRecibos.DisplayLayout.Override.CellButtonAppearance.ImageVAlign = VAlign.Middle
        Me.grdRecibos.DisplayLayout.Bands(0).Columns("XML").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
        Me.grdRecibos.DisplayLayout.Bands(0).Columns("PDF").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always

        Me.grdRecibos.DisplayLayout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
        Me.grdRecibos.DisplayLayout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Right
        Me.grdRecibos.DisplayLayout.Override.HeaderCheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
    End Sub

    Public Sub disenioGrid()
        grdRecibos.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

        grdRecibos.DisplayLayout.UseFixedHeaders = True
        grdRecibos.DisplayLayout.Bands(0).Columns("Selección").Header.Fixed = True
        grdRecibos.DisplayLayout.Bands(0).Columns("#").Header.Fixed = True
        grdRecibos.DisplayLayout.Bands(0).Columns("XML").Header.Fixed = True
        grdRecibos.DisplayLayout.Bands(0).Columns("PDF").Header.Fixed = True
        grdRecibos.DisplayLayout.Bands(0).Columns("Clave Empleado").Header.Fixed = True
        grdRecibos.DisplayLayout.Bands(0).Columns("Colaborador").Header.Fixed = True
        grdRecibos.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        With grdRecibos.DisplayLayout.Bands(0)
            .ColHeaderLines = 2
            .Columns("timbreNominaId").Hidden = True
            .Columns("PatronId").Hidden = True
            .Columns("PeriodoNominaId").Hidden = True
            .Columns("Fecha Pago").Hidden = True
            .Columns("RutaXML").Hidden = True
            .Columns("RutaPDF").Hidden = True
            .Columns("EmpresaRFC").Hidden = True
            .Columns("VersionRecibo").Hidden = True

            .Columns("Selección").Header.VisiblePosition = 0
            .Columns("Selección").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clave Empleado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RFC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Folio Fiscal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Emisión").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Timbrado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Pago").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Estatus").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Estatus Recibo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tipo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Cancelación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Motivo Cancelación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Usuario Canceló").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("XML").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PDF").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Motivo sin Timbrar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RutaXML").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RutaPDF").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Fecha Pago").Format = "dd/MM/yyyy"
            .Columns("Fecha Pago").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date
            .Columns("Fecha Pago").FilterOperandStyle = FilterOperandStyle.UseColumnEditor
            .Columns("Fecha Emisión").Format = "dd/MM/yyyy"
            '.Columns("Fecha Timbrado").Format = "dd/MM/yyyy HH:mm:ss"
            .Columns("Fecha Timbrado").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
            .Columns("Fecha Timbrado").FilterOperandStyle = FilterOperandStyle.UseColumnEditor
            .Columns("Fecha Timbrado").Nullable = Nullable.Null
            .Columns("Fecha Timbrado").NullText = String.Empty
            '.Columns("Fecha Cancelacion").Format = "dd/MM/yyyy HH:mm:ss"
            .Columns("Fecha Cancelación").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
            .Columns("Fecha Cancelación").Nullable = Nullable.Null
            .Columns("Fecha Cancelación").NullText = String.Empty
            .Columns("Fecha Cancelación").FilterOperandStyle = FilterOperandStyle.UseColumnEditor
            .Columns("Total").Format = "$##,##0.00"

            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Selección").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("XML").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("PDF").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            'grdRecibos.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("#").Width = 30
            .Columns("Selección").Width = 30
            .Columns("Clave Empleado").Width = 60
            .Columns("Colaborador").Width = 300
            .Columns("RFC").Width = 100
            .Columns("Recibo").Width = 50
            .Columns("Folio Fiscal").Width = 200
            .Columns("Fecha Emisión").Width = 70
            .Columns("Fecha Timbrado").Width = 105
            .Columns("Fecha Pago").Width = 75
            .Columns("Total").Width = 65
            .Columns("Estatus").Width = 75
            .Columns("Tipo").Width = 100
            .Columns("Fecha Cancelación").Width = 105
            .Columns("Motivo Cancelación").Width = 200
            .Columns("Usuario Canceló").Width = 70
            .Columns("Motivo sin Timbrar").Width = 200
            .Columns("XML").Width = 25
            .Columns("PDF").Width = 25

            .Columns("Clave Empleado").CharacterCasing = CharacterCasing.Upper
            .Columns("Colaborador").CharacterCasing = CharacterCasing.Upper
            .Columns("RFC").CharacterCasing = CharacterCasing.Upper
            .Columns("Estatus").CharacterCasing = CharacterCasing.Upper
            .Columns("Tipo").CharacterCasing = CharacterCasing.Upper
            .Columns("Motivo Cancelación").CharacterCasing = CharacterCasing.Upper
            .Columns("Motivo sin Timbrar").CharacterCasing = CharacterCasing.Upper

            Dim clnSumTotal As UltraGridColumn = .Columns("Total")

            Dim SumTotal As SummarySettings = .Summaries.Add("Total", SummaryType.Sum, clnSumTotal)
            SumTotal.DisplayFormat = "${0:###,###,###,###0.00}"
            SumTotal.Appearance.TextHAlign = HAlign.Right

            .SummaryFooterCaption = "TOTAL"
        End With

        'grdRecibos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdRecibos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdRecibos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        lblTotal.Text = CDbl(grdRecibos.Rows.SummaryValues("Total").Value).ToString("C2")
        lblTotal.AutoSize = True

        formatoFila()
    End Sub

    Private Sub formatoFila()
        Try
            For Each row As UltraGridRow In grdRecibos.Rows
                Select Case row.Cells("Estatus Recibo").Value
                    Case "POR TIMBRAR"
                        row.Appearance.ForeColor = Color.DarkOrange
                    Case Else
                        row.Appearance.ForeColor = Color.Black
                End Select

                Select Case row.Cells("Estatus").Value
                    Case "CANCELADO"
                        row.Appearance.ForeColor = Color.Red
                End Select

                If row.Cells("Fecha Timbrado").Value = "" Then
                    row.Cells("Fecha Timbrado").Appearance.ForeColor = Color.Transparent
                End If

                If row.Cells("Fecha Cancelación").Value = "" Then
                    row.Cells("Fecha Cancelación").Appearance.ForeColor = Color.Transparent
                End If

                If row.Cells("RutaXML").Value <> "" Then
                    Dim archivo As String = String.Empty
                    If row.Cells("VersionRecibo").Value = "3.2" Then
                        archivo = rutaArchivosCont32 & "Version32\" & row.Cells("EmpresaRFC").Value & "\" & row.Cells("RutaXML").Value
                    Else
                        archivo = rutaArchivosCont & row.Cells("RutaXML").Value
                    End If

                    If Not existeArchivo(archivo) Then
                        row.Cells("XML").Activation = Activation.Disabled
                    End If
                Else
                    row.Cells("XML").Activation = Activation.Disabled
                End If

                If row.Cells("RutaPDF").Value <> "" Then
                    Dim archivo As String = String.Empty
                    If row.Cells("VersionRecibo").Value = "3.2" Then
                        archivo = rutaArchivosCont32 & "Version32\" & row.Cells("EmpresaRFC").Value & "\" & row.Cells("RutaPDF").Value
                    Else
                        archivo = rutaArchivosCont & row.Cells("RutaPDF").Value
                    End If

                    If Not existeArchivo(archivo) Then
                        row.Cells("PDF").Activation = Activation.Disabled
                    End If
                Else
                    row.Cells("PDF").Activation = Activation.Disabled
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, lblLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub limpiarFiltros()
        cmbEmpresa.SelectedIndex = 0
        cmbTipo.SelectedIndex = 0
        cmbEstatus.SelectedIndex = 0
        cmbTimbrado.SelectedIndex = 0

        grdRecibos.DataSource = Nothing
        lblRecibos.Text = "0"
        lblTimbrados.Text = "0"
        lblNoTimbrados.Text = "0"
        lblTotal.Text = "0"
    End Sub

    Private Function validarEstatus(ByVal opcAccion As Int16, ByVal idsCredito() As Integer) As Boolean
        Dim objBU As New Negocios.ReciboNominaBU
        Dim resultado As String = String.Empty

        For item As Integer = 0 To idsCredito.Length - 1
            resultado = objBU.validarEstatus(idsCredito(item), opcAccion)
            If resultado <> "CORRECTO" Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click, lblTimbrar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim idsRecibos(0) As Integer

        For Each row As UltraGridRow In grdRecibos.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsRecibos(contSeleccionadas)
                idsRecibos(contSeleccionadas) = row.Cells("timbreNominaId").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
            'ElseIf contSeleccionadas > 1 Then
            '    objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            '    objMensajeAdv.ShowDialog()
        Else
            If validarEstatus(2, idsRecibos) Then
                Dim objBU As New Negocios.ReciboNominaBU
                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim periodoId As Integer = cmbPeriodo.SelectedValue
                Dim rango As Boolean = rdoRango.Checked
                Dim fechaInicio As Date = dtpFechaInicio.Value.ToShortDateString
                Dim fechaFin As Date = dtpFechaFin.Value.ToShortDateString
                Dim tipo As String = cmbTipo.Text

                If objBU.validaDiferenciasTimbradoNomina(patronId, periodoId, rango, fechaInicio, fechaFin, tipo) Then
                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Advertencia, "Existen diferencias contra el reporte de Nómina Fiscal, favor de verificar la diferencia y comunicarse al área de sistemas.")
                Else
                    Dim objMensajeConf As New Tools.ConfirmarForm
                    objMensajeConf.mensaje = "¿Está seguro de timbrar los recibos seleccionados? Este proceso no se podrá revertir."
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim resultado As String = String.Empty
                        Dim contTimbradas As Integer = 0
                        Dim causas As String = String.Empty

                        For item As Integer = 0 To idsRecibos.Length - 1
                            resultado = generarRecibo(idsRecibos(item))

                            If resultado = "EXITO" Then
                                contTimbradas += 1
                            Else
                                causas &= resultado & vbCrLf
                            End If
                        Next
                        Me.Cursor = Cursors.Default

                        If contSeleccionadas = contTimbradas Then
                            objMensajeExito.mensaje = "Recibos timbrados correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contTimbradas = 0 Then
                            If causas <> "" Then
                                Dim objMensajeAdvg As New Tools.AdvertenciaFormGrande
                                objMensajeAdvg.mensaje = causas
                                objMensajeAdvg.ShowDialog()
                            Else
                                objMensajeError.mensaje = "Error no se pudieron timbrados los recibos seleccionados."
                                objMensajeError.ShowDialog()
                            End If
                        ElseIf contSeleccionadas > contTimbradas Then
                            objMensajeAdv.mensaje = "Algunos recibos seleccionadas no se pudieron timbrar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeAdv.ShowDialog()
                            cargarListado()
                        End If
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "Los recibos de nómina deben de estar en estatus POR TIMBRAR para realizar esta acción."
                objMensajeAdv.ShowDialog()
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Public Function descargarArchivo(ByVal archivo As String) As String
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = ""
            Dim nuevaRuta As String = ""
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)

            If archivo <> "" Then
                If Not existeCarpeta(rutaTmp) Then
                    crearCarpeta(rutaTmp)
                End If

                nuevaRuta = rutaTmp & IO.Path.GetFileName(archivo)
                If Not existeArchivo(nuevaRuta) Then
                    'archivo = archivo.ToUpper.Replace(objFTP.obtenerURL.ToUpper, "")
                    rutaArchivo = IO.Path.GetDirectoryName(archivo)
                    objFTP.DescargarArchivo(rutaArchivo, rutaTmp, IO.Path.GetFileName(archivo))
                End If
                descargado = True
            End If

            Return nuevaRuta
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function generarRecibo(ByVal reciboId As Integer) As String
        Dim resultado As String = String.Empty
        Dim objBU As New Negocios.ReciboNominaBU
        Dim timNominaFiscal As New Entidades.TimbreNominaFiscal
        Dim pathXml As String = String.Empty
        Dim pathPdf As String = String.Empty

        Try
            timNominaFiscal = objBU.consultarInformacionRecibo(reciboId)
            If Not timNominaFiscal Is Nothing Then
                Dim objUtileriasBU As New UtileriasFacturasBU
                Dim RutaCliente As String = String.Empty
                Dim RutaServidorSICY As String = String.Empty
                Dim RutaRest As String = String.Empty
                Dim rutaContabilidad As String = String.Empty

                rutas = objUtileriasBU.ObtenerDirectoriosNomina(obtenerEmpresaId(timNominaFiscal.TNFPatronId), 3, "AMBOS")
                rutaArchivos = rutas.RutaSICY
                rutaArchivosCont = rutas.RutaContabilidad

                If validarRecibo(reciboId) Then
                    Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
                    Dim Servidor As String = IIf(pruebas, ServidorRestPruebasPruebas, ServidorRest)
                    Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU

                    llamarServicio.url = Servidor & "ReciboNomina/Timbrado?timNominaFiscalID=" & reciboId.ToString & "&usuarioId=" & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & "&bPruebas=" & pruebas.ToString
                    llamarServicio.metodo = "GET"
                    Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

                    If Respuesta.respuesta = 1 Then
                        resultado = True
                        RutaRest = Respuesta.mensaje(0)
                        RutaServidorSICY = Respuesta.mensaje(1)
                        RutaCliente = Respuesta.mensaje(2)
                        rutaContabilidad = Respuesta.mensaje(3)
                        pathXml = Respuesta.mensaje(4)
                        pathPdf = Respuesta.mensaje(5)
                        objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente & pathXml) & "\")
                        objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY & pathXml) & "\")
                        objUtilerias.CrearDirectorio(Path.GetDirectoryName(rutaContabilidad & pathXml) & "\")
                        objUtilerias.CopiarArchivoSICY(RutaRest & pathXml, RutaServidorSICY & pathXml, RutaCliente & pathXml, local, rutaContabilidad & pathXml)
                        objUtilerias.CopiarArchivoSICY(RutaRest & pathPdf, RutaServidorSICY & pathPdf, RutaCliente & pathPdf, local, rutaContabilidad & pathPdf)
                        resultado = "EXITO"
                    Else
                        resultado = Respuesta.aviso & "(" & reciboId.ToString & ")"
                        Try
                            objBU.actualizarMotivoSinTimbrar(timNominaFiscal.TNFTimbreNominaFiscalId, resultado.ToUpper)
                        Catch ex As Exception
                        End Try
                    End If
                Else
                    resultado = "El recibo no se puede timbrar. Verificar si ya estaba previamente timbrado."
                End If
            End If
        Catch ex As Exception
            resultado = ex.Message
        End Try

        Return resultado
    End Function

    Private Function obtenerEmpresaId(ByVal patronId As Integer) As Integer
        Try
            Dim objBU As New Negocios.ReciboNominaBU
            Dim dtDatos As New DataTable

            If pruebas Then
                patronId = 0
            End If
            dtDatos = objBU.consultarDatosEmpresa(patronId)
            Return dtDatos.Rows(0)("EmpresaId")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function validarRecibo(ByVal reciboId As Integer) As Boolean
        Dim objBU As New Negocios.ReciboNominaBU
        Dim timNominaFiscal As New Entidades.TimbreNominaFiscal
        Dim resultado As Boolean = False
        Dim objUtileriasBU As New UtileriasFacturasBU

        Try
            timNominaFiscal = objBU.consultarInformacionRecibo(reciboId)
            If Not timNominaFiscal Is Nothing Then
                Try
                    objUtileriasBU.CrearDirectorio(Path.GetDirectoryName(rutas.RutaCliente & timNominaFiscal.TNFXml) & "\")
                    objUtileriasBU.CrearDirectorio(Path.GetDirectoryName(rutas.RutaSICY & timNominaFiscal.TNFXml) & "\")
                    objUtileriasBU.CopiarArchivoSICY(rutas.RutaServicioRest & timNominaFiscal.TNFXml, rutas.RutaSICY & timNominaFiscal.TNFXml, rutas.RutaCliente & timNominaFiscal.TNFXml, local)

                    If existeArchivo(rutaArchivos & timNominaFiscal.TNFXml) Then
                        Dim doc As New XmlDocument
                        Dim factura As XmlNode
                        Dim nodo As XmlNode
                        Dim timbre As XmlNode
                        Dim xmlmanager As System.Xml.XmlNamespaceManager
                        Dim VersionComplemento As String = String.Empty

                        Try
                            doc.Load(rutaArchivos & timNominaFiscal.TNFXml)
                            xmlmanager = New XmlNamespaceManager(doc.NameTable)
                            xmlmanager.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3")
                            xmlmanager.AddNamespace("tfd", "http://www.sat.gob.mx/timbrefiscaldigital")

                            factura = doc.SelectSingleNode("cfdi:Comprobante", xmlmanager)
                            nodo = factura.SelectSingleNode("cfdi:Complemento", xmlmanager)
                            timbre = nodo.FirstChild()

                            If Not timbre Is Nothing Then
                                Try
                                    If timbre.Attributes.GetNamedItem("UUID").Value <> "" Then
                                        timNominaFiscal.TNFCadenaOriginal = obtenerCadenaOriginal(timNominaFiscal)
                                        VersionComplemento = timbre.Attributes.GetNamedItem("Version").Value
                                        timNominaFiscal.TNFUuid = timbre.Attributes.GetNamedItem("UUID").Value
                                        timNominaFiscal.TNFFechaTimbrado = timbre.Attributes.GetNamedItem("FechaTimbrado").Value
                                        timNominaFiscal.TNFSelloSAT = timbre.Attributes.GetNamedItem("SelloSAT").Value
                                        timNominaFiscal.TNFNoCertificadoSAT = timbre.Attributes.GetNamedItem("NoCertificadoSAT").Value
                                        timNominaFiscal.TNFCadenaOriginalComplemento = "||" & VersionComplemento &
                                            "|" & timNominaFiscal.TNFUuid &
                                            "|" & timNominaFiscal.TNFFechaTimbrado &
                                            "|" & timNominaFiscal.TNFSello &
                                            "|" & timNominaFiscal.TNFNoCertificadoSAT & "||"

                                        If objBU.actualizarInformacionTimbrado(timNominaFiscal) = "EXITO" Then
                                            My.Computer.FileSystem.CopyFile(rutaArchivos & timNominaFiscal.TNFXml, rutaArchivosCont & timNominaFiscal.TNFXml, True)
                                        End If
                                    Else
                                        'El xml existe pero no esta timbrado
                                        resultado = True
                                    End If
                                Catch ex As Exception
                                    'El xml existe pero no esta timbrado
                                    resultado = True
                                End Try
                            Else
                                'El xml existe pero no esta timbrado
                                resultado = True
                            End If
                        Catch ex As Exception

                        End Try
                    Else
                        resultado = True
                    End If

                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception

        End Try

        Return resultado
    End Function

    Private Function obtenerCadenaOriginal(ByVal iNominaFiscal As Entidades.TimbreNominaFiscal) As String
        Dim objTimbradoBU = New Facturacion.Negocios.TimbradoBU(obtenerEmpresaId(iNominaFiscal.TNFPatronId), pruebas)
        Dim resultado As String = String.Empty
        Try
            resultado = objTimbradoBU.GenerarCadenaOriginal(rutaArchivos & iNominaFiscal.TNFXml, iNominaFiscal.TNFTimbreNominaFiscalId, claveDocumento)
        Catch ex As Exception

        End Try

        Return resultado
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, lblCancelar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim reciboId As Integer = 0

        For Each row As UltraGridRow In grdRecibos.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                reciboId = row.Cells("timbreNominaId").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsRecibos(0) As Integer
            idsRecibos(0) = reciboId
            If validarEstatus(4, idsRecibos) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de cancelar el recibo seleccionado? se generará un nuevo registro para timbrar. Este proceso no se podrá revertir."

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim formMotivo As New MotivoRechazoForm

                    If Not CheckForm(formMotivo) Then
                        formMotivo.ShowDialog()
                        If formMotivo.motivo <> "" Then
                            Me.Cursor = Cursors.WaitCursor
                            If cancelarRecibo(reciboId, formMotivo.motivo) Then
                                Me.Cursor = Cursors.Default
                                objMensajeExito.mensaje = "Recibo de nómina cancelado correctamente."
                                objMensajeExito.ShowDialog()
                                cargarListado()
                            End If
                            Me.Cursor = Cursors.Default
                        Else
                            objMensajeAdv.mensaje = "Debe ingresar motivo de la cancelación."
                            objMensajeAdv.ShowDialog()
                        End If
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "El recibo de nómina debe de estar en estatus ACTIVO y TIMBRADO para realizar esta acción."
                objMensajeAdv.ShowDialog()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function cancelarRecibo(ByVal reciboId As Integer, ByVal motivo As String) As Boolean
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim resultado As String = String.Empty
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Dim RutaRest As String = String.Empty
        Dim rutaContabilidad As String = String.Empty
        Dim pathXml As String = String.Empty
        Dim pathPdf As String = String.Empty
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = IIf(pruebas, ServidorRestPruebasPruebas, ServidorRest)

        llamarServicio.url = Servidor & "ReciboNomina/cancelarRecibo?timNominaFiscalID=" & reciboId.ToString & "&motivo='" & motivo.ToString & "'&usuarioCancelo=" & Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid & "&bPruebas=" & pruebas.ToString
        llamarServicio.metodo = "GET"
        Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

        If Respuesta.respuesta = 1 Then
            RutaRest = Respuesta.mensaje(0)
            RutaServidorSICY = Respuesta.mensaje(1)
            RutaCliente = Respuesta.mensaje(2)
            rutaContabilidad = Respuesta.mensaje(3)
            pathXml = Respuesta.mensaje(4)
            pathPdf = Respuesta.mensaje(5)

            objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente & pathXml))
            objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY & pathXml))
            objUtilerias.CrearDirectorio(Path.GetDirectoryName(rutaContabilidad & pathXml))
            objUtilerias.CopiarArchivoSICY(RutaRest & pathXml, RutaServidorSICY & pathXml, RutaCliente & pathXml, local, rutaContabilidad & pathXml)
            objUtilerias.CopiarArchivoSICY(RutaRest & pathPdf, RutaServidorSICY & pathPdf, RutaCliente & pathPdf, local, rutaContabilidad & pathPdf)

            If Not existeArchivo(RutaServidorSICY & pathXml) Then
                objMensajeAdv.mensaje = "Error al copiar los archivos"
                objMensajeAdv.ShowDialog()
            End If

            Return True
        Else
            objMensajeAdv.mensaje = Respuesta.aviso
            objMensajeAdv.ShowDialog()
            Return False
        End If
        Me.Cursor = Cursors.Default
    End Function

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function CancelarCFDI(ByVal timbreFiscal As Entidades.TimbreNominaFiscal) As String
        'Dim parameters As CancelarParameters = CancelarParameters.NewEntity()
        'Dim proveedor As Proveedor = proveedor.NewEntity()
        ''Objeto que contiene la información retornada por el PAC
        'Dim informacion As Cancelar.Informacion = informacion.NewEntity()

        'Dim objBU As New Negocios.ReciboNominaBU
        'Dim mensaje As String = String.Empty
        'Dim xmlCanc As String = String.Empty

        '' Se asigna los parámetros a usar durante el proceso
        'parameters.Usuario.Value = usuarioWS
        'parameters.Password.Value = contrasenaWS
        'parameters.Identificador.Value = identificadorWS
        'parameters.TestMode = True 'CAMBIAR_PRODUCTIVO
        'parameters.Informacion = informacion
        ''parameters.ConstanciaRetenciones = false

        'parameters.RfcEmisor.Value = timbreFiscal.TNFEmisorRfc
        '' Se agrega el UUID a cancelar; se pueden agregar tantos como sea necesario, solamente existen 2 restricciones
        ''   1. Todos los UUID deben ser del mismos RFC
        ''   2. El número máximo de UUIDs es de 500.
        'parameters.Uuid.Add(timbreFiscal.TNFUuid)

        ''Cancela el documento
        'Dim result As ProcessProviderResult = proveedor.CancelarCfdi(parameters)

        'If informacion.Folios.Count > 0 Then
        '    If (informacion.Folios(0).Status.Value = 201) OrElse (informacion.Folios(0).Status.Value = 202) Then
        '        timbreFiscal.TNFUuidCancelacion = informacion.Folios(0).Uuid.Value
        '        timbreFiscal.TNFFechaCancelacion = informacion.Folios(0).Fecha.Value

        '        xmlCanc = rutaArchivos & timbreFiscal.TNFXml
        '        xmlCanc = xmlCanc.Insert(xmlCanc.Length - 4, "_CANCELADO")
        '        timbreFiscal.TNFXmlCancelacion = timbreFiscal.TNFXml.Insert(timbreFiscal.TNFXml.Length - 4, "_CANCELADO")
        '        Try
        '            Dim strXML As String = String.Empty
        '            strXML = cadenaXMLCancelacion(informacion, timbreFiscal.TNFEmisorRfc, "")
        '            File.WriteAllText(xmlCanc, strXML)
        '            My.Computer.FileSystem.CopyFile(xmlCanc, timbreFiscal.TNFXml.Insert(timbreFiscal.TNFXml.Length - 4, "_CANCELADO"), True)
        '        Catch ex As Exception

        '        End Try

        '        Dim lstPercepciones As New List(Of Entidades.TimbrePercepcion)
        '        lstPercepciones = objBU.consultarInformacionTimbrarPercepciones(timbreFiscal.TNFTimbreNominaFiscalId)

        '        Dim lstDeducciones As New List(Of Entidades.TimbreDeduccion)
        '        lstDeducciones = objBU.consultarInformacionTimbrarDeducciones(timbreFiscal.TNFTimbreNominaFiscalId)

        '        Dim lstOtrosPagos As New List(Of Entidades.TimbreOtrosPagos)
        '        lstOtrosPagos = objBU.consultarInformacionTimbrarOtrosPagos(timbreFiscal.TNFTimbreNominaFiscalId)

        '        Dim lstIncapacidades As New List(Of Entidades.TimbreIncapacidad)
        '        lstIncapacidades = objBU.consultarInformacionTimbrarIncapacidades(timbreFiscal.TNFTimbreNominaFiscalId)

        '        Dim lstHorasExtras As New List(Of Entidades.TimbreHorasExtra)
        '        lstHorasExtras = objBU.consultarInformacionTimbrarHorasExtra(timbreFiscal.TNFTimbreNominaFiscalId)

        '        Dim pdfGenerado As String = generarPdf(timbreFiscal, lstPercepciones, lstDeducciones, lstOtrosPagos, lstIncapacidades, lstHorasExtras, "CANCELACION")
        '        If pdfGenerado = "Generado" Then
        '            timbreFiscal.TNFPdfCancelacion = timbreFiscal.TNFPdf.Insert(timbreFiscal.TNFPdf.Length - 4, "_CANCELADO")
        '        End If

        '        mensaje = objBU.actualizarCancelacionTimbrado(timbreFiscal)
        '    Else
        '        mensaje = informacion.Folios(0).Status.Value & " - " & informacion.Folios(0).Description.Value
        '    End If
        'Else
        '    mensaje = informacion.Error.Numero.Value.ToString() & " - " & informacion.Error.Descripcion.Value
        'End If

        'Return mensaje
    End Function

    Private Function cadenaXMLCancelacion(ByVal informacion As String, ByVal emisorRFC As String, ByVal signature As String) As String
        'Dim cadenaXML As String = String.Empty

        'cadenaXML &= "<Cancelacion xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" "
        'cadenaXML &= "xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" "
        'cadenaXML &= "xmlns=""http://cancelacfd.sat.gob.mx"" "
        'cadenaXML &= "RfcEmisor=""" & emisorRFC & """ Fecha=""" & informacion.Folios(0).Fecha.Value.ToString("yyyy-MM-ddThh:mm:ss") & """>" & vbCrLf
        'cadenaXML &= "<Folios>" & vbCrLf
        'cadenaXML &= "<UUID>" & informacion.Folios(0).Uuid.Value & "</UUID>" & vbCrLf
        'cadenaXML &= "<UUIDEstatus>" & informacion.Folios(0).Status.Value & "</UUIDEstatus>" & vbCrLf
        'cadenaXML &= "<UUIDdescripcion>" & informacion.Folios(0).Description.Value & "</UUIDdescripcion>" & vbCrLf
        'cadenaXML &= "<UUIDfecha>" & informacion.Folios(0).Fecha.Value.ToString("yyyy-MM-ddThh:mm:ss") & "</UUIDfecha>" & vbCrLf
        'cadenaXML &= "</Folios>" & vbCrLf
        'cadenaXML &= "<Signature> " & signature & " </Signature>"
        'cadenaXML &= "</Cancelacion>"

        'Return cadenaXML
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click, lblExportar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdRecibos.Rows.Count > 0 Then
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
                        grdRecibos.DisplayLayout.Bands(0).Columns("Selección").Hidden = True
                        grdRecibos.DisplayLayout.Bands(0).Columns("XML").Hidden = True
                        grdRecibos.DisplayLayout.Bands(0).Columns("PDF").Hidden = True

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        archivo = "ListadoRecibos_" & fecha_hora & ".xlsx"
                        gridExcelExporter.Export(grdRecibos, .SelectedPath & "\" & archivo)

                        grdRecibos.DisplayLayout.Bands(0).Columns("Selección").Hidden = False
                        grdRecibos.DisplayLayout.Bands(0).Columns("XML").Hidden = False
                        grdRecibos.DisplayLayout.Bands(0).Columns("PDF").Hidden = False
                    End If
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                    objMensajeExito.ShowDialog()
                    .Dispose()
                End With
            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click, lblImprimir.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm

        If grdRecibos.Rows.Count > 0 Then
            Try
                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim reporte As New StiReport
                EntidadReporte = objReporte.LeerReporteporClave("LISTADO_RECIBOS_NOMINAFISCAL")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                reporte.Load(archivo)
                reporte.Compile()

                Dim dtListado = New DataTable("dtRecibos")
                With dtListado
                    .Columns.Add("Num")
                    .Columns.Add("Colaborador")
                    .Columns.Add("RFC")
                    .Columns.Add("ClaveEmpleado")
                    .Columns.Add("FechaPago")
                    .Columns.Add("Total")
                    .Columns.Add("Fecha")
                    .Columns.Add("FolioFiscal")
                    .Columns.Add("FechaTimbrado")
                    .Columns.Add("Estatus")
                    .Columns.Add("FechaCancelacion")
                    .Columns.Add("MotivoCancelacion")
                    .Columns.Add("EstatusRecibo")
                End With

                For Each item As UltraGridRow In grdRecibos.Rows
                    dtListado.Rows.Add(
                        CInt(item.Cells("#").Value.ToString()),
                        item.Cells("Colaborador").Value.ToString(),
                        item.Cells("RFC").Value.ToString(),
                        item.Cells("Clave Empleado").Value.ToString(),
                        CDate(item.Cells("Fecha Pago").Value.ToString()),
                        CDbl(item.Cells("Total").Value.ToString()),
                        CDate(item.Cells("Fecha Emisión").Value.ToString()),
                        item.Cells("Folio Fiscal").Value.ToString(),
                        item.Cells("Fecha Timbrado").Value.ToString(),
                        item.Cells("Estatus").Value.ToString(),
                        item.Cells("Fecha Cancelación").Value.ToString(),
                        item.Cells("Motivo Cancelación").Value.ToString(),
                        item.Cells("Estatus Recibo").Value.ToString()
                    )
                Next

                'reporte("Logo") = credInfonavit.CILogoNave
                reporte("Empresa") = cmbEmpresa.Text
                reporte("Periodo") = cmbPeriodo.Text
                reporte("Reporte") = EntidadReporte.Pnombre.Trim & ".mrt"
                reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                reporte.RegData(dtListado)
                reporte.Show()
                'reporte.Render()
            Catch ex As Exception
                objMensajeError.mensaje = "Error al imprimir."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para imprimir."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub grdRecibos_ClickCellButton(sender As Object, e As CellEventArgs) Handles grdRecibos.ClickCellButton
        Dim archivo As String = String.Empty
        archivo = rutaArchivosCont & grdRecibos.Rows(e.Cell.Row.Index).Cells("Ruta" & e.Cell.Column.Key).Value

        If grdRecibos.Rows(e.Cell.Row.Index).Cells("VersionRecibo").Value = "3.2" Then
            archivo = rutaArchivosCont32 & "Version32\" & grdRecibos.Rows(e.Cell.Row.Index).Cells("EmpresaRFC").Value & "\" & grdRecibos.Rows(e.Cell.Row.Index).Cells("Ruta" & e.Cell.Column.Key).Value
        Else
            archivo = rutaArchivosCont & grdRecibos.Rows(e.Cell.Row.Index).Cells("Ruta" & e.Cell.Column.Key).Value
        End If

        If archivo <> "" And existeArchivo(archivo) Then
            Process.Start(archivo)
        End If
    End Sub

    Private Sub btnDescargarArchivos_Click(sender As Object, e As EventArgs) Handles btnDescargarArchivos.Click, lblDescargarArchivos.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim existenTodos As Boolean = True
        Dim archviosDescargar() As String
        Dim contItems As Integer = 0

        For Each row As UltraGridRow In grdRecibos.Rows
            If row.Cells("Selección").Value Then
                If row.Cells("XML").Activation = Activation.Disabled Then
                    existenTodos = False
                Else
                    ReDim Preserve archviosDescargar(contItems)
                    archviosDescargar(contItems) = row.Cells("RutaXML").Value
                    contItems += 1
                End If

                If row.Cells("PDF").Activation = Activation.Disabled Then
                    existenTodos = False
                Else
                    ReDim Preserve archviosDescargar(contItems)
                    archviosDescargar(contItems) = row.Cells("RutaPDF").Value
                    contItems += 1
                End If

                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        ElseIf archviosDescargar Is Nothing Then
            objMensajeAdv.mensaje = "Ningún registro seleccionado contiene archivo para descargar."
            objMensajeAdv.ShowDialog()
        Else
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim archivo As String = String.Empty

            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                If ret = Windows.Forms.DialogResult.OK Then
                    Try
                        Dim consecutivo As Integer = 1
                        For item As Integer = 0 To archviosDescargar.Length - 1
                            My.Computer.FileSystem.CopyFile(rutaArchivosCont & "\" & archviosDescargar(item), .SelectedPath & "\" & IO.Path.GetFileNameWithoutExtension(archviosDescargar(item)) & "_" & consecutivo & IO.Path.GetExtension(archviosDescargar(item)), True)

                            If item Mod 2 <> 0 Then
                                consecutivo = consecutivo + 1
                            End If
                        Next
                    Catch ex As Exception

                    End Try
                End If
                If existenTodos Then
                    objMensajeExito.mensaje = "Los archivos se descargaron correctamente los archivos seleccionados."
                Else
                    objMensajeExito.mensaje = "No todos los registros seleccionado cuentan con archivo, se descargaron los existentes."
                End If
                objMensajeExito.ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub btnGenerarPDF_Click(sender As Object, e As EventArgs) Handles btnGenerarPDF.Click, lblGenerarPDF.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsRecibos() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdRecibos.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsRecibos(contSeleccionadas)
                idsRecibos(contSeleccionadas) = row.Cells("timbreNominaId").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(3, idsRecibos) Then
                Dim resultado As String = String.Empty
                Dim contGeneradas As Integer = 0
                Dim tipoRecibo As String = String.Empty

                Try
                    For item As Integer = 0 To idsRecibos.Length - 1
                        If generarPDF(idsRecibos(item), "") = "Generado" Then
                            contGeneradas += 1
                        End If
                    Next

                    If contSeleccionadas = contGeneradas Then
                        objMensajeExito.mensaje = "PDF's generados correctamente."
                        objMensajeExito.ShowDialog()
                        cargarListado()
                    ElseIf contGeneradas = 0 Then
                        objMensajeError.mensaje = "Error no se pudieron generar los PDF's de los registros seleccionados."
                        objMensajeError.ShowDialog()
                    ElseIf contSeleccionadas > contGeneradas Then
                        objMensajeError.mensaje = "Algunos PDF's no pudieron generarse, el listado se actualizará favor de intentarlo nuevamente."
                        objMensajeError.ShowDialog()
                        cargarListado()
                    End If
                Catch ex As Exception
                    objMensajeError.mensaje = "Error al generar PDF's."
                    objMensajeError.ShowDialog()
                End Try
            Else
                objMensajeAdv.mensaje = "Los recibos deben de estar en estatus ACTIVO o CANCELADO y en versión 3.3 para realizar esta acción."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        Me.Close()
    End Sub

    Private Sub rdoPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPeriodo.CheckedChanged
        dtpFechaInicio.Enabled = False
        dtpFechaFin.Enabled = False
        cmbPeriodo.Enabled = True
    End Sub

    Private Sub rdoRango_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRango.CheckedChanged
        dtpFechaInicio.Enabled = True
        dtpFechaFin.Enabled = True
        If cmbPeriodo.Items.Count > 0 Then
            cmbPeriodo.SelectedIndex = 0
        End If
        cmbPeriodo.Enabled = False
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbEmpresa.SelectedValue
                objForm.ShowDialog()
                colaboradorIds = String.Empty
                colaboradorIds = objForm.colaboradorIds

                If colaboradorIds <> "" Then
                    pnlArchivoCargado.Visible = True
                Else
                    pnlArchivoCargado.Visible = False
                End If
            End If
        End If
    End Sub

    Private Function generarPDF(ByVal timbreNominaId As Integer, ByVal opcion As String) As String
        Dim pdfGenerado As String = String.Empty
        Try
            Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
            Dim RutaCliente As String = String.Empty
            Dim RutaServidorSICY As String = String.Empty
            Dim RutaRest As String = String.Empty
            Dim rutaContabilidad As String = String.Empty
            Dim pathPdf As String = String.Empty
            Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
            Dim Servidor As String = IIf(pruebas, ServidorRestPruebasPruebas, ServidorRest)

            llamarServicio.url = Servidor & "ReciboNomina/generarPdfRA?timNominaFiscalID=" & timbreNominaId.ToString & "&opcion='" & opcion.ToString & "'&bPruebas=" & pruebas.ToString
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo

            If Respuesta.respuesta = 1 Then
                pdfGenerado = "Generado"

                RutaRest = Respuesta.mensaje(0)
                RutaServidorSICY = Respuesta.mensaje(1)
                RutaCliente = Respuesta.mensaje(2)
                rutaContabilidad = Respuesta.mensaje(3)
                pathPdf = Respuesta.mensaje(4)

                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaCliente & pathPdf) & "\")
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(RutaServidorSICY & pathPdf) & "\")
                objUtilerias.CrearDirectorio(Path.GetDirectoryName(rutaContabilidad & pathPdf) & "\")
                objUtilerias.CopiarArchivoSICY(RutaRest & pathPdf, RutaServidorSICY & pathPdf, RutaCliente & pathPdf, local, rutaContabilidad & pathPdf)
            Else
                pdfGenerado = Respuesta.aviso
            End If
        Catch ex As Exception
            pdfGenerado = "Error"
        End Try
        Return pdfGenerado
    End Function
End Class