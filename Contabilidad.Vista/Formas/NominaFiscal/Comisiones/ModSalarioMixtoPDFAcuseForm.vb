Imports System.Windows.Forms
Imports System.Net
Public Class ModSalarioMixtoPDFAcuseForm
    Public solicitudId As Integer = 0
    Public colaboradorId As Integer = 0
    Public guardado As Boolean = False
    Dim directorio As String = String.Empty

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PDF|*.pdf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivo.Text = ofdRutaArchivo.FileName
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim tipoCorreo As String = String.Empty
        Dim motivoRechazo As String = String.Empty
        Dim imssSemanal As Double = 0

        Try
            If validarArchivo() Then

                If rdbAceptado.Checked Then
                    objMensajeConf.mensaje = "Esta acción actualizará el salario del colaborador y reemplazará el archivo de rechazo si es que existe ¿Está seguro de continuar?"""
                Else
                    objMensajeConf.mensaje = "Esta acción modificará la fecha del movimiento y el registro seguirá pendiente de cargar al IDSE ¿Está seguro de continuar?"
                    Dim formMotivo As New MotivoRechazoForm
                    If Not CheckForm(formMotivo) Then
                        formMotivo.ShowDialog()

                        If formMotivo.motivo <> "" Then
                            motivoRechazo = formMotivo.motivo
                        Else
                            objMensajeAdv.mensaje = "Debe Ingresar el motivo de rechazo."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If
                End If

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If subirArchivo(txtArchivo.Text) Then
                        Dim objBU As New Negocios.ModSalarioMixtoBU
                        Dim resultado As String = String.Empty
                        Dim dtResultado As New DataTable

                        If rdbAceptado.Checked Then
                            dtResultado = objBU.aplicarSolicitud(solicitudId, directorio, IO.Path.GetFileName(txtArchivo.Text))
                            If Not dtResultado Is Nothing Then
                                If dtResultado.Rows.Count > 0 Then
                                    resultado = dtResultado.Rows(0)("mensaje").ToString
                                    imssSemanal = CDbl(dtResultado.Rows(0)("imssSemanal").ToString)
                                End If
                            End If
                            tipoCorreo = "Aceptado"
                        Else
                            Try
                                resultado = objBU.rechazarIdseSolicitud(solicitudId, directorio, IO.Path.GetFileName(txtArchivo.Text), motivoRechazo)
                                tipoCorreo = "Rechazado"

                            Catch ex As Exception
                                resultado = "ERROR"
                            End Try
                        End If

                        If resultado = "EXITO" Then
                            Dim modSalario As New Entidades.ModificacionSalarioMixto
                            modSalario = objBU.consultarSolicitudModificacionSalario(solicitudId)
                            enviar_correo(modSalario, tipoCorreo)
                            objMensajeExito.mensaje = "El archivo se ha cargado con correctamente"
                            objMensajeExito.ShowDialog()
                            guardado = True
                            Me.Close()
                        Else
                            objMensajeError.mensaje = "Error al actualizar información del colaborador."
                            objMensajeError.ShowDialog()
                        End If
                    Else
                        objMensajeError.mensaje = "Error subir el archivo de acuse."
                        objMensajeError.ShowDialog()
                    End If
                End If
            End If

        Catch ex As Exception
            objMensajeError.mensaje = "Error al guardar acuse."
            objMensajeError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    'Private Function obtenerCreditoInfonavit(ByVal solicitudId As Integer) As Entidades.CreditoInfonavit
    '    Dim credinfonavit As New Entidades.CreditoInfonavit

    '    Try
    '        Dim objBu As New Negocios.ModSalarioMixtoBU
    '        Dim modSalario As New Entidades.ModificacionSalarioMixto

    '        modSalario = objBu.consultarSolicitudModificacionSalario(solicitudId)
    '        If Not modSalario Is Nothing Then
    '            If modSalario.MDNumCreditoInfonavit <> "" Then
    '                Dim objCalcInfonavit As New CalculoInfonavit
    '                Dim fechaMovimiento As String = objBu.obtenerFechaMovimiento(modSalario.MDPatronId)

    '                If fechaMovimiento <> "" Then
    '                    credinfonavit = objCalcInfonavit.calcularDescuentoPorcentaje(modSalario.MDSalarioNuevo, modSalario.MDvalorDescuentoInfonavit, modSalario.MDPatronId, fechaMovimiento)
    '                Else
    '                    Return Nothing
    '                End If
    '            Else
    '                credinfonavit.CIRetenciondiaria = 0
    '                credinfonavit.CIDescuentosemanal = 0
    '            End If
    '        Else
    '            Return Nothing
    '        End If

    '        Return credinfonavit
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function

    Private Function validarArchivo() As Boolean
        Dim extension As String = ""
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If txtArchivo.Text <> "" Then
            extension = System.IO.Path.GetExtension(txtArchivo.Text)
            If extension.ToUpper <> ".PDF" Then
                objMensajeAdv.mensaje = "El archivo seleccionado no es un PDF."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If
        Return True
    End Function

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function subirArchivo(ByVal ruta As String) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & colaboradorId

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorio, ruta)
                rutaArchivo = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(ruta)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Private Sub enviar_correo(ByVal modSalario As Entidades.ModificacionSalarioMixto, ByVal tipoCorreo As String)
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim objBU As New Negocios.ModSalarioMixtoBU
        Dim dtDatosCorreo As New DataTable
        Dim destinatarios As String = String.Empty
        Dim correoEnvia As String = String.Empty
        Dim mensaje As String = String.Empty
        Dim asunto As String = String.Empty
        Dim correo As New Tools.Correo

        If tipoCorreo = "Aceptado" Then
            mensaje = cuerpoCorreoAceptado(modSalario)
            asunto = "Confirmación de Modificación de Salario IMSS de " & modSalario.PNombreColaborador
        ElseIf tipoCorreo = "Rechazado" Then
            mensaje = cuerpoCorreoRechazado(modSalario)
            asunto = "Rechazo IDSE de Modificación de Salario IMSS de " & modSalario.PNombreColaborador
        End If

        dtDatosCorreo = objBU.consultaDatosCorreo(modSalario.MDID)
        If Not dtDatosCorreo Is Nothing Then
            If dtDatosCorreo.Rows(0)("destinatarios").ToString <> "" Then
                destinatarios = dtDatosCorreo.Rows(0)("destinatarios").ToString
                correoEnvia = dtDatosCorreo.Rows(0)("correoEnvia").ToString

                correo.EnviarCorreoHtml(destinatarios, correoEnvia, asunto, mensaje)
            End If
        End If

    End Sub

    Private Function cuerpoCorreoAceptado(ByVal modSalario As Entidades.ModificacionSalarioMixto) As String
        Dim mensaje As String = String.Empty
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        mensaje = "<html>"
        mensaje &= "<head>"
        mensaje &= "<style type ='text/css'>" &
                "body {display:block; margin:8px; background:#FFFFFF;}" &
                "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                "A:link {text-decoration:none; color:#FFFFFF;}" &
                "A:visited {text-decoration:none; color:#FFFFFF;}" &
                "A:active {text-decoration:none; color:#FFFFFF;}" &
                "A:hover {text-decoration:none;color:#006699;} "
        mensaje &= "</style>"
        mensaje &= "</head>"
        mensaje &= "<body>"
        mensaje &= "<div id='wrapper'>" &
                "<div id='header'>" &
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Modificación de Salario" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>" &
                "<p>Se ha confirmado la modificación de salario del colaborador. Se aplicarán los siguientes descuentos a partir de la siguiente elaboración de nómina:</p>"
        mensaje &= "<table id='tblInformacion' class='tableizer-table'>" &
                "<thead>" &
                "<tr class='tableizer-firstrow'>" &
                "<th>NSS</th>" &
                "<th>NOMBRE</th>" &
                "<th>FECHA<br />MOVIMIENTO</th>" &
                "<th>DESCUENTO<br />IMSS</th>" &
                "</tr>" &
                "</thead>"
        mensaje &= "<tbody>" &
                "<tr>" &
                "<td>" & modSalario.PNumSS & "</td>" &
                "<td>" & modSalario.PNombreColaborador & "</td>" &
                "<td>" & modSalario.PFechaMovimiento & "</td>" &
                "<td style='text-align:right;'>" & Math.Round(modSalario.PIMSSSemanal).ToString("C2") & "</td>" &
                "</tr>"
        mensaje &= "</tbody>"
        mensaje &= "</table>"
        mensaje &= "<p>Para descargar el acuse de modificación de salario vaya a la ficha del colaborador, en su expediente encontrará disponible el archivo correspondiente.</p>"
        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje
    End Function

    Private Function cuerpoCorreoRechazado(ByVal modSalario As Entidades.ModificacionSalarioMixto) As String
        Dim mensaje As String = String.Empty

        mensaje = "<html>"
        mensaje &= "<head>"
        mensaje &= "<style type ='text/css'>" &
                "body {display:block; margin:8px; background:#FFFFFF;}" &
                "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                "A:link {text-decoration:none; color:#FFFFFF;}" &
                "A:visited {text-decoration:none; color:#FFFFFF;}" &
                "A:active {text-decoration:none; color:#FFFFFF;}" &
                "A:hover {text-decoration:none;color:#006699;} "
        mensaje &= "</style>"
        mensaje &= "</head>"
        mensaje &= "<body>"
        mensaje &= "<div id='wrapper'>" &
                "<div id='header'>" &
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Modificación de Salario" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>" &
                "<p>La modificación de salario IMSS de " & modSalario.PNombreColaborador & " fue rechazado en IDSE. Al inicio del próximo periodo de nómina se intentará nuevamente la carga por lo que en este periodo no se verá reflejada esta modificación. Para descargar el acuse de rechazo vaya a la ficha del colaborador, en su expediente encontrará disponible el archivo correspondiente, el cual será remplazado con el correspondiente acuse de confirmación cuando la carga sea exitosa.</p>"
        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje
    End Function
End Class