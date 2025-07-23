Public Class ReporteDeInventarioBU


    Public Function ConsultaDeReporteInventario() As Entidades.ReporteDeInventarioPrecioBase
        Dim objDA As New Datos.ReporteDeInventarioDA
        Dim tabla As New DataTable
        Dim totalPares As Integer = 0
        Dim totalSinPrecio As Integer = 0
        Dim EntInventario As New Entidades.ReporteDeInventarioPrecioBase
        Try
            tabla = objDA.ConsultaDeReporteInventario()
            If IsNothing(tabla) = False Then
                With EntInventario
                    .Datos = tabla
                    For Each fila As DataRow In tabla.Rows
                        totalPares += fila.Item("Pares")
                        If fila.Item("Precio Base") = 0 Then
                            totalSinPrecio += 1
                        End If
                    Next
                    .TotalPares = totalPares
                    .ParesSiPrecio = totalSinPrecio
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return EntInventario
    End Function

End Class
