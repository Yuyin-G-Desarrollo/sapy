Imports Framework
Imports Entidades
Imports Produccion.Entidades
Imports Tools

Public Class ResumenInventarioProcesoForm

    Dim objUsuarioSesion As Usuarios

    Private Sub ResumenInventarioProcesoForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitComps()
    End Sub

    Public Sub InitComps()

        objUsuarioSesion = SesionUsuario.UsuarioSesion

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)
        cmbDepartamento = Controles.ComboDepartamentosSegunNave(cmbDepartamento, cmbNave.SelectedValue)

        dtpFechaProgramacionDe.Value = Now.Date
        dtpFechaProgramacionA.Value = Now.Date

    End Sub

    Private Sub cmbNave_Validated(sender As Object, e As System.EventArgs) Handles cmbNave.Validated
        cmbDepartamento.DataSource = Nothing
        cmbDepartamento.Items.Clear()
        cmbDepartamento = Controles.ComboDepartamentosSegunNave(cmbDepartamento, CInt(cmbNave.SelectedValue))
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        Cursor.Current = Cursors.WaitCursor
        InitComps()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        Cursor.Current = Cursors.WaitCursor
        If ValidarFormulario() Then
            ConsultarInventarioEnProceso()
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Function ValidarFormulario() As Boolean
        Dim Aviso As New AvisoForm

        ValidarFormulario = True

        If cmbNave.SelectedIndex <= 0 Then
            Aviso.mensaje = "Es necesario seleccionar una Nave."
            Aviso.ShowDialog()
            Aviso.Close()
            ValidarFormulario = False
        End If

        If dtpFechaProgramacionDe.Value > dtpFechaProgramacionA.Value Then
            Aviso.mensaje = "La Fecha Inicial debe ser mayor a la Fecha Final."
            Aviso.ShowDialog()
            Aviso.Close()
            ValidarFormulario = False
        End If

        Aviso = Nothing

    End Function

    Private Sub ConsultarInventarioEnProceso(Optional ByVal ExpPDF As Boolean = False, Optional ByVal ExpEXCEL As Boolean = False)
        'Mandar Imprimir
        Dim frmVistaPrevia As New ReportesVistaPreviaForm
        Dim vReporte As New rptResumenInventarioProceso

        With frmVistaPrevia
            If .Imprimir(vReporte, "@Nave|@FechaIni|@FechaFin|@Usuario", cmbNave.SelectedValue & "|" & FormatDateTime(dtpFechaProgramacionDe.Value, DateFormat.ShortDate) & "|" & FormatDateTime(dtpFechaProgramacionA.Value, DateFormat.ShortDate) & "|" & objUsuarioSesion.PUserUsername.ToUpper, "Entero|Fecha|Fecha|Cadena", ExpPDF, ExpEXCEL) Then
                .ShowDialog()
                .Close()
            End If
        End With

        frmVistaPrevia = Nothing
    End Sub

    Private Sub btnExpPDF_Click(sender As System.Object, e As System.EventArgs) Handles btnExpPDF.Click
        Cursor.Current = Cursors.WaitCursor
        If ValidarFormulario() Then
            ConsultarInventarioEnProceso(True)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnExpExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExpExcel.Click
        Cursor.Current = Cursors.WaitCursor
        If ValidarFormulario() Then
            ConsultarInventarioEnProceso(, True)
        End If
        Cursor.Current = Cursors.Default
    End Sub
End Class