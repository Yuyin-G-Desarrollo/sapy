Imports Persistencia
Imports System.Data.SqlClient

Public Class PagoProveedorDA

    Public Function buscarProveedor(ByVal proveedorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdProveedor, RazonSocial, NomComercial FROM Proveedores WHERE IdProveedor = " + proveedorID.ToString + " "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarCobrador(ByVal proveedorID As Integer, ByVal cobradorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdCobrador, Nombre, RutaFoto FROM cxpproveedorcobrador WHERE IdProveedor = " + proveedorID.ToString + "AND IdCobrador = " + cobradorID.ToString + "  and Estatus = 'ACTIVO'"

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarPago(ByVal proveedorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT * FROM tmpprogramapagos WHERE  Imprimerecibo = 1 and idproveedor= " + proveedorID.ToString + " "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function buscarChecke(ByVal proveedorID As Integer) As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT * FROM cxpordenespago where Entregar=0 AND Imprimerecibo=1 AND (IdConcepto=1 OR IdConcepto=2 OR IdConcepto=3 OR IdConcepto=12 OR IdConcepto=13) and IDPROVEEDOR= " + proveedorID.ToString + " "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Sub insertarRegistroProveedor(ByVal proveedorID As Integer, ByVal cobradorID As Integer)

        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim consulta As String = "" +
" INSERT INTO dbo.RegistroProveedor" +
"            (" +
"   		    idproveedor" +
"              ,fechahora" +
"              ,fecha" +
"              ,idcobrador" +
" 		     )" +
"            VALUES" +
"            (" +
               proveedorID.ToString +
"             ,(SELECT GETDATE())" +
"             ,(SELECT GETDATE())" +
"             ," + cobradorID.ToString +
" 		   )"

        operaciones.EjecutaSentencia(consulta)
        Console.WriteLine("Mandó la sentencia")

    End Sub

End Class
