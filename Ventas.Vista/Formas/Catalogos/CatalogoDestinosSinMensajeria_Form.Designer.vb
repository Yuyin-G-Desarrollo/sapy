<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CatalogoDestinosSinMensajeria_Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CatalogoDestinosSinMensajeria_Form))
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlBtnExportar = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlBtnAltas = New System.Windows.Forms.Panel()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.grdDestinosSinMensajeria = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.ultExportGrid = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlBtnExportar.SuspendLayout()
        Me.pnlBtnAltas.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.grdDestinosSinMensajeria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Label1)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 405)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(849, 60)
        Me.pnlPie.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(727, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Poblaciones y ciudades de Tiendas/Embarques/CEDIS activos que no tienen proveedor" &
    "es de mensajería relacionados."
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblMostrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(735, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(114, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnGuardar.Location = New System.Drawing.Point(14, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(68, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(9, 41)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 6
        Me.lblMostrar.Text = "Mostrar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(68, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnExportar)
        Me.pnlEncabezado.Controls.Add(Me.pnlBtnAltas)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(849, 60)
        Me.pnlEncabezado.TabIndex = 17
        '
        'pnlBtnExportar
        '
        Me.pnlBtnExportar.Controls.Add(Me.btnExportar)
        Me.pnlBtnExportar.Controls.Add(Me.lblExportar)
        Me.pnlBtnExportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnExportar.Location = New System.Drawing.Point(54, 0)
        Me.pnlBtnExportar.Name = "pnlBtnExportar"
        Me.pnlBtnExportar.Size = New System.Drawing.Size(55, 60)
        Me.pnlBtnExportar.TabIndex = 50
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(11, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 15
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(4, 41)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 14
        Me.lblExportar.Text = "Exportar"
        '
        'pnlBtnAltas
        '
        Me.pnlBtnAltas.Controls.Add(Me.btnAltas)
        Me.pnlBtnAltas.Controls.Add(Me.lblAltas)
        Me.pnlBtnAltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBtnAltas.Location = New System.Drawing.Point(0, 0)
        Me.pnlBtnAltas.Name = "pnlBtnAltas"
        Me.pnlBtnAltas.Size = New System.Drawing.Size(54, 60)
        Me.pnlBtnAltas.TabIndex = 49
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Ventas.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(11, 7)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 15
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(13, 41)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(30, 13)
        Me.lblAltas.TabIndex = 14
        Me.lblAltas.Text = "Altas"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(454, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(395, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(109, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(212, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Destinos Sin Mensajerías"
        '
        'grdDestinosSinMensajeria
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDestinosSinMensajeria.DisplayLayout.Appearance = Appearance1
        Me.grdDestinosSinMensajeria.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.WithOperand
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdDestinosSinMensajeria.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdDestinosSinMensajeria.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdDestinosSinMensajeria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDestinosSinMensajeria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDestinosSinMensajeria.Location = New System.Drawing.Point(0, 60)
        Me.grdDestinosSinMensajeria.Name = "grdDestinosSinMensajeria"
        Me.grdDestinosSinMensajeria.Size = New System.Drawing.Size(849, 345)
        Me.grdDestinosSinMensajeria.TabIndex = 19
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(327, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'CatalogoDestinosSinMensajeria_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(849, 465)
        Me.Controls.Add(Me.grdDestinosSinMensajeria)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CatalogoDestinosSinMensajeria_Form"
        Me.Text = "Destinos Sin Mensajerías"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlBtnExportar.ResumeLayout(False)
        Me.pnlBtnExportar.PerformLayout()
        Me.pnlBtnAltas.ResumeLayout(False)
        Me.pnlBtnAltas.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.grdDestinosSinMensajeria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents grdDestinosSinMensajeria As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlBtnExportar As System.Windows.Forms.Panel
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents pnlBtnAltas As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents ultExportGrid As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents PictureBox1 As PictureBox
End Class
