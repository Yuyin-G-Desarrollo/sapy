Imports Produccion.Datos

Public Class AdministracionKioskoBU
    Dim objDA As New AdministracionKioskoDA
    Public Function ConsultarModelosImportadosVigentes()
        Return objDA.ConsultarModelosImportadosVigentes()
    End Function

    Public Function InsertarImportacionModelos(ByVal archivo As String, ByVal dtModelos As DataTable) As DataTable
        Return objDA.InsertarImportacionModelos(archivo, dtModelos)
    End Function

    Public Function InsertarConfiguracionesKioskoCITY(ByVal rutaFotografiaPrincipal As String,
                                                     ByVal rutaFotografiaExterna As String,
                                                     ByVal rutaFotografiaInterna As String,
                                                     ByVal rutaFichaTecnica As String) As DataTable
        Return objDA.InsertarConfiguracionesKioskoCITY(rutaFotografiaPrincipal, rutaFotografiaExterna, rutaFotografiaInterna, rutaFichaTecnica)
    End Function

    Public Function ConsultarConfiguracionesKioskoCITY()
        Return objDA.ConsultarConfiguracionesKioskoCITY()
    End Function

    Public Function ConsultarModelos(ByVal tipoBusqueda As String, ByVal busqueda As String, ByVal busqueda2 As String, ByVal busqueda3 As String) As DataTable
        Return objDA.ConsultarModelos(tipoBusqueda, busqueda, busqueda2, busqueda3)
    End Function
End Class
