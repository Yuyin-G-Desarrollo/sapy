<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpedienteColaboradorForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpedienteColaboradorForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblDescargar = New System.Windows.Forms.Label()
        Me.btnDescargar = New System.Windows.Forms.Button()
        Me.pnlRemplazar = New System.Windows.Forms.Panel()
        Me.btnRemplazar = New System.Windows.Forms.Button()
        Me.lblReemplazar = New System.Windows.Forms.Label()
        Me.pnlDescargar = New System.Windows.Forms.Panel()
        Me.btnAbrir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.gpbDatos = New System.Windows.Forms.GroupBox()
        Me.lblNSS = New System.Windows.Forms.Label()
        Me.lblNSSE = New System.Windows.Forms.Label()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.lblColaboradorE = New System.Windows.Forms.Label()
        Me.grdExpediente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.guardarArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.ofdReemplazar = New System.Windows.Forms.OpenFileDialog()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlRemplazar.SuspendLayout()
        Me.pnlDescargar.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.gpbDatos.SuspendLayout()
        CType(Me.grdExpediente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblDescargar)
        Me.pnlEncabezado.Controls.Add(Me.btnDescargar)
        Me.pnlEncabezado.Controls.Add(Me.pnlRemplazar)
        Me.pnlEncabezado.Controls.Add(Me.pnlDescargar)
        Me.pnlEncabezado.Controls.Add(Me.Label1)
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezado)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(547, 59)
        Me.pnlEncabezado.TabIndex = 38
        '
        'lblDescargar
        '
        Me.lblDescargar.AutoSize = True
        Me.lblDescargar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDescargar.Location = New System.Drawing.Point(173, 41)
        Me.lblDescargar.Name = "lblDescargar"
        Me.lblDescargar.Size = New System.Drawing.Size(56, 13)
        Me.lblDescargar.TabIndex = 3
        Me.lblDescargar.Text = "Descargar"
        Me.lblDescargar.Visible = False
        '
        'btnDescargar
        '
        Me.btnDescargar.Image = CType(resources.GetObject("btnDescargar.Image"), System.Drawing.Image)
        Me.btnDescargar.Location = New System.Drawing.Point(185, 8)
        Me.btnDescargar.Name = "btnDescargar"
        Me.btnDescargar.Size = New System.Drawing.Size(31, 32)
        Me.btnDescargar.TabIndex = 1
        Me.btnDescargar.UseVisualStyleBackColor = True
        Me.btnDescargar.Visible = False
        '
        'pnlRemplazar
        '
        Me.pnlRemplazar.Controls.Add(Me.btnRemplazar)
        Me.pnlRemplazar.Controls.Add(Me.lblReemplazar)
        Me.pnlRemplazar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRemplazar.Location = New System.Drawing.Point(66, 0)
        Me.pnlRemplazar.Name = "pnlRemplazar"
        Me.pnlRemplazar.Size = New System.Drawing.Size(66, 59)
        Me.pnlRemplazar.TabIndex = 27
        '
        'btnRemplazar
        '
        Me.btnRemplazar.Image = Global.Contabilidad.Vista.My.Resources.Resources.copiar_32
        Me.btnRemplazar.Location = New System.Drawing.Point(18, 7)
        Me.btnRemplazar.Name = "btnRemplazar"
        Me.btnRemplazar.Size = New System.Drawing.Size(31, 32)
        Me.btnRemplazar.TabIndex = 7
        Me.btnRemplazar.UseVisualStyleBackColor = True
        '
        'lblReemplazar
        '
        Me.lblReemplazar.AutoSize = True
        Me.lblReemplazar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReemplazar.Location = New System.Drawing.Point(2, 41)
        Me.lblReemplazar.Name = "lblReemplazar"
        Me.lblReemplazar.Size = New System.Drawing.Size(63, 13)
        Me.lblReemplazar.TabIndex = 8
        Me.lblReemplazar.Text = "Reemplazar"
        '
        'pnlDescargar
        '
        Me.pnlDescargar.Controls.Add(Me.btnAbrir)
        Me.pnlDescargar.Controls.Add(Me.Label2)
        Me.pnlDescargar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescargar.Location = New System.Drawing.Point(0, 0)
        Me.pnlDescargar.Name = "pnlDescargar"
        Me.pnlDescargar.Size = New System.Drawing.Size(66, 59)
        Me.pnlDescargar.TabIndex = 26
        '
        'btnAbrir
        '
        Me.btnAbrir.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnAbrir.Location = New System.Drawing.Point(16, 7)
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(32, 32)
        Me.btnAbrir.TabIndex = 0
        Me.btnAbrir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(7, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Visualizar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(371, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 20)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Expediente"
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(563, 18)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(265, 20)
        Me.lblEncabezado.TabIndex = 5
        Me.lblEncabezado.Text = "Alta y Edición de Colaboradores"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 397)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(547, 60)
        Me.Panel2.TabIndex = 39
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnCerrar)
        Me.Panel7.Controls.Add(Me.lblCerrar)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(495, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(52, 60)
        Me.Panel7.TabIndex = 37
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
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
        'gpbDatos
        '
        Me.gpbDatos.BackColor = System.Drawing.Color.AliceBlue
        Me.gpbDatos.Controls.Add(Me.lblNSS)
        Me.gpbDatos.Controls.Add(Me.lblNSSE)
        Me.gpbDatos.Controls.Add(Me.lblColaborador)
        Me.gpbDatos.Controls.Add(Me.lblColaboradorE)
        Me.gpbDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbDatos.Location = New System.Drawing.Point(0, 59)
        Me.gpbDatos.Name = "gpbDatos"
        Me.gpbDatos.Size = New System.Drawing.Size(547, 77)
        Me.gpbDatos.TabIndex = 40
        Me.gpbDatos.TabStop = False
        '
        'lblNSS
        '
        Me.lblNSS.AutoSize = True
        Me.lblNSS.Location = New System.Drawing.Point(82, 45)
        Me.lblNSS.Name = "lblNSS"
        Me.lblNSS.Size = New System.Drawing.Size(32, 13)
        Me.lblNSS.TabIndex = 0
        Me.lblNSS.Text = "NSS:"
        '
        'lblNSSE
        '
        Me.lblNSSE.AutoSize = True
        Me.lblNSSE.Location = New System.Drawing.Point(13, 45)
        Me.lblNSSE.Name = "lblNSSE"
        Me.lblNSSE.Size = New System.Drawing.Size(32, 13)
        Me.lblNSSE.TabIndex = 0
        Me.lblNSSE.Text = "NSS:"
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Location = New System.Drawing.Point(82, 20)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(67, 13)
        Me.lblColaborador.TabIndex = 0
        Me.lblColaborador.Text = "Colaborador:"
        '
        'lblColaboradorE
        '
        Me.lblColaboradorE.AutoSize = True
        Me.lblColaboradorE.Location = New System.Drawing.Point(13, 20)
        Me.lblColaboradorE.Name = "lblColaboradorE"
        Me.lblColaboradorE.Size = New System.Drawing.Size(67, 13)
        Me.lblColaboradorE.TabIndex = 0
        Me.lblColaboradorE.Text = "Colaborador:"
        '
        'grdExpediente
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdExpediente.DisplayLayout.Appearance = Appearance1
        Me.grdExpediente.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdExpediente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdExpediente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdExpediente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdExpediente.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdExpediente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdExpediente.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdExpediente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdExpediente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdExpediente.Location = New System.Drawing.Point(0, 136)
        Me.grdExpediente.Name = "grdExpediente"
        Me.grdExpediente.Size = New System.Drawing.Size(547, 261)
        Me.grdExpediente.TabIndex = 41
        '
        'ofdReemplazar
        '
        Me.ofdReemplazar.FileName = "OpenFileDialog1"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(475, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 38
        Me.imgLogo.TabStop = False
        '
        'ExpedienteColaboradorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 457)
        Me.Controls.Add(Me.grdExpediente)
        Me.Controls.Add(Me.gpbDatos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ExpedienteColaboradorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Expediente Colaborador"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlRemplazar.ResumeLayout(False)
        Me.pnlRemplazar.PerformLayout()
        Me.pnlDescargar.ResumeLayout(False)
        Me.pnlDescargar.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.gpbDatos.ResumeLayout(False)
        Me.gpbDatos.PerformLayout()
        CType(Me.grdExpediente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlDescargar As System.Windows.Forms.Panel
    Friend WithEvents btnDescargar As System.Windows.Forms.Button
    Friend WithEvents lblDescargar As System.Windows.Forms.Label
    Friend WithEvents pnlRemplazar As System.Windows.Forms.Panel
    Friend WithEvents btnRemplazar As System.Windows.Forms.Button
    Friend WithEvents lblReemplazar As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents gpbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblColaboradorE As System.Windows.Forms.Label
    Friend WithEvents lblNSSE As System.Windows.Forms.Label
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents lblNSS As System.Windows.Forms.Label
    Friend WithEvents grdExpediente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents guardarArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ofdReemplazar As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnAbrir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
