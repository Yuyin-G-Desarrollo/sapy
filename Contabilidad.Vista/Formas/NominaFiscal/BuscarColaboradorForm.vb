Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Tools

Public Class BuscarColaboradorForm
    Public idColaborador As Integer = 0
    ''1. internos, 2.externos, 3.Todos
    Public externo As Int32 = 0


    Private Sub BuscarColaboradorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboEmpresa()
        llenarComboNave()
        Select Case externo
            Case 1 : rdbExternoNo.Checked = True
                rdbExternoSi.Enabled = False
                GroupBox2.Enabled = False
            Case 2 : rdbExternoSi.Checked = True
                rdbExternoNo.Enabled = False
                GroupBox2.Enabled = False

        End Select
    End Sub

    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresa()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboNave()
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblBuscar.Click
        cargarListado()
    End Sub

    Private Sub cargarListado()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If validarFiltros() Then
                Dim objBu As New Negocios.UtileriasBU
                Dim dtListado As New DataTable

                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim naveId As Integer = cmbNave.SelectedValue
                Dim nombre As String = txtNombre.Text
                Dim externo As Boolean = rdbExternoSi.Checked

                dtListado = objBu.consultarColaboradoresAsegurados(patronId, naveId, nombre, externo, True)
                If dtListado.Rows.Count > 0 Then
                    grdColaboradores.DataSource = dtListado
                    disenioGrid()
                Else
                    grdColaboradores.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de colaboradores."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        With grdColaboradores.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Departamento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdColaboradores.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("#").Width = 20

            .Columns("#").CharacterCasing = CharacterCasing.Upper
            .Columns("Colaborador").CharacterCasing = CharacterCasing.Upper
            .Columns("Departamento").CharacterCasing = CharacterCasing.Upper
            .Columns("Puesto").CharacterCasing = CharacterCasing.Upper
            .Columns("Nave").CharacterCasing = CharacterCasing.Upper
        End With

        grdColaboradores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradores.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdColaboradores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradores.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdColaboradores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        cargarListado()
    End Sub

    Private Sub grdColaboradores_BeforeRowActivate(sender As Object, e As RowEventArgs)
        'Try
        '    If e.Row.Cells("ID").Value <> 0 Then
        '        idColaborador = CInt(e.Row.Cells("ID").Value)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub grdColaboradores_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdColaboradores.ClickCell
        Try
            If e.Cell.Row.Cells("ID").Value <> 0 Then
                idColaborador = CInt(e.Cell.Row.Cells("ID").Value)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click, lblSeleccionar.Click
        seleccionarColaborador()
    End Sub

    Private Sub grdColaboradores_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdColaboradores.DoubleClickCell
        seleccionarColaborador()
    End Sub

    Private Sub seleccionarColaborador()
        If idColaborador = 0 Then
            btnSeleccionar.DialogResult = Windows.Forms.DialogResult.Cancel

            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione un colaborador"
            Advertencia.MdiParent = MdiParent
            Advertencia.Show()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click, lblCancelar.Click
        idColaborador = 0
        Me.Close()
    End Sub
End Class