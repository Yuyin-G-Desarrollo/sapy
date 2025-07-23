Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class ListadoClientesPendientesReplicarForm

    Dim ObjBU As New Negocios.ReplicaClientesBU
    Dim ListadoClientes As New List(Of Entidades.Cliente)
    Dim value As New Object
    Private Sub ListadoClientesPendientesReplicarForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  CargarListaClientes()
        Tools.Utilerias.ComboObtenerCEDIS(cboCedis)
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub CargarListaClientes(ByVal idcedis As Integer)

        Try
            Cursor = Cursors.WaitCursor
            'ListadoClientes =
            grdClientesPorReplicar.DataSource = ObjBU.ConsultaClientesSinReplicar(idcedis)

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewClientesPorReplicar.Columns
                If col.FieldName = "clienteid" Or col.FieldName = "idsicy" Or col.FieldName = "nombregenerico" Or col.FieldName = "NombreEjecutiva" Then
                    col.Visible = True
                Else
                    col.Visible = False
                End If
            Next
            viewClientesPorReplicar.IndicatorWidth = 30

            DiseñoGrid.DiseñoBaseGrid(viewClientesPorReplicar)

            DiseñoGrid.EstiloColumna(viewClientesPorReplicar, "clienteid", "ClienteID", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewClientesPorReplicar, "idsicy", "Cliente_SICY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewClientesPorReplicar, "nombregenerico", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewClientesPorReplicar, "RazonSocial", "Razon Social", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewClientesPorReplicar, "NombreEjecutiva", "Ejecutiva", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")

            lblTotalSeleccionados.Text = CDbl(viewClientesPorReplicar.RowCount).ToString("N0")

            viewClientesPorReplicar.OptionsView.ColumnAutoWidth = True

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCopiarCliente_Click(sender As Object, e As EventArgs) Handles btnCopiarCliente.Click
        value = cboCedis.SelectedValue
        If (TypeOf value Is Integer) Then
            'ValidarFilaSeleccionada()
            Dim idcedis As Integer = cboCedis.SelectedValue
            If idcedis = 43 Then
                ValidarFilaSeleccionada()
            ElseIf idcedis = 82 Then
                ValidarFilaSeleccionadaLicencias()
            End If
        End If
    End Sub

    Public Sub ValidarFilaSeleccionada()
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim ClienteSAYID As Integer = 0
        Dim ClienteSICYID As Integer = 0
        Dim NombreCliente As String = String.Empty
        Dim CapturaNombreReplica As New CopiarClienteForm

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = viewClientesPorReplicar.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewClientesPorReplicar.IsRowSelected(viewClientesPorReplicar.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1
                    ClienteSAYID = CInt(viewClientesPorReplicar.GetRowCellValue(viewClientesPorReplicar.GetVisibleRowHandle(index), "clienteid"))
                    ClienteSICYID = CInt(viewClientesPorReplicar.GetRowCellValue(viewClientesPorReplicar.GetVisibleRowHandle(index), "idsicy"))
                    NombreCliente = (viewClientesPorReplicar.GetRowCellValue(viewClientesPorReplicar.GetVisibleRowHandle(index), "nombregenerico"))
                End If
            Next

            If FilasSeleccionadas = 1 Then
                If ObjBU.ValidaExisteReplicaCliente(ClienteSAYID) = False Then
                    CapturaNombreReplica.ClienteSAYID = ClienteSAYID
                    CapturaNombreReplica.NombreCliente = NombreCliente
                    CapturaNombreReplica.ClienteSICYID = ClienteSICYID
                    If CapturaNombreReplica.ShowDialog() = DialogResult.OK Then
                        CargarListaClientes(cboCedis.SelectedValue)
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El cliente ya se ha replicado.")
                End If


            ElseIf FilasSeleccionadas > 1 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Se debe de seleccionar una sola fila.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una fila.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewClientesPorReplicar_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewClientesPorReplicar.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_ReplicaClientes_Ventas.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_ReplicaClientes_Ventas.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        value = cboCedis.SelectedValue
        If (TypeOf value Is Integer) Then
            CargarListaClientes(cboCedis.SelectedValue)
        End If

    End Sub

    Private Sub ValidarFilaSeleccionadaLicencias()
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim ClienteSAYID As Integer = 0
        Dim ClienteSICYID As Integer = 0
        Dim NombreCliente As String = String.Empty
        Dim CapturaNombreReplica As New CopiarClienteLicenciasForm

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = viewClientesPorReplicar.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewClientesPorReplicar.IsRowSelected(viewClientesPorReplicar.GetVisibleRowHandle(index))) = True Then
                    FilasSeleccionadas += 1
                    ClienteSAYID = CInt(viewClientesPorReplicar.GetRowCellValue(viewClientesPorReplicar.GetVisibleRowHandle(index), "clienteid"))
                    ClienteSICYID = CInt(viewClientesPorReplicar.GetRowCellValue(viewClientesPorReplicar.GetVisibleRowHandle(index), "idsicy"))
                    NombreCliente = (viewClientesPorReplicar.GetRowCellValue(viewClientesPorReplicar.GetVisibleRowHandle(index), "nombregenerico"))
                End If
            Next

            If FilasSeleccionadas = 1 Then
                If ObjBU.ValidaExisteReplicaClienteReedition(ClienteSAYID) = False Then
                    CapturaNombreReplica.ClienteSAYID = ClienteSAYID
                    CapturaNombreReplica.NombreCliente = NombreCliente
                    CapturaNombreReplica.ClienteSICYID = ClienteSICYID
                    If CapturaNombreReplica.ShowDialog() = DialogResult.OK Then
                        CargarListaClientes(cboCedis.SelectedValue)
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El cliente ya se ha replicado.")
                End If


            ElseIf FilasSeleccionadas > 1 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Se debe de seleccionar una sola fila.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una fila.")
            End If

        Catch ex As Exception
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class