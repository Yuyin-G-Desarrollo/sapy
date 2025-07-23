
Public Class Condicion

    Private Pcondicionid As Integer
    Public Property condicionid() As Integer
        Get
            Return Pcondicionid
        End Get
        Set(ByVal value As Integer)
            Pcondicionid = value
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

    Private Ptipocondicion As TipoCondicion
    Public Property tipocondicion() As TipoCondicion
        Get
            Return Ptipocondicion
        End Get
        Set(ByVal value As TipoCondicion)
            Ptipocondicion = value
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
