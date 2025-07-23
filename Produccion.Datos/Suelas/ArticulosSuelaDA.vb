Imports System.Data.SqlClient

Public Class ArticulosSuelaDA

    Public Function VerComboColecciones(ByVal idMarca As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select cl.cole_descripcion" +
            " from Programacion.Colecciones as cl" +
            " inner join Programacion.ColeccionMarca as cm" +
            " on cl.cole_coleccionid = cm.coma_coleccionid" +
            " where cl.cole_activo ='True'"
        If (idMarca <> "") Then
            cadena += " and cm.coma_marcaid in (" + idMarca + ")"
        End If

        cadena += "and cm.coma_activo = 1 group by cl.cole_descripcion" +
            " order by cl.cole_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verComboMarcas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select marc_marcaid," +
                                " marc_codigo as 'Código'," +
                                " marc_descripcion as 'Descripción'," +
                                " marc_escliente, marc_codigosicy" +
                                " from Programacion.Marcas" +
                                " where marc_activo='True'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verComboSuelaProgramacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT suel_suelaid," +
                                "suel_descripcion " +
                                "FROM Programacion.TBL_SuelaGlobal " +
                                "WHERE suel_activo= 1 " +
                                "ORDER BY suel_descripcion ASC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verComboColorSuela() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT cosu_colorsuelaid," +
                                "cosu_nombrecolor " +
                                "FROM Programacion.TBL_ColorSuela " +
                                "WHERE cosu_activo=1 "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verComboAcabadoSuela() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT * FROM Programacion.TBL_Suelas_Acabado WHERE tsa_activo = 1 ORDER BY tsa_nombreacabado asc"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verComboFamiliaSuela() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT * FROM Programacion.TBL_Suelas_Familia WHERE tsf_activo = 1 ORDER BY tsf_nombrefamilia asc"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function verArticulos(ByVal Marcaidsay As String, ByVal ColeccionId As String, UsuarioId As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@MarcaIdSay"
        parametro.Value = Marcaidsay
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ColeccionId"
        parametro.Value = ColeccionId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = UsuarioId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Suelas_ConsultaArticulo_CargaSuelas]", listaParametros)
        'Return operacion.EjecutarConsultaSP("[Produccion].[SP_Suelas_ConsultaArticulo_CargaSuelas_Prueba]", listaParametros)

    End Function

    Public Function ListadoParametroArticulos(tipo_busqueda As Integer, naveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "TipoConsulta"
        parametro.Value = tipo_busqueda
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ArticulosSuela_ConsultaFiltros]", listaparametros)

    End Function



    Public Function ObtieneArticulos(ByVal pXmlArticulos As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XML_ARTICULOS"
        parametro.Value = pXmlArticulos
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_Suelas_EditarArticulo]", listaparametros)
    End Function



End Class
