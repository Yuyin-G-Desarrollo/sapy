Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class AgregarOTForm

    Public ClienteID As Integer = 0
    Public FolioVerificacion As Integer = 0
    Dim ObjBU As New Negocios.VerificacionSalidasBU
    Dim ListaOT As List(Of Entidades.OTPendienteVerificar)

    Private Sub AgregarOTForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarGrid(ClienteID)
    End Sub

    Public Sub CargarGrid(ByVal ClienteId As Integer)
        ListaOT = ObjBU.ConsultaOTsPendientesSalida(ClienteId)

        grdAgregarOTs.DataSource = ListaOT
        DiseñoGrid.DiseñoBaseGrid(viewAgregarOTs)

        DiseñoGrid.EstiloColumna(viewAgregarOTs, "PedidoSAY", "Pedido SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
        DiseñoGrid.EstiloColumna(viewAgregarOTs, "PedidoSICY", "Pedido SICY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
        DiseñoGrid.EstiloColumna(viewAgregarOTs, "TotalPares", "Total " & vbCrLf & " Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
        DiseñoGrid.EstiloColumna(viewAgregarOTs, "TotalConfirmados", "Total " & vbCrLf & " Confirmados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
        viewAgregarOTs.BestFitColumns()
        lblTotalSeleccionados.Text = CDbl(viewAgregarOTs.RowCount).ToString("N0")

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim OTs As String = String.Empty


        Try
            If ListaOT.Where(Function(x) x.Seleccionar = True).Count = 0 Then
                Throw New System.InvalidOperationException("No hay elementos seleccionados")
            End If

            Dim elementos = ListaOT.Where(Function(x) x.Seleccionar = True)

            For Each Elemento As Entidades.OTPendienteVerificar In elementos
                If OTs = String.Empty Then
                    OTs = Elemento.OT.ToString()
                Else
                    OTs = OTs & "," & Elemento.OT.ToString()
                End If
            Next

            ObjBU.InsertarOT(FolioVerificacion, OTs)
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han insertado las OTs existosamente.")

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As InvalidOperationException
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message.ToString())
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged

        For Each item As Entidades.OTPendienteVerificar In ListaOT
            item.Seleccionar = chkSeleccionar.Checked
        Next

        grdAgregarOTs.RefreshDataSource()
    End Sub


    Private Sub viewAgregarOTs_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles viewAgregarOTs.CellValueChanged

        Dim OT As Integer = viewAgregarOTs.GetRowCellValue(e.RowHandle, "OT")
        Dim Seleccionar As Boolean = viewAgregarOTs.GetRowCellValue(e.RowHandle, "Seleccionar")

        Dim EntidadOT As Entidades.OTPendienteVerificar = ListaOT.Where(Function(x) x.OT = OT).FirstOrDefault
        EntidadOT.Seleccionar = Seleccionar
    End Sub

End Class