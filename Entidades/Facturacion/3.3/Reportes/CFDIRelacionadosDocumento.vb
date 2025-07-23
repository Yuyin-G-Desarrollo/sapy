Public Class CFDIRelacionadosDocumento

    Private PClaveCFDI As String
    Public Property ClaveCFDI() As String
        Get
            Return PClaveCFDI
        End Get
        Set(ByVal value As String)
            PClaveCFDI = value
        End Set
    End Property

    Private PTipoRelacion As String
    Public Property TipoRelacion() As String
        Get
            Return PTipoRelacion
        End Get
        Set(ByVal value As String)
            PTipoRelacion = value
        End Set
    End Property

    Private PCFDIRelacionado As String
    Public Property CFDIRelacionado() As String
        Get
            Return PCFDIRelacionado
        End Get
        Set(ByVal value As String)
            PCFDIRelacionado = value
        End Set
    End Property

End Class
