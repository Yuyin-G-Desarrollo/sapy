Public Class DatosContactoSICY

    Private ContactoVentas As String
    Public Property daco_ContactoVentas() As String
        Get
            Return ContactoVentas
        End Get
        Set(ByVal value As String)
            ContactoVentas = value
        End Set
    End Property

    Private telcontact As String
    Public Property daco_telcontact() As String
        Get
            Return telcontact
        End Get
        Set(ByVal value As String)
            telcontact = value
        End Set
    End Property

    Private ContactoPagos As String
    Public Property daco_ContactoPagos() As String
        Get
            Return ContactoPagos
        End Get
        Set(ByVal value As String)
            ContactoPagos = value
        End Set
    End Property


    Private Email As String
    Public Property daco_Email() As String
        Get
            Return Email
        End Get
        Set(ByVal value As String)
            Email = value
        End Set
    End Property

    Private Telefono As String
    Public Property daco_Telefono() As String
        Get
            Return Telefono
        End Get
        Set(ByVal value As String)
            Telefono = value
        End Set
    End Property

    Private contactocobranza As String
    Public Property daco_contactocobranza() As String
        Get
            Return contactocobranza
        End Get
        Set(ByVal value As String)
            contactocobranza = value
        End Set
    End Property

    Private telcobranza As String
    Public Property daco_telcobranza() As String
        Get
            Return telcobranza
        End Get
        Set(ByVal value As String)
            telcobranza = value
        End Set
    End Property

    Private rutafoto As String
    Public Property daco_rutafoto() As String
        Get
            Return rutafoto
        End Get
        Set(ByVal value As String)
            rutafoto = value
        End Set
    End Property

    Private CobranzaEmail As String
    Public Property daco_CobranzaEmail() As String
        Get
            Return CobranzaEmail
        End Get
        Set(ByVal value As String)
            CobranzaEmail = value
        End Set
    End Property

    Private VentasEmail As String
    Public Property daco_VentasEmail() As String
        Get
            Return VentasEmail
        End Get
        Set(ByVal value As String)
            VentasEmail = value
        End Set
    End Property

    Private IdProveedor As Integer
    Public Property daco_IdProveedor() As Integer
        Get
            Return IdProveedor
        End Get
        Set(ByVal value As Integer)
            IdProveedor = value
        End Set
    End Property

End Class
