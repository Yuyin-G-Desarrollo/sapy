Public Class ListaBaseBU

    Public Function listaListasBase()
        Dim objLBaseDA As New Ventas.Datos.ListaBaseDA
        Return objLBaseDA.listaListasBase()
    End Function

    Public Function listaListasBaseCombo()
        Dim objLBaseDA As New Ventas.Datos.ListaBaseDA
        Return objLBaseDA.listaListasBaseCombo()
    End Function

    Public Function consecutivoCod(ByVal anio As Int32) As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.consecutivoCod(anio)
    End Function

    Public Function DatosListasBase() As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.datosListasBase()
    End Function

    Public Function guardarListaBaseNueva(ByVal enListaB As Entidades.ListaBase) As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.guardarListaBaseNueva(enListaB)
    End Function


    Public Function DatosProductos(ByVal conPrecio As Boolean, ByVal precioCero As Boolean, ByVal activos As Boolean, ByVal descontinuadosvnt As Boolean) As DataTable

        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.DatosProductos(conPrecio, precioCero, activos, descontinuadosvnt)
    End Function

    Public Sub guardarListaBaseDetalles(ByVal idListaBase As Int32, ByVal productoestiloid As Int32, ByVal precio As Decimal)
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        objLBDA.guardarListaBaseDetalles(idListaBase, productoestiloid, precio)
    End Sub

    Public Function verListaPreciosCombo() As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.verListaPreciosCombo()
    End Function

    Public Function datosPrecioBaseEditar(ByVal idListaPrecio As Int32) As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.datosPrecioBaseEditar(idListaPrecio)
    End Function

    Public Function verificarVigenciaLista() As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.verificarVigenciaLista()
    End Function

    Public Function verHistorico(ByVal codigos As String)
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.verHistorico(codigos)
    End Function

    Public Function consultaEstiloPrecio(ByVal idListaBase As Int32) As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA
        Return objLBDA.consultaEstiloPrecio(idListaBase)
    End Function

    'Public Function idMaxLPB() As DataTable
    '    Dim objLBDA As New Ventas.Datos.ListaBaseDA
    '    Return objLBDA.idMaxLPB()
    'End Function

    Public Function editarListaPrecios(ByVal idListaPrecios As Int32, ByVal comentarios As String) As DataTable
        Dim objLBDA As New Ventas.Datos.ListaBaseDA

        editarListaPrecios = New DataTable

        editarListaPrecios = objLBDA.editarListaPrecios(idListaPrecios, comentarios)

        Return editarListaPrecios
    End Function

    Public Function verListaPBase(ByVal idListaB As Int32) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.verListaPBase(idListaB)
    End Function

    Public Function verDetallesListaPrecios(ByVal idListaB As Int32, ByVal conPrecio As Boolean,
                                            ByVal precioCero As Boolean, ByVal activos As Boolean, ByVal descontinuadosvnt As Boolean) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.verDetallesListaPrecios(idListaB, conPrecio, precioCero, activos, descontinuadosvnt)
    End Function

    Public Function verProductosListasPrecios() As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.verProductosListasPrecios
    End Function

    Public Function verConsultaListaBaseAgrupada(ByVal ListaBase As Int32) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.verConsultaListaBaseAgrupada(ListaBase)
    End Function

    Public Function VerTitulosTallas(ByVal idListaBase As String) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.VerTitulosTallas(idListaBase)
    End Function

    Public Function VerModelosGrupo(ByVal idListaBase As String) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.VerModelosGrupo(idListaBase)
    End Function

    Public Sub EditarListaBase(ByVal entListBase As Entidades.ListaBase, ByVal comentario As String)
        Dim objListaBaseDA As New Datos.ListaBaseDA
        objListaBaseDA.EditarListaBase(entListBase, comentario)
    End Sub

    Public Sub EditarListaBasePrecios(ByVal idListaBase As Int32, ByVal productoestiloid As Int32,
                                      ByVal precio As Decimal, ByVal redondeo As Boolean)
        Dim objListaBaseDA As New Datos.ListaBaseDA
        objListaBaseDA.EditarListaBasePrecios(idListaBase, productoestiloid, precio, redondeo)
    End Sub

    Public Function verIdListaBase() As Int32
        Dim objListaBaseDA As New Datos.ListaBaseDA
        Return objListaBaseDA.verIdListaBase()
    End Function

    Public Function verListaPreciosActivaAutorizada() As DataTable
        Dim objListaBaseDA As New Datos.ListaBaseDA
        Return objListaBaseDA.verListaPreciosActivaAutorizada
    End Function

    Public Function verDetallesListaPreciosCliente(ByVal idListaB As Int32, ByVal idCLiente As Int32,
                                                     ByVal idListaVentasClientePrecio As Int32,
                                                     ByVal vertodo As Boolean, ByVal idListaPreciosVenta As Int32,
                                                        ByVal clienteModelosGeneralesIdLista As Int32) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.verDetallesListaPreciosCliente(idListaB, idCLiente, idListaVentasClientePrecio,
                                                     vertodo, idListaPreciosVenta, clienteModelosGeneralesIdLista)
    End Function

    'Public Function verDetallesListaPreciosClienteSOLOregistro(ByVal idListaB As Int32, ByVal idCliente As Int32,
    '                                                             ByVal idListaCliente As Int32, ByVal Incremento As Double,
    '                                                             ByVal MN_Nacional_Extranjera As Boolean,
    '                                                             ByVal Incremento_Porcentaje_Cantidad As Boolean, ByVal Paridad As Double,
    '                                                             ByVal Marcas As String,
    '                                                             ByVal ListaCompleta_o_Pedido As Boolean,
    '                                                             ByVal FechaInicioPedido As String,
    '                                                             ByVal FechaFinPedido As String
    '                                                             ) As DataTable

    '    Dim objPDA As New Ventas.Datos.ListaBaseDA
    '    Dim dtMarcaModelo As New DataTable
    '    Dim Marcaje As Integer
    '    Dim Modelaje As Integer

    '    dtMarcaModelo = objPDA.RecuperarMarcaJe_Modelaje(idCliente)

    '    For Each row As DataRow In dtMarcaModelo.Rows
    '        Marcaje = row.Item(0)
    '        Modelaje = row.Item(1)
    '    Next

    '    Return objPDA.verDetallesListaPreciosClienteSOLOregistro(idListaB, idCliente, idListaCliente, Incremento, MN_Nacional_Extranjera,
    '                                                             Incremento_Porcentaje_Cantidad, Paridad, Marcaje, Modelaje, Marcas,
    '                                                             ListaCompleta_o_Pedido, FechaInicioPedido, FechaFinPedido)
    'End Function


    Public Function consultarLimitesVigenciasPorListasVentas(ByVal idlistaBase As Int32) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.consultarLimitesVigenciasPorListasVentas(idlistaBase)
    End Function

    ''' <summary>
    ''' RECUPERA EL HISTORIAL DE LOS CAMBIS EN LOS PRODUCTOS DE LAS LSITAS DE BASE SELECCIONADAS
    ''' </summary>
    ''' <param name="hsListaCodigosListaBase">HASHSET CON CODIGOS DE LAS LSITAS DE BASE DONDE SE BUSCARA LA INFORMACION</param>
    ''' <param name="hsListaProductos">HASHSET CON  PRODUCTOS DE LOS CUALES SE CONSULTARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA </returns>
    ''' <remarks></remarks>
    Public Function RecuperarHistorialDeProductos(ByVal hsListaProductos As HashSet(Of String), ByVal hsListaCodigosListaBase As HashSet(Of String), _
                                                  ByVal hsEstiloProducto As HashSet(Of String)) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA

        Dim CodigosListaBase As String = String.Empty
        Dim Productos As String = String.Empty
        Dim IdsEstiloProducto As String = String.Empty

        For Each item In hsListaCodigosListaBase
            If CodigosListaBase = "" Then
                CodigosListaBase = item.ToString
            Else
                CodigosListaBase = CodigosListaBase + "," + item.ToString
            End If
        Next

        For Each item In hsListaProductos
            If Productos = "" Then
                Productos = "'" + item.ToString + "'"
            Else
                Productos = Productos + "," + "'" + item.ToString + "'"
            End If
        Next

        For Each item In hsEstiloProducto
            If IdsEstiloProducto = "" Then
                IdsEstiloProducto = "'" + item.ToString + "'"
            Else
                IdsEstiloProducto = IdsEstiloProducto + "," + "'" + item.ToString + "'"
            End If
        Next

        RecuperarHistorialDeProductos = objPDA.RecuperarHistorialDeProductos(CodigosListaBase, Productos, IdsEstiloProducto)

        Return RecuperarHistorialDeProductos
    End Function

    Public Function verListaPreciosBase() As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA

        verListaPreciosBase = objPDA.RecuperarListasBase()

        Return verListaPreciosBase()
    End Function

    Public Function RecuperarHistorialCliente(ByVal IdCliente As Integer) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA

        RecuperarHistorialCliente = objPDA.RecuperarHistorialCliente(IdCliente)

        Return RecuperarHistorialCliente
    End Function


    Public Function RecuperarListasBaseExistentes() As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA

        RecuperarListasBaseExistentes = objPDA.RecuperarListasBaseExistentes()

        Return RecuperarListasBaseExistentes
    End Function


    Public Function consultarListaPreciosSimulador(ByVal idListaCliente As Int32,
                                                     ByVal idCLiente As Int32,
                                                     ByVal agentes As String,
                                                     ByVal familias As Boolean,
                                                     ByVal colecciones As Boolean,
                                                     ByVal ArticulosPedidos As Boolean,
                                                     ByVal fechaInicio As String,
                                                     ByVal fechafIN As String,
                                                     ByVal Marcas As String,
                                                     ByVal IdMoneda As Integer,
                                                     ByVal Paridad As Double,
                                                     ByVal Incremento As Double,
                                                     ByVal Incremento_Porcentaje_Cantidad As Boolean) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA

        consultarListaPreciosSimulador = objPDA.consultarListaPreciosSimulador(idListaCliente, idCLiente, agentes, familias, colecciones, ArticulosPedidos,
                                     fechaInicio, fechafIN, Marcas, IdMoneda, Paridad, Incremento, Incremento_Porcentaje_Cantidad)

        Return consultarListaPreciosSimulador
    End Function

    Public Function consultaListaPreciosClientesPrecioArticulo(ByVal idListaBase As Int32, ByVal idProductoEstilo As Int32) As DataTable
        Dim objPDA As New Ventas.Datos.ListaBaseDA
        Return objPDA.consultaListaPreciosClientesPrecioArticulo(idListaBase, idProductoEstilo)
    End Function

    Public Function ConsultarResumenListaPreciosBase(ByVal idListaBase As Int16)
        Dim objDA As New Datos.ListaBaseDA
        Return objDA.ResumenListaDePreciosBase(idListaBase)
    End Function

    Public Function InsertPrecioProductoDetalles(ByVal ProductoEstiloId As String, ByVal PrecioVenta As Double, ByVal tppe_productoestiloid As String)
        Dim objDA As New Datos.ListaBaseDA
        Return objDA.InsertPrecioProductoDetalles(ProductoEstiloId, PrecioVenta, tppe_productoestiloid)

    End Function
End Class

