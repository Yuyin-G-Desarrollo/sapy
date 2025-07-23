Public Class Lineas
    Private idLinea As Int32
    Private nombreLinea As String
    Private activoLinea As Boolean

    Public Property PidLinea As Int32
        Get
            Return idLinea
        End Get
        Set(value As Int32)
            idLinea = value
        End Set
    End Property

    Public Property PnombreLinea As String
        Get
            Return nombreLinea
        End Get
        Set(value As String)
            nombreLinea = value
        End Set
    End Property

    Public Property PactivoLinea As Boolean
        Get
            Return activoLinea
        End Get
        Set(value As Boolean)
            activoLinea = value
        End Set
    End Property

End Class
