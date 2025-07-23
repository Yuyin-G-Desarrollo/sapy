<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenDeProductosParaProveedoresForm
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pnlDockEncabezado = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEtiquetaPares = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblPares = New System.Windows.Forms.Label()
        Me.lblPromedio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlFiltrosImportes = New System.Windows.Forms.Panel()
        Me.chkCorrida = New System.Windows.Forms.CheckBox()
        Me.chkColor = New System.Windows.Forms.CheckBox()
        Me.chkModelo = New System.Windows.Forms.CheckBox()
        Me.chkColeccion = New System.Windows.Forms.CheckBox()
        Me.lblAgruparPor = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.gridListaEntradas = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlDockEncabezado.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlFiltrosImportes.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.gridListaEntradas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlEncabezado.Size = New System.Drawing.Size(744, 59)
        Me.pnlEncabezado.TabIndex = 6
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.BackColor = System.Drawing.Color.White
        Me.pnlAccionesCabecera.Controls.Add(Me.lblExportar)
        Me.pnlAccionesCabecera.Controls.Add(Me.btnExportar)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(129, 59)
        Me.pnlAccionesCabecera.TabIndex = 1
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(17, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 28
        Me.lblExportar.Text = "Exportar"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Almacen.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(24, 5)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 1
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.pnlDockEncabezado)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(248, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(496, 59)
        Me.pnlTitulo.TabIndex = 0
        '
        'pnlDockEncabezado
        '
        Me.pnlDockEncabezado.Controls.Add(Me.lblTitulo)
        Me.pnlDockEncabezado.Location = New System.Drawing.Point(38, 19)
        Me.pnlDockEncabezado.Name = "pnlDockEncabezado"
        Me.pnlDockEncabezado.Size = New System.Drawing.Size(384, 37)
        Me.pnlDockEncabezado.TabIndex = 47
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(23, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(361, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Entrada de Producto por Nave con Importes"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Panel1)
        Me.pnlPie.Controls.Add(Me.pnlFiltrosImportes)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 408)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(744, 70)
        Me.pnlPie.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblEtiquetaPares)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblPares)
        Me.Panel1.Controls.Add(Me.lblPromedio)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(426, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(174, 70)
        Me.Panel1.TabIndex = 54
        '
        'lblEtiquetaPares
        '
        Me.lblEtiquetaPares.AutoSize = True
        Me.lblEtiquetaPares.Location = New System.Drawing.Point(3, 7)
        Me.lblEtiquetaPares.Name = "lblEtiquetaPares"
        Me.lblEtiquetaPares.Size = New System.Drawing.Size(34, 13)
        Me.lblEtiquetaPares.TabIndex = 48
        Me.lblEtiquetaPares.Text = "Pares"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(87, 49)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(13, 13)
        Me.lblTotal.TabIndex = 53
        Me.lblTotal.Text = "0"
        '
        'lblPares
        '
        Me.lblPares.AutoSize = True
        Me.lblPares.Location = New System.Drawing.Point(87, 7)
        Me.lblPares.Name = "lblPares"
        Me.lblPares.Size = New System.Drawing.Size(13, 13)
        Me.lblPares.TabIndex = 49
        Me.lblPares.Text = "0"
        '
        'lblPromedio
        '
        Me.lblPromedio.AutoSize = True
        Me.lblPromedio.Location = New System.Drawing.Point(87, 28)
        Me.lblPromedio.Name = "lblPromedio"
        Me.lblPromedio.Size = New System.Drawing.Size(13, 13)
        Me.lblPromedio.TabIndex = 52
        Me.lblPromedio.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Precio Promedio"
        '
        'pnlFiltrosImportes
        '
        Me.pnlFiltrosImportes.Controls.Add(Me.chkCorrida)
        Me.pnlFiltrosImportes.Controls.Add(Me.chkColor)
        Me.pnlFiltrosImportes.Controls.Add(Me.chkModelo)
        Me.pnlFiltrosImportes.Controls.Add(Me.chkColeccion)
        Me.pnlFiltrosImportes.Controls.Add(Me.lblAgruparPor)
        Me.pnlFiltrosImportes.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFiltrosImportes.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltrosImportes.Name = "pnlFiltrosImportes"
        Me.pnlFiltrosImportes.Size = New System.Drawing.Size(332, 70)
        Me.pnlFiltrosImportes.TabIndex = 47
        '
        'chkCorrida
        '
        Me.chkCorrida.AutoSize = True
        Me.chkCorrida.Location = New System.Drawing.Point(105, 27)
        Me.chkCorrida.Name = "chkCorrida"
        Me.chkCorrida.Size = New System.Drawing.Size(59, 17)
        Me.chkCorrida.TabIndex = 5
        Me.chkCorrida.Text = "Corrida"
        Me.chkCorrida.UseVisualStyleBackColor = True
        '
        'chkColor
        '
        Me.chkColor.AutoSize = True
        Me.chkColor.Location = New System.Drawing.Point(105, 46)
        Me.chkColor.Name = "chkColor"
        Me.chkColor.Size = New System.Drawing.Size(50, 17)
        Me.chkColor.TabIndex = 4
        Me.chkColor.Text = "Color"
        Me.chkColor.UseVisualStyleBackColor = True
        '
        'chkModelo
        '
        Me.chkModelo.AutoSize = True
        Me.chkModelo.Location = New System.Drawing.Point(18, 27)
        Me.chkModelo.Name = "chkModelo"
        Me.chkModelo.Size = New System.Drawing.Size(61, 17)
        Me.chkModelo.TabIndex = 3
        Me.chkModelo.Text = "Modelo"
        Me.chkModelo.UseVisualStyleBackColor = True
        '
        'chkColeccion
        '
        Me.chkColeccion.AutoSize = True
        Me.chkColeccion.Location = New System.Drawing.Point(18, 46)
        Me.chkColeccion.Name = "chkColeccion"
        Me.chkColeccion.Size = New System.Drawing.Size(73, 17)
        Me.chkColeccion.TabIndex = 2
        Me.chkColeccion.Text = "Colección"
        Me.chkColeccion.UseVisualStyleBackColor = True
        '
        'lblAgruparPor
        '
        Me.lblAgruparPor.AutoSize = True
        Me.lblAgruparPor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgruparPor.Location = New System.Drawing.Point(5, 7)
        Me.lblAgruparPor.Name = "lblAgruparPor"
        Me.lblAgruparPor.Size = New System.Drawing.Size(81, 13)
        Me.lblAgruparPor.TabIndex = 0
        Me.lblAgruparPor.Text = "Agrupar por :"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.BackColor = System.Drawing.Color.White
        Me.pnlDatosBotones.Controls.Add(Me.lblMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(600, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(144, 70)
        Me.pnlDatosBotones.TabIndex = 1
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMostrar.Location = New System.Drawing.Point(20, 47)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 6
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnMostrar.Image = Global.Almacen.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(25, 12)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 7
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Almacen.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(91, 12)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(90, 47)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'gridListaEntradas
        '
        Me.gridListaEntradas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridListaEntradas.DisplayLayout.Appearance = Appearance1
        Me.gridListaEntradas.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.gridListaEntradas.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaEntradas.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaEntradas.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridListaEntradas.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridListaEntradas.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridListaEntradas.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.gridListaEntradas.Location = New System.Drawing.Point(0, 59)
        Me.gridListaEntradas.Name = "gridListaEntradas"
        Me.gridListaEntradas.Size = New System.Drawing.Size(734, 194)
        Me.gridListaEntradas.TabIndex = 8
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 56)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(734, 339)
        Me.GridControl1.TabIndex = 9
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.CustomizationFormHint.Options.UseTextOptions = True
        Me.GridView1.Appearance.CustomizationFormHint.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(426, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(70, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 48
        Me.imgLogo.TabStop = False
        '
        'ResumenDeProductosParaProveedoresForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(744, 478)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.gridListaEntradas)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimumSize = New System.Drawing.Size(750, 500)
        Me.Name = "ResumenDeProductosParaProveedoresForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Exportar"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.pnlAccionesCabecera.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlDockEncabezado.ResumeLayout(False)
        Me.pnlDockEncabezado.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlFiltrosImportes.ResumeLayout(False)
        Me.pnlFiltrosImportes.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.gridListaEntradas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlAccionesCabecera As System.Windows.Forms.Panel
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents gridListaEntradas As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlDockEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlFiltrosImportes As System.Windows.Forms.Panel
    Friend WithEvents chkCorrida As System.Windows.Forms.CheckBox
    Friend WithEvents chkColor As System.Windows.Forms.CheckBox
    Friend WithEvents chkModelo As System.Windows.Forms.CheckBox
    Friend WithEvents chkColeccion As System.Windows.Forms.CheckBox
    Friend WithEvents lblAgruparPor As System.Windows.Forms.Label
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblPromedio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPares As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaPares As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents imgLogo As PictureBox
End Class
