<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarcaFormRapido
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
        Me.grdListaMarcas = New System.Windows.Forms.DataGridView()
        Me.ColSeleccionar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.ckbEsCliente = New System.Windows.Forms.CheckBox()
        Me.txtCodSicy = New System.Windows.Forms.TextBox()
        Me.lblCodSicy = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtNombreMarca = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.grdMarcas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        CType(Me.grdListaMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeader.SuspendLayout()
        CType(Me.grdMarcas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdListaMarcas
        '
        Me.grdListaMarcas.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdListaMarcas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSeleccionar})
        Me.grdListaMarcas.Location = New System.Drawing.Point(0, 310)
        Me.grdListaMarcas.Name = "grdListaMarcas"
        Me.grdListaMarcas.ReadOnly = True
        Me.grdListaMarcas.Size = New System.Drawing.Size(62, 35)
        Me.grdListaMarcas.TabIndex = 0
        '
        'ColSeleccionar
        '
        Me.ColSeleccionar.HeaderText = ""
        Me.ColSeleccionar.Name = "ColSeleccionar"
        Me.ColSeleccionar.ReadOnly = True
        Me.ColSeleccionar.Text = ""
        Me.ColSeleccionar.Width = 30
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.btnDown)
        Me.pnlHeader.Controls.Add(Me.btnUP)
        Me.pnlHeader.Controls.Add(Me.lblGuardar)
        Me.pnlHeader.Controls.Add(Me.ckbEsCliente)
        Me.pnlHeader.Controls.Add(Me.txtCodSicy)
        Me.pnlHeader.Controls.Add(Me.lblCodSicy)
        Me.pnlHeader.Controls.Add(Me.btnFiltrar)
        Me.pnlHeader.Controls.Add(Me.btnNuevo)
        Me.pnlHeader.Controls.Add(Me.btnAgregar)
        Me.pnlHeader.Controls.Add(Me.txtNombreMarca)
        Me.pnlHeader.Controls.Add(Me.lblNombre)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(352, 27)
        Me.pnlHeader.TabIndex = 1
        '
        'btnDown
        '
        Me.btnDown.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(322, 4)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 31
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'btnUP
        '
        Me.btnUP.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUP.Location = New System.Drawing.Point(293, 4)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(20, 20)
        Me.btnUP.TabIndex = 30
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(287, 67)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 28
        Me.lblGuardar.Text = "Guardar"
        '
        'ckbEsCliente
        '
        Me.ckbEsCliente.AutoSize = True
        Me.ckbEsCliente.Location = New System.Drawing.Point(216, 61)
        Me.ckbEsCliente.Name = "ckbEsCliente"
        Me.ckbEsCliente.Size = New System.Drawing.Size(58, 17)
        Me.ckbEsCliente.TabIndex = 23
        Me.ckbEsCliente.Text = "Cliente"
        Me.ckbEsCliente.UseVisualStyleBackColor = True
        '
        'txtCodSicy
        '
        Me.txtCodSicy.Location = New System.Drawing.Point(54, 58)
        Me.txtCodSicy.Name = "txtCodSicy"
        Me.txtCodSicy.Size = New System.Drawing.Size(65, 20)
        Me.txtCodSicy.TabIndex = 22
        '
        'lblCodSicy
        '
        Me.lblCodSicy.AutoSize = True
        Me.lblCodSicy.Location = New System.Drawing.Point(6, 62)
        Me.lblCodSicy.Name = "lblCodSicy"
        Me.lblCodSicy.Size = New System.Drawing.Size(31, 13)
        Me.lblCodSicy.TabIndex = 21
        Me.lblCodSicy.Text = "SICY"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrar.Location = New System.Drawing.Point(338, 70)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(14, 17)
        Me.btnFiltrar.TabIndex = 20
        Me.btnFiltrar.UseVisualStyleBackColor = True
        Me.btnFiltrar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnNuevo.Location = New System.Drawing.Point(338, 70)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(14, 17)
        Me.btnNuevo.TabIndex = 19
        Me.btnNuevo.UseVisualStyleBackColor = True
        Me.btnNuevo.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnAgregar.Location = New System.Drawing.Point(293, 35)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 17
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtNombreMarca
        '
        Me.txtNombreMarca.Location = New System.Drawing.Point(54, 35)
        Me.txtNombreMarca.Name = "txtNombreMarca"
        Me.txtNombreMarca.Size = New System.Drawing.Size(220, 20)
        Me.txtNombreMarca.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(6, 39)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(44, 13)
        Me.lblNombre.TabIndex = 0
        Me.lblNombre.Text = "Nombre"
        '
        'grdMarcas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarcas.DisplayLayout.Appearance = Appearance1
        Me.grdMarcas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdMarcas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdMarcas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdMarcas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdMarcas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdMarcas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdMarcas.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdMarcas.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdMarcas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdMarcas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMarcas.Location = New System.Drawing.Point(0, 27)
        Me.grdMarcas.Name = "grdMarcas"
        Me.grdMarcas.Size = New System.Drawing.Size(352, 318)
        Me.grdMarcas.TabIndex = 2
        '
        'MarcaFormRapido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(352, 345)
        Me.Controls.Add(Me.grdMarcas)
        Me.Controls.Add(Me.grdListaMarcas)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "MarcaFormRapido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Marcas"
        CType(Me.grdListaMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.grdMarcas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdListaMarcas As System.Windows.Forms.DataGridView
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents txtNombreMarca As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents ColSeleccionar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents ckbEsCliente As System.Windows.Forms.CheckBox
    Friend WithEvents txtCodSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSicy As System.Windows.Forms.Label
    Friend WithEvents grdMarcas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
End Class
