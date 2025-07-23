Imports DevExpress.Data.Extensions
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class SalidaNavesProduccion_ConsultasFiltros

    Private objBU As New Negocios.SalidaNavesProduccion_ConsultasFiltrosBU
    Private ListaFoliosSalida As New List(Of String)
    Private ListaAtados As New List(Of String)
    Private ListaPedidos As New List(Of String)
    Private dtLote As New DataTable
    Private ListaAños As New List(Of Integer)
    Private UsuarioID As Integer
    Dim ObjBU_SalidasAlmacenBU As New Negocios.SalidasAlmacenBU

    Private Sub SalidaNavesProduccion_ConsultasFiltros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

        dtpSalidaNaveAl.Value = Date.Now
        dtpSalidaNaveDel.Value = Date.Now
        dtpEntradaCEDISAl.Value = Date.Now
        dtpEntradaCEDISDel.Value = Date.Now
        dtpProgramaAl.Value = Date.Now
        dtpProgramaDel.Value = Date.Now

        dtpSalidaNaveAl.MinDate = dtpSalidaNaveDel.Value
        dtpEntradaCEDISAl.MinDate = dtpEntradaCEDISDel.Value
        dtpProgramaAl.MinDate = dtpProgramaDel.Value

        dtLote.Columns.Add("Lote", Type.GetType("System.String"))
        dtLote.Columns.Add("Año", Type.GetType("System.String"))

        CargarGridEstatus()
        CargarComboCEDIS()
        GenerarAñosCombo()
    End Sub

    Private Sub GenerarAñosCombo()
        Dim AñoActual As Integer = Date.Now.Year
        Dim AñoSeleccionado As Integer
        ListaAños.Clear()
        ListaAños.Add(2018) ' ES EL PRIMER AÑO 

        For año As Integer = 0 To ((Date.Now.Year) - ListaAños.Item(0))
            ListaAños.Add(ListaAños.Item(año) + 1)
        Next

        AñoSeleccionado = ListaAños.GetValidIndex(AñoActual) - 1
        cmbFiltroAnio.DataSource = ListaAños
        cmbFiltroAnio.SelectedIndex = AñoSeleccionado

    End Sub

    Private Sub CargarComboCEDIS()
        Dim ListaNaves As List(Of Entidades.Naves)
        Try
            ListaNaves = objBU.ConsultarNavesCEDIS()

            cmbCEDIS.DisplayMember = "PNombre"
            cmbCEDIS.ValueMember = "PNaveID"
            cmbCEDIS.DataSource = ListaNaves
            'cmbCEDIS.SelectedIndex = 0
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub CargarGridEstatus()
        Dim dtEstatus As DataTable
        Try

            dtEstatus = objBU.ConsultarEstatusSalidasNaves
            gridEstatus.DataSource = dtEstatus
            DiseñoGrid(gridEstatus)
            With gridEstatus
                .DisplayLayout.Bands(0).Columns("EstatusID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Status").CellActivation = Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Descripción").CellActivation = Activation.NoEdit
            End With
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub chkSalidaNave_CheckedChanged(sender As Object, e As EventArgs) Handles chkSalidaNave.CheckedChanged
        Dim value As Boolean = chkSalidaNave.Checked
        dtpSalidaNaveAl.Enabled = value
        dtpSalidaNaveDel.Enabled = value
    End Sub

    Private Sub chkEntregaCEDIS_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregaCEDIS.CheckedChanged
        Dim value As Boolean = chkEntregaCEDIS.Checked
        dtpEntradaCEDISAl.Enabled = value
        dtpEntradaCEDISDel.Enabled = value
    End Sub

    Private Sub chkPrograma_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrograma.CheckedChanged
        Dim value As Boolean = chkPrograma.Checked
        dtpProgramaAl.Enabled = value
        dtpProgramaDel.Enabled = value
    End Sub

    Private Sub rdbTipoConsulta_Detallada_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTipoConsulta_Detallada.CheckedChanged
        Dim value As Boolean = rdbTipoConsulta_Detallada.Checked
        pnlConUbicacion.Enabled = value
    End Sub

    Private Sub rdbTipoConsulta_AuditoriaEntradas_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTipoConsulta_AuditoriaEntradas.CheckedChanged
        chkConUbicacionNO.Checked = True
        chkConUbicacionSI.Checked = True
    End Sub

    Private Sub rdbTipoConsulta_AuditoriaEntradasCEDIS_CheckedChanged(sender As Object, e As EventArgs) Handles rdbTipoConsulta_AuditoriaEntradasCEDIS.CheckedChanged
        chkConUbicacionNO.Checked = True
        chkConUbicacionSI.Checked = True
    End Sub

    Private Sub cmbCEDIS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCEDIS.SelectedIndexChanged
        Dim dtCEDIS As DataTable
        Dim NaveID As Integer = TryCast(cmbCEDIS.SelectedItem, Entidades.Naves).PNaveId
        Try

            If NaveID > 0 Then
                dtCEDIS = objBU.ConsultarNavesCEDIS(NaveID)
                gridCEDIS.DataSource = dtCEDIS
                gridCEDIS.DisplayLayout.Bands(0).Columns("Almacén").CellActivation = Activation.NoEdit
                DiseñoGrid(gridCEDIS)
            End If


        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub btnFiltroNaves_Click(sender As Object, e As EventArgs) Handles btnFiltroNaves.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = "NAVES"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridNave.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If listado.DialogResult = Windows.Forms.DialogResult.OK Then
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.DialogResult = Windows.Forms.DialogResult.OK And listado.listParametros.Rows.Count > 0 Then
                With gridNave
                    .DataSource = listado.listParametros
                    .DisplayLayout.Bands(0).Columns(" ").Hidden = True
                    .DisplayLayout.Bands(0).Columns("NaveID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("NaveSICYID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Nave").CellActivation = Activation.NoEdit
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End With
                DiseñoGrid(gridNave)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = "CLIENTES"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridFiltroCliente.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If listado.DialogResult = Windows.Forms.DialogResult.OK Then
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.DialogResult = Windows.Forms.DialogResult.OK And listado.listParametros.Rows.Count > 0 Then
                With gridFiltroCliente
                    .DataSource = listado.listParametros
                    .DisplayLayout.Bands(0).Columns(" ").Hidden = True
                    .DisplayLayout.Bands(0).Columns("IdSAY").Hidden = True
                    .DisplayLayout.Bands(0).Columns("IdSICY").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Activation.NoEdit
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End With
                DiseñoGrid(gridFiltroCliente)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnFiltroTiendas_Click(sender As Object, e As EventArgs) Handles btnFiltroTiendas.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = "TIENDAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridFiltroTiendas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If listado.DialogResult = Windows.Forms.DialogResult.OK Then
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.DialogResult = Windows.Forms.DialogResult.OK And listado.listParametros.Rows.Count > 0 Then
                With gridFiltroTiendas
                    .DataSource = listado.listParametros
                    .DisplayLayout.Bands(0).Columns(" ").Hidden = True
                    .DisplayLayout.Bands(0).Columns("IdSICY").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Cliente").Hidden = True
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                    .DisplayLayout.Bands(0).Columns("Tienda/Embarque/CEDIS").CellActivation = Activation.NoEdit
                End With
                DiseñoGrid(gridFiltroTiendas)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnFiltroArticulos_Click(sender As Object, e As EventArgs) Handles btnFiltroArticulos.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = "ARTICULOS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridFiltroArticulos.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If listado.DialogResult = Windows.Forms.DialogResult.OK Then
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.DialogResult = Windows.Forms.DialogResult.OK And listado.listParametros.Rows.Count > 0 Then
                With gridFiltroArticulos
                    .DataSource = listado.listParametros
                    .DisplayLayout.Bands(0).Columns(" ").Hidden = True
                    .DisplayLayout.Bands(0).Columns("ProductoEstiloID").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Temporada").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Piel").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Color").Hidden = True
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End With
                DiseñoGrid(gridFiltroArticulos)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnFiltroCorrida_Click(sender As Object, e As EventArgs) Handles btnFiltroCorrida.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = "CORRIDAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridFIltroCorrida.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If listado.DialogResult = Windows.Forms.DialogResult.OK Then
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.DialogResult = Windows.Forms.DialogResult.OK And listado.listParametros.Rows.Count > 0 Then
                With gridFIltroCorrida
                    .DataSource = listado.listParametros
                    .DisplayLayout.Bands(0).Columns(" ").Hidden = True
                    .DisplayLayout.Bands(0).Columns("Talla_tallaid").Hidden = True
                    .DisplayLayout.Bands(0).Columns("talla_sicy").Hidden = True
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End With
                DiseñoGrid(gridFIltroCorrida)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnFiltroTallas_Click(sender As Object, e As EventArgs) Handles btnFiltroTallas.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listado As New ListadoParametroForm
        listado.tipo_busqueda = "TALLAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridFiltroTallas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If listado.DialogResult = Windows.Forms.DialogResult.OK Then
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.DialogResult = Windows.Forms.DialogResult.OK And listado.listParametros.Rows.Count > 0 Then
                With gridFiltroTallas
                    .DataSource = listado.listParametros
                    .DisplayLayout.Bands(0).Columns(" ").Hidden = True
                    .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
                End With
                DiseñoGrid(gridFiltroTallas)
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub gridNave_KeyDown(sender As Object, e As KeyEventArgs) Handles gridNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridNave.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroFolioSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroFolioSalida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroFolioSalida.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFIltroLotes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFIltroLotes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFIltroLotes.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroAtados_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroAtados.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroAtados.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroTiendas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroTiendas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroTiendas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroArticulos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroArticulos.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFIltroCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFIltroCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFIltroCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub gridFiltroTallas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridFiltroTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridFiltroTallas.DeleteSelectedRows(False)
    End Sub

    Private Sub txtFiltroFolioSalida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioSalida.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioSalida.Text) Then Return

            ListaFoliosSalida.Add(txtFiltroFolioSalida.Text)
            gridFiltroFolioSalida.DataSource = Nothing
            gridFiltroFolioSalida.DataSource = ListaFoliosSalida

            txtFiltroFolioSalida.Text = String.Empty
            gridFiltroFolioSalida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folios de Salida"
            With gridFiltroFolioSalida.DisplayLayout
                .Override.RowAppearance.TextHAlign = HAlign.Right
                .Override.CellClickAction = CellClickAction.RowSelect
                .Bands(0).Columns(0).CellActivation = Activation.NoEdit
            End With
            DiseñoGrid(gridFiltroFolioSalida)
        End If
    End Sub

    Private Sub txtFIltroLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroLote.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroLote.Text) Then Return

            Dim row As DataRow = dtLote.NewRow
            With row
                .Item("Lote") = txtFiltroLote.Text
                .Item("Año") = cmbFiltroAnio.Text
            End With
            dtLote.Rows.Add(row)

            gridFIltroLotes.DataSource = Nothing
            gridFIltroLotes.DataSource = dtLote

            txtFiltroLote.Text = String.Empty
            With gridFIltroLotes.DisplayLayout
                .Override.RowAppearance.TextHAlign = HAlign.Right
                .Override.CellClickAction = CellClickAction.RowSelect
                .Bands(0).Columns(0).CellActivation = Activation.NoEdit
            End With
            DiseñoGrid(gridFIltroLotes)
        End If
    End Sub

    Private Sub txtFiltroAtado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroAtado.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroAtado.Text) Then Return

            ListaAtados.Add(txtFiltroAtado.Text)
            gridFiltroAtados.DataSource = Nothing
            gridFiltroAtados.DataSource = ListaAtados

            txtFiltroAtado.Text = String.Empty
            gridFiltroAtados.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atados"
            With gridFiltroAtados.DisplayLayout
                .Override.RowAppearance.TextHAlign = HAlign.Right
                .Bands(0).Columns(0).CellActivation = Activation.NoEdit
            End With
            DiseñoGrid(gridFiltroAtados)
        End If
    End Sub

    Private Sub txtFiltroPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroPedido.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroPedido.Text) Then Return

            ListaPedidos.Add(txtFiltroPedido.Text)
            gridFiltroPedido.DataSource = Nothing
            gridFiltroPedido.DataSource = ListaPedidos

            txtFiltroPedido.Text = String.Empty
            gridFiltroPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedidos"
            With gridFiltroPedido.DisplayLayout
                .Override.RowAppearance.TextHAlign = HAlign.Right
                .Override.CellClickAction = CellClickAction.RowSelect
                .Bands(0).Columns(0).CellActivation = Activation.NoEdit
            End With
            DiseñoGrid(gridFiltroPedido)
        End If
    End Sub

    Private Sub dtpSalidaNaveDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpSalidaNaveDel.ValueChanged
        If dtpSalidaNaveAl.Value < dtpSalidaNaveDel.Value Then
            dtpSalidaNaveAl.Value = dtpSalidaNaveDel.Value
        End If
        dtpSalidaNaveAl.MinDate = dtpSalidaNaveDel.Value
    End Sub

    Private Sub dtpEntradaCEDISDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpEntradaCEDISDel.ValueChanged
        If dtpEntradaCEDISAl.Value < dtpEntradaCEDISDel.Value Then
            dtpEntradaCEDISAl.Value = dtpEntradaCEDISDel.Value
        End If
        dtpEntradaCEDISAl.MinDate = dtpEntradaCEDISDel.Value
    End Sub

    Private Sub dtpProgramaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpProgramaDel.ValueChanged
        If dtpProgramaAl.Value < dtpProgramaDel.Value Then
            dtpProgramaAl.Value = dtpProgramaDel.Value
        End If
        dtpProgramaAl.MinDate = dtpProgramaDel.Value
    End Sub


    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid, ByVal ColumnaDato As String, ByVal GridConCheck As Boolean) As String
        Dim CadenaFIltro As String = ""
        If GridConCheck Then
            For Each row As UltraGridRow In grid.Rows
                If CBool(row.Cells(" ").Value) Then
                    CadenaFIltro += row.Cells(ColumnaDato).Value.ToString.Trim + ","
                End If
            Next
        Else
            If grid.Name = "gridFIltroLotes" Then
                For Each row As UltraGridRow In grid.Rows
                    CadenaFIltro += row.Cells("Lote").Value.ToString.Trim + "-" + row.Cells("Año").Value + ","
                Next
            Else
                For Each row As UltraGridRow In grid.Rows
                    CadenaFIltro += row.Cells(ColumnaDato).Value.ToString.Trim + ","
                Next
            End If
        End If
        'CadenaFIltro = CadenaFIltro + "0"
        If CadenaFIltro.Length > 0 Then
            CadenaFIltro = CadenaFIltro.Substring(0, CadenaFIltro.Length - 1)
        End If
        Return CadenaFIltro
    End Function

    Private Function ObtenerFiltros() As Entidades.FiltrosSalidaNavesProduccion
        Dim FiltrosSalidaNaves As New Entidades.FiltrosSalidaNavesProduccion
        'Dim TipoConsulta As String

        'If rdbTipoConsulta_Detallada.Checked Then TipoConsulta = rdbTipoConsulta_Detallada.Text
        'If rdbTipoConsulta_AuditoriaEntradas.Checked Then TipoConsulta = rdbTipoConsulta_AuditoriaEntradas.Text
        'If rdbTipoConsulta_AuditoriaEntradasCEDIS.Checked Then TipoConsulta = rdbTipoConsulta_AuditoriaEntradasCEDIS.Text

        With FiltrosSalidaNaves
            .Usuario = Entidades.SesionUsuario.UsuarioSesion

            If rdbTipoConsulta_Detallada.Checked Then .TipoConsulta = rdbTipoConsulta_Detallada.Text
            If rdbTipoConsulta_AuditoriaEntradas.Checked Then .TipoConsulta = rdbTipoConsulta_AuditoriaEntradas.Text
            If rdbTipoConsulta_AuditoriaEntradasCEDIS.Checked Then .TipoConsulta = rdbTipoConsulta_AuditoriaEntradasCEDIS.Text
            If rdbPedidoOrigen.Checked Then .TipoPedido = 1
            If rdbPedidoActual.Checked Then .TipoPedido = 2
            If rdbClienteOrigen.Checked Then .TipoCliente = 1
            If rdbClienteActual.Checked Then .TipoCliente = 2
            If rdbTiendaDelPedidoOrigen.Checked Then .TipoTienda = 1
            If rdbTiendaDelPedidoActual.Checked Then .TipoTienda = 2
            If rdbY.Checked Then .Condicion = "AND"
            If rdbO.Checked Then .Condicion = "OR"

            .FechaSalidaNave = chkSalidaNave.Checked
            .FechaInicioSalidaNave = dtpSalidaNaveDel.Value
            .FechaFinSalidaNave = dtpSalidaNaveAl.Value
            .FechaEntradaCEDIS = chkEntregaCEDIS.Checked
            .FechaInicioEntradaCEDIS = dtpEntradaCEDISDel.Value
            .FechaFinEntradaCEDIS = dtpEntradaCEDISAl.Value
            .FechaPrograma = chkPrograma.Checked
            .FechaInicioPrograma = dtpProgramaDel.Value
            .FechaFinPrograma = dtpProgramaAl.Value

            .ConUbicacion_SI = chkConUbicacionSI.Checked
            .ConUbicacion_NO = chkConUbicacionNO.Checked
            .EntregaMismoDia_SI = chkMismoDiaSI.Checked
            .EntregaMismoDia_NO = chkMismoDiaNO.Checked
            .SinCEDIS = chkSInCEDIS.Checked

            .StatusID = ObtenerFiltrosGrid(gridEstatus, "EstatusID", True)
            .CEDIS_id = ObtenerFiltrosGrid(gridCEDIS, "Almacén", True)
            .NavesID = ObtenerFiltrosGrid(gridNave, "NaveSICYID", False)
            .Nave = ObtenerFiltrosGrid(gridNave, "Nave", False)
            .FolioSalidaID = ObtenerFiltrosGrid(gridFiltroFolioSalida, "Folios de Salida", False)
            .LoteAño = ObtenerFiltrosGrid(gridFIltroLotes, "", False)
            .Atado = ObtenerFiltrosGrid(gridFiltroAtados, "Atados", False)
            .PedidoID = ObtenerFiltrosGrid(gridFiltroPedido, "Pedidos", False)
            .ClienteID = ObtenerFiltrosGrid(gridFiltroCliente, "IdSICY", False)
            .TiendaID = ObtenerFiltrosGrid(gridFiltroTiendas, "Tienda/Embarque/CEDIS", False)
            .ProductoEstiloID = ObtenerFiltrosGrid(gridFiltroArticulos, "ProductoEstiloID", False)
            .CorridaID = ObtenerFiltrosGrid(gridFIltroCorrida, "Talla", False)
            .Talla = ObtenerFiltrosGrid(gridFiltroTallas, "Talla", False)
        End With

        Return FiltrosSalidaNaves
    End Function

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim EntidadFiltros As Entidades.FiltrosSalidaNavesProduccion
        Dim ReporteSalidaNaves As New ReporteSalidaNavesProduccionForm

        EntidadFiltros = ObtenerFiltros()

        If EntidadFiltros.TipoConsulta = "Auditoría de Entradas" Then
            Me.Cursor = Cursors.WaitCursor
            imprimirReporte(EntidadFiltros)
            Me.Cursor = Cursors.Default
        Else
            ReporteSalidaNaves.EntidadFiltros = EntidadFiltros
            ReporteSalidaNaves.ShowDialog()
        End If

    End Sub

    Private Sub imprimirReporte(Filtros As Entidades.FiltrosSalidaNavesProduccion)

        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsSalidaNaves As New DataSet("dsSalidaNaves")
        Dim dtSalidaNaves As New DataTable("dtSalidaNaves")
        Dim dtTablaCantidadesProgramas As New DataTable
        'Dim dsTotalesDeSalidas As New DataSet
        Dim lProgramas As New HashSet(Of String)
        Dim nombreNave As String = ""
        Dim urlImagenNave As String = ""
        Dim Fecha_Inicio As Date
        Dim Fecha_Fin As Date
        Dim totalRecibidos As Integer = 0
        Dim totalPendientes As Integer = 0
        Dim paresATiempo As Integer = 0
        Dim paresAtrasados As Integer = 0
        Dim totalPares As Integer = 0
        Dim atadosATiempo As Integer = 0
        Dim atadosAtrasados As Integer = 0
        Dim totalAtados As Integer = 0
        Dim lotesATiempo As Integer = 0
        Dim lotesAtrasados As Integer = 0
        Dim totalLotes As Integer = 0
        Dim operadorEntrega As String = ""
        Dim operadorRecibe As String = ""
        Dim nombreReporte As String = ""
        Dim usuarioImprime As String = ""
        Dim noProgramas As Integer = 0
        Dim ReporteSalidas As New Stimulsoft.Report.StiReport

        If Not gridNave.Rows.Count = 1 Then
            show_message("Advertencia", "Debe seleccionar una nave.")
            Return
        End If

        If Filtros.FechaSalidaNave Then
            Fecha_Inicio = Filtros.FechaInicioSalidaNave.ToShortDateString
            Fecha_Fin = Filtros.FechaFinSalidaNave.ToShortDateString()
        End If
        If Filtros.FechaEntradaCEDIS Then
            Fecha_Inicio = Filtros.FechaInicioEntradaCEDIS.ToShortDateString
            Fecha_Fin = Filtros.FechaFinEntradaCEDIS.ToShortDateString()
        End If
        If Filtros.FechaPrograma Then
            Fecha_Inicio = Filtros.FechaInicioPrograma.ToShortDateString
            Fecha_Fin = Filtros.FechaFinPrograma.ToShortDateString()
        End If

        Try

            dtSalidaNaves = objBU.ConsultarSalidasNavesProduccion(Filtros)

            If dtSalidaNaves.Rows.Count < 1 Then
                show_message("Advertencia", "No se encontró información")
                Return
            End If

            Dim dtCatidades As DataTable = RecuperarCantidadesProgramasEnTiempoYAtrasados(dtSalidaNaves, Fecha_Inicio)
            paresATiempo = dtCatidades.Rows(0).Item("Pares")
            atadosATiempo = dtCatidades.Rows(0).Item("Atados")
            lotesATiempo = dtCatidades.Rows(0).Item("Lotes")
            paresAtrasados = dtCatidades.Rows(1).Item("Pares")
            atadosAtrasados = dtCatidades.Rows(1).Item("Atados")
            lotesAtrasados = dtCatidades.Rows(1).Item("Lotes")
            totalPares = paresATiempo + paresAtrasados
            totalAtados = atadosATiempo + atadosAtrasados
            totalLotes = lotesATiempo + lotesAtrasados

            totalRecibidos = CInt(dtSalidaNaves.Compute("SUM(Recibido)", ""))
            totalPendientes = CInt(dtSalidaNaves.Compute("SUM(Pendiente)", ""))
            noProgramas = dtSalidaNaves.AsEnumerable().Select(Function(X) X.Item("Programa")).Distinct.Count
            usuarioImprime = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

            operadorEntrega = dtSalidaNaves.Rows(0).Item("Envía").ToString
            operadorRecibe = dtSalidaNaves.Rows(0).Item("Recibe").ToString

            urlImagenNave = Tools.Controles.ObtenerLogoNave(43)

            entReporte = objReporte.LeerReporteporClave("AUDITORIA_INGRESO_PRODUCCION")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

            dsSalidaNaves.Tables.Add(dtSalidaNaves)

            ReporteSalidas.Load(archivo)
            ReporteSalidas.Compile()
            ReporteSalidas("urlImagenNave") = urlImagenNave
            ReporteSalidas("nombreNave") = Tools.Controles.RecuperarNombreNave(Filtros.NavesID)
            ReporteSalidas("nombreReporte") = entReporte.Pnombre
            ReporteSalidas("usuarioImprime") = usuarioImprime
            ReporteSalidas("FechaDel_Al") = Fecha_Inicio + " Al " + Fecha_Fin
            ReporteSalidas("totalRecibidos") = totalRecibidos
            ReporteSalidas("totalPendientes") = totalPendientes
            ReporteSalidas("paresATiempo") = paresATiempo
            ReporteSalidas("atadosATiempo") = atadosATiempo
            ReporteSalidas("lotesATiempo") = lotesATiempo
            ReporteSalidas("paresAtrasados") = paresAtrasados
            ReporteSalidas("atadosAtrasados") = atadosAtrasados
            ReporteSalidas("lotesAtrasados") = lotesAtrasados
            ReporteSalidas("totalPares") = totalPares
            ReporteSalidas("totalAtados") = totalAtados
            ReporteSalidas("totalLotes") = totalLotes
            ReporteSalidas("operadorEntrega") = operadorEntrega
            ReporteSalidas("operadorRecibe") = operadorRecibe
            ReporteSalidas("noProgramas") = noProgramas

            ReporteSalidas.Dictionary.Clear()
            ReporteSalidas.RegData(dsSalidaNaves)
            ReporteSalidas.Dictionary.Synchronize()
            ReporteSalidas.Show()

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub

    Private Function RecuperarCantidadesProgramasEnTiempoYAtrasados(ByVal dtTabla As DataTable, ByVal fecha_Salida As Date) As DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim Dias As Integer
        Dim programa As Date
        Dim ParesBien As Integer = 0
        Dim ParesMal As Integer = 0
        Dim AtadosBien As Integer = 0
        Dim AtadosMal As Integer = 0
        Dim LotesBien As Integer = 0
        Dim LotesMal As Integer = 0
        Dim diasTotales As Double = 0

        For Each row As DataRow In dtTabla.Rows
            programa = row.Item("Programa")
            Dias = (fecha_Salida - programa).TotalDays
            'borrar---------------------------------------------------------------------------
            Dias = DateDiff(DateInterval.Day, programa, fecha_Salida) 'dias que existen entre el rango de fechas
            For index As Integer = 1 To Dias
                If index = 1 Then
                    If programa.Month = 3 Then
                        If programa.Day = 21 Then
                        ElseIf programa.Day = 22 Then
                        ElseIf programa.Day = 23 Then
                        ElseIf programa.Day = 24 Then
                        ElseIf programa.Day = 25 Then
                        ElseIf programa.Day = 26 Then
                        ElseIf programa.Day = 27 Then
                            If Not programa.DayOfWeek = 0 Then
                                diasTotales = diasTotales + 1
                            End If
                        Else
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                End If
                If DateAdd(DateInterval.Day, index, programa).Month = 3 Then
                    If DateAdd(DateInterval.Day, index, programa).Day = 21 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 22 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 23 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 24 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 25 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 26 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 27 Then
                        If Not DateAdd(DateInterval.Day, index, programa).DayOfWeek = 0 Then
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                Else
                    diasTotales = diasTotales + 1
                End If
            Next
            Dias = diasTotales
            'borrar---------------------------------------------------------------------------
            'Dias = 14
            If Dias <= 5 Then
                ParesBien += row.Item("PARES")
                AtadosBien += row.Item("ATADOS")
                LotesBien += 1
            ElseIf Dias = 6 Then
                If (programa.DayOfWeek = 3 And fecha_Salida.DayOfWeek = 1) Or
                    (programa.DayOfWeek = 4 And fecha_Salida.DayOfWeek = 2) Or
                    (programa.DayOfWeek = 5 And fecha_Salida.DayOfWeek = 3) Or
                    (programa.DayOfWeek = 6 And fecha_Salida.DayOfWeek = 4) Then
                    ParesBien += row.Item("PARES")
                    AtadosBien += row.Item("ATADOS")
                    LotesBien += 1
                Else
                    ParesMal += row.Item("PARES")
                    AtadosMal += row.Item("ATADOS")
                    LotesMal += 1
                End If
            Else
                ParesMal += row.Item("PARES")
                AtadosMal += row.Item("ATADOS")
                LotesMal += 1
            End If
            diasTotales = 0
        Next

        Dim columns As DataColumnCollection = dtTablaCantidadesProgramas.Columns
        Dim columna0 As New DataColumn
        columna0.DataType = Type.GetType("System.Double")
        columna0.DefaultValue = 0
        columna0.ColumnName = "Pares"
        columns.Add(columna0)

        Dim columna1 As New DataColumn
        columna1.DataType = Type.GetType("System.Double")
        columna1.DefaultValue = 0
        columna1.ColumnName = "Atados"
        columns.Add(columna1)

        Dim columna2 As New DataColumn
        columna2.DataType = Type.GetType("System.Double")
        columna2.DefaultValue = 0
        columna2.ColumnName = "Lotes"
        columns.Add(columna2)

        Dim newCustomersRow As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow("Pares") = ParesBien
        newCustomersRow("Atados") = AtadosBien
        newCustomersRow("Lotes") = LotesBien
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow)

        Dim newCustomersRow1 As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow1("Pares") = ParesMal
        newCustomersRow1("Atados") = AtadosMal
        newCustomersRow1("Lotes") = LotesMal
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow1)

        dtTablaCantidadesProgramas.TableName = "dtTablaCantidadesProgramas"

        Return dtTablaCantidadesProgramas
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        rdbTipoConsulta_Detallada.Checked = True
        rdbPedidoActual.Checked = True
        rdbClienteOrigen.Checked = True
        rdbTiendaDelPedidoOrigen.Checked = True

        chkSInCEDIS.Checked = True
        chkMismoDiaSI.Checked = True
        chkMismoDiaNO.Checked = True
        chkSalidaNave.Checked = True
        chkEntregaCEDIS.Checked = False
        chkPrograma.Checked = False

        gridCEDIS.DataSource = Nothing
        gridNave.DataSource = Nothing
        gridFiltroFolioSalida.DataSource = Nothing
        gridFIltroLotes.DataSource = Nothing
        gridFiltroAtados.DataSource = Nothing
        gridFiltroPedido.DataSource = Nothing
        gridFiltroCliente.DataSource = Nothing
        gridFiltroTiendas.DataSource = Nothing
        gridFiltroArticulos.DataSource = Nothing
        gridFIltroCorrida.DataSource = Nothing
        gridFiltroTallas.DataSource = Nothing

        GenerarAñosCombo()
        CargarGridEstatus()
        CargarComboCEDIS()

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


End Class