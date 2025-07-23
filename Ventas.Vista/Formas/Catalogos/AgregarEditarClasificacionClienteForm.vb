Imports Tools

Public Class AgregarEditarClasificacionClienteForm

    Public altasOCambios As Boolean
    Public IdClasificacion As String
    Public Nombre As String
    Public activo As Boolean

    Private Sub AgregarEditarClasificacionClienteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtIDAgregarEditarClasificacionCliente.MaxLength = 1
        txtNombreAgregarEditarClasificacionCliente.MaxLength = 20

        'validamos que sí presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If altasOCambios = False Then
            Dim objClasificacionBU As New Negocios.CatalogoClasificacionClienteBU
            Dim Clasificacion As New Entidades.CatalogoClasificacionesCliente

            txtIDAgregarEditarClasificacionCliente.MaxLength = 1
            txtIDAgregarEditarClasificacionCliente.Enabled = False
            txtIDAgregarEditarClasificacionCliente.Text = IdClasificacion

            txtNombreAgregarEditarClasificacionCliente.MaxLength = 20
            txtNombreAgregarEditarClasificacionCliente.Text = Nombre

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
        If altasOCambios = True Then

            Dim objClasificacion As New Negocios.CatalogoClasificacionClienteBU
            Dim Existe As New Entidades.CatalogoClasificacionesCliente
            Existe = objClasificacion.ValidarId(txtIDAgregarEditarClasificacionCliente.Text)

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtNombreAgregarEditarClasificacionCliente.Text <> "" Then
                lblNombreAgregarEditarClasificacionCliente.ForeColor = Color.Black
            Else
                lblNombreAgregarEditarClasificacionCliente.ForeColor = Color.Red
                vacios = True
            End If

            If txtIDAgregarEditarClasificacionCliente.Text <> "" Then
                lblIDAgregarEditarClasificacionCliente.ForeColor = Color.Black
            Else
                lblIDAgregarEditarClasificacionCliente.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()

            ElseIf Existe.PNombre <> "" Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "El ID ya existe, por favor ingresa uno diferente"
                FormularioError.ShowDialog()

            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim Clasificacion As New Entidades.CatalogoClasificacionesCliente
                Clasificacion.PNombre = txtNombreAgregarEditarClasificacionCliente.Text
                Clasificacion.PIdClasificacion = txtIDAgregarEditarClasificacionCliente.Text
                If rdoActivoSi.Checked = True Then
                    Clasificacion.PActivo = True
                ElseIf rdoActivoNo.Checked = True Then
                    Clasificacion.PActivo = False
                End If

                Dim objClasificacionBU As New Negocios.CatalogoClasificacionClienteBU
                objClasificacion.GuardarClasificacionCliente(Clasificacion)

                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()

                Me.Close()
            End If

        Else ''entra al modo de modificar de la ventana

            'validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtNombreAgregarEditarClasificacionCliente.Text <> "" Then
                lblNombreAgregarEditarClasificacionCliente.ForeColor = Color.Black
            Else
                lblNombreAgregarEditarClasificacionCliente.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                'se valida que este todo bien para editar
                Dim Clasificacion As New Entidades.CatalogoClasificacionesCliente
                Clasificacion.PNombre = txtNombreAgregarEditarClasificacionCliente.Text
                Clasificacion.PIdClasificacion = IdClasificacion

                If rdoActivoSi.Checked = True Then
                    Clasificacion.PActivo = True
                ElseIf rdoActivoNo.Checked Then
                    Clasificacion.PActivo = False
                End If

                Dim objClasificacionBU As New Negocios.CatalogoClasificacionClienteBU
                objClasificacionBU.editarClasificacionCliente(Clasificacion)
                Dim FormaExito As New Tools.ExitoForm
                FormaExito.mensaje = "Registro guardado"
                FormaExito.ShowDialog()
                Me.Close()
            End If
        End If


    End Sub
End Class