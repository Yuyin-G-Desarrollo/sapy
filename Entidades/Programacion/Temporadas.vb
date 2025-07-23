Public Class Temporadas
    Private idTemporada As String
    Private codigoTemporada As String
    Private nombreTemporada As String
    Private anioTemporada As String
    Private vigenciaTemporada As Nullable(Of Date)
    Private activoTemporada As Boolean


    Public Property pIdTemporada As String
        Get
            Return idTemporada
        End Get
        Set(ByVal value As String)
            idTemporada = value
        End Set
    End Property

    Public Property pCodigoTemporada As String
        Get
            Return codigoTemporada
        End Get
        Set(ByVal value As String)
            codigoTemporada = value
        End Set
    End Property

    Public Property pNombreTemporada As String
        Get
            Return nombreTemporada
        End Get
        Set(ByVal value As String)
            nombreTemporada = value
        End Set
    End Property

    Public Property pAnioTemporada As String
        Get
            Return anioTemporada
        End Get
        Set(ByVal value As String)
            anioTemporada = value
        End Set
    End Property

    Public Property pVigenciaTemporada() As Date?
        Get
            Return vigenciaTemporada
        End Get
        Set(ByVal value As Date?)
            vigenciaTemporada = value
        End Set
    End Property

    Public Property pActivoTemporada As Boolean
        Get
            Return activoTemporada
        End Get
        Set(ByVal value As Boolean)
            activoTemporada = value
        End Set
    End Property

End Class
