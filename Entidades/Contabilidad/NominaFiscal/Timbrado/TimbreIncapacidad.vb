Public Class TimbreIncapacidad
    Private timbreIncapaidadId As Integer
    Public Property TITimbreIncapaidadId() As Integer
        Get
            Return timbreIncapaidadId
        End Get
        Set(ByVal value As Integer)
            timbreIncapaidadId = value
        End Set
    End Property

    Private timbreNominaFiscalId As Integer
    Public Property TITimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private diasIncapacidad As Double
    Public Property TIDiasIncapacidad() As Double
        Get
            Return diasIncapacidad
        End Get
        Set(ByVal value As Double)
            diasIncapacidad = value
        End Set
    End Property

    Private tipoIncapacidad As String
    Public Property TITipoIncapacidad() As String
        Get
            Return tipoIncapacidad
        End Get
        Set(ByVal value As String)
            tipoIncapacidad = value
        End Set
    End Property

    Private importemonetario As Double
    Public Property TIImportemonetario() As Double
        Get
            Return importemonetario
        End Get
        Set(ByVal value As Double)
            importemonetario = value
        End Set
    End Property

    Private descuento As Double
    Public Property TIDescuento() As Double
        Get
            Return descuento
        End Get
        Set(ByVal value As Double)
            descuento = value
        End Set
    End Property

    Private tipoDescripcion As String
    Public Property TITipoDescripcion() As String
        Get
            Return tipoDescripcion
        End Get
        Set(ByVal value As String)
            tipoDescripcion = value
        End Set
    End Property
End Class
