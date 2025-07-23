<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PermisosFrameWorkForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PermisosFrameWorkForm))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.pnlOperaciones = New System.Windows.Forms.Panel()
        Me.lblReplicaPermisos = New System.Windows.Forms.Label()
        Me.bntReplicarPermisos = New System.Windows.Forms.Button()
        Me.lblAltaUsuario = New System.Windows.Forms.Label()
        Me.lblPermisoEspecial = New System.Windows.Forms.Label()
        Me.btnAltaUsuario = New System.Windows.Forms.Button()
        Me.btnPermisoEspecial = New System.Windows.Forms.Button()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.lblPermisos = New System.Windows.Forms.Label()
        Me.lblAltasPerfiles = New System.Windows.Forms.Label()
        Me.lblAltasModulo = New System.Windows.Forms.Label()
        Me.pnlContenedor = New System.Windows.Forms.Panel()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.pnlArbolModulos = New System.Windows.Forms.Panel()
        Me.ArbolModulos = New System.Windows.Forms.TreeView()
        Me.pnlArbolUsuarios = New System.Windows.Forms.Panel()
        Me.ArbolUsuarios = New System.Windows.Forms.TreeView()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.gprPerfilesDatos = New System.Windows.Forms.GroupBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.rdoInactivo = New System.Windows.Forms.RadioButton()
        Me.rdoActivo = New System.Windows.Forms.RadioButton()
        Me.btnAgregaPerfil = New System.Windows.Forms.Button()
        Me.lblPerfil = New System.Windows.Forms.Label()
        Me.txtPerfilNuevo = New System.Windows.Forms.TextBox()
        Me.gprDatosModulo = New System.Windows.Forms.GroupBox()
        Me.lblActualizarModulos = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnAltaModulo = New System.Windows.Forms.Button()
        Me.lblALtaModulo = New System.Windows.Forms.Label()
        Me.btnEditarModulo = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlOperaciones.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.pnlContenedor.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.pnlArbolModulos.SuspendLayout()
        Me.pnlArbolUsuarios.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.gprPerfilesDatos.SuspendLayout()
        Me.gprDatosModulo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(894, 60)
        Me.pnlHeader.TabIndex = 0
        '
        'pnlOperaciones
        '
        Me.pnlOperaciones.Controls.Add(Me.lblReplicaPermisos)
        Me.pnlOperaciones.Controls.Add(Me.bntReplicarPermisos)
        Me.pnlOperaciones.Controls.Add(Me.lblAltaUsuario)
        Me.pnlOperaciones.Controls.Add(Me.lblPermisoEspecial)
        Me.pnlOperaciones.Controls.Add(Me.btnAltaUsuario)
        Me.pnlOperaciones.Controls.Add(Me.btnPermisoEspecial)
        Me.pnlOperaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlOperaciones.Name = "pnlOperaciones"
        Me.pnlOperaciones.Size = New System.Drawing.Size(329, 60)
        Me.pnlOperaciones.TabIndex = 1
        '
        'lblReplicaPermisos
        '
        Me.lblReplicaPermisos.AutoSize = True
        Me.lblReplicaPermisos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblReplicaPermisos.Location = New System.Drawing.Point(178, 41)
        Me.lblReplicaPermisos.Name = "lblReplicaPermisos"
        Me.lblReplicaPermisos.Size = New System.Drawing.Size(88, 13)
        Me.lblReplicaPermisos.TabIndex = 5
        Me.lblReplicaPermisos.Text = "Replica Permisos"
        '
        'bntReplicarPermisos
        '
        Me.bntReplicarPermisos.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.seguridad_32
        Me.bntReplicarPermisos.Location = New System.Drawing.Point(202, 7)
        Me.bntReplicarPermisos.Name = "bntReplicarPermisos"
        Me.bntReplicarPermisos.Size = New System.Drawing.Size(32, 32)
        Me.bntReplicarPermisos.TabIndex = 4
        Me.bntReplicarPermisos.UseVisualStyleBackColor = True
        '
        'lblAltaUsuario
        '
        Me.lblAltaUsuario.AutoSize = True
        Me.lblAltaUsuario.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltaUsuario.Location = New System.Drawing.Point(103, 41)
        Me.lblAltaUsuario.Name = "lblAltaUsuario"
        Me.lblAltaUsuario.Size = New System.Drawing.Size(64, 13)
        Me.lblAltaUsuario.TabIndex = 3
        Me.lblAltaUsuario.Text = "Alta Usuario"
        '
        'lblPermisoEspecial
        '
        Me.lblPermisoEspecial.AutoSize = True
        Me.lblPermisoEspecial.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblPermisoEspecial.Location = New System.Drawing.Point(13, 41)
        Me.lblPermisoEspecial.Name = "lblPermisoEspecial"
        Me.lblPermisoEspecial.Size = New System.Drawing.Size(86, 13)
        Me.lblPermisoEspecial.TabIndex = 2
        Me.lblPermisoEspecial.Text = "Permiso especial"
        '
        'btnAltaUsuario
        '
        Me.btnAltaUsuario.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.colaboradores_32
        Me.btnAltaUsuario.Location = New System.Drawing.Point(119, 7)
        Me.btnAltaUsuario.Name = "btnAltaUsuario"
        Me.btnAltaUsuario.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaUsuario.TabIndex = 2
        Me.btnAltaUsuario.UseVisualStyleBackColor = True
        '
        'btnPermisoEspecial
        '
        Me.btnPermisoEspecial.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_321
        Me.btnPermisoEspecial.Location = New System.Drawing.Point(40, 7)
        Me.btnPermisoEspecial.Name = "btnPermisoEspecial"
        Me.btnPermisoEspecial.Size = New System.Drawing.Size(32, 32)
        Me.btnPermisoEspecial.TabIndex = 2
        Me.btnPermisoEspecial.UseVisualStyleBackColor = True
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.lblPermisos)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTitulo.Location = New System.Drawing.Point(710, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(184, 60)
        Me.pnlTitulo.TabIndex = 0
        '
        'lblPermisos
        '
        Me.lblPermisos.AutoSize = True
        Me.lblPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermisos.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPermisos.Location = New System.Drawing.Point(31, 22)
        Me.lblPermisos.Name = "lblPermisos"
        Me.lblPermisos.Size = New System.Drawing.Size(82, 20)
        Me.lblPermisos.TabIndex = 1
        Me.lblPermisos.Text = "Permisos"
        '
        'lblAltasPerfiles
        '
        Me.lblAltasPerfiles.AutoSize = True
        Me.lblAltasPerfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltasPerfiles.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltasPerfiles.Location = New System.Drawing.Point(372, 46)
        Me.lblAltasPerfiles.Name = "lblAltasPerfiles"
        Me.lblAltasPerfiles.Size = New System.Drawing.Size(67, 13)
        Me.lblAltasPerfiles.TabIndex = 4
        Me.lblAltasPerfiles.Text = "Altas Perfiles"
        '
        'lblAltasModulo
        '
        Me.lblAltasModulo.AutoSize = True
        Me.lblAltasModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltasModulo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblAltasModulo.Location = New System.Drawing.Point(360, 47)
        Me.lblAltasModulo.Name = "lblAltasModulo"
        Me.lblAltasModulo.Size = New System.Drawing.Size(71, 13)
        Me.lblAltasModulo.TabIndex = 3
        Me.lblAltasModulo.Text = "Editar módulo"
        '
        'pnlContenedor
        '
        Me.pnlContenedor.BackColor = System.Drawing.Color.White
        Me.pnlContenedor.Controls.Add(Me.pnlAcciones)
        Me.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlContenedor.Location = New System.Drawing.Point(0, 568)
        Me.pnlContenedor.Name = "pnlContenedor"
        Me.pnlContenedor.Size = New System.Drawing.Size(894, 60)
        Me.pnlContenedor.TabIndex = 1
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.lblCancelar)
        Me.pnlAcciones.Controls.Add(Me.btnGuardar)
        Me.pnlAcciones.Controls.Add(Me.btnCancelar)
        Me.pnlAcciones.Controls.Add(Me.lblGuardar)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(730, 0)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(164, 60)
        Me.pnlAcciones.TabIndex = 0
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblCancelar.Location = New System.Drawing.Point(97, 40)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(35, 13)
        Me.lblCancelar.TabIndex = 2
        Me.lblCancelar.Text = "Cerrar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.guardar2_32
        Me.btnGuardar.Location = New System.Drawing.Point(42, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(32, 32)
        Me.btnGuardar.TabIndex = 3
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.salir_32
        Me.btnCancelar.Location = New System.Drawing.Point(98, 6)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(32, 32)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblGuardar.Location = New System.Drawing.Point(37, 40)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(45, 13)
        Me.lblGuardar.TabIndex = 2
        Me.lblGuardar.Text = "Guardar"
        '
        'pnlArbolModulos
        '
        Me.pnlArbolModulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlArbolModulos.Controls.Add(Me.ArbolModulos)
        Me.pnlArbolModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlArbolModulos.Location = New System.Drawing.Point(443, 121)
        Me.pnlArbolModulos.Name = "pnlArbolModulos"
        Me.pnlArbolModulos.Size = New System.Drawing.Size(451, 447)
        Me.pnlArbolModulos.TabIndex = 2
        '
        'ArbolModulos
        '
        Me.ArbolModulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ArbolModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArbolModulos.Location = New System.Drawing.Point(0, 0)
        Me.ArbolModulos.Name = "ArbolModulos"
        Me.ArbolModulos.Size = New System.Drawing.Size(449, 445)
        Me.ArbolModulos.TabIndex = 0
        '
        'pnlArbolUsuarios
        '
        Me.pnlArbolUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlArbolUsuarios.Controls.Add(Me.ArbolUsuarios)
        Me.pnlArbolUsuarios.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlArbolUsuarios.Location = New System.Drawing.Point(0, 121)
        Me.pnlArbolUsuarios.Name = "pnlArbolUsuarios"
        Me.pnlArbolUsuarios.Size = New System.Drawing.Size(443, 447)
        Me.pnlArbolUsuarios.TabIndex = 3
        '
        'ArbolUsuarios
        '
        Me.ArbolUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ArbolUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArbolUsuarios.Location = New System.Drawing.Point(0, 0)
        Me.ArbolUsuarios.Name = "ArbolUsuarios"
        Me.ArbolUsuarios.Size = New System.Drawing.Size(441, 445)
        Me.ArbolUsuarios.TabIndex = 0
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.gprPerfilesDatos)
        Me.pnlDatos.Controls.Add(Me.gprDatosModulo)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.Location = New System.Drawing.Point(0, 60)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(894, 61)
        Me.pnlDatos.TabIndex = 4
        '
        'gprPerfilesDatos
        '
        Me.gprPerfilesDatos.Controls.Add(Me.lblActivo)
        Me.gprPerfilesDatos.Controls.Add(Me.rdoInactivo)
        Me.gprPerfilesDatos.Controls.Add(Me.lblAltasPerfiles)
        Me.gprPerfilesDatos.Controls.Add(Me.rdoActivo)
        Me.gprPerfilesDatos.Controls.Add(Me.btnAgregaPerfil)
        Me.gprPerfilesDatos.Controls.Add(Me.lblPerfil)
        Me.gprPerfilesDatos.Controls.Add(Me.txtPerfilNuevo)
        Me.gprPerfilesDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.gprPerfilesDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gprPerfilesDatos.Location = New System.Drawing.Point(0, 0)
        Me.gprPerfilesDatos.Name = "gprPerfilesDatos"
        Me.gprPerfilesDatos.Size = New System.Drawing.Size(444, 61)
        Me.gprPerfilesDatos.TabIndex = 0
        Me.gprPerfilesDatos.TabStop = False
        Me.gprPerfilesDatos.Text = "Perfiles"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.Location = New System.Drawing.Point(229, 31)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 9
        Me.lblActivo.Text = "Activo"
        '
        'rdoInactivo
        '
        Me.rdoInactivo.AutoSize = True
        Me.rdoInactivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoInactivo.Location = New System.Drawing.Point(316, 29)
        Me.rdoInactivo.Name = "rdoInactivo"
        Me.rdoInactivo.Size = New System.Drawing.Size(39, 17)
        Me.rdoInactivo.TabIndex = 8
        Me.rdoInactivo.TabStop = True
        Me.rdoInactivo.Text = "No"
        Me.rdoInactivo.UseVisualStyleBackColor = True
        '
        'rdoActivo
        '
        Me.rdoActivo.AutoSize = True
        Me.rdoActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoActivo.Location = New System.Drawing.Point(274, 29)
        Me.rdoActivo.Name = "rdoActivo"
        Me.rdoActivo.Size = New System.Drawing.Size(34, 17)
        Me.rdoActivo.TabIndex = 7
        Me.rdoActivo.TabStop = True
        Me.rdoActivo.Text = "Si"
        Me.rdoActivo.UseVisualStyleBackColor = True
        '
        'btnAgregaPerfil
        '
        Me.btnAgregaPerfil.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.perfiles_32
        Me.btnAgregaPerfil.Location = New System.Drawing.Point(389, 12)
        Me.btnAgregaPerfil.Name = "btnAgregaPerfil"
        Me.btnAgregaPerfil.Size = New System.Drawing.Size(32, 32)
        Me.btnAgregaPerfil.TabIndex = 3
        Me.btnAgregaPerfil.UseVisualStyleBackColor = True
        '
        'lblPerfil
        '
        Me.lblPerfil.AutoSize = True
        Me.lblPerfil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPerfil.Location = New System.Drawing.Point(5, 31)
        Me.lblPerfil.Name = "lblPerfil"
        Me.lblPerfil.Size = New System.Drawing.Size(65, 13)
        Me.lblPerfil.TabIndex = 5
        Me.lblPerfil.Text = "Nuevo Perfil"
        '
        'txtPerfilNuevo
        '
        Me.txtPerfilNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerfilNuevo.Location = New System.Drawing.Point(76, 27)
        Me.txtPerfilNuevo.Name = "txtPerfilNuevo"
        Me.txtPerfilNuevo.Size = New System.Drawing.Size(136, 20)
        Me.txtPerfilNuevo.TabIndex = 2
        '
        'gprDatosModulo
        '
        Me.gprDatosModulo.Controls.Add(Me.lblActualizarModulos)
        Me.gprDatosModulo.Controls.Add(Me.btnActualizar)
        Me.gprDatosModulo.Controls.Add(Me.btnAltaModulo)
        Me.gprDatosModulo.Controls.Add(Me.lblALtaModulo)
        Me.gprDatosModulo.Controls.Add(Me.btnEditarModulo)
        Me.gprDatosModulo.Controls.Add(Me.lblAltasModulo)
        Me.gprDatosModulo.Dock = System.Windows.Forms.DockStyle.Right
        Me.gprDatosModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gprDatosModulo.Location = New System.Drawing.Point(455, 0)
        Me.gprDatosModulo.Name = "gprDatosModulo"
        Me.gprDatosModulo.Size = New System.Drawing.Size(439, 61)
        Me.gprDatosModulo.TabIndex = 2
        Me.gprDatosModulo.TabStop = False
        Me.gprDatosModulo.Text = "Modulos"
        '
        'lblActualizarModulos
        '
        Me.lblActualizarModulos.AutoSize = True
        Me.lblActualizarModulos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualizarModulos.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblActualizarModulos.Location = New System.Drawing.Point(221, 46)
        Me.lblActualizarModulos.Name = "lblActualizarModulos"
        Me.lblActualizarModulos.Size = New System.Drawing.Size(53, 13)
        Me.lblActualizarModulos.TabIndex = 7
        Me.lblActualizarModulos.Text = "Actualizar"
        '
        'btnActualizar
        '
        Me.btnActualizar.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.incentivos_32
        Me.btnActualizar.Location = New System.Drawing.Point(231, 12)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(32, 32)
        Me.btnActualizar.TabIndex = 6
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnAltaModulo
        '
        Me.btnAltaModulo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.altas_32
        Me.btnAltaModulo.Location = New System.Drawing.Point(305, 12)
        Me.btnAltaModulo.Name = "btnAltaModulo"
        Me.btnAltaModulo.Size = New System.Drawing.Size(32, 32)
        Me.btnAltaModulo.TabIndex = 4
        Me.btnAltaModulo.UseVisualStyleBackColor = True
        '
        'lblALtaModulo
        '
        Me.lblALtaModulo.AutoSize = True
        Me.lblALtaModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblALtaModulo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lblALtaModulo.Location = New System.Drawing.Point(285, 47)
        Me.lblALtaModulo.Name = "lblALtaModulo"
        Me.lblALtaModulo.Size = New System.Drawing.Size(72, 13)
        Me.lblALtaModulo.TabIndex = 5
        Me.lblALtaModulo.Text = "Altas módulos"
        '
        'btnEditarModulo
        '
        Me.btnEditarModulo.Image = Global.Framework.Vista.SAPY.My.Resources.Resources.editar_32
        Me.btnEditarModulo.Location = New System.Drawing.Point(379, 12)
        Me.btnEditarModulo.Name = "btnEditarModulo"
        Me.btnEditarModulo.Size = New System.Drawing.Size(32, 32)
        Me.btnEditarModulo.TabIndex = 1
        Me.btnEditarModulo.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(116, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(68, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 48
        Me.PictureBox1.TabStop = False
        '
        'PermisosFrameWorkForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(894, 628)
        Me.Controls.Add(Me.pnlArbolModulos)
        Me.Controls.Add(Me.pnlArbolUsuarios)
        Me.Controls.Add(Me.pnlContenedor)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(900, 650)
        Me.MinimumSize = New System.Drawing.Size(900, 650)
        Me.Name = "PermisosFrameWorkForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Permisos"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlOperaciones.ResumeLayout(False)
        Me.pnlOperaciones.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        Me.pnlContenedor.ResumeLayout(False)
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlArbolModulos.ResumeLayout(False)
        Me.pnlArbolUsuarios.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.gprPerfilesDatos.ResumeLayout(False)
        Me.gprPerfilesDatos.PerformLayout()
        Me.gprDatosModulo.ResumeLayout(False)
        Me.gprDatosModulo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedor As System.Windows.Forms.Panel
    Friend WithEvents pnlArbolModulos As System.Windows.Forms.Panel
    Friend WithEvents ArbolModulos As System.Windows.Forms.TreeView
    Friend WithEvents pnlArbolUsuarios As System.Windows.Forms.Panel
    Friend WithEvents ArbolUsuarios As System.Windows.Forms.TreeView
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents lblPermisos As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents pnlOperaciones As System.Windows.Forms.Panel
    Friend WithEvents lblPermisoEspecial As System.Windows.Forms.Label
    Friend WithEvents btnPermisoEspecial As System.Windows.Forms.Button
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents gprDatosModulo As System.Windows.Forms.GroupBox
    Friend WithEvents gprPerfilesDatos As System.Windows.Forms.GroupBox
    Friend WithEvents txtPerfilNuevo As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregaPerfil As System.Windows.Forms.Button
    Friend WithEvents lblPerfil As System.Windows.Forms.Label
    Friend WithEvents lblAltasPerfiles As System.Windows.Forms.Label
    Friend WithEvents lblAltasModulo As System.Windows.Forms.Label
    Friend WithEvents btnAltaModulo As System.Windows.Forms.Button
    Friend WithEvents lblALtaModulo As System.Windows.Forms.Label
    Friend WithEvents btnEditarModulo As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents rdoInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents lblAltaUsuario As System.Windows.Forms.Label
    Friend WithEvents btnAltaUsuario As System.Windows.Forms.Button
    Friend WithEvents lblActualizarModulos As System.Windows.Forms.Label
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblReplicaPermisos As Label
    Friend WithEvents bntReplicarPermisos As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
