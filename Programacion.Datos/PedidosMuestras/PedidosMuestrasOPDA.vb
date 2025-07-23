Imports System.Data.SqlClient

Public Class PedidosMuestrasOPDA
    Public Function VerListaPedidosMuestrasOP(ByVal Accion As Integer, ByVal idUsuario As Integer, Optional ByVal Nave As Integer = 0, Optional ByVal FechaIni As String = "", Optional ByVal FechaFin As String = "") As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idUsuario"
        ParametroParaLista.Value = idUsuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idNave"
        ParametroParaLista.Value = IIf(Nave = 0, DBNull.Value, Nave)
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaInicio"
        ParametroParaLista.Value = IIf(FechaIni = "", DBNull.Value, FechaIni)
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaFin"
        ParametroParaLista.Value = IIf(FechaFin = "", DBNull.Value, FechaFin)
        ListaParametros.Add(ParametroParaLista)


        Return operacion.EjecutarConsultaSP("Programacion.SP_Ventas_ConsultarOPPedidosMuestras", ListaParametros)
    End Function

    Public Function VerListaEtiquetasMuestrasOP(ByVal idOrdenProduccion As Integer, ByVal Accion As Integer, ByVal TipoImpresion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@OrdenProduccionId"
        ParametroParaLista.Value = idOrdenProduccion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@TipoImpresion"
        ParametroParaLista.Value = TipoImpresion
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Programacion_EtiquetasMuestrasOP", ListaParametros)
    End Function


    Public Function VerListaEtiquetasMuestras(ByVal piezaId As String, ByVal Accion As Integer, ByVal TipoImpresion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pemp_piezaid"
        ParametroParaLista.Value = piezaId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@TipoImpresion"
        ParametroParaLista.Value = TipoImpresion
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Programacion_EtiquetasMuestras", ListaParametros)
    End Function


    Public Function VerListaComboEstatus() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Return operacion.EjecutarConsultaSP("Programacion.SP_Ventas_ConsultarPedidosMuestrasOPEstatus", ListaParametros)
    End Function

    Public Function VerListaComboNaves(Optional ByVal idUsuario As Integer = 0) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idUsuario"
        ParametroParaLista.Value = IIf(idUsuario = 0, DBNull.Value, idUsuario)
        ListaParametros.Add(ParametroParaLista)
        Return operacion.EjecutarConsultaSP("Programacion.SP_Ventas_ConsultarPedidosMuestrasOPNaves", ListaParametros)
    End Function

    Public Function VerCantidadPendiente(ByVal unidadmedidaid As Integer, ByVal productoestiloid As Integer, ByVal pedidoid As Integer, ByVal talla As String, ByVal cantidad As Integer) As Integer

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@pdetorm_unidadmedidaid"
        ParametroParaLista.Value = unidadmedidaid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@pdetorm_productoestiloid"
        ParametroParaLista.Value = productoestiloid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@pdetorm_pedidoid"
        ParametroParaLista.Value = pedidoid
        ListaParametros.Add(ParametroParaLista)



        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@pdetorm_talla"
        ParametroParaLista.Value = talla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@cantidad"
        ParametroParaLista.Value = cantidad
        ListaParametros.Add(ParametroParaLista)

        Dim dt As DataTable
        dt = operacion.EjecutarConsultaSP("Programacion.SP_Ventas_ConsultarCantidadPendientesMuestrasXEnviar", ListaParametros)
        Return CInt(dt.Rows(0).Item("cantidad"))

    End Function

    Public Function EsEncargadoDeNave(ByVal idUsuario As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idUsuario"
        ParametroParaLista.Value = IIf(idUsuario = 0, DBNull.Value, idUsuario)
        ListaParametros.Add(ParametroParaLista)
        Dim dt As DataTable
        dt = operacion.EjecutarConsultaSP("Programacion.SP_Ventas_ConsultarSiEsEncagardoDeNave", ListaParametros)

        If dt.Rows(0).Item("EsEncargado") = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AltaPedidoMuestraOP(ByVal entidadOrdenesProduccionMuestras As Entidades.OrdenesProduccionMuestras) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_colaboradorencargadoid"
        ParametroParaLista.Value = DBNull.Value
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_naveid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_naveid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_cantsolicitada"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_cantsolicitada
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_productoestiloid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_productoestiloid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_pedidoid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_pedidoid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter   '' CAMBIOS OAMB (22/05/2024) - Agregamos el id de la partida del pedido seleccionado.
        ParametroParaLista.ParameterName = "pdetm_partidaid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetm_partidaid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_unidadmedidaid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_unidadmedidaid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_fechacorte"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_fechacorte.ToString("dd/MM/yyyy")
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_cantpendiente"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_cantsolicitada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_talla"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_talla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_usuariocreoid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_usuariocreoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_fechacreacion"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_fechacreacion
        ListaParametros.Add(ParametroParaLista)


        Return operacion.EjecutarConsultaSP("Ventas.SP_Programacion_GerenearOPPedidosMuestras", ListaParametros)
    End Function

    Public Function consultaCorreosGeneraOP(ByVal ClaveEnvio As String, ByVal idNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "ClaveEnvio"
        parametro.Value = ClaveEnvio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idNave"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Programacion.SP_Programacion_ConsultaDatosCorreoPedidosMuestras", listaParametros)
    End Function

    Public Function consultaInventarioMuestras(ByVal Accion As Integer, ByVal Modelo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "Accion"
        parametro.Value = Accion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_ReporteInventarioMuestras", listaParametros)
    End Function

    Public Sub EnviaPedidoMuestraOP(ByVal entidadOrdenesProduccionMuestras As Entidades.OrdenesProduccionMuestras)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_pedidoid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_pedidoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_productoestiloid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_productoestiloid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_unidadmedidaid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_unidadmedidaid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_talla "
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_talla
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "cantidad"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_cantsolicitada
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_Programacion_EnvioAcomercializadora", ListaParametros)
    End Sub

    Public Sub Apartar(ByVal entidadOrdenesProduccionMuestras As Entidades.OrdenesProduccionMuestras)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_pedidoid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_pedidoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_productoestiloid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_productoestiloid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_unidadmedidaid"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_unidadmedidaid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "pdetorm_talla "
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.pdetorm_talla
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "cantidad"
        ParametroParaLista.Value = entidadOrdenesProduccionMuestras.Apartados
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Ventas.SP_Editar_Status_ApartarPedidosMuestrasDetalles", ListaParametros)
    End Sub

    Public Function VerListaComboImnpresorasZebra() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Return operacion.EjecutarConsultaSP("Programacion.SP_ObtenerListaDeImpresorasZebra", ListaParametros)
    End Function

    Public Function ObtenerComandoImpresorasZebra(ByVal idImpresora As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idImpresora"
        ParametroParaLista.Value = idImpresora
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_ObtenerComandoDeImpresora", ListaParametros)
    End Function

    Public Sub ActulizaOrdenesProduccionMuestra(ByVal xmlOrdenes As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "XmlOrdenes"
        ParametroParaLista.Value = xmlOrdenes
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("[Programacion].[SP_ActualizaOrdenProduccionMuestra]", ListaParametros)
    End Sub

    Public Function VerListaPedidosMuestrasOPAutorizadoProdBloq(ByVal Accion As Integer, ByVal idUsuario As Integer, Optional ByVal Nave As Integer = 0, Optional ByVal FechaIni As String = "", Optional ByVal FechaFin As String = "") As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Accion"
        ParametroParaLista.Value = Accion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idUsuario"
        ParametroParaLista.Value = idUsuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idNave"
        ParametroParaLista.Value = IIf(Nave = 0, DBNull.Value, Nave)
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaInicio"
        ParametroParaLista.Value = IIf(FechaIni = "", DBNull.Value, FechaIni)
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "FechaFin"
        ParametroParaLista.Value = IIf(FechaFin = "", DBNull.Value, FechaFin)
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Ventas_ConsultarOPPedidosMuestrasAutorizadoProduccionBloqueados]", ListaParametros)

    End Function

    Public Function verListaInventariosPorEtiquetaDatos(ByVal Etiquetas As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "Etiquetas"
        parametros.Value = Etiquetas
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_ReporteInventarioMuestras_EscaneoMasivo]", listaParametros)

    End Function

    Public Function obtenerNaveReproceso(ByVal usuarioId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim parametros As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametros.ParameterName = "@idUsuario"
        parametros.Value = usuarioId
        listaParametros.Add(parametros)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_Ventas_ConsultarNave_Reproceso]", listaParametros)
    End Function
    Public Function obtenerReporteMuestrasReprocesPorNave(ByVal idusuario As Integer, ByVal naveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idusuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_Ventas_ConsultarOPPedidosMuestras_NavesReproceso]", listaParametros)
    End Function



    '' --------------------------------------------------- AdministradorOPpedidosMuestrasForm --------------------------------------------------- ''

    Public Function GenerarColocacionPedidosMuestras(ByVal CadenaXML As String, ByVal FechaProgramacionPropuesta As String) As DataSet
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@CadenaXML", CadenaXML)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@FechaProgramacionPropuesta", FechaProgramacionPropuesta)
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSPDataSet("[Muestras].[SP_ProgramacionMuestras_GenerarColocacionPedidosMuestras]", listaparametros)
    End Function


    Public Function RegistrarSesionActualMuestrasFormulario(ByVal UsuarioId As Integer, ByVal NombreFormulario As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@UsuarioId", UsuarioId)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@NombreFormulario", NombreFormulario)
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Muestras].[SP_ProgramacionMuestras_RegistrarSesionMuestrasFormulario]", listaparametros)
    End Function


    Public Function ConsultarSesionActualMuestrasFormulario(ByVal NombreFormulario As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@NombreFormulario", NombreFormulario)
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Muestras].[SP_ProgramacionMuestras_ConsultarSesionMuestrasFormulario]", listaparametros)
    End Function


    Public Function CerrarSesionActualMuestrasFormulario(ByVal UsuarioId As Integer, ByVal NombreFormulario As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@UsuarioId", UsuarioId)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@NombreFormulario", NombreFormulario)
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Muestras].[SP_ProgramacionMuestras_CerrarSesionMuestrasFormulario]", listaparametros)
    End Function


    Public Function ConsultarNavesProduccion() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Muestras].[SP_ProgramacionMuestras_ConsultarNavesProduccion]", listaparametros)
    End Function


    Public Function ConsultarReporteFabricacionMuestrasOP(ByVal OrdenesProduccion As String, ByVal NaveId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@OrdenesProduccion", OrdenesProduccion)
        listaparametros.Add(parametro)

        parametro = New SqlParameter("@NaveId", NaveId)
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Muestras].[SP_ProgramacionMuestras_ConsultarReporteFabricacionMuestrasOPs]", listaparametros)
    End Function

    '' --------------------------------------------------- AdministradorOPpedidosMuestrasForm --------------------------------------------------- ''

End Class
