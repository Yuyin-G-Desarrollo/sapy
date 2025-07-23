Public Class ClienteRFC

    Private Pclienterfcid As Integer
    Public Property clienterfcid() As Integer
        Get
            Return Pclienterfcid
        End Get
        Set(ByVal value As Integer)
            Pclienterfcid = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Private Ppersona As Persona
    Public Property persona() As Persona
        Get
            Return Ppersona
        End Get
        Set(ByVal value As Persona)
            Ppersona = value
        End Set
    End Property

    Private Pclasificacionpersona As ClasificacionPersona
    Public Property clasificacionpersona() As ClasificacionPersona
        Get
            Return Pclasificacionpersona
        End Get
        Set(ByVal value As ClasificacionPersona)
            Pclasificacionpersona = value
        End Set
    End Property

    Private Pramo As Ramo
    Public Property ramo() As Ramo
        Get
            Return Pramo
        End Get
        Set(ByVal value As Ramo)
            Pramo = value
        End Set
    End Property

    Private Pruta As Ruta
    Public Property ruta() As Ruta
        Get
            Return Pruta
        End Get
        Set(ByVal value As Ruta)
            Pruta = value
        End Set
    End Property

    Private PRFC As String
    Public Property RFC() As String
        Get
            Return PRFC
        End Get
        Set(ByVal value As String)
            PRFC = value
        End Set
    End Property

    Private Pporcentajefacturar As Decimal
    Public Property porcentajefacturar() As Decimal
        Get
            Return Pporcentajefacturar
        End Get
        Set(ByVal value As Decimal)
            Pporcentajefacturar = value
        End Set
    End Property

    Private Pporcentajeremisionar As Decimal
    Public Property porcentajeremisionar() As Decimal
        Get
            Return Pporcentajeremisionar
        End Get
        Set(ByVal value As Decimal)
            Pporcentajeremisionar = value
        End Set
    End Property

    Private Pcomentarios As String
    Public Property comentarios() As String
        Get
            Return Pcomentarios
        End Get
        Set(ByVal value As String)
            Pcomentarios = value
        End Set
    End Property

    Private Pclienterfcafacturar As ClienteRFC
    Public Property clienterfcafacturar() As ClienteRFC
        Get
            Return Pclienterfcafacturar
        End Get
        Set(ByVal value As ClienteRFC)
            Pclienterfcafacturar = value
        End Set
    End Property

    Private Pincoterm As Incoterms
    Public Property incoterm() As Incoterms
        Get
            Return Pincoterm
        End Get
        Set(ByVal value As Incoterms)
            Pincoterm = value
        End Set
    End Property

    Private Pparcialidades1 As Integer
    Public Property parcialidades1() As Integer
        Get
            Return Pparcialidades1
        End Get
        Set(ByVal value As Integer)
            Pparcialidades1 = value
        End Set
    End Property

    Private Pparcialidadesx As Integer
    Public Property parcialidadesx() As Integer
        Get
            Return Pparcialidadesx
        End Get
        Set(ByVal value As Integer)
            Pparcialidadesx = value
        End Set
    End Property

    Private Pmetodopago As MetodoPago
    Public Property metodopago() As MetodoPago
        Get
            Return Pmetodopago
        End Get
        Set(ByVal value As MetodoPago)
            Pmetodopago = value
        End Set
    End Property

    Private Pformapago As FormaPago
    Public Property formapago() As FormaPago
        Get
            Return Pformapago
        End Get
        Set(ByVal value As FormaPago)
            Pformapago = value
        End Set
    End Property


    Private Pcuenta As String
    Public Property cuenta() As String
        Get
            Return Pcuenta
        End Get
        Set(ByVal value As String)
            Pcuenta = value
        End Set
    End Property

    Private Pmoneda As Moneda
    Public Property moneda() As Moneda
        Get
            Return Pmoneda
        End Get
        Set(ByVal value As Moneda)
            Pmoneda = value
        End Set
    End Property

    Private Ptipoiva As TipoIVA
    Public Property tipoiva() As TipoIVA
        Get
            Return Ptipoiva
        End Get
        Set(ByVal value As TipoIVA)
            Ptipoiva = value
        End Set
    End Property

    Private Ptipocliente As TipoCliente
    Public Property tipocliente() As TipoCliente
        Get
            Return Ptipocliente
        End Get
        Set(ByVal value As TipoCliente)
            Ptipocliente = value
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


    Private PRegimenFiscalId As Int32
    Public Property regimenFiscalId() As Int32
        Get
            Return PRegimenFiscalId
        End Get
        Set(ByVal value As Int32)
            PRegimenFiscalId = value
        End Set
    End Property
End Class
