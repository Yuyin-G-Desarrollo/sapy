Public Class DocumentosDinamicosBU

    Public Function ObtenerRFCOrdenTrabajo(ByVal ClienteID As Integer, ByVal OT As String) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerRFCOrdenTrabajo(ClienteID, OT)
    End Function

    Public Function ObtenerDatosClienteFacturacion(ByVal ClienteID As Integer, ByVal OT As String) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerDatosClienteFacturacion(ClienteID, OT)
    End Function

    'Se agrego campos
    Public Function ObtenerDatosClienteFacturacionEntidad(ByVal ClienteID As Integer, ByVal OT As String) As Entidades.FacturacionDatosCliente
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Dim dtInformacion As DataTable
        Dim obj As New Entidades.FacturacionDatosCliente

        dtInformacion = objda.ObtenerDatosClienteFacturacion(ClienteID, OT)

        If dtInformacion.Rows.Count > 0 Then
            If IsDBNull(dtInformacion.Rows(0).Item("ClienteID")) = True Then
                obj.ClienteID = -1
            Else
                obj.ClienteID = dtInformacion.Rows(0).Item("ClienteID")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("Cliente")) = True Then
                obj.Cliente = ""
            Else
                obj.Cliente = dtInformacion.Rows(0).Item("Cliente")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("PorcentajeFacturacion")) = True Then
                obj.PorcentajeFacturacion = 0
            Else
                obj.PorcentajeFacturacion = dtInformacion.Rows(0).Item("PorcentajeFacturacion")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("PorcentajeRemision")) = True Then
                obj.PorcentajeRemision = 0
            Else
                obj.PorcentajeRemision = dtInformacion.Rows(0).Item("PorcentajeRemision")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("MonedaID")) = True Then
                obj.MonedaID = -1
            Else
                obj.MonedaID = dtInformacion.Rows(0).Item("MonedaID")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("Moneda")) = True Then
                obj.Moneda = ""
            Else
                obj.Moneda = dtInformacion.Rows(0).Item("Moneda")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("Plazo")) = True Then
                obj.Plazo = 0
            Else
                obj.Plazo = dtInformacion.Rows(0).Item("Plazo")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("MontoMaximoFactura")) = True Then
                obj.MontoMaximoFacturacion = 0
            Else
                obj.MontoMaximoFacturacion = dtInformacion.Rows(0).Item("MontoMaximoFactura")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("RestriccionID")) = True Then
                obj.RestriccionID = 0
            Else
                obj.RestriccionID = dtInformacion.Rows(0).Item("RestriccionID")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("Restriccion")) = True Then
                obj.Restriccion = ""
            Else
                obj.Restriccion = dtInformacion.Rows(0).Item("Restriccion")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("FacturarPorMarca")) = True Then
                obj.FacturarPorMarca = ""
            Else
                obj.FacturarPorMarca = dtInformacion.Rows(0).Item("FacturarPorMarca")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("EmpresaID")) = True Then
                obj.EmpresaID = 0
            Else
                obj.EmpresaID = dtInformacion.Rows(0).Item("EmpresaID")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("Empresa")) = True Then
                obj.Empresa = ""
            Else
                obj.Empresa = dtInformacion.Rows(0).Item("Empresa")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("EmpresaRFC")) = True Then
                obj.EmpresaRFC = ""
            Else
                obj.EmpresaRFC = dtInformacion.Rows(0).Item("EmpresaRFC")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("TipoIvaID")) = True Then
                obj.TipoIVA = 0
            Else
                obj.TipoIVA = dtInformacion.Rows(0).Item("TipoIvaID")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("IVA")) = True Then
                obj.IVA = ""
            Else
                obj.IVA = dtInformacion.Rows(0).Item("IVA")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("ImprimirTienda")) = True Then
                obj.ImprimirTienda = False
            Else
                obj.ImprimirTienda = dtInformacion.Rows(0).Item("ImprimirTienda")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("ImprimirOC")) = True Then
                obj.ImprimirOC = False
            Else
                obj.ImprimirOC = dtInformacion.Rows(0).Item("ImprimirOC")
            End If

            If IsDBNull(dtInformacion.Rows(0).Item("DescripcionEspecial")) = True Then
                obj.DescripcionEspecial = False
            Else
                obj.DescripcionEspecial = dtInformacion.Rows(0).Item("DescripcionEspecial")
            End If

            'If IsDBNull(dtInformacion.Rows(0).Item("CorreoReceptor")) = True Then
            '    obj.CorreoReceptor = ""
            'Else
            '    obj.CorreoReceptor = dtInformacion.Rows(0).Item("CorreoReceptor")
            'End If

        End If

        Return obj

    End Function

    Public Function ObtenerInformacionSesion(ByVal SesionID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerInformacionSesion(SesionID)
    End Function

    Public Function ObtenerPartidasOT(ByVal OTs As String, ByVal SessionId As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerPartidasOT(OTs, SessionId)
    End Function

    Public Function InsertarDocumento(ByVal SessionID As Integer, ByVal ClienteID As Integer, ByVal TipoDocumento As String, ByVal RazonSocial As String, ByVal RazonSocialReceptor As String, ByVal UsuarioCapturaID As Integer, ByVal CantidadPares As Integer, ByVal SubTotal As Double, ByVal DocumentoId As Integer, ByVal UsoCFDI As String, ByVal Descuento As Double, ByVal TotalIVA As Double, ByVal MontoTotal As Double, ByVal Importe As Double, ByVal ConsecutivoDocumento As Integer, ByVal PorcentajeDescuento As Double) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.InsertarDocumento(SessionID, ClienteID, TipoDocumento, RazonSocial, RazonSocialReceptor, UsuarioCapturaID, CantidadPares, SubTotal, DocumentoId, UsoCFDI, Descuento, TotalIVA, MontoTotal, Importe, ConsecutivoDocumento, PorcentajeDescuento)
    End Function

    Public Function InsertarDetallesDocumento(ByVal DocumentoID As Integer, ByVal OrdenTrabajoPartida As Integer, ByVal ProductoEstilo As Integer, ByVal CantidadPares As Integer, ByVal PrecioEnPedido As Double, ByVal PrecioDocumento As Double, ByVal SubTotal As Double, ByVal Descuento As Double, ByVal Importe As Double, ByVal IVA As Double, ByVal MontoTotal As Double, ByVal SessionID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.InsertarDetallesDocumento(DocumentoID, OrdenTrabajoPartida, ProductoEstilo, CantidadPares, PrecioEnPedido, PrecioDocumento, SubTotal, Descuento, Importe, IVA, MontoTotal, SessionID)
    End Function

    Public Function ObtenerRFC(ByVal RFCID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerRFC(RFCID)
    End Function


    Public Function ObtenerDocumentosSession(ByVal SessionID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerDocumentosSession(SessionID)
    End Function

    Public Function ObtenerDetallesDocumentosSession(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerDetallesDocumentosSession(SessionID, DocumentoID)
    End Function

    Public Function BorrarDocumentosSession(ByVal SessionID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.BorrarDocumentosSession(SessionID)
    End Function

    Public Function ObtenerUsoCFDISession(ByVal SessionID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerUsoCFDISession(SessionID)
    End Function

    Public Function ObtenerDescuentosClientes(ByVal ClienteID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerDescuentosClientes(ClienteID)
    End Function

    Public Function ActualizarUsoDocumento(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ActualizarUsoDocumento(SessionID, DocumentoID)
    End Function

    Public Function ActualizarOrdenCompraDocumento(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ActualizarOrdenCompraDocumento(SessionID, DocumentoID)
    End Function

    Public Function ActualizarTiendaDocumento(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ActualizarTiendaDocumento(SessionID, DocumentoID)
    End Function

    Public Function GuardarEncabezadoFacturacion(ByVal ClienteID As Integer, ByVal OT As String, ByVal PorcentajeFacturacion_FTC As Integer, ByVal PorcentajaRemision_FTC As Integer, ByVal PorcentajeFacturacion_usuario As Integer, ByVal PorcentajeRemision_usuario As Integer, ByVal MontoMaximoFactura As Double, ByVal RestriccionFacturacionID As Integer, ByVal TipoIVAID As Integer, ByVal MonedaID As Integer, ByVal ImprimirOC As Boolean, ByVal ImprimirTienda As Boolean, ByVal EmisorID As Integer, ByVal UsuarioID As Integer, ByVal SessionID As Integer, ByVal GeneracionAutomatica As Boolean) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.GuardarEncabezadoFacturacion(ClienteID, OT, PorcentajeFacturacion_FTC, PorcentajaRemision_FTC, PorcentajeFacturacion_usuario, PorcentajeRemision_usuario, MontoMaximoFactura, RestriccionFacturacionID, TipoIVAID, MonedaID, ImprimirOC, ImprimirTienda, EmisorID, UsuarioID, SessionID, GeneracionAutomatica)
    End Function

    Public Function GuardarDetallesFacturacion(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.GuardarDetallesFacturacion(SessionID, ClienteID)
    End Function

    Public Function ObtenerFactorDescuento(ByVal ClienteID As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerFactorDescuento(ClienteID)
    End Function

    Public Function ObtenerPartidasOTAndrea(ByVal OTs As String, ByVal SessionId As Integer) As DataTable
        Dim objda As New Ventas.Datos.DocumentosDinamicosDA
        Return objda.ObtenerPartidasOTAndrea(OTs, SessionId)
    End Function

  
End Class
