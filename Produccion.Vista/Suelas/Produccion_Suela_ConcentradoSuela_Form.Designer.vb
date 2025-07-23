<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Produccion_Suela_ConcentradoSuela_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produccion_Suela_ConcentradoSuela_Form))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblImprimirOrdenCompra = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdConcentradoTarjetas = New DevExpress.XtraGrid.GridControl()
        Me.MVConcentradoSuelas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblFechaA = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblFechaDe = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdConcentradoTarjetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MVConcentradoSuelas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblImprimirOrdenCompra)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(942, 63)
        Me.pnlEncabezado.TabIndex = 2018
        '
        'lblImprimirOrdenCompra
        '
        Me.lblImprimirOrdenCompra.AutoSize = True
        Me.lblImprimirOrdenCompra.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirOrdenCompra.Location = New System.Drawing.Point(16, 40)
        Me.lblImprimirOrdenCompra.Name = "lblImprimirOrdenCompra"
        Me.lblImprimirOrdenCompra.Size = New System.Drawing.Size(46, 13)
        Me.lblImprimirOrdenCompra.TabIndex = 109
        Me.lblImprimirOrdenCompra.Text = "Exportar"
        Me.lblImprimirOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(22, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 108
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(674, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(197, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Concentrado de Suelas"
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
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.Panel2)
        Me.pnlInformacionAlta.Controls.Add(Me.Panel1)
        Me.pnlInformacionAlta.Controls.Add(Me.pnlEncabezado)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(942, 492)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdConcentradoTarjetas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(942, 391)
        Me.Panel2.TabIndex = 2021
        '
        'grdConcentradoTarjetas
        '
        Me.grdConcentradoTarjetas.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdConcentradoTarjetas.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdConcentradoTarjetas.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdConcentradoTarjetas.Location = New System.Drawing.Point(0, 0)
        Me.grdConcentradoTarjetas.MainView = Me.MVConcentradoSuelas
        Me.grdConcentradoTarjetas.Name = "grdConcentradoTarjetas"
        Me.grdConcentradoTarjetas.Size = New System.Drawing.Size(942, 391)
        Me.grdConcentradoTarjetas.TabIndex = 13
        Me.grdConcentradoTarjetas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MVConcentradoSuelas})
        '
        'MVConcentradoSuelas
        '
        Me.MVConcentradoSuelas.GridControl = Me.grdConcentradoTarjetas
        Me.MVConcentradoSuelas.Name = "MVConcentradoSuelas"
        Me.MVConcentradoSuelas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MVConcentradoSuelas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.MVConcentradoSuelas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.MVConcentradoSuelas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.MVConcentradoSuelas.OptionsPrint.AllowMultilineHeaders = True
        Me.MVConcentradoSuelas.OptionsSelection.MultiSelect = True
        Me.MVConcentradoSuelas.OptionsView.ColumnAutoWidth = False
        Me.MVConcentradoSuelas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.MVConcentradoSuelas.OptionsView.ShowFooter = True
        Me.MVConcentradoSuelas.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFechaA)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lblFechaDe)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(942, 38)
        Me.Panel1.TabIndex = 2020
        '
        'lblFechaA
        '
        Me.lblFechaA.AutoSize = True
        Me.lblFechaA.Location = New System.Drawing.Point(174, 13)
        Me.lblFechaA.Name = "lblFechaA"
        Me.lblFechaA.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaA.TabIndex = 0
        Me.lblFechaA.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "a:"
        '
        'lblFechaDe
        '
        Me.lblFechaDe.AutoSize = True
        Me.lblFechaDe.Location = New System.Drawing.Point(86, 13)
        Me.lblFechaDe.Name = "lblFechaDe"
        Me.lblFechaDe.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaDe.TabIndex = 0
        Me.lblFechaDe.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Programa de:"
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
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlContenido)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(942, 563)
        Me.pnlContenedor.TabIndex = 3
        '
        'Produccion_Suela_ConcentradoSuela_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 563)
        Me.Controls.Add(Me.pnlContenedor)
        Me.MinimumSize = New System.Drawing.Size(950, 590)
        Me.Name = "Produccion_Suela_ConcentradoSuela_Form"
        Me.Text = "Concentrado de Suelas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdConcentradoTarjetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MVConcentradoSuelas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblImprimirOrdenCompra As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlInformacionAlta As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdConcentradoTarjetas As DevExpress.XtraGrid.GridControl
    Friend WithEvents MVConcentradoSuelas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents lblFechaA As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFechaDe As Label
    Friend WithEvents Label1 As Label
End Class
