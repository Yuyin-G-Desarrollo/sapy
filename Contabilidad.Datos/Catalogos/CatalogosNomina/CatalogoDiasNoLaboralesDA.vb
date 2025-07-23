Imports System.Data.SqlClient

Public Class CatalogoDiasNoLaboralesDA


    Public Function consultaDiasNoLaborales(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_Catalogos_DiasNoLaborables_Consulta]", listaParametros)
    End Function


    Public Function InsertarDiaNoLAboral(ByVal dia As Entidades.DiasNoLaborales) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = dia.Fecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = dia.Anio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = dia.Usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@descripcion"
            parametro.Value = dia.Descripción
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NF_Alta_DiaFestivo]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function consultaPeridoVacaciones(ByVal anio As Int32, ByVal patron As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "@patron"
        parametro.Value = patron
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_ConsultarPeriodoVacacional]", listaParametros)
    End Function

    Public Function InsertarVacaciones(ByVal dia As Entidades.DiasNoLaborales) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@patron"
            parametro.Value = dia.Mensaje
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechainicioSS"
            parametro.Value = dia.FechaISS
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechafinSS"
            parametro.Value = dia.FechaFSS
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechainicioN"
            parametro.Value = dia.FechaIN
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechafinN"
            parametro.Value = dia.FechaFN
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = dia.Anio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = dia.Usuario
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NF_Alta_SemanaVacacional]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function EditarVacaciones(ByVal dia As Entidades.DiasNoLaborales) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@idPeriodo"
            parametro.Value = dia.ID_Dia
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechainicioSS"
            parametro.Value = dia.FechaISS
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechafinSS"
            parametro.Value = dia.FechaFSS
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechainicioN"
            parametro.Value = dia.FechaIN
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechafinN"
            parametro.Value = dia.FechaFN
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = dia.Usuario
            listaParametros.Add(parametro)



            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_EditarPeriodoVacacional]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function descripcionDias() As DataTable
        Try
            Dim objPersistencia As New Persistencia.OperacionesProcedimientos
            Return objPersistencia.EjecutaConsulta(" Select  DISTINCT isNull(dnl.dinl_descripcion,'') as Descripcion FROM Contabilidad.DiasNoLaborables dnl")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function patrones(ByVal anio As Integer) As DataTable
        Try
            Dim objPersistencia As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = anio
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Consulta_De_Patrones]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function periodoCerrado(ByVal fechainicio As Date, ByVal fechaFin As Date, idPeriodo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechainicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@periodoId"
            parametro.Value = idPeriodo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_NF_PeriodoNominaFiscal]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function EditarDiasNoLaborables(ByVal fechaAnterior As Date, ByVal fechaEditada As Date, ByVal descripcion As String, ByVal usuario As Integer, ByVal accion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaAnterior"
        parametro.Value = fechaAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaEditada"
        parametro.Value = fechaEditada
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioM"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descripcion"
        parametro.Value = descripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_Editar_DiaFestivo]", listaParametros)
    End Function

End Class
