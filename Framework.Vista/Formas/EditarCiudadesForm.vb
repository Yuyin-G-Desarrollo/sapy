Imports Framework.Negocios

Public Class EditarCiudadesForm

    Dim seleccionestados, seleccionpais, CiudadID As Int32
    Dim seleleccionNombreCiudad As String

    Public Property ECiudadId As Int32
        Get
            Return CiudadID
        End Get
        Set(ByVal value As Int32)
            CiudadID = value
        End Set
    End Property

    Public Property ESeleccionpais As Int32
        Get
            Return seleccionpais
        End Get
        Set(ByVal value As Int32)
            seleccionpais = value
        End Set
    End Property

    Public Property ESeleccionestado As Int32
        Get
            Return seleccionestados
        End Get
        Set(ByVal value As Int32)
            seleccionestados = value
        End Set
    End Property

    Public Property EseleccionNombreCiudad As String
        Get
            Return seleleccionNombreCiudad
        End Get
        Set(ByVal value As String)
            seleleccionNombreCiudad = value
        End Set
    End Property

    Private Sub EditarCiudadesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbPais = Controles.ComboPaises(cmbPais)
        cmbPais.SelectedValue = seleccionpais
        cmbEstados = Controles.ComboEstados(cmbEstados)
        cmbEstados.SelectedValue = seleccionestados
        cmbEstados.SelectedValue = seleccionestados
        txtEditarNombreCiudad.Text = seleleccionNombreCiudad
        txtEditarNombreCiudad.MaxLength = 50

    End Sub



    Private Sub btnGuardarEdicionPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarEdicionPais.Click
        Dim vacios As Boolean = False
        If txtEditarNombreCiudad.Text <> "" Then
            lblActivoPaisAlta.ForeColor = Color.Black

        Else
            lblEditarNombreEstado.ForeColor = Color.Red
            vacios = True
        End If
        Dim ComboVacio As Boolean = False
        If cmbPais.SelectedIndex > 0 Then
            lblPais.ForeColor = Color.Black
            ComboVacio = False
        Else
            lblPais.ForeColor = Color.Red
            ComboVacio = True
        End If

        Dim ComboVacioEstados As Boolean = False
        If cmbEstados.SelectedIndex > 0 Then
            lblPais.ForeColor = Color.Black
            ComboVacioEstados = False
        Else
            lblPais.ForeColor = Color.Red
            ComboVacioEstados = True
        End If
        If (vacios = True) Or (ComboVacio = True) Or (ComboVacioEstados = True) Then
            Dim FormularioError As New ErroresForm
            FormularioError.mensaje = "Campos Vacios"
            FormularioError.Show()
        Else
            Dim Ciudad As New Entidades.Ciudades
            Ciudad.CNombre = txtEditarNombreCiudad.Text
            Ciudad.CActivo = rdoActivoSi.Checked
            Ciudad.CciudadId = CiudadID
            Dim estado As New Entidades.Estados
            If cmbEstados.SelectedIndex > 0 Then
                estado.EIDDEstado = CInt(cmbEstados.SelectedValue)


                Dim obCiudadBU As New CiudadesBU
                obCiudadBU.EditarCiudad(Ciudad, estado)
                Dim FormularioMensaje As New ExitoForm
                FormularioMensaje.mensaje = "Registro Modificado"
                FormularioMensaje.ShowDialog()
                Me.Close()
            End If
        End If
    End Sub



    Private Sub txtEditarNombreCiudad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEditarNombreCiudad.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelarEdicionPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarEdicionPais.Click
        Me.Close()

    End Sub
End Class