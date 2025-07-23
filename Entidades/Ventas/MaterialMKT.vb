
Public Class MaterialMKT

    Private Pmaterialmercadotecniaid As Integer
    Public Property materialmercadotecniaid() As Integer
        Get
            Return Pmaterialmercadotecniaid
        End Get
        Set(ByVal value As Integer)
            Pmaterialmercadotecniaid = value
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

    Private Ptipomaterialmercadotecnia As TipoMaterialMKT
    Public Property tipomaterialmercadotecnia() As TipoMaterialMKT
        Get
            Return Ptipomaterialmercadotecnia
        End Get
        Set(ByVal value As TipoMaterialMKT)
            Ptipomaterialmercadotecnia = value
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
