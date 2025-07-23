Imports DevExpress.Utils.Menu
Imports Produccion.Negocios
Imports Tools
Imports Tools.modMensajes

Public Class AvancesProduccion_CapturaMotivoRestraso_Form
    Private ReadOnly objSalidaLoteSuelaBU As New RegistroSuelaTerminadaBU
    Private UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

    Private Sub ConsultarInformacion()
        Try
            If cmbNave.EditValue Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar una nave.")
                Return
            End If

            If cmbDepartamento.EditValue Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar un departamento.")
                Return
            End If
            Tools.MostrarEspere(Me)
            Dim dtFoliosSalidaSuela = objSalidaLoteSuelaBU.ConsultarLotesPendientesDepartamentoNave(cmbNave.EditValue, cmbDepartamento.EditValue)
            Tools.TerminarEspere(Me)
            grdLotesPendientes.DataSource = Nothing
            If dtFoliosSalidaSuela.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se encontró información con los filtros seleccionados.")
                Return
            End If
            grdLotesPendientes.DataSource = dtFoliosSalidaSuela
            lblRegistros.Text = Val(dtFoliosSalidaSuela.Rows.Count).ToString("N0")
            lblUltimaDistribucion.Text = Date.Now
            DiseñoGrid.AlternarColorEnFilas(grvLotesPendientes)
            grvLotesPendientes.BestFitColumns()
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub grvLotesPendientes_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grvLotesPendientes.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Row Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewMenu = TryCast(e.Menu, DevExpress.XtraGrid.Menu.GridViewMenu)
            menu.Items.Add(New DXMenuItem("HERRAMENTALES", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("MATERIALES", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("SUELAS", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("SINTETICOS", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("FORRO", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("SERIGRAFIA", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("PERSONAL", AddressOf OpcionElegidaMenu))
            menu.Items.Add(New DXMenuItem("N/A", AddressOf OpcionElegidaMenu))
        End If
    End Sub
    Private Sub OpcionElegidaMenu(ByVal sender As Object, ByVal e As EventArgs)
        Dim menuItem As DXMenuItem = TryCast(sender, DXMenuItem)
        Dim menuSeleccionado As String = menuItem.Caption
        Dim seleccionadosRowHandles As Int32() = grvLotesPendientes.GetSelectedRows()
        For index = 0 To seleccionadosRowHandles.Length - 1
            grvLotesPendientes.SetRowCellValue(seleccionadosRowHandles(index), cMotivo, menuSeleccionado)
        Next
    End Sub

    Private Sub grvLotesPendientes_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grvLotesPendientes.CustomDrawCell
        If e.RowHandle < 0 Or e.Column.FieldName <> cMotivo.FieldName Then
            Return
        End If

        If e.CellValue <> grvLotesPendientes.GetDataRow(e.RowHandle)("MotivoRespaldo") Then
            e.Appearance.ForeColor = lblDatosEditados.ForeColor
        End If

        If e.CellValue = "N/A" Then
            e.Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If cmbNave.EditValue Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar una nave.")
                Return
            End If

            If cmbDepartamento.EditValue Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar un departamento.")
                Return
            End If

            Dim dtLotesMotivosActualizados As DataTable = grdLotesPendientes.DataSource
            If dtLotesMotivosActualizados.Select("Motivo <> MotivoRespaldo").Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se ha actualizado ningun registro.")
                Return
            End If
            dtLotesMotivosActualizados = dtLotesMotivosActualizados.Select("Motivo <> MotivoRespaldo").CopyToDataTable
            Dim xmlLotesActualizados As XElement = New XElement("Celdas")
            With dtLotesMotivosActualizados
                For index = 0 To .Rows.Count - 1
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("Lote", .Rows(index)("Lote")))
                    vNodo.Add(New XAttribute("Año", .Rows(index)("Año")))
                    vNodo.Add(New XAttribute("NaveID", .Rows(index)("Nave")))
                    vNodo.Add(New XAttribute("Motivo", .Rows(index)("Motivo")))
                    vNodo.Add(New XAttribute("DepartamentoID", cmbDepartamento.EditValue))
                    xmlLotesActualizados.Add(vNodo)
                Next
            End With
            Dim vConfirmarForm As New ConfirmarForm
            Dim vDialogResult As New DialogResult
            vConfirmarForm.Text = "Motivo Atraso"
            vConfirmarForm.mensaje = "¿Estas seguro de guardar los motivos de los lotes?"
            vDialogResult = vConfirmarForm.ShowDialog
            If Not vDialogResult = Windows.Forms.DialogResult.OK Then
                Return
            End If
            Tools.MostrarEspere(Me)
            objSalidaLoteSuelaBU.ActualizarMotivoAtraso(xmlLotesActualizados.ToString, UsuarioID)
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Success, "Información actualizada correctamente")
            ConsultarInformacion()
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub AvancesProduccion_CapturaMotivoRestraso_Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LlenarComboNaves()
    End Sub

    Private Sub LlenarComboNaves()
        Try
            Tools.MostrarEspere(Me)
            Dim dtNaves As DataTable = objSalidaLoteSuelaBU.ConsultarNaves(UsuarioID)
            Tools.TerminarEspere(Me)
            If dtNaves.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No cuenta con ninguna nave asignada para la captura de motivos.")
                Close()
                Return
            End If
            cmbNave.Properties.DataSource = dtNaves
            If dtNaves.Rows.Count > 1 Then
                Return
            End If
            cmbNave.EditValue = dtNaves.Rows(0)("NaveID")
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub cmbNave_EditValueChanged(sender As Object, e As EventArgs) Handles cmbNave.EditValueChanged
        LlenarComboDepartamento()
    End Sub
    Private Sub LlenarComboDepartamento()
        Try
            If cmbNave.EditValue Is Nothing Then
                cmbDepartamento.Properties.DataSource = Nothing
                cmbDepartamento.EditValue = Nothing
                Return
            End If
            Tools.MostrarEspere(Me)
            Dim dtDepartamento As DataTable = objSalidaLoteSuelaBU.ConsultarDepartamentosConfiguracionNave(cmbNave.EditValue)
            Tools.TerminarEspere(Me)
            If dtDepartamento.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No cuenta con ninguna departamento asignado para la captura de motivos.")
                Close()
                Return
            End If
            cmbDepartamento.Properties.DataSource = dtDepartamento
            If dtDepartamento.Rows.Count > 1 Then
                Return
            End If
            cmbDepartamento.Enabled = False
            cmbDepartamento.EditValue = dtDepartamento.Rows(0)("NaveID")
            ConsultarInformacion()
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        ConsultarInformacion()
    End Sub

    Private Sub AvancesProduccion_CapturaMotivoRestraso_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            ConsultarInformacion()
        End If
    End Sub
End Class