Public Class AsuntosMuestras
    Private _AsuntoMuestraId As Int32
    Private _activo As Boolean
    Private _descripcion As String

    Public Property AsuntoMuestraId As Int32
        Get
            Return _AsuntoMuestraId
        End Get
        Set(value As Int32)
            _AsuntoMuestraId = value
        End Set
    End Property
    Public Property Activo As Boolean
        Get
            Return _activo
        End Get
        Set(value As Boolean)
            _activo = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
End Class
