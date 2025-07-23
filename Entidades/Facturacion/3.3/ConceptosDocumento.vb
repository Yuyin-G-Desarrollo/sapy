
Public Class ConceptosDocumento


    Private PClaveProductoServicio As String
    Public Property ClaveProductoServicio() As String
        Get
            Return PClaveProductoServicio
        End Get
        Set(ByVal value As String)
            PClaveProductoServicio = value
        End Set
    End Property

    Private PCantidad As String
    Public Property Cantidad() As String
        Get
            Return PCantidad
        End Get
        Set(ByVal value As String)
            PCantidad = value
        End Set
    End Property

    Private PClaveUnidad As String
    Public Property ClaveUnidad() As String
        Get
            Return PClaveUnidad
        End Get
        Set(ByVal value As String)
            PClaveUnidad = value
        End Set
    End Property

    Private PUnidad As String
    Public Property Unidad() As String
        Get
            Return PUnidad
        End Get
        Set(ByVal value As String)
            PUnidad = value
        End Set
    End Property

    Private PDescripcion As String
    Public Property Descripcion() As String
        Get
            Return PDescripcion
        End Get
        Set(ByVal value As String)
            PDescripcion = value
        End Set
    End Property

    Private PValorUnitario As String
    Public Property ValorUnitario() As String
        Get
            Return PValorUnitario
        End Get
        Set(ByVal value As String)
            PValorUnitario = value
        End Set
    End Property

    Private PConceptoImporte As String
    Public Property ConceptoImporte() As String
        Get
            Return PConceptoImporte
        End Get
        Set(ByVal value As String)
            PConceptoImporte = value
        End Set
    End Property

    Private PBase As String
    Public Property Base() As String
        Get
            Return PBase
        End Get
        Set(ByVal value As String)
            PBase = value
        End Set
    End Property

    Private PImpuesto As String
    Public Property Impuesto() As String
        Get
            Return PImpuesto
        End Get
        Set(ByVal value As String)
            PImpuesto = value
        End Set
    End Property

    Private PTrasladoImporte As String
    Public Property TrasladoImporte() As String
        Get
            Return PTrasladoImporte
        End Get
        Set(ByVal value As String)
            PTrasladoImporte = value
        End Set
    End Property

    Private PDescuento As String
    Public Property Descuento() As String
        Get
            Return PDescuento
        End Get
        Set(ByVal value As String)
            PDescuento = value
        End Set
    End Property

    Private PEstilo As String
    Public Property Estilo() As String
        Get
            Return PEstilo
        End Get
        Set(ByVal value As String)
            PEstilo = value
        End Set
    End Property
    Private claImpuesto As String
    Public Property ClaveImpuesto() As String
        Get
            Return claImpuesto
        End Get
        Set(ByVal value As String)
            claImpuesto = value
        End Set
    End Property
End Class
