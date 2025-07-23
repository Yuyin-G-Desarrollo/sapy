Public Class UtileriaDA
    Public Function obtenerMesActual() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT CONVERT(VARCHAR(150), (CASE MONTH(GETDATE()) " & vbCrLf & _
            "WHEN 1 THEN 'ENERO' WHEN 2 THEN 'FEBRERO' WHEN 3 THEN 'MARZO' " & vbCrLf & _
            "WHEN 4 THEN 'ABRIL' WHEN 5 THEN 'MAYO' WHEN 6 THEN 'JUNIO' " & vbCrLf & _
            "WHEN 7 THEN 'JULIO' WHEN 8 THEN 'AGOSTO' WHEN 9 THEN 'SEPTIEMBRE' " & vbCrLf & _
            "WHEN 10 THEN 'OCTUBRE' WHEN 11 THEN 'NOVIEMBRE'  ELSE 'DICIEMBRE' END)) " & vbCrLf & _
            "+ ' ' + CONVERT(VARCHAR(150), (YEAR(GETDATE()))) MESACTUAL "

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerAnioActual() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT YEAR(GETDATE()) ANIOACTUAL "

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerMesActualNum() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT REPLACE(STR(DATEPART(mm, GETDATE()), 2), ' ', '0') MESACTUAL"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerFechaActual() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select CAST(getdate() AS DATE) as FechaActual"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerLocalizacion(ByVal ciudadId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT ISNULL(c.city_nombre, '') ciudad, " & _
                    "ISNULL(e.esta_nombre, '') estado, " & _
                    "ISNULL(p.pais_nombre , '') pais " & _
                    "FROM Framework.Ciudades c " & _
                    "LEFT JOIN Framework.Estados e ON e.esta_estadoid = c.city_estadoid " & _
                    "LEFT JOIN Framework.Paises p ON p.pais_paisid = e.esta_paisid " & _
                    "WHERE c.city_ciudadid = " & ciudadId
        Return operacion.EjecutaConsulta(consulta)
    End Function
End Class
