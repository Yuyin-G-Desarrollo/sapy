Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.IO
Imports System.Xml

Public Class CancelacionPedidosForm

    Dim objBU As New Ventas.Negocios.CancelacionPedidosBU
    Dim ListaPedidoSICY As New List(Of String)
    Dim ListaPedidoSAY As New List(Of String)
    Dim TipoPerfil As Integer = 0


    Private Sub CancelacionPedidosForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarFecha()
        chkFiltroFecha.Checked = True
        chkFiltroFecha_CheckedChanged(sender, e)
        Me.WindowState = FormWindowState.Maximized
        PermisosPerfil()
    End Sub

    Private Sub PermisosPerfil()
        Dim DTInformacionUsuario As New DataTable

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_CANCELAR_PEDIDOS", "VENT_CANPED_ATENCIONCLIENTES") Then
        '    TipoPerfil = 1

        '    btnAtnClientes.Enabled = False
        '    DTInformacionUsuario.Columns.Add("IdColaborador")
        '    DTInformacionUsuario.Columns.Add(" ")
        '    DTInformacionUsuario.Columns.Add("Nombre")
        '    DTInformacionUsuario.Rows.Add(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 0, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal)

        '    grdAtnClientes.DataSource = DTInformacionUsuario
        '    grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Hidden = True
        '    grdAtnClientes.DisplayLayout.Bands(0).Columns(1).Hidden = True

        'End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 256
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub CargarFecha()
        Dim FechaActual As Date = Date.Now
        Dim DiaSemana As Integer = FechaActual.DayOfWeek
        Dim FechaInicio As Date
        Dim FechaFin As Date

        If DiaSemana >= 1 Then
            FechaInicio = FechaActual.AddDays((1 - DiaSemana))
        Else
            FechaInicio = FechaActual.AddDays(1)
        End If

        FechaFin = FechaActual.AddDays(6 - DiaSemana)

        dtpFechaInicio.Value = FechaInicio
        dtpFechaFin.Value = FechaFin
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
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

    Private Sub btnTienda_Click(sender As Object, e As EventArgs) Handles btnTienda.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 2
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

    Private Sub btnAtnClientes_Click(sender As Object, e As EventArgs) Handles btnAtnClientes.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 3

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAtnClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAtnClientes.DataSource = listado.listParametros
        With grdAtnClientes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Atn. Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnAgenteVentas.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroAgenteVentas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroAgenteVentas.DataSource = listado.listParametros
        With grdFiltroAgenteVentas
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnStatusPedido_Click(sender As Object, e As EventArgs) Handles btnStatusPedido.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 11
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatusPedido.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusPedido.DataSource = listado.listParametros
        With grdStatusPedido
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = False
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status Pedido"
        End With
    End Sub

    Private Sub grdCliente_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCliente.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
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

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

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

    Private Sub grdAtnClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAtnClientes.BeforeRowsDeleted
        If TipoPerfil = 1 Then
            e.Cancel = True
        End If
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAtnClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtnClientes.InitializeLayout
        grid_diseño(grdAtnClientes)
        grdAtnClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Atn. Clientes"
    End Sub

    Private Sub grdAtnClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAtnClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAtnClientes.DeleteSelectedRows(False)        
    End Sub

    Private Sub grdFiltroAgenteVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroAgenteVentas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub


    Private Sub grdFiltroAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroAgenteVentas.InitializeLayout
        grid_diseño(grdFiltroAgenteVentas)
        grdFiltroAgenteVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente Ventas"
    End Sub

    Private Sub grdFiltroAgenteVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroAgenteVentas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroAgenteVentas.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdPedidoSAY.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)        
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdPedidoSICY.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdStatusPedido_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdStatusPedido.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdStatusPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusPedido.InitializeLayout
        grid_diseño(grdStatusPedido)
        grdStatusPedido.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status"
    End Sub

    Private Sub grdStatusPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatusPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatusPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub grdTienda_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTienda.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_diseño(grdTienda)
        grdTienda.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda"
    End Sub

    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0        
        Dim confirmar As New Tools.ConfirmarForm
        Dim PedidoSAYIDSeleccionado As Integer = 0
        

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewPedidos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    FilasSeleccionadas += 1
                    PedidoSAYIDSeleccionado = CInt(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY"))
                End If
               
            Next

            If FilasSeleccionadas = 1 Then
                Dim PartidasForm As New CancelacionPartidasForm
                PartidasForm.MdiParent = Me.MdiParent
                PartidasForm.PedidoSAYID = PedidoSAYIDSeleccionado
                PartidasForm.CancelacionPedidosForm = Me
                PartidasForm.Show()
            ElseIf FilasSeleccionadas > 1 Then
                show_message("Advertencia", "Se debe seleccionar solo un pedido a la vez.")
            Else
                show_message("Advertencia", "No se ha seleccionado un pedido.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error la mostrar la información. Vuelva a intentar.")
        End Try


    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarPedidos()
    End Sub


    Public Sub CargarPedidos()
        Dim DTInformacion As New DataTable
        Dim FPedidoSAY As String = String.Empty
        Dim FPedidoSICY As String = String.Empty
        Dim FCliente As String = String.Empty
        Dim FTienda As String = String.Empty
        Dim FAtnClientes As String = String.Empty
        Dim FAgenteVentas As String = String.Empty
        Dim FStatusPedido As String = String.Empty
        Dim FTipoFecha As Integer = 0

        Try

            Cursor = Cursors.WaitCursor

            btnArriba_Click(Nothing, Nothing)
            FPedidoSAY = ObtenerFiltrosGrid(grdPedidoSAY)
            FPedidoSICY = ObtenerFiltrosGrid(grdPedidoSICY)
            FCliente = ObtenerFiltrosGrid(grdCliente)
            FTienda = ObtenerFiltrosGrid(grdTienda)
            FAtnClientes = ObtenerFiltrosGrid(grdAtnClientes)
            FAgenteVentas = ObtenerFiltrosGrid(grdFiltroAgenteVentas)
            FStatusPedido = ObtenerFiltrosGrid(grdStatusPedido)
            FTipoFecha = ObtenerTipoFecha()

            DTInformacion = objBU.ConsultaPedidosACancelar(FPedidoSAY, FPedidoSICY, FCliente, FTienda, FAtnClientes, FAgenteVentas, FStatusPedido, dtpFechaInicio.Value.ToShortDateString(), dtpFechaFin.Value.ToShortDateString(), chkFiltroFecha.Checked, FTipoFecha)

            grdPedidos.DataSource = DTInformacion
            DiseñoGrid()
            lblTotalSeleccionados.Text = "0"
            ViewPedidos.OptionsSelection.MultiSelect = True

            lblTotalSeleccionados.Text = CDbl(ViewPedidos.RowCount.ToString()).ToString("n0")

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al mostrar la información. intente de nuevo.")
        End Try


    End Sub

    Private Function ObtenerTipoFecha() As Integer
        Dim Tipo As Integer = 0

        If rdoCaptura.Checked = True Then
            Tipo = 1
        Else
            Tipo = 2
        End If

        Return Tipo
    End Function

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


    Private Sub DiseñoGrid()
        ViewPedidos.OptionsView.ColumnAutoWidth = False
        ViewPedidos.OptionsView.BestFitMaxRowCount = -1

        'If IsNothing(ViewPedidos.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
        '    ViewPedidos.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '    AddHandler ViewPedidos.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
        '    ViewPedidos.Columns.Item("#").VisibleIndex = 0
        'End If

        ViewPedidos.IndicatorWidth = 35
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In ViewPedidos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        ViewPedidos.OptionsView.ColumnAutoWidth = False

        'ViewPedidos.Columns.ColumnByFieldName("EstatusID").Visible = False
        ViewPedidos.Columns.ColumnByFieldName("Seleccionar").Caption = " "

        'ViewPedidos.Columns.ColumnByFieldName("#").Width = 35
        ViewPedidos.Columns.ColumnByFieldName("Seleccionar").Width = 30
        'ViewPedidos.Columns.ColumnByFieldName("Seleccionar").Width = 30
        ViewPedidos.Columns.ColumnByFieldName("PedidoSICY").Width = 55
        ViewPedidos.Columns.ColumnByFieldName("Estatus").Width = 100
        ViewPedidos.Columns.ColumnByFieldName("PedidoSICY").Caption = "P SICY"
        ViewPedidos.Columns.ColumnByFieldName("PedidoSAY").Width = 55
        ViewPedidos.Columns.ColumnByFieldName("PedidoSAY").Caption = "P SAY"
        ViewPedidos.Columns.ColumnByFieldName("Cliente").Width = 250
        ViewPedidos.Columns.ColumnByFieldName("FechaEntrega").Caption = "F Entrega"
        ViewPedidos.Columns.ColumnByFieldName("FechaPrograma").Caption = "F Programa"
        ViewPedidos.Columns.ColumnByFieldName("ParesCancelados").Caption = "Cancelados"
        ViewPedidos.Columns.ColumnByFieldName("TotalPares").Caption = "Pares"
        ViewPedidos.Columns.ColumnByFieldName("ParesProceso").Caption = "Proceso"
        ViewPedidos.Columns.ColumnByFieldName("ParesInventario").Caption = "Inv"
        ViewPedidos.Columns.ColumnByFieldName("Pendiente").Caption = "Pendiente"

        ViewPedidos.Columns.ColumnByFieldName("ParesSalidaApartado").Visible = False
        ViewPedidos.Columns.ColumnByFieldName("TotalParesApartado").Visible = False
        ViewPedidos.Columns.ColumnByFieldName("ParesSinProyectar").Visible = False
        ViewPedidos.Columns.ColumnByFieldName("ParesLotesA").Visible = False
        ViewPedidos.Columns.ColumnByFieldName("ParesConfirmadosDesasignacion").Visible = False
       

        ViewPedidos.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("Apartado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("Pendiente").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("ParesOT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("Facturado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("Entregado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("ParesInventario").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ViewPedidos.Columns.ColumnByFieldName("ParesOTDesasignacion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        ViewPedidos.Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("Apartado").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("Pendiente").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("ParesOT").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("Facturado").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("Entregado").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("ParesInventario").DisplayFormat.FormatString = "N0"
        ViewPedidos.Columns.ColumnByFieldName("ParesOTDesasignacion").DisplayFormat.FormatString = "N0"

        ViewPedidos.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        'ViewPedidos.Columns.ColumnByFieldName("#").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Facturado").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("ParesProceso").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("ParesInventario").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("ParesOTDesasignacion").OptionsColumn.AllowSize = True

        ViewPedidos.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("ParesCancelados").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Apartado").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Entregado").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Pendiente").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("FechaEntrega").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("OT").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("Facturas").OptionsColumn.AllowSize = True
        ViewPedidos.Columns.ColumnByFieldName("ParesOT").OptionsColumn.AllowSize = True


        'ViewPedidos.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Seleccionar").OptionsColumn.AllowEdit = True
        ViewPedidos.Columns.ColumnByFieldName("PedidoSICY").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("PedidoSAY").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("ParesCancelados").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Apartado").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Entregado").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Pendiente").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("FechaEntrega").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Apartados").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Facturas").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("FechaPrograma").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("NumeroLotes").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("ParesOT").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("Facturado").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("ParesProceso").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("ParesInventario").OptionsColumn.AllowEdit = False
        ViewPedidos.Columns.ColumnByFieldName("ParesOTDesasignacion").OptionsColumn.AllowEdit = False

        ViewPedidos.Columns.ColumnByFieldName("NumeroLotes").Visible = False

        ViewPedidos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(ViewPedidos.Columns("ParesOTDesasignacion").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesOTDesasignacion")) = True Then
            ViewPedidos.Columns("ParesOTDesasignacion").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesOTDesasignacion", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ParesOTDesasignacion"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item)
        End If


        If IsNothing(ViewPedidos.Columns("Facturado").Summary.FirstOrDefault(Function(x) x.FieldName = "Facturado")) = True Then
            ViewPedidos.Columns("Facturado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Facturado", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Facturado"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item)
        End If

        If IsNothing(ViewPedidos.Columns("ParesOT").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesOT")) = True Then
            ViewPedidos.Columns("ParesOT").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesOT", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ParesOT"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item)
        End If

        If IsNothing(ViewPedidos.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
            ViewPedidos.Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "TotalPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item)
        End If

        If IsNothing(ViewPedidos.Columns("ParesCancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesCancelados")) = True Then
            ViewPedidos.Columns("ParesCancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesCancelados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesCancelados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPedidos.Columns("Apartado").Summary.FirstOrDefault(Function(x) x.FieldName = "Apartado")) = True Then
            ViewPedidos.Columns("Apartado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Apartado", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Apartado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPedidos.Columns("Entregado").Summary.FirstOrDefault(Function(x) x.FieldName = "Entregado")) = True Then
            ViewPedidos.Columns("Entregado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Entregado", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Entregado"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPedidos.Columns("Pendiente").Summary.FirstOrDefault(Function(x) x.FieldName = "Pendiente")) = True Then
            ViewPedidos.Columns("Pendiente").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pendiente", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "Pendiente"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPedidos.Columns("ParesProceso").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesProceso")) = True Then
            ViewPedidos.Columns("ParesProceso").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesProceso", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesProceso"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item2)
        End If

        If IsNothing(ViewPedidos.Columns("ParesInventario").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesInventario")) = True Then
            ViewPedidos.Columns("ParesInventario").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesInventario", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesInventario"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            ViewPedidos.GroupSummary.Add(item2)
        End If


    End Sub


    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = ViewPedidos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function


    Private Sub ValidacionesGrid()
        


    End Sub

    Private Sub ViewPedidos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles ViewPedidos.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim FechaPrograma As Date
        Dim NumeroLotes As Integer = 0
        Dim FechaActual As Date
        Dim FechaNula As Date = Nothing

        Try

            Dim Facturas As String = String.Empty
            Dim OT As String = String.Empty
            Dim Apartado As String = String.Empty

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "Facturas")) = False Then
                Facturas = currentView.GetRowCellValue(e.RowHandle, "Facturas")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "OT")) = False Then
                OT = currentView.GetRowCellValue(e.RowHandle, "OT")
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, "Apartado")) = False Then
                Apartado = currentView.GetRowCellValue(e.RowHandle, "Apartado")
            End If

            If e.Column.FieldName = "Facturas" And Facturas <> String.Empty Then
                e.Appearance.ForeColor = Color.Red
            End If

            If e.Column.FieldName = "OT" And OT <> String.Empty Then
                e.Appearance.ForeColor = Color.Red
            End If

            If e.Column.FieldName = "Apartados" And Apartado <> String.Empty Then
                e.Appearance.ForeColor = Color.Red
            End If


            FechaActual = Date.Now.ToShortDateString()

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, currentView.Columns("FechaPrograma"))) = False Then
                FechaPrograma = currentView.GetRowCellValue(e.RowHandle, currentView.Columns("FechaPrograma"))
            Else
                FechaPrograma = Nothing
            End If

            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, currentView.Columns("NumeroLotes"))) = False Then
                NumeroLotes = currentView.GetRowCellValue(e.RowHandle, currentView.Columns("NumeroLotes"))
            Else
                NumeroLotes = 0
            End If


            If e.Column.FieldName = "FechaPrograma" Then
                If NumeroLotes > 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        e.Appearance.ForeColor = Color.Red
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            e.Appearance.ForeColor = Color.Red
                        End If
                    End If
                End If
            End If


            If e.Column.FieldName = "NumeroLotes" Then
                If NumeroLotes > 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub ViewPedidos_RowStyle(sender As Object, e As RowStyleEventArgs) Handles ViewPedidos.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Try
                Cursor = Cursors.WaitCursor
                Dim Facturas As String = String.Empty
                Dim OT As String = String.Empty
                Dim Apartado As String = String.Empty
                Dim TotalParesFacturados As Integer = 0
                Dim ParesCancelados As Integer = 0
                Dim TotalParesPedido As Integer = 0
                Dim ParesEntregados As Integer = 0
                Dim FechaPrograma As Date
                Dim NumeroLotes As Integer = 0
                Dim FechaNula As Date = Nothing
                Dim ParesOT As Integer = 0
                Dim ParesApartado As Integer = 0                
                Dim ParesSalidaApartado As Integer = 0
                Dim TotalParesApartado As Integer = 0
                Dim ParesProceso As Integer = 0

                Dim ParesLotesA As Integer = 0
                Dim ParesSinProyectar As Integer = 0

                Dim ParesOTDesasignacion As Integer = 0
                Dim ParesConfirmadosDesasignacion As Integer = 0

                ' Dim EstatusPedido As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("EstatusPartida"))
                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesOTDesasignacion"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesOTDesasignacion"))) = False Then
                    ParesOTDesasignacion = View.GetRowCellValue(e.RowHandle, View.Columns("ParesOTDesasignacion"))
                Else
                    ParesOTDesasignacion = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesConfirmadosDesasignacion"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesConfirmadosDesasignacion"))) = False Then
                    ParesConfirmadosDesasignacion = View.GetRowCellValue(e.RowHandle, View.Columns("ParesConfirmadosDesasignacion"))
                Else
                    ParesConfirmadosDesasignacion = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesLotesA"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesLotesA"))) = False Then
                    ParesLotesA = View.GetRowCellValue(e.RowHandle, View.Columns("ParesLotesA"))
                Else
                    ParesLotesA = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesSinProyectar"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesSinProyectar"))) = False Then
                    ParesSinProyectar = View.GetRowCellValue(e.RowHandle, View.Columns("ParesSinProyectar"))
                Else
                    ParesSinProyectar = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesProceso"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesProceso"))) = False Then
                    ParesProceso = View.GetRowCellValue(e.RowHandle, View.Columns("ParesProceso"))
                Else
                    ParesProceso = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesSalidaApartado"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesSalidaApartado"))) = False Then
                    ParesSalidaApartado = View.GetRowCellValue(e.RowHandle, View.Columns("ParesSalidaApartado"))
                Else
                    ParesSalidaApartado = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("TotalParesApartado"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("TotalParesApartado"))) = False Then
                    TotalParesApartado = View.GetRowCellValue(e.RowHandle, View.Columns("TotalParesApartado"))
                Else
                    TotalParesApartado = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesOT"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesOT"))) = False Then
                    ParesOT = View.GetRowCellValue(e.RowHandle, View.Columns("ParesOT"))
                Else
                    ParesOT = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("FechaPrograma"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("FechaPrograma"))) = False Then
                    FechaPrograma = View.GetRowCellValue(e.RowHandle, View.Columns("FechaPrograma"))
                Else
                    FechaPrograma = Nothing
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("NumeroLotes"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("NumeroLotes"))) = False Then
                    NumeroLotes = View.GetRowCellValue(e.RowHandle, View.Columns("NumeroLotes"))
                Else
                    NumeroLotes = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, "Apartado")) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("Apartado"))) = False Then                    
                    ParesApartado = View.GetRowCellValue(e.RowHandle, "Apartado")
                Else
                    ParesApartado = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Facturado"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("Facturado"))) = False Then
                    TotalParesFacturados = View.GetRowCellValue(e.RowHandle, View.Columns("Facturado"))
                Else
                    TotalParesFacturados = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("TotalPares"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("TotalPares"))) = False Then
                    TotalParesPedido = View.GetRowCellValue(e.RowHandle, View.Columns("TotalPares"))
                Else
                    TotalParesPedido = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("ParesCancelados"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("ParesCancelados"))) = False Then
                    ParesCancelados = View.GetRowCellValue(e.RowHandle, View.Columns("ParesCancelados"))
                Else
                    ParesCancelados = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Entregado"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("Entregado"))) = False Then
                    ParesEntregados = View.GetRowCellValue(e.RowHandle, View.Columns("Entregado"))
                Else
                    ParesEntregados = 0
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Facturas"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("Facturas"))) = False Then
                    Facturas = View.GetRowCellValue(e.RowHandle, View.Columns("Facturas"))
                Else
                    Facturas = String.Empty
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("OT"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("OT"))) = False Then
                    OT = View.GetRowCellValue(e.RowHandle, View.Columns("OT"))
                Else
                    OT = String.Empty
                End If

                If IsDBNull(View.GetRowCellValue(e.RowHandle, View.Columns("Apartados"))) = False And IsNothing(View.GetRowCellValue(e.RowHandle, View.Columns("Apartados"))) = False Then
                    Apartado = View.GetRowCellValue(e.RowHandle, View.Columns("Apartados"))
                Else
                    Apartado = String.Empty
                End If

                e.Appearance.BackColor = ObtenerColorFila(OT, Facturas, Apartado, TotalParesFacturados, TotalParesPedido, ParesCancelados, ParesEntregados, ParesOT, FechaPrograma, NumeroLotes, ParesApartado, TotalParesApartado, ParesSalidaApartado, ParesProceso, ParesSinProyectar, ParesLotesA, ParesOTDesasignacion, ParesConfirmadosDesasignacion)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try


        End If
    End Sub


    Private Function ObtenerColorFila(ByVal OT As String, ByVal Facturas As String, ByVal Apartado As String, ByVal TotalParesFacturados As Integer, ByVal TotalParesPedido As Integer, ByVal ParesCancelados As Integer, ByVal ParesEntregados As Integer, ByVal ParesOT As Integer, ByVal FechaPrograma As Date, ByVal NumeroLotes As Integer, ByVal ParesApartado As Integer, ByVal TotalParesApartado As Integer, ByVal ParesApartadoSalida As Integer, ByVal ParesProceso As Integer, ByVal ParesSinProyectar As Integer, ByVal ParesLotesA As Integer, ByVal ParesDesasignacionOT As Integer, ByVal ParesConfirmadosDesasigacion As Integer) As Color
        Dim TipoColor As Color = Color.Empty

        Dim FechaNula As Date = Nothing
        Dim FechaActual As Date

        FechaActual = Date.Now.ToShortDateString()

        If TotalParesPedido > 0 Then
            If TotalParesPedido - ParesCancelados = ParesEntregados Then
                TipoColor = Color.LightGray
            End If
        End If

        If OT <> String.Empty Then
            TipoColor = Color.LightGray
        End If

        If Facturas <> String.Empty Then
            If TotalParesFacturados = (TotalParesPedido - ParesCancelados) Then
                TipoColor = Color.LightGray
            End If
        End If

        If Apartado <> String.Empty Then
            If TotalParesApartado <> ParesApartadoSalida Then
                TipoColor = Color.LightGray
            End If
        End If

        If ParesProceso > 0 Then

            If ParesSinProyectar <> (ParesLotesA + ParesApartadoSalida - (ParesEntregados + ParesCancelados + ParesOT + ParesApartado)) Then
                If NumeroLotes > 0 Then
                    TipoColor = Color.LightGray
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        TipoColor = Color.LightGray
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            TipoColor = Color.LightGray
                        End If
                    End If
                End If

            End If
        Else

            If NumeroLotes > 0 Then
                TipoColor = Color.LightGray
            End If

            If FechaPrograma <> FechaNula Then
                If NumeroLotes > 0 Then
                    TipoColor = Color.LightGray
                Else
                    If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                        TipoColor = Color.LightGray
                    End If
                End If
            End If

        End If


        If TotalParesPedido - ParesCancelados = ParesEntregados Then
            TipoColor = Color.LightGray
        End If

        If TotalParesPedido <= (ParesCancelados + ParesEntregados + ParesApartado + ParesOT) Then
            TipoColor = Color.LightGray
        End If

        If ParesDesasignacionOT > 0 Then
            If ParesDesasignacionOT <> ParesConfirmadosDesasigacion Then
                TipoColor = Color.LightGray
            End If
        End If
        

        'If ParesProceso = (TotalParesPedido - ParesCancelados - ParesEntregados) And ParesProceso > 0 Then

        'Else
        '    If NumeroLotes > 0 Then
        '        TipoColor = Color.LightGray
        '    End If

        '    If FechaPrograma <> FechaNula Then
        '        If NumeroLotes > 0 Then
        '            TipoColor = Color.LightGray
        '        Else
        '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                TipoColor = Color.LightGray
        '            End If
        '        End If
        '    End If
        'End If

        'If TotalParesPedido > 0 Then
        '    If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = TotalParesPedido Then
        '        TipoColor = Color.LightGray
        '    End If
        'End If

        '-------------------------------------------------------------------------------------


        'If OT <> String.Empty Or Facturas <> String.Empty Or Apartado <> String.Empty Then

        '    If Facturas <> String.Empty Then
        '        If OT = String.Empty And Apartado = String.Empty And NumeroLotes = 0 Then
        '            If FechaPrograma <> FechaNula Then
        '                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                    TipoColor = Color.LightGray
        '                Else
        '                    If TotalParesFacturados <> ParesEntregados Then
        '                        TipoColor = Color.LightGray
        '                    End If
        '                End If
        '            Else
        '                If TotalParesFacturados <> ParesEntregados Then
        '                    TipoColor = Color.LightGray
        '                End If
        '            End If

        '        Else
        '            TipoColor = Color.LightGray
        '        End If


        '    End If

        '    If OT <> String.Empty Then
        '        TipoColor = Color.LightGray
        '    End If

        '    If Apartado <> String.Empty Then
        '        TipoColor = Color.LightGray
        '    End If

        '    'If ParesPartida > 0 Then
        '    '    If (ParesOT + ParesCancelados + ParesEntregados + ParesApartado) = ParesPartida Then
        '    '        TipoColor = Color.LightGray
        '    '    End If
        '    'End If

        '    If NumeroLotes > 0 Then
        '        TipoColor = Color.LightGray
        '    End If

        '    If FechaPrograma <> FechaNula Then
        '        If NumeroLotes > 0 Then
        '            TipoColor = Color.LightGray
        '        Else
        '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                TipoColor = Color.LightGray
        '            End If
        '        End If
        '    End If

        'Else

        '    If NumeroLotes > 0 Then
        '        TipoColor = Color.LightGray
        '    End If

        '    If FechaPrograma <> FechaNula Then
        '        If NumeroLotes > 0 Then
        '            TipoColor = Color.LightGray
        '        Else
        '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                TipoColor = Color.LightGray
        '            End If
        '        End If
        '    End If

        'End If

        Return TipoColor

    End Function

    'Private Sub ViewPedidos_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles ViewPedidos.CustomRowCellEdit
    '    If e.Column.FieldName = "Discontinued" AndAlso NeedToHideDiscontinuedCheckbox(TryCast(sender, GridView), e.RowHandle) Then
    '        'e.RepositoryItem = emptyEditor
    '    End If
    'End Sub

    'Private Function NeedToHideDiscontinuedCheckbox(view As GridView, row As Integer) As Boolean
    '    Return True
    '    ' your code here....
    'End Function

    Private Sub ViewPedidos_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ViewPedidos.ShowingEditor
        'Dim View As GridView = sender

        'Dim TipoColor As Color = Color.Empty

        'Dim FechaNula As Date = Nothing
        'Dim FechaActual As Date
        'Dim Facturas As String = String.Empty
        'Dim OT As String = String.Empty
        'Dim Apartado As String = String.Empty
        'Dim NumeroLotes As Integer = 0
        'Dim FechaPrograma As Date

        'FechaActual = Date.Now.ToShortDateString()


        'If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("OT"))) = False And IsNothing(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("OT"))) = False Then
        '    OT = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("OT"))
        'Else
        '    OT = String.Empty
        'End If

        'If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Facturas"))) = False And IsNothing(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Facturas"))) = False Then
        '    Facturas = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Facturas"))
        'Else
        '    Facturas = String.Empty
        'End If

        'If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Apartado"))) = False And IsNothing(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Apartado"))) = False Then
        '    Apartado = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("Apartado"))
        'Else
        '    Apartado = String.Empty
        'End If

        'If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("NumeroLotes"))) = False And IsNothing(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("NumeroLotes"))) = False Then
        '    NumeroLotes = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("NumeroLotes"))
        'Else
        '    NumeroLotes = 0
        'End If


        'If IsDBNull(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("FechaPrograma"))) = False And IsNothing(View.GetRowCellValue(View.FocusedRowHandle, View.Columns("FechaPrograma"))) = False Then
        '    FechaPrograma = View.GetRowCellValue(View.FocusedRowHandle, View.Columns("FechaPrograma"))
        'Else
        '    FechaPrograma = Nothing
        'End If

        'If OT <> String.Empty Or Facturas <> String.Empty Or Apartado <> String.Empty Then

        '    If Facturas <> String.Empty Then
        '        e.Cancel = True
        '    End If

        '    If OT <> String.Empty Then
        '        e.Cancel = True
        '    End If

        '    If Apartado <> String.Empty Then
        '        e.Cancel = True
        '    End If


        '    If NumeroLotes > 0 Then
        '        e.Cancel = True
        '    End If

        '    If FechaPrograma <> FechaNula Then
        '        If NumeroLotes > 0 Then
        '            e.Cancel = True
        '        Else
        '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                e.Cancel = True
        '            End If
        '        End If
        '    End If

        'Else

        '    If NumeroLotes > 0 Then
        '        e.Cancel = True
        '    End If

        '    If FechaPrograma <> FechaNula Then
        '        If NumeroLotes > 0 Then
        '            e.Cancel = True
        '        Else
        '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
        '                e.Cancel = True
        '            End If
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If ViewPedidos.GroupCount > 0 Then
                        grdPedidos.ExportToXlsx(.SelectedPath + "\Datos_CancelacionPedidos_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        grdPedidos.ExportToXlsx(.SelectedPath + "\Datos_CancelacionPedidos_" + fecha_hora + ".xlsx", exportOptions)

                    End If

                    show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_CancelacionPedidos_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_CancelacionPedidos_" + fecha_hora + ".xlsx")
                End If

            End With

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        'Dim EstatusID As Integer = ViewPedidos.GetRowCellValue(e.RowHandle, "EstatusPartida")
        Dim Facturas As String = String.Empty
        Dim OT As String = String.Empty
        Dim Apartado As String = String.Empty
        Dim FechaPrograma As Date
        Dim NumeroLotes As Integer = 0
        Dim FechaActual As Date
        Dim FechaNula As Date = Nothing
        Dim TotalParesFacturados As Integer = 0
        Dim ParesEntregados As Integer = 0
        Dim TotalParesPedido As Integer = 0
        Dim ParesCancelados As Integer = 0

        Dim ParesSalidaApartado As Integer = 0
        Dim TotalParesApartado As Integer = 0
        Dim ParesProceso As Integer = 0
        Dim ParesOT As Integer = 0
        Dim ParesLotesA As Integer = 0
        Dim ParesSinProyectar As Integer = 0
        Dim CantidadApartados As String = String.Empty


        Dim ParesOTDesasignacion As Integer = 0
        Dim ParesConfirmadosDesasignacion As Integer = 0

        Try

            FechaActual = Date.Now.ToShortDateString()

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesOTDesasignacion"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesOTDesasignacion"))) = False Then
                ParesOTDesasignacion = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesOTDesasignacion"))
            Else
                ParesOTDesasignacion = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesConfirmadosDesasignacion"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesConfirmadosDesasignacion"))) = False Then
                ParesConfirmadosDesasignacion = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesConfirmadosDesasignacion"))
            Else
                ParesConfirmadosDesasignacion = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Apartados"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Apartados"))) = False Then
                CantidadApartados = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Apartados"))
            Else
                CantidadApartados = String.Empty
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesLotesA"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesLotesA"))) = False Then
                ParesLotesA = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesLotesA"))
            Else
                ParesLotesA = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesSinProyectar"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesSinProyectar"))) = False Then
                ParesSinProyectar = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesSinProyectar"))
            Else
                ParesSinProyectar = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesProceso"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesProceso"))) = False Then
                ParesProceso = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesProceso"))
            Else
                ParesProceso = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesSalidaApartado"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesSalidaApartado"))) = False Then
                ParesSalidaApartado = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesSalidaApartado"))
            Else
                ParesSalidaApartado = 0
            End If
         
            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("TotalParesApartado"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("TotalParesApartado"))) = False Then
                TotalParesApartado = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("TotalParesApartado"))
            Else
                TotalParesApartado = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesOT"))) = False And IsNothing(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesOT"))) = False Then
                ParesOT = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesOT"))
            Else
                ParesOT = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("TotalPares"))) = False Then
                TotalParesPedido = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("TotalPares"))
            Else
                TotalParesPedido = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesCancelados"))) = False Then
                ParesCancelados = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("ParesCancelados"))
            Else
                ParesCancelados = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("FechaPrograma"))) = False Then
                FechaPrograma = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("FechaPrograma"))
            Else
                FechaPrograma = Nothing
            End If


            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Facturado"))) = False Then
                TotalParesFacturados = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Facturado"))
            Else
                TotalParesFacturados = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Entregado"))) = False Then
                ParesEntregados = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("Entregado"))
            Else
                ParesEntregados = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("NumeroLotes"))) = False Then
                NumeroLotes = ViewPedidos.GetRowCellValue(e.RowHandle, ViewPedidos.Columns("NumeroLotes"))
            Else
                NumeroLotes = 0
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, "Facturas")) = False Then
                Facturas = ViewPedidos.GetRowCellValue(e.RowHandle, "Facturas")
            Else
                Facturas = String.Empty
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, "OT")) = False Then
                OT = ViewPedidos.GetRowCellValue(e.RowHandle, "OT")
            Else
                OT = String.Empty
            End If

            If IsDBNull(ViewPedidos.GetRowCellValue(e.RowHandle, "Apartado")) = False Then
                Apartado = ViewPedidos.GetRowCellValue(e.RowHandle, "Apartado")
            Else
                Apartado = 0
            End If

            If TotalParesPedido > 0 Then
                If TotalParesPedido - ParesCancelados = ParesEntregados Then
                    e.Formatting.BackColor = Color.LightGray
                End If
            End If

            If OT <> String.Empty Then
                e.Formatting.BackColor = Color.LightGray
            End If

            If Facturas <> String.Empty Then
                If TotalParesFacturados = (TotalParesPedido - ParesCancelados) Then
                    e.Formatting.BackColor = Color.LightGray
                End If
            End If

            If CantidadApartados <> String.Empty Then
                If TotalParesApartado <> ParesSalidaApartado Then
                    e.Formatting.BackColor = Color.LightGray
                End If
            End If

            If ParesProceso > 0 Then

                If ParesSinProyectar <> (ParesLotesA + ParesSalidaApartado - (ParesEntregados + ParesCancelados + ParesOT + Apartado)) Then
                    If NumeroLotes > 0 Then
                        e.Formatting.BackColor = Color.LightGray
                    End If

                    If FechaPrograma <> FechaNula Then
                        If NumeroLotes > 0 Then
                            e.Formatting.BackColor = Color.LightGray
                        Else
                            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                                e.Formatting.BackColor = Color.LightGray
                            End If
                        End If
                    End If

                End If
            Else

                If NumeroLotes > 0 Then
                    e.Formatting.BackColor = Color.LightGray
                End If

                If FechaPrograma <> FechaNula Then
                    If NumeroLotes > 0 Then
                        e.Formatting.BackColor = Color.LightGray
                    Else
                        If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                            e.Formatting.BackColor = Color.LightGray
                        End If
                    End If
                End If

            End If


            If TotalParesPedido - ParesCancelados = ParesEntregados Then
                e.Formatting.BackColor = Color.LightGray
            End If

            If TotalParesPedido <= (ParesCancelados + ParesEntregados + Apartado + ParesOT) Then
                e.Formatting.BackColor = Color.LightGray
            End If

            If ParesOTDesasignacion > 0 Then
                If ParesOTDesasignacion <> ParesConfirmadosDesasignacion Then
                    e.Formatting.BackColor = Color.LightGray
                End If
            End If
            

            'If ParesProceso = (TotalParesPedido - ParesCancelados - ParesEntregados) And ParesProceso > 0 Then

            'Else
            '    If NumeroLotes > 0 Then
            '        e.Formatting.BackColor = Color.LightGray
            '    End If

            '    If FechaPrograma <> FechaNula Then
            '        If NumeroLotes > 0 Then
            '            e.Formatting.BackColor = Color.LightGray
            '        Else
            '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '                e.Formatting.BackColor = Color.LightGray
            '            End If
            '        End If
            '    End If

            'End If

            'If TotalParesPedido > 0 Then
            '    If (ParesOT + ParesCancelados + ParesEntregados + TotalParesApartado) = TotalParesPedido Then
            '        e.Formatting.BackColor = Color.LightGray
            '    End If
            'End If
            '--------------------------------------------------------------------

            'If EstatusID = 14 Or EstatusID = 15 Then
            '    e.Formatting.BackColor = Color.LightGray
            'End If

            'If TotalParesPedido > 0 Then
            '    If TotalParesPedido - ParesCancelados = ParesEntregados Then
            '        e.Formatting.BackColor = Color.LightGray
            '    End If
            'End If

            'If OT <> String.Empty Or Apartado <> String.Empty Or NumeroLotes > 0 Then
            '    e.Formatting.BackColor = Color.LightGray
            'End If


            'If Facturas <> String.Empty Then
            '    If OT = String.Empty And Apartado = String.Empty And NumeroLotes = 0 Then
            '        If FechaPrograma <> FechaNula Then
            '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '                e.Formatting.BackColor = Color.LightGray
            '            Else
            '                If TotalParesFacturados <> ParesEntregados Then
            '                    e.Formatting.BackColor = Color.LightGray
            '                End If
            '            End If
            '        Else
            '            If TotalParesFacturados <> ParesEntregados Then
            '                e.Formatting.BackColor = Color.LightGray
            '            End If
            '        End If

            '    Else
            '        e.Formatting.BackColor = Color.LightGray
            '    End If
            'End If

            'If FechaNula <> FechaPrograma Then
            '    If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
            '        e.Formatting.BackColor = Color.LightGray
            '    End If
            'End If


            'If e.ColumnFieldName = "Facturas" Then
            '    If Facturas <> String.Empty Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If

            'If e.ColumnFieldName = "OT" Then
            '    If OT <> String.Empty Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If

            'If e.ColumnFieldName = "Apartados" Then
            '    If Apartado <> String.Empty Then
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If


            'If e.ColumnFieldName = "FechaPrograma" Then
            '    If NumeroLotes > 0 Then
            '        e.Formatting.Font.Color = Color.Red                    
            '    End If

            '    If FechaPrograma <> FechaNula Then
            '        If NumeroLotes > 0 Then
            '            e.Formatting.Font.Color = Color.Red                        
            '        Else
            '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then                            
            '                e.Formatting.Font.Color = Color.Red
            '            End If
            '        End If
            '    End If
            'End If

            'If e.ColumnFieldName = "NumeroLotes" Then
            '    If NumeroLotes > 0 Then                    
            '        e.Formatting.Font.Color = Color.Red
            '    End If
            'End If



        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPedidoSAY.DataSource = Nothing
        grdPedidoSICY.DataSource = Nothing
        grdCliente.DataSource = Nothing
        grdTienda.DataSource = Nothing
        grdAtnClientes.DataSource = Nothing
        grdFiltroAgenteVentas.DataSource = Nothing
        grdStatusPedido.DataSource = Nothing
        grdPedidos.DataSource = Nothing
        ListaPedidoSAY.Clear()
        ListaPedidoSICY.Clear()
        CargarFecha()
        lblTotalSeleccionados.Text = "0"
    End Sub

    Private Sub btnPedidoCompleto_Click(sender As Object, e As EventArgs) Handles btnPedidoCompleto.Click
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim confirmar As New Tools.ConfirmarForm
        Dim PedidosSAYSeleccionados As String = String.Empty
        Dim OTs As String = String.Empty
        Dim ApartadosPendientes As String = String.Empty
        Dim PedidosNoCancelar As Integer = 0
        Dim confirmacion As New Tools.ConfirmarForm
        Dim TotalParesFacturados As Integer = 0
        Dim ParesEntregados As Integer = 0
        Dim FechaPrograma As Date
        Dim FechaNula As Date = Nothing
        Dim NumeroLotes As Integer = 0
        Dim facturas As String = String.Empty
        Dim FechaActual As Date
        Dim PedNoCancelar As Boolean = False
        Dim TotalParesPedido As Integer = 0
        Dim TotalParesCancelados As Integer = 0
        Dim ParesSalidaApartado As Integer = 0
        Dim TotalParesApartado As Integer = 0
        Dim ParesProceso As Integer = 0
        Dim ParesOT As Integer = 0
        Dim ApartadosActivos As String = String.Empty
        Dim ParesLotesA As Integer = 0
        Dim ParesSinProyectar As Integer = 0
        Dim ParesOTDesasignacion As Integer = 0
        Dim ParesConfirmadosDesasignacion As Integer = 0

        Try

            Cursor = Cursors.WaitCursor
            FechaActual = Date.Now.ToShortDateString()
            NumeroFilas = ViewPedidos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                PedNoCancelar = False
                If CBool(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    FilasSeleccionadas += 1
                    ' OTs = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "OT").ToString()
                    'ApartadosPendientes = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartado").ToString()

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesOTDesasignacion")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesOTDesasignacion")) = False Then
                        ParesOTDesasignacion = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesOTDesasignacion")
                    Else
                        ParesOTDesasignacion = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesConfirmadosDesasignacion")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesConfirmadosDesasignacion")) = False Then
                        ParesConfirmadosDesasignacion = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesConfirmadosDesasignacion")
                    Else
                        ParesConfirmadosDesasignacion = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesLotesA")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesLotesA")) = False Then
                        ParesLotesA = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesLotesA")
                    Else
                        ParesLotesA = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesSinProyectar")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesSinProyectar")) = False Then
                        ParesSinProyectar = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesSinProyectar")
                    Else
                        ParesSinProyectar = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "OT")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "OT")) = False Then
                        OTs = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "OT")
                    Else
                        OTs = String.Empty
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartado")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartado")) = False Then
                        ApartadosPendientes = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartado")
                    Else
                        ApartadosPendientes = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartados")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartados")) = False Then
                        ApartadosActivos = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Apartados")
                    Else
                        ApartadosActivos = String.Empty
                    End If


                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesProceso")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesProceso")) = False Then
                        ParesProceso = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesProceso")
                    Else
                        ParesProceso = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesSalidaApartado")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesSalidaApartado")) = False Then
                        ParesSalidaApartado = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesSalidaApartado")
                    Else
                        ParesSalidaApartado = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "TotalParesApartado")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "TotalParesApartado")) = False Then
                        TotalParesApartado = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "TotalParesApartado")
                    Else
                        TotalParesApartado = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesOT")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesOT")) = False Then
                        ParesOT = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesOT")
                    Else
                        ParesOT = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "TotalPares")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "TotalPares")) = False Then
                        TotalParesPedido = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "TotalPares")
                    Else
                        TotalParesPedido = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesCancelados")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesCancelados")) = False Then
                        TotalParesCancelados = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "ParesCancelados")
                    Else
                        TotalParesCancelados = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Facturado")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Facturado")) = False Then
                        TotalParesFacturados = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Facturado")
                    Else
                        TotalParesFacturados = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Entregado")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Entregado")) = False Then
                        ParesEntregados = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Entregado")
                    Else
                        ParesEntregados = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "FechaPrograma")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "FechaPrograma")) = False Then
                        FechaPrograma = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "FechaPrograma")
                    Else
                        FechaPrograma = Nothing
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "NumeroLotes")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "NumeroLotes")) = False Then
                        NumeroLotes = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "NumeroLotes")
                    Else
                        NumeroLotes = 0
                    End If

                    If IsDBNull(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Facturas")) = False And IsNothing(ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Facturas")) = False Then
                        facturas = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Facturas")
                    Else
                        facturas = String.Empty
                    End If


                    If TotalParesPedido > 0 Then
                        If (TotalParesPedido - TotalParesCancelados) = ParesEntregados Then
                            PedNoCancelar = True
                        End If
                    End If

                    If OTs <> String.Empty Then
                        PedNoCancelar = True
                    End If

                    If facturas <> String.Empty Then
                        If TotalParesFacturados = (TotalParesPedido - TotalParesCancelados) Then
                            PedNoCancelar = True
                        End If
                    End If

                    If ApartadosActivos <> String.Empty Then
                        If TotalParesApartado <> ParesSalidaApartado Then
                            PedNoCancelar = True
                        End If
                    End If

                    If ParesProceso > 0 Then

                        If ParesSinProyectar <> (ParesLotesA + ParesSalidaApartado - (ParesEntregados + TotalParesCancelados + ParesOT + ApartadosPendientes)) Then
                            If NumeroLotes > 0 Then
                                PedNoCancelar = True
                            End If

                            If FechaPrograma <> FechaNula Then
                                If NumeroLotes > 0 Then
                                    PedNoCancelar = True
                                Else
                                    If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                                        PedNoCancelar = True
                                    End If
                                End If
                            End If

                        End If
                    Else

                        If NumeroLotes > 0 Then
                            PedNoCancelar = True
                        End If

                        If FechaPrograma <> FechaNula Then
                            If NumeroLotes > 0 Then
                                PedNoCancelar = True
                            Else
                                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                                    PedNoCancelar = True
                                End If
                            End If
                        End If

                    End If


                    If TotalParesPedido - TotalParesCancelados = ParesEntregados Then
                        PedNoCancelar = True
                    End If

                    If TotalParesPedido <= (TotalParesCancelados + ParesEntregados + ApartadosPendientes + ParesOT) Then
                        PedNoCancelar = True
                    End If

                    If ParesOTDesasignacion > 0 Then
                        If ParesOTDesasignacion <> ParesConfirmadosDesasignacion Then
                            PedNoCancelar = True
                        End If
                    End If

                    'If ParesProceso = (TotalParesPedido - TotalParesCancelados - ParesEntregados) And ParesProceso > 0 Then

                    'Else
                    '    If NumeroLotes > 0 Then
                    '        PedNoCancelar = True
                    '    End If

                    '    If FechaPrograma <> FechaNula Then
                    '        If NumeroLotes > 0 Then
                    '            PedNoCancelar = True
                    '        Else
                    '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                    '                PedNoCancelar = True
                    '            End If
                    '        End If
                    '    End If
                    'End If

                    If TotalParesPedido > 0 Then
                        If (ParesOT + TotalParesCancelados + ParesEntregados + ApartadosPendientes) = TotalParesPedido Then
                            PedNoCancelar = True
                        End If
                    End If

                    If PedNoCancelar = True Then
                        PedidosNoCancelar += 1
                    Else
                        If PedidosSAYSeleccionados = String.Empty Then
                            PedidosSAYSeleccionados = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                        Else
                            PedidosSAYSeleccionados &= "," & ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                        End If
                    End If

                    'If TotalParesPedido > 0 Then
                    '    If (TotalParesPedido - TotalParesCancelados) = ParesEntregados Then
                    '        PedNoCancelar = True
                    '    End If
                    'End If



                    'If OTs <> String.Empty Or facturas <> String.Empty Or ApartadosPendientes <> String.Empty Then

                    '    If facturas <> String.Empty Then
                    '        If OTs = String.Empty And ApartadosPendientes = String.Empty And NumeroLotes = 0 Then
                    '            If FechaPrograma <> FechaNula Then
                    '                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                    '                    PedNoCancelar = True
                    '                Else
                    '                    If TotalParesFacturados <> ParesEntregados Then
                    '                        PedNoCancelar = True
                    '                    End If
                    '                End If
                    '            Else
                    '                If TotalParesFacturados <> ParesEntregados Then
                    '                    PedNoCancelar = True
                    '                End If
                    '            End If

                    '        Else
                    '            PedNoCancelar = True
                    '        End If
                    '    End If

                    '    If OTs <> String.Empty Then
                    '        PedNoCancelar = True
                    '    End If

                    '    If ApartadosPendientes <> String.Empty Then
                    '        PedNoCancelar = True
                    '    End If

                    '    If NumeroLotes > 0 Then
                    '        PedNoCancelar = True
                    '    End If

                    '    If FechaPrograma <> FechaNula Then
                    '        If NumeroLotes > 0 Then
                    '            PedNoCancelar = True
                    '        Else
                    '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                    '                PedNoCancelar = True
                    '            End If
                    '        End If
                    '    End If

                    'Else
                    '    If NumeroLotes > 0 Then
                    '        PedNoCancelar = True
                    '    End If

                    '    If FechaPrograma <> FechaNula Then
                    '        If NumeroLotes > 0 Then
                    '            PedNoCancelar = True
                    '        Else
                    '            If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                    '                PedNoCancelar = True
                    '            End If
                    '        End If
                    '    End If

                    'End If


                    'If PedNoCancelar = True Then
                    '    PedidosNoCancelar += 1
                    'Else
                    '    If PedidosSAYSeleccionados = String.Empty Then
                    '        PedidosSAYSeleccionados = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                    '    Else
                    '        PedidosSAYSeleccionados &= "," & ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                    '    End If
                    'End If

                    ''If OTs = String.Empty And ApartadosPendientes = String.Empty And NumeroLotes = 0 Then
                    ''    If PedidosSAYSeleccionados = String.Empty Then
                    ''        PedidosSAYSeleccionados = ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                    ''    Else
                    ''        PedidosSAYSeleccionados &= "," & ViewPedidos.GetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "PedidoSAY").ToString()
                    ''    End If

                    ''Else
                    ''    If facturas <> String.Empty Then
                    ''        If OTs = String.Empty And ApartadosPendientes = String.Empty And NumeroLotes = 0 Then
                    ''            If FechaPrograma <> FechaNula Then
                    ''                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                    ''                    PedidosNoCancelar += 1
                    ''                Else
                    ''                    If TotalParesFacturados <> ParesEntregados Then
                    ''                        PedidosNoCancelar += 1
                    ''                    End If
                    ''                End If
                    ''            End If
                    ''        End If
                    ''    Else
                    ''        If FechaPrograma <> FechaNula Then
                    ''            If NumeroLotes > 0 Then
                    ''                PedidosNoCancelar += 1
                    ''            Else
                    ''                If FechaPrograma.ToShortDateString <= FechaActual.AddDays(7) Then
                    ''                    PedidosNoCancelar += 1
                    ''                End If
                    ''            End If
                    ''        End If

                    ''    End If

                    ''End If


                End If
            Next

            If FilasSeleccionadas > 0 Then
                If PedidosNoCancelar > 0 And (FilasSeleccionadas > PedidosNoCancelar) Then
                    confirmacion.mensaje = "Se cancelarán " + CStr(FilasSeleccionadas - PedidosNoCancelar) + " pedidos de " + FilasSeleccionadas.ToString() + " seleccionados. ¿Desea continuar?"
                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim CancelarPartidas As New MotivosCancelacionForm
                        CancelarPartidas.PedidoSAYID = PedidosSAYSeleccionados
                        CancelarPartidas.CancelarPedidoCompleto = True
                        If CancelarPartidas.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            CargarPedidos()
                        End If

                    End If
                ElseIf FilasSeleccionadas = PedidosNoCancelar Then
                    show_message("Advertencia", "No se pueden cancelar los pedidos debido a que tienen OTs activas o apartados por confirmar.")
                Else
                    Dim CancelarPartidas As New MotivosCancelacionForm
                    CancelarPartidas.PedidoSAYID = PedidosSAYSeleccionados
                    CancelarPartidas.CancelarPedidoCompleto = True
                    If CancelarPartidas.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        CargarPedidos()
                    End If
                End If

            Else
                show_message("Advertencia", "No se ha seleccionado una partida.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error la mostrar la información. Vuelva a intentar.")
        End Try
    End Sub

    Private Sub chkFiltroFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltroFecha.CheckedChanged
        dtpFechaInicio.Enabled = chkFiltroFecha.Checked
        dtpFechaFin.Enabled = chkFiltroFecha.Checked
        rdoCaptura.Enabled = chkFiltroFecha.Checked
        rdoEntrega.Enabled = chkFiltroFecha.Checked
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

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            ListaPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = ListaPedidoSAY

            txtPedidoSAY.Text = String.Empty
        End If
    End Sub

    Private Sub grdGeneralSinFeEspecial_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles ViewPedidos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1            
        End If
    End Sub


    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewPedidos.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                ViewPedidos.SetRowCellValue(ViewPedidos.GetVisibleRowHandle(index), "Seleccionar", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub
End Class