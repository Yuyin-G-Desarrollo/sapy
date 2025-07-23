Public Class TipoPoliza

    Private Ppolizatipoid As Integer
    Public Property polizatipoid() As Integer
        Get
            Return Ppolizatipoid
        End Get
        Set(ByVal value As Integer)
            Ppolizatipoid = value
        End Set
    End Property

    Private Pnombre As String
    Public Property nombre() As String
        Get
            Return Pnombre
        End Get
        Set(ByVal value As String)
            Pnombre = value
        End Set
    End Property

    Private Pstatus As Boolean
    Public Property status() As Boolean
        Get
            Return Pstatus
        End Get
        Set(ByVal value As Boolean)
            Pstatus = value
        End Set
    End Property


End Class
