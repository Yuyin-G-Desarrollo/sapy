Imports Contabilidad.Datos

Public Class TarjetaAlmacenBU

    Public Function consultaEmpresas() As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.consultaEmpresas()
    End Function

    Public Function obtenerAniosEmpresa(ByVal empresaId As Int32) As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.obtenerAniosEmpresa(empresaId)
    End Function

    Public Function obtenerProductosEmpresa(ByVal empresaId As Int32) As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.obtenerProductosEmpresa(empresaId)
    End Function

    Public Function obtenerTarjetaAlmacen(ByVal empresaId As Integer, ByVal anio As Integer, ByVal mesIni As Integer, ByVal mesFin As Integer, ByVal productoId As String) As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.obtenerTarjetaAlmacen(empresaId, anio, mesIni, mesFin, productoId)
    End Function

    Public Function obtenerInventario(ByVal empresaId As Integer, ByVal anio As Integer, ByVal mesIni As Integer, ByVal mesFin As Integer, ByVal productoId As String) As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.obtenerInventario(empresaId, anio, mesIni, mesFin, productoId)
    End Function

    Public Function consultaConfigPrecioVenta() As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.consultaConfigPrecioVenta()
    End Function

    Public Function actualizarConfigPrecioVenta(ByVal configuracionId As Integer, ByVal limiteInferior As Double, ByVal limiteSuperior As Double) As String
        Dim objDa As New TarjetaAlmacenDA
        Dim strResult As String = String.Empty
        Dim dtResult As New DataTable

        dtResult = objDa.actualizarConfigPrecioVenta(configuracionId, limiteInferior, limiteSuperior)
        If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
            strResult = dtResult.Rows(0).Item("mensaje")
        End If

        Return strResult
    End Function

    Public Function ListadoParametrosReportes(tipo_busqueda As Integer, idUsuario As Integer, empresaId As Integer) As DataTable
        Dim objDA As New TarjetaAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametrosReportes(tipo_busqueda, idUsuario, empresaId)
        Return tabla
    End Function

    Public Function validarPorcentajePrecioVenta(ByVal tarjetaId As Integer) As String
        Dim objDa As New TarjetaAlmacenDA
        Dim strResult As String = String.Empty
        Dim dtResult As New DataTable

        dtResult = objDa.validarPorcentajePrecioVenta(tarjetaId)
        If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
            strResult = dtResult.Rows(0).Item("mensaje")
        End If

        Return strResult
    End Function

    Public Function obtenerConfigPorcentaje(ByVal empresaId As Integer) As DataTable
        Dim objDa As New TarjetaAlmacenDA
        Return objDa.obtenerConfigPorcentaje(empresaId)
    End Function

End Class
