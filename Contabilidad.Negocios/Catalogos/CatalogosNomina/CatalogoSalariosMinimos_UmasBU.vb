Public Class CatalogoSalariosMinimos_UmasBU
    Public Function ConsultaPrecio_SalarioMIN_UMA() As List(Of Entidades.SalariosMinimosyUMAS)
        Dim objDA As New Datos.CatalogoSalariosMinimos_UmasDA
        Dim listentidad As New List(Of Entidades.SalariosMinimosyUMAS)
        Dim entidad As Entidades.SalariosMinimosyUMAS
        Dim tabla As DataTable
        Try
            tabla = objDA.ConsultaPrecio_SalarioMIN_UMA()
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    For Each Fila As DataRow In tabla.Rows
                        entidad = New Entidades.SalariosMinimosyUMAS
                        With entidad
                            .MontoSalarioMinimo = Fila.Item("Precio")
                        End With
                        listentidad.Add(entidad)
                    Next
                End If
            End If
            Return listentidad
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaBitacoraPrecio_SalarioMIN_UMA() As DataTable
        Try
            Dim objDA As New Datos.CatalogoSalariosMinimos_UmasDA
            Return objDA.ConsultaBitacoraPrecio_SalarioMIN_UMA()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ModificarPrecio_SalarioMIN_UMA(ByVal MontoSalarioMinimo As String, ByVal MontoUMA As String, ByVal MontoUMI As String, ByVal ColaboradorID As String, ByVal FechaMoificacion As DateTime, ByVal anio As Integer) As Entidades.SalariosMinimosyUMAS
        Dim objDA As New Datos.CatalogoSalariosMinimos_UmasDA
        Dim entidad As New Entidades.SalariosMinimosyUMAS
        Try
            Dim tabla = objDA.ModificarPrecio_SalarioMIN_UMA(MontoSalarioMinimo, MontoUMA, MontoUMI, ColaboradorID, FechaMoificacion, anio)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    For Each Fila As DataRow In tabla.Rows
                        entidad = New Entidades.SalariosMinimosyUMAS
                        With entidad
                            .Resp = Fila.Item("Respuesta")
                            .Mensage = Fila.Item("mensaje")
                        End With
                    Next
                End If
            End If
            Return entidad
        Catch ex As Exception
            entidad.Resp = 0
            entidad.Mensage = "Error" + ex.Message
            Return entidad
        End Try
    End Function


End Class
