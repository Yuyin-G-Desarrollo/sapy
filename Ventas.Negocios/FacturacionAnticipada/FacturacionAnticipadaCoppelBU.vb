Public Class FacturacionAnticipadaCoppelBU

    Dim objDA As Datos.FacturacionAnticipadaCoppelDA

    Public Function ConsultarPedidosDistribucion(pedidos As String,
                                                    pedidosSICY As String,
                                                    fechaInicio As DateTime?,
                                                    fechaFin As DateTime?,
                                                    distribucionPendiente As Boolean,
                                                    distribucionCapturada As Boolean
                                                    ) As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarPedidosDistribucion(pedidos, pedidosSICY, fechaInicio, fechaFin, distribucionPendiente, distribucionCapturada)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPedidosDistribucionHermanosBatta(ClienteID As Integer, conDistribucion As Boolean, sinDistribucion As Boolean, pedidosSAY As String, pedidosSICY As String) As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            Return objDA.ConsultarPedidosDistribucionHermanosBatta(ClienteID, conDistribucion, sinDistribucion, pedidosSAY, pedidosSICY)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarDistribucion_Encabezado(ordenPedidoCliente As String,
                                                    usuarioCaptura As Integer,
                                                    pedidoSAY As Integer) As Integer
        Dim idDistribucionEncabezado As Integer
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            idDistribucionEncabezado = objDA.InsertarDistribucion_Encabezado(ordenPedidoCliente, usuarioCaptura, pedidoSAY)
            Return idDistribucionEncabezado
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarDistribucion(distribucionpedidoid As Integer,
                                         distribucion As Entidades.DistribucionPedidoCoppel,
                                         usuariocapturaid As Integer) As DataTable
        'ordenpedidocliente As String,
        'codigo As Integer,
        'modelo As Integer,
        'talla As Integer,
        'destino As String,
        'cantidadPedida As Integer,
        'cantidadSurtida As Integer,
        'usuariocapturaid As Integer
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.InsertarDistribucion(distribucionpedidoid,
                                            distribucion.OrdenCliente,
                                            distribucion.CodigoRapidoCliente,
                                            CInt(distribucion.Modelo),
                                            CInt(distribucion.Talla),
                                            distribucion.Destino,
                                            distribucion.CantidadPedida,
                                            distribucion.CantidadSurtida,
                                            usuariocapturaid)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarDistribucion_CargarInformacionFaltante(distribucionpedidoid As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.InsertarDistribucion_CargarInformacionFaltante(distribucionpedidoid)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GenerarOT(pedidoId As Integer) As Integer
        Dim dt As Integer
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.GenerarOT(pedidoId)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerInformacionReportePlaneacion(opcionFiltro As Integer, tipoReporte As Boolean, tipoPedidos As Integer, anio As Integer, semanaInicio As Integer, semanaFin As Integer, fechaInicio As DateTime, fechaFin As DateTime) As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ObtenerInformacionReportePlaneacion(opcionFiltro, tipoReporte, tipoPedidos, anio, semanaInicio, semanaFin, fechaInicio, fechaFin)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEmpaqueArticulos(articulosEmpaque As String) As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarEmpaqueArticulos(articulosEmpaque)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarOTGeneradas(pedidoSAY As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarOTGeneradas(pedidoSAY)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDetallePares(pedidoSAY As Integer) As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarDetallePares(pedidoSAY)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDocumentosActivos(ordenTrabajo As String) As Boolean
        Dim dt As DataTable
        Dim correcto As Boolean = 0
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarDocumentosActivos(ordenTrabajo)
            correcto = dt.Rows(0)(0)

            Return correcto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarConfirmacionDocumento(documentoId As Integer) As Boolean
        Dim dt As DataTable
        Dim correcto As Boolean = 0
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarConfirmacionDocumento(documentoId)
            correcto = dt.Rows(0)(0)

            Return correcto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarBodegas() As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarBodegas()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTiendas() As DataTable
        Dim dt As DataTable
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            dt = objDA.ConsultarTiendas()
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub RegistrarBodegaTienda(idBodega As Integer, nombreBodega As String, idTiendas As String)
        objDA = New Datos.FacturacionAnticipadaCoppelDA
        Try
            objDA.RegistrarBodegaTienda(idBodega, nombreBodega, idTiendas)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
