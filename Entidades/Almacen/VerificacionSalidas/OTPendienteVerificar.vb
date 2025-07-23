Public Class OTPendienteVerificar

    Dim _Seleccionar As Boolean = False
    Dim _OT As Integer = 0
    Dim _Cliente As String = String.Empty
    Dim _PedidoSAY As Integer = 0
    Dim _PedidoSICY As Integer = 0
    Dim _TotalPares As Integer = 0
    Dim _TotalConfirmados As Integer = 0

#Region "Propiedades"

    Public Property Seleccionar As Boolean
        Get
            Return _Seleccionar
        End Get
        Set(value As Boolean)
            _Seleccionar = value
        End Set
    End Property

    Public Property OT As Integer
        Get
            Return _OT
        End Get
        Set(value As Integer)
            _OT = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(value As String)
            _Cliente = value
        End Set
    End Property

    Public Property PedidoSAY As Integer
        Get
            Return _PedidoSAY
        End Get
        Set(value As Integer)
            _PedidoSAY = value
        End Set
    End Property

    Public Property PedidoSICY As Integer
        Get
            Return _PedidoSICY
        End Get
        Set(value As Integer)
            _PedidoSICY = value
        End Set
    End Property

    Public Property TotalPares As Integer
        Get
            Return _TotalPares
        End Get
        Set(value As Integer)
            _TotalPares = value
        End Set
    End Property

    Public Property TotalConfirmados As Integer
        Get
            Return _TotalConfirmados
        End Get
        Set(value As Integer)
            _TotalConfirmados = value
        End Set
    End Property

#End Region



End Class
