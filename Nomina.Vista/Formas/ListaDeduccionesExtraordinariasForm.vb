Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports Tools

Public Class ListaDeduccionesExtraordinariasForm

    Private Sub ListaDeduccionesExtraordinariasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpFechaDel.Value = Now.ToShortDateString
        dtpFechaAl.Value = Now.ToShortDateString
        btnArriba.Visible = False
        btnAbajo.Visible = False
        Try
            WindowState = FormWindowState.Maximized
            'grdDeducciones.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'grdDeducciones.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        Try
            Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Try
            If cmbNave.SelectedIndex > 0 Then
                Dim listaDecucciones As New List(Of Entidades.Deducciones)
                Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU
                Dim res As New DataTable
                grdCtrolDeducciones.DataSource = DBNull.Value
                grdDeducciones.ClearColumnsFilter()

                If rdoPeriodoNomina.Checked Then
                    If cmbPeriodoNomina.SelectedIndex > 0 Then
                        Me.Cursor = Cursors.WaitCursor
                        res = deduccionesBU.lstDeduccionesFiltro(cmbNave.SelectedValue, cmbPeriodoNomina.SelectedValue, txtColaborador.Text, String.Empty, String.Empty, False)

                    Else
                        Dim objMensajeGuardar As New Tools.AdvertenciaForm
                        objMensajeGuardar.mensaje = "No se ha seleccionado ningún periodo de nómina."
                        objMensajeGuardar.ShowDialog()
                        grdDeducciones.ClearColumnsFilter()
                        grdDeducciones.OptionsView.ShowFooter = GroupFooterShowMode.Hidden
                        Exit Sub
                    End If

                ElseIf rdoFechas.Checked Then
                    Me.Cursor = Cursors.WaitCursor
                    res = deduccionesBU.lstDeduccionesFiltro(cmbNave.SelectedValue, 0, txtColaborador.Text, dtpFechaDel.Value.ToShortDateString, dtpFechaAl.Value.ToShortDateString, True)
                End If
                'listaDecucciones = deduccionesBU.ListaDeduccionFiltro(idNave, idSemanaNomina, colaborador)
                If res.Rows.Count > 0 Then
                    grdCtrolDeducciones.DataSource = res
                    estiloGridDeducciones()

                Else
                    Dim objMensajeGuardar As New Tools.AdvertenciaForm
                    objMensajeGuardar.mensaje = "No hay datos por mostrar."
                    objMensajeGuardar.ShowDialog()
                    grdCtrolDeducciones.DataSource = DBNull.Value
                    grdDeducciones.ClearColumnsFilter()
                    grdDeducciones.OptionsView.ShowFooter = GroupFooterShowMode.Hidden
                End If
                'For Each objeto As Entidades.Deducciones In listaDecucciones
                '    AgregarFilaDeduccionesCobradas(objeto)
                'Next
            Else
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "No se ha seleccionado ninguna nave."
                objMensajeGuardar.ShowDialog()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception

        End Try
    End Sub

    Public Sub estiloGridDeducciones()

        'Adecuar ancho del indicador de renglón en el grid
        grdDeducciones.IndicatorWidth = 40
        'acomoda las columnas del ancho automaticamente
        'grdDeducciones.OptionsView.ColumnAutoWidth = True
        'grdDeducciones.OptionsView.BestFitMaxRowCount = 1
        ' grdDeducciones.BestFitColumns()

        'Esconde idColumnas
        grdDeducciones.Columns("decx_fechacreacion").Visible = False
        'acomoda el nombre de la columna centrado
        grdDeducciones.Columns("decx_deduccionid").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("numero pagos").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("pnom_FechaFinal").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("Colaborador").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("grup_name").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("pues_nombre").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("decx_concepto").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("decx_monto").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("pagodecx_saldoanterior").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("pagodecx_abono").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("pagodecx_saldonuevo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdDeducciones.Columns("numero pagos").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

        'Para que haga la busqueda por lo que contiene decx_deduccionid
        grdDeducciones.Columns("decx_deduccionid").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("pnom_FechaFinal").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("numero pagos").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("Colaborador").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("grup_name").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("pues_nombre").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("decx_concepto").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("decx_monto").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("pagodecx_saldoanterior").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("pagodecx_abono").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdDeducciones.Columns("pagodecx_saldonuevo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'asigna nombre en la columna
        grdDeducciones.Columns("decx_deduccionid").Caption = "No. Deducción"
        grdDeducciones.Columns("numero pagos").Caption = "No. Pago"
        grdDeducciones.Columns("pnom_FechaFinal").Caption = "Fecha Cierre"
        grdDeducciones.Columns("grup_name").Caption = "Departamento"
        grdDeducciones.Columns("pues_nombre").Caption = "Puesto"
        grdDeducciones.Columns("decx_concepto").Caption = "Concepto"
        grdDeducciones.Columns("decx_monto").Caption = "Monto"
        grdDeducciones.Columns("pagodecx_saldoanterior").Caption = "Saldo"
        grdDeducciones.Columns("pagodecx_abono").Caption = "Abono"
        grdDeducciones.Columns("pagodecx_saldonuevo").Caption = "Saldo Nuevo"

        grdDeducciones.Columns("pagodecx_abono").Summary.Clear()
        ' Make the group footers always visible.
        grdDeducciones.OptionsView.ShowFooter = GroupFooterShowMode.Hidden

        grdDeducciones.Columns("pagodecx_abono").Summary.Clear()
        ' Make the group footers always visible.
        grdDeducciones.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
        ' se le da la función que va hacer en el footer (sumar lo que tengas las filas de esa columna)
        grdDeducciones.Columns("pagodecx_abono").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "pagodecx_abono", "{0:N2}")

        Dim itemAbono As GridGroupSummaryItem = New GridGroupSummaryItem()
        itemAbono.FieldName = "pagodecx_abono"
        itemAbono.SummaryType = DevExpress.Data.SummaryItemType.Count
        itemAbono.DisplayFormat = "Total: {0:N2}"

        If grdDeducciones.GroupSummary.Count > 0 Then
        Else
            grdDeducciones.GroupSummary.Add(itemAbono)
        End If

        'Define el formato en que4 se va a mostrar en la columna que se le indica
        Dim monto = grdDeducciones.Columns("decx_monto").DisplayFormat
        monto.FormatType = FormatType.Numeric
        monto.FormatString = "{0:N2}"
        Dim saldoAnterior = grdDeducciones.Columns("pagodecx_saldoanterior").DisplayFormat
        saldoAnterior.FormatType = FormatType.Numeric
        saldoAnterior.FormatString = "{0:N2}"
        Dim abono = grdDeducciones.Columns("pagodecx_abono").DisplayFormat
        abono.FormatType = FormatType.Numeric
        abono.FormatString = "{0:N2}"
        Dim saldoNuevo = grdDeducciones.Columns("pagodecx_saldonuevo").DisplayFormat
        saldoNuevo.FormatType = FormatType.Numeric
        saldoNuevo.FormatString = "{0:N2}"

        'Pone el color de fondo salteado de color blacno y azul
        For i As Integer = 1 To grdDeducciones.RowCount - 1
            If i Mod 2 = 0 Then
                'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
                grdDeducciones.Appearance.EvenRow.BackColor = Color.LightSteelBlue
                grdDeducciones.OptionsView.EnableAppearanceEvenRow = True
                grdDeducciones.Invalidate()
            End If
        Next
    End Sub

    Private Sub grdPreferentesSinFechaEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDeducciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub AgregarFilaDeduccionesCobradas(ByVal Deducciones As Entidades.Deducciones)

        'Dim celda As DataGridViewCell
        'Dim fila As New DataGridViewRow
        ''  Dim tablaReporte As New DataTable

        ' ''El numero de pago
        'celda = New DataGridViewTextBoxCell
        '' celda.Value = grdDeducciones.Rows.Count + 1
        'fila.Cells.Add(celda)

        ' ''El numero de pago
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PNumeroPago
        'fila.Cells.Add(celda)

        ' ''El nombre
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PColaborador.PNombre.ToUpper + " " + Deducciones.PColaborador.PApaterno.ToUpper + " " + Deducciones.PColaborador.PAmaterno.ToUpper
        'fila.Cells.Add(celda)

        ' ''El departamento
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PDepartamento
        'fila.Cells.Add(celda)

        ' ''El Puesto
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PPuesto
        'fila.Cells.Add(celda)

        ' ''El concepto
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PConceptoDeduccion
        'fila.Cells.Add(celda)

        ' ''Numero de semanas
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PnumeroSemanas
        'fila.Cells.Add(celda)

        ' ''El monto
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PMontoDeduccion
        'fila.Cells.Add(celda)

        ' ''El Saldo
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PSaldoAnterior
        'fila.Cells.Add(celda)


        ' ''El abono
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.Pabono
        'fila.Cells.Add(celda)

        ''Nuevo saldo
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PSaldo
        'fila.Cells.Add(celda)

        ' ''El ID del colaborador
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PColaborador.PColaboradorid
        'fila.Cells.Add(celda)

        ' ''El ID DEDUCCION
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PidDeduccion
        'fila.Cells.Add(celda)

        ' ''El ID DEDUCCION
        'celda = New DataGridViewTextBoxCell
        'celda.Value = Deducciones.PPagoID
        'fila.Cells.Add(celda)

        ' ''COBRADO
        'celda = New DataGridViewTextBoxCell
        'celda.Value = "C"
        'fila.Cells.Add(celda)


        'Me.grdDeducciones.AddNewRow(fila)
    End Sub

    Private Sub btnAlta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlta.Click
        Dim objAlta As New DeduccionesForm
        objAlta.Show()
        Me.Close()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim objeliminar As New EliminarDeduccionesForm
        objeliminar.MdiParent = Me.MdiParent
        objeliminar.Show()
        Me.Close()
    End Sub

    Private Sub btnCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCobro.Click
        Dim objCobro As New CobranzaDeduccionesExtraordinariasForm
        objCobro.MdiParent = Me.MdiParent
        objCobro.Show()
        Me.Close()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub


    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

        Dim vAdvertenciaForm As New AdvertenciaForm
        If cmbNave.Text = "" Then
            vAdvertenciaForm.Text = "Deducciones"
            vAdvertenciaForm.mensaje = "Debe Seleccionar una nave"
            vAdvertenciaForm.Show()
        Else
            If grdDeducciones.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Try
                    Me.Cursor = Cursors.Default
                    ImprimirReporte()
                Catch ex As Exception
                End Try
                Me.Cursor = Cursors.Default
            Else
                Dim objMensajeGuardar As New Tools.AdvertenciaForm
                objMensajeGuardar.mensaje = "No hay datos para imprirmir."
                objMensajeGuardar.ShowDialog()
            End If

        End If

    End Sub

    Public Sub ImprimirReporte()

        Try

            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As New Entidades.Reportes
            Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU
            Dim colaboradorDeduccion As New Entidades.Colaborador
            Dim Deducciones As New Entidades.Deducciones
            Dim dtColaboradoresDeducciones As New DataTable
            Dim arrReporte As New ArrayList
            Dim contador As Int16 = 1

            dtColaboradoresDeducciones.Columns.Add("#")
            dtColaboradoresDeducciones.Columns.Add("No. Pago")
            dtColaboradoresDeducciones.Columns.Add("Colaborador")
            dtColaboradoresDeducciones.Columns.Add("Departamento")
            dtColaboradoresDeducciones.Columns.Add("Puesto")
            dtColaboradoresDeducciones.Columns.Add("Concepto")
            dtColaboradoresDeducciones.Columns.Add("Monto")
            dtColaboradoresDeducciones.Columns.Add("Saldo")
            dtColaboradoresDeducciones.Columns.Add("Abono")
            dtColaboradoresDeducciones.Columns.Add("Saldo Nuevo")

            For I = 0 To grdDeducciones.RowCount() - 1
                arrReporte.Add(grdDeducciones.GetDataRow(I))
            Next

            'clientesPreferentesSinFechaEspecial
            For x = 0 To arrReporte.Count - 1
                Dim dRColaboradoresDeducciones As DataRow = dtColaboradoresDeducciones.NewRow
                Dim Row As DataRow = CType(arrReporte(x), DataRow)

                dRColaboradoresDeducciones.Item("#") = contador
                dRColaboradoresDeducciones.Item("No. Pago") = Row("numero pagos").ToString
                dRColaboradoresDeducciones.Item("Colaborador") = Row("Colaborador").ToString
                dRColaboradoresDeducciones.Item("Departamento") = Row("grup_name").ToString
                dRColaboradoresDeducciones.Item("Puesto") = Row("pues_nombre").ToString
                dRColaboradoresDeducciones.Item("Concepto") = Row("decx_concepto").ToString
                dRColaboradoresDeducciones.Item("Monto") = CInt(Row("decx_monto"))
                dRColaboradoresDeducciones.Item("Saldo") = Row("pagodecx_saldoanterior")
                dRColaboradoresDeducciones.Item("Abono") = Row("pagodecx_abono").ToString
                dRColaboradoresDeducciones.Item("Saldo Nuevo") = Row("pagodecx_saldonuevo")

                dtColaboradoresDeducciones.Rows.Add(dRColaboradoresDeducciones)
                contador += 1
            Next

            Dim periodoNomina As String = String.Empty
            If rdoPeriodoNomina.Checked = True Then
                periodoNomina = cmbPeriodoNomina.Text
            ElseIf rdoFechas.Checked = True Then
                periodoNomina = "Del " + dtpFechaDel.Value.ToShortDateString.ToString + " Al " + dtpFechaAl.Value.ToShortDateString.ToString
            End If

            'periodoNomina = cmbPeriodoNomina.Text
            EntidadReporte = OBJBU.LeerReporteporClave("REPORTE_DEDUCCIONES_EXTRA")

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                   EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()

            reporte.Dictionary.Clear()

            reporte("periodoNomina") = periodoNomina
            reporte("NombreReporte") = "REPORTE_DEDUCCIONES_EXTRA.mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte.RegData(dtColaboradoresDeducciones)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbPeriodoNomina_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbPeriodoNomina.SelectionChangeCommitted
        'If cmbPeriodoNomina.SelectedIndex > 0 Then
        '    grpFechas.Visible = False
        'Else
        '    grpFechas.Visible = True
        'End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCtrolDeducciones.DataSource = DBNull.Value
        dtpFechaDel.Value = Now.ToShortDateString
        dtpFechaAl.Value = Now.ToShortDateString
        txtColaborador.Text = ""
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbPeriodoNomina.DataSource = Nothing
        cmbPeriodoNomina.ValueMember = Nothing
        cmbPeriodoNomina.DisplayMember = Nothing
        cmbPeriodoNomina.SelectedValue = Nothing
        cmbPeriodoNomina.Text = Nothing
        rdoPeriodoNomina.Checked = True
        grdDeducciones.ClearColumnsFilter()
        grdDeducciones.OptionsView.ShowFooter = GroupFooterShowMode.Hidden
    End Sub

    Private Sub rdoPeriodoNomina_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPeriodoNomina.CheckedChanged
        If rdoPeriodoNomina.Checked = True Then
            cmbPeriodoNomina.Enabled = True
            lblDel.Enabled = False
            lblAl.Enabled = False
            dtpFechaDel.Enabled = False
            dtpFechaAl.Enabled = False
        Else
            cmbPeriodoNomina.Enabled = 0
            lblDel.Enabled = 1
            lblAl.Enabled = 1
            dtpFechaDel.Enabled = 1
            dtpFechaAl.Enabled = 1
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click

    End Sub
End Class