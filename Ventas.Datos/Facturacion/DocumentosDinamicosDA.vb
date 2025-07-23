Imports System.Data.SqlClient

Public Class DocumentosDinamicosDA

    Public Function ObtenerRFCOrdenTrabajo(ByVal ClienteID As Integer, ByVal OT As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteId"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@OT"
        parametro.Value = OT
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConfigDoctos_RFCCliente]", ListaParametros)
    End Function


    Public Function ObtenerDatosClienteFacturacion(ByVal ClienteID As Integer, ByVal OT As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteId"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@OrdenTrabajo"
        parametro.Value = OT
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConfigDoctos_DatosCliente]", ListaParametros)
    End Function


    Public Function ObtenerInformacionSesion(ByVal SesionID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SesionID
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DatosSessionUsuario]", ListaParametros)
    End Function

    Public Function ObtenerPartidasOT(ByVal OTs As String, ByVal SessionId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@OT"
        parametro.Value = OTs
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Session"
        parametro.Value = SessionId
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_PartidasOT]", ListaParametros)
    End Function




    Public Function InsertarDocumento(ByVal SessionID As Integer, ByVal ClienteID As Integer, ByVal TipoDocumento As String, ByVal RazonSocial As String, ByVal RazonSocialReceptor As String, ByVal UsuarioCapturaID As Integer, ByVal CantidadPares As Integer, ByVal SubTotal As Double, ByVal DocumentoID As Integer, ByVal UsoCFDI As String, ByVal Descuento As Double, ByVal TotalIVA As Double, ByVal MontoTotal As Double, ByVal Importe As Double, ByVal ConsecutivoDocumento As Integer, ByVal PorcentajeDescuento As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteID"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoDocumento"
        parametro.Value = TipoDocumento
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RazonSocialEmisorID"
        parametro.Value = RazonSocial
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RazonSocialReceptorID"
        parametro.Value = RazonSocialReceptor
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCapturaID"
        parametro.Value = UsuarioCapturaID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CantidadPares"
        parametro.Value = CantidadPares
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Subtotal"
        parametro.Value = SubTotal
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descuento"
        parametro.Value = Descuento
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalIVA"
        parametro.Value = TotalIVA
        ListaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@Importe"
        parametro.Value = Importe
        ListaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@MontoTotal"
        parametro.Value = MontoTotal
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsoCFDI"
        parametro.Value = UsoCFDI
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ConsecutivoDocumento"
        parametro.Value = ConsecutivoDocumento
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorcentajeDescuento"
        parametro.Value = PorcentajeDescuento
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_CrearDocumento]", ListaParametros)
    End Function

    Public Function InsertarDetallesDocumento(ByVal DocumentoID As Integer, ByVal OrdenTrabajoPartida As Integer, ByVal ProductoEstilo As Integer, ByVal CantidadPares As Integer, ByVal PrecioEnPedido As Double, ByVal PrecioDocumento As Double, ByVal SubTotal As Double, ByVal Descuento As Double, ByVal Importe As Double, ByVal IVA As Double, ByVal MontoTotal As Double, ByVal SessionID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@OrdenTrabajoPartida"
        parametro.Value = OrdenTrabajoPartida
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProductoEstilo"
        parametro.Value = ProductoEstilo
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CantidadPares"
        parametro.Value = CantidadPares
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PrecioEnPedido"
        parametro.Value = PrecioEnPedido
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PrecioDocumento"
        parametro.Value = PrecioDocumento
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Subtotal"
        parametro.Value = SubTotal
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Descuento"
        parametro.Value = Descuento
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Importe"
        parametro.Value = Importe
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IVA"
        parametro.Value = IVA
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MontoTotal"
        parametro.Value = MontoTotal
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SessionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_InsertarDetallesDocumento]", ListaParametros)
    End Function

    Public Function ObtenerRFC(ByVal RFCID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@RFCID"
        parametro.Value = RFCID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ObtenerRFC]", ListaParametros)
    End Function

    Public Function ObtenerDocumentosSession(ByVal SessionID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ObtenerDocumentosSession]", ListaParametros)
    End Function

    Public Function ObtenerDetallesDocumentosSession(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SessionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ObtenerDetallesDocumentosSession]", ListaParametros)
    End Function

    Public Function BorrarDocumentosSession(ByVal SessionID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_BorrarDocumentosSession]", ListaParametros)
    End Function


    Public Function ObtenerUsoCFDISession(ByVal SessionID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ObtenerUsoCFDISession]", ListaParametros)
    End Function

    Public Function ObtenerDescuentosClientes(ByVal ClienteID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteId"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConfigDoctos_DescuentosCliente]", ListaParametros)
    End Function

    Public Function ActualizarUsoDocumento(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ActualizarUsoDocumento]", ListaParametros)
    End Function

    Public Function ActualizarOrdenCompraDocumento(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ActualizarOrdenCompraDocumento]", ListaParametros)
    End Function

    Public Function ActualizarTiendaDocumento(ByVal SessionID As Integer, ByVal DocumentoID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DocumentoID"
        parametro.Value = DocumentoID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_ActualizarTiendaDocumento]", ListaParametros)
    End Function

    Public Function GuardarEncabezadoFacturacion(ByVal ClienteID As Integer, ByVal OT As String, ByVal PorcentajeFacturacion_FTC As Integer, ByVal PorcentajaRemision_FTC As Integer, ByVal PorcentajeFacturacion_usuario As Integer, ByVal PorcentajeRemision_usuario As Integer, ByVal MontoMaximoFactura As Double, ByVal RestriccionFacturacionID As Integer, ByVal TipoIVAID As Integer, ByVal MonedaID As Integer, ByVal ImprimirOC As Boolean, ByVal ImprimirTienda As Boolean, ByVal EmisorID As Integer, ByVal UsuarioID As Integer, ByVal SessionID As Integer, ByVal GeneracionAutomatica As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteId"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@OT"
        parametro.Value = OT
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorcentajeFacturacion"
        parametro.Value = DBNull.Value
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorcentajeRemision"
        parametro.Value = DBNull.Value
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorcentajeFacturacion_FTC"
        parametro.Value = PorcentajeFacturacion_FTC
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PorcentajeRemision_FTC"
        parametro.Value = PorcentajaRemision_FTC
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MontoMaximoFactura"
        parametro.Value = MontoMaximoFactura
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RestriccionFacturacionID"
        If RestriccionFacturacionID = 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = RestriccionFacturacionID
        End If
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoIVAID"
        If TipoIVAID = 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = TipoIVAID
        End If
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MonedaID"
        If MonedaID < 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = MonedaID
        End If
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ImprimirOC"
        parametro.Value = ImprimirOC
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ImprimirTienda"
        parametro.Value = ImprimirTienda
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EmisorID"
        If EmisorID = 0 Then
            parametro.Value = DBNull.Value
        Else
            parametro.Value = EmisorID
        End If
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = UsuarioID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@GeneracionAutomatica"
        parametro.Value = GeneracionAutomatica
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_VisualizacionDocumentos_Paso3]", ListaParametros)
    End Function


    Public Function GuardarDetallesFacturacion(ByVal SessionID As Integer, ByVal ClienteID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteId"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@SesionID"
        parametro.Value = SessionID
        ListaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_VisualizacionDocumentos_Detalles]", ListaParametros)
    End Function

    Public Function ObtenerFactorDescuento(ByVal ClienteID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ClienteId"
        parametro.Value = ClienteID
        ListaParametros.Add(parametro)

      
        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_ConfigDoctos_ObtenerFactorDescuento]", ListaParametros)
    End Function


    Public Function ObtenerPartidasOTAndrea(ByVal OTs As String, ByVal SessionId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@OT"
        parametro.Value = OTs
        ListaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Session"
        parametro.Value = SessionId
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_DocDinamicos_Andrea_PartidasOT]", ListaParametros)
    End Function
End Class
