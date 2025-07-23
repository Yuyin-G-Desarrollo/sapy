Public Class AdministradorExcepcionFacturacionDA

    Public Function ListadoClientes() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As DataTable = objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Facturacion_ConsultaClientesExcepcion]")
        Return dtResultadoConsulta
    End Function

    Public Function ListadoClientesSinRegistro() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As DataTable = objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Facturacion_ConsultaClientesExcepcionSinRegistro]")
        Return dtResultadoConsulta
    End Function

End Class
