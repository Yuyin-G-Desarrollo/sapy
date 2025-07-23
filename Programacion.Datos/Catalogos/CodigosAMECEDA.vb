Imports System.Data.SqlClient

Public Class CodigosAMECEDA

    Public Function RecuperarUltimoCodigoAMECEGenerado()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = <Consulta>
                        select top 1 coam_codigoAmece from Programacion.CodigosAmece order by coam_codigoameceid desc
                   </Consulta>.Value
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function comboClientes_CodigosAMECE() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ColaboradorID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CodigosAMECE_ConsultarClientes]", listaParametros)
    End Function

    Public Function comboListaPrecioDeCliente_CodigosAMECE(ByVal IdCliente As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = <Consulta>
                        select * from Ventas.ListaVentasClientePrecio 
                        join Ventas.ListaVentasCliente on lvcl_listaventasclienteid = lvcp_listaventasclienteid
                        where lvcp_estatusid in (25,26) and lvcl_clienteid = <%= IdCliente.ToString %> 
                       AND (lvcp_vigenciafin >= CAST(GETDATE() AS date)) 
                       order by lvcp_descripcion
                   </Consulta>.Value
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function RecuperarVigenciaListaPrecio(ByVal IdListaPrecioCliente As Integer) As DataTable
        Dim objDA As New Datos.CodigosAMECEDA
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty

        Consulta = <Consulta>
                       select lvcp_vigenciainicio, lvcp_vigenciafin 
                        from Ventas.ListaVentasClientePrecio
                        where lvcp_listaventasclienteprecioid = <%= IdListaPrecioCliente.ToString %>
                   </Consulta>.Value

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function


    ''' <summary>
    ''' CONSULTA LA LISTA DE LOS PRODUCTOS QUE ESTAN EN "PEDIDOS CONFIRMADOS POR VENTAS" O EN "LISTA DE PRECIOS" O "TODOS" (OBLIGATORIO ELEGIR UNA DE LAS TRS OPCIONES); 
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
    ''' <returns>RESULTADO DE LA EJECUCION DEL PROCEDIMIENTO ALMACENADO EN UN DATATABLE</returns>
    ''' <remarks></remarks>
    Public Function CargarListaCodigosPorCliente(ByVal BanderaVerCodigosDe As Integer, ByVal BanderaConCodigo As Integer, IdClienteSAY As Integer, ByVal IdListaVentasClientePrecio As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoFiltro"
        parametro.Value = BanderaVerCodigosDe
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CondicionAmece"
        parametro.Value = BanderaConCodigo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteId"
        parametro.Value = IdClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaPrecioClienteId"
        parametro.Value = IdListaVentasClientePrecio
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_AMECE_ConsultaListaArticulos]", listaParametros)
    End Function


    Public Sub GenerarCodigoAmece(ByVal IdProductoEstilo As Integer, ByVal Talla As String, ByVal IdUsuario As Integer, ByVal ClienteId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoEstiloID "
        parametro.Value = IdProductoEstilo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Talla"
        parametro.Value = Talla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId "
        parametro.Value = IdUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteID "
        parametro.Value = ClienteId
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("[Programacion].[SP_AMECE_AltaNuevoCodigo_v2]", listaParametros)
    End Sub
End Class
