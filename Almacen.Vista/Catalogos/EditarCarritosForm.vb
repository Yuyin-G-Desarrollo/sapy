Imports Tools

Public Class EditarCarritosForm

    Public carritoid As Integer
    Public descripcion As String
    Public naveid As Integer
    Public almacenid As String
    Public tipocarritoid As Integer
    Public estatus As Boolean


    Private Sub EditarCarritosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listado_naves()
        cboxNave.SelectedValue = naveid
        txtDescripcion.Text = descripcion
        listado_almacen()
        cboxAlmacen.Text = almacenid
        listado_Tipo_Carritos()
        cboxTipoCarrito.SelectedValue = tipocarritoid

        If estatus Then
            rbtnEstatusActivo.Checked = True
            rbtnEstatusInactivo.Checked = False
        Else
            rbtnEstatusActivo.Checked = False
            rbtnEstatusInactivo.Checked = True
        End If

    End Sub

    Private Sub EditarCarritosForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

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
        If cboxNave.SelectedIndex > 0 Then
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
            Return
        End If

        Dim carrito As New Entidades.Carrito
        Dim nave As New Entidades.Naves
        Dim almacen As New Entidades.Almacen
        Dim tipocarrito As New Entidades.TipoCarrito

        Dim objBu As New Negocios.ClientesAlmacenBU

        carrito.carritoid = carritoid
        carrito.descripcion = CStr(txtDescripcion.Text)
        nave.PNaveId = CInt(cboxNave.SelectedValue)
        naveid = CInt(cboxNave.SelectedValue)
        almacen.almacenid = CStr(cboxAlmacen.Text)
        carrito.nave = nave
        carrito.almacen = almacen
        tipocarrito.tipocarritoid = CInt(cboxTipoCarrito.SelectedValue)
        carrito.tipocarrito = tipocarrito
        carrito.activo = CBool(rbtnEstatusActivo.Checked)

        Try
            objBu.Alta_Editar_Carrito(carrito)
            show_message("Exito", "Carrito actualizado con éxito")
        Catch ex As Exception
            show_message("Error", "Algo surgió mal durante la operación")
        End Try


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