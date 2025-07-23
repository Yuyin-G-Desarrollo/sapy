<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaPermisoForm
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaPermisoForm))
		Me.pnlEncabezado = New System.Windows.Forms.Panel()
		Me.lblEliminar = New System.Windows.Forms.Label()
		Me.btnEliminar = New System.Windows.Forms.Button()
		Me.lblListaPermisos = New System.Windows.Forms.Label()
		Me.btnAltas = New System.Windows.Forms.Button()
		Me.lblAltas = New System.Windows.Forms.Label()
		Me.imgLogo = New System.Windows.Forms.PictureBox()
		Me.lblModulo = New System.Windows.Forms.Label()
		Me.lblAccion = New System.Windows.Forms.Label()
		Me.grbPermisos = New System.Windows.Forms.GroupBox()
		Me.cmbModulo = New System.Windows.Forms.ComboBox()
		Me.cmbAccion = New System.Windows.Forms.ComboBox()
		Me.btnAbajo = New System.Windows.Forms.Button()
		Me.btnArriba = New System.Windows.Forms.Button()
		Me.lblPerfil = New System.Windows.Forms.Label()
		Me.cmbPerfil = New System.Windows.Forms.ComboBox()
		Me.lblBúscar = New System.Windows.Forms.Label()
		Me.lblLimpiar = New System.Windows.Forms.Label()
		Me.btnLimpiar = New System.Windows.Forms.Button()
		Me.btnBuscar = New System.Windows.Forms.Button()
		Me.grdPermisos = New System.Windows.Forms.DataGridView()
		Me.ColModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColModuloid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColAccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColAccionid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColPerfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.ColPerfilid = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.pnlEncabezado.SuspendLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grbPermisos.SuspendLayout()
		CType(Me.grdPermisos, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'pnlEncabezado
		'
		Me.pnlEncabezado.BackColor = System.Drawing.Color.White
		Me.pnlEncabezado.Controls.Add(Me.lblEliminar)
		Me.pnlEncabezado.Controls.Add(Me.btnEliminar)
		Me.pnlEncabezado.Controls.Add(Me.lblListaPermisos)
		Me.pnlEncabezado.Controls.Add(Me.btnAltas)
		Me.pnlEncabezado.Controls.Add(Me.lblAltas)
		Me.pnlEncabezado.Controls.Add(Me.imgLogo)
		Me.pnlEncabezado.Location = New System.Drawing.Point(4, 3)
		Me.pnlEncabezado.Name = "pnlEncabezado"
		Me.pnlEncabezado.Size = New System.Drawing.Size(477, 67)
		Me.pnlEncabezado.TabIndex = 2
		'
		'lblEliminar
		'
		Me.lblEliminar.AutoSize = True
		Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblEliminar.Location = New System.Drawing.Point(62, 47)
		Me.lblEliminar.Name = "lblEliminar"
		Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
		Me.lblEliminar.TabIndex = 33
		Me.lblEliminar.Text = "Eliminar"
		'
		'btnEliminar
		'
		Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
		Me.btnEliminar.Location = New System.Drawing.Point(65, 12)
		Me.btnEliminar.Name = "btnEliminar"
		Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
		Me.btnEliminar.TabIndex = 2
		Me.btnEliminar.UseVisualStyleBackColor = True
		'
		'lblListaPermisos
		'
		Me.lblListaPermisos.AutoSize = True
		Me.lblListaPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblListaPermisos.ForeColor = System.Drawing.Color.SteelBlue
		Me.lblListaPermisos.Location = New System.Drawing.Point(388, 42)
		Me.lblListaPermisos.Name = "lblListaPermisos"
		Me.lblListaPermisos.Size = New System.Drawing.Size(82, 20)
		Me.lblListaPermisos.TabIndex = 21
		Me.lblListaPermisos.Text = "Permisos"
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
		Me.imgLogo.Location = New System.Drawing.Point(343, 1)
		Me.imgLogo.Name = "imgLogo"
		Me.imgLogo.Size = New System.Drawing.Size(129, 59)
		Me.imgLogo.TabIndex = 0
		Me.imgLogo.TabStop = False
		'
		'lblModulo
		'
		Me.lblModulo.AutoSize = True
		Me.lblModulo.Location = New System.Drawing.Point(79, 53)
		Me.lblModulo.Name = "lblModulo"
		Me.lblModulo.Size = New System.Drawing.Size(42, 13)
		Me.lblModulo.TabIndex = 3
		Me.lblModulo.Text = "Módulo"
		'
		'lblAccion
		'
		Me.lblAccion.AutoSize = True
		Me.lblAccion.Location = New System.Drawing.Point(79, 88)
		Me.lblAccion.Name = "lblAccion"
		Me.lblAccion.Size = New System.Drawing.Size(40, 13)
		Me.lblAccion.TabIndex = 7
		Me.lblAccion.Text = "Acción"
		'
		'grbPermisos
		'
		Me.grbPermisos.Controls.Add(Me.cmbModulo)
		Me.grbPermisos.Controls.Add(Me.cmbAccion)
		Me.grbPermisos.Controls.Add(Me.btnAbajo)
		Me.grbPermisos.Controls.Add(Me.btnArriba)
		Me.grbPermisos.Controls.Add(Me.lblPerfil)
		Me.grbPermisos.Controls.Add(Me.cmbPerfil)
		Me.grbPermisos.Controls.Add(Me.lblBúscar)
		Me.grbPermisos.Controls.Add(Me.lblLimpiar)
		Me.grbPermisos.Controls.Add(Me.btnLimpiar)
		Me.grbPermisos.Controls.Add(Me.btnBuscar)
		Me.grbPermisos.Controls.Add(Me.lblModulo)
		Me.grbPermisos.Controls.Add(Me.lblAccion)
		Me.grbPermisos.Location = New System.Drawing.Point(9, 76)
		Me.grbPermisos.Name = "grbPermisos"
		Me.grbPermisos.Size = New System.Drawing.Size(461, 169)
		Me.grbPermisos.TabIndex = 9
		Me.grbPermisos.TabStop = False
		'
		'cmbModulo
		'
		Me.cmbModulo.FormattingEnabled = True
		Me.cmbModulo.Location = New System.Drawing.Point(146, 50)
		Me.cmbModulo.Name = "cmbModulo"
		Me.cmbModulo.Size = New System.Drawing.Size(155, 21)
		Me.cmbModulo.TabIndex = 36
		'
		'cmbAccion
		'
		Me.cmbAccion.FormattingEnabled = True
		Me.cmbAccion.Location = New System.Drawing.Point(146, 85)
		Me.cmbAccion.Name = "cmbAccion"
		Me.cmbAccion.Size = New System.Drawing.Size(155, 21)
		Me.cmbAccion.TabIndex = 35
		'
		'btnAbajo
		'
		Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
		Me.btnAbajo.Location = New System.Drawing.Point(433, 14)
		Me.btnAbajo.Name = "btnAbajo"
		Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
		Me.btnAbajo.TabIndex = 34
		Me.btnAbajo.UseVisualStyleBackColor = True
		'
		'btnArriba
		'
		Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
		Me.btnArriba.Location = New System.Drawing.Point(402, 13)
		Me.btnArriba.Name = "btnArriba"
		Me.btnArriba.Size = New System.Drawing.Size(20, 20)
		Me.btnArriba.TabIndex = 33
		Me.btnArriba.UseVisualStyleBackColor = True
		'
		'lblPerfil
		'
		Me.lblPerfil.AutoSize = True
		Me.lblPerfil.Location = New System.Drawing.Point(89, 121)
		Me.lblPerfil.Name = "lblPerfil"
		Me.lblPerfil.Size = New System.Drawing.Size(30, 13)
		Me.lblPerfil.TabIndex = 32
		Me.lblPerfil.Text = "Perfil"
		'
		'cmbPerfil
		'
		Me.cmbPerfil.FormattingEnabled = True
		Me.cmbPerfil.Location = New System.Drawing.Point(146, 117)
		Me.cmbPerfil.Name = "cmbPerfil"
		Me.cmbPerfil.Size = New System.Drawing.Size(155, 21)
		Me.cmbPerfil.TabIndex = 6
		'
		'lblBúscar
		'
		Me.lblBúscar.AutoSize = True
		Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblBúscar.Location = New System.Drawing.Point(350, 119)
		Me.lblBúscar.Name = "lblBúscar"
		Me.lblBúscar.Size = New System.Drawing.Size(40, 13)
		Me.lblBúscar.TabIndex = 30
		Me.lblBúscar.Text = "Búscar"
		'
		'lblLimpiar
		'
		Me.lblLimpiar.AutoSize = True
		Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
		Me.lblLimpiar.Location = New System.Drawing.Point(400, 119)
		Me.lblLimpiar.Name = "lblLimpiar"
		Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
		Me.lblLimpiar.TabIndex = 29
		Me.lblLimpiar.Text = "Limpiar"
		'
		'btnLimpiar
		'
		Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
		Me.btnLimpiar.Location = New System.Drawing.Point(403, 85)
		Me.btnLimpiar.Name = "btnLimpiar"
		Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
		Me.btnLimpiar.TabIndex = 9
		Me.btnLimpiar.UseVisualStyleBackColor = True
		'
		'btnBuscar
		'
		Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
		Me.btnBuscar.Location = New System.Drawing.Point(353, 85)
		Me.btnBuscar.Name = "btnBuscar"
		Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
		Me.btnBuscar.TabIndex = 8
		Me.btnBuscar.UseVisualStyleBackColor = True
		'
		'grdPermisos
		'
		Me.grdPermisos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grdPermisos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColModulo, Me.ColModuloid, Me.ColAccion, Me.ColAccionid, Me.ColPerfil, Me.ColPerfilid})
		Me.grdPermisos.GridColor = System.Drawing.SystemColors.ActiveCaption
		Me.grdPermisos.Location = New System.Drawing.Point(13, 260)
		Me.grdPermisos.Name = "grdPermisos"
		Me.grdPermisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grdPermisos.Size = New System.Drawing.Size(457, 190)
		Me.grdPermisos.TabIndex = 10
		'
		'ColModulo
		'
		Me.ColModulo.HeaderText = "Módulo"
		Me.ColModulo.Name = "ColModulo"
		Me.ColModulo.Width = 140
		'
		'ColModuloid
		'
		Me.ColModuloid.HeaderText = "moduloid"
		Me.ColModuloid.Name = "ColModuloid"
		Me.ColModuloid.Visible = False
		'
		'ColAccion
		'
		Me.ColAccion.HeaderText = "Acción"
		Me.ColAccion.Name = "ColAccion"
		Me.ColAccion.Width = 140
		'
		'ColAccionid
		'
		Me.ColAccionid.HeaderText = "accionid"
		Me.ColAccionid.Name = "ColAccionid"
		Me.ColAccionid.Visible = False
		'
		'ColPerfil
		'
		Me.ColPerfil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
		Me.ColPerfil.HeaderText = "Perfil"
		Me.ColPerfil.Name = "ColPerfil"
		'
		'ColPerfilid
		'
		Me.ColPerfilid.HeaderText = "perfilid"
		Me.ColPerfilid.Name = "ColPerfilid"
		Me.ColPerfilid.Visible = False
		'
		'ListaPermisoForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.BackColor = System.Drawing.Color.AliceBlue
		Me.ClientSize = New System.Drawing.Size(482, 465)
		Me.Controls.Add(Me.grdPermisos)
		Me.Controls.Add(Me.grbPermisos)
		Me.Controls.Add(Me.pnlEncabezado)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "ListaPermisoForm"
		Me.Text = "Lista Permisos"
		Me.pnlEncabezado.ResumeLayout(False)
		Me.pnlEncabezado.PerformLayout()
		CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grbPermisos.ResumeLayout(False)
		Me.grbPermisos.PerformLayout()
		CType(Me.grdPermisos, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
	Friend WithEvents lblListaPermisos As System.Windows.Forms.Label
	Friend WithEvents btnAltas As System.Windows.Forms.Button
	Friend WithEvents lblAltas As System.Windows.Forms.Label
	Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
	Friend WithEvents lblEliminar As System.Windows.Forms.Label
	Friend WithEvents btnEliminar As System.Windows.Forms.Button
	Friend WithEvents lblModulo As System.Windows.Forms.Label
	Friend WithEvents lblAccion As System.Windows.Forms.Label
	Friend WithEvents grbPermisos As System.Windows.Forms.GroupBox
	Friend WithEvents lblBúscar As System.Windows.Forms.Label
	Friend WithEvents lblLimpiar As System.Windows.Forms.Label
	Friend WithEvents btnLimpiar As System.Windows.Forms.Button
	Friend WithEvents btnBuscar As System.Windows.Forms.Button
	Friend WithEvents grdPermisos As System.Windows.Forms.DataGridView
	Friend WithEvents lblPerfil As System.Windows.Forms.Label
	Friend WithEvents cmbPerfil As System.Windows.Forms.ComboBox
	Friend WithEvents cmbModulo As System.Windows.Forms.ComboBox
	Friend WithEvents cmbAccion As System.Windows.Forms.ComboBox
	Friend WithEvents btnAbajo As System.Windows.Forms.Button
	Friend WithEvents btnArriba As System.Windows.Forms.Button
	Friend WithEvents ColModulo As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColModuloid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColAccion As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColAccionid As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColPerfil As System.Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ColPerfilid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
