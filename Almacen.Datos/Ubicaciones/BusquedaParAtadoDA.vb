Public Class BusquedaParAtadoDA

    Public Function buscarClientesNombreComercial(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                "   pers_personaid" +
                                " , clie_clienteid" +
                                " , UPPER(clie_statuscliente) AS clie_statuscliente" +
                                " , LTRIM(RTRIM ( UPPER(clie_nombregenerico))) AS clie_nombregenerico" +
                                " , clie_clasificacionpersonaid" +
                                " , UPPER(clie_razonsocial) AS clie_razonsocial" +
                                " , clie_ranking" +
                                " , clie_fechacreacion " +
                                " FROM Framework.Persona" +
                                " JOIN Cliente.Cliente ON clie_personaidcliente = pers_personaid"

        If clienteID > 0 Then
            consulta += " WHERE clie_clienteid = " + clienteID.ToString
        End If

        consulta += " ORDER BY clie_nombregenerico"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
