<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConsultaLotesForm
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLotesGrfImagen = New System.Windows.Forms.Button()
        Me.lblEtiquetasPrueba = New System.Windows.Forms.Label()
        Me.btnEtiquetaPruebas = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblConsultaInventarioNaves = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.lblImprimirEtiquetas = New System.Windows.Forms.Label()
        Me.btnImprimirEtiquetas = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.cmbImpresoras = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtmFechaPrograma = New System.Windows.Forms.DateTimePicker()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdConsultaLotes = New DevExpress.XtraGrid.GridControl()
        Me.ViewConsultaDeLotes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalLotes = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdConsultaLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewConsultaDeLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1276, 65)
        Me.pnlEncabezado.TabIndex = 28
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(703, 65)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label4)
        Me.Panel14.Controls.Add(Me.btnLotesGrfImagen)
        Me.Panel14.Controls.Add(Me.lblEtiquetasPrueba)
        Me.Panel14.Controls.Add(Me.btnEtiquetaPruebas)
        Me.Panel14.Controls.Add(Me.Label1)
        Me.Panel14.Controls.Add(Me.btnExportarExcel)
        Me.Panel14.Controls.Add(Me.lblConsultaInventarioNaves)
        Me.Panel14.Controls.Add(Me.btnImprimir)
        Me.Panel14.Controls.Add(Me.lblImprimirEtiquetas)
        Me.Panel14.Controls.Add(Me.btnImprimirEtiquetas)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(703, 65)
        Me.Panel14.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(269, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 26)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Lotes Sin " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "GRG/Imagen"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLotesGrfImagen
        '
        Me.btnLotesGrfImagen.BackColor = System.Drawing.Color.Transparent
        Me.btnLotesGrfImagen.Image = Global.Programacion.Vista.My.Resources.Resources.Camara
        Me.btnLotesGrfImagen.Location = New System.Drawing.Point(287, 3)
        Me.btnLotesGrfImagen.Name = "btnLotesGrfImagen"
        Me.btnLotesGrfImagen.Size = New System.Drawing.Size(32, 32)
        Me.btnLotesGrfImagen.TabIndex = 91
        Me.btnLotesGrfImagen.UseVisualStyleBackColor = False
        '
        'lblEtiquetasPrueba
        '
        Me.lblEtiquetasPrueba.AutoSize = True
        Me.lblEtiquetasPrueba.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEtiquetasPrueba.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEtiquetasPrueba.Location = New System.Drawing.Point(212, 38)
        Me.lblEtiquetasPrueba.Name = "lblEtiquetasPrueba"
        Me.lblEtiquetasPrueba.Size = New System.Drawing.Size(51, 26)
        Me.lblEtiquetasPrueba.TabIndex = 90
        Me.lblEtiquetasPrueba.Text = "Etiquetas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Prueba"
        '
        'btnEtiquetaPruebas
        '
        Me.btnEtiquetaPruebas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEtiquetaPruebas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnEtiquetaPruebas.Image = Global.Programacion.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.btnEtiquetaPruebas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEtiquetaPruebas.Location = New System.Drawing.Point(214, 3)
        Me.btnEtiquetaPruebas.Name = "btnEtiquetaPruebas"
        Me.btnEtiquetaPruebas.Size = New System.Drawing.Size(32, 32)
        Me.btnEtiquetaPruebas.TabIndex = 89
        Me.btnEtiquetaPruebas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(140, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 88
        Me.Label1.Text = "Exportar"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(148, 3)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 87
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblConsultaInventarioNaves
        '
        Me.lblConsultaInventarioNaves.AutoSize = True
        Me.lblConsultaInventarioNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblConsultaInventarioNaves.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaInventarioNaves.Location = New System.Drawing.Point(12, 38)
        Me.lblConsultaInventarioNaves.Name = "lblConsultaInventarioNaves"
        Me.lblConsultaInventarioNaves.Size = New System.Drawing.Size(42, 13)
        Me.lblConsultaInventarioNaves.TabIndex = 86
        Me.lblConsultaInventarioNaves.Text = "Imprimir"
        Me.lblConsultaInventarioNaves.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(16, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 85
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'lblImprimirEtiquetas
        '
        Me.lblImprimirEtiquetas.AutoSize = True
        Me.lblImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImprimirEtiquetas.Location = New System.Drawing.Point(73, 38)
        Me.lblImprimirEtiquetas.Name = "lblImprimirEtiquetas"
        Me.lblImprimirEtiquetas.Size = New System.Drawing.Size(51, 13)
        Me.lblImprimirEtiquetas.TabIndex = 84
        Me.lblImprimirEtiquetas.Text = "Etiquetas"
        '
        'btnImprimirEtiquetas
        '
        Me.btnImprimirEtiquetas.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImprimirEtiquetas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimirEtiquetas.Image = Global.Programacion.Vista.My.Resources.Resources.ImprimirEtiquetas
        Me.btnImprimirEtiquetas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImprimirEtiquetas.Location = New System.Drawing.Point(82, 3)
        Me.btnImprimirEtiquetas.Name = "btnImprimirEtiquetas"
        Me.btnImprimirEtiquetas.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirEtiquetas.TabIndex = 82
        Me.btnImprimirEtiquetas.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(871, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(405, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(120, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(155, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Consulta de Lotes"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(322, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.chkSeleccionar)
        Me.Panel1.Controls.Add(Me.cmbImpresoras)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtmFechaPrograma)
        Me.Panel1.Controls.Add(Me.cmbNave)
        Me.Panel1.Controls.Add(Me.lblDepartamento)
        Me.Panel1.Controls.Add(Me.lblNave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1276, 68)
        Me.Panel1.TabIndex = 29
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(13, 39)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(82, 17)
        Me.chkSeleccionar.TabIndex = 53
        Me.chkSeleccionar.Text = "Seleccionar"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'cmbImpresoras
        '
        Me.cmbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImpresoras.FormattingEnabled = True
        Me.cmbImpresoras.Items.AddRange(New Object() {"200dpi", "300dpi"})
        Me.cmbImpresoras.Location = New System.Drawing.Point(651, 9)
        Me.cmbImpresoras.Name = "cmbImpresoras"
        Me.cmbImpresoras.Size = New System.Drawing.Size(152, 21)
        Me.cmbImpresoras.TabIndex = 52
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(589, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Impresora:"
        '
        'dtmFechaPrograma
        '
        Me.dtmFechaPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaPrograma.Location = New System.Drawing.Point(336, 10)
        Me.dtmFechaPrograma.Name = "dtmFechaPrograma"
        Me.dtmFechaPrograma.Size = New System.Drawing.Size(239, 20)
        Me.dtmFechaPrograma.TabIndex = 49
        Me.dtmFechaPrograma.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(54, 10)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(173, 21)
        Me.cmbNave.TabIndex = 48
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(242, 13)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(88, 13)
        Me.lblDepartamento.TabIndex = 47
        Me.lblDepartamento.Text = "Fecha Programa:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(12, 13)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 46
        Me.lblNave.Text = "Nave:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(38, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(41, 6)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 50
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1276, 60)
        Me.Panel2.TabIndex = 30
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label2)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1114, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 60)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(99, 6)
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
        Me.lblCerrar.Location = New System.Drawing.Point(102, 38)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdConsultaLotes
        '
        Me.grdConsultaLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsultaLotes.Location = New System.Drawing.Point(0, 133)
        Me.grdConsultaLotes.MainView = Me.ViewConsultaDeLotes
        Me.grdConsultaLotes.Name = "grdConsultaLotes"
        Me.grdConsultaLotes.Size = New System.Drawing.Size(1276, 416)
        Me.grdConsultaLotes.TabIndex = 31
        Me.grdConsultaLotes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ViewConsultaDeLotes})
        '
        'ViewConsultaDeLotes
        '
        Me.ViewConsultaDeLotes.GridControl = Me.grdConsultaLotes
        Me.ViewConsultaDeLotes.Name = "ViewConsultaDeLotes"
        Me.ViewConsultaDeLotes.OptionsView.ShowAutoFilterRow = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(51, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total de lotes:"
        '
        'lblTotalLotes
        '
        Me.lblTotalLotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLotes.Location = New System.Drawing.Point(49, 22)
        Me.lblTotalLotes.Name = "lblTotalLotes"
        Me.lblTotalLotes.Size = New System.Drawing.Size(60, 23)
        Me.lblTotalLotes.TabIndex = 5
        Me.lblTotalLotes.Text = "0"
        Me.lblTotalLotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblTotalLotes)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(159, 60)
        Me.Panel3.TabIndex = 4
        '
        'ConsultaLotesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 609)
        Me.Controls.Add(Me.grdConsultaLotes)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ConsultaLotesForm"
        Me.Text = "Consulta de Lotes"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdConsultaLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewConsultaDeLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents lblImprimirEtiquetas As System.Windows.Forms.Label
    Friend WithEvents btnImprimirEtiquetas As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdConsultaLotes As DevExpress.XtraGrid.GridControl
    Friend WithEvents ViewConsultaDeLotes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbImpresoras As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents dtmFechaPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblConsultaInventarioNaves As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblEtiquetasPrueba As System.Windows.Forms.Label
    Friend WithEvents btnEtiquetaPruebas As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnLotesGrfImagen As Button
    Friend WithEvents lblTotalLotes As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
End Class
