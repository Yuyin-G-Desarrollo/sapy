Imports Tools

Public Class AgregarEditarTiposDeTiendaForm

    Public AgregarOModificar As Boolean
    Public IdTipoTienda As Int32
    Public Nombre As String
    Public activo As Boolean

    Private Sub AgregarEditarTiposDeTiendaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'validamos que sí presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If AgregarOModificar = False Then
            Dim objTipoTiendasBU As New Negocios.CatalogoTiposDeTiendaBU
            Dim TipoTiendas As New Entidades.CatalogoTiposDeTienda

            txtAgregarEditarTipoTiendaNombre.MaxLength = 50
            txtAgregarEditarTipoTiendaNombre.Text = Nombre

            If activo = True Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If
        End If
    End Sub

    Private Sub btnCancelarTipoTienda_Click(sender As Object, e As EventArgs) Handles btnCancelarTipoTienda.Click
        Me.Dispose()
    End Sub


    Private Sub btnGuardarTipoTienda_Click(sender As Object, e As EventArgs) Handles btnGuardarTipoTienda.Click
        '' Condicion para verificar si dara de alta o realizara una actualizacion a los datos
        If AgregarOModificar = True Then
            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtAgregarEditarTipoTiendaNombre.Text <> "" Then
                lblAgregarEditarTipoTiendaNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarTipoTiendaNombre.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim TiposTienda As New Entidades.CatalogoTiposDeTienda
                TiposTienda.PNombreTipoTienda = txtAgregarEditarTipoTiendaNombre.Text
                If rdoActivoSi.Checked = True Then
                    TiposTienda.PActivo = True
                ElseIf rdoActivoNo.Checked = True Then
                    TiposTienda.PActivo = False
                End If

                Dim objTipoTienda As New Negocios.CatalogoTiposDeTiendaBU
                objTipoTienda.GuardarTipoTienda(TiposTienda)

                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()
                Me.Close()
            End If

        Else ''entra al modo de modificar de la ventana

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtAgregarEditarTipoTiendaNombre.Text <> "" Then
                lblAgregarEditarTipoTiendaNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarTipoTiendaNombre.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                ''se valida que este todo bien para editar
                Dim TiposTIenda As New Entidades.CatalogoTiposDeTienda
                TiposTIenda.PNombreTipoTienda = txtAgregarEditarTipoTiendaNombre.Text
                TiposTIenda.PIdTipoTienda = IdTipoTienda

                If rdoActivoSi.Checked = True Then
                    TiposTIenda.PActivo = True
                ElseIf rdoActivoNo.Checked Then
                    TiposTIenda.PActivo = False
                End If

                Dim objTipoTiendaBU As New Negocios.CatalogoTiposDeTiendaBU
                objTipoTiendaBU.editarTipoTienda(TiposTIenda)
                Dim FormaExito As New Tools.ExitoForm
                FormaExito.mensaje = "Registro guardado"
                FormaExito.ShowDialog()
                Me.Close()
            End If

        End If
    End Sub


End Class