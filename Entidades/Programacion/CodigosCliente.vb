Public Class CodigosCliente


    Private IdCodigoCliente As Integer
    Public Property PIdCodigoCliente As Integer
        Get
            Return IdCodigoCliente
        End Get
        Set(value As Integer)
            IdCodigoCliente = value
        End Set
    End Property

    Private ClienteId As Integer
    Public Property PClienteId As Integer
        Get
            Return ClienteId
        End Get
        Set(value As Integer)
            ClienteId = value
        End Set
    End Property

    Private ProductoEstiloId As Integer
    Public Property PProductoEstiloId As Integer
        Get
            Return ProductoEstiloId
        End Get
        Set(value As Integer)
            ProductoEstiloId = value
        End Set
    End Property

    Private CodigoCliente As String
    Public Property PCodigoCliente As String
        Get
            Return CodigoCliente
        End Get
        Set(value As String)
            CodigoCliente = value
        End Set
    End Property

    Private CodigoRapidoCliente As String
    Public Property PCodigoRapidoCliente As String
        Get
            Return CodigoRapidoCliente
        End Get
        Set(value As String)
            CodigoRapidoCliente = value
        End Set
    End Property

    Private EstiloCliente As String
    Public Property PEstiloCliente As String
        Get
            Return EstiloCliente
        End Get
        Set(value As String)
            EstiloCliente = value
        End Set
    End Property

    Private MarcaCliente As String
    Public Property PMarcaCliente As String
        Get
            Return MarcaCliente
        End Get
        Set(value As String)
            MarcaCliente = value
        End Set
    End Property

    Private ColeccionCliente As String
    Public Property PColeccionCliente As String
        Get
            Return ColeccionCliente
        End Get
        Set(value As String)
            ColeccionCliente = value
        End Set
    End Property

    Private FamiliaCliente As String
    Public Property PFamiliaCliente As String
        Get
            Return FamiliaCliente
        End Get
        Set(value As String)
            FamiliaCliente = value
        End Set
    End Property

    Private LineaCliente As String
    Public Property PLineaCliente As String
        Get
            Return LineaCliente
        End Get
        Set(value As String)
            LineaCliente = value
        End Set
    End Property


    Private MaterialCliente As String
    Public Property PMaterialCliente As String
        Get
            Return MaterialCliente
        End Get
        Set(value As String)
            MaterialCliente = value
        End Set
    End Property


    Private ColorCliente As String
    Public Property PColorCliente As String
        Get
            Return ColorCliente
        End Get
        Set(value As String)
            ColorCliente = value
        End Set
    End Property


    Private TallaCliente As String
    Public Property PTallaCliente As String
        Get
            Return TallaCliente
        End Get
        Set(value As String)
            TallaCliente = value
        End Set
    End Property

    Private DescripcionCliente As String
    Public Property PDescripcionCliente As String
        Get
            Return DescripcionCliente
        End Get
        Set(value As String)
            DescripcionCliente = value
        End Set
    End Property

    Private MotivoEliminacion As String
    Public Property PMotivoEliminacion As String
        Get
            Return MotivoEliminacion
        End Get
        Set(value As String)
            MotivoEliminacion = value
        End Set
    End Property

    Private CantidadEmpacado As Integer
    Public Property PCantidadEmpacado As Integer
        Get
            Return CantidadEmpacado
        End Get
        Set(value As Integer)
            CantidadEmpacado = value
        End Set
    End Property

    Private Imagen As String
    Public Property PImagen As String
        Get
            Return Imagen
        End Get
        Set(value As String)
            Imagen = value
        End Set
    End Property

    Private Activo As Boolean
    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property

    Private UsuarioCreo As Integer
    Public Property PUsuarioCreo As Integer
        Get
            Return UsuarioCreo
        End Get
        Set(value As Integer)
            UsuarioCreo = value
        End Set
    End Property

    Private UsuarioModifico As Integer
    Public Property PUsuarioModifico As Integer
        Get
            Return UsuarioModifico
        End Get
        Set(value As Integer)
            UsuarioModifico = value
        End Set
    End Property

    Private UsuarioElimino As Integer
    Public Property PUsuarioElimino As Integer
        Get
            Return UsuarioElimino
        End Get
        Set(value As Integer)
            UsuarioElimino = value
        End Set
    End Property

    Private FechaCreacion As Date
    Public Property PFechaCreacion As Date
        Get
            Return FechaCreacion
        End Get
        Set(value As Date)
            FechaCreacion = value
        End Set
    End Property

    Private FechaModificacion As Date
    Public Property PFechaModificacion As Date
        Get
            Return FechaModificacion
        End Get
        Set(value As Date)
            FechaModificacion = value
        End Set
    End Property

    Private FechaEliminacion As Date
    Public Property PFechaElimianciona As Date
        Get
            Return FechaEliminacion
        End Get
        Set(value As Date)
            FechaEliminacion = value
        End Set
    End Property


End Class
