<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventarioDetalleForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventarioDetalleForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlInferior = New System.Windows.Forms.Panel()
        Me.lblSalidas = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEntradas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblInventario = New System.Windows.Forms.Label()
        Me.grdDetalles = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.lblProveedor = New System.Windows.Forms.Label()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalDinero = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInferior.SuspendLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbParametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(785, 63)
        Me.pnlEncabezado.TabIndex = 164
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(535, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(176, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Detalle de Inventario"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(717, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.Color.White
        Me.pnlInferior.Controls.Add(Me.lblSalidas)
        Me.pnlInferior.Controls.Add(Me.Label5)
        Me.pnlInferior.Controls.Add(Me.lblEntradas)
        Me.pnlInferior.Controls.Add(Me.Label4)
        Me.pnlInferior.Controls.Add(Me.lblSalir)
        Me.pnlInferior.Controls.Add(Me.btnSalir)
        Me.pnlInferior.Controls.Add(Me.Label1)
        Me.pnlInferior.Controls.Add(Me.lblInventario)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(0, 472)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(785, 56)
        Me.pnlInferior.TabIndex = 165
        '
        'lblSalidas
        '
        Me.lblSalidas.AutoSize = True
        Me.lblSalidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalidas.Location = New System.Drawing.Point(81, 34)
        Me.lblSalidas.Name = "lblSalidas"
        Me.lblSalidas.Size = New System.Drawing.Size(11, 13)
        Me.lblSalidas.TabIndex = 101
        Me.lblSalidas.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(31, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Salidas:"
        '
        'lblEntradas
        '
        Me.lblEntradas.AutoSize = True
        Me.lblEntradas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntradas.Location = New System.Drawing.Point(81, 14)
        Me.lblEntradas.Name = "lblEntradas"
        Me.lblEntradas.Size = New System.Drawing.Size(11, 13)
        Me.lblEntradas.TabIndex = 99
        Me.lblEntradas.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Entradas:"
        '
        'lblSalir
        '
        Me.lblSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(731, 39)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 98
        Me.lblSalir.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(732, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(244, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Inventario Total:"
        '
        'lblInventario
        '
        Me.lblInventario.AutoSize = True
        Me.lblInventario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventario.Location = New System.Drawing.Point(347, 14)
        Me.lblInventario.Name = "lblInventario"
        Me.lblInventario.Size = New System.Drawing.Size(11, 13)
        Me.lblInventario.TabIndex = 74
        Me.lblInventario.Text = "-"
        '
        'grdDetalles
        '
        Me.grdDetalles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetalles.DisplayLayout.Appearance = Appearance1
        Me.grdDetalles.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDetalles.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDetalles.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDetalles.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDetalles.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDetalles.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdDetalles.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetalles.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdDetalles.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdDetalles.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDetalles.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdDetalles.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDetalles.Location = New System.Drawing.Point(0, 163)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.Size = New System.Drawing.Size(777, 309)
        Me.grdDetalles.TabIndex = 166
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Controls.Add(Me.lblMaterial)
        Me.grbParametros.Controls.Add(Me.lblProveedor)
        Me.grbParametros.Controls.Add(Me.lblPrecio)
        Me.grbParametros.Controls.Add(Me.Label2)
        Me.grbParametros.Controls.Add(Me.Label6)
        Me.grbParametros.Controls.Add(Me.btnMostrar)
        Me.grbParametros.Controls.Add(Me.dtpFechaFinal)
        Me.grbParametros.Controls.Add(Me.dtpFechaInicio)
        Me.grbParametros.Controls.Add(Me.lblA)
        Me.grbParametros.Controls.Add(Me.lblDe)
        Me.grbParametros.Controls.Add(Me.Label3)
        Me.grbParametros.Controls.Add(Me.Label7)
        Me.grbParametros.Controls.Add(Me.lblTotalDinero)
        Me.grbParametros.Controls.Add(Me.lblNave)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 63)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(785, 94)
        Me.grbParametros.TabIndex = 167
        Me.grbParametros.TabStop = False
        '
        'lblMaterial
        '
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.Location = New System.Drawing.Point(89, 40)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(10, 13)
        Me.lblMaterial.TabIndex = 73
        Me.lblMaterial.Text = "-"
        '
        'lblProveedor
        '
        Me.lblProveedor.AutoSize = True
        Me.lblProveedor.Location = New System.Drawing.Point(89, 57)
        Me.lblProveedor.Name = "lblProveedor"
        Me.lblProveedor.Size = New System.Drawing.Size(10, 13)
        Me.lblProveedor.TabIndex = 78
        Me.lblProveedor.Text = "-"
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(87, 74)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(11, 13)
        Me.lblPrecio.TabIndex = 76
        Me.lblPrecio.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Precio:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(733, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 168
        Me.Label6.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(737, 14)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 167
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Location = New System.Drawing.Point(408, 14)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(198, 20)
        Me.dtpFechaFinal.TabIndex = 92
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Location = New System.Drawing.Point(90, 14)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(193, 20)
        Me.dtpFechaInicio.TabIndex = 91
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(12, 18)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(71, 13)
        Me.lblA.TabIndex = 90
        Me.lblA.Text = "*Fecha Inicial"
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Location = New System.Drawing.Point(336, 17)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(66, 13)
        Me.lblDe.TabIndex = 89
        Me.lblDe.Text = "*Fecha Final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(252, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Total"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(24, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Proveedor:"
        '
        'lblTotalDinero
        '
        Me.lblTotalDinero.AutoSize = True
        Me.lblTotalDinero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDinero.Location = New System.Drawing.Point(289, 74)
        Me.lblTotalDinero.Name = "lblTotalDinero"
        Me.lblTotalDinero.Size = New System.Drawing.Size(11, 13)
        Me.lblTotalDinero.TabIndex = 75
        Me.lblTotalDinero.Text = "-"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(36, 40)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(47, 13)
        Me.lblNave.TabIndex = 69
        Me.lblNave.Text = "Material:"
        '
        'InventarioDetalleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(785, 528)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.grdDetalles)
        Me.Controls.Add(Me.pnlInferior)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(793, 746)
        Me.MinimumSize = New System.Drawing.Size(793, 446)
        Me.Name = "InventarioDetalleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Inventario"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInferior.ResumeLayout(False)
        Me.pnlInferior.PerformLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlInferior As System.Windows.Forms.Panel
    Friend WithEvents lblSalir As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grdDetalles As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblSalidas As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEntradas As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblTotalDinero As System.Windows.Forms.Label
    Friend WithEvents lblInventario As System.Windows.Forms.Label
    Friend WithEvents lblMaterial As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblDe As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
End Class
