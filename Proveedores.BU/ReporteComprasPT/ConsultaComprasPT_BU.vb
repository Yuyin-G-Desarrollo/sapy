Imports Entidades
Imports Proveedores.DA
Public Class ConsultaComprasPT_BU

    Public Function ObtenerCompradeProductoIngresado(ByVal pFechaInicio As Date, ByVal pFechaFin As Date, ByVal pIdNaves As String, ByVal pIdMarcas As String) As DataTable
        Dim obj As New ConsultaComprasPT_DA
        Return obj.ObtieneCompradeProductoIngresado(pFechaInicio, pFechaFin, pIdNaves, pIdMarcas)
    End Function

    Public Function ListadoParametroNaves(tipo_Nave As Integer) As DataTable
        Dim objDA As New Proveedores.DA.ConsultaComprasPT_DA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametroNaves(tipo_Nave)

        Return tabla

    End Function

    Public Function PreciosNavesPropias() As DataTable
        Dim obj As New ConsultaComprasPT_DA
        Return obj.ObtienePreciosNavesPropias()
    End Function

    Public Function ObtenerCompradeProductoIngresadoCoppel(rowsGrdPedidos As String) As DataTable
        Dim obj As New ConsultaComprasPT_DA
        Return obj.ObtieneCompradeProductoIngresadoCopel(rowsGrdPedidos)
    End Function
    Public Function ListadoParametroMarcas() As DataTable
        Dim objDA As New Proveedores.DA.ConsultaComprasPT_DA
        Dim tabla As New DataTable
        tabla = objDA.listadoParametroMarcas()

        Return tabla

    End Function

    Public Function ObtenerNavesReceptoras() As DataTable
        Dim objDA As New ConsultaComprasPT_DA
        Return objDA.ObtenerNavesReceptoras()
    End Function

    Public Function ObtenerResumenFacturacion(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal navesId As String, ByVal marcasId As String) As DataTable
        Dim objDA As New ConsultaComprasPT_DA
        Return objDA.ObtenerResumenFacturacion(fechaInicio, fechaFin, navesId, marcasId)
    End Function

    Public Function InsertarDocumentoFactura(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal navesId As String, ByVal marcasId As String, ByVal pruebas As Boolean) As DataTable
        Dim objDA As New ConsultaComprasPT_DA
        Return objDA.InsertarDocumentoFactura(fechaInicio, fechaFin, navesId, marcasId, pruebas)
    End Function

    Public Function InsertarDocumentoFacturaDetalle(ByVal facturaPTIngresadoDetalle As FacturaPTIngresadoDetalle) As String
        Dim objDA As New ConsultaComprasPT_DA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.InsertarDocumentoFacturaDetalle(facturaPTIngresadoDetalle)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje").ToString()
            End If
        End If

        Return resultado
    End Function

    Public Function GeneraInformacionTimbrar(ByVal documentoId As Integer) As String
        Dim objDA As New ConsultaComprasPT_DA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.GeneraInformacionTimbrar(documentoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0).Item("mensaje").ToString()
            End If
        End If

        Return resultado
    End Function

    Public Function ListadoParametroArticulos() As DataTable
        Dim objDA As New Proveedores.DA.ConsultaComprasPT_DA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroArticulos()

        Return tabla

    End Function
End Class
