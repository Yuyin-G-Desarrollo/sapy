Imports Produccion.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CatalogoFraccionesForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Dim id As Integer = 0
    Public nave As Integer
    Dim Actualizar As String = 0

    Private Sub CatalogoFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerFracciones()
        txtFracciones.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        rdoSi.Checked = True
        txtFraccion.Focus()
        rdoSiPaga.Checked = True
        'llenarcomboMaquinaria()
    End Sub

    Public Sub llenarcomboMaquinaria()
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaMaquinaria()
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMaquinaria.DataSource = lista
            cmbMaquinaria.DisplayMember = "Maquinaria"
            cmbMaquinaria.ValueMember = "ID"
        End If
    End Sub

    Public Sub obtenerFracciones()
        Dim obj As New catalagosBU
        Dim listaFracciones As New DataTable
        listaFracciones = obj.listaFraccionesCatalogo(IIf(rbActivo.Checked, True, False), rbTodos.Checked)
        grdFracciones.DataSource = listaFracciones
        disenioGrid()
    End Sub

    'Private Sub permitirSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress, txtTiempo.KeyPress
    '    If Char.IsDigit(e.KeyChar) Then
    '        e.Handled = False
    '    ElseIf Char.IsControl(e.KeyChar) Then
    '        e.Handled = False
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub

    Public Sub disenioGrid()
        With grdFracciones.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Fracción").CellActivation = Activation.NoEdit
            .Columns("Tiempo").CellActivation = Activation.NoEdit
            .Columns("Precio").CellActivation = Activation.NoEdit
            '.Columns("Maquinaria").CellActivation = Activation.NoEdit
            .Columns("Departamento").CellActivation = Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Tiempo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right

            .Columns("ID").Width = 30
            '.Columns("IDmaq").Hidden = True
            .Columns("idd").Hidden = True
            .Columns("Fracción").Width = 150
            .Columns("Paga").Hidden = True
            .Columns("Activo").Width = 40
            .Columns("Tiempo").Hidden = True
            .Columns("Precio").Hidden = True
            '.Columns("Maquinaria").Hidden = True
            .Columns("Departamento").Hidden = True

            .Columns("Paga").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Paga").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Paga").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Paga").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Activo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdFracciones.Rows.Count - 1
                If grdFracciones.Rows(value).Cells("Paga").Value = 1 Then
                    grdFracciones.Rows(value).Cells("Paga").Value = True
                Else
                    grdFracciones.Rows(value).Cells("Paga").Value = False
                End If
            Next
            For value = 0 To grdFracciones.Rows.Count - 1
                If grdFracciones.Rows(value).Cells("Activo").Value = 1 Then
                    grdFracciones.Rows(value).Cells("Activo").Value = True
                Else
                    grdFracciones.Rows(value).Cells("Activo").Value = False
                End If
            Next
        End With
        grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtFracciones.Text <> "" Then
            If Actualizar = 0 Then
                guardarFraccion()
            Else
                ActualizarFraccion()
            End If
        Else
            objAdvertencia.mensaje = "Ingrese una Fracción"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
            lblFraccion.ForeColor = Drawing.Color.Red
        End If

    End Sub

    Public Sub guardarFraccion()
        Dim entidad As New Entidades.Fracciones
        Dim obj As New catalagosBU

        entidad.frap_descripcion = txtFracciones.Text
        If rdoSiPaga.Checked = True Then
            entidad.frap_paga = 1
        Else
            entidad.frap_paga = 0
        End If

        If txtPrecio.Text <> "" Then
            entidad.frap_precio = txtTiempo.Text
        Else
            entidad.frap_precio = 0
        End If
        If txtTiempo.Text <> "" Then
            entidad.frap_tiempo = txtTiempo.Text
        Else
            entidad.frap_tiempo = 0
        End If

        If cmbMaquinaria.SelectedValue > 0 Then
            entidad.frap_maquinaria = cmbMaquinaria.SelectedValue
        Else
            entidad.frap_maquinaria = 0
        End If
        entidad.frap_usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            entidad.frap_activo = 1
        Else
            entidad.frap_activo = 0
        End If

        obj.GuardarFracciones(entidad)
        obtenerFracciones()
        objExito.mensaje = "Se guardo con éxito la fracción"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Public Sub ActualizarFraccion()
        Dim entidad As New Entidades.Fracciones
        Dim obj As New catalagosBU

        entidad.frap_descripcion = txtFracciones.Text
        If rdoSiPaga.Checked = True Then
            entidad.frap_paga = 1
        Else
            entidad.frap_paga = 0
        End If
        entidad.frap_tiempo = txtTiempo.Text
        entidad.frap_precio = txtPrecio.Text
        If cmbMaquinaria.SelectedValue > 0 Then
            entidad.frap_maquinaria = cmbMaquinaria.SelectedValue
        Else
            entidad.frap_maquinaria = 0
        End If
        entidad.frap_usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            entidad.frap_activo = 1
        Else
            entidad.frap_activo = 0
        End If
        entidad.frap_fraccionid = txtIDFraccion.Text

        obj.ActualizarFracciones(entidad)
        obtenerFracciones()
        objExito.mensaje = "Se modificó la fracción"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Private Sub grdFracciones_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdFracciones.DoubleClickCell
        'If grdFracciones.Rows.Count > 0 Then
        '    txtFracciones.Text = grdFracciones.ActiveRow.Cells("Fracción").Text
        '    txtIDFraccion.Text = grdFracciones.ActiveRow.Cells("ID").Text
        '    txtPrecio.Text = grdFracciones.ActiveRow.Cells("Precio").Text
        '    txtTiempo.Text = grdFracciones.ActiveRow.Cells("Tiempo").Text
        '    If grdFracciones.ActiveRow.Cells("Paga").Text = True Then
        '        rdoSiPaga.Checked = True
        '    Else
        '        rdoNoPaga.Checked = True
        '    End If
        '    If grdFracciones.ActiveRow.Cells("Activo").Text = True Then
        '        rdoSi.Checked = True
        '    Else
        '        rdoNo.Checked = True
        '    End If
        'End If
        'Try
        '    cmbMaquinaria.SelectedValue = grdFracciones.ActiveRow.Cells("IDmaq").Text
        'Catch ex As Exception

        'End Try
        'Actualizar = Actualizar + 1
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New AltaModificarFraccionesForm
        form.actualizar = 0
        form.ShowDialog()
        obtenerFracciones()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If id <> 0 Then
            Dim form As New AltaModificarFraccionesForm
            form.actualizar = 1
            form.idfraccion = grdFracciones.ActiveRow.Cells("ID").Text
            form.fraccion = grdFracciones.ActiveRow.Cells("Fracción").Text
            form.tiempo = grdFracciones.ActiveRow.Cells("Tiempo").Text
            form.precio = grdFracciones.ActiveRow.Cells("Precio").Text
            Try
                form.departamento = grdFracciones.ActiveRow.Cells("idd").Text
            Catch ex As Exception
                form.departamento = 0
            End Try
            'If grdFracciones.ActiveRow.Cells("IDmaq").Text = "" Then
            '    form.idmaquinaria = 0
            'Else
            '    form.idmaquinaria = grdFracciones.ActiveRow.Cells("IDmaq").Text
            'End If
            If grdFracciones.ActiveRow.Cells("Activo").Text = True Then
                form.activo = 1
            Else
                form.activo = 0
            End If
            If grdFracciones.ActiveRow.Cells("Paga").Text = True Then
                form.paga = 1
            Else
                form.paga = 0
            End If
            form.ShowDialog()
            obtenerFracciones()
        Else
            objAdvertencia.mensaje = "Seleccione una fracción para poder editarla"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub grdFracciones_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdFracciones.ClickCell
        Try
            id = grdFracciones.ActiveRow.Cells("ID").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim SaveFileDialog As New SaveFileDialog
        Dim NombreArchivo As String = "Catálogo_Fracciones_"
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter

        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"


        Dim FileName As String = SaveFileDialog.FileName
        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            gridExcelExporter.Export(Me.grdFracciones, FileName)

            Dim msg_exito As New Tools.ExitoForm
            msg_exito.mensaje = "Los datos se exportaron correctamente"
            msg_exito.ShowDialog()

            System.Diagnostics.Process.Start(FileName)

        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        obtenerFracciones()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Me.Cursor = Cursors.WaitCursor
        grdFracciones.DataSource = Nothing
        rbActivo.Checked = True
        Me.Cursor = Cursors.Default
    End Sub
End Class