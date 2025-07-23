Public Class DepartamentosByPatron

    Private _ID_Patron As Integer
    Private _ID_Departamento As Integer
    Private _NombreDepartamento As String
    Private _ClaveSueldo As String
    Private _ClavePremioPuntualidad As String
    Private _ClavePremioAsistencia As String
    Private _ClaveVacaciones As String
    Private _ClavePrimaVacacional As String
    Private _ClaveAguinaldo As String
    Private _Usuario As Integer
    Private _Fecha As DateTime
    Private _resp As Integer
    Private _mensaje As String

    Public Property ID_Patron As Integer
        Get
            Return _ID_Patron
        End Get
        Set(value As Integer)
            _ID_Patron = value
        End Set
    End Property

    Public Property NombreDepartamento As String
        Get
            Return _NombreDepartamento
        End Get
        Set(value As String)
            _NombreDepartamento = value
        End Set
    End Property

    Public Property ClaveSueldo As String
        Get
            Return _ClaveSueldo
        End Get
        Set(value As String)
            _ClaveSueldo = value
        End Set
    End Property

    Public Property ClavePremioPuntualidad As String
        Get
            Return _ClavePremioPuntualidad
        End Get
        Set(value As String)
            _ClavePremioPuntualidad = value
        End Set
    End Property

    Public Property ClavePremioAsistencia As String
        Get
            Return _ClavePremioAsistencia
        End Get
        Set(value As String)
            _ClavePremioAsistencia = value
        End Set
    End Property

    Public Property ClaveVacaciones As String
        Get
            Return _ClaveVacaciones
        End Get
        Set(value As String)
            _ClaveVacaciones = value
        End Set
    End Property

    Public Property ClavePrimaVacacional As String
        Get
            Return _ClavePrimaVacacional
        End Get
        Set(value As String)
            _ClavePrimaVacacional = value
        End Set
    End Property

    Public Property Resp As Integer
        Get
            Return _resp
        End Get
        Set(value As Integer)
            _resp = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property

    Public Property Usuario As Integer
        Get
            Return _Usuario
        End Get
        Set(value As Integer)
            _Usuario = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property ClaveAguinaldo As String
        Get
            Return _ClaveAguinaldo
        End Get
        Set(value As String)
            _ClaveAguinaldo = value
        End Set
    End Property

    Public Property ID_Departamento As Integer
        Get
            Return _ID_Departamento
        End Get
        Set(value As Integer)
            _ID_Departamento = value
        End Set
    End Property
End Class
