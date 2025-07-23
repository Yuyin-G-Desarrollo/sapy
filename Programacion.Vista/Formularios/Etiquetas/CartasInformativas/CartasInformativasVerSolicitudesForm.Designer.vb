<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CartasInformativasVerSolicitudesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CartasInformativasVerSolicitudesForm))
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlRechazar = New System.Windows.Forms.Panel()
        Me.btnRechazarCarta = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnSolicitarCarta = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkFechas = New System.Windows.Forms.CheckBox()
        Me.txtPedidoSay = New System.Windows.Forms.TextBox()
        Me.cboEstatus = New System.Windows.Forms.ComboBox()
        Me.gpoFechas = New System.Windows.Forms.GroupBox()
        Me.dtpAl = New System.Windows.Forms.DateTimePicker()
        Me.dtpDel = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.lblParesProceso = New System.Windows.Forms.Label()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdSolicitud = New DevExpress.XtraGrid.GridControl()
        Me.grdVSolicitud = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlRechazar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.gpoFechas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlRechazar)
        Me.pnlCabecera.Controls.Add(Me.pnlAutorizar)
        Me.pnlCabecera.Controls.Add(Me.pnlHeader)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(990, 72)
        Me.pnlCabecera.TabIndex = 34
        '
        'pnlRechazar
        '
        Me.pnlRechazar.Controls.Add(Me.btnRechazarCarta)
        Me.pnlRechazar.Controls.Add(Me.Label8)
        Me.pnlRechazar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRechazar.Location = New System.Drawing.Point(72, 0)
        Me.pnlRechazar.Name = "pnlRechazar"
        Me.pnlRechazar.Size = New System.Drawing.Size(72, 72)
        Me.pnlRechazar.TabIndex = 11
        '
        'btnRechazarCarta
        '
        Me.btnRechazarCarta.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRechazarCarta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnRechazarCarta.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
        Me.btnRechazarCarta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnRechazarCarta.Location = New System.Drawing.Point(20, 9)
        Me.btnRechazarCarta.Name = "btnRechazarCarta"
        Me.btnRechazarCarta.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazarCarta.TabIndex = 12
        Me.btnRechazarCarta.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(10, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 26)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Rechazar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Carta"
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnSolicitarCarta)
        Me.pnlAutorizar.Controls.Add(Me.Label4)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(0, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(72, 72)
        Me.pnlAutorizar.TabIndex = 10
        '
        'btnSolicitarCarta
        '
        Me.btnSolicitarCarta.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSolicitarCarta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnSolicitarCarta.Image = Global.Programacion.Vista.My.Resources.Resources.autorizar_32
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
        Me.Label4.Size = New System.Drawing.Size(54, 26)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Autorizar  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "   Carta"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.Panel2)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(589, 0)
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
        Me.lblEncabezado.Text = "Cartas Informativas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ver Solicitudes"
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 72)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(990, 74)
        Me.Panel3.TabIndex = 75
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.chkFechas)
        Me.Panel6.Controls.Add(Me.txtPedidoSay)
        Me.Panel6.Controls.Add(Me.cboEstatus)
        Me.Panel6.Controls.Add(Me.gpoFechas)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(661, 72)
        Me.Panel6.TabIndex = 86
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(406, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Estatus:"
        '
        'chkFechas
        '
        Me.chkFechas.AutoSize = True
        Me.chkFechas.Location = New System.Drawing.Point(21, 5)
        Me.chkFechas.Name = "chkFechas"
        Me.chkFechas.Size = New System.Drawing.Size(75, 17)
        Me.chkFechas.TabIndex = 86
        Me.chkFechas.Text = "Por Fecha"
        Me.chkFechas.UseVisualStyleBackColor = True
        '
        'txtPedidoSay
        '
        Me.txtPedidoSay.Location = New System.Drawing.Point(457, 17)
        Me.txtPedidoSay.Name = "txtPedidoSay"
        Me.txtPedidoSay.Size = New System.Drawing.Size(127, 20)
        Me.txtPedidoSay.TabIndex = 85
        '
        'cboEstatus
        '
        Me.cboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstatus.FormattingEnabled = True
        Me.cboEstatus.Location = New System.Drawing.Point(457, 42)
        Me.cboEstatus.Name = "cboEstatus"
        Me.cboEstatus.Size = New System.Drawing.Size(127, 21)
        Me.cboEstatus.TabIndex = 87
        '
        'gpoFechas
        '
        Me.gpoFechas.Controls.Add(Me.dtpAl)
        Me.gpoFechas.Controls.Add(Me.dtpDel)
        Me.gpoFechas.Controls.Add(Me.Label5)
        Me.gpoFechas.Controls.Add(Me.Label3)
        Me.gpoFechas.Enabled = False
        Me.gpoFechas.Location = New System.Drawing.Point(104, 2)
        Me.gpoFechas.Name = "gpoFechas"
        Me.gpoFechas.Size = New System.Drawing.Size(264, 67)
        Me.gpoFechas.TabIndex = 83
        Me.gpoFechas.TabStop = False
        Me.gpoFechas.Text = "Fecha de Solicitud"
        '
        'dtpAl
        '
        Me.dtpAl.Location = New System.Drawing.Point(48, 40)
        Me.dtpAl.Name = "dtpAl"
        Me.dtpAl.Size = New System.Drawing.Size(200, 20)
        Me.dtpAl.TabIndex = 82
        '
        'dtpDel
        '
        Me.dtpDel.Location = New System.Drawing.Point(48, 16)
        Me.dtpDel.Name = "dtpDel"
        Me.dtpDel.Size = New System.Drawing.Size(200, 20)
        Me.dtpDel.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Al:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Del:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(384, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Pedido SAY:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(823, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(165, 72)
        Me.Panel1.TabIndex = 16
        '
        'btnMostrar
        '
        Me.btnMostrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(98, 14)
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
        Me.Label1.Location = New System.Drawing.Point(95, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Mostrar"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.SystemColors.Control
        Me.pnlPie.Controls.Add(Me.Panel4)
        Me.pnlPie.Controls.Add(Me.lblParesProceso)
        Me.pnlPie.Controls.Add(Me.lblTotalRegistros)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 459)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(990, 59)
        Me.pnlPie.TabIndex = 76
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.lblActualizacion)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(617, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(292, 59)
        Me.Panel4.TabIndex = 129
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Ultima actualización:"
        '
        'lblActualizacion
        '
        Me.lblActualizacion.AutoSize = True
        Me.lblActualizacion.Location = New System.Drawing.Point(123, 25)
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
        Me.lblParesProceso.Location = New System.Drawing.Point(19, 12)
        Me.lblParesProceso.Name = "lblParesProceso"
        Me.lblParesProceso.Size = New System.Drawing.Size(75, 16)
        Me.lblParesProceso.TabIndex = 128
        Me.lblParesProceso.Text = "Registros"
        Me.lblParesProceso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(19, 28)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalRegistros.TabIndex = 127
        Me.lblTotalRegistros.Text = "0"
        Me.lblTotalRegistros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnSalir)
        Me.pnlAcciones.Controls.Add(Me.lblCerrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(909, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(81, 59)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(18, 6)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(21, 37)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 5
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdSolicitud)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 146)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(990, 313)
        Me.Panel5.TabIndex = 77
        '
        'grdSolicitud
        '
        Me.grdSolicitud.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSolicitud.Location = New System.Drawing.Point(0, 0)
        Me.grdSolicitud.MainView = Me.grdVSolicitud
        Me.grdSolicitud.Name = "grdSolicitud"
        Me.grdSolicitud.Size = New System.Drawing.Size(990, 313)
        Me.grdSolicitud.TabIndex = 166
        Me.grdSolicitud.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVSolicitud})
        '
        'grdVSolicitud
        '
        Me.grdVSolicitud.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVSolicitud.Appearance.FocusedRow.Options.UseBackColor = True
        Me.grdVSolicitud.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.grdVSolicitud.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.grdVSolicitud.Appearance.SelectedRow.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.grdVSolicitud.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White
        Me.grdVSolicitud.Appearance.SelectedRow.Options.UseBackColor = True
        Me.grdVSolicitud.Appearance.SelectedRow.Options.UseForeColor = True
        Me.grdVSolicitud.GridControl = Me.grdSolicitud
        Me.grdVSolicitud.IndicatorWidth = 30
        Me.grdVSolicitud.Name = "grdVSolicitud"
        Me.grdVSolicitud.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVSolicitud.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.grdVSolicitud.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.grdVSolicitud.OptionsMenu.ShowGroupSummaryEditorItem = True
        Me.grdVSolicitud.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVSolicitud.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grdVSolicitud.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.grdVSolicitud.OptionsView.ShowAutoFilterRow = True
        Me.grdVSolicitud.OptionsView.ShowFooter = True
        Me.grdVSolicitud.OptionsView.ShowGroupPanel = False
        '
        'CartasInformativasVerSolicitudesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 518)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlCabecera)
        Me.Name = "CartasInformativasVerSolicitudesForm"
        Me.Text = "Cartas Informativas Ver Solicitudes"
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlRechazar.ResumeLayout(False)
        Me.pnlRechazar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.gpoFechas.ResumeLayout(False)
        Me.gpoFechas.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlCabecera As Panel
    Friend WithEvents pnlAutorizar As Panel
    Friend WithEvents btnSolicitarCarta As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEncabezado As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMostrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDel As DateTimePicker
    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblActualizacion As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents pnlAcciones As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlRechazar As Panel
    Friend WithEvents btnRechazarCarta As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpAl As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents grdSolicitud As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVSolicitud As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gpoFechas As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblParesProceso As Label
    Friend WithEvents lblTotalRegistros As Label
    Friend WithEvents txtPedidoSay As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents cboEstatus As ComboBox
    Friend WithEvents chkFechas As CheckBox
End Class
