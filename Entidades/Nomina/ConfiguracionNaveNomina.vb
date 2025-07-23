
Public Class ConfiguracionNaveNomina
    Private conNaveId As Int32
    Private ConDiasAguinaldo As Int32
    Private ConDiasVacaciones As Int32
    Private conDiasGratificacion As Int32
    Private NaveNombre As Entidades.Naves
    Private AutorizaGerente As Boolean
    Private AutorizaDirector As Boolean
    Private ConfiguracionID As Int32

    Public Property PIDconfiguracion As Int32
        Get
            Return ConfiguracionID
        End Get
        Set(ByVal value As Int32)
            ConfiguracionID = value
        End Set
    End Property

    Public Property PAutorizaGerente As Boolean
        Get
            Return AutorizaGerente
        End Get
        Set(ByVal value As Boolean)
            AutorizaGerente = value
        End Set
    End Property

    Public Property PAutorizaDirector As Boolean
        Get
            Return AutorizaDirector
        End Get
        Set(ByVal value As Boolean)
            AutorizaDirector = value
        End Set
    End Property

    Public Property PNaveNombre As Naves
        Get
            Return NaveNombre
        End Get
        Set(ByVal value As Naves)
            NaveNombre = value
        End Set
    End Property

    Public Property PconNaveId As Int32
        Get
            Return conNaveId
        End Get
        Set(ByVal value As Int32)
            conNaveId = value
        End Set
    End Property

    Public Property PConDiasAguinaldo As Int32
        Get

            Return ConDiasAguinaldo
        End Get
        Set(ByVal value As Int32)
            ConDiasAguinaldo = value
        End Set
    End Property

    Public Property PconDiasVacaciones As Int32
        Get
            Return ConDiasVacaciones
        End Get
        Set(ByVal value As Int32)
            ConDiasVacaciones = value
        End Set
    End Property

    Public Property PconDiasGratificacion As Int32
        Get
            Return conDiasGratificacion
        End Get
        Set(ByVal value As Int32)
            conDiasGratificacion = value
        End Set
    End Property

End Class
