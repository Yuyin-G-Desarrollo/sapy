Imports System.Data.SqlClient

Public Class WebRemisionDA
    Public Function obtenerListadoRemisiones(ByVal usuarioId As Integer, ByVal sucursalId As Integer, ByVal estatus As String, ByVal filtro As String, ByVal opcFechas As Integer, ByVal filtroFecha1 As String, ByVal filtroFecha2 As String, ByVal orden As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT row_number() OVER(ORDER BY r.rem_fechaCreacion " & orden & ") NUM, " & vbCrLf & _
                    "r.rem_id ID, " & vbCrLf & _
                    "ISNULL(r.rem_folio, '') REMISION, " & vbCrLf & _
                    "ISNULL(s.suc_nombre, '') SUCURSAL, " & vbCrLf & _
                    "ISNULL(c.cfac_razonsocial, '') CLIENTE, " & vbCrLf & _
                    "ISNULL(sum(rp.remprod_cantidad), 0) PARES, " & vbCrLf & _
                    "ISNULL(r.rem_subtotal, 0) SUBTOTAL, " & vbCrLf & _
                    "ISNULL(r.rem_total, 0) TOTAL, " & vbCrLf & _
                    "ISNULL(CONVERT(VARCHAR(20), r.rem_fecha, 120), '') FECHA, " & vbCrLf & _
                    "ISNULL((SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = r.rem_usuarioIdCreo), '') USUARIO, " & vbCrLf & _
                    "ISNULL(CONVERT(VARCHAR(10), r.rem_fechaCancelacion, 120), '') FECHA_CANCELACION, " & vbCrLf & _
                    "ISNULL((SELECT user_username FROM Framework.Usuarios WHERE user_usuarioid = r.rem_usuarioIdCancelacion), '') USUARIO_CANCELO, " & vbCrLf & _
                    "ISNULL(r.rem_pdf, '')  RUTA_PDF, " & vbCrLf & _
                    "ISNULL(r.rem_estatus, '') ESTATUS " & vbCrLf & _
                    "FROM Facturacion.Remision r" & vbCrLf & _
                    "INNER JOIN Facturacion.Sucursales s ON s.suc_sucursalid = r.rem_sucursalId " & vbCrLf & _
                    "INNER JOIN Facturacion.ClientesCFDI c ON c.cfac_clienteid = r.rem_clienteId " & vbCrLf & _
                    "INNER JOIN Facturacion.SucursalUsuarios su ON su.sucu_sucursaldid = r.rem_sucursalId " & vbCrLf & _
                    "INNER JOIN Facturacion.RemisionProductos rp ON rp.remprod_remisionId = r.rem_id " & vbCrLf &
                    "WHERE su.susu_usuarioid = " & usuarioId & " AND r.rem_estatus = '" & estatus & "' "

        If sucursalId <> 0 Then
            consulta &= " AND r.rem_sucursalId = " & sucursalId & vbCrLf
        End If

        Select Case opcFechas
            Case 0
                consulta &= " AND MONTH(r.rem_fechaCreacion) = MONTH(GETDATE()) AND YEAR(r.rem_fechaCreacion) = YEAR(GETDATE())  " & vbCrLf
            Case 1
                consulta &= " AND r.rem_fechaCreacion BETWEEN '" & filtroFecha1 & " 00:00' AND '" & filtroFecha2 & " 23:59' " & vbCrLf
            Case 2
                consulta &= " AND DATEPART(wk, r.rem_fechaCreacion) = " & filtroFecha1 & " and YEAR(r.rem_fechaCreacion) = " & filtroFecha2 & vbCrLf
        End Select

        If filtro <> "" Then
            consulta &= " AND (r.rem_folio LIKE '%" & filtro & "%' OR c.cfac_razonsocial LIKE '%" & filtro & "%') " & vbCrLf
        End If

        consulta &= "GROUP BY rem_id, r.rem_fechaCreacion, r.rem_folio, s.suc_nombre, c.cfac_razonsocial, r.rem_subtotal, r.rem_total, r.rem_fecha, r.rem_usuarioIdCreo, r.rem_fechaCancelacion, r.rem_usuarioIdCancelacion, r.rem_pdf, r.rem_estatus "

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerFolioSuc(ByVal sucursalId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "select ISNULL(MAX(rem_folio) + 1, 1) Folio from Facturacion.Remision where rem_año = YEAR(GETDATE()) and rem_sucursalId = " & sucursalId

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function guardarRemision(ByVal remision As Entidades.Remision) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "id"
        parametro.Value = remision.RID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folio"
        parametro.Value = remision.RFolio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fecha"
        parametro.Value = remision.RFecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "subtotal"
        parametro.Value = remision.RSubtotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "total"
        parametro.Value = remision.RTotal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuento"
        parametro.Value = remision.RDescuento
        listaParametros.Add(parametro)

        If remision.RMotivoDescuento <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "motivoDescuento"
            parametro.Value = remision.RMotivoDescuento
            listaParametros.Add(parametro)
        End If

        If remision.RPdf <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "pdf"
            parametro.Value = remision.RPdf
            listaParametros.Add(parametro)
        End If

        If remision.REstatus <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "estatus"
            parametro.Value = remision.REstatus
            listaParametros.Add(parametro)
        End If

        If remision.RObservacion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "observacion"
            parametro.Value = remision.RObservacion
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "clienteId"
        parametro.Value = remision.RClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "sucursalId"
        parametro.Value = remision.RSucursalId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = remision.RUsuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "reporteId"
        parametro.Value = remision.RReporteId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Facturacion.SP_GuardarRemision", listaParametros)
    End Function

    Public Sub guardarProductoRemision(ByVal remisionId As Integer, ByVal lstConceptos As List(Of Entidades.Conceptos))
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As List(Of SqlParameter)
        Dim parametro As SqlParameter


        For i As Integer = 0 To lstConceptos.Count - 1
            listaParametros = New List(Of SqlParameter)

            parametro = New SqlParameter
            parametro.ParameterName = "remisionId"
            parametro.Value = remisionId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "productoId"
            parametro.Value = lstConceptos.Item(i).CProductoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "cantidad"
            parametro.Value = lstConceptos.Item(i).CCantidad
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "unidadMedidaId"
            parametro.Value = lstConceptos.Item(i).CUnidadId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "valorUnitario"
            parametro.Value = lstConceptos.Item(i).CValorUnitario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "importe"
            parametro.Value = lstConceptos.Item(i).CImporte
            listaParametros.Add(parametro)

            operacion.EjecutarConsultaSP("Facturacion.SP_GuardarProductoRemision", listaParametros)
        Next
    End Sub

    Public Sub actualizaRutaPDF(ByVal remision As Entidades.Remision)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "update Facturacion.Remision set rem_pdf = '" & remision.RPdf & "', rem_reporteId = " & remision.RReporteId & " where rem_id = " & remision.RID

        operacion.EjecutaConsulta(consulta)
    End Sub

    Public Function obtenerRemision(ByVal remisionId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT ISNULL(rem_id, 0) rem_id, " & vbCrLf & _
                    "ISNULL(rem_folio, 0) rem_folio, " & vbCrLf & _
                    "ISNULL(rem_fecha, '') rem_fecha, " & vbCrLf & _
                    "ISNULL(rem_año, 0) rem_año, " & vbCrLf & _
                    "ISNULL(rem_subtotal, 0) rem_subtotal, " & vbCrLf & _
                    "ISNULL(rem_total, 0) rem_total, " & vbCrLf & _
                    "ISNULL(rem_descuento, 0) rem_descuento, " & vbCrLf & _
                    "ISNULL(rem_motivoDescuento, '') rem_motivoDescuento, " & vbCrLf & _
                    "ISNULL(rem_pdf, '') rem_pdf, " & vbCrLf & _
                    "ISNULL(rem_estatus, '') rem_estatus, " & vbCrLf & _
                    "ISNULL(rem_observacion, '') rem_observacion, " & vbCrLf & _
                    "ISNULL(rem_clienteId, 0) rem_clienteId, " & vbCrLf & _
                    "ISNULL(rem_sucursalId, 0) rem_sucursalId, " & vbCrLf & _
                    "ISNULL(rem_usuarioIdCreo, 0) rem_usuarioIdCreo, " & vbCrLf & _
                    "ISNULL(rem_fechaCreacion, '') rem_fechaCreacion, " & vbCrLf & _
                    "ISNULL(rem_usuarioIdCancelacion, 0) rem_usuarioIdCancelacion, " & vbCrLf & _
                    "ISNULL(rem_fechaCancelacion, '') rem_fechaCancelacion, " & vbCrLf & _
                    "ISNULL(rem_motivoCancelacion, '') rem_motivoCancelacion, " & vbCrLf & _
                    "ISNULL(rem_reporteId, 0) rem_reporteId " & vbCrLf & _
                    "FROM Facturacion.Remision " & vbCrLf & _
                    "WHERE rem_id = " & remisionId

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerProductosRemision(ByVal remisionId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "SELECT ISNULL(rp.remprod_id, 0) remprod_id, " & vbCrLf & _
                    "ISNULL(rp.remprod_remisionId, 0) remprod_remisionId, " & vbCrLf & _
                    "ISNULL(rp.remprod_productoId, 0) remprod_productoId, " & vbCrLf & _
                    "ISNULL(p.fapr_descripción, '') descripcion, " & vbCrLf & _
                    "ISNULL(rp.remprod_unidadMedidaId, 0) remprod_unidadMedidaId, " & vbCrLf & _
                    "ISNULL(um.unme_descripcion, '') unidadMedida, " & vbCrLf & _
                    "ISNULL(rp.remprod_cantidad, 0) remprod_cantidad, " & vbCrLf & _
                    "ISNULL(rp.remprod_valorUnitario, 0) remprod_valorUnitario, " & vbCrLf & _
                    "ISNULL(rp.remprod_importe, 0) remprod_importe " & vbCrLf & _
                    "FROM Facturacion.RemisionProductos rp " & vbCrLf & _
                    "INNER JOIN Facturacion.FacturacionProductos p on p.fapr_productoid = rp.remprod_productoId " & vbCrLf & _
                    "INNER JOIN Materiales.UnidadDeMedida um on um.unme_idunidad = rp.remprod_unidadMedidaId " & vbCrLf & _
                    "WHERE rp.remprod_remisionId =  " & remisionId

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function cancelarRemision(ByVal remision As Entidades.Remision) As Boolean
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim consulta As String = String.Empty

            consulta = "update Facturacion.Remision set " & _
                        "rem_estatus = 'CANCELADA', " & _
                        "rem_fechaCancelacion = GETDATE(), " & _
                        "rem_usuarioIdCancelacion = " & remision.CUsuarioIdCancelacion & ", " & _
                        "rem_motivoCancelacion = ' " & remision.RMotivoCancelacion & " ' " & _
                        "where rem_id = " & remision.RID

            operacion.EjecutaConsulta(consulta)
            Return True
        Catch
            Return False
        End Try
    End Function
End Class
