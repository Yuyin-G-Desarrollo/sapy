<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionSolicitudNominaForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionSolicitudNominaForm))
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
        Me.gpbFiltroSolicitudes = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSemana = New System.Windows.Forms.TextBox()
        Me.lblSemana = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.grdSolicitudes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.gpbFiltroSolicitudes.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(884, 59)
        Me.pnlHeader.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pcbTitulo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(460, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(424, 59)
        Me.Panel1.TabIndex = 47
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(3, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(357, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Configuración Solicitud a Finanzas Nómina "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 464)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(884, 63)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblGuardar)
        Me.Panel3.Controls.Add(Me.btnGuardar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(786, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(46, 63)
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
        Me.Panel7.Location = New System.Drawing.Point(832, 0)
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
        'gpbFiltroSolicitudes
        '
        Me.gpbFiltroSolicitudes.Controls.Add(Me.lblFecha)
        Me.gpbFiltroSolicitudes.Controls.Add(Me.Label1)
        Me.gpbFiltroSolicitudes.Controls.Add(Me.txtSemana)
        Me.gpbFiltroSolicitudes.Controls.Add(Me.lblSemana)
        Me.gpbFiltroSolicitudes.Controls.Add(Me.Panel10)
        Me.gpbFiltroSolicitudes.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltroSolicitudes.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltroSolicitudes.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltroSolicitudes.Name = "gpbFiltroSolicitudes"
        Me.gpbFiltroSolicitudes.Size = New System.Drawing.Size(884, 91)
        Me.gpbFiltroSolicitudes.TabIndex = 24
        Me.gpbFiltroSolicitudes.TabStop = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblFecha.Location = New System.Drawing.Point(114, 58)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(51, 16)
        Me.lblFecha.TabIndex = 51
        Me.lblFecha.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Fecha Modificación"
        '
        'txtSemana
        '
        Me.txtSemana.Location = New System.Drawing.Point(68, 19)
        Me.txtSemana.Name = "txtSemana"
        Me.txtSemana.Size = New System.Drawing.Size(130, 20)
        Me.txtSemana.TabIndex = 49
        Me.txtSemana.Visible = False
        '
        'lblSemana
        '
        Me.lblSemana.AutoSize = True
        Me.lblSemana.Location = New System.Drawing.Point(16, 22)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(46, 13)
        Me.lblSemana.TabIndex = 48
        Me.lblSemana.Text = "Semana"
        Me.lblSemana.Visible = False
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnFiltrarSolicitud)
        Me.Panel10.Controls.Add(Me.lblBuscar)
        Me.Panel10.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(718, 16)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(101, 72)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(58, 49)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(12, 18)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 4
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(7, 49)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.BackgroundImage = Global.Nomina.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(62, 18)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 5
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(819, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(62, 72)
        Me.pnlMinimizarParametros.TabIndex = 44
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'grdSolicitudes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudes.DisplayLayout.Appearance = Appearance1
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSolicitudes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdSolicitudes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitudes.Location = New System.Drawing.Point(0, 150)
        Me.grdSolicitudes.Name = "grdSolicitudes"
        Me.grdSolicitudes.Size = New System.Drawing.Size(884, 314)
        Me.grdSolicitudes.TabIndex = 25
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(356, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 46
        Me.pcbTitulo.TabStop = False
        '
        'ConfiguracionSolicitudNominaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(884, 527)
        Me.Controls.Add(Me.grdSolicitudes)
        Me.Controls.Add(Me.gpbFiltroSolicitudes)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ConfiguracionSolicitudNominaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.gpbFiltroSolicitudes.ResumeLayout(False)
        Me.gpbFiltroSolicitudes.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents gpbFiltroSolicitudes As System.Windows.Forms.GroupBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents grdSolicitudes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblSemana As System.Windows.Forms.Label
    Friend WithEvents txtSemana As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As PictureBox
End Class
