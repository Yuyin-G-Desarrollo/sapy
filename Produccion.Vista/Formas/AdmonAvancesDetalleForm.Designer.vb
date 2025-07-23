<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdmonAvancesDetalleForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdmonAvancesDetalleForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblDetalleLote = New System.Windows.Forms.Label()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.grbListaAcciones = New System.Windows.Forms.GroupBox()
        Me.grdDetalles = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTalla = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtModelo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNoLote = New System.Windows.Forms.TextBox()
        Me.lblNombreDelHorario = New System.Windows.Forms.Label()
        Me.txtPrograma = New System.Windows.Forms.TextBox()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbListaAcciones.SuspendLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(523, 86)
        Me.pnlEncabezado.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTitulo.Controls.Add(Me.lblDetalleLote)
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Location = New System.Drawing.Point(372, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(148, 80)
        Me.pnlTitulo.TabIndex = 22
        '
        'lblDetalleLote
        '
        Me.lblDetalleLote.AutoSize = True
        Me.lblDetalleLote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalleLote.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDetalleLote.Location = New System.Drawing.Point(13, 59)
        Me.lblDetalleLote.Name = "lblDetalleLote"
        Me.lblDetalleLote.Size = New System.Drawing.Size(132, 20)
        Me.lblDetalleLote.TabIndex = 21
        Me.lblDetalleLote.Text = "Detalle de Lote"
        '
        'imgLogo
        '
        Me.imgLogo.Image = CType(resources.GetObject("imgLogo.Image"), System.Drawing.Image)
        Me.imgLogo.Location = New System.Drawing.Point(16, 6)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(129, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'grbListaAcciones
        '
        Me.grbListaAcciones.Controls.Add(Me.grdDetalles)
        Me.grbListaAcciones.Controls.Add(Me.Label3)
        Me.grbListaAcciones.Controls.Add(Me.txtTalla)
        Me.grbListaAcciones.Controls.Add(Me.Label2)
        Me.grbListaAcciones.Controls.Add(Me.txtModelo)
        Me.grbListaAcciones.Controls.Add(Me.Label1)
        Me.grbListaAcciones.Controls.Add(Me.txtNoLote)
        Me.grbListaAcciones.Controls.Add(Me.lblNombreDelHorario)
        Me.grbListaAcciones.Controls.Add(Me.txtPrograma)
        Me.grbListaAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbListaAcciones.Location = New System.Drawing.Point(0, 86)
        Me.grbListaAcciones.Name = "grbListaAcciones"
        Me.grbListaAcciones.Size = New System.Drawing.Size(523, 291)
        Me.grbListaAcciones.TabIndex = 11
        Me.grbListaAcciones.TabStop = False
        '
        'grdDetalles
        '
        Me.grdDetalles.AllowEditing = False
        Me.grdDetalles.AllowFiltering = True
        Me.grdDetalles.AutoResize = True
        Me.grdDetalles.ColumnInfo = resources.GetString("grdDetalles.ColumnInfo")
        Me.grdDetalles.ExtendLastCol = True
        Me.grdDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.grdDetalles.Location = New System.Drawing.Point(10, 131)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.Rows.Count = 1
        Me.grdDetalles.Rows.DefaultSize = 17
        Me.grdDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdDetalles.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.grdDetalles.Size = New System.Drawing.Size(502, 148)
        Me.grdDetalles.StyleInfo = resources.GetString("grdDetalles.StyleInfo")
        Me.grdDetalles.TabIndex = 12
        Me.grdDetalles.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Talla"
        '
        'txtTalla
        '
        Me.txtTalla.Location = New System.Drawing.Point(108, 97)
        Me.txtTalla.MaxLength = 50
        Me.txtTalla.Name = "txtTalla"
        Me.txtTalla.Size = New System.Drawing.Size(88, 20)
        Me.txtTalla.TabIndex = 11
        Me.txtTalla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Modelo"
        '
        'txtModelo
        '
        Me.txtModelo.Location = New System.Drawing.Point(108, 71)
        Me.txtModelo.MaxLength = 50
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Size = New System.Drawing.Size(362, 20)
        Me.txtModelo.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "No Lote"
        '
        'txtNoLote
        '
        Me.txtNoLote.Location = New System.Drawing.Point(108, 45)
        Me.txtNoLote.MaxLength = 50
        Me.txtNoLote.Name = "txtNoLote"
        Me.txtNoLote.Size = New System.Drawing.Size(88, 20)
        Me.txtNoLote.TabIndex = 7
        Me.txtNoLote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNombreDelHorario
        '
        Me.lblNombreDelHorario.AutoSize = True
        Me.lblNombreDelHorario.Location = New System.Drawing.Point(47, 22)
        Me.lblNombreDelHorario.Name = "lblNombreDelHorario"
        Me.lblNombreDelHorario.Size = New System.Drawing.Size(55, 13)
        Me.lblNombreDelHorario.TabIndex = 2
        Me.lblNombreDelHorario.Text = "Programa:"
        '
        'txtPrograma
        '
        Me.txtPrograma.Location = New System.Drawing.Point(108, 19)
        Me.txtPrograma.MaxLength = 50
        Me.txtPrograma.Name = "txtPrograma"
        Me.txtPrograma.Size = New System.Drawing.Size(88, 20)
        Me.txtPrograma.TabIndex = 5
        Me.txtPrograma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(463, 417)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(49, 13)
        Me.lblCancelar.TabIndex = 51
        Me.lblCancelar.Text = "Cancelar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(471, 384)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'AdmonAvancesDetalleForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(523, 438)
        Me.Controls.Add(Me.lblCancelar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.grbListaAcciones)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AdmonAvancesDetalleForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Lote"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbListaAcciones.ResumeLayout(False)
        Me.grbListaAcciones.PerformLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents lblDetalleLote As System.Windows.Forms.Label
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents grbListaAcciones As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreDelHorario As System.Windows.Forms.Label
    Friend WithEvents txtPrograma As System.Windows.Forms.TextBox
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTalla As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtModelo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNoLote As System.Windows.Forms.TextBox
    Friend WithEvents grdDetalles As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
End Class
