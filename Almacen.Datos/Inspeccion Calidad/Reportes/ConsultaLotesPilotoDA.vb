Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class ConsultaLotesPilotoDA


    '''<comentario>
    ''' Obtiene los lotes pilotos de la nave por rango de fechas
    '''</comentario>
    '''<parametro1>FechaInicio</parametro1>
    '''<parametro1>FechaFin</parametro1>
    '''<parametro1>Nave</parametro1>
    '''<retorno>Objeto DataTable</retorno>
    Public Function ConsultarLotesPiloto(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Nave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_InspeccionCalidad_Reporte_ConsultaLotesPiloto]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
