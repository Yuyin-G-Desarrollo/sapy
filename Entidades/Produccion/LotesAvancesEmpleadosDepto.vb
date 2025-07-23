Public Class LotesAvancesEmpleadosDepto

    Private idEmpleado_ As Integer
    Public Property idEmpleado() As Integer
        Get
            Return idEmpleado_
        End Get
        Set(ByVal value As Integer)
            idEmpleado_ = value
        End Set
    End Property

    Private idConfiguracion_ As Integer
    Public Property idConfiguracion() As Integer
        Get
            Return idConfiguracion_
        End Get
        Set(ByVal value As Integer)
            idConfiguracion_ = value
        End Set
    End Property

    Private estatus_ As String
    Public Property estatus() As String
        Get
            Return estatus_
        End Get
        Set(ByVal value As String)
            estatus_ = value
        End Set
    End Property

    Private idColaborador_ As Integer
    Public Property idColaborador() As Integer
        Get
            Return idColaborador_
        End Get
        Set(ByVal value As Integer)
            idColaborador_ = value
        End Set
    End Property

    Private usuarioCreo_ As Integer
    Public Property usuarioCreo() As Integer
        Get
            Return usuarioCreo_
        End Get
        Set(ByVal value As Integer)
            usuarioCreo_ = value
        End Set
    End Property

    Private usuarioModifico_ As Integer
    Public Property usuarioModifico() As Integer
        Get
            Return usuarioModifico_
        End Get
        Set(ByVal value As Integer)
            usuarioModifico_ = value
        End Set
    End Property

    Private fechaCreacion_ As String
    Public Property fechaCreacion() As String
        Get
            Return fechaCreacion_
        End Get
        Set(ByVal value As String)
            fechaCreacion_ = value
        End Set
    End Property

    Private fechaModificacion_ As String
    Public Property fechaModificacion() As String
        Get
            Return fechaModificacion_
        End Get
        Set(ByVal value As String)
            fechaModificacion_ = value
        End Set
    End Property

    Private idColaboradorSay_ As Integer
    Public Property idColaboradorSay() As Integer
        Get
            Return idColaboradorSay_
        End Get
        Set(ByVal value As Integer)
            idColaboradorSay_ = value
        End Set
    End Property

    Private id_ As Integer
    Public Property id() As Integer
        Get
            Return id_
        End Get
        Set(ByVal value As Integer)
            id_ = value
        End Set
    End Property


End Class
