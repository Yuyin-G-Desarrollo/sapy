<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarArticulo_SuelaForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarArticulo_SuelaForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.lblTextoConsumo = New System.Windows.Forms.Label()
        Me.lblConsumoSuela = New System.Windows.Forms.Label()
        Me.gboxEditarArticulo = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdEditarArticulo = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.lblTextoArticulo = New System.Windows.Forms.Label()
        Me.lblArticulo2 = New System.Windows.Forms.Label()
        Me.lblArticulo1 = New System.Windows.Forms.Label()
        Me.PicFoto = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbAcabado = New System.Windows.Forms.ComboBox()
        Me.lblAcabado = New System.Windows.Forms.Label()
        Me.cmbFamilia = New System.Windows.Forms.ComboBox()
        Me.lblFamilia = New System.Windows.Forms.Label()
        Me.cmbColorSuelaDos = New System.Windows.Forms.ComboBox()
        Me.lblColorSuelaDos = New System.Windows.Forms.Label()
        Me.cmbColorSuela = New System.Windows.Forms.ComboBox()
        Me.lblColorSuela = New System.Windows.Forms.Label()
        Me.cmbSuela = New System.Windows.Forms.ComboBox()
        Me.lblSuela = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.gboxEditarArticulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdEditarArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlContenido)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(942, 563)
        Me.pnlContenedor.TabIndex = 1
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(942, 563)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.lblTextoConsumo)
        Me.pnlInformacionAlta.Controls.Add(Me.lblConsumoSuela)
        Me.pnlInformacionAlta.Controls.Add(Me.gboxEditarArticulo)
        Me.pnlInformacionAlta.Controls.Add(Me.lblTextoArticulo)
        Me.pnlInformacionAlta.Controls.Add(Me.lblArticulo2)
        Me.pnlInformacionAlta.Controls.Add(Me.lblArticulo1)
        Me.pnlInformacionAlta.Controls.Add(Me.PicFoto)
        Me.pnlInformacionAlta.Controls.Add(Me.PictureBox1)
        Me.pnlInformacionAlta.Controls.Add(Me.pnlEncabezado)
        Me.pnlInformacionAlta.Controls.Add(Me.GroupBox1)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(942, 492)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'lblTextoConsumo
        '
        Me.lblTextoConsumo.AutoSize = True
        Me.lblTextoConsumo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoConsumo.Location = New System.Drawing.Point(3, 104)
        Me.lblTextoConsumo.Name = "lblTextoConsumo"
        Me.lblTextoConsumo.Size = New System.Drawing.Size(78, 18)
        Me.lblTextoConsumo.TabIndex = 2023
        Me.lblTextoConsumo.Text = "Consumo:"
        '
        'lblConsumoSuela
        '
        Me.lblConsumoSuela.AutoSize = True
        Me.lblConsumoSuela.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsumoSuela.Location = New System.Drawing.Point(87, 104)
        Me.lblConsumoSuela.Name = "lblConsumoSuela"
        Me.lblConsumoSuela.Size = New System.Drawing.Size(12, 16)
        Me.lblConsumoSuela.TabIndex = 2023
        Me.lblConsumoSuela.Text = "-"
        '
        'gboxEditarArticulo
        '
        Me.gboxEditarArticulo.Controls.Add(Me.Panel2)
        Me.gboxEditarArticulo.Location = New System.Drawing.Point(0, 87)
        Me.gboxEditarArticulo.Name = "gboxEditarArticulo"
        Me.gboxEditarArticulo.Size = New System.Drawing.Size(934, 137)
        Me.gboxEditarArticulo.TabIndex = 2022
        Me.gboxEditarArticulo.TabStop = False
        Me.gboxEditarArticulo.Text = "Artículos"
        Me.gboxEditarArticulo.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdEditarArticulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(928, 113)
        Me.Panel2.TabIndex = 2
        '
        'grdEditarArticulo
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEditarArticulo.DisplayLayout.Appearance = Appearance1
        Me.grdEditarArticulo.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdEditarArticulo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEditarArticulo.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdEditarArticulo.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdEditarArticulo.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEditarArticulo.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdEditarArticulo.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEditarArticulo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEditarArticulo.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdEditarArticulo.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdEditarArticulo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEditarArticulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEditarArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEditarArticulo.Location = New System.Drawing.Point(0, 0)
        Me.grdEditarArticulo.Name = "grdEditarArticulo"
        Me.grdEditarArticulo.Size = New System.Drawing.Size(928, 113)
        Me.grdEditarArticulo.TabIndex = 2
        '
        'lblTextoArticulo
        '
        Me.lblTextoArticulo.AutoSize = True
        Me.lblTextoArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoArticulo.Location = New System.Drawing.Point(3, 66)
        Me.lblTextoArticulo.Name = "lblTextoArticulo"
        Me.lblTextoArticulo.Size = New System.Drawing.Size(61, 18)
        Me.lblTextoArticulo.TabIndex = 2021
        Me.lblTextoArticulo.Text = "Artículo:"
        '
        'lblArticulo2
        '
        Me.lblArticulo2.AutoSize = True
        Me.lblArticulo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo2.Location = New System.Drawing.Point(67, 84)
        Me.lblArticulo2.Name = "lblArticulo2"
        Me.lblArticulo2.Size = New System.Drawing.Size(12, 16)
        Me.lblArticulo2.TabIndex = 2021
        Me.lblArticulo2.Text = "-"
        '
        'lblArticulo1
        '
        Me.lblArticulo1.AutoSize = True
        Me.lblArticulo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo1.Location = New System.Drawing.Point(67, 66)
        Me.lblArticulo1.Name = "lblArticulo1"
        Me.lblArticulo1.Size = New System.Drawing.Size(12, 16)
        Me.lblArticulo1.TabIndex = 2021
        Me.lblArticulo1.Text = "-"
        '
        'PicFoto
        '
        Me.PicFoto.BackColor = System.Drawing.Color.White
        Me.PicFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFoto.Location = New System.Drawing.Point(336, 124)
        Me.PicFoto.Name = "PicFoto"
        Me.PicFoto.Size = New System.Drawing.Size(263, 136)
        Me.PicFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicFoto.TabIndex = 2020
        Me.PicFoto.TabStop = False
        Me.PicFoto.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(-23, -46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 2019
        Me.PictureBox1.TabStop = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(942, 63)
        Me.pnlEncabezado.TabIndex = 2018
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(694, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(174, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Editar Suela Artículo"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(874, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbAcabado)
        Me.GroupBox1.Controls.Add(Me.lblAcabado)
        Me.GroupBox1.Controls.Add(Me.cmbFamilia)
        Me.GroupBox1.Controls.Add(Me.lblFamilia)
        Me.GroupBox1.Controls.Add(Me.cmbColorSuelaDos)
        Me.GroupBox1.Controls.Add(Me.lblColorSuelaDos)
        Me.GroupBox1.Controls.Add(Me.cmbColorSuela)
        Me.GroupBox1.Controls.Add(Me.lblColorSuela)
        Me.GroupBox1.Controls.Add(Me.cmbSuela)
        Me.GroupBox1.Controls.Add(Me.lblSuela)
        Me.GroupBox1.Location = New System.Drawing.Point(256, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(423, 211)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmbAcabado
        '
        Me.cmbAcabado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAcabado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAcabado.FormattingEnabled = True
        Me.cmbAcabado.Location = New System.Drawing.Point(73, 164)
        Me.cmbAcabado.Name = "cmbAcabado"
        Me.cmbAcabado.Size = New System.Drawing.Size(307, 21)
        Me.cmbAcabado.TabIndex = 29
        '
        'lblAcabado
        '
        Me.lblAcabado.AutoSize = True
        Me.lblAcabado.ForeColor = System.Drawing.Color.Black
        Me.lblAcabado.Location = New System.Drawing.Point(10, 167)
        Me.lblAcabado.Name = "lblAcabado"
        Me.lblAcabado.Size = New System.Drawing.Size(57, 13)
        Me.lblAcabado.TabIndex = 28
        Me.lblAcabado.Text = "* Acabado"
        '
        'cmbFamilia
        '
        Me.cmbFamilia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFamilia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFamilia.FormattingEnabled = True
        Me.cmbFamilia.Location = New System.Drawing.Point(72, 126)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(307, 21)
        Me.cmbFamilia.TabIndex = 27
        '
        'lblFamilia
        '
        Me.lblFamilia.AutoSize = True
        Me.lblFamilia.ForeColor = System.Drawing.Color.Black
        Me.lblFamilia.Location = New System.Drawing.Point(20, 129)
        Me.lblFamilia.Name = "lblFamilia"
        Me.lblFamilia.Size = New System.Drawing.Size(46, 13)
        Me.lblFamilia.TabIndex = 26
        Me.lblFamilia.Text = "* Familia"
        '
        'cmbColorSuelaDos
        '
        Me.cmbColorSuelaDos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbColorSuelaDos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColorSuelaDos.FormattingEnabled = True
        Me.cmbColorSuelaDos.Location = New System.Drawing.Point(72, 91)
        Me.cmbColorSuelaDos.Name = "cmbColorSuelaDos"
        Me.cmbColorSuelaDos.Size = New System.Drawing.Size(307, 21)
        Me.cmbColorSuelaDos.TabIndex = 25
        '
        'lblColorSuelaDos
        '
        Me.lblColorSuelaDos.AutoSize = True
        Me.lblColorSuelaDos.ForeColor = System.Drawing.Color.Black
        Me.lblColorSuelaDos.Location = New System.Drawing.Point(13, 94)
        Me.lblColorSuelaDos.Name = "lblColorSuelaDos"
        Me.lblColorSuelaDos.Size = New System.Drawing.Size(53, 13)
        Me.lblColorSuelaDos.TabIndex = 24
        Me.lblColorSuelaDos.Text = "Color Dos"
        '
        'cmbColorSuela
        '
        Me.cmbColorSuela.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbColorSuela.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColorSuela.FormattingEnabled = True
        Me.cmbColorSuela.Location = New System.Drawing.Point(73, 58)
        Me.cmbColorSuela.Name = "cmbColorSuela"
        Me.cmbColorSuela.Size = New System.Drawing.Size(307, 21)
        Me.cmbColorSuela.TabIndex = 2
        '
        'lblColorSuela
        '
        Me.lblColorSuela.AutoSize = True
        Me.lblColorSuela.ForeColor = System.Drawing.Color.Black
        Me.lblColorSuela.Location = New System.Drawing.Point(6, 61)
        Me.lblColorSuela.Name = "lblColorSuela"
        Me.lblColorSuela.Size = New System.Drawing.Size(61, 13)
        Me.lblColorSuela.TabIndex = 23
        Me.lblColorSuela.Text = "* Color Uno"
        '
        'cmbSuela
        '
        Me.cmbSuela.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSuela.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSuela.FormattingEnabled = True
        Me.cmbSuela.Location = New System.Drawing.Point(73, 25)
        Me.cmbSuela.Name = "cmbSuela"
        Me.cmbSuela.Size = New System.Drawing.Size(307, 21)
        Me.cmbSuela.TabIndex = 1
        '
        'lblSuela
        '
        Me.lblSuela.AutoSize = True
        Me.lblSuela.ForeColor = System.Drawing.Color.Black
        Me.lblSuela.Location = New System.Drawing.Point(23, 28)
        Me.lblSuela.Name = "lblSuela"
        Me.lblSuela.Size = New System.Drawing.Size(44, 13)
        Me.lblSuela.TabIndex = 21
        Me.lblSuela.Text = "* Suela "
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 492)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(942, 71)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCerrar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(825, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(64, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(65, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(10, 48)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 0
        Me.lblGuardar.Text = "Guardar"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(15, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'EditarArticulo_SuelaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 563)
        Me.Controls.Add(Me.pnlContenedor)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(950, 590)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(950, 590)
        Me.Name = "EditarArticulo_SuelaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Suela Articulo"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.pnlInformacionAlta.PerformLayout()
        Me.gboxEditarArticulo.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdEditarArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents pnlInformacionAlta As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents cmbColorSuela As ComboBox
    Friend WithEvents lblColorSuela As Label
    Friend WithEvents cmbSuela As ComboBox
    Friend WithEvents lblSuela As Label
    Friend WithEvents PicFoto As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblArticulo1 As Label
    Friend WithEvents lblArticulo2 As Label
    Friend WithEvents gboxEditarArticulo As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbColorSuelaDos As ComboBox
    Friend WithEvents lblColorSuelaDos As Label
    Friend WithEvents cmbFamilia As ComboBox
    Friend WithEvents lblFamilia As Label
    Friend WithEvents cmbAcabado As ComboBox
    Friend WithEvents lblAcabado As Label
    Friend WithEvents lblConsumoSuela As Label
    Friend WithEvents lblTextoConsumo As Label
    Friend WithEvents lblTextoArticulo As Label
    Friend WithEvents grdEditarArticulo As Infragistics.Win.UltraWinGrid.UltraGrid
End Class
