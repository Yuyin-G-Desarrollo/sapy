Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Text


Public Class PedidosMuestras_ConsultasMovimientos_Resultados
    Dim listInicial As New List(Of String)
    Dim listPiezas As New List(Of Integer)
    Dim listPedidos As New List(Of Integer)

#Region "Boton Mostrar Mas"
    Private Sub btnTallas_Click(sender As Object, e As EventArgs) Handles btnTallas.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "TALLAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridTallas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridTallas.DataSource = listado.listParametros
        With gridTallas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Tallas"
        End With
    End Sub
    Private Sub btnCorridas_Click(sender As Object, e As EventArgs) Handles btnCorridas.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "CORRIDAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridCorridas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridCorridas.DataSource = listado.listParametros
        With gridCorridas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Corridas"
        End With
    End Sub
    Private Sub bntArticulos_Click(sender As Object, e As EventArgs) Handles bntArticulos.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "ARTICULOS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridArticulos.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridArticulos.DataSource = listado.listParametros
        With gridArticulos
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True

            '.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Articulos"
        End With
    End Sub
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "CLIENTES"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridClientes.Rows
            Dim parametro As String = row.Cells(1).Text
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

            .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
        End With
    End Sub
    Private Sub btnMovimientos_Click(sender As Object, e As EventArgs) Handles btnMovimientos.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "MOVIMIENTOS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridMovimientos.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridMovimientos.DataSource = listado.listParametros
        With gridMovimientos
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Movimientos"
        End With
    End Sub
#End Region
#Region "Inicializa Layout"
    Private Sub gridTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTallas.InitializeLayout
        grid_diseño(gridTallas)
        gridTallas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tallas"

    End Sub
    Private Sub gridArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridArticulos.InitializeLayout
        grid_diseño(gridArticulos)
        gridArticulos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Articulos"
    End Sub
    Private Sub gridCorridas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCorridas.InitializeLayout
        grid_diseño(gridCorridas)
        gridCorridas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corridas"
    End Sub
    Private Sub gridCodigosDePiezas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCodigosDePiezas.InitializeLayout
        grid_diseño(gridCodigosDePiezas)
        gridCodigosDePiezas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código de pieza"
    End Sub
    Private Sub gridPedidosMuestras_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPedidosMuestras.InitializeLayout
        grid_diseño(gridPedidosMuestras)
        gridPedidosMuestras.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedidos de Muestras"
    End Sub
    Private Sub gridClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridClientes.InitializeLayout
        grid_diseño(gridClientes)
        gridClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub
    Private Sub gridMovimientos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridMovimientos.InitializeLayout
        grid_diseño(gridMovimientos)
        gridMovimientos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Movimientos"
    End Sub

#End Region
#Region "Diseño Grid"
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
            .Override.AllowRowFiltering = DefaultableBoolean.True
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub
    ''Asigna formato a columnas de ultragrid
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

#End Region
#Region "Eventos Form"
    Private Sub PedidosMuestras_ConsultasMovimientos_Resultados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridClientes.DataSource = listInicial
        gridArticulos.DataSource = listInicial
        gridCorridas.DataSource = listInicial
        gridTallas.DataSource = listInicial
        gridCodigosDePiezas.DataSource = listInicial
        gridPedidosMuestras.DataSource = listInicial
        gridMovimientos.DataSource = listInicial
    End Sub
#End Region
#Region "Eventos Presionar Tecla TextBox"
    Private Sub txtCodigosPieza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigosPieza.KeyPress
        'Verdadero no escribe
        e.Handled = ValidacionesDatos.soloNumeros(sender, e)
    End Sub
    Private Sub txtCodigosPieza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigosPieza.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
            Dim dtResultado As DataTable
            dtResultado = objBU.ConsultaTablaFiltros("PIEZAS", txtCodigosPieza.Text.Trim.ToString)
            If Not IsNothing(dtResultado) Then
                If dtResultado.Rows.Count > 0 Then
                    If CInt(dtResultado.Rows(0).Item("RESULTADO")) > 0 Then
                        listPiezas.Add(CInt(txtCodigosPieza.Text.Trim))
                        gridCodigosDePiezas.DataSource = Nothing
                        gridCodigosDePiezas.DataSource = listPiezas
                        txtCodigosPieza.Clear()
                    Else
                        Controles.Mensajes_Y_Alertas("INFORMACION", "Código pieza invalido.")
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub txtPedidosMuestra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidosMuestra.KeyPress
        'Verdadero no escribe
        e.Handled = ValidacionesDatos.soloNumeros(sender, e)
    End Sub
    Private Sub txtPedidosMuestra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPedidosMuestra.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
            Dim dtResultado As DataTable
            dtResultado = objBU.ConsultaTablaFiltros("PEDIDOS", txtPedidosMuestra.Text.Trim.ToString)
            If Not IsNothing(dtResultado) Then
                If dtResultado.Rows.Count > 0 Then
                    If CInt(dtResultado.Rows(0).Item("RESULTADO")) > 0 Then
                        listPedidos.Add(CInt(txtPedidosMuestra.Text.Trim))
                        gridPedidosMuestras.DataSource = Nothing
                        gridPedidosMuestras.DataSource = listPedidos
                        txtPedidosMuestra.Clear()
                    Else
                        Controles.Mensajes_Y_Alertas("INFORMACION", "Pedido de muestra invalido.")
                    End If
                End If
            End If
        End If
    End Sub
#End Region
#Region "Eventos Presionar Tecla Grids"
    Private Sub gridClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridClientes.DeleteSelectedRows(False)
    End Sub
    Private Sub gridArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridArticulos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridArticulos.DeleteSelectedRows(False)
    End Sub

    Private Sub gridTallas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTallas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCorridas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCorridas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCorridas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCodigosDePiezas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCodigosDePiezas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCodigosDePiezas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridPedidosMuestras_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPedidosMuestras.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPedidosMuestras.DeleteSelectedRows(False)
    End Sub

    Private Sub gridMovimientos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridMovimientos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridMovimientos.DeleteSelectedRows(False)
    End Sub

#End Region


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If chkMovimiento.Checked Then
            If CDate(dtpFMovimientoDel.Value.ToShortDateString) > CDate(dtpFMovimientoAl.Value.ToShortDateString) Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                dtpFMovimientoDel.Focus()
                Exit Sub
            End If
        End If

        Dim Operador As String = String.Empty
        Dim Movimientos As String
        Dim Piezas As String
        Dim Clientes As String
        Dim PedidosM As String
        Dim Articulos As String
        Dim Corridas As String
        Dim tallas As String
        Dim strFMovimiento As String = ""
        Dim objBU As New Negocios.EnvioRecepcionMuestrasBU

        Try
            If rdbY.Checked Then
                Operador = "AND"
            ElseIf rdbO.Checked Then
                Operador = "OR"
            End If

            Movimientos = GeneraCadenaFiltro(gridMovimientos, 1)
            Piezas = GeneraCadenaFiltro(gridCodigosDePiezas, 0)
            Clientes = GeneraCadenaFiltro(gridClientes, 1)
            PedidosM = GeneraCadenaFiltro(gridPedidosMuestras, 0)
            Articulos = GeneraCadenaFiltro(gridArticulos, 1)
            Corridas = GeneraCadenaFiltro(gridCorridas, 1)
            tallas = GeneraCadenaFiltro(gridTallas, 1)


            If chkMovimiento.Checked Then
                strFMovimiento = dtpFMovimientoDel.Value.ToShortDateString + "," + dtpFMovimientoAl.Value.ToShortDateString
            End If

            Dim dtMovimientosMuestras As DataTable
            Dim EntFiltros As New Entidades.FiltrosEnvioRecepcionMuestras
            EntFiltros.Operador = Operador
            EntFiltros.Movimientos = Movimientos

            EntFiltros.DelPedidoOrigen = rdbDelPedidoOrigen.Checked
            EntFiltros.DelPedidoDelMovimiento = rdbDelPedidoDelMovimiento.Checked
            EntFiltros.Clientes = Clientes

            EntFiltros.PedidosMOrigen = rdbOrigen.Checked 'CAMBIAR RADIO BUTTON
            EntFiltros.PedidosMMovimiento = rdbMovimiento.Checked 'CAMBIAR PARAMETRO DE LA ENTIDAD Y EL RADIO BUTTON
            EntFiltros.PedidoMuestras = PedidosM

            EntFiltros.CodigosPieza = Piezas
            EntFiltros.Articulos = Articulos

            EntFiltros.Corrida = Corridas
            EntFiltros.Tallas = tallas

            EntFiltros.FechaMovimiento = strFMovimiento

            dtMovimientosMuestras = objBU.ConsultaMovimientosMuestras(EntFiltros)

            If Not IsNothing(dtMovimientosMuestras) Then
                If dtMovimientosMuestras.Rows.Count > 0 Then
                    Dim form As New PedidosMuestras_consultasMovimientosMuestras
                    form.DataConsulta = dtMovimientosMuestras
                    form.EntFiltros = EntFiltros
                    form.ShowDialog()

                Else
                    Controles.Mensajes_Y_Alertas("INFORMACION", "La consulta actual no contiene registros")
                End If
            End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try

    End Sub


    Private Function GeneraCadenaFiltro(ByVal grid As UltraGrid, ByVal index As Integer) As String
        Dim sb As New StringBuilder
        Try
            For Each row As UltraGridRow In grid.Rows
                sb.Append(row.Cells(index).Value.ToString)
                sb.Append(",")
            Next
            If sb.Length > 0 Then
                sb.Remove(sb.Length - 1, 1)
            End If
            GeneraCadenaFiltro = sb.ToString
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
            GeneraCadenaFiltro = ""
        End Try
    End Function


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridMovimientos.DataSource = Nothing
        gridClientes.DataSource = Nothing
        gridArticulos.DataSource = Nothing
        gridCorridas.DataSource = Nothing
        gridTallas.DataSource = Nothing
        gridCodigosDePiezas.DataSource = Nothing
        gridPedidosMuestras.DataSource = Nothing
        chkMovimiento.Checked = False
        dtpFMovimientoDel.Value = Date.Now
        dtpFMovimientoAl.Value = Date.Now


        gridMovimientos.DataSource = listInicial
        gridClientes.DataSource = listInicial
        gridArticulos.DataSource = listInicial
        gridCorridas.DataSource = listInicial
        gridTallas.DataSource = listInicial
        gridCodigosDePiezas.DataSource = listInicial
        gridPedidosMuestras.DataSource = listInicial

    End Sub
End Class