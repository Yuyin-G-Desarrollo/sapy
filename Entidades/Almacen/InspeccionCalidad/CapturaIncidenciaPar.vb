
Public Class CapturaIncidenciaPar
    Private _InformacionPar As New InformacionParLeido

    Private _IncicidenciaID As Integer
    Private _Observaciones As String
    Private _Foto1 As String
    Private _Foto2 As String
    Private _TipoIncidencia As Integer
    Private _InspeccionParID As Integer

#Region "Propiedades"


    Public Property InformacionPar As InformacionParLeido
        Get
            Return _InformacionPar
        End Get
        Set(value As InformacionParLeido)
            _InformacionPar = value
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

    Public Property TipoIncidencia As Integer
        Get
            Return _TipoIncidencia
        End Get
        Set(value As Integer)
            _TipoIncidencia = value
        End Set
    End Property

    Public Property InspeccionParID As Integer
        Get
            Return _InspeccionParID
        End Get
        Set(value As Integer)
            _InspeccionParID = value
        End Set
    End Property

    Public Property IncicidenciaID As Integer
        Get
            Return _IncicidenciaID
        End Get
        Set(value As Integer)
            _IncicidenciaID = value
        End Set
    End Property

#End Region

End Class
