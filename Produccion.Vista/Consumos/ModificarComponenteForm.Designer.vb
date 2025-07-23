<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarComponenteForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarComponenteForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblGuardarComponente = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnGuardarComponente = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblFechaAutorizacion = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.gbxActivo = New System.Windows.Forms.GroupBox()
        Me.rdoNo = New System.Windows.Forms.RadioButton()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.lblComponente = New System.Windows.Forms.Label()
        Me.txtComponente = New System.Windows.Forms.TextBox()
        Me.grdClasificacion = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxActivo.SuspendLayout()
        CType(Me.grdClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblGuardarComponente)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.Button1)
        Me.pnlInferior.Controls.Add(Me.btnGuardarComponente)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 469)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(482, 54)
        Me.pnlInferior.TabIndex = 2014
        '
        'lblGuardarComponente
        '
        Me.lblGuardarComponente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGuardarComponente.AutoSize = True
        Me.lblGuardarComponente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarComponente.Location = New System.Drawing.Point(371, 38)
        Me.lblGuardarComponente.Name = "lblGuardarComponente"
        Me.lblGuardarComponente.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarComponente.TabIndex = 102
        Me.lblGuardarComponente.Text = "Guardar"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(433, 40)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.Button1.Location = New System.Drawing.Point(434, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGuardarComponente
        '
        Me.btnGuardarComponente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarComponente.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarComponente.Location = New System.Drawing.Point(377, 3)
        Me.btnGuardarComponente.Name = "btnGuardarComponente"
        Me.btnGuardarComponente.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarComponente.TabIndex = 5
        Me.btnGuardarComponente.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Controls.Add(Me.lblFechaAutorizacion)
        Me.pnlEncabezado.Controls.Add(Me.lbl)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(482, 63)
        Me.pnlEncabezado.TabIndex = 2013
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(-460, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 16)
        Me.Label5.TabIndex = 232
        Me.Label5.Text = "VENTANA NO FUNCIONAL"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(40, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(372, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Asignación de clasificaciones a componentes"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(414, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblFechaAutorizacion
        '
        Me.lblFechaAutorizacion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblFechaAutorizacion.AutoSize = True
        Me.lblFechaAutorizacion.Location = New System.Drawing.Point(-113, 18)
        Me.lblFechaAutorizacion.Name = "lblFechaAutorizacion"
        Me.lblFechaAutorizacion.Size = New System.Drawing.Size(112, 13)
        Me.lblFechaAutorizacion.TabIndex = 228
        Me.lblFechaAutorizacion.Text = "Fecha de autorización"
        Me.lblFechaAutorizacion.Visible = False
        '
        'lbl
        '
        Me.lbl.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl.AutoSize = True
        Me.lbl.Location = New System.Drawing.Point(-47, 17)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(42, 13)
        Me.lbl.TabIndex = 229
        Me.lbl.Text = "Estatus"
        Me.lbl.Visible = False
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(26, 72)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(18, 13)
        Me.lblId.TabIndex = 2024
        Me.lblId.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(96, 69)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(59, 20)
        Me.txtID.TabIndex = 2020
        '
        'gbxActivo
        '
        Me.gbxActivo.Controls.Add(Me.rdoNo)
        Me.gbxActivo.Controls.Add(Me.rdoSi)
        Me.gbxActivo.Enabled = False
        Me.gbxActivo.Location = New System.Drawing.Point(347, 83)
        Me.gbxActivo.Name = "gbxActivo"
        Me.gbxActivo.Size = New System.Drawing.Size(91, 35)
        Me.gbxActivo.TabIndex = 2023
        Me.gbxActivo.TabStop = False
        Me.gbxActivo.Text = "Activo"
        '
        'rdoNo
        '
        Me.rdoNo.AutoSize = True
        Me.rdoNo.Location = New System.Drawing.Point(46, 14)
        Me.rdoNo.Name = "rdoNo"
        Me.rdoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdoNo.TabIndex = 4
        Me.rdoNo.Text = "No"
        Me.rdoNo.UseVisualStyleBackColor = True
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(6, 14)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 3
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'lblComponente
        '
        Me.lblComponente.AutoSize = True
        Me.lblComponente.Location = New System.Drawing.Point(26, 100)
        Me.lblComponente.Name = "lblComponente"
        Me.lblComponente.Size = New System.Drawing.Size(67, 13)
        Me.lblComponente.TabIndex = 2022
        Me.lblComponente.Text = "Componente"
        '
        'txtComponente
        '
        Me.txtComponente.Enabled = False
        Me.txtComponente.Location = New System.Drawing.Point(96, 97)
        Me.txtComponente.Name = "txtComponente"
        Me.txtComponente.Size = New System.Drawing.Size(227, 20)
        Me.txtComponente.TabIndex = 2021
        '
        'grdClasificacion
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificacion.DisplayLayout.Appearance = Appearance1
        Me.grdClasificacion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificacion.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdClasificacion.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClasificacion.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClasificacion.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdClasificacion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClasificacion.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdClasificacion.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdClasificacion.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClasificacion.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdClasificacion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClasificacion.Location = New System.Drawing.Point(0, 124)
        Me.grdClasificacion.Name = "grdClasificacion"
        Me.grdClasificacion.Size = New System.Drawing.Size(474, 330)
        Me.grdClasificacion.TabIndex = 2025
        '
        'ModificarComponenteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(482, 523)
        Me.Controls.Add(Me.grdClasificacion)
        Me.Controls.Add(Me.lblId)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.gbxActivo)
        Me.Controls.Add(Me.lblComponente)
        Me.Controls.Add(Me.txtComponente)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(490, 550)
        Me.MinimumSize = New System.Drawing.Size(490, 550)
        Me.Name = "ModificarComponenteForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de clasificaciones a componentes"
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxActivo.ResumeLayout(False)
        Me.gbxActivo.PerformLayout()
        CType(Me.grdClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblGuardarComponente As System.Windows.Forms.Label
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnGuardarComponente As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblFechaAutorizacion As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lblId As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents gbxActivo As System.Windows.Forms.GroupBox
    Friend WithEvents rdoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents lblComponente As System.Windows.Forms.Label
    Friend WithEvents txtComponente As System.Windows.Forms.TextBox
    Friend WithEvents grdClasificacion As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
