
Public Class InspeccionCalidadValidaFolio

    Private _Folio As String
    Private _Mensaje As String
    Private _Estatus As Boolean

    Public Property Folio As String
        Get
            Return _Folio
        End Get
        Set(value As String)
            _Folio = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property Estatus As Boolean
        Get
            Return _Estatus
        End Get
        Set(value As Boolean)
            _Estatus = value
        End Set
    End Property

    Sub New()
        Folio = ""
        Mensaje = String.Empty
        Estatus = False
    End Sub

End Class
