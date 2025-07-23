Public Class CatalogoClasificacionClienteBU

    ''Función ListaRutas para llenar la lista de rutas
    Public Function ListaClasificacionCliente(ByVal activo As Boolean, ByVal NombreTipoTienda As String) As DataTable
        Dim objListaClasificacionDA As New Datos.CatalogoClasificacionClienteDA
        Dim tablas As New DataTable
        ListaClasificacionCliente = objListaClasificacionDA.ListaClasificacionClientes(activo, NombreTipoTienda)

        Return ListaClasificacionCliente
    End Function

    Public Function ValidarId(ByVal IdCatalago As String) As Entidades.CatalogoClasificacionesCliente

        Dim objClasificacionDA As New Datos.CatalogoClasificacionClienteDA
        Dim Clasificacion As New Entidades.CatalogoClasificacionesCliente
        Dim tablaClasificacion As New DataTable
        tablaClasificacion = objClasificacionDA.ListaValidarExistencia(IdCatalago)

        For Each fila As DataRow In tablaClasificacion.Rows
            Clasificacion.PNombre = CStr(fila("clas_nombre"))
        Next
        Return Clasificacion
    End Function

    ''funcion para guardar 
    Public Sub GuardarClasificacionCliente(ByVal ClasificacionCliente As Entidades.CatalogoClasificacionesCliente)
        Dim objCLasificacionClienteDA As New Datos.CatalogoClasificacionClienteDA
        objCLasificacionClienteDA.AgregarClasificacionCLiente(ClasificacionCliente)
    End Sub

    ''FuncionEditar
    Public Sub editarClasificacionCliente(ByVal ClasificacionCliente As Entidades.CatalogoClasificacionesCliente)
        Dim objEditarClasificacionClienteDA As New Datos.CatalogoClasificacionClienteDA
        objEditarClasificacionClienteDA.EditarClasificacionCliente(ClasificacionCliente)
    End Sub

End Class
