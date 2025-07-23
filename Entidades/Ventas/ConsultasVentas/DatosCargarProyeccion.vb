Public Class DatosCargarProyeccion

    Private Psemana As Integer
    Public Property semana() As Integer
        Get
            Return Psemana
        End Get
        Set(ByVal value As Integer)
            Psemana = value
        End Set
    End Property

    Private Paño As Integer
    Public Property año() As Integer
        Get
            Return Paño
        End Get
        Set(ByVal value As Integer)
            Paño = value
        End Set
    End Property

    Private PmarcaSAY As Integer
    Public Property marcaSAY() As Integer
        Get
            Return PmarcaSAY
        End Get
        Set(ByVal value As Integer)
            PmarcaSAY = value
        End Set
    End Property

    Private PmarcaSICY As String
    Public Property marcaSICY() As String
        Get
            Return PmarcaSICY
        End Get
        Set(ByVal value As String)
            PmarcaSICY = value
        End Set
    End Property

    Private PcolaboradorAgenteId As Integer
    Public Property colaboradorAgenteId() As Integer
        Get
            Return PcolaboradorAgenteId
        End Get
        Set(ByVal value As Integer)
            PcolaboradorAgenteId = value
        End Set
    End Property

    Private PidClienteSAY As Integer
    Public Property idClienteSAY() As Integer
        Get
            Return PidClienteSAY
        End Get
        Set(ByVal value As Integer)
            PidClienteSAY = value
        End Set
    End Property

    Private PidClienteSICY As Integer
    Public Property idClienteSICY() As Integer
        Get
            Return PidClienteSICY
        End Get
        Set(ByVal value As Integer)
            PidClienteSICY = value
        End Set
    End Property

    Private PidRutaSAY As Integer
    Public Property idRutaSAY() As Integer
        Get
            Return PidRutaSAY
        End Get
        Set(ByVal value As Integer)
            PidRutaSAY = value
        End Set
    End Property

    Private PparesProyectar As String
    Public Property paresProyectar() As String
        Get
            Return PparesProyectar
        End Get
        Set(ByVal value As String)
            PparesProyectar = value
        End Set
    End Property

    Private PusuarioId As Integer
    Public Property usuarioId() As Integer
        Get
            Return PusuarioId
        End Get
        Set(ByVal value As Integer)
            PusuarioId = value
        End Set
    End Property


    Private PfamiliaProyeccion As Integer
    Public Property familiaProyeccion() As Integer
        Get
            Return PfamiliaProyeccion
        End Get
        Set(ByVal value As Integer)
            PfamiliaProyeccion = value
        End Set
    End Property


    Private PclasificacionId As String
    Public Property clasificacionId() As String
        Get
            Return PclasificacionId
        End Get
        Set(ByVal value As String)
            PclasificacionId = value
        End Set
    End Property


    Private PclasificacionTexto As String
    Public Property clasificacionTexto() As String
        Get
            Return PclasificacionTexto
        End Get
        Set(ByVal value As String)
            PclasificacionTexto = value
        End Set
    End Property




End Class
