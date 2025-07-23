
Public Class CatalogoRamosBU


    ''Función ListaDias para llenar la lista de ramos
    Public Function ListaRamos(ByVal activo As Boolean, ByVal nombreRamo As String, NombreCortoRamo As String) As DataTable
        Dim objListaRamosDA As New Datos.CatalogoRamosDA
        Dim tablas As New DataTable
        ListaRamos = objListaRamosDA.ListaRamos(activo, nombreRamo, NombreCortoRamo)

        Return ListaRamos
    End Function

    ''Función ListaDias para llenar la lista de ramos
    Public Function ListaRamos_Sicy() As DataTable
        Dim objListaRamosDA As New Datos.CatalogoRamosDA
        ListaRamos_Sicy = objListaRamosDA.ListaRamos_Sicy()
        Return ListaRamos_Sicy
    End Function

    ''funcion para guardar 
    Public Sub guardarRamos(ByVal Ramos As Entidades.CatalogoRamos)
        Dim objRamos As New Datos.CatalogoRamosDA
        objRamos.AltaRamos(Ramos)
    End Sub


    ''FuncionEditar
    Public Sub editarRamos(ByVal Ramos As Entidades.CatalogoRamos)
        Dim ObjEditarRamos As New Datos.CatalogoRamosDA
        ObjEditarRamos.editarRamos(Ramos)
    End Sub



End Class
