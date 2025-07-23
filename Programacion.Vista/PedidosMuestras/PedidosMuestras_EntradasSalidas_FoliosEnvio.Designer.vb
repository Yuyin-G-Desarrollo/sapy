<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PedidosMuestras_EntradasSalidas_FoliosEnvio
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
        Me.groupContenedor = New System.Windows.Forms.GroupBox()
        Me.GrdFoliosEnvios = New DevExpress.XtraGrid.GridControl()
        Me.GrdVFoliosEnvios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFolioSeleccionado = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.groupContenedor.SuspendLayout()
        CType(Me.GrdFoliosEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrdVFoliosEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupContenedor
        '
        Me.groupContenedor.Controls.Add(Me.GrdFoliosEnvios)
        Me.groupContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupContenedor.Location = New System.Drawing.Point(0, 60)
        Me.groupContenedor.Name = "groupContenedor"
        Me.groupContenedor.Size = New System.Drawing.Size(518, 343)
        Me.groupContenedor.TabIndex = 17
        Me.groupContenedor.TabStop = False
        '
        'GrdFoliosEnvios
        '
        Me.GrdFoliosEnvios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrdFoliosEnvios.Location = New System.Drawing.Point(3, 16)
        Me.GrdFoliosEnvios.MainView = Me.GrdVFoliosEnvios
        Me.GrdFoliosEnvios.Name = "GrdFoliosEnvios"
        Me.GrdFoliosEnvios.Size = New System.Drawing.Size(512, 324)
        Me.GrdFoliosEnvios.TabIndex = 0
        Me.GrdFoliosEnvios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GrdVFoliosEnvios})
        '
        'GrdVFoliosEnvios
        '
        Me.GrdVFoliosEnvios.GridControl = Me.GrdFoliosEnvios
        Me.GrdVFoliosEnvios.Name = "GrdVFoliosEnvios"
        Me.GrdVFoliosEnvios.OptionsView.ShowAutoFilterRow = True
        Me.GrdVFoliosEnvios.OptionsView.ShowGroupPanel = False
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lblNave)
        Me.pnlEstado.Controls.Add(Me.Label1)
        Me.pnlEstado.Controls.Add(Me.lblFolioSeleccionado)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Controls.Add(Me.Label12)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 403)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(518, 60)
        Me.pnlEstado.TabIndex = 16
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(56, 12)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(0, 16)
        Me.lblNave.TabIndex = 152
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 16)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Nave:"
        '
        'lblFolioSeleccionado
        '
        Me.lblFolioSeleccionado.AutoSize = True
        Me.lblFolioSeleccionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioSeleccionado.ForeColor = System.Drawing.Color.Black
        Me.lblFolioSeleccionado.Location = New System.Drawing.Point(190, 29)
        Me.lblFolioSeleccionado.Name = "lblFolioSeleccionado"
        Me.lblFolioSeleccionado.Size = New System.Drawing.Size(13, 16)
        Me.lblFolioSeleccionado.TabIndex = 150
        Me.lblFolioSeleccionado.Text = "-"
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblCancelar)
        Me.pnlOperaciones.Controls.Add(Me.lblGuardar)
        Me.pnlOperaciones.Controls.Add(Me.btnCancelar)
        Me.pnlOperaciones.Controls.Add(Me.btnGuardar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(369, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(149, 60)
        Me.pnlOperaciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(99, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(15, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(63, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Seleccionar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(99, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.aceptar_321
        Me.btnGuardar.Location = New System.Drawing.Point(30, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(182, 16)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Folio de Envío seleccionado:"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(518, 60)
        Me.pnlHeader.TabIndex = 15
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(258, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(260, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(60, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(131, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Folios de Envío"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(191, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'PedidosMuestras_EntradasSalidas_FoliosEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 463)
        Me.Controls.Add(Me.groupContenedor)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(534, 502)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(534, 502)
        Me.Name = "PedidosMuestras_EntradasSalidas_FoliosEnvio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Folios de Envío"
        Me.groupContenedor.ResumeLayout(False)
        CType(Me.GrdFoliosEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrdVFoliosEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents groupContenedor As GroupBox
    Friend WithEvents pnlEstado As Panel
    Friend WithEvents pnlOperaciones As Panel
    Friend WithEvents lblCancelar As Label
    Friend WithEvents btnCancelar As Button
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pcbTitulo As PictureBox
    Friend WithEvents lblGuardar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblFolioSeleccionado As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblNave As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GrdFoliosEnvios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GrdVFoliosEnvios As DevExpress.XtraGrid.Views.Grid.GridView
End Class
