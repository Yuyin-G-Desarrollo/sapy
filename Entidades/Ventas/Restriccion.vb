Public Class Restriccion

    Private Prestriccionid As Integer
    Public Property restriccionid() As Integer
        Get
            Return Prestriccionid
        End Get
        Set(ByVal value As Integer)
            Prestriccionid = value
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

    Private Ptiporestriccion As TipoRestriccion
    Public Property tiporestriccion() As TipoRestriccion
        Get
            Return Ptiporestriccion
        End Get
        Set(ByVal value As TipoRestriccion)
            Ptiporestriccion = value
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
