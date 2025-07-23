Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting
Imports Framework.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ConsultaMovtosInfonavitForm
    Dim colaboradorIds As String = String.Empty
    Dim montoDiferencia As Double = 0.0

    Private Sub ConsultaMovtosInfonavitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        txtAnio.Text = DateTime.Now.ToString("yyyy")
        cargarComboEmpresaPatron()
        cargarComboTipos()

        ReporteMovimientosInfonavitWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("REP_MOVCREDINF", "EDITAR_WORD")

    End Sub

    Private Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronEmpresaPorAnio(txtAnio.Text)
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

    Private Sub cargarComboTipos()
        Try
            cmbTiposMov.DataSource = Nothing
            Dim objBu As New Contabilidad.Negocios.CreditoInfonavitBU
            Dim dtTipos As New DataTable

            dtTipos = objBu.obtenerTiposMovimiento()

            If Not dtTipos Is Nothing AndAlso dtTipos.Rows.Count > 0 Then
                cmbTiposMov.DataSource = dtTipos
                cmbTiposMov.ValueMember = "IdMovimiento"
                cmbTiposMov.DisplayMember = "Descripcion"
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al cargar el combo Tipos.")
        End Try
    End Sub

    Private Sub txtAnio_TextChanged(sender As Object, e As EventArgs) Handles txtAnio.TextChanged
        cargarComboEmpresaPatron()
        cargarCombosPeriodos()
    End Sub

    Public Sub cargarCombosPeriodos()
        limpiarGrid()
        colaboradorIds = String.Empty
        pnlColCargados.Visible = False
        cmbPeriodoDel.DataSource = Nothing
        cmbPeriodoAl.DataSource = Nothing

        If cmbPatron.SelectedIndex > 0 And txtAnio.Text.Length = 4 Then
            Try
                If cmbPatron.SelectedValue > 0 Then
                    Dim objBu As New Contabilidad.Negocios.UtileriasBU
                    Dim dtPeriodosDel As New DataTable
                    Dim dtPeriodosAl As New DataTable

                    dtPeriodosDel = objBu.consultarPeriodosNominaxAnioBU(CInt(cmbPatron.SelectedValue.ToString), CInt(txtAnio.Text.ToString))
                    dtPeriodosAl = objBu.consultarPeriodosNominaxAnioAlBU(CInt(cmbPatron.SelectedValue.ToString), CInt(txtAnio.Text.ToString))

                    If Not dtPeriodosDel Is Nothing Then
                        If dtPeriodosDel.Rows.Count > 0 Then
                            cmbPeriodoDel.DataSource = dtPeriodosDel
                            cmbPeriodoDel.ValueMember = "ID"
                            cmbPeriodoDel.DisplayMember = "PERIODO"

                            cmbPeriodoAl.DataSource = dtPeriodosAl
                            cmbPeriodoAl.ValueMember = "ID"
                            cmbPeriodoAl.DisplayMember = "PERIODO"
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "No hay periodos de nómina para la empresa seleccionada.")
                        End If
                    End If

                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "No hay periodos de nómina para la empresa seleccionada.")
                End If

            Catch
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al cargar los periodos.")
            End Try
        End If

        Me.txtAnio.Select()
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón"
            objMensajeAdv.ShowDialog()
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbPatron.SelectedValue
                objForm.ShowDialog()
                colaboradorIds = String.Empty
                colaboradorIds = objForm.colaboradorIds

                If colaboradorIds <> "" Then
                    pnlColCargados.Visible = True
                Else
                    pnlColCargados.Visible = False
                End If
            End If
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub rdoAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles rdoAcumulado.CheckedChanged
        limpiarGrid()
    End Sub

    Private Sub rdoDetallado_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDetallado.CheckedChanged
        limpiarGrid()
    End Sub

    Private Sub limpiarGrid()
        vwDatos.Columns.Clear()
        vwDatos.Bands.Clear()
        grdDatos.DataSource = Nothing
        montoDiferencia = 0.0
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If validarFiltros() Then
            Try
                Me.Cursor = Cursors.WaitCursor
                limpiarGrid()
                Dim objBU As New Contabilidad.Negocios.CreditoInfonavitBU
                Dim dtDatos As New DataTable
                Dim patronId As Integer = 0
                Dim periododel As Integer = 0
                Dim periodoal As Integer = 0
                Dim anio As Integer = 0
                Dim tipomovimiento As Integer = 0

                patronId = CInt(cmbPatron.SelectedValue)
                periododel = CInt(cmbPeriodoDel.SelectedValue)
                periodoal = CInt(cmbPeriodoAl.SelectedValue)
                anio = CInt(txtAnio.Text)
                tipomovimiento = CInt(cmbTiposMov.SelectedValue)

                montoDiferencia = objBU.obtenerMontoDiferencia(patronId)

                If rdoAcumulado.Checked = True Then
                    dtDatos = objBU.obtenerAcumuladoMovtosInfonavit(patronId, periododel, periodoal, anio, colaboradorIds, tipomovimiento)
                ElseIf rdoDetallado.Checked = True Then
                    dtDatos = objBU.obtenerDetalleMovtosInfonavit(patronId, periododel, periodoal, anio, colaboradorIds)
                End If

                If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                    grdDatos.DataSource = dtDatos

                    If rdoAcumulado.Checked = True Then
                        grdDatos.RepositoryItems.Clear()
                        disenioGridAcumulado()
                        AgregarBotonPDF()
                    ElseIf rdoDetallado.Checked = True Then
                        disenioGridDetallado(patronId, periododel, periodoal, anio)
                        grdDatos.RepositoryItems.Clear()
                    End If

                    For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwDatos.Columns
                        Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                        If Col.FieldName <> ("PDF") Then
                            Col.OptionsColumn.AllowEdit = False
                        End If

                        If Col.ColumnType() = GetType(Double) Then
                            Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            Col.DisplayFormat.FormatString = "N2"

                            If IsNothing(vwDatos.Columns(Col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = Col.FieldName)) = True Then
                                vwDatos.Columns(Col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N2}")
                                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                                item.FieldName = Col.FieldName
                                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                item.DisplayFormat = "{0:N2}"
                                vwDatos.GroupSummary.Add(item)
                            End If

                        End If

                        If rdoDetallado.Checked = True Then
                            Col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


                        End If

                    Next

                    For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In vwDatos.Bands
                        gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        For Each childrenBand In gridband.Children
                            childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        Next
                    Next

                    vwDatos.IndicatorWidth = 40

                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron datos para mostrar.")
                End If

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al cargar los datos.")
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Function validarFiltros() As Boolean
        If txtAnio.Text.Trim = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de ingresar el año a consultar.")
            Return False
        End If

        If Not cmbPatron.SelectedIndex > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir el patrón a consultar.")
            Return False
        End If

        If Not cmbPeriodoDel.SelectedIndex >= 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir el periodo inicial a consultar.")
            Return False
        End If

        If Not cmbPeriodoAl.SelectedIndex >= 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir el periodo final a consultar.")
            Return False
        End If

        Return True
    End Function

    Private Sub AgregarBotonPDF()
        If vwDatos Is Nothing Then Exit Sub
        If vwDatos.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdDatos.RepositoryItems.Add(_RIButton)

        vwDatos.Columns("PDF").ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        vwDatos.Columns("PDF").UnboundType = DevExpress.Data.UnboundColumnType.Object
        vwDatos.Columns("PDF").ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Image = My.Resources._1373583708_101
        _RIButton.Buttons(0).Width = vwDatos.Columns("PDF").Width - (vwDatos.Columns("PDF").Width / 4)
        AddHandler _RIButton.ButtonClick, AddressOf ColumnaPDF_Click
    End Sub

    Private Sub ColumnaPDF_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        NumeroFilas = vwDatos.DataRowCount

        For index As Integer = 0 To NumeroFilas Step 1
            If vwDatos.IsRowSelected(vwDatos.GetVisibleRowHandle(index)) Then
                Dim idColaborador As Integer = 0
                Dim carpeta As String = String.Empty
                Dim archivo As String = String.Empty

                If Not IsDBNull(vwDatos.GetRowCellValue(index, "colaboradorid")) Then
                    idColaborador = vwDatos.GetRowCellValue(index, "colaboradorid")
                    If Not IsDBNull(vwDatos.GetRowCellValue(index, "carpeta")) Then
                        carpeta = vwDatos.GetRowCellValue(index, "carpeta")
                    End If

                    If IsDBNull(vwDatos.GetRowCellValue(index, "nombrearchivo")) Then
                        archivo = ""
                    Else
                        archivo = vwDatos.GetRowCellValue(index, "nombrearchivo")
                    End If
                End If

                Try
                    If carpeta.Length > 0 And archivo.Length > 0 Then
                        Dim objTransferencias As New Tools.TransferenciaFTP
                        objTransferencias.DescargarArchivo(carpeta, "Descargas\Acuses\Contabilidad", archivo)
                        Process.Start("Descargas\Acuses\Contabilidad\" + archivo)

                    End If
                Catch ex As Exception
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al intentar descargar al acuse.")
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        Next
    End Sub

    Private Sub disenioGridAcumulado()
        DiseñoGrid.DiseñoBaseGrid(vwDatos)
        Dim band1 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim band2 As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band1.Caption = ""
        band1.OptionsBand.AllowMove = False
        band2.Caption = ""
        band2.OptionsBand.AllowMove = False
        band1.Fixed = Columns.FixedStyle.Left

        vwDatos.OptionsView.AllowCellMerge = True

        vwDatos.Columns("colaboradorid").Visible = False
        vwDatos.Columns("creditoinfonavitid").Visible = False
        vwDatos.Columns("tipomovimentoid").Visible = False
        vwDatos.Columns("tipodescuentoid").Visible = False
        vwDatos.Columns("carpeta").Visible = False
        vwDatos.Columns("usuarioaplicoid").Visible = False
        vwDatos.Columns("fechaInicialConsulta").Visible = False
        vwDatos.Columns("fechaFinalConsulta").Visible = False
        vwDatos.Columns("tipofila").Visible = False
        vwDatos.Columns("nombrearchivo").Visible = False

        For Each vColumna As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwDatos.Columns
            Select Case vColumna.FieldName
                Case "tipofila"
                    vColumna.OwnerBand = band1
                Case "colaboradorid"
                    vColumna.OwnerBand = band1
                Case "clave"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Case "colaborador"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Case "nss"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Case "rfc"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
                Case "creditoinfonavitid"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                Case "tipomovimentoid"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                Case "tipomovimento"
                    vColumna.OwnerBand = band1
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
                Case Else
                    vColumna.OwnerBand = band2
                    vColumna.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End Select

            vColumna.OptionsColumn.AllowMove = False

        Next

        vwDatos.Bands.Add(band1)
        vwDatos.Bands.Add(band2)
        vwDatos.OptionsView.ShowFooter = False
        vwDatos.OptionsCustomization.AllowSort = False

        vwDatos.Columns.ColumnByFieldName("clave").Caption = "Código Empleado"
        vwDatos.Columns.ColumnByFieldName("colaborador").Caption = "Colaborador"
        vwDatos.Columns.ColumnByFieldName("nss").Caption = "NSS"
        vwDatos.Columns.ColumnByFieldName("rfc").Caption = "RFC"
        vwDatos.Columns.ColumnByFieldName("tipomovimento").Caption = "Tipo de Movimiento"
        vwDatos.Columns.ColumnByFieldName("fecharecepcion").Caption = "Fecha de Recepción"
        vwDatos.Columns.ColumnByFieldName("fechamovimiento").Caption = "Fecha de inicio de descuento"
        vwDatos.Columns.ColumnByFieldName("numerocredito").Caption = "Numero de Crédito"
        vwDatos.Columns.ColumnByFieldName("tipodescuento").Caption = "Tipo de Descuento"
        vwDatos.Columns.ColumnByFieldName("valordescuento").Caption = "Valor de Descuento"
        vwDatos.Columns.ColumnByFieldName("retencionsemanalfiscal").Caption = "Retención Semanal Fiscal"
        vwDatos.Columns.ColumnByFieldName("AjusteSem").Caption = "Ajuste Semanal Fiscal"
        vwDatos.Columns.ColumnByFieldName("descuentosemanal").Caption = "Descuento Semanal Infonavit"
        vwDatos.Columns.ColumnByFieldName("descuentoFiscal").Caption = "Descuento FISCAL en Nomina"
        vwDatos.Columns.ColumnByFieldName("descuentoReal").Caption = "Descuento REAL en Nomina"
        vwDatos.Columns.ColumnByFieldName("difFiscalvsReal").Caption = "Diferencia Nomina Fiscal contra Real"
        vwDatos.Columns.ColumnByFieldName("fechaaplicacion").Caption = "Fecha de aplicación"
        vwDatos.Columns.ColumnByFieldName("UsuarioAplico").Caption = "Usuario que Aplicó"

        vwDatos.Columns.ColumnByFieldName("clave").Width = 70

        If IsNothing(vwDatos.Columns.ColumnByFieldName("PDF")) = False Then
            vwDatos.Columns.ColumnByFieldName("PDF").Width = 30
            vwDatos.Columns.ColumnByFieldName("PDF").OptionsColumn.AllowEdit = True
        End If

    End Sub

    Private Sub disenioGridDetallado(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer)
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim dtSemanas As New DataTable
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        vwDatos.OptionsView.AllowCellMerge = False
        vwDatos.OptionsView.ShowFooter = True
        vwDatos.OptionsCustomization.AllowSort = True

        vwDatos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        vwDatos.OptionsSelection.EnableAppearanceFocusedCell = False
        vwDatos.OptionsSelection.MultiSelect = False

        DiseñoGrid.DiseñoBaseGrid(vwDatos)

        dtSemanas = objBU.obtenerSemanasReporteDetalle(patronId, periododel, periodoal, anio)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = ""
        band.OptionsBand.AllowMove = True
        band.Fixed = Columns.FixedStyle.Left

        vwDatos.Columns.Clear()
        vwDatos.Bands.Clear()

        vwDatos.Columns.AddField("colaboradorid")
        vwDatos.Columns.ColumnByFieldName("colaboradorid").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("colaboradorid").Visible = False

        vwDatos.Columns.AddField("clave")
        vwDatos.Columns.ColumnByFieldName("clave").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("clave").Visible = True
        vwDatos.Columns.ColumnByFieldName("clave").Caption = "Código Empleado"

        vwDatos.Columns.AddField("colaborador")
        vwDatos.Columns.ColumnByFieldName("colaborador").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("colaborador").Visible = True
        vwDatos.Columns.ColumnByFieldName("colaborador").Caption = "Colaborador"

        vwDatos.Columns.AddField("nss")
        vwDatos.Columns.ColumnByFieldName("nss").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("nss").Visible = True
        vwDatos.Columns.ColumnByFieldName("nss").Caption = "NSS"

        vwDatos.Columns.AddField("rfc")
        vwDatos.Columns.ColumnByFieldName("rfc").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("rfc").Visible = True
        vwDatos.Columns.ColumnByFieldName("rfc").Caption = "RFC"

        vwDatos.Columns.AddField("fechaalta")
        vwDatos.Columns.ColumnByFieldName("fechaalta").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("fechaalta").Visible = True
        vwDatos.Columns.ColumnByFieldName("fechaalta").Caption = "Fecha de Alta"

        vwDatos.Columns.AddField("fechabaja")
        vwDatos.Columns.ColumnByFieldName("fechabaja").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("fechabaja").Visible = True
        vwDatos.Columns.ColumnByFieldName("fechabaja").Caption = "Fecha de Baja"

        listBands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Gran Total"
        band.OptionsBand.AllowMove = True
        band.Fixed = Columns.FixedStyle.Left

        vwDatos.Columns.AddField("TotalFiscal")
        vwDatos.Columns.ColumnByFieldName("TotalFiscal").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("TotalFiscal").Visible = True
        vwDatos.Columns.ColumnByFieldName("TotalFiscal").Caption = "Total Fiscal"

        vwDatos.Columns.AddField("TotalReal")
        vwDatos.Columns.ColumnByFieldName("TotalReal").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("TotalReal").Visible = True
        vwDatos.Columns.ColumnByFieldName("TotalReal").Caption = "Total Real"

        vwDatos.Columns.AddField("TotalDiferencia")
        vwDatos.Columns.ColumnByFieldName("TotalDiferencia").OwnerBand = band
        vwDatos.Columns.ColumnByFieldName("TotalDiferencia").Visible = True
        vwDatos.Columns.ColumnByFieldName("TotalDiferencia").Caption = "Diferencia Nómina Fiscal contra Real"

        listBands.Add(band)

        For Each row As DataRow In dtSemanas.Rows
            band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            band.Caption = row.Item("descripcion").ToString()
            band.OptionsBand.AllowMove = True
            listBands.Add(band)

            vwDatos.Columns.AddField(row.Item("noSemana").ToString() + "Fiscal")
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Fiscal").OwnerBand = band
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Fiscal").Visible = True
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Fiscal").Caption = "Descuento FISCAL en Nómina"

            vwDatos.Columns.AddField(row.Item("noSemana").ToString() + "Real")
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Real").OwnerBand = band
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Real").Visible = True
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Real").Caption = "Descuento REAL en Nómina"

            vwDatos.Columns.AddField(row.Item("noSemana").ToString() + "Dif")
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Dif").OwnerBand = band
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Dif").Visible = True
            vwDatos.Columns.ColumnByFieldName(row.Item("noSemana").ToString() + "Dif").Caption = "Diferencia Nómina Fiscal contra Real"
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In vwDatos.Columns
            Select Case Col.FieldName
                Case "clave"
                    Col.Width = 70
                Case "colaborador"
                    Col.Width = 250
                Case "nss"
                    Col.Width = 80
                Case "rfc"
                    Col.Width = 100
                Case "fechaalta"
                    Col.Width = 80
                Case "fechabaja"
                    Col.Width = 80
                Case Else
                    If Col.Caption.Contains("Total") Then
                        Col.Width = 80
                    Else
                        Col.Width = 130
                    End If
            End Select
            Col.OptionsColumn.AllowMove = True
        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            vwDatos.Bands.Add(gridBand)
        Next

        vwDatos.Appearance.FocusedRow.BackColor = Color.FromName("MenuHighlight")
        vwDatos.Appearance.FocusedRow.ForeColor = Color.White
        vwDatos.Appearance.EvenRow.BackColor = Color.White
        vwDatos.Appearance.OddRow.BackColor = Color.FromName("GradientActiveCaption")
        vwDatos.OptionsView.EnableAppearanceEvenRow = True
        vwDatos.OptionsView.EnableAppearanceOddRow = True
    End Sub

    Private Sub vwDatos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwDatos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwDatos_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles vwDatos.FocusedRowChanged
        vwDatos.LayoutChanged()
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        cargarCombosPeriodos()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarGrid()
        cmbPatron.SelectedIndex = 0
        cmbTiposMov.SelectedIndex = 0
        colaboradorIds = String.Empty
        pnlColCargados.Visible = False
        txtAnio.Text = DateTime.Now.ToString("yyyy")
        rdoAcumulado.Checked = True
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

    Private Sub AyudaReporteMovimientosInfonavitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaReporteMovimientosInfonavitToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_CreditoInfonavit_Reporte_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_CreditoInfonavit_Reporte_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ReporteMovimientosInfonavitWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteMovimientosInfonavitWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_CreditoInfonavit_Reporte_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_CreditoInfonavit_Reporte_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If rdoDetallado.Checked = True Then
            exportarExcel()
        Else
            imprimirReporteAcumulado()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub imprimirReporteAcumulado()
        If vwDatos.RowCount > 0 Then
            Dim dsReporteInfonavit As New DataSet("dsReporteInfonavit")
            Dim dtAcumulado As New DataTable
            Dim dtEncabezado As New DataTable
            Dim objBUInf As New Negocios.CreditoInfonavitBU
            Dim strFechas As String = String.Empty

            Try
                Me.Cursor = Cursors.WaitCursor
                Dim patronId As Integer
                Dim periododel As Integer
                Dim periodoal As Integer
                Dim empresa As String = String.Empty
                Dim periodoIni As String = String.Empty
                Dim periodoFin As String = String.Empty

                patronId = CInt(cmbPatron.SelectedValue)
                periododel = CInt(cmbPeriodoDel.SelectedValue)
                periodoal = CInt(cmbPeriodoAl.SelectedValue)

                dtEncabezado = objBUInf.obtenerEncabezadoRepAcumulado(patronId, periododel, periodoal)
                If Not dtEncabezado Is Nothing AndAlso dtEncabezado.Rows.Count > 0 Then
                    empresa = dtEncabezado.Rows(0)("patron").ToString
                    periodoIni = dtEncabezado.Rows(0)("periodode").ToString
                    periodoFin = dtEncabezado.Rows(0)("periodoa").ToString
                End If

                Dim vw = New DataView()
                vw = vwDatos.DataSource

                dtAcumulado = vw.ToTable()
                dtAcumulado.TableName = "dtAcumulado"

                For index As Integer = dtAcumulado.Rows.Count - 1 To 0 Step -1
                    If dtAcumulado.Rows(index).Item("tipofila").ToString.Trim <> "" Then
                        dtAcumulado.Rows.RemoveAt(index)
                    End If
                Next

                dsReporteInfonavit.Tables.Add(dtAcumulado)

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("REP_ACUMULADO_INFONAVIT")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte("Empresa") = empresa.ToUpper
                reporte("SemanaInicio") = periodoIni.ToUpper
                reporte("SemanaFin") = periodoFin.ToUpper
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.RegData(dsReporteInfonavit)
                reporte.Render()
                reporte.Show()

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Public Sub exportarExcel()
        If vwDatos.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty

            Try
                If rdoAcumulado.Checked = True Then
                    nombreReporte = "\Reporte_Acumulado_Infonavit_"
                Else
                    nombreReporte = "\Reporte_Detallado_Infonavit_"
                End If


                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If vwDatos.GroupCount > 0 Then
                            vwDatos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            If rdoDetallado.Checked = True Then
                                vwDatos.OptionsPrint.AutoWidth = False
                                vwDatos.OptionsPrint.UsePrintStyles = False
                                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG

                                vwDatos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                            Else
                                vwDatos.OptionsPrint.AutoWidth = True
                                vwDatos.OptionsPrint.UsePrintStyles = True
                                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.DataAware

                                Dim exportOptions = New XlsxExportOptionsEx()
                                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                                grdDatos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            End If
                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try
            If vwDatos.GetRowCellValue(e.RowHandle, "tipofila") = "SUBTOTAL" Then
                e.Formatting.BackColor = Color.FromArgb(189, 215, 238)
                e.Formatting.Font.Bold = True
            End If

            If vwDatos.GetRowCellValue(e.RowHandle, "tipofila") = "TOTAL" Then
                e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                e.Formatting.Font.Bold = True
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " + ex.Message)
        End Try

        e.Handled = True
    End Sub

    Private Sub vwDatos_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles vwDatos.CustomDrawCell
        If rdoAcumulado.Checked = True Then
            Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
            Try
                If currentView.GetRowCellValue(e.RowHandle, "tipofila") = "SUBTOTAL" Then

                    e.Appearance.BackColor = Color.FromArgb(189, 215, 238)
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)

                ElseIf currentView.GetRowCellValue(e.RowHandle, "tipofila") = "TOTAL" Then
                    e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)

                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió el siguiente error: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub vwDatos_RowCellStyle(sender As Object, e As Views.Grid.RowCellStyleEventArgs) Handles vwDatos.RowCellStyle
        If rdoDetallado.Checked = True Then
            If e.Column.FieldName.Contains("Dif") And Not e.Column.FieldName.Contains("Total") Then
                Dim valor As Decimal = 0.0
                If Not IsDBNull(vwDatos.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    valor = CDbl(vwDatos.GetRowCellValue(e.RowHandle, e.Column.FieldName))
                End If
                If montoDiferencia > 0 AndAlso valor > montoDiferencia Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
        Else
            Try
                Dim view As Views.BandedGrid.BandedGridView = CType(sender, Views.BandedGrid.BandedGridView)
                Dim viewInfo As GridViewInfo = CType(view.GetViewInfo(), GridViewInfo)

                If e.RowHandle = view.FocusedRowHandle Then
                    e.Appearance.Assign(viewInfo.PaintAppearance.FocusedRow)
                End If

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub vwDatos_CustomRowCellEdit(sender As Object, e As Views.Grid.CustomRowCellEditEventArgs) Handles vwDatos.CustomRowCellEdit
        If rdoAcumulado.Checked Then
            If (e.Column.FieldName = "PDF") Then
                Dim rutapdf As String = String.Empty
                If Not IsDBNull(vwDatos.GetRowCellValue(e.RowHandle, "nombrearchivo")) Then
                    rutapdf = vwDatos.GetRowCellValue(e.RowHandle, "nombrearchivo")
                End If

                If vwDatos.GetRowCellValue(e.RowHandle, "tipofila") <> "" Or rutapdf = "" Then
                    Dim editor As New RepositoryItemButtonEdit
                    editor.Assign(e.RepositoryItem)
                    editor.Buttons(0).Visible = False
                    e.RepositoryItem = editor

                End If
            End If
        End If
    End Sub

    Private Sub vwDatos_CustomColumnDisplayText(sender As Object, e As Views.Base.CustomColumnDisplayTextEventArgs) Handles vwDatos.CustomColumnDisplayText
        If rdoAcumulado.Checked Then
            Dim view As ColumnView = TryCast(sender, ColumnView)
            If e.Column.FieldName = "valordescuento" AndAlso e.ListSourceRowIndex <> DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                If view.GetListSourceRowCellValue(e.ListSourceRowIndex, "tipofila") = "" Then
                    Dim ciMX As CultureInfo = New CultureInfo("es-MX")
                    Dim strTipoDescuento As String = view.GetListSourceRowCellValue(e.ListSourceRowIndex, "tipodescuento")
                    Dim valordescuento As Double = CDbl(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "valordescuento"))
                    Select Case strTipoDescuento.ToUpper.Trim
                        Case "CUOTA FIJA"
                            e.DisplayText = String.Format(ciMX, "{0:c}", valordescuento)
                            Exit Select
                        Case "VECES DE SM"
                            e.DisplayText = String.Format(CultureInfo.InvariantCulture, "{0:N4}", valordescuento)
                            Exit Select
                        Case "PORCENTAJE"
                            e.DisplayText = String.Format(CultureInfo.InvariantCulture, "{0:n2}", valordescuento)
                            Exit Select
                    End Select
                End If
            End If
        End If
    End Sub
End Class