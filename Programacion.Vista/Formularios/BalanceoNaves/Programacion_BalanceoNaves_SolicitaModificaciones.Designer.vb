<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Programacion_BalanceoNaves_SolicitaModificaciones
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSemanaFecha = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlConteo = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdSolicitaCambios = New DevExpress.XtraGrid.GridControl()
        Me.vwSolicitaCambios = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlConteo.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        CType(Me.grdSolicitaCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwSolicitaCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.lblSemanaFecha)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1198, 60)
        Me.pnlHeader.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Semana :"
        '
        'lblSemanaFecha
        '
        Me.lblSemanaFecha.AutoSize = True
        Me.lblSemanaFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanaFecha.Location = New System.Drawing.Point(93, 18)
        Me.lblSemanaFecha.Name = "lblSemanaFecha"
        Me.lblSemanaFecha.Size = New System.Drawing.Size(10, 13)
        Me.lblSemanaFecha.TabIndex = 174
        Me.lblSemanaFecha.Text = "-"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(791, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(407, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(28, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(276, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Solicita Cambios Balanceo Naves"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlConteo)
        Me.Panel1.Controls.Add(Me.lblObservaciones)
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 485)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1198, 60)
        Me.Panel1.TabIndex = 73
        '
        'pnlConteo
        '
        Me.pnlConteo.Controls.Add(Me.lblRegistrosTitulo)
        Me.pnlConteo.Controls.Add(Me.lblRegistros)
        Me.pnlConteo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlConteo.Location = New System.Drawing.Point(0, 0)
        Me.pnlConteo.Name = "pnlConteo"
        Me.pnlConteo.Size = New System.Drawing.Size(107, 60)
        Me.pnlConteo.TabIndex = 188
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(9, 8)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 183
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(3, 33)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 184
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(278, 16)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(232, 26)
        Me.lblObservaciones.TabIndex = 173
        Me.lblObservaciones.Text = "* Se guardarán únicamente los registros con" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Observaciones y Motivo de Solicitud " &
    "de Cambio" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.lblGuardar)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(952, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(246, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(145, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(139, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 5
        Me.lblGuardar.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(196, 6)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(195, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdSolicitaCambios
        '
        Me.grdSolicitaCambios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitaCambios.Location = New System.Drawing.Point(0, 60)
        Me.grdSolicitaCambios.MainView = Me.vwSolicitaCambios
        Me.grdSolicitaCambios.Name = "grdSolicitaCambios"
        Me.grdSolicitaCambios.Size = New System.Drawing.Size(1198, 425)
        Me.grdSolicitaCambios.TabIndex = 74
        Me.grdSolicitaCambios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwSolicitaCambios})
        '
        'vwSolicitaCambios
        '
        Me.vwSolicitaCambios.ActiveFilterEnabled = False
        Me.vwSolicitaCambios.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.vwSolicitaCambios.GridControl = Me.grdSolicitaCambios
        Me.vwSolicitaCambios.Name = "vwSolicitaCambios"
        Me.vwSolicitaCambios.OptionsCustomization.AllowBandMoving = False
        Me.vwSolicitaCambios.OptionsCustomization.AllowColumnMoving = False
        Me.vwSolicitaCambios.OptionsCustomization.AllowFilter = False
        Me.vwSolicitaCambios.OptionsCustomization.AllowGroup = False
        Me.vwSolicitaCambios.OptionsCustomization.AllowSort = False
        Me.vwSolicitaCambios.OptionsFilter.AllowFilterEditor = False
        Me.vwSolicitaCambios.OptionsMenu.EnableColumnMenu = False
        Me.vwSolicitaCambios.OptionsView.ColumnAutoWidth = False
        Me.vwSolicitaCambios.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwSolicitaCambios.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.vwSolicitaCambios.OptionsView.ShowDetailButtons = False
        Me.vwSolicitaCambios.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.vwSolicitaCambios.OptionsView.ShowGroupPanel = False
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(324, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'Programacion_BalanceoNaves_SolicitaModificaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1198, 545)
        Me.Controls.Add(Me.grdSolicitaCambios)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Programacion_BalanceoNaves_SolicitaModificaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Solicita Cambios Balanceo Naves"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlConteo.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        CType(Me.grdSolicitaCambios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwSolicitaCambios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents bntSalir As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdSolicitaCambios As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwSolicitaCambios As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSemanaFecha As Label
    Friend WithEvents pnlConteo As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pbYuyin As PictureBox
End Class
