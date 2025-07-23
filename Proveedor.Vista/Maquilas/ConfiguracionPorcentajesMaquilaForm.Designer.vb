<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionPorcentajesMaquilaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfiguracionPorcentajesMaquilaForm))
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblNumeroSemana = New System.Windows.Forms.Label()
        Me.lblsemana = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.lbldatosguardados = New System.Windows.Forms.Label()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlGuardar = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlCerrar = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.gdvDatosConfiguracionPorcentajeMaquilas = New DevExpress.XtraGrid.GridControl()
        Me.vwDatosConfiguracionPorcentajeMaquilas = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlGuardar.SuspendLayout()
        Me.pnlCerrar.SuspendLayout()
        CType(Me.gdvDatosConfiguracionPorcentajeMaquilas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwDatosConfiguracionPorcentajeMaquilas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblEncabezado)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(398, 0)
        Me.pnlTitulo.MaximumSize = New System.Drawing.Size(410, 69)
        Me.pnlTitulo.MinimumSize = New System.Drawing.Size(410, 69)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(410, 69)
        Me.pnlTitulo.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(21, 21)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(287, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Configuración Porcentajes Maquila"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblNumeroSemana)
        Me.pnlHeader.Controls.Add(Me.lblsemana)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(808, 69)
        Me.pnlHeader.TabIndex = 35
        '
        'lblNumeroSemana
        '
        Me.lblNumeroSemana.AutoSize = True
        Me.lblNumeroSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroSemana.Location = New System.Drawing.Point(137, 40)
        Me.lblNumeroSemana.Name = "lblNumeroSemana"
        Me.lblNumeroSemana.Size = New System.Drawing.Size(127, 15)
        Me.lblNumeroSemana.TabIndex = 8
        Me.lblNumeroSemana.Text = "lblNumeroSemana"
        Me.lblNumeroSemana.Visible = False
        '
        'lblsemana
        '
        Me.lblsemana.AutoSize = True
        Me.lblsemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsemana.Location = New System.Drawing.Point(24, 40)
        Me.lblsemana.Name = "lblsemana"
        Me.lblsemana.Size = New System.Drawing.Size(107, 15)
        Me.lblsemana.TabIndex = 7
        Me.lblsemana.Text = "Semana Actual:"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.lbldatosguardados)
        Me.pnlEstado.Controls.Add(Me.pnlOperaciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 493)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(808, 65)
        Me.pnlEstado.TabIndex = 39
        '
        'lbldatosguardados
        '
        Me.lbldatosguardados.AutoSize = True
        Me.lbldatosguardados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldatosguardados.Location = New System.Drawing.Point(12, 21)
        Me.lbldatosguardados.Name = "lbldatosguardados"
        Me.lbldatosguardados.Size = New System.Drawing.Size(387, 15)
        Me.lbldatosguardados.TabIndex = 38
        Me.lbldatosguardados.Text = "Los cambios guardados, serán aplicados apartir de la semana actual."
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.Panel1)
        Me.pnlOperaciones.Controls.Add(Me.Label1)
        Me.pnlOperaciones.Controls.Add(Me.pnlGuardar)
        Me.pnlOperaciones.Controls.Add(Me.pnlCerrar)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlOperaciones.Location = New System.Drawing.Point(375, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(433, 65)
        Me.pnlOperaciones.TabIndex = 37
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnLimpiar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(253, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(60, 65)
        Me.Panel1.TabIndex = 107
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Image = Global.Proveedor.Vista.My.Resources.Resources.limpiar_32
        Me.BtnLimpiar.Location = New System.Drawing.Point(14, 6)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.BtnLimpiar.TabIndex = 20
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(11, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Limpiar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Purple
        Me.Label1.Location = New System.Drawing.Point(105, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 17)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Datos Modificados"
        '
        'pnlGuardar
        '
        Me.pnlGuardar.Controls.Add(Me.btnGuardar)
        Me.pnlGuardar.Controls.Add(Me.lblGuardar)
        Me.pnlGuardar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlGuardar.Location = New System.Drawing.Point(313, 0)
        Me.pnlGuardar.Name = "pnlGuardar"
        Me.pnlGuardar.Size = New System.Drawing.Size(60, 65)
        Me.pnlGuardar.TabIndex = 105
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(14, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 20
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(8, 41)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 21
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlCerrar
        '
        Me.pnlCerrar.Controls.Add(Me.btnCerrar)
        Me.pnlCerrar.Controls.Add(Me.lblCerrar)
        Me.pnlCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCerrar.Location = New System.Drawing.Point(373, 0)
        Me.pnlCerrar.Name = "pnlCerrar"
        Me.pnlCerrar.Size = New System.Drawing.Size(60, 65)
        Me.pnlCerrar.TabIndex = 104
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(14, 6)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 20
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(13, 41)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 21
        Me.lblCerrar.Text = "Cerrar"
        '
        'gdvDatosConfiguracionPorcentajeMaquilas
        '
        Me.gdvDatosConfiguracionPorcentajeMaquilas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gdvDatosConfiguracionPorcentajeMaquilas.Location = New System.Drawing.Point(0, 69)
        Me.gdvDatosConfiguracionPorcentajeMaquilas.MainView = Me.vwDatosConfiguracionPorcentajeMaquilas
        Me.gdvDatosConfiguracionPorcentajeMaquilas.Name = "gdvDatosConfiguracionPorcentajeMaquilas"
        Me.gdvDatosConfiguracionPorcentajeMaquilas.Size = New System.Drawing.Size(808, 424)
        Me.gdvDatosConfiguracionPorcentajeMaquilas.TabIndex = 40
        Me.gdvDatosConfiguracionPorcentajeMaquilas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.vwDatosConfiguracionPorcentajeMaquilas})
        '
        'vwDatosConfiguracionPorcentajeMaquilas
        '
        Me.vwDatosConfiguracionPorcentajeMaquilas.ActiveFilterEnabled = False
        Me.vwDatosConfiguracionPorcentajeMaquilas.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1})
        Me.vwDatosConfiguracionPorcentajeMaquilas.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn1, Me.BandedGridColumn2})
        Me.vwDatosConfiguracionPorcentajeMaquilas.GridControl = Me.gdvDatosConfiguracionPorcentajeMaquilas
        Me.vwDatosConfiguracionPorcentajeMaquilas.Name = "vwDatosConfiguracionPorcentajeMaquilas"
        Me.vwDatosConfiguracionPorcentajeMaquilas.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.vwDatosConfiguracionPorcentajeMaquilas.OptionsCustomization.AllowColumnMoving = False
        Me.vwDatosConfiguracionPorcentajeMaquilas.OptionsCustomization.AllowSort = False
        Me.vwDatosConfiguracionPorcentajeMaquilas.OptionsMenu.EnableColumnMenu = False
        Me.vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ShowAutoFilterRow = True
        Me.vwDatosConfiguracionPorcentajeMaquilas.OptionsView.ShowGroupPanel = False
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowMove = False
        Me.BandedGridColumn1.OptionsColumn.AllowShowHide = False
        Me.BandedGridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(342, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 69)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 46
        Me.PictureBox1.TabStop = False
        '
        'ConfiguracionPorcentajesMaquilaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 558)
        Me.Controls.Add(Me.gdvDatosConfiguracionPorcentajeMaquilas)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(816, 585)
        Me.MinimumSize = New System.Drawing.Size(816, 585)
        Me.Name = "ConfiguracionPorcentajesMaquilaForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Porcentajes Maquila"
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlEstado.PerformLayout()
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlGuardar.ResumeLayout(False)
        Me.pnlGuardar.PerformLayout()
        Me.pnlCerrar.ResumeLayout(False)
        Me.pnlCerrar.PerformLayout()
        CType(Me.gdvDatosConfiguracionPorcentajeMaquilas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwDatosConfiguracionPorcentajeMaquilas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblEncabezado As Windows.Forms.Label
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents pnlEstado As Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As Windows.Forms.Panel
    Friend WithEvents pnlGuardar As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents pnlCerrar As Windows.Forms.Panel
    Friend WithEvents btnCerrar As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents gdvDatosConfiguracionPorcentajeMaquilas As DevExpress.XtraGrid.GridControl
    Friend WithEvents lbldatosguardados As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lblNumeroSemana As Windows.Forms.Label
    Friend WithEvents lblsemana As Windows.Forms.Label
    Friend WithEvents vwDatosConfiguracionPorcentajeMaquilas As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents BtnLimpiar As Windows.Forms.Button
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
End Class
