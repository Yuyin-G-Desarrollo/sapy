Imports System.Data.SqlClient

Public Class FacturacionAnticipadaCoppelDA
    Dim objOperacionesSAY As Persistencia.OperacionesProcedimientos
    Dim objOperacionesSICY As Persistencia.OperacionesProcedimientosSICY

    Public Function ConsultarPedidosDistribucion(pedidos As String,
                                                    pedidosSICY As String,
                                                    fechaInicio As DateTime?,
                                                    fechaFin As DateTime?,
                                                    distribucionPendiente As Boolean,
                                                    distribucionCapturada As Boolean) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidos"
            parametro.Value = pedidos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidosSICY"
            parametro.Value = pedidosSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@distribucionPendiente"
            parametro.Value = distribucionPendiente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@distribucionCapturada"
            parametro.Value = distribucionCapturada
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_Consultar]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPedidosDistribucionHermanosBatta(ClienteID As Integer, conDistribucion As Boolean, sinDistribucion As Boolean, pedidosSAY As String, pedidosSICY As String) As DataTable
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

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidosSAY"
            parametro.Value = pedidosSAY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidosSICY"
            parametro.Value = pedidosSICY
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarPedidosHermanosBatta]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarDistribucion_Encabezado(ordenPedidoCliente As String,
                                                    usuarioCaptura As Integer,
                                                    pedidoSAY As Integer) As Integer
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim idGenerado As Integer = 0
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ordenPedidoCliente"
            parametro.Value = ordenPedidoCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioCapturaId"
            parametro.Value = usuarioCaptura
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoSAY"
            parametro.Value = pedidoSAY
            listaParametros.Add(parametro)

            idGenerado = CInt(objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_RegistrarDistribucion_Encabezado]", listaParametros).Rows(0)(0).ToString)

        Catch ex As Exception
            Throw ex
        End Try

        Return idGenerado
    End Function

    Public Function InsertarDistribucion(distribucionpedidoid As Integer,
                                         ordenpedidocliente As String,
                                         codigo As String,
                                         modelo As Integer,
                                         talla As Integer,
                                         destino As String,
                                         cantidadPedida As Integer,
                                         cantidadSurtida As Integer,
                                         usuariocapturaid As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@distribucionPedidoId"
            parametro.Value = distribucionpedidoid
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ordenPedidoCliente"
            parametro.Value = ordenpedidocliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@codigo"
            parametro.Value = codigo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@modelo"
            parametro.Value = modelo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@talla"
            parametro.Value = talla
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@destino"
            parametro.Value = destino
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cantidadPedida"
            parametro.Value = cantidadPedida
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cantidadSurtida"
            parametro.Value = cantidadSurtida
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioCapturaId"
            parametro.Value = usuariocapturaid
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_RegistrarDistribucion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function InsertarDistribucion_CargarInformacionFaltante(distribucionpedidoid As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@distribucionPedidoId"
            parametro.Value = distribucionpedidoid
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_RegistrarDistribucion_CargarInformacionFaltante]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarOT(pedidoId As Integer) As Integer
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim cantidadOT As Integer = 0
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoSay"
            parametro.Value = pedidoId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioCapturaId"
            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listaParametros.Add(parametro)

            cantidadOT = CInt(objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_FacturacionCalzado_Coppel_GenerarOT]", listaParametros).Rows(0)(0))
        Catch ex As Exception
            Throw ex
        End Try

        Return cantidadOT
    End Function

    Public Function ObtenerInformacionReportePlaneacion(opcionFiltro As Integer, tipoReporte As Boolean, tipoPedidos As Integer, anio As Integer, semanaInicio As Integer, semanaFin As Integer, fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        'objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        objOperacionesSICY = New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim dtResultado As New DataTable
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@opcionFiltro"
            parametro.Value = opcionFiltro
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoReporte"
            parametro.Value = tipoReporte
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipoPedidos"
            parametro.Value = tipoPedidos
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = anio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@semanaInicio"
            parametro.Value = semanaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@semanaFin"
            parametro.Value = semanaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaInicio"
            parametro.Value = fechaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaFin"
            parametro.Value = fechaFin
            listaParametros.Add(parametro)

            dtResultado = objOperacionesSICY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarReportePlaneacion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtResultado
    End Function

    Public Function ConsultarEmpaqueArticulos(articulosEmpaque As String) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@articulosEmpaque"
            parametro.Value = articulosEmpaque
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarEmpaqueArticulos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarOTGeneradas(pedidoSAY As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoSAY"
            parametro.Value = pedidoSAY
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarOTGeneradas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDetallePares(pedidoSAY As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@pedidoSAY"
            parametro.Value = pedidoSAY
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarDetallePares]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDocumentosActivos(ordenTrabajo As String) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@ordenTrabajo"
            parametro.Value = ordenTrabajo
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarDocumentosActivos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarConfirmacionDocumento(documentoId As Integer) As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@documentoId"
            parametro.Value = documentoId
            listaParametros.Add(parametro)

            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_ConsultarConfirmacionDocumento]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarBodegas() As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_BodegaTiendas_ConsultarBodegas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTiendas() As DataTable
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            Return objOperacionesSAY.EjecutarConsultaSP("[Ventas].[SP_DistribucionTiendasCoppel_BodegaTiendas_ConsultarTiendas]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub RegistrarBodegaTienda(idBodega As Integer, nombreBodega As String, idTiendas As String)
        objOperacionesSAY = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try

            parametro = New SqlParameter
            parametro.ParameterName = "@idBodega"
            parametro.Value = idBodega
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nombreBodega"
            parametro.Value = nombreBodega
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@idTiendas"
            parametro.Value = idTiendas
            listaParametros.Add(parametro)

            objOperacionesSAY.EjecutarSentenciaSP("[Ventas].[SP_DistribucionTiendasCoppel_BodegaTiendas_RegistrarBodegaTienda]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
