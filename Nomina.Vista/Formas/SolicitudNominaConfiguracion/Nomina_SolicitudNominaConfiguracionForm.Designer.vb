<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nomina_SolicitudNominaConfiguracionForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nomina_SolicitudNominaConfiguracionForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTextoUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualización = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.grdConfiguracionNomina = New DevExpress.XtraGrid.GridControl()
        Me.MVConfiguracionNomina = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdConfiguracionNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MVConfiguracionNomina, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label4)
        Me.pnlHeader.Controls.Add(Me.btnEditar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1045, 79)
        Me.pnlHeader.TabIndex = 72
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(20, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Editar"
        '
        'btnEditar
        '
        Me.btnEditar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEditar.Image = Global.Nomina.Vista.My.Resources.Resources.editar_321
        Me.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEditar.Location = New System.Drawing.Point(21, 12)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 84
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(568, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(477, 79)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(119, 29)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(272, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Configuración Solicitud Finanzas"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.lblTextoUltimaActualizacion)
        Me.Panel2.Controls.Add(Me.lblFechaUltimaActualización)
        Me.Panel2.Controls.Add(Me.pnlBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 475)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1045, 73)
        Me.Panel2.TabIndex = 74
        '
        'lblTextoUltimaActualizacion
        '
        Me.lblTextoUltimaActualizacion.AutoSize = True
        Me.lblTextoUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaActualizacion.Location = New System.Drawing.Point(580, 32)
        Me.lblTextoUltimaActualizacion.Name = "lblTextoUltimaActualizacion"
        Me.lblTextoUltimaActualizacion.Size = New System.Drawing.Size(104, 13)
        Me.lblTextoUltimaActualizacion.TabIndex = 123
        Me.lblTextoUltimaActualizacion.Text = "Última actualización:"
        '
        'lblFechaUltimaActualización
        '
        Me.lblFechaUltimaActualización.AutoSize = True
        Me.lblFechaUltimaActualización.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualización.Location = New System.Drawing.Point(699, 32)
        Me.lblFechaUltimaActualización.Name = "lblFechaUltimaActualización"
        Me.lblFechaUltimaActualización.Size = New System.Drawing.Size(10, 13)
        Me.lblFechaUltimaActualización.TabIndex = 124
        Me.lblFechaUltimaActualización.Text = "-"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.lblAceptar)
        Me.pnlBotones.Controls.Add(Me.btnMostrar)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(913, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(132, 73)
        Me.pnlBotones.TabIndex = 6
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(22, 47)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(42, 13)
        Me.lblAceptar.TabIndex = 81
        Me.lblAceptar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Nomina.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(25, 12)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 82
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(76, 47)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 80
        Me.lblCerrar.Text = "Cerrar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Nomina.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(77, 12)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 79
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'grdConfiguracionNomina
        '
        Me.grdConfiguracionNomina.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdConfiguracionNomina.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdConfiguracionNomina.Location = New System.Drawing.Point(0, 79)
        Me.grdConfiguracionNomina.MainView = Me.MVConfiguracionNomina
        Me.grdConfiguracionNomina.Name = "grdConfiguracionNomina"
        Me.grdConfiguracionNomina.Size = New System.Drawing.Size(1045, 396)
        Me.grdConfiguracionNomina.TabIndex = 75
        Me.grdConfiguracionNomina.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.MVConfiguracionNomina})
        '
        'MVConfiguracionNomina
        '
        Me.MVConfiguracionNomina.GridControl = Me.grdConfiguracionNomina
        Me.MVConfiguracionNomina.Name = "MVConfiguracionNomina"
        Me.MVConfiguracionNomina.OptionsView.ShowAutoFilterRow = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(409, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'Nomina_SolicitudNominaConfiguracionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 548)
        Me.Controls.Add(Me.grdConfiguracionNomina)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "Nomina_SolicitudNominaConfiguracionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Solicitud Finanzas"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdConfiguracionNomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MVConfiguracionNomina, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents grdConfiguracionNomina As DevExpress.XtraGrid.GridControl
    Friend WithEvents MVConfiguracionNomina As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblTextoUltimaActualizacion As Label
    Friend WithEvents lblFechaUltimaActualización As Label
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents bntSalir As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnEditar As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
