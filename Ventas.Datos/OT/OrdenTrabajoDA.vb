
Imports System.Data.SqlClient

Public Class OrdenTrabajoDA




    Public Function ConsultarOTs(ByVal PerfilId As Int32, ByVal TipoOT As Integer, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date,
                                 ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal AtnClientes As String,
                                 ByVal AgenteVentas As String, ByVal StatusOT As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal Piel As String,
                                 ByVal Color As String, ByVal Corrida As String, ByVal Operador As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "PerfilId"
        parametro.Value = PerfilId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cita"
        parametro.Value = Cita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FEchaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = Tienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = AgenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = Piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = Color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = Operador
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTs]", listaParametros)

    End Function


    Public Function AutorizarOT(ByVal OrdenTrabajoID As Int32, ByVal UsuarioID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AutorizarOT]", listaParametros)

    End Function


    Public Function RechazarOT(ByVal OrdenTrabajoID As String, ByVal UsuarioID As String, ByVal MotivoRechazo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MotivoRechazo"
        parametro.Value = MotivoRechazo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_RechazarOT]", listaParametros)

    End Function

    Public Function ConsultarParesAtadoAndrea(ByVal OrdenTrabajoID As Int32, ByVal LoteId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteID"
        parametro.Value = LoteId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarParesAtadoAndrea]", listaParametros)

    End Function

    Public Function ConsultarCodigosAndreaXml(ByVal OrdenTrabajoID As Int32, ByVal LoteId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LoteID"
        parametro.Value = LoteId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarCodigosAndreaXML]", listaParametros)

    End Function



    Public Function ConsultarPartidasOrdenTrabajo(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaPartidasOT]", listaParametros)

    End Function




    Public Function ConsultarParesPartidasOrdenTrabajo(ByVal OrdenTrabajoID As String, ByVal Partida As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = Partida
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaParesPartidaOT]", listaParametros)

    End Function


    Public Function ConsultarInformacionOT(ByVal OrdenTrabajoID As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarInformacionOT]", listaParametros)

    End Function

    Public Function ObtenerTotalesOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ObtenerTotalesOTs]", listaParametros)

    End Function



    Public Function ConfirmacionPares(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal TipoCodigo As Integer, ByVal CodigoPar As String, ByVal Estiba As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OTId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoCodigo"
        parametro.Value = TipoCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoPar"
        parametro.Value = CodigoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estiba"
        parametro.Value = Estiba
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConfirmacionPares]", listaParametros)

    End Function


    Public Function ValidacionPares(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal TipoCodigo As Integer, ByVal CodigoPar As String, ByVal Estiba As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OTId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoCodigo"
        parametro.Value = TipoCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoPar"
        parametro.Value = CodigoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estiba"
        parametro.Value = Estiba
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ValidacionPares]", listaParametros)

    End Function

    Public Function CancelarPartidaOT(ByVal OrdenTrabajoID As Int32, ByVal Partida As Integer, ByVal ColaboradorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = Partida
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_CancelarPartidasOT]", listaParametros)

    End Function

    Public Function ActualizarEncabezadosOrdenTrabajo() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ActualizarEncabezadosPartidas]", listaParametros)

    End Function


    Public Function ConsultaMensajeriasAltaEmbarquesAgenda(ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaMensajerias]", listaParametros)

        'Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_OrdenTrabajo_ConsultaMensajerias]")

    End Function

    Public Function ConsultaOperadoresAltaEmbarquesAgenda() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_OrdenTrabajo_ConsultaOperadores] ")

    End Function

    Public Function ConsultaUnidadesAltaEmbarquesAgenda() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_OrdenTrabajo_ConsultaUnidades]")

    End Function

    Public Sub InsertarEditarCitaEntrega(ByVal AltaCita As Entidades.OrdenTrabajoCitaEntrega)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = AltaCita.PordenesTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntrega"
        parametro.Value = AltaCita.PfechaEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clave"
        parametro.Value = AltaCita.Pclave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PersonasRequeridas"
        parametro.Value = AltaCita.PpersonasRequeridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = AltaCita.Pobservaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModifico"
        parametro.Value = AltaCita.PusuarioModifica
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_InsertarEditarCitaEntrega]", listaParametros)

    End Sub


    Public Function ActualizarFechaPreparacion(ByVal OrdenTrabajoID As String, ByVal FechaPreparacion As Date, ByVal UsuarioID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaPreparacion"
        parametro.Value = FechaPreparacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AgregarFechaPreparacion]", listaParametros)


    End Function

    Public Sub InsertarEditarEmbarqueEntrega(ByVal AltaEmbarque As Entidades.OrdenTrabajoEmbarqueEntrega)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = AltaEmbarque.PordenesTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntrega"
        parametro.Value = AltaEmbarque.PfechaEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MensajeriaId"
        parametro.Value = AltaEmbarque.PmensajeriaIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UnidadIdSICY"
        parametro.Value = AltaEmbarque.PunidadIdSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operadorid"
        parametro.Value = AltaEmbarque.PoperadorIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModifico"
        parametro.Value = AltaEmbarque.PusuarioModifica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaRegreso"
        parametro.Value = AltaEmbarque.PfechaRegreso
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_InsertarEditarEmbarqueEntrega]", listaParametros)

    End Sub



    Public Function ConsultarDetalleOTs(ByVal PerfilId As Int32, ByVal TipoOT As Integer, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date,
                                ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal AtnClientes As String,
                                ByVal AgenteVentas As String, ByVal StatusOT As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal Piel As String,
                                ByVal Color As String, ByVal Corrida As String, ByVal Operador As String, ByVal CEDISID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "PerfilId"
        parametro.Value = PerfilId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cita"
        parametro.Value = Cita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FEchaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = Tienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = AgenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = Piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = Color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = Operador
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarDetalleOTS_v4]", listaParametros)

    End Function

    Public Function ConsultarDetalleOTsPaqueteria(ByVal OrdenesTrabajo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = OrdenesTrabajo
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ObtenerInformacionOTs_Paqueterias]", listaParametros)

    End Function


    Public Function ConsultarOTsAlmacen(ByVal PerfilId As Int32, ByVal TipoOT As Integer, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date,
                                ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal AtnClientes As String,
                                ByVal AgenteVentas As String, ByVal StatusOT As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal Piel As String,
                                ByVal Color As String, ByVal Corrida As String, ByVal Operador As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "PerfilId"
        parametro.Value = PerfilId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cita"
        parametro.Value = Cita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FEchaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = Cliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = Tienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = AgenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = Marca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = Piel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = Color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = Operador
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTsAlmacen]", listaParametros)

    End Function


    Public Function ConsultarIncidencias(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OT"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarIncidencias]", listaParametros)

    End Function

    Public Function ConsultarErrores(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OT"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarErroresv2]", listaParametros)

    End Function



    Public Function ConsultarCitasEmbarquesModoLista(ByVal SinAgendar As Integer, ByVal Agendado As Integer, ByVal TipoEntrega As Integer, ByVal Unidad As Integer, ByVal EsYISTI As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "MostrarSinAgendar"
        parametro.Value = SinAgendar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MostrarAgendado"
        parametro.Value = Agendado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LugarEntrega"
        parametro.Value = TipoEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UnidadIdSICY"
        parametro.Value = Unidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsYISTI"
        parametro.Value = EsYISTI
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaModoListaAgendaEntregas]", listaParametros)

    End Function


    Public Function AceptarOTAlmacen(ByVal OrdenTrabajoID As Int32, ByVal UsuarioID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Almacen_AceptarOT]", listaParametros)

    End Function

    Public Function AsignarOperadorOT(ByVal OrdenTrabajoID As String, ByVal OperadorId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OperadorID"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AsignarOperadorOT]", listaParametros)

    End Function

    Public Function ConsultarPartidasAsignacionOperador(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaPartidasOT_AsignacionOperador]", listaParametros)

    End Function


    Public Function AsignarOperadorPartidaOT(ByVal OrdenTrabajoID As String, ByVal Partida As String, ByVal OperadorId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partida"
        parametro.Value = Partida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OperadorID"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AsignarOperadorPartidaOT]", listaParametros)

    End Function

    Public Function ConsultarInformacionReporteTerminoOT(ByVal OrdenTrabajoID As String, ByVal UsuarioImprimioID As Integer, ByVal ClientesSinCita As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioImprimio"
        parametro.Value = UsuarioImprimioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Reporte_TerminoOT]", listaParametros)

    End Function


    Public Function ConsultarCitasEmbarquesModoAgenda(ByVal TipoEntrega As Integer, ByVal Unidad As Integer, ByVal FechaInicioEmbarque As Date, ByVal FechaFinEmbarque As Date, ByVal HoraInicioEmbarque As Integer, ByVal HoraFinEmbarque As Integer, ByVal EsYISTI As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "LugarEntrega"
        parametro.Value = TipoEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UnidadIdSICY"
        parametro.Value = Unidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicioEmbarque"
        parametro.Value = FechaInicioEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinEmbarque"
        parametro.Value = FechaFinEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "HoraInicioEmbarque"
        parametro.Value = HoraInicioEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "HoraFinEmbarque"
        parametro.Value = HoraFinEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsYISTI"
        parametro.Value = EsYISTI
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaModoAgendaEntregas]", listaParametros)

    End Function

    Public Function ValidacionParesANDREA(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal CodigoAtado As String, ByVal CodigoAndrea As String, ByVal Estiba As String, ByVal EstibaUbicacionReal As String,
                                          ByVal ColaboradorUbicoID As Integer, ByVal FechaUbico As Date, ByVal Articulo As String, ByVal Calce As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing



        parametro.ParameterName = "UsuarioID"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OTId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoAtado"
        parametro.Value = CodigoAtado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estiba"
        parametro.Value = Estiba
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoAndrea"
        parametro.Value = CodigoAndrea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UbicacionEstibaReal"
        parametro.Value = EstibaUbicacionReal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorUbicoID"
        parametro.Value = ColaboradorUbicoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaUbico"
        If FechaUbico = FechaNula Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = FechaUbico
        End If

        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Articulo"
        parametro.Value = Articulo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Calce"
        parametro.Value = Calce
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ValidacionParesAndrea]", listaParametros)


    End Function

    Public Function ConfirmacionParesANDREA(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal CodigoAtado As String, ByVal CodigoAndrea As String, ByVal Estiba As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OTId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoAtado"
        parametro.Value = CodigoAtado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estiba"
        parametro.Value = Estiba
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigoAndrea"
        parametro.Value = CodigoAndrea
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConfirmacionParesAndrea]", listaParametros)


    End Function


    Public Function LiberarUnidades(ByVal OTLiberar As String, ByVal UsuarioModifico As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = OTLiberar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioModifico"
        parametro.Value = UsuarioModifico
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_LiberarUnidades]", listaParametros)

    End Function



    Public Function ObtenerClienteOT(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoID "
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ObtenerClienteOT]", listaParametros)

    End Function



    Public Function CancelarEmbarque(ByVal OTCancelarEmbarque As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = OTCancelarEmbarque
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_CancelarEmbarque]", listaParametros)

    End Function



    Public Function ObtenerCodigosAndreaPorAtado(ByVal OrdenTrabajoSAYID As Integer, ByVal CodigoAtado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoSAYID"
        parametro.Value = OrdenTrabajoSAYID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Atado"
        parametro.Value = CodigoAtado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ObtenerCodigosAndreaPorAtado]", listaParametros)

    End Function

    Public Function ObtenerOrdenesTrabajoAgrupadasEmbarque(ByVal OrdenTrabajoSAYID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenesTrabajo"
        parametro.Value = OrdenTrabajoSAYID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTsAgrupadasEmbarque]", listaParametros)


    End Function

    Public Function ConsultarNumeroColumnasPorFecha() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return objPersistencia.EjecutaConsulta("exec [Ventas].[SP_OrdenTrabajo_ConsultarColumnasPorFecha]")

    End Function

    Public Sub LiberarUnidades()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("exec [Ventas].[SP_OrdenTrabajo_LiberarUnidadesOrdenesFechaTerminoEmbarqueCumplida]")

    End Sub


    Public Function ConsultaInformacionCodigoAndrea(ByVal CodigoAndrea As String, ByVal OTID As Integer, ByVal Atado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "CodigoAndrea"
        parametro.Value = CodigoAndrea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OTID"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Atado"
        parametro.Value = Atado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaInformacionCodigoAndrea]", listaParametros)

    End Function



    Public Function IniciarTiempoEjecucionOperador(ByVal colaboradorConfirmaID As Integer, ByVal OTID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = colaboradorConfirmaID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "OT"
        parametro.Value = OTID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "TipoMedicion"
        parametro.Value = 1
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AsignarTiempoEjecucionOperador]", listaParametros)

    End Function


    Public Function FinalizarTiempoEjecucionOperador(ByVal colaboradorConfirmaID As Integer, ByVal OTID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = colaboradorConfirmaID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "OT"
        parametro.Value = OTID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "TipoMedicion"
        parametro.Value = 2
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AsignarTiempoEjecucionOperador]", listaParametros)

    End Function


    Public Function InformacionCodigoAndrea(ByVal CodigoAndrea As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "CodigoAndrea"
        parametro.Value = CodigoAndrea
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_InformacionCodigoAndrea]", listaParametros)

    End Function


    Public Function CrearArchivoConfirmacionAndrea(ByVal OTID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing
        Dim query As String = String.Empty

        query = <cadena>
                    SELECT ID_Docena, CodigoAndrea
                    from Ventas.vParesAlmacen_ANDREA_HandHeld
                    where OTSAY=<%= OTID.ToString() %>
                    ORDER by ID_Docena
                </cadena>

        Return objPersistencia.EjecutaConsulta(query)

    End Function


    Public Function ConsultaDatosParaXMLAndrea(ByVal OrdenTrabajoId As Integer, ByVal NumLoteAndreaId As String, ByVal FechaConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NumLoteAndreaId"
        parametro.Value = NumLoteAndreaId
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_SeleccionarDatosXmlv3]", listaParametros)

    End Function


    Public Function ConsultaLotesAndreaPorOT(ByVal FechaConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_SeleccionarLotesAndreaConfirmadosv2]", listaParametros)

    End Function

    Public Sub ActualizaParesConArchivoGeneradoEnOT(ByVal OrdenTrabajoId As String, ByVal NumLoteAndreaId As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NumLoteAndreaId"
        parametro.Value = NumLoteAndreaId
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ActualizarParesArchivosGeneradosAndrea]", listaParametros)

    End Sub

    Public Function DesasignarOperadorOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_DesasignarOperadorOT]", listaParametros)

    End Function

    Public Function ConsultarDireccionesTienda(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Reporte_TerminoOTDireccionesEntregav5]", listaParametros)

    End Function

    Public Function GenerarImpresionOT(ByVal OrdenTrabajoID As String, ByVal UsuarioId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_GenerarImpresionOT]", listaParametros)

    End Function


    Public Function ObtenerCantidadTiendas(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Reporte_ObtenerNumeroTiendas]", listaParametros)

    End Function

    Public Function VerificarPartidasAntesRechazarOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoIdSAY"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Rechazar_VerificarPartidasPorFacturar]", listaParametros)

    End Function

    Public Function CancelarPartidasOT(ByVal OrdenTrabajoID As String, ByVal UsuarioID As String, ByVal PartidasIds As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Partidas"
        parametro.Value = PartidasIds
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_CancelarPartidasOT]", listaParametros)

    End Function

    Public Function CancelarParesDeOTSICY(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "IdOrdenTrabajoSAY"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Cancelar_DesasignarPares]", listaParametros)

    End Function
    Public Function ElimnarOtsInWork(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "IdOrdenTrabajoSAY"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Eliminar_De_Work]", listaParametros)

    End Function


    Public Function GenerarFacturasAndrea(ByVal OrdenTrabajoID As String, ByVal TotalPAres As Integer, ByVal Usuario As String, ByVal PArtidas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "idOTSAY"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idCadenaSICY"
        parametro.Value = 0
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "totalPares"
        parametro.Value = TotalPAres
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Usuario
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "partidas"
        parametro.Value = PArtidas
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[USP_EntregaFacturacionOT_Andrea]", listaParametros)

    End Function

    Public Function ObtenerNombreCortoColaborador(ByVal ColaboradorID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "ColaboradorId"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ObtenerNombreCortoColaborador]", listaParametros)

    End Function


    Public Function EnviarFacturarPartidas(ByVal OrdenTrabajoID As Integer, ByVal Partidas As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OTId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "PArtidas"
        parametro.Value = Partidas
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_EnviarFacturarPartidas]", listaParametros)

    End Function

    Public Function CancelarOT(ByVal OrdenTrabajoID As String, ByVal UsuarioID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "IdOrdenTrabajoSAY"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_CancelarOT]", listaParametros)

    End Function

    Public Function ConsultaPartidaPorFacturarAndrea(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_ConsultaPartidaPorFacturar]", listaParametros)

    End Function

    Public Function ConsultaOperadorAsignadoAndrea(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_ConsultaOperadorAsignado]", listaParametros)

    End Function

    Public Function AsignaOperadorAndrea(ByVal OrdenTrabajoID As Integer, ByVal OperadorID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OperadorID"
        parametro.Value = OperadorID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_AsignacionOperador]", listaParametros)

    End Function


    Public Function DesasignaOperadorAndrea(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_DesasignacionOperador]", listaParametros)

    End Function


    Public Function GenerarEtiquetasAndrea(ByVal OrdenTrabajoID As Integer, ByVal LoteAndrea As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "LoteAndrea"
        parametro.Value = LoteAndrea
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_CodigosAndreaEtiquetas]", listaParametros)

    End Function


    Public Function GenerarEtiquetasAndreavariosLotes(ByVal OrdenTrabajoID As Integer, ByVal LoteAndrea As String, ByVal FechaConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "LoteAndrea"
        parametro.Value = LoteAndrea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_CodigosAndreaEtiquetasVariosLotes]", listaParametros)

    End Function

    Public Function ConsultaLotesAndreaPorLOTEtiquetasPorFecha(ByVal FechaConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_GeneracionEtiquetasXMLv2]", listaParametros)


    End Function

    Public Function ObtenerNumeroPasilloEtiquetas(ByVal FechaConfirmacion As Date, ByVal NumeroLote As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "NumLoteAndreaId"
        parametro.Value = NumeroLote
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_SeleccionarDatosXml_Etiquetas]", listaParametros)

    End Function


    Public Function ObtenerCodigosAndreaConfirmadosPorFecha(ByVal FechaConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "FechaConfirmo"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_oRDENTRABAJO_ETIQUETAS]", listaParametros)

    End Function


    Public Function ActualizarEstatusGenerarXMLEtiquetas(ByVal LoteAndrea As String, ByVal FechaConfirmacion As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "LotesAndrea"
        parametro.Value = LoteAndrea
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaConfirmacion"
        parametro.Value = FechaConfirmacion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ActualizarEstatusGenerarArchivoXMLEtiquetas]", listaParametros)

    End Function


    Public Function CapturaObservacionesOT(ByVal OrdenTrabajoID As String, ByVal Observaciones As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Observaciones"
        parametro.Value = Observaciones
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_CapturaObservaciones]", listaParametros)

    End Function

    Public Function ObtenerObservacionesOT(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ObtenerObservacionesOT]", listaParametros)

    End Function


    Public Function EliminarObservacionesOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_EliminarObservacionesOT]", listaParametros)

    End Function


    Public Function ObtenerHorariosRecibo(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "IdOrdenTrabajoSAY"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Reporte_ObtenerHorariosRecibeCliente]", listaParametros)

    End Function


    Public Function ConsultarInformacionReporteTerminoOTSinCita(ByVal OrdenTrabajoID As String, ByVal UsuarioImprimioID As Integer, ByVal ClientesSinCita As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioImprimio"
        parametro.Value = UsuarioImprimioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Reporte_TerminoOT_SinCitav5]", listaParametros)

    End Function


    Public Function ConsultarInformacionReporteTerminoOTConCita(ByVal OrdenTrabajoID As String, ByVal UsuarioImprimioID As Integer, ByVal ClientesSinCita As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioImprimio"
        parametro.Value = UsuarioImprimioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Reporte_TerminoOT_ConCitaV5]", listaParametros)

    End Function

    Public Function ClienteTieneCita(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ClienteTieneCita]", listaParametros)

    End Function


    Public Function CargarOTVentasFiltrosDefault(ByVal TipoOT As String, ByVal AtnClientes As String, ByVal StatusOT As String, ByVal RequiereCita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CEDISID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RequiereCita"
        parametro.Value = RequiereCita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTs_Ventas_SinFiltros_v2]", listaParametros)

    End Function


    Public Function CargarOTVentasConFiltros(ByVal TipoOT As String, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal ClienteID As String, ByVal TiendaID As String, ByVal AtnClientes As String, ByVal AgenteVentasID As String, ByVal StatusOT As String, ByVal MarcaId As String, ByVal ColeccionID As String, ByVal ModeloID As String, ByVal PielId As String, ByVal ColorID As String, ByVal Corrida As String, ByVal CEDISID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cita"
        parametro.Value = Cita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FEchaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = TiendaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = AgenteVentasID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = MarcaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = ColeccionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = ModeloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = PielId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = ColorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTs_Ventas_ConFiltros_Optimizado_v2]", listaParametros)

    End Function


    Public Function CargarOTAlmacenFiltrosDefault(ByVal TipoOT As String, ByVal StatusOT As String, ByVal RequiereCita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, Optional ByVal UsuarioID As Integer = 1, Optional ByVal CEDISID As Integer = 43) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cita"
        parametro.Value = RequiereCita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISID"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTsAlmacenSinFiltrosv2_v2]", listaParametros)

    End Function


    Public Function CargarOTAlmacenConFiltros(ByVal TipoOT As String, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal ClienteID As String, ByVal TiendaID As String, ByVal AtnClientes As String, ByVal AgenteVentasID As String, ByVal StatusOT As String, ByVal MarcaId As String, ByVal ColeccionID As String, ByVal ModeloID As String, ByVal PielId As String, ByVal ColorID As String, ByVal Corrida As String, ByVal OperadorId As String, ByVal UsuarioID As Integer, ByVal CEDISID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "TipoOT"
        parametro.Value = TipoOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cita"
        parametro.Value = Cita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoFecha"
        parametro.Value = TipoFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FEchaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = PedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioOT"
        parametro.Value = FolioOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = ClienteID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tienda"
        parametro.Value = TiendaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = AtnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = AgenteVentasID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusOt"
        parametro.Value = StatusOT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = MarcaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = ColeccionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = ModeloID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = PielId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = ColorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = Corrida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Operador"
        parametro.Value = OperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioID"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CEDISId"
        parametro.Value = CEDISID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultarOTsAlmacenConFiltros_v2]", listaParametros)

    End Function


    Public Function ParesConfirmadosOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Desasignacion_ParesConfirmadosOT]", listaParametros)

    End Function

    Public Function ObtenerParesConfirmadosOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ObtenerParesConfirmados]", listaParametros)

    End Function


    Public Function EnviarAFacturarOT(ByVal OTID As Integer, ByVal ColaboradorId As Integer, ByVal TotalPares As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalPares"
        parametro.Value = TotalPares
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_GenerarFactura]", listaParametros)

    End Function




    Public Function ObtenerInformacionParesOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OrdenTrabajoID
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Impresion_ParesOT]", listaParametros)

    End Function

    Public Sub ActualizarAPorFacturarOT(ByVal OTID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OTID"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_FacturaGenerada]", listaParametros)

    End Sub

    Public Sub ActualizarEstatusPartidaOrdenTrabajo(ByVal OTID As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "OTID"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ActualizarEstatusPartidas]", listaParametros)

    End Sub


    Public Function ConsultarDestinatariosCorreoOTYISTI(ByVal Clave As String, ByVal NaveSAYID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "ClaveEnvio"
        parametro.Value = Clave
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "NaveID"
        parametro.Value = NaveSAYID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ConsultaDatosCorreosAutorizacionOT]", listaParametros)

    End Function


    Public Function ConsultarPartidasParesRechazadosAndrea(ByVal OTID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_PartidasParesRechazados]", listaParametros)
    End Function

    Public Function CancelarParesRechazados(ByVal OTID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_CancelarParesRechazados]", listaParametros)
    End Function

    Public Function DesasignarParesCanceladosAndrea(ByVal OTID As Integer, ByVal OrdenTrabajoDetalleId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrdenTrabajoPartidaDEtalleId"
        parametro.Value = OrdenTrabajoDetalleId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Cancelar_ParesAndrea_v2]", listaParametros)

    End Function

    Public Function ConsultarAgenteVentas(ColaboradorID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@colaboradorId"
            parametro.Value = ColaboradorID
            listaParametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Ventas].[SP_AdministradorOT_ConsultasFiltros_Agente]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviarDatosParaConfirmacion(OrdenTrabajoID As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@OTID"
            parametro.Value = OrdenTrabajoID
            listaParametros.Add(parametro)

            operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_EnviaDatosConfirmacion_Work]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub ActualizarOTUbicaciones(OrdenTrabajoID As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@OTID"
            parametro.Value = OrdenTrabajoID
            listaParametros.Add(parametro)

            operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_ActualizaOT_Ubicaciones_Optimizado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function AsignarNumeroASN(OrdenTrabajos As String, numeroASN As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@OTs"
            parametro.Value = OrdenTrabajos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@numeroASN"
            parametro.Value = numeroASN
            listaParametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenesTrabajo_AsignarNumeroASN]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function CancelarParesRechazadosAndrea(ByVal OTID As Integer, ByVal UsuarioID As Integer, ByVal PartidaDetalleID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim FechaNula As Date = Nothing

        parametro.ParameterName = "OrdenTrabajoId"
        parametro.Value = OTID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PartidaDetalleID"
        parametro.Value = PartidaDetalleID
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_Andrea_CancelarParesRechazados_v2]", listaParametros)
    End Function

    Public Function ConsultarReporteOTDesasignacion_Encabezado(ordenTrabajo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ordenTrabajoId"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ConsultarReporteOTDesasignacion_Encabezado]", listaParametros)
    End Function

    Public Function ConsultarReporteOTDesasignacion(ordenTrabajo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ordenTrabajoId"
        parametro.Value = ordenTrabajo
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Cancelacion_ConsultarReporteOTDesasignacion]", listaParametros)
    End Function

    Public Function ValidarestatusPedido(ByVal pedidoId As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@pedidoId", pedidoId)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_COnsultaEstatusPedido]", listaParametros)
    End Function

    Public Function ConsultaTiendasRFC(ByVal clienteid As Integer, ByVal rfc As Integer)
        'ByVal pedido As Integer, 
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        'Dim Parametro = New SqlParameter("@pedido", pedido)
        'listaparametros.Add(Parametro)

        Dim Parametro = New SqlParameter("@cliente", clienteid)
        listaparametros.Add(Parametro)

        Parametro = New SqlParameter("@RFCid", rfc)
        listaparametros.Add(Parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ConsultaTiendasRFC]", listaparametros)

    End Function

    Public Function ConsultaRFCCliente(ByVal clienteId As Integer, ByVal rfcBloqueado As Integer, ByVal pedidoId As Integer)
        ', ByVal PedidoId As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@clienteid", clienteId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfcBloqueado", rfcBloqueado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PedidoId", pedidoId)
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ConsultaRFCCliente]", listaParametros)
    End Function

    Public Function ConultaDetallePedido(ByVal pedidoId As Integer, ByVal Ots As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@pedidoId", pedidoId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Ots", Ots)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_Consulta_DetallePedido]", listaParametros)

    End Function

    Public Function CambioDeTiendaPartidasPedido(ByVal rfc As Integer, ByVal pedidoSAY As Integer, ByVal pedidoSICY As Integer, ByVal partida As String,
                                                 ByVal TIECNuevo As Integer, ByVal rfcSICYNuevo As Integer, ByVal ordenCompra As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@RFC", rfc)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PEdidoSAY", pedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PedidoSICY", pedidoSICY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@PArtidas", partida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TiendaEmbarqueID", TIECNuevo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@RFCIdSICY", rfcSICYNuevo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@OrdenCompra", ordenCompra)
        listaParametros.Add(parametro)


        'Return MsgBox(rfc & " " & pedidoSAY & " " & pedidoSICY & " " & partida & " " & TIECNuevo)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_MesaAyuda_CambiarRFCTiendaPedido]", listaParametros)

    End Function

    Public Function GuardarRespaldo(ByVal pedidoSAY As Integer, ByVal pedidoSICY As Integer, ByVal OT As Integer, ByVal Partida As Integer,
                                    ByVal RFCAnterior As Integer, ByVal RFCNuevo As Integer, ByVal TECAnterior As Integer, TECNuevo As Integer,
                                    ByVal UsuarioId As Integer, ByVal rfcSICYNuevo As Integer, ByVal modificado As Integer,
                                    ByVal OCAnterior As String, ByVal OCNuevo As String)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@pedidoSAY", pedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@pedidoSICY", pedidoSICY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ot", OT)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@partida", Partida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfcanterior", RFCAnterior)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfcnuevo", RFCNuevo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tecanterior", TECAnterior)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tecnuevo", TECNuevo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioodifico", UsuarioId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@rfcidSICY", rfcSICYNuevo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@modificado", modificado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ocAnterior", OCAnterior)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ocNuevo", OCNuevo)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Ventas_GuardarRespaldoTiendas]", listaParametros)

    End Function

    Public Function ValidaExistenOtFacturadasEnPedido(ByVal pedidoSAY As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@pedidoId", pedidoSAY)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ValidaExistenOtFacturadasEnPedido]", listaParametros)

    End Function

    Public Function ActualizarOts_CambiarOrdenCompra_CargoAdicional_Sac(ByVal Ot As String, ByVal OrdenCompra As String, ByVal cargoAdicional As Decimal) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@OrdenTrabajo"
        parametro.Value = Ot
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@OrdenCompra"
        parametro.Value = OrdenCompra
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CargoAdicional"
        parametro.Value = cargoAdicional
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_OrdenTrabajo_AplicarCargosPorOT]", listaParametros)
    End Function

    Public Function ActualizarOCcliente(ByVal ordenTrabajoId As Integer, ByVal ocNuevo As String)
        'ByVal ocNuevo As String, ByVal pedidosay As Integer, ByVal pedidosicy As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros = New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@ot", ordenTrabajoId)
        listaParametros.Add(parametro)

        'parametro = New SqlParameter("@pedidosay", pedidosay)
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter("@pedidosicy", pedidosicy)
        'listaParametros.Add(parametro)

        parametro = New SqlParameter("@ocNuevo", ocNuevo)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Cambio_OC_PedidoCliente]", listaParametros)
    End Function

End Class
