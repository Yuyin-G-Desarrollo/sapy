<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResumenFacturasComplementoPTISAPForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenFacturasComplementoPTISAPForm))
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListadoFacturasComplementosSAP = New DevExpress.XtraGrid.GridControl()
        Me.gvwListadoComplementosSAP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLeyenda = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaCliente.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListadoFacturasComplementosSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvwListadoComplementosSAP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.pnlContenedor)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(841, 447)
        Me.pnlListaCliente.TabIndex = 27
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.Panel1)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(841, 447)
        Me.pnlContenedor.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdListadoFacturasComplementosSAP)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 388)
        Me.Panel1.TabIndex = 3
        '
        'grdListadoFacturasComplementosSAP
        '
        Me.grdListadoFacturasComplementosSAP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListadoFacturasComplementosSAP.Location = New System.Drawing.Point(0, 77)
        Me.grdListadoFacturasComplementosSAP.MainView = Me.gvwListadoComplementosSAP
        Me.grdListadoFacturasComplementosSAP.Name = "grdListadoFacturasComplementosSAP"
        Me.grdListadoFacturasComplementosSAP.Size = New System.Drawing.Size(841, 240)
        Me.grdListadoFacturasComplementosSAP.TabIndex = 68
        Me.grdListadoFacturasComplementosSAP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvwListadoComplementosSAP})
        '
        'gvwListadoComplementosSAP
        '
        Me.gvwListadoComplementosSAP.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.gvwListadoComplementosSAP.Appearance.EvenRow.Options.UseBackColor = True
        Me.gvwListadoComplementosSAP.GridControl = Me.grdListadoFacturasComplementosSAP
        Me.gvwListadoComplementosSAP.Name = "gvwListadoComplementosSAP"
        Me.gvwListadoComplementosSAP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvwListadoComplementosSAP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.gvwListadoComplementosSAP.OptionsBehavior.Editable = False
        Me.gvwListadoComplementosSAP.OptionsView.ShowFooter = True
        Me.gvwListadoComplementosSAP.OptionsView.ShowGroupPanel = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblLeyenda)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(841, 77)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        '
        'lblLeyenda
        '
        Me.lblLeyenda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLeyenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLeyenda.Location = New System.Drawing.Point(3, 16)
        Me.lblLeyenda.Name = "lblLeyenda"
        Me.lblLeyenda.Size = New System.Drawing.Size(835, 58)
        Me.lblLeyenda.TabIndex = 0
        Me.lblLeyenda.Text = "Se generarán N facturas de complementos de PT para SAP"
        Me.lblLeyenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 317)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(841, 71)
        Me.pnlPie.TabIndex = 64
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(697, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.cancelar_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(86, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(23, 43)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Aceptar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(85, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(29, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(841, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(841, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(331, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(510, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(9, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(427, 20)
        Me.lblTitulo.TabIndex = 47
        Me.lblTitulo.Text = "Resumen Facturas Complementos Compras PT SAP"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(442, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ResumenFacturasComplementoPTISAPForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 447)
        Me.Controls.Add(Me.pnlListaCliente)
        Me.Name = "ResumenFacturasComplementoPTISAPForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resumen Facturas Complementos Compras PT SAP"
        Me.pnlListaCliente.ResumeLayout(False)
        Me.pnlContenedor.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListadoFacturasComplementosSAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvwListadoComplementosSAP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaCliente As Panel
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdListadoFacturasComplementosSAP As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvwListadoComplementosSAP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblLeyenda As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblAceptar As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
