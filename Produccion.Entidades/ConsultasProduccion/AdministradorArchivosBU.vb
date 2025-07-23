Imports Produccion.Datos

Public Class AdministradorArchivosBU

    Public Function GuardarArchivo(ByVal pXmlEstilos As String, ByVal pNombreDocumento As String, ByVal pDocumento As String, ByVal pNombreOriginal As String, ByVal pCategoria As Integer, ByVal pIdUsuario As Integer, ByVal pNombreUsuario As String, ByVal pEsOtroArchivo As Boolean, ByVal pIdColaborador As Integer, ByVal pIdNave As Integer?, ByVal pXmlEstilosElimina As String) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.GuardaArchivo(pXmlEstilos, pNombreDocumento, pDocumento, pNombreOriginal, pCategoria, pIdUsuario, pNombreUsuario, pEsOtroArchivo, pIdColaborador, pIdNave, pXmlEstilosElimina)
    End Function

    Public Function ObtieneArchivo(ByVal pXmlEstilos As String, ByVal pNombreArchivo As String, ByVal pEsOtroArchivo As Boolean, ByVal pIdNave As Integer?, ByVal pIdColaborador As Integer) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.ObtineArchivos(pXmlEstilos, pNombreArchivo, pEsOtroArchivo, pIdNave, pIdColaborador)
    End Function

    Public Shared Function ArchivoEnUso(ByVal Ruta As String) As Boolean
        Dim nFileNum As Integer
        nFileNum = FreeFile()

        Try
            FileOpen(nFileNum, Ruta, OpenMode.Binary, OpenAccess.Write)
            FileClose(nFileNum)
            Return False
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Function ObtenerCategoriasDeptos(ByVal pEsDepto As Boolean) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.ObtineCategoriasDeptos(pEsDepto)
    End Function

    Public Function GuardarCategoriasDeptos(ByVal pNombre As String, ByVal pEsDepto As Boolean, ByVal pImagen As String) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.GuardaDeptosCategorias(pNombre, pEsDepto, pImagen)
    End Function

    Public Function ActualizarArchivo(ByVal pIdArchivo As Integer, ByVal pDocumento As String, ByVal pNombreOriginal As String, ByVal pCategoria As Integer, ByVal pIdUsuario As Integer, ByVal pNombreUsuario As String) As String
        Dim obj As New AdministradorArchivosDA
        Return obj.ActualizaArchivo(pIdArchivo, pDocumento, pNombreOriginal, pCategoria, pIdUsuario, pNombreUsuario)
    End Function

    Public Function ObtenerArchivosExistentes(ByVal pXmlEtilos As String, ByVal pNombreArchivo As String, ByVal pEsOtroArchivo As Boolean, ByVal pIdNave As Integer?) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.ObtieneArchivosExistentes(pXmlEtilos, pNombreArchivo, pEsOtroArchivo, pIdNave)
    End Function

    Public Function ObtenerCatalogosArchivo(ByVal pTipoConsulta As Integer, ByVal pEsDepto As Boolean, ByVal pIdSeleccion As Integer, ByVal pIdSeleccionModelo As String, pIdNave As Integer, ByVal pIdMarca As Integer, ByVal pIdCorrida As Integer, ByVal pIdPielColor As String) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.ObtieneCatalogosArchivos(pTipoConsulta, pEsDepto, pIdSeleccion, pIdSeleccionModelo, pIdNave, pIdMarca, pIdCorrida, pIdPielColor)
    End Function

    Public Function ObtenerAdministradorArchivos(ByVal pEsOtroArchivo As Boolean, ByVal pIdNave As Integer, ByVal pIdMarca As Integer?, ByVal pIdColeccion As Integer?) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.ObtieneAdministradorArchivos(pEsOtroArchivo, pIdNave, pIdMarca, pIdColeccion)
    End Function

    Public Function ObtenerAdministradorArchivosTecnicos(ByVal pIdProductoEstilo As Integer, ByVal pIdNave As Integer) As DataTable
        Dim obj As New AdministradorArchivosDA
        Return obj.ObtieneAdministradorArchivosTecnicos(pIdProductoEstilo, pIdNave)
    End Function

    Public Function EliminarArchivosTecnicosOtros(ByVal pIdArchivo As Integer, ByVal pIdNave As Integer, ByVal pIdProdutoEstilo As Integer, ByVal pEsOtroArchivo As Boolean) As Integer
        Dim obj As New AdministradorArchivosDA
        Return obj.EliminaArchivosTecnicosOtros(pIdArchivo, pIdNave, pIdProdutoEstilo, pEsOtroArchivo)
    End Function


End Class
