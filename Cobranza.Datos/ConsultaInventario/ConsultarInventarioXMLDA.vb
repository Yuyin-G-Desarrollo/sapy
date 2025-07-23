Imports System.Data.SqlClient

Public Class ConsultarInventarioXMLDA

    Public Sub GuardarInformacionXMLFacturas(ByVal pXmlDocumentos As String, ByVal Serie As String, ByVal Folio As String, ByVal FechaTimbrado As String, ByVal Rfc As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@XmlDocumentos", pXmlDocumentos)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Serie", Serie)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Folio", Folio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaTimbrado", FechaTimbrado)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Rfc", Rfc)
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("[Ventas].[InsertaINFO_FacturasXML_ConsultaInventario]", listaParametros)

    End Sub

End Class
