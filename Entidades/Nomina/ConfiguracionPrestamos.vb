Public Class ConfiguracionPrestamos
    Private Naves As Naves
    Private ConfiguracionPrestamoId As Integer
    Private InteresSobreSaldo As Boolean ''Entidad para alojar tipo de interes
    Private InteresFijo As Boolean ''Entidad para alojar tipo de interes
    Private SinInteres As Boolean ''Entidad para alojar tipo de interes
    Private AutorizacionGerente As Boolean ''Entidad para alojar si requiere autorizacion del gerente
    Private AutorizacionDirector As Boolean ''Entidad para alojar si requiere autorizacion del director
    Private Interes As Double ''Entidad para alojar la Tasa de interes que se manejara
    Private MontoMaximoPorNave As Double ''entidad para alojar el monto maximo a prestas por nave
    Private MontoMaximoColaborador As Double ''Entidad para alojar el monto maximo que se le puede prestar a un colaborador
    Private SemanasMaximo As Int32 ''Entidad para alojar el numero maximo de semanas para pagar un prestamo
    Private UsuarioCreoId As Int32 ''Entidad para alojar el Id  del usuario que creo el registro
    Private UsuarioModificoId As Int32 ''Entidad para alojar el id del usuario que modifico un registro
    

    'Setters y getters de las cuales asignamos y devolvemos los valores desde la consulta

    Public Property PNaves As Entidades.Naves
        Get
            Return Naves
        End Get
        Set(ByVal value As Entidades.Naves)
            Naves = value
        End Set
    End Property


    Public Property PInteresSobreSaldo As Boolean
        Get
            Return InteresSobreSaldo
        End Get
        Set(ByVal value As Boolean)
            InteresSobreSaldo = value
        End Set
    End Property

    Public Property PInteresFijo As Boolean
        Get
            Return InteresFijo
        End Get
        Set(ByVal value As Boolean)
            InteresFijo = value
        End Set
    End Property


    Public Property PSinInteres As Boolean
        Get
            Return SinInteres
        End Get
        Set(ByVal value As Boolean)
            SinInteres = value
        End Set
    End Property

    Public Property PAutorizacionGerente As Boolean
        Get
            Return AutorizacionGerente
        End Get
        Set(ByVal value As Boolean)
            AutorizacionGerente = value
        End Set
    End Property

    Public Property PAutorizacionDirector As Boolean
        Get
            Return AutorizacionDirector
        End Get
        Set(ByVal value As Boolean)
            AutorizacionDirector = value
        End Set
    End Property


    Public Property PInteres As Double
        Get
            Return Interes
        End Get
        Set(ByVal value As Double)
            Interes = value
        End Set
    End Property

    Public Property PMontoMaximoPorNave As Double
        Get
            Return MontoMaximoPorNave
        End Get
        Set(ByVal value As Double)
            MontoMaximoPorNave = value
        End Set
    End Property

    Public Property PMontoMaximoPorColaborador As Double
        Get
            Return MontoMaximoColaborador
        End Get
        Set(ByVal value As Double)
            MontoMaximoColaborador = value
        End Set
    End Property

    Public Property PSemanasMaximo As Int32
        Get
            Return SemanasMaximo
        End Get
        Set(ByVal value As Int32)
            SemanasMaximo = value
        End Set
    End Property

    Public Property PUsuarioCreo As Int32
        Get
            Return UsuarioCreoId
        End Get
        Set(ByVal value As Int32)
            UsuarioCreoId = value
        End Set
    End Property

    Public Property PUsuarioModifico As Int32
        Get
            Return UsuarioModificoId
        End Get
        Set(ByVal value As Int32)
            UsuarioModificoId = value
        End Set
    End Property

    Public Property PConfiguracionPrestamoId As Int32
        Get
            Return ConfiguracionPrestamoId
        End Get
        Set(ByVal value As Int32)
            ConfiguracionPrestamoId = value
        End Set
    End Property




End Class
