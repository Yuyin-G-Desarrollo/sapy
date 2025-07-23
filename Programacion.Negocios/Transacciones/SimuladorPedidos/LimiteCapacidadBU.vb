Public Class LimiteCapacidadBU

    Public Function consultaLineaLimiteCapacidadAnio(ByVal idLinea As Int32, ByVal anio As Int32, ByVal simulacion As Int32) As DataTable
        Dim objDA As New Datos.LimiteCapacidadDA
        Return objDA.consultaLineaLimiteCapacidadAnio(idLinea, anio, simulacion)
    End Function

    Public Sub guardardarLimiteCapacidadLinea(ByVal entLimiteCap As Entidades.LimiteCapacidad)
        Dim objDA As New Datos.LimiteCapacidadDA
        objDA.guardardarLimiteCapacidadLinea(entLimiteCap)
    End Sub
End Class
