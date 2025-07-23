<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultaPedidosProgramaCOPPELForm
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
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblConfigurar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.btnImprimirReportePedidos = New System.Windows.Forms.Button()
        Me.lblConsultaInventarioNaves = New System.Windows.Forms.Label()
        Me.btnCargarArchivo = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblTotalSeleccionados = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.dtmFechaFinPrograma = New System.Windows.Forms.DateTimePicker()
        Me.dtmFechaInicioPrograma = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdConsultaDeLotes = New DevExpress.XtraGrid.GridControl()
        Me.grdVConsultaDeLotes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdConsultaDeLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVConsultaDeLotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblConfigurar)
        Me.pnlListaPaises.Controls.Add(Me.Label3)
        Me.pnlListaPaises.Controls.Add(Me.btnConfigurar)
        Me.pnlListaPaises.Controls.Add(Me.btnImprimirReportePedidos)
        Me.pnlListaPaises.Controls.Add(Me.lblConsultaInventarioNaves)
        Me.pnlListaPaises.Controls.Add(Me.btnCargarArchivo)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1075, 67)
        Me.pnlListaPaises.TabIndex = 30
        '
        'lblConfigurar
        '
        Me.lblConfigurar.AutoSize = True
        Me.lblConfigurar.BackColor = System.Drawing.Color.Transparent
        Me.lblConfigurar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConfigurar.Location = New System.Drawing.Point(146, 37)
        Me.lblConfigurar.Name = "lblConfigurar"
        Me.lblConfigurar.Size = New System.Drawing.Size(97, 26)
        Me.lblConfigurar.TabIndex = 52
        Me.lblConfigurar.Text = "Configurar-Etiqueta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliente-Colección"
        Me.lblConfigurar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblConfigurar.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(95, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "Reporte"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnConfigurar
        '
        Me.btnConfigurar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnConfigurar.Image = Global.Programacion.Vista.My.Resources.Resources.OProduccion
        Me.btnConfigurar.Location = New System.Drawing.Point(175, 4)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(32, 32)
        Me.btnConfigurar.TabIndex = 51
        Me.btnConfigurar.UseVisualStyleBackColor = False
        Me.btnConfigurar.Visible = False
        '
        'btnImprimirReportePedidos
        '
        Me.btnImprimirReportePedidos.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnImprimirReportePedidos.Image = Global.Programacion.Vista.My.Resources.Resources.editar_32
        Me.btnImprimirReportePedidos.Location = New System.Drawing.Point(100, 4)
        Me.btnImprimirReportePedidos.Name = "btnImprimirReportePedidos"
        Me.btnImprimirReportePedidos.Size = New System.Drawing.Size(32, 32)
        Me.btnImprimirReportePedidos.TabIndex = 48
        Me.btnImprimirReportePedidos.UseVisualStyleBackColor = False
        '
        'lblConsultaInventarioNaves
        '
        Me.lblConsultaInventarioNaves.AutoSize = True
        Me.lblConsultaInventarioNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblConsultaInventarioNaves.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaInventarioNaves.Location = New System.Drawing.Point(12, 37)
        Me.lblConsultaInventarioNaves.Name = "lblConsultaInventarioNaves"
        Me.lblConsultaInventarioNaves.Size = New System.Drawing.Size(77, 13)
        Me.lblConsultaInventarioNaves.TabIndex = 47
        Me.lblConsultaInventarioNaves.Text = "Cargar Archivo"
        Me.lblConsultaInventarioNaves.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCargarArchivo
        '
        Me.btnCargarArchivo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCargarArchivo.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.btnCargarArchivo.Location = New System.Drawing.Point(25, 4)
        Me.btnCargarArchivo.Name = "btnCargarArchivo"
        Me.btnCargarArchivo.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarArchivo.TabIndex = 46
        Me.btnCargarArchivo.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(732, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(343, 67)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(13, 15)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(244, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Impresión Etiquetas COPPEL"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.lblTotalSeleccionados)
        Me.pnlPie.Controls.Add(Me.lblClientes)
        Me.pnlPie.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 371)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1075, 60)
        Me.pnlPie.TabIndex = 67
        '
        'lblTotalSeleccionados
        '
        Me.lblTotalSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSeleccionados.Location = New System.Drawing.Point(22, 33)
        Me.lblTotalSeleccionados.Name = "lblTotalSeleccionados"
        Me.lblTotalSeleccionados.Size = New System.Drawing.Size(69, 18)
        Me.lblTotalSeleccionados.TabIndex = 126
        Me.lblTotalSeleccionados.Text = "0"
        Me.lblTotalSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblClientes
        '
        Me.lblClientes.AutoSize = True
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.Color.Black
        Me.lblClientes.Location = New System.Drawing.Point(22, 11)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.Size = New System.Drawing.Size(79, 16)
        Me.lblClientes.TabIndex = 125
        Me.lblClientes.Text = "Registros " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(339, 26)
        Me.lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion"
        Me.lblFechaUltimaActualizacion.Size = New System.Drawing.Size(0, 13)
        Me.lblFechaUltimaActualizacion.TabIndex = 123
        Me.lblFechaUltimaActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoUltimaDistribucion
        '
        Me.lblTextoUltimaDistribucion.AutoSize = True
        Me.lblTextoUltimaDistribucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoUltimaDistribucion.ForeColor = System.Drawing.Color.Black
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(216, 26)
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
        Me.pnlAcciones.Controls.Add(Me.Label2)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(902, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(173, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(114, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(114, 43)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(52, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(55, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 41
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'pnlFiltros
        '
        Me.pnlFiltros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.dtmFechaFinPrograma)
        Me.pnlFiltros.Controls.Add(Me.dtmFechaInicioPrograma)
        Me.pnlFiltros.Controls.Add(Me.Label1)
        Me.pnlFiltros.Controls.Add(Me.cmbNave)
        Me.pnlFiltros.Controls.Add(Me.lblDepartamento)
        Me.pnlFiltros.Controls.Add(Me.lblNave)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 67)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1075, 68)
        Me.pnlFiltros.TabIndex = 68
        '
        'dtmFechaFinPrograma
        '
        Me.dtmFechaFinPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaFinPrograma.Location = New System.Drawing.Point(593, 32)
        Me.dtmFechaFinPrograma.Name = "dtmFechaFinPrograma"
        Me.dtmFechaFinPrograma.Size = New System.Drawing.Size(239, 20)
        Me.dtmFechaFinPrograma.TabIndex = 45
        Me.dtmFechaFinPrograma.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        Me.dtmFechaFinPrograma.Visible = False
        '
        'dtmFechaInicioPrograma
        '
        Me.dtmFechaInicioPrograma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtmFechaInicioPrograma.Location = New System.Drawing.Point(296, 32)
        Me.dtmFechaInicioPrograma.Name = "dtmFechaInicioPrograma"
        Me.dtmFechaInicioPrograma.Size = New System.Drawing.Size(239, 20)
        Me.dtmFechaInicioPrograma.TabIndex = 40
        Me.dtmFechaInicioPrograma.Value = New Date(2016, 11, 14, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(590, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "F. Fin de Programa:"
        Me.Label1.Visible = False
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Location = New System.Drawing.Point(68, 31)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(173, 21)
        Me.cmbNave.TabIndex = 2
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(293, 16)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(103, 13)
        Me.lblDepartamento.TabIndex = 1
        Me.lblDepartamento.Text = "Fecha de Programa:"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Location = New System.Drawing.Point(65, 16)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(36, 13)
        Me.lblNave.TabIndex = 0
        Me.lblNave.Text = "Nave:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.grdConsultaDeLotes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 135)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1075, 236)
        Me.Panel1.TabIndex = 69
        '
        'grdConsultaDeLotes
        '
        Me.grdConsultaDeLotes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsultaDeLotes.Location = New System.Drawing.Point(0, 0)
        Me.grdConsultaDeLotes.MainView = Me.grdVConsultaDeLotes
        Me.grdConsultaDeLotes.Name = "grdConsultaDeLotes"
        Me.grdConsultaDeLotes.Size = New System.Drawing.Size(1075, 236)
        Me.grdConsultaDeLotes.TabIndex = 33
        Me.grdConsultaDeLotes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVConsultaDeLotes})
        '
        'grdVConsultaDeLotes
        '
        Me.grdVConsultaDeLotes.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVConsultaDeLotes.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVConsultaDeLotes.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdVConsultaDeLotes.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVConsultaDeLotes.GridControl = Me.grdConsultaDeLotes
        Me.grdVConsultaDeLotes.Name = "grdVConsultaDeLotes"
        Me.grdVConsultaDeLotes.OptionsView.ShowAutoFilterRow = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(260, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(83, 67)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'ConsultaPedidosProgramaCOPPELForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 431)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ConsultaPedidosProgramaCOPPELForm"
        Me.Text = "Impresión Etiquetas COPPEL"
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
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdConsultaDeLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVConsultaDeLotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblConsultaInventarioNaves As System.Windows.Forms.Label
    Friend WithEvents btnCargarArchivo As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents dtmFechaInicioPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents grdConsultaDeLotes As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVConsultaDeLotes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtmFechaFinPrograma As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnImprimirReportePedidos As System.Windows.Forms.Button
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents lblTotalSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblConfigurar As Label
    Friend WithEvents btnConfigurar As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
