<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AgendaEntregasForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AgendaEntregasForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblNumFiltrados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdAgendaEntregas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdAgendaEntregas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.Panel11)
        Me.pnlEncabezado.Controls.Add(Me.lblExportar)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1199, 59)
        Me.pnlEncabezado.TabIndex = 71
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.pbYuyin)
        Me.Panel11.Controls.Add(Me.lblTitulo)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel11.Location = New System.Drawing.Point(918, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(281, 59)
        Me.Panel11.TabIndex = 55
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(213, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 48
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(19, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(174, 20)
        Me.lblTitulo.TabIndex = 47
        Me.lblTitulo.Text = "Agenda de Entregas"
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(8, 36)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 19
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.Location = New System.Drawing.Point(12, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 11
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.lblNumFiltrados)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 427)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1199, 61)
        Me.pnlPie.TabIndex = 73
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(389, 25)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 123
        Me.lblFechaUltimaActualizacion.Text = "24/05/2016 01:54 PM"
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(277, 25)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 124
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNumFiltrados
        '
        Me.lblNumFiltrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumFiltrados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNumFiltrados.Location = New System.Drawing.Point(44, 27)
        Me.lblNumFiltrados.Name = "lblNumFiltrados"
        Me.lblNumFiltrados.Size = New System.Drawing.Size(86, 24)
        Me.lblNumFiltrados.TabIndex = 118
        Me.lblNumFiltrados.Text = "0"
        Me.lblNumFiltrados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(47, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 24)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Registros"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label3)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1044, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(155, 61)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(93, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(96, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdAgendaEntregas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1199, 368)
        Me.Panel1.TabIndex = 74
        '
        'grdAgendaEntregas
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdAgendaEntregas.DisplayLayout.Appearance = Appearance1
        Me.grdAgendaEntregas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdAgendaEntregas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdAgendaEntregas.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdAgendaEntregas.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdAgendaEntregas.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdAgendaEntregas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdAgendaEntregas.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdAgendaEntregas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdAgendaEntregas.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdAgendaEntregas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdAgendaEntregas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAgendaEntregas.Location = New System.Drawing.Point(0, 0)
        Me.grdAgendaEntregas.Name = "grdAgendaEntregas"
        Me.grdAgendaEntregas.Size = New System.Drawing.Size(1199, 368)
        Me.grdAgendaEntregas.TabIndex = 65
        '
        'AgendaEntregasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1199, 488)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MinimumSize = New System.Drawing.Size(1207, 515)
        Me.Name = "AgendaEntregasForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agenda de Entregas"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdAgendaEntregas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdAgendaEntregas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents lblNumFiltrados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
End Class
