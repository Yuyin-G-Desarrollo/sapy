<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResumenProductosForm
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo2 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnAgrupamiento = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkCorrida = New System.Windows.Forms.CheckBox()
        Me.chkPielColor = New System.Windows.Forms.CheckBox()
        Me.chkModelo = New System.Windows.Forms.CheckBox()
        Me.chkMarcaColeccionTemp = New System.Windows.Forms.CheckBox()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.grdConsulta = New DevExpress.XtraGrid.GridControl()
        Me.grdVConsulta = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlAccionesCabecera = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblnombrecedis = New System.Windows.Forms.Label()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnAgrupamiento.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel14.SuspendLayout()
        Me.pnlAccionesCabecera.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.lblnombrecedis)
        Me.pnlEncabezado.Controls.Add(Me.pnlAccionesCabecera)
        Me.pnlEncabezado.Controls.Add(Me.Label1)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(956, 83)
        Me.pnlEncabezado.TabIndex = 28
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo2)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(522, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(434, 83)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo2
        '
        Me.lblTitulo2.AutoSize = True
        Me.lblTitulo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo2.Location = New System.Drawing.Point(7, 42)
        Me.lblTitulo2.Name = "lblTitulo2"
        Me.lblTitulo2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo2.Size = New System.Drawing.Size(338, 20)
        Me.lblTitulo2.TabIndex = 48
        Me.lblTitulo2.Text = "Consultas Envió y recepción de muestras"
        Me.lblTitulo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(3, 22)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(345, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Consultas Envió y Recepción de Muestras"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(351, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 83)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.pnAgrupamiento)
        Me.Panel2.Controls.Add(Me.lblUltimaActualizacion)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 422)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(956, 70)
        Me.Panel2.TabIndex = 30
        '
        'pnAgrupamiento
        '
        Me.pnAgrupamiento.Controls.Add(Me.Label2)
        Me.pnAgrupamiento.Controls.Add(Me.chkCorrida)
        Me.pnAgrupamiento.Controls.Add(Me.chkPielColor)
        Me.pnAgrupamiento.Controls.Add(Me.chkModelo)
        Me.pnAgrupamiento.Controls.Add(Me.chkMarcaColeccionTemp)
        Me.pnAgrupamiento.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnAgrupamiento.Location = New System.Drawing.Point(0, 0)
        Me.pnAgrupamiento.Name = "pnAgrupamiento"
        Me.pnAgrupamiento.Size = New System.Drawing.Size(318, 70)
        Me.pnAgrupamiento.TabIndex = 163
        Me.pnAgrupamiento.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Agrupamiento:"
        '
        'chkCorrida
        '
        Me.chkCorrida.AutoSize = True
        Me.chkCorrida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCorrida.ForeColor = System.Drawing.Color.Black
        Me.chkCorrida.Location = New System.Drawing.Point(191, 41)
        Me.chkCorrida.Name = "chkCorrida"
        Me.chkCorrida.Size = New System.Drawing.Size(59, 17)
        Me.chkCorrida.TabIndex = 159
        Me.chkCorrida.Text = "Corrida"
        Me.chkCorrida.UseVisualStyleBackColor = True
        '
        'chkPielColor
        '
        Me.chkPielColor.AutoSize = True
        Me.chkPielColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPielColor.ForeColor = System.Drawing.Color.Black
        Me.chkPielColor.Location = New System.Drawing.Point(16, 41)
        Me.chkPielColor.Name = "chkPielColor"
        Me.chkPielColor.Size = New System.Drawing.Size(70, 17)
        Me.chkPielColor.TabIndex = 160
        Me.chkPielColor.Text = "Piel-Color"
        Me.chkPielColor.UseVisualStyleBackColor = True
        '
        'chkModelo
        '
        Me.chkModelo.AutoSize = True
        Me.chkModelo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkModelo.ForeColor = System.Drawing.Color.Black
        Me.chkModelo.Location = New System.Drawing.Point(191, 23)
        Me.chkModelo.Name = "chkModelo"
        Me.chkModelo.Size = New System.Drawing.Size(61, 17)
        Me.chkModelo.TabIndex = 158
        Me.chkModelo.Text = "Modelo"
        Me.chkModelo.UseVisualStyleBackColor = True
        '
        'chkMarcaColeccionTemp
        '
        Me.chkMarcaColeccionTemp.AutoSize = True
        Me.chkMarcaColeccionTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarcaColeccionTemp.ForeColor = System.Drawing.Color.Black
        Me.chkMarcaColeccionTemp.Location = New System.Drawing.Point(16, 23)
        Me.chkMarcaColeccionTemp.Name = "chkMarcaColeccionTemp"
        Me.chkMarcaColeccionTemp.Size = New System.Drawing.Size(163, 17)
        Me.chkMarcaColeccionTemp.TabIndex = 157
        Me.chkMarcaColeccionTemp.Text = "Marca-Colección-Temporada"
        Me.chkMarcaColeccionTemp.UseVisualStyleBackColor = True
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(972, 38)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(0, 13)
        Me.lblUltimaActualizacion.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(972, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Última actualización:"
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.Label6)
        Me.pnlDatosBotones.Controls.Add(Me.btnMostrar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(794, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 70)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label6.Location = New System.Drawing.Point(67, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(70, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 10
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(116, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCerrar.Location = New System.Drawing.Point(119, 40)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'grdConsulta
        '
        Me.grdConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdConsulta.Location = New System.Drawing.Point(0, 83)
        Me.grdConsulta.MainView = Me.grdVConsulta
        Me.grdConsulta.Name = "grdConsulta"
        Me.grdConsulta.Size = New System.Drawing.Size(956, 339)
        Me.grdConsulta.TabIndex = 31
        Me.grdConsulta.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVConsulta})
        '
        'grdVConsulta
        '
        Me.grdVConsulta.GridControl = Me.grdConsulta
        Me.grdVConsulta.Name = "grdVConsulta"
        Me.grdVConsulta.OptionsPrint.AllowMultilineHeaders = True
        Me.grdVConsulta.OptionsView.ShowAutoFilterRow = True
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.Label17)
        Me.Panel14.Controls.Add(Me.btnExportarExcel)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(137, 83)
        Me.Panel14.TabIndex = 3
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportarExcel.Location = New System.Drawing.Point(12, 12)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 88
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label17.Location = New System.Drawing.Point(9, 47)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 89
        Me.Label17.Text = "Exportar"
        '
        'pnlAccionesCabecera
        '
        Me.pnlAccionesCabecera.Controls.Add(Me.Panel14)
        Me.pnlAccionesCabecera.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAccionesCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlAccionesCabecera.Name = "pnlAccionesCabecera"
        Me.pnlAccionesCabecera.Size = New System.Drawing.Size(74, 83)
        Me.pnlAccionesCabecera.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(187, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Consulta envió y recepción cedis:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblnombrecedis
        '
        Me.lblnombrecedis.AutoSize = True
        Me.lblnombrecedis.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnombrecedis.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblnombrecedis.Location = New System.Drawing.Point(356, 42)
        Me.lblnombrecedis.Name = "lblnombrecedis"
        Me.lblnombrecedis.Size = New System.Drawing.Size(51, 20)
        Me.lblnombrecedis.TabIndex = 48
        Me.lblnombrecedis.Text = "cedis"
        Me.lblnombrecedis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ResumenProductosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 492)
        Me.Controls.Add(Me.grdConsulta)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "ResumenProductosForm"
        Me.Text = "Consultas de Envío y Recepción de Muestras"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnAgrupamiento.ResumeLayout(False)
        Me.pnAgrupamiento.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel14.ResumeLayout(False)
        Me.Panel14.PerformLayout()
        Me.pnlAccionesCabecera.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlDatosBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents grdConsulta As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVConsulta As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents pnAgrupamiento As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkCorrida As System.Windows.Forms.CheckBox
    Friend WithEvents chkPielColor As System.Windows.Forms.CheckBox
    Friend WithEvents chkModelo As System.Windows.Forms.CheckBox
    Friend WithEvents chkMarcaColeccionTemp As System.Windows.Forms.CheckBox
    Friend WithEvents lblTitulo2 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlAccionesCabecera As Panel
    Friend WithEvents lblnombrecedis As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents btnExportarExcel As Button
End Class
