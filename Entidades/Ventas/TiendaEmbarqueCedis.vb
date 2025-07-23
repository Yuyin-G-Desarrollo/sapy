Public Class TiendaEmbarqueCedis

    Private Ptiendaembarquecedisid As Integer
    Public Property tiendaembarquecedisid() As Integer
        Get
            Return Ptiendaembarquecedisid
        End Get
        Set(ByVal value As Integer)
            Ptiendaembarquecedisid = value
        End Set
    End Property

    Private Pclienterfc As ClienteRFC
    Public Property clienterfc() As ClienteRFC
        Get
            Return Pclienterfc
        End Get
        Set(ByVal value As ClienteRFC)
            Pclienterfc = value
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

    Private Preembarcar As Boolean
    Public Property reembarcar() As Boolean
        Get
            Return Preembarcar
        End Get
        Set(ByVal value As Boolean)
            Preembarcar = value
        End Set
    End Property

    Private Preembarcarporcobrar As Boolean
    Public Property reembarcarporcobrar() As Boolean
        Get
            Return Preembarcarporcobrar
        End Get
        Set(ByVal value As Boolean)
            Preembarcarporcobrar = value
        End Set
    End Property

    Private Ptipoflete As TipoFlete
    Public Property tipoflete() As TipoFlete
        Get
            Return Ptipoflete
        End Get
        Set(ByVal value As TipoFlete)
            Ptipoflete = value
        End Set
    End Property

    Private Pconveniotransportes As String
    Public Property conveniotransportes() As String
        Get
            Return Pconveniotransportes
        End Get
        Set(ByVal value As String)
            Pconveniotransportes = value
        End Set
    End Property

    Private Ptipovalor As TipoValor
    Public Property tipovalor() As TipoValor
        Get
            Return Ptipovalor
        End Get
        Set(ByVal value As TipoValor)
            Ptipovalor = value
        End Set
    End Property

    Private Pdeclararvalor As Boolean
    Public Property declararvalor() As Boolean
        Get
            Return Pdeclararvalor
        End Get
        Set(ByVal value As Boolean)
            Pdeclararvalor = value
        End Set
    End Property

    Private Pdeclararenpesos As Boolean
    Public Property declararenpesos() As Boolean
        Get
            Return Pdeclararenpesos
        End Get
        Set(ByVal value As Boolean)
            Pdeclararenpesos = value
        End Set
    End Property

    Private Pvaloradeclarar As Decimal
    Public Property valoradeclarar() As Decimal
        Get
            Return Pvaloradeclarar
        End Get
        Set(ByVal value As Decimal)
            Pvaloradeclarar = value
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

    Private Pnotasempaque As String
    Public Property notasempaque() As String
        Get
            Return Pnotasempaque
        End Get
        Set(ByVal value As String)
            Pnotasempaque = value
        End Set
    End Property

    Private Pseguro As String
    Public Property seguro() As String
        Get
            Return Pseguro
        End Get
        Set(ByVal value As String)
            Pseguro = value
        End Set
    End Property

    Private Ppoliza As String
    Public Property poliza() As String
        Get
            Return Ppoliza
        End Get
        Set(ByVal value As String)
            Ppoliza = value
        End Set
    End Property

    Private Ptipoempaque As TipoEmpaque
    Public Property tipoempaque() As TipoEmpaque
        Get
            Return Ptipoempaque
        End Get
        Set(ByVal value As TipoEmpaque)
            Ptipoempaque = value
        End Set
    End Property

    Private Ptamanoempaque As TamanoEmpaque
    Public Property tamanoempaque() As TamanoEmpaque
        Get
            Return Ptamanoempaque
        End Get
        Set(ByVal value As TamanoEmpaque)
            Ptamanoempaque = value
        End Set
    End Property

    Private Pminimoparesempaque As Integer
    Public Property minimoparesempaque() As Integer
        Get
            Return Pminimoparesempaque
        End Get
        Set(ByVal value As Integer)
            Pminimoparesempaque = value
        End Set
    End Property

    Private Pmaximoparesempaque As Integer
    Public Property maximoparesempaque() As Integer
        Get
            Return Pmaximoparesempaque
        End Get
        Set(ByVal value As Integer)
            Pmaximoparesempaque = value
        End Set
    End Property

    Private Ptipotienda As TipoTienda
    Public Property tipotienda() As TipoTienda
        Get
            Return Ptipotienda
        End Get
        Set(ByVal value As TipoTienda)
            Ptipotienda = value
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

    Private PcodigoTienda As String
    Public Property codigoTienda() As String
        Get
            Return PcodigoTienda
        End Get
        Set(ByVal value As String)
            PcodigoTienda = value
        End Set
    End Property


End Class

