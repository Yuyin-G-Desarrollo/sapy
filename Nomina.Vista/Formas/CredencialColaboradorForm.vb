Imports System.Net
Imports Tools
Imports Framework.Negocios

Public Class CredencialColaboradorForm
    Private ColaboradorID As Int32

    Public Property PColaboradorID As Int32
        Get
            Return ColaboradorID
        End Get
        Set(ByVal value As Int32)
            ColaboradorID = value
        End Set
    End Property

    Public activo As Boolean

    Private Sub CredencialColaboradorForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If PermisosUsuarioBU.ConsultarPermiso("NOM_COL_CODR", "HISTORIALSALARIOS") Then
            btnSalarios.Visible = True
            lblSalarios.Visible = True

        Else
            btnSalarios.Visible = False
            lblSalarios.Visible = False
        End If

        txtDepartamento.Text = ""
        txtPuesto.Text = ""
        lblCurp.Text = ""
        lblRFC.Text = ""
        lblCivil.Text = ""
        lblNacimiento.Text = ""
        lblCalle.Text = ""
        lblNumero.Text = ""
        lblColonia.Text = ""
        lblCP.Text = ""
        lblCasa.Text = ""
        lblCel.Text = ""
        lblEmail.Text = ""
        lblSueldo.Text = ""
        lblFechaAltaImss.Text = ""
        lblPatron.Text = ""
        lblFormadePago.Text = ""
        lblNSS.Text = ""
        lblCuenta.Text = ""
        lblNave.Text = ""
        lblPuesto.Text = ""
        lblSexo.Text = ""
        lblFiniquito.Text = ""
        lblClaveElector.Text = ""
        lblDepartamento.Text = ""
        lblCelula.Text = ""
        lblHorario.Text = ""
        lblTipoSalario.Text = ""
        lblTipoPago.Text = ""
        lblCantidad.Text = ""
        lblNoCuenta.Text = ""
        lblFechaIngreso.Text = ""
        lblCiudad.Text = ""
        lblTipoInfonavit.Text = ""
        lblMontoinfonavit.Text = ""
        lblFechaInfonavit.Text = ""
        lblSueldoDiario.Text = ""
        txtxMotivo.Text = ""
        lblMotivoFiniquito.Text = ""
        Dim tooltip1, tooltip2, tooltip3, tooltip4, tooltip5, tooltip6, tooltip7, tooltip8 As New ToolTip
        tooltip1.ShowAlways = True
        tooltip2.ShowAlways = True
        tooltip3.ShowAlways = True
        tooltip4.ShowAlways = True
        tooltip5.ShowAlways = True
        tooltip6.ShowAlways = True
        tooltip7.ShowAlways = True
        tooltip8.ShowAlways = True
        tooltip1.SetToolTip(btnGeneral, "Mostrar información general del colaborador")
        tooltip2.SetToolTip(btnExpediente, "Mostrar Expediente del colaborador")
        tooltip3.SetToolTip(btnLaboral, "Mostrar información laboral del colaborador")
        tooltip4.SetToolTip(btnMedica, "Mostrar información medica del colaborador")
        tooltip5.SetToolTip(btnNomina, "Mostrar información de nómina del colaborador")
        tooltip6.SetToolTip(btnAcademica, "Mostrar información académica del colaborador")
        tooltip7.SetToolTip(btnReal, "Mostrar información adicional del colaborador")
        tooltip8.SetToolTip(btnSalarios, "Mostrar historial de salario")
        grdSalarios.Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        CargarInformacionGeneral()
        CargarInformacionNomina()
        CargarInformacionLaboral()
        CargarInformacionMedica()
        llenarDatosReales()
        CargarColaboradorArchivos()
        CargarColaboradorAcademica()
        CargarColaboradorReferencias()
        CargarSalarios()
        grdReferencias.ReadOnly = True
        grdArchivos.ReadOnly = True
        pnlReal.Visible = False
        pnlGeneral.Visible = True
        pnlGeneral.Dock = DockStyle.Fill
        pnlNomina.Visible = False
        pnlLaboral.Visible = False
        pnlMedica.Visible = False
        pnlExpediente.Visible = False
        pnlAcademica.Visible = False
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False

    End Sub




    Public Sub CargarInformacionLaboral()
        Dim objBULaboral As New Negocios.ColaboradorLaboralBU
        Dim EntidadLaboral As New Entidades.ColaboradorLaboral
        EntidadLaboral = objBULaboral.buscarInformacionLaboral(ColaboradorID)
        Try
            lblNave.Text = EntidadLaboral.PNaveId.PNombre.ToUpper
            If EntidadLaboral.PCheca = True Then
                lblChecaChecador.Text = "SI"
            Else
                lblChecaChecador.Text = "NO"
            End If
            If EntidadLaboral.PReporte = True Then
                lblReportesChecador.Text = "SI"
            Else
                lblReportesChecador.Text = "NO"
            End If
            If EntidadLaboral.PGanaIncentivos = True Then
                lblIncentivosChecador.Text = "SI"
            Else
                lblIncentivosChecador.Text = "NO"
            End If

            lblNip.Text = EntidadLaboral.PNIP

            If lblNave.Text = "VILLAGONTI" Or lblNave.Text = "GREENLOVE" Then
                Label.Visible = True
                lblHuellaExterno.Visible = True
                Label.Text = EntidadLaboral.PhuellaExterno
            Else
                Label.Visible = False
                lblHuellaExterno.Visible = False
            End If

        Catch ex As Exception

        End Try
        Try
            lblPuesto.Text = EntidadLaboral.PPuestoId.PNombre.ToUpper
        Catch ex As Exception

        End Try
        Try
            lblDepartamento.Text = EntidadLaboral.PDepartamentoId.DNombre.ToUpper
        Catch ex As Exception

        End Try
        Try
            If Not EntidadLaboral.PCelula Is Nothing Then
                lblCelula.Text = EntidadLaboral.PCelula.PNombre.ToUpper
            End If
        Catch ex As Exception

        End Try
        Try
            lblHorario.Text = EntidadLaboral.PHorarioId.DNombre.ToUpper
        Catch ex As Exception

        End Try
    End Sub



    Public Sub CargarInformacionGeneral()
        Dim ObjBU As New Negocios.ColaboradoresBU
        Dim Datos As New Entidades.Colaborador
        Dim ObjBULaboral As New Negocios.ColaboradorLaboralBU
        Dim DatosLabo As New Entidades.ColaboradorLaboral
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        Dim EntidadArchivos As New Entidades.ColaboradorExpediente

        EntidadArchivos = ObjArchivosBU.CredencialColaborador(ColaboradorID)

        Datos = ObjBU.BuscarColaboradorGeneral(ColaboradorID)
        txtNombre.Text = Datos.PNombre + " " + Datos.PApaterno + " " + Datos.PAmaterno
        Try

            Dim objFTP As New Tools.TransferenciaFTP
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
            PictureBox1.Image = Image.FromStream(Stream)
        Catch

        End Try
        Try


            DatosLabo = ObjBULaboral.buscarInformacionLaboral(ColaboradorID)
            If DatosLabo.PNaveId.PNombre.Length > 0 Then
                txtNave.Text = DatosLabo.PNaveId.PNombre.ToUpper
                txtDepartamento.Text = DatosLabo.PDepartamentoId.DNombre.ToUpper
                txtPuesto.Text = DatosLabo.PPuestoId.PNombre.ToUpper
            Else

            End If

        Catch ex As Exception

        End Try

        Try

            lblCurp.Text = Datos.pCurp.ToUpper
            lblRFC.Text = Datos.PRfc.ToUpper
            lblCivil.Text = Datos.PEstadoCivil
            lblSexo.Text = Datos.PSexo
            lblClaveElector.Text = Datos.PClaveElector

            If Datos.PFechaNacimiento = CDate("01/01/0001") Then
                lblNacimiento.Text = " "
            Else
                lblNacimiento.Text = Datos.PFechaNacimiento.ToShortDateString
            End If

            If Datos.PActivo = False Then
                btnFiniquito.Visible = True
                lblBtnFiniquito.Visible = True
                cargarInformacionFiniquito()
            End If
            lblCalle.Text = Datos.PCalle.ToUpper
            lblNumero.Text = Datos.Pnumero
            lblColonia.Text = Datos.Pcolonia.ToUpper
            lblCP.Text = Datos.PCP
            lblCasa.Text = Datos.PTelefonoCasa
            lblCel.Text = Datos.PTelefonoCel
            lblEmail.Text = Datos.PEmail
            Dim Ciudad As New Framework.Negocios.CiudadesBU
            Dim EntidadCiudad As New Entidades.Ciudades


            lblCiudad.Text = Datos.PCiudad.CNombre
        Catch ex As Exception

        End Try





    End Sub
    Public Sub cargarInformacionFiniquito()
        Dim objFiniquito As New Negocios.FiniquitosBU
        Dim objMFiniquito As New Negocios.MotivosFiniquitoBU
        Dim vFiniquito As New Entidades.Finiquitos
        Dim vMotivo As New Entidades.MotivosFiniquito
        vFiniquito = objFiniquito.obtenerFiniquitoColaborador(ColaboradorID)
        lblFiniquito.Text = vFiniquito.PTotalFiniquito.ToString("C")
        lblAhorroFiniquito.Text = vFiniquito.PAhorro.ToString("C")
        lblUtilidadesFiniquito.Text = vFiniquito.PUtilidades.ToString("C")
        lblGratificacionesFiniquito.Text = vFiniquito.PGratificacion.ToString("C")
        lblSubTotalFiniquito.Text = vFiniquito.PSubtotal.ToString("C")
        lblPrestamoFiniquito.Text = vFiniquito.PPrestamo.ToString("C")
        lblExtrasFiniquito.Text = vFiniquito.PExtras.ToString("C")
        lblTotalFiniquito.Text = vFiniquito.PTotalEntregar.ToString("C")
        If vFiniquito.PFechaBaja = CDate("01/01/0001") Then
            lblFechaBajaFiniquito.Text = " "
        Else
            lblFechaBajaFiniquito.Text = vFiniquito.PFechaBaja.ToShortDateString
        End If
        lblFechaBajaFiniquito.Text = vFiniquito.PFechaBaja.ToShortDateString

        txtxMotivo.Text = vFiniquito.PJustificacion.ToString

        vMotivo = objMFiniquito.BuscarMotivos(vFiniquito.PMotivoFiniquitoId.PMotivoFiniquitoId)

        lblMotivoFiniquito.Text = vMotivo.PNombre


    End Sub
    Public Sub CargarInformacionNomina()

        Try
            Dim ObjBU As New Negocios.ColaboradorNominaBU
            Dim entidadNomina As New Entidades.ColaboradorNomina
            entidadNomina = ObjBU.buscarColaborarNomina(ColaboradorID)
            lblSueldo.Text = entidadNomina.PSalario.ToString("C")
            lblSueldoDiario.Text = entidadNomina.PSalarioDiario.ToString("C")
            If entidadNomina.PFechaAltaImss = CDate("01/01/0001") Then
                lblFechaAltaImss.Text = " "
            Else
                lblFechaAltaImss.Text = entidadNomina.PFechaAltaImss.ToShortDateString
            End If

            If entidadNomina.PInfonavit = True Then
                If entidadNomina.PInfonavitTipo = 4 Then
                    lblTipoInfonavit.Text = "CONTADORES"
                    lblMontoinfonavit.Text = entidadNomina.PInfonavitMonto
                    lblFechaInfonavit.Text = entidadNomina.PfechaAltaInfonavit
                Else
                    lblTipoInfonavit.Text = ""
                End If

            Else

            End If
            lblPatron.Text = entidadNomina.PPatron.Pnombre.ToUpper
            lblFormadePago.Text = entidadNomina.PFormaPago.ToUpper
            lblNSS.Text = entidadNomina.PNss.ToString
            ' lblCuenta.Text = entidadNomina.PCuenta.ToString
            Dim anios As Int32 = 0
            Dim meses As Int32 = 0
            Dim dias As Int32 = 0
            Dim diasme As Int32 = 0
            Dim Diastrabajados As Int32
            If entidadNomina.PFechaAltaImss = CDate("01/01/0001") Then
                Diastrabajados = 0
            Else
                Diastrabajados = DateDiff("y", entidadNomina.PFechaAltaImss.ToShortDateString, Date.Today)
            End If

            Dim objFiniquito As New Nomina.Negocios.FiniquitosBU
            Dim finiquito As New Entidades.Finiquitos
            'Dim fecha As New Date
            'fecha = objFiniquito.BuscarFiniquito(ColaboradorID)
            'If Not fecha = Date.MinValue Then
            '    Diastrabajados = DateDiff("y", entidadNomina.PFechaAltaImss.ToShortDateString, fecha)
            'End If

            If activo = False Then
                finiquito = objFiniquito.BuscarFiniquito(ColaboradorID)
                anios = finiquito.PAntiguedadAnios
                meses = finiquito.PAntiguedadMeses
                diasme = finiquito.PAntiguedadDias
            Else
                anios = Diastrabajados \ 365
                meses = (Diastrabajados Mod 365) \ 30.4
                diasme = (Diastrabajados Mod 365) Mod 30.4
            End If

            lblAntiguedadDato.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES " + diasme.ToString + " DIAS "
            '     lblAntiguedadCabeceras.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES "
            lblAntiguedadFiniquito.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES " + diasme.ToString + " DIAS "
        Catch ex As Exception

        End Try


    End Sub


    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneral.Click
        pnlGeneral.Dock = DockStyle.Fill
        pnlGeneral.Visible = True
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub

    Private Sub btnLaboral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNomina.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.Fill
        pnlNomina.Visible = True
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False

    End Sub

    Private Sub btnLaboral_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaboral.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.Fill
        pnlLaboral.Visible = True
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub



    Public Sub CargarInformacionMedica()
        Dim OBJMedicaBU As New Negocios.ColaboradorMedicaBU
        Dim EntidadMedica As New Entidades.ColaboradorMedica
        EntidadMedica = OBJMedicaBU.buscarColaborarMedica(ColaboradorID)
        Try
            lblTipoSanguineo.Text = EntidadMedica.PTipoSanguineo
            lblContactoEmergencias.Text = EntidadMedica.PContactoEmergencias
            lblConsideraciones.Text = EntidadMedica.PComentarios
            lblTelefono.Text = EntidadMedica.PTelefonoEmergencias
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMedica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedica.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.Fill
        pnlMedica.Visible = True
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub

    Public Sub llenarDatosReales()
        Dim objBU As New Negocios.ColaboradorRealBU
        Dim EntidadesReal As New Entidades.ColaboradorReal
        Dim anios As Int32 = 0
        Dim meses As Int32 = 0
        Dim dias As Int32 = 0
        Dim diasme As Int32 = 0
        Dim Diastrabajados As Int32

        EntidadesReal = objBU.BuscarColaboradorReal(ColaboradorID)
        Dim objFiniquito As New Negocios.FiniquitosBU
        Dim finiquito As New Entidades.Finiquitos
        Try
            lblTipoSalario.Text = EntidadesReal.PTipoPago
            lblTipoPago.Text = EntidadesReal.PTipo
            If Not EntidadesReal.PCantidad = 0 Then
                lblCantidad.Text = EntidadesReal.PCantidad.ToString("C")
            Else
                lblCantidad.Text = EntidadesReal.PCostoFraccion.ToString("C")
            End If

            lblNoCuenta.Text = EntidadesReal.PNumero

            If Not EntidadesReal.PSueldoSemanalAguinaldo = 0 Then
                lblSueldoSemanalAguinaldo.Text = EntidadesReal.PSueldoSemanalAguinaldo.ToString("C")
            Else
                lblSueldoSemanalAguinaldo.Text = ""
            End If

            If activo Then
                If EntidadesReal.PFecha = CDate("01/01/0001") Then
                    lblFechaIngresoFiniquito.Text = " "
                    Diastrabajados = 0
                Else
                    lblFechaIngresoFiniquito.Text = EntidadesReal.PFecha.ToShortDateString
                    Diastrabajados = DateDiff("y", EntidadesReal.PFecha.ToShortDateString, Date.Today)
                End If
                anios = Diastrabajados \ 365
                meses = (Diastrabajados Mod 365) \ 30.4
                diasme = (Diastrabajados Mod 365) Mod 30.4
            Else
                lblFechaIngresoFiniquito.Text = EntidadesReal.PFecha.ToShortDateString
                finiquito = objFiniquito.BuscarFiniquito(ColaboradorID)
                anios = finiquito.PAntiguedadAnios
                meses = finiquito.PAntiguedadMeses
                diasme = finiquito.PAntiguedadDias
            End If


            lblFechaingresoAdicional.Text = EntidadesReal.PFecha.ToShortDateString
            Dim vbancoBu As New BancosBU
            Dim entidadesbanco As New Entidades.Bancos
            entidadesbanco = vbancoBu.buscarBancos(EntidadesReal.PBanco)
            lblBanco.Text = entidadesbanco.PNombre
            lblID.Text = ColaboradorID

            lblAntiguedadCabeceras.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES "
            lblAntiguedadFiniquito.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES " + diasme.ToString + " DIAS "
            '    Dim anios As Int32 = 0
            '    Dim meses As Int32 = 0
            '    Dim dias As Int32 = 0
            '    Dim diasme As Int32 = 0
            '    Dim Diastrabajados As Int32

            '    If EntidadesReal.PFecha = CDate("01/01/0001") Then
            '        Diastrabajados = 0
            '    Else
            '        Diastrabajados = DateDiff("y", EntidadesReal.PFecha.ToShortDateString, Date.Today)
            '    End If

            '    If Not Fecha = Date.MinValue Then
            '        Diastrabajados = DateDiff("y", EntidadesReal.PFecha.ToShortDateString, Fecha)
            '        'btnFiniquito.Visible = True
            '        lblFechaBaja.Visible = True
            '        'lblFechaBajaFiniquito.Visible = True
            '        lblFechaBajaFiniquito.Text = Fecha.ToShortDateString
            '        'lblJustificacion.Visible = True
            '        'lblJustificacionDato.Visible = True
            '        lblJustificacionFiniquito.Text = objFiniquito.BuscarDescripcion(ColaboradorID)
            '    End If


            '    anios = Diastrabajados \ 365
            '    meses = (Diastrabajados Mod 365) \ 30.4
            '    diasme = (Diastrabajados Mod 365) Mod 30.4
            '    lblAntiguedadFiniquito.Text = anios.ToString + " AÑOS " + meses.ToString + "  MESES " + diasme.ToString + " DIAS "
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReal.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.Fill
        pnlReal.Visible = True
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub


    Private Sub CargarColaboradorArchivos()


        Dim objBU As New Negocios.EnviodeArchivosBU
        Dim lista As New List(Of Entidades.ColaboradorExpediente)
        lista = objBU.ListaColaboradorArchivos(ColaboradorID)
        For Each Archivo As Entidades.ColaboradorExpediente In lista
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow


            celda = New DataGridViewTextBoxCell
            celda.Value = Archivo.PNombreArchivo.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Archivo.Ptitulo.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Archivo.PCarpeta.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = Archivo.PCredencial

            fila.Cells.Add(celda)

            'celda = New DataGridViewTextBoxCell
            'celda.Value = referencia.PColaboradorReferenciaId
            'fila.Cells.Add(celda)

            grdArchivos.Rows.Add(fila)
        Next

    End Sub

    Private Sub btnExpediente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpediente.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.Fill
        pnlExpediente.Visible = True
        pnlAcademica.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub





    Private Sub CargarColaboradorAcademica()


        Dim objBU As New Negocios.ColaboradorAcademicoBU
        Dim lista As New List(Of Entidades.AcademicosColaborador)
        lista = objBU.ListaColaboradorAcademica(ColaboradorID)
        For Each Academica As Entidades.AcademicosColaborador In lista
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow


            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PNombreEscuela.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PCarrera.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PAnioInicio.ToString
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PAnioTermino
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PEstado.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Academica.PAcademicaId
            fila.Cells.Add(celda)

            grdAcademica.Rows.Add(fila)
        Next





    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcademica.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlAcademica.Dock = DockStyle.Fill
        pnlAcademica.Visible = True
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub

    Private Sub grdArchivos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdArchivos.CellDoubleClick
        Dim objTransferencias As New Tools.TransferenciaFTP

        Try
            If CStr(grdArchivos.Rows(e.RowIndex).Cells(0).Value).Length > 0 Then
                SAVArchivo.RestoreDirectory = True
                SAVArchivo.Title = "Guardar en:"

                SAVArchivo.Filter = "JPEG|*.jpg"

                SAVArchivo.FileName = CStr(grdArchivos.Rows(e.RowIndex).Cells(0).Value)
                Dim tabla() As String
                If SAVArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then

                    tabla = Split(SAVArchivo.FileName, "\")
                    Dim Rutaguardar As String = ""
                    For n = 0 To UBound(tabla, 1)
                        If UBound(tabla) = n Then
                        Else
                            Rutaguardar += tabla(n) + "\"
                        End If
                    Next

                    Dim Origen As String = ""
                    Origen += CStr(grdArchivos.Rows(e.RowIndex).Cells(2).Value)
                    objTransferencias.DescargarArchivo(Origen, Rutaguardar, CStr(grdArchivos.Rows(e.RowIndex).Cells(0).Value))
                End If
            Else
            End If
        Catch ex As Exception
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Este usuario no cuenta con ningun documento"
            Advertencia.MdiParent = Me.MdiParent
            Advertencia.Show()
        End Try




    End Sub

    Private Sub CargarColaboradorReferencias()



        Dim objBU As New Negocios.ColaboradorReferenciasBU
        Dim lista As New List(Of Entidades.ColaboradorReferencias)
        lista = objBU.ListaColaboradorReferencias(ColaboradorID)
        For Each referencia As Entidades.ColaboradorReferencias In lista
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow


            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PNombre.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.POcupacion.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PParentezco.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PTelefono.ToUpper
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PColaboradorReferenciaId
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = referencia.PFechaNacimiento.ToShortDateString
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = (DateDiff("y", referencia.PFechaNacimiento.ToShortDateString, Date.Today)) \ 365
            fila.Cells.Add(celda)
            grdReferencias.Rows.Add(fila)
        Next

    End Sub

    Private Sub btnFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFamilia.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlAcademica.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.Fill
        pnlFamilia.Visible = True
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub btnSalarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalarios.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlAcademica.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlFiniquito.Dock = DockStyle.None
        pnlFiniquito.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.Fill
        pnlHistorialSalarios.Visible = True
    End Sub


    Private Sub CargarSalarios()


        Dim objBU As New Negocios.HistorialSalarioBUvb
        Dim lista As New List(Of Entidades.HistorialSalarios)
        lista = objBU.ListaHistorialSueldos(ColaboradorID)
        For Each Sueldo As Entidades.HistorialSalarios In lista
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow


            celda = New DataGridViewTextBoxCell
            celda.Value = FormatNumber(Sueldo.PSueldo, 0)
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Sueldo.PFecha
            fila.Cells.Add(celda)



            '

            grdSalarios.Rows.Add(fila)
        Next

    End Sub

    Private Sub pnlGeneral_Paint(sender As Object, e As PaintEventArgs) Handles pnlGeneral.Paint

    End Sub

    Private Sub Label42_Click(sender As Object, e As EventArgs) Handles Label42.Click

    End Sub

    Private Sub pnlLaboral_Paint(sender As Object, e As PaintEventArgs) Handles pnlLaboral.Paint

    End Sub

    Private Sub btnFiniquito_Click(sender As Object, e As EventArgs) Handles btnFiniquito.Click
        pnlGeneral.Dock = DockStyle.None
        pnlGeneral.Visible = False
        pnlNomina.Dock = DockStyle.None
        pnlNomina.Visible = False
        pnlLaboral.Dock = DockStyle.None
        pnlLaboral.Visible = False
        pnlMedica.Dock = DockStyle.None
        pnlMedica.Visible = False
        pnlReal.Dock = DockStyle.None
        pnlReal.Visible = False
        pnlExpediente.Dock = DockStyle.None
        pnlExpediente.Visible = False
        pnlAcademica.Dock = DockStyle.None
        pnlAcademica.Visible = False
        pnlFamilia.Dock = DockStyle.None
        pnlFamilia.Visible = False
        pnlHistorialSalarios.Dock = DockStyle.None
        pnlHistorialSalarios.Visible = False
        pnlFiniquito.Dock = DockStyle.Fill
        pnlFiniquito.Visible = True
       
    End Sub

    Private Sub Label73_Click(sender As Object, e As EventArgs) Handles lblBanco.Click

    End Sub

    Private Sub Label71_Click(sender As Object, e As EventArgs) Handles Label71.Click

    End Sub
End Class