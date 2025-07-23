Imports Tools

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win


Public Class CatalogoTiposDeTiendaForm

    Dim AgregarOModificar As Boolean
    Dim IdTipoTienda As Int32
    Dim Nombre As String
    Dim activo As Boolean


    'Botónes arriba y abajo
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbTiposDeTienda.Height = 39
        grbTiposDeTienda.Top = 126
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbTiposDeTienda.Height = 102
        grbTiposDeTienda.Top = 102
    End Sub

    'Botón limpiar
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaTiposDeTienda.DataSource = Nothing
        IdTipoTienda = 0
        txtNombreTipoDeTienda.Text = ""
        Nombre = ""
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        AgregarOModificar = True
        Dim formaTiposTienda As New AgregarEditarTiposDeTiendaForm
        formaTiposTienda.IdTipoTienda = IdTipoTienda
        formaTiposTienda.Nombre = Nombre
        formaTiposTienda.activo = activo
        formaTiposTienda.AgregarOModificar = AgregarOModificar
        formaTiposTienda.ShowDialog()
        LlenarTablaTiposTienda()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If IdTipoTienda = 0 And Nombre = "" Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else
            AgregarOModificar = False
            Dim formaTiposTienda As New AgregarEditarTiposDeTiendaForm
            formaTiposTienda.IdTipoTienda = IdTipoTienda
            formaTiposTienda.Nombre = Nombre
            formaTiposTienda.activo = activo
            formaTiposTienda.AgregarOModificar = AgregarOModificar
            formaTiposTienda.ShowDialog()
            LlenarTablaTiposTienda()
        End If
    End Sub


    Public Sub LlenarTablaTiposTienda()
        ''Limpiar los datos de la tabla cada vez que presione el boton de buscar.
        gridListaTiposDeTienda.DataSource = Nothing
        IdTipoTienda = 0
        Nombre = ""

        ''Declaracion del objeto para llamar los metodos de la capa de negocios.
        Dim objBU As New Negocios.CatalogoTiposDeTiendaBU
        Dim TablaRutas As New DataTable

        ''Asignación de valores a las variables.
        Nombre = txtNombreTipoDeTienda.Text
        If rdoSi.Checked = False Then
            activo = False
        Else
            activo = True
        End If
        TablaRutas = objBU.ListaTipoTienda(activo, Nombre)

        ''Envíamos los datos al metodo de llenar Grid.
        gridListaTiposDeTienda.DataSource = TablaRutas
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarTablaTiposTienda()
    End Sub

    Private Sub CatalogoTiposDeTiendaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
    End Sub

    'Formato del grid
    Private Sub gridListaTiposDeTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridListaTiposDeTienda.InitializeLayout
        With gridListaTiposDeTienda

            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub gridListaTiposDeTienda_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaTiposDeTienda.ClickCell
        Dim row As UltraGridRow = gridListaTiposDeTienda.ActiveRow
        If row.IsFilterRow Then Return
        IdTipoTienda = CInt(row.Cells(0).Text)
        Nombre = CStr(row.Cells(1).Text)
        activo = CBool(row.Cells(2).Value)
    End Sub

    Private Sub gridListaTiposDeTienda_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridListaTiposDeTienda.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub txtNombreTipoDeTienda_TextChanged(sender As Object, e As EventArgs) Handles txtNombreTipoDeTienda.TextChanged

    End Sub
End Class