
Public Class ResumenInspeccion

    Private _TipoIncidencia As String
    Private _IncidenciaParID As Integer
    Private _IncidenciaID As Integer
    Private _Cliente As String
    Private _Modelo As String
    Private _Coleccion As String
    Private _lote As Integer
    Private _Foto1 As String
    Private _Foto2 As String
    Private _Incidencia As String
    Private _Rechazo As String
    Private _ParesDevueltos As String
    Private _Inspector As String
    Private _Nave As String
    Private _Accion As String
    Private _EsLotePiloto As Boolean
    Private _LotePiloto As String
    Private _Corrida As String
#Region "Propiedades"

    Public Property Nave As String
        Get
            Return _Nave
        End Get
        Set(value As String)
            _Nave = value
        End Set
    End Property
    Public Property Inspector As String
        Get
            Return _Inspector
        End Get
        Set(value As String)
            _Inspector = value
        End Set
    End Property

    Public Property ParesDevueltos As String
        Get
            Return _ParesDevueltos
        End Get
        Set(value As String)
            _ParesDevueltos = value
        End Set
    End Property

    Public Property Rechazo As String
        Get
            Return _Rechazo
        End Get
        Set(value As String)
            _Rechazo = value
        End Set
    End Property

    Public Property Incidencia As String
        Get
            Return _Incidencia
        End Get
        Set(value As String)
            _Incidencia = value
        End Set
    End Property

    Public Property TipoIncidencia As String
        Get
            Return _TipoIncidencia
        End Get
        Set(value As String)
            _TipoIncidencia = value
        End Set
    End Property

    Public Property IncidenciaParID As Integer
        Get
            Return _IncidenciaParID
        End Get
        Set(value As Integer)
            _IncidenciaParID = value
        End Set
    End Property

    Public Property IncidenciaID As Integer
        Get
            Return _IncidenciaID
        End Get
        Set(value As Integer)
            _IncidenciaID = value
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

    Public Property Modelo As String
        Get
            Return _Modelo
        End Get
        Set(value As String)
            _Modelo = value
        End Set
    End Property

    Public Property Coleccion As String
        Get
            Return _Coleccion
        End Get
        Set(value As String)
            _Coleccion = value
        End Set
    End Property

    Public Property lote As Integer
        Get
            Return _lote
        End Get
        Set(value As Integer)
            _lote = value
        End Set
    End Property

    Public Property Foto1 As String
        Get
            Return _Foto1
        End Get
        Set(value As String)
            _Foto1 = value
        End Set
    End Property

    Public Property Foto2 As String
        Get
            Return _Foto2
        End Get
        Set(value As String)
            _Foto2 = value
        End Set
    End Property

    Public Property Accion As String
        Get
            Return _Accion
        End Get
        Set(value As String)
            _Accion = value
        End Set
    End Property

    Public Property EsLotePiloto As Boolean
        Get
            Return _EsLotePiloto
        End Get
        Set(value As Boolean)
            _EsLotePiloto = value
        End Set
    End Property

    Public Property LotePiloto As String
        Get
            Return _LotePiloto
        End Get
        Set(value As String)
            _LotePiloto = value
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

#End Region





End Class
