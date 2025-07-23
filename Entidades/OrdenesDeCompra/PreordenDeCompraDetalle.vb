Public Class PreordenDeCompra

    Private tipo As String
    Public Property tipo_() As String
        Get
            Return tipo
        End Get
        Set(ByVal value As String)
            tipo = value
        End Set
    End Property

    Private Nave As Integer
    Public Property Nave_() As Integer
        Get
            Return Nave
        End Get
        Set(ByVal value As Integer)
            Nave = value
        End Set
    End Property

    Private Anio As Integer
    Public Property Anio_() As Integer
        Get
            Return Anio
        End Get
        Set(ByVal value As Integer)
            Anio = value
        End Set
    End Property

    Private FechaPrograma As String
    Public Property FechaPrograma_() As String
        Get
            Return FechaPrograma
        End Get
        Set(ByVal value As String)
            FechaPrograma = value
        End Set
    End Property

    Private FechaEntrega As String
    Public Property FechaEntrega_() As String
        Get
            Return FechaEntrega
        End Get
        Set(ByVal value As String)
            FechaEntrega = value
        End Set
    End Property

    Private Priorirdad As String
    Public Property Prioridad_() As String
        Get
            Return Priorirdad
        End Get
        Set(ByVal value As String)
            Priorirdad = value
        End Set
    End Property

    Private pares As Integer
    Public Property pares_() As Integer
        Get
            Return pares
        End Get
        Set(ByVal value As Integer)
            pares = value
        End Set
    End Property


    Private Componenteid As Integer
    Public Property Componenteid_() As Integer
        Get
            Return Componenteid
        End Get
        Set(ByVal value As Integer)
            Componenteid = value
        End Set
    End Property

    Private Proveedorid As Integer
    Public Property Proveedorid_() As Integer
        Get
            Return Proveedorid
        End Get
        Set(ByVal value As Integer)
            Proveedorid = value
        End Set
    End Property

    Private Descuento As Double
    Public Property Descuento_() As Double
        Get
            Return Descuento
        End Get
        Set(ByVal value As Double)
            Descuento = value
        End Set
    End Property

    Private documento As String
    Public Property documento_() As String
        Get
            Return documento
        End Get
        Set(ByVal value As String)
            documento = value
        End Set
    End Property


    Private Tipodeorden As String
    Public Property Tipodeorden_() As String
        Get
            Return Tipodeorden
        End Get
        Set(ByVal value As String)
            Tipodeorden = value
        End Set
    End Property

    Private Observacion As String
    Public Property Observacion_() As String
        Get
            Return Observacion
        End Get
        Set(ByVal value As String)
            Observacion = value
        End Set
    End Property

    Private Usuariocreoid As Integer
    Public Property Usuariocreoid_() As Integer
        Get
            Return Usuariocreoid
        End Get
        Set(ByVal value As Integer)
            Usuariocreoid = value
        End Set
    End Property

    Private Fechacreo As String
    Public Property Fechacreo_() As String
        Get
            Return Fechacreo
        End Get
        Set(ByVal value As String)
            Fechacreo = value
        End Set
    End Property

    Private Usuariomodifico As Integer
    Public Property Usuariomodifico_() As Integer
        Get
            Return Usuariomodifico
        End Get
        Set(ByVal value As Integer)
            Usuariomodifico = value
        End Set
    End Property

    Private Fechamodifico As String
    Public Property Fechamodifico_() As String
        Get
            Return Fechamodifico
        End Get
        Set(ByVal value As String)
            Fechamodifico = value
        End Set
    End Property

    Private Autorizada As String
    Public Property Autorizada_() As String
        Get
            Return Autorizada
        End Get
        Set(ByVal value As String)
            Autorizada = value
        End Set
    End Property

    Private Usuarioautorizaid As Integer
    Public Property Usuarioautorizaid_() As Integer
        Get
            Return Usuarioautorizaid
        End Get
        Set(ByVal value As Integer)
            Usuarioautorizaid = value
        End Set
    End Property

    Private Fechaautorizo As String
    Public Property Fechaautorizo_() As String
        Get
            Return Fechaautorizo
        End Get
        Set(ByVal value As String)
            Fechaautorizo = value
        End Set
    End Property
    Private monedaid As Integer
    Public Property monedaid_() As Integer
        Get
            Return monedaid
        End Get
        Set(ByVal value As Integer)
            monedaid = value
        End Set
    End Property

End Class
