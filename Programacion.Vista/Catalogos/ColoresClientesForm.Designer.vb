<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColoresClientesForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlParametros = New System.Windows.Forms.GroupBox()
        Me.rdoListaPrecios = New System.Windows.Forms.RadioButton()
        Me.rdoColores = New System.Windows.Forms.RadioButton()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.grdListaColoresClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        CType(Me.grdListaColoresClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(760, 60)
        Me.pnlHeader.TabIndex = 1
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
        Me.pnlOperaciones.Size = New System.Drawing.Size(182, 60)
        Me.pnlOperaciones.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(467, 0)
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
        Me.lblTitulo.Size = New System.Drawing.Size(216, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Relación Colores-Clientes"
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
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.Panel1)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 363)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(760, 60)
        Me.pnlEstado.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(560, 0)
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
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.rdoListaPrecios)
        Me.pnlParametros.Controls.Add(Me.rdoColores)
        Me.pnlParametros.Controls.Add(Me.cmbClientes)
        Me.pnlParametros.Controls.Add(Me.lblCliente)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 60)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(760, 61)
        Me.pnlParametros.TabIndex = 3
        Me.pnlParametros.TabStop = False
        '
        'rdoListaPrecios
        '
        Me.rdoListaPrecios.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoListaPrecios.AutoSize = True
        Me.rdoListaPrecios.Location = New System.Drawing.Point(547, 38)
        Me.rdoListaPrecios.Name = "rdoListaPrecios"
        Me.rdoListaPrecios.Size = New System.Drawing.Size(207, 17)
        Me.rdoListaPrecios.TabIndex = 21
        Me.rdoListaPrecios.Text = "Colores en artículos de lista de precios"
        Me.rdoListaPrecios.UseVisualStyleBackColor = True
        '
        'rdoColores
        '
        Me.rdoColores.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdoColores.AutoSize = True
        Me.rdoColores.Checked = True
        Me.rdoColores.Location = New System.Drawing.Point(547, 16)
        Me.rdoColores.Name = "rdoColores"
        Me.rdoColores.Size = New System.Drawing.Size(163, 17)
        Me.rdoColores.TabIndex = 20
        Me.rdoColores.TabStop = True
        Me.rdoColores.Text = "Catálogo de colores (Activos)"
        Me.rdoColores.UseVisualStyleBackColor = True
        '
        'cmbClientes
        '
        Me.cmbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(57, 16)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(340, 21)
        Me.cmbClientes.TabIndex = 19
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(12, 19)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 18
        Me.lblCliente.Text = "Cliente"
        '
        'grdListaColoresClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaColoresClientes.DisplayLayout.Appearance = Appearance1
        Me.grdListaColoresClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaColoresClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaColoresClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaColoresClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaColoresClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdListaColoresClientes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdListaColoresClientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaColoresClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaColoresClientes.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaColoresClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdListaColoresClientes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdListaColoresClientes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdListaColoresClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaColoresClientes.Location = New System.Drawing.Point(0, 121)
        Me.grdListaColoresClientes.Name = "grdListaColoresClientes"
        Me.grdListaColoresClientes.Size = New System.Drawing.Size(760, 242)
        Me.grdListaColoresClientes.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(46, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Editar"
        '
        'Button2
        '
        Me.Button2.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.Button2.Location = New System.Drawing.Point(46, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 10
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(11, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Alta"
        '
        'Button1
        '
        Me.Button1.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.Button1.Location = New System.Drawing.Point(8, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 8
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ColoresClientesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(760, 423)
        Me.Controls.Add(Me.grdListaColoresClientes)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(776, 462)
        Me.MinimumSize = New System.Drawing.Size(776, 462)
        Me.Name = "ColoresClientesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relación Colores-Cliente"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        CType(Me.grdListaColoresClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlParametros As System.Windows.Forms.GroupBox
    Friend WithEvents grdListaColoresClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cmbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents rdoListaPrecios As System.Windows.Forms.RadioButton
    Friend WithEvents rdoColores As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
