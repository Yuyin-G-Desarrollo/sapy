<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdministracionKiosko_CargaModelosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdministracionKiosko_CargaModelosForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlImportar = New System.Windows.Forms.Panel()
        Me.lblImportarInformacion = New System.Windows.Forms.Label()
        Me.btnImportarInformacion = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblRegistrosTitulo = New System.Windows.Forms.Label()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblUltimaDistribucion = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblLabelUltimaActualizacion = New System.Windows.Forms.Label()
        Me.grdModelosImportados = New DevExpress.XtraGrid.GridControl()
        Me.grvModelosImportados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cModelo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cMarca = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cPielColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cColeccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cFamilia = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cTemporada = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cCorrida = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1.SuspendLayout()
        Me.pnlImportar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPie.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        CType(Me.grdModelosImportados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grvModelosImportados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlImportar)
        Me.Panel1.Controls.Add(Me.pnlTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1089, 75)
        Me.Panel1.TabIndex = 6
        '
        'pnlImportar
        '
        Me.pnlImportar.Controls.Add(Me.lblImportarInformacion)
        Me.pnlImportar.Controls.Add(Me.btnImportarInformacion)
        Me.pnlImportar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlImportar.Location = New System.Drawing.Point(0, 0)
        Me.pnlImportar.Name = "pnlImportar"
        Me.pnlImportar.Size = New System.Drawing.Size(72, 75)
        Me.pnlImportar.TabIndex = 101
        '
        'lblImportarInformacion
        '
        Me.lblImportarInformacion.AutoSize = True
        Me.lblImportarInformacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblImportarInformacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblImportarInformacion.Location = New System.Drawing.Point(13, 45)
        Me.lblImportarInformacion.Name = "lblImportarInformacion"
        Me.lblImportarInformacion.Size = New System.Drawing.Size(45, 13)
        Me.lblImportarInformacion.TabIndex = 114
        Me.lblImportarInformacion.Text = "Importar"
        '
        'btnImportarInformacion
        '
        Me.btnImportarInformacion.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnImportarInformacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnImportarInformacion.Image = Global.Produccion.Vista.My.Resources.Resources.excel_32
        Me.btnImportarInformacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnImportarInformacion.Location = New System.Drawing.Point(20, 12)
        Me.btnImportarInformacion.Name = "btnImportarInformacion"
        Me.btnImportarInformacion.Size = New System.Drawing.Size(32, 32)
        Me.btnImportarInformacion.TabIndex = 113
        Me.btnImportarInformacion.Text = resources.GetString("btnImportarInformacion.Text")
        Me.btnImportarInformacion.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(607, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(482, 75)
        Me.pnlTitulo.TabIndex = 49
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(405, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(77, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 93
        Me.PictureBox1.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(229, 26)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(159, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Carga de Modelos "
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.GroupBox1)
        Me.pnlPie.Controls.Add(Me.Panel6)
        Me.pnlPie.Controls.Add(Me.pnlDatosBotones)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 500)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1089, 81)
        Me.pnlPie.TabIndex = 132
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblUsuario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(112, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 63)
        Me.GroupBox1.TabIndex = 192
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ultima Importación"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(58, 39)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(129, 13)
        Me.lblFecha.TabIndex = 170
        Me.lblFecha.Text = "20/06/2024 05:59:00 PM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 169
        Me.Label3.Text = "Fecha:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(58, 18)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(52, 13)
        Me.lblUsuario.TabIndex = 168
        Me.lblUsuario.Text = "JSORCIA"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Usuario:"
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblRegistrosTitulo)
        Me.Panel6.Controls.Add(Me.lblRegistros)
        Me.Panel6.Location = New System.Drawing.Point(0, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(106, 70)
        Me.Panel6.TabIndex = 191
        '
        'lblRegistrosTitulo
        '
        Me.lblRegistrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistrosTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblRegistrosTitulo.Location = New System.Drawing.Point(12, 10)
        Me.lblRegistrosTitulo.Name = "lblRegistrosTitulo"
        Me.lblRegistrosTitulo.Size = New System.Drawing.Size(86, 23)
        Me.lblRegistrosTitulo.TabIndex = 187
        Me.lblRegistrosTitulo.Text = "Registros"
        Me.lblRegistrosTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegistros
        '
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblRegistros.Location = New System.Drawing.Point(12, 35)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(86, 22)
        Me.lblRegistros.TabIndex = 188
        Me.lblRegistros.Text = "0"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.btnCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblUltimaDistribucion)
        Me.pnlDatosBotones.Controls.Add(Me.lblCancelar)
        Me.pnlDatosBotones.Controls.Add(Me.lblLabelUltimaActualizacion)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(843, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(246, 81)
        Me.pnlDatosBotones.TabIndex = 2
        '
        'btnCancelar
        '
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Produccion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(202, 12)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblUltimaDistribucion
        '
        Me.lblUltimaDistribucion.AutoSize = True
        Me.lblUltimaDistribucion.Location = New System.Drawing.Point(17, 36)
        Me.lblUltimaDistribucion.Name = "lblUltimaDistribucion"
        Me.lblUltimaDistribucion.Size = New System.Drawing.Size(118, 13)
        Me.lblUltimaDistribucion.TabIndex = 166
        Me.lblUltimaDistribucion.Text = "13/02/2019 12:34 p.m."
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(202, 44)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 0
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblLabelUltimaActualizacion
        '
        Me.lblLabelUltimaActualizacion.AutoSize = True
        Me.lblLabelUltimaActualizacion.Location = New System.Drawing.Point(25, 18)
        Me.lblLabelUltimaActualizacion.Name = "lblLabelUltimaActualizacion"
        Me.lblLabelUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblLabelUltimaActualizacion.TabIndex = 165
        Me.lblLabelUltimaActualizacion.Text = "Última Actualización"
        '
        'grdModelosImportados
        '
        Me.grdModelosImportados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdModelosImportados.Location = New System.Drawing.Point(0, 75)
        Me.grdModelosImportados.MainView = Me.grvModelosImportados
        Me.grdModelosImportados.Name = "grdModelosImportados"
        Me.grdModelosImportados.Size = New System.Drawing.Size(1089, 425)
        Me.grdModelosImportados.TabIndex = 133
        Me.grdModelosImportados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grvModelosImportados})
        '
        'grvModelosImportados
        '
        Me.grvModelosImportados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.cModelo, Me.cMarca, Me.cPielColor, Me.cColeccion, Me.cFamilia, Me.cTemporada, Me.cCorrida})
        Me.grvModelosImportados.GridControl = Me.grdModelosImportados
        Me.grvModelosImportados.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.grvModelosImportados.IndicatorWidth = 40
        Me.grvModelosImportados.Name = "grvModelosImportados"
        Me.grvModelosImportados.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled
        Me.grvModelosImportados.OptionsSelection.MultiSelect = True
        Me.grvModelosImportados.OptionsView.ColumnAutoWidth = False
        Me.grvModelosImportados.OptionsView.ShowAutoFilterRow = True
        Me.grvModelosImportados.OptionsView.ShowGroupPanel = False
        '
        'cModelo
        '
        Me.cModelo.AppearanceHeader.Options.UseTextOptions = True
        Me.cModelo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cModelo.Caption = "Modelo"
        Me.cModelo.FieldName = "Modelo"
        Me.cModelo.Name = "cModelo"
        Me.cModelo.OptionsColumn.AllowEdit = False
        Me.cModelo.Visible = True
        Me.cModelo.VisibleIndex = 4
        '
        'cMarca
        '
        Me.cMarca.AppearanceHeader.Options.UseTextOptions = True
        Me.cMarca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cMarca.Caption = "Marca"
        Me.cMarca.FieldName = "Marca"
        Me.cMarca.Name = "cMarca"
        Me.cMarca.OptionsColumn.AllowEdit = False
        Me.cMarca.Visible = True
        Me.cMarca.VisibleIndex = 2
        '
        'cPielColor
        '
        Me.cPielColor.AppearanceHeader.Options.UseTextOptions = True
        Me.cPielColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cPielColor.Caption = "Piel Color"
        Me.cPielColor.FieldName = "PielColor"
        Me.cPielColor.Name = "cPielColor"
        Me.cPielColor.OptionsColumn.AllowEdit = False
        Me.cPielColor.Visible = True
        Me.cPielColor.VisibleIndex = 5
        '
        'cColeccion
        '
        Me.cColeccion.AppearanceHeader.Options.UseTextOptions = True
        Me.cColeccion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cColeccion.Caption = "Colección"
        Me.cColeccion.FieldName = "Coleccion"
        Me.cColeccion.Name = "cColeccion"
        Me.cColeccion.OptionsColumn.AllowEdit = False
        Me.cColeccion.Visible = True
        Me.cColeccion.VisibleIndex = 3
        '
        'cFamilia
        '
        Me.cFamilia.AppearanceHeader.Options.UseTextOptions = True
        Me.cFamilia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cFamilia.Caption = "Familia"
        Me.cFamilia.FieldName = "Familia"
        Me.cFamilia.Name = "cFamilia"
        Me.cFamilia.OptionsColumn.AllowEdit = False
        Me.cFamilia.Visible = True
        Me.cFamilia.VisibleIndex = 1
        '
        'cTemporada
        '
        Me.cTemporada.AppearanceHeader.Options.UseTextOptions = True
        Me.cTemporada.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cTemporada.Caption = "Temporada"
        Me.cTemporada.FieldName = "Temporada"
        Me.cTemporada.Name = "cTemporada"
        Me.cTemporada.OptionsColumn.AllowEdit = False
        Me.cTemporada.Visible = True
        Me.cTemporada.VisibleIndex = 0
        '
        'cCorrida
        '
        Me.cCorrida.AppearanceHeader.Options.UseTextOptions = True
        Me.cCorrida.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cCorrida.Caption = "Corrrida"
        Me.cCorrida.FieldName = "Corrida"
        Me.cCorrida.Name = "cCorrida"
        Me.cCorrida.OptionsColumn.AllowEdit = False
        Me.cCorrida.Visible = True
        Me.cCorrida.VisibleIndex = 6
        '
        'AdministracionKiosko_CargaModelosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1089, 581)
        Me.Controls.Add(Me.grdModelosImportados)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.Panel1)
        Me.MaximumSize = New System.Drawing.Size(1105, 620)
        Me.MinimumSize = New System.Drawing.Size(1105, 620)
        Me.Name = "AdministracionKiosko_CargaModelosForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de Modelos "
        Me.Panel1.ResumeLayout(False)
        Me.pnlImportar.ResumeLayout(False)
        Me.pnlImportar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPie.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        CType(Me.grdModelosImportados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grvModelosImportados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pnlPie As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblRegistrosTitulo As Label
    Friend WithEvents lblRegistros As Label
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents lblUltimaDistribucion As Label
    Friend WithEvents lblCancelar As Label
    Friend WithEvents lblLabelUltimaActualizacion As Label
    Friend WithEvents grdModelosImportados As DevExpress.XtraGrid.GridControl
    Friend WithEvents grvModelosImportados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cModelo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cMarca As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cPielColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cColeccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cFamilia As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cTemporada As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cCorrida As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pnlImportar As Panel
    Friend WithEvents lblImportarInformacion As Label
    Friend WithEvents btnImportarInformacion As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblUsuario As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblFecha As Label
End Class
