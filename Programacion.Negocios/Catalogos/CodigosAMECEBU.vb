Public Class CodigosAMECEBU

    Public Function RecuperarUltimoCodigoAMECEGenerado() As DataTable
        Dim objDA As New Datos.CodigosAMECEDA

        RecuperarUltimoCodigoAMECEGenerado = objDA.RecuperarUltimoCodigoAMECEGenerado
        
        Return RecuperarUltimoCodigoAMECEGenerado
    End Function


    Public Function comboClientes_CodigosAMECE() As DataTable
        Dim objDA As New Datos.CodigosAMECEDA
        comboClientes_CodigosAMECE = objDA.comboClientes_CodigosAMECE()
        Return comboClientes_CodigosAMECE
    End Function


    Public Function comboListaPrecioDeCliente_CodigosAMECE(ByVal IdCliente As Integer) As DataTable
        Dim objDA As New Datos.CodigosAMECEDA
        comboListaPrecioDeCliente_CodigosAMECE = objDA.comboListaPrecioDeCliente_CodigosAMECE(IdCliente)
        Return comboListaPrecioDeCliente_CodigosAMECE
    End Function

    Public Function RecuperarVigenciaListaPrecio(ByVal IdListaPrecioCliente As Integer) As DataTable
        Dim objDA As New Datos.CodigosAMECEDA

        RecuperarVigenciaListaPrecio = objDA.RecuperarVigenciaListaPrecio(IdListaPrecioCliente)

        Return RecuperarVigenciaListaPrecio

    End Function



    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS PARA CONSULTAR LA LISTA DE LOS PRODUCTOS QUE ESTAN EN "PEDIDOS CONFIRMADOS POR VENTAS" O EN "LISTA DE PRECIOS" O "TODOS" (OBLIGATORIO ELEGIR UNA DE LAS TRS OPCIONES); 
    ''' PRODUCTOS QUE TIENEN CODIGO AMECE O PRODUCTOS QUE NO TIENEN CODIGO AMECE O TODOS (OBLIGATORIO SELECCIONAR UNA DE LAS TRS OPCIONES);
    ''' PRODUCTOS ASIGNADOS A UN CLIENTE (FILTRO OBLIGATORIO); PRODUCTOS EN UNA LISTA DE PRECIOS DE CLIENTE(OPCIONAL, SOLO ES OBLIGATORIO CUANDO SE ELECCIONA EL FILTRO "VER
    ''' PRODUCTO DE LISTA DE PRECIOS")
    ''' </summary>
    ''' <param name="BanderaVerCodigosDe">
    ''' VARIABLE DEL TIPO ENTERO PARA SELECCIONAR UNA DE LAS TRES OPCIONES DEL FILTRO "VER PRODUCTOS EN":
    '''     1= VER PRODUCTOS EN PEDIDOS CONFIRMADOS POR VENTAS
    '''     2= VER PRODUCTOS EN LISTA DE PRECIOS
    '''     3= VER TODOS LOS PRODUCTOS
    ''' </param>
    ''' <param name="BanderaConCodigo">
    ''' VARIABLE DEL TIPO ENTERO PARA SELECCIONAR UNA DE LAS OPCIONES DEL FILTRO "CON CODIGO AMECE"
    '''     1= SI
    '''     2= NO
    '''     3= TODOS
    ''' </param>
    ''' <param name="IdClienteSAY"> ID DEL CLIENTE DEL CUAL SE CONSULTARAN LOS PRODUCTOS</param>
    ''' <param name="IdListaVentasClientePrecio">ID DE LA LISTA DE PRECIOS DE LA CUAL SE CONSULTARAN LOS PRODUCTOS</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA</returns>
    ''' <remarks></remarks>
    Public Function CargarListaCodigosPorCliente(ByVal BanderaVerCodigosDe As Integer, ByVal BanderaConCodigo As Integer, IdClienteSAY As Integer, ByVal IdListaVentasClientePrecio As Integer) As DataTable
        Dim objDA As New Datos.CodigosAMECEDA

        CargarListaCodigosPorCliente = objDA.CargarListaCodigosPorCliente(BanderaVerCodigosDe, BanderaConCodigo, IdClienteSAY, IdListaVentasClientePrecio)

        Return CargarListaCodigosPorCliente

    End Function


    Public Sub GenerarCodigoAmece(ByVal IdProductoEstilo As Integer, ByVal Talla As String, ByVal IdUsuario As Integer, ByVal ClienteId As Integer)
        Dim objDA As New Datos.CodigosAMECEDA
        objDA.GenerarCodigoAmece(IdProductoEstilo, Talla, IdUsuario, ClienteId)
    End Sub


End Class
