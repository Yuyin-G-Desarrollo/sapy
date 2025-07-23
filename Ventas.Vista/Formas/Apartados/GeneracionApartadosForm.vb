Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class GeneracionApartadosForm

    Dim dtInicial As New DataTable
    Dim listInicial As New List(Of String)
    Dim listPedidosSay As New List(Of String)

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 24
        chboxSeleccionarTodo.Visible = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 323
        chboxSeleccionarTodo.Visible = False
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        pnlParametros.Height = 24
        chboxSeleccionarTodo.Visible = True

        gridApartados.DataSource = Nothing
        chboxSeleccionarTodo.Checked = False
        chboxSeleccionarTodo.Enabled = True
        Dim FiltrosApartados As New Entidades.FiltrosApartados
        Dim objBU As New Negocios.ApartadosBU

        Dim tabla_apartados As New DataTable
        Dim lMarca As String = String.Empty
        Dim lPedido As String = String.Empty
        Dim lCliente As String = String.Empty
        Dim lTienda As String = String.Empty
        Dim lColeccion As String = String.Empty
        Dim lModelo As String = String.Empty
        Dim lCorrida As String = String.Empty
        Dim lRanking As String = String.Empty
        Dim lNave As String = String.Empty
        Dim lTemporada As String = String.Empty


        FiltrosApartados.PFechaEntregaDel = If(chboxFiltrarFechaEntrega.Checked, dtpEntregaDel.Value.ToShortDateString, "")
        FiltrosApartados.PFechaEntregaAl = If(chboxFiltrarFechaEntrega.Checked, dtpEntregaAl.Value.ToShortDateString, "")
        FiltrosApartados.PFechaProgramaDel = If(chboxFiltrarFechaPrograma.Checked, dtpProgramaDel.Value.ToShortDateString, "")
        FiltrosApartados.PFechaProgramaAl = If(chboxFiltrarFechaPrograma.Checked, dtpProgramaAl.Value.ToShortDateString, "")

        For Each row As UltraGridRow In grdMarca.Rows
            If row.Index = 0 Then
                lMarca += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lMarca += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PMarca = lMarca

        For Each row As UltraGridRow In grdPedido.Rows
            If row.Index = 0 Then
                lPedido += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lPedido += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PPedido = lPedido

        For Each row As UltraGridRow In grdCliente.Rows
            If row.Index = 0 Then
                lCliente += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lCliente += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PCliente = lCliente

        For Each row As UltraGridRow In grdTienda.Rows
            If row.Index = 0 Then
                lTienda += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lTienda += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PTienda = lTienda

        For Each row As UltraGridRow In grdColeccion.Rows
            If row.Index = 0 Then
                lColeccion += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lColeccion += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PColeccion = lColeccion

        For Each row As UltraGridRow In grdModelo.Rows
            If row.Index = 0 Then
                lModelo += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lModelo += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PModelo = lModelo

        For Each row As UltraGridRow In grdCorrida.Rows
            If row.Index = 0 Then
                lCorrida += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lCorrida += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PCorrida = lCorrida

        For Each row As UltraGridRow In grdRanking.Rows
            If row.Index = 0 Then
                lRanking += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lRanking += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PRanking = lRanking

        For Each row As UltraGridRow In grdNave.Rows
            If row.Index = 0 Then
                lNave += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lNave += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PNave = lNave

        For Each row As UltraGridRow In grdTemporada.Rows
            If row.Index = 0 Then
                lTemporada += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lTemporada += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        FiltrosApartados.PTemporada = lTemporada


        ' tabla_apartados = objBU.consultaGenerarApartados(FiltrosApartados)


        gridApartados.DataSource = tabla_apartados

        'gridapartados_diseño(gridApartados, e)

    End Sub

    Private Sub GeneracionApartadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)

        dtpEntregaDel.Value = Now.Date
        dtpProgramaDel.Value = Now.Date

        Me.WindowState = 2

        lblEntregaDel.Enabled = False
        lblEntregaAl.Enabled = False
        lblProgramaDel.Enabled = False
        lblProgramaAl.Enabled = False
        dtpEntregaDel.Enabled = False
        dtpEntregaAl.Enabled = False
        dtpProgramaDel.Enabled = False
        dtpProgramaAl.Enabled = False


        chboxSeleccionarTodo.Visible = False
        dtInicial.Columns.Add("OK_renglonCompleto")
        dtInicial.Columns.Add("Pedido")
        dtInicial.Columns.Add("PedidoDetalleID")
        dtInicial.Columns.Add("OC")
        dtInicial.Columns.Add("Semana")
        dtInicial.Columns.Add("FechaEntregaProgramacion")
        dtInicial.Columns.Add("FechaEntregaCliente")
        dtInicial.Columns.Add("Cliente")
        dtInicial.Columns.Add("Tienda")
        dtInicial.Columns.Add("Partida")
        dtInicial.Columns.Add("Material")
        dtInicial.Columns.Add("Temporada")
        'dtInicial.Columns.Add("ParesPedidos")
        dtInicial.Columns.Add("Numeracion")
        dtInicial.Columns.Add("CantidadPedido")
        dtInicial.Columns.Add("CantidadApartado")
        dtInicial.Columns.Add("CantidadPorApartar")
        dtInicial.Columns.Add("UnidadesManipulacion")
        dtInicial.Columns.Add("OK_UnidadManipulacion")
        dtInicial.Columns.Add("Destallados")
        dtInicial.Columns.Add("OK_Destallado")
        dtInicial.Columns.Add("Pares")
        dtInicial.Columns.Add("OK_Pares")
        dtInicial.Columns.Add("Modificado")
        dtInicial.Columns.Add("BloqueadoAhora")
        dtInicial.Columns.Add("BloqueadoTresMeses")

        

        gridApartados.DataSource = dtInicial

        grdMarca.DataSource = listInicial
        grdPedido.DataSource = listInicial
        grdCliente.DataSource = listInicial
        grdTienda.DataSource = listInicial
        grdColeccion.DataSource = listInicial
        grdModelo.DataSource = listInicial
        grdCorrida.DataSource = listInicial
        grdRanking.DataSource = listInicial
        grdNave.DataSource = listInicial
        grdTemporada.DataSource = listInicial

        'txtColocadoEnPrograma.Enabled = False

    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            If grid.Name <> gridApartados.Name Then
                .PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
                .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            End If
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            '.Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowDelete = DefaultableBoolean.False
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next



        'asignaFormato_Columna(grid)

    End Sub

    Private Sub gridapartados_diseño(ByVal grid As UltraGrid, e As Object)
        Dim IndicePrimerColumna As Integer
        Dim Cantidad_Grupos As Integer = 0

        'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL 
        Dim Layout As UltraGridLayout = e.Layout
        Dim rootBand As UltraGridBand = Layout.Bands(0)

        rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

        'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas
        IndicePrimerColumna = 14

        Cantidad_Grupos = rootBand.Columns.Count - IndicePrimerColumna

        'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
        For n = 0 To rootBand.Columns.Count - 1 Step 1

            If n < 5 Or (n > 6 And n < 13) Or n = 22 Then
                Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = grupo
            Else
                If n = 5 Then
                    Dim NombreColumna As String
                    NombreColumna = "Fecha Entrega"

                    Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                    rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                ElseIf n = 6 Then
                    Dim Grupo As UltraGridGroup = rootBand.Groups("Fecha Entrega")
                    rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo

                End If
                If n > 12 And n < 16 Then
                    If n = 13 Then
                        Dim NombreColumna As String
                        NombreColumna = "Cantidad"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    Else
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Cantidad")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                Else
                    If n = 16 Then
                        Dim NombreColumna As String
                        NombreColumna = "Inventario Disponible"

                        Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna)
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    ElseIf n > 16 Then
                        Dim Grupo As UltraGridGroup = rootBand.Groups("Inventario Disponible")
                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Grupo
                    End If
                End If

                IndicePrimerColumna += 1
            End If
        Next


        grid.DisplayLayout.Bands(0).Columns("BloqueadoAhora").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("BloqueadoTresMeses").Hidden = True

        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        grid.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Semana").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("CantidadApartado").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("CantidadApartado").Format = "n0"
        gridApartados.DisplayLayout.Bands(0).Columns("CantidadPorApartar").CellAppearance.TextHAlign = HAlign.Right
        gridApartados.DisplayLayout.Bands(0).Columns("CantidadPorApartar").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("UnidadesManipulacion").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("UnidadesManipulacion").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Destallados").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Destallados").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Pares").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Modificado").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Partida").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Partida").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("PedidoDetalleID").CellAppearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("PedidoDetalleID").Format = "n0"

        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Width = 35


        grid.DisplayLayout.Bands(0).Columns("OK_UnidadManipulacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("OK_UnidadManipulacion").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("OK_UnidadManipulacion").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("OK_UnidadManipulacion").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("OK_UnidadManipulacion").Width = 35


        grid.DisplayLayout.Bands(0).Columns("OK_Destallado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("OK_Destallado").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("OK_Destallado").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("OK_Destallado").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("OK_Destallado").Width = 35


        grid.DisplayLayout.Bands(0).Columns("OK_Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        grid.DisplayLayout.Bands(0).Columns("OK_Pares").Style = ColumnStyle.CheckBox
        grid.DisplayLayout.Bands(0).Columns("OK_Pares").DefaultCellValue = False
        grid.DisplayLayout.Bands(0).Columns("OK_Pares").AllowRowFiltering = DefaultableBoolean.False
        grid.DisplayLayout.Bands(0).Columns("OK_Pares").Width = 35

        grid.DisplayLayout.Bands(0).Columns("PedidoDetalleID").Width = 90
        grid.DisplayLayout.Bands(0).Columns("Pedido").Width = 80
        grid.DisplayLayout.Bands(0).Columns("OC").Width = 80
        grid.DisplayLayout.Bands(0).Columns("Semana").Width = 80
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaProgramacion").Width = 80
        grid.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Width = 80
        grid.DisplayLayout.Bands(0).Columns("Cliente").Width = 350
        grid.DisplayLayout.Bands(0).Columns("Tienda").Width = 350
        grid.DisplayLayout.Bands(0).Columns("Partida").Width = 70
        grid.DisplayLayout.Bands(0).Columns("Material").Width = 400
        grid.DisplayLayout.Bands(0).Columns("Temporada").Width = 170
        'grid.DisplayLayout.Bands(0).Columns("ParesPedidos").Header.Caption = "Pares en Pedidos"
        grid.DisplayLayout.Bands(0).Columns("Numeracion").Width = 80
        grid.DisplayLayout.Bands(0).Columns("CantidadPedido").Width = 80
        grid.DisplayLayout.Bands(0).Columns("CantidadApartado").Width = 80
        grid.DisplayLayout.Bands(0).Columns("CantidadPorApartar").Width = 80
        grid.DisplayLayout.Bands(0).Columns("UnidadesManipulacion").Width = 80
        grid.DisplayLayout.Bands(0).Columns("Destallados").Width = 80
        grid.DisplayLayout.Bands(0).Columns("Pares").Width = 80
        grid.DisplayLayout.Bands(0).Columns("Modificado").Width = 70

        grid.AllowDrop = True


        Dim summary1, summary2, summary3, summary4, summary5 As SummarySettings
        summary1 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Pedidos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("CantidadPedido"))
        summary2 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Apartados", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("CantidadApartado"))
        summary3 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Prepacks", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("UnidadesManipulacion"))
        summary4 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Destallado", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Destallados"))
        summary5 = grid.DisplayLayout.Bands(0).Summaries.Add("Total Pares Sueltos", SummaryType.Sum, grid.DisplayLayout.Bands(0).Columns("Pares"))
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary1.DisplayFormat = "{0:#,##0}"
        summary1.Appearance.TextHAlign = HAlign.Right
        summary2.DisplayFormat = "{0:#,##0}"
        summary2.Appearance.TextHAlign = HAlign.Right
        summary3.DisplayFormat = "{0:#,##0}"
        summary3.Appearance.TextHAlign = HAlign.Right
        summary4.DisplayFormat = "{0:#,##0}"
        summary4.Appearance.TextHAlign = HAlign.Right
        summary5.DisplayFormat = "{0:#,##0}"
        summary5.Appearance.TextHAlign = HAlign.Right

        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        If width > grid.Width Then
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        Else
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If


    End Sub

    Private Sub gridApartados_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridApartados.InitializeLayout
        grid_diseño(gridApartados)
        gridapartados_diseño(gridApartados, e)
        gridApartados.DisplayLayout.Bands(0).Columns("OK_renglonCompleto").Header.Caption = "OK"
        gridApartados.DisplayLayout.Bands(0).Columns("Pedido").Header.Caption = "Pedido"
        gridApartados.DisplayLayout.Bands(0).Columns("PedidoDetalleID").Header.Caption = "Pedido Detalle"
        gridApartados.DisplayLayout.Bands(0).Columns("OC").Header.Caption = "OC"
        gridApartados.DisplayLayout.Bands(0).Columns("Semana").Header.Caption = "#Semana"
        gridApartados.DisplayLayout.Bands(0).Columns("FechaEntregaProgramacion").Header.Caption = "Programación"
        gridApartados.DisplayLayout.Bands(0).Columns("FechaEntregaCliente").Header.Caption = "Cliente"
        gridApartados.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
        gridApartados.DisplayLayout.Bands(0).Columns("Tienda").Header.Caption = "Tienda"
        gridApartados.DisplayLayout.Bands(0).Columns("Partida").Header.Caption = "Partida"
        gridApartados.DisplayLayout.Bands(0).Columns("Material").Header.Caption = "Material"
        gridApartados.DisplayLayout.Bands(0).Columns("Temporada").Header.Caption = "Temporada"
        'gridApartados.DisplayLayout.Bands(0).Columns("ParesPedidos").Header.Caption = "Pares en Pedidos"
        gridApartados.DisplayLayout.Bands(0).Columns("Numeracion").Header.Caption = "Numeración"
        gridApartados.DisplayLayout.Bands(0).Columns("CantidadPedido").Header.Caption = "Pedido"
        gridApartados.DisplayLayout.Bands(0).Columns("CantidadApartado").Header.Caption = "Apartado"
        gridApartados.DisplayLayout.Bands(0).Columns("CantidadPorApartar").Header.Caption = "Por Apartar"
        gridApartados.DisplayLayout.Bands(0).Columns("UnidadesManipulacion").Header.Caption = "Prepack"
        gridApartados.DisplayLayout.Bands(0).Columns("OK_UnidadManipulacion").Header.Caption = "OK"
        gridApartados.DisplayLayout.Bands(0).Columns("Destallados").Header.Caption = "Destallados"
        gridApartados.DisplayLayout.Bands(0).Columns("OK_Destallado").Header.Caption = "OK"
        gridApartados.DisplayLayout.Bands(0).Columns("Pares").Header.Caption = "Pares"
        gridApartados.DisplayLayout.Bands(0).Columns("OK_Pares").Header.Caption = "OK"
        gridApartados.DisplayLayout.Bands(0).Columns("Modificado").Header.Caption = "Modificado"
        gridApartados.DisplayLayout.Bands(0).Columns("BloqueadoAhora").Header.Caption = "Bloqueado Ahora"
        gridApartados.DisplayLayout.Bands(0).Columns("BloqueadoTresMeses").Header.Caption = "Bloqueado 3 meses"

    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_simple_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedido.InitializeLayout
        grid_simple_diseño(grdPedido)
        grdPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_simple_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_simple_diseño(grdTienda)
        grdTienda.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda"
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_simple_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_simple_diseño(grdModelo)
        grdModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_simple_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdRanking_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRanking.InitializeLayout
        grid_simple_diseño(grdRanking)
        grdRanking.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Ranking"
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_simple_diseño(grdNave)
        grdNave.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub

    Private Sub grdTemporada_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTemporada.InitializeLayout
        grid_simple_diseño(grdTemporada)
        grdTemporada.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Temporada"
    End Sub

    Private Sub chboxFiltrarFechaEntrega_CheckedChanged(sender As Object, e As EventArgs)
        If chboxFiltrarFechaEntrega.Checked Then
            lblEntregaDel.Enabled = True
            lblEntregaAl.Enabled = True
            dtpEntregaDel.Enabled = True
            dtpEntregaAl.Enabled = True
        Else
            lblEntregaDel.Enabled = False
            lblEntregaAl.Enabled = False
            dtpEntregaDel.Enabled = False
            dtpEntregaAl.Enabled = False
        End If
    End Sub

    Private Sub chboxFiltrarFechaPrograma_CheckedChanged(sender As Object, e As EventArgs)
        If chboxFiltrarFechaPrograma.Checked Then
            lblProgramaDel.Enabled = True
            lblProgramaAl.Enabled = True
            dtpProgramaDel.Enabled = True
            dtpProgramaAl.Enabled = True
        Else
            lblProgramaDel.Enabled = False
            lblProgramaAl.Enabled = False
            dtpProgramaDel.Enabled = False
            dtpProgramaAl.Enabled = False
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        btnAbajo_Click(sender, e)

        listPedidosSay = New List(Of String)

        gridApartados.DataSource = Nothing
        grdMarca.DataSource = Nothing
        grdPedido.DataSource = Nothing
        grdCliente.DataSource = Nothing
        grdTienda.DataSource = Nothing
        grdColeccion.DataSource = Nothing
        grdModelo.DataSource = Nothing
        grdCorrida.DataSource = Nothing
        grdRanking.DataSource = Nothing
        grdNave.DataSource = Nothing
        grdTemporada.DataSource = Nothing


        gridApartados.DataSource = dtInicial
        grdMarca.DataSource = listInicial
        grdPedido.DataSource = listPedidosSay
        grdCliente.DataSource = listInicial
        grdTienda.DataSource = listInicial
        grdColeccion.DataSource = listInicial
        grdModelo.DataSource = listInicial
        grdCorrida.DataSource = listInicial
        grdRanking.DataSource = listInicial
        grdNave.DataSource = listInicial
        grdTemporada.DataSource = listInicial
        chboxFiltrarFechaEntrega.Checked = False
        dtpEntregaDel.Value = Now.Date
        dtpEntregaAl.Value = Now.Date.AddDays(7)
        chboxFiltrarFechaPrograma.Checked = False
        dtpProgramaDel.Value = Now.Date
        dtpProgramaAl.Value = Now.Date.AddDays(7)
        chboxSeleccionarTodo.Checked = False
        chboxPrepack.Checked = True
        chboxDestallados.Checked = True
        chboxColocadoEnPrograma.Checked = True
        txtColocadoEnPrograma.Text = "3"
        txtNumeroTallas.Text = "3"
        txtNumeroPares.Text = "8"
        rdbMostrarFinal.Checked = True
        rdbDescartar.Checked = False

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub gridApartados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles gridApartados.DoubleClickCell
        If e.Cell.IsFilterRowCell = False Then
            Dim renglonSeleccionado As Integer = 0
            Dim detallePedidoID As String = String.Empty
            renglonSeleccionado = e.Cell.Row.Index
            detallePedidoID = gridApartados.Rows(renglonSeleccionado).Cells("PedidoDetalleID").Value.ToString()
            Dim ventana As New TallasEnPartida(detallePedidoID)
            ventana.ShowDialog()
        End If
    End Sub

    Private Sub btnResumen_Click(sender As Object, e As EventArgs) Handles btnResumen.Click
        Dim ventanaResumen As New ResumenApartados()
        ventanaResumen.ShowDialog()
    End Sub

    Private Sub chkColocadoEnPrograma_CheckedChanged(sender As Object, e As EventArgs)
        If chboxColocadoEnPrograma.Checked Then
            txtColocadoEnPrograma.Enabled = True
        Else
            txtColocadoEnPrograma.Enabled = False
        End If
    End Sub

    Private Sub gridApartados_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles gridApartados.InitializeRow

        If e.Row.Cells("BloqueadoTresMeses").Value = "1" Then
            e.Row.Cells("Cliente").Appearance.ForeColor = pnlClienteBloqueadoAnteriormente.BackColor
            e.Row.Cells("Cliente").Appearance.FontData.Bold = DefaultableBoolean.True
        End If
        If e.Row.Cells("BloqueadoAhora").Value = "1" Then
            e.Row.Cells("Cliente").Appearance.ForeColor = pnlClienteBloqueado.BackColor
            e.Row.Cells("Cliente").Appearance.FontData.Bold = DefaultableBoolean.True
        End If
        'If e.Row.Cells("Modificado").Value = "1" Then
        If e.Row.Cells("CantidadApartado").Value <> e.Row.Cells("CantidadPorApartar").Value Then
            e.Row.Cells("Modificado").Appearance.BackColor = pnlPartidaModificada.BackColor
            e.Row.Cells("Modificado").Appearance.ForeColor = pnlPartidaModificada.BackColor
        Else
            e.Row.Cells("Modificado").Appearance.BackColor = pnlPartidaNoModificada.BackColor
            e.Row.Cells("Modificado").Appearance.ForeColor = pnlPartidaNoModificada.BackColor
        End If
        If e.Row.Cells("CantidadApartado").Value > 0 Then
            e.Row.Cells("CantidadApartado").Appearance.BackColor = pnlApartadoDisponible.BackColor
            'Else
            '    e.Row.Hidden = True
        End If
        If e.Row.Cells("CantidadPedido").Value = e.Row.Cells("CantidadApartado").Value Then
            e.Row.Cells("CantidadPedido").Appearance.BackColor = pnlPartidaApartadoCompleta.BackColor
        End If
    End Sub

    Private Sub gridApartados_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridApartados.ClickCell
        If e.Cell.Column.Header.Caption = "OK" And e.Cell.IsFilterRowCell = False Then
            If CBool(e.Cell.Value) Then
                e.Cell.Value = False
            Else
                e.Cell.Value = True
            End If
        End If
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click

        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marcas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
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

    Private Sub txtPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedido.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then

            If String.IsNullOrEmpty(txtPedido.Text) Then Return
                listPedidosSay.Add(txtPedido.Text)
                grdPedido.DataSource = Nothing
                grdPedido.DataSource = listPedidosSay

                txtPedido.Text = String.Empty
        End If
    End Sub

    'Muestra el form de mensaje
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

    Private Sub grdPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub btnTienda_Click(sender As Object, e As EventArgs) Handles btnTienda.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 5
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTienda.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTienda.DataSource = listado.listParametros
        With grdTienda
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tienda"
        End With
    End Sub

    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdRanking_KeyDown(sender As Object, e As KeyEventArgs) Handles grdRanking.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdRanking.DeleteSelectedRows(False)
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub grdTemporada_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTemporada.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTemporada.DeleteSelectedRows(False)
    End Sub

    Private Sub btnColección_Click(sender As Object, e As EventArgs) Handles btnColección.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
        End With
    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 4
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

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 6
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdModelo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdModelo.DataSource = listado.listParametros
        With grdModelo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Modelos"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corridas"
        End With
    End Sub

    Private Sub btnRanking_Click(sender As Object, e As EventArgs) Handles btnRanking.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 8
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdRanking.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdRanking.DataSource = listado.listParametros
        With grdRanking
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Ranking"
        End With
    End Sub

    Private Sub btnTemporada_Click(sender As Object, e As EventArgs) Handles btnTemporada.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 9
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTemporada.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTemporada.DataSource = listado.listParametros
        With grdTemporada
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Temporada"
        End With
    End Sub

    Private Sub dtpEntregaDel_ValueChanged(sender As Object, e As EventArgs)
        dtpEntregaAl.MinDate = dtpEntregaDel.Value
    End Sub

    Private Sub dtpProgramaDel_ValueChanged(sender As Object, e As EventArgs)
        dtpProgramaAl.MinDate = dtpProgramaDel.Value
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        If gridApartados.Rows.Count > 0 Then
            Cursor = Cursors.WaitCursor
            If chboxSeleccionarTodo.Checked Then
                For Each row As UltraGridRow In gridApartados.Rows.GetFilteredInNonGroupByRows
                    row.Cells("OK_renglonCompleto").Value = True
                Next
            Else
                For Each row As UltraGridRow In gridApartados.Rows.GetFilteredInNonGroupByRows
                    row.Cells("OK_renglonCompleto").Value = False
                Next
            End If
            Cursor = Cursors.Default
        Else
            chboxSeleccionarTodo.Checked = False
        End If
    End Sub

    Private Sub gridApartados_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridApartados.SelectionDrag
        gridApartados.DoDragDrop(gridApartados.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub gridApartados_DragOver(sender As Object, e As DragEventArgs) Handles gridApartados.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.gridApartados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.gridApartados.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub gridApartados_DragDrop(sender As Object, e As DragEventArgs) Handles gridApartados.DragDrop
        Dim dropIndex As Integer

        'Get the position on the grid where the dragged row(s) are to be dropped. 
        'get the grid coordinates of the row (the drop zone) 
        Dim uieOver As UIElement = gridApartados.DisplayLayout.UIElement.ElementFromPoint(gridApartados.PointToClient(New Point(e.X, e.Y)))

        'get the row that is the drop zone/or where the dragged row is to be dropped 
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index    'index/position of drop zone in grid 

            'get the dragged row(s)which are to be dragged to another position in the grid 
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
            'get the count of selected rows and drop each starting at the dropIndex 
            For Each aRow As UltraGridRow In SelRows
                'move the selected row(s) to the drop zone 
                gridApartados.Rows.Move(aRow, dropIndex)
            Next

        End If
    End Sub

    Private Sub btnPrioridadClientes_Click(sender As Object, e As EventArgs) Handles btnPrioridadClientes.Click
        Dim ventana As New PrioridadClientesApartadosForm()
        ventana.ShowDialog()
    End Sub
End Class