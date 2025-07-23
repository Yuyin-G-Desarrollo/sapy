Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class CatalogosInsidenciasDA
    Public Function ConsultarInsidencias(ByVal Status As Integer, ByVal depa As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@status"
            parametro.Value = Status
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@departamento"
            parametro.Value = depa
            listaParametros.Add(parametro)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Catalogo_Incidencias_Consulta_Incidencias]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function AgregarIncidencias(ByVal entidad As Entidades.CatalogoInsidencias) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@incidencia "
            parametro.Value = entidad.Incidencias
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@departamento"
            parametro.Value = entidad.Departamento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = Convert.ToDateTime(entidad.Fecha)
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = entidad.Usuario
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Catalogo_Incidencias_Agrega_Incidencias]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EditarIncidencias(ByVal entidad As Entidades.CatalogoInsidencias) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@incidencia "
            parametro.Value = entidad.Incidencias
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ID_Incidencia"
            parametro.Value = entidad.IDIncidencias
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@departamento"
            parametro.Value = entidad.Departamento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = Convert.ToDateTime(entidad.Fecha)
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = entidad.Usuario
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Catalogo_Incidencias_Editar_Incidencia]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ModificarEstatusInsidencias(ByVal cadena As String, ByVal usuario As Int16, ByVal status As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ID_Incidencia"
            parametro.Value = cadena
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@status"
            parametro.Value = status
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Catalogo_Incidencias_Modificar_Estatus_Incidencias]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerDepartamentos() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Try
            Return objPersistencia.EjecutaConsulta("Select insp_departamentoid as ID, insp_departamento as Nombre from Almacen.TBL_InspeccionCalidad_Departamento where insp_activo=1 ORDER by insp_departamento ASC")
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
