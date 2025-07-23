<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LotesAndreaGenerarXML_form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LotesAndreaGenerarXML_form))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtmFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlArchivosGeneradosAntes = New System.Windows.Forms.Panel()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnGenerarArchivos = New System.Windows.Forms.Button()
        Me.lblGenerarArchivos = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdLotesAndrea = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.cmsTipoArchivoGenerar = New System.Windows.Forms.ContextMenuStrip()
        Me.PorLoteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompletoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.grdLotesAndrea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTipoArchivoGenerar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(499, 59)
        Me.pnlEncabezado.TabIndex = 67
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(499, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.chkSeleccionar)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtmFechaInicio)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(431, 59)
        Me.Panel1.TabIndex = 47
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(17, 40)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(82, 17)
        Me.chkSeleccionar.TabIndex = 52
        Me.chkSeleccionar.Text = "Seleccionar"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 48
        Me.Label3.Text = "Fecha confirmación:"
        '
        'dtmFechaInicio
        '
        Me.dtmFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtmFechaInicio.Location = New System.Drawing.Point(124, 19)
        Me.dtmFechaInicio.Name = "dtmFechaInicio"
        Me.dtmFechaInicio.Size = New System.Drawing.Size(82, 20)
        Me.dtmFechaInicio.TabIndex = 47
        Me.dtmFechaInicio.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(306, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(117, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Lotes Andrea"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(431, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Label2)
        Me.pnlPie.Controls.Add(Me.pnlArchivosGeneradosAntes)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 337)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(499, 71)
        Me.pnlPie.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(122, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 26)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Archivos generados" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "anteriormente"
        '
        'pnlArchivosGeneradosAntes
        '
        Me.pnlArchivosGeneradosAntes.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.pnlArchivosGeneradosAntes.Location = New System.Drawing.Point(105, 27)
        Me.pnlArchivosGeneradosAntes.Name = "pnlArchivosGeneradosAntes"
        Me.pnlArchivosGeneradosAntes.Size = New System.Drawing.Size(13, 15)
        Me.pnlArchivosGeneradosAntes.TabIndex = 39
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnBuscar)
        Me.pnlDatosBotones.Controls.Add(Me.Label4)
        Me.pnlDatosBotones.Controls.Add(Me.btnGenerarArchivos)
        Me.pnlDatosBotones.Controls.Add(Me.lblGenerarArchivos)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(306, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(193, 71)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnBuscar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_321
        Me.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBuscar.Location = New System.Drawing.Point(42, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 6
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(37, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Mostrar"
        '
        'btnGenerarArchivos
        '
        Me.btnGenerarArchivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarArchivos.Image = Global.Ventas.Vista.My.Resources.Resources.aceptar_32
        Me.btnGenerarArchivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGenerarArchivos.Location = New System.Drawing.Point(95, 8)
        Me.btnGenerarArchivos.Name = "btnGenerarArchivos"
        Me.btnGenerarArchivos.Size = New System.Drawing.Size(32, 32)
        Me.btnGenerarArchivos.TabIndex = 4
        Me.btnGenerarArchivos.UseVisualStyleBackColor = True
        '
        'lblGenerarArchivos
        '
        Me.lblGenerarArchivos.AutoSize = True
        Me.lblGenerarArchivos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGenerarArchivos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGenerarArchivos.Location = New System.Drawing.Point(92, 41)
        Me.lblGenerarArchivos.Name = "lblGenerarArchivos"
        Me.lblGenerarArchivos.Size = New System.Drawing.Size(48, 26)
        Me.lblGenerarArchivos.TabIndex = 3
        Me.lblGenerarArchivos.Text = "Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Archivos"
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(148, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(148, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(9, 33)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 116
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdLotesAndrea)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(499, 278)
        Me.Panel2.TabIndex = 70
        '
        'grdLotesAndrea
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotesAndrea.DisplayLayout.Appearance = Appearance1
        Me.grdLotesAndrea.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdLotesAndrea.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdLotesAndrea.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdLotesAndrea.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdLotesAndrea.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLotesAndrea.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdLotesAndrea.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLotesAndrea.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdLotesAndrea.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdLotesAndrea.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotesAndrea.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.grdLotesAndrea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLotesAndrea.Location = New System.Drawing.Point(0, 0)
        Me.grdLotesAndrea.Name = "grdLotesAndrea"
        Me.grdLotesAndrea.Size = New System.Drawing.Size(499, 278)
        Me.grdLotesAndrea.TabIndex = 72
        '
        'cmsTipoArchivoGenerar
        '
        Me.cmsTipoArchivoGenerar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorLoteToolStripMenuItem, Me.CompletoToolStripMenuItem})
        Me.cmsTipoArchivoGenerar.Name = "cmsTipoArchivoGenerar"
        Me.cmsTipoArchivoGenerar.Size = New System.Drawing.Size(120, 48)
        '
        'PorLoteToolStripMenuItem
        '
        Me.PorLoteToolStripMenuItem.Name = "PorLoteToolStripMenuItem"
        Me.PorLoteToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.PorLoteToolStripMenuItem.Text = "Por lote"
        '
        'CompletoToolStripMenuItem
        '
        Me.CompletoToolStripMenuItem.Name = "CompletoToolStripMenuItem"
        Me.CompletoToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.CompletoToolStripMenuItem.Text = "Completo"
        '
        'LotesAndreaGenerarXML_form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 408)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlPie)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LotesAndreaGenerarXML_form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lotes Andrea"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdLotesAndrea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTipoArchivoGenerar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnGenerarArchivos As System.Windows.Forms.Button
    Friend WithEvents lblGenerarArchivos As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents grdLotesAndrea As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlArchivosGeneradosAntes As System.Windows.Forms.Panel
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents cmsTipoArchivoGenerar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PorLoteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompletoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtmFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
End Class
