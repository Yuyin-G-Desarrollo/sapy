Imports System.Drawing
Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Tools.Utilerias

Public Class FiltroOperadoresAlmacenForm

    Public listaParametroID As Integer = 0
    Public todos As Integer

    Public Sub poblar_gridListadoParametros()

        grdDocumentos.DataSource = Nothing

        Dim objBU As New Negocios.AdministradorDocumentosBU
        Dim Tabla_ListadoParametros As New DataTable

        If todos = 0 Then
            Tabla_ListadoParametros = objBU.ConsultarOperadores()
            grdDocumentos.DataSource = Tabla_ListadoParametros
        Else
            Tabla_ListadoParametros = objBU.ConsultarTodosLosOperadores()
            grdDocumentos.DataSource = Tabla_ListadoParametros
        End If



    End Sub



    Private Sub FiltroPatronesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblar_gridListadoParametros()
        DiseñoGrid.DiseñoBaseGrid(vwDocumentos)
        vwDocumentos.OptionsView.ColumnAutoWidth = True
        DiseñoGrid.EstiloColumna(vwDocumentos, "Parámetro", "Parámetro", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwDocumentos, " ", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, False, Nothing, "{0:N0}")
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim NumeroFilas = vwDocumentos.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                FilasSeleccionadas += 1
                documentosSeleccionados = documentosSeleccionados & "," & vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(index), "Parámetro")
            End If
        Next
        If FilasSeleccionadas > 1 Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Solo puedes seleccionar un operador")
        Else
            listaParametroID = vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(vwDocumentos.GetSelectedRows(0)), "Parámetro")
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class