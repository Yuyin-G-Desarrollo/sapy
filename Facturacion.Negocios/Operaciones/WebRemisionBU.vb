Public Class WebRemisionBU
    Public Function obtenerListadoRemisiones(ByVal usuarioId As Integer, ByVal sucursalId As Integer, ByVal estatus As String, ByVal filtro As String, ByVal opcFechas As Integer, ByVal filtroFecha1 As String, ByVal filtroFecha2 As String, ByVal orden As String) As DataTable
        Dim objDA As New Datos.WebRemisionDA
        Return objDA.obtenerListadoRemisiones(usuarioId, sucursalId, estatus, filtro, opcFechas, filtroFecha1, filtroFecha2, orden)
    End Function

    Public Function obtenerFolioSuc(ByVal sucursalId As Integer) As String
        Dim objDA As New Datos.WebRemisionDA
        Dim dtFolio As New DataTable

        dtFolio = objDA.obtenerFolioSuc(sucursalId)
        Return CStr(dtFolio.Rows(0)("Folio").ToString)
    End Function

    Public Function guardarRemision(ByVal remision As Entidades.Remision) As DataTable
        Dim objDA As New Datos.WebRemisionDA

        Return objDA.guardarRemision(remision)
    End Function

    Public Sub guardarProductoRemision(ByVal remisionId As Integer, ByVal lstConceptos As List(Of Entidades.Conceptos))
        Dim objDA As New Datos.WebRemisionDA
        objDA.guardarProductoRemision(remisionId, lstConceptos)
    End Sub

    Public Function obtenerRemision(ByVal remisionId As Integer) As Entidades.Remision
        Dim objDA As New Datos.WebRemisionDA
        Dim tabla As New DataTable
        Dim remision As New Entidades.Remision

        tabla = objDA.obtenerRemision(remisionId)
        For Each row As DataRow In tabla.Rows
            remision.RID = CInt(row("rem_id"))
            remision.RFolio = CInt(row("rem_folio"))
            remision.RFecha = CDate(row("rem_fecha"))
            remision.RAnio = CInt(row("rem_año"))
            remision.RSubtotal = CDbl(row("rem_subtotal"))
            remision.RTotal = CDbl(row("rem_total"))
            remision.RDescuento = CDbl(row("rem_descuento"))
            remision.RMotivoDescuento = CStr(row("rem_motivoDescuento"))
            remision.RPdf = CStr(row("rem_pdf"))
            remision.REstatus = CStr(row("rem_estatus"))
            remision.RObservacion = CStr(row("rem_observacion"))
            remision.RClienteId = CInt(row("rem_clienteId"))
            remision.RSucursalId = CInt(row("rem_sucursalId"))
            remision.RUsuarioId = CInt(row("rem_usuarioIdCreo"))
            remision.CUsuarioIdCancelacion = CInt(row("rem_usuarioIdCancelacion"))
            remision.RFechaCancelacion = CDate(row("rem_fechaCancelacion"))
            remision.RMotivoCancelacion = CStr(row("rem_motivoCancelacion"))
            remision.RReporteId = CInt(row("rem_reporteId"))
        Next

        Return remision
    End Function

    Public Function obtenerProductosRemision(ByVal remisionId As Integer) As List(Of Entidades.Conceptos)
        Dim objDA As New Datos.WebRemisionDA
        Dim tabla As New DataTable
        Dim concepto As Entidades.Conceptos
        Dim lstConceptos As New List(Of Entidades.Conceptos)

        tabla = objDA.obtenerProductosRemision(remisionId)
        For Each row As DataRow In tabla.Rows
            concepto = New Entidades.Conceptos

            concepto.CProductoId = CInt(row("remprod_productoId"))
            concepto.CDescripcion = CStr(row("descripcion"))
            concepto.CUnidadId = CInt(row("remprod_unidadMedidaId"))
            concepto.CUnidad = CStr(row("unidadMedida"))
            concepto.CCantidad = CDbl(row("remprod_cantidad"))
            concepto.CValorUnitario = CDbl(row("remprod_valorUnitario"))
            concepto.CImporte = CDbl(row("remprod_importe"))

            lstConceptos.Add(concepto)
        Next

        Return lstConceptos
    End Function

    Public Function cancelarRemision(ByVal remision As Entidades.Remision) As Boolean
        Dim objDA As New Datos.WebRemisionDA
        Return objDA.cancelarRemision(remision)
    End Function
End Class
