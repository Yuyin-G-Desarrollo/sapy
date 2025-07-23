Imports Produccion.Datos

Public Class CelulaBandaBU
    Public Function updateAvance(ByVal idLoteAvance As Integer, ByVal idCelula As Integer) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.updateAvance(idLoteAvance, idCelula)
    End Function
    Public Function insertAvance(ByVal idNaveSICY As Integer, ByVal año As Integer, ByVal idDep As Integer, ByVal idCelula As Integer,
                                 ByVal pares As Integer, ByVal estado As String, ByVal lote As Integer) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.insertAvance(idNaveSICY, año, idDep, idCelula, pares, estado, lote)
    End Function
    Public Function getTotalCelulasyBandas(ByVal idNaveSICY As Integer, ByVal fecha As Date, ByVal idDep As Integer) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getTotalCelulasyBandas(idNaveSICY, fecha, idDep)
    End Function
    Public Function getFechasEmbarque(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getFechasEmbarque(idNaveSICY, fecha)
    End Function
    Public Function getConfiguracion(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getConfiguracion(idNaveSICY, fecha)
    End Function
    Public Function getDatosLotes(ByVal idNaveSICY As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getDatosLotes(idNaveSICY, fecha)
    End Function
    Public Function getCelulasBandasDep(ByVal idDep As Integer) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getCelulasBandasDep(idDep)
    End Function
    Public Function getParesxEmbarque(ByVal idNave As Integer, ByVal fecha As Date, ByVal estado As String) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getParesxEmbarque(idNave, fecha, estado)
    End Function
    Public Function getParesxDepartamento(ByVal idNave As Integer, ByVal fecha As Date, ByVal idDep As Integer, ByVal estado As String) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getParesxDepartamento(idNave, fecha, idDep, estado)
    End Function
    Public Function getDepartamentosXNave(ByVal idNave As Integer) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getDepartamentosXNave(idNave)
    End Function

    Public Function getLotesyPares(ByVal idNave As Integer, ByVal fecha As Date) As DataTable
        Dim obj As New CelulaBandaDA
        Return obj.getLotesyPares(idNave, fecha)
    End Function


End Class
