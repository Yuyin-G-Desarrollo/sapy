Public Class PedidosMuestrasOP
    ''
    Public Function VerListaPedidosMuestrasOP(ByVal Accion As Integer, ByVal idUsuario As Integer, Optional ByVal Nave As Integer = 0, Optional ByVal FechaIni As String = "", Optional ByVal FechaFin As String = "") As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return AsuntosPedidosMuestrasDA.VerListaPedidosMuestrasOP(Accion, idUsuario, Nave, FechaIni, FechaFin)
    End Function

    Public Function VerListaComboEstatus() As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return AsuntosPedidosMuestrasDA.VerListaComboEstatus
    End Function
    Public Function VerListaComboNaves(Optional ByVal idUsuario As Integer = 0) As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return AsuntosPedidosMuestrasDA.VerListaComboNaves(idUsuario)
    End Function

    Public Function VerListaComboImnpresorasZebra() As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return AsuntosPedidosMuestrasDA.VerListaComboImnpresorasZebra
    End Function

    Public Function ObtenerComandoImpresorasZebra(ByVal idImpresora As Integer) As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return AsuntosPedidosMuestrasDA.ObtenerComandoImpresorasZebra(idImpresora)
    End Function


    Public Function AltaPedidoMuestraOP(ByVal entidadOrdenesProduccionMuestras As Entidades.OrdenesProduccionMuestras) As DataTable '' CAMBIOS OAMB (22/05/2024) - El SP devuelve el id de la OP generada y la nave.
        Dim PedidosMuestrasOPDatos As New Programacion.Datos.PedidosMuestrasOPDA
        Return PedidosMuestrasOPDatos.AltaPedidoMuestraOP(entidadOrdenesProduccionMuestras)
    End Function

    Public Sub EnviaPedidoMuestraOP(ByVal entidadOrdenesProduccionMuestras As Entidades.OrdenesProduccionMuestras)
        Dim PedidosMuestrasOPDatos As New Programacion.Datos.PedidosMuestrasOPDA
        PedidosMuestrasOPDatos.EnviaPedidoMuestraOP(entidadOrdenesProduccionMuestras)
    End Sub

    Public Sub Apartar(ByVal entidadOrdenesProduccionMuestras As Entidades.OrdenesProduccionMuestras)
        Dim PedidosMuestrasOPDatos As New Programacion.Datos.PedidosMuestrasOPDA
        PedidosMuestrasOPDatos.Apartar(entidadOrdenesProduccionMuestras)
    End Sub
    Public Function consultaCorreosGeneraOP(ByVal ClaveEnvio As String, ByVal idNave As Integer) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.consultaCorreosGeneraOP(ClaveEnvio, idNave)
    End Function
    Public Function VerListaEtiquetasMuestrasOP(ByVal idOrdenProduccion As Integer, ByVal Accion As Integer, ByVal TipoImpresion As String) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.VerListaEtiquetasMuestrasOP(idOrdenProduccion, Accion, TipoImpresion)
    End Function
    Public Function VerListaEtiquetasMuestras(ByVal piezaId As String, ByVal Accion As Integer, ByVal TipoImpresion As String) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.VerListaEtiquetasMuestras(piezaId, Accion, TipoImpresion)
    End Function

    Public Function EsEncargadoDeNave(ByVal idUsuario As Integer) As Boolean
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.EsEncargadoDeNave(idUsuario)
    End Function
    Public Function VerCantidadPendiente(ByVal unidadmedidaid As Integer, ByVal productoestiloid As Integer, ByVal pedidoid As Integer, ByVal talla As String, ByVal cantidad As Integer) As Integer
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.VerCantidadPendiente(unidadmedidaid, productoestiloid, pedidoid, talla, cantidad)
    End Function
    Public Function consultaInventarioMuestras(ByVal Accion As Integer, ByVal Modelo As String) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.consultaInventarioMuestras(Accion, Modelo)
    End Function
    Public Function ActulizarOrdenesProduccionMuestra(ByVal xmlOrdenes As String) As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        AsuntosPedidosMuestrasDA.ActulizaOrdenesProduccionMuestra(xmlOrdenes)
    End Function

    Public Function VerListaPedidosMuestrasOPAutorizadoProdBloq(ByVal Accion As Integer, ByVal idUsuario As Integer, Optional ByVal Nave As Integer = 0, Optional ByVal FechaIni As String = "", Optional ByVal FechaFin As String = "") As DataTable
        Dim AsuntosPedidosMuestrasDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return AsuntosPedidosMuestrasDA.VerListaPedidosMuestrasOPAutorizadoProdBloq(Accion, idUsuario, Nave, FechaIni, FechaFin)
    End Function

    Public Function verListaInventariosPorEtiqueta(ByVal Etiquetas As String) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.verListaInventariosPorEtiquetaDatos(Etiquetas)
    End Function

    Public Function obtenerNaveReproceso(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.obtenerNaveReproceso(usuarioId)
    End Function

    Public Function obtenerReporteMuestrasReprocesoPorNave(ByVal usuarioId As Integer, ByVal naveId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Return objDA.obtenerReporteMuestrasReprocesPorNave(usuarioId, naveId)
    End Function



    '' --------------------------------------------------- AdministradorOPpedidosMuestrasForm --------------------------------------------------- ''

    Public Function GenerarColocacionPedidosMuestras(ByVal CadenaXML As String, ByVal FechaProgramacionPropuesta As String) As DataSet
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Dim dsColocacionPedidosMuestras As New DataSet

        Try
            dsColocacionPedidosMuestras = objDA.GenerarColocacionPedidosMuestras(CadenaXML, FechaProgramacionPropuesta)
        Catch ex As Exception
            Throw ex
        End Try

        Return dsColocacionPedidosMuestras
    End Function


    Public Sub RegistrarSesionActualMuestrasFormulario(ByVal UsuarioId As Integer, ByVal NombreFormulario As String)
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA

        Try
            objDA.RegistrarSesionActualMuestrasFormulario(UsuarioId, NombreFormulario)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ConsultarSesionActualMuestrasFormulario(ByVal NombreFormulario As String) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Dim dtSesionActual As New DataTable

        Try
            dtSesionActual = objDA.ConsultarSesionActualMuestrasFormulario(NombreFormulario)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtSesionActual
    End Function

    Public Sub CerrarSesionActualMuestrasFormulario(ByVal UsuarioId As Integer, ByVal NombreFormulario As String)
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA

        Try
            objDA.CerrarSesionActualMuestrasFormulario(UsuarioId, NombreFormulario)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ConsultarNavesProduccion() As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Dim dtSesionActual As New DataTable

        Try
            dtSesionActual = objDA.ConsultarNavesProduccion()
        Catch ex As Exception
            Throw ex
        End Try

        Return dtSesionActual
    End Function


    Public Function ConsultarReporteFabricacionMuestrasOP(ByVal OrdenesProduccion As String, ByVal NaveId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.PedidosMuestrasOPDA
        Dim dtSesionActual As New DataTable

        Try
            dtSesionActual = objDA.ConsultarReporteFabricacionMuestrasOP(OrdenesProduccion, NaveId)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtSesionActual
    End Function

    '' --------------------------------------------------- AdministradorOPpedidosMuestrasForm --------------------------------------------------- ''

End Class
