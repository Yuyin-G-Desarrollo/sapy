Imports System.Drawing
Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ListaPatronesContForm

    Private Sub ListaPatronesContForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarListado()

        pnlAltas.Visible = PermisosUsuarioBU.ConsultarPermiso("REG_PATRONAL", "ALTA")
        pnlEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("REG_PATRONAL", "EDITAR")
        PatronesArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("REG_PATRONAL", "MODIF_WORD_RPNF")

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarListado()
    End Sub

    Private Sub llenarListado()
        grdPatrones.DataSource = Nothing
        Dim objBU As New Negocios.CatalogoPatronesBU
        Dim dtPatrones As New DataTable

        dtPatrones = objBU.ConsultarPatrones(txtNombre.Text, txtRFC.Text, txtRegPatronal.Text, rdoActivo.Checked)
        If Not dtPatrones Is Nothing AndAlso dtPatrones.Rows.Count > 0 Then
            grdPatrones.DataSource = dtPatrones
            formatoGrid()
        Else
            Dim mensajeAdv As New Tools.AdvertenciaForm
            mensajeAdv.mensaje = "No se encontró información."
            mensajeAdv.ShowDialog()

        End If

    End Sub

    Public Sub formatoGrid()
        grdPatrones.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        With grdPatrones.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.RowSelect

            .Columns("patr_patronid").Hidden = True

            .Columns("patr_nombre").Header.Caption = "Patrón"
            .Columns("patr_rfc").Header.Caption = "RFC"
            .Columns("patr_nopatronal").Header.Caption = "Registro Patronal"
            .Columns("manejaComisiones").Header.Caption = "Maneja Comisiones"
            .Columns("estado").Header.Caption = "Estatus"
            .Columns("usuariocreo").Header.Caption = "Usuario creó"

            .Columns("patr_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("patr_rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("patr_nopatronal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("manejaComisiones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("estado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("usuariocreo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        End With

        grdPatrones.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdPatrones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPatrones.DisplayLayout.Override.RowSelectorWidth = 35
        grdPatrones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdPatrones.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdPatrones.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

        Me.grdPatrones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPatrones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdPatrones.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
        grdPatrones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPatrones.DataSource = Nothing
        txtNombre.Text = ""
        txtRegPatronal.Text = ""
        txtRFC.Text = ""
        rdoActivo.Checked = True
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim objForm As New AltaPatronesForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaPatronesForm
            formaAltas.editar = False
            formaAltas.idpatron = 0
            formaAltas.ShowDialog()

            If formaAltas.guardado Then
                llenarListado()
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

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objAdvertencias As New Tools.AdvertenciaForm

        If grdPatrones.Selected.Rows.Count > 1 Then
            objAdvertencias.mensaje = "Seleccione solo un registro para poder editarlo."
            objAdvertencias.ShowDialog()
        ElseIf grdPatrones.Selected.Rows.Count = 0 Then
            objAdvertencias.mensaje = "Seleccione un registro para poder editarlo."
            objAdvertencias.ShowDialog()
        ElseIf IsDBNull(grdPatrones.Selected.Rows(0).Cells("patr_patronid").Value) = False Then
            Dim objForm As New AltaPatronesForm
            If Not CheckForm(objForm) Then

                Dim formaAltas As New AltaPatronesForm
                formaAltas.editar = True
                formaAltas.idpatron = CInt(grdPatrones.Selected.Rows(0).Cells("patr_patronid").Value)
                formaAltas.ShowDialog()

                If formaAltas.guardado Then
                    llenarListado()
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

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaPatronesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaPatronesToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_AltaPatrones_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_AltaPatrones_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PatronesArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PatronesArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_AltaPatrones_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_AltaPatrones_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PlantillaAltaPatronToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlantillaAltaPatronToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "AltaPatron_Formato.xlsx")
            Process.Start("Descargas\Manuales\Contabilidad\AltaPatron_Formato.xlsx")
        Catch ex As Exception
        End Try
    End Sub

End Class