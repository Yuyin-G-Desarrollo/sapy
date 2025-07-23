<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesEspecialesForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesEspecialesForm))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnAltas = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.tbtClientes = New System.Windows.Forms.TabControl()
        Me.tbtClientesEspeciales = New System.Windows.Forms.TabPage()
        Me.grdDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.tbtClientesExcluidosCapacidad = New System.Windows.Forms.TabPage()
        Me.grdClientesExcluidos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pnlOpciones = New System.Windows.Forms.Panel()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.grbNaves = New System.Windows.Forms.GroupBox()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbClientes = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.UltraGridBagLayoutManager1 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrincipal.SuspendLayout()
        Me.tbtClientes.SuspendLayout()
        Me.tbtClientesEspeciales.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtClientesExcluidosCapacidad.SuspendLayout()
        CType(Me.grdClientesExcluidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOpciones.SuspendLayout()
        Me.grbNaves.SuspendLayout()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnEliminar)
        Me.pnlEncabezado.Controls.Add(Me.Label4)
        Me.pnlEncabezado.Controls.Add(Me.btnExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.lblExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnAltas)
        Me.pnlEncabezado.Controls.Add(Me.lblActualizar)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(553, 56)
        Me.pnlEncabezado.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label5)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(280, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(273, 56)
        Me.pnlTitulo.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(33, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(166, 20)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Clientes Especiales"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(205, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 56)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Programacion.Vista.My.Resources.Resources.borrar_321
        Me.btnEliminar.Location = New System.Drawing.Point(73, 6)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 34
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(68, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Eliminar"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(130, 6)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 24
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(130, 38)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(33, 13)
        Me.lblExportarExcel.TabIndex = 25
        Me.lblExportarExcel.Text = "Excel"
        '
        'btnAltas
        '
        Me.btnAltas.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAltas.Location = New System.Drawing.Point(16, 6)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.Size = New System.Drawing.Size(32, 32)
        Me.btnAltas.TabIndex = 22
        Me.btnAltas.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(17, 38)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(30, 13)
        Me.lblActualizar.TabIndex = 23
        Me.lblActualizar.Text = "Altas"
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.tbtClientes)
        Me.pnlPrincipal.Controls.Add(Me.pnlOpciones)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 56)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Padding = New System.Windows.Forms.Padding(11, 3, 11, 11)
        Me.pnlPrincipal.Size = New System.Drawing.Size(553, 493)
        Me.pnlPrincipal.TabIndex = 4
        '
        'tbtClientes
        '
        Me.tbtClientes.Controls.Add(Me.tbtClientesEspeciales)
        Me.tbtClientes.Controls.Add(Me.tbtClientesExcluidosCapacidad)
        Me.tbtClientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtClientes.Location = New System.Drawing.Point(11, 91)
        Me.tbtClientes.Name = "tbtClientes"
        Me.tbtClientes.SelectedIndex = 0
        Me.tbtClientes.Size = New System.Drawing.Size(531, 391)
        Me.tbtClientes.TabIndex = 8
        '
        'tbtClientesEspeciales
        '
        Me.tbtClientesEspeciales.Controls.Add(Me.grdDatos)
        Me.tbtClientesEspeciales.Location = New System.Drawing.Point(4, 22)
        Me.tbtClientesEspeciales.Name = "tbtClientesEspeciales"
        Me.tbtClientesEspeciales.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtClientesEspeciales.Size = New System.Drawing.Size(523, 365)
        Me.tbtClientesEspeciales.TabIndex = 0
        Me.tbtClientesEspeciales.Text = "Clientes Especiales"
        Me.tbtClientesEspeciales.UseVisualStyleBackColor = True
        '
        'grdDatos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatos.DisplayLayout.Appearance = Appearance1
        Me.grdDatos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDatos.Location = New System.Drawing.Point(3, 3)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(517, 359)
        Me.grdDatos.TabIndex = 6
        '
        'tbtClientesExcluidosCapacidad
        '
        Me.tbtClientesExcluidosCapacidad.Controls.Add(Me.grdClientesExcluidos)
        Me.tbtClientesExcluidosCapacidad.Location = New System.Drawing.Point(4, 22)
        Me.tbtClientesExcluidosCapacidad.Name = "tbtClientesExcluidosCapacidad"
        Me.tbtClientesExcluidosCapacidad.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtClientesExcluidosCapacidad.Size = New System.Drawing.Size(523, 365)
        Me.tbtClientesExcluidosCapacidad.TabIndex = 1
        Me.tbtClientesExcluidosCapacidad.Text = "Clientes Excluidos"
        Me.tbtClientesExcluidosCapacidad.UseVisualStyleBackColor = True
        '
        'grdClientesExcluidos
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesExcluidos.DisplayLayout.Appearance = Appearance3
        Me.grdClientesExcluidos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesExcluidos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientesExcluidos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesExcluidos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesExcluidos.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdClientesExcluidos.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesExcluidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesExcluidos.Location = New System.Drawing.Point(3, 3)
        Me.grdClientesExcluidos.Name = "grdClientesExcluidos"
        Me.grdClientesExcluidos.Size = New System.Drawing.Size(517, 359)
        Me.grdClientesExcluidos.TabIndex = 0
        '
        'pnlOpciones
        '
        Me.pnlOpciones.Controls.Add(Me.btnAbajo)
        Me.pnlOpciones.Controls.Add(Me.btnArriba)
        Me.pnlOpciones.Controls.Add(Me.grbNaves)
        Me.pnlOpciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOpciones.Location = New System.Drawing.Point(11, 3)
        Me.pnlOpciones.Name = "pnlOpciones"
        Me.pnlOpciones.Size = New System.Drawing.Size(531, 88)
        Me.pnlOpciones.TabIndex = 7
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(499, 9)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 37
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(468, 9)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 36
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'grbNaves
        '
        Me.grbNaves.Controls.Add(Me.lblOrden)
        Me.grbNaves.Controls.Add(Me.Label2)
        Me.grbNaves.Controls.Add(Me.cbClientes)
        Me.grbNaves.Controls.Add(Me.Label1)
        Me.grbNaves.Location = New System.Drawing.Point(5, 35)
        Me.grbNaves.Name = "grbNaves"
        Me.grbNaves.Size = New System.Drawing.Size(522, 47)
        Me.grbNaves.TabIndex = 35
        Me.grbNaves.TabStop = False
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.Location = New System.Drawing.Point(477, 16)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(15, 15)
        Me.lblOrden.TabIndex = 28
        Me.lblOrden.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(440, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Orden"
        '
        'cbClientes
        '
        Me.cbClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbClientes.FormattingEnabled = True
        Me.cbClientes.Location = New System.Drawing.Point(84, 13)
        Me.cbClientes.Name = "cbClientes"
        Me.cbClientes.Size = New System.Drawing.Size(342, 21)
        Me.cbClientes.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Cliente"
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 549)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(553, 60)
        Me.pnlExtado.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.btnGuardar)
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(369, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 60)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(128, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cerrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(129, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(75, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(42, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Mostrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(17, 42)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Programacion.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(23, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 2
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(76, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 3
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'ClientesEspecialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(553, 609)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.pnlExtado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(569, 648)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(569, 648)
        Me.Name = "ClientesEspecialesForm"
        Me.Text = "Clientes Especiales"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.tbtClientes.ResumeLayout(False)
        Me.tbtClientesEspeciales.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtClientesExcluidosCapacidad.ResumeLayout(False)
        CType(Me.grdClientesExcluidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOpciones.ResumeLayout(False)
        Me.grbNaves.ResumeLayout(False)
        Me.grbNaves.PerformLayout()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.UltraGridBagLayoutManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnAltas As System.Windows.Forms.Button
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents grdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pnlOpciones As System.Windows.Forms.Panel
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents grbNaves As System.Windows.Forms.GroupBox
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents tbtClientes As System.Windows.Forms.TabControl
    Friend WithEvents tbtClientesEspeciales As System.Windows.Forms.TabPage
    Friend WithEvents tbtClientesExcluidosCapacidad As System.Windows.Forms.TabPage
    Friend WithEvents grdClientesExcluidos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridBagLayoutManager1 As Infragistics.Win.Misc.UltraGridBagLayoutManager
End Class
