Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class FiltrosConsultaParesSalidas

    Dim listPares As New List(Of String)
    Dim listAtados As New List(Of String)
    Dim listPedidos As New List(Of String)
    Dim listLotes As New DataTable
    Dim listInicial As New List(Of String)
    Dim perfilId As Integer = 0

    Private Sub FiltrosConsultaParesSalidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.SalidasAlmacenBU

        Me.Top = 0
        Me.Left = 0

        listLotes = New DataTable
        listLotes.Columns.Add("Lote")
        listLotes.Columns.Add("AnioLote")
        listLotes.Columns("AnioLote").Caption = "Año"

        gridPares.DataSource = listPares
        gridAtados.DataSource = listAtados
        gridPedidos.DataSource = listPedidos
        gridLotes.DataSource = listLotes
        gridClientes.DataSource = listInicial
        gridNaves.DataSource = listInicial
        gridTiendas.DataSource = listInicial
        gridProductos.DataSource = listInicial
        gridCorridas.DataSource = listInicial
        gridTallas.DataSource = listInicial

        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)

        dtResultadoPerfil = objBU.consultaPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilId = dtResultadoPerfil.Rows(0).Item("perfilId")
        End If
    End Sub

    Private Sub txtPares_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPares.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPares.Text) Then Return

            listPares.Add(txtPares.Text)
            gridPares.DataSource = Nothing
            gridPares.DataSource = listPares

            txtPares.Text = String.Empty

        End If
    End Sub

    Private Sub gridPares_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridPares.InitializeLayout
        grid_diseño(gridPares)
        gridPares.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Par"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    'Asigna formato a columnas de ultragrid
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

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

    Private Sub txtAtados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtados.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtAtados.Text) Then Return

            listAtados.Add(txtAtados.Text)
            gridAtados.DataSource = Nothing
            gridAtados.DataSource = listAtados

            txtAtados.Text = String.Empty

        End If
    End Sub

    Private Sub gridAtados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridAtados.InitializeLayout
        grid_diseño(gridAtados)
        gridAtados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atado"
    End Sub

    Private Sub gridPares_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPares.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPares.DeleteSelectedRows(False)
    End Sub

    Private Sub gridAtados_KeyDown(sender As Object, e As KeyEventArgs) Handles gridAtados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridAtados.DeleteSelectedRows(False)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedido.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedido.Text) Then Return

            listPedidos.Add(txtPedido.Text)
            gridPedidos.DataSource = Nothing
            gridPedidos.DataSource = listPedidos

            txtPedido.Text = String.Empty

        End If
    End Sub

    Private Sub gridPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPedidos.InitializeLayout
        grid_diseño(gridPedidos)
        gridPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub gridPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPedidos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPedidos.DeleteSelectedRows(False)
    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLote.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text) Then Return

            Dim newRowLote As DataRow
            newRowLote = listLotes.NewRow
            newRowLote.Item(0) = txtLote.Text.Trim
            newRowLote.Item(1) = txtAnioLote.Text.Trim
            listLotes.Rows.Add(newRowLote)
            gridLotes.DataSource = Nothing
            gridLotes.DataSource = listLotes

            txtLote.Text = String.Empty
            txtAnioLote.Text = String.Empty
        End If
    End Sub

    Private Sub txtAnioLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAnioLote.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text.Trim) Then
                If String.IsNullOrEmpty(txtAnioLote.Text.Trim) Then Return
                MsgBox("Debe Ingresar un Lote")
                txtAnioLote.Text = String.Empty
            Else
                Dim newRowLote As DataRow
                newRowLote = listLotes.NewRow
                newRowLote.Item(0) = txtLote.Text
                newRowLote.Item(1) = txtAnioLote.Text
                listLotes.Rows.Add(newRowLote)
                gridLotes.DataSource = Nothing
                gridLotes.DataSource = listLotes
                txtLote.Text = String.Empty
                txtAnioLote.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub gridLotes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridLotes.InitializeLayout
        grid_simple_diseño(gridLotes)
        gridLotes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Lote"
    End Sub

    Private Sub gridLotes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridLotes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridLotes.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_simple_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridProductos.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridProductos.DataSource = listado.listParametros
        With gridProductos
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Producto"
        End With
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridClientes.DataSource = listado.listParametros
        With gridClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub gridClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridClientes.InitializeLayout
        grid_diseño(gridClientes)
        gridClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub gridClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridClientes.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridPares.DataSource = Nothing
        txtPares.Text = ""
        gridAtados.DataSource = Nothing
        txtAtados.Text = ""
        gridLotes.DataSource = Nothing
        txtLote.Text = ""
        txtAnioLote.Text = ""
        gridNaves.DataSource = Nothing
        gridPedidos.DataSource = Nothing
        txtPedido.Text = ""
        gridClientes.DataSource = Nothing
        gridTiendas.DataSource = Nothing
        gridProductos.DataSource = Nothing
        gridCorridas.DataSource = Nothing
        gridTallas.DataSource = Nothing
        rbtnY.Checked = True
    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 4
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridNaves.DataSource = listado.listParametros
        With gridNaves
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Nave"
        End With
    End Sub

    Private Sub btnTiendas_Click(sender As Object, e As EventArgs) Handles btnTiendas.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 5
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridTiendas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridTiendas.DataSource = listado.listParametros
        With gridTiendas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tienda"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridCorridas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridCorridas.DataSource = listado.listParametros
        With gridCorridas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Corrida"
        End With
    End Sub

    Private Sub btnTallas_Click(sender As Object, e As EventArgs) Handles btnTallas.Click
        Dim listado As New ListadoParametroSalidasForm
        listado.tipo_busqueda = 8
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridTallas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridTallas.DataSource = listado.listParametros
        With gridTallas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Talla"
        End With
    End Sub

    Private Sub gridTiendas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTiendas.InitializeLayout
        grid_diseño(gridTiendas)
        gridTiendas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda"
    End Sub

    Private Sub gridProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridProductos.InitializeLayout
        grid_diseño(gridProductos)
        gridProductos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Producto"
    End Sub

    Private Sub gridCorridas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCorridas.InitializeLayout
        grid_diseño(gridCorridas)
        gridCorridas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub gridTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTallas.InitializeLayout
        grid_diseño(gridTallas)
        gridTallas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Talla"
    End Sub

    Private Sub gridTiendas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTiendas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTiendas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles gridNaves.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridNaves.DeleteSelectedRows(False)
    End Sub

    Private Sub gridProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridProductos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridProductos.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCorridas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCorridas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCorridas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridTallas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTallas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridNaves.InitializeLayout
        grid_diseño(gridNaves)
        gridNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Dim objFiltrosParesEmbarquesSalidas As New Entidades.FiltrosParesEmbarquesSalidas
        Dim lPares As String = String.Empty
        Dim lAtados As String = String.Empty
        Dim lLotes As String = String.Empty
        Dim lAñosLotes As String = String.Empty
        Dim lNaves As String = String.Empty
        Dim lPedidos As String = String.Empty
        Dim lClientes As String = String.Empty
        Dim lTiendas As String = String.Empty
        Dim lProductos As String = String.Empty
        Dim lCorridas As String = String.Empty
        Dim lTallas As String = String.Empty
        Dim FiltroY_O As String = String.Empty
        Dim Cedis As Integer = 0

        For Each row As UltraGridRow In gridPares.Rows
            If row.Index = 0 Then
                lPares += "'" + row.Cells(0).Text + "'"
            Else
                lPares += ", '" + row.Cells(0).Text + "'"
            End If
        Next

        For Each row As UltraGridRow In gridAtados.Rows
            If row.Index = 0 Then
                lAtados += "'" + row.Cells(0).Text + "'"
            Else
                lAtados += ", '" + row.Cells(0).Text + "'"
            End If
        Next

        For Each row As UltraGridRow In gridLotes.Rows
            If row.Index = 0 Then
                lLotes += row.Cells(0).Text
                If row.Cells(1).Text.ToString.Trim <> "" Then
                    lAñosLotes += row.Cells(1).Text
                End If
            Else
                lLotes += ", " + row.Cells(0).Text
                If row.Cells(1).Text.ToString.Trim <> "" Then
                    lAñosLotes += ", " + row.Cells(1).Text
                End If
            End If
        Next

        For Each row As UltraGridRow In gridNaves.Rows
            If row.Index = 0 Then
                lNaves += row.Cells("Parámetro").Text
            Else
                lNaves += ", " + row.Cells("Parámetro").Text
            End If
        Next

        For Each row As UltraGridRow In gridPedidos.Rows
            If row.Index = 0 Then
                lPedidos += row.Cells(0).Text
            Else
                lPedidos += ", " + row.Cells(0).Text
            End If
        Next

        For Each row As UltraGridRow In gridClientes.Rows
            If row.Index = 0 Then
                lClientes += row.Cells("Parámetro").Text
            Else
                lClientes += ", " + row.Cells("Parámetro").Text
            End If
        Next

        For Each row As UltraGridRow In gridTiendas.Rows
            If row.Index = 0 Then
                lTiendas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lTiendas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        For Each row As UltraGridRow In gridProductos.Rows
            If row.Index = 0 Then
                lProductos += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lProductos += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        For Each row As UltraGridRow In gridCorridas.Rows
            If row.Index = 0 Then
                lCorridas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lCorridas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        For Each row As UltraGridRow In gridTallas.Rows
            If row.Index = 0 Then
                lTallas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lTallas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        If rbtnY.Checked Then
            FiltroY_O = "Y"
        End If

        If rbtnO.Checked Then
            FiltroY_O = "O"
        End If

        Cedis = cboxNaveAlmacen.SelectedValue

        If lPares = "" And lAtados = "" And lLotes = "" And lAñosLotes = "" And lNaves = "" And lPedidos = "" And lClientes = "" And lTiendas = "" And lProductos = "" And lCorridas = "" And lTallas = "" Then
            If perfilId = 74 Then
                show_message("Advertencia", "Debe seleccionar al menos un cliente")
            Else
                show_message("Advertencia", "Debe seleccionar al menos un filtro")
            End If
        Else
            objFiltrosParesEmbarquesSalidas.PCodigosPar = lPares
            objFiltrosParesEmbarquesSalidas.PCodigosAtado = lAtados
            objFiltrosParesEmbarquesSalidas.PLotes = lLotes
            objFiltrosParesEmbarquesSalidas.PAñosLotes = lAñosLotes
            objFiltrosParesEmbarquesSalidas.PNaves = lNaves
            objFiltrosParesEmbarquesSalidas.PPedidos = lPedidos
            objFiltrosParesEmbarquesSalidas.PClientes = lClientes
            objFiltrosParesEmbarquesSalidas.PTiendas = lTiendas
            objFiltrosParesEmbarquesSalidas.PProductos = lProductos
            objFiltrosParesEmbarquesSalidas.PCorridas = lCorridas
            objFiltrosParesEmbarquesSalidas.PTallas = lTallas
            objFiltrosParesEmbarquesSalidas.PFiltroY_O = FiltroY_O
            objFiltrosParesEmbarquesSalidas.PCedis = Cedis


            Dim consultaPares As New ConsultarParesSalidaAlmacenForm(objFiltrosParesEmbarquesSalidas)
            consultaPares.MdiParent = Me.MdiParent
            consultaPares.Show()

        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

End Class