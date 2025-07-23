Public Class MovimientosMuestrasForm_Motivo
    Private _Movimiento As String = String.Empty
    Public Property Movimiento() As String
        Get
            Return _Movimiento
        End Get
        Set(ByVal value As String)
            _Movimiento = value
        End Set
    End Property

    Private _piezas As Int16 = 0
    Public Property Piezas() As Int16
        Get
            Return _piezas
        End Get
        Set(ByVal value As Int16)
            _piezas = value
        End Set
    End Property

    Private _Motivo As String = String.Empty
    Public Property Motivo() As String
        Get
            Return _Motivo
        End Get
        Set(ByVal value As String)
            _Motivo = value
        End Set
    End Property

    Private _Accion As String = String.Empty
    Public Property Accion() As String
        Get
            Return _Accion
        End Get
        Set(ByVal value As String)
            _Accion = value
        End Set
    End Property

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtMotivo.Text.Trim.Length > 0 Then
            _Accion = "GUARDAR"
            _Motivo = txtMotivo.Text.Trim.ToUpper.ToString
            Me.Close()
        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No puede guardar este movimiento sin haber capturado un motivo")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        _Accion = "CERRAR"
        Me.Close()
    End Sub

    Private Sub MovimientosMuestrasForm_Motivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblMovimiento.Text = _Movimiento
        lblPiezas.Text = _piezas.ToString
    End Sub
End Class