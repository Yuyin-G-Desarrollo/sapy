Public Class AgregarDescripcionFiniquitoForm
    Private idFiniquito As Int32
    Public Property PidFiniquito As Int32
        Get
            Return idFiniquito
        End Get
        Set(value As Int32)
            idFiniquito = value
        End Set
    End Property


    Private Sub AgregarDescripcionFiniquitoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objbu As New Negocios.FiniquitosBU
        Dim entidad As New Entidades.Finiquitos
        entidad = objbu.SolicitudFiniquito(idFiniquito)
        txtDescripcionFiniquito.Text = entidad.PJustificacion
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtDescripcionFiniquito.Text.Length > 0 Then
            Dim objbu As New Negocios.FiniquitosBU
            'objbu.AgregarAnotacion(idFiniquito, txtDescripcionFiniquito.Text)
            Me.Close()
        End If

    End Sub

    Private Sub AgregarDescripcionFiniquitoForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If

    End Sub
End Class