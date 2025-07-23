
Public Class Almacen

    Private Palmacenid As Integer
    Public Property almacenid() As Integer
        Get
            Return Palmacenid
        End Get
        Set(ByVal value As Integer)
            Palmacenid = value
        End Set
    End Property

    Private Pnombre As String
    Public Property nombre() As String
        Get
            Return Pnombre
        End Get
        Set(ByVal value As String)
            Pnombre = value
        End Set
    End Property

    Private Pstock As Boolean
    Public Property stock() As Boolean
        Get
            Return Pstock
        End Get
        Set(ByVal value As Boolean)
            Pstock = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property

End Class
