<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoMaterialesMercadotecniaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoMaterialesMercadotecniaForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.grbMaterialesMercadotecnia = New System.Windows.Forms.GroupBox()
        Me.cboMaterialesMercadotecniaTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipoMaterial = New System.Windows.Forms.Label()
        Me.rdoSi = New System.Windows.Forms.RadioButton()
        Me.btnNo = New System.Windows.Forms.RadioButton()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblNombreDelMaterial = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.txtNombreDelMaterial = New System.Windows.Forms.TextBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblListaCatalogoMaterialesMercadotecnia = New System.Windows.Forms.Label()
        Me.Editar = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridListaMaterialesMercadotecnia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grbMaterialesMercadotecnia.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridListaMaterialesMercadotecnia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbMaterialesMercadotecnia
        '
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.cboMaterialesMercadotecniaTipo)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.lblTipoMaterial)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.rdoSi)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.btnNo)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.btnAbajo)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.btnArriba)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.lblBúscar)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.lblLimpiar)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.btnLimpiar)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.btnBuscar)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.lblNombreDelMaterial)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.lblActivo)
        Me.grbMaterialesMercadotecnia.Controls.Add(Me.txtNombreDelMaterial)
        Me.grbMaterialesMercadotecnia.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbMaterialesMercadotecnia.Location = New System.Drawing.Point(0, 53)
        Me.grbMaterialesMercadotecnia.Name = "grbMaterialesMercadotecnia"
        Me.grbMaterialesMercadotecnia.Size = New System.Drawing.Size(584, 135)
        Me.grbMaterialesMercadotecnia.TabIndex = 14
        Me.grbMaterialesMercadotecnia.TabStop = False
        '
        'cboMaterialesMercadotecniaTipo
        '
        Me.cboMaterialesMercadotecniaTipo.FormattingEnabled = True
        Me.cboMaterialesMercadotecniaTipo.Location = New System.Drawing.Point(76, 42)
        Me.cboMaterialesMercadotecniaTipo.Name = "cboMaterialesMercadotecniaTipo"
        Me.cboMaterialesMercadotecniaTipo.Size = New System.Drawing.Size(361, 21)
        Me.cboMaterialesMercadotecniaTipo.TabIndex = 38
        '
        'lblTipoMaterial
        '
        Me.lblTipoMaterial.AutoSize = True
        Me.lblTipoMaterial.Location = New System.Drawing.Point(23, 45)
        Me.lblTipoMaterial.Name = "lblTipoMaterial"
        Me.lblTipoMaterial.Size = New System.Drawing.Size(28, 13)
        Me.lblTipoMaterial.TabIndex = 37
        Me.lblTipoMaterial.Text = "Tipo"
        '
        'rdoSi
        '
        Me.rdoSi.AutoSize = True
        Me.rdoSi.Checked = True
        Me.rdoSi.Location = New System.Drawing.Point(76, 109)
        Me.rdoSi.Name = "rdoSi"
        Me.rdoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdoSi.TabIndex = 3
        Me.rdoSi.TabStop = True
        Me.rdoSi.Text = "Si"
        Me.rdoSi.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.AutoSize = True
        Me.btnNo.Location = New System.Drawing.Point(130, 109)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(39, 17)
        Me.btnNo.TabIndex = 4
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(541, 8)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 8
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(517, 8)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 7
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(486, 116)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 26
        Me.lblBúscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(534, 116)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 25
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(541, 82)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(489, 82)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblNombreDelMaterial
        '
        Me.lblNombreDelMaterial.AutoSize = True
        Me.lblNombreDelMaterial.Location = New System.Drawing.Point(23, 78)
        Me.lblNombreDelMaterial.Name = "lblNombreDelMaterial"
        Me.lblNombreDelMaterial.Size = New System.Drawing.Size(44, 13)
        Me.lblNombreDelMaterial.TabIndex = 7
        Me.lblNombreDelMaterial.Text = "Material"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(23, 111)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 5
        Me.lblActivo.Text = "Activo"
        '
        'txtNombreDelMaterial
        '
        Me.txtNombreDelMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreDelMaterial.Location = New System.Drawing.Point(76, 75)
        Me.txtNombreDelMaterial.MaxLength = 50
        Me.txtNombreDelMaterial.Name = "txtNombreDelMaterial"
        Me.txtNombreDelMaterial.Size = New System.Drawing.Size(361, 20)
        Me.txtNombreDelMaterial.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.lblListaCatalogoMaterialesMercadotecnia)
        Me.pnlEncabezado.Controls.Add(Me.Editar)
        Me.pnlEncabezado.Controls.Add(Me.btnEditar)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(584, 53)
        Me.pnlEncabezado.TabIndex = 13
        '
        'lblListaCatalogoMaterialesMercadotecnia
        '
        Me.lblListaCatalogoMaterialesMercadotecnia.AutoSize = True
        Me.lblListaCatalogoMaterialesMercadotecnia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaCatalogoMaterialesMercadotecnia.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaCatalogoMaterialesMercadotecnia.Location = New System.Drawing.Point(295, 16)
        Me.lblListaCatalogoMaterialesMercadotecnia.Name = "lblListaCatalogoMaterialesMercadotecnia"
        Me.lblListaCatalogoMaterialesMercadotecnia.Size = New System.Drawing.Size(215, 20)
        Me.lblListaCatalogoMaterialesMercadotecnia.TabIndex = 21
        Me.lblListaCatalogoMaterialesMercadotecnia.Text = "Materiales Mercadotecnia"
        '
        'Editar
        '
        Me.Editar.AutoSize = True
        Me.Editar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Editar.Location = New System.Drawing.Point(64, 37)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(34, 13)
        Me.Editar.TabIndex = 19
        Me.Editar.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(64, 2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 11
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAltas
        '
        Me.btnAltas.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 2)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 10
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(18, 37)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Altas"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridListaMaterialesMercadotecnia)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 188)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(584, 273)
        Me.Panel1.TabIndex = 15
        '
        'gridListaMaterialesMercadotecnia
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Appearance = Appearance1
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridListaMaterialesMercadotecnia.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaMaterialesMercadotecnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridListaMaterialesMercadotecnia.Location = New System.Drawing.Point(0, 0)
        Me.gridListaMaterialesMercadotecnia.Name = "gridListaMaterialesMercadotecnia"
        Me.gridListaMaterialesMercadotecnia.Size = New System.Drawing.Size(584, 273)
        Me.gridListaMaterialesMercadotecnia.TabIndex = 9
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(516, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'CatalogoMaterialesMercadotecniaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbMaterialesMercadotecnia)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(600, 500)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 500)
        Me.MinimizeBox = False
        Me.Name = "CatalogoMaterialesMercadotecniaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Materiales Mercadotecnia"
        Me.grbMaterialesMercadotecnia.ResumeLayout(False)
        Me.grbMaterialesMercadotecnia.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridListaMaterialesMercadotecnia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbMaterialesMercadotecnia As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSi As System.Windows.Forms.RadioButton
    Friend WithEvents btnNo As System.Windows.Forms.RadioButton
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblNombreDelMaterial As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtNombreDelMaterial As System.Windows.Forms.TextBox
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblListaCatalogoMaterialesMercadotecnia As System.Windows.Forms.Label
    Friend WithEvents Editar As System.Windows.Forms.Label
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents lblTipoMaterial As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridListaMaterialesMercadotecnia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cboMaterialesMercadotecniaTipo As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
