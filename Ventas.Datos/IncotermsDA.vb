Public Class IncotermsDA

    Public Function listadoIncoterms() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT inco_incotermsid, CAST(LTRIM(RTRIM(UPPER(inco_claveincoterm))) + ' - ' + LTRIM(RTRIM(UPPER(inco_nombre))) AS VARCHAR(250)) AS inco_nombre FROM Embarque.INCOTERMS ORDER BY inco_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
