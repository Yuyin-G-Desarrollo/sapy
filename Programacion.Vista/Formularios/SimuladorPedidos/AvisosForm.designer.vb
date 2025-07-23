<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvisosForm
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
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pcbTitulo = New System.Windows.Forms.PictureBox()
        Me.btnBajaAvisos = New System.Windows.Forms.Button()
        Me.lblBajas = New System.Windows.Forms.Label()
        Me.btnAltasAvisos = New System.Windows.Forms.Button()
        Me.lblAltas = New System.Windows.Forms.Label()
        Me.bntBajasUsuario = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.btnAltasUsuario = New System.Windows.Forms.Button()
        Me.lblActualizar = New System.Windows.Forms.Label()
        Me.pnlPrincipal = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.cmbUsuario = New System.Windows.Forms.ComboBox()
        Me.grdUsuarios = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.grdDatos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnBajaAvisos)
        Me.pnlEncabezado.Controls.Add(Me.lblBajas)
        Me.pnlEncabezado.Controls.Add(Me.btnAltasAvisos)
        Me.pnlEncabezado.Controls.Add(Me.lblAltas)
        Me.pnlEncabezado.Controls.Add(Me.bntBajasUsuario)
        Me.pnlEncabezado.Controls.Add(Me.lblExportarExcel)
        Me.pnlEncabezado.Controls.Add(Me.btnAltasUsuario)
        Me.pnlEncabezado.Controls.Add(Me.lblActualizar)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(830, 59)
        Me.pnlEncabezado.TabIndex = 3
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.Label3)
        Me.pnlTitulo.Controls.Add(Me.pcbTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(557, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(273, 59)
        Me.pnlTitulo.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(138, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Avisos"
        '
        'pcbTitulo
        '
        Me.pcbTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pcbTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pcbTitulo.Location = New System.Drawing.Point(205, 0)
        Me.pcbTitulo.Name = "pcbTitulo"
        Me.pcbTitulo.Size = New System.Drawing.Size(68, 59)
        Me.pcbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbTitulo.TabIndex = 0
        Me.pcbTitulo.TabStop = False
        '
        'btnBajaAvisos
        '
        Me.btnBajaAvisos.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
        Me.btnBajaAvisos.Location = New System.Drawing.Point(98, 7)
        Me.btnBajaAvisos.Name = "btnBajaAvisos"
        Me.btnBajaAvisos.Size = New System.Drawing.Size(32, 32)
        Me.btnBajaAvisos.TabIndex = 28
        Me.btnBajaAvisos.UseVisualStyleBackColor = True
        '
        'lblBajas
        '
        Me.lblBajas.AutoSize = True
        Me.lblBajas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBajas.Location = New System.Drawing.Point(81, 42)
        Me.lblBajas.Name = "lblBajas"
        Me.lblBajas.Size = New System.Drawing.Size(77, 13)
        Me.lblBajas.TabIndex = 29
        Me.lblBajas.Text = "Eliminar Avisos"
        '
        'btnAltasAvisos
        '
        Me.btnAltasAvisos.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAltasAvisos.Location = New System.Drawing.Point(30, 7)
        Me.btnAltasAvisos.Name = "btnAltasAvisos"
        Me.btnAltasAvisos.Size = New System.Drawing.Size(32, 32)
        Me.btnAltasAvisos.TabIndex = 26
        Me.btnAltasAvisos.UseVisualStyleBackColor = True
        '
        'lblAltas
        '
        Me.lblAltas.AutoSize = True
        Me.lblAltas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltas.Location = New System.Drawing.Point(14, 42)
        Me.lblAltas.Name = "lblAltas"
        Me.lblAltas.Size = New System.Drawing.Size(64, 13)
        Me.lblAltas.TabIndex = 27
        Me.lblAltas.Text = "Altas Avisos"
        '
        'bntBajasUsuario
        '
        Me.bntBajasUsuario.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.cancelar_32
        Me.bntBajasUsuario.Location = New System.Drawing.Point(493, 7)
        Me.bntBajasUsuario.Name = "bntBajasUsuario"
        Me.bntBajasUsuario.Size = New System.Drawing.Size(32, 32)
        Me.bntBajasUsuario.TabIndex = 24
        Me.bntBajasUsuario.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(473, 42)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(82, 13)
        Me.lblExportarExcel.TabIndex = 25
        Me.lblExportarExcel.Text = "Eliminar Usuario"
        '
        'btnAltasUsuario
        '
        Me.btnAltasUsuario.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAltasUsuario.Location = New System.Drawing.Point(416, 7)
        Me.btnAltasUsuario.Name = "btnAltasUsuario"
        Me.btnAltasUsuario.Size = New System.Drawing.Size(32, 32)
        Me.btnAltasUsuario.TabIndex = 22
        Me.btnAltasUsuario.UseVisualStyleBackColor = True
        '
        'lblActualizar
        '
        Me.lblActualizar.AutoSize = True
        Me.lblActualizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizar.Location = New System.Drawing.Point(398, 42)
        Me.lblActualizar.Name = "lblActualizar"
        Me.lblActualizar.Size = New System.Drawing.Size(69, 13)
        Me.lblActualizar.TabIndex = 23
        Me.lblActualizar.Text = "Altas Usuario"
        '
        'pnlPrincipal
        '
        Me.pnlPrincipal.Controls.Add(Me.Panel1)
        Me.pnlPrincipal.Controls.Add(Me.grdDatos)
        Me.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPrincipal.Location = New System.Drawing.Point(0, 59)
        Me.pnlPrincipal.Name = "pnlPrincipal"
        Me.pnlPrincipal.Padding = New System.Windows.Forms.Padding(11, 3, 11, 11)
        Me.pnlPrincipal.Size = New System.Drawing.Size(830, 484)
        Me.pnlPrincipal.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.grdUsuarios)
        Me.Panel1.Location = New System.Drawing.Point(176, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(643, 415)
        Me.Panel1.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUsuario)
        Me.GroupBox1.Controls.Add(Me.cmbUsuario)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(611, 75)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Selecciona aviso para usuario en la hora seleccionada"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(69, 31)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 36
        Me.lblUsuario.Text = "Usuario"
        '
        'cmbUsuario
        '
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.Location = New System.Drawing.Point(132, 27)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(419, 21)
        Me.cmbUsuario.TabIndex = 35
        '
        'grdUsuarios
        '
        Me.grdUsuarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdUsuarios.DisplayLayout.Appearance = Appearance1
        Me.grdUsuarios.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdUsuarios.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdUsuarios.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdUsuarios.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdUsuarios.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdUsuarios.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdUsuarios.Location = New System.Drawing.Point(15, 97)
        Me.grdUsuarios.Name = "grdUsuarios"
        Me.grdUsuarios.Size = New System.Drawing.Size(611, 300)
        Me.grdUsuarios.TabIndex = 37
        Me.grdUsuarios.Text = "Usuarios"
        '
        'grdDatos
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatos.DisplayLayout.Appearance = Appearance3
        Me.grdDatos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdDatos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDatos.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdDatos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdDatos.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdDatos.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdDatos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdDatos.Location = New System.Drawing.Point(8, 6)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.Size = New System.Drawing.Size(162, 412)
        Me.grdDatos.TabIndex = 6
        Me.grdDatos.Text = "Avisos"
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.Panel2)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 483)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(830, 60)
        Me.pnlExtado.TabIndex = 14
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblCancelar)
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(699, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(131, 60)
        Me.Panel2.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(75, 42)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(76, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'AvisosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(830, 543)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlPrincipal)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "AvisosForm"
        Me.Text = "Avisos"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pcbTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrincipal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grdUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlPrincipal As System.Windows.Forms.Panel
    Friend WithEvents btnAltasUsuario As System.Windows.Forms.Button
    Friend WithEvents lblActualizar As System.Windows.Forms.Label
    Friend WithEvents bntBajasUsuario As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents grdDatos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents btnAltasAvisos As System.Windows.Forms.Button
    Friend WithEvents lblAltas As System.Windows.Forms.Label
    Friend WithEvents btnBajaAvisos As System.Windows.Forms.Button
    Friend WithEvents lblBajas As System.Windows.Forms.Label
    Friend WithEvents cmbUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents grdUsuarios As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pcbTitulo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
