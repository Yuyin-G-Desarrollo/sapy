<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColeccionesNuevas_VigentesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColeccionesNuevas_VigentesForm))
        Me.grpTiposDeTienda = New System.Windows.Forms.GroupBox()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.cmbCargo = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblNombreClasificacionCliente = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezadoCatalogoClasificacionCliente = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFechaConsulta = New System.Windows.Forms.Label()
        Me.lblPedidosContados = New System.Windows.Forms.Label()
        Me.lblSeleccionados = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.grpTiposDeTienda.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpTiposDeTienda
        '
        Me.grpTiposDeTienda.Controls.Add(Me.chkSeleccionar)
        Me.grpTiposDeTienda.Controls.Add(Me.RadioButton1)
        Me.grpTiposDeTienda.Controls.Add(Me.rbtnCliente)
        Me.grpTiposDeTienda.Controls.Add(Me.Label2)
        Me.grpTiposDeTienda.Controls.Add(Me.ComboBox1)
        Me.grpTiposDeTienda.Controls.Add(Me.Label1)
        Me.grpTiposDeTienda.Controls.Add(Me.txtNombre)
        Me.grpTiposDeTienda.Controls.Add(Me.cmbCargo)
        Me.grpTiposDeTienda.Controls.Add(Me.btnAbajo)
        Me.grpTiposDeTienda.Controls.Add(Me.btnArriba)
        Me.grpTiposDeTienda.Controls.Add(Me.lblNombreClasificacionCliente)
        Me.grpTiposDeTienda.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTiposDeTienda.Location = New System.Drawing.Point(0, 55)
        Me.grpTiposDeTienda.Name = "grpTiposDeTienda"
        Me.grpTiposDeTienda.Size = New System.Drawing.Size(658, 165)
        Me.grpTiposDeTienda.TabIndex = 82
        Me.grpTiposDeTienda.TabStop = False
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(8, 144)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionar.TabIndex = 65
        Me.chkSeleccionar.Text = "Seleccionar todo"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(338, 119)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(66, 17)
        Me.RadioButton1.TabIndex = 33
        Me.RadioButton1.Text = "Vigentes"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbtnCliente
        '
        Me.rbtnCliente.AutoSize = True
        Me.rbtnCliente.Checked = True
        Me.rbtnCliente.ForeColor = System.Drawing.Color.Black
        Me.rbtnCliente.Location = New System.Drawing.Point(241, 119)
        Me.rbtnCliente.Name = "rbtnCliente"
        Me.rbtnCliente.Size = New System.Drawing.Size(62, 17)
        Me.rbtnCliente.TabIndex = 32
        Me.rbtnCliente.TabStop = True
        Me.rbtnCliente.Text = "Nuevas"
        Me.rbtnCliente.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 13)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Clasificar como Colecciones "
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(170, 89)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(418, 21)
        Me.ComboBox1.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Temporada"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(170, 63)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(418, 20)
        Me.txtNombre.TabIndex = 28
        Me.txtNombre.Text = "POLIFORUM LEÓN - DEL 16/08/2016 AL 19/08/2016"
        '
        'cmbCargo
        '
        Me.cmbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCargo.FormattingEnabled = True
        Me.cmbCargo.Location = New System.Drawing.Point(170, 38)
        Me.cmbCargo.Name = "cmbCargo"
        Me.cmbCargo.Size = New System.Drawing.Size(418, 21)
        Me.cmbCargo.TabIndex = 27
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(630, 13)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 7
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(606, 13)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 6
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblNombreClasificacionCliente
        '
        Me.lblNombreClasificacionCliente.AutoSize = True
        Me.lblNombreClasificacionCliente.Location = New System.Drawing.Point(71, 41)
        Me.lblNombreClasificacionCliente.Name = "lblNombreClasificacionCliente"
        Me.lblNombreClasificacionCliente.Size = New System.Drawing.Size(48, 13)
        Me.lblNombreClasificacionCliente.TabIndex = 7
        Me.lblNombreClasificacionCliente.Text = "* Evento"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezadoCatalogoClasificacionCliente)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(658, 55)
        Me.pnlEncabezado.TabIndex = 81
        '
        'lblEncabezadoCatalogoClasificacionCliente
        '
        Me.lblEncabezadoCatalogoClasificacionCliente.AutoSize = True
        Me.lblEncabezadoCatalogoClasificacionCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezadoCatalogoClasificacionCliente.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezadoCatalogoClasificacionCliente.Location = New System.Drawing.Point(193, 19)
        Me.lblEncabezadoCatalogoClasificacionCliente.Name = "lblEncabezadoCatalogoClasificacionCliente"
        Me.lblEncabezadoCatalogoClasificacionCliente.Size = New System.Drawing.Size(397, 20)
        Me.lblEncabezadoCatalogoClasificacionCliente.TabIndex = 21
        Me.lblEncabezadoCatalogoClasificacionCliente.Text = "Identificación de Colecciones Nuevas y Vigentes"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblFechaConsulta)
        Me.Panel2.Controls.Add(Me.lblPedidosContados)
        Me.Panel2.Controls.Add(Me.lblSeleccionados)
        Me.Panel2.Controls.Add(Me.lblRegistros)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 479)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(658, 60)
        Me.Panel2.TabIndex = 83
        '
        'lblFechaConsulta
        '
        Me.lblFechaConsulta.AutoSize = True
        Me.lblFechaConsulta.Location = New System.Drawing.Point(802, 16)
        Me.lblFechaConsulta.Name = "lblFechaConsulta"
        Me.lblFechaConsulta.Size = New System.Drawing.Size(0, 13)
        Me.lblFechaConsulta.TabIndex = 14
        '
        'lblPedidosContados
        '
        Me.lblPedidosContados.AutoSize = True
        Me.lblPedidosContados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidosContados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPedidosContados.Location = New System.Drawing.Point(50, 34)
        Me.lblPedidosContados.Name = "lblPedidosContados"
        Me.lblPedidosContados.Size = New System.Drawing.Size(21, 24)
        Me.lblPedidosContados.TabIndex = 10
        Me.lblPedidosContados.Text = "0"
        '
        'lblSeleccionados
        '
        Me.lblSeleccionados.AutoSize = True
        Me.lblSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccionados.Location = New System.Drawing.Point(9, 20)
        Me.lblSeleccionados.Name = "lblSeleccionados"
        Me.lblSeleccionados.Size = New System.Drawing.Size(110, 16)
        Me.lblSeleccionados.TabIndex = 11
        Me.lblSeleccionados.Text = "seleccionados"
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.Location = New System.Drawing.Point(23, 4)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(75, 16)
        Me.lblRegistros.TabIndex = 9
        Me.lblRegistros.Text = "Registros"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.Button2)
        Me.pnlAcciones.Controls.Add(Me.Label4)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.lblMostrar)
        Me.pnlAcciones.Controls.Add(Me.Button1)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(412, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(246, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.Button2.Location = New System.Drawing.Point(29, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 26
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(24, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Guardar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Enabled = False
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(83, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 0
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(78, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 25
        Me.lblMostrar.Text = "Mostrar"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.Button1.Location = New System.Drawing.Point(139, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(135, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Limpiar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Enabled = False
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(191, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(190, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(588, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 55)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'ColeccionesNuevas_VigentesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(658, 539)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grpTiposDeTienda)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ColeccionesNuevas_VigentesForm"
        Me.Text = "Identificación de Colecciones Nuevas y Vigentes"
        Me.grpTiposDeTienda.ResumeLayout(False)
        Me.grpTiposDeTienda.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpTiposDeTienda As System.Windows.Forms.GroupBox
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblNombreClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezadoCatalogoClasificacionCliente As System.Windows.Forms.Label
    Friend WithEvents cmbCargo As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCliente As System.Windows.Forms.RadioButton
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblFechaConsulta As System.Windows.Forms.Label
    Friend WithEvents lblPedidosContados As System.Windows.Forms.Label
    Friend WithEvents lblSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents imgLogo As PictureBox
End Class
