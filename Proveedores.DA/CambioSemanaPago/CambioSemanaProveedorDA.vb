Imports System.Data.SqlClient

Public Class CambioSemanaProveedorDA

    Public Function obtenerProveedor(tipo_busqueda As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@tipoBusqueda"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ListadoParametrosProveedor_SemanaPago]", listaParametros)
    End Function

    Public Function ObtenerDocumentosProveedor(ProveedorId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "ProveedorID"
        parametro.Value = ProveedorId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ObtieneDocumentosCambioSemana_Proveedor]", listaParametros)

    End Function

    Public Function llenarComboAnioPago() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = " SELECT DISTINCT(numano) año, numano añoPago FROM catsemanas WHERE numano > 2018 ORDER BY numano ASC"
        Return objPersistencia.EjecutaConsulta(cadena)

    End Function


    Public Function llenarComboSemanaPago(ByVal año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = " select ROW_NUMBER() OVER (order BY numsem) num, numsem from catsemanas where numano =  ('" + año.ToString + "') ORDER BY numsem ASC"
        Return objPersistencia.EjecutaConsulta(cadena)

    End Function

    Public Function ActualizarSemanaPagoProveedor(ByVal pXmlDocumentos As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Xml_Documentos"
        parametro.Value = pXmlDocumentos
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_Proveedores_ActualizaSemanaPagoProveedor]", listaParametros)

    End Function




End Class
