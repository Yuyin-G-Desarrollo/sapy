Imports Programacion.Datos
Imports Entidades
Public Class Programacion_MapaOcupacionBU

    Public Function consultaMapaOcupacion(ByVal GrupoNaves As String, ByVal Año As Integer, ByVal SemanaInicio As Integer, ByVal SemanaFin As Integer, ByVal AñoFin As Integer) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultaMapaOcupacion(GrupoNaves, Año, SemanaInicio, SemanaFin, AñoFin)
    End Function
    Public Function consultaDetalleOcupacionSemanal(ByVal Año As String, ByVal Semana As String, ByVal IdNave As String) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultaDetalleOcupacionSemanal(Año, Semana, IdNave)
    End Function

    Public Function consultaDetalleOcupacionSemanalConFechas(ByVal Año As String, ByVal Semana As String, ByVal IdNave As String, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultaDetalleOcupacionSemanalConFechas(Año, Semana, IdNave, FechaInicio, FechaFin)
    End Function
    Public Function consultarBitacoraErrores(ByVal Año As Integer) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultarBitacoraErrores(Año)
    End Function
    Public Function consultarBitacoraMovimientosManuales(ByVal Año As Integer) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultarBitacoraMovimientosManuales(Año)
    End Function

    Public Function MoverDetalleOcupacionSemanal(ByVal XML As String) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.MoverDetalleOcupacionSemanal(XML)
    End Function

    Public Function MoverDetalleOcupacionSemanal(ByVal XML As String, otro As Boolean) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.MoverDetalleOcupacionSemanal(XML, otro)
    End Function

    Public Function ColocarPartidaEnSemanas(ByVal productoEstiloId As Integer, ByVal pedidoSayId As Integer, ByVal partida As Integer, ByVal paresColocar As Integer, ByVal usuarioCreoId As Integer) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.ColocarPartidaEnSemanas(productoEstiloId, pedidoSayId, partida, paresColocar, usuarioCreoId)
    End Function
    Public Sub EditarTamañoLote(ByVal tamañoLote As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.EditarTamañoLote(tamañoLote)
    End Sub
    Public Function ConsultarTamañoLoteActual() As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.ConsultarTamañoLoteActual()
    End Function
    Public Sub CerrarSemana(ByVal XML As String, ByVal año As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.CerrarSemana(XML, año)
    End Sub
    Public Function ConsultarUltimaSemanaAño(ByVal año As Integer) As Integer
        Dim objDa As New Programacion_MapaOcupacionDA
        Dim tabla As DataTable = objDa.ConsultarUltimaSemanaAño(año)
        If (tabla.Rows.Count > 0) Then Return tabla.Rows.Item(0).Item(0).ToString()
        Return 1
    End Function
    Public Sub EditarCapacidadesSemana(ByVal XML As String, ByVal año As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.EditarCapacidadesSemana(XML, año)
    End Sub
    Public Sub EditarATRSemana(ByVal XML As String, ByVal año As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.EditarATRSemana(XML, año)
    End Sub
    Public Function consultaSPID_Encabezados(ByVal spid As Integer) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultaSPID_Encabezados(spid)
    End Function

    Public Function consultarBitacoraCancelaciones(ByVal filtrosCancelaciones As BitacoraCancelaciones) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultarBitacoraCancelaciones(filtrosCancelaciones)
    End Function
    Public Sub AutorizarPlan(ByVal XML As String, ByVal año As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.AutorizarPlan(XML, año)
    End Sub
    Public Sub ReAbrirPlan(ByVal XML As String, ByVal año As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.ReAbrirPlan(XML, año)
    End Sub
    Public Function SemanaNavePlanNoAutorizado(ByVal Semana As Integer, ByVal año As Integer, ByVal NaveIdSay As Integer) As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.SemanaNavePlanNoAutorizado(Semana, año, NaveIdSay)
    End Function
    Public Function consultaPlanesAutorizados() As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultaPlanesAutorizados()
    End Function

    Public Function ObtenerParesColocadosPorTalla(ByVal FNave As String, ByVal FColeccion As String, ByVal FModelo As String, ByVal FPielColor As String, ByVal FCorrida As String, ByVal FCliente As String, ByVal FPedidoSAY As String,
                                                  ByVal FiltroFecha As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objDA As New Programacion_MapaOcupacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerParesColocadosPorTalla(FNave, FColeccion, FModelo, FPielColor, FCorrida, FCliente, FPedidoSAY,
                                                    FiltroFecha, FechaInicio, FechaFin)
        Return Tabla
    End Function

    Public Sub InsertarBitacoraDesprogramados(detalle As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.InsertarBitacoraDesprogramados(detalle)
    End Sub

    Public Function consultarBitacoraDesprogramadas() As DataTable
        Dim objDa As New Programacion_MapaOcupacionDA
        Return objDa.consultarBitacoraDesprogramadas()
    End Function

    Public Function ObtenerNuevaFechaEntrega(ByVal semanaNueva As Integer, ByVal año As Integer, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Programacion_MapaOcupacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerNuevaFechaEntrega(semanaNueva, año, NaveID)
        Return Tabla
    End Function

    Public Function MoverApartadosCancelados(ByVal XML As String) As DataTable
        Dim objDA As New Programacion_MapaOcupacionDA
        Dim Tabla As New DataTable
        Tabla = objDA.MoverApartadosCancelados(XML)
        Return Tabla
    End Function

    Public Sub EditarCapacidadesSemanaGlobal(Naves As String, Año As Integer, capacidad As Integer)
        Dim objDa As New Programacion_MapaOcupacionDA
        objDa.EditarCapacidadesSemanaGlobal(Naves, Año, capacidad)
    End Sub

    Public Function ValidarCierreNave(ByVal NaveID As Integer) As Integer
        Dim objDa As New Programacion_MapaOcupacionDA
        Dim Tabla As New DataTable

        Tabla = objDa.ValidarCierreNave(NaveID)

        Dim SePuedeCerrar As Integer = Tabla.Rows(0)(0)

        Return SePuedeCerrar
    End Function

End Class
