Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Produccion.Datos
Imports Tools

Public Class CatalogoComponentesForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim cambio As Integer = 0
    Dim id As Integer = 0
    Dim componente As String = ""
    Dim activo As Integer = 0

    Dim ListaComponentesSeleccionadosActivos As New List(Of Integer)

    Private Sub CatalogoComponentesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtComponente.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        obtenerComponentes()
    End Sub

    Public Sub obtenerComponentes()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        listaComponentes = obj.listaComponentes
        grdComponente.DataSource = listaComponentes
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdComponente.DisplayLayout.Bands(0)

            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Componente").CellActivation = Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Activo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Activo").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("ID").Width = 20
            .Columns("Componente").Width = 150
            .Columns("Activo").Width = 20

        End With
        grdComponente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    'Private Sub btnGuardarComponente_Click(sender As Object, e As EventArgs) Handles btnGuardarComponente.Click
    '    If txtComponente.Text <> "" Then
    '        If txtComponente.Text <> " " Then
    '            If txtID.Text = "" Then
    '                If BuscarComponente() = True Then
    '                    guardarComponente()
    '                Else
    '                    objMensaje.mensaje = "Ya hay un componente igual a la captura"
    '                    objMensaje.ShowDialog()
    '                End If
    '            Else
    '                'If BuscarComponente() = True Then
    '                modificarComponente()
    '                ' Else
    '                'objMensaje.mensaje = "Ya hay un componente igual a la captura"
    '                'objMensaje.ShowDialog()
    '            End If

    '            'End If
    '        Else
    '            objMensaje.mensaje = "Ingrese algun componente valido"
    '            objMensaje.ShowDialog()
    '        End If
    '    Else
    '        objMensaje.mensaje = "Ingrese algun componente"
    '        objMensaje.ShowDialog()
    '        lblComponente.ForeColor = Drawing.Color.Red
    '    End If
    '    'If txtID.Text <> "" Then
    '    '    leerComponentesSeleccionados()
    '    '    modificarListaComponente()
    '    'End If

    '    obtenerComponentes()
    'End Sub

    Public Sub leerComponentesSeleccionados()
        For value = 0 To grdComponente.Rows.Count - 1
            If grdComponente.Rows(value).Cells("Activo").Text = 1 Then
                ListaComponentesSeleccionadosActivos.Add(grdComponente.Rows(0).Cells("ID").Text)
            End If
        Next
    End Sub

    Public Sub guardarComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos

        componente.comp_descripcion = txtComponente.Text
        componente.comp_usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            componente.comp_activo = 1
        Else
            componente.comp_activo = 0
        End If
        obj.GuardarComponente(componente)
        objExito.mensaje = "Se guardo el componente con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()

    End Sub

    Public Sub modificarComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos

        componente.comp_descripcion = txtComponente.Text
        componente.comp_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If rdoSi.Checked = True Then
            componente.comp_activo = 1
        Else
            componente.comp_activo = 0
        End If
        componente.comp_idcomponente = txtID.Text
        obj.ModificarComponente(componente)
        objExito.mensaje = "Se realizo el cambio con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Public Function BuscarComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos
        listaComponentes = obj.ComponenteRepetido(txtComponente.Text)
        If listaComponentes.Rows.Count = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub modificarListaComponente()
        Dim obj As New ConsumosBU
        Dim listaComponentes As New DataTable
        Dim componente As New Entidades.Consumos

        For value = 0 To grdComponente.Rows.Count - 1
            componente.comp_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            componente.comp_idcomponente = grdComponente.Rows(value).Cells("ID").Value
            componente.comp_descripcion = grdComponente.Rows(value).Cells("Componente").Value
            componente.comp_activo = grdComponente.Rows(value).Cells("Activo").Value

            obj.ModificarComponente(componente)
        Next

        objExito.mensaje = "Se realizo el cambio con éxito"
        objExito.StartPosition = FormStartPosition.CenterScreen
        objExito.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdComponente_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdComponente.ClickCell
        Try
            id = grdComponente.ActiveRow.Cells("ID").Value
            componente = grdComponente.ActiveRow.Cells("Componente").Value
            activo = grdComponente.ActiveRow.Cells("Activo").Value
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim form As New AltaEditarComponentesForm
        form.editar = 0
        form.ShowDialog()
        obtenerComponentes()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If id <> 0 Then
                Dim form As New AltaEditarComponentesForm
                form.editar = 1
                form.id = id
                form.componente = componente
                form.activo = activo
                form.ShowDialog()
                obtenerComponentes()
            Else
                objAdvertencia.mensaje = "Seleccione un componente para poder editarlo"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAgregarClasificacion_Click(sender As Object, e As EventArgs) Handles btnAgregarClasificacion.Click
        If id <> 0 Then
            Dim form As New ModificarComponenteForm
            form.id = grdComponente.ActiveRow.Cells("ID").Text
            form.componente = grdComponente.ActiveRow.Cells("Componente").Text
            If grdComponente.ActiveRow.Cells("Activo").Text = 1 Then
                form.activo = 1
            Else
                form.activo = 0
            End If

            cambio = 1
            form.ShowDialog()
        Else
            objAdvertencia.mensaje = "Seleccione un componente para poder relacionarlo con alguna clasificación"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If
    End Sub

End Class