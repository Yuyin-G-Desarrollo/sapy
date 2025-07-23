Imports Proveedores.DA
Public Class DevolucionesPreliminares_BU

    Public Function obtenerFacturasConSaldo(ByVal emisorSicyId As Integer, ByVal receptorSicyId As Integer) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.obtenerFacturasConSaldo(emisorSicyId, receptorSicyId)
    End Function

    Public Function insertarDevolucionPreliminar(ByVal xmlDetalles As String, ByVal facturaCompraId As Integer, ByVal facturaAplicarId As Integer, ByVal emisorId As Integer, ByVal receptorId As Integer) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.insertarDevolucionPreliminar(xmlDetalles, facturaCompraId, facturaAplicarId, emisorId, receptorId)
    End Function

    Public Function ObtenerEstatusDevolucion() As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.ObtenerEstatusDevolucion()
    End Function

    Public Function consultarDevolucionesPT(ByVal porFechaDevolucion As Boolean, ByVal porFechaFactura As Boolean, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal emisorIds As String, ByVal receptorIds As String, ByVal estatusIds As String) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.consultarDevolucionesPT(porFechaDevolucion, porFechaFactura, fechaInicio, fechaFin, emisorIds, receptorIds, estatusIds)
    End Function

    Public Function obtenerDetalleDevolucion(ByVal devolucionId As Integer) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.obtenerDetalleDevolucion(devolucionId)
    End Function

    Public Function validarExisteDevolucion(ByVal rfcEmisor As String, ByVal serieDocumento As String, ByVal folioDocumento As Integer, ByVal UUID As String) As Boolean
        Dim objDA As New DevolucionesPreliminares_DA
        Dim dtResultado As New DataTable
        Dim blnResult As Boolean = False
        dtResultado = objDA.validarExisteDevolucion(rfcEmisor, serieDocumento, folioDocumento, UUID)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            blnResult = True
        End If

        Return blnResult
    End Function
    Public Function aplicarDevolucion(ByVal devolucionId As Integer, ByVal devComprasXML As Entidades.DevComprasPT_XML, ByVal rutaXML As String, ByVal rutaPDF As String) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.aplicarDevolucion(devolucionId, devComprasXML, rutaXML, rutaPDF)
    End Function

    Public Function obtenerRutasSICY_Emisor(ByVal emisorId As Integer) As DataTable
        Dim objDa As New DA.DevolucionesPreliminares_DA
        Return objDa.obtenerRutasSICY_Emisor(emisorId)
    End Function

    Public Function insertarRegistroDevolucionCompras(ByVal documentoId As Integer) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.insertarRegistroDevolucionCompras(documentoId)
    End Function

    Public Function obtenerLauyoutDevolucionesPT(ByVal porFechaDevolucion As Boolean, ByVal porFechaFactura As Boolean, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal emisorIds As String, ByVal receptorIds As String) As DataTable
        Dim objDA As New DA.DevolucionesPreliminares_DA
        Return objDA.obtenerLauyoutDevolucionesPT(porFechaDevolucion, porFechaFactura, fechaInicio, fechaFin, emisorIds, receptorIds)
    End Function

End Class
