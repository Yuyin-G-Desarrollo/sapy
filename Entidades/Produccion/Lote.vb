Public Class Lote
    Private LoteAño As Int32
    Private LoteNave As Int32
    Private LoteNumero As Int32
    Private LoteFecha As DateTime
    Private LoteFechaEmbarque As DateTime
    Private LoteModelo As String
    Private LoteTalla As String
    Private LoteDepartamentoAvance As String
    Private LoteFechaAvance As DateTime
    Private LoteUsuarioAvance As String
    Private LoteObservacion As String

    Public Property PLoteAño As Int32
        Get
            Return LoteAño
        End Get
        Set(ByVal value As Int32)
            LoteAño = value
        End Set
    End Property

    Public Property PLoteNave As Int32
        Get
            Return LoteNave
        End Get
        Set(ByVal value As Int32)
            LoteNave = value
        End Set
    End Property

    Public Property PLoteNumero As Int32
        Get
            Return LoteNumero
        End Get
        Set(ByVal value As Int32)
            LoteNumero = value
        End Set
    End Property

    Public Property PLoteFecha As DateTime
        Get
            Return LoteFecha
        End Get
        Set(ByVal value As DateTime)
            LoteFecha = value
        End Set
    End Property

    Public Property PLoteFechaEmbarque As DateTime
        Get
            Return LoteFechaEmbarque
        End Get
        Set(ByVal value As DateTime)
            LoteFechaEmbarque = value
        End Set
    End Property

    Public Property PLoteModelo As String
        Get
            Return LoteModelo
        End Get
        Set(ByVal value As String)
            LoteModelo = value
        End Set
    End Property

    Public Property PLoteTalla As String
        Get
            Return LoteTalla
        End Get
        Set(ByVal value As String)
            LoteTalla = value
        End Set
    End Property

    Public Property PLoteDepartamentoAvance As String
        Get
            Return LoteDepartamentoAvance
        End Get
        Set(ByVal value As String)
            LoteDepartamentoAvance = value
        End Set
    End Property

    Public Property PLoteFechaAvance As DateTime
        Get
            Return LoteFechaAvance
        End Get
        Set(ByVal value As DateTime)
            LoteFechaAvance = value
        End Set
    End Property

    Public Property PLoteUsuarioAvance As String
        Get
            Return LoteUsuarioAvance
        End Get
        Set(ByVal value As String)
            LoteUsuarioAvance = value
        End Set
    End Property

    Public Property PLoteObservacion As String
        Get
            Return LoteObservacion
        End Get
        Set(ByVal value As String)
            LoteObservacion = value
        End Set
    End Property

End Class
