Imports CrystalDecisions.Shared

Public Class MenuConcentradosForm
    Dim parametros As ParameterFields = New ParameterFields()
    Dim FechaInicio As ParameterField = New ParameterField()
    Dim FechaFin As ParameterField = New ParameterField()
    Dim LogotipoNave As ParameterField = New ParameterField()
    Dim NaveNombre As ParameterField = New ParameterField()
    Dim myDiscreteValue1 As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim myDiscreteValue As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim LogotipoRuta As ParameterDiscreteValue = New ParameterDiscreteValue()
    Dim VNaveNombre As ParameterDiscreteValue = New ParameterDiscreteValue()
    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If cmbNave.SelectedIndex > 0 Then
            FechaInicio.ParameterFieldName = "SemanaInicio"
            FechaFin.ParameterFieldName = "SemanaFin"
            LogotipoNave.ParameterFieldName = "NaveRuta"
            NaveNombre.ParameterFieldName = "NaveNombre"
            If cmbNave.SelectedValue = 2 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/YUYIN.JPG"
            ElseIf cmbNave.SelectedValue = 3 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/JEANS.JPG"
            ElseIf cmbNave.SelectedValue = 4 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/MERANO.JPG"
            ElseIf cmbNave.SelectedValue = 5 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/JEANS2.JPG"
            ElseIf cmbNave.SelectedValue = 43 Then
                LogotipoRuta.Value = rutaPublica & "LOGOTIPOS/GRUPOYUYIN.JPG"
            End If
            VNaveNombre.Value = cmbNave.Text
            myDiscreteValue.Value = dtpFechaInicio.Value.ToShortDateString
            myDiscreteValue1.Value = dtpFechaFin.Value.ToShortDateString

            FechaInicio.CurrentValues.Add(myDiscreteValue)
            FechaFin.CurrentValues.Add(myDiscreteValue1)
            LogotipoNave.CurrentValues.Add(LogotipoRuta)
            NaveNombre.CurrentValues.Add(VNaveNombre)

            parametros.Add(FechaInicio)
            parametros.Add(FechaFin)
            parametros.Add(LogotipoNave)
            parametros.Add(NaveNombre)


            If chkBajas.Checked = True Then
                Dim ReporteBajas As New ConcentradoBajasColaboradores
                Dim TablaResultados As New DataTable
                Dim objBU As New Negocios.FiniquitosBU
                Dim Visor As New VisorReportesEnTablas
                TablaResultados = objBU.ReporteIncidencias(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cmbNave.SelectedValue)
                ReporteBajas.SetDataSource(TablaResultados)
                Visor.ReporteViewer.ReportSource = ReporteBajas
                Visor.ReporteViewer.ParameterFieldInfo = parametros
                Visor.Show()
                Visor = New VisorReportesEnTablas
            End If

            If chkGratificaciones.Checked = True Then
                Dim dataSetReportes As New Vista.ConcentradoGratificacionesAnual
                Dim visor As New VisorReportesEnTablas
                ' NavesID = cmbNave.SelectedValue
                dataSetReportes.SetDataSource(ImprimirTablaGratificacionesConcentrado())
                Dim objTools As New Tools.ReportesVistaPrevia
                objTools.ImprimirYuyinERP(dataSetReportes, "", "", "", False, True)
                'visor.ReporteViewer.ReportSource = dataSetReportes
                'visor.ShowDialog()
                'dataSetReporte = New Vista.ReportesFiniquitos
                visor.ReporteViewer.ParameterFieldInfo = parametros
                visor.Close()
                visor = Nothing
                dataSetReportes = Nothing
            End If
            If chkAltas.Checked = True Then
                Dim ReporteAltas As New ConcentradoAltasColaboradores
                Dim TablaResultados As New DataTable
                Dim objBU As New Negocios.ColaboradoresBU
                Dim Visor As New VisorReportesEnTablas
                TablaResultados = objBU.ConcentradoAltas(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cmbNave.SelectedValue)
                Visor.ReporteViewer.ParameterFieldInfo = parametros
                ReporteAltas.SetDataSource(TablaResultados)
                Visor.ReporteViewer.ReportSource = ReporteAltas
                Visor.Show()
                Visor = New VisorReportesEnTablas
            End If
            If chkCumpleañeros.Checked = True Then
                Dim ReporteBajas As New ConcentradoCumpleaños
                Dim TablaResultados As New DataTable
                Dim objBU As New Negocios.ColaboradoresBU
                Dim Visor As New VisorReportesEnTablas
                TablaResultados = objBU.ConcentradoCumpleaños(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cmbNave.SelectedValue)
                Visor.ReporteViewer.ParameterFieldInfo = parametros
                ReporteBajas.SetDataSource(TablaResultados)
                Visor.ReporteViewer.ReportSource = ReporteBajas
                Visor.Show()
                Visor = New VisorReportesEnTablas
            End If
            If chkDeduccionesImss.Checked = True Then
                Dim ReporteBajas As New ConcentradoDeduccionesIMSS
                Dim TablaResultados As New DataTable
                Dim objBU As New Negocios.ColaboradoresBU
                Dim Visor As New VisorReportesEnTablas
                TablaResultados = objBU.ConcentradoIMSS(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cmbNave.SelectedValue)
                Visor.ReporteViewer.ParameterFieldInfo = parametros
                ReporteBajas.SetDataSource(TablaResultados)
                Visor.ReporteViewer.ReportSource = ReporteBajas
                Visor.Show()
                Visor = New VisorReportesEnTablas
            End If
            If chkDeducExtr.Checked = True Then
                Dim ReporteBajas As New ConcentradoDeduccionesExtraordinarias
                Dim TablaResultados As New DataTable
                Dim objBU As New Negocios.ColaboradoresBU
                Dim Visor As New VisorReportesEnTablas
                TablaResultados = objBU.ConcentradoDeduccionesExtraordinarias(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, cmbNave.SelectedValue)
                Visor.ReporteViewer.ParameterFieldInfo = parametros
                ReporteBajas.SetDataSource(TablaResultados)
                Visor.ReporteViewer.ReportSource = ReporteBajas
                Visor.Show()
                Visor = New VisorReportesEnTablas
            End If
        End If
    End Sub

    Public Function ImprimirTablaGratificacionesConcentrado() As DataTable
        Dim ObjBu As New Negocios.IncentivosBU
        Dim DataSetIncentivos As New DataTable
        DataSetIncentivos = ObjBu.ConcentradoAnualGratificaciones(cmbNave.SelectedValue)



        'Dim contador As New Int32
        'contador = DataSetIncentivos.Rows.Count
        Return DataSetIncentivos
    End Function

    Private Sub MenuConcentradosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub
End Class