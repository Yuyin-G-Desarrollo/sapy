Public Class infoFolioDevolucion

    Private _DevolucionNaveID As Integer
    Private _NaveID As Integer
    Private _Nave As String
    Private _FechaCaptura As Date
    Private _Colaborador As String
    Private _FechaEstimadaRegreso As Date
    Private _FechaRegreso As Date
    Private _CantidadDevuelta As Integer
    Private _CantidadRegreso As Integer
    Private _CantidadPendiente As Integer
    Private _FechaCancelacion As Date
    Private _MotivoCancelacion As String
    Private _ColaboradorRecibio As String
    Private _Status As String
    Private _FolioSalidaID As Integer
    Private _FolioInspeccionID As Integer
    Private _Tratamiento As String

#Region "Propiedades"
    Public Property DevolucionNaveID As Integer
        Get
            Return _DevolucionNaveID
        End Get
        Set(value As Integer)
            _DevolucionNaveID = value
        End Set
    End Property

    Public Property NaveID As Integer
        Get
            Return _NaveID
        End Get
        Set(value As Integer)
            _NaveID = value
        End Set
    End Property

    Public Property FechaCaptura As Date
        Get
            Return _FechaCaptura
        End Get
        Set(value As Date)
            _FechaCaptura = value
        End Set
    End Property

    Public Property Colaborador As String
        Get
            Return _Colaborador
        End Get
        Set(value As String)
            _Colaborador = value
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


    Public Property FechaEstimadaRegreso As Date
        Get
            Return _FechaEstimadaRegreso
        End Get
        Set(value As Date)
            _FechaEstimadaRegreso = value
        End Set
    End Property

    Public Property FechaRegreso As Date
        Get
            Return _FechaRegreso
        End Get
        Set(value As Date)
            _FechaRegreso = value
        End Set
    End Property

    Public Property CantidadDevuelta As Integer
        Get
            Return _CantidadDevuelta
        End Get
        Set(value As Integer)
            _CantidadDevuelta = value
        End Set
    End Property

    Public Property CantidadRegreso As Integer
        Get
            Return _CantidadRegreso
        End Get
        Set(value As Integer)
            _CantidadRegreso = value
        End Set
    End Property

    Public Property CantidadPendiente As Integer
        Get
            Return _CantidadPendiente
        End Get
        Set(value As Integer)
            _CantidadPendiente = value
        End Set
    End Property

    Public Property FechaCancelacion As Date
        Get
            Return _FechaCancelacion
        End Get
        Set(value As Date)
            _FechaCancelacion = value
        End Set
    End Property

    Public Property MotivoCancelacion As String
        Get
            Return _MotivoCancelacion
        End Get
        Set(value As String)
            _MotivoCancelacion = value
        End Set
    End Property

    Public Property ColaboradorRecibio As String
        Get
            Return _ColaboradorRecibio
        End Get
        Set(value As String)
            _ColaboradorRecibio = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _Status
        End Get
        Set(value As String)
            _Status = value
        End Set
    End Property

    Public Property FolioSalidaID As Integer
        Get
            Return _FolioSalidaID
        End Get
        Set(value As Integer)
            _FolioSalidaID = value
        End Set
    End Property
    Public Property FolioInspeccionID As Integer
        Get
            Return _FolioInspeccionID
        End Get
        Set(value As Integer)
            _FolioInspeccionID = value
        End Set
    End Property
    Public Property Tratamiento As String
        Get
            Return _Tratamiento
        End Get
        Set(value As String)
            _Tratamiento = value
        End Set
    End Property


#End Region

    Sub New()
        _DevolucionNaveID = 0
        _Nave = String.Empty
        _FechaCaptura = Nothing
        _Colaborador = String.Empty
        _FechaEstimadaRegreso = Nothing
        _FechaRegreso = Nothing
        _CantidadDevuelta = 0
        _CantidadRegreso = 0
        _CantidadPendiente = 0
        _FechaCancelacion = Nothing
        _MotivoCancelacion = String.Empty
        _ColaboradorRecibio = String.Empty
        _Status = String.Empty
        _FolioSalidaID = 0
        _FolioInspeccionID = 0
        _Tratamiento = String.Empty
    End Sub

End Class
