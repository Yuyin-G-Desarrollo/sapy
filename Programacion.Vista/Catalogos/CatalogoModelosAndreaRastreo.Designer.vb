<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoModelosAndreaRastreo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoModelosAndreaRastreo))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdModelosAndrea = New DevExpress.XtraGrid.GridControl()
        Me.grdVModelosAndrea = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.chkDesasignar = New System.Windows.Forms.CheckBox()
        Me.rbtNoAsignados = New System.Windows.Forms.RadioButton()
        Me.rbtAsignados = New System.Windows.Forms.RadioButton()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdModelosAndrea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVModelosAndrea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(882, 60)
        Me.pnlListaPaises.TabIndex = 35
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.pctTitulo)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(560, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(322, 60)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(11, 11)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(228, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Conf. de Etiquetas Rastreo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Modelos Andrea" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblTotalRegistros)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 418)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(882, 65)
        Me.Panel2.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Total registros:"
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(31, 31)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(64, 18)
        Me.lblTotalRegistros.TabIndex = 4
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.pnlGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.pnlCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(670, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(212, 65)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(76, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(71, 65)
        Me.pnlGuardar.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(19, 10)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(14, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(147, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(65, 65)
        Me.pnlCerrar.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(17, 10)
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
        Me.lblCerrar.Location = New System.Drawing.Point(17, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(882, 358)
        Me.Panel1.TabIndex = 37
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdModelosAndrea)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 60)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(882, 298)
        Me.Panel4.TabIndex = 2
        '
        'grdModelosAndrea
        '
        Me.grdModelosAndrea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdModelosAndrea.Location = New System.Drawing.Point(0, 0)
        Me.grdModelosAndrea.MainView = Me.grdVModelosAndrea
        Me.grdModelosAndrea.Name = "grdModelosAndrea"
        Me.grdModelosAndrea.Size = New System.Drawing.Size(882, 298)
        Me.grdModelosAndrea.TabIndex = 0
        Me.grdModelosAndrea.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVModelosAndrea})
        '
        'grdVModelosAndrea
        '
        Me.grdVModelosAndrea.Appearance.EvenRow.BackColor = System.Drawing.Color.LightBlue
        Me.grdVModelosAndrea.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVModelosAndrea.Appearance.OddRow.BackColor = System.Drawing.Color.Transparent
        Me.grdVModelosAndrea.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVModelosAndrea.GridControl = Me.grdModelosAndrea
        Me.grdVModelosAndrea.Name = "grdVModelosAndrea"
        Me.grdVModelosAndrea.OptionsView.ShowAutoFilterRow = True
        Me.grdVModelosAndrea.OptionsView.ShowGroupPanel = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.chkSeleccionarTodo)
        Me.Panel3.Controls.Add(Me.chkDesasignar)
        Me.Panel3.Controls.Add(Me.rbtNoAsignados)
        Me.Panel3.Controls.Add(Me.rbtAsignados)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(882, 60)
        Me.Panel3.TabIndex = 1
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(29, 37)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarTodo.TabIndex = 3
        Me.chkSeleccionarTodo.Text = "Seleccionar todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'chkDesasignar
        '
        Me.chkDesasignar.AutoSize = True
        Me.chkDesasignar.Location = New System.Drawing.Point(206, 16)
        Me.chkDesasignar.Name = "chkDesasignar"
        Me.chkDesasignar.Size = New System.Drawing.Size(79, 17)
        Me.chkDesasignar.TabIndex = 2
        Me.chkDesasignar.Text = "Desasignar"
        Me.chkDesasignar.UseVisualStyleBackColor = True
        '
        'rbtNoAsignados
        '
        Me.rbtNoAsignados.AutoSize = True
        Me.rbtNoAsignados.Checked = True
        Me.rbtNoAsignados.Location = New System.Drawing.Point(29, 16)
        Me.rbtNoAsignados.Name = "rbtNoAsignados"
        Me.rbtNoAsignados.Size = New System.Drawing.Size(91, 17)
        Me.rbtNoAsignados.TabIndex = 1
        Me.rbtNoAsignados.TabStop = True
        Me.rbtNoAsignados.Text = "No Asignados"
        Me.rbtNoAsignados.UseVisualStyleBackColor = True
        '
        'rbtAsignados
        '
        Me.rbtAsignados.AutoSize = True
        Me.rbtAsignados.Location = New System.Drawing.Point(126, 16)
        Me.rbtAsignados.Name = "rbtAsignados"
        Me.rbtAsignados.Size = New System.Drawing.Size(74, 17)
        Me.rbtAsignados.TabIndex = 0
        Me.rbtAsignados.Text = "Asignados"
        Me.rbtAsignados.UseVisualStyleBackColor = True
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(254, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTitulo.TabIndex = 46
        Me.pctTitulo.TabStop = False
        '
        'CatalogoModelosAndreaRastreo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(882, 483)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.MaximizeBox = False
        Me.Name = "CatalogoModelosAndreaRastreo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Conf. de Etiquetas Rastreo Modelos Andrea"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdModelosAndrea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVModelosAndrea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents pnlGuardar As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents pnlCerrar As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grdModelosAndrea As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVModelosAndrea As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents rbtNoAsignados As RadioButton
    Friend WithEvents rbtAsignados As RadioButton
    Friend WithEvents chkDesasignar As CheckBox
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents pctTitulo As PictureBox
End Class
