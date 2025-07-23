<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuariosForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.grpBusqueda = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpActivo = New System.Windows.Forms.GroupBox()
        Me.rdbInactivos = New System.Windows.Forms.RadioButton()
        Me.rdbActivo = New System.Windows.Forms.RadioButton()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cmbBusquedaDepartamento = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmbBusquedaPerfil = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaPerfil = New System.Windows.Forms.Label()
        Me.cmbBusquedaNave = New System.Windows.Forms.ComboBox()
        Me.lblBusquedaNave = New System.Windows.Forms.Label()
        Me.txtBusquedaEmail = New System.Windows.Forms.TextBox()
        Me.lblBusquedaEmail = New System.Windows.Forms.Label()
        Me.lblBusquedaNombre = New System.Windows.Forms.Label()
        Me.txtBusquedaNombre = New System.Windows.Forms.TextBox()
        Me.txtBusquedaUsuario = New System.Windows.Forms.TextBox()
        Me.lblBusquedaUsuario = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnOcultar = New System.Windows.Forms.Button()
        Me.colNombreUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBusqueda.SuspendLayout()
        Me.grpActivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblAltas)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Controls.Add(Me.picLogo)
        Me.Panel1.Controls.Add(Me.btnEditar)
        Me.Panel1.Controls.Add(Me.btnAltas)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(837, 70)
        Me.Panel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(214, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Excepciones"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(159, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Perfiles"
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.excepiones_32
        Me.Button2.Location = New System.Drawing.Point(228, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 36)
        Me.Button2.TabIndex = 7
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.perfiles_32
        Me.Button1.Location = New System.Drawing.Point(161, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 36)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(99, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Editar"
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(39, 52)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 4
        Me.lblAltas.Text = "Altas"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(579, 46)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(248, 20)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "Lista de Usuarios del Sistema"
        '
        'picLogo
        '
        Me.picLogo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.yuyin
        Me.picLogo.Location = New System.Drawing.Point(702, 0)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(121, 50)
        Me.picLogo.TabIndex = 2
        Me.picLogo.TabStop = False
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnEditar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.editar_321
        Me.btnEditar.Location = New System.Drawing.Point(96, 12)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(36, 36)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.BackColor = System.Drawing.Color.White
        Me.btnAltas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAltas.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(34, 12)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(36, 36)
        Me.btnAltas.TabIndex = 0
        Me.btnAltas.UseVisualStyleBackColor = False
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNombreUsuario, Me.colNombre, Me.colEmail, Me.colActivo, Me.id})
        Me.dgvUsuarios.GridColor = System.Drawing.Color.SteelBlue
        Me.dgvUsuarios.Location = New System.Drawing.Point(12, 219)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(804, 386)
        Me.dgvUsuarios.TabIndex = 1
        '
        'grpBusqueda
        '
        Me.grpBusqueda.Controls.Add(Me.Label4)
        Me.grpBusqueda.Controls.Add(Me.Label3)
        Me.grpBusqueda.Controls.Add(Me.grpActivo)
        Me.grpBusqueda.Controls.Add(Me.btnLimpiar)
        Me.grpBusqueda.Controls.Add(Me.btnBuscar)
        Me.grpBusqueda.Controls.Add(Me.cmbBusquedaDepartamento)
        Me.grpBusqueda.Controls.Add(Me.lblDepartamento)
        Me.grpBusqueda.Controls.Add(Me.cmbBusquedaPerfil)
        Me.grpBusqueda.Controls.Add(Me.lblBusquedaPerfil)
        Me.grpBusqueda.Controls.Add(Me.cmbBusquedaNave)
        Me.grpBusqueda.Controls.Add(Me.lblBusquedaNave)
        Me.grpBusqueda.Controls.Add(Me.txtBusquedaEmail)
        Me.grpBusqueda.Controls.Add(Me.lblBusquedaEmail)
        Me.grpBusqueda.Controls.Add(Me.lblBusquedaNombre)
        Me.grpBusqueda.Controls.Add(Me.txtBusquedaNombre)
        Me.grpBusqueda.Controls.Add(Me.txtBusquedaUsuario)
        Me.grpBusqueda.Controls.Add(Me.lblBusquedaUsuario)
        Me.grpBusqueda.Controls.Add(Me.btnMostrar)
        Me.grpBusqueda.Controls.Add(Me.btnOcultar)
        Me.grpBusqueda.Location = New System.Drawing.Point(15, 72)
        Me.grpBusqueda.Name = "grpBusqueda"
        Me.grpBusqueda.Size = New System.Drawing.Size(807, 141)
        Me.grpBusqueda.TabIndex = 2
        Me.grpBusqueda.TabStop = False
        Me.grpBusqueda.Text = "Búsqueda"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(754, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Limpiar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(693, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Buscar"
        '
        'grpActivo
        '
        Me.grpActivo.Controls.Add(Me.rdbInactivos)
        Me.grpActivo.Controls.Add(Me.rdbActivo)
        Me.grpActivo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpActivo.Location = New System.Drawing.Point(474, 50)
        Me.grpActivo.Name = "grpActivo"
        Me.grpActivo.Size = New System.Drawing.Size(101, 79)
        Me.grpActivo.TabIndex = 15
        Me.grpActivo.TabStop = False
        '
        'rdbInactivos
        '
        Me.rdbInactivos.AutoSize = True
        Me.rdbInactivos.Location = New System.Drawing.Point(6, 54)
        Me.rdbInactivos.Name = "rdbInactivos"
        Me.rdbInactivos.Size = New System.Drawing.Size(68, 17)
        Me.rdbInactivos.TabIndex = 1
        Me.rdbInactivos.Text = "Inactivos"
        Me.rdbInactivos.UseVisualStyleBackColor = True
        '
        'rdbActivo
        '
        Me.rdbActivo.AutoSize = True
        Me.rdbActivo.Checked = True
        Me.rdbActivo.Location = New System.Drawing.Point(7, 20)
        Me.rdbActivo.Name = "rdbActivo"
        Me.rdbActivo.Size = New System.Drawing.Size(60, 17)
        Me.rdbActivo.TabIndex = 0
        Me.rdbActivo.TabStop = True
        Me.rdbActivo.Text = "Activos"
        Me.rdbActivo.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(755, 79)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(36, 36)
        Me.btnLimpiar.TabIndex = 14
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(694, 79)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(36, 36)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cmbBusquedaDepartamento
        '
        Me.cmbBusquedaDepartamento.FormattingEnabled = True
        Me.cmbBusquedaDepartamento.Location = New System.Drawing.Point(307, 79)
        Me.cmbBusquedaDepartamento.Name = "cmbBusquedaDepartamento"
        Me.cmbBusquedaDepartamento.Size = New System.Drawing.Size(121, 21)
        Me.cmbBusquedaDepartamento.TabIndex = 13
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(226, 82)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(74, 13)
        Me.lblDepartamento.TabIndex = 12
        Me.lblDepartamento.Text = "Departamento"
        '
        'cmbBusquedaPerfil
        '
        Me.cmbBusquedaPerfil.FormattingEnabled = True
        Me.cmbBusquedaPerfil.Location = New System.Drawing.Point(307, 108)
        Me.cmbBusquedaPerfil.Name = "cmbBusquedaPerfil"
        Me.cmbBusquedaPerfil.Size = New System.Drawing.Size(121, 21)
        Me.cmbBusquedaPerfil.TabIndex = 11
        '
        'lblBusquedaPerfil
        '
        Me.lblBusquedaPerfil.AutoSize = True
        Me.lblBusquedaPerfil.Location = New System.Drawing.Point(226, 111)
        Me.lblBusquedaPerfil.Name = "lblBusquedaPerfil"
        Me.lblBusquedaPerfil.Size = New System.Drawing.Size(30, 13)
        Me.lblBusquedaPerfil.TabIndex = 10
        Me.lblBusquedaPerfil.Text = "Perfil"
        '
        'cmbBusquedaNave
        '
        Me.cmbBusquedaNave.FormattingEnabled = True
        Me.cmbBusquedaNave.Location = New System.Drawing.Point(307, 50)
        Me.cmbBusquedaNave.Name = "cmbBusquedaNave"
        Me.cmbBusquedaNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbBusquedaNave.TabIndex = 9
        '
        'lblBusquedaNave
        '
        Me.lblBusquedaNave.AutoSize = True
        Me.lblBusquedaNave.Location = New System.Drawing.Point(226, 53)
        Me.lblBusquedaNave.Name = "lblBusquedaNave"
        Me.lblBusquedaNave.Size = New System.Drawing.Size(33, 13)
        Me.lblBusquedaNave.TabIndex = 8
        Me.lblBusquedaNave.Text = "Nave"
        '
        'txtBusquedaEmail
        '
        Me.txtBusquedaEmail.Location = New System.Drawing.Point(73, 109)
        Me.txtBusquedaEmail.Name = "txtBusquedaEmail"
        Me.txtBusquedaEmail.Size = New System.Drawing.Size(131, 20)
        Me.txtBusquedaEmail.TabIndex = 7
        '
        'lblBusquedaEmail
        '
        Me.lblBusquedaEmail.AutoSize = True
        Me.lblBusquedaEmail.Location = New System.Drawing.Point(24, 111)
        Me.lblBusquedaEmail.Name = "lblBusquedaEmail"
        Me.lblBusquedaEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblBusquedaEmail.TabIndex = 6
        Me.lblBusquedaEmail.Text = "Email"
        '
        'lblBusquedaNombre
        '
        Me.lblBusquedaNombre.AutoSize = True
        Me.lblBusquedaNombre.Location = New System.Drawing.Point(24, 82)
        Me.lblBusquedaNombre.Name = "lblBusquedaNombre"
        Me.lblBusquedaNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblBusquedaNombre.TabIndex = 5
        Me.lblBusquedaNombre.Text = "Nombre"
        '
        'txtBusquedaNombre
        '
        Me.txtBusquedaNombre.Location = New System.Drawing.Point(73, 79)
        Me.txtBusquedaNombre.Name = "txtBusquedaNombre"
        Me.txtBusquedaNombre.Size = New System.Drawing.Size(131, 20)
        Me.txtBusquedaNombre.TabIndex = 4
        '
        'txtBusquedaUsuario
        '
        Me.txtBusquedaUsuario.Location = New System.Drawing.Point(73, 50)
        Me.txtBusquedaUsuario.Name = "txtBusquedaUsuario"
        Me.txtBusquedaUsuario.Size = New System.Drawing.Size(131, 20)
        Me.txtBusquedaUsuario.TabIndex = 3
        '
        'lblBusquedaUsuario
        '
        Me.lblBusquedaUsuario.AutoSize = True
        Me.lblBusquedaUsuario.Location = New System.Drawing.Point(24, 53)
        Me.lblBusquedaUsuario.Name = "lblBusquedaUsuario"
        Me.lblBusquedaUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblBusquedaUsuario.TabIndex = 2
        Me.lblBusquedaUsuario.Text = "Usuario"
        '
        'btnMostrar
        '
        Me.btnMostrar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnMostrar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources._1373584074_navigate_down
        Me.btnMostrar.Location = New System.Drawing.Point(776, 11)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(25, 23)
        Me.btnMostrar.TabIndex = 1
        Me.btnMostrar.UseVisualStyleBackColor = False
        '
        'btnOcultar
        '
        Me.btnOcultar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnOcultar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources._1373584033_navigate_up
        Me.btnOcultar.Location = New System.Drawing.Point(744, 11)
        Me.btnOcultar.Name = "btnOcultar"
        Me.btnOcultar.Size = New System.Drawing.Size(26, 23)
        Me.btnOcultar.TabIndex = 0
        Me.btnOcultar.UseVisualStyleBackColor = False
        '
        'colNombreUsuario
        '
        Me.colNombreUsuario.FillWeight = 269.0722!
        Me.colNombreUsuario.HeaderText = "Usuario"
        Me.colNombreUsuario.Name = "colNombreUsuario"
        Me.colNombreUsuario.Width = 144
        '
        'colNombre
        '
        Me.colNombre.FillWeight = 15.46391!
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Width = 80
        '
        'colEmail
        '
        Me.colEmail.FillWeight = 15.46391!
        Me.colEmail.HeaderText = "Email"
        Me.colEmail.Name = "colEmail"
        Me.colEmail.Width = 200
        '
        'colActivo
        '
        Me.colActivo.HeaderText = "Activo"
        Me.colActivo.Name = "colActivo"
        Me.colActivo.Width = 50
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'UsuariosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(830, 612)
        Me.Controls.Add(Me.grpBusqueda)
        Me.Controls.Add(Me.dgvUsuarios)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UsuariosForm"
        Me.Text = "Listado de Usuarios del Sistema"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBusqueda.ResumeLayout(False)
        Me.grpBusqueda.PerformLayout()
        Me.grpActivo.ResumeLayout(False)
        Me.grpActivo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents grpBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents btnOcultar As System.Windows.Forms.Button
    Friend WithEvents lblBusquedaUsuario As System.Windows.Forms.Label
    Friend WithEvents cmbBusquedaDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmbBusquedaPerfil As System.Windows.Forms.ComboBox
    Friend WithEvents lblBusquedaPerfil As System.Windows.Forms.Label
    Friend WithEvents cmbBusquedaNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblBusquedaNave As System.Windows.Forms.Label
    Friend WithEvents txtBusquedaEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblBusquedaEmail As System.Windows.Forms.Label
    Friend WithEvents lblBusquedaNombre As System.Windows.Forms.Label
    Friend WithEvents txtBusquedaNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtBusquedaUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents grpActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdbInactivos As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivo As System.Windows.Forms.RadioButton
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colNombreUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
