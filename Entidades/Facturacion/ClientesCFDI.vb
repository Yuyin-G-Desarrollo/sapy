Public Class ClientesCFDI
    Private idcliente As Integer
    Public Property IdCte() As Integer
        Get
            Return idcliente
        End Get
        Set(ByVal value As Integer)
            idcliente = value
        End Set
    End Property

    Private razonSocial As String
    Public Property CRazonSocial() As String
        Get
            Return razonSocial
        End Get
        Set(ByVal value As String)
            razonSocial = value
        End Set
    End Property

    Private nombre As String
    Public Property CNombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private paterno As String
    Public Property CPaterno() As String
        Get
            Return paterno
        End Get
        Set(ByVal value As String)
            paterno = value
        End Set
    End Property

    Private materno As String
    Public Property CMaterno() As String
        Get
            Return materno
        End Get
        Set(ByVal value As String)
            materno = value
        End Set
    End Property

    Private rfc As String
    Public Property CRFC() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private curp As String
    Public Property CCurp() As String
        Get
            Return curp
        End Get
        Set(ByVal value As String)
            curp = value
        End Set
    End Property

    Private calle As String
    Public Property CCalle() As String
        Get
            Return calle
        End Get
        Set(ByVal value As String)
            calle = value
        End Set
    End Property

    Private numeroInterior As String
    Public Property CNumeroInterior() As String
        Get
            Return numeroInterior
        End Get
        Set(ByVal value As String)
            numeroInterior = value
        End Set
    End Property

    Private numeroExterior As String
    Public Property CNumeroExterior() As String
        Get
            Return numeroExterior
        End Get
        Set(ByVal value As String)
            numeroExterior = value
        End Set
    End Property

    Private colonia As String
    Public Property CColonia() As String
        Get
            Return colonia
        End Get
        Set(ByVal value As String)
            colonia = value
        End Set
    End Property

    Private cp As String
    Public Property CCP() As String
        Get
            Return cp
        End Get
        Set(ByVal value As String)
            cp = value
        End Set
    End Property

    Private idCiudad As Integer
    Public Property CIdCiudad() As Integer
        Get
            Return idCiudad
        End Get
        Set(ByVal value As Integer)
            idCiudad = value
        End Set
    End Property

    Private email As String
    Public Property CEmail() As String
        Get
            Return email
        End Get
        Set(ByVal value As String)
            email = value
        End Set
    End Property

    Private idUssuario As Integer
    Public Property CIdUsuario() As Integer
        Get
            Return idUssuario
        End Get
        Set(ByVal value As Integer)
            idUssuario = value
        End Set
    End Property


    Private idUsarioCreo As Integer
    Public Property CIdUsuarioCreo() As Integer
        Get
            Return idUsarioCreo
        End Get
        Set(ByVal value As Integer)
            idUsarioCreo = value
        End Set
    End Property

    Private idUsuarioModifico As Integer
    Public Property CIdUsuarioModifico() As Integer
        Get
            Return idUsuarioModifico
        End Get
        Set(ByVal value As Integer)
            idUsuarioModifico = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property CFechaCreadcion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private fechaModificacion As Date
    Public Property CFechaModificacion() As Date
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As Date)
            fechaModificacion = value
        End Set
    End Property

    Private sucursalId As Integer
    Public Property CSucursalID() As Integer
        Get
            Return sucursalId
        End Get
        Set(ByVal value As Integer)
            sucursalId = value
        End Set
    End Property

    Private telefono As String
    Public Property CTelefono() As String
        Get
            Return telefono
        End Get
        Set(ByVal value As String)
            telefono = value
        End Set
    End Property

    Private estadoId As Integer
    Public Property CEstadoId() As Integer
        Get
            Return estadoId
        End Get
        Set(ByVal value As Integer)
            estadoId = value
        End Set
    End Property

    Private paisId As Integer
    Public Property CPaisId() As Integer
        Get
            Return paisId
        End Get
        Set(ByVal value As Integer)
            paisId = value
        End Set
    End Property

    Private ciudad As String
    Public Property CCiudad() As String
        Get
            Return ciudad
        End Get
        Set(ByVal value As String)
            ciudad = value
        End Set
    End Property

    Private estado As String
    Public Property CEstado() As String
        Get
            Return estado
        End Get
        Set(ByVal value As String)
            estado = value
        End Set
    End Property

    Private pais As String
    Public Property CPais() As String
        Get
            Return pais
        End Get
        Set(ByVal value As String)
            pais = value
        End Set
    End Property

    Private metodoPagoId As Integer
    Public Property CMetodoPagoId() As Integer
        Get
            Return metodoPagoId
        End Get
        Set(ByVal value As Integer)
            metodoPagoId = value
        End Set
    End Property

    Private formaPago As String
    Public Property CFormaPago() As String
        Get
            Return formaPago
        End Get
        Set(ByVal value As String)
            formaPago = value
        End Set
    End Property

    Private condicionesPago As String
    Public Property CCondicionesPago() As String
        Get
            Return condicionesPago
        End Get
        Set(ByVal value As String)
            condicionesPago = value
        End Set
    End Property

    Private activo As Boolean
    Public Property CActivo() As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Private nombreRemision As String
    Public Property CNombreRemision() As String
        Get
            Return nombreRemision
        End Get
        Set(ByVal value As String)
            nombreRemision = value
        End Set
    End Property

    Private facturar As Boolean
    Public Property CFacturar() As Boolean
        Get
            Return facturar
        End Get
        Set(ByVal value As Boolean)
            facturar = value
        End Set
    End Property

    Private remisionar As Boolean
    Public Property CRemisionar() As Boolean
        Get
            Return remisionar
        End Get
        Set(ByVal value As Boolean)
            remisionar = value
        End Set
    End Property

End Class
