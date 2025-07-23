Public Class DatosProveedorSICY

    Private RazonSocial As String
    Public Property prov_RazonSocial() As String
        Get
            Return RazonSocial
        End Get
        Set(ByVal value As String)
            RazonSocial = value
        End Set
    End Property

    Private NomPagoDoc As String
    Public Property prov_NomPagoDoc() As String
        Get
            Return NomPagoDoc
        End Get
        Set(ByVal value As String)
            NomPagoDoc = value
        End Set
    End Property

    Private Calle As String
    Public Property prov_Calle() As String
        Get
            Return Calle
        End Get
        Set(ByVal value As String)
            Calle = value
        End Set
    End Property

    Private Colonia As String
    Public Property prov_Colonia() As String
        Get
            Return Colonia
        End Get
        Set(ByVal value As String)
            Colonia = value
        End Set
    End Property

    Private CodPost As String
    Public Property prov_CodPost() As String
        Get
            Return CodPost
        End Get
        Set(ByVal value As String)
            CodPost = value
        End Set
    End Property

    Private RFC As String
    Public Property prov_RFC() As String
        Get
            Return RFC
        End Get
        Set(ByVal value As String)
            RFC = value
        End Set
    End Property

    Private CURP As String
    Public Property prov_CURP() As String
        Get
            Return CURP
        End Get
        Set(ByVal value As String)
            CURP = value
        End Set
    End Property

    Private IdCiudad As Integer
    Public Property prov_IdCiudad() As Integer
        Get
            Return IdCiudad
        End Get
        Set(ByVal value As Integer)
            IdCiudad = value
        End Set
    End Property

    Private IdProveedor As Integer
    Public Property prov_IdProveedor() As Integer
        Get
            Return IdProveedor
        End Get
        Set(ByVal value As Integer)
            IdProveedor = value
        End Set
    End Property

    Private NombreRepresentanteLegal As String
    Public Property prov_NombreRepresentanteLegal() As String
        Get
            Return NombreRepresentanteLegal
        End Get
        Set(ByVal value As String)
            NombreRepresentanteLegal = value
        End Set
    End Property

    Private idsicy As Integer
    Public Property prov_idsicy() As Integer
        Get
            Return idsicy
        End Get
        Set(ByVal value As Integer)
            idsicy = value
        End Set
    End Property


End Class
