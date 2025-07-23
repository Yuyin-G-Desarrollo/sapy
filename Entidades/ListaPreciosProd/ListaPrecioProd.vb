Public Class ListaPrecioProd
    Private listaid_ As Integer = 0
    Public Property listaid() As Integer
        Get
            Return listaid_
        End Get
        Set(ByVal value As Integer)
            listaid_ = value
        End Set
    End Property
    Private Nave_ As String
    Public Property Nave() As String
        Get
            Return Nave_
        End Get
        Set(ByVal value As String)
            Nave_ = value
        End Set
    End Property
    Private idNave_ As Integer
    Public Property idNave() As Integer
        Get
            Return idNave_
        End Get
        Set(ByVal value As Integer)
            idNave_ = value
        End Set
    End Property

    Private nombre_ As String
    Public Property nombre() As String
        Get
            Return nombre_
        End Get
        Set(ByVal value As String)
            nombre_ = value
        End Set
    End Property

    Private inicio_ As Date
    Public Property inicio() As Date
        Get
            Return inicio_
        End Get
        Set(ByVal value As Date)
            inicio_ = value
        End Set
    End Property
    Private fin_ As Date
    Public Property fin() As Date
        Get
            Return fin_
        End Get
        Set(ByVal value As Date)
            fin_ = value
        End Set
    End Property

    Private marca_ As String
    Public Property marca() As String
        Get
            Return marca_
        End Get
        Set(ByVal value As String)
            marca_ = value
        End Set
    End Property

    Private coleccion_ As String
    Public Property coleccion() As String
        Get
            Return coleccion_
        End Get
        Set(ByVal value As String)
            coleccion_ = value
        End Set
    End Property

    Private usuarioId_ As String
    Public Property usuarioId() As String
        Get
            Return usuarioId_
        End Get
        Set(ByVal value As String)
            usuarioId_ = value
        End Set
    End Property
    Private idmarca_ As String
    Public Property idmarca() As String
        Get
            Return idmarca_
        End Get
        Set(ByVal value As String)
            idmarca_ = value
        End Set
    End Property

    Private idcoleccion_ As String
    Public Property idcoleccion() As String
        Get
            Return idcoleccion_
        End Get
        Set(ByVal value As String)
            idcoleccion_ = value
        End Set
    End Property
End Class
