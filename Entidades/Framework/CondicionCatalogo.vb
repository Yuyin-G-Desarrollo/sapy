
Public Class CondicionCatalogo

    Private Pcondicioncatalogoid As Integer
    Public Property condicioncatalogoid() As Integer
        Get
            Return Pcondicioncatalogoid
        End Get
        Set(ByVal value As Integer)
            Pcondicioncatalogoid = value
        End Set
    End Property

    Private Pdescripcion As String
    Public Property descripcion() As String
        Get
            Return Pdescripcion
        End Get
        Set(ByVal value As String)
            Pdescripcion = value
        End Set
    End Property

    Private Pcondicion As Condicion
    Public Property condicion() As Condicion
        Get
            Return Pcondicion
        End Get
        Set(ByVal value As Condicion)
            Pcondicion = value
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
