Public Class CargaNaveArticuloBU
    Public Function CargarNoAsignados(ByVal Nave As Integer) As DataTable
        Dim objNaveArticulos As New Programacion.Datos.CargaNaveArticuloDA
        Dim tbNaveAsigandos As DataTable

        tbNaveAsigandos = objNaveArticulos.CargarProductosNaveNoAsignado(Nave)
        Return tbNaveAsigandos
    End Function

    Public Function CargarAsignados(ByVal Nave As Integer) As DataTable
        Dim objNaveArticulos As New Programacion.Datos.CargaNaveArticuloDA
        Dim tbNaveNoAsigandos As DataTable

        tbNaveNoAsigandos = objNaveArticulos.CargarProductosNaveAsignado(Nave)
        Return tbNaveNoAsigandos
    End Function

    Public Function InsertarModificarNaveProductos(ByVal tabla As DataTable, ByVal usuario As Integer, ByVal nave As Integer, ByVal prioridad As Integer) As Boolean
        Dim objNaveArticulos As New Programacion.Datos.CargaNaveArticuloDA
        Dim validacion As Boolean = True

        For Each row As DataRow In tabla.Rows
            If row("Prioridad") Is DBNull.Value Or row("Prioridad").ToString = "" Then
                validacion = objNaveArticulos.InsertarModificaNaveArticulo(nave, _
                                                             row("pres_productoestiloid"), _
                                                             prioridad, _
                                                             row("FechaInicioProduccion"), _
                                                             row("FechaFinProduccion"), _
                                                            usuario)
            Else
                validacion = objNaveArticulos.InsertarModificaNaveArticulo(nave, _
                                                                     row("pres_productoestiloid"), _
                                                                     row("Prioridad"), _
                                                                     row("FechaInicioProduccion"), _
                                                                     row("FechaFinProduccion"), _
                                                                    usuario)
            End If



        Next

        Return validacion
    End Function

End Class
