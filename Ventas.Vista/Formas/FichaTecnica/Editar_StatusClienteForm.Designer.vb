<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Editar_StatusClienteForm
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
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Editar_StatusClienteForm))
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlListaCliente = New System.Windows.Forms.Panel()
        Me.gboxHistorial = New System.Windows.Forms.GroupBox()
        Me.gridHistorial = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gboxModificacionStatusCliente = New System.Windows.Forms.GroupBox()
        Me.pnlClienteStatus = New System.Windows.Forms.Panel()
        Me.rbtnClienteStatusInactivo = New System.Windows.Forms.RadioButton()
        Me.rbtnClienteStatusActivo = New System.Windows.Forms.RadioButton()
        Me.cboxClienteEstatus = New System.Windows.Forms.ComboBox()
        Me.lblClienteEstatus = New System.Windows.Forms.Label()
        Me.cboxClienteCliente = New System.Windows.Forms.ComboBox()
        Me.txtClienteRazonSocial = New System.Windows.Forms.TextBox()
        Me.lblClienteRazonSocial = New System.Windows.Forms.Label()
        Me.lblClienteCliente = New System.Windows.Forms.Label()
        Me.txtValidacionComentarios = New System.Windows.Forms.TextBox()
        Me.lblVentasValidacionComentarios = New System.Windows.Forms.Label()
        Me.lblVentasValidacionFecha = New System.Windows.Forms.Label()
        Me.dateModificacionFecha = New System.Windows.Forms.DateTimePicker()
        Me.cboxValidador = New System.Windows.Forms.ComboBox()
        Me.lblVentasValidador = New System.Windows.Forms.Label()
        Me.pnlClienteBotones = New System.Windows.Forms.Panel()
        Me.btnCancelarCliente = New System.Windows.Forms.Button()
        Me.lblCancelarCliente = New System.Windows.Forms.Label()
        Me.btnGuardarCliente = New System.Windows.Forms.Button()
        Me.lblGuardarCliente = New System.Windows.Forms.Label()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlListaCliente.SuspendLayout()
        Me.gboxHistorial.SuspendLayout()
        CType(Me.gridHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gboxModificacionStatusCliente.SuspendLayout()
        Me.pnlClienteStatus.SuspendLayout()
        Me.pnlClienteBotones.SuspendLayout()
        Me.pnlCabecera.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.AliceBlue
        Me.pnlContenedor.Controls.Add(Me.pnlListaCliente)
        Me.pnlContenedor.Controls.Add(Me.pnlCabecera)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(704, 539)
        Me.pnlContenedor.TabIndex = 2
        '
        'pnlListaCliente
        '
        Me.pnlListaCliente.Controls.Add(Me.gboxHistorial)
        Me.pnlListaCliente.Controls.Add(Me.Panel1)
        Me.pnlListaCliente.Controls.Add(Me.pnlClienteBotones)
        Me.pnlListaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlListaCliente.Location = New System.Drawing.Point(0, 59)
        Me.pnlListaCliente.Name = "pnlListaCliente"
        Me.pnlListaCliente.Size = New System.Drawing.Size(704, 480)
        Me.pnlListaCliente.TabIndex = 3
        '
        'gboxHistorial
        '
        Me.gboxHistorial.Controls.Add(Me.gridHistorial)
        Me.gboxHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxHistorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gboxHistorial.ForeColor = System.Drawing.Color.Black
        Me.gboxHistorial.Location = New System.Drawing.Point(0, 232)
        Me.gboxHistorial.Name = "gboxHistorial"
        Me.gboxHistorial.Size = New System.Drawing.Size(704, 183)
        Me.gboxHistorial.TabIndex = 10
        Me.gboxHistorial.TabStop = False
        Me.gboxHistorial.Text = "Historial de validaciones"
        '
        'gridHistorial
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.gridHistorial.DisplayLayout.Appearance = Appearance1
        Me.gridHistorial.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom
        Me.gridHistorial.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridHistorial.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.gridHistorial.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.gridHistorial.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.gridHistorial.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        Me.gridHistorial.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.gridHistorial.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridHistorial.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.gridHistorial.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridHistorial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.gridHistorial.Location = New System.Drawing.Point(3, 16)
        Me.gridHistorial.Name = "gridHistorial"
        Me.gridHistorial.Size = New System.Drawing.Size(698, 164)
        Me.gridHistorial.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gboxModificacionStatusCliente)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(704, 232)
        Me.Panel1.TabIndex = 30
        '
        'gboxModificacionStatusCliente
        '
        Me.gboxModificacionStatusCliente.Controls.Add(Me.pnlClienteStatus)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.cboxClienteEstatus)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblClienteEstatus)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.cboxClienteCliente)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.txtClienteRazonSocial)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblClienteRazonSocial)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblClienteCliente)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.txtValidacionComentarios)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblVentasValidacionComentarios)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblVentasValidacionFecha)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.dateModificacionFecha)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.cboxValidador)
        Me.gboxModificacionStatusCliente.Controls.Add(Me.lblVentasValidador)
        Me.gboxModificacionStatusCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gboxModificacionStatusCliente.ForeColor = System.Drawing.Color.Black
        Me.gboxModificacionStatusCliente.Location = New System.Drawing.Point(118, 6)
        Me.gboxModificacionStatusCliente.Name = "gboxModificacionStatusCliente"
        Me.gboxModificacionStatusCliente.Size = New System.Drawing.Size(465, 217)
        Me.gboxModificacionStatusCliente.TabIndex = 9
        Me.gboxModificacionStatusCliente.TabStop = False
        '
        'pnlClienteStatus
        '
        Me.pnlClienteStatus.Controls.Add(Me.rbtnClienteStatusInactivo)
        Me.pnlClienteStatus.Controls.Add(Me.rbtnClienteStatusActivo)
        Me.pnlClienteStatus.Enabled = False
        Me.pnlClienteStatus.Location = New System.Drawing.Point(217, 117)
        Me.pnlClienteStatus.Name = "pnlClienteStatus"
        Me.pnlClienteStatus.Size = New System.Drawing.Size(145, 22)
        Me.pnlClienteStatus.TabIndex = 15
        '
        'rbtnClienteStatusInactivo
        '
        Me.rbtnClienteStatusInactivo.AutoSize = True
        Me.rbtnClienteStatusInactivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rbtnClienteStatusInactivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbtnClienteStatusInactivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbtnClienteStatusInactivo.Location = New System.Drawing.Point(71, 3)
        Me.rbtnClienteStatusInactivo.Name = "rbtnClienteStatusInactivo"
        Me.rbtnClienteStatusInactivo.Size = New System.Drawing.Size(71, 17)
        Me.rbtnClienteStatusInactivo.TabIndex = 1
        Me.rbtnClienteStatusInactivo.Text = "Inactivo"
        Me.rbtnClienteStatusInactivo.UseVisualStyleBackColor = True
        '
        'rbtnClienteStatusActivo
        '
        Me.rbtnClienteStatusActivo.AutoSize = True
        Me.rbtnClienteStatusActivo.Checked = True
        Me.rbtnClienteStatusActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rbtnClienteStatusActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbtnClienteStatusActivo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rbtnClienteStatusActivo.Location = New System.Drawing.Point(3, 3)
        Me.rbtnClienteStatusActivo.Name = "rbtnClienteStatusActivo"
        Me.rbtnClienteStatusActivo.Size = New System.Drawing.Size(61, 17)
        Me.rbtnClienteStatusActivo.TabIndex = 0
        Me.rbtnClienteStatusActivo.TabStop = True
        Me.rbtnClienteStatusActivo.Text = "Activo"
        Me.rbtnClienteStatusActivo.UseVisualStyleBackColor = True
        '
        'cboxClienteEstatus
        '
        Me.cboxClienteEstatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxClienteEstatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxClienteEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxClienteEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxClienteEstatus.FormattingEnabled = True
        Me.cboxClienteEstatus.Items.AddRange(New Object() {"CLIENTE", "PROSPECTO"})
        Me.cboxClienteEstatus.Location = New System.Drawing.Point(111, 62)
        Me.cboxClienteEstatus.Name = "cboxClienteEstatus"
        Me.cboxClienteEstatus.Size = New System.Drawing.Size(201, 21)
        Me.cboxClienteEstatus.TabIndex = 14
        '
        'lblClienteEstatus
        '
        Me.lblClienteEstatus.AutoSize = True
        Me.lblClienteEstatus.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblClienteEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblClienteEstatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblClienteEstatus.Location = New System.Drawing.Point(8, 63)
        Me.lblClienteEstatus.Name = "lblClienteEstatus"
        Me.lblClienteEstatus.Size = New System.Drawing.Size(37, 13)
        Me.lblClienteEstatus.TabIndex = 13
        Me.lblClienteEstatus.Text = "Status"
        '
        'cboxClienteCliente
        '
        Me.cboxClienteCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboxClienteCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cboxClienteCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxClienteCliente.Location = New System.Drawing.Point(112, 11)
        Me.cboxClienteCliente.Name = "cboxClienteCliente"
        Me.cboxClienteCliente.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboxClienteCliente.Size = New System.Drawing.Size(344, 21)
        Me.cboxClienteCliente.TabIndex = 11
        '
        'txtClienteRazonSocial
        '
        Me.txtClienteRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtClienteRazonSocial.Location = New System.Drawing.Point(111, 36)
        Me.txtClienteRazonSocial.MaxLength = 200
        Me.txtClienteRazonSocial.Name = "txtClienteRazonSocial"
        Me.txtClienteRazonSocial.Size = New System.Drawing.Size(344, 20)
        Me.txtClienteRazonSocial.TabIndex = 12
        '
        'lblClienteRazonSocial
        '
        Me.lblClienteRazonSocial.AutoSize = True
        Me.lblClienteRazonSocial.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteRazonSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblClienteRazonSocial.ForeColor = System.Drawing.Color.Black
        Me.lblClienteRazonSocial.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblClienteRazonSocial.Location = New System.Drawing.Point(8, 39)
        Me.lblClienteRazonSocial.Name = "lblClienteRazonSocial"
        Me.lblClienteRazonSocial.Size = New System.Drawing.Size(70, 13)
        Me.lblClienteRazonSocial.TabIndex = 9
        Me.lblClienteRazonSocial.Text = "Razón Social"
        '
        'lblClienteCliente
        '
        Me.lblClienteCliente.AutoSize = True
        Me.lblClienteCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblClienteCliente.ForeColor = System.Drawing.Color.Black
        Me.lblClienteCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblClienteCliente.Location = New System.Drawing.Point(9, 15)
        Me.lblClienteCliente.Name = "lblClienteCliente"
        Me.lblClienteCliente.Size = New System.Drawing.Size(88, 13)
        Me.lblClienteCliente.TabIndex = 10
        Me.lblClienteCliente.Text = "Nombre genérico"
        '
        'txtValidacionComentarios
        '
        Me.txtValidacionComentarios.Enabled = False
        Me.txtValidacionComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtValidacionComentarios.Location = New System.Drawing.Point(111, 153)
        Me.txtValidacionComentarios.MaxLength = 150
        Me.txtValidacionComentarios.Multiline = True
        Me.txtValidacionComentarios.Name = "txtValidacionComentarios"
        Me.txtValidacionComentarios.Size = New System.Drawing.Size(344, 53)
        Me.txtValidacionComentarios.TabIndex = 2
        '
        'lblVentasValidacionComentarios
        '
        Me.lblVentasValidacionComentarios.AutoSize = True
        Me.lblVentasValidacionComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblVentasValidacionComentarios.ForeColor = System.Drawing.Color.Black
        Me.lblVentasValidacionComentarios.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVentasValidacionComentarios.Location = New System.Drawing.Point(12, 153)
        Me.lblVentasValidacionComentarios.Name = "lblVentasValidacionComentarios"
        Me.lblVentasValidacionComentarios.Size = New System.Drawing.Size(60, 13)
        Me.lblVentasValidacionComentarios.TabIndex = 0
        Me.lblVentasValidacionComentarios.Text = "Comentario"
        '
        'lblVentasValidacionFecha
        '
        Me.lblVentasValidacionFecha.AutoSize = True
        Me.lblVentasValidacionFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblVentasValidacionFecha.ForeColor = System.Drawing.Color.Black
        Me.lblVentasValidacionFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVentasValidacionFecha.Location = New System.Drawing.Point(12, 125)
        Me.lblVentasValidacionFecha.Name = "lblVentasValidacionFecha"
        Me.lblVentasValidacionFecha.Size = New System.Drawing.Size(37, 13)
        Me.lblVentasValidacionFecha.TabIndex = 0
        Me.lblVentasValidacionFecha.Text = "Fecha"
        '
        'dateModificacionFecha
        '
        Me.dateModificacionFecha.CustomFormat = ""
        Me.dateModificacionFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dateModificacionFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateModificacionFecha.Location = New System.Drawing.Point(111, 119)
        Me.dateModificacionFecha.Name = "dateModificacionFecha"
        Me.dateModificacionFecha.Size = New System.Drawing.Size(87, 20)
        Me.dateModificacionFecha.TabIndex = 1
        '
        'cboxValidador
        '
        Me.cboxValidador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboxValidador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboxValidador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboxValidador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cboxValidador.FormattingEnabled = True
        Me.cboxValidador.Location = New System.Drawing.Point(111, 90)
        Me.cboxValidador.Name = "cboxValidador"
        Me.cboxValidador.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboxValidador.Size = New System.Drawing.Size(344, 21)
        Me.cboxValidador.TabIndex = 0
        '
        'lblVentasValidador
        '
        Me.lblVentasValidador.AutoSize = True
        Me.lblVentasValidador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblVentasValidador.ForeColor = System.Drawing.Color.Black
        Me.lblVentasValidador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVentasValidador.Location = New System.Drawing.Point(12, 93)
        Me.lblVentasValidador.Name = "lblVentasValidador"
        Me.lblVentasValidador.Size = New System.Drawing.Size(36, 13)
        Me.lblVentasValidador.TabIndex = 0
        Me.lblVentasValidador.Text = "Valida"
        '
        'pnlClienteBotones
        '
        Me.pnlClienteBotones.Controls.Add(Me.btnCancelarCliente)
        Me.pnlClienteBotones.Controls.Add(Me.lblCancelarCliente)
        Me.pnlClienteBotones.Controls.Add(Me.btnGuardarCliente)
        Me.pnlClienteBotones.Controls.Add(Me.lblGuardarCliente)
        Me.pnlClienteBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlClienteBotones.Location = New System.Drawing.Point(0, 415)
        Me.pnlClienteBotones.Name = "pnlClienteBotones"
        Me.pnlClienteBotones.Size = New System.Drawing.Size(704, 65)
        Me.pnlClienteBotones.TabIndex = 29
        '
        'btnCancelarCliente
        '
        Me.btnCancelarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnCancelarCliente.Image = Global.Ventas.Vista.My.Resources.Resources.salir_32
        Me.btnCancelarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancelarCliente.Location = New System.Drawing.Point(646, 9)
        Me.btnCancelarCliente.Name = "btnCancelarCliente"
        Me.btnCancelarCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelarCliente.TabIndex = 4
        Me.btnCancelarCliente.UseVisualStyleBackColor = True
        '
        'lblCancelarCliente
        '
        Me.lblCancelarCliente.AutoSize = True
        Me.lblCancelarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCancelarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCancelarCliente.Location = New System.Drawing.Point(645, 44)
        Me.lblCancelarCliente.Name = "lblCancelarCliente"
        Me.lblCancelarCliente.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelarCliente.TabIndex = 0
        Me.lblCancelarCliente.Text = "Cerrar"
        '
        'btnGuardarCliente
        '
        Me.btnGuardarCliente.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.btnGuardarCliente.Image = Global.Ventas.Vista.My.Resources.Resources.guardar2_32
        Me.btnGuardarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGuardarCliente.Location = New System.Drawing.Point(598, 9)
        Me.btnGuardarCliente.Name = "btnGuardarCliente"
        Me.btnGuardarCliente.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardarCliente.TabIndex = 3
        Me.btnGuardarCliente.UseVisualStyleBackColor = True
        '
        'lblGuardarCliente
        '
        Me.lblGuardarCliente.AutoSize = True
        Me.lblGuardarCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGuardarCliente.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardarCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGuardarCliente.Location = New System.Drawing.Point(592, 44)
        Me.lblGuardarCliente.Name = "lblGuardarCliente"
        Me.lblGuardarCliente.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardarCliente.TabIndex = 0
        Me.lblGuardarCliente.Text = "Guardar"
        '
        'pnlCabecera
        '
        Me.pnlCabecera.BackColor = System.Drawing.Color.White
        Me.pnlCabecera.Controls.Add(Me.pnlEncabezado)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCabecera.Location = New System.Drawing.Point(0, 0)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(704, 59)
        Me.pnlCabecera.TabIndex = 1
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.BackColor = System.Drawing.Color.White
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(704, 59)
        Me.pnlEncabezado.TabIndex = 25
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(183, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(521, 59)
        Me.pnlTitulo.TabIndex = 20
        '
        'lblTitulo
        '
        Me.lblTitulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitulo.Location = New System.Drawing.Point(276, 20)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblTitulo.Size = New System.Drawing.Size(174, 20)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Activación de cliente"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(453, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'Editar_StatusClienteForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 539)
        Me.Controls.Add(Me.pnlContenedor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(710, 561)
        Me.MinimumSize = New System.Drawing.Size(710, 561)
        Me.Name = "Editar_StatusClienteForm"
        Me.Text = "Activación de cliente"
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlListaCliente.ResumeLayout(False)
        Me.gboxHistorial.ResumeLayout(False)
        CType(Me.gridHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.gboxModificacionStatusCliente.ResumeLayout(False)
        Me.gboxModificacionStatusCliente.PerformLayout()
        Me.pnlClienteStatus.ResumeLayout(False)
        Me.pnlClienteStatus.PerformLayout()
        Me.pnlClienteBotones.ResumeLayout(False)
        Me.pnlClienteBotones.PerformLayout()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlListaCliente As System.Windows.Forms.Panel
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents gboxHistorial As System.Windows.Forms.GroupBox
    Friend WithEvents gridHistorial As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents gboxModificacionStatusCliente As System.Windows.Forms.GroupBox
    Friend WithEvents txtValidacionComentarios As System.Windows.Forms.TextBox
    Friend WithEvents lblVentasValidacionComentarios As System.Windows.Forms.Label
    Friend WithEvents lblVentasValidacionFecha As System.Windows.Forms.Label
    Friend WithEvents dateModificacionFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboxValidador As System.Windows.Forms.ComboBox
    Friend WithEvents lblVentasValidador As System.Windows.Forms.Label
    Friend WithEvents cboxClienteCliente As System.Windows.Forms.ComboBox
    Friend WithEvents txtClienteRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents lblClienteRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lblClienteCliente As System.Windows.Forms.Label
    Friend WithEvents pnlClienteStatus As System.Windows.Forms.Panel
    Friend WithEvents rbtnClienteStatusInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnClienteStatusActivo As System.Windows.Forms.RadioButton
    Friend WithEvents cboxClienteEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblClienteEstatus As System.Windows.Forms.Label
    Friend WithEvents pnlClienteBotones As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarCliente As System.Windows.Forms.Button
    Friend WithEvents lblCancelarCliente As System.Windows.Forms.Label
    Friend WithEvents btnGuardarCliente As System.Windows.Forms.Button
    Friend WithEvents lblGuardarCliente As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class
