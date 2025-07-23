<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaLotesSinGrfImagenForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkSinLogoMarca = New System.Windows.Forms.CheckBox()
        Me.chkSinImagen = New System.Windows.Forms.CheckBox()
        Me.chkGrf300 = New System.Windows.Forms.CheckBox()
        Me.chkGrf200 = New System.Windows.Forms.CheckBox()
        Me.chkFechasProg = New System.Windows.Forms.CheckBox()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaAl = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDel = New System.Windows.Forms.DateTimePicker()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GrdConsulta = New DevExpress.XtraGrid.GridControl()
        Me.GrdVConsulta = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        CType(Me.GrdConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdVConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(840, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(305, 65)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(3, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(230, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Lotes Con/Sin GRF/Imagen"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblExportar)
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1145, 65)
        Me.pnlListaPaises.TabIndex = 34
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(16, 42)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 157
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(23, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 156
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(569, 100)
        Me.Panel1.TabIndex = 71
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.chkSinLogoMarca)
        Me.Panel2.Controls.Add(Me.chkSinImagen)
        Me.Panel2.Controls.Add(Me.chkGrf300)
        Me.Panel2.Controls.Add(Me.chkGrf200)
        Me.Panel2.Controls.Add(Me.chkFechasProg)
        Me.Panel2.Controls.Add(Me.btnMostrar)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dtpFechaAl)
        Me.Panel2.Controls.Add(Me.dtpFechaDel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1145, 77)
        Me.Panel2.TabIndex = 74
        '
        'chkSinLogoMarca
        '
        Me.chkSinLogoMarca.AutoSize = True
        Me.chkSinLogoMarca.Location = New System.Drawing.Point(534, 47)
        Me.chkSinLogoMarca.Name = "chkSinLogoMarca"
        Me.chkSinLogoMarca.Size = New System.Drawing.Size(136, 17)
        Me.chkSinLogoMarca.TabIndex = 21
        Me.chkSinLogoMarca.Text = "Sin Logo Marca Cliente"
        Me.chkSinLogoMarca.UseVisualStyleBackColor = True
        '
        'chkSinImagen
        '
        Me.chkSinImagen.AutoSize = True
        Me.chkSinImagen.Location = New System.Drawing.Point(534, 22)
        Me.chkSinImagen.Name = "chkSinImagen"
        Me.chkSinImagen.Size = New System.Drawing.Size(79, 17)
        Me.chkSinImagen.TabIndex = 20
        Me.chkSinImagen.Text = "Sin Imagen"
        Me.chkSinImagen.UseVisualStyleBackColor = True
        '
        'chkGrf300
        '
        Me.chkGrf300.AutoSize = True
        Me.chkGrf300.Location = New System.Drawing.Point(429, 47)
        Me.chkGrf300.Name = "chkGrf300"
        Me.chkGrf300.Size = New System.Drawing.Size(87, 17)
        Me.chkGrf300.TabIndex = 19
        Me.chkGrf300.Text = "Sin GRF 300"
        Me.chkGrf300.UseVisualStyleBackColor = True
        '
        'chkGrf200
        '
        Me.chkGrf200.AutoSize = True
        Me.chkGrf200.Location = New System.Drawing.Point(429, 23)
        Me.chkGrf200.Name = "chkGrf200"
        Me.chkGrf200.Size = New System.Drawing.Size(87, 17)
        Me.chkGrf200.TabIndex = 18
        Me.chkGrf200.Text = "Sin GRF 200"
        Me.chkGrf200.UseVisualStyleBackColor = True
        '
        'chkFechasProg
        '
        Me.chkFechasProg.AutoSize = True
        Me.chkFechasProg.Location = New System.Drawing.Point(23, 34)
        Me.chkFechasProg.Name = "chkFechasProg"
        Me.chkFechasProg.Size = New System.Drawing.Size(91, 30)
        Me.chkFechasProg.TabIndex = 17
        Me.chkFechasProg.Text = "Fecha " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Programación"
        Me.chkFechasProg.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(708, 18)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 16
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(705, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Mostrar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Al:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha Del:"
        '
        'dtpFechaAl
        '
        Me.dtpFechaAl.Location = New System.Drawing.Point(197, 44)
        Me.dtpFechaAl.Name = "dtpFechaAl"
        Me.dtpFechaAl.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaAl.TabIndex = 1
        '
        'dtpFechaDel
        '
        Me.dtpFechaDel.Location = New System.Drawing.Point(197, 18)
        Me.dtpFechaDel.Name = "dtpFechaDel"
        Me.dtpFechaDel.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaDel.TabIndex = 0
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(980, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(106, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 468)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1145, 60)
        Me.pnlPie.TabIndex = 75
        '
        'GrdConsulta
        '
        Me.GrdConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.GrdConsulta.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GrdConsulta.Location = New System.Drawing.Point(0, 142)
        Me.GrdConsulta.MainView = Me.GrdVConsulta
        Me.GrdConsulta.Name = "GrdConsulta"
        Me.GrdConsulta.Size = New System.Drawing.Size(1145, 326)
        Me.GrdConsulta.TabIndex = 76
        Me.GrdConsulta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdVConsulta})
        '
        'GrdVConsulta
        '
        Me.GrdVConsulta.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GrdVConsulta.Appearance.EvenRow.Options.UseBackColor = True
        Me.GrdVConsulta.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdVConsulta.Appearance.OddRow.Options.UseBackColor = True
        Me.GrdVConsulta.Appearance.SelectedRow.BackColor = System.Drawing.Color.Blue
        Me.GrdVConsulta.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GrdVConsulta.GridControl = Me.GrdConsulta
        Me.GrdVConsulta.Name = "GrdVConsulta"
        Me.GrdVConsulta.OptionsView.ShowAutoFilterRow = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(243, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 65)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ConsultaLotesSinGrfImagenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 528)
        Me.Controls.Add(Me.GrdConsulta)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MinimumSize = New System.Drawing.Size(920, 555)
        Me.Name = "ConsultaLotesSinGrfImagenForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta Lotes Sin GRF/Imagen"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        CType(Me.GrdConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdVConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaAl As DateTimePicker
    Friend WithEvents dtpFechaDel As DateTimePicker
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblExportar As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents GrdConsulta As DevExpress.XtraGrid.GridControl
    Friend WithEvents GrdVConsulta As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkSinLogoMarca As CheckBox
    Friend WithEvents chkSinImagen As CheckBox
    Friend WithEvents chkGrf300 As CheckBox
    Friend WithEvents chkGrf200 As CheckBox
    Friend WithEvents chkFechasProg As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
