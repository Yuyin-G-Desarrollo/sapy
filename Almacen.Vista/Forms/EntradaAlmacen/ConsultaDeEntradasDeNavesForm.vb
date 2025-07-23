Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools


Public Class ConsultaDeEntradasDeNavesForm

    Dim lLotes As New List(Of String)
    Dim lAtados As New List(Of String)
    Dim lPedidos As New List(Of String)
    Dim lNaves As String



    Private Sub ConsultaDeEntradasDeNavesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtInformacionCentroDistribucion As DataTable
        Dim dtNumeroAlmacenes As DataTable
        Dim tipo As Integer

        dtpFinEntrada.Value = Now.Date
        dtpFinEntrada.MaxDate = Now.Date
        dtpFinPrograma.Value = Now.Date
        dtpFinPrograma.MaxDate = Now.Date
        dtpInicioEntrada.Value = Now.Date
        dtpInicioEntrada.MaxDate = Now.Date
        dtpInicioPrograma.Value = Now.Date
        dtpInicioPrograma.MaxDate = Now.Date

        chboxFiltrarFechaPrograma.Checked = False

        'POBLAR COMBO NAVES
        cmbUNavesIdSicy = Tools.Controles.UltraComboNaves_IdSicy(cmbUNavesIdSicy)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "CONSULTAR_AMBAS_COMERC") Then
            tipo = 1
            dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuarioTipo(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, tipo)
        Else
            tipo = 0
            dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuarioTipo(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, tipo)
        End If
        cboxNave.DataSource = dtInformacionCentroDistribucion
        cboxNave.DisplayMember = "Nave"
        cboxNave.ValueMember = "NaveSAYID"

        cboxNave.SelectedIndex = 0
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "CONSULTAR_AMBAS_COMERC") Then
            cboxNave.SelectedIndex = 1
            If cboxNave.SelectedIndex = 1 Then
                dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNave.SelectedValue)
                cboxAlmacen.DataSource = dtNumeroAlmacenes
                cboxAlmacen.ValueMember = "NumeroAlmacen"
                cboxAlmacen.DisplayMember = "NumeroAlmacen"
                cboxAlmacen.SelectedIndex = 0
            End If
            cboxNave.SelectedIndex = 0
        Else
            If cboxNave.SelectedIndex = 0 Then
                dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNave.SelectedValue)
                cboxAlmacen.DataSource = dtNumeroAlmacenes
                cboxAlmacen.ValueMember = "NumeroAlmacen"
                cboxAlmacen.DisplayMember = "NumeroAlmacen"
                cboxAlmacen.SelectedIndex = 0
            End If
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "UBICACION_ENTRADAS") Then
            chboxConUbicacion.Checked = False
            chboxConUbicacion.Visible = True
        Else
            chboxConUbicacion.Checked = False
            chboxConUbicacion.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "IMPRIMIR_OTROS") And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "IMPRIMIR_OTROS_VENTAS") Then
            btnExportarOtros.Visible = True
            lblExportarOtros.Visible = True
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "IMPRIMIR_OTROS") Then
            btnExportarOtros.Visible = True
            lblExportarOtros.Visible = True
            ProduccionPorNaveConImportesToolStripMenuItem.Visible = False
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_CONSULTAENTRADAS", "IMPRIMIR_OTROS_VENTAS") Then
            btnExportarOtros.Visible = True
            lblExportarOtros.Visible = True
            ResumenDeProductosToolStripMenuItem.Visible = False
        Else
            btnExportarOtros.Visible = False
            lblExportarOtros.Visible = False
        End If


    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim listado As New ListaParametrosConsultaEntradasNavesForm
        listado.id_tipo_busqueda = 4
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdProductos.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.lParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.dtParametros.Rows.Count = 0 Then Return
        grdProductos.DataSource = listado.dtParametros
        With grdProductos
            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Productos"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
        End With
    End Sub

    Private Sub btnTiendas_Click(sender As Object, e As EventArgs) Handles btnTiendas.Click
        Dim listado As New ListaParametrosConsultaEntradasNavesForm
        listado.id_tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTiendas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.lParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.dtParametros.Rows.Count = 0 Then Return
        grdTiendas.DataSource = listado.dtParametros
        With grdTiendas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tiendas"
        End With
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim listado As New ListaParametrosConsultaEntradasNavesForm
        listado.id_tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.lParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.dtParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.dtParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListaParametrosConsultaEntradasNavesForm
        listado.id_tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCorridas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.lParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.dtParametros.Rows.Count = 0 Then Return
        grdCorridas.DataSource = listado.dtParametros
        With grdCorridas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Corridas"
        End With
    End Sub

    Private Sub btnLotes_Click(sender As Object, e As EventArgs)
        Dim listado As New ListaParametrosConsultaEntradasNavesForm
        listado.id_tipo_busqueda = 5
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdLotes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.lParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.dtParametros.Rows.Count = 0 Then Return
        grdLotes.DataSource = listado.dtParametros
        With grdLotes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Corridas"
        End With
    End Sub

#Region "Grids"

    Private Sub grdProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProductos.InitializeLayout
        grid_diseño(grdProductos)
        grdProductos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Productos"
    End Sub

    Private Sub grdAtados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtados.InitializeLayout
        grid_simple_diseño(grdAtados)
        grdAtados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código de Atado"
    End Sub

    Private Sub grdLotes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdLotes.InitializeLayout
        grid_simple_diseño(grdLotes)
        grdLotes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Lotes"
    End Sub

    Private Sub grdPedidos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidos.InitializeLayout
        grid_simple_diseño(grdPedidos)
        grdPedidos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedidos"
    End Sub

    Private Sub grdTiendas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTiendas.InitializeLayout
        grid_diseño(grdTiendas)
        grdTiendas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tiendas"
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdCorridas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorridas.InitializeLayout
        grid_diseño(grdCorridas)
        grdCorridas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corridas"
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

#End Region

#Region "Text Box"

    Public Function txtNumericoSinDecimales(ByVal txtControl As MaskedTextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = False Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub txtAtados_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtados.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtAtados.Text) Then Return

            If IsNumeric(txtAtados.Text) Then

                If txtAtados.Text.Length <= 13 And txtAtados.Text.Length >= 10 Then

                    lAtados.Add(txtAtados.Text)
                    grdAtados.DataSource = Nothing
                    grdAtados.DataSource = lAtados

                    txtAtados.Text = String.Empty

                Else
                    show_message("Aviso", "Código de atado inválido")
                End If
            Else
                show_message("Aviso", "Código de atado inválido")
            End If
        Else
            e.Handled = txtNumericoSinDecimales(txtAtados, e.KeyChar, True)
        End If

    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLotes.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLotes.Text) Then Return
            lLotes.Add(txtLotes.Text)
            grdLotes.DataSource = Nothing
            grdLotes.DataSource = lLotes
            txtLotes.Text = String.Empty
        Else
            e.Handled = txtNumericoSinDecimales(txtLotes, e.KeyChar, True)
        End If
    End Sub

    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedido.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedido.Text) Then Return
            lPedidos.Add(txtPedido.Text)
            grdPedidos.DataSource = Nothing
            grdPedidos.DataSource = lPedidos
            txtPedido.Text = String.Empty
        Else
            e.Handled = txtNumericoSinDecimales(txtPedido, e.KeyChar, True)
        End If
    End Sub

#End Region

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

            mensajeExito.ShowDialog()
        End If
    End Sub


    Private Sub grids_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProductos.KeyDown, grdPedidos.KeyDown, grdLotes.KeyDown, grdCorridas.KeyDown, grdClientes.KeyDown, grdAtados.KeyDown, grdTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAtados.DeleteSelectedRows(False)
        grdClientes.DeleteSelectedRows(False)
        grdCorridas.DeleteSelectedRows(False)
        grdLotes.DeleteSelectedRows(False)
        grdPedidos.DeleteSelectedRows(False)
        grdProductos.DeleteSelectedRows(False)
        grdTiendas.DeleteSelectedRows(False)
    End Sub

    Public Function GenerarFiltros(grid As UltraGrid) As String
        Dim filtro As String = ""
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                filtro += "'" + row.Cells(0).Text + "'"
            Else
                filtro += ",'" + row.Cells(0).Text + "'"
            End If
        Next
        Return filtro
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'VALIDAMOS CAMPOS VACIOS


        'DECLARAMOS VARIABLES
        Dim lLotes As String = String.Empty
        Dim lAtados As String = String.Empty
        Dim lPedidos As String = String.Empty

        Dim lProductos As String = String.Empty
        Dim lClientes As String = String.Empty
        Dim lCorridas As String = String.Empty
        Dim lTiendas As String = String.Empty
        Dim lTallas As String = String.Empty


        'Dim lNave As String = String.Empty

        Dim fechaInicioEntradas As String = String.Empty
        Dim fechaTerminoEntradas As String = String.Empty

        Dim fechaInicioProgramas As String = String.Empty
        Dim fechaTerminoProgramas As String = String.Empty

        Dim bY_O As Boolean = rbtnY.Checked
        Dim filtroFechaPrograma As Boolean = chboxFiltrarFechaPrograma.Checked

        Dim form As New ListaEntradasaAlmacenFrom
        Dim filtros As New Entidades.EntradasAlmacen
        filtros.ComercializadoraId = cboxNave.SelectedValue

        filtros.Filtro = IIf(rbtnY.Checked = True, "AND", "OR")
        ''ATADOS
        'For Each row As UltraGridRow In grdAtados.Rows
        '    If row.Index = 0 Then
        '        lAtados += "'" + row.Cells(0).Text + "'"
        '    Else
        '        lAtados += ", '" + row.Cells(0).Text + "'"
        '    End If
        'Next
        'form.lAtados = lAtados
        filtros.Atados = GenerarFiltros(grdAtados)

        ''LOTES
        'For Each row As UltraGridRow In grdLotes.Rows
        '    If row.Index = 0 Then
        '        lLotes += "'" + row.Cells(0).Text + "'"
        '    Else
        '        lLotes += ", '" + row.Cells(0).Text + "'"
        '    End If
        'Next
        'form.lLotes = lLotes
        filtros.Lotes = GenerarFiltros(grdLotes)

        ''PEDIDOS
        For Each row As UltraGridRow In grdPedidos.Rows
            If row.Index = 0 Then
                lPedidos += "" + row.Cells(0).Text + ""
            Else
                lPedidos += ", " + row.Cells(0).Text + ""
            End If
        Next
        filtros.Pedidos = lPedidos
        'filtros.Pedidos = GenerarFiltros(grdPedidos)

        ''PRODUCTOS
        'For Each row As UltraGridRow In grdProductos.Rows
        '    If row.Index = 0 Then
        '        lProductos += "'" + row.Cells("Parámetro").Text + "'"
        '    Else
        '        lProductos += ", '" + row.Cells("Parámetro").Text + "'"
        '    End If
        'Next
        'form.lProductos = lProductos
        filtros.Productos = GenerarFiltros(grdProductos)

        ''TIENDAS
        'For Each row As UltraGridRow In grdTiendas.Rows
        '    If row.Index = 0 Then
        '        lTiendas += "'" + row.Cells("Parámetro").Text + "'"
        '    Else
        '        lTiendas += ", '" + row.Cells("Parámetro").Text + "'"
        '    End If
        'Next
        'form.lTiendas = lTiendas
        filtros.Tiendas = GenerarFiltros(grdTiendas)

        ''CLIENTES
        'For Each row As UltraGridRow In grdClientes.Rows
        '    If row.Index = 0 Then
        '        lClientes += "'" + row.Cells("Parámetro").Text + "'"
        '    Else
        '        lClientes += ", '" + row.Cells("Parámetro").Text + "'"
        '    End If
        'Next
        'form.lClientes = lClientes
        filtros.Clientes = GenerarFiltros(grdClientes)

        ''TIENDAS
        'For Each row As UltraGridRow In grdCorridas.Rows
        '    If row.Index = 0 Then
        '        lCorridas += "'" + row.Cells("Parámetro").Text + "'"
        '    Else
        '        lCorridas += ", '" + row.Cells("Parámetro").Text + "'"
        '    End If
        'Next
        'form.lCorridas = lCorridas
        filtros.Corridas = GenerarFiltros(grdCorridas)

        ''TALLAS
        'For Each row As UltraGridRow In grdTallas.Rows
        '    If row.Index = 0 Then
        '        lTallas += "'" + row.Cells("Parámetro").Text + "'"
        '    Else
        '        lTallas += ", '" + row.Cells("Parámetro").Text + "'"
        '    End If
        'Next
        'form.lTallas = lTallas
        filtros.Tallas = GenerarFiltros(grdTallas)

        ''FECHA ENTRADAS
        fechaInicioEntradas = dtpInicioEntrada.Value.ToShortDateString.ToString + " 00:00:00"
        fechaTerminoEntradas = dtpFinEntrada.Value.ToShortDateString.ToString + " 23:59:59"
        fechaInicioEntradas = DateTime.Parse(fechaInicioEntradas).ToString("yyyy/dd/MM HH:mm:ss")
        fechaTerminoEntradas = DateTime.Parse(fechaTerminoEntradas).ToString("yyyy/dd/MM HH:mm:ss")

        ''FECHA ENTRADAS
        If chboxFiltrarFechaPrograma.Checked = True Then
            fechaInicioProgramas = dtpInicioPrograma.Value.ToShortDateString.ToString + " 00:00:00"
            fechaTerminoProgramas = dtpFinPrograma.Value.ToShortDateString.ToString + " 23:59:59"
            fechaInicioProgramas = DateTime.Parse(fechaInicioProgramas).ToString("yyyy/dd/MM HH:mm:ss")
            fechaTerminoProgramas = DateTime.Parse(fechaTerminoProgramas).ToString("yyyy/dd/MM HH:mm:ss")
        End If


        'form.lNave = lNaves
        'form.bY_O = bY_O
        'form.filtroFechaPrograma = filtroFechaPrograma

        form.Ubicacion = chboxConUbicacion.Checked

        'form.fechaInicioEntradas = fechaInicioEntradas
        'form.fechaTerminoEntradas = fechaTerminoEntradas

        'form.fechaInicioProgramas = fechaInicioProgramas
        'form.fechaTerminoProgramas = fechaTerminoProgramas
        'form.EsPedidoActual = rdoPedidoActual.Checked
        'form.EsClienteActual = rdoClienteActual.Checked
        show_message("Aviso", "Este proceso puede tardar dependiendo de la cantidad de pares a buscar y el tipo de consulta(Con ó sin ubicación).")
        filtros.Nave = lNaves
        filtros.BY_O = bY_O
        'filtros.FiltroFechaPrograma = filtroFechaPrograma
        'filtros.FechaInicioEntradas = dtpInicioEntrada.Value
        'filtros.FechaTerminoEntradas = dtpFinEntrada.Value
        'filtros.FechaInicioProgramas = fechaInicioProgramas
        'filtros.FechaTerminoProgramas = fechaTerminoProgramas

        filtros.FiltroFechaPrograma = filtroFechaPrograma
        filtros.FechaInicioEntradas = fechaInicioEntradas
        filtros.FechaTerminoEntradas = fechaTerminoEntradas
        filtros.FechaInicioProgramas = fechaInicioProgramas
        filtros.FechaTerminoProgramas = fechaTerminoProgramas
        filtros.EsPedidoActual = rdoPedidoActual.Checked
        filtros.EsClienteActual = rdoClienteActual.Checked
        filtros.Ubicacion = chboxConUbicacion.Checked
        form.Filtros = filtros
        form.ShowDialog()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lLotes.Clear()
        lAtados.Clear()
        lPedidos.Clear()


        grdAtados.DataSource = Nothing
        grdClientes.DataSource = Nothing
        grdCorridas.DataSource = Nothing
        grdLotes.DataSource = Nothing
        grdPedidos.DataSource = Nothing
        grdProductos.DataSource = Nothing
        grdTiendas.DataSource = Nothing
        grdTallas.DataSource = Nothing

        txtAtados.Clear()
        txtLotes.Clear()
        txtPedido.Clear()

        chboxFiltrarFechaPrograma.Checked = False
        chboxConUbicacion.Checked = False

        dtpInicioEntrada.Value = Now.Date
        dtpFinEntrada.Value = Now.Date
        dtpInicioPrograma.Value = Now.Date
        dtpFinPrograma.Value = Now.Date

        LimpiarUltracombo()

    End Sub


    ''' <summary>
    ''' LIMPIA LOS ULTRACOMBOS EN EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LimpiarUltracombo()

        Dim contcmbUNAves As Int32 = cmbUNavesIdSicy.CheckedItems.Count

        If contcmbUNAves = 1 Then
            cmbUNavesIdSicy.SelectedItem.CheckState = CheckState.Unchecked
        ElseIf contcmbUNAves > 1 Then
            cmbUNavesIdSicy.Clear()
        End If
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub




    Private Sub btnTallas_Click(sender As Object, e As EventArgs) Handles btnTallas.Click
        Dim listado As New ListaParametrosConsultaEntradasNavesForm
        listado.id_tipo_busqueda = 5
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTallas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.lParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.dtParametros.Rows.Count = 0 Then Return
        grdTallas.DataSource = listado.dtParametros
        With grdTallas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corridas"
        End With

    End Sub


    Private Sub grdTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTallas.InitializeLayout
        grid_diseño(grdTallas)
        grdTallas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tallas"
    End Sub


    Private Sub cmbUNavesIdSicy_ValueChanged(sender As Object, e As EventArgs) Handles cmbUNavesIdSicy.ValueChanged
        Dim dtDatosFiltrados As New DataTable
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        datosCombo = Me.cmbUNavesIdSicy.Value
        dtsCmbFiltro = Me.cmbUNavesIdSicy.Items.ValueList

        If Not datosCombo Is Nothing Then
            Dim index As Int32 = -1
            lNaves = ""
            For Each value As Object In datosCombo
                Dim text As String = value
                If lNaves = "" Then
                    lNaves += text
                Else
                    lNaves += "," + text
                End If
            Next
        Else
            lNaves = String.Empty
        End If



    End Sub

    Private Sub btnExportarOtros_Click(sender As Object, e As EventArgs) Handles btnExportarOtros.Click

        cmsExportarOtros.Show(btnExportarOtros, 0, btnExportarOtros.Height)
    End Sub


    Private Sub ResumenDeProductosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ResumenDeProductosToolStripMenuItem.Click
        chboxConUbicacion.Checked = False
        Dim objExportarOtros As New ResumenDeProductosParaProveedoresForm
        objExportarOtros.WindowState = 2

        Dim lLotes As String = String.Empty
        Dim lAtados As String = String.Empty
        Dim lPedidos As String = String.Empty
        Dim lProductos As String = String.Empty
        Dim lClientes As String = String.Empty
        Dim lCorridas As String = String.Empty
        Dim lTiendas As String = String.Empty
        Dim lTallas As String = String.Empty
        Dim fechaInicioEntradas As String = String.Empty
        Dim fechaTerminoEntradas As String = String.Empty
        Dim fechaInicioProgramas As String = String.Empty
        Dim fechaTerminoProgramas As String = String.Empty
        Dim bY_O As Boolean = rbtnY.Checked
        Dim filtroFechaPrograma As Boolean = chboxFiltrarFechaPrograma.Checked

        ''ATADOS
        For Each row As UltraGridRow In grdAtados.Rows
            If row.Index = 0 Then
                lAtados += "'" + row.Cells(0).Text + "'"
            Else
                lAtados += ", '" + row.Cells(0).Text + "'"
            End If
        Next

        ''LOTES
        For Each row As UltraGridRow In grdLotes.Rows
            If row.Index = 0 Then
                lLotes += "'" + row.Cells(0).Text + "'"
            Else
                lLotes += ", '" + row.Cells(0).Text + "'"
            End If
        Next

        ''PEDIDOS
        For Each row As UltraGridRow In grdPedidos.Rows
            If row.Index = 0 Then
                lPedidos += "" + row.Cells(0).Text + ""
            Else
                lPedidos += ", " + row.Cells(0).Text + ""
            End If
        Next

        ''PRODUCTOS
        For Each row As UltraGridRow In grdProductos.Rows
            If row.Index = 0 Then
                lProductos += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lProductos += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''TIENDAS
        For Each row As UltraGridRow In grdTiendas.Rows
            If row.Index = 0 Then
                lTiendas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lTiendas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''CLIENTES
        For Each row As UltraGridRow In grdClientes.Rows
            If row.Index = 0 Then
                lClientes += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lClientes += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''TIENDAS
        For Each row As UltraGridRow In grdCorridas.Rows
            If row.Index = 0 Then
                lCorridas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lCorridas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next


        ''TALLAS
        For Each row As UltraGridRow In grdTallas.Rows
            If row.Index = 0 Then
                lTallas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lTallas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''FECHA ENTRADAS
        fechaInicioEntradas = dtpInicioEntrada.Value.ToShortDateString.ToString + " 00:00:00"
        fechaTerminoEntradas = dtpFinEntrada.Value.ToShortDateString.ToString + " 23:59:59"
        fechaInicioEntradas = DateTime.Parse(fechaInicioEntradas).ToString("yyyy/dd/MM HH:mm:ss")
        fechaTerminoEntradas = DateTime.Parse(fechaTerminoEntradas).ToString("yyyy/dd/MM HH:mm:ss")

        ''FECHA ENTRADAS
        If chboxFiltrarFechaPrograma.Checked = True Then
            fechaInicioProgramas = dtpInicioPrograma.Value.ToShortDateString.ToString + " 00:00:00"
            fechaTerminoProgramas = dtpFinPrograma.Value.ToShortDateString.ToString + " 23:59:59"
            fechaInicioProgramas = DateTime.Parse(fechaInicioProgramas).ToString("yyyy/dd/MM HH:mm:ss")
            fechaTerminoProgramas = DateTime.Parse(fechaTerminoProgramas).ToString("yyyy/dd/MM HH:mm:ss")
        End If


        objExportarOtros.Text = "Resumen de Productos"
        objExportarOtros.lblTitulo.Text = "Resumen de Productos"
        objExportarOtros.resumenNaves = True
        objExportarOtros.StartPosition = FormStartPosition.CenterScreen
        objExportarOtros.ComercializadoraID = cboxNave.SelectedValue
        objExportarOtros.lAtados = lAtados
        objExportarOtros.lLotes = lLotes
        objExportarOtros.lPedidos = lPedidos
        objExportarOtros.lProductos = lProductos
        objExportarOtros.lTiendas = lTiendas
        objExportarOtros.lCorridas = lCorridas
        objExportarOtros.lTallas = lTallas
        objExportarOtros.lNave = lNaves
        objExportarOtros.bY_O = bY_O
        objExportarOtros.filtroFechaPrograma = filtroFechaPrograma
        'ubicacion se desactiva con boton mostrar otros
        objExportarOtros.Ubicacion = chboxConUbicacion.Checked

        objExportarOtros.fechaInicioEntradas = fechaInicioEntradas
        objExportarOtros.fechaTerminoEntradas = fechaTerminoEntradas
        objExportarOtros.fechaInicioProgramas = fechaInicioProgramas
        objExportarOtros.fechaTerminoProgramas = fechaTerminoProgramas
        objExportarOtros.lClientes = lClientes

        objExportarOtros.ShowDialog()
    End Sub

    Private Sub ProduccionPorNaveConImportesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ProduccionPorNaveConImportesToolStripMenuItem.Click
        Dim objExportarOtros As New ResumenDeProductosParaProveedoresForm

        objExportarOtros.WindowState = 2
        Dim lLotes As String = String.Empty
        Dim lAtados As String = String.Empty
        Dim lPedidos As String = String.Empty
        Dim lProductos As String = String.Empty
        Dim lClientes As String = String.Empty
        Dim lCorridas As String = String.Empty
        Dim lTiendas As String = String.Empty
        Dim lTallas As String = String.Empty
        Dim fechaInicioEntradas As String = String.Empty
        Dim fechaTerminoEntradas As String = String.Empty
        Dim fechaInicioProgramas As String = String.Empty
        Dim fechaTerminoProgramas As String = String.Empty
        Dim bY_O As Boolean = rbtnY.Checked
        Dim filtroFechaPrograma As Boolean = chboxFiltrarFechaPrograma.Checked

        ''ATADOS
        For Each row As UltraGridRow In grdAtados.Rows
            If row.Index = 0 Then
                lAtados += "'" + row.Cells(0).Text + "'"
            Else
                lAtados += ", '" + row.Cells(0).Text + "'"
            End If
        Next

        ''LOTES
        For Each row As UltraGridRow In grdLotes.Rows
            If row.Index = 0 Then
                lLotes += "'" + row.Cells(0).Text + "'"
            Else
                lLotes += ", '" + row.Cells(0).Text + "'"
            End If
        Next

        ''PEDIDOS
        For Each row As UltraGridRow In grdPedidos.Rows
            If row.Index = 0 Then
                lPedidos += "" + row.Cells(0).Text + ""
            Else
                lPedidos += ", " + row.Cells(0).Text + ""
            End If
        Next

        ''PRODUCTOS
        For Each row As UltraGridRow In grdProductos.Rows
            If row.Index = 0 Then
                lProductos += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lProductos += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''TIENDAS
        For Each row As UltraGridRow In grdTiendas.Rows
            If row.Index = 0 Then
                lTiendas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lTiendas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''CLIENTES
        For Each row As UltraGridRow In grdClientes.Rows
            If row.Index = 0 Then
                lClientes += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lClientes += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''TIENDAS
        For Each row As UltraGridRow In grdCorridas.Rows
            If row.Index = 0 Then
                lCorridas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lCorridas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next


        ''TALLAS
        For Each row As UltraGridRow In grdTallas.Rows
            If row.Index = 0 Then
                lTallas += "'" + row.Cells("Parámetro").Text + "'"
            Else
                lTallas += ", '" + row.Cells("Parámetro").Text + "'"
            End If
        Next

        ''FECHA ENTRADAS
        fechaInicioEntradas = dtpInicioEntrada.Value.ToShortDateString.ToString + " 00:00:00"
        fechaTerminoEntradas = dtpFinEntrada.Value.ToShortDateString.ToString + " 23:59:59"
        fechaInicioEntradas = DateTime.Parse(fechaInicioEntradas).ToString("yyyy/dd/MM HH:mm:ss")
        fechaTerminoEntradas = DateTime.Parse(fechaTerminoEntradas).ToString("yyyy/dd/MM HH:mm:ss")

        ''FECHA ENTRADAS
        If chboxFiltrarFechaPrograma.Checked = True Then
            fechaInicioProgramas = dtpInicioPrograma.Value.ToShortDateString.ToString + " 00:00:00"
            fechaTerminoProgramas = dtpFinPrograma.Value.ToShortDateString.ToString + " 23:59:59"
            fechaInicioProgramas = DateTime.Parse(fechaInicioProgramas).ToString("yyyy/dd/MM HH:mm:ss")
            fechaTerminoProgramas = DateTime.Parse(fechaTerminoProgramas).ToString("yyyy/dd/MM HH:mm:ss")
        End If

        objExportarOtros.ComercializadoraID = cboxNave.SelectedValue
        objExportarOtros.Text = "Entrada de Producto por Nave con Importes"
        objExportarOtros.lblTitulo.Text = "Entrada de Producto por Nave con Importes"
        objExportarOtros.resumenNaveconImportes = True
        objExportarOtros.StartPosition = FormStartPosition.CenterScreen
        objExportarOtros.lAtados = lAtados
        objExportarOtros.lLotes = lLotes
        objExportarOtros.lPedidos = lPedidos
        objExportarOtros.lProductos = lProductos
        objExportarOtros.lTiendas = lTiendas
        objExportarOtros.lCorridas = lCorridas
        objExportarOtros.lTallas = lTallas
        objExportarOtros.lNave = lNaves
        objExportarOtros.bY_O = bY_O
        objExportarOtros.filtroFechaPrograma = filtroFechaPrograma
        objExportarOtros.Ubicacion = chboxConUbicacion.Checked
        objExportarOtros.fechaInicioEntradas = fechaInicioEntradas
        objExportarOtros.fechaTerminoEntradas = fechaTerminoEntradas
        objExportarOtros.fechaInicioProgramas = fechaInicioProgramas
        objExportarOtros.fechaTerminoProgramas = fechaTerminoProgramas
        objExportarOtros.lClientes = lClientes

        objExportarOtros.ShowDialog()

    End Sub
End Class