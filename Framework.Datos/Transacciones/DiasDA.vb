Public Class DiasDA


    Public Function TablaDias() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                " dias_diaid" +
                                " , LTRIM(RTRIM(UPPER(dias_nombre))) AS dias_nombre" +
                                " FROM Framework.Dias" +
                                " ORDER BY dias_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
