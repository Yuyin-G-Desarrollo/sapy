<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VentasClienteDevolucionesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasClienteDevolucionesForm))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.lblagregar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdVentasCliente = New DevExpress.XtraGrid.GridControl()
        Me.wvVentasCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdVentasCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wvVentasCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(971, 63)
        Me.pnlBanner.TabIndex = 64
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(616, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(355, 63)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(287, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(101, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(156, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Ventas del Cliente"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 439)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(971, 57)
        Me.pnlPie.TabIndex = 75
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnAgregar)
        Me.pnlDatosBotones.Controls.Add(Me.lblagregar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(827, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 57)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregar.Image = Global.Cobranza.Vista.My.Resources.Resources.aceptar_321
        Me.btnAgregar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregar.Location = New System.Drawing.Point(39, 6)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'lblagregar
        '
        Me.lblagregar.AutoSize = True
        Me.lblagregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblagregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblagregar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblagregar.Location = New System.Drawing.Point(33, 38)
        Me.lblagregar.Name = "lblagregar"
        Me.lblagregar.Size = New System.Drawing.Size(44, 13)
        Me.lblagregar.TabIndex = 3
        Me.lblagregar.Text = "Agregar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(87, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(81, 38)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cancelar"
        '
        'grdVentasCliente
        '
        Me.grdVentasCliente.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdVentasCliente.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdVentasCliente.Location = New System.Drawing.Point(0, 63)
        Me.grdVentasCliente.MainView = Me.wvVentasCliente
        Me.grdVentasCliente.Name = "grdVentasCliente"
        Me.grdVentasCliente.Size = New System.Drawing.Size(971, 376)
        Me.grdVentasCliente.TabIndex = 76
        Me.grdVentasCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.wvVentasCliente})
        '
        'wvVentasCliente
        '
        Me.wvVentasCliente.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.wvVentasCliente.Appearance.EvenRow.Options.UseBackColor = True
        Me.wvVentasCliente.GridControl = Me.grdVentasCliente
        Me.wvVentasCliente.Name = "wvVentasCliente"
        Me.wvVentasCliente.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvVentasCliente.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvVentasCliente.OptionsCustomization.AllowColumnMoving = False
        Me.wvVentasCliente.OptionsView.ShowAutoFilterRow = True
        Me.wvVentasCliente.OptionsView.ShowFooter = True
        Me.wvVentasCliente.OptionsView.ShowGroupPanel = False
        '
        'VentasClienteDevolucionesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 496)
        Me.Controls.Add(Me.grdVentasCliente)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlBanner)
        Me.KeyPreview = True
        Me.Name = "VentasClienteDevolucionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ventas del Cliente"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdVentasCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wvVentasCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As Windows.Forms.Panel
    Friend WithEvents btnAgregar As Windows.Forms.Button
    Friend WithEvents lblagregar As Windows.Forms.Label
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents grdVentasCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents wvVentasCliente As DevExpress.XtraGrid.Views.Grid.GridView
End Class
