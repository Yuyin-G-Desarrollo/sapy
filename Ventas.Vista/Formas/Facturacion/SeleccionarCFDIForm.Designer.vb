<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SeleccionarCFDIForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SeleccionarCFDIForm))
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbConAjuste = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblSerie = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.grdListado = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(48, 19)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(79, 20)
        Me.txtSerie.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbConAjuste)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblFolio)
        Me.GroupBox1.Controls.Add(Me.txtFolio)
        Me.GroupBox1.Controls.Add(Me.lblSerie)
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(536, 49)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        '
        'cmbConAjuste
        '
        Me.cmbConAjuste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConAjuste.FormattingEnabled = True
        Me.cmbConAjuste.Items.AddRange(New Object() {"Todas", "Si", "No"})
        Me.cmbConAjuste.Location = New System.Drawing.Point(346, 19)
        Me.cmbConAjuste.Name = "cmbConAjuste"
        Me.cmbConAjuste.Size = New System.Drawing.Size(121, 21)
        Me.cmbConAjuste.TabIndex = 38
        Me.cmbConAjuste.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(282, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Con Ajuste"
        Me.Label1.Visible = False
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.ForeColor = System.Drawing.Color.Black
        Me.lblFolio.Location = New System.Drawing.Point(150, 22)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(29, 13)
        Me.lblFolio.TabIndex = 36
        Me.lblFolio.Text = "Folio"
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(185, 19)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(79, 20)
        Me.txtFolio.TabIndex = 35
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = True
        Me.lblSerie.ForeColor = System.Drawing.Color.Black
        Me.lblSerie.Location = New System.Drawing.Point(13, 22)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(31, 13)
        Me.lblSerie.TabIndex = 31
        Me.lblSerie.Text = "Serie"
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(94, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 50
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(92, 45)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 51
        Me.lblCerrar.Text = "Cerrar"
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(33, 45)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(44, 13)
        Me.lblAceptar.TabIndex = 0
        Me.lblAceptar.Text = "Aceptar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(39, 10)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(32, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnAceptar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(392, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 407)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(536, 71)
        Me.pnlPie.TabIndex = 69
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblEncabezado)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(536, 59)
        Me.pnlEncabezado.TabIndex = 68
        '
        'lblEncabezado
        '
        Me.lblEncabezado.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(300, 0)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(168, 59)
        Me.lblEncabezado.TabIndex = 26
        Me.lblEncabezado.Text = "Buscar CFDI"
        Me.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdListado
        '
        Me.grdListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListado.Location = New System.Drawing.Point(0, 108)
        Me.grdListado.MainView = Me.GridView1
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(536, 299)
        Me.grdListado.TabIndex = 71
        Me.grdListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.GridView1.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridView1.Appearance.OddRow.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GridView1.Appearance.OddRow.BackColor2 = System.Drawing.Color.LightSteelBlue
        Me.GridView1.Appearance.OddRow.Options.UseBackColor = True
        Me.GridView1.GridControl = Me.grdListado
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(468, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 25
        Me.pbYuyin.TabStop = False
        '
        'SeleccionarCFDIForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(536, 478)
        Me.Controls.Add(Me.grdListado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(544, 505)
        Me.MinimumSize = New System.Drawing.Size(544, 505)
        Me.Name = "SeleccionarCFDIForm"
        Me.Text = "Seleccionar CFDI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtSerie As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblSerie As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents lblFolio As Label
    Friend WithEvents txtFolio As TextBox
    Friend WithEvents grdListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbConAjuste As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents pbYuyin As PictureBox
End Class
