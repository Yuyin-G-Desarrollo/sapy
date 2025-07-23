Imports System.Threading
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Tools


Public Class Programacion_Reportes_ParesProgramadosPorTalla_Form

    Dim vFiltroColeccion As String = Nothing
    Dim vFiltroModelo As String = Nothing
    Dim vFiltroPielColor As String = Nothing
    Dim vFiltroCorrida As String = Nothing
    Dim vFiltroFechaInicio As String = Nothing
    Dim vFiltroFechaFin As String = Nothing
    Dim vFiltroNave As String = Nothing
    Dim vFiltroCliente As String = Nothing
    Dim vFiltroPedido As String = Nothing
    Dim dtResultadoConsulta As New DataTable
    Dim FPedidoSAY As String = String.Empty
    Dim FPedidoSICY As String = String.Empty
    Dim ListaPedidoSICY As New List(Of String)
    Dim ListaPedidoSAY As New List(Of String)
    Dim verPedido As New Integer

    Private Sub Programacion_Reportes_ParesProgramadosPorTalla_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        dtpFechaInicio.MinDate = "01/01/2018"
        dtpFechaFin.MaxDate = "31/12/" + (dtpFechaInicio.Value.Year + 1).ToString()


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PARES_PROGRAMADOS_TALLA", "CONSULTA_PPCP") Then
            grpboxNave.Enabled = True
        Else
            Dim dtNavesAsignadas As New DataTable
            Dim objNavesBU As New Negocios.Programacion_Reportes_ParesProgramadosPorTallaBU
            dtNavesAsignadas = objNavesBU.ObtenerNaves(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            grpboxNave.Enabled = False
            grdNave.DataSource = dtNavesAsignadas
            With grdNave
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                '.DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
            End With
        End If



    End Sub
    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged

        'If dtpFechaFin.MinDate > "31/12/" + dtpFechaInicio.Value.Year.ToString() Then
        dtpFechaFin.MinDate = dtpFechaInicio.Value
        'dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()
        'Else
        '    'dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()
        '    dtpFechaFin.MinDate = dtpFechaInicio.Value
        'End If
    End Sub

    Private Sub btnLimpiarNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarNave.Click
        grdNave.DataSource = Nothing
    End Sub

    Private Sub btnAgregarNave_Click(sender As Object, e As EventArgs) Handles btnAgregarNave.Click
        Dim listado As New ListaNaveAsignada


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNave.DataSource = listado.listParametros

        With grdNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub btnLimpiarColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdColeccion.DataSource = Nothing
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        LlenarGridFiltro(grdColeccion, "Colección", 2)
    End Sub

    Private Sub btnLimpiarModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarModelo.Click
        grdModelo.DataSource = Nothing
    End Sub

    Private Sub btnAgregarModelo_Click(sender As Object, e As EventArgs) Handles btnAgregarModelo.Click
        LlenarGridFiltro(grdModelo, "Modelo", 3)
    End Sub

    Private Sub btnLimpiarPielColor_Click(sender As Object, e As EventArgs) Handles btnLimpiarPielColor.Click
        grdPielColor.DataSource = Nothing
    End Sub

    Private Sub btnAgregarPielColor_Click(sender As Object, e As EventArgs) Handles btnAgregarPielColor.Click
        LlenarGridFiltro(grdPielColor, "Piel / Color", 7)
    End Sub

    Private Sub btnLimpiarCorrida_Click(sender As Object, e As EventArgs) Handles btnLimpiarCorrida.Click
        grdCorrida.DataSource = Nothing
    End Sub

    Private Sub btnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        LlenarGridFiltro(grdCorrida, "Corrida", 6)
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        LlenarGridFiltro(grdCliente, "Cliente", 13)
    End Sub

    Private Sub btnLimpiarCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarCliente.Click
        grdCliente.DataSource = Nothing
    End Sub

    'Private Sub btnLimpiarPedido_Click(sender As Object, e As EventArgs) Handles btnLimpiarPedido.Click
    '    grdCliente.DataSource = Nothing
    'End Sub

    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltradoForm
        listado.tipo_busqueda = pTipoBusqueda


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In pGrid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        pGrid.DataSource = listado.listParametros

        With pGrid
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor

        Dim vTipo As String = cmbAgrupado.Text
        Dim obj As New Programacion_Reportes_ParesProgramadosPorTallaBU
        Dim vSpid As Integer = 0
        dtResultadoConsulta.Clear()
        dtResultadoConsulta.Columns.Clear()

        If chkPedido.Checked Then
            verPedido = 1
        Else
            verPedido = 0
        End If

        If vTipo <> "" Then
            obtenerFiltros()
            Select Case vTipo

                Case "Por Programa"
                    If grdCliente.DataSource Is Nothing Then
                        If chkCliente.Checked Then
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasProgramaVerCliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)

                        Else
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasPrograma(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        End If
                    Else
                        dtResultadoConsulta = obj.ObtenerParesProgramadosTallasPrograma_Cliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroCliente, FPedidoSAY, FPedidoSICY, verPedido)
                    End If

                Case "Por Semana"
                    If grdCliente.DataSource Is Nothing Then
                        If chkCliente.Checked Then
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasSemanaVerCliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        Else
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasSemana(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        End If
                    Else
                        dtResultadoConsulta = obj.ObtenerParesProgramadosTallasSemana_Cliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroCliente, FPedidoSAY, FPedidoSICY, verPedido)
                    End If

                Case "Por Mes"
                    If grdCliente.DataSource Is Nothing Then
                        If chkCliente.Checked Then
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasMesVerCliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        Else
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasMes(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        End If
                    Else
                        dtResultadoConsulta = obj.ObtenerParesProgramadosTallasMes_Cliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroCliente, FPedidoSAY, FPedidoSICY, verPedido)
                    End If

                Case "Por Año"
                    If grdCliente.DataSource Is Nothing Then
                        If chkCliente.Checked Then
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasAnualVerCliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        Else
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasAnual(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        End If
                    Else
                        dtResultadoConsulta = obj.ObtenerParesProgramadosTallasAnual_Cliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroCliente, FPedidoSAY, FPedidoSICY, verPedido)
                    End If

                Case "Por Lote"
                    If grdCliente.DataSource Is Nothing Then
                        If chkCliente.Checked Then
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasLoteVerCliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)

                        Else
                            dtResultadoConsulta = obj.ObtenerParesProgramadosTallasLote(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, FPedidoSAY, FPedidoSICY, verPedido)
                        End If
                    Else
                        dtResultadoConsulta = obj.ObtenerParesProgramadosTallasLote_Cliente(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroCliente, FPedidoSAY, FPedidoSICY, verPedido)

                    End If

            End Select

            If dtResultadoConsulta.Rows.Count > 0 Then
                vwReporte.Columns.Clear()
                grdReporte.DataSource = Nothing
                grdReporte.DataSource = dtResultadoConsulta
                DiseñoGrid()
                reporteTotales()
                ContadorColeccionesModelos()
                btnArriba_Click(Nothing, Nothing)
            Else
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "No hay datos para mostrar"
                mensajeAdvertencia.ShowDialog()
            End If
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debe seleccionar un agrupamiento."
            mensajeAdvertencia.ShowDialog()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim vDatosFiltrados As String = Nothing
        For Each Row As UltraGridRow In grid.Rows
            If vDatosFiltrados <> Nothing Then
                vDatosFiltrados += ","
            End If
            vDatosFiltrados += Row.Cells("Parametro").Value.ToString()
        Next
        Return vDatosFiltrados
    End Function

    Private Sub obtenerFiltros()
        vFiltroFechaInicio = dtpFechaInicio.Value
        vFiltroFechaFin = dtpFechaFin.Value
        vFiltroColeccion = Filtros(grdColeccion)
        vFiltroCorrida = Filtros(grdCorrida)
        vFiltroPielColor = Filtros(grdPielColor)
        vFiltroModelo = Filtros(grdModelo)
        vFiltroNave = Filtros(grdNave)
        vFiltroCliente = Filtros(grdCliente)
        vFiltroPedido = Filtros(grdCliente)
        FPedidoSAY = ObtenerFiltrosGrid(grdPedidoSAY)
        FPedidoSICY = ObtenerFiltrosGrid(grdPedidoSICY)
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 335
    End Sub
    Private Sub DiseñoGrid()

        'grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        'grdReporte.LookAndFeel.UseDefaultLookAndFeel = False
        'vwReporte.Appearance.HeaderPanel.Options.UseBackColor = True
        'vwReporte.OptionsView.AllowCellMerge = False
        vwReporte.IndicatorWidth = 45

        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns

            vColumna.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If vColumna.FieldName.Contains("ColeccionSAY") = True Then
                vColumna.Width = 180
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("Lote") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("ModeloSAY") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("NaveNombre") = True Then
                vColumna.Width = 100
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                vColumna.Caption = "Nave"

            ElseIf vColumna.FieldName.Contains("PielColor") = True Then
                vColumna.Width = 180
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("Corrida") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("Pares") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vColumna.DisplayFormat.FormatString = "N0"

            ElseIf vColumna.FieldName.Contains("FechaProgramacion") = True Then
                vColumna.Width = 100
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("Marca") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("MesNum") = True Then
                vColumna.Visible = False

            ElseIf vColumna.FieldName.Contains("SemanaProgramacion") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("MesProgramacion") = True Then
                vColumna.Width = 150
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("AñoProgramacion") = True Then
                vColumna.Width = 90
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("Cliente") = True Then
                vColumna.Width = 180
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                If (grdCliente.DataSource IsNot Nothing And chkCliente.Checked) Or (grdCliente.DataSource Is Nothing And chkCliente.Checked) Then
                    vColumna.Visible = True
                ElseIf (grdCliente.DataSource IsNot Nothing And chkCliente.Checked = False) Or (grdCliente.DataSource Is Nothing And chkCliente.Checked = False) Then
                    vColumna.Visible = False
                End If
            ElseIf vColumna.FieldName.Contains("PedidoSAY") = True Then
                vColumna.Width = 180
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                If (grdPedidoSAY.DataSource IsNot Nothing And chkPedido.Checked) Or (grdPedidoSAY.DataSource Is Nothing And chkPedido.Checked) Then
                    vColumna.Visible = True
                ElseIf (grdPedidoSAY.DataSource IsNot Nothing And chkPedido.Checked = False) Or (grdPedidoSAY.DataSource Is Nothing And chkPedido.Checked = False) Then
                    vColumna.Visible = False
                End If
            ElseIf vColumna.FieldName.Contains("PedidoSICY") = True Then
                vColumna.Width = 180
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                If (grdPedidoSICY.DataSource IsNot Nothing And chkPedido.Checked) Or (grdPedidoSICY.DataSource Is Nothing And chkPedido.Checked) Then
                    vColumna.Visible = True
                ElseIf (grdPedidoSICY.DataSource IsNot Nothing And chkPedido.Checked = False) Or (grdPedidoSICY.DataSource Is Nothing And chkPedido.Checked = False) Then
                    vColumna.Visible = False
                End If
            Else
                vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vColumna.DisplayFormat.FormatString = "N0"
            End If


        Next

    End Sub

    Private Sub reporteTotales()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            If vColumna.FieldName.Contains("Pares") Or vColumna.FieldName.Contains("1") Or vColumna.FieldName.Contains("2") Or vColumna.FieldName.Contains("3") Then
                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                vwReporte.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If

        Next
    End Sub

    Private Sub ContadorColeccionesModelos()

        Dim vColecciones = (From x In dtResultadoConsulta
                            Select x.Item("ColeccionSAY")).Distinct()
        Dim vModelos = (From x In dtResultadoConsulta
                        Select x.Item("ModeloSAY")).Distinct()

        lblModelosNum.Text = Format(vModelos.Count, "##,##0")
        lblColeccionesNum.Text = Format(vColecciones.Count, "##,##0")

    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPielColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPielColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPielColor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
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

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "N0"
            End If
            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
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

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
    End Sub

    Private Sub grdPielColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout
        grid_diseño(grdPielColor)
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
    End Sub

    'Private Sub grdPedidoSAYSICYInitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSYCY.InitializeLayout
    '    grid_diseño(grdPedidoSAY)
    'End Sub

    'Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
    '    grid_diseño(grdCliente)
    'End Sub}}

    Private Sub vwReporte_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle

        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Pares_Programados_Por_Talla_" + cmbAgrupado.SelectedText
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        lblColeccionesNum.Text = 0
        lblModelosNum.Text = 0
        grdReporte.DataSource = Nothing
        vwReporte.Columns.Clear()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PARES_PROGRAMADOS_TALLA", "CONSULTA_PPCP") Then
            grdNave.DataSource = Nothing
        End If
        grdColeccion.DataSource = Nothing
        grdModelo.DataSource = Nothing
        grdCorrida.DataSource = Nothing
        grdPielColor.DataSource = Nothing
        grdCliente.DataSource = Nothing
        grdPedidoSAY.DataSource = Nothing
        grdPedidoSICY.DataSource = Nothing

        ListaPedidoSAY.Clear()
        ListaPedidoSICY.Clear()

    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return Resultado
    End Function

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            ListaPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = ListaPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            ListaPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = ListaPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub
End Class