<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm
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
        Me.grbRegistroDias = New System.Windows.Forms.GroupBox()
        Me.chboxEntradaParPorPar = New System.Windows.Forms.CheckBox()
        Me.chboxSalidaparporpar = New System.Windows.Forms.CheckBox()
        Me.pnlAltaDias = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cmbUCLientes = New Infragistics.Win.UltraWinGrid.UltraCombo()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.grbRegistroDias.SuspendLayout()
        Me.pnlAltaDias.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.cmbUCLientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbRegistroDias
        '
        Me.grbRegistroDias.Controls.Add(Me.chboxEntradaParPorPar)
        Me.grbRegistroDias.Controls.Add(Me.chboxSalidaparporpar)
        Me.grbRegistroDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbRegistroDias.Location = New System.Drawing.Point(77, 157)
        Me.grbRegistroDias.Name = "grbRegistroDias"
        Me.grbRegistroDias.Size = New System.Drawing.Size(365, 49)
        Me.grbRegistroDias.TabIndex = 18
        Me.grbRegistroDias.TabStop = False
        Me.grbRegistroDias.Text = "Validar embarque par por par"
        '
        'chboxEntradaParPorPar
        '
        Me.chboxEntradaParPorPar.AutoSize = True
        Me.chboxEntradaParPorPar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chboxEntradaParPorPar.Location = New System.Drawing.Point(111, 23)
        Me.chboxEntradaParPorPar.Name = "chboxEntradaParPorPar"
        Me.chboxEntradaParPorPar.Size = New System.Drawing.Size(63, 17)
        Me.chboxEntradaParPorPar.TabIndex = 4
        Me.chboxEntradaParPorPar.Text = "Entrada"
        Me.chboxEntradaParPorPar.UseVisualStyleBackColor = True
        '
        'chboxSalidaparporpar
        '
        Me.chboxSalidaparporpar.AutoSize = True
        Me.chboxSalidaparporpar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chboxSalidaparporpar.Location = New System.Drawing.Point(13, 23)
        Me.chboxSalidaparporpar.Name = "chboxSalidaparporpar"
        Me.chboxSalidaparporpar.Size = New System.Drawing.Size(55, 17)
        Me.chboxSalidaparporpar.TabIndex = 3
        Me.chboxSalidaparporpar.Text = "Salida"
        Me.chboxSalidaparporpar.UseVisualStyleBackColor = True
        '
        'pnlAltaDias
        '
        Me.pnlAltaDias.BackColor = System.Drawing.Color.White
        Me.pnlAltaDias.Controls.Add(Me.imgLogo)
        Me.pnlAltaDias.Controls.Add(Me.lblEncabezado)
        Me.pnlAltaDias.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAltaDias.Location = New System.Drawing.Point(0, 0)
        Me.pnlAltaDias.Name = "pnlAltaDias"
        Me.pnlAltaDias.Size = New System.Drawing.Size(474, 60)
        Me.pnlAltaDias.TabIndex = 17
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(90, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(300, 20)
        Me.lblEncabezado.TabIndex = 47
        Me.lblEncabezado.Text = "Configuración de Entradas y Salidas"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(28, 129)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(43, 13)
        Me.lblCliente.TabIndex = 23
        Me.lblCliente.Text = "*Cliente"
        '
        'cmbNaves
        '
        Me.cmbNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(77, 87)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(369, 21)
        Me.cmbNaves.TabIndex = 1
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(28, 90)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(37, 13)
        Me.lblNave.TabIndex = 21
        Me.lblNave.Text = "*Nave"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.White
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.lblBuscar)
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 224)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(474, 61)
        Me.pnlAcciones.TabIndex = 25
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(422, 41)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(35, 13)
        Me.lblLimpiar.TabIndex = 24
        Me.lblLimpiar.Text = "Cerrar"
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(354, 41)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(45, 13)
        Me.lblBuscar.TabIndex = 23
        Me.lblBuscar.Text = "Guardar"
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(423, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackgroundImage = Global.Almacen.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(358, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cmbUCLientes
        '
        Me.cmbUCLientes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.cmbUCLientes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.cmbUCLientes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.cmbUCLientes.Location = New System.Drawing.Point(77, 123)
        Me.cmbUCLientes.Name = "cmbUCLientes"
        Me.cmbUCLientes.Size = New System.Drawing.Size(369, 22)
        Me.cmbUCLientes.TabIndex = 2
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(404, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 60)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 48
        Me.imgLogo.TabStop = False
        '
        'Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(474, 285)
        Me.Controls.Add(Me.cmbUCLientes)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.cmbNaves)
        Me.Controls.Add(Me.lblNave)
        Me.Controls.Add(Me.grbRegistroDias)
        Me.Controls.Add(Me.pnlAltaDias)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Agregar_o_Editar_ConfiguracionEmbarquesParPorParForm"
        Me.Text = "Configuración de Entradas y Salidas"
        Me.grbRegistroDias.ResumeLayout(False)
        Me.grbRegistroDias.PerformLayout()
        Me.pnlAltaDias.ResumeLayout(False)
        Me.pnlAltaDias.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.cmbUCLientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbRegistroDias As System.Windows.Forms.GroupBox
    Friend WithEvents pnlAltaDias As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents chboxEntradaParPorPar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxSalidaparporpar As System.Windows.Forms.CheckBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbUCLientes As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents imgLogo As PictureBox
End Class
