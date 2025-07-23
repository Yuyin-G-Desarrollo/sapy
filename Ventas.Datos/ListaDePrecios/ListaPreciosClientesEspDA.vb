Public Class ListaPreciosClientesEspDA

    Public Function buscarClientesNombreComercial(ByVal clienteID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "" +
                                " SELECT" +
                                " pers_personaid," +
                                " clie_clienteid," +
                                    " UPPER(clie_statuscliente) As clie_statuscliente," +
                                " LTRIM(RTrim(UPPER(clie_nombregenerico))) As clie_nombregenerico," +
                                " clie_clasificacionpersonaid," +
                                " UPPER(clie_razonsocial) As clie_razonsocial," +
                                    " clie_ranking," +
                                    " clie_fechacreacion," +
                                    " iccl_incrementopar_porcent," +
                                    " iccl_incrementopar_monto," +
                                    " clie_precioespecial" +
                                    " FROM Framework.Persona" +
                            " INNER JOIN Cliente.Cliente" +
                                " ON clie_personaidcliente = pers_personaid" +
                            " INNER JOIN Cobranza.InfoCliente" +
                                " ON clie_clienteid=iccl_clienteid" +
                                    " WHERE clie_activo = 1"

        If clienteID > 0 Then
            consulta += " AND clie_clienteid = " + clienteID.ToString
        End If

        consulta += " ORDER BY clie_nombregenerico"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

End Class
