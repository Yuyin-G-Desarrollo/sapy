Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports Persistencia

Public Class InventarioPrecioBaseDA

    Private ReadOnly objPersistencia As New OperacionesProcedimientosSICY

    Public Function ConsultaInventario(cedis As Integer, fecha As Date) As DataTable
        Dim listaParametros As New List(Of SqlParameter) From {
            New SqlParameter With {
                .ParameterName = "CEDIS",
                .Value = cedis
            },
            New SqlParameter With {
                .ParameterName = "Fecha",
                .Value = fecha
            }
        }

        Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Inventario_PrecioBase_Historico_Reporte]", listaParametros)
    End Function

End Class
