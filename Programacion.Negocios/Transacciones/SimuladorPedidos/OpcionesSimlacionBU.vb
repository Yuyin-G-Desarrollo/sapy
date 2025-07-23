Public Class OpcionesSimlacionBU

    Public Function consultaClasificaciones() As DataTable
        Dim objDA As New Datos.OpcionesSimlacionDA
        Return objDA.consultaClasificaciones
    End Function

    Public Function verClientesClasificacionRealYConfigurada(ByVal idSimulacion As Int32, ByVal clasificacion As String) As DataTable
        Dim objDA As New Datos.OpcionesSimlacionDA
        Return objDA.verClientesClasificacionRealYConfigurada(idSimulacion, clasificacion)
    End Function

    Public Function consultaClientesConfigurados(ByVal idSimulacion As Int32, ByVal clasificacion As String) As DataTable
        Dim objBU As New Datos.OpcionesSimlacionDA
        Return objBU.consultaClientesConfigurados(idSimulacion, clasificacion)
    End Function

    Public Sub cambiarConfiguracionClasRanking(ByVal idSimulacion As Int32, ByVal idCliente As Int32,
                                                ByVal idCadena As Int32, ByVal Clasificacion As String,
                                                ByVal Ranking As Int32, ByVal ClasificacionReal As String,
                                                ByVal RankingReal As Int32)
        Dim objDA As New Datos.OpcionesSimlacionDA
        objDA.cambiarConfiguracionClasRanking(idSimulacion, idCliente, idCadena, Clasificacion, Ranking, ClasificacionReal, RankingReal)
    End Sub

    Public Function consultaClasificacionCliente(ByVal idSimulacion As Int32) As DataTable
        Dim objBU As New Datos.OpcionesSimlacionDA
        Return objBU.consultaClasificacionCliente(idSimulacion)
    End Function

End Class
