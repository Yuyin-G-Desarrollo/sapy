Imports Tools

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CatalogoRamosForm

    ''VARIABLES PARA LA SELECCION Y EDICION Y ENVIARLE VALORES A EL FORMULARIO DE ALTA Y CAMBIOS
    Dim altasCambios As Boolean
    Dim IdForma As Int32
    Dim Nombre As String
    Dim NombreCorto As String
    Dim activo As Boolean
    Dim sicyID As Integer

    '' botones arriba abajo.
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbRamos.Height = 39
        grbRamos.Top = 126
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbRamos.Height = 135
        grbRamos.Top = 126
    End Sub

    Public Sub LlenarListaRamos()
        ''Limpiar los datos de la tabla cada vez que presione el boton de buscar.
        gridListaRamos.DataSource = Nothing
        IdForma = 0
        Nombre = ""
        NombreCorto = ""


        ''Declaracion del objeto para llamar los metodos de la capa de negocios.
        Dim objBU As New Negocios.CatalogoRamosBU

        Dim TablaRamos As New DataTable

        ''Asignación de valores a las variables.
        Nombre = txtNombreRamo.Text
        NombreCorto = txtNombreCortoRamo.Text
        If rdoSi.Checked = False Then
            activo = False
        Else
            activo = True
        End If

        TablaRamos = objBU.ListaRamos(activo, Nombre, NombreCorto)

        ''Envíamos los datos al metodo de llenar Grid.
        gridListaRamos.DataSource = TablaRamos
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarListaRamos()
    End Sub

    '' Darle  forma al grid.
    Private Sub gridListaRamos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridListaRamos.InitializeLayout

        With gridListaRamos

            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True

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

    ''boton limpiar.
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaRamos.DataSource = Nothing
        txtNombreCortoRamo.Text = ""
        txtNombreRamo.Text = ""

        Dim IdForma = 0
        Dim Nombre = ""
        Dim NombreCorto = ""

    End Sub

    ''Botón Agregar
    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        altasCambios = True
        Dim formaRamos As New AgregarEditarRamosForm
        formaRamos.IdForma = IdForma
        formaRamos.nombre = Nombre
        formaRamos.nombrecorto = NombreCorto
        formaRamos.activo = activo
        formaRamos.AgregarOModificar = altasCambios
        formaRamos.ShowDialog()
        LlenarListaRamos()
    End Sub

    ''Botón editar
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

        If IdForma = 0 And Nombre = "" And NombreCorto = "" Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else
            altasCambios = False
            Dim formaRamos As New AgregarEditarRamosForm
            formaRamos.IdForma = IdForma
            formaRamos.Nombre = Nombre
            formaRamos.NombreCorto = NombreCorto
            formaRamos.activo = activo
            formaRamos.sicyID =
            formaRamos.AgregarOModificar = altasCambios
            formaRamos.sicyID = sicyID
            formaRamos.ShowDialog()
            LlenarListaRamos()

        End If
    End Sub


    Private Sub gridListaRamos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridListaRamos.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub gridListaRamos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridListaRamos.ClickCell
        Dim row As UltraGridRow = gridListaRamos.ActiveRow
        If row.IsFilterRow Then Return
        IdForma = CInt(row.Cells(0).Text)
        Nombre = CStr(row.Cells(1).Text)
        NombreCorto = CStr(row.Cells(2).Text)
        activo = CBool(row.Cells(3).Value)
        sicyID = CInt(row.Cells(4).Value)
    End Sub

    Private Sub CatalogoRamosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
    End Sub


End Class