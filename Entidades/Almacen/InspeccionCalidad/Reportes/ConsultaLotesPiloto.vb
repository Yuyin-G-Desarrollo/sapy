Public Class ConsultaLotesPiloto
    Private _FolioInspeccion As Integer
    Private _FolioIngreso As Integer
    Private _Lote As Integer
    Private _Nave As String
    Private _Año As Integer
    Private _ParesLote As Integer
    Private _ParesInspeccionadosLote As Integer
    Private _NumeroIncidenciasLote As Integer
    Private _Cliente As String
    Private _ModeloSICY As String
    Private _ModeloSAY As String
    Private _Articulo As String
    Private _CodigoPar As String
    Private _CodigoAtado As String
    Private _Incidencia As String
    Private _FechaRegistroIncidencia As String
    Private _Inspector As String
    Private _IncidenciaMenor As String
    Private _IncidenciaMayor As String
    Private _ParesDeVueltos As Integer
    Private _Observaciones As String

    Public Property FolioInspeccion As Integer
        Get
            Return _FolioInspeccion
        End Get
        Set(value As Integer)
            _FolioInspeccion = value
        End Set
    End Property

    Public Property FolioIngreso As Integer
        Get
            Return _FolioIngreso
        End Get
        Set(value As Integer)
            _FolioIngreso = value
        End Set
    End Property

    Public Property Lote As Integer
        Get
            Return _Lote
        End Get
        Set(value As Integer)
            _Lote = value
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

    Public Property Año As Integer
        Get
            Return _Año
        End Get
        Set(value As Integer)
            _Año = value
        End Set
    End Property

    Public Property ParesLote As Integer
        Get
            Return _ParesLote
        End Get
        Set(value As Integer)
            _ParesLote = value
        End Set
    End Property

    Public Property ParesInspeccionadosLote As Integer
        Get
            Return _ParesInspeccionadosLote
        End Get
        Set(value As Integer)
            _ParesInspeccionadosLote = value
        End Set
    End Property

    Public Property NumeroIncidenciasLote As Integer
        Get
            Return _NumeroIncidenciasLote
        End Get
        Set(value As Integer)
            _NumeroIncidenciasLote = value
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

    Public Property ModeloSICY As String
        Get
            Return _ModeloSICY
        End Get
        Set(value As String)
            _ModeloSICY = value
        End Set
    End Property

    Public Property ModeloSAY As String
        Get
            Return _ModeloSAY
        End Get
        Set(value As String)
            _ModeloSAY = value
        End Set
    End Property

    Public Property Articulo As String
        Get
            Return _Articulo
        End Get
        Set(value As String)
            _Articulo = value
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

    Public Property CodigoAtado As String
        Get
            Return _CodigoAtado
        End Get
        Set(value As String)
            _CodigoAtado = value
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

    Public Property FechaRegistroIncidencia As String
        Get
            Return _FechaRegistroIncidencia
        End Get
        Set(value As String)
            _FechaRegistroIncidencia = value
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



    Public Property Observaciones As String
        Get
            Return _Observaciones
        End Get
        Set(value As String)
            _Observaciones = value
        End Set
    End Property

    Public Property IncidenciaMenor As String
        Get
            Return _IncidenciaMenor
        End Get
        Set(value As String)
            _IncidenciaMenor = value
        End Set
    End Property

    Public Property IncidenciaMayor As String
        Get
            Return _IncidenciaMayor
        End Get
        Set(value As String)
            _IncidenciaMayor = value
        End Set
    End Property

    Public Property ParesDeVueltos As Integer
        Get
            Return _ParesDeVueltos
        End Get
        Set(value As Integer)
            _ParesDeVueltos = value
        End Set
    End Property
End Class
