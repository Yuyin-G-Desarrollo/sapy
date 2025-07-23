Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Produccion.Negocios
Imports Tools

Public Class CatalogoMaquinariaForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim Actualizar As String = 0
    Dim nave As Integer = 0
    Dim id = 0
    Dim maquinaria = ""
    Dim idmaquinaria = 0
    Dim activo = 0

    Private Sub CatalogoMaquinariaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load, grdMaquinaria.DoubleClick
        obtenerMaquinaria()
        txtMaquinaria.Focus()
        txtMaquinaria.CharacterCasing = Windows.Forms.CharacterCasing.Upper
    End Sub

    Public Sub obtenerMaquinaria()
        Dim obj As New catalagosBU
        Dim listamaquinaria As New DataTable
        listamaquinaria = obj.listaMaquinaria()
        grdMaquinaria.DataSource = listamaquinaria
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdMaquinaria.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Maquinaria").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns("Activo").Width = 20
            .Columns("Maquinaria").Width = 120

            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Activo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdMaquinaria.Rows.Count - 1
                If grdMaquinaria.Rows(value).Cells("Activo").Value = 1 Then
                    grdMaquinaria.Rows(value).Cells("Activo").Value = True
                Else
                    grdMaquinaria.Rows(value).Cells("Activo").Value = False
                End If
            Next

        End With
        grdMaquinaria.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Actualizar = 0 Then
            guardarMaquinaria()
        Else
            ModificarMaquinaria()
        End If
    End Sub

    Public Sub guardarMaquinaria()
        Dim entidad As New Entidades.Maquinaria
        Dim obj As New catalagosBU

        entidad.maq_descripcion = txtMaquinaria.Text
        entidad.maq_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            entidad.maq_activo = 1
        Else
            entidad.maq_activo = 0
        End If

        obj.GuardarMaquinaria(entidad)
        objExito.mensaje = "Maquinaria registrada con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
        obtenerMaquinaria()
    End Sub

    Public Sub ModificarMaquinaria()
        Dim entidad As New Entidades.Maquinaria
        Dim obj As New catalagosBU

        entidad.maq_descripcion = txtMaquinaria.Text
        entidad.maq_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            entidad.maq_activo = 1
        ElseIf rdoNo.Checked = True Then
            entidad.maq_activo = 0
        End If
        entidad.maq_maquinaid = txtIDMaquinaria.Text

        obj.ActualizarMaquinaria(entidad)
        objExito.mensaje = "Maquinaria modificada con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
        obtenerMaquinaria()
    End Sub

    Private Sub grdMateriales_DoubleClick(sender As Object, e As EventArgs)
        maquinaria = grdMaquinaria.ActiveRow.Cells("Maquinaria").Text
        id = grdMaquinaria.ActiveRow.Cells("ID").Text
        activo = grdMaquinaria.ActiveRow.Cells("Activo").Text
        Actualizar = Actualizar + 1
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New AltaEdicionMaquinariaForm
        form.modificar = 0
        form.ShowDialog()
        obtenerMaquinaria()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If id = 0 Then
            objAdvertencia.mensaje = "Seleccione alguna maquinaria para poder modificarla"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        Else
            Dim form As New AltaEdicionMaquinariaForm
            form.modificar = 1
            form.id = id
            form.idmaquinqrias = idmaquinaria
            form.maquinaria = maquinaria
            form.activo = activo
            form.ShowDialog()
            obtenerMaquinaria()
        End If
    End Sub

    Private Sub grdMaquinaria_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdMaquinaria.ClickCell
        maquinaria = grdMaquinaria.ActiveRow.Cells("Maquinaria").Text
        id = grdMaquinaria.ActiveRow.Cells("ID").Text
        activo = grdMaquinaria.ActiveRow.Cells("Activo").Text
        Actualizar = Actualizar + 1
    End Sub
End Class