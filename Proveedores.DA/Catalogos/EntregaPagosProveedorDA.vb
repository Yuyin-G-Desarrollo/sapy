Imports System.Data.SqlClient

Public Class EntregaPagosProveedorDA


    Public Function ListadoParametrosProveedor(tipo_busqueda As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "TipoConsulta"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ConsultaFiltros]", listaParametros)
    End Function

    Public Function ObtenerDocumentosaPagar(ProveedorId As String) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProveedorId"
        parametro.Value = ProveedorId
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ObtieneDocumentosAPagar]", listaParametros)

    End Function

    Public Function ObtieneReciboPagoAnterior(proveedorid As Integer, recibo As Integer, usuario As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@proveedor"
        parametro.Value = proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@recibo"
        parametro.Value = recibo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ObtieneReciboAnterior]", listaParametros)

    End Function

    Public Function ObtieneReciboPagoAnteriorDetalles(semana As Integer, proveedorid As Integer, recibo As Integer, año As Integer, usuario As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@semana"
        parametro.Value = semana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@proveedorid"
        parametro.Value = proveedorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@recibo"
        parametro.Value = recibo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@año"
        parametro.Value = año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = usuario
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ObtieneReciboAnterior2]", listaParametros)


    End Function

    Public Function ActualizaTablaEntregaPagos(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ActualizaTablasPagos]", listaparametros)

    End Function

    Public Function SiguienteRecibo() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[dbo].[spSiguienteRecibo]", listaParametros)
    End Function

    Public Function ImprimirReciboPago() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[dbo].[spRDocPrvPagados]", listaParametros)
    End Function

    Public Function ObtieneReciboPagoEncabezado(ByVal ProveedorId As Integer, ByVal Recibo As Integer, ByVal Usuario As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@prv"
        parametro.Value = ProveedorId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usu"
        parametro.Value = Usuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Consec"
        parametro.Value = Recibo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ObtieneReciboNuevoEncabezado]", listaparametros)

    End Function

    Public Function ObtieneReciboPagoDetalles(ByVal ProveedorId As Integer, Recibo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@prv"
        parametro.Value = ProveedorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Consec"
        parametro.Value = Recibo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ObtieneReciboNuevoDetalles]", listaParametros)
    End Function

    Public Function ActualizaPagosProveedor(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ActualizaPagosProveedor]", listaparametros)

    End Function

    Public Function verComboReciboPago(ByVal idProveedor As Integer, ByVal Semana As Integer, ByVal año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        parametro.ParameterName = "@ProveedorId"
        parametro.Value = idProveedor
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Semana"
        parametro.Value = Semana
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = año
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_ObtieneReciboPorProveedor]", listaparametros)
    End Function

    Public Function verComboProveedores() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = "SELECT IdProveedor ,RazonSocial FROM proveedores WHERE estatus = 'Activo' AND IdProveedor IN (SELECT idproveedor FROM CXPProveedorCobrador) ORDER BY razonsocial"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function verComboSemanaPago(ByVal año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = " select ROW_NUMBER() OVER (order BY numsem) num, numsem, CAST(FecIni AS DATE) FecIni, CAST(FecFin AS DATE) FecFin from catsemanas where numano =  ('" + año.ToString + "') ORDER BY numsem ASC"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function verComboAño() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = " SELECT DISTINCT(numano) año, numano añoPago FROM catsemanas WHERE numano > 2017 ORDER BY numano ASC"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function insertaRecibo(ByVal ProveedorId As Integer, Usuario As String, Recibo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProveedorId"
        parametro.Value = ProveedorId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Usuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Consec"
        parametro.Value = Recibo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_EntregaPagosProveedor_InsertaRecibo]", listaparametros)

    End Function


End Class
