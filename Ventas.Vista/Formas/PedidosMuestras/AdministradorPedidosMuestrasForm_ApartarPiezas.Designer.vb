<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorPedidosMuestrasForm_ApartarPiezas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministradorPedidosMuestrasForm_ApartarPiezas))
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.grdInventarioDisponible = New DevExpress.XtraGrid.GridControl()
        Me.grdVInventarioDisponible = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblPiezasPorApartar = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblPedido = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPiezasApartadas = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grdPiezasApartadas = New DevExpress.XtraGrid.GridControl()
        Me.grdVPiezasApartadas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtcapturacodigos = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grdPartidasInventarioDisponible = New DevExpress.XtraGrid.GridControl()
        Me.grdVPartidasInventarioDisponible = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.groupContenedor.SuspendLayout()
        CType(Me.grdInventarioDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVInventarioDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdPiezasApartadas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPiezasApartadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grdPartidasInventarioDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPartidasInventarioDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupContenedor
        '
        Me.groupContenedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.groupContenedor.Controls.Add(Me.grdInventarioDisponible)
        Me.groupContenedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupContenedor.Location = New System.Drawing.Point(9, 214)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(556, 229)
        Me.groupContenedor.TabIndex = 20
        Me.groupContenedor.TabStop = False
        Me.groupContenedor.Text = "Inventario Disponible"
        '
        'grdInventarioDisponible
        '
        Me.grdInventarioDisponible.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdInventarioDisponible.Location = New System.Drawing.Point(3, 16)
        Me.grdInventarioDisponible.MainView = Me.grdVInventarioDisponible
        Me.grdInventarioDisponible.Name = "grdInventarioDisponible"
        Me.grdInventarioDisponible.Size = New System.Drawing.Size(550, 203)
        Me.grdInventarioDisponible.TabIndex = 0
        Me.grdInventarioDisponible.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVInventarioDisponible})
        '
        'grdVInventarioDisponible
        '
        Me.grdVInventarioDisponible.GridControl = Me.grdInventarioDisponible
        Me.grdVInventarioDisponible.Name = "grdVInventarioDisponible"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblPiezasPorApartar)
        Me.pnlEstado.Controls.Add(Me.Label8)
        Me.pnlEstado.Controls.Add(Me.lblCliente)
        Me.pnlEstado.Controls.Add(Me.lblPedido)
        Me.pnlEstado.Controls.Add(Me.Label3)
        Me.pnlEstado.Controls.Add(Me.lblPiezasApartadas)
        Me.pnlEstado.Controls.Add(Me.Label2)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 465)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1203, 60)
        Me.pnlEstado.TabIndex = 19
        '
        'lblPiezasPorApartar
        '
        Me.lblPiezasPorApartar.AutoSize = True
        Me.lblPiezasPorApartar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiezasPorApartar.ForeColor = System.Drawing.Color.Black
        Me.lblPiezasPorApartar.Location = New System.Drawing.Point(408, 36)
        Me.lblPiezasPorApartar.Name = "lblPiezasPorApartar"
        Me.lblPiezasPorApartar.Size = New System.Drawing.Size(15, 16)
        Me.lblPiezasPorApartar.TabIndex = 158
        Me.lblPiezasPorApartar.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(294, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(117, 15)
        Me.Label8.TabIndex = 157
        Me.Label8.Text = "Piezas  Por Apartar: "
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(339, 16)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(12, 16)
        Me.lblCliente.TabIndex = 156
        Me.lblCliente.Text = "-"
        '
        'lblPedido
        '
        Me.lblPedido.AutoSize = True
        Me.lblPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedido.ForeColor = System.Drawing.Color.Black
        Me.lblPedido.Location = New System.Drawing.Point(294, 16)
        Me.lblPedido.Name = "lblPedido"
        Me.lblPedido.Size = New System.Drawing.Size(15, 16)
        Me.lblPedido.TabIndex = 155
        Me.lblPedido.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(232, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Pedido: "
        '
        'lblPiezasApartadas
        '
        Me.lblPiezasApartadas.AutoSize = True
        Me.lblPiezasApartadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPiezasApartadas.ForeColor = System.Drawing.Color.Black
        Me.lblPiezasApartadas.Location = New System.Drawing.Point(75, 35)
        Me.lblPiezasApartadas.Name = "lblPiezasApartadas"
        Me.lblPiezasApartadas.Size = New System.Drawing.Size(16, 16)
        Me.lblPiezasApartadas.TabIndex = 153
        Me.lblPiezasApartadas.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(22, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 16)
        Me.Label2.TabIndex = 152
        Me.Label2.Text = "Piezas Apartadas"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1064, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(139, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(81, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(81, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1203, 60)
        Me.pnlHeader.TabIndex = 18
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(800, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(403, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(72, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(263, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Piezas de Muestras Por Apartar"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Location = New System.Drawing.Point(335, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.grdPiezasApartadas)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(571, 214)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(612, 225)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Piezas Apartadas"
        '
        'grdPiezasApartadas
        '
        Me.grdPiezasApartadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPiezasApartadas.Location = New System.Drawing.Point(3, 87)
        Me.grdPiezasApartadas.MainView = Me.grdVPiezasApartadas
        Me.grdPiezasApartadas.Name = "grdPiezasApartadas"
        Me.grdPiezasApartadas.Size = New System.Drawing.Size(606, 135)
        Me.grdPiezasApartadas.TabIndex = 1
        Me.grdPiezasApartadas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPiezasApartadas})
        '
        'grdVPiezasApartadas
        '
        Me.grdVPiezasApartadas.GridControl = Me.grdPiezasApartadas
        Me.grdVPiezasApartadas.Name = "grdVPiezasApartadas"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox3.Controls.Add(Me.txtcapturacodigos)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(606, 71)
        Me.GroupBox3.TabIndex = 130
        Me.GroupBox3.TabStop = False
        '
        'txtcapturacodigos
        '
        Me.txtcapturacodigos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcapturacodigos.Location = New System.Drawing.Point(166, 19)
        Me.txtcapturacodigos.Name = "txtcapturacodigos"
        Me.txtcapturacodigos.Size = New System.Drawing.Size(145, 20)
        Me.txtcapturacodigos.TabIndex = 128
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(339, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Al momento de hacer la lectura del código se guarda la pieza apartada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(66, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "* Código de Pieza:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.grdPartidasInventarioDisponible)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(9, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(895, 142)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Partidas con inventario disponible"
        '
        'grdPartidasInventarioDisponible
        '
        Me.grdPartidasInventarioDisponible.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidasInventarioDisponible.Location = New System.Drawing.Point(3, 16)
        Me.grdPartidasInventarioDisponible.MainView = Me.grdVPartidasInventarioDisponible
        Me.grdPartidasInventarioDisponible.Name = "grdPartidasInventarioDisponible"
        Me.grdPartidasInventarioDisponible.Size = New System.Drawing.Size(889, 123)
        Me.grdPartidasInventarioDisponible.TabIndex = 0
        Me.grdPartidasInventarioDisponible.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPartidasInventarioDisponible})
        '
        'grdVPartidasInventarioDisponible
        '
        Me.grdVPartidasInventarioDisponible.GridControl = Me.grdPartidasInventarioDisponible
        Me.grdVPartidasInventarioDisponible.Name = "grdVPartidasInventarioDisponible"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(335, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'AdministradorPedidosMuestrasForm_ApartarPiezas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1203, 525)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupContenedor)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1211, 552)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1211, 552)
        Me.Name = "AdministradorPedidosMuestrasForm_ApartarPiezas"
        Me.Text = "Piezas de Muestras Por Apartar"
        Me.groupContenedor.ResumeLayout(False)
        CType(Me.grdInventarioDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVInventarioDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdPiezasApartadas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPiezasApartadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grdPartidasInventarioDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPartidasInventarioDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupContenedor As GroupBox
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents lblPiezasApartadas As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCliente As Label
    Friend WithEvents lblPedido As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtcapturacodigos As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPiezasPorApartar As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents grdInventarioDisponible As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVInventarioDisponible As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdPiezasApartadas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPiezasApartadas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdPartidasInventarioDisponible As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPartidasInventarioDisponible As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
