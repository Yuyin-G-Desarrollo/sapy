Imports Stimulsoft.Report

Public Class PanelFiltroReporte

    Private Sub PanelFiltroReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAnio.Maximum = Date.Now.Year + 1
        txtAnio.Value = Date.Now.Year
        txtSemanaInicio.Value = 1
        txtSemanaFin.Value = 52

        dtpFechaInicio.Value = Date.Parse("01-01-" + Date.Now.Year.ToString)
        dtpFechaFin.Value = Date.Parse("31-12-" + Date.Now.Year.ToString)

        LlenarCombos()

        rdbTodos.Checked = True
    End Sub

    Private Sub LlenarCombos()
        Dim items As String() = {"NORMAL", "DETALLADO"}

        cmbTipoReporte.DataSource = items

        cmbTipoReporte.SelectedIndex = 0
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Try
            Cursor = Cursors.WaitCursor
            Imprimir()
            Cursor = Cursors.Default
        Catch ex As Exception
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ha ocurrido un error al generar el reporte.")
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Imprimir()
        Dim seleccionPestania As Integer = 1
        Dim objBU As New Negocios.FacturacionAnticipadaCoppelBU
        Dim dtPedidos As New DataTable
        Dim dsPedidosReporte As New DataSet("Datos")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim fechaInicio As DateTime
        Dim fechaFin As DateTime
        Dim anio As Integer
        Dim semanaInicio As Integer
        Dim semanaFin As Integer
        Dim tipoReporte As Boolean
        Dim tipoPedidos As Integer

        If tbcPanelFiltro.SelectedTab Is tbpSemana Then
            seleccionPestania = 2
            anio = txtAnio.Value
            semanaInicio = txtSemanaInicio.Value
            semanaFin = txtSemanaFin.Value

        End If

        fechaInicio = dtpFechaInicio.Value
        fechaFin = dtpFechaFin.Value
        tipoReporte = cmbTipoReporte.SelectedIndex

        For Each Ctrl As RadioButton In grpPedidos.Controls
            If Ctrl.Checked Then tipoPedidos = Ctrl.TabIndex + 1
        Next

        dtPedidos = objBU.ObtenerInformacionReportePlaneacion(seleccionPestania, tipoReporte, tipoPedidos, anio, semanaInicio, semanaFin, fechaInicio, fechaFin)

        dtPedidos.TableName = "dtPedidos"
        dsPedidosReporte.Tables.Add(dtPedidos)

        If tipoReporte = 0 Then
            EntidadReporte = objReporte.LeerReporteporClave("VTAS_REPTE_PLAN_ENTG_COPPEL_NORMAL")
        Else
            EntidadReporte = objReporte.LeerReporteporClave("VTAS_REPTE_PLAN_ENTG_COPPEL_DETALLADO")
        End If


        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport

        reporte.Load(archivo)
        reporte.Compile()
        reporte.Dictionary.Clear()
        reporte("usuarioGeneraReporte") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        reporte("urlImagenNave") = "http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG"
        reporte("username") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

        reporte.RegData(dsPedidosReporte)
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub txtSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtSemanaInicio.ValueChanged
        If txtSemanaFin.Value < txtSemanaInicio.Value Then
            txtSemanaFin.Value = txtSemanaInicio.Value
        End If
        txtSemanaFin.Minimum = txtSemanaInicio.Value
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    'Private Sub txtAnio_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    PermitirSoloNumeros(e)
    'End Sub

    'Private Sub txtSemanaInicio_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    PermitirSoloNumeros(e)
    'End Sub

    'Private Sub txtSemanaFin_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    PermitirSoloNumeros(e)
    'End Sub

    'Private Sub PermitirSoloNumeros(e As KeyPressEventArgs)
    '    If Not IsNumeric(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
    '        e.Handled = True
    '    End If
    'End Sub


End Class