Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports Framework.Negocios
Imports Tools

Public Class ModificacionCreditoInfonavitForm
    Dim colaboradorIds As String = String.Empty
    Dim directorio As String = String.Empty
    Dim creditoInfonavit As New Entidades.CreditoInfonavit
    Dim editando As Boolean = False

    Private Sub ModificacionCreditoInfonavitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarComboNave()
        pnlCalcular.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_CRED_INF", "CALC_MOD_INF")
        pnlAutorizar.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_CRED_INF", "AUTORIZA_MOD_INF")
        pnlGuardar.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_CRED_INF", "GUARDA_MOD_INF")

    End Sub

    Private Sub llenarComboNave()
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

    Private Sub limpiar()
        editando = False
        vwDatos.Columns.Clear()
        grdDatos.DataSource = Nothing
        colaboradorIds = String.Empty
        pnlColCargados.Visible = False
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        cmbEmpresa.DataSource = Nothing
        limpiar()

        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbEmpresa.DataSource = dtEmpresa
                cmbEmpresa.DisplayMember = "Patron"
                cmbEmpresa.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbEmpresa.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        If cmbNave.Items.Count > 1 And cmbNave.SelectedIndex > 0 Then
            If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de seleccionar un Patrón.")
            Else
                Dim objForm As New SeleccionarColaboradoresForm
                If Not CheckForm(objForm) Then
                    objForm.colaboradorIds = colaboradorIds
                    objForm.patronId = cmbEmpresa.SelectedValue
                    objForm.ShowDialog()
                    colaboradorIds = String.Empty
                    colaboradorIds = objForm.colaboradorIds

                    If colaboradorIds <> "" Then
                        pnlColCargados.Visible = True
                    Else
                        pnlColCargados.Visible = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If validaAccionEnEdicion() = True Then
            limpiar()
            cmbNave.SelectedIndex = 0
        End If
    End Sub

    Private Function validaAccionEnEdicion() As Boolean
        Dim blnRealizar As Boolean = False

        If editando Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                blnRealizar = True
            End If
        Else
            blnRealizar = True
        End If

        Return blnRealizar
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If validaAccionEnEdicion() = True Then
            If cmbEmpresa.SelectedIndex > 0 Then
                Dim objBU As New Negocios.CreditoInfonavitBU
                Dim dtListado As New DataTable
                Dim naveId As Integer = 0
                Dim patronId As Integer = 0
                editando = False
                vwDatos.Columns.Clear()
                grdDatos.DataSource = Nothing

                naveId = CInt(cmbNave.SelectedValue)
                patronId = CInt(cmbEmpresa.SelectedValue)

                dtListado = objBU.obtenerListadoCreditosInfonavitModificar(naveId, patronId, colaboradorIds)
                If Not dtListado Is Nothing AndAlso dtListado.Rows.Count > 0 Then
                    grdDatos.DataSource = dtListado
                    disenioGrid()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron datos para mostrar.")
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario elegir una empresa para consultar la información.")
            End If
        End If
    End Sub

    Private Sub disenioGrid()
        DiseñoGrid.DiseñoBaseGrid(vwDatos)
        DiseñoGrid.AlternarColorEnFilas(vwDatos)
        vwDatos.BestFitColumns()
        vwDatos.OptionsView.ShowFooter = False

        If IsNothing(vwDatos.Columns.FirstOrDefault(Function(x) x.FieldName = "No.")) = True Then
            vwDatos.Columns.AddVisible("No.").UnboundType = DevExpress.Data.UnboundColumnType.Integer
            AddHandler vwDatos.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            vwDatos.Columns.Item("No.").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDatos.Columns
            If col.FieldName = "fecharecepcion" Or col.FieldName = "valordescuento" Or col.FieldName = "cargaracuse" Then
                col.OptionsColumn.AllowEdit = True
            Else
                col.OptionsColumn.AllowEdit = False
            End If

            Select Case col.FieldName
                Case "clave"
                    col.Width = 70
                    col.Caption = "Código Empleado"
                Case "colaborador"
                    col.Caption = "Colaborador"
                    col.Width = 320
                Case "cono_nss"
                    col.Caption = "NSS"
                Case "movimiento"
                    col.Caption = "Movimiento"
                     col.Width = 250
                Case "fecharecepcion"
                    col.Caption = "Fecha de Recepción"
                Case "fechamovimiento"
                    col.Caption = "Fecha de Movimiento"
                Case "numcredito"
                    col.Caption = "Número de Crédito"
                Case "tipodescuento"
                    col.Caption = "Tipo de Descuento"
                Case "valordescuento"
                    col.Caption = "Valor de Descuento"
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N2}"
                Case "nuevodescuento"
                    col.Caption = "Nuevo Descuento"
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N2}"
                Case "cargaracuse"
                    col.Caption = "Cargar Acuse"
                    col.Width = 50
                Case Else
                    If Not IsNothing(vwDatos.Columns.FirstOrDefault(Function(x) x.FieldName = "No.")) AndAlso col.FieldName = "No." Then
                        col.Visible = True
                        col.Width = 40
                    Else
                        col.Visible = False
                    End If
            End Select
        Next
        DiseñoGrid.AlinearTextoEncabezadoColumnas(vwDatos)
        AddGridColumnButton()
    End Sub

    Public Sub AddGridColumnButton()

        If vwDatos Is Nothing Then Exit Sub
        If vwDatos.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdDatos.RepositoryItems.Add(_RIButton)
        vwDatos.Columns("cargaracuse").ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        vwDatos.Columns("cargaracuse").UnboundType = DevExpress.Data.UnboundColumnType.Object
        vwDatos.Columns("cargaracuse").ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Image = My.Resources.arrow_up
        _RIButton.Buttons(0).Width = vwDatos.Columns("cargaracuse").Width - (vwDatos.Columns("cargaracuse").Width / 4) 'kha??

        AddHandler _RIButton.ButtonClick, AddressOf ColumnaCargarAcuse_Click

    End Sub

    Private Sub ColumnaCargarAcuse_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Try
            opfArchivoRetencion.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            opfArchivoRetencion.Filter = "PDF|*.pdf;"
            opfArchivoRetencion.FilterIndex = 3
            opfArchivoRetencion.ShowDialog()
            If opfArchivoRetencion.FileName <> "" Then
                Dim filaActual As Int64 = vwDatos.FocusedRowHandle
                'Dim strColaborador As String = String.Empty
                'strColaborador = vwDatos.GetRowCellValue(filaActual, "colaboradorid")
                vwDatos.SetRowCellValue(filaActual, "rutaarchivoretencion", opfArchivoRetencion.FileName)
                opfArchivoRetencion.FileName = ""
                'vwDatos.SetRowCellValue(filaActual, "rutaarchivoretencion", rutaAcuses & strColaborador & "/" & IO.Path.GetFileName(opfArchivoRetencion.FileName))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = vwDatos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub vwDatos_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwDatos.CellValueChanged
        If e.Column.FieldName = "fecharecepcion" Or e.Column.FieldName = "valordescuento" Then
            If Not IsDBNull(vwDatos.GetRowCellValue(e.RowHandle, "fecharecepcion")) AndAlso Not IsDBNull(vwDatos.GetRowCellValue(e.RowHandle, "valordescuento")) Then
                Try
                    If IsNumeric(vwDatos.GetRowCellValue(e.RowHandle, "tipodescuentoid")) Then
                        Dim objBU As New Negocios.CreditoInfonavitBU
                        Dim creditoInfonavit As New Entidades.CreditoInfonavit
                        Dim objCalcInfonavit As New CalculoInfonavit
                        Dim salarioBase As Double = 0
                        Dim valorDescuento As Double = 0
                        Dim fila As Integer = e.RowHandle
                        Dim patronId As Integer = 0
                        Dim fechaMovimiento As New Date

                        patronId = CDbl(vwDatos.GetRowCellValue(fila, "patronId"))
                        fechaMovimiento = objBU.obtenerFechaBimestreFecha(CDate(vwDatos.GetRowCellValue(e.RowHandle, "fecharecepcion")))
                        vwDatos.SetRowCellValue(e.RowHandle, "fechamovimiento", fechaMovimiento)

                        If IsNumeric(vwDatos.GetRowCellValue(fila, "valordescuento")) AndAlso IsNumeric(vwDatos.GetRowCellValue(fila, "salariobase")) Then
                            salarioBase = CDbl(vwDatos.GetRowCellValue(fila, "salarioBase"))
                            valorDescuento = CDbl(vwDatos.GetRowCellValue(fila, "valordescuento"))
                        End If

                        Select Case vwDatos.GetRowCellValue(e.RowHandle, "tipodescuentoid").ToString
                            Case "0"
                            Case "1" 'PORCENTAJE
                                creditoInfonavit = objCalcInfonavit.calcularDescuentoPorcentaje(salarioBase, valorDescuento, patronId, fechaMovimiento)
                            Case "2" 'CUOTAFIJA
                                creditoInfonavit = objCalcInfonavit.calcularDescuentoCoutaFija(valorDescuento, patronId, fechaMovimiento)
                            Case "3" 'VECES SALARIO MÍNIMO
                                creditoInfonavit = objCalcInfonavit.calcularDescuentoVecesSM(valorDescuento, patronId, fechaMovimiento)
                        End Select

                        'Asignar valores al grid 
                        vwDatos.SetRowCellValue(fila, "modci_salarioBimestral", creditoInfonavit.CISalarioBimestral)
                        vwDatos.SetRowCellValue(fila, "modci_importeretencionmensual", creditoInfonavit.CIImporteretencionmensual)
                        vwDatos.SetRowCellValue(fila, "modci_salarioMinimoDF", creditoInfonavit.CISalarioMinimoDF)
                        vwDatos.SetRowCellValue(fila, "modci_retencionMensual", creditoInfonavit.CIRetencionMensual)
                        vwDatos.SetRowCellValue(fila, "modci_importeretencionbimestral", creditoInfonavit.CIImporteretencionbimestral)
                        vwDatos.SetRowCellValue(fila, "modci_importeretenerbimestral", creditoInfonavit.CIImporteretenerbimestral)
                        vwDatos.SetRowCellValue(fila, "modci_seguroVivienda", creditoInfonavit.CISeguroVivienda)
                        vwDatos.SetRowCellValue(fila, "modci_retenciondiaria", creditoInfonavit.CIRetenciondiaria)
                        vwDatos.SetRowCellValue(fila, "modci_retencionsemanalfiscal", creditoInfonavit.CIRetencionsemanalfiscal)
                        vwDatos.SetRowCellValue(fila, "modci_semanasdescontaranual", creditoInfonavit.CISemanasdescontaranual)
                        vwDatos.SetRowCellValue(fila, "modci_numSemanaDescontar", creditoInfonavit.CINumSemDescontar)
                        vwDatos.SetRowCellValue(fila, "modci_descuentosemanal", creditoInfonavit.CIDescuentosemanal)
                        vwDatos.SetRowCellValue(fila, "nuevodescuento", creditoInfonavit.CIDescuentosemanal)

                        editando = True

                    End If
                Catch ex As Exception
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener los datos para el cálculo.")
                End Try
            End If
        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        If editando Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen registros en edición, no es posible autorizar ya que no se enviarán los datos actuales.")
        Else
            ' validr que todos los colaboradores tengan su archivo cargado
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If validaAccionEnEdicion() = True Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        limpiar()
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Try
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Si existen solicitudes no autorizadas para este patrón y nave se reemplazarán, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar la información.")
        End Try
    End Sub
End Class

