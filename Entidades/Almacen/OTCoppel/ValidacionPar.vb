Public Class ValidacionPar
    Private TipoPar As String
    Private IdPar As String
    Private IdDocena As String
    Private IdPartida As Integer
    Private IdPedido As Integer
    Private IDCliente As Integer
    Private IdNave As Integer
    Private IDLote As Integer
    Private EstatusPar As String
    Private Descripcion As String
    Private IdProducto As String
    Private IdTalla As String
    Private Calce As String
    Private Nave As String
    Private Confirmacion As String
    Private Confirmo As String
    Private EntradaAlmacen As String
    Private Año As String

    Public Property PTipoPar As String
        Get
            Return TipoPar
        End Get
        Set(value As String)
            TipoPar = value
        End Set
    End Property

    Public Property PIdPar As String
        Get
            Return IdPar
        End Get
        Set(value As String)
            IdPar = value
        End Set
    End Property

    Public Property PIdDocena As String
        Get
            Return IdDocena
        End Get
        Set(value As String)
            IdDocena = value
        End Set
    End Property

    Public Property PIdPartida As Integer
        Get
            Return IdPartida
        End Get
        Set(value As Integer)
            IdPartida = value
        End Set
    End Property

    Public Property PIdPedido As Integer
        Get
            Return IdPedido
        End Get
        Set(value As Integer)
            IdPedido = value
        End Set
    End Property

    Public Property PIdCliente As Integer
        Get
            Return IDCliente
        End Get
        Set(value As Integer)
            IDCliente = value
        End Set
    End Property

    Public Property PIdNave As Integer
        Get
            Return IdNave
        End Get
        Set(value As Integer)
            IdNave = value
        End Set
    End Property

    Public Property PIdLote As Integer
        Get
            Return IDLote
        End Get
        Set(value As Integer)
            IDLote = value
        End Set
    End Property

    Public Property PEstatusPar As String
        Get
            Return EstatusPar
        End Get
        Set(value As String)
            EstatusPar = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PIdProducto As String
        Get
            Return IdProducto
        End Get
        Set(value As String)
            IdProducto = value
        End Set
    End Property

    Public Property PIdTalla As String
        Get
            Return IdTalla
        End Get
        Set(value As String)
            IdTalla = value
        End Set
    End Property

    Public Property PCalce As String
        Get
            Return Calce
        End Get
        Set(value As String)
            Calce = value
        End Set
    End Property

    Public Property PNave As String
        Get
            Return Nave
        End Get
        Set(value As String)
            Nave = value
        End Set
    End Property

    Public Property PEntradaAlmacen As String
        Get
            Return EntradaAlmacen
        End Get
        Set(value As String)
            EntradaAlmacen = value
        End Set
    End Property

    Public Property PAño As String
        Get
            Return Año
        End Get
        Set(value As String)
            Año = value
        End Set
    End Property

End Class
