Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Entidades
Public Class AvancesProduccionSuelaDA
    Public Function ObtieneColaborador(ByVal pClColaborador As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClColaborador"
            parametro.Value = pClColaborador
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccionSuelas_Colaborador]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtieneEncabezado(ByVal pFolio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Folio"
            parametro.Value = pFolio
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccionSuelas_Encabezado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ObtieneAvances(ByVal pFolio As String, ByVal pMaquina As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Folio"
            parametro.Value = pFolio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumMaquina"
            parametro.Value = pMaquina
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccionSuelas_Avances]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtieneMaquinasProduccion(ByVal pNaveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveId"
            parametro.Value = pNaveId
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccionSuelas_MaquinasProduccion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardaAvancesProduccion(ByVal Maquina As Integer, ByVal IdColaborador As Integer, ByVal xmlAvances As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Maquina"
            parametro.Value = Maquina
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdColaborador"
            parametro.Value = IdColaborador
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@xmlAvances"
            parametro.Value = xmlAvances
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccionSuelas_GuardaAvances]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtieneUltimoAvance(ByVal pFolio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Folio"
            parametro.Value = pFolio
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_AvancesProduccionSuelas_UltimoAvance]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
