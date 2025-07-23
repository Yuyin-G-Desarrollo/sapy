Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Windows.Forms
Imports System.Drawing

Public Class AltaNombreComercialForm

    Public NaveID As Integer = -1
    Public Dage_ProveedorId As Integer = -1

    Private Sub AltaNombreComercialForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'CargarPaises()
        'gridDisenoNave(grdNaves)
        'CargarNaves()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click

        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objNombreComercial As New Proveedores.BU.ProveedorBU
        Dim NombreComercialID As Integer = 0
        Dim DtNombreComercial As DataTable

        If ValidarInformacion() = True Then
            Dim mensajeConfirmacion As New ConfirmarForm
            mensajeConfirmacion.mensaje = "¿Está seguro de guardar? Posteriormente no se podrá realizar cambios."

            If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                DtNombreComercial = objNombreComercial.AltaNombreComercial(txtNombreComercial.Text.Trim(), txtPaginaWeb.Text.Trim(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "", -1)
                NombreComercialID = DtNombreComercial.Rows(0).Item("dage_proveedorid").ToString()
                Dage_ProveedorId = NombreComercialID

                ' objNombreComercial.InsertarRelacionNaveNombreComercial(NombreComercialID, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                If NombreComercialID <> -1 Then
                    objNombreComercial.InsertarRelacionNaveNombreComercial(NombreComercialID, NaveID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                    show_message("Exito", "Los datos han sido guardados")
                    Me.Close()

                Else
                    show_message("Advertencia", "Los campos con * no pueden estar vacíos, y se debe de tener seleccionado al menos una nave.")
                End If
            End If
           

        Else
            show_message("Advertencia", "Los campos con * no pueden estar vacíos, y se debe de tener seleccionado al menos una nave.")
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

    Private Function ValidarInformacion() As Boolean
        Dim Valido As Boolean = True
        Dim NaveSeleccionado As Integer = 0

        If txtNombreComercial.Text.Trim() = "" Then
            Valido = False
            lblNombreComercial.ForeColor = Drawing.Color.Red
        Else
            lblNombreComercial.ForeColor = Drawing.Color.Black
        End If

        Return Valido
    End Function

    Private Sub grdNaves_ClickCell(sender As Object, e As ClickCellEventArgs)
        If e.Cell.IsFilterRowCell = False Then
            If e.Cell.Column.Key = " " Then
                If e.Cell.Value Then
                    e.Cell.Value = False
                Else
                    e.Cell.Value = True
                End If
            End If
        End If
    End Sub

End Class