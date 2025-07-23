Public Class AgregarEditarCondicionesForm

    Public accion As String
    Public GuardarPolitica As Boolean
    Public AgregarOEditar As Boolean

    Public IdTipo As Integer
    Public NombreTipo As String
    Public ActivoTipo As Boolean

    Public IdCondicion As Integer
    Public NombreCondicion As String
    Public ActivoCondicion As Boolean

    Public IdCatalogo As Integer
    Public DescripcionCatalogo As String
    Public ActivoCatalogo As Boolean

    Public OpDefault As Boolean

    Private CamposVacios As Boolean
    Private Salio As Boolean

    Public Property PSalio As Boolean
        Get
            Return Salio
        End Get
        Set(value As Boolean)
            Salio = value
        End Set
    End Property




    Private Sub AgregarEditarCondicionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If accion = "Tipo" Then
            grpTipoCondicion.Visible = True
            grpCondicion.Visible = False
            grpCatalogoCondicion.Visible = False

            lblEncabezado.Text = "1. Tipo de Política"
            lblEncabezado.Location = New Point(179, 20)
            Me.Text = "1. Tipo de Política"
            txtTipoNombre.MaxLength = 50
            If AgregarOEditar = False Then
                txtTipoNombre.Text = NombreTipo
                If ActivoTipo Then
                    rdoTipoActivoSi.Checked = True
                Else
                    rdoTipoActivoNo.Checked = True
                End If
            End If

        ElseIf accion = "Condicion" Then
            ''System.Threading.Thread.Sleep(5000)
            ComboTipoCondiciones(cboCondicionTipo)
            cboCondicionTipo.SelectedIndex = cboCondicionTipo.FindStringExact(NombreTipo)

            grpTipoCondicion.Visible = False
            grpCondicion.Visible = True
            grpCatalogoCondicion.Visible = False

            lblEncabezado.Text = "2. Política"
            lblEncabezado.Location = New Point(242, 20)
            Me.Text = "2. Política"
            txtCondicionNombre.MaxLength = 60
            If AgregarOEditar = False Then
                txtCondicionNombre.Text = NombreCondicion
                If ActivoCondicion Then
                    rdoCondicionActivoSi.Checked = True
                Else
                    rdoCondicionActivoNo.Checked = True
                End If
            End If

        ElseIf accion = "Catalogo" Then
            ComboTipoCondiciones(cboTipoPolitica)
            cboTipoPolitica.SelectedIndex = cboTipoPolitica.FindStringExact(NombreTipo)

            ComboCondicionCatalogo(cboCatalogoCondicion)
            cboCatalogoCondicion.SelectedIndex = cboCatalogoCondicion.FindStringExact(NombreCondicion)


            grpTipoCondicion.Visible = False
            grpCondicion.Visible = False
            grpCatalogoCondicion.Visible = True

            lblEncabezado.Text = "3. Catálogo de la Política"
            lblEncabezado.Location = New Point(130, 20)
            Me.Text = "3. Catálogo de la Política"

            txtDescripcionCatalogo.MaxLength = 60
            If AgregarOEditar = False Then
                txtDescripcionCatalogo.Text = DescripcionCatalogo
                If ActivoCatalogo Then
                    rdoCatalogoActivoSi.Checked = True
                Else
                    rdoCatalogoActivoNo.Checked = True
                End If
            End If
        End If

    End Sub

    Private Sub GuardarEditarTipoCondiciones()

        CamposVacios = False
        If AgregarOEditar = True Then
            If txtTipoNombre.Text <> "" Then
                lblTipoNombre.ForeColor = Color.Black
            Else
                lblTipoNombre.ForeColor = Color.Red
                CamposVacios = True
            End If
            If CamposVacios = True Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos Vacios"
                FormularioError.StartPosition = FormStartPosition.CenterScreen
                FormularioError.StartPosition = FormStartPosition.CenterScreen
                FormularioError.ShowDialog()
            Else
                Dim TipoCodicion As New Entidades.CatalogoCondicionesTipo
                TipoCodicion.PNombre = txtTipoNombre.Text
                If rdoTipoActivoSi.Checked = True Then
                    TipoCodicion.PActivo = True
                Else
                    TipoCodicion.PActivo = False
                End If
                Dim objCondicionesBU As New Negocios.CatalogoCondicionesBU
                objCondicionesBU.altaTipo(TipoCodicion)
                Dim FormularioMensaje As New ExitoForm
                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.StartPosition = FormStartPosition.CenterScreen
                FormularioMensaje.ShowDialog()
                Me.Close()
            End If
        Else
            If txtTipoNombre.Text <> "" Then

                lblTipoNombre.ForeColor = Color.Black
            Else
                lblTipoNombre.ForeColor = Color.Red
                CamposVacios = True
            End If
            If CamposVacios Then
                Dim FormaError As New ErroresForm
                FormaError.mensaje = "Campos vacíos"
                FormaError.StartPosition = FormStartPosition.CenterScreen
                FormaError.ShowDialog()
            Else
                Dim edtarTipo As New Entidades.CatalogoCondicionesTipo
                edtarTipo.PNombre = txtTipoNombre.Text
                If rdoTipoActivoSi.Checked = True Then
                    edtarTipo.PActivo = True
                Else
                    edtarTipo.PActivo = False
                End If
                edtarTipo.PIdTipo = IdTipo
                Dim objEditarTipoBU As New Negocios.CatalogoCondicionesBU
                objEditarTipoBU.editarTipoCondiciones(edtarTipo)
                Dim FormaExito As New ExitoForm
                FormaExito.mensaje = "Registro Guardado"
                FormaExito.StartPosition = FormStartPosition.CenterScreen
                FormaExito.ShowDialog()
            End If
            Me.Close()
        End If
    End Sub

    Private Sub GuardarEditarCondiciones()
        
            CamposVacios = False
            If AgregarOEditar = True Then
                GuardarPolitica = True
                If txtCondicionNombre.Text <> "" Then
                    lblCondicionNombre.ForeColor = Color.Black
                Else
                    lblCondicionNombre.ForeColor = Color.Red
                    CamposVacios = True
                End If
                If CInt(cboCondicionTipo.SelectedValue) <> 0 Then
                    lblCondicionTipo.ForeColor = Color.Black
                Else
                    lblCondicionTipo.ForeColor = Color.Red
                    CamposVacios = True
                End If
                If CamposVacios = True Then
                    Dim FormularioError As New ErroresForm
                    FormularioError.mensaje = "Campos Vacios"
                FormularioError.StartPosition = FormStartPosition.CenterScreen
                FormularioError.ShowDialog()
            Else

                Dim objBU As New Negocios.CatalogoCondicionesBU
                Dim CondicionB As New Entidades.CatalogoCondicionesCondicion
                CondicionB = objBU.BuscarCondicion(txtCondicionNombre.Text)
                If CondicionB.PIdCondicion > 0 Then

                    Dim FormularioMensaje As New ErroresForm
                    FormularioMensaje.mensaje = "El nombre de la política ya existe"
                    FormularioMensaje.StartPosition = FormStartPosition.CenterScreen
                    FormularioMensaje.ShowDialog()
                Else
                    PSalio = False

                    Dim Condicion As New Entidades.CatalogoCondicionesCondicion
                    Condicion.PNombre = txtCondicionNombre.Text
                    Condicion.PIdTipo = CInt(cboCondicionTipo.SelectedValue)
                    If rdoCondicionActivoSi.Checked = True Then
                        Condicion.PActivo = True
                    Else
                        Condicion.PActivo = False
                    End If
                    Dim objCondicionesBU As New Negocios.CatalogoCondicionesBU
                    objCondicionesBU.altaCondicion(Condicion)
                    Dim FormularioMensaje As New ExitoForm
                    FormularioMensaje.mensaje = "Registro Guardado"
                    FormularioMensaje.StartPosition = FormStartPosition.CenterScreen
                    FormularioMensaje.ShowDialog()

                    Me.Close()
                End If
            End If
        Else
            If txtCondicionNombre.Text <> "" Then
                lblCondicionNombre.ForeColor = Color.Black
            Else
                lblCondicionNombre.ForeColor = Color.Red
                CamposVacios = True
            End If
            If IdTipo <> 0 Then
                lblCondicionTipo.ForeColor = Color.Black
            Else
                lblCondicionTipo.ForeColor = Color.Red
                CamposVacios = True
            End If
            If CamposVacios Then
                Dim FormaError As New ErroresForm
                FormaError.mensaje = "Campos vacíos"
                FormaError.StartPosition = FormStartPosition.CenterScreen
                FormaError.ShowDialog()
            Else
                Dim editarCondicion As New Entidades.CatalogoCondicionesCondicion
                editarCondicion.PNombre = txtCondicionNombre.Text
                editarCondicion.PIdTipo = CInt(cboCondicionTipo.SelectedValue)
                IdTipo = CInt(cboCondicionTipo.SelectedValue)
                If rdoCondicionActivoSi.Checked = True Then
                    editarCondicion.PActivo = True
                Else
                    editarCondicion.PActivo = False
                End If
                editarCondicion.PIdTipo = CInt(cboCondicionTipo.SelectedValue)
                editarCondicion.PIdCondicion = IdCondicion
                Dim objEditarCondicionBU As New Negocios.CatalogoCondicionesBU
                objEditarCondicionBU.editarCondicion(editarCondicion)
                Dim FormaExito As New ExitoForm
                FormaExito.mensaje = "Registro Guardado"
                FormaExito.StartPosition = FormStartPosition.CenterScreen
                FormaExito.ShowDialog()
                Me.Close()
            End If
        End If

    End Sub

    Private Sub guardarEditarCatalogo()
        CamposVacios = False
        If AgregarOEditar = True Then
            If txtDescripcionCatalogo.Text <> "" Then
                lblCatalogoDescripcion.ForeColor = Color.Black
            Else
                lblCatalogoDescripcion.ForeColor = Color.Red
                CamposVacios = True
            End If
            If IdTipo <> 0 Then
                lblCatalogoCondicion.ForeColor = Color.Black
            Else
                lblCatalogoCondicion.ForeColor = Color.Red
                CamposVacios = True
            End If
            If CamposVacios = True Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos Vacios"
                FormularioError.StartPosition = FormStartPosition.CenterScreen
                FormularioError.ShowDialog()
            Else
                Dim Catalogo As New Entidades.CatalogoCondicionesCatalogo
                Catalogo.PDescripcion = txtDescripcionCatalogo.Text
                Catalogo.PIdCondicion = CInt(cboCatalogoCondicion.SelectedValue)
                If rdoCatalogoActivoSi.Checked = True Then
                    Catalogo.PActivo = True
                Else
                    Catalogo.PActivo = False
                End If
                Catalogo.POpcionDefault = False

                Dim objCatalogoBU As New Negocios.CatalogoCondicionesBU
                objCatalogoBU.altaCatalogo(Catalogo)
                Dim FormularioMensaje As New ExitoForm
                FormularioMensaje.mensaje = "Registro Guardado"
                FormularioMensaje.StartPosition = FormStartPosition.CenterScreen
                FormularioMensaje.ShowDialog()
                Me.Close()
            End If
        Else
            If txtDescripcionCatalogo.Text <> "" Then
                lblCatalogoDescripcion.ForeColor = Color.Black
            Else
                lblCatalogoDescripcion.ForeColor = Color.Red
                CamposVacios = True
            End If
            If IdTipo <> 0 Then
                lblCatalogoCondicion.ForeColor = Color.Black
            Else
                lblCatalogoCondicion.ForeColor = Color.Red
                CamposVacios = True
            End If
            If CamposVacios = True Then
                Dim FormularioError As New ErroresForm
                FormularioError.mensaje = "Campos Vacios"
                FormularioError.StartPosition = FormStartPosition.CenterScreen
                FormularioError.ShowDialog()
            Else
                Dim editarCatalogo As New Entidades.CatalogoCondicionesCatalogo
                editarCatalogo.PIdCatalogo = IdCatalogo
                editarCatalogo.PDescripcion = txtDescripcionCatalogo.Text
                editarCatalogo.PIdCondicion = CInt(cboCatalogoCondicion.SelectedValue)
                editarCatalogo.POpcionDefault = OpDefault
                If rdoCatalogoActivoSi.Checked = True Then
                    editarCatalogo.PActivo = True
                Else
                    editarCatalogo.PActivo = False
                End If

                IdTipo = CInt(cboTipoPolitica.SelectedValue)
                IdCondicion = CInt(cboCatalogoCondicion.SelectedValue)


                Dim objEditarCatalogo As New Negocios.CatalogoCondicionesBU
                objEditarCatalogo.editarCatalogo(editarCatalogo)
                Dim FormaExito As New ExitoForm
                FormaExito.mensaje = "Registro Guardado"
                FormaExito.StartPosition = FormStartPosition.CenterScreen
                FormaExito.ShowDialog()
            End If
            Me.Close()
        End If
    End Sub




    Public Function ComboTipoCondiciones(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoCondiciones = New ComboBox
        ComboTipoCondiciones = ComboEntrada
        Dim TablaTipo As New List(Of Entidades.CatalogoCondicionesTipo)
        Dim objTipoCondicionesBU As New Negocios.CatalogoCondicionesBU
        TablaTipo = objTipoCondicionesBU.ListaTipoCondicion()

        TablaTipo.Insert(0, New Entidades.CatalogoCondicionesTipo)
        If TablaTipo.Count > 0 Then
            ComboTipoCondiciones.DataSource = TablaTipo
            ComboTipoCondiciones.DisplayMember = "PNombre"
            ComboTipoCondiciones.ValueMember = "PIdTipo"
        End If

    End Function

    Public Function ComboCondicionCatalogo(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboCondicionCatalogo = New ComboBox
        ComboCondicionCatalogo = ComboEntrada
        Dim Tablacondicion As New List(Of Entidades.CatalogoCondicionesCondicion)

        Dim objCondicion As New Negocios.CatalogoCondicionesBU
        Tablacondicion = objCondicion.ListaCondicionCatalogo(IdTipo)

        Tablacondicion.Insert(0, New Entidades.CatalogoCondicionesCondicion)
        If Tablacondicion.Count > 0 Then
            ComboCondicionCatalogo.DataSource = Tablacondicion
            ComboCondicionCatalogo.DisplayMember = "PNombre"
            ComboCondicionCatalogo.ValueMember = "PIdCondicion"
        End If
    End Function

    Private Sub btnGuardarCondiciones_Click(sender As Object, e As EventArgs) Handles btnGuardarCondiciones.Click
        If accion = "Tipo" Then
            GuardarEditarTipoCondiciones()
        ElseIf accion = "Condicion" Then
                GuardarEditarCondiciones()
        ElseIf accion = "Catalogo" Then
                guardarEditarCatalogo()
            End If


    End Sub

    Private Sub btnCancelarTipoPolitica_Click(sender As Object, e As EventArgs) Handles btnCancelarTipoPolitica.Click
        PSalio = True
        Me.Close()
    End Sub


   
    Private Sub cboTipoPolitica_DropDownClosed(sender As Object, e As EventArgs) Handles cboTipoPolitica.DropDownClosed
        IdTipo = CInt(cboTipoPolitica.SelectedValue)
        ComboCondicionCatalogo(cboCatalogoCondicion)
    End Sub

 
End Class