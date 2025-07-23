<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CartasInformativasPedidosDetallesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasInformativasPedidosDetallesForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblSalir = New System.Windows.Forms.Label()
        Me.grdPartidas = New DevExpress.XtraGrid.GridControl()
        Me.grdVPartidas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkVerTallas = New System.Windows.Forms.CheckBox()
        Me.txtPedidoSAY = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkSeleccionarTodo = New System.Windows.Forms.CheckBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.dtpFechaCaptura = New System.Windows.Forms.DateTimePicker()
        Me.txtAgente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.grdTallas = New DevExpress.XtraGrid.GridControl()
        Me.grdVTallas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVTallas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(819, 72)
        Me.pnlListaPaises.TabIndex = 33
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(418, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(401, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEncabezado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(52, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(281, 72)
        Me.Panel2.TabIndex = 46
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(14, 17)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(262, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Cartas Informativas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pedidos Por Entregar - Partidas"
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
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 429)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(819, 66)
        Me.pnlPie.TabIndex = 71
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.lblSalir)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(654, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 66)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(51, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 12
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardar.Location = New System.Drawing.Point(47, 36)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 13
        Me.lblGuardar.Text = "Guardar"
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
        'lblSalir
        '
        Me.lblSalir.AutoSize = True
        Me.lblSalir.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSalir.Location = New System.Drawing.Point(109, 35)
        Me.lblSalir.Name = "lblSalir"
        Me.lblSalir.Size = New System.Drawing.Size(35, 13)
        Me.lblSalir.TabIndex = 5
        Me.lblSalir.Text = "Cerrar"
        '
        'grdPartidas
        '
        Me.grdPartidas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPartidas.Location = New System.Drawing.Point(0, 0)
        Me.grdPartidas.MainView = Me.grdVPartidas
        Me.grdPartidas.Name = "grdPartidas"
        Me.grdPartidas.Size = New System.Drawing.Size(403, 239)
        Me.grdPartidas.TabIndex = 165
        Me.grdPartidas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVPartidas})
        '
        'grdVPartidas
        '
        Me.grdVPartidas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVPartidas.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVPartidas.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVPartidas.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdVPartidas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVPartidas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdVPartidas.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdVPartidas.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdVPartidas.GridControl = Me.grdPartidas
        Me.grdVPartidas.IndicatorWidth = 30
        Me.grdVPartidas.Name = "grdVPartidas"
        Me.grdVPartidas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVPartidas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVPartidas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdVPartidas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdVPartidas.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVPartidas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVPartidas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdVPartidas.OptionsView.ShowAutoFilterRow = True
        Me.grdVPartidas.OptionsView.ShowFooter = True
        Me.grdVPartidas.OptionsView.ShowGroupPanel = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.chkVerTallas)
        Me.Panel1.Controls.Add(Me.txtPedidoSAY)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.chkSeleccionarTodo)
        Me.Panel1.Controls.Add(Me.txtObservaciones)
        Me.Panel1.Controls.Add(Me.dtpFechaCaptura)
        Me.Panel1.Controls.Add(Me.txtAgente)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCliente)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(819, 118)
        Me.Panel1.TabIndex = 72
        '
        'chkVerTallas
        '
        Me.chkVerTallas.AutoSize = True
        Me.chkVerTallas.Location = New System.Drawing.Point(244, 88)
        Me.chkVerTallas.Name = "chkVerTallas"
        Me.chkVerTallas.Size = New System.Drawing.Size(73, 17)
        Me.chkVerTallas.TabIndex = 18
        Me.chkVerTallas.Text = "Ver Tallas"
        Me.chkVerTallas.UseVisualStyleBackColor = True
        '
        'txtPedidoSAY
        '
        Me.txtPedidoSAY.Enabled = False
        Me.txtPedidoSAY.Location = New System.Drawing.Point(487, 9)
        Me.txtPedidoSAY.Name = "txtPedidoSAY"
        Me.txtPedidoSAY.Size = New System.Drawing.Size(89, 20)
        Me.txtPedidoSAY.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(414, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Pedido SAY:"
        '
        'chkSeleccionarTodo
        '
        Me.chkSeleccionarTodo.AutoSize = True
        Me.chkSeleccionarTodo.Location = New System.Drawing.Point(128, 88)
        Me.chkSeleccionarTodo.Name = "chkSeleccionarTodo"
        Me.chkSeleccionarTodo.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarTodo.TabIndex = 15
        Me.chkSeleccionarTodo.Text = "Seleccionar Todo"
        Me.chkSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(487, 36)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(302, 69)
        Me.txtObservaciones.TabIndex = 14
        '
        'dtpFechaCaptura
        '
        Me.dtpFechaCaptura.Location = New System.Drawing.Point(128, 62)
        Me.dtpFechaCaptura.Name = "dtpFechaCaptura"
        Me.dtpFechaCaptura.Size = New System.Drawing.Size(255, 20)
        Me.dtpFechaCaptura.TabIndex = 13
        '
        'txtAgente
        '
        Me.txtAgente.Enabled = False
        Me.txtAgente.Location = New System.Drawing.Point(128, 35)
        Me.txtAgente.Name = "txtAgente"
        Me.txtAgente.Size = New System.Drawing.Size(255, 20)
        Me.txtAgente.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Fecha de Captura:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(400, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Observaciones:"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(128, 9)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(255, 20)
        Me.txtCliente.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Agente:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(80, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cliente:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.SplitContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 190)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(819, 239)
        Me.Panel3.TabIndex = 73
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdPartidas)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdTallas)
        Me.SplitContainer1.Size = New System.Drawing.Size(819, 239)
        Me.SplitContainer1.SplitterDistance = 403
        Me.SplitContainer1.TabIndex = 0
        '
        'grdTallas
        '
        Me.grdTallas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdTallas.Location = New System.Drawing.Point(0, 0)
        Me.grdTallas.MainView = Me.grdVTallas
        Me.grdTallas.Name = "grdTallas"
        Me.grdTallas.Size = New System.Drawing.Size(412, 239)
        Me.grdTallas.TabIndex = 166
        Me.grdTallas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVTallas})
        '
        'grdVTallas
        '
        Me.grdVTallas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVTallas.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVTallas.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVTallas.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdVTallas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVTallas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdVTallas.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdVTallas.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdVTallas.GridControl = Me.grdTallas
        Me.grdVTallas.IndicatorWidth = 30
        Me.grdVTallas.Name = "grdVTallas"
        Me.grdVTallas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVTallas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVTallas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdVTallas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdVTallas.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVTallas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVTallas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdVTallas.OptionsView.ShowAutoFilterRow = True
        Me.grdVTallas.OptionsView.ShowFooter = True
        Me.grdVTallas.OptionsView.ShowGroupPanel = False
        '
        'CartasInformativasPedidosDetallesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 495)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "CartasInformativasPedidosDetallesForm"
        Me.Text = "Cartas Informativas Pedido-Detalle"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        CType(Me.grdPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdTallas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVTallas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlListaPaises As Panel
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblSalir As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblGuardar As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents dtpFechaCaptura As DateTimePicker
    Friend WithEvents txtAgente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents chkSeleccionarTodo As CheckBox
    Friend WithEvents txtPedidoSAY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents grdPartidas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVPartidas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdTallas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVTallas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkVerTallas As CheckBox
End Class
