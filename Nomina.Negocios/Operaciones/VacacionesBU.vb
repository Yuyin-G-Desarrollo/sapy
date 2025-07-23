Imports Entidades
Imports Nomina.Datos
Public Class VacacionesBU
    Public Function ListaPercepcionesCarta(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDa As New Datos.VacacionesDA
        Return objDa.ListaPercepcionesCarta(Filtros)
    End Function
    Public Function CalculoPercepcionesLista(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.CalculoPercepcionesLista(Filtros)
    End Function
    Public Function CalculoPercepcionesAgregar(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.CalculoPercepcionesAgregar(Filtros)
    End Function
    Public Function ValidarStatusAguinaldoVacaciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.ValidarStatusAguinaldoVacaciones(Filtros)
    End Function
    Public Function AutorizarPercepciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.AutorizarPercepciones(Filtros)
    End Function
    Public Function ResumenAguinaldoVacaciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.ResumenAguinaldoVacaciones(Filtros)
    End Function
    Public Function ConsultaChquesAguinaldoVacaciones(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.ConsultaChquesAguinaldoVacaciones(Filtros)
    End Function

    Public Function ValidarTimbrado(ByVal Filtros As Entidades.FiltrosCalculoPercepciones)
        Dim objDA As New Datos.VacacionesDA
        Return objDA.ValidarTimbrado(Filtros)
    End Function

End Class
