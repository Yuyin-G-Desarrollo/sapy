<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionPrestamosForm
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionPrestamosForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.grdConfiguracion = New System.Windows.Forms.DataGridView()
        Me.IdNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdConfiguracionPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaximoDeSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoMaximoPorNave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoMaximoPorColaborado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TasaDeInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InteresSobreSaldo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.InteresFijo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SinInteres = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AutorizacionGerente = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AutorizacionDirector = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardado = New System.Windows.Forms.Label()
        Me.lblGuardado2 = New System.Windows.Forms.Label()
        Me.lblNoGuardado = New System.Windows.Forms.Label()
        Me.lblNoGuardado2 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdConfiguracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1241, 59)
        Me.pnlHeader.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(645, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(596, 59)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(528, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 23
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(292, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(235, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Configuración de Préstamos"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(28, 37)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Guardar"
        '
        'grdConfiguracion
        '
        Me.grdConfiguracion.AllowUserToAddRows = False
        Me.grdConfiguracion.AllowUserToDeleteRows = False
        Me.grdConfiguracion.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdConfiguracion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdConfiguracion.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdConfiguracion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdConfiguracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdConfiguracion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdNave, Me.IdConfiguracionPrestamo, Me.Nave, Me.MaximoDeSemanas, Me.MontoMaximoPorNave, Me.MontoMaximoPorColaborado, Me.TasaDeInteres, Me.InteresSobreSaldo, Me.InteresFijo, Me.SinInteres, Me.AutorizacionGerente, Me.AutorizacionDirector})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdConfiguracion.DefaultCellStyle = DataGridViewCellStyle8
        Me.grdConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConfiguracion.Location = New System.Drawing.Point(0, 59)
        Me.grdConfiguracion.Name = "grdConfiguracion"
        Me.grdConfiguracion.Size = New System.Drawing.Size(1241, 410)
        Me.grdConfiguracion.TabIndex = 2
        '
        'IdNave
        '
        Me.IdNave.HeaderText = "IdNave"
        Me.IdNave.Name = "IdNave"
        Me.IdNave.Visible = False
        Me.IdNave.Width = 5
        '
        'IdConfiguracionPrestamo
        '
        Me.IdConfiguracionPrestamo.HeaderText = "IdConfiguracionPrestamo"
        Me.IdConfiguracionPrestamo.Name = "IdConfiguracionPrestamo"
        Me.IdConfiguracionPrestamo.Visible = False
        Me.IdConfiguracionPrestamo.Width = 5
        '
        'Nave
        '
        Me.Nave.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Nave.DefaultCellStyle = DataGridViewCellStyle3
        Me.Nave.HeaderText = "Nave"
        Me.Nave.Name = "Nave"
        Me.Nave.ReadOnly = True
        '
        'MaximoDeSemanas
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.MaximoDeSemanas.DefaultCellStyle = DataGridViewCellStyle4
        Me.MaximoDeSemanas.HeaderText = "Máximo de Semanas"
        Me.MaximoDeSemanas.MaxInputLength = 3
        Me.MaximoDeSemanas.Name = "MaximoDeSemanas"
        Me.MaximoDeSemanas.Width = 150
        '
        'MontoMaximoPorNave
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.MontoMaximoPorNave.DefaultCellStyle = DataGridViewCellStyle5
        Me.MontoMaximoPorNave.HeaderText = "Monto Máximo por Nave"
        Me.MontoMaximoPorNave.MaxInputLength = 13
        Me.MontoMaximoPorNave.Name = "MontoMaximoPorNave"
        Me.MontoMaximoPorNave.Width = 150
        '
        'MontoMaximoPorColaborado
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.MontoMaximoPorColaborado.DefaultCellStyle = DataGridViewCellStyle6
        Me.MontoMaximoPorColaborado.HeaderText = "Monto Máximo por Colaborador"
        Me.MontoMaximoPorColaborado.MaxInputLength = 13
        Me.MontoMaximoPorColaborado.Name = "MontoMaximoPorColaborado"
        Me.MontoMaximoPorColaborado.Width = 150
        '
        'TasaDeInteres
        '
        Me.TasaDeInteres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "##,##0.00"
        DataGridViewCellStyle7.NullValue = "0"
        Me.TasaDeInteres.DefaultCellStyle = DataGridViewCellStyle7
        Me.TasaDeInteres.HeaderText = "Tasa de Interés"
        Me.TasaDeInteres.MaxInputLength = 5
        Me.TasaDeInteres.Name = "TasaDeInteres"
        Me.TasaDeInteres.Width = 97
        '
        'InteresSobreSaldo
        '
        Me.InteresSobreSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.InteresSobreSaldo.HeaderText = "Interés Sobre Saldo"
        Me.InteresSobreSaldo.IndeterminateValue = "%"
        Me.InteresSobreSaldo.Name = "InteresSobreSaldo"
        Me.InteresSobreSaldo.Width = 71
        '
        'InteresFijo
        '
        Me.InteresFijo.HeaderText = "Interés Fijo"
        Me.InteresFijo.Name = "InteresFijo"
        Me.InteresFijo.Width = 70
        '
        'SinInteres
        '
        Me.SinInteres.HeaderText = "Sin Interés"
        Me.SinInteres.Name = "SinInteres"
        Me.SinInteres.Width = 70
        '
        'AutorizacionGerente
        '
        Me.AutorizacionGerente.HeaderText = "Autorización Gerente"
        Me.AutorizacionGerente.Name = "AutorizacionGerente"
        Me.AutorizacionGerente.Width = 70
        '
        'AutorizacionDirector
        '
        Me.AutorizacionDirector.HeaderText = "Autorización Director"
        Me.AutorizacionDirector.Name = "AutorizacionDirector"
        Me.AutorizacionDirector.Width = 70
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Controls.Add(Me.lblGuardado)
        Me.pnlEstado.Controls.Add(Me.lblGuardado2)
        Me.pnlEstado.Controls.Add(Me.lblNoGuardado)
        Me.pnlEstado.Controls.Add(Me.lblNoGuardado2)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 469)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1241, 60)
        Me.pnlEstado.TabIndex = 11
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(1091, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(150, 60)
        Me.pnlAcciones.TabIndex = 4
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(99, 37)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 56
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(99, 6)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 55
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(32, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardado
        '
        Me.lblGuardado.AutoSize = True
        Me.lblGuardado.ForeColor = System.Drawing.Color.Black
        Me.lblGuardado.Location = New System.Drawing.Point(42, 37)
        Me.lblGuardado.Name = "lblGuardado"
        Me.lblGuardado.Size = New System.Drawing.Size(122, 13)
        Me.lblGuardado.TabIndex = 12
        Me.lblGuardado.Text = "Configuración Guardada"
        '
        'lblGuardado2
        '
        Me.lblGuardado2.AutoSize = True
        Me.lblGuardado2.BackColor = System.Drawing.Color.LightGreen
        Me.lblGuardado2.ForeColor = System.Drawing.Color.LightGreen
        Me.lblGuardado2.Location = New System.Drawing.Point(21, 35)
        Me.lblGuardado2.MinimumSize = New System.Drawing.Size(15, 15)
        Me.lblGuardado2.Name = "lblGuardado2"
        Me.lblGuardado2.Size = New System.Drawing.Size(15, 15)
        Me.lblGuardado2.TabIndex = 11
        '
        'lblNoGuardado
        '
        Me.lblNoGuardado.AutoSize = True
        Me.lblNoGuardado.ForeColor = System.Drawing.Color.Black
        Me.lblNoGuardado.Location = New System.Drawing.Point(222, 37)
        Me.lblNoGuardado.Name = "lblNoGuardado"
        Me.lblNoGuardado.Size = New System.Drawing.Size(211, 13)
        Me.lblNoGuardado.TabIndex = 1
        Me.lblNoGuardado.Text = "Configuración NO Guardada y/o Incorrecta"
        '
        'lblNoGuardado2
        '
        Me.lblNoGuardado2.AutoSize = True
        Me.lblNoGuardado2.BackColor = System.Drawing.Color.Salmon
        Me.lblNoGuardado2.ForeColor = System.Drawing.Color.Salmon
        Me.lblNoGuardado2.Location = New System.Drawing.Point(201, 35)
        Me.lblNoGuardado2.MinimumSize = New System.Drawing.Size(15, 15)
        Me.lblNoGuardado2.Name = "lblNoGuardado2"
        Me.lblNoGuardado2.Size = New System.Drawing.Size(15, 15)
        Me.lblNoGuardado2.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdNave"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "IdConfiguracionPrestamo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.HeaderText = "Nave"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn4.HeaderText = "Máximo de semanas"
        Me.DataGridViewTextBoxColumn4.MaxInputLength = 3
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn5.HeaderText = "Monto máximo por nave"
        Me.DataGridViewTextBoxColumn5.MaxInputLength = 13
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle11.Format = "C2"
        DataGridViewCellStyle11.NullValue = "0"
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn6.HeaderText = "Monto máximo por colaborador"
        Me.DataGridViewTextBoxColumn6.MaxInputLength = 13
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle12.Format = "##,##0.00"
        DataGridViewCellStyle12.NullValue = "0"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn7.HeaderText = "Tasa de Interés"
        Me.DataGridViewTextBoxColumn7.MaxInputLength = 5
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(528, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 24
        Me.pcbTitulo.TabStop = False
        '
        'ConfiguracionPrestamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 529)
        Me.Controls.Add(Me.grdConfiguracion)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ConfiguracionPrestamosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de Préstamos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdConfiguracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents grdConfiguracion As System.Windows.Forms.DataGridView
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents lblGuardado As System.Windows.Forms.Label
    Friend WithEvents lblGuardado2 As System.Windows.Forms.Label
    Friend WithEvents lblNoGuardado As System.Windows.Forms.Label
    Friend WithEvents lblNoGuardado2 As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdNave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdConfiguracionPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaximoDeSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoMaximoPorNave As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MontoMaximoPorColaborado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TasaDeInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InteresSobreSaldo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InteresFijo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SinInteres As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AutorizacionGerente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AutorizacionDirector As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
