Imports Nomina.Negocios

Public Class AltaIncentivoForm
    Dim prueba As String
    Dim Seleccion As Int32
    Dim CmbSeleccion As Int32
    Dim nombre As String

    Public Sub AltaIncentivoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbMotivos = Controles.ComboMotivosIncentivoSegunUsuario(cmbMotivos, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '--------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Nombre", "Nombre") '0
        grdBuscarEmpleado.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '---------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Paterno", "Paterno") '1
        '-----------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Materno", "Materno") '2
        '------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("Departamento", "Departamento") '3
        '--------------------------------------------------------
        grdBuscarEmpleado.Columns.Add("IDEmpleado", "IDEmpleadp") '4
        grdBuscarEmpleado.Columns("IDEmpleado").Visible = False
        '----------------------------------------------------------

        txtBuscarNombreIncentivo.Enabled = False


    End Sub

    Private Sub btnBuscarEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Dim empleados As New BuscarEmpleadoForm
        'empleados.MdiParent = Me
        ' empleados.Show()
    End Sub





    Private Sub btnGuardar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnBuscarEmpleado_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tabAltaIncentivos.SelectedIndex = 1

    End Sub





    Public Sub AgregarFila(ByVal empleado As Entidades.Colaborador)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PNombre
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PApaterno
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PAmaterno
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PIDepartamento.DNombre
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = empleado.PColaboradorid
        fila.Cells.Add(celda)



        grdBuscarEmpleado.Rows.Add(fila)



    End Sub


    Public Sub llenartabla()


        Dim listaEmpleados As New List(Of Entidades.Colaborador)
        Dim objBU As New Negocios.ColaboradoresBU
        Dim numero As New Int32
        numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaEmpleados = objBU.BuscarEmpleado(txtBuscarEmpleado.Text, numero)
        For Each objeto As Entidades.Colaborador In listaEmpleados

            AgregarFila(objeto)
        Next


    End Sub





    Private Sub grdBuscarEmpleado_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        nombre = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtBuscarNombreIncentivo.Text = nombre
        tabAltaIncentivos.SelectedIndex = 0

    End Sub


    Private Sub btnBuscarEmpleado_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tabAltaIncentivos.SelectedIndex = 1
        lblTitle.Text = "Buscar Empleado"
    End Sub

    Private Sub txtBuscarEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarEmpleado.TextChanged

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        llenartabla()
        grdBuscarEmpleado.Rows.Clear()
        llenartabla()
    End Sub

    Private Sub grdBuscarEmpleado_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBuscarEmpleado.CellClick
        If e.RowIndex >= 0 Then
            Seleccion = CInt(grdBuscarEmpleado.Rows(e.RowIndex).Cells(4).Value)
            txtBuscarEmpleado.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(0).Value) + " " + CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(1).Value) + " " + CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(2).Value)
            txtBuscarNombreIncentivo.Text = CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(0).Value) + " " + CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(1).Value) + " " + CStr(grdBuscarEmpleado.Rows(e.RowIndex).Cells(2).Value)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinuar.Click
        tabAltaIncentivos.SelectedIndex = 0
        lblTitle.Text = "Agregar Incentivo"
    End Sub

    Private Sub lblEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblEmpleado.Click


    End Sub


    Private Sub cmbMotivos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If cmbMotivos.SelectedIndex <= 0 Then

        Else
            CmbSeleccion = cmbMotivos.SelectedValue

        End If


    End Sub







    Private Sub btnBuscarEmpleado_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarEmpleado.Click
        tabAltaIncentivos.SelectedIndex = 1
        lblTitle.Text = "Agregar Incentivo"
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim Empleado As Boolean = False
        If txtBuscarEmpleado.Text <> "" Then
            lblEmpleado.ForeColor = Color.Black
        Else
            lblEmpleado.ForeColor = Color.Red
            Empleado = True
        End If
        Dim Monto As Boolean = False
        If txtMonto.Text <> "" Then
            lblMonto.ForeColor = Color.Black
        Else
            lblMonto.ForeColor = Color.Red
            Monto = True
        End If
        Dim combo As Boolean = False
        If cmbMotivos.Text <> "" Then
            lblMotivo.ForeColor = Color.Black
        Else
            lblMotivo.ForeColor = Color.Red
            combo = True
        End If


        If (Empleado = True) Or (Monto = True) Or (combo = True) Then
            Dim FormularioError As New AdvertenciaForm
            FormularioError.mensaje = "Faltan campos por completar"
            FormularioError.MdiParent = MdiParent
            FormularioError.Show()
        Else
            Dim Incentivos As New Entidades.SolicitudIncentivos

            Incentivos.PColaboradorID = Seleccion
            Incentivos.PMonto = txtMonto.Text
            Incentivos.PDescripcion = TxtDescripcion.Text


            If cmbMotivos.SelectedIndex > 0 Then
                Dim motivo As New Entidades.Incentivos
                motivo.IIncentivoId = CInt(cmbMotivos.SelectedValue)
                Incentivos.PMotivoID = motivo
            End If


            Dim objBU As New IncentivosBU
            'bjBU.EnviarSolicitud(Incentivos)
            Dim FormularioMensaje As New ExitoForm
            Dim FormularioError As New AdvertenciaForm
            Dim MensajeNegocios As String = ""
            MensajeNegocios = objBU.EnviarSolicitud(Incentivos)


            If MensajeNegocios.Length = 0 Then


                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.MdiParent = MdiParent
                FormularioMensaje.Show()
                Me.Close()

            ElseIf MensajeNegocios = "El monto solicitado excede el limite del monto permitido." Then
                FormularioError.mensaje = MensajeNegocios
                FormularioError.MdiParent = MdiParent
                FormularioError.Show()
                Me.Close()
            Else
                FormularioError.mensaje = MensajeNegocios
                FormularioError.MdiParent = MdiParent
                FormularioError.Show()
                Me.Close()
            End If


        End If

    End Sub

    Private Sub txtMonto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtBuscarNombreIncentivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscarNombreIncentivo.TextChanged

    End Sub
End Class