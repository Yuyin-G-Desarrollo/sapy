<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CierreSemanalForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CierreSemanalForm))
        Me.grdCierreSemanal = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grbCierreSemanal = New System.Windows.Forms.GroupBox()
        Me.cmbPeriodosNomina = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblConceptoSemNomina = New System.Windows.Forms.Label()
        Me.lblSemanaNomina = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblNombreNave = New System.Windows.Forms.Label()
        Me.lblConceptoPeriodo = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.lblBúscar = New System.Windows.Forms.Label()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.lblRegresar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        CType(Me.grdCierreSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCierreSemanal.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCierreSemanal
        '
        Me.grdCierreSemanal.AllowEditing = False
        Me.grdCierreSemanal.AllowFiltering = True
        Me.grdCierreSemanal.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
        Me.grdCierreSemanal.ColumnInfo = resources.GetString("grdCierreSemanal.ColumnInfo")
        Me.grdCierreSemanal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCierreSemanal.ExtendLastCol = True
        Me.grdCierreSemanal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grdCierreSemanal.Location = New System.Drawing.Point(0, 218)
        Me.grdCierreSemanal.Name = "grdCierreSemanal"
        Me.grdCierreSemanal.Rows.Count = 6
        Me.grdCierreSemanal.Rows.DefaultSize = 19
        Me.grdCierreSemanal.Size = New System.Drawing.Size(688, 244)
        Me.grdCierreSemanal.StyleInfo = resources.GetString("grdCierreSemanal.StyleInfo")
        Me.grdCierreSemanal.TabIndex = 2
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.txtBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBuscar.Location = New System.Drawing.Point(90, 127)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(280, 20)
        Me.txtBuscar.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.candado
        Me.btnGuardar.Location = New System.Drawing.Point(78, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'grbCierreSemanal
        '
        Me.grbCierreSemanal.BackColor = System.Drawing.Color.Transparent
        Me.grbCierreSemanal.Controls.Add(Me.cmbPeriodosNomina)
        Me.grbCierreSemanal.Controls.Add(Me.cmbNave)
        Me.grbCierreSemanal.Controls.Add(Me.txtBuscar)
        Me.grbCierreSemanal.Controls.Add(Me.lblBuscar)
        Me.grbCierreSemanal.Controls.Add(Me.lblConceptoSemNomina)
        Me.grbCierreSemanal.Controls.Add(Me.lblSemanaNomina)
        Me.grbCierreSemanal.Controls.Add(Me.lblPeriodo)
        Me.grbCierreSemanal.Controls.Add(Me.lblNave)
        Me.grbCierreSemanal.Controls.Add(Me.lblNombreNave)
        Me.grbCierreSemanal.Controls.Add(Me.lblConceptoPeriodo)
        Me.grbCierreSemanal.Controls.Add(Me.Panel3)
        Me.grbCierreSemanal.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbCierreSemanal.Location = New System.Drawing.Point(0, 59)
        Me.grbCierreSemanal.Name = "grbCierreSemanal"
        Me.grbCierreSemanal.Size = New System.Drawing.Size(688, 159)
        Me.grbCierreSemanal.TabIndex = 1
        Me.grbCierreSemanal.TabStop = False
        '
        'cmbPeriodosNomina
        '
        Me.cmbPeriodosNomina.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbPeriodosNomina.FormattingEnabled = True
        Me.cmbPeriodosNomina.Location = New System.Drawing.Point(86, 100)
        Me.cmbPeriodosNomina.Name = "cmbPeriodosNomina"
        Me.cmbPeriodosNomina.Size = New System.Drawing.Size(474, 21)
        Me.cmbPeriodosNomina.TabIndex = 46
        '
        'cmbNave
        '
        Me.cmbNave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(86, 49)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(150, 21)
        Me.cmbNave.TabIndex = 45
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblBuscar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBuscar.Location = New System.Drawing.Point(7, 127)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(78, 15)
        Me.lblBuscar.TabIndex = 8
        Me.lblBuscar.Text = "Colaborador:"
        '
        'lblConceptoSemNomina
        '
        Me.lblConceptoSemNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblConceptoSemNomina.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblConceptoSemNomina.Location = New System.Drawing.Point(87, 105)
        Me.lblConceptoSemNomina.Name = "lblConceptoSemNomina"
        Me.lblConceptoSemNomina.Size = New System.Drawing.Size(456, 15)
        Me.lblConceptoSemNomina.TabIndex = 7
        Me.lblConceptoSemNomina.Text = "NOMINA CORRESPONDIENTE AL PERIODO 14/AGO/2013 - 20/AGO/2013"
        '
        'lblSemanaNomina
        '
        Me.lblSemanaNomina.AutoSize = True
        Me.lblSemanaNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblSemanaNomina.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSemanaNomina.Location = New System.Drawing.Point(7, 105)
        Me.lblSemanaNomina.Name = "lblSemanaNomina"
        Me.lblSemanaNomina.Size = New System.Drawing.Size(57, 15)
        Me.lblSemanaNomina.TabIndex = 6
        Me.lblSemanaNomina.Text = "Semana:"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodo.Location = New System.Drawing.Point(7, 80)
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
        Me.lblNave.Location = New System.Drawing.Point(7, 55)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(38, 15)
        Me.lblNave.TabIndex = 4
        Me.lblNave.Text = "Nave:"
        '
        'lblNombreNave
        '
        Me.lblNombreNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNombreNave.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreNave.Location = New System.Drawing.Point(87, 55)
        Me.lblNombreNave.Name = "lblNombreNave"
        Me.lblNombreNave.Size = New System.Drawing.Size(149, 15)
        Me.lblNombreNave.TabIndex = 3
        Me.lblNombreNave.Text = "COMERCIALIZADORA DE SUELAS"
        Me.lblNombreNave.Visible = False
        '
        'lblConceptoPeriodo
        '
        Me.lblConceptoPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblConceptoPeriodo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblConceptoPeriodo.Location = New System.Drawing.Point(87, 80)
        Me.lblConceptoPeriodo.Name = "lblConceptoPeriodo"
        Me.lblConceptoPeriodo.Size = New System.Drawing.Size(547, 15)
        Me.lblConceptoPeriodo.TabIndex = 1
        Me.lblConceptoPeriodo.Text = "CAJA DE AHORRO CORRESPONDIENTE AL PERIODO 01/ENE/2012 - 31/DIC/2013"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnAbajo)
        Me.Panel3.Controls.Add(Me.lblBúscar)
        Me.Panel3.Controls.Add(Me.btnArriba)
        Me.Panel3.Controls.Add(Me.lblLimpiar)
        Me.Panel3.Controls.Add(Me.btnLimpiar)
        Me.Panel3.Controls.Add(Me.btnBuscar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(566, 16)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(119, 140)
        Me.Panel3.TabIndex = 43
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(90, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'lblBúscar
        '
        Me.lblBúscar.AutoSize = True
        Me.lblBúscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBúscar.Location = New System.Drawing.Point(15, 121)
        Me.lblBúscar.Name = "lblBúscar"
        Me.lblBúscar.Size = New System.Drawing.Size(49, 15)
        Me.lblBúscar.TabIndex = 40
        Me.lblBúscar.Text = "Mostrar"
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(66, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(69, 122)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(49, 15)
        Me.lblLimpiar.TabIndex = 39
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.Location = New System.Drawing.Point(78, 89)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 2
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(23, 88)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(2, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(282, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Cierre Semanal de Caja de Ahorro"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(688, 59)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(339, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(349, 59)
        Me.pnlTitulo.TabIndex = 28
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(56, 39)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(75, 13)
        Me.lblGuardar.TabIndex = 31
        Me.lblGuardar.Text = "Cerrar semana"
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(148, 6)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 3
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'lblRegresar
        '
        Me.lblRegresar.AutoSize = True
        Me.lblRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRegresar.Location = New System.Drawing.Point(146, 41)
        Me.lblRegresar.Name = "lblRegresar"
        Me.lblRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblRegresar.TabIndex = 32
        Me.lblRegresar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 462)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(688, 60)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.lblGuardar)
        Me.Panel2.Controls.Add(Me.lblRegresar)
        Me.Panel2.Controls.Add(Me.btnRegresar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(488, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 60)
        Me.Panel2.TabIndex = 0
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(281, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 28
        Me.pcbTitulo.TabStop = False
        '
        'CierreSemanalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(688, 522)
        Me.Controls.Add(Me.grdCierreSemanal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbCierreSemanal)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "CierreSemanalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre Semanal de Caja de Ahorro"
        CType(Me.grdCierreSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCierreSemanal.ResumeLayout(False)
        Me.grbCierreSemanal.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdCierreSemanal As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents grbCierreSemanal As System.Windows.Forms.GroupBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblConceptoSemNomina As System.Windows.Forms.Label
    Friend WithEvents lblSemanaNomina As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblNombreNave As System.Windows.Forms.Label
    Friend WithEvents lblConceptoPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents lblRegresar As System.Windows.Forms.Label
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents lblBúscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPeriodosNomina As System.Windows.Forms.ComboBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
