Imports System.Data.SqlClient

Public Class FacturacionAnticipadaDA
    Dim objOperacionesSAY As Persistencia.OperacionesProcedimientos
    Dim objOperacionesSICY As Persistencia.OperacionesProcedimientosSICY

    Public Function ConsultarClientesDistribuciones() As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_ConsultarClientes]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPedidosDistribucionesPorCliente(ClienteID As Integer, conDistribucion As Boolean, sinDistribucion As Boolean) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@idCliente"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@conDistribucion"
            parametro.Value = conDistribucion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@sinDistribucion"
            parametro.Value = sinDistribucion
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_ConsultarPedidosDistribuciones]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarPedidoDistribucion(PedidoID As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoSAY"
            parametro.Value = PedidoID
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_COnsultarDistribucionPedido]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function insertarDistribucionArchivo_Encabezado(entDistribucion As Entidades.DistribucionPedido, usuarioID As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_clienteid"
            parametro.Value = entDistribucion.Cliente.clienteid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_pedidosayid"
            parametro.Value = entDistribucion.PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_pedidosicyid"
            parametro.Value = entDistribucion.PedidoSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_ordencompracliente"
            parametro.Value = entDistribucion.OrdenCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_cantidadpares"
            parametro.Value = entDistribucion.ParesArchivo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_usuarioid"
            parametro.Value = usuarioID
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_InsertarInformacionArchivo_Encabezado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub insertarDistribucionArchivo_Detalle(arhivoDistribucionID As Integer, codigoRapido As String, nombreTienda As String, nPares As Integer, talla As String)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_archivodistribucionid"
            parametro.Value = arhivoDistribucionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_codigorapido"
            parametro.Value = codigoRapido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_tienda"
            parametro.Value = nombreTienda
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_pares"
            parametro.Value = nPares
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@imad_talla"
            parametro.Value = talla
            listaParametros.Add(parametro)


            objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_InsertarInformacionArchivo_Detalle]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function validarDatosArchivoImportado(archivoDistribucionID As Integer, pedidoID As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@archivoDistribucionID"
            parametro.Value = archivoDistribucionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoID"
            parametro.Value = pedidoID
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_ValidarArticulos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub borrarDatosImportacion(archivoDistribucionID As Integer, pedidoID As Integer)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@archivoDistribucionID"
            parametro.Value = archivoDistribucionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoID"
            parametro.Value = pedidoID
            listaParametros.Add(parametro)

            objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_BorrarDatosArchivoImportado]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function insertarDistribucionPedido(ByVal entDistribucion As Entidades.DistribucionPedido, archivoDistribucionID As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoID"
            parametro.Value = entDistribucion.PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@archivoDistribucionID"
            parametro.Value = archivoDistribucionID
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_InsertarDistribucionPedido]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CancelarDistribucionPedido(ByVal entDistribucion As Entidades.DistribucionPedido, ByVal usuarioID As Integer)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoID"
            parametro.Value = entDistribucion.PedidoSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ordenTrabajoID"
            parametro.Value = entDistribucion.OrdenTrabajoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@DistribucionPedidoID"
            parametro.Value = entDistribucion.DistribucionPedidoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioCancelaID"
            parametro.Value = usuarioID
            listaParametros.Add(parametro)

            objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_CancelarDustribucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarDistribucionOT_Detalle(OTs As String)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@OrdenTrabajoID"
            parametro.Value = OTs
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_ConsultarDistribucionOT_Detalle]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarDistribucionOT(OTs As String)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@OrdenTrabajoID"
            parametro.Value = OTs
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_ConsultarDistribucionOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function validarPedidoSinOT(pedidoID As Integer)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@PedidoID"
            parametro.Value = pedidoID
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_PedidoDistribucion_ValidarPedidoNoTengaOT]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
