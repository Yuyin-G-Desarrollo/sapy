Imports Tools
Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Proveedores.BU
Imports Proveedores
Imports Stimulsoft.Report
Imports System.Drawing

Public Class OrdenesDeCompraForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Dim objDatelleRechazo As New Tools.NotificacionConTextAreaForm

    Public idOc As Integer

    Private Sub OrdenesDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarListasNaves()
        permisos()
    End Sub

    Public Sub permisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV_OC", "AUTORIZAR") Then
        Else
            btnAutorizar.Visible = False
            lblAutorizar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV_OC", "RECHAZAR") Then
        Else
            btnRechazar.Visible = False
            lblRechazar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV_OC", "CANCELAR") Then
        Else
            btnCancelar.Visible = False
            lblCancelar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CAT_PROV_OC", "EDITAR") Then
        Else
            btnEditar.Visible = False
            lblEditar.Visible = False
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim captura As New CapturaOrdenesDeCompraForm
        If captura.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Public Sub LlenarListasNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub cmbEstatus_SelectedIndexChanged(sender As Object, e As EventArgs)
        colorearItemCombo()
    End Sub

    Public Sub colorearItemCombo()
        If cmbEstatus.Text = "CAPTURADA" Then
            cmbEstatus.BackColor = System.Drawing.Color.SandyBrown
        ElseIf cmbEstatus.Text = "AUTORIZADA" Then
            cmbEstatus.BackColor = System.Drawing.Color.PowderBlue
        ElseIf cmbEstatus.Text = "RECHAZADA" Then
            cmbEstatus.BackColor = System.Drawing.Color.OrangeRed
        ElseIf cmbEstatus.Text = "CANCELADA" Then
            cmbEstatus.BackColor = System.Drawing.Color.Salmon
        ElseIf cmbEstatus.Text = "POR SURTIR" Then
            cmbEstatus.BackColor = System.Drawing.Color.Sienna
        ElseIf cmbEstatus.Text = "PARCIAL SURTIDA" Then
            cmbEstatus.BackColor = System.Drawing.Color.MediumPurple
        ElseIf cmbEstatus.Text = "SURTIDA" Then
            cmbEstatus.BackColor = System.Drawing.Color.LightGray
        End If
    End Sub

    Public Sub limpiar()
        txtFolio.Text = ""
        cmbEstatus.SelectedValue = 0
        cmbNave.SelectedValue = 0
        dtpAl.Value = DateTime.Now.ToString("dd/MM/yyyy")
        dtpDel.Value = DateTime.Now.ToString("dd/MM/yyyy")
        grdOrdenesdeCompra.DataSource = Nothing
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Public Sub consultaGeneral(ByVal idnave As Int32, ByVal del As Date, ByVal al As Date, ByVal anio As Integer)
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable
        lsta = obj.consultaGeneral(idnave, del, al, anio)
        grdOrdenesdeCompra.DataSource = lsta
    End Sub

    Public Sub consulta1(ByVal idnave As Int32, ByVal del As Date, ByVal al As String, ByVal anio As String, ByVal busca As String)
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable
        lsta = obj.consulta1(idnave, del, al, anio, busca)
        grdOrdenesdeCompra.DataSource = lsta
    End Sub

    Public Sub consultaConEstatus(ByVal idnave As Int32, ByVal del As Date, ByVal al As Date, ByVal anio As Integer, ByVal estatus As String)
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable
        lsta = obj.consultaConEstatus(idnave, del, al, anio, estatus)
        grdOrdenesdeCompra.DataSource = lsta
    End Sub

    Public Sub consultaConFolio(ByVal idnave As Int32, ByVal anio As Integer, ByVal folio As Integer)
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable
        lsta = obj.consultaConFolio(idnave, anio, folio)
        grdOrdenesdeCompra.DataSource = lsta
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNave.SelectedValue = 0 Then
            objAdvertencia.mensaje = "Debe seleccionar una nave."
            objAdvertencia.ShowDialog()
        Else
            btnBuscar()
        End If

    End Sub

    Public Sub btnBuscar()
        Dim idnave, anio As Integer
        Dim del, dell, al, all As String

        idnave = cmbNave.SelectedValue
        anio = DateTime.Now.ToString("yyyy")
        dell = dtpDel.Value.Date
        all = dtpAl.Value.Date
        del = dell.ToString.ToUpper.Trim.Replace("0:00:00", "")
        al = all.ToString.ToUpper.Trim.Replace("0:00:00", "")

        If cmbEstatus.Text = "" Then
            consultaGeneral(idnave, del, al, anio)
            disenioGrid()
        End If

        If cmbEstatus.Text <> "" Then
            Dim estatus As String
            If cmbEstatus.Text = "CAPTURADA" Then
                estatus = "C"
            End If
            If cmbEstatus.Text = "AUTORIZADA" Then
                estatus = "A"
            End If
            If cmbEstatus.Text = "RECHAZADA" Then
                estatus = "R"
            End If
            If cmbEstatus.Text = "CANCELADA" Then
                estatus = "X"
            End If
            If cmbEstatus.Text = "POR SURTIR" Then
                estatus = "P"
            End If
            If cmbEstatus.Text = "PARCIAL SURTIDA" Then
                estatus = "/"
            End If
            If cmbEstatus.Text = "SURTIDA" Then
                estatus = "S"
            End If
            consultaConEstatus(idnave, del, al, anio, estatus)
            disenioGrid()
        End If

        If txtFolio.Text <> "" Then
            consultaConFolio(idnave, anio, txtFolio.Text)
            disenioGrid()
        End If

        If rdoAutorizacion.Checked = True Or rdoCaptura.Checked = True Or rdoEntrega.Checked = True Or rdoRechazo.Checked = True Then
            If cmbEstatus.Text = "" Then
                Dim busca As String
                If rdoAutorizacion.Checked = True Then
                    busca = "ordc_fechaautorizacion"
                End If
                If rdoCaptura.Checked = True Then
                    busca = "ordc_fechaelaboracion"
                End If
                If rdoEntrega.Checked = True Then
                    busca = "ordc_fechaentregaestimada"
                End If
                If rdoRechazo.Checked = True Then
                    busca = "ordc_fechacancelacion"
                End If
                consulta1(idnave, del, al, anio, busca)
                disenioGrid()
            End If
        End If
    End Sub

    Public Sub disenioGrid()

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        With grdOrdenesdeCompra.DisplayLayout.Bands(0)

            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("#").Header.Caption = " "
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha de Solicitud").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Folio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha de Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Importe").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tipo de Documento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Razon Social").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Prioridad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Plazo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tipo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("ID").Hidden = True
            .Columns("Estatus").Hidden = True
            .Columns("ID c").Hidden = True

            .Columns("Importe").Format = "$##,##0.00"
            .Columns("Importe").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Folio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Seleccion").Width = 12
            .Columns("#").Width = 20
            .Columns("Proveedor").Width = 150
            .Columns("Importe").Width = 50
            .Columns("Razon Social").Width = 150
            .Columns("Plazo").Width = 120
            .Columns("Prioridad").Width = 50
            .Columns("Tipo").Width = 60
            grdOrdenesdeCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.Cursor = Windows.Forms.Cursors.Default
        End With
        colorearGrid()

    End Sub

    Public Sub colorearGrid()

        If grdOrdenesdeCompra.Rows.Count > 0 Then

            With grdOrdenesdeCompra.DisplayLayout.Bands(0)
                Dim tamano As Integer = 0
                Do
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Text = "ALTA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Text = "A" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Text = "BAJA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Text = "B" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#04B404")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Text = "MEDIA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Text = "M" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("Prioridad").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#daa520")
                    End If

                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "CAPTURADA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "C" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7BE81")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "AUTORIZADA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "A" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#81DAF5")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "RECHAZADA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "R" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF4000")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "CANCELADA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "X" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#F78181")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "POR SURTIR" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "P" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#61380B")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "PARCIAL SURTIDA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "/" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#7401DF")
                    End If
                    If grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "SURTIDA" Or grdOrdenesdeCompra.Rows(tamano).Cells("Estatus").Text = "S" Then
                        grdOrdenesdeCompra.Rows(tamano).Cells("#").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#848484")
                    End If

                    tamano = tamano + 1

                Loop While tamano < grdOrdenesdeCompra.Rows.Count

            End With

        End If

    End Sub

    Private Sub permitirSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub Autorizar()

        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New OrdenesDeCompra

        Dim tamano As Integer = grdOrdenesdeCompra.Rows.Count()

        For value As Integer = 0 To tamano - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "CAPTURADA" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "C" Then
                    Dim id As Integer
                    id = grdOrdenesdeCompra.Rows(value).Cells("ID").Text
                    EntidadOC.ordc_ordencompraid = id
                    EntidadOC.ordc_fechaautorizacion = DateTime.Now.ToString("dd/MM/yyyy")
                    EntidadOC.ordc_autorizacompraid = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
                    EntidadOC.ordc_estatus = "A"
                    objBU.autorizarMaterial(EntidadOC)
                End If
            End If
        Next
        disenioGrid()
    End Sub

    Public Sub Rechazar()

        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        Dim tamano As Integer = grdOrdenesdeCompra.Rows.Count()

        For value As Integer = 0 To tamano - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "CAPTURADA" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "C" Then
                    Dim id As Integer
                    id = grdOrdenesdeCompra.Rows(value).Cells("ID").Text
                    EntidadOC.ordc_ordencompraid = id
                    EntidadOC.ordc_estatus = "R"
                    EntidadOC.ordc_razonrechazo = objDatelleRechazo.texto
                    'EntidadOC.ordc_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    objBU.rechazarMaterial(EntidadOC)
                End If
            End If
        Next
        disenioGrid()
    End Sub

    Public Sub Cancelar()

        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        Dim tamano As Integer = grdOrdenesdeCompra.Rows.Count()

        For value As Integer = 0 To tamano - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "AUTORIZADA" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "CAPTURADA" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "A" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "C" Then
                    Dim id As Integer
                    id = grdOrdenesdeCompra.Rows(value).Cells("ID").Text
                    EntidadOC.ordc_ordencompraid = id
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    EntidadOC.ordc_estatus = "X"
                    'EntidadOC.ordc_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    objBU.rechazarMaterial(EntidadOC)
                End If
            End If
        Next
        disenioGrid()
    End Sub

    Public Sub porSurtir()

        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        Dim tamano As Integer = grdOrdenesdeCompra.Rows.Count()

        For value As Integer = 0 To tamano - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "A" Then
                    Dim id As Integer
                    id = grdOrdenesdeCompra.Rows(value).Cells("ID").Text
                    EntidadOC.ordc_ordencompraid = id
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    EntidadOC.ordc_estatus = "P"
                    objBU.autorizarMaterial(EntidadOC)
                End If
            End If
        Next

    End Sub

    Public Sub ParcialSurtida()

        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        Dim tamano As Integer = grdOrdenesdeCompra.Rows.Count()

        For value As Integer = 0 To tamano - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "A" Then
                    Dim id As Integer
                    id = grdOrdenesdeCompra.Rows(value).Cells("ID").Text
                    EntidadOC.ordc_ordencompraid = id
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    EntidadOC.ordc_estatus = "/"
                    objBU.autorizarMaterial(EntidadOC)
                End If
            End If
        Next

    End Sub

    Public Sub Surtida()

        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        Dim tamano As Integer = grdOrdenesdeCompra.Rows.Count()

        For value As Integer = 0 To tamano - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                ' If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text <> "A" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text <> "R" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text <> "/" Or grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text <> "S" Then
                If grdOrdenesdeCompra.Rows(value).Cells("Estatus").Text = "A" Then
                    Dim id As Integer
                    id = grdOrdenesdeCompra.Rows(value).Cells("ID").Text
                    EntidadOC.ordc_ordencompraid = id
                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    EntidadOC.ordc_estatus = "S"
                    objBU.autorizarMaterial(EntidadOC)
                End If
            End If
        Next

    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Try
            If grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "CAPTURADA" Then
                objConfirmacion.mensaje = "¿Esta seguro que desea AUTORIZAR la orden de compra?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Autorizar()
                    btnBuscar()
                    objConfirmacion.mensaje = "Se AUTORIZO la orden de compra"
                    objConfirmacion.ShowDialog()
                End If
            Else
                If grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "CANCELADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "X" Then
                    objAdvertencia.mensaje = "No se puede AUTORIZAR una orden de compra CANCELADA"
                    objAdvertencia.ShowDialog()
                End If
                If grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "RECHAZADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "R" Then
                    objAdvertencia.mensaje = "No se puede AUTORIZAR una orden de compra RECHAZADA"
                    objAdvertencia.ShowDialog()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Try
            Dim tamano = grdOrdenesdeCompra.Rows.Count
            Dim numero As Integer = 0

            For value As Integer = 0 To tamano - 1
                If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                    numero = numero + 1
                End If
            Next

            If numero <= 1 Then
                If grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "CAPTURADA" Then
                    objConfirmacion.mensaje = "¿Esta seguro que desea RECHAZAR la orden de compra?"
                    If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        objDatelleRechazo.mensaje = "Ingrese la razón del rechazo de la orden de compra"
                        objDatelleRechazo.ShowDialog()
                        Rechazar()
                        btnBuscar()
                    End If
                Else
                    objAdvertencia.mensaje = "No se puede RECHAZAR una orden de compra si esta no tiene el estatus de CAPTURADA"
                    objAdvertencia.ShowDialog()
                End If
            Else
                objAdvertencia.mensaje = "Solo se puede rechazar una orden de compra a la vez"
                objAdvertencia.ShowDialog()
            End If
           
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            If grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "CAPTURADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "AUTORIZADA" Then
                objConfirmacion.mensaje = "¿Esta seguro que desea CANCELAR la orden de compra?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cancelar()
                    btnBuscar()
                End If
            Else
                objAdvertencia.mensaje = "No se puede CANCELAR una orden de compra si esta no tiene el estatus de CAPTURADA O AUTORIZADA"
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub grdOrdenesdeCompra_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdOrdenesdeCompra.DoubleClickCell
        Try
            If grdOrdenesdeCompra.ActiveRow.Cells("RAZON SOCIAL").Text <> "" Then
                idOc = grdOrdenesdeCompra.ActiveRow.Cells("ID").Text
                Dim form As New CapturaOrdenesDeCompraForm
                form.txtIdOC.Text = idOc
                If form.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    'actualizar()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If grdOrdenesdeCompra.Rows.Count > 0 Then

                Dim CONTADOR As Integer = 0
                Dim CELDA As Integer = 0
                For value As Integer = 0 To grdOrdenesdeCompra.Rows.Count - 1
                    If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                        CONTADOR = CONTADOR + 1
                        CELDA = value
                    End If
                Next

                If CONTADOR = 1 Then
                    If grdOrdenesdeCompra.Rows(CELDA).Cells("Estatus").Text = "CAPTURADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "C" Then
                        idOc = grdOrdenesdeCompra.Rows(CELDA).Cells("ID").Text
                        Dim modificarCaptura As New CapturaOrdenesDeCompraForm
                        modificarCaptura.txtModificar.Text = "SI"
                        modificarCaptura.txtIdOC.Text = idOc
                        If modificarCaptura.ShowDialog = Windows.Forms.DialogResult.OK Then
                        End If
                    Else
                        If grdOrdenesdeCompra.Rows(CELDA).Cells("Estatus").Text = "CANCELADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "X" Then
                            objAdvertencia.mensaje = "No se puede editar una orden de compra CANCELADA"
                            objAdvertencia.ShowDialog()
                        End If
                        If grdOrdenesdeCompra.Rows(CELDA).Cells("Estatus").Text = "RECHAZADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "R" Then
                            objAdvertencia.mensaje = "No se puede editar una orden de compra RECHAZADA"
                            objAdvertencia.ShowDialog()
                        End If
                        If grdOrdenesdeCompra.Rows(CELDA).Cells("Estatus").Text = "AUTORIZADA" Or grdOrdenesdeCompra.ActiveRow.Cells("Estatus").Text = "A" Then
                            objAdvertencia.mensaje = "No se puede editar una orden de compra AUTORIZADA"
                            objAdvertencia.ShowDialog()
                        End If
                    End If
                ElseIf CONTADOR = 0 Then
                    objAdvertencia.mensaje = "Seleccione una orden de compra"
                    objAdvertencia.ShowDialog()
                Else
                    objAdvertencia.mensaje = "Solo puede editar una orden de compra a la vez"
                    objAdvertencia.ShowDialog()
                End If

            Else
                objAdvertencia.mensaje = "Seleccione una orden de compra para poder editarla"
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub crearreporte()
        Dim idoc As Integer
        Dim idm As Integer
        Dim prov As Integer
        Dim encabezado = New DataTable("Encabezado")
        Dim tablamateriales = New DataTable("tablamateriales")
        Dim autorizo = New DataTable("autorizo")
        Dim objBU As New OrdenesDeCompra

        Dim CONTADOR As Integer = 0
        Dim CELDA As Integer = 0
        For value As Integer = 0 To grdOrdenesdeCompra.Rows.Count - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                CONTADOR = CONTADOR + 1
                CELDA = value
            End If
        Next

        If CONTADOR = 1 Then
            Try
                If grdOrdenesdeCompra.Rows(CELDA).Cells("Seleccion").Text = 1 Then
                    ''Obtener el numero de orden de compra
                    idoc = grdOrdenesdeCompra.ActiveRow.Cells("ID").Text
                    idm = grdOrdenesdeCompra.ActiveRow.Cells("Folio").Text
                    prov = grdOrdenesdeCompra.ActiveRow.Cells("ID c").Text
                    encabezado = objBU.reporteOrdenDeCompra(idoc)
                    tablamateriales = objBU.reporteOrdenDeCompraMateriales(idoc)
                    autorizo = objBU.autorizo(idoc)

                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("Reporte_Orden_de_Compra")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    ' Dim x = encabezado.Rows(0).Item("Folio").ToString
                    ruta = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                    reporte("log") = ruta.ToUpper.Trim.Replace(" ", "")
                    reporte("folio") = encabezado.Rows(0).Item("Folio").ToString
                    reporte("Id nave") = encabezado.Rows(0).Item("Id nave").ToString
                    Dim fech As Date = DateTime.Now.ToString("dd/MM/yyyy")
                    Dim hora = Now.ToString("HH:mm:ss")
                    reporte("fechadeldia") = fech + " " + hora
                    reporte("fenvio") = encabezado.Rows(0).Item("Fecha").ToString
                    ' reporte("contacto") = encabezado.Rows(0).Item("Nombre").ToString
                    reporte("fentrega") = encabezado.Rows(0).Item("Fecha entrega").ToString
                    reporte("periodo") = "DEL: " + encabezado.Rows(0).Item("Periodo del").ToString + " AL: " + encabezado.Rows(0).Item("Periodo al").ToString
                    If encabezado.Rows(0).Item("Urgencia").ToString = "M" Then
                        reporte("urgencia") = "MEDIO"
                    ElseIf encabezado.Rows(0).Item("Urgencia").ToString = "B" Then
                        reporte("urgencia") = "BAJO"
                    ElseIf encabezado.Rows(0).Item("Urgencia").ToString = "A" Then
                        reporte("urgencia") = "ALTO"
                    End If
                    'reporte("calle") = encabezado.Rows(0).Item("Calle").ToString + " #" + encabezado.Rows(0).Item("No").ToString
                    'reporte("colonia") = encabezado.Rows(0).Item("Colonia").ToString
                    '' reporte("no") = encabezado.Rows(0).Item("No").ToString 
                    'reporte("telefono") = encabezado.Rows(0).Item("Telefono").ToString
                    reporte("calle") = encabezado.Rows(0).Item("Calle").ToString.ToUpper() + " #" + encabezado.Rows(0).Item("No").ToString + " COL." + encabezado.Rows(0).Item("Colonia").ToString.ToUpper() + " - " + encabezado.Rows(0).Item("Nombre").ToString.ToUpper()
                    'reporte("telefono") = encabezado.Rows(0).Item("Telefono").ToString
                    reporte("observaciones") = encabezado.Rows(0).Item("Observaciones").ToString.ToUpper()
                    If encabezado.Rows(0).Item("Motivo").ToString <> "" Then
                        reporte("motivo") = "MOTIVO DEL RECHAZO: " + encabezado.Rows(0).Item("Motivo").ToString.ToUpper()
                    End If
                    Dim total, iva, subtotal As Double
                    total = encabezado.Rows(0)("Total").ToString()
                    iva = encabezado.Rows(0)("Iva").ToString()
                    subtotal = encabezado.Rows(0)("Subtotal").ToString()
                    reporte("subtotal") = Format(subtotal, "#,##0.00")
                    reporte("iva") = Format(iva, "#,##0.00")
                    reporte("total") = Format(total, "#,##0.00")
                    reporte("cadenacomercial") = encabezado.Rows(0).Item("Cadena comercial").ToString.ToUpper() + " - " + encabezado.Rows(0).Item("Proveedor").ToString.ToUpper() + " TEL." + encabezado.Rows(0).Item("Telefono").ToString.ToUpper()
                    ' reporte("proveedor") = encabezado.Rows(0).Item("Proveedor").ToString
                    reporte("usuario") = encabezado.Rows(0).Item("Nombre").ToString.ToUpper()
                    reporte("numped") = tablamateriales.Rows.Count.ToString
                    reporte("elaboro") = encabezado.Rows(0).Item("Nombre").ToString.ToUpper()
                    If encabezado.Rows(0).Item("Estatus").ToString = "X" Then
                        reporte("autorizo") = "ORDEN DE COMPRA CANCELADA"
                    ElseIf encabezado.Rows(0).Item("Estatus").ToString = "R" Then
                        reporte("autorizo") = "ORDEN DE COMPRA RECHAZADA"
                    ElseIf encabezado.Rows(0).Item("Estatus").ToString = "C" Then
                        reporte("autorizo") = "ORDEN DE COMPRA NO AUTORIZADA"
                    ElseIf autorizo.Rows.Count <> 0 Then
                        reporte("autorizo") = autorizo.Rows(0).Item("user_nombrereal").ToString.ToUpper()
                    End If
                    reporte.RegData(tablamateriales)
                    ' reporte("cadenacomercial") = encabezado.Rows(0).Item("").ToString
                    'reporte("cadenacomercial") = encabezado.Rows(0).Item("").ToString
                    ''reporte("año") = "" & Year(Now)
                    reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
        
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim CONTADOR As Integer = 0
        For value As Integer = 0 To grdOrdenesdeCompra.Rows.Count - 1
            If grdOrdenesdeCompra.Rows(value).Cells("Seleccion").Text = 1 Then
                CONTADOR = CONTADOR + 1
            End If
        Next
        If CONTADOR = 1 Then
            crearreporte()
        ElseIf CONTADOR = 0 Then
            objAdvertencia.mensaje = "Seleccione una orden de compra para generar el archivo"
            objAdvertencia.ShowDialog()
        Else
            objAdvertencia.mensaje = "Solo puede generar un reporte a la vez"
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub rdoCaptura_CheckedChanged(sender As Object, e As EventArgs) Handles rdoCaptura.CheckedChanged
        'cmbEstatus.SelectedValue = 0
    End Sub

    'Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
    '    'pnlGrid.Width = 1066
    '    pnlGrid.Height = 445

    'End Sub

    'Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
    '    'pnlGrid.Width = 1066
    '    pnlGrid.Height = 369
    'End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim form As New FechasDePAgoForm
        'form.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Dim form As New PlazosDePagoForm
        'form.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Dim form As New PlazosDePagoPrincipalForm
        'form.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim form As New AltaEdicionDeSemanasPlazoDePagoForm
        'form.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Dim FORM As New ConsultaDeCobradoresForm
        'FORM.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Dim FORM As New AltaEdicionDeCobradoresForm
        'FORM.ShowDialog()
    End Sub
End Class