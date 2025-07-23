<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfiguracionEtiquetasForm
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode2 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblInactivarLengua = New System.Windows.Forms.Label()
        Me.btnInactivarLengua = New System.Windows.Forms.Button()
        Me.lblRechazarLengua = New System.Windows.Forms.Label()
        Me.btnRechazarLengua = New System.Windows.Forms.Button()
        Me.lblAutorizarLengua = New System.Windows.Forms.Label()
        Me.btnAutorizarLengua = New System.Windows.Forms.Button()
        Me.lblAltaEtiquetaClienteColeccion = New System.Windows.Forms.Label()
        Me.btnAltaEtiquetaClienteColeccion = New System.Windows.Forms.Button()
        Me.lblExportar = New System.Windows.Forms.Label()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        Me.lblRechazo = New System.Windows.Forms.Label()
        Me.btnRechazo = New System.Windows.Forms.Button()
        Me.lblPorAutorizar = New System.Windows.Forms.Label()
        Me.btnPorAutorizar = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lblCatalogosParametros = New System.Windows.Forms.Label()
        Me.btnCatalogoParametros = New System.Windows.Forms.Button()
        Me.lblVistaPrevia = New System.Windows.Forms.Label()
        Me.btnVistaPrevia = New System.Windows.Forms.Button()
        Me.lblConfigurarEtiqueta = New System.Windows.Forms.Label()
        Me.btnAlta = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pnlPie = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFechaUltimaActualizacion = New System.Windows.Forms.Label()
        Me.lblTextoUltimaDistribucion = New System.Windows.Forms.Label()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabTipo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grdEtiquetaEspecial = New DevExpress.XtraGrid.GridControl()
        Me.grdVEtiquetaEspecial = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grdEtiquetaYuyin = New DevExpress.XtraGrid.GridControl()
        Me.grdVEtiquetaYuyin = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.grdEtiquetasLengua = New DevExpress.XtraGrid.GridControl()
        Me.viewEtiquetasLengua = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rdbSinDiseño = New System.Windows.Forms.RadioButton()
        Me.rdbConDiseño = New System.Windows.Forms.RadioButton()
        Me.cmbEstatusPedido = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlPie.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabTipo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.grdEtiquetaEspecial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVEtiquetaEspecial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.grdEtiquetaYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVEtiquetaYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.grdEtiquetasLengua, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewEtiquetasLengua, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.cmbEstatusPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblInactivarLengua)
        Me.pnlListaPaises.Controls.Add(Me.btnInactivarLengua)
        Me.pnlListaPaises.Controls.Add(Me.lblRechazarLengua)
        Me.pnlListaPaises.Controls.Add(Me.btnRechazarLengua)
        Me.pnlListaPaises.Controls.Add(Me.lblAutorizarLengua)
        Me.pnlListaPaises.Controls.Add(Me.btnAutorizarLengua)
        Me.pnlListaPaises.Controls.Add(Me.lblAltaEtiquetaClienteColeccion)
        Me.pnlListaPaises.Controls.Add(Me.btnAltaEtiquetaClienteColeccion)
        Me.pnlListaPaises.Controls.Add(Me.lblExportar)
        Me.pnlListaPaises.Controls.Add(Me.btnExportarExcel)
        Me.pnlListaPaises.Controls.Add(Me.lblRechazo)
        Me.pnlListaPaises.Controls.Add(Me.btnRechazo)
        Me.pnlListaPaises.Controls.Add(Me.lblPorAutorizar)
        Me.pnlListaPaises.Controls.Add(Me.btnPorAutorizar)
        Me.pnlListaPaises.Controls.Add(Me.lblAutorizar)
        Me.pnlListaPaises.Controls.Add(Me.btnAutorizar)
        Me.pnlListaPaises.Controls.Add(Me.lblCatalogosParametros)
        Me.pnlListaPaises.Controls.Add(Me.btnCatalogoParametros)
        Me.pnlListaPaises.Controls.Add(Me.lblVistaPrevia)
        Me.pnlListaPaises.Controls.Add(Me.btnVistaPrevia)
        Me.pnlListaPaises.Controls.Add(Me.lblConfigurarEtiqueta)
        Me.pnlListaPaises.Controls.Add(Me.btnAlta)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1077, 72)
        Me.pnlListaPaises.TabIndex = 30
        '
        'lblInactivarLengua
        '
        Me.lblInactivarLengua.AutoSize = True
        Me.lblInactivarLengua.BackColor = System.Drawing.Color.Transparent
        Me.lblInactivarLengua.Enabled = False
        Me.lblInactivarLengua.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblInactivarLengua.Location = New System.Drawing.Point(541, 40)
        Me.lblInactivarLengua.Name = "lblInactivarLengua"
        Me.lblInactivarLengua.Size = New System.Drawing.Size(48, 26)
        Me.lblInactivarLengua.TabIndex = 69
        Me.lblInactivarLengua.Text = "Inactivar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lengua"
        Me.lblInactivarLengua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblInactivarLengua.Visible = False
        '
        'btnInactivarLengua
        '
        Me.btnInactivarLengua.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnInactivarLengua.Enabled = False
        Me.btnInactivarLengua.Image = Global.Programacion.Vista.My.Resources.Resources.cancelar_321
        Me.btnInactivarLengua.Location = New System.Drawing.Point(548, 5)
        Me.btnInactivarLengua.Name = "btnInactivarLengua"
        Me.btnInactivarLengua.Size = New System.Drawing.Size(32, 32)
        Me.btnInactivarLengua.TabIndex = 68
        Me.btnInactivarLengua.UseVisualStyleBackColor = False
        Me.btnInactivarLengua.Visible = False
        '
        'lblRechazarLengua
        '
        Me.lblRechazarLengua.AutoSize = True
        Me.lblRechazarLengua.BackColor = System.Drawing.Color.Transparent
        Me.lblRechazarLengua.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazarLengua.Location = New System.Drawing.Point(472, 40)
        Me.lblRechazarLengua.Name = "lblRechazarLengua"
        Me.lblRechazarLengua.Size = New System.Drawing.Size(53, 26)
        Me.lblRechazarLengua.TabIndex = 67
        Me.lblRechazarLengua.Text = "Rechazar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lengua"
        Me.lblRechazarLengua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRechazarLengua
        '
        Me.btnRechazarLengua.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnRechazarLengua.Image = Global.Programacion.Vista.My.Resources.Resources.rechazar_32
        Me.btnRechazarLengua.Location = New System.Drawing.Point(482, 5)
        Me.btnRechazarLengua.Name = "btnRechazarLengua"
        Me.btnRechazarLengua.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazarLengua.TabIndex = 66
        Me.btnRechazarLengua.UseVisualStyleBackColor = False
        '
        'lblAutorizarLengua
        '
        Me.lblAutorizarLengua.AutoSize = True
        Me.lblAutorizarLengua.BackColor = System.Drawing.Color.Transparent
        Me.lblAutorizarLengua.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizarLengua.Location = New System.Drawing.Point(406, 40)
        Me.lblAutorizarLengua.Name = "lblAutorizarLengua"
        Me.lblAutorizarLengua.Size = New System.Drawing.Size(51, 26)
        Me.lblAutorizarLengua.TabIndex = 65
        Me.lblAutorizarLengua.Text = "Autorizar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lengua"
        Me.lblAutorizarLengua.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAutorizarLengua
        '
        Me.btnAutorizarLengua.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAutorizarLengua.Image = Global.Programacion.Vista.My.Resources.Resources.autorizar_32
        Me.btnAutorizarLengua.Location = New System.Drawing.Point(414, 5)
        Me.btnAutorizarLengua.Name = "btnAutorizarLengua"
        Me.btnAutorizarLengua.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizarLengua.TabIndex = 64
        Me.btnAutorizarLengua.UseVisualStyleBackColor = False
        '
        'lblAltaEtiquetaClienteColeccion
        '
        Me.lblAltaEtiquetaClienteColeccion.AutoSize = True
        Me.lblAltaEtiquetaClienteColeccion.BackColor = System.Drawing.Color.Transparent
        Me.lblAltaEtiquetaClienteColeccion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaEtiquetaClienteColeccion.Location = New System.Drawing.Point(305, 40)
        Me.lblAltaEtiquetaClienteColeccion.Name = "lblAltaEtiquetaClienteColeccion"
        Me.lblAltaEtiquetaClienteColeccion.Size = New System.Drawing.Size(95, 26)
        Me.lblAltaEtiquetaClienteColeccion.TabIndex = 63
        Me.lblAltaEtiquetaClienteColeccion.Text = "Alta Etiqueta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliente - Colección"
        Me.lblAltaEtiquetaClienteColeccion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAltaEtiquetaClienteColeccion
        '
        Me.btnAltaEtiquetaClienteColeccion.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAltaEtiquetaClienteColeccion.Image = Global.Programacion.Vista.My.Resources.Resources.altas_32
        Me.btnAltaEtiquetaClienteColeccion.Location = New System.Drawing.Point(336, 5)
        Me.btnAltaEtiquetaClienteColeccion.Name = "btnAltaEtiquetaClienteColeccion"
        Me.btnAltaEtiquetaClienteColeccion.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaEtiquetaClienteColeccion.TabIndex = 62
        Me.btnAltaEtiquetaClienteColeccion.UseVisualStyleBackColor = False
        '
        'lblExportar
        '
        Me.lblExportar.AutoSize = True
        Me.lblExportar.BackColor = System.Drawing.Color.Transparent
        Me.lblExportar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportar.Location = New System.Drawing.Point(254, 40)
        Me.lblExportar.Name = "lblExportar"
        Me.lblExportar.Size = New System.Drawing.Size(46, 13)
        Me.lblExportar.TabIndex = 61
        Me.lblExportar.Text = "Exportar"
        Me.lblExportar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnExportarExcel.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportarExcel.Location = New System.Drawing.Point(257, 5)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(32, 32)
        Me.btnExportarExcel.TabIndex = 60
        Me.btnExportarExcel.UseVisualStyleBackColor = False
        '
        'lblRechazo
        '
        Me.lblRechazo.AutoSize = True
        Me.lblRechazo.BackColor = System.Drawing.Color.Transparent
        Me.lblRechazo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblRechazo.Location = New System.Drawing.Point(68, 40)
        Me.lblRechazo.Name = "lblRechazo"
        Me.lblRechazo.Size = New System.Drawing.Size(53, 13)
        Me.lblRechazo.TabIndex = 59
        Me.lblRechazo.Text = "Rechazar"
        Me.lblRechazo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnRechazo
        '
        Me.btnRechazo.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnRechazo.Image = Global.Programacion.Vista.My.Resources.Resources.rechazar_32
        Me.btnRechazo.Location = New System.Drawing.Point(77, 5)
        Me.btnRechazo.Name = "btnRechazo"
        Me.btnRechazo.Size = New System.Drawing.Size(32, 32)
        Me.btnRechazo.TabIndex = 58
        Me.btnRechazo.UseVisualStyleBackColor = False
        '
        'lblPorAutorizar
        '
        Me.lblPorAutorizar.AutoSize = True
        Me.lblPorAutorizar.BackColor = System.Drawing.Color.Transparent
        Me.lblPorAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPorAutorizar.Location = New System.Drawing.Point(183, 40)
        Me.lblPorAutorizar.Name = "lblPorAutorizar"
        Me.lblPorAutorizar.Size = New System.Drawing.Size(67, 13)
        Me.lblPorAutorizar.TabIndex = 57
        Me.lblPorAutorizar.Text = "Por Autorizar"
        Me.lblPorAutorizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnPorAutorizar
        '
        Me.btnPorAutorizar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnPorAutorizar.Image = Global.Programacion.Vista.My.Resources.Resources.salida
        Me.btnPorAutorizar.Location = New System.Drawing.Point(195, 5)
        Me.btnPorAutorizar.Name = "btnPorAutorizar"
        Me.btnPorAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnPorAutorizar.TabIndex = 56
        Me.btnPorAutorizar.UseVisualStyleBackColor = False
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.BackColor = System.Drawing.Color.Transparent
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(6, 40)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(48, 13)
        Me.lblAutorizar.TabIndex = 55
        Me.lblAutorizar.Text = "Autorizar"
        Me.lblAutorizar.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAutorizar
        '
        Me.btnAutorizar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAutorizar.Image = Global.Programacion.Vista.My.Resources.Resources.autorizar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(14, 5)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(32, 32)
        Me.btnAutorizar.TabIndex = 54
        Me.btnAutorizar.UseVisualStyleBackColor = False
        '
        'lblCatalogosParametros
        '
        Me.lblCatalogosParametros.AutoSize = True
        Me.lblCatalogosParametros.BackColor = System.Drawing.Color.Transparent
        Me.lblCatalogosParametros.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCatalogosParametros.Location = New System.Drawing.Point(67, 40)
        Me.lblCatalogosParametros.Name = "lblCatalogosParametros"
        Me.lblCatalogosParametros.Size = New System.Drawing.Size(63, 26)
        Me.lblCatalogosParametros.TabIndex = 53
        Me.lblCatalogosParametros.Text = "Catálogo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Parámetros "
        Me.lblCatalogosParametros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCatalogoParametros
        '
        Me.btnCatalogoParametros.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCatalogoParametros.Image = Global.Programacion.Vista.My.Resources.Resources.catalogos_32
        Me.btnCatalogoParametros.Location = New System.Drawing.Point(77, 5)
        Me.btnCatalogoParametros.Name = "btnCatalogoParametros"
        Me.btnCatalogoParametros.Size = New System.Drawing.Size(32, 32)
        Me.btnCatalogoParametros.TabIndex = 52
        Me.btnCatalogoParametros.UseVisualStyleBackColor = False
        '
        'lblVistaPrevia
        '
        Me.lblVistaPrevia.AutoSize = True
        Me.lblVistaPrevia.BackColor = System.Drawing.Color.Transparent
        Me.lblVistaPrevia.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblVistaPrevia.Location = New System.Drawing.Point(133, 40)
        Me.lblVistaPrevia.Name = "lblVistaPrevia"
        Me.lblVistaPrevia.Size = New System.Drawing.Size(37, 26)
        Me.lblVistaPrevia.TabIndex = 51
        Me.lblVistaPrevia.Text = "Vista " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Previa"
        Me.lblVistaPrevia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnVistaPrevia
        '
        Me.btnVistaPrevia.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnVistaPrevia.Image = Global.Programacion.Vista.My.Resources.Resources.codigos
        Me.btnVistaPrevia.Location = New System.Drawing.Point(136, 5)
        Me.btnVistaPrevia.Name = "btnVistaPrevia"
        Me.btnVistaPrevia.Size = New System.Drawing.Size(32, 32)
        Me.btnVistaPrevia.TabIndex = 50
        Me.btnVistaPrevia.UseVisualStyleBackColor = False
        '
        'lblConfigurarEtiqueta
        '
        Me.lblConfigurarEtiqueta.AutoSize = True
        Me.lblConfigurarEtiqueta.BackColor = System.Drawing.Color.Transparent
        Me.lblConfigurarEtiqueta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConfigurarEtiqueta.Location = New System.Drawing.Point(6, 40)
        Me.lblConfigurarEtiqueta.Name = "lblConfigurarEtiqueta"
        Me.lblConfigurarEtiqueta.Size = New System.Drawing.Size(55, 13)
        Me.lblConfigurarEtiqueta.TabIndex = 47
        Me.lblConfigurarEtiqueta.Text = "Configurar"
        Me.lblConfigurarEtiqueta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAlta
        '
        Me.btnAlta.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAlta.Image = Global.Programacion.Vista.My.Resources.Resources.OProduccion
        Me.btnAlta.Location = New System.Drawing.Point(15, 5)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(32, 32)
        Me.btnAlta.TabIndex = 46
        Me.btnAlta.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.PictureBox1)
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(676, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(401, 72)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(13, 15)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(319, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Configuración de Etiquetas Especiales"
        '
        'pnlPie
        '
        Me.pnlPie.BackColor = System.Drawing.Color.White
        Me.pnlPie.Controls.Add(Me.Label5)
        Me.pnlPie.Controls.Add(Me.Panel2)
        Me.pnlPie.Controls.Add(Me.pnlAcciones)
        Me.pnlPie.Controls.Add(Me.Label4)
        Me.pnlPie.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPie.Location = New System.Drawing.Point(0, 396)
        Me.pnlPie.Name = "pnlPie"
        Me.pnlPie.Size = New System.Drawing.Size(1077, 60)
        Me.pnlPie.TabIndex = 67
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Orange
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(123, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 126
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblFechaUltimaActualizacion)
        Me.Panel2.Controls.Add(Me.lblTextoUltimaDistribucion)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(486, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(426, 60)
        Me.Panel2.TabIndex = 125
        '
        'lblFechaUltimaActualizacion
        '
        Me.lblFechaUltimaActualizacion.AutoSize = True
        Me.lblFechaUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimaActualizacion.ForeColor = System.Drawing.Color.Black
        Me.lblFechaUltimaActualizacion.Location = New System.Drawing.Point(114, 26)
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
        Me.lblTextoUltimaDistribucion.Location = New System.Drawing.Point(3, 26)
        Me.lblTextoUltimaDistribucion.Name = "lblTextoUltimaDistribucion"
        Me.lblTextoUltimaDistribucion.Size = New System.Drawing.Size(105, 13)
        Me.lblTextoUltimaDistribucion.TabIndex = 124
        Me.lblTextoUltimaDistribucion.Text = "Última Actualización:"
        Me.lblTextoUltimaDistribucion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.btnMostrar)
        Me.pnlAcciones.Controls.Add(Me.Label3)
        Me.pnlAcciones.Controls.Add(Me.btnCerrar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(912, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(165, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'btnMostrar
        '
        Me.btnMostrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(46, 7)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 16
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(43, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Mostrar"
        '
        'btnCerrar
        '
        Me.btnCerrar.BackgroundImage = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(106, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(106, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Sin Configuración"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabTipo)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1077, 324)
        Me.Panel1.TabIndex = 68
        '
        'TabTipo
        '
        Me.TabTipo.Controls.Add(Me.TabPage1)
        Me.TabTipo.Controls.Add(Me.TabPage2)
        Me.TabTipo.Controls.Add(Me.TabPage3)
        Me.TabTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabTipo.Location = New System.Drawing.Point(0, 36)
        Me.TabTipo.Name = "TabTipo"
        Me.TabTipo.SelectedIndex = 0
        Me.TabTipo.Size = New System.Drawing.Size(1077, 288)
        Me.TabTipo.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grdEtiquetaEspecial)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1069, 262)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Etiquetas Cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grdEtiquetaEspecial
        '
        Me.grdEtiquetaEspecial.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode1.RelationName = "Level1"
        Me.grdEtiquetaEspecial.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdEtiquetaEspecial.Location = New System.Drawing.Point(3, 3)
        Me.grdEtiquetaEspecial.MainView = Me.grdVEtiquetaEspecial
        Me.grdEtiquetaEspecial.Name = "grdEtiquetaEspecial"
        Me.grdEtiquetaEspecial.Size = New System.Drawing.Size(1063, 256)
        Me.grdEtiquetaEspecial.TabIndex = 2
        Me.grdEtiquetaEspecial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVEtiquetaEspecial})
        '
        'grdVEtiquetaEspecial
        '
        Me.grdVEtiquetaEspecial.Appearance.EvenRow.BackColor = System.Drawing.Color.White
        Me.grdVEtiquetaEspecial.Appearance.EvenRow.Options.UseBackColor = True
        Me.grdVEtiquetaEspecial.Appearance.OddRow.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.grdVEtiquetaEspecial.Appearance.OddRow.Options.UseBackColor = True
        Me.grdVEtiquetaEspecial.GridControl = Me.grdEtiquetaEspecial
        Me.grdVEtiquetaEspecial.Name = "grdVEtiquetaEspecial"
        Me.grdVEtiquetaEspecial.OptionsView.ShowAutoFilterRow = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grdEtiquetaYuyin)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1069, 262)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Etiquetas Yuyin"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grdEtiquetaYuyin
        '
        Me.grdEtiquetaYuyin.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode2.RelationName = "Level1"
        Me.grdEtiquetaYuyin.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode2})
        Me.grdEtiquetaYuyin.Location = New System.Drawing.Point(3, 3)
        Me.grdEtiquetaYuyin.MainView = Me.grdVEtiquetaYuyin
        Me.grdEtiquetaYuyin.Name = "grdEtiquetaYuyin"
        Me.grdEtiquetaYuyin.Size = New System.Drawing.Size(1063, 256)
        Me.grdEtiquetaYuyin.TabIndex = 2
        Me.grdEtiquetaYuyin.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdVEtiquetaYuyin})
        '
        'grdVEtiquetaYuyin
        '
        Me.grdVEtiquetaYuyin.GridControl = Me.grdEtiquetaYuyin
        Me.grdVEtiquetaYuyin.Name = "grdVEtiquetaYuyin"
        Me.grdVEtiquetaYuyin.OptionsView.ShowAutoFilterRow = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grdEtiquetasLengua)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1069, 262)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Lengua"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grdEtiquetasLengua
        '
        Me.grdEtiquetasLengua.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode3.RelationName = "Level1"
        Me.grdEtiquetasLengua.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode3})
        Me.grdEtiquetasLengua.Location = New System.Drawing.Point(3, 3)
        Me.grdEtiquetasLengua.MainView = Me.viewEtiquetasLengua
        Me.grdEtiquetasLengua.Name = "grdEtiquetasLengua"
        Me.grdEtiquetasLengua.Size = New System.Drawing.Size(1063, 256)
        Me.grdEtiquetasLengua.TabIndex = 1
        Me.grdEtiquetasLengua.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewEtiquetasLengua})
        '
        'viewEtiquetasLengua
        '
        Me.viewEtiquetasLengua.GridControl = Me.grdEtiquetasLengua
        Me.viewEtiquetasLengua.Name = "viewEtiquetasLengua"
        Me.viewEtiquetasLengua.OptionsView.ShowAutoFilterRow = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.rdbSinDiseño)
        Me.Panel3.Controls.Add(Me.rdbConDiseño)
        Me.Panel3.Controls.Add(Me.cmbEstatusPedido)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1077, 36)
        Me.Panel3.TabIndex = 1
        '
        'rdbSinDiseño
        '
        Me.rdbSinDiseño.AutoSize = True
        Me.rdbSinDiseño.Location = New System.Drawing.Point(361, 11)
        Me.rdbSinDiseño.Name = "rdbSinDiseño"
        Me.rdbSinDiseño.Size = New System.Drawing.Size(76, 17)
        Me.rdbSinDiseño.TabIndex = 5
        Me.rdbSinDiseño.Text = "Sin Diseño"
        Me.rdbSinDiseño.UseVisualStyleBackColor = True
        Me.rdbSinDiseño.Visible = False
        '
        'rdbConDiseño
        '
        Me.rdbConDiseño.AutoSize = True
        Me.rdbConDiseño.Checked = True
        Me.rdbConDiseño.Location = New System.Drawing.Point(272, 11)
        Me.rdbConDiseño.Name = "rdbConDiseño"
        Me.rdbConDiseño.Size = New System.Drawing.Size(80, 17)
        Me.rdbConDiseño.TabIndex = 4
        Me.rdbConDiseño.TabStop = True
        Me.rdbConDiseño.Text = "Con Diseño"
        Me.rdbConDiseño.UseVisualStyleBackColor = True
        Me.rdbConDiseño.Visible = False
        '
        'cmbEstatusPedido
        '
        Me.cmbEstatusPedido.CheckedListSettings.CheckBoxAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbEstatusPedido.CheckedListSettings.CheckBoxStyle = Infragistics.Win.CheckStyle.CheckBox
        Me.cmbEstatusPedido.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.cmbEstatusPedido.Location = New System.Drawing.Point(59, 9)
        Me.cmbEstatusPedido.Name = "cmbEstatusPedido"
        Me.cmbEstatusPedido.Size = New System.Drawing.Size(194, 21)
        Me.cmbEstatusPedido.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Estatus"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.PictureBox1.Location = New System.Drawing.Point(339, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'ConfiguracionEtiquetasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1077, 456)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPie)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "ConfiguracionEtiquetasForm"
        Me.Text = "Configuración de Etiquetas Especiales"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlPie.ResumeLayout(False)
        Me.pnlPie.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.TabTipo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.grdEtiquetaEspecial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVEtiquetaEspecial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.grdEtiquetaYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVEtiquetaYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.grdEtiquetasLengua, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewEtiquetasLengua, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.cmbEstatusPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents lblConfigurarEtiqueta As System.Windows.Forms.Label
    Friend WithEvents btnAlta As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pnlPie As System.Windows.Forms.Panel
    Friend WithEvents lblFechaUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblTextoUltimaDistribucion As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblVistaPrevia As System.Windows.Forms.Label
    Friend WithEvents btnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabTipo As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents grdEtiquetaEspecial As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVEtiquetaEspecial As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents grdEtiquetaYuyin As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdVEtiquetaYuyin As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents grdEtiquetasLengua As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewEtiquetasLengua As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblCatalogosParametros As Label
    Friend WithEvents btnCatalogoParametros As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbEstatusPedido As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblPorAutorizar As System.Windows.Forms.Label
    Friend WithEvents btnPorAutorizar As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblRechazo As System.Windows.Forms.Label
    Friend WithEvents btnRechazo As System.Windows.Forms.Button
    Friend WithEvents lblExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
    Friend WithEvents lblAltaEtiquetaClienteColeccion As Label
    Friend WithEvents btnAltaEtiquetaClienteColeccion As Button
    Friend WithEvents lblAutorizarLengua As Label
    Friend WithEvents btnAutorizarLengua As Button
    Friend WithEvents lblAutorizar As Label
    Friend WithEvents btnAutorizar As Button
    Friend WithEvents lblRechazarLengua As Label
    Friend WithEvents btnRechazarLengua As Button
    Friend WithEvents rdbSinDiseño As RadioButton
    Friend WithEvents rdbConDiseño As RadioButton
    Friend WithEvents lblInactivarLengua As Label
    Friend WithEvents btnInactivarLengua As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
