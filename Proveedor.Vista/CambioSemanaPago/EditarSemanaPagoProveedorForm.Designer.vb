<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarSemanaPagoProveedorForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarSemanaPagoProveedorForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAñoCompraNuevo = New System.Windows.Forms.ComboBox()
        Me.cmbSemanaCompraNueva = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdEditarSemanaPago = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.lblAñoPago = New System.Windows.Forms.Label()
        Me.cmbSemPagoNueva = New System.Windows.Forms.ComboBox()
        Me.lblSemanaPagoNueva = New System.Windows.Forms.Label()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtSemActual = New System.Windows.Forms.TextBox()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.txtDocto = New System.Windows.Forms.TextBox()
        Me.lblIDocto = New System.Windows.Forms.Label()
        Me.lblSemanaPagoActual = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSemanaCompraActual = New System.Windows.Forms.TextBox()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.grdEditarSemanaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 401)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(534, 60)
        Me.Panel1.TabIndex = 69
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(288, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(145, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(139, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 5
        Me.lblGuardar.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 6)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(534, 60)
        Me.pnlHeader.TabIndex = 70
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(238, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(43, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(174, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Editar Semana Pago"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(534, 341)
        Me.Panel2.TabIndex = 71
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbAñoCompraNuevo)
        Me.Panel3.Controls.Add(Me.cmbSemanaCompraNueva)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.grdEditarSemanaPago)
        Me.Panel3.Controls.Add(Me.cmbAño)
        Me.Panel3.Controls.Add(Me.lblAñoPago)
        Me.Panel3.Controls.Add(Me.cmbSemPagoNueva)
        Me.Panel3.Controls.Add(Me.lblSemanaPagoNueva)
        Me.Panel3.Controls.Add(Me.txtImporte)
        Me.Panel3.Controls.Add(Me.txtSemActual)
        Me.Panel3.Controls.Add(Me.lblImporte)
        Me.Panel3.Controls.Add(Me.txtDocto)
        Me.Panel3.Controls.Add(Me.lblIDocto)
        Me.Panel3.Controls.Add(Me.lblSemanaPagoActual)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtSemanaCompraActual)
        Me.Panel3.Location = New System.Drawing.Point(12, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(510, 296)
        Me.Panel3.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 212)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Año Compra Nuevo *"
        '
        'cmbAñoCompraNuevo
        '
        Me.cmbAñoCompraNuevo.FormattingEnabled = True
        Me.cmbAñoCompraNuevo.Location = New System.Drawing.Point(132, 209)
        Me.cmbAñoCompraNuevo.Name = "cmbAñoCompraNuevo"
        Me.cmbAñoCompraNuevo.Size = New System.Drawing.Size(75, 21)
        Me.cmbAñoCompraNuevo.TabIndex = 45
        '
        'cmbSemanaCompraNueva
        '
        Me.cmbSemanaCompraNueva.FormattingEnabled = True
        Me.cmbSemanaCompraNueva.Location = New System.Drawing.Point(349, 209)
        Me.cmbSemanaCompraNueva.Name = "cmbSemanaCompraNueva"
        Me.cmbSemanaCompraNueva.Size = New System.Drawing.Size(142, 21)
        Me.cmbSemanaCompraNueva.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Sem Compra Nueva *"
        '
        'grdEditarSemanaPago
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEditarSemanaPago.DisplayLayout.Appearance = Appearance1
        Me.grdEditarSemanaPago.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdEditarSemanaPago.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdEditarSemanaPago.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdEditarSemanaPago.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdEditarSemanaPago.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdEditarSemanaPago.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdEditarSemanaPago.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdEditarSemanaPago.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdEditarSemanaPago.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdEditarSemanaPago.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdEditarSemanaPago.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdEditarSemanaPago.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdEditarSemanaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdEditarSemanaPago.Location = New System.Drawing.Point(0, 0)
        Me.grdEditarSemanaPago.Name = "grdEditarSemanaPago"
        Me.grdEditarSemanaPago.Size = New System.Drawing.Size(510, 184)
        Me.grdEditarSemanaPago.TabIndex = 40
        '
        'cmbAño
        '
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Location = New System.Drawing.Point(132, 246)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(75, 21)
        Me.cmbAño.TabIndex = 39
        '
        'lblAñoPago
        '
        Me.lblAñoPago.AutoSize = True
        Me.lblAñoPago.Location = New System.Drawing.Point(13, 249)
        Me.lblAñoPago.Name = "lblAñoPago"
        Me.lblAñoPago.Size = New System.Drawing.Size(61, 13)
        Me.lblAñoPago.TabIndex = 38
        Me.lblAñoPago.Text = "Año Pago *"
        '
        'cmbSemPagoNueva
        '
        Me.cmbSemPagoNueva.FormattingEnabled = True
        Me.cmbSemPagoNueva.Location = New System.Drawing.Point(349, 246)
        Me.cmbSemPagoNueva.Name = "cmbSemPagoNueva"
        Me.cmbSemPagoNueva.Size = New System.Drawing.Size(142, 21)
        Me.cmbSemPagoNueva.TabIndex = 37
        '
        'lblSemanaPagoNueva
        '
        Me.lblSemanaPagoNueva.AutoSize = True
        Me.lblSemanaPagoNueva.Location = New System.Drawing.Point(223, 249)
        Me.lblSemanaPagoNueva.Name = "lblSemanaPagoNueva"
        Me.lblSemanaPagoNueva.Size = New System.Drawing.Size(98, 13)
        Me.lblSemanaPagoNueva.TabIndex = 36
        Me.lblSemanaPagoNueva.Text = "Sem Pago Nueva *"
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(132, 137)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(142, 20)
        Me.txtImporte.TabIndex = 35
        '
        'txtSemActual
        '
        Me.txtSemActual.Location = New System.Drawing.Point(132, 58)
        Me.txtSemActual.Name = "txtSemActual"
        Me.txtSemActual.ReadOnly = True
        Me.txtSemActual.Size = New System.Drawing.Size(142, 20)
        Me.txtSemActual.TabIndex = 34
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(13, 141)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(45, 13)
        Me.lblImporte.TabIndex = 33
        Me.lblImporte.Text = "Importe "
        '
        'txtDocto
        '
        Me.txtDocto.Location = New System.Drawing.Point(132, 24)
        Me.txtDocto.Name = "txtDocto"
        Me.txtDocto.ReadOnly = True
        Me.txtDocto.Size = New System.Drawing.Size(142, 20)
        Me.txtDocto.TabIndex = 30
        '
        'lblIDocto
        '
        Me.lblIDocto.AutoSize = True
        Me.lblIDocto.Location = New System.Drawing.Point(13, 28)
        Me.lblIDocto.Name = "lblIDocto"
        Me.lblIDocto.Size = New System.Drawing.Size(36, 13)
        Me.lblIDocto.TabIndex = 32
        Me.lblIDocto.Text = "Docto"
        '
        'lblSemanaPagoActual
        '
        Me.lblSemanaPagoActual.AutoSize = True
        Me.lblSemanaPagoActual.Location = New System.Drawing.Point(13, 62)
        Me.lblSemanaPagoActual.Name = "lblSemanaPagoActual"
        Me.lblSemanaPagoActual.Size = New System.Drawing.Size(89, 13)
        Me.lblSemanaPagoActual.TabIndex = 31
        Me.lblSemanaPagoActual.Text = "Sem Pago Actual"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Sem Compra Actual"
        '
        'txtSemanaCompraActual
        '
        Me.txtSemanaCompraActual.Location = New System.Drawing.Point(132, 101)
        Me.txtSemanaCompraActual.Name = "txtSemanaCompraActual"
        Me.txtSemanaCompraActual.ReadOnly = True
        Me.txtSemanaCompraActual.Size = New System.Drawing.Size(142, 20)
        Me.txtSemanaCompraActual.TabIndex = 42
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(228, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'EditarSemanaPagoProveedorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 461)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "EditarSemanaPagoProveedorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Semana Pago Proveedor"
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.grdEditarSemanaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents bntSalir As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents txtImporte As Windows.Forms.TextBox
    Friend WithEvents txtSemActual As Windows.Forms.TextBox
    Friend WithEvents lblImporte As Windows.Forms.Label
    Friend WithEvents txtDocto As Windows.Forms.TextBox
    Friend WithEvents lblIDocto As Windows.Forms.Label
    Friend WithEvents lblSemanaPagoActual As Windows.Forms.Label
    Friend WithEvents cmbAño As Windows.Forms.ComboBox
    Friend WithEvents lblAñoPago As Windows.Forms.Label
    Friend WithEvents cmbSemPagoNueva As Windows.Forms.ComboBox
    Friend WithEvents lblSemanaPagoNueva As Windows.Forms.Label
    Friend WithEvents grdEditarSemanaPago As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbSemanaCompraNueva As Windows.Forms.ComboBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtSemanaCompraActual As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents cmbAñoCompraNuevo As Windows.Forms.ComboBox
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
