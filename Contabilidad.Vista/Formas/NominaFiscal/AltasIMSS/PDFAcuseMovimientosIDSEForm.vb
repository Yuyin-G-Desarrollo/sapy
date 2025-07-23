Imports Tools
Imports System.Net
Imports Stimulsoft.Report.Export
Imports Stimulsoft.Report

Public Class PDFAcuseMovimientosIDSEForm

    Public movimiento As String = String.Empty
    Dim directorio As String = String.Empty
    Public solicitudId As Integer = 0
    Public colaboradorId As Integer = 0
    Public guardado As Boolean = False
    Dim idInfonavit As Int32 = 0
    Dim sPDF As String = String.Empty
    Dim directorioInfonavit As String = String.Empty

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PDF|*.pdf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivo.Text = ofdRutaArchivo.FileName
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        AplicarMovimiento()
    End Sub

    Public Sub AplicarMovimiento()
        Dim advetencia As New AdvertenciaForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim resul As String = String.Empty
        Dim exito As New ExitoForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim motivo As String = String.Empty

        If validarArchivo() Then
            If movimiento = "Aceptar" Then
                objMensajeConf.mensaje = "Esta acción actualizara el alta a ""ACEPTADA"", ¿Está seguro de continuar?"
            Else
                objMensajeConf.mensaje = "Esta acción actualizara el alta a ""RECHAZADA"", ¿Está seguro de continuar?"
            End If

            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                If subirArchivo(txtArchivo.Text) Then
                    If movimiento = "Rechazar" Then
                        Dim formMotivo As New MotivoRechazoForm
                        formMotivo.ShowDialog()
                        motivo = formMotivo.motivo

                        If motivo.Trim = "" Then
                            Dim objMensajeAdv As New Tools.AdvertenciaForm
                            objMensajeAdv.mensaje = "No se RECHAZARON las solicitudes debido a que no se ingresó el motivo de regreso."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If

                    resul = objBu.aceptarRechazarIdseAltaImss(solicitudId, colaboradorId, directorio, IO.Path.GetFileName(txtArchivo.Text), movimiento, motivo)

                    If resul = "EXITO" Then
                        Dim credinfonavit As New Entidades.CreditoInfonavit

                        enviarCorreo()
                        notificarCambioPatron()

                        exito.mensaje = "El archivo se ha cargado con correctamente"
                        exito.ShowDialog()
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
    End Sub

    Private Sub notificarCambioPatron()
        If colaboradorId <> 0 Then
            Dim objBu As New Negocios.ColaboradoresContabilidadBU
            Dim dtDatos As New DataTable

            dtDatos = objBu.obtenerDatosCambioPatron(colaboradorId)
            If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0).Item("Envia").ToString.Trim <> "" And dtDatos.Rows(0).Item("Destinos").ToString.Trim <> "" Then
                    Dim correo As New Tools.Correo
                    Dim mensaje As String = String.Empty
                    Dim nombreColaborador As String = dtDatos.Rows(0).Item("Colaborador")
                    Dim patronOrigen As String = dtDatos.Rows(0).Item("PatronOrigen")
                    Dim patronDestino As String = dtDatos.Rows(0).Item("PatronDestino")
                    Dim destinatarios As String = dtDatos.Rows(0).Item("Destinos")
                    Dim correoEnvia As String = dtDatos.Rows(0).Item("Envia")
                    mensaje = cuerpoCorreoCambioPatron(nombreColaborador, patronOrigen, patronDestino)

                    correo.EnviarCorreoHtml(destinatarios, correoEnvia, "Notificación de cambio de razón social", mensaje)
                End If
            End If
        End If
    End Sub

    Private Function cuerpoCorreoCambioPatron(ByVal colaborador As String, ByVal patronOrigen As String, ByVal patronDestino As String) As String
        Dim CadenaCorreo As String = String.Empty
        Dim CadenaDiseño As String = String.Empty

        CadenaDiseño = <CadenaDiseño>                   
                            body {}

                                    .encabezado {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      background: #536EBE;
                                      color: white;
                                      text-align: center;
                                    }

                                    h2 {
                                      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
                                      font-weight: 200;
                                      line-height: 1.0;
                                      font-size: 1.5rem;
                                    }

                                    .cuerpo {
                                      margin-top: 25px;
                                      margin-left: 25px;
                                      margin-right: 250px;
                                      font-family: arial, sans-serif;
                                      color: black;
                                    }                                                             

                                    .centro {
                                      text-align: center;
                                    }

                                    .cuerpo-pie {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      margin-top: 25px;
                                      font-family: arial, sans-serif;
                                      background: #CDCDCD;
                                      color: black;
                                    }

                                    .cuerpo-pie label {
                                      margin-left: 25px;
                                      margin-bottom: 25px;
                                    }

                       </CadenaDiseño>.Value
        CadenaCorreo = " <html> " +
                            " <head> " +
                               " <meta charset ='utf-8'/> " +
                               " <style type='text/css'>" + CadenaDiseño + "</style> " +
                            " </head> " +
                            " <body> " +
                                " <div Class='encabezado'> " +
                                        " <h2> NOTIFICACIÓN DE CAMBIO DE RAZÓN SOCIAL </h2> " +
                                " </div> " +
                                " <div Class='cuerpo'> " +
                                    " <div> " +
                                        " <Label> Se ha realizado el cambio de razón social del colaborador de <b>" + colaborador + "</b> de " +
                                            patronOrigen + " a " + patronDestino + " " +
                                        " </label> " +
                                    " </div> " +
                                " </div> " +
                                " <div Class='cuerpo-pie'> " +
                                            " <Label> Favor de ingresar al sistema SAY y reimprimir su credencial.</label> " +
                                " </div> " +
                            " </body> " +
                        " </html> "

        Return CadenaCorreo
    End Function

    Public Sub enviarCorreo()
        Dim dtDestinatarios As New DataTable
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim destinatarios As String = String.Empty
        Dim correoEnvia As String = String.Empty
        Dim correo As New Tools.Correo
        Dim asunto As String = String.Empty
        Dim mensaje As String = String.Empty
        Dim altaImss As New Entidades.AltaColaboradorIMSS
        Dim dtAlta As New DataTable
        Dim cartaGenerada As Boolean = True
        Dim resultado As String = String.Empty

        dtDestinatarios = objBu.consultaDestinatariosAltaIMSS(solicitudId)
        objBu = New Negocios.ColaboradoresContabilidadBU
        dtAlta = objBu.consultaInformacionParaEditarImss(solicitudId)

        If dtAlta.Rows.Count > 0 Then
            altaImss.PNombre = dtAlta.Rows(0).Item("nombre")
            altaImss.PNSS = dtAlta.Rows(0).Item("nss")
            altaImss.PSDI = dtAlta.Rows(0).Item("sdi")
            altaImss.PSalarioBase = dtAlta.Rows(0).Item("salarioBase")
            altaImss.PColaboradorId = dtAlta.Rows(0).Item("idColaborador")
            altaImss.PFechaAlta = dtAlta.Rows(0).Item("fechaAlta")
            altaImss.PNombres = dtAlta.Rows(0).Item("nombresolo")
            altaImss.PAPaterno = dtAlta.Rows(0).Item("apaterno")
            altaImss.PAMaterno = dtAlta.Rows(0).Item("amaterno")
            altaImss.PMotivoRechazo = dtAlta.Rows(0).Item("motivoRechazo")
            altaImss.PCantidadDescontar = dtAlta.Rows(0).Item("descuentoSema")
            altaImss.PCreditoInfonavitId = dtAlta.Rows(0).Item("idInfonavit")
            idInfonavit = dtAlta.Rows(0).Item("idInfonavit")
        End If

        ''aplica INFONAVIT en caso de que cuente con el
        If idInfonavit <> 0 Then
            Dim credinfonavit As New Entidades.CreditoInfonavit
            Dim objBUIn As New Negocios.CreditoInfonavitBU
            credinfonavit = objBUIn.consultarMovimientoCreditoInfonavit(idInfonavit)
            If Not credinfonavit Is Nothing Then
                If generarCartaDescuento(credinfonavit) Then
                    resultado = objBUIn.aplicarMovimientoCreditoInfonavit(idInfonavit, directorioInfonavit, IO.Path.GetFileName(sPDF))

                    cartaGenerada = True
                Else
                    cartaGenerada = False
                End If
            End If
        End If


        If movimiento = "Aceptar" Then
            mensaje = cuerpoCorreoAceptado(altaImss)
            asunto = "Confirmación alta IMSS de " + altaImss.PNombre
        Else
            mensaje = cuerpoCorreoRechazado(altaImss)
            asunto = "Rechazo IDSE de alta IMSS de " + altaImss.PNombre
        End If

        If cartaGenerada = True Then
            If Not dtDestinatarios Is Nothing Then
                If dtDestinatarios.Rows.Count > 0 Then
                    destinatarios = dtDestinatarios.Rows(0)("destinatarios").ToString
                    correoEnvia = dtDestinatarios.Rows(0)("correoEnvia").ToString

                    correo.EnviarCorreoHtml(destinatarios, correoEnvia, asunto, mensaje)
                End If
            End If
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Algo surgió mal al generar la carta. Favor de realizarla desde creditos de infonavit"
            advertencia.ShowDialog()
        End If

    End Sub

    Public Function cuerpoCorreoAceptado(ByVal altaImss As Entidades.AltaColaboradorIMSS) As String
        Dim mensaje As String = String.Empty
        Dim retencionImss As New Entidades.RetencionImss
        Dim retencionISRSPE As New Entidades.RetencionISR_SPE
        Dim objCalcImss As New CalculoIMSS
        Dim objCalcISRSPE As New CalculoISR
        Dim valorISR As Double = 0
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim encabezadoISR As String = String.Empty
        Dim descuentoSem As Double = 0
        Dim descuentoDiario As Double = 0
        Dim spe As Boolean = False
        Try
            retencionImss = objCalcImss.calcularRetecionImssIntegrado(altaImss.PSDI, 7)
            If retencionImss Is Nothing Then
                objMensajeAdv.mensaje = objCalcImss.msjError
                objMensajeAdv.ShowDialog()
            End If
        Catch ex As Exception

        End Try

        Try
            retencionISRSPE = objCalcISRSPE.calcularISR_SPE(altaImss.PSalarioBase * 7, altaImss.PColaboradorId, True, True, 0)
            If retencionISRSPE Is Nothing Then
                objMensajeAdv.mensaje = objCalcImss.msjError
                objMensajeAdv.ShowDialog()
            Else
                If retencionISRSPE.RISSPEpagado > 0 Then
                    valorISR = retencionISRSPE.RISSPEpagado
                    encabezadoISR = "SPE<br />POR PAGAR"
                    spe = True
                ElseIf retencionISRSPE.RISISRretenido >= 0 Then
                    valorISR = retencionISRSPE.RISISRretenido
                    encabezadoISR = "DESCUENTO<br />ISR"
                End If

                Dim objBu As New Negocios.ColaboradoresContabilidadBU
                Dim dtDescuentos As New DataTable

                dtDescuentos = objBu.actualizarDescuentoISR(colaboradorId, valorISR, retencionImss.RIRetencionImss, retencionImss.RIRetencionDiaria, spe)
                If dtDescuentos.Rows.Count > 0 Then
                    descuentoSem = dtDescuentos.Rows(0).Item("imssSemanal")
                    descuentoDiario = dtDescuentos.Rows(0).Item("imssDiario")
                End If
            End If
        Catch ex As Exception

        End Try

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
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Alta IMSS" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>" &
                "<p>Se ha confirmado el alta IMSS del colaborador. Se aplicarán los siguientes descuentos a partir de la siguiente elaboración de nómina fiscal:</p>"
        mensaje &= "<table id='tblInformacion' class='tableizer-table'>" &
                "<thead>" &
                "<tr class='tableizer-firstrow'>" &
                "<th>NSS</th>" &
                "<th>A PATERNO</th>" &
                "<th>A MATERNO</th>" &
                "<th>NOMBRE</th>" &
                "<th>FECHA<br />MOVIMIENTO</th>" &
                "<th>DESCUENTO<br />IMSS</th>" &
                "<th>" & encabezadoISR & "</th>" &
                "<th>DESCUENTO<br />INFONAVIT</th>" &
                "</tr>" &
                "</thead>"
        mensaje &= "<tbody>" &
                "<tr>" &
                "<td>" & altaImss.PNSS & "</td>" &
                "<td>" & altaImss.PNombres & "</td>" &
                "<td>" & altaImss.PAPaterno & "</td>" &
                "<td>" & altaImss.PAMaterno & "</td>" &
                "<td>" & altaImss.PFechaAlta & "</td>" &
                "<td style='text-align:right;'>" & Math.Round(descuentoSem).ToString("C2") & "</td>" &
                "<td style='text-align:right;'>" & Math.Round(valorISR).ToString("C2") & "</td>" &
                "<td style='text-align:right;'>" & Math.Round(altaImss.PCantidadDescontar).ToString("C2") & "</td>" &
                "</tr>"
        mensaje &= "</tbody>"
        mensaje &= "</table>"
        If idInfonavit <> 0 Then
            mensaje &= "<p>Para descargar el acuse de alta de IMSS y la carta de descuento de INFONAVIT vaya a la ficha del colaborador, en su expediente encontrará disponible los archivos correspondiente.</p>"
        Else
            mensaje &= "<p>Para descargar el acuse de alta de IMSS vaya a la ficha del colaborador, en su expediente encontrará disponible el archivo correspondiente.</p>"
        End If

        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje
    End Function

    Private Function cuerpoCorreoRechazado(ByVal altaImss As Entidades.AltaColaboradorIMSS) As String
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
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Alta IMSS" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>" &
                "<p>El alta IMSS de " & altaImss.PNombre & " fue rechazado en IDSE. Favor de hacer la correcciones necesarias (" & altaImss.PMotivoRechazo & " ), para que se vuelva a intentar en el próximo periodo de nómina.</p>"
        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje

    End Function

    Public Function cuerpoCorreoRechazado() As String

    End Function
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Function generarCartaDescuento(ByVal credInfonavit As Entidades.CreditoInfonavit) As Boolean
        If credInfonavit.CIMovimientoinfonavitid <> 2 Then
            Try
                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim reporte As New StiReport
                Dim pdfSettings = New StiPdfExportSettings()
                EntidadReporte = objReporte.LeerReporteporClave("CARTA_DESC_INFONAVIT")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim descuentoMensual As String = String.Empty
                Dim descuentoBimestral As String = String.Empty


                sPDF = rutaTmp & "CARTA_DESC_INFONAVIT" & credInfonavit.CIColaboradorid & "_" & Date.Now.ToString("ddMMyyyHmm") & ".pdf"
                If Not existeCarpeta(rutaTmp) Then
                    crearCarpeta(rutaTmp)
                End If

                reporte.Load(archivo)
                reporte.Compile()

                Select Case credInfonavit.CITipoDescuentoStr
                    Case "PORCENTAJE"
                        descuentoMensual = credInfonavit.CISalarioBase.ToString("C2") & " (salario base) * " & diasBimestre & " (días del bimestre) = " & credInfonavit.CISalarioBimestral.ToString("C2") & " * " & credInfonavit.CIValordescuento.ToString("N4") & " porcentaje = " & credInfonavit.CIImporteretencionmensual.ToString("C2") & " (bimestral)"
                        descuentoBimestral = "Descuento bimestral de " & credInfonavit.CIImporteretenerbimestral.ToString("C2") & " + " & credInfonavit.CISeguroVivienda.ToString("C2") & " Seguro para vivienda = " & credInfonavit.CIImporteretenerbimestral.ToString("C2")
                    Case "CUOTA FIJA"
                        descuentoMensual = credInfonavit.CIValordescuento.ToString("C2") & " (mensual)"
                        descuentoBimestral = CDbl(credInfonavit.CIValordescuento * 2).ToString("C2") & " (bimestral)"
                    Case "VECES DE SM"
                        descuentoMensual = credInfonavit.CISalarioMinimoDF.ToString("C2") & " (salario mínimo del DF) * " & credInfonavit.CIValordescuento.ToString("N4") & " veces = " & credInfonavit.CIRetencionMensual.ToString("N2") & " (mensual)"
                        descuentoBimestral = "Descuento bimestral de " & credInfonavit.CIImporteretencionbimestral.ToString("C2") & " + " & credInfonavit.CISeguroVivienda.ToString("C2") & " Seguro para vivienda = " & credInfonavit.CIImporteretenerbimestral.ToString("C2")
                End Select

                Dim credito = New DataTable("dtCredito")
                With credito
                    .Columns.Add("Nombre")
                    .Columns.Add("NumCredito")
                    .Columns.Add("TipoDescuento")
                    .Columns.Add("CalculoMensual")
                    .Columns.Add("CalculoBimestral")
                    .Columns.Add("DescuentoSemanal")
                End With

                credito.Rows.Add( _
                    credInfonavit.CIColaborador, _
                    credInfonavit.CINumerocredito, _
                    credInfonavit.CITipoDescuentoStr, _
                    descuentoMensual, _
                    descuentoBimestral, _
                    credInfonavit.CIDescuentosemanal _
                )

                reporte("Logo") = credInfonavit.CILogoNave
                reporte.RegData(credito)
                'reporte.Show()
                reporte.Render()
                reporte.ExportDocument(StiExportFormat.Pdf, sPDF, pdfSettings)
                reporte.Dispose()

                If subirArchivoInfonavit(sPDF, credInfonavit.CIColaboradorid) Then
                    eliminaArchivo(sPDF)
                    Return True
                Else
                    eliminaArchivo(sPDF)
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Else
            Return True
        End If
    End Function

    Private Function subirArchivoInfonavit(ByVal ruta As String, ByVal colaboradorId As Integer) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorioInfonavit = rutaAcuses & colaboradorId

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorioInfonavit, ruta)
                rutaArchivo = objFTP.obtenerURL & "/" & directorioInfonavit & "/" & IO.Path.GetFileName(ruta)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    directorioInfonavit = String.Empty
                    Return False
                End If
            Else
                directorioInfonavit = String.Empty
                Return False
            End If
        Catch
            directorioInfonavit = String.Empty
            Return False
        End Try
    End Function
End Class