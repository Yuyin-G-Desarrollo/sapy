<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SolicitudFinanzasNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SolicitudFinanzasNomina))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNominaFiscal = New System.Windows.Forms.TextBox()
        Me.lblTotalNomFiscal = New System.Windows.Forms.Label()
        Me.lblChequeEfectivo = New System.Windows.Forms.Label()
        Me.lblChequeEfec = New System.Windows.Forms.Label()
        Me.lblSaldoE = New System.Windows.Forms.Label()
        Me.lblTotalNomina = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCheque = New System.Windows.Forms.Label()
        Me.lblChequeEt = New System.Windows.Forms.Label()
        Me.lblDeducciones = New System.Windows.Forms.Label()
        Me.lbldeduccionesEt = New System.Windows.Forms.Label()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblEfectivoEt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblNaveE = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Panel1)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(382, 59)
        Me.pnlHeader.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(68, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 59)
        Me.Panel1.TabIndex = 48
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(8, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(236, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Solicitud a Finanzas Nómina"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 405)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(382, 63)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblGuardar)
        Me.Panel3.Controls.Add(Me.btnGuardar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(279, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(51, 63)
        Me.Panel3.TabIndex = 39
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(3, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 1
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(8, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnCerrar)
        Me.Panel7.Controls.Add(Me.lblCerrar)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(330, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(52, 63)
        Me.Panel7.TabIndex = 38
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(9, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(8, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 19
        Me.lblCerrar.Text = "Cerrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNominaFiscal)
        Me.GroupBox1.Controls.Add(Me.lblTotalNomFiscal)
        Me.GroupBox1.Controls.Add(Me.lblChequeEfectivo)
        Me.GroupBox1.Controls.Add(Me.lblChequeEfec)
        Me.GroupBox1.Controls.Add(Me.lblSaldoE)
        Me.GroupBox1.Controls.Add(Me.lblTotalNomina)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblCheque)
        Me.GroupBox1.Controls.Add(Me.lblChequeEt)
        Me.GroupBox1.Controls.Add(Me.lblDeducciones)
        Me.GroupBox1.Controls.Add(Me.lbldeduccionesEt)
        Me.GroupBox1.Controls.Add(Me.lblSaldo)
        Me.GroupBox1.Controls.Add(Me.lblEfectivo)
        Me.GroupBox1.Controls.Add(Me.lblEfectivoEt)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblNave)
        Me.GroupBox1.Controls.Add(Me.lblNaveE)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 332)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'txtNominaFiscal
        '
        Me.txtNominaFiscal.Location = New System.Drawing.Point(190, 89)
        Me.txtNominaFiscal.Name = "txtNominaFiscal"
        Me.txtNominaFiscal.ReadOnly = True
        Me.txtNominaFiscal.Size = New System.Drawing.Size(156, 20)
        Me.txtNominaFiscal.TabIndex = 9
        '
        'lblTotalNomFiscal
        '
        Me.lblTotalNomFiscal.AutoSize = True
        Me.lblTotalNomFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNomFiscal.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalNomFiscal.Location = New System.Drawing.Point(187, 90)
        Me.lblTotalNomFiscal.Name = "lblTotalNomFiscal"
        Me.lblTotalNomFiscal.Size = New System.Drawing.Size(139, 16)
        Me.lblTotalNomFiscal.TabIndex = 24
        Me.lblTotalNomFiscal.Text = "TotalNominaFiscal"
        Me.lblTotalNomFiscal.Visible = False
        '
        'lblChequeEfectivo
        '
        Me.lblChequeEfectivo.AutoSize = True
        Me.lblChequeEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChequeEfectivo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblChequeEfectivo.Location = New System.Drawing.Point(187, 203)
        Me.lblChequeEfectivo.Name = "lblChequeEfectivo"
        Me.lblChequeEfectivo.Size = New System.Drawing.Size(67, 16)
        Me.lblChequeEfectivo.TabIndex = 23
        Me.lblChequeEfectivo.Text = "cheque2"
        Me.lblChequeEfectivo.Visible = False
        '
        'lblChequeEfec
        '
        Me.lblChequeEfec.AutoSize = True
        Me.lblChequeEfec.Location = New System.Drawing.Point(6, 206)
        Me.lblChequeEfec.Name = "lblChequeEfec"
        Me.lblChequeEfec.Size = New System.Drawing.Size(165, 13)
        Me.lblChequeEfec.TabIndex = 22
        Me.lblChequeEfec.Text = "(-) Complemento Cheque Efectivo"
        Me.lblChequeEfec.Visible = False
        '
        'lblSaldoE
        '
        Me.lblSaldoE.AutoSize = True
        Me.lblSaldoE.Location = New System.Drawing.Point(11, 285)
        Me.lblSaldoE.Name = "lblSaldoE"
        Me.lblSaldoE.Size = New System.Drawing.Size(34, 13)
        Me.lblSaldoE.TabIndex = 21
        Me.lblSaldoE.Text = "Saldo"
        '
        'lblTotalNomina
        '
        Me.lblTotalNomina.AutoSize = True
        Me.lblTotalNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalNomina.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTotalNomina.Location = New System.Drawing.Point(187, 54)
        Me.lblTotalNomina.Name = "lblTotalNomina"
        Me.lblTotalNomina.Size = New System.Drawing.Size(97, 16)
        Me.lblTotalNomina.TabIndex = 20
        Me.lblTotalNomina.Text = "TotalNomina"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Total Nómina:"
        '
        'lblCheque
        '
        Me.lblCheque.AutoSize = True
        Me.lblCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheque.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCheque.Location = New System.Drawing.Point(187, 170)
        Me.lblCheque.Name = "lblCheque"
        Me.lblCheque.Size = New System.Drawing.Size(59, 16)
        Me.lblCheque.TabIndex = 17
        Me.lblCheque.Text = "cheque"
        '
        'lblChequeEt
        '
        Me.lblChequeEt.AutoSize = True
        Me.lblChequeEt.Location = New System.Drawing.Point(6, 173)
        Me.lblChequeEt.Name = "lblChequeEt"
        Me.lblChequeEt.Size = New System.Drawing.Size(168, 13)
        Me.lblChequeEt.TabIndex = 16
        Me.lblChequeEt.Text = "(-) Complemento Cheque Depósito"
        '
        'lblDeducciones
        '
        Me.lblDeducciones.AutoSize = True
        Me.lblDeducciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeducciones.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDeducciones.Location = New System.Drawing.Point(187, 131)
        Me.lblDeducciones.Name = "lblDeducciones"
        Me.lblDeducciones.Size = New System.Drawing.Size(99, 16)
        Me.lblDeducciones.TabIndex = 15
        Me.lblDeducciones.Text = "Deducciones"
        '
        'lbldeduccionesEt
        '
        Me.lbldeduccionesEt.AutoSize = True
        Me.lbldeduccionesEt.Location = New System.Drawing.Point(6, 134)
        Me.lbldeduccionesEt.Name = "lbldeduccionesEt"
        Me.lbldeduccionesEt.Size = New System.Drawing.Size(121, 13)
        Me.lbldeduccionesEt.TabIndex = 14
        Me.lbldeduccionesEt.Text = "(-) Nomina Deducciones"
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblSaldo.Location = New System.Drawing.Point(190, 282)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(49, 16)
        Me.lblSaldo.TabIndex = 13
        Me.lblSaldo.Text = "Saldo"
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEfectivo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEfectivo.Location = New System.Drawing.Point(190, 242)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(64, 16)
        Me.lblEfectivo.TabIndex = 13
        Me.lblEfectivo.Text = "Efectivo"
        '
        'lblEfectivoEt
        '
        Me.lblEfectivoEt.AutoSize = True
        Me.lblEfectivoEt.Location = New System.Drawing.Point(6, 245)
        Me.lblEfectivoEt.Name = "lblEfectivoEt"
        Me.lblEfectivoEt.Size = New System.Drawing.Size(125, 13)
        Me.lblEfectivoEt.TabIndex = 12
        Me.lblEfectivoEt.Text = "(-) Complemento Efectivo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "(-) Nomina Fiscal"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblNave.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNave.Location = New System.Drawing.Point(187, 19)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(45, 16)
        Me.lblNave.TabIndex = 1
        Me.lblNave.Text = "Nave"
        '
        'lblNaveE
        '
        Me.lblNaveE.AutoSize = True
        Me.lblNaveE.Location = New System.Drawing.Point(6, 19)
        Me.lblNaveE.Name = "lblNaveE"
        Me.lblNaveE.Size = New System.Drawing.Size(36, 13)
        Me.lblNaveE.TabIndex = 0
        Me.lblNaveE.Text = "Nave:"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(246, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'SolicitudFinanzasNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(382, 468)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SolicitudFinanzasNomina"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicitud a Finanzas Nómina"
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblNaveE As System.Windows.Forms.Label
    Friend WithEvents lblCheque As System.Windows.Forms.Label
    Friend WithEvents lblChequeEt As System.Windows.Forms.Label
    Friend WithEvents lblDeducciones As System.Windows.Forms.Label
    Friend WithEvents lbldeduccionesEt As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblEfectivoEt As System.Windows.Forms.Label
    Friend WithEvents txtNominaFiscal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalNomina As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoE As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents lblChequeEfectivo As Label
    Friend WithEvents lblChequeEfec As Label
    Friend WithEvents lblTotalNomFiscal As Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
