Imports System.Xml


Public Class OrdenTrabajoBU

    Public Function ConsultarOTs(ByVal PerfilId As Int32, ByVal TipoOT As Integer, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date,
                                 ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal AtnClientes As String,
                                 ByVal AgenteVentas As String, ByVal StatusOT As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal Piel As String,
                                 ByVal Color As String, ByVal Corrida As String, ByVal Operador As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarOTs(PerfilId, TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, Cliente, Tienda, AtnClientes, AgenteVentas, StatusOT, Marca, Coleccion, Modelo, Piel, Color, Corrida, Operador)
    End Function

    Public Function AutorizarOT(ByVal OrdenTrabajoID As Int32, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.AutorizarOT(OrdenTrabajoID, UsuarioID)
    End Function

    Public Function RechazarOT(ByVal OrdenTrabajoID As String, ByVal UsuarioID As String, ByVal MotivoRechazo As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.RechazarOT(OrdenTrabajoID, UsuarioID, MotivoRechazo)
    End Function

    Public Function ConsultarParesAtadoAndrea(ByVal OrdenTrabajoID As Int32, ByVal LoteId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarParesAtadoAndrea(OrdenTrabajoID, LoteId)
    End Function

    Public Function ConsultarCodigosAndreaXml(ByVal OrdenTrabajoID As Int32, ByVal LoteId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarCodigosAndreaXml(OrdenTrabajoID, LoteId)
    End Function


    Public Function ConsultarPartidasOrdenTrabajo(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarPartidasOrdenTrabajo(OrdenTrabajoID)
    End Function

    Public Function ConsultarParesPartidasOrdenTrabajo(ByVal OrdenTrabajoID As String, ByVal Partida As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarParesPartidasOrdenTrabajo(OrdenTrabajoID, Partida)
    End Function

    Public Function ConsultarInformacionOT(ByVal OrdenTrabajoID As Int32) As Entidades.OrdenTrabajo
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Dim DTInformacion As DataTable
        Dim objEnt As New Entidades.OrdenTrabajo
        DTInformacion = objDA.ConsultarInformacionOT(OrdenTrabajoID)

        If DTInformacion.Rows.Count > 0 Then
            objEnt.OrdenTrabajoID = DTInformacion.Rows(0).Item("OrdenTrabajo")
            objEnt.OrdenTrabajoSICYID = DTInformacion.Rows(0).Item("OrdenTrabajoSICYID")
            objEnt.ClienteSAYID = DTInformacion.Rows(0).Item("ClienteSAYID")
            objEnt.Cliente = DTInformacion.Rows(0).Item("Cliente")
            objEnt.PedidoSAYID = DTInformacion.Rows(0).Item("PedidoSAYID")
            objEnt.PedidoSICYID = DTInformacion.Rows(0).Item("PedidoSICY")
            objEnt.TipoOT = DTInformacion.Rows(0).Item("TIPOOT")
            objEnt.EstatusID = DTInformacion.Rows(0).Item("StatusID")
            objEnt.Estatus = DTInformacion.Rows(0).Item("Status")
            objEnt.TotalPares = DTInformacion.Rows(0).Item("TotalPares")
            objEnt.TotalParesConfirmados = DTInformacion.Rows(0).Item("ParesConfirmados")
            objEnt.TotalParesPorConfirmar = DTInformacion.Rows(0).Item("ParesPorConfirmar")
            objEnt.TotalParesCancelados = DTInformacion.Rows(0).Item("ParesCancelados")
            objEnt.ParesErroneos = DTInformacion.Rows(0).Item("ParesErroneos")
            objEnt.ParesCorregidos = DTInformacion.Rows(0).Item("ParesCorregidos")
            objEnt.TotalParesIncidencias = DTInformacion.Rows(0).Item("ParesIncidencia")
            objEnt.FechaCaptura = DTInformacion.Rows(0).Item("FechaCaptura")
            objEnt.OrdenCliente = DTInformacion.Rows(0).Item("OrdenCliente")
            If IsDBNull(DTInformacion.Rows(0).Item("FechaPreparacion")) = True Then
                objEnt.FechaPreparacion = Nothing
            Else
                objEnt.FechaPreparacion = DTInformacion.Rows(0).Item("FechaPreparacion")
            End If

            objEnt.FacturacionAnticipada = IIf(IsDBNull(DTInformacion.Rows(0).Item("FA")) = False, DTInformacion.Rows(0).Item("FA"), False)

        End If

        Return objEnt

    End Function

    Public Function ConfirmacionPares(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal TipoCodigo As Integer, ByVal CodigoPar As String, ByVal Estiba As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConfirmacionPares(OrdenTrabajoID, OperadorId, TipoCodigo, CodigoPar, Estiba)
    End Function

    Public Function ObtenerTotalesOT(ByVal OrdenTrabajoID As String) As Entidades.OrdenTrabajo
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Dim DTInformacion As DataTable
        Dim objEnt As New Entidades.OrdenTrabajo
        DTInformacion = objDA.ObtenerTotalesOT(OrdenTrabajoID)

        If DTInformacion.Rows.Count > 0 Then

            objEnt.TotalPares = DTInformacion.Rows(0).Item("TotalPares")
            objEnt.TotalParesConfirmados = DTInformacion.Rows(0).Item("ParesConfirmados")
            objEnt.TotalParesPorConfirmar = DTInformacion.Rows(0).Item("ParesPorConfirmar")
            objEnt.TotalParesCancelados = DTInformacion.Rows(0).Item("ParesCancelados")
            objEnt.ParesErroneos = DTInformacion.Rows(0).Item("ParesErroneos")
            objEnt.ParesCorregidos = DTInformacion.Rows(0).Item("ParesCorregidos")
            objEnt.TotalParesIncidencias = DTInformacion.Rows(0).Item("ParesIncidencia")

        End If

        Return objEnt
    End Function

    Public Function ValidacionPares(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal TipoCodigo As Integer, ByVal CodigoPar As String, ByVal Estiba As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ValidacionPares(OrdenTrabajoID, OperadorId, TipoCodigo, CodigoPar, Estiba)
    End Function

    Public Function CancelarPartidasOT(ByVal OrdenTrabajoID As String, ByVal UsuarioID As String, ByVal PartidasIds As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CancelarPartidasOT(OrdenTrabajoID, UsuarioID, PartidasIds)
    End Function

    Public Function ActualizarEncabezadosOrdenTrabajo() As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ActualizarEncabezadosOrdenTrabajo()
    End Function


    Public Function ConsultaMensajeriasAltaEmbarquesAgenda(ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaMensajeriasAltaEmbarquesAgenda(UsuarioID)
    End Function

    Public Function ConsultaOperadoresAltaEmbarquesAgenda() As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaOperadoresAltaEmbarquesAgenda()
    End Function

    Public Function ConsultaUnidadesAltaEmbarquesAgenda() As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaUnidadesAltaEmbarquesAgenda()
    End Function

    Public Sub InsertarCitaEntrega(ByVal AltaCita As Entidades.OrdenTrabajoCitaEntrega)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.InsertarEditarCitaEntrega(AltaCita)
    End Sub

    Public Function ActualizarFechaPreparacion(ByVal OrdenTrabajoID As String, ByVal FechaPreparacion As Date, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ActualizarFechaPreparacion(OrdenTrabajoID, FechaPreparacion, UsuarioID)
    End Function

    Public Sub InsertarEditarEmbarqueEntrega(ByVal AltaEmbarque As Entidades.OrdenTrabajoEmbarqueEntrega)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.InsertarEditarEmbarqueEntrega(AltaEmbarque)
    End Sub


    Public Function ConsultarDetalleOTs(ByVal PerfilId As Int32, ByVal TipoOT As Integer, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date,
                                ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal AtnClientes As String,
                                ByVal AgenteVentas As String, ByVal StatusOT As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal Piel As String,
                                ByVal Color As String, ByVal Corrida As String, ByVal Operador As String, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarDetalleOTs(PerfilId, TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, Cliente, Tienda, AtnClientes, AgenteVentas, StatusOT, Marca, Coleccion, Modelo, Piel, Color, Corrida, Operador, CEDISID)
    End Function

    Public Function ConsultarDetalleOTsPaqueteria(ByVal OrdenesTrabajo As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarDetalleOTsPaqueteria(OrdenesTrabajo)
    End Function

    Public Function ConsultarOTsAlmacen(ByVal PerfilId As Int32, ByVal TipoOT As Integer, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date,
                               ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal Cliente As String, ByVal Tienda As String, ByVal AtnClientes As String,
                               ByVal AgenteVentas As String, ByVal StatusOT As String, ByVal Marca As String, ByVal Coleccion As String, ByVal Modelo As String, ByVal Piel As String,
                               ByVal Color As String, ByVal Corrida As String, ByVal Operador As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarOTsAlmacen(PerfilId, TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, Cliente, Tienda, AtnClientes, AgenteVentas, StatusOT, Marca, Coleccion, Modelo, Piel, Color, Corrida, Operador)
    End Function

    Public Function ConsultarIncidencias(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarIncidencias(OrdenTrabajoID)
    End Function

    Public Function ConsultarErrores(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarErrores(OrdenTrabajoID)
    End Function



    Public Function ConsultarCitasEmbarquesModoLista(ByVal SinAgendar As Integer, ByVal Agendado As Integer, ByVal TipoEntrega As Integer, ByVal Unidad As Integer, ByVal EsYISTI As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.LiberarUnidades()
        Return objDA.ConsultarCitasEmbarquesModoLista(SinAgendar, Agendado, TipoEntrega, Unidad, EsYISTI)
    End Function



    Public Function AceptarOTAlmacen(ByVal OrdenTrabajoID As Int32, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.AceptarOTAlmacen(OrdenTrabajoID, UsuarioID)
    End Function

    Public Function AsignarOperadorOT(ByVal OrdenTrabajoID As String, ByVal OperadorId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.AsignarOperadorOT(OrdenTrabajoID, OperadorId)
    End Function

    Public Function ConsultarPartidasAsignacionOperador(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarPartidasAsignacionOperador(OrdenTrabajoID)
    End Function

    Public Function AsignarOperadorPartidaOT(ByVal OrdenTrabajoID As String, ByVal Partida As String, ByVal OperadorId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.AsignarOperadorPartidaOT(OrdenTrabajoID, Partida, OperadorId)
    End Function

    Public Function ConsultarInformacionReporteTerminoOT(ByVal OrdenTrabajoID As String, ByVal UsuarioImprimioID As Integer, ByVal ClientesConCita As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Dim DTInformacionReporte As New DataTable
        Dim objEnt As New Entidades.OrdenTrabajoReporteTermino
        Dim DTDomicilios As DataTable
        Dim Domicilio As Entidades.OrdenTrabajoDireccionEntrega
        Dim NumeroTiendas As Integer = 0
        Dim dtOrdenTrabajo As New DataTable
        Dim dtInformacionOt As DataTable
        Dim OTImpresionID As String()
        Dim indice As Integer = 0
        'Dim DTHorariosRecibe As DataTable
        Dim ClienteTieneCita As DataTable

        OTImpresionID = Split(OrdenTrabajoID, ",")

        For Each Item As String In OTImpresionID
            ClienteTieneCita = objDA.ClienteTieneCita(Item)

            If CBool(ClienteTieneCita.Rows(0).Item(0)) = ClientesConCita Then
                indice += 1
                If indice = 1 Then

                    If ClientesConCita = True Then
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTConCita(Item, UsuarioImprimioID, ClientesConCita)
                    Else
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTSinCita(Item, UsuarioImprimioID, ClientesConCita)
                    End If

                    If dtInformacionOt.Rows.Count > 0 Then
                        DTInformacionReporte = dtInformacionOt.Clone()
                        DTInformacionReporte.ImportRow(dtInformacionOt.Rows(0))
                    End If

                Else
                    If ClientesConCita = True Then
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTConCita(Item, UsuarioImprimioID, ClientesConCita)
                    Else
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTSinCita(Item, UsuarioImprimioID, ClientesConCita)
                    End If

                    If dtInformacionOt.Rows.Count > 0 Then
                        DTInformacionReporte.ImportRow(dtInformacionOt.Rows(0))
                    End If

                End If
            End If

        Next



        dtOrdenTrabajo = New DataTable("dtOrdenTrabajo")
        With dtOrdenTrabajo
            .Columns.Add("OTCodigo")
            .Columns.Add("Cliente")
            .Columns.Add("FechaEntrega")
            .Columns.Add("AtnClientes")
            .Columns.Add("FechaCreacion")
            .Columns.Add("OT")
            .Columns.Add("Agente")
            .Columns.Add("Transporte")
            .Columns.Add("Empaque")
            .Columns.Add("TotalEnviar")
            .Columns.Add("Cita")
            .Columns.Add("HoraCita")
            .Columns.Add("Confirmacion")
            .Columns.Add("Observaciones")
            .Columns.Add("TipoEmpaque")
            .Columns.Add("EntregarPedido")
            .Columns.Add("FacturarPor")
            .Columns.Add("ImporteMax")
            .Columns.Add("Facturacion")
            .Columns.Add("NotasVentas")
            .Columns.Add("NotasEmpaque")
            .Columns.Add("EntregarEn")
            .Columns.Add("Direccion")
            .Columns.Add("Colonia")
            .Columns.Add("Ciudad")
            .Columns.Add("Estado")
            .Columns.Add("CP")
            .Columns.Add("Convenio")
            .Columns.Add("ContactoRampa")
            .Columns.Add("NotasEmbarque")
            .Columns.Add("DiasEntrega")
            .Columns.Add("UsuarioImprimio")
            .Columns.Add("FechaImpresion")
            .Columns.Add("OTUbicacion")
            .Columns.Add("PedidoSICY")
            .Columns.Add("PedidoSAY")
            .Columns.Add("Tienda")
            .Columns.Add("RFC")
            .Columns.Add("ObservacionesPedido")
            .Columns.Add("HorariosRecibo")
            .Columns.Add("IDEmbarque")
            .Columns.Add("IdRazonSocial")
            .Columns.Add("RazonSocial")
            .Columns.Add("NumeroPersonas")
            .Columns.Add("IDSAY")
            .Columns.Add("RFCSAY")
            .Columns.Add("RazonSocialSAY")
            .Columns.Add("OrdenCliente")
            .Columns.Add("LlevaCopiaPedido")
        End With


        If IsNothing(DTInformacionReporte) = False Then
            For Each Fila As DataRow In DTInformacionReporte.Rows
                objEnt = New Entidades.OrdenTrabajoReporteTermino
                objEnt.UsuarioImprimio = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                objEnt.OrdenTrabajoID = Fila.Item("OTSAYID").ToString()
                objEnt.OTCodigo = Fila.Item("OTCodigoSAYID").ToString()

                'If ClientesConCita = False Then
                '    DTHorariosRecibe = objDA.ObtenerHorariosRecibo(objEnt.OrdenTrabajoID)

                '    If DTHorariosRecibe.Rows.Count > 0 Then

                '        For Each FilaHorario As DataRow In DTHorariosRecibe.Rows
                '            objEnt.HorariosRecibo &= FilaHorario.Item("HorarioRecibe").ToString() + vbCrLf
                '        Next

                '    Else
                '        objEnt.HorariosRecibo = "-----------------------------"
                '    End If

                'Else
                '    objEnt.HorariosRecibo = "-----------------------------"
                'End If

                If IsDBNull(Fila.Item("IDRFCSAY")) = False Then
                    objEnt.IDSAY = CadenaVacia(Fila.Item("IDRFCSAY"), False, False, False)
                Else
                    objEnt.IDSAY = "---"
                End If


                If IsDBNull(Fila.Item("OrdenCliente")) = False Then
                    objEnt.OrdenCliente = CadenaVacia(Fila.Item("OrdenCliente"), False, False, False)
                Else
                    objEnt.OrdenCliente = "---"
                End If


                If IsDBNull(Fila.Item("RFCSAY")) = False Then
                    objEnt.RFCSAY = CadenaVacia(Fila.Item("RFCSAY"), False, False, False)
                Else
                    objEnt.RFCSAY = "---"
                End If

                If IsDBNull(Fila.Item("RazonSocialSAY")) = False Then
                    objEnt.RazonSocialSAY = CadenaVacia(Fila.Item("RazonSocialSAY"), False, False, False)
                Else
                    objEnt.RazonSocialSAY = "---"
                End If

                If IsDBNull(Fila.Item("NumeroPersonas")) = False Then
                    objEnt.NumeroPersonas = CadenaVacia(Fila.Item("NumeroPersonas"), False, False, False)
                Else
                    objEnt.NumeroPersonas = "---"
                End If

                If IsDBNull(Fila.Item("IDEmbarque")) = False Then
                    objEnt.IDEmbarque = CadenaVacia(Fila.Item("IDEmbarque"), False, False, False)
                Else
                    objEnt.IDEmbarque = "---"
                End If

                If IsDBNull(Fila.Item("IdRazonSocial")) = False Then
                    objEnt.IdRazonSocial = CadenaVacia(Fila.Item("IdRazonSocial"), False, False, False)
                Else
                    objEnt.IdRazonSocial = "---"
                End If

                If IsDBNull(Fila.Item("RazonSocial")) = False Then
                    objEnt.RazonSocial = CadenaVacia(Fila.Item("RazonSocial"), False, False, False)
                Else
                    objEnt.RazonSocial = "--------------"
                End If


                ' objEnt.HorariosRecibo = objEnt.HorariosRecibo.Trim()

                If IsDBNull(Fila.Item("OTSICYID")) = False Then
                    objEnt.OrdenTrabajoSICYID = CadenaVacia(Fila.Item("OTSICYID"), False, False, False)
                Else
                    objEnt.OrdenTrabajoSICYID = "0"
                End If

                If IsDBNull(Fila.Item("Agente")) = False Then
                    objEnt.Agente = CadenaVacia(Fila.Item("Agente"), False, False)
                Else
                    objEnt.Agente = "-----------------------------"
                End If


                If IsDBNull(Fila.Item("Cliente")) = False Then
                    objEnt.Cliente = CadenaVacia(Fila.Item("Cliente"), False, False)
                Else
                    objEnt.Cliente = "----------------------------"
                End If


                If IsDBNull(Fila.Item("Transporte")) = False Then
                    objEnt.Transporte = CadenaVacia(Fila.Item("Transporte"), False, False)
                Else
                    objEnt.Transporte = "----------------------------"
                End If

                If IsDBNull(Fila.Item("TipoEmpaque")) = False Then
                    objEnt.TipoEmpaque = CadenaVacia(Fila.Item("TipoEmpaque"), False, False)
                Else
                    objEnt.TipoEmpaque = "----------------------------"
                End If

                If IsDBNull(Fila.Item("TotalEnviar")) = False Then
                    objEnt.TotalEnviar = CadenaVacia(Fila.Item("TotalEnviar"), False, True)
                Else
                    objEnt.TotalEnviar = "0"
                End If

                If IsDBNull(Fila.Item("FechaCita")) = False Then
                    objEnt.Cita = CadenaVacia(Fila.Item("FechaCita"), True, False, False)
                    objEnt.HoraCita = CadenaVacia(Fila.Item("HoraCita"), False)
                Else
                    objEnt.HoraCita = "----------------------------"
                    objEnt.Cita = "----------------------------"
                End If

                If IsDBNull(Fila.Item("Confirmacion")) = False Then
                    objEnt.Confirmacion = CadenaVacia(Fila.Item("Confirmacion"), False, False)
                Else
                    objEnt.Confirmacion = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ObservacionesCita")) = False Then
                    objEnt.Observaciones = CadenaVacia(Fila.Item("ObservacionesCita"), False, False)
                Else
                    objEnt.Observaciones = "----------------------------"

                End If

                If IsDBNull(Fila.Item("Atncliente")) = False Then
                    objEnt.AtnClientes = CadenaVacia(Fila.Item("Atncliente"), False)
                Else
                    objEnt.AtnClientes = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FechaCreacion")) = False Then
                    objEnt.FechaCreacion = CadenaVacia(Fila.Item("FechaCreacion"), True)
                Else
                    objEnt.FechaCreacion = "----------------------------"
                End If


                If IsDBNull(Fila.Item("DiasEntrega")) = False Then
                    objEnt.DiasEntrega = CadenaVacia(Fila.Item("DiasEntrega"), False)
                Else
                    objEnt.DiasEntrega = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FechaImpresion")) = False Then
                    objEnt.FechaImpresion = CadenaVacia(Fila.Item("FechaImpresion"), True, , True)
                Else
                    objEnt.FechaImpresion = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FechaEntrega")) = False Then
                    objEnt.FechaEntrega = CadenaVacia(Fila.Item("FechaEntrega"), True)
                Else
                    objEnt.FechaEntrega = "----------------------------"
                End If

                If IsDBNull(Fila.Item("UbicaionOT")) = False Then
                    objEnt.UbicacionOT = CadenaVacia(Fila.Item("UbicaionOT"), False)
                Else
                    objEnt.UbicacionOT = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ENTREGAPEDIDO")) = False Then
                    objEnt.EntregarPedido = CadenaVacia(Fila.Item("ENTREGAPEDIDO"), False)
                Else
                    objEnt.EntregarPedido = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FacturarPor")) = False Then
                    objEnt.FacturarPor = CadenaVacia(Fila.Item("FacturarPor"), False)
                Else
                    objEnt.FacturarPor = "----------------------------"
                End If

                If IsDBNull(Fila.Item("NOTASVENTAS")) = False Then
                    objEnt.NotasVentas = CadenaVacia(Fila.Item("NOTASVENTAS"), False)
                Else
                    objEnt.NotasVentas = "----------------------------"
                End If

                If IsDBNull(Fila.Item("IMPORTEPORVENTA")) = False Then
                    objEnt.ImporteMaxVta = CadenaVacia(Fila.Item("IMPORTEPORVENTA"), False)
                Else
                    objEnt.ImporteMaxVta = "----------------------------"
                End If

                If IsDBNull(Fila.Item("PorcentajeFacturacion")) = False Then
                    objEnt.PorcentajeFacturacion = CadenaVacia(Fila.Item("PorcentajeFacturacion"), False)
                Else
                    objEnt.PorcentajeFacturacion = "0"
                End If

                If IsDBNull(Fila.Item("NOTASEMBARQUE")) = False Then
                    objEnt.EmbarqueNotas = CadenaVacia(Fila.Item("NOTASEMBARQUE"), False)
                Else
                    objEnt.EmbarqueNotas = "----------------------------"
                End If

                If IsDBNull(Fila.Item("LUGARENTREGA")) = False Then
                    objEnt.EmbarqueEntregarEn = CadenaVacia(Fila.Item("LUGARENTREGA"), False)
                Else
                    objEnt.EmbarqueEntregarEn = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ContactoRampa")) = False Then
                    objEnt.EmbarqueContactoRampa = CadenaVacia(Fila.Item("ContactoRampa"), False)
                Else
                    objEnt.EmbarqueContactoRampa = "----------------------------"
                End If

                If IsDBNull(Fila.Item("PedidoSICY")) = False Then
                    objEnt.PedidoSICY = CadenaVacia(Fila.Item("PedidoSICY"), False)
                Else
                    objEnt.PedidoSICY = "----------------------------"
                End If

                If IsDBNull(Fila.Item("PedidoSAY")) = False Then
                    objEnt.PedidoSAY = CadenaVacia(Fila.Item("PedidoSAY"), False)
                Else
                    objEnt.PedidoSAY = "----------------------------"
                End If

                If IsDBNull(Fila.Item("Tienda")) = False Then
                    objEnt.Tienda = CadenaVacia(Fila.Item("Tienda"), False)
                Else
                    objEnt.Tienda = "----------------------------"
                End If

                If IsDBNull(Fila.Item("RFC")) = False Then
                    objEnt.RFC = CadenaVacia(Fila.Item("RFC"), False)
                Else
                    objEnt.RFC = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ObservacionesPedido")) = False Then
                    objEnt.ObservacionesPedido = Fila.Item("ObservacionesPedido")
                Else
                    objEnt.ObservacionesPedido = "----------------------------"
                End If


                If IsDBNull(Fila.Item("LlevaCopiaPedido")) = False Then
                    If CBool(Fila.Item("LlevaCopiaPedido")) = True Then
                        objEnt.LlevaCopiaPedido = "SI"
                    Else
                        objEnt.LlevaCopiaPedido = "NO"
                    End If
                Else
                    objEnt.LlevaCopiaPedido = "NO"
                End If

                'Domicilios Tienda
                DTDomicilios = objDA.ConsultarDireccionesTienda(objEnt.OrdenTrabajoID)

                For Each filaDomicilio As DataRow In DTDomicilios.Rows
                    Domicilio = New Entidades.OrdenTrabajoDireccionEntrega

                    If IsDBNull(filaDomicilio.Item("Tienda")) = False Then
                        Domicilio.Tienda = CadenaVacia(filaDomicilio.Item("Tienda").ToString(), False)
                    Else
                        Domicilio.Tienda = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("DIRECCION")) = False Then
                        Domicilio.Calle = CadenaVacia(filaDomicilio.Item("DIRECCION").ToString(), False)
                    Else
                        Domicilio.Calle = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("COLONIA")) = False Then
                        Domicilio.Colonia = CadenaVacia(filaDomicilio.Item("COLONIA").ToString(), False)
                    Else
                        Domicilio.Colonia = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("Noexterior")) = False Then
                        Domicilio.NumeroExterior = CadenaVacia(filaDomicilio.Item("Noexterior").ToString(), False)
                    Else
                        Domicilio.NumeroExterior = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("Ciudad")) = False Then
                        Domicilio.Ciudad = CadenaVacia(filaDomicilio.Item("Ciudad").ToString(), False)
                    Else
                        Domicilio.Ciudad = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("Estado")) = False Then
                        Domicilio.Estado = CadenaVacia(filaDomicilio.Item("Estado").ToString(), False)
                    Else
                        Domicilio.Estado = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("CP")) = False Then
                        Domicilio.CP = CadenaVacia(filaDomicilio.Item("cp").ToString(), False)
                    Else
                        Domicilio.CP = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("convenio")) = False Then
                        Domicilio.ConvenioTransporte = CadenaVacia(filaDomicilio.Item("convenio").ToString(), False)
                    Else
                        Domicilio.ConvenioTransporte = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("TotalParesTienda")) = False Then
                        Domicilio.TotalPares = CadenaVacia(filaDomicilio.Item("TotalParesTienda").ToString(), False, True)
                    Else
                        Domicilio.TotalPares = "0"
                    End If

                    If IsDBNull(filaDomicilio.Item("ComentariosCita")) = False Then
                        Domicilio.ComentariosCita = CadenaVacia(filaDomicilio.Item("ComentariosCita").ToString(), False)
                    Else
                        Domicilio.ComentariosCita = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("ENTREGAPEDIDO")) = False Then
                        Domicilio.EntregaPedido = CadenaVacia(filaDomicilio.Item("ENTREGAPEDIDO").ToString(), False)
                    Else
                        Domicilio.EntregaPedido = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("FacturarPor")) = False Then
                        Domicilio.FacturarPor = CadenaVacia(filaDomicilio.Item("FacturarPor").ToString(), False)
                    Else
                        Domicilio.FacturarPor = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("NOTASVENTAS")) = False Then
                        Domicilio.NotasVentas = CadenaVacia(filaDomicilio.Item("NOTASVENTAS").ToString(), False)
                    Else
                        Domicilio.NotasVentas = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("IMPORTEPORVENTA")) = False Then
                        Domicilio.ImportePorVenta = CadenaVacia(filaDomicilio.Item("IMPORTEPORVENTA").ToString(), False, True)
                    Else
                        Domicilio.ImportePorVenta = "0"
                    End If


                    If IsDBNull(filaDomicilio.Item("FACTURAR")) = False Then
                        Domicilio.Facturar = CadenaVacia(filaDomicilio.Item("FACTURAR").ToString(), False)
                    Else
                        Domicilio.Facturar = "----------------------------"
                    End If


                    If IsDBNull(filaDomicilio.Item("LUGARENTREGA")) = False Then
                        Domicilio.Lugarentregar = CadenaVacia(filaDomicilio.Item("LUGARENTREGA").ToString(), False)
                    Else
                        Domicilio.Lugarentregar = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("NOTASVENTAS")) = False Then
                        Domicilio.NotasVentas = CadenaVacia(filaDomicilio.Item("NOTASVENTAS").ToString(), False)
                    Else
                        Domicilio.NotasVentas = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("NOTASEMBARQUE")) = False Then
                        Domicilio.NotasEmbarque = CadenaVacia(filaDomicilio.Item("NOTASEMBARQUE").ToString(), False)
                    Else
                        Domicilio.NotasEmbarque = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("ContactoRampa")) = False Then
                        Domicilio.ContactoRampa = CadenaVacia(filaDomicilio.Item("ContactoRampa").ToString(), False)
                    Else
                        Domicilio.ContactoRampa = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("EMPAQUE")) = False Then
                        Domicilio.Empaque = CadenaVacia(filaDomicilio.Item("EMPAQUE").ToString(), False)
                    Else
                        Domicilio.Empaque = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("TIPOEMPAQUE")) = False Then
                        Domicilio.TipoEmpaque = CadenaVacia(filaDomicilio.Item("TIPOEMPAQUE").ToString(), False)
                    Else
                        Domicilio.TipoEmpaque = "----------------------------"
                    End If

                    If IsDBNull(filaDomicilio.Item("NOTASEMPAQUE")) = False Then
                        Domicilio.NotasEmpaque = CadenaVacia(filaDomicilio.Item("NOTASEMPAQUE").ToString(), False)
                    Else
                        Domicilio.NotasEmpaque = "----------------------------"
                    End If

                    objEnt.DomicilioTiendas.Add(Domicilio)
                Next


                dtOrdenTrabajo.Rows.Add(objEnt.OTCodigo, objEnt.Cliente, objEnt.FechaEntrega, objEnt.AtnClientes, objEnt.FechaCreacion, objEnt.OrdenTrabajoID, objEnt.Agente, objEnt.Transporte, objEnt.DomicilioTiendas(0).Empaque, objEnt.TotalEnviar, objEnt.Cita, objEnt.HoraCita, objEnt.Confirmacion, objEnt.Observaciones, objEnt.DomicilioTiendas(0).TipoEmpaque, objEnt.EntregarPedido, objEnt.FacturarPor, objEnt.ImporteMaxVta, objEnt.PorcentajeFacturacion, objEnt.NotasVentas, objEnt.DomicilioTiendas(0).NotasEmpaque, objEnt.EmbarqueEntregarEn, objEnt.DomicilioTiendas(0).Calle + " #" + objEnt.DomicilioTiendas(0).NumeroExterior.ToString(), objEnt.DomicilioTiendas(0).Colonia, objEnt.DomicilioTiendas(0).Ciudad, objEnt.DomicilioTiendas(0).Estado, objEnt.DomicilioTiendas(0).CP, objEnt.DomicilioTiendas(0).ConvenioTransporte.ToString(), objEnt.EmbarqueContactoRampa, objEnt.EmbarqueNotas, objEnt.DiasEntrega, objEnt.UsuarioImprimio, FormatoFecha(Date.Parse(objEnt.FechaImpresion)), objEnt.UbicacionOT, objEnt.PedidoSICY, objEnt.PedidoSAY, objEnt.Tienda, objEnt.RFC, objEnt.ObservacionesPedido, objEnt.HorariosRecibo, objEnt.IDEmbarque, objEnt.IdRazonSocial, objEnt.RazonSocial, objEnt.NumeroPersonas, objEnt.IDSAY, objEnt.RFCSAY, objEnt.RazonSocialSAY, objEnt.OrdenCliente, objEnt.LlevaCopiaPedido.ToString())

            Next

        End If




        Return dtOrdenTrabajo

        'Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        'Dim DTInformacionReporte As DataTable
        'Dim objEnt As New Entidades.OrdenTrabajoReporteTermino
        'Dim DTDomicilios As DataTable
        'Dim Domicilio As Entidades.OrdenTrabajoDireccionEntrega
        'Dim NumeroTiendas As Integer = 0

        'DTInformacionReporte = objDA.ConsultarInformacionReporteTerminoOT(OrdenTrabajoID, UsuarioImprimioID)

        'DTDomicilios = objDA.ConsultarDireccionesTienda(OrdenTrabajoID)

        'NumeroTiendas = DTDomicilios.Rows.Count

        'For Each fila As DataRow In DTDomicilios.Rows
        '    Domicilio = New Entidades.OrdenTrabajoDireccionEntrega

        '    If NumeroTiendas > 1 Then
        '        If IsDBNull(fila.Item("Tienda")) = False Then
        '            Domicilio.Tienda = CadenaVacia(fila.Item("Tienda").ToString(), False)
        '        Else
        '            Domicilio.Tienda = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("DIRECCION")) = False Then
        '            Domicilio.Calle = fila.Item("DIRECCION").ToString()
        '        Else
        '            Domicilio.Calle = ""
        '        End If

        '        If IsDBNull(fila.Item("COLONIA")) = False Then
        '            Domicilio.Colonia = fila.Item("COLONIA").ToString()
        '        Else
        '            Domicilio.Colonia = ""
        '        End If

        '        If IsDBNull(fila.Item("Noexterior")) = False Then
        '            Domicilio.NumeroExterior = fila.Item("Noexterior").ToString()
        '        Else
        '            Domicilio.NumeroExterior = ""
        '        End If

        '        If IsDBNull(fila.Item("Ciudad")) = False Then
        '            Domicilio.Ciudad = fila.Item("Ciudad").ToString()
        '        Else
        '            Domicilio.Ciudad = ""
        '        End If

        '        If IsDBNull(fila.Item("Estado")) = False Then
        '            Domicilio.Estado = fila.Item("Estado").ToString()
        '        Else
        '            Domicilio.Estado = ""
        '        End If

        '        If IsDBNull(fila.Item("CP")) = False Then
        '            Domicilio.CP = fila.Item("cp").ToString()
        '        Else
        '            Domicilio.CP = ""
        '        End If

        '        If IsDBNull(fila.Item("convenio")) = False Then
        '            Domicilio.ConvenioTransporte = fila.Item("convenio").ToString()
        '        Else
        '            Domicilio.ConvenioTransporte = ""
        '        End If

        '        If IsDBNull(fila.Item("TotalParesTienda")) = False Then
        '            Domicilio.TotalPares = CadenaVacia(fila.Item("TotalParesTienda").ToString(), False, True)
        '        Else
        '            Domicilio.TotalPares = "0"
        '        End If

        '        If IsDBNull(fila.Item("ComentariosCita")) = False Then
        '            Domicilio.ComentariosCita = fila.Item("ComentariosCita").ToString()
        '        Else
        '            Domicilio.ComentariosCita = ""
        '        End If

        '        If IsDBNull(fila.Item("ENTREGAPEDIDO")) = False Then
        '            Domicilio.EntregaPedido = fila.Item("ENTREGAPEDIDO").ToString()
        '        Else
        '            Domicilio.EntregaPedido = ""
        '        End If

        '        If IsDBNull(fila.Item("FacturarPor")) = False Then
        '            Domicilio.FacturarPor = fila.Item("FacturarPor").ToString()
        '        Else
        '            Domicilio.FacturarPor = ""
        '        End If

        '        If IsDBNull(fila.Item("NOTASVENTAS")) = False Then
        '            Domicilio.NotasVentas = fila.Item("NOTASVENTAS").ToString()
        '        Else
        '            Domicilio.NotasVentas = ""
        '        End If

        '        If IsDBNull(fila.Item("IMPORTEPORVENTA")) = False Then
        '            Domicilio.ImportePorVenta = CadenaVacia(fila.Item("IMPORTEPORVENTA").ToString(), False, True)
        '        Else
        '            Domicilio.ImportePorVenta = "0"
        '        End If


        '        If IsDBNull(fila.Item("FACTURAR")) = False Then
        '            Domicilio.Facturar = fila.Item("FACTURAR").ToString()
        '        Else
        '            Domicilio.Facturar = ""
        '        End If


        '        If IsDBNull(fila.Item("LUGARENTREGA")) = False Then
        '            Domicilio.Lugarentregar = fila.Item("LUGARENTREGA").ToString()
        '        Else
        '            Domicilio.Lugarentregar = ""
        '        End If

        '        If IsDBNull(fila.Item("NOTASVENTAS")) = False Then
        '            Domicilio.NotasVentas = CadenaVacia(fila.Item("NOTASVENTAS").ToString(), False)
        '        Else
        '            Domicilio.NotasVentas = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("NOTASEMBARQUE")) = False Then
        '            Domicilio.NotasEmbarque = CadenaVacia(fila.Item("NOTASEMBARQUE").ToString(), False)
        '        Else
        '            Domicilio.NotasEmbarque = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("ContactoRampa")) = False Then
        '            Domicilio.ContactoRampa = CadenaVacia(fila.Item("ContactoRampa").ToString(), False)
        '        Else
        '            Domicilio.ContactoRampa = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("EMPAQUE")) = False Then
        '            Domicilio.Empaque = CadenaVacia(fila.Item("EMPAQUE").ToString(), False)
        '        Else
        '            Domicilio.Empaque = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("TIPOEMPAQUE")) = False Then
        '            Domicilio.TipoEmpaque = CadenaVacia(fila.Item("TIPOEMPAQUE").ToString(), False)
        '        Else
        '            Domicilio.TipoEmpaque = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("NOTASEMPAQUE")) = False Then
        '            Domicilio.NotasEmpaque = CadenaVacia(fila.Item("NOTASEMPAQUE").ToString(), False)
        '        Else
        '            Domicilio.NotasEmpaque = "----------------------------"
        '        End If
        '    Else
        '        If IsDBNull(fila.Item("Tienda")) = False Then
        '            Domicilio.Tienda = CadenaVacia(fila.Item("Tienda").ToString(), False)
        '        Else
        '            Domicilio.Tienda = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("DIRECCION")) = False Then
        '            Domicilio.Calle = CadenaVacia(fila.Item("DIRECCION").ToString(), False)
        '        Else
        '            Domicilio.Calle = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("COLONIA")) = False Then
        '            Domicilio.Colonia = CadenaVacia(fila.Item("COLONIA").ToString(), False)
        '        Else
        '            Domicilio.Colonia = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("Noexterior")) = False Then
        '            Domicilio.NumeroExterior = CadenaVacia(fila.Item("Noexterior").ToString(), False)
        '        Else
        '            Domicilio.NumeroExterior = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("Ciudad")) = False Then
        '            Domicilio.Ciudad = CadenaVacia(fila.Item("Ciudad").ToString(), False)
        '        Else
        '            Domicilio.Ciudad = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("Estado")) = False Then
        '            Domicilio.Estado = CadenaVacia(fila.Item("Estado").ToString(), False)
        '        Else
        '            Domicilio.Estado = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("CP")) = False Then
        '            Domicilio.CP = CadenaVacia(fila.Item("cp").ToString(), False)
        '        Else
        '            Domicilio.CP = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("convenio")) = False Then
        '            Domicilio.ConvenioTransporte = CadenaVacia(fila.Item("convenio").ToString(), False)
        '        Else
        '            Domicilio.ConvenioTransporte = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("TotalParesTienda")) = False Then
        '            Domicilio.TotalPares = CadenaVacia(fila.Item("TotalParesTienda").ToString(), False, True)
        '        Else
        '            Domicilio.TotalPares = "0"
        '        End If

        '        If IsDBNull(fila.Item("ComentariosCita")) = False Then
        '            Domicilio.ComentariosCita = CadenaVacia(fila.Item("ComentariosCita").ToString(), False)
        '        Else
        '            Domicilio.ComentariosCita = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("ENTREGAPEDIDO")) = False Then
        '            Domicilio.EntregaPedido = CadenaVacia(fila.Item("ENTREGAPEDIDO").ToString(), False)
        '        Else
        '            Domicilio.EntregaPedido = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("FacturarPor")) = False Then
        '            Domicilio.FacturarPor = CadenaVacia(fila.Item("FacturarPor").ToString(), False)
        '        Else
        '            Domicilio.FacturarPor = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("NOTASVENTAS")) = False Then
        '            Domicilio.NotasVentas = CadenaVacia(fila.Item("NOTASVENTAS").ToString(), False)
        '        Else
        '            Domicilio.NotasVentas = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("IMPORTEPORVENTA")) = False Then
        '            Domicilio.ImportePorVenta = CadenaVacia(fila.Item("IMPORTEPORVENTA").ToString(), False, True)
        '        Else
        '            Domicilio.ImportePorVenta = "0"
        '        End If


        '        If IsDBNull(fila.Item("FACTURAR")) = False Then
        '            Domicilio.Facturar = CadenaVacia(fila.Item("FACTURAR").ToString(), False)
        '        Else
        '            Domicilio.Facturar = "----------------------------"
        '        End If


        '        If IsDBNull(fila.Item("LUGARENTREGA")) = False Then
        '            Domicilio.Lugarentregar = CadenaVacia(fila.Item("LUGARENTREGA").ToString(), False)
        '        Else
        '            Domicilio.Lugarentregar = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("NOTASVENTAS")) = False Then
        '            Domicilio.NotasVentas = CadenaVacia(fila.Item("NOTASVENTAS").ToString(), False)
        '        Else
        '            Domicilio.NotasVentas = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("NOTASEMBARQUE")) = False Then
        '            Domicilio.NotasEmbarque = CadenaVacia(fila.Item("NOTASEMBARQUE").ToString(), False)
        '        Else
        '            Domicilio.NotasEmbarque = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("ContactoRampa")) = False Then
        '            Domicilio.ContactoRampa = CadenaVacia(fila.Item("ContactoRampa").ToString(), False)
        '        Else
        '            Domicilio.ContactoRampa = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("EMPAQUE")) = False Then
        '            Domicilio.Empaque = CadenaVacia(fila.Item("EMPAQUE").ToString(), False)
        '        Else
        '            Domicilio.Empaque = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("TIPOEMPAQUE")) = False Then
        '            Domicilio.TipoEmpaque = CadenaVacia(fila.Item("TIPOEMPAQUE").ToString(), False)
        '        Else
        '            Domicilio.TipoEmpaque = "----------------------------"
        '        End If

        '        If IsDBNull(fila.Item("NOTASEMPAQUE")) = False Then
        '            Domicilio.NotasEmpaque = CadenaVacia(fila.Item("NOTASEMPAQUE").ToString(), False)
        '        Else
        '            Domicilio.NotasEmpaque = "----------------------------"
        '        End If
        '    End If


        '    objEnt.DomicilioTiendas.Add(Domicilio)
        'Next


        'If DTInformacionReporte.Rows.Count > 0 Then

        '    objEnt.UsuarioImprimio = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

        '    objEnt.OrdenTrabajoID = DTInformacionReporte.Rows(0).Item("OTSAYID").ToString()
        '    objEnt.OTCodigo = DTInformacionReporte.Rows(0).Item("OTCodigoSAYID").ToString()

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("OTSICYID")) = False Then
        '        objEnt.OrdenTrabajoSICYID = CadenaVacia(DTInformacionReporte.Rows(0).Item("OTSICYID"), False, False, False)
        '    Else
        '        objEnt.OrdenTrabajoSICYID = "0"
        '    End If



        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("Agente")) = False Then
        '        objEnt.Agente = CadenaVacia(DTInformacionReporte.Rows(0).Item("Agente"), False, False)
        '    Else
        '        objEnt.Agente = "-----------------------------"
        '    End If


        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("Cliente")) = False Then
        '        objEnt.Cliente = CadenaVacia(DTInformacionReporte.Rows(0).Item("Cliente"), False, False)
        '    Else
        '        objEnt.Cliente = "----------------------------"
        '    End If


        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("Transporte")) = False Then
        '        objEnt.Transporte = CadenaVacia(DTInformacionReporte.Rows(0).Item("Transporte"), False, False)
        '    Else
        '        objEnt.Transporte = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("TipoEmpaque")) = False Then
        '        objEnt.TipoEmpaque = CadenaVacia(DTInformacionReporte.Rows(0).Item("TipoEmpaque"), False, False)
        '    Else
        '        objEnt.TipoEmpaque = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("TotalEnviar")) = False Then
        '        objEnt.TotalEnviar = CadenaVacia(DTInformacionReporte.Rows(0).Item("TotalEnviar"), False, True)
        '    Else
        '        objEnt.TotalEnviar = "0"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("FechaCita")) = False Then
        '        objEnt.Cita = CadenaVacia(DTInformacionReporte.Rows(0).Item("FechaCita"), True, False, False)
        '        objEnt.HoraCita = CadenaVacia(DTInformacionReporte.Rows(0).Item("HoraCita"), False)
        '    Else
        '        objEnt.HoraCita = "----------------------------"
        '        objEnt.Cita = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("Confirmacion")) = False Then
        '        objEnt.Confirmacion = CadenaVacia(DTInformacionReporte.Rows(0).Item("Confirmacion"), False, False)
        '    Else
        '        objEnt.Confirmacion = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("ObservacionesCita")) = False Then
        '        objEnt.Observaciones = CadenaVacia(DTInformacionReporte.Rows(0).Item("ObservacionesCita"), False, False)
        '    Else
        '        objEnt.Observaciones = "----------------------------"

        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("Atncliente")) = False Then
        '        objEnt.AtnClientes = CadenaVacia(DTInformacionReporte.Rows(0).Item("Atncliente"), False)
        '    Else
        '        objEnt.AtnClientes = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("FechaCreacion")) = False Then
        '        objEnt.FechaCreacion = CadenaVacia(DTInformacionReporte.Rows(0).Item("FechaCreacion"), True)
        '    Else
        '        objEnt.FechaCreacion = "----------------------------"
        '    End If


        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("DiasEntrega")) = False Then
        '        objEnt.DiasEntrega = CadenaVacia(DTInformacionReporte.Rows(0).Item("DiasEntrega"), False)
        '    Else
        '        objEnt.DiasEntrega = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("FechaImpresion")) = False Then
        '        objEnt.FechaImpresion = CadenaVacia(DTInformacionReporte.Rows(0).Item("FechaImpresion"), True, , True)
        '    Else
        '        objEnt.FechaImpresion = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("FechaEntrega")) = False Then
        '        objEnt.FechaEntrega = CadenaVacia(DTInformacionReporte.Rows(0).Item("FechaEntrega"), True)
        '    Else
        '        objEnt.FechaEntrega = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("UbicaionOT")) = False Then
        '        objEnt.UbicacionOT = CadenaVacia(DTInformacionReporte.Rows(0).Item("UbicaionOT"), False)
        '    Else
        '        objEnt.UbicacionOT = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("ENTREGAPEDIDO")) = False Then
        '        objEnt.EntregarPedido = CadenaVacia(DTInformacionReporte.Rows(0).Item("ENTREGAPEDIDO"), False)
        '    Else
        '        objEnt.EntregarPedido = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("FacturarPor")) = False Then
        '        objEnt.FacturarPor = CadenaVacia(DTInformacionReporte.Rows(0).Item("FacturarPor"), False)
        '    Else
        '        objEnt.FacturarPor = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("NOTASVENTAS")) = False Then
        '        objEnt.NotasVentas = CadenaVacia(DTInformacionReporte.Rows(0).Item("NOTASVENTAS"), False)
        '    Else
        '        objEnt.NotasVentas = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("IMPORTEPORVENTA")) = False Then
        '        objEnt.ImporteMaxVta = CadenaVacia(DTInformacionReporte.Rows(0).Item("IMPORTEPORVENTA"), False)
        '    Else
        '        objEnt.ImporteMaxVta = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("PorcentajeFacturacion")) = False Then
        '        objEnt.PorcentajeFacturacion = CadenaVacia(DTInformacionReporte.Rows(0).Item("PorcentajeFacturacion"), False)
        '    Else
        '        objEnt.PorcentajeFacturacion = "0"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("NOTASEMBARQUE")) = False Then
        '        objEnt.EmbarqueNotas = CadenaVacia(DTInformacionReporte.Rows(0).Item("NOTASEMBARQUE"), False)
        '    Else
        '        objEnt.EmbarqueNotas = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("LUGARENTREGA")) = False Then
        '        objEnt.EmbarqueEntregarEn = CadenaVacia(DTInformacionReporte.Rows(0).Item("LUGARENTREGA"), False)
        '    Else
        '        objEnt.EmbarqueEntregarEn = "----------------------------"
        '    End If

        '    If IsDBNull(DTInformacionReporte.Rows(0).Item("ContactoRampa")) = False Then
        '        objEnt.EmbarqueContactoRampa = CadenaVacia(DTInformacionReporte.Rows(0).Item("ContactoRampa"), False)
        '    Else
        '        objEnt.EmbarqueContactoRampa = "----------------------------"
        '    End If

        'End If

        'Return objEnt

    End Function


    Public Function ConsultarInformacionReporteTerminoVariasTiendasOT(ByVal OrdenTrabajoID As String, ByVal UsuarioImprimioID As Integer, ByVal ClienteConCita As Boolean) As DataTable

        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Dim DTInformacionReporte As New DataTable
        Dim objEnt As New Entidades.OrdenTrabajoReporteTermino
        'Dim DTDomicilios As DataTable
        '  Dim Domicilio As Entidades.OrdenTrabajoDireccionEntrega
        Dim NumeroTiendas As Integer = 0
        Dim dtOrdenTrabajo As New DataTable
        Dim dtInformacionOt As DataTable
        Dim OTImpresionID As String()
        Dim indice As Integer = 0
        'Dim DTHorariosRecibe As DataTable
        Dim ClienteTieneCita As DataTable

        OTImpresionID = Split(OrdenTrabajoID, ",")

        For Each Item As String In OTImpresionID
            ClienteTieneCita = objDA.ClienteTieneCita(Item)

            If CBool(ClienteTieneCita.Rows(0).Item(0)) = ClienteConCita Then
                indice += 1
                If indice = 1 Then
                    If ClienteConCita = True Then
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTConCita(Item, UsuarioImprimioID, ClienteConCita)
                    Else
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTSinCita(Item, UsuarioImprimioID, ClienteConCita)
                    End If
                    If dtInformacionOt.Rows.Count > 0 Then
                        DTInformacionReporte = dtInformacionOt.Clone()
                        DTInformacionReporte.ImportRow(dtInformacionOt.Rows(0))
                    End If
                Else
                    If ClienteConCita = True Then
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTConCita(Item, UsuarioImprimioID, ClienteConCita)
                    Else
                        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOTSinCita(Item, UsuarioImprimioID, ClienteConCita)
                    End If
                    If dtInformacionOt.Rows.Count > 0 Then
                        DTInformacionReporte.ImportRow(dtInformacionOt.Rows(0))
                    End If
                End If
            End If
        Next

        If IsNothing(DTInformacionReporte) = False Then
            dtOrdenTrabajo = New DataTable("dtOrdenTrabajo")
            With dtOrdenTrabajo
                .Columns.Add("OTCodigo")
                .Columns.Add("Cliente")
                .Columns.Add("FechaEntrega")
                .Columns.Add("AtnClientes")
                .Columns.Add("FechaCreacion")
                .Columns.Add("OT")
                .Columns.Add("Agente")
                .Columns.Add("Transporte")
                .Columns.Add("Empaque")
                .Columns.Add("TotalEnviar")
                .Columns.Add("Cita")
                .Columns.Add("HoraCita")
                .Columns.Add("Confirmacion")
                .Columns.Add("Observaciones")
                .Columns.Add("TipoEmpaque")
                .Columns.Add("EntregarPedido")
                .Columns.Add("FacturarPor")
                .Columns.Add("ImporteMax")
                .Columns.Add("Facturacion")
                .Columns.Add("NotasVentas")
                .Columns.Add("NotasEmpaque")
                .Columns.Add("EntregarEn")
                .Columns.Add("Direccion")
                .Columns.Add("Colonia")
                .Columns.Add("Ciudad")
                .Columns.Add("Estado")
                .Columns.Add("CP")
                .Columns.Add("Convenio")
                .Columns.Add("ContactoRampa")
                .Columns.Add("NotasEmbarque")
                .Columns.Add("DiasEntrega")
                .Columns.Add("UsuarioImprimio")
                .Columns.Add("FechaImpresion")
                .Columns.Add("OTUbicacion")
                .Columns.Add("PedidoSICY")
                .Columns.Add("PedidoSAY")
                .Columns.Add("ObservacionesPedido")
                .Columns.Add("HorariosRecibo")
                .Columns.Add("NumeroPersonas")
                .Columns.Add("OrdenCliente")
                .Columns.Add("LlevaCopiaPedido")
            End With


            For Each Fila As DataRow In DTInformacionReporte.Rows
                objEnt = New Entidades.OrdenTrabajoReporteTermino

                objEnt.UsuarioImprimio = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                objEnt.OrdenTrabajoID = Fila.Item("OTSAYID").ToString()
                objEnt.OTCodigo = Fila.Item("OTCodigoSAYID").ToString()


                'If ClienteConCita = False Then
                '    DTHorariosRecibe = objDA.ObtenerHorariosRecibo(objEnt.OrdenTrabajoID)

                '    If DTHorariosRecibe.Rows.Count > 0 Then

                '        For Each FilaHorario As DataRow In DTHorariosRecibe.Rows
                '            objEnt.HorariosRecibo &= FilaHorario.Item("HorarioRecibe").ToString() + vbCrLf
                '        Next

                '    Else
                '        objEnt.HorariosRecibo = "-----------------------------"
                '    End If

                'Else
                '    objEnt.HorariosRecibo = "-----------------------------"
                'End If

                If IsDBNull(Fila.Item("OrdenCliente")) = False Then
                    objEnt.OrdenCliente = CadenaVacia(Fila.Item("OrdenCliente"), False)
                Else
                    objEnt.OrdenCliente = "---"
                End If

                If IsDBNull(Fila.Item("NumeroPersonas")) = False Then
                    objEnt.NumeroPersonas = CadenaVacia(Fila.Item("NumeroPersonas"), False)
                Else
                    objEnt.NumeroPersonas = "---"
                End If

                If IsDBNull(Fila.Item("ObservacionesPedido")) = False Then
                    objEnt.ObservacionesPedido = CadenaVacia(Fila.Item("ObservacionesPedido"), False)
                Else
                    objEnt.ObservacionesPedido = "----------------------------"
                End If

                If IsDBNull(Fila.Item("PedidoSICY")) = False Then
                    objEnt.PedidoSICY = CadenaVacia(Fila.Item("PedidoSICY"), False)
                Else
                    objEnt.PedidoSICY = "----------------------------"
                End If

                If IsDBNull(Fila.Item("PedidoSAY")) = False Then
                    objEnt.PedidoSAY = CadenaVacia(Fila.Item("PedidoSAY"), False)
                Else
                    objEnt.PedidoSAY = "----------------------------"
                End If

                If IsDBNull(Fila.Item("OTSICYID")) = False Then
                    objEnt.OrdenTrabajoSICYID = CadenaVacia(Fila.Item("OTSICYID"), False, False, False)
                Else
                    objEnt.OrdenTrabajoSICYID = "0"
                End If

                If IsDBNull(Fila.Item("Agente")) = False Then
                    objEnt.Agente = CadenaVacia(Fila.Item("Agente"), False, False)
                Else
                    objEnt.Agente = "-----------------------------"
                End If


                If IsDBNull(Fila.Item("Cliente")) = False Then
                    objEnt.Cliente = CadenaVacia(Fila.Item("Cliente"), False, False)
                Else
                    objEnt.Cliente = "----------------------------"
                End If


                If IsDBNull(Fila.Item("Transporte")) = False Then
                    objEnt.Transporte = CadenaVacia(Fila.Item("Transporte"), False, False)
                Else
                    objEnt.Transporte = "----------------------------"
                End If

                If IsDBNull(Fila.Item("TipoEmpaque")) = False Then
                    objEnt.TipoEmpaque = CadenaVacia(Fila.Item("TipoEmpaque"), False, False)
                Else
                    objEnt.TipoEmpaque = "----------------------------"
                End If

                If IsDBNull(Fila.Item("TotalEnviar")) = False Then
                    objEnt.TotalEnviar = CadenaVacia(Fila.Item("TotalEnviar"), False, True)
                Else
                    objEnt.TotalEnviar = "0"
                End If

                If IsDBNull(Fila.Item("FechaCita")) = False Then
                    objEnt.Cita = CadenaVacia(Fila.Item("FechaCita"), True, False, False)
                    objEnt.HoraCita = CadenaVacia(Fila.Item("HoraCita"), False)
                Else
                    objEnt.HoraCita = "----------------------------"
                    objEnt.Cita = "----------------------------"
                End If

                If IsDBNull(Fila.Item("Confirmacion")) = False Then
                    objEnt.Confirmacion = CadenaVacia(Fila.Item("Confirmacion"), False, False)
                Else
                    objEnt.Confirmacion = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ObservacionesCita")) = False Then
                    objEnt.Observaciones = CadenaVacia(Fila.Item("ObservacionesCita"), False, False)
                Else
                    objEnt.Observaciones = "----------------------------"

                End If

                If IsDBNull(Fila.Item("Atncliente")) = False Then
                    objEnt.AtnClientes = CadenaVacia(Fila.Item("Atncliente"), False)
                Else
                    objEnt.AtnClientes = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FechaCreacion")) = False Then
                    objEnt.FechaCreacion = CadenaVacia(Fila.Item("FechaCreacion"), True)
                Else
                    objEnt.FechaCreacion = "----------------------------"
                End If


                If IsDBNull(Fila.Item("DiasEntrega")) = False Then
                    objEnt.DiasEntrega = CadenaVacia(Fila.Item("DiasEntrega"), False)
                Else
                    objEnt.DiasEntrega = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FechaImpresion")) = False Then
                    objEnt.FechaImpresion = CadenaVacia(Fila.Item("FechaImpresion"), True, , True)
                Else
                    objEnt.FechaImpresion = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FechaEntrega")) = False Then
                    objEnt.FechaEntrega = CadenaVacia(Fila.Item("FechaEntrega"), True)
                Else
                    objEnt.FechaEntrega = "----------------------------"
                End If

                If IsDBNull(Fila.Item("UbicaionOT")) = False Then
                    objEnt.UbicacionOT = CadenaVacia(Fila.Item("UbicaionOT"), False)
                Else
                    objEnt.UbicacionOT = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ENTREGAPEDIDO")) = False Then
                    objEnt.EntregarPedido = CadenaVacia(Fila.Item("ENTREGAPEDIDO"), False)
                Else
                    objEnt.EntregarPedido = "----------------------------"
                End If

                If IsDBNull(Fila.Item("FacturarPor")) = False Then
                    objEnt.FacturarPor = CadenaVacia(Fila.Item("FacturarPor"), False)
                Else
                    objEnt.FacturarPor = "----------------------------"
                End If

                If IsDBNull(Fila.Item("NOTASVENTAS")) = False Then
                    objEnt.NotasVentas = CadenaVacia(Fila.Item("NOTASVENTAS"), False)
                Else
                    objEnt.NotasVentas = "----------------------------"
                End If

                If IsDBNull(Fila.Item("IMPORTEPORVENTA")) = False Then
                    objEnt.ImporteMaxVta = CadenaVacia(Fila.Item("IMPORTEPORVENTA"), False)
                Else
                    objEnt.ImporteMaxVta = "----------------------------"
                End If

                If IsDBNull(Fila.Item("PorcentajeFacturacion")) = False Then
                    objEnt.PorcentajeFacturacion = CadenaVacia(Fila.Item("PorcentajeFacturacion"), False)
                Else
                    objEnt.PorcentajeFacturacion = "0"
                End If

                If IsDBNull(Fila.Item("NOTASEMBARQUE")) = False Then
                    objEnt.EmbarqueNotas = CadenaVacia(Fila.Item("NOTASEMBARQUE"), False)
                Else
                    objEnt.EmbarqueNotas = "----------------------------"
                End If

                If IsDBNull(Fila.Item("LUGARENTREGA")) = False Then
                    objEnt.EmbarqueEntregarEn = CadenaVacia(Fila.Item("LUGARENTREGA"), False)
                Else
                    objEnt.EmbarqueEntregarEn = "----------------------------"
                End If

                If IsDBNull(Fila.Item("ContactoRampa")) = False Then
                    objEnt.EmbarqueContactoRampa = CadenaVacia(Fila.Item("ContactoRampa"), False)
                Else
                    objEnt.EmbarqueContactoRampa = "----------------------------"
                End If

                If IsDBNull(Fila.Item("Empaque")) = False Then
                    objEnt.Empaque = CadenaVacia(Fila.Item("Empaque"), False)
                Else
                    objEnt.Empaque = "----------------------------"
                End If

                If IsDBNull(Fila.Item("LlevaCopiaPedido")) = False Then
                    If CBool(Fila.Item("LlevaCopiaPedido")) = True Then
                        objEnt.LlevaCopiaPedido = "SI"
                    Else
                        objEnt.LlevaCopiaPedido = "NO"
                    End If
                Else
                    objEnt.LlevaCopiaPedido = "NO"
                End If

                dtOrdenTrabajo.Rows.Add(objEnt.OTCodigo, objEnt.Cliente, objEnt.FechaEntrega, objEnt.AtnClientes, objEnt.FechaCreacion, objEnt.OrdenTrabajoID, objEnt.Agente, objEnt.Transporte, objEnt.Empaque, objEnt.TotalEnviar, objEnt.Cita, objEnt.HoraCita, objEnt.Confirmacion, objEnt.Observaciones, "", objEnt.EntregarPedido, objEnt.FacturarPor, objEnt.ImporteMaxVta, objEnt.PorcentajeFacturacion, objEnt.NotasVentas, "", objEnt.EmbarqueEntregarEn, "", "", "", "", "", "", objEnt.EmbarqueContactoRampa, objEnt.EmbarqueNotas, objEnt.DiasEntrega, objEnt.UsuarioImprimio, FormatoFecha(Date.Parse(objEnt.FechaImpresion)), objEnt.UbicacionOT, objEnt.PedidoSICY, objEnt.PedidoSAY, objEnt.ObservacionesPedido, objEnt.HorariosRecibo, objEnt.NumeroPersonas, objEnt.OrdenCliente, objEnt.LlevaCopiaPedido.ToString())

            Next
        End If



        Return dtOrdenTrabajo

        '--------------------------------------------------------------------------------------------------------------
        'Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        'Dim DTInformacionReporte As DataTable
        'Dim objEnt As New Entidades.OrdenTrabajoReporteTermino
        'Dim DTDomicilios As DataTable
        'Dim Domicilio As Entidades.OrdenTrabajoDireccionEntrega
        'Dim NumeroTiendas As Integer = 0
        'Dim dtOrdenTrabajo As New DataTable
        'Dim dtInformacionOt As DataTable
        'Dim OTImpresionID As String()
        'Dim indice As Integer = 0

        'OTImpresionID = Split(OrdenTrabajoID, ",")

        'For Each Item As String In OTImpresionID
        '    indice += 1
        '    If indice = 1 Then
        '        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOT(Item, UsuarioImprimioID, ClienteConCita)
        '        DTInformacionReporte = dtInformacionOt.Clone()
        '        DTInformacionReporte.ImportRow(dtInformacionOt.Rows(0))
        '    Else
        '        dtInformacionOt = objDA.ConsultarInformacionReporteTerminoOT(Item, UsuarioImprimioID, ClienteConCita)
        '        DTInformacionReporte.ImportRow(dtInformacionOt.Rows(0))
        '    End If
        'Next



        'dtOrdenTrabajo = New DataTable("dtOrdenTrabajo")
        'With dtOrdenTrabajo
        '    .Columns.Add("OTCodigo")
        '    .Columns.Add("Cliente")
        '    .Columns.Add("FechaEntrega")
        '    .Columns.Add("AtnClientes")
        '    .Columns.Add("FechaCreacion")
        '    .Columns.Add("OT")
        '    .Columns.Add("Agente")
        '    .Columns.Add("Transporte")
        '    .Columns.Add("Empaque")
        '    .Columns.Add("TotalEnviar")
        '    .Columns.Add("Cita")
        '    .Columns.Add("HoraCita")
        '    .Columns.Add("Confirmacion")
        '    .Columns.Add("Observaciones")
        '    .Columns.Add("TipoEmpaque")
        '    .Columns.Add("EntregarPedido")
        '    .Columns.Add("FacturarPor")
        '    .Columns.Add("ImporteMax")
        '    .Columns.Add("Facturacion")
        '    .Columns.Add("NotasVentas")
        '    .Columns.Add("NotasEmpaque")
        '    .Columns.Add("EntregarEn")
        '    .Columns.Add("Direccion")
        '    .Columns.Add("Colonia")
        '    .Columns.Add("Ciudad")
        '    .Columns.Add("Estado")
        '    .Columns.Add("CP")
        '    .Columns.Add("Convenio")
        '    .Columns.Add("ContactoRampa")
        '    .Columns.Add("NotasEmbarque")
        '    .Columns.Add("DiasEntrega")
        '    .Columns.Add("UsuarioImprimio")
        '    .Columns.Add("FechaImpresion")
        '    .Columns.Add("OTUbicacion")
        'End With


        'For Each Fila As DataRow In DTInformacionReporte.Rows
        '    objEnt = New Entidades.OrdenTrabajoReporteTermino

        '    objEnt.UsuarioImprimio = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

        '    objEnt.OrdenTrabajoID = Fila.Item("OTSAYID").ToString()
        '    objEnt.OTCodigo = Fila.Item("OTCodigoSAYID").ToString()

        '    If IsDBNull(Fila.Item("OTSICYID")) = False Then
        '        objEnt.OrdenTrabajoSICYID = CadenaVacia(Fila.Item("OTSICYID"), False, False, False)
        '    Else
        '        objEnt.OrdenTrabajoSICYID = "0"
        '    End If

        '    If IsDBNull(Fila.Item("Agente")) = False Then
        '        objEnt.Agente = CadenaVacia(Fila.Item("Agente"), False, False)
        '    Else
        '        objEnt.Agente = "-----------------------------"
        '    End If


        '    If IsDBNull(Fila.Item("Cliente")) = False Then
        '        objEnt.Cliente = CadenaVacia(Fila.Item("Cliente"), False, False)
        '    Else
        '        objEnt.Cliente = "----------------------------"
        '    End If


        '    If IsDBNull(Fila.Item("Transporte")) = False Then
        '        objEnt.Transporte = CadenaVacia(Fila.Item("Transporte"), False, False)
        '    Else
        '        objEnt.Transporte = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("TipoEmpaque")) = False Then
        '        objEnt.TipoEmpaque = CadenaVacia(Fila.Item("TipoEmpaque"), False, False)
        '    Else
        '        objEnt.TipoEmpaque = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("TotalEnviar")) = False Then
        '        objEnt.TotalEnviar = CadenaVacia(Fila.Item("TotalEnviar"), False, True)
        '    Else
        '        objEnt.TotalEnviar = "0"
        '    End If

        '    If IsDBNull(Fila.Item("FechaCita")) = False Then
        '        objEnt.Cita = CadenaVacia(Fila.Item("FechaCita"), True, False, False)
        '        objEnt.HoraCita = CadenaVacia(Fila.Item("HoraCita"), False)
        '    Else
        '        objEnt.HoraCita = "----------------------------"
        '        objEnt.Cita = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("Confirmacion")) = False Then
        '        objEnt.Confirmacion = CadenaVacia(Fila.Item("Confirmacion"), False, False)
        '    Else
        '        objEnt.Confirmacion = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("ObservacionesCita")) = False Then
        '        objEnt.Observaciones = CadenaVacia(Fila.Item("ObservacionesCita"), False, False)
        '    Else
        '        objEnt.Observaciones = "----------------------------"

        '    End If

        '    If IsDBNull(Fila.Item("Atncliente")) = False Then
        '        objEnt.AtnClientes = CadenaVacia(Fila.Item("Atncliente"), False)
        '    Else
        '        objEnt.AtnClientes = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("FechaCreacion")) = False Then
        '        objEnt.FechaCreacion = CadenaVacia(Fila.Item("FechaCreacion"), True)
        '    Else
        '        objEnt.FechaCreacion = "----------------------------"
        '    End If


        '    If IsDBNull(Fila.Item("DiasEntrega")) = False Then
        '        objEnt.DiasEntrega = CadenaVacia(Fila.Item("DiasEntrega"), False)
        '    Else
        '        objEnt.DiasEntrega = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("FechaImpresion")) = False Then
        '        objEnt.FechaImpresion = CadenaVacia(Fila.Item("FechaImpresion"), True, , True)
        '    Else
        '        objEnt.FechaImpresion = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("FechaEntrega")) = False Then
        '        objEnt.FechaEntrega = CadenaVacia(Fila.Item("FechaEntrega"), True)
        '    Else
        '        objEnt.FechaEntrega = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("UbicaionOT")) = False Then
        '        objEnt.UbicacionOT = CadenaVacia(Fila.Item("UbicaionOT"), False)
        '    Else
        '        objEnt.UbicacionOT = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("ENTREGAPEDIDO")) = False Then
        '        objEnt.EntregarPedido = CadenaVacia(Fila.Item("ENTREGAPEDIDO"), False)
        '    Else
        '        objEnt.EntregarPedido = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("FacturarPor")) = False Then
        '        objEnt.FacturarPor = CadenaVacia(Fila.Item("FacturarPor"), False)
        '    Else
        '        objEnt.FacturarPor = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("NOTASVENTAS")) = False Then
        '        objEnt.NotasVentas = CadenaVacia(Fila.Item("NOTASVENTAS"), False)
        '    Else
        '        objEnt.NotasVentas = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("IMPORTEPORVENTA")) = False Then
        '        objEnt.ImporteMaxVta = CadenaVacia(Fila.Item("IMPORTEPORVENTA"), False)
        '    Else
        '        objEnt.ImporteMaxVta = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("PorcentajeFacturacion")) = False Then
        '        objEnt.PorcentajeFacturacion = CadenaVacia(Fila.Item("PorcentajeFacturacion"), False)
        '    Else
        '        objEnt.PorcentajeFacturacion = "0"
        '    End If

        '    If IsDBNull(Fila.Item("NOTASEMBARQUE")) = False Then
        '        objEnt.EmbarqueNotas = CadenaVacia(Fila.Item("NOTASEMBARQUE"), False)
        '    Else
        '        objEnt.EmbarqueNotas = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("LUGARENTREGA")) = False Then
        '        objEnt.EmbarqueEntregarEn = CadenaVacia(Fila.Item("LUGARENTREGA"), False)
        '    Else
        '        objEnt.EmbarqueEntregarEn = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("ContactoRampa")) = False Then
        '        objEnt.EmbarqueContactoRampa = CadenaVacia(Fila.Item("ContactoRampa"), False)
        '    Else
        '        objEnt.EmbarqueContactoRampa = "----------------------------"
        '    End If

        '    If IsDBNull(Fila.Item("Empaque")) = False Then
        '        objEnt.Empaque = CadenaVacia(Fila.Item("Empaque"), False)
        '    Else
        '        objEnt.Empaque = "----------------------------"
        '    End If

        '    dtOrdenTrabajo.Rows.Add(objEnt.OTCodigo, objEnt.Cliente, objEnt.FechaEntrega, objEnt.AtnClientes, objEnt.FechaCreacion, objEnt.OrdenTrabajoID, objEnt.Agente, objEnt.Transporte, objEnt.Empaque, objEnt.TotalEnviar, objEnt.Cita, objEnt.HoraCita, objEnt.Confirmacion, objEnt.Observaciones, "", objEnt.EntregarPedido, objEnt.FacturarPor, objEnt.ImporteMaxVta, objEnt.PorcentajeFacturacion, objEnt.NotasVentas, "", objEnt.EmbarqueEntregarEn, "", "", "", "", "", "", objEnt.EmbarqueContactoRampa, objEnt.EmbarqueNotas, objEnt.DiasEntrega, objEnt.UsuarioImprimio, FormatoFecha(Date.Parse(objEnt.FechaImpresion)), objEnt.UbicacionOT)

        'Next

        'Return dtOrdenTrabajo


    End Function


    Private Function FormatoFecha(ByVal Fecha As Date) As String
        Dim Resultado As String = String.Empty

        Select Case Fecha.DayOfWeek

            Case DayOfWeek.Monday
                Resultado = "Lunes"
            Case DayOfWeek.Tuesday
                Resultado = "Martes"
            Case DayOfWeek.Wednesday
                Resultado = "Miercoles"
            Case DayOfWeek.Thursday
                Resultado = "Jueves"
            Case DayOfWeek.Friday
                Resultado = "Viernes"
            Case DayOfWeek.Saturday
                Resultado = "Sabado"
            Case DayOfWeek.Sunday
                Resultado = "Domingo"
        End Select

        Resultado += " " + Fecha.Day.ToString() + " de "

        Select Case Fecha.Month

            Case 1
                Resultado += "Enero"
            Case 2
                Resultado += "Febrero"
            Case 3
                Resultado += "Marzo"
            Case 4
                Resultado += "Abril"
            Case 5
                Resultado += "Mayo"
            Case 6
                Resultado += "Junio"
            Case 7
                Resultado += "Julio"
            Case 8
                Resultado += "Agosto"
            Case 9
                Resultado += "Septiembre"
            Case 10
                Resultado += "Octubre"
            Case 11
                Resultado += "Noviembre"
            Case 12
                Resultado += "Diciembre"
        End Select

        Resultado += " de " + Fecha.Year.ToString() + " "

        If Fecha.Hour < 10 Then
            Resultado += "0" + Fecha.Hour.ToString()
        Else
            Resultado += Fecha.Hour.ToString()
        End If

        If Fecha.Minute < 10 Then
            Resultado += ":0" + Fecha.Minute.ToString()
        Else
            Resultado += ":" + Fecha.Minute.ToString()
        End If

        If Fecha.Second < 10 Then
            Resultado += ":0" + Fecha.Second.ToString()
        Else
            Resultado += ":" + Fecha.Second.ToString()
        End If

        Return Resultado

    End Function



    Private Function CadenaVacia(ByVal Cadena As String, ByVal EsFecha As Boolean, Optional ByVal EsNumero As Boolean = False, Optional ByVal FechaCompleta As Boolean = False) As String
        Dim Resultado As String = String.Empty

        If IsDBNull(Cadena) = True Then
            Resultado = "----------------------------"
        ElseIf String.IsNullOrEmpty(Cadena) = True Then
            Resultado = "----------------------------"
        Else

            If EsFecha = True Then
                If FechaCompleta = True Then
                    Resultado = Date.Parse(Cadena.Trim())
                Else
                    Resultado = Date.Parse(Cadena.Trim()).ToShortDateString()
                End If
            ElseIf EsNumero = True Then
                Resultado = CDbl(Cadena.Trim()).ToString("n0")
            Else
                Resultado = Cadena.Trim()
            End If

        End If

        Return Resultado

    End Function

    Public Function ConsultarCitasEmbarquesModoAgenda(ByVal TipoEntrega As Integer, ByVal Unidad As Integer, ByVal FechaInicioEmbarque As Date, ByVal FechaFinEmbarque As Date, ByVal HoraInicioEmbarque As Integer, ByVal HoraFinEmbarque As Integer, ByVal EsYISTI As Boolean) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.LiberarUnidades()
        Return objDA.ConsultarCitasEmbarquesModoAgenda(TipoEntrega, Unidad, FechaInicioEmbarque, FechaFinEmbarque, HoraInicioEmbarque, HoraFinEmbarque, EsYISTI)
    End Function


    Public Function ValidacionParesANDREA(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal CodigoAtado As String, ByVal CodigoAndrea As String, ByVal Estiba As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Dim dtInformacionCodigoAndrea As DataTable
        Dim Fecha As Date
        dtInformacionCodigoAndrea = objDA.ConsultaInformacionCodigoAndrea(CodigoAndrea, OrdenTrabajoID, CodigoAtado)
        If dtInformacionCodigoAndrea.Rows.Count > 0 Then
            If IsDBNull(dtInformacionCodigoAndrea.Rows(0).Item("FechaUbico")) = True Then
                Fecha = Nothing
            Else
                Fecha = CDate(dtInformacionCodigoAndrea.Rows(0).Item("FechaUbico"))
            End If
            Return objDA.ValidacionParesANDREA(OrdenTrabajoID, OperadorId, CodigoAtado, CodigoAndrea, Estiba, dtInformacionCodigoAndrea.Rows(0).Item("UbicacionEstiba").ToString(), dtInformacionCodigoAndrea.Rows(0).Item("ColaboradorUbicoID").ToString(), Fecha, dtInformacionCodigoAndrea.Rows(0).Item("Articulo").ToString(), dtInformacionCodigoAndrea.Rows(0).Item("Talla").ToString())
        Else
            Return objDA.ValidacionParesANDREA(OrdenTrabajoID, OperadorId, CodigoAtado, CodigoAndrea, Estiba, "", "0", Nothing, "", "")
        End If


    End Function

    Public Function LiberarUnidades(ByVal OTLiberar As String, ByVal UsuarioModifico As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.LiberarUnidades(OTLiberar, UsuarioModifico)
    End Function


    Public Function ConfirmacionParesANDREA(ByVal OrdenTrabajoID As Integer, ByVal OperadorId As Integer, ByVal CodigoAtado As String, ByVal CodigoAndrea As String, ByVal Estiba As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConfirmacionParesANDREA(OrdenTrabajoID, OperadorId, CodigoAtado, CodigoAndrea, Estiba)
    End Function

    Public Function CancelarEmbarque(ByVal OTCancelarEmbarque As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CancelarEmbarque(OTCancelarEmbarque)
    End Function

    Public Function ObtenerClienteOT(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerClienteOT(OrdenTrabajoID)
    End Function

    Public Function ObtenerCodigosAndreaPorAtado(ByVal OrdenTrabajoSAYID As Integer, ByVal CodigoAtado As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerCodigosAndreaPorAtado(OrdenTrabajoSAYID, CodigoAtado)
    End Function

    Public Function ObtenerOrdenesTrabajoAgrupadasEmbarque(ByVal OrdenTrabajoSAYID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerOrdenesTrabajoAgrupadasEmbarque(OrdenTrabajoSAYID)
    End Function

    Public Function ConsultarNumeroColumnasPorFecha() As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarNumeroColumnasPorFecha()
    End Function

    Public Sub LiberarUnidades()
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.LiberarUnidades()
    End Sub

    'Public Function ConsultaInformacionCodigoAndrea(ByVal CodigoAndrea As String) As DataTable
    '    Dim objDA As New Ventas.Datos.OrdenTrabajoDA
    '    Return objDA.ConsultaInformacionCodigoAndrea(CodigoAndrea)
    'End Function

    Public Function IniciarTiempoEjecucionOperador(ByVal colaboradorConfirmaID As Integer, ByVal OTID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.IniciarTiempoEjecucionOperador(colaboradorConfirmaID, OTID)
    End Function


    Public Function FinalizarTiempoEjecucionOperador(ByVal colaboradorConfirmaID As Integer, ByVal OTID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.FinalizarTiempoEjecucionOperador(colaboradorConfirmaID, OTID)
    End Function

    Public Function CrearArchivoConfirmacionAndrea(ByVal OTID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CrearArchivoConfirmacionAndrea(OTID)
    End Function

    Public Function InformacionCodigoAndrea(ByVal CodigoAndrea As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.InformacionCodigoAndrea(CodigoAndrea)
    End Function

    Public Function ConstruyeXmlAndrea(ByVal numLotesAndrea As String, ByVal rutaGuardar As String, ByVal ordenTrabajoId As Integer, ByVal numArchivo As Integer, ByVal tipoArchivo As Integer, ByVal idLote As Integer, ByVal FechaConfirmacion As Date) As String
        Dim result As String = String.Empty
        Dim ObjDA As New Datos.OrdenTrabajoDA

        Dim datosXMLAndrea As New DataTable
        Dim CerosInicio As String = String.Empty
        Dim CantidadCeros As Integer = 0
        datosXMLAndrea = ObjDA.ConsultaDatosParaXMLAndrea(ordenTrabajoId, numLotesAndrea, FechaConfirmacion)
        Dim index As Integer = 0

        Try
            If System.IO.Directory.Exists("C:\Arc_Sync\") = False Then
                System.IO.Directory.CreateDirectory("C:\Arc_Sync\")
            End If

            Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(rutaGuardar + "descarga" + If(tipoArchivo = 1, "_" + idLote.ToString() + If(numArchivo > 0, "_" + numArchivo.ToString(), ""), "_Completo") + ".xml", System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)

            'Crear el elemento de documento principal Comprobante.
            myXmlTextWriter.WriteStartElement("NewDataSet")

            For Each registro As DataRow In datosXMLAndrea.Rows
                CerosInicio = String.Empty
                index += 1

                If index <> datosXMLAndrea.Rows.Count Then
                    If registro.Item("Alternativa").ToString().Length < 13 Then
                        CantidadCeros = 13 - registro.Item("Alternativa").ToString().Length
                        For value As Integer = 1 To CantidadCeros
                            CerosInicio &= "0"
                        Next
                    End If
                End If

                myXmlTextWriter.WriteStartElement("Captura")

                myXmlTextWriter.WriteElementString("Alternativa", CerosInicio & registro.Item("Alternativa").ToString())
                myXmlTextWriter.WriteElementString("Cantidad", registro.Item("Cantidad").ToString())
                myXmlTextWriter.WriteElementString("Pasillo", registro.Item("Pasillo").ToString())

                myXmlTextWriter.WriteEndElement()

            Next

            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

            If tipoArchivo = 1 Then
                result = "Archivos generados correctamente."
            Else
                result = "Archivo generado correctamente."
            End If
        Catch ex As Exception
            If tipoArchivo = 1 Then
                result = "Error al generar los archivos. Intente de nuevo."
            Else
                result = "Error al generar el archivo. Intente de nuevo."
            End If
        End Try

        Return result

    End Function

    Public Function ConsultaLotesAndreaPorOT(ByVal FechaConfirmacion As Date) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaLotesAndreaPorOT(FechaConfirmacion)
    End Function

    Public Sub ActualizaParesConArchivoGeneradoEnOT(ByVal OrdenTrabajoId As String, ByVal NumLoteAndreaId As String)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.ActualizaParesConArchivoGeneradoEnOT(OrdenTrabajoId, NumLoteAndreaId)
    End Sub

    Public Sub DesasignarOperadorOT(ByVal OrdenTrabajoID As String)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.DesasignarOperadorOT(OrdenTrabajoID)
    End Sub

    Public Function VerificarPartidasAntesRechazarOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.VerificarPartidasAntesRechazarOT(OrdenTrabajoID)
    End Function


    Public Function ObtenerCantidadTiendas(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerCantidadTiendas(OrdenTrabajoID)
    End Function

    Public Function CancelarParesDeOTSICY(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CancelarParesDeOTSICY(OrdenTrabajoID)
    End Function
    Public Function ElimnarOtsInWork(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ElimnarOtsInWork(OrdenTrabajoID)
    End Function

    Public Function GenerarImpresionOT(ByVal OrdenTrabajoID As String, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.GenerarImpresionOT(OrdenTrabajoID, UsuarioId)
    End Function

    Public Function ConsultarDireccionesTienda(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarDireccionesTienda(OrdenTrabajoID)
    End Function


    Public Function GenerarFacturasAndrea(ByVal OrdenTrabajoID As String, ByVal TotalPAres As Integer, ByVal Usuario As String, ByVal PArtidas As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.GenerarFacturasAndrea(OrdenTrabajoID, TotalPAres, Usuario, PArtidas)
    End Function

    Public Function ObtenerNombreCortoColaborador(ByVal ColaboradorID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerNombreCortoColaborador(ColaboradorID)
    End Function

    Public Function EnviarFacturarPartidas(ByVal OrdenTrabajoID As Integer, ByVal Partidas As String, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.EnviarFacturarPartidas(OrdenTrabajoID, Partidas, UsuarioID)
    End Function


    Public Function CancelarOT(ByVal OrdenTrabajoID As String, ByVal UsuarioID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CancelarOT(OrdenTrabajoID, UsuarioID)
    End Function

    Public Function ConsultaPartidaPorFacturarAndrea(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaPartidaPorFacturarAndrea(OrdenTrabajoID)
    End Function

    Public Function ConsultaOperadorAsignadoAndrea(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaOperadorAsignadoAndrea(OrdenTrabajoID)
    End Function

    Public Function AsignaOperadorAndrea(ByVal OrdenTrabajoID As Integer, ByVal OperadorID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.AsignaOperadorAndrea(OrdenTrabajoID, OperadorID)
    End Function

    Public Function DesasignaOperadorAndrea(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.DesasignaOperadorAndrea(OrdenTrabajoID)
    End Function

    Public Function GenerarEtiquetasAndrea(ByVal OrdenTrabajoID As Integer, ByVal LoteAndrea As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.GenerarEtiquetasAndrea(OrdenTrabajoID, LoteAndrea)
    End Function


    Public Function ConstruyeXmlEtiquetasAndrea(ByVal numLotesAndrea As String, ByVal rutaGuardar As String, ByVal ordenTrabajoId As Integer, ByVal numArchivo As Integer, ByVal tipoArchivo As Integer, ByVal idLote As Integer, ByVal FEchaConfirmacion As Date) As String
        Dim result As String = String.Empty
        Dim ObjDA As New Datos.OrdenTrabajoDA
        Dim datosXMLAndrea As New DataTable
        Dim ListaCodigosAtadosH As New List(Of String)
        Dim ListaCodigosAtadosUnicos As New List(Of String)
        Dim DTEtiquetasCodigos As New DataTable
        Dim DTEtiquetasCodigosH As New DataTable
        Dim CerosInicio As String = String.Empty
        Dim CantidadCeros As Integer = 0
        Dim NumeroEtiquetasAndrea As Integer = 0
        Dim Pasilo As String = String.Empty
        Dim NumeroCodigosAndreaDiferentes As Integer = 0
        Dim DTEtiquetasPasillo As DataTable
        Dim indice As Integer = 0
        DTEtiquetasCodigosH.Columns.Add("CodigoAndrea", GetType(String))
        DTEtiquetasCodigos.Columns.Add("CodigoAndrea", GetType(String))
        DTEtiquetasCodigos.Columns.Add("NumeroEtiquetas", GetType(Integer))
        datosXMLAndrea = ObjDA.GenerarEtiquetasAndrea(ordenTrabajoId, numLotesAndrea)


        Dim AtadosUnicos = datosXMLAndrea.AsEnumerable.Where(Function(x) x.Item("Cantidad").ToString = 5)
        Dim AtadosH = datosXMLAndrea.AsEnumerable.Where(Function(x) x.Item("Cantidad").ToString < 5)

        For Each Atado As DataRow In AtadosUnicos
            DTEtiquetasCodigos.Rows.Add(Atado.Item("CodigoAndrea").ToString, 1)
        Next

        For Each Atado As DataRow In AtadosH
            If Atado.Item("Cantidad") = 1 Then
                DTEtiquetasCodigosH.Rows.Add(Atado.Item("CodigoAndrea"))
            Else
                For index As Integer = 1 To Atado.Item("Cantidad")
                    DTEtiquetasCodigosH.Rows.Add(Atado.Item("CodigoAndrea"))
                Next
            End If
        Next


        Dim grupo = DTEtiquetasCodigosH.AsEnumerable.GroupBy(Function(x) x.Item("CodigoAndrea"))

        Dim NumeroEtiquetasH As Integer = 0

        For Each grp In grupo
            If grp.Count >= 5 Then
                NumeroEtiquetasH = CInt(grp.Count / 5)
                For index As Integer = 1 To NumeroEtiquetasH
                    DTEtiquetasCodigos.Rows.Add(grp(0), 1)
                Next
            End If
        Next


        Dim CantidadEtiquetasPorCodigo = DTEtiquetasCodigos.AsEnumerable.GroupBy(Function(X) X.Item("CodigoAndrea"))


        If System.IO.Directory.Exists("C:\Arc_Sync\") = False Then
            System.IO.Directory.CreateDirectory("C:\Arc_Sync\")
        End If


        Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(rutaGuardar + "descarga" + If(tipoArchivo = 1, "_" + idLote.ToString() + If(numArchivo > 0, "_" + numArchivo.ToString(), ""), "_Completo") + ".xml", System.Text.Encoding.UTF8)
        myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
        myXmlTextWriter.WriteStartDocument(False)

        'Crear el elemento de documento principal Comprobante.
        myXmlTextWriter.WriteStartElement("NewDataSet")

        myXmlTextWriter.WriteStartElement("Captura")

        For Each grp In CantidadEtiquetasPorCodigo
            CantidadCeros = String.Empty
            indice = 0

            If indice <> datosXMLAndrea.Rows.Count Then
                If grp(0).Item("CodigoAndrea").ToString().Length < 13 Then
                    CantidadCeros = 13 - grp(0).Item("CodigoAndrea").ToString().Length
                    For value As Integer = 1 To CantidadCeros
                        CerosInicio &= "0"
                    Next
                End If
            End If

            NumeroCodigosAndreaDiferentes += 1

            myXmlTextWriter.WriteElementString("Alternativa", CerosInicio & grp(0).Item("CodigoAndrea"))
            myXmlTextWriter.WriteElementString("Cantidad", grp.Count)
            NumeroEtiquetasAndrea += grp.Count
            myXmlTextWriter.WriteElementString("Pasillo", "N/A")
        Next

        DTEtiquetasPasillo = ObjDA.ObtenerNumeroPasilloEtiquetas(numLotesAndrea, FEchaConfirmacion)
        If DTEtiquetasCodigos.Rows.Count > 0 Then
            Pasilo = DTEtiquetasCodigos.Rows(0).Item("Pasillo")
        End If

        myXmlTextWriter.WriteElementString("Alternativa", NumeroCodigosAndreaDiferentes)
        myXmlTextWriter.WriteElementString("Cantidad", NumeroEtiquetasAndrea)
        myXmlTextWriter.WriteElementString("Pasillo", Pasilo)


        myXmlTextWriter.WriteEndElement()

        myXmlTextWriter.Flush()
        myXmlTextWriter.Close()



        If tipoArchivo = 1 Then
            result = "Archivos generados correctamente."
        Else
            result = "Archivo generado correctamente."
        End If


        Return result

    End Function

    Public Function GenerarEtiquetasAndreavariosLotes(ByVal numLotesAndrea As String, ByVal rutaGuardar As String, ByVal ordenTrabajoId As Integer, ByVal numArchivo As Integer, ByVal tipoArchivo As Integer, ByVal idLote As Integer, ByVal FEchaConfirmacion As Date) As String
        Dim result As String = String.Empty
        Dim ObjDA As New Datos.OrdenTrabajoDA

        Dim datosXMLAndrea As New DataTable
        Dim ListaCodigosAtadosH As New List(Of String)
        Dim ListaCodigosAtadosUnicos As New List(Of String)
        Dim DTEtiquetasCodigos As New DataTable
        Dim DTEtiquetasCodigosH As New DataTable
        Dim NumeroEtiquetasAndrea As Integer = 0
        Dim Pasilo As String = String.Empty
        Dim NumeroCodigosAndreaDiferentes As Integer = 0
        Dim DTEtiquetasPasillo As DataTable
        Dim DTEtiquetasCodigosSInCompletar As New DataTable
        Dim CerosInicio As String = String.Empty
        Dim CantidadCeros As Integer = 0
        Dim Indice As Integer = 0


        DTEtiquetasCodigosH.Columns.Add("CodigoAndrea", GetType(String))
        DTEtiquetasCodigos.Columns.Add("CodigoAndrea", GetType(String))
        DTEtiquetasCodigos.Columns.Add("NumeroEtiquetas", GetType(Integer))
        DTEtiquetasCodigosSInCompletar.Columns.Add("CodigoAndrea", GetType(String))
        DTEtiquetasCodigosSInCompletar.Columns.Add("NumeroEtiquetas", GetType(Integer))

        datosXMLAndrea = ObjDA.GenerarEtiquetasAndreavariosLotes(ordenTrabajoId, numLotesAndrea, FEchaConfirmacion)


        Dim AtadosUnicos = datosXMLAndrea.AsEnumerable.Where(Function(x) x.Item("Cantidad").ToString = 5)
        Dim AtadosH = datosXMLAndrea.AsEnumerable.Where(Function(x) x.Item("Cantidad").ToString < 5)

        For Each Atado As DataRow In AtadosUnicos
            DTEtiquetasCodigos.Rows.Add(Atado.Item("CodigoAndrea").ToString, 1)
        Next


        For Each Atado As DataRow In AtadosH
            If Atado.Item("Cantidad") = 1 Then
                DTEtiquetasCodigosH.Rows.Add(Atado.Item("CodigoAndrea"))
            Else
                For index As Integer = 1 To Atado.Item("Cantidad")

                    DTEtiquetasCodigosH.Rows.Add(Atado.Item("CodigoAndrea"))
                Next
            End If
        Next


        Dim grupo = DTEtiquetasCodigosH.AsEnumerable.GroupBy(Function(x) x.Item("CodigoAndrea"))

        Dim NumeroEtiquetasH As Integer = 0

        For Each grp In grupo
            If grp.Count >= 5 Then
                NumeroEtiquetasH = Fix(grp.Count / 5)
                For index As Integer = 1 To NumeroEtiquetasH
                    DTEtiquetasCodigos.Rows.Add(grp(0).Item("CodigoAndrea"), 1)
                Next
            Else
                If DTEtiquetasCodigosSInCompletar.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea") = grp(0).Item("CodigoAndrea")).Count = 0 And DTEtiquetasCodigos.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea") = grp(0).Item("CodigoAndrea")).Count = 0 Then
                    DTEtiquetasCodigosSInCompletar.Rows.Add(grp(0).Item("CodigoAndrea"), 0)
                End If
            End If
        Next


        Dim CantidadEtiquetasPorCodigo = DTEtiquetasCodigos.AsEnumerable.GroupBy(Function(X) X.Item("CodigoAndrea"))


        If System.IO.Directory.Exists("C:\Arc_Sync\") = False Then
            System.IO.Directory.CreateDirectory("C:\Arc_Sync\")
        End If

        Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(rutaGuardar + "descarga" + If(tipoArchivo = 1, "_" + idLote.ToString() + If(numArchivo > 0, "_" + numArchivo.ToString(), ""), "_Etiquetas_Completo") + ".xml", System.Text.Encoding.UTF8)
        myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
        myXmlTextWriter.WriteStartDocument(False)

        'Crear el elemento de documento principal Comprobante.
        myXmlTextWriter.WriteStartElement("NewDataSet")


        For Each grp In CantidadEtiquetasPorCodigo
            myXmlTextWriter.WriteStartElement("Captura")
            NumeroCodigosAndreaDiferentes += 1
            NumeroEtiquetasAndrea += grp.Count

            CantidadCeros = 0
            CerosInicio = String.Empty
            Indice = 0

            If grp(0).Item("CodigoAndrea").ToString().Length < 13 Then
                CantidadCeros = 13 - grp(0).Item("CodigoAndrea").ToString().Length
                For value As Integer = 1 To CantidadCeros
                    CerosInicio &= "0"
                Next
            End If

            myXmlTextWriter.WriteElementString("Alternativa", CerosInicio & grp(0).Item("CodigoAndrea"))
            myXmlTextWriter.WriteElementString("Cantidad", grp.Count)
            myXmlTextWriter.WriteElementString("Pasillo", "N/A")
            myXmlTextWriter.WriteEndElement()
        Next


        For Each Fila As DataRow In DTEtiquetasCodigosSInCompletar.Rows
            CantidadCeros = 0
            CerosInicio = String.Empty
            Indice = 0

            If Fila.Item("CodigoAndrea").ToString().Length < 13 Then
                CantidadCeros = 13 - Fila.Item("CodigoAndrea").ToString().Length
                For value As Integer = 1 To CantidadCeros
                    CerosInicio &= "0"
                Next
            End If


            myXmlTextWriter.WriteStartElement("Captura")
            NumeroCodigosAndreaDiferentes += 1
            myXmlTextWriter.WriteElementString("Alternativa", CerosInicio & Fila.Item("CodigoAndrea"))
            myXmlTextWriter.WriteElementString("Cantidad", 0)
            myXmlTextWriter.WriteElementString("Pasillo", "N/A")
            myXmlTextWriter.WriteEndElement()
        Next

        'DTEtiquetasCodigosSInCompletar

        DTEtiquetasPasillo = ObjDA.ObtenerNumeroPasilloEtiquetas(FEchaConfirmacion, numLotesAndrea)
        If DTEtiquetasPasillo.Rows.Count > 0 Then
            If IsDBNull(DTEtiquetasPasillo.Rows(0).Item("Pasillo")) = False Then
                Pasilo = DTEtiquetasPasillo.Rows(0).Item("Pasillo")
            Else
                Pasilo = String.Empty
            End If

        End If
        myXmlTextWriter.WriteStartElement("Captura")

        myXmlTextWriter.WriteElementString("Alternativa", NumeroCodigosAndreaDiferentes)
        myXmlTextWriter.WriteElementString("Cantidad", NumeroEtiquetasAndrea)
        myXmlTextWriter.WriteElementString("Pasillo", Pasilo)

        myXmlTextWriter.WriteEndElement()


        myXmlTextWriter.WriteEndElement()

        myXmlTextWriter.Flush()
        myXmlTextWriter.Close()



        If tipoArchivo = 1 Then
            result = "Archivos generados correctamente."
        Else
            result = "Archivo generado correctamente."
        End If

        Return result
    End Function

    Public Function ConsultaLotesAndreaPorLOTEtiquetasPorFecha(ByVal FechaConfirmacion As Date) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultaLotesAndreaPorLOTEtiquetasPorFecha(FechaConfirmacion)
    End Function

    Public Function ObtenerNumeroPasilloEtiquetas(ByVal FechaConfirmacion As Date, ByVal NumeroLote As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerNumeroPasilloEtiquetas(FechaConfirmacion, NumeroLote)
    End Function

    Public Function ObtenerCodigosAndreaConfirmadosPorFecha(ByVal FechaConfirmacion As Date) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerCodigosAndreaConfirmadosPorFecha(FechaConfirmacion)
    End Function

    Public Function ActualizarEstatusGenerarXMLEtiquetas(ByVal LoteAndrea As String, ByVal FechaConfirmacion As Date) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ActualizarEstatusGenerarXMLEtiquetas(LoteAndrea, FechaConfirmacion)
    End Function

    Public Function CapturaObservacionesOT(ByVal OrdenTrabajoID As String, ByVal Observaciones As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CapturaObservacionesOT(OrdenTrabajoID, Observaciones)
    End Function

    Public Function ObtenerObservacionesOT(ByVal OrdenTrabajoID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerObservacionesOT(OrdenTrabajoID)
    End Function

    Public Function EliminarObservacionesOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.EliminarObservacionesOT(OrdenTrabajoID)
    End Function

    Public Function GenerarOrdenesTrabajo(ByVal SesionUsuarioID As Integer, ByVal UsuarioId As Integer)
        Dim tabla As New DataTable
        'Genera los encabezados de las OTS
        tabla = GenerarEncabezadosOT(SesionUsuarioID)
        'Genera los detalles de las OTS
        GenerarDetallesOrdenesTrabajo(UsuarioId)

        RelacionarOTPares(UsuarioId)

        Return tabla

    End Function

#Region "Generación de OTs"

    Private Function GenerarEncabezadosOT(ByVal SesionUsuarioID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Dim dtResultadoGeneracion As New DataTable
        Try
            dtResultadoGeneracion = objDA.GenerarEncabezadoOrdenesTrabajo(SesionUsuarioID)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                dtResultadoGeneracion = GenerarEncabezadosOT(SesionUsuarioID)
            End If
        End Try
        Return dtResultadoGeneracion
    End Function

    Private Sub GenerarDetallesOrdenesTrabajo(ByVal UsuarioId As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Try
            objDA.GenerarDetallesOrdenesTrabajo(UsuarioId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                GenerarDetallesOrdenesTrabajo(UsuarioId)
            End If
        End Try
    End Sub

    Private Sub RelacionarOTPares(ByVal UsuarioId As Integer)
        Dim objDA As New Ventas.Datos.ProyeccionEntregasDA
        Try
            objDA.RelacionarOTPares(UsuarioId)
        Catch ex As Exception
            If ex.Message.ToString.Contains("interbloqueo") Then
                RelacionarOTPares(UsuarioId)
            End If
        End Try
    End Sub

#End Region

    Public Function ObtenerHorariosRecibo(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerHorariosRecibo(OrdenTrabajoID)
    End Function

    Public Function CargarOTVentasFiltrosDefault(ByVal TipoOT As String, ByVal AtnClientes As String, ByVal StatusOT As String, ByVal RequiereCita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CargarOTVentasFiltrosDefault(TipoOT, AtnClientes, StatusOT, RequiereCita, TipoFecha, FechaInicio, FechaFin, CEDISID)
    End Function

    Public Function CargarOTVentasConFiltros(ByVal TipoOT As String, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal ClienteID As String, ByVal TiendaID As String, ByVal AtnClientes As String, ByVal AgenteVentasID As String, ByVal StatusOT As String, ByVal MarcaId As String, ByVal ColeccionID As String, ByVal ModeloID As String, ByVal PielId As String, ByVal ColorID As String, ByVal Corrida As String, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CargarOTVentasConFiltros(TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, ClienteID, TiendaID, AtnClientes, AgenteVentasID, StatusOT, MarcaId, ColeccionID, ModeloID, PielId, ColorID, Corrida, CEDISID)
    End Function

    Public Function CargarOTVentas(ByVal TipoOT As String, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal ClienteID As String, ByVal TiendaID As String, ByVal AtnClientes As String, ByVal AgenteVentasID As String, ByVal StatusOT As String, ByVal MarcaId As String, ByVal ColeccionID As String, ByVal ModeloID As String, ByVal PielId As String, ByVal ColorID As String, ByVal Corrida As String, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA

        If PedidoSAY = String.Empty And PedidoSICY = String.Empty And FolioOT = String.Empty And ClienteID = String.Empty And TiendaID = String.Empty And MarcaId = String.Empty And ColeccionID = String.Empty And ModeloID = String.Empty And PielId = String.Empty And ColorID = String.Empty And Corrida = String.Empty And AgenteVentasID = String.Empty Then
            Return objDA.CargarOTVentasFiltrosDefault(TipoOT, AtnClientes, StatusOT, Cita, TipoFecha, FechaInicio, FechaFin, CEDISID)
        Else
            Return objDA.CargarOTVentasConFiltros(TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, ClienteID, TiendaID, AtnClientes, AgenteVentasID, StatusOT, MarcaId, ColeccionID, ModeloID, PielId, ColorID, Corrida, CEDISID)
        End If
    End Function

    Public Function CargarOTAlmacenFiltrosDefault(ByVal TipoOT As String, ByVal StatusOT As String, ByVal RequiereCita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal UsuarioID As Integer, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CargarOTAlmacenFiltrosDefault(TipoOT, StatusOT, RequiereCita, TipoFecha, FechaInicio, FechaFin, UsuarioID, CEDISID)
    End Function

    Public Function CargarOTAlmacenConFiltros(ByVal TipoOT As String, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal ClienteID As String, ByVal TiendaID As String, ByVal AtnClientes As String, ByVal AgenteVentasID As String, ByVal StatusOT As String, ByVal MarcaId As String, ByVal ColeccionID As String, ByVal ModeloID As String, ByVal PielId As String, ByVal ColorID As String, ByVal Corrida As String, ByVal OperadorId As String, ByVal UsuarioID As Integer, ByVal CEDISID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CargarOTAlmacenConFiltros(TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, ClienteID, TiendaID, AtnClientes, AgenteVentasID, StatusOT, MarcaId, ColeccionID, ModeloID, PielId, ColorID, Corrida, OperadorId, UsuarioID, CEDISID)
    End Function

    Public Function CargarOTAlmacen(ByVal TipoOT As String, ByVal Cita As Integer, ByVal TipoFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal PedidoSAY As String, ByVal PedidoSICY As String, ByVal FolioOT As String, ByVal ClienteID As String, ByVal TiendaID As String, ByVal AtnClientes As String, ByVal AgenteVentasID As String, ByVal StatusOT As String, ByVal MarcaId As String, ByVal ColeccionID As String, ByVal ModeloID As String, ByVal PielId As String, ByVal ColorID As String, ByVal Corrida As String, ByVal Operador As String, Optional ByVal UsuarioId As Integer = 1, Optional ByVal CEDISID As Integer = 43) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA

        If AtnClientes = String.Empty And PedidoSAY = String.Empty And PedidoSICY = String.Empty And FolioOT = String.Empty And ClienteID = String.Empty And TiendaID = String.Empty And MarcaId = String.Empty And ColeccionID = String.Empty And ModeloID = String.Empty And PielId = String.Empty And ColorID = String.Empty And Corrida = String.Empty And Operador = String.Empty And AgenteVentasID = String.Empty Then
            Return objDA.CargarOTAlmacenFiltrosDefault(TipoOT, StatusOT, Cita, TipoFecha, FechaInicio, FechaFin, UsuarioId, CEDISID)
        Else
            Return objDA.CargarOTAlmacenConFiltros(TipoOT, Cita, TipoFecha, FechaInicio, FechaFin, PedidoSAY, PedidoSICY, FolioOT, ClienteID, TiendaID, AtnClientes, AgenteVentasID, StatusOT, MarcaId, ColeccionID, ModeloID, PielId, ColorID, Corrida, Operador, UsuarioId, CEDISID)
        End If
    End Function

    Public Function ParesConfirmadosOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ParesConfirmadosOT(OrdenTrabajoID)
    End Function

    Public Function ObtenerParesConfirmadosOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerParesConfirmadosOT(OrdenTrabajoID)
    End Function

    Public Function EnviarAFacturarOT(ByVal OTID As Integer, ByVal ColaboradorId As Integer, ByVal TotalPares As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.EnviarAFacturarOT(OTID, ColaboradorId, TotalPares)
    End Function

    Public Function ObtenerInformacionParesOT(ByVal OrdenTrabajoID As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ObtenerInformacionParesOT(OrdenTrabajoID)
    End Function

    Public Sub ActualizarAPorFacturarOT(ByVal OTID As Integer)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.ActualizarAPorFacturarOT(OTID)
    End Sub

    Public Sub ActualizarEstatusPartidaOrdenTrabajo(ByVal OTID As Integer)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.ActualizarEstatusPartidaOrdenTrabajo(OTID)
    End Sub

    Public Function ConsultarDestinatariosCorreoOTYISTI(ByVal Clave As String, ByVal NaveSAYID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarDestinatariosCorreoOTYISTI(Clave, NaveSAYID)
    End Function

    Public Function ConsultarPartidasParesRechazadosAndrea(ByVal OTID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarPartidasParesRechazadosAndrea(OTID)
    End Function

    Public Function CancelarParesRechazados(ByVal OTID As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CancelarParesRechazados(OTID, UsuarioId)
    End Function

    Public Function DesasignarParesCanceladosAndrea(ByVal OTID As Integer, ByVal OrdenTrabajoDetalleId As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.DesasignarParesCanceladosAndrea(OTID, OrdenTrabajoDetalleId)
    End Function

    Public Function ConsultarAgenteVentas(ColaboradorID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Try
            Return objDA.ConsultarAgenteVentas(ColaboradorID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EnviarDatosParaConfirmacion(OrdenTrabajoID As String)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.EnviarDatosParaConfirmacion(OrdenTrabajoID)
    End Sub

    Public Sub ActualizarOTUbicaciones(OrdenTrabajoID As String)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        objDA.ActualizarOTUbicaciones(OrdenTrabajoID)
    End Sub
    Public Function AsignarNumeroASN(OrdenTrabajos As String, numeroASN As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.AsignarNumeroASN(OrdenTrabajos, numeroASN)
    End Function

    Public Function CancelarParesRechazadosAndrea(ByVal OTID As Integer, ByVal UsuarioID As Integer, ByVal PartidaDetalleID As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.CancelarParesRechazadosAndrea(OTID, UsuarioID, PartidaDetalleID)
    End Function

    Public Function ConsultarReporteOTDesasignacion_Encabezado(ordenTrabajo As Integer) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarReporteOTDesasignacion_Encabezado(ordenTrabajo)
    End Function

    Public Function ConsultarReporteOTDesasignacion(ordenTrabajo As String) As DataTable
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Return objDA.ConsultarReporteOTDesasignacion(ordenTrabajo)
    End Function

    Public Function ValidarestatusPedido(ByVal pedidoId As Integer)
        Dim objDA As New Ventas.Datos.OrdenTrabajoDA
        Dim estatusId As Integer
        Dim tabla As New DataTable
        tabla = objDA.ValidarestatusPedido(pedidoId)
        estatusId = tabla.Rows(0).Item("Res")
        Return estatusId
    End Function

    Public Function ConsultaTiendasRFC(ByVal clienteid As Integer, ByVal rfc As Integer)
        'ByVal pedido As Integer,
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.ConsultaTiendasRFC(clienteid, rfc)
    End Function

    Public Function ConsultaRFCCliente(ByVal clienteId As Integer, ByVal rfcBloqueado As Integer, ByVal pedidoId As Integer)
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.ConsultaRFCCliente(clienteId, rfcBloqueado, pedidoId)
    End Function

    Public Function ConultaDetallePedido(ByVal pedidoId As Integer, ByVal Ots As String)
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.ConultaDetallePedido(pedidoId, Ots)
    End Function


    Public Function CambioDeTiendaPartidasPedido(ByVal rfc As Integer, ByVal pedidoSAY As Integer, ByVal pedidoSICY As Integer, ByVal partida As String,
                                                 ByVal TIECNuevo As Integer, ByVal rfcSICYNuevo As Integer, ByVal ordenCompra As String)
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.CambioDeTiendaPartidasPedido(rfc, pedidoSAY, pedidoSICY, partida, TIECNuevo, rfcSICYNuevo, ordenCompra)
    End Function

    Public Function GuardarRespaldo(ByVal pedidoSAY As Integer, ByVal pedidoSICY As Integer, ByVal OT As Integer, ByVal Partida As String,
                                    ByVal RFCAnterior As Integer, ByVal RFCNuevo As Integer, ByVal TECAnterior As Integer, TECNuevo As Integer,
                                    ByVal UsuarioId As Integer, ByVal rfcSICYNuevo As Integer, ByVal modificado As Integer,
                                    ByVal OCAnterior As String, ByVal OCNuevo As String)
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.GuardarRespaldo(pedidoSAY, pedidoSICY, OT, CInt(Partida), RFCAnterior, RFCNuevo, TECAnterior, TECNuevo, UsuarioId, rfcSICYNuevo, modificado, OCAnterior, OCNuevo)
    End Function

    Public Function ValidaExistenOtFacturadasEnPedido(ByVal pedidoSAY As Integer)
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.ValidaExistenOtFacturadasEnPedido(pedidoSAY)
    End Function

    Public Function ActualizarOCcliente(ByVal ordenTrabajoId As Integer, ByVal ocNuevo As String)
        'ByVal ocNuevo As String, ByVal pedidosay As Integer, ByVal pedidosicy As Integer
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        'ocNuevo, pedidosay, pedidosicy
        Return objDa.ActualizarOCcliente(ordenTrabajoId, ocNuevo)
    End Function

    Public Function ActualizarOts_CambiarOrdenCompra_CargoAdicional(ByVal Ot As String, ByVal OrdenCompra As String, ByVal cargoAdicional As Decimal) As DataTable
        Dim objDa As New Ventas.Datos.OrdenTrabajoDA
        Return objDa.ActualizarOts_CambiarOrdenCompra_CargoAdicional_Sac(Ot, OrdenCompra, cargoAdicional)
    End Function

End Class
