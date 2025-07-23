Public Class Percepciones

    Private Colaborador As Colaborador
    Private Prestamos As SolicitudPrestamo
    Private Cobranza As CobranzaPrestamos


    Private TotalPercepciones As Double
    Private PersepcionTipo As Integer
    Private ConceptoPersepcion As String
    Private MontoPersepcion As Double
    Private idCreo As Integer


    Public Property PTotalPercepciones As Double
        Get
            Return TotalPercepciones
        End Get
        Set(ByVal value As Double)
            TotalPercepciones = value
        End Set
    End Property


    Public Property PidCreo As Integer
        Get
            Return idCreo
        End Get
        Set(ByVal value As Integer)
            idCreo = value
        End Set
    End Property


    Public Property PConceptoPercepcion As String
        Get
            Return ConceptoPersepcion

        End Get
        Set(ByVal value As String)
            ConceptoPersepcion = value
        End Set
    End Property


    Public Property PMontoPercepcion As Double
        Get
            Return MontoPersepcion
        End Get
        Set(ByVal value As Double)
            MontoPersepcion = value
        End Set
    End Property


    Public Property PColaborador As Colaborador
        Get
            Return Colaborador
        End Get
        Set(ByVal value As Colaborador)
            Colaborador = value
        End Set
    End Property



    Public Property PCobranza As CobranzaPrestamos
        Get
            Return Cobranza
        End Get
        Set(ByVal value As CobranzaPrestamos)
            Cobranza = value
        End Set
    End Property



    Public Property PPercepcionTipo As Integer
        Get
            Return PersepcionTipo
        End Get
        Set(ByVal value As Integer)
            PersepcionTipo = value
        End Set
    End Property


    Public Property PPrestamos As SolicitudPrestamo
        Get
            Return Prestamos
        End Get
        Set(ByVal value As SolicitudPrestamo)
            Prestamos = value
        End Set
    End Property


End Class
