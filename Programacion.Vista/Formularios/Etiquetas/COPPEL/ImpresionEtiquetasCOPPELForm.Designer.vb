<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionEtiquetasCOPPELForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.cmbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPedCliente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPares = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPedidoCliente = New System.Windows.Forms.TextBox()
        Me.txtPedidoSICY = New System.Windows.Forms.TextBox()
        Me.txtPedidoSAY = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.ofArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.grdImpresionEtiquetas = New DevExpress.XtraGrid.GridControl()
        Me.gdvImpresionEtiquetas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdImpresionEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gdvImpresionEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1092, 59)
        Me.pnlListaPaises.TabIndex = 31
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(749, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(343, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(118, 18)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(160, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Etiquetas COPPEL"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 463)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1092, 60)
        Me.pnlPie.TabIndex = 68
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.btnImprimir)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(919, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(173, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(118, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(118, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(51, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(54, 5)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 41
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.cmbImpresoras)
        Me.pnlFiltros.Controls.Add(Me.Label6)
        Me.pnlFiltros.Controls.Add(Me.GroupBox2)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 59)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1092, 161)
        Me.pnlFiltros.TabIndex = 69
        '
        'cmbImpresoras
        '
        Me.cmbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresoras.FormattingEnabled = True
        Me.cmbImpresoras.Items.AddRange(New Object() {"200dpi", "300dpi"})
        Me.cmbImpresoras.Location = New System.Drawing.Point(311, 113)
        Me.cmbImpresoras.Name = "cmbImpresoras"
        Me.cmbImpresoras.Size = New System.Drawing.Size(152, 21)
        Me.cmbImpresoras.TabIndex = 54
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(249, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Impresora:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPedCliente)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnExaminar)
        Me.GroupBox2.Controls.Add(Me.txtArchivo)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(245, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(504, 83)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Archivo COPPEL"
        '
        'txtPedCliente
        '
        Me.txtPedCliente.Location = New System.Drawing.Point(103, 21)
        Me.txtPedCliente.Name = "txtPedCliente"
        Me.txtPedCliente.ReadOnly = True
        Me.txtPedCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtPedCliente.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Pedido Cliente:"
        '
        'btnExaminar
        '
        Me.btnExaminar.Location = New System.Drawing.Point(414, 48)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(75, 23)
        Me.btnExaminar.TabIndex = 13
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(103, 51)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(305, 20)
        Me.txtArchivo.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Archivo COPPEL:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPares)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPedidoCliente)
        Me.GroupBox1.Controls.Add(Me.txtPedidoSICY)
        Me.GroupBox1.Controls.Add(Me.txtPedidoSAY)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 138)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pedido Seleccionado"
        '
        'txtPares
        '
        Me.txtPares.Location = New System.Drawing.Point(88, 103)
        Me.txtPares.Name = "txtPares"
        Me.txtPares.ReadOnly = True
        Me.txtPares.Size = New System.Drawing.Size(100, 20)
        Me.txtPares.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Pares:"
        '
        'txtPedidoCliente
        '
        Me.txtPedidoCliente.Location = New System.Drawing.Point(88, 76)
        Me.txtPedidoCliente.Name = "txtPedidoCliente"
        Me.txtPedidoCliente.ReadOnly = True
        Me.txtPedidoCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtPedidoCliente.TabIndex = 7
        '
        'txtPedidoSICY
        '
        Me.txtPedidoSICY.Location = New System.Drawing.Point(88, 51)
        Me.txtPedidoSICY.Name = "txtPedidoSICY"
        Me.txtPedidoSICY.ReadOnly = True
        Me.txtPedidoSICY.Size = New System.Drawing.Size(100, 20)
        Me.txtPedidoSICY.TabIndex = 6
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Location = New System.Drawing.Point(88, 24)
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.ReadOnly = True
        Me.txtPedidoSAY.Size = New System.Drawing.Size(100, 20)
        Me.txtPedidoSAY.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Pedido Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pedido SICY:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 27)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(67, 13)
        Me.lblNave.TabIndex = 1
        Me.lblNave.Text = "Pedido SAY:"
        '
        'grdImpresionEtiquetas
        '
        Me.grdImpresionEtiquetas.AccessibleRole = System.Windows.Forms.AccessibleRole.Separator
        Me.grdImpresionEtiquetas.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdImpresionEtiquetas.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdImpresionEtiquetas.Location = New System.Drawing.Point(0, 220)
        Me.grdImpresionEtiquetas.MainView = Me.gdvImpresionEtiquetas
        Me.grdImpresionEtiquetas.Name = "grdImpresionEtiquetas"
        Me.grdImpresionEtiquetas.Size = New System.Drawing.Size(1092, 243)
        Me.grdImpresionEtiquetas.TabIndex = 70
        Me.grdImpresionEtiquetas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gdvImpresionEtiquetas})
        '
        'gdvImpresionEtiquetas
        '
        Me.gdvImpresionEtiquetas.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.gdvImpresionEtiquetas.Appearance.EvenRow.Options.UseBackColor = True
        Me.gdvImpresionEtiquetas.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.gdvImpresionEtiquetas.Appearance.OddRow.Options.UseBackColor = True
        Me.gdvImpresionEtiquetas.GridControl = Me.grdImpresionEtiquetas
        Me.gdvImpresionEtiquetas.Name = "gdvImpresionEtiquetas"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(279, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'ImpresionEtiquetasCOPPELForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1092, 523)
        Me.Controls.Add(Me.grdImpresionEtiquetas)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1100, 550)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1100, 550)
        Me.Name = "ImpresionEtiquetasCOPPELForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etiquetas COPPEL"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdImpresionEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gdvImpresionEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents txtPedidoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtPedidoSICY As System.Windows.Forms.TextBox
    Friend WithEvents txtPedidoSAY As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents ofArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtPares As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPedCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grdImpresionEtiquetas As DevExpress.XtraGrid.GridControl
    Friend WithEvents gdvImpresionEtiquetas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbImpresoras As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
