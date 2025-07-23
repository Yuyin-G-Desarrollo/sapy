Imports Tools

Public Class AgregarEditarRutasForm

    Public IdRuta As Int32
    Public activo As Boolean
    Public nombre As String
    Public AgregarOModificar As Boolean


    Private Sub AgregarEditarRutasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'validamos que sí presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If AgregarOModificar = False Then
            Dim objRutasBu As New Negocios.CatalogoRutasBU
            Dim Ramos As New Entidades.CatalogoRutas

            txtAgregarEditarRutasNombre.MaxLength = 50
            txtAgregarEditarRutasNombre.Text = nombre

            If activo = True Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If
        End If
    End Sub

    Private Sub btnCancelarRuta_Click(sender As Object, e As EventArgs) Handles btnCancelarRuta.Click
        Me.Dispose()
    End Sub

    Private Sub btnGuardarRuta_Click(sender As Object, e As EventArgs) Handles btnGuardarRuta.Click
        '' Condicion para verificar si dara de alta o realizara una actualizacion a los datos
        If AgregarOModificar = True Then
            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtAgregarEditarRutasNombre.Text <> "" Then
                lblAgregarEditarRutasNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarRutasNombre.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim Rutas As New Entidades.CatalogoRutas
                Rutas.PNombreRuta = txtAgregarEditarRutasNombre.Text
                If rdoActivoSi.Checked = True Then
                    Rutas.PActivo = True
                ElseIf rdoActivoNo.Checked = True Then
                    Rutas.PActivo = False
                End If

                Dim objRutasBU As New Negocios.CatalogoRutasBU
                objRutasBU.GuardarRutas(Rutas)

                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()


                Me.Close()
            End If

        Else ''entra al modo de modificar de la ventana

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtAgregarEditarRutasNombre.Text <> "" Then
                lblAgregarEditarRutasNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarRutasNombre.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                ''se valida que este todo bien para editar
                Dim Rutas As New Entidades.CatalogoRutas
                Rutas.PNombreRuta = txtAgregarEditarRutasNombre.Text
                Rutas.PRutaId = IdRuta

                If rdoActivoSi.Checked = True Then
                    Rutas.PActivo = True
                ElseIf rdoActivoNo.Checked Then
                    Rutas.PActivo = False
                End If

                Dim objRutasBU As New Negocios.CatalogoRutasBU
                objRutasBU.editarRutas(Rutas)
                Dim FormaExito As New Tools.ExitoForm
                FormaExito.mensaje = "Registro guardado"
                FormaExito.ShowDialog()

                Me.Close()
            End If

        End If
    End Sub
End Class