Imports Tools
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.Windows.Forms
Imports Framework.Negocios

Public Class AutorizacionAltaIMSSForm

    Public Sub limpiarCampos()
        txtNombre.Text = ""
        cmbNave.SelectedIndex = 0
        grdColaboradoresAut.DataSource = Nothing
        ''100 id estatus solicitado
        cmbEstatus.SelectedValue = 100
    End Sub

    Public Sub cargarDatosIniciales()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbNave.SelectedIndex() = 1

        Dim objBu As New Negocios.UtileriasBU
        Dim dtEstatus As New DataTable
        dtEstatus = objBu.consultaListadoEstatus("ALTAIMSS")
        If dtEstatus.Rows.Count > 0 Then
            cmbEstatus.DataSource = dtEstatus
            cmbEstatus.DisplayMember = "estatus"
            cmbEstatus.ValueMember = "id"
            cmbEstatus.SelectedValue = 100
        End If

        If cmbNave.SelectedValue <> 0 Then
            consultarDatosPorAutorizar()
        End If
    End Sub

    Public Sub consultarDatosPorAutorizar()
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtAutorizar As New DataTable
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        dtAutorizar = objBu.consultaAltasImssPorAutorizar(cmbNave.SelectedValue, cmbEstatus.SelectedValue, txtNombre.Text)

        grdColaboradoresAut.DataSource = Nothing

        If Not dtAutorizar Is Nothing Then
            If dtAutorizar.Rows.Count > 0 Then
                grdColaboradoresAut.DataSource = dtAutorizar
                formatoGrid()
            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub formatoGrid()
        With grdColaboradoresAut.DisplayLayout.Bands(0)

            .Columns("idColaborador").Hidden = True
            .Columns("idAlta").Hidden = True
            .Columns("rojo").Hidden = True
            .Columns("sdiPuesto").Hidden = True
            .Columns("estatus").Hidden = True
            .Columns("umfId").Hidden = True
            .Columns("patronId").Hidden = True
            .Columns("patron").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("apaterno").Header.Caption = "A.Paterno"
            .Columns("aMaterno").Header.Caption = "A.Materno"
            .Columns("nombre").Header.Caption = "Nombre"
            .Columns("curp").Header.Caption = "Curp"
            .Columns("rfc").Header.Caption = "RFC"
            .Columns("nss").Header.Caption = "NSS"
            .Columns("diasantiguedad").Header.Caption = "Días Antiguedad"
            .Columns("puesto").Header.Caption = "Puesto"
            .Columns("sdi").Header.Caption = "SDI"


            .Columns("apaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("aMaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("curp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasantiguedad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sdi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("sdi").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasantiguedad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("sdi").Format = "###,###,##0.00"
            '.Columns("diasantiguedad").Format = "###,###,##0.00"

            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdColaboradoresAut.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdColaboradoresAut.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradoresAut.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradoresAut.DisplayLayout.Override.RowSelectorWidth = 35
        grdColaboradoresAut.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdColaboradoresAut.Rows(0).Selected = True

        'grdSolicitudes.DisplayLayout.Bands(0).Columns("estDsn").Width = 20
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("Seleccion").Width = 20
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaEntrega").Width = 50
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdColaboradoresAut.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("AUT_ALTAIMSS", "AUT_RECHAZAR") Then
            pnlAltas.Visible = True
            pnlRechazar.Visible = True
        Else
            pnlAltas.Visible = False
            pnlRechazar.Visible = False
        End If
    End Sub

    Public Sub editarAltaImss()
        Dim alta As New CompletarAltaColaboradorIMSSForm
        Dim dtEditar As New DataTable

        dtEditar.Columns.Add("seleccion")
        dtEditar.Columns.Add("idColaborador")
        dtEditar.Columns.Add("aPaterno")
        dtEditar.Columns.Add("aMaterno")
        dtEditar.Columns.Add("nombre")
        dtEditar.Columns.Add("curp")
        dtEditar.Columns.Add("rfc")
        dtEditar.Columns.Add("nss")
        dtEditar.Columns.Add("diasAntiguedad")
        dtEditar.Columns.Add("puesto")
        dtEditar.Columns.Add("sdi")
        dtEditar.Columns.Add("umfId")
        dtEditar.Columns.Add("patronId")
        dtEditar.Columns.Add("patron")

        Dim filaCol As DataRow = dtEditar.NewRow

        filaCol.Item("seleccion") = "false"
        filaCol.Item("idColaborador") = grdColaboradoresAut.ActiveRow.Cells("idColaborador").Value()
        filaCol.Item("aPaterno") = grdColaboradoresAut.ActiveRow.Cells("apaterno").Value()
        filaCol.Item("aMaterno") = grdColaboradoresAut.ActiveRow.Cells("amaterno").Value()
        filaCol.Item("nombre") = grdColaboradoresAut.ActiveRow.Cells("nombre").Value()
        filaCol.Item("curp") = grdColaboradoresAut.ActiveRow.Cells("curp").Value()
        filaCol.Item("rfc") = grdColaboradoresAut.ActiveRow.Cells("rfc").Value()
        filaCol.Item("nss") = grdColaboradoresAut.ActiveRow.Cells("nss").Value()
        filaCol.Item("diasAntiguedad") = grdColaboradoresAut.ActiveRow.Cells("diasAntiguedad").Value()
        filaCol.Item("puesto") = grdColaboradoresAut.ActiveRow.Cells("puesto").Value()
        filaCol.Item("sdi") = grdColaboradoresAut.ActiveRow.Cells("sdi").Value()
        filaCol.Item("umfId") = grdColaboradoresAut.ActiveRow.Cells("umfId").Value()
        filaCol.Item("patronId") = grdColaboradoresAut.ActiveRow.Cells("patronId").Value()
        filaCol.Item("patron") = grdColaboradoresAut.ActiveRow.Cells("patron").Value()

        dtEditar.Rows.Add(filaCol)

        alta.dtColabo = dtEditar
        alta.editaridColaborador = grdColaboradoresAut.ActiveRow.Cells("idColaborador").Value()
        alta.idAlta = grdColaboradoresAut.ActiveRow.Cells("idAlta").Value()
        alta.ShowDialog()
        consultarDatosPorAutorizar()
    End Sub

    Public Sub autorizarSolicitudes()
        Dim countReg As Int32 = 0
        Dim mensajeConfirmacionSDI As New ConfirmarForm
        Dim idAlta As Int32 = 0
        Dim idColaborador As Int32 = 0
        Dim objAut As New Negocios.ColaboradoresContabilidadBU
        Dim dtAutorizar As New DataTable
        Dim bandera As Boolean = True
        Dim guardados As Int32 = 0
        Dim autorizados As Int32 = 0
        Dim estatus As String = String.Empty

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        For Each rowGr As UltraGridRow In grdColaboradoresAut.Rows
            If CBool(rowGr.Cells("Seleccion").Value) = True Then
                countReg = countReg + 1
            End If
            If rowGr.Cells("estatus").Value <> "SOLICITADO" Then
                autorizados += 1
                estatus = rowGr.Cells("estatus").Value
            End If
        Next

        Dim mensajeConfirmacion As New ConfirmarForm
        If countReg > 1 Then
            mensajeConfirmacion.mensaje = "¿Está seguro de autorizar los " + countReg.ToString + " registros seleccionados? No podrá revertir este proceso"
        Else
            mensajeConfirmacion.mensaje = "¿Está seguro de autorizar el registro seleccionado? No podrá revertir este proceso"
        End If

        If autorizados = 0 And countReg > 0 Then
            If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                For Each rowGr As UltraGridRow In grdColaboradoresAut.Rows
                    If CBool(rowGr.Cells("Seleccion").Value) = True Then
                        objAut = New Negocios.ColaboradoresContabilidadBU

                        idAlta = rowGr.Cells("idAlta").Value
                        idColaborador = rowGr.Cells("idColaborador").Value

                        If CDbl(rowGr.Cells("sdi").Value) > CDbl(rowGr.Cells("sdiPuesto").Value) Then
                            Dim nombre As String = String.Empty
                            nombre = rowGr.Cells("apaterno").Value + " " + rowGr.Cells("amaterno").Value + " " + rowGr.Cells("nombre").Value
                            mensajeConfirmacionSDI.mensaje = "El colaborador " + nombre + " excede el SDI establecido para su puesto (" + CStr(rowGr.Cells("sdiPuesto").Value).ToString + "). ¿Esta seguro que quiere autorizar ese registro?"
                            If mensajeConfirmacionSDI.ShowDialog = Windows.Forms.DialogResult.OK Then
                                ''autorizar
                                dtAutorizar = objAut.autorizarAltaImss(CInt(rowGr.Cells("idColaborador").Value), CInt(rowGr.Cells("idAlta").Value), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                If dtAutorizar.Rows.Count > 0 Then
                                    If dtAutorizar.Rows(0).Item("resul") = "ERROR" Then
                                        bandera = False
                                    End If
                                End If
                                guardados = guardados + 1
                            End If
                        Else
                            ''autorizar
                            dtAutorizar = objAut.autorizarAltaImss(CInt(rowGr.Cells("idColaborador").Value), CInt(rowGr.Cells("idAlta").Value), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            If dtAutorizar.Rows.Count > 0 Then
                                If dtAutorizar.Rows(0).Item("resul") = "ERROR" Then
                                    bandera = False
                                End If
                            End If
                            guardados = guardados + 1
                        End If

                    End If
                Next

                If bandera = True And guardados <> 0 Then
                    Dim exito As New ExitoForm
                    exito.mensaje = "Se autorizaron correctamente las solicitudes"
                    exito.ShowDialog()
                    consultarDatosPorAutorizar()
                ElseIf bandera = False Then
                    Dim advertencia As New AdvertenciaForm
                    advertencia.mensaje = "Algo surgió mal durante el proceso, favor de intentar nuevamente"
                    advertencia.ShowDialog()
                End If
            End If
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "No es posible autorizar solicitudes en estatus " + estatus
            advertencia.ShowDialog()
        End If


        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub rechazarSolicitudes()
        Dim rechazado As Int32 = 0
        Dim countReg As Int32 = 0
        Dim estatus As String = String.Empty
        Dim bandera As Boolean = True

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        For Each rowGr As UltraGridRow In grdColaboradoresAut.Rows
            If CBool(rowGr.Cells("Seleccion").Value) = True Then
                countReg = countReg + 1
            End If
            If rowGr.Cells("estatus").Value <> "SOLICITADO" Then
                rechazado += 1
                estatus = rowGr.Cells("estatus").Value
            End If
        Next

        Dim mensajeConfirmacion As New ConfirmarForm
        If countReg > 1 Then
            mensajeConfirmacion.mensaje = "¿Está seguro de rechazar los " + countReg.ToString + " registros seleccionados? No podrá revertir este proceso"
        Else
            mensajeConfirmacion.mensaje = "¿Está seguro de rechazar el registro seleccionado? No podrá revertir este proceso"
        End If

        If rechazado = 0 Then
            If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim motivo As String = String.Empty
                Dim formMotivo As New MotivoRechazoForm
                formMotivo.ShowDialog()
                motivo = formMotivo.motivo

                If motivo.Trim = "" Then
                    Dim objMensajeAdv As New Tools.AdvertenciaForm
                    objMensajeAdv.mensaje = "No se RECHAZARON las solicitudes debido a que no se ingresó el motivo de regreso."
                    objMensajeAdv.ShowDialog()
                    Exit Sub
                End If

                For Each rowGr As UltraGridRow In grdColaboradoresAut.Rows
                    If CBool(rowGr.Cells("Seleccion").Value) = True Then
                        Dim objBu As New Negocios.ColaboradoresContabilidadBU
                        Dim dtRechazar As New DataTable

                        dtRechazar = objBu.rechazarAltaImss(CInt(rowGr.Cells("idColaborador").Value), CInt(rowGr.Cells("idAlta").Value), motivo, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                        If dtRechazar.Rows.Count > 0 Then
                            If dtRechazar.Rows(0).Item("resul") = "ERROR" Then
                                bandera = False
                            End If
                        End If
                    End If
                Next

                If bandera = True Then
                    Dim exito As New ExitoForm
                    exito.mensaje = "Se rechazaron correctamente las solicitudes"
                    exito.ShowDialog()
                    consultarDatosPorAutorizar()
                ElseIf bandera = False Then
                    Dim advertencia As New AdvertenciaForm
                    advertencia.mensaje = "Algo surgió mal durante el proceso, favor de intentar nuevamente"
                    advertencia.ShowDialog()
                End If
            End If
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "No es posible rechazar solicitudes en estatus " + estatus
            advertencia.ShowDialog()

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdColaboradoresAut.Height = 471
        grdColaboradoresAut.Top = 115
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 99
        grdColaboradoresAut.Height = 346
        grdColaboradoresAut.Top = 240
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        limpiarCampos()
    End Sub

    Private Sub AutorizacionAltaIMSSForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        cargarDatosIniciales()
        configurarPermisosBotonesEspeciales()
    End Sub

    Private Sub grdColaboradoresAut_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdColaboradoresAut.DoubleClickCell
        editarAltaImss()
    End Sub

    Private Sub grdColaboradoresAut_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdColaboradoresAut.InitializeRow
        If e.Row.Cells("rojo").Value = 1 Then
            e.Row.Cells("sdi").Appearance.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        If cmbNave.SelectedIndex <> 0 Then
            consultarDatosPorAutorizar()
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Selecciona una nave"
            advertencia.ShowDialog()
        End If

    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            consultarDatosPorAutorizar()
        End If
    End Sub


    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        autorizarSolicitudes()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        rechazarSolicitudes()
    End Sub
End Class