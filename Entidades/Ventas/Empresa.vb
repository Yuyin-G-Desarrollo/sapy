
Public Class Empresa

    Private empr_empresaid As Integer
    Public Property Pempr_empresaid() As Integer
        Get
            Return empr_empresaid
        End Get
        Set(ByVal value As Integer)
            empr_empresaid = value
        End Set
    End Property

    Private empr_nombre As String
    Public Property Pempr_nombre() As String
        Get
            Return empr_nombre
        End Get
        Set(ByVal value As String)
            empr_nombre = value
        End Set
    End Property

    Private empr_activo As Boolean
    Public Property Pempr_activo() As Boolean
        Get
            Return empr_activo
        End Get
        Set(ByVal value As Boolean)
            empr_activo = value
        End Set
    End Property

    Private RFCEmpresa As String
    Public Property PRFCEmpresa As String
        Get
            Return RFCEmpresa
        End Get
        Set(value As String)
            RFCEmpresa = value
        End Set
    End Property

    Private TasaIVA As Double
    Public Property PTasaIva As Double
        Get
            Return TasaIVA
        End Get
        Set(value As Double)
            TasaIVA = value
        End Set
    End Property

    Private TasaIVAEncabezado As Double
    Public Property PTasaIvaEncabezado As Double
        Get
            Return TasaIVAEncabezado
        End Get
        Set(value As Double)
            TasaIVAEncabezado = value
        End Set
    End Property

End Class
