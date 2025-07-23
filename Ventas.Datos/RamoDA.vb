Imports Persistencia
Imports System.Data.SqlClient

Public Class RamoDA

    Public Function ListadoRamos() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT ramo_ramoid, LTRIM(RTRIM ( UPPER(ramo_nombre))) AS ramo_nombre, ramo_nombrecorto FROM Cliente.Ramos WHERE ramo_activo = 1 ORDER BY ramo_nombre"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    ''' <summary>
    ''' RECUPERA LOS RAMOS DE UNA DETERMINADO CLIENTE CUANDO SU MARCAJE SEA MAYOR A CERO Y ESTE ACTIVO
    ''' </summary>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LOS RAMOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaRamosPorCliente_con_Marcaje(ByVal IdCliente As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT racl_ramoclienteid AS 'Id_Ramo', LTRIM(RTRIM(ramo_nombre)) + ' - (' + CONVERT(varchar(4), racl_marcaje) + '%)' AS 'Ramo'   FROM CLIENTE.ClienteRamos" +
                                " JOIN Cliente.Ramos ON racl_ramoid = ramo_ramoid " +
                                " WHERE racl_clienteid = " + IdCliente.ToString + " AND racl_marcaje <> 0 AND racl_activo = 1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function recuperarRamoMarcaje(ByVal IdClienteRamo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select racl_marcaje from Cliente.ClienteRamos WHERE racl_ramoclienteid = " + IdClienteRamo.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
