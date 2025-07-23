<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DetallesNotaCreditoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetallesNotaCreditoForm))
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlBanner = New System.Windows.Forms.Panel()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lblpares = New System.Windows.Forms.Label()
        Me.Lblcliente = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.grdDetallesNotaCredito = New DevExpress.XtraGrid.GridControl()
        Me.wvDetallesNotaCredito = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblNoRegistros = New System.Windows.Forms.Label()
        Me.lblultimaFecActualizacion = New System.Windows.Forms.Label()
        Me.lblfolioactual = New System.Windows.Forms.Label()
        Me.lblC_cliente = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblrazSocialemisor = New System.Windows.Forms.Label()
        Me.lblsocialreceptor = New System.Windows.Forms.Label()
        Me.lblfecha = New System.Windows.Forms.Label()
        Me.pnlBanner.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcciones.SuspendLayout()
        Me.gpFecha.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        CType(Me.grdDetallesNotaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wvDetallesNotaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBanner
        '
        Me.pnlBanner.BackColor = System.Drawing.Color.White
        Me.pnlBanner.Controls.Add(Me.btnExportar)
        Me.pnlBanner.Controls.Add(Me.lblExportar)
        Me.pnlBanner.Controls.Add(Me.pnlTitulo)
        Me.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBanner.Location = New System.Drawing.Point(0, 0)
        Me.pnlBanner.Name = "pnlBanner"
        Me.pnlBanner.Size = New System.Drawing.Size(876, 65)
        Me.pnlBanner.TabIndex = 63
        '
        'btnExportar
        '
        Me.btnExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnExportar.Image = Global.Cobranza.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExportar.Location = New System.Drawing.Point(24, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 123
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblExportar.Location = New System.Drawing.Point(18, 43)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 122
        Me.lblExportar.Text = "Exportar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(505, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(371, 65)
        Me.pnlTitulo.TabIndex = 5
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(303, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(68, 65)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 43
        Me.pbYuyin.TabStop = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(95, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(181, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Detalles Nota Crédito"
        '
        'pnlAcciones
        '
        Me.pnlAcciones.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlAcciones.Controls.Add(Me.lblLimpiar)
        Me.pnlAcciones.Controls.Add(Me.btnLimpiar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.gpFecha)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 65)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(876, 128)
        Me.pnlAcciones.TabIndex = 73
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(1302, 76)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 24
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLimpiar.Location = New System.Drawing.Point(1303, 41)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 23
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(1254, 76)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(42, 13)
        Me.lblGuardar.TabIndex = 22
        Me.lblGuardar.Text = "Mostrar"
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Cobranza.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnMostrar.Location = New System.Drawing.Point(1258, 42)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 21
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'gpFecha
        '
        Me.gpFecha.Controls.Add(Me.lblfecha)
        Me.gpFecha.Controls.Add(Me.lblsocialreceptor)
        Me.gpFecha.Controls.Add(Me.lblrazSocialemisor)
        Me.gpFecha.Controls.Add(Me.lblTotalPares)
        Me.gpFecha.Controls.Add(Me.lblC_cliente)
        Me.gpFecha.Controls.Add(Me.lblfolioactual)
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.Label1)
        Me.gpFecha.Controls.Add(Me.Lblpares)
        Me.gpFecha.Controls.Add(Me.Lblcliente)
        Me.gpFecha.Controls.Add(Me.lblFolio)
        Me.gpFecha.Location = New System.Drawing.Point(10, 6)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(846, 111)
        Me.gpFecha.TabIndex = 3
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Información Devolución"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(484, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(484, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 13)
        Me.Label2.TabIndex = 158
        Me.Label2.Text = "Razón Social Receptor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(484, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Razón Social Emisor:"
        '
        'Lblpares
        '
        Me.Lblpares.AutoSize = True
        Me.Lblpares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblpares.Location = New System.Drawing.Point(22, 89)
        Me.Lblpares.Name = "Lblpares"
        Me.Lblpares.Size = New System.Drawing.Size(43, 13)
        Me.Lblpares.TabIndex = 156
        Me.Lblpares.Text = "Pares:"
        '
        'Lblcliente
        '
        Me.Lblcliente.AutoSize = True
        Me.Lblcliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblcliente.Location = New System.Drawing.Point(22, 55)
        Me.Lblcliente.Name = "Lblcliente"
        Me.Lblcliente.Size = New System.Drawing.Size(50, 13)
        Me.Lblcliente.TabIndex = 155
        Me.Lblcliente.Text = "Cliente:"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(22, 25)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(38, 13)
        Me.lblFolio.TabIndex = 154
        Me.lblFolio.Text = "Folio:"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlPie.Controls.Add(Me.lblultimaFecActualizacion)
        Me.pnlPie.Controls.Add(Me.lblNoRegistros)
        Me.pnlPie.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlPie.Controls.Add(Me.Label4)
        Me.pnlPie.Controls.Add(Me.btnCancelar)
        Me.pnlPie.Controls.Add(Me.lblCancelar)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 429)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(876, 62)
        Me.pnlPie.TabIndex = 75
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(615, 16)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(102, 13)
        Me.lblUltimaActualizacion.TabIndex = 156
        Me.lblUltimaActualizacion.Text = "Ultima Actualización"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(58, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Registros"
        '
        'btnCancelar
        '
        Me.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelar.Image = Global.Cobranza.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelar.Location = New System.Drawing.Point(800, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelar.Location = New System.Drawing.Point(800, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 16
        Me.lblCancelar.Text = "Cerrar"
        '
        'grdDetallesNotaCredito
        '
        Me.grdDetallesNotaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdDetallesNotaCredito.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdDetallesNotaCredito.Location = New System.Drawing.Point(0, 193)
        Me.grdDetallesNotaCredito.MainView = Me.wvDetallesNotaCredito
        Me.grdDetallesNotaCredito.Name = "grdDetallesNotaCredito"
        Me.grdDetallesNotaCredito.Size = New System.Drawing.Size(876, 236)
        Me.grdDetallesNotaCredito.TabIndex = 78
        Me.grdDetallesNotaCredito.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.wvDetallesNotaCredito})
        '
        'wvDetallesNotaCredito
        '
        Me.wvDetallesNotaCredito.Appearance.EvenRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.wvDetallesNotaCredito.Appearance.EvenRow.Options.UseBackColor = True
        Me.wvDetallesNotaCredito.GridControl = Me.grdDetallesNotaCredito
        Me.wvDetallesNotaCredito.Name = "wvDetallesNotaCredito"
        Me.wvDetallesNotaCredito.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvDetallesNotaCredito.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.wvDetallesNotaCredito.OptionsCustomization.AllowColumnMoving = False
        Me.wvDetallesNotaCredito.OptionsView.ShowFooter = True
        Me.wvDetallesNotaCredito.OptionsView.ShowGroupPanel = False
        '
        'lblNoRegistros
        '
        Me.lblNoRegistros.AutoSize = True
        Me.lblNoRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRegistros.Location = New System.Drawing.Point(74, 38)
        Me.lblNoRegistros.Name = "lblNoRegistros"
        Me.lblNoRegistros.Size = New System.Drawing.Size(46, 13)
        Me.lblNoRegistros.TabIndex = 158
        Me.lblNoRegistros.Text = "NoReg"
        '
        'lblultimaFecActualizacion
        '
        Me.lblultimaFecActualizacion.AutoSize = True
        Me.lblultimaFecActualizacion.Location = New System.Drawing.Point(615, 40)
        Me.lblultimaFecActualizacion.Name = "lblultimaFecActualizacion"
        Me.lblultimaFecActualizacion.Size = New System.Drawing.Size(127, 13)
        Me.lblultimaFecActualizacion.TabIndex = 159
        Me.lblultimaFecActualizacion.Text = "ultimaFechaActualizacion"
        '
        'lblfolioactual
        '
        Me.lblfolioactual.AutoSize = True
        Me.lblfolioactual.Location = New System.Drawing.Point(101, 25)
        Me.lblfolioactual.Name = "lblfolioactual"
        Me.lblfolioactual.Size = New System.Drawing.Size(32, 13)
        Me.lblfolioactual.TabIndex = 166
        Me.lblfolioactual.Text = "Folio:"
        '
        'lblC_cliente
        '
        Me.lblC_cliente.AutoSize = True
        Me.lblC_cliente.Location = New System.Drawing.Point(101, 55)
        Me.lblC_cliente.Name = "lblC_cliente"
        Me.lblC_cliente.Size = New System.Drawing.Size(42, 13)
        Me.lblC_cliente.TabIndex = 167
        Me.lblC_cliente.Text = "Cliente:"
        '
        'lblTotalPares
        '
        Me.lblTotalPares.AutoSize = True
        Me.lblTotalPares.Location = New System.Drawing.Point(101, 89)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(42, 13)
        Me.lblTotalPares.TabIndex = 168
        Me.lblTotalPares.Text = "Cliente:"
        '
        'lblrazSocialemisor
        '
        Me.lblrazSocialemisor.AutoSize = True
        Me.lblrazSocialemisor.Location = New System.Drawing.Point(636, 25)
        Me.lblrazSocialemisor.Name = "lblrazSocialemisor"
        Me.lblrazSocialemisor.Size = New System.Drawing.Size(42, 13)
        Me.lblrazSocialemisor.TabIndex = 169
        Me.lblrazSocialemisor.Text = "Cliente:"
        '
        'lblsocialreceptor
        '
        Me.lblsocialreceptor.AutoSize = True
        Me.lblsocialreceptor.Location = New System.Drawing.Point(636, 55)
        Me.lblsocialreceptor.Name = "lblsocialreceptor"
        Me.lblsocialreceptor.Size = New System.Drawing.Size(42, 13)
        Me.lblsocialreceptor.TabIndex = 170
        Me.lblsocialreceptor.Text = "Cliente:"
        '
        'lblfecha
        '
        Me.lblfecha.AutoSize = True
        Me.lblfecha.Location = New System.Drawing.Point(636, 89)
        Me.lblfecha.Name = "lblfecha"
        Me.lblfecha.Size = New System.Drawing.Size(42, 13)
        Me.lblfecha.TabIndex = 171
        Me.lblfecha.Text = "Cliente:"
        '
        'DetallesNotaCreditoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 491)
        Me.Controls.Add(Me.grdDetallesNotaCredito)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.pnlBanner)
        Me.MaximumSize = New System.Drawing.Size(884, 518)
        Me.MinimumSize = New System.Drawing.Size(884, 518)
        Me.Name = "DetallesNotaCreditoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalles Nota Crédito"
        Me.pnlBanner.ResumeLayout(False)
        Me.pnlBanner.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        CType(Me.grdDetallesNotaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wvDetallesNotaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBanner As Windows.Forms.Panel
    Friend WithEvents btnExportar As Windows.Forms.Button
    Friend WithEvents lblExportar As Windows.Forms.Label
    Friend WithEvents pnlTitulo As Windows.Forms.Panel
    Friend WithEvents pbYuyin As Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As Windows.Forms.Label
    Friend WithEvents pnlAcciones As Windows.Forms.Panel
    Friend WithEvents lblLimpiar As Windows.Forms.Label
    Friend WithEvents btnLimpiar As Windows.Forms.Button
    Friend WithEvents lblGuardar As Windows.Forms.Label
    Friend WithEvents btnMostrar As Windows.Forms.Button
    Friend WithEvents gpFecha As Windows.Forms.GroupBox
    Friend WithEvents Lblpares As Windows.Forms.Label
    Friend WithEvents Lblcliente As Windows.Forms.Label
    Friend WithEvents lblFolio As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents pnlPie As Windows.Forms.Panel
    Friend WithEvents grdDetallesNotaCredito As DevExpress.XtraGrid.GridControl
    Friend WithEvents wvDetallesNotaCredito As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents lblCancelar As Windows.Forms.Label
    Friend WithEvents lblUltimaActualizacion As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents lblultimaFecActualizacion As Windows.Forms.Label
    Friend WithEvents lblNoRegistros As Windows.Forms.Label
    Friend WithEvents lblTotalPares As Windows.Forms.Label
    Friend WithEvents lblC_cliente As Windows.Forms.Label
    Friend WithEvents lblfolioactual As Windows.Forms.Label
    Friend WithEvents lblfecha As Windows.Forms.Label
    Friend WithEvents lblsocialreceptor As Windows.Forms.Label
    Friend WithEvents lblrazSocialemisor As Windows.Forms.Label
End Class
