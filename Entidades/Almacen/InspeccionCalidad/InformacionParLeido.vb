Public Class InformacionParLeido

    Private _Estatus As Boolean
    Private _InspeccionParID As String
    Private _Lote As String
    Private _NaveID As String
    Private _Nave As String
    Private _Año As String
    Private _MarcaSAY As String
    Private _ColeccionSAY As String
    Private _Color As String
    Private _Piel As String
    Private _Corrida As String
    Private _Talla As String
    Private _Pedido As String
    Private _Atado As String
    Private _NumeroAtado As String
    Private _CodigoPar As String
    Private _Folio As String
    Private _UsuarioId As Integer
    Private _RutaImagenZapato As String
    Private _ClienteSICYID As Integer
    Private _ClienteSAYID As Integer
    Private _NombreCliente As String
    Private _ModeloSAY As String

#Region "Propiedades"
    Public Property ModeloSAY As String
        Get
            Return _ModeloSAY
        End Get
        Set(value As String)
            _ModeloSAY = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return _NombreCliente
        End Get
        Set(value As String)
            _NombreCliente = value
        End Set
    End Property

    Public Property RutaImagenZapato As String
        Get
            Return _RutaImagenZapato
        End Get
        Set(value As String)
            _RutaImagenZapato = value
        End Set
    End Property

    Public Property ClienteSICYID As Integer
        Get
            Return _ClienteSICYID
        End Get
        Set(value As Integer)
            _ClienteSICYID = value
        End Set
    End Property

    Public Property ClienteSAYID As Integer
        Get
            Return _ClienteSAYID
        End Get
        Set(value As Integer)
            _ClienteSAYID = value
        End Set
    End Property

    Public Property CodigoPar As String
        Get
            Return _CodigoPar
        End Get
        Set(value As String)
            _CodigoPar = value
        End Set
    End Property

    Public Property Folio As String
        Get
            Return _Folio
        End Get
        Set(value As String)
            _Folio = value
        End Set
    End Property

    Public Property UsuarioId As Integer
        Get
            Return _UsuarioId
        End Get
        Set(value As Integer)
            _UsuarioId = value
        End Set
    End Property

    Public Property Estatus As Boolean
        Get
            Return _Estatus
        End Get
        Set(value As Boolean)
            _Estatus = value
        End Set
    End Property


    Public Property InspeccionParID As String
        Get
            Return _InspeccionParID
        End Get
        Set(value As String)
            _InspeccionParID = value
        End Set
    End Property


    Public Property Lote As String
        Get
            Return _Lote
        End Get
        Set(value As String)
            _Lote = value
        End Set
    End Property


    Public Property NaveID As String
        Get
            Return _NaveID
        End Get
        Set(value As String)
            _NaveID = value
        End Set
    End Property

    Public Property Nave As String
        Get
            Return _Nave
        End Get
        Set(value As String)
            _Nave = value
        End Set
    End Property

    Public Property Año As String
        Get
            Return _Año
        End Get
        Set(value As String)
            _Año = value
        End Set
    End Property

    Public Property MarcaSAY As String
        Get
            Return _MarcaSAY
        End Get
        Set(value As String)
            _MarcaSAY = value
        End Set
    End Property

    Public Property ColeccionSAY As String
        Get
            Return _ColeccionSAY
        End Get
        Set(value As String)
            _ColeccionSAY = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return _Color
        End Get
        Set(value As String)
            _Color = value
        End Set
    End Property

    Public Property Piel As String
        Get
            Return _Piel
        End Get
        Set(value As String)
            _Piel = value
        End Set
    End Property
    Public Property Pedido As String
        Get
            Return _Pedido
        End Get
        Set(value As String)
            _Pedido = value
        End Set
    End Property

    Public Property Talla As String
        Get
            Return _Talla
        End Get
        Set(value As String)
            _Talla = value
        End Set
    End Property

    Public Property Corrida As String
        Get
            Return _Corrida
        End Get
        Set(value As String)
            _Corrida = value
        End Set
    End Property

    Public Property Atado As String
        Get
            Return _Atado
        End Get
        Set(value As String)
            _Atado = value
        End Set
    End Property

    Public Property NumeroAtado As String
        Get
            Return _NumeroAtado
        End Get
        Set(value As String)
            _NumeroAtado = value
        End Set
    End Property




#End Region

    Public Sub New()
        _Estatus = False
        _InspeccionParID = String.Empty
        _Lote = String.Empty
        _NaveID = String.Empty
        _Nave = String.Empty
        _Año = String.Empty
        _MarcaSAY = String.Empty
        _ColeccionSAY = String.Empty
        _Color = String.Empty
        _Piel = String.Empty
        _Corrida = String.Empty
        _Talla = String.Empty
        _Pedido = String.Empty
        _Atado = String.Empty
        _NumeroAtado = String.Empty
        RutaImagenZapato = String.Empty
        ClienteSICYID = 0
        ClienteSAYID = 0
        NombreCliente = String.Empty
    End Sub

End Class
