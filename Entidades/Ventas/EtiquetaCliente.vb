Public Class EtiquetaCliente

    Private Petiquetaclienteid As Integer
    Public Property etiquetaclienteid() As Integer
        Get
            Return Petiquetaclienteid
        End Get
        Set(ByVal value As Integer)
            Petiquetaclienteid = value
        End Set
    End Property

    Private Ptipoetiquetaespecial As TipoEtiqueta
    Public Property tipoetiquetaespecial() As TipoEtiqueta
        Get
            Return Ptipoetiquetaespecial
        End Get
        Set(ByVal value As TipoEtiqueta)
            Ptipoetiquetaespecial = value
        End Set
    End Property


    Private Pimprimeenyuyin As Boolean
    Public Property imprimeenyuyin() As Boolean
        Get
            Return Pimprimeenyuyin
        End Get
        Set(ByVal value As Boolean)
            Pimprimeenyuyin = value
        End Set
    End Property

    Private Pfuenteinformacionetiqueta As FuenteInformacionEtiqueta
    Public Property fuenteinformacionetiqueta() As FuenteInformacionEtiqueta
        Get
            Return Pfuenteinformacionetiqueta
        End Get
        Set(ByVal value As FuenteInformacionEtiqueta)
            Pfuenteinformacionetiqueta = value
        End Set
    End Property

    Private Ptamanoetiqueta As TamanoEtiqueta
    Public Property tamanoetiqueta() As TamanoEtiqueta
        Get
            Return Ptamanoetiqueta
        End Get
        Set(ByVal value As TamanoEtiqueta)
            Ptamanoetiqueta = value
        End Set
    End Property

    Private Pubicacionetiqueta As UbicacionEtiqueta
    Public Property ubicacionetiqueta() As UbicacionEtiqueta
        Get
            Return Pubicacionetiqueta
        End Get
        Set(ByVal value As UbicacionEtiqueta)
            Pubicacionetiqueta = value
        End Set
    End Property

    Private Prutaimagen As String
    Public Property rutaimagen() As String
        Get
            Return Prutaimagen
        End Get
        Set(ByVal value As String)
            Prutaimagen = value
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
