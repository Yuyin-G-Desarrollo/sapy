<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteCierreSemanalForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCierreSemanalForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.onlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.grdCierreSemanal = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.grbCierreSemanal = New System.Windows.Forms.GroupBox()
        Me.lblNombreNave = New System.Windows.Forms.Label()
        Me.pnlMinimizar = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSemanaNomina = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblConceptoPeriodo = New System.Windows.Forms.Label()
        Me.lblRegresar = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.onlTitulo.SuspendLayout()
        CType(Me.grdCierreSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCierreSemanal.SuspendLayout()
        Me.pnlMinimizar.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.onlTitulo)
        Me.pnlHeader.Controls.Add(Me.lblImprimir)
        Me.pnlHeader.Controls.Add(Me.btnImprimir)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(740, 59)
        Me.pnlHeader.TabIndex = 33
        '
        'onlTitulo
        '
        Me.onlTitulo.Controls.Add(Me.pcbTitulo)
        Me.onlTitulo.Controls.Add(Me.lblTitulo)
        Me.onlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.onlTitulo.Location = New System.Drawing.Point(455, 0)
        Me.onlTitulo.Name = "onlTitulo"
        Me.onlTitulo.Size = New System.Drawing.Size(285, 59)
        Me.onlTitulo.TabIndex = 28
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(2, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(207, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Reporte Cierre Semanal "
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImprimir.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblImprimir.Location = New System.Drawing.Point(22, 40)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 23
        Me.lblImprimir.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.AliceBlue
        Me.btnImprimir.Image = Global.Nomina.Vista.My.Resources.Resources._1377984784_printer
        Me.btnImprimir.Location = New System.Drawing.Point(27, 5)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 22
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(582, 146)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBúscar.TabIndex = 40
        Me.lblBúscar.Text = "Mostrar"
        '
        'grdCierreSemanal
        '
        Me.grdCierreSemanal.AllowEditing = False
        Me.grdCierreSemanal.AllowFiltering = True
        Me.grdCierreSemanal.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
        Me.grdCierreSemanal.BackColor = System.Drawing.Color.White
        Me.grdCierreSemanal.ColumnInfo = resources.GetString("grdCierreSemanal.ColumnInfo")
        Me.grdCierreSemanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCierreSemanal.ExtendLastCol = True
        Me.grdCierreSemanal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grdCierreSemanal.Location = New System.Drawing.Point(0, 232)
        Me.grdCierreSemanal.Name = "grdCierreSemanal"
        Me.grdCierreSemanal.Rows.Count = 6
        Me.grdCierreSemanal.Rows.DefaultSize = 19
        Me.grdCierreSemanal.Size = New System.Drawing.Size(740, 299)
        Me.grdCierreSemanal.StyleInfo = resources.GetString("grdCierreSemanal.StyleInfo")
        Me.grdCierreSemanal.TabIndex = 35
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(627, 146)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 39
        Me.lblLimpiar.Text = "Limpiar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.txtBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBuscar.Location = New System.Drawing.Point(101, 140)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(466, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblBuscar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBuscar.Location = New System.Drawing.Point(12, 140)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(78, 15)
        Me.lblBuscar.TabIndex = 8
        Me.lblBuscar.Text = "Colaborador:"
        '
        'grbCierreSemanal
        '
        Me.grbCierreSemanal.BackColor = System.Drawing.Color.Transparent
        Me.grbCierreSemanal.Controls.Add(Me.lblNombreNave)
        Me.grbCierreSemanal.Controls.Add(Me.pnlMinimizar)
        Me.grbCierreSemanal.Controls.Add(Me.Label1)
        Me.grbCierreSemanal.Controls.Add(Me.cmbSemanaNomina)
        Me.grbCierreSemanal.Controls.Add(Me.lblBúscar)
        Me.grbCierreSemanal.Controls.Add(Me.lblLimpiar)
        Me.grbCierreSemanal.Controls.Add(Me.btnLimpiar)
        Me.grbCierreSemanal.Controls.Add(Me.btnBuscar)
        Me.grbCierreSemanal.Controls.Add(Me.txtBuscar)
        Me.grbCierreSemanal.Controls.Add(Me.lblBuscar)
        Me.grbCierreSemanal.Controls.Add(Me.lblPeriodo)
        Me.grbCierreSemanal.Controls.Add(Me.lblNave)
        Me.grbCierreSemanal.Controls.Add(Me.lblConceptoPeriodo)
        Me.grbCierreSemanal.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbCierreSemanal.Location = New System.Drawing.Point(0, 59)
        Me.grbCierreSemanal.Name = "grbCierreSemanal"
        Me.grbCierreSemanal.Size = New System.Drawing.Size(740, 173)
        Me.grbCierreSemanal.TabIndex = 34
        Me.grbCierreSemanal.TabStop = False
        '
        'lblNombreNave
        '
        Me.lblNombreNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblNombreNave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNombreNave.Location = New System.Drawing.Point(101, 55)
        Me.lblNombreNave.Name = "lblNombreNave"
        Me.lblNombreNave.Size = New System.Drawing.Size(317, 15)
        Me.lblNombreNave.TabIndex = 46
        Me.lblNombreNave.Text = "COMERCIALIZADORA DE SUELAS"
        '
        'pnlMinimizar
        '
        Me.pnlMinimizar.Controls.Add(Me.btnArriba)
        Me.pnlMinimizar.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizar.Location = New System.Drawing.Point(673, 16)
        Me.pnlMinimizar.Name = "pnlMinimizar"
        Me.pnlMinimizar.Size = New System.Drawing.Size(64, 154)
        Me.pnlMinimizar.TabIndex = 45
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(12, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(38, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(12, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Semana:"
        '
        'cmbSemanaNomina
        '
        Me.cmbSemanaNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSemanaNomina.FormattingEnabled = True
        Me.cmbSemanaNomina.Location = New System.Drawing.Point(101, 110)
        Me.cmbSemanaNomina.Name = "cmbSemanaNomina"
        Me.cmbSemanaNomina.Size = New System.Drawing.Size(466, 21)
        Me.cmbSemanaNomina.TabIndex = 43
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(632, 112)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(586, 112)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodo.Location = New System.Drawing.Point(12, 79)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(53, 15)
        Me.lblPeriodo.TabIndex = 5
        Me.lblPeriodo.Text = "Periodo:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblNave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNave.Location = New System.Drawing.Point(11, 55)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(38, 15)
        Me.lblNave.TabIndex = 4
        Me.lblNave.Text = "Nave:"
        '
        'lblConceptoPeriodo
        '
        Me.lblConceptoPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblConceptoPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblConceptoPeriodo.Location = New System.Drawing.Point(101, 80)
        Me.lblConceptoPeriodo.Name = "lblConceptoPeriodo"
        Me.lblConceptoPeriodo.Size = New System.Drawing.Size(500, 15)
        Me.lblConceptoPeriodo.TabIndex = 1
        Me.lblConceptoPeriodo.Text = "CAJA DE AHORRO CORRESPONDIENTE AL PERIODO 01/ENE/2012 - 31/DIC/2013"
        '
        'lblRegresar
        '
        Me.lblRegresar.AutoSize = True
        Me.lblRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegresar.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegresar.Location = New System.Drawing.Point(154, 38)
        Me.lblRegresar.Name = "lblRegresar"
        Me.lblRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblRegresar.TabIndex = 39
        Me.lblRegresar.Text = "Cerrar"
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.cancelar_32
        Me.btnRegresar.Location = New System.Drawing.Point(154, 6)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 36
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.Panel2)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 531)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(740, 60)
        Me.pnlEstado.TabIndex = 40
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnRegresar)
        Me.Panel2.Controls.Add(Me.lblRegresar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(540, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 60)
        Me.Panel2.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(217, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 28
        Me.pcbTitulo.TabStop = False
        '
        'ReporteCierreSemanalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(740, 591)
        Me.Controls.Add(Me.grdCierreSemanal)
        Me.Controls.Add(Me.grbCierreSemanal)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReporteCierreSemanalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Cierre Semanal"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.onlTitulo.ResumeLayout(False)
        Me.onlTitulo.PerformLayout()
        CType(Me.grdCierreSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCierreSemanal.ResumeLayout(False)
        Me.grbCierreSemanal.PerformLayout()
        Me.pnlMinimizar.ResumeLayout(False)
        Me.pnlEstado.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents grdCierreSemanal As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents grbCierreSemanal As System.Windows.Forms.GroupBox
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblConceptoPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblRegresar As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSemanaNomina As System.Windows.Forms.ComboBox
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlMinimizar As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblNombreNave As System.Windows.Forms.Label
    Friend WithEvents onlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As PictureBox
End Class
