Imports Produccion.Negocios
Imports Tools

Public Class AsignarColaboradoresAvancesProduccionForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public id As Integer = 0
    Public colaborador As String = ""
    Public idColaborador As Integer = 0
    Public Departamento As String = ""
    Public idDepartamento As String = ""
    Public activo As Integer = 0
    Public Accion As String = ""
    Public idtabla As New DataTable
    Public nave As Integer = 0
    Public estatus As String = ""
    'Public estatus As Integer
    Public modificar = 0
    
    Private Sub AsignarColaboradoresAvancesProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnGuardar.Visible = False
        lblGuardar.Visible = False

        Try
            If modificar = 0 Then
                lblIdNAve.Text = nave
            Else

                lblIdText.Text = id
                txtColaborador.Text = colaborador
                lblIDEmpleadoSicy.Text = idColaborador
                txtDepartamento.Text = Departamento
                lblIDDepartamento.Text = idDepartamento
                If estatus = "A" Then
                    'If estatus = 1 Then
                    rdoActivo.Checked = True
                Else
                    rdoInactivo.Checked = True
                End If
                lblIdNAve.Text = nave
                'buscarIdSicy()
                validar()
                'lblIDColaboradorSay.Text = idtabla.Rows(0).Item(0).ToString
                lblIDColaboradorSay.Text = idColaborador
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lblIdText.Text = "-"
        lblIDEmpleadoSicy.Text = 0
        lblIDDepartamento.Text = 0
        lblIdConfiguracion.Text = 0
        txtColaborador.Text = ""
        txtDepartamento.Text = ""
        lblIDColaboradorSay.Text = 0
        rdoActivo.Checked = True

        btnGuardar.Visible = False
        lblGuardar.Visible = False

    End Sub

    Private Sub btnBuscar1_Click(sender As Object, e As EventArgs) Handles btnBuscar1.Click
        Try
            txtColaborador.Text = Nothing
            Dim form As New ListaColaboradoresSicyForm
            Dim obj As New catalagosBU
            Dim tablas As New DataTable
            form.nave = nave
            form.ShowDialog()
            txtColaborador.Text = form.colaborador
            lblIDEmpleadoSicy.Text = form.idColaborador
            'buscarIdSicy()
            validar()
            'lblIDColaboradorSay.Text = idtabla.Rows(0).Item(0).ToString
            lblIDColaboradorSay.Text = form.idColaborador

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            txtDepartamento.Text = Nothing
            Dim form As New ListaDepartamentosForm
            form.nave = nave
            form.ShowDialog()
            txtDepartamento.Text = form.Departamento
            lblIDDepartamento.Text = form.idDepartamento
            lblIdConfiguracion.Text = form.Configuracion
            validar()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If lblIdText.Text = "-" Then
            Try
                If buscarRegistrosRepetidos() = False Then
                    If lblIdConfiguracion.Text = 0 Then
                        objMensaje.mensaje = "No hay configuracion registrada para está nave y departamento"
                        objMensaje.ShowDialog()
                    Else
                        GuardarEmpleadoAvances()
                    End If

                Else
                    objMensaje.mensaje = "El empleado capturado ya tiene un registro anterior"
                    objMensaje.ShowDialog()
                End If

            Catch ex As Exception
            End Try
        Else
            Try
                ModificarEmpleadoAvances()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Public Function buscarRegistrosRepetidos()
        Dim obj As New ProduccionBU
        Dim tablas As New DataTable

        'tablas = obj.BuscarRegistrosRepetidosAvancesDeProduccion(lblIDEmpleadoSicy.Text)
        tablas = obj.BuscarRegistrosRepetidosAvancesDeProduccion(lblIDColaboradorSay.Text, lblIdConfiguracion.Text)
        If tablas.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub GuardarEmpleadoAvances()
        Dim Empleado As New Entidades.LotesAvancesEmpleadosDepto
        Dim objbu As New ProduccionBU

        Empleado.idEmpleado = lblIDColaboradorSay.Text
        Empleado.idConfiguracion = lblIdConfiguracion.Text
        Empleado.estatus = "A"
        Empleado.idColaboradorSay = lblIDEmpleadoSicy.Text
        Empleado.usuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objbu.AltaLotesAvancesEmpleadosDepto(Empleado)
        objExito.mensaje = "Empleado registado con éxito"
        objExito.ShowDialog()
        Me.Close()
    End Sub


    Public Sub ModificarEmpleadoAvances()
        Dim Empleado As New Entidades.LotesAvancesEmpleadosDepto
        Dim objbu As New ProduccionBU

        Empleado.id = lblIdText.Text
        Empleado.idConfiguracion = lblIdConfiguracion.Text
        If rdoInactivo.Checked = True Then
            Empleado.estatus = "B"
        ElseIf rdoActivo.Checked = True Then
            Empleado.estatus = "A"
        End If
        Empleado.idColaboradorSay = lblIDColaboradorSay.Text
        Empleado.usuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objbu.ModificaLotesAvancesEmpleadosDepto(Empleado)
        objExito.mensaje = "Registro modificado con éxito"
        objExito.ShowDialog()
        Me.Close()
    End Sub

    Public Sub buscarIdSicy()
        Dim obj As New ProduccionBU
        idtabla = obj.buscarIdSicy(txtColaborador.Text)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub validar()
        If txtColaborador.Text = Nothing Then
            btnGuardar.Visible = False
            lblGuardar.Visible = False
        ElseIf txtDepartamento.Text = Nothing Then
            btnGuardar.Visible = False
            lblGuardar.Visible = False
        Else
            btnGuardar.Visible = True
            lblGuardar.Visible = True
        End If
    End Sub

End Class