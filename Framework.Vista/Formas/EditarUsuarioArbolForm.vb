Public Class EditarUsuarioArbolForm
    Public idUsuario As Int32
    Private nombreUsuario As String
    Private contrasena As String
    Private nombreReal As String
    Private email As String
    Private activo As Boolean
    Private sicy As String

    Public colaboradorId As String
    Public colaboradorNombre As String

    Public Sub guardarDatos()
        Dim objNaveUsuario As New Framework.Negocios.NavesUsuarioBU
        Dim entNavUser As New Entidades.NavesUsuario
        Dim objPerfUsuario As New Framework.Negocios.PerfilesUsuarioBU
        Dim entPerfUser As New Entidades.PerfilesUsuario

        Dim objUsuerBu As New Framework.Negocios.UsuariosBU
        Dim entUsuario As New Entidades.Usuarios
        entUsuario.PUserUsername = txtUsername.Text
        entUsuario.PUserNombreReal = txtNombre.Text
        entUsuario.PUserMd5 = txtContrasena.Text
        entUsuario.PUserEmail = txtEmail.Text
        entUsuario.PUserActive = CBool(rdoActivo.Checked)
        entUsuario.PUsuariosSicy = txtSicy.Text
        entUsuario.PUserUsuarioid = idUsuario
        If (colaboradorId <> "") Then
            entUsuario.PIDColaboradorUser = CInt(colaboradorId)
        Else
            entUsuario.PIDColaboradorUser = 0
        End If

        objUsuerBu.editarUsuario(entUsuario)
        objUsuerBu.eliminaRegistrosNaveUsuario(CStr(idUsuario))
        objUsuerBu.eliminaRegistrosPerfilUsuario(CStr(idUsuario))

        For Each rowPerf As DataGridViewRow In grdPerfiles.Rows
            If (CBool(rowPerf.Cells(0).Value) = True) Then
                'MsgBox("id Perfil " + rowPerf.Cells(1).Value.ToString + " Nombre " + rowPerf.Cells(2).Value.ToString)
                Dim perfU As New Entidades.Perfiles
                Dim userP As New Entidades.Usuarios

                userP.PUserUsuarioid = idUsuario
                perfU.Pperfilid = CInt(rowPerf.Cells(1).Value.ToString)

                entPerfUser.PPerfil = perfU
                entPerfUser.PUsuario = userP

                objPerfUsuario.Altas(entPerfUser)
            End If
        Next

        For Each rowNave As DataGridViewRow In grdNaves.Rows
            If (CBool(rowNave.Cells(0).Value) = True) Then
                'MsgBox("id Nave " + rowNave.Cells(1).Value.ToString + " Nombre " + rowNave.Cells(2).Value.ToString)

                Dim navU As New Entidades.Naves
                Dim userN As New Entidades.Usuarios

                navU.PNaveId = CInt(rowNave.Cells(1).Value.ToString)
                userN.PUserUsuarioid = idUsuario

                entNavUser.PUsuariosID = userN
                entNavUser.NavesID = navU

                objNaveUsuario.guardar(entNavUser)
            End If
        Next

    End Sub

    Public Sub verDatosDelUsuario()
        Dim objUser As New Framework.Negocios.UsuariosBU
        Dim objModulos As New Framework.Negocios.ModulosBU

        Dim dtDatosUsuario As New DataTable
        dtDatosUsuario = objUser.verDatosUsuarioRegistro(CStr(idUsuario))

        nombreUsuario = dtDatosUsuario.Rows(0)(1).ToString
        contrasena = dtDatosUsuario.Rows(0)(2).ToString
        activo = CBool(dtDatosUsuario.Rows(0)(3).ToString)
        nombreReal = dtDatosUsuario.Rows(0)(4).ToString
        email = dtDatosUsuario.Rows(0)(5).ToString
        sicy = dtDatosUsuario.Rows(0)(6).ToString
        colaboradorId = dtDatosUsuario.Rows(0)(7).ToString

        txtUsername.Text = nombreUsuario
        'txtContrasena.Text = ""
        'txtconfirmarContrasena.Text = ""

        If (activo = True) Then
            rdoActivo.Checked = True
        Else
            rdoInactivo.Checked = True
        End If
        txtNombre.Text = nombreReal
        txtEmail.Text = email
        txtSicy.Text = sicy
        If (colaboradorId <> "") Then
            Dim dtDatoColaborador As New DataTable
            dtDatoColaborador = objModulos.verColaboradorUnico(colaboradorId)
            lblnombreColaborador.Text = dtDatoColaborador.Rows(0)(1).ToString
            lblIdColaborador.Text = colaboradorId
        End If

    End Sub

    Public Sub llenarTablaNaves()
        Dim objNav As New Framework.Negocios.NavesBU
        Dim dtDatosNaves As New DataTable
        dtDatosNaves = objNav.listaNaves
        grdNaves.DataSource = dtDatosNaves
        With grdNaves
            .Columns(1).Visible = False
            .Columns(2).ReadOnly = True
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(0).Width = 50
            .Columns(2).HeaderText = "Nave"
        End With
    End Sub


    Public Sub llenarTablaPerfiles()
        Dim objPerf As New Framework.Negocios.PerfilesBU
        Dim dtDatosPerfiles As New DataTable
        dtDatosPerfiles = objPerf.VerPerfiles

        With grdPerfiles
            .DataSource = dtDatosPerfiles
            .Columns(1).Visible = False
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(0).Width = 50
            .Columns(1).Width = 50
            .Columns(2).HeaderText = "Perfil"
        End With
    End Sub

    Public Sub marcarRegistros()
        Dim objUser As New Framework.Negocios.UsuariosBU
        Dim dtDatosRegistroNave As New DataTable
        Dim dtDatosRegistroPerfil As New DataTable

        dtDatosRegistroNave = objUser.verRegistrosNavesUsuario(CStr(idUsuario))
        dtDatosRegistroPerfil = objUser.verRegistrosPerfilUsuario(CStr(idUsuario))

        For Each rowNave As DataGridViewRow In grdNaves.Rows
            For Each rowNaveDt As DataRow In dtDatosRegistroNave.Rows
                If (rowNave.Cells(1).Value.ToString = rowNaveDt.Item(0).ToString) Then
                    rowNave.Cells(0).Value = True
                End If
            Next
        Next


        For Each rowPerfil As DataGridViewRow In grdPerfiles.Rows
            For Each rowPerfilDT As DataRow In dtDatosRegistroPerfil.Rows
                If (rowPerfil.Cells(1).Value.ToString = rowPerfilDT.Item(0).ToString) Then
                    rowPerfil.Cells(0).Value = True
                End If
            Next
        Next

    End Sub

    Private Sub EditarUsuarioArbolForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        grdNaves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdPerfiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdNaves.AllowUserToAddRows = False
        grdPerfiles.AllowUserToAddRows = False

        llenarTablaNaves()
        llenarTablaPerfiles()
        marcarRegistros()
        verDatosDelUsuario()

    End Sub

    Public Function validarVacios() As Boolean
        If (txtUsername.Text = Nothing Or txtEmail.Text = Nothing Or txtNombre.Text = Nothing) Then
            If (txtUsername.Text = Nothing) Then
                lblUsuario.ForeColor = Color.Red
            Else
                lblUsuario.ForeColor = Color.Black
            End If
            If (txtEmail.Text = Nothing) Then
                lblEmail.ForeColor = Color.Red
            Else
                lblEmail.ForeColor = Color.Black
            End If
            If (txtNombre.Text = Nothing) Then
                lblNombre.ForeColor = Color.Red
            Else
                lblNombre.ForeColor = Color.Black
            End If
            Return False

        Else
            lblUsuario.ForeColor = Color.Black
            lblEmail.ForeColor = Color.Black
            lblNombre.ForeColor = Color.Black
        End If
        Return True
    End Function

    Public Function verificarContrasena() As Boolean
        If (txtContrasena.Text <> Nothing And txtconfirmarContrasena.Text <> Nothing) Then
            If (txtContrasena.Text <> txtconfirmarContrasena.Text) Then
                Return False
            End If
        End If
        Return True
    End Function

    Public Function validaNaveSeleccion() As Boolean
        Dim contNavs As Int32 = 0

        For Each rowN As DataGridViewRow In grdNaves.Rows
            If (rowN.Cells(0).Value IsNot Nothing) Then
                If (CBool(rowN.Cells(0).Value.ToString) = True) Then
                    contNavs = contNavs + 1
                End If
            End If
        Next
        If (contNavs = 0) Then
            Return False
        End If
        Return True
    End Function

    Public Function validaPerfilSeleccion() As Boolean
        Dim contPerf As Int32 = 0
        Dim recorre As Int32 = 0
        For Each rowP As DataGridViewRow In grdPerfiles.Rows
            If (rowP.Cells(0).Value IsNot Nothing) Then
                If (CBool(rowP.Cells(0).Value.ToString) = True) Then
                    contPerf = contPerf + 1
                End If
            End If
        Next
        If (contPerf = 0) Then
            Return False
        End If
        Return True
    End Function


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validarVacios() = True) Then

            If (verificarContrasena() = True) Then

                If (validaPerfilSeleccion() = True) Then

                    If (validaNaveSeleccion() = True) Then

                        If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                            guardarDatos()
                            Me.Close()
                        End If

                    Else
                        MsgBox("Debe seleccionar al menos una nave.")
                    End If

                Else
                    MsgBox("Debe seleccionar al menos un perfil.")
                End If

            Else
                MsgBox("Debe confirmar la contraseña.")
            End If

        Else
            MsgBox("Debe completar los datos obligatorios.")
        End If
    End Sub

    Private Sub txtContrasena_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContrasena.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtContrasena.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtContrasena.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtContrasena_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContrasena.LostFocus
        If (txtUsername.Text.Length > 0) Then
            If (txtContrasena.Text = txtUsername.Text) Then
                MsgBox("Por seguridad la contraseña debe ser diferente al usuario.")
            End If
        End If
    End Sub

    Private Sub txtContrasena_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContrasena.TextChanged
        If (txtconfirmarContrasena.Text.Length = 0) Then
            lblErrorContrasena.Visible = True
        Else
            If (txtconfirmarContrasena.Text.Length > 0) Then
                If (txtContrasena.Text <> txtconfirmarContrasena.Text) Then
                    lblErrorContrasena.Visible = True
                End If
            Else
                lblErrorContrasena.Visible = False
            End If
        End If

        If (txtContrasena.Text.Length = 0 And txtconfirmarContrasena.Text.Length = 0) Then
            lblErrorContrasena.Visible = False
        End If
        If (txtContrasena.Text = txtconfirmarContrasena.Text) Then
            lblErrorContrasena.Visible = False
        End If
    End Sub

    Private Sub txtconfirmarContrasena_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtconfirmarContrasena.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtconfirmarContrasena.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtconfirmarContrasena.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtconfirmarContrasena_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtconfirmarContrasena.TextChanged
        If (txtconfirmarContrasena.Text.Length = 0) Then
            lblErrorContrasena.Visible = True
        Else
            If (txtContrasena.Text.Length > 0) Then
                If (txtContrasena.Text <> txtconfirmarContrasena.Text) Then
                    lblErrorContrasena.Visible = True
                Else
                    lblErrorContrasena.Visible = False
                End If
            End If
        End If

        If (txtContrasena.Text.Length = 0 And txtconfirmarContrasena.Text.Length = 0) Then
            lblErrorContrasena.Visible = False
        ElseIf (txtconfirmarContrasena.Text.Length > 0 And txtContrasena.Text.Length = 0) Then
            lblErrorContrasena.Visible = True
        End If
    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtEmail.Text.Length < 100) Then

            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = "." Or caracter = "_" Or caracter = "/" Or caracter = "@" Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEmail_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.LostFocus
        Dim tam As Int32 = 0
        Dim cadena As String = txtEmail.Text
        Dim contadoraroba As Int32 = 0
        Dim contadorpunto As Int32 = 0
        If (txtEmail.Text.Length > 0) Then
            For tam = 0 To Len(cadena) - 1
                If (cadena.Chars(tam) = "@") Then
                    contadoraroba = contadoraroba + 1
                End If
                If (cadena.Chars(tam) = ".") Then
                    contadorpunto = contadorpunto + 1
                End If
            Next

            If (contadoraroba = 0 Or contadorpunto = 0) Then
                MsgBox("Verifique que el e-mail que ingreso sea correcto.")
            End If
        End If
    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombre.Text.Length < 100) Then

            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = Chr(Keys.Space) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtSicy.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = Chr(Keys.Space) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtUsername.Text.Length < 100) Then

            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = Chr(Keys.Space) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtUsername_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.LostFocus
        If (txtContrasena.Text.Length > 0) Then
            If (txtUsername.Text = txtContrasena.Text) Then
                MsgBox("Por seguridad el usuario debe ser diferente a la contraseña.")
            End If
        End If
    End Sub

    Private Sub btnColaborador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColaborador.Click
        Dim objColForm As New seleccionColaboradoForm
        objColForm.ShowDialog()

        lblIdColaborador.Text = objColForm.PidColaborador

        lblnombreColaborador.Text = objColForm.PnombeColaborador
        colaboradorNombre = objColForm.PnombeColaborador
        colaboradorId = objColForm.PidColaborador
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class