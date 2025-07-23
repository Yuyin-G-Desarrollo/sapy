Imports Persistencia
Imports System.Data.SqlClient

Public Class EmpresasDA

    Public Function ListaEmpresas() As DataTable

        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT empr_empresaid, LTRIM(RTRIM ( UPPER(empr_nombre))) AS empr_nombre FROM Framework.Empresas WHERE empr_activo = 1 and empr_arrendamiento = 0 ORDER BY empr_nombre"

        Return objOperaciones.EjecutaConsulta(consulta)

    End Function


End Class
