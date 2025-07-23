Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_AsignarPlaneador_GrupoNave
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm

    Private Sub Programacion_AsignarPlaneador_GrupoNave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInformacion()
    End Sub


    Private Sub CargarInformacion()
        Dim objBU As New PlanFabricacionBU
        Dim dtObtieneInfo As New DataTable

        Try
            vwPlaneadorPorGrupo.Columns.Clear()
            grdPlaneadorPorGrupo.DataSource = Nothing

            dtObtieneInfo = objBU.ObtienePlaneadorPorNave()

            If dtObtieneInfo.Rows.Count > 0 Then
                grdPlaneadorPorGrupo.DataSource = dtObtieneInfo
                DisenioGrid()
            Else
                advertencia.mensaje = "No hay datos para mostrar."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwPlaneadorPorGrupo.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            If col.FieldName = " " Then
                col.OptionsColumn.AllowEdit = True
            Else
                col.OptionsColumn.AllowEdit = False
            End If

        Next

        vwPlaneadorPorGrupo.Columns.ColumnByFieldName(" ").Width = 30
        vwPlaneadorPorGrupo.Columns.ColumnByFieldName("Planeador").Width = 260
        vwPlaneadorPorGrupo.Columns.ColumnByFieldName("Grupo").Width = 60

        DiseñoGrid.AlternarColorEnFilas(vwPlaneadorPorGrupo)
        vwPlaneadorPorGrupo.IndicatorWidth = 30
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim editarRegistroGrupo As New Programacion_Edicion_PlaneadorGrupoNave
        Dim NumeroFilas As Integer = 0
        Dim contadorRegistros As Integer = 0
        Dim Grupo As String = String.Empty

        If vwPlaneadorPorGrupo.DataRowCount > 0 Then

            NumeroFilas = vwPlaneadorPorGrupo.DataRowCount

            With vwPlaneadorPorGrupo
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        contadorRegistros += 1
                        Grupo = vwPlaneadorPorGrupo.GetRowCellValue(vwPlaneadorPorGrupo.GetVisibleRowHandle(index), "Grupo").ToString()
                    End If
                Next
            End With

            If contadorRegistros = 1 Then
                editarRegistroGrupo.Grupo = Grupo
                editarRegistroGrupo.ShowDialog()
                CargarInformacion()
            Else
                advertencia.mensaje = "Seleccione un solo registro para editar."
                advertencia.ShowDialog()
            End If

        End If

    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub vwPlaneadorPorGrupo_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwPlaneadorPorGrupo.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarInformacion()
    End Sub
End Class