Public Class DocumentoFactura
    Private _IdDocumentoSAY As Integer
    Private _ClienteId As Integer
    Private _Factura As String
    Private _MetodoPago As String
    Private _NombreEmpresa As String
    Private _EmpresaId As String
    Private _Receptorid As String
    Private _Cliente As String
    Private _Tipo As String
    Private _StatusID As Integer

    Public Property IdDocumentoSAY As Integer
        Get
            Return _IdDocumentoSAY
        End Get
        Set(value As Integer)
            _IdDocumentoSAY = value
        End Set
    End Property



    Public Property Factura As String
        Get
            Return _Factura
        End Get
        Set(value As String)
            _Factura = value
        End Set
    End Property

    Public Property MetodoPago As String
        Get
            Return _MetodoPago
        End Get
        Set(value As String)
            _MetodoPago = value
        End Set
    End Property

    Public Property NombreEmpresa As String
        Get
            Return _NombreEmpresa
        End Get
        Set(value As String)
            _NombreEmpresa = value
        End Set
    End Property

    Public Property EmpresaId As String
        Get
            Return _EmpresaId
        End Get
        Set(value As String)
            _EmpresaId = value
        End Set
    End Property

    Public Property Receptorid As String
        Get
            Return _Receptorid
        End Get
        Set(value As String)
            _Receptorid = value
        End Set
    End Property

    Public Property ClienteId As Integer
        Get
            Return _ClienteId
        End Get
        Set(value As Integer)
            _ClienteId = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(value As String)
            _Cliente = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property StatusID As Integer
        Get
            Return _StatusID
        End Get
        Set(value As Integer)
            _StatusID = value
        End Set
    End Property
End Class
