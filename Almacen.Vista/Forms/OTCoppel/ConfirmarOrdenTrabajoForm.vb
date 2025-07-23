Imports Infragistics.Win.UltraWinGrid
Imports System.Media
Imports Infragistics.Win
Imports System.IO
Imports Tools

Public Class ConfirmarOrdenTrabajoForm
    Public VerDetalles As Boolean = False
    Public idPedido As Int32 = 0
    Public idTienda As Int32 = 0
    Public nombreTienda As String = ""
    Public idOtCoppel As Int32 = 0
    Dim perQuitarPares As Boolean = False
    Dim cadenaLectura As String = ""
    Dim ParEscaneado As String
    Dim estatusEscaneado As String = "" 'estatusParEscaneado
    Dim partidasCompletas As Integer = 0 '' guarda cuando una partida se completa
    Dim EsAtado As Boolean = False
    Dim LecturaTerminal As Boolean = False
    Dim usuarioTerminal As String = ""

    Public Sub CargarDatos() ''Metodo llamado en el load carga la informacion inicial
        Dim objBU As New Negocios.OTCoppelBU
        Dim dtTotalPares As New DataTable
        Dim dtDetalleConfirmado As New DataTable
        partidasCompletas = 0
        grdTotalPares.DataSource = ""
        lblNombreTienda.Text = nombreTienda
        lblIdOrden.Text = idOtCoppel
        lblIdPedido.Text = idPedido
        dtTotalPares = objBU.DetalleParesAConfirmar(idOtCoppel)
        grdTotalPares.DataSource = dtTotalPares
        formatoGridParesTotales()
        cargarTotalesInicial()
        FormatoGridParesConfirmar()

        If VerDetalles = True Then
            btnIniciar.Enabled = False
            lblIniciar.Enabled = False
            btnDetener.Enabled = False
            lblDetener.Enabled = False
            btnTerminal.Enabled = False
            lblTerminal.Enabled = False
            btnQuitarPares.Enabled = False
            lblQuitarPares.Enabled = False
            dtDetalleConfirmado = objBU.VerDetallesGridConfirmacion(idOtCoppel)
            'FormatoGridParesConfirmar()
            'grdParesPorConfirmar.DataSource = dtDetalleConfirmado
            'AgregarRenglonGridDetalles()
            grdParesConfirmadosAnteriormente.DataSource = dtDetalleConfirmado
            FormatoGridParesConfirmadosAnteriormente()
            AgregarRenglonGridParesConfirmadosAnteriormente()
            sPCParesConfirmar.SplitterDistance = 0
            sPCParesConfirmar.SplitterWidth = 1
            sPCParesConfirmar.IsSplitterFixed = True
            sPCParesConfirmar.Panel1.Hide()
            If grdParesConfirmadosAnteriormente.Rows.Count > 0 Then
                btnExportar.Enabled = True
                lblExportar.Enabled = True
            Else
                btnExportar.Enabled = False
                lblExportar.Enabled = False
            End If
        Else
            dtDetalleConfirmado = objBU.VerDetallesGridConfirmacion(idOtCoppel)
            grdParesConfirmadosAnteriormente.DataSource = dtDetalleConfirmado
            FormatoGridParesConfirmadosAnteriormente()
            AgregarRenglonGridParesConfirmadosAnteriormente()
            If grdParesConfirmadosAnteriormente.Rows.Count > 0 Then
                btnExportar.Enabled = True
                lblExportar.Enabled = True
            Else
                btnExportar.Enabled = False
                lblExportar.Enabled = False
            End If
        End If
    End Sub

    Public Sub cargarTotalesInicial()
        'Dim objBU As New Negocios.OTCoppelBU
        Dim totalP As Integer = 0
        Dim totalCon As Integer = 0
        Dim totalF As Integer = 0
        'Dim dtParesConfirmadosAnteriormente As New DataTable
        For Each row As UltraGridRow In grdTotalPares.Rows
            totalP = totalP + row.Cells("total").Value
            totalCon = totalCon + row.Cells("otcod_paresConfirmados").Value
            totalF = totalF + row.Cells("faltante").Value
            'dtParesConfirmadosAnteriormente = objBU.VerDetallesGridConfirmacion(idOtCoppel)
            'grdParesConfirmadosAnteriormente.DataSource = dtParesConfirmadosAnteriormente
            'FormatoGridParesConfirmadosAnteriormente()
        Next

        lblTotalPares.Text = totalP
        lblPorConfirmar.Text = totalF
        lblTotalConfirmados.Text = totalCon
    End Sub
    ''Se crean las columnas con el formato que tendra el grid de los pares de la lectura
    Public Sub FormatoGridParesConfirmar()
        Dim dtParesConfirmar As New DataTable
        Dim ColumnaLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Int32)

        Dim ColumnaAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)

        Dim ColumnaPar As New DataColumn("Par")
        ColumnaPar.DataType = GetType(String)

        Dim ColumnaRenglon As New DataColumn("Renglon")
        ColumnaRenglon.DataType = GetType(Int32)

        Dim ColumnaTalla As New DataColumn("IdtblTalla")
        ColumnaTalla.DataType = GetType(String)

        Dim ColumnaCalce As New DataColumn("Calce")
        ColumnaCalce.DataType = GetType(String)

        Dim ColumnaProducto As New DataColumn("IdProducto")
        ColumnaProducto.DataType = GetType(String)

        Dim columnaidNave As New DataColumn("idNave")
        columnaidNave.DataType = GetType(Int32)

        Dim ColumnaEstatusPar As New DataColumn("EstatusPar")
        ColumnaEstatusPar.DataType = GetType(String)

        Dim ColumnaPedido As New DataColumn("Pedido")
        ColumnaPedido.DataType = GetType(Int32)

        Dim ColumnaPartida As New DataColumn("Partida")
        ColumnaPartida.DataType = GetType(Int32)

        Dim ColumnaCliente As New DataColumn("Cliente")
        ColumnaCliente.DataType = GetType(Int32)

        Dim ColumnaEstatus As New DataColumn("Estatus")
        ColumnaEstatus.DataType = GetType(String)

        Dim ColumnaDescripcion As New DataColumn("Descripcion")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaNumero As New DataColumn("#")
        ColumnaNumero.DataType = GetType(Int32)

        Dim ColumnaNoAtado As New DataColumn("NumeroAtado")
        ColumnaNoAtado.DataType = GetType(Int32)

        Dim columnaNave As New DataColumn("Nave")
        columnaNave.DataType = GetType(String)

        Dim columnaEntradaAlmacen As New DataColumn("EntradaAlmacen")
        columnaEntradaAlmacen.DataType = GetType(String)

        Dim columnaAño As New DataColumn("Año")
        columnaAño.DataType = GetType(String)

        Dim columnaOrden As New DataColumn("Orden")
        columnaOrden.DataType = GetType(Int32)

        Dim columnaTienda As New DataColumn("Tienda")
        columnaTienda.DataType = GetType(String)

        Dim columnaTipoPar As New DataColumn("TipoPar")
        columnaTienda.DataType = GetType(String)

        dtParesConfirmar.Columns.Add(ColumnaNumero)
        dtParesConfirmar.Columns.Add(columnaTipoPar)
        dtParesConfirmar.Columns.Add(ColumnaAtado)
        dtParesConfirmar.Columns.Add(ColumnaPar)
        dtParesConfirmar.Columns.Add(ColumnaDescripcion)
        dtParesConfirmar.Columns.Add(ColumnaRenglon)
        dtParesConfirmar.Columns.Add(ColumnaCalce)
        dtParesConfirmar.Columns.Add(ColumnaLote)
        dtParesConfirmar.Columns.Add(columnaNave)
        dtParesConfirmar.Columns.Add(columnaAño)
        dtParesConfirmar.Columns.Add(columnaEntradaAlmacen)

        dtParesConfirmar.Columns.Add(ColumnaTalla)
        dtParesConfirmar.Columns.Add(ColumnaNoAtado)
        dtParesConfirmar.Columns.Add(ColumnaProducto)
        dtParesConfirmar.Columns.Add(columnaidNave)
        dtParesConfirmar.Columns.Add(ColumnaEstatusPar)
        dtParesConfirmar.Columns.Add(ColumnaPedido)
        dtParesConfirmar.Columns.Add(ColumnaPartida)
        dtParesConfirmar.Columns.Add(ColumnaCliente)
        dtParesConfirmar.Columns.Add(ColumnaEstatus)

        grdParesPorConfirmar.DataSource = Nothing
        grdParesPorConfirmar.DataSource = dtParesConfirmar
        grdParesPorConfirmar.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdParesPorConfirmar.DisplayLayout.Override.RowSelectorWidth = 35

        With grdParesPorConfirmar.DisplayLayout.Bands(0)
            .Columns("IdtblTalla").Hidden = True
            .Columns("IdProducto").Hidden = True
            .Columns("EstatusPar").Hidden = True
            .Columns("Pedido").Hidden = True
            .Columns("Partida").Hidden = True
            .Columns("Cliente").Hidden = True
            .Columns("Estatus").Hidden = True
            .Columns("NumeroAtado").Hidden = True
            .Columns("idNave").Hidden = True

            .Columns("TipoPar").Header.Caption = "St"
            .Columns("Calce").Header.Caption = "Talla"
            .Columns("Descripcion").Header.Caption = "Descripción"
            .Columns("Renglon").Header.Caption = "Renglón"
            .Columns("EntradaAlmacen").Header.Caption = "Entrada almacén"

            .Columns("Lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Atado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Renglon").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Calce").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("EntradaAlmacen").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("EntradaAlmacen").Style = ColumnStyle.DateTime

            .Columns("TipoPar").Width = 20
            .Columns("#").Width = 20
            .Columns("Atado").Width = 80
            .Columns("Par").Width = 80
            .Columns("Renglon").Width = 60
            .Columns("Descripcion").Width = 350
            .Columns("Calce").Width = 35
            .Columns("Año").Width = 35
            .Columns("EntradaAlmacen").Width = 120

        End With

    End Sub
    ''Se crean las columnas con el formato que tendra el grid de los pares que se confirmaron anteriormente
    Public Sub FormatoGridParesConfirmadosAnteriormente()

        grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowSelectorWidth = 35

        grdParesConfirmadosAnteriormente.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowSelectorWidth = 35
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        'grdParesConfirmadosAnteriormente.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grdParesConfirmadosAnteriormente.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdParesConfirmadosAnteriormente.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdParesConfirmadosAnteriormente.DisplayLayout.GroupByBox.Hidden = False
        grdParesConfirmadosAnteriormente.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        With grdParesConfirmadosAnteriormente.DisplayLayout.Bands(0)
            .Columns("#").Hidden = True
            .Columns("IdtblTalla").Hidden = True
            .Columns("IdProducto").Hidden = True
            .Columns("EstatusPar").Hidden = True
            .Columns("Pedido").Hidden = True
            .Columns("Partida").Hidden = True
            .Columns("Cliente").Hidden = True
            '.Columns("Estatus").Hidden = True
            '.Columns("NumeroAtado").Hidden = True
            .Columns("idNave").Hidden = True
            .Columns("idPedidoConfirmacion").Hidden = True
            .Columns("idOrdenTrabajoConfirmacion").Hidden = True
            .Columns("TiendaConfirmacion").Hidden = True

            .Columns("TipoPar").Header.Caption = "St"
            .Columns("Calce").Header.Caption = "Talla"
            .Columns("Descripcion").Header.Caption = "Descripción"
            .Columns("confirmo").Header.Caption = "Confirmó"
            .Columns("confirmacion").Header.Caption = "Confirmación"
            .Columns("Renglon").Header.Caption = "Renglón"
            .Columns("EntradaAlmacen").Header.Caption = "Entrada almacén"
            .Columns("idPedidoConfirmacion").Header.Caption = "Pedido"
            .Columns("idOrdenTrabajoConfirmacion").Header.Caption = "Orden de Trabajo"
            .Columns("TiendaConfirmacion").Header.Caption = "Tienda"

            .Columns("TipoPar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Atado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Renglon").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Calce").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("confirmo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("confirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("EntradaAlmacen").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("idPedidoConfirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("idOrdenTrabajoConfirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("TiendaConfirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Atado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Par").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Renglon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Calce").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Lote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("idPedidoConfirmacion").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("idOrdenTrabajoConfirmacion").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("confirmacion").Style = ColumnStyle.DateTime
            .Columns("EntradaAlmacen").Style = ColumnStyle.DateTime


            .Columns("TipoPar").Width = 25
            .Columns("Atado").Width = 80
            .Columns("Par").Width = 80
            .Columns("Descripcion").Width = 300
            .Columns("Renglon").Width = 60
            .Columns("Calce").Width = 35
            .Columns("Año").Width = 35
            .Columns("EntradaAlmacen").Width = 120
            .Columns("confirmacion").Width = 120
            .Columns("confirmo").Width = 80

        End With

    End Sub


    '' inicia la captura de codigos
    Public Sub iniciarCapturaCodigos()
        txtCapturaCodigos.Enabled = True
        txtCapturaCodigos.Select()
        btnIniciar.Enabled = False
        lblIniciar.Enabled = False
        btnDetener.Enabled = True
        lblDetener.Enabled = True
        btnTerminal.Enabled = False
        lblTerminal.Enabled = False
        btnQuitarPares.Enabled = False
        lblQuitarPares.Enabled = False
        LecturaTerminal = False
    End Sub

    ''Formato del grid con el total de pares que se debe de confirmar
    Public Sub formatoGridParesTotales()
        With grdTotalPares.DisplayLayout.Bands(0)
            .Columns("otcod_idOtCoppelDetalles").Hidden = True
            .Columns("otcod_idotCoppel").Hidden = True
            .Columns("otcod_idProducto").Hidden = True
            .Columns("estatus_Renglon").Hidden = True
            .Columns("idpiel").Hidden = True
            .Columns("color").Hidden = True
            .Columns("IdTalla").Hidden = True
            .Columns("confirmados_real").Hidden = True


            .Columns("Renglon").Header.Caption = "#"
            .Columns("IdModelo").Header.Caption = "Modelo"
            .Columns("Descripcion").Header.Caption = "Descripción"
            .Columns("otcod_talla").Header.Caption = "Talla"
            .Columns("total").Header.Caption = "Total"
            .Columns("otcod_paresConfirmados").Header.Caption = "Conf"
            .Columns("faltante").Header.Caption = "Faltante"

            .Columns("Renglon").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("idModelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otcod_talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("otcod_paresConfirmados").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("faltante").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Renglon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("otcod_talla").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("otcod_paresConfirmados").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("faltante").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right



        End With

        grdTotalPares.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdTotalPares.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdTotalPares.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdTotalPares.DisplayLayout.Override.RowSelectorWidth = 35
        grdTotalPares.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdTotalPares.Rows(0).Selected = True

        grdTotalPares.DisplayLayout.Bands(0).Columns("Renglon").Width = 20
        grdTotalPares.DisplayLayout.Bands(0).Columns("Faltante").Width = 45
        grdTotalPares.DisplayLayout.Bands(0).Columns("idModelo").Width = 40
        grdTotalPares.DisplayLayout.Bands(0).Columns("Renglon").Width = 25
        grdTotalPares.DisplayLayout.Bands(0).Columns("otcod_talla").Width = 35
        grdTotalPares.DisplayLayout.Bands(0).Columns("total").Width = 35
        grdTotalPares.DisplayLayout.Bands(0).Columns("otcod_paresConfirmados").Width = 35
        indicesGrid()
    End Sub

    Public Sub actualizarFaltanteGridPares(ByVal cantidad As Int32, ByVal IdDetalleOt As Int32, ByVal confirmado As Int32, ByVal detallePar As Entidades.ValidacionPar, ByVal guardar As Boolean)
        Dim totalPares As Integer = 0
        Dim totalConfirmar As Integer = 0
        Dim totalFaltante As Integer = 0
        Dim estatusTienda As String = ""
        For cont = 0 To grdTotalPares.Rows.Count - 1
            If grdTotalPares.Rows(cont).Cells("otcod_idOtCoppelDetalles").Value = IdDetalleOt Then
                If guardar = False Then
                    grdTotalPares.Rows(cont).Cells("faltante").Value = cantidad
                    grdTotalPares.Rows(cont).Cells("otcod_paresConfirmados").Value = confirmado
                End If
                estatusTienda = "PC"
                If grdTotalPares.Rows(cont).Cells("total").Value = grdTotalPares.Rows(cont).Cells("otcod_paresConfirmados").Value Then
                    If guardar = False Then
                        grdTotalPares.Rows(cont).CellAppearance.BackColor = DefaultBackColor
                        grdTotalPares.Rows(cont).Cells("estatus_Renglon").Value = "C"
                    End If
                    partidasCompletas = partidasCompletas + 1
                    If partidasCompletas >= grdTotalPares.Rows.Count Then
                        estatusTienda = "C"
                    End If
                End If
                If grdTotalPares.Rows(cont).Cells("total").Value = grdTotalPares.Rows(cont).Cells("confirmados_real").Value Then
                    If guardar = False Then
                        grdTotalPares.Rows(cont).CellAppearance.BackColor = DefaultBackColor
                        grdTotalPares.Rows(cont).Cells("estatus_Renglon").Value = "C"
                    End If
                    partidasCompletas = partidasCompletas + 1
                    If partidasCompletas >= grdTotalPares.Rows.Count Then
                        estatusTienda = "C"
                    End If
                End If
            End If
            'If guardar = True Then
            '    guardarPar(detallePar, IdDetalleOt, idOtCoppel, confirmado, estatusTienda)
            'End If
            totalPares = totalPares + grdTotalPares.Rows(cont).Cells("total").Value
            totalConfirmar = totalConfirmar + grdTotalPares.Rows(cont).Cells("otcod_paresConfirmados").Value
            totalFaltante = totalFaltante + grdTotalPares.Rows(cont).Cells("faltante").Value
        Next
        lblTotalPares.Text = totalPares
        lblPorConfirmar.Text = totalFaltante
        lblTotalConfirmados.Text = totalConfirmar

    End Sub
    ''valida que el par leido pertenezca a los pares de la venta
    Public Sub validaEstiloLectura(ByVal codigo As String, ByVal NumeroAtado As Integer, ByVal guardar As Boolean)
        Dim objBu As New Negocios.OTCoppelBU
        Dim ListaDetallePar As New List(Of Entidades.ValidacionPar)
        Dim estatus As String = ""
        Dim cantidad, confirmado, renglon As Int32
        Dim idDetalleOt As Int32 = 0

        Dim parRepetido As Int32 = 0

        'detallePar = objBu.ValidarParLeido(codigo, EsAtado)
        ListaDetallePar = objBu.ValidarParLeido(codigo, EsAtado)
        Dim total, totalActual As Integer
        total = grdParesPorConfirmar.Rows.Count
        totalActual = 0
        For Each detallePar As Entidades.ValidacionPar In ListaDetallePar
            renglon = 0
            If detallePar.PIdPar <> Nothing Then
                If guardar = False Then
                    For Each rowPar As UltraGridRow In grdParesPorConfirmar.Rows
                        If rowPar.Cells("Par").Value = detallePar.PIdPar Then
                            parRepetido += 1
                        End If
                    Next
                End If
                If parRepetido = 0 Then
                    For Each row As UltraGridRow In grdTotalPares.Rows
                        'If (row.Cells("Estatus_Renglon").Value.Equals("I") Or IsDBNull(row.Cells("Estatus_Renglon").Value)) Or (guardar = True) Then
                        If row.Cells("Estatus_Renglon").Value.Equals("I") Or IsDBNull(row.Cells("Estatus_Renglon").Value) Then
                            If row.Cells("otcod_idProducto").Value.ToString.Trim = detallePar.PIdProducto And row.Cells("otcod_talla").Value.ToString.Trim = detallePar.PCalce And row.Cells("IdTalla").Value.ToString.Trim = detallePar.PIdTalla Then
                                'And row.Cells("otcod_talla").Value = detallePar.PCalce Then
                                '
                                totalActual = totalActual + 1
                                estatus = "C" 'correcto
                                renglon = row.Cells("renglon").Value
                                If guardar = False Then
                                    cantidad = row.Cells("faltante").Value - 1
                                    confirmado = row.Cells("otcod_paresConfirmados").Value + 1
                                Else
                                    cantidad = row.Cells("faltante").Value
                                    confirmado = row.Cells("otcod_paresConfirmados").Value
                                End If
                                idDetalleOt = row.Cells("otcod_idOtCoppelDetalles").Value
                                Exit For
                            Else
                                If guardar = False Then
                                    estatus = "I"
                                    'ReproducirSonidoError()
                                End If
                            End If
                        Else
                            estatus = "I"
                        End If
                    Next
                End If
            End If
            If estatus = "C" And estatusEscaneado <> "I" Then
                actualizarFaltanteGridPares(cantidad, idDetalleOt, confirmado, detallePar, guardar)
            End If
            If parRepetido = 0 And guardar = False Then
                AgregarParGrid(detallePar, estatus, renglon, NumeroAtado)
                If estatus = "I" Then
                    txtCapturaCodigos.Enabled = False
                    Exit For
                End If
            End If
        Next

        If ListaDetallePar.Count = 0 Or parRepetido > 0 And guardar = False Then
            lblMensajeCapturaCodigos.Visible = True
            ReproducirSonidoError()
        End If
    End Sub

    Public Sub VerificarParYaEscaneado()
        estatusEscaneado = ""
        For cont = 0 To grdParesPorConfirmar.Rows.Count - 1
            'If cont = 0 Then
            '    Exit For
            'End If
            If grdParesPorConfirmar.Rows(cont).Cells("Par").Value.ToString.Trim = ParEscaneado Then
                ReproducirSonidoError()
                grdParesPorConfirmar.Rows(cont).Cells("estatus").Value = "I"
                estatusEscaneado = "I"
                Exit For
            End If
        Next
    End Sub
    ''sonido de error 
    Public Sub ReproducirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub
    '' Crea la numeracion para los renglones del grid totalPares
    Public Sub indicesGrid()
        Dim cont2 As Integer = 1
        For cont = 0 To grdTotalPares.Rows.Count - 1
            grdTotalPares.Rows(cont).Cells("Renglon").Value = cont2
            cont2 = cont2 + 1
            If grdTotalPares.Rows(cont).Cells("Total").Value <> grdTotalPares.Rows(cont).Cells("otcod_paresConfirmados").Value Then
                grdTotalPares.Rows(cont).Cells("estatus_Renglon").Value = "I"
                grdTotalPares.Rows(cont).CellAppearance.BackColor = Color.Gold
            Else
                partidasCompletas = partidasCompletas + 1
                grdTotalPares.Rows(cont).Cells("estatus_Renglon").Value = "C"
            End If
        Next
    End Sub

    Private Sub ConfirmarOrdenTrabajoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_OT_COPPEL", "ALM_OT_COPPEL_QUITARPARES") Then
            'btnQuitarPares.Visible = True
            'lblQuitarPares.Visible = True
        Else
            btnQuitarPares.Visible = False
            lblQuitarPares.Visible = False
        End If
        CargarDatos()
        Me.Top = 45

    End Sub

    Public Sub AgregarParGrid(DetallePar As Entidades.ValidacionPar, ByVal estatus As String, ByVal renglon As Int32, ByVal NoAtado As Int32)
        '   VerificarParYaEscaneado()
        Dim advertencia As New AdvertenciaFormSinBoton
        Dim rowPar As UltraGridRow = Me.grdParesPorConfirmar.DisplayLayout.Bands(0).AddNew
        Dim totalExternos As Integer = 0
        Dim totalCorrectos As Integer = 0

        totalExternos = Integer.Parse(lblTotalExternos.Text)
        totalCorrectos = Integer.Parse(lblTotalCorrectos.Text)
        If estatusEscaneado = "I" Then
            ' rowPar.CellAppearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8080")
            rowPar.Cells("renglon").Value = 0
            rowPar.Cells("estatus").Value = estatusEscaneado
        Else
            rowPar.Cells("renglon").Value = renglon
            rowPar.Cells("estatus").Value = estatus
        End If
        rowPar.Cells("TipoPar").Value = DetallePar.PTipoPar
        rowPar.Cells("idProducto").Value = DetallePar.PIdProducto
        rowPar.Cells("Partida").Value = DetallePar.PIdPartida
        rowPar.Cells("Pedido").Value = DetallePar.PIdPedido
        rowPar.Cells("Cliente").Value = DetallePar.PIdCliente
        rowPar.Cells("EstatusPar").Value = DetallePar.PEstatusPar
        rowPar.Cells("idnave").Value = DetallePar.PIdNave

        rowPar.Cells("IdtblTalla").Value = DetallePar.PIdTalla
        rowPar.Cells("Atado").Value = DetallePar.PIdDocena

        rowPar.Cells("par").Value = DetallePar.PIdPar
        rowPar.Cells("NumeroAtado").Value = NoAtado
        rowPar.Cells("Lote").Value = DetallePar.PIdLote
        rowPar.Cells("Descripcion").Value = DetallePar.PDescripcion
        rowPar.Cells("Calce").Value = DetallePar.PCalce

        rowPar.Cells("nave").Value = DetallePar.PNave
        rowPar.Cells("EntradaAlmacen").Value = DetallePar.PEntradaAlmacen
        rowPar.Cells("Año").Value = DetallePar.PAño


        If rowPar.Cells("estatus").Value = "I" Then
            rowPar.Cells("TipoPar").Value = ""
            rowPar.CellAppearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8080")
            btnGuardar.Enabled = False
            ReproducirSonidoError()
            advertencia.mensaje = "Se detectó producto que no se puede confirmar en esta OT, limpia y vuelve a leer"
            advertencia.ShowDialog()
        Else
            If DetallePar.PTipoPar = "E" Then
                rowPar.Cells("TipoPar").Appearance.BackColor = Color.Red
                totalExternos += 1
                lblTotalExternos.Text = totalExternos.ToString()
            ElseIf DetallePar.PTipoPar = "C" Then
                rowPar.Cells("TipoPar").Appearance.BackColor = Color.Green
                totalCorrectos += 1
                lblTotalCorrectos.Text = totalCorrectos.ToString()
            End If

        End If




        EnumerarIndicesRenglonGrid()



    End Sub

    Public Sub EnumerarIndicesRenglonGrid()
        For cont = grdParesPorConfirmar.Rows.Count - 1 To 0 Step -1
            If grdParesPorConfirmar.Rows.Count = 1 Then
                grdParesPorConfirmar.Rows(cont).Cells("#").Value = 1
                cont = 0
            Else
                grdParesPorConfirmar.Rows(cont).Cells("#").Value = grdParesPorConfirmar.Rows(cont - 1).Cells("#").Value + 1
                cont = 0
            End If
        Next
    End Sub

    Public Sub EnumerarIndicesRenglonGridDetalles()
        Dim cont2 As Integer = 1
        For cont = 0 To grdParesPorConfirmar.Rows.Count - 1
            'If grdParesPorConfirmar.Rows.Count = 1 Then
            grdParesPorConfirmar.Rows(cont).Cells("#").Value = cont2
            cont2 = cont2 + 1
            'Else
            'grdParesPorConfirmar.Rows(cont).Cells("#").Value = grdParesPorConfirmar.Rows(cont - 1).Cells("#").Value + 1
            'cont = 0
            'End If
        Next
    End Sub

    Private Sub txtCapturaCodigos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCapturaCodigos.KeyPress
        Dim advertencia As New AdvertenciaFormSinBoton
        Dim mensajeAtado As String
        Dim validacionAtado As Integer = 0
        Dim CodigoLeido As String = String.Empty
        mensajeAtado = ""
        lblMensajeCapturaCodigos.Visible = False
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim codigosLectura As String()
            Dim Noatado As Integer = 0


            CodigoLeido = txtCapturaCodigos.Text.Replace("'", "-")
            CodigoLeido = CodigoLeido.ToUpper.Replace("PC", "Y-000-")

            codigosLectura = (LTrim(RTrim(CodigoLeido))).Split("-")

            If (LTrim(RTrim(txtCapturaCodigos.Text))) = "" Then Return

            If codigosLectura.Length = 3 Then

                If codigosLectura.Length = 1 Then
                    codigosLectura = (LTrim(RTrim(txtCapturaCodigos.Text.ToUpper))).Split("'")
                    If codigosLectura.Length = 1 Then
                        ReproducirSonidoError()
                        lblMensajeCapturaCodigos.Visible = True
                    End If
                End If
                cadenaLectura = codigosLectura(2)
                ParEscaneado = cadenaLectura
                Noatado = cadenaLectura.Substring(8, 1)
                EsAtado = False
                validaEstiloLectura(cadenaLectura, Noatado, False)
            ElseIf (LTrim(RTrim(txtCapturaCodigos.Text))).Length = 11 Then
                cadenaLectura = (LTrim(RTrim(txtCapturaCodigos.Text)))
                Noatado = cadenaLectura.Substring(8, 1)
                EsAtado = True
                validacionAtado = validaAtado(cadenaLectura)
                If validacionAtado = 0 Then
                    validaEstiloLectura(cadenaLectura, Noatado, False)
                Else
                    If validacionAtado = 1 Then
                        mensajeAtado = "Atado " + cadenaLectura + " con pares externos, leer par por par"
                    ElseIf validacionAtado = 2 Then
                        mensajeAtado = "Atado " + cadenaLectura + " con pares confirmados, leer par por par"
                    End If
                    ReproducirSonidoError()
                    advertencia.mensaje = mensajeAtado
                    advertencia.ShowDialog()
                End If
            Else
                ReproducirSonidoError()
                lblMensajeCapturaCodigos.Visible = True
            End If
            txtCapturaCodigos.Text = ""
        End If
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        iniciarCapturaCodigos()
    End Sub

    Private Sub grdParesPorConfirmar_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)

        With grdParesPorConfirmar.DisplayLayout.Bands(0)
            .Columns("Partida").Hidden = True
            .Columns("Pedido").Hidden = True
            .Columns("Cliente").Hidden = True
            .Columns("estatusPar").Hidden = True
            .Columns("estatus").Hidden = True
            .Columns("Nave").Hidden = True
            .Columns("idProducto").Hidden = True

            .Columns("idtblTalla").Hidden = True
            .Columns("Atado").Hidden = True

            .Columns("NumeroAtado").Header.Caption = "No.Atado"

            .Columns("Calce").Header.Caption = "Talla"
            .Columns("Renglon").Header.Caption = "Renglón OT"
            .Columns("#").CellActivation = Activation.NoEdit
            .Columns("Par").CellActivation = Activation.NoEdit
            .Columns("NumeroAtado").CellActivation = Activation.NoEdit
            .Columns("Lote").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .Columns("Renglon").CellActivation = Activation.NoEdit
            .Columns("Calce").CellActivation = Activation.NoEdit

            .Columns("NumeroAtado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Calce").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Renglon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With

        grdParesPorConfirmar.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdParesPorConfirmar.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdParesPorConfirmar.DisplayLayout.Override.RowSelectorWidth = 45

        grdParesPorConfirmar.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        grdParesPorConfirmar.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdParesPorConfirmar.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdParesPorConfirmar.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdParesPorConfirmar.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("#").Width = 15
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("Lote").Width = 30
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("NumeroAtado").Width = 30
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("NumeroAtado").Width = 30
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("Calce").Width = 20
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("Renglon").Width = 30
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("calce").Width = 25
        grdParesPorConfirmar.DisplayLayout.Bands(0).Columns("Descripcion").Width = 120


    End Sub

    Private Sub txtCapturaCodigos_Leave(sender As Object, e As EventArgs) Handles txtCapturaCodigos.Leave
        If btnDetener.Focused = False Then
            txtCapturaCodigos.Focus()
        End If
    End Sub


    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        btnIniciar.Enabled = True
        lblIniciar.Enabled = True
        txtCapturaCodigos.Enabled = False
        btnTerminal.Enabled = False
        btnTerminal.Enabled = True
        lblTerminal.Enabled = True
        'lblQuitarPares.Enabled = True
        'btnQuitarPares.Enabled = True
        lblMensajeCapturaCodigos.Visible = False

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Dim formaConfirmacion As New ConfirmarForm
        'formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        'formaConfirmacion.mensaje = "Todos los pares sin guardar se borrarán ¿Estas seguro que deseas salir?"

        'If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
        Me.Close()
        'End If
    End Sub


    'Public Sub RecorrerGridGuardar(ByVal estatusOt As String)
    '    Dim objBu As New Negocios.OTCoppelBU
    '    Dim idOtCoppelDetalles As Int32 = 0
    '    Dim idOtCoppel, paresConfirmado As Int32
    '    Dim DetallesPares As New Entidades.ValidacionPar
    '    Dim FormaExito As New ExitoForm
    '    Cursor = Cursors.WaitCursor
    '    For Each row As UltraGridRow In grdTotalPares.Rows
    '        If row.Cells("Estatus_Renglon").Value = "C" Then
    '            For Each rowGridConfirmar As UltraGridRow In grdParesPorConfirmar.Rows
    '                If rowGridConfirmar.Cells("Renglon").Value = row.Cells("renglon").Value Then
    '                    DetallesPares.PIdPar = rowGridConfirmar.Cells("Par").Value
    '                    DetallesPares.PIdDocena = rowGridConfirmar.Cells("Atado").Value
    '                    DetallesPares.PEstatusPar = rowGridConfirmar.Cells("estatusPar").Value
    '                    DetallesPares.PIdPartida = rowGridConfirmar.Cells("Partida").Value
    '                    DetallesPares.PIdPedido = rowGridConfirmar.Cells("Pedido").Value
    '                    DetallesPares.PIdCliente = rowGridConfirmar.Cells("Cliente").Value
    '                    DetallesPares.PIdNave = rowGridConfirmar.Cells("Nave").Value
    '                    DetallesPares.PIdLote = rowGridConfirmar.Cells("Lote").Value
    '                    idOtCoppelDetalles = row.Cells("otcod_idOtCoppelDetalles").Value

    '                    objBu.InsertarDetalleParesOT(DetallesPares, idOtCoppelDetalles)
    '                End If
    '            Next
    '            idOtCoppel = row.Cells("otcod_idotCoppel").Value
    '            paresConfirmado = row.Cells("otcod_paresConfirmados").Value
    '            objBu.ActualizarEstatusOTCoppel(idOtCoppel, paresConfirmado, idOtCoppelDetalles, estatusOt)
    '        End If
    '    Next
    '    Cursor = Cursors.Default
    '    FormaExito.mensaje = "Confirmación Guardada"
    '    FormaExito.Show()
    '    limpiarVariables()
    'End Sub

    Public Sub limpiarVariables()
        btnIniciar.Enabled = False
        lblIniciar.Enabled = False
        btnDetener.Enabled = True
        lblDetener.Enabled = True
        btnTerminal.Enabled = False
        lblTerminal.Enabled = False
        btnQuitarPares.Enabled = False
        lblQuitarPares.Enabled = False
    End Sub

    Public Sub guardarPar(ByVal DetallePar As Entidades.ValidacionPar, ByVal idOtCoppelDetalles As Int32, ByVal idOtCoppel As Integer, ByVal paresConfirmado As Integer)
        Dim objBu As New Negocios.OTCoppelBU
        Dim usuario As String = ""
        'If LecturaTerminal = True Then
        '    usuario = usuarioTerminal
        'Else
        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'End If

        objBu.InsertarDetalleParesOT(DetallePar, idOtCoppelDetalles, idOtCoppel, paresConfirmado, usuario)
    End Sub

    Public Sub guardarEstatusDetalle(ByVal idOtCoppelDetalles As Int32, ByVal paresConfirmado As Integer, ByVal estatusDetalle As String)
        Dim objBu As New Negocios.OTCoppelBU
        Dim usuario As String = ""
        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objBu.ActualizarDetallesOTCoppel(idOtCoppelDetalles, paresConfirmado, usuario, estatusDetalle)
    End Sub

    Public Sub guardarEstatusOT(ByVal idOtCoppel As Int32, ByVal EstatusOt As String, ByVal paresConfirmados As Int32, ByVal paresCorrectos As Int32, ByVal paresExternos As Int32)
        Dim objBu As New Negocios.OTCoppelBU
        Dim usuario As String = ""
        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objBu.ActualizarOTCoppel(idOtCoppel, EstatusOt, paresConfirmados, usuario, paresCorrectos, paresExternos)
    End Sub

    Public Sub AgregarRenglonGridDetalles()
        Dim renglon As Integer = 0
        For cont = 0 To grdTotalPares.Rows.Count - 1
            For Each row As UltraGridRow In grdParesPorConfirmar.Rows
                If row.Cells("idProducto").Value.ToString.Trim = grdTotalPares.Rows(cont).Cells("otcod_idProducto").Value.ToString.Trim And row.Cells("Calce").Value.ToString.Trim = grdTotalPares.Rows(cont).Cells("otcod_talla").Value.ToString.Trim And row.Cells("idtblTalla").Value.ToString.Trim = grdTotalPares.Rows(cont).Cells("IdTalla").Value.ToString.Trim Then

                    renglon = grdTotalPares.Rows(cont).Cells("renglon").Value
                    row.Cells("Renglon").Value = renglon

                End If
            Next
        Next
        EnumerarIndicesRenglonGridDetalles()
    End Sub

    Public Sub AgregarRenglonGridParesConfirmadosAnteriormente()
        Dim renglon As Integer = 0
        Dim totalExternos As Integer = 0
        Dim totalCorrectos As Integer = 0
        For cont = 0 To grdTotalPares.Rows.Count - 1
            For Each row As UltraGridRow In grdParesConfirmadosAnteriormente.Rows
                If row.Cells("idProducto").Value.ToString.Trim = grdTotalPares.Rows(cont).Cells("otcod_idProducto").Value.ToString.Trim And row.Cells("Calce").Value.ToString.Trim = grdTotalPares.Rows(cont).Cells("otcod_talla").Value.ToString.Trim And row.Cells("idtblTalla").Value.ToString.Trim = grdTotalPares.Rows(cont).Cells("IdTalla").Value.ToString.Trim Then

                    renglon = grdTotalPares.Rows(cont).Cells("renglon").Value
                    row.Cells("Renglon").Value = renglon
                    If row.Cells("TipoPar").Value = "E" Then
                        row.Cells("TipoPar").Appearance.BackColor = Color.Red
                        totalExternos += 1
                        lblTotalExternos.Text = totalExternos.ToString()
                    ElseIf row.Cells("TipoPar").Value = "C" Then
                        row.Cells("TipoPar").Appearance.BackColor = Color.Green
                        totalCorrectos += 1
                        lblTotalCorrectos.Text = totalCorrectos.ToString()
                    End If

                End If
            Next
        Next
        EnumerarIndicesRenglonGridDetalles()
    End Sub

    Public Sub CargarArchivoLeerTerminal()
        Dim myStream As Stream = Nothing
        Dim openFileDialog As New OpenFileDialog
        Dim MensajeError As New ErroresForm
        Dim MensajeAviso As New AvisoForm
        openFileDialog.InitialDirectory = "c:\"
        openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"
        openFileDialog.FilterIndex = 2
        openFileDialog.RestoreDirectory = True

        MensajeAviso.mensaje = "Este proceso puede tardar dependiendo de la cantidad de pares a validar"
        MensajeAviso.ShowDialog()
        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Try
                myStream = openFileDialog.OpenFile()
                If (openFileDialog.FileName IsNot Nothing) Then

                    LeerLineasArchivoCargado(openFileDialog.FileName)

                End If
            Catch Ex As Exception
                MensajeError.mensaje = "No se puede leer el archivo. Error original: " & Ex.Message
                MensajeError.ShowDialog()
            Finally

                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub LeerLineasArchivoCargado(ByVal ruta As String)
        Dim reader As New StreamReader(ruta)
        Dim linea As String = ""
        Dim arrArchivo As New ArrayList()
        Dim cadenaLectura As String = ""
        LecturaTerminal = True
        Dim codigosLectura As String()
        Dim Noatado As Integer = 0
        Dim validacionAtado As Integer = 0
        Dim codigoLeido As String = String.Empty

        Do
            linea = reader.ReadLine
            If Not linea Is Nothing Then
                arrArchivo.Add(linea)
            End If
        Loop Until linea Is Nothing
        reader.Close()

        'If ValidaUSuarioOT(arrArchivo.Item(0), arrArchivo.Item(1)) = True Then
        Me.Cursor = Cursors.WaitCursor
        For cont = 1 To arrArchivo.Count - 1
            codigoLeido = LTrim(RTrim(arrArchivo.Item(cont)))
            If codigoLeido <> "" Then

                codigoLeido = codigoLeido.Replace("PC", "Y-000-")
                codigoLeido = codigoLeido.Replace("'", "-")

                'codigosLectura = (LTrim(RTrim(arrArchivo.Item(cont)))).Split("-")
                codigosLectura = (LTrim(RTrim(codigoLeido))).Split("-")

                If codigosLectura.Length = 3 Then

                    If codigosLectura.Length = 1 Then
                        codigosLectura = (LTrim(RTrim(arrArchivo.Item(cont)))).Split("'")
                        If codigosLectura.Length = 1 Then
                            ReproducirSonidoError()
                        End If
                    End If
                    cadenaLectura = codigosLectura(2)
                    Noatado = cadenaLectura.Substring(8, 1)
                    EsAtado = False
                    validaEstiloLectura(cadenaLectura, Noatado, False)

                ElseIf (LTrim(RTrim(arrArchivo.Item(cont)))).Length = 11 Then
                    cadenaLectura = (LTrim(RTrim(arrArchivo.Item(cont))))
                    Noatado = cadenaLectura.Substring(8, 1)
                    EsAtado = True
                    validacionAtado = validaAtado(cadenaLectura)
                    If validacionAtado = 0 Then
                        validaEstiloLectura(cadenaLectura, Noatado, False)
                    End If
                    'validaEstiloLectura(cadenaLectura, Noatado, False)

                Else
                    ReproducirSonidoError()
                End If
            End If
        Next
        Me.Cursor = Cursors.Default
        'End If

    End Sub
    Public Function ValidaUSuarioOT(ByVal colaborador As String, ByVal idOt As String) As Boolean
        Dim advetencia As New AdvertenciaForm
        If colaborador.Contains("EM") Then
            If idOt = idOtCoppel.ToString Then
                ValidaUSuarioOT = True
                usuarioTerminal = colaborador.Remove(0, 2)
            Else
                advetencia.mensaje = "La orden que trata de confirmar no corresponde a la orden escaneada."
                advetencia.ShowDialog()
                ValidaUSuarioOT = False
            End If
        Else
            advetencia.mensaje = "El archivo no contiene el usuario.Escanee su credencial "
            advetencia.ShowDialog()
            ValidaUSuarioOT = False
        End If

        Return ValidaUSuarioOT
    End Function

    Private Sub btnTerminal_Click(sender As Object, e As EventArgs) Handles btnTerminal.Click
        btnIniciar.Enabled = False
        lblIniciar.Enabled = False
        btnDetener.Enabled = False
        lblDetener.Enabled = False
        'btnQuitarPares.Enabled = True
        'lblQuitarPares.Enabled = True
        CargarArchivoLeerTerminal()
        lblMensajeCapturaCodigos.Visible = False
    End Sub

    Public Sub QuitarParesGrid(ByVal idPar As String)
        Dim renglon As Integer = 0
        Dim advetencia As New AdvertenciaForm
        If idPar <> "" Then
            For Each row As UltraGridRow In grdParesPorConfirmar.Rows
                If row.Cells("Par").Value = idPar Then
                    renglon = row.Cells("renglon").Value
                    actualizarTotalesQuitar(renglon, idPar)
                    row.Delete()
                    EnumerarIndicesRenglonGridDetalles()
                End If
            Next
        Else
            advetencia.mensaje = "Seleccione el par que desea quitar"
            advetencia.ShowDialog()
        End If
    End Sub

    Public Sub actualizarTotalesQuitar(ByVal renglon As Integer, ByVal idPar As String)
        Dim fal, conf, paresConf As Integer
        Dim idotDetalles As Integer
        Dim obj As New Negocios.OTCoppelBU
        Dim estatusTienda As String = ""
        For Each row As UltraGridRow In grdTotalPares.Rows
            If row.Cells("renglon").Value = renglon Then
                idotDetalles = row.Cells("otcod_idOtCoppelDetalles").Value

                fal = row.Cells("faltante").Value
                conf = row.Cells("otcod_paresConfirmados").Value
                row.Cells("faltante").Value = fal + 1
                row.Cells("otcod_paresConfirmados").Value = conf - 1
                paresConf = row.Cells("otcod_paresConfirmados").Value
                If row.Cells("total").Value > row.Cells("otcod_paresConfirmados").Value Then
                    row.CellAppearance.BackColor = Color.Gold
                    row.Cells("estatus_Renglon").Value = "I"
                    partidasCompletas = partidasCompletas - 1
                    If partidasCompletas < grdTotalPares.Rows.Count Then
                        estatusTienda = "PC"
                    Else
                        estatusTienda = "C"
                    End If
                End If
                obj.ActualizarQuitarPar(idPar, idotDetalles, idOtCoppel, estatusTienda, paresConf)
            End If

        Next
        cargarTotalesInicial()
    End Sub

    Private Sub btnQuitarPares_Click(sender As Object, e As EventArgs) Handles btnQuitarPares.Click
        Dim idPar As String = ""
        For cont = 0 To grdParesPorConfirmar.Rows.Count - 1
            If grdParesPorConfirmar.Rows(cont).Cells("Par").Selected = True Then
                idPar = grdParesPorConfirmar.Rows(cont).Cells("Par").Value
            End If
        Next

        QuitarParesGrid(idPar)
    End Sub

    Private Sub grdParesPorConfirmar_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs)
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty

        grid = grdParesConfirmadosAnteriormente

        With grid.DisplayLayout.Bands(0)
            .Columns("idPedidoConfirmacion").Hidden = False
            .Columns("idOrdenTrabajoConfirmacion").Hidden = False
            .Columns("TiendaConfirmacion").Hidden = False
        End With

        nombreDocumento = "\Pares_Confirmados_Orden" + lblIdOrden.Text + "_"

        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then

                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")

                With grid.DisplayLayout.Bands(0)
                    .Columns("idPedidoConfirmacion").Hidden = True
                    .Columns("idOrdenTrabajoConfirmacion").Hidden = True
                    .Columns("TiendaConfirmacion").Hidden = True
                End With
                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = "Los datos se exportaron correctamente"
                mensajeExito.ShowDialog()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim Noatado As Int32 = 0
        Dim objBU As New Negocios.OTCoppelBU
        Dim dtDetalleConfirmado As DataTable
        Dim formaConfirmacion As New ConfirmarForm
        Dim advertencia As New AdvertenciaForm
        Dim mensajeOrdenIncompleta As String = ""
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        If lblPorConfirmar.Text > 0 Then
            mensajeOrdenIncompleta = "La orden de trabajo quedará parcialmente confirmada "
        End If
        formaConfirmacion.mensaje = mensajeOrdenIncompleta + "¿Estas seguro que deseas guardar?"

        If grdParesPorConfirmar.Rows.Count > 0 Then
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                'For Each renglon As UltraGridRow In grdParesPorConfirmar.Rows
                '    EsAtado = False
                '    validaEstiloLectura(renglon.Cells("Par").Value.ToString, renglon.Cells("NumeroAtado").Value.ToString, True)
                'Next
                GuardarParesEscaneados()
                dtDetalleConfirmado = objBU.VerDetallesGridConfirmacion(idOtCoppel)
                grdParesConfirmadosAnteriormente.DataSource = dtDetalleConfirmado
                FormatoGridParesConfirmadosAnteriormente()
                AgregarRenglonGridParesConfirmadosAnteriormente()
                If grdParesConfirmadosAnteriormente.Rows.Count > 0 Then
                    btnExportar.Enabled = True
                    lblExportar.Enabled = True
                Else
                    btnExportar.Enabled = False
                    lblExportar.Enabled = False
                End If
                btnDetener_Click(sender, e)
                grdParesPorConfirmar.DataSource = Nothing
                FormatoGridParesConfirmar()
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                btnLimpiar.Enabled = False
                lblLimpiar.Enabled = False
                btnDetener.Enabled = False
                lblDetener.Enabled = False
                btnIniciar.Enabled = False
                lblIniciar.Enabled = False
                btnTerminal.Enabled = False
                lblTerminal.Enabled = False
                Cursor = Cursors.Default
                Dim mensajeExito As New ExitoForm
                mensajeExito.mensaje = "Datos guardados correctamente"
                mensajeExito.ShowDialog()
            End If
        Else
            advertencia.mensaje = "No se ha escaneado ningún par"
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Cursor = Cursors.WaitCursor
        Dim formaConfirmacion As New ConfirmarForm
        Dim advertencia As New AdvertenciaForm
        Dim paresCapturados As Int32 = 0
        Dim incidencias As Int32 = 0
        Dim objBU As New Negocios.OTCoppelBU
        Dim usuario As String = ""
        If LecturaTerminal = True Then
            usuario = usuarioTerminal
        Else
            usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        End If
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "Todos los pares sin guardar se borrarán ¿Estas seguro que deseas limpiar?"
        If grdParesPorConfirmar.Rows.Count > 0 Then
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                paresCapturados = grdParesPorConfirmar.Rows.Count
                For Each rowPar As UltraGridRow In grdParesPorConfirmar.Rows
                    If rowPar.Cells("estatus").Value = "I" Then
                        incidencias += 1
                    End If
                Next
                If incidencias > 0 Then
                    objBU.InsertarIncidencias(lblIdOrden.Text, usuario, paresCapturados, incidencias)
                End If
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
                btnIniciar.Enabled = True
                btnDetener.Enabled = True
                lblIniciar.Enabled = True
                lblTerminal.Enabled = True
                btnTerminal.Enabled = True
                lblDetener.Enabled = True
                txtCapturaCodigos.Enabled = False
                lblTotalCorrectos.Text = "0"
                lblTotalExternos.Text = "0"
                CargarDatos()
            End If
        Else
            advertencia.mensaje = "No se ha escaneado ningún par"
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ConfirmarOrdenTrabajoForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If grdParesPorConfirmar.Rows.Count > 0 Then
            Dim formaConfirmacion As New ConfirmarForm
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "Todos los pares sin guardar se borrarán ¿Estas seguro que deseas salir?"
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub

    Public Sub GuardarParesEscaneados()
        Dim DetallePar As New Entidades.ValidacionPar
        Dim listaPares As New List(Of Entidades.ValidacionPar)
        Dim estatus As String = ""
        Dim estatusDetalle As String = ""
        Dim estatusOT As String = ""
        Dim cantidad, confirmado, renglon, totalPares, confirmadoTotal, correctoTotal, externoTotal As Int32
        Dim renglonConfirmado As Int32 = 0
        Dim idDetalleOt As Int32 = 0

        If grdParesPorConfirmar.Rows.Count > 0 Then
            For Each rowPar As UltraGridRow In grdParesPorConfirmar.Rows
                DetallePar = New Entidades.ValidacionPar
                DetallePar.PTipoPar = rowPar.Cells("TipoPar").Value
                DetallePar.PIdPar = rowPar.Cells("Par").Value
                DetallePar.PIdDocena = rowPar.Cells("Atado").Value
                DetallePar.PIdPartida = rowPar.Cells("Renglon").Value
                DetallePar.PIdPedido = rowPar.Cells("Pedido").Value
                DetallePar.PIdCliente = rowPar.Cells("Cliente").Value
                DetallePar.PIdNave = rowPar.Cells("idNave").Value
                DetallePar.PIdLote = rowPar.Cells("Lote").Value
                DetallePar.PEstatusPar = rowPar.Cells("EstatusPar").Value
                DetallePar.PDescripcion = rowPar.Cells("Descripcion").Value
                DetallePar.PIdProducto = rowPar.Cells("IdProducto").Value
                DetallePar.PCalce = rowPar.Cells("Calce").Value
                DetallePar.PIdTalla = rowPar.Cells("IdtblTalla").Value
                DetallePar.PNave = rowPar.Cells("Nave").Value
                DetallePar.PEntradaAlmacen = rowPar.Cells("EntradaAlmacen").Value
                DetallePar.PAño = rowPar.Cells("Año").Value
                listaPares.Add(DetallePar)
            Next
        End If
        For Each detalle As Entidades.ValidacionPar In listaPares
            For Each row As UltraGridRow In grdTotalPares.Rows
                If row.Cells("otcod_idProducto").Value.ToString.Trim = detalle.PIdProducto And row.Cells("otcod_talla").Value.ToString.Trim = detalle.PCalce And row.Cells("IdTalla").Value.ToString.Trim = detalle.PIdTalla Then
                    'And row.Cells("otcod_talla").Value = detallePar.PCalce Then
                    estatus = "C" 'correcto
                    renglon = row.Cells("renglon").Value
                    totalPares = row.Cells("total").Value
                    confirmado = row.Cells("confirmados_real").Value + 1
                    idDetalleOt = row.Cells("otcod_idOtCoppelDetalles").Value
                    row.Cells("confirmados_real").Value = confirmado
                    Exit For
                End If
            Next
            If estatus = "C" Then
                guardarPar(detalle, idDetalleOt, idOtCoppel, confirmado)
            End If
        Next
        For Each row As UltraGridRow In grdTotalPares.Rows
            estatusDetalle = ""
            totalPares = row.Cells("total").Value
            confirmado = row.Cells("confirmados_real").Value
            idDetalleOt = row.Cells("otcod_idOtCoppelDetalles").Value
            If confirmado = totalPares Then
                renglonConfirmado += 1
                estatusDetalle = "C"
            End If
            guardarEstatusDetalle(idDetalleOt, confirmado, estatusDetalle)
        Next

        If renglonConfirmado = grdTotalPares.Rows.Count Then
            estatusOT = "C"
        Else
            estatusOT = "PC"
        End If
        confirmadoTotal = lblTotalConfirmados.Text
        correctoTotal = lblTotalCorrectos.Text
        externoTotal = lblTotalExternos.Text
        guardarEstatusOT(idOtCoppel, estatusOT, confirmadoTotal, correctoTotal, externoTotal)

    End Sub


    ''valida que el atado leido este disponible para confirmar
    Public Function validaAtado(ByVal NumeroAtado As String)
        Dim objBu As New Negocios.OTCoppelBU
        Dim validacionAtado As Integer
        Dim tablaValidacion As DataTable
        tablaValidacion = objBu.validaAtadoOTCoppel(NumeroAtado)
        For Each row As DataRow In tablaValidacion.Rows
            validacionAtado = Integer.Parse(row.Item("validacionAtado"))
        Next
        Return validacionAtado
    End Function


End Class
