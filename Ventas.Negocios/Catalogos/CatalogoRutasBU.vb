
Public Class CatalogoRutasBU

    ''Función ListaRutas para llenar la lista de rutas
    Public Function ListaRutas(ByVal activo As Boolean, ByVal nombreRuta As String) As DataTable
        Dim objListaRutasDA As New Datos.CatalogoRutasDA
        Dim tablas As New DataTable
        ListaRutas = objListaRutasDA.ListaRutas(nombreRuta, activo)

        Return ListaRutas
    End Function

    ''funcion para guardar 
    Public Sub GuardarRutas(ByVal Rutas As Entidades.CatalogoRutas)
        Dim objRutas As New Datos.CatalogoRutasDA
        objRutas.AltaRutas(Rutas)
    End Sub


    ''FuncionEditar
    Public Sub editarRutas(ByVal Rutas As Entidades.CatalogoRutas)
        Dim objEditarRutas As New Datos.CatalogoRutasDA
        objEditarRutas.EditarRutas(Rutas)
    End Sub



End Class
