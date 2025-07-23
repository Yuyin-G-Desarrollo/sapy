Imports Tools
Public Class DocumentosExtranjeros_Paridad_Form


    Private objBU As New Negocios.AdministradorOTFacturacionBU
    Public OrdenesTrabajo As String
    Public paridad As Double = 1
    Public Avanzar As Boolean

    Private _entCliente As Entidades.Cliente
    Public Property entCliente() As Entidades.Cliente
        Get
            Return _entCliente
        End Get
        Set(ByVal value As Entidades.Cliente)
            _entCliente = value
        End Set
    End Property


    Private Sub DocumentosExtranjeros_Paridad_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCliente.Text = _entCliente.nombregenerico
        lblOts.Text = OrdenesTrabajo
        lblMoneda.Text = _entCliente.Moneda.nombre

    End Sub

    Public Sub ObtenerInfomracionCliente(ClienteID As Integer)
        Try
            _entCliente = objBU.ObtenerInfomracionCliente(ClienteID)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Avanzar = False
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not txtParidad.MaskCompleted Then
            show_message("Advertencia", "No se ha ingresado la paridad correctamente.")
            Avanzar = False
            Return
        End If

        paridad = CDbl(txtParidad.Text)
        Avanzar = True
        Me.Close()

    End Sub
End Class