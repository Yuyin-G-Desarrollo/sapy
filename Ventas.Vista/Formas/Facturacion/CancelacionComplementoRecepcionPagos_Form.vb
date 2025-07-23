Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Tools

Public Class CancelacionComplementoRecepcionPagos_Form

#Region "VARIABLES GLOBALES"

    Public idComplementoPago As Integer
    Public folioCRP As String
    Public montoPago As String
    Public razonSocialCliente As String
    Public fechaCRP As String

    Public ventanaAdministradorCRP As New AdministradorComplementoRecepcionPagos_Form

    Private Guardando As Integer = 0
    Private ErrorCancelacion As String = String.Empty

#End Region

    Private Sub CancelacionComplementoRecepcionPagos_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtDatosMostrarCancelacion As New DataTable
        Dim dtComboMotivoCancelacion As New DataTable
        Dim objBu As New Negocios.AdministradorComplementoRecepcionPagosBU

        dtDatosMostrarCancelacion = objBu.consultaMotivosCancelacion()

        dtDatosMostrarCancelacion.Rows.InsertAt(dtDatosMostrarCancelacion.NewRow, 0)

        cmboxMotivoCancelación.DataSource = dtDatosMostrarCancelacion

        cmboxMotivoCancelación.ValueMember = "IdMotivoCancelacion"
        cmboxMotivoCancelación.DisplayMember = "Motivo"

        lblFolioCRP.Text = folioCRP
        lblMontoPago.Text = montoPago
        lblCliente.Text = razonSocialCliente
        lblFecha.Text = fechaCRP

        dtDatosMostrarCancelacion = objBu.consultaDatosFacturasPantallaCancelacion(idComplementoPago)
        grdFacturasCancelacion.DataSource = dtDatosMostrarCancelacion
        DiseñoGridDocumentos()

    End Sub

    Private Sub DiseñoGridDocumentos()
        bgvFacturasCancelacion.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvFacturasCancelacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            bgvFacturasCancelacion.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowEdit = False
        Next

        bgvFacturasCancelacion.Columns.ColumnByFieldName("Monto Original de la Factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo Anterior").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Total Aplicado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo de la Factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvFacturasCancelacion.Columns.ColumnByFieldName("No. Parcialidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvFacturasCancelacion.Columns.ColumnByFieldName("F Factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        bgvFacturasCancelacion.Columns.ColumnByFieldName("Monto Original de la Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo Anterior").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Total Aplicado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo de la Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvFacturasCancelacion.Columns.ColumnByFieldName("No. Parcialidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Folio Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvFacturasCancelacion.Columns.ColumnByFieldName("Monto Original de la Factura").DisplayFormat.FormatString = "N2"
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo Anterior").DisplayFormat.FormatString = "N2"
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Total Aplicado").DisplayFormat.FormatString = "N2"
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo de la Factura").DisplayFormat.FormatString = "N2"
        bgvFacturasCancelacion.Columns.ColumnByFieldName("No. Parcialidad").DisplayFormat.FormatString = "N0"

        bgvFacturasCancelacion.Columns.ColumnByFieldName("Folio Factura").Width = 100
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Método de Pago").Width = 100
        bgvFacturasCancelacion.Columns.ColumnByFieldName("F Factura").Width = 120
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Monto Original de la Factura").Width = 150
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo Anterior").Width = 85
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Total Aplicado").Width = 75
        bgvFacturasCancelacion.Columns.ColumnByFieldName("Saldo de la Factura").Width = 110
        bgvFacturasCancelacion.Columns.ColumnByFieldName("No. Parcialidad").Width = 100

        bgvFacturasCancelacion.Columns.ColumnByFieldName("F Factura").DisplayFormat.FormatString = "dd/MM/yyyy"

        bgvFacturasCancelacion.IndicatorWidth = 40
        bgvFacturasCancelacion.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(bgvFacturasCancelacion.Columns("Total Aplicado").Summary.FirstOrDefault(Function(x) x.FieldName = "Total Aplicado")) = True Then
            bgvFacturasCancelacion.Columns("Total Aplicado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Aplicado", "{0:N2}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Total Aplicado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0:N2}"
            bgvFacturasCancelacion.GroupSummary.Add(item2)
        End If


    End Sub

    Private Sub bgvCFDI_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvFacturasCancelacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnGuardarCancelacion_Click(sender As Object, e As EventArgs) Handles btnGuardarCancelacion.Click
        Dim objBU As New Negocios.AdministradorComplementoRecepcionPagosBU
        Dim confirmacion As New Tools.ConfirmarForm
        Dim dtResultadoGenerarDatosTimbrado As New DataTable

        Guardando = 1

        Dim resultadoCancelacion As New DataTable

        Dim tipoCancelacion As String = If(rdbCancelación.Checked, "CANCELACION", "SUSTITUCION")
        Dim observacionCancelacion As String = txtObservaciones.Text

        If cmboxMotivoCancelación.SelectedIndex > 0 And txtObservaciones.Text <> "" Then
            confirmacion.mensaje = "Se cancelará el complmento de pago #" + idComplementoPago.ToString() + ", esta acción no podrá revertirse. ¿Desea continuar?"
            If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If Cancelacion_Complementoid(idComplementoPago) = False Then
                    show_message("Error", ErrorCancelacion)
                    Exit Sub
                End If
                resultadoCancelacion = objBU.cancelarComplementoPago(idComplementoPago, tipoCancelacion, observacionCancelacion, cmboxMotivoCancelación.SelectedValue, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                'show_message(resultadoCancelacion.Rows(0).Item("Resultado").ToString(), resultadoCancelacion.Rows(0).Item("Mensaje").ToString())
                If resultadoCancelacion.Rows(0).Item("Resultado").ToString() = "Exito" Then
                    show_message(resultadoCancelacion.Rows(0).Item("Resultado").ToString(), resultadoCancelacion.Rows(0).Item("Mensaje").ToString() & " se enviará el nuevo complemento con el id #" + resultadoCancelacion.Rows(0).Item("complementopagoid").ToString())
                    btnGuardarCancelacion.Enabled = False
                    lblGuardarCancelacion.Enabled = False
                    Dim complementoPagoId As Integer = resultadoCancelacion.Rows(0).Item("complementopagoid")
                    If complementoPagoId > 0 Then
                        dtResultadoGenerarDatosTimbrado = objBU.generarDatosTimbrarComplemento(complementoPagoId)
                        If dtResultadoGenerarDatosTimbrado.Rows.Count > 0 Then
                            Dim resultado As String = String.Empty
                            Dim mensaje As String = String.Empty

                            resultado = dtResultadoGenerarDatosTimbrado.Rows(0).Item("Resultado").ToString()
                            mensaje = dtResultadoGenerarDatosTimbrado.Rows(0).Item("Mensaje").ToString()

                            If resultado = "Exito" Then
                                Dim idEmpresa = CInt(dtResultadoGenerarDatosTimbrado.Rows(0).Item("idEmpresa"))
                                Dim objComplemento As New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                                objComplemento.FolioComplementoPago(complementoPagoId, idEmpresa)
                                Dim aviso As String = objComplemento.Aviso
                                Dim respuesta As Int16 = objComplemento.Respuesta
                                If respuesta = 1 Then
                                    aviso = ""
                                    respuesta = 0
                                    objComplemento.CopiarDocumento()
                                    aviso = objComplemento.Aviso
                                    respuesta = objComplemento.Respuesta
                                    If respuesta = 1 Then
                                        'Process.Start(objtimbradoBU.RutaCliente)
                                        objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                                        objComplemento.GenerarPdfComplementoPago(complementoPagoId)
                                        respuesta = 0
                                        aviso = String.Empty
                                        respuesta = objComplemento.Respuesta
                                        aviso = objComplemento.Aviso
                                        If respuesta = 1 Then
                                            aviso = ""
                                            respuesta = 0
                                            objComplemento.CopiarDocumento()
                                            aviso = objComplemento.Aviso
                                            respuesta = objComplemento.Respuesta
                                            If respuesta = 1 Then
                                                show_message("Exito", aviso)
                                            Else
                                                MsgBox(aviso)
                                            End If
                                        Else
                                            MsgBox(aviso)
                                        End If
                                    Else
                                        MsgBox(aviso)
                                    End If
                                Else
                                    MsgBox(aviso)
                                End If
                            Else
                                show_message("Error", mensaje)
                            End If

                        Else
                            MsgBox("El procedimiento no arrojo niungun resultado.")
                        End If
                    End If
                Else
                    show_message(resultadoCancelacion.Rows(0).Item("Resultado").ToString(), resultadoCancelacion.Rows(0).Item("Mensaje").ToString())
                End If
            End If
        Else
            show_message("Advertencia", "Debe seleccionar un motivo de cancelación y capturar una observación para continuar.")
        End If

    End Sub

    Private Function Cancelacion_Complementoid(ByVal complementoPagoId As Integer) As Boolean
        Dim objComplemento As New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
        Dim aviso As String = String.Empty
        Dim respuesta As Int16 = 0
        Try
            objComplemento.folioComplementoPago_cancelacion(complementoPagoId)
            aviso = objComplemento.Aviso
            respuesta = objComplemento.Respuesta
            If respuesta = 1 Then
                aviso = ""
                respuesta = 0
                objComplemento.CopiarDocumento()
                aviso = objComplemento.Aviso
                respuesta = objComplemento.Respuesta
                If respuesta = 1 Then
                    'Process.Start(objtimbradoBU.RutaCliente)
                    objComplemento = New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                    objComplemento.GenerarPdfComplementoPagoCancelacion(complementoPagoId)
                    respuesta = 0
                    aviso = String.Empty
                    respuesta = objComplemento.Respuesta
                    aviso = objComplemento.Aviso
                    If respuesta = 1 Then
                        aviso = ""
                        respuesta = 0
                        objComplemento.CopiarDocumento()
                        aviso = objComplemento.Aviso
                        respuesta = objComplemento.Respuesta
                        If respuesta = 1 Then
                            show_message("Exito", aviso)
                        Else
                            ErrorCancelacion = aviso
                        End If
                    Else
                        ErrorCancelacion = aviso
                    End If
                Else
                    ErrorCancelacion = aviso
                End If
            Else
                ErrorCancelacion = aviso
            End If
        Catch ex As Exception
            respuesta = 0
            ErrorCancelacion = ex.Message.ToString()
        End Try
        Return IIf(respuesta = 0, False, True)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
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


        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

    End Sub

    Private Sub CancelacionComplementoRecepcionPagos_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If Guardando = 1 Then
            e.Cancel = True
            Guardando = 0
        End If

    End Sub

    Private Sub CancelacionComplementoRecepcionPagos_Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If btnGuardarCancelacion.Enabled = False Then
            ventanaAdministradorCRP.ActualizarAdministradorCRP()
        End If
    End Sub

End Class