Public Class ConfiguracionCajaNave

    Private ccnId As Int32
    Private CajaAhorro As Entidades.CajaAhorro
    Private SemanaInicial As Int32
    Private SemanaFinal As Int32
    Private Interes As Int16

    Public Property pccnId As Int32
        Get
            Return ccnId
        End Get
        Set(value As Int32)
            ccnId = value
        End Set
    End Property


    Public Property pCajaAhorro As Entidades.CajaAhorro
        Get
            Return CajaAhorro
        End Get
        Set(value As Entidades.CajaAhorro)
            CajaAhorro = value
        End Set
    End Property


    Public Property pSemanaInicial As Int32
        Get
            Return SemanaInicial
        End Get
        Set(value As Int32)
            SemanaInicial = value
        End Set
    End Property


    Public Property pSemanaFinal As Int32
        Get
            Return SemanaFinal
        End Get
        Set(value As Int32)
            SemanaFinal = value
        End Set
    End Property

    Public Property pInteres As Int16
        Get
            Return Interes
        End Get
        Set(value As Int16)
            Interes = value
        End Set
    End Property


End Class
