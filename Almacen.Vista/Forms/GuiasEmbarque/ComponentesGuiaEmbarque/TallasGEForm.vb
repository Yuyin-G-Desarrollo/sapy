Imports Almacen.Negocios
Imports Tools
Imports Tools.Utilerias

Public Class TallasGEForm
    Public embarqueID As Integer
    Public numeroCaja As Integer
    Public totalPares As Integer
    Public existenR As Integer
    Dim segundaVez As Boolean
    Dim objInstancia As New AdministradorDocumentosBU
    Dim salir As Integer
    Dim confirmar As New Tools.ConfirmarForm

    Private Sub llenarcombocajas()
        Dim tabla = objInstancia.ConsultarTallas
        With cbTalla
            .DataSource = tabla
            .DisplayMember = "Talla"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub cbTalla_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTalla.SelectedIndexChanged
        If existenR <> 1 Then
            Dim value = cbTalla.SelectedValue
            If (TypeOf value Is DataRowView) Then Return

            Dim resultado = objInstancia.ConsultarTallasCaja(numeroCaja, embarqueID, cbTalla.SelectedValue)
            If resultado.ErrorTallas.Error <> 1 Then
                grdTallas.DataSource = resultado.ListaTallas
                DiseñoGrid.DiseñoBaseGrid(vwTallas)

                DiseñoGrid.EstiloColumna(vwTallas, "ID", "ID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, False, Nothing, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwTallas, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwTallas, "Talla", "Talla", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 180, False, Nothing, "{0:N0}")


            Else
                Utilerias.show_message(TipoMensaje.Advertencia, resultado.ErrorTallas.Mensaje)
            End If
        End If
    End Sub

    Private Sub consultarregistrosExistentes()
        If existenR = 1 Then
            Dim resultado = objInstancia.ConsultarDetalleTallaCajas(embarqueID, numeroCaja)

            If resultado.Rows.Count <> 0 Then
                grdTallas.DataSource = resultado
                DiseñoGrid.DiseñoBaseGrid(vwTallas)
                cbTalla.SelectedValue = resultado.Rows(0).Item("TallaId")
                DiseñoGrid.EstiloColumna(vwTallas, "ID", "ID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, False, Nothing, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwTallas, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwTallas, "Talla", "Talla", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 180, False, Nothing, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwTallas, "TallaID", "Talla", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 180, False, Nothing, "{0:N0}")

                cbTalla.Enabled = False
                Button1.Visible = True
                salir = 1
                segundaVez = True
                conteoPares()
            Else
                Button1.Visible = False
            End If

        End If
    End Sub

    Private Sub TallasGEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcombocajas()
        lbltotalpares.Text = totalPares
        consultarregistrosExistentes()
    End Sub

    Private Sub vwTallas_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles vwTallas.CellValueChanged
        segundaVez = False
        Dim id = vwTallas.GetRowCellValue(vwTallas.GetVisibleRowHandle(e.RowHandle), "ID")
            Dim pares = e.Value

        Dim resultado = objInstancia.EditarParesTallaCaja(id, pares)
        conteoPares()
        If resultado.Error <> 0 Then
            Utilerias.show_message(TipoMensaje.Advertencia, resultado.Mensaje)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tabla As New DataTable
        grdTallas.DataSource = tabla
        cbTalla.Enabled = True
        existenR = 0
    End Sub

    Private Sub TallasGEForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If salir = 1 Then
        Else
            confirmar.mensaje = "¿Está seguro de salir la informacion aun no esta correcta?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then

            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub conteoPares()

        Dim totalPares As Integer = 0
        Dim NumeroFilas = vwTallas.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1
            Dim pares = vwTallas.GetRowCellValue(vwTallas.GetVisibleRowHandle(index), "Pares")
            totalPares = totalPares + pares
            Next

        If totalPares = lbltotalpares.Text Then
            salir = 1
            If segundaVez <> True Then
                Utilerias.show_message(TipoMensaje.Exito, "Todos los pares ya tienen sus tallas")
            End If
        ElseIf totalPares > lbltotalpares.Text Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Exediste la cantidad de pares de la caja")
            salir = 0
        ElseIf totalPares < lbltotalpares.Text Then
            salir = 0
        End If


    End Sub

End Class