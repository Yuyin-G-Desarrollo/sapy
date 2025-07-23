Public Class DatosSPEMensual
    Private rfc As String
    Public Property PRFC As String
        Get
            Return rfc
        End Get
        Set(value As String)
            rfc = value
        End Set
    End Property

    Private exentocargado As Double
    Public Property PExentoCargado As Double
        Get
            Return exentocargado
        End Get
        Set(value As Double)
            exentocargado = value
        End Set
    End Property

    Private gravadocargado As Double
    Public Property PGravadoCargado As Double
        Get
            Return gravadocargado
        End Get
        Set(value As Double)
            gravadocargado = value
        End Set
    End Property

    Private isrcargado As Double
    Public Property PISRCargado As Double
        Get
            Return isrcargado
        End Get
        Set(value As Double)
            isrcargado = value
        End Set
    End Property

    Private patronid As Integer
    Public Property PPatronId As Integer
        Get
            Return patronid
        End Get
        Set(value As Integer)
            patronid = value
        End Set
    End Property

    Private anio As Integer
    Public Property PAnio As Integer
        Get
            Return anio
        End Get
        Set(value As Integer)
            anio = value
        End Set
    End Property

    Private mes As Integer
    Public Property PMes As Integer
        Get
            Return mes
        End Get
        Set(value As Integer)
            mes = value
        End Set
    End Property

End Class
