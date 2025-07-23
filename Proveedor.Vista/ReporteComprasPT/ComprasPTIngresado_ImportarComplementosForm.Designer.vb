<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComprasPTIngresado_ImportarComplementosForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComprasPTIngresado_ImportarComplementosForm))
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPDF = New System.Windows.Forms.Button()
        Me.btnXML = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bntSalir = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdListado = New DevExpress.XtraGrid.GridControl()
        Me.gvwListado = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvwListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbParametros
        '
        Me.grbParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 60)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(927, 16)
        Me.grbParametros.TabIndex = 79
        Me.grbParametros.TabStop = False
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.btnExcel)
        Me.pnlHeader.Controls.Add(Me.Label1)
        Me.pnlHeader.Controls.Add(Me.btnPDF)
        Me.pnlHeader.Controls.Add(Me.btnXML)
        Me.pnlHeader.Controls.Add(Me.Label14)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.Label3)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(927, 60)
        Me.pnlHeader.TabIndex = 78
        '
        'btnExcel
        '
        Me.btnExcel.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.Importarexcel_32
        Me.btnExcel.Location = New System.Drawing.Point(10, 3)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExcel.TabIndex = 171
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(5, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Importar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPDF
        '
        Me.btnPDF.BackgroundImage = Global.Proveedor.Vista.My.Resources.Resources.agregar_pdf
        Me.btnPDF.Location = New System.Drawing.Point(122, 3)
        Me.btnPDF.Name = "btnPDF"
        Me.btnPDF.Size = New System.Drawing.Size(32, 32)
        Me.btnPDF.TabIndex = 169
        Me.btnPDF.UseVisualStyleBackColor = True
        '
        'btnXML
        '
        Me.btnXML.Image = Global.Proveedor.Vista.My.Resources.Resources.agregar_xml_32
        Me.btnXML.Location = New System.Drawing.Point(66, 3)
        Me.btnXML.Name = "btnXML"
        Me.btnXML.Size = New System.Drawing.Size(32, 32)
        Me.btnXML.TabIndex = 168
        Me.btnXML.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label14.Location = New System.Drawing.Point(62, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 26)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XML"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(586, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(341, 60)
        Me.pnlTitulo.TabIndex = 1
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(59, 19)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(178, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Cargar Complemento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(117, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 26)
        Me.Label3.TabIndex = 170
        Me.Label3.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PDF"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Controls.Add(Me.Label4)
        Me.pnlBotones.Controls.Add(Me.bntSalir)
        Me.pnlBotones.Controls.Add(Me.lblCerrar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(716, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(211, 60)
        Me.pnlBotones.TabIndex = 6
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.Image = Global.Proveedor.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(136, 7)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(131, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Guardar"
        '
        'bntSalir
        '
        Me.bntSalir.Image = Global.Proveedor.Vista.My.Resources.Resources.salir_32
        Me.bntSalir.Location = New System.Drawing.Point(174, 7)
        Me.bntSalir.Name = "bntSalir"
        Me.bntSalir.Size = New System.Drawing.Size(32, 32)
        Me.bntSalir.TabIndex = 0
        Me.bntSalir.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(175, 42)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 3
        Me.lblCerrar.Text = "Cerrar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.pnlBotones)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 372)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(927, 60)
        Me.Panel1.TabIndex = 80
        '
        'grdListado
        '
        Me.grdListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListado.Location = New System.Drawing.Point(0, 76)
        Me.grdListado.MainView = Me.gvwListado
        Me.grdListado.Name = "grdListado"
        Me.grdListado.Size = New System.Drawing.Size(927, 296)
        Me.grdListado.TabIndex = 81
        Me.grdListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvwListado})
        '
        'gvwListado
        '
        Me.gvwListado.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.gvwListado.Appearance.EvenRow.Options.UseBackColor = True
        Me.gvwListado.GridControl = Me.grdListado
        Me.gvwListado.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", Nothing, "")})
        Me.gvwListado.IndicatorWidth = 25
        Me.gvwListado.Name = "gvwListado"
        Me.gvwListado.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvwListado.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvwListado.OptionsBehavior.Editable = False
        Me.gvwListado.OptionsCustomization.AllowColumnMoving = False
        Me.gvwListado.OptionsCustomization.AllowGroup = False
        Me.gvwListado.OptionsMenu.EnableColumnMenu = False
        Me.gvwListado.OptionsPrint.PrintDetails = True
        Me.gvwListado.OptionsPrint.UsePrintStyles = False
        Me.gvwListado.OptionsView.ColumnAutoWidth = False
        Me.gvwListado.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[False]
        Me.gvwListado.OptionsView.EnableAppearanceEvenRow = True
        Me.gvwListado.OptionsView.EnableAppearanceOddRow = True
        Me.gvwListado.OptionsView.ShowAutoFilterRow = True
        Me.gvwListado.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor
        Me.gvwListado.OptionsView.ShowDetailButtons = False
        Me.gvwListado.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.gvwListado.OptionsView.ShowFooter = True
        Me.gvwListado.OptionsView.ShowGroupPanel = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(273, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 60)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 46
        Me.pbYuyin.TabStop = False
        '
        'ComprasPTIngresado_ImportarComplementosForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 432)
        Me.Controls.Add(Me.grdListado)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ComprasPTIngresado_ImportarComplementosForm"
        Me.Text = "Importar Complementos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvwListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbParametros As Windows.Forms.GroupBox
    Friend WithEvents pnlHeader As Windows.Forms.Panel
    Friend WithEvents btnPDF As Windows.Forms.Button
    Friend WithEvents btnXML As Windows.Forms.Button
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents btnExcel As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlBotones As Windows.Forms.Panel
    Friend WithEvents btnGuardar As Windows.Forms.Button
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents bntSalir As Windows.Forms.Button
    Friend WithEvents lblCerrar As Windows.Forms.Label
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents grdListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvwListado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents OpenFileDialog1 As Windows.Forms.OpenFileDialog
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
End Class
