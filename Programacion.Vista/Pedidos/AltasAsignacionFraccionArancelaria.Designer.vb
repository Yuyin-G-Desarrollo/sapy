<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltasAsignacionFraccionArancelariaForm
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
        Me.gpbCaracteristicasDelArticulo = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cmbCorte = New System.Windows.Forms.ComboBox()
        Me.cmbCorrida = New System.Windows.Forms.ComboBox()
        Me.cmbForro = New System.Windows.Forms.ComboBox()
        Me.cmbSuela = New System.Windows.Forms.ComboBox()
        Me.cmbFalimias = New System.Windows.Forms.ComboBox()
        Me.lblCorte = New System.Windows.Forms.Label()
        Me.lblCorrida = New System.Windows.Forms.Label()
        Me.lblForro = New System.Windows.Forms.Label()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.lblSuela = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardarFraccion = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.cmbFraccionAAsignar = New System.Windows.Forms.ComboBox()
        Me.gpbFraccionAAsignar = New System.Windows.Forms.GroupBox()
        Me.gpbTallas = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdTallas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.chkSeleccionarTodo_Tallas = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gpbCaracteristicasDelArticulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.gpbFraccionAAsignar.SuspendLayout()
        Me.gpbTallas.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbCaracteristicasDelArticulo
        '
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.cmbTipo)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.lblTipo)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.cmbCorte)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.cmbCorrida)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.cmbForro)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.cmbSuela)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.cmbFalimias)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.lblCorte)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.lblCorrida)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.lblForro)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.lblFamilia)
        Me.gpbCaracteristicasDelArticulo.Controls.Add(Me.lblSuela)
        Me.gpbCaracteristicasDelArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbCaracteristicasDelArticulo.Location = New System.Drawing.Point(8, 128)
        Me.gpbCaracteristicasDelArticulo.Name = "gpbCaracteristicasDelArticulo"
        Me.gpbCaracteristicasDelArticulo.Size = New System.Drawing.Size(245, 296)
        Me.gpbCaracteristicasDelArticulo.TabIndex = 3
        Me.gpbCaracteristicasDelArticulo.TabStop = False
        Me.gpbCaracteristicasDelArticulo.Text = "Características del artículo"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(59, 202)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(177, 21)
        Me.cmbTipo.TabIndex = 8
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTipo.Location = New System.Drawing.Point(9, 205)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(32, 13)
        Me.lblTipo.TabIndex = 85
        Me.lblTipo.Text = "*Tipo"
        '
        'cmbCorte
        '
        Me.cmbCorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCorte.FormattingEnabled = True
        Me.cmbCorte.Location = New System.Drawing.Point(59, 76)
        Me.cmbCorte.Name = "cmbCorte"
        Me.cmbCorte.Size = New System.Drawing.Size(177, 21)
        Me.cmbCorte.TabIndex = 5
        '
        'cmbCorrida
        '
        Me.cmbCorrida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCorrida.FormattingEnabled = True
        Me.cmbCorrida.Location = New System.Drawing.Point(59, 244)
        Me.cmbCorrida.Name = "cmbCorrida"
        Me.cmbCorrida.Size = New System.Drawing.Size(177, 21)
        Me.cmbCorrida.TabIndex = 9
        '
        'cmbForro
        '
        Me.cmbForro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbForro.FormattingEnabled = True
        Me.cmbForro.Location = New System.Drawing.Point(59, 118)
        Me.cmbForro.Name = "cmbForro"
        Me.cmbForro.Size = New System.Drawing.Size(177, 21)
        Me.cmbForro.TabIndex = 6
        '
        'cmbSuela
        '
        Me.cmbSuela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSuela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSuela.FormattingEnabled = True
        Me.cmbSuela.Location = New System.Drawing.Point(59, 160)
        Me.cmbSuela.Name = "cmbSuela"
        Me.cmbSuela.Size = New System.Drawing.Size(177, 21)
        Me.cmbSuela.TabIndex = 7
        '
        'cmbFalimias
        '
        Me.cmbFalimias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFalimias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFalimias.FormattingEnabled = True
        Me.cmbFalimias.Location = New System.Drawing.Point(59, 34)
        Me.cmbFalimias.Name = "cmbFalimias"
        Me.cmbFalimias.Size = New System.Drawing.Size(177, 21)
        Me.cmbFalimias.TabIndex = 4
        '
        'lblCorte
        '
        Me.lblCorte.AutoSize = True
        Me.lblCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCorte.Location = New System.Drawing.Point(9, 79)
        Me.lblCorte.Name = "lblCorte"
        Me.lblCorte.Size = New System.Drawing.Size(36, 13)
        Me.lblCorte.TabIndex = 79
        Me.lblCorte.Text = "*Corte"
        '
        'lblCorrida
        '
        Me.lblCorrida.AutoSize = True
        Me.lblCorrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCorrida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCorrida.Location = New System.Drawing.Point(9, 247)
        Me.lblCorrida.Name = "lblCorrida"
        Me.lblCorrida.Size = New System.Drawing.Size(44, 13)
        Me.lblCorrida.TabIndex = 78
        Me.lblCorrida.Text = "*Corrida"
        '
        'lblForro
        '
        Me.lblForro.AutoSize = True
        Me.lblForro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForro.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblForro.Location = New System.Drawing.Point(9, 121)
        Me.lblForro.Name = "lblForro"
        Me.lblForro.Size = New System.Drawing.Size(35, 13)
        Me.lblForro.TabIndex = 77
        Me.lblForro.Text = "*Forro"
        '
        'lblFamilia
        '
        Me.lblFamilia.AutoSize = True
        Me.lblFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFamilia.Location = New System.Drawing.Point(9, 37)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(43, 13)
        Me.lblFamilia.TabIndex = 7
        Me.lblFamilia.Text = "*Familia"
        '
        'lblSuela
        '
        Me.lblSuela.AutoSize = True
        Me.lblSuela.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuela.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSuela.Location = New System.Drawing.Point(9, 163)
        Me.lblSuela.Name = "lblSuela"
        Me.lblSuela.Size = New System.Drawing.Size(38, 13)
        Me.lblSuela.TabIndex = 3
        Me.lblSuela.Text = "*Suela"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 450)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(745, 60)
        Me.pnlPie.TabIndex = 16
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardarFraccion)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(585, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(160, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardarFraccion
        '
        Me.btnGuardarFraccion.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarFraccion.Location = New System.Drawing.Point(52, 8)
        Me.btnGuardarFraccion.Name = "btnGuardarFraccion"
        Me.btnGuardarFraccion.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarFraccion.TabIndex = 13
        Me.btnGuardarFraccion.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(46, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 6
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(106, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(745, 60)
        Me.pnlEncabezado.TabIndex = 15
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(161, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(584, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(139, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(376, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Características Artículo - Fracción Arancelaria"
        '
        'cmbFraccionAAsignar
        '
        Me.cmbFraccionAAsignar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFraccionAAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFraccionAAsignar.FormattingEnabled = True
        Me.cmbFraccionAAsignar.Location = New System.Drawing.Point(6, 19)
        Me.cmbFraccionAAsignar.Name = "cmbFraccionAAsignar"
        Me.cmbFraccionAAsignar.Size = New System.Drawing.Size(707, 21)
        Me.cmbFraccionAAsignar.TabIndex = 2
        '
        'gpbFraccionAAsignar
        '
        Me.gpbFraccionAAsignar.Controls.Add(Me.cmbFraccionAAsignar)
        Me.gpbFraccionAAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbFraccionAAsignar.Location = New System.Drawing.Point(8, 66)
        Me.gpbFraccionAAsignar.Name = "gpbFraccionAAsignar"
        Me.gpbFraccionAAsignar.Size = New System.Drawing.Size(719, 56)
        Me.gpbFraccionAAsignar.TabIndex = 1
        Me.gpbFraccionAAsignar.TabStop = False
        Me.gpbFraccionAAsignar.Text = "Fracción Arancelaria A Asignar"
        '
        'gpbTallas
        '
        Me.gpbTallas.Controls.Add(Me.Panel4)
        Me.gpbTallas.Controls.Add(Me.chkSeleccionarTodo_Tallas)
        Me.gpbTallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbTallas.Location = New System.Drawing.Point(259, 128)
        Me.gpbTallas.Name = "gpbTallas"
        Me.gpbTallas.Size = New System.Drawing.Size(468, 296)
        Me.gpbTallas.TabIndex = 10
        Me.gpbTallas.TabStop = False
        Me.gpbTallas.Text = "Tallas"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdTallas)
        Me.Panel4.Location = New System.Drawing.Point(6, 39)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(456, 251)
        Me.Panel4.TabIndex = 1
        '
        'grdTallas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTallas.DisplayLayout.Appearance = Appearance1
        Me.grdTallas.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdTallas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTallas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTallas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTallas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTallas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand
        Me.grdTallas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTallas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdTallas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTallas.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdTallas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdTallas.Location = New System.Drawing.Point(0, 0)
        Me.grdTallas.Name = "grdTallas"
        Me.grdTallas.Size = New System.Drawing.Size(456, 251)
        Me.grdTallas.TabIndex = 17
        '
        'chkSeleccionarTodo_Tallas
        '
        Me.chkSeleccionarTodo_Tallas.AutoSize = True
        Me.chkSeleccionarTodo_Tallas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionarTodo_Tallas.Location = New System.Drawing.Point(6, 16)
        Me.chkSeleccionarTodo_Tallas.Name = "chkSeleccionarTodo_Tallas"
        Me.chkSeleccionarTodo_Tallas.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo_Tallas.TabIndex = 11
        Me.chkSeleccionarTodo_Tallas.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo_Tallas.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(522, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AltasAsignacionFraccionArancelariaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(745, 510)
        Me.Controls.Add(Me.gpbTallas)
        Me.Controls.Add(Me.gpbFraccionAAsignar)
        Me.Controls.Add(Me.gpbCaracteristicasDelArticulo)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(751, 532)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(751, 532)
        Me.Name = "AltasAsignacionFraccionArancelariaForm"
        Me.Text = "Características Artículo - Fracción Arancelaria"
        Me.gpbCaracteristicasDelArticulo.ResumeLayout(False)
        Me.gpbCaracteristicasDelArticulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.gpbFraccionAAsignar.ResumeLayout(False)
        Me.gpbTallas.ResumeLayout(False)
        Me.gpbTallas.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbCaracteristicasDelArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents lblFamilia As System.Windows.Forms.Label
    Friend WithEvents lblSuela As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnGuardarFraccion As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents cmbCorte As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCorrida As System.Windows.Forms.ComboBox
    Friend WithEvents cmbForro As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSuela As System.Windows.Forms.ComboBox
    Friend WithEvents cmbFalimias As System.Windows.Forms.ComboBox
    Friend WithEvents lblCorte As System.Windows.Forms.Label
    Friend WithEvents lblCorrida As System.Windows.Forms.Label
    Friend WithEvents lblForro As System.Windows.Forms.Label
    Friend WithEvents cmbFraccionAAsignar As System.Windows.Forms.ComboBox
    Friend WithEvents gpbFraccionAAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents gpbTallas As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionarTodo_Tallas As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents grdTallas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PictureBox1 As PictureBox
End Class
