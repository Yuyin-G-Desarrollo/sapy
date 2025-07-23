Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools

Public Class CobranzaDeduccionesExtraordinariasForm
    Dim fechaFinNomina As DateTime

    Private Sub CobranzaDeduccionesExtraordinariasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            If cmbNave.SelectedIndex > 0 Then
                SemanaNomina()
            End If

            cmbEstatus.Visible = False
            lblEstatus.Visible = False
            lblIdSemanaNomina.Visible = False
            lblSemanaNomina.Visible = False
            lblSemanaNominaFIN.Visible = False
            'btnGuardar.Visible = False
            lblGuardar.Text = "Cerrar semana"
            'clmCondonarAbono.Visible = False
            'clmCondonarTodo.Visible = False
            'clmSemanas.Visible = False
            lblCondonado.Visible = False
            lblCondonado2.Visible = False
            lblPosibleCondonacion.Visible = False
            lblPosibleCondonacion2.Visible = False

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_DED", "CONDONARTODO") Then
                lblGuardar.Text = "Cerrar semana"
                'clmCondonarAbono.Visible = True
                'clmCondonarTodo.Visible = True
                'clmSemanas.Visible = True

                lblCondonado.Visible = True
                lblCondonado2.Visible = True
                lblPosibleCondonacion.Visible = True
                lblPosibleCondonacion2.Visible = True

            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_DED", "CONDONARABONO") Then
                'clmCondonarAbono.Visible = True
                'clmSemanas.Visible = True
                'clmCondonarTodo.Visible = False

                lblCondonado.Visible = True
                lblCondonado2.Visible = True
                lblPosibleCondonacion.Visible = True
                lblPosibleCondonacion2.Visible = True
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objAlta As New DeduccionesForm
        objAlta.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objeliminar As New EliminarDeduccionesForm
        objeliminar.Show()
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'grdDeducciones.Rows.Clear()
        Try
            'If cmbEstatus.SelectedIndex = 0 Then


            If cmbNave.SelectedIndex > 0 Then
                'if de A se comentó para que entrara en la condición
                'descomentar cuando se publique
                If lblSemanaNomina.Text = "A" Then
                    Me.Cursor = Cursors.WaitCursor
                    llenarTablaDeduccionesPorCobrar(cmbNave.SelectedValue)
                    btnCorte.Enabled = True
                    Me.Cursor = Cursors.Default
                End If
            Else
                Dim mensaje As New Tools.AdvertenciaForm
                mensaje.mensaje = "No se ha seleccionado ninguna nave."
                mensaje.ShowDialog()
            End If
            'End If

            'If cmbEstatus.SelectedIndex = 1 Then
            '    llenarTablaDeduccionesCobradas(cmbNave.SelectedValue, lblIdSemanaNomina.Text)

            'End If

        Catch ex As Exception
        End Try
    End Sub

    Public Sub llenarTablaDeduccionesCobradas(ByVal idNave As Integer, ByVal idSemanaNomina As Integer)

        Try
            Dim listaDecucciones As New List(Of Entidades.Deducciones)
            Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

            listaDecucciones = deduccionesBU.ListaDeduccionCobrados(idNave, idSemanaNomina)

            For Each objeto As Entidades.Deducciones In listaDecucciones
                ' AgregarFilaDeduccionesCobradas(objeto)
            Next

        Catch ex As Exception
        End Try
    End Sub

    'Public Sub AgregarFilaDeduccionesCobradas(ByVal Deducciones As Entidades.Deducciones)

    '    Dim celda As DataGridViewCell
    '    Dim fila As New DataGridViewRow

    '    ''El numero de pago
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PNumeroPago
    '    fila.Cells.Add(celda)

    '    ''El nombre
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PColaborador.PNombre + " " + Deducciones.PColaborador.PApaterno + " " + Deducciones.PColaborador.PAmaterno
    '    fila.Cells.Add(celda)

    '    ''El departamento
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PDepartamento
    '    fila.Cells.Add(celda)

    '    ''El Puesto
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PPuesto
    '    fila.Cells.Add(celda)

    '    ''El concepto
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PConceptoDeduccion
    '    fila.Cells.Add(celda)

    '    ''Numero de semanas
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PnumeroSemanas
    '    fila.Cells.Add(celda)

    '    ''El monto
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PMontoDeduccion
    '    fila.Cells.Add(celda)

    '    ''El Saldo
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PSaldoAnterior
    '    fila.Cells.Add(celda)

    '    ''El abono
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.Pabono
    '    fila.Cells.Add(celda)

    '    'Nuevo saldo
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PSaldo
    '    fila.Cells.Add(celda)

    '    ''El ID del colaborador
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PColaborador.PColaboradorid
    '    fila.Cells.Add(celda)

    '    ''El ID DEDUCCION
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PidDeduccion
    '    fila.Cells.Add(celda)

    '    ''El ID DEDUCCION
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Deducciones.PPagoID
    '    fila.Cells.Add(celda)

    '    ''COBRADO
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = "C"
    '    fila.Cells.Add(celda)

    '    Me.grdDeducciones.Rows.Add(fila)

    'End Sub

    Public Sub llenarTablaDeduccionesPorCobrar(ByVal idNave As Integer)

        Try
            Dim listaDecucciones As New List(Of Entidades.Deducciones)
            Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU
            Dim DTDeducciones As New DataTable
            DTDeducciones = deduccionesBU.ListaDeduccionPorCobrar(idNave)
            grdCierreSemanal.DataSource = DTDeducciones
            estiloGrdCierreSemanal()

            'listaDecucciones = deduccionesBU.ListaDeduccionPorCobrar(idNave)
            'grdCierreSemanal.DataSource = listaDecucciones
            'lstDeducciones = deduccionesBU.lstDeduccionesPorCobrar(idNave)
            'For Each objeto As Entidades.Deducciones In listaDecucciones
            '    AgregarFilaDeduccionesPorCobrar(objeto)
            'Next
            'Dim totalDeducciones As Double = 0
            'Dim contadorfilas As Integer = 0
            'For Each row As DataGridViewRow In grdDeducciones.Rows
            '    totalDeducciones += row.Cells("clmAbono").Value
            '    contadorfilas += 1

            '    ''Posible condonacion
            '    If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_DED", "CONDONARTODO") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_DED", "CONDONARABONO") Then
            '        If row.Cells("clmSemanas").Value = 6 And row.Cells("clmCondonacion").Value = 0 Then
            '            grdDeducciones.Rows(contadorfilas - 1).DefaultCellStyle.BackColor = Color.LightBlue
            '        End If

            '        If row.Cells("clmSemanas").Value = 6 And row.Cells("clmCondonacion").Value > 0 Then
            '            grdDeducciones.Rows(contadorfilas - 1).DefaultCellStyle.BackColor = Color.LightGray
            '        End If
            '    End If
            'Next
            'If contadorfilas > 0 Then
            '    grdDeducciones.Rows.Add("", "", "", "", "", "", "", "", "", "", totalDeducciones.ToString("N0"), "")
            '    grdDeducciones.Rows(contadorfilas).DefaultCellStyle.BackColor = Color.GreenYellow
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub estiloGrdCierreSemanal()
        grdCierreSemanal.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdCierreSemanal.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdCierreSemanal.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdCierreSemanal.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdCierreSemanal.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdCierreSemanal.DisplayLayout.Override.RowSelectorWidth = 35
        grdCierreSemanal.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        With grdCierreSemanal.DisplayLayout.Bands(0)
            .Columns("IdColaborador").Hidden = True
            .Columns("IdDeduccion").Hidden = True
            .Columns("NumSemanas").Hidden = True
            .Columns("NumPago").Hidden = True

            .Columns("CondonarTodo").Header.Caption = "Condonar Todo"
            .Columns("NumeroPago").Header.Caption = "Número Pago"
            .Columns("SaldoNuevo").Header.Caption = "Saldo Nuevo"

            .Columns("CondonarTodo").Header.Appearance.TextHAlign = HAlign.Center

            .Columns("CondonarTodo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("NumeroPago").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Departamento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Concepto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Monto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Saldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Abono").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("SaldoNuevo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("NumeroPago").CellAppearance.TextHAlign = HAlign.Center
            .Columns("Monto").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Saldo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Abono").CellAppearance.TextHAlign = HAlign.Right
            .Columns("SaldoNuevo").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Monto").Format = "##,##0.00"
            .Columns("Saldo").Format = "##,##0.00"
            .Columns("Abono").Format = "##,##0.00"
            .Columns("SaldoNuevo").Format = "##,##0.00"
            .Columns("Abono").MaskInput = "nnnn"
        End With


        Dim summary1 As SummarySettings
        summary1 = grdCierreSemanal.DisplayLayout.Bands(0).Summaries.Add("Total Abono", SummaryType.Sum, grdCierreSemanal.DisplayLayout.Bands(0).Columns("Abono"))
        grdCierreSemanal.DisplayLayout.Bands(0).SummaryFooterCaption = "Total Abono"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right

        Me.grdCierreSemanal.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCierreSemanal.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdCierreSemanal.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub grdCierreSemanal_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdCierreSemanal.AfterCellUpdate
        Try
            Dim abono As Double = 0
            Dim saldo As Double = 0

            If e.Cell.Column.Header.Caption = "Abono" Then
                Try
                    abono = grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("Abono").Value
                    saldo = grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("Saldo").Value
                Catch ex As Exception
                    grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("Abono").Value = 0
                End Try

                If abono > saldo Then
                    grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("Abono").Appearance.BackColor = Color.Salmon
                    grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("SaldoNuevo").Value = 0
                Else
                    grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("Abono").Appearance.BackColor = Color.LightGreen
                    grdCierreSemanal.Rows(e.Cell.Row.Index).Cells("SaldoNuevo").Value = saldo - abono
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDeduccionesPorCobrar(ByVal Deducciones As Entidades.Deducciones)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        Dim listaDecucciones As New List(Of Entidades.Deducciones)
        Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

        listaDecucciones = deduccionesBU.NumSemanasGanadas(Deducciones.PColaborador.PColaboradorid)
        Dim ContadorSemanas As Integer = 0
        For Each objeto As Entidades.Deducciones In listaDecucciones
            If objeto.PSemGanadas = True Then
                ContadorSemanas += 1
            End If
        Next

        Dim listaCondonacion As New List(Of Entidades.Deducciones)
        Dim condonacionBU As New Nomina.Negocios.DeduccionesBU

        listaCondonacion = condonacionBU.NumCondonaciones(Deducciones.PColaborador.PColaboradorid)
        Dim contadorCondonaciones As Integer = 0
        For Each objeto As Entidades.Deducciones In listaCondonacion
            If objeto.PCondonacion = True Then
                contadorCondonaciones += 1
            End If
        Next


        ''Condonar abono
        celda = New DataGridViewCheckBoxCell
        celda.Value = False
        fila.Cells.Add(celda)

        'Condonar todo
        celda = New DataGridViewCheckBoxCell
        celda.Value = False
        fila.Cells.Add(celda)

        ''El numero de pago
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PNumeroPago.ToString + "/" + Deducciones.PnumeroSemanas.ToString
        fila.Cells.Add(celda)

        ''El nombre
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PColaborador.PNombre + " " + Deducciones.PColaborador.PApaterno + " " + Deducciones.PColaborador.PAmaterno
        fila.Cells.Add(celda)

        ''El departamento
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PDepartamento
        fila.Cells.Add(celda)

        ''El Puesto
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PPuesto
        fila.Cells.Add(celda)

        ''El concepto
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PConceptoDeduccion
        fila.Cells.Add(celda)

        ''Numero de semanas
        celda = New DataGridViewTextBoxCell
        celda.Value = ContadorSemanas
        fila.Cells.Add(celda)

        ''El monto
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PMontoDeduccion
        fila.Cells.Add(celda)

        ''El Saldo
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PSaldo
        fila.Cells.Add(celda)



        Dim Saldo As Double = Deducciones.PSaldo
        Dim abono As Double = Deducciones.Pabono
        Dim SaldoAnterior As Double = Deducciones.PSaldo

        Dim abonofinal As Double = 0
        If Saldo <= abono Then
            abonofinal = Saldo
            ''El abono
            celda = New DataGridViewTextBoxCell
            celda.Value = abonofinal
            fila.Cells.Add(celda)

            'Nuevo saldo
            celda = New DataGridViewTextBoxCell
            celda.Value = Saldo - abonofinal
            fila.Cells.Add(celda)


        Else
            ''El abono
            celda = New DataGridViewTextBoxCell
            celda.Value = abono
            fila.Cells.Add(celda)


            'Nuevo saldo
            celda = New DataGridViewTextBoxCell
            celda.Value = Saldo - abono
            fila.Cells.Add(celda)
        End If

        ''El ID del colaborador
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PColaborador.PColaboradorid
        fila.Cells.Add(celda)

        ''El ID DEDUCCION
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PidDeduccion
        fila.Cells.Add(celda)

        ''El ID PAGO
        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)

        ''POr cobrar
        celda = New DataGridViewTextBoxCell
        celda.Value = "PC"
        fila.Cells.Add(celda)

        ''Condonaciones
        celda = New DataGridViewTextBoxCell
        celda.Value = contadorCondonaciones
        fila.Cells.Add(celda)

        ''El numero de pago
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PNumeroPago.ToString
        fila.Cells.Add(celda)

        ' Me.grdDeducciones.Rows.Add(fila)
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        If cmbNave.SelectedIndex > 0 Then
            SemanaNomina()
        Else
        End If
    End Sub

    'Private Sub grdDeducciones_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    '    If e.ColumnIndex = Me.clmCondonarTodo.Index Then
    '        Dim value As Boolean = CType(Me.grdDeducciones.CurrentCell.EditedFormattedValue, Boolean)

    '        If value = True Then
    '            grdDeducciones.CurrentRow.Cells("clmCondonarAbono").Value = False
    '        End If
    '    End If

    '    If e.ColumnIndex = Me.clmCondonarAbono.Index Then
    '        Dim value As Boolean = CType(Me.grdDeducciones.CurrentCell.EditedFormattedValue, Boolean)
    '        If value = True Then
    '            grdDeducciones.CurrentRow.Cells("clmCondonarTodo").Value = False
    '        End If
    '    End If
    'End Sub

    'Private Sub grdDeducciones_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    Try
    '        Dim abono As Double = 0
    '        Dim saldo As Double = 0
    '        Dim saldonuevo As Double = 0
    '        Dim estamal As Integer = 0
    '        Dim Acumulado As Double = 0
    '        If e.ColumnIndex = 10 Then

    '            For Each row As DataGridViewRow In grdDeducciones.Rows
    '                If row.Cells("clmColaborador").Value <> "" Then


    '                    Try
    '                        abono = row.Cells("clmAbono").Value
    '                    Catch ex As Exception
    '                        row.Cells("clmAbono").Value = 0
    '                    End Try

    '                    ''VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SALDO QUE TIENE
    '                    If row.Cells("clmAbono").Value > row.Cells("clmSaldo").Value Then
    '                        row.Cells("clmAbono").Style.BackColor = Color.Salmon
    '                        estamal += 1

    '                    Else
    '                        Acumulado += row.Cells("clmAbono").Value
    '                        row.Cells("clmAbono").Style.BackColor = Color.White
    '                        saldonuevo = row.Cells("clmSaldo").Value - row.Cells("clmAbono").Value
    '                        abono = row.Cells("clmAbono").Value
    '                        row.Cells("clmAbono").Value = abono.ToString("N0")
    '                        row.Cells("clmSaldoNuevo").Value = saldonuevo.ToString("N0")

    '                    End If
    '                Else
    '                    row.Cells("clmAbono").Value = Acumulado
    '                End If
    '            Next

    '            If estamal = 0 Then
    '                btnCorte.Enabled = True
    '            Else
    '                btnCorte.Enabled = False
    '            End If

    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub btnCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorte.Click
        Dim mensajeExito As New ConfirmarForm

        If validarAbonos() Then
            mensajeExito.mensaje = "¿Esta seguro que quiere realizar el cierre de deducciones? "
            If mensajeExito.ShowDialog = DialogResult.OK Then
                btnBuscar.Enabled = False
                guardarDeduccion()
                grdCierreSemanal.DataSource = Nothing
                lblIdSemanaNomina.Text = ""
            End If
        End If

        'Antes
        'Dim contador As Integer = 0
        'For Each dato As DataGridViewRow In grdDeducciones.Rows
        '    contador += 1
        'Next

        'If contador > 0 Then
        '    Dim mensajeExito As New ConfirmarForm
        '    mensajeExito.mensaje = "¿Esta seguro que quiere realizar el cierre de deducciones? "

        '    If mensajeExito.ShowDialog = DialogResult.OK Then
        '        ' btnGuardar.Enabled = False
        '        btnBuscar.Enabled = False
        '        guardarDeduccion()
        '        grdDeducciones.Rows.Clear()
        '        lblIdSemanaNomina.Text = ""
        '    End If
        'End If
    End Sub

    Private Function validarAbonos() As Boolean
        Dim msjAdvertencia As New Tools.AdvertenciaForm
        Dim objBU As New Negocios.CobranzaPrestamosBU

        If grdCierreSemanal.Rows.Count = 0 Then
            msjAdvertencia.mensaje = "No se puede cerrar semana si no hay deducciones por aplicar."
            msjAdvertencia.ShowDialog()
            Return False
        End If

        If objBU.validaPeriodoAnterior(CInt(lblIdSemanaNomina.Text), CInt(cmbNave.SelectedValue)) = False Then
            msjAdvertencia.mensaje = "No se puede cerrar semana si el periodo de nómina anterior no ha sido cerrado."
            msjAdvertencia.ShowDialog()
            Return False
        End If

        For Each row As UltraGridRow In grdCierreSemanal.Rows
            If row.Cells("Abono").Value > row.Cells("Saldo").Value Then
                msjAdvertencia.mensaje = "Hay abonos que sobrepasan el saldo de la deducción."
                msjAdvertencia.ShowDialog()
                Return False
            End If
        Next

        Return True
    End Function

    Public Sub guardarDeduccion()
        Try
            Dim ObjDedu As New Entidades.Deducciones
            Dim objBU As New Negocios.DeduccionesBU
            Dim mensajeExito As New ExitoForm

            For Each row As UltraGridRow In grdCierreSemanal.Rows
                ObjDedu.PidDeduccion = row.Cells("IdDeduccion").Value
                ObjDedu.PSemanaNominaID = lblIdSemanaNomina.Text
                ObjDedu.PNumeroPago = row.Cells("NumPago").Value
                ObjDedu.PSaldoAnterior = row.Cells("Saldo").Value
                ObjDedu.PSaldo = row.Cells("SaldoNuevo").Value

                If row.Cells("CondonarTodo").Value = True Then
                    ObjDedu.Pabono = 0
                    ObjDedu.PEstatus = "C"
                    ObjDedu.PCondonacion = True
                ElseIf row.Cells("SaldoNuevo").Value = 0 Then
                    ObjDedu.Pabono = row.Cells("Abono").Value
                    ObjDedu.PEstatus = "C"
                    ObjDedu.PCondonacion = False
                Else
                    ObjDedu.Pabono = row.Cells("Abono").Value
                    ObjDedu.PEstatus = "B"
                    ObjDedu.PCondonacion = False
                End If

                ObjDedu.PidCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                ObjDedu.PFechaModificacion = fechaFinNomina

                objBU.GuardarPagoDeduccionesExtraordinarias(ObjDedu)
            Next


            'mensajeExito.MdiParent = Me.MdiParent
            'mensajeExito.mensaje = "Corte de deducciones guardado"
            'mensajeExito.Show()
            Dim objMensajeGuardar As New Tools.ExitoForm
            objMensajeGuardar.mensaje = "Corte de deducciones guardado."
            objMensajeGuardar.ShowDialog()
            cmbNave.SelectedIndex = 0
            grdCierreSemanal.DataSource = Nothing

        Catch ex As Exception
        End Try
    End Sub

    'Public Sub guardarDeduccion()
    '    Try
    '        Dim ObjDedu As New Entidades.Deducciones
    '        Dim objBU As New Negocios.DeduccionesBU
    '        Dim contadorTrue As Integer = 0

    '        For Each row As DataGridViewRow In grdDeducciones.Rows
    '            If row.Cells("clmNumeroPago").Value.ToString = "" Then

    '            Else
    '                ObjDedu.PidDeduccion = row.Cells("clmIdDeduccion").Value
    '                ObjDedu.PSemanaNominaID = lblIdSemanaNomina.Text
    '                ObjDedu.PNumeroPago = row.Cells("clmNumPago").Value
    '                ObjDedu.PSaldoAnterior = row.Cells("clmSaldo").Value
    '                ObjDedu.PSaldo = row.Cells("clmSaldoNuevo").Value



    '                If row.Cells("clmCondonarTodo").Value = True Then
    '                    ObjDedu.Pabono = 0
    '                    ObjDedu.PEstatus = "C"
    '                    ObjDedu.PCondonacion = True
    '                ElseIf row.Cells("clmCondonarAbono").Value = True And row.Cells("clmSaldoNuevo").Value > 0 Then
    '                    ObjDedu.Pabono = 0
    '                    ObjDedu.PEstatus = "B"
    '                    ObjDedu.PCondonacion = True
    '                ElseIf row.Cells("clmCondonarAbono").Value = True And row.Cells("clmSaldoNuevo").Value = 0 Then
    '                    ObjDedu.Pabono = 0
    '                    ObjDedu.PEstatus = "C"
    '                    ObjDedu.PCondonacion = True
    '                ElseIf row.Cells("clmSaldoNuevo").Value = 0 Then
    '                    ObjDedu.Pabono = row.Cells("clmAbono").Value
    '                    ObjDedu.PEstatus = "C"
    '                    ObjDedu.PCondonacion = False
    '                ElseIf row.Cells("clmCondonarAbono").Value = False And row.Cells("clmCondonarTodo").Value = False Then
    '                    ObjDedu.PEstatus = "B"
    '                    ObjDedu.Pabono = row.Cells("clmAbono").Value
    '                    ObjDedu.PCondonacion = False
    '                End If


    '                ObjDedu.PidCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    '                ObjDedu.PFechaModificacion = fechaFinNomina

    '                objBU.GuardarPagoDeduccionesExtraordinarias(ObjDedu)
    '            End If
    '        Next

    '        Dim mensajeExito2 As New ExitoForm
    '        mensajeExito2.MdiParent = Me.MdiParent
    '        mensajeExito2.mensaje = "Corte de deducciones guardado"
    '        mensajeExito2.Show()
    '        cmbNave.SelectedIndex = 0
    '        grdDeducciones.Rows.Clear()

    '    Catch ex As Exception
    '    End Try
    'End Sub
    ''Metodo para que solo se ingresen NUMEROS y UN punto en un datagridview
    'Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
    '    ' referencia a la celda 
    '    Dim validar As TextBox = CType(e.Control, TextBox)
    '    ' agregar el controlador de eventos para el KeyPress  
    '    AddHandler validar.KeyPress, AddressOf validar_Keypress
    'End Sub

    ''Evento key press para validacion del datagridview
    'Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    ' evento Keypress  
    '    ' obtener indice de la columna  
    '    ' Dim columna As Integer = grdDeducciones.CurrentCell.ColumnIndex

    '    ' comprobar si la celda en edición corresponde a la columna que se requiera
    '    If columna = 8 Then
    '        ' Obtener caracter  
    '        Dim caracter As Char = e.KeyChar

    '        ' referencia a la celda  
    '        Dim txt As TextBox = CType(sender, TextBox)

    '        ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
    '        ' es el separador decimal, y que no contiene ya el separador  

    '        If (Char.IsNumber(caracter)) Or _
    '        (caracter = ChrW(Keys.Back)) Or _
    '        (caracter = ".") And _
    '        (txt.Text.Contains(".") = False) Then

    '            e.Handled = False
    '        Else
    '            e.Handled = True

    '        End If
    '    End If
    'End Sub

    ''LLENAR SEMANA NOMINA ACTIVA
    Public Sub SemanaNomina()
        Try
            Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
            Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            SemanaNominaActiva = SenamaActivaBu.SemanaNominaActiva(idNave)

            For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
                SemanaActiva(objeto)
            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Sub SemanaActiva(ByVal SemanaActiva As Entidades.CobranzaPrestamos)
        Dim mensaje As String = ""
        fechaFinNomina = SemanaActiva.PfechaFinNomina
        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        lblSemanaNominaFIN.Text = SemanaActiva.PfechaFinNomina
        lblSemanaNomina.Text = SemanaActiva.PPeriodoNominaDeducciones
        lblConceptoNomina.Text = SemanaActiva.PConceptoSemana

        If lblSemanaNomina.Text = "C" Then
            btnCorte.Enabled = False
        Else
            btnCorte.Enabled = True
            btnBuscar.Enabled = True

        End If
    End Sub

    Private Sub cmbEstatus_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEstatus.DropDownClosed
        If cmbEstatus.SelectedIndex = 0 Then
            btnCorte.Visible = True
            ' btnGuardar.Visible = False
            lblGuardar.Text = "Cierre semanal"
        End If

        If cmbEstatus.SelectedIndex = 1 Then
            '  btnGuardar.Visible = True
            btnCorte.Visible = False
            lblGuardar.Text = "Editar cierre semanal"
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Estas seguro de querer realizar el cierre de deducciones? "

        If mensajeExito.ShowDialog = DialogResult.OK Then
            ' btnGuardar.Enabled = False
            btnBuscar.Enabled = False
            guardarEdicionDeduccion()
            'grdDeducciones.Rows.Clear()
            lblIdSemanaNomina.Text = ""
        End If
    End Sub

    Public Sub guardarEdicionDeduccion()
        Dim ObjDedu As New Entidades.Deducciones
        Dim objBU As New Negocios.DeduccionesBU
        Dim contadorTrue As Integer = 0

        'For Each row As DataGridViewRow In grdDeducciones.Rows

        '    If row.Cells("clmIdPago").Value.ToString = "" Then

        '    Else
        '        '         
        '        '@decx_deduccionid,

        '        '@decx_usuariomodifico as integer,
        '        '@decx_estatus as nvarchar(1),

        '        '@pagodecx_pagoid as integer,
        '        '@pagodecx_abono as money,
        '        '@pagodecx_saldoanterior as money,
        '        '@pagodecx_saldonuevo as money

        '        ObjDedu.PidDeduccion = row.Cells("clmIdDeduccion").Value
        '        ObjDedu.PidModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        '        If row.Cells("clmSaldoNuevo").Value = 0 Or row.Cells("clmCondonarTodo").Value = True Then
        '            ObjDedu.Pabono = row.Cells("clmAbono").Value
        '            ObjDedu.PEstatus = "C"
        '        ElseIf row.Cells("clmCondonarAbono").Value = True Then
        '            ObjDedu.Pabono = 0
        '            ObjDedu.PEstatus = "B"
        '        ElseIf row.Cells("clmCondonarAbono").Value = False And row.Cells("clmCondonarTodo").Value = False Then
        '            ObjDedu.PEstatus = "B"
        '            ObjDedu.Pabono = row.Cells("clmAbono").Value
        '        End If
        '        ObjDedu.PPagoID = row.Cells("clmIdPago").Value

        '        ObjDedu.PSaldoAnterior = row.Cells("clmSaldo").Value
        '        ObjDedu.PSaldo = row.Cells("clmSaldoNuevo").Value

        '        'objBU.GuardaEdicionDeduccion(ObjDedu)
        '    End If
        'Next

        Dim mensajeExito2 As New ExitoForm
        mensajeExito2.MdiParent = Me.MdiParent
        mensajeExito2.mensaje = "Cierre semanal de deducciones guardado"
        mensajeExito2.Show()
        cmbNave.SelectedIndex = 0
        'grdDeducciones.Rows.Clear()
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 115
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        'grdDeducciones.Rows.Clear()
        grdCierreSemanal.DataSource = Nothing
        lblConceptoNomina.Text = "Periodo de nómina"
        cmbNave.SelectedIndex = 0
    End Sub

    Private Sub btnLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objListas As New ListaDeduccionesExtraordinariasForm
        objListas.Show()
        Me.Close()
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub pnlMinimizarParametros_Paint(sender As Object, e As PaintEventArgs) Handles pnlMinimizarParametros.Paint

    End Sub
End Class