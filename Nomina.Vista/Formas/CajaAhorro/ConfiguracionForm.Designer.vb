<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionForm))
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grbConfiguracion = New System.Windows.Forms.GroupBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblNombreNave = New System.Windows.Forms.Label()
        Me.lblConceptoPeriodo = New System.Windows.Forms.Label()
        Me.lblRegresar = New System.Windows.Forms.Label()
        Me.grdConfiguracion = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.lblEjemplo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbConfiguracion.SuspendLayout()
        CType(Me.grdConfiguracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(95, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 17
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlHeader)
        Me.pnlEncabezado.Controls.Add(Me.imgLogo)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(544, 59)
        Me.pnlEncabezado.TabIndex = 13
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.lblNuevo)
        Me.pnlHeader.Controls.Add(Me.btnCopiar)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(544, 59)
        Me.pnlHeader.TabIndex = 20
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.Label1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(95, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(449, 59)
        Me.pnlTitulo.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(31, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Configuración  de Interés de Caja de Ahorro"
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblNuevo.Location = New System.Drawing.Point(20, 40)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(37, 13)
        Me.lblNuevo.TabIndex = 21
        Me.lblNuevo.Text = "Copiar"
        '
        'btnCopiar
        '
        Me.btnCopiar.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCopiar.Image = Global.Nomina.Vista.My.Resources.Resources.copiar_32
        Me.btnCopiar.Location = New System.Drawing.Point(22, 7)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiar.TabIndex = 20
        Me.btnCopiar.UseVisualStyleBackColor = False
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(404, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(125, 55)
        Me.imgLogo.TabIndex = 19
        Me.imgLogo.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(281, 58)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(245, 20)
        Me.lblTitulo.TabIndex = 9
        Me.lblTitulo.Text = "Configuracion Caja de Ahorro"
        '
        'grbConfiguracion
        '
        Me.grbConfiguracion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbConfiguracion.BackColor = System.Drawing.Color.Transparent
        Me.grbConfiguracion.Controls.Add(Me.lblPeriodo)
        Me.grbConfiguracion.Controls.Add(Me.lblNave)
        Me.grbConfiguracion.Controls.Add(Me.lblNombreNave)
        Me.grbConfiguracion.Controls.Add(Me.lblConceptoPeriodo)
        Me.grbConfiguracion.Location = New System.Drawing.Point(0, 58)
        Me.grbConfiguracion.Name = "grbConfiguracion"
        Me.grbConfiguracion.Size = New System.Drawing.Size(533, 68)
        Me.grbConfiguracion.TabIndex = 14
        Me.grbConfiguracion.TabStop = False
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblPeriodo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblPeriodo.Location = New System.Drawing.Point(6, 40)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(50, 15)
        Me.lblPeriodo.TabIndex = 5
        Me.lblPeriodo.Text = "Periodo"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.lblNave.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblNave.Location = New System.Drawing.Point(6, 16)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(35, 15)
        Me.lblNave.TabIndex = 4
        Me.lblNave.Text = "Nave"
        '
        'lblNombreNave
        '
        Me.lblNombreNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblNombreNave.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNombreNave.Location = New System.Drawing.Point(63, 16)
        Me.lblNombreNave.Name = "lblNombreNave"
        Me.lblNombreNave.Size = New System.Drawing.Size(317, 15)
        Me.lblNombreNave.TabIndex = 3
        Me.lblNombreNave.Text = "COMERCIALIZADORA DE SUELAS"
        '
        'lblConceptoPeriodo
        '
        Me.lblConceptoPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold)
        Me.lblConceptoPeriodo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblConceptoPeriodo.Location = New System.Drawing.Point(63, 40)
        Me.lblConceptoPeriodo.Name = "lblConceptoPeriodo"
        Me.lblConceptoPeriodo.Size = New System.Drawing.Size(466, 15)
        Me.lblConceptoPeriodo.TabIndex = 1
        Me.lblConceptoPeriodo.Text = "CAJA DE AHORRO CORRESPONDIENTE AL PERIODO 01/ENE/2012 - 31/DIC/2013"
        '
        'lblRegresar
        '
        Me.lblRegresar.AutoSize = True
        Me.lblRegresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegresar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRegresar.Location = New System.Drawing.Point(156, 40)
        Me.lblRegresar.Name = "lblRegresar"
        Me.lblRegresar.Size = New System.Drawing.Size(35, 13)
        Me.lblRegresar.TabIndex = 18
        Me.lblRegresar.Text = "Cerrar"
        '
        'grdConfiguracion
        '
        Me.grdConfiguracion.AllowEditing = False
        Me.grdConfiguracion.AllowFiltering = True
        Me.grdConfiguracion.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
        Me.grdConfiguracion.ColumnInfo = resources.GetString("grdConfiguracion.ColumnInfo")
        Me.grdConfiguracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.grdConfiguracion.Location = New System.Drawing.Point(8, 132)
        Me.grdConfiguracion.Name = "grdConfiguracion"
        Me.grdConfiguracion.Rows.Count = 6
        Me.grdConfiguracion.Rows.DefaultSize = 19
        Me.grdConfiguracion.Rows.Fixed = 2
        Me.grdConfiguracion.Size = New System.Drawing.Size(372, 145)
        Me.grdConfiguracion.StyleInfo = resources.GetString("grdConfiguracion.StyleInfo")
        Me.grdConfiguracion.TabIndex = 19
        '
        'lblEjemplo
        '
        Me.lblEjemplo.Location = New System.Drawing.Point(3, 28)
        Me.lblEjemplo.Name = "lblEjemplo"
        Me.lblEjemplo.Size = New System.Drawing.Size(138, 75)
        Me.lblEjemplo.TabIndex = 20
        Me.lblEjemplo.Text = "  Inicio     Fin     Interés (%)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    0           2           50 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    3         " &
    "  6           40" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    7          10          30    " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   11         52          2" &
    "5 "
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 288)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(544, 60)
        Me.pnlEstado.TabIndex = 21
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblRegresar)
        Me.pnlAcciones.Controls.Add(Me.btnRegresar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(344, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(200, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Nomina.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(101, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 16
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.btnRegresar.Location = New System.Drawing.Point(157, 7)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(32, 32)
        Me.btnRegresar.TabIndex = 15
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Ejemplo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblEjemplo)
        Me.GroupBox1.Location = New System.Drawing.Point(385, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(142, 116)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(381, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 28
        Me.pcbTitulo.TabStop = False
        '
        'ConfiguracionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(544, 348)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.grdConfiguracion)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.grbConfiguracion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(550, 370)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(550, 370)
        Me.Name = "ConfiguracionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración  de Interés de Caja de Ahorro"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbConfiguracion.ResumeLayout(False)
        Me.grbConfiguracion.PerformLayout()
        CType(Me.grdConfiguracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grbConfiguracion As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreNave As System.Windows.Forms.Label
    Friend WithEvents lblConceptoPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblRegresar As System.Windows.Forms.Label
    Friend WithEvents grdConfiguracion As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEjemplo As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents btnCopiar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pcbTitulo As PictureBox
End Class
