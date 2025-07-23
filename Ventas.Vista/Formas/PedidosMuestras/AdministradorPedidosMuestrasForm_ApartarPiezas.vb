Imports System.Media
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class AdministradorPedidosMuestrasForm_ApartarPiezas

    Dim objBU As New Negocios.PedidosMuestrasBU
    Dim PiezasPorApartar As Integer
    Dim PiezasApartadas As Integer
    Dim UsuarioID As Integer


    Private _Pedido As Integer
    Public Property Pedido() As Integer
        Get
            Return _Pedido
        End Get
        Set(ByVal value As Integer)
            _Pedido = value
        End Set
    End Property

    Private _Cliente As String
    Public Property Cliente() As String
        Get
            Return _Cliente
        End Get
        Set(ByVal value As String)
            _Cliente = value
        End Set
    End Property


    Private Sub AdministradorPedidosMuestrasForm_ApartarPiezas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInicial()
    End Sub


    Private Sub CargarInicial()
        Me.Cursor = Cursors.WaitCursor

        UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        CargarGrid_PartidasConInventario()
        CargarGrid_InventarioDisponible()
        CargarGrid_PiezasApartadas()
        lblPedido.Text = _Pedido
        lblCliente.Text = _Cliente
        lblPiezasPorApartar.Text = PiezasPorApartar
        lblPiezasApartadas.Text = PiezasApartadas
        txtcapturacodigos.Select()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CargarGrid_PartidasConInventario()
        Dim accion As Integer = 2
        Dim dtPedidoDetalle As DataTable
        Try
            dtPedidoDetalle = objBU.ListaPedidosMuestrasDetalles(_Pedido, accion)
            grdPartidasInventarioDisponible.DataSource = dtPedidoDetalle
            DiseñoGrid(grdVPartidasInventarioDisponible)
            PiezasPorApartar = dtPedidoDetalle.Rows.Count
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub CargarGrid_InventarioDisponible()
        Dim dtPedidoDetalle As DataTable
        Try
            dtPedidoDetalle = objBU.ConsultarInventarioDisponiblePedidoMuestra(_Pedido)
            grdInventarioDisponible.DataSource = dtPedidoDetalle
            DiseñoGrid(grdVInventarioDisponible)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub CargarGrid_PiezasApartadas()
        Dim dtPiezasApartadas As DataTable
        Try
            dtPiezasApartadas = objBU.ConsultarPiezasApartadas(_Pedido)
            grdPiezasApartadas.DataSource = dtPiezasApartadas
            DiseñoGrid(grdVPiezasApartadas)

            PiezasApartadas = dtPiezasApartadas.Rows.Count


        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Public Sub DiseñoGrid(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        'Grid.OptionsView.EnableAppearanceEvenRow = True
        'Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = False
        Grid.OptionsSelection.EnableAppearanceFocusedRow = False
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        'Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        'Grid.Appearance.EvenRow.BackColor = Color.White
        'Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        'Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next

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
            mensajeExito.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdVPartidasInventarioDisponible_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPartidasInventarioDisponible.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdVInventarioDisponible_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVInventarioDisponible.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdVPiezasApartadas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPiezasApartadas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub txtcapturacodigos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcapturacodigos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Trim(txtcapturacodigos.Text) <> String.Empty Then
                Dim CadenaCapturada As String = Trim(txtcapturacodigos.Text).Replace("'", "-")
                ApartarPiezasMuestra(CadenaCapturada)
            End If
        End If
    End Sub

    Private Sub ReproducirSonidoCorrecto()
        Dim player As New SoundPlayer(My.Resources.SonidoExito)
        player.Play()
    End Sub

    Private Sub ReproducirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_05)
        player.Play()
    End Sub


    Private Sub ApartarPiezasMuestra(CadenaPieza As String)
        Dim dtApartarPiezas As DataTable
        Try
            dtApartarPiezas = objBU.ApartarPiezaMuestra(CadenaPieza, _Pedido, UsuarioID)
            If dtApartarPiezas.Rows.Count > 0 Then
                If dtApartarPiezas.Rows(0).Item(0).ToString = "ÉXITO" Then
                    ReproducirSonidoCorrecto()
                    CargarInicial()
                ElseIf dtApartarPiezas.Rows(0).Item(0).ToString = "SE REQUIERE PAR, NO HAY DISPONIBLE DEL OTRO PIE" Then
                    ReproducirSonidoError()
                    show_message("Advertencia", "SE REQUIERE PAR, NO HAY DISPONIBLE DEL OTRO PIE")
                Else
                    ReproducirSonidoError()
                    show_message("Advertencia", "NO SE PUEDE APARTAR")
                End If
            End If
            txtcapturacodigos.Clear()
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub txtcapturacodigos_Leave(sender As Object, e As EventArgs) Handles txtcapturacodigos.Leave
        txtcapturacodigos.Focus()
    End Sub
End Class