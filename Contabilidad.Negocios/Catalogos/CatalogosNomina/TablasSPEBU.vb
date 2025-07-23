Public Class TablasSPEBU

    Public Function consultarTablaSPE(ByVal tipo As String, ByVal activo As Boolean) As DataTable
        Dim objDA As New Datos.TablasSPEDA
        Return objDA.consultarTablasSPE(tipo, activo)

    End Function

    Public Function existeRango(ByVal objSPE As Entidades.TablasSPE) As Boolean
        Dim objDa As New Datos.TablasSPEDA
        Dim dtResult As New DataTable
        Dim blnExiste As Boolean = False

        dtResult = objDa.existeRango(objSPE)
        If Not IsNothing(dtResult) AndAlso dtResult.Rows.Count > 0 Then
            blnExiste = True
        End If

        Return blnExiste
    End Function

    Public Function guardarTablaSPE(ByVal objSPE As Entidades.TablasSPE) As String
        Dim objDA As New Datos.TablasSPEDA
        Dim dtResultado As DataTable
        Dim strResultado As String = String.Empty

        dtResultado = objDA.guardarTablaSPE(objSPE)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            strResultado = dtResultado.Rows(0).Item(0).ToString
        End If

        Return strResultado

    End Function

    Public Function consultaDatosSubsidio(ByVal idSubsidio As Integer) As DataTable
        Dim objDA As New Datos.TablasSPEDA
        Return objDA.consultaDatosSubsidio(idSubsidio)
    End Function

    Public Function desactivarSubsidio(ByVal idSubsidio As Integer) As String
        Dim objDA As New Datos.TablasSPEDA
        Dim dtResultado As DataTable
        Dim strResultado As String = String.Empty

        dtResultado = objDA.desactivarSubsidio(idSubsidio)
        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            strResultado = dtResultado.Rows(0).Item(0).ToString
        End If

        Return strResultado
    End Function

End Class
