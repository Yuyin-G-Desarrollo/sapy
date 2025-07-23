Public Class TablasTarifasBU
    Public Function consultaTarifas(ByVal tipo As String, ByVal activo As Boolean) As DataTable
        Dim objDa As New Datos.TablasTarifasDA
        Return objDa.consultaTarifas(tipo, activo)
    End Function

    Public Function guardarTarifas(ByVal objTarifa As Entidades.TablasTarifas) As String
        Dim objDa As New Datos.TablasTarifasDA
        Dim dtResult As New DataTable
        Dim strmensaje As String = String.Empty

        dtResult = objDa.guardarTarifas(objTarifa)

        If Not IsNothing(dtResult) AndAlso dtResult.Rows.Count > 0 Then
            strmensaje = dtResult.Rows(0).Item(0)
        End If

        Return strmensaje
    End Function

    Public Function consultaDatosTarifa(ByVal idTarifa As Integer) As DataTable
        Dim objDa As New Datos.TablasTarifasDA
        Return objDa.consultaDatosTarifa(idTarifa)
    End Function

    Public Function desactivarTarifas(ByVal idTarifa As Integer) As String
        Dim objDa As New Datos.TablasTarifasDA
        Dim dtResult As New DataTable
        Dim strmensaje As String = String.Empty

        dtResult = objDa.desactivarTarifa(idTarifa)
        If Not IsNothing(dtResult) AndAlso dtResult.Rows.Count > 0 Then
            strmensaje = dtResult.Rows(0).Item(0)
        End If

        Return strmensaje
    End Function

    Public Function existeRango(ByVal objTarifa As Entidades.TablasTarifas) As Boolean
        Dim objDa As New Datos.TablasTarifasDA
        Dim dtResult As New DataTable
        Dim blnExiste As Boolean = False

        dtResult = objDa.existeRango(objTarifa)
        If Not IsNothing(dtResult) AndAlso dtResult.Rows.Count > 0 Then
            blnExiste = True
        End If

        Return blnExiste
    End Function

End Class
