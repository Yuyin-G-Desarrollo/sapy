Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ReportesForm
    Public nombre As String
    Public esquema As String
    Public clave As String
    Public activo As Boolean
    Public IdReporte As Int32
    Public AgregarOEditar As Boolean

    Private Sub ReportesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        nombre = txtNombre.Text
        activo = True
        esquema = txtEsquema.Text
        clave = txtClave.Text
        ListaReportes()
    End Sub

    ''' <summary>
    ''' Manda llamar el metodo ListaReportas de la capa negocios con el que llenaremos el grid
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ListaReportes()
        Dim objbu As New Negocios.ReportesBU
        grdLisaReportes.DataSource = objbu.ListaReportes(esquema, nombre, clave, activo)
        IdReporte = 0
        nombre = ""
        esquema = ""
        clave = ""
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlOpciones.Height = 148
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlOpciones.Height = 32
    End Sub


    Private Sub grdLisaReportes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdLisaReportes.InitializeLayout
        With grdLisaReportes
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Esquema").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Nombre").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Clave").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Activo").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.NoEdit
        End With

    End Sub

    Private Sub grdLisaReportes_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdLisaReportes.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdLisaReportes_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdLisaReportes.ClickCell
        Dim row As UltraGridRow = grdLisaReportes.ActiveRow
        If row.IsFilterRow Then Return
        IdReporte = CInt(row.Cells("Id").Text)
        esquema = CStr(row.Cells("Esquema").Text)
        nombre = CStr(row.Cells("Nombre").Text)
        clave = CStr(row.Cells("Clave").Text)
        activo = CBool(row.Cells("Activo").Value)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        nombre = txtNombre.Text
        clave = txtClave.Text
        esquema = txtEsquema.Text
        If rdoSi.Checked = True Then
            activo = True
        ElseIf rdoNo.Checked = True Then
            activo = False
        End If
        ListaReportes()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        nombre = ""
        activo = True
        esquema = ""
        clave = ""
        IdReporte = 0

        rdoSi.Checked = True
        txtNombre.Text = ""
        txtEsquema.Text = ""
        txtClave.Text = ""
        grdLisaReportes.DataSource = Nothing

    End Sub


    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        AgregarOEditar = True
        Dim formaReportes As New AltaReportesForm
        formaReportes.AgregarOEditar = AgregarOEditar
        formaReportes.ShowDialog()
        ListaReportes()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AgregarOEditar = False

        If IdReporte = 0 Then
            Dim formaError As New AdvertenciaForm
            formaError.mensaje = "Selecciona los los datos que deseas modificar antes de dar click en el botón 'Editar'"
            formaError.ShowDialog()
        Else
            Dim formaReportes As New AltaReportesForm
            formaReportes.idReporte = IdReporte
            formaReportes.Nombre = nombre
            formaReportes.Clave = clave
            formaReportes.activo = activo
            formaReportes.Esquema = esquema
            formaReportes.AgregarOEditar = AgregarOEditar
            formaReportes.ShowDialog()
            ListaReportes()
        End If
    End Sub


    'Private Sub ugridReportes_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs)
    '    idReporte = 0
    '    Nombre = ""
    '    Esquema = ""
    '    Clave = ""
    '    idReporte = CInt(ugridReportes.Rows(ugridReportes.ActiveRow.Index).Cells("repo_reporteid").Value)
    '    Nombre = CStr(ugridReportes.Rows(ugridReportes.ActiveRow.Index).Cells("repo_nombrereporte").Value)
    '    Esquema = CStr(ugridReportes.Rows(ugridReportes.ActiveRow.Index).Cells("repo_esquema").Value)
    '    Try
    '        Clave = CStr(ugridReportes.Rows(ugridReportes.ActiveRow.Index).Cells("repo_clavereporte").Value)
    '    Catch ex As Exception
    '    End Try
    '    txtNombre.Text = Nombre
    '    txtEsquema.Text = Esquema
    '    txtClave.Text = Clave
    'End Sub

End Class