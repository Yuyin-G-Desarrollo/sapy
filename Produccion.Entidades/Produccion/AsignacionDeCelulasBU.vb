Imports Produccion.Datos

Public Class AsignacionDeCelulasBU

    Public Function totalLotesPares(ByVal NaveId As Integer, ByVal FechaP As Date) As DataTable
        Dim objDA As New AsignacionDeCelulasDA
        Return objDA.totalLotesPares(NaveId, FechaP)
    End Function

    Public Function Celulas(ByVal NaveId As Integer, ByVal Celula As String) As DataTable
        Dim ObjCeluldaDA As New AsignacionDeCelulasDA
        Return ObjCeluldaDA.Celulas(NaveId, Celula)
    End Function

    Public Function departamentosNave(ByVal NaveId As Integer) As DataTable
        Dim objDepartamentosDA As New AsignacionDeCelulasDA
        Return objDepartamentosDA.departamentosNave(NaveId)
    End Function

    Public Function paresPorDepto(ByVal NaveId As Integer, ByVal Fecha As Date, ByVal DeptoId As Integer, ByVal Estado As String) As DataTable
        Dim objParesDepto As New AsignacionDeCelulasDA
        Return objParesDepto.paresPorDepto(NaveId, Fecha, DeptoId, Estado)
    End Function

    Public Function configuracionXNave(ByVal NaveId As Integer, ByVal FechaP As Date) As DataTable
        Dim obj As New AsignacionDeCelulasDA
        Return obj.configuracionXNave(NaveId, FechaP)
    End Function

    Public Function fechasEmbarque(ByVal NaveId As Integer, ByVal FechaP As Date) As DataTable
        Dim obj As New AsignacionDeCelulasDA
        Return obj.fechasEmbarque(NaveId, FechaP)
    End Function

    Public Function paresPorCelula(ByVal NaveId As Integer, ByVal Fecha As Date, ByVal DeptoId As Integer) As DataTable
        Dim objParesDepto As New AsignacionDeCelulasDA
        Return objParesDepto.paresPorCelula(NaveId, Fecha, DeptoId)
    End Function

    Public Function InsertaAvanceCelula(ByVal Año As Integer, ByVal NaveId As Integer, ByVal LoteId As Integer, ByVal IdConfiguracion As Integer,
                                        ByVal IdCelula As String, ByVal Pares As Integer, ByVal Estado As String) As DataTable
        Dim obj As New AsignacionDeCelulasDA
        Return obj.InsertaAvanceCelula(Año, NaveId, LoteId, IdConfiguracion, CInt(IdCelula), Pares, Estado)
    End Function

    Public Function ActualizaAvanceCelula(ByVal IdCelula As Integer, ByVal IdAvance As Integer) As DataTable
        Dim obj As New AsignacionDeCelulasDA
        Return obj.ActualizaAvanceCelula(CInt(IdCelula), IdAvance)
    End Function


End Class
