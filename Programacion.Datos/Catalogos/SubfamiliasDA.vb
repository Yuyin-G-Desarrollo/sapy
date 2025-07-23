Imports System.Data.SqlClient

Public Class SubfamiliasDA

    Public Function ListarSubfamilias(ByVal clave As String, ByVal descripcion As String, ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim activoCadena As String = String.Empty

        If (activo = True) Then
            activoCadena = "True"
        ElseIf (activo = False) Then
            activoCadena = "False"
        End If
        Dim cadena As String = "Select subf_subfamiliaid, subf_descripcion, subf_activo from Programacion.Subfamilia where subf_descripcion like '%" + descripcion + "%' and subf_activo='" + activoCadena + "'"
        If (clave <> "") Then
            cadena += " and subf_codigo like '%" + clave + "%'"
        End If
        cadena += " ORDER BY subf_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function idMaxSubfamilia() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("SELECT MAX(subf_subfamiliaid) FROM Programacion.Subfamilia;")
    End Function

    Public Function VerCodigosDisponibles() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select subf_codigo from Programacion.Subfamilia where subf_activo='False' and subf_codigo not in (Select subf_codigo from  Programacion.Subfamilia where subf_codigo='True')")
    End Function

    Public Sub RegistrarSubfamilia(ByVal subfamilia As Entidades.Subfamilias, ByVal usuariocreo As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = subfamilia.PDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = subfamilia.PActivo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuariocreo
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Altas_Subfamilias", ListaParametros)
    End Sub

    Public Function ValidarRepetidos(ByVal Codigo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Select subf_codigo from Programacion.Subfamilia where subf_codigo='" + Codigo + "' and subf_activo='true'")
    End Function

    Public Sub ModificarSubfamilia(ByVal EntidadFamilia As Entidades.Subfamilias, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadFamilia.PDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadFamilia.PActivo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "IdSubfamilia"
        ParametroParaLista.Value = EntidadFamilia.PIdSubfamilia
        ListaParametros.Add(ParametroParaLista)
        operacion.EjecutarSentenciaSP("Programacion.SP_Modificar_Subfamilia", ListaParametros)

    End Sub

    Public Function VerComboSubfamilia(ByVal descripcion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select subf_Subfamiliaid, subf_descripcion from Programacion.Subfamilia where subf_activo='true'"

        If (descripcion <> "") Then
            cadena += " and subf_descripcion like '%" + descripcion + "%'"
        End If
        cadena += " order by subf_descripcion ASC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerCodigoSubfamiliaRapido(ByVal idFam As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select subf_codigo, subf_descripcion from Programacion.Subfamilia where subf_subfamiliaid =" + idFam + "")
    End Function

    Public Function validarInactivarSub(ByVal idSub As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT prod_codigo,	prod_descripcion" +
                                " FROM Programacion.Productos a" +
                                " INNER JOIN Programacion.ProductoSubfamilias b" +
                                " ON a.prod_productoid = b.prsu_productoid" +
                                " WHERE b.prsu_subfamiliaid =" + idSub +
                                " AND prod_activo = 1 AND b.prsu_activo=1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

End Class
