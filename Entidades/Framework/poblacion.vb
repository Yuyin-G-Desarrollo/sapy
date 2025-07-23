
Public Class Poblacion

    Private Ppoblacionid As Integer
    Public Property poblacionid() As Integer
        Get
            Return Ppoblacionid
        End Get
        Set(ByVal value As Integer)
            Ppoblacionid = value
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

    Private Pciudad As Ciudades
    Public Property ciudad() As Ciudades
        Get
            Return Pciudad
        End Get
        Set(ByVal value As Ciudades)
            Pciudad = value
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
