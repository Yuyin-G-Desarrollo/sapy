Public Class ConfiguracionAsistencia

    Private configuracionAsistenciaId As Int32
    Private rango As Int32
    Private resultadoCheck As Int32
    Private porcentaje As Double
    Private nave As Naves


    Public Property PConfiguracionAsistenciaId As Int32

        Get
            Return configuracionAsistenciaId
        End Get
        Set(ByVal value As Int32)
            configuracionAsistenciaId = value
        End Set
    End Property

    Public Property PRango As Int32
        Get
            Return rango
        End Get
        Set(ByVal value As Int32)
            rango = value
        End Set
    End Property

    Public Property PResultadoCheck As Int32
        Get
            Return resultadoCheck
        End Get
        Set(ByVal value As Int32)
            resultadoCheck = value
        End Set
    End Property

    Public Property PPorcentaje As Double
        Get
            Return porcentaje
        End Get
        Set(ByVal value As Double)
            porcentaje = value
        End Set
    End Property

    Public Property PNaves As Naves
        Get
            Return nave
        End Get
        Set(ByVal value As Naves)
            nave = value
        End Set
    End Property

End Class
