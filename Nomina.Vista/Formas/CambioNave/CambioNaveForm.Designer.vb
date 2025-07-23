<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cambioNaveForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cambioNaveForm))
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.lblAyuda = New System.Windows.Forms.Label()
        Me.pnlBajaCambioNave = New System.Windows.Forms.Panel()
        Me.btnBajaCambioNave = New System.Windows.Forms.Button()
        Me.lblBajaCambioNave = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlFiltros2 = New System.Windows.Forms.Panel()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCurp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDepto = New System.Windows.Forms.ComboBox()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPuesto = New System.Windows.Forms.ComboBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdColaboradores = New DevExpress.XtraGrid.GridControl()
        Me.vwColaboradores = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        Me.pnlBajaCambioNave.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlFiltros2.SuspendLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAyuda)
        Me.pnlEncabezado.Controls.Add(Me.pnlBajaCambioNave)
        Me.pnlEncabezado.Controls.Add(Me.Panel1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(984, 86)
        Me.pnlEncabezado.TabIndex = 16
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.btnAyuda)
        Me.pnlAyuda.Controls.Add(Me.lblAyuda)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAyuda.Location = New System.Drawing.Point(85, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(68, 86)
        Me.pnlAyuda.TabIndex = 127
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = CType(resources.GetObject("btnAyuda.Image"), System.Drawing.Image)
        Me.btnAyuda.Location = New System.Drawing.Point(16, 5)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(32, 32)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'lblAyuda
        '
        Me.lblAyuda.AutoSize = True
        Me.lblAyuda.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAyuda.Location = New System.Drawing.Point(14, 40)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(37, 13)
        Me.lblAyuda.TabIndex = 8
        Me.lblAyuda.Text = "Ayuda"
        '
        'pnlBajaCambioNave
        '
        Me.pnlBajaCambioNave.Controls.Add(Me.btnBajaCambioNave)
        Me.pnlBajaCambioNave.Controls.Add(Me.lblBajaCambioNave)
        Me.pnlBajaCambioNave.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBajaCambioNave.Location = New System.Drawing.Point(0, 0)
        Me.pnlBajaCambioNave.Name = "pnlBajaCambioNave"
        Me.pnlBajaCambioNave.Size = New System.Drawing.Size(85, 86)
        Me.pnlBajaCambioNave.TabIndex = 48
        '
        'btnBajaCambioNave
        '
        Me.btnBajaCambioNave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBajaCambioNave.Image = Global.Nomina.Vista.My.Resources.Resources.aceptar_32
        Me.btnBajaCambioNave.Location = New System.Drawing.Point(25, 5)
        Me.btnBajaCambioNave.Name = "btnBajaCambioNave"
        Me.btnBajaCambioNave.Size = New System.Drawing.Size(32, 32)
        Me.btnBajaCambioNave.TabIndex = 22
        Me.btnBajaCambioNave.UseVisualStyleBackColor = True
        '
        'lblBajaCambioNave
        '
        Me.lblBajaCambioNave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblBajaCambioNave.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBajaCambioNave.Location = New System.Drawing.Point(6, 40)
        Me.lblBajaCambioNave.Name = "lblBajaCambioNave"
        Me.lblBajaCambioNave.Size = New System.Drawing.Size(69, 26)
        Me.lblBajaCambioNave.TabIndex = 23
        Me.lblBajaCambioNave.Text = "Cambiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Nave"
        Me.lblBajaCambioNave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(743, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(241, 86)
        Me.Panel1.TabIndex = 20
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(173, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 86)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 47
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(18, 33)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(139, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Cambio de Nave"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEstado
        '
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEstado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(0, 68)
        Me.pnlEstado.TabIndex = 22
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(916, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(68, 68)
        Me.pnlOperaciones.TabIndex = 24
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(17, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 28
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(16, 48)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 29
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlOperaciones)
        Me.pnlPie.Controls.Add(Me.pnlEstado)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 513)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(984, 68)
        Me.pnlPie.TabIndex = 20
        '
        'pnlFiltros2
        '
        Me.pnlFiltros2.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros2.Controls.Add(Me.btnBuscar)
        Me.pnlFiltros2.Controls.Add(Me.btnLimpiar)
        Me.pnlFiltros2.Controls.Add(Me.lblBuscar)
        Me.pnlFiltros2.Controls.Add(Me.cmbPuesto)
        Me.pnlFiltros2.Controls.Add(Me.lblLimpiar)
        Me.pnlFiltros2.Controls.Add(Me.Label6)
        Me.pnlFiltros2.Controls.Add(Me.cmbDepto)
        Me.pnlFiltros2.Controls.Add(Me.Label5)
        Me.pnlFiltros2.Controls.Add(Me.cmbNave)
        Me.pnlFiltros2.Controls.Add(Me.lblNave)
        Me.pnlFiltros2.Controls.Add(Me.txtNombre)
        Me.pnlFiltros2.Controls.Add(Me.Label1)
        Me.pnlFiltros2.Controls.Add(Me.Label2)
        Me.pnlFiltros2.Controls.Add(Me.txtCurp)
        Me.pnlFiltros2.Controls.Add(Me.Label3)
        Me.pnlFiltros2.Controls.Add(Me.txtRFC)
        Me.pnlFiltros2.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros2.Location = New System.Drawing.Point(0, 115)
        Me.pnlFiltros2.Name = "pnlFiltros2"
        Me.pnlFiltros2.Size = New System.Drawing.Size(984, 105)
        Me.pnlFiltros2.TabIndex = 52
        '
        'txtRFC
        '
        Me.txtRFC.ForeColor = System.Drawing.Color.Black
        Me.txtRFC.Location = New System.Drawing.Point(73, 70)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(293, 20)
        Me.txtRFC.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(23, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "RFC"
        '
        'txtCurp
        '
        Me.txtCurp.ForeColor = System.Drawing.Color.Black
        Me.txtCurp.Location = New System.Drawing.Point(73, 43)
        Me.txtCurp.Name = "txtCurp"
        Me.txtCurp.Size = New System.Drawing.Size(293, 20)
        Me.txtCurp.TabIndex = 38
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(23, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "CURP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(23, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(73, 16)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(293, 20)
        Me.txtNombre.TabIndex = 36
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(893, 15)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(931, 15)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(890, 51)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 54
        Me.lblBuscar.Text = "Mostrar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(932, 51)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 53
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(423, 18)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 55
        Me.lblNave.Text = "Nave"
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(513, 15)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(195, 21)
        Me.cmbNave.TabIndex = 56
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(423, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Departamento"
        '
        'cmbDepto
        '
        Me.cmbDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepto.ForeColor = System.Drawing.Color.Black
        Me.cmbDepto.FormattingEnabled = True
        Me.cmbDepto.Location = New System.Drawing.Point(513, 42)
        Me.cmbDepto.Name = "cmbDepto"
        Me.cmbDepto.Size = New System.Drawing.Size(195, 21)
        Me.cmbDepto.TabIndex = 58
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(919, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 33
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(423, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 59
        Me.Label6.Text = "Puesto"
        '
        'cmbPuesto
        '
        Me.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPuesto.ForeColor = System.Drawing.Color.Black
        Me.cmbPuesto.FormattingEnabled = True
        Me.cmbPuesto.Location = New System.Drawing.Point(513, 69)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(195, 21)
        Me.cmbPuesto.TabIndex = 60
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(943, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 34
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grdColaboradores
        '
        Me.grdColaboradores.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdColaboradores.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdColaboradores.Location = New System.Drawing.Point(0, 220)
        Me.grdColaboradores.MainView = Me.vwColaboradores
        Me.grdColaboradores.Name = "grdColaboradores"
        Me.grdColaboradores.Size = New System.Drawing.Size(984, 293)
        Me.grdColaboradores.TabIndex = 53
        Me.grdColaboradores.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwColaboradores})
        '
        'vwColaboradores
        '
        Me.vwColaboradores.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.vwColaboradores.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.vwColaboradores.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwColaboradores.Appearance.OddRow.BackColor = System.Drawing.Color.LightSteelBlue
        Me.vwColaboradores.Appearance.OddRow.BackColor2 = System.Drawing.Color.LightSteelBlue
        Me.vwColaboradores.Appearance.OddRow.Options.UseBackColor = True
        Me.vwColaboradores.GridControl = Me.grdColaboradores
        Me.vwColaboradores.Name = "vwColaboradores"
        Me.vwColaboradores.OptionsBehavior.Editable = False
        Me.vwColaboradores.OptionsView.ShowAutoFilterRow = True
        Me.vwColaboradores.OptionsView.ShowGroupPanel = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(984, 29)
        Me.Panel2.TabIndex = 61
        '
        'cambioNaveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 581)
        Me.Controls.Add(Me.grdColaboradores)
        Me.Controls.Add(Me.pnlFiltros2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "cambioNaveForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio Nave"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAyuda.ResumeLayout(False)
        Me.pnlAyuda.PerformLayout()
        Me.pnlBajaCambioNave.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlFiltros2.ResumeLayout(False)
        Me.pnlFiltros2.PerformLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAyuda As Panel
    Friend WithEvents btnAyuda As Button
    Friend WithEvents lblAyuda As Label
    Friend WithEvents pnlBajaCambioNave As Panel
    Friend WithEvents btnBajaCambioNave As Button
    Friend WithEvents lblBajaCambioNave As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlFiltros2 As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents cmbPuesto As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnArriba As Button
    Friend WithEvents cmbDepto As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblNave As Label
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents lblBuscar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCurp As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRFC As TextBox
    Friend WithEvents grdColaboradores As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwColaboradores As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As Panel
End Class
