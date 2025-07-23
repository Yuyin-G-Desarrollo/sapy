<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_ImportacionCalendarioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Programacion_ImportacionCalendarioForm))
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudAnio = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlGenerar = New System.Windows.Forms.Panel()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlDescargar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlImportar = New System.Windows.Forms.Panel()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.dgDatos = New DevExpress.XtraGrid.GridControl()
        Me.dgVDatos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bntCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.UltraPanel1.ClientArea.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlGenerar.SuspendLayout()
        Me.pnlDescargar.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgVDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.Controls.Add(Me.Panel3)
        Me.pnlFiltros.Controls.Add(Me.GroupBox1)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 102)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(800, 78)
        Me.pnlFiltros.TabIndex = 15
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnMostrar)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(679, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(121, 78)
        Me.Panel3.TabIndex = 1
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(42, 15)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 10
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(38, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Mostrar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudAnio)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(213, 60)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'nudAnio
        '
        Me.nudAnio.Location = New System.Drawing.Point(59, 20)
        Me.nudAnio.Maximum = New Decimal(New Integer() {2030, 0, 0, 0})
        Me.nudAnio.Minimum = New Decimal(New Integer() {2020, 0, 0, 0})
        Me.nudAnio.Name = "nudAnio"
        Me.nudAnio.Size = New System.Drawing.Size(76, 20)
        Me.nudAnio.TabIndex = 5
        Me.nudAnio.Value = New Decimal(New Integer() {2020, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Año:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel4.Controls.Add(Me.UltraPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 71)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(800, 31)
        Me.Panel4.TabIndex = 14
        '
        'UltraPanel1
        '
        '
        'UltraPanel1.ClientArea
        '
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnAbajo)
        Me.UltraPanel1.ClientArea.Controls.Add(Me.btnArriba)
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.UltraPanel1.Location = New System.Drawing.Point(679, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(121, 31)
        Me.UltraPanel1.TabIndex = 0
        '
        'btnAbajo
        '
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.Image = Global.Programacion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(71, 6)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(23, 20)
        Me.btnAbajo.TabIndex = 15
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.Image = Global.Programacion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(44, 6)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(21, 20)
        Me.btnArriba.TabIndex = 14
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlGenerar)
        Me.pnlHeader.Controls.Add(Me.pnlDescargar)
        Me.pnlHeader.Controls.Add(Me.pnlImportar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(800, 71)
        Me.pnlHeader.TabIndex = 12
        '
        'pnlGenerar
        '
        Me.pnlGenerar.Controls.Add(Me.btnGenerar)
        Me.pnlGenerar.Controls.Add(Me.Label3)
        Me.pnlGenerar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGenerar.Location = New System.Drawing.Point(146, 0)
        Me.pnlGenerar.Name = "pnlGenerar"
        Me.pnlGenerar.Size = New System.Drawing.Size(73, 71)
        Me.pnlGenerar.TabIndex = 4
        '
        'btnGenerar
        '
        Me.btnGenerar.Image = Global.Programacion.Vista.My.Resources.Resources.catalogos_32
        Me.btnGenerar.Location = New System.Drawing.Point(21, 3)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerar.TabIndex = 8
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(17, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Generar"
        '
        'pnlDescargar
        '
        Me.pnlDescargar.Controls.Add(Me.btnExportar)
        Me.pnlDescargar.Controls.Add(Me.Label2)
        Me.pnlDescargar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescargar.Location = New System.Drawing.Point(73, 0)
        Me.pnlDescargar.Name = "pnlDescargar"
        Me.pnlDescargar.Size = New System.Drawing.Size(73, 71)
        Me.pnlDescargar.TabIndex = 3
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.ordenar
        Me.btnExportar.Location = New System.Drawing.Point(22, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 6
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(11, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 26)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descargar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Formato"
        '
        'pnlImportar
        '
        Me.pnlImportar.Controls.Add(Me.btnImportar)
        Me.pnlImportar.Controls.Add(Me.lblEditar)
        Me.pnlImportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlImportar.Name = "pnlImportar"
        Me.pnlImportar.Size = New System.Drawing.Size(73, 71)
        Me.pnlImportar.TabIndex = 2
        '
        'btnImportar
        '
        Me.btnImportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnImportar.Location = New System.Drawing.Point(21, 3)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(32, 32)
        Me.btnImportar.TabIndex = 4
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(17, 38)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(45, 13)
        Me.lblEditar.TabIndex = 5
        Me.lblEditar.Text = "Importar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label4)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(504, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 71)
        Me.pnlTitulo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(77, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Calendario PPCP"
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(5, 47)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(217, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Importación Días Festivos"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = CType(resources.GetObject("pcbTitulo.Image"), System.Drawing.Image)
        Me.pcbTitulo.Location = New System.Drawing.Point(228, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 71)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'dgDatos
        '
        Me.dgDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgDatos.Location = New System.Drawing.Point(0, 0)
        Me.dgDatos.MainView = Me.dgVDatos
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.Size = New System.Drawing.Size(800, 390)
        Me.dgDatos.TabIndex = 11
        Me.dgDatos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.dgVDatos})
        '
        'dgVDatos
        '
        Me.dgVDatos.GridControl = Me.dgDatos
        Me.dgVDatos.Name = "dgVDatos"
        Me.dgVDatos.OptionsMenu.EnableColumnMenu = False
        Me.dgVDatos.OptionsSelection.InvertSelection = True
        Me.dgVDatos.OptionsSelection.MultiSelect = True
        Me.dgVDatos.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.dgVDatos.OptionsView.ShowAutoFilterRow = True
        Me.dgVDatos.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 390)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 60)
        Me.Panel1.TabIndex = 13
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.Label1)
        Me.pnlBotones.Controls.Add(Me.bntCerrar)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(554, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(140, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(136, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Guardar"
        '
        'bntCerrar
        '
        Me.bntCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.bntCerrar.Location = New System.Drawing.Point(196, 7)
        Me.bntCerrar.Name = "bntCerrar"
        Me.bntCerrar.Size = New System.Drawing.Size(32, 32)
        Me.bntCerrar.TabIndex = 0
        Me.bntCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'Programacion_ImportacionCalendario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.dgDatos)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Programacion_ImportacionCalendario"
        Me.Text = "Programacion_ImportacionCalendario"
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.UltraPanel1.ClientArea.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlGenerar.ResumeLayout(False)
        Me.pnlGenerar.PerformLayout()
        Me.pnlDescargar.ResumeLayout(False)
        Me.pnlDescargar.PerformLayout()
        Me.pnlImportar.ResumeLayout(False)
        Me.pnlImportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgVDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlFiltros As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nudAnio As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlGenerar As Panel
    Friend WithEvents btnGenerar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlDescargar As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlImportar As Panel
    Friend WithEvents btnImportar As Button
    Friend WithEvents lblEditar As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents dgDatos As DevExpress.XtraGrid.GridControl
    Friend WithEvents dgVDatos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents bntCerrar As Button
    Friend WithEvents lblCerrar As Label
End Class
