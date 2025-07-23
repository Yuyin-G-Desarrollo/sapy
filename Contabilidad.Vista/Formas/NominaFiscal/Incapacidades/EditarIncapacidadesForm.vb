Imports System.Net
Imports System.Drawing
Imports Tools
Imports System.Windows.Forms

Public Class EditarIncapacidadesForm
    Dim ColaboradorID As Integer = 0
    Dim incapacida
    Dim NaveID As Integer = 0
    Dim EstaMal As Boolean = False
    Dim ValidarIncapacidadExistene As Boolean = False
    Dim rutaArchivo As String = String.Empty
    Public colaboradorIncapacidadId As Int32 = 0
    Public fechaInicioInc As Date
    Public fechaFinInc As Date
    Dim listaArchivo As New List(Of Entidades.AcusesIncapacidades)
    Dim directorio As String = String.Empty
    Public Const rutaAcuses As String = "IMAGENES/"
    'Public Const rutaFTP As String = "FTP://192.168.7.16/"
    'Public Const ftpUsuario As String = "prod\yuyinerp"
    'Public Const ftpContrasena As String = "yuyinerp"
    Dim diasNoCorresponde As Boolean = False
    Public validaRT As Boolean = False


    Private Sub EditarIncapacidadesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pbColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)
        ' Tools.FormatoCtrls.formato(Me)
        llenarComboRamoDelSeguro()
        llenarComboTipoRiesgo()
        llenarcomboControlIncapacidad()
        llenarComboSecuelaOconsecuencia()
        llenarcombotipoMaternidad()
        'llenarComboIncapacidadesAnteriores()
        cargarDatosIncapacidad()

        'limpiar()
        If validaRT = True Then
            cmbRamoDelSeguro.Enabled = False
            cmbTipoDeRiesgo.Enabled = False
            cmbIncapacidadAnterior.Enabled = False
            cmbControlIncapacidad.Enabled = False
            cmbSecuelaOConsecuencia.Enabled = False
            dtpFechaInicio.Enabled = False
            ' dtpFechaFinal.Enabled = False
            NupDiasAutorizados.Enabled = False
            txtDescripcion.Enabled = False
            chkRiesgoTrabajo.Enabled = False
            txtFolio1.Enabled = False
        End If
    End Sub

    Public Sub llenarComboIncapacidadesAnteriores()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim dtAnt As New DataTable
        dtAnt = objBU.consultaIncapacidadesAnteriores(ColaboradorID, lblIncapacidadID.Text)

        If dtAnt.Rows.Count > 0 Then
            With cmbIncapacidadAnterior
                .DisplayMember = "descripcion"
                .ValueMember = "idIncapacidad"
                .DataSource = dtAnt
            End With
        End If

    End Sub

    Public Sub mostrarListadoArchivos()
        Dim objBu As New Negocios.IncapacidadesBU
        listaArchivo = objBu.consultaListadoArchivos(lblIncapacidadID.Text)

        For Each archivo As Entidades.AcusesIncapacidades In listaArchivo
            lbListaArchivos.Items.Add(archivo.PTipo + " - " + archivo.PNombreArchivo)
        Next
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
            If listaArchivo.Exists(Function(c) c.PTipo = tipoArchivo.ToUpper) Then
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
                    archivoNuevo.PExpedienteId = 0

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

    Public Sub cargarDatosIncapacidad()
        Dim ListaIncapacidadesDetalle As New List(Of Entidades.Incapacidades)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjENT As New Entidades.Incapacidades

        If colaboradorIncapacidadId > 0 Then
            ColaboradorID = colaboradorIncapacidadId
            LlenarDatosColaborador()
            lblColaborador.ForeColor = Color.Black
            lblEdad.ForeColor = Color.Black
            lblNave.ForeColor = Color.Black
            lblDepartamento.ForeColor = Color.Black
            lblPuesto.ForeColor = Color.Black
        End If

        ListaIncapacidadesDetalle = ObjBU.ListaDetalleIncapacidades(colaboradorIncapacidadId, fechaInicioInc, fechaFinInc)

        For Each Fila As Entidades.Incapacidades In ListaIncapacidadesDetalle
            lblReplicado.Text = Fila.PIncapacidadNominpaq
            lblIncapacidadID.Text = Fila.PIncapacidadID
            txtFolio.Text = Fila.PIncapacidadFolio
            dtpFechaFinal.Value = Fila.PIncapacidadFechaFin.ToShortDateString
            dtpFechaInicio.Value = Fila.PIncapacidadFechaInicio.ToShortDateString
            NupDiasAutorizados.Enabled = False
            NupDiasAutorizados.Value = Fila.PIncapacidadDiasAutorizados
            NupDiasAutorizados.Enabled = True
            cmbRamoDelSeguro.SelectedValue = Fila.PRamoSeguroID
            llenarcomboControlIncapacidad()
            llenarComboIncapacidadesAnteriores()
            cmbTipoDeRiesgo.SelectedValue = Fila.PTipoRiesgoID
            cmbControlIncapacidad.SelectedValue = Fila.PControlIncapacidadID
            cmbSecuelaOConsecuencia.SelectedValue = Fila.PSecuelaID
            cmbTipoMaternidad.SelectedValue = Fila.PTipoMaternidadID
            txtDescripcion.Text = Fila.PIncapacidadDescripcion
            cmbIncapacidadAnterior.SelectedValue = Fila.PIncapacidadAnteirorId
            chkRiesgoTrabajo.Checked = Fila.PAceptadoRT

            mostrarListadoArchivos()

            If Fila.PEstatusId = 111 Then
                txtFolio.Enabled = False
                ' dtpFechaFinal.Enabled = False
                dtpFechaInicio.Enabled = False
                NupDiasAutorizados.Enabled = False
                txtDescripcion.Enabled = False
                cmbRamoDelSeguro.Enabled = False
                cmbTipoDeRiesgo.Enabled = False
                cmbControlIncapacidad.Enabled = False
                cmbSecuelaOConsecuencia.Enabled = False
                cmbTipoMaternidad.Enabled = False
                btnGuardarEditar.Enabled = False
                btnEliminar.Enabled = False
            Else
                txtFolio.Enabled = True
                ' dtpFechaFinal.Enabled = True
                dtpFechaInicio.Enabled = True
                NupDiasAutorizados.Enabled = True
                txtDescripcion.Enabled = True
                cmbRamoDelSeguro.Enabled = True
                btnGuardarEditar.Enabled = True
                btnEliminar.Enabled = True
                ValidarCombosActivos()
            End If
        Next

    End Sub



    Private Sub EditarIncapacidadesForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim empleadosForm As New Nomina.Vista.BuscarEmpleadoForm

        'empleadosForm.grdBuscarEmpleado.Rows.Clear()
        txtFolio.Focus()

        If empleadosForm.ShowDialog = DialogResult.OK Then
            ColaboradorID = empleadosForm.pseleccion
            If ColaboradorID > 0 Then
                LlenarDatosColaborador()
                lblColaborador.ForeColor = Color.Black
                lblEdad.ForeColor = Color.Black
                lblNave.ForeColor = Color.Black
                lblDepartamento.ForeColor = Color.Black
                lblPuesto.ForeColor = Color.Black
            End If
        End If
    End Sub

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

            ''Llenado lista incapacidades
            LBIncapacidades.Items.Clear()
            ListaIncapacidades(ColaboradorID)

            LBIncapacidades.Items.Add("--Nominpaq--")

            ListaIncapacidadesReclicadas(ColaboradorID)

        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = "No seleccionó ningún colaborador."
            mensajeError.Show()
        End Try
    End Sub

    Private Sub ListaIncapacidadesReclicadas(ByVal ColaboradorID As Integer)
        Try
            Dim ObjBU As New Negocios.IncapacidadesBU
            Dim ListaIncapacidadesColaborador As New List(Of Entidades.Incapacidades)
            ListaIncapacidadesColaborador = ObjBU.ListaIncapacidadesReplicadas(ColaboradorID)
            For Each Incapacidad As Entidades.Incapacidades In ListaIncapacidadesColaborador
                LBIncapacidades.Items.Add(Incapacidad.PIncapacidadFechaInicio.ToShortDateString + " - " + Incapacidad.PIncapacidadFechaFin.ToShortDateString)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListaIncapacidades(ByVal ColaboradorID As Integer)
        Try
            Dim ObjBU As New Negocios.IncapacidadesBU
            Dim ListaIncapacidadesColaborador As New List(Of Entidades.Incapacidades)
            ListaIncapacidadesColaborador = ObjBU.ListaIncapacidades(ColaboradorID)
            For Each Incapacidad As Entidades.Incapacidades In ListaIncapacidadesColaborador
                LBIncapacidades.Items.Add(Incapacidad.PIncapacidadFechaInicio.ToShortDateString + " - " + Incapacidad.PIncapacidadFechaFin.ToShortDateString)

            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGuardarEditar_Click(sender As Object, e As EventArgs) Handles btnGuardarEditar.Click
        ValidarCampos()
        If EstaMal = False Then

            If validaIncapacidadInicial() And (cmbControlIncapacidad.SelectedValue = 1 Or cmbControlIncapacidad.SelectedValue = 2) Then
                Dim advetencia As New AdvertenciaForm
                advetencia.mensaje = "No es posible editar la incapacidad como " + cmbControlIncapacidad.Text + " debido a que el colaborador ya cuenta con una incapacidad pendiente (INICIAL)"
                advetencia.ShowDialog()
            Else
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "¿Estas seguro de querer editar la incapacidad? "
                If mensajeExito.ShowDialog = DialogResult.OK Then
                    GuardarEditar()
                End If
            End If



        Else

            If diasNoCorresponde Then
                Dim advetencia As New AdvertenciaForm
                advetencia.mensaje = "Los dias autorizados no corresponden con la diferencia de días entre las fechas capturadas"
                advetencia.ShowDialog()
            End If

        End If
    End Sub

    Public Sub GuardarEditar()
        ValidarIncapacidad(ColaboradorID, dtpFechaInicio.Value, dtpFechaFinal.Value, lblIncapacidadID.Text)

        If ValidarIncapacidadExistene = False Then
            Dim objBU As New Negocios.IncapacidadesBU
            Dim ObjEnt As New Entidades.Incapacidades
            Dim Colaborador As New Entidades.Colaborador

            ObjEnt.PIncapacidadID = lblIncapacidadID.Text
            ObjEnt.PIncapacidadFolio = txtFolio.Text
            ObjEnt.PIncapacidadFechaInicio = dtpFechaInicio.Value
            ObjEnt.PIncapacidadFechaFin = dtpFechaFinal.Value
            ObjEnt.PIncapacidadDiasAutorizados = NupDiasAutorizados.Value

            ObjEnt.PRamoSeguroID = cmbRamoDelSeguro.SelectedValue
            ObjEnt.PAceptadoRT = chkRiesgoTrabajo.Checked

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
            ObjEnt.PFechaModificacion = Today.Date
            ObjEnt.PUsuarioModificacion = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            ObjEnt.PIncapacidadAnteirorId = cmbIncapacidadAnterior.SelectedValue
            ObjEnt.PColaborador = Colaborador

            ''Guardar mandando mensaje
            Try
                objBU.EditarIncapacidades(ObjEnt)

                If subirArchivos(lblIncapacidadID.Text) Then
                    Dim mensajeExito As New ExitoForm
                    mensajeExito.MdiParent = Me.MdiParent
                    mensajeExito.mensaje = "La incapacidad se ha modificado correctamente."
                    mensajeExito.Show()
                    LBIncapacidades.Items.Clear()
                    ListaIncapacidades(ColaboradorID)
                    LBIncapacidades.Items.Add("--Nominpaq--")
                    ListaIncapacidadesReclicadas(ColaboradorID)
                Else
                    Dim mensajeAdvertencia As New AdvertenciaForm
                    mensajeAdvertencia.MdiParent = Me.MdiParent
                    mensajeAdvertencia.mensaje = "Algo surgió mal al subir los acuses de la incapacidad, por favor adjunte los archivos nuevamente editando la incapacidad"
                    mensajeAdvertencia.Show()
                    limpiar()
                End If


            Catch ex As Exception
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.MdiParent = Me.MdiParent
                mensajeAdvertencia.mensaje = "Algo surgió mal al editar la incapacidad"
                mensajeAdvertencia.Show()
            End Try
        Else
            Dim mensajeAviso As New AvisoForm
            mensajeAviso.MdiParent = Me.MdiParent
            mensajeAviso.mensaje = "Ya existe una incapacidad entre ese rango de fechas."
            mensajeAviso.Show()
            LBIncapacidades.Items.Clear()
            ListaIncapacidades(ColaboradorID)
            LBIncapacidades.Items.Add("--Nominpaq--")
            ListaIncapacidadesReclicadas(ColaboradorID)
            lblFechaInicio.ForeColor = Color.Red
            lblFechafinal.ForeColor = Color.Red
        End If


    End Sub

    Public Function subirArchivos(ByVal idIncapacidad As Int32) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP()
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty
            Dim bandera As Boolean = True
            Dim resul As String = String.Empty
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & ColaboradorID

            For Each archivo As Entidades.AcusesIncapacidades In listaArchivo
                If archivo.PRutaArchivo <> "" Then
                    objFTP.EnviarArchivo(archivo.PCarpetaArchivo, archivo.PRutaArchivo)
                    'objFTP.EnviarArchivo(archivo.PCarpetaArchivo, "C:\Users\SISTEMAS5\Documents\credenciales\jeans.pdf")
                    rutaArchivo = objFTP.obtenerURL & "/" & archivo.PCarpetaArchivo & "/" & archivo.PNombreArchivo
                    Dim tituloMovimiento As String = String.Empty
                    If objFTP.FtpExisteArchivo(rutaArchivo) Then
                        ''aqui actualizar expediente
                        Dim objBu As New Negocios.IncapacidadesBU
                        tituloMovimiento = "INCAPACIDADES (" + archivo.PTipo.ToUpper + ")"
                        resul = objBu.actualizarExpediente(ColaboradorID, idIncapacidad, archivo.PExpedienteId, tituloMovimiento, archivo.PCarpetaArchivo, archivo.PNombreArchivo)

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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim mensajeConfirmar As New ConfirmarForm
        mensajeConfirmar.mensaje = "¿Estas seguro de querer eliminar la incapacidad? "
        If mensajeConfirmar.ShowDialog = DialogResult.OK Then
            GuardarEliminar()
        End If
    End Sub

    Public Sub GuardarEliminar()
        Dim objBU As New Negocios.IncapacidadesBU
        Dim ObjEnt As New Entidades.Incapacidades

        Try
            If lblIncapacidadID.Text <> "" Then


                ObjEnt.PIncapacidadID = lblIncapacidadID.Text

                objBU.EliminarIncapacidades(ObjEnt)
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "La incapacidad se ha eliminado correctamente."
                mensajeExito.Show()
                LBIncapacidades.Items.Clear()
                ListaIncapacidades(ColaboradorID)
                LBIncapacidades.Items.Add("--Nominpaq--")
                ListaIncapacidadesReclicadas(ColaboradorID)

                lblReplicado.Text = ""
                lblIncapacidadID.Text = ""
                txtFolio.Text = ""
                txtDescripcion.Text = ""
                dtpFechaFinal.Value = Today.Date
                dtpFechaInicio.Value = Today.Date
                NupDiasAutorizados.Value = 0
                cmbRamoDelSeguro.SelectedIndex = 0
                cmbControlIncapacidad.SelectedIndex = 0
                cmbSecuelaOConsecuencia.SelectedIndex = 0
                cmbTipoDeRiesgo.SelectedIndex = 0
                cmbTipoMaternidad.SelectedIndex = 0

                txtFolio.Enabled = False
                txtDescripcion.Enabled = False
                dtpFechaInicio.Enabled = False
                '  dtpFechaFinal.Enabled = False
                NupDiasAutorizados.Enabled = False
                cmbRamoDelSeguro.Enabled = False
                cmbControlIncapacidad.Enabled = False
                cmbSecuelaOConsecuencia.Enabled = False
                cmbTipoDeRiesgo.Enabled = False
                cmbTipoMaternidad.Enabled = False
            Else
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Favor de seleccionar una incapacidad."
                mensajeExito.Show()
            End If


        Catch ex As Exception

        End Try

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
        LBIncapacidades.Items.Clear()

        txtFolio.Text = ""
        txtDescripcion.Text = ""
        dtpFechaFinal.Value = Today.Date
        dtpFechaInicio.Value = Today.Date
        NupDiasAutorizados.Value = 0
        cmbRamoDelSeguro.SelectedIndex = 0
        cmbControlIncapacidad.SelectedIndex = 0
        cmbSecuelaOConsecuencia.SelectedIndex = 0
        cmbTipoDeRiesgo.SelectedIndex = 0
        cmbTipoMaternidad.SelectedIndex = 0
        pbColaborador.Image = CType(My.Resources.ResourceManager.GetObject("YUMPER1"), Image)

        txtFolio.Enabled = False
        txtDescripcion.Enabled = False
        dtpFechaInicio.Enabled = False
        'dtpFechaFinal.Enabled = False
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
    End Sub

    Private Sub ValidarCampos()
        EstaMal = False

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
            lblFolio.ForeColor = Color.Red
            EstaMal = True
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
        If NupDiasAutorizados.Value = 0 Then
            lblDiasAutorizados.ForeColor = Color.Red
            EstaMal = True
        Else
            lblDiasAutorizados.ForeColor = Color.Black
        End If
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
        If (cmbRamoDelSeguro.Text = "RIESGO DE TRABAJO" And cmbControlIncapacidad.SelectedIndex = 0) Or (cmbRamoDelSeguro.Text = "ENFERMEDAD GENERAL" And cmbControlIncapacidad.SelectedIndex = 0) Then
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
        If cmbRamoDelSeguro.Text = "MATERNIDAD" And cmbTipoMaternidad.SelectedIndex = 0 Then
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

        If NupDiasAutorizados.Value <> ((dtpFechaFinal.Value - dtpFechaInicio.Value).TotalDays + 1) Then
            If NupDiasAutorizados.Value <> 0 Then
                EstaMal = True
                diasNoCorresponde = True
            End If

        End If

    End Sub

    Private Sub ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal incapacidadID As Integer)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjEnt As New Entidades.Incapacidades
        ValidarIncapacidadExistene = False
        ObjEnt = ObjBU.ValidarIncapacidadEditar(ColaboradorID, FechaInicio, FechaFin, incapacidadID)
        ValidarIncapacidadExistene = ObjEnt.PValidarIncapacidad
    End Sub

    Private Sub LBIncapacidades_DoubleClick(sender As Object, e As EventArgs) Handles LBIncapacidades.DoubleClick, lbListaArchivos.DoubleClick
        Try

            Dim ObjBU As New Negocios.IncapacidadesBU
            Dim ObjENT As New Entidades.Incapacidades
            Dim ListaIncapacidadesDetalle As New List(Of Entidades.Incapacidades)

            Dim FechaInicio, FechaFin As DateTime
            Dim cadena As String = LBIncapacidades.SelectedItem
            If cadena <> "--Nominpaq--" Then
                paintInBlack()

                Dim tabla() As String
                Dim n As Integer

                tabla = Split(cadena, " - ")

                For n = 0 To UBound(tabla, 1)
                    FechaInicio = tabla(0)
                    FechaFin = tabla(1)
                Next

                ListaIncapacidadesDetalle = ObjBU.ListaDetalleIncapacidades(ColaboradorID, FechaInicio, FechaFin)

                For Each Fila As Entidades.Incapacidades In ListaIncapacidadesDetalle
                    lblReplicado.Text = Fila.PIncapacidadNominpaq
                    lblIncapacidadID.Text = Fila.PIncapacidadID
                    txtFolio.Text = Fila.PIncapacidadFolio
                    dtpFechaInicio.Value = Fila.PIncapacidadFechaInicio.ToShortDateString
                    dtpFechaFinal.Value = Fila.PIncapacidadFechaFin.ToShortDateString
                    NupDiasAutorizados.Value = Fila.PIncapacidadDiasAutorizados
                    cmbRamoDelSeguro.SelectedValue = Fila.PRamoSeguroID
                    llenarcomboControlIncapacidad()
                    cmbTipoDeRiesgo.SelectedValue = Fila.PTipoRiesgoID
                    cmbControlIncapacidad.SelectedValue = Fila.PControlIncapacidadID
                    cmbSecuelaOConsecuencia.SelectedValue = Fila.PSecuelaID
                    cmbTipoMaternidad.SelectedValue = Fila.PTipoMaternidadID
                    txtDescripcion.Text = Fila.PIncapacidadDescripcion



                    If lblReplicado.Text = True Then
                        txtFolio.Enabled = False
                        'dtpFechaFinal.Enabled = False
                        dtpFechaInicio.Enabled = False
                        NupDiasAutorizados.Enabled = False
                        txtDescripcion.Enabled = False
                        cmbRamoDelSeguro.Enabled = False
                        cmbTipoDeRiesgo.Enabled = False
                        cmbControlIncapacidad.Enabled = False
                        cmbSecuelaOConsecuencia.Enabled = False
                        cmbTipoMaternidad.Enabled = False
                        btnGuardarEditar.Enabled = False
                        btnEliminar.Enabled = False
                    Else
                        txtFolio.Enabled = True
                        'dtpFechaFinal.Enabled = True
                        dtpFechaInicio.Enabled = True
                        NupDiasAutorizados.Enabled = True
                        txtDescripcion.Enabled = True
                        cmbRamoDelSeguro.Enabled = True
                        btnGuardarEditar.Enabled = True
                        btnEliminar.Enabled = True
                        ValidarCombosActivos()
                    End If
                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbRamoDelSeguro_DropDownClosed(sender As Object, e As EventArgs) Handles cmbRamoDelSeguro.DropDownClosed, cmbIncapacidadAnterior.DropDownClosed
        Try
            llenarcomboControlIncapacidad()
            ValidarCombosActivos()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub paintInBlack()
        lblFolio.ForeColor = Color.Black
        lblFechaInicio.ForeColor = Color.Black
        lblFechafinal.ForeColor = Color.Black
        lblDiasAutorizados.ForeColor = Color.Black
        lblRamoDelSeguro.ForeColor = Color.Black
        lblTipoDeRiesgo.ForeColor = Color.Black
        lblControlDeIncapacidad.ForeColor = Color.Black
        lblSecuelaOConsecuencia.ForeColor = Color.Black
        lblTipoMaternidad.ForeColor = Color.Black
        lblDescripcion.ForeColor = Color.Black
    End Sub

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

    Public Sub ValidarCombosActivos()

        If cmbRamoDelSeguro.SelectedValue = 1 Then
            cmbTipoDeRiesgo.Enabled = True
            cmbControlIncapacidad.Enabled = True
            cmbSecuelaOConsecuencia.Enabled = True
        Else
            'If cmbRamoDelSeguro.SelectedValue = 2 Then
            'Else
            '    cmbControlIncapacidad.Enabled = False
            '    cmbControlIncapacidad.SelectedIndex = 0
            'End If

            cmbTipoDeRiesgo.Enabled = False
            cmbTipoDeRiesgo.SelectedIndex = 0

            cmbSecuelaOConsecuencia.Enabled = False
            cmbSecuelaOConsecuencia.SelectedIndex = 0
        End If
        ''
        If cmbRamoDelSeguro.SelectedValue = 2 Or cmbRamoDelSeguro.SelectedValue = 1 Or cmbRamoDelSeguro.SelectedValue = 3 Then
            cmbControlIncapacidad.Enabled = True
        Else
            cmbControlIncapacidad.Enabled = False
        End If
        ''
        If cmbRamoDelSeguro.SelectedValue = 3 Then
            cmbTipoMaternidad.Enabled = True
        Else
            cmbTipoMaternidad.Enabled = False
            cmbTipoMaternidad.SelectedIndex = 0
        End If
    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnAlta_Click(sender As Object, e As EventArgs) Handles BtnAlta.Click
        Dim Objalta As New AltaIncapacidadesForm
        Objalta.Show()
        Me.Close()
    End Sub

    Private Sub btnLista_Click(sender As Object, e As EventArgs)
        Dim ObjLista As New ListaIncapacidadesForm
        ObjLista.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregarArchivo()
    End Sub

    Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
        ofdRutaArchivo.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ofdRutaArchivo.Filter = "PDF|*.pdf;"
        ofdRutaArchivo.FilterIndex = 3
        ofdRutaArchivo.ShowDialog()
        rutaArchivo = ofdRutaArchivo.FileName
        lblNombreArchivo.Text = IO.Path.GetFileName(rutaArchivo)
    End Sub

    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFinal.ValueChanged
        Dim diasAutorizados As Integer = 0
        Dim fechai As DateTime
        Dim fechaF As DateTime
        fechai = dtpFechaInicio.Value
        fechaF = dtpFechaFinal.Value
        diasAutorizados = (fechaF - fechai).TotalDays

        If diasAutorizados < 0 Or diasAutorizados > 99 Then
            diasAutorizados = 0
        Else
            diasAutorizados += 1
        End If

        NupDiasAutorizados.Value = diasAutorizados
    End Sub

    Public Function validaIncapacidadInicial() As Boolean
        Dim existe As Int32 = 0
        Dim objBu As New Negocios.IncapacidadesBU

        'existe = objBu.validaIncapacidadIncial(ColaboradorID, CInt(lblIncapacidadID.Text))

        If existe = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub NupDiasAutorizados_ValueChanged(sender As Object, e As EventArgs) Handles NupDiasAutorizados.ValueChanged
        Dim diasAutorizados As Double
        diasAutorizados = NupDiasAutorizados.Value
        dtpFechaFinal.Value = dtpFechaInicio.Value.AddDays(diasAutorizados - 1)

        If diasAutorizados <> 0 And NupDiasAutorizados.Enabled Then
            ValidarIncapacidad(ColaboradorID, dtpFechaInicio.Value, dtpFechaFinal.Value)
        End If
    End Sub

    Private Sub ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjEnt As New Entidades.Incapacidades
        Dim diasAut As Int32 = 0
        ValidarIncapacidadExistene = False
        ObjEnt = ObjBU.ValidarIncapacidad(ColaboradorID, FechaInicio, FechaFin, CInt(lblIncapacidadID.Text))
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
End Class