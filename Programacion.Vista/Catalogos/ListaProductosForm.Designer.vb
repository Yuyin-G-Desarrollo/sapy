<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaProductosForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnUp = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnRastroModelosAndrea = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnFotografia = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnEstatus = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.lblSubfamilia = New System.Windows.Forms.Label()
        Me.grpParametrosBusqueda = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblTemporada = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblFiltrar = New System.Windows.Forms.Label()
        Me.cmbColeccion = New System.Windows.Forms.ComboBox()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.cmbFamilia = New System.Windows.Forms.ComboBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.cmbSubfamilia = New System.Windows.Forms.ComboBox()
        Me.cmbTalla = New System.Windows.Forms.ComboBox()
        Me.cmbCorte = New System.Windows.Forms.ComboBox()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.cmbTemporada = New System.Windows.Forms.ComboBox()
        Me.lblPiel = New System.Windows.Forms.Label()
        Me.cmbForro = New System.Windows.Forms.ComboBox()
        Me.lblTalla = New System.Windows.Forms.Label()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.lblPielMuestra = New System.Windows.Forms.Label()
        Me.lblSuela = New System.Windows.Forms.Label()
        Me.lblForro = New System.Windows.Forms.Label()
        Me.cmbSuela = New System.Windows.Forms.ComboBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.cmbPiel = New System.Windows.Forms.ComboBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpParametros = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboComercializadora = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnVerModelosDetalles = New System.Windows.Forms.Button()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.cmbUColeccion = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cmbUMarca = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblColeccion = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.grdListaProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.grpParametrosBusqueda.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.grpParametros.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbUColeccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbUMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListaProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnDown)
        Me.pnlHeader.Controls.Add(Me.btnFiltrar)
        Me.pnlHeader.Controls.Add(Me.btnUp)
        Me.pnlHeader.Controls.Add(Me.btnLimpiar)
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Controls.Add(Me.lblSubfamilia)
        Me.pnlHeader.Controls.Add(Me.grpParametrosBusqueda)
        Me.pnlHeader.Controls.Add(Me.lblLimpiar)
        Me.pnlHeader.Controls.Add(Me.txtCodigo)
        Me.pnlHeader.Controls.Add(Me.lblTemporada)
        Me.pnlHeader.Controls.Add(Me.txtDescripcion)
        Me.pnlHeader.Controls.Add(Me.lblFiltrar)
        Me.pnlHeader.Controls.Add(Me.cmbColeccion)
        Me.pnlHeader.Controls.Add(Me.lblFamilia)
        Me.pnlHeader.Controls.Add(Me.cmbFamilia)
        Me.pnlHeader.Controls.Add(Me.lblDescripcion)
        Me.pnlHeader.Controls.Add(Me.cmbGrupo)
        Me.pnlHeader.Controls.Add(Me.lblCodigo)
        Me.pnlHeader.Controls.Add(Me.cmbMarca)
        Me.pnlHeader.Controls.Add(Me.cmbSubfamilia)
        Me.pnlHeader.Controls.Add(Me.cmbTalla)
        Me.pnlHeader.Controls.Add(Me.cmbCorte)
        Me.pnlHeader.Controls.Add(Me.cmbColor)
        Me.pnlHeader.Controls.Add(Me.cmbTemporada)
        Me.pnlHeader.Controls.Add(Me.lblPiel)
        Me.pnlHeader.Controls.Add(Me.cmbForro)
        Me.pnlHeader.Controls.Add(Me.lblTalla)
        Me.pnlHeader.Controls.Add(Me.lblGrupo)
        Me.pnlHeader.Controls.Add(Me.lblPielMuestra)
        Me.pnlHeader.Controls.Add(Me.lblSuela)
        Me.pnlHeader.Controls.Add(Me.lblForro)
        Me.pnlHeader.Controls.Add(Me.cmbSuela)
        Me.pnlHeader.Controls.Add(Me.lblColor)
        Me.pnlHeader.Controls.Add(Me.cmbPiel)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1146, 74)
        Me.pnlHeader.TabIndex = 0
        '
        'btnDown
        '
        Me.btnDown.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(851, 16)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 1
        Me.btnDown.UseVisualStyleBackColor = True
        Me.btnDown.Visible = False
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrar.Location = New System.Drawing.Point(851, 7)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrar.TabIndex = 6
        Me.btnFiltrar.UseVisualStyleBackColor = True
        Me.btnFiltrar.Visible = False
        '
        'btnUp
        '
        Me.btnUp.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUp.Location = New System.Drawing.Point(851, 13)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(20, 20)
        Me.btnUp.TabIndex = 0
        Me.btnUp.UseVisualStyleBackColor = True
        Me.btnUp.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(851, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.UseVisualStyleBackColor = True
        Me.btnLimpiar.Visible = False
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnRastroModelosAndrea)
        Me.pnlOperaciones.Controls.Add(Me.Label6)
        Me.pnlOperaciones.Controls.Add(Me.btnFotografia)
        Me.pnlOperaciones.Controls.Add(Me.Label3)
        Me.pnlOperaciones.Controls.Add(Me.btnEstatus)
        Me.pnlOperaciones.Controls.Add(Me.Label2)
        Me.pnlOperaciones.Controls.Add(Me.btnEditar)
        Me.pnlOperaciones.Controls.Add(Me.btnAlta)
        Me.pnlOperaciones.Controls.Add(Me.lblEditar)
        Me.pnlOperaciones.Controls.Add(Me.lblAlta)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(376, 74)
        Me.pnlOperaciones.TabIndex = 1
        '
        'btnRastroModelosAndrea
        '
        Me.btnRastroModelosAndrea.Image = Global.Programacion.Vista.My.Resources.Resources.OProduccion
        Me.btnRastroModelosAndrea.Location = New System.Drawing.Point(241, 3)
        Me.btnRastroModelosAndrea.Name = "btnRastroModelosAndrea"
        Me.btnRastroModelosAndrea.Size = New System.Drawing.Size(32, 32)
        Me.btnRastroModelosAndrea.TabIndex = 9
        Me.btnRastroModelosAndrea.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(215, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 26)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Conf. Etiq. Rastreo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Modelos Andrea"
        '
        'btnFotografia
        '
        Me.btnFotografia.Image = Global.Programacion.Vista.My.Resources.Resources.colaboradorexpediente_32
        Me.btnFotografia.Location = New System.Drawing.Point(163, 3)
        Me.btnFotografia.Name = "btnFotografia"
        Me.btnFotografia.Size = New System.Drawing.Size(32, 32)
        Me.btnFotografia.TabIndex = 7
        Me.btnFotografia.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(152, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 26)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cambio de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fotografía"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEstatus
        '
        Me.btnEstatus.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnEstatus.Location = New System.Drawing.Point(108, 3)
        Me.btnEstatus.Name = "btnEstatus"
        Me.btnEstatus.Size = New System.Drawing.Size(32, 32)
        Me.btnEstatus.TabIndex = 5
        Me.btnEstatus.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(96, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 26)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cambio de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Estatus"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(59, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 3
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.btnAlta.Location = New System.Drawing.Point(10, 3)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 2
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(58, 38)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 1
        Me.lblEditar.Text = "Editar"
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(14, 38)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 0
        Me.lblAlta.Text = "Alta"
        '
        'lblSubfamilia
        '
        Me.lblSubfamilia.AutoSize = True
        Me.lblSubfamilia.Location = New System.Drawing.Point(837, 19)
        Me.lblSubfamilia.Name = "lblSubfamilia"
        Me.lblSubfamilia.Size = New System.Drawing.Size(55, 13)
        Me.lblSubfamilia.TabIndex = 33
        Me.lblSubfamilia.Text = "Subfamilia"
        Me.lblSubfamilia.Visible = False
        '
        'grpParametrosBusqueda
        '
        Me.grpParametrosBusqueda.Controls.Add(Me.lblTitulo)
        Me.grpParametrosBusqueda.Controls.Add(Me.pcbTitulo)
        Me.grpParametrosBusqueda.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpParametrosBusqueda.Location = New System.Drawing.Point(946, 0)
        Me.grpParametrosBusqueda.Name = "grpParametrosBusqueda"
        Me.grpParametrosBusqueda.Size = New System.Drawing.Size(200, 74)
        Me.grpParametrosBusqueda.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(52, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(76, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Modelos"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(132, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 74)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(843, 20)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 1
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(840, 16)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(75, 20)
        Me.txtCodigo.TabIndex = 4
        Me.txtCodigo.Visible = False
        '
        'lblTemporada
        '
        Me.lblTemporada.AutoSize = True
        Me.lblTemporada.Location = New System.Drawing.Point(837, 18)
        Me.lblTemporada.Name = "lblTemporada"
        Me.lblTemporada.Size = New System.Drawing.Size(61, 13)
        Me.lblTemporada.TabIndex = 18
        Me.lblTemporada.Text = "Temporada"
        Me.lblTemporada.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(840, 17)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(82, 20)
        Me.txtDescripcion.TabIndex = 6
        Me.txtDescripcion.Visible = False
        '
        'lblFiltrar
        '
        Me.lblFiltrar.AutoSize = True
        Me.lblFiltrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblFiltrar.Location = New System.Drawing.Point(852, 19)
        Me.lblFiltrar.Name = "lblFiltrar"
        Me.lblFiltrar.Size = New System.Drawing.Size(40, 13)
        Me.lblFiltrar.TabIndex = 0
        Me.lblFiltrar.Text = "Buscar"
        Me.lblFiltrar.Visible = False
        '
        'cmbColeccion
        '
        Me.cmbColeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColeccion.FormattingEnabled = True
        Me.cmbColeccion.Location = New System.Drawing.Point(840, 14)
        Me.cmbColeccion.Name = "cmbColeccion"
        Me.cmbColeccion.Size = New System.Drawing.Size(77, 21)
        Me.cmbColeccion.TabIndex = 7
        Me.cmbColeccion.Visible = False
        '
        'lblFamilia
        '
        Me.lblFamilia.AutoSize = True
        Me.lblFamilia.Location = New System.Drawing.Point(848, 21)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(39, 13)
        Me.lblFamilia.TabIndex = 15
        Me.lblFamilia.Text = "Familia"
        Me.lblFamilia.Visible = False
        '
        'cmbFamilia
        '
        Me.cmbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFamilia.FormattingEnabled = True
        Me.cmbFamilia.Location = New System.Drawing.Point(835, 15)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(82, 21)
        Me.cmbFamilia.TabIndex = 8
        Me.cmbFamilia.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(848, 21)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(63, 13)
        Me.lblDescripcion.TabIndex = 12
        Me.lblDescripcion.Text = "Descripción"
        Me.lblDescripcion.Visible = False
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(835, 13)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(43, 21)
        Me.cmbGrupo.TabIndex = 9
        Me.cmbGrupo.Visible = False
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(847, 28)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 11
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.Visible = False
        '
        'cmbMarca
        '
        Me.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(835, 12)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(82, 21)
        Me.cmbMarca.TabIndex = 10
        Me.cmbMarca.Visible = False
        '
        'cmbSubfamilia
        '
        Me.cmbSubfamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubfamilia.FormattingEnabled = True
        Me.cmbSubfamilia.Location = New System.Drawing.Point(840, 17)
        Me.cmbSubfamilia.Name = "cmbSubfamilia"
        Me.cmbSubfamilia.Size = New System.Drawing.Size(82, 21)
        Me.cmbSubfamilia.TabIndex = 32
        Me.cmbSubfamilia.Visible = False
        '
        'cmbTalla
        '
        Me.cmbTalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTalla.FormattingEnabled = True
        Me.cmbTalla.Location = New System.Drawing.Point(855, 17)
        Me.cmbTalla.Name = "cmbTalla"
        Me.cmbTalla.Size = New System.Drawing.Size(43, 21)
        Me.cmbTalla.TabIndex = 25
        Me.cmbTalla.Visible = False
        '
        'cmbCorte
        '
        Me.cmbCorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorte.FormattingEnabled = True
        Me.cmbCorte.Location = New System.Drawing.Point(840, 14)
        Me.cmbCorte.Name = "cmbCorte"
        Me.cmbCorte.Size = New System.Drawing.Size(43, 21)
        Me.cmbCorte.TabIndex = 26
        Me.cmbCorte.Visible = False
        '
        'cmbColor
        '
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(846, 13)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(43, 21)
        Me.cmbColor.TabIndex = 27
        Me.cmbColor.Visible = False
        '
        'cmbTemporada
        '
        Me.cmbTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTemporada.FormattingEnabled = True
        Me.cmbTemporada.Location = New System.Drawing.Point(850, 16)
        Me.cmbTemporada.Name = "cmbTemporada"
        Me.cmbTemporada.Size = New System.Drawing.Size(82, 21)
        Me.cmbTemporada.TabIndex = 28
        Me.cmbTemporada.Visible = False
        '
        'lblPiel
        '
        Me.lblPiel.AutoSize = True
        Me.lblPiel.Location = New System.Drawing.Point(859, 12)
        Me.lblPiel.Name = "lblPiel"
        Me.lblPiel.Size = New System.Drawing.Size(24, 13)
        Me.lblPiel.TabIndex = 19
        Me.lblPiel.Text = "Piel"
        Me.lblPiel.Visible = False
        '
        'cmbForro
        '
        Me.cmbForro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForro.FormattingEnabled = True
        Me.cmbForro.Location = New System.Drawing.Point(868, 14)
        Me.cmbForro.Name = "cmbForro"
        Me.cmbForro.Size = New System.Drawing.Size(43, 21)
        Me.cmbForro.TabIndex = 29
        Me.cmbForro.Visible = False
        '
        'lblTalla
        '
        Me.lblTalla.AutoSize = True
        Me.lblTalla.Location = New System.Drawing.Point(862, 21)
        Me.lblTalla.Name = "lblTalla"
        Me.lblTalla.Size = New System.Drawing.Size(30, 13)
        Me.lblTalla.TabIndex = 20
        Me.lblTalla.Text = "Talla"
        Me.lblTalla.Visible = False
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.Location = New System.Drawing.Point(875, 24)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(36, 13)
        Me.lblGrupo.TabIndex = 17
        Me.lblGrupo.Text = "Grupo"
        Me.lblGrupo.Visible = False
        '
        'lblPielMuestra
        '
        Me.lblPielMuestra.AutoSize = True
        Me.lblPielMuestra.Location = New System.Drawing.Point(857, 22)
        Me.lblPielMuestra.Name = "lblPielMuestra"
        Me.lblPielMuestra.Size = New System.Drawing.Size(32, 13)
        Me.lblPielMuestra.TabIndex = 23
        Me.lblPielMuestra.Text = "Corte"
        Me.lblPielMuestra.Visible = False
        '
        'lblSuela
        '
        Me.lblSuela.AutoSize = True
        Me.lblSuela.Location = New System.Drawing.Point(843, 23)
        Me.lblSuela.Name = "lblSuela"
        Me.lblSuela.Size = New System.Drawing.Size(34, 13)
        Me.lblSuela.TabIndex = 22
        Me.lblSuela.Text = "Suela"
        Me.lblSuela.Visible = False
        '
        'lblForro
        '
        Me.lblForro.AutoSize = True
        Me.lblForro.Location = New System.Drawing.Point(852, 19)
        Me.lblForro.Name = "lblForro"
        Me.lblForro.Size = New System.Drawing.Size(31, 13)
        Me.lblForro.TabIndex = 24
        Me.lblForro.Text = "Forro"
        Me.lblForro.Visible = False
        '
        'cmbSuela
        '
        Me.cmbSuela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuela.FormattingEnabled = True
        Me.cmbSuela.Location = New System.Drawing.Point(855, 9)
        Me.cmbSuela.Name = "cmbSuela"
        Me.cmbSuela.Size = New System.Drawing.Size(43, 21)
        Me.cmbSuela.TabIndex = 31
        Me.cmbSuela.Visible = False
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(862, 12)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(31, 13)
        Me.lblColor.TabIndex = 21
        Me.lblColor.Text = "Color"
        Me.lblColor.Visible = False
        '
        'cmbPiel
        '
        Me.cmbPiel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPiel.FormattingEnabled = True
        Me.cmbPiel.Location = New System.Drawing.Point(855, 16)
        Me.cmbPiel.Name = "cmbPiel"
        Me.cmbPiel.Size = New System.Drawing.Size(43, 21)
        Me.cmbPiel.TabIndex = 30
        Me.cmbPiel.Visible = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(895, 22)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 2
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(931, 22)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 3
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlSalir)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 511)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1146, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.btnCancelar)
        Me.pnlSalir.Controls.Add(Me.lblCancelar)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(878, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(268, 60)
        Me.pnlSalir.TabIndex = 12
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(216, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(215, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 11
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(1017, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 26)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Vista " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Artículos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpParametros
        '
        Me.grpParametros.Controls.Add(Me.GroupBox1)
        Me.grpParametros.Controls.Add(Me.btnLimpiar2)
        Me.grpParametros.Controls.Add(Me.Label5)
        Me.grpParametros.Controls.Add(Me.btnMostrar)
        Me.grpParametros.Controls.Add(Me.Label4)
        Me.grpParametros.Controls.Add(Me.btnVerModelosDetalles)
        Me.grpParametros.Controls.Add(Me.Label1)
        Me.grpParametros.Controls.Add(Me.lblActivo)
        Me.grpParametros.Controls.Add(Me.rdoInactivo)
        Me.grpParametros.Controls.Add(Me.cmbUColeccion)
        Me.grpParametros.Controls.Add(Me.rdoActivo)
        Me.grpParametros.Controls.Add(Me.cmbUMarca)
        Me.grpParametros.Controls.Add(Me.lblColeccion)
        Me.grpParametros.Controls.Add(Me.lblMarca)
        Me.grpParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpParametros.Location = New System.Drawing.Point(0, 74)
        Me.grpParametros.Name = "grpParametros"
        Me.grpParametros.Size = New System.Drawing.Size(1146, 63)
        Me.grpParametros.TabIndex = 2
        Me.grpParametros.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboComercializadora)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 48)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Comercializadora"
        '
        'cboComercializadora
        '
        Me.cboComercializadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComercializadora.FormattingEnabled = True
        Me.cboComercializadora.Location = New System.Drawing.Point(19, 17)
        Me.cboComercializadora.Name = "cboComercializadora"
        Me.cboComercializadora.Size = New System.Drawing.Size(160, 21)
        Me.cboComercializadora.TabIndex = 42
        '
        'btnLimpiar2
        '
        Me.btnLimpiar2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar2.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar2.Location = New System.Drawing.Point(1108, 9)
        Me.btnLimpiar2.Name = "btnLimpiar2"
        Me.btnLimpiar2.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar2.TabIndex = 40
        Me.btnLimpiar2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(1104, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Limpiar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(1067, 9)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 38
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(1063, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Mostrar"
        '
        'btnVerModelosDetalles
        '
        Me.btnVerModelosDetalles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerModelosDetalles.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnVerModelosDetalles.Location = New System.Drawing.Point(1024, 9)
        Me.btnVerModelosDetalles.Name = "btnVerModelosDetalles"
        Me.btnVerModelosDetalles.Size = New System.Drawing.Size(32, 32)
        Me.btnVerModelosDetalles.TabIndex = 12
        Me.btnVerModelosDetalles.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(847, 24)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 37
        Me.lblActivo.Text = "Activo"
        '
        'cmbUColeccion
        '
        Me.cmbUColeccion.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbUColeccion.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbUColeccion.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbUColeccion.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cmbUColeccion.CheckedListSettings.EditorValueSource = Infragistics.Win.EditorWithComboValueSource.CheckedItems
        Me.cmbUColeccion.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbUColeccion.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbUColeccion.Location = New System.Drawing.Point(593, 20)
        Me.cmbUColeccion.Name = "cmbUColeccion"
        Me.cmbUColeccion.Size = New System.Drawing.Size(209, 21)
        Me.cmbUColeccion.TabIndex = 36
        '
        'cmbUMarca
        '
        Me.cmbUMarca.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest
        Me.cmbUMarca.AutoSuggestFilterMode = Infragistics.Win.AutoSuggestFilterMode.Contains
        Me.cmbUMarca.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbUMarca.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cmbUMarca.CheckedListSettings.EditorValueSource = Infragistics.Win.EditorWithComboValueSource.CheckedItems
        Me.cmbUMarca.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010
        Me.cmbUMarca.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbUMarca.Location = New System.Drawing.Point(285, 20)
        Me.cmbUMarca.Name = "cmbUMarca"
        Me.cmbUMarca.Size = New System.Drawing.Size(209, 21)
        Me.cmbUMarca.TabIndex = 35
        '
        'lblColeccion
        '
        Me.lblColeccion.AutoSize = True
        Me.lblColeccion.Location = New System.Drawing.Point(533, 24)
        Me.lblColeccion.Name = "lblColeccion"
        Me.lblColeccion.Size = New System.Drawing.Size(54, 13)
        Me.lblColeccion.TabIndex = 16
        Me.lblColeccion.Text = "Colección"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(236, 24)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 14
        Me.lblMarca.Text = "Marca"
        '
        'grdListaProductos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.BorderColor = System.Drawing.Color.DarkGray
        Appearance1.TextVAlignAsString = "Middle"
        Me.grdListaProductos.DisplayLayout.Appearance = Appearance1
        Me.grdListaProductos.DisplayLayout.GroupByBox.Hidden = True
        Me.grdListaProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListaProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BorderColor = System.Drawing.Color.AliceBlue
        Me.grdListaProductos.DisplayLayout.Override.HeaderAppearance = Appearance2
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaProductos.DisplayLayout.Override.RowAlternateAppearance = Appearance3
        Me.grdListaProductos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaProductos.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaProductos.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdListaProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaProductos.Location = New System.Drawing.Point(0, 137)
        Me.grdListaProductos.Name = "grdListaProductos"
        Me.grdListaProductos.Size = New System.Drawing.Size(1146, 374)
        Me.grdListaProductos.TabIndex = 4
        Me.grdListaProductos.Text = "Productos"
        '
        'ListaProductosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1146, 571)
        Me.Controls.Add(Me.grdListaProductos)
        Me.Controls.Add(Me.grpParametros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ListaProductosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Modelos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.grpParametrosBusqueda.ResumeLayout(False)
        Me.grpParametrosBusqueda.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.grpParametros.ResumeLayout(False)
        Me.grpParametros.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cmbUColeccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbUMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListaProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents grpParametrosBusqueda As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents grpParametros As System.Windows.Forms.GroupBox
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblFiltrar As System.Windows.Forms.Label
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents lblColeccion As System.Windows.Forms.Label
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cmbMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFamilia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbColeccion As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents cmbSuela As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPiel As System.Windows.Forms.ComboBox
    Friend WithEvents lblSuela As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents lblForro As System.Windows.Forms.Label
    Friend WithEvents lblPielMuestra As System.Windows.Forms.Label
    Friend WithEvents lblTalla As System.Windows.Forms.Label
    Friend WithEvents cmbForro As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTemporada As System.Windows.Forms.ComboBox
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCorte As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTalla As System.Windows.Forms.ComboBox
    Friend WithEvents lblTemporada As System.Windows.Forms.Label
    Friend WithEvents lblPiel As System.Windows.Forms.Label
    Friend WithEvents lblSubfamilia As System.Windows.Forms.Label
    Friend WithEvents cmbSubfamilia As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents grdListaProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbUMarca As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cmbUColeccion As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnVerModelosDetalles As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents btnFotografia As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEstatus As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboComercializadora As ComboBox
    Friend WithEvents btnRastroModelosAndrea As Button
    Friend WithEvents Label6 As Label
End Class
