Imports Libreria_CFDI_33.Negocios
Imports ToolServicios
Public Class NotasDeCreditoForm
    Private Sub bntTimbrar_Click(sender As Object, e As EventArgs) Handles bntTimbrar.Click

        Dim objNegocios As New GenerarFacturaElectronicaBU
        objNegocios.Folio(78236)
        Dim aviso As String = objNegocios.Aviso
        Dim respuesta As Int16 = objNegocios.Respuesta
        If respuesta = 1 Then
            aviso = ""
            respuesta = 0
            objNegocios.CopiarDocumento()
            aviso = objNegocios.Aviso
            respuesta = objNegocios.Respuesta
            If respuesta = 1 Then
                Process.Start(objNegocios.RutaCliente)
            Else
                MsgBox(aviso)
            End If
        Else
            MsgBox(aviso)
        End If

        ''Consumo para libreria de facturacion(Omar A.) directa si ir al rest
        'Dim objNotaCredito As New Facturacion.Negocios.NotaCreditoBU(19, 2, "XML")
        'Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Dim respuestaresult As RespuestaRestArray = objNotaCredito.Timbrado(59747, 22, "NOTACREDITO", 1)
        'Dim aviso As String = respuestaresult.aviso
        'Dim respuesta As Int16 = respuestaresult.respuesta

        'If respuesta = 1 Then
        '    aviso = ""
        '    respuesta = 0

        '    Dim rutaRest = respuestaresult.mensaje(0).ToString
        '    Dim rutaServidor = respuestaresult.mensaje(1).ToString
        '    Dim rutaCliente = respuestaresult.mensaje(2).ToString

        '    respuestaresult = objUtilerias.CopiarArchivoSICY(rutaRest, rutaServidor, rutaCliente)

        'Else
        '    MsgBox(aviso)
        'End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objNegocios As New GenerarFacturaElectronicaBU
        objNegocios.GenerarPdf(64697)
        Dim aviso As String = objNegocios.Aviso
        Dim respuesta As Int16 = objNegocios.Respuesta
        aviso = objNegocios.Aviso
        respuesta = objNegocios.Respuesta
        If respuesta = 1 Then
            aviso = ""
            respuesta = 0
            objNegocios.CopiarDocumento()
            aviso = objNegocios.Aviso
            respuesta = objNegocios.Respuesta
            If respuesta = 1 Then
                Process.Start(objNegocios.RutaCliente)
            Else
                MsgBox(aviso)
            End If
        Else
            MsgBox(aviso)
        End If



        ''Consumo para libreria de facturacion(Omar A.) directa si ir al rest    
        'Dim objNotaCredito As New Facturacion.Negocios.NotaCreditoBU
        'Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturas
        'Dim respuestaresult As RespuestaRestArray = objNotaCredito.GenerarPDF(59597)
        'Dim aviso As String = respuestaresult.aviso
        'Dim respuesta As Int16 = respuestaresult.respuesta
        'Dim rutaPDF As String = respuestaresult.mensaje(0).ToString
        'Dim rutaServidor As String = respuestaresult.mensaje(1).ToString
        'If respuesta = 1 Then
        '    MsgBox(objUtilerias.CopiarArchivoSICY(rutaPDF, rutaServidor))
        'Else
        '    MsgBox(aviso)
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim objNegocios As New GenerarFacturaElectronicaBU
        'objNegocios.prueba()
        'Dim aviso As String = objNegocios.Aviso
        'Dim respuesta As Int16 = objNegocios.Respuesta
        'aviso = objNegocios.Aviso
        'respuesta = objNegocios.Respuesta
        'If respuesta = 1 Then
        '    MsgBox(aviso)
        'Else
        '    MsgBox(aviso)
        'End If

        'Process.Start("\\192.168.2.2\bin\TASFE\EmpresaPruebas\NotasDeCredito33\PDF102017\MCV0902263W7F1NCR2090.pdf")

        Dim Parametro1 As String
        Dim Parametro2 As String
        Dim Proceso As Integer
        Try
            Parametro1 = "Ruta1"
            Parametro2 = "Ruta2"

            Proceso = Shell("C:\CopiarArchivoApp\CopiarArchivo.exe " & Parametro1 & " " & Parametro2, AppWinStyle.MinimizedFocus, True, -1)

            MsgBox("Ejecutado")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim objNegocios As New GenerarFacturaElectronicaBU
        Dim UUID As String = ""
        'UUID = objNegocios.ObtenerUUIDNOtaDeCredito(59803)
        UUID = objNegocios.ObtenerUUIDNOtaDeCredito(txtNotaCredito.Text)

        'objNegocios.folio_cancelacion(59803)
        objNegocios.folio_cancelacion(txtNotaCredito.Text)
        Dim aviso As String = objNegocios.Aviso
        Dim respuesta As Int16 = objNegocios.Respuesta
        If respuesta = 1 Then
            aviso = ""
            respuesta = 0
            objNegocios.CopiarDocumento()
            aviso = objNegocios.Aviso
            respuesta = objNegocios.Respuesta
            If respuesta = 1 Then
                ' Process.Start(objNegocios.RutaCliente)
                'Codigo exito llena varables con las propiedades de las rutas,UUID,Fechade cancelacion
                'strFolioCancelacion = objNegocios.UUID
                'datFechaCancelacion = objNegocios.FechaCancelacion
                'strRutaXML = objNegocios.strPathArchivoXML
                'strRutaPDF = objNegocios.strPathArchivoPDF
                MessageBox.Show("Cancelado")
            Else
                MsgBox(aviso)
            End If
        Else
            MsgBox(aviso)
        End If

        lblIdNotaCencalada.Text = txtNotaCredito.Text


        ''Consumo para libreria de facturacion(Omar A.) directa si ir al rest    
        'Dim objNotaCredito As New Facturacion.Negocios.NotaCreditoBU
        'Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        'Dim respuestaresult As RespuestaRestArray = objNotaCredito.TimbradoCancelacion(59752, "8a3425fd-7ac5-4930-b197-f1d31b3f5462", 19, "NOTACREDITO", True, 236)
        'Dim aviso As String = respuestaresult.aviso
        'Dim respuesta As Int16 = respuestaresult.respuesta
        'Dim rutaPDF As String = respuestaresult.mensaje(0).ToString
        'Dim rutaServidor As String = respuestaresult.mensaje(1).ToString
        'Dim rutaCliente As String = respuestaresult.mensaje(1).ToString
        'If respuesta = 1 Then
        '    MsgBox(aviso)
        'Else
        '    MsgBox(aviso)
        'End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim objNegocios As New GenerarFacturaElectronicaBU
        'objNegocios.GenerarPdfCancelacion(64205)
        objNegocios.GenerarPdfCancelacion(txtNotaCredito.Text)
        Dim aviso As String = objNegocios.Aviso
        Dim respuesta As Int16 = objNegocios.Respuesta
        aviso = objNegocios.Aviso
        respuesta = objNegocios.Respuesta
        If respuesta = 1 Then
            aviso = ""
            respuesta = 0
            objNegocios.CopiarDocumento()
            aviso = objNegocios.Aviso
            respuesta = objNegocios.Respuesta
            If respuesta = 1 Then
                Process.Start(objNegocios.RutaPDFServidor)
            Else
                MsgBox(aviso)
            End If
        Else
            MsgBox(aviso)
        End If

        txtNotaCredito.Text = ""


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim objNegocios As New GenerarFacturaElectronicaBU
        Dim UUID As String = ""
        UUID = objNegocios.ObtenerUUIDNOtaDeCredito(59178)
    End Sub

    Private Sub NotasDeCreditoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkConsulta_CheckedChanged(sender As Object, e As EventArgs) Handles chkConsulta.CheckedChanged
        If chkConsulta.Checked Then
            Me.Size = New Size(788, 321)
        Else
            Me.Size = New Size(400, 321)
        End If
    End Sub
End Class