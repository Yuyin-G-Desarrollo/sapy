Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Persistencia

Public Class InventarioDA

    Public Function ListadoInventarioAntiguedad(cedis As Integer) As DataTable

        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim dtDatosRetornados As New DataTable
        'Try
        '    dtDatosRetornados = operaciones.EjecutaConsultaSinThrow(ConsultaInventarioAntiguedad)
        'Catch ex As Exception
        '    If ex.Message.ToUpper.Contains("INTERBLOQUEO") Or ex.Message.ToUpper.Contains("DEADLOCK") Then
        '        dtDatosRetornados.Columns.Add("Mensaje")
        '        Dim rowDtRetornado As DataRow
        '        rowDtRetornado = dtDatosRetornados.NewRow
        '        rowDtRetornado.Item(0) = "Error de interbloqueo, vuelva a intentar mas tarde."
        '        dtDatosRetornados.Rows.Add(rowDtRetornado)
        '    Else
        '        Throw ex
        '    End If
        'End Try

        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@cedis"
        parametro.Value = cedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultarInventarioAntiguedad]", listaParametros)
    End Function


    Public Function InventarioDisponible(ByVal antiguedad As Integer, ByVal vigentes As Integer, ByVal descontinuados As Integer, ByVal verTalla As Integer,
                                         ByVal familia As String, ByVal marca As String, ByVal coleccion As String, ByVal articulo As String,
                                         ByVal disponible As Integer, ByVal bloqueados As Integer) As DataTable
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@antiguedad", antiguedad)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@vigentes", vigentes)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@descontinuados", descontinuados)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@verTalla", verTalla)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Familia", familia)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Marca", marca)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Coleccion", coleccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Articulo", articulo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Disponibles", disponible)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Bloqueados", bloqueados)
        listaparametros.Add(parametro)

        If disponible = 1 And bloqueados = 1 Then
            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto_Antiguedad_Todos]", listaparametros)
        Else
            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto_Antiguedad_Bloqueados]", listaparametros)
        End If

        'Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto]", listaparametros)
        'Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto_Antiguedad]", listaparametros)


    End Function
    Public Function InventarioDisponibleAG(ByVal antiguedad As Integer, ByVal vigentes As Integer, ByVal descontinuados As Integer, ByVal verTalla As Integer,
                                        ByVal familia As String, ByVal marca As String, ByVal coleccion As String, ByVal articulo As String,
                                        ByVal disponible As Integer, ByVal bloqueados As Integer) As DataTable
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@antiguedad", antiguedad)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@vigentes", vigentes)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@descontinuados", descontinuados)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@verTalla", verTalla)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Familia", familia)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Marca", marca)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Coleccion", coleccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Articulo", articulo)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Disponibles", disponible)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Bloqueados", bloqueados)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@Agente", Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
        listaparametros.Add(parametro)

        'If disponible = 1 And bloqueados = 1 Then
        '    Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto_Antiguedad_Todos]", listaparametros)
        'Else
        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto_Antiguedad_BloqueadosAG]", listaparametros)
        'End If

        'Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto]", listaparametros)
        'Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Apartados_SAY_ConsultaInventarioDisponible_ConFoto_Antiguedad]", listaparametros)


    End Function
    Public Function ListadoInventarioAntiguo_Prevendido(ByVal cedisId As Integer) As DataTable
        Dim objPersistencia As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@cedisId"
        parametro.Value = cedisId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultarInventarioAntiguedad_Prevendido]", listaParametros)
    End Function

End Class
