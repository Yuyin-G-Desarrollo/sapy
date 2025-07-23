Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ReporteInventarioForm
    Public idNave As Integer = 0
    Dim adv As New AdvertenciaForm

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        imprimirReporte(dtpFechaInicio.Value)
    End Sub
    Public Sub imprimirReporte(fecha As Date)
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New InventarioBU
        Dim list As New List(Of Integer)
        Dim dtLista As New DataTable("dtInventario")
        Try
            Me.Cursor = Cursors.WaitCursor
            dtLista = obj.getInventarioXProveedor(idNave, fecha)
            For Each row As DataRow In dtLista.Rows
                row("total") = row("precio") * row("cantidad")
            Next
            If dtLista.Rows.Count > 0 Then
                dtLista.TableName = "dtInventario"
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("INVENTARIOXPROVEEDOR")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte.RegData(dtLista)
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("urlNave") = obj.getURLNave(idNave)
                reporte("semana") = obj.getNoSemana(dtpFechaInicio.Value)
                reporte("fecha") = dtpFechaInicio.Value
                reporte.Render()
                reporte.Show()
            Else
                adv.mensaje = "No existe información a mostrar."
                adv.ShowDialog()
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado. Detalle: " & ex.ToString
            adv.ShowDialog()
        End Try
    End Sub
End Class