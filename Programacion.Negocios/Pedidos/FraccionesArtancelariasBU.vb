Public Class FraccionesArtancelariasBU

    ''' <summary>
    ''' CONECTA CON LA CAMPA DE DATOS Y RECUPERA UN DATATABLE CON LA LISTA DE LOS REGISTROS DE FRACCIONES ARANCELARIAS EXISTENTES(ACTIVAS O INACTIVAS)
    ''' </summary>
    ''' <param name="Activo">VARIABLE DEL TIPO BOLEANO, 1 = CONSULTAR REGISTROS ACTIVOS, 0 = CONSULTAR REGISTROS INACTIVOS</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Catalogo_FraccionesArancelarias(ByVal Activo As Boolean) As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA
        Lista_Catalogo_FraccionesArancelarias = New DataTable

        Lista_Catalogo_FraccionesArancelarias = objDA.Lista_Catalogo_FraccionesArancelarias(Activo)

        Return Lista_Catalogo_FraccionesArancelarias
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS Y RECUPERA LA LISTA DE LOS DETALLES DE UNA O VARIAS FRACCIONES ARANCELARIAS(ACTIVAS O INACTIVAS ESTO DEPENDE DE SI EL ID DE LA(S) FRACCION(ES) ES ACTIVO O INACTIVO)
    ''' </summary>
    ''' <param name="Ids_Fracciones">IDS DE LAS FRACCIONES DE LAS CUALES SE RECUPERARAN SUS DETALLES</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Lista_FraccionesArancelarias_Detalles(ByVal Ids_Fracciones As String) As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA
        Lista_FraccionesArancelarias_Detalles = New DataTable

        Lista_FraccionesArancelarias_Detalles = objDA.Lista_FraccionesArancelarias_Detalles(Ids_Fracciones)

        Return Lista_FraccionesArancelarias_Detalles
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA RECUPERAR TODOS LOS PRODUCTOS QUE CUMPLAN CON LA CONDICIÓN DE FAMILIA, TIPO, SUELA, FORO, CORTE DE UNA O VARIAS FRACCIOES ARANCELARIAS
    ''' </summary>
    ''' <param name="hsIdFracciones">HASH SET CON LOS IDS DE LAS FRACCIONES ARANCELARIAS DE LAS CUALES SERAN BUSCADOS TODOS LOS PRODUCTOS QUE ENTREN EN LAS CARACTERISTICAS DE CADA
    ''' UNO DE LOS DETALLES DE CADA FRACCIÓN ARANCELARIA</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Articulos(ByVal hsIdFracciones As HashSet(Of Integer)) As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA
        Dim ids_Fracciones As String = String.Empty

        For Each item In hsIdFracciones
            If ids_Fracciones = "" Then
                ids_Fracciones = item.ToString
            Else
                ids_Fracciones += "," + item.ToString
            End If
        Next

        Lista_Articulos = objDA.Lista_Articulos(ids_Fracciones)

        Return Lista_Articulos
    End Function

    ''' <summary>
    ''' OBTIENE EL ID Y EL CODIGO + DESCIPCION DE TODAS LAS FRACCIONES ARANCELARIAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECICION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_FraccionesArancelariasActivas_SAY() As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_FraccionesArancelariasActivas_SAY = objDA.Lista_FraccionesArancelariasActivas_SAY

        Return Lista_FraccionesArancelariasActivas_SAY
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODAS LAS FAMILIAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Familias_Activas_SAY() As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_Familias_Activas_SAY = objDA.Lista_Familias_Activas_SAY

        Return Lista_Familias_Activas_SAY
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DEL ID Y LA DESCRIPCION DE TODOS LOS CORTES(TABLA PIELMUESTRA) ACTIVOS DE LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_PielMuestra_o_Corte_Activa_SAY() As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_PielMuestra_o_Corte_Activa_SAY = objDA.Lista_PielMuestra_o_Corte_Activa_SAY

        Return Lista_PielMuestra_o_Corte_Activa_SAY
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRICION DE TODOS LOS FORROS ACTIVOS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Forros_Activos_SAY() As DataTable
       Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_Forros_Activos_SAY = objDA.Lista_Forros_Activos_SAY

        Return Lista_Forros_Activos_SAY
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODAS LAS SUELAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</remarks>
    Public Function Lista_Suelas_Activas_SAY() As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_Suelas_Activas_SAY = objDA.Lista_Suelas_Activas_SAY

        Return Lista_Suelas_Activas_SAY
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODOS LOS TIPO DE PRODUCTO(TABLA TIPOCATEGORIA) ACTIVAS DE LA BD DEL SAY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</remarks>
    Public Function Lista_TipoCategoria_Activos_SAY() As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_TipoCategoria_Activos_SAY = objDA.Lista_TipoCategoria_Activos_SAY

        Return Lista_TipoCategoria_Activos_SAY
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODAS LAS CORRIDAS MEXICANAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Corridas_Mexicanas_Activas_SAY() As DataTable
       Dim objDA As New Datos.FraccionesArancelariasDA

        Lista_Corridas_Mexicanas_Activas_SAY = objDA.Lista_Corridas_Mexicanas_Activas_SAY

        Return Lista_Corridas_Mexicanas_Activas_SAY
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA RECUPERAR UNA LISTA CON TODAS LAS TALLAS PERTENECIENTES A UNA CORRIDA EN ESPECIFICO, ADEMAS DE ESTO EN UN CAMPO MUESTRA SI ESTA TALLA YA ESTA ASIGNADA A ALGUNA 
    ''' FRACCIÓN ARANCELARIA EXISTENTE Y SI ESTA FRACCION ESTA ACTIVA O INACTIVA
    ''' </summary>
    ''' <param name="IdCorrida">ID DE LA CORRIDA DE LA CUAL SE RECUPERARAN LAS TALLAS</param>
    ''' <param name="objFraccionArancelariaDetalle">OBJETO DE LA ENTIDAD FRACCIONES_ARANCELARIAS_DETALLES CON LAS CARACTERIISTICAS CON LAS CUALES DEBERAN
    ''' COINCIDIR LOS PRODUCTOS BUSCADOS(FAMILIA, CORTE, TIPO, FORRO, SUELA)</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function ListaTallas_Para_FraccionArancelariaDetalles(ByVal IdCorrida As Integer, ByVal objFraccionArancelariaDetalle As Entidades.Fracciones_Arancelarias_Detalles) As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA
        ListaTallas_Para_FraccionArancelariaDetalles = New DataTable

        ListaTallas_Para_FraccionArancelariaDetalles = objDA.ListaTallas_Para_FraccionArancelariaDetalles(IdCorrida, objFraccionArancelariaDetalle)

        Return ListaTallas_Para_FraccionArancelariaDetalles
    End Function

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA GUARDAR RGISTROS EN LA TABLA DE DETALLES DE LAS FRACCIONES ARANCELARIAS, BASANDOSE EN UNA LISTA QUE RECIBE LA FUNCION, LA CUAL
    ''' CONTIENE LA CANTIDAD DE DETALLES A AGREGAR Y SUS RESPECTIVOS ATRIBUTOS
    ''' </summary>
    ''' <param name="lsFraccionArancelaria">LISTA DE LA CALSE ENTIDADES.FRACCIONES_ARANCELARIAS_DETALLES</param>
    ''' <remarks></remarks>
    Public Sub GuardarFraccionArancelariaDetalles(ByVal lsFraccionArancelaria As List(Of Entidades.Fracciones_Arancelarias_Detalles))
        Dim objDA As New Datos.FraccionesArancelariasDA

        For Each item In lsFraccionArancelaria
            objDA.GuardarFraccionArancelariaDetalles(item)
        Next
    End Sub

    ''' <summary>
    ''' INACTIVA REGISTROS DE UNA O VARIOS REGISTROS DE LA TABLA DE DETALLES DE LAS FRACCIONES ARANCELARIAS
    ''' </summary>
    ''' <param name="ids_detalles"> CADENA CON LOS IDS DE LOS REGISTROS A INACTIVAR</param>
    ''' <remarks></remarks>
    Public Sub Eliminar_FraccionesDetalles(ByVal ids_detalles As String)
        Dim objDA As New Datos.FraccionesArancelariasDA

        objDA.Eliminar_FraccionesDetalles(ids_detalles)
    End Sub

    Public Function ListaFracciones_De_Detalle_SoloConsulta(ByVal IdCorrida As Integer, ByVal objFraccionArancelariaDetalle As Entidades.Fracciones_Arancelarias_Detalles) As DataTable
        Dim objDA As New Datos.FraccionesArancelariasDA
        ListaFracciones_De_Detalle_SoloConsulta = objDA.ListaFracciones_De_Detalle_SoloConsulta(IdCorrida, objFraccionArancelariaDetalle)
        Return ListaFracciones_De_Detalle_SoloConsulta
    End Function
End Class
