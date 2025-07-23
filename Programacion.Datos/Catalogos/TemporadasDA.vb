Imports System.Data.SqlClient

Public Class TemporadasDA

    '' OAMB CAMBIOS (06/05/2025) - Se crea el SP de la consulta.
    Public Function VerListaTemporadas(ByVal nombre As String, ByVal codigo As String, ByVal anio As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter("@Nombre", nombre)
        ListaParametros.Add(ParametroParaLista)
        ParametroParaLista = New SqlParameter("@Codigo", codigo)
        ListaParametros.Add(ParametroParaLista)
        ParametroParaLista = New SqlParameter("@Anio", anio)
        ListaParametros.Add(ParametroParaLista)
        ParametroParaLista = New SqlParameter("@Activo", activo)
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Temporadas_ConsultarTemporadas", ListaParametros)
    End Function
    ''Public Function VerListaTemporadas_ORIGINAL(ByVal nombre As String, ByVal codigo As String, ByVal anio As String, ByVal activo As Boolean) As DataTable
    ''    Dim operacion As New Persistencia.OperacionesProcedimientos
    ''    Dim cadena As String = "select temp_temporadaid, temp_codigo, temp_nombre, temp_año, temp_activo  from Programacion.Temporadas where temp_nombre like '%" + nombre + "%' and temp_activo='" + activo.ToString + "'"
    ''    If (codigo <> "") Then
    ''        cadena += " and temp_codigo like '%" + codigo + "%'"
    ''    End If
    ''    If (anio <> "") Then
    ''        cadena += " and temp_año like '%" + anio + "%'"
    ''    End If

    ''    Return operacion.EjecutaConsulta(cadena)
    ''End Function

    Public Function ContarFilas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select COUNT(*) from Programacion.Temporadas"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VeridMaximoidTemporada() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "Select max(temp_temporadaid ) from Programacion.Temporadas;"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function verCodigosDisponibles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT temp_codigo from Programacion.Temporadas   where temp_activo  ='False' and temp_codigo  not in (select temp_codigo   from Programacion.Temporadas  where temp_activo  ='True')"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub RegistrarTemporada(ByVal entidadTemporada As Entidades.Temporadas, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = entidadTemporada.pCodigoTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "nombre"
        ParametroParaLista.Value = entidadTemporada.pNombreTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "anio"
        ParametroParaLista.Value = entidadTemporada.pAnioTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@vigencia", entidadTemporada.pVigenciaTemporada)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadTemporada.pActivoTemporada
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Temporada", ListaParametros)
    End Sub

    Public Function validarRepetidos(ByVal codigo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT COUNT(*) FROM Programacion.Temporadas" +
                                " WHERE temp_activo ='TRUE'" +
                                " AND temp_codigo  ='" + codigo + "'"
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Sub EditarTemporada(ByVal entidadTemporada As Entidades.Temporadas, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "idtemporada"
        ParametroParaLista.Value = entidadTemporada.pIdTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "codigo"
        ParametroParaLista.Value = entidadTemporada.pCodigoTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "nombre"
        ParametroParaLista.Value = entidadTemporada.pNombreTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "anio"
        ParametroParaLista.Value = entidadTemporada.pAnioTemporada
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@vigencia", entidadTemporada.pVigenciaTemporada)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadTemporada.pActivoTemporada
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Temporada", ListaParametros)
    End Sub

    Public Function VerComboTemporada(ByVal descripcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "select temp_temporadaid , temp_codigo, (temp_nombre+' ('+cast (temp_año as varchar(20))+')') as 'descripcion', temp_año from Programacion.Temporadas where temp_activo ='true'"
        Dim cadena As String = "select temp_temporadaid , temp_codigo," +
            " temp_nombre as 'descripcion', temp_año" +
            " from Programacion.Temporadas where temp_activo ='true'"
        If (descripcion <> "") Then
            cadena += " and temp_nombre like '%" + descripcion + "%'"
        End If
        cadena += " ORDER BY temp_año DESC, temp_nombre"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerTemporadaRegistroRapido(ByVal idtemp As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT temp_temporadaid, temp_codigo, temp_nombre, temp_año" +
                                " FROM Programacion.Temporadas" +
                                " where temp_temporadaid =" + idtemp
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ValidarExistenModelos(ByVal idtemp As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT prod_codigo, prod_descripcion" +
                                " FROM Programacion.Productos" +
                                " WHERE prod_temporadaid =" + idtemp + " and prod_activo=1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verTemporadasRegistradas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " temp_temporadaid," +
                            " temp_nombre," +
                            " temp_año" +
                            " FROM Programacion.Temporadas" +
                            " WHERE temp_activo = 1" +
                    " ORDER BY temp_año DESC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaAnioTemporada(ByVal idTemp As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                    " temp_año" +
                        " FROM Programacion.Temporadas" +
                        " WHERE temp_temporadaid = " + idTemp.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
