<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClientesFaltantesSAPForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesFaltantesSAPForm))
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblTotalClientes = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdReporteClientesFaltantesSAP = New DevExpress.XtraGrid.GridControl()
        Me.vwReporteClientesFaltantesSAP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlPie.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdReporteClientesFaltantesSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwReporteClientesFaltantesSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.lblTotalClientes)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 391)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1032, 71)
        Me.pnlPie.TabIndex = 65
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.lblCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(857, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 71)
        Me.Panel1.TabIndex = 187
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(112, 11)
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
        Me.lblCerrar.Location = New System.Drawing.Point(112, 45)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblTotalClientes
        '
        Me.lblTotalClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalClientes.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalClientes.Location = New System.Drawing.Point(14, 39)
        Me.lblTotalClientes.Name = "lblTotalClientes"
        Me.lblTotalClientes.Size = New System.Drawing.Size(86, 24)
        Me.lblTotalClientes.TabIndex = 186
        Me.lblTotalClientes.Text = "0"
        Me.lblTotalClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(12, 8)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(86, 32)
        Me.lblClientes.TabIndex = 185
        Me.lblClientes.Text = "Total Clientes"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlEncabezado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1032, 64)
        Me.Panel2.TabIndex = 68
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel3)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1032, 65)
        Me.pnlEncabezado.TabIndex = 68
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(504, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(528, 65)
        Me.Panel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(215, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(220, 20)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Clientes Faltantes en SAP"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdReporteClientesFaltantesSAP
        '
        Me.grdReporteClientesFaltantesSAP.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdReporteClientesFaltantesSAP.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdReporteClientesFaltantesSAP.Location = New System.Drawing.Point(0, 64)
        Me.grdReporteClientesFaltantesSAP.MainView = Me.vwReporteClientesFaltantesSAP
        Me.grdReporteClientesFaltantesSAP.Name = "grdReporteClientesFaltantesSAP"
        Me.grdReporteClientesFaltantesSAP.Size = New System.Drawing.Size(1032, 327)
        Me.grdReporteClientesFaltantesSAP.TabIndex = 69
        Me.grdReporteClientesFaltantesSAP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwReporteClientesFaltantesSAP, Me.GridView1})
        '
        'vwReporteClientesFaltantesSAP
        '
        Me.vwReporteClientesFaltantesSAP.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.vwReporteClientesFaltantesSAP.Appearance.EvenRow.Options.UseBackColor = True
        Me.vwReporteClientesFaltantesSAP.GridControl = Me.grdReporteClientesFaltantesSAP
        Me.vwReporteClientesFaltantesSAP.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.vwReporteClientesFaltantesSAP.IndicatorWidth = 25
        Me.vwReporteClientesFaltantesSAP.Name = "vwReporteClientesFaltantesSAP"
        Me.vwReporteClientesFaltantesSAP.OptionsBehavior.Editable = False
        Me.vwReporteClientesFaltantesSAP.OptionsCustomization.AllowColumnMoving = False
        Me.vwReporteClientesFaltantesSAP.OptionsCustomization.AllowGroup = False
        Me.vwReporteClientesFaltantesSAP.OptionsCustomization.AllowSort = False
        Me.vwReporteClientesFaltantesSAP.OptionsMenu.EnableColumnMenu = False
        Me.vwReporteClientesFaltantesSAP.OptionsView.ColumnAutoWidth = False
        Me.vwReporteClientesFaltantesSAP.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.vwReporteClientesFaltantesSAP.OptionsView.EnableAppearanceEvenRow = True
        Me.vwReporteClientesFaltantesSAP.OptionsView.EnableAppearanceOddRow = True
        Me.vwReporteClientesFaltantesSAP.OptionsView.ShowAutoFilterRow = True
        Me.vwReporteClientesFaltantesSAP.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwReporteClientesFaltantesSAP.OptionsView.ShowDetailButtons = False
        Me.vwReporteClientesFaltantesSAP.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwReporteClientesFaltantesSAP.OptionsView.ShowGroupPanel = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.grdReporteClientesFaltantesSAP
        Me.GridView1.Name = "GridView1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(460, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(68, 65)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 91
        Me.PictureBox2.TabStop = False
        '
        'ClientesFaltantesSAPForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 462)
        Me.Controls.Add(Me.grdReporteClientesFaltantesSAP)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlPie)
        Me.MaximumSize = New System.Drawing.Size(1040, 489)
        Me.MinimumSize = New System.Drawing.Size(1040, 489)
        Me.Name = "ClientesFaltantesSAPForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes Faltantes en SAP"
        Me.pnlPie.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.grdReporteClientesFaltantesSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwReporteClientesFaltantesSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblTotalClientes As Label
    Friend WithEvents lblClientes As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdReporteClientesFaltantesSAP As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwReporteClientesFaltantesSAP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
