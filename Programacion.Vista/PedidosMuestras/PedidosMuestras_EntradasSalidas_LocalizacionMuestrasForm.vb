Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization

Public Class PedidosMuestras_EntradasSalidas_LocalizacionMuestrasForm

    Private ListaCodigosPiezas As New List(Of String)
    Private ListaPedidosMuestra As New List(Of String)
    Private ObjBU As New Programacion.Negocios.EnvioRecepcionMuestrasBU

    Private Sub btnFiltroNave_Click(sender As Object, e As EventArgs) Handles btnFiltroNave.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "NAVES_TODAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridNave.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridNave.DataSource = listado.listParametros
        With gridNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

    Private Sub btnBahia_Click(sender As Object, e As EventArgs) Handles btnBahia.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "BAHIA"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridBahia.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridBahia.DataSource = listado.listParametros
        With gridBahia
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = False
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Bahia"
        End With
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "CLIENTES"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(1).Text
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
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

    Private Sub btnOperador_Click(sender As Object, e As EventArgs) Handles btnOperador.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "OPERADOR"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridOperador.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridOperador.DataSource = listado.listParametros
        With gridOperador
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

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
            '.DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Tallas"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "CORRIDAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridCorrida.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridCorrida.DataSource = listado.listParametros
        With gridCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Corrida"
        End With
    End Sub

    Private Sub btnArticulos_Click(sender As Object, e As EventArgs) Handles btnArticulos.Click
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
            .DisplayLayout.Bands(0).Columns(2).Hidden = False
            .DisplayLayout.Bands(0).Columns(3).Hidden = False
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = False
            .DisplayLayout.Bands(0).Columns(6).Hidden = False
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            .DisplayLayout.Bands(0).Columns(8).Hidden = True
            .DisplayLayout.Bands(0).Columns(9).Hidden = False
            .DisplayLayout.Bands(0).Columns(10).Hidden = False
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoMuestra_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoMuestra.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoMuestra.DeleteSelectedRows(False)
    End Sub

    Private Sub gridArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridArticulos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridArticulos.DeleteSelectedRows(False)
    End Sub

    Private Sub gridBahia_KeyDown(sender As Object, e As KeyEventArgs) Handles gridBahia.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridBahia.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCodigosPiezas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCodigosPiezas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCodigosPiezas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub gridNave_KeyDown(sender As Object, e As KeyEventArgs) Handles gridNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridNave.DeleteSelectedRows(False)
    End Sub

    Private Sub gridOperador_KeyDown(sender As Object, e As KeyEventArgs) Handles gridOperador.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridOperador.DeleteSelectedRows(False)
    End Sub

    Private Sub gridTallas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTallas.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            If grid.Name = "gridCodigosPiezas" Or grid.Name = "grdPedidoMuestra" Or grid.Name = "gridCorrida" Or grid.Name = "gridTallas" Then
                .Override.RowAppearance.TextHAlign = HAlign.Right
            Else
                .Override.RowAppearance.TextHAlign = HAlign.Left
            End If
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

    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
    End Sub

    Private Sub grdPedidoMuestra_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoMuestra.InitializeLayout
        grid_diseño(grdPedidoMuestra)
    End Sub

    Private Sub gridArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridArticulos.InitializeLayout
        grid_diseño(gridArticulos)
    End Sub

    Private Sub gridBahia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridBahia.InitializeLayout
        grid_diseño(gridBahia)
    End Sub

    Private Sub gridCodigosPiezas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCodigosPiezas.InitializeLayout
        grid_diseño(gridCodigosPiezas)
    End Sub

    Private Sub gridCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCorrida.InitializeLayout
        grid_diseño(gridCorrida)
    End Sub

    Private Sub gridNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridNave.InitializeLayout
        grid_diseño(gridNave)
    End Sub

    Private Sub gridOperador_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridOperador.InitializeLayout
        grid_diseño(gridOperador)
    End Sub

    Private Sub gridTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTallas.InitializeLayout
        grid_diseño(gridTallas)
    End Sub

    Private Sub txtCodigoPieza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPieza.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtCodigoPieza.Text) Then Return

            ListaCodigosPiezas.Add(txtCodigoPieza.Text)
            gridCodigosPiezas.DataSource = Nothing
            gridCodigosPiezas.DataSource = ListaCodigosPiezas

            txtCodigoPieza.Text = String.Empty
            gridCodigosPiezas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Codigo Pieza"
            With gridCodigosPiezas.DisplayLayout
                .Override.RowAppearance.TextHAlign = HAlign.Right
            End With
        End If
    End Sub

    Private Sub txtPedidoMuestra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoMuestra.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoMuestra.Text) Then Return

            ListaPedidosMuestra.Add(txtPedidoMuestra.Text)
            grdPedidoMuestra.DataSource = Nothing
            grdPedidoMuestra.DataSource = ListaPedidosMuestra

            txtPedidoMuestra.Text = String.Empty
            grdPedidoMuestra.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido"
            With grdPedidoMuestra.DisplayLayout
                .Override.RowAppearance.TextHAlign = HAlign.Right
            End With

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCliente.DataSource = Nothing
        grdPedidoMuestra.DataSource = Nothing
        gridBahia.DataSource = Nothing
        gridCodigosPiezas.DataSource = Nothing
        gridCorrida.DataSource = Nothing
        gridNave.DataSource = Nothing
        gridOperador.DataSource = Nothing
        gridTallas.DataSource = Nothing
        gridArticulos.DataSource = Nothing

        rdoPedidoOrigenMuestra.Checked = True
        rdoPedidoActualMuestra.Checked = False

        rdoPedidoOrigen.Checked = True
        rdoPedioActual.Checked = False

        rdoConUbicacion.Checked = False
        rdoSinUbicacion.Checked = False
        rdoTodo.Checked = True

        rdoY.Checked = True
        rdoO.Checked = False

        chkEntregacCiente.Checked = False
        chkEntregaNave.Checked = False
        chkEnvioNave.Checked = False
        chkRecepciónComercializadora.Checked = False

        chkUbicacion.Checked = True

        dtmEntregaClienteAl.Value = Date.Now
        dtmEntregaClienteDel.Value = Date.Now
        dtmEntregaNaveAl.Value = Date.Now
        dtmEntregaNaveDel.Value = Date.Now
        dtmEnvioNaveAl.Value = Date.Now
        dtmEnvioNaveDel.Value = Date.Now
        dtmFechaUbicacionAl.Value = Date.Now
        dtmFechaUbicacionDel.Value = Date.Now
        'dtmHoraUbicacionAl.Value = Date.Now
        'dtmHoraUbicacionDel.Value=0
        dtmRecepcionComercializadoraAl.Value = Date.Now
        dtmRecepcionComercializadoraDel.Value = Date.Now

        cmbNaveAlmacen.SelectedIndex = 0
        cmbAlmacen.SelectedIndex = 0
    End Sub

    Private Sub PedidosMuestras_EntradasSalidas_LocalizacionMuestrasForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim FechaActual As Date

        cmbNaveAlmacen.Items.Add("COMERCIALIZADORA")
        cmbNaveAlmacen.Items.Add("REEDITION")
        cmbNaveAlmacen.SelectedIndex = 0
        cmbAlmacen.SelectedIndex = 0
        FechaActual = CDate(Date.Now.ToShortDateString)

        dtmHoraUbicacionDel.Value = FechaActual
        Me.Location = New Point(0, 0)
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If grid.Name = "gridCodigosPiezas" Or grid.Name = "grdPedidoMuestra" Then
                If row.Index = 0 Then
                    Resultado += " '" + Replace(row.Cells(0).Text, ",", "").Trim + "'"
                Else
                    Resultado += ", '" + Replace(row.Cells(0).Text, ",", "").Trim + "'"
                End If
            Else
                If row.Index = 0 Then
                    Resultado += " '" + Replace(row.Cells(1).Text, ",", "").Trim + "'"
                Else
                    Resultado += ", '" + Replace(row.Cells(1).Text, ",", "").Trim + "'"
                End If
            End If
        Next
        Return Resultado
    End Function

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim EntidadFiltros As New Entidades.FiltrosEnvioRecepcionMuestras
        Dim DTResultado As New DataTable
        Dim VentanaForm As New ListadoUbicacionPiezasForm

        Try
            Cursor = Cursors.WaitCursor
            If chkAsignada.Checked = False And chkDisponible.Checked = False Then
                chkAsignada.ForeColor = Color.Red
                chkDisponible.ForeColor = Color.Red
                show_message("Advertencia", "Asegurese de marcar una opción de status Disponible o Asignada")
                Cursor = Cursors.Default
                Return
            Else
                chkAsignada.ForeColor = Color.Black
                chkDisponible.ForeColor = Color.Black
            End If

            If ValidarFiltros() = True Then
                EntidadFiltros = ObtenerFiltros()
                DTResultado = ObjBU.ConsultarUbicacionPiezas(EntidadFiltros)
                VentanaForm.DtListadoUbicacionPiezas = DTResultado
                VentanaForm.EntidadFiltros = EntidadFiltros
                VentanaForm.MdiParent = Me.MdiParent
                VentanaForm.Show()
            Else
                show_message("Advertencia", "Los filtros de fecha marcados en rojo estan fuera de rango.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
            Cursor = Cursors.Default
        End Try

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

    Private Function ObtenerFiltros() As Entidades.FiltrosEnvioRecepcionMuestras
        Dim EntidadFiltros As New Entidades.FiltrosEnvioRecepcionMuestras
        Dim TipoUbicacion As Integer = 0
        Dim TipoOperacion As Integer = 0

        Try

            If rdoConUbicacion.Checked = True Then
                TipoUbicacion = 1
            ElseIf rdoSinUbicacion.Checked = True Then
                TipoUbicacion = 2
            ElseIf rdoTodo.Checked = True Then
                TipoUbicacion = 3
            End If

            If rdoY.Checked = True Then
                TipoOperacion = 1
            ElseIf rdoO.Checked = True Then
                TipoOperacion = 2
            End If

            EntidadFiltros.Clientes = ObtenerFiltrosGrid(grdCliente)
            EntidadFiltros.PedidoMuestras = ObtenerFiltrosGrid(grdPedidoMuestra)
            EntidadFiltros.BahiaID = ObtenerFiltrosGrid(gridBahia) 'true
            EntidadFiltros.CodigosPieza = ObtenerFiltrosGrid(gridCodigosPiezas)
            EntidadFiltros.Corrida = ObtenerFiltrosGrid(gridCorrida) ''11-14
            EntidadFiltros.NaveSICYID = ObtenerFiltrosGrid(gridNave) ' nombre operador
            EntidadFiltros.Operador = ObtenerFiltrosGrid(gridOperador) ' nombre operador
            EntidadFiltros.Tallas = ObtenerFiltrosGrid(gridTallas) ' 15
            EntidadFiltros.Articulos = ObtenerFiltrosGrid(gridArticulos) '11

            If cmbNaveAlmacen.SelectedIndex = 0 Then
                EntidadFiltros.NaveAlmacen = 43
            ElseIf cmbNaveAlmacen.SelectedIndex = 1 Then
                EntidadFiltros.NaveAlmacen = 82
            End If
            'EntidadFiltros.NaveAlmacen = 43 'cmbNaveAlmacen.SelectedValue
            EntidadFiltros.NumeroAlmacen = 1 'cmbAlmacen.SelectedValue
            EntidadFiltros.FiltroUbicacion = chkUbicacion.Checked

            EntidadFiltros.FechaUbicacionDel = CDate(dtmFechaUbicacionDel.Value.ToShortDateString.ToString() + " " + dtmHoraUbicacionDel.Value.ToLongTimeString.ToString)
            EntidadFiltros.HoraUbicacionDel = dtmHoraUbicacionDel.Value
            EntidadFiltros.HoraUbicacionAl = dtmHoraUbicacionAl.Value
            EntidadFiltros.FechaUbicacionAl = CDate(dtmFechaUbicacionAl.Value.ToShortDateString.ToString() + " " + dtmHoraUbicacionAl.Value.ToLongTimeString.ToString)
            EntidadFiltros.FiltroentregaNave = chkEntregaNave.Checked
            EntidadFiltros.FechaEntregaNaveDel = dtmEntregaNaveDel.Value
            EntidadFiltros.FechaEntregaNaveAl = dtmEntregaNaveAl.Value
            EntidadFiltros.FiltroEntregaCliente = chkEntregacCiente.Checked
            EntidadFiltros.FechaEntregaClienteDel = dtmEntregaClienteDel.Value
            EntidadFiltros.FechaEntregaClienteAl = dtmEntregaClienteAl.Value
            EntidadFiltros.FiltroEnvioNave = chkEnvioNave.Checked
            EntidadFiltros.FechaEnvioNaveDel = dtmEnvioNaveDel.Value
            EntidadFiltros.FechaEnvioNaveAl = dtmEnvioNaveAl.Value
            EntidadFiltros.FiltroRecepcionComercializadora = chkRecepciónComercializadora.Checked
            EntidadFiltros.FechaRecepcionComercializadoraDel = dtmRecepcionComercializadoraDel.Value
            EntidadFiltros.FechaRecepcionComercializadoraAl = dtmRecepcionComercializadoraAl.Value

            EntidadFiltros.StatusAsignada = chkAsignada.Checked
            EntidadFiltros.StatusDisponible = chkDisponible.Checked

            EntidadFiltros.TipoUbicacion = TipoUbicacion
            EntidadFiltros.TipoOperacion = TipoOperacion
            EntidadFiltros.EsClienteOrigen = rdoPedidoOrigen.Checked
            EntidadFiltros.EsPedidoOrigen = rdoPedidoOrigenMuestra.Checked

        Catch ex As Exception
            Throw ex
        End Try

        Return EntidadFiltros

    End Function

    Private Function ValidarFiltros() As Boolean
        Dim Resultado As Boolean = True

        If chkUbicacion.Checked = True Then
            If Date.Compare(CDate(dtmFechaUbicacionDel.Value.ToShortDateString), CDate(dtmFechaUbicacionAl.Value.ToShortDateString)) <> 0 Then
                'If CDate(dtmFechaUbicacionDel.Value.ToShortDateString()) > dtmFechaUbicacionAl.Value Then
                Resultado = False
                chkUbicacion.ForeColor = Color.Red
            Else
                chkUbicacion.ForeColor = Color.Black
            End If

            If Date.Compare(CDate(dtmFechaUbicacionDel.Value.ToShortDateString), CDate(dtmFechaUbicacionAl.Value.ToShortDateString)) = 0 Then
                If DateTime.Compare(dtmHoraUbicacionDel.Value.ToLongTimeString, dtmHoraUbicacionAl.Value.ToLongTimeString) = 1 Then
                    chkUbicacion.ForeColor = Color.Red
                    Resultado = False
                Else
                    chkUbicacion.ForeColor = Color.Black
                End If
            End If
        End If


        If chkEntregaNave.Checked = True Then
            If CDate(dtmEntregaNaveDel.Value.ToShortDateString) > CDate(dtmEntregaNaveAl.Value.ToShortDateString) Then
                Resultado = False
                chkEntregaNave.ForeColor = Color.Red
            Else
                chkEntregaNave.ForeColor = Color.Black
            End If
        End If

        If chkEntregacCiente.Checked = True Then
            If CDate(dtmEntregaClienteDel.Value.ToShortDateString) > CDate(dtmEntregaClienteAl.Value.ToShortDateString) Then
                Resultado = False
                chkEntregacCiente.ForeColor = Color.Red
            Else
                chkEntregacCiente.ForeColor = Color.Black
            End If
        End If

        If chkEntregaNave.Checked = True Then
            If CDate(dtmEnvioNaveDel.Value.ToShortDateString) > CDate(dtmEnvioNaveAl.Value.ToShortDateString) Then
                Resultado = False
                chkEntregaNave.ForeColor = Color.Red
            Else
                chkEntregaNave.ForeColor = Color.Black
            End If
        End If

        If chkRecepciónComercializadora.Checked = True Then
            If CDate(dtmRecepcionComercializadoraDel.Value.ToShortDateString) > CDate(dtmRecepcionComercializadoraAl.Value.ToShortDateString) Then
                Resultado = False
                chkRecepciónComercializadora.ForeColor = Color.Red
            Else
                chkRecepciónComercializadora.ForeColor = Color.Black
            End If
        End If

        Return Resultado
    End Function

    Private Sub chkEntregaNave_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregaNave.CheckedChanged
        dtmEntregaNaveDel.Enabled = chkEntregaNave.Checked
        dtmEntregaNaveAl.Enabled = chkEntregaNave.Checked
    End Sub

    Private Sub chkEntregacCiente_CheckedChanged(sender As Object, e As EventArgs) Handles chkEntregacCiente.CheckedChanged
        dtmEntregaClienteDel.Enabled = chkEntregacCiente.Checked
        dtmEntregaClienteAl.Enabled = chkEntregacCiente.Checked
    End Sub

    Private Sub chkEnvioNave_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnvioNave.CheckedChanged
        dtmEnvioNaveDel.Enabled = chkEnvioNave.Checked
        dtmEnvioNaveAl.Enabled = chkEnvioNave.Checked
    End Sub

    Private Sub chkRecepciónComercializadora_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecepciónComercializadora.CheckedChanged
        dtmRecepcionComercializadoraAl.Enabled = chkRecepciónComercializadora.Checked
        dtmRecepcionComercializadoraDel.Enabled = chkRecepciónComercializadora.Checked
    End Sub

    Private Sub chkUbicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkUbicacion.CheckedChanged
        dtmFechaUbicacionAl.Enabled = chkUbicacion.Checked
        dtmFechaUbicacionDel.Enabled = chkUbicacion.Checked
        dtmHoraUbicacionAl.Enabled = chkUbicacion.Checked
        dtmHoraUbicacionDel.Enabled = chkUbicacion.Checked
    End Sub
End Class