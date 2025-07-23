Imports System.Net
Imports System.Drawing
Imports System.Windows.Forms
Imports Tools


Public Class AltaIncapacidadesForm
    Dim ColaboradorID As Integer = 0
    Dim NaveID As Integer = 0
    Dim EstaMal As Boolean = False
    Dim ValidarIncapacidadExistene As Boolean = False
    Dim rutaArchivo As String = String.Empty
    Dim listaArchivo As New List(Of Entidades.AcusesIncapacidades)
    Dim directorio As String = String.Empty
    Public Const rutaAcuses As String = "IMAGENES/"
    'Public Const rutaFTP As String = "FTP://192.168.7.16/"
    'Public Const rutaFTP As String = Tools
    'Public Const ftpUsuario As String = "prod\yuyinerp"
    'Public Const ftpContrasena As String = "yuyinerp"
    Dim perfilContabilidad As Boolean = False
    Dim validaArchivo As Boolean = False
    Dim diasNoCorresponde As Boolean = False

    Private Sub AltaIncapacidadesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)
        llenarComboRamoDelSeguro()
        llenarComboTipoRiesgo()

        llenarComboSecuelaOconsecuencia()
        llenarcombotipoMaternidad()

        limpiar()
    End Sub

    Private Sub configuracionPerfil()
        Try
            Dim objBU As New Negocios.IncapacidadesBU
            perfilContabilidad = objBU.validarPerfilContabilidad()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AltaIncapacidadesForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        configuracionPerfil()
        If perfilContabilidad Then
            abrirPantallaBuscarColaborador()
            If ColaboradorID > 0 Then
                LlenarDatosColaborador()
                txtFolio.Enabled = True
                txtDescripcion.Enabled = True
                dtpFechaInicio.Enabled = True
                '  dtpFechaFinal.Enabled = True
                NupDiasAutorizados.Enabled = True
                cmbRamoDelSeguro.Enabled = True
                lblColaborador.ForeColor = Color.Black
                lblEdad.ForeColor = Color.Black
                lblNave.ForeColor = Color.Black
                lblDepartamento.ForeColor = Color.Black
                lblPuesto.ForeColor = Color.Black
            End If

        Else
            Dim empleadosForm As New Nomina.Vista.BuscarEmpleadoForm


            'empleadosForm.grdBuscarEmpleado.Rows.Clear()
            txtFolio.Focus()

            If empleadosForm.ShowDialog = DialogResult.OK Then
                ColaboradorID = empleadosForm.pseleccion

                If ColaboradorID > 0 Then
                    LlenarDatosColaborador()
                    txtFolio.Enabled = True
                    txtDescripcion.Enabled = True
                    dtpFechaInicio.Enabled = True
                    ' dtpFechaFinal.Enabled = True
                    NupDiasAutorizados.Enabled = True
                    cmbRamoDelSeguro.Enabled = True
                    lblColaborador.ForeColor = Color.Black
                    lblEdad.ForeColor = Color.Black
                    lblNave.ForeColor = Color.Black
                    lblDepartamento.ForeColor = Color.Black
                    lblPuesto.ForeColor = Color.Black
                End If
            End If
        End If


    End Sub

    Private Sub abrirPantallaBuscarColaborador()
        Dim objForm As New Contabilidad.Vista.BuscarColaboradorForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New Contabilidad.Vista.BuscarColaboradorForm
            formaAltas.externo = 2
            formaAltas.ShowDialog()

            ColaboradorID = formaAltas.idColaborador
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Sub LlenarDatosColaborador()

        Dim FechaActual As Date = DateTime.Now().ToShortDateString()
        Dim anios As Int32 = 0
        Dim meses As Int32 = 0
        Dim dias As Int32 = 0
        Dim diasme As Int32 = 0
        Dim DiasDeVida As Integer

        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.IncapacidadesBU
        Dim objFTP As New Tools.TransferenciaFTP

        EntidadArchivos = ObjArchivosBU.CredencialColaborador(ColaboradorID)
        Try
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            Dim Carpeta As String = ""

            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next

            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
            pbColaborador.Image = Image.FromStream(Stream)
        Catch ex As Exception
        End Try

        Try
            ''LLENADO DE DATOS PERSONALES
            Dim DatosPersonales As New Entidades.Colaborador
            Dim DatosPersonalesBU As New Negocios.IncapacidadesBU

            DatosPersonales = DatosPersonalesBU.BuscarColaboradorGeneral(ColaboradorID)
            lblColaborador2.Text = DatosPersonales.PNombre + " " + DatosPersonales.PApaterno + " " + DatosPersonales.PAmaterno

            ''Llenado de EDAD
            Dim FechaNacimiento As Date = DatosPersonales.PFechaNacimiento
            DiasDeVida = (FechaActual - FechaNacimiento).TotalDays
            anios = DiasDeVida \ 365
            meses = (DiasDeVida - (365 * Fix(DiasDeVida / 365)))
            meses = Fix(meses / 30.4)
            diasme = (DiasDeVida Mod 365) Mod 30.4
            lblEdad2.Text = UCase(anios.ToString + " años ")

            ''LLENADO DE DATOS LABORALES
            Dim DatosLaborales As New Entidades.ColaboradorLaboral
            Dim DatosLaboralesBU As New Negocios.IncapacidadesBU

            DatosLaborales = DatosLaboralesBU.buscarInformacionLaboral(ColaboradorID)
            lblPuesto2.Text = DatosLaborales.PPuestoId.PNombre
            lblDepartamento2.Text = DatosLaborales.PDepartamentoId.DNombre
            lblNave2.Text = UCase(DatosLaborales.PNaveId.PNombre)
            NaveID = DatosLaborales.PNaveId.PNaveId

            ''cargar incapacidades anteriores
            llenarComboIncapacidadesAnteriores()

        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No seleccionó ningún colaborador."
            mensajeError.Show()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ValidarCampos()

        If EstaMal = False Then
            If validaIncapacidadInicial() And (cmbControlIncapacidad.SelectedValue = 1 Or cmbControlIncapacidad.SelectedValue = 2) Then
                'Esta validacion ya no se hace petición de lula en junta el día 28/09/2017
                Dim advetencia As New AdvertenciaForm
                advetencia.mensaje = "No es posible capturar la incapacidad como " + cmbControlIncapacidad.Text + " debido a que el colaborador ya cuenta con una incapacidad pendiente (INICIAL)"
                advetencia.ShowDialog()
            Else
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "¿Estas seguro de querer dar de alta la incapacidad? "
                If mensajeExito.ShowDialog = DialogResult.OK Then
                    Guardar()
                End If
            End If

        Else
            Dim advetencia As New AdvertenciaForm
            If validaArchivo Then
                advetencia.mensaje = "Es obligatorio adjuntar la carta de incapacidad"
            ElseIf diasNoCorresponde Then
                advetencia.mensaje = "Los dias autorizados no corresponden con la diferencia de días entre las fechas capturadas"
            Else
                advetencia.mensaje = "Faltan datos por completar. Verifique la información"
            End If
            advetencia.ShowDialog()

        End If
    End Sub


    Public Sub Guardar()
        ValidarIncapacidad(ColaboradorID, dtpFechaInicio.Value, dtpFechaFinal.Value)

        If ValidarIncapacidadExistene = False Then

            Dim objBU As New Negocios.IncapacidadesBU
            Dim ObjEnt As New Entidades.Incapacidades
            Dim Colaborador As New Entidades.Colaborador

            Colaborador.PColaboradorid = ColaboradorID
            ObjEnt.PIncapacidadFolio = txtFolio.Text
            ObjEnt.PIncapacidadFechaInicio = dtpFechaInicio.Value
            ObjEnt.PIncapacidadFechaFin = dtpFechaFinal.Value
            ObjEnt.PIncapacidadDiasAutorizados = NupDiasAutorizados.Value

            ObjEnt.PRamoSeguroID = cmbRamoDelSeguro.SelectedValue

            If cmbTipoDeRiesgo.Text <> "" Then
                ObjEnt.PTipoRiesgoID = cmbTipoDeRiesgo.SelectedValue
            End If

            If cmbControlIncapacidad.Text <> "" Then
                ObjEnt.PControlIncapacidadID = cmbControlIncapacidad.SelectedValue
            End If

            If cmbSecuelaOConsecuencia.Text <> "" Then
                ObjEnt.PSecuelaID = cmbSecuelaOConsecuencia.SelectedValue
            End If

            If cmbTipoMaternidad.Text <> "" Then
                ObjEnt.PTipoMaternidadID = cmbTipoMaternidad.SelectedValue
            End If

            ObjEnt.PIncapacidadDescripcion = txtDescripcion.Text
            ObjEnt.PFechaCreacion = Today.Date
            ObjEnt.PUsuarioCreacion = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjEnt.PIncapacidadAnteirorId = cmbIncapacidadAnterior.SelectedValue

            If listaArchivo.Exists(Function(c) c.PTipo = "Carta de Incapacidad") Then
                ObjEnt.PCartaIncapacidad = True
            End If

            If listaArchivo.Exists(Function(c) c.PTipo = "formatost7") Then
                ObjEnt.PFormatost7 = True
            End If

            If listaArchivo.Exists(Function(c) c.PTipo = "formatost2") Then
                ObjEnt.PFormatoSt2 = True
            End If

            ObjEnt.PAceptadoRT = chkRiesgoTrabajo.Checked
            ObjEnt.PColaborador = Colaborador

            ''Guardar mandando mensaje
            Try
                Dim dtGuardar As New DataTable
                dtGuardar = objBU.AltaIncapacidad(ObjEnt)

                If dtGuardar.Rows.Count > 0 Then
                    Dim idIncapacidad As Int32 = 0
                    If dtGuardar.Rows(0).Item("resul") = "EXITO" Then
                        idIncapacidad = dtGuardar.Rows(0).Item("IdIncapacidad")

                        If subirArchivos(idIncapacidad) Then
                            Dim mensajeExito As New ExitoForm
                            mensajeExito.MdiParent = Me.MdiParent
                            mensajeExito.mensaje = "La incapacidad se ha registrado correctamente."
                            mensajeExito.Show()
                            limpiar()
                        Else
                            Dim mensajeAdvertencia As New AdvertenciaForm
                            mensajeAdvertencia.MdiParent = Me.MdiParent
                            mensajeAdvertencia.mensaje = "Algo surgió mal al subir los acuses de la incapacidad, por favor adjunte los archivos nuevamente editando la incapacidad"
                            mensajeAdvertencia.Show()
                            limpiar()
                        End If

                    End If

                End If

            Catch ex As Exception
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.MdiParent = Me.MdiParent
                mensajeAdvertencia.mensaje = "Algo surgió mal al dar de alta la incapacidad"
                mensajeAdvertencia.Show()
            End Try
            'Else
            '    Dim mensajeAviso As New AvisoForm
            '    mensajeAviso.MdiParent = Me.MdiParent
            '    mensajeAviso.mensaje = "Ya existe una incapacidad entre ese rango de fechas."
            '    mensajeAviso.Show()
            '    lblFechaInicio.ForeColor = Color.Red
            '    lblFechafinal.ForeColor = Color.Red
        End If
    End Sub

    Public Function subirArchivos(ByVal idIncapacidad As Int32) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty
            Dim bandera As Boolean = True
            Dim resul As String = String.Empty
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & ColaboradorID

            For Each archivo As Entidades.AcusesIncapacidades In listaArchivo
                If archivo.PRutaArchivo <> "" Then
                    objFTP.EnviarArchivo(archivo.PCarpetaArchivo, archivo.PRutaArchivo)
                    rutaArchivo = objFTP.obtenerURL & "/" & archivo.PCarpetaArchivo & "/" & archivo.PNombreArchivo
                    Dim tituloMovimiento As String = String.Empty
                    If objFTP.FtpExisteArchivo(rutaArchivo) Then
                        ''aqui actualizar expediente
                        Dim objBu As New Negocios.IncapacidadesBU
                        tituloMovimiento = "INCAPACIDADES (" + archivo.PTipo.ToUpper + ")"
                        resul = objBu.actualizarExpediente(ColaboradorID, idIncapacidad, 0, tituloMovimiento, archivo.PCarpetaArchivo, archivo.PNombreArchivo)

                    Else
                        bandera = False
                    End If
                Else
                    bandera = False
                End If
            Next
            If bandera = True Then
                If resul = "EXITO" Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If


        Catch
            Return False
        End Try
    End Function

    Public Sub llenarComboRamoDelSeguro()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim RamoSeguro As New DataTable
        RamoSeguro = objBU.RamoDelSeguro()
        RamoSeguro.Rows.InsertAt(RamoSeguro.NewRow, 0)
        With cmbRamoDelSeguro
            .DisplayMember = "ramo_descripcion"
            .ValueMember = "ramo_ramoseguroid"
            .DataSource = RamoSeguro
        End With
    End Sub

    Public Sub llenarComboIncapacidadesAnteriores()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim dtAnt As New DataTable
        dtAnt = objBU.consultaIncapacidadesAnteriores(ColaboradorID, 0)

        If dtAnt.Rows.Count > 0 Then
            With cmbIncapacidadAnterior
                .DisplayMember = "descripcion"
                .ValueMember = "idIncapacidad"
                .DataSource = dtAnt
            End With
        End If

    End Sub

    Public Sub llenarComboTipoRiesgo()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim TipoRiesgo As New DataTable
        TipoRiesgo = objBU.TipoRiesgo()
        TipoRiesgo.Rows.InsertAt(TipoRiesgo.NewRow, 0)
        With cmbTipoDeRiesgo
            .DisplayMember = "trin_descripcion"
            .ValueMember = "trin_tiporiesgo"
            .DataSource = TipoRiesgo
        End With
    End Sub

    Public Sub llenarcomboControlIncapacidad()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim ControlIncapacidad As New DataTable
        If cmbRamoDelSeguro.SelectedIndex <> 0 Then
            ControlIncapacidad = objBU.ControlIncapacidad(cmbRamoDelSeguro.SelectedValue)
            ControlIncapacidad.Rows.InsertAt(ControlIncapacidad.NewRow, 0)
            With cmbControlIncapacidad
                .DisplayMember = "inco_descripcion"
                .ValueMember = "inco_controlincapacidadid"
                .DataSource = ControlIncapacidad
            End With
        End If

    End Sub

    Public Sub llenarComboSecuelaOconsecuencia()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim SecuelaOconsecuencia As New DataTable
        SecuelaOconsecuencia = objBU.SecuelaOconsecuencia()
        SecuelaOconsecuencia.Rows.InsertAt(SecuelaOconsecuencia.NewRow, 0)
        With cmbSecuelaOConsecuencia
            .DisplayMember = "inse_descripcion"
            .ValueMember = "inse_secuelaid"
            .DataSource = SecuelaOconsecuencia
        End With
    End Sub

    Public Sub llenarcombotipoMaternidad()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim TipoMaternidad As New DataTable
        TipoMaternidad = objBU.TipoMaternidad()
        TipoMaternidad.Rows.InsertAt(TipoMaternidad.NewRow, 0)
        With cmbTipoMaternidad
            .DisplayMember = "inma_descripcion"
            .ValueMember = "inma_maternidadid"
            .DataSource = TipoMaternidad
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub limpiar()
        lblColaborador2.Text = "Colaborador"
        lblEdad2.Text = "Edad"
        lblNave2.Text = "Nave"
        lblDepartamento2.Text = "Departamento"
        lblPuesto2.Text = "Puesto"

        txtFolio.Text = ""
        txtDescripcion.Text = ""
        NupDiasAutorizados.Value = 0
        dtpFechaFinal.Value = Today.Date
        dtpFechaInicio.Value = Today.Date
        NupDiasAutorizados.Value = 0
        cmbRamoDelSeguro.SelectedIndex = 0
        'cmbControlIncapacidad.SelectedIndex = 0
        cmbSecuelaOConsecuencia.SelectedIndex = 0
        cmbTipoDeRiesgo.SelectedIndex = 0
        cmbTipoMaternidad.SelectedIndex = 0
        pbColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)

        txtFolio.Enabled = False
        txtDescripcion.Enabled = False
        dtpFechaInicio.Enabled = False
        ' dtpFechaFinal.Enabled = False
        NupDiasAutorizados.Enabled = False
        cmbRamoDelSeguro.Enabled = False
        cmbControlIncapacidad.Enabled = False
        cmbSecuelaOConsecuencia.Enabled = False
        cmbTipoDeRiesgo.Enabled = False
        cmbTipoMaternidad.Enabled = False

        lblColaborador.ForeColor = Color.Black
        lblEdad.ForeColor = Color.Black
        lblNave.ForeColor = Color.Black
        lblDepartamento.ForeColor = Color.Black
        lblPuesto.ForeColor = Color.Black

        lblFolio.ForeColor = Color.Black
        lblDiasAutorizados.ForeColor = Color.Black
        lblRamoDelSeguro.ForeColor = Color.Black
        lblTipoDeRiesgo.ForeColor = Color.Black
        lblControlDeIncapacidad.ForeColor = Color.Black
        lblSecuelaOConsecuencia.ForeColor = Color.Black
        lblTipoMaternidad.ForeColor = Color.Black
        lblDescripcion.ForeColor = Color.Black

        lblNombreArchivo.Text = ""
        rutaArchivo = ""
        lbListaArchivos.Items.Clear()
        listaArchivo.Clear()
        rdnActaIncapacidad.Checked = True
        cmbIncapacidadAnterior.DataSource = Nothing
    End Sub

    Private Sub cmbRamoDelSeguro_DropDownClosed(sender As Object, e As EventArgs) Handles cmbRamoDelSeguro.DropDownClosed
        Try

            If cmbRamoDelSeguro.SelectedValue = 1 Or cmbRamoDelSeguro.SelectedValue = 2 Or cmbRamoDelSeguro.SelectedValue = 3 Then
                cmbControlIncapacidad.Enabled = True
            Else
                cmbControlIncapacidad.Enabled = False
            End If

            If cmbRamoDelSeguro.SelectedValue = 1 Then
                cmbTipoDeRiesgo.Enabled = True
                cmbControlIncapacidad.Enabled = True
                cmbSecuelaOConsecuencia.Enabled = True
            Else
                'cmbControlIncapacidad.Enabled = False
                'cmbControlIncapacidad.SelectedIndex = 0

                cmbTipoDeRiesgo.Enabled = False
                cmbTipoDeRiesgo.SelectedIndex = 0

                cmbSecuelaOConsecuencia.Enabled = False
                cmbSecuelaOConsecuencia.SelectedIndex = 0
            End If
            ''

            ''
            'If cmbRamoDelSeguro.SelectedValue = 3 Then
            '    cmbTipoMaternidad.Enabled = True
            'Else
            '    cmbTipoMaternidad.Enabled = False
            '    cmbTipoMaternidad.SelectedIndex = 0
            'End If
            llenarcomboControlIncapacidad()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ValidarCampos()
        EstaMal = False
        validaArchivo = False
        diasNoCorresponde = False

        If ColaboradorID = 0 Then
            lblColaborador.ForeColor = Color.Red
            lblEdad.ForeColor = Color.Red
            lblNave.ForeColor = Color.Red
            lblDepartamento.ForeColor = Color.Red
            lblPuesto.ForeColor = Color.Red
            EstaMal = True
        Else
            lblColaborador.ForeColor = Color.Black
            lblEdad.ForeColor = Color.Black
            lblNave.ForeColor = Color.Black
            lblDepartamento.ForeColor = Color.Black
            lblPuesto.ForeColor = Color.Black
        End If
        ''

        If Trim(txtFolio.Text) = "" Then
            If NupDiasAutorizados.Value <> 0 Then
                lblFolio.ForeColor = Color.Red
                EstaMal = True
            End If

        Else
            lblFolio.ForeColor = Color.Black
        End If
        ''
        If dtpFechaInicio.Value > dtpFechaFinal.Value Then
            lblFechaInicio.ForeColor = Color.Red
            lblFechafinal.ForeColor = Color.Red
            EstaMal = True
        Else
            lblFechaInicio.ForeColor = Color.Black
            lblFechafinal.ForeColor = Color.Black
        End If
        ''
        'If NupDiasAutorizados.Value = 0 Then
        '    lblDiasAutorizados.ForeColor = Color.Red
        '    EstaMal = True
        'Else
        '    lblDiasAutorizados.ForeColor = Color.Black
        'End If
        ''
        If cmbRamoDelSeguro.SelectedIndex = 0 Then
            lblRamoDelSeguro.ForeColor = Color.Red
            EstaMal = True
        Else
            lblRamoDelSeguro.ForeColor = Color.Black
        End If
        ''
        If cmbRamoDelSeguro.Text = "RIESGO DE TRABAJO" And cmbTipoDeRiesgo.SelectedIndex = 0 Then
            lblTipoDeRiesgo.ForeColor = Color.Red
            EstaMal = True
        Else
            lblTipoDeRiesgo.ForeColor = Color.Black
        End If
        ''
        If (cmbRamoDelSeguro.Text = "RIESGO DE TRABAJO" And cmbControlIncapacidad.SelectedIndex <= 0) Or (cmbRamoDelSeguro.Text = "ENFERMEDAD GENERAL" And cmbControlIncapacidad.SelectedIndex = 0) Then
            lblControlDeIncapacidad.ForeColor = Color.Red
            EstaMal = True
        Else
            lblControlDeIncapacidad.ForeColor = Color.Black
        End If
        ''
        If cmbRamoDelSeguro.Text = "RIESGO DE TRABAJO" And cmbSecuelaOConsecuencia.SelectedIndex = 0 Then
            lblSecuelaOConsecuencia.ForeColor = Color.Red
            EstaMal = True
        Else
            lblSecuelaOConsecuencia.ForeColor = Color.Black
        End If
        ''
        If cmbRamoDelSeguro.Text = "MATERNIDAD" And cmbControlIncapacidad.SelectedIndex = 0 Then
            lblTipoMaternidad.ForeColor = Color.Red
            EstaMal = True
        Else
            lblTipoMaternidad.ForeColor = Color.Black
        End If
        ''
        If Trim(txtDescripcion.Text) = "" Then
            lblDescripcion.ForeColor = Color.Red
            EstaMal = True
        Else
            lblDescripcion.ForeColor = Color.Black
        End If

        ''valida carta de incapacidad
        If Not listaArchivo.Exists(Function(c) c.PTipo = "Carta de Incapacidad") Then
            EstaMal = True
            validaArchivo = True
        End If

        If NupDiasAutorizados.Value <> ((dtpFechaFinal.Value - dtpFechaInicio.Value).TotalDays + 1) Then
            If NupDiasAutorizados.Value <> 0 Then
                EstaMal = True
                diasNoCorresponde = True
            End If

        End If


    End Sub

    Private Sub ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjEnt As New Entidades.Incapacidades
        Dim diasAut As Int32 = 0
        ValidarIncapacidadExistene = False
        ObjEnt = ObjBU.ValidarIncapacidad(ColaboradorID, FechaInicio, FechaFin, 0)
        ValidarIncapacidadExistene = ObjEnt.PValidarIncapacidad

        If ValidarIncapacidadExistene = True Then
            Dim advertencia As New AdvertenciaForm

            If ObjEnt.PIncapacidadFechaFin.AddDays(1) > dtpFechaFinal.Value Then
                advertencia.mensaje = "El colaborador ya cuenta con una incapacidad para esas fechas."
            Else
                advertencia.mensaje = "El colaborador ya cuenta con una incapacidad para esas fechas. La fecha de inicio y los dias autorizados se moveran"

                Dim temp As Int32 = (ObjEnt.PIncapacidadFechaFin - dtpFechaInicio.Value).TotalDays
                diasAut = NupDiasAutorizados.Value - (ObjEnt.PIncapacidadFechaFin - dtpFechaInicio.Value).TotalDays
                dtpFechaInicio.Value = ObjEnt.PIncapacidadFechaFin.AddDays(1)
                NupDiasAutorizados.Value = diasAut
            End If

            'NupDiasAutorizados.Enabled = False
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim ObjEditar As New EditarIncapacidadesForm
        ObjEditar.Show()
        Me.Close()
    End Sub

    Private Sub btnLista_Click(sender As Object, e As EventArgs)
        Dim ObjLista As New ListaIncapacidadesForm
        ObjLista.Show()
        Me.Close()
    End Sub

    'Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
    '    Dim diasAutorizados As Integer = 0
    '    Dim fechai As DateTime
    '    Dim fechaF As DateTime
    '    fechai = dtpFechaInicio.Value
    '    fechaF = dtpFechaFinal.Value
    '    diasAutorizados = (fechaF - fechai).TotalDays

    '    If diasAutorizados < 0 Or diasAutorizados > 99 Then
    '        diasAutorizados = 0
    '    Else
    '        diasAutorizados += 1
    '    End If

    '    NupDiasAutorizados.Value = diasAutorizados
    'End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        Dim diasAutorizados As Integer = 0
        Dim fechai As DateTime
        Dim fechaF As DateTime
        fechai = dtpFechaInicio.Value
        fechaF = dtpFechaFinal.Value
        diasAutorizados = (fechaF - fechai).TotalDays

        If diasAutorizados <= 0 Then
            diasAutorizados = 0
        Else
            diasAutorizados += 1
        End If

        NupDiasAutorizados.Value = diasAutorizados
    End Sub

    Private Sub NupDiasAutorizados_ValueChanged(sender As Object, e As EventArgs) Handles NupDiasAutorizados.ValueChanged
        Dim diasAutorizados As Double
        diasAutorizados = NupDiasAutorizados.Value
        dtpFechaFinal.Value = dtpFechaInicio.Value.AddDays(diasAutorizados - 1)

        If diasAutorizados <> 0 Then
            ValidarIncapacidad(ColaboradorID, dtpFechaInicio.Value, dtpFechaFinal.Value)
        End If

    End Sub


    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PDF|*.pdf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        rutaArchivo = ofdRutaArchivo.FileName
        lblNombreArchivo.Text = IO.Path.GetFileName(rutaArchivo)
    End Sub

    Public Sub agregarArchivo()
        Dim tipoArchivo As String = String.Empty
        Dim seleccionado As Boolean = True
        Dim advertencia As New AdvertenciaForm
        Dim item As Integer = 0

        If rdnActaIncapacidad.Checked Then
            tipoArchivo = "Carta de Incapacidad"
        ElseIf rdnFormatost2.Checked Then
            tipoArchivo = "formato ST2"
        ElseIf rdnFormatost7.Checked Then
            tipoArchivo = "formato ST7"
        Else
            seleccionado = False
        End If

        If seleccionado = True And rutaArchivo <> "" Then
            If listaArchivo.Exists(Function(c) c.PTipo = tipoArchivo) Then
                advertencia.mensaje = "Ya existe un archivo de " + tipoArchivo + " no es posible agregar otro"
                advertencia.ShowDialog()
            Else
                Dim confirmacion As New ConfirmarForm
                confirmacion.mensaje = "¿Estas seguro de agregar el archivo a la incapacidad? Una vez agregado no podrá realizar cambios"
                If confirmacion.ShowDialog = DialogResult.OK Then
                    Dim archivoNuevo As New Entidades.AcusesIncapacidades
                    directorio = rutaAcuses & ColaboradorID
                    archivoNuevo.PTipo = tipoArchivo
                    archivoNuevo.PRutaArchivo = rutaArchivo
                    archivoNuevo.PCarpetaArchivo = directorio
                    archivoNuevo.PNombreArchivo = IO.Path.GetFileName(rutaArchivo)

                    listaArchivo.Add(archivoNuevo)

                    lbListaArchivos.Items.Clear()

                    For Each incapacidad As Entidades.AcusesIncapacidades In listaArchivo
                        lbListaArchivos.Items.Add(incapacidad.PTipo.ToUpper + "-" + incapacidad.PNombreArchivo)
                    Next
                    lblNombreArchivo.Text = ""
                    rutaArchivo = ""
                End If


            End If


        Else
            advertencia.mensaje = "Para agregar un archivo, seleccione un tipo de formato y el archivo"
            advertencia.ShowDialog()
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregarArchivo()
    End Sub

    Public Function validaIncapacidadInicial() As Boolean
        Dim existe As Int32 = 0
        Dim objBu As New Negocios.IncapacidadesBU

        'existe = objBu.validaIncapacidadIncial(ColaboradorID, 0)

        If existe = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class