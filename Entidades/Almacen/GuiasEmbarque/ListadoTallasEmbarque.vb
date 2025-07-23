Imports Entidades

Public Class ListadoTallasEmbarque

    Private _listaTallas As List(Of TallasEmbarques)
    Private _errorTallas As ErrorEmbarque

    Public Property ListaTallas As List(Of TallasEmbarques)
        Get
            Return _listaTallas
        End Get
        Set(value As List(Of TallasEmbarques))
            _listaTallas = value
        End Set
    End Property

    Public Property ErrorTallas As ErrorEmbarque
        Get
            Return _errorTallas
        End Get
        Set(value As ErrorEmbarque)
            _errorTallas = value
        End Set
    End Property
End Class
