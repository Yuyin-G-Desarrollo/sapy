Imports Entidades

Public Class NivelDocumentos

    Private _Documento As Integer
    Private _Nivel As Integer
    Private _Embarque As Integer
    Private _TotalNivel As Integer
    Private _Error As ErrorEmbarque

    Public Property Documento As Integer
        Get
            Return _Documento
        End Get
        Set(value As Integer)
            _Documento = value
        End Set
    End Property

    Public Property Nivel As Integer
        Get
            Return _Nivel
        End Get
        Set(value As Integer)
            _Nivel = value
        End Set
    End Property

    Public Property Embarque As Integer
        Get
            Return _Embarque
        End Get
        Set(value As Integer)
            _Embarque = value
        End Set
    End Property

    Public Property [Error] As ErrorEmbarque
        Get
            Return _Error
        End Get
        Set(value As ErrorEmbarque)
            _Error = value
        End Set
    End Property

    Public Property TotalNivel As Integer
        Get
            Return _TotalNivel
        End Get
        Set(value As Integer)
            _TotalNivel = value
        End Set
    End Property
End Class
