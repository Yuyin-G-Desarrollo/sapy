<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListaImpresorasForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaImpresorasForm))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblImprimirEtiquetas = New System.Windows.Forms.Label()
        Me.btnAsignarImpresora = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdImpresoras = New DevExpress.XtraGrid.GridControl()
        Me.grdVImpresoras = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdImpresoras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVImpresoras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblImprimirEtiquetas)
        Me.pnlListaPaises.Controls.Add(Me.btnAsignarImpresora)
        Me.pnlListaPaises.Controls.Add(Me.btnEditar)
        Me.pnlListaPaises.Controls.Add(Me.Label2)
        Me.pnlListaPaises.Controls.Add(Me.btnAlta)
        Me.pnlListaPaises.Controls.Add(Me.Label1)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(920, 67)
        Me.pnlListaPaises.TabIndex = 33
        '
        'lblImprimirEtiquetas
        '
        Me.lblImprimirEtiquetas.AutoSize = True
        Me.lblImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimirEtiquetas.Location = New System.Drawing.Point(114, 38)
        Me.lblImprimirEtiquetas.Name = "lblImprimirEtiquetas"
        Me.lblImprimirEtiquetas.Size = New System.Drawing.Size(53, 26)
        Me.lblImprimirEtiquetas.TabIndex = 86
        Me.lblImprimirEtiquetas.Text = "Asignar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Impresora"
        Me.lblImprimirEtiquetas.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAsignarImpresora
        '
        Me.btnAsignarImpresora.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAsignarImpresora.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnAsignarImpresora.Image = Global.Programacion.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.btnAsignarImpresora.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAsignarImpresora.Location = New System.Drawing.Point(122, 9)
        Me.btnAsignarImpresora.Name = "btnAsignarImpresora"
        Me.btnAsignarImpresora.Size = New System.Drawing.Size(32, 32)
        Me.btnAsignarImpresora.TabIndex = 85
        Me.btnAsignarImpresora.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.BackgroundImage = CType(resources.GetObject("btnEditar.BackgroundImage"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(71, 9)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 18
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Location = New System.Drawing.Point(69, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Editar"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAlta
        '
        Me.btnAlta.BackgroundImage = CType(resources.GetObject("btnAlta.BackgroundImage"), System.Drawing.Image)
        Me.btnAlta.Location = New System.Drawing.Point(20, 9)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 16
        Me.btnAlta.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Location = New System.Drawing.Point(22, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Altas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(539, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(381, 67)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(117, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(201, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Catálogo de Impresoras"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 405)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(920, 60)
        Me.pnlPie.TabIndex = 70
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(755, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = CType(resources.GetObject("btnCerrar.BackgroundImage"), System.Drawing.Image)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.grdImpresoras)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(920, 338)
        Me.Panel1.TabIndex = 71
        '
        'grdImpresoras
        '
        Me.grdImpresoras.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdImpresoras.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdImpresoras.Location = New System.Drawing.Point(0, 0)
        Me.grdImpresoras.MainView = Me.grdVImpresoras
        Me.grdImpresoras.Name = "grdImpresoras"
        Me.grdImpresoras.Size = New System.Drawing.Size(920, 338)
        Me.grdImpresoras.TabIndex = 32
        Me.grdImpresoras.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVImpresoras})
        '
        'grdVImpresoras
        '
        Me.grdVImpresoras.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVImpresoras.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVImpresoras.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 1.0!)
        Me.grdVImpresoras.Appearance.HorzLine.Options.UseFont = True
        Me.grdVImpresoras.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdVImpresoras.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVImpresoras.GridControl = Me.grdImpresoras
        Me.grdVImpresoras.Name = "grdVImpresoras"
        Me.grdVImpresoras.OptionsView.ShowAutoFilterRow = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(319, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ListaImpresorasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 465)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(928, 492)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(928, 492)
        Me.Name = "ListaImpresorasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Catálogo de Impresoras"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdImpresoras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVImpresoras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdImpresoras As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVImpresoras As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblImprimirEtiquetas As Label
    Friend WithEvents btnAsignarImpresora As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
