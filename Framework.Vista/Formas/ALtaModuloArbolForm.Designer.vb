<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ALtaModuloArbolForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ALtaModuloArbolForm))
        Me.txtIcono = New System.Windows.Forms.TextBox()
        Me.lblIcono = New System.Windows.Forms.Label()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.lblComponente = New System.Windows.Forms.Label()
        Me.grdAcciones = New System.Windows.Forms.DataGridView()
        Me.componente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.icono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoAct = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.quitar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblPermisos = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtComponenteWEB = New System.Windows.Forms.TextBox()
        Me.lblComponenteWEB = New System.Windows.Forms.Label()
        Me.txtIconoWEB = New System.Windows.Forms.TextBox()
        Me.lblIconoWEB = New System.Windows.Forms.Label()
        Me.grbComponente = New System.Windows.Forms.GroupBox()
        Me.chkEsWeb = New System.Windows.Forms.CheckBox()
        Me.chkEscritorio = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.ckbNivelPadre = New System.Windows.Forms.CheckBox()
        Me.cmbModSuperior = New System.Windows.Forms.ComboBox()
        Me.txtNombreModulo = New System.Windows.Forms.TextBox()
        Me.lblSuperior = New System.Windows.Forms.Label()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.lblQuitar = New System.Windows.Forms.Label()
        Me.gprMostrarMenu = New System.Windows.Forms.GroupBox()
        Me.rdoNoMostrar = New System.Windows.Forms.RadioButton()
        Me.rdoMostrarEnMenu = New System.Windows.Forms.RadioButton()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.gprActivo = New System.Windows.Forms.GroupBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grbComponente.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gprMostrarMenu.SuspendLayout()
        Me.gprActivo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIcono
        '
        Me.txtIcono.Enabled = False
        Me.txtIcono.Location = New System.Drawing.Point(100, 69)
        Me.txtIcono.Name = "txtIcono"
        Me.txtIcono.Size = New System.Drawing.Size(268, 20)
        Me.txtIcono.TabIndex = 52
        '
        'lblIcono
        '
        Me.lblIcono.AutoSize = True
        Me.lblIcono.Location = New System.Drawing.Point(27, 72)
        Me.lblIcono.Name = "lblIcono"
        Me.lblIcono.Size = New System.Drawing.Size(34, 13)
        Me.lblIcono.TabIndex = 51
        Me.lblIcono.Text = "Icono"
        '
        'txtComponente
        '
        Me.txtComponente.Enabled = False
        Me.txtComponente.Location = New System.Drawing.Point(100, 42)
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(268, 20)
        Me.txtComponente.TabIndex = 49
        '
        'lblComponente
        '
        Me.lblComponente.AutoSize = True
        Me.lblComponente.Location = New System.Drawing.Point(27, 45)
        Me.lblComponente.Name = "lblComponente"
        Me.lblComponente.Size = New System.Drawing.Size(67, 13)
        Me.lblComponente.TabIndex = 47
        Me.lblComponente.Text = "Componente"
        '
        'grdAcciones
        '
        Me.grdAcciones.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAcciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.componente, Me.nombre, Me.icono, Me.clave, Me.tipoAct, Me.quitar})
        Me.grdAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grdAcciones.Location = New System.Drawing.Point(0, 275)
        Me.grdAcciones.Name = "grdAcciones"
        Me.grdAcciones.RowHeadersVisible = False
        Me.grdAcciones.RowHeadersWidth = 4
        Me.grdAcciones.Size = New System.Drawing.Size(883, 279)
        Me.grdAcciones.TabIndex = 53
        '
        'componente
        '
        Me.componente.HeaderText = "Componente"
        Me.componente.Name = "componente"
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
        '
        'clave
        '
        Me.clave.HeaderText = "Clave"
        Me.clave.Name = "clave"
        '
        'tipoAct
        '
        Me.tipoAct.HeaderText = "Tipo"
        Me.tipoAct.Items.AddRange(New Object() {"Consultar", "Altas", "Editar", "Eliminar", "Otros"})
        Me.tipoAct.Name = "tipoAct"
        Me.tipoAct.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tipoAct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'quitar
        '
        Me.quitar.HeaderText = "Quitar"
        Me.quitar.Name = "quitar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(883, 60)
        Me.pnlHeader.TabIndex = 58
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblPermisos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(699, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(184, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblPermisos
        '
        Me.lblPermisos.AutoSize = True
        Me.lblPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermisos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPermisos.Location = New System.Drawing.Point(34, 20)
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
        Me.pnlEstado.Location = New System.Drawing.Point(0, 554)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(883, 60)
        Me.pnlEstado.TabIndex = 59
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(748, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(135, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(19, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 63
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(78, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 62
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
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(25, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtComponenteWEB
        '
        Me.txtComponenteWEB.Enabled = False
        Me.txtComponenteWEB.Location = New System.Drawing.Point(100, 120)
        Me.txtComponenteWEB.Name = "txtComponenteWEB"
        Me.txtComponenteWEB.Size = New System.Drawing.Size(268, 20)
        Me.txtComponenteWEB.TabIndex = 68
        '
        'lblComponenteWEB
        '
        Me.lblComponenteWEB.AutoSize = True
        Me.lblComponenteWEB.Location = New System.Drawing.Point(27, 123)
        Me.lblComponenteWEB.Name = "lblComponenteWEB"
        Me.lblComponenteWEB.Size = New System.Drawing.Size(29, 13)
        Me.lblComponenteWEB.TabIndex = 66
        Me.lblComponenteWEB.Text = "URL"
        '
        'txtIconoWEB
        '
        Me.txtIconoWEB.Enabled = False
        Me.txtIconoWEB.Location = New System.Drawing.Point(100, 147)
        Me.txtIconoWEB.Name = "txtIconoWEB"
        Me.txtIconoWEB.Size = New System.Drawing.Size(268, 20)
        Me.txtIconoWEB.TabIndex = 64
        '
        'lblIconoWEB
        '
        Me.lblIconoWEB.AutoSize = True
        Me.lblIconoWEB.Location = New System.Drawing.Point(32, 150)
        Me.lblIconoWEB.Name = "lblIconoWEB"
        Me.lblIconoWEB.Size = New System.Drawing.Size(62, 13)
        Me.lblIconoWEB.TabIndex = 65
        Me.lblIconoWEB.Text = "Icono WEB"
        '
        'grbComponente
        '
        Me.grbComponente.Controls.Add(Me.chkEsWeb)
        Me.grbComponente.Controls.Add(Me.chkEscritorio)
        Me.grbComponente.Controls.Add(Me.txtComponente)
        Me.grbComponente.Controls.Add(Me.lblComponente)
        Me.grbComponente.Controls.Add(Me.lblIcono)
        Me.grbComponente.Controls.Add(Me.txtIcono)
        Me.grbComponente.Controls.Add(Me.txtIconoWEB)
        Me.grbComponente.Controls.Add(Me.lblIconoWEB)
        Me.grbComponente.Controls.Add(Me.lblComponenteWEB)
        Me.grbComponente.Controls.Add(Me.txtComponenteWEB)
        Me.grbComponente.Location = New System.Drawing.Point(452, 66)
        Me.grbComponente.Name = "grbComponente"
        Me.grbComponente.Size = New System.Drawing.Size(407, 182)
        Me.grbComponente.TabIndex = 69
        Me.grbComponente.TabStop = False
        '
        'chkEsWeb
        '
        Me.chkEsWeb.AutoSize = True
        Me.chkEsWeb.Location = New System.Drawing.Point(100, 97)
        Me.chkEsWeb.Name = "chkEsWeb"
        Me.chkEsWeb.Size = New System.Drawing.Size(51, 17)
        Me.chkEsWeb.TabIndex = 71
        Me.chkEsWeb.Text = "WEB"
        Me.chkEsWeb.UseVisualStyleBackColor = True
        '
        'chkEscritorio
        '
        Me.chkEscritorio.AutoSize = True
        Me.chkEscritorio.Checked = True
        Me.chkEscritorio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEscritorio.Location = New System.Drawing.Point(132, 18)
        Me.chkEscritorio.Name = "chkEscritorio"
        Me.chkEscritorio.Size = New System.Drawing.Size(69, 17)
        Me.chkEscritorio.TabIndex = 70
        Me.chkEscritorio.Text = "Escritorio"
        Me.chkEscritorio.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Componente"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Icono"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Clave"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblActivo)
        Me.GroupBox1.Controls.Add(Me.txtClave)
        Me.GroupBox1.Controls.Add(Me.lblClave)
        Me.GroupBox1.Controls.Add(Me.ckbNivelPadre)
        Me.GroupBox1.Controls.Add(Me.cmbModSuperior)
        Me.GroupBox1.Controls.Add(Me.txtNombreModulo)
        Me.GroupBox1.Controls.Add(Me.lblSuperior)
        Me.GroupBox1.Controls.Add(Me.lblModulo)
        Me.GroupBox1.Controls.Add(Me.lblQuitar)
        Me.GroupBox1.Controls.Add(Me.gprMostrarMenu)
        Me.GroupBox1.Controls.Add(Me.btnQuitar)
        Me.GroupBox1.Controls.Add(Me.gprActivo)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 182)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "Menú"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(35, 126)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 90
        Me.lblActivo.Text = "Activo"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(114, 87)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(256, 20)
        Me.txtClave.TabIndex = 95
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(35, 90)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(41, 13)
        Me.lblClave.TabIndex = 94
        Me.lblClave.Text = "* Clave"
        '
        'ckbNivelPadre
        '
        Me.ckbNivelPadre.AutoSize = True
        Me.ckbNivelPadre.Location = New System.Drawing.Point(114, 9)
        Me.ckbNivelPadre.Name = "ckbNivelPadre"
        Me.ckbNivelPadre.Size = New System.Drawing.Size(95, 17)
        Me.ckbNivelPadre.TabIndex = 100
        Me.ckbNivelPadre.Text = "Módulo nivel 1"
        Me.ckbNivelPadre.UseVisualStyleBackColor = True
        '
        'cmbModSuperior
        '
        Me.cmbModSuperior.FormattingEnabled = True
        Me.cmbModSuperior.Location = New System.Drawing.Point(114, 32)
        Me.cmbModSuperior.Name = "cmbModSuperior"
        Me.cmbModSuperior.Size = New System.Drawing.Size(256, 21)
        Me.cmbModSuperior.TabIndex = 99
        '
        'txtNombreModulo
        '
        Me.txtNombreModulo.Location = New System.Drawing.Point(114, 60)
        Me.txtNombreModulo.Name = "txtNombreModulo"
        Me.txtNombreModulo.Size = New System.Drawing.Size(256, 20)
        Me.txtNombreModulo.TabIndex = 92
        '
        'lblSuperior
        '
        Me.lblSuperior.AutoSize = True
        Me.lblSuperior.Location = New System.Drawing.Point(35, 36)
        Me.lblSuperior.Name = "lblSuperior"
        Me.lblSuperior.Size = New System.Drawing.Size(71, 13)
        Me.lblSuperior.TabIndex = 98
        Me.lblSuperior.Text = "Mod. superior"
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Location = New System.Drawing.Point(35, 63)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(49, 13)
        Me.lblModulo.TabIndex = 93
        Me.lblModulo.Text = "* Modulo"
        '
        'lblQuitar
        '
        Me.lblQuitar.AutoSize = True
        Me.lblQuitar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblQuitar.Location = New System.Drawing.Point(337, 150)
        Me.lblQuitar.Name = "lblQuitar"
        Me.lblQuitar.Size = New System.Drawing.Size(35, 13)
        Me.lblQuitar.TabIndex = 102
        Me.lblQuitar.Text = "Quitar"
        '
        'gprMostrarMenu
        '
        Me.gprMostrarMenu.Controls.Add(Me.rdoNoMostrar)
        Me.gprMostrarMenu.Controls.Add(Me.rdoMostrarEnMenu)
        Me.gprMostrarMenu.Location = New System.Drawing.Point(114, 146)
        Me.gprMostrarMenu.Name = "gprMostrarMenu"
        Me.gprMostrarMenu.Size = New System.Drawing.Size(106, 28)
        Me.gprMostrarMenu.TabIndex = 96
        Me.gprMostrarMenu.TabStop = False
        '
        'rdoNoMostrar
        '
        Me.rdoNoMostrar.AutoSize = True
        Me.rdoNoMostrar.Location = New System.Drawing.Point(58, 10)
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
        Me.rdoMostrarEnMenu.Location = New System.Drawing.Point(11, 10)
        Me.rdoMostrarEnMenu.Name = "rdoMostrarEnMenu"
        Me.rdoMostrarEnMenu.Size = New System.Drawing.Size(34, 17)
        Me.rdoMostrarEnMenu.TabIndex = 31
        Me.rdoMostrarEnMenu.TabStop = True
        Me.rdoMostrarEnMenu.Text = "Si"
        Me.rdoMostrarEnMenu.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.quitar_32
        Me.btnQuitar.Location = New System.Drawing.Point(338, 116)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(32, 32)
        Me.btnQuitar.TabIndex = 101
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'gprActivo
        '
        Me.gprActivo.Controls.Add(Me.rdoActivo)
        Me.gprActivo.Controls.Add(Me.rdoInactivo)
        Me.gprActivo.Location = New System.Drawing.Point(114, 113)
        Me.gprActivo.Name = "gprActivo"
        Me.gprActivo.Size = New System.Drawing.Size(106, 28)
        Me.gprActivo.TabIndex = 97
        Me.gprActivo.TabStop = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Location = New System.Drawing.Point(11, 10)
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
        Me.rdoInactivo.Location = New System.Drawing.Point(58, 10)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 35
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
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
        'ALtaModuloArbolForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(883, 614)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grbComponente)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.grdAcciones)
        Me.Controls.Add(Me.pnlEstado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(889, 636)
        Me.MinimumSize = New System.Drawing.Size(889, 636)
        Me.Name = "ALtaModuloArbolForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulos"
        CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grbComponente.ResumeLayout(False)
        Me.grbComponente.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gprMostrarMenu.ResumeLayout(False)
        Me.gprMostrarMenu.PerformLayout()
        Me.gprActivo.ResumeLayout(False)
        Me.gprActivo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtIcono As System.Windows.Forms.TextBox
    Friend WithEvents lblIcono As System.Windows.Forms.Label
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents lblComponente As System.Windows.Forms.Label
    Friend WithEvents grdAcciones As System.Windows.Forms.DataGridView
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtComponenteWEB As System.Windows.Forms.TextBox
    Friend WithEvents lblComponenteWEB As System.Windows.Forms.Label
    Friend WithEvents txtIconoWEB As System.Windows.Forms.TextBox
    Friend WithEvents lblIconoWEB As System.Windows.Forms.Label
    Friend WithEvents grbComponente As System.Windows.Forms.GroupBox
    Friend WithEvents chkEsWeb As System.Windows.Forms.CheckBox
    Friend WithEvents chkEscritorio As System.Windows.Forms.CheckBox
    Friend WithEvents componente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents icono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoAct As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents quitar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblPermisos As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents ckbNivelPadre As System.Windows.Forms.CheckBox
    Friend WithEvents cmbModSuperior As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreModulo As System.Windows.Forms.TextBox
    Friend WithEvents lblSuperior As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblQuitar As System.Windows.Forms.Label
    Friend WithEvents gprMostrarMenu As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNoMostrar As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMostrarEnMenu As System.Windows.Forms.RadioButton
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents gprActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As PictureBox
End Class
