<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionNavesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionNavesForm))
        Me.grdConfiguracionNaves = New System.Windows.Forms.DataGridView()
        Me.Nave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiasGratificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AutorizaGerente = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AutorizaDirector = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DiasAguinaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDConfiguracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDConfiguraciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDiasVacaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        CType(Me.grdConfiguracionNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdConfiguracionNaves
        '
        Me.grdConfiguracionNaves.AllowUserToAddRows = False
        Me.grdConfiguracionNaves.AllowUserToDeleteRows = False
        Me.grdConfiguracionNaves.AllowUserToResizeColumns = False
        Me.grdConfiguracionNaves.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConfiguracionNaves.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdConfiguracionNaves.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdConfiguracionNaves.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdConfiguracionNaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConfiguracionNaves.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nave, Me.DiasGratificacion, Me.AutorizaGerente, Me.AutorizaDirector, Me.DiasAguinaldo, Me.IDConfiguracion, Me.IDConfiguraciones, Me.ColDiasVacaciones})
        Me.grdConfiguracionNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConfiguracionNaves.Location = New System.Drawing.Point(0, 60)
        Me.grdConfiguracionNaves.Name = "grdConfiguracionNaves"
        Me.grdConfiguracionNaves.Size = New System.Drawing.Size(630, 442)
        Me.grdConfiguracionNaves.TabIndex = 0
        '
        'Nave
        '
        Me.Nave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nave.HeaderText = "Nave"
        Me.Nave.Name = "Nave"
        Me.Nave.ReadOnly = True
        '
        'DiasGratificacion
        '
        Me.DiasGratificacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.DiasGratificacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.DiasGratificacion.FillWeight = 278.4173!
        Me.DiasGratificacion.HeaderText = "Dias de Gratificación"
        Me.DiasGratificacion.Name = "DiasGratificacion"
        Me.DiasGratificacion.Visible = False
        '
        'AutorizaGerente
        '
        Me.AutorizaGerente.FillWeight = 10.79137!
        Me.AutorizaGerente.HeaderText = "Autoriza Gerente"
        Me.AutorizaGerente.Name = "AutorizaGerente"
        '
        'AutorizaDirector
        '
        Me.AutorizaDirector.FillWeight = 10.79137!
        Me.AutorizaDirector.HeaderText = "Autoriza Director"
        Me.AutorizaDirector.Name = "AutorizaDirector"
        '
        'DiasAguinaldo
        '
        Me.DiasAguinaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DiasAguinaldo.HeaderText = "Dias Aguinaldo"
        Me.DiasAguinaldo.Name = "DiasAguinaldo"
        Me.DiasAguinaldo.Visible = False
        '
        'IDConfiguracion
        '
        Me.IDConfiguracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.IDConfiguracion.HeaderText = "IDConfiguracion"
        Me.IDConfiguracion.Name = "IDConfiguracion"
        Me.IDConfiguracion.Visible = False
        '
        'IDConfiguraciones
        '
        Me.IDConfiguraciones.HeaderText = "ID"
        Me.IDConfiguraciones.Name = "IDConfiguraciones"
        Me.IDConfiguraciones.Visible = False
        '
        'ColDiasVacaciones
        '
        Me.ColDiasVacaciones.HeaderText = "Dias de Vacaciones"
        Me.ColDiasVacaciones.Name = "ColDiasVacaciones"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(630, 60)
        Me.pnlListaPaises.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(293, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(337, 60)
        Me.Panel1.TabIndex = 5
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(40, 18)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(228, 20)
        Me.lblEncabezado.TabIndex = 9
        Me.lblEncabezado.Text = "Configuración de Finiquitos"
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(507, 38)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(45, 13)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Guardar"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnAutorizar.Location = New System.Drawing.Point(513, 6)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizar.TabIndex = 1
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblCerrar)
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnAutorizar)
        Me.Panel2.Controls.Add(Me.lblNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 443)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(630, 59)
        Me.Panel2.TabIndex = 14
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(577, 37)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 13
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(578, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 12
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nave"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn2.FillWeight = 278.4173!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Dias de Gratificacion"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dias Aguinaldo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.HeaderText = "IDConfiguracion"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Dias de Vacaciones"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(269, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'ConfiguracionNavesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(630, 502)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grdConfiguracionNaves)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(638, 529)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(638, 529)
        Me.Name = "ConfiguracionNavesForm"
        Me.Text = "Configuración de Finiquitos"
        CType(Me.grdConfiguracionNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdConfiguracionNaves As System.Windows.Forms.DataGridView
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Nave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiasGratificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AutorizaGerente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AutorizaDirector As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DiasAguinaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDConfiguracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDConfiguraciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDiasVacaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
