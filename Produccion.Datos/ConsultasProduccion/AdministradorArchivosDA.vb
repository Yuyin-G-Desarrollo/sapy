Imports System.Data.SqlClient

Public Class AdministradorArchivosDA
    Public Function GuardaArchivo(ByVal pXmlEstilos As String, ByVal pNombreDocumento As String, ByVal pDocumento As String, ByVal pNombreOriginal As String, ByVal pCategoria As Integer, ByVal pIdUsuario As Integer, ByVal pNombreUsuario As String, ByVal pEsOtroArchivo As Boolean, ByVal pIdColaborador As Integer, ByVal pIdNave As Integer?, ByVal pXmlEstilosElimina As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@XML_ESTILOS"
        parametro.Value = pXmlEstilos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreDocumento"
        parametro.Value = pNombreDocumento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Documento"
        parametro.Value = pDocumento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreOriginal"
        parametro.Value = pNombreOriginal
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Categoria"
        parametro.Value = pCategoria
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsiario"
        parametro.Value = pIdUsuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreUsuario"
        parametro.Value = pNombreUsuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EsOtroArchivo"
        parametro.Value = pEsOtroArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdColaborador"
        parametro.Value = pIdColaborador
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@XML_EstilosElimina"
        parametro.Value = pXmlEstilosElimina
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_InsertaArchivos_Tecnicos_Otros]", listaparametros) '.Rows(0).Item("NewNombre")
    End Function

    Public Function ObtineArchivos(ByVal pXmlEstilos As String, ByVal pNombreArchivo As String, ByVal pEsOtroArchivo As Boolean, ByVal pIdNave As Integer?, ByVal pIdColaborador As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@XML_ESTILOS"
        parametro.Value = pXmlEstilos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreArchivo"
        parametro.Value = pNombreArchivo
        listaparametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "@EsOtroArchivo"
        parametro.Value = pEsOtroArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdColaborador"
        parametro.Value = pIdColaborador
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ObtieneArchivos_Tecnicos_Otros]", listaparametros)

    End Function

    Public Function ObtineCategoriasDeptos(ByVal pEsDepto As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EsDepto"
        parametro.Value = pEsDepto
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ObtieneCategoriasDeptos]", listaparametros)

    End Function

    Public Function GuardaDeptosCategorias(ByVal pNombre As String, ByVal pEsDepto As Boolean, ByVal pImagen As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nombre"
        parametro.Value = pNombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EsDepto"
        parametro.Value = pEsDepto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Imagen"
        parametro.Value = pImagen
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_InsertaDeptosCategorias_Archivos_Tecnicos_Otros]", listaparametros)
    End Function

    Public Function ActualizaArchivo(ByVal pIdArchivo As Integer, ByVal pDocumento As String, ByVal pNombreOriginal As String, ByVal pCategoria As Integer, ByVal pIdUsuario As Integer, ByVal pNombreUsuario As String) As String
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdArchivo"
        parametro.Value = pIdArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Documento"
        parametro.Value = pDocumento
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreOriginal"
        parametro.Value = pNombreOriginal
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Categoria"
        parametro.Value = pCategoria
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsiario"
        parametro.Value = pIdUsuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreUsuario"
        parametro.Value = pNombreUsuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_EditaArchivos_Tecnicos_Otros]", listaparametros).Rows(0).Item("NewNombre").ToString()
    End Function

    Public Function ObtieneArchivosExistentes(ByVal pXmlEtilos As String, ByVal pNombreArchivo As String, ByVal pEsOtroArchivo As Boolean, ByVal pIdNave As Integer?) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@XML_ESTILOS"
        parametro.Value = pXmlEtilos
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NombreArchivo"
        parametro.Value = pNombreArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EsOtroArchivo"
        parametro.Value = pEsOtroArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ObtieneArchivosXML_Tecnicos]", listaparametros)

    End Function


    Public Function ObtieneCatalogosArchivos(ByVal pTipoConsulta As Integer, ByVal pEsDepto As Boolean, ByVal IdSeleccion As Integer, ByVal pIdSeleccionModelo As String, ByVal pIdNave As Integer, ByVal pIdMarca As Integer, ByVal pIdCorrida As Integer, ByVal pIdPielColor As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@TipoConsulta"
        parametro.Value = pTipoConsulta
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EsDepto"
        parametro.Value = pEsDepto
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdSeleccion"
        parametro.Value = IdSeleccion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMarca"
        parametro.Value = pIdMarca
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCorrida"
        parametro.Value = pIdCorrida
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdPielColor"
        parametro.Value = pIdPielColor
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ConsultaArchivos_ConsultaCatalogos]", listaparametros)

    End Function

    Public Function ObtieneAdministradorArchivos(ByVal pEsOtroArchivo As Boolean, ByVal pIdNave As Integer, ByVal pIdMarca As Integer?, ByVal pIdColeccion As Integer?) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@EsOtroArchivo"
        parametro.Value = pEsOtroArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMarca"
        parametro.Value = pIdMarca
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdColeccion"
        parametro.Value = pIdColeccion
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaArchivos_ObtieneAdministradorArchivos]", listaparametros)

    End Function

    Public Function ObtieneAdministradorArchivosTecnicos(ByVal pIdProductoEstilo As Integer, ByVal pIdNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdProductoEstilo"
        parametro.Value = pIdProductoEstilo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConsultaArchivos_ObtieneAdministradorArchivos_FichasTecnicas]", listaparametros)

    End Function

    Public Function EliminaArchivosTecnicosOtros(ByVal pIdArchivo As Integer, ByVal pIdNave As Integer, pIdProductoEstilo As Integer?, ByVal pEsOtroArchivo As Boolean) As Integer
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdArchivo"
        parametro.Value = pIdArchivo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = pIdNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdProductoEstilo"
        parametro.Value = pIdProductoEstilo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EsOtroArchivo"
        parametro.Value = pEsOtroArchivo
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_EliminaArchivos_Otros_Tecnicos]", listaparametros).Rows(0).Item("NumArchivos")

    End Function


End Class
