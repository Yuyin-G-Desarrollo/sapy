Imports System.Data.SqlClient

Public Class CatalogoSalariosMinimos_UmasDA


    '''<comentario>
    ''' Obtiene los lotes pilotos de la nave por rango de fechas
    '''</comentario>
    '''<parametro1>FechaInicio</parametro1>
    '''<parametro1>FechaFin</parametro1>
    '''<parametro1>Nave</parametro1>
    '''<retorno>Objeto DataTable</retorno>
    '''
    Public Function ConsultaPrecio_SalarioMIN_UMA() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Consulta_Opciones_SalMin_UMA]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaBitacoraPrecio_SalarioMIN_UMA() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ConsultaBitacora_SalariosMin_UMA]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ModificarPrecio_SalarioMIN_UMA(ByVal MontoSalarioMinimo As String, ByVal MontoUMA As String, ByVal MontoUMI As String, ByVal ColaboradorID As String, ByVal FechaMoificacion As DateTime, ByVal anio As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@MontoSalarioMinimo"
            parametro.Value = MontoSalarioMinimo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MontoUMA"
            parametro.Value = MontoUMA
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MontoUMI"
            parametro.Value = MontoUMI
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ColaboradorID"
            parametro.Value = ColaboradorID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaModificacion"
            parametro.Value = FechaMoificacion
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_ModificarPrecio_SalMin_UMA]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
