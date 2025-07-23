Public Class TallasEmbarques

    Private _ID As Integer
    Private _Talla As String
    Private _Pares As Integer

    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property

    Public Property Talla As String
        Get
            Return _Talla
        End Get
        Set(value As String)
            _Talla = value
        End Set
    End Property

    Public Property Pares As Integer
        Get
            Return _Pares
        End Get
        Set(value As Integer)
            _Pares = value
        End Set
    End Property
End Class
