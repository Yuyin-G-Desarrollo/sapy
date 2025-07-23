<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConsultaInventarioForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConsultaInventarioForm))
        Me.pnlListaPaises = New System.Windows.Forms.Panel()
        Me.lblConsultaInventarioNaves = New System.Windows.Forms.Label()
        Me.btnConsultaInventarioNaves = New System.Windows.Forms.Button()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblEncabezado = New System.Windows.Forms.Label()
        Me.pbYuyin = New System.Windows.Forms.PictureBox()
        Me.gpbFiltro = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnArriba = New System.Windows.Forms.Button()
        Me.btnAbajo = New System.Windows.Forms.Button()
        Me.btnFiltrarSolicitud = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.cmbDepartamentos = New System.Windows.Forms.ComboBox()
        Me.cmbNave = New System.Windows.Forms.ComboBox()
        Me.lblNave = New System.Windows.Forms.Label()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.pnlNave = New System.Windows.Forms.Panel()
        Me.btnDetalles4 = New System.Windows.Forms.Button()
        Me.btnDetalles3 = New System.Windows.Forms.Button()
        Me.btnDetalles2 = New System.Windows.Forms.Button()
        Me.lblInventarioNaveTitulo = New System.Windows.Forms.Label()
        Me.lblInventarioNave = New System.Windows.Forms.Label()
        Me.lblProgramasNave = New System.Windows.Forms.Label()
        Me.lblParesProcesoNave = New System.Windows.Forms.Label()
        Me.lblParesTerminadosNave = New System.Windows.Forms.Label()
        Me.lblInventarioNaveValor = New System.Windows.Forms.Label()
        Me.lblProgramasNaveValor = New System.Windows.Forms.Label()
        Me.lblParesTerminadosNaveValor = New System.Windows.Forms.Label()
        Me.lblParesProcesoNaveValor = New System.Windows.Forms.Label()
        Me.pnlDepartamento = New System.Windows.Forms.Panel()
        Me.btnDetalles8 = New System.Windows.Forms.Button()
        Me.btnDetalles7 = New System.Windows.Forms.Button()
        Me.btnDetalles6 = New System.Windows.Forms.Button()
        Me.lblTituloInventarioDepartamento = New System.Windows.Forms.Label()
        Me.lblinventariodepartamento = New System.Windows.Forms.Label()
        Me.lblProgramasdepartamentos = New System.Windows.Forms.Label()
        Me.lblProcesoDepartamento = New System.Windows.Forms.Label()
        Me.lblTerminados = New System.Windows.Forms.Label()
        Me.lblInventarioDEpartamentoDato = New System.Windows.Forms.Label()
        Me.lblProgramasDepartamentoDato = New System.Windows.Forms.Label()
        Me.lblTerminadosDepartamentoDato = New System.Windows.Forms.Label()
        Me.lblProcesoDepartamentoDato = New System.Windows.Forms.Label()
        Me.pnlListaPaises.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbFiltro.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlNave.SuspendLayout()
        Me.pnlDepartamento.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlListaPaises
        '
        Me.pnlListaPaises.BackColor = System.Drawing.Color.White
        Me.pnlListaPaises.Controls.Add(Me.lblConsultaInventarioNaves)
        Me.pnlListaPaises.Controls.Add(Me.btnConsultaInventarioNaves)
        Me.pnlListaPaises.Controls.Add(Me.pnlHeader)
        Me.pnlListaPaises.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlListaPaises.Location = New System.Drawing.Point(0, 0)
        Me.pnlListaPaises.Name = "pnlListaPaises"
        Me.pnlListaPaises.Size = New System.Drawing.Size(532, 59)
        Me.pnlListaPaises.TabIndex = 27
        '
        'lblConsultaInventarioNaves
        '
        Me.lblConsultaInventarioNaves.AutoSize = True
        Me.lblConsultaInventarioNaves.BackColor = System.Drawing.Color.Transparent
        Me.lblConsultaInventarioNaves.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblConsultaInventarioNaves.Location = New System.Drawing.Point(5, 34)
        Me.lblConsultaInventarioNaves.Name = "lblConsultaInventarioNaves"
        Me.lblConsultaInventarioNaves.Size = New System.Drawing.Size(54, 26)
        Me.lblConsultaInventarioNaves.TabIndex = 47
        Me.lblConsultaInventarioNaves.Text = "Inventario" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Naves"
        Me.lblConsultaInventarioNaves.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnConsultaInventarioNaves
        '
        Me.btnConsultaInventarioNaves.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnConsultaInventarioNaves.BackgroundImage = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnConsultaInventarioNaves.Location = New System.Drawing.Point(15, 3)
        Me.btnConsultaInventarioNaves.Name = "btnConsultaInventarioNaves"
        Me.btnConsultaInventarioNaves.Size = New System.Drawing.Size(32, 32)
        Me.btnConsultaInventarioNaves.TabIndex = 46
        Me.btnConsultaInventarioNaves.UseVisualStyleBackColor = False
        '
        'pnlHeader
        '
        Me.pnlHeader.Controls.Add(Me.lblEncabezado)
        Me.pnlHeader.Controls.Add(Me.pbYuyin)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlHeader.Location = New System.Drawing.Point(189, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(343, 59)
        Me.pnlHeader.TabIndex = 6
        '
        'lblEncabezado
        '
        Me.lblEncabezado.AutoSize = True
        Me.lblEncabezado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEncabezado.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblEncabezado.Location = New System.Drawing.Point(70, 18)
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Size = New System.Drawing.Size(190, 20)
        Me.lblEncabezado.TabIndex = 7
        Me.lblEncabezado.Text = "Consulta de Inventario"
        '
        'pbYuyin
        '
        Me.pbYuyin.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbYuyin.Image = CType(resources.GetObject("pbYuyin.Image"), System.Drawing.Image)
        Me.pbYuyin.Location = New System.Drawing.Point(284, 0)
        Me.pbYuyin.Name = "pbYuyin"
        Me.pbYuyin.Size = New System.Drawing.Size(59, 59)
        Me.pbYuyin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbYuyin.TabIndex = 45
        Me.pbYuyin.TabStop = False
        '
        'gpbFiltro
        '
        Me.gpbFiltro.Controls.Add(Me.Panel2)
        Me.gpbFiltro.Controls.Add(Me.cmbDepartamentos)
        Me.gpbFiltro.Controls.Add(Me.cmbNave)
        Me.gpbFiltro.Controls.Add(Me.lblNave)
        Me.gpbFiltro.Controls.Add(Me.lblNombreEmpleado)
        Me.gpbFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpbFiltro.Location = New System.Drawing.Point(0, 59)
        Me.gpbFiltro.Name = "gpbFiltro"
        Me.gpbFiltro.Size = New System.Drawing.Size(532, 102)
        Me.gpbFiltro.TabIndex = 29
        Me.gpbFiltro.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnArriba)
        Me.Panel2.Controls.Add(Me.btnAbajo)
        Me.Panel2.Controls.Add(Me.btnFiltrarSolicitud)
        Me.Panel2.Controls.Add(Me.lblBuscar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(473, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(56, 83)
        Me.Panel2.TabIndex = 40
        '
        'btnArriba
        '
        Me.btnArriba.AccessibleName = "0"
        Me.btnArriba.Image = CType(resources.GetObject("btnArriba.Image"), System.Drawing.Image)
        Me.btnArriba.Location = New System.Drawing.Point(5, 0)
        Me.btnArriba.Name = "btnArriba"
        Me.btnArriba.Size = New System.Drawing.Size(20, 20)
        Me.btnArriba.TabIndex = 35
        Me.btnArriba.UseVisualStyleBackColor = True
        '
        'btnAbajo
        '
        Me.btnAbajo.AccessibleName = "0"
        Me.btnAbajo.Image = CType(resources.GetObject("btnAbajo.Image"), System.Drawing.Image)
        Me.btnAbajo.Location = New System.Drawing.Point(27, 0)
        Me.btnAbajo.Name = "btnAbajo"
        Me.btnAbajo.Size = New System.Drawing.Size(20, 20)
        Me.btnAbajo.TabIndex = 36
        Me.btnAbajo.UseVisualStyleBackColor = True
        '
        'btnFiltrarSolicitud
        '
        Me.btnFiltrarSolicitud.Image = Global.Produccion.Vista.My.Resources.Resources.buscar_32
        Me.btnFiltrarSolicitud.Location = New System.Drawing.Point(15, 26)
        Me.btnFiltrarSolicitud.Name = "btnFiltrarSolicitud"
        Me.btnFiltrarSolicitud.Size = New System.Drawing.Size(32, 32)
        Me.btnFiltrarSolicitud.TabIndex = 5
        Me.btnFiltrarSolicitud.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblBuscar.Location = New System.Drawing.Point(10, 62)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(42, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Mostrar"
        '
        'cmbDepartamentos
        '
        Me.cmbDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamentos.ForeColor = System.Drawing.Color.Black
        Me.cmbDepartamentos.FormattingEnabled = True
        Me.cmbDepartamentos.Location = New System.Drawing.Point(268, 49)
        Me.cmbDepartamentos.Name = "cmbDepartamentos"
        Me.cmbDepartamentos.Size = New System.Drawing.Size(189, 21)
        Me.cmbDepartamentos.TabIndex = 27
        '
        'cmbNave
        '
        Me.cmbNave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNave.ForeColor = System.Drawing.Color.Black
        Me.cmbNave.FormattingEnabled = True
        Me.cmbNave.Items.AddRange(New Object() {"", "Pendientes", "Pagado"})
        Me.cmbNave.Location = New System.Drawing.Point(50, 49)
        Me.cmbNave.Name = "cmbNave"
        Me.cmbNave.Size = New System.Drawing.Size(121, 21)
        Me.cmbNave.TabIndex = 26
        '
        'lblNave
        '
        Me.lblNave.AutoSize = True
        Me.lblNave.ForeColor = System.Drawing.Color.Black
        Me.lblNave.Location = New System.Drawing.Point(13, 52)
        Me.lblNave.Name = "lblNave"
        Me.lblNave.Size = New System.Drawing.Size(33, 13)
        Me.lblNave.TabIndex = 25
        Me.lblNave.Text = "Nave"
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(183, 52)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(74, 13)
        Me.lblNombreEmpleado.TabIndex = 0
        Me.lblNombreEmpleado.Text = "Departamento"
        '
        'pnlNave
        '
        Me.pnlNave.Controls.Add(Me.btnDetalles4)
        Me.pnlNave.Controls.Add(Me.btnDetalles3)
        Me.pnlNave.Controls.Add(Me.btnDetalles2)
        Me.pnlNave.Controls.Add(Me.lblInventarioNaveTitulo)
        Me.pnlNave.Controls.Add(Me.lblInventarioNave)
        Me.pnlNave.Controls.Add(Me.lblProgramasNave)
        Me.pnlNave.Controls.Add(Me.lblParesProcesoNave)
        Me.pnlNave.Controls.Add(Me.lblParesTerminadosNave)
        Me.pnlNave.Controls.Add(Me.lblInventarioNaveValor)
        Me.pnlNave.Controls.Add(Me.lblProgramasNaveValor)
        Me.pnlNave.Controls.Add(Me.lblParesTerminadosNaveValor)
        Me.pnlNave.Controls.Add(Me.lblParesProcesoNaveValor)
        Me.pnlNave.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNave.Location = New System.Drawing.Point(0, 161)
        Me.pnlNave.Name = "pnlNave"
        Me.pnlNave.Size = New System.Drawing.Size(257, 212)
        Me.pnlNave.TabIndex = 30
        '
        'btnDetalles4
        '
        Me.btnDetalles4.Image = Global.Produccion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnDetalles4.Location = New System.Drawing.Point(31, 153)
        Me.btnDetalles4.Name = "btnDetalles4"
        Me.btnDetalles4.Size = New System.Drawing.Size(24, 24)
        Me.btnDetalles4.TabIndex = 41
        Me.btnDetalles4.UseVisualStyleBackColor = True
        '
        'btnDetalles3
        '
        Me.btnDetalles3.Image = Global.Produccion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnDetalles3.Location = New System.Drawing.Point(31, 120)
        Me.btnDetalles3.Name = "btnDetalles3"
        Me.btnDetalles3.Size = New System.Drawing.Size(24, 24)
        Me.btnDetalles3.TabIndex = 39
        Me.btnDetalles3.UseVisualStyleBackColor = True
        '
        'btnDetalles2
        '
        Me.btnDetalles2.Image = Global.Produccion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnDetalles2.Location = New System.Drawing.Point(31, 83)
        Me.btnDetalles2.Name = "btnDetalles2"
        Me.btnDetalles2.Size = New System.Drawing.Size(24, 24)
        Me.btnDetalles2.TabIndex = 37
        Me.btnDetalles2.UseVisualStyleBackColor = True
        '
        'lblInventarioNaveTitulo
        '
        Me.lblInventarioNaveTitulo.AutoSize = True
        Me.lblInventarioNaveTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventarioNaveTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblInventarioNaveTitulo.Location = New System.Drawing.Point(53, 13)
        Me.lblInventarioNaveTitulo.Name = "lblInventarioNaveTitulo"
        Me.lblInventarioNaveTitulo.Size = New System.Drawing.Size(156, 16)
        Me.lblInventarioNaveTitulo.TabIndex = 34
        Me.lblInventarioNaveTitulo.Text = "Inventario de la Nave"
        '
        'lblInventarioNave
        '
        Me.lblInventarioNave.AutoSize = True
        Me.lblInventarioNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventarioNave.ForeColor = System.Drawing.Color.Black
        Me.lblInventarioNave.Location = New System.Drawing.Point(55, 53)
        Me.lblInventarioNave.Name = "lblInventarioNave"
        Me.lblInventarioNave.Size = New System.Drawing.Size(66, 16)
        Me.lblInventarioNave.TabIndex = 33
        Me.lblInventarioNave.Text = "Inventario"
        '
        'lblProgramasNave
        '
        Me.lblProgramasNave.AutoSize = True
        Me.lblProgramasNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramasNave.ForeColor = System.Drawing.Color.Black
        Me.lblProgramasNave.Location = New System.Drawing.Point(55, 87)
        Me.lblProgramasNave.Name = "lblProgramasNave"
        Me.lblProgramasNave.Size = New System.Drawing.Size(75, 16)
        Me.lblProgramasNave.TabIndex = 32
        Me.lblProgramasNave.Text = "Programas"
        '
        'lblParesProcesoNave
        '
        Me.lblParesProcesoNave.AutoSize = True
        Me.lblParesProcesoNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProcesoNave.ForeColor = System.Drawing.Color.Black
        Me.lblParesProcesoNave.Location = New System.Drawing.Point(55, 124)
        Me.lblParesProcesoNave.Name = "lblParesProcesoNave"
        Me.lblParesProcesoNave.Size = New System.Drawing.Size(116, 16)
        Me.lblParesProcesoNave.TabIndex = 31
        Me.lblParesProcesoNave.Text = "Pares en Proceso"
        '
        'lblParesTerminadosNave
        '
        Me.lblParesTerminadosNave.AutoSize = True
        Me.lblParesTerminadosNave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesTerminadosNave.ForeColor = System.Drawing.Color.Black
        Me.lblParesTerminadosNave.Location = New System.Drawing.Point(55, 158)
        Me.lblParesTerminadosNave.Name = "lblParesTerminadosNave"
        Me.lblParesTerminadosNave.Size = New System.Drawing.Size(120, 16)
        Me.lblParesTerminadosNave.TabIndex = 30
        Me.lblParesTerminadosNave.Text = "Pares Terminados"
        '
        'lblInventarioNaveValor
        '
        Me.lblInventarioNaveValor.AutoSize = True
        Me.lblInventarioNaveValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventarioNaveValor.ForeColor = System.Drawing.Color.Black
        Me.lblInventarioNaveValor.Location = New System.Drawing.Point(208, 53)
        Me.lblInventarioNaveValor.Name = "lblInventarioNaveValor"
        Me.lblInventarioNaveValor.Size = New System.Drawing.Size(27, 15)
        Me.lblInventarioNaveValor.TabIndex = 29
        Me.lblInventarioNaveValor.Text = "0.0"
        '
        'lblProgramasNaveValor
        '
        Me.lblProgramasNaveValor.AutoSize = True
        Me.lblProgramasNaveValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramasNaveValor.ForeColor = System.Drawing.Color.Black
        Me.lblProgramasNaveValor.Location = New System.Drawing.Point(207, 87)
        Me.lblProgramasNaveValor.Name = "lblProgramasNaveValor"
        Me.lblProgramasNaveValor.Size = New System.Drawing.Size(27, 15)
        Me.lblProgramasNaveValor.TabIndex = 28
        Me.lblProgramasNaveValor.Text = "0.0"
        '
        'lblParesTerminadosNaveValor
        '
        Me.lblParesTerminadosNaveValor.AutoSize = True
        Me.lblParesTerminadosNaveValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesTerminadosNaveValor.ForeColor = System.Drawing.Color.Black
        Me.lblParesTerminadosNaveValor.Location = New System.Drawing.Point(200, 158)
        Me.lblParesTerminadosNaveValor.Name = "lblParesTerminadosNaveValor"
        Me.lblParesTerminadosNaveValor.Size = New System.Drawing.Size(15, 15)
        Me.lblParesTerminadosNaveValor.TabIndex = 27
        Me.lblParesTerminadosNaveValor.Text = "0"
        '
        'lblParesProcesoNaveValor
        '
        Me.lblParesProcesoNaveValor.AutoSize = True
        Me.lblParesProcesoNaveValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParesProcesoNaveValor.ForeColor = System.Drawing.Color.Black
        Me.lblParesProcesoNaveValor.Location = New System.Drawing.Point(200, 124)
        Me.lblParesProcesoNaveValor.Name = "lblParesProcesoNaveValor"
        Me.lblParesProcesoNaveValor.Size = New System.Drawing.Size(15, 15)
        Me.lblParesProcesoNaveValor.TabIndex = 26
        Me.lblParesProcesoNaveValor.Text = "0"
        '
        'pnlDepartamento
        '
        Me.pnlDepartamento.Controls.Add(Me.btnDetalles8)
        Me.pnlDepartamento.Controls.Add(Me.btnDetalles7)
        Me.pnlDepartamento.Controls.Add(Me.btnDetalles6)
        Me.pnlDepartamento.Controls.Add(Me.lblTituloInventarioDepartamento)
        Me.pnlDepartamento.Controls.Add(Me.lblinventariodepartamento)
        Me.pnlDepartamento.Controls.Add(Me.lblProgramasdepartamentos)
        Me.pnlDepartamento.Controls.Add(Me.lblProcesoDepartamento)
        Me.pnlDepartamento.Controls.Add(Me.lblTerminados)
        Me.pnlDepartamento.Controls.Add(Me.lblInventarioDEpartamentoDato)
        Me.pnlDepartamento.Controls.Add(Me.lblProgramasDepartamentoDato)
        Me.pnlDepartamento.Controls.Add(Me.lblTerminadosDepartamentoDato)
        Me.pnlDepartamento.Controls.Add(Me.lblProcesoDepartamentoDato)
        Me.pnlDepartamento.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDepartamento.Location = New System.Drawing.Point(273, 161)
        Me.pnlDepartamento.Name = "pnlDepartamento"
        Me.pnlDepartamento.Size = New System.Drawing.Size(259, 212)
        Me.pnlDepartamento.TabIndex = 31
        '
        'btnDetalles8
        '
        Me.btnDetalles8.Image = Global.Produccion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnDetalles8.Location = New System.Drawing.Point(35, 153)
        Me.btnDetalles8.Name = "btnDetalles8"
        Me.btnDetalles8.Size = New System.Drawing.Size(24, 24)
        Me.btnDetalles8.TabIndex = 50
        Me.btnDetalles8.UseVisualStyleBackColor = True
        '
        'btnDetalles7
        '
        Me.btnDetalles7.Image = Global.Produccion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnDetalles7.Location = New System.Drawing.Point(35, 120)
        Me.btnDetalles7.Name = "btnDetalles7"
        Me.btnDetalles7.Size = New System.Drawing.Size(24, 24)
        Me.btnDetalles7.TabIndex = 48
        Me.btnDetalles7.UseVisualStyleBackColor = True
        '
        'btnDetalles6
        '
        Me.btnDetalles6.Image = Global.Produccion.Vista.My.Resources.Resources._1385860942_Zoom
        Me.btnDetalles6.Location = New System.Drawing.Point(35, 83)
        Me.btnDetalles6.Name = "btnDetalles6"
        Me.btnDetalles6.Size = New System.Drawing.Size(24, 24)
        Me.btnDetalles6.TabIndex = 46
        Me.btnDetalles6.UseVisualStyleBackColor = True
        '
        'lblTituloInventarioDepartamento
        '
        Me.lblTituloInventarioDepartamento.AutoSize = True
        Me.lblTituloInventarioDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloInventarioDepartamento.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTituloInventarioDepartamento.Location = New System.Drawing.Point(43, 13)
        Me.lblTituloInventarioDepartamento.Name = "lblTituloInventarioDepartamento"
        Me.lblTituloInventarioDepartamento.Size = New System.Drawing.Size(182, 16)
        Me.lblTituloInventarioDepartamento.TabIndex = 43
        Me.lblTituloInventarioDepartamento.Text = "Inventario  Departamento"
        '
        'lblinventariodepartamento
        '
        Me.lblinventariodepartamento.AutoSize = True
        Me.lblinventariodepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinventariodepartamento.ForeColor = System.Drawing.Color.Black
        Me.lblinventariodepartamento.Location = New System.Drawing.Point(60, 53)
        Me.lblinventariodepartamento.Name = "lblinventariodepartamento"
        Me.lblinventariodepartamento.Size = New System.Drawing.Size(66, 16)
        Me.lblinventariodepartamento.TabIndex = 42
        Me.lblinventariodepartamento.Text = "Inventario"
        '
        'lblProgramasdepartamentos
        '
        Me.lblProgramasdepartamentos.AutoSize = True
        Me.lblProgramasdepartamentos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramasdepartamentos.ForeColor = System.Drawing.Color.Black
        Me.lblProgramasdepartamentos.Location = New System.Drawing.Point(60, 87)
        Me.lblProgramasdepartamentos.Name = "lblProgramasdepartamentos"
        Me.lblProgramasdepartamentos.Size = New System.Drawing.Size(75, 16)
        Me.lblProgramasdepartamentos.TabIndex = 41
        Me.lblProgramasdepartamentos.Text = "Programas"
        '
        'lblProcesoDepartamento
        '
        Me.lblProcesoDepartamento.AutoSize = True
        Me.lblProcesoDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesoDepartamento.ForeColor = System.Drawing.Color.Black
        Me.lblProcesoDepartamento.Location = New System.Drawing.Point(60, 124)
        Me.lblProcesoDepartamento.Name = "lblProcesoDepartamento"
        Me.lblProcesoDepartamento.Size = New System.Drawing.Size(116, 16)
        Me.lblProcesoDepartamento.TabIndex = 40
        Me.lblProcesoDepartamento.Text = "Pares en Proceso"
        '
        'lblTerminados
        '
        Me.lblTerminados.AutoSize = True
        Me.lblTerminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerminados.ForeColor = System.Drawing.Color.Black
        Me.lblTerminados.Location = New System.Drawing.Point(60, 157)
        Me.lblTerminados.Name = "lblTerminados"
        Me.lblTerminados.Size = New System.Drawing.Size(120, 16)
        Me.lblTerminados.TabIndex = 39
        Me.lblTerminados.Text = "Pares Terminados"
        '
        'lblInventarioDEpartamentoDato
        '
        Me.lblInventarioDEpartamentoDato.AutoSize = True
        Me.lblInventarioDEpartamentoDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInventarioDEpartamentoDato.ForeColor = System.Drawing.Color.Black
        Me.lblInventarioDEpartamentoDato.Location = New System.Drawing.Point(208, 53)
        Me.lblInventarioDEpartamentoDato.Name = "lblInventarioDEpartamentoDato"
        Me.lblInventarioDEpartamentoDato.Size = New System.Drawing.Size(27, 15)
        Me.lblInventarioDEpartamentoDato.TabIndex = 38
        Me.lblInventarioDEpartamentoDato.Text = "0.0"
        '
        'lblProgramasDepartamentoDato
        '
        Me.lblProgramasDepartamentoDato.AutoSize = True
        Me.lblProgramasDepartamentoDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgramasDepartamentoDato.ForeColor = System.Drawing.Color.Black
        Me.lblProgramasDepartamentoDato.Location = New System.Drawing.Point(207, 87)
        Me.lblProgramasDepartamentoDato.Name = "lblProgramasDepartamentoDato"
        Me.lblProgramasDepartamentoDato.Size = New System.Drawing.Size(27, 15)
        Me.lblProgramasDepartamentoDato.TabIndex = 37
        Me.lblProgramasDepartamentoDato.Text = "0.0"
        '
        'lblTerminadosDepartamentoDato
        '
        Me.lblTerminadosDepartamentoDato.AutoSize = True
        Me.lblTerminadosDepartamentoDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTerminadosDepartamentoDato.ForeColor = System.Drawing.Color.Black
        Me.lblTerminadosDepartamentoDato.Location = New System.Drawing.Point(201, 157)
        Me.lblTerminadosDepartamentoDato.Name = "lblTerminadosDepartamentoDato"
        Me.lblTerminadosDepartamentoDato.Size = New System.Drawing.Size(15, 15)
        Me.lblTerminadosDepartamentoDato.TabIndex = 36
        Me.lblTerminadosDepartamentoDato.Text = "0"
        '
        'lblProcesoDepartamentoDato
        '
        Me.lblProcesoDepartamentoDato.AutoSize = True
        Me.lblProcesoDepartamentoDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesoDepartamentoDato.ForeColor = System.Drawing.Color.Black
        Me.lblProcesoDepartamentoDato.Location = New System.Drawing.Point(201, 124)
        Me.lblProcesoDepartamentoDato.Name = "lblProcesoDepartamentoDato"
        Me.lblProcesoDepartamentoDato.Size = New System.Drawing.Size(15, 15)
        Me.lblProcesoDepartamentoDato.TabIndex = 35
        Me.lblProcesoDepartamentoDato.Text = "0"
        '
        'ConsultaInventarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(532, 373)
        Me.Controls.Add(Me.pnlDepartamento)
        Me.Controls.Add(Me.pnlNave)
        Me.Controls.Add(Me.gpbFiltro)
        Me.Controls.Add(Me.pnlListaPaises)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(538, 395)
        Me.MinimumSize = New System.Drawing.Size(538, 395)
        Me.Name = "ConsultaInventarioForm"
        Me.Text = "Consulta de Inventario"
        Me.pnlListaPaises.ResumeLayout(False)
        Me.pnlListaPaises.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.pbYuyin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbFiltro.ResumeLayout(False)
        Me.gpbFiltro.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlNave.ResumeLayout(False)
        Me.pnlNave.PerformLayout()
        Me.pnlDepartamento.ResumeLayout(False)
        Me.pnlDepartamento.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlListaPaises As System.Windows.Forms.Panel
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblEncabezado As System.Windows.Forms.Label
    Friend WithEvents pbYuyin As System.Windows.Forms.PictureBox
    Friend WithEvents gpbFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents cmbDepartamentos As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNave As System.Windows.Forms.ComboBox
    Friend WithEvents lblNave As System.Windows.Forms.Label
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents btnFiltrarSolicitud As System.Windows.Forms.Button
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents pnlNave As System.Windows.Forms.Panel
    Friend WithEvents pnlDepartamento As System.Windows.Forms.Panel
    Friend WithEvents lblInventarioNaveTitulo As System.Windows.Forms.Label
    Friend WithEvents lblInventarioNave As System.Windows.Forms.Label
    Friend WithEvents lblProgramasNave As System.Windows.Forms.Label
    Friend WithEvents lblParesProcesoNave As System.Windows.Forms.Label
    Friend WithEvents lblParesTerminadosNave As System.Windows.Forms.Label
    Friend WithEvents lblInventarioNaveValor As System.Windows.Forms.Label
    Friend WithEvents lblProgramasNaveValor As System.Windows.Forms.Label
    Friend WithEvents lblParesTerminadosNaveValor As System.Windows.Forms.Label
    Friend WithEvents lblParesProcesoNaveValor As System.Windows.Forms.Label
    Friend WithEvents lblTituloInventarioDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblinventariodepartamento As System.Windows.Forms.Label
    Friend WithEvents lblProgramasdepartamentos As System.Windows.Forms.Label
    Friend WithEvents lblProcesoDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblTerminados As System.Windows.Forms.Label
    Friend WithEvents lblInventarioDEpartamentoDato As System.Windows.Forms.Label
    Friend WithEvents lblProgramasDepartamentoDato As System.Windows.Forms.Label
    Friend WithEvents lblTerminadosDepartamentoDato As System.Windows.Forms.Label
    Friend WithEvents lblProcesoDepartamentoDato As System.Windows.Forms.Label
    Friend WithEvents btnDetalles4 As System.Windows.Forms.Button
    Friend WithEvents btnDetalles3 As System.Windows.Forms.Button
    Friend WithEvents btnDetalles2 As System.Windows.Forms.Button
    Friend WithEvents btnDetalles8 As System.Windows.Forms.Button
    Friend WithEvents btnDetalles7 As System.Windows.Forms.Button
    Friend WithEvents btnDetalles6 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnArriba As System.Windows.Forms.Button
    Friend WithEvents btnAbajo As System.Windows.Forms.Button
    Friend WithEvents btnConsultaInventarioNaves As System.Windows.Forms.Button
    Friend WithEvents lblConsultaInventarioNaves As System.Windows.Forms.Label
End Class
