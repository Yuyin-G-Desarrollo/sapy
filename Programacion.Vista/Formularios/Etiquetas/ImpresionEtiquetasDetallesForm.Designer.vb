<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionEtiquetasDetallesForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblPrueba = New System.Windows.Forms.Label()
        Me.chboxSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.btnClientesPruebaDetallesImprimir = New System.Windows.Forms.Button()
        Me.lblImprimir = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlParamCaptura = New System.Windows.Forms.Panel()
        Me.lblParamCaptura = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdEtiquetasDetalles = New DevExpress.XtraGrid.GridControl()
        Me.grdVEtiquetasDetalles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdEtiquetasBatta = New DevExpress.XtraGrid.GridControl()
        Me.grdVEtiquetasBatta = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdEtiquetasDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVEtiquetasDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEtiquetasBatta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVEtiquetasBatta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblPrueba)
        Me.pnlListaPaises.Controls.Add(Me.chboxSeleccionarTodo)
        Me.pnlListaPaises.Controls.Add(Me.btnClientesPruebaDetallesImprimir)
        Me.pnlListaPaises.Controls.Add(Me.lblImprimir)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1024, 92)
        Me.pnlListaPaises.TabIndex = 35
        '
        'lblPrueba
        '
        Me.lblPrueba.AutoSize = True
        Me.lblPrueba.Font = New System.Drawing.Font("Arial Black", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrueba.ForeColor = System.Drawing.Color.Red
        Me.lblPrueba.Location = New System.Drawing.Point(487, 41)
        Me.lblPrueba.Name = "lblPrueba"
        Me.lblPrueba.Size = New System.Drawing.Size(67, 15)
        Me.lblPrueba.TabIndex = 122
        Me.lblPrueba.Text = "PRUEBAS"
        '
        'chboxSeleccionarTodo
        '
        Me.chboxSeleccionarTodo.AutoSize = True
        Me.chboxSeleccionarTodo.Location = New System.Drawing.Point(38, 64)
        Me.chboxSeleccionarTodo.Name = "chboxSeleccionarTodo"
        Me.chboxSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chboxSeleccionarTodo.TabIndex = 121
        Me.chboxSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chboxSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'btnClientesPruebaDetallesImprimir
        '
        Me.btnClientesPruebaDetallesImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnClientesPruebaDetallesImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnClientesPruebaDetallesImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClientesPruebaDetallesImprimir.Location = New System.Drawing.Point(38, 12)
        Me.btnClientesPruebaDetallesImprimir.Name = "btnClientesPruebaDetallesImprimir"
        Me.btnClientesPruebaDetallesImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnClientesPruebaDetallesImprimir.TabIndex = 114
        Me.btnClientesPruebaDetallesImprimir.UseVisualStyleBackColor = True
        '
        'lblImprimir
        '
        Me.lblImprimir.AutoSize = True
        Me.lblImprimir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimir.Location = New System.Drawing.Point(32, 47)
        Me.lblImprimir.Name = "lblImprimir"
        Me.lblImprimir.Size = New System.Drawing.Size(42, 13)
        Me.lblImprimir.TabIndex = 113
        Me.lblImprimir.Text = "Imprimir"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(623, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(401, 92)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(18, 41)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(266, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Impresión de Etiquetas Detalles"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.pnlParamCaptura)
        Me.Panel2.Controls.Add(Me.lblParamCaptura)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 432)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 65)
        Me.Panel2.TabIndex = 36
        '
        'pnlParamCaptura
        '
        Me.pnlParamCaptura.BackColor = System.Drawing.Color.Red
        Me.pnlParamCaptura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlParamCaptura.ForeColor = System.Drawing.Color.Black
        Me.pnlParamCaptura.Location = New System.Drawing.Point(42, 23)
        Me.pnlParamCaptura.Name = "pnlParamCaptura"
        Me.pnlParamCaptura.Size = New System.Drawing.Size(15, 15)
        Me.pnlParamCaptura.TabIndex = 39
        '
        'lblParamCaptura
        '
        Me.lblParamCaptura.AutoSize = True
        Me.lblParamCaptura.BackColor = System.Drawing.Color.Transparent
        Me.lblParamCaptura.Location = New System.Drawing.Point(68, 25)
        Me.lblParamCaptura.Name = "lblParamCaptura"
        Me.lblParamCaptura.Size = New System.Drawing.Size(82, 13)
        Me.lblParamCaptura.TabIndex = 38
        Me.lblParamCaptura.Text = "Campos vacios."
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(862, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 65)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
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
        'grdEtiquetasDetalles
        '
        Me.grdEtiquetasDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdEtiquetasDetalles.Location = New System.Drawing.Point(0, 92)
        Me.grdEtiquetasDetalles.MainView = Me.grdVEtiquetasDetalles
        Me.grdEtiquetasDetalles.Name = "grdEtiquetasDetalles"
        Me.grdEtiquetasDetalles.Size = New System.Drawing.Size(1024, 340)
        Me.grdEtiquetasDetalles.TabIndex = 37
        Me.grdEtiquetasDetalles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVEtiquetasDetalles})
        '
        'grdVEtiquetasDetalles
        '
        Me.grdVEtiquetasDetalles.GridControl = Me.grdEtiquetasDetalles
        Me.grdVEtiquetasDetalles.Name = "grdVEtiquetasDetalles"
        Me.grdVEtiquetasDetalles.OptionsView.ShowAutoFilterRow = True
        '
        'grdEtiquetasBatta
        '
        Me.grdEtiquetasBatta.Location = New System.Drawing.Point(233, 177)
        Me.grdEtiquetasBatta.MainView = Me.grdVEtiquetasBatta
        Me.grdEtiquetasBatta.Name = "grdEtiquetasBatta"
        Me.grdEtiquetasBatta.Size = New System.Drawing.Size(558, 143)
        Me.grdEtiquetasBatta.TabIndex = 124
        Me.grdEtiquetasBatta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVEtiquetasBatta})
        '
        'grdVEtiquetasBatta
        '
        Me.grdVEtiquetasBatta.GridControl = Me.grdEtiquetasBatta
        Me.grdVEtiquetasBatta.Name = "grdVEtiquetasBatta"
        Me.grdVEtiquetasBatta.OptionsView.ShowGroupPanel = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(319, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(82, 92)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ImpresionEtiquetasDetallesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 497)
        Me.Controls.Add(Me.grdEtiquetasDetalles)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Controls.Add(Me.grdEtiquetasBatta)
        Me.Name = "ImpresionEtiquetasDetallesForm"
        Me.Text = "Impresión de Etiquetas Detalles"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdEtiquetasDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVEtiquetasDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEtiquetasBatta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVEtiquetasBatta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdEtiquetasDetalles As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVEtiquetasDetalles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnClientesPruebaDetallesImprimir As System.Windows.Forms.Button
    Friend WithEvents lblImprimir As System.Windows.Forms.Label
    Friend WithEvents chboxSeleccionarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents pnlParamCaptura As System.Windows.Forms.Panel
    Friend WithEvents lblParamCaptura As System.Windows.Forms.Label
    Friend WithEvents lblPrueba As System.Windows.Forms.Label
    Friend WithEvents grdEtiquetasBatta As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVEtiquetasBatta As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PictureBox1 As PictureBox
End Class
