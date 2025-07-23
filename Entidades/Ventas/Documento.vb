Public Class Documento

    Private Pdocumentosclienteid As Integer
    Public Property documentosclienteid() As Integer
        Get
            Return Pdocumentosclienteid
        End Get
        Set(ByVal value As Integer)
            Pdocumentosclienteid = value
        End Set
    End Property

    Private Ptipodocumento As TipoDocumento
    Public Property tipodocumento() As TipoDocumento
        Get
            Return Ptipodocumento
        End Get
        Set(ByVal value As TipoDocumento)
            Ptipodocumento = value
        End Set
    End Property

    Private Pnumerocopias As Integer
    Public Property numerocopias() As Integer
        Get
            Return Pnumerocopias
        End Get
        Set(ByVal value As Integer)
            Pnumerocopias = value
        End Set
    End Property

    Private Ppoliticaventa As PoliticaVenta
    Public Property politicaventa() As PoliticaVenta
        Get
            Return Ppoliticaventa
        End Get
        Set(ByVal value As PoliticaVenta)
            Ppoliticaventa = value
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
