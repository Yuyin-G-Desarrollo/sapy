<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListadoSucursales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListadoSucursales))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPruebaXML = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbActivoNo = New System.Windows.Forms.RadioButton()
        Me.rdbActivoSi = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdSucursales = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdSucursales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.btnEditar)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Controls.Add(Me.btnNuevo)
        Me.pnlBanner.Controls.Add(Me.lblNuevo)
        Me.pnlBanner.Controls.Add(Me.lblEditar)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(487, 68)
        Me.pnlBanner.TabIndex = 58
        '
        'btnEditar
        '
        Me.btnEditar.Image = Global.Facturacion.Vista.My.Resources.Resources.editar_32
        Me.btnEditar.Location = New System.Drawing.Point(70, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 60
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(146, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(341, 68)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(273, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 68)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(169, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(98, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Sucursales"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Facturacion.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(18, 9)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(32, 32)
        Me.btnNuevo.TabIndex = 58
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(20, 41)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(30, 13)
        Me.lblNuevo.TabIndex = 59
        Me.lblNuevo.Text = "Altas"
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(69, 41)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 61
        Me.lblEditar.Text = "Editar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.btnPruebaXML)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 402)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 62)
        Me.Panel1.TabIndex = 59
        '
        'btnPruebaXML
        '
        Me.btnPruebaXML.Image = Global.Facturacion.Vista.My.Resources.Resources.reporteDeducciones_
        Me.btnPruebaXML.Location = New System.Drawing.Point(23, 6)
        Me.btnPruebaXML.Name = "btnPruebaXML"
        Me.btnPruebaXML.Size = New System.Drawing.Size(32, 32)
        Me.btnPruebaXML.TabIndex = 62
        Me.btnPruebaXML.UseVisualStyleBackColor = True
        Me.btnPruebaXML.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(11, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "PruebaXML"
        Me.Label1.Visible = False
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(442, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 45
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.Image = Global.Facturacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(443, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 44
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbActivoNo)
        Me.GroupBox1.Controls.Add(Me.rdbActivoSi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 46)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        '
        'rdbActivoNo
        '
        Me.rdbActivoNo.AutoSize = True
        Me.rdbActivoNo.Location = New System.Drawing.Point(134, 18)
        Me.rdbActivoNo.Name = "rdbActivoNo"
        Me.rdbActivoNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbActivoNo.TabIndex = 2
        Me.rdbActivoNo.Text = "No"
        Me.rdbActivoNo.UseVisualStyleBackColor = True
        '
        'rdbActivoSi
        '
        Me.rdbActivoSi.AutoSize = True
        Me.rdbActivoSi.Checked = True
        Me.rdbActivoSi.Location = New System.Drawing.Point(72, 18)
        Me.rdbActivoSi.Name = "rdbActivoSi"
        Me.rdbActivoSi.Size = New System.Drawing.Size(34, 17)
        Me.rdbActivoSi.TabIndex = 1
        Me.rdbActivoSi.TabStop = True
        Me.rdbActivoSi.Text = "Si"
        Me.rdbActivoSi.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Activo"
        '
        'grdSucursales
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 7.0!
        Appearance1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.grdSucursales.DisplayLayout.Appearance = Appearance1
        Me.grdSucursales.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.grdSucursales.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdSucursales.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdSucursales.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortSingle
        Me.grdSucursales.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdSucursales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSucursales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSucursales.Location = New System.Drawing.Point(0, 114)
        Me.grdSucursales.Name = "grdSucursales"
        Me.grdSucursales.Size = New System.Drawing.Size(487, 288)
        Me.grdSucursales.TabIndex = 61
        '
        'ListadoSucursales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(487, 464)
        Me.Controls.Add(Me.grdSucursales)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlBanner)
        Me.Name = "ListadoSucursales"
        Me.Text = "Sucursales"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdSucursales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlBanner As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents rdbActivoNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbActivoSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdSucursales As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnPruebaXML As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
