<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarIncapacidadesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarIncapacidadesForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.BtnAlta = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblReplicado = New System.Windows.Forms.Label()
        Me.lblIncapacidadID = New System.Windows.Forms.Label()
        Me.cmbTipoMaternidad = New System.Windows.Forms.ComboBox()
        Me.lblTipoMaternidad = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.btnGuardarEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblGuardarEditar = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblAgregar = New System.Windows.Forms.Label()
        Me.grbParametros = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbListaArchivos = New System.Windows.Forms.ListBox()
        Me.LBIncapacidades = New System.Windows.Forms.ListBox()
        Me.pnlIncapacidad = New System.Windows.Forms.Panel()
        Me.txtFolio = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rdnFormatost2 = New System.Windows.Forms.RadioButton()
        Me.rdnFormatost7 = New System.Windows.Forms.RadioButton()
        Me.rdnActaIncapacidad = New System.Windows.Forms.RadioButton()
        Me.lblNombreArchivo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkRiesgoTrabajo = New System.Windows.Forms.CheckBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.cmbSecuelaOConsecuencia = New System.Windows.Forms.ComboBox()
        Me.lblSecuelaOConsecuencia = New System.Windows.Forms.Label()
        Me.cmbControlIncapacidad = New System.Windows.Forms.ComboBox()
        Me.lblControlDeIncapacidad = New System.Windows.Forms.Label()
        Me.cmbTipoDeRiesgo = New System.Windows.Forms.ComboBox()
        Me.lblTipoDeRiesgo = New System.Windows.Forms.Label()
        Me.cmbIncapacidadAnterior = New System.Windows.Forms.ComboBox()
        Me.cmbRamoDelSeguro = New System.Windows.Forms.ComboBox()
        Me.lblRamoDelSeguro = New System.Windows.Forms.Label()
        Me.NupDiasAutorizados = New System.Windows.Forms.NumericUpDown()
        Me.lblDiasAutorizados = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFechafinal = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.txtFolio1 = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.lblColaborador = New System.Windows.Forms.Label()
        Me.lblColaborador2 = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblEdad2 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblPuesto = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.lblNave2 = New System.Windows.Forms.Label()
        Me.lblDepartamento2 = New System.Windows.Forms.Label()
        Me.lblPuesto2 = New System.Windows.Forms.Label()
        Me.pbColaborador = New System.Windows.Forms.PictureBox()
        Me.ofdRutaArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlIncapacidad.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.NupDiasAutorizados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        CType(Me.pbColaborador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblBuscar)
        Me.pnlHeader.Controls.Add(Me.lblLimpiar)
        Me.pnlHeader.Controls.Add(Me.lblAlta)
        Me.pnlHeader.Controls.Add(Me.BtnAlta)
        Me.pnlHeader.Controls.Add(Me.btnLimpiar)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Controls.Add(Me.btnBuscar)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(588, 59)
        Me.pnlHeader.TabIndex = 13
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(8, 38)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(40, 13)
        Me.lblBuscar.TabIndex = 51
        Me.lblBuscar.Text = "Buscar"
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(67, 38)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 50
        Me.lblLimpiar.Text = "Limpiar"
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAlta.Location = New System.Drawing.Point(177, 38)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(25, 13)
        Me.lblAlta.TabIndex = 52
        Me.lblAlta.Text = "Alta"
        Me.lblAlta.Visible = False
        '
        'BtnAlta
        '
        Me.BtnAlta.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.BtnAlta.Location = New System.Drawing.Point(173, 3)
        Me.BtnAlta.Name = "BtnAlta"
        Me.BtnAlta.Size = New System.Drawing.Size(32, 32)
        Me.BtnAlta.TabIndex = 51
        Me.BtnAlta.UseVisualStyleBackColor = True
        Me.BtnAlta.Visible = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiar.Location = New System.Drawing.Point(70, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiar.TabIndex = 49
        Me.btnLimpiar.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.imgLogo)
        Me.pnlTitulo.Controls.Add(Me.lblReplicado)
        Me.pnlTitulo.Controls.Add(Me.lblIncapacidadID)
        Me.pnlTitulo.Controls.Add(Me.cmbTipoMaternidad)
        Me.pnlTitulo.Controls.Add(Me.lblTipoMaternidad)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(211, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(377, 59)
        Me.pnlTitulo.TabIndex = 5
        '
        'lblReplicado
        '
        Me.lblReplicado.AutoSize = True
        Me.lblReplicado.Location = New System.Drawing.Point(166, 2)
        Me.lblReplicado.Name = "lblReplicado"
        Me.lblReplicado.Size = New System.Drawing.Size(55, 13)
        Me.lblReplicado.TabIndex = 41
        Me.lblReplicado.Text = "Replicado"
        Me.lblReplicado.Visible = False
        '
        'lblIncapacidadID
        '
        Me.lblIncapacidadID.AutoSize = True
        Me.lblIncapacidadID.Location = New System.Drawing.Point(224, 1)
        Me.lblIncapacidadID.Name = "lblIncapacidadID"
        Me.lblIncapacidadID.Size = New System.Drawing.Size(80, 13)
        Me.lblIncapacidadID.TabIndex = 40
        Me.lblIncapacidadID.Text = "ID Incapacidad"
        Me.lblIncapacidadID.Visible = False
        '
        'cmbTipoMaternidad
        '
        Me.cmbTipoMaternidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMaternidad.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoMaternidad.FormattingEnabled = True
        Me.cmbTipoMaternidad.Location = New System.Drawing.Point(16, 32)
        Me.cmbTipoMaternidad.Name = "cmbTipoMaternidad"
        Me.cmbTipoMaternidad.Size = New System.Drawing.Size(104, 21)
        Me.cmbTipoMaternidad.TabIndex = 39
        Me.cmbTipoMaternidad.Visible = False
        '
        'lblTipoMaternidad
        '
        Me.lblTipoMaternidad.AutoSize = True
        Me.lblTipoMaternidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMaternidad.ForeColor = System.Drawing.Color.Black
        Me.lblTipoMaternidad.Location = New System.Drawing.Point(13, 10)
        Me.lblTipoMaternidad.Name = "lblTipoMaternidad"
        Me.lblTipoMaternidad.Size = New System.Drawing.Size(107, 16)
        Me.lblTipoMaternidad.TabIndex = 38
        Me.lblTipoMaternidad.Text = "Tipo maternidad"
        Me.lblTipoMaternidad.Visible = False
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(146, 17)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(160, 20)
        Me.lblTitulo.TabIndex = 2
        Me.lblTitulo.Text = "Editar Incapacidad"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnBuscar.Location = New System.Drawing.Point(11, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(32, 32)
        Me.btnBuscar.TabIndex = 48
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlAcciones)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 540)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(588, 60)
        Me.pnlEstado.TabIndex = 16
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblEliminar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardarEditar)
        Me.pnlAcciones.Controls.Add(Me.btnEliminar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardarEditar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(377, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(211, 60)
        Me.pnlAcciones.TabIndex = 18
        '
        'lblEliminar
        '
        Me.lblEliminar.AutoSize = True
        Me.lblEliminar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEliminar.Location = New System.Drawing.Point(120, 40)
        Me.lblEliminar.Name = "lblEliminar"
        Me.lblEliminar.Size = New System.Drawing.Size(43, 13)
        Me.lblEliminar.TabIndex = 54
        Me.lblEliminar.Text = "Eliminar"
        '
        'btnGuardarEditar
        '
        Me.btnGuardarEditar.Image = Global.Contabilidad.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarEditar.Location = New System.Drawing.Point(78, 7)
        Me.btnGuardarEditar.Name = "btnGuardarEditar"
        Me.btnGuardarEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarEditar.TabIndex = 33
        Me.btnGuardarEditar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Contabilidad.Vista.My.Resources.Resources.cancelar_32
        Me.btnEliminar.Location = New System.Drawing.Point(125, 7)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(32, 32)
        Me.btnEliminar.TabIndex = 53
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblGuardarEditar
        '
        Me.lblGuardarEditar.AutoSize = True
        Me.lblGuardarEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarEditar.Location = New System.Drawing.Point(72, 40)
        Me.lblGuardarEditar.Name = "lblGuardarEditar"
        Me.lblGuardarEditar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarEditar.TabIndex = 32
        Me.lblGuardarEditar.Text = "Guardar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(166, 7)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 30
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(165, 41)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 31
        Me.lblCancelar.Text = "Cerrar"
        '
        'lblAgregar
        '
        Me.lblAgregar.AutoSize = True
        Me.lblAgregar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAgregar.Location = New System.Drawing.Point(375, 60)
        Me.lblAgregar.Name = "lblAgregar"
        Me.lblAgregar.Size = New System.Drawing.Size(44, 13)
        Me.lblAgregar.TabIndex = 32
        Me.lblAgregar.Text = "Agregar"
        '
        'grbParametros
        '
        Me.grbParametros.Controls.Add(Me.Panel3)
        Me.grbParametros.Controls.Add(Me.LBIncapacidades)
        Me.grbParametros.Controls.Add(Me.pnlIncapacidad)
        Me.grbParametros.Controls.Add(Me.pnlDatos)
        Me.grbParametros.Controls.Add(Me.pbColaborador)
        Me.grbParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbParametros.ForeColor = System.Drawing.Color.Black
        Me.grbParametros.Location = New System.Drawing.Point(0, 59)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(588, 481)
        Me.grbParametros.TabIndex = 17
        Me.grbParametros.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lbListaArchivos)
        Me.Panel3.Location = New System.Drawing.Point(6, 326)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(137, 155)
        Me.Panel3.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Lista de archivos"
        '
        'lbListaArchivos
        '
        Me.lbListaArchivos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbListaArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbListaArchivos.ForeColor = System.Drawing.Color.Black
        Me.lbListaArchivos.FormattingEnabled = True
        Me.lbListaArchivos.ItemHeight = 12
        Me.lbListaArchivos.Location = New System.Drawing.Point(4, 29)
        Me.lbListaArchivos.Name = "lbListaArchivos"
        Me.lbListaArchivos.Size = New System.Drawing.Size(126, 122)
        Me.lbListaArchivos.TabIndex = 69
        '
        'LBIncapacidades
        '
        Me.LBIncapacidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBIncapacidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBIncapacidades.ForeColor = System.Drawing.Color.Black
        Me.LBIncapacidades.FormattingEnabled = True
        Me.LBIncapacidades.ItemHeight = 12
        Me.LBIncapacidades.Location = New System.Drawing.Point(10, 182)
        Me.LBIncapacidades.Name = "LBIncapacidades"
        Me.LBIncapacidades.Size = New System.Drawing.Size(126, 98)
        Me.LBIncapacidades.TabIndex = 69
        '
        'pnlIncapacidad
        '
        Me.pnlIncapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIncapacidad.Controls.Add(Me.txtFolio)
        Me.pnlIncapacidad.Controls.Add(Me.Panel1)
        Me.pnlIncapacidad.Controls.Add(Me.chkRiesgoTrabajo)
        Me.pnlIncapacidad.Controls.Add(Me.txtDescripcion)
        Me.pnlIncapacidad.Controls.Add(Me.lblDescripcion)
        Me.pnlIncapacidad.Controls.Add(Me.cmbSecuelaOConsecuencia)
        Me.pnlIncapacidad.Controls.Add(Me.lblSecuelaOConsecuencia)
        Me.pnlIncapacidad.Controls.Add(Me.cmbControlIncapacidad)
        Me.pnlIncapacidad.Controls.Add(Me.lblControlDeIncapacidad)
        Me.pnlIncapacidad.Controls.Add(Me.cmbTipoDeRiesgo)
        Me.pnlIncapacidad.Controls.Add(Me.lblTipoDeRiesgo)
        Me.pnlIncapacidad.Controls.Add(Me.cmbIncapacidadAnterior)
        Me.pnlIncapacidad.Controls.Add(Me.cmbRamoDelSeguro)
        Me.pnlIncapacidad.Controls.Add(Me.lblRamoDelSeguro)
        Me.pnlIncapacidad.Controls.Add(Me.NupDiasAutorizados)
        Me.pnlIncapacidad.Controls.Add(Me.lblDiasAutorizados)
        Me.pnlIncapacidad.Controls.Add(Me.dtpFechaFinal)
        Me.pnlIncapacidad.Controls.Add(Me.Label1)
        Me.pnlIncapacidad.Controls.Add(Me.lblFechafinal)
        Me.pnlIncapacidad.Controls.Add(Me.dtpFechaInicio)
        Me.pnlIncapacidad.Controls.Add(Me.lblFechaInicio)
        Me.pnlIncapacidad.Controls.Add(Me.txtFolio1)
        Me.pnlIncapacidad.Controls.Add(Me.lblFolio)
        Me.pnlIncapacidad.Location = New System.Drawing.Point(145, 137)
        Me.pnlIncapacidad.Name = "pnlIncapacidad"
        Me.pnlIncapacidad.Size = New System.Drawing.Size(431, 340)
        Me.pnlIncapacidad.TabIndex = 68
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(113, 3)
        Me.txtFolio.Mask = "LL000000"
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(100, 20)
        Me.txtFolio.TabIndex = 42
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExaminar)
        Me.Panel1.Controls.Add(Me.btnAgregar)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblNombreArchivo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblAgregar)
        Me.Panel1.Location = New System.Drawing.Point(3, 263)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(423, 78)
        Me.Panel1.TabIndex = 41
        '
        'btnExaminar
        '
        Me.btnExaminar.Image = Global.Contabilidad.Vista.My.Resources.Resources.colaboradorexpediente_32
        Me.btnExaminar.Location = New System.Drawing.Point(135, 29)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(32, 32)
        Me.btnExaminar.TabIndex = 36
        Me.btnExaminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Contabilidad.Vista.My.Resources.Resources.altas_32
        Me.btnAgregar.Location = New System.Drawing.Point(380, 29)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregar.TabIndex = 35
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdnFormatost2)
        Me.Panel2.Controls.Add(Me.rdnFormatost7)
        Me.Panel2.Controls.Add(Me.rdnActaIncapacidad)
        Me.Panel2.Location = New System.Drawing.Point(4, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(414, 24)
        Me.Panel2.TabIndex = 34
        '
        'rdnFormatost2
        '
        Me.rdnFormatost2.AutoSize = True
        Me.rdnFormatost2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdnFormatost2.Location = New System.Drawing.Point(301, 3)
        Me.rdnFormatost2.Name = "rdnFormatost2"
        Me.rdnFormatost2.Size = New System.Drawing.Size(104, 20)
        Me.rdnFormatost2.TabIndex = 1
        Me.rdnFormatost2.TabStop = True
        Me.rdnFormatost2.Text = "Formato ST2"
        Me.rdnFormatost2.UseVisualStyleBackColor = True
        '
        'rdnFormatost7
        '
        Me.rdnFormatost7.AutoSize = True
        Me.rdnFormatost7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdnFormatost7.Location = New System.Drawing.Point(170, 3)
        Me.rdnFormatost7.Name = "rdnFormatost7"
        Me.rdnFormatost7.Size = New System.Drawing.Size(104, 20)
        Me.rdnFormatost7.TabIndex = 1
        Me.rdnFormatost7.TabStop = True
        Me.rdnFormatost7.Text = "Formato ST7"
        Me.rdnFormatost7.UseVisualStyleBackColor = True
        '
        'rdnActaIncapacidad
        '
        Me.rdnActaIncapacidad.AutoSize = True
        Me.rdnActaIncapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdnActaIncapacidad.Location = New System.Drawing.Point(3, 3)
        Me.rdnActaIncapacidad.Name = "rdnActaIncapacidad"
        Me.rdnActaIncapacidad.Size = New System.Drawing.Size(150, 20)
        Me.rdnActaIncapacidad.TabIndex = 1
        Me.rdnActaIncapacidad.TabStop = True
        Me.rdnActaIncapacidad.Text = "Acta de Incapacidad"
        Me.rdnActaIncapacidad.UseVisualStyleBackColor = True
        '
        'lblNombreArchivo
        '
        Me.lblNombreArchivo.AutoSize = True
        Me.lblNombreArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreArchivo.Location = New System.Drawing.Point(172, 37)
        Me.lblNombreArchivo.Name = "lblNombreArchivo"
        Me.lblNombreArchivo.Size = New System.Drawing.Size(105, 16)
        Me.lblNombreArchivo.TabIndex = 1
        Me.lblNombreArchivo.Text = "Nombre Archivo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Seleccionar Archivo"
        '
        'chkRiesgoTrabajo
        '
        Me.chkRiesgoTrabajo.AutoSize = True
        Me.chkRiesgoTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRiesgoTrabajo.Location = New System.Drawing.Point(239, 3)
        Me.chkRiesgoTrabajo.Name = "chkRiesgoTrabajo"
        Me.chkRiesgoTrabajo.Size = New System.Drawing.Size(196, 20)
        Me.chkRiesgoTrabajo.TabIndex = 40
        Me.chkRiesgoTrabajo.Text = "Riesgo de trabajo aceptado"
        Me.chkRiesgoTrabajo.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.txtDescripcion.Location = New System.Drawing.Point(118, 211)
        Me.txtDescripcion.MaxLength = 40
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(296, 50)
        Me.txtDescripcion.TabIndex = 37
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.Black
        Me.lblDescripcion.Location = New System.Drawing.Point(3, 211)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(80, 16)
        Me.lblDescripcion.TabIndex = 36
        Me.lblDescripcion.Text = "Descripcion"
        '
        'cmbSecuelaOConsecuencia
        '
        Me.cmbSecuelaOConsecuencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSecuelaOConsecuencia.ForeColor = System.Drawing.Color.Black
        Me.cmbSecuelaOConsecuencia.FormattingEnabled = True
        Me.cmbSecuelaOConsecuencia.Location = New System.Drawing.Point(156, 184)
        Me.cmbSecuelaOConsecuencia.Name = "cmbSecuelaOConsecuencia"
        Me.cmbSecuelaOConsecuencia.Size = New System.Drawing.Size(258, 21)
        Me.cmbSecuelaOConsecuencia.TabIndex = 35
        '
        'lblSecuelaOConsecuencia
        '
        Me.lblSecuelaOConsecuencia.AutoSize = True
        Me.lblSecuelaOConsecuencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecuelaOConsecuencia.ForeColor = System.Drawing.Color.Black
        Me.lblSecuelaOConsecuencia.Location = New System.Drawing.Point(3, 184)
        Me.lblSecuelaOConsecuencia.Name = "lblSecuelaOConsecuencia"
        Me.lblSecuelaOConsecuencia.Size = New System.Drawing.Size(156, 16)
        Me.lblSecuelaOConsecuencia.TabIndex = 34
        Me.lblSecuelaOConsecuencia.Text = "Secuela o consecuencia"
        '
        'cmbControlIncapacidad
        '
        Me.cmbControlIncapacidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbControlIncapacidad.ForeColor = System.Drawing.Color.Black
        Me.cmbControlIncapacidad.FormattingEnabled = True
        Me.cmbControlIncapacidad.Location = New System.Drawing.Point(156, 158)
        Me.cmbControlIncapacidad.Name = "cmbControlIncapacidad"
        Me.cmbControlIncapacidad.Size = New System.Drawing.Size(258, 21)
        Me.cmbControlIncapacidad.TabIndex = 33
        '
        'lblControlDeIncapacidad
        '
        Me.lblControlDeIncapacidad.AutoSize = True
        Me.lblControlDeIncapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControlDeIncapacidad.ForeColor = System.Drawing.Color.Black
        Me.lblControlDeIncapacidad.Location = New System.Drawing.Point(3, 158)
        Me.lblControlDeIncapacidad.Name = "lblControlDeIncapacidad"
        Me.lblControlDeIncapacidad.Size = New System.Drawing.Size(147, 16)
        Me.lblControlDeIncapacidad.TabIndex = 32
        Me.lblControlDeIncapacidad.Text = "Control de incapacidad"
        '
        'cmbTipoDeRiesgo
        '
        Me.cmbTipoDeRiesgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDeRiesgo.ForeColor = System.Drawing.Color.Black
        Me.cmbTipoDeRiesgo.FormattingEnabled = True
        Me.cmbTipoDeRiesgo.Location = New System.Drawing.Point(121, 132)
        Me.cmbTipoDeRiesgo.Name = "cmbTipoDeRiesgo"
        Me.cmbTipoDeRiesgo.Size = New System.Drawing.Size(293, 21)
        Me.cmbTipoDeRiesgo.TabIndex = 31
        '
        'lblTipoDeRiesgo
        '
        Me.lblTipoDeRiesgo.AutoSize = True
        Me.lblTipoDeRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDeRiesgo.ForeColor = System.Drawing.Color.Black
        Me.lblTipoDeRiesgo.Location = New System.Drawing.Point(3, 132)
        Me.lblTipoDeRiesgo.Name = "lblTipoDeRiesgo"
        Me.lblTipoDeRiesgo.Size = New System.Drawing.Size(96, 16)
        Me.lblTipoDeRiesgo.TabIndex = 30
        Me.lblTipoDeRiesgo.Text = "Tipo de riesgo"
        '
        'cmbIncapacidadAnterior
        '
        Me.cmbIncapacidadAnterior.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cmbIncapacidadAnterior.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIncapacidadAnterior.ForeColor = System.Drawing.Color.Black
        Me.cmbIncapacidadAnterior.FormattingEnabled = True
        Me.cmbIncapacidadAnterior.Location = New System.Drawing.Point(156, 81)
        Me.cmbIncapacidadAnterior.Name = "cmbIncapacidadAnterior"
        Me.cmbIncapacidadAnterior.Size = New System.Drawing.Size(258, 21)
        Me.cmbIncapacidadAnterior.TabIndex = 29
        '
        'cmbRamoDelSeguro
        '
        Me.cmbRamoDelSeguro.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.cmbRamoDelSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRamoDelSeguro.ForeColor = System.Drawing.Color.Black
        Me.cmbRamoDelSeguro.FormattingEnabled = True
        Me.cmbRamoDelSeguro.Location = New System.Drawing.Point(121, 106)
        Me.cmbRamoDelSeguro.Name = "cmbRamoDelSeguro"
        Me.cmbRamoDelSeguro.Size = New System.Drawing.Size(293, 21)
        Me.cmbRamoDelSeguro.TabIndex = 29
        '
        'lblRamoDelSeguro
        '
        Me.lblRamoDelSeguro.AutoSize = True
        Me.lblRamoDelSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRamoDelSeguro.ForeColor = System.Drawing.Color.Black
        Me.lblRamoDelSeguro.Location = New System.Drawing.Point(3, 106)
        Me.lblRamoDelSeguro.Name = "lblRamoDelSeguro"
        Me.lblRamoDelSeguro.Size = New System.Drawing.Size(112, 16)
        Me.lblRamoDelSeguro.TabIndex = 28
        Me.lblRamoDelSeguro.Text = "Ramo del seguro"
        '
        'NupDiasAutorizados
        '
        Me.NupDiasAutorizados.Location = New System.Drawing.Point(117, 55)
        Me.NupDiasAutorizados.Name = "NupDiasAutorizados"
        Me.NupDiasAutorizados.Size = New System.Drawing.Size(96, 20)
        Me.NupDiasAutorizados.TabIndex = 27
        '
        'lblDiasAutorizados
        '
        Me.lblDiasAutorizados.AutoSize = True
        Me.lblDiasAutorizados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasAutorizados.ForeColor = System.Drawing.Color.Black
        Me.lblDiasAutorizados.Location = New System.Drawing.Point(2, 55)
        Me.lblDiasAutorizados.Name = "lblDiasAutorizados"
        Me.lblDiasAutorizados.Size = New System.Drawing.Size(109, 16)
        Me.lblDiasAutorizados.TabIndex = 26
        Me.lblDiasAutorizados.Text = "Dias autorizados"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Enabled = False
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(317, 29)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaFinal.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(2, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Incapacidad anterior"
        '
        'lblFechafinal
        '
        Me.lblFechafinal.AutoSize = True
        Me.lblFechafinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechafinal.ForeColor = System.Drawing.Color.Black
        Me.lblFechafinal.Location = New System.Drawing.Point(238, 31)
        Me.lblFechafinal.Name = "lblFechafinal"
        Me.lblFechafinal.Size = New System.Drawing.Size(73, 16)
        Me.lblFechafinal.TabIndex = 24
        Me.lblFechafinal.Text = "Fecha final"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(117, 29)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(96, 20)
        Me.dtpFechaInicio.TabIndex = 23
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFechaInicio.Location = New System.Drawing.Point(2, 29)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(80, 16)
        Me.lblFechaInicio.TabIndex = 22
        Me.lblFechaInicio.Text = "Fecha inicio"
        '
        'txtFolio1
        '
        Me.txtFolio1.Location = New System.Drawing.Point(235, 54)
        Me.txtFolio1.MaxLength = 8
        Me.txtFolio1.Name = "txtFolio1"
        Me.txtFolio1.Size = New System.Drawing.Size(106, 20)
        Me.txtFolio1.TabIndex = 21
        Me.txtFolio1.Visible = False
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.Black
        Me.lblFolio.Location = New System.Drawing.Point(2, 3)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(38, 16)
        Me.lblFolio.TabIndex = 20
        Me.lblFolio.Text = "Folio"
        '
        'pnlDatos
        '
        Me.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDatos.Controls.Add(Me.lblColaborador)
        Me.pnlDatos.Controls.Add(Me.lblColaborador2)
        Me.pnlDatos.Controls.Add(Me.lblEdad)
        Me.pnlDatos.Controls.Add(Me.lblEdad2)
        Me.pnlDatos.Controls.Add(Me.lblNave)
        Me.pnlDatos.Controls.Add(Me.lblPuesto)
        Me.pnlDatos.Controls.Add(Me.lblDepartamento)
        Me.pnlDatos.Controls.Add(Me.lblNave2)
        Me.pnlDatos.Controls.Add(Me.lblDepartamento2)
        Me.pnlDatos.Controls.Add(Me.lblPuesto2)
        Me.pnlDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDatos.Location = New System.Drawing.Point(145, 19)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(431, 112)
        Me.pnlDatos.TabIndex = 67
        '
        'lblColaborador
        '
        Me.lblColaborador.AutoSize = True
        Me.lblColaborador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador.ForeColor = System.Drawing.Color.Black
        Me.lblColaborador.Location = New System.Drawing.Point(2, 2)
        Me.lblColaborador.Name = "lblColaborador"
        Me.lblColaborador.Size = New System.Drawing.Size(84, 16)
        Me.lblColaborador.TabIndex = 19
        Me.lblColaborador.Text = "Colaborador"
        '
        'lblColaborador2
        '
        Me.lblColaborador2.AutoSize = True
        Me.lblColaborador2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColaborador2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblColaborador2.Location = New System.Drawing.Point(117, 2)
        Me.lblColaborador2.Name = "lblColaborador2"
        Me.lblColaborador2.Size = New System.Drawing.Size(84, 16)
        Me.lblColaborador2.TabIndex = 20
        Me.lblColaborador2.Text = "Colaborador"
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.ForeColor = System.Drawing.Color.Black
        Me.lblEdad.Location = New System.Drawing.Point(2, 23)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(41, 16)
        Me.lblEdad.TabIndex = 2
        Me.lblEdad.Text = "Edad"
        '
        'lblEdad2
        '
        Me.lblEdad2.AutoSize = True
        Me.lblEdad2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEdad2.Location = New System.Drawing.Point(117, 23)
        Me.lblEdad2.Name = "lblEdad2"
        Me.lblEdad2.Size = New System.Drawing.Size(41, 16)
        Me.lblEdad2.TabIndex = 11
        Me.lblEdad2.Text = "Edad"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(2, 44)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(41, 16)
        Me.lblNave.TabIndex = 7
        Me.lblNave.Text = "Nave"
        '
        'lblPuesto
        '
        Me.lblPuesto.AutoSize = True
        Me.lblPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto.ForeColor = System.Drawing.Color.Black
        Me.lblPuesto.Location = New System.Drawing.Point(3, 86)
        Me.lblPuesto.Name = "lblPuesto"
        Me.lblPuesto.Size = New System.Drawing.Size(50, 16)
        Me.lblPuesto.TabIndex = 6
        Me.lblPuesto.Text = "Puesto"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.ForeColor = System.Drawing.Color.Black
        Me.lblDepartamento.Location = New System.Drawing.Point(2, 65)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(94, 16)
        Me.lblDepartamento.TabIndex = 8
        Me.lblDepartamento.Text = "Departamento"
        '
        'lblNave2
        '
        Me.lblNave2.AutoSize = True
        Me.lblNave2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNave2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNave2.Location = New System.Drawing.Point(117, 44)
        Me.lblNave2.Name = "lblNave2"
        Me.lblNave2.Size = New System.Drawing.Size(41, 16)
        Me.lblNave2.TabIndex = 16
        Me.lblNave2.Text = "Nave"
        '
        'lblDepartamento2
        '
        Me.lblDepartamento2.AutoSize = True
        Me.lblDepartamento2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblDepartamento2.Location = New System.Drawing.Point(117, 65)
        Me.lblDepartamento2.Name = "lblDepartamento2"
        Me.lblDepartamento2.Size = New System.Drawing.Size(94, 16)
        Me.lblDepartamento2.TabIndex = 17
        Me.lblDepartamento2.Text = "Departamento"
        '
        'lblPuesto2
        '
        Me.lblPuesto2.AutoSize = True
        Me.lblPuesto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuesto2.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPuesto2.Location = New System.Drawing.Point(117, 86)
        Me.lblPuesto2.Name = "lblPuesto2"
        Me.lblPuesto2.Size = New System.Drawing.Size(50, 16)
        Me.lblPuesto2.TabIndex = 15
        Me.lblPuesto2.Text = "Puesto"
        '
        'pbColaborador
        '
        Me.pbColaborador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbColaborador.Image = CType(resources.GetObject("pbColaborador.Image"), System.Drawing.Image)
        Me.pbColaborador.Location = New System.Drawing.Point(10, 19)
        Me.pbColaborador.Name = "pbColaborador"
        Me.pbColaborador.Size = New System.Drawing.Size(126, 157)
        Me.pbColaborador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbColaborador.TabIndex = 56
        Me.pbColaborador.TabStop = False
        '
        'ofdRutaArchivo
        '
        Me.ofdRutaArchivo.FileName = "OpenFileDialog1"
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(305, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 59)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 42
        Me.imgLogo.TabStop = False
        '
        'EditarIncapacidadesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(588, 600)
        Me.Controls.Add(Me.grbParametros)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "EditarIncapacidadesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar incapacidad"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlIncapacidad.ResumeLayout(False)
        Me.pnlIncapacidad.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NupDiasAutorizados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        CType(Me.pbColaborador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents btnGuardarEditar As System.Windows.Forms.Button
    Friend WithEvents lblAgregar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents pnlIncapacidad As System.Windows.Forms.Panel
    Friend WithEvents cmbTipoMaternidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoMaternidad As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents cmbSecuelaOConsecuencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblSecuelaOConsecuencia As System.Windows.Forms.Label
    Friend WithEvents cmbControlIncapacidad As System.Windows.Forms.ComboBox
    Friend WithEvents lblControlDeIncapacidad As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDeRiesgo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoDeRiesgo As System.Windows.Forms.Label
    Friend WithEvents cmbRamoDelSeguro As System.Windows.Forms.ComboBox
    Friend WithEvents lblRamoDelSeguro As System.Windows.Forms.Label
    Friend WithEvents NupDiasAutorizados As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDiasAutorizados As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechafinal As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents txtFolio1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents lblColaborador As System.Windows.Forms.Label
    Friend WithEvents lblColaborador2 As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents lblEdad2 As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblPuesto As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblNave2 As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento2 As System.Windows.Forms.Label
    Friend WithEvents lblPuesto2 As System.Windows.Forms.Label
    Friend WithEvents pbColaborador As System.Windows.Forms.PictureBox
    Friend WithEvents LBIncapacidades As System.Windows.Forms.ListBox
    Friend WithEvents lblIncapacidadID As System.Windows.Forms.Label
    Friend WithEvents lblReplicado As System.Windows.Forms.Label
    Friend WithEvents lblEliminar As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents BtnAlta As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkRiesgoTrabajo As System.Windows.Forms.CheckBox
    Friend WithEvents cmbIncapacidadAnterior As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblGuardarEditar As System.Windows.Forms.Label
    Friend WithEvents lblNombreArchivo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ofdRutaArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbListaArchivos As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdnFormatost2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdnFormatost7 As System.Windows.Forms.RadioButton
    Friend WithEvents rdnActaIncapacidad As System.Windows.Forms.RadioButton
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents txtFolio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
