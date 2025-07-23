Imports Almacen.Datos
Public Class SalidaNavesBU
    Public Function validarexterna(ByVal idNave As Integer) As Boolean
        Dim objDA As New Datos.SalidaNavesDA
        Return objDA.validarexterna(idNave)
    End Function
    ''' <summary>
    ''' Recupera el precio del par escaneado
    ''' </summary>
    ''' <param name="lote"></param>
    ''' <param name="año"></param>
    ''' <param name="idNave"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerificarAtadoValido_RecuperaPrecioLote(ByVal lote As Integer, ByVal año As Integer, ByVal idNave As Integer) As Integer
        Dim objDA As New Datos.SalidaNavesDA
        Return objDA.VerificarAtadoValido_RecuperaPrecioLote(lote, año, idNave)
    End Function
    ''' <summary>
    ''' FUNCION PARA RECUPERAR UNA TABLA INFORMACION DE LOS USUARIOS QUE PERTENECEN A CIERTA NAVE
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR INFORMACION</param>
    ''' <returns>TABLA CON LOS DATOS DE LAS NAVES</returns>
    ''' <remarks></remarks>
    Public Function ComboOperadoresSegunNave(ByVal IdNave As Integer) As DataTable
        Dim objDA As New Datos.SalidaNavesDA
        Dim tabla As New DataTable
        tabla = objDA.ComboOperadoresSegunNave(IdNave)
        Return tabla
    End Function

    ''' <summary>
    ''' FUNCION PARA VERIFICAR SÍ EL CODIGO LEEÍDO PERTENECE A UN CODIGO VALIDO
    ''' </summary>
    ''' <param name="codigo">CODIGO DEL POSIBLE ATADO A VALIDAR</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function VerificarAtadoValido_RecuperaInformacionLote(ByVal codigo As String) As Entidades.CapturaAtadoValido
        Dim AtadoValido As New Entidades.CapturaAtadoValido
        Dim objDA As New SalidaNavesDA
        Dim dtCodigosAtados As New DataTable
        dtCodigosAtados = objDA.VerificarAtadoValido_RecuperaInformacionLote(codigo)

        If dtCodigosAtados.Rows.Count > 0 Then
            For Each row As DataRow In dtCodigosAtados.Rows
                AtadoValido.PIdAtado = row.Item("Atado")
                AtadoValido.PIdNAve = row.Item("Nave")
                AtadoValido.PLote = row.Item("Lote")
                AtadoValido.PAño = row.Item("Año")
                AtadoValido.PN_Pares = row.Item("n_Pares")
                AtadoValido.PDescripcion = row.Item("Descripción")
                AtadoValido.PIdCliente = row.Item("IdCliente")
                AtadoValido.PN_AtadoEscaneado = row.Item("No_Atado")
            Next
        Else
            AtadoValido.PIdAtado = 0
        End If
        Return AtadoValido
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarAtadoIngresadoAnteriormente(ByVal codigo As String) As Entidades.CapturaAtadoValido
        Dim AtadoValido As New Entidades.CapturaAtadoValido
        Dim objDA As New SalidaNavesDA
        Dim dtCodigosAtados As New DataTable
        dtCodigosAtados = objDA.ValidarAtadoIngresadoAnteriormente(codigo)

        If dtCodigosAtados.Rows.Count > 0 Then
            For Each row As DataRow In dtCodigosAtados.Rows
                AtadoValido.PIdAtado = row.Item("Atado")
                AtadoValido.PIdNAve = row.Item("Nave")
                AtadoValido.PLote = row.Item("Lote")
                AtadoValido.PAño = row.Item("Año")
                AtadoValido.PN_Pares = row.Item("n_Pares")
                AtadoValido.PDescripcion = row.Item("Descripción")
                AtadoValido.PIdCliente = row.Item("IdCliente")
                AtadoValido.PN_AtadoEscaneado = row.Item("No_Atado")
            Next
        Else
            AtadoValido.PIdAtado = 0
        End If
        Return AtadoValido
    End Function

    ''' <summary>
    ''' FUNCION PARA INSETAR UN REGISTRO EN LA TABLA PRODUCCION.SALIDANAVES Y RECUPERAR EL GENERADO
    ''' </summary>
    ''' <param name="IdNave">NAVE QUE SE USARA PARA DAR DE ALTA EL REGISTRO DE SALIDANAVES</param>
    ''' <param name="Operador">OPERADOR QUE SE USARA PARA DAR DE ALTA EL REGISTRO DE SALIDANAVES</param>
    ''' <param name="TipoNave">TIPO NAVE QUE SE USARA PARA DAR DE ALTA EL REGISTRO DE SALIDANAVES</param>
    ''' <returns>ID DEL REGISTRO GENERADO EN LA TABLA SALIDA NAVES</returns>
    ''' <remarks></remarks>
    Public Function IniciarSalidaNave(ByVal IdNave As Integer, ByVal Operador As Integer, ByVal TipoNave As Boolean)
        Dim objDA As New SalidaNavesDA
        Dim dtSalidaNave As New DataTable
        Dim IdSalidaNave As Integer
        dtSalidaNave = objDA.IniciarSalidaNave(IdNave, Operador, TipoNave)
        For Each row As DataRow In dtSalidaNave.Rows
            IdSalidaNave = row.Item(0)
        Next
        Return IdSalidaNave
    End Function

    ''' <summary>
    ''' VALIDA QUE UN LOTE ESTE EN ESTADO CONCLUIDO CONECTANDO A LA CAPA DE DATOS Y EJECUTANDO UN PROCEDIMIENTO ALMACENADO
    ''' </summary>
    ''' <param name="DatosAtado">ENTIDAD CON VARIABLES LLENAS DE INFORMACION UTILIZADA POR EL PROCEDIMIENTO ALMACENADO</param>
    ''' <param name="IdSalidaNave">ID DE EL REGISTRO DE LA TABLA SALIDANAVES SOBRE LA QUE SE ESTARA TRABAJANDO</param>
    ''' <returns>TABLA CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function ValidarLoteTerminado(ByVal DatosAtado As Entidades.CapturaAtadoValido, ByVal IdSalidaNave As Integer)
        Dim objDA As New SalidaNavesDA
        Dim dtTablas As New DataTable
        dtTablas = objDA.ValidarLoteTerminado(DatosAtado, IdSalidaNave)
        Return dtTablas
    End Function

    ''' <summary>
    ''' RECUPERA EL CODIGO DE ATADO, NUMERO DE ATADO, LOTE, DESCRIPCION, AÑO DE ATADO DE UN ATADO DETERMINADO PERTENECIENTE A UNA SALIDA DE NAVES DETERMINADA
    ''' </summary>
    ''' <param name="Atado">ATADO DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <param name="idSalidaNave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function recuperarDatosAtadoSalidaNavesDetalles(ByVal Atado As String, ByVal idSalidanave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.recuperarDatosAtadoSalidaNavesDetalles(Atado, idSalidanave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPARE LOS TOTALES DE LOS PARES SEGUN EL ESTATUS EN EL QUE FIERON ENCONTRADOS PARA CON ESTOS TOTALES VALIDAR SI EL ATADO ESTA CORRECTO, SI LE FALTAN O ESTA MALFORMADO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Atado">ATADO CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <returns>TABLA CON LOS TOTALES DE PARES, PARES ENCONTRADOS, PARES FALTANTES Y PARES SOBRANTES</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Pares_De_Atado_Segun_Estatus(ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal Proceso As String, ByVal Tipo_Nave As Boolean,
                                                                   ByVal IdNave As Integer)
        Dim objDA As New SalidaNavesDA
        Dim dtTotales As New DataTable
        dtTotales = objDA.Recuperar_Totales_Pares_De_Atado_Segun_Estatus(IdSalidaNave, Atado, Proceso, Tipo_Nave, IdNave)
        Return dtTotales
    End Function

    ''' <summary>
    ''' ACTUALIZA EL ESTATUS DE UN ATADO, ESTO SE HACE CUANDO EL SISTEMA DETECTA QUE SE ESCANEO UN CODIGO DE ATADO NUEVO.
    ''' </summary>
    ''' <param name="Atado">ATADO AL CUAL ACTUALIZAR EL ESTADO</param>
    ''' <param name="Status">ESTADO DEL ATADO</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Año">AÑO DEL ATADO QUE SE ACTUALIZARA</param>
    ''' <remarks></remarks>
    Public Sub ActualizarEstatusDeAtadoN(ByVal Atado As String, ByVal Status As Integer, ByVal IdSalidaNave As Integer, ByVal Año As Integer, ByVal ParxPar As Boolean, ByVal Num_Pares As Integer _
                                         , ByVal Lote As Integer, ByVal NaveId As Integer, ByVal Proceso As String, ByVal TipoNave As Boolean, ByVal IdCarrito As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        objDA.ActualizarEstatusDeAtadoN(Atado, Status, IdSalidaNave, Año, ParxPar, Num_Pares, Lote, NaveId, Proceso, TipoNave, IdCarrito)
    End Sub

    ''' <summary>
    ''' CONSULTA SI UN PAR EXISTE EN LA TABLA TMPDOCENASPARES, DE SER ASI REGRESA UN VALOR 'TRUE', DE LO CONTRARIO REGRESA UN VALOR 'FALSE'
    ''' </summary>
    ''' <param name="codigo">CODIGO DEL PAR A VERIFICAR</param>
    ''' <returns>VALOR BOOLEANO</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' ACTUALIZA EL ESTADO DE UN PAR QUE HA SIDO ESCANEADO, DE NO EXISTIR LO AGREGA A LA TABLA PRODUCCION.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="cadena">CODIGO DE PAR A ACTUALIZAR</param>
    ''' <param name="AtadoActual">ATADO DEL PAR A ACTUALIZAR</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="AñoAtadoActual">AÑO DEL ATADO CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Lote">LOTE CON EL QUE SE ESTA TRABAJANDO</param>
    ''' <param name="IdNAve"></param>
    ''' <returns>TALLA DEL PAR MODIFICADO/AGREGADO</returns>
    ''' <remarks></remarks>
    Public Function ActualizarEstatusPar(ByVal cadena As String, ByVal AtadoActual As String, ByVal IdSalidaNave As Integer, ByVal AñoAtadoActual As Integer, ByVal Lote As Integer, _
                                         ByVal IdNave As Integer, ByVal Talla As String, ByVal NumeroPar As Integer, ByVal TipoEscaneo As Boolean, ByVal IdProducto As String, _
                                         ByVal Descripcion As String, ByVal Proceso As String, ByVal Tipo_Nave As Boolean, ByVal Idcarrito As Integer)
        Dim dtTallas As New DataTable
        Dim objDA As New SalidaNavesDA
        dtTallas = objDA.ActualizarEstatusPar(cadena, AtadoActual, IdSalidaNave, AñoAtadoActual, Lote, IdNave, Talla, NumeroPar, TipoEscaneo, IdProducto, Descripcion, Proceso, Tipo_Nave, Idcarrito)

        Return dtTallas
    End Function

    ''' <summary>
    ''' AGREGA LOS PARES DEL ATADO ACTUAL ESCANEADO A LA TABLA PRODUCCION.SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA A NAVE CON LA QUE SE ESTA TRABAJANDO Y EN LA QUE SE AGREGARAN LOS PARES</param>
    ''' <param name="Atado">ATADO AL QUE PERTENECEN LOS PARES QUE SE AGREGARAN</param>
    ''' <param name="lote">LOTE DEL ATADO</param>
    ''' <param name="Año">AÑO DEL LOTE DEL ATADO</param>
    ''' <param name="IdNave">ID DE LA NAVE, DEL LOTE, DEL ATADO</param>
    ''' <remarks></remarks>
    Public Sub AgregarParesAtadoActual(ByVal AtadoIncluidoEnSalida As Boolean, ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer, ByVal N_Atado As Integer, _
                                       ByVal LecturaParXPar As Boolean, ByVal Proceso As String, ByVal TipoCodigo As String, ByVal TipoNave As Boolean, ByVal IdCarrito As Integer, ByVal LoteTerminado As Boolean)
        Dim objDA As New Datos.SalidaNavesDA
        objDA.AgregarParesAtadoActual(AtadoIncluidoEnSalida, IdSalidaNave, Atado, lote, Año, IdNave, N_Atado, LecturaParXPar, Proceso, TipoCodigo, TipoNave, IdCarrito, LoteTerminado)
    End Sub

    ''' <summary>
    ''' RECUPERA LA TALLA DE UN PAR EN ESPECIFICO
    ''' </summary>
    ''' <param name="Codigo">CODIGO DEL PAR DEL CUAL SE RECUPERARA LA TALLA</param>
    ''' <returns>TALLA RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarTalla(ByVal Codigo As String)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTalla As New DataTable

        dtTalla = objDA.RecuperarTalla(Codigo)

        Return dtTalla
    End Function

    ''' <summary>
    ''' VALIDA SI EL CODIGO ESCANEADO PERTENECE A ALGUN CODIGO DE CLIENTE
    ''' </summary>
    ''' <param name="CodigoEscaneado">CODIGO ESCANEADO</param>
    ''' <param name="IdCLiente"> ID DEL CLIENTE AL QUE S ELE ASIGNO EL LOTE</param>
    ''' <returns>TALLA DEL CODIGO DE CLIENTE ESCANEADO</returns>
    ''' <remarks></remarks>
    Public Function Validar_Codigo_De_Cliente(ByVal CodigoEscaneado As String, ByVal IdCLiente As Integer, ByVal codigosAtadoActual As String)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        Dim talla As String = String.Empty
        dtTabla = objDA.Validar_Codigo_De_Cliente(CodigoEscaneado, IdCLiente, codigosAtadoActual)
        For Each row As DataRow In dtTabla.Rows
            talla = row.Item(0)
        Next
        Return talla
    End Function

    ''' <summary>
    ''' RECUPERA LOS PARES PERTENECIENTES A UN ATADO, CON SU CODIGO DE CLIENTE CORRESPONDIENTE
    ''' </summary>
    ''' <param name="IdAtado"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Recuperar_dtPares_Para_Escanea_CodClientes(ByVal IdAtado As String)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.Recuperar_dtPares_Para_Escanea_CodClientes(IdAtado)
        Return dtTabla
    End Function

    ''' <summary>
    ''' VERIFICA SI NO HAY UN PROCESO DE SALIDA DE NAVES PENDIENTE PARA LA NAVE EN CUESTION, DE SER ASI SE REGRESARA UNA TABLA CON INFORMACION DE EL PROCESO DE SALIDA DE NAVE PENDIENTE DE CONCLUIR
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE EN LA QUE SE VERIFICARA SI HAY PROCESOS PENDIENTES DE SALIDA DE NAVES</param>
    ''' <returns>DATATABLE CON INFORMACION DE LA SALIDA DE NAVE PENDIENTE(SÍ ES QUE HAY ALGÚNA)</returns>
    ''' <remarks></remarks>
    Public Function ValidarSalidasPendientes(ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.ValidarSalidasPendientes(IdNave)
        Return dtTabla
    End Function


    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS CODIGOS DE ATADO PERTENECIENTES A UN LOTE NO TERMINADO
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUALS E RECUPERARAN LOS CODIGOS DE ATADO</param>
    ''' <returns>DATATABLE CON LA INFORMACION DE LOS CODIGOS DE ATADO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarAtados_de_LoteIncompleto(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable

        dtTabla = objDA.RecuperarAtados_de_Lote(Lote, Año, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA LOS ATADOS YA LEEIDOS E INCLUIDOS EN LA TABLA Almacen.SALIDANAVESDETALLES CON SU ESTADO Y SU LOTE CORRESPONDIENTE PARA ACTUALIZAR LA TABLA DE GRID ERRONEOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A RECUPERAR INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla = objDA.RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves(IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA LOS CODIGOS DE ATADO PERTENECIENTES A UN LOTE
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUAL SE RECUPERARAN LOS ATADOS</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="IdNave">NAVE DEL LOTE</param>
    ''' <returns>TABLA CON LOS DATOS DE LOS ATADOS RECUPERADOS</returns>
    ''' <remarks></remarks>
    Public Function RecuperarAtadosDelLote(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim dtAtadosLote As New DataTable
        Dim objDA As New Datos.SalidaNavesDA
        dtAtadosLote = objDA.RecuperarAtados_de_Lote(Lote, Año, IdNave)
        Return dtAtadosLote
    End Function

    ''' <summary>
    ''' RECUPERA LOS ATADOS Y SU DESCRIPCIO PERTENECIENTEAS A UN LOTE DETERMINADO
    ''' </summary>
    ''' <param name="Lote">LOTE DEL QUE SE RECUPERARAN LOS ATADOS</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="IdNave">NAVE DEL LOTE</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarAtados_de_Lote_Con_Descripcion(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim dtAtadosLote As New DataTable
        Dim objDA As New Datos.SalidaNavesDA
        dtAtadosLote = objDA.RecuperarAtados_de_Lote_Con_Descripcion(Lote, Año, IdNave)
        Return dtAtadosLote
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES Y EL TOTAL DE ATADOS PERTENECIENTE A UN LOTE
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUAL SE RECUPERARAN LOS TOTALES</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="IdNave">ID DE LA NAVE A LA QUE PERTENECE EL LOTE</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarPares_De_Lote(ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim dtAtadosLote As New DataTable
        Dim objDA As New Datos.SalidaNavesDA
        dtAtadosLote = objDA.RecuperarPares_De_Lote(Lote, Año, IdNave)
        Return dtAtadosLote
    End Function

    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UN PAR BASANDOSE EN EL CODIGO DE CLIENTE DEL PAR
    ''' </summary>
    ''' <param name="COdigoCliente">CODIGO DEL CLIENTE CON EL CUAL SE RECUPERARA LA DESCRIPCION</param>
    ''' <returns>DESCRIPCION</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDesripcionPar(ByVal COdigoCliente As String)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtDescripcion As New DataTable
        dtDescripcion = objDA.RecuperarDesripcionPar(COdigoCliente)
        Return dtDescripcion
    End Function

    ''' <summary>
    ''' RECUPERA LA DESCRIPCION DE UN PAR MEDIANTE EL CODIGO DE PAR UNICO DE YUYIN
    ''' </summary>
    ''' <param name="Codigo">CODIGO A VERIFICAR</param>
    ''' <returns>DESCRIPCION DEL PAR</returns>
    ''' <remarks></remarks>
    Public Function RecuperarDesripcionParEmpresa(ByVal Codigo As String)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtDescripcion As New DataTable
        dtDescripcion = objDA.RecuperarDesripcionParEmpresa(Codigo)
        Return dtDescripcion
    End Function

    ''' <summary>
    ''' RECUPERA LOS PARES DE UNA SALIDA DE NAVES EN PROCESO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES A RECUPERAR LOS PARES</param>
    ''' <returns>TABLA CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function RecuperaParesDeSalidaNaveEnProceso(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.RecuperaParesDeSalidaNaveEnProceso(IdSalidaNave, IdNave)
        Return dtTabla
    End Function

    ''' <summary>
    ''' ELIMINA LOS PARES DE CIERTO ATADO DE LA TABLA PRODUCCION.SALIDANAVESDETALLES EN CASO DE QUE YA SE HUBIERAN AGREGADO PARES PARA ESE ATADO EN ESA TABLA
    ''' </summary>
    ''' <param name="Atado">CODIGO DE ATADO DEL CUAL VERIFICAREMOS SI EXISTEN PARES EN LA TABLA</param>
    ''' <remarks></remarks>
    Public Sub ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles(ByVal Atado As String, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        objDA.ELiminarParesAtadoYaEscaneadoTabla_ProduccionSalidaNacesDetalles(Atado, IdSalidaNave, IdNave)
    End Sub

    ' ''' <summary>
    ' ''' RECUPERA EL NUMERO DE ATADO REGISTRADO EN LA TABLA ALMACEN.SALIDANAVESDETALLES
    ' ''' </summary>
    ' ''' <param name="Atado">ATADO DEL CUAL SE RECUPERARA EL NUMERO DE ATADO</param>
    ' ''' <param name="IdSalidaNave">ID DE SALIDA DE NAVE</param>
    ' ''' <returns>TABLA CON EL RESULTADO DE LA CONSULTA PARA RECUPERAR EL NUMERO DE ATADO</returns>
    ' ''' <remarks></remarks>
    ''Public Function RecuperarNumeroAtado(ByVal Atado As String, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
    ''    Dim objDA As New Datos.SalidaNavesDA
    ''    Dim dtTabla As New DataTable
    ''    dtTabla = objDA.RecuperarNumeroAtado(Atado, IdSalidaNave, IdNave)
    ''    Return dtTabla
    ''End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA EJECUTAR LA CONSULTA PARA ELIMINAR LOS PARES DE UN ATADO EN ESPECIFICO.
    ''' </summary>
    ''' <param name="llotes">LOTE DEL CUAL SE ELIMINARAN LOS PARES</param>
    ''' <param name="IdNave">NAVE DEL LOTE</param>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ENCUENTRA EL LOTE</param>
    ''' <remarks></remarks>
    Public Sub EliminarParesDeAtadoDescartadoDeLaTablaSalidaNavesDetalles(ByVal IdSalidaNave As Integer, ByVal llotes As HashSet(Of String), ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim lotes() As String

        For Each item In llotes
            lotes = item.Split("-")
            objDA.EliminarParesDeAtadoDescartadoDeLaTablaSalidaNavesDetalles(lotes(0), lotes(1), IdSalidaNave, IdNave)
        Next


    End Sub

    ''' <summary>
    ''' AGREGA LOS PARES CON EL CODIGO DE CLIENTE EN EL CAMPO CORRESPONDIENTE AL CODIGO DEL PAR EN LA TABLA SALIDANAVESDETALLES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALINA DE NAVE EN LA QUE SE INSERTARAN LOS CAMPOS</param>
    ''' <param name="Atado">ATADO DE LOS PARES</param>
    ''' <param name="lote">LOTE DE LOS PARES</param>
    ''' <param name="Año">AÑO DEL LOTE DE LOS PARES</param>
    ''' <param name="IdNave">ID DE LA NAVE DEL LOTE  DE LOS PARES</param>
    ''' <param name="N_Atado">NUMERO DE ATADO A ESCANEAR O ESCANEADO</param>
    ''' <remarks></remarks>
    Public Sub Agregar_PAres_codigoCliente_SalidaNavesDetalles_AtadoActual(ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal lote As Integer, ByVal Año As Integer, _
                                                                           ByVal IdNave As Integer, ByVal N_Atado As Integer, ByVal TipoPar As String)
        Dim objDA As New Datos.SalidaNavesDA
        objDA.Agregar_PAres_codigoCliente_SalidaNavesDetalles_AtadoActual(IdSalidaNave, Atado, lote, Año, IdNave, N_Atado, TipoPar)
    End Sub

    ' ''' <summary>
    ' ''' ACTUALIZA LA TABLA SALIDA NAVES CUANDO SE FINALIZA EL ESCANEO PARA UNA SALIDA DE NAVES
    ' ''' </summary>
    ' ''' <param name="IdSalidaNaves">ID DE LA SALIDA DE NAVES CON LA QUE SE ESTA TRABAJANDO</param>
    ' ''' <param name="TotalPares">TOTAL DE PARES A EMBARCAR</param>
    ' ''' <param name="Total_Atados">TOTAL DE ATADOS A EMBARCAR</param>
    ' ''' <param name="Total_Lotes">TOTAL DE LOTES A EMBARCAR</param>
    ' ''' <remarks></remarks>
    'Public Sub Actualizar_Almacen_salidanaves_SalidaNaves(ByVal IdSalidaNaves As Integer, ByVal TotalPares As Integer, ByVal Total_Atados As Integer, ByVal Total_Lotes As Integer)
    '    Dim objDA As New Datos.SalidaNavesDA
    '    objDA.Actualizar_Almacen_salidanaves_SalidaNaves(IdSalidaNaves, TotalPares, Total_Atados, Total_Lotes)
    'End Sub

    ''' <summary>
    ''' ACTUALIZA LA TABLA SALIDANAVESDETALLES CUANDO SE FINALIZA EL ESCANEO PARA UNA SALIDA DE NAVES
    ''' </summary>
    ''' <param name="IdSalidaNaves">ID DE LA SALIDA DE NAVES A FINALIZAR</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_Almacen_salidaNavesDetalles_SalidaNaves(ByVal IdSalidaNaves As Integer, ByVal Estado As String, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        objDA.Actualizar_Almacen_salidaNavesDetalles_SalidaNaves(IdSalidaNaves, Estado, IdNave)
    End Sub

    ''' <summary>
    ''' RECUPERA QUE TIPO DE NAVE ES CON LA QUE SE ESTA TRABAJANDO, SI ES MAQUILA O ES NAVE NORMAL
    ''' </summary>
    ''' <param name="Id_Nave">ID DE LA NAVE A VERIFICAR</param>
    ''' <returns>VALOR BOOLEANO TRUE PARA UNA NAVE DEL TIPO MAQUILA Y UN VALOR FALSE PARA UNA NAVE NORMAL</returns>
    ''' <remarks></remarks>
    Public Function Validar_TipoNave_Maquila_O_Normal(ByVal Id_Nave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        Dim Tipo_Nave As Boolean
        dtTabla = objDA.Validar_TipoNave_Maquila_O_Normal(Id_Nave)
        For Each row As DataRow In dtTabla.Rows
            If row.Item(0) = "S" Then
                Tipo_Nave = True
            Else
                Tipo_Nave = False
            End If
        Next

        Return Tipo_Nave
    End Function

    ''' <summary>
    ''' RECUPERA UNA TABLA CON LOS LOS LOTES, ATADOS, PARES AGREGADOS A UNA SALIDA DE NAVES CONCLUIDA
    ''' </summary>
    ''' <param name="Id_Salida_Nave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Informacion_Reporte_SalidaNaves(ByVal Id_Salida_Nave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        dtTabla = objDA.Recuperar_Informacion_Reporte_SalidaNaves(Id_Salida_Nave, IdNave)

        Return dtTabla

    End Function

    ''' <summary>
    ''' RECUPERA EL NOMBRE DE UNA NAVE DE ACUERDO CON SU ID
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR EL NOMBRE</param>
    ''' <returns>NOMBRE DE LA NAVE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarNombreNave(ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        Dim NombreNave As String

        dtTabla = objDA.RecuperarNombreNave(IdNave)

        NombreNave = dtTabla.Rows(0).Item(0)

        Return NombreNave
    End Function

    ''' <summary>
    ''' RECUPERA LOS ID DE CLIENTES UQE HAY QUE VALIDAR LECTURA PAR POR PAR PARA DETERMINADA NAVE Y PARA CIERTO PROCESO(ENTRADA O SALIDA)
    ''' </summary>
    ''' <param name="Id_Nave">ID DE LA NAVE DE LA QUE SE RECUPERARAN LOS CLIENTES QUE HAY QUE VALIDAR PAR POR PAR</param>
    ''' <param name="Proceso">PROCESO(ENTRADA O SALIDA)</param>
    ''' <returns>LISTA CON LOS IDS DE LOS CLIENTES QUE HAY QUE VALIDAR PARA LA NAVE CON LA QUE SE ESTA TRABAJANDO</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesParaValidacionParxPar(ByVal Id_Nave As Integer, ByVal Proceso As String)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        Dim lListas As New List(Of String)
        dtTabla = objDA.RecuperarClientesParaValidacionParxPar(Id_Nave, Proceso)

        For Each row As DataRow In dtTabla.Rows
            lListas.Add(row.Item(0))
        Next
        Return lListas
    End Function

    ''' <summary>
    ''' RECUPERA LOS ID DE CLIENTES QUE ESTAN ASIGNADOS EN LOS ATADOS DE UN LOTE
    ''' </summary>
    ''' <param name="Lote">LOTE DEL CUAL SE RECUPERARAN LOS CLIENTES</param>
    ''' <param name="Año">AÑO DEL LOTE</param>
    ''' <param name="Id_Nave">NAVE A LA QUE PERTENECE EL LOTE</param>
    ''' <returns>LISTA CON LOS ID DE LOC CLIENTES INCLUIDOS EN EL LOTE</returns>
    ''' <remarks></remarks>
    Public Function RecuperarClientesIncluidos_En_El_Lote(ByVal Lote As Integer, ByVal Año As Integer, ByVal Id_Nave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable
        Dim lListas As New List(Of String)
        dtTabla = objDA.RecuperarClientesIncluidos_En_El_Lote(Lote, Año, Id_Nave)

        For Each row As DataRow In dtTabla.Rows
            lListas.Add(row.Item(0))
        Next
        Return lListas
    End Function

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES EMBARCADOS, ATADOS EMBARCADO Y LOTES EMBARCADOS HASTA EL MOMENTO EN UNA SALIDA DE NAVE
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_SalidaNaveEnProceso(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable

        dtTabla = objDA.Recuperar_Totales_SalidaNaveEnProceso(IdSalidaNave, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA EJECUTAR EL PROCEDIMIETO ALMACENADO PARA ACTUALIZAR LA FECCHA DE SALIDA DE LOS PARES DE LA SALIDA DE NAVE EN LA TABLA TMPDOCENASPARES
    ''' Y ACTUALIZAR EL ESTADO DE LA SALIDA DE NAVE EN LA TABLA SALIDANAVES ASI COMO LOS TOTALES DE PARES,LATADOS Y LOTES EMBARCADOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="TotalPares">TOTAL DE PARES EMBARCADOS</param>
    ''' <param name="TotalAtados">TOTAL DE ATADOS EMBARCADOS</param>
    ''' <param name="TotalLotes">TOTAL DE LOTES EMBARCADOS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function FinalizarSalidaNaves(ByVal IdSalidaNave As Integer, ByVal TotalPares As Integer, ByVal TotalAtados As Integer, ByVal TotalLotes As Integer, ByVal IdNave As Integer)
        Dim objDASalida As New Datos.SalidaNavesDA
        Dim dtTabla As New DataTable

        dtTabla = objDASalida.FinalizarSalidaNaves(IdSalidaNave, TotalPares, TotalAtados, TotalLotes, IdNave)

        Return dtTabla
    End Function

    ''' <summary>
    ''' RECUPERA LA FECHA EN AL QUE SE LE DIO SALIDA A UN EMBARQUE
    ''' </summary>
    ''' <param name="IdSAlidaNave">ID DE LA SALIDA DE NAVE DE LA QUE SE RECUPERARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA FECHA DE SALIDA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarFechaDeSalidaDeEmbarque(ByVal IdSAlidaNave As Integer)
        Dim objDASalida As New Datos.SalidaNavesDA
        Dim dtFecha As New DataTable

        dtFecha = objDASalida.RecuperarFechaDeSalidaDeEmbarque(IdSAlidaNave)

        Return dtFecha
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA RECUPERAR LOS TOTALES DE PARES,ATADOS,LOTES EMBARCADOS Y LA FECHA DE EMBARQUE
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA QUE SE RECUPERARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_LotesAtadosPares_Embarcados(ByVal IdSalidaNave As Integer)
        Dim objSalidaDA As New Datos.SalidaNavesDA
        Dim dtTotales = objSalidaDA.Recuperar_Totales_LotesAtadosPares_Embarcados(IdSalidaNave)
        Return dtTotales
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA CONSULTAR LAS SALIDAS DE NAVES DENTRO DE UN RANGO
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA CUAL SE BUSCARAN REPORTES</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Salidas_De_Nave(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objDA As New Datos.SalidaNavesDA
        Dim dtSalidaNave As New DataTable

        dtSalidaNave = objDA.Recuperar_Salidas_De_Nave(Fecha_Inicio, Fecha_Fin, IdNave)

        Return dtSalidaNave
    End Function

    Public Sub EliminarErroresDeLaLectura(ByVal IdNave As Integer, ByVal IdEmbarque As Integer, ByVal salida_Entrada As String)
        Dim objDA As New Datos.SalidaNavesDA
        objDA.EliminarErroresDeLaLectura(IdNave, IdEmbarque, salida_Entrada)
    End Sub




End Class
