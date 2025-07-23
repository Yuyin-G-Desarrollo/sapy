Imports Tools

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CatalogoRutasForm

    ''VARIABLES PARA LA SELECCION Y EDICION Y ENVIARLE VALORES A EL FORMULARIO DE ALTA Y CAMBIOS
    Dim altasCambios As Boolean
    Dim IdRuta As Int32
    Dim Nombre As String
    Dim activo As Boolean

    ''Botónes arriba y abajo para 
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbRutas.Height = 37
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbRutas.Height = 102
    End Sub

    ''Boton Limpiar
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaRutas.DataSource = Nothing
        txtNombreRuta.Text = ""

        IdRuta = 0
        Nombre = ""

    End Sub

    '' Darle  forma al grid.
    Private Sub gridListaRamos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridListaRutas.InitializeLayout

        With gridListaRutas
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


    Public Sub LlenarTablaRutas()
        ''Limpiar los datos de la tabla cada vez que presione el boton de buscar.
        gridListaRutas.DataSource = Nothing
        IdRuta = 0
        Nombre = ""

        ''Declaracion del objeto para llamar los metodos de la capa de negocios.
        Dim objBU As New Negocios.CatalogoRutasBU

        Dim TablaRutas As New DataTable

        ''Asignación de valores a las variables.
        Nombre = txtNombreRuta.Text
        If rdoSi.Checked = False Then
            activo = False
        Else
            activo = True
        End If

        TablaRutas = objBU.ListaRutas(activo, Nombre)

        ''Envíamos los datos al metodo de llenar Grid.
        gridListaRutas.DataSource = TablaRutas
    End Sub

    'Botón buscar
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarTablaRutas()
    End Sub

    'Boton para agregar rutas
    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        altasCambios = True
        Dim formaRutas As New AgregarEditarRutasForm
        formaRutas.IdRuta = IdRuta
        formaRutas.nombre = Nombre
        formaRutas.activo = activo
        formaRutas.AgregarOModificar = altasCambios
        formaRutas.ShowDialog()
        LlenarTablaRutas()
    End Sub

    'Botón para modificar rutas
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If IdRuta = 0 And Nombre = "" Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else
            altasCambios = False
            Dim formaRutas As New AgregarEditarRutasForm
            formaRutas.IdRuta = IdRuta
            formaRutas.nombre = Nombre
            formaRutas.activo = activo
            formaRutas.AgregarOModificar = altasCambios
            formaRutas.ShowDialog()
            LlenarTablaRutas()
        End If
    End Sub


    Private Sub CatalogoRutasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
    End Sub

    Private Sub gridListaRutas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaRutas.ClickCell
        Dim row As UltraGridRow = gridListaRutas.ActiveRow
        If row.IsFilterRow Then Return
        IdRuta = CInt(row.Cells(0).Text)
        Nombre = CStr(row.Cells(1).Text)
        activo = CBool(row.Cells(2).Value)
    End Sub

    Private Sub gridListaRutas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridListaRutas.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class