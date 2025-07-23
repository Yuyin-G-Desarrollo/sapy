Imports System.Data.SqlClient

Public Class ReportePartidasParesProcesoDA

    Public Function consultaDatosPartidas(ByVal Estatus As String, ByVal EnProceso As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@status"
        parametro.Value = Estatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ParesEnProceso"
        parametro.Value = EnProceso
        listaParametros.Add(parametro)


        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_ConsultaCompraInicial_PartidasConParesEnProceso", listaParametros)

        Return dtResultadoConsulta

    End Function
End Class
