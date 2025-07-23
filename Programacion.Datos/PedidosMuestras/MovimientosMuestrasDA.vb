Imports System.Data.SqlClient

Public Class MovimientosMuestrasDA
    Public Function tablaLayoutEtiquetasMuestras() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "esLayout"
        ParametroParaLista.Value = True
        ListaParametros.Add(ParametroParaLista)
        Return operacion.EjecutarConsultaSP("Almacen.SP_Almacen_ConsultarEtiquetasPedidosMuestrasV2", ListaParametros)
    End Function

    Public Function tablaLayoutEtiquetasMuestras(ByVal etiqueta As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "esLayout"
        ParametroParaLista.Value = False
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pemp_piezaid"
        ParametroParaLista.Value = etiqueta
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Almacen.SP_Almacen_ConsultarEtiquetasPedidosMuestrasV2", ListaParametros)
    End Function

    Public Sub EditarPedidosMuestrasPiezas(ByVal etiqueta As String, ByVal Accion As Integer, ByVal UsuarioID As Int32, ByVal idSalidaInventario As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pemp_piezaid"
        ParametroParaLista.Value = etiqueta
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "UsuarioID"
        ParametroParaLista.Value = UsuarioID
        ListaParametros.Add(ParametroParaLista)



        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idSalidaInventario"
        ParametroParaLista.Value = idSalidaInventario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Almacen.SP_Editar_Status_PedidosMuestrasPiezas_ConUsuarioV2", ListaParametros)
        'operacion.EjecutarSentenciaSP("Almacen.SP_Editar_Status_PedidosMuestrasPiezas", ListaParametros)
    End Sub


    Public Function InsertarSalidasInventario(ByVal Piezas As Integer, ByVal Motivo As String, ByVal UsuarioID As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@piezas"
        ParametroParaLista.Value = Piezas
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@Motivo"
        ParametroParaLista.Value = Motivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@UsuarioID"
        ParametroParaLista.Value = UsuarioID
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Muestras_Movimientos_Consultas_Insertar_SalidasInventario", ListaParametros)
        'operacion.EjecutarSentenciaSP("Almacen.SP_Editar_Status_PedidosMuestrasPiezas", ListaParametros)
    End Function

    Public Function CargarCedisNaves() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_EnvioRecepcionMuestras_ObtenerCedis]", ListaParametros)

    End Function
End Class
