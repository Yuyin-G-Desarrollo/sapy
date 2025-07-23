<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvioDepositoForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvioDepositoForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEnviar = New System.Windows.Forms.Label()
        Me.btnenviar = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grdDeposito = New System.Windows.Forms.DataGridView()
        Me.clmConsecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmNumCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTitular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCncelar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.grdDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblEnviar)
        Me.pnlHeader.Controls.Add(Me.btnenviar)
        Me.pnlHeader.Controls.Add(Me.lblImprimir)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(726, 60)
        Me.pnlHeader.TabIndex = 16
        '
        'lblEnviar
        '
        Me.lblEnviar.AutoSize = True
        Me.lblEnviar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEnviar.Location = New System.Drawing.Point(10, 42)
        Me.lblEnviar.Name = "lblEnviar"
        Me.lblEnviar.Size = New System.Drawing.Size(37, 13)
        Me.lblEnviar.TabIndex = 13
        Me.lblEnviar.Text = "Enviar"
        '
        'btnenviar
        '
        Me.btnenviar.Image = Global.Nomina.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnenviar.Location = New System.Drawing.Point(13, 7)
        Me.btnenviar.Name = "btnenviar"
        Me.btnenviar.Size = New System.Drawing.Size(32, 32)
        Me.btnenviar.TabIndex = 12
        Me.btnenviar.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.Location = New System.Drawing.Point(59, 42)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(41, 13)
        Me.lblImprimir.TabIndex = 11
        Me.lblImprimir.Text = "imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(62, 7)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 10
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(460, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(266, 60)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(35, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(161, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Envio de depositos"
        '
        'grdDeposito
        '
        Me.grdDeposito.AllowUserToAddRows = False
        Me.grdDeposito.AllowUserToDeleteRows = False
        Me.grdDeposito.AllowUserToResizeColumns = False
        Me.grdDeposito.AllowUserToResizeRows = False
        Me.grdDeposito.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.grdDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDeposito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmConsecutivo, Me.clmNumCuenta, Me.clmTitular, Me.clmTotal})
        Me.grdDeposito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDeposito.Location = New System.Drawing.Point(0, 60)
        Me.grdDeposito.Name = "grdDeposito"
        Me.grdDeposito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDeposito.Size = New System.Drawing.Size(726, 379)
        Me.grdDeposito.TabIndex = 17
        '
        'clmConsecutivo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmConsecutivo.DefaultCellStyle = DataGridViewCellStyle1
        Me.clmConsecutivo.HeaderText = "#"
        Me.clmConsecutivo.Name = "clmConsecutivo"
        Me.clmConsecutivo.ReadOnly = True
        Me.clmConsecutivo.Width = 25
        '
        'clmNumCuenta
        '
        Me.clmNumCuenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clmNumCuenta.DefaultCellStyle = DataGridViewCellStyle2
        Me.clmNumCuenta.HeaderText = "Cuenta"
        Me.clmNumCuenta.Name = "clmNumCuenta"
        Me.clmNumCuenta.ReadOnly = True
        Me.clmNumCuenta.Width = 66
        '
        'clmTitular
        '
        Me.clmTitular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.clmTitular.DefaultCellStyle = DataGridViewCellStyle3
        Me.clmTitular.HeaderText = "Titular"
        Me.clmTitular.Name = "clmTitular"
        Me.clmTitular.ReadOnly = True
        '
        'clmTotal
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.clmTotal.DefaultCellStyle = DataGridViewCellStyle4
        Me.clmTotal.HeaderText = "Total"
        Me.clmTotal.Name = "clmTotal"
        Me.clmTotal.ReadOnly = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Controls.Add(Me.Label6)
        Me.pnlEstado.Controls.Add(Me.lbltotal)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 439)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(726, 60)
        Me.pnlEstado.TabIndex = 19
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnCncelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(603, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(123, 60)
        Me.pnlAcciones.TabIndex = 18
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(76, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 60
        Me.lblCancelar.Text = "Cerrar"
        Me.lblCancelar.Visible = False
        '
        'btnCncelar
        '
        Me.btnCncelar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCncelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCncelar.Location = New System.Drawing.Point(77, 10)
        Me.btnCncelar.Name = "btnCncelar"
        Me.btnCncelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCncelar.TabIndex = 59
        Me.btnCncelar.UseVisualStyleBackColor = True
        Me.btnCncelar.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.GreenYellow
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.ForeColor = System.Drawing.Color.GreenYellow
        Me.Label6.Location = New System.Drawing.Point(13, 26)
        Me.Label6.MaximumSize = New System.Drawing.Size(15, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "___"
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.ForeColor = System.Drawing.Color.Black
        Me.lbltotal.Location = New System.Drawing.Point(31, 26)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(31, 13)
        Me.lbltotal.TabIndex = 1
        Me.lbltotal.Text = "Total"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(198, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 27
        Me.pcbTitulo.TabStop = False
        '
        'EnvioDepositoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(726, 499)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdDeposito)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EnvioDepositoForm"
        Me.Text = "EnvioDeposito"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.grdDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grdDeposito As System.Windows.Forms.DataGridView
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCncelar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents lblEnviar As System.Windows.Forms.Label
    Friend WithEvents btnenviar As System.Windows.Forms.Button
    Friend WithEvents clmConsecutivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNumCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTitular As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcbTitulo As PictureBox
End Class
