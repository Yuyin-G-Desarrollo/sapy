Imports System.Data.SqlClient
Imports Entidades

Public Class ProyeccionMaterialDA

    Public Function ObtieneProyeccionMaterialAnual(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_Anual]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_Anual_Prueba]", listaparametros)

    End Function
    Public Function ObtieneProyeccionMaterialAnualColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_AnualColeccion]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_AnualColeccion_Prueba]", listaparametros)

    End Function


    Public Function ObtieneProyeccionMaterialMensual(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMes]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMes_Prueba]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialMensualColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMesColeccion]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMesColeccion_Prueba]", listaparametros)

    End Function


    Public Function ObtieneProyeccionMaterialSemanal(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales]", listaparametros)
        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemana]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemana_Prueba]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialSemanalColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemanaColeccion]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemanaColeccion_Prueba]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialPrograma(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorPrograma]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorPrograma_Prueba]", listaparametros)
    End Function

    Public Function ObtieneProyeccionMaterialProgramaColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorProgramaColeccion]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorProgramaColeccion_Prueba]", listaparametros)
    End Function


    Public Function ObtieneConsultaFiltro(ByVal pTipoConsulta As Integer, ByVal pIdNave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoConsulta"
        parametro.Value = pTipoConsulta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Produccion_ConsultasFiltros]", listaparametros)
    End Function

    Public Function ObtieneExplosionMateriales(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaExplosionMateriales_Reporte]", listaparametros)
    End Function
    '...........................................................................

    Public Function ObtieneProyeccionMaterialAnualLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_AnualLoteado]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_AnualLoteado_Prueba]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialMensualLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMesLoteado]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMesLoteado_Prueba]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialSemanalLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemanaLoteado]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemanaLoteado_Prueba]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialProgramaLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorProgramaLoteado]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorProgramaLoteado_Prueba]", listaparametros)

    End Function

    Public Function ObtieneExplosionMaterialesLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaExplosionMateriales_ReporteLoteado]", listaparametros)
    End Function

    Public Function ObtieneProyeccionMaterialTallas(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTalla]", listaparametros)
        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTalla_Corregir]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTalla_CorregirV2]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialTallasColeccion(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaColeccion]", listaparametros)
        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaColeccion_Corregir]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaColeccion_CorregirV2]", listaparametros)
    End Function

    Public Function ObtieneProyeccionMaterialTallasLoteado(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaLoteado]", listaparametros)
        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaLoteado_Corregir]", listaparametros)
        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaLoteado_CorregirV2]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialProgramaLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorProgramaLote]", listaparametros)
    End Function

    Public Function ObtieneProyeccionMaterialSemanalLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemanaLote]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialMensualLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorMesLote]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialAnualLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_AnualLote]", listaparametros)

    End Function

    Public Function ObtieneProyeccionMaterialTallasLote(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdColeccion As String, ByVal pIdModelo As String, ByVal pPielColor As String, ByVal pIdCorrida As String, ByVal pIdProveedor As String, ByVal pIdClasificacion As String, ByVal CriticosDias As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = pFechaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = pFechaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        parametro.Value = pIdModelo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PielColor"
        parametro.Value = pPielColor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proveedor"
        parametro.Value = pIdProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Clasificacion"
        parametro.Value = pIdClasificacion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CriticosDias"
        parametro.Value = CriticosDias
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorTallaLote]", listaparametros)

    End Function

    Public Function ReporteProyeccionMateriales(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pClasificacion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@Nave",
                .Value = pIdNave
            },
            New SqlParameter With {
                .ParameterName = "@FechaInicio",
                .Value = pFechaInicio
            },
            New SqlParameter With {
                .ParameterName = "@FechaFin",
                .Value = pFechaFin
            },
            New SqlParameter With {
                .ParameterName = "@Clasificacion",
                .Value = pClasificacion
            }
        }

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaProyeccionMateriales_PorSemana_Reporte]", listaparametros)
    End Function

    Public Function ReporteProyeccionMaterialesSinteticosCorte(ByVal pIdNave As Integer, ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pClasificacion As String, ByVal semana As Integer, ByVal anio As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@Nave",
                .Value = pIdNave
            },
            New SqlParameter With {
                .ParameterName = "@FechaInicio",
                .Value = pFechaInicio
            },
            New SqlParameter With {
                .ParameterName = "@FechaFin",
                .Value = pFechaFin
            },
            New SqlParameter With {
                .ParameterName = "@Clasificacion",
                .Value = pClasificacion
            },
            New SqlParameter With {
                .ParameterName = "@semana",
                .Value = semana
            },
            New SqlParameter With {
                .ParameterName = "@anio",
                .Value = anio
            }
        }

        Return operacion.EjecutarConsultaSP("[Produccion].[ValidarSiExiste_ExplosionMaterialesSinteticosCorteSinIVA]", listaparametros)
    End Function

    Public Function ObtenerFEchaInicioFin(ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@Semana",
                .Value = Semana
            },
            New SqlParameter With {
                .ParameterName = "@Año",
                .Value = Año
            }
        }

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_CalendarioSemana]", listaparametros)
    End Function

    Public Function GenerarReporteExplosionMaterialesDirectosSinIVA(ByVal pIdNave As Integer,
                                                                    ByVal pFechaInicio As Date,
                                                                    ByVal pFechaFin As Date,
                                                                    ByVal Accion As Integer,
                                                                    ByVal NumeroSemana As Integer,
                                                                    ByVal AnioConsulta As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@Nave",
                .Value = pIdNave
            },
            New SqlParameter With {
                .ParameterName = "@FechaInicio",
                .Value = pFechaInicio
            },
            New SqlParameter With {
                .ParameterName = "@FechaFin",
                .Value = pFechaFin
            },
            New SqlParameter With {
                .ParameterName = "@Accion",
                .Value = Accion
            },
            New SqlParameter With {
                .ParameterName = "@NumeroSemana",
                .Value = NumeroSemana
            },
            New SqlParameter With {
                .ParameterName = "@AnioConsulta",
                .Value = AnioConsulta
            },
            New SqlParameter With {
                .ParameterName = "@UsuarioConsulta",
                .Value = SesionUsuario.UsuarioSesion.PUserUsername.ToString()
            }
        }

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ProyeccionMateriales_ConsultarExplosionMaterialDirectosSinIVA]", listaparametros)
    End Function

    Public Function GenerarReporteExplosionMaterialesDirectosConIVA(ByVal pIdNave As Integer,
                                                                ByVal pFechaInicio As Date,
                                                                ByVal pFechaFin As Date,
                                                                ByVal Accion As Integer,
                                                                ByVal NumeroSemana As Integer,
                                                                ByVal AnioConsulta As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@Nave",
                .Value = pIdNave
            },
            New SqlParameter With {
                .ParameterName = "@FechaInicio",
                .Value = pFechaInicio
            },
            New SqlParameter With {
                .ParameterName = "@FechaFin",
                .Value = pFechaFin
            },
            New SqlParameter With {
                .ParameterName = "@Accion",
                .Value = Accion
            },
            New SqlParameter With {
                .ParameterName = "@NumeroSemana",
                .Value = NumeroSemana
            },
            New SqlParameter With {
                .ParameterName = "@AnioConsulta",
                .Value = AnioConsulta
            },
            New SqlParameter With {
                .ParameterName = "@UsuarioConsulta",
                .Value = SesionUsuario.UsuarioSesion.PUserUsername.ToString()
            }
        }

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ProyeccionMateriales_ConsultarExplosionMaterialDirectosConIVA]", listaparametros)
    End Function

End Class
