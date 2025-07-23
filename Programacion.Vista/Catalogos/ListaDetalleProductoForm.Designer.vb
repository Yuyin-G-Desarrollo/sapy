<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListaDetalleProductoForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListaDetalleProductoForm))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.btnLogoMarcaMultiple = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCargarImagenesMultiple = New System.Windows.Forms.Button()
        Me.lblSeleccionImagenMultiple = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.pnlSalir = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.lblClientePropietario = New System.Windows.Forms.Label()
        Me.lblCategoriaNombre = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lbldescripcionNombre = New System.Windows.Forms.Label()
        Me.lblMarcaNombre = New System.Windows.Forms.Label()
        Me.lblCodigoNombre = New System.Windows.Forms.Label()
        Me.lblTemporadaNombre = New System.Windows.Forms.Label()
        Me.lblSubfamiliaNombre = New System.Windows.Forms.Label()
        Me.lblColeccionNombre = New System.Windows.Forms.Label()
        Me.lblColeccion = New System.Windows.Forms.Label()
        Me.lblSubfamilia = New System.Windows.Forms.Label()
        Me.lblTemporada = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gprFoto = New System.Windows.Forms.GroupBox()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.grpDibujo = New System.Windows.Forms.GroupBox()
        Me.picDibujo = New System.Windows.Forms.PictureBox()
        Me.txtSubfamilia = New System.Windows.Forms.TextBox()
        Me.txtColeccion = New System.Windows.Forms.TextBox()
        Me.txtTemporada = New System.Windows.Forms.TextBox()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.grdListaDetallesProd = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.pctTitulo = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlEstado.SuspendLayout()
        Me.pnlSalir.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.grpDatosGenerales.SuspendLayout()
        Me.gprFoto.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDibujo.SuspendLayout()
        CType(Me.picDibujo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListaDetallesProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.pnlOperaciones)
        Me.pnlHeader.Controls.Add(Me.pnlTitulo)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1047, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.btnLogoMarcaMultiple)
        Me.pnlOperaciones.Controls.Add(Me.Label1)
        Me.pnlOperaciones.Controls.Add(Me.btnCargarImagenesMultiple)
        Me.pnlOperaciones.Controls.Add(Me.lblSeleccionImagenMultiple)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(245, 60)
        Me.pnlOperaciones.TabIndex = 1
        '
        'btnLogoMarcaMultiple
        '
        Me.btnLogoMarcaMultiple.Image = Global.Programacion.Vista.My.Resources.Resources.agregar_32
        Me.btnLogoMarcaMultiple.Location = New System.Drawing.Point(141, 6)
        Me.btnLogoMarcaMultiple.Name = "btnLogoMarcaMultiple"
        Me.btnLogoMarcaMultiple.Size = New System.Drawing.Size(32, 32)
        Me.btnLogoMarcaMultiple.TabIndex = 34
        Me.btnLogoMarcaMultiple.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(106, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Logo Marca Multiple"
        '
        'btnCargarImagenesMultiple
        '
        Me.btnCargarImagenesMultiple.Image = Global.Programacion.Vista.My.Resources.Resources.galeria
        Me.btnCargarImagenesMultiple.Location = New System.Drawing.Point(35, 6)
        Me.btnCargarImagenesMultiple.Name = "btnCargarImagenesMultiple"
        Me.btnCargarImagenesMultiple.Size = New System.Drawing.Size(32, 32)
        Me.btnCargarImagenesMultiple.TabIndex = 32
        Me.btnCargarImagenesMultiple.UseVisualStyleBackColor = True
        '
        'lblSeleccionImagenMultiple
        '
        Me.lblSeleccionImagenMultiple.AutoSize = True
        Me.lblSeleccionImagenMultiple.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblSeleccionImagenMultiple.Location = New System.Drawing.Point(11, 41)
        Me.lblSeleccionImagenMultiple.Name = "lblSeleccionImagenMultiple"
        Me.lblSeleccionImagenMultiple.Size = New System.Drawing.Size(81, 13)
        Me.lblSeleccionImagenMultiple.TabIndex = 33
        Me.lblSeleccionImagenMultiple.Text = "Imagen Multiple"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.pctTitulo)
        Me.pnlTitulo.Controls.Add(Me.lblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(751, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(296, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitulo.Location = New System.Drawing.Point(145, 23)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(79, 20)
        Me.lblTitulo.TabIndex = 1
        Me.lblTitulo.Text = "Artículos"
        '
        'pnlEstado
        '
        Me.pnlEstado.BackColor = System.Drawing.Color.White
        Me.pnlEstado.Controls.Add(Me.pnlSalir)
        Me.pnlEstado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlEstado.Location = New System.Drawing.Point(0, 522)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(1047, 60)
        Me.pnlEstado.TabIndex = 1
        '
        'pnlSalir
        '
        Me.pnlSalir.Controls.Add(Me.btnCancelar)
        Me.pnlSalir.Controls.Add(Me.lblCancelar)
        Me.pnlSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSalir.Location = New System.Drawing.Point(847, 0)
        Me.pnlSalir.Name = "pnlSalir"
        Me.pnlSalir.Size = New System.Drawing.Size(200, 60)
        Me.pnlSalir.TabIndex = 13
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(141, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(140, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 11
        Me.lblCancelar.Text = "Cerrar"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.grpDatosGenerales)
        Me.pnlDatos.Controls.Add(Me.gprFoto)
        Me.pnlDatos.Controls.Add(Me.grpDibujo)
        Me.pnlDatos.Controls.Add(Me.txtSubfamilia)
        Me.pnlDatos.Controls.Add(Me.txtColeccion)
        Me.pnlDatos.Controls.Add(Me.txtTemporada)
        Me.pnlDatos.Controls.Add(Me.txtMarca)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtDescripcion)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 60)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1047, 155)
        Me.pnlDatos.TabIndex = 3
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.lblNombreCliente)
        Me.grpDatosGenerales.Controls.Add(Me.lblClientePropietario)
        Me.grpDatosGenerales.Controls.Add(Me.lblCategoriaNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblCategoria)
        Me.grpDatosGenerales.Controls.Add(Me.lblMarca)
        Me.grpDatosGenerales.Controls.Add(Me.lbldescripcionNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblMarcaNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigoNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblTemporadaNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblSubfamiliaNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblColeccionNombre)
        Me.grpDatosGenerales.Controls.Add(Me.lblColeccion)
        Me.grpDatosGenerales.Controls.Add(Me.lblSubfamilia)
        Me.grpDatosGenerales.Controls.Add(Me.lblTemporada)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigo)
        Me.grpDatosGenerales.Controls.Add(Me.Label3)
        Me.grpDatosGenerales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpDatosGenerales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(0, 0)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(707, 155)
        Me.grpDatosGenerales.TabIndex = 30
        Me.grpDatosGenerales.TabStop = False
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.ForeColor = System.Drawing.Color.Black
        Me.lblNombreCliente.Location = New System.Drawing.Point(402, 72)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(45, 15)
        Me.lblNombreCliente.TabIndex = 33
        Me.lblNombreCliente.Text = "Cliente"
        Me.lblNombreCliente.Visible = False
        '
        'lblClientePropietario
        '
        Me.lblClientePropietario.AutoSize = True
        Me.lblClientePropietario.Location = New System.Drawing.Point(284, 73)
        Me.lblClientePropietario.Name = "lblClientePropietario"
        Me.lblClientePropietario.Size = New System.Drawing.Size(94, 13)
        Me.lblClientePropietario.TabIndex = 32
        Me.lblClientePropietario.Text = "Modelo del Cliente"
        Me.lblClientePropietario.Visible = False
        '
        'lblCategoriaNombre
        '
        Me.lblCategoriaNombre.AutoSize = True
        Me.lblCategoriaNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblCategoriaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoriaNombre.ForeColor = System.Drawing.Color.Black
        Me.lblCategoriaNombre.Location = New System.Drawing.Point(104, 72)
        Me.lblCategoriaNombre.Name = "lblCategoriaNombre"
        Me.lblCategoriaNombre.Size = New System.Drawing.Size(58, 15)
        Me.lblCategoriaNombre.TabIndex = 31
        Me.lblCategoriaNombre.Text = "categoria"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Location = New System.Drawing.Point(52, 73)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(28, 13)
        Me.lblCategoria.TabIndex = 30
        Me.lblCategoria.Text = "Tipo"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Location = New System.Drawing.Point(43, 48)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(37, 13)
        Me.lblMarca.TabIndex = 5
        Me.lblMarca.Text = "Marca"
        '
        'lbldescripcionNombre
        '
        Me.lbldescripcionNombre.AutoSize = True
        Me.lbldescripcionNombre.BackColor = System.Drawing.Color.Transparent
        Me.lbldescripcionNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldescripcionNombre.ForeColor = System.Drawing.Color.Black
        Me.lbldescripcionNombre.Location = New System.Drawing.Point(402, 22)
        Me.lbldescripcionNombre.Name = "lbldescripcionNombre"
        Me.lbldescripcionNombre.Size = New System.Drawing.Size(70, 15)
        Me.lbldescripcionNombre.TabIndex = 29
        Me.lbldescripcionNombre.Text = "descripcion"
        '
        'lblMarcaNombre
        '
        Me.lblMarcaNombre.AutoSize = True
        Me.lblMarcaNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblMarcaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarcaNombre.ForeColor = System.Drawing.Color.Black
        Me.lblMarcaNombre.Location = New System.Drawing.Point(104, 47)
        Me.lblMarcaNombre.Name = "lblMarcaNombre"
        Me.lblMarcaNombre.Size = New System.Drawing.Size(42, 15)
        Me.lblMarcaNombre.TabIndex = 28
        Me.lblMarcaNombre.Text = "marca"
        '
        'lblCodigoNombre
        '
        Me.lblCodigoNombre.AutoSize = True
        Me.lblCodigoNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigoNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoNombre.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoNombre.Location = New System.Drawing.Point(104, 22)
        Me.lblCodigoNombre.Name = "lblCodigoNombre"
        Me.lblCodigoNombre.Size = New System.Drawing.Size(44, 15)
        Me.lblCodigoNombre.TabIndex = 24
        Me.lblCodigoNombre.Text = "codigo"
        '
        'lblTemporadaNombre
        '
        Me.lblTemporadaNombre.AutoSize = True
        Me.lblTemporadaNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblTemporadaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblTemporadaNombre.ForeColor = System.Drawing.Color.Black
        Me.lblTemporadaNombre.Location = New System.Drawing.Point(104, 123)
        Me.lblTemporadaNombre.Name = "lblTemporadaNombre"
        Me.lblTemporadaNombre.Size = New System.Drawing.Size(57, 13)
        Me.lblTemporadaNombre.TabIndex = 25
        Me.lblTemporadaNombre.Text = "temporada"
        '
        'lblSubfamiliaNombre
        '
        Me.lblSubfamiliaNombre.AutoSize = True
        Me.lblSubfamiliaNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblSubfamiliaNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.lblSubfamiliaNombre.ForeColor = System.Drawing.Color.Black
        Me.lblSubfamiliaNombre.Location = New System.Drawing.Point(104, 98)
        Me.lblSubfamiliaNombre.Name = "lblSubfamiliaNombre"
        Me.lblSubfamiliaNombre.Size = New System.Drawing.Size(53, 13)
        Me.lblSubfamiliaNombre.TabIndex = 26
        Me.lblSubfamiliaNombre.Text = "subfamilia"
        '
        'lblColeccionNombre
        '
        Me.lblColeccionNombre.AutoSize = True
        Me.lblColeccionNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblColeccionNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColeccionNombre.ForeColor = System.Drawing.Color.Black
        Me.lblColeccionNombre.Location = New System.Drawing.Point(402, 47)
        Me.lblColeccionNombre.Name = "lblColeccionNombre"
        Me.lblColeccionNombre.Size = New System.Drawing.Size(59, 15)
        Me.lblColeccionNombre.TabIndex = 27
        Me.lblColeccionNombre.Text = "coleccion"
        '
        'lblColeccion
        '
        Me.lblColeccion.AutoSize = True
        Me.lblColeccion.Location = New System.Drawing.Point(324, 48)
        Me.lblColeccion.Name = "lblColeccion"
        Me.lblColeccion.Size = New System.Drawing.Size(54, 13)
        Me.lblColeccion.TabIndex = 9
        Me.lblColeccion.Text = "Colección"
        '
        'lblSubfamilia
        '
        Me.lblSubfamilia.AutoSize = True
        Me.lblSubfamilia.Location = New System.Drawing.Point(13, 98)
        Me.lblSubfamilia.Name = "lblSubfamilia"
        Me.lblSubfamilia.Size = New System.Drawing.Size(67, 13)
        Me.lblSubfamilia.TabIndex = 17
        Me.lblSubfamilia.Text = "Aplicaciones"
        '
        'lblTemporada
        '
        Me.lblTemporada.AutoSize = True
        Me.lblTemporada.Location = New System.Drawing.Point(19, 123)
        Me.lblTemporada.Name = "lblTemporada"
        Me.lblTemporada.Size = New System.Drawing.Size(61, 13)
        Me.lblTemporada.TabIndex = 6
        Me.lblTemporada.Text = "Temporada"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(40, 23)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(40, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(315, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Descripción"
        '
        'gprFoto
        '
        Me.gprFoto.BackColor = System.Drawing.Color.AliceBlue
        Me.gprFoto.Controls.Add(Me.picFoto)
        Me.gprFoto.Dock = System.Windows.Forms.DockStyle.Right
        Me.gprFoto.Location = New System.Drawing.Point(707, 0)
        Me.gprFoto.Name = "gprFoto"
        Me.gprFoto.Size = New System.Drawing.Size(170, 155)
        Me.gprFoto.TabIndex = 23
        Me.gprFoto.TabStop = False
        Me.gprFoto.Text = "Foto"
        '
        'picFoto
        '
        Me.picFoto.BackColor = System.Drawing.Color.White
        Me.picFoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFoto.Image = CType(resources.GetObject("picFoto.Image"), System.Drawing.Image)
        Me.picFoto.Location = New System.Drawing.Point(3, 16)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(164, 136)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 19
        Me.picFoto.TabStop = False
        '
        'grpDibujo
        '
        Me.grpDibujo.Controls.Add(Me.picDibujo)
        Me.grpDibujo.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpDibujo.Location = New System.Drawing.Point(877, 0)
        Me.grpDibujo.Name = "grpDibujo"
        Me.grpDibujo.Size = New System.Drawing.Size(170, 155)
        Me.grpDibujo.TabIndex = 21
        Me.grpDibujo.TabStop = False
        Me.grpDibujo.Text = "Dibujo"
        '
        'picDibujo
        '
        Me.picDibujo.BackColor = System.Drawing.Color.White
        Me.picDibujo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picDibujo.Image = CType(resources.GetObject("picDibujo.Image"), System.Drawing.Image)
        Me.picDibujo.Location = New System.Drawing.Point(3, 16)
        Me.picDibujo.Name = "picDibujo"
        Me.picDibujo.Size = New System.Drawing.Size(164, 136)
        Me.picDibujo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picDibujo.TabIndex = 20
        Me.picDibujo.TabStop = False
        '
        'txtSubfamilia
        '
        Me.txtSubfamilia.BackColor = System.Drawing.Color.White
        Me.txtSubfamilia.Location = New System.Drawing.Point(98, 16)
        Me.txtSubfamilia.Name = "txtSubfamilia"
        Me.txtSubfamilia.ReadOnly = True
        Me.txtSubfamilia.Size = New System.Drawing.Size(176, 20)
        Me.txtSubfamilia.TabIndex = 18
        Me.txtSubfamilia.Visible = False
        '
        'txtColeccion
        '
        Me.txtColeccion.BackColor = System.Drawing.Color.White
        Me.txtColeccion.Location = New System.Drawing.Point(98, 16)
        Me.txtColeccion.Name = "txtColeccion"
        Me.txtColeccion.ReadOnly = True
        Me.txtColeccion.Size = New System.Drawing.Size(176, 20)
        Me.txtColeccion.TabIndex = 12
        Me.txtColeccion.Visible = False
        '
        'txtTemporada
        '
        Me.txtTemporada.BackColor = System.Drawing.Color.White
        Me.txtTemporada.Location = New System.Drawing.Point(98, 16)
        Me.txtTemporada.Name = "txtTemporada"
        Me.txtTemporada.ReadOnly = True
        Me.txtTemporada.Size = New System.Drawing.Size(176, 20)
        Me.txtTemporada.TabIndex = 7
        Me.txtTemporada.Visible = False
        '
        'txtMarca
        '
        Me.txtMarca.BackColor = System.Drawing.Color.White
        Me.txtMarca.Location = New System.Drawing.Point(84, 34)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(176, 20)
        Me.txtMarca.TabIndex = 8
        Me.txtMarca.Visible = False
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.White
        Me.txtCodigo.Location = New System.Drawing.Point(84, 16)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(176, 20)
        Me.txtCodigo.TabIndex = 4
        Me.txtCodigo.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.Location = New System.Drawing.Point(69, 16)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(176, 20)
        Me.txtDescripcion.TabIndex = 3
        Me.txtDescripcion.Visible = False
        '
        'grdListaDetallesProd
        '
        Appearance1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaDetallesProd.DisplayLayout.Appearance = Appearance1
        Me.grdListaDetallesProd.DisplayLayout.GroupByBox.Hidden = True
        Me.grdListaDetallesProd.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
        Me.grdListaDetallesProd.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
        Me.grdListaDetallesProd.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdListaDetallesProd.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
        Appearance2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdListaDetallesProd.DisplayLayout.Override.RowAlternateAppearance = Appearance2
        Appearance3.BorderColor = System.Drawing.Color.DarkGray
        Me.grdListaDetallesProd.DisplayLayout.Override.RowAppearance = Appearance3
        Me.grdListaDetallesProd.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.grdListaDetallesProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdListaDetallesProd.Location = New System.Drawing.Point(0, 215)
        Me.grdListaDetallesProd.Name = "grdListaDetallesProd"
        Me.grdListaDetallesProd.Size = New System.Drawing.Size(1047, 307)
        Me.grdListaDetallesProd.TabIndex = 4
        '
        'pctTitulo
        '
        Me.pctTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pctTitulo.Image = Global.Programacion.Vista.My.Resources.Resources.logoYuyin
        Me.pctTitulo.Location = New System.Drawing.Point(228, 0)
        Me.pctTitulo.Name = "pctTitulo"
        Me.pctTitulo.Size = New System.Drawing.Size(68, 60)
        Me.pctTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pctTitulo.TabIndex = 2
        Me.pctTitulo.TabStop = False
        '
        'ListaDetalleProductoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1047, 582)
        Me.Controls.Add(Me.grdListaDetallesProd)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.pnlEstado)
        Me.Controls.Add(Me.pnlHeader)
        Me.Name = "ListaDetalleProductoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Artículos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlSalir.ResumeLayout(False)
        Me.pnlSalir.PerformLayout()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        Me.gprFoto.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDibujo.ResumeLayout(False)
        CType(Me.picDibujo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListaDetallesProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents txtColeccion As System.Windows.Forms.TextBox
    Friend WithEvents lblColeccion As System.Windows.Forms.Label
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents txtTemporada As System.Windows.Forms.TextBox
    Friend WithEvents lblTemporada As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents txtSubfamilia As System.Windows.Forms.TextBox
    Friend WithEvents lblSubfamilia As System.Windows.Forms.Label
    Friend WithEvents picDibujo As System.Windows.Forms.PictureBox
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents gprFoto As System.Windows.Forms.GroupBox
    Friend WithEvents grpDibujo As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSalir As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblCodigoNombre As System.Windows.Forms.Label
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblMarcaNombre As System.Windows.Forms.Label
    Friend WithEvents lblTemporadaNombre As System.Windows.Forms.Label
    Friend WithEvents lblSubfamiliaNombre As System.Windows.Forms.Label
    Friend WithEvents lblColeccionNombre As System.Windows.Forms.Label
    Friend WithEvents lbldescripcionNombre As System.Windows.Forms.Label
    Friend WithEvents grdListaDetallesProd As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents lblCategoriaNombre As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents btnCargarImagenesMultiple As System.Windows.Forms.Button
    Friend WithEvents lblSeleccionImagenMultiple As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblClientePropietario As System.Windows.Forms.Label
    Friend WithEvents btnLogoMarcaMultiple As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pctTitulo As PictureBox
End Class
