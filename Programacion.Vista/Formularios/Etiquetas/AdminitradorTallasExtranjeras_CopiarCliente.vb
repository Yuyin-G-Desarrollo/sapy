Imports DevExpress.XtraGrid.Views.Base

Public Class AdminitradorTallasExtranjeras_CopiarCliente

    Private UsuarioID As Integer
    Private ClienteDestino As Integer
    Private ListCorridasSeleccionadas As New List(Of Integer)()

    Private _ListaCorridas As ArrayList
    Public Property Lista() As ArrayList
        Get
            Return _ListaCorridas
        End Get
        Set(ByVal value As ArrayList)
            _ListaCorridas = value
        End Set
    End Property

    Private _ClienteOrigen As String
    Public Property ClienteOrigen() As String
        Get
            Return _ClienteOrigen
        End Get
        Set(ByVal value As String)
            _ClienteOrigen = value
        End Set
    End Property

    Private _ClienteOrigenID As Integer
    Public Property ClienteOrigenID() As Integer
        Get
            Return _ClienteOrigenID
        End Get
        Set(ByVal value As Integer)
            _ClienteOrigenID = value
        End Set
    End Property


    Private Sub AdminitradorTallasExtranjeras_CopiarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtClienteOrigen.Text = ClienteOrigen
        CargarComboClientesDestino()
        txtClienteOrigen.Select()
    End Sub

    Private Sub CargarComboClientesDestino()
        Dim objNeg As New Negocios.EtiquetasBU
        Dim dtClientesOrigen As DataTable
        Try

            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            If objNeg.ConsultarPerfilUsuario(UsuarioID).Rows.Count > 0 Then 'Si el perfil del usuario es Agente de Ventas Si no 0
                dtClientesOrigen = objNeg.ConsultarClientesDestinoCopiarTallasAgente(ClienteOrigenID, UsuarioID)
            Else 'Si el perfil del usuario es diferente a Agente de Ventas
                dtClientesOrigen = objNeg.ConsultarClientesDestinoCopiarTallas(ClienteOrigenID)
            End If
            dtClientesOrigen.Rows.InsertAt(dtClientesOrigen.NewRow, 0)
            cmbClientesDestino.DataSource = dtClientesOrigen
            cmbClientesDestino.DisplayMember = "clie_nombregenerico"
            cmbClientesDestino.ValueMember = "clie_clienteid"

        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try

    End Sub

    Private Sub cmbClientesDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientesDestino.SelectedIndexChanged

        Dim objNeg As New Negocios.EtiquetasBU
        Dim dt As DataTable
        Dim msg_adv As New Tools.AdvertenciaForm

        If cmbClientesDestino.SelectedIndex = 0 Then
            ClienteDestino = 0
            Return
        Else
            ClienteDestino = cmbClientesDestino.SelectedValue
        End If
        Me.Cursor = Cursors.WaitCursor
        Try

            dt = objNeg.ConsultarPaisesCorridasXCliente(ClienteDestino)
            grdCorridasExtranjerasDestino.DataSource = dt
            DiseñoGrid(GrdVCorridasExtranjerasDestino)
            grdCorridasExtranjerasDestino.Select()
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DiseñoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        'Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedCell.ForeColor = Color.White

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf GrdVCorridasExtranjerasDestino_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Grid.Columns.ColumnByFieldName("PaisID").Visible = False

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Abreviatura").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True


        Grid.Columns.ColumnByFieldName("Abreviatura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Corrida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.BestFitColumns()
    End Sub

    Private Sub GrdVCorridasExtranjerasDestino_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GrdVCorridasExtranjerasDestino.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = GrdVCorridasExtranjerasDestino.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim msg_adv As New Tools.AdvertenciaForm
        Dim msg_Conf As New Tools.ConfirmarForm
        Dim msg_Exito As New Tools.ExitoForm
        Dim objNegocios As New Negocios.EtiquetasBU

        If ClienteDestino = 0 Then
            msg_adv.mensaje = "Seleccione un cliente destino valido"
            msg_adv.ShowDialog()
            Return
        End If

        If ListCorridasSeleccionadas.Count = 0 Then
            msg_adv.mensaje = "No se han seleccionado corridas para guardar"
            msg_adv.ShowDialog()
            Return
        End If

        Try
            msg_Conf.mensaje = "¿Desea actualizar los registros? (Una vez realizada esta acción no se podra revertir)"
            If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                GrdVCorridasExtranjerasDestino.ClearColumnsFilter
                For Each fila In ListCorridasSeleccionadas
                    For Each CorridaDetalle As Entidades.TallasExtranjerasClienteDetalle In _ListaCorridas
                        CorridaDetalle.Cliente = ClienteDestino
                        If GrdVCorridasExtranjerasDestino.GetRowCellValue(fila, "Abreviatura") = CorridaDetalle.PaisAbreviatura Then
                            objNegocios.GuardarTallaExtranjeraClienteDetalle(CorridaDetalle, UsuarioID)
                        End If
                    Next
                Next
                msg_Exito.mensaje = "Los cambios se guardaron con éxito"
                msg_Exito.ShowDialog()
            End If
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub GrdVCorridasExtranjerasDestino_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GrdVCorridasExtranjerasDestino.CellValueChanging
        If e.Column.ToString = " " Then
            If e.Value = True Then
                If Not ListCorridasSeleccionadas.Contains(GrdVCorridasExtranjerasDestino.GetDataSourceRowIndex(e.RowHandle)) Then
                    ListCorridasSeleccionadas.Add(GrdVCorridasExtranjerasDestino.GetDataSourceRowIndex(e.RowHandle))
                End If

            Else
                If ListCorridasSeleccionadas.Contains(e.RowHandle) Then
                    ListCorridasSeleccionadas.RemoveAt(ListCorridasSeleccionadas.IndexOf(GrdVCorridasExtranjerasDestino.GetDataSourceRowIndex(e.RowHandle)))
                End If
            End If
            lblRegistrosSeleccionados.Text = ListCorridasSeleccionadas.Count
        End If
    End Sub

    Private Sub GrdVCorridasExtranjerasDestino_CustomDrawEmptyForeground(sender As Object, e As CustomDrawEventArgs) Handles GrdVCorridasExtranjerasDestino.CustomDrawEmptyForeground
        Dim VIew As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If VIew.RowCount <> 0 Then
            Return
        End If
        Dim Formato As New StringFormat
        Formato.LineAlignment = StringAlignment.Center
        'Formato.Alignment = drawFormat.LineAlignment
        e.Appearance.ForeColor = Color.Black
        e.Graphics.DrawString("No es posible copiar las corridas seleccionads porque el cliente destino no tiene listas de precios en estatus ACEPTADA O CAPTURADA.", e.Appearance.Font, SystemBrushes.ControlDarkDark, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), Formato)
    End Sub


End Class
