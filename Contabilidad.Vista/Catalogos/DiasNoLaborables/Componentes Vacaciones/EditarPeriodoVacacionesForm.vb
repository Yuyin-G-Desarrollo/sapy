Imports Tools

Public Class EditarPeriodoVacacionesForm
    Public idPeriodo As Integer
    Public anio As Integer
    Public fechaISS As Date
    Public fechaFSS As Date
    Public fechaIN As Date
    Public fechaFN As Date

    Private Sub EditarPeriodoVacacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcomboFechas()
        dtpFISS.Value = fechaISS
        dtpFFSS.Value = fechaFSS
        dtpFIN.Value = fechaIN
        dtpFFN.Value = fechaFN
        cmbAnio.SelectedIndex = anio
        bloquearFechas()
    End Sub

    Private Sub bloquearFechas()
        Try
            Dim ObjB2 As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
            Dim success = ObjB2.PerdiodoSSCerrado(dtpFISS.Value, dtpFFSS.Value, CInt(txtidpatron.Text))
            If success > 0 Then
                dtpFISS.Enabled = False
                dtpFFSS.Enabled = False
                lblm1.Visible = True
            End If
            Dim success2 = ObjB2.PerdiodoSSCerrado(dtpFIN.Value, dtpFFN.Value, CInt(txtidpatron.Text))
            If success2 > 0 Then
                lblm1.Visible = True
                dtpFIN.Enabled = False
                dtpFFN.Enabled = False
            End If



        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub



    Public Sub llenarcomboFechas()
        Dim valoresCombo As New System.Collections.Generic.Dictionary(Of Integer, String)
        Dim anioActual As Integer = Date.Now.Year

        For index = anioActual - 3 To anioActual + 4
            Dim anio As Integer = index + 1
            Dim fecha = Convert.ToString(anio)
            valoresCombo.Add(anio, fecha)
        Next
        cmbAnio.DisplayMember = "Value"
        cmbAnio.ValueMember = "Key"
        cmbAnio.DataSource = valoresCombo.ToArray

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim entidad As New Entidades.DiasNoLaborales
        If cmbAnio.Text <> dtpFISS.Value.Year And dtpFISS.Value.Year <> 1900 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text + " para la fecha inicial de vacaciones de semana santa.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If cmbAnio.Text <> dtpFFSS.Value.Year And dtpFFSS.Value.Year <> 1900 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text + " para la fecha final de vacaciones de semana santa.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If

        If cmbAnio.Text <> dtpFIN.Value.Year And dtpFIN.Value.Year <> 1900 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text + " para la fecha inicial de vacaciones de navidad.")
            lblN.ForeColor = Drawing.Color.Red
            Return
        Else
            lblN.ForeColor = Drawing.Color.Black
        End If
        'If cmbAnio.Text <> dtpFFN.Value.Year Then
        '    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text)
        '    lblN.ForeColor = Drawing.Color.Red
        '    Return
        'Else
        '    lblN.ForeColor = Drawing.Color.Black
        'End If

        If Date.Compare(dtpFISS.Value.ToShortDateString, dtpFIN.Value.ToShortDateString) > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de semana santa no puede ser mayor a la de navidad.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If Date.Compare(dtpFFSS.Value.ToShortDateString, dtpFFN.Value.ToShortDateString) > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de semana santa no puede ser mayor a la de navidad.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If Date.Compare(dtpFISS.Value.ToShortDateString, dtpFFSS.Value.ToShortDateString) > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor que la fin.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If Date.Compare(dtpFIN.Value.ToShortDateString, dtpFFN.Value.ToShortDateString) > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor que la fin.")
            lblN.ForeColor = Drawing.Color.Red
            Return
        Else
            lblN.ForeColor = Drawing.Color.Black
        End If
        entidad.FechaISS = dtpFISS.Value
        entidad.FechaFSS = dtpFFSS.Value
        entidad.FechaIN = dtpFIN.Value
        entidad.FechaFN = dtpFFN.Value
        entidad.ID_Dia = txtidpatron.Text
        entidad.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        insertarPeriodo(entidad)
    End Sub
    Private Sub insertarPeriodo(ByVal entidad As Entidades.DiasNoLaborales)

        Try
            Dim ObjB2 As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
            Dim success = ObjB2.EditarVacaciones(entidad)
            If success.Resp > 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                Me.Close()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class