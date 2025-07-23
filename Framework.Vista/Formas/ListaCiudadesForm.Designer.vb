<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaCiudadesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaCiudadesForm))
        Me.grdFiltroCiudades = New System.Windows.Forms.DataGridView()
        Me.gpbFiltroCiudades = New System.Windows.Forms.GroupBox()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.cmbPaises = New System.Windows.Forms.ComboBox()
        Me.Estado = New System.Windows.Forms.Label()
        Me.Pais = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarPais = New System.Windows.Forms.Button()
        Me.btnFiltrarPais = New System.Windows.Forms.Button()
        Me.lblActivoPais = New System.Windows.Forms.Label()
        Me.txtBuscarNombrePais = New System.Windows.Forms.TextBox()
        Me.lblNombrePais = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblAltaCiudad = New System.Windows.Forms.Label()
        Me.btnEditarCiudades = New System.Windows.Forms.Button()
        Me.btnAltaCiudades = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grdFiltroCiudades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroCiudades.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdFiltroCiudades
        '
        Me.grdFiltroCiudades.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdFiltroCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiltroCiudades.Location = New System.Drawing.Point(8, 221)
        Me.grdFiltroCiudades.MultiSelect = False
        Me.grdFiltroCiudades.Name = "grdFiltroCiudades"
        Me.grdFiltroCiudades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiltroCiudades.Size = New System.Drawing.Size(761, 309)
        Me.grdFiltroCiudades.TabIndex = 5
        '
        'gpbFiltroCiudades
        '
        Me.gpbFiltroCiudades.Controls.Add(Me.cmbEstados)
        Me.gpbFiltroCiudades.Controls.Add(Me.cmbPaises)
        Me.gpbFiltroCiudades.Controls.Add(Me.Estado)
        Me.gpbFiltroCiudades.Controls.Add(Me.Pais)
        Me.gpbFiltroCiudades.Controls.Add(Me.Panel1)
        Me.gpbFiltroCiudades.Controls.Add(Me.btnAbajo)
        Me.gpbFiltroCiudades.Controls.Add(Me.btnArriba)
        Me.gpbFiltroCiudades.Controls.Add(Me.lblLimpiar)
        Me.gpbFiltroCiudades.Controls.Add(Me.lblBuscar)
        Me.gpbFiltroCiudades.Controls.Add(Me.btnLimpiarPais)
        Me.gpbFiltroCiudades.Controls.Add(Me.btnFiltrarPais)
        Me.gpbFiltroCiudades.Controls.Add(Me.lblActivoPais)
        Me.gpbFiltroCiudades.Controls.Add(Me.txtBuscarNombrePais)
        Me.gpbFiltroCiudades.Controls.Add(Me.lblNombrePais)
        Me.gpbFiltroCiudades.Location = New System.Drawing.Point(8, 66)
        Me.gpbFiltroCiudades.Name = "gpbFiltroCiudades"
        Me.gpbFiltroCiudades.Size = New System.Drawing.Size(760, 150)
        Me.gpbFiltroCiudades.TabIndex = 4
        Me.gpbFiltroCiudades.TabStop = False
        '
        'cmbEstados
        '
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(274, 69)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(299, 21)
        Me.cmbEstados.TabIndex = 2
        '
        'cmbPaises
        '
        Me.cmbPaises.FormattingEnabled = True
        Me.cmbPaises.Location = New System.Drawing.Point(274, 42)
        Me.cmbPaises.Name = "cmbPaises"
        Me.cmbPaises.Size = New System.Drawing.Size(299, 21)
        Me.cmbPaises.TabIndex = 1
        '
        'Estado
        '
        Me.Estado.AutoSize = True
        Me.Estado.Location = New System.Drawing.Point(228, 72)
        Me.Estado.Name = "Estado"
        Me.Estado.Size = New System.Drawing.Size(40, 13)
        Me.Estado.TabIndex = 16
        Me.Estado.Text = "Estado"
        '
        'Pais
        '
        Me.Pais.AutoSize = True
        Me.Pais.Location = New System.Drawing.Point(228, 47)
        Me.Pais.Name = "Pais"
        Me.Pais.Size = New System.Drawing.Size(29, 13)
        Me.Pais.TabIndex = 15
        Me.Pais.Text = "País"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdoActivoNo)
        Me.Panel1.Controls.Add(Me.rdoActivoSi)
        Me.Panel1.Location = New System.Drawing.Point(274, 117)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(94, 30)
        Me.Panel1.TabIndex = 14
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.Location = New System.Drawing.Point(52, 7)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 5
        Me.rdoActivoNo.TabStop = True
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.Location = New System.Drawing.Point(3, 7)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 4
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(724, 13)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(696, 13)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(709, 134)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(657, 134)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarPais
        '
        Me.btnLimpiarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.limpiar_32
        Me.btnLimpiarPais.Location = New System.Drawing.Point(712, 102)
        Me.btnLimpiarPais.Name = "btnLimpiarPais"
        Me.btnLimpiarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarPais.TabIndex = 7
        Me.btnLimpiarPais.UseVisualStyleBackColor = True
        '
        'btnFiltrarPais
        '
        Me.btnFiltrarPais.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.buscar_32
        Me.btnFiltrarPais.Location = New System.Drawing.Point(661, 102)
        Me.btnFiltrarPais.Name = "btnFiltrarPais"
        Me.btnFiltrarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarPais.TabIndex = 6
        Me.btnFiltrarPais.UseVisualStyleBackColor = True
        '
        'lblActivoPais
        '
        Me.lblActivoPais.AutoSize = True
        Me.lblActivoPais.Location = New System.Drawing.Point(228, 127)
        Me.lblActivoPais.Name = "lblActivoPais"
        Me.lblActivoPais.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoPais.TabIndex = 2
        Me.lblActivoPais.Text = "Activo"
        '
        'txtBuscarNombrePais
        '
        Me.txtBuscarNombrePais.Location = New System.Drawing.Point(274, 94)
        Me.txtBuscarNombrePais.Name = "txtBuscarNombrePais"
        Me.txtBuscarNombrePais.Size = New System.Drawing.Size(299, 20)
        Me.txtBuscarNombrePais.TabIndex = 3
        '
        'lblNombrePais
        '
        Me.lblNombrePais.AutoSize = True
        Me.lblNombrePais.Location = New System.Drawing.Point(228, 97)
        Me.lblNombrePais.Name = "lblNombrePais"
        Me.lblNombrePais.Size = New System.Drawing.Size(40, 13)
        Me.lblNombrePais.TabIndex = 0
        Me.lblNombrePais.Text = "Ciudad"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.PictureBox1)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaCiudad)
        Me.pnlListaPaises.Controls.Add(Me.btnEditarCiudades)
        Me.pnlListaPaises.Controls.Add(Me.btnAltaCiudades)
        Me.pnlListaPaises.Location = New System.Drawing.Point(1, 3)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(774, 60)
        Me.pnlListaPaises.TabIndex = 3
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(622, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(84, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Ciudades"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(62, 40)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 4
        Me.lblEditar.Text = "Editar"
        '
        'lblAltaCiudad
        '
        Me.lblAltaCiudad.AutoSize = True
        Me.lblAltaCiudad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaCiudad.Location = New System.Drawing.Point(14, 40)
        Me.lblAltaCiudad.Name = "lblAltaCiudad"
        Me.lblAltaCiudad.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaCiudad.TabIndex = 3
        Me.lblAltaCiudad.Text = "Altas"
        '
        'btnEditarCiudades
        '
        Me.btnEditarCiudades.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.editar_32
        Me.btnEditarCiudades.Location = New System.Drawing.Point(64, 8)
        Me.btnEditarCiudades.Name = "btnEditarCiudades"
        Me.btnEditarCiudades.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarCiudades.TabIndex = 2
        Me.btnEditarCiudades.UseVisualStyleBackColor = True
        '
        'btnAltaCiudades
        '
        Me.btnAltaCiudades.BackgroundImage = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAltaCiudades.Location = New System.Drawing.Point(14, 8)
        Me.btnAltaCiudades.Name = "btnAltaCiudades"
        Me.btnAltaCiudades.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaCiudades.TabIndex = 1
        Me.btnAltaCiudades.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(706, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ListaCiudadesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(776, 539)
        Me.Controls.Add(Me.grdFiltroCiudades)
        Me.Controls.Add(Me.gpbFiltroCiudades)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListaCiudadesForm"
        Me.Text = "Ciudades"
        CType(Me.grdFiltroCiudades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroCiudades.ResumeLayout(False)
        Me.gpbFiltroCiudades.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdFiltroCiudades As System.Windows.Forms.DataGridView
    Friend WithEvents gpbFiltroCiudades As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarPais As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarPais As System.Windows.Forms.Button
    Friend WithEvents lblActivoPais As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombrePais As System.Windows.Forms.TextBox
    Friend WithEvents lblNombrePais As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblAltaCiudad As System.Windows.Forms.Label
    Friend WithEvents btnEditarCiudades As System.Windows.Forms.Button
    Friend WithEvents btnAltaCiudades As System.Windows.Forms.Button
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPaises As System.Windows.Forms.ComboBox
    Friend WithEvents Estado As System.Windows.Forms.Label
    Friend WithEvents Pais As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
