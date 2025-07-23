Public Class RutaDA

    Public Function ListadoRutas() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT ruta_rutaid, LTRIM(RTRIM ( UPPER(ruta_nombre))) AS ruta_nombre FROM Ventas.Rutas WHERE ruta_activo = 1 ORDER BY ruta_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
