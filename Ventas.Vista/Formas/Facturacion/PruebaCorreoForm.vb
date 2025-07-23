Public Class PruebaCorreoForm

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtContenido.TextChanged

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New Negocios.VistaPreviaDocumentosBU
        Dim dtDatosDocumento As New DataTable()
        Dim folioFactura As String = String.Empty
        Dim nombreCliente As String = String.Empty
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Dim correoCliente As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim objTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim StatusCorreo As Boolean = False


        Try
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")

            rutaArchivoPDF = txtArchivo.Text.Trim
            correoCliente = txtto.Text.Trim
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = txtto.Text.Trim

           
            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If

          
           

            asuntoCorreo = "Prueba de envio de correo FACTURA "
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en facturación, ya sea por Razón Social, Domicilio Fiscal, Forma de Pago, Importe máximo de facturación etc. se realizará UNICAMENTE dentro de los primeros 7 días posteriores a la expedición de la factura; pasando este lapso de días no se harán cambios. </li>" +
                            "<li> En caso de errores en el domicilio fiscal solo verá reflejados los cambios en el archivo PDF, ya que de acuerdo a disposición del SAT en el archivo XML estos campos ya no existen. </li>" +
                            "<li> No se podrá hacer cancelaciones de facturas que ya hayan sido pagadas. </li>" +
                            "<li> No procederá la cancelación de un CFDI que se haya facturado conforme a los datos proporcionados por usted al momento de hacer su pedido. </li>" +
                            "<li> De acuerdo a lo establecido en la guía del llenado de los comprobantes fiscales del ""Anexo 20 SAT"" cuando la clave de uso registrada en el CFDI es incorrecta no será motivo de cancelación ni afectará para deducción o acreditamiento. Sin embargo, se recomienda que en el momento que se percaten del error soliciten su corrección para la siguiente facturación.</li>" +
                            "<li> No procederá hacer cancelaciones de cambios en la Clave del producto ya que está es asignada por la empresa que emite el CFDI, por lo tanto es nuestra responsabilidad que este indicada correctamente.</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntosPruebas(destinatarios, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

           

        Catch ex As Exception
            StatusCorreo = False
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim objBU As New Negocios.VistaPreviaDocumentosBU
        Dim dtDatosDocumento As New DataTable()
        Dim folioFactura As String = String.Empty
        Dim nombreCliente As String = String.Empty
        Dim rutaArchivoPDF As String = String.Empty
        Dim rutaArchivoXML As String = String.Empty
        Dim correoCliente As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim CorreoEnviado As String = String.Empty
        Dim objTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim StatusCorreo As Boolean = False


        Try
            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")

            rutaArchivoPDF = txtArchivo.Text.Trim
            correoCliente = txtto.Text.Trim
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = txtto.Text.Trim


            If rutaArchivoPDF <> String.Empty Then
                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoPDF)
                lstArchivoAdjuntos.Add(archivoAdjunto)
            End If




            asuntoCorreo = "Prueba de envio de correo FACTURA "
            cadenaCorreo = "<html> " +
                           " <head>" +
                           " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <br><p>Estimado Cliente: Anexo encontrará su CFDI en formato PDF y XML.</p>"
            cadenaCorreo += " <p> Le sugerimos tomar en cuenta las siguientes consideraciones en cuanto a cancelaciones:<br>"
            cadenaCorreo += " <ol>" +
                            "<li> Cualquier cambio en facturación, ya sea por Razón Social, Domicilio Fiscal, Forma de Pago, Importe máximo de facturación etc. se realizará UNICAMENTE dentro de los primeros 7 días posteriores a la expedición de la factura; pasando este lapso de días no se harán cambios. </li>" +
                            "<li> En caso de errores en el domicilio fiscal solo verá reflejados los cambios en el archivo PDF, ya que de acuerdo a disposición del SAT en el archivo XML estos campos ya no existen. </li>" +
                            "<li> No se podrá hacer cancelaciones de facturas que ya hayan sido pagadas. </li>" +
                            "<li> No procederá la cancelación de un CFDI que se haya facturado conforme a los datos proporcionados por usted al momento de hacer su pedido. </li>" +
                            "<li> De acuerdo a lo establecido en la guía del llenado de los comprobantes fiscales del ""Anexo 20 SAT"" cuando la clave de uso registrada en el CFDI es incorrecta no será motivo de cancelación ni afectará para deducción o acreditamiento. Sin embargo, se recomienda que en el momento que se percaten del error soliciten su corrección para la siguiente facturación.</li>" +
                            "<li> No procederá hacer cancelaciones de cambios en la Clave del producto ya que está es asignada por la empresa que emite el CFDI, por lo tanto es nuestra responsabilidad que este indicada correctamente.</li>" +
                            "</ol>" +
                            "</p>"
            cadenaCorreo += " <p> Atentamente: Grupo Yuyin </p>"
            cadenaCorreo += " </body> " +
                            " </html> "

            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntosPruebas25(destinatarios, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)



        Catch ex As Exception
            StatusCorreo = False
        End Try
    End Sub
End Class