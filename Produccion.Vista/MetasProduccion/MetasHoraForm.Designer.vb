<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MetasHoraForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MetasHoraForm))
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.lblDiaSemana = New System.Windows.Forms.Label()
        Me.lblDep = New System.Windows.Forms.Label()
        Me.lblDia = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.btnEstatusAnterior = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.lblEstatusAnterior = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.pblAlta = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlEstatusAnterior = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdMetasProd = New DevExpress.XtraGrid.GridControl()
        Me.vwReporte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlParametros.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEditar.SuspendLayout()
        Me.pblAlta.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlEstatusAnterior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdMetasProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(106, 17)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 194
        Me.lblDepartamento.Text = "Departamento:"
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.lblDiaSemana)
        Me.pnlParametros.Controls.Add(Me.lblDep)
        Me.pnlParametros.Controls.Add(Me.lblDia)
        Me.pnlParametros.Controls.Add(Me.lblDepartamento)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 63)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(375, 69)
        Me.pnlParametros.TabIndex = 2017
        '
        'lblDiaSemana
        '
        Me.lblDiaSemana.AutoSize = True
        Me.lblDiaSemana.Location = New System.Drawing.Point(189, 42)
        Me.lblDiaSemana.Name = "lblDiaSemana"
        Me.lblDiaSemana.Size = New System.Drawing.Size(36, 13)
        Me.lblDiaSemana.TabIndex = 197
        Me.lblDiaSemana.Text = "Lunes"
        '
        'lblDep
        '
        Me.lblDep.AutoSize = True
        Me.lblDep.Location = New System.Drawing.Point(189, 17)
        Me.lblDep.Name = "lblDep"
        Me.lblDep.Size = New System.Drawing.Size(32, 13)
        Me.lblDep.TabIndex = 196
        Me.lblDep.Text = "Corte"
        '
        'lblDia
        '
        Me.lblDia.AutoSize = True
        Me.lblDia.Location = New System.Drawing.Point(108, 42)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.Size = New System.Drawing.Size(28, 13)
        Me.lblDia.TabIndex = 195
        Me.lblDia.Text = "Día:"
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(178, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(102, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Metas Hora"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(307, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'btnEstatusAnterior
        '
        Me.btnEstatusAnterior.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.quitar_32
        Me.btnEstatusAnterior.Location = New System.Drawing.Point(15, 0)
        Me.btnEstatusAnterior.Name = "btnEstatusAnterior"
        Me.btnEstatusAnterior.Size = New System.Drawing.Size(32, 32)
        Me.btnEstatusAnterior.TabIndex = 8
        Me.btnEstatusAnterior.UseVisualStyleBackColor = True
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
        'lblEstatusAnterior
        '
        Me.lblEstatusAnterior.AutoSize = True
        Me.lblEstatusAnterior.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEstatusAnterior.Location = New System.Drawing.Point(6, 37)
        Me.lblEstatusAnterior.Name = "lblEstatusAnterior"
        Me.lblEstatusAnterior.Size = New System.Drawing.Size(51, 13)
        Me.lblEstatusAnterior.TabIndex = 205
        Me.lblEstatusAnterior.Text = "inhabilitar"
        Me.lblEstatusAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Produccion.Vista.My.Resources.Resources.editar_322
        Me.btnEditar.Location = New System.Drawing.Point(8, 0)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 2
        Me.btnEditar.UseVisualStyleBackColor = True
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
        'Button2
        '
        Me.Button2.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.altas_32
        Me.Button2.Location = New System.Drawing.Point(5, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(9, 37)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 189
        Me.lblAlta.Text = "Alta"
        '
        'pblAlta
        '
        Me.pblAlta.Controls.Add(Me.Button2)
        Me.pblAlta.Controls.Add(Me.lblAlta)
        Me.pblAlta.Location = New System.Drawing.Point(3, 3)
        Me.pblAlta.Name = "pblAlta"
        Me.pblAlta.Size = New System.Drawing.Size(43, 54)
        Me.pblAlta.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.pblAlta)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlEditar)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlEstatusAnterior)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(176, 60)
        Me.FlowLayoutPanel1.TabIndex = 2019
        '
        'pnlEstatusAnterior
        '
        Me.pnlEstatusAnterior.Controls.Add(Me.btnEstatusAnterior)
        Me.pnlEstatusAnterior.Controls.Add(Me.lblEstatusAnterior)
        Me.pnlEstatusAnterior.Location = New System.Drawing.Point(106, 3)
        Me.pnlEstatusAnterior.Name = "pnlEstatusAnterior"
        Me.pnlEstatusAnterior.Size = New System.Drawing.Size(64, 54)
        Me.pnlEstatusAnterior.TabIndex = 193
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(375, 63)
        Me.pnlEncabezado.TabIndex = 2016
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 351)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(375, 57)
        Me.pnlPie.TabIndex = 2023
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.lblGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(275, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(100, 57)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(15, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 199
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(10, 38)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 200
        Me.lblGuardar.Text = "Guardar"
        Me.lblGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(59, 6)
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
        Me.lblCerrar.Location = New System.Drawing.Point(58, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdMetasProd
        '
        Me.grdMetasProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMetasProd.Location = New System.Drawing.Point(0, 132)
        Me.grdMetasProd.MainView = Me.vwReporte
        Me.grdMetasProd.Name = "grdMetasProd"
        Me.grdMetasProd.Size = New System.Drawing.Size(375, 219)
        Me.grdMetasProd.TabIndex = 2024
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
        'MetasHoraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 408)
        Me.Controls.Add(Me.grdMetasProd)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "MetasHoraForm"
        Me.Text = "Metas Hora"
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pblAlta.ResumeLayout(False)
        Me.pblAlta.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlEstatusAnterior.ResumeLayout(False)
        Me.pnlEstatusAnterior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdMetasProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDepartamento As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents btnEstatusAnterior As Button
    Friend WithEvents lblEditar As Label
    Friend WithEvents lblEstatusAnterior As Label
    Friend WithEvents btnEditar As Button
    Friend WithEvents pnlEditar As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents lblAlta As Label
    Friend WithEvents pblAlta As Panel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents pnlEstatusAnterior As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblDiaSemana As Label
    Friend WithEvents lblDep As Label
    Friend WithEvents lblDia As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdMetasProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
End Class
