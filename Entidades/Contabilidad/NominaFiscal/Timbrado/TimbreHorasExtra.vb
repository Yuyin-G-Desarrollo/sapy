Public Class TimbreHorasExtra
    Private timbreHorasExtraId As Integer
    Public Property THETimbreHorasExtraId() As Integer
        Get
            Return timbreHorasExtraId
        End Get
        Set(ByVal value As Integer)
            timbreHorasExtraId = value
        End Set
    End Property

    Private timbreNominaFiscalId As Integer
    Public Property THETimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private dias As Integer
    Public Property THEDias() As Integer
        Get
            Return dias
        End Get
        Set(ByVal value As Integer)
            dias = value
        End Set
    End Property

    Private tipoHoras As String
    Public Property THETipoHoras() As String
        Get
            Return tipoHoras
        End Get
        Set(ByVal value As String)
            tipoHoras = value
        End Set
    End Property

    Private horasExtra As Integer
    Public Property THEHorasExtra() As Integer
        Get
            Return horasExtra
        End Get
        Set(ByVal value As Integer)
            horasExtra = value
        End Set
    End Property

    Private importePagado As Double
    Public Property THEImportePagado() As Double
        Get
            Return importePagado
        End Get
        Set(ByVal value As Double)
            importePagado = value
        End Set
    End Property
End Class
