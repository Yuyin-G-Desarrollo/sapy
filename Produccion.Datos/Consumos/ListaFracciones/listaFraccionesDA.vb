Imports System.Data.SqlClient

Public Class listaFraccionesDA

    Public Function ListaFraccionesporNave(naveid As String, marcaId As String, coleccionId As String, estatus As String, naves As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        'Dim vEstatusArticulo As String = String.Empty

        'If estatus <> "" Then
        '    Select Case estatus
        '        Case "D"
        '            estatus = "DESARROLLO"
        '        Case "AD"
        '            estatus = "AUTORIZADO DESARROLLO"
        '        Case "AP"
        '            estatus = "AUTORIZADO PARA PRODUCCIÓN"
        '        Case "I"
        '            estatus = "INACTIVO NAVE"
        '        Case "DP"
        '            estatus = "DESCONTINUADO"
        '        Case Else
        '    End Select
        'End If


        parametro.ParameterName = "@naveId"
        parametro.Value = naveid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MarcaId"
        parametro.Value = marcaId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@coleccionId"
        parametro.Value = coleccionId
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estatus"
        parametro.Value = estatus
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Naves"
        parametro.Value = naves
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[ObtenerFraccionesporNaveV1]", listaparametros)

    End Function
End Class
