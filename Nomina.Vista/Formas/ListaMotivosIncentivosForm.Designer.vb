<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaMotivosIncentivosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaMotivosIncentivosForm))
        Me.lblAltaCiudad = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnEditarIncentivo = New System.Windows.Forms.Button()
        Me.btnAltaIncentivo = New System.Windows.Forms.Button()
        Me.grdFiltroIncentivos = New System.Windows.Forms.DataGridView()
        Me.gpbFiltroIncentivos = New System.Windows.Forms.GroupBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.rdoActivoNo = New System.Windows.Forms.RadioButton()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnLimpiarIncentivos = New System.Windows.Forms.Button()
        Me.rdoActivoSi = New System.Windows.Forms.RadioButton()
        Me.btnFiltrarPais = New System.Windows.Forms.Button()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.Nave = New System.Windows.Forms.Label()
        Me.lblActivoNave = New System.Windows.Forms.Label()
        Me.txtBuscarNombreIncentivo = New System.Windows.Forms.TextBox()
        Me.lblNombreIncentivo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.grdFiltroIncentivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltroIncentivos.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblAltaCiudad
        '
        Me.lblAltaCiudad.AutoSize = True
        Me.lblAltaCiudad.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaCiudad.Location = New System.Drawing.Point(16, 39)
        Me.lblAltaCiudad.Name = "lblAltaCiudad"
        Me.lblAltaCiudad.Size = New System.Drawing.Size(30, 13)
        Me.lblAltaCiudad.TabIndex = 3
        Me.lblAltaCiudad.Text = "Altas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(66, 40)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 4
        Me.lblEditar.Text = "Editar"
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(586, 18)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(221, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Motivos de Gratificaciones"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pcbTitulo)
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.lblEditar)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaCiudad)
        Me.pnlListaPaises.Controls.Add(Me.btnEditarIncentivo)
        Me.pnlListaPaises.Controls.Add(Me.btnAltaIncentivo)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(884, 59)
        Me.pnlListaPaises.TabIndex = 6
        '
        'btnEditarIncentivo
        '
        Me.btnEditarIncentivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.editar_321
        Me.btnEditarIncentivo.Location = New System.Drawing.Point(66, 6)
        Me.btnEditarIncentivo.Name = "btnEditarIncentivo"
        Me.btnEditarIncentivo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarIncentivo.TabIndex = 2
        Me.btnEditarIncentivo.UseVisualStyleBackColor = True
        '
        'btnAltaIncentivo
        '
        Me.btnAltaIncentivo.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.altas_32
        Me.btnAltaIncentivo.Location = New System.Drawing.Point(14, 6)
        Me.btnAltaIncentivo.Name = "btnAltaIncentivo"
        Me.btnAltaIncentivo.Size = New System.Drawing.Size(31, 32)
        Me.btnAltaIncentivo.TabIndex = 1
        Me.btnAltaIncentivo.UseVisualStyleBackColor = True
        '
        'grdFiltroIncentivos
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroIncentivos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdFiltroIncentivos.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdFiltroIncentivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdFiltroIncentivos.Location = New System.Drawing.Point(12, 196)
        Me.grdFiltroIncentivos.MultiSelect = False
        Me.grdFiltroIncentivos.Name = "grdFiltroIncentivos"
        Me.grdFiltroIncentivos.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdFiltroIncentivos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdFiltroIncentivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFiltroIncentivos.Size = New System.Drawing.Size(851, 334)
        Me.grdFiltroIncentivos.TabIndex = 8
        '
        'gpbFiltroIncentivos
        '
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblBuscar)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnAbajo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.rdoActivoNo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnArriba)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnLimpiarIncentivos)
        Me.gpbFiltroIncentivos.Controls.Add(Me.rdoActivoSi)
        Me.gpbFiltroIncentivos.Controls.Add(Me.btnFiltrarPais)
        Me.gpbFiltroIncentivos.Controls.Add(Me.cmbNaves)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblLimpiar)
        Me.gpbFiltroIncentivos.Controls.Add(Me.Nave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblActivoNave)
        Me.gpbFiltroIncentivos.Controls.Add(Me.txtBuscarNombreIncentivo)
        Me.gpbFiltroIncentivos.Controls.Add(Me.lblNombreIncentivo)
        Me.gpbFiltroIncentivos.Location = New System.Drawing.Point(12, 61)
        Me.gpbFiltroIncentivos.Name = "gpbFiltroIncentivos"
        Me.gpbFiltroIncentivos.Size = New System.Drawing.Size(850, 129)
        Me.gpbFiltroIncentivos.TabIndex = 7
        Me.gpbFiltroIncentivos.TabStop = False
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(753, 110)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(815, 10)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 13
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'rdoActivoNo
        '
        Me.rdoActivoNo.AutoSize = True
        Me.rdoActivoNo.ForeColor = System.Drawing.Color.Black
        Me.rdoActivoNo.Location = New System.Drawing.Point(267, 106)
        Me.rdoActivoNo.Name = "rdoActivoNo"
        Me.rdoActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoActivoNo.TabIndex = 6
        Me.rdoActivoNo.TabStop = True
        Me.rdoActivoNo.Text = "No"
        Me.rdoActivoNo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(789, 10)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 12
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnLimpiarIncentivos
        '
        Me.btnLimpiarIncentivos.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarIncentivos.Location = New System.Drawing.Point(803, 78)
        Me.btnLimpiarIncentivos.Name = "btnLimpiarIncentivos"
        Me.btnLimpiarIncentivos.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarIncentivos.TabIndex = 6
        Me.btnLimpiarIncentivos.UseVisualStyleBackColor = True
        '
        'rdoActivoSi
        '
        Me.rdoActivoSi.AutoSize = True
        Me.rdoActivoSi.Checked = True
        Me.rdoActivoSi.ForeColor = System.Drawing.Color.Black
        Me.rdoActivoSi.Location = New System.Drawing.Point(203, 106)
        Me.rdoActivoSi.Name = "rdoActivoSi"
        Me.rdoActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivoSi.TabIndex = 5
        Me.rdoActivoSi.TabStop = True
        Me.rdoActivoSi.Text = "Si"
        Me.rdoActivoSi.UseVisualStyleBackColor = True
        '
        'btnFiltrarPais
        '
        Me.btnFiltrarPais.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarPais.Location = New System.Drawing.Point(756, 78)
        Me.btnFiltrarPais.Name = "btnFiltrarPais"
        Me.btnFiltrarPais.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarPais.TabIndex = 5
        Me.btnFiltrarPais.UseVisualStyleBackColor = True
        '
        'cmbNaves
        '
        Me.cmbNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaves.ForeColor = System.Drawing.Color.Black
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(203, 47)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(524, 21)
        Me.cmbNaves.TabIndex = 17
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(800, 110)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 8
        Me.lblLimpiar.Text = "Limpiar"
        '
        'Nave
        '
        Me.Nave.AutoSize = True
        Me.Nave.ForeColor = System.Drawing.Color.Black
        Me.Nave.Location = New System.Drawing.Point(133, 52)
        Me.Nave.Name = "Nave"
        Me.Nave.Size = New System.Drawing.Size(33, 13)
        Me.Nave.TabIndex = 15
        Me.Nave.Text = "Nave"
        '
        'lblActivoNave
        '
        Me.lblActivoNave.AutoSize = True
        Me.lblActivoNave.ForeColor = System.Drawing.Color.Black
        Me.lblActivoNave.Location = New System.Drawing.Point(133, 106)
        Me.lblActivoNave.Name = "lblActivoNave"
        Me.lblActivoNave.Size = New System.Drawing.Size(37, 13)
        Me.lblActivoNave.TabIndex = 2
        Me.lblActivoNave.Text = "Activo"
        '
        'txtBuscarNombreIncentivo
        '
        Me.txtBuscarNombreIncentivo.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarNombreIncentivo.Location = New System.Drawing.Point(203, 78)
        Me.txtBuscarNombreIncentivo.Name = "txtBuscarNombreIncentivo"
        Me.txtBuscarNombreIncentivo.Size = New System.Drawing.Size(524, 20)
        Me.txtBuscarNombreIncentivo.TabIndex = 1
        '
        'lblNombreIncentivo
        '
        Me.lblNombreIncentivo.AutoSize = True
        Me.lblNombreIncentivo.ForeColor = System.Drawing.Color.Black
        Me.lblNombreIncentivo.Location = New System.Drawing.Point(133, 79)
        Me.lblNombreIncentivo.Name = "lblNombreIncentivo"
        Me.lblNombreIncentivo.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreIncentivo.TabIndex = 0
        Me.lblNombreIncentivo.Text = "Nombre"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(816, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'ListaMotivosIncentivosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(884, 550)
        Me.Controls.Add(Me.gpbFiltroIncentivos)
        Me.Controls.Add(Me.grdFiltroIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(890, 572)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(890, 572)
        Me.Name = "ListaMotivosIncentivosForm"
        Me.Text = "Motivos de Gratificaciones"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.grdFiltroIncentivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltroIncentivos.ResumeLayout(False)
        Me.gpbFiltroIncentivos.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAltaIncentivo As System.Windows.Forms.Button
    Friend WithEvents btnEditarIncentivo As System.Windows.Forms.Button
    Friend WithEvents lblAltaCiudad As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents grdFiltroIncentivos As System.Windows.Forms.DataGridView
    Friend WithEvents gpbFiltroIncentivos As System.Windows.Forms.GroupBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents rdoActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnLimpiarIncentivos As System.Windows.Forms.Button
    Friend WithEvents rdoActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnFiltrarPais As System.Windows.Forms.Button
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents Nave As System.Windows.Forms.Label
    Friend WithEvents lblActivoNave As System.Windows.Forms.Label
    Friend WithEvents txtBuscarNombreIncentivo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreIncentivo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
