Imports Ventas.Datos.PrecioDA

Public Class PrecioBU

    Dim dtTablaRecuperarParametros As New DataTable

    ''' <summary>
    ''' CONSULTA EL ID DE LA LISTA DE PRECIOS DE VENTA, EL INCREMENTO POR PAR, TIPO DE INCREMENTO(PORCENTAJE O MONEDA), INICIO DEL RANGO DE FACTURACION,
    ''' FIN DEL RANGO DE FACTURACION, INICIO DEL RANGO DE DESCUENTOS, FIN DEL RANGO DE DESCUENTOS DE LA TABLA VENTAS.LISTAPRECIOSVENTA
    ''' </summary>
    ''' <param name="Id_Lista_De_Precio">ID DE LA LISTA DE PRECIO DE LA CUAL SE RECUPERARA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Valores_De_Lista_De_Precios(ByVal Id_Lista_De_Precio As Integer) As DataTable
        Dim objPrecioDA As New Datos.PrecioDA

        Return objPrecioDA.Recuperar_Valores_De_Lista_De_Precios(Id_Lista_De_Precio)
    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE TIPOS DE IVA ASIGNADOS PARA ESA LISTA DE PRECIOS
    ''' </summary>
    ''' <param name="Id_Lista_De_Precio">ID DE LISTA DE PRECIOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Lista_Tipos_Iva(ByVal Id_Lista_De_Precio As Integer) As DataTable
         Dim objPrecioDA As New Datos.PrecioDA

        Return objPrecioDA.Recuperar_Lista_Tipos_Iva(Id_Lista_De_Precio)
    End Function

    ''' <summary>
    ''' CONSULTA LA LISTA DE TIPOS DE FLETES ASIGNADO PARA UNA LISTA DE PRECIOS
    ''' </summary>
    ''' <param name="Id_Lista_De_Precio">ID DE LA LISTA DE PRECIOS DE LA CUAL SE RECUPERARA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Lista_Tipos_Flete(ByVal Id_Lista_De_Precio As Integer) As DataTable
           Dim objPrecioDA As New Datos.PrecioDA

        Return objPrecioDA.Recuperar_Lista_Tipos_Flete(Id_Lista_De_Precio)
    End Function

    ''' <summary>
    ''' RECUEPRA EL ID DE LA CONF. DE LISTA DE CLIENTE, EL ID DE LA LISTA DE VENTAS EN LA QUE EL CLIENTE ESTA ASIGNADO, EL DESCUENTO, LA FACTURACION, EL ID DEL TIPO DE FLETE,
    ''' EL ID DEL TIPO DE IVA, EL ID DEL TIPO DE MONEDA DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="Id_Lista_Precios">ID DE LA LSITA DE PRECIOS EN LA QUE ESTA ASIGNADO EL CLIENTE</param>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA EN UNA TABLA DE DATOS</returns>
    ''' <remarks></remarks>
    Public Function recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios(ByVal Id_Lista_Precios As Integer, ByVal IdCliente As Integer) As DataTable
        Dim objPrecioDA As New Datos.PrecioDA

        Return objPrecioDA.recuperar_Informacion_Cliente_Para_Configurar_Lista_Precios(Id_Lista_Precios, IdCliente)
    End Function


    Public Function Recuperar_Paridad_Moneda(ByVal IdMoneda As Integer) As DataTable
        Dim objPrecioDA As New Datos.PrecioDA
        Recuperar_Paridad_Moneda = objPrecioDA.Recuperar_Paridad_Moneda(IdMoneda)
        Return Recuperar_Paridad_Moneda
    End Function


    Public Function Guardar_Valores_de_Lista_de_Precios(ByVal IdCliente As Integer, ByVal IdListaPrecioVentas As Integer, ByVal Descuentos As Double, ByVal Facturacion As _
                                                        Integer, ByVal IdFlete As Integer, ByVal IdIVA As Integer, ByVal IdMoneda As Integer, ByVal incoterm As Integer,
                                                        ByVal DescuentoPorArticulo As Boolean) As DataTable
        Dim objPrecioDA As New Datos.PrecioDA
        Guardar_Valores_de_Lista_de_Precios = New DataTable
        Guardar_Valores_de_Lista_de_Precios = objPrecioDA.Guardar_Valores_de_Lista_de_Precios(IdCliente, IdListaPrecioVentas, Descuentos, Facturacion, IdFlete, _
                                                                                              IdIVA, IdMoneda, incoterm, DescuentoPorArticulo)
        Return Guardar_Valores_de_Lista_de_Precios
    End Function


    Public Function recuperar_Id_Lista_Base(ByVal IdListaVentas As Integer) As DataTable
        Dim objPrecioDA As New Datos.PrecioDA

        recuperar_Id_Lista_Base = objPrecioDA.recuperar_Id_Lista_Base(IdListaVentas)

        Return recuperar_Id_Lista_Base
    End Function


    Public Function Asignar_Nueva_Lista_De_Precios_A_Cliente(ByVal IdListaPrecioVentaActual As Integer, ByVal IdListaPrecioVentaPorAsignar As Integer, _
        ByVal IdMoneda As Integer, ByVal IdClienteSay As Integer) As DataTable
        Asignar_Nueva_Lista_De_Precios_A_Cliente = New DataTable
        Dim objDAPrecio As New Datos.PrecioDA

        Asignar_Nueva_Lista_De_Precios_A_Cliente = objDAPrecio.Asignar_Nueva_Lista_De_Precios_A_Cliente(IdListaPrecioVentaActual, IdListaPrecioVentaPorAsignar, _
                                                                                                        IdMoneda, IdClienteSay)

        Return Asignar_Nueva_Lista_De_Precios_A_Cliente
    End Function


    Public Function ValidarPermitirCambioLP_y_Moneda(ByVal IdListaPrecioVenta As Integer, ByVal IdClienteSAY As Integer) As DataTable
        Dim objDA As New Datos.PrecioDA
        ValidarPermitirCambioLP_y_Moneda = New DataTable
        ValidarPermitirCambioLP_y_Moneda = objDA.ValidarPermitirCambioLP_y_Moneda(IdListaPrecioVenta, IdClienteSAY)
        Return ValidarPermitirCambioLP_y_Moneda
    End Function

    Public Function RecuperarInformacionListaVentaClientePrecio(ByVal IdClienteSay As Integer, ByVal IdListaVentas As Integer, ByVal NombreListaVentaClientePrecio As String) As DataTable
        Dim objDA As New Datos.PrecioDA

        Return objDA.RecuperarInformacionListaVentaClientePrecio(IdClienteSay, IdListaVentas, LTrim(RTrim(NombreListaVentaClientePrecio)))
    End Function


End Class
