Public Class InteresesPrestamos
    Private Interes As Double
    Private Semanas As Double
    Private Estatus As String
    Private TipoInteres As String
    Private TotalIntereses As Double


    Public Property PInteres As Double
        Get
            Return Interes
        End Get
        Set(ByVal value As Double)
            Interes = value
        End Set
    End Property

    Public Property PSemanas As Double
        Get
            Return Semanas
        End Get
        Set(ByVal value As Double)
            Semanas = value
        End Set
    End Property

    Public Property PEstatus As String
        Get
            Return Estatus
        End Get
        Set(ByVal value As String)
            Estatus = value
        End Set
    End Property

    Public Property PtipoInteres As String
        Get
            Return TipoInteres
        End Get
        Set(ByVal value As String)
            TipoInteres = value
        End Set
    End Property

    Public Property PTotalInteres As Double
        Get
            Return TotalIntereses
        End Get
        Set(ByVal value As Double)
            TotalIntereses = value
        End Set
    End Property

End Class
