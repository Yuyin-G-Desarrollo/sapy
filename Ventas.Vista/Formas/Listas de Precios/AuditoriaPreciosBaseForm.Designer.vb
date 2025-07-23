<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AuditoriaPreciosBaseForm
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
        Me.grdClientesCopia = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.lblEstatusListaPrecios = New System.Windows.Forms.Label()
        Me.cmbEstatusLista = New System.Windows.Forms.ComboBox()
        Me.chkSeleccionarFiltrados = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblContClientes = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.lblMostrar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.btnExportarExcelApartados = New System.Windows.Forms.Button()
        Me.lblActualizarDatos = New System.Windows.Forms.Label()
        CType(Me.grdClientesCopia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdClientesCopia
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesCopia.DisplayLayout.Appearance = Appearance1
        Me.grdClientesCopia.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdClientesCopia.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdClientesCopia.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdClientesCopia.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdClientesCopia.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdClientesCopia.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdClientesCopia.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdClientesCopia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdClientesCopia.Location = New System.Drawing.Point(0, 129)
        Me.grdClientesCopia.Name = "grdClientesCopia"
        Me.grdClientesCopia.Size = New System.Drawing.Size(950, 324)
        Me.grdClientesCopia.TabIndex = 61
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.lblEstatusListaPrecios)
        Me.Panel1.Controls.Add(Me.cmbEstatusLista)
        Me.Panel1.Controls.Add(Me.chkSeleccionarFiltrados)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(950, 69)
        Me.Panel1.TabIndex = 64
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(15, 26)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(390, 17)
        Me.RadioButton2.TabIndex = 50
        Me.RadioButton2.Text = "Precios Finales en Listas de Precios de Clientes diferentes al precio calculado"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(15, 7)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(385, 17)
        Me.RadioButton1.TabIndex = 49
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Precios Base en Listas de Precio de Clientes diferentes al precio base actual"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'lblEstatusListaPrecios
        '
        Me.lblEstatusListaPrecios.AutoSize = True
        Me.lblEstatusListaPrecios.Location = New System.Drawing.Point(479, 30)
        Me.lblEstatusListaPrecios.Name = "lblEstatusListaPrecios"
        Me.lblEstatusListaPrecios.Size = New System.Drawing.Size(63, 13)
        Me.lblEstatusListaPrecios.TabIndex = 48
        Me.lblEstatusListaPrecios.Text = "* Lista Base"
        '
        'cmbEstatusLista
        '
        Me.cmbEstatusLista.FormattingEnabled = True
        Me.cmbEstatusLista.Location = New System.Drawing.Point(548, 26)
        Me.cmbEstatusLista.Name = "cmbEstatusLista"
        Me.cmbEstatusLista.Size = New System.Drawing.Size(376, 21)
        Me.cmbEstatusLista.TabIndex = 47
        '
        'chkSeleccionarFiltrados
        '
        Me.chkSeleccionarFiltrados.AutoSize = True
        Me.chkSeleccionarFiltrados.Location = New System.Drawing.Point(15, 51)
        Me.chkSeleccionarFiltrados.Name = "chkSeleccionarFiltrados"
        Me.chkSeleccionarFiltrados.Size = New System.Drawing.Size(110, 17)
        Me.chkSeleccionarFiltrados.TabIndex = 46
        Me.chkSeleccionarFiltrados.Text = "Seleccionar Todo"
        Me.chkSeleccionarFiltrados.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblContClientes)
        Me.Panel2.Controls.Add(Me.lblClientes)
        Me.Panel2.Controls.Add(Me.pnlAcciones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 453)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(950, 60)
        Me.Panel2.TabIndex = 63
        '
        'lblContClientes
        '
        Me.lblContClientes.AutoSize = True
        Me.lblContClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContClientes.ForeColor = System.Drawing.Color.Black
        Me.lblContClientes.Location = New System.Drawing.Point(67, 33)
        Me.lblContClientes.Name = "lblContClientes"
        Me.lblContClientes.Size = New System.Drawing.Size(25, 25)
        Me.lblContClientes.TabIndex = 45
        Me.lblContClientes.Text = "0"
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(23, 3)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(112, 32)
        Me.lblClientes.TabIndex = 46
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionados"
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.lblMostrar)
        Me.pnlAcciones.Controls.Add(Me.btnLimpiar)
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(691, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(259, 60)
        Me.pnlAcciones.TabIndex = 1
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Ventas.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(119, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 26
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'lblMostrar
        '
        Me.lblMostrar.AutoSize = True
        Me.lblMostrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblMostrar.Location = New System.Drawing.Point(117, 40)
        Me.lblMostrar.Name = "lblMostrar"
        Me.lblMostrar.Size = New System.Drawing.Size(42, 13)
        Me.lblMostrar.TabIndex = 25
        Me.lblMostrar.Text = "Mostrar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Ventas.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(164, 7)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 24
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(163, 40)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 23
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(209, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_321
        Me.btnGuardar.Location = New System.Drawing.Point(74, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(208, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 3
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(68, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnExportarExcelApartados)
        Me.pnlHeader.Controls.Add(Me.lblActualizarDatos)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(950, 60)
        Me.pnlHeader.TabIndex = 62
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(552, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(398, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(156, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(170, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Auditoría de Precios"
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Ventas.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(330, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pctTitulo.TabIndex = 0
        Me.pctTitulo.TabStop = False
        '
        'btnExportarExcelApartados
        '
        Me.btnExportarExcelApartados.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcelApartados.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcelApartados.Image = Global.Ventas.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcelApartados.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcelApartados.Location = New System.Drawing.Point(15, 10)
        Me.btnExportarExcelApartados.Name = "btnExportarExcelApartados"
        Me.btnExportarExcelApartados.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcelApartados.TabIndex = 55
        Me.btnExportarExcelApartados.UseVisualStyleBackColor = True
        '
        'lblActualizarDatos
        '
        Me.lblActualizarDatos.AutoSize = True
        Me.lblActualizarDatos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarDatos.Location = New System.Drawing.Point(9, 42)
        Me.lblActualizarDatos.Name = "lblActualizarDatos"
        Me.lblActualizarDatos.Size = New System.Drawing.Size(46, 13)
        Me.lblActualizarDatos.TabIndex = 54
        Me.lblActualizarDatos.Text = "Exportar"
        '
        'AuditoriaPreciosBaseForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(950, 513)
        Me.Controls.Add(Me.grdClientesCopia)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "AuditoriaPreciosBaseForm"
        Me.Text = "Auditoría de Precios"
        CType(Me.grdClientesCopia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdClientesCopia As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarFiltrados As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblContClientes As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pctTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstatusListaPrecios As System.Windows.Forms.Label
    Friend WithEvents cmbEstatusLista As System.Windows.Forms.ComboBox
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents lblMostrar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnExportarExcelApartados As System.Windows.Forms.Button
    Friend WithEvents lblActualizarDatos As System.Windows.Forms.Label
End Class
