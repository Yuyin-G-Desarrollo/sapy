Imports Entidades
Imports System.Data.SqlClient
Public Class Programacion_MapaOcupacionDA

    Public Function consultaMapaOcupacion(ByVal GrupoNaves As String, ByVal Año As Integer, ByVal SemanaInicio As Integer, ByVal SemanaFin As Integer, ByVal AñoFin As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@GrupoNaves"
        parametro.Value = GrupoNaves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AñoInicio"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaInicio"
        parametro.Value = SemanaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AñoFin"
        parametro.Value = AñoFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SemanaFin"
        parametro.Value = SemanaFin
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ConsultaMapaOcupacion_prueba2Años]", listaParametros)

    End Function
    Public Function consultaDetalleOcupacionSemanal(ByVal Año As String, ByVal Semana As String, ByVal IdNave As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Semana"
        parametro.Value = Semana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = IdNave
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ConsultaDetalleMapaOcupacion_Prueba2Años]", listaParametros)

    End Function

    Public Function consultaDetalleOcupacionSemanalConFechas(ByVal Año As String, ByVal Semana As String, ByVal IdNave As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@IdNave", IdNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ConsultaDetalleMapaOcupacion_Prueba2Años_ConFechas]", listaParametros)

    End Function


    Public Function consultarBitacoraErrores(ByVal Año As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ConsultaBitacoraErrores]", listaParametros)

    End Function
    Public Function consultarBitacoraMovimientosManuales(ByVal Año As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ConsultaMovimientosManuales]", listaParametros)

    End Function

    Public Function MoverDetalleOcupacionSemanal(ByVal XML As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_MoverDetalleMapaOcupacion]", listaParametros)
    End Function

    Public Function MoverDetalleOcupacionSemanal(ByVal XML As String, otro As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_MoverDetalleMapaOcupacion_Bitacora]", listaParametros)
    End Function

    Public Function ColocarPartidaEnSemanas(ByVal productoEstiloId As Integer, ByVal pedidoSayId As Integer, ByVal partida As Integer, ByVal paresColocar As Integer, ByVal usuarioCreoId As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@productoEstiloId"
        parametro.Value = productoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@pedidoSAY"
        parametro.Value = pedidoSayId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@partida"
        parametro.Value = partida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@paresColocar"
        parametro.Value = paresColocar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioCreoId"
        parametro.Value = usuarioCreoId
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ColocaPartidasEnSemanas]", listaParametros)
    End Function
    Public Sub CerrarSemana(ByVal XML As String, ByVal año As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Programacion].[SP_CerrarSemana_MapaOcupacion]", listaParametros)

    End Sub
    Public Function ConsultarUltimaSemanaAño(ByVal año As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ConsultarUltimaSemana_MapaOcupacion]", listaParametros)

    End Function
    Public Sub EditarTamañoLote(ByVal tamañoLote As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@TamañoLote"
        parametro.Value = tamañoLote
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Programacion].[SP_EditarTamañoLote_MapaOcupacion]", listaParametros)

    End Sub
    Public Function ConsultarTamañoLoteActual() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ConsultarTamañoLoteActual_MapaOcupacion]", listaParametros)

    End Function
    Public Sub EditarCapacidadesSemana(ByVal XML As String, ByVal año As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Programacion].[SP_EditarCapacidadSemana_MapaOcupacion]", listaParametros)

    End Sub
    Public Sub EditarATRSemana(ByVal XML As String, ByVal año As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Programacion].[SP_EditarATRSemana_MapaOcupacion]", listaParametros)

    End Sub

    Public Function consultaSPID_Encabezados(ByVal spid As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "SPID"
        parametro.Value = spid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ConsultaMapaColocacionEncabezados_prueba2Años]", listaParametros)

    End Function

    Public Function consultarBitacoraCancelaciones(ByVal filtrosCancelaciones As BitacoraCancelaciones) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "nave"
        parametro.Value = filtrosCancelaciones.naveIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoSAY"
        parametro.Value = filtrosCancelaciones.pedidoIdSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "pedidoSICY"
        parametro.Value = filtrosCancelaciones.pedidoIdSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroFechaCancelacion"
        parametro.Value = filtrosCancelaciones.filtroFechaCancelacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCancelacionDe"
        parametro.Value = filtrosCancelaciones.fechaCancelacionDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaCancelacionA"
        parametro.Value = filtrosCancelaciones.fechaCancelacionA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtroSemanas"
        parametro.Value = filtrosCancelaciones.filtroSemanas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "añoSemanaLiberadaDe"
        parametro.Value = filtrosCancelaciones.añoSemanaLiberadaDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "semanaLiberadaDe"
        parametro.Value = filtrosCancelaciones.semanaLiberadaDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "añoSemanaLiberadaA"
        parametro.Value = filtrosCancelaciones.añoSemanaLiberadaA
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "semanaLiberadaA"
        parametro.Value = filtrosCancelaciones.semanaLiberadaA
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_Consulta_BitacoraRegistrosCancelados]", listaParametros)

    End Function
    Public Sub AutorizarPlan(ByVal XML As String, ByVal año As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Año"
        'parametro.Value = año
        'listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Programacion].[SP_MapaOcupacion_AutorizaPlan]", listaParametros)

    End Sub
    Public Sub ReAbrirPlan(ByVal XML As String, ByVal año As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = XML
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Año"
        'parametro.Value = año
        'listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("[Programacion].[SP_MapaOcupacion_ReabrirPlan]", listaParametros)

    End Sub
    Public Function SemanaNavePlanNoAutorizado(ByVal Semana As Integer, ByVal año As Integer, ByVal NaveIdSay As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Semana"
        parametro.Value = Semana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveIdSay"
        parametro.Value = NaveIdSay
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_MapaOcupacion_VerificaMovimientoManual]", listaParametros)

    End Function

    Public Function consultaPlanesAutorizados() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_MapaOcupacion_ObtieneSemanasPlanAutorizado]", listaParametros)

    End Function

    Public Function ObtenerParesColocadosPorTalla(ByVal FNave As String, ByVal FColeccion As String, ByVal FModelo As String, ByVal FPielColor As String, ByVal FCorrida As String, ByVal FCliente As String, ByVal FPedidoSAY As String,
                                                  ByVal FiltroFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("FNave", FNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FColeccion", FColeccion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FModelo", FModelo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FPielColor", FPielColor)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FCorrida", FCorrida)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FCliente", FCliente)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FPedidoSAY", FPedidoSAY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FiltroFecha", FiltroFecha)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("FechaFin", FechaFin)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ParesColocadosporTalla]", listaParametros)
    End Function

    Public Sub InsertarBitacoraDesprogramados(detalle As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@detalle",
                .Value = detalle
            },
            New SqlParameter With {
                .ParameterName = "@usuario",
                .Value = SesionUsuario.UsuarioSesion.PUserUsuarioid
            }
        }

        operaciones.EjecutarConsultaSP("[Programacion].[SP_MapaOcupacion_InsertarBitacoraDesprogramados]", listaParametros)
    End Sub

    Public Function consultarBitacoraDesprogramadas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Return operaciones.EjecutaConsulta("EXEC [Programacion].[SP_MapaOcupacion_ConsultaBitacoraDesprogramados]")

    End Function
    Public Function ObtenerNuevaFechaEntrega(ByVal semanaNueva As Integer, ByVal año As Integer, ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@SemanaNueva", semanaNueva)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ObtieneNuevaFechaEntrega]", listaParametros)
    End Function

    Public Sub EditarCapacidadesSemanaGlobal(Naves As String, Año As Integer, Capacidad As Integer)
        Dim operaciones As New Persistencia.OperacionesProcedimientos

        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "@Naves",
                .Value = Naves
            },
            New SqlParameter With {
                .ParameterName = "@Año",
                .Value = Año
            },
            New SqlParameter With {
                .ParameterName = "@Capacidad",
                .Value = Capacidad
            }
        }

        operaciones.EjecutarConsultaSP("[Programacion].[SP_EditarCapacidadSemana_MapaOcupacion_Global]", listaParametros)

    End Sub

    Public Function MoverApartadosCancelados(ByVal XML As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@XML", XML)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_MoverApartadosCancelados]", listaParametros)
    End Function

    Public Function ValidarCierreNave(ByVal NaveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ValidarCierreNave]", listaParametros)
    End Function

End Class
