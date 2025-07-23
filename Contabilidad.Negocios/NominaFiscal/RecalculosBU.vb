Public Class RecalculosBU
    Public Function obtenerAniosPatron(ByVal patronId As Int32) As DataTable
        Dim objDA As New Datos.RecalculosDA
        Dim dtlista As New DataTable

        dtlista = objDA.obtenerAniosPatron(patronId)
        If Not dtlista Is Nothing Then
            If dtlista.Rows.Count > 1 Then
                Dim dtRow As DataRow = dtlista.NewRow
                dtRow("Anios") = ""
                dtlista.Rows.InsertAt(dtRow, 0)
            End If
        End If

        Return dtlista
    End Function

    Public Function consultarRecalculosDescuentos(ByVal patronId As Int32, ByVal anio As Integer, ByVal tipo As Int16) As DataTable
        Dim objDA As New Datos.RecalculosDA
        Return objDA.consultarRecalculosDescuentos(patronId, anio, tipo)
    End Function

    Public Function recalcularDescuentos(ByVal patronId As Int32) As String
        Dim objDA As New Datos.RecalculosDA
        Dim dtResult As New DataTable
        Dim mensaje As String = String.Empty

        dtResult = objDA.recalcularDescuentos(patronId)

        If Not dtResult Is Nothing Then
            mensaje = dtResult.Rows(0).Item("mensaje")
        Else
            mensaje = "ERROR"
        End If

        Return mensaje
    End Function

    Public Function validaExisteRecalculo(ByVal patronId As Int32, ByVal anio As Integer) As Boolean
        Dim objDA As New Datos.RecalculosDA
        Dim dtResult As New DataTable
        Dim existe As Boolean = False

        dtResult = objDA.consultarRecalculosDescuentos(patronId, anio, 0)
        If Not dtResult Is Nothing AndAlso dtResult.Rows.Count > 0 Then
            existe = True
        End If

        Return existe

    End Function

    Public Function datosEmpresa(ByVal patronid As Int32) As DataTable
        Dim dtEmpresa As New DataTable
        Dim objDa As New Datos.RecalculosDA

        dtEmpresa = objDa.datosEmpresa(patronid)

        Return dtEmpresa
    End Function

    Public Function autorizarRealculo(ByVal patronid As Integer, ByVal anio As Int32) As String
        Dim objDA As New Datos.RecalculosDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.autorizarRealculo(patronid, anio)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If
        Return resultado
    End Function

    Public Function validaAutorizado(ByVal patronid As Integer, ByVal anio As Int32) As Boolean
        Dim objDA As New Datos.RecalculosDA
        Dim dtResultado As New DataTable
        Dim resultado As Boolean = False

        dtResultado = objDA.validaAutorizado(patronid, anio)
        If Not dtResultado Is Nothing Then
            If dtResultado.Rows(0)("autorizado") > 0 Then
                resultado = True
            End If
        End If
        Return resultado
    End Function

    Public Function obtieneDestinosCorreo(ByVal patronid As Integer) As String
        Dim objDA As New Datos.RecalculosDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDA.obtieneDestinosCorreo(patronid)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("destinos").ToString
        End If
        Return resultado
    End Function
End Class
