Imports System.Data.SqlClient
Public Class ColeccionNaveDA

    Public Function ConsultarNavesAux() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ConsultaNavesAux]", listaParametros)
    End Function


    Public Function ConsultarNavesMarca(ByVal NaveIdSAY As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@IdNaveSay", NaveIdSAY)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_MovimientosColecciones_ConsultaNavesmarca_costos]", listaParametros)
    End Function
    Public Function ConsultarColeccion(ByVal NaveIdSAY As Integer, ByVal marca As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@IdNaveSAY", NaveIdSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@marca", marca)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ConsultaNavesColeccion]", listaParametros)
    End Function

    Public Function ObtieneArticulosNoAsignadosPorNave(ByVal IdNaveSAY As Integer, ByVal Marca As String, ByVal ColeccionSay As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveIdSAY", IdNaveSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColeccionSay", ColeccionSay)
        listaParametros.Add(parametro)



        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Articulos_CostosNave_coleccion]", listaParametros)

    End Function



    Public Function CrearReporteActualizarCostos(ByVal IdNaveSAY As Integer, ByVal ProductoEstiloSeleccionados As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveOrigen", IdNaveSAY)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@ProductoEstiloID", ProductoEstiloSeleccionados)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CreaReporte_ActualizacionCostos]", listaParametros)
    End Function

    Public Function ListadoParametroMovimientoColecciones(ByVal tipo_busqueda As Integer, ByVal NaveSayId As Integer, ByVal Marca As String, ByVal Colecciones As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipo_busqueda", tipo_busqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveOrigen", NaveSayId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@colecciones", Colecciones)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ActualizarCostos_ListaParametros]", listaParametros)
    End Function


    Public Function ObtieneArticulostallas(ByVal NaveSayId As Integer, ByVal Colecciones As String, ByVal Marca As String, ByVal tallas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveIdSAY", NaveSayId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ColeccionSay", Colecciones)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Marca", Marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@corrida", tallas)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Articulos_CostosNave_Coleccion_talla]", listaParametros)
    End Function


    Public Function ObtenerNaveDesarrolla(ByVal productoestiloId As String)
        Dim obj As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@productoEstilo", productoestiloId)
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Programacion].[SP_ConsultaNaveDesarrollaXProductoEstilo]", listaParametros)

    End Function
End Class
