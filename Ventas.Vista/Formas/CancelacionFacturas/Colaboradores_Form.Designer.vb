<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Colaboradores_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Colaboradores_Form))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblAreas = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdColaboradores = New DevExpress.XtraGrid.GridControl()
        Me.vwColaboradores = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwColaboradores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblAreas)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(490, 56)
        Me.pnlEncabezado.TabIndex = 9
        '
        'lblAreas
        '
        Me.lblAreas.AutoSize = True
        Me.lblAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreas.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblAreas.Location = New System.Drawing.Point(277, 18)
        Me.lblAreas.Name = "lblAreas"
        Me.lblAreas.Size = New System.Drawing.Size(126, 20)
        Me.lblAreas.TabIndex = 21
        Me.lblAreas.Text = "Colaboradores"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(422, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 47
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 386)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(490, 64)
        Me.Panel1.TabIndex = 42
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCncelar)
        Me.Panel2.Controls.Add(Me.lblCancelar)
        Me.Panel2.Location = New System.Drawing.Point(368, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(119, 58)
        Me.Panel2.TabIndex = 39
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.Location = New System.Drawing.Point(78, 3)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 36
        Me.btnCncelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(77, 35)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 38
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdColaboradores
        '
        Me.grdColaboradores.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdColaboradores.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdColaboradores.Location = New System.Drawing.Point(0, 56)
        Me.grdColaboradores.MainView = Me.vwColaboradores
        Me.grdColaboradores.Name = "grdColaboradores"
        Me.grdColaboradores.Size = New System.Drawing.Size(490, 330)
        Me.grdColaboradores.TabIndex = 2
        Me.grdColaboradores.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwColaboradores})
        '
        'vwColaboradores
        '
        Me.vwColaboradores.GridControl = Me.grdColaboradores
        Me.vwColaboradores.Name = "vwColaboradores"
        Me.vwColaboradores.OptionsSelection.MultiSelect = True
        Me.vwColaboradores.OptionsView.ShowAutoFilterRow = True
        Me.vwColaboradores.OptionsView.ShowGroupPanel = False
        '
        'Colaboradores_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(490, 450)
        Me.Controls.Add(Me.grdColaboradores)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Colaboradores_Form"
        Me.Text = "Colaboradores"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwColaboradores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblAreas As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCncelar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents grdColaboradores As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwColaboradores As DevExpress.XtraGrid.Views.Grid.GridView
End Class
