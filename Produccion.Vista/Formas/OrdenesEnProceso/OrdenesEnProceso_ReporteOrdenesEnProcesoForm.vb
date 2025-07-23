Imports DevExpress.Export
Imports DevExpress.XtraPrinting
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Programacion.Negocios
Imports Tools
Imports Tools.modMensajes
Imports Ventas.Vista

Public Class OrdenesEnProceso_ReporteOrdenesEnProcesoForm
    Private objOrdenesEnProcesoBU As New OrdenesEnProcesoBU
    Dim listaInicial As New List(Of String)
    Dim listaPedidoSAY As New List(Of String)
    Dim listaPedidoSICY As New List(Of String)
    Dim listaLote As New List(Of String)
    Dim litaModeloSAY As New List(Of String)
    Dim litaModeloSICY As New List(Of String)

#Region "Filtro Pedido SAY"
    Private Sub btnLimPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimPedidoSAY.Click
        grdPedidoSAY.DataSource = Nothing
        grdPedidoSAY.DataSource = listaInicial
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        DiseñarGridFiltros(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return
            listaPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listaPedidoSAY
            txtPedidoSAY.Text = String.Empty
        End If
    End Sub
#End Region

#Region "Filtro Pedido SICY"
    Private Sub btnLimPedidoSICY_Click(sender As Object, e As EventArgs) Handles btnLimPedidoSICY.Click
        grdPedidoSICY.DataSource = Nothing
        listaPedidoSICY.Clear()
        grdPedidoSICY.DataSource = listaInicial
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        DiseñarGridFiltros(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listaPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listaPedidoSICY
            txtPedidoSICY.Text = String.Empty
        End If
    End Sub
#End Region

#Region "Filtro Lote"
    Private Sub btnLimLote_Click(sender As Object, e As EventArgs) Handles btnLimLote.Click
        grdLote.DataSource = Nothing
        listaLote.Clear()
        grdLote.DataSource = listaInicial
    End Sub

    Private Sub grdLote_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdLote.InitializeLayout
        DiseñarGridFiltros(grdLote)
        grdLote.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Lote"
    End Sub

    Private Sub grdLote_KeyDown(sender As Object, e As KeyEventArgs) Handles grdLote.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdLote.DeleteSelectedRows(False)
    End Sub

    Private Sub txtLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLote.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtLote.Text) Then Return

            listaLote.Add(txtLote.Text)
            grdLote.DataSource = Nothing
            grdLote.DataSource = listaLote

            txtLote.Text = String.Empty
        End If
    End Sub
#End Region

#Region "Filtro Modelo SAY"
    Private Sub btnLimModeloSAY_Click(sender As Object, e As EventArgs) Handles btnLimModeloSAY.Click
        grdModeloSAY.DataSource = Nothing
        litaModeloSAY.Clear()
        grdModeloSAY.DataSource = listaInicial
    End Sub

    Private Sub grdModeloSAY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdModeloSAY.InitializeLayout
        DiseñarGridFiltros(grdModeloSAY)
        grdModeloSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo SAY"
    End Sub

    Private Sub grdModeloSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModeloSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModeloSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub txtModeloSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModeloSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtModeloSAY.Text) Then Return

            litaModeloSAY.Add(txtModeloSAY.Text)
            grdModeloSAY.DataSource = Nothing
            grdModeloSAY.DataSource = litaModeloSAY
            txtModeloSAY.Text = String.Empty
        End If
    End Sub


#End Region

#Region "Filtro Modelo SICY"
    Private Sub btnLimModeloSICY_Click(sender As Object, e As EventArgs) Handles btnLimModeloSICY.Click
        grdModeloSICY.DataSource = Nothing
        litaModeloSICY.Clear()
        grdModeloSICY.DataSource = listaInicial
    End Sub
    Private Sub grdModeloSICY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdModeloSICY.InitializeLayout
        DiseñarGridFiltros(grdModeloSICY)
        grdModeloSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo SICY"
    End Sub

    Private Sub grdModeloSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModeloSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModeloSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub txtModeloSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModeloSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtModeloSICY.Text) Then Return

            litaModeloSICY.Add(txtModeloSICY.Text)
            grdModeloSICY.DataSource = Nothing
            grdModeloSICY.DataSource = litaModeloSICY
            txtModeloSICY.Text = String.Empty
        End If
    End Sub



#End Region

#Region "Filtro Nave Desarrollo"
    Private Sub btnAgregarNaveDesarrollo_Click(sender As Object, e As EventArgs) Handles btnAgregarNaveDesarrollo.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 1
            listado.parametroFiltro = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            For Each row As UltraGridRow In grdNaveDesarrollo.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdNaveDesarrollo.DataSource = listado.listParametros
            With grdNaveDesarrollo
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Nave Desarrollo"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimNaveDesarrollo_Click(sender As Object, e As EventArgs) Handles btnLimNaveDesarrollo.Click
        grdNaveDesarrollo.DataSource = listaInicial
    End Sub

    Private Sub grdNaveDesarrollo_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdNaveDesarrollo.InitializeLayout
        DiseñarGridFiltros(grdNaveDesarrollo)
        grdNaveDesarrollo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave Desarrollo"
    End Sub

    Private Sub grdNaveDesarrollo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNaveDesarrollo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNaveDesarrollo.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Hormas"
    Private Sub btnAgregarHorma_Click(sender As Object, e As EventArgs) Handles btnAgregarHorma.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 2

            For Each row As UltraGridRow In grdHorma.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdHorma.DataSource = listado.listParametros
            With grdHorma
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Horma"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimHorma_Click(sender As Object, e As EventArgs) Handles btnLimHorma.Click
        grdHorma.DataSource = listaInicial
    End Sub

    Private Sub grdHorma_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdHorma.InitializeLayout
        DiseñarGridFiltros(grdHorma)
        grdHorma.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Horma"
    End Sub

    Private Sub grdHorma_KeyDown(sender As Object, e As KeyEventArgs) Handles grdHorma.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdHorma.DeleteSelectedRows(False)
    End Sub
#End Region
#Region "Filtro Proveedor Suela"
    Private Sub btnAgregarProveedorSuela_Click(sender As Object, e As EventArgs) Handles btnAgregarProveedorSuela.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 3

            For Each row As UltraGridRow In grdProveedorSuela.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdProveedorSuela.DataSource = listado.listParametros
            With grdProveedorSuela
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Proveedor Suela"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimProveedorSuela_Click(sender As Object, e As EventArgs) Handles btnLimProveedorSuela.Click
        grdProveedorSuela.DataSource = listaInicial
    End Sub

    Private Sub grdProveedorSuela_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdProveedorSuela.InitializeLayout
        DiseñarGridFiltros(grdProveedorSuela)
        grdProveedorSuela.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Proveedor Suela"
    End Sub

    Private Sub grdProveedorSuela_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProveedorSuela.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdProveedorSuela.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Temporada"
    Private Sub btnAgregarTemporada_Click(sender As Object, e As EventArgs) Handles btnAgregarTemporada.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 4

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
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Temporada"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimTemporada_Click(sender As Object, e As EventArgs) Handles btnLimTemporada.Click
        grdTemporada.DataSource = listaInicial
    End Sub

    Private Sub grdTemporada_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTemporada.InitializeLayout
        DiseñarGridFiltros(grdTemporada)
        grdTemporada.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Temporada"
    End Sub

    Private Sub grdTemporada_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTemporada.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTemporada.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Corridas"
    Private Sub btnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 5

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
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimCorrida_Click(sender As Object, e As EventArgs) Handles btnLimCorrida.Click
        grdCorrida.DataSource = listaInicial
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        DiseñarGridFiltros(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Cliente"
    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 6

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
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimCliente_Click(sender As Object, e As EventArgs) Handles btnLimCliente.Click
        grdCliente.DataSource = listaInicial
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        DiseñarGridFiltros(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Suela"
    Private Sub btnAgregarSuela_Click(sender As Object, e As EventArgs) Handles btnAgregarSuela.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 7

            For Each row As UltraGridRow In grdSuela.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdSuela.DataSource = listado.listParametros
            With grdSuela
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Suela"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimSuela_Click(sender As Object, e As EventArgs) Handles btnLimSuela.Click
        grdSuela.DataSource = listaInicial
    End Sub

    Private Sub grdSuela_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdSuela.InitializeLayout
        DiseñarGridFiltros(grdSuela)
        grdSuela.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Suela"
    End Sub

    Private Sub grdSuela_KeyDown(sender As Object, e As KeyEventArgs) Handles grdSuela.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdSuela.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Marca"
    Private Sub btnAgregarMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarMarca.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 8

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
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimMarca_Click(sender As Object, e As EventArgs) Handles btnLimMarca.Click
        grdMarca.DataSource = listaInicial
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        DiseñarGridFiltros(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Colecciones"
    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 9

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
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        DiseñarGridFiltros(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Piel Color"
    Private Sub btnAgregarPielColor_Click(sender As Object, e As EventArgs) Handles btnAgregarPielColor.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 10

            For Each row As UltraGridRow In grdPielColor.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdPielColor.DataSource = listado.listParametros
            With grdPielColor
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Piel Color"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimPielColor_Click(sender As Object, e As EventArgs) Handles btnLimPielColor.Click
        grdPielColor.DataSource = listaInicial
    End Sub

    Private Sub grdPielColor_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout
        DiseñarGridFiltros(grdPielColor)
        grdPielColor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel Color"
    End Sub

    Private Sub grdPielColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPielColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPielColor.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Familia Ventas"
    Private Sub btnAgregarFamiliaVenta_Click(sender As Object, e As EventArgs) Handles btnAgregarFamiliaVenta.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 11

            For Each row As UltraGridRow In grdFamiliaVenta.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdFamiliaVenta.DataSource = listado.listParametros
            With grdFamiliaVenta
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia Venta"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimFamiliaVenta_Click(sender As Object, e As EventArgs) Handles btnLimFamiliaVenta.Click
        grdFamiliaVenta.DataSource = listaInicial
    End Sub

    Private Sub grdFamiliaVenta_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFamiliaVenta.InitializeLayout
        DiseñarGridFiltros(grdFamiliaVenta)
        grdFamiliaVenta.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia Venta"
    End Sub

    Private Sub grdFamiliaVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamiliaVenta.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamiliaVenta.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Filtro Familia"
    Private Sub btnAgregarFamilia_Click(sender As Object, e As EventArgs) Handles btnAgregarFamilia.Click
        Try
            Dim listado As New OrdenesEnProceso_ListadoParametrosForm
            Dim listaParametroID As New List(Of String)

            listado.tipoBusqueda = 12

            For Each row As UltraGridRow In grdFamilia.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdFamilia.DataSource = listado.listParametros
            With grdFamilia
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimFamilia_Click(sender As Object, e As EventArgs) Handles btnLimFamilia.Click
        grdFamilia.DataSource = listaInicial
    End Sub

    Private Sub grdFamilia_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFamilia.InitializeLayout
        DiseñarGridFiltros(grdFamilia)
        grdFamilia.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub grdFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamilia.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamilia.DeleteSelectedRows(False)
    End Sub
#End Region

#Region "Eventos Filtros"
    Private Sub DiseñarGridFiltros(grid As UltraGrid)
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

        AsignarFormatoColumna(grid)
    End Sub

    Public Sub AsignarFormatoColumna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Function ConsultarFiltro(grdFiltro As UltraGrid, Optional indiceFiltro As Integer = 0) As String
        Dim filtro As String = String.Empty
        For Each row As UltraGridRow In grdFiltro.Rows
            If row.Index = 0 Then
                filtro += " " + row.Cells(indiceFiltro).Text.Replace(" ", "").Replace(",", "") + ""
            Else
                filtro += ", " + row.Cells(indiceFiltro).Text.Replace(" ", "").Replace(",", "") + ""
            End If
        Next
        ConsultarFiltro = filtro
    End Function
#End Region

    Private Sub Reportes_OrdenesEnProcesoForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        CargarNaveSegunUsuario()
        InicializarFiltros()
    End Sub

    Private Sub InicializarFiltros()
        dtpFechaInicio.Value = Now.ToShortDateString
        dtpFechaFin.Value = Now.ToShortDateString
        rbtFechaPrograma.Checked = True
        listaInicial = New List(Of String)
        grdPedidoSAY.DataSource = listaInicial
        grdPedidoSICY.DataSource = listaInicial
        grdLote.DataSource = listaInicial
        grdModeloSAY.DataSource = listaInicial
        grdModeloSICY.DataSource = listaInicial
        grdNaveDesarrollo.DataSource = listaInicial
        grdHorma.DataSource = listaInicial
        grdProveedorSuela.DataSource = listaInicial
        grdTemporada.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial
        grdCliente.DataSource = listaInicial
        grdSuela.DataSource = listaInicial
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        grdPielColor.DataSource = listaInicial
        grdFamiliaVenta.DataSource = listaInicial
        grdFamilia.DataSource = listaInicial
        cmbNave.EditValue = Nothing
        cmbGrupo.EditValue = Nothing
        rdoTodos.Checked = True
    End Sub

    Private Sub CargarNaveSegunUsuario()
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim dtNaves As New DataTable
        Tools.MostrarEspere(Me)
        dtNaves = objOrdenesEnProcesoBU.ConsultarNavesPorUsuario(UsuarioID)
        Tools.TerminarEspere(Me)
        If dtNaves.Rows.Count = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "El usuario no cuenta con una nave asignada.")
            Return
        End If
        cmbNave.Properties.DataSource = dtNaves
        cmbNave.EditValue = Nothing
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    Private Sub chActivaFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chActivaFecha.CheckedChanged
        grpFiltroFecha.Enabled = Not chActivaFecha.Checked
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        InicializarFiltros()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Dim objFiltrosOrdenesProceso As New Entidades.FiltroOrdenesEnProceso
            If cmbNave.EditValue = Nothing Then
                objFiltrosOrdenesProceso.PNaveID = 0
            Else
                objFiltrosOrdenesProceso.PNaveID = cmbNave.EditValue
            End If
            If cmbGrupo.EditValue = Nothing Then
                objFiltrosOrdenesProceso.PGrupoNave = ""
            Else
                objFiltrosOrdenesProceso.PGrupoNave = cmbGrupo.EditValue
            End If
            objFiltrosOrdenesProceso.PPedidosSAYID = ConsultarFiltro(grdPedidoSAY)
            objFiltrosOrdenesProceso.PPedidosSICYID = ConsultarFiltro(grdPedidoSICY)
            objFiltrosOrdenesProceso.PLotes = ConsultarFiltro(grdLote)
            objFiltrosOrdenesProceso.PModelosSAY = ConsultarFiltro(grdModeloSAY)
            objFiltrosOrdenesProceso.PModelosSICY = ConsultarFiltro(grdModeloSICY)
            objFiltrosOrdenesProceso.PNavesDesarrolloID = ConsultarFiltro(grdNaveDesarrollo)
            objFiltrosOrdenesProceso.PHormasID = ConsultarFiltro(grdHorma)
            objFiltrosOrdenesProceso.PProveedoresSuelaID = ConsultarFiltro(grdProveedorSuela)
            objFiltrosOrdenesProceso.PTemporadasID = ConsultarFiltro(grdTemporada)
            objFiltrosOrdenesProceso.PCorridas = ConsultarFiltro(grdCorrida)
            objFiltrosOrdenesProceso.PClientesID = ConsultarFiltro(grdCliente)
            objFiltrosOrdenesProceso.PSuelasID = ConsultarFiltro(grdSuela)
            objFiltrosOrdenesProceso.PMarcasID = ConsultarFiltro(grdMarca)
            objFiltrosOrdenesProceso.PColeccionesID = ConsultarFiltro(grdColeccion)
            objFiltrosOrdenesProceso.PPielesColoresID = ConsultarFiltro(grdPielColor)
            objFiltrosOrdenesProceso.PFamiliasVentaID = ConsultarFiltro(grdFamiliaVenta)
            objFiltrosOrdenesProceso.PFamiliasID = ConsultarFiltro(grdFamilia)
            Select Case True
                Case chActivaFecha.Checked
                    objFiltrosOrdenesProceso.PTipoConsulta = ""
                Case rbtFechaEntrega.Checked
                    objFiltrosOrdenesProceso.PTipoConsulta = "ENTREGA_CLIENTE"
                Case rbtFechaEntradaAlmacen.Checked
                    objFiltrosOrdenesProceso.PTipoConsulta = "ENTRADA_ALMACEN"
                Case Else
                    objFiltrosOrdenesProceso.PTipoConsulta = "PROGRAMA"
            End Select

            If objFiltrosOrdenesProceso.PTipoConsulta <> "" Then
                objFiltrosOrdenesProceso.PFechaInicio = dtpFechaInicio.Value.ToShortDateString()
                objFiltrosOrdenesProceso.PFechaFin = dtpFechaFin.Value.ToShortDateString()
            Else
                objFiltrosOrdenesProceso.PFechaInicio = ""
                objFiltrosOrdenesProceso.PFechaFin = ""
            End If
            Select Case True
                Case rdoTodos.Checked
                    objFiltrosOrdenesProceso.PTipoBusqueda = ""
                Case rdoConVigencia.Checked
                    objFiltrosOrdenesProceso.PTipoBusqueda = "CON_VIGENCIA"
                Case rdoOrdenesPendientes.Checked
                    objFiltrosOrdenesProceso.PTipoBusqueda = "ORDENES_PENDIENTES"
            End Select
            Dim dtOrdenesEnProceso As New DataTable
            Dim esReporteLote As Boolean = (cmbTipoReporte.EditValue = "LOTE" OrElse cmbTipoReporte.EditValue Is Nothing)

            Tools.MostrarEspere(Me)

            If esReporteLote Then
                dtOrdenesEnProceso = objOrdenesEnProcesoBU.ConsultarOrdenesEnProcesoFiltros(objFiltrosOrdenesProceso)
            Else
                dtOrdenesEnProceso = objOrdenesEnProcesoBU.ConsultarLotesEntregadosPorMesFiltros(objFiltrosOrdenesProceso)
            End If

            Tools.TerminarEspere(Me)

            If dtOrdenesEnProceso.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se encontró información con los filtros seleccionados.")
                If Not esReporteLote Then Return
            End If

            If esReporteLote Then
                grvOrdenesEnProceso.ClearColumnsFilter()
                grdOrdenesEnProceso.DataSource = dtOrdenesEnProceso
                lblRegistros.Text = dtOrdenesEnProceso.Rows.Count.ToString("N0")
                lblUltimaDistribucion.Text = Date.Now.ToString()
                DiseñoGrid.AlternarColorEnFilas(grvOrdenesEnProceso)
                grvOrdenesEnProceso.BestFitColumns()
                CalcularTotales(dtOrdenesEnProceso)
                If dtOrdenesEnProceso.Rows.Count > 0 Then pnlFiltros.Visible = False
            Else
                Dim form As New OrdenesEnProceso_ReporteOrdenesEnProcesoPorMesForm With {
                    .dtReporte = dtOrdenesEnProceso,
                    .MdiParent = Me.MdiParent
                }
                form.Show()
            End If
        Catch ex As Exception
            Tools.TerminarEspere(Me)
            Tools.MostrarMensaje(Mensajes.Warning, ex.Message)
        End Try
    End Sub

    Private Sub CalcularTotales(dtOrdenesEnProceso As DataTable)
        Dim NumeroLotes As String = "0"
        Dim LotesProceso As String = "0"
        Dim LotesTernminados As String = "0"
        Dim ParesStock As String = "0"
        Dim NumeroPares As String = "0"

        Dim dtNumeroLotes = dtOrdenesEnProceso.AsEnumerable.Select(Function(x) x.Item("Lote")).Distinct()

        Dim dtLotesProceso = (From fila In dtOrdenesEnProceso.AsEnumerable
                              Select New With {
                                    .Lote = fila.Field(Of Int32)("Lote"),
                                    .FEchaSalida = fila.Item("FechaSalida")
                                  }).Distinct.ToList()


        LotesProceso = dtLotesProceso.AsEnumerable.Where(Function(y) IsDBNull(y.FEchaSalida) = True).Select(Function(x) x.Lote).Distinct.Count.ToString

        LotesTernminados = dtLotesProceso.AsEnumerable.Where(Function(y) IsDBNull(y.FEchaSalida) = False).Select(Function(x) x.Lote).Distinct.Count.ToString

        ParesStock = dtOrdenesEnProceso.AsEnumerable.Sum(Function(x) x.Item("ParesStock"))
        NumeroPares = dtOrdenesEnProceso.AsEnumerable.Sum(Function(x) x.Item("Pares"))
        NumeroLotes = dtNumeroLotes.Count().ToString()

        lblLotesProceso.Text = CDbl(LotesProceso).ToString("N0")
        lblLotesTerminados.Text = CDbl(LotesTernminados).ToString("N0")
        lblParesStock.Text = CDbl(ParesStock).ToString("N0")
        lblParesCliente.Text = CDbl(NumeroPares).ToString("N0")
        lblTotaldeLotes.Text = CDbl(NumeroLotes).ToString("N0")
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If grvOrdenesEnProceso.DataRowCount > 0 Then
                nombreReporte = Me.Text
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grvOrdenesEnProceso.GroupCount > 0 Then
                            grvOrdenesEnProceso.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            grvOrdenesEnProceso.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
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

    Private Sub grvOrdenesEnProceso_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles grvOrdenesEnProceso.CustomSummaryCalculate
        If e.IsTotalSummary Then
            Dim listLotes As New List(Of String)
            For row As Integer = 0 To grvOrdenesEnProceso.RowCount - 1
                If listLotes.Contains(grvOrdenesEnProceso.GetDataRow(row).Item("Lote").ToString) = False Then
                    listLotes.Add(grvOrdenesEnProceso.GetDataRow(row).Item("Lote").ToString)
                End If
            Next
            e.TotalValue = listLotes.Count()
            e.TotalValueReady = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub rbtFechaEntradaAlmacen_CheckedChanged(sender As Object, e As EventArgs) Handles rbtFechaEntradaAlmacen.CheckedChanged
        lblTipoReporte.Enabled = rbtFechaEntradaAlmacen.Checked
        cmbTipoReporte.Enabled = rbtFechaEntradaAlmacen.Checked
        If rbtFechaEntradaAlmacen.Checked = False Then
            cmbTipoReporte.EditValue = "LOTE"
        End If
    End Sub

    Private Sub grvOrdenesEnProceso_CellMerge(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs) Handles grvOrdenesEnProceso.CellMerge
        e.Handled = True
        If e.Column.FieldName = ("Nave") Then
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

        If e.Column.FieldName = ("ModeloSAY") Then
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

        If e.Column.FieldName = ("PedidoSICYID") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 6).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("PedidoSAYID") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 7).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If

        If e.Column.FieldName = ("Cliente") Then
            Dim view = sender
            Dim previousCol As Object

            previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 8).FieldName
            'get the previous column
            If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                e.Handled = True
            End If
        End If


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

        If e.Column.FieldName = ("SuelaProveedor") Then
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

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub OrdenesEnProceso_ReporteOrdenesEnProcesoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
    End Sub
End Class