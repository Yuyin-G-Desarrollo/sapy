<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLimiteCapacidad
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLimiteCapacidad))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblListaNaves = New System.Windows.Forms.Label()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grdLimiteCapacidad = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbNaves = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLineas = New System.Windows.Forms.ComboBox()
        Me.cmbSimulaciones = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlValores = New System.Windows.Forms.Panel()
        Me.chkPorcentaje = New System.Windows.Forms.CheckBox()
        Me.chkLlenarTodo = New System.Windows.Forms.CheckBox()
        Me.numAnio = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdLimiteCapacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbNaves.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlValores.SuspendLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(611, 59)
        Me.pnlEncabezado.TabIndex = 5
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblListaNaves)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(283, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(328, 59)
        Me.pnlTitulo.TabIndex = 33
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(260, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 22
        Me.pcbTitulo.TabStop = False
        '
        'imgLogo
        '
        Me.imgLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgLogo.Location = New System.Drawing.Point(267, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(61, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'lblListaNaves
        '
        Me.lblListaNaves.AutoSize = True
        Me.lblListaNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblListaNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaNaves.Location = New System.Drawing.Point(114, 19)
        Me.lblListaNaves.Name = "lblListaNaves"
        Me.lblListaNaves.Size = New System.Drawing.Size(147, 20)
        Me.lblListaNaves.TabIndex = 21
        Me.lblListaNaves.Text = "Límite Capacidad"
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 469)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(611, 60)
        Me.pnlExtado.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(465, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(146, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(29, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 13
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(35, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(89, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(90, 7)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grdLimiteCapacidad
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLimiteCapacidad.DisplayLayout.Appearance = Appearance1
        Me.grdLimiteCapacidad.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdLimiteCapacidad.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdLimiteCapacidad.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLimiteCapacidad.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLimiteCapacidad.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLimiteCapacidad.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdLimiteCapacidad.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLimiteCapacidad.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdLimiteCapacidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLimiteCapacidad.Location = New System.Drawing.Point(0, 189)
        Me.grdLimiteCapacidad.Name = "grdLimiteCapacidad"
        Me.grdLimiteCapacidad.Size = New System.Drawing.Size(611, 280)
        Me.grdLimiteCapacidad.TabIndex = 21
        '
        'grbNaves
        '
        Me.grbNaves.Controls.Add(Me.Label5)
        Me.grbNaves.Controls.Add(Me.Label1)
        Me.grbNaves.Controls.Add(Me.cmbLineas)
        Me.grbNaves.Controls.Add(Me.cmbSimulaciones)
        Me.grbNaves.Controls.Add(Me.Panel2)
        Me.grbNaves.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbNaves.Location = New System.Drawing.Point(0, 59)
        Me.grbNaves.Name = "grbNaves"
        Me.grbNaves.Size = New System.Drawing.Size(611, 130)
        Me.grbNaves.TabIndex = 22
        Me.grbNaves.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Simulación:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Linea:"
        '
        'cmbLineas
        '
        Me.cmbLineas.FormattingEnabled = True
        Me.cmbLineas.Location = New System.Drawing.Point(72, 96)
        Me.cmbLineas.Name = "cmbLineas"
        Me.cmbLineas.Size = New System.Drawing.Size(239, 21)
        Me.cmbLineas.TabIndex = 33
        '
        'cmbSimulaciones
        '
        Me.cmbSimulaciones.FormattingEnabled = True
        Me.cmbSimulaciones.Location = New System.Drawing.Point(72, 67)
        Me.cmbSimulaciones.Name = "cmbSimulaciones"
        Me.cmbSimulaciones.Size = New System.Drawing.Size(239, 21)
        Me.cmbSimulaciones.TabIndex = 32
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.pnlValores)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(318, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(290, 111)
        Me.Panel2.TabIndex = 31
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(232, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 36
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'pnlValores
        '
        Me.pnlValores.Controls.Add(Me.chkPorcentaje)
        Me.pnlValores.Controls.Add(Me.chkLlenarTodo)
        Me.pnlValores.Controls.Add(Me.numAnio)
        Me.pnlValores.Controls.Add(Me.Label2)
        Me.pnlValores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlValores.Location = New System.Drawing.Point(0, 40)
        Me.pnlValores.Name = "pnlValores"
        Me.pnlValores.Size = New System.Drawing.Size(290, 71)
        Me.pnlValores.TabIndex = 35
        '
        'chkPorcentaje
        '
        Me.chkPorcentaje.AutoSize = True
        Me.chkPorcentaje.Location = New System.Drawing.Point(147, 44)
        Me.chkPorcentaje.Name = "chkPorcentaje"
        Me.chkPorcentaje.Size = New System.Drawing.Size(34, 17)
        Me.chkPorcentaje.TabIndex = 37
        Me.chkPorcentaje.Text = "%"
        Me.chkPorcentaje.UseVisualStyleBackColor = True
        '
        'chkLlenarTodo
        '
        Me.chkLlenarTodo.AutoSize = True
        Me.chkLlenarTodo.Location = New System.Drawing.Point(50, 44)
        Me.chkLlenarTodo.Name = "chkLlenarTodo"
        Me.chkLlenarTodo.Size = New System.Drawing.Size(79, 17)
        Me.chkLlenarTodo.TabIndex = 36
        Me.chkLlenarTodo.Text = "Llenar todo"
        Me.chkLlenarTodo.UseVisualStyleBackColor = True
        '
        'numAnio
        '
        Me.numAnio.Location = New System.Drawing.Point(50, 10)
        Me.numAnio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnio.Minimum = New Decimal(New Integer() {2015, 0, 0, 0})
        Me.numAnio.Name = "numAnio"
        Me.numAnio.Size = New System.Drawing.Size(90, 20)
        Me.numAnio.TabIndex = 35
        Me.numAnio.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Año:"
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(261, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'frmLimiteCapacidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(611, 529)
        Me.Controls.Add(Me.grdLimiteCapacidad)
        Me.Controls.Add(Me.grbNaves)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmLimiteCapacidad"
        Me.Text = "Límite Capacidad"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdLimiteCapacidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbNaves.ResumeLayout(False)
        Me.grbNaves.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlValores.ResumeLayout(False)
        Me.pnlValores.PerformLayout()
        CType(Me.numAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaNaves As System.Windows.Forms.Label
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grdLimiteCapacidad As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbNaves As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlValores As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbLineas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSimulaciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkLlenarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents chkPorcentaje As System.Windows.Forms.CheckBox
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
End Class
