Public Class LineasBU

    Public Function verListaLineas(ByVal activo As Boolean) As DataTable
        Dim objLineaDA As New Datos.LineasDA
        Return objLineaDA.verListaLineas(activo)
    End Function

    Public Function verIdMaxLineas() As DataTable
        Dim objLineaDA As New Datos.LineasDA
        Return objLineaDA.verIdMaxLineas()
    End Function

    Public Sub registrarEditaLinea(ByVal entLineas As Entidades.Lineas, ByVal altaLinea As Boolean)
        Dim objLineaDA As New Datos.LineasDA
        objLineaDA.registrarEditaLinea(entLineas, altaLinea)
    End Sub

    Public Function validarInactivarLinea(ByVal idLinea As Int32) As DataTable
        Dim objLineaDA As New Datos.LineasDA
        Return objLineaDA.validarInactivarLinea(idLinea)
    End Function

    Public Function verRegistroLineaRapido(ByVal idsLineas As String) As DataTable
        Dim objLineaDA As New Datos.LineasDA
        Return objLineaDA.verRegistroLineaRapido(idsLineas)
    End Function

    Public Function verComboLineas() As DataTable
        Dim objLineaDA As New Datos.LineasDA
        Return objLineaDA.verComboLineas()
    End Function
End Class
