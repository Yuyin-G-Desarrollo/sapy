Imports System.Drawing
Imports System.Windows.Forms
Imports Proveedores.BU
Imports Tools

Public Class Proveedor_AltaEdicion_CatalogoRetenciones
    Dim confirmar As New ConfirmarForm
    Dim objBU As New CatalogoRetencionesBU
    Public chSI As Integer = 0
    Public RetencionID As Integer = 0

    Private Sub Proveedor_AltaEdicion_CatalogoRetenciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If chSI = 1 Then rdSI.Checked = True
        txtDescripcion.Select()
        txtDescripcion.Properties.CharacterCasing = CharacterCasing.Upper
        If RetencionID <> 0 Then ObtenerDatosRetencion()
    End Sub

    Private Sub ObtenerDatosRetencion()
        Dim dtRetencion As New DataTable
        Dim activo As Integer = 0

        dtRetencion = objBU.ObtenerRetenciones(RetencionID)
        If dtRetencion.Rows.Count > 0 Then
            txtDescripcion.Text = dtRetencion.Rows(0).Item("Descripción")
            cmbBase.Text = dtRetencion.Rows(0).Item("Base")
            txtPorcentaje.Text = dtRetencion.Rows(0).Item("Porcentaje")
            activo = dtRetencion.Rows(0).Item("Activo")

            If activo = 1 Then rdSI.Checked = True Else rdNo.Checked = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtRetencion As New DataTable
        Dim descripcion, base, porcentaje, activo

        If ValidaCampos() = True Then
            descripcion = txtDescripcion.Text
            base = cmbBase.Text
            porcentaje = txtPorcentaje.Text

            If rdSI.Checked = True Then activo = 1 Else activo = 0

            confirmar.mensaje = "¿Está seguro de guardar la información?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dtRetencion = objBU.InsertaEditaRetenciones(descripcion, base, porcentaje, RetencionID, activo)
                Tools.MostrarMensaje(Mensajes.Success, "Datos guardados correctamente.")
                Me.Close()
            End If
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Llene los campos faltantes.")
        End If
    End Sub

    Private Function ValidaCampos()
        Dim Resultado As Boolean = True

        If txtDescripcion.Text = "" Then
            Resultado = False
            lblDescripcion.ForeColor = Color.Red
        Else
            lblDescripcion.ForeColor = Color.Black
        End If

        If cmbBase.Text = "" Then
            Resultado = False
            lblbase.ForeColor = Color.Red
        Else
            lblbase.ForeColor = Color.Black
        End If

        If txtPorcentaje.Text = "" Then
            Resultado = False
            lblPorcentaje.ForeColor = Color.Red
        Else
            lblPorcentaje.ForeColor = Color.Black
        End If

        If rdSI.Checked = False And rdNo.Checked = False Then
            lblActivo.ForeColor = Color.Red
        Else
            lblActivo.ForeColor = Color.Black
        End If

        Return Resultado

    End Function

    Private Sub bntCerrar_Click(sender As Object, e As EventArgs) Handles bntCerrar.Click
        Me.Close()
    End Sub

End Class