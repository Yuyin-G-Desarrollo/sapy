Public Class AdministrarComplementoPagoCompensacionBU
    Public Function obtenerCfdiCliente(ByVal clienteId As Integer, ByVal serie As String, ByVal folio As Integer, ByVal conAjuste As String) As DataTable
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDatos.obtenerCfdiCliente(clienteId, serie, folio, conAjuste)
    End Function

    Public Function validaCRPAjuste(ByVal complementoId As Integer) As DataTable
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDatos.validaCRPAjuste(complementoId)
    End Function

    Public Function obtenerAjuste(ByVal complementoId As Integer) As DataTable
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDatos.obtenerAjuste(complementoId)
    End Function

    Public Function generarAjuste(ByVal complementoId As Integer, ByVal rutaXml As String, ByVal rutaPdf As String) As DataTable
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDatos.generarAjuste(complementoId, rutaXml, rutaPdf)
    End Function

    Public Function obtenerCRPAjuste(ByVal complementoId As Integer) As DataTable
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDatos.obtenerCRPAjuste(complementoId)
    End Function

    Public Function generarCobros(ByVal complementoId As Integer) As String
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.generarCobros(complementoId)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows.Count > 0 Then
                resultado = dtResultado.Rows(0)("mensaje").ToString()
            End If
        End If

        Return resultado
    End Function

    Public Function obtenerClientes(ByVal tipo_busqueda As Integer) As DataTable
        Dim objDatos As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDatos.obtenerClientes(tipo_busqueda)
    End Function

    Public Function obtenerAjustesPorCompensacion(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ClienteID As String, ByVal TipoPago As Integer) As DataTable
        Dim objDA As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDA.obtenerAjustesPorCompensacion(FechaInicio, FechaFin, ClienteID, TipoPago)
    End Function

    Public Function CambiarTipoCobroAjuste(ByVal pmXLCeldas As String)
        Dim objDA As New Datos.AdministrarComplementoPagoCompensacionDA
        Return objDA.CambiarTipoCobroAjuste(pmXLCeldas)
    End Function


End Class
