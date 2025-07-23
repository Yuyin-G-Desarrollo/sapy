Imports System.Data.SqlClient
Imports Entidades.Produccion

Public Class ConfiguracionClienteProveedorInternoDA
    Public Function obtenerProveedoresInternos()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        dtResultadoConsulta = objPersistencia.EjecutaConsulta("[Cobranza].[SP_Consulta_ProveedoresInternos]")
        Return dtResultadoConsulta
    End Function
    Public Function MostrarClientesInternosProveedor(ByVal objConfiguracion As Entidades.ConfiguracionClienteProveedorInterno)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idproveedor"
        parametro.Value = objConfiguracion.IdProveedorInterno
        listaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "tipoFiltro"
        parametro.Value = objConfiguracion.ActivoInterno
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Consulta_ProveedoresClientesInternos]", listaParametros)

        Return dtResultadoConsulta
    End Function
    Public Function ConsultarBancoRfcProveedorInterno(ByVal idCuenta As Entidades.ConfiguracionClienteProveedorInterno)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "idCuenta"
        parametro.Value = idCuenta.IdCuentaBancaria
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_Consulta_CuentaBancoProveedorInterno]", listaParametros)

        Return dtResultadoConsulta
    End Function
End Class
