Imports Tools

Public Class AgregarEditarMaterialesForm

    Public idMaterial As Integer
    Public idTipo As Integer
    Public tipo As String
    Public material As String
    Public activo As Boolean
    Public estado As Boolean

    Private Sub AgregarEditarMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Llenamos el combo con los datos de los tipos de materiales
        ComboTipoMateriales(cboMaterialesMercadotecniaTipo)
        cboMaterialesMercadotecniaTipo.SelectedIndex = cboMaterialesMercadotecniaTipo.FindStringExact(tipo)
        TxtAgregarEditarMaterialesNombre.MaxLength = 50

        'validamos que si presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If estado = False Then

            Dim objMaterialesMercadotecnia As New Negocios.CatalogoMaterialesMercadotecniaBU
            Dim MaterialesMercadotecnia As New Entidades.CatalogoMaterialesMercadotecnia

            TxtAgregarEditarMaterialesNombre.Text = material
            If activo = True Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If

        End If
    End Sub

    ''Funcion que recoge los datos par allenar el combobox
    Public Shared Function ComboTipoMateriales(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoMateriales = New ComboBox
        ComboTipoMateriales = ComboEntrada
        Dim tablaMateriales As New List(Of Entidades.TipoMaterialesMercadotecnia)
        Dim objMaterialesMercadotecniBU As New Negocios.CatalogoMaterialesMercadotecniaBU
        tablaMateriales = objMaterialesMercadotecniBU.ListaTipoMateriales()

        tablaMateriales.Insert(0, New Entidades.TipoMaterialesMercadotecnia)
        If tablaMateriales.Count > 0 Then
            ComboTipoMateriales.DataSource = tablaMateriales
            ComboTipoMateriales.DisplayMember = "PtipoMaterial"
            ComboTipoMateriales.ValueMember = "PidtipoMaterial"
        End If
   


    End Function


    Private Sub btnCancelarMaterial_Click(sender As Object, e As EventArgs) Handles btnCancelarMaterial.Click
        Me.Dispose()
    End Sub


    Private Sub btnGuardarDia_Click(sender As Object, e As EventArgs) Handles btnGuardarDia.Click

        '' Condicion para verificar si dara de alta o realizara una actualizacion a los datos
        If estado = True Then

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If TxtAgregarEditarMaterialesNombre.Text <> "" Then
                lblAgregarEditarMaterialesNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarMaterialesNombre.ForeColor = Color.Red
                vacios = True
            End If

            If cboMaterialesMercadotecniaTipo.SelectedValue = 0 Then
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim MaterialesMercadotecnia As New Entidades.CatalogoMaterialesMercadotecnia

                MaterialesMercadotecnia.PmameNombre = TxtAgregarEditarMaterialesNombre.Text
                MaterialesMercadotecnia.PmameTipoId = cboMaterialesMercadotecniaTipo.SelectedValue


                If rdoActivoSi.Checked = True Then
                    MaterialesMercadotecnia.Pmameactivo = True
                Else
                    MaterialesMercadotecnia.Pmameactivo = False
                End If



                Dim objMaterialesMercadotecniaBU As New Negocios.CatalogoMaterialesMercadotecniaBU
                objMaterialesMercadotecniaBU.guardarMateriales(MaterialesMercadotecnia)

                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()


                Me.Close()
            End If

        Else ''entra al modo de modificar de la ventana

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If TxtAgregarEditarMaterialesNombre.Text <> "" Then
                lblAgregarEditarMaterialesNombre.ForeColor = Color.Black
            Else
                lblAgregarEditarMaterialesNombre.ForeColor = Color.Red
                vacios = True
            End If

            If cboMaterialesMercadotecniaTipo.SelectedValue = 0 Then
                vacios = True
            End If


            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                ''se valida que este todo bien para editar
                Dim Materiales As New Entidades.CatalogoMaterialesMercadotecnia
                Materiales.PmameNombre = TxtAgregarEditarMaterialesNombre.Text
                Materiales.PmameTipoId = cboMaterialesMercadotecniaTipo.SelectedValue

                If rdoActivoSi.Checked = True Then
                    Materiales.Pmameactivo = True
                Else
                    Materiales.Pmameactivo = False
                End If

                Materiales.PmameID = idMaterial

                Dim objMaterialesMBU As New Negocios.CatalogoMaterialesMercadotecniaBU
                objMaterialesMBU.editarMateriales(Materiales)
                Dim FormaExito As New Tools.ExitoForm
                FormaExito.mensaje = "Registro guardado"
                FormaExito.ShowDialog()

                Me.Close()
            End If

        End If



    End Sub
End Class