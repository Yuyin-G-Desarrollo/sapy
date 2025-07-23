Imports System.Data.SqlClient
Imports Entidades
Imports ToolServicios

Public Class PedidosMuestraDA
#Region "Pedidos Muestra"
    ''' <summary>
    ''' Catalogo de Agentes
    ''' </summary>
    ''' <param name="idCliente"> Valor numerico que representa el ID del Cliente</param>
    ''' <returns>Regresa el listado de Agentes por Cliente o Todos</returns>
    Public Function ListaAgente(ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim tabla As DataTable = Nothing
        Try
            parametro.ParameterName = "@idcliente"
            parametro.Value = idCliente
            listaParametros.Add(parametro)
            tabla = (objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarAgentesMuestras", listaParametros))
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try

        Return tabla
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function ConsultaAsuntosMuestra() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim tabla As DataTable
        Try
            tabla = objPersistencia.EjecutaConsulta("execute Ventas.SP_Ventas_ConsultarAsuntosMuestras")
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return tabla
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="idAgente"></param>
    ''' <returns></returns>
    Public Function ConsultaClientesMuestras(ByVal idAgente As Int32?) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim tabla As DataTable
        Try
            parametro.ParameterName = "@idagente"
            parametro.Value = idAgente
            listaParametros.Add(parametro)
            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarClientesMuestras", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            parametro = Nothing
            listaParametros = Nothing
        End Try
        Return tabla
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <returns></returns>
    Public Function ConsultaEstatusMuestras(ByVal opcion As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim tabla As DataTable = Nothing
        Try
            parametro.ParameterName = "@accion"
            parametro.Value = opcion
            listaParametros.Add(parametro)
            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarEstatusMuestras", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            parametro = Nothing
            listaParametros = Nothing
        End Try
        Return tabla
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filtro"></param>
    ''' <returns></returns>
    Public Function ConsultarProductosMuestras(ByVal filtro As String, ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim tabla As DataTable
        Try

            listaParametros.Add(New SqlParameter(parameterName:="@mostrarProd", value:=filtro))
            listaParametros.Add(New SqlParameter(parameterName:="@clienteid", value:=idCliente))
            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarProductosMuestras", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return tabla
    End Function
    ''' <summary>
    ''' Consulta los productos por codigo de barras
    ''' </summary>
    ''' <param name="filtro"></param>
    ''' <returns></returns>
    Public Function ConsultarProductosMuestrasCodigo(ByVal filtro As String, ByVal idCliente As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim tabla As DataTable
        Try

            listaParametros.Add(New SqlParameter(parameterName:="@mostrarProd", value:=filtro))
            listaParametros.Add(New SqlParameter(parameterName:="@clienteid", value:=idCliente))
            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarProductosMuestrasEtiqueta ", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return tabla
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pedido"></param>
    ''' <returns></returns>
    Public Function InsertarPedidosMuestra(ByVal pedido As PedidoMuestra) As Int32
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim idPedidoMuestra As DataTable
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@idcliente", value:=pedido.pedim_clienteid))
            listaParametros.Add(New SqlParameter(parameterName:="@idagente", value:=pedido.pedim_colaboradorid_vendedor))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaCreacion", value:=pedido.pedim_fechacreacion))
            listaParametros.Add(New SqlParameter(parameterName:="@idasunto", value:=pedido.pedim_asuntomuestrasid))
            listaParametros.Add(New SqlParameter(parameterName:="@idTemporada", value:=pedido.pedim_temporadaid))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaEntrega", value:=pedido.pedim_fechaentregacliente))
            listaParametros.Add(New SqlParameter(parameterName:="@idEstatus", value:=pedido.pedim_estatusid))
            listaParametros.Add(New SqlParameter(parameterName:="@idUsuariocrea", value:=pedido.pedim_usuariocreoid))
            listaParametros.Add(New SqlParameter(parameterName:="@accion", value:=OpcionesPedidosMuestra.Insertar))
            listaParametros.Add(New SqlParameter(parameterName:="@FolioPedido", value:=pedido.pedim_pedidoid))
            listaParametros.Add(New SqlParameter(parameterName:="@Observaciones", value:=pedido.pedim_observaciones))
            idPedidoMuestra = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_AltaPedidosMuestras", listaParametros)

        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return Int32.Parse(idPedidoMuestra(0)(0))
    End Function
    Public Function ModificarPedidosMuestra(ByVal pedido As PedidoMuestra) As Int32
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim idPedidoMuestra As DataTable
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@idcliente", value:=pedido.pedim_clienteid))
            listaParametros.Add(New SqlParameter(parameterName:="@idagente", value:=pedido.pedim_colaboradorid_vendedor))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaCreacion", value:=pedido.pedim_fechacreacion))
            listaParametros.Add(New SqlParameter(parameterName:="@idasunto", value:=pedido.pedim_asuntomuestrasid))
            listaParametros.Add(New SqlParameter(parameterName:="@idTemporada", value:=pedido.pedim_temporadaid))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaEntrega", value:=pedido.pedim_fechaentregacliente))
            listaParametros.Add(New SqlParameter(parameterName:="@idEstatus", value:=pedido.pedim_estatusid))
            listaParametros.Add(New SqlParameter(parameterName:="@idUsuariocrea", value:=pedido.pedim_usuariocreoid))
            listaParametros.Add(New SqlParameter(parameterName:="@accion", value:=OpcionesPedidosMuestra.Modificar))
            listaParametros.Add(New SqlParameter(parameterName:="@FolioPedido", value:=pedido.pedim_pedidoid))
            listaParametros.Add(New SqlParameter(parameterName:="@Observaciones", value:=pedido.pedim_observaciones))
            idPedidoMuestra = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_AltaPedidosMuestras", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionPedidoMuestra)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return Int32.Parse(idPedidoMuestra(0)(0))
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pedidoDetalle"></param>
    ''' <returns></returns>
    Public Function InsertarPedidosMuestraDetalle(ByVal pedidoDetalle As PedidoMuestraDetalle, ByVal ejecutivo As Int32) As Int32
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim idPedidoMuestra As DataTable
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@Accion", value:=OpcionesPedidosMuestra.Insertar))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_pedidoid", value:=pedidoDetalle.pdetm_pedidoid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_productoestiloid", value:=pedidoDetalle.pdetm_productoestiloid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_unidadmedidaid", value:=pedidoDetalle.pdetm_unidadmedidaid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_estatusid", value:=pedidoDetalle.pdetm_estatusid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_talla", value:=pedidoDetalle.pdetm_talla))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_cantidad", value:=pedidoDetalle.pdetm_cantidad))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_costo", value:=pedidoDetalle.pdetm_costo))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechaentregacliente", value:=pedidoDetalle.pdetm_fechaentregacliente))
            'listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechaentregareal", value:=pedidoDetalle.pdetm_fechaentregareal))
            'listaParametros.Add(New SqlParameter(parameterName:="@pdetm_anotacion", value:=pedidoDetalle.pdetm_anotacion))
            'listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechacancelacion", value:=pedidoDetalle.pdetm_fechacancelacion))
            'listaParametros.Add(New SqlParameter(parameterName:="@pdetm_estatuscancelacionid", value:=pedidoDetalle.pdetm_estatuscancelacionid))
            'listaParametros.Add(New SqlParameter(parameterName:="@pdetm_motivocancelacion", value:=pedidoDetalle.pdetm_motivocancelacion))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechacreacion", value:=pedidoDetalle.pdetm_fechacreacion))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_usuariocreoid", value:=pedidoDetalle.pdetm_usuariocreoid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_ejecutivo", value:=ejecutivo))
            idPedidoMuestra = objPersistencia.EjecutarConsultaSP("Ventas.SP_VEntas_AltaPedidosMuestraDetalle", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionDetallePedidosMuestra)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return Int32.Parse(idPedidoMuestra(0)(0))
    End Function

    Public Function ModificarPedidosMuestraDetalle(ByVal pedidoDetalle As PedidoMuestraDetalle, ByVal idEjecutivo As Int32) As Int32
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim idPedidoMuestra As DataTable
        Dim retorno As Int32 = 0
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@Accion", value:=OpcionesPedidosMuestra.Modificar))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_pedidoid", value:=pedidoDetalle.pdetm_pedidoid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_productoestiloid", value:=pedidoDetalle.pdetm_productoestiloid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_unidadmedidaid", value:=pedidoDetalle.pdetm_unidadmedidaid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_estatusid", value:=pedidoDetalle.pdetm_estatusid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_talla", value:=pedidoDetalle.pdetm_talla))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_cantidad", value:=pedidoDetalle.pdetm_cantidad))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_costo", value:=pedidoDetalle.pdetm_costo))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechaentregacliente", value:=pedidoDetalle.pdetm_fechaentregacliente))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechaentregareal", value:=pedidoDetalle.pdetm_fechaentregareal))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_anotacion", value:=pedidoDetalle.pdetm_anotacion))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechacancelacion", value:=pedidoDetalle.pdetm_fechacancelacion))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_estatuscancelacionid", value:=pedidoDetalle.pdetm_estatuscancelacionid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_motivocancelacion", value:=pedidoDetalle.pdetm_motivocancelacion))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_fechacreacion", value:=pedidoDetalle.pdetm_fechacreacion))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_usuariocreoid", value:=pedidoDetalle.pdetm_usuariocreoid))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_ejecutivo", value:=pedidoDetalle.pdetm_usuariocreoid))

            idPedidoMuestra = objPersistencia.EjecutarConsultaSP("Ventas.SP_VEntas_AltaPedidosMuestraDetalle", listaParametros)
            retorno = Int32.Parse(idPedidoMuestra(0)(0))
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionDetallePedidosMuestra)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return retorno
    End Function

    Public Function PedidosMuestraGeneral(ByVal filtro As String, ByVal fechaInicio As DateTime?, ByVal fechaFin As DateTime?, ByVal usuarioId As Int32, ByVal perfilId As Int32, ByVal agenteId As Int32, ByVal finalizado As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim pedidoMuetra As DataTable = Nothing
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@idagente", value:=agenteId))
            listaParametros.Add(New SqlParameter(parameterName:="@idusuario", value:=usuarioId))
            listaParametros.Add(New SqlParameter(parameterName:="@perfil", value:=perfilId))
            listaParametros.Add(New SqlParameter(parameterName:="@filtro", value:=filtro))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaInicio", value:=fechaInicio))
            listaParametros.Add(New SqlParameter(parameterName:="@FechaFin", value:=fechaFin))
            listaParametros.Add(New SqlParameter(parameterName:="@finalizado", value:=finalizado))
            pedidoMuetra = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultaPedidosMuestrasEstatus", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionDetallePedidosMuestra)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return pedidoMuetra
    End Function
    Public Function ConsultaPerfilUsuario(ByVal login As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim perfiles As DataTable = Nothing
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@UserName", value:=login))
            perfiles = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarPerfilesUsuarioMuestras", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return perfiles
    End Function

    Public Function ConsultaTemporadas()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()

        Dim perfiles As DataTable = Nothing
        Try

            perfiles = objPersistencia.EjecutaConsulta("execute Ventas.SP_Ventas_ConsultaTemporada")
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing

        End Try
        Return perfiles
    End Function


    Public Function ConsultaUnidadesMedida()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim perfiles As DataTable = Nothing
        Try

            perfiles = objPersistencia.EjecutaConsulta("Execute Ventas.SP_Ventas_ConsultarPedidosMuestrasUnidadesMedida")
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return perfiles
    End Function

    Public Function ConsultaDetalleTallas(ByVal idTalla As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim perfiles As DataTable = Nothing
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@idtalla", value:=idTalla))
            perfiles = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_Consultartallacentral", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
        End Try
        Return perfiles
    End Function
    Public Function ConsultarPedidosMuestraDetalleWeb(ByVal idPedido As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim tabla As DataTable
        Try
            parametro.ParameterName = "@idPedido"
            parametro.Value = idPedido
            listaParametros.Add(parametro)
            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarPedidosMuestrasDetallesWEB", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return tabla
    End Function
    Public Function ConsultarPedidosMuestraWeb(ByVal idPedido As Int32, ByVal accion As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim parametro2 As New SqlParameter()

        Dim tabla As DataTable
        Try

            parametro.ParameterName = "@FolioPedido"
            parametro.Value = idPedido
            listaParametros.Add(parametro)

            parametro2.ParameterName = "@accion"
            parametro2.Value = accion
            listaParametros.Add(parametro2)

            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarPedidosMuestrasWEB", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return tabla
    End Function

    Public Function EliminarPedidosMuestraWeb(ByVal idPedido As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim parametro2 As New SqlParameter()

        Dim tabla As DataTable
        Try

            parametro.ParameterName = "@FolioPedido"
            parametro.Value = idPedido
            listaParametros.Add(parametro)

            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_EliminarPedidosMuestraDetalleWEB", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return tabla
    End Function


    Public Function ValidarPedidosMuestraProductos(ByVal idPedido As Int32, ByVal idEstatusOriginal As Int32, ByVal idEstatusAbierto As Int32, ByVal idEjecutivo As Int32) As Int32
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()
        Dim retorno As Int32 = 0
        Dim tabla As DataTable
        Try
            listaParametros.Add(New SqlParameter(parameterName:="@Accion", value:=OpcionesPedidosMuestra.Modificar))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_pedidoid", value:=idPedido))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_estatusid", value:=idEstatusOriginal))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_estatusid2", value:=idEstatusAbierto))
            listaParametros.Add(New SqlParameter(parameterName:="@pdetm_ejecutivo", value:=idEjecutivo))

            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_AltaPedidosMuestraDetalle", listaParametros)
            retorno = Int32.Parse(tabla(0)(0))
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorInsercionDetallePedidosMuestra)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return retorno
    End Function

    Public Function ReportePedidoMuestras(ByVal Accion As Integer, ByVal Folio As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idPedido"
        ParametroParaLista.Value = Folio
        ListaParametros.Add(ParametroParaLista)



        Return operacion.EjecutarConsultaSP("Ventas.SP_ReportePedidosMuestras", ListaParametros)
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

#Region "Validación Agente"
    Public Function ValidaAgenteBaseUsuario(ByVal idUsuario As Int32) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos()
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter()

        Dim tabla As DataTable
        Try

            parametro.ParameterName = "@idusuario"
            parametro.Value = idUsuario
            listaParametros.Add(parametro)

            tabla = objPersistencia.EjecutarConsultaSP("Ventas.SP_Ventas_ConsultarIDAgentesMuestras", listaParametros)
        Catch ex As Exception
            Throw New ArgumentException(MensajesPedidosMuestra.CNSErrorConsulta)
        Finally
            objPersistencia = Nothing
            listaParametros = Nothing
            parametro = Nothing
        End Try
        Return tabla
    End Function
#End Region
#End Region


End Class
