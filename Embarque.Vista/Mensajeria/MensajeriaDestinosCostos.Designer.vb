<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MensajeriaDestinosCostos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MensajeriaDestinosCostos))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblExpExcel = New System.Windows.Forms.Label()
        Me.btnExpExcel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTituloVentana = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gridLista = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.SaveAs = New System.Windows.Forms.SaveFileDialog()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblExpExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnExpExcel)
        Me.pnlEncabezado.Controls.Add(Me.Button1)
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Controls.Add(Me.Label4)
        Me.pnlEncabezado.Controls.Add(Me.Label1)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1241, 65)
        Me.pnlEncabezado.TabIndex = 9
        '
        'lblExpExcel
        '
        Me.lblExpExcel.AutoSize = True
        Me.lblExpExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExpExcel.Location = New System.Drawing.Point(137, 37)
        Me.lblExpExcel.Name = "lblExpExcel"
        Me.lblExpExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblExpExcel.TabIndex = 59
        Me.lblExpExcel.Text = "Exportar"
        '
        'btnExpExcel
        '
        Me.btnExpExcel.Image = CType(resources.GetObject("btnExpExcel.Image"), System.Drawing.Image)
        Me.btnExpExcel.Location = New System.Drawing.Point(145, 6)
        Me.btnExpExcel.Name = "btnExpExcel"
        Me.btnExpExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExpExcel.TabIndex = 58
        Me.btnExpExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(71, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 57
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(68, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Masiva"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(56, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Actualización"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(21, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 53
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTituloVentana)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(645, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(596, 65)
        Me.pnlTitulo.TabIndex = 20
        '
        'lblTituloVentana
        '
        Me.lblTituloVentana.AutoSize = True
        Me.lblTituloVentana.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloVentana.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloVentana.Location = New System.Drawing.Point(158, 18)
        Me.lblTituloVentana.Name = "lblTituloVentana"
        Me.lblTituloVentana.Size = New System.Drawing.Size(364, 20)
        Me.lblTituloVentana.TabIndex = 46
        Me.lblTituloVentana.Text = "Información Mensajerías - Destinos - Costos"
        Me.lblTituloVentana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(528, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'btnAltas
        '
        Me.btnAltas.Image = CType(resources.GetObject("btnAltas.Image"), System.Drawing.Image)
        Me.btnAltas.Location = New System.Drawing.Point(17, 4)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(21, 35)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(28, 13)
        Me.lblAltas.TabIndex = 16
        Me.lblAltas.Text = "Alta "
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 465)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1241, 60)
        Me.pnlEstado.TabIndex = 66
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblMostrar)
        Me.pnlOperaciones.Controls.Add(Me.btnMostrar)
        Me.pnlOperaciones.Controls.Add(Me.lblCerrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(1027, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(214, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(80, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 15
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Embarque.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(84, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 14
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(148, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Embarque.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(149, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gridLista)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1241, 400)
        Me.Panel1.TabIndex = 67
        '
        'gridLista
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridLista.DisplayLayout.Appearance = Appearance1
        Me.gridLista.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridLista.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridLista.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridLista.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridLista.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridLista.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridLista.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.gridLista.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridLista.Location = New System.Drawing.Point(0, 0)
        Me.gridLista.Name = "gridLista"
        Me.gridLista.Size = New System.Drawing.Size(1241, 400)
        Me.gridLista.TabIndex = 66
        '
        'MensajeriaDestinosCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 525)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "MensajeriaDestinosCostos"
        Me.Text = "Información Mensajerías -  Destinos - Costos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.gridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTituloVentana As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gridLista As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblExpExcel As System.Windows.Forms.Label
    Friend WithEvents btnExpExcel As System.Windows.Forms.Button
    Friend WithEvents SaveAs As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
End Class
