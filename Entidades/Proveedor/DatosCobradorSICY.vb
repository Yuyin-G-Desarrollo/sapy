Public Class DatosCobradorSICY

    Private idproveedor As Integer
    Public Property cobr_idproveedor() As Integer
        Get
            Return idproveedor
        End Get
        Set(ByVal value As Integer)
            idproveedor = value
        End Set
    End Property

    Private Nombre As String
    Public Property cobr_Nombre() As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Private Estatus As String
    Public Property cobr_Estatus() As String
        Get
            Return Estatus
        End Get
        Set(ByVal value As String)
            Estatus = value
        End Set
    End Property

    Private UsuCreo As String
    Public Property cobr_UsuCreo() As String
        Get
            Return UsuCreo
        End Get
        Set(ByVal value As String)
            UsuCreo = value
        End Set
    End Property

    Private fechacreo As Date
    Public Property cobr_fechacreo() As Date
        Get
            Return fechacreo
        End Get
        Set(ByVal value As Date)
            fechacreo = value
        End Set
    End Property

    Private usumod As String
    Public Property cobr_usumod() As String
        Get
            Return usumod
        End Get
        Set(ByVal value As String)
            usumod = value
        End Set
    End Property

    Private fecultmov As Date
    Public Property cobr_fecultmov() As Date
        Get
            Return fecultmov
        End Get
        Set(ByVal value As Date)
            fecultmov = value
        End Set
    End Property

    Private RutaFoto As String
    Public Property cobr_RutaFoto() As String
        Get
            Return RutaFoto
        End Get
        Set(ByVal value As String)
            RutaFoto = value
        End Set
    End Property

    Private idcobrador As String
    Public Property cobr_idcobrador() As String
        Get
            Return idcobrador
        End Get
        Set(ByVal value As String)
            idcobrador = value
        End Set
    End Property


End Class
