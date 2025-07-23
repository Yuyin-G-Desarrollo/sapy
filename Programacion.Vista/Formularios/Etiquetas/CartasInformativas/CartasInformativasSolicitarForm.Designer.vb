<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CartasInformativasSolicitarForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasInformativasSolicitarForm))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlSolCarta = New System.Windows.Forms.Panel()
        Me.btnSolicitarCarta = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboNaves = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaPrograma = New System.Windows.Forms.DateTimePicker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdCartas = New DevExpress.XtraGrid.GridControl()
        Me.grdVCartas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlSolCarta.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdCartas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVCartas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlSolCarta)
        Me.pnlCabecera.Controls.Add(Me.pnlHeader)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(819, 72)
        Me.pnlCabecera.TabIndex = 33
        '
        'pnlSolCarta
        '
        Me.pnlSolCarta.Controls.Add(Me.btnSolicitarCarta)
        Me.pnlSolCarta.Controls.Add(Me.Label4)
        Me.pnlSolCarta.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSolCarta.Location = New System.Drawing.Point(0, 0)
        Me.pnlSolCarta.Name = "pnlSolCarta"
        Me.pnlSolCarta.Size = New System.Drawing.Size(72, 72)
        Me.pnlSolCarta.TabIndex = 10
        '
        'btnSolicitarCarta
        '
        Me.btnSolicitarCarta.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSolicitarCarta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSolicitarCarta.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnSolicitarCarta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSolicitarCarta.Location = New System.Drawing.Point(22, 9)
        Me.btnSolicitarCarta.Name = "btnSolicitarCarta"
        Me.btnSolicitarCarta.Size = New System.Drawing.Size(32, 32)
        Me.btnSolicitarCarta.TabIndex = 12
        Me.btnSolicitarCarta.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(15, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Solicitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  Carta"
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
        Me.lblEncabezado.Location = New System.Drawing.Point(90, 14)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(166, 40)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Cartas Informativas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solicitar Carta"
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
        Me.pnlPie.Controls.Add(Me.Panel5)
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 396)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(819, 59)
        Me.pnlPie.TabIndex = 71
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lblActualizacion)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(521, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(215, 59)
        Me.Panel5.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Ultima actualización:"
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.Location = New System.Drawing.Point(110, 25)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(16, 13)
        Me.lblActualizacion.TabIndex = 80
        Me.lblActualizacion.Text = "..."
        '
        'lblParesProceso
        '
        Me.lblParesProceso.AutoSize = True
        Me.lblParesProceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProceso.ForeColor = System.Drawing.Color.Black
        Me.lblParesProceso.Location = New System.Drawing.Point(32, 14)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(75, 16)
        Me.lblParesProceso.TabIndex = 124
        Me.lblParesProceso.Text = "Registros"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(32, 30)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 123
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.lblCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(736, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(83, 59)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(24, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(24, 37)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 5
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cboNaves)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.dtpFechaPrograma)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(819, 64)
        Me.Panel3.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Nave:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Fecha de Programa:"
        Me.Label3.Visible = False
        '
        'cboNaves
        '
        Me.cboNaves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNaves.FormattingEnabled = True
        Me.cboNaves.Location = New System.Drawing.Point(143, 7)
        Me.cboNaves.Name = "cboNaves"
        Me.cboNaves.Size = New System.Drawing.Size(200, 21)
        Me.cboNaves.TabIndex = 18
        Me.cboNaves.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(652, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(165, 62)
        Me.Panel1.TabIndex = 16
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(102, 10)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 14
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(99, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Mostrar"
        '
        'dtpFechaPrograma
        '
        Me.dtpFechaPrograma.Location = New System.Drawing.Point(143, 35)
        Me.dtpFechaPrograma.Name = "dtpFechaPrograma"
        Me.dtpFechaPrograma.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaPrograma.TabIndex = 13
        Me.dtpFechaPrograma.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdCartas)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 136)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(819, 260)
        Me.Panel4.TabIndex = 75
        '
        'grdCartas
        '
        Me.grdCartas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCartas.Location = New System.Drawing.Point(0, 0)
        Me.grdCartas.MainView = Me.grdVCartas
        Me.grdCartas.Name = "grdCartas"
        Me.grdCartas.Size = New System.Drawing.Size(819, 260)
        Me.grdCartas.TabIndex = 165
        Me.grdCartas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVCartas})
        '
        'grdVCartas
        '
        Me.grdVCartas.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVCartas.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVCartas.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVCartas.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdVCartas.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVCartas.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdVCartas.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdVCartas.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdVCartas.GridControl = Me.grdCartas
        Me.grdVCartas.IndicatorWidth = 30
        Me.grdVCartas.Name = "grdVCartas"
        Me.grdVCartas.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVCartas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVCartas.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdVCartas.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdVCartas.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVCartas.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVCartas.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdVCartas.OptionsView.ShowAutoFilterRow = True
        Me.grdVCartas.OptionsView.ShowFooter = True
        Me.grdVCartas.OptionsView.ShowGroupPanel = False
        '
        'CartasInformativasSolicitarForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 455)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "CartasInformativasSolicitarForm"
        Me.Text = "Solicitar Carta"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlSolCarta.ResumeLayout(False)
        Me.pnlSolCarta.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdCartas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVCartas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlSolCarta As Panel
    Friend WithEvents btnSolicitarCarta As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblActualizacion As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaPrograma As DateTimePicker
    Friend WithEvents cboNaves As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents grdCartas As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVCartas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblParesProceso As Label
    Friend WithEvents lblTotalRegistros As Label
End Class
