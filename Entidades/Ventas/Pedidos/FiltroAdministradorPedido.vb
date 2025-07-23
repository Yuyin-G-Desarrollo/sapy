Public Class FiltroAdministradorPedido
    Private _tipoFecha As Integer = 0
    Private _fechaInicio As Date = Date.Now
    Private _fechaFin As Date = Date.Now
    Private _mostrarPartidas As Boolean = False
    Private _estatusPedido As String = String.Empty
    Private _pedidoSAY As String = String.Empty
    Private _pedidoSICY As String = String.Empty
    Private _cliente As String = String.Empty
    Private _atnCliente As String = String.Empty
    Private _agenteVentas As String = String.Empty
    Private _modelo As String = String.Empty
    Private _color As String = String.Empty
    Private _corrida As String = String.Empty
    Private _piel As String = String.Empty
    Private _marca As String = String.Empty
    Private _coleccion As String = String.Empty
    Private _cedis As Integer = 0

    Public Property CEDIS As Integer
        Get
            Return _cedis
        End Get
        Set(value As Integer)
            _cedis = value
        End Set
    End Property

    Public Property TipoFecha As Integer
        Get
            Return _tipoFecha
        End Get
        Set(value As Integer)
            _tipoFecha = value
        End Set
    End Property


    Public Property FechaInicio As Date
        Get
            Return _fechaInicio
        End Get
        Set(value As Date)
            _fechaInicio = value
        End Set
    End Property

    Public Property FechaFin As Date
        Get
            Return _fechaFin
        End Get
        Set(value As Date)
            _fechaFin = value
        End Set
    End Property

    Public Property MostrarPartidas As Boolean
        Get
            Return _mostrarPartidas
        End Get
        Set(value As Boolean)
            _mostrarPartidas = value
        End Set
    End Property

    Public Property EstatusPedido As String
        Get
            Return _estatusPedido
        End Get
        Set(value As String)
            _estatusPedido = value
        End Set
    End Property

    Public Property PedidoSAY As String
        Get
            Return _pedidoSAY
        End Get
        Set(value As String)
            _pedidoSAY = value
        End Set
    End Property

    Public Property PedidoSICY As String
        Get
            Return _pedidoSICY
        End Get
        Set(value As String)
            _pedidoSICY = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property AtnCliente As String
        Get
            Return _atnCliente
        End Get
        Set(value As String)
            _atnCliente = value
        End Set
    End Property

    Public Property AgenteVentas As String
        Get
            Return _agenteVentas
        End Get
        Set(value As String)
            _agenteVentas = value
        End Set
    End Property

    Public Property Modelo As String
        Get
            Return _modelo
        End Get
        Set(value As String)
            _modelo = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return _color
        End Get
        Set(value As String)
            _color = value
        End Set
    End Property

    Public Property Corrida As String
        Get
            Return _corrida
        End Get
        Set(value As String)
            _corrida = value
        End Set
    End Property

    Public Property Piel As String
        Get
            Return _piel
        End Get
        Set(value As String)
            _piel = value
        End Set
    End Property

    Public Property Marca As String
        Get
            Return _marca
        End Get
        Set(value As String)
            _marca = value
        End Set
    End Property

    Public Property Coleccion As String
        Get
            Return _coleccion
        End Get
        Set(value As String)
            _coleccion = value
        End Set
    End Property
End Class
