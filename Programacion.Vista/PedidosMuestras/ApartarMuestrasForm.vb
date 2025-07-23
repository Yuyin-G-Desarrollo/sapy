Imports Tools

Public Class ApartarMuestrasForm


    Public Sub New()
        InitializeComponent()
        _EntidadOP = New Entidades.OrdenesProduccionMuestras
    End Sub

    Private _EntidadOP As Entidades.OrdenesProduccionMuestras
    Public Property EntidadOP() As Entidades.OrdenesProduccionMuestras
        Get
            Return _EntidadOP
        End Get
        Set(ByVal value As Entidades.OrdenesProduccionMuestras)
            _EntidadOP = value
        End Set
    End Property


    Public Sub RecibirDatos(ByVal Entidad As Entidades.OrdenesProduccionMuestras)
        txtAutorizado.Text = Entidad.pdetorm_cantsolicitada.ToString
        txtDisponible.Text = Entidad.Disponible
        EntidadOP.pdetorm_pedidoid = Entidad.pdetorm_pedidoid
        EntidadOP.pdetorm_productoestiloid = Entidad.pdetorm_productoestiloid
        EntidadOP.pdetorm_talla = Entidad.pdetorm_talla
        EntidadOP.pdetorm_unidadmedidaid = Entidad.pdetorm_unidadmedidaid
        EntidadOP.EnviarAproducir = Entidad.EnviarAproducir
        EntidadOP.Disponible = Entidad.Disponible
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtApartar.Text.Trim.Length > 0 Then
            If CInt(txtApartar.Text) > EntidadOP.Disponible Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "La cantidad para apartar no puede ser mayor a " + EntidadOP.Disponible.ToString + "."
                mensaje.ShowDialog()
            Else
                Dim objNeg As New Programacion.Negocios.PedidosMuestrasOP
                EntidadOP.Apartados = CInt(txtApartar.Text)
                objNeg.Apartar(EntidadOP)
                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = "El registro se realizó con éxito."
                mensajeExito.ShowDialog()
                Me.Close()
            End If
        Else
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "El campo apartados no contiene texto."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub txtApartar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtApartar.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class