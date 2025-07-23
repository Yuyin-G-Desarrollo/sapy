Public Class FacturacionAnticipadaBU
    Dim objDA As Datos.FacturacionAnticipadaDA

    Public Function ConsultarClientesDistribuciones() As List(Of Entidades.Cliente)
        Dim dt As DataTable
        Dim listClientes As New List(Of Entidades.Cliente)
        Dim entCliente As New Entidades.Cliente
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            dt = objDA.ConsultarClientesDistribuciones()
            For Each row As DataRow In dt.Rows
                entCliente = New Entidades.Cliente
                entCliente.clienteid = row.Item("ClienteID")
                entCliente.nombregenerico = row.Item("Cliente")
                entCliente.TipoArchivoDistribucionTiendas = row.Item("DistribucionTiendas")
                listClientes.Add(entCliente)
            Next
            Return listClientes
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarPedidosDistribucionesPorCliente(ClienteID As Integer, conDistribucion As Boolean, sinDistribucion As Boolean) As DataTable
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            Return objDA.ConsultarPedidosDistribucionesPorCliente(ClienteID, conDistribucion, sinDistribucion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarPedidoDistribucion(PedidoID As Integer) As DataTable
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            Return objDA.consultarPedidoDistribucion(PedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function insertarDistribucionArchivo_Encabezado(entDistribucion As Entidades.DistribucionPedido, usuarioID As Integer) As Integer
        objDA = New Datos.FacturacionAnticipadaDA
        Dim dt As DataTable
        Try
            dt = objDA.insertarDistribucionArchivo_Encabezado(entDistribucion, usuarioID)
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0).Item(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub insertarDistribucionArchivo_Detalle(arhivoDistribucionID As Integer, codigoRapido As String, nombreTienda As String, nPares As Integer, talla As String)
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            objDA.insertarDistribucionArchivo_Detalle(arhivoDistribucionID, codigoRapido, nombreTienda, nPares, talla)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function validarDatosArchivoImportado(archivoDistribucionID As Integer, pedidoID As Integer) As DataTable
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            Return objDA.validarDatosArchivoImportado(archivoDistribucionID, pedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub borrarDatosImportacion(archivoDistribucionID As Integer, pedidoID As Integer)
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            objDA.borrarDatosImportacion(archivoDistribucionID, pedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function insertarDistribucionPedido(ByVal entDistribucion As Entidades.DistribucionPedido, archivoDistribucionID As Integer) As DataTable
        objDA = New Datos.FacturacionAnticipadaDA
        Dim dtDistribucion As DataTable
        Try
            dtDistribucion = objDA.insertarDistribucionPedido(entDistribucion, archivoDistribucionID)
            Return dtDistribucion
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CancelarDistribucionPedido(ByVal entDistribucion As Entidades.DistribucionPedido, ByVal usuarioID As Integer)
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            objDA.CancelarDistribucionPedido(entDistribucion, usuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function consultarDistribucionOT_Detalle(OTs As String)
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            Return objDA.consultarDistribucionOT_Detalle(OTs)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarDistribucionOT(OTs As String)
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            Return objDA.consultarDistribucionOT(OTs)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function validarPedidoSinOT(pedidoID As Integer)
        objDA = New Datos.FacturacionAnticipadaDA
        Try
            Return objDA.validarPedidoSinOT(pedidoID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
