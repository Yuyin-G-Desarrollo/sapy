Public Class ArticulosSuelaBU

    Public Function verComboColeccion(ByVal idMarca As String) As DataTable
        Dim coleccionNegocios As New Produccion.Datos.ArticulosSuelaDA
        Return coleccionNegocios.verComboColecciones(idMarca)
    End Function

    Public Function verComboMarcas() As DataTable
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Return objDa.verComboMarcas()
    End Function

    Public Function VerArticulos(ByVal Marcaidsay As String, ByVal ColeccionId As String, UsuarioId As Integer) As DataTable
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Return objDa.verArticulos(Marcaidsay, ColeccionId, UsuarioId)
    End Function

    Public Function ListadoParametroArticulos(tipo_busqueda As Integer, naveId As Integer) As DataTable
        '-
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Dim tabla As New DataTable
        tabla = objDa.ListadoParametroArticulos(tipo_busqueda, naveId)
        Return tabla
    End Function

    Public Function verComboSuelaProgramacion() As DataTable
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Return objDa.verComboSuelaProgramacion()
    End Function

    Public Function verComboColorSuela() As DataTable
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Return objDa.verComboColorSuela()
    End Function

    Public Function verComboAcabadoSuela() As DataTable
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Return objDa.verComboAcabadoSuela()
    End Function

    Public Function verComboFamiliaSuela() As DataTable
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        Return objDa.verComboFamiliaSuela()
    End Function

    Public Sub ObtieneArticulo(ByVal pXmlArticulos As String)
        Dim objDa As New Produccion.Datos.ArticulosSuelaDA
        objDa.ObtieneArticulos(pXmlArticulos)
    End Sub

End Class
