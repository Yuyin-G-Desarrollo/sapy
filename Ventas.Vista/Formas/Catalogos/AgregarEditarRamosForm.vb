Imports Tools

Public Class AgregarEditarRamosForm
    Public AgregarOModificar As Boolean
    Public IdForma As Int32
    Public Nombre As String
    Public NombreCorto As String
    Public activo As Boolean
    Public sicyID As Integer

    Private Sub AgregarEditarRamosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'validamos que sí presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If AgregarOModificar = False Then

            Dim objRamosBU As New Negocios.CatalogoRamosBU
            Dim Ramos As New Entidades.CatalogoRamos

            txtAgregarEditarRamoNombre.MaxLength = 30
            txtAgregarEditarRamoNombre.Text = Nombre

            txtAgregarEditarRamosNombreCorto.MaxLength = 10
            txtAgregarEditarRamosNombreCorto.Text = NombreCorto

            If activo = True Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If


        End If

        ListaRamos_Sicy()
        If sicyID > 0 Then
            cboxEditarAgregarRamoIDSICY.SelectedValue = sicyID
        End If


    End Sub

    Private Sub ListaRamos_Sicy()

        Try
            Dim CatalogoRamosBU As New Negocios.CatalogoRamosBU
            Dim tabla As New DataTable

            tabla = CatalogoRamosBU.ListaRamos_Sicy()
            tabla.Rows.InsertAt(tabla.NewRow, 0)

            cboxEditarAgregarRamoIDSICY.DataSource = tabla
            cboxEditarAgregarRamoIDSICY.DisplayMember = "Ramo"
            cboxEditarAgregarRamoIDSICY.ValueMember = "IdRamo"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCancelarRamo_Click(sender As Object, e As EventArgs) Handles btnCancelarRamo.Click
        Me.Dispose()
    End Sub


    Private Sub btnGuardarRamo_Click(sender As Object, e As EventArgs) Handles btnGuardarRamo.Click
        '' Condicion para verificar si dara de alta o realizara una actualizacion a los datos
        If AgregarOModificar = True Then
            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtAgregarEditarRamoNombre.Text <> "" Then
                lblAgregarEditarRamosNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarRamosNombre.ForeColor = Color.Red
                vacios = True
            End If

            If txtAgregarEditarRamosNombreCorto.Text <> "" Then
                lblAgregarEditarRamoNombreCorto.ForeColor = Color.Black
            Else
                lblAgregarEditarRamoNombreCorto.ForeColor = Color.Red
                vacios = True
            End If

            If IsNothing(cboxEditarAgregarRamoIDSICY.SelectedValue) Or cboxEditarAgregarRamoIDSICY.SelectedItem = 0 Then
                lblAgregarEditarRamoIDSICY.ForeColor = Color.Red
                vacios = True
            Else
                lblAgregarEditarRamoIDSICY.ForeColor = Color.Black
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim Ramos As New Entidades.CatalogoRamos
                Ramos.PRamoNombre = txtAgregarEditarRamoNombre.Text
                Ramos.PRamoNombreCorto = txtAgregarEditarRamosNombreCorto.Text
                Ramos.PRamoSicyID = cboxEditarAgregarRamoIDSICY.SelectedValue
                If rdoActivoSi.Checked = True Then
                    Ramos.PRamoActivo = True
                ElseIf rdoActivoNo.Checked = True Then
                    Ramos.PRamoActivo = False
                End If

                Dim objRamosBU As New Negocios.CatalogoRamosBU
                objRamosBU.guardarRamos(Ramos)

                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()


                Me.Close()
            End If

        Else ''entra al modo de modificar de la ventana

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If txtAgregarEditarRamoNombre.Text <> "" Then
                lblAgregarEditarRamosNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarRamosNombre.ForeColor = Color.Red
                vacios = True

                If txtAgregarEditarRamoNombre.Text <> "" Then
                    lblAgregarEditarRamoNombreCorto.ForeColor = Color.Black
                Else
                    lblAgregarEditarRamoNombreCorto.ForeColor = Color.Red
                    vacios = True
                End If
            End If

            If IsNothing(cboxEditarAgregarRamoIDSICY.SelectedValue) Or cboxEditarAgregarRamoIDSICY.SelectedIndex = 0 Then
                lblAgregarEditarRamoIDSICY.ForeColor = Color.Red
                vacios = True
            Else
                lblAgregarEditarRamoIDSICY.ForeColor = Color.Black
            End If


            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                ''se valida que este todo bien para editar
                Dim Ramos As New Entidades.CatalogoRamos
                Ramos.PRamoNombre = txtAgregarEditarRamoNombre.Text
                Ramos.PRamoNombreCorto = txtAgregarEditarRamosNombreCorto.Text
                Ramos.PRamoSicyID = cboxEditarAgregarRamoIDSICY.SelectedValue

                If rdoActivoSi.Checked = True Then
                    Ramos.PRamoActivo = True
                ElseIf rdoActivoNo.Checked Then
                    Ramos.PRamoActivo = False
                End If

                Ramos.PRamoId = IdForma

                Dim objRamosBU As New Negocios.CatalogoRamosBU
                objRamosBU.editarRamos(Ramos)
                Dim FormaExito As New Tools.ExitoForm
                FormaExito.mensaje = "Registro guardado"
                FormaExito.ShowDialog()

                Me.Close()
            End If
        End If
    End Sub
End Class