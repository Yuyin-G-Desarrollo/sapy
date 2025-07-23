Public Class DevolucionCliente_EntregaAEmbarques_Form

    Public objDev As New Entidades.DevolucionCliente
    Private Sub DevolucionCliente_EntregaAEmbarques_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFolioDev.Text = objDev.Devolucionclienteid
        lblCliente.Text = objDev.NombreCliente.ToString
        lblCantidad.Text = objDev.Cantidadtotal
        lblUnidad.Text = objDev.Unidad
        txtUsuarioEntrega.Text = objDev.UsuarioPasaEmbarques
        txtUsuarioRecibe.Text = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim negocios As New Negocios.DevolucionClientesBU
        negocios.CambiarEstatusDevolucion(objDev.Devolucionclienteid, 354, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "ALMACÉN")
        Dim ventanaExito As New Tools.ExitoForm
        ventanaExito.mensaje = "Producto recibido en Embarques"
        ventanaExito.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class