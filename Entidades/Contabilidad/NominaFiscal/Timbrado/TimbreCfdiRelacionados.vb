Public Class TimbreCfdiRelacionados
    Private cfdiRelacionadosId As Integer
    Public Property TCRCfdiRelacionadosId() As Integer
        Get
            Return cfdiRelacionadosId
        End Get
        Set(ByVal value As Integer)
            cfdiRelacionadosId = value
        End Set
    End Property

    Private timbreNominaFiscalId As Integer
    Public Property TCRTimbreNominaFiscalId() As Integer
        Get
            Return timbreNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalId = value
        End Set
    End Property

    Private timbreNominaFiscalOriginalId As Integer
    Public Property TCRTimbreNominaFiscalOriginalId() As Integer
        Get
            Return timbreNominaFiscalOriginalId
        End Get
        Set(ByVal value As Integer)
            timbreNominaFiscalOriginalId = value
        End Set
    End Property

    Private periodoNominaFiscalId As Integer
    Public Property TCRPeriodoNominaFiscalId() As Integer
        Get
            Return periodoNominaFiscalId
        End Get
        Set(ByVal value As Integer)
            periodoNominaFiscalId = value
        End Set
    End Property

    Private nominaFiscalId As Integer
    Public Property TCRNominaFiscalId() As Integer
        Get
            Return nominaFiscalId
        End Get
        Set(ByVal value As Integer)
            nominaFiscalId = value
        End Set
    End Property

    Private tipoRelacion As String
    Public Property TCRTipoRelacion() As String
        Get
            Return tipoRelacion
        End Get
        Set(ByVal value As String)
            tipoRelacion = value
        End Set
    End Property

    Private uuid As String
    Public Property TCRUuid() As String
        Get
            Return uuid
        End Get
        Set(ByVal value As String)
            uuid = value
        End Set
    End Property
End Class