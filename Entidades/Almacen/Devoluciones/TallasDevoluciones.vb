Public Class TallasDevoluciones

    Private _Talla As String
    Private _Cantidad As Integer

    Public Property Talla As String
        Get
            Return _Talla
        End Get
        Set(value As String)
            _Talla = value
        End Set
    End Property


    Public Property Cantidad As Integer
        Get
            Return _Cantidad
        End Get
        Set(value As Integer)
            _Cantidad = value
        End Set
    End Property



End Class
