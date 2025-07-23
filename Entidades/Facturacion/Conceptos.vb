Public Class Conceptos
    Private cantidad As Double
    Public Property CCantidad() As Double
        Get
            Return cantidad
        End Get
        Set(ByVal value As Double)
            cantidad = value
        End Set
    End Property

    Private unidad As String
    Public Property CUnidad() As String
        Get
            Return unidad
        End Get
        Set(ByVal value As String)
            unidad = value
        End Set
    End Property

    Private unidadId As Integer
    Public Property CUnidadId() As Integer
        Get
            Return unidadId
        End Get
        Set(ByVal value As Integer)
            unidadId = value
        End Set
    End Property

    Private productoId As Integer
    Public Property CProductoId() As Integer
        Get
            Return productoId
        End Get
        Set(ByVal value As Integer)
            productoId = value
        End Set
    End Property

    Private descripcion As String
    Public Property CDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private valorUnitario As Double
    Public Property CValorUnitario() As Double
        Get
            Return valorUnitario
        End Get
        Set(ByVal value As Double)
            valorUnitario = value
        End Set
    End Property

    Private importe As Double
    Public Property CImporte() As Double
        Get
            Return importe
        End Get
        Set(ByVal value As Double)
            importe = value
        End Set
    End Property

    Private estilo As String
    Public Property CEstilo() As String
        Get
            Return estilo
        End Get
        Set(ByVal value As String)
            estilo = value
        End Set
    End Property
End Class