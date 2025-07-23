<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MetasProduccionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MetasProduccionForm))
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlAlta = New System.Windows.Forms.Panel()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlMetasHora = New System.Windows.Forms.Panel()
        Me.btnEstatusAnterior = New System.Windows.Forms.Button()
        Me.lblEstatusAnterior = New System.Windows.Forms.Label()
        Me.pnlExcepciones = New System.Windows.Forms.Panel()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.lblAsignar = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdMetasProd = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlAlta.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlMetasHora.SuspendLayout()
        Me.pnlExcepciones.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdMetasProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlAlta)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlEditar)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlMetasHora)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlExcepciones)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(251, 60)
        Me.FlowLayoutPanel1.TabIndex = 2019
        '
        'pnlAlta
        '
        Me.pnlAlta.Controls.Add(Me.btnAlta)
        Me.pnlAlta.Controls.Add(Me.lblAlta)
        Me.pnlAlta.Location = New System.Drawing.Point(3, 3)
        Me.pnlAlta.Name = "pnlAlta"
        Me.pnlAlta.Size = New System.Drawing.Size(43, 54)
        Me.pnlAlta.TabIndex = 0
        '
        'btnAlta
        '
        Me.btnAlta.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.btnAlta.Location = New System.Drawing.Point(3, 0)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 1
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(7, 37)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 189
        Me.lblAlta.Text = "Alta"
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Location = New System.Drawing.Point(52, 3)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(48, 54)
        Me.pnlEditar.TabIndex = 190
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Produccion.Vista.My.Resources.Resources.editar_322
        Me.btnEditar.Location = New System.Drawing.Point(6, 0)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(3, 37)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(40, 13)
        Me.lblEditar.TabIndex = 191
        Me.lblEditar.Text = "  Editar"
        '
        'pnlMetasHora
        '
        Me.pnlMetasHora.Controls.Add(Me.btnEstatusAnterior)
        Me.pnlMetasHora.Controls.Add(Me.lblEstatusAnterior)
        Me.pnlMetasHora.Location = New System.Drawing.Point(106, 3)
        Me.pnlMetasHora.Name = "pnlMetasHora"
        Me.pnlMetasHora.Size = New System.Drawing.Size(64, 54)
        Me.pnlMetasHora.TabIndex = 193
        '
        'btnEstatusAnterior
        '
        Me.btnEstatusAnterior.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.horarios_32
        Me.btnEstatusAnterior.Location = New System.Drawing.Point(15, 0)
        Me.btnEstatusAnterior.Name = "btnEstatusAnterior"
        Me.btnEstatusAnterior.Size = New System.Drawing.Size(32, 32)
        Me.btnEstatusAnterior.TabIndex = 8
        Me.btnEstatusAnterior.UseVisualStyleBackColor = True
        '
        'lblEstatusAnterior
        '
        Me.lblEstatusAnterior.AutoSize = True
        Me.lblEstatusAnterior.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEstatusAnterior.Location = New System.Drawing.Point(0, 35)
        Me.lblEstatusAnterior.Name = "lblEstatusAnterior"
        Me.lblEstatusAnterior.Size = New System.Drawing.Size(62, 13)
        Me.lblEstatusAnterior.TabIndex = 205
        Me.lblEstatusAnterior.Text = "Metas Hora"
        Me.lblEstatusAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlExcepciones
        '
        Me.pnlExcepciones.Controls.Add(Me.btnAsignar)
        Me.pnlExcepciones.Controls.Add(Me.lblAsignar)
        Me.pnlExcepciones.Location = New System.Drawing.Point(176, 3)
        Me.pnlExcepciones.Name = "pnlExcepciones"
        Me.pnlExcepciones.Size = New System.Drawing.Size(69, 54)
        Me.pnlExcepciones.TabIndex = 191
        Me.pnlExcepciones.Visible = False
        '
        'btnAsignar
        '
        Me.btnAsignar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.excepiones_32
        Me.btnAsignar.Location = New System.Drawing.Point(19, 0)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignar.TabIndex = 3
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'lblAsignar
        '
        Me.lblAsignar.AutoSize = True
        Me.lblAsignar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAsignar.Location = New System.Drawing.Point(3, 37)
        Me.lblAsignar.Name = "lblAsignar"
        Me.lblAsignar.Size = New System.Drawing.Size(68, 13)
        Me.lblAsignar.TabIndex = 195
        Me.lblAsignar.Text = "Excepciones"
        Me.lblAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(55, 11)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(134, 21)
        Me.cmbNave.TabIndex = 2006
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(16, 14)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 2007
        Me.lblNave.Text = "Nave"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(445, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(251, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(177, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Metas de Producción"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(513, 63)
        Me.pnlEncabezado.TabIndex = 156
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.cmbNave)
        Me.pnlParametros.Controls.Add(Me.lblNave)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 0)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(513, 46)
        Me.pnlParametros.TabIndex = 25
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdMetasProd)
        Me.Panel4.Controls.Add(Me.pnlPie)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 46)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(513, 341)
        Me.Panel4.TabIndex = 27
        '
        'grdMetasProd
        '
        Me.grdMetasProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMetasProd.Location = New System.Drawing.Point(0, 0)
        Me.grdMetasProd.MainView = Me.vwReporte
        Me.grdMetasProd.Name = "grdMetasProd"
        Me.grdMetasProd.Size = New System.Drawing.Size(513, 284)
        Me.grdMetasProd.TabIndex = 2021
        Me.grdMetasProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporte, Me.GridView1})
        '
        'vwReporte
        '
        Me.vwReporte.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporte.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporte.GridControl = Me.grdMetasProd
        Me.vwReporte.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.vwReporte.IndicatorWidth = 25
        Me.vwReporte.Name = "vwReporte"
        Me.vwReporte.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporte.OptionsCustomization.AllowGroup = False
        Me.vwReporte.OptionsMenu.EnableColumnMenu = False
        Me.vwReporte.OptionsView.ColumnAutoWidth = False
        Me.vwReporte.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporte.OptionsView.EnableAppearanceEvenRow = True
        Me.vwReporte.OptionsView.EnableAppearanceOddRow = True
        Me.vwReporte.OptionsView.ShowAutoFilterRow = True
        Me.vwReporte.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporte.OptionsView.ShowDetailButtons = False
        Me.vwReporte.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporte.OptionsView.ShowFooter = True
        Me.vwReporte.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdMetasProd
        Me.GridView1.Name = "GridView1"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 284)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(513, 57)
        Me.pnlPie.TabIndex = 2009
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.Panel1)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(417, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(96, 57)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(8, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 197
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(3, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 198
        Me.lblGuardar.Text = "Guardar"
        Me.lblGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(96, 57)
        Me.Panel1.TabIndex = 196
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Button2.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.Button2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button2.Location = New System.Drawing.Point(56, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(55, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(56, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(55, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.Panel4)
        Me.Panel9.Controls.Add(Me.pnlParametros)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 63)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(513, 387)
        Me.Panel9.TabIndex = 158
        '
        'MetasProduccionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 450)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "MetasProduccionForm"
        Me.Text = "Metas de Produccion"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlAlta.ResumeLayout(False)
        Me.pnlAlta.PerformLayout()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlMetasHora.ResumeLayout(False)
        Me.pnlMetasHora.PerformLayout()
        Me.pnlExcepciones.ResumeLayout(False)
        Me.pnlExcepciones.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdMetasProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pnlAlta As Panel
    Friend WithEvents btnAlta As Button
    Friend WithEvents lblAlta As Label
    Friend WithEvents pnlEditar As Panel
    Friend WithEvents btnEditar As Button
    Friend WithEvents lblEditar As Label
    Friend WithEvents pnlExcepciones As Panel
    Friend WithEvents btnAsignar As Button
    Friend WithEvents lblAsignar As Label
    Friend WithEvents pnlMetasHora As Panel
    Friend WithEvents btnEstatusAnterior As Button
    Friend WithEvents lblEstatusAnterior As Label
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents lblNave As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents grdMetasProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
End Class
