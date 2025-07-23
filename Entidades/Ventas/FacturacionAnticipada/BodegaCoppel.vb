Imports Entidades

Public Class BodegaCoppel
    Private _id As Integer
    Private _nombre As String
    Private _tiendas As List(Of TiendaCoppel)

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Tiendas As List(Of TiendaCoppel)
        Get
            Return _tiendas
        End Get
        Set(value As List(Of TiendaCoppel))
            _tiendas = value
        End Set
    End Property

End Class
