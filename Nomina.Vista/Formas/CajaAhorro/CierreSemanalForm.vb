Imports C1.Win.C1FlexGrid
Imports Tools

Public Class CierreSemanalForm
    Public listaNegativos As New List(Of Integer)
    Public IdCajaAhorro As Int32 = -1
    Public Nave As Int32 = 0 'String = ""
    Public Periodo As String = ""
    Dim permiso As Boolean = False

    Private semana As String
    Public IdPeriodoNomina As Int32 = -1
    Private _searchfilter As New C1.Win.C1FlexGrid.ConditionFilter


    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbCierreSemanal.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbCierreSemanal.Height = 159
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

        txtBuscar.Text = ""
        txtBuscar_TextChanged(sender, e)

        For i = 1 To grdCierreSemanal.Cols.Count - 1
            grdCierreSemanal.ClearFilter(i)
        Next

    End Sub

    Private Sub Inicializa()
        Me.Cursor = Cursors.WaitCursor
        Dim objColaboradorPeriodoCajaBU As New Nomina.Negocios.ColaboradorPeriodoCajaBU
        Dim objColaboradorPeriodoCaja As New List(Of Entidades.ColaboradorPeriodoCaja)


        If IdPeriodoNomina > 0 Then
            IdCajaAhorro = objColaboradorPeriodoCajaBU.ObtieneIdCajaAhorro(IdPeriodoNomina)
        End If

        objColaboradorPeriodoCaja = objColaboradorPeriodoCajaBU.Listar(IdCajaAhorro)

        grdCierreSemanal.Rows.Count = 1

        For Each objeto In objColaboradorPeriodoCaja
            AgregarFila(objeto)
            IdPeriodoNomina = objeto.pPeriodo.PeriodoId
            semana = objeto.pPeriodo.Concepto

            lblConceptoPeriodo.Text = objeto.pCajaAhorro.pConcepto.ToString

        Next

        grdCierreSemanal.SubtotalPosition = SubtotalPositionEnum.BelowData
        UpdateTotals()
        ActualizarColores()


        If Not (semana Is Nothing) Then
            lblConceptoSemNomina.Text = semana.ToString
        Else
            lblConceptoSemNomina.Text = ""
        End If

        grdCierreSemanal.Cols("CajaAhorroId").Visible = False
        grdCierreSemanal.Cols("ColaboradorId").Visible = False
        grdCierreSemanal.Cols("PeriodoNomId").Visible = False


        Me.Cursor = Cursors.Default
        'lblConceptoPeriodo.Text = Periodo

    End Sub

    Private Sub CierreSemanalForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter And Not (e.Alt Or e.Control) Then

            If Me.ActiveControl.GetType Is GetType(TextBox) Or Me.ActiveControl.GetType Is GetType(CheckBox) Or Me.ActiveControl.GetType Is GetType(DateTimePicker) Then
                If e.Shift Then
                    Me.ProcessTabKey(False)
                Else
                    Me.ProcessTabKey(True)
                End If
            End If
        End If

    End Sub

    Private Sub CierreSemanalForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdCierreSemanal.Cols("Monto").Width = 1
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Inicializa()

        cmbNave.SelectedValue = Nave
        lblNombreNave.Text = cmbNave.Text
        cmbPeriodosNomina.Visible = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "NOM_CAJA_ANT") Then
            ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodosNomina, cmbNave.SelectedValue)

            cmbPeriodosNomina.Visible = True
            permiso = True
        End If


        'Tools.FormatoCtrls.formato(Me)

    End Sub

    Public Sub AgregarFila(ByVal configuracion As Entidades.ColaboradorPeriodoCaja)

        'grdCierreSemanal.AddItem(grdCierreSemanal.Rows.Count & vbTab & configuracion.pColaborador.Pnumero & vbTab & configuracion.pColaborador.PNombre & vbTab & configuracion.pMontoAhorrado & vbTab & configuracion.pCajaAhorro.pCajaAhorroId & vbTab & configuracion.pColaborador.PColaboradorid & vbTab & configuracion.pPeriodo.PPeriodoId)
        grdCierreSemanal.AddItem(grdCierreSemanal.Rows.Count & vbTab & configuracion.pColaborador.pIdAnual & vbTab & configuracion.pColaborador.PNombreCompleto & vbTab & configuracion.pMontoAhorrado & vbTab & configuracion.pCajaAhorro.pCajaAhorroId & vbTab & configuracion.pColaborador.PColaboradorid & vbTab & configuracion.pPeriodo.PPeriodoId)

    End Sub


    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        _searchfilter.Condition1.Operator = C1.Win.C1FlexGrid.ConditionOperator.Contains
        _searchfilter.Condition1.Parameter = txtBuscar.Text

        Dim count As Int32 = 0

        grdCierreSemanal.BeginUpdate()

        For r = grdCierreSemanal.Rows.Fixed To grdCierreSemanal.Rows.Count - 1
            Dim visible As Boolean = False
            For c = grdCierreSemanal.Cols.Fixed To grdCierreSemanal.Cols.Count - 1
                If _searchfilter.Apply(grdCierreSemanal(r, c)) Then
                    visible = True
                    count += 1
                    Exit For
                End If
            Next
            grdCierreSemanal.Rows(r).Visible = visible
        Next
        grdCierreSemanal.EndUpdate()

        UpdateTotals()

    End Sub

    Private Sub grdCierreSemanal_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdCierreSemanal.AfterEdit
        UpdateTotals()
    End Sub

    Private Sub grdCierreSemanal_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCierreSemanal.EnterCell
        grdCierreSemanal.AllowEditing = False
        If grdCierreSemanal.Col = 3 Then


            If permiso = True Then
                grdCierreSemanal.AllowEditing = True
            Else
                grdCierreSemanal.AllowEditing = False
            End If

            If SePuedeEditar(grdCierreSemanal(grdCierreSemanal.Row, "ColaboradorId")) = True Then
                grdCierreSemanal.AllowEditing = True
            Else
                grdCierreSemanal.AllowEditing = False
            End If



        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim resultado As String = String.Empty

        resultado = Validar()
        If resultado.Length = 0 Then
            'If MessageBox.Show("Desea guardar la informacion", "Confirmar Operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            '    Guardar()
            'End If

            Dim MensajeConfirmacion As New ConfirmarForm
            MensajeConfirmacion.mensaje = "¿ Desea guardar la información ?"
            MensajeConfirmacion.Text = "Confirmar operación"
            MensajeConfirmacion.StartPosition = FormStartPosition.CenterScreen

            If MensajeConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Guardar()
            End If
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = resultado.ToString
            mensajeAdvertencia.ShowDialog()
        End If
    End Sub

    Private Function Validar() As String
        Validar = String.Empty

        If grdCierreSemanal.Rows.Count <= 1 Then
            Validar = "No hay información para guardar."
            Exit Function
        End If

        For i = 1 To grdCierreSemanal.Rows.Count - 2
            If Not IsNumeric(grdCierreSemanal.Rows(i)("Monto")) Then
                Validar = "El monto ahorrado no puede quedar vacío para el renglón: " & grdCierreSemanal(i, 0).ToString
                Exit Function
            End If

            If CDbl(grdCierreSemanal.Rows(i)("Monto")) < 0 Then
                Validar = "El monto ahorrado no puede ser menor a cero para el renglón: " & grdCierreSemanal(i, 0).ToString
                Exit Function
            End If
        Next

        If IdPeriodoNomina = -1 Then
            Validar = "No se encontró un periodo de nómina actual."
            Exit Function
        End If

    End Function

    Private Sub Guardar()
        Try

            Dim Lista As New List(Of Entidades.ColaboradorPeriodoCaja)

            For i = 1 To grdCierreSemanal.Rows.Count - 2

                Dim objColaboradorPeriodoCaja As New Entidades.ColaboradorPeriodoCaja

                Dim objCajaAhorro As New Entidades.CajaAhorro
                Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU
                objCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(grdCierreSemanal.Rows(i)("CajaAhorroId"))


                Dim objColaborador As New Entidades.Colaborador
                Dim objColaboradorBU As New Nomina.Negocios.ColaboradoresBU
                objColaborador = objColaboradorBU.BuscarColaboradorGeneral(grdCierreSemanal.Rows(i)("ColaboradorId"))

                Dim objPeriodosNomina As New Entidades.PeriodosNomina
                Dim objPeriodosNominaBU As New Nomina.Negocios.ControlDePeriodoBU
                If permiso = True Then
                    objPeriodosNomina = objPeriodosNominaBU.BuscarPeridosSeleccionados(cmbPeriodosNomina.SelectedValue)
                Else
                    objPeriodosNomina = objPeriodosNominaBU.BuscarPeridosSeleccionados(grdCierreSemanal.Rows(i)("PeriodoNomId"))
                End If

                objColaboradorPeriodoCaja.pCajaAhorro = objCajaAhorro
                objColaboradorPeriodoCaja.pPeriodo = objPeriodosNomina
                objColaboradorPeriodoCaja.pColaborador = objColaborador
                objColaboradorPeriodoCaja.pMontoAhorrado = grdCierreSemanal.Rows(i)("Monto")
                Lista.Add(objColaboradorPeriodoCaja)
            Next

            Dim objColaboradorPeriodoCajaBU As New Nomina.Negocios.ColaboradorPeriodoCajaBU
            objColaboradorPeriodoCajaBU.CerrarCajaAhorro(Lista, IdCajaAhorro)

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Cierre semanal guardado."
            mensajeExito.ShowDialog()

            Me.Close()

        Catch ex As Exception
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = ex.Message
            mensajeAdvertencia.ShowDialog()
        End Try

    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub FijarRenglon()

        Dim renglon As Int32
        renglon = 0
        For i = 1 To grdCierreSemanal.Rows.Count - 2
            If grdCierreSemanal.Rows(i).Visible = True Then
                renglon += 1
                grdCierreSemanal(i, 0) = renglon
            End If
        Next
    End Sub

    Private Sub grdCierreSemanal_ValidateEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles grdCierreSemanal.ValidateEdit

        If Not IsNumeric(grdCierreSemanal.Editor.Text) = True Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Introduzca un número"
            mensajeAdvertencia.ShowDialog()
            e.Cancel = True
            Exit Sub
        End If

        If e.Col = grdCierreSemanal.Cols("Monto").Index Then
            If CLng(grdCierreSemanal.Editor.Text) < 0 Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "El monto de ahorro tiene que ser mayor o igual a cero."
                mensajeAdvertencia.ShowDialog()
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub


    Private Function SePuedeEditar(IdColaborador As Int32) As Boolean
        SePuedeEditar = False
        'Dim colaborador As List(Of Integer)


        If listaNegativos.Count <= 0 Then
            SePuedeEditar = False
            Exit Function
        End If

        'For Each id As Int32 In listaNegativos

        'Next



        Dim colaborador = From n In listaNegativos Where n = IdColaborador Select n

        If colaborador.Count > 0 Then
            SePuedeEditar = True
        Else
            SePuedeEditar = False
        End If


    End Function


    Private Sub UpdateTotals()

        grdCierreSemanal.Subtotal(AggregateEnum.Clear)

        Dim s As CellStyle = grdCierreSemanal.Styles(CellStyleEnum.Subtotal0)
        s.BackColor = Color.GreenYellow
        s.ForeColor = Color.Black
        s.Font = New Font(grdCierreSemanal.Font, FontStyle.Bold)

        grdCierreSemanal.Subtotal(AggregateEnum.Sum, 0, -1, 3, "Grand Total")

    End Sub


    Private Sub ActualizarColores()
        Dim r As C1.Win.C1FlexGrid.CellStyle = grdCierreSemanal.Styles.Add("Critical")
        r.BackColor = Color.Salmon
        r.ForeColor = Color.Black
        r.Font = New Font(grdCierreSemanal.Font, FontStyle.Bold)

        If listaNegativos.Count > 0 Then
            For i As Int32 = 1 To grdCierreSemanal.Rows.Count - 2
                Dim colaborador = From n In listaNegativos Where n = grdCierreSemanal.Rows(i)("ColaboradorId") Select n
                If colaborador.Count > 0 Then
                    Dim rg As CellRange = grdCierreSemanal.GetCellRange(i, 3)
                    rg.Style = grdCierreSemanal.Styles("Critical")
                End If
            Next
        End If
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        grdCierreSemanal.Rows.Count = 1
        lblConceptoPeriodo.Text = ""
        lblConceptoSemNomina.Text = ""
        If permiso = True Then
            ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodosNomina, cmbNave.SelectedValue)
        End If
        Call btnLimpiar_Click(sender, e)
    End Sub



    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged

        'grdCierreSemanal.Rows.Count = 1
        'lblConceptoPeriodo.Text = ""
        'lblConceptoSemNomina.Text = ""
        'Call btnLimpiar_Click(sender, e)
        'Call btnBuscar_Click(sender, e)
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click


        IdPeriodoNomina = -1


        Dim objColaboradorPeriodoCajaBU As New Nomina.Negocios.ColaboradorPeriodoCajaBU


        If cmbNave.SelectedIndex > 0 Then

            If objColaboradorPeriodoCajaBU.VerificaIdCajaAhorro_Nave(cmbNave.SelectedValue) = True Then
                IdCajaAhorro = objColaboradorPeriodoCajaBU.ObtieneIdCajaAhorro_Nave(cmbNave.SelectedValue)
                Inicializa()
            Else
                grdCierreSemanal.Rows.Count = 1
                lblConceptoPeriodo.Text = ""
                lblConceptoSemNomina.Text = ""

                Call btnLimpiar_Click(sender, e)


                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "La nave no cuenta con una Caja de Ahorro Activa"
                mensajeAdvertencia.ShowDialog()

            End If

        End If

    End Sub

    Private Sub cmbPeriodosNomina_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriodosNomina.DropDownClosed
        lblConceptoSemNomina.Text = ""
    End Sub

    Public Function ComboPeriodoSegunNaveSegunAsistencia(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal naveID As Int32) As System.Windows.Forms.ComboBox

        Dim comboPeriodosSegunNave As New ComboBox
        comboPeriodosSegunNave = comboEntrada
        Dim tablaPeriodosSegunNave As New DataTable
        Dim objPeriodosSegunNave As New Nomina.Negocios.CajaAhorroBU
        tablaPeriodosSegunNave = objPeriodosSegunNave.periodosCajaAhorroSinCierre(naveID)
        comboPeriodosSegunNave.DataSource = tablaPeriodosSegunNave
        comboPeriodosSegunNave.DisplayMember = "pnom_Concepto"
        comboPeriodosSegunNave.ValueMember = "pnom_PeriodoNomId"
        Return comboPeriodosSegunNave
    End Function









End Class