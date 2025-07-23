Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization


Public Class AgregarEditarMotivoIncidenciaForm

    Public TipoMotivoId As Integer = -1
    Public CategoriaId As Integer = -1
    Public TipoMotivoIncidencia As String = String.Empty
    Public Activo As Boolean = True



    Private Sub AgregarEditarMotivoIncidenciaForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarCategorias()
        If TipoMotivoId >= 0 Then
            txtNombreMotivoIncidencia.Text = TipoMotivoIncidencia.Trim.ToUpper()
            If Activo = True Then
                rdoSi.Checked = True
                rdoNo.Checked = False
            Else
                rdoSi.Checked = False
                rdoNo.Checked = True
            End If
            lblActivo.Visible = True
            rdoNo.Visible = True
            rdoSi.Visible = True

            If CategoriaId >= 0 Then

                cmbCategoria.SelectedValue = CategoriaId
            End If
        Else
            rdoSi.Checked = True
            rdoNo.Checked = False
            txtNombreMotivoIncidencia.Text = String.Empty

            lblActivo.Visible = False
            rdoNo.Visible = False
            rdoSi.Visible = False
        End If

    End Sub


    Private Sub CargarCategorias()
        Dim objCategoria As New Ventas.Negocios.CatalogoCategoriaMotivoIncidenciaBU

        Dim Tabla_ListadoParametros As DataTable
        Tabla_ListadoParametros = objCategoria.ListaCategoriasMotivosIncidencias(True) ' Mostrar las categoriasActivas
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        With cmbCategoria
            .DataSource = Tabla_ListadoParametros
            .DisplayMember = "Categoria"
            .ValueMember = "CategoriaID"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Function ValidacionCamposCapturados() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(txtNombreMotivoIncidencia.Text) = True Then
            Resultado = False
            lblMotivoIncidencia.ForeColor = Color.Red
        Else
            lblMotivoIncidencia.ForeColor = Color.Black
        End If

        If cmbCategoria.SelectedIndex = 0 Then
            Resultado = False
            lblCategoria.ForeColor = Color.Red
        Else
            lblCategoria.ForeColor = Color.Black
        End If

        Return Resultado
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objCategoria As New Ventas.Negocios.CatalogoMotivosIncidenciaBU
        Dim objMotivoEntidad As New Entidades.CatalogoMotivosIncidencias


        If ValidacionCamposCapturados() = False Then
            show_message("Advertencia", "Los campos en rojo son obligatorios")
            Return
        End If

        objMotivoEntidad.Activo = rdoSi.Checked
        objMotivoEntidad.CategoriaID = cmbCategoria.SelectedValue
        objMotivoEntidad.Motivo = txtNombreMotivoIncidencia.Text.Trim()

        If TipoMotivoId >= 0 Then
            objMotivoEntidad.MotivoIncidenciaID = TipoMotivoId
            objMotivoEntidad.UsuarioModificoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objCategoria.EditarMotivoIncidencia(objMotivoEntidad)
            show_message("Exito", "Se han realizado los cambios en el motivo de incidencia")
        Else
            objMotivoEntidad.UsuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objCategoria.AltaMotivoIncidencia(objMotivoEntidad)
            show_message("Exito", "Se ha registrado un nuevo motivo de incidencia")
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