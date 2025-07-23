<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaModulosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaModulosForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaModulos = New System.Windows.Forms.Label()
        Me.lblAcciones = New System.Windows.Forms.Label()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAcciones = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.txtNombreDelModulo = New System.Windows.Forms.TextBox()
        Me.lblNombreDelModulo = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.lblComponente = New System.Windows.Forms.Label()
        Me.lblGuardarHistorial = New System.Windows.Forms.Label()
        Me.lblMostarEnMenu = New System.Windows.Forms.Label()
        Me.lblModuloSuperior = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.grbMostarEnMenu = New System.Windows.Forms.GroupBox()
        Me.rdoMenu = New System.Windows.Forms.RadioButton()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.grbGuardarHistorial = New System.Windows.Forms.GroupBox()
        Me.rdoGuardarHistorial = New System.Windows.Forms.RadioButton()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.grdModulos = New System.Windows.Forms.DataGridView()
        Me.ColNombreModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColModuloSuperior = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColClave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColComponente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMostrarEnMenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGuardarHistorial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.grbBusqueda = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.cmbModuloSuperior = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbMostarEnMenu.SuspendLayout()
        Me.grbGuardarHistorial.SuspendLayout()
        CType(Me.grdModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbBusqueda.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblListaModulos)
        Me.pnlEncabezado.Controls.Add(Me.lblAcciones)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAcciones)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Location = New System.Drawing.Point(-5, 2)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(946, 67)
        Me.pnlEncabezado.TabIndex = 0
        '
        'lblListaModulos
        '
        Me.lblListaModulos.AutoSize = True
        Me.lblListaModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaModulos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaModulos.Location = New System.Drawing.Point(772, 45)
        Me.lblListaModulos.Name = "lblListaModulos"
        Me.lblListaModulos.Size = New System.Drawing.Size(145, 20)
        Me.lblListaModulos.TabIndex = 21
        Me.lblListaModulos.Text = "Lista de Módulos"
        '
        'lblAcciones
        '
        Me.lblAcciones.AutoSize = True
        Me.lblAcciones.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAcciones.Location = New System.Drawing.Point(104, 47)
        Me.lblAcciones.Name = "lblAcciones"
        Me.lblAcciones.Size = New System.Drawing.Size(51, 13)
        Me.lblAcciones.TabIndex = 20
        Me.lblAcciones.Text = "Acciones"
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(64, 47)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 19
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(64, 12)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAcciones
        '
        Me.btnAcciones.Image = CType(resources.GetObject("btnAcciones.Image"), System.Drawing.Image)
        Me.btnAcciones.Location = New System.Drawing.Point(112, 12)
        Me.btnAcciones.Name = "btnAcciones"
        Me.btnAcciones.Size = New System.Drawing.Size(32, 32)
        Me.btnAcciones.TabIndex = 3
        Me.btnAcciones.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 12)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 47)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(792, 3)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(129, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'txtNombreDelModulo
        '
        Me.txtNombreDelModulo.Location = New System.Drawing.Point(172, 52)
        Me.txtNombreDelModulo.MaxLength = 50
        Me.txtNombreDelModulo.Name = "txtNombreDelModulo"
        Me.txtNombreDelModulo.Size = New System.Drawing.Size(100, 20)
        Me.txtNombreDelModulo.TabIndex = 4
        '
        'lblNombreDelModulo
        '
        Me.lblNombreDelModulo.AutoSize = True
        Me.lblNombreDelModulo.Location = New System.Drawing.Point(68, 52)
        Me.lblNombreDelModulo.Name = "lblNombreDelModulo"
        Me.lblNombreDelModulo.Size = New System.Drawing.Size(98, 13)
        Me.lblNombreDelModulo.TabIndex = 2
        Me.lblNombreDelModulo.Text = "Nombre del módulo"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(367, 55)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(34, 13)
        Me.lblClave.TabIndex = 3
        Me.lblClave.Text = "Clave"
        '
        'lblComponente
        '
        Me.lblComponente.AutoSize = True
        Me.lblComponente.Location = New System.Drawing.Point(71, 139)
        Me.lblComponente.Name = "lblComponente"
        Me.lblComponente.Size = New System.Drawing.Size(67, 13)
        Me.lblComponente.TabIndex = 4
        Me.lblComponente.Text = "Componente"
        '
        'lblGuardarHistorial
        '
        Me.lblGuardarHistorial.AutoSize = True
        Me.lblGuardarHistorial.Location = New System.Drawing.Point(316, 139)
        Me.lblGuardarHistorial.Name = "lblGuardarHistorial"
        Me.lblGuardarHistorial.Size = New System.Drawing.Size(85, 13)
        Me.lblGuardarHistorial.TabIndex = 5
        Me.lblGuardarHistorial.Text = "Guardar Historial"
        '
        'lblMostarEnMenu
        '
        Me.lblMostarEnMenu.AutoSize = True
        Me.lblMostarEnMenu.Location = New System.Drawing.Point(542, 96)
        Me.lblMostarEnMenu.Name = "lblMostarEnMenu"
        Me.lblMostarEnMenu.Size = New System.Drawing.Size(83, 13)
        Me.lblMostarEnMenu.TabIndex = 6
        Me.lblMostarEnMenu.Text = "Mostar en menú"
        '
        'lblModuloSuperior
        '
        Me.lblModuloSuperior.AutoSize = True
        Me.lblModuloSuperior.Location = New System.Drawing.Point(68, 96)
        Me.lblModuloSuperior.Name = "lblModuloSuperior"
        Me.lblModuloSuperior.Size = New System.Drawing.Size(82, 13)
        Me.lblModuloSuperior.TabIndex = 7
        Me.lblModuloSuperior.Text = "Módulo superior"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(417, 52)
        Me.txtClave.MaxLength = 50
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(100, 20)
        Me.txtClave.TabIndex = 13
        '
        'txtComponente
        '
        Me.txtComponente.Location = New System.Drawing.Point(172, 136)
        Me.txtComponente.MaxLength = 50
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(100, 20)
        Me.txtComponente.TabIndex = 6
        '
        'grbMostarEnMenu
        '
        Me.grbMostarEnMenu.Controls.Add(Me.rdoMenu)
        Me.grbMostarEnMenu.Controls.Add(Me.rdoNo)
        Me.grbMostarEnMenu.Location = New System.Drawing.Point(631, 80)
        Me.grbMostarEnMenu.Name = "grbMostarEnMenu"
        Me.grbMostarEnMenu.Size = New System.Drawing.Size(100, 34)
        Me.grbMostarEnMenu.TabIndex = 7
        Me.grbMostarEnMenu.TabStop = False
        '
        'rdoMenu
        '
        Me.rdoMenu.AutoSize = True
        Me.rdoMenu.Checked = True
        Me.rdoMenu.Location = New System.Drawing.Point(6, 12)
        Me.rdoMenu.Name = "rdoMenu"
        Me.rdoMenu.Size = New System.Drawing.Size(36, 17)
        Me.rdoMenu.TabIndex = 8
        Me.rdoMenu.TabStop = True
        Me.rdoMenu.Text = "Sí"
        Me.rdoMenu.UseVisualStyleBackColor = True
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(56, 11)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 9
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'grbGuardarHistorial
        '
        Me.grbGuardarHistorial.Controls.Add(Me.rdoGuardarHistorial)
        Me.grbGuardarHistorial.Controls.Add(Me.rdoInactivo)
        Me.grbGuardarHistorial.Location = New System.Drawing.Point(417, 125)
        Me.grbGuardarHistorial.Name = "grbGuardarHistorial"
        Me.grbGuardarHistorial.Size = New System.Drawing.Size(100, 34)
        Me.grbGuardarHistorial.TabIndex = 10
        Me.grbGuardarHistorial.TabStop = False
        '
        'rdoGuardarHistorial
        '
        Me.rdoGuardarHistorial.AutoSize = True
        Me.rdoGuardarHistorial.Location = New System.Drawing.Point(6, 12)
        Me.rdoGuardarHistorial.Name = "rdoGuardarHistorial"
        Me.rdoGuardarHistorial.Size = New System.Drawing.Size(36, 17)
        Me.rdoGuardarHistorial.TabIndex = 11
        Me.rdoGuardarHistorial.Text = "Sí"
        Me.rdoGuardarHistorial.UseVisualStyleBackColor = True
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(56, 11)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 12
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'grdModulos
        '
        Me.grdModulos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdModulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNombreModulo, Me.ColModuloSuperior, Me.ColClave, Me.ColComponente, Me.ColMostrarEnMenu, Me.ColGuardarHistorial, Me.ColActivo, Me.colId})
        Me.grdModulos.GridColor = System.Drawing.Color.SteelBlue
        Me.grdModulos.Location = New System.Drawing.Point(10, 258)
        Me.grdModulos.Name = "grdModulos"
        Me.grdModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdModulos.Size = New System.Drawing.Size(915, 364)
        Me.grdModulos.TabIndex = 16
        '
        'ColNombreModulo
        '
        Me.ColNombreModulo.HeaderText = "Nombre del módulo"
        Me.ColNombreModulo.Name = "ColNombreModulo"
        '
        'ColModuloSuperior
        '
        Me.ColModuloSuperior.HeaderText = "Módulo Superior"
        Me.ColModuloSuperior.Name = "ColModuloSuperior"
        '
        'ColClave
        '
        Me.ColClave.HeaderText = "Clave"
        Me.ColClave.Name = "ColClave"
        '
        'ColComponente
        '
        Me.ColComponente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColComponente.HeaderText = "Componente"
        Me.ColComponente.Name = "ColComponente"
        '
        'ColMostrarEnMenu
        '
        Me.ColMostrarEnMenu.HeaderText = "Mostrar En Menu"
        Me.ColMostrarEnMenu.Name = "ColMostrarEnMenu"
        '
        'ColGuardarHistorial
        '
        Me.ColGuardarHistorial.HeaderText = "Guardar historial"
        Me.ColGuardarHistorial.Name = "ColGuardarHistorial"
        '
        'ColActivo
        '
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.Name = "ColActivo"
        '
        'colId
        '
        Me.colId.HeaderText = "Id"
        Me.colId.Name = "colId"
        Me.colId.Visible = False
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(854, 149)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 17
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(804, 149)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBúscar.TabIndex = 18
        Me.lblBúscar.Text = "Búscar"
        '
        'grbBusqueda
        '
        Me.grbBusqueda.Controls.Add(Me.Label1)
        Me.grbBusqueda.Controls.Add(Me.txtArchivo)
        Me.grbBusqueda.Controls.Add(Me.GroupBox1)
        Me.grbBusqueda.Controls.Add(Me.lblActivo)
        Me.grbBusqueda.Controls.Add(Me.cmbModuloSuperior)
        Me.grbBusqueda.Controls.Add(Me.btnAbajo)
        Me.grbBusqueda.Controls.Add(Me.btnArriba)
        Me.grbBusqueda.Controls.Add(Me.lblMostarEnMenu)
        Me.grbBusqueda.Controls.Add(Me.lblBúscar)
        Me.grbBusqueda.Controls.Add(Me.txtNombreDelModulo)
        Me.grbBusqueda.Controls.Add(Me.lblLimpiar)
        Me.grbBusqueda.Controls.Add(Me.lblNombreDelModulo)
        Me.grbBusqueda.Controls.Add(Me.btnLimpiar)
        Me.grbBusqueda.Controls.Add(Me.lblClave)
        Me.grbBusqueda.Controls.Add(Me.btnBuscar)
        Me.grbBusqueda.Controls.Add(Me.lblComponente)
        Me.grbBusqueda.Controls.Add(Me.lblGuardarHistorial)
        Me.grbBusqueda.Controls.Add(Me.grbGuardarHistorial)
        Me.grbBusqueda.Controls.Add(Me.lblModuloSuperior)
        Me.grbBusqueda.Controls.Add(Me.grbMostarEnMenu)
        Me.grbBusqueda.Controls.Add(Me.txtClave)
        Me.grbBusqueda.Controls.Add(Me.txtComponente)
        Me.grbBusqueda.Location = New System.Drawing.Point(10, 75)
        Me.grbBusqueda.Name = "grbBusqueda"
        Me.grbBusqueda.Size = New System.Drawing.Size(915, 177)
        Me.grbBusqueda.TabIndex = 19
        Me.grbBusqueda.TabStop = False
        Me.grbBusqueda.Text = "Búsqueda"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdoActivo)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Location = New System.Drawing.Point(631, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(100, 34)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(6, 12)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(36, 17)
        Me.rdoActivo.TabIndex = 8
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Sí"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(56, 11)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton2.TabIndex = 9
        Me.RadioButton2.Text = "No"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(588, 59)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 19
        Me.lblActivo.Text = "Activo"
        '
        'cmbModuloSuperior
        '
        Me.cmbModuloSuperior.FormattingEnabled = True
        Me.cmbModuloSuperior.Location = New System.Drawing.Point(172, 93)
        Me.cmbModuloSuperior.MaxLength = 50
        Me.cmbModuloSuperior.Name = "cmbModuloSuperior"
        Me.cmbModuloSuperior.Size = New System.Drawing.Size(100, 21)
        Me.cmbModuloSuperior.TabIndex = 5
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(888, 9)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 18
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(857, 9)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 17
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(857, 115)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 15
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(807, 115)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(317, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Archivo Reporte"
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(417, 93)
        Me.txtArchivo.MaxLength = 50
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(100, 20)
        Me.txtArchivo.TabIndex = 22
        '
        'ListaModulosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(937, 634)
        Me.Controls.Add(Me.grbBusqueda)
        Me.Controls.Add(Me.grdModulos)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaModulosForm"
        Me.Text = "Lista Módulos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbMostarEnMenu.ResumeLayout(False)
        Me.grbMostarEnMenu.PerformLayout()
        Me.grbGuardarHistorial.ResumeLayout(False)
        Me.grbGuardarHistorial.PerformLayout()
        CType(Me.grdModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbBusqueda.ResumeLayout(False)
        Me.grbBusqueda.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaModulos As System.Windows.Forms.Label
    Friend WithEvents lblAcciones As System.Windows.Forms.Label
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAcciones As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents txtNombreDelModulo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreDelModulo As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents lblComponente As System.Windows.Forms.Label
    Friend WithEvents lblGuardarHistorial As System.Windows.Forms.Label
    Friend WithEvents lblMostarEnMenu As System.Windows.Forms.Label
    Friend WithEvents lblModuloSuperior As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents grbMostarEnMenu As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMenu As System.Windows.Forms.RadioButton
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents grbGuardarHistorial As System.Windows.Forms.GroupBox
    Friend WithEvents rdoGuardarHistorial As System.Windows.Forms.RadioButton
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents grdModulos As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents grbBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents cmbModuloSuperior As System.Windows.Forms.ComboBox
    Friend WithEvents ColNombreModulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColModuloSuperior As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColClave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColComponente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMostrarEnMenu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGuardarHistorial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
End Class
