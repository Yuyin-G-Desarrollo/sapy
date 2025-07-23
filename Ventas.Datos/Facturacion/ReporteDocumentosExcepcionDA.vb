Imports System.Data.SqlClient

Public Class ReporteDocumentosExcepcionDA

    Public Function ConsultarReportesExcepcion(ByVal FechaDel As String,
                                               ByVal FechaAl As String,
                                               ByVal ClientesIDSay As String,
                                               ByVal IdEmisor As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter With {
            .ParameterName = "FechaDel",
            .Value = FechaDel
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "FechaAl",
            .Value = FechaAl
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "ClientesIDSay",
            .Value = ClientesIDSay
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "IdEmisor",
            .Value = IdEmisor
        }
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Facturacion_ConsultaDocumentosExcepcion]", listaParametros)
    End Function

End Class
