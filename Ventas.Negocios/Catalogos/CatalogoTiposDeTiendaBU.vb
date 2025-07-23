Public Class CatalogoTiposDeTiendaBU

    ''Función ListaRutas para llenar la lista de rutas
    Public Function ListaTipoTienda(ByVal activo As Boolean, ByVal NombreTipoTienda As String) As DataTable
        Dim objListaTipoTiendaDA As New Datos.CatalogoTiposDeTiendaDA
        Dim tablas As New DataTable
        ListaTipoTienda = objListaTipoTiendaDA.ListaTipoTiendas(activo, NombreTipoTienda)

        Return ListaTipoTienda
    End Function

    ''funcion para guardar 
    Public Sub GuardarTipoTienda(ByVal TipoTienda As Entidades.CatalogoTiposDeTienda)
        Dim objTipoTienda As New Datos.CatalogoTiposDeTiendaDA
        objTipoTienda.AgregarTipoTienda(TipoTienda)
    End Sub


    ''FuncionEditar
    Public Sub editarTipoTienda(ByVal TipoTienda As Entidades.CatalogoTiposDeTienda)
        Dim objEditarTipoTienda As New Datos.CatalogoTiposDeTiendaDA
        objEditarTipoTienda.EditarTipoTiendas(TipoTienda)
    End Sub



End Class
