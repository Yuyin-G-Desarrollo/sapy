<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrdenesEnProceso_ReporteOrdenesEnProcesoPorMesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrdenesEnProceso_ReporteOrdenesEnProcesoPorMesForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.pnlEnviarEtiquetas = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdOrdenesEnProceso = New DevExpress.XtraGrid.GridControl()
        Me.grvOrdenesEnProceso = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.chkSeleccion = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlExportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlEnviarEtiquetas.SuspendLayout()
        CType(Me.grdOrdenesEnProceso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvOrdenesEnProceso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlExportar)
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1101, 75)
        Me.Panel1.TabIndex = 2032
        '
        'pnlExportar
        '
        Me.pnlExportar.Controls.Add(Me.btnExportar)
        Me.pnlExportar.Controls.Add(Me.lblExportar)
        Me.pnlExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlExportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlExportar.Name = "pnlExportar"
        Me.pnlExportar.Size = New System.Drawing.Size(65, 75)
        Me.pnlExportar.TabIndex = 50
        '
        'btnExportar
        '
        Me.btnExportar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(16, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 174
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExportar.Location = New System.Drawing.Point(13, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 173
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(541, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(560, 75)
        Me.pnlTitulo.TabIndex = 49
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(161, 26)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(314, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Reporte Ordenes En Proceso Por Mes"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.Panel7)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 661)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1101, 76)
        Me.pnlPie.TabIndex = 2033
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblRegistrosTitulo)
        Me.Panel7.Controls.Add(Me.lblRegistros)
        Me.Panel7.Location = New System.Drawing.Point(3, 1)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(106, 70)
        Me.Panel7.TabIndex = 190
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(10, 15)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 187
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(10, 40)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 188
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Panel10)
        Me.pnlDatosBotones.Controls.Add(Me.pnlEnviarEtiquetas)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(559, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(542, 76)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblUltimaDistribucion)
        Me.Panel10.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(277, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(200, 76)
        Me.Panel10.TabIndex = 5
        '
        'lblUltimaDistribucion
        '
        Me.lblUltimaDistribucion.AutoSize = True
        Me.lblUltimaDistribucion.Location = New System.Drawing.Point(57, 39)
        Me.lblUltimaDistribucion.Name = "lblUltimaDistribucion"
        Me.lblUltimaDistribucion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaDistribucion.TabIndex = 166
        Me.lblUltimaDistribucion.Text = "13/02/2019 12:34 p.m."
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(65, 21)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 165
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'pnlEnviarEtiquetas
        '
        Me.pnlEnviarEtiquetas.Controls.Add(Me.btnCerrar)
        Me.pnlEnviarEtiquetas.Controls.Add(Me.lblCerrar)
        Me.pnlEnviarEtiquetas.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEnviarEtiquetas.Location = New System.Drawing.Point(477, 0)
        Me.pnlEnviarEtiquetas.Name = "pnlEnviarEtiquetas"
        Me.pnlEnviarEtiquetas.Size = New System.Drawing.Size(65, 76)
        Me.pnlEnviarEtiquetas.TabIndex = 2
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(16, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 174
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(15, 43)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 173
        Me.lblCerrar.Text = "Cerrar"
        Me.lblCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdOrdenesEnProceso
        '
        Me.grdOrdenesEnProceso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdOrdenesEnProceso.Location = New System.Drawing.Point(0, 75)
        Me.grdOrdenesEnProceso.MainView = Me.grvOrdenesEnProceso
        Me.grdOrdenesEnProceso.Name = "grdOrdenesEnProceso"
        Me.grdOrdenesEnProceso.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkSeleccion})
        Me.grdOrdenesEnProceso.Size = New System.Drawing.Size(1101, 586)
        Me.grdOrdenesEnProceso.TabIndex = 2034
        Me.grdOrdenesEnProceso.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvOrdenesEnProceso})
        '
        'grvOrdenesEnProceso
        '
        Me.grvOrdenesEnProceso.GridControl = Me.grdOrdenesEnProceso
        Me.grvOrdenesEnProceso.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.grvOrdenesEnProceso.IndicatorWidth = 40
        Me.grvOrdenesEnProceso.Name = "grvOrdenesEnProceso"
        Me.grvOrdenesEnProceso.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.grvOrdenesEnProceso.OptionsSelection.MultiSelect = True
        Me.grvOrdenesEnProceso.OptionsView.AllowCellMerge = True
        Me.grvOrdenesEnProceso.OptionsView.ColumnAutoWidth = False
        Me.grvOrdenesEnProceso.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.grvOrdenesEnProceso.OptionsView.ShowAutoFilterRow = True
        Me.grvOrdenesEnProceso.OptionsView.ShowFooter = True
        Me.grvOrdenesEnProceso.OptionsView.ShowGroupPanel = False
        '
        'chkSeleccion
        '
        Me.chkSeleccion.Name = "chkSeleccion"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(483, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(77, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 94
        Me.PictureBox1.TabStop = False
        '
        'OrdenesEnProceso_ReporteOrdenesEnProcesoPorMesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 737)
        Me.Controls.Add(Me.grdOrdenesEnProceso)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "OrdenesEnProceso_ReporteOrdenesEnProcesoPorMesForm"
        Me.Text = "Reporte Ordenes En Proceso Por Mes"
        Me.Panel1.ResumeLayout(False)
        Me.pnlExportar.ResumeLayout(False)
        Me.pnlExportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlEnviarEtiquetas.ResumeLayout(False)
        Me.pnlEnviarEtiquetas.PerformLayout()
        CType(Me.grdOrdenesEnProceso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvOrdenesEnProceso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlExportar As Panel
    Friend WithEvents btnExportar As Button
    Friend WithEvents lblExportar As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents lblUltimaDistribucion As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents pnlEnviarEtiquetas As Panel
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents grdOrdenesEnProceso As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvOrdenesEnProceso As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkSeleccion As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PictureBox1 As PictureBox
End Class
