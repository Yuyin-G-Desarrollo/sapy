<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArticulosForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblAgente = New System.Windows.Forms.Label()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.lblModelo = New System.Windows.Forms.Label()
        Me.txtPedido = New System.Windows.Forms.TextBox()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.txtAgente = New System.Windows.Forms.TextBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAltaPedidoDetalle = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnAltaPedidoDetalle = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdSeleccionArticulos = New DevExpress.XtraGrid.GridControl()
        Me.grdVseleccionArticulos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlParamCaptura = New System.Windows.Forms.Panel()
        Me.lblParamCaptura = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdSeleccionArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVseleccionArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblCliente)
        Me.Panel1.Controls.Add(Me.lblAgente)
        Me.Panel1.Controls.Add(Me.lblPedido)
        Me.Panel1.Controls.Add(Me.lblModelo)
        Me.Panel1.Controls.Add(Me.txtPedido)
        Me.Panel1.Controls.Add(Me.chboxSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.txtModelo)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.txtAgente)
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1328, 70)
        Me.Panel1.TabIndex = 0
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(294, 18)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 126
        Me.lblCliente.Text = "Cliente"
        Me.lblCliente.Visible = False
        '
        'lblAgente
        '
        Me.lblAgente.AutoSize = True
        Me.lblAgente.Location = New System.Drawing.Point(501, 18)
        Me.lblAgente.Name = "lblAgente"
        Me.lblAgente.Size = New System.Drawing.Size(41, 13)
        Me.lblAgente.TabIndex = 125
        Me.lblAgente.Text = "Agente"
        Me.lblAgente.Visible = False
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Location = New System.Drawing.Point(716, 18)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(40, 13)
        Me.lblPedido.TabIndex = 124
        Me.lblPedido.Text = "Pedido"
        Me.lblPedido.Visible = False
        '
        'lblModelo
        '
        Me.lblModelo.AutoSize = True
        Me.lblModelo.Location = New System.Drawing.Point(27, 16)
        Me.lblModelo.Name = "lblModelo"
        Me.lblModelo.Size = New System.Drawing.Size(42, 13)
        Me.lblModelo.TabIndex = 123
        Me.lblModelo.Text = "Modelo"
        Me.lblModelo.Visible = False
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(790, 13)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.ReadOnly = True
        Me.txtPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtPedido.TabIndex = 122
        Me.txtPedido.Visible = False
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(42, 39)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 121
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(120, 13)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.ReadOnly = True
        Me.txtModelo.Size = New System.Drawing.Size(100, 20)
        Me.txtModelo.TabIndex = 4
        Me.txtModelo.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(339, 13)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtCliente.TabIndex = 3
        Me.txtCliente.Visible = False
        '
        'txtAgente
        '
        Me.txtAgente.Location = New System.Drawing.Point(566, 13)
        Me.txtAgente.Name = "txtAgente"
        Me.txtAgente.ReadOnly = True
        Me.txtAgente.Size = New System.Drawing.Size(100, 20)
        Me.txtAgente.TabIndex = 2
        Me.txtAgente.Visible = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(1014, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(314, 70)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(31, 28)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(187, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Selección de Artículos"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(231, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 70)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlParamCaptura)
        Me.Panel2.Controls.Add(Me.lblParamCaptura)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 400)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1328, 64)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnCerrar)
        Me.Panel3.Controls.Add(Me.lblAltaPedidoDetalle)
        Me.Panel3.Controls.Add(Me.lblCerrar)
        Me.Panel3.Controls.Add(Me.btnAltaPedidoDetalle)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1184, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(144, 64)
        Me.Panel3.TabIndex = 91
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(89, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 90
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAltaPedidoDetalle
        '
        Me.lblAltaPedidoDetalle.AutoSize = True
        Me.lblAltaPedidoDetalle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaPedidoDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAltaPedidoDetalle.Location = New System.Drawing.Point(39, 42)
        Me.lblAltaPedidoDetalle.Name = "lblAltaPedidoDetalle"
        Me.lblAltaPedidoDetalle.Size = New System.Drawing.Size(25, 13)
        Me.lblAltaPedidoDetalle.TabIndex = 88
        Me.lblAltaPedidoDetalle.Text = "Alta"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(94, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(27, 13)
        Me.lblCerrar.TabIndex = 89
        Me.lblCerrar.Text = "Salir"
        '
        'btnAltaPedidoDetalle
        '
        Me.btnAltaPedidoDetalle.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAltaPedidoDetalle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAltaPedidoDetalle.Image = Global.Ventas.Vista.My.Resources.Resources.agregar_22
        Me.btnAltaPedidoDetalle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAltaPedidoDetalle.Location = New System.Drawing.Point(33, 6)
        Me.btnAltaPedidoDetalle.Name = "btnAltaPedidoDetalle"
        Me.btnAltaPedidoDetalle.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaPedidoDetalle.TabIndex = 86
        Me.btnAltaPedidoDetalle.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdSeleccionArticulos)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 70)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1328, 330)
        Me.Panel5.TabIndex = 3
        '
        'grdSeleccionArticulos
        '
        Me.grdSeleccionArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdSeleccionArticulos.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdSeleccionArticulos.Location = New System.Drawing.Point(0, 0)
        Me.grdSeleccionArticulos.MainView = Me.grdVseleccionArticulos
        Me.grdSeleccionArticulos.Name = "grdSeleccionArticulos"
        Me.grdSeleccionArticulos.Size = New System.Drawing.Size(1328, 330)
        Me.grdSeleccionArticulos.TabIndex = 28
        Me.grdSeleccionArticulos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVseleccionArticulos})
        '
        'grdVseleccionArticulos
        '
        Me.grdVseleccionArticulos.GridControl = Me.grdSeleccionArticulos
        Me.grdVseleccionArticulos.Name = "grdVseleccionArticulos"
        Me.grdVseleccionArticulos.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.[Default]
        Me.grdVseleccionArticulos.OptionsView.ShowAutoFilterRow = True
        '
        'pnlParamCaptura
        '
        Me.pnlParamCaptura.BackColor = System.Drawing.Color.Lavender
        Me.pnlParamCaptura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlParamCaptura.ForeColor = System.Drawing.Color.Black
        Me.pnlParamCaptura.Location = New System.Drawing.Point(42, 23)
        Me.pnlParamCaptura.Name = "pnlParamCaptura"
        Me.pnlParamCaptura.Size = New System.Drawing.Size(15, 15)
        Me.pnlParamCaptura.TabIndex = 93
        '
        'lblParamCaptura
        '
        Me.lblParamCaptura.AutoSize = True
        Me.lblParamCaptura.Location = New System.Drawing.Point(68, 25)
        Me.lblParamCaptura.Name = "lblParamCaptura"
        Me.lblParamCaptura.Size = New System.Drawing.Size(153, 13)
        Me.lblParamCaptura.TabIndex = 92
        Me.lblParamCaptura.Text = "Campos editables para captura"
        '
        'ArticulosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1328, 464)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ArticulosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de Artículos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdSeleccionArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVseleccionArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblAltaPedidoDetalle As System.Windows.Forms.Label
    Friend WithEvents btnAltaPedidoDetalle As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents grdSeleccionArticulos As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVseleccionArticulos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtAgente As System.Windows.Forms.TextBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblAgente As System.Windows.Forms.Label
    Friend WithEvents lblPedido As System.Windows.Forms.Label
    Friend WithEvents lblModelo As System.Windows.Forms.Label
    Friend WithEvents pnlParamCaptura As System.Windows.Forms.Panel
    Friend WithEvents lblParamCaptura As System.Windows.Forms.Label
End Class
