Public Class DatosSPEMensualBU
    Public Function consultaListaMeses() As DataTable
        Dim objDa As New Datos.DatosSPEMensualDA
        Return objDa.consultaListaMeses()
    End Function

    Public Function consultarDatos(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer, ByVal nombre As String) As DataTable
        Dim objDa As New Datos.DatosSPEMensualDA
        Return objDa.consultarDatos(patronId, anio, mes, nombre)
    End Function

    Public Function importarDatos(ByVal lista As List(Of Entidades.DatosSPEMensual)) As String
        Dim objDa As New Datos.DatosSPEMensualDA
        Dim dtResultado As New DataTable
        Dim strResultado As String = String.Empty
        Dim exitosos As Integer = 0
        Dim total As Integer = 0

        For Each datos As Entidades.DatosSPEMensual In lista
            total += 1
            dtResultado = objDa.importarDatos(datos)

            If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item(0) = "EXITO" Then
                    exitosos += 1
                End If
            End If
        Next

        If exitosos = total Then
            strResultado = "EXITO"
        Else
            strResultado = "No se importaron correctamente todos los datos (" & exitosos.ToString & " exitosos de " & total.ToString & ")."
        End If

        Return strResultado
    End Function

    Public Function validarEstatusAutorizado(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim objDa As New Datos.DatosSPEMensualDA
        Dim dtResultado As New DataTable
        Dim blnAutorizado As Boolean = False

        dtResultado = objDa.validarEstatusAutorizado(patronId, anio, mes)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            If dtResultado.Rows(0).Item(0) > 0 Then
                blnAutorizado = True
            End If
        End If

        Return blnAutorizado
    End Function

    Public Function autorizarDatos(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer) As DataTable
        Dim objDa As New Datos.DatosSPEMensualDA
        Return objDa.autorizarDatos(patronId, anio, mes)
    End Function

    Public Function obtieneEncabezadoReporte(ByVal patronId As Integer) As String
        Dim objDa As New Datos.DatosSPEMensualDA
        Dim dtResultado As New DataTable
        Dim strEncabezado As String = String.Empty

        dtResultado = objDa.obtieneEncabezadoReporte(patronId)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            strEncabezado = dtResultado.Rows(0).Item(0)
        End If

        Return strEncabezado
    End Function

End Class
