
Public Class ValidacionTipo

    Private Pvalidaciontipoid As Integer
    Public Property validaciontipoid() As Integer
        Get
            Return Pvalidaciontipoid
        End Get
        Set(ByVal value As Integer)
            Pvalidaciontipoid = value
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

    Private Ptabla As String
    Public Property tabla() As String
        Get
            Return Ptabla
        End Get
        Set(ByVal value As String)
            Ptabla = value
        End Set
    End Property

    Private Pcampotablastatus As String
    Public Property campotablastatus() As String
        Get
            Return Pcampotablastatus
        End Get
        Set(ByVal value As String)
            Pcampotablastatus = value
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
