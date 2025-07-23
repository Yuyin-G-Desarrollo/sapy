Public Class CatalogosBU
    Public Function consultaDiasNoLaborables(ByVal anio As Int32) As DataTable
        Dim dtDiasNoLaborables As New DataTable
        Dim objDA As New Datos.CatalogosDA

        dtDiasNoLaborables = objDA.consultaDiasNoLaborablesDA(anio)
        Return dtDiasNoLaborables
    End Function
    Public Function insertarDiasNoLaborablesFecha(ByVal fechaAnterior As Date, ByVal fechaEditada As Date, ByVal descripcion As String) As String
        Dim objDA As New Datos.CatalogosDA
        Dim dtDiasNoLaborablesFecha As New DataTable
        Dim resultado As String = String.Empty

        dtDiasNoLaborablesFecha = objDA.insertarDiasNoLaborablesFechaDA(fechaAnterior, fechaEditada, descripcion)

        If Not dtDiasNoLaborablesFecha Is Nothing Then
            resultado = dtDiasNoLaborablesFecha.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function consultaContadordeTimbres() As DataTable
        Dim dtContadordeTimbres As New DataTable
        Dim objDA As New Datos.CatalogosDA

        dtContadordeTimbres = objDA.consultaContadordetimbresDA
        Return dtContadordeTimbres
    End Function
End Class
