Imports Persistencia
Imports System.Data.SqlClient

Public Class ExcepcionMotivoDA

    Public Function listaMotivoExcepcion(ByVal naveID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.ExcepcionMotivo WHERE exmot_naveid = " + naveID.ToString


        Return opereciones.EjecutaConsulta(consulta)

    End Function


    Public Function listaIncentivosSegunMotivo(ByVal motivoID As Integer) As DataTable

        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM ControlAsistencia.ExcepcionMotivo WHERE exmot_id = " + motivoID.ToString

        Return opereciones.EjecutaConsulta(consulta)

    End Function


End Class
