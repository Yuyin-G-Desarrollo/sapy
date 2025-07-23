<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RelacionCuentasContablesForm
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
        Me.lblHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPolizasContables = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.grdCuentasContpac = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdCuentasContpac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.White
        Me.lblHeader.Controls.Add(Me.Label1)
        Me.lblHeader.Controls.Add(Me.btnAlta)
        Me.lblHeader.Controls.Add(Me.Panel1)
        Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(608, 60)
        Me.lblHeader.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(15, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Crear nueva"
        '
        'btnAlta
        '
        Me.btnAlta.Image = Global.Contabilidad.Vista.My.Resources.Resources.agregar_32
        Me.btnAlta.Location = New System.Drawing.Point(30, 5)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(34, 35)
        Me.btnAlta.TabIndex = 47
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblPolizasContables)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(270, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(338, 60)
        Me.Panel1.TabIndex = 46
        '
        'lblPolizasContables
        '
        Me.lblPolizasContables.AutoSize = True
        Me.lblPolizasContables.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolizasContables.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPolizasContables.Location = New System.Drawing.Point(28, 20)
        Me.lblPolizasContables.Name = "lblPolizasContables"
        Me.lblPolizasContables.Size = New System.Drawing.Size(237, 20)
        Me.lblPolizasContables.TabIndex = 21
        Me.lblPolizasContables.Text = "Relacion Cuentas Contables"
        '
        'pnlEstado
        '
        Me.pnlEstado.Controls.Add(Me.pnlBotones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 426)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(608, 60)
        Me.pnlEstado.TabIndex = 20
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.btnsalir)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(420, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(188, 60)
        Me.pnlBotones.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(138, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Salir"
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnsalir.Location = New System.Drawing.Point(134, 5)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(34, 35)
        Me.btnsalir.TabIndex = 8
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'grdCuentasContpac
        '
        Me.grdCuentasContpac.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCuentasContpac.Location = New System.Drawing.Point(0, 60)
        Me.grdCuentasContpac.Name = "grdCuentasContpac"
        Me.grdCuentasContpac.Size = New System.Drawing.Size(608, 366)
        Me.grdCuentasContpac.TabIndex = 22
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(266, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 47
        Me.imgLogo.TabStop = False
        '
        'RelacionCuentasContablesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(608, 486)
        Me.Controls.Add(Me.grdCuentasContpac)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.pnlEstado)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RelacionCuentasContablesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relacion cuentas contables"
        Me.lblHeader.ResumeLayout(False)
        Me.lblHeader.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdCuentasContpac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPolizasContables As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents grdCuentasContpac As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
