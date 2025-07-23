<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CancelarPrestamosForm
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CancelarPrestamosForm))
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grdCancelar = New System.Windows.Forms.DataGridView()
        Me.clmidPrestamo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmCancelar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmColaborador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTasaDeInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmSinInteres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.pnlMinimizar = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.grdCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.pnlMinimizar.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(1241, 59)
        Me.pnlBanner.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(868, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(373, 59)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(135, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(170, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Cancelar Préstamos"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(90, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 3
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(95, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'grdCancelar
        '
        Me.grdCancelar.AllowUserToAddRows = False
        Me.grdCancelar.AllowUserToDeleteRows = False
        Me.grdCancelar.AllowUserToOrderColumns = True
        Me.grdCancelar.AllowUserToResizeColumns = False
        Me.grdCancelar.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCancelar.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCancelar.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCancelar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdCancelar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCancelar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmidPrestamo, Me.clmCancelar, Me.clmColaborador, Me.clmSaldo, Me.clmAbono, Me.clmSemanas, Me.clmTasaDeInteres, Me.clmSinInteres, Me.estatus})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.NullValue = Nothing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdCancelar.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdCancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCancelar.Location = New System.Drawing.Point(0, 175)
        Me.grdCancelar.Name = "grdCancelar"
        Me.grdCancelar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdCancelar.Size = New System.Drawing.Size(1241, 294)
        Me.grdCancelar.TabIndex = 5
        '
        'clmidPrestamo
        '
        Me.clmidPrestamo.HeaderText = "idPrestamo"
        Me.clmidPrestamo.Name = "clmidPrestamo"
        Me.clmidPrestamo.Visible = False
        '
        'clmCancelar
        '
        Me.clmCancelar.HeaderText = ""
        Me.clmCancelar.Name = "clmCancelar"
        Me.clmCancelar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmCancelar.ToolTipText = "Cancelar"
        Me.clmCancelar.Width = 20
        '
        'clmColaborador
        '
        Me.clmColaborador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmColaborador.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmColaborador.HeaderText = "Colaborador"
        Me.clmColaborador.Name = "clmColaborador"
        Me.clmColaborador.ReadOnly = True
        '
        'clmSaldo
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clmSaldo.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmSaldo.HeaderText = "Monto Inicial"
        Me.clmSaldo.Name = "clmSaldo"
        Me.clmSaldo.ReadOnly = True
        '
        'clmAbono
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.clmAbono.DefaultCellStyle = DataGridViewCellStyle5
        Me.clmAbono.HeaderText = "Abono"
        Me.clmAbono.Name = "clmAbono"
        Me.clmAbono.ReadOnly = True
        '
        'clmSemanas
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.clmSemanas.DefaultCellStyle = DataGridViewCellStyle6
        Me.clmSemanas.HeaderText = "Num. Semanas"
        Me.clmSemanas.Name = "clmSemanas"
        Me.clmSemanas.ReadOnly = True
        Me.clmSemanas.Width = 115
        '
        'clmTasaDeInteres
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.clmTasaDeInteres.DefaultCellStyle = DataGridViewCellStyle7
        Me.clmTasaDeInteres.HeaderText = "Tasa de Interés"
        Me.clmTasaDeInteres.MaxInputLength = 5
        Me.clmTasaDeInteres.Name = "clmTasaDeInteres"
        Me.clmTasaDeInteres.ReadOnly = True
        Me.clmTasaDeInteres.Width = 110
        '
        'clmSinInteres
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmSinInteres.DefaultCellStyle = DataGridViewCellStyle8
        Me.clmSinInteres.HeaderText = "Tipo de Interés"
        Me.clmSinInteres.Name = "clmSinInteres"
        Me.clmSinInteres.ReadOnly = True
        Me.clmSinInteres.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmSinInteres.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.clmSinInteres.Width = 350
        '
        'estatus
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.estatus.DefaultCellStyle = DataGridViewCellStyle9
        Me.estatus.HeaderText = "clmestatus"
        Me.estatus.Name = "estatus"
        Me.estatus.Visible = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 469)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1241, 60)
        Me.pnlEstado.TabIndex = 15
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(1038, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(203, 60)
        Me.pnlAcciones.TabIndex = 18
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(155, 38)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 60
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(156, 6)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 59
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.Transparent
        Me.grbParametros.Controls.Add(Me.pnlMinimizar)
        Me.grbParametros.Controls.Add(Me.cmbNaves)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(1241, 116)
        Me.grbParametros.TabIndex = 16
        Me.grbParametros.TabStop = False
        '
        'pnlMinimizar
        '
        Me.pnlMinimizar.Controls.Add(Me.btnLimpiar)
        Me.pnlMinimizar.Controls.Add(Me.lblLimpiar)
        Me.pnlMinimizar.Controls.Add(Me.lblBuscar)
        Me.pnlMinimizar.Controls.Add(Me.btnBuscar)
        Me.pnlMinimizar.Controls.Add(Me.btnArriba)
        Me.pnlMinimizar.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizar.Location = New System.Drawing.Point(1038, 16)
        Me.pnlMinimizar.Name = "pnlMinimizar"
        Me.pnlMinimizar.Size = New System.Drawing.Size(200, 97)
        Me.pnlMinimizar.TabIndex = 45
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(156, 39)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 53
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(152, 74)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 52
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBuscar.Location = New System.Drawing.Point(92, 77)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 51
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscar.Location = New System.Drawing.Point(95, 42)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 50
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(145, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(168, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbNaves
        '
        Me.cmbNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaves.ForeColor = System.Drawing.Color.Black
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(450, 55)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(394, 21)
        Me.cmbNaves.TabIndex = 3
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(406, 58)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 2
        Me.lblNave.Text = "Nave"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(305, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 3
        Me.pcbTitulo.TabStop = False
        '
        'CancelarPrestamosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1241, 529)
        Me.Controls.Add(Me.grdCancelar)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlBanner)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CancelarPrestamosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar Préstamos"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.grdCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.pnlMinimizar.ResumeLayout(False)
        Me.pnlMinimizar.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grdCancelar As System.Windows.Forms.DataGridView
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlMinimizar As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents clmidPrestamo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmCancelar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clmColaborador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTasaDeInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSinInteres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
