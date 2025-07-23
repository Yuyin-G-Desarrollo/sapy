<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaOrdenCompraForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaOrdenCompraForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtpPrograma = New System.Windows.Forms.DateTimePicker()
        Me.lblPrograma = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cbxNave = New System.Windows.Forms.ComboBox()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblDetalle = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdOrdenCompra = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2.SuspendLayout()
        Me.pnlInferior.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdOrdenCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.dtpPrograma)
        Me.Panel2.Controls.Add(Me.lblPrograma)
        Me.Panel2.Controls.Add(Me.lblNave)
        Me.Panel2.Controls.Add(Me.cbxNave)
        Me.Panel2.Controls.Add(Me.lblMostrar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Controls.Add(Me.lblLimpiar)
        Me.Panel2.Location = New System.Drawing.Point(0, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(965, 65)
        Me.Panel2.TabIndex = 2029
        '
        'dtpPrograma
        '
        Me.dtpPrograma.Location = New System.Drawing.Point(410, 24)
        Me.dtpPrograma.Name = "dtpPrograma"
        Me.dtpPrograma.Size = New System.Drawing.Size(200, 20)
        Me.dtpPrograma.TabIndex = 2028
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.Location = New System.Drawing.Point(315, 26)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(89, 13)
        Me.lblPrograma.TabIndex = 2027
        Me.lblPrograma.Text = "*Fecha Programa"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(9, 27)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 127
        Me.lblNave.Text = "*Nave"
        '
        'cbxNave
        '
        Me.cbxNave.FormattingEnabled = True
        Me.cbxNave.Location = New System.Drawing.Point(48, 23)
        Me.cbxNave.Name = "cbxNave"
        Me.cbxNave.Size = New System.Drawing.Size(224, 21)
        Me.cbxNave.TabIndex = 126
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(865, 44)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 125
        Me.lblMostrar.Text = "Mostrar"
        Me.lblMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(921, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 122
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(870, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 124
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(918, 44)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 123
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 345)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(965, 54)
        Me.pnlInferior.TabIndex = 2028
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(912, 37)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 100
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(913, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblImprimir)
        Me.pnlEncabezado.Controls.Add(Me.btnImprimir)
        Me.pnlEncabezado.Controls.Add(Me.lblDetalle)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnVerDetalle)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(965, 63)
        Me.pnlEncabezado.TabIndex = 2027
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(78, 46)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 2032
        Me.lblImprimir.Text = "Imprimir"
        Me.lblImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Produccion.Vista.My.Resources.Resources.imprimir_321
        Me.btnImprimir.Location = New System.Drawing.Point(82, 9)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 2031
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'lblDetalle
        '
        Me.lblDetalle.AutoSize = True
        Me.lblDetalle.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetalle.Location = New System.Drawing.Point(10, 46)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(59, 13)
        Me.lblDetalle.TabIndex = 2030
        Me.lblDetalle.Text = "Ver Detalle"
        Me.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(649, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(245, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Consulta Ordenes de Compra"
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.Image = Global.Produccion.Vista.My.Resources.Resources.details
        Me.btnVerDetalle.Location = New System.Drawing.Point(24, 9)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(32, 32)
        Me.btnVerDetalle.TabIndex = 2029
        Me.btnVerDetalle.UseVisualStyleBackColor = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(897, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.grdOrdenCompra)
        Me.Panel1.Location = New System.Drawing.Point(0, 140)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(965, 199)
        Me.Panel1.TabIndex = 2030
        '
        'grdOrdenCompra
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenCompra.DisplayLayout.Appearance = Appearance1
        Me.grdOrdenCompra.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenCompra.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdOrdenCompra.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdOrdenCompra.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdOrdenCompra.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdOrdenCompra.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdOrdenCompra.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdOrdenCompra.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdOrdenCompra.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdOrdenCompra.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdOrdenCompra.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdOrdenCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenCompra.Location = New System.Drawing.Point(0, 0)
        Me.grdOrdenCompra.Name = "grdOrdenCompra"
        Me.grdOrdenCompra.Size = New System.Drawing.Size(965, 199)
        Me.grdOrdenCompra.TabIndex = 2022
        '
        'ConsultaOrdenCompraForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(965, 399)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConsultaOrdenCompraForm"
        Me.Text = "Consulta Ordenes de Compra"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdOrdenCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cbxNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdOrdenCompra As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents dtpPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
    Friend WithEvents lblDetalle As System.Windows.Forms.Label
    Friend WithEvents btnVerDetalle As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
