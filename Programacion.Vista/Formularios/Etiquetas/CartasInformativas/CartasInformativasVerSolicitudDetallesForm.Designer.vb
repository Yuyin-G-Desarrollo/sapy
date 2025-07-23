<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CartasInformativasVerSolicitudDetallesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasInformativasVerSolicitudDetallesForm))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdSolicitudDetalle = New DevExpress.XtraGrid.GridControl()
        Me.grdVSolicitudDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdSolicitudDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVSolicitudDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlHeader)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(704, 72)
        Me.pnlCabecera.TabIndex = 34
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(303, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(401, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEncabezado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(71, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(262, 72)
        Me.Panel2.TabIndex = 46
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(84, 14)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(173, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Cartas Informativas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ver Solicitud Detalle"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(333, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 72)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 296)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(704, 59)
        Me.pnlPie.TabIndex = 77
        '
        'lblParesProceso
        '
        Me.lblParesProceso.AutoSize = True
        Me.lblParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProceso.ForeColor = System.Drawing.Color.Black
        Me.lblParesProceso.Location = New System.Drawing.Point(30, 12)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(75, 16)
        Me.lblParesProceso.TabIndex = 126
        Me.lblParesProceso.Text = "Registros"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(30, 28)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 125
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.lblCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(539, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 59)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(106, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(109, 35)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 5
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdSolicitudDetalle
        '
        Me.grdSolicitudDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitudDetalle.Location = New System.Drawing.Point(0, 72)
        Me.grdSolicitudDetalle.MainView = Me.grdVSolicitudDetalle
        Me.grdSolicitudDetalle.Name = "grdSolicitudDetalle"
        Me.grdSolicitudDetalle.Size = New System.Drawing.Size(704, 224)
        Me.grdSolicitudDetalle.TabIndex = 166
        Me.grdSolicitudDetalle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVSolicitudDetalle})
        '
        'grdVSolicitudDetalle
        '
        Me.grdVSolicitudDetalle.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVSolicitudDetalle.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVSolicitudDetalle.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVSolicitudDetalle.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdVSolicitudDetalle.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVSolicitudDetalle.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdVSolicitudDetalle.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdVSolicitudDetalle.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdVSolicitudDetalle.GridControl = Me.grdSolicitudDetalle
        Me.grdVSolicitudDetalle.IndicatorWidth = 30
        Me.grdVSolicitudDetalle.Name = "grdVSolicitudDetalle"
        Me.grdVSolicitudDetalle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVSolicitudDetalle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVSolicitudDetalle.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdVSolicitudDetalle.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdVSolicitudDetalle.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVSolicitudDetalle.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVSolicitudDetalle.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdVSolicitudDetalle.OptionsView.ShowFooter = True
        Me.grdVSolicitudDetalle.OptionsView.ShowGroupPanel = False
        '
        'CartasInformativasVerSolicitudDetallesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 355)
        Me.Controls.Add(Me.grdSolicitudDetalle)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CartasInformativasVerSolicitudDetallesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cartas Informativas Ver Solicitudes Detalles"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdSolicitudDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVSolicitudDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdSolicitudDetalle As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVSolicitudDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblParesProceso As Label
    Friend WithEvents lblTotalRegistros As Label
End Class
