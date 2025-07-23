<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColeccionFormRapido
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
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblCLiente = New System.Windows.Forms.Label()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.lblAnio = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnDown = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblCodSicy = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.txtCodSicy = New System.Windows.Forms.TextBox()
        Me.txtNombreColeccion = New System.Windows.Forms.TextBox()
        Me.grdColecciones = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlHeader.SuspendLayout()
        CType(Me.grdColecciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblNombreCliente)
        Me.pnlHeader.Controls.Add(Me.lblCLiente)
        Me.pnlHeader.Controls.Add(Me.btnClientes)
        Me.pnlHeader.Controls.Add(Me.lblAnio)
        Me.pnlHeader.Controls.Add(Me.lblCodigo)
        Me.pnlHeader.Controls.Add(Me.txtCodigo)
        Me.pnlHeader.Controls.Add(Me.cmbAnio)
        Me.pnlHeader.Controls.Add(Me.btnAgregar)
        Me.pnlHeader.Controls.Add(Me.btnDown)
        Me.pnlHeader.Controls.Add(Me.lblGuardar)
        Me.pnlHeader.Controls.Add(Me.lblCodSicy)
        Me.pnlHeader.Controls.Add(Me.lblNombre)
        Me.pnlHeader.Controls.Add(Me.btnUP)
        Me.pnlHeader.Controls.Add(Me.txtCodSicy)
        Me.pnlHeader.Controls.Add(Me.txtNombreColeccion)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(342, 27)
        Me.pnlHeader.TabIndex = 0
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.Location = New System.Drawing.Point(108, 113)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(7, 12)
        Me.lblNombreCliente.TabIndex = 37
        Me.lblNombreCliente.Text = " "
        '
        'lblCLiente
        '
        Me.lblCLiente.AutoSize = True
        Me.lblCLiente.Location = New System.Drawing.Point(34, 113)
        Me.lblCLiente.Name = "lblCLiente"
        Me.lblCLiente.Size = New System.Drawing.Size(39, 13)
        Me.lblCLiente.TabIndex = 36
        Me.lblCLiente.Text = "Cliente"
        '
        'btnClientes
        '
        Me.btnClientes.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnClientes.Image = Global.Programacion.Vista.My.Resources.Resources.ClienteProg
        Me.btnClientes.Location = New System.Drawing.Point(76, 107)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(25, 25)
        Me.btnClientes.TabIndex = 35
        Me.btnClientes.UseVisualStyleBackColor = False
        '
        'lblAnio
        '
        Me.lblAnio.AutoSize = True
        Me.lblAnio.Location = New System.Drawing.Point(5, 59)
        Me.lblAnio.Name = "lblAnio"
        Me.lblAnio.Size = New System.Drawing.Size(68, 13)
        Me.lblAnio.TabIndex = 34
        Me.lblAnio.Text = "* Temporada"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(166, 86)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 32
        Me.lblCodigo.Text = "Código"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(209, 82)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(71, 20)
        Me.txtCodigo.TabIndex = 33
        '
        'cmbAnio
        '
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Location = New System.Drawing.Point(76, 55)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(204, 21)
        Me.cmbAnio.TabIndex = 30
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnAgregar.Location = New System.Drawing.Point(295, 48)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 20
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnDown
        '
        Me.btnDown.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnDown.Location = New System.Drawing.Point(311, 5)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(20, 20)
        Me.btnDown.TabIndex = 29
        Me.btnDown.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(289, 83)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 27
        Me.lblGuardar.Text = "Guardar"
        '
        'lblCodSicy
        '
        Me.lblCodSicy.AutoSize = True
        Me.lblCodSicy.Location = New System.Drawing.Point(42, 86)
        Me.lblCodSicy.Name = "lblCodSicy"
        Me.lblCodSicy.Size = New System.Drawing.Size(31, 13)
        Me.lblCodSicy.TabIndex = 25
        Me.lblCodSicy.Text = "SICY"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(22, 32)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(51, 13)
        Me.lblNombre.TabIndex = 18
        Me.lblNombre.Text = "* Nombre"
        '
        'btnUP
        '
        Me.btnUP.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnUP.Location = New System.Drawing.Point(279, 5)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(20, 20)
        Me.btnUP.TabIndex = 28
        Me.btnUP.UseVisualStyleBackColor = True
        '
        'txtCodSicy
        '
        Me.txtCodSicy.Location = New System.Drawing.Point(76, 82)
        Me.txtCodSicy.Name = "txtCodSicy"
        Me.txtCodSicy.Size = New System.Drawing.Size(71, 20)
        Me.txtCodSicy.TabIndex = 26
        '
        'txtNombreColeccion
        '
        Me.txtNombreColeccion.Location = New System.Drawing.Point(76, 28)
        Me.txtNombreColeccion.Name = "txtNombreColeccion"
        Me.txtNombreColeccion.Size = New System.Drawing.Size(204, 20)
        Me.txtNombreColeccion.TabIndex = 19
        '
        'grdColecciones
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColecciones.DisplayLayout.Appearance = Appearance1
        Me.grdColecciones.DisplayLayout.GroupByBox.Hidden = True
        Me.grdColecciones.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdColecciones.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdColecciones.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdColecciones.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdColecciones.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdColecciones.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdColecciones.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdColecciones.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdColecciones.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdColecciones.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdColecciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdColecciones.Location = New System.Drawing.Point(0, 27)
        Me.grdColecciones.Name = "grdColecciones"
        Me.grdColecciones.Size = New System.Drawing.Size(342, 298)
        Me.grdColecciones.TabIndex = 2
        '
        'ColeccionFormRapido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(342, 325)
        Me.Controls.Add(Me.grdColecciones)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(358, 364)
        Me.MinimumSize = New System.Drawing.Size(358, 364)
        Me.Name = "ColeccionFormRapido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colecciones"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.grdColecciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNombreColeccion As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents grdColecciones As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnDown As System.Windows.Forms.Button
    Friend WithEvents btnUP As System.Windows.Forms.Button
    Friend WithEvents txtCodSicy As System.Windows.Forms.TextBox
    Friend WithEvents lblCodSicy As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents cmbAnio As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblAnio As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblCLiente As System.Windows.Forms.Label
    Friend WithEvents btnClientes As System.Windows.Forms.Button
End Class
