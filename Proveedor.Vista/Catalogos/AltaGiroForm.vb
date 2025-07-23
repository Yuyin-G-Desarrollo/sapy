Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing

Public Class AltaGiroForm

    Public GiroID As Integer = -1
    Public Giro As String = String.Empty

    Private Sub AltaGiroForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim DTInformacionGiro As DataTable
        Dim objBU As New Proveedores.BU.ClasificacionGiroBU
        Dim EsActivo As Boolean = False

        If GiroID <> -1 Then
            lblTitulo.Text = "Edición Giro"
            Me.Text = "Edición Giro"
            txtGiro.Enabled = False
            txtGiro.Text = Giro.Trim()
            DTInformacionGiro = objBU.ConsultaInformacionGiro(GiroID)
            If DTInformacionGiro.Rows.Count > 0 Then
                EsActivo = CBool(DTInformacionGiro.Rows(0).Item("girp_activo"))
                If EsActivo = True Then
                    rdoSi.Checked = True
                    rdoNo.Checked = False
                Else
                    rdoNo.Checked = True
                    rdoSi.Checked = False
                End If

            End If
        Else

            rdoSi.Enabled = False
            rdoNo.Enabled = False
            rdoSi.Checked = True
            rdoNo.Checked = False
        End If

    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Proveedores.BU.ClasificacionGiroBU()
        Dim DTGiro As DataTable

        Dim mensajeConfirmacion As New ConfirmarForm

        If txtGiro.Text.Trim = String.Empty Then
            lblGiro.ForeColor = Drawing.Color.Red
            show_message("Advertencia", "El campo de giro no puede estar vacío")
        Else
            lblGiro.ForeColor = Drawing.Color.Black
            DTGiro = objBU.BuscarGiro(txtGiro.Text.Trim(), GiroID)

            If DTGiro.Rows.Count > 0 Then
                show_message("Advertencia", "Ya existe un giro con el mismo nombre")

            Else

                If GiroID = -1 Then
                    mensajeConfirmacion.mensaje = "¿Está seguro de dar de alta el giro, ya no se podrán realizar cambios?"
                Else
                    mensajeConfirmacion.mensaje = "¿Está seguro de guardar los cambios?"
                End If

                If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If GiroID = -1 Then
                        objBU.InsertarGiro(txtGiro.Text.Trim(), rdoSi.Checked, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    Else
                        objBU.EditarGiro(GiroID, txtGiro.Text.Trim(), rdoSi.Checked, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    End If
                    show_message("Exito", "Se han guardado los cambios ")
                    Me.Close()

                End If

            End If



           
        End If

    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function
End Class