Public Class ConsultaLotesPiloto

    '''<comentario>
    ''' Obtiene los lotes pilotos de la nave por rango de fechas
    '''</comentario>
    '''<parametro1>FechaInicio</parametro1>
    '''<parametro1>FechaFin</parametro1>
    '''<parametro1>Nave</parametro1>
    '''<retorno>Objeto ConsultaLotesPiloto</retorno>

    Public Function ConsultarLotesPiloto(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Nave As Integer) As List(Of Entidades.ConsultaLotesPiloto)
        Dim objDA As New Datos.ConsultaLotesPilotoDA
        Dim tabla As New DataTable
        Dim ListEntLotesPiloto As New List(Of Entidades.ConsultaLotesPiloto)
        Dim EntLotesPiloto As Entidades.ConsultaLotesPiloto
        Try
            tabla = objDA.ConsultarLotesPiloto(FechaInicio, FechaFin, Nave)
            If IsNothing(tabla) = False Then
                If tabla.Rows.Count > 0 Then
                    For Each Fila As DataRow In tabla.Rows
                        EntLotesPiloto = New Entidades.ConsultaLotesPiloto
                        With EntLotesPiloto
                            .FolioInspeccion = Fila.Item("FolioInspeccion")
                            .FolioIngreso = Fila.Item("FolioIngreso")
                            .Lote = Fila.Item("Lote")
                            .Nave = Fila.Item("Nave")
                            .Año = Fila.Item("Año")
                            .ParesLote = Fila.Item("ParesLote")
                            .ParesInspeccionadosLote = Fila.Item("ParesInspeccionadosLote")
                            .Incidencia = Fila.Item("Incidencia")
                            .Cliente = Fila.Item("Cliente")
                            .ModeloSICY = Fila.Item("ModeloSICY")
                            .ModeloSAY = Fila.Item("ModeloSAY")
                            .Articulo = Fila.Item("Articulo")
                            .CodigoPar = Fila.Item("CodigoPar")
                            .CodigoAtado = Fila.Item("CodigoAtado")
                            .Incidencia = Fila.Item("Incidencia")
                            .FechaRegistroIncidencia = Fila.Item("FechaRegistroIncidencia")
                            .Inspector = Fila.Item("Inspector")
                            .IncidenciaMenor = Fila.Item("IncidenciaMenor")
                            .IncidenciaMayor = Fila.Item("IncidenciaMayor")
                            .ParesDeVueltos = Fila.Item("ParesDeVueltos")
                            .Observaciones = Fila.Item("Observaciones")
                        End With
                        ListEntLotesPiloto.Add(EntLotesPiloto)
                    Next
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return ListEntLotesPiloto

    End Function
End Class
