Imports Tools

Public Class AltaCarritosForm

    Public naveid As Integer
    Public almacenid As String

    Private Sub AltaCarritosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listado_naves()

        listado_Tipo_Carritos()

    End Sub

    Private Sub AltaCarritosForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim caracter As Char = e.KeyChar
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub listado_naves()
        Try
            Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        Catch ex As Exception
        End Try
        If cboxNave.Items.Count = 2 Then
            listado_almacen()
        End If
    End Sub

    Private Sub listado_almacen()
        Try
            Controles.ComboAlmacenSegunNave(cboxAlmacen, CInt(cboxNave.SelectedValue))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub listado_Tipo_Carritos()
        Try
            Controles.ComboTiposCarritos(cboxTipoCarrito)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cboxNave_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboxNave.SelectionChangeCommitted
        listado_almacen()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If String.IsNullOrEmpty(txtDescripcion.Text) Then
            show_message("Aviso", "Debe ingresar una descripción de carrito")

        Else
            Dim carrito As New Entidades.Carrito
            Dim nave As New Entidades.Naves
            Dim almacen As New Entidades.Almacen
            Dim tipocarrito As New Entidades.TipoCarrito

            Dim objBu As New Negocios.ClientesAlmacenBU

            carrito.carritoid = 0
            carrito.descripcion = CStr(txtDescripcion.Text)
            nave.PNaveId = CInt(cboxNave.SelectedValue)
            almacen.almacenid = CStr(cboxAlmacen.Text)
            carrito.nave = nave
            carrito.almacen = almacen
            tipocarrito.tipocarritoid = CInt(cboxTipoCarrito.SelectedValue)
            carrito.tipocarrito = tipocarrito

            Try
                objBu.Alta_Editar_Carrito(carrito)
                show_message("Exito", "Nuevo carrito agregado con éxito")
            Catch ex As Exception
                show_message("Error", "Algo surgió mal durante la operación")
            End Try

            naveid = CInt(cboxNave.SelectedValue)
            almacenid = CStr(cboxAlmacen.Text)
        End If

       

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

End Class