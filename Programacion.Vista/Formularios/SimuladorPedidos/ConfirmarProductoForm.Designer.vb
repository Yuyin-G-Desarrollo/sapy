<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmarProductoForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNaveDestino = New System.Windows.Forms.Label()
        Me.lblCorrida = New System.Windows.Forms.Label()
        Me.lblHorma = New System.Windows.Forms.Label()
        Me.lblTotalProductos = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCapacidadProducto = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.grdProductosSeleccionados = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.txtOrden = New Infragistics.Win.UltraWinEditors.UltraNumericEditor()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtCapacidadProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProductosSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(732, 60)
        Me.pnlHeader.TabIndex = 12
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label3)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(265, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(467, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(92, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(282, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Capacidades de horma y producto"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(399, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 315)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(732, 60)
        Me.pnlExtado.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(598, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(134, 60)
        Me.Panel1.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(75, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(17, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(23, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(76, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nave destino"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Horma"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(345, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Orden destino"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(200, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Corrida"
        '
        'lblNaveDestino
        '
        Me.lblNaveDestino.AutoSize = True
        Me.lblNaveDestino.Location = New System.Drawing.Point(93, 75)
        Me.lblNaveDestino.Name = "lblNaveDestino"
        Me.lblNaveDestino.Size = New System.Drawing.Size(33, 13)
        Me.lblNaveDestino.TabIndex = 20
        Me.lblNaveDestino.Text = "Nave"
        '
        'lblCorrida
        '
        Me.lblCorrida.AutoSize = True
        Me.lblCorrida.Location = New System.Drawing.Point(245, 96)
        Me.lblCorrida.Name = "lblCorrida"
        Me.lblCorrida.Size = New System.Drawing.Size(40, 13)
        Me.lblCorrida.TabIndex = 21
        Me.lblCorrida.Text = "Corrida"
        '
        'lblHorma
        '
        Me.lblHorma.AutoSize = True
        Me.lblHorma.Location = New System.Drawing.Point(93, 96)
        Me.lblHorma.Name = "lblHorma"
        Me.lblHorma.Size = New System.Drawing.Size(38, 13)
        Me.lblHorma.TabIndex = 23
        Me.lblHorma.Text = "Horma"
        '
        'lblTotalProductos
        '
        Me.lblTotalProductos.AutoSize = True
        Me.lblTotalProductos.Location = New System.Drawing.Point(477, 96)
        Me.lblTotalProductos.Name = "lblTotalProductos"
        Me.lblTotalProductos.Size = New System.Drawing.Size(55, 13)
        Me.lblTotalProductos.TabIndex = 25
        Me.lblTotalProductos.Text = "Productos"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(345, 96)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(126, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Productos seleccionados"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(581, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Capacidad"
        '
        'txtCapacidadProducto
        '
        Me.txtCapacidadProducto.Location = New System.Drawing.Point(645, 92)
        Me.txtCapacidadProducto.MaskInput = "nnn,nnn,nnn"
        Me.txtCapacidadProducto.MinValue = 0
        Me.txtCapacidadProducto.Name = "txtCapacidadProducto"
        Me.txtCapacidadProducto.Size = New System.Drawing.Size(75, 21)
        Me.txtCapacidadProducto.TabIndex = 2
        '
        'grdProductosSeleccionados
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosSeleccionados.DisplayLayout.Appearance = Appearance1
        Me.grdProductosSeleccionados.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProductosSeleccionados.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductosSeleccionados.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdProductosSeleccionados.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProductosSeleccionados.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductosSeleccionados.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProductosSeleccionados.Location = New System.Drawing.Point(12, 119)
        Me.grdProductosSeleccionados.Name = "grdProductosSeleccionados"
        Me.grdProductosSeleccionados.Size = New System.Drawing.Size(708, 190)
        Me.grdProductosSeleccionados.TabIndex = 29
        Me.grdProductosSeleccionados.Text = "Productos por actualizar"
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(480, 66)
        Me.txtOrden.MaskInput = "nnn"
        Me.txtOrden.MaxValue = 80
        Me.txtOrden.MinValue = 1
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(67, 21)
        Me.txtOrden.TabIndex = 1
        '
        'ConfirmarProductoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(732, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.grdProductosSeleccionados)
        Me.Controls.Add(Me.txtCapacidadProducto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblTotalProductos)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblHorma)
        Me.Controls.Add(Me.lblCorrida)
        Me.Controls.Add(Me.lblNaveDestino)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfirmarProductoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Capacidades de horma y producto"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtCapacidadProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProductosSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNaveDestino As System.Windows.Forms.Label
    Friend WithEvents lblCorrida As System.Windows.Forms.Label
    Friend WithEvents lblHorma As System.Windows.Forms.Label
    Friend WithEvents lblTotalProductos As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidadProducto As Infragistics.Win.UltraWinEditors.UltraNumericEditor
    Friend WithEvents grdProductosSeleccionados As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents txtOrden As Infragistics.Win.UltraWinEditors.UltraNumericEditor
End Class
