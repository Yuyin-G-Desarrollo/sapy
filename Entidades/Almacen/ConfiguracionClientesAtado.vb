Public Class ConfiguracionClientesAtado
    Dim ccve_configuracionid As Int32
    Dim ccve_cadenaid As Int32
    Dim ccve_validarsalidaporpar As Boolean
    Dim ccve_validarentradaporpar As Boolean
    Dim ccve_naveid As Int32


    Public Property Pccve_configuracionid As Int32
        Get
            Return ccve_configuracionid
        End Get
        Set(value As Int32)
            ccve_configuracionid = value
        End Set
    End Property

    Public Property Pccve_cadenaid As Int32
        Get
            Return ccve_cadenaid
        End Get
        Set(value As Int32)
            ccve_cadenaid = value
        End Set
    End Property

    Public Property Pccve_validarsalidaporpar As Boolean
        Get
            Return ccve_validarsalidaporpar
        End Get
        Set(value As Boolean)
            ccve_validarsalidaporpar = value
        End Set
    End Property


    Public Property Pccve_validarentradaporpar As Boolean
        Get
            Return ccve_validarentradaporpar
        End Get
        Set(value As Boolean)
            ccve_validarentradaporpar = value
        End Set
    End Property


    Public Property Pccve_naveid As Int32
        Get
            Return ccve_naveid
        End Get
        Set(value As Int32)
            ccve_naveid = value
        End Set
    End Property

End Class
