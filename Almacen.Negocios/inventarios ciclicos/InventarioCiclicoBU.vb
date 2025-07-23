Public Class InventarioCiclicoBU

    Public Function RecuperarNombreCliente(ByVal IdCliente As String) As DataTable
        Dim objClienteDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objClienteDA.RecuperarNombreCliente(IdCliente)
        Return tabla
    End Function

    Public Function RecuperaNombreAgente(ByVal IdNombreAgente As String) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.RecuperarNombreAgente(IdNombreAgente)
        Return tabla
    End Function

    Public Function RecuperarNombreTienda(ByVal IdTienda As String) As DataTable
        Dim objTiendaDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objTiendaDA.RecuperarNombreTienda(IdTienda)
        Return tabla
    End Function

    Public Function RecuperarNombreProducto(ByVal IdProducto As String) As DataTable
        Dim objProductoDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objProductoDA.RecuperarNombreProducto(IdProducto)
        'RecuperarNombreProducto = New List(Of Entidades.Productos)
        'For Each row As DataRow In tabla.Rows
        '    Dim NombreProducto As New Entidades.Productos
        '    NombreProducto.PDescripcionProd = CStr(row("Descripcion"))
        '    RecuperarNombreProducto.Add(NombreProducto)
        'Next
        Return tabla
    End Function

    Public Function RecuperarNombreBahia(ByVal IdBahia As String) As DataTable
        Dim objBahiaDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objBahiaDA.RecuperarNombreBahia(IdBahia)
        'RecuperarNombreBahia = New List(Of Entidades.Bahia)
        'For Each row As DataRow In tabla.Rows
        '    Dim NombreBahia As New Entidades.Bahia
        '    NombreBahia.bahi_descripcion = CStr(row("Bahía"))
        '    RecuperarNombreBahia.Add(NombreBahia)
        'Next
        Return tabla
    End Function

    Public Function RecuperarDescripcionCorrida(ByVal IdCorrida As String) As DataTable
        Dim objCorridaBU As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objCorridaBU.RecuperarDescripcionCorrida(IdCorrida)
        Return tabla
    End Function

    Public Function RecuperarMarca(ByVal IdMarca As String) As DataTable
        Dim objMarcaDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objMarcaDA.RecuperarMarca(IdMarca)
        Return tabla
    End Function

    Public Function RecuperarColeccion(ByVal IdColeccion As String) As DataTable
        Dim objColeccionDa As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objColeccionDa.RecuperarColeccion(IdColeccion)
        Return tabla
    End Function

    Public Function RecuperarPedido(ByVal IdPedido As String) As DataTable
        Dim objPedidoDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objPedidoDA.RecuperarPedido(IdPedido)
        Return tabla
    End Function

    Public Function ListaOperadoresAlmacenSicy() As DataTable
        ListaOperadoresAlmacenSicy = New DataTable
        Dim objListaOperadoresAlmacenSicyDA = New Datos.InventarioCiclicoDA
        ListaOperadoresAlmacenSicy = objListaOperadoresAlmacenSicyDA.ListaOperadores
        Return ListaOperadoresAlmacenSicy
    End Function

    Public Function AgregarInventarioCiclico(ByVal Inventario As Entidades.InventariosCiclicos) As DataTable
        Dim objAltaInventarioCiclicoDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objAltaInventarioCiclicoDA.AgregarInventarioCiclico(Inventario)
        Return tabla
    End Function

    Public Sub EditarInventarioCiclico(ByVal Inventario As Entidades.InventariosCiclicos)
        Dim objEditarInventarioCiclicoDA As New Datos.InventarioCiclicoDA
        objEditarInventarioCiclicoDA.EditarInventarioCiclico(Inventario)
    End Sub

    Public Sub AgregarDetalleAtadoCompletoInventarioCiclico(ByVal InventarioDetalles As Entidades.InventarioCiclicoDetalle)
        Dim objDetallesInventarioDA As New Datos.InventarioCiclicoDA
        objDetallesInventarioDA.AgregarDetallesInventarioCiclico(InventarioDetalles)

    End Sub

    Public Sub AgregarDetallesInventarioCiclico(ByVal InventarioDetalles As Entidades.InventarioCiclicoDetalle)
        Dim objDetallesInventarioDA As New Datos.InventarioCiclicoDA
        objDetallesInventarioDA.AgregarDetallesInventarioCiclico(InventarioDetalles)

    End Sub

    Public Sub AgregarCaracteristicaInventarioCiclico(ByVal Caracteristica As Entidades.InvenatariosCiclicosCaracteristicas)
        Dim objAgregarCaracteristica As New Datos.InventarioCiclicoDA
        objAgregarCaracteristica.AgregarCaracteristicaInventarioCiclico(Caracteristica)
    End Sub

    Public Function ListaInventariosCiclicos(ByVal Inventarios As Entidades.InventarioCiclicoBusqueda, ByVal y_o As Boolean) As DataTable
        Dim objInventarioDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objInventarioDA.ListaInventariosCiclicos(Inventarios, y_o)
        Return tabla
    End Function

    Public Function ListaEstadosInventariosCiclicos() As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtEstadosInventariosCiclicos As New DataTable
        dtEstadosInventariosCiclicos = objDA.ListaEstadosInventariosCiclicos()
        Return dtEstadosInventariosCiclicos
    End Function

    Public Function ListaParametrosFiltradoEditar(ByVal IdInventario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtListaParametros As New DataTable
        dtListaParametros = objDA.ListaCriterioFiltradoEditar(IdInventario)
        Return dtListaParametros
    End Function

    Public Function RecuperarCaracteristica(ByVal CampoDesccripcion As String, ByVal Tabla As String, ByVal IdCampo As String, ByVal IdCaracteristica As String) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtCaracteristica As New DataTable
        dtCaracteristica = objDA.RecuperarCaracteristica(CampoDesccripcion, Tabla, IdCampo, IdCaracteristica)
        Return dtCaracteristica
    End Function

    Public Function RecuperarDetalleInventario(ByVal IdInventario As Integer, ByVal IdEstado As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtInventarioCaracteristicas As New DataTable
        dtInventarioCaracteristicas = objDA.ListaDetalleInventario(IdInventario, IdEstado)
        Return dtInventarioCaracteristicas
    End Function

    Public Function CorridasReporte(ByVal IdInventario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtCorridas As New DataTable
        dtCorridas = objDA.CorridasReporte(IdInventario)
        Return dtCorridas
    End Function

    Public Function ResumenInventario(ByVal IdInventario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtResumen As New DataTable
        dtResumen = objDA.ResumenInventario(IdInventario)
        Return dtResumen
    End Function

    ''' <summary>
    ''' RECUPERA LA TABLA DE LOS PARES PERTENECIENTES A CIERTO INVENTARIO CICLICO AGRUPANDO LOS PARES CON UNA TABLA PIVOTE ORDENANDO COLUMAS
    '''  DE TALLAS CON LOS PARES DE CADA TALLA CORRESPONDIENTES A CADA COLUMNA, Y ATADO.
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL CUAL SE BUSCARA</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImprimirReporteResultadoInventario(ByVal IdInventario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtResultadoInventario As New DataTable
        dtResultadoInventario = objDA.ImprimirReporteResultadoInventario(IdInventario)
        Return dtResultadoInventario
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LO PARES PERTENECIENTES A CIERTO INVENTARIO CICLICO AGRUPADOS POR ATADOS
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL CUAL SE BUSCARAN LOS PARES</param>
    ''' <param name="Atado">ATADO EN EL CUAL SE BUSCARAN LOS PARES</param>
    ''' <param name="Ubicacion">UBICACION (ESIBA EN LA CUAL SE BUSCARAN LOS PARES)</param>
    ''' <returns>TABLA CON LOS PARES ENCONTRADOS AGRUPADOS POR ATADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarEncontrados(ByVal IdInventario As Integer, ByVal Atado As String, ByVal Ubicacion As String) As Integer
        Dim Encontrados As Integer
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtEncontrados As New DataTable
        dtEncontrados = objDA.RecuperarEncontrados(IdInventario, Atado, Ubicacion)
        For Each row As DataRow In dtEncontrados.Rows
            If row.Item(0) Is DBNull.Value Then
                Encontrados = 0
            Else
                Encontrados = row.Item(0)
            End If

        Next
        Return Encontrados
    End Function

    ''' <summary>
    ''' RECUPERA EL CODIGO DE PAR DE DE CIERTO INVENTARIO CICLICO CUANDO ESTE PAR ES UNICO EN UN ATADO QUE PERTENECE AL INVENTARIO O ES UN PAR QUE ESTA DESTALLADO
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL CUAL BUSCARA</param>
    ''' <param name="Atado">ID DEL ATADO EN EL CUAL BUSCARA</param>
    ''' <param name="Ubicacion">UBICACION EN LA CUAL BUSCARA AL PAR</param>
    ''' <returns>TABLA CON EL DATO DEL PAR ENCONTRADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCodigoPar(ByVal IdInventario As Integer, ByVal Atado As String, ByVal Ubicacion As String) As String
        Dim CodigoPar As String = ""
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtCodigoPar As New DataTable
        dtCodigoPar = objDA.RecuperarCodigoPar(IdInventario, Atado, Ubicacion)
        For Each row As DataRow In dtCodigoPar.Rows
            CodigoPar = row.Item(0)
        Next
        Return CodigoPar
    End Function

    ''' <summary>
    ''' RECUPERA UNA LISTA CON LOS PARES SOBRANTES DE DETERMINADO INVENTARIO CICLICO
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL CUAL SE BUSCARAN PARES SOBRANTES</param>
    ''' <returns>TABLA CON LOS PARES ENCONTRADOS COMO SOBRANTES EN UN DETERMINADO INNVENTARIO CICLICO</returns>
    ''' <remarks></remarks>
    Public Function ImprimirSobrantesInventario(ByVal IdInventario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtInventariosSobrantes As New DataTable
        dtInventariosSobrantes = objDA.ImprimirSobrantesInventario(IdInventario)
        Return dtInventariosSobrantes
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LAS CANTIDADES DE INVENTARIOS REALIZADOS EN ESTADO 3 "FINALIZADO" Y LA DEVUELVE
    ''' </summary>
    ''' <returns>TABLA CON LOS TOTALES DE INNVETARIOS REALIZADOS, INVENTARIOS CON ERRORES E INVENTARIOS SIN ERRORES</returns>
    ''' <remarks></remarks>
    Public Function TotaLInventariosLevantados(ByVal fechainicio As String, ByVal fechafin As String) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtInventarios As New DataTable
        dtInventarios = objDA.TotaLInventariosLevantados(fechainicio, fechafin)
        Return dtInventarios
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS IDENTIFICADORES DE LOS INVENTARIOS CICLICOS EN ESTADO 3 "FINALIZADO", Y LOS DEVUELBE COMO UNA CADENA
    ''' </summary>
    ''' <returns>CADENA CON LOS IDS DE LOS INVENTARIOS CICLICOS EN LOS QUE SE BUSCARAN LOS PARES TOTALES INVENTARIADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarIdsInvCi(ByVal FechaInicio As String, ByVal fechaFin As String) As String
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim IdsInventarios As String = "0"
        Dim dtIdInventarios As New DataTable
        dtIdInventarios = objDA.RecuperarIdsInvCi(FechaInicio, fechaFin)
        For Each row As DataRow In dtIdInventarios.Rows
            IdsInventarios = IdsInventarios + " ,  " + CStr(row(0))
        Next
        Return IdsInventarios
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA RECUPERAR UNA TABLA CON LA LISTA DE LOS TOTALES DE PARES A ENCONTRAR, ENCONTRADOS SIN ERRORES Y ENCONTRADOS CON ERRORES
    '''  DE TODOS LOS INVENTARIOS CICLICOS EN ESTADO "FINALIZADO"
    ''' </summary>
    ''' <param name="IdsInventarios">IDENTIFICADORES DE LOS INVENTARIOS EN LOS QUE SE BUSCARAN LOS DATOS</param>
    ''' <returns>TABLA CON LOS TOTALES ENCONTRADOS</returns>
    ''' <remarks></remarks>
    Public Function TotalParesConsultados(ByVal IdsInventarios As String) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtPares As New DataTable
        dtPares = objDA.TotalParesConsultados(IdsInventarios)
        Return dtPares
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS PARES INVENTARIODOS EN UN DETERMINADO INVENTARIO CICLICO YA CONCLUIDO Y SUS CARACTERISTICAS CORREPONDIENTES
    ''' </summary>
    ''' <param name="IdInventarioCiclico">ID DEL INVENTARIO DEL CUAL SE BUSCA RECUPERAR INFORMACIÓN</param>
    ''' <returns>TABLA CON LOS PARES DEL INVENTARIO CICLICO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaParesInventarioConcluido(ByVal IdInventarioCiclico As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtPares As New DataTable
        dtPares = objDA.RecuperarListaParesInventarioConcluido(IdInventarioCiclico)
        Return dtPares
    End Function

    ''' <summary>
    ''' VERIFICA SI EL USUARIO QUE INICIO SESION TIENE ALGIN INVENTARIO CICLICO EN ESTADO "EN PROCESO"
    ''' </summary>
    ''' <returns>BOOLEAN</returns>
    ''' <remarks></remarks>
    Public Function VerificarInventariosEnProcesoUsuarioLoggueado() As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtTablas As New DataTable
        dtTablas = objDA.VerificarInventariosEnProcesoUsuarioLoggueado()
        If dtTablas.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA CAMBIAR EL ESTADO DE UN INVENTARIO CICLICO A "EN PROCESO"
    ''' </summary>
    ''' <param name="IdInventario">ID DEL INVENTARIO A ACIUALIZAR</param>
    ''' <returns>BOOBLEAN</returns>
    ''' <remarks></remarks>
    Public Function IniciarInventarioCiclico(ByVal IdInventario As Integer) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtIniciarInventario As New DataTable
        dtIniciarInventario = objDA.IniciarInventarioCiclico(IdInventario)
        If dtIniciarInventario.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA VERIFICAR SI EL CODIGO LEEIDO PERTENECE A UNA ESTIBA VALIDA
    ''' </summary>
    ''' <param name="codigo">CODIGO A VERIFICAR</param>
    ''' <returns>BOOBLEAN</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Estiba_Valido(ByVal codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Estiba_Valido(codigo)

        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA VERIFICAR SI EL CODIGO LEEIDO PERTENECE A UN PAR DENTRO DE LA TABLA "ALMACEN.INVENTARIOSCICLICOSDETALLES" DE UN INVENRARIO EN ESPECIFICO
    ''' </summary>
    ''' <param name="codigo">CODIGO A VERIFICAR</param>
    ''' <param name="IdInventario">ID DEL INVENTARIO EN EL QUE BUSCARA EL DODIGO</param>
    ''' <returns>BOOLEAN</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_Valido_InventarioCilcicoDetalles(ByVal codigo As String, ByVal IdInventario As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_Valido_InventarioCiclicoDetalles(codigo, IdInventario)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA VERIFICAR SÍ EL CODIGO DE PAR LEEIDO SE ENCIENTRA EN LA TABLA "ALMACEN.UBICACIONPARES"
    ''' </summary>
    ''' <param name="codigo">CODIGO A BUSCAR</param>
    ''' <returns>BOOLEAN</returns>
    ''' <remarks></remarks>
    Public Function Consulta_Par_Valido(ByVal codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_Valido(codigo)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function RecuperarParesAtadoContenidoAtado(ByVal Codigo As String)
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtPares As New DataTable
        dtPares = objDA.RecuperarParesAtadoContenidoAtado(Codigo)
        Return dtPares
    End Function

    Public Function RecuperarParesAtadotmpDocenasPares(ByVal Codigo As String)
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtPares As New DataTable
        dtPares = objDA.RecuperarParesAtadotmpDocenasPares(Codigo)
        Return dtPares
    End Function

    Public Function VerificarAtadoUbicacionAtados(ByVal Codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim Tabla As New DataTable
        Tabla = objDA.VerificarAtadoUbicacionAtados(Codigo)
        If Tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerificarAtadoLotesDocenas(ByVal Codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim Tabla As New DataTable
        Tabla = objDA.VerificarAtadoLotesDocenas(Codigo)
        If Tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Consulta_Par_ContenidoAtados(ByVal codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_ContenidoAtados(codigo)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Consulta_Par_tmpErroresPares(ByVal codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_tmpErroresPares(codigo)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Consulta_Par_tmpDocenasPares(ByVal codigo As String) As Boolean
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim tabla As New DataTable
        tabla = objDA.Consulta_Par_tmpDocenasPares(codigo)
        If tabla.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub AgregarParAErroresStatusPar(ByVal CodigoPar As String, ByVal EstibaId As String, ByVal IdUsuario As Integer)
        Dim objDA As New Datos.InventarioCiclicoDA
        objDA.AgregarParAErroresStatusPar(CodigoPar, EstibaId, IdUsuario)
    End Sub

    Public Function ParEscaneadoInvCiclDetalle(ByVal IdInventarioCiclico As Integer, ByVal CodigoPar As String, ByVal Estiba As String, ByVal IdUsuario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtPares As New DataTable
        dtPares = objDA.AgregarParEscaneadoICIDetalle(IdInventarioCiclico, CodigoPar, Estiba, IdUsuario)
        Return dtPares
    End Function

    Public Function CargarTotalParesInventarioEnProceso(ByVal IdInventario As Integer) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtTotalPares As New DataTable
        dtTotalPares = objDA.CargarTotalParesInventarioEnProceso(IdInventario)
        Return dtTotalPares
    End Function


    Public Sub CerrarInventarioCiclico(ByVal IdInventarioCiclico As Integer, ByVal Total As Integer, ByVal Nbien As Integer, ByVal NFaltante As Integer, ByVal NSobrantes As Integer, ByVal IdUsuario As Integer)
        Dim objDA As New Datos.InventarioCiclicoDA
        objDA.CerrarInventarioCiclico(IdInventarioCiclico, Total, Nbien, NFaltante, NSobrantes, IdUsuario)
    End Sub
    Public Sub CerrarInventarioCiclicoDetalle(ByVal IdInventarioCiclico As Integer)
        Dim objDA As New Datos.InventarioCiclicoDA
        objDA.CerrarInventarioCiclicoDetalle(IdInventarioCiclico)
    End Sub

    ''' <summary>
    ''' CONECTA CON DATOS PARA RECUPERAR LA INFORMACION DE LA BAHIA DE UNA ESTIBA EN ESPECIFICO
    ''' </summary>
    ''' <param name="Estiba">ESTIBA DE LA QUE SE RECUPERARA INFORMACION</param>
    ''' <returns>TABLA CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDatosUbicacionReal(ByVal Estiba As String) As DataTable
        Dim objDA As New Datos.InventarioCiclicoDA
        Dim dtBahia As New DataTable
        dtBahia = objDA.RecuperarDatosUbicacionReal(Estiba)
        Return dtBahia
    End Function

End Class
