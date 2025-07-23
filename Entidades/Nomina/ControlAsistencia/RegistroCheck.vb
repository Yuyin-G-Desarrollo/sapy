Imports Entidades

Public Class RegistroCheck

    Private regcheck_id As Integer
    Private regcheck_nave As Naves
    Private regcheck_normal As DateTime
    Private regcheck_automatico As DateTime
    Private regcheck_manual As DateTime
    Private regcheck_colaborador As Colaborador
    Private regcheck_departamento As Departamentos
    Private regcheck_resultado As Integer
    Private regcheck_tipo_check As Integer
    Private regcheck_excepcion As RegistroExcepciones
    Private regcheck_nota As String
    Private regcheck_tipos As String

    Public Property PId() As Integer
        Get
            Return regcheck_id
        End Get
        Set(ByVal value As Integer)
            regcheck_id = value
        End Set
    End Property

    Public Property Pregcheck_nave() As Naves
        Get
            Return regcheck_nave
        End Get
        Set(ByVal value As Naves)
            regcheck_nave = value
        End Set
    End Property

    Public Property PCheck_normal() As DateTime
        Get
            Return regcheck_normal
        End Get
        Set(ByVal value As DateTime)
            regcheck_normal = value
        End Set
    End Property

    Public Property PCheck_automatico() As DateTime
        Get
            Return regcheck_automatico
        End Get
        Set(ByVal value As DateTime)
            regcheck_automatico = value
        End Set
    End Property

    Public Property PCheck_manual() As DateTime
        Get
            Return regcheck_manual
        End Get
        Set(ByVal value As DateTime)
            regcheck_manual = value
        End Set
    End Property

    Public Property PCheck_Colaborador() As Colaborador
        Get
            Return regcheck_colaborador
        End Get
        Set(ByVal value As Colaborador)
            regcheck_colaborador = value
        End Set
    End Property

    Public Property Pregcheck_departamento() As Departamentos
        Get
            Return regcheck_departamento
        End Get
        Set(ByVal value As Departamentos)
            regcheck_departamento = value
        End Set
    End Property

    Public Property PCheck_Resultado() As Integer
        Get
            Return regcheck_resultado
        End Get
        Set(ByVal value As Integer)
            regcheck_resultado = value
        End Set
    End Property

    Public Property PCheck_Tipo() As Integer
        Get
            Return regcheck_tipo_check
        End Get
        Set(ByVal value As Integer)
            regcheck_tipo_check = value
        End Set
    End Property

    Public Property PCheck_Excepcion() As RegistroExcepciones
        Get
            Return regcheck_excepcion
        End Get
        Set(ByVal value As RegistroExcepciones)
            regcheck_excepcion = value
        End Set
    End Property

    Public Property PCheck_Nota() As String
        Get
            Return regcheck_nota
        End Get
        Set(ByVal value As String)
            regcheck_nota = value
        End Set
    End Property


    Public Property PRegcheck_Tipos As String
        Get
            Return regcheck_tipos
        End Get
        Set(ByVal value As String)
            regcheck_tipos = value
        End Set
    End Property

End Class
