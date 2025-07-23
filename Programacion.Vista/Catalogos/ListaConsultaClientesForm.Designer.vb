<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaConsultaClientesForm
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
        Me.grdClientes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblAgregar = New System.Windows.Forms.Label()
        Me.btnAgregarCLientes = New System.Windows.Forms.Button()
        Me.pnlAgregar = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlBotonera.SuspendLayout()
        Me.pnlAgregar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdClientes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Appearance = Appearance1
        Me.grdClientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Row
        Me.grdClientes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientes.Location = New System.Drawing.Point(0, 60)
        Me.grdClientes.Name = "grdClientes"
        Me.grdClientes.Size = New System.Drawing.Size(666, 261)
        Me.grdClientes.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.pnlBotonera)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 321)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 60)
        Me.Panel2.TabIndex = 2
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Controls.Add(Me.btnCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblCancelar)
        Me.pnlBotonera.Controls.Add(Me.lblGuardar)
        Me.pnlBotonera.Controls.Add(Me.btnGuardar)
        Me.pnlBotonera.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotonera.Location = New System.Drawing.Point(466, 0)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(200, 60)
        Me.pnlBotonera.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(146, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(146, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(78, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(84, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblAgregar
        '
        Me.lblAgregar.AutoSize = True
        Me.lblAgregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgregar.Location = New System.Drawing.Point(28, 39)
        Me.lblAgregar.Name = "lblAgregar"
        Me.lblAgregar.Size = New System.Drawing.Size(44, 13)
        Me.lblAgregar.TabIndex = 1
        Me.lblAgregar.Text = "Agregar"
        Me.lblAgregar.Visible = False
        '
        'btnAgregarCLientes
        '
        Me.btnAgregarCLientes.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.btnAgregarCLientes.Location = New System.Drawing.Point(34, 7)
        Me.btnAgregarCLientes.Name = "btnAgregarCLientes"
        Me.btnAgregarCLientes.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarCLientes.TabIndex = 0
        Me.btnAgregarCLientes.UseVisualStyleBackColor = True
        Me.btnAgregarCLientes.Visible = False
        '
        'pnlAgregar
        '
        Me.pnlAgregar.Controls.Add(Me.btnAgregarCLientes)
        Me.pnlAgregar.Controls.Add(Me.lblAgregar)
        Me.pnlAgregar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAgregar.Location = New System.Drawing.Point(572, 0)
        Me.pnlAgregar.Name = "pnlAgregar"
        Me.pnlAgregar.Size = New System.Drawing.Size(94, 60)
        Me.pnlAgregar.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlAgregar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 60)
        Me.Panel1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(429, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Clientes con ""Descripción Especial Documentos"" habilitada en la FTC (Pestaña Alma" & _
    "cén)"
        '
        'ListaConsultaClientesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(666, 381)
        Me.Controls.Add(Me.grdClientes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListaConsultaClientesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        CType(Me.grdClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlBotonera.PerformLayout()
        Me.pnlAgregar.ResumeLayout(False)
        Me.pnlAgregar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdClientes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblAgregar As System.Windows.Forms.Label
    Friend WithEvents btnAgregarCLientes As System.Windows.Forms.Button
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents pnlAgregar As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
