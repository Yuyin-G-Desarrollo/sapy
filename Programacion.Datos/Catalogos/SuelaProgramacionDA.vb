Imports System.Data.SqlClient


Public Class SuelaProgramacionDA

    Public Function verSuelaProgramacionId(ByVal SuelaProgramacionID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametroLista As New SqlParameter
        Try
            parametroLista.ParameterName = "@SuelaProgramacionID"
            parametroLista.Value = SuelaProgramacionID
            listaParametros.Add(parametroLista)

            Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Modelos_ObtenerInfoSuelaProgramacion]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
