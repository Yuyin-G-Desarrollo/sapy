Imports Tools
Imports Infragistics.Win.UltraWinGrid

Public Class ConfirmacionIncompletaForm

    Public NumApartado As Integer = 0
    Public ventanaAnterior As New ConfirmarApartado()
    Public TotalParesProgramar As Integer = 0
    Public ventanaAdministrador As New AdministracionApartadosForm()

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ObjBu As New Negocios.ApartadosBU()
        Dim confirmacion As New confirmarFormGrande
        Dim mensajeConfirmacion As String = String.Empty
        Dim dtResultadoGuardado As New DataTable

        If txtObservacionConfirmacionIncompleta.Text <> "" Then
            mensajeConfirmacion = "Este apartado quedará en status de CONFIRMACIÓN INCOMPLETA, al guardar este status los " + TotalParesProgramar.ToString() + " pares pendientes por confirmar serán enviados al área de PPCP para su programación y ya no podrá realizar ningún movimiento a este apartado ¿Desea guardar este cambio?"
            confirmacion.mensaje = mensajeConfirmacion
            If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                dtResultadoGuardado = ObjBu.ConfirmacionIncompleta(NumApartado, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObservacionConfirmacionIncompleta.Text)
                show_message(dtResultadoGuardado.Rows(0).Item("tipoResultado").ToString(), dtResultadoGuardado.Rows(0).Item("mensajeResultado").ToString())
                ventanaAnterior.statusApartado = "CONFIRMACIÓN INCOMPLETA"
                ventanaAdministrador.ventanaAbierta = "Confirmacion"
                enviarCorreoConfirmacionIncompleta()
                Me.Close()
            End If
        Else
            show_message("Advertencia", "Debe capturar una observación para realizar la confirmación incompleta")
        End If
    End Sub


    Private Sub ConfirmacionIncompletaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNumApartado.Text = NumApartado.ToString()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub ConfirmacionIncompletaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ventanaAnterior.terminaConfirmacionIncompleta()
        If ventanaAnterior.statusApartado = "CONFIRMACIÓN INCOMPLETA" Then
            ventanaAnterior.CargarDatos()
        End If
    End Sub

    Private Sub enviarCorreoConfirmacionIncompleta()
        Dim objBu As New Negocios.ApartadosBU
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim correo As New Tools.Correo
        Dim cadenaCorreo As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim tipoBusquedaPartidas As Integer = 0
        Dim idBusquedaPartidas As Integer = 0
        Dim dtResultadoPartidasCanceladas As New DataTable
        Dim dtResultadoUsuarioCaptura As New DataTable
        Dim destinatariosConUsuarioCapturo As String = String.Empty

        dtResultadoDatosCorreos = objBu.consultaCorreosEnvioConfirmacionIncompleta("ENVIO_APARTADOS_CONFIRMACIONINCOMPLETA")

        If dtResultadoDatosCorreos.Rows.Count > 0 Then

            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()


            cadenaCorreo = "<html> " +
                                            " <head>" +
                                                " <style type='text/css'>body {display: block; margin: 8px; background: #FFFFFF;}" +
                                                " #header{	position: fixed;" +
                                                " height: 62px;" +
                                                " margin: 1% 1%;" +
                                                " top: 0;" +
                                                " left: 0;" +
                                                " right: 0;" +
                                                " color: black;" +
                                                " font-family: Arial, Helvetica ,sans-serif;" +
                                                " font-size: 12px;" +
                                                 " }" +
                                                " #content   {width: 90%;" +
                                                " position: fixed;" +
                                                " margin: 0% 0%;" +
                                                " padding-top: 15%;" +
                                                " padding-bottom: 1%;" +
                                                " font-family: Arial, Helvetica ,sans-serif;" +
                                                " font-size: 12px;" +
                                                " }" +
                                                " table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;" +
                                                " font-size: 10px;}" +
                                                " .tableizer-table td {	padding: 4px;" +
                                                " margin: 0px;" +
                                                " border: 1px solid #FFFFFF;" +
                                                " border-color: #FFFFFF;" +
                                                 " border: 1px solid #CCCCCC;" +
                                                " width: 90px;}" +
                                                " .tableizer-table tr {	padding: 4px;" +
                                                " margin: 0;" +
                                                " color: #003366;" +
                                                " font-weight: bold;" +
                                                " background-color: #transparent;" +
                                                " opacity: 1;}" +
                                                " .tableizer-table th {	background-color: #DFDFDF;" +
                                                " color: black;" +
                                                " font-weight: bold;" +
                                                " height: 30px;" +
                                                " font-size: 11px;}" +
                                                " .tableizer-table tr:nth-child(odd){ background-color: #9BC4E2;}" +
                                                " .tableizer-table tr:nth-child(even){ background-color:  #transparent;}" +
                                                " </style>" +
                                            " </head>"
            cadenaCorreo += " <body> "
            cadenaCorreo += " <div id='wrapper'>"
            cadenaCorreo += " <div id='header'>"

            cadenaCorreo += " <br><p><B>CONFIRMACI&Oacute;N INCOMPLETA DEL APARTADO:</B># " + NumApartado.ToString() + ""
            cadenaCorreo += " <p><B>CLIENTE:</B> " + ventanaAnterior.lblNombreCliente.Text + "</p>"
            cadenaCorreo += " <br><p align='center'><B>DETALLES DE LA CONFIRMACI&Oacute;N INCOMPLETA</B></p>"
            cadenaCorreo += " </div>"
            cadenaCorreo += " </div>"
            cadenaCorreo += " <div id='content' >"
            cadenaCorreo += " <p><B>USUARIO:</B> " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal + "</p>"
            cadenaCorreo += " <p><B>FECHA:</B> " + Date.Now.ToString() + "</p>"
            cadenaCorreo += " <p>Los siguientes pares se enviar&aacute;n al &aacute;rea de PPCP para su programaci&oacute;n:  "
            cadenaCorreo += " <table id= 'mi_tabla'  class='tableizer-table'align='center' >"
            cadenaCorreo += " <thead>"
            cadenaCorreo += " <tr class='tableizer-firstrow'>"
            cadenaCorreo += " <th >Partida</th>"
            cadenaCorreo += " <th width='30%' height='30px'>Colecci&oacute;n</th>"
            cadenaCorreo += " <th>Modelo</th>"
            cadenaCorreo += " <th >Talla</th>"
            cadenaCorreo += " <th>Pares</th>"
            cadenaCorreo += " </tr>"
            cadenaCorreo += " </thead>"
            cadenaCorreo += " <tbody>"

            For Each rowDt As UltraGridRow In ventanaAnterior.grdPartidasConfirmadasyPorConfirmar.Rows
                If rowDt.Appearance.BackColor = ventanaAnterior.pnlColorPartidaIncompleta.BackColor And rowDt.Appearance.ForeColor = Color.Red Then
                    cadenaCorreo += " <tr>"
                    cadenaCorreo += " <td align='right'>" + rowDt.Cells("#").Value.ToString + "</td>"
                    cadenaCorreo += " <td>" + rowDt.Cells("Coleccion").Value.ToString + "</td>"
                    cadenaCorreo += " <td>" + rowDt.Cells("Modelo").Value.ToString + "</td>"
                    cadenaCorreo += " <td> " + rowDt.Cells("Talla").Value.ToString + "</td>"
                    cadenaCorreo += " <td align='right'> " + rowDt.Cells("Faltante").Value.ToString + "</td>"
                    cadenaCorreo += " </tr>"
                End If
            Next

            cadenaCorreo += " </tbody>" +
             " </table>" +
              " </div>" +
              " </body> " +
              " </html> "

            asuntoCorreo = "Confirmación incompleta del apartado " + NumApartado.ToString() + " (Pedido SAY " + ventanaAnterior.lblIdPedidoSAY.Text + ")"

            destinatariosConUsuarioCapturo = destinatarios
            dtResultadoUsuarioCaptura = objBu.ConsultaCorreoUsuarioCaptura(NumApartado.ToString())

            If dtResultadoUsuarioCaptura.Rows.Count > 0 Then
                destinatariosConUsuarioCapturo += "," + dtResultadoUsuarioCaptura.Rows(0).Item("CorreoUsuarioCaptura").ToString()
            End If


            correo.EnviarCorreoHtml(destinatariosConUsuarioCapturo, remitente, asuntoCorreo, cadenaCorreo)

        End If

    End Sub

End Class