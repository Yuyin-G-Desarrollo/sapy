Imports Libreria_CFDI_33.Negocios
Imports ToolServicios
Public Class ComplementoPagoForm

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click

        'Dim objNegocios As New GenerarFacturaElectronicaBU
        'objNegocios.FolioComplementoPago(2)
        'Dim aviso As String = objNegocios.Aviso
        'Dim respuesta As Int16 = objNegocios.Respuesta
        'If respuesta = 1 Then
        '    aviso = ""
        '    respuesta = 0
        '    objNegocios.CopiarDocumento()
        '    aviso = objNegocios.Aviso
        '    respuesta = objNegocios.Respuesta
        '    If respuesta = 1 Then
        '        Process.Start(objNegocios.RutaCliente)
        '    Else
        '        MsgBox(aviso)
        '    End If
        'Else
        '    MsgBox(aviso)
        'End If


        'Consumo para libreria de facturacion(Omar A.) directa si ir al rest
        Dim objBU As New Facturacion.Negocios.ComplementoPagoBU(19, 4, "XML")
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim respuestaresult As RespuestaRestArray = objBU.Timbrado(445, 19, "COMPLEMENTOPAGO", True)
        Dim aviso As String = respuestaresult.aviso
        Dim respuesta As Int16 = respuestaresult.respuesta
        If respuesta = 1 Then
            aviso = ""
            respuesta = 0
            Dim rutaRest = respuestaresult.mensaje(0).ToString
            Dim rutaServidor = respuestaresult.mensaje(1).ToString
            Dim rutaCliente = respuestaresult.mensaje(2).ToString
            respuestaresult = objUtilerias.CopiarArchivoSICY(rutaRest, rutaServidor, rutaCliente, True)
        Else
            MsgBox(aviso)
        End If
    End Sub

    Private Sub btnGenerarPdf_Click(sender As Object, e As EventArgs) Handles btnGenerarPdf.Click
        'Consumo para libreria de facturacion(Omar A.) directa si ir al rest    
        Dim objBU As New Facturacion.Negocios.ComplementoPagoBU
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim respuestaresult As RespuestaRestArray = objBU.GenerarPDF(445)
        Dim aviso As String = respuestaresult.aviso
        Dim respuesta As Int16 = respuestaresult.respuesta
        Dim rutaPDF As String = respuestaresult.mensaje(0).ToString
        Dim rutaServidor As String = respuestaresult.mensaje(1).ToString
        If respuesta = 1 Then

            'MsgBox(objUtilerias.CopiarArchivoSICY(rutaPDF, rutaServidor))
        Else
            MsgBox(aviso)
        End If
    End Sub

    Private Sub btnnTimbrarCancelacion_Click(sender As Object, e As EventArgs) Handles btnnTimbrarCancelacion.Click
        'Consumo para libreria de facturacion(Omar A.) directa si ir al rest    
        Dim objBU As New Facturacion.Negocios.ComplementoPagoBU
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim respuestaresult As RespuestaRestArray = objBU.TimbradoCancelacion(4, "54b6535e-3ec2-4704-9330-4f621870306b", 19, "COMPLEMENTOPAGO", True, 236)
        Dim aviso As String = respuestaresult.aviso
        Dim respuesta As Int16 = respuestaresult.respuesta
        If respuesta = 1 Then
            aviso = ""
            respuesta = 0
            Dim rutaRest = respuestaresult.mensaje(0).ToString
            Dim rutaServidor = respuestaresult.mensaje(1).ToString
            Dim rutaCliente = respuestaresult.mensaje(2).ToString
            respuestaresult = objUtilerias.CopiarArchivoSICY(rutaRest, rutaServidor, rutaCliente, True)
        Else
            MsgBox(aviso)
        End If
    End Sub

    Private Sub btnCancelarPDF_Click(sender As Object, e As EventArgs) Handles btnCancelarPDF.Click

          'Consumo para libreria de facturacion(Omar A.) directa si ir al rest    
        Dim objBU As New Facturacion.Negocios.ComplementoPagoBU
        Dim objUtilerias As New Facturacion.Negocios.UtileriasFacturasBU
        Dim respuestaresult As RespuestaRestArray = objBU.GenerarPDFCancelacion(4)
        Dim aviso As String = respuestaresult.aviso
        Dim respuesta As Int16 = respuestaresult.respuesta
        Dim rutaPDF As String = respuestaresult.mensaje(0).ToString
        Dim rutaServidor As String = respuestaresult.mensaje(1).ToString
        If respuesta = 1 Then

            'MsgBox(objUtilerias.CopiarArchivoSICY(rutaPDF, rutaServidor))
        Else
            MsgBox(aviso)
        End If
    End Sub
End Class