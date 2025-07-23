<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EscaneoMasivoEtiquetasForm
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
        Dim ScrollBarLook1 As Infragistics.Win.UltraWinScrollBar.ScrollBarLook = New Infragistics.Win.UltraWinScrollBar.ScrollBarLook()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblImprimirEtiquetas = New System.Windows.Forms.Label()
        Me.btnImprimirEtiquetas = New System.Windows.Forms.Button()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.cmbImpresion = New System.Windows.Forms.ComboBox()
        Me.chkCaja = New System.Windows.Forms.CheckBox()
        Me.chkSuela = New System.Windows.Forms.CheckBox()
        Me.lblImpresora = New System.Windows.Forms.Label()
        Me.chkColgante = New System.Windows.Forms.CheckBox()
        Me.pnlDisponibles = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEtiqueta = New System.Windows.Forms.TextBox()
        Me.grdEtiquetas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.groupContenedor.SuspendLayout()
        Me.pnlDisponibles.SuspendLayout()
        CType(Me.grdEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 444)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1096, 60)
        Me.Panel2.TabIndex = 34
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(934, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
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
        Me.lblCerrar.Location = New System.Drawing.Point(119, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(27, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Salir"
        '
        'lblImprimirEtiquetas
        '
        Me.lblImprimirEtiquetas.AutoSize = True
        Me.lblImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimirEtiquetas.Location = New System.Drawing.Point(985, 45)
        Me.lblImprimirEtiquetas.Name = "lblImprimirEtiquetas"
        Me.lblImprimirEtiquetas.Size = New System.Drawing.Size(89, 13)
        Me.lblImprimirEtiquetas.TabIndex = 84
        Me.lblImprimirEtiquetas.Text = "Imprimir Etiquetas"
        '
        'btnImprimirEtiquetas
        '
        Me.btnImprimirEtiquetas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirEtiquetas.Image = Global.Programacion.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.btnImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirEtiquetas.Location = New System.Drawing.Point(1013, 10)
        Me.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas"
        Me.btnImprimirEtiquetas.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirEtiquetas.TabIndex = 82
        Me.btnImprimirEtiquetas.UseVisualStyleBackColor = True
        '
        'Panel14
        '
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(404, 83)
        Me.Panel14.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(192, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Mostrar"
        Me.Label1.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(196, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 31)
        Me.btnBuscar.TabIndex = 130
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1096, 83)
        Me.pnlEncabezado.TabIndex = 32
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(404, 83)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(363, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(733, 83)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(124, 30)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(482, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Escaneo de Inventario Confirmado, Entregado y Disponible"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(650, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 83)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.lblImprimirEtiquetas)
        Me.Panel1.Controls.Add(Me.groupContenedor)
        Me.Panel1.Controls.Add(Me.pnlDisponibles)
        Me.Panel1.Controls.Add(Me.btnImprimirEtiquetas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1096, 72)
        Me.Panel1.TabIndex = 35
        '
        'groupContenedor
        '
        Me.groupContenedor.Controls.Add(Me.cmbImpresion)
        Me.groupContenedor.Controls.Add(Me.chkCaja)
        Me.groupContenedor.Controls.Add(Me.chkSuela)
        Me.groupContenedor.Controls.Add(Me.lblImpresora)
        Me.groupContenedor.Controls.Add(Me.chkColgante)
        Me.groupContenedor.Location = New System.Drawing.Point(270, 11)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(592, 53)
        Me.groupContenedor.TabIndex = 129
        Me.groupContenedor.TabStop = False
        '
        'cmbImpresion
        '
        Me.cmbImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresion.FormattingEnabled = True
        Me.cmbImpresion.Items.AddRange(New Object() {"IMPRESIÓN 200", "IMPRESIÓN 300"})
        Me.cmbImpresion.Location = New System.Drawing.Point(141, 18)
        Me.cmbImpresion.Name = "cmbImpresion"
        Me.cmbImpresion.Size = New System.Drawing.Size(153, 21)
        Me.cmbImpresion.TabIndex = 4
        '
        'chkCaja
        '
        Me.chkCaja.AutoSize = True
        Me.chkCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCaja.Location = New System.Drawing.Point(424, 19)
        Me.chkCaja.Name = "chkCaja"
        Me.chkCaja.Size = New System.Drawing.Size(60, 24)
        Me.chkCaja.TabIndex = 2
        Me.chkCaja.Text = "Caja"
        Me.chkCaja.UseVisualStyleBackColor = True
        '
        'chkSuela
        '
        Me.chkSuela.AutoSize = True
        Me.chkSuela.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSuela.Location = New System.Drawing.Point(512, 19)
        Me.chkSuela.Name = "chkSuela"
        Me.chkSuela.Size = New System.Drawing.Size(69, 24)
        Me.chkSuela.TabIndex = 1
        Me.chkSuela.Text = "Suela"
        Me.chkSuela.UseVisualStyleBackColor = True
        '
        'lblImpresora
        '
        Me.lblImpresora.AutoSize = True
        Me.lblImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpresora.Location = New System.Drawing.Point(7, 16)
        Me.lblImpresora.Name = "lblImpresora"
        Me.lblImpresora.Size = New System.Drawing.Size(117, 20)
        Me.lblImpresora.TabIndex = 3
        Me.lblImpresora.Text = "Tipo Impresión:"
        '
        'chkColgante
        '
        Me.chkColgante.AutoSize = True
        Me.chkColgante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkColgante.Location = New System.Drawing.Point(307, 18)
        Me.chkColgante.Name = "chkColgante"
        Me.chkColgante.Size = New System.Drawing.Size(92, 24)
        Me.chkColgante.TabIndex = 0
        Me.chkColgante.Text = "Colgante"
        Me.chkColgante.UseVisualStyleBackColor = True
        '
        'pnlDisponibles
        '
        Me.pnlDisponibles.Controls.Add(Me.Label1)
        Me.pnlDisponibles.Controls.Add(Me.Label6)
        Me.pnlDisponibles.Controls.Add(Me.btnBuscar)
        Me.pnlDisponibles.Controls.Add(Me.txtEtiqueta)
        Me.pnlDisponibles.Location = New System.Drawing.Point(6, 3)
        Me.pnlDisponibles.Name = "pnlDisponibles"
        Me.pnlDisponibles.Size = New System.Drawing.Size(238, 66)
        Me.pnlDisponibles.TabIndex = 125
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Escanear Código"
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(9, 31)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(168, 20)
        Me.txtEtiqueta.TabIndex = 114
        '
        'grdEtiquetas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEtiquetas.DisplayLayout.Appearance = Appearance1
        Me.grdEtiquetas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEtiquetas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdEtiquetas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdEtiquetas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEtiquetas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdEtiquetas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEtiquetas.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdEtiquetas.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdEtiquetas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Appearance4.BackColor = System.Drawing.Color.White
        ScrollBarLook1.Appearance = Appearance4
        Me.grdEtiquetas.DisplayLayout.ScrollBarLook = ScrollBarLook1
        Me.grdEtiquetas.Dock = System.Windows.Forms.DockStyle.Right
        Me.grdEtiquetas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.grdEtiquetas.Location = New System.Drawing.Point(0, 155)
        Me.grdEtiquetas.Name = "grdEtiquetas"
        Me.grdEtiquetas.Size = New System.Drawing.Size(1096, 289)
        Me.grdEtiquetas.TabIndex = 37
        '
        'EscaneoMasivoEtiquetasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 504)
        Me.Controls.Add(Me.grdEtiquetas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(1112, 543)
        Me.MinimumSize = New System.Drawing.Size(1112, 543)
        Me.Name = "EscaneoMasivoEtiquetasForm"
        Me.Text = "Escaneo Masivo Etiquetas"
        Me.Panel2.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.groupContenedor.ResumeLayout(False)
        Me.groupContenedor.PerformLayout()
        Me.pnlDisponibles.ResumeLayout(False)
        Me.pnlDisponibles.PerformLayout()
        CType(Me.grdEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlDisponibles As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEtiqueta As TextBox
    Friend WithEvents lblImprimirEtiquetas As Label
    Friend WithEvents btnImprimirEtiquetas As Button
    Friend WithEvents groupContenedor As GroupBox
    Friend WithEvents cmbImpresion As ComboBox
    Friend WithEvents chkCaja As CheckBox
    Friend WithEvents chkSuela As CheckBox
    Friend WithEvents lblImpresora As Label
    Friend WithEvents chkColgante As CheckBox
    Friend WithEvents grdEtiquetas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label1 As Label
End Class
