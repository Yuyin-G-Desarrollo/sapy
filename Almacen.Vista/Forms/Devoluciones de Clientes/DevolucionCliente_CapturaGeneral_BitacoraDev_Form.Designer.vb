<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DevolucionCliente_CapturaGeneral_BitacoraDev_Form
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevolucionCliente_CapturaGeneral_BitacoraDev_Form))
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblBtnCerrar = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grdBitacora = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblClienteDevolucion = New System.Windows.Forms.Label()
        Me.lblFolioDevolución = New System.Windows.Forms.Label()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.pnlMarcarTodo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlPie.SuspendLayout()
        CType(Me.grdBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblBtnCerrar)
        Me.pnlPie.Controls.Add(Me.btnCerrar)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 438)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(820, 63)
        Me.pnlPie.TabIndex = 65
        '
        'lblBtnCerrar
        '
        Me.lblBtnCerrar.AutoSize = True
        Me.lblBtnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBtnCerrar.Location = New System.Drawing.Point(765, 41)
        Me.lblBtnCerrar.Name = "lblBtnCerrar"
        Me.lblBtnCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblBtnCerrar.TabIndex = 56
        Me.lblBtnCerrar.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(768, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 57
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'grdBitacora
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBitacora.DisplayLayout.Appearance = Appearance1
        Me.grdBitacora.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.grdBitacora.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdBitacora.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdBitacora.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.Combo
        Me.grdBitacora.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdBitacora.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.grdBitacora.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdBitacora.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.grdBitacora.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdBitacora.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdBitacora.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBitacora.Location = New System.Drawing.Point(0, 0)
        Me.grdBitacora.Name = "grdBitacora"
        Me.grdBitacora.Size = New System.Drawing.Size(820, 331)
        Me.grdBitacora.TabIndex = 64
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.grdBitacora)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 107)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(820, 331)
        Me.Panel3.TabIndex = 67
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.lblClienteDevolucion)
        Me.Panel2.Controls.Add(Me.lblFolioDevolución)
        Me.Panel2.Controls.Add(Me.lblUnidadMedida)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(820, 36)
        Me.Panel2.TabIndex = 68
        '
        'lblClienteDevolucion
        '
        Me.lblClienteDevolucion.AutoSize = True
        Me.lblClienteDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClienteDevolucion.ForeColor = System.Drawing.Color.Black
        Me.lblClienteDevolucion.Location = New System.Drawing.Point(333, 10)
        Me.lblClienteDevolucion.Name = "lblClienteDevolucion"
        Me.lblClienteDevolucion.Size = New System.Drawing.Size(13, 16)
        Me.lblClienteDevolucion.TabIndex = 173
        Me.lblClienteDevolucion.Text = "-"
        '
        'lblFolioDevolución
        '
        Me.lblFolioDevolución.AutoSize = True
        Me.lblFolioDevolución.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioDevolución.ForeColor = System.Drawing.Color.Black
        Me.lblFolioDevolución.Location = New System.Drawing.Point(165, 3)
        Me.lblFolioDevolución.Name = "lblFolioDevolución"
        Me.lblFolioDevolución.Size = New System.Drawing.Size(51, 25)
        Me.lblFolioDevolución.TabIndex = 172
        Me.lblFolioDevolución.Text = "589"
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.AutoSize = True
        Me.lblUnidadMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadMedida.ForeColor = System.Drawing.Color.Black
        Me.lblUnidadMedida.Location = New System.Drawing.Point(12, 9)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(147, 16)
        Me.lblUnidadMedida.TabIndex = 171
        Me.lblUnidadMedida.Text = "Folio de Devolución"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlTitulo.Controls.Add(Me.Panel1)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(820, 71)
        Me.pnlTitulo.TabIndex = 69
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblExportar)
        Me.Panel1.Controls.Add(Me.btnExportarExcel)
        Me.Panel1.Controls.Add(Me.pnlMarcarTodo)
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(752, 59)
        Me.Panel1.TabIndex = 47
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(22, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 54
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(28, 8)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 55
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'pnlMarcarTodo
        '
        Me.pnlMarcarTodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMarcarTodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMarcarTodo.Name = "pnlMarcarTodo"
        Me.pnlMarcarTodo.Size = New System.Drawing.Size(16, 59)
        Me.pnlMarcarTodo.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(458, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(280, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Bitácora de Devolución de Cliente"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(752, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 71)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'DevolucionCliente_CapturaGeneral_BitacoraDev_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 501)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlPie)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(828, 528)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(828, 528)
        Me.Name = "DevolucionCliente_CapturaGeneral_BitacoraDev_Form"
        Me.Text = "Bitácora de Devoluciones"
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        CType(Me.grdBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlPie As Panel
    Friend WithEvents lblBtnCerrar As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents grdBitacora As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblClienteDevolucion As Label
    Friend WithEvents lblFolioDevolución As Label
    Friend WithEvents lblUnidadMedida As Label
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblExportar As Label
    Friend WithEvents btnExportarExcel As Button
    Friend WithEvents pnlMarcarTodo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
End Class
