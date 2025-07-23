Public Class Solicitud
    Private _Solicitudid As Integer
    Private _Estatus As String
    Private _IdMotivoInterno As Integer

    Public Property Solicitudid As Integer
        Get
            Return _Solicitudid
        End Get
        Set(value As Integer)
            _Solicitudid = value
        End Set
    End Property



    Public Property IdMotivoInterno As Integer
        Get
            Return _IdMotivoInterno
        End Get
        Set(value As Integer)
            _IdMotivoInterno = value
        End Set
    End Property

    Public Property Estatus As String
        Get
            Return _Estatus
        End Get
        Set(value As String)
            _Estatus = value
        End Set
    End Property
End Class
