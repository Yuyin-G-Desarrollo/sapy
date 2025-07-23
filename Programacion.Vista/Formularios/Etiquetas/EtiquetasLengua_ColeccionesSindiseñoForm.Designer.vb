<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EtiquetasLengua_ColeccionesSindiseñoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtiquetasLengua_ColeccionesSindiseñoForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnClientesPruebaDetallesImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdEtiquetasDetalles = New DevExpress.XtraGrid.GridControl()
        Me.grdVEtiquetasDetalles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdEtiquetasDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVEtiquetasDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnClientesPruebaDetallesImprimir)
        Me.pnlListaPaises.Controls.Add(Me.lblImprimir)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(546, 53)
        Me.pnlListaPaises.TabIndex = 35
        '
        'btnClientesPruebaDetallesImprimir
        '
        Me.btnClientesPruebaDetallesImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnClientesPruebaDetallesImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.excel_321
        Me.btnClientesPruebaDetallesImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClientesPruebaDetallesImprimir.Location = New System.Drawing.Point(30, 3)
        Me.btnClientesPruebaDetallesImprimir.Name = "btnClientesPruebaDetallesImprimir"
        Me.btnClientesPruebaDetallesImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnClientesPruebaDetallesImprimir.TabIndex = 116
        Me.btnClientesPruebaDetallesImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimir.Location = New System.Drawing.Point(24, 38)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(46, 13)
        Me.lblImprimir.TabIndex = 115
        Me.lblImprimir.Text = "Exportar"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(211, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(335, 53)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(11, 19)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(245, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Alerta Colecciones sin diseño"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Label47)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 432)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(546, 65)
        Me.Panel2.TabIndex = 36
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(27, 36)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(16, 13)
        Me.Label47.TabIndex = 4
        Me.Label47.Text = "..."
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(384, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 65)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(103, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(103, 37)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdEtiquetasDetalles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 379)
        Me.Panel1.TabIndex = 37
        '
        'grdEtiquetasDetalles
        '
        Me.grdEtiquetasDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEtiquetasDetalles.Location = New System.Drawing.Point(0, 0)
        Me.grdEtiquetasDetalles.MainView = Me.grdVEtiquetasDetalles
        Me.grdEtiquetasDetalles.Name = "grdEtiquetasDetalles"
        Me.grdEtiquetasDetalles.Size = New System.Drawing.Size(546, 379)
        Me.grdEtiquetasDetalles.TabIndex = 38
        Me.grdEtiquetasDetalles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVEtiquetasDetalles})
        '
        'grdVEtiquetasDetalles
        '
        Me.grdVEtiquetasDetalles.GridControl = Me.grdEtiquetasDetalles
        Me.grdVEtiquetasDetalles.Name = "grdVEtiquetasDetalles"
        Me.grdVEtiquetasDetalles.OptionsView.ShowAutoFilterRow = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(273, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'EtiquetasLengua_ColeccionesSindiseñoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 497)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "EtiquetasLengua_ColeccionesSindiseñoForm"
        Me.Text = "Alerta Colecciones sin diseño"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdEtiquetasDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVEtiquetasDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label47 As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents btnClientesPruebaDetallesImprimir As Button
    Friend WithEvents lblImprimir As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdEtiquetasDetalles As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVEtiquetasDetalles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
