<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AltaIncentivoForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.tabAltaIncentivos = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnBuscarEmpleado = New System.Windows.Forms.Button()
        Me.lblJustificacion = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.cmbMotivos = New System.Windows.Forms.ComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtBuscarNombreIncentivo = New System.Windows.Forms.TextBox()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.BuscarEmpleado = New System.Windows.Forms.TabPage()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.grdBuscarEmpleado = New System.Windows.Forms.DataGridView()
        Me.txtBuscarEmpleado = New System.Windows.Forms.TextBox()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlListaPaises.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAltaIncentivos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.BuscarEmpleado.SuspendLayout()
        CType(Me.grdBuscarEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblEncabezado)
        Me.pnlListaPaises.Controls.Add(Me.pbYuyin)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(668, 104)
        Me.pnlListaPaises.TabIndex = 11
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(530, 41)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(137, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Nuevo Incentivo"
        '
        'pbYuyin
        '
        Me.pbYuyin.Image = Global.Nomina.Vista.My.Resources.Resources.yuyin
        Me.pbYuyin.Location = New System.Drawing.Point(544, 2)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(119, 56)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 0
        Me.pbYuyin.TabStop = False
        '
        'tabAltaIncentivos
        '
        Me.tabAltaIncentivos.Controls.Add(Me.TabPage1)
        Me.tabAltaIncentivos.Controls.Add(Me.BuscarEmpleado)
        Me.tabAltaIncentivos.Location = New System.Drawing.Point(-4, 93)
        Me.tabAltaIncentivos.Name = "tabAltaIncentivos"
        Me.tabAltaIncentivos.SelectedIndex = 0
        Me.tabAltaIncentivos.Size = New System.Drawing.Size(1118, 412)
        Me.tabAltaIncentivos.TabIndex = 13
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnBuscarEmpleado)
        Me.TabPage1.Controls.Add(Me.lblJustificacion)
        Me.TabPage1.Controls.Add(Me.txtMonto)
        Me.TabPage1.Controls.Add(Me.TxtDescripcion)
        Me.TabPage1.Controls.Add(Me.lblMonto)
        Me.TabPage1.Controls.Add(Me.cmbMotivos)
        Me.TabPage1.Controls.Add(Me.lblMotivo)
        Me.TabPage1.Controls.Add(Me.lblLimpiar)
        Me.TabPage1.Controls.Add(Me.lblBuscar)
        Me.TabPage1.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.TabPage1.Controls.Add(Me.btnGuardar)
        Me.TabPage1.Controls.Add(Me.txtBuscarNombreIncentivo)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpleado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1110, 386)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnBuscarEmpleado
        '
        Me.btnBuscarEmpleado.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscarEmpleado.Location = New System.Drawing.Point(304, 6)
        Me.btnBuscarEmpleado.Name = "btnBuscarEmpleado"
        Me.btnBuscarEmpleado.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscarEmpleado.TabIndex = 36
        Me.btnBuscarEmpleado.UseVisualStyleBackColor = True
        '
        'lblJustificacion
        '
        Me.lblJustificacion.AutoSize = True
        Me.lblJustificacion.Location = New System.Drawing.Point(6, 123)
        Me.lblJustificacion.Name = "lblJustificacion"
        Me.lblJustificacion.Size = New System.Drawing.Size(65, 13)
        Me.lblJustificacion.TabIndex = 35
        Me.lblJustificacion.Text = "Justificacion"
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(62, 46)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(118, 20)
        Me.txtMonto.TabIndex = 34
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Location = New System.Drawing.Point(78, 123)
        Me.TxtDescripcion.Multiline = True
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(388, 180)
        Me.TxtDescripcion.TabIndex = 33
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(23, 49)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(37, 13)
        Me.lblMonto.TabIndex = 32
        Me.lblMonto.Text = "Monto"
        '
        'cmbMotivos
        '
        Me.cmbMotivos.FormattingEnabled = True
        Me.cmbMotivos.Location = New System.Drawing.Point(62, 77)
        Me.cmbMotivos.Name = "cmbMotivos"
        Me.cmbMotivos.Size = New System.Drawing.Size(121, 21)
        Me.cmbMotivos.TabIndex = 31
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(21, 80)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(39, 13)
        Me.lblMotivo.TabIndex = 30
        Me.lblMotivo.Text = "Motivo"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(607, 335)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 13)
        Me.lblLimpiar.TabIndex = 29
        Me.lblLimpiar.Text = "Cancelar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(544, 335)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 28
        Me.lblBuscar.Text = "Guardar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(610, 299)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 27
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.guardar_32
        Me.btnGuardar.Location = New System.Drawing.Point(548, 299)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 26
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtBuscarNombreIncentivo
        '
        Me.txtBuscarNombreIncentivo.Location = New System.Drawing.Point(62, 13)
        Me.txtBuscarNombreIncentivo.Name = "txtBuscarNombreIncentivo"
        Me.txtBuscarNombreIncentivo.Size = New System.Drawing.Size(237, 20)
        Me.txtBuscarNombreIncentivo.TabIndex = 25
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(6, 15)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(54, 13)
        Me.lblNombreEmpleado.TabIndex = 24
        Me.lblNombreEmpleado.Text = "Empleado"
        '
        'BuscarEmpleado
        '
        Me.BuscarEmpleado.Controls.Add(Me.btnContinuar)
        Me.BuscarEmpleado.Controls.Add(Me.btnBuscar)
        Me.BuscarEmpleado.Controls.Add(Me.grdBuscarEmpleado)
        Me.BuscarEmpleado.Controls.Add(Me.txtBuscarEmpleado)
        Me.BuscarEmpleado.Controls.Add(Me.lblEmpleado)
        Me.BuscarEmpleado.Location = New System.Drawing.Point(4, 22)
        Me.BuscarEmpleado.Name = "BuscarEmpleado"
        Me.BuscarEmpleado.Padding = New System.Windows.Forms.Padding(3)
        Me.BuscarEmpleado.Size = New System.Drawing.Size(1110, 386)
        Me.BuscarEmpleado.TabIndex = 1
        Me.BuscarEmpleado.Text = "TabPage2"
        Me.BuscarEmpleado.UseVisualStyleBackColor = True
        '
        'btnContinuar
        '
        Me.btnContinuar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.nuevo_32
        Me.btnContinuar.Location = New System.Drawing.Point(353, 6)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(32, 32)
        Me.btnContinuar.TabIndex = 30
        Me.btnContinuar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(304, 6)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 29
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'grdBuscarEmpleado
        '
        Me.grdBuscarEmpleado.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdBuscarEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBuscarEmpleado.Location = New System.Drawing.Point(6, 69)
        Me.grdBuscarEmpleado.Name = "grdBuscarEmpleado"
        Me.grdBuscarEmpleado.Size = New System.Drawing.Size(650, 290)
        Me.grdBuscarEmpleado.TabIndex = 28
        '
        'txtBuscarEmpleado
        '
        Me.txtBuscarEmpleado.Location = New System.Drawing.Point(62, 13)
        Me.txtBuscarEmpleado.Name = "txtBuscarEmpleado"
        Me.txtBuscarEmpleado.Size = New System.Drawing.Size(220, 20)
        Me.txtBuscarEmpleado.TabIndex = 25
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Location = New System.Drawing.Point(6, 15)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(54, 13)
        Me.lblEmpleado.TabIndex = 24
        Me.lblEmpleado.Text = "Empleado"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Location = New System.Drawing.Point(0, 82)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(688, 33)
        Me.Panel1.TabIndex = 14
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(257, 8)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(151, 20)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Agregar Incentivo"
        '
        'AltaIncentivoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(668, 511)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tabAltaIncentivos)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AltaIncentivoForm"
        Me.Text = "AltaIncentivoForm"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAltaIncentivos.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.BuscarEmpleado.ResumeLayout(False)
        Me.BuscarEmpleado.PerformLayout()
        CType(Me.grdBuscarEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents tabAltaIncentivos As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents BuscarEmpleado As System.Windows.Forms.TabPage
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents grdBuscarEmpleado As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscarEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnBuscarEmpleado As System.Windows.Forms.Button
    Friend WithEvents lblJustificacion As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents cmbMotivos As System.Windows.Forms.ComboBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents txtBuscarNombreIncentivo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
End Class
