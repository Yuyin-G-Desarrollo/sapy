Public Class VisitanteBU
    Public Function consultarEventoActivo() As Entidades.Evento
        Dim objDA As New Datos.VisitanteDA
        Dim tabla As New DataTable
        Dim evento As New Entidades.Evento

        tabla = objDA.consultarEventoActivo()
        If tabla.Rows.Count <> 0 Then
            evento.EEventoId = CInt(tabla.Rows(0).Item("even_eventoid").ToString)
            evento.ENombre = CStr(tabla.Rows(0).Item("even_nombre").ToString)
            evento.EAbreviatura = CStr(tabla.Rows(0).Item("even_abreviatura").ToString)
            evento.ELugar = CStr(tabla.Rows(0).Item("even_lugar").ToString)
            evento.EFechaInicioEvento = CDate(tabla.Rows(0).Item("even_fechainicioevento").ToString)
            evento.EFEchaFinEvento = CDate(tabla.Rows(0).Item("even_fechafinevento").ToString)
            evento.EParesPedidos = CInt(tabla.Rows(0).Item("even_parespedidos").ToString)
            evento.EConsecutivoVisitante = CInt(tabla.Rows(0).Item("even_consecutivovisitante").ToString)
            evento.EFechaEntregaColeccionesNuevas = CDate(tabla.Rows(0).Item("even_fechaentrega_coleccionesnuevas").ToString)
            evento.EFechaEntregaColeccionesVigentes = CDate(tabla.Rows(0).Item("even_fechaentrega_coleccionesvigentes").ToString)
        End If

        Return evento
    End Function

    Public Function consultarFechaActual() As String
        Dim objDA As New Datos.VisitanteDA
        Dim tabla As New DataTable
        Dim fechaActual As String = String.Empty

        tabla = objDA.consultarFechaActual()
        If tabla.Rows.Count <> 0 Then
            fechaActual = tabla.Rows(0).Item("FECHA_ACTUAL").ToString
        End If

        Return fechaActual
    End Function

    Public Function consultarTipoVisitante() As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarTipoVisitante()
    End Function

    Public Function consultarDistribuidores() As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarDistribuidores()
    End Function

    Public Function consultarAtiende() As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarAtiende()
    End Function

    Public Function consultarClientesVisitantes(ByVal opcion As Int32, ByVal filtro As String) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarClientesVisitantes(opcion, filtro)
    End Function

    Public Function consultarDatosVisitanteAnterior(ByVal visitanteId As Int32) As Entidades.Visitante
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim visitante As New Entidades.Visitante

        table = objDA.consultarDatosVisitanteAnterior(visitanteId)

        If table.Rows.Count <> 0 Then
            visitante.VId = CInt(table.Rows(0)("ID").ToString)
            visitante.VNombreVisitante = table.Rows(0)("NOMBRE").ToString
            visitante.VCalle = table.Rows(0)("CALLE").ToString
            visitante.VNumeroExterior = table.Rows(0)("NUM_EXT").ToString
            visitante.VColonia = table.Rows(0)("COLONIA").ToString
            visitante.VCiudadId = CInt(table.Rows(0)("CIUDAD_ID").ToString)
            visitante.VEstadoId = CInt(table.Rows(0)("ESTADO_ID").ToString)
            visitante.VPaisId = CInt(table.Rows(0)("PAIS_ID").ToString)
            visitante.VCiudad = table.Rows(0)("CIUDAD").ToString
            visitante.VEstado = table.Rows(0)("ESTADO").ToString
            visitante.VPais = table.Rows(0)("PAIS").ToString
            visitante.VCorreoElectronico = table.Rows(0)("CORREO").ToString
            visitante.VDirector = table.Rows(0)("DIRECTOR").ToString
            visitante.VOtroContacto = table.Rows(0)("OTRO_CONTACTO").ToString
            visitante.VDistribuidorClienteId = CInt(table.Rows(0)("DISTRIBUIDOR_ID").ToString)
            visitante.VOtroDistribuidor = table.Rows(0)("OTRO_DISTRIBUIDOR").ToString
            visitante.VNombreComercial = table.Rows(0)("NOMBRE_COMERCIAL").ToString
            visitante.VRamoId = CInt(table.Rows(0)("RAMO_ID").ToString)
            visitante.VCantidadTiendas = CInt(table.Rows(0)("CANT_TIENDAS").ToString)
        End If

        Return visitante
    End Function

    Public Function consultarDatosCliente(ByVal clienteId As Int32) As Entidades.Visitante
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim visitante As New Entidades.Visitante

        table = objDA.consultarDatosCliente(clienteId)

        If table.Rows.Count <> 0 Then
            visitante.VId = CInt(table.Rows(0)("clie_clienteid").ToString)
            visitante.VPersonaId = CInt(table.Rows(0)("clie_personaidcliente").ToString)
            visitante.VNombreVisitante = table.Rows(0)("Nombre").ToString
            visitante.VCalle = table.Rows(0)("domi_calle").ToString
            visitante.VNumeroExterior = table.Rows(0)("domi_numexterior").ToString
            visitante.VColonia = table.Rows(0)("domi_colonia").ToString
            visitante.VCiudadId = CInt(table.Rows(0)("city_ciudadid").ToString)
            visitante.VEstadoId = CInt(table.Rows(0)("esta_estadoid").ToString)
            visitante.VPaisId = CInt(table.Rows(0)("pais_paisid").ToString)
            visitante.VCiudad = table.Rows(0)("city_nombre").ToString
            visitante.VNombreComercial = table.Rows(0)("RazonSocial").ToString
        End If

        Return visitante
    End Function

    Public Function consultarEmailCliente(ByVal personaId As Int32) As String
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim email As String = String.Empty

        table = objDA.consultarEmailCliente(personaId)

        If table.Rows.Count <> 0 Then
            email = table.Rows(0)("empe_email").ToString
        End If

        Return email
    End Function
    Public Function consultarDirectorCliente(ByVal personaId As Int32) As String
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim director As String = String.Empty

        table = objDA.consultarDirectorCliente(personaId)

        If table.Rows.Count <> 0 Then
            director = table.Rows(0)("pers_nombre").ToString
        End If

        Return director
    End Function

    Public Function consultarRamoCliente(ByVal clienteId As Integer) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarRamoCliente(clienteId)
    End Function

    Public Function consultarTiendasCliente(ByVal clienteId As Int32) As String
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim tiendas As Integer

        table = objDA.consultarTiendasCliente(clienteId)

        If table.Rows.Count <> 0 Then
            tiendas = table.Rows(0)("TIENDAS").ToString
        End If

        Return tiendas
    End Function

    Public Function consultarTelefonosVisitante(ByVal visitanteId As Int32) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarTelefonosVisitante(visitanteId)
    End Function

    Public Function consultarTelefonosCliente(ByVal personaId As Int32) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarTelefonosCliente(personaId)
    End Function

    Public Function consultarClienteEventosAnteriores(ByVal nombreVisitante As String, ByVal nombreComercial As String) As String
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim eventos As Integer
        Dim resultado As String = "NO"

        table = objDA.consultarClienteEventosAnteriores(nombreVisitante, nombreComercial)

        If table.Rows.Count <> 0 Then
            eventos = CInt(table.Rows(0)("Eventos").ToString)

            If eventos > 0 Then
                resultado = "SI"
            End If
        End If

        Return resultado
    End Function

    Public Function altaVisitante(ByVal visitante As Entidades.Visitante) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable

        table = objDA.altaVisitante(visitante)
        Return table
    End Function

    Public Sub altaTelefonoVisitante(ByVal personaId As Integer, ByVal telefono As Entidades.TelefonoVisitante)
        Dim objDA As New Datos.VisitanteDA
        objDA.altaTelefonoVisitante(personaId, telefono)
    End Sub

    Public Function consultarEventos() As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarEventos()
    End Function

    Public Function consultarListadoVisitantes(ByVal eventoId As Integer, ByVal visitantesIds As String, ByVal atendioIds As String, ByVal tipos As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal condicion As String) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarListadoVisitantes(eventoId, visitantesIds, atendioIds, tipos, fechaInicio, fechaFin, condicion)
    End Function

    Public Function consultarVisitante(ByVal visitanteId As Int32) As Entidades.Visitante
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim visitante As New Entidades.Visitante

        table = objDA.consultarVisitante(visitanteId)
        If table.Rows.Count <> 0 Then
            visitante.VId = CInt(table.Rows(0)("ID").ToString)
            visitante.VEvento = table.Rows(0)("EVENTO").ToString
            visitante.VEventoId = table.Rows(0)("EVENTO_ID").ToString
            visitante.VConsecutivoEvento = CInt(table.Rows(0)("CONSECUTIVO").ToString)
            visitante.VFecha = table.Rows(0)("FECHA").ToString
            visitante.VUsuario = table.Rows(0)("USUARIO").ToString
            visitante.VNombreVisitante = table.Rows(0)("NOMBRE").ToString
            visitante.VClasificacionPersonaId = CInt(table.Rows(0)("CLASIFICACION_ID").ToString)
            visitante.VEventosAnteriores = CBool(table.Rows(0)("EVENTOS_ANTERIORES").ToString)
            visitante.VCalle = table.Rows(0)("CALLE").ToString
            visitante.VNumeroExterior = table.Rows(0)("NUM_EXT").ToString
            visitante.VColonia = table.Rows(0)("COLONIA").ToString
            visitante.VCiudadId = CInt(table.Rows(0)("CIUDAD_ID").ToString)
            visitante.VEstadoId = CInt(table.Rows(0)("ESTADO_ID").ToString)
            visitante.VPaisId = CInt(table.Rows(0)("PAIS_ID").ToString)
            visitante.VCiudad = table.Rows(0)("CIUDAD").ToString
            visitante.VEstado = table.Rows(0)("ESTADO").ToString
            visitante.VPais = table.Rows(0)("PAIS").ToString
            visitante.VCorreoElectronico = table.Rows(0)("CORREO").ToString
            visitante.VDirector = table.Rows(0)("DIRECTOR").ToString
            visitante.VOtroContacto = table.Rows(0)("OTRO_CONTACTO").ToString
            visitante.VHaCombradoYuyin = CBool(table.Rows(0)("HA_COMPRADO_YUYIN").ToString)
            visitante.VDistribuidorClienteId = CInt(table.Rows(0)("DISTRIBUIDOR_ID").ToString)
            visitante.VOtroDistribuidor = table.Rows(0)("OTRO_DISTRIBUIDOR").ToString
            visitante.VNombreComercial = table.Rows(0)("NOMBRE_COMERCIAL").ToString
            visitante.VRamoId = CInt(table.Rows(0)("RAMO_ID").ToString)
            visitante.VCantidadTiendas = CInt(table.Rows(0)("CANT_TIENDAS").ToString)
            visitante.VObservaciones = table.Rows(0)("OBSERVACIONES").ToString
            visitante.VUsuarioAtiendeId = CInt(table.Rows(0)("ATENDIO_ID").ToString)
            visitante.VClienteId = CInt(table.Rows(0)("CLIENTE_ID").ToString)
            visitante.VPersonaId = CInt(table.Rows(0)("PERSONA_ID").ToString)
        End If

        Return visitante
    End Function

    Public Sub editarVisitante(ByVal visitante As Entidades.Visitante)
        Dim objDA As New Datos.VisitanteDA
        objDA.editarVisitante(visitante)
    End Sub

    Public Sub editarTelefonoVisitante(ByVal telefono As Entidades.TelefonoVisitante)
        Dim objDA As New Datos.VisitanteDA
        objDA.editarTelefonoVisitante(telefono)
    End Sub

    Public Function consultarListadoFiltroVisitantes(ByVal eventoId As Integer, ByVal filtro As String) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarListadoFiltroVisitantes(eventoId, filtro)
    End Function

    Public Function consultarFechasEvento(ByVal eventoId As Integer) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Return objDA.consultarFechasEvento(eventoId)
    End Function

    Public Function consultarNumPedidosVisitante(ByVal visitanteId As Int32) As String
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim numPedidos As String = String.Empty

        table = objDA.consultarNumPedidosVisitante(visitanteId)
        If table.Rows.Count <> 0 Then
            numPedidos = table.Rows(0)("NumPedidos").ToString
        End If

        Return numPedidos
    End Function

    Public Function consultarVisitanteTipoClasificacion(ByVal visitanteId As Integer) As String
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim numPedidos As String = String.Empty

        table = objDA.consultarVisitanteTipoClasificacion(visitanteId)
        If table.Rows.Count <> 0 Then
            numPedidos = table.Rows(0)("CLASIFICACION_ID").ToString
        End If

        Return numPedidos
    End Function

    Public Function consultarVisitanteTipoClasificaciondt(ByVal visitanteId As Integer) As DataTable
        Dim objDA As New Datos.VisitanteDA
        Dim table As New DataTable
        Dim numPedidos As String = String.Empty

        table = objDA.consultarVisitanteTipoClasificacion(visitanteId)

        Return table
    End Function

End Class
