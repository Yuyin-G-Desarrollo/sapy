



Public Class SolicitudIncentivos
    Private NombreIncentivo As Entidades.Incentivos
    Private NColaborador As Entidades.Colaborador
    Private Departamento As Entidades.Departamentos
    Private FechaSolicitud As DateTime
    Private FechaAutorizacion As DateTime
    Private Solicito As Entidades.Usuarios
    Private Autorizo As Entidades.Usuarios
    Private Estatus As String
    Private IncentivoId As Entidades.Incentivos
    Private Monto As Int32
    Private SolicitudID As Int32
    Private MotivoID As Incentivos
    Private ColaboradorID As Int32
    Private Descripcion As String
    Private celulas As Entidades.Celulas
    Private MotivoID2 As Incentivos
    Private MotivoID3 As Incentivos
    Private MontoGratificacion1 As Int32
    Private MontoGratificacion2 As Int32
    Private MontoGratificacion3 As Int32

    Public Property Pcelulas As Celulas
        Get
            Return celulas
        End Get
        Set(value As Celulas)
            celulas = value
        End Set
    End Property

    Public Property PNombreIncentivo As Incentivos
        Get
            Return NombreIncentivo
        End Get
        Set(ByVal value As Incentivos)
            NombreIncentivo = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(ByVal value As String)
            Descripcion = value
        End Set
    End Property


    Public Property PColaboradorID As Int32
        Get
            Return ColaboradorID
        End Get
        Set(ByVal value As Int32)
            ColaboradorID = value
        End Set
    End Property

    Public Property PMotivoID As Incentivos
        Get
            Return MotivoID
        End Get
        Set(ByVal value As Incentivos)
            MotivoID = value
        End Set
    End Property

    Public Property PSolicitudID As Int32
        Get
            Return SolicitudID
        End Get
        Set(ByVal value As Int32)
            SolicitudID = value
        End Set
    End Property

    Public Property PMonto As Int32
        Get
            Return Monto
        End Get
        Set(ByVal value As Int32)
            Monto = value
        End Set
    End Property


    Public Property PIncentivoID As Incentivos
        Get
            Return IncentivoId
        End Get
        Set(ByVal value As Incentivos)
            IncentivoId = value
        End Set
    End Property


    Public Property PDepartamento As Departamentos
        Get
            Return Departamento
        End Get
        Set(ByVal value As Departamentos)
            Departamento = value
        End Set
    End Property

    Public Property PFechaSolicitud As DateTime
        Get
            Return FechaSolicitud
        End Get
        Set(ByVal value As DateTime)
            FechaSolicitud = value
        End Set
    End Property

    Public Property PFechaAutorizacion As DateTime
        Get
            Return FechaAutorizacion
        End Get
        Set(ByVal value As DateTime)
            FechaAutorizacion = value
        End Set
    End Property

    Public Property PSolicito As Usuarios
        Get
            Return Solicito
        End Get
        Set(ByVal value As Usuarios)
            Solicito = value
        End Set
    End Property

    Public Property PAutorizo As Usuarios
        Get
            Return Autorizo
        End Get
        Set(ByVal value As Usuarios)
            Autorizo = value
        End Set
    End Property


    Public Property PNombreColaborador As Colaborador
        Get
            Return NColaborador
        End Get
        Set(ByVal value As Colaborador)
            NColaborador = value
        End Set
    End Property

    Public Property PEstatus As String
        Get
            Return Estatus
        End Get
        Set(ByVal value As String)
            Estatus = value
        End Set
    End Property

    Public Property PMotivoID2 As Incentivos
        Get
            Return MotivoID2
        End Get
        Set(ByVal value As Incentivos)
            MotivoID2 = value
        End Set
    End Property

    Public Property PMotivoID3 As Incentivos
        Get
            Return MotivoID3
        End Get
        Set(ByVal value As Incentivos)
            MotivoID3 = value
        End Set
    End Property

    Public Property PMontoGratificacion1 As Int32
        Get
            Return MontoGratificacion1
        End Get
        Set(ByVal value As Int32)
            MontoGratificacion1 = value
        End Set
    End Property

    Public Property PMontoGratificacion2 As Int32
        Get
            Return MontoGratificacion2
        End Get
        Set(ByVal value As Int32)
            MontoGratificacion2 = value
        End Set
    End Property

    Public Property PMontoGratificacion3 As Int32
        Get
            Return MontoGratificacion3
        End Get
        Set(ByVal value As Int32)
            MontoGratificacion3 = value
        End Set
    End Property
End Class
