Imports Entidades

Public Class InformacionEmbarque

    Private _folioEmbarque As Integer
    Private _contenido As Integer
    Private _RemitenteID As Integer
    Private _remitente As String
    Private _TiendaID As Integer
    Private _Tienda As String
    Private _Embarco As Integer
    Private _ciudad As String
    Private _EstadoID As Integer
    Private _estado As String
    Private _direccion As String
    Private _colonia As String
    Private _CP As String
    Private _numExt As String
    Private _numInt As String
    Private _fecha As Date
    Private _transporte As Integer
    Private _tipofleje As Integer
    Private _formaPago As String
    Private _Error As ErrorEmbarque
    Private _unidadMedida As Integer
    Private _ciudadID As Integer
    Private _solitalla As Integer
    Private _session As Integer
    Private _solicita As String
    Private _observaciones As String
    Private _Calle As String
    Private _rembarque As Integer
    Private _Consignatarioid As Integer
    Private _Consignatario As String
    Private _descripcionContenido As String
    Private _costoEnvio As Double
    Private _telefono As String
    Private _contacto As String
    Private _lada As String
    Private _paisID As Integer
    Private _especifica As String
    Private _clienteid As Integer
    Private _emisorid As Integer
    Private _rfcClienteID As Integer
    Private _pais As String
    Private _domicilio As String


    Public Property Domicilio As String
        Get
            Return _domicilio
        End Get
        Set(value As String)
            _domicilio = value
        End Set
    End Property


    Public Property Pais As String
        Get
            Return _pais
        End Get
        Set(value As String)
            _pais = value
        End Set
    End Property

    Public Property RFCClienteID As Integer
        Get
            Return _rfcClienteID
        End Get
        Set(value As Integer)
            _rfcClienteID = value
        End Set
    End Property

    Public Property Emisorid As Integer
        Get
            Return _emisorid
        End Get
        Set(value As Integer)
            _emisorid = value
        End Set
    End Property
    Public Property FolioEmbarque As Integer
        Get
            Return _folioEmbarque
        End Get
        Set(value As Integer)
            _folioEmbarque = value
        End Set
    End Property

    Public Property Contenido As Integer
        Get
            Return _contenido
        End Get
        Set(value As Integer)
            _contenido = value
        End Set
    End Property



    Public Property Embarco As Integer
        Get
            Return _Embarco
        End Get
        Set(value As Integer)
            _Embarco = value
        End Set
    End Property

    Public Property Ciudad As String
        Get
            Return _ciudad
        End Get
        Set(value As String)
            _ciudad = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property

    Public Property Colonia As String
        Get
            Return _colonia
        End Get
        Set(value As String)
            _colonia = value
        End Set
    End Property

    Public Property CP As String
        Get
            Return _CP
        End Get
        Set(value As String)
            _CP = value
        End Set
    End Property

    Public Property NumExt As String
        Get
            Return _numExt
        End Get
        Set(value As String)
            _numExt = value
        End Set
    End Property

    Public Property NumInt As String
        Get
            Return _numInt
        End Get
        Set(value As String)
            _numInt = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
        End Set
    End Property

    Public Property Transporte As Integer
        Get
            Return _transporte
        End Get
        Set(value As Integer)
            _transporte = value
        End Set
    End Property

    Public Property Tipofleje As Integer
        Get
            Return _tipofleje
        End Get
        Set(value As Integer)
            _tipofleje = value
        End Set
    End Property



    Public Property [Error] As ErrorEmbarque
        Get
            Return _Error
        End Get
        Set(value As ErrorEmbarque)
            _Error = value
        End Set
    End Property

    Public Property RemitenteID As Integer
        Get
            Return _RemitenteID
        End Get
        Set(value As Integer)
            _RemitenteID = value
        End Set
    End Property

    Public Property Remitente As String
        Get
            Return _remitente
        End Get
        Set(value As String)
            _remitente = value
        End Set
    End Property

    Public Property TiendaID As Integer
        Get
            Return _TiendaID
        End Get
        Set(value As Integer)
            _TiendaID = value
        End Set
    End Property

    Public Property Tienda As String
        Get
            Return _Tienda
        End Get
        Set(value As String)
            _Tienda = value
        End Set
    End Property

    Public Property FormaPago As String
        Get
            Return _formaPago
        End Get
        Set(value As String)
            _formaPago = value
        End Set
    End Property

    Public Property UnidadMedida As Integer
        Get
            Return _unidadMedida
        End Get
        Set(value As Integer)
            _unidadMedida = value
        End Set
    End Property

    Public Property CiudadID As Integer
        Get
            Return _ciudadID
        End Get
        Set(value As Integer)
            _ciudadID = value
        End Set
    End Property

    Public Property Solitalla As Integer
        Get
            Return _solitalla
        End Get
        Set(value As Integer)
            _solitalla = value
        End Set
    End Property

    Public Property Session As Integer
        Get
            Return _session
        End Get
        Set(value As Integer)
            _session = value
        End Set
    End Property

    Public Property Solicita As String
        Get
            Return _solicita
        End Get
        Set(value As String)
            _solicita = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return _observaciones
        End Get
        Set(value As String)
            _observaciones = value
        End Set
    End Property

    Public Property Calle As String
        Get
            Return _Calle
        End Get
        Set(value As String)
            _Calle = value
        End Set
    End Property

    Public Property Rembarque As Integer
        Get
            Return _rembarque
        End Get
        Set(value As Integer)
            _rembarque = value
        End Set
    End Property

    Public Property Consignatarioid As Integer
        Get
            Return _Consignatarioid
        End Get
        Set(value As Integer)
            _Consignatarioid = value
        End Set
    End Property

    Public Property Consignatario As String
        Get
            Return _Consignatario
        End Get
        Set(value As String)
            _Consignatario = value
        End Set
    End Property

    Public Property DescripcionContenido As String
        Get
            Return _descripcionContenido
        End Get
        Set(value As String)
            _descripcionContenido = value
        End Set
    End Property

    Public Property CostoEnvio As Double
        Get
            Return _costoEnvio
        End Get
        Set(value As Double)
            _costoEnvio = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property Lada As String
        Get
            Return _lada
        End Get
        Set(value As String)
            _lada = value
        End Set
    End Property



    Public Property EstadoID As Integer
        Get
            Return _EstadoID
        End Get
        Set(value As Integer)
            _EstadoID = value
        End Set
    End Property

    Public Property PaisID As Integer
        Get
            Return _paisID
        End Get
        Set(value As Integer)
            _paisID = value
        End Set
    End Property

    Public Property Especifica As String
        Get
            Return _especifica
        End Get
        Set(value As String)
            _especifica = value
        End Set
    End Property

    Public Property Contacto As String
        Get
            Return _contacto
        End Get
        Set(value As String)
            _contacto = value
        End Set
    End Property

    Public Property Clienteid As Integer
        Get
            Return _clienteid
        End Get
        Set(value As Integer)
            _clienteid = value
        End Set
    End Property
End Class
