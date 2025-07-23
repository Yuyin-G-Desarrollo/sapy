Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization

Public Class AgregarEditarCategoriasMotivosIncidenciaForm

    Public CategoriaID As Integer = -1
    Public NombreCategoria As String = String.Empty
    Public CategoriaActiva As Boolean = True
    Private MotivoIncidenciaID As Integer = -1
    Private MotivoIncidencia As String = String.Empty
    Private Activo As Boolean = True



    Private Sub AgregarEditarCategoriasMotivosIncidenciaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtNombreCategoria.Text = String.Empty
        If CategoriaID >= 0 Then
            txtNombreCategoria.Text = NombreCategoria.Trim().ToUpper()
            rdoSi.Visible = True
            rdoNo.Visible = True
            lblActivo.Visible = True
            If CategoriaActiva = True Then
                rdoSi.Checked = True
                rdoNo.Checked = False
            Else
                rdoSi.Checked = False
                rdoNo.Checked = True
            End If
        Else
            lblActivo.Visible = True
            rdoSi.Checked = True
            rdoNo.Checked = False
            rdoSi.Visible = False
            rdoNo.Visible = False
            lblActivo.Visible = False
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ObjCategoria As New Ventas.Negocios.CatalogoCategoriaMotivoIncidenciaBU
        Dim objCategoriaEntidad As New Entidades.CategoriaMotivoIncidencia

        If String.IsNullOrEmpty(txtNombreCategoria.Text) = True Then
            lblNombreCategoria.ForeColor = Color.Red
            show_message("Advertencia", " El nombre de la categoría no puede estar vacío")
            Return
        Else
            lblNombreCategoria.ForeColor = Color.Black
        End If

        objCategoriaEntidad.Categoria = txtNombreCategoria.Text.Trim()
        objCategoriaEntidad.Activo = rdoSi.Checked
        If CategoriaID >= 0 Then
            objCategoriaEntidad.CategoriaID = CategoriaID
            objCategoriaEntidad.UsuarioNModificoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjCategoria.EditarCategoria(objCategoriaEntidad)
            show_message("Exito", "Se ha modificado la categoría")

        Else

            objCategoriaEntidad.UsuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjCategoria.AltaCategoria(objCategoriaEntidad)
            show_message("Exito", "Se ha creado la nueva categoría")
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

End Class