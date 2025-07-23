Imports System.Data.SqlClient

Public Class ProyeccionEntregasDA

    Public Function ListadoParametroProyeccionEntregas(tipo_busqueda As Integer, ColaboradorID As Integer, TipoPerfil As Integer, tipoCliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoPerfil"
        parametro.Value = TipoPerfil
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoCliente"
        parametro.Value = tipoCliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultasFiltros_18122018", listaParametros)

    End Function

    Public Function ConsultaSesionActivaPorUsuario(idUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioProyectando"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultaSesionActivaPorUsuario", listaParametros)

    End Function
    Public Function CompararPedidOrigen(ByVal pedidoSay As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@PedidoSay"
        parametro.Value = pedidoSay
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_CompararPedidosOriginalesSAY", listaParametros)

    End Function

    Public Function ConsultaSesionActivaPorUsuario_SoloConsulta(idUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioProyectando"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultaSesionActivaPorUsuario_SoloConsulta", listaParametros)

    End Function

    Public Sub GeneracionDatosProyeccionEntregas(colaboradorId As Integer, usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer, filtros As Entidades.ProyeccionEntregas)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioNombre"
        parametro.Value = usuarioNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = sesionAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaInicio"
        parametro.Value = filtros.PfechaEntregaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaFin"
        parametro.Value = filtros.PfechaEntregaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MostrarClientesSiRequierenCita"
        parametro.Value = filtros.PmostrarClientesCita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MostrarClientesNoRequierenCita"
        parametro.Value = filtros.PmostrarClientesNoCita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusPedido"
        parametro.Value = filtros.PstatusPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PlazoPago"
        parametro.Value = filtros.PplazoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = filtros.PpedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = filtros.PpedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = filtros.Pcliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaEmbarqueCedis"
        parametro.Value = filtros.PtiendaEmbarqueCedis
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = filtros.PatnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = filtros.PagenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = filtros.Pmarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = filtros.Pcoleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = filtros.Pmodelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = filtros.Ppiel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = filtros.Pcolor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = filtros.Pcorrida
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_GenerarDatosPartidasParaProyectar", listaParametros)

    End Sub

    Public Sub GeneracionDatosProyeccionEntregas_SoloConsulta(colaboradorId As Integer, usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer, filtros As Entidades.ProyeccionEntregas)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioNombre"
        parametro.Value = usuarioNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = sesionAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaInicio"
        parametro.Value = filtros.PfechaEntregaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaEntregaFin"
        parametro.Value = filtros.PfechaEntregaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MostrarClientesSiRequierenCita"
        parametro.Value = filtros.PmostrarClientesCita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MostrarClientesNoRequierenCita"
        parametro.Value = filtros.PmostrarClientesNoCita
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "StatusPedido"
        parametro.Value = filtros.PstatusPedido
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PlazoPago"
        parametro.Value = filtros.PplazoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSAY"
        parametro.Value = filtros.PpedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSICY"
        parametro.Value = filtros.PpedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = filtros.Pcliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TiendaEmbarqueCedis"
        parametro.Value = filtros.PtiendaEmbarqueCedis
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AtnClientes"
        parametro.Value = filtros.PatnClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AgenteVentas"
        parametro.Value = filtros.PagenteVentas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Marca"
        parametro.Value = filtros.Pmarca
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Coleccion"
        parametro.Value = filtros.Pcoleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modelo"
        parametro.Value = filtros.Pmodelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Piel"
        parametro.Value = filtros.Ppiel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Color"
        parametro.Value = filtros.Pcolor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corrida"
        parametro.Value = filtros.Pcorrida
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_GenerarDatosPartidasParaProyectar_SoloConsulta", listaParametros)

    End Sub

    Public Function ConsultaProyeccionPorNivel(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = consultaNivel.PtipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSAY"
        parametro.Value = consultaNivel.PidPedidoSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = consultaNivel.PidPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lote"
        parametro.Value = consultaNivel.Plote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = consultaNivel.Paño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveSicyID"
        parametro.Value = consultaNivel.PnaveSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Atado"
        parametro.Value = consultaNivel.Patado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultaPantallaProyeccionPorNivel", listaParametros)

    End Function

    Public Function LimpiarSesionUsuarioCerrarPantalla(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = SesionID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_LimpiarSesionUsuarioCerrarPantalla]", listaParametros)

    End Function

    Public Function LimpiarSesionUsuarioCerrarPantalla_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = SesionID
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_LimpiarSesionUsuarioCerrarPantalla_SoloConsulta]", listaParametros)

    End Function


    Public Function GuardarProyeccion(ByVal NivelSeleccion As Integer, ByVal PedidoSICY As String, ByVal CodigoPartida As String, ByVal Lote As Integer, ByVal AñoLote As Integer, ByVal NaveLote As Integer, ByVal CodigoAtado As String, ByVal CodigoPar As String, ByVal TomarInventario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NivelSeleccion"
        parametro.Value = NivelSeleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoPartida"
        parametro.Value = CodigoPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AñoLote"
        parametro.Value = AñoLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveLote"
        parametro.Value = NaveLote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoAtado"
        parametro.Value = CodigoAtado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CodigoPar"
        parametro.Value = CodigoPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TomarInventario"
        parametro.Value = TomarInventario
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ActualizarDatosPorProyectar]", listaParametros)

    End Function

    Public Function GenerarEncabezadoOrdenesTrabajo(ByVal SesionUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionProyeccion"
        parametro.Value = SesionUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_InsertarOT_Y_Pares]", listaParametros)

    End Function

    Public Function GenerarDetallesOrdenesTrabajo(ByVal SesionUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@UsuarioProyectando"
        parametro.Value = SesionUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_GeneraDetallesOrdenTrabajo]", listaParametros)

    End Function

    Public Function EliminarSesionUsuario(ByVal SesionUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@UsuarioProyectando"
        parametro.Value = SesionUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_EliminarSesionActivaPorUsuario]", listaParametros)

    End Function

    Public Function RelacionarOTPares(ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@UsuarioProyectando"
        parametro.Value = UsuarioID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ActualizarOT_TmpDocenasPares]", listaParametros)

    End Function

    Public Function ComprobarDatosOcupados(ByVal SesionID As Integer, ByVal Filtros As Entidades.ProyeccionEntregas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionAnterior"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@StatusPedido"
        If String.IsNullOrEmpty(Filtros.PstatusPedido) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PstatusPedido
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PlazoPago"
        If String.IsNullOrEmpty(Filtros.PplazoPago) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PplazoPago
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        If String.IsNullOrEmpty(Filtros.PpedidoSAY) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PpedidoSAY
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        If String.IsNullOrEmpty(Filtros.PpedidoSICY) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PpedidoSICY
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        If String.IsNullOrEmpty(Filtros.Pcliente) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcliente
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TiendaEmbarqueCedis"
        If String.IsNullOrEmpty(Filtros.PtiendaEmbarqueCedis) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PtiendaEmbarqueCedis
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AtnClientes"
        If String.IsNullOrEmpty(Filtros.PatnClientes) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PatnClientes
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AgenteVentas"
        If String.IsNullOrEmpty(Filtros.PagenteVentas) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PagenteVentas
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        If String.IsNullOrEmpty(Filtros.Pmarca) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pmarca
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        If String.IsNullOrEmpty(Filtros.Pcoleccion) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcoleccion
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        If String.IsNullOrEmpty(Filtros.Pmodelo) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pmodelo
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Piel"
        If String.IsNullOrEmpty(Filtros.Ppiel) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Ppiel
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Color"
        If String.IsNullOrEmpty(Filtros.Pcolor) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcolor
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        If String.IsNullOrEmpty(Filtros.Pcorrida) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcorrida
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarClientesSiRequierenCita"
        If String.IsNullOrEmpty(Filtros.PmostrarClientesCita) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PmostrarClientesCita
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarClientesNoRequierenCita"
        If String.IsNullOrEmpty(Filtros.PmostrarClientesNoCita) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PmostrarClientesNoCita
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaEntregaInicio"
        If String.IsNullOrEmpty(Filtros.PfechaEntregaInicio) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PfechaEntregaInicio
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaEntregaFin"
        If String.IsNullOrEmpty(Filtros.PfechaEntregaFin) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PfechaEntregaFin
        End If
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ValidarClienteOcupado]", listaParametros)

    End Function

    Public Function ComprobarDatosOcupados_SoloConsulta(ByVal SesionID As Integer, ByVal Filtros As Entidades.ProyeccionEntregas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionAnterior"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@StatusPedido"
        If String.IsNullOrEmpty(Filtros.PstatusPedido) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PstatusPedido
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PlazoPago"
        If String.IsNullOrEmpty(Filtros.PplazoPago) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PplazoPago
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSAY"
        If String.IsNullOrEmpty(Filtros.PpedidoSAY) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PpedidoSAY
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        If String.IsNullOrEmpty(Filtros.PpedidoSICY) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PpedidoSICY
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cliente"
        If String.IsNullOrEmpty(Filtros.Pcliente) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcliente
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TiendaEmbarqueCedis"
        If String.IsNullOrEmpty(Filtros.PtiendaEmbarqueCedis) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PtiendaEmbarqueCedis
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AtnClientes"
        If String.IsNullOrEmpty(Filtros.PatnClientes) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PatnClientes
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AgenteVentas"
        If String.IsNullOrEmpty(Filtros.PagenteVentas) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PagenteVentas
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marca"
        If String.IsNullOrEmpty(Filtros.Pmarca) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pmarca
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Coleccion"
        If String.IsNullOrEmpty(Filtros.Pcoleccion) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcoleccion
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Modelo"
        If String.IsNullOrEmpty(Filtros.Pmodelo) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pmodelo
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Piel"
        If String.IsNullOrEmpty(Filtros.Ppiel) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Ppiel
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Color"
        If String.IsNullOrEmpty(Filtros.Pcolor) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcolor
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Corrida"
        If String.IsNullOrEmpty(Filtros.Pcorrida) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.Pcorrida
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarClientesSiRequierenCita"
        If String.IsNullOrEmpty(Filtros.PmostrarClientesCita) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PmostrarClientesCita
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MostrarClientesNoRequierenCita"
        If String.IsNullOrEmpty(Filtros.PmostrarClientesNoCita) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PmostrarClientesNoCita
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaEntregaInicio"
        If String.IsNullOrEmpty(Filtros.PfechaEntregaInicio) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PfechaEntregaInicio
        End If
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaEntregaFin"
        If String.IsNullOrEmpty(Filtros.PfechaEntregaFin) = True Then
            parametro.Value = String.Empty
        Else
            parametro.Value = Filtros.PfechaEntregaFin
        End If
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ValidarClienteOcupado_SoloConsulta]", listaParametros)

    End Function

    Public Function ConsultaParesApartadosPorConfirmar(ByVal SesionID As Integer, ByVal ModoConsulta As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ModoConsulta"
        parametro.Value = ModoConsulta
        parametro.DbType = DbType.Boolean
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ConsultaApartadosPorConfirmar]", listaParametros)

    End Function

    Public Function ConsultaParesEnReproceso(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesReproceso]", listaParametros)

    End Function
    Public Function ConsultaParesEnReproceso_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesReproceso_SoloConsulta]", listaParametros)

    End Function

    Public Function ConsultaParesProgramacionProgramado(ByVal SesionID As Integer, ByVal ModoConsulta As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModoConsulta"
        parametro.DbType = DbType.Boolean
        parametro.Value = ModoConsulta
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesProgramacionProgramados]", listaParametros)
    End Function

    Public Function ConsultaClientesBloqueados(ByVal SesionID As Integer, ByVal ModoConsulta As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModoConsulta"
        parametro.Value = ModoConsulta
        parametro.DbType = DbType.Boolean
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ClientesBloqueados]", listaParametros)

    End Function

    Public Function ConsultaParesBloquedos(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesBloqueados]", listaParametros)

    End Function

    Public Function ConsultaParesBloquedos_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesBloqueados_SoloConsulta]", listaParametros)

    End Function

    Public Function ConsultaParesEnProceso(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesEnProceso]", listaParametros)

    End Function

    Public Function ConsultaParesEnProceso_SoloConsulta(ByVal SesionID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Consulta_ParesEnProceso_SoloConsulta]", listaParametros)

    End Function

    Public Function ProyectarLotesCompletos(ByVal PedidoSICY As Integer, ByVal TomarInventario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@PedidoSICY"
        parametro.Value = PedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TomarInventario"
        parametro.Value = TomarInventario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ActualizarDatosPorProyectar_LotesCompletos]", listaParametros)

    End Function

    Public Sub GeneracionDatosProyeccionEntregasCargarSesionAnterior(usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioNombre"
        parametro.Value = usuarioNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = sesionAnterior
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_GenerarDatosPartidasParaProyectarNoLimpiarSesion", listaParametros)

    End Sub

    Public Sub GeneracionDatosProyeccionEntregasCargarSesionAnterior_SoloConsulta(usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioNombre"
        parametro.Value = usuarioNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = sesionAnterior
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_GenerarDatosPartidasParaProyectarNoLimpiarSesion_SoloConsulta", listaParametros)

    End Sub

    Public Function ConsultaProyeccionPorNivel_Pedido(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Pedido", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_Pedido_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cedis"
        parametro.Value = consultaNivel.Pcedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Pedido_SoloConsulta_Divison", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_Partida(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Partida]", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_Partida_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Partida_SoloConsulta]", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_PartidaPedido(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "IdPedidoSICY"
        'parametro.Value = consultaNivel.PidPedidoSICY
        'listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Partida_Pedidos]", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_PartidaPedido_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "IdPedidoSICY"
        'parametro.Value = consultaNivel.PidPedidoSICY
        'listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Partida_Pedidos_SoloConsulta]", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_Lote(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = consultaNivel.PidPartida
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Lotes]", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_Lote_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = consultaNivel.PidPartida
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Lotes_SoloConsulta]", listaParametros)

    End Function


    Public Function ConsultaProyeccionPorNivel_Atado(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = consultaNivel.PidPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lote"
        parametro.Value = consultaNivel.Plote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = consultaNivel.Paño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveSicyID"
        parametro.Value = consultaNivel.PnaveSicyID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Atados]", listaParametros)

    End Function

    Public Function ConsultaProyeccionPorNivel_Atado_SoloConsulta(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = consultaNivel.PidPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lote"
        parametro.Value = consultaNivel.Plote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = consultaNivel.Paño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveSicyID"
        parametro.Value = consultaNivel.PnaveSicyID
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Atados_SoloConsulta]", listaParametros)

    End Function


    Public Function ConsultaProyeccionPorNivel_Pares(consultaNivel As Entidades.ProyeccionEntregasPorNivel) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "UsuarioConsultaId"
        parametro.Value = consultaNivel.PusuarioConsultaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPedidoSICY"
        parametro.Value = consultaNivel.PidPedidoSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdPartida"
        parametro.Value = consultaNivel.PidPartida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lote"
        parametro.Value = consultaNivel.Plote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Año"
        parametro.Value = consultaNivel.Paño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveSicyID"
        parametro.Value = consultaNivel.PnaveSicyID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Atado"
        parametro.Value = consultaNivel.Patado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.[SP_Proyeccion_ConsultaPantallaProyeccionPorNivel_Pares]", listaParametros)

    End Function


    Public Sub GeneracionDatosProyeccionEntregasSinFiltros(colaboradorId As Integer, usuarioId As Integer, usuarioNombre As String, sesionAnterior As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioNombre"
        parametro.Value = usuarioNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SesionAnterior"
        parametro.Value = sesionAnterior
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_GenerarDatosPartidasParaProyectar_SinFiltros]", listaParametros)

    End Sub

    Public Function consultarSumatoriaAtados(ByVal codigoAtado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@CodigoAtado"
        parametro.Value = codigoAtado
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_SumatoriaPorTallas_Atados]", listaParametros)
    End Function

    Public Function consultarSumatoriaLotes(ByVal Lote As Integer, ByVal Nave As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_SumatoriaPorTallas_Lotes]", listaParametros)
    End Function

    Public Function GenerarOrdenesTrabajoCompletas(ByVal SesionUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@SesionProyeccion"
        parametro.Value = SesionUsuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Proyeccion_Generar_OT_Work]", listaParametros)

    End Function

End Class
