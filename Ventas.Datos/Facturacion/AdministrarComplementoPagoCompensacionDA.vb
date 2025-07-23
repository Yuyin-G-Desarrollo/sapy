Imports System.Data.SqlClient
Imports Persistencia
Public Class AdministrarComplementoPagoCompensacionDA
    Public Function obtenerCfdiCliente(ByVal clienteId As Integer, ByVal serie As String, ByVal folio As Integer, ByVal conAjuste As String) As DataTable
        Dim operacion As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "cadenaId"
        parametro.Value = clienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "serie"
        parametro.Value = serie
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "folio"
        parametro.Value = folio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conAjuste"
        parametro.Value = conAjuste
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ComplementoPagoAjuste_ObtenerCFDI", listaParametros)
    End Function

    Public Function validaCRPAjuste(ByVal complementoId As Integer) As DataTable
        Dim operacion As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "complementoPagoId"
        parametro.Value = complementoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ComplementoPagoAjuste_ValidaCRPAjuste", listaParametros)
    End Function

    Public Function obtenerAjuste(ByVal complementoId As Integer) As DataTable
        Dim operacion As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "complementoPagoId"
        parametro.Value = complementoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ComplementoPagoAjuste_Obtener", listaParametros)
    End Function

    Public Function generarAjuste(ByVal complementoId As Integer, ByVal rutaXml As String, ByVal rutaPdf As String) As DataTable
        Dim operacion As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "complementoPagoId"
        parametro.Value = complementoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaXml"
        parametro.Value = rutaXml
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaPdf"
        parametro.Value = rutaPdf
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ComplementoPagoAjuste_Generar", listaParametros)
    End Function

    Public Function obtenerCRPAjuste(ByVal complementoId As Integer) As DataTable
        Dim operacion As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "complementoId"
        parametro.Value = complementoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ComplementoPagoAjuste_ObtenerCRPAjuste", listaParametros)
    End Function

    Public Function generarCobros(ByVal complementoId As Integer) As DataTable
        Dim operacion As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "complementoId"
        parametro.Value = complementoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ComplementoPagoAjuste_GenerarCobros", listaParametros)
    End Function

    Public Function obtenerClientes(ByVal tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@tipoBusqueda", tipo_busqueda)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_ListadoParametrosCobranza_Clientes]", listaParametros)

    End Function

    Public Function obtenerAjustesPorCompensacion(ByVal FechaInicio As Date, ByVal FechaFin As Date, ClienteID As String, ByVal TipoPago As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ClienteID", ClienteID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@TipoPago", TipoPago)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Obtiene_AjustesCompensacion]", listaParametros)


    End Function

    Public Function CambiarTipoCobroAjuste(ByVal pXmlCeldas As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@XMLCeldas", pXmlCeldas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Modifica_TipoCobro_AjusteCompensacion]", listaParametros)

    End Function



End Class
