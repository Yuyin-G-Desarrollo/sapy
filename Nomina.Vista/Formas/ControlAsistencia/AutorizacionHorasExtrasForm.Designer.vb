<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AutorizacionHorasExtrasForm
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutorizacionHorasExtrasForm))
        Me.pnlCabezera = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.pnlYuyin = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.gridConfiguracionAsistencia = New System.Windows.Forms.DataGridView()
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Departamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inasistencias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetardoMenor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RetardoMayor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HorarioID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HorasExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlCabezera.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlYuyin.SuspendLayout()
        CType(Me.gridConfiguracionAsistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMinimizarParametros.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabezera
        '
        Me.pnlCabezera.BackColor = System.Drawing.Color.White
        Me.pnlCabezera.Controls.Add(Me.pnlAcciones)
        Me.pnlCabezera.Controls.Add(Me.pnlYuyin)
        Me.pnlCabezera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabezera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabezera.Name = "pnlCabezera"
        Me.pnlCabezera.Size = New System.Drawing.Size(1241, 60)
        Me.pnlCabezera.TabIndex = 3
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnAutorizar)
        Me.pnlAcciones.Controls.Add(Me.btnRechazar)
        Me.pnlAcciones.Controls.Add(Me.lblNuevo)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(250, 60)
        Me.pnlAcciones.TabIndex = 9
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(60, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(53, 13)
        Me.lblCancelar.TabIndex = 12
        Me.lblCancelar.Text = "Rechazar"
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnAutorizar.Location = New System.Drawing.Point(15, 7)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizar.TabIndex = 9
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'btnRechazar
        '
        Me.btnRechazar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar32
        Me.btnRechazar.Location = New System.Drawing.Point(70, 7)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazar.TabIndex = 10
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(6, 41)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(48, 13)
        Me.lblNuevo.TabIndex = 11
        Me.lblNuevo.Text = "Autorizar"
        '
        'pnlYuyin
        '
        Me.pnlYuyin.Controls.Add(Me.pcbTitulo)
        Me.pnlYuyin.Controls.Add(Me.lblTitulo)
        Me.pnlYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlYuyin.Location = New System.Drawing.Point(854, 0)
        Me.pnlYuyin.Name = "pnlYuyin"
        Me.pnlYuyin.Size = New System.Drawing.Size(387, 60)
        Me.pnlYuyin.TabIndex = 8
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(78, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTitulo.Size = New System.Drawing.Size(243, 20)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "Autorización de Horas Extras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 406)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1241, 60)
        Me.pnlPie.TabIndex = 4
        '
        'gridConfiguracionAsistencia
        '
        Me.gridConfiguracionAsistencia.AllowUserToAddRows = False
        Me.gridConfiguracionAsistencia.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridConfiguracionAsistencia.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridConfiguracionAsistencia.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridConfiguracionAsistencia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridConfiguracionAsistencia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccion, Me.Nombre, Me.Departamento, Me.Inasistencias, Me.RetardoMenor, Me.RetardoMayor, Me.HorarioID, Me.HorasExtras, Me.Cantidad, Me.IDColaborador})
        Me.gridConfiguracionAsistencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridConfiguracionAsistencia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridConfiguracionAsistencia.GridColor = System.Drawing.Color.SteelBlue
        Me.gridConfiguracionAsistencia.Location = New System.Drawing.Point(0, 154)
        Me.gridConfiguracionAsistencia.Name = "gridConfiguracionAsistencia"
        Me.gridConfiguracionAsistencia.RowHeadersVisible = False
        Me.gridConfiguracionAsistencia.Size = New System.Drawing.Size(1241, 252)
        Me.gridConfiguracionAsistencia.TabIndex = 5
        '
        'Seleccion
        '
        Me.Seleccion.HeaderText = ""
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seleccion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Seleccion.Width = 40
        '
        'Nombre
        '
        Me.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Nombre.FillWeight = 250.0!
        Me.Nombre.HeaderText = "Colaborador"
        Me.Nombre.MinimumWidth = 250
        Me.Nombre.Name = "Nombre"
        '
        'Departamento
        '
        Me.Departamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Departamento.HeaderText = "Departamento"
        Me.Departamento.Name = "Departamento"
        '
        'Inasistencias
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Inasistencias.DefaultCellStyle = DataGridViewCellStyle3
        Me.Inasistencias.HeaderText = "Inasistencias"
        Me.Inasistencias.Name = "Inasistencias"
        Me.Inasistencias.ReadOnly = True
        '
        'RetardoMenor
        '
        Me.RetardoMenor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.NullValue = Nothing
        Me.RetardoMenor.DefaultCellStyle = DataGridViewCellStyle4
        Me.RetardoMenor.HeaderText = "Retardo Menor"
        Me.RetardoMenor.MaxInputLength = 3
        Me.RetardoMenor.Name = "RetardoMenor"
        Me.RetardoMenor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'RetardoMayor
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.RetardoMayor.DefaultCellStyle = DataGridViewCellStyle5
        Me.RetardoMayor.HeaderText = "Retardo Mayor"
        Me.RetardoMayor.Name = "RetardoMayor"
        '
        'HorarioID
        '
        Me.HorarioID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.HorarioID.HeaderText = "HorarioID"
        Me.HorarioID.Name = "HorarioID"
        Me.HorarioID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HorarioID.Visible = False
        '
        'HorasExtras
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.HorasExtras.DefaultCellStyle = DataGridViewCellStyle6
        Me.HorasExtras.HeaderText = "Horas extras"
        Me.HorasExtras.MaxInputLength = 6
        Me.HorasExtras.Name = "HorasExtras"
        '
        'Cantidad
        '
        Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'IDColaborador
        '
        Me.IDColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.IDColaborador.HeaderText = "IDColaborador"
        Me.IDColaborador.Name = "IDColaborador"
        Me.IDColaborador.Visible = False
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(353, 50)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 7
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(394, 46)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(320, 21)
        Me.cmbNave.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.HeaderText = "Configuracion Asistencia ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nave ID"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle8.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nave"
        Me.DataGridViewTextBoxColumn3.MaxInputLength = 3
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.NullValue = Nothing
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn4.HeaderText = "Rango"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 3
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn5.HeaderText = "Porcentaje"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.HeaderText = "IDColaborador"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.HeaderText = "IDColaborador"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1188, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(50, 75)
        Me.pnlMinimizarParametros.TabIndex = 8
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(25, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 44
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(3, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 43
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Controls.Add(Me.cmbNave)
        Me.grbParametros.Controls.Add(Me.pnlMinimizarParametros)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1241, 94)
        Me.grbParametros.TabIndex = 9
        Me.grbParametros.TabStop = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(319, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 30
        Me.pcbTitulo.TabStop = False
        '
        'AutorizacionHorasExtrasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 466)
        Me.Controls.Add(Me.gridConfiguracionAsistencia)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabezera)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AutorizacionHorasExtrasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorización de Horas Extras"
        Me.pnlCabezera.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlYuyin.ResumeLayout(False)
        Me.pnlYuyin.PerformLayout()
        CType(Me.gridConfiguracionAsistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlCabezera As System.Windows.Forms.Panel
    Friend WithEvents pnlYuyin As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents gridConfiguracionAsistencia As System.Windows.Forms.DataGridView
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Seleccion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Departamento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Inasistencias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetardoMenor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetardoMayor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HorarioID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HorasExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
