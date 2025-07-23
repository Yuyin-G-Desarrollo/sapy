Imports Tools

Public Class EliminarDeduccionesForm
    Dim inicioSemana As DateTime
    Dim Finsemana As DateTime
    Dim TotalDeducciones As Double = 0.0
    Dim TotalAbono As Double = 0.0
    Private Sub EliminarDeduccionesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        'Tools.FormatoCtrls.formato(Me)
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Catch ex As Exception
        End Try
    End Sub


    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        Try
            Tools.Controles.ComboAreaSegunNave(cmbArea, cmbNave.SelectedValue)
            SemanaNomina()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub cmbArea_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.DropDownClosed
        Try
            Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, cmbArea.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        grdDeducciones.Rows.Clear()
        TotalDeducciones = 0.0
        TotalAbono = 0.0
        lblTotalDed.Text = "$ 0.0"
        lblTotalAbono.Text = "$ 0.0"
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


            llenarTablaDeduccionesEliminar(idNave, idArea, idDepartamento, txtColaborador.Text)


        Catch ex As Exception

        End Try

    End Sub


    ''----------------------
    Public Sub llenarTablaDeduccionesEliminar(ByVal idNave As Integer, ByVal idArea As Integer, ByVal idDepartamento As Integer, ByVal ColaboradorN As String)

        Try
            Dim listaDecucciones As New List(Of Entidades.Deducciones)
            Dim deduccionesBU As New Nomina.Negocios.DeduccionesBU

            listaDecucciones = deduccionesBU.ListaDeduccion(idNave, idArea, idDepartamento, ColaboradorN)

            For Each objeto As Entidades.Deducciones In listaDecucciones
                AgregarFilaDeduccionesEliminar(objeto)
            Next

            lblTotalDed.Text = "$ " & TotalDeducciones.ToString("##,##0.00")
            lblTotalAbono.Text = "$ " & TotalAbono.ToString("##,##0.00")

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDeduccionesEliminar(ByVal Deducciones As Entidades.Deducciones)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow
        Dim numeroDePago As Integer = Deducciones.PNumeroPago
        Dim fechaCreacion As DateTime = Deducciones.PFechaCreacion.ToShortDateString


        If numeroDePago < 2 OrElse (fechaCreacion >= inicioSemana And fechaCreacion <= Finsemana) Then

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

            ''El concepto
            celda = New DataGridViewTextBoxCell
            celda.Value = Deducciones.PConceptoDeduccion
            fila.Cells.Add(celda)

            ''El monto
            celda = New DataGridViewTextBoxCell
            celda.Value = Deducciones.PMontoDeduccion
            fila.Cells.Add(celda)

            TotalDeducciones += Deducciones.PMontoDeduccion
            TotalAbono += Deducciones.Pabono

            ''El abono
            celda = New DataGridViewTextBoxCell
            celda.Value = Deducciones.Pabono
            fila.Cells.Add(celda)

            ''Numero de semanas
            celda = New DataGridViewTextBoxCell
            celda.Value = Deducciones.PnumeroSemanas
            fila.Cells.Add(celda)

            ''El ID del colaborador
            celda = New DataGridViewTextBoxCell
            celda.Value = Deducciones.PColaborador.PColaboradorid
            fila.Cells.Add(celda)

            ''El ID DEDUCCION
            celda = New DataGridViewTextBoxCell
            celda.Value = Deducciones.PidDeduccion
            fila.Cells.Add(celda)

            ''El numero de pago
            celda = New DataGridViewTextBoxCell
            celda.Value = numeroDePago
            fila.Cells.Add(celda)

            Me.grdDeducciones.Rows.Add(fila)
        End If
    End Sub


    Private Sub SeleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click
        grdDeducciones.CurrentCell = grdDeducciones.Item(1, 0)
        For Each row As DataGridViewRow In grdDeducciones.Rows
            row.Cells(0).Value = True
        Next
    End Sub

    Private Sub DeseleccionarTodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeseleccionarTodosToolStripMenuItem.Click
        grdDeducciones.CurrentCell = grdDeducciones.Item(1, 0)
        For Each row As DataGridViewRow In grdDeducciones.Rows
            row.Cells(0).Value = False
        Next
    End Sub



    Public Sub EliminarDeducciones()
        Dim ObjDeducciones As New Entidades.Deducciones
        Dim ObjDeduccionesBU As New Negocios.DeduccionesBU

        Dim contadorTrue As Integer = 0


        For Each row As DataGridViewRow In grdDeducciones.Rows
            If row.Cells("clmDeduccion").Value = True Then
                ObjDeducciones.PidDeduccion = CInt(row.Cells("clmIdDeduccion").Value)
                contadorTrue = 1
                ObjDeduccionesBU.EliminarDeducciones(ObjDeducciones)
            End If
        Next

        If contadorTrue = 1 Then
            Dim mensajeExito2 As New ExitoForm
            mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Deduccion eliminada"
            mensajeExito2.Show()
            grdDeducciones.Rows.Clear()
            TotalDeducciones = 0.0
            lblTotalDed.Text = "$ 0.0"
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


                llenarTablaDeduccionesEliminar(idNave, idArea, idDepartamento, txtColaborador.Text)


            Catch ex As Exception

            End Try


        Else
            Dim mensajeExito2 As New AvisoForm
            mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Seleccionar algun colaborador para eliminar la deduccion"
            mensajeExito2.Show()

        End If

    End Sub


    Private Sub txtColaborador_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColaborador.KeyPress

        ''SOLO LETRAS
        Dim caracter As Char = e.KeyChar
        If (Char.IsLetter(caracter)) Or (caracter = ChrW(Keys.Back)) Or (Char.IsSeparator(caracter)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Estas seguro de querer eliminar las deducciones? "

        If mensajeExito.ShowDialog = DialogResult.OK Then
            EliminarDeducciones()
        End If


    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub
    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 127
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdDeducciones.Rows.Clear()
        txtColaborador.Text = ""
        TotalDeducciones = 0.0
        lblTotalDed.Text = "$ 0.0"

    End Sub

    Private Sub btnAltaDeducciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objAlta As New DeduccionesForm
        objAlta.Show()
        Me.Close()

    End Sub

    Private Sub btnCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objCobro As New CobranzaDeduccionesExtraordinariasForm
        objCobro.Show()
        Me.Close()

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
        Dim mensaje As String = ""
        Finsemana = SemanaActiva.PfechaFinNomina.ToShortDateString
        inicioSemana = SemanaActiva.PfechaInicioNomina.ToShortDateString
    End Sub

    Private Sub btnLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objListas As New ListaDeduccionesExtraordinariasForm
        objListas.Show()
        Me.Close()
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub
End Class