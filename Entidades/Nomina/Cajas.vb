Public Class Cajas
    Private CajaID As Int32
    Private NombreCaja As String

    Public Property PCajaID As Int32
        Get
            Return CajaID
        End Get
        Set(ByVal value As Int32)
            CajaID = value
        End Set
    End Property

    Public Property PNombreCaja As String
        Get
            Return NombreCaja
        End Get
        Set(ByVal value As String)
            NombreCaja = value
        End Set
    End Property


End Class
