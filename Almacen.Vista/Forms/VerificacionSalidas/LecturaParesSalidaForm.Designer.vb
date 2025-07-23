<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LecturaParesSalidaForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LecturaParesSalidaForm))
        Dim GridLevelNode3 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlQuitarLotes = New System.Windows.Forms.Panel()
        Me.btnQuitarDocumentosAndrea = New System.Windows.Forms.Button()
        Me.lblQuitarDocumentos = New System.Windows.Forms.Label()
        Me.pnlAgregarOT = New System.Windows.Forms.Panel()
        Me.btnAgregarOT = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlCambiarVista = New System.Windows.Forms.Panel()
        Me.btnCambiarVista = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlLimpiarPares = New System.Windows.Forms.Panel()
        Me.btnLimpiarPares = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCodigosError = New System.Windows.Forms.Panel()
        Me.btnCodigosConErrores = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlDescartarPares = New System.Windows.Forms.Panel()
        Me.btnDescartarAtados = New System.Windows.Forms.Button()
        Me.lblDescartarP = New System.Windows.Forms.Label()
        Me.pnlDescartarOT = New System.Windows.Forms.Panel()
        Me.btnDescartarLote = New System.Windows.Forms.Button()
        Me.lblDescartarLote = New System.Windows.Forms.Label()
        Me.pnlDetener = New System.Windows.Forms.Panel()
        Me.btnDetener = New System.Windows.Forms.Button()
        Me.lblDetener = New System.Windows.Forms.Label()
        Me.pnlIniciar = New System.Windows.Forms.Panel()
        Me.btnIniciar = New System.Windows.Forms.Button()
        Me.lblIniciar = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblParesDescartados = New System.Windows.Forms.Label()
        Me.lblTextoParesPendientes = New System.Windows.Forms.Label()
        Me.lblTextoParesLeidos = New System.Windows.Forms.Label()
        Me.lblParesConfirmados = New System.Windows.Forms.Label()
        Me.lblTextoTotalPares = New System.Windows.Forms.Label()
        Me.lblTotalPares = New System.Windows.Forms.Label()
        Me.lblTextoTotalOT = New System.Windows.Forms.Label()
        Me.lblTotalOT = New System.Windows.Forms.Label()
        Me.pnlDatosBotones = New System.Windows.Forms.Panel()
        Me.lblAceptar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.pnlTotalOT = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblParesPendientes = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblEtiquetaParesDescartados = New System.Windows.Forms.Label()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.pnlParesExcedente = New System.Windows.Forms.Panel()
        Me.lblPanelParesExcedentes = New System.Windows.Forms.Label()
        Me.lblTextParesExcedentes = New System.Windows.Forms.Label()
        Me.lblDescartarPares = New System.Windows.Forms.Label()
        Me.txtNombreOperador = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblTextoFolio = New System.Windows.Forms.Label()
        Me.lblFolioPaqueteria = New System.Windows.Forms.Label()
        Me.txtFolioPaqueteria = New System.Windows.Forms.TextBox()
        Me.lblTextoMensajeria = New System.Windows.Forms.Label()
        Me.cmbMensajeria = New System.Windows.Forms.ComboBox()
        Me.lblTextoUnidad = New System.Windows.Forms.Label()
        Me.cmbUnidad = New System.Windows.Forms.ComboBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.cmbOperador = New System.Windows.Forms.ComboBox()
        Me.lblCapturaCodigos = New System.Windows.Forms.Label()
        Me.txtLectura = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlParesLeidos = New System.Windows.Forms.Panel()
        Me.lblPanelParesLeidos = New System.Windows.Forms.Label()
        Me.lblParesLeidos = New System.Windows.Forms.Label()
        Me.ProgressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.grdParesConfirmados = New DevExpress.XtraGrid.GridControl()
        Me.viewParesConfirmados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.pnlParesPendientes = New System.Windows.Forms.Panel()
        Me.lblPanelParesPendientes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grdParesPendientes = New DevExpress.XtraGrid.GridControl()
        Me.viewParesPendientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ProgressPanel2 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlQuitarLotes.SuspendLayout()
        Me.pnlAgregarOT.SuspendLayout()
        Me.pnlCambiarVista.SuspendLayout()
        Me.pnlLimpiarPares.SuspendLayout()
        Me.pnlCodigosError.SuspendLayout()
        Me.pnlDescartarPares.SuspendLayout()
        Me.pnlDescartarOT.SuspendLayout()
        Me.pnlDetener.SuspendLayout()
        Me.pnlIniciar.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlDatosBotones.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlParesExcedente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel23.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlParesLeidos.SuspendLayout()
        CType(Me.grdParesConfirmados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewParesConfirmados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParesPendientes.SuspendLayout()
        CType(Me.grdParesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.viewParesPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlQuitarLotes)
        Me.pnlEncabezado.Controls.Add(Me.pnlAgregarOT)
        Me.pnlEncabezado.Controls.Add(Me.pnlCambiarVista)
        Me.pnlEncabezado.Controls.Add(Me.pnlLimpiarPares)
        Me.pnlEncabezado.Controls.Add(Me.pnlCodigosError)
        Me.pnlEncabezado.Controls.Add(Me.pnlDescartarPares)
        Me.pnlEncabezado.Controls.Add(Me.pnlDescartarOT)
        Me.pnlEncabezado.Controls.Add(Me.pnlDetener)
        Me.pnlEncabezado.Controls.Add(Me.pnlIniciar)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1284, 70)
        Me.pnlEncabezado.TabIndex = 26
        '
        'pnlQuitarLotes
        '
        Me.pnlQuitarLotes.Controls.Add(Me.btnQuitarDocumentosAndrea)
        Me.pnlQuitarLotes.Controls.Add(Me.lblQuitarDocumentos)
        Me.pnlQuitarLotes.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlQuitarLotes.Location = New System.Drawing.Point(544, 0)
        Me.pnlQuitarLotes.Name = "pnlQuitarLotes"
        Me.pnlQuitarLotes.Size = New System.Drawing.Size(68, 70)
        Me.pnlQuitarLotes.TabIndex = 125
        '
        'btnQuitarDocumentosAndrea
        '
        Me.btnQuitarDocumentosAndrea.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnQuitarDocumentosAndrea.BackgroundImage = CType(resources.GetObject("btnQuitarDocumentosAndrea.BackgroundImage"), System.Drawing.Image)
        Me.btnQuitarDocumentosAndrea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuitarDocumentosAndrea.Image = Global.Almacen.Vista.My.Resources.Resources.borrar_32
        Me.btnQuitarDocumentosAndrea.Location = New System.Drawing.Point(17, 9)
        Me.btnQuitarDocumentosAndrea.Name = "btnQuitarDocumentosAndrea"
        Me.btnQuitarDocumentosAndrea.Size = New System.Drawing.Size(32, 32)
        Me.btnQuitarDocumentosAndrea.TabIndex = 104
        Me.btnQuitarDocumentosAndrea.UseVisualStyleBackColor = False
        '
        'lblQuitarDocumentos
        '
        Me.lblQuitarDocumentos.AutoSize = True
        Me.lblQuitarDocumentos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblQuitarDocumentos.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblQuitarDocumentos.Location = New System.Drawing.Point(16, 43)
        Me.lblQuitarDocumentos.Name = "lblQuitarDocumentos"
        Me.lblQuitarDocumentos.Size = New System.Drawing.Size(35, 26)
        Me.lblQuitarDocumentos.TabIndex = 103
        Me.lblQuitarDocumentos.Text = "Quitar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lotes"
        Me.lblQuitarDocumentos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAgregarOT
        '
        Me.pnlAgregarOT.Controls.Add(Me.btnAgregarOT)
        Me.pnlAgregarOT.Controls.Add(Me.Label3)
        Me.pnlAgregarOT.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAgregarOT.Location = New System.Drawing.Point(476, 0)
        Me.pnlAgregarOT.Name = "pnlAgregarOT"
        Me.pnlAgregarOT.Size = New System.Drawing.Size(68, 70)
        Me.pnlAgregarOT.TabIndex = 124
        '
        'btnAgregarOT
        '
        Me.btnAgregarOT.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregarOT.BackgroundImage = CType(resources.GetObject("btnAgregarOT.BackgroundImage"), System.Drawing.Image)
        Me.btnAgregarOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAgregarOT.Image = Global.Almacen.Vista.My.Resources.Resources.altas_322
        Me.btnAgregarOT.Location = New System.Drawing.Point(17, 9)
        Me.btnAgregarOT.Name = "btnAgregarOT"
        Me.btnAgregarOT.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregarOT.TabIndex = 104
        Me.btnAgregarOT.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(11, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 26)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Agregar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OT"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlCambiarVista
        '
        Me.pnlCambiarVista.Controls.Add(Me.btnCambiarVista)
        Me.pnlCambiarVista.Controls.Add(Me.Label5)
        Me.pnlCambiarVista.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCambiarVista.Location = New System.Drawing.Point(408, 0)
        Me.pnlCambiarVista.Name = "pnlCambiarVista"
        Me.pnlCambiarVista.Size = New System.Drawing.Size(68, 70)
        Me.pnlCambiarVista.TabIndex = 123
        '
        'btnCambiarVista
        '
        Me.btnCambiarVista.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCambiarVista.BackgroundImage = CType(resources.GetObject("btnCambiarVista.BackgroundImage"), System.Drawing.Image)
        Me.btnCambiarVista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCambiarVista.Image = Global.Almacen.Vista.My.Resources.Resources.catalogos_32
        Me.btnCambiarVista.Location = New System.Drawing.Point(17, 9)
        Me.btnCambiarVista.Name = "btnCambiarVista"
        Me.btnCambiarVista.Size = New System.Drawing.Size(32, 32)
        Me.btnCambiarVista.TabIndex = 104
        Me.btnCambiarVista.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(11, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 26)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Cambiar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vista"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlLimpiarPares
        '
        Me.pnlLimpiarPares.Controls.Add(Me.btnLimpiarPares)
        Me.pnlLimpiarPares.Controls.Add(Me.Label2)
        Me.pnlLimpiarPares.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLimpiarPares.Location = New System.Drawing.Point(340, 0)
        Me.pnlLimpiarPares.Name = "pnlLimpiarPares"
        Me.pnlLimpiarPares.Size = New System.Drawing.Size(68, 70)
        Me.pnlLimpiarPares.TabIndex = 122
        '
        'btnLimpiarPares
        '
        Me.btnLimpiarPares.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnLimpiarPares.BackgroundImage = CType(resources.GetObject("btnLimpiarPares.BackgroundImage"), System.Drawing.Image)
        Me.btnLimpiarPares.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLimpiarPares.Image = Global.Almacen.Vista.My.Resources.Resources.limpiar_321
        Me.btnLimpiarPares.Location = New System.Drawing.Point(17, 9)
        Me.btnLimpiarPares.Name = "btnLimpiarPares"
        Me.btnLimpiarPares.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarPares.TabIndex = 104
        Me.btnLimpiarPares.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 26)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Limpiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pares"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlCodigosError
        '
        Me.pnlCodigosError.Controls.Add(Me.btnCodigosConErrores)
        Me.pnlCodigosError.Controls.Add(Me.Label1)
        Me.pnlCodigosError.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCodigosError.Location = New System.Drawing.Point(272, 0)
        Me.pnlCodigosError.Name = "pnlCodigosError"
        Me.pnlCodigosError.Size = New System.Drawing.Size(68, 70)
        Me.pnlCodigosError.TabIndex = 121
        '
        'btnCodigosConErrores
        '
        Me.btnCodigosConErrores.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCodigosConErrores.BackgroundImage = CType(resources.GetObject("btnCodigosConErrores.BackgroundImage"), System.Drawing.Image)
        Me.btnCodigosConErrores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCodigosConErrores.Image = CType(resources.GetObject("btnCodigosConErrores.Image"), System.Drawing.Image)
        Me.btnCodigosConErrores.Location = New System.Drawing.Point(17, 9)
        Me.btnCodigosConErrores.Name = "btnCodigosConErrores"
        Me.btnCodigosConErrores.Size = New System.Drawing.Size(32, 32)
        Me.btnCodigosConErrores.TabIndex = 104
        Me.btnCodigosConErrores.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(11, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 26)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Codigos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Error"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDescartarPares
        '
        Me.pnlDescartarPares.Controls.Add(Me.btnDescartarAtados)
        Me.pnlDescartarPares.Controls.Add(Me.lblDescartarP)
        Me.pnlDescartarPares.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescartarPares.Location = New System.Drawing.Point(204, 0)
        Me.pnlDescartarPares.Name = "pnlDescartarPares"
        Me.pnlDescartarPares.Size = New System.Drawing.Size(68, 70)
        Me.pnlDescartarPares.TabIndex = 120
        '
        'btnDescartarAtados
        '
        Me.btnDescartarAtados.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnDescartarAtados.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar_32
        Me.btnDescartarAtados.Location = New System.Drawing.Point(20, 9)
        Me.btnDescartarAtados.Name = "btnDescartarAtados"
        Me.btnDescartarAtados.Size = New System.Drawing.Size(32, 32)
        Me.btnDescartarAtados.TabIndex = 105
        Me.btnDescartarAtados.UseVisualStyleBackColor = False
        '
        'lblDescartarP
        '
        Me.lblDescartarP.AutoSize = True
        Me.lblDescartarP.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDescartarP.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescartarP.Location = New System.Drawing.Point(9, 43)
        Me.lblDescartarP.Name = "lblDescartarP"
        Me.lblDescartarP.Size = New System.Drawing.Size(53, 26)
        Me.lblDescartarP.TabIndex = 106
        Me.lblDescartarP.Text = "Descartar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pares"
        Me.lblDescartarP.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDescartarOT
        '
        Me.pnlDescartarOT.Controls.Add(Me.btnDescartarLote)
        Me.pnlDescartarOT.Controls.Add(Me.lblDescartarLote)
        Me.pnlDescartarOT.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDescartarOT.Location = New System.Drawing.Point(136, 0)
        Me.pnlDescartarOT.Name = "pnlDescartarOT"
        Me.pnlDescartarOT.Size = New System.Drawing.Size(68, 70)
        Me.pnlDescartarOT.TabIndex = 119
        '
        'btnDescartarLote
        '
        Me.btnDescartarLote.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnDescartarLote.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar_32
        Me.btnDescartarLote.Location = New System.Drawing.Point(17, 9)
        Me.btnDescartarLote.Name = "btnDescartarLote"
        Me.btnDescartarLote.Size = New System.Drawing.Size(32, 32)
        Me.btnDescartarLote.TabIndex = 100
        Me.btnDescartarLote.UseVisualStyleBackColor = False
        '
        'lblDescartarLote
        '
        Me.lblDescartarLote.AutoSize = True
        Me.lblDescartarLote.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDescartarLote.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescartarLote.Location = New System.Drawing.Point(6, 43)
        Me.lblDescartarLote.Name = "lblDescartarLote"
        Me.lblDescartarLote.Size = New System.Drawing.Size(56, 26)
        Me.lblDescartarLote.TabIndex = 101
        Me.lblDescartarLote.Text = "Descartar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OT"
        Me.lblDescartarLote.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDetener
        '
        Me.pnlDetener.Controls.Add(Me.btnDetener)
        Me.pnlDetener.Controls.Add(Me.lblDetener)
        Me.pnlDetener.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDetener.Location = New System.Drawing.Point(68, 0)
        Me.pnlDetener.Name = "pnlDetener"
        Me.pnlDetener.Size = New System.Drawing.Size(68, 70)
        Me.pnlDetener.TabIndex = 118
        '
        'btnDetener
        '
        Me.btnDetener.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnDetener.Image = Global.Almacen.Vista.My.Resources.Resources.cancelar321
        Me.btnDetener.Location = New System.Drawing.Point(14, 9)
        Me.btnDetener.Name = "btnDetener"
        Me.btnDetener.Size = New System.Drawing.Size(32, 32)
        Me.btnDetener.TabIndex = 94
        Me.btnDetener.UseVisualStyleBackColor = False
        '
        'lblDetener
        '
        Me.lblDetener.AutoSize = True
        Me.lblDetener.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblDetener.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDetener.Location = New System.Drawing.Point(8, 43)
        Me.lblDetener.Name = "lblDetener"
        Me.lblDetener.Size = New System.Drawing.Size(45, 13)
        Me.lblDetener.TabIndex = 97
        Me.lblDetener.Text = "Detener"
        '
        'pnlIniciar
        '
        Me.pnlIniciar.Controls.Add(Me.btnIniciar)
        Me.pnlIniciar.Controls.Add(Me.lblIniciar)
        Me.pnlIniciar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlIniciar.Location = New System.Drawing.Point(0, 0)
        Me.pnlIniciar.Name = "pnlIniciar"
        Me.pnlIniciar.Size = New System.Drawing.Size(68, 70)
        Me.pnlIniciar.TabIndex = 117
        '
        'btnIniciar
        '
        Me.btnIniciar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnIniciar.Image = CType(resources.GetObject("btnIniciar.Image"), System.Drawing.Image)
        Me.btnIniciar.Location = New System.Drawing.Point(18, 9)
        Me.btnIniciar.Name = "btnIniciar"
        Me.btnIniciar.Size = New System.Drawing.Size(32, 32)
        Me.btnIniciar.TabIndex = 94
        Me.btnIniciar.UseVisualStyleBackColor = False
        '
        'lblIniciar
        '
        Me.lblIniciar.AutoSize = True
        Me.lblIniciar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblIniciar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIniciar.Location = New System.Drawing.Point(17, 43)
        Me.lblIniciar.Name = "lblIniciar"
        Me.lblIniciar.Size = New System.Drawing.Size(35, 13)
        Me.lblIniciar.TabIndex = 96
        Me.lblIniciar.Text = "Iniciar"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Controls.Add(Me.pbYuyin)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(666, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(618, 70)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(268, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(261, 20)
        Me.lblTitulo.TabIndex = 46
        Me.lblTitulo.Text = "Movimientos Pares Salida WMS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = Global.Almacen.Vista.My.Resources.Resources.logoYuyin
        Me.pbYuyin.Location = New System.Drawing.Point(535, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(83, 70)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.lblParesDescartados)
        Me.Panel2.Controls.Add(Me.lblTextoParesPendientes)
        Me.Panel2.Controls.Add(Me.lblTextoParesLeidos)
        Me.Panel2.Controls.Add(Me.lblParesConfirmados)
        Me.Panel2.Controls.Add(Me.lblTextoTotalPares)
        Me.Panel2.Controls.Add(Me.lblTotalPares)
        Me.Panel2.Controls.Add(Me.lblTextoTotalOT)
        Me.Panel2.Controls.Add(Me.lblTotalOT)
        Me.Panel2.Controls.Add(Me.pnlDatosBotones)
        Me.Panel2.Controls.Add(Me.pnlTotalOT)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 628)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1284, 73)
        Me.Panel2.TabIndex = 37
        '
        'lblParesDescartados
        '
        Me.lblParesDescartados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblParesDescartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesDescartados.Location = New System.Drawing.Point(406, 48)
        Me.lblParesDescartados.Name = "lblParesDescartados"
        Me.lblParesDescartados.Size = New System.Drawing.Size(93, 18)
        Me.lblParesDescartados.TabIndex = 127
        Me.lblParesDescartados.Text = "0"
        Me.lblParesDescartados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTextoParesPendientes
        '
        Me.lblTextoParesPendientes.AutoSize = True
        Me.lblTextoParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoParesPendientes.ForeColor = System.Drawing.Color.Black
        Me.lblTextoParesPendientes.Location = New System.Drawing.Point(311, 8)
        Me.lblTextoParesPendientes.Name = "lblTextoParesPendientes"
        Me.lblTextoParesPendientes.Size = New System.Drawing.Size(86, 32)
        Me.lblTextoParesPendientes.TabIndex = 126
        Me.lblTextoParesPendientes.Text = "Pares " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pendientes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTextoParesPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTextoParesLeidos
        '
        Me.lblTextoParesLeidos.AutoSize = True
        Me.lblTextoParesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoParesLeidos.ForeColor = System.Drawing.Color.Black
        Me.lblTextoParesLeidos.Location = New System.Drawing.Point(225, 10)
        Me.lblTextoParesLeidos.Name = "lblTextoParesLeidos"
        Me.lblTextoParesLeidos.Size = New System.Drawing.Size(55, 32)
        Me.lblTextoParesLeidos.TabIndex = 124
        Me.lblTextoParesLeidos.Text = "Pares " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Leidos"
        Me.lblTextoParesLeidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesConfirmados
        '
        Me.lblParesConfirmados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblParesConfirmados.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesConfirmados.Location = New System.Drawing.Point(206, 47)
        Me.lblParesConfirmados.Name = "lblParesConfirmados"
        Me.lblParesConfirmados.Size = New System.Drawing.Size(89, 18)
        Me.lblParesConfirmados.TabIndex = 123
        Me.lblParesConfirmados.Text = "0"
        Me.lblParesConfirmados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTextoTotalPares
        '
        Me.lblTextoTotalPares.AutoSize = True
        Me.lblTextoTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTotalPares.ForeColor = System.Drawing.Color.Black
        Me.lblTextoTotalPares.Location = New System.Drawing.Point(123, 9)
        Me.lblTextoTotalPares.Name = "lblTextoTotalPares"
        Me.lblTextoTotalPares.Size = New System.Drawing.Size(49, 32)
        Me.lblTextoTotalPares.TabIndex = 122
        Me.lblTextoTotalPares.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pares"
        Me.lblTextoTotalPares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalPares
        '
        Me.lblTotalPares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPares.Location = New System.Drawing.Point(107, 47)
        Me.lblTotalPares.Name = "lblTotalPares"
        Me.lblTotalPares.Size = New System.Drawing.Size(89, 18)
        Me.lblTotalPares.TabIndex = 121
        Me.lblTotalPares.Text = "0"
        Me.lblTotalPares.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTextoTotalOT
        '
        Me.lblTextoTotalOT.AutoSize = True
        Me.lblTextoTotalOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTotalOT.ForeColor = System.Drawing.Color.Black
        Me.lblTextoTotalOT.Location = New System.Drawing.Point(30, 11)
        Me.lblTextoTotalOT.Name = "lblTextoTotalOT"
        Me.lblTextoTotalOT.Size = New System.Drawing.Size(48, 32)
        Me.lblTextoTotalOT.TabIndex = 120
        Me.lblTextoTotalOT.Text = "Total " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "OT"
        Me.lblTextoTotalOT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalOT
        '
        Me.lblTotalOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalOT.Location = New System.Drawing.Point(7, 47)
        Me.lblTotalOT.Name = "lblTotalOT"
        Me.lblTotalOT.Size = New System.Drawing.Size(89, 18)
        Me.lblTotalOT.TabIndex = 119
        Me.lblTotalOT.Text = "0"
        Me.lblTotalOT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDatosBotones
        '
        Me.pnlDatosBotones.Controls.Add(Me.lblAceptar)
        Me.pnlDatosBotones.Controls.Add(Me.btnGuardar)
        Me.pnlDatosBotones.Controls.Add(Me.btnCerrar)
        Me.pnlDatosBotones.Controls.Add(Me.lblCerrar)
        Me.pnlDatosBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDatosBotones.Location = New System.Drawing.Point(1122, 0)
        Me.pnlDatosBotones.Name = "pnlDatosBotones"
        Me.pnlDatosBotones.Size = New System.Drawing.Size(162, 73)
        Me.pnlDatosBotones.TabIndex = 3
        '
        'lblAceptar
        '
        Me.lblAceptar.AutoSize = True
        Me.lblAceptar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAceptar.Location = New System.Drawing.Point(41, 38)
        Me.lblAceptar.Name = "lblAceptar"
        Me.lblAceptar.Size = New System.Drawing.Size(45, 13)
        Me.lblAceptar.TabIndex = 4
        Me.lblAceptar.Text = "Finalizar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardar.Image = Global.Almacen.Vista.My.Resources.Resources.enviarcalculo_32
        Me.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardar.Location = New System.Drawing.Point(45, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCerrar.Location = New System.Drawing.Point(103, 6)
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
        Me.lblCerrar.Location = New System.Drawing.Point(103, 37)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 0
        Me.lblCerrar.Text = "Cerrar"
        '
        'pnlTotalOT
        '
        Me.pnlTotalOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotalOT.Location = New System.Drawing.Point(3, 6)
        Me.pnlTotalOT.Name = "pnlTotalOT"
        Me.pnlTotalOT.Size = New System.Drawing.Size(97, 64)
        Me.pnlTotalOT.TabIndex = 129
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Location = New System.Drawing.Point(102, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(97, 64)
        Me.Panel4.TabIndex = 130
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(202, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(97, 64)
        Me.Panel5.TabIndex = 131
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.lblParesPendientes)
        Me.Panel6.Location = New System.Drawing.Point(302, 6)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(98, 64)
        Me.Panel6.TabIndex = 132
        '
        'lblParesPendientes
        '
        Me.lblParesPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesPendientes.Location = New System.Drawing.Point(3, 40)
        Me.lblParesPendientes.Name = "lblParesPendientes"
        Me.lblParesPendientes.Size = New System.Drawing.Size(90, 18)
        Me.lblParesPendientes.TabIndex = 125
        Me.lblParesPendientes.Text = "0"
        Me.lblParesPendientes.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.lblEtiquetaParesDescartados)
        Me.Panel7.Location = New System.Drawing.Point(402, 6)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(101, 64)
        Me.Panel7.TabIndex = 133
        '
        'lblEtiquetaParesDescartados
        '
        Me.lblEtiquetaParesDescartados.AutoSize = True
        Me.lblEtiquetaParesDescartados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaParesDescartados.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaParesDescartados.Location = New System.Drawing.Point(1, 1)
        Me.lblEtiquetaParesDescartados.Name = "lblEtiquetaParesDescartados"
        Me.lblEtiquetaParesDescartados.Size = New System.Drawing.Size(97, 32)
        Me.lblEtiquetaParesDescartados.TabIndex = 128
        Me.lblEtiquetaParesDescartados.Text = "Pares " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Descartados"
        Me.lblEtiquetaParesDescartados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlParametros
        '
        Me.pnlParametros.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlParametros.Controls.Add(Me.pnlParesExcedente)
        Me.pnlParametros.Controls.Add(Me.lblDescartarPares)
        Me.pnlParametros.Controls.Add(Me.txtNombreOperador)
        Me.pnlParametros.Controls.Add(Me.lblFolio)
        Me.pnlParametros.Controls.Add(Me.lblTextoFolio)
        Me.pnlParametros.Controls.Add(Me.lblFolioPaqueteria)
        Me.pnlParametros.Controls.Add(Me.txtFolioPaqueteria)
        Me.pnlParametros.Controls.Add(Me.lblTextoMensajeria)
        Me.pnlParametros.Controls.Add(Me.cmbMensajeria)
        Me.pnlParametros.Controls.Add(Me.lblTextoUnidad)
        Me.pnlParametros.Controls.Add(Me.cmbUnidad)
        Me.pnlParametros.Controls.Add(Me.lblOperador)
        Me.pnlParametros.Controls.Add(Me.cmbOperador)
        Me.pnlParametros.Controls.Add(Me.lblCapturaCodigos)
        Me.pnlParametros.Controls.Add(Me.txtLectura)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlParametros.Location = New System.Drawing.Point(0, 70)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(1284, 68)
        Me.pnlParametros.TabIndex = 39
        '
        'pnlParesExcedente
        '
        Me.pnlParesExcedente.BackColor = System.Drawing.Color.Crimson
        Me.pnlParesExcedente.Controls.Add(Me.lblPanelParesExcedentes)
        Me.pnlParesExcedente.Controls.Add(Me.lblTextParesExcedentes)
        Me.pnlParesExcedente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParesExcedente.Location = New System.Drawing.Point(0, 0)
        Me.pnlParesExcedente.Name = "pnlParesExcedente"
        Me.pnlParesExcedente.Size = New System.Drawing.Size(1284, 68)
        Me.pnlParesExcedente.TabIndex = 171
        '
        'lblPanelParesExcedentes
        '
        Me.lblPanelParesExcedentes.AutoSize = True
        Me.lblPanelParesExcedentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanelParesExcedentes.ForeColor = System.Drawing.Color.White
        Me.lblPanelParesExcedentes.Location = New System.Drawing.Point(796, 1)
        Me.lblPanelParesExcedentes.Name = "lblPanelParesExcedentes"
        Me.lblPanelParesExcedentes.Size = New System.Drawing.Size(58, 63)
        Me.lblPanelParesExcedentes.TabIndex = 2
        Me.lblPanelParesExcedentes.Text = "0"
        '
        'lblTextParesExcedentes
        '
        Me.lblTextParesExcedentes.AutoSize = True
        Me.lblTextParesExcedentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextParesExcedentes.ForeColor = System.Drawing.Color.White
        Me.lblTextParesExcedentes.Location = New System.Drawing.Point(308, 0)
        Me.lblTextParesExcedentes.Name = "lblTextParesExcedentes"
        Me.lblTextParesExcedentes.Size = New System.Drawing.Size(366, 63)
        Me.lblTextParesExcedentes.TabIndex = 1
        Me.lblTextParesExcedentes.Text = "EXCEDENTE"
        '
        'lblDescartarPares
        '
        Me.lblDescartarPares.AutoSize = True
        Me.lblDescartarPares.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescartarPares.ForeColor = System.Drawing.Color.Red
        Me.lblDescartarPares.Location = New System.Drawing.Point(274, 14)
        Me.lblDescartarPares.Name = "lblDescartarPares"
        Me.lblDescartarPares.Size = New System.Drawing.Size(79, 17)
        Me.lblDescartarPares.TabIndex = 114
        Me.lblDescartarPares.Text = "Descartar"
        '
        'txtNombreOperador
        '
        Me.txtNombreOperador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreOperador.Location = New System.Drawing.Point(457, 39)
        Me.txtNombreOperador.Name = "txtNombreOperador"
        Me.txtNombreOperador.Size = New System.Drawing.Size(248, 20)
        Me.txtNombreOperador.TabIndex = 113
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(121, 14)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(26, 17)
        Me.lblFolio.TabIndex = 112
        Me.lblFolio.Text = "---"
        '
        'lblTextoFolio
        '
        Me.lblTextoFolio.AutoSize = True
        Me.lblTextoFolio.Location = New System.Drawing.Point(85, 14)
        Me.lblTextoFolio.Name = "lblTextoFolio"
        Me.lblTextoFolio.Size = New System.Drawing.Size(29, 13)
        Me.lblTextoFolio.TabIndex = 111
        Me.lblTextoFolio.Text = "Folio"
        '
        'lblFolioPaqueteria
        '
        Me.lblFolioPaqueteria.AutoSize = True
        Me.lblFolioPaqueteria.Location = New System.Drawing.Point(714, 42)
        Me.lblFolioPaqueteria.Name = "lblFolioPaqueteria"
        Me.lblFolioPaqueteria.Size = New System.Drawing.Size(83, 13)
        Me.lblFolioPaqueteria.TabIndex = 109
        Me.lblFolioPaqueteria.Text = "Folio Paqueteria"
        '
        'txtFolioPaqueteria
        '
        Me.txtFolioPaqueteria.Location = New System.Drawing.Point(799, 40)
        Me.txtFolioPaqueteria.Name = "txtFolioPaqueteria"
        Me.txtFolioPaqueteria.Size = New System.Drawing.Size(215, 20)
        Me.txtFolioPaqueteria.TabIndex = 108
        '
        'lblTextoMensajeria
        '
        Me.lblTextoMensajeria.AutoSize = True
        Me.lblTextoMensajeria.Location = New System.Drawing.Point(359, 14)
        Me.lblTextoMensajeria.Name = "lblTextoMensajeria"
        Me.lblTextoMensajeria.Size = New System.Drawing.Size(92, 13)
        Me.lblTextoMensajeria.TabIndex = 107
        Me.lblTextoMensajeria.Text = "* Mensajería Real"
        '
        'cmbMensajeria
        '
        Me.cmbMensajeria.FormattingEnabled = True
        Me.cmbMensajeria.Location = New System.Drawing.Point(457, 11)
        Me.cmbMensajeria.Name = "cmbMensajeria"
        Me.cmbMensajeria.Size = New System.Drawing.Size(248, 21)
        Me.cmbMensajeria.TabIndex = 106
        '
        'lblTextoUnidad
        '
        Me.lblTextoUnidad.AutoSize = True
        Me.lblTextoUnidad.Location = New System.Drawing.Point(756, 15)
        Me.lblTextoUnidad.Name = "lblTextoUnidad"
        Me.lblTextoUnidad.Size = New System.Drawing.Size(41, 13)
        Me.lblTextoUnidad.TabIndex = 105
        Me.lblTextoUnidad.Text = "Unidad"
        '
        'cmbUnidad
        '
        Me.cmbUnidad.FormattingEnabled = True
        Me.cmbUnidad.Location = New System.Drawing.Point(799, 13)
        Me.cmbUnidad.Name = "cmbUnidad"
        Me.cmbUnidad.Size = New System.Drawing.Size(215, 21)
        Me.cmbUnidad.TabIndex = 104
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(402, 41)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(51, 13)
        Me.lblOperador.TabIndex = 103
        Me.lblOperador.Text = "Operador"
        '
        'cmbOperador
        '
        Me.cmbOperador.FormattingEnabled = True
        Me.cmbOperador.Location = New System.Drawing.Point(457, 38)
        Me.cmbOperador.Name = "cmbOperador"
        Me.cmbOperador.Size = New System.Drawing.Size(248, 21)
        Me.cmbOperador.TabIndex = 102
        '
        'lblCapturaCodigos
        '
        Me.lblCapturaCodigos.AutoSize = True
        Me.lblCapturaCodigos.Location = New System.Drawing.Point(15, 45)
        Me.lblCapturaCodigos.Name = "lblCapturaCodigos"
        Me.lblCapturaCodigos.Size = New System.Drawing.Size(99, 13)
        Me.lblCapturaCodigos.TabIndex = 101
        Me.lblCapturaCodigos.Text = "Captura de códigos"
        '
        'txtLectura
        '
        Me.txtLectura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLectura.Enabled = False
        Me.txtLectura.Location = New System.Drawing.Point(121, 42)
        Me.txtLectura.Name = "txtLectura"
        Me.txtLectura.Size = New System.Drawing.Size(233, 20)
        Me.txtLectura.TabIndex = 100
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel23)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 138)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1284, 490)
        Me.Panel1.TabIndex = 40
        '
        'Panel23
        '
        Me.Panel23.Controls.Add(Me.SplitContainer1)
        Me.Panel23.Controls.Add(Me.ProgressPanel2)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel23.Location = New System.Drawing.Point(0, 0)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(1284, 490)
        Me.Panel23.TabIndex = 52
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlParesLeidos)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressPanel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grdParesConfirmados)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlParesPendientes)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdParesPendientes)
        Me.SplitContainer1.Size = New System.Drawing.Size(1284, 490)
        Me.SplitContainer1.SplitterDistance = 622
        Me.SplitContainer1.TabIndex = 171
        '
        'pnlParesLeidos
        '
        Me.pnlParesLeidos.BackColor = System.Drawing.Color.ForestGreen
        Me.pnlParesLeidos.Controls.Add(Me.lblPanelParesLeidos)
        Me.pnlParesLeidos.Controls.Add(Me.lblParesLeidos)
        Me.pnlParesLeidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParesLeidos.Location = New System.Drawing.Point(0, 0)
        Me.pnlParesLeidos.Name = "pnlParesLeidos"
        Me.pnlParesLeidos.Size = New System.Drawing.Size(622, 490)
        Me.pnlParesLeidos.TabIndex = 169
        '
        'lblPanelParesLeidos
        '
        Me.lblPanelParesLeidos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPanelParesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 100.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanelParesLeidos.ForeColor = System.Drawing.Color.White
        Me.lblPanelParesLeidos.Location = New System.Drawing.Point(4, 198)
        Me.lblPanelParesLeidos.Name = "lblPanelParesLeidos"
        Me.lblPanelParesLeidos.Size = New System.Drawing.Size(616, 153)
        Me.lblPanelParesLeidos.TabIndex = 1
        Me.lblPanelParesLeidos.Text = "0"
        Me.lblPanelParesLeidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblParesLeidos
        '
        Me.lblParesLeidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 65.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesLeidos.ForeColor = System.Drawing.Color.White
        Me.lblParesLeidos.Location = New System.Drawing.Point(0, 48)
        Me.lblParesLeidos.Name = "lblParesLeidos"
        Me.lblParesLeidos.Size = New System.Drawing.Size(619, 98)
        Me.lblParesLeidos.TabIndex = 0
        Me.lblParesLeidos.Text = "LEÍDOS"
        Me.lblParesLeidos.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressPanel1
        '
        Me.ProgressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel1.Appearance.Options.UseBackColor = True
        Me.ProgressPanel1.Caption = "Espere Por Favor"
        Me.ProgressPanel1.Description = "Cargando ..."
        Me.ProgressPanel1.Location = New System.Drawing.Point(421, 167)
        Me.ProgressPanel1.Name = "ProgressPanel1"
        Me.ProgressPanel1.Size = New System.Drawing.Size(246, 66)
        Me.ProgressPanel1.TabIndex = 168
        Me.ProgressPanel1.Text = "ProgressPanel1"
        Me.ProgressPanel1.Visible = False
        '
        'grdParesConfirmados
        '
        Me.grdParesConfirmados.Dock = System.Windows.Forms.DockStyle.Fill
        GridLevelNode3.RelationName = "Level1"
        Me.grdParesConfirmados.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode3})
        Me.grdParesConfirmados.Location = New System.Drawing.Point(0, 0)
        Me.grdParesConfirmados.MainView = Me.viewParesConfirmados
        Me.grdParesConfirmados.Name = "grdParesConfirmados"
        Me.grdParesConfirmados.Size = New System.Drawing.Size(622, 490)
        Me.grdParesConfirmados.TabIndex = 42
        Me.grdParesConfirmados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewParesConfirmados, Me.GridView3, Me.GridView4})
        '
        'viewParesConfirmados
        '
        Me.viewParesConfirmados.GridControl = Me.grdParesConfirmados
        Me.viewParesConfirmados.Name = "viewParesConfirmados"
        Me.viewParesConfirmados.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesConfirmados.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesConfirmados.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.viewParesConfirmados.OptionsPrint.AllowMultilineHeaders = True
        Me.viewParesConfirmados.OptionsSelection.MultiSelect = True
        Me.viewParesConfirmados.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.viewParesConfirmados.OptionsView.ColumnAutoWidth = False
        Me.viewParesConfirmados.OptionsView.ShowAutoFilterRow = True
        Me.viewParesConfirmados.OptionsView.ShowFooter = True
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30})
        Me.GridView3.GridControl = Me.grdParesConfirmados
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView3.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView3.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView3.OptionsSelection.MultiSelect = True
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = """"
        Me.GridColumn1.FieldName = "Seleccionar"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 35
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "OT"
        Me.GridColumn3.FieldName = "OT"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 70
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "OTSICY"
        Me.GridColumn4.FieldName = "OTSICY"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 70
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Cliente"
        Me.GridColumn5.FieldName = "Cliente"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 220
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Agente"
        Me.GridColumn6.FieldName = "Agente"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "STATUS"
        Me.GridColumn7.FieldName = "STATUS"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 90
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Tipo OT"
        Me.GridColumn8.FieldName = "TipoOT"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 70
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Pedido SAY"
        Me.GridColumn9.FieldName = "PedidoSAY"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 80
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Pedido SICY"
        Me.GridColumn10.FieldName = "PedidoSICY"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 80
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Orden Cliente"
        Me.GridColumn11.FieldName = "OrdenCliente"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        Me.GridColumn11.Width = 90
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Fecha Entrega Programación"
        Me.GridColumn12.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 120
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Fecha Preparación"
        Me.GridColumn13.FieldName = "FechaPreparacion"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 11
        Me.GridColumn13.Width = 120
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Cantidad"
        Me.GridColumn14.FieldName = "Cantidad"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 12
        Me.GridColumn14.Width = 80
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Confirmados"
        Me.GridColumn15.FieldName = "Confirmados"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 13
        Me.GridColumn15.Width = 80
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Por Confirmar"
        Me.GridColumn16.FieldName = "PorConfirmar"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.AllowEdit = False
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 14
        Me.GridColumn16.Width = 90
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Cancelados"
        Me.GridColumn17.FieldName = "Cancelados"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 15
        Me.GridColumn17.Width = 80
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Usuario Captura"
        Me.GridColumn18.FieldName = "UsuarioCaptura"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 16
        Me.GridColumn18.Width = 90
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Fecha Captura"
        Me.GridColumn19.FieldName = "FechaCaptura"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.AllowEdit = False
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 17
        Me.GridColumn19.Width = 120
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Cita"
        Me.GridColumn20.FieldName = "Cita"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.OptionsColumn.AllowEdit = False
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 18
        Me.GridColumn20.Width = 50
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Usuario Modifico"
        Me.GridColumn21.FieldName = "UsuarioModifico"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.AllowEdit = False
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 19
        Me.GridColumn21.Width = 90
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Fecha Modificación"
        Me.GridColumn22.FieldName = "FechaModificacion"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.AllowEdit = False
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 20
        Me.GridColumn22.Width = 120
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Dias Faltantes"
        Me.GridColumn23.FieldName = "DiasFaltantes"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.AllowEdit = False
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 21
        Me.GridColumn23.Width = 90
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "BE"
        Me.GridColumn24.FieldName = "BE"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.AllowEdit = False
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 22
        Me.GridColumn24.Width = 50
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Motivo Cancelación"
        Me.GridColumn25.FieldName = "MotivoCancelacion"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.AllowEdit = False
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 23
        Me.GridColumn25.Width = 100
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "EstatusID"
        Me.GridColumn26.FieldName = "EstatusID"
        Me.GridColumn26.Name = "GridColumn26"
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "ClaveCitaEntrega"
        Me.GridColumn27.FieldName = "ClaveCitaEntrega"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 24
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "GridColumn3"
        Me.GridColumn28.FieldName = "Observaciones"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 25
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "FechaCitaEntrega"
        Me.GridColumn29.FieldName = "FechaCitaEntrega"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 26
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "HoraCita"
        Me.GridColumn30.FieldName = "HoraCita"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 27
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.grdParesConfirmados
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView4.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView4.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView4.OptionsSelection.MultiSelect = True
        Me.GridView4.OptionsView.ColumnAutoWidth = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowFooter = True
        '
        'pnlParesPendientes
        '
        Me.pnlParesPendientes.BackColor = System.Drawing.Color.Orange
        Me.pnlParesPendientes.Controls.Add(Me.lblPanelParesPendientes)
        Me.pnlParesPendientes.Controls.Add(Me.Label4)
        Me.pnlParesPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlParesPendientes.Location = New System.Drawing.Point(0, 0)
        Me.pnlParesPendientes.Name = "pnlParesPendientes"
        Me.pnlParesPendientes.Size = New System.Drawing.Size(658, 490)
        Me.pnlParesPendientes.TabIndex = 170
        '
        'lblPanelParesPendientes
        '
        Me.lblPanelParesPendientes.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPanelParesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 100.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPanelParesPendientes.ForeColor = System.Drawing.Color.White
        Me.lblPanelParesPendientes.Location = New System.Drawing.Point(0, 198)
        Me.lblPanelParesPendientes.Name = "lblPanelParesPendientes"
        Me.lblPanelParesPendientes.Size = New System.Drawing.Size(655, 153)
        Me.lblPanelParesPendientes.TabIndex = 2
        Me.lblPanelParesPendientes.Text = "0"
        Me.lblPanelParesPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 65.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(23, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(608, 98)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "PENDIENTES"
        '
        'grdParesPendientes
        '
        Me.grdParesPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParesPendientes.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.LightGray
        Me.grdParesPendientes.EmbeddedNavigator.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.grdParesPendientes.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        GridLevelNode1.RelationName = "Level1"
        Me.grdParesPendientes.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.grdParesPendientes.Location = New System.Drawing.Point(0, 0)
        Me.grdParesPendientes.MainView = Me.viewParesPendientes
        Me.grdParesPendientes.Name = "grdParesPendientes"
        Me.grdParesPendientes.Size = New System.Drawing.Size(658, 490)
        Me.grdParesPendientes.TabIndex = 42
        Me.grdParesPendientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.viewParesPendientes, Me.GridView5, Me.GridView6})
        '
        'viewParesPendientes
        '
        Me.viewParesPendientes.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.viewParesPendientes.Appearance.Empty.Options.UseBackColor = True
        Me.viewParesPendientes.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.viewParesPendientes.Appearance.EvenRow.Options.UseBackColor = True
        Me.viewParesPendientes.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.viewParesPendientes.Appearance.OddRow.Options.UseBackColor = True
        Me.viewParesPendientes.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.viewParesPendientes.Appearance.Preview.Options.UseBackColor = True
        Me.viewParesPendientes.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.viewParesPendientes.Appearance.Row.Options.UseBackColor = True
        Me.viewParesPendientes.GridControl = Me.grdParesPendientes
        Me.viewParesPendientes.Name = "viewParesPendientes"
        Me.viewParesPendientes.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesPendientes.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.viewParesPendientes.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.viewParesPendientes.OptionsPrint.AllowMultilineHeaders = True
        Me.viewParesPendientes.OptionsSelection.MultiSelect = True
        Me.viewParesPendientes.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.viewParesPendientes.OptionsView.ColumnAutoWidth = False
        Me.viewParesPendientes.OptionsView.ShowAutoFilterRow = True
        Me.viewParesPendientes.OptionsView.ShowFooter = True
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumn46, Me.GridColumn47, Me.GridColumn48, Me.GridColumn49, Me.GridColumn50, Me.GridColumn51, Me.GridColumn52, Me.GridColumn53, Me.GridColumn54, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumn58})
        Me.GridView5.GridControl = Me.grdParesPendientes
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView5.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView5.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView5.OptionsSelection.MultiSelect = True
        Me.GridView5.OptionsView.ColumnAutoWidth = False
        Me.GridView5.OptionsView.ShowAutoFilterRow = True
        Me.GridView5.OptionsView.ShowFooter = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = """"
        Me.GridColumn2.FieldName = "Seleccionar"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 35
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "OT"
        Me.GridColumn31.FieldName = "OT"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 1
        Me.GridColumn31.Width = 70
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "OTSICY"
        Me.GridColumn32.FieldName = "OTSICY"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 2
        Me.GridColumn32.Width = 70
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Cliente"
        Me.GridColumn33.FieldName = "Cliente"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.OptionsColumn.AllowEdit = False
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 3
        Me.GridColumn33.Width = 220
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Agente"
        Me.GridColumn34.FieldName = "Agente"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 4
        Me.GridColumn34.Width = 80
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "STATUS"
        Me.GridColumn35.FieldName = "STATUS"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.OptionsColumn.AllowEdit = False
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 5
        Me.GridColumn35.Width = 90
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Tipo OT"
        Me.GridColumn36.FieldName = "TipoOT"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.OptionsColumn.AllowEdit = False
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 6
        Me.GridColumn36.Width = 70
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Pedido SAY"
        Me.GridColumn37.FieldName = "PedidoSAY"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.OptionsColumn.AllowEdit = False
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 7
        Me.GridColumn37.Width = 80
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Pedido SICY"
        Me.GridColumn38.FieldName = "PedidoSICY"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.OptionsColumn.AllowEdit = False
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 8
        Me.GridColumn38.Width = 80
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Orden Cliente"
        Me.GridColumn39.FieldName = "OrdenCliente"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.OptionsColumn.AllowEdit = False
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 9
        Me.GridColumn39.Width = 90
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Fecha Entrega Programación"
        Me.GridColumn40.FieldName = "FechaEntregaProgramacion"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.OptionsColumn.AllowEdit = False
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 10
        Me.GridColumn40.Width = 120
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Fecha Preparación"
        Me.GridColumn41.FieldName = "FechaPreparacion"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.OptionsColumn.AllowEdit = False
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 11
        Me.GridColumn41.Width = 120
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Cantidad"
        Me.GridColumn42.FieldName = "Cantidad"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.OptionsColumn.AllowEdit = False
        Me.GridColumn42.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:#.##}")})
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 12
        Me.GridColumn42.Width = 80
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Confirmados"
        Me.GridColumn43.FieldName = "Confirmados"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.OptionsColumn.AllowEdit = False
        Me.GridColumn43.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Confirmados", "{0:#.##}")})
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 13
        Me.GridColumn43.Width = 80
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "Por Confirmar"
        Me.GridColumn44.FieldName = "PorConfirmar"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.OptionsColumn.AllowEdit = False
        Me.GridColumn44.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PorConfirmar", "{0:#.##}")})
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 14
        Me.GridColumn44.Width = 90
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Cancelados"
        Me.GridColumn45.FieldName = "Cancelados"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.OptionsColumn.AllowEdit = False
        Me.GridColumn45.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cancelados", "{0:#.##}")})
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 15
        Me.GridColumn45.Width = 80
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Usuario Captura"
        Me.GridColumn46.FieldName = "UsuarioCaptura"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.OptionsColumn.AllowEdit = False
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 16
        Me.GridColumn46.Width = 90
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Fecha Captura"
        Me.GridColumn47.FieldName = "FechaCaptura"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.OptionsColumn.AllowEdit = False
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 17
        Me.GridColumn47.Width = 120
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Cita"
        Me.GridColumn48.FieldName = "Cita"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.OptionsColumn.AllowEdit = False
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 18
        Me.GridColumn48.Width = 50
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Usuario Modifico"
        Me.GridColumn49.FieldName = "UsuarioModifico"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.OptionsColumn.AllowEdit = False
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 19
        Me.GridColumn49.Width = 90
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Fecha Modificación"
        Me.GridColumn50.FieldName = "FechaModificacion"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.OptionsColumn.AllowEdit = False
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 20
        Me.GridColumn50.Width = 120
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "Dias Faltantes"
        Me.GridColumn51.FieldName = "DiasFaltantes"
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.OptionsColumn.AllowEdit = False
        Me.GridColumn51.Visible = True
        Me.GridColumn51.VisibleIndex = 21
        Me.GridColumn51.Width = 90
        '
        'GridColumn52
        '
        Me.GridColumn52.Caption = "BE"
        Me.GridColumn52.FieldName = "BE"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.OptionsColumn.AllowEdit = False
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 22
        Me.GridColumn52.Width = 50
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "Motivo Cancelación"
        Me.GridColumn53.FieldName = "MotivoCancelacion"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.OptionsColumn.AllowEdit = False
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 23
        Me.GridColumn53.Width = 100
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "EstatusID"
        Me.GridColumn54.FieldName = "EstatusID"
        Me.GridColumn54.Name = "GridColumn54"
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "ClaveCitaEntrega"
        Me.GridColumn55.FieldName = "ClaveCitaEntrega"
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.Visible = True
        Me.GridColumn55.VisibleIndex = 24
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "GridColumn3"
        Me.GridColumn56.FieldName = "Observaciones"
        Me.GridColumn56.Name = "GridColumn56"
        Me.GridColumn56.Visible = True
        Me.GridColumn56.VisibleIndex = 25
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "FechaCitaEntrega"
        Me.GridColumn57.FieldName = "FechaCitaEntrega"
        Me.GridColumn57.Name = "GridColumn57"
        Me.GridColumn57.Visible = True
        Me.GridColumn57.VisibleIndex = 26
        '
        'GridColumn58
        '
        Me.GridColumn58.Caption = "HoraCita"
        Me.GridColumn58.FieldName = "HoraCita"
        Me.GridColumn58.Name = "GridColumn58"
        Me.GridColumn58.Visible = True
        Me.GridColumn58.VisibleIndex = 27
        '
        'GridView6
        '
        Me.GridView6.GridControl = Me.grdParesPendientes
        Me.GridView6.Name = "GridView6"
        Me.GridView6.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView6.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        Me.GridView6.OptionsPrint.AllowMultilineHeaders = True
        Me.GridView6.OptionsSelection.MultiSelect = True
        Me.GridView6.OptionsView.ColumnAutoWidth = False
        Me.GridView6.OptionsView.ShowAutoFilterRow = True
        Me.GridView6.OptionsView.ShowFooter = True
        '
        'ProgressPanel2
        '
        Me.ProgressPanel2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel2.Appearance.Options.UseBackColor = True
        Me.ProgressPanel2.Caption = "Espere Por Favor"
        Me.ProgressPanel2.Description = "Guardando ..."
        Me.ProgressPanel2.Location = New System.Drawing.Point(431, 198)
        Me.ProgressPanel2.Name = "ProgressPanel2"
        Me.ProgressPanel2.Size = New System.Drawing.Size(246, 66)
        Me.ProgressPanel2.TabIndex = 170
        Me.ProgressPanel2.Text = "ProgressPanel2"
        Me.ProgressPanel2.Visible = False
        '
        'LecturaParesSalidaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 701)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlParametros)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "LecturaParesSalidaForm"
        Me.Text = "Captura Pares de Salida"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlQuitarLotes.ResumeLayout(False)
        Me.pnlQuitarLotes.PerformLayout()
        Me.pnlAgregarOT.ResumeLayout(False)
        Me.pnlAgregarOT.PerformLayout()
        Me.pnlCambiarVista.ResumeLayout(False)
        Me.pnlCambiarVista.PerformLayout()
        Me.pnlLimpiarPares.ResumeLayout(False)
        Me.pnlLimpiarPares.PerformLayout()
        Me.pnlCodigosError.ResumeLayout(False)
        Me.pnlCodigosError.PerformLayout()
        Me.pnlDescartarPares.ResumeLayout(False)
        Me.pnlDescartarPares.PerformLayout()
        Me.pnlDescartarOT.ResumeLayout(False)
        Me.pnlDescartarOT.PerformLayout()
        Me.pnlDetener.ResumeLayout(False)
        Me.pnlDetener.PerformLayout()
        Me.pnlIniciar.ResumeLayout(False)
        Me.pnlIniciar.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDatosBotones.ResumeLayout(False)
        Me.pnlDatosBotones.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlParametros.PerformLayout()
        Me.pnlParesExcedente.ResumeLayout(False)
        Me.pnlParesExcedente.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlParesLeidos.ResumeLayout(False)
        CType(Me.grdParesConfirmados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewParesConfirmados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParesPendientes.ResumeLayout(False)
        Me.pnlParesPendientes.PerformLayout()
        CType(Me.grdParesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.viewParesPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlEncabezado As Panel
    Friend WithEvents pnlTitulo As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents pbYuyin As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlDatosBotones As Panel
    Friend WithEvents lblAceptar As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblCerrar As Label
    Friend WithEvents pnlParametros As Panel
    Friend WithEvents btnDetener As Button
    Friend WithEvents lblDetener As Label
    Friend WithEvents lblIniciar As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel23 As Panel
    Friend WithEvents lblCapturaCodigos As Label
    Friend WithEvents txtLectura As TextBox
    Friend WithEvents lblTextoTotalPares As Label
    Friend WithEvents lblTotalPares As Label
    Friend WithEvents ProgressPanel2 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents lblTextoUnidad As Label
    Friend WithEvents cmbUnidad As ComboBox
    Friend WithEvents lblOperador As Label
    Friend WithEvents cmbOperador As ComboBox
    Friend WithEvents lblTextoMensajeria As Label
    Friend WithEvents cmbMensajeria As ComboBox
    Friend WithEvents lblTextoParesPendientes As Label
    Friend WithEvents lblParesPendientes As Label
    Friend WithEvents lblTextoParesLeidos As Label
    Friend WithEvents lblParesConfirmados As Label
    Friend WithEvents lblFolioPaqueteria As Label
    Friend WithEvents txtFolioPaqueteria As TextBox
    Friend WithEvents lblFolio As Label
    Friend WithEvents lblTextoFolio As Label
    Friend WithEvents btnDescartarLote As Button
    Friend WithEvents lblDescartarLote As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents grdParesConfirmados As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewParesConfirmados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdParesPendientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents viewParesPendientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ProgressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents txtNombreOperador As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCodigosConErrores As Button
    Friend WithEvents lblDescartarP As Label
    Friend WithEvents btnDescartarAtados As Button
    Friend WithEvents lblEtiquetaParesDescartados As Label
    Friend WithEvents lblParesDescartados As Label
    Friend WithEvents lblDescartarPares As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents pnlLimpiarPares As Panel
    Friend WithEvents btnLimpiarPares As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents pnlCodigosError As Panel
    Friend WithEvents pnlDescartarPares As Panel
    Friend WithEvents pnlDescartarOT As Panel
    Friend WithEvents pnlDetener As Panel
    Friend WithEvents pnlIniciar As Panel
    Friend WithEvents btnIniciar As Button
    Friend WithEvents lblTextoTotalOT As Label
    Friend WithEvents lblTotalOT As Label
    Friend WithEvents pnlTotalOT As Panel
    Friend WithEvents pnlParesExcedente As Panel
    Friend WithEvents lblPanelParesExcedentes As Label
    Friend WithEvents lblTextParesExcedentes As Label
    Friend WithEvents pnlParesLeidos As Panel
    Friend WithEvents lblPanelParesLeidos As Label
    Friend WithEvents lblParesLeidos As Label
    Friend WithEvents pnlParesPendientes As Panel
    Friend WithEvents lblPanelParesPendientes As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlCambiarVista As Panel
    Friend WithEvents btnCambiarVista As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlAgregarOT As Panel
    Friend WithEvents btnAgregarOT As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents pnlQuitarLotes As Panel
    Friend WithEvents btnQuitarDocumentosAndrea As Button
    Friend WithEvents lblQuitarDocumentos As Label
End Class
