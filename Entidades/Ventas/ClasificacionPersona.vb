
Public Class ClasificacionPersona

    Private Pclasificacionpersonaid As Integer
    Public Property clasificacionpersonaid() As Integer
        Get
            Return Pclasificacionpersonaid
        End Get
        Set(ByVal value As Integer)
            Pclasificacionpersonaid = value
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

    Private Pclasepersona As ClasePersona
    Public Property clasepersona() As ClasePersona
        Get
            Return Pclasepersona
        End Get
        Set(ByVal value As ClasePersona)
            Pclasepersona = value
        End Set
    End Property

    Private Pstatusalta As Boolean
    Public Property statusalta() As Boolean
        Get
            Return Pstatusalta
        End Get
        Set(ByVal value As Boolean)
            Pstatusalta = value
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
