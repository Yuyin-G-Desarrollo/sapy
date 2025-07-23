<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaImagenesModelosZebra
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLotesGrfImagen = New System.Windows.Forms.Button()
        Me.lblConsultaInventarioNaves = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.GrdConsultaGrificoZebra = New DevExpress.XtraGrid.GridControl()
        Me.GrdVConsultaGrificoZebra = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rdbConGraficos = New System.Windows.Forms.RadioButton()
        Me.rdbTodos = New System.Windows.Forms.RadioButton()
        Me.rdbSinGraficos = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdbActivos = New System.Windows.Forms.RadioButton()
        Me.rdbInactivos = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.GrdConsultaGrificoZebra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdVConsultaGrificoZebra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.btnLotesGrfImagen)
        Me.pnlListaPaises.Controls.Add(Me.lblConsultaInventarioNaves)
        Me.pnlListaPaises.Controls.Add(Me.btnImprimir)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(863, 65)
        Me.pnlListaPaises.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(79, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 26)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Lotes Sin " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GRG/Imagen"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLotesGrfImagen
        '
        Me.btnLotesGrfImagen.BackColor = System.Drawing.Color.Transparent
        Me.btnLotesGrfImagen.Image = Global.Programacion.Vista.My.Resources.Resources.Camara
        Me.btnLotesGrfImagen.Location = New System.Drawing.Point(97, 4)
        Me.btnLotesGrfImagen.Name = "btnLotesGrfImagen"
        Me.btnLotesGrfImagen.Size = New System.Drawing.Size(32, 32)
        Me.btnLotesGrfImagen.TabIndex = 74
        Me.btnLotesGrfImagen.UseVisualStyleBackColor = False
        '
        'lblConsultaInventarioNaves
        '
        Me.lblConsultaInventarioNaves.AutoSize = True
        Me.lblConsultaInventarioNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblConsultaInventarioNaves.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaInventarioNaves.Location = New System.Drawing.Point(30, 38)
        Me.lblConsultaInventarioNaves.Name = "lblConsultaInventarioNaves"
        Me.lblConsultaInventarioNaves.Size = New System.Drawing.Size(41, 26)
        Me.lblConsultaInventarioNaves.TabIndex = 73
        Me.lblConsultaInventarioNaves.Text = "Cargar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "gráfico"
        Me.lblConsultaInventarioNaves.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.Transparent
        Me.btnImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.imagen
        Me.btnImprimir.Location = New System.Drawing.Point(33, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 72
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(569, 100)
        Me.Panel1.TabIndex = 71
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(558, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(305, 65)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(14, 15)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(212, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Modelos - Gráficos Zebra"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 413)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(863, 60)
        Me.pnlPie.TabIndex = 70
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(698, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(46, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 16
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(43, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Mostrar"
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
        'GrdConsultaGrificoZebra
        '
        Me.GrdConsultaGrificoZebra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        GridLevelNode1.RelationName = "Level1"
        Me.GrdConsultaGrificoZebra.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GrdConsultaGrificoZebra.Location = New System.Drawing.Point(0, 106)
        Me.GrdConsultaGrificoZebra.MainView = Me.GrdVConsultaGrificoZebra
        Me.GrdConsultaGrificoZebra.Name = "GrdConsultaGrificoZebra"
        Me.GrdConsultaGrificoZebra.Size = New System.Drawing.Size(863, 308)
        Me.GrdConsultaGrificoZebra.TabIndex = 72
        Me.GrdConsultaGrificoZebra.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdVConsultaGrificoZebra})
        '
        'GrdVConsultaGrificoZebra
        '
        Me.GrdVConsultaGrificoZebra.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GrdVConsultaGrificoZebra.Appearance.EvenRow.Options.UseBackColor = True
        Me.GrdVConsultaGrificoZebra.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrdVConsultaGrificoZebra.Appearance.OddRow.Options.UseBackColor = True
        Me.GrdVConsultaGrificoZebra.Appearance.SelectedRow.BackColor = System.Drawing.Color.Blue
        Me.GrdVConsultaGrificoZebra.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GrdVConsultaGrificoZebra.GridControl = Me.GrdConsultaGrificoZebra
        Me.GrdVConsultaGrificoZebra.Name = "GrdVConsultaGrificoZebra"
        Me.GrdVConsultaGrificoZebra.OptionsView.ShowAutoFilterRow = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 65)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(863, 38)
        Me.Panel2.TabIndex = 73
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.rdbConGraficos)
        Me.Panel4.Controls.Add(Me.rdbTodos)
        Me.Panel4.Controls.Add(Me.rdbSinGraficos)
        Me.Panel4.Location = New System.Drawing.Point(12, 7)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(243, 28)
        Me.Panel4.TabIndex = 6
        '
        'rdbConGraficos
        '
        Me.rdbConGraficos.AutoSize = True
        Me.rdbConGraficos.Location = New System.Drawing.Point(150, 6)
        Me.rdbConGraficos.Name = "rdbConGraficos"
        Me.rdbConGraficos.Size = New System.Drawing.Size(84, 17)
        Me.rdbConGraficos.TabIndex = 5
        Me.rdbConGraficos.TabStop = True
        Me.rdbConGraficos.Text = "Con gráficos"
        Me.rdbConGraficos.UseVisualStyleBackColor = True
        '
        'rdbTodos
        '
        Me.rdbTodos.AutoSize = True
        Me.rdbTodos.Location = New System.Drawing.Point(8, 5)
        Me.rdbTodos.Name = "rdbTodos"
        Me.rdbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rdbTodos.TabIndex = 3
        Me.rdbTodos.Text = "Todos"
        Me.rdbTodos.UseVisualStyleBackColor = True
        '
        'rdbSinGraficos
        '
        Me.rdbSinGraficos.AutoSize = True
        Me.rdbSinGraficos.Location = New System.Drawing.Point(69, 5)
        Me.rdbSinGraficos.Name = "rdbSinGraficos"
        Me.rdbSinGraficos.Size = New System.Drawing.Size(80, 17)
        Me.rdbSinGraficos.TabIndex = 4
        Me.rdbSinGraficos.Text = "Sin gráficos"
        Me.rdbSinGraficos.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.rdbActivos)
        Me.Panel3.Controls.Add(Me.rdbInactivos)
        Me.Panel3.Location = New System.Drawing.Point(452, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(408, 29)
        Me.Panel3.TabIndex = 5
        '
        'rdbActivos
        '
        Me.rdbActivos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbActivos.AutoSize = True
        Me.rdbActivos.Location = New System.Drawing.Point(8, 8)
        Me.rdbActivos.Name = "rdbActivos"
        Me.rdbActivos.Size = New System.Drawing.Size(60, 17)
        Me.rdbActivos.TabIndex = 3
        Me.rdbActivos.TabStop = True
        Me.rdbActivos.Text = "Activos"
        Me.rdbActivos.UseVisualStyleBackColor = True
        '
        'rdbInactivos
        '
        Me.rdbInactivos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbInactivos.AutoSize = True
        Me.rdbInactivos.Location = New System.Drawing.Point(86, 8)
        Me.rdbInactivos.Name = "rdbInactivos"
        Me.rdbInactivos.Size = New System.Drawing.Size(68, 17)
        Me.rdbInactivos.TabIndex = 4
        Me.rdbInactivos.TabStop = True
        Me.rdbInactivos.Text = "Inactivos"
        Me.rdbInactivos.UseVisualStyleBackColor = True
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
        'ConsultaImagenesModelosZebra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 473)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GrdConsultaGrificoZebra)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ConsultaImagenesModelosZebra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modelos – Gráficos Zebra"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.GrdConsultaGrificoZebra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdVConsultaGrificoZebra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrdConsultaGrificoZebra As DevExpress.XtraGrid.GridControl
    Friend WithEvents GrdVConsultaGrificoZebra As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblConsultaInventarioNaves As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents rdbInactivos As RadioButton
    Friend WithEvents rdbActivos As RadioButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rdbConGraficos As RadioButton
    Friend WithEvents rdbTodos As RadioButton
    Friend WithEvents rdbSinGraficos As RadioButton
    Friend WithEvents btnLotesGrfImagen As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
