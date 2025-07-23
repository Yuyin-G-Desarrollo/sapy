<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministradorOT_ComplementosForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.txt_PagoAdicional = New DevExpress.XtraEditors.TextEdit()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.lbl_OrdenTrabajo = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.lbl_OrdenCompra = New Infragistics.Win.Misc.UltraLabel()
        Me.txt_OrdenTrabajo = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txt_OrdenCompra = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        CType(Me.txt_PagoAdicional.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OrdenTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_OrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(319, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(156, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Complementos OT"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(490, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(-204, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(573, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(116, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(369, 65)
        Me.pnlEncabezado.TabIndex = 24
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.txt_PagoAdicional)
        Me.pnlParametros.Controls.Add(Me.UltraLabel2)
        Me.pnlParametros.Controls.Add(Me.lbl_OrdenTrabajo)
        Me.pnlParametros.Controls.Add(Me.UltraLabel1)
        Me.pnlParametros.Controls.Add(Me.lbl_OrdenCompra)
        Me.pnlParametros.Controls.Add(Me.txt_OrdenTrabajo)
        Me.pnlParametros.Controls.Add(Me.txt_OrdenCompra)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 65)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(369, 156)
        Me.pnlParametros.TabIndex = 25
        '
        'txt_PagoAdicional
        '
        Me.txt_PagoAdicional.Location = New System.Drawing.Point(108, 102)
        Me.txt_PagoAdicional.Name = "txt_PagoAdicional"
        Me.txt_PagoAdicional.Properties.Mask.EditMask = "n2"
        Me.txt_PagoAdicional.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txt_PagoAdicional.Size = New System.Drawing.Size(100, 20)
        Me.txt_PagoAdicional.TabIndex = 3
        '
        'UltraLabel2
        '
        Appearance1.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Appearance1.TextHAlignAsString = "Center"
        Appearance1.TextVAlignAsString = "Middle"
        Me.UltraLabel2.Appearance = Appearance1
        Me.UltraLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(12, 128)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(299, 23)
        Me.UltraLabel2.TabIndex = 2
        Me.UltraLabel2.Text = "Nota: El pago adicional debe llevar el IVA incluido"
        '
        'lbl_OrdenTrabajo
        '
        Appearance2.TextHAlignAsString = "Center"
        Appearance2.TextVAlignAsString = "Middle"
        Me.lbl_OrdenTrabajo.Appearance = Appearance2
        Me.lbl_OrdenTrabajo.Location = New System.Drawing.Point(8, 35)
        Me.lbl_OrdenTrabajo.Name = "lbl_OrdenTrabajo"
        Me.lbl_OrdenTrabajo.Size = New System.Drawing.Size(87, 23)
        Me.lbl_OrdenTrabajo.TabIndex = 2
        Me.lbl_OrdenTrabajo.Text = "Ordenes trabajo"
        '
        'UltraLabel1
        '
        Appearance3.TextHAlignAsString = "Center"
        Appearance3.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance3
        Me.UltraLabel1.Location = New System.Drawing.Point(10, 101)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(87, 23)
        Me.UltraLabel1.TabIndex = 2
        Me.UltraLabel1.Text = "Pago Adicional"
        '
        'lbl_OrdenCompra
        '
        Appearance4.TextHAlignAsString = "Center"
        Appearance4.TextVAlignAsString = "Middle"
        Me.lbl_OrdenCompra.Appearance = Appearance4
        Me.lbl_OrdenCompra.Location = New System.Drawing.Point(8, 66)
        Me.lbl_OrdenCompra.Name = "lbl_OrdenCompra"
        Me.lbl_OrdenCompra.Size = New System.Drawing.Size(94, 23)
        Me.lbl_OrdenCompra.TabIndex = 2
        Me.lbl_OrdenCompra.Text = "Orden Compra"
        '
        'txt_OrdenTrabajo
        '
        Me.txt_OrdenTrabajo.Location = New System.Drawing.Point(108, 37)
        Me.txt_OrdenTrabajo.Name = "txt_OrdenTrabajo"
        Me.txt_OrdenTrabajo.ReadOnly = True
        Me.txt_OrdenTrabajo.Size = New System.Drawing.Size(236, 21)
        Me.txt_OrdenTrabajo.TabIndex = 1
        '
        'txt_OrdenCompra
        '
        Me.txt_OrdenCompra.Location = New System.Drawing.Point(108, 68)
        Me.txt_OrdenCompra.Name = "txt_OrdenCompra"
        Me.txt_OrdenCompra.Size = New System.Drawing.Size(134, 21)
        Me.txt_OrdenCompra.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlPie)
        Me.Panel1.Controls.Add(Me.pnlDatosBotones)
        Me.Panel1.Controls.Add(Me.pnlParametros)
        Me.Panel1.Controls.Add(Me.pnlEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(369, 282)
        Me.Panel1.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 222)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(213, 60)
        Me.pnlPie.TabIndex = 27
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(51, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(162, 60)
        Me.Panel2.TabIndex = 1
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(213, 221)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(156, 61)
        Me.pnlDatosBotones.TabIndex = 26
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(62, 40)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Guardar"
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(115, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar_321
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(66, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'AdministradorOT_ComplementosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(369, 282)
        Me.Controls.Add(Me.Panel1)
        Me.MaximumSize = New System.Drawing.Size(385, 321)
        Me.MinimumSize = New System.Drawing.Size(385, 321)
        Me.Name = "AdministradorOT_ComplementosForm"
        Me.Text = "AdministradorOT_ComplementosForm"
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.txt_PagoAdicional.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OrdenTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_OrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbl_OrdenCompra As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_OrdenCompra As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbl_OrdenTrabajo As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents txt_OrdenTrabajo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txt_PagoAdicional As DevExpress.XtraEditors.TextEdit
End Class
