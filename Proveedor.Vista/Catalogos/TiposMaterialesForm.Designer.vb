<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TiposMaterialesForm
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TiposMaterialesForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdTiposMateriales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdTiposMateriales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnLimpiar)
        Me.pnlHeader.Controls.Add(Me.btnGuardar)
        Me.pnlHeader.Controls.Add(Me.lblAlta)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(650, 60)
        Me.pnlHeader.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(51, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Editar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(354, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(57, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(165, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Tipos de Materiales"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Proveedor.Vista.My.Resources.Resources.editar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(51, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 27
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_32
        Me.btnGuardar.Location = New System.Drawing.Point(12, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 25
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(16, 38)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 26
        Me.lblAlta.Text = "Alta"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 403)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 60)
        Me.Panel1.TabIndex = 5
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(404, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 7)
        Me.bntSalir.MaximumSize = New System.Drawing.Size(778, 498)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdTiposMateriales
        '
        Me.grdTiposMateriales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTiposMateriales.DisplayLayout.Appearance = Appearance1
        Me.grdTiposMateriales.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTiposMateriales.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdTiposMateriales.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdTiposMateriales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdTiposMateriales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdTiposMateriales.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdTiposMateriales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdTiposMateriales.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdTiposMateriales.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdTiposMateriales.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdTiposMateriales.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdTiposMateriales.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdTiposMateriales.Location = New System.Drawing.Point(0, 66)
        Me.grdTiposMateriales.Name = "grdTiposMateriales"
        Me.grdTiposMateriales.Size = New System.Drawing.Size(642, 331)
        Me.grdTiposMateriales.TabIndex = 63
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(228, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'TiposMaterialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(650, 463)
        Me.Controls.Add(Me.grdTiposMateriales)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(658, 488)
        Me.Name = "TiposMaterialesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipos de Materiales"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdTiposMateriales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents bntSalir As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdTiposMateriales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
