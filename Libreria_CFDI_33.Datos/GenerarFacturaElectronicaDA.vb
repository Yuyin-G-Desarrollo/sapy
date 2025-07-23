Imports Persistencia
Imports System.Data.SqlClient

Public Class GenerarFacturaElectronicaDA
    Public Function InsertaDatosTimbradoNotaDeCredito(ByVal idNotaDeCredito As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "p_IdNotaCredito"
            ParametroParaLista.Value = idNotaDeCredito
            ListaParametros.Add(ParametroParaLista)
            Return operacion.EjecutarConsultaSP("[Cobranza].[sp_InsertaDatosTimbradoNotaDeCredito]", ListaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerEmpresaIdTimbradoNotaDeCredito(ByVal idNotaDeCredito As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "@Accion"
            ParametroParaLista.Value = 4
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_IdNotaCredito"
            ParametroParaLista.Value = idNotaDeCredito
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("[Cobranza].[sp_ReporteDocTimbradoNotaDeCredito]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerUUIDEmpresaNotaDeCredito(ByVal idNotaDeCredito As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "@Accion"
            ParametroParaLista.Value = 5
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_IdNotaCredito"
            ParametroParaLista.Value = idNotaDeCredito
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("[Cobranza].[sp_ReporteDocTimbradoNotaDeCredito]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerUUIDEmpresaComplementoPago(ByVal documentoID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "@Accion"
            ParametroParaLista.Value = 1
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_complementoPagoId"
            ParametroParaLista.Value = documentoID
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("[Cobranza].[sp_ReporteDocTimbradoComplementoPago]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ActualizaSICYDoctosElectronicos(ByVal DocumentoID As Integer, ByVal TipoComprobante As String, ByVal TipoDocumento As String, ByVal Ruta As String, Optional ByVal Accion As String = "") As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "@DocumentoID"
            ParametroParaLista.Value = DocumentoID
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@TipoComprobante"
            ParametroParaLista.Value = TipoComprobante
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@TipoDocumento"
            ParametroParaLista.Value = TipoDocumento
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Ruta"
            ParametroParaLista.Value = Ruta
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@Accion"
            ParametroParaLista.Value = IIf(Accion = "", DBNull.Value, Accion)
            ListaParametros.Add(ParametroParaLista)


            Return operacion.EjecutarConsultaSP("[Ventas].[SP_Facturacion_Timbrado_ActualizarSICY_DoctosElectronicos]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerUUIDNotaDeCredito(ByVal idNotaDeCredito As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        Try
            ParametroParaLista.ParameterName = "@Accion"
            ParametroParaLista.Value = 6
            ListaParametros.Add(ParametroParaLista)

            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "@p_IdNotaCredito"
            ParametroParaLista.Value = idNotaDeCredito
            ListaParametros.Add(ParametroParaLista)

            Return operacion.EjecutarConsultaSP("[Cobranza].[sp_ReporteDocTimbradoNotaDeCredito]", ListaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerRutaServidorREST() As DataTable
        Try
            Dim operacion As New Persistencia.OperacionesProcedimientos
            Dim listaParametros As New List(Of SqlParameter)

            Return operacion.EjecutarConsultaSP("[Ventas].[SP_FacturacionCalzado_Timbrado_Configuracion_ObtenerServidorREST]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
End Class
