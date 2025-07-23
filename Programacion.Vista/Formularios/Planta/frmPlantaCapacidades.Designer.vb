<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlantaCapacidades
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlantaCapacidades))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnEliminarAsignacion = New System.Windows.Forms.Button()
        Me.lblctualizarCelulas = New System.Windows.Forms.Label()
        Me.lblEliminarAsignacion = New System.Windows.Forms.Label()
        Me.btnActualizarCelulas = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblCopiarSemana = New System.Windows.Forms.Label()
        Me.btnCopiarSemanas = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.lblListaNaves = New System.Windows.Forms.Label()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblExportarExcel = New System.Windows.Forms.Label()
        Me.pnlExtado = New System.Windows.Forms.Panel()
        Me.lblSemanaActual = New System.Windows.Forms.Label()
        Me.lblContSeleccionados = New System.Windows.Forms.Label()
        Me.lblEtiquetaSeleccionados = New System.Windows.Forms.Label()
        Me.lblUltimaActualizacion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMostrar = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grpNaves = New System.Windows.Forms.GroupBox()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.numAnioFin = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkNOasignado = New System.Windows.Forms.CheckBox()
        Me.chkAsignado = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chkInactivo = New System.Windows.Forms.CheckBox()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.cmbNaves = New System.Windows.Forms.ComboBox()
        Me.numSemanaFinal = New System.Windows.Forms.NumericUpDown()
        Me.numSemanaInicio = New System.Windows.Forms.NumericUpDown()
        Me.numAnioInicio = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbtProducto = New System.Windows.Forms.TabPage()
        Me.grdProductos = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarProductos = New System.Windows.Forms.CheckBox()
        Me.tbtHorma = New System.Windows.Forms.TabPage()
        Me.grdCapacidadHorma = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarHorma = New System.Windows.Forms.CheckBox()
        Me.tbtGrupo = New System.Windows.Forms.TabPage()
        Me.grdGrupoCapacidad = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarGrupo = New System.Windows.Forms.CheckBox()
        Me.tbtCelulas = New System.Windows.Forms.TabPage()
        Me.grdLineasSemana = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkSeleccionarCelGlobal = New System.Windows.Forms.CheckBox()
        Me.tbtCapacidades = New System.Windows.Forms.TabControl()
        Me.exportExcelDetalle = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExtado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpNaves.SuspendLayout()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemanaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtProducto.SuspendLayout()
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.tbtHorma.SuspendLayout()
        CType(Me.grdCapacidadHorma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.tbtGrupo.SuspendLayout()
        CType(Me.grdGrupoCapacidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.tbtCelulas.SuspendLayout()
        CType(Me.grdLineasSemana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.tbtCapacidades.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlBotones)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnExportar)
        Me.pnlEncabezado.Controls.Add(Me.lblExportarExcel)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1194, 68)
        Me.pnlEncabezado.TabIndex = 4
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnEliminarAsignacion)
        Me.pnlBotones.Controls.Add(Me.lblctualizarCelulas)
        Me.pnlBotones.Controls.Add(Me.lblEliminarAsignacion)
        Me.pnlBotones.Controls.Add(Me.btnActualizarCelulas)
        Me.pnlBotones.Controls.Add(Me.Label11)
        Me.pnlBotones.Controls.Add(Me.lblCopiarSemana)
        Me.pnlBotones.Controls.Add(Me.btnCopiarSemanas)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBotones.Location = New System.Drawing.Point(0, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(200, 68)
        Me.pnlBotones.TabIndex = 43
        '
        'btnEliminarAsignacion
        '
        Me.btnEliminarAsignacion.Enabled = False
        Me.btnEliminarAsignacion.Image = Global.Programacion.Vista.My.Resources.Resources.eliminarAsignacion
        Me.btnEliminarAsignacion.Location = New System.Drawing.Point(149, 7)
        Me.btnEliminarAsignacion.Name = "btnEliminarAsignacion"
        Me.btnEliminarAsignacion.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminarAsignacion.TabIndex = 41
        Me.btnEliminarAsignacion.UseVisualStyleBackColor = True
        '
        'lblctualizarCelulas
        '
        Me.lblctualizarCelulas.AutoSize = True
        Me.lblctualizarCelulas.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblctualizarCelulas.Location = New System.Drawing.Point(13, 39)
        Me.lblctualizarCelulas.Name = "lblctualizarCelulas"
        Me.lblctualizarCelulas.Size = New System.Drawing.Size(53, 26)
        Me.lblctualizarCelulas.TabIndex = 35
        Me.lblctualizarCelulas.Text = "Actualizar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Células"
        Me.lblctualizarCelulas.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEliminarAsignacion
        '
        Me.lblEliminarAsignacion.AutoSize = True
        Me.lblEliminarAsignacion.Enabled = False
        Me.lblEliminarAsignacion.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminarAsignacion.Location = New System.Drawing.Point(136, 39)
        Me.lblEliminarAsignacion.Name = "lblEliminarAsignacion"
        Me.lblEliminarAsignacion.Size = New System.Drawing.Size(58, 26)
        Me.lblEliminarAsignacion.TabIndex = 42
        Me.lblEliminarAsignacion.Text = "Eliminar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Capacidad"
        Me.lblEliminarAsignacion.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnActualizarCelulas
        '
        Me.btnActualizarCelulas.Image = CType(resources.GetObject("btnActualizarCelulas.Image"), System.Drawing.Image)
        Me.btnActualizarCelulas.Location = New System.Drawing.Point(23, 7)
        Me.btnActualizarCelulas.Name = "btnActualizarCelulas"
        Me.btnActualizarCelulas.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizarCelulas.TabIndex = 34
        Me.btnActualizarCelulas.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label11.Location = New System.Drawing.Point(138, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 13)
        Me.Label11.TabIndex = 40
        '
        'lblCopiarSemana
        '
        Me.lblCopiarSemana.AutoSize = True
        Me.lblCopiarSemana.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCopiarSemana.Location = New System.Drawing.Point(79, 39)
        Me.lblCopiarSemana.Name = "lblCopiarSemana"
        Me.lblCopiarSemana.Size = New System.Drawing.Size(46, 26)
        Me.lblCopiarSemana.TabIndex = 36
        Me.lblCopiarSemana.Text = " Copiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Semana"
        Me.lblCopiarSemana.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnCopiarSemanas
        '
        Me.btnCopiarSemanas.Image = CType(resources.GetObject("btnCopiarSemanas.Image"), System.Drawing.Image)
        Me.btnCopiarSemanas.Location = New System.Drawing.Point(86, 7)
        Me.btnCopiarSemanas.Name = "btnCopiarSemanas"
        Me.btnCopiarSemanas.Size = New System.Drawing.Size(32, 32)
        Me.btnCopiarSemanas.TabIndex = 39
        Me.btnCopiarSemanas.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblListaNaves)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(696, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(498, 68)
        Me.pnlTitulo.TabIndex = 33
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(437, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(61, 68)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgLogo.TabIndex = 0
        Me.imgLogo.TabStop = False
        '
        'lblListaNaves
        '
        Me.lblListaNaves.AutoSize = True
        Me.lblListaNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblListaNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaNaves.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblListaNaves.Location = New System.Drawing.Point(22, 20)
        Me.lblListaNaves.Name = "lblListaNaves"
        Me.lblListaNaves.Size = New System.Drawing.Size(413, 20)
        Me.lblListaNaves.TabIndex = 21
        Me.lblListaNaves.Text = "Capacidades por célula de producción por semana"
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Programacion.Vista.My.Resources.Resources.excel_32
        Me.btnExportar.Location = New System.Drawing.Point(217, 8)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(32, 32)
        Me.btnExportar.TabIndex = 24
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblExportarExcel
        '
        Me.lblExportarExcel.AutoSize = True
        Me.lblExportarExcel.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblExportarExcel.Location = New System.Drawing.Point(210, 40)
        Me.lblExportarExcel.Name = "lblExportarExcel"
        Me.lblExportarExcel.Size = New System.Drawing.Size(46, 13)
        Me.lblExportarExcel.TabIndex = 25
        Me.lblExportarExcel.Text = "Exportar"
        Me.lblExportarExcel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlExtado
        '
        Me.pnlExtado.BackColor = System.Drawing.Color.White
        Me.pnlExtado.Controls.Add(Me.lblSemanaActual)
        Me.pnlExtado.Controls.Add(Me.lblContSeleccionados)
        Me.pnlExtado.Controls.Add(Me.lblEtiquetaSeleccionados)
        Me.pnlExtado.Controls.Add(Me.lblUltimaActualizacion)
        Me.pnlExtado.Controls.Add(Me.Panel1)
        Me.pnlExtado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlExtado.Location = New System.Drawing.Point(0, 549)
        Me.pnlExtado.Name = "pnlExtado"
        Me.pnlExtado.Size = New System.Drawing.Size(1194, 60)
        Me.pnlExtado.TabIndex = 25
        '
        'lblSemanaActual
        '
        Me.lblSemanaActual.AutoSize = True
        Me.lblSemanaActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanaActual.Location = New System.Drawing.Point(668, 15)
        Me.lblSemanaActual.Name = "lblSemanaActual"
        Me.lblSemanaActual.Size = New System.Drawing.Size(88, 13)
        Me.lblSemanaActual.TabIndex = 48
        Me.lblSemanaActual.Text = "Semana Actual 1"
        '
        'lblContSeleccionados
        '
        Me.lblContSeleccionados.AutoSize = True
        Me.lblContSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContSeleccionados.ForeColor = System.Drawing.Color.Black
        Me.lblContSeleccionados.Location = New System.Drawing.Point(25, 33)
        Me.lblContSeleccionados.MaximumSize = New System.Drawing.Size(100, 25)
        Me.lblContSeleccionados.MinimumSize = New System.Drawing.Size(100, 25)
        Me.lblContSeleccionados.Name = "lblContSeleccionados"
        Me.lblContSeleccionados.Size = New System.Drawing.Size(100, 25)
        Me.lblContSeleccionados.TabIndex = 46
        Me.lblContSeleccionados.Text = "0"
        Me.lblContSeleccionados.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEtiquetaSeleccionados
        '
        Me.lblEtiquetaSeleccionados.AutoSize = True
        Me.lblEtiquetaSeleccionados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtiquetaSeleccionados.ForeColor = System.Drawing.Color.Black
        Me.lblEtiquetaSeleccionados.Location = New System.Drawing.Point(20, 3)
        Me.lblEtiquetaSeleccionados.Name = "lblEtiquetaSeleccionados"
        Me.lblEtiquetaSeleccionados.Size = New System.Drawing.Size(112, 16)
        Me.lblEtiquetaSeleccionados.TabIndex = 47
        Me.lblEtiquetaSeleccionados.Text = "Seleccionados"
        Me.lblEtiquetaSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUltimaActualizacion
        '
        Me.lblUltimaActualizacion.AutoSize = True
        Me.lblUltimaActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaActualizacion.Location = New System.Drawing.Point(668, 35)
        Me.lblUltimaActualizacion.Name = "lblUltimaActualizacion"
        Me.lblUltimaActualizacion.Size = New System.Drawing.Size(49, 13)
        Me.lblUltimaActualizacion.TabIndex = 45
        Me.lblUltimaActualizacion.Text = "00:00:00"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMostrar)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(783, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(411, 60)
        Me.Panel1.TabIndex = 0
        '
        'btnMostrar
        '
        Me.btnMostrar.Image = Global.Programacion.Vista.My.Resources.Resources.buscar_32
        Me.btnMostrar.Location = New System.Drawing.Point(292, 8)
        Me.btnMostrar.Name = "btnMostrar"
        Me.btnMostrar.Size = New System.Drawing.Size(32, 32)
        Me.btnMostrar.TabIndex = 24
        Me.btnMostrar.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label18.Location = New System.Drawing.Point(287, 41)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Mostrar"
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(355, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 5
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.Programacion.Vista.My.Resources.Resources.salir_32
        Me.btnSalir.Location = New System.Drawing.Point(356, 8)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(32, 32)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'grpNaves
        '
        Me.grpNaves.Controls.Add(Me.btnAbajo)
        Me.grpNaves.Controls.Add(Me.btnArriba)
        Me.grpNaves.Controls.Add(Me.numAnioFin)
        Me.grpNaves.Controls.Add(Me.Label15)
        Me.grpNaves.Controls.Add(Me.chkNOasignado)
        Me.grpNaves.Controls.Add(Me.chkAsignado)
        Me.grpNaves.Controls.Add(Me.Label14)
        Me.grpNaves.Controls.Add(Me.chkInactivo)
        Me.grpNaves.Controls.Add(Me.chkActivo)
        Me.grpNaves.Controls.Add(Me.Label13)
        Me.grpNaves.Controls.Add(Me.Label1)
        Me.grpNaves.Controls.Add(Me.Label9)
        Me.grpNaves.Controls.Add(Me.lblNave)
        Me.grpNaves.Controls.Add(Me.cmbNaves)
        Me.grpNaves.Controls.Add(Me.numSemanaFinal)
        Me.grpNaves.Controls.Add(Me.numSemanaInicio)
        Me.grpNaves.Controls.Add(Me.numAnioInicio)
        Me.grpNaves.Controls.Add(Me.Label6)
        Me.grpNaves.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpNaves.Location = New System.Drawing.Point(0, 68)
        Me.grpNaves.Name = "grpNaves"
        Me.grpNaves.Size = New System.Drawing.Size(1194, 86)
        Me.grpNaves.TabIndex = 26
        Me.grpNaves.TabStop = False
        Me.grpNaves.Text = "Filtros"
        '
        'btnAbajo
        '
        Me.btnAbajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(1165, 15)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 54
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnArriba
        '
        Me.btnArriba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(1134, 15)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 53
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'numAnioFin
        '
        Me.numAnioFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAnioFin.Location = New System.Drawing.Point(493, 48)
        Me.numAnioFin.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnioFin.Name = "numAnioFin"
        Me.numAnioFin.Size = New System.Drawing.Size(48, 20)
        Me.numAnioFin.TabIndex = 52
        Me.numAnioFin.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(472, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(15, 13)
        Me.Label15.TabIndex = 51
        Me.Label15.Text = "al"
        '
        'chkNOasignado
        '
        Me.chkNOasignado.AutoSize = True
        Me.chkNOasignado.Location = New System.Drawing.Point(1095, 50)
        Me.chkNOasignado.Name = "chkNOasignado"
        Me.chkNOasignado.Size = New System.Drawing.Size(40, 17)
        Me.chkNOasignado.TabIndex = 50
        Me.chkNOasignado.Text = "No"
        Me.chkNOasignado.UseVisualStyleBackColor = True
        '
        'chkAsignado
        '
        Me.chkAsignado.AutoSize = True
        Me.chkAsignado.Checked = True
        Me.chkAsignado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAsignado.Location = New System.Drawing.Point(1054, 50)
        Me.chkAsignado.Name = "chkAsignado"
        Me.chkAsignado.Size = New System.Drawing.Size(35, 17)
        Me.chkAsignado.TabIndex = 49
        Me.chkAsignado.Text = "Si"
        Me.chkAsignado.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(992, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 13)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "Asignados"
        '
        'chkInactivo
        '
        Me.chkInactivo.AutoSize = True
        Me.chkInactivo.Location = New System.Drawing.Point(909, 50)
        Me.chkInactivo.Name = "chkInactivo"
        Me.chkInactivo.Size = New System.Drawing.Size(40, 17)
        Me.chkInactivo.TabIndex = 47
        Me.chkInactivo.Text = "No"
        Me.chkInactivo.UseVisualStyleBackColor = True
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Checked = True
        Me.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActivo.Location = New System.Drawing.Point(868, 50)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(35, 17)
        Me.chkActivo.TabIndex = 46
        Me.chkActivo.Text = "Si"
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(819, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 45
        Me.Label13.Text = "Activos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(708, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "al"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(585, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 13)
        Me.Label9.TabIndex = 43
        Me.Label9.Text = "Semana del"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.Location = New System.Drawing.Point(41, 52)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 23
        Me.lblNave.Text = "Nave"
        '
        'cmbNaves
        '
        Me.cmbNaves.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNaves.FormattingEnabled = True
        Me.cmbNaves.Location = New System.Drawing.Point(83, 48)
        Me.cmbNaves.Name = "cmbNaves"
        Me.cmbNaves.Size = New System.Drawing.Size(218, 21)
        Me.cmbNaves.TabIndex = 24
        '
        'numSemanaFinal
        '
        Me.numSemanaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSemanaFinal.Location = New System.Drawing.Point(729, 48)
        Me.numSemanaFinal.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemanaFinal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemanaFinal.Name = "numSemanaFinal"
        Me.numSemanaFinal.Size = New System.Drawing.Size(48, 20)
        Me.numSemanaFinal.TabIndex = 40
        Me.numSemanaFinal.Value = New Decimal(New Integer() {52, 0, 0, 0})
        '
        'numSemanaInicio
        '
        Me.numSemanaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numSemanaInicio.Location = New System.Drawing.Point(654, 48)
        Me.numSemanaInicio.Maximum = New Decimal(New Integer() {52, 0, 0, 0})
        Me.numSemanaInicio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numSemanaInicio.Name = "numSemanaInicio"
        Me.numSemanaInicio.Size = New System.Drawing.Size(48, 20)
        Me.numSemanaInicio.TabIndex = 38
        Me.numSemanaInicio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numAnioInicio
        '
        Me.numAnioInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAnioInicio.Location = New System.Drawing.Point(417, 48)
        Me.numAnioInicio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.numAnioInicio.Minimum = New Decimal(New Integer() {2014, 0, 0, 0})
        Me.numAnioInicio.Name = "numAnioInicio"
        Me.numAnioInicio.Size = New System.Drawing.Size(48, 20)
        Me.numAnioInicio.TabIndex = 36
        Me.numAnioInicio.Value = New Decimal(New Integer() {2015, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(368, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Año del"
        '
        'tbtProducto
        '
        Me.tbtProducto.Controls.Add(Me.grdProductos)
        Me.tbtProducto.Controls.Add(Me.Panel5)
        Me.tbtProducto.Location = New System.Drawing.Point(4, 22)
        Me.tbtProducto.Name = "tbtProducto"
        Me.tbtProducto.Size = New System.Drawing.Size(1186, 369)
        Me.tbtProducto.TabIndex = 4
        Me.tbtProducto.Text = "Producto"
        Me.tbtProducto.UseVisualStyleBackColor = True
        '
        'grdProductos
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductos.DisplayLayout.Appearance = Appearance1
        Me.grdProductos.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdProductos.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductos.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdProductos.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdProductos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdProductos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdProductos.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdProductos.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdProductos.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdProductos.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdProductos.Location = New System.Drawing.Point(0, 30)
        Me.grdProductos.Name = "grdProductos"
        Me.grdProductos.Size = New System.Drawing.Size(1186, 339)
        Me.grdProductos.TabIndex = 28
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel5.Controls.Add(Me.chkSeleccionarProductos)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1186, 30)
        Me.Panel5.TabIndex = 3
        '
        'chkSeleccionarProductos
        '
        Me.chkSeleccionarProductos.AutoSize = True
        Me.chkSeleccionarProductos.Location = New System.Drawing.Point(4, 7)
        Me.chkSeleccionarProductos.Name = "chkSeleccionarProductos"
        Me.chkSeleccionarProductos.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarProductos.TabIndex = 42
        Me.chkSeleccionarProductos.Text = "Seleccionar todo"
        Me.chkSeleccionarProductos.UseVisualStyleBackColor = True
        '
        'tbtHorma
        '
        Me.tbtHorma.Controls.Add(Me.grdCapacidadHorma)
        Me.tbtHorma.Controls.Add(Me.Panel6)
        Me.tbtHorma.Location = New System.Drawing.Point(4, 22)
        Me.tbtHorma.Name = "tbtHorma"
        Me.tbtHorma.Size = New System.Drawing.Size(1186, 369)
        Me.tbtHorma.TabIndex = 5
        Me.tbtHorma.Text = "Horma"
        Me.tbtHorma.UseVisualStyleBackColor = True
        '
        'grdCapacidadHorma
        '
        Appearance3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCapacidadHorma.DisplayLayout.Appearance = Appearance3
        Me.grdCapacidadHorma.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdCapacidadHorma.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCapacidadHorma.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdCapacidadHorma.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdCapacidadHorma.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdCapacidadHorma.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdCapacidadHorma.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdCapacidadHorma.DisplayLayout.Override.RowAlternateAppearance = Appearance4
        Me.grdCapacidadHorma.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdCapacidadHorma.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdCapacidadHorma.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCapacidadHorma.Location = New System.Drawing.Point(0, 30)
        Me.grdCapacidadHorma.Name = "grdCapacidadHorma"
        Me.grdCapacidadHorma.Size = New System.Drawing.Size(1186, 339)
        Me.grdCapacidadHorma.TabIndex = 28
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel6.Controls.Add(Me.chkSeleccionarHorma)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1186, 30)
        Me.Panel6.TabIndex = 3
        '
        'chkSeleccionarHorma
        '
        Me.chkSeleccionarHorma.AutoSize = True
        Me.chkSeleccionarHorma.Location = New System.Drawing.Point(4, 7)
        Me.chkSeleccionarHorma.Name = "chkSeleccionarHorma"
        Me.chkSeleccionarHorma.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarHorma.TabIndex = 43
        Me.chkSeleccionarHorma.Text = "Seleccionar todo"
        Me.chkSeleccionarHorma.UseVisualStyleBackColor = True
        '
        'tbtGrupo
        '
        Me.tbtGrupo.Controls.Add(Me.grdGrupoCapacidad)
        Me.tbtGrupo.Controls.Add(Me.Panel3)
        Me.tbtGrupo.Location = New System.Drawing.Point(4, 22)
        Me.tbtGrupo.Name = "tbtGrupo"
        Me.tbtGrupo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtGrupo.Size = New System.Drawing.Size(1186, 369)
        Me.tbtGrupo.TabIndex = 2
        Me.tbtGrupo.Text = "Grupo"
        Me.tbtGrupo.UseVisualStyleBackColor = True
        '
        'grdGrupoCapacidad
        '
        Appearance5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdGrupoCapacidad.DisplayLayout.Appearance = Appearance5
        Me.grdGrupoCapacidad.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdGrupoCapacidad.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdGrupoCapacidad.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdGrupoCapacidad.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdGrupoCapacidad.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdGrupoCapacidad.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdGrupoCapacidad.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdGrupoCapacidad.DisplayLayout.Override.RowAlternateAppearance = Appearance6
        Me.grdGrupoCapacidad.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdGrupoCapacidad.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdGrupoCapacidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdGrupoCapacidad.Location = New System.Drawing.Point(3, 33)
        Me.grdGrupoCapacidad.Name = "grdGrupoCapacidad"
        Me.grdGrupoCapacidad.Size = New System.Drawing.Size(1180, 333)
        Me.grdGrupoCapacidad.TabIndex = 28
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel3.Controls.Add(Me.chkSeleccionarGrupo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1180, 30)
        Me.Panel3.TabIndex = 1
        '
        'chkSeleccionarGrupo
        '
        Me.chkSeleccionarGrupo.AutoSize = True
        Me.chkSeleccionarGrupo.Location = New System.Drawing.Point(4, 7)
        Me.chkSeleccionarGrupo.Name = "chkSeleccionarGrupo"
        Me.chkSeleccionarGrupo.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarGrupo.TabIndex = 41
        Me.chkSeleccionarGrupo.Text = "Seleccionar todo"
        Me.chkSeleccionarGrupo.UseVisualStyleBackColor = True
        '
        'tbtCelulas
        '
        Me.tbtCelulas.Controls.Add(Me.grdLineasSemana)
        Me.tbtCelulas.Controls.Add(Me.Panel2)
        Me.tbtCelulas.Location = New System.Drawing.Point(4, 22)
        Me.tbtCelulas.Name = "tbtCelulas"
        Me.tbtCelulas.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtCelulas.Size = New System.Drawing.Size(1186, 369)
        Me.tbtCelulas.TabIndex = 1
        Me.tbtCelulas.Text = "Células (Global)"
        Me.tbtCelulas.UseVisualStyleBackColor = True
        '
        'grdLineasSemana
        '
        Appearance7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLineasSemana.DisplayLayout.Appearance = Appearance7
        Me.grdLineasSemana.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.WithinBand
        Me.grdLineasSemana.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLineasSemana.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdLineasSemana.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdLineasSemana.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdLineasSemana.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdLineasSemana.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdLineasSemana.DisplayLayout.Override.RowAlternateAppearance = Appearance8
        Me.grdLineasSemana.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdLineasSemana.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended
        Me.grdLineasSemana.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdLineasSemana.Location = New System.Drawing.Point(3, 33)
        Me.grdLineasSemana.Name = "grdLineasSemana"
        Me.grdLineasSemana.Size = New System.Drawing.Size(1180, 333)
        Me.grdLineasSemana.TabIndex = 27
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel2.Controls.Add(Me.chkSeleccionarCelGlobal)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1180, 30)
        Me.Panel2.TabIndex = 0
        '
        'chkSeleccionarCelGlobal
        '
        Me.chkSeleccionarCelGlobal.AutoSize = True
        Me.chkSeleccionarCelGlobal.Location = New System.Drawing.Point(4, 7)
        Me.chkSeleccionarCelGlobal.Name = "chkSeleccionarCelGlobal"
        Me.chkSeleccionarCelGlobal.Size = New System.Drawing.Size(106, 17)
        Me.chkSeleccionarCelGlobal.TabIndex = 40
        Me.chkSeleccionarCelGlobal.Text = "Seleccionar todo"
        Me.chkSeleccionarCelGlobal.UseVisualStyleBackColor = True
        '
        'tbtCapacidades
        '
        Me.tbtCapacidades.Controls.Add(Me.tbtCelulas)
        Me.tbtCapacidades.Controls.Add(Me.tbtGrupo)
        Me.tbtCapacidades.Controls.Add(Me.tbtHorma)
        Me.tbtCapacidades.Controls.Add(Me.tbtProducto)
        Me.tbtCapacidades.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbtCapacidades.Location = New System.Drawing.Point(0, 154)
        Me.tbtCapacidades.Name = "tbtCapacidades"
        Me.tbtCapacidades.SelectedIndex = 0
        Me.tbtCapacidades.Size = New System.Drawing.Size(1194, 395)
        Me.tbtCapacidades.TabIndex = 27
        '
        'frmPlantaCapacidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1194, 609)
        Me.Controls.Add(Me.tbtCapacidades)
        Me.Controls.Add(Me.grpNaves)
        Me.Controls.Add(Me.pnlExtado)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "frmPlantaCapacidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capacidades por célula de producción por semana"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlEncabezado.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.pnlBotones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExtado.ResumeLayout(False)
        Me.pnlExtado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.grpNaves.ResumeLayout(False)
        Me.grpNaves.PerformLayout()
        CType(Me.numAnioFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemanaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSemanaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAnioInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtProducto.ResumeLayout(False)
        CType(Me.grdProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.tbtHorma.ResumeLayout(False)
        CType(Me.grdCapacidadHorma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.tbtGrupo.ResumeLayout(False)
        CType(Me.grdGrupoCapacidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tbtCelulas.ResumeLayout(False)
        CType(Me.grdLineasSemana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.tbtCapacidades.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents btnEliminarAsignacion As System.Windows.Forms.Button
    Friend WithEvents lblEliminarAsignacion As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCopiarSemanas As System.Windows.Forms.Button
    Friend WithEvents lblCopiarSemana As System.Windows.Forms.Label
    Friend WithEvents btnActualizarCelulas As System.Windows.Forms.Button
    Friend WithEvents lblctualizarCelulas As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
    Friend WithEvents lblListaNaves As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents lblExportarExcel As System.Windows.Forms.Label
    Friend WithEvents pnlExtado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents grpNaves As System.Windows.Forms.GroupBox
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents chkNOasignado As System.Windows.Forms.CheckBox
    Friend WithEvents chkAsignado As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents chkInactivo As System.Windows.Forms.CheckBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents cmbNaves As System.Windows.Forms.ComboBox
    Friend WithEvents numSemanaFinal As System.Windows.Forms.NumericUpDown
    Friend WithEvents numSemanaInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAnioInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbtProducto As System.Windows.Forms.TabPage
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarProductos As System.Windows.Forms.CheckBox
    Friend WithEvents tbtHorma As System.Windows.Forms.TabPage
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents tbtGrupo As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tbtCelulas As System.Windows.Forms.TabPage
    Friend WithEvents grdLineasSemana As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkSeleccionarCelGlobal As System.Windows.Forms.CheckBox
    Friend WithEvents tbtCapacidades As System.Windows.Forms.TabControl
    Friend WithEvents grdProductos As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents grdCapacidadHorma As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkSeleccionarHorma As System.Windows.Forms.CheckBox
    Friend WithEvents grdGrupoCapacidad As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents chkSeleccionarGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents numAnioFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents exportExcelDetalle As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents lblUltimaActualizacion As System.Windows.Forms.Label
    Friend WithEvents lblContSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblEtiquetaSeleccionados As System.Windows.Forms.Label
    Friend WithEvents lblSemanaActual As System.Windows.Forms.Label
End Class
