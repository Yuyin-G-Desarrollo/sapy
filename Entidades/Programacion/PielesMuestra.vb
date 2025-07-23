Public Class PielesMuestra
    Private PMPielMuestraId As Int32
    Private PMDescripcion As String
    Private PMCodigo As String
    Private PMActivo As Boolean

    Public Property PiMUId As Int32
        Get
            Return PMPielMuestraId
        End Get
        Set(ByVal value As Int32)
            PMPielMuestraId = value
        End Set
    End Property

    Public Property PiMuDescripcion As String
        Get
            Return PMDescripcion
        End Get
        Set(ByVal value As String)
            PMDescripcion = value
        End Set
    End Property

    Public Property PiMuCodigo As String
        Get
            Return PMCodigo
        End Get
        Set(ByVal value As String)
            PMCodigo = value
        End Set
    End Property

    Public Property PiMuActivo As Boolean
        Get
            Return PMActivo
        End Get
        Set(ByVal value As Boolean)
            PMActivo = value
        End Set
    End Property



End Class
