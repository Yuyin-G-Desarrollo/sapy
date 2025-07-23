<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenApartadosPPCP_Form
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResumenApartadosPPCP_Form))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.btnExportarExcelApartados = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaDistribucion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdResumenGeneral = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdResumenNaves = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdResumenCliente = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.grdResumenGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.grdResumenNaves, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdResumenCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(912, 59)
        Me.pnlEncabezado.TabIndex = 118
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportarExcelApartados)
        Me.pnlAccionesCabecera.Controls.Add(Me.lblActualizarDatos)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(260, 59)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'btnExportarExcelApartados
        '
        Me.btnExportarExcelApartados.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelApartados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelApartados.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelApartados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelApartados.Location = New System.Drawing.Point(23, 8)
        Me.btnExportarExcelApartados.Name = "btnExportarExcelApartados"
        Me.btnExportarExcelApartados.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelApartados.TabIndex = 55
        Me.btnExportarExcelApartados.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(17, 40)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 54
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(260, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(652, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(323, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(260, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Resumen de Apartados (PPCP)"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 533)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(912, 60)
        Me.pnlPie.TabIndex = 123
        '
        'lblFechaUltimaDistribucion
        '
        Me.lblFechaUltimaDistribucion.Location = New System.Drawing.Point(204, 23)
        Me.lblFechaUltimaDistribucion.Name = "lblFechaUltimaDistribucion"
        Me.lblFechaUltimaDistribucion.Size = New System.Drawing.Size(176, 20)
        Me.lblFechaUltimaDistribucion.TabIndex = 84
        Me.lblFechaUltimaDistribucion.Text = "-"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(197, 20)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Resumen de la distribución generada el:"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(581, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(331, 60)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(284, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(283, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.grdResumenGeneral)
        Me.Panel5.Location = New System.Drawing.Point(10, 65)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(551, 309)
        Me.Panel5.TabIndex = 75
        '
        'grdResumenGeneral
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenGeneral.DisplayLayout.Appearance = Appearance1
        Me.grdResumenGeneral.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdResumenGeneral.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdResumenGeneral.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdResumenGeneral.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdResumenGeneral.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdResumenGeneral.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdResumenGeneral.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdResumenGeneral.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.grdResumenGeneral.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdResumenGeneral.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdResumenGeneral.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdResumenGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResumenGeneral.Location = New System.Drawing.Point(0, 0)
        Me.grdResumenGeneral.Name = "grdResumenGeneral"
        Me.grdResumenGeneral.Size = New System.Drawing.Size(551, 309)
        Me.grdResumenGeneral.TabIndex = 59
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdResumenNaves)
        Me.Panel1.Location = New System.Drawing.Point(567, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(330, 309)
        Me.Panel1.TabIndex = 75
        '
        'grdResumenNaves
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenNaves.DisplayLayout.Appearance = Appearance3
        Me.grdResumenNaves.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdResumenNaves.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdResumenNaves.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdResumenNaves.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdResumenNaves.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdResumenNaves.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdResumenNaves.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenNaves.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdResumenNaves.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdResumenNaves.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdResumenNaves.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResumenNaves.Location = New System.Drawing.Point(0, 0)
        Me.grdResumenNaves.Name = "grdResumenNaves"
        Me.grdResumenNaves.Size = New System.Drawing.Size(330, 309)
        Me.grdResumenNaves.TabIndex = 59
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdResumenCliente)
        Me.Panel2.Location = New System.Drawing.Point(10, 380)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(887, 135)
        Me.Panel2.TabIndex = 75
        '
        'grdResumenCliente
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenCliente.DisplayLayout.Appearance = Appearance5
        Me.grdResumenCliente.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdResumenCliente.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdResumenCliente.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdResumenCliente.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdResumenCliente.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdResumenCliente.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdResumenCliente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdResumenCliente.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdResumenCliente.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdResumenCliente.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdResumenCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdResumenCliente.Location = New System.Drawing.Point(0, 0)
        Me.grdResumenCliente.Name = "grdResumenCliente"
        Me.grdResumenCliente.Size = New System.Drawing.Size(887, 135)
        Me.grdResumenCliente.TabIndex = 61
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(584, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ResumenApartadosPPCP_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(912, 593)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.MaximumSize = New System.Drawing.Size(920, 620)
        Me.MinimumSize = New System.Drawing.Size(920, 620)
        Me.Name = "ResumenApartadosPPCP_Form"
        Me.Text = "Resumen de Apartados (PPCP)"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.grdResumenGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdResumenNaves, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdResumenCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcelApartados As System.Windows.Forms.Button
    Friend WithEvents lblActualizarDatos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblFechaUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents grdResumenGeneral As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdResumenNaves As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdResumenCliente As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents PictureBox1 As PictureBox
End Class
