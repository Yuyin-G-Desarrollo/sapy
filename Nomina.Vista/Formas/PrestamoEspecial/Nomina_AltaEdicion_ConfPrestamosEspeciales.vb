Imports Nomina.Negocios
Imports Tools

Public Class Nomina_AltaEdicion_ConfPrestamosEspeciales
    Public NaveID As Integer
    Public Accion As Integer
    Dim confirmar As New ConfirmarForm
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Public Concepto As String = ""

    Public PorcentajeCC As Integer = 0
    Public ConceptoID As Integer = 0
    Public Semanas As Integer = 0

    Private Sub Nomina_AltaEdicion_ConfPrestamosEspeciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Accion = 2 Then
            txtConcepto.Text = Concepto
            txtPorcentajeCC.Text = PorcentajeCC
            txtSemanas.Text = Semanas

        Else
            rdoActivoSi.Checked = True
            panelActivo.Enabled = False
            lblActivo.Enabled = False
        End If

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New ConsultarPrestamosBU
        Dim Concepto As String
        Dim Semanas As Integer

        Dim usuarioID As Integer
        Dim PorcentajeCC As Integer
        Dim Activo As Integer

        Try

            Concepto = txtConcepto.Text
            usuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            PorcentajeCC = txtPorcentajeCC.Text
            Semanas = txtSemanas.Text

            If rdoActivoSi.Checked = True Then
                Activo = 1
            Else
                Activo = 0
            End If

            confirmar.mensaje = "¿Desea actualizar los datos de configuración?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                objBU.InsertarConfPrestamosEspeciales(Concepto, NaveID, usuarioID, Accion, ConceptoID, Activo, PorcentajeCC, Semanas)
                exito.mensaje = "Se realizaron los cambios con éxito."
                exito.ShowDialog()
            Else
                advertencia.mensaje = "No se actualizaron los datos. Intente Nuevamente."
                advertencia.ShowDialog()
            End If

            Cursor = Cursors.Default
            Me.Close()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub


End Class