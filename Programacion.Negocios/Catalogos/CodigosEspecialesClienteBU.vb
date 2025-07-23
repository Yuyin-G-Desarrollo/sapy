Public Class CodigosEspecialesClienteBU
    Public Function BuscarClienteConCodsEspeciales(ByVal idCliente As Integer) As Boolean
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.BuscarClientesCodsEspeciales(idCliente)
    End Function

    Public Function ListasPreciosCliente(ByVal idCliente As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.ListasPreciosCliente(idCliente)
    End Function
    Public Function ListasPreciosClienteFechas(ByVal idLista As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.ListasPreciosClienteFechas(idLista)
    End Function
    Public Function LlenarTabla1(ByVal verProductos As Integer, ByVal conCodigo As Integer, ByVal activos As Integer,
                                 ByVal idLista As Integer, ByVal idCliente As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.LlenarTabla1(verProductos, conCodigo, activos, idLista, idCliente)
    End Function
    Public Function LlenarTabla2(ByVal verProductos As Integer, ByVal conCodigo As Integer, ByVal activos As Integer,
                                 ByVal idLista As Integer, ByVal idCliente As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.LlenarTabla2(verProductos, conCodigo, activos, idLista, idCliente)
    End Function
    Public Function CambiarEstatusInactivoCodsProdsEstilo(ByVal ids As String, ByVal motivo As String) As String
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.CambiarEstatusInactivoCodsProdsEstilo(ids, motivo)
    End Function
    Public Function InsertUpdateCodigosProductoEstilo(ByVal codigoproductoestiloid As Integer, ByVal productoestiloid As Integer, ByVal codigoprincipal As String, ByVal codigosecundario As String, ByVal clienteid As Integer) As String
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.InsertUpdateCodigosProductoEstilo(codigoproductoestiloid, productoestiloid, codigoprincipal, codigosecundario, clienteid)
    End Function
    Public Function getDigitoVerificador(ByVal digitos As String) As String
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getDigitoVerificador(digitos)
    End Function
    Public Function getTallasIdsSAY(ByVal idTalla As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getTallasIdsSAY(idTalla)
    End Function
    Public Sub InsertCodigosClientes(ByVal idCliente As Integer, ByVal productoestiloid As Integer, ByVal codigocliente As String,
                                      ByVal estilocliente As String, ByVal marcacliente As String, ByVal coleccioncliente As String,
                                      ByVal lineacliente As String, ByVal materialcliente As String, ByVal colorcliente As String,
                                      ByVal tallacliente As String)
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        datos.InsertCodigosClientes(idCliente, productoestiloid, codigocliente, estilocliente, marcacliente, coleccioncliente,
                                      lineacliente, materialcliente, colorcliente, tallacliente)
    End Sub
    Public Function getCodigosClientes(ByVal productoid As Integer, ByVal clienteid As Integer, ByVal productoestiloid As Integer, ByVal codigoECO As String, ByVal idTalla As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getCodigosClientes(productoid, clienteid, productoestiloid, codigoECO, idTalla)
    End Function
    Public Sub InactivarCodigosClientes(ByVal codigosclientesid As Integer, ByVal motivoeliminacion As String)
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        datos.InactivarCodigosClientes(codigosclientesid, motivoeliminacion)
    End Sub
    Public Function getListaIdCodigosClientes(ByVal productoEstiloID As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getListaIdCodigosClientes(productoEstiloID)
    End Function
    Public Sub UpdateCodigosClientes(ByVal codigosclientesid As Integer, ByVal productoestiloid As Integer, ByVal codigocliente As String,
                                          ByVal estilocliente As String, ByVal marcacliente As String, ByVal coleccioncliente As String,
                                          ByVal lineacliente As String, ByVal materialcliente As String, ByVal colorcliente As String,
                                          ByVal tallacliente As String)
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        datos.UpdateCodigosClientes(codigosclientesid, productoestiloid, codigocliente, estilocliente, marcacliente, coleccioncliente,
                                          lineacliente, materialcliente, colorcliente, tallacliente)
    End Sub
    ''' <summary>
    ''' Regresa DataTable de los ids de las tablas CodigosProductoEstilo y CodigosClientes(SI EXISTEN)
    ''' </summary>
    ''' <param name="productoEstiloID"></param>
    ''' <param name="idCliente"></param>
    ''' <param name="claveECO"></param>
    ''' <param name="nivel"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getIdsCodigos(ByVal productoEstiloID As String, ByVal idCliente As Integer, ByVal claveECO As String, ByVal nivel As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getIdsCodigos(productoEstiloID, idCliente, claveECO, nivel)
    End Function
    Public Function actualizarCodigoECOySecundario(ByVal codigoECO As String, ByVal CodigoSec As String, ByVal idCliente As Integer, ByVal id As Integer,
                                                   ByVal nivel As Integer) As String
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.actualizarCodigoECOySecundario(codigoECO, CodigoSec, idCliente, id, nivel)
    End Function
    Public Function validarInsercionCodigos(ByVal modeloCliente As String, ByVal color As String, ByVal piel As String, ByVal tallaInicio As String, ByVal idCliente As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.validarInsercionCodigos(modeloCliente, color, piel, tallaInicio, idCliente)
    End Function
    Public Function getAllCodigosClientes(ByVal clienteid As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getAllCodigosClientes(clienteid)
    End Function
    Public Function getDatosProductoEstilo(ByVal productoEstiloId As Integer) As DataTable
        Dim datos As New Programacion.Datos.CodigosEspecialesClienteDA
        Return datos.getDatosProductoEstilo(productoEstiloId)
    End Function
End Class
