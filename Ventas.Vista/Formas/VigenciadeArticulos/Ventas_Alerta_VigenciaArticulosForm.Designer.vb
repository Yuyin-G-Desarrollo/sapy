<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ventas_Alerta_VigenciaArticulosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ventas_Alerta_VigenciaArticulosForm))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlde1a15dias = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDescontinuado = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlMayora15dias = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.grdAlertaDescontinuar = New DevExpress.XtraGrid.GridControl()
        Me.vwAlertaDescontinuar = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdAlertaDescontinuar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwAlertaDescontinuar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.lblRegistrosTitulo)
        Me.Panel2.Controls.Add(Me.lblRegistros)
        Me.Panel2.Controls.Add(Me.GroupBox12)
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 417)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1034, 71)
        Me.Panel2.TabIndex = 29
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(12, 14)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 185
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(12, 40)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 186
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label3)
        Me.GroupBox12.Controls.Add(Me.pnlde1a15dias)
        Me.GroupBox12.Controls.Add(Me.Label5)
        Me.GroupBox12.Controls.Add(Me.pnlDescontinuado)
        Me.GroupBox12.Controls.Add(Me.Label12)
        Me.GroupBox12.Controls.Add(Me.pnlMayora15dias)
        Me.GroupBox12.Location = New System.Drawing.Point(179, 7)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(423, 55)
        Me.GroupBox12.TabIndex = 122
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Status Artículo (ST)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(220, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Vencimiento entre 1 y 15 días"
        '
        'pnlde1a15dias
        '
        Me.pnlde1a15dias.BackColor = System.Drawing.Color.Yellow
        Me.pnlde1a15dias.ForeColor = System.Drawing.Color.Black
        Me.pnlde1a15dias.Location = New System.Drawing.Point(202, 16)
        Me.pnlde1a15dias.Name = "pnlde1a15dias"
        Me.pnlde1a15dias.Size = New System.Drawing.Size(15, 15)
        Me.pnlde1a15dias.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Descontinuado"
        '
        'pnlDescontinuado
        '
        Me.pnlDescontinuado.BackColor = System.Drawing.Color.OrangeRed
        Me.pnlDescontinuado.ForeColor = System.Drawing.Color.Black
        Me.pnlDescontinuado.Location = New System.Drawing.Point(6, 37)
        Me.pnlDescontinuado.Name = "pnlDescontinuado"
        Me.pnlDescontinuado.Size = New System.Drawing.Size(15, 15)
        Me.pnlDescontinuado.TabIndex = 25
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(24, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Vencimiento mayor a 15 días"
        '
        'pnlMayora15dias
        '
        Me.pnlMayora15dias.BackColor = System.Drawing.Color.Green
        Me.pnlMayora15dias.ForeColor = System.Drawing.Color.Black
        Me.pnlMayora15dias.Location = New System.Drawing.Point(6, 16)
        Me.pnlMayora15dias.Name = "pnlMayora15dias"
        Me.pnlMayora15dias.Size = New System.Drawing.Size(15, 15)
        Me.pnlMayora15dias.TabIndex = 23
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnActualizar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblActualizar)
        Me.pnlBotones.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlBotones.Controls.Add(Me.Label2)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(608, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(426, 71)
        Me.pnlBotones.TabIndex = 6
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Ventas.Vista.My.Resources.Resources.refresh_321
        Me.btnActualizar.Location = New System.Drawing.Point(332, 14)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 21
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(382, 14)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 20
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(322, 49)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(53, 13)
        Me.lblActualizar.TabIndex = 19
        Me.lblActualizar.Text = "Actualizar"
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(155, 34)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(28, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 2
        Me.lblFechaUltimaActualizacion.Text = "-------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha Última Actualización :"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(381, 49)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnExportar)
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1034, 69)
        Me.pnlListaPaises.TabIndex = 30
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(20, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 22
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(13, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Exportar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(521, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(513, 69)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(83, 22)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(356, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Alertas - Artículos Próximos a Descontinuar"
        '
        'grdAlertaDescontinuar
        '
        Me.grdAlertaDescontinuar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAlertaDescontinuar.Location = New System.Drawing.Point(0, 69)
        Me.grdAlertaDescontinuar.MainView = Me.vwAlertaDescontinuar
        Me.grdAlertaDescontinuar.Name = "grdAlertaDescontinuar"
        Me.grdAlertaDescontinuar.Size = New System.Drawing.Size(1034, 348)
        Me.grdAlertaDescontinuar.TabIndex = 31
        Me.grdAlertaDescontinuar.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwAlertaDescontinuar})
        '
        'vwAlertaDescontinuar
        '
        Me.vwAlertaDescontinuar.GridControl = Me.grdAlertaDescontinuar
        Me.vwAlertaDescontinuar.Name = "vwAlertaDescontinuar"
        Me.vwAlertaDescontinuar.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.vwAlertaDescontinuar.OptionsMenu.EnableColumnMenu = False
        Me.vwAlertaDescontinuar.OptionsPrint.AllowMultilineHeaders = True
        Me.vwAlertaDescontinuar.OptionsSelection.MultiSelect = True
        Me.vwAlertaDescontinuar.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwAlertaDescontinuar.OptionsView.ShowAutoFilterRow = True
        Me.vwAlertaDescontinuar.OptionsView.ShowGroupPanel = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(445, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'Ventas_Alerta_VigenciaArticulosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 488)
        Me.Controls.Add(Me.grdAlertaDescontinuar)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Ventas_Alerta_VigenciaArticulosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alertas - Vigencia de Artículos "
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.grdAlertaDescontinuar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwAlertaDescontinuar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents lblActualizar As Label
    Friend WithEvents lblFechaUltimaActualizacion As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents grdAlertaDescontinuar As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwAlertaDescontinuar As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents pnlMayora15dias As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlDescontinuado As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlde1a15dias As Panel
    Friend WithEvents btnActualizar As Button
    Friend WithEvents bntSalir As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
