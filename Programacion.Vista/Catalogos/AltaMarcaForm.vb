Imports Tools

Public Class AltaMarcaForm
    Dim dtidMarca As DataTable
    Dim IdUsuarioCreo As Int32

    ' ''metodo que genera un codigo nuevo dependiendo del id o si se a llegado al limite la asignacion de un codigo que se encuentre inactivo
    Public Sub GenerarClave()
        Try

            Dim MarcaNegocios As New Programacion.Negocios.MarcasBU
            Dim dtContadrorFilas As DataTable
            dtContadrorFilas = New DataTable
            'dtidMarca = New DataTable
            'dtidMarca = MarcaNegocios.SeleccionarMaximoId
            dtContadrorFilas = MarcaNegocios.VerMarcas
            Dim ValidacionExistePrimero As Int32 = dtContadrorFilas.Rows.Count
            Dim NuevoCod As Int32 = ValidacionExistePrimero + 1

            Dim codigoNuevo As String = String.Empty
            Dim IdMaximo As Int32 = 0
            Dim IdNuevo As Int32 = 0

            If (ValidacionExistePrimero = 0) Then
                IdNuevo = 1
                codigoNuevo = "1"
                txtCodigo.Text = codigoNuevo
                '    IdMaximo = Convert.ToInt32(dtidMarca.Rows(0)("MaximoID").ToString)
                '    IdNuevo = ValidacionExistePrimero + 1
                'End If
            ElseIf (ValidacionExistePrimero >= 1 And ValidacionExistePrimero < 36) Then
                If (NuevoCod >= 1 And NuevoCod <= 9) Then
                    codigoNuevo = NuevoCod.ToString
                    txtCodigo.Text = codigoNuevo

                ElseIf (NuevoCod > 9) Then

                    If (NuevoCod = 10) Then
                        codigoNuevo = "A"
                    End If
                    If (NuevoCod = 11) Then
                        codigoNuevo = "B"
                    End If
                    If (NuevoCod = 12) Then
                        codigoNuevo = "C"
                    End If
                    If (NuevoCod = 13) Then
                        codigoNuevo = "D"
                    End If
                    If (NuevoCod = 14) Then
                        codigoNuevo = "E"
                    End If
                    If (NuevoCod = 15) Then
                        codigoNuevo = "F"
                    End If
                    If (NuevoCod = 16) Then
                        codigoNuevo = "G"
                    End If
                    If (NuevoCod = 17) Then
                        codigoNuevo = "H"
                    End If
                    If (NuevoCod = 18) Then
                        codigoNuevo = "I"
                    End If
                    If (NuevoCod = 19) Then
                        codigoNuevo = "J"
                    End If
                    If (NuevoCod = 20) Then
                        codigoNuevo = "K"
                    End If
                    If (NuevoCod = 21) Then
                        codigoNuevo = "L"
                    End If
                    If (NuevoCod = 22) Then
                        codigoNuevo = "M"
                    End If
                    If (NuevoCod = 23) Then
                        codigoNuevo = "N"
                    End If
                    If (NuevoCod = 24) Then
                        codigoNuevo = "Ñ"
                    End If
                    If (NuevoCod = 25) Then
                        codigoNuevo = "O"
                    End If
                    If (NuevoCod = 26) Then
                        codigoNuevo = "P"
                    End If
                    If (NuevoCod = 27) Then
                        codigoNuevo = "Q"
                    End If
                    If (NuevoCod = 28) Then
                        codigoNuevo = "R"
                    End If
                    If (NuevoCod = 29) Then
                        codigoNuevo = "S"
                    End If
                    If (NuevoCod = 30) Then
                        codigoNuevo = "T"
                    End If
                    If (NuevoCod = 31) Then
                        codigoNuevo = "U"
                    End If
                    If (NuevoCod = 32) Then
                        codigoNuevo = "V"
                    End If
                    If (NuevoCod = 33) Then
                        codigoNuevo = "W"
                    End If
                    If (NuevoCod = 34) Then
                        codigoNuevo = "X"
                    End If
                    If (NuevoCod = 35) Then
                        codigoNuevo = "Y"
                    End If
                    If (NuevoCod = 36) Then
                        codigoNuevo = "Z"
                    End If
                    txtCodigo.Text = codigoNuevo
                End If
            End If
            If (ValidacionExistePrimero >= 36) Then
                Dim dtCodigosDisponibles As DataTable
                dtCodigosDisponibles = New DataTable
                dtCodigosDisponibles = MarcaNegocios.VerCodigosDisponibles()
                Dim DatoValidacionExistente As String = dtCodigosDisponibles.Rows(0)("marc_codigo").ToString()
                codigoNuevo = DatoValidacionExistente.ToString
                txtCodigo.Text = codigoNuevo
            End If
            Dim objColeBU As New Negocios.ColeccionBU
            txtCodigoSicy.Text = objColeBU.EncontrarColeccionSICY(3)(0)(0)
        Catch ex As Exception
        End Try
    End Sub

    ' ''metodo que realiza el envio de datos a la entidad y realiza el registro de la marca
    Public Sub RegistgroDatos()
        Dim MarcaNegocio As New Programacion.Negocios.MarcasBU
        Dim MarcaEntidad As New Entidades.Marcas
        MarcaEntidad.PCodigo = txtCodigo.Text.Trim
        MarcaEntidad.PDescripcion = txtDescripcion.Text.Trim
        MarcaEntidad.PSicyCodigo = txtCodigoSicy.Text.Trim
        MarcaEntidad.PComercializadora = CInt(cmbCEDIS.SelectedValue)
        If (ckbCliente.Checked = True) Then
            MarcaEntidad.PClienteMarca = True
        ElseIf (ckbCliente.Checked = False) Then
            MarcaEntidad.PClienteMarca = False
        End If
        If (rdoActivo.Checked) Then
            MarcaEntidad.PActivo = True
        ElseIf (rdoInactivo.Checked) Then
            MarcaEntidad.PActivo = False
        End If
        IdUsuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        MarcaNegocio.RegistrarNuevaMarca(MarcaEntidad, IdUsuarioCreo)

    End Sub

    ' ''metodo que valida que no existas campos vacios y le indica al usuario que estos deben ser llenados en caso de no hacerlo.
    Public Function ValidarVacio() As Boolean
        If (txtCodigo.Text.Trim = Nothing Or txtDescripcion.Text.Trim = Nothing) Then
            If (txtCodigo.Text.Trim = Nothing) Then
                lblCodigo.ForeColor = Drawing.Color.Red
            Else
                lblCodigo.ForeColor = Drawing.Color.Black
            End If
            If (txtDescripcion.Text.Trim = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            lblCodigo.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                RegistgroDatos()
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El registro se realizó con éxito."
                mensaje.ShowDialog()
                Me.Close()
            Else
            End If

        ElseIf (ValidarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()

        End If
    End Sub

    Private Sub AltaMarcaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Focus()
        lblCodigo.ForeColor = Drawing.Color.Black
        lblDescripcion.ForeColor = Drawing.Color.Black
        txtDescripcion.Text = String.Empty
        txtCodigoSicy.Text = String.Empty
        rdoActivo.Checked = True
        GenerarClave()
        cmbCEDIS = Utilerias.ComboObtenerCEDIS(cmbCEDIS)
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If

    End Sub

    Private Sub txtCodigoSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigoSicy.Text.Length < 10) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodigoSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub txtCódigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress

    End Sub
End Class