<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBitacoraImportarPrograma
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblListaNaves = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.lblEtiqueta = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grbNaves = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dttFin = New System.Windows.Forms.DateTimePicker()
        Me.dttInicio = New System.Windows.Forms.DateTimePicker()
        Me.tbtAcciones = New System.Windows.Forms.TabControl()
        Me.tbtPedido = New System.Windows.Forms.TabPage()
        Me.grdPedidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbtLotes = New System.Windows.Forms.TabPage()
        Me.grdLotes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbtBitacora = New System.Windows.Forms.TabPage()
        Me.grdBitacora = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grbNaves.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tbtAcciones.SuspendLayout()
        Me.tbtPedido.SuspendLayout()
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtLotes.SuspendLayout()
        CType(Me.grdLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtBitacora.SuspendLayout()
        CType(Me.grdBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.lblExportarExcel)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1051, 59)
        Me.pnlEncabezado.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblListaNaves)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(723, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(328, 59)
        Me.pnlTitulo.TabIndex = 33
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(260, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 22
        Me.pcbTitulo.TabStop = False
        '
        'imgLogo
        '
        Me.imgLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imgLogo.Location = New System.Drawing.Point(267, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(61, 59)
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'lblListaNaves
        '
        Me.lblListaNaves.AutoSize = True
        Me.lblListaNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblListaNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaNaves.Location = New System.Drawing.Point(99, 19)
        Me.lblListaNaves.Name = "lblListaNaves"
        Me.lblListaNaves.Size = New System.Drawing.Size(159, 20)
        Me.lblListaNaves.TabIndex = 21
        Me.lblListaNaves.Text = "Importar Programa"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(20, 7)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 24
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(20, 39)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(33, 13)
        Me.lblExportarExcel.TabIndex = 25
        Me.lblExportarExcel.Text = "Excel"
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.lblEtiqueta)
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 477)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(1051, 60)
        Me.pnlExtado.TabIndex = 15
        '
        'lblEtiqueta
        '
        Me.lblEtiqueta.AutoSize = True
        Me.lblEtiqueta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiqueta.ForeColor = System.Drawing.Color.Black
        Me.lblEtiqueta.Location = New System.Drawing.Point(10, 11)
        Me.lblEtiqueta.Name = "lblEtiqueta"
        Me.lblEtiqueta.Size = New System.Drawing.Size(369, 13)
        Me.lblEtiqueta.TabIndex = 5
        Me.lblEtiqueta.Text = "Importar los datos hará un remplazo de la información que existe actualmente"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnImportar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(905, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(146, 60)
        Me.Panel1.TabIndex = 0
        '
        'btnImportar
        '
        Me.btnImportar.Image = Global.Programacion.Vista.My.Resources.Resources.importarPrograma
        Me.btnImportar.Location = New System.Drawing.Point(33, 7)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(32, 32)
        Me.btnImportar.TabIndex = 26
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(89, 39)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(27, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Importar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(90, 7)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grbNaves
        '
        Me.grbNaves.Controls.Add(Me.Panel2)
        Me.grbNaves.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbNaves.Location = New System.Drawing.Point(0, 59)
        Me.grbNaves.Name = "grbNaves"
        Me.grbNaves.Size = New System.Drawing.Size(1051, 63)
        Me.grbNaves.TabIndex = 16
        Me.grbNaves.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dttFin)
        Me.Panel2.Controls.Add(Me.dttInicio)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(482, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 44)
        Me.Panel2.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(306, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Fin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(51, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Inicio"
        '
        'dttFin
        '
        Me.dttFin.Location = New System.Drawing.Point(333, 14)
        Me.dttFin.Name = "dttFin"
        Me.dttFin.Size = New System.Drawing.Size(200, 20)
        Me.dttFin.TabIndex = 28
        '
        'dttInicio
        '
        Me.dttInicio.Location = New System.Drawing.Point(89, 14)
        Me.dttInicio.Name = "dttInicio"
        Me.dttInicio.Size = New System.Drawing.Size(200, 20)
        Me.dttInicio.TabIndex = 29
        '
        'tbtAcciones
        '
        Me.tbtAcciones.Controls.Add(Me.tbtPedido)
        Me.tbtAcciones.Controls.Add(Me.tbtLotes)
        Me.tbtAcciones.Controls.Add(Me.tbtBitacora)
        Me.tbtAcciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtAcciones.Location = New System.Drawing.Point(0, 122)
        Me.tbtAcciones.Name = "tbtAcciones"
        Me.tbtAcciones.SelectedIndex = 0
        Me.tbtAcciones.Size = New System.Drawing.Size(1051, 355)
        Me.tbtAcciones.TabIndex = 17
        '
        'tbtPedido
        '
        Me.tbtPedido.Controls.Add(Me.grdPedidos)
        Me.tbtPedido.Location = New System.Drawing.Point(4, 22)
        Me.tbtPedido.Name = "tbtPedido"
        Me.tbtPedido.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtPedido.Size = New System.Drawing.Size(1043, 329)
        Me.tbtPedido.TabIndex = 0
        Me.tbtPedido.Text = "Pedidos"
        Me.tbtPedido.UseVisualStyleBackColor = True
        '
        'grdPedidos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidos.DisplayLayout.Appearance = Appearance1
        Me.grdPedidos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdPedidos.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdPedidos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdPedidos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdPedidos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdPedidos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdPedidos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdPedidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPedidos.Location = New System.Drawing.Point(3, 3)
        Me.grdPedidos.Name = "grdPedidos"
        Me.grdPedidos.Size = New System.Drawing.Size(1037, 323)
        Me.grdPedidos.TabIndex = 20
        '
        'tbtLotes
        '
        Me.tbtLotes.Controls.Add(Me.grdLotes)
        Me.tbtLotes.Location = New System.Drawing.Point(4, 22)
        Me.tbtLotes.Name = "tbtLotes"
        Me.tbtLotes.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtLotes.Size = New System.Drawing.Size(1043, 329)
        Me.tbtLotes.TabIndex = 1
        Me.tbtLotes.Text = "Lotes"
        Me.tbtLotes.UseVisualStyleBackColor = True
        '
        'grdLotes
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotes.DisplayLayout.Appearance = Appearance3
        Me.grdLotes.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdLotes.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdLotes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLotes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotes.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdLotes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotes.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLotes.Location = New System.Drawing.Point(3, 3)
        Me.grdLotes.Name = "grdLotes"
        Me.grdLotes.Size = New System.Drawing.Size(1037, 323)
        Me.grdLotes.TabIndex = 21
        '
        'tbtBitacora
        '
        Me.tbtBitacora.Controls.Add(Me.grdBitacora)
        Me.tbtBitacora.Controls.Add(Me.Panel3)
        Me.tbtBitacora.Location = New System.Drawing.Point(4, 22)
        Me.tbtBitacora.Name = "tbtBitacora"
        Me.tbtBitacora.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtBitacora.Size = New System.Drawing.Size(1043, 329)
        Me.tbtBitacora.TabIndex = 2
        Me.tbtBitacora.Text = "Bitacora"
        Me.tbtBitacora.UseVisualStyleBackColor = True
        '
        'grdBitacora
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBitacora.DisplayLayout.Appearance = Appearance5
        Me.grdBitacora.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdBitacora.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.grdBitacora.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdBitacora.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdBitacora.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdBitacora.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdBitacora.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdBitacora.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdBitacora.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdBitacora.Location = New System.Drawing.Point(3, 26)
        Me.grdBitacora.Name = "grdBitacora"
        Me.grdBitacora.Size = New System.Drawing.Size(1037, 300)
        Me.grdBitacora.TabIndex = 21
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblFolio)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1037, 23)
        Me.Panel3.TabIndex = 22
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(57, 5)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(13, 13)
        Me.lblFolio.TabIndex = 24
        Me.lblFolio.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Folio :"
        '
        'frmBitacoraImportarPrograma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1051, 537)
        Me.Controls.Add(Me.tbtAcciones)
        Me.Controls.Add(Me.grbNaves)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmBitacoraImportarPrograma"
        Me.Text = "Importar Programa"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.pnlExtado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grbNaves.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tbtAcciones.ResumeLayout(False)
        Me.tbtPedido.ResumeLayout(False)
        CType(Me.grdPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtLotes.ResumeLayout(False)
        CType(Me.grdLotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtBitacora.ResumeLayout(False)
        CType(Me.grdBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaNaves As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblEtiqueta As System.Windows.Forms.Label
    Friend WithEvents grbNaves As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbtAcciones As System.Windows.Forms.TabControl
    Friend WithEvents tbtPedido As System.Windows.Forms.TabPage
    Friend WithEvents tbtLotes As System.Windows.Forms.TabPage
    Friend WithEvents tbtBitacora As System.Windows.Forms.TabPage
    Friend WithEvents grdPedidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdLotes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdBitacora As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dttInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
End Class
