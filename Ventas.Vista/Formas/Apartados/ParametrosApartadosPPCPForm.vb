Imports Infragistics.Win.UltraWinGrid

Public Class ParametrosApartadosPPCPForm

    Public filtrosGenerarApartados As Entidades.FiltrosGeneracionApartadosPPCP
    Public ventanaOrigen As GeneracionApartadosPPCP_Form

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub btnActualizarDistribucion_Click(sender As Object, e As EventArgs) Handles btnActualizarDistribucion.Click
        Dim objBU As New Negocios.ApartadosBU
        Dim dtTablaResultado As New DataTable()
        Dim listaColumnas As New List(Of String)
        Cursor = Cursors.WaitCursor

        For Each col As UltraGridColumn In ventanaOrigen.grdDatosGenerarApartados.DisplayLayout.Bands(0).Columns
            listaColumnas.Add(col.Header.Caption)
        Next

        'Se agrego para que el inventario no dier negativos
        objBU.Replicacion_TmpdocenasPares()

        objBU.limpiarModificacionAnteriorRegenerarDistribucion()

        If listaColumnas.Contains("M3") Then
            For Each renglon As UltraGridRow In ventanaOrigen.grdDatosGenerarApartados.Rows
                If renglon.Cells("M3").Value.ToString() = "X" Then

                    filtrosGenerarApartados.PAtadoNON = If(CBool(renglon.Cells("OK_Normales").Value) And renglon.Cells("OK_Normales").Hidden = False, 1, 0)
                    filtrosGenerarApartados.PAtadoPAR = If(CBool(renglon.Cells("OK_Normales").Value) And renglon.Cells("OK_Normales").Hidden = False, 1, 0)
                    filtrosGenerarApartados.PAtadoPUNTO = If(CBool(renglon.Cells("OK_Punto").Value) And renglon.Cells("OK_Punto").Hidden = False, 1, 0)
                    filtrosGenerarApartados.PParesDestallados = If(CBool(renglon.Cells("OK_Destallados").Value) And renglon.Cells("OK_Destallados").Hidden = False, 1, 0)
                    filtrosGenerarApartados.PDestallarNormales = If(CBool(renglon.Cells("OK_AtadosDestalladosNormales").Value) And renglon.Cells("OK_AtadosDestalladosNormales").Hidden = False, 1, 0)
                    filtrosGenerarApartados.PDestallarPuntos = If(CBool(renglon.Cells("OK_AtadosDestalladosPunto").Value) And renglon.Cells("OK_AtadosDestalladosPunto").Hidden = False, 1, 0)

                    objBU.RegenerarDistribucionPartidasModificadasM3(filtrosGenerarApartados, Integer.Parse(renglon.Cells("PedidoDetalleId").Value), Integer.Parse(renglon.Cells("Nave").Value), Integer.Parse(renglon.Cells("ProgramaId").Value))
                End If

            Next
        End If

        filtrosGenerarApartados.PAtadoNON = If(chboxAtadosNon.Checked, 1, 0)
        filtrosGenerarApartados.PAtadoPAR = If(chboxAtadosPar.Checked, 1, 0)
        filtrosGenerarApartados.PAtadoPUNTO = If(chboxAtadosPunto.Checked, 1, 0)
        filtrosGenerarApartados.PParesDestallados = If(chboxParesDestallados.Checked, 1, 0)
        filtrosGenerarApartados.PDestallarNormales = If(chboxDestallarNormales.Checked, 1, 0)
        filtrosGenerarApartados.PDestallarPuntos = If(chboxDestallarPunto.Checked, 1, 0)

        objBU.RegenerarDistribucionPartidasModificadas(filtrosGenerarApartados)
        objBU.actualizarTotalesDistribucionPartidasPorGenerar()
        dtTablaResultado = objBU.seleccionarPartidasConDistribucion(2)
        ventanaOrigen.grdDatosGenerarApartados.DataSource = Nothing
        ventanaOrigen.chboxSeleccionarTodoAtadosNormalesCompletos.Checked = True
        ventanaOrigen.chboxSeleccionarTodoAtadosNormalesCompletos.Enabled = True
        ventanaOrigen.chboxSeleccionarTodoAtadosPuntoCompletos.Checked = True
        ventanaOrigen.chboxSeleccionarTodoAtadosPuntoCompletos.Enabled = True
        ventanaOrigen.chboxSeleccionarTodoParesDestallados.Checked = True
        ventanaOrigen.chboxSeleccionarTodoParesDestallados.Enabled = True
        ventanaOrigen.chboxSeleccionarTodoAtadosNormalesDestallar.Checked = True
        ventanaOrigen.chboxSeleccionarTodoAtadosNormalesDestallar.Enabled = True
        ventanaOrigen.chboxSeleccionarTodoAtadosPuntoDestallar.Checked = True
        ventanaOrigen.chboxSeleccionarTodoAtadosPuntoDestallar.Enabled = True

        ventanaOrigen.grdDatosGenerarApartados.DataSource = dtTablaResultado
        ventanaOrigen.gridPedidosDistribucionesDiseño(ventanaOrigen.grdDatosGenerarApartados, 1)
        ventanaOrigen.chboxMostrarPartidasSinInventario.Checked = True
        ventanaOrigen.tipoDistribucion = 1

        Cursor = Cursors.Default
        Me.Close()
        ventanaOrigen.WindowState = FormWindowState.Maximized
        ventanaOrigen.lblFechaUltimaDistribucion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
    End Sub

    Private Sub ParametrosApartadosPPCPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If filtrosGenerarApartados.PAtadoNON = 1 Then
            chboxAtadosNon.Checked = True
        Else
            chboxAtadosNon.Checked = False
        End If
        If filtrosGenerarApartados.PAtadoPAR = 1 Then
            chboxAtadosPar.Checked = True
        Else
            chboxAtadosPar.Checked = False
        End If
        If filtrosGenerarApartados.PAtadoPUNTO = 1 Then
            chboxAtadosPunto.Checked = True
        Else
            chboxAtadosPunto.Checked = False
        End If
        If filtrosGenerarApartados.PParesDestallados = 1 Then
            chboxParesDestallados.Checked = True
        Else
            chboxParesDestallados.Checked = False
        End If
        If filtrosGenerarApartados.PDestallarNormales = 1 Then
            chboxDestallarNormales.Checked = True
        Else
            chboxDestallarNormales.Checked = False
        End If
        If filtrosGenerarApartados.PDestallarPuntos = 1 Then
            chboxDestallarPunto.Checked = True
        Else
            chboxDestallarPunto.Checked = False
        End If
    End Sub
End Class