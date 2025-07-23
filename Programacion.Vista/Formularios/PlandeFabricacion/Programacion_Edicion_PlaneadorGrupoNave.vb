Imports Programacion.Negocios
Imports Tools

Public Class Programacion_Edicion_PlaneadorGrupoNave
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Public Grupo As String = String.Empty

    Private Sub Programacion_Edicion_PlaneadorGrupoNave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPlaneadores()
    End Sub

    Private Sub CargarPlaneadores()
        Dim objBU As New PlanFabricacionBU
        Dim dtObtienePlaneadores As New DataTable
        dtObtienePlaneadores = objBU.ObtienePlaneadoresPorGrupo(1, 0, "") '1 es para recuperar los planeadores y 0 por el id 

        If dtObtienePlaneadores.Rows.Count > 0 Then

            dtObtienePlaneadores.Rows.InsertAt(dtObtienePlaneadores.NewRow, 0)
            cmbPlaneador.DataSource = dtObtienePlaneadores
            cmbPlaneador.DisplayMember = "Planeador"
            cmbPlaneador.ValueMember = "PlaneadorID"
        Else
            advertencia.mensaje = "No existe información."
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New PlanFabricacionBU
        Dim PlaneadorID As Integer = 0


        Try
            If cmbPlaneador.SelectedValue <> 0 Then

                PlaneadorID = cmbPlaneador.SelectedValue

                objBU.ObtienePlaneadoresPorGrupo(2, PlaneadorID, Grupo)

                exito.mensaje = "Datos actualizados correctamente."
                exito.ShowDialog()
                Me.Dispose()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class