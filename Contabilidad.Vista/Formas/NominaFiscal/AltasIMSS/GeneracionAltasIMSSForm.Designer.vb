<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GeneracionAltasIMSSForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneracionAltasIMSSForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.lblEditar = New System.Windows.Forms.Label()
        Me.pnlRegresar = New System.Windows.Forms.Panel()
        Me.btnRegresar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlRechazar = New System.Windows.Forms.Panel()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlAutorizar = New System.Windows.Forms.Panel()
        Me.btnAutorizar = New System.Windows.Forms.Button()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.pnlTTX = New System.Windows.Forms.Panel()
        Me.btnGenerarTtx = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblCerrar = New System.Windows.Forms.Label()
        Me.gpbFiltro = New System.Windows.Forms.GroupBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.lblLimpiar = New System.Windows.Forms.Label()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.btnLimpiarSolicitudes = New System.Windows.Forms.Button()
        Me.pnlMinimizarParametros = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.cmbEstatus = New System.Windows.Forms.ComboBox()
        Me.cmbPatron = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.grdGeneracionImss = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.imgLogo = New System.Windows.Forms.PictureBox()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.pnlRegresar.SuspendLayout()
        Me.pnlRechazar.SuspendLayout()
        Me.pnlAutorizar.SuspendLayout()
        Me.pnlTTX.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.gpbFiltro.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.pnlMinimizarParametros.SuspendLayout()
        CType(Me.grdGeneracionImss, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.pnlEditar)
        Me.pnlListaPaises.Controls.Add(Me.pnlRegresar)
        Me.pnlListaPaises.Controls.Add(Me.pnlRechazar)
        Me.pnlListaPaises.Controls.Add(Me.pnlAutorizar)
        Me.pnlListaPaises.Controls.Add(Me.pnlTTX)
        Me.pnlListaPaises.Controls.Add(Me.Panel1)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(1241, 69)
        Me.pnlListaPaises.TabIndex = 26
        '
        'pnlEditar
        '
        Me.pnlEditar.Controls.Add(Me.btnEditar)
        Me.pnlEditar.Controls.Add(Me.lblEditar)
        Me.pnlEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlEditar.Location = New System.Drawing.Point(278, 0)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(59, 69)
        Me.pnlEditar.TabIndex = 35
        '
        'btnEditar
        '
        Me.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.Location = New System.Drawing.Point(14, 8)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(32, 32)
        Me.btnEditar.TabIndex = 22
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'lblEditar
        '
        Me.lblEditar.AutoSize = True
        Me.lblEditar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblEditar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblEditar.Location = New System.Drawing.Point(13, 43)
        Me.lblEditar.Name = "lblEditar"
        Me.lblEditar.Size = New System.Drawing.Size(34, 13)
        Me.lblEditar.TabIndex = 23
        Me.lblEditar.Text = "Editar"
        '
        'pnlRegresar
        '
        Me.pnlRegresar.Controls.Add(Me.btnRegresar)
        Me.pnlRegresar.Controls.Add(Me.Label3)
        Me.pnlRegresar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRegresar.Location = New System.Drawing.Point(210, 0)
        Me.pnlRegresar.Name = "pnlRegresar"
        Me.pnlRegresar.Size = New System.Drawing.Size(68, 69)
        Me.pnlRegresar.TabIndex = 12
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Contabilidad.Vista.My.Resources.Resources.refresh_32
        Me.btnRegresar.Location = New System.Drawing.Point(19, 8)
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(31, 32)
        Me.btnRegresar.TabIndex = 1
        Me.btnRegresar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label3.Location = New System.Drawing.Point(9, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Regresar"
        '
        'pnlRechazar
        '
        Me.pnlRechazar.Controls.Add(Me.btnRechazar)
        Me.pnlRechazar.Controls.Add(Me.Label2)
        Me.pnlRechazar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlRechazar.Location = New System.Drawing.Point(144, 0)
        Me.pnlRechazar.Name = "pnlRechazar"
        Me.pnlRechazar.Size = New System.Drawing.Size(66, 69)
        Me.pnlRechazar.TabIndex = 11
        '
        'btnRechazar
        '
        Me.btnRechazar.Image = Global.Contabilidad.Vista.My.Resources.Resources.borrar_32
        Me.btnRechazar.Location = New System.Drawing.Point(18, 8)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(31, 32)
        Me.btnRechazar.TabIndex = 1
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(7, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Rechazar"
        '
        'pnlAutorizar
        '
        Me.pnlAutorizar.Controls.Add(Me.btnAutorizar)
        Me.pnlAutorizar.Controls.Add(Me.lblAutorizar)
        Me.pnlAutorizar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAutorizar.Location = New System.Drawing.Point(74, 0)
        Me.pnlAutorizar.Name = "pnlAutorizar"
        Me.pnlAutorizar.Size = New System.Drawing.Size(70, 69)
        Me.pnlAutorizar.TabIndex = 10
        '
        'btnAutorizar
        '
        Me.btnAutorizar.Image = Global.Contabilidad.Vista.My.Resources.Resources.aceptar_32
        Me.btnAutorizar.Location = New System.Drawing.Point(19, 8)
        Me.btnAutorizar.Name = "btnAutorizar"
        Me.btnAutorizar.Size = New System.Drawing.Size(31, 32)
        Me.btnAutorizar.TabIndex = 1
        Me.btnAutorizar.UseVisualStyleBackColor = True
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAutorizar.Location = New System.Drawing.Point(12, 43)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(44, 13)
        Me.lblAutorizar.TabIndex = 3
        Me.lblAutorizar.Text = "Aceptar"
        '
        'pnlTTX
        '
        Me.pnlTTX.Controls.Add(Me.btnGenerarTtx)
        Me.pnlTTX.Controls.Add(Me.Label4)
        Me.pnlTTX.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTTX.Location = New System.Drawing.Point(0, 0)
        Me.pnlTTX.Name = "pnlTTX"
        Me.pnlTTX.Size = New System.Drawing.Size(74, 69)
        Me.pnlTTX.TabIndex = 9
        '
        'btnGenerarTtx
        '
        Me.btnGenerarTtx.Image = Global.Contabilidad.Vista.My.Resources.Resources.reporteDeducciones_
        Me.btnGenerarTtx.Location = New System.Drawing.Point(21, 8)
        Me.btnGenerarTtx.Name = "btnGenerarTtx"
        Me.btnGenerarTtx.Size = New System.Drawing.Size(31, 32)
        Me.btnGenerarTtx.TabIndex = 1
        Me.btnGenerarTtx.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(2, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Generar TXT"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.imgLogo)
        Me.Panel1.Controls.Add(Me.lblEncabezado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(820, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 69)
        Me.Panel1.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(122, 20)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(220, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Generación de altas IMSS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 465)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1241, 60)
        Me.Panel2.TabIndex = 31
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnCerrar)
        Me.Panel7.Controls.Add(Me.lblCerrar)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel7.Location = New System.Drawing.Point(1189, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(52, 60)
        Me.Panel7.TabIndex = 37
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = Global.Contabilidad.Vista.My.Resources.Resources.salir_32
        Me.btnCerrar.Location = New System.Drawing.Point(9, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 32)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblCerrar
        '
        Me.lblCerrar.AutoSize = True
        Me.lblCerrar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCerrar.Location = New System.Drawing.Point(8, 39)
        Me.lblCerrar.Name = "lblCerrar"
        Me.lblCerrar.Size = New System.Drawing.Size(35, 13)
        Me.lblCerrar.TabIndex = 19
        Me.lblCerrar.Text = "Cerrar"
        '
        'gpbFiltro
        '
        Me.gpbFiltro.BackColor = System.Drawing.Color.AliceBlue
        Me.gpbFiltro.Controls.Add(Me.txtNombre)
        Me.gpbFiltro.Controls.Add(Me.Label14)
        Me.gpbFiltro.Controls.Add(Me.Panel10)
        Me.gpbFiltro.Controls.Add(Me.pnlMinimizarParametros)
        Me.gpbFiltro.Controls.Add(Me.cmbEstatus)
        Me.gpbFiltro.Controls.Add(Me.cmbPatron)
        Me.gpbFiltro.Controls.Add(Me.Label1)
        Me.gpbFiltro.Controls.Add(Me.lblNave)
        Me.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltro.Location = New System.Drawing.Point(0, 69)
        Me.gpbFiltro.Name = "gpbFiltro"
        Me.gpbFiltro.Size = New System.Drawing.Size(1241, 107)
        Me.gpbFiltro.TabIndex = 32
        Me.gpbFiltro.TabStop = False
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(562, 33)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(290, 20)
        Me.txtNombre.TabIndex = 97
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(495, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Nombre"
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.lblLimpiar)
        Me.Panel10.Controls.Add(Me.btnFiltrarSolicitud)
        Me.Panel10.Controls.Add(Me.lblBuscar)
        Me.Panel10.Controls.Add(Me.btnLimpiarSolicitudes)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(1061, 16)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(112, 88)
        Me.Panel10.TabIndex = 47
        '
        'lblLimpiar
        '
        Me.lblLimpiar.AutoSize = True
        Me.lblLimpiar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblLimpiar.Location = New System.Drawing.Point(66, 52)
        Me.lblLimpiar.Name = "lblLimpiar"
        Me.lblLimpiar.Size = New System.Drawing.Size(40, 13)
        Me.lblLimpiar.TabIndex = 46
        Me.lblLimpiar.Text = "Limpiar"
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.Image = Global.Contabilidad.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(20, 21)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 4
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(15, 52)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 45
        Me.lblBuscar.Text = "Mostrar"
        '
        'btnLimpiarSolicitudes
        '
        Me.btnLimpiarSolicitudes.Image = Global.Contabilidad.Vista.My.Resources.Resources.limpiar_32
        Me.btnLimpiarSolicitudes.Location = New System.Drawing.Point(70, 21)
        Me.btnLimpiarSolicitudes.Name = "btnLimpiarSolicitudes"
        Me.btnLimpiarSolicitudes.Size = New System.Drawing.Size(32, 32)
        Me.btnLimpiarSolicitudes.TabIndex = 5
        Me.btnLimpiarSolicitudes.UseVisualStyleBackColor = True
        '
        'pnlMinimizarParametros
        '
        Me.pnlMinimizarParametros.Controls.Add(Me.btnArriba)
        Me.pnlMinimizarParametros.Controls.Add(Me.btnAbajo)
        Me.pnlMinimizarParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMinimizarParametros.Location = New System.Drawing.Point(1173, 16)
        Me.pnlMinimizarParametros.Name = "pnlMinimizarParametros"
        Me.pnlMinimizarParametros.Size = New System.Drawing.Size(65, 88)
        Me.pnlMinimizarParametros.TabIndex = 44
        '
        'btnArriba
        '
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(8, 1)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 41
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(37, 1)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 42
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'cmbEstatus
        '
        Me.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstatus.ForeColor = System.Drawing.Color.Black
        Me.cmbEstatus.FormattingEnabled = True
        Me.cmbEstatus.Location = New System.Drawing.Point(75, 66)
        Me.cmbEstatus.Name = "cmbEstatus"
        Me.cmbEstatus.Size = New System.Drawing.Size(370, 21)
        Me.cmbEstatus.TabIndex = 1
        '
        'cmbPatron
        '
        Me.cmbPatron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatron.ForeColor = System.Drawing.Color.Black
        Me.cmbPatron.FormattingEnabled = True
        Me.cmbPatron.Location = New System.Drawing.Point(75, 33)
        Me.cmbPatron.Name = "cmbPatron"
        Me.cmbPatron.Size = New System.Drawing.Size(370, 21)
        Me.cmbPatron.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Estado"
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(21, 37)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(38, 13)
        Me.lblNave.TabIndex = 25
        Me.lblNave.Text = "Patrón"
        '
        'grdGeneracionImss
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdGeneracionImss.DisplayLayout.Appearance = Appearance1
        Me.grdGeneracionImss.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.[True]
        Me.grdGeneracionImss.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell
        Me.grdGeneracionImss.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdGeneracionImss.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Me.grdGeneracionImss.DisplayLayout.Override.FixedRowSortOrder = Infragistics.Win.UltraWinGrid.FixedRowSortOrder.Sorted
        Me.grdGeneracionImss.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdGeneracionImss.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Me.grdGeneracionImss.DisplayLayout.Override.RowFilterMode = Infragistics.Win.UltraWinGrid.RowFilterMode.AllRowsInBand
        Me.grdGeneracionImss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdGeneracionImss.Location = New System.Drawing.Point(0, 176)
        Me.grdGeneracionImss.Name = "grdGeneracionImss"
        Me.grdGeneracionImss.Size = New System.Drawing.Size(1241, 289)
        Me.grdGeneracionImss.TabIndex = 33
        '
        'imgLogo
        '
        Me.imgLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.imgLogo.Image = Global.Contabilidad.Vista.My.Resources.Resources.logoYuyin
        Me.imgLogo.Location = New System.Drawing.Point(349, 0)
        Me.imgLogo.Name = "imgLogo"
        Me.imgLogo.Size = New System.Drawing.Size(72, 69)
        Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgLogo.TabIndex = 46
        Me.imgLogo.TabStop = False
        '
        'GeneracionAltasIMSSForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 525)
        Me.Controls.Add(Me.grdGeneracionImss)
        Me.Controls.Add(Me.gpbFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.Name = "GeneracionAltasIMSSForm"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlEditar.ResumeLayout(False)
        Me.pnlEditar.PerformLayout()
        Me.pnlRegresar.ResumeLayout(False)
        Me.pnlRegresar.PerformLayout()
        Me.pnlRechazar.ResumeLayout(False)
        Me.pnlRechazar.PerformLayout()
        Me.pnlAutorizar.ResumeLayout(False)
        Me.pnlAutorizar.PerformLayout()
        Me.pnlTTX.ResumeLayout(False)
        Me.pnlTTX.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.gpbFiltro.ResumeLayout(False)
        Me.gpbFiltro.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.pnlMinimizarParametros.ResumeLayout(False)
        CType(Me.grdGeneracionImss, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlAutorizar As System.Windows.Forms.Panel
    Friend WithEvents btnRechazar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlTTX As System.Windows.Forms.Panel
    Friend WithEvents btnAutorizar As System.Windows.Forms.Button
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblCerrar As System.Windows.Forms.Label
    Friend WithEvents gpbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents lblLimpiar As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarSolicitudes As System.Windows.Forms.Button
    Friend WithEvents pnlMinimizarParametros As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents cmbEstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPatron As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents pnlRechazar As System.Windows.Forms.Panel
    Friend WithEvents btnGenerarTtx As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdGeneracionImss As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents pnlRegresar As System.Windows.Forms.Panel
    Friend WithEvents btnRegresar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents lblEditar As System.Windows.Forms.Label
    Friend WithEvents imgLogo As Windows.Forms.PictureBox
End Class
