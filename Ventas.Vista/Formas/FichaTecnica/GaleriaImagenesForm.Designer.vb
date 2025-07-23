<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GaleriaImagenesForm
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
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlGaleria = New System.Windows.Forms.Panel()
        Me.imgGaleria = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.pnlBotonesGaleria = New System.Windows.Forms.Panel()
        Me.btnEliminarImagen = New System.Windows.Forms.Button()
        Me.btnAgregarImagenes = New System.Windows.Forms.Button()
        Me.lblEliminarImagen = New System.Windows.Forms.Label()
        Me.lblAgregarImagenes = New System.Windows.Forms.Label()
        Me.pnlGaleriaCarrusel = New System.Windows.Forms.Panel()
        Me.pnlGaleriaCarruselMiniaturas = New System.Windows.Forms.Panel()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlGaleria.SuspendLayout()
        Me.pnlBotonesGaleria.SuspendLayout()
        Me.pnlGaleriaCarrusel.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlGaleria)
        Me.pnlContenedor.Controls.Add(Me.pnlBotonesGaleria)
        Me.pnlContenedor.Controls.Add(Me.pnlGaleriaCarrusel)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(640, 551)
        Me.pnlContenedor.TabIndex = 0
        '
        'pnlGaleria
        '
        Me.pnlGaleria.BackColor = System.Drawing.Color.LightGray
        Me.pnlGaleria.Controls.Add(Me.imgGaleria)
        Me.pnlGaleria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGaleria.Location = New System.Drawing.Point(0, 67)
        Me.pnlGaleria.Name = "pnlGaleria"
        Me.pnlGaleria.Size = New System.Drawing.Size(640, 374)
        Me.pnlGaleria.TabIndex = 2
        '
        'imgGaleria
        '
        Me.imgGaleria.BackColor = System.Drawing.Color.Black
        Me.imgGaleria.BorderShadowColor = System.Drawing.Color.Empty
        Me.imgGaleria.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.imgGaleria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgGaleria.Location = New System.Drawing.Point(0, 0)
        Me.imgGaleria.Name = "imgGaleria"
        Me.imgGaleria.Size = New System.Drawing.Size(640, 374)
        Me.imgGaleria.TabIndex = 0
        '
        'pnlBotonesGaleria
        '
        Me.pnlBotonesGaleria.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlBotonesGaleria.Controls.Add(Me.btnEliminarImagen)
        Me.pnlBotonesGaleria.Controls.Add(Me.btnAgregarImagenes)
        Me.pnlBotonesGaleria.Controls.Add(Me.lblEliminarImagen)
        Me.pnlBotonesGaleria.Controls.Add(Me.lblAgregarImagenes)
        Me.pnlBotonesGaleria.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBotonesGaleria.Location = New System.Drawing.Point(0, 0)
        Me.pnlBotonesGaleria.Name = "pnlBotonesGaleria"
        Me.pnlBotonesGaleria.Size = New System.Drawing.Size(640, 67)
        Me.pnlBotonesGaleria.TabIndex = 3
        '
        'btnEliminarImagen
        '
        Me.btnEliminarImagen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEliminarImagen.Image = Global.Ventas.Vista.My.Resources.Resources.borrar_32
        Me.btnEliminarImagen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEliminarImagen.Location = New System.Drawing.Point(596, 12)
        Me.btnEliminarImagen.Name = "btnEliminarImagen"
        Me.btnEliminarImagen.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarImagen.TabIndex = 28
        Me.btnEliminarImagen.UseVisualStyleBackColor = True
        '
        'btnAgregarImagenes
        '
        Me.btnAgregarImagenes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregarImagenes.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAgregarImagenes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAgregarImagenes.Location = New System.Drawing.Point(548, 12)
        Me.btnAgregarImagenes.Name = "btnAgregarImagenes"
        Me.btnAgregarImagenes.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarImagenes.TabIndex = 27
        Me.btnAgregarImagenes.UseVisualStyleBackColor = True
        '
        'lblEliminarImagen
        '
        Me.lblEliminarImagen.AutoSize = True
        Me.lblEliminarImagen.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminarImagen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEliminarImagen.Location = New System.Drawing.Point(591, 47)
        Me.lblEliminarImagen.Name = "lblEliminarImagen"
        Me.lblEliminarImagen.Size = New System.Drawing.Size(43, 13)
        Me.lblEliminarImagen.TabIndex = 25
        Me.lblEliminarImagen.Text = "Eliminar"
        '
        'lblAgregarImagenes
        '
        Me.lblAgregarImagenes.AutoSize = True
        Me.lblAgregarImagenes.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgregarImagenes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAgregarImagenes.Location = New System.Drawing.Point(542, 47)
        Me.lblAgregarImagenes.Name = "lblAgregarImagenes"
        Me.lblAgregarImagenes.Size = New System.Drawing.Size(44, 13)
        Me.lblAgregarImagenes.TabIndex = 26
        Me.lblAgregarImagenes.Text = "Agregar"
        '
        'pnlGaleriaCarrusel
        '
        Me.pnlGaleriaCarrusel.BackColor = System.Drawing.Color.Black
        Me.pnlGaleriaCarrusel.Controls.Add(Me.pnlGaleriaCarruselMiniaturas)
        Me.pnlGaleriaCarrusel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGaleriaCarrusel.Location = New System.Drawing.Point(0, 441)
        Me.pnlGaleriaCarrusel.Name = "pnlGaleriaCarrusel"
        Me.pnlGaleriaCarrusel.Size = New System.Drawing.Size(640, 110)
        Me.pnlGaleriaCarrusel.TabIndex = 1
        '
        'pnlGaleriaCarruselMiniaturas
        '
        Me.pnlGaleriaCarruselMiniaturas.AutoScroll = True
        Me.pnlGaleriaCarruselMiniaturas.BackColor = System.Drawing.Color.Black
        Me.pnlGaleriaCarruselMiniaturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGaleriaCarruselMiniaturas.Location = New System.Drawing.Point(0, 0)
        Me.pnlGaleriaCarruselMiniaturas.Name = "pnlGaleriaCarruselMiniaturas"
        Me.pnlGaleriaCarruselMiniaturas.Size = New System.Drawing.Size(640, 110)
        Me.pnlGaleriaCarruselMiniaturas.TabIndex = 1
        '
        'GaleriaImagenesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 551)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "GaleriaImagenesForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlGaleria.ResumeLayout(False)
        Me.pnlBotonesGaleria.ResumeLayout(False)
        Me.pnlBotonesGaleria.PerformLayout()
        Me.pnlGaleriaCarrusel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents imgGaleria As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents pnlGaleriaCarrusel As System.Windows.Forms.Panel
    Friend WithEvents pnlGaleriaCarruselMiniaturas As System.Windows.Forms.Panel
    Friend WithEvents pnlGaleria As System.Windows.Forms.Panel
    Friend WithEvents pnlBotonesGaleria As System.Windows.Forms.Panel
    Friend WithEvents btnEliminarImagen As System.Windows.Forms.Button
    Friend WithEvents btnAgregarImagenes As System.Windows.Forms.Button
    Friend WithEvents lblEliminarImagen As System.Windows.Forms.Label
    Friend WithEvents lblAgregarImagenes As System.Windows.Forms.Label
End Class
