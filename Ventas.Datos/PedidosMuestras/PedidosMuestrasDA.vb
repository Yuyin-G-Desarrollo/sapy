Imports Persistencia
Imports System.Data.SqlClient
Public Class PedidosMuestrasDA

    Public Function ListaPedidosMuestras(ByVal idUsuario As Int32, ByVal mostrarTodo As Boolean, ByVal seguimiento As Integer,
                                         ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cedisId As Integer) As List(Of Entidades.PedidosMuestras)

        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim tabla As DataTable

        parametro.ParameterName = "@usuarioCreo"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@mostrarTodo"
        parametro.Value = mostrarTodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Seguimiento"
        parametro.Value = seguimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cedisid"
        parametro.Value = cedisId
        listaParametros.Add(parametro)

        ListaPedidosMuestras = New List(Of Entidades.PedidosMuestras)
        tabla = operaciones.EjecutarConsultaSP("[Ventas].[SP_Ventas_ConsultarPedidosMuestras_ConDisponible]", listaParametros)
        For Each fila As DataRow In tabla.Rows
            Dim PedidoMuestra As New Entidades.PedidosMuestras
            'CInt(fila("clie_clienteid"))
            PedidoMuestra.Sel = CBool(fila("Sel"))
            PedidoMuestra.Folio = CInt(fila("Folio"))
            PedidoMuestra.Temporada = IIf(IsDBNull(fila("Temporada")), "", fila("Temporada"))
            PedidoMuestra.idCliente = IIf(IsDBNull(fila("idCliente")), 0, fila("idCliente"))
            PedidoMuestra.Cliente = IIf(IsDBNull(fila("Cliente")), "", fila("Cliente"))
            PedidoMuestra.idAgente = IIf(IsDBNull(fila("idAgente")), 0, fila("idAgente"))
            If seguimiento = 2 Then
                ' PedidoMuestra.OrdenProduccion = IIf(IsDBNull(fila("OrdenProducción")), 0, fila("OrdenProducción"))
                'PedidoMuestra.FechaOrden = IIf(IsDBNull(fila("FechaOrden")), "", fila("FechaOrden"))
            End If
            PedidoMuestra.Agente = IIf(IsDBNull(fila("Agente")), "", fila("Agente"))
            PedidoMuestra.UsuarioCreo = IIf(IsDBNull(fila("UsuarioCreo")), 0, fila("UsuarioCreo"))
            PedidoMuestra.NombreUsuarioCreo = IIf(IsDBNull(fila("NombreUsuarioCreo")), "", fila("NombreUsuarioCreo"))
            PedidoMuestra.FechaCreacion = CDate(fila("Fecha_Creacion"))
            PedidoMuestra.fechaEntrega = IIf(IsDBNull(fila("Fecha_Entrega_Cliente")), "", fila("Fecha_Entrega_Cliente"))
            PedidoMuestra.EstatusId = IIf(IsDBNull(fila("EstatusId")), 0, fila("EstatusId"))
            PedidoMuestra.Estatus = IIf(IsDBNull(fila("Estatus")), "", fila("Estatus"))
            PedidoMuestra.Observaciones = IIf(IsDBNull(fila("Observaciones")), "", fila("Observaciones"))
            PedidoMuestra.Capturados = IIf(IsDBNull(fila("Capturados")), 0, fila("Capturados"))
            PedidoMuestra.Autorizados = IIf(IsDBNull(fila("Autorizados")), 0, fila("Autorizados"))
            PedidoMuestra.EnProduccion = IIf(IsDBNull(fila("EnProduccion")), 0, fila("EnProduccion"))
            PedidoMuestra.Apartados = IIf(IsDBNull(fila("Apartados")), 0, fila("Apartados"))
            PedidoMuestra.Recibidos = IIf(IsDBNull(fila("Recibidos")), 0, fila("Recibidos"))
            PedidoMuestra.Enviados = IIf(IsDBNull(fila("Enviados")), 0, fila("Enviados"))
            PedidoMuestra.Cancelados = IIf(IsDBNull(fila("Cancelados")), 0, fila("Cancelados"))
            PedidoMuestra.Asunto = IIf(IsDBNull(fila("Asunto")), "", fila("Asunto"))
            PedidoMuestra.idTemporada = IIf(IsDBNull(fila("idTemporada")), 0, fila("idTemporada"))
            PedidoMuestra.idAsunto = IIf(IsDBNull(fila("idAsunto")), 0, fila("idAsunto"))
            PedidoMuestra.Confirmados = IIf(IsDBNull(fila("Confirmados")), 0, fila("Confirmados"))
            PedidoMuestra.FechaEntregaReal = IIf(IsDBNull(fila("FechaEnvio")), "", fila("FechaEnvio"))

            If seguimiento = 1 Then
                PedidoMuestra.Disponible = IIf(IsDBNull(fila("Disponible")), 0, fila("Disponible"))
                PedidoMuestra.DisponibleTotal = 0
                PedidoMuestra.DisponiblePedido = 0
            End If

            If seguimiento = 2 Then
                PedidoMuestra.Disponible = 0
                PedidoMuestra.DisponibleTotal = 0
                PedidoMuestra.DisponiblePedido = 0
            End If

            If seguimiento = 3 Then
                PedidoMuestra.DisponibleTotal = IIf(IsDBNull(fila("DisponibleTotal")), 0, fila("DisponibleTotal"))
                PedidoMuestra.DisponiblePedido = IIf(IsDBNull(fila("DisponiblePedido")), 0, fila("DisponiblePedido"))
            End If

            ListaPedidosMuestras.Add(PedidoMuestra)
        Next
    End Function

    Public Function ListaPedidosDetalles(ByVal Folio As Integer, Accion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        ParametroParaLista.ParameterName = "@PedidoMuestrasID"
        ParametroParaLista.Value = Folio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Ventas_ConsultarOPPedidosMuestras_PorApartar", ListaParametros)
    End Function

    Public Sub CambioDeTallaMuestras(ByVal MuestrasDetalleID As String, ByVal talla As Int16)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@MuestrasDetalleID"
        parametro.Value = MuestrasDetalleID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Talla"
        parametro.Value = talla
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("[Ventas].[SP_PedidosMuestras_CambioTalla]", listaParametros)
    End Sub

    Public Function ListaArticulos(ByVal modelo As String, ByVal agente As Integer, ByVal cliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "agente"
        ParametroParaLista.Value = IIf(agente = 0, DBNull.Value, agente)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "cliente"
        ParametroParaLista.Value = IIf(cliente = 0, DBNull.Value, cliente)
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarPedidosMuestrasArticulos", ListaParametros)
    End Function

    Public Function ListaModelosCancelar(ByVal modelo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultarModelosCancelacionMuestras", ListaParametros)

    End Function

    Public Sub EditarEstatusPedidoMuestra(ByVal Folio As Integer, ByVal Estatus As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idPedido"
        ParametroParaLista.Value = Folio
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Estatus"
        ParametroParaLista.Value = Estatus
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_Editar_Status_PedidosMuestras", ListaParametros)

    End Sub

    Public Sub EditarPedidoMuestras(ByVal EntidadPedidoMuestra As Entidades.PedidosMuestras)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idPedido"
        ParametroParaLista.Value = EntidadPedidoMuestra.Folio
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idAsunto"
        ParametroParaLista.Value = EntidadPedidoMuestra.idAsunto
        ListaParametros.Add(ParametroParaLista)



        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaEntrega"
        ParametroParaLista.Value = EntidadPedidoMuestra.fechaEntrega
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Observaciones"
        ParametroParaLista.Value = EntidadPedidoMuestra.Observaciones
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idcliente"
        ParametroParaLista.Value = EntidadPedidoMuestra.idCliente
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idagente"
        ParametroParaLista.Value = EntidadPedidoMuestra.idAgente
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = EntidadPedidoMuestra.idTemporada
        ListaParametros.Add(ParametroParaLista)


        operacion.EjecutarSentenciaSP("Ventas.SP_Ventas_Editar_PedidosMuestras", ListaParametros)

    End Sub


    Public Sub EditarEstatusPedidoMuestraDetalles(ByVal Folio As Integer, ByVal Estilo As Integer, ByVal UnidadMedida As Integer, ByVal Talla As String, ByVal Estatus As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idPedido"
        ParametroParaLista.Value = Folio
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idEstilo"
        ParametroParaLista.Value = Estilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idUnidadMedida"
        ParametroParaLista.Value = UnidadMedida
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "talla"
        ParametroParaLista.Value = Talla
        ListaParametros.Add(ParametroParaLista)



        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Estatus"
        ParametroParaLista.Value = Estatus
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_Editar_Status_PedidosMuestrasDetalles", ListaParametros)
    End Sub


    'Public Sub CancelarMuestra(ByVal Folio As Integer, ByVal Estilo As Integer, ByVal UnidadMedida As Integer, ByVal Talla As String, ByVal UsuarioID As Integer)
    Public Sub CancelarMuestra(ByVal Folio As Integer, ByVal PedidoMuestraDetalle As Integer, ByVal UsuarioID As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_pedidoid"
        ParametroParaLista.Value = Folio
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@pdtem_pedidomuestradetalleid"
        ParametroParaLista.Value = PedidoMuestraDetalle
        ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "pdetm_productoestiloid"
        'ParametroParaLista.Value = Estilo
        'ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "pdetm_unidadmedidaid"
        'ParametroParaLista.Value = UnidadMedida
        'ListaParametros.Add(ParametroParaLista)


        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "pdetm_talla"
        'ParametroParaLista.Value = Talla
        'ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@UsuarioID"
        ParametroParaLista.Value = UsuarioID
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_Ventas_CancelarMuestras", ListaParametros)
    End Sub


    Public Sub AltaPedidoDetalleMuestra(ByVal entidadPedidoMuestraDetalle As Entidades.PedidoMuestraDetalle)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_pedidoid"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_pedidoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_productoestiloid"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_productoestiloid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_unidadmedidaid"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_unidadmedidaid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_estatusid"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_estatusid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_talla"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_talla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_cantidad"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_cantidad
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_costo"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_costo
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_fechaentregacliente"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_fechaentregacliente.ToString("dd/MM/yyyy")
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_fechaentregareal"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_anotacion"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_fechacancelacion"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_estatuscancelacionid"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_motivocancelacion"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_fechacreacion"
        ParametroParaLista.Value = DateTime.Now.ToString("dd/MM/yyyy")
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_usuariocreoid"
        ParametroParaLista.Value = entidadPedidoMuestraDetalle.pdetm_usuariocreoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetm_ejecutivo"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_Ventas_AltaPedidosMuestraDetalleERP", ListaParametros)
    End Sub

    Public Function ListaUnidadesDeMedida() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Return operacion.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarPedidosMuestrasUnidadesMedida", ListaParametros)
    End Function

    Public Function ListaAsutosPedidoMuestras() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Return operacion.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarPedidosMuestrasUnidadesMedida", ListaParametros)
    End Function




    Public Function ReportePedidoMuestras(ByVal Accion As Integer, ByVal Folio As Integer, Optional ByVal Cadena As String = "", Optional ByVal MostrarPrecio As Boolean = False) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idPedido"
        ParametroParaLista.Value = IIf(Folio = 0, DBNull.Value, Folio)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Cadena"
        ParametroParaLista.Value = IIf(Cadena = "", DBNull.Value, Cadena)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "MostrarPrecio"
        ParametroParaLista.Value = MostrarPrecio
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Ventas.SP_ReportePedidosMuestras", ListaParametros)
    End Function


    Public Function VerListaAsuntos(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)
        Return operacion.EjecutarConsultaSP("Programacion.SP_Consulta_AsuntosMuestras", ListaParametros)
    End Function

    Public Sub APartarPedidoMuestra(Pedido As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Dim ParametroParaLista As New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoID"
            ParametroParaLista.Value = Pedido
            ListaParametros.Add(ParametroParaLista)

            operacion.EjecutarConsultaSP("[Ventas].[SP_Muestras_ApartarPedido]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ConsultarInventarioDisponiblePedidoMuestra(PedidoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Dim ParametroParaLista As New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoID"
            ParametroParaLista.Value = PedidoID
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Muestras_Apartados_PiezasDisponibles]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviarPedidoPorAutorizar(PedidoID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Dim ParametroParaLista As New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoID"
            ParametroParaLista.Value = PedidoID
            ListaParametros.Add(ParametroParaLista)

            objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Muestras_Apartados_EnviarPedidoAPorAutorizar]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarPiezasApartadas(PedidoID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try

            Dim ParametroParaLista As New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoID"
            ParametroParaLista.Value = PedidoID
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Muestras_Apartados_PiezasApartadas]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ApartarPiezaMuestra(PiezaID As String, PedidoID As Integer, UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter
        Try

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@PiezaID"
            ParametroParaLista.Value = PiezaID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoID"
            ParametroParaLista.Value = PedidoID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@UsuarioID"
            ParametroParaLista.Value = UsuarioID
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Muestras_Apartados_ApartarPieza]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CopiarPedidoMuestra(ByVal PedidoID As Integer, ByVal UsuarioCopiaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter
        Try

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoMuestraID"
            ParametroParaLista.Value = PedidoID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@UsuarioCopiaID"
            ParametroParaLista.Value = UsuarioCopiaId
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_PedidosMuestras_CopiarPedido]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function CargarComboClientes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_AdministradosPedidosMuestras_FiltroClientes]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarComboAgentes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter
        Try
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@idcliente"
            ParametroParaLista.Value = Nothing
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ConsultarAgentesMuestras]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CargarComboTempordas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Try
            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Ventas_ConsultaTemporada]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function VerificarParesCompletos(PedidoID As Integer, Proceso As Integer, UsuarioID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter
        Try
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@PedidoID"
            ParametroParaLista.Value = PedidoID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Proceso"
            ParametroParaLista.Value = Proceso
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@UsuarioID"
            ParametroParaLista.Value = UsuarioID
            ListaParametros.Add(ParametroParaLista)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Muestras_Apartados_EnviarPedidoAPorAutorizar_VerificarParesCompletos]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CargarCedisNaves() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[Sp_EnvioRecepcionMuestras_ObtenerCedis]", ListaParametros)

    End Function
    Public Function validaCedisOriginal(ByVal modelo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As SqlParameter

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ValidaModeloPedido_PertenecienteMismoCedis]", ListaParametros)

    End Function
    Public Function ConsultarInventarioPiezasMuestras() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Return operacion.EjecutarConsultaSP("[Ventas].[SP_PiezasMuestras_ConsultaInventario]", ListaParametros)
    End Function
End Class
