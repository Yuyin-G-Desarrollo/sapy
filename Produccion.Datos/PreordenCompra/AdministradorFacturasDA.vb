Imports System.Data.SqlClient

Public Class AdministradorFacturasDA


    Public Function ObtenerFacturas(ByVal NaveID As Integer, ByVal ProveedorID As String, ByVal SemanaPago As Integer, ByVal AñoPago As Integer, ByVal FechaInicio As String, ByVal FechaFin As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProveedorID", ProveedorID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SemanaPago", SemanaPago)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@AñoPago", AñoPago)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_Obtiene_AdministradorFacturasCompras]", listaParametros)

    End Function

    Public Function EnviarFacturas(ByVal Celdas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Celdas", Celdas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_EnvioFacturas_AdministradorFacturasCompras]", listaParametros)
    End Function

    Public Function CancelarFacturas(ByVal Celdas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Celdas", Celdas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Compras].[SP_CancelarFacturas_AdministradorFacturasCompras]", listaParametros)
    End Function

End Class
