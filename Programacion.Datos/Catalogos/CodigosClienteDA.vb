Imports System.Data.SqlClient

Public Class CodigosClienteDA


    Public Function RecuperarListaCodigos_Cliente_O_Amece(ByVal FiltroCliente_o_Amece As Boolean, ByVal Filtro_Lugar As Integer, ByVal FiltroCantidad As Integer, _
                                                         ByVal IdCliente As Integer, ByVal IdListaPrecioCliente As Integer, ByVal Activo As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@CodigoAmece_Cliente"
        parametro.Value = FiltroCliente_o_Amece
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoFiltro"
        parametro.Value = Filtro_Lugar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CondicionCodigo"
        parametro.Value = FiltroCantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ClienteId"
        parametro.Value = IdCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ListaPrecioClienteId"
        parametro.Value = IdListaPrecioCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ActivoCodigo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_CODIGOSCLIENTE_ConsultaListaArticulos_Respaldo]", listaParametros)

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function comboClientes_CodigosCLiente() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = String.Empty
        Consulta = <Consulta>
                      
                   </Consulta>.Value
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function



    Public Sub Agregar_Nuevo_CodigoCliente(ByVal CodigoCliente As Entidades.CodigosCliente)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cocl_clienteid"
        parametro.Value = CodigoCliente.PClienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_productoestiloid"
        parametro.Value = CodigoCliente.PProductoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_codigocliente"
        parametro.Value = CodigoCliente.PCodigoCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_codigorapidocliente"
        parametro.Value = CodigoCliente.PCodigoRapidoCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_estilocliente"
        parametro.Value = CodigoCliente.PEstiloCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_marcacliente"
        parametro.Value = CodigoCliente.PMarcaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_coleccioncliente"
        parametro.Value = CodigoCliente.PColeccionCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_lineacliente"
        parametro.Value = CodigoCliente.PLineaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_materialcliente"
        parametro.Value = CodigoCliente.PMaterialCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_familiacliente"
        parametro.Value = CodigoCliente.PFamiliaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_colorcliente"
        parametro.Value = CodigoCliente.PColorCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_tallacliente"
        parametro.Value = CodigoCliente.PTallaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_descripcioncliente"
        parametro.Value = CodigoCliente.PDescripcionCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_cantidadempacado"
        parametro.Value = CodigoCliente.PCantidadEmpacado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("[Programacion].[SP_CodigosCliente_AltaNuevoCodigo]", listaParametros)
    End Sub

    Public Sub Editar_CodigoCliente(ByVal CodigoCliente As Entidades.CodigosCliente)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cocl_codigosclientesid"
        parametro.Value = CodigoCliente.PIdCodigoCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_codigocliente"
        parametro.Value = CodigoCliente.PCodigoCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_codigorapidocliente"
        parametro.Value = CodigoCliente.PCodigoRapidoCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_estilocliente"
        parametro.Value = CodigoCliente.PEstiloCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_marcacliente"
        parametro.Value = CodigoCliente.PMarcaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_coleccioncliente"
        parametro.Value = CodigoCliente.PColeccionCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_lineacliente"
        parametro.Value = CodigoCliente.PLineaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_materialcliente"
        parametro.Value = CodigoCliente.PMaterialCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_familiacliente"
        parametro.Value = CodigoCliente.PFamiliaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_colorcliente"
        parametro.Value = CodigoCliente.PColorCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_tallacliente"
        parametro.Value = CodigoCliente.PTallaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_descripcioncliente"
        parametro.Value = CodigoCliente.PDescripcionCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_cantidadempacado"
        parametro.Value = CodigoCliente.PCantidadEmpacado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("[Programacion].[SP_CodigosCliente_EditarCodigo]", listaParametros)

    End Sub

    Public Sub Eliminar_CodigoCliente(ByVal CodigoCliente As Entidades.CodigosCliente)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@cocl_codigosclientesid"
        parametro.Value = CodigoCliente.PIdCodigoCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cocl_motivoeliminacion"
        parametro.Value = CodigoCliente.PMotivoEliminacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        objPersistencia.EjecutarSentenciaSP("[Programacion].[SP_CodigosCliente_InactivarCodigo]", listaParametros)
    End Sub

    Public Function ValidarCodigoClienteExistente(ByVal codigo As Entidades.CodigosCliente) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = <Consulta>
                        select cocl_codigosclientesid from programacion.CodigosClientes 
                        where cocl_productoestiloid = <%= codigo.PProductoEstiloId.ToString %>
                        and cocl_tallacliente ='<%= codigo.PTallaCliente.ToString %>'
                        and cocl_clienteid = <%= codigo.PClienteId.ToString %>
                   </Consulta>.Value

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

End Class
