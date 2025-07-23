Public Class FolioDevolucion_Detalle

    Dim _FolioDevolucion As Integer
    Dim _FolioDevolucionDetalle As Integer
    Dim _Articulo As String
    Dim _CantidadPares As Integer
    Dim _Cliente As String


    Public Property FolioDevolucion As Integer
        Get
            Return _FolioDevolucion
        End Get
        Set(value As Integer)
            _FolioDevolucion = value
        End Set
    End Property

    Public Property FolioDevolucionDetalle As Integer
        Get
            Return _FolioDevolucionDetalle
        End Get
        Set(value As Integer)
            _FolioDevolucionDetalle = value
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

    Public Property CantidadPares As Integer
        Get
            Return _CantidadPares
        End Get
        Set(value As Integer)
            _CantidadPares = value
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


End Class
