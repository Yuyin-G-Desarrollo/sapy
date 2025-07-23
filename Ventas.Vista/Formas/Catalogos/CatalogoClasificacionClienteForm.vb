Imports Tools

Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class CatalogoClasificacionClienteForm

    ''VARIABLES PARA LA SELECCION Y EDICION Y ENVIARLE VALORES A EL FORMULARIO DE ALTA Y CAMBIOS
    Dim altasOCambios As Boolean
    Dim IdClasificacion As String
    Dim Nombre As String
    Dim activo As Boolean


    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpTiposDeTienda.Height = 37
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpTiposDeTienda.Height = 101
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdListaClasificacionClientes.DataSource = Nothing
        txtNombreClasificacionCliente.Text = ""
        IdClasificacion = ""
        Nombre = ""
    End Sub


    Public Sub llenarTablaClasificaion()
        ''Limpiar los datos de la tabla cada vez que presione el boton de buscar.
        grdListaClasificacionClientes.DataSource = Nothing
        IdClasificacion = ""
        Nombre = ""
        activo = True


        ''Declaracion del objeto para llamar los metodos de la capa de negocios.
        Dim objBU As New Negocios.CatalogoClasificacionClienteBU

        Dim TablaClasificacion As New DataTable

        ''Asignación de valores a las variables.
        Nombre = txtNombreClasificacionCliente.Text
        If rdoSi.Checked = True Then
            activo = True
        Else
            activo = False
        End If

        TablaClasificacion = objBU.ListaClasificacionCliente(activo, Nombre)
        ''Envíamos los datos al metodo de llenar Grid.
        grdListaClasificacionClientes.DataSource = TablaClasificacion
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarTablaClasificaion()
    End Sub


    Private Sub gridListaClasificacionClientes_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdListaClasificacionClientes.InitializeLayout
        asignaFormato_Columna(grdListaClasificacionClientes)

        With grdListaClasificacionClientes

            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Bands(0).Columns(0).Width = 7%
            .DisplayLayout.Bands(0).Columns(1).Width = 83%
            .DisplayLayout.Bands(0).Columns(2).Width = 10%


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



    Private Sub grdListaClasificacionClientes_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListaClasificacionClientes.ClickCell
        Dim row As UltraGridRow = grdListaClasificacionClientes.ActiveRow
        If row.IsFilterRow Then Return
        IdClasificacion = CStr(row.Cells(0).Text)
        Nombre = CStr(row.Cells(1).Text)
        activo = CBool(row.Cells(3).Value)
    End Sub


    Private Sub grdListaClasificacionClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaClasificacionClientes.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        altasOCambios = True
        Dim formaClasificacion As New AgregarEditarClasificacionClienteForm
        formaClasificacion.IdClasificacion = IdClasificacion
        formaClasificacion.Nombre = Nombre
        formaClasificacion.activo = activo
        formaClasificacion.altasOCambios = altasOCambios

        formaClasificacion.ShowDialog()

        llenarTablaClasificaion()

    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If IdClasificacion = "" And Nombre = "" Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Realiza una consulta y selecciona la fila que contenga los datos que deseas modificar antes de dar click en el botón 'Editar'!"
            FormularioError.ShowDialog()
        Else
            altasOCambios = False
            Dim formaClasificacion As New AgregarEditarClasificacionClienteForm

            formaClasificacion.IdClasificacion = IdClasificacion
            formaClasificacion.Nombre = Nombre
            formaClasificacion.activo = activo
            formaClasificacion.altasOCambios = altasOCambios

            formaClasificacion.ShowDialog()

            llenarTablaClasificaion()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class