Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class CancelacionApartados

    Public dtDatosApartadosPartidasCancelar As DataTable
    Public detallada As Integer

    Private Sub btnCerrarr_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CancelacionApartados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdDatosCancelar.DataSource = dtDatosApartadosPartidasCancelar
        gridApartadosPartidasCancelarDiseño(grdDatosCancelar)
    End Sub

    Private Sub gridApartadosPartidasCancelarDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim objBU As New Negocios.ApartadosBU
        Dim dtResultadoMotivosCancelacion As New DataTable
        Dim listOpcionesMotivosCancelacion As New ValueList

        dtResultadoMotivosCancelacion = objBU.consultaMotivosCancelacion()

        For Each renglon As DataRow In dtResultadoMotivosCancelacion.Rows
            listOpcionesMotivosCancelacion.ValueListItems.Add(renglon.Item("ID"), renglon.Item("Motivo"))
        Next

        grid.DisplayLayout.Bands(0).Columns("Apartado").Header.Caption = "Apartado"
        grid.DisplayLayout.Bands(0).Columns("Apartado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Apartado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        If detallada = 1 Then
            grid.DisplayLayout.Bands(0).Columns("ApartadoDetalle").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Partida").Header.Caption = "Partida"
            grid.DisplayLayout.Bands(0).Columns("Partida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Partida").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Producto").Header.Caption = "Producto"
            grid.DisplayLayout.Bands(0).Columns("Producto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("Pedido").Header.Caption = "PedidoSAY"
        grid.DisplayLayout.Bands(0).Columns("Pedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").Header.Caption = "OrdenCte"
        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("Cantidad").Header.Caption = "Cantidad"
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cantidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("Status").Header.Caption = "Status"
        grid.DisplayLayout.Bands(0).Columns("Status").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        grid.DisplayLayout.Bands(0).Columns("Motivo").Header.Caption = "*Motivo Cancelación"
        grid.DisplayLayout.Bands(0).Columns("Motivo").Style = ColumnStyle.DropDownList
        grid.DisplayLayout.Bands(0).Columns("Motivo").ValueList = listOpcionesMotivosCancelacion
        grid.DisplayLayout.Bands(0).Columns("Motivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit

        grid.DisplayLayout.Bands(0).Columns("Observaciones").Header.Caption = "*Observaciones"
        grid.DisplayLayout.Bands(0).Columns("Observaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("Observaciones").CharacterCasing = CharacterCasing.Upper
        grid.DisplayLayout.Bands(0).Columns("Observaciones").MaxLength = 250

        grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Cliente").Hidden = True


        ' grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


        Dim summary1 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Cantidad"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right



        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If


        grid.DisplayLayout.Bands(0).Columns("Apartado").Width = 35
        If detallada = 1 Then
            grid.DisplayLayout.Bands(0).Columns("Partida").Width = 35
            grid.DisplayLayout.Bands(0).Columns("Producto").Width = 100
        End If
        grid.DisplayLayout.Bands(0).Columns("Pedido").Width = 55
        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").Width = 60
        grid.DisplayLayout.Bands(0).Columns("Cantidad").Width = 45
        grid.DisplayLayout.Bands(0).Columns("Status").Width = 70
        grid.DisplayLayout.Bands(0).Columns("Motivo").Width = 200
        grid.DisplayLayout.Bands(0).Columns("Observaciones").Width = 200
        grid.DisplayLayout.Bands(0).Columns("Cliente").Width = 80

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.ApartadosBU
        Dim dtResultadoCancelacion As New DataTable
        Dim contador As Integer = 0
        Dim apartadosCancelar As String = ""
        Dim partidasCancelar As String = ""
        Dim motivosCancelacion As String = ""
        Dim observacionesCancelacion As String = ""
        Dim datosIncompletos As Integer = 0
        Dim confirmar As New Tools.confirmarFormGrande
        Dim idUsuarioCancela As Integer = 0

        idUsuarioCancela = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If detallada = 0 Then

            For Each renglon As UltraGridRow In grdDatosCancelar.Rows
                If IsDBNull(renglon.Cells("Motivo").Value) Or IsDBNull(renglon.Cells("Observaciones").Value) Then
                    datosIncompletos += 1
                    Exit For
                End If

                If renglon.Cells("Motivo").Value = "" Or renglon.Cells("Observaciones").Value = "" Then
                    datosIncompletos += 1
                    Exit For
                Else
                    contador += 1
                    If apartadosCancelar <> "" Then
                        apartadosCancelar += ","
                    End If
                    apartadosCancelar += renglon.Cells("Apartado").Value.ToString()
                    If motivosCancelacion <> "" Then
                        motivosCancelacion += ","
                    End If
                    motivosCancelacion += renglon.Cells("Motivo").Value.ToString()
                    If observacionesCancelacion <> "" Then
                        observacionesCancelacion += "~"
                    End If
                    observacionesCancelacion += renglon.Cells("Observaciones").Value.ToString().ToUpper()
                End If
            Next

            If datosIncompletos > 0 Then
                show_message("Advertencia", "Debe seleccionar un motivo de cancelación y capturar una observación para cada apartado a cancelar")
            Else
                If contador > 1 Then
                    confirmar.mensaje = "¿Está seguro que desea cancelar los apartados #" + apartadosCancelar.ToString() + "? (Este proceso no puede revertirse)"
                ElseIf contador = 1 Then
                    confirmar.mensaje = "¿Está seguro que desea cancelar el apartado #" + apartadosCancelar.ToString() + "? (Este proceso no puede revertirse)"
                End If

                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    btnGuardar.Enabled = False
                    Dim ApartadosSinCancelar As String = ""

                    For Each renglon As UltraGridRow In grdDatosCancelar.Rows
                        Try
                            objBu.cancelarApartado(renglon.Cells("Apartado").Value, renglon.Cells("Motivo").Value, renglon.Cells("Observaciones").Value.ToString().ToUpper(), idUsuarioCancela)
                            objBu.cancelarApartadoSICY(renglon.Cells("Apartado").Value)
                            objBu.EnviarParesCanceladosApartadoAProgramar(renglon.Cells("Apartado").Value)
                        Catch ex As Exception
                            If ApartadosSinCancelar = "" Then
                                ApartadosSinCancelar += " " + renglon.Cells("Apartado").Value.ToString
                            Else
                                ApartadosSinCancelar += " ," + renglon.Cells("Apartado").Value.ToString
                            End If

                        End Try


                    Next

                    If ApartadosSinCancelar = "" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha cancelado con exito el apartado")
                        enviarCorreoCancelacionApartados()
                        Cursor = Cursors.Default
                        Me.Close()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Los siguientes apartados no se cancelaron " + ApartadosSinCancelar)
                        Cursor = Cursors.Default
                        Me.Close()
                    End If


                    '' CODIGO ANTERIOR
                    'dtResultadoCancelacion = objBu.cancelarApartados(apartadosCancelar, motivosCancelacion, observacionesCancelacion, idUsuarioCancela)
                    'show_message(dtResultadoCancelacion.Rows(0)("tipoResultado"), dtResultadoCancelacion.Rows(0)("mensajeResultado"))
                    'If dtResultadoCancelacion.Rows(0)("tipoResultado") = "Exito" Then
                    '    'enviarCorreoCancelacionApartados()
                    '    Cursor = Cursors.Default
                    '    Me.Close()
                    'End If



                End If

            End If

        Else

            For Each renglon As UltraGridRow In grdDatosCancelar.Rows
                If renglon.Cells("Motivo").Value = "" Or renglon.Cells("Observaciones").Value = "" Then
                    datosIncompletos += 1
                    Exit For
                Else
                    contador += 1
                    If partidasCancelar <> "" Then
                        partidasCancelar += ","
                    End If
                    partidasCancelar += renglon.Cells("ApartadoDetalle").Value.ToString()
                    If motivosCancelacion <> "" Then
                        motivosCancelacion += ","
                    End If
                    motivosCancelacion += renglon.Cells("Motivo").Value.ToString()
                    If observacionesCancelacion <> "" Then
                        observacionesCancelacion += "~"
                    End If
                    observacionesCancelacion += renglon.Cells("Observaciones").Value.ToString()
                End If
            Next

            If datosIncompletos > 0 Then
                show_message("Advertencia", "Debe seleccionar un motivo de cancelación y capturar una observación para cada partida a cancelar")
            Else
                If contador > 1 Then
                    confirmar.mensaje = "¿Está seguro que desea cancelar las" + contador.ToString() + " partidas seleccionadas? (Este proceso no puede revertirse)"
                ElseIf contador = 1 Then
                    confirmar.mensaje = "¿Está seguro que desea cancelar la partida seleccionada? (Este proceso no puede revertirse)"
                End If

                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    btnGuardar.Enabled = False
                    Dim ApartadosSinCancelar As String = ""

                    For Each renglon As UltraGridRow In grdDatosCancelar.Rows
                        Try
                            objBu.CancelarPartidaApartado(renglon.Cells("Apartado").Value, renglon.Cells("ApartadoDetalle").Value, renglon.Cells("Motivo").Value, renglon.Cells("Observaciones").Value.ToString().ToUpper(), idUsuarioCancela)
                            objBu.cancelarPartidaApartadoSICY(renglon.Cells("Apartado").Value, renglon.Cells("ApartadoDetalle").Value)
                            objBu.EnviarParesCanceladosPartidaApartadoAProgramar(renglon.Cells("Apartado").Value, renglon.Cells("ApartadoDetalle").Value)
                        Catch ex As Exception
                            If ApartadosSinCancelar = "" Then
                                ApartadosSinCancelar += " " + renglon.Cells("Apartado").Value.ToString
                            Else
                                ApartadosSinCancelar += " ," + renglon.Cells("Apartado").Value.ToString
                            End If

                        End Try


                    Next

                    If ApartadosSinCancelar = "" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha cancelado con exito el apartado")
                        enviarCorreoCancelacionApartados()
                        Cursor = Cursors.Default
                        Me.Close()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Los siguientes apartados no se cancelaron " + ApartadosSinCancelar)
                        Cursor = Cursors.Default
                        Me.Close()
                    End If


                    'dtResultadoCancelacion = objBu.cancelarPartidas(partidasCancelar, motivosCancelacion, observacionesCancelacion, idUsuarioCancela)
                    'show_message(dtResultadoCancelacion.Rows(0)("tipoResultado"), dtResultadoCancelacion.Rows(0)("mensajeResultado"))
                    'If dtResultadoCancelacion.Rows(0)("tipoResultado") = "Exito" Then
                    '    enviarCorreoCancelacionApartados()
                    '    Cursor = Cursors.Default
                    '    Me.Close()
                    'End If

                End If

            End If

        End If
        Cursor = Cursors.Default
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

    Private Sub enviarCorreoCancelacionApartados()
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

        dtResultadoDatosCorreos = objBu.consultaCorreosEnvioCancelacion("ENVIO_APARTADOS_CANCELARAPARTADO")

        If dtResultadoDatosCorreos.Rows.Count > 0 Then

            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()
            destinatarios = dtResultadoDatosCorreos.Rows(0).Item("Destinatarios").ToString()


            For Each renglon As UltraGridRow In grdDatosCancelar.Rows
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
                If detallada = 1 Then
                    cadenaCorreo += " <br><p><B>CANCELACI&Oacute;N DE PARTIDA:</B> " + renglon.Cells("Partida").Value.ToString() + "  (APARTADO " + renglon.Cells("Apartado").Value.ToString() + " PEDIDO " + renglon.Cells("Pedido").Value.ToString()
                Else
                    cadenaCorreo += " <br><p><B>CANCELACI&Oacute;N DE APARTADO:</B> " + renglon.Cells("Apartado").Value.ToString() + " (PEDIDO " + renglon.Cells("Pedido").Value.ToString()
                End If
                cadenaCorreo += If(renglon.Cells("OrdenCliente").Value.ToString() <> "", " ORDEN CLIENTE " + renglon.Cells("OrdenCliente").Value.ToString(), "")
                cadenaCorreo += ")</p>  "
                cadenaCorreo += " <p><B>CLIENTE:</B> " + renglon.Cells("Cliente").Value.ToString() + "</p>"
                cadenaCorreo += " <br><p align='center'><B>DETALLES DE LA CANCELACI&Oacute;N</B></p>"
                cadenaCorreo += " </div>"
                cadenaCorreo += " </div>"
                cadenaCorreo += " <div id='content' >"
                cadenaCorreo += " <p><B>USUARIO:</B> " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal + "</p>"
                cadenaCorreo += " <p><B>FECHA:</B> " + Date.Now.ToString() + "</p>"
                cadenaCorreo += " <p><B>MOTIVO:</B> " + renglon.Cells("Motivo").Text.ToString() + " (OBSERVACI&Oacute;N: " + renglon.Cells("Observaciones").Text.ToString().ToUpper() + ")</p>"
                cadenaCorreo += " <table id= 'mi_tabla'  class='tableizer-table'align='center' >"
                cadenaCorreo += " <thead>"
                cadenaCorreo += " <tr class='tableizer-firstrow'>"
                cadenaCorreo += " <th >Partida</th>"
                cadenaCorreo += " <th width='30%' height='30px'>Coleccion</th>"
                cadenaCorreo += " <th>Modelo</th>"
                cadenaCorreo += " <th width='20%'>Piel-Color</th>"
                cadenaCorreo += " <th >Corrida</th>"
                cadenaCorreo += " <th>Pares</th>"
                cadenaCorreo += " </tr>"
                cadenaCorreo += " </thead>"
                cadenaCorreo += " <tbody>"

                If detallada = 1 Then
                    tipoBusquedaPartidas = 2
                    idBusquedaPartidas = Integer.Parse(renglon.Cells("ApartadoDetalle").Value.ToString())
                Else
                    tipoBusquedaPartidas = 1
                    idBusquedaPartidas = Integer.Parse(renglon.Cells("Apartado").Value.ToString())
                End If

                dtResultadoPartidasCanceladas = objBu.busquedaPartidasApartadosParaCorreoCancelacion(idBusquedaPartidas, tipoBusquedaPartidas)

                For Each rowDt As DataRow In dtResultadoPartidasCanceladas.Rows
                    cadenaCorreo += " <tr>"
                    cadenaCorreo += " <td align='right'>" + rowDt.Item("Partida").ToString + "</td>"
                    cadenaCorreo += " <td>" + rowDt.Item("Coleccion").ToString + "</td>"
                    cadenaCorreo += " <td>" + rowDt.Item("Modelo").ToString + "</td>"
                    cadenaCorreo += " <td> " + rowDt.Item("PielColor").ToString + "</td>"
                    cadenaCorreo += " <td> " + rowDt.Item("Corrida").ToString + "</td>"
                    cadenaCorreo += " <td align='right'> " + rowDt.Item("Pares").ToString + "</td>"
                    cadenaCorreo += " </tr>"
                Next

                cadenaCorreo += " </tbody>" +
                 " </table>" +
                  " </div>" +
                  " </body> " +
                  " </html> "

                If detallada = 1 Then
                    asuntoCorreo = "Cancelación de Partida  " + renglon.Cells("Partida").Value.ToString() + " (Apartado " + renglon.Cells("Apartado").Value.ToString() + " Pedido " + renglon.Cells("Pedido").Value.ToString() + ")"
                Else
                    asuntoCorreo = "Cancelación de apartado " + renglon.Cells("Apartado").Value.ToString() + " (Pedido " + renglon.Cells("Pedido").Value.ToString() + ")"
                End If

                destinatariosConUsuarioCapturo = destinatarios
                dtResultadoUsuarioCaptura = objBu.ConsultaCorreoUsuarioCaptura(renglon.Cells("Apartado").Value.ToString())

                If dtResultadoUsuarioCaptura.Rows.Count > 0 Then
                    destinatariosConUsuarioCapturo += "," + dtResultadoUsuarioCaptura.Rows(0).Item("CorreoUsuarioCaptura").ToString()
                End If

                correo.EnviarCorreoHtml(destinatariosConUsuarioCapturo, remitente, asuntoCorreo, cadenaCorreo)
            Next

        End If

    End Sub

End Class