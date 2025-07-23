<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsignacionColaboradoresAvancesProduccionForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsignacionColaboradoresAvancesProduccionForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pblAlta = New System.Windows.Forms.Panel()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdEmpleadosDpto = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNaveBuscar = New System.Windows.Forms.Label()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pblAlta.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdEmpleadosDpto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 433)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(808, 56)
        Me.pnlInferior.TabIndex = 162
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(754, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(755, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(752, 37)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 102
        Me.lblLimpiar.Text = "Limpiar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(808, 63)
        Me.pnlEncabezado.TabIndex = 161
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(262, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(477, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Asignación de Colaboradores para Avances de Producción"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(740, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pblAlta)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlEditar)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(6, 1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(250, 60)
        Me.FlowLayoutPanel1.TabIndex = 2020
        '
        'pblAlta
        '
        Me.pblAlta.Controls.Add(Me.btnAlta)
        Me.pblAlta.Controls.Add(Me.lblAlta)
        Me.pblAlta.Location = New System.Drawing.Point(3, 3)
        Me.pblAlta.Name = "pblAlta"
        Me.pblAlta.Size = New System.Drawing.Size(60, 54)
        Me.pblAlta.TabIndex = 191
        '
        'btnAlta
        '
        Me.btnAlta.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.nuevo_321
        Me.btnAlta.Location = New System.Drawing.Point(14, 0)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 1
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(18, 37)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 189
        Me.lblAlta.Text = "Alta"
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Location = New System.Drawing.Point(69, 3)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(60, 54)
        Me.pnlEditar.TabIndex = 192
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Produccion.Vista.My.Resources.Resources.editar_322
        Me.btnEditar.Location = New System.Drawing.Point(14, 0)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(15, 37)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 191
        Me.lblEditar.Text = "Editar"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.lblExportarExcel)
        Me.Panel4.Location = New System.Drawing.Point(135, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(60, 54)
        Me.Panel4.TabIndex = 195
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.Button1.Location = New System.Drawing.Point(14, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(7, 30)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 26)
        Me.lblExportarExcel.TabIndex = 189
        Me.lblExportarExcel.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Excel"
        Me.lblExportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.grdEmpleadosDpto)
        Me.Panel1.Location = New System.Drawing.Point(0, 129)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(806, 302)
        Me.Panel1.TabIndex = 163
        '
        'grdEmpleadosDpto
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEmpleadosDpto.DisplayLayout.Appearance = Appearance1
        Me.grdEmpleadosDpto.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEmpleadosDpto.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdEmpleadosDpto.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdEmpleadosDpto.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEmpleadosDpto.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEmpleadosDpto.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEmpleadosDpto.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdEmpleadosDpto.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdEmpleadosDpto.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdEmpleadosDpto.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdEmpleadosDpto.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEmpleadosDpto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEmpleadosDpto.Location = New System.Drawing.Point(0, 0)
        Me.grdEmpleadosDpto.Name = "grdEmpleadosDpto"
        Me.grdEmpleadosDpto.Size = New System.Drawing.Size(802, 298)
        Me.grdEmpleadosDpto.TabIndex = 2005
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.rdoInactivo)
        Me.Panel2.Controls.Add(Me.rdoActivo)
        Me.Panel2.Controls.Add(Me.lblEstatus)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.cmbNave)
        Me.Panel2.Controls.Add(Me.lblNaveBuscar)
        Me.Panel2.Controls.Add(Me.lblMostrar)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(806, 58)
        Me.Panel2.TabIndex = 164
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Location = New System.Drawing.Point(344, 18)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(63, 17)
        Me.rdoInactivo.TabIndex = 2028
        Me.rdoInactivo.Text = "Inactivo"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Checked = True
        Me.rdoActivo.Location = New System.Drawing.Point(293, 18)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(55, 17)
        Me.rdoActivo.TabIndex = 2027
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Activo"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(245, 20)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(42, 13)
        Me.lblEstatus.TabIndex = 2026
        Me.lblEstatus.Text = "Estatus"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(755, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 35)
        Me.btnLimpiar.TabIndex = 101
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(52, 17)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(161, 21)
        Me.cmbNave.TabIndex = 106
        '
        'lblNaveBuscar
        '
        Me.lblNaveBuscar.AutoSize = True
        Me.lblNaveBuscar.Location = New System.Drawing.Point(17, 21)
        Me.lblNaveBuscar.Name = "lblNaveBuscar"
        Me.lblNaveBuscar.Size = New System.Drawing.Size(33, 13)
        Me.lblNaveBuscar.TabIndex = 104
        Me.lblNaveBuscar.Text = "Nave"
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(694, 37)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 108
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(697, 3)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 35)
        Me.btnMostrar.TabIndex = 107
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'AsignacionColaboradoresAvancesProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(808, 489)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "AsignacionColaboradoresAvancesProduccionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de Colaboradores para Avances de Producción"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pblAlta.ResumeLayout(False)
        Me.pblAlta.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdEmpleadosDpto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdEmpleadosDpto As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNaveBuscar As System.Windows.Forms.Label
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pblAlta As System.Windows.Forms.Panel
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
End Class
