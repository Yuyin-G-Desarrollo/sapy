<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaUsuarioForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.ptbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.rdbInactivo = New System.Windows.Forms.RadioButton()
        Me.rdbActivo = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.MaskedTextBox()
        Me.txtconfirmarContrasena = New System.Windows.Forms.MaskedTextBox()
        Me.lblConfirmaPass = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.gprDatosPersonales = New System.Windows.Forms.GroupBox()
        Me.lblIdColaborador = New System.Windows.Forms.Label()
        Me.lblnombreColaborador = New System.Windows.Forms.Label()
        Me.btnColaborador = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gprUserPass = New System.Windows.Forms.GroupBox()
        Me.txtSicy = New System.Windows.Forms.TextBox()
        Me.lblSicy = New System.Windows.Forms.Label()
        Me.lblErrorContrasena = New System.Windows.Forms.Label()
        Me.grdNaves = New System.Windows.Forms.DataGridView()
        Me.SelectNave = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlGrupBox = New System.Windows.Forms.Panel()
        Me.grdPerfiles = New System.Windows.Forms.DataGridView()
        Me.selectPerfil = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.ptbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.gprDatosPersonales.SuspendLayout()
        Me.gprUserPass.SuspendLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrupBox.SuspendLayout()
        CType(Me.grdPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(828, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.ptbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(676, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(152, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(80, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Usuarios"
        '
        'ptbTitulo
        '
        Me.ptbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.ptbTitulo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.logoYuyin2
        Me.ptbTitulo.Location = New System.Drawing.Point(92, 0)
        Me.ptbTitulo.Name = "ptbTitulo"
        Me.ptbTitulo.Size = New System.Drawing.Size(60, 60)
        Me.ptbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptbTitulo.TabIndex = 0
        Me.ptbTitulo.TabStop = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 586)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(828, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(676, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(152, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(90, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(31, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(91, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(37, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'rdbInactivo
        '
        Me.rdbInactivo.AutoSize = True
        Me.rdbInactivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbInactivo.Location = New System.Drawing.Point(166, 94)
        Me.rdbInactivo.Name = "rdbInactivo"
        Me.rdbInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rdbInactivo.TabIndex = 27
        Me.rdbInactivo.Text = "Inactivo"
        Me.rdbInactivo.UseVisualStyleBackColor = True
        '
        'rdbActivo
        '
        Me.rdbActivo.AutoSize = True
        Me.rdbActivo.Checked = True
        Me.rdbActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbActivo.Location = New System.Drawing.Point(105, 94)
        Me.rdbActivo.Name = "rdbActivo"
        Me.rdbActivo.Size = New System.Drawing.Size(55, 17)
        Me.rdbActivo.TabIndex = 26
        Me.rdbActivo.TabStop = True
        Me.rdbActivo.Text = "Activo"
        Me.rdbActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.Location = New System.Drawing.Point(62, 94)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 25
        Me.lblActivo.Text = "Activo"
        '
        'txtContrasena
        '
        Me.txtContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContrasena.Location = New System.Drawing.Point(105, 59)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtContrasena.Size = New System.Drawing.Size(185, 20)
        Me.txtContrasena.TabIndex = 23
        '
        'txtconfirmarContrasena
        '
        Me.txtconfirmarContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconfirmarContrasena.Location = New System.Drawing.Point(105, 110)
        Me.txtconfirmarContrasena.Name = "txtconfirmarContrasena"
        Me.txtconfirmarContrasena.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtconfirmarContrasena.Size = New System.Drawing.Size(185, 20)
        Me.txtconfirmarContrasena.TabIndex = 24
        '
        'lblConfirmaPass
        '
        Me.lblConfirmaPass.AutoSize = True
        Me.lblConfirmaPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmaPass.Location = New System.Drawing.Point(127, 94)
        Me.lblConfirmaPass.Name = "lblConfirmaPass"
        Me.lblConfirmaPass.Size = New System.Drawing.Size(114, 13)
        Me.lblConfirmaPass.TabIndex = 22
        Me.lblConfirmaPass.Text = "* Confirmar contraseña"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(31, 62)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(68, 13)
        Me.lblPass.TabIndex = 21
        Me.lblPass.Text = "* Contraseña"
        '
        'txtEmail
        '
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(105, 62)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(228, 20)
        Me.txtEmail.TabIndex = 20
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(52, 62)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(47, 13)
        Me.lblEmail.TabIndex = 19
        Me.lblEmail.Text = "* e - mail"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(105, 33)
        Me.txtNombre.MaxLength = 100
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(228, 20)
        Me.txtNombre.TabIndex = 18
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(48, 36)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 17
        Me.lblNombre.Text = "* Nombre"
        '
        'txtUsername
        '
        Me.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(105, 33)
        Me.txtUsername.MaxLength = 15
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(185, 20)
        Me.txtUsername.TabIndex = 16
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(49, 36)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(50, 13)
        Me.lblUsuario.TabIndex = 15
        Me.lblUsuario.Text = "* Usuario"
        '
        'gprDatosPersonales
        '
        Me.gprDatosPersonales.Controls.Add(Me.lblIdColaborador)
        Me.gprDatosPersonales.Controls.Add(Me.lblnombreColaborador)
        Me.gprDatosPersonales.Controls.Add(Me.btnColaborador)
        Me.gprDatosPersonales.Controls.Add(Me.Label2)
        Me.gprDatosPersonales.Controls.Add(Me.rdbInactivo)
        Me.gprDatosPersonales.Controls.Add(Me.txtNombre)
        Me.gprDatosPersonales.Controls.Add(Me.lblNombre)
        Me.gprDatosPersonales.Controls.Add(Me.lblEmail)
        Me.gprDatosPersonales.Controls.Add(Me.txtEmail)
        Me.gprDatosPersonales.Controls.Add(Me.rdbActivo)
        Me.gprDatosPersonales.Controls.Add(Me.lblActivo)
        Me.gprDatosPersonales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gprDatosPersonales.Location = New System.Drawing.Point(3, 0)
        Me.gprDatosPersonales.Name = "gprDatosPersonales"
        Me.gprDatosPersonales.Size = New System.Drawing.Size(410, 159)
        Me.gprDatosPersonales.TabIndex = 28
        Me.gprDatosPersonales.TabStop = False
        Me.gprDatosPersonales.Text = "Datos personales"
        '
        'lblIdColaborador
        '
        Me.lblIdColaborador.AutoSize = True
        Me.lblIdColaborador.Location = New System.Drawing.Point(367, 122)
        Me.lblIdColaborador.Name = "lblIdColaborador"
        Me.lblIdColaborador.Size = New System.Drawing.Size(0, 13)
        Me.lblIdColaborador.TabIndex = 32
        Me.lblIdColaborador.Visible = False
        '
        'lblnombreColaborador
        '
        Me.lblnombreColaborador.AutoSize = True
        Me.lblnombreColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombreColaborador.Location = New System.Drawing.Point(141, 124)
        Me.lblnombreColaborador.Name = "lblnombreColaborador"
        Me.lblnombreColaborador.Size = New System.Drawing.Size(19, 13)
        Me.lblnombreColaborador.TabIndex = 31
        Me.lblnombreColaborador.Text = "----"
        '
        'btnColaborador
        '
        Me.btnColaborador.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.colaboradores_32
        Me.btnColaborador.Location = New System.Drawing.Point(105, 118)
        Me.btnColaborador.Name = "btnColaborador"
        Me.btnColaborador.Size = New System.Drawing.Size(25, 25)
        Me.btnColaborador.TabIndex = 30
        Me.btnColaborador.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Colaborador"
        '
        'gprUserPass
        '
        Me.gprUserPass.Controls.Add(Me.txtSicy)
        Me.gprUserPass.Controls.Add(Me.lblSicy)
        Me.gprUserPass.Controls.Add(Me.lblErrorContrasena)
        Me.gprUserPass.Controls.Add(Me.txtUsername)
        Me.gprUserPass.Controls.Add(Me.lblUsuario)
        Me.gprUserPass.Controls.Add(Me.lblPass)
        Me.gprUserPass.Controls.Add(Me.txtContrasena)
        Me.gprUserPass.Controls.Add(Me.txtconfirmarContrasena)
        Me.gprUserPass.Controls.Add(Me.lblConfirmaPass)
        Me.gprUserPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gprUserPass.Location = New System.Drawing.Point(415, 0)
        Me.gprUserPass.Name = "gprUserPass"
        Me.gprUserPass.Size = New System.Drawing.Size(410, 159)
        Me.gprUserPass.TabIndex = 29
        Me.gprUserPass.TabStop = False
        Me.gprUserPass.Text = "Datos del usuario"
        '
        'txtSicy
        '
        Me.txtSicy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSicy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSicy.Location = New System.Drawing.Point(105, 136)
        Me.txtSicy.MaxLength = 50
        Me.txtSicy.Name = "txtSicy"
        Me.txtSicy.Size = New System.Drawing.Size(185, 20)
        Me.txtSicy.TabIndex = 33
        '
        'lblSicy
        '
        Me.lblSicy.AutoSize = True
        Me.lblSicy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSicy.Location = New System.Drawing.Point(68, 136)
        Me.lblSicy.Name = "lblSicy"
        Me.lblSicy.Size = New System.Drawing.Size(31, 13)
        Me.lblSicy.TabIndex = 32
        Me.lblSicy.Text = "SICY"
        '
        'lblErrorContrasena
        '
        Me.lblErrorContrasena.AutoSize = True
        Me.lblErrorContrasena.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorContrasena.ForeColor = System.Drawing.Color.Red
        Me.lblErrorContrasena.Location = New System.Drawing.Point(291, 114)
        Me.lblErrorContrasena.Name = "lblErrorContrasena"
        Me.lblErrorContrasena.Size = New System.Drawing.Size(107, 13)
        Me.lblErrorContrasena.TabIndex = 31
        Me.lblErrorContrasena.Text = "Confirme contraseña."
        Me.lblErrorContrasena.Visible = False
        '
        'grdNaves
        '
        Me.grdNaves.AllowUserToAddRows = False
        Me.grdNaves.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdNaves.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdNaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNaves.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SelectNave})
        Me.grdNaves.Dock = System.Windows.Forms.DockStyle.Right
        Me.grdNaves.Location = New System.Drawing.Point(415, 225)
        Me.grdNaves.Name = "grdNaves"
        Me.grdNaves.RowHeadersVisible = False
        Me.grdNaves.Size = New System.Drawing.Size(413, 361)
        Me.grdNaves.TabIndex = 30
        '
        'SelectNave
        '
        Me.SelectNave.HeaderText = ""
        Me.SelectNave.Name = "SelectNave"
        Me.SelectNave.Width = 50
        '
        'pnlGrupBox
        '
        Me.pnlGrupBox.Controls.Add(Me.gprUserPass)
        Me.pnlGrupBox.Controls.Add(Me.gprDatosPersonales)
        Me.pnlGrupBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlGrupBox.Location = New System.Drawing.Point(0, 60)
        Me.pnlGrupBox.Name = "pnlGrupBox"
        Me.pnlGrupBox.Size = New System.Drawing.Size(828, 165)
        Me.pnlGrupBox.TabIndex = 32
        '
        'grdPerfiles
        '
        Me.grdPerfiles.AllowUserToAddRows = False
        Me.grdPerfiles.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPerfiles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grdPerfiles.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPerfiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selectPerfil})
        Me.grdPerfiles.Dock = System.Windows.Forms.DockStyle.Right
        Me.grdPerfiles.Location = New System.Drawing.Point(2, 225)
        Me.grdPerfiles.Name = "grdPerfiles"
        Me.grdPerfiles.RowHeadersVisible = False
        Me.grdPerfiles.Size = New System.Drawing.Size(413, 361)
        Me.grdPerfiles.TabIndex = 33
        '
        'selectPerfil
        '
        Me.selectPerfil.HeaderText = ""
        Me.selectPerfil.Name = "selectPerfil"
        Me.selectPerfil.Width = 50
        '
        'AltaUsuarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(828, 646)
        Me.Controls.Add(Me.grdPerfiles)
        Me.Controls.Add(Me.grdNaves)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlGrupBox)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaUsuarioForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Usuarios"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.ptbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.gprDatosPersonales.ResumeLayout(False)
        Me.gprDatosPersonales.PerformLayout()
        Me.gprUserPass.ResumeLayout(False)
        Me.gprUserPass.PerformLayout()
        CType(Me.grdNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrupBox.ResumeLayout(False)
        CType(Me.grdPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents rdbInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtContrasena As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtconfirmarContrasena As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblConfirmaPass As System.Windows.Forms.Label
    Friend WithEvents lblPass As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents ptbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents gprDatosPersonales As System.Windows.Forms.GroupBox
    Friend WithEvents gprUserPass As System.Windows.Forms.GroupBox
    Friend WithEvents lblErrorContrasena As System.Windows.Forms.Label
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grdNaves As System.Windows.Forms.DataGridView
    Friend WithEvents pnlGrupBox As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SelectNave As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblnombreColaborador As System.Windows.Forms.Label
    Friend WithEvents btnColaborador As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblIdColaborador As System.Windows.Forms.Label
    Friend WithEvents txtSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblSicy As System.Windows.Forms.Label
    Friend WithEvents grdPerfiles As System.Windows.Forms.DataGridView
    Friend WithEvents selectPerfil As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
