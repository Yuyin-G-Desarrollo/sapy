Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Reflection

Public Class AlertaMovimientosPendientesForm
    Public dtMovmientosPendientes As DataTable

    Private Sub AlertaMovimientosPendientesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblHoraEnvioAlerta.Text = Date.Now
        If dtMovmientosPendientes Is Nothing Then
            llenarDatos()
        End If
        mostrarMovimientosPendientes()
    End Sub

    Public Sub llenarDatos()
        Dim objBu As New Framework.Negocios.AlertasBU
        dtMovmientosPendientes = objBu.consultaListadoMovimientosPendientes()
    End Sub

    Public Sub mostrarMovimientosPendientes()
        If Not dtMovmientosPendientes Is Nothing Then
            If dtMovmientosPendientes.Rows.Count > 0 Then
                grdMoviminetosPendientes.DataSource = dtMovmientosPendientes
                With grdMoviminetosPendientes.DisplayLayout.Bands(0)
                    .Columns("IDMOVMIENTO").Hidden = True
                    .Columns("IDPATRON").Hidden = True
                    .Columns("IDESTATUS").Hidden = True
                    .Columns("IDNAVE").Hidden = True
                    .Columns("MOVIMIENTO").CellActivation = Activation.NoEdit
                    .Columns("PATRON").CellActivation = Activation.NoEdit
                    .Columns("NUM. MOVIMIENTOS").CellActivation = Activation.NoEdit

                    .Columns("NUM. MOVIMIENTOS").CellAppearance.TextHAlign = HAlign.Right

                    '.Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                    '.Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False

                    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                End With

                grdMoviminetosPendientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                grdMoviminetosPendientes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                grdMoviminetosPendientes.DisplayLayout.Override.RowSelectorWidth = 35
                grdMoviminetosPendientes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                grdMoviminetosPendientes.Rows(0).Selected = True
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdMoviminetosPendientes_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdMoviminetosPendientes.DoubleClickRow
        Dim objBU As New Framework.Negocios.AlertasBU
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim movimiento As String = String.Empty
        Dim pantalla As String = String.Empty
        Dim patronId As Int32 = 0
        Dim estatusId As Int32 = 0
        Dim naveId As Int32 = 0

        Try
            movimiento = e.Row.Cells("MOVIMIENTO").Value
            pantalla = objBU.consultarPermisoPantallaNomina(movimiento)
            patronId = CInt(e.Row.Cells("IDPATRON").Value)
            estatusId = CInt(e.Row.Cells("IDESTATUS").Value)
            naveId = CInt(e.Row.Cells("IDNAVE").Value)

            If pantalla <> "" Then
                Dim tipo As Type = Type.GetType(pantalla)
                Dim objForma As Windows.Forms.Form = TryCast(Activator.CreateInstance(tipo), Windows.Forms.Form)
                Dim myType As Type = objForma.GetType()
                Dim atPatron As PropertyInfo = myType.GetProperty("prPatronId")
                Dim atEstatus As PropertyInfo = myType.GetProperty("prEstatusId")
                Dim atNave As PropertyInfo = myType.GetProperty("prNaveId")

                objForma.MdiParent = MdiParent
                atPatron.SetValue(objForma, patronId, Nothing)
                atEstatus.SetValue(objForma, estatusId, Nothing)
                atNave.SetValue(objForma, naveId, Nothing)
                objForma.Show()
            Else
                objMensajeAdv.mensaje = "No tiene permiso para la pantalla"
                objMensajeAdv.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        lblHoraEnvioAlerta.Text = Date.Now
        llenarDatos()
        mostrarMovimientosPendientes()
    End Sub
End Class