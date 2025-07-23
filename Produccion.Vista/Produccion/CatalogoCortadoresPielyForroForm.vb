Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class CatalogoCortadoresPielyForroForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public idNaveSicy As Integer = 0
    Public idNaveSay As Integer = 0
    Dim lsta As New DataTable
    Dim lsta2 As New DataTable

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CatalogoCortadoresPielyForroForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCampoNaves()
        lsta.Columns.Add("ID")
        lsta.Columns.Add("Tipo")
        lsta2.Columns.Add("ID")
        lsta2.Columns.Add("Tipo")
        llenarComboTipoCortadorBuscar()
        Try
            obtenetIdNaveSicy()
        Catch ex As Exception
        End Try
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub llenarCampoNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub


    Public Sub llenarComboTipoCortadorBuscar()
        Dim obj As New catalagosBU
        Dim lst As New DataTable
        lst = obj.getTiposCortadores()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbTipoCortadorBuscar.DataSource = lst
            cmbTipoCortadorBuscar.DisplayMember = "tcor_descripcion"
            cmbTipoCortadorBuscar.ValueMember = "tcor_tipocortadorid"
        End If

        'lsta2.Clear()
        'lsta2.Rows.Add(New Object() {"0", ""})
        'lsta2.Rows.Add(New Object() {"1", "CORTADOR PIEL"})
        'lsta2.Rows.Add(New Object() {"2", "CORTADOR FORRO"})
        'cmbTipoCortadorBuscar.DataSource = lsta2
        'cmbTipoCortadorBuscar.DisplayMember = "Tipo"
        'cmbTipoCortadorBuscar.ValueMember = "ID"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNave.Text = "" Then
            objMensaje.mensaje = "Seleccione una nave"
            objMensaje.ShowDialog()
            lblNave.ForeColor = Drawing.Color.Red
        Else
            lblNave.ForeColor = Drawing.Color.Black
            Try
                obtenetIdNaveSicy()
            Catch ex As Exception
            End Try
            Try
                consultarCortadores()
            Catch ex As Exception
            End Try
        End If


    End Sub

    Public Sub obtenetIdNaveSicy()
        Dim obj As New catalagosBU
        Dim tablas As New DataTable
        If cmbNave.Text <> "" Then
            tablas = obj.listaNavesSicy(cmbNave.Text)
            idNaveSicy = tablas.Rows(0).Item(0)
        End If
    End Sub

    Public Sub obtenerIdNaveSay()
        Dim obj As New ProduccionBU
        Dim tabla As New DataTable
        If cmbNave.Text <> "" Then
            tabla = obj.idNaveSay(cmbNave.Text)
            idNaveSay = tabla.Rows(0).Item(0)
        End If
    End Sub


    Public Sub consultarCortadores()
        Dim obj As New ProduccionBU
        Dim tabla As New DataTable
        Dim estatus As Integer = 0
        Dim tipoCortador As Integer = 0
        If rdoActivo.Checked = True Then
            estatus = 1
        Else
            estatus = 0
        End If
        obtenerIdNaveSay()
        Try
            tipoCortador = cmbTipoCortadorBuscar.SelectedValue
        Catch ex As Exception
            tipoCortador = 0
        End Try
        tabla = obj.ConsultaCortadores(idNaveSay, tipoCortador, estatus)
        grdCortadores.DataSource = tabla
        disenioGrdCortadores()
    End Sub

    Public Sub disenioGrdCortadores()
        Dim band As UltraGridBand = Me.grdCortadores.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdCortadores.DisplayLayout.Bands(0)

            .Columns(" ").CellActivation = Activation.NoEdit
            .Columns("Tipo Cortador").CellActivation = Activation.NoEdit
            .Columns("ID colaborador").CellActivation = Activation.NoEdit
            .Columns("Cortador").CellActivation = Activation.NoEdit
            .Columns("Nombre Corto").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit

            .Columns("ID").Hidden = True
            .Columns("Estatus").Hidden = True
            .Columns("Tipo Cortador").Hidden = True

            .Columns("ID colaborador").CellAppearance.TextHAlign = HAlign.Right
            grdCortadores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Columns("ID colaborador").Width = 20
            .Columns("Cortador").Width = 200
            .Columns("Nombre Corto").Width = 80

            .Columns("Estatus").Width = 40
            .Columns(" ").Width = 10
            .Columns("Tipo Cortador").Width = 4
            .Columns("ID colaborador").Header.Caption = "ID"

        End With


        For value = 0 To grdCortadores.Rows.Count - 1
            If grdCortadores.Rows(value).Cells("Tipo Cortador").Text = "CORTADOR PIEL" Then
                grdCortadores.Rows(value).Cells(" ").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#0489B1")
            ElseIf grdCortadores.Rows(value).Cells("Tipo Cortador").Text = "CORTADOR FORRO" Then
                grdCortadores.Rows(value).Cells(" ").Appearance.BackColor = Color.MediumPurple
            ElseIf grdCortadores.Rows(value).Cells("Tipo Cortador").Text = "CORTADOR PIEL SINTETICO" Then
                grdCortadores.Rows(value).Cells(" ").Appearance.BackColor = Color.Salmon
            ElseIf grdCortadores.Rows(value).Cells("Tipo Cortador").Text = "CORTADOR FORRO SINTETICO" Then
                grdCortadores.Rows(value).Cells(" ").Appearance.BackColor = Color.Sienna
            End If
        Next
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbNave.SelectedValue = 0
        cmbTipoCortadorBuscar.SelectedValue = 0
        rdoActivo.Checked = True
        grdCortadores.DataSource = Nothing
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Try
            If cmbNave.Text = "" Then
                objMensaje.mensaje = "Seleccione una nave"
                objMensaje.ShowDialog()
                lblNave.ForeColor = Drawing.Color.Red
            Else
                lblNave.ForeColor = Drawing.Color.Black
                Dim form As New AltaCortadoresForm
                obtenerIdNaveSay()
                form.nave = idNaveSay
                form.accion = 0
                form.ShowDialog()
            End If
        Catch ex As Exception
        End Try
        Try
            consultarCortadores()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub grdCortadores_DoubleClick(sender As Object, e As EventArgs) Handles grdCortadores.DoubleClick
        'editarCortador()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If cmbNave.Text = "" Then
                objMensaje.mensaje = "Seleccione una nave"
                objMensaje.ShowDialog()
                lblNave.ForeColor = Drawing.Color.Red
            Else
                editarCortador()
            End If
        Catch ex As Exception
        End Try
        Try
            consultarCortadores()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub editarCortador()
        Dim form As New AltaCortadoresForm
        obtenetIdNaveSicy()
        form.idEmpleado = grdCortadores.ActiveRow.Cells("ID colaborador").Value
        form.idRegistro = grdCortadores.ActiveRow.Cells("ID").Value
        form.empleado = grdCortadores.ActiveRow.Cells("Cortador").Value
        form.nombrecorto = grdCortadores.ActiveRow.Cells("Nombre Corto").Value
        form.tipoCortador = grdCortadores.ActiveRow.Cells("Tipo Cortador").Value
        form.activo = grdCortadores.ActiveRow.Cells("Estatus").Value
        form.accion = 1
        'form.lblIdText.Visible = True
        'form.lblIdRegistro.Visible = True
        form.nave = idNaveSay
        form.ShowDialog()
        consultarCortadores()
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            grdCortadores.DataSource = Nothing
            cmbTipoCortadorBuscar.SelectedValue = 0
            rdoActivo.Checked = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If grdCortadores.Rows.Count > 0 Then
            exportarExcel()
        End If
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grdCortadores, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
                'grdLotesProduccion.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbTipoCortadorBuscar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoCortadorBuscar.SelectedIndexChanged

    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged

    End Sub
End Class