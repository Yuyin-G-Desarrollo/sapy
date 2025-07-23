
Public Class EntradaProductoBU

    ''' <summary>
    ''' RECUPERA EL ESTADO DE UNA SALIDA DE NAVE DEACUERDO A SU COLUMNA DE IDENTIFICACION, SÍ NO ENCUENTRA NINGUNA SALIDA DE NAVE QUE CONCUERDE CON EL ID_INGRESADO
    ''' REGRESA UNA CADENA CON EL VALOR "INVALIDO", SÍ EL ESTADO ESTA "EN PROCESO" REGRESA EL MISMO ESTADO EN LA CADENA, SÍ EL ESTADO ESTA EN "EMBARCADO" REGRESA
    ''' UNA CADENA CON EL MISMO ESTADO, SÍ EL ESTADO ESTA COMO "ENTREGADO" REGRESA UNA CADENA CON EL MISMO ESTADO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A VERIFICAR</param>
    ''' <returns>ESTADO DE LA SALIDA DE NAVE ENCONTRADA</returns>
    ''' <remarks></remarks>
    Public Function VerificarSalidaNaveEmbarcada(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDA.VerificarSalidaNaveEmbarcada(IdSalidaNave, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' ACTUALIZA EL ESTADO DE UNA SALIDA DE NAVE CUANDO COMIENZAN CON EL PROCESO DE DALE INGRESO AL ALMACEN
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A INGRESAR</param>
    ''' <remarks></remarks>
    Public Sub ActualizarEstatus_SalidaNave_ParaElComienzoDelEscaneo(ByVal IdSalidaNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        objDA.ActualizarEstatus_SalidaNave_ParaElComienzoDelEscaneo(IdSalidaNave)
    End Sub

    ' ''' <summary>
    ' ''' RECUPERA TODOS LOS PARES INCLUIDOS UNA DETERMINADA SALIDA DE NAVE
    ' ''' </summary>
    ' ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARAN SUS PARES CON SU INFORMACION</param>
    ' ''' <returns>DATATABLE CON LOS PARES PERTENECIENTES A LA SALIDA DENAVE CON LA QUE SE ESTA TRABAJANDO</returns>
    ' ''' <remarks></remarks>
    'Public Function RecuperarInformacionDeLotesEmbarcados_Pares_Leidos(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
    '    Dim objDA As New Datos.EntradaProductoDA
    '    Dim dtTabla As New DataTable
    '    dtTabla = objDA.RecuperarInformacionDeLotesEmbarcados_Pares_Leidos(IdSalidaNave, IdNave)
    '    Return dtTabla
    'End Function

    ''' <summary>
    ''' RECUPERA UN VALOR NULLO CON EL TITULO DE QUITAR, EL LOTE, NUMERO DE ATADO, ATADO, DESCRIPCION DE ATADO, 0 CON EL TITULO DE ESTADO Y  AÑO DE TODOS LOS ATADOS 
    ''' INCLUIDOS EN UNA SALIDA DE NAVES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarInformacionDeLotesEmbarcados_Atados_Leidos(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.RecuperarInformacionDeLotesEmbarcados_Atados_Leidos(IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES, ATADOS Y LOTES EMBARCADOS EN UNA SALIDA DE NAVE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES DE LA CUAL SE RECUPERARA INFORMACION</param>
    ''' <returns>DATATABLE CON LOS TOTALES</returns>
    ''' <remarks></remarks>
    Public Function RecuperarTotalesdeSalidaNaveEmbarcada(ByVal IdSalidaNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.RecuperarTotalesdeSalidaNaveEmbarcada(IdSalidaNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA EJECUTAR LA CONSULTA Y VALIDAR QUE UN ATADO PERTENECE A UNA SALIDA DE NAVE 
    ''' </summary>
    ''' <param name="Atado">ATADO QUE SE VERIFICARA</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE BUSCARA EL ATADO</param>
    ''' <returns>ID DEL ATADO (EN CASO DE HABER SIDO ENCONTRADO)</returns>
    ''' <remarks></remarks>
    Public Function ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso(ByVal Atado As String, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso(Atado, IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA EJECUTAR LA CONSULTA QUE RECUPERA LOS PARES Y CARACTERISTICAS(ATADO, PAR, TALLA, CODIGO CLIENTE, ESTADO, DESCRIPCION, CLAVE DEL PRODUCTO,
    '''  NUMERO DE PAR) DE LOS MISMOS, DE UN ATADO EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdAtado">ID DEL ATADO DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA QUE SE RECUPERARA LA INFORMACIÓN</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles(ByVal IdAtado As String, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles(IdAtado, IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA EJECUTAR LA CONSULTA PARA ELIMINAR LOS PARES CON ESTADO DE SOBRANTE DE UN ATADO EN ESPECIFICO PARA VOLVERLO A ESCANEAR
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="AtadoActual">ATADO DEL CUAL SE ELIMINARAN LOS PARES SOBRANTES EN CASO DE EXISTIR
    ''' </param>
    ''' <remarks></remarks>
    Public Sub Eliminar_ParesSobrantes_De_Atado_SalidaNavesDetalles(ByVal IdSalidaNave As Integer, ByVal AtadoActual As String, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        objDA.Eliminar_ParesSobrantes_De_Atado_SalidaNavesDetalles(IdSalidaNave, AtadoActual, IdNave)
    End Sub

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA ACTUALIZAR EL ESTADO DE LA UN ATADO ESPECIFICO A "CON FALTANTE", Y LOS RESULTADOS DE LOS PARES DE ESE ATADO EN BLANCO PARA
    ''' VOLVERLOS A ESCANEAR
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE</param>
    ''' <param name="AtadoActual">ATADO EN EL CUAL SE ACTUALIZARA LA INFORMACION</param>
    ''' <remarks></remarks>
    Public Sub Eliminar_Estado_De_Pares_Atado_Para_Entrada_De_Producto_SalidaNavesDetalles(ByVal IdSalidaNave As Integer, ByVal AtadoActual As String, ByVal LoteCompleto As String, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        objDA.Eliminar_Estado_De_Pares_Atado_Para_Entrada_De_Producto_SalidaNavesDetalles(IdSalidaNave, AtadoActual, LoteCompleto, IdNave)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS PARES DE UNA ENTRADA DEPRODUCTO EN PROCESO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES A RECUPERAR LOS PARES</param>
    ''' <returns>TABLA CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperaParesDeEntradaLotesEnProceso(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.RecuperaParesDeEntradaLotesEnProceso(IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA LOS ATADOS YA LEEIDOS E INCLUIDOS EN LA TABLA Almacen.SALIDANAVESDETALLES CON SU ESTADO Y SU LOTE CORRESPONDIENTE PARA ACTUALIZAR LA TABLA DE GRID ERRONEOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A RECUPERAR INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves_Entrada_De_Producto(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTabla = objDA.RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves_Entrada_De_Producto(IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' ACTUALIZA EL ESTADO DE LOS PARES DEL UN LOTE DETERMINADO A "REGRESADO"
    ''' </summary>
    ''' <param name="IdSAlidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ENCUENTRA EL LOTE</param>
    ''' <param name="llotes">LOTE A ACTUALIZAR</param>
    ''' <param name="IdNave">NAVE DEL LOTE</param>
    ''' <remarks></remarks>
    Public Sub DescarTarPares_Entrada_De_Producto(ByVal IdSAlidaNave As Integer, ByVal llotes As HashSet(Of String), ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim lotes() As String

        For Each item In llotes
            lotes = item.Split("-")
            objDA.DescarTarPares_Entrada_De_Producto(IdSAlidaNave, lotes(0), lotes(1), IdNave)
        Next
    End Sub

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA CAMBIAR EL TIPO DE CODIGO UNICO AL CODIGO DE CLIENTE QUE LE CORRESPONDE 
    ''' </summary>
    ''' <param name="Id_Salida">ID DE LA SALIDA DE NAVE EN LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Atado">ATADO EN EL CUAL SE ACTUALIZARAN LOS PARES</param>
    ''' <param name="dtPares">DATATABLE CON LOS CODIGOS DE CLIENTE CORRESPONDIENTE PARA CADA CODIGO DE PAR UNICO</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar(ByVal Id_Salida As Integer, ByVal Atado As String,
                                                                                                   ByVal dtPares As DataTable, ByVal IdNave As Integer)
        Dim objDAEntrada As New Datos.EntradaProductoDA
        Dim Codigo_Unico As String
        Dim Codigo_Cliente As String

        For Each row As DataRow In dtPares.Rows
            Codigo_Cliente = row.Item("CODIGO_CLIENTE")
            Codigo_Unico = row.Item("PAR")
            objDAEntrada.Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar(Id_Salida, Atado, Codigo_Unico, Codigo_Cliente, IdNave)
        Next
    End Sub

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA ACTUALIZAR EL CAMPO PARA PARES DEVUELTOS EN 0 Y EL CAMPO PARA PARES ENTREGADOS EN 1 PARA TODOS LOS PARES DE UN LOTE
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Lote">LOTE EN EL CUAL SE ACTUALIZARAN LOS PARES</param>
    ''' <param name="Año">AÑO DEL LOTE QUE SE ACTUALIZARA</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_Estado_De_Pares_Del_Lote_A_Entregado(ByVal IdSalidaNave As Integer, ByVal Lote As Integer, ByVal Año As Integer, ByVal Tipo_Nave As Boolean, ByVal IdNave As Integer)
        Dim objDAEntrada As New Datos.EntradaProductoDA
        objDAEntrada.Actualizar_Estado_De_Pares_Del_Lote_A_Entregado(IdSalidaNave, Lote, Año, Tipo_Nave, IdNave)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES LEIDOS, LOS TOTALES DE PARES QUE SE TENIAN QUE LEER, LOS TOTALES DE PARES REGRESADOS, LOS TOTALES DE PARES INGRESADOS, EL TOTAL DE PARES NO LEIDOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE OBTENDRAN LAS CANTIDADES</param>
    ''' <returns>DATATABLE CON LAS CANTIDADES OBTENIDOAS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Entrada_De_Nave_En_Proceso(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDAEntradaProducto As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDAEntradaProducto.Recuperar_Totales_Entrada_De_Nave_En_Proceso(IdSalidaNave, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' PROCEDIMIENTO ALMACENADO EN EL QUE SE ACTUALIZA EL ESTADO DE ENTRADA AL ALMACEN DE 0 A 1 EN LA TABLA TMPDOCENASPARES PARA LOS OARES QUE SE RECIBIERON ADEMAS DE LA FECHA EN LA QUE ESNTRARON
    ''' , TAMBIEN SE ASIGNAN LAS PLATAFORMAS(CARRITOS) CON SU CONTENIDO A LAS TABLAS OCUPACIONCARRITOS Y OCUPACIONCARRITOSLOTES, Y FINALMENNTE SE ACTUALIZA LA TABLA SALIDANAVES PARA CONCLUIR EL 
    ''' PROCESO DE ENTRADA
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Tipo_Nave">TIPO DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="ParesEntregados">CANTIDAD DE PARES A LOS QUE SE LES DIO ENTRADA</param>
    ''' <param name="AtadosEntregados">CANTIDAD DE ATADOS A LOS QUE SE LES DIO ENTRADA</param>
    ''' <param name="LotesEntregados">CANTIDAD DE LOSTES A LOS QUE SE LES DIO ENTRADA</param>
    ''' <param name="ParesRegresados">CANTIDAD DE PARES QUE SE REGRESARON</param>
    ''' <param name="AtadosRegresados">CANTIDAD DE ATADOS QUE SE REGRESARON</param>
    ''' <param name="LotesRegresados">CANTIDAD DE LOTES REGRESADOS</param>
    ''' <returns>TABLA CON UNA CELDA CON EL MENSAJE "EXITO" O "ERROR", DEPENDIENDO DE SI HUBO O NO ERRORES EN LA EJECUCION DE PROCEDIMIENTO ALMACENADO</returns>
    ''' <remarks></remarks>
    Public Function FinalizarEntradaProducto(ByVal IdSalidaNave As Integer, ByVal Tipo_Nave As Boolean, ByVal ParesEntregados As Integer, ByVal AtadosEntregados As Integer, _
                                              ByVal LotesEntregados As Integer, ByVal ParesRegresados As Integer, ByVal AtadosRegresados As Integer,
                                              ByVal LotesRegresados As Integer, ByVal IdNave As Integer)
        Dim objDAEntrada As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDAEntrada.FinalizarEntradaProducto(IdSalidaNave, Tipo_Nave, ParesEntregados, AtadosEntregados, LotesEntregados, ParesRegresados, _
                                                        AtadosRegresados, LotesRegresados, IdNave)


        Return dtTabla
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA VALIDAR SI UN ID DE CARRITO EXISTE Y ESTA ACTIVO
    ''' </summary>
    ''' <param name="IdCarrito">ID DEL CARRITO A CHECAR</param>
    ''' <returns>VALOR BOLEANO TRUE PARA CODIGO VALIDO Y FALSE PARA CODIGO INVALIDO</returns>
    ''' <remarks></remarks>
    Public Function ValidarCarritoPerteneciente_a_Nave(ByVal IdCarrito As Integer, ByVal IdNave_Almacen As Integer, ByVal IdAlmacen As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtCarritoValido As New DataTable

        dtCarritoValido = objDA.ValidarCarritoPerteneciente_a_Nave(IdCarrito, IdNave_Almacen, IdAlmacen)

        For Each row As DataRow In dtCarritoValido.Rows
            If row.Item(0) = 0 Then
                Return False
            Else
                Return True
            End If
        Next
    End Function

    ''' <summary>
    ''' RECUPERA LA CANTIDAD DE ATADOS EMBARCADOS REGISTRADA EN LA TABLA ALMACEN.SALIDANAVES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES DE LA CUAL SE RECUPERARA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCantidadDeAtadosEmbarcados(ByVal IdSalidaNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTotalAtadosEmbarcados As New DataTable
        dtTotalAtadosEmbarcados = objDA.RecuperarCantidadDeAtadosEmbarcados(IdSalidaNave)
        Return dtTotalAtadosEmbarcados
    End Function

    ''' <summary>
    ''' RECUPERA LOS EXISTENTES DE CLIENTES, TIENDAS, CORRIDAS Y PRODUCTOS SEGUN SEA EL CASO REQUERIDO
    ''' </summary>
    ''' <param name="IdParametro">ID DEL CASO PARA LA CONSULTA
    ''' 1.- CLIENTES
    ''' 2.- TIENDAS
    ''' 3.- CORRIDAS
    ''' 4.- PRODUCTOS</param>
    ''' <returns>DATATABLE CON LA INFORMACION OBTENIDA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarInformacionDelParametro(ByVal IdParametro As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTablaParametros As New DataTable
        dtTablaParametros = objDA.RecuperarInformacionDelParametro(IdParametro)
        Return dtTablaParametros
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA RECUPERAR LA INFORMACION DE LA SALIDA DE NAVES DEACUERDO A CIERTOS FILTROS
    ''' </summary>
    ''' <param name="lLotes">LOTES EN LOS QUE SE BUSCARA </param>
    ''' <param name="lAtados"> ATADOS EN LOS QUE SE BUSCARA </param>
    ''' <param name="lPedidos"> PEDIDOS EN LOS QUE SE BUSCARA </param>
    ''' <param name="lProductos"> ID DE LOS PRODUCTOS EN LOS QUE SE BUSCARA </param>
    ''' <param name="lClientes"> IDS DE LOS CLIENTES EN LOS QUE SE BUSCARA </param>
    ''' <param name="lCorridas"> IDS DE LAS CORRIDAS EN LAS QUE SE BUSCARA </param>
    ''' <param name="lTiendas"> IDS DE LAS TIENDAS EN LAS QUE SE BUSCARA </param>
    ''' <param name="lNave"> IDS DE LAS NAVES EN LAS QUE SE BUSCARA</param>
    ''' <param name="fechaInicioEntradas"> FECHA DE INICIO DE ENTRADAS(RANGO) </param>
    ''' <param name="fechaTerminoEntradas"> FECHA DE FIN DE ENTRADAS(RANGO)</param>
    ''' <param name="fechaInicioProgramas"> FECHA DE INICIO DE PROGRAMA(RANGO)</param>
    ''' <param name="fechaTerminoProgramas"> FECHA DE FIN DE PROGRAMA(RANGO)</param>
    ''' <param name="bY_O">BOOLEANO TRUE PARA BUSCAR CON CONDICION AND, FALSE PARA BUSCAR CON CONDICION OR</param>
    ''' <param name="filtroFechaPrograma"> VALOR BOOLEANO, TRUE PARA FILTRAR POR FECHA DE PROGRAMA, FALSE PARA NO. </param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA </returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaDeSalidas(ByVal Ubicacio_Y_N As Boolean, ByVal lTallas As String, ByVal lLotes As String, ByVal lAtados As String,
                                            ByVal lPedidos As String, ByVal lProductos As String,
                                            ByVal lClientes As String, ByVal lCorridas As String, ByVal lTiendas As String, ByVal lNave As String,
                                            ByVal fechaInicioEntradas As String, ByVal fechaTerminoEntradas As String, ByVal fechaInicioProgramas As String,
                                            ByVal fechaTerminoProgramas As String, ByVal bY_O As Boolean, ByVal filtroFechaPrograma As Boolean, ByVal EsPedidoActual As Boolean, ByVal EsClienteActual As Boolean) As DataTable
        Dim objEntradaDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objEntradaDA.RecuperarListaDeSalidas(Ubicacio_Y_N, lTallas, lLotes, lAtados, lPedidos, lProductos, lClientes, lCorridas, lTiendas, lNave,
                                                                fechaInicioEntradas, fechaTerminoEntradas, fechaInicioProgramas,
                                                                fechaTerminoProgramas, bY_O, filtroFechaPrograma, EsPedidoActual, EsClienteActual)

        Return dtTabla
    End Function

    Public Function ConsultaEntradasAlmacen(ByVal Filtros As Entidades.EntradasAlmacen)
        Dim objEntradaDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objEntradaDA.ConsultaEntradasAlmacen(Filtros)

        Return dtTabla
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Ubicacio_Y_N"></param>
    ''' <param name="lTallas"></param>
    ''' <param name="lLotes"></param>
    ''' <param name="lAtados"></param>
    ''' <param name="lPedidos"></param>
    ''' <param name="lProductos"></param>
    ''' <param name="lClientes"></param>
    ''' <param name="lCorridas"></param>
    ''' <param name="lTiendas"></param>
    ''' <param name="lNave"></param>
    ''' <param name="fechaInicioEntradas"></param>
    ''' <param name="fechaTerminoEntradas"></param>
    ''' <param name="fechaInicioProgramas"></param>
    ''' <param name="fechaTerminoProgramas"></param>
    ''' <param name="bY_O"></param>
    ''' <param name="filtroFechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaDetallesProductos(ByVal Ubicacio_Y_N As Boolean, ByVal lTallas As String, ByVal lLotes As String, ByVal lAtados As String,
                                            ByVal lPedidos As String, ByVal lProductos As String,
                                            ByVal lClientes As String, ByVal lCorridas As String, ByVal lTiendas As String, ByVal lNave As String,
                                            ByVal fechaInicioEntradas As String, ByVal fechaTerminoEntradas As String, ByVal fechaInicioProgramas As String,
                                            ByVal fechaTerminoProgramas As String, ByVal bY_O As Boolean, ByVal filtroFechaPrograma As Boolean, ByVal ComercializadoraId As Integer) As DataTable
        Dim objEntradaDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objEntradaDA.RecuperarListaDetallesProductos(Ubicacio_Y_N, lTallas, lLotes, lAtados, lPedidos, lProductos, lClientes, lCorridas, lTiendas, lNave,
                                                                fechaInicioEntradas, fechaTerminoEntradas, fechaInicioProgramas,
                                                                fechaTerminoProgramas, bY_O, filtroFechaPrograma, ComercializadoraId)

        Return dtTabla
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="lNave"></param>
    ''' <param name="fechaInicioEntradas"></param>
    ''' <param name="fechaTerminoEntradas"></param>
    ''' <param name="bY_O"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaDetallesProductosConImporte(ByVal lNave As String, ByVal fechaInicioEntradas As String,
                                                              ByVal fechaTerminoEntradas As String, ByVal bY_O As Boolean, ByVal Coleccion As Boolean,
                                                              ByVal Modelo As Boolean, ByVal Talla As Boolean, ByVal Color As Boolean, ByVal ComercializadoraID As Integer) As DataTable
        Dim objEntradaDA As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objEntradaDA.RecuperarListaDetallesProductosConImporte(lNave, fechaInicioEntradas,
                                                               fechaTerminoEntradas, bY_O, Coleccion,
                                                               Modelo, Talla, Color, ComercializadoraID)

        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES RECIBIDOS EN UNA NAVE EN ESPECIFICO EN UN RANGO DE FECHAS.
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA QUE SE BUSCARAN LAS ENTRADAS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Recibidos(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objDAEntradas As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDAEntradas.Recuperar_Totales_Recibidos(Fecha_Inicio, Fecha_Fin, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES NO EMBARCADOS ESCANEADOS DURANTE EL PROCESO DE ENTRADA DE LOTES A ALMACÉN DE UNA NAVE EN ESPECIFICO
    ''' DENTRO DE UN RANGO DE FECHAS
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA CUAL SE BUSCARAN LAS ENTRADAS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_No_Embarcados(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objDAEntradas As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDAEntradas.Recuperar_Totales_No_Embarcados(Fecha_Inicio, Fecha_Fin, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES QUE SE EMBARCARON PERO NO SE RECIBIERON EN EL PROCESO DE ENTRADA DE LOTES DE UNA NAVE EN ESPECIFICO DENTRO DE UN 
    ''' RANGO DE FECHAS
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE EN LA QUE SE REALIZARA LA BUSQUEDA</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Faltantes(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objDAEntradas As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDAEntradas.Recuperar_Totales_Faltantes(Fecha_Inicio, Fecha_Fin, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA EL NOMBRE DEL OPERADOR DEACUERDO AL ID DE USUARIO QUE ESTA GUARDADO EN EL ULTIMO REGISTRO GUARDADO EN LA TABLA SALIDANAVES DE LA BASE DE DATOS DEL SISY PARA UNA NAVE EN ESPECIFICO
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA BUSQUEDA</param>
    ''' <returns>CADENA CON EL NOMBRE RECUPERADO</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Nombre_Operador_ReporteEntradas(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer) As String
        Dim objDAEntradas As New Datos.EntradaProductoDA
        Dim dtTabla As New DataTable

        dtTabla = objDAEntradas.Recuperar_Nombre_Operador_ReporteEntradas(Fecha_Inicio, Fecha_Fin, IdNave)

        Return dtTabla.Rows(0).Item("Operador")
    End Function

    ''' <summary>
    ''' RECUPERA TODA LA INFORMACION DE LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE PARA POBLAR EL GRID DE LA CAPA VISTA
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function PoblarGridConfiguracionDeValidaciones() As DataTable
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtConfiguracionEntradas_Y_Salidas As New DataTable

        dtConfiguracionEntradas_Y_Salidas = objDA.PoblarGridConfiguracionDeValidaciones

        Return dtConfiguracionEntradas_Y_Salidas
    End Function

    ''' <summary>
    ''' CONSULTA LAS CADENAS ACTIIVAS EN LA TABLA CADENAS
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaDeCadenasActivas() As DataTable
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtClientes_Cadenas As New DataTable

        dtClientes_Cadenas = objDA.ListaDeCadenasActivas

        Return dtClientes_Cadenas
    End Function

    ''' <summary>
    ''' REALIZA EL PROCESO PARA ACTUALIZAR LOSDATOS DE LA TABLA ALMACEN.CONFIGURACIONVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdConfiguracionEmbarque">ID DE EL REGISTRO QUE SE ACTUALIZARA</param>
    ''' <param name="Entrada">VALOR BOOLEANO PARA VALIDAR ENTRADAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <param name="Salida">VALOR BOOLEANO PARA VALIDAR SALIDAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <remarks></remarks>
    Public Sub EditarRegistroConfiguracionDeEmbarques(ByVal IdConfiguracionEmbarque As Integer, ByVal Entrada As Boolean, ByVal Salida As Boolean)
        Dim objDA As New Datos.EntradaProductoDA
        objDA.EditarRegistroConfiguracionDeEmbarques(IdConfiguracionEmbarque, Entrada, Salida)
    End Sub

    ''' <summary>
    ''' INACTIVA UN REGISTRO EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdRegistro">ID DEL REGISTRO A ACTUALIZAR</param>
    ''' <remarks></remarks>
    Public Sub DesactivarRegistro(ByVal IdRegistro As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        objDA.DesactivarRegistro(IdRegistro)
    End Sub

    ''' <summary>
    ''' INSERTA REGISTROS EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdCliente">ID CLIENTE QUE SE VALIDARA</param>
    ''' <param name="Entrada">VALOR BOOLEANO PARA VALIDAR ENTRADAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <param name="Salida">VALOR BOOLEANO PARA VALIDAR SALIDAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <param name="NaveId">ID DE LA NAVE EN LA QUE SE VALDIARA EL CLIENTE</param>
    ''' <remarks></remarks>
    Public Sub AgregarRegistroConfiguracionDeEmbarques(ByVal IdCliente As Integer, ByVal Entrada As Boolean, ByVal Salida As Boolean, ByVal NaveId As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        objDA.AgregarRegistroConfiguracionDeEmbarques(IdCliente, Entrada, Salida, NaveId)
    End Sub

    ''' <summary>
    ''' RECUPERA EL RESULTADO DE CONSULTAR SI UN REGISTRO EXISTE EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A VERIFICAR</param>
    ''' <param name="IdCliente">ID DEL CLIENTE A VERIFICAR</param>
    ''' <returns>DATATABLE CON EL RESULTADO OBTENIDO</returns>
    ''' <remarks></remarks>
    Public Function ValidarRegistrosExistentes(ByVal IdNave As Integer, ByVal IdCliente As Integer) As DataTable
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtRegistrosExistentes As New DataTable

        dtRegistrosExistentes = objDA.ValidarRegistrosExistentes(IdNave, IdCliente)

        Return dtRegistrosExistentes
    End Function

    ''' <summary>
    ''' ACTIVA UN REGISTRO EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE Y MODIFICA LOS VALORES DE LAS VALIDACIONES DE ENTRADAS Y SALIDAS PAR POR PAR
    ''' </summary>
    ''' <param name="IdRegistro">ID DEL REGISTRO A ACTIVAR</param>
    ''' <param name="Entrada">VALOR DE LA ENTRADA A MODIFICAR</param>
    ''' <param name="Salida">VALOR DE LA ENTRADA A ACTIVAR</param>
    ''' <remarks></remarks>
    Public Sub ActivarRegistroDeValidacion(ByVal IdRegistro As Integer, ByVal Entrada As Boolean, ByVal Salida As Boolean)
        Dim objDA As New Datos.EntradaProductoDA

        objDA.ActivarRegistroDeValidacion(IdRegistro, Entrada, Salida)
    End Sub

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LA INFORMACION DE LOS CARRITOS POBLADOS Y SU CONTENIDO EN UNA ENTRADA DE NAVE
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA ENTRADA DE NAVE DE LA CUAL SE RECUPERARAN LOS CARRITOS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function PoblarDetalleCarritos(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTablaDetalleCarritos As New DataTable

        dtTablaDetalleCarritos = objDA.PoblarDetalleCarritos(IdSalidaNave, IdNave)

        Return dtTablaDetalleCarritos
    End Function


    Public Function AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada(ByVal IdSalidaNave As Integer, ByVal Id_Nave As Integer, ByVal Año As Integer, _
                                                                         ByVal Lote As Integer, ByVal Proceso As String, ByVal TipoCodigo As String, _
                                                                         ByVal Tipo_Nave_Maquila_o_Interna As Boolean, ByVal Atado_Incluido_SalidaNave_en_Curso As Boolean, _
                                                                         ByVal ResultadoLoteCompleto As Boolean)

        Dim objDA As New Datos.EntradaProductoDA
        Dim dtTablaAtados As New DataTable

        dtTablaAtados = objDA.AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada(IdSalidaNave, Id_Nave, Año, Lote, Proceso, TipoCodigo, _
                                                                          Tipo_Nave_Maquila_o_Interna, Atado_Incluido_SalidaNave_en_Curso, _
                                                                          ResultadoLoteCompleto)



        Return dtTablaAtados
    End Function


    'Public Sub Agregar_Atados_De_Faltantes_a_Lotes_incompletos_en_Entrada_De_Nave(ByVal IdSalidaNave As Integer, ByVal TipoNave As Boolean)
    '    Dim objDA As New Datos.EntradaProductoDA

    '    objDA.Agregar_Atados_De_Faltantes_a_Lotes_incompletos_en_Entrada_De_Nave(IdSalidaNave, TipoNave)
    'End Sub


    'Public Function ValidarParesCompletos_DeLotesCorrectos(ByVal IdSalidaNave As Integer, ByVal Proceso As String) As DataTable
    '    Dim objDA As New Datos.EntradaProductoDA
    '    Dim dtParesConValorNuloEnAtadoValidadoComoCorrecto As New DataTable

    '    dtParesConValorNuloEnAtadoValidadoComoCorrecto = objDA.ValidarParesCompletos_DeLotesCorrectos(IdSalidaNave, Proceso)

    '    Return dtParesConValorNuloEnAtadoValidadoComoCorrecto
    'End Function


    Public Sub RegistrarBitacora(ByVal ConfiguracionId As Integer, ByVal UsuarioId As Integer, ByVal ValidaEntradaAnterior As Boolean, ByVal ValidaSalidaAnterior As Boolean, ByVal ValidaEntradaNuevo As Boolean, ByVal ValidaSalidaNuevo As Boolean)
        Dim objDA As New Datos.EntradaProductoDA

        Try
            objDA.RegistrarBitacora(ConfiguracionId, UsuarioId, ValidaEntradaAnterior, ValidaSalidaAnterior, ValidaEntradaNuevo, ValidaSalidaNuevo)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


End Class


