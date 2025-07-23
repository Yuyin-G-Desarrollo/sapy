Public Class EditarMaterialesMercadotecniaPOP
    Private IdMaterial As Integer
    Private NombreMaterial As String
    Private Descripcion As String
    Private UMC As String
    Private Marca As String
    Private MotivoFabricacion As String
    Private Precio As Integer
    Private EstatusM As String
    Private Existencia As Integer
    Private RutaFoto As String
    Private nombreImagen As String

    Public Property PIdMaterial() As Integer
        Get
            Return IdMaterial
        End Get
        Set(ByVal value As Integer)
            IdMaterial = value
        End Set
    End Property

    Public Property PNombreMaterial() As String
        Get
            Return NombreMaterial
        End Get
        Set(ByVal value As String)
            NombreMaterial = value
        End Set
    End Property

    Public Property PDescripcion() As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PUMC() As String
        Get
            Return UMC
        End Get
        Set(ByVal value As String)
            UMC = value
        End Set
    End Property

    Public Property PMarca() As String
        Get
            Return Marca
        End Get
        Set(ByVal value As String)
            Marca = value
        End Set
    End Property

    Public Property PMotivoFabricacion() As String
        Get
            Return MotivoFabricacion
        End Get
        Set(ByVal value As String)
            MotivoFabricacion = value
        End Set
    End Property

    Public Property PPrecio() As Integer
        Get
            Return Precio
        End Get
        Set(ByVal value As Integer)
            Precio = value
        End Set
    End Property

    Public Property PEstatusM() As String
        Get
            Return EstatusM
        End Get
        Set(ByVal value As String)
            EstatusM = value
        End Set
    End Property


    Public Property PExistencia() As Integer
        Get
            Return Existencia
        End Get
        Set(ByVal value As Integer)
            Existencia = value
        End Set
    End Property

    Public Property PRutaFoto() As String
        Get
            Return RutaFoto
        End Get
        Set(ByVal value As String)
            RutaFoto = value
        End Set
    End Property


    Public Property PnombreImagen() As String
        Get
            Return nombreImagen
        End Get
        Set(ByVal value As String)
            nombreImagen = value
        End Set
    End Property

End Class
