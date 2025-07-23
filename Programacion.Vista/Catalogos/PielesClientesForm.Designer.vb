<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PielesClientesForm
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
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.GroupBox()
        Me.rdoListaPrecios = New System.Windows.Forms.RadioButton()
        Me.rdoPieles = New System.Windows.Forms.RadioButton()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grdListaPielesClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListaPielesClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.Label2)
        Me.pnlOperaciones.Controls.Add(Me.Button2)
        Me.pnlOperaciones.Controls.Add(Me.Label1)
        Me.pnlOperaciones.Controls.Add(Me.Button1)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(237, 60)
        Me.pnlOperaciones.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(50, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Editar"
        '
        'Button2
        '
        Me.Button2.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.Button2.Location = New System.Drawing.Point(50, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 6
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(15, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Alta"
        '
        'Button1
        '
        Me.Button1.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.Button1.Location = New System.Drawing.Point(12, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 4
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(805, 60)
        Me.pnlHeader.TabIndex = 2
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(512, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(293, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(203, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Relación Pieles-Clientes"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(225, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.White
        Me.pnlParametros.Controls.Add(Me.rdoListaPrecios)
        Me.pnlParametros.Controls.Add(Me.rdoPieles)
        Me.pnlParametros.Controls.Add(Me.cmbClientes)
        Me.pnlParametros.Controls.Add(Me.lblCliente)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 60)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(805, 61)
        Me.pnlParametros.TabIndex = 4
        Me.pnlParametros.TabStop = False
        '
        'rdoListaPrecios
        '
        Me.rdoListaPrecios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoListaPrecios.AutoSize = True
        Me.rdoListaPrecios.Location = New System.Drawing.Point(599, 38)
        Me.rdoListaPrecios.Name = "rdoListaPrecios"
        Me.rdoListaPrecios.Size = New System.Drawing.Size(200, 17)
        Me.rdoListaPrecios.TabIndex = 21
        Me.rdoListaPrecios.Text = "Pieles en artículos de lista de precios"
        Me.rdoListaPrecios.UseVisualStyleBackColor = True
        '
        'rdoPieles
        '
        Me.rdoPieles.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoPieles.AutoSize = True
        Me.rdoPieles.Checked = True
        Me.rdoPieles.Location = New System.Drawing.Point(599, 16)
        Me.rdoPieles.Name = "rdoPieles"
        Me.rdoPieles.Size = New System.Drawing.Size(156, 17)
        Me.rdoPieles.TabIndex = 20
        Me.rdoPieles.TabStop = True
        Me.rdoPieles.Text = "Catálogo de pieles (Activos)"
        Me.rdoPieles.UseVisualStyleBackColor = True
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(57, 23)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(340, 21)
        Me.cmbClientes.TabIndex = 19
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(12, 26)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.Text = "Cliente"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Panel1)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 404)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(805, 60)
        Me.pnlEstado.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(605, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 60)
        Me.Panel1.TabIndex = 1
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(148, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(149, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'grdListaPielesClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaPielesClientes.DisplayLayout.Appearance = Appearance1
        Me.grdListaPielesClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdListaPielesClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaPielesClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaPielesClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaPielesClientes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListaPielesClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaPielesClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaPielesClientes.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaPielesClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaPielesClientes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaPielesClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaPielesClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaPielesClientes.Location = New System.Drawing.Point(0, 121)
        Me.grdListaPielesClientes.Name = "grdListaPielesClientes"
        Me.grdListaPielesClientes.Size = New System.Drawing.Size(805, 283)
        Me.grdListaPielesClientes.TabIndex = 7
        '
        'PielesClientesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 464)
        Me.Controls.Add(Me.grdListaPielesClientes)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(821, 503)
        Me.MinimumSize = New System.Drawing.Size(821, 503)
        Me.Name = "PielesClientesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relación Pieles-Clientes"
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdListaPielesClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlParametros As System.Windows.Forms.GroupBox
    Friend WithEvents rdoListaPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents rdoPieles As System.Windows.Forms.RadioButton
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grdListaPielesClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
