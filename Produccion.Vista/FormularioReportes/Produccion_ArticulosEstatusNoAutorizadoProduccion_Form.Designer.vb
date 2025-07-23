<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Produccion_ArticulosEstatusNoAutorizadoProduccion_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Produccion_ArticulosEstatusNoAutorizadoProduccion_Form))
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.lblImprimirOrdenCompra = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlInformacionAlta = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdArticulosNoAutorizados = New DevExpress.XtraGrid.GridControl()
        Me.VArticulosNoAutorizados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.cboNave2 = New System.Windows.Forms.ComboBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.pnlContenido = New System.Windows.Forms.Panel()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlInformacionAlta.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdArticulosNoAutorizados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VArticulosNoAutorizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlContenido.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblImprimirOrdenCompra)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pbYuyin)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(942, 63)
        Me.pnlEncabezado.TabIndex = 2018
        '
        'lblImprimirOrdenCompra
        '
        Me.lblImprimirOrdenCompra.AutoSize = True
        Me.lblImprimirOrdenCompra.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirOrdenCompra.Location = New System.Drawing.Point(16, 40)
        Me.lblImprimirOrdenCompra.Name = "lblImprimirOrdenCompra"
        Me.lblImprimirOrdenCompra.Size = New System.Drawing.Size(46, 13)
        Me.lblImprimirOrdenCompra.TabIndex = 109
        Me.lblImprimirOrdenCompra.Text = "Exportar"
        Me.lblImprimirOrdenCompra.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(22, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 108
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(571, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(301, 20)
        Me.lblTitulo.TabIndex = 21
        Me.lblTitulo.Text = "Artículos No Autorizados Producción"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(874, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 63)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.pnlBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 492)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(942, 71)
        Me.pnlPie.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCerrar)
        Me.pnlBotones.Controls.Add(Me.lblCancelar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(825, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(117, 71)
        Me.pnlBotones.TabIndex = 2
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(64, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(65, 48)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 4
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlInformacionAlta
        '
        Me.pnlInformacionAlta.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlInformacionAlta.Controls.Add(Me.Panel2)
        Me.pnlInformacionAlta.Controls.Add(Me.pnlParametros)
        Me.pnlInformacionAlta.Controls.Add(Me.pnlEncabezado)
        Me.pnlInformacionAlta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacionAlta.Location = New System.Drawing.Point(0, 0)
        Me.pnlInformacionAlta.Name = "pnlInformacionAlta"
        Me.pnlInformacionAlta.Size = New System.Drawing.Size(942, 492)
        Me.pnlInformacionAlta.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdArticulosNoAutorizados)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(942, 328)
        Me.Panel2.TabIndex = 2021
        '
        'grdArticulosNoAutorizados
        '
        Me.grdArticulosNoAutorizados.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdArticulosNoAutorizados.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdArticulosNoAutorizados.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdArticulosNoAutorizados.Location = New System.Drawing.Point(0, 0)
        Me.grdArticulosNoAutorizados.MainView = Me.VArticulosNoAutorizados
        Me.grdArticulosNoAutorizados.Name = "grdArticulosNoAutorizados"
        Me.grdArticulosNoAutorizados.Size = New System.Drawing.Size(942, 328)
        Me.grdArticulosNoAutorizados.TabIndex = 13
        Me.grdArticulosNoAutorizados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.VArticulosNoAutorizados})
        '
        'VArticulosNoAutorizados
        '
        Me.VArticulosNoAutorizados.GridControl = Me.grdArticulosNoAutorizados
        Me.VArticulosNoAutorizados.Name = "VArticulosNoAutorizados"
        Me.VArticulosNoAutorizados.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.VArticulosNoAutorizados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.VArticulosNoAutorizados.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.VArticulosNoAutorizados.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.VArticulosNoAutorizados.OptionsPrint.AllowMultilineHeaders = True
        Me.VArticulosNoAutorizados.OptionsSelection.MultiSelect = True
        Me.VArticulosNoAutorizados.OptionsView.ColumnAutoWidth = False
        Me.VArticulosNoAutorizados.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.VArticulosNoAutorizados.OptionsView.ShowFooter = True
        Me.VArticulosNoAutorizados.OptionsView.ShowGroupPanel = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.cboNave2)
        Me.pnlParametros.Controls.Add(Me.cboGrupo)
        Me.pnlParametros.Controls.Add(Me.Label3)
        Me.pnlParametros.Controls.Add(Me.dtpFechaFin)
        Me.pnlParametros.Controls.Add(Me.dtpFechaInicio)
        Me.pnlParametros.Controls.Add(Me.lblMostrar)
        Me.pnlParametros.Controls.Add(Me.Panel6)
        Me.pnlParametros.Controls.Add(Me.btnLimpiar)
        Me.pnlParametros.Controls.Add(Me.Label2)
        Me.pnlParametros.Controls.Add(Me.btnMostrar)
        Me.pnlParametros.Controls.Add(Me.Label1)
        Me.pnlParametros.Controls.Add(Me.lblNave)
        Me.pnlParametros.Controls.Add(Me.lblLimpiar)
        Me.pnlParametros.Controls.Add(Me.cmbNave)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 63)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(942, 101)
        Me.pnlParametros.TabIndex = 2020
        '
        'cboNave2
        '
        Me.cboNave2.FormattingEnabled = True
        Me.cboNave2.Location = New System.Drawing.Point(201, 44)
        Me.cboNave2.Name = "cboNave2"
        Me.cboNave2.Size = New System.Drawing.Size(159, 21)
        Me.cboNave2.TabIndex = 152
        '
        'cboGrupo
        '
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(64, 44)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(89, 21)
        Me.cboGrupo.TabIndex = 131
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Grupo:"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFin.Location = New System.Drawing.Point(616, 44)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaFin.TabIndex = 130
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(490, 44)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaInicio.TabIndex = 130
        '
        'lblMostrar
        '
        Me.lblMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(840, 70)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 129
        Me.lblMostrar.Text = "Mostrar"
        Me.lblMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnAbajo)
        Me.Panel6.Controls.Add(Me.btnArriba)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(942, 27)
        Me.Panel6.TabIndex = 68
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.BackColor = System.Drawing.Color.White
        Me.btnAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnAbajo.Image = Global.Produccion.Vista.My.Resources.Resources._1373584074_navigate_down
        Me.btnAbajo.Location = New System.Drawing.Point(882, 3)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 38
        Me.btnAbajo.UseVisualStyleBackColor = False
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.BackColor = System.Drawing.Color.White
        Me.btnArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnArriba.Image = Global.Produccion.Vista.My.Resources.Resources._1373584033_navigate_up
        Me.btnArriba.Location = New System.Drawing.Point(908, 3)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 37
        Me.btnArriba.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.Image = Global.Produccion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(896, 33)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 126
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(594, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "a:"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_321
        Me.btnMostrar.Location = New System.Drawing.Point(845, 33)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 128
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(379, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Fecha Programa de:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(159, 47)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 67
        Me.lblNave.Text = "Nave:"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(893, 70)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 127
        Me.lblLimpiar.Text = "Limpiar"
        Me.lblLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbNave
        '
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(201, 44)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(159, 21)
        Me.cmbNave.TabIndex = 66
        '
        'pnlContenido
        '
        Me.pnlContenido.Controls.Add(Me.pnlInformacionAlta)
        Me.pnlContenido.Controls.Add(Me.pnlPie)
        Me.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenido.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenido.Name = "pnlContenido"
        Me.pnlContenido.Size = New System.Drawing.Size(942, 563)
        Me.pnlContenido.TabIndex = 4
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlContenido)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(942, 563)
        Me.pnlContenedor.TabIndex = 3
        '
        'Produccion_ArticulosEstatusNoAutorizadoProduccion_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 563)
        Me.Controls.Add(Me.pnlContenedor)
        Me.MinimumSize = New System.Drawing.Size(950, 590)
        Me.Name = "Produccion_ArticulosEstatusNoAutorizadoProduccion_Form"
        Me.Text = "Artículos No Autorizados Producción"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlInformacionAlta.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdArticulosNoAutorizados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VArticulosNoAutorizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.pnlContenido.ResumeLayout(False)
        Me.pnlContenedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents lblImprimirOrdenCompra As Label
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCancelar As Label
    Friend WithEvents pnlInformacionAlta As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents grdArticulosNoAutorizados As DevExpress.XtraGrid.GridControl
    Friend WithEvents VArticulosNoAutorizados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents pnlContenido As Panel
    Friend WithEvents pnlContenedor As Panel
    Friend WithEvents lblNave As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnAbajo As Button
    Friend WithEvents btnArriba As Button
    Friend WithEvents cmbNave As ComboBox
    Friend WithEvents dtpFechaFin As DateTimePicker
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents lblMostrar As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblLimpiar As Label
    Friend WithEvents cboGrupo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboNave2 As ComboBox
End Class
