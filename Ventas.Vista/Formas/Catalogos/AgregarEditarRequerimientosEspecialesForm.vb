Imports Tools

Public Class AgregarEditarRequerimientosEspecialesForm
    Public AgregarOModificar As Boolean
    Public Activo As Boolean
    Public IdRequerimiento As Int32
    Public IdTipo As Int32
    Public Nombre As String
    Public Tipo As String


    Private Sub AgregarEditarRequerimientosEspecialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Llenamos el combo con los datos de los tipos de materiales
        ComboTipoRequerimientos(cboTipoRequerimiento)
        TxtAgregarEditarNombreRequerimiento.MaxLength = 50

        'validamos que si presiono el boton de editar llene el cuadro de texto y seleccione el radiobutton
        If AgregarOModificar = False Then

            Dim objRequerimiento As New Negocios.CatalogoRequerimientosEspecialesBU
            Dim Requerimientos As New Entidades.CatalogoRequerimientosEspeciales

            TxtAgregarEditarNombreRequerimiento.Text = Nombre

            cboTipoRequerimiento.SelectedIndex = cboTipoRequerimiento.FindStringExact(Tipo)

            If Activo = True Then
                rdoActivoSi.Checked = True
            Else
                rdoActivoNo.Checked = True
            End If
        End If
    End Sub

    Public Function ComboTipoRequerimientos(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoRequerimientos = New ComboBox
        ComboTipoRequerimientos = ComboEntrada
        Dim TablaTipos As New List(Of Entidades.TipoRequerimientosEspeciales)
        Dim objRequerimientosBU As New Negocios.CatalogoRequerimientosEspecialesBU
        TablaTipos = objRequerimientosBU.ListaTipoRequerimientos()

        TablaTipos.Insert(0, New Entidades.TipoRequerimientosEspeciales)
        If TablaTipos.Count > 0 Then
            ComboTipoRequerimientos.DataSource = TablaTipos
            ComboTipoRequerimientos.DisplayMember = "PTipo"
            ComboTipoRequerimientos.ValueMember = "PIdTipo"
        End If

    End Function

    Private Sub btnCancelarRequerimiento_Click(sender As Object, e As EventArgs) Handles btnCancelarRequerimiento.Click
        Me.Dispose()
    End Sub

    Private Sub btnGuardarRequerimiento_Click(sender As Object, e As EventArgs) Handles btnGuardarRequerimiento.Click

        '' Condicion para verificar si dara de alta o realizara una actualizacion a los datos
        If AgregarOModificar = True Then

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If TxtAgregarEditarNombreRequerimiento.Text <> "" Then
                lblAgregarEditarNombreRequerimiento.ForeColor = Color.Black
            Else
                lblAgregarEditarNombreRequerimiento.ForeColor = Color.Red
                vacios = True
            End If

            If cboTipoRequerimiento.SelectedValue = 0 Then
                vacios = True
                lblAgregarEditarTipoRequerimiento.ForeColor = Color.Red
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                '' asignammos los valores a la clase de la capa entidad 
                Dim Requerimientos As New Entidades.CatalogoRequerimientosEspeciales

                Requerimientos.PNombre = TxtAgregarEditarNombreRequerimiento.Text
                Requerimientos.PIdTipo = cboTipoRequerimiento.SelectedValue


                If rdoActivoSi.Checked = True Then
                    Requerimientos.PActivo = True
                Else
                    Requerimientos.PActivo = False
                End If

                Dim objRequerimientoBU As New Negocios.CatalogoRequerimientosEspecialesBU
                objRequerimientoBU.GuardarRequerimiento(Requerimientos)

                Dim FormularioMensaje As New Tools.ExitoForm
                FormularioMensaje.mensaje = "Registro guardado"
                FormularioMensaje.ShowDialog()

                Me.Close()
            End If

        Else ''entra al modo de modificar de la ventana

            ''validar que los campos no estan vacios
            Dim vacios As Boolean = False
            If TxtAgregarEditarNombreRequerimiento.Text <> "" Then
                lblAgregarEditarNombreRequerimiento.ForeColor = Color.Black
            Else
                lblAgregarEditarNombreRequerimiento.ForeColor = Color.Red
                vacios = True
            End If
            

            If cboTipoRequerimiento.SelectedValue = 0 Then
                lblAgregarEditarTipoRequerimiento.ForeColor = Color.Red
                vacios = True
            End If

            If vacios Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos vacíos"
                FormularioError.ShowDialog()
            Else
                ''se valida que este todo bien para editar
                Dim Requerimientos As New Entidades.CatalogoRequerimientosEspeciales
                Requerimientos.PNombre = TxtAgregarEditarNombreRequerimiento.Text
                Requerimientos.PIdTipo = cboTipoRequerimiento.SelectedValue

                If rdoActivoSi.Checked = True Then
                    Requerimientos.PActivo = True
                Else
                    Requerimientos.PActivo = False
                End If

                Requerimientos.PIdRequerimiento = IdRequerimiento

                Dim objRequerimientoBU As New Negocios.CatalogoRequerimientosEspecialesBU
                objRequerimientoBU.ActualizarRequerimiento(Requerimientos)
                Dim FormaExito As New Tools.ExitoForm
                FormaExito.mensaje = "Registro guardado"
                FormaExito.ShowDialog()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub cboTipoRequerimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoRequerimiento.SelectedIndexChanged
       
    End Sub
End Class