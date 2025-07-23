Imports System.Data.SqlClient

Public Class CatalogosEstadisticaVentasDA

    Public Function AgregarCalendarioSemana(ByVal cadena As String, ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "Cadena"
        parametro.Value = cadena
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AnioIn"
        parametro.Value = anio
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_CalendarioSemanal_InsertarSemanas]", listaparametros)
    End Function

    Public Function ConsultarCalendarioSemana(ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Catalogo_CalendarioSemanal_ConsultarSemanas]", listaparametros)
    End Function

    Public Function ConsultarPProyecion(ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Catalogo_ProyeccionProduccion_ConsultarProyeccion]", listaparametros)
    End Function


    Public Function AgregarPProduccion(ByVal cadena As String, ByVal anio As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "Cadena"
        parametro.Value = cadena
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AnioIn"
        parametro.Value = anio
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Catalogo_ProyeccionProduccion_InsertarProyeccion]", listaparametros)
    End Function


End Class
