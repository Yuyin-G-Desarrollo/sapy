Public Class BajaCambioNaveBU
    Public Function obtenerListaColaboradores(ByVal naveId As Integer, ByVal patronId As Integer, ByVal asegurado As Boolean, ByVal nombre As String) As DataTable
        Dim objDatos As New Datos.BajaCambioNaveDA
        Return objDatos.obtenerListaColaboradores(naveId, patronId, asegurado, nombre)
    End Function

    Public Function obtenerNavesDestino(ByVal naveId As Integer) As DataTable
        Dim objDatos As New Datos.BajaCambioNaveDA
        Dim dtListado As New DataTable
        dtListado = objDatos.obtenerNavesDestino(naveId)
        If Not dtListado Is Nothing Then
            If dtListado.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtListado.NewRow
                dtRow("naveDestinoId") = 0
                dtRow("nave_nombre") = ""
                dtRow("nave_navesicyid") = 0
                dtListado.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtListado
    End Function

    Public Function obtenerFechaCorteNave(ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer, ByVal colaboradorId As Integer, ByVal patronDestinoId As Integer) As DataTable
        Dim objDatos As New Datos.BajaCambioNaveDA
        Return objDatos.obtenerFechaCorteNave(naveOrigenId, naveDestinoId, colaboradorId, patronDestinoId)
    End Function

    Public Function copiarColaborador(ByVal colaboradorId As Integer, ByVal patronOrigenId As Integer, ByVal patronDestinoId As Integer,
                                      ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer) As String
        Dim objDatos As New Datos.BajaCambioNaveDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.copiarColaborador(colaboradorId, patronOrigenId, patronDestinoId, naveOrigenId, naveDestinoId)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function
End Class
