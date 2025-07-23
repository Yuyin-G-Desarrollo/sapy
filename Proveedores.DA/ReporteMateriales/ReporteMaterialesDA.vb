Imports System.Data.SqlClient

Public Class ReporteMaterialesDA
    Public Function listadoNaves(tipo_Nave As Integer, activo As Integer, ByVal TipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
               
        parametro = New SqlParameter
        parametro.ParameterName = "@TipoConsulta"
        parametro.Value = TipoConsulta
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_Materiales_ConsultaNavesFiltro]", listaparametros)
    End Function

    Public Function listadoHormas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("[Materiales].[SP_Materiales_ConsultaHormas]")
    End Function

    Public Function ObtenerHormasActivasInactivas(navesId As String,
                                                  HormaActiva As String,
                                                  Horma As String,
                                                  ArticuloActivoEnNAve As String,
                                                  Marca As String,
                                                  Coleccion As String,
                                                  Venta As String,
                                                  Temporada As String,
                                                  Estatus As String,
                                                  NaveDesarrollo As String,
                                                  GrupoDesarrollo As String,
                                                   ModeloSicy As String,
                                                   Corrida As String
                                                  ) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "@navesId"
        parametro.Value = navesId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@HormaActiva"
        parametro.Value = HormaActiva
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Horma"
        parametro.Value = Horma
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ArticuloActivoEnNave"
        parametro.Value = ArticuloActivoEnNAve
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        parametro.Value = Marca
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        parametro.Value = Coleccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Venta"
        parametro.Value = Venta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Temporada"
        parametro.Value = Temporada
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = Estatus
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@NaveDesarrollo", NaveDesarrollo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@GrupoDesarrollo", GrupoDesarrollo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModeloSicy"
        parametro.Value = ModeloSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        parametro.Value = Corrida
        listaparametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Materiales].[ObtenerMaterialesHormas_Prueba_V2]", listaparametros)

    End Function

    Public Function listadoNavesDesarrollo()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutarConsultaSP("[Materiales].[SP_Materiales_ConsultaNavesDesarrolloFiltro]", New List(Of SqlParameter))
    End Function


End Class
