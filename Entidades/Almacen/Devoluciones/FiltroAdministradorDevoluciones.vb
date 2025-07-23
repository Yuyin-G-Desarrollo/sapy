Public Class FiltroAdministradorDevoluciones

    Private _tipoDevolucion1 As String
    Private _fechaRegistroInicio1 As Date
    Private _fechaRegistroFin1 As Date
    Private _fechaRecepcionInicio1 As Date
    Private _fechaRecepcionFin1 As Date
    Private _fechaConclusionInicio1 As Date
    Private _fechaConclusionFin1 As Date
    Private _estatus1 As String
    Private _resolucion1 As String
    Private _procede1 As Int16
    Private _folioDev1 As String
    Private _pedidoSAY1 As String
    Private _pedidoSICY1 As String
    Private _documentos1 As String
    Private _añoDocto1 As Int16
    Private _facturaRemision1 As Int16
    Private _idClientes1 As String
    Private _idAgenteVent1 As String
    Private _idAtnClientes1 As String
    Private _marca1 As String
    Private _coleccion1 As String
    Private _modelo1 As String
    Private _piel1 As String
    Private _color1 As String
    Private _corrida1 As String
    Private _vista As String
    Private _Usuario As Integer
    Private _ConNotaC As Integer
    Private _CEDIS As Integer

    Public Sub New()
        _fechaRegistroInicio1 = CDate("01/01/1900")
        _fechaRegistroFin1 = CDate("01/01/1900")
        _fechaRecepcionInicio1 = CDate("01/01/1900")
        _fechaRecepcionFin1 = CDate("01/01/1900")
        _fechaConclusionInicio1 = CDate("01/01/1900")
        _fechaConclusionFin1 = CDate("01/01/1900")
    End Sub

    Public Property CEDIS As Integer
        Get
            Return _CEDIS
        End Get
        Set(value As Integer)
            _CEDIS = value
        End Set
    End Property


    Public Property TipoDevolucion As String
        Get
            Return _tipoDevolucion1
        End Get
        Set(value As String)
            _tipoDevolucion1 = value
        End Set
    End Property

    Public Property FechaRegistroInicio As Date
        Get
            Return _fechaRegistroInicio1
        End Get
        Set(value As Date)
            _fechaRegistroInicio1 = value
        End Set
    End Property

    Public Property FechaRegistroFin As Date
        Get
            Return _fechaRegistroFin1
        End Get
        Set(value As Date)
            _fechaRegistroFin1 = value
        End Set
    End Property

    Public Property FechaRecepcionInicio As Date
        Get
            Return _fechaRecepcionInicio1
        End Get
        Set(value As Date)
            _fechaRecepcionInicio1 = value
        End Set
    End Property

    Public Property FechaRecepcionFin As Date
        Get
            Return _fechaRecepcionFin1
        End Get
        Set(value As Date)
            _fechaRecepcionFin1 = value
        End Set
    End Property

    Public Property FechaConclusionInicio As Date
        Get
            Return _fechaConclusionInicio1
        End Get
        Set(value As Date)
            _fechaConclusionInicio1 = value
        End Set
    End Property

    Public Property FechaConclusionFin As Date
        Get
            Return _fechaConclusionFin1
        End Get
        Set(value As Date)
            _fechaConclusionFin1 = value
        End Set
    End Property

    Public Property Estatus As String
        Get
            Return _estatus1
        End Get
        Set(value As String)
            _estatus1 = value
        End Set
    End Property

    Public Property Resolucion As String
        Get
            Return _resolucion1
        End Get
        Set(value As String)
            _resolucion1 = value
        End Set
    End Property

    Public Property Procede As Short
        Get
            Return _procede1
        End Get
        Set(value As Short)
            _procede1 = value
        End Set
    End Property

    Public Property FolioDev As String
        Get
            Return _folioDev1
        End Get
        Set(value As String)
            _folioDev1 = value
        End Set
    End Property

    Public Property PedidoSAY As String
        Get
            Return _pedidoSAY1
        End Get
        Set(value As String)
            _pedidoSAY1 = value
        End Set
    End Property

    Public Property PedidoSICY As String
        Get
            Return _pedidoSICY1
        End Get
        Set(value As String)
            _pedidoSICY1 = value
        End Set
    End Property

    Public Property Documentos As String
        Get
            Return _documentos1
        End Get
        Set(value As String)
            _documentos1 = value
        End Set
    End Property

    Public Property AñoDocto As Short
        Get
            Return _añoDocto1
        End Get
        Set(value As Short)
            _añoDocto1 = value
        End Set
    End Property

    Public Property FacturaRemision As Short
        Get
            Return _facturaRemision1
        End Get
        Set(value As Short)
            _facturaRemision1 = value
        End Set
    End Property

    Public Property IdClientes As String
        Get
            Return _idClientes1
        End Get
        Set(value As String)
            _idClientes1 = value
        End Set
    End Property

    Public Property IdAgenteVent As String
        Get
            Return _idAgenteVent1
        End Get
        Set(value As String)
            _idAgenteVent1 = value
        End Set
    End Property

    Public Property IdAtnClientes As String
        Get
            Return _idAtnClientes1
        End Get
        Set(value As String)
            _idAtnClientes1 = value
        End Set
    End Property

    Public Property Marca As String
        Get
            Return _marca1
        End Get
        Set(value As String)
            _marca1 = value
        End Set
    End Property

    Public Property Coleccion As String
        Get
            Return _coleccion1
        End Get
        Set(value As String)
            _coleccion1 = value
        End Set
    End Property

    Public Property Modelo As String
        Get
            Return _modelo1
        End Get
        Set(value As String)
            _modelo1 = value
        End Set
    End Property

    Public Property Piel As String
        Get
            Return _piel1
        End Get
        Set(value As String)
            _piel1 = value
        End Set
    End Property

    Public Property Color As String
        Get
            Return _color1
        End Get
        Set(value As String)
            _color1 = value
        End Set
    End Property

    Public Property Corrida As String
        Get
            Return _corrida1
        End Get
        Set(value As String)
            _corrida1 = value
        End Set
    End Property

    Public Property Vista As String
        Get
            Return _vista
        End Get
        Set(value As String)
            _vista = value
        End Set
    End Property

    Public Property Usuario As Integer
        Get
            Return _Usuario
        End Get
        Set(value As Integer)
            _Usuario = value
        End Set
    End Property

    Public Property ConNotaC As Integer
        Get
            Return _ConNotaC
        End Get
        Set(value As Integer)
            _ConNotaC = value
        End Set
    End Property
End Class
