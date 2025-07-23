<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CargaBasesSimulacionForm
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
        Me.components = New System.ComponentModel.Container()
        Dim DateButton1 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim DateButton2 As Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton = New Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.grdBase = New DevExpress.XtraGrid.GridControl()
        Me.ViewConsultaBaseSimula = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.txtLogErrores = New System.Windows.Forms.TextBox()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.uccFechaIni = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.uccFechaFin = New Infragistics.Win.UltraWinSchedule.UltraCalendarCombo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.cmbBase = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.utcManejoCarga = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.opCargaExcel = New System.Windows.Forms.OpenFileDialog()
        Me.exeExportar = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.UltraTabPageControl1.SuspendLayout()
        CType(Me.grdBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewConsultaBaseSimula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.uccFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uccFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.utcManejoCarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.utcManejoCarga.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.grdBase)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(2, 24)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(728, 235)
        '
        'grdBase
        '
        Me.grdBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBase.Location = New System.Drawing.Point(0, 0)
        Me.grdBase.MainView = Me.ViewConsultaBaseSimula
        Me.grdBase.Name = "grdBase"
        Me.grdBase.Size = New System.Drawing.Size(728, 235)
        Me.grdBase.TabIndex = 32
        Me.grdBase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.ViewConsultaBaseSimula})
        '
        'ViewConsultaBaseSimula
        '
        Me.ViewConsultaBaseSimula.GridControl = Me.grdBase
        Me.ViewConsultaBaseSimula.Name = "ViewConsultaBaseSimula"
        Me.ViewConsultaBaseSimula.OptionsView.ShowAutoFilterRow = True
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.txtLogErrores)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(728, 235)
        '
        'txtLogErrores
        '
        Me.txtLogErrores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtLogErrores.Location = New System.Drawing.Point(0, 0)
        Me.txtLogErrores.Multiline = True
        Me.txtLogErrores.Name = "txtLogErrores"
        Me.txtLogErrores.ReadOnly = True
        Me.txtLogErrores.Size = New System.Drawing.Size(728, 235)
        Me.txtLogErrores.TabIndex = 12
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.btnExportarExcel)
        Me.pnlListaPaises.Controls.Add(Me.lblExportarExcel)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(732, 59)
        Me.pnlListaPaises.TabIndex = 32
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(34, 6)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 26
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(12, 41)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(75, 13)
        Me.lblExportarExcel.TabIndex = 27
        Me.lblExportarExcel.Text = "Exportar Excel"
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(351, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(381, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(113, 22)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(205, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Configuración Simulador"
        Me.lblEncabezado.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 429)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(732, 60)
        Me.pnlPie.TabIndex = 69
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(567, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(106, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnLimpiar.Image = Global.Programacion.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(688, 38)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 16
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(685, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Limpiar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnConsultar)
        Me.Panel1.Controls.Add(Me.uccFechaIni)
        Me.Panel1.Controls.Add(Me.uccFechaFin)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnExaminar)
        Me.Panel1.Controls.Add(Me.txtArchivo)
        Me.Panel1.Controls.Add(Me.cmbBase)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblNave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(732, 109)
        Me.Panel1.TabIndex = 70
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.Location = New System.Drawing.Point(634, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Buscar"
        '
        'btnConsultar
        '
        Me.btnConsultar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnConsultar.Location = New System.Drawing.Point(637, 38)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(32, 32)
        Me.btnConsultar.TabIndex = 17
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'uccFechaIni
        '
        Me.uccFechaIni.DateButtons.Add(DateButton1)
        Me.uccFechaIni.Location = New System.Drawing.Point(116, 45)
        Me.uccFechaIni.Name = "uccFechaIni"
        Me.uccFechaIni.NonAutoSizeHeight = 21
        Me.uccFechaIni.Size = New System.Drawing.Size(120, 21)
        Me.uccFechaIni.TabIndex = 16
        Me.uccFechaIni.Value = New Date(2018, 2, 24, 0, 0, 0, 0)
        '
        'uccFechaFin
        '
        Me.uccFechaFin.DateButtons.Add(DateButton2)
        Me.uccFechaFin.Location = New System.Drawing.Point(298, 45)
        Me.uccFechaFin.Name = "uccFechaFin"
        Me.uccFechaFin.NonAutoSizeHeight = 21
        Me.uccFechaFin.Size = New System.Drawing.Size(120, 21)
        Me.uccFechaFin.TabIndex = 15
        Me.uccFechaFin.Value = New Date(2018, 2, 24, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(238, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Fecha Fin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Fecha Inicio:"
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Programacion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnExaminar.Location = New System.Drawing.Point(418, 75)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(25, 23)
        Me.btnExaminar.TabIndex = 12
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.Location = New System.Drawing.Point(116, 76)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(302, 20)
        Me.txtArchivo.TabIndex = 11
        '
        'cmbBase
        '
        Me.cmbBase.FormattingEnabled = True
        Me.cmbBase.Location = New System.Drawing.Point(116, 13)
        Me.cmbBase.Name = "cmbBase"
        Me.cmbBase.Size = New System.Drawing.Size(302, 21)
        Me.cmbBase.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ruta Excel:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(38, 18)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(34, 13)
        Me.lblNave.TabIndex = 1
        Me.lblNave.Text = "Base:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(0, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(732, 370)
        Me.Panel2.TabIndex = 71
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.utcManejoCarga)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.ForeColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(0, 109)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(732, 261)
        Me.Panel3.TabIndex = 71
        '
        'utcManejoCarga
        '
        Me.utcManejoCarga.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.utcManejoCarga.Controls.Add(Me.UltraTabPageControl1)
        Me.utcManejoCarga.Controls.Add(Me.UltraTabPageControl2)
        Me.utcManejoCarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.utcManejoCarga.Location = New System.Drawing.Point(0, 0)
        Me.utcManejoCarga.Name = "utcManejoCarga"
        Me.utcManejoCarga.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.utcManejoCarga.Size = New System.Drawing.Size(732, 261)
        Me.utcManejoCarga.TabIndex = 33
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Archivo"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Log Errores"
        Me.utcManejoCarga.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab1, UltraTab2})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(728, 235)
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(319, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'CargaBasesSimulacionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 489)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "CargaBasesSimulacionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuracion simulador"
        Me.UltraTabPageControl1.ResumeLayout(False)
        CType(Me.grdBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewConsultaBaseSimula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl2.PerformLayout()
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.uccFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uccFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.utcManejoCarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.utcManejoCarga.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbBase As System.Windows.Forms.ComboBox
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grdBase As DevExpress.XtraGrid.GridControl
    Friend WithEvents ViewConsultaBaseSimula As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents opCargaExcel As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents uccFechaIni As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents uccFechaFin As Infragistics.Win.UltraWinSchedule.UltraCalendarCombo
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents utcManejoCarga As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents txtLogErrores As TextBox
    Friend WithEvents btnConsultar As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents exeExportar As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
