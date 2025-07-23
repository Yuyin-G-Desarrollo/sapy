
Public Class ClasePersona

    'cper_clasepersonaid	cper_nombre	cper_activo

    Private cper_clasepersonaid As Integer
    Public Property Pcper_clasepersonaid() As Integer
        Get
            Return cper_clasepersonaid
        End Get
        Set(ByVal value As Integer)
            cper_clasepersonaid = value
        End Set
    End Property

    Private cper_nombre As String
    Public Property Pcper_nombre() As String
        Get
            Return cper_nombre
        End Get
        Set(ByVal value As String)
            cper_nombre = value
        End Set
    End Property

    Private cper_activo As Boolean
    Public Property Pcper_activo() As Boolean
        Get
            Return cper_activo
        End Get
        Set(ByVal value As Boolean)
            cper_activo = value
        End Set
    End Property


End Class
