Imports Tools
Imports Programacion.Negocios
Imports Entidades
Public Class LicenciasForm
    Public Accion As String

    Public marcaid As Integer
    Public IdLicencia As String
    Public ClaveLiencia As String
    Public CodigoSICY As Integer
    Public Activo As Integer

    Dim idUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    'Dim idUsuario As Integer = 307
    Dim comercializadoraid As Integer = 82

    Private Sub LicenciasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New LicenciasBU
        If Accion = "Alta" Then
            lblTitulo.Text = "Alta de Licencia"
            txtClave.Enabled = True
            rbtActivo.Checked = True
            Dim idcodigoSICY As Integer = obj.ObtenerIdCodigo()
            txtCodigoSICY.Text = idcodigoSICY
        End If
        If Accion = "Editar" Then
            txtClave.Enabled = False
            lblTitulo.Text = "Editar Licencia"
            txtClave.Text = IdLicencia
            txtLicencia.Text = ClaveLiencia
            txtCodigoSICY.Text = CodigoSICY
            If Activo = 0 Then
                rbtInactivo.Checked = True
            Else
                rbtActivo.Checked = True
            End If
        End If
    End Sub

    Private Sub btncCerrar_Click(sender As Object, e As EventArgs) Handles btncCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClave.KeyPress
        If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New LicenciasBU
        Dim tbl As New DataTable

        If Accion = "Alta" Then
            If validarlicenciaClave() = False Then
                Return
            ElseIf ValidarLicenciaNombre() = False Then
                Return
            ElseIf ValidarLicenciaCodigoSICY() = False Then
                Return
            Else
                GuardarRegistro()
            End If
        End If
        If Accion = "Editar" Then
            If ValidaLicenciaNombreEditar() = False Then
                Return
            ElseIf ValidalicenciaCodigoEditar() = False Then
                Return
            Else
                ActualizarRegistro()
            End If

        End If
    End Sub
    Private Function validarlicenciaClave() As Boolean
        Dim validacion As Boolean

        If txtClave.Text.Length < 2 Then
            ErrorClave.SetError(txtClave, "La clave debe contener 2 letras.")
            validacion = False
        ElseIf validaexiste(1, txtClave.Text) = False Then
            ErrorClave.SetError(txtClave, "La clave ya existe.")
            validacion = False
        Else
            ErrorClave.SetError(txtClave, "")
            validacion = True
        End If
        Return validacion
    End Function

    Private Function ValidarLicenciaNombre() As Boolean
        Dim validacion As Boolean
        If txtLicencia.Text.Length = 0 Then
            ErrorLicencia.SetError(txtLicencia, "Ingrese el nombre de la licencia.")
            Validacion = False
        ElseIf validaexiste(2, txtLicencia.Text) = False Then
            ErrorLicencia.SetError(txtLicencia, "La licencia ya existe.")
            Validacion = False
        Else
            ErrorLicencia.SetError(txtLicencia, "")
            Validacion = True
        End If
        Return validacion
    End Function

    Private Function ValidarLicenciaCodigoSICY() As Boolean
        Dim validacion As Boolean
        If txtCodigoSICY.Text.Length = 0 Then
            ErrorCodigoSICY.SetError(txtCodigoSICY, "Ingrese el código sicy.")
            Validacion = False
        ElseIf validaexiste(3, txtCodigoSICY.Text) = False Then
            ErrorCodigoSICY.SetError(txtCodigoSICY, "El código ya existe.")
            validacion = False
        Else
            ErrorCodigoSICY.SetError(txtCodigoSICY, "")
            Validacion = True
        End If
        Return validacion
    End Function

    Private Function validaexiste(ByVal opcion As Integer, ByVal Palabra As String) As Boolean
        Dim obj As New LicenciasBU
        Dim valida As Boolean
        Dim tblRes = New DataTable
        Dim existe As Integer

        Select Case opcion
            Case 1
                tblRes = obj.validarClaveLicencia(Palabra)
                existe = tblRes.Rows(0).Item("Existe")
                If existe = 1 Then
                    valida = False
                Else
                    valida = True
                End If
            Case 2
                tblRes = obj.validarNombreLicencia(Palabra)
                existe = tblRes.Rows(0).Item("Existe")
                If existe = 1 Then
                    valida = False
                Else
                    valida = True
                End If
            Case 3
                tblRes = obj.validarCodigoSICYLicencia(Palabra)
                existe = tblRes.Rows(0).Item("Existe")
                If existe = 1 Then
                    valida = False
                Else
                    valida = True
                End If
        End Select
        Return valida
    End Function

    Private Function ArticuloActivo() As Integer
        If rbtActivo.Checked Then
            Activo = 1
        End If
        If rbtInactivo.Checked Then
            Activo = 0
        End If
        Return Activo
    End Function

    Private Sub GuardarRegistro()
        Dim obj As New LicenciasBU
        Try
            Activo = ArticuloActivo()
            obj.GuardarAltaLicencia(txtLicencia.Text, txtCodigoSICY.Text, Activo, idUsuario, txtClave.Text, comercializadoraid)
            Tools.MostrarMensaje(Mensajes.Success, "Se ha registrado correctamente.")
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub ActualizarRegistro()
        Dim obj As New LicenciasBU
        Try
            Activo = ArticuloActivo()
            obj.GuardarEditarLicencia(marcaid, txtLicencia.Text, txtCodigoSICY.Text, Activo, idUsuario)
            Tools.MostrarMensaje(Mensajes.Success, "Se han realizado los cambios correctamente.")
        Catch ex As Exception
        Finally
            Me.Close()
        End Try
    End Sub

    Private Function ValidaLicenciaNombreEditar() As Boolean
        Dim obj As New LicenciasBU
        Dim valida As Boolean
        Dim tbl As New DataTable
        tbl = obj.validarNombreLicenciaEditar(txtLicencia.Text, marcaid)
        Dim existeNombre As Integer = tbl.Rows(0).Item("Existe")
        If existeNombre = 1 Then
            ErrorLicencia.SetError(txtLicencia, "La licencia ya existe.")
            valida = False
        Else
            ErrorLicencia.SetError(txtLicencia, "")
            valida = True
        End If
        Return valida
    End Function

    Public Function ValidaLicenciaCodigoEditar() As Boolean
        Dim obj As New LicenciasBU
        Dim valida As Boolean
        Dim tbl As New DataTable
        tbl = obj.validarCodigoLicenciaEditar(txtCodigoSICY.Text, marcaid)
        Dim existeCodigo As Integer = tbl.Rows(0).Item("Existe")
        If existeCodigo = 1 Then
            ErrorCodigoSICY.SetError(txtCodigoSICY, "El código ya existe.")
            valida = False
        Else
            ErrorCodigoSICY.SetError(txtCodigoSICY, "")
             valida = True
        End If
        Return valida
    End Function

End Class