<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbonoExtraordinarioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AbonoExtraordinarioForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNuevoSaldo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalAbono = New System.Windows.Forms.TextBox()
        Me.lblInteres = New System.Windows.Forms.Label()
        Me.lblAbono = New System.Windows.Forms.Label()
        Me.lblSemanas = New System.Windows.Forms.Label()
        Me.txtInteres = New System.Windows.Forms.TextBox()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.txtMontoSolicitado = New System.Windows.Forms.TextBox()
        Me.txtSaldoCapital = New System.Windows.Forms.TextBox()
        Me.txtSaldoTotal = New System.Windows.Forms.TextBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblcerrar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(459, 60)
        Me.pnlHeader.TabIndex = 7
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(152, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(307, 60)
        Me.pnlTitulo.TabIndex = 41
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(53, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(178, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Abono Extraordinario"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtNuevoSaldo)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtTotalAbono)
        Me.Panel2.Controls.Add(Me.lblInteres)
        Me.Panel2.Controls.Add(Me.lblAbono)
        Me.Panel2.Controls.Add(Me.lblSemanas)
        Me.Panel2.Controls.Add(Me.txtInteres)
        Me.Panel2.Controls.Add(Me.lblMonto)
        Me.Panel2.Controls.Add(Me.txtMontoSolicitado)
        Me.Panel2.Controls.Add(Me.txtSaldoCapital)
        Me.Panel2.Controls.Add(Me.txtSaldoTotal)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(13, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(434, 285)
        Me.Panel2.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(62, 236)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Nuevo Saldo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNuevoSaldo
        '
        Me.txtNuevoSaldo.Enabled = False
        Me.txtNuevoSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNuevoSaldo.ForeColor = System.Drawing.Color.Black
        Me.txtNuevoSaldo.Location = New System.Drawing.Point(171, 233)
        Me.txtNuevoSaldo.Name = "txtNuevoSaldo"
        Me.txtNuevoSaldo.Size = New System.Drawing.Size(200, 22)
        Me.txtNuevoSaldo.TabIndex = 62
        Me.txtNuevoSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(62, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Total Abono"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalAbono
        '
        Me.txtTotalAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAbono.ForeColor = System.Drawing.Color.Black
        Me.txtTotalAbono.Location = New System.Drawing.Point(171, 196)
        Me.txtTotalAbono.Name = "txtTotalAbono"
        Me.txtTotalAbono.Size = New System.Drawing.Size(200, 22)
        Me.txtTotalAbono.TabIndex = 60
        Me.txtTotalAbono.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInteres
        '
        Me.lblInteres.AutoSize = True
        Me.lblInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInteres.ForeColor = System.Drawing.Color.Black
        Me.lblInteres.Location = New System.Drawing.Point(62, 113)
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Size = New System.Drawing.Size(88, 16)
        Me.lblInteres.TabIndex = 21
        Me.lblInteres.Text = "Monto Interés"
        Me.lblInteres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAbono
        '
        Me.lblAbono.AutoSize = True
        Me.lblAbono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbono.ForeColor = System.Drawing.Color.Black
        Me.lblAbono.Location = New System.Drawing.Point(62, 154)
        Me.lblAbono.Name = "lblAbono"
        Me.lblAbono.Size = New System.Drawing.Size(78, 16)
        Me.lblAbono.TabIndex = 22
        Me.lblAbono.Text = "Saldo Total"
        Me.lblAbono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSemanas
        '
        Me.lblSemanas.AutoSize = True
        Me.lblSemanas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanas.ForeColor = System.Drawing.Color.Black
        Me.lblSemanas.Location = New System.Drawing.Point(62, 72)
        Me.lblSemanas.Name = "lblSemanas"
        Me.lblSemanas.Size = New System.Drawing.Size(89, 16)
        Me.lblSemanas.TabIndex = 20
        Me.lblSemanas.Text = "Saldo Capital"
        Me.lblSemanas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtInteres
        '
        Me.txtInteres.Enabled = False
        Me.txtInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInteres.ForeColor = System.Drawing.Color.Black
        Me.txtInteres.Location = New System.Drawing.Point(171, 112)
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Size = New System.Drawing.Size(200, 22)
        Me.txtInteres.TabIndex = 4
        Me.txtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(62, 31)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(108, 16)
        Me.lblMonto.TabIndex = 19
        Me.lblMonto.Text = "Monto Solicitado"
        Me.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMontoSolicitado
        '
        Me.txtMontoSolicitado.Enabled = False
        Me.txtMontoSolicitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoSolicitado.ForeColor = System.Drawing.Color.Black
        Me.txtMontoSolicitado.Location = New System.Drawing.Point(171, 28)
        Me.txtMontoSolicitado.Name = "txtMontoSolicitado"
        Me.txtMontoSolicitado.Size = New System.Drawing.Size(200, 22)
        Me.txtMontoSolicitado.TabIndex = 1
        Me.txtMontoSolicitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoCapital
        '
        Me.txtSaldoCapital.Enabled = False
        Me.txtSaldoCapital.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoCapital.ForeColor = System.Drawing.Color.Black
        Me.txtSaldoCapital.Location = New System.Drawing.Point(171, 70)
        Me.txtSaldoCapital.Name = "txtSaldoCapital"
        Me.txtSaldoCapital.Size = New System.Drawing.Size(200, 22)
        Me.txtSaldoCapital.TabIndex = 2
        Me.txtSaldoCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSaldoTotal
        '
        Me.txtSaldoTotal.Enabled = False
        Me.txtSaldoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoTotal.ForeColor = System.Drawing.Color.Black
        Me.txtSaldoTotal.Location = New System.Drawing.Point(171, 154)
        Me.txtSaldoTotal.Name = "txtSaldoTotal"
        Me.txtSaldoTotal.Size = New System.Drawing.Size(200, 22)
        Me.txtSaldoTotal.TabIndex = 3
        Me.txtSaldoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.ForeColor = System.Drawing.Color.Black
        Me.pnlEstado.Location = New System.Drawing.Point(0, 357)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(459, 60)
        Me.pnlEstado.TabIndex = 62
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblcerrar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(342, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(117, 60)
        Me.pnlAcciones.TabIndex = 47
        '
        'lblcerrar
        '
        Me.lblcerrar.AutoSize = True
        Me.lblcerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblcerrar.Location = New System.Drawing.Point(68, 41)
        Me.lblcerrar.Name = "lblcerrar"
        Me.lblcerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblcerrar.TabIndex = 9
        Me.lblcerrar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(16, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(13, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Generar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(67, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(239, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 42
        Me.pcbTitulo.TabStop = False
        '
        'AbonoExtraordinarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(459, 417)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AbonoExtraordinarioForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Abono Extraordinario"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblInteres As System.Windows.Forms.Label
    Friend WithEvents lblAbono As System.Windows.Forms.Label
    Friend WithEvents lblSemanas As System.Windows.Forms.Label
    Friend WithEvents txtInteres As System.Windows.Forms.TextBox
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents txtMontoSolicitado As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoCapital As System.Windows.Forms.TextBox
    Friend WithEvents txtSaldoTotal As System.Windows.Forms.TextBox
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblcerrar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAbono As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNuevoSaldo As System.Windows.Forms.TextBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
