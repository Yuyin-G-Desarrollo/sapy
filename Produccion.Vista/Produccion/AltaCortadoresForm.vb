Imports Produccion.Negocios
Imports Entidades
Imports Tools

Public Class AltaCortadoresForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim lsta As New DataTable

    Public idEmpleado As Integer = 0
    Public idRegistro As Integer = 0
    Public empleado As String = ""
    Public nombrecorto As String = ""
    Public tipoCortador As String = ""
    Public activo As String = ""
    Public accion As Integer = 0
    Public nave As Integer

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbTipoCortador.SelectedValue = 0
        lblIdText.Text = ""
        txtNombre.Text = ""
        txtNombreCorto.Text = ""
        rdoActivo.Checked = True
        btnBuscarEmpleado.Enabled = True
        lblIdText.Visible = False
        lblIdRegistro.Visible = False
    End Sub

    Private Sub AltaCortadoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsta.Columns.Add("ID")
        lsta.Columns.Add("Tipo")
        llenarComboTipoCortador()
        txtNombreCorto.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        If accion = 0 Then
            rdoInactivo.Enabled = False
        Else

            lblIdColaborador.Text = idEmpleado
            lblIdText.Text = idRegistro
            txtNombre.Text = empleado
            txtNombreCorto.Text = nombrecorto
            lblNaveid.Text = nave
            If activo = "ACTIVO" Then
                rdoActivo.Checked = True
            Else
                rdoInactivo.Checked = True
                cmbTipoCortador.Enabled = False
            End If
            If tipoCortador = "CORTADOR PIEL" Then
                cmbTipoCortador.Text = "CORTADOR PIEL"
            ElseIf tipoCortador = "CORTADOR FORRO" Then
                cmbTipoCortador.Text = "CORTADOR FORRO"
            ElseIf tipoCortador = "CORTADOR FORRO SINTETICO" Then
                cmbTipoCortador.Text = "CORTADOR FORRO SINTETICO"
            ElseIf tipoCortador = "CORTADOR PIEL SINTETICO" Then
                cmbTipoCortador.Text = "CORTADOR PIEL SINTETICO"
            End If
            btnBuscarEmpleado.Enabled = False
        End If
        lblNaveid.Text = nave

    End Sub

    Public Sub llenarComboTipoCortador()
        Dim obj As New catalagosBU
        Dim lst As New DataTable
        lst = obj.getTiposCortadores()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbTipoCortador.DataSource = lst
            cmbTipoCortador.DisplayMember = "tcor_descripcion"
            cmbTipoCortador.ValueMember = "tcor_tipocortadorid"
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar1_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleado.Click
        Dim form As New listaColaboradoresForm
        Dim obj As New catalagosBU
        Dim tablas As New DataTable

        form.nave = nave
        form.ShowDialog()
        txtNombre.Text = form.colaborador
        lblIdColaborador.Text = form.idColaborador
        txtNombreCorto.Text = form.nombreCorto
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarCampos() = True Then
            If txtNombre.TextLength > 0 And cmbTipoCortador.Text <> "" And lblIdColaborador.Text <> "-" Then
                If lblIdText.Text = "" Then
                    objConfirmacion.mensaje = "¿Está seguro de realizar el registro?"
                    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If buscarCortadorRepetido() = True Then
                            objMensaje.mensaje = "Ya hay un registro del colaborador para el mismo tipo de cortador"
                            objMensaje.ShowDialog()
                        Else
                            GuardarCortador()
                        End If
                    End If
                Else
                    objConfirmacion.mensaje = "¿Está seguro de realizar el cambio?"
                    If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ModificaCortador()
                    End If
                End If
            End If
        Else
            objMensaje.mensaje = "Favor de llenar todos los campos"
            objMensaje.ShowDialog()
        End If


    End Sub

    Public Function validarCampos()
        Dim contador = 0
        'lblNave.ForeColor = Drawing.Color.Red
        If txtNombre.Text = "" Then
            lblNombre.ForeColor = Drawing.Color.Red
            contador = contador + 1
        Else
            lblNombre.ForeColor = Drawing.Color.Black
        End If
        'If txtNombreCorto.Text = "" Then
        '    lblNombreCorto.ForeColor = Drawing.Color.Red
        '    contador = contador + 1
        'Else
        '    lblNombreCorto.ForeColor = Drawing.Color.Black
        'End If
        If cmbTipoCortador.Text = "" Then
            lblTipoCortador.ForeColor = Drawing.Color.Red
            contador = contador + 1
        Else
            lblTipoCortador.ForeColor = Drawing.Color.Black
        End If

        If contador > 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub GuardarCortador()
        Dim cortador As New CortadoresPielForro
        Dim objbu As New ProduccionBU

        cortador.copf_colaboradorid = lblIdColaborador.Text
        cortador.copf_naveid = nave
        cortador.copf_tipocortador = cmbTipoCortador.SelectedValue
        If rdoActivo.Checked = True Then
            cortador.copf_estatus = 1
        Else
            cortador.copf_estatus = 0
        End If
        cortador.copf_usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objbu.AltaCortador(cortador)
        objExito.mensaje = "Cortador registado con éxito."
        objExito.ShowDialog()
        accion = 1
        'Me.Close()
    End Sub

    Public Sub ModificaCortador()
        Dim cortador As New CortadoresPielForro
        Dim objbu As New ProduccionBU

        'objConfirmacion.mensaje = "¿Está seguro de realizar el cambio al registro?"
        'If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
        cortador.copf_cortadorPielForro = lblIdText.Text
        cortador.copf_tipocortador = cmbTipoCortador.SelectedValue
        If rdoActivo.Checked = True Then
            cortador.copf_estatus = 1
        Else
            cortador.copf_estatus = 0
        End If
        cortador.copf_usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objbu.ModificaCortador(cortador)
        objExito.mensaje = "Cortador modificado con éxito"
        objExito.ShowDialog()
        Me.Close()
        'End If

    End Sub

    Public Function buscarCortadorRepetido()
        Dim obj As New ProduccionBU
        Dim tablas As New DataTable
        tablas = obj.buscarCortadorRepetido(lblIdColaborador.Text, cmbTipoCortador.SelectedValue)

        If tablas.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function


    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        If accion = 0 Then
            rdoActivo.Checked = True
        End If
        If rdoInactivo.Checked Then
            cmbTipoCortador.Enabled = False
        End If
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        If rdoActivo.Checked Then
            cmbTipoCortador.Enabled = True
        End If

    End Sub
End Class