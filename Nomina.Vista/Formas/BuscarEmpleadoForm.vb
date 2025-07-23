Imports Tools

Public Class BuscarEmpleadoForm
    Dim seleccion As Int32
    Dim columna As Int32 = 0
    Dim idNaveEmpleado As Int32 = 0
    Public Property pseleccion As Int32
        Get
            Return seleccion
        End Get
        Set(ByVal value As Int32)
            seleccion = value
        End Set
    End Property

    Public Property PIdNaveEmpleado As Int32
        Get
            Return idNaveEmpleado
        End Get
        Set(ByVal value As Int32)
            idNaveEmpleado = value
        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub



    Private Sub lblEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub txtBuscarEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub grdBuscarEmpleado_CellClick1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BuscarEmpleadoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        grdBuscarEmpleado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdBuscarEmpleado.Columns.Add("Nombre", "#") '0
        'grdBuscarEmpleado.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdBuscarEmpleado.Columns("Nombre").Width = 20
        grdBuscarEmpleado.Columns("Nombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '---------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Paterno", "Paterno") '1
        grdBuscarEmpleado.Columns("Paterno").Visible = False
        '-----------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Materno", "Colaborador") '2
        grdBuscarEmpleado.Columns("Materno").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'grdBuscarEmpleado.Columns("Materno").Width = 200
        '------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Departamento", "Departamento") '3
        grdBuscarEmpleado.Columns("Departamento").Width = 200
        '--------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("IDEmpleado", "IDEmpleado") '4
        grdBuscarEmpleado.Columns("IDEmpleado").Visible = False
        '----------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("FechaCreacion", "FechaCreacion") '5
        grdBuscarEmpleado.Columns("FechaCreacion").Visible = False
        '-------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Puesto", "Puesto") '6
        grdBuscarEmpleado.Columns("Puesto").Width = 180
        '--------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("IdNaveColaborador", "IdNaveColaborador") '7
        grdBuscarEmpleado.Columns("IdNaveColaborador").Visible = False

        grdBuscarEmpleado.Columns.Add("idCelula", "idCelula") '8
        grdBuscarEmpleado.Columns("idCelula").Visible = False

        grdBuscarEmpleado.Columns.Add("Celula", "Celula") '9
        grdBuscarEmpleado.Columns("Celula").Width = 120

        grdBuscarEmpleado.Columns.Add("idDepartamento", "idDepartamento") '10
        grdBuscarEmpleado.Columns("idDepartamento").Visible = False

        grdBuscarEmpleado.Columns.Add("tipoSalario", "tipoSalario") '11
        grdBuscarEmpleado.Columns("tipoSalario").Visible = False
        Me.MdiParent = MdiParent

        txtDepartamento.Visible = False
        txtDepartamento.Visible = False
        txtPuesto.Visible = False
        txtIDTrabajador.Visible = False

    End Sub




    Public Sub AgregarFila(ByVal empleado As Entidades.Colaborador)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = grdBuscarEmpleado.Rows.Count
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PApaterno
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PNombre + " " + empleado.PApaterno + " " + empleado.PAmaterno
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PIDepartamento.DNombre
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PColaboradorid
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PFechaCreacion
        fila.Cells.Add(celda)



        Dim BuscarPuesto As New Entidades.ColaboradorLaboral
        Dim objBusPuesto As New Negocios.ColaboradorLaboralBU
        BuscarPuesto = objBusPuesto.buscarInformacionLaboral(empleado.PColaboradorid)
        celda = New DataGridViewTextBoxCell
        Try
            celda.Value = BuscarPuesto.PPuestoId.PNombre
        Catch ex As Exception

        End Try

        fila.Cells.Add(celda)

        BuscarPuesto = objBusPuesto.buscarInformacionLaboral(empleado.PColaboradorid)
        celda = New DataGridViewTextBoxCell
        Try
            celda.Value = BuscarPuesto.PNaveId.PNaveId
        Catch ex As Exception

        End Try

        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.Pcelulas.PCelulaid
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.Pcelulas.PNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PIDepartamento.Ddepartamentoid
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PEmail
        fila.Cells.Add(celda)

        grdBuscarEmpleado.Rows.Add(fila)




    End Sub


    Public Sub llenartabla()


        Dim listaEmpleados As New List(Of Entidades.Colaborador)
        Dim objBU As New Negocios.ColaboradoresBU
        Dim numero As New Int32
        numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaEmpleados = objBU.BuscarEmpleado(txtBuscarEmpleado.Text, numero, cmbNave.SelectedValue)


        For Each objeto As Entidades.Colaborador In listaEmpleados


            AgregarFila(objeto)

        Next


    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        If cmbNave.SelectedIndex <= 0 Then
            lblNave.Text = "* Nave"
            lblNave.ForeColor = Color.Red
        Else

            grdBuscarEmpleado.Rows.Clear()
            llenartabla()
            idNaveEmpleado = (CInt(grdBuscarEmpleado.Rows(0).Cells(7).Value))
            seleccion = CInt(grdBuscarEmpleado.Rows(0).Cells(4).Value)
            txtBuscarEmpleado.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(2).Value)
            '+ " " + CStr(grdBuscarEmpleado.Rows(0).Cells(1).Value) _
            '+ " " + CStr(grdBuscarEmpleado.Rows(0).Cells(2).Value)
            txtDepartamento.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(3).Value)
            txtIDTrabajador.Text = (grdBuscarEmpleado.Rows(0).Cells(5).Value)
            txtPuesto.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(6).Value)
            txtCelula.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(9).Value)
            txtNave.Text = (CInt(grdBuscarEmpleado.Rows(0).Cells(7).Value))
            txtIdDepartamento.Text = (CInt(grdBuscarEmpleado.Rows(0).Cells(10).Value))
            txtTipoSalario.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(11).Value)
            lblNave.Text = "Nave"
            lblNave.ForeColor = Color.Black
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub grdBuscarEmpleado_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBuscarEmpleado.CellClick
        If e.RowIndex >= 0 Then
            idNaveEmpleado = (CInt(grdBuscarEmpleado.Rows(e.RowIndex).Cells(7).Value))
            seleccion = CInt(grdBuscarEmpleado.Rows(e.RowIndex).Cells(4).Value)
            txtBuscarEmpleado.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(2).Value)
            txtDepartamento.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(3).Value)
            txtIDTrabajador.Text = (grdBuscarEmpleado.Rows(e.RowIndex).Cells(5).Value)
            txtPuesto.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(6).Value)
            txtCelula.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(9).Value)
            txtNave.Text = (CInt(grdBuscarEmpleado.Rows(e.RowIndex).Cells(7).Value))
            txtIdDepartamento.Text = (CInt(grdBuscarEmpleado.Rows(e.RowIndex).Cells(10).Value))
            txtTipoSalario.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(11).Value)
        End If
    End Sub

    Private Sub btnContinuar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        If seleccion = 0 Then
            btnContinuar.DialogResult = Windows.Forms.DialogResult.Cancel

            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador"
            Advertencia.MdiParent = MdiParent
            Advertencia.Show()
        Else
            If txtNave.Text = String.Empty Then
                Dim Advertencia As New AdvertenciaForm
                Advertencia.mensaje = "Seleccione un colaborador"
                Advertencia.MdiParent = MdiParent
                Advertencia.Show()
            Else
                Me.Close()
            End If

            ' btnContinuar.DialogResult = Windows.Forms.DialogResult.OK

        End If



    End Sub




    Private Sub txtBuscarEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarEmpleado.KeyPress


        If CInt(AscW(e.KeyChar)) = CInt(Keys.Enter) Then
            'llenartabla()
            'grdBuscarEmpleado.Rows.Clear()
            llenartabla()
            idNaveEmpleado = (CInt(grdBuscarEmpleado.Rows(0).Cells(7).Value))
            seleccion = CInt(grdBuscarEmpleado.Rows(0).Cells(4).Value)
            txtBuscarEmpleado.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(2).Value)
            ' + " " + 'CStr(grdBuscarEmpleado.Rows(0).Cells(1).Value) _
            txtDepartamento.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(3).Value)
            txtIDTrabajador.Text = (grdBuscarEmpleado.Rows(0).Cells(5).Value)
            txtPuesto.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(6).Value)
            txtCelula.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(9).Value)
            txtNave.Text = (CInt(grdBuscarEmpleado.Rows(0).Cells(7).Value))
            txtIdDepartamento.Text = (CInt(grdBuscarEmpleado.Rows(0).Cells(10).Value))
            txtTipoSalario.Text = CStr(grdBuscarEmpleado.Rows(0).Cells(11).Value)
        End If

        Dim caracter As Char = e.KeyChar
        If (txtBuscarEmpleado.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtBuscarEmpleado.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub lblNave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNave.Click

    End Sub

    Private Sub txtBuscarEmpleado_TextChanged_1(sender As Object, e As EventArgs) Handles txtBuscarEmpleado.TextChanged

    End Sub

    Private Sub grdBuscarEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdBuscarEmpleado.CellContentClick

    End Sub
End Class