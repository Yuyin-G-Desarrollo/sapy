Imports System.Data.SqlClient

Public Class CredencialesDA


    Public Function obtenerFotoCredencial(ByVal idNave As Int32) As String
        Dim objDA As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim url As String = ""
        cadena = <cadena>
       SELECT
        (D.nave_credencialurl) as urlCredencial
        FROM Framework.Naves as D 
        where D.nave_naveid = <%= idNave.ToString %>
                 </cadena>.Value

        dt = objDA.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            url = dt.Rows(0).Item("urlCredencial").ToString
        End If
        Return url
    End Function

    Public Function obtenerURLCredencial(naveID As Integer, ByVal Departamento As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = naveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Departamento"
        parametro.Value = Departamento
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Nomina].[SP_obtenerURLCredencial]", listaParametros)
    End Function

End Class
