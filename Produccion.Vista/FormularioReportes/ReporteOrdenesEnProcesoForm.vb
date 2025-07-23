Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid
Imports DevExpress.Export
Imports System.Text.RegularExpressions
Imports Almacen.Vista
Imports System.Data.DataSet

Public Class ReporteOrdenesEnProcesoForm
    Public dtReporte As DataTable

    Private Sub ReporteOrdenesEnProcesoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        WindowState = FormWindowState.Maximized
        Me.Left = 0
        Me.Top = 0
        grdReporte.DataSource = dtReporte
        estiloGridReporte()
        CalcularTotales()
        Me.Cursor = Cursors.Default
        'hola
        ' Dim dt = dtReporte.AsEnumerable.Select(Function(x) x.Item("Lote")).Distinct()

    End Sub


    ' Calcular los totatles del grid
    Private Sub CalcularTotales()
        Dim NumeroLotes As String = "0"
        Dim LotesProceso As String = "0"
        Dim LotesTernminados As String = "0"
        Dim ParesStock As String = "0"
        Dim NumeroPares As String = "0"

        'Obtiene los lotes distintos del datatable 
        Dim dtNumeroLotes = dtReporte.AsEnumerable.Select(Function(x) x.Item("Lote")).Distinct()


        'Obtiene los lotes en proceso
        'Select del datatable con las columnas de lote y fecha salida (no hace el distinct correctamente)
        Dim dtLotesProceso = (From fila In dtReporte.AsEnumerable
                              Select New With {
                                    .Lote = fila.Field(Of Int32)("Lote"),
                                    .FEchaSalida = fila.Item("Fecha_Salida")
                                  }).Distinct.ToList()


        LotesProceso = dtLotesProceso.AsEnumerable.Where(Function(y) IsDBNull(y.FEchaSalida) = True).Select(Function(x) x.Lote).Distinct.Count.ToString
        '----------------------------------

        'Obtiene los lotes terminados
        LotesTernminados = dtLotesProceso.AsEnumerable.Where(Function(y) IsDBNull(y.FEchaSalida) = False).Select(Function(x) x.Lote).Distinct.Count.ToString

        ParesStock = dtReporte.AsEnumerable.Sum(Function(x) x.Item("ParesStock"))
        NumeroPares = dtReporte.AsEnumerable.Sum(Function(x) x.Item("No_Pares"))
        NumeroLotes = dtNumeroLotes.Count().ToString()

        lblLotesProceso.Text = CDbl(LotesProceso).ToString("N0")
        lblLotesTerminados.Text = CDbl(LotesTernminados).ToString("N0")
        lblParesStock.Text = CDbl(ParesStock).ToString("N0")
        lblParesCliente.Text = CDbl(NumeroPares).ToString("N0")
        lblTotaldeLotes.Text = CDbl(NumeroLotes).ToString("N0")


    End Sub



    Private Sub estiloGridReporte()
        'acomoda las columnas del ancho automaticamente
        gridVReporte.BestFitColumns()

        'Esconde idColumnas
        'gridVReporte.Columns("Nave1").Visible = True
        'gridVReporte.Columns("Nave2").Visible = False
        'gridVReporte.Columns("Nombre1").Visible = False
        'gridVReporte.Columns("IdTalla").Visible = False
        'gridVReporte.Columns("IdLinea").Visible = False
        'gridVReporte.Columns("IdCadena").Visible = False
        'gridVReporte.Columns("Proceso").Visible = False
        'gridVReporte.Columns("IdAlmacen").Visible = False
        'gridVReporte.Columns("IdAgente").Visible = False
        'gridVReporte.Columns("Almacen").Visible = False
        'gridVReporte.Columns("IdCombinacion").Visible = False
        'gridVReporte.Columns("Column1").Visible = False
        'gridVReporte.Columns("IdPedido").Visible = False

        gridVReporte.Columns("IdPedido").Visible = False
        gridVReporte.Columns("Nave").Visible = False
        gridVReporte.Columns("IdLinea").Visible = False
        gridVReporte.Columns("IdCadena").Visible = False
        gridVReporte.Columns("Proceso").Visible = False
        gridVReporte.Columns("IdAlmacen").Visible = False
        gridVReporte.Columns("IdAgente").Visible = False
        gridVReporte.Columns("Almacen").Visible = False
        gridVReporte.Columns("IdCombinacion").Visible = False
        gridVReporte.Columns("IdTalla").Visible = False
        gridVReporte.Columns("IdCombinacion").Visible = False
        gridVReporte.Columns("Agente").Visible = False
        gridVReporte.Columns("FechaActual").Visible = False
        gridVReporte.Columns("Sem(FechaActual)").Visible = False
        gridVReporte.Columns("Estatus").Visible = False


        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        'gridVReporte.Columns("IdModelo").OptionsColumn.AllowEdit = False 
        'gridVReporte.Columns("Lote").OptionsColumn.AllowEdit = False 
        'gridVReporte.Columns("Color").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Fecha").OptionsColumn.AllowEdit = False 
        'gridVReporte.Columns("PedidoSicy").OptionsColumn.AllowEdit = False 
        'gridVReporte.Columns("ParesStock").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("No_Pares").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Nave").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Marca").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Coleccion").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("nombre").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Talla").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Fecha_Salida").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("Orden").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("FechaEntrega").OptionsColumn.AllowEdit = False
        'gridVReporte.Columns("FechaEntraAlmacen").OptionsColumn.AllowEdit = False

        gridVReporte.Columns("NomNave").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("IdNave").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Lote").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("IdModelo").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("IdModeloSICY").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Talla").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Color").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Marca").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("ID").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Coleccion").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("PedidoSicy").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("PedidoSAY").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Cliente").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Fecha").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Sem(Fecha)").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("ParesStock").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("No_Pares").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Fecha_Salida").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Orden").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("FechaEntrega").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Sem(FechaEntrega)").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Estatus").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("FechaEndradaAlmacen").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Sem(FechaEndradaAlmacen)").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("FechaSolicitaCliente").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Sem(FechaSolicitaCliente)").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Sem(FechaCaptura)").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Horma").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Prioridades").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("FechaVigencia").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("Suela").OptionsColumn.AllowEdit = False
        gridVReporte.Columns("ProveedorSuela").OptionsColumn.AllowEdit = False


        'acomoda el nombre de la columna centrado
        'gridVReporte.Columns("IdModelo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Lote").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Color").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Fecha").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Lote").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("PedidoSicy").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("ParesStock").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("No_Pares").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Nave").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Coleccion").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("nombre").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Talla").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Fecha_Salida").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("Orden").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("FechaEntrega").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        'gridVReporte.Columns("FechaEntraAlmacen").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center


        gridVReporte.Columns("NomNave").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("IdNave").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Lote").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("IdModelo").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("IdModeloSICY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Talla").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Color").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Marca").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Coleccion").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("PedidoSicy").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("PedidoSAY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Cliente").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Fecha").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("ParesStock").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("No_Pares").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Fecha_Salida").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Orden").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("FechaEntrega").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Estatus").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("Horma").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("FechaEndradaAlmacen").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        gridVReporte.Columns("FechaSolicitaCliente").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        'Para que haga la busqueda por lo que contiene
        'gridVReporte.Columns("IdModelo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Lote").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Color").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Fecha").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("PedidoSicy").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("ParesStock").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("No_Pares").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Nave").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Coleccion").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("nombre").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Talla").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Fecha_Salida").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("Orden").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("FechaEntrega").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        'gridVReporte.Columns("FechaEntraAlmacen").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        gridVReporte.Columns("NomNave").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("IdNave").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Lote").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("IdModelo").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("IdModeloSICY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Talla").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Color").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Marca").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Coleccion").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("PedidoSicy").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("PedidoSAY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Cliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Fecha").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("ParesStock").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("No_Pares").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Fecha_Salida").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Orden").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("FechaEntrega").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Estatus").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("FechaEndradaAlmacen").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("FechaSolicitaCliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        gridVReporte.Columns("Horma").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains

        'Asigna nombre a la Columna
        'gridVReporte.Columns("nombre").Caption = "Cliente"
        'gridVReporte.Columns("Fecha_Salida").Caption = "F. Salida"
        'gridVReporte.Columns("Fecha").Caption = "F. Entrada"
        'gridVReporte.Columns("No_Pares").Caption = "# Pares"
        'gridVReporte.Columns("FechaEntrega").Caption = "F. Entrega Cte"
        'gridVReporte.Columns("Orden").Caption = "Orden de Compra"
        'gridVReporte.Columns("FechaEntraAlmacen").Caption = "F. Entrada Almacen"
        'gridVReporte.Columns("NomNave").Caption = "Nave"
        'gridVReporte.Columns("IdNave").Caption = "# Nave"

        gridVReporte.Columns("NomNave").Caption = "Nave"
        gridVReporte.Columns("IdNave").Caption = "#Nave"
        gridVReporte.Columns("Fecha_Salida").Caption = "F. Salida"
        gridVReporte.Columns("Fecha").Caption = "F. Entrada"
        gridVReporte.Columns("Sem(Fecha)").Caption = "Sem(F.Entrada)"
        gridVReporte.Columns("ID").Caption = "P.E. ID"
        gridVReporte.Columns("No_Pares").Caption = "# Pares"
        gridVReporte.Columns("FechaEntrega").Caption = "Fecha Entrega Cte"
        gridVReporte.Columns("Sem(FechaEntrega)").Caption = "Sem(F.Entrega Cte)"
        gridVReporte.Columns("Orden").Caption = "Orden de Compra"
        gridVReporte.Columns("FechaEndradaAlmacen").Caption = "F.Entrada Almacen"
        gridVReporte.Columns("Sem(FechaEndradaAlmacen)").Caption = "Sem(F.Entrada Almacen)"
        gridVReporte.Columns("FechaSolicitaCliente").Caption = "F.Solicita Cliente"
        gridVReporte.Columns("Sem(FechaSolicitaCliente)").Caption = "Sem(F.Solicita Cliente)"
        gridVReporte.Columns("Sem(FechaCaptura)").Caption = "Sem(F.Captura)"

        gridVReporte.Columns("ParesStock").DisplayFormat.FormatString = "N0"
        gridVReporte.Columns("No_Pares").DisplayFormat.FormatString = "N0"

        'Realiza la suma, conteo del registro por columna--------------------------------------------------------------------
        gridVReporte.OptionsView.ShowFooter = GroupFooterShowMode.VisibleIfExpanded
        gridVReporte.Columns("ParesStock").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesStock", "{0:N0}")
        gridVReporte.Columns("No_Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "No_Pares", "{0:N0}")
        gridVReporte.Columns("Lote").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Lote", " {0}")


        'gridVReporte.Columns("Fecha").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Fecha", " {0}")
        'gridVReporte.Columns("Fecha_Salida").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "Fecha_Salida", " {0}")
        

        'Agrupamiento por columna
        gridVReporte.OptionsView.AllowCellMerge = True

        ''Pone el color de fondo salteado de color blacno y azul
        'For i As Integer = 1 To gridVReporte.RowCount - 1
        '    If i Mod 2 = 0 Then
        '        'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
        '        gridVReporte.Appearance.EvenRow.BackColor = Color.LightSteelBlue
        '        gridVReporte.OptionsView.EnableAppearanceOddRow = True
        '        grdReporte.Invalidate()
        '    End If
        'Next

       

    End Sub


    Private Sub gridVReporte_CellMerge(ByVal sender As Object, ByVal e As CellMergeEventArgs) Handles gridVReporte.CellMerge
        Dim view1 As GridView = sender
        e.Handled = True
        'sirve para hacer las divbisiones tomando en cuenta una columna (+1) en este caso toma a la columna de Lote como referencia
        'para todas las demás columnas



        If e.Column.FieldName = ("NomNave") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) + 1).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("Lote") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column)).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("IdModelo") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 1).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("Talla") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 2).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("Color") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 3).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("Marca") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 4).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("Coleccion") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 5).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("PedidoSicy") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 6).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("PedidoSAY") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 7).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("nombre") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 8).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        'If e.Column.FieldName = ("Fecha") Then
        '    Dim view = sender
        '    Dim previousCol As Object

        '    previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 8).FieldName
        '    'get the previous column
        '    If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
        '        e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
        '        e.Handled = True
        '    End If
        'End If

        If e.Column.FieldName = ("Suela") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 9).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("ProveedorSuela") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 10).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

    End Sub

    'Private Sub calcularTotales()
    '    Dim totalLotesProceso As Integer = 0
    '    Dim totalLotesTerminados As Integer = 0
    '    Dim totalLotes As Integer = 0
    '    Dim paresStock As Integer = 0
    '    Dim paresClientes As Integer = 0

    '    For row As Integer = 1 To gridVReporte.RowCount - 1
    '        If gridVReporte.GetDataRow(row).Item("Lote").ToString <> "" Then
    '            totalLotes += 1
    '        End If
    '    Next

    '    lblTotaldeLotes.Text = totalLotes
    'End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String

        'Ask the user where to save the file to
        Dim SaveFileDialog As New SaveFileDialog()
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True
        If SaveFileDialog.ShowDialog() = DialogResult.OK Then

            'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
            gridVReporte.OptionsPrint.AutoWidth = True
            gridVReporte.OptionsPrint.EnableAppearanceEvenRow = True
            gridVReporte.OptionsPrint.PrintPreview = True
            'Set the selected file as the filename
            filename = SaveFileDialog.FileName

            Dim exportOptions = New XlsxExportOptionsEx()
            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

            'Export the file via inbuild function
            DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
            gridVReporte.ExportToXlsx(filename, exportOptions)

            'If the file exists (i.e. export worked), then open it
            If System.IO.File.Exists(filename) Then
                Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If DialogResult = Windows.Forms.DialogResult.Yes Then
                    System.Diagnostics.Process.Start(filename)
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    'Agrupamiento por lote, considera 1 registro aún si esta combinado
    Private Sub gridVReporte_CustomSummaryCalculate(ByVal sender As Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles gridVReporte.CustomSummaryCalculate
        If e.IsTotalSummary Then
            Dim listLotes As New List(Of String)
            'For Each row As DataRow In dtReporte.Rows
            '    If listLotes.Contains(row.Item("Lote").ToString) = False Then
            '        listLotes.Add(row.Item("Lote").ToString)
            '    End If
            'Next

            For row As Integer = 0 To gridVReporte.RowCount - 1


                If listLotes.Contains(gridVReporte.GetDataRow(row).Item("Lote").ToString) = False Then
                    listLotes.Add(gridVReporte.GetDataRow(row).Item("Lote").ToString)
                End If

            Next
            e.TotalValue = listLotes.Count()
            e.TotalValueReady = True
        End If

    End Sub

    Private Sub lblExportar_Click(sender As Object, e As EventArgs) Handles lblExportar.Click

    End Sub
End Class