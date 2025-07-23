Imports Tools

Public Class DeduccionesForm
    Dim FinSemanaNomina As DateTime
    Private Sub DeduccionesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Tools.FormatoCtrls.formato(Me)
        Me.Top = 0
        Me.Left = 0
        txtNumeroSemanas.Visible = False
        txtAbono.Visible = False
        lblAbono.Visible = False
        lblNumeroSemanas.Visible = False
        rdbAbono.Visible = False
        rdbSemanas.Visible = False
        btnCalcular.Visible = False
        lblCalcular.Visible = False
        btnOcultar.Visible = False
        lblOcultar.Visible = False

        grdTablaAmortizacion.Visible = False
        grdTablaAmortizacion.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdTablaAmortizacion.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdTablaAmortizacion.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdTablaAmortizacion.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdTablaAmortizacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdTablaAmortizacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdTablaAmortizacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdTablaAmortizacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        grdDeducciones.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdDeducciones.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdDeducciones.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdDeducciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdDeducciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdDeducciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            If cmbNave.SelectedValue > 0 Then
                cmbNaveDrop()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        cmbNaveDrop()
    End Sub


    Private Sub cmbArea_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.DropDownClosed
        Try
            Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, cmbArea.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbDepartamento_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamento.DropDownClosed
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        grdDeducciones.Rows.Clear()
        Try



            Dim idNave As Integer = CInt(cmbNave.SelectedValue)
            Dim idArea As Integer = 0
            Dim idDepartamento As Integer = 0

            If IsDBNull(cmbArea.SelectedValue) Then

            Else
                idArea = cmbArea.SelectedValue
            End If

            If IsDBNull(cmbDepartamento.SelectedValue) Then

            Else
                idDepartamento = cmbDepartamento.SelectedValue
            End If

            llenarTablaColaboradoresDeducciones(idNave, idArea, idDepartamento, txtColaborador.Text)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub llenarTablaColaboradoresDeducciones(ByVal idNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal ColaboradorN As String)

        Try
            Dim listaColaboradoresDecucciones As New List(Of Entidades.Deducciones)
            Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

            listaColaboradoresDecucciones = deduccionesBU.ListaColaboradoresDeduccion(idNave, idArea, idDepartamento, ColaboradorN)

            For Each objeto As Entidades.Deducciones In listaColaboradoresDecucciones
                AgregarFilaColaboradoresDeducciones(objeto)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaColaboradoresDeducciones(ByVal Deducciones As Entidades.Deducciones)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        ''El check box
        celda = New DataGridViewCheckBoxCell
        celda.Value = False
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

        ''El ID del colaborador
        celda = New DataGridViewTextBoxCell
        celda.Value = Deducciones.PColaborador.PColaboradorid
        fila.Cells.Add(celda)

        ''EL id de la semana activa
        celda = New DataGridViewTextBoxCell
        celda.Value = lblIdSemanaNomina.Text
        fila.Cells.Add(celda)

        ''El tipo de deduccion
        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)

        Me.grdDeducciones.Rows.Add(fila)

    End Sub

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
        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        FinSemanaNomina = SemanaActiva.PfechaFinNomina
        lblSemanaNomina.Text = SemanaActiva.PPeriodoNominaDeducciones

    End Sub
    ''LLENAR SEMANA NOMINA ACTIVA

    Private Sub SeleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        grdDeducciones.CurrentCell = grdDeducciones.Item(1, 0)
        For Each row As DataGridViewRow In grdDeducciones.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub DeseleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeseleccionarTodasToolStripMenuItem.Click
        grdDeducciones.CurrentCell = grdDeducciones.Item(1, 0)
        For Each row As DataGridViewRow In grdDeducciones.Rows
            row.Cells(0).Value = False
        Next
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If txtMonto.Text = "" Then
            lblMonto.ForeColor = Color.Red
            lblconcepto.ForeColor = Color.Black
        ElseIf txtConcepto.Text = "" Then
            lblconcepto.ForeColor = Color.Red
            lblMonto.ForeColor = Color.Black
        ElseIf chkPeriodo.CheckAlign = True Then
            Calcular()
            lblMonto.ForeColor = Color.Black
            lblconcepto.ForeColor = Color.Black
            GuardarDeducciones()
        Else
            lblMonto.ForeColor = Color.Black
            lblconcepto.ForeColor = Color.Black
            GuardarDeducciones()

        End If

    End Sub

    Public Sub GuardarDeducciones()
        Dim ObjDeducciones As New Entidades.Deducciones
        Dim ObjDeduccionesBU As New Negocios.DeduccionesBU
        Dim ObjColaborador As New Entidades.Colaborador
        Dim ObjCobranza As New Entidades.CobranzaPrestamos

        Dim contadorTrue As Integer = 0

        If txtConcepto.Text = "" Then
            Dim mensajeExito2 As New AvisoForm
            mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Favor de llenar el concepto "
            mensajeExito2.Show()

        Else

            If txtMonto.Text = "" Then
                Dim mensajeExito2 As New AvisoForm
                mensajeExito2.MdiParent = Me.MdiParent
                mensajeExito2.mensaje = "Favor de llenar el  monto"
                mensajeExito2.Show()
            Else

                For Each row As DataGridViewRow In grdDeducciones.Rows
                    If row.Cells("clmDeduccion").Value = True Then

                        ObjColaborador.PColaboradorid = CInt(row.Cells("clmIdColaborador").Value)
                        ObjDeducciones.PidCreo = CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        ObjDeducciones.PConceptoDeduccion = CStr(txtConcepto.Text)
                        ObjDeducciones.PMontoDeduccion = CDbl(txtMonto.Text)
                        ObjDeducciones.PnumeroSemanas = CInt(txtNumeroSemanas.Text)
                        ObjDeducciones.PEstatus = "A"
                        ObjDeducciones.PSaldo = CDbl(txtMonto.Text)

                        If chkPeriodo.Checked = True Then
                            ObjDeducciones.Pabono = CDbl(txtAbono.Text)
                        Else
                            ObjDeducciones.Pabono = CDbl(txtMonto.Text)
                        End If

                        ObjDeducciones.PColaborador = ObjColaborador

                        ObjDeduccionesBU.guardarDeduccionesExtraordinaria(ObjDeducciones)
                        contadorTrue = 1
                    End If

                Next

                If contadorTrue = 1 Then
                    Dim mensajeExito2 As New ExitoForm
                    mensajeExito2.MdiParent = Me.MdiParent
                    mensajeExito2.mensaje = "Deducciones guardadas"
                    mensajeExito2.Show()
                    limpiar()

                    Try

                        Dim idNave As Integer = CInt(cmbNave.SelectedValue)
                        Dim idArea As Integer = 0
                        Dim idDepartamento As Integer = 0

                        If IsDBNull(cmbArea.SelectedValue) Then

                        Else
                            idArea = cmbArea.SelectedValue
                        End If

                        If IsDBNull(cmbDepartamento.SelectedValue) Then

                        Else
                            idDepartamento = cmbDepartamento.SelectedValue
                        End If

                        llenarTablaColaboradoresDeducciones(idNave, idArea, idDepartamento, txtColaborador.Text)

                    Catch ex As Exception

                    End Try

                Else
                    Dim mensajeExito2 As New AvisoForm
                    mensajeExito2.MdiParent = Me.MdiParent
                    mensajeExito2.mensaje = "Seleccionar algun colaborador para realizar la deduccion"
                    mensajeExito2.Show()

                End If

            End If
        End If

    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtMonto.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True

        End If
    End Sub

    Private Sub txtMonto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMonto.LostFocus
        Try
            Dim Monto As Double = txtMonto.Text
            Monto = Math.Round(Monto, 2)
            txtMonto.Text = Monto.ToString("c")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColaborador.KeyPress
        Dim caracter As Char = e.KeyChar
        If (Char.IsLetter(caracter)) Or (caracter = ChrW(Keys.Back)) Or (Char.IsSeparator(caracter)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()

    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click

        If chkPeriodo.Checked = True Then
            grbParametros.Height = 208
        End If

        If chkPeriodo.Checked = False Then
            grbParametros.Height = 175
        End If

    End Sub

    Private Sub rdbSemanas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbSemanas.CheckedChanged
        If rdbSemanas.Checked = True Then
            txtNumeroSemanas.Enabled = True
            txtAbono.Enabled = False
            rdbAbono.Checked = False
        End If

    End Sub

    Private Sub rdbAbono_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAbono.CheckedChanged
        If rdbAbono.Checked = True Then
            txtAbono.Enabled = True
            txtNumeroSemanas.Enabled = False
            rdbSemanas.Checked = False
        End If

    End Sub

    Private Sub chkPeriodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPeriodo.CheckedChanged
        If chkPeriodo.Checked = True Then
            lblAbono.Visible = True
            lblNumeroSemanas.Visible = True
            txtNumeroSemanas.Visible = True
            txtAbono.Visible = True
            grbParametros.Height = 183
            rdbAbono.Visible = True
            rdbSemanas.Visible = True
            txtAbono.Enabled = False
            rdbSemanas.Checked = True
            btnCalcular.Visible = True
            lblCalcular.Visible = True

            btnOcultar.Visible = True
            lblOcultar.Visible = True

            btnGuardar.Enabled = False

        End If

        If chkPeriodo.Checked = False Then
            lblAbono.Visible = False
            lblNumeroSemanas.Visible = False
            txtNumeroSemanas.Visible = False
            txtAbono.Visible = False
            grbParametros.Height = 175
            rdbAbono.Visible = False
            rdbSemanas.Visible = False
            btnCalcular.Visible = False
            lblCalcular.Visible = False
            btnOcultar.Visible = False
            lblOcultar.Visible = False
            btnGuardar.Enabled = True
            grdTablaAmortizacion.Visible = False
            grdDeducciones.Visible = True
            grdTablaAmortizacion.Rows.Clear()
            txtAbono.Text = ""
            txtNumeroSemanas.Text = 1
            rdbSemanas.Checked = True

        End If

    End Sub

    Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
        Calcular()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOcultar.Click
        If lblOcultar.Text = "Mostrar Cálculo" Then
            grdTablaAmortizacion.Visible = True
            lblOcultar.Text = "Ocultar Cálculo"
            grdDeducciones.Visible = False

        ElseIf lblOcultar.Text = "Ocultar Cálculo" Then
            grdTablaAmortizacion.Visible = False
            grdDeducciones.Visible = True
            lblOcultar.Text = "Mostrar Cálculo"
        End If

    End Sub

    Public Sub limpiar()
        grdDeducciones.Rows.Clear()
        grdTablaAmortizacion.Rows.Clear()

        cmbNave.SelectedIndex = 0
        cmbArea.SelectedIndex = 0
        cmbDepartamento.SelectedIndex = 0

        txtColaborador.Text = ""
        txtConcepto.Text = ""
        txtMonto.Text = ""
        txtNumeroSemanas.Visible = False
        txtAbono.Visible = False

        lblAbono.Visible = False
        lblNumeroSemanas.Visible = False
        lblCalcular.Visible = False

        rdbAbono.Visible = False
        rdbSemanas.Visible = False

        btnCalcular.Visible = False
        grbParametros.Height = 175
        chkPeriodo.Checked = False
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        Dim Objeliminar As New EliminarDeduccionesForm
        Objeliminar.Show()
        Me.Close()
    End Sub

    Private Sub lblCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCobro.Click
        Dim ObjCobro As New CobranzaDeduccionesExtraordinariasForm
        ObjCobro.MdiParent = Me.MdiParent
        ObjCobro.Show()
        Me.Close()
    End Sub

    Private Sub btnLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLista.Click
        Dim objListas As New ListaDeduccionesExtraordinariasForm
        objListas.Show()
        Me.Close()
    End Sub


    Public Sub Calcular()
        Try
            If txtMonto.Text = "" Then
                lblMonto.ForeColor = Color.Red
                btnGuardar.Enabled = False
                grdTablaAmortizacion.Rows.Clear()

            Else
                lblMonto.ForeColor = Color.Black


                grdDeducciones.Visible = False
                grdTablaAmortizacion.Visible = True
                btnOcultar.Visible = True
                lblOcultar.Visible = True
                Dim Monto As Double = 0
                Dim fila As Integer = 0
                Dim Semanas As Integer = 1
                Dim abono As Double = 0
                Dim saldoAnterior As Double = 0

                ''POR ABONO
                If rdbAbono.Checked = True Then
                    If txtAbono.Text = "" Then
                        lblAbono.ForeColor = Color.Red
                        grdTablaAmortizacion.Rows.Clear()
                        btnGuardar.Enabled = False

                    Else
                        lblAbono.ForeColor = Color.Black
                        grdTablaAmortizacion.Rows.Clear()
                        Monto = CDbl(txtMonto.Text)
                        abono = CDbl(txtAbono.Text)
                        fila = 0

                        While Monto > 0

                            If Monto <= abono Then
                                Dim abonofinal As Double = Monto
                                saldoAnterior = Monto
                                Monto = Monto - abonofinal


                                grdTablaAmortizacion.Rows.Insert(fila, Semanas, abonofinal, saldoAnterior, Monto)
                                Monto = 0
                                Semanas = Semanas + 1

                            Else
                                saldoAnterior = Monto
                                Monto = Monto - abono
                                grdTablaAmortizacion.Rows.Insert(fila, Semanas, abono, saldoAnterior, Monto)

                                Semanas = Semanas + 1
                            End If
                            fila += 1

                        End While
                        txtNumeroSemanas.Text = Semanas - 1
                        btnGuardar.Enabled = True
                    End If
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''POR SEMANAS
                If rdbSemanas.Checked = True Then
                    If txtNumeroSemanas.Text = "" Then
                        lblNumeroSemanas.ForeColor = Color.Red
                        grdTablaAmortizacion.Rows.Clear()
                    Else
                        lblNumeroSemanas.ForeColor = Color.Black
                        grdTablaAmortizacion.Rows.Clear()
                        Monto = CDbl(txtMonto.Text)
                        abono = Monto / CInt(txtNumeroSemanas.Text)
                        fila = 0
                        saldoAnterior = 0
                        Semanas = CInt(txtNumeroSemanas.Text)

                        While Semanas > 0

                            If Monto <= abono Then
                                Dim abonofinal As Double = Monto
                                saldoAnterior = Monto
                                Monto = Monto - abonofinal

                                Me.grdTablaAmortizacion.Rows.Insert(fila, fila + 1, abonofinal, saldoAnterior, Monto)
                                Monto = 0
                                Semanas = Semanas - 1
                            Else
                                saldoAnterior = Monto
                                Monto = Monto - abono
                                Me.grdTablaAmortizacion.Rows.Insert(fila, fila + 1, abono, saldoAnterior, Monto)

                                Semanas = Semanas - 1
                            End If
                            fila += 1
                        End While
                        txtAbono.Text = abono
                        btnGuardar.Enabled = True

                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Public Sub cmbNaveDrop()
        Try

            lblSemanaNomina.Text = ""
            lblIdSemanaNomina.Text = ""
            Tools.Controles.ComboAreaSegunNave(cmbArea, cmbNave.SelectedValue)
            SemanaNomina()
            If lblSemanaNomina.Text = "C" Then
                cmbDepartamento.Enabled = False
                cmbArea.Enabled = False
                txtColaborador.Enabled = False
                txtConcepto.Enabled = False
                txtMonto.Enabled = False
                chkPeriodo.Enabled = False
                btnBuscar.Enabled = False
                btnGuardar.Enabled = False

                Dim mensajeExito2 As New AvisoForm
                mensajeExito2.MdiParent = Me.MdiParent
                mensajeExito2.mensaje = "El periodo de deducciones ya fue cerrado"
                mensajeExito2.Show()


            ElseIf lblSemanaNomina.Text = "A" Then
                cmbDepartamento.Enabled = True
                cmbArea.Enabled = True
                txtColaborador.Enabled = True
                txtConcepto.Enabled = True
                txtMonto.Enabled = True
                chkPeriodo.Enabled = True
                btnBuscar.Enabled = True
                btnGuardar.Enabled = True

            ElseIf lblSemanaNomina.Text = "B" Or lblSemanaNomina.Text = "" Then
                cmbDepartamento.Enabled = False
                cmbArea.Enabled = False
                txtColaborador.Enabled = False
                txtConcepto.Enabled = False
                txtMonto.Enabled = False
                chkPeriodo.Enabled = False
                btnBuscar.Enabled = False
                btnGuardar.Enabled = False

                Dim mensajeExito2 As New AvisoForm
                mensajeExito2.MdiParent = Me.MdiParent
                mensajeExito2.mensaje = "El periodo de esta nave esta bloqueado y/o no se a dado de alta"
                mensajeExito2.Show()

            End If
        Catch ex As Exception
        End Try
    End Sub


End Class