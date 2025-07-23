Imports Tools
Imports System.Net
Imports System.Windows.Forms.OpenFileDialog
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Linq
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Stimulsoft.Report

Public Class PDFAcuseMovimientoBajaIDSEForm


    Public movimiento As String = String.Empty
    Dim directorio As String = String.Empty
    Public solicitudId As Integer = 0
    Public colaboradorId As Integer = 0
    Public guardado As Boolean = False


    Private Sub PDFAcuseMovimientoBajaIDSEForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If movimiento = "Aceptar" Then
            rdbAceptado.Checked = True
            rdbRechazado.Checked = False
        Else
            rdbAceptado.Checked = False
            rdbRechazado.Checked = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtArchivo.Text = String.Empty Then
            show_message("Advertencia", "No se ha seleccionado un archivo.")
        Else
            AplicarMovimiento()
        End If

    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PDF|*.pdf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        txtArchivo.Text = ofdRutaArchivo.FileName
    End Sub

    Public Sub AplicarMovimiento()
        Dim advetencia As New AdvertenciaForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objBu As New Negocios.SolicitudBajaBU
        Dim resul As DataTable
        Dim exito As New ExitoForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim Resultado As String = String.Empty
        Dim motivo As String = String.Empty

        If validarArchivo() Then
            If movimiento = "Aceptar" Then
                objMensajeConf.mensaje = "Esta acción actualizará la solicitud de baja a ""ACEPTADA"", ¿Está seguro de continuar?"
            Else
                objMensajeConf.mensaje = "Esta acción actualizará la solicitud de baja a ""RECHAZADA"", ¿Está seguro de continuar?"
            End If

            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                If subirArchivo(txtArchivo.Text) Then
                    If movimiento = "Aceptar" Then
                        resul = objBu.SolicitudBajaAceptada(solicitudId, colaboradorId, directorio, IO.Path.GetFileName(txtArchivo.Text), movimiento, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    Else
                        Dim formMotivo As New MotivoRechazoForm
                        formMotivo.ShowDialog()
                        motivo = formMotivo.motivo

                        If motivo <> "" Then
                            Dim objMensajeAdv As New Tools.AdvertenciaForm
                            objMensajeAdv.mensaje = "Debe Ingresar el motivo de rechazo."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                        resul = objBu.SolicitudBajaRechazada(solicitudId, colaboradorId, directorio, IO.Path.GetFileName(txtArchivo.Text), movimiento, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, motivo)
                    End If
                    Resultado = resul.Rows(0).Item("resul")

                    If Resultado = "EXITO" Then
                        'enviarCorreo()
                        If movimiento = "Aceptar" Then
                            exito.mensaje = "Se aceptó la baja del colaborador exitosamente"
                        Else
                            exito.mensaje = "Se actualizó la solicitud exitosamente. Intente nuevamente cuando la baja haya sido aceptada"
                        End If

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


    Public Sub enviarCorreo()
        Dim dtDestinatarios As New DataTable
        Dim objBu As New Negocios.SolicitudBajaBU
        Dim destinatarios As String = String.Empty
        Dim correoEnvia As String = String.Empty
        Dim correo As New Tools.Correo
        Dim asunto As String = String.Empty
        Dim mensaje As String = String.Empty
        Dim altaImss As New Entidades.AltaColaboradorIMSS
        Dim dtAlta As New DataTable

        dtDestinatarios = objBu.ConsultaEnvioCorreo(solicitudId)

        dtAlta = objBu.ObtenerSolicitud(-1, solicitudId, -1, -1)

        If dtAlta.Rows.Count > 0 Then
            altaImss.PNombre = dtAlta.Rows(0).Item("NombreCompleto")
            altaImss.PNSS = dtAlta.Rows(0).Item("cono_nss")
            altaImss.PSDI = dtAlta.Rows(0).Item("cono_salariodiario")
            altaImss.PColaboradorId = dtAlta.Rows(0).Item("baim_colaboradorid")
            altaImss.PFechaAlta = dtAlta.Rows(0).Item("baim_fechabaja")
            altaImss.PNombres = dtAlta.Rows(0).Item("Nombre")
            altaImss.PAPaterno = dtAlta.Rows(0).Item("APaterno")
            altaImss.PAMaterno = dtAlta.Rows(0).Item("AMaterno")
        End If
        If movimiento = "Aceptar" Then
            mensaje = cuerpoCorreoAceptado(altaImss)
            asunto = "Confirmación de la Solicitud de baja IMSS de " + altaImss.PNombre
        Else
            mensaje = cuerpoCorreoRechazado(altaImss)
            asunto = "Rechazo IDSE de la Solicitud de Baja IMSS de " + altaImss.PNombre
        End If

        If Not dtDestinatarios Is Nothing Then
            If dtDestinatarios.Rows.Count > 0 Then
                destinatarios = dtDestinatarios.Rows(0)("destinatarios").ToString
                correoEnvia = dtDestinatarios.Rows(0)("correoEnvia").ToString

                ' correo.EnviarCorreoHtml(destinatarios, correoEnvia, asunto, mensaje)
            End If
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
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Solicitud de Baja de IMSS" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>" &
                "<p>Se ha Aceptado la Solicitud de Baja IMSS del colaborador. </p>"
        mensaje &= "<table id='tblInformacion' class='tableizer-table'>" &
                "<thead>" &
                "<tr class='tableizer-firstrow'>" &
                "<th>NSS</th>" &
                "<th>NOMBRE</th>" &
                "<th>A PATERNO</th>" &
                "<th>A MATERNO</th>" &
                "<th>FECHA<br />MOVIMIENTO</th>" &
                "<th>" & encabezadoISR & "</th>" &
                "</tr>" &
                "</thead>"
        mensaje &= "<tbody>" &
                "<tr>" &
                "<td>" & altaImss.PNSS & "</td>" &
                "<td>" & altaImss.PNombres & "</td>" &
                "<td>" & altaImss.PAPaterno & "</td>" &
                "<td>" & altaImss.PAMaterno & "</td>" &
                "<td>" & altaImss.PFechaAlta & "</td>" &            
                "</tr>"
        mensaje &= "</tbody>"
        mensaje &= "</table>"
        mensaje &= "<p>Para descargar el acuse de baja de IMSS vaya a la ficha del colaborador, en su expediente encontrará disponible el archivo correspondiente.</p>"
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
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Solicitud de Baja IMSS" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>" &
                "<p>La Solicitud de Baja IMSS de " & altaImss.PNombre & " fue rechazado en IDSE. Al inicio del próximo periodo de nómina se intentará nuevamente la carga por lo que en este periodo no se verá reflejada esta modificación. Para descargar el acuse de rechazo vaya a la ficha del colaborador, en su expediente encontrará disponible el archivo correspondiente, el cual será remplazado con el correspondiente acuse de confirmación cuando la carga sea exitosa.</p>"
        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje

    End Function

   
End Class