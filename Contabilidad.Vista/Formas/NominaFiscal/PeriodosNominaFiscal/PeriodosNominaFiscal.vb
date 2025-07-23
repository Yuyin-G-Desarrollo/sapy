Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.Drawing
Imports Framework.Negocios

Public Class PeriodosNominaFiscal

    Private Sub PeriodosNominaFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        cargarPatrones()
        iniciarFechas()
        obtenerListaEstatus()

        pnlAltas.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_PERIODOS", "ALTA")
        pnlEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_PERIODOS", "EDITAR")
        pnlEliminar.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_PERIODOS", "ELIMINAR")

        'Permisos menú 
        PeriodosNFArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_PERIODOS", "MODIF_WORD_PNF")
        PeriodosNFPropuestaToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_PERIODOS", "PROPUESTA_PNF")

    End Sub

    Private Sub cargarPatrones()
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim dtPatrones As New DataTable

        dtPatrones = objBU.cargarPatrones
        If dtPatrones.Rows.Count > 0 Then
            cmbPatron.DataSource = dtPatrones
            cmbPatron.DisplayMember = "PATRON"
            cmbPatron.ValueMember = "ID"
        End If

    End Sub

    Private Sub obtenerListaEstatus()
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim dtEstatus As New DataTable

        dtEstatus = objBU.obtenerListaEstatus
        If dtEstatus.Rows.Count > 0 Then
            dtEstatus.Rows.InsertAt(dtEstatus.NewRow, 0)
            cmbEstatus.DataSource = dtEstatus
            cmbEstatus.DisplayMember = "nombre"
            cmbEstatus.ValueMember = "estatusid"
        End If

    End Sub

    Private Sub iniciarFechas()
        dtpFechaInicio.Value = Date.Today
        dtpFechaFin.Value = DateAdd(DateInterval.Day, 7, Date.Today)
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objForm As New AltasPeriodosNominaFiscal
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltasPeriodosNominaFiscal
            formaAltas.ShowDialog()

            If formaAltas.guardado Then
                llenarGrid()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarGrid()
    End Sub

    Private Sub llenarGrid()
        If cmbPatron.SelectedIndex > 0 Then
            Dim objBU As New Negocios.PeriodosNominaFiscalBU
            Dim dtPeriodos As New DataTable
            Dim estatus As Integer

            If IsDBNull(cmbEstatus.SelectedValue) Then
                estatus = 0
            Else
                estatus = cmbEstatus.SelectedValue
            End If

            dtPeriodos = objBU.consultarPeriodos(cmbPatron.SelectedValue, dtpFechaInicio.Value, dtpFechaFin.Value, estatus)
            grdPeriodos.DataSource = Nothing

            If dtPeriodos.Rows.Count > 0 Then
                grdPeriodos.DataSource = dtPeriodos
                formatoGrid()
            Else
                Dim mensajeAdv As New Tools.AdvertenciaForm
                mensajeAdv.mensaje = "La consulta no devolvió ningún resultado."
                mensajeAdv.ShowDialog()
            End If
        Else
            Dim mensajeAdv As New Tools.AdvertenciaForm
            mensajeAdv.mensaje = "Debe de seleccionar un patrón"
            mensajeAdv.ShowDialog()
        End If
    End Sub

    Public Sub formatoGrid()
        grdPeriodos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdPeriodos.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

        With grdPeriodos.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.RowSelect

            .Columns("penof_periodonominafiscalId").Hidden = True
            .Columns("penof_estatusId").Hidden = True
            .Columns("penof_periodonominafiscalId").Hidden = True
            .Columns("penof_faltasRetPermitidos").Hidden = True
            .Columns("penof_incapacidadesPermitidas").Hidden = True

            .Columns("penof_fechaInicial").Header.Caption = "Fecha Inicio"
            .Columns("penof_fechaFinal").Header.Caption = "Fecha Fin"
            .Columns("penof_diaslaborados").Header.Caption = "Días Nómina"
            .Columns("penof_fechaPago").Header.Caption = "Fecha Pago"
            .Columns("penof_anio").Header.Caption = "Año"
            .Columns("penof_numerosemana").Header.Caption = "Semana"
            .Columns("esta_nombre").Header.Caption = "Estatus"
            .Columns("usuariocreo").Header.Caption = "Usuario Creo"
            .Columns("penof_fechaCreacion").Header.Caption = "Fecha Creación"
            .Columns("penof_retardosPermitidos").Header.Caption = "Retardos"
            '.Columns("penof_faltasRetPermitidos").Header.Caption = "Faltas Retardo"
            .Columns("penof_faltasPermitidas").Header.Caption = "Faltas"
            '.Columns("penof_incapacidadesPermitidas").Header.Caption = "Incapacidad"
            .Columns("penof_diasFaltasCompletas").Header.Caption = "Faltas Semana"
            .Columns("penof_bimestre").Header.Caption = "Bimestre"

            .Columns("penof_diaslaborados").CellAppearance.TextHAlign = HAlign.Right
            .Columns("penof_retardosPermitidos").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("penof_faltasRetPermitidos").CellAppearance.TextHAlign = HAlign.Right
            .Columns("penof_faltasPermitidas").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("penof_incapacidadesPermitidas").CellAppearance.TextHAlign = HAlign.Right
            .Columns("penof_diasFaltasCompletas").CellAppearance.TextHAlign = HAlign.Right
            .Columns("penof_bimestre").CellAppearance.TextHAlign = HAlign.Right

            .Columns("penof_fechaCreacion").Format = "dd/MM/yyyy HH:mm"

        End With

        grdPeriodos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdPeriodos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPeriodos.DisplayLayout.Override.RowSelectorWidth = 35
        grdPeriodos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdPeriodos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdPeriodos.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.IncludeHeader)
        grdPeriodos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPeriodos.DisplayLayout.Bands(0).Columns("esta_nombre").Width = 80

        Me.grdPeriodos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPeriodos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdPeriodos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPeriodos.DataSource = Nothing
        iniciarFechas()
        cmbEstatus.SelectedIndex = 0
        cmbPatron.SelectedIndex = 0
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objAdvertencias As New Tools.AdvertenciaForm

        If grdPeriodos.Selected.Rows.Count > 1 Then
            objAdvertencias.mensaje = "Seleccione solo un registro para poder editarlo."
            objAdvertencias.ShowDialog()
        ElseIf grdPeriodos.Selected.Rows.Count = 0 Then
            objAdvertencias.mensaje = "Seleccione un registro para poder editarlo."
            objAdvertencias.ShowDialog()
        ElseIf IsDBNull(grdPeriodos.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value) = False And IsDBNull(grdPeriodos.Selected.Rows(0).Cells("esta_nombre").Value) = False Then


            If grdPeriodos.Selected.Rows(0).Cells("esta_nombre").Value = "CERRADO" Then
                objAdvertencias.mensaje = "No es posible editar un periodo en estatus CERRADO."
                objAdvertencias.ShowDialog()
            Else
                Dim objBU As New Negocios.PeriodosNominaFiscalBU

                If objBU.validaEstatusPeriodo(CInt(grdPeriodos.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value)) Then
                    Dim objForm As New EditarPeriodosNominaFiscal
                    If Not CheckForm(objForm) Then

                        Dim frmEditar As New EditarPeriodosNominaFiscal
                        frmEditar.idPeriodo = CInt(grdPeriodos.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value)
                        frmEditar.ShowDialog()

                        If frmEditar.guardado Then
                            llenarGrid()
                        End If
                    End If
                Else
                    objAdvertencias.mensaje = "El periodo de asistencia ya ha sido cerrado, no es posible editar el registro seleccionado."
                    objAdvertencias.ShowDialog()
                End If
            End If
        Else
            Dim objError As New Tools.ErroresForm
            objError.mensaje = "No es posible editar el registro seleccionado."
            objError.ShowDialog()

        End If

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim objAdvertencias As New Tools.AdvertenciaForm
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim mensaje As String = String.Empty

        If grdPeriodos.Selected.Rows.Count = 0 Then
            objAdvertencias.mensaje = "Seleccione al menos un registro para eliminarlo."
            objAdvertencias.ShowDialog()
        ElseIf grdPeriodos.Selected.Rows.Count > 0 Then
            Dim mensajeConf As New Tools.ConfirmarForm
            mensajeConf.mensaje = "El periodo debe estar en estatus BLOQUEADO para poder ser eliminado. ¿Está seguro de continuar?."

            If mensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim periodoseliminar As Integer = 0
                Dim periodoseliminados As Integer = 0

                For Each row As UltraGridRow In grdPeriodos.Selected.Rows
                    periodoseliminar += 1
                    If IsDBNull(grdPeriodos.Selected.Rows(0).Cells("penof_periodonominafiscalId").Value) = False Then
                        mensaje = String.Empty
                        mensaje = objBU.EliminarPeriodo(CInt(row.Cells("penof_periodonominafiscalId").Value))
                        If mensaje = "EXITO" Then
                            periodoseliminados += 1
                        End If
                    End If
                Next

                If periodoseliminados = periodoseliminar Then
                    Dim mensajeExito As New Tools.ExitoForm
                    If periodoseliminar > 1 Then
                        mensajeExito.mensaje = "Los periodos fueron eliminados correctamente."
                    Else
                        mensajeExito.mensaje = "El periodo fue eliminado correctamente."
                    End If
                    mensajeExito.ShowDialog()
                Else
                    Dim mensajeError As New Tools.ErroresForm
                    If periodoseliminar > 1 Then
                        mensajeError.mensaje = "Algunos periodos no fueron eliminados."
                    Else
                        If grdPeriodos.Selected.Rows(0).Cells("esta_nombre").Value <> "BLOQUEADO" Then
                            mensajeError.mensaje = "No es posible eliminar el periodo ya que no está en estatus BLOQUEADO."
                        Else
                            mensajeError.mensaje = "El periodo no pudo ser eliminado."
                        End If


                    End If
                    mensajeError.ShowDialog()
                End If

                llenarGrid()

            End If
        End If

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaPeriodosNFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaPeriodosNFToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_PeridosNomina_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_PeridosNomina_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PeriodosNFArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeriodosNFArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_PeridosNomina_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_PeridosNomina_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PeriodosNFPropuestaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeriodosNFPropuestaToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "Contabilidad_SAY_PeridosNominaFiscal_Nov2019_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\Contabilidad_SAY_PeridosNominaFiscal_Nov2019_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub pnlEditar_Paint(sender As Object, e As PaintEventArgs) Handles pnlEditar.Paint

    End Sub
End Class