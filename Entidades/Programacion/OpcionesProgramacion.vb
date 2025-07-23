Public Class OpcionesProgramacion
    Dim idOpciones As Integer
    Dim descripcionOpciones As String
    Dim opcionNumericoUno As Double
    Dim opcionNumericoDos As Double
    Dim opcionValorEntero As Integer
    Dim opcionFecha As Date
    Dim opcionCadena As String
    Dim opcionValorBooleano As Boolean


    Public Property pidOpciones As Integer
        Get
            Return idOpciones
        End Get
        Set(value As Integer)
            idOpciones = value
        End Set
    End Property
    Public Property pdescripcionOpciones As String
        Get
            Return descripcionOpciones
        End Get
        Set(value As String)
            descripcionOpciones = value
        End Set
    End Property
    Public Property popcionNumericoUno As Double
        Get
            Return opcionNumericoUno
        End Get
        Set(value As Double)
            opcionNumericoUno = value
        End Set
    End Property
    Public Property popcionNumericoDos As Double
        Get
            Return opcionNumericoDos
        End Get
        Set(value As Double)
            opcionNumericoDos = value
        End Set
    End Property
    Public Property popcionValorEntero As Integer
        Get
            Return opcionValorEntero
        End Get
        Set(value As Integer)
            opcionValorEntero = value
        End Set
    End Property
    Public Property popcionFecha As Date
        Get
            Return opcionFecha
        End Get
        Set(value As Date)
            opcionFecha = value
        End Set
    End Property
    Public Property popcionCadena As String
        Get
            Return opcionCadena
        End Get
        Set(value As String)
            opcionCadena = value
        End Set
    End Property
    Public Property popcionValorBooleano As Boolean
        Get
            Return opcionValorBooleano
        End Get
        Set(value As Boolean)
            opcionValorBooleano = value
        End Set
    End Property

End Class
