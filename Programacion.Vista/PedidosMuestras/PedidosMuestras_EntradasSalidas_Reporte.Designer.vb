<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosMuestras_EntradasSalidas_Reporte
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
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdFolios = New DevExpress.XtraGrid.GridControl()
        Me.GrdVFolios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtmFechaFinEnvio = New System.Windows.Forms.DateTimePicker()
        Me.dtmFechaInicioEnvio = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbNaveMenu = New System.Windows.Forms.ComboBox()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblFolioSeleccionado = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.lblcedis = New System.Windows.Forms.Label()
        Me.txtnombrecedis = New System.Windows.Forms.TextBox()
        Me.groupContenedor.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdVFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupContenedor
        '
        Me.groupContenedor.Controls.Add(Me.Panel1)
        Me.groupContenedor.Controls.Add(Me.GroupBox1)
        Me.groupContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupContenedor.Location = New System.Drawing.Point(0, 60)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(862, 417)
        Me.groupContenedor.TabIndex = 20
        Me.groupContenedor.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdFolios)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 73)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(856, 341)
        Me.Panel1.TabIndex = 22
        '
        'grdFolios
        '
        Me.grdFolios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolios.Location = New System.Drawing.Point(0, 0)
        Me.grdFolios.MainView = Me.GrdVFolios
        Me.grdFolios.Name = "grdFolios"
        Me.grdFolios.Size = New System.Drawing.Size(856, 341)
        Me.grdFolios.TabIndex = 0
        Me.grdFolios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdVFolios})
        '
        'GrdVFolios
        '
        Me.GrdVFolios.GridControl = Me.grdFolios
        Me.GrdVFolios.Name = "GrdVFolios"
        Me.GrdVFolios.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtnombrecedis)
        Me.GroupBox1.Controls.Add(Me.lblcedis)
        Me.GroupBox1.Controls.Add(Me.dtmFechaFinEnvio)
        Me.GroupBox1.Controls.Add(Me.dtmFechaInicioEnvio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbNaveMenu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(856, 57)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'dtmFechaFinEnvio
        '
        Me.dtmFechaFinEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaFinEnvio.Location = New System.Drawing.Point(252, 14)
        Me.dtmFechaFinEnvio.Name = "dtmFechaFinEnvio"
        Me.dtmFechaFinEnvio.Size = New System.Drawing.Size(87, 20)
        Me.dtmFechaFinEnvio.TabIndex = 2
        '
        'dtmFechaInicioEnvio
        '
        Me.dtmFechaInicioEnvio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaInicioEnvio.Location = New System.Drawing.Point(86, 14)
        Me.dtmFechaInicioEnvio.Name = "dtmFechaInicioEnvio"
        Me.dtmFechaInicioEnvio.Size = New System.Drawing.Size(87, 20)
        Me.dtmFechaInicioEnvio.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(192, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "*Fin Envío"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "* Inicio Envío"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(359, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 126
        Me.Label3.Text = "* Nave"
        '
        'cmbNaveMenu
        '
        Me.cmbNaveMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNaveMenu.FormattingEnabled = True
        Me.cmbNaveMenu.Location = New System.Drawing.Point(405, 14)
        Me.cmbNaveMenu.Name = "cmbNaveMenu"
        Me.cmbNaveMenu.Size = New System.Drawing.Size(209, 21)
        Me.cmbNaveMenu.TabIndex = 3
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblFolioSeleccionado)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Controls.Add(Me.Label12)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 477)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(862, 60)
        Me.pnlEstado.TabIndex = 19
        '
        'lblFolioSeleccionado
        '
        Me.lblFolioSeleccionado.AutoSize = True
        Me.lblFolioSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioSeleccionado.ForeColor = System.Drawing.Color.Black
        Me.lblFolioSeleccionado.Location = New System.Drawing.Point(233, 21)
        Me.lblFolioSeleccionado.Name = "lblFolioSeleccionado"
        Me.lblFolioSeleccionado.Size = New System.Drawing.Size(13, 16)
        Me.lblFolioSeleccionado.TabIndex = 150
        Me.lblFolioSeleccionado.Text = "-"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.Label1)
        Me.pnlOperaciones.Controls.Add(Me.Label7)
        Me.pnlOperaciones.Controls.Add(Me.btnLimpiar)
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnMostrar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnImprimir)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(585, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(277, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(126, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Mostrar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label7.Location = New System.Drawing.Point(177, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(178, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(226, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(74, 43)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(42, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Imprimir"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(129, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 5
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(226, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(77, 8)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 4
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(210, 16)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Folio de Envío seleccionado:"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(862, 60)
        Me.pnlHeader.TabIndex = 18
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(516, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(346, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(39, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(238, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Reporte - Envío de Muestras"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(277, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'lblcedis
        '
        Me.lblcedis.AutoSize = True
        Me.lblcedis.Location = New System.Drawing.Point(632, 17)
        Me.lblcedis.Name = "lblcedis"
        Me.lblcedis.Size = New System.Drawing.Size(40, 13)
        Me.lblcedis.TabIndex = 129
        Me.lblcedis.Text = "* Cedis"
        '
        'txtnombrecedis
        '
        Me.txtnombrecedis.Location = New System.Drawing.Point(675, 15)
        Me.txtnombrecedis.Name = "txtnombrecedis"
        Me.txtnombrecedis.ReadOnly = True
        Me.txtnombrecedis.Size = New System.Drawing.Size(165, 20)
        Me.txtnombrecedis.TabIndex = 130
        Me.txtnombrecedis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PedidosMuestras_EntradasSalidas_Reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 537)
        Me.Controls.Add(Me.groupContenedor)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PedidosMuestras_EntradasSalidas_Reporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reporte - Envío de Muestras"
        Me.groupContenedor.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdFolios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdVFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupContenedor As GroupBox
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents lblFolioSeleccionado As Label
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbNaveMenu As ComboBox
    Friend WithEvents dtmFechaFinEnvio As DateTimePicker
    Friend WithEvents dtmFechaInicioEnvio As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdFolios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GrdVFolios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblcedis As Label
    Friend WithEvents txtnombrecedis As TextBox
End Class
