<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpresionEtiquetasEspecialesForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblConsultaInventarioNaves = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.cmbResolucionImpresora = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkSeleccionar = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.dtmFechaPrograma = New System.Windows.Forms.DateTimePicker()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.grdLotes = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.grdLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblConsultaInventarioNaves)
        Me.pnlListaPaises.Controls.Add(Me.btnImprimir)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(923, 59)
        Me.pnlListaPaises.TabIndex = 29
        '
        'lblConsultaInventarioNaves
        '
        Me.lblConsultaInventarioNaves.AutoSize = True
        Me.lblConsultaInventarioNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblConsultaInventarioNaves.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaInventarioNaves.Location = New System.Drawing.Point(10, 34)
        Me.lblConsultaInventarioNaves.Name = "lblConsultaInventarioNaves"
        Me.lblConsultaInventarioNaves.Size = New System.Drawing.Size(42, 13)
        Me.lblConsultaInventarioNaves.TabIndex = 47
        Me.lblConsultaInventarioNaves.Text = "Imprimir"
        Me.lblConsultaInventarioNaves.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImprimir.Image = Global.Programacion.Vista.My.Resources.Resources.imprimir_32
        Me.btnImprimir.Location = New System.Drawing.Point(15, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimir.TabIndex = 46
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(580, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(343, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(13, 15)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(262, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Impresión Etiquetas Especiales"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 325)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(923, 60)
        Me.pnlPie.TabIndex = 66
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(128, 26)
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
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(16, 26)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 124
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(809, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(114, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(39, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(39, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.cmbResolucionImpresora)
        Me.pnlFiltros.Controls.Add(Me.Label3)
        Me.pnlFiltros.Controls.Add(Me.chkSeleccionar)
        Me.pnlFiltros.Controls.Add(Me.Label2)
        Me.pnlFiltros.Controls.Add(Me.btnMostrar)
        Me.pnlFiltros.Controls.Add(Me.dtmFechaPrograma)
        Me.pnlFiltros.Controls.Add(Me.cmbNave)
        Me.pnlFiltros.Controls.Add(Me.lblDepartamento)
        Me.pnlFiltros.Controls.Add(Me.lblNave)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 59)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(923, 61)
        Me.pnlFiltros.TabIndex = 67
        '
        'cmbResolucionImpresora
        '
        Me.cmbResolucionImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResolucionImpresora.FormattingEnabled = True
        Me.cmbResolucionImpresora.Items.AddRange(New Object() {"200dpi", "300dpi"})
        Me.cmbResolucionImpresora.Location = New System.Drawing.Point(672, 13)
        Me.cmbResolucionImpresora.Name = "cmbResolucionImpresora"
        Me.cmbResolucionImpresora.Size = New System.Drawing.Size(112, 21)
        Me.cmbResolucionImpresora.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(603, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Resolución:"
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.Location = New System.Drawing.Point(11, 38)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(82, 17)
        Me.chkSeleccionar.TabIndex = 43
        Me.chkSeleccionar.Text = "Seleccionar"
        Me.chkSeleccionar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(843, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(846, 2)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 41
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'dtmFechaPrograma
        '
        Me.dtmFechaPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaPrograma.Location = New System.Drawing.Point(350, 13)
        Me.dtmFechaPrograma.Name = "dtmFechaPrograma"
        Me.dtmFechaPrograma.Size = New System.Drawing.Size(239, 20)
        Me.dtmFechaPrograma.TabIndex = 40
        Me.dtmFechaPrograma.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(68, 13)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(173, 21)
        Me.cmbNave.TabIndex = 2
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(256, 16)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(88, 13)
        Me.lblDepartamento.TabIndex = 1
        Me.lblDepartamento.Text = "Fecha Programa:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(26, 16)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave:"
        '
        'grdLotes
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotes.DisplayLayout.Appearance = Appearance1
        Me.grdLotes.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotes.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdLotes.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdLotes.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLotes.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLotes.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdLotes.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLotes.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdLotes.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdLotes.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdLotes.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
        Me.grdLotes.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLotes.Location = New System.Drawing.Point(0, 120)
        Me.grdLotes.Name = "grdLotes"
        Me.grdLotes.Size = New System.Drawing.Size(923, 205)
        Me.grdLotes.TabIndex = 68
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(281, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ImpresionEtiquetasEspecialesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 385)
        Me.Controls.Add(Me.grdLotes)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ImpresionEtiquetasEspecialesForm"
        Me.Text = "Impresión Etiquetas Especiales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.grdLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblConsultaInventarioNaves As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents dtmFechaPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents grdLotes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents chkSeleccionar As System.Windows.Forms.CheckBox
    Friend WithEvents cmbResolucionImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
