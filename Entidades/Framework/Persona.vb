
Public Class Persona

    Private Ppersonaid As Integer
    Public Property personaid() As Integer
        Get
            Return Ppersonaid
        End Get
        Set(ByVal value As Integer)
            Ppersonaid = value
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

    Private Papaterno As String
    Public Property apaterno() As String
        Get
            Return Papaterno
        End Get
        Set(ByVal value As String)
            Papaterno = value
        End Set
    End Property

    Private Pamaterno As String
    Public Property amaterno() As String
        Get
            Return Pamaterno
        End Get
        Set(ByVal value As String)
            Pamaterno = value
        End Set
    End Property

    Private PCURP As String
    Public Property CURP() As String
        Get
            Return PCURP
        End Get
        Set(ByVal value As String)
            PCURP = value
        End Set
    End Property

    Private Prazonsocial As String
    Public Property razonsocial() As String
        Get
            Return Prazonsocial
        End Get
        Set(ByVal value As String)
            Prazonsocial = value
        End Set
    End Property

    Private Ppaginaweb As String
    Public Property paginaweb() As String
        Get
            Return Ppaginaweb
        End Get
        Set(ByVal value As String)
            Ppaginaweb = value
        End Set
    End Property

    Private Pfechanacimiento As DateTime
    Public Property fechanacimiento() As DateTime
        Get
            Return Pfechanacimiento
        End Get
        Set(ByVal value As DateTime)
            Pfechanacimiento = value
        End Set
    End Property

    Private Ppersonafisica As Boolean
    Public Property personafisica() As Boolean
        Get
            Return Ppersonafisica
        End Get
        Set(ByVal value As Boolean)
            Ppersonafisica = value
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

    Private PSicyID As Int32
    Public Property SicyID() As Int32
        Get
            Return PSicyID
        End Get
        Set(ByVal value As Int32)
            PSicyID = value
        End Set
    End Property


End Class
