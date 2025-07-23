Imports Tools

Public Class AltaCategorias
    Public esAltaCat As Boolean
    Public idCategoria As Int32
    Public activoCat As Boolean
    Public nombreCat As String

    Public Sub cargarCodigoNuevo()
        Dim objCatBU As New Negocios.CategoriasBU
        Dim dtCategoriasIds As New DataTable
        Dim cantCat As Int32 = 0
        dtCategoriasIds = objCatBU.verIdMaxCategorias
        If dtCategoriasIds.Rows(0)(0).ToString = "" Then
            cantCat = 1
        Else
            cantCat = CInt(dtCategoriasIds.Rows(0)(0).ToString) + 1
        End If
        txtCodigo.Text = cantCat.ToString
    End Sub

    Public Function validarInactivarCategoria() As Boolean
        Dim objCatBU As New Negocios.CategoriasBU
        Dim dtCategorias As New DataTable
        dtCategorias = objCatBU.contarRegistrosCategoria(idCategoria)
        Dim contCat As Int32 = CInt(dtCategorias.Rows(0)(0).ToString)
        If contCat > 0 And rdoInactivo.Checked = True Then
            Return False
        End If
        Return True
    End Function

    Public Sub registrarEditarCategoria()
        If validarInactivarCategoria() = True Then
            Dim objCatBU As New Negocios.CategoriasBU
            Dim entidadCat As New Entidades.Categorias
            Dim objConfirmar As New ConfirmarForm
            objConfirmar.mensaje = "¿Esta seguro de guardar los cambios?"
            If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                If esAltaCat = True Then
                    entidadCat.PnombreCategoria = txtDescripcion.Text
                    entidadCat.PactivoCategoria = CBool(rdoActivo.Checked)
                    objCatBU.registrarEditaCategoria(entidadCat, esAltaCat)
                    Dim objMensaje As New ExitoForm
                    objMensaje.mensaje = "El registro se realizó con éxito."
                    objMensaje.ShowDialog()
                    Me.Close()

                ElseIf esAltaCat = False Then
                    entidadCat.PidCategoria = txtCodigo.Text
                    entidadCat.PnombreCategoria = txtDescripcion.Text
                    entidadCat.PactivoCategoria = CBool(rdoActivo.Checked)
                    objCatBU.registrarEditaCategoria(entidadCat, esAltaCat)
                    Dim objMensaje As New ExitoForm
                    objMensaje.mensaje = "El registro se realizó con éxito."
                    objMensaje.ShowDialog()
                    Me.Close()
                End If
            End If
        Else
            MsgBox("La Categoría " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen modelos activos registrados con esta categoría.", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub AltaCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If esAltaCat = True Then
            rdoActivo.Checked = True
            cargarCodigoNuevo()
        ElseIf esAltaCat = False Then

            If activoCat = True Then
                rdoActivo.Checked = True
            Else
                rdoInactivo.Checked = True
            End If

            txtCodigo.Text = idCategoria
            txtDescripcion.Text = nombreCat
        End If

    End Sub

    Public Function validarVaio() As Boolean
        If txtDescripcion.Text = "" Then
            lblDescripcion.ForeColor = Color.Red
            Return False
        Else
            lblDescripcion.ForeColor = Color.Black
        End If
        Return True
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarVaio() = True Then
            registrarEditarCategoria()
        Else
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.mensaje = "Los campos marcados en rojo deben ser completados."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "/" Or caracter = ("-") Or caracter = (".") Or caracter = ("_")) Then
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class