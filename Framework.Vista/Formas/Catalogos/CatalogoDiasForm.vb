Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CatalogoDiasForm

    Dim AgregarOModificar As Boolean
    Dim Activo As Boolean
    Dim IdDia As Int32
    Dim Nombre As String


    ''' <summary>
    ''' MANDA LLAMAR EL METODO LISTADIAS DE LA CAPA NEGOCIOS CON EL QUE LLENAREMOS EL GRID
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub llenarTablaDias()
        IdDia = 0
        Nombre = ""

        grdListaDias.DataSource = Nothing

        Dim objBU As New Negocios.CatalogoDiasBU
        Dim ListaDias As New DataTable

        ''Asignación de valores a las variables.
        Nombre = txtNombreDia.Text
        If rdoSi.Checked = False Then
            Activo = False
        Else
            Activo = True
        End If

        ListaDias = objBU.ListaDias(Activo, Nombre)

        ''Envíamos los datos al metodo de llenar Grid.
        grdListaDias.DataSource = ListaDias
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarTablaDias()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdListaDias.DataSource = Nothing
        txtNombreDia.Text = ""
        rdoSi.Checked = True
        IdDia = 0
        Nombre = ""
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbDias.Height = 39
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbDias.Height = 102
    End Sub


    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        AgregarOModificar = True

        Dim formaDias As New EditarAgregarDiaForm
        'formaDias.MdiParent = Me.MdiParent
        formaDias.IdDia = IdDia
        formaDias.Nombre = Nombre
        formaDias.AgregarOModificar = AgregarOModificar
        formaDias.ShowDialog()
        llenarTablaDias()
    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        AgregarOModificar = False

        If IdDia = 0 Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else

            Dim formaDias As New EditarAgregarDiaForm
            'formaDias.MdiParent = Me.MdiParent
            formaDias.IdDia = IdDia
            formaDias.Nombre = Nombre
            formaDias.Activo = Activo
            formaDias.AgregarOModificar = AgregarOModificar
            formaDias.ShowDialog()
            llenarTablaDias()
        End If

    End Sub


    Private Sub grdListaDias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaDias.BeforeRowsDeleted
        'If MsgBox("estas seguro de borrar", MsgBoxStyle.YesNo, "hey!!!") = MsgBoxResult.Ok Then
        'Else
        e.Cancel = True
        'End If
    End Sub


    Private Sub gridListaDias_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListaDias.InitializeLayout
        With grdListaDias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Bands(0).Columns(1).Width = 300 'Ajusta la columna indicada a un tamaño manualmente asignado.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With

    End Sub


    Private Sub grdListaDias_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaDias.ClickCell
        Dim row As UltraGridRow = grdListaDias.ActiveRow
        If row.IsFilterRow Then Return
        IdDia = CInt(row.Cells(0).Text)
        Nombre = CStr(row.Cells(1).Text)
        Activo = CBool(row.Cells(2).Value)
    End Sub


    Private Sub CatalogoDiasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
    End Sub


End Class