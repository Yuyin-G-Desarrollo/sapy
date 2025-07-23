<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarModuloArbolForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarModuloArbolForm))
        Me.grdAcciones = New System.Windows.Forms.DataGridView()
        Me.accionId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.identificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.componente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.icono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.activo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.txtIcono = New System.Windows.Forms.TextBox()
        Me.lblIcono = New System.Windows.Forms.Label()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.lblComponente = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblPermisos = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnlCampos = New System.Windows.Forms.Panel()
        Me.grpModulo = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.gprMostrarMenu = New System.Windows.Forms.GroupBox()
        Me.rdoNoMostrar = New System.Windows.Forms.RadioButton()
        Me.rdoMostrarEnMenu = New System.Windows.Forms.RadioButton()
        Me.cmbModSuperior = New System.Windows.Forms.ComboBox()
        Me.txtNombreModulo = New System.Windows.Forms.TextBox()
        Me.lblSuperior = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.gprActivo = New System.Windows.Forms.GroupBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkEsWeb = New System.Windows.Forms.CheckBox()
        Me.chkEscritorio = New System.Windows.Forms.CheckBox()
        Me.txtIconoWEB = New System.Windows.Forms.TextBox()
        Me.lblIconoWEB = New System.Windows.Forms.Label()
        Me.lblComponenteWEB = New System.Windows.Forms.Label()
        Me.txtComponenteWEB = New System.Windows.Forms.TextBox()
        Me.grdOrdenamiento = New System.Windows.Forms.DataGridView()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.moduloId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.claveModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlCampos.SuspendLayout()
        Me.grpModulo.SuspendLayout()
        Me.gprMostrarMenu.SuspendLayout()
        Me.gprActivo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdOrdenamiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdAcciones
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAcciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdAcciones.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAcciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.accionId, Me.identificador, Me.componente, Me.nombre, Me.icono, Me.clave, Me.activo})
        Me.grdAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAcciones.Location = New System.Drawing.Point(0, 255)
        Me.grdAcciones.Name = "grdAcciones"
        Me.grdAcciones.RowHeadersVisible = False
        Me.grdAcciones.RowHeadersWidth = 4
        Me.grdAcciones.Size = New System.Drawing.Size(509, 285)
        Me.grdAcciones.TabIndex = 38
        '
        'accionId
        '
        Me.accionId.HeaderText = "idAct"
        Me.accionId.Name = "accionId"
        Me.accionId.ReadOnly = True
        Me.accionId.Visible = False
        '
        'identificador
        '
        Me.identificador.HeaderText = "idModulo"
        Me.identificador.Name = "identificador"
        Me.identificador.ReadOnly = True
        Me.identificador.Visible = False
        '
        'componente
        '
        Me.componente.HeaderText = "Componente"
        Me.componente.Name = "componente"
        Me.componente.Visible = False
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        '
        'icono
        '
        Me.icono.HeaderText = "Icono"
        Me.icono.Name = "icono"
        Me.icono.Visible = False
        '
        'clave
        '
        Me.clave.HeaderText = "Clave"
        Me.clave.Name = "clave"
        '
        'activo
        '
        Me.activo.HeaderText = "Activo"
        Me.activo.Name = "activo"
        '
        'txtIcono
        '
        Me.txtIcono.Location = New System.Drawing.Point(106, 66)
        Me.txtIcono.Name = "txtIcono"
        Me.txtIcono.Size = New System.Drawing.Size(303, 20)
        Me.txtIcono.TabIndex = 37
        '
        'lblIcono
        '
        Me.lblIcono.AutoSize = True
        Me.lblIcono.Location = New System.Drawing.Point(21, 69)
        Me.lblIcono.Name = "lblIcono"
        Me.lblIcono.Size = New System.Drawing.Size(34, 13)
        Me.lblIcono.TabIndex = 34
        Me.lblIcono.Text = "Icono"
        '
        'txtComponente
        '
        Me.txtComponente.Location = New System.Drawing.Point(106, 39)
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(303, 20)
        Me.txtComponente.TabIndex = 28
        '
        'lblComponente
        '
        Me.lblComponente.AutoSize = True
        Me.lblComponente.Location = New System.Drawing.Point(21, 45)
        Me.lblComponente.Name = "lblComponente"
        Me.lblComponente.Size = New System.Drawing.Size(67, 13)
        Me.lblComponente.TabIndex = 26
        Me.lblComponente.Text = "Componente"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(963, 60)
        Me.pnlHeader.TabIndex = 41
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblPermisos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(779, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(184, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblPermisos
        '
        Me.lblPermisos.AutoSize = True
        Me.lblPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermisos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPermisos.Location = New System.Drawing.Point(34, 22)
        Me.lblPermisos.Name = "lblPermisos"
        Me.lblPermisos.Size = New System.Drawing.Size(76, 20)
        Me.lblPermisos.TabIndex = 1
        Me.lblPermisos.Text = "Módulos"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 540)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(963, 60)
        Me.pnlEstado.TabIndex = 42
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(828, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(135, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(19, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 65
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(80, 38)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 64
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(80, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(25, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'pnlCampos
        '
        Me.pnlCampos.Controls.Add(Me.grpModulo)
        Me.pnlCampos.Controls.Add(Me.GroupBox1)
        Me.pnlCampos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCampos.Location = New System.Drawing.Point(0, 60)
        Me.pnlCampos.Name = "pnlCampos"
        Me.pnlCampos.Size = New System.Drawing.Size(963, 195)
        Me.pnlCampos.TabIndex = 45
        '
        'grpModulo
        '
        Me.grpModulo.Controls.Add(Me.Label1)
        Me.grpModulo.Controls.Add(Me.lblActivo)
        Me.grpModulo.Controls.Add(Me.gprMostrarMenu)
        Me.grpModulo.Controls.Add(Me.cmbModSuperior)
        Me.grpModulo.Controls.Add(Me.txtNombreModulo)
        Me.grpModulo.Controls.Add(Me.lblSuperior)
        Me.grpModulo.Controls.Add(Me.lblModulo)
        Me.grpModulo.Controls.Add(Me.gprActivo)
        Me.grpModulo.Controls.Add(Me.lblClave)
        Me.grpModulo.Controls.Add(Me.txtClave)
        Me.grpModulo.Location = New System.Drawing.Point(12, 6)
        Me.grpModulo.Name = "grpModulo"
        Me.grpModulo.Size = New System.Drawing.Size(475, 182)
        Me.grpModulo.TabIndex = 72
        Me.grpModulo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Menú"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(17, 116)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 55
        Me.lblActivo.Text = "Activo"
        '
        'gprMostrarMenu
        '
        Me.gprMostrarMenu.Controls.Add(Me.rdoNoMostrar)
        Me.gprMostrarMenu.Controls.Add(Me.rdoMostrarEnMenu)
        Me.gprMostrarMenu.Location = New System.Drawing.Point(94, 143)
        Me.gprMostrarMenu.Name = "gprMostrarMenu"
        Me.gprMostrarMenu.Size = New System.Drawing.Size(106, 28)
        Me.gprMostrarMenu.TabIndex = 51
        Me.gprMostrarMenu.TabStop = False
        '
        'rdoNoMostrar
        '
        Me.rdoNoMostrar.AutoSize = True
        Me.rdoNoMostrar.Location = New System.Drawing.Point(57, 8)
        Me.rdoNoMostrar.Name = "rdoNoMostrar"
        Me.rdoNoMostrar.Size = New System.Drawing.Size(39, 17)
        Me.rdoNoMostrar.TabIndex = 30
        Me.rdoNoMostrar.TabStop = True
        Me.rdoNoMostrar.Text = "No"
        Me.rdoNoMostrar.UseVisualStyleBackColor = True
        '
        'rdoMostrarEnMenu
        '
        Me.rdoMostrarEnMenu.AutoSize = True
        Me.rdoMostrarEnMenu.Location = New System.Drawing.Point(6, 8)
        Me.rdoMostrarEnMenu.Name = "rdoMostrarEnMenu"
        Me.rdoMostrarEnMenu.Size = New System.Drawing.Size(34, 17)
        Me.rdoMostrarEnMenu.TabIndex = 31
        Me.rdoMostrarEnMenu.TabStop = True
        Me.rdoMostrarEnMenu.Text = "Si"
        Me.rdoMostrarEnMenu.UseVisualStyleBackColor = True
        '
        'cmbModSuperior
        '
        Me.cmbModSuperior.FormattingEnabled = True
        Me.cmbModSuperior.Location = New System.Drawing.Point(94, 74)
        Me.cmbModSuperior.Name = "cmbModSuperior"
        Me.cmbModSuperior.Size = New System.Drawing.Size(352, 21)
        Me.cmbModSuperior.TabIndex = 54
        '
        'txtNombreModulo
        '
        Me.txtNombreModulo.Location = New System.Drawing.Point(94, 14)
        Me.txtNombreModulo.Name = "txtNombreModulo"
        Me.txtNombreModulo.Size = New System.Drawing.Size(352, 20)
        Me.txtNombreModulo.TabIndex = 47
        '
        'lblSuperior
        '
        Me.lblSuperior.AutoSize = True
        Me.lblSuperior.Location = New System.Drawing.Point(17, 78)
        Me.lblSuperior.Name = "lblSuperior"
        Me.lblSuperior.Size = New System.Drawing.Size(71, 13)
        Me.lblSuperior.TabIndex = 53
        Me.lblSuperior.Text = "Mod. superior"
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Location = New System.Drawing.Point(17, 17)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(49, 13)
        Me.lblModulo.TabIndex = 48
        Me.lblModulo.Text = "* Modulo"
        '
        'gprActivo
        '
        Me.gprActivo.Controls.Add(Me.rdoActivo)
        Me.gprActivo.Controls.Add(Me.rdoInactivo)
        Me.gprActivo.Location = New System.Drawing.Point(94, 105)
        Me.gprActivo.Name = "gprActivo"
        Me.gprActivo.Size = New System.Drawing.Size(106, 28)
        Me.gprActivo.TabIndex = 52
        Me.gprActivo.TabStop = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(8, 9)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 36
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(59, 9)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 35
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(17, 51)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(34, 13)
        Me.lblClave.TabIndex = 49
        Me.lblClave.Text = "Clave"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(94, 48)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(352, 20)
        Me.txtClave.TabIndex = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtComponente)
        Me.GroupBox1.Controls.Add(Me.lblIcono)
        Me.GroupBox1.Controls.Add(Me.chkEsWeb)
        Me.GroupBox1.Controls.Add(Me.txtIcono)
        Me.GroupBox1.Controls.Add(Me.chkEscritorio)
        Me.GroupBox1.Controls.Add(Me.lblComponente)
        Me.GroupBox1.Controls.Add(Me.txtIconoWEB)
        Me.GroupBox1.Controls.Add(Me.lblIconoWEB)
        Me.GroupBox1.Controls.Add(Me.lblComponenteWEB)
        Me.GroupBox1.Controls.Add(Me.txtComponenteWEB)
        Me.GroupBox1.Location = New System.Drawing.Point(508, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(433, 182)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        '
        'chkEsWeb
        '
        Me.chkEsWeb.AutoSize = True
        Me.chkEsWeb.Location = New System.Drawing.Point(106, 98)
        Me.chkEsWeb.Name = "chkEsWeb"
        Me.chkEsWeb.Size = New System.Drawing.Size(51, 17)
        Me.chkEsWeb.TabIndex = 71
        Me.chkEsWeb.Text = "WEB"
        Me.chkEsWeb.UseVisualStyleBackColor = True
        '
        'chkEscritorio
        '
        Me.chkEscritorio.AutoSize = True
        Me.chkEscritorio.Location = New System.Drawing.Point(106, 15)
        Me.chkEscritorio.Name = "chkEscritorio"
        Me.chkEscritorio.Size = New System.Drawing.Size(69, 17)
        Me.chkEscritorio.TabIndex = 70
        Me.chkEscritorio.Text = "Escritorio"
        Me.chkEscritorio.UseVisualStyleBackColor = True
        '
        'txtIconoWEB
        '
        Me.txtIconoWEB.Location = New System.Drawing.Point(106, 149)
        Me.txtIconoWEB.Name = "txtIconoWEB"
        Me.txtIconoWEB.Size = New System.Drawing.Size(303, 20)
        Me.txtIconoWEB.TabIndex = 64
        '
        'lblIconoWEB
        '
        Me.lblIconoWEB.AutoSize = True
        Me.lblIconoWEB.Location = New System.Drawing.Point(26, 152)
        Me.lblIconoWEB.Name = "lblIconoWEB"
        Me.lblIconoWEB.Size = New System.Drawing.Size(62, 13)
        Me.lblIconoWEB.TabIndex = 65
        Me.lblIconoWEB.Text = "Icono WEB"
        '
        'lblComponenteWEB
        '
        Me.lblComponenteWEB.AutoSize = True
        Me.lblComponenteWEB.Location = New System.Drawing.Point(26, 125)
        Me.lblComponenteWEB.Name = "lblComponenteWEB"
        Me.lblComponenteWEB.Size = New System.Drawing.Size(29, 13)
        Me.lblComponenteWEB.TabIndex = 66
        Me.lblComponenteWEB.Text = "URL"
        '
        'txtComponenteWEB
        '
        Me.txtComponenteWEB.Location = New System.Drawing.Point(106, 122)
        Me.txtComponenteWEB.Name = "txtComponenteWEB"
        Me.txtComponenteWEB.Size = New System.Drawing.Size(303, 20)
        Me.txtComponenteWEB.TabIndex = 68
        '
        'grdOrdenamiento
        '
        Me.grdOrdenamiento.AllowDrop = True
        Me.grdOrdenamiento.AllowUserToAddRows = False
        Me.grdOrdenamiento.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenamiento.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grdOrdenamiento.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdOrdenamiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Orden, Me.moduloId, Me.NombreModulo, Me.claveModulo})
        Me.grdOrdenamiento.Dock = System.Windows.Forms.DockStyle.Right
        Me.grdOrdenamiento.Location = New System.Drawing.Point(509, 255)
        Me.grdOrdenamiento.Name = "grdOrdenamiento"
        Me.grdOrdenamiento.RowHeadersWidth = 25
        Me.grdOrdenamiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdOrdenamiento.Size = New System.Drawing.Size(454, 285)
        Me.grdOrdenamiento.TabIndex = 46
        '
        'Orden
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Orden.DefaultCellStyle = DataGridViewCellStyle3
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.Visible = False
        '
        'moduloId
        '
        Me.moduloId.HeaderText = "Id"
        Me.moduloId.Name = "moduloId"
        Me.moduloId.Visible = False
        '
        'NombreModulo
        '
        Me.NombreModulo.HeaderText = "Nombre"
        Me.NombreModulo.MaxInputLength = 50
        Me.NombreModulo.Name = "NombreModulo"
        '
        'claveModulo
        '
        Me.claveModulo.HeaderText = "Clave"
        Me.claveModulo.MaxInputLength = 15
        Me.claveModulo.Name = "claveModulo"
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn1.HeaderText = "idAct"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "idModulo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Componente"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 50
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 15
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Icono"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Clave"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Componente"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Icono"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Clave"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(116, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 49
        Me.PictureBox1.TabStop = False
        '
        'EditarModuloArbolForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(963, 600)
        Me.Controls.Add(Me.grdAcciones)
        Me.Controls.Add(Me.grdOrdenamiento)
        Me.Controls.Add(Me.pnlCampos)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(969, 622)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(969, 622)
        Me.Name = "EditarModuloArbolForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulos"
        CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlCampos.ResumeLayout(False)
        Me.grpModulo.ResumeLayout(False)
        Me.grpModulo.PerformLayout()
        Me.gprMostrarMenu.ResumeLayout(False)
        Me.gprMostrarMenu.PerformLayout()
        Me.gprActivo.ResumeLayout(False)
        Me.gprActivo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdOrdenamiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdAcciones As System.Windows.Forms.DataGridView
    Friend WithEvents txtIcono As System.Windows.Forms.TextBox
    Friend WithEvents lblIcono As System.Windows.Forms.Label
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents lblComponente As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlCampos As System.Windows.Forms.Panel
    Friend WithEvents grdOrdenamiento As System.Windows.Forms.DataGridView
    Friend WithEvents accionId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents identificador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents componente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents icono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents activo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents moduloId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreModulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents claveModulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEsWeb As System.Windows.Forms.CheckBox
    Friend WithEvents chkEscritorio As System.Windows.Forms.CheckBox
    Friend WithEvents txtIconoWEB As System.Windows.Forms.TextBox
    Friend WithEvents lblIconoWEB As System.Windows.Forms.Label
    Friend WithEvents lblComponenteWEB As System.Windows.Forms.Label
    Friend WithEvents txtComponenteWEB As System.Windows.Forms.TextBox
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblPermisos As System.Windows.Forms.Label
    Friend WithEvents grpModulo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents gprMostrarMenu As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNoMostrar As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMostrarEnMenu As System.Windows.Forms.RadioButton
    Friend WithEvents cmbModSuperior As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreModulo As System.Windows.Forms.TextBox
    Friend WithEvents lblSuperior As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents gprActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
