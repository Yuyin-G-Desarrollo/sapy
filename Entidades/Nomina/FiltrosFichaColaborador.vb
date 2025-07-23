Public Class FiltrosFichaColaborador
    Private Nombre As String
    Private CURP As String
    Private RFC As String
    Private Activo As Boolean
    Private IdNave As Int32
    Private IdDepartamento As Int32
    Private IdPuesto As Int32
    Private Externo As Boolean


    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property

    Public Property PCURP As String
        Get
            Return CURP
        End Get
        Set(value As String)
            CURP = value
        End Set
    End Property

    Public Property PRFC As String
        Get
            Return RFC
        End Get
        Set(value As String)
            RFC = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property

    Public Property PIdNave As Int32
        Get
            Return IdNave
        End Get
        Set(value As Int32)
            IdNave = value
        End Set
    End Property

    Public Property PIdDepartamento As Int32
        Get
            Return IdDepartamento
        End Get
        Set(value As Int32)
            IdDepartamento = value
        End Set
    End Property

    Public Property PIdPuesto As Int32
        Get
            Return IdPuesto
        End Get
        Set(value As Int32)
            IdPuesto = value
        End Set
    End Property

    Public Property PExterno As Boolean
        Get
            Return Externo
        End Get
        Set(value As Boolean)
            Externo = value
        End Set
    End Property

End Class
