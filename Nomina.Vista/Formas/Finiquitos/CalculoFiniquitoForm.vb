Imports System.Net
Imports Nomina.Negocios
Imports Tools

Public Class CalculoFiniquitoForm
    Public ACCION As String = "ALTA"
    Public idFiniquito As Int32 = 0
    Public idNaveEmpleadoFin As Int32 = 0
    Public idColaboradorFin As Int32 = 0
    Public nombreEmpleadoFin As String
    Public departamentoFin As String
    Public puestoFin As String
    Public fechaIngreso As String

    Public fechaAguinaldo As String

    Public JustificacionFin As String
    Public ahorroFin As String
    Public fechaBajaFin As String
    Public antiguedadanios As String
    Public antiguedadmeses As String
    Public antiguedaddias As String


    Public motivoFin As Int32

    Public sueldosemana1 As String
    Public sueldosemana2 As String
    Public sueldosemana3 As String
    Public sueldosemana4 As String

    Public recontratarFin As Boolean
    Public prestamoFin As String
    Public gratificacionFin As String

    Public totalaguinaldo As String
    Public totalvacaciones As String
    Public primavacacional As String
    Public totalfiniquito As String
    Public subtotalfiniquito As String

    Public utilidades As String
    Public utilidadesanterior As String
    Public anioutilidades As String
    Public anioutilidadesanterior As String
    Public totalentregar As String
    Public fechasolicitud As String
    Public fechaAutorizo As String


    Public salariosemanal As String
    Public salariodiario As String
    Public mesesaguinaldo As String
    Public diasaguinaldo As String
    Public mesesvacaciones As String
    Public diasvacaciones As String
    Public tipoPago As String
    Public estado As String

    Public extras As String

    Dim idNaveEmpleado As Int32, IdColaborador As Int32
    Dim antiguedadArray(2) As Int32
    Dim anios As Int32
    Dim meses As Int32
    Dim dias As Int32
    Dim sueldoDiario As Double, costoDiario As Double
    Dim puesto As String
    Dim objFiniquitosBU As New Negocios.FiniquitosBU
    Dim ListaFiniquitos As New List(Of Entidades.Finiquitos)

    Dim editarSueldo As Boolean
    Dim pasaValidacion As Integer

    Property fechabaja As Object

    Private Sub CalculoFiniquitoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBuNe As New Negocios.FiniquitosBU

        Dim dtConfigNave As New DataTable
        Dim configUtilidades As Int32
        Dim configAguinaldo As Int32
        Dim configExtras As Int32
        Dim configGratificacion As Int32

        dtConfigNave = objBuNe.ConfiguracionFiniquitoNave(CInt(idColaboradorFin.ToString))
        lblUtilidadesActual.Text = "Utilidades " & Year(CDate(DPFecha.Value))
        lblUtilidadesAnterior.Text = "Utilidades " & Year(CDate(DPFecha.Value)) - 1

        'Obtenemos configuración de nave
        If dtConfigNave.Rows.Count > 0 Then
            configUtilidades = dtConfigNave.Rows(0).Item("cffn_utilidades")
        Else
            configUtilidades = 1
        End If
        If dtConfigNave.Rows.Count > 0 Then
            configGratificacion = dtConfigNave.Rows(0).Item("cffn_gratificacion")
        Else
            configGratificacion = 1
        End If
        If dtConfigNave.Rows.Count > 0 Then
            configExtras = dtConfigNave.Rows(0).Item("cffn_extras")
        Else
            configExtras = 1
        End If
        If dtConfigNave.Rows.Count > 0 Then
            configAguinaldo = dtConfigNave.Rows(0).Item("cffn_aguinaldo")
        Else
            configAguinaldo = 1
        End If

        'Ocultamos controles si confir es 0
        If configUtilidades = 0 Then
            lblUtilidadesActual.Visible = False
            lblUtilidadesAnterior.Visible = False
            Pesos3.Visible = False
            Label8.Visible = False
            txtUtilidadesActual.Visible = False
            txtUtilidadesAnterior.Visible = False
        End If

        If configAguinaldo = 0 Then
            Panel2.Visible = False
        End If

        If configExtras = 0 Then
            lblExtras.Visible = False
            Label2.Visible = False
            txtExtras.Visible = False
        End If

        If configGratificacion = 0 Then
            lblGraficacion.Visible = False
            Pesos4.Visible = False
            txtGratificacion.Visible = False
        End If


        editarSueldo = False
        If ACCION = "EDITAR" Then
            btnFiniquitar.Visible = False
            lblFiniquitar.Visible = False
            If estado = "A" Then
                btnGuardar.Visible = True
                lblGuardar.Visible = True
            Else
                btnGuardar.Visible = False
                lblGuardar.Visible = False
            End If
            llenarDatosEditar()

        ElseIf ACCION = "CONSULTA" Then
            btnFiniquitar.Visible = False
            lblFiniquitar.Visible = False
            If estado = "A" Then
                btnGuardar.Visible = True
                lblGuardar.Visible = True
            Else
                btnGuardar.Visible = False
                lblGuardar.Visible = False
            End If
            txtGratificacion.Enabled = False
            DPFecha.Enabled = False
            'txtJustificacion.Enabled = False
            cmbMotivoFiniquito.Enabled = False
            pnlSemanas.Enabled = False
            llenarDatosConsultar()
        Else
            btnFiniquitar.Visible = True
            lblFiniquitar.Visible = True
            btnGuardar.Visible = False
            lblGuardar.Visible = False
        End If
        editarSueldo = True
    End Sub

    Public Sub llenarDatosConsultar()

        Dim DatosGenerales As New Entidades.ColaboradorNomina
        Dim DatosReales As New Entidades.ColaboradorReal


        DatosGenerales = objFiniquitosBU.DatosGeneralesColaborador(idColaboradorFin)
        DatosReales = objFiniquitosBU.DatosRealesColaborador(idColaboradorFin)


        If CBool(DatosGenerales.PAsegurado) Then
            lblEstatusSeguroDato.Text = "SI"
        Else
            lblEstatusSeguroDato.Text = "NO"
        End If

        'Cambio Realizado por Alejandra R. Solicitado por el Sr. Fidel 
        If DatosReales.PTipoPago = "DESTAJO" Or DatosReales.PTipoPago = "POR BANDA" Or DatosReales.PTipoPago = "SALARIO" Then
            pnlSemanas.Visible = False
        End If

        IdColaborador = idColaboradorFin
        idNaveEmpleado = idNaveEmpleadoFin
        puesto = puestoFin
        btnBuscarEmpleado.Visible = False
        lblBuscarEmpleado.Visible = False
        txtJustificacion.Text = JustificacionFin
        chkRecontratar.Checked = recontratarFin
        DPFecha.Value = fechaBajaFin
        lblNomTrabajadorDato.Text = nombreEmpleadoFin
        lblDepartamentoDato.Text = departamentoFin
        lblPuestoDato.Text = puestoFin
        lblFechaIngresoDato.Text = fechaIngreso

        dias = antiguedaddias
        meses = antiguedadmeses
        anios = antiguedadanios
        lblAnti.Text = antiguedadanios + "   Años  " + antiguedadmeses + "   Meses    " + antiguedaddias + "   Dias"

        If IdColaborador > 0 Then
            Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
            Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
            listaMotivos = objBU.MotivosFiniquitoSegunNave(idNaveEmpleado)
            listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
            If listaMotivos.Count > 0 Then
                cmbMotivoFiniquito.DataSource = listaMotivos
                cmbMotivoFiniquito.DisplayMember = "PNombre"
                cmbMotivoFiniquito.ValueMember = "PMotivoFiniquitoId"
            End If
            cmbMotivoFiniquito.SelectedValue = motivoFin
        Else
            cmbMotivoFiniquito.DataSource = Nothing
        End If

        lblTipoPagoDato.Text = DatosReales.PTipoPago
        If DatosReales.PTipoPago = "SALARIO" Then
            txtSemana1.Value = CInt(sueldosemana1)
            txtSemana2.Value = CInt(sueldosemana2)
            txtSemana3.Value = CInt(sueldosemana3)
            txtSemana4.Value = CInt(sueldosemana4)
        End If

        txtDiasTrabajadorCorresponde.Text = CDbl(diasvacaciones).ToString("N2")
        If diasvacaciones <= 0 Then
            txtTotalVacaciones.Text = 0
            txtPrimaVacacional.Text = 0
            txtTotalVacTotal.Text = 0
            totalvacaciones = 0
            primavacacional = 0
        End If

        If utilidadesanterior = "" Then
            utilidadesanterior = 0
        End If

        txtTotalAguinaldo.Text = CDbl(totalaguinaldo).ToString("N2")
        txtTotalVacTotal.Text = CDbl(CDbl(totalvacaciones) + CDbl(primavacacional)).ToString("N2")
        txtPrimaVacacional.Text = CDbl(primavacacional).ToString("N2")
        txtGratificacion.Text = Math.Round(CDbl(gratificacionFin)).ToString("N0")
        txtLiquidacion.Text = Math.Round(CDbl(totalfiniquito)).ToString("N0")
        txtAhorrro.Text = Math.Round(CDbl(ahorroFin)).ToString("N0")
        txtPrestamo.Text = Math.Round(CDbl(prestamoFin)).ToString("N0")
        txtUtilidades.Text = Math.Round(CDbl(utilidades)).ToString("N0")
        txtUtilidadesActual.Text = Math.Round(CDbl(utilidades) - CDbl(utilidadesanterior)).ToString("N0")
        txtUtilidadesAnterior.Text = Math.Round(CDbl(utilidadesanterior)).ToString("N0")
        txtSubtotal.Text = Math.Round(CDbl(subtotalfiniquito)).ToString("N0")
        txtTotalEntregar.Text = Math.Round(CDbl(totalentregar)).ToString("N0")

        If CInt(txtTotalEntregar.Text) < 0 Then
            txtTotalEntregar.ForeColor = Color.Red
            txtTotalEntregar.BackColor = SystemColors.Control
        Else
            txtTotalEntregar.ForeColor = Color.Black
        End If
        lblFechaEntregaDato.Text = fechaAutorizo

        If anioutilidades = Nothing Then
            lblUtilidadesActual.Text = "Utilidades " & Year(CDate(DPFecha.Value))
        Else
            lblUtilidadesActual.Text = "Utilidades " & anioutilidades
        End If
        If anioutilidadesanterior = Nothing Then
            lblUtilidadesAnterior.Text = "Utilidades " & Year(CDate(DPFecha.Value)) - 1
        Else
            lblUtilidadesAnterior.Text = "Utilidades " & anioutilidadesanterior
        End If

        LblSueldoCal.Text = CDbl(salariosemanal).ToString("N2")
        lblSueldoDiarioCal.Text = CDbl(salariodiario).ToString("N2")
        txtMesesTrabajados.Text = CDbl(mesesaguinaldo).ToString("N2")
        txtDiasCorrespondenSegunMeses.Text = CDbl(diasaguinaldo).ToString("N2")
        txtDiasvacacionesCorresponden.Text = CDbl(mesesvacaciones).ToString("N2")

        txtTotalVacaciones.Text = CDbl(totalvacaciones).ToString("N2")
        txtPrimaVacacional.Text = CDbl(primavacacional).ToString("N2")
        txtExtras.Text = CDbl(extras).ToString("N0")

        lblSueldo.Text = " "
        lblSueldo.Text = "Sueldo Base"



        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(IdColaborador)
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
            picFotoColaborador.Image = Image.FromStream(Stream)
            picFotoColaborador.BackgroundImageLayout = ImageLayout.Zoom
        Catch ex As Exception
        End Try
    End Sub

    Public Sub llenarDatosEditar()

        Dim DatosGenerales As New Entidades.ColaboradorNomina
        Dim DatosReales As New Entidades.ColaboradorReal
        DatosGenerales = objFiniquitosBU.DatosGeneralesColaborador(idColaboradorFin)
        DatosReales = objFiniquitosBU.DatosRealesColaborador(idColaboradorFin)

        If CBool(DatosGenerales.PAsegurado) Then
            lblEstatusSeguroDato.Text = "SI"
        Else
            lblEstatusSeguroDato.Text = "NO"
        End If
        If DatosReales.PTipoPago = "DESTAJO" Or DatosReales.PTipoPago = "POR BANDA" Then
            pnlSemanas.Visible = True
        ElseIf DatosReales.PTipoPago = "SALARIO" Then
            pnlSemanas.Visible = False
        End If

        IdColaborador = idColaboradorFin
        idNaveEmpleado = idNaveEmpleadoFin
        puesto = puestoFin
        btnBuscarEmpleado.Visible = False
        lblBuscarEmpleado.Visible = False
        txtJustificacion.Text = JustificacionFin
        chkRecontratar.Checked = recontratarFin
        lblNomTrabajadorDato.Text = nombreEmpleadoFin
        lblDepartamentoDato.Text = departamentoFin
        lblPuestoDato.Text = puestoFin
        lblFechaIngresoDato.Text = fechaIngreso

        dias = antiguedaddias
        meses = antiguedadmeses
        anios = antiguedadanios
        lblAnti.Text = antiguedadanios + "   Años  " + antiguedadmeses + "   Meses    " + antiguedaddias + "   Dias"

        If IdColaborador > 0 Then
            Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
            Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
            listaMotivos = objBU.MotivosFiniquitoSegunNave(idNaveEmpleado)
            listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
            If listaMotivos.Count > 0 Then
                cmbMotivoFiniquito.DataSource = listaMotivos
                cmbMotivoFiniquito.DisplayMember = "PNombre"
                cmbMotivoFiniquito.ValueMember = "PMotivoFiniquitoId"
            End If
            cmbMotivoFiniquito.SelectedValue = motivoFin
        Else
            cmbMotivoFiniquito.DataSource = Nothing
        End If

        lblTipoPagoDato.Text = DatosReales.PTipoPago
        If DatosReales.PTipoPago <> "SALARIO" Then
            txtSemana1.Value = CInt(sueldosemana1)
            txtSemana2.Value = CInt(sueldosemana2)
            txtSemana3.Value = CInt(sueldosemana3)
            txtSemana4.Value = CInt(sueldosemana4)
        End If

        txtAhorrro.Text = CDbl(ahorroFin).ToString("N0")
        LblSueldoCal.Text = CDbl(salariosemanal).ToString("N2")
        lblSueldoDiarioCal.Text = CDbl(salariodiario).ToString("N2")
        DPFecha.Value = fechaBajaFin

        txtLiquidacion.Text = Math.Round(CDbl(totalfiniquito)).ToString("N0")
        txtPrestamo.Text = Math.Round(CDbl(prestamoFin)).ToString("N0")
        txtSubtotal.Text = Math.Round(CDbl(subtotalfiniquito)).ToString("N0")
        txtTotalEntregar.Text = Math.Round(CDbl(totalentregar)).ToString("N0")
        If CInt(txtTotalEntregar.Text) < 0 Then
            txtTotalEntregar.ForeColor = Color.Red
            txtTotalEntregar.BackColor = SystemColors.Control
        Else
            txtTotalEntregar.ForeColor = Color.Black
        End If
        lblFechaEntregaDato.Text = fechaAutorizo
        txtMesesTrabajados.Text = CDbl(mesesaguinaldo).ToString("N2")
        'txtDiasCorrespondenSegunMeses.Text = CDbl(diasaguinaldo).ToString("N2")
        txtDiasvacacionesCorresponden.Text = CDbl(mesesvacaciones).ToString("N2")
        txtDiasTrabajadorCorresponde.Text = CDbl(diasvacaciones).ToString("N2")
        txtTotalVacaciones.Text = CDbl(totalvacaciones).ToString("N2")
        txtPrimaVacacional.Text = CDbl(primavacacional).ToString("N2")
        txtGratificacion.Text = Math.Round(CDbl(gratificacionFin)).ToString("N0")

        txtExtras.Text = CDbl(extras).ToString("N0")

        Operaciones()

        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(IdColaborador)
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
            picFotoColaborador.Image = Image.FromStream(Stream)
            picFotoColaborador.BackgroundImageLayout = ImageLayout.Zoom
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub llenarDatosEditar()
    '    IdColaborador = idColaboradorFin
    '    idNaveEmpleado = idNaveEmpleadoFin
    '    puesto = puestoFin
    '    btnBuscarEmpleado.Visible = False
    '    lblBuscarEmpleado.Visible = False
    '    txtJustificacion.Text = JustificacionFin
    '    chkRecontratar.Checked = recontratarFin
    '    lblNomTrabajadorDato.Text = nombreEmpleadoFin
    '    lblDepartamentoDato.Text = departamentoFin
    '    lblPuestoDato.Text = puestoFin
    '    txtAhorrro.Text = CDbl(ahorroFin).ToString("N2")
    '    txtPrestamo.Text = CDbl(prestamoFin).ToString("N2")
    '    Dim EntidadArchivos As New Entidades.ColaboradorExpediente
    '    Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
    '    EntidadArchivos = ObjArchivosBU.CredencialColaborador(IdColaborador)
    '    Try
    '        Dim objFTP As New Tools.TransferenciaFTP
    '        Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    '        request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
    '        Dim Carpeta As String = ""
    '        Dim tabla() As String
    '        tabla = Split(EntidadArchivos.PCarpeta, "\")
    '        For n = 0 To UBound(tabla, 1)
    '            Carpeta += tabla(n) + "/"
    '        Next

    '        Dim Stream As System.IO.Stream
    '        Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
    '        picFotoColaborador.Image = Image.FromStream(Stream)
    '        picFotoColaborador.BackgroundImageLayout = ImageLayout.Zoom
    '    Catch ex As Exception

    '    End Try
    '    If IdColaborador > 0 Then
    '        Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
    '        Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
    '        listaMotivos = objBU.MotivosFiniquitoSegunNave(idNaveEmpleado)
    '        listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
    '        If listaMotivos.Count > 0 Then
    '            cmbMotivoFiniquito.DataSource = listaMotivos
    '            cmbMotivoFiniquito.DisplayMember = "PNombre"
    '            cmbMotivoFiniquito.ValueMember = "PMotivoFiniquitoId"
    '        End If
    '        cmbMotivoFiniquito.SelectedValue = motivoFin
    '        DPFecha.Value = fechaBajaFin
    '        Operaciones()
    '    Else
    '        cmbMotivoFiniquito.DataSource = Nothing
    '    End If
    '    Operaciones()
    '    txtGratificacion.Text = gratificacionFin
    'End Sub

    Public Sub cargaEditar()
        idNaveEmpleado = 0
        IdColaborador = 0
        puesto = ""

        idNaveEmpleado = idNaveEmpleadoFin
        IdColaborador = idColaboradorFin
        puesto = puestoFin
        lblNomTrabajadorDato.Text = nombreEmpleadoFin
        lblDepartamentoDato.Text = departamentoFin
        txtAhorrro.Text = CDbl(ahorroFin).ToString("N2")

        DPFecha.Enabled = True
        txtSemana1.Value = "0"
        txtSemana2.Value = "0"
        txtSemana3.Value = "0"
        txtSemana4.Value = "0"
        txtAhorrro.Text = "0"
        txtUtilidades.Text = "0"
        txtSubtotal.Text = "0"
        txtPrestamo.Text = "0"
        txtJustificacion.Text = ""
        txtTotalEntregar.Text = "0"

        txtUtilidades.Text = FormatNumber(0, 2)
        txtPrestamo.Text = FormatNumber(0, 2)
        txtPrestamo.Text = FormatNumber(txtPrestamo.Text, 2)

        Dim EntidadArchivos As New Entidades.ColaboradorExpediente
        Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
        EntidadArchivos = ObjArchivosBU.CredencialColaborador(IdColaborador)
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
            picFotoColaborador.Image = Image.FromStream(Stream)
            picFotoColaborador.BackgroundImageLayout = ImageLayout.Zoom
        Catch ex As Exception

        End Try

        If IdColaborador > 0 Then
            Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
            Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
            listaMotivos = objBU.MotivosFiniquitoSegunNave(idNaveEmpleado)
            listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
            If listaMotivos.Count > 0 Then
                cmbMotivoFiniquito.DataSource = listaMotivos
                cmbMotivoFiniquito.DisplayMember = "PNombre"
                cmbMotivoFiniquito.ValueMember = "PMotivoFiniquitoId"
            End If
            cmbMotivoFiniquito.SelectedValue = motivoFin
            Operaciones()
        Else
            cmbMotivoFiniquito.DataSource = Nothing
        End If

    End Sub

    Public Sub Operaciones()
        '----------------Caja de Ahorro y prestamos-------------------
        Dim objCA As New CajaColaboradorBU
        Dim CantidadAhorro As Int32
        Dim CantidadPrestamo As Int32
        Dim objDeducciones As New DeduccionesBU
        Dim cantidadDeduccion As Int32
        Dim DatosGenerales As New Entidades.ColaboradorNomina
        Dim DatosReales As New Entidades.ColaboradorReal
        Dim DatosFiniquito As New DataTable
        Dim totalMesesInicio As Double = 0
        Dim totalDiasInicio As Int32 = 0
        Dim totalDiasInicioVacacion As Int32 = 0
        Dim totalMesesInicioVacacion As Double = 0
        Dim FechaCorte As Date = Today
        Dim mesestrabajo As Double
        Dim mesestrabajoVacaciones As Double = 0
        Dim ConfiguracionNave As New Entidades.ConfiguracionNaveNomina
        Dim objConfNaves As New ConfiguracionNaveNominaBU


        If ACCION <> "EDITAR" Then
            CantidadAhorro = objCA.ConsultarCajaDeAhorroSaldo(IdColaborador, idNaveEmpleado)
            txtAhorrro.Text = CDbl(CantidadAhorro).ToString("N0")
            CantidadPrestamo = objFiniquitosBU.ConsultaDePrestamoparaLiquidacion(IdColaborador, idNaveEmpleado)
            cantidadDeduccion = objDeducciones.ConsultaDeduccionesparaLiquidacion(IdColaborador)
            txtPrestamo.Text = CDbl(CantidadPrestamo + cantidadDeduccion).ToString("N0")
        End If

        '---------------------------------------------------------
        'Llenar Tablas de datos
        DatosGenerales = objFiniquitosBU.DatosGeneralesColaborador(IdColaborador)
        DatosReales = objFiniquitosBU.DatosRealesColaborador(IdColaborador)
        DatosFiniquito = objFiniquitosBU.DatosCalculoFiniquito(IdColaborador, CDate(DPFecha.Value))
        ConfiguracionNave = objConfNaves.buscarConfiguracionNave(idNaveEmpleado)

        'Reetiquetado de labels
        lblUtilidadesActual.Text = "Utilidades " & Year(CDate(DPFecha.Value))
        lblUtilidadesAnterior.Text = "Utilidades " & (Year(CDate(DPFecha.Value)) - 1)
        lblFechaIngresoDato.Text = DatosReales.PFecha
        lblPuestoDato.Text = puesto
        lblTipoPagoDato.Text = DatosReales.PTipoPago
        LblSueldoCal.Text = FormatNumber(DatosReales.PCantidad, 2)
        If CBool(DatosGenerales.PAsegurado) Then
            lblEstatusSeguroDato.Text = "SI"
        Else
            lblEstatusSeguroDato.Text = "NO"
        End If
        If lblTipoPagoDato.Text = "POR BANDA" Or lblTipoPagoDato.Text = "DESTAJO" Then
            If ACCION <> "EDITAR" Then
                lblSueldo.Text = " "
                lblSueldo.Text = "Sueldo Base"
            End If
        End If

        antiguedadArray = objFiniquitosBU.CalcularAntiguedad(CDate(DatosReales.PFecha).ToShortDateString, CDate(DPFecha.Value).ToShortDateString)
        anios = antiguedadArray(0)
        meses = antiguedadArray(1)
        dias = antiguedadArray(2)
        lblAnti.Text = anios.ToString + "   Años  " + meses.ToString + "   Meses    " + dias.ToString + "   Dias"

        'Recálculos configurables
        If idNaveEmpleado = 61 Then
            totalDiasInicioVacacion = DateDiff(DateInterval.Day, CDate(Year(Now).ToString + "-04-01"), CDate(DPFecha.Value))
            totalDiasInicio = DateDiff(DateInterval.Day, CDate(DatosReales.PFecha), CDate(DPFecha.Value))
        Else
            totalDiasInicioVacacion = DateDiff(DateInterval.Day, CDate(DatosReales.PFecha), CDate(DPFecha.Value))
            totalDiasInicio = DateDiff(DateInterval.Day, CDate(DatosReales.PFecha), CDate(DPFecha.Value))
        End If
        totalMesesInicio = CDbl(totalDiasInicio / 30.4).ToString("N2")
        totalMesesInicioVacacion = CDbl(totalDiasInicioVacacion / 30.4).ToString("N2")
        diasvacaciones = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("DiasVacacionesFiniquito").ToString), 2)
        fechaAguinaldo = objFiniquitosBU.obtenerFechaCreacionAguinaldo(IdColaborador)
        'Cambio Realizado por Alejandra R. Solicitado por el Sr. Fidel 
        If DatosReales.PTipoPago = "DESTAJO" Or DatosReales.PTipoPago = "POR BANDA" Or DatosReales.PTipoPago = "SALARIO" Then
            pnlSemanas.Visible = False
        End If
        'Validacion si el momento actual es el mismo año del ingreso del colaborador (menos de 1 año)        
        If CDate(DatosReales.PFecha).Year = Date.Now.Year Then
            If IsDBNull(fechaAguinaldo) = False Then
                If CDate(fechaAguinaldo) < CDate(DatosReales.PFecha).ToShortDateString Then
                    fechaAguinaldo = CDate(DatosReales.PFecha).ToShortDateString
                End If
                mesestrabajo = ((DateDiff("d", CDate(fechaAguinaldo).ToShortDateString, CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
            Else
                mesestrabajo = ((DateDiff("d", CDate(DatosReales.PFecha).ToShortDateString, CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
            End If

        Else
            If IsDBNull(fechaAguinaldo) = False Then
                If Year(fechaAguinaldo) = Year(DateTime.Now) And Month(fechaAguinaldo) = 12 Then
                    mesestrabajo = 0
                Else
                    If idNaveEmpleado = 61 Then
                        Dim anioVacaciones As Int32 = DPFecha.Value.Year
                        If DPFecha.Value <= CDate("01/04/" + DPFecha.Value.Year.ToString) Then
                            anioVacaciones -= 1
                        End If
                        If anioVacaciones = DPFecha.Value.Year Then
                            mesestrabajoVacaciones = ((DateDiff("d", CDate(anioVacaciones.ToString + "-04-01"), CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
                        ElseIf anioVacaciones < DPFecha.Value.Year Then
                            If CDate(DatosReales.PFecha) <= CDate(anioVacaciones.ToString + "-04-01") Then
                                mesestrabajoVacaciones = ((DateDiff("d", CDate(anioVacaciones.ToString + "-04-01"), CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
                            Else
                                mesestrabajoVacaciones = ((DateDiff("d", CDate(DatosReales.PFecha), CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
                            End If
                        End If
                        mesestrabajo = ((DateDiff("d", CDate(fechaAguinaldo).ToShortDateString, CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
                    Else
                        mesestrabajo = ((DateDiff("d", CDate(fechaAguinaldo).ToShortDateString, CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
                    End If
                End If
                If mesestrabajo < 0 Then
                    mesestrabajo = 0
                End If
            Else
                mesestrabajo = ((DateDiff("d", CDate("01/01/" + DPFecha.Value.Year.ToString), CDate(DPFecha.Value).ToShortDateString) + 1) / 30.4).ToString("N1")
            End If

        End If

        'Llenado de controles directos
        txtDiasCorresponden.Text = ConfiguracionNave.PConDiasAguinaldo
        txtDiasTrabajadorCorresponde.Text = FormatNumber(DatosFiniquito.Rows(0).Item("DiasVacacionesFiniquito"), 2)
        txtMesesTrabajados.Text = mesestrabajo

        'txtDiasCorrespondenSegunMeses.Text = FormatNumber(((ConfiguracionNave.PConDiasAguinaldo / 12) * mesestrabajo), 2)
        txtDiasCorrespondenSegunMeses.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("DiasAguinaldo").ToString), 2)

        'Llenado dinámico de controles
        'If anios < 1 And meses < 2 Then
        '    txtDiasCorrespondenSegunMeses.Text = 0
        'End If

        If idNaveEmpleado = 61 Then
            txtDiasVacCorres.Text = objConfNaves.CalcularDiasSegunAntiguedad(idNaveEmpleado, (totalMesesInicioVacacion / 12))
        Else
            txtDiasVacCorres.Text = objConfNaves.CalcularDiasSegunAntiguedad(idNaveEmpleado, anios)
        End If
        If idNaveEmpleado = 61 Then
            txtDiasvacacionesCorresponden.Text = mesestrabajoVacaciones.ToString("N1")
        Else
            txtDiasvacacionesCorresponden.Text = mesestrabajo.ToString("N1")
        End If
        If diasvacaciones <= 0 Then
            txtTotalVacaciones.Text = 0
            txtPrimaVacacional.Text = 0
            txtTotalVacTotal.Text = 0
            totalvacaciones = 0
            primavacacional = 0
        Else
            txtTotalVacaciones.Text = FormatNumber(DatosFiniquito.Rows(0).Item("MontoVacaciones"), 0)
            txtPrimaVacacional.Text = FormatNumber(DatosFiniquito.Rows(0).Item("MontoPrima"), 0)
            txtTotalVacTotal.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("MontoVacaciones").ToString) + CDbl(DatosFiniquito.Rows(0).Item("MontoPrima").ToString), 0)
            totalvacaciones = FormatNumber(DatosFiniquito.Rows(0).Item("MontoVacaciones"), 0)
            primavacacional = FormatNumber(DatosFiniquito.Rows(0).Item("MontoPrima"), 0)
        End If
        If DatosReales.PCantidad.ToString <> "" Then
            If DatosReales.PCantidad.ToString > 0 Then
                sueldoDiario = FormatNumber(((DatosReales.PCantidad) / 7), 2)
                If txtDiasCorrespondenSegunMeses.Text = "" Then
                    txtDiasCorrespondenSegunMeses.Text = 0
                End If
                txtTotalAguinaldo.Text = FormatNumber((CType(txtDiasCorrespondenSegunMeses.Text, Double) * sueldoDiario), 2)
            Else
                MsgBox("El Empleado no tiene un sueldo registrado", MsgBoxStyle.Information, "")
            End If
        Else
            MsgBox("El Empleado no tiene un sueldo registrado", MsgBoxStyle.Information, "")
        End If
        costoDiario = sueldoDiario
        lblSueldoDiarioCal.Text = costoDiario.ToString("N2")

        calcularTotales()
    End Sub


    Public Sub OperacionesCambioSueldo()



        Dim divSem As Int32 = 0
        If CInt(txtSemana1.Value) > 0 Then
            divSem += 1
        End If
        If CInt(txtSemana2.Value) > 0 Then
            divSem += 1
        End If

        If CInt(txtSemana3.Value) > 0 Then
            divSem += 1
        End If

        If CInt(txtSemana4.Value) > 0 Then
            divSem += 1
        End If


        Dim total As Double = 0.0
        total = (CDbl(txtSemana1.Value) + CDbl(txtSemana2.Value) + CDbl(txtSemana3.Value) + CDbl(txtSemana4.Value)) / divSem

        LblSueldoCal.Text = FormatNumber(total, 2)
        If total.ToString <> "" Then
            If total.ToString > 0 Then
                sueldoDiario = FormatNumber(((total) / 7), 2)

                costoDiario = sueldoDiario
                If txtDiasCorrespondenSegunMeses.Text = "" Then
                    txtDiasCorrespondenSegunMeses.Text = 0
                End If
                txtTotalAguinaldo.Text = FormatNumber((CType(txtDiasCorrespondenSegunMeses.Text, Double) * sueldoDiario), 2)
            Else
                MsgBox("El Empleado no tiene un sueldo registrado", MsgBoxStyle.Information, "")
            End If
        Else
            MsgBox("El Empleado no tiene un sueldo registrado", MsgBoxStyle.Information, "")
        End If

        costoDiario = sueldoDiario
        lblSueldoDiarioCal.Text = costoDiario.ToString("N2")
        If ((anios > 0) Or (anios = 0 And meses >= 2)) Then
            txtTotalVacaciones.Text = FormatNumber(CType(txtDiasTrabajadorCorresponde.Text, Double) * sueldoDiario, 2)
            txtPrimaVacacional.Text = FormatNumber(((CType(txtDiasTrabajadorCorresponde.Text, Double) * sueldoDiario) * 0.25), 2)
            txtTotalVacTotal.Text = FormatNumber((CType(txtTotalVacaciones.Text, Double) + CType(txtPrimaVacacional.Text, Double)), 2)
        Else
            txtTotalVacaciones.Text = "0.0"
            txtPrimaVacacional.Text = "0.0"
            txtTotalVacTotal.Text = "0.0"
        End If

        calcularTotales()
    End Sub




    Public Sub Validacion()
        If txtGratificacion.Text = "" Then
            txtGratificacion.Text = 0
        End If
        If txtAhorrro.Text = "" Then
            txtAhorrro.Text = 0
        End If
        If txtUtilidades.Text = "" Then
            txtUtilidades.Text = 0
        End If
        If txtPrestamo.Text = "" Then
            txtPrestamo.Text = 0
        End If
        If txtLiquidacion.Text = "" Then
            txtLiquidacion.Text = 0
        End If
        If txtExtras.Text = "" Then
            txtExtras.Text = 0
        End If
    End Sub

    Public Sub calcularTotales()
        Dim totGratificacion As Double = 0.0
        Dim mesesCalcular As Double = 0.0
        Dim total As Double = 0.0
        Dim extras As Double = 0.0
        Dim objConfNaves As New ConfiguracionNaveNominaBU
        Dim DatosFiniquito As New DataTable
        Dim dtUtilidadesNave As New DataTable
        dtUtilidadesNave = objConfNaves.ValidaUtilidadesNave(idNaveEmpleado)
        DatosFiniquito = objFiniquitosBU.DatosCalculoFiniquito(IdColaborador, CDate(DPFecha.Value))
        For Each row As DataRow In dtUtilidadesNave.Rows
            pasaValidacion = dtUtilidadesNave.Rows(0).Item("AñoCumplido")
        Next
        extras = txtExtras.Text
        If lblFechaIngresoDato.Text <> "" And lblFechaIngresoDato.Text <> "-" Then
            Dim totalMesesInicio As Int32 = 0
            Dim totalMesesInicioDecimales As Double = 0
            Dim totalDiasInicio As Int32 = 0
            totalDiasInicio = DateDiff(DateInterval.Day, CDate(lblFechaIngresoDato.Text), CDate(DPFecha.Value))
            totalMesesInicio = CDbl(totalDiasInicio / 30.4).ToString("N0")
            totalMesesInicioDecimales = CDbl(totalDiasInicio / 30.4).ToString("N1")
            totalfiniquito = Math.Round((CDbl(txtTotalAguinaldo.Text) + CDbl(txtTotalVacTotal.Text))).ToString("N0")
            txtLiquidacion.Text = Math.Round(CDbl(totalfiniquito)).ToString("N0")
            txtUtilidadesAnterior.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("UtilidadesAnterior").ToString), 0)
            txtUtilidadesActual.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("UtilidadesActual").ToString), 0)
            txtUtilidades.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("UtilidadesAnterior").ToString) + CDbl(DatosFiniquito.Rows(0).Item("UtilidadesActual").ToString), 0)
            utilidades = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("UtilidadesAnterior").ToString) + CDbl(DatosFiniquito.Rows(0).Item("UtilidadesActual").ToString), 0)
            txtGratificacion.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("MontoGratificacion").ToString), 0)
            gratificacionFin = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("MontoGratificacion").ToString), 0)
            Dim subtotal As Double = CDbl(txtLiquidacion.Text) + CDbl(txtAhorrro.Text) + CDbl(txtUtilidades.Text) + CDbl(txtGratificacion.Text)
            txtSubtotal.Text = Math.Round(subtotal).ToString("N0")
            total = Math.Round(subtotal - CDbl(txtPrestamo.Text)).ToString("N2") + CDbl(txtExtras.Text)
            txtTotalEntregar.Text = total.ToString("N0")
            txtExtras.Text = extras.ToString("N0")
            If CInt(txtTotalEntregar.Text) < 0 Then
                txtTotalEntregar.ForeColor = Color.Red
                txtTotalEntregar.BackColor = SystemColors.Control
            Else
                txtTotalEntregar.ForeColor = Color.Black
            End If
        End If
    End Sub

    Public Function validarFechaDiaHoy() As Boolean
        If DPFecha.Value.ToShortDateString = Date.Now.ToShortDateString Then
            Return False
        End If
        Return True
    End Function

    Public Function validarVacios() As Boolean
        lblMotivoFiniquito.ForeColor = Color.Black

        If idFiniquito = 0 Then
            Return False
        End If

        If cmbMotivoFiniquito.SelectedIndex = 0 Then
            lblMotivoFiniquito.ForeColor = Color.Red
            Return False
        End If

        Return True
    End Function


    Public Sub guardarCambiosEditar()
        Try
            Dim objFNBU As New Negocios.FiniquitosBU
            Dim objSolicitudBaja As New Contabilidad.Negocios.SolicitudBajaBU
            Dim DTSolicitudBaja As DataTable
            Dim SolicitudBajaID As Integer
            Dim SBColaboradorID As Integer
            Dim objFiniquitoBU As New Contabilidad.Negocios.FiniquitoFiscalBU
            Dim EntFinquitoFiscal As Entidades.FiniquitoFiscal

            If ACCION = "EDITAR" Then
                Dim entFin As New Entidades.Finiquitos
                Dim entMot As New Entidades.MotivosFiniquito
                entMot.PMotivoFiniquitoId = cmbMotivoFiniquito.SelectedValue
                entFin.PMotivoFiniquitoId = entMot
                entFin.PJustificacion = txtJustificacion.Text
                entFin.PFechaBaja = DPFecha.Value.ToShortDateString
                entFin.PAntiguedadDias = dias
                entFin.PAntiguedadMeses = meses
                entFin.PAntiguedadAnios = anios
                entFin.PSemana1 = txtSemana1.Value
                entFin.PSemana2 = txtSemana2.Value
                entFin.PSemana3 = txtSemana3.Value
                entFin.PSemana4 = txtSemana4.Value
                entFin.PSalario = CType(LblSueldoCal.Text, Double)
                entFin.PSalarioDiario = CType(lblSueldoDiarioCal.Text, Double)
                entFin.PMesesAguinaldo = txtMesesTrabajados.Text
                entFin.PDiasAguinaldo = txtDiasCorrespondenSegunMeses.Text
                entFin.PTotalAguinaldo = txtTotalAguinaldo.Text
                entFin.PMesesVacaciones = txtDiasvacacionesCorresponden.Text
                entFin.PDiasVacaciones = txtDiasTrabajadorCorresponde.Text
                entFin.PTotalVacaciones = txtTotalVacaciones.Text
                entFin.PAhorro = ahorroFin
                entFin.PUtilidades = txtUtilidades.Text
                entFin.PGratificacion = txtGratificacion.Text
                entFin.PSubtotal = txtSubtotal.Text
                entFin.PPrestamo = txtPrestamo.Text
                entFin.PTotalEntregar = txtTotalEntregar.Text
                entFin.PPrimaVacacional = txtPrimaVacacional.Text
                entFin.PDiasSegunAntiguedad = txtDiasVacCorres.Text
                entFin.PnoRecontratar = CBool(chkRecontratar.Checked)
                entFin.PTotalFiniquito = txtLiquidacion.Text
                entFin.PExtras = txtExtras.Text
                entFin.PUtilidadesAnterior = txtUtilidadesAnterior.Text
                entFin.PAnioUtilidadesAnterior = (Year(CDate(DPFecha.Value)) - 1)
                entFin.PAnioUtilidades = Year(CDate(DPFecha.Value))

                objFNBU.editarFiniquito(idFiniquito, entFin)
                DTSolicitudBaja = objSolicitudBaja.ObtenerSolicitudBajaPorFiniquitoRealID(idFiniquito)

                If DTSolicitudBaja.Rows.Count > 0 Then
                    SolicitudBajaID = DTSolicitudBaja.Rows(0).Item("baim_bajaimssid").ToString()
                    SBColaboradorID = DTSolicitudBaja.Rows(0).Item("baim_colaboradorid").ToString()

                    objSolicitudBaja.EditarSolicitudBaja(SolicitudBajaID, SBColaboradorID, DPFecha.Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Date.Now, "")

                    EntFinquitoFiscal = objFiniquitoBU.CalcularFinquitoFiscal(SBColaboradorID, DPFecha.Value, 0)
                    EntFinquitoFiscal.SolicitudBajaID = SolicitudBajaID
                    EntFinquitoFiscal.FechaCreacion = Date.Now
                    EntFinquitoFiscal.UsuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    EntFinquitoFiscal.ColaboradorID = SBColaboradorID
                    EntFinquitoFiscal.FinquitoFiscalID = DTSolicitudBaja.Rows(0).Item("baim_finiquitofiscalid").ToString
                    objFiniquitoBU.EditarFiniquitoFiscal(EntFinquitoFiscal)

                    'objFiniquitoBU.GuardarFiniquitoFiscal(EntFinquitoFiscal)

                Else
                    objSolicitudBaja.GuardarSolicitudBaja(SBColaboradorID, DPFecha.Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Date.Now, "", "INTERNO", SolicitudBajaID)
                End If


            ElseIf ACCION = "CONSULTA" Then
                objFNBU.editarFiniquitoCerrado(idFiniquito, txtLiquidacion.Text, txtSubtotal.Text, txtGratificacion.Text, txtJustificacion.Text, CBool(chkRecontratar.Checked))
            End If
            'If chkRecontratar.Checked = True Then
            '    enviar_correoNoRecontratar(idNaveEmpleado, "ENVIO_NOTIFICACION_NO_RECONTRATAR")
            'End If
            Dim objMensajeGuardar As New Tools.ExitoForm
            objMensajeGuardar.mensaje = "Registro correcto."
            objMensajeGuardar.ShowDialog()
        Catch ex As Exception
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "No se guardarón los cambios."
            objMensajeGuardar.ShowDialog()
        End Try
    End Sub

    Public Sub calcularTotalesEditaGratificacion()
        Dim DatosFiniquito As New DataTable
        If lblFechaIngresoDato.Text <> "" And lblFechaIngresoDato.Text <> "-" Then
            Dim totalMesesInicio As Int32 = 0
            Dim total As Double = 0.0
            Dim extras As Double = 0.0
            extras = txtExtras.Text
            ' pregunta con decimales o sin decimales ?
            Dim totalMesesInicioDecimales As Double = 0
            Dim totalDiasInicio As Int32 = 0
            Dim totGratificacion As Double = 0.0
            Dim mesesCalcular As Double = 0.0

            totalDiasInicio = DateDiff(DateInterval.Day, CDate(lblFechaIngresoDato.Text), CDate(DPFecha.Value))
            totalMesesInicio = CDbl(totalDiasInicio / 30.4).ToString("N0")
            totalMesesInicioDecimales = CDbl(totalDiasInicio / 30.4).ToString("N1")

            '[AALcaraz 2023-04-14] Cambio para calcular vacaciones y finiquito desde SP
            DatosFiniquito = objFiniquitosBU.DatosCalculoFiniquito(IdColaborador, CDate(DPFecha.Value))

            'txtLiquidacion.Text = (CDbl(txtTotalAguinaldo.Text) + CDbl(txtTotalVacTotal.Text)).ToString("N2")
            txtLiquidacion.Text = Math.Round((CDbl(txtTotalAguinaldo.Text) + CDbl(txtTotalVacTotal.Text))).ToString("N0")
            '[AALcaraz 2023-04-14] Aqui hay cambio para recalcular Utilidades, sale de SP
            txtUtilidades.Text = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("UtilidadesAnterior").ToString) + CDbl(DatosFiniquito.Rows(0).Item("UtilidadesActual").ToString), 0)
            utilidades = FormatNumber(CDbl(DatosFiniquito.Rows(0).Item("UtilidadesAnterior").ToString) + CDbl(DatosFiniquito.Rows(0).Item("UtilidadesActual").ToString), 0)
            'If anios >= 1 Then
            '    If idNaveEmpleado = 61 Or idNaveEmpleado = 64 Then
            '        txtUtilidades.Text = 0
            '    Else
            '        'Ticket número 11490 Solicitado a TI por Alma y finanzas.
            '        'txtUtilidades.Text = (CDbl(CDbl(LblSueldoCal.Text) * 0.6)).ToString("N0")
            '        txtUtilidades.Text = (CDbl(CDbl(LblSueldoCal.Text) * 0.3)).ToString("N0")
            '    End If
            'Else
            '    If meses >= 2 Then
            '        Dim utilidadProcentaje As Double = 0.0
            '        'Ticket número 11490 Solicitado a TI por Alma y finanzas.
            '        'utilidadProcentaje = (0.6 / 12) * totalMesesInicioDecimales
            '        utilidadProcentaje = (0.3 / 12) * totalMesesInicioDecimales
            '        txtUtilidades.Text = (CDbl(CDbl(LblSueldoCal.Text) * utilidadProcentaje)).ToString("N0")
            '    Else
            '        txtUtilidades.Text = "0.0"





            '    End If

            '    If idNaveEmpleado = 61 Or idNaveEmpleado = 64 Then
            '        txtUtilidades.Text = 0
            '    End If
            'End If
            'If pasaValidacion = 0 Then
            '    txtUtilidades.Text = 0
            'End If
            '[AAlcaraz] Fin Cambio

            Dim subtotal As Double = CDbl(txtLiquidacion.Text) + CDbl(txtAhorrro.Text) + CDbl(txtUtilidades.Text) + CDbl(txtGratificacion.Text)
            'txtSubtotal.Text = subtotal.ToString("N2")
            txtSubtotal.Text = subtotal.ToString("N0")
            total = Math.Round((subtotal - CDbl(txtPrestamo.Text))).ToString("N2") + CDbl(txtExtras.Text)
            txtTotalEntregar.Text = total.ToString("N0")
            txtExtras.Text = extras.ToString("N0")
            If CInt(txtTotalEntregar.Text) < 0 Then
                txtTotalEntregar.ForeColor = Color.Red
                txtTotalEntregar.BackColor = SystemColors.Control
            Else
                txtTotalEntregar.ForeColor = Color.Black
            End If
        End If
        txtGratificacion.Text = FormatNumber(txtGratificacion.Text, 0)
    End Sub

    Private Sub btnFiniquitar_Click(sender As Object, e As EventArgs) Handles btnFiniquitar.Click
        Dim SoliciutdBaja As New Contabilidad.Negocios.SolicitudBajaBU
        Dim objMensajeConfirma As New Tools.ConfirmarForm
        Dim EntFiniquitoReal As Entidades.Finiquitos


        Dim continuar As Boolean = True
        If validarFechaDiaHoy() = False Then
            Dim objmco As New Tools.ConfirmarForm
            objmco.mensaje = "La fecha de baja es la misma fecha de hoy ¿Desea continuar?"
            If objmco.ShowDialog = Windows.Forms.DialogResult.OK Then
                continuar = True
            Else
                continuar = False
            End If
        End If

        If continuar = True Then
            ''agregado validacion periodos de nomina fiscales
            Dim objBuNF As New Contabilidad.Negocios.SolicitudBajaBU
            Dim objAV As New FiniquitosBU
            If objAV.validaColaboradorAsegurado(IdColaborador) = 1 Then
                If objBuNF.validaIncapacidadColaborador(IdColaborador, DPFecha.Value.ToShortDateString) = 0 Then
                    If objBuNF.existePeriodoNominaBajas(IdColaborador, 2, DPFecha.Value.ToShortDateString) Then
                        continuar = True
                    Else
                        Dim advertencia As New AdvertenciaForm
                        advertencia.mensaje = "No es posible dar de alta el finiquito debido a que no existen periodos de nomina fiscales"
                        advertencia.ShowDialog()
                        continuar = False

                    End If
                Else
                    Dim advertencia As New AdvertenciaForm
                    advertencia.mensaje = "No es posible dar de alta el finiquito debido a que el colaborador cuenta con una incapacidad para la fecha de baja"
                    advertencia.ShowDialog()
                    continuar = False

                End If
            Else
                'Agregar validación de proceso de Alta IMSS
                If objAV.validaProcesoAlta(IdColaborador) Then
                    Dim advertencia As New AdvertenciaForm
                    advertencia.mensaje = "No es posible dar de alta el finiquito debido a que el colaborador tiene un Alta IMSS en proceso." _
                    & Environment.NewLine _
                    & "Favor de notificar al departamento de Contabilidad."
                    advertencia.ShowDialog()
                    continuar = False
                End If
            End If

        End If


        If continuar = True Then
            'Dim objMensajeConfirma As New Tools.ConfirmarForm
            objMensajeConfirma.mensaje = "¿Está seguro de solicitar el finiquito del colaborador?"
            If objMensajeConfirma.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim ComboMotivo As New Boolean
                ComboMotivo = False
                If (cmbMotivoFiniquito.Text <> "") Then
                    lblMotivoFiniquito.ForeColor = Color.Black
                Else
                    lblMotivoFiniquito.ForeColor = Color.Red
                    ComboMotivo = True
                End If
                If ComboMotivo = True Then
                    Dim FormularioError As New AdvertenciaForm
                    FormularioError.mensaje = "Seleccione un Motivo"
                    FormularioError.MdiParent = MdiParent
                    FormularioError.Show()
                Else
                    Dim ObjEntidadFiniquito As New Entidades.Finiquitos
                    Dim objColaborador As New Entidades.Colaborador
                    objColaborador.PColaboradorid = IdColaborador
                    ObjEntidadFiniquito.PColaboradorId = objColaborador
                    If cmbMotivoFiniquito.SelectedValue > 0 Then
                        Dim motivo As New Entidades.MotivosFiniquito
                        motivo.PMotivoFiniquitoId = CInt(cmbMotivoFiniquito.SelectedValue)
                        ObjEntidadFiniquito.PMotivoFiniquitoId = motivo
                    End If
                    ObjEntidadFiniquito.PJustificacion = txtJustificacion.Text
                    ObjEntidadFiniquito.PFechaBaja = DPFecha.Value
                    ObjEntidadFiniquito.PAntiguedadAnios = anios
                    ObjEntidadFiniquito.PAntiguedadMeses = meses
                    ObjEntidadFiniquito.PAntiguedadDias = dias
                    If txtSemana1.Value.ToString = "0" Then
                        ObjEntidadFiniquito.PSemana1 = 0
                        ObjEntidadFiniquito.PSemana2 = 0
                        ObjEntidadFiniquito.PSemana3 = 0
                        ObjEntidadFiniquito.PSemana4 = 0
                    Else
                        ObjEntidadFiniquito.PSemana1 = txtSemana1.Value
                        ObjEntidadFiniquito.PSemana2 = txtSemana2.Value
                        ObjEntidadFiniquito.PSemana3 = txtSemana3.Value
                        ObjEntidadFiniquito.PSemana4 = txtSemana4.Value
                    End If
                    If txtAhorrro.Text = "" Then
                        ObjEntidadFiniquito.PAhorro = 0
                    End If
                    If txtUtilidades.Text = "" Then
                        ObjEntidadFiniquito.PUtilidades = 0
                    End If
                    If txtUtilidadesAnterior.Text = "" Then
                        ObjEntidadFiniquito.PUtilidadesAnterior = 0
                    End If
                    If txtUtilidades.Text = 0 Then
                        ObjEntidadFiniquito.PUtilidades = 0
                    End If
                    If txtGratificacion.Text = "" Then
                        ObjEntidadFiniquito.PGratificacion = 0
                    End If

                    If txtPrestamo.Text = "" Then
                        ObjEntidadFiniquito.PPrestamo = 0
                    End If
                    If txtSubtotal.Text = "" Then
                        ObjEntidadFiniquito.PSubtotal = 0
                    Else
                        ObjEntidadFiniquito.PSubtotal = txtSubtotal.Text
                    End If
                    ObjEntidadFiniquito.PSalario = CType(LblSueldoCal.Text, Double)
                    ObjEntidadFiniquito.PSalarioDiario = CType(lblSueldoDiarioCal.Text, Double)
                    ObjEntidadFiniquito.PMesesAguinaldo = txtMesesTrabajados.Text
                    ObjEntidadFiniquito.PDiasAguinaldo = txtDiasCorrespondenSegunMeses.Text
                    ObjEntidadFiniquito.PMesesVacaciones = txtDiasvacacionesCorresponden.Text
                    ObjEntidadFiniquito.PDiasVacaciones = txtDiasTrabajadorCorresponde.Text
                    ObjEntidadFiniquito.PTotalAguinaldo = txtTotalAguinaldo.Text
                    ObjEntidadFiniquito.PTotalVacaciones = txtTotalVacaciones.Text
                    ObjEntidadFiniquito.PTotalFiniquito = txtLiquidacion.Text
                    ObjEntidadFiniquito.PAhorro = txtAhorrro.Text
                    ObjEntidadFiniquito.PUtilidades = txtUtilidades.Text
                    ObjEntidadFiniquito.PUtilidadesAnterior = txtUtilidadesAnterior.Text
                    ObjEntidadFiniquito.PGratificacion = txtGratificacion.Text
                    ObjEntidadFiniquito.PPrestamo = txtPrestamo.Text

                    If txtTotalEntregar.Text = "" Then
                        ObjEntidadFiniquito.PTotalEntregar = 0
                    Else
                        ObjEntidadFiniquito.PTotalEntregar = txtTotalEntregar.Text
                    End If
                    ObjEntidadFiniquito.PEstado = "A"
                    ObjEntidadFiniquito.PUsuarioCreoId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    ObjEntidadFiniquito.PDiasSegunAntiguedad = txtDiasVacCorres.Text
                    ObjEntidadFiniquito.PPrimaVacacional = txtPrimaVacacional.Text
                    ObjEntidadFiniquito.PNaveID = idNaveEmpleado
                    ObjEntidadFiniquito.PnoRecontratar = CBool(chkRecontratar.Checked)
                    ObjEntidadFiniquito.PExtras = txtExtras.Text
                    ObjEntidadFiniquito.PAnioUtilidadesAnterior = (Year(CDate(DPFecha.Value)) - 1)
                    ObjEntidadFiniquito.PAnioUtilidades = Year(CDate(DPFecha.Value))

                    Dim ColaboradorCorreo As New Entidades.Colaborador
                    ColaboradorCorreo.PNombre = lblNomTrabajadorDato.Text
                    Dim DepartamentoCorreo As New Entidades.Departamentos
                    DepartamentoCorreo.DNombre = lblDepartamento.Text
                    ColaboradorCorreo.PIDepartamento = DepartamentoCorreo
                    Dim objBU As New FiniquitosBU
                    Dim MensajeNegocios As String
                    MensajeNegocios = objBU.SolicitarFiniquito(ObjEntidadFiniquito, IdColaborador, "A")
                    If MensajeNegocios.Length = 0 Then
                        Dim FormularioMensaje As New ExitoForm
                        FormularioMensaje.mensaje = "Se solicitó el finiquito correctamente."
                        ListaFiniquitos.Add(ObjEntidadFiniquito)
                        enviar_correo(idNaveEmpleado, ListaFiniquitos, "ENVIO_NOTIFICACIONES_FINIQUITOS")
                        If chkRecontratar.Checked = True Then
                            enviar_correoNoRecontratar(idNaveEmpleado, "ENVIO_NOTIFICACION_NO_RECONTRATAR")
                        End If
                        FormularioMensaje.MdiParent = MdiParent
                        FormularioMensaje.Show()

                        'Crear solicitud de baja y calculo del finiquito fiscal
                        Dim objA As New FiniquitosBU

                        If objA.validaColaboradorAsegurado(IdColaborador) = 1 Then
                            EntFiniquitoReal = objBU.obtenerFiniquitoColaborador(IdColaborador)
                            SoliciutdBaja.GuardarSolicitudBaja(IdColaborador, DPFecha.Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Date.Now, "", "INTERNO", EntFiniquitoReal.PFiniquito)
                            ObjEntidadFiniquito.PColaboradorId.PNombre = lblNomTrabajadorDato.Text
                            enviar_correoContadores(ObjEntidadFiniquito)
                        End If

                        Me.Close()
                    Else
                        Dim FormularioMensaje As New AdvertenciaForm
                        FormularioMensaje.mensaje = MensajeNegocios
                        FormularioMensaje.MdiParent = MdiParent
                        FormularioMensaje.Show()
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub




    Private Sub DPFecha_ValueChanged(sender As Object, e As EventArgs) Handles DPFecha.ValueChanged
        If ACCION <> "CONSULTA" Then
            If IdColaborador > 0 Then
                Operaciones()
            End If
        End If
    End Sub

    Private Sub btnBuscarEmpleado_Click(sender As Object, e As EventArgs) Handles btnBuscarEmpleado.Click
        Dim empleadosForm As New BuscarEmpleadoForm
        idNaveEmpleado = 0
        IdColaborador = 0
        puesto = ""
        empleadosForm.grdBuscarEmpleado.Rows.Clear()
        If empleadosForm.ShowDialog = DialogResult.OK Then
            idNaveEmpleado = empleadosForm.PIdNaveEmpleado
            IdColaborador = empleadosForm.pseleccion
            puesto = empleadosForm.txtPuesto.Text
            lblNomTrabajadorDato.Text = empleadosForm.txtBuscarEmpleado.Text
            lblDepartamentoDato.Text = empleadosForm.txtDepartamento.Text
            empleadosForm.grdBuscarEmpleado.Rows.Clear()
            empleadosForm.grdBuscarEmpleado.Columns.Clear()
            empleadosForm.txtBuscarEmpleado.Text = ""
            DPFecha.Enabled = True
            chkRecontratar.Checked = False
            txtSemana1.Value = 0
            txtSemana2.Value = 0
            txtSemana3.Value = 0
            txtSemana4.Value = 0
            txtAhorrro.Text = "0"
            txtUtilidades.Text = "0"
            txtSubtotal.Text = "0"
            txtPrestamo.Text = "0"
            txtJustificacion.Text = ""
            txtTotalEntregar.Text = "0"
            txtAhorrro.Text = FormatNumber(0, 2)
            txtAhorrro.Text = FormatNumber(txtAhorrro.Text, 2)
            txtUtilidades.Text = FormatNumber(0, 2)
            txtPrestamo.Text = FormatNumber(0, 2)
            txtPrestamo.Text = FormatNumber(txtPrestamo.Text, 2)

            Dim EntidadArchivos As New Entidades.ColaboradorExpediente
            Dim ObjArchivosBU As New Negocios.EnviodeArchivosBU
            EntidadArchivos = ObjArchivosBU.CredencialColaborador(IdColaborador)
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
                picFotoColaborador.Image = Image.FromStream(Stream)
                picFotoColaborador.BackgroundImageLayout = ImageLayout.Zoom
            Catch ex As Exception

            End Try

            If IdColaborador > 0 Then
                Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
                Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
                listaMotivos = objBU.MotivosFiniquitoSegunNave(idNaveEmpleado)
                listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
                If listaMotivos.Count > 0 Then
                    cmbMotivoFiniquito.DataSource = listaMotivos
                    cmbMotivoFiniquito.DisplayMember = "PNombre"
                    cmbMotivoFiniquito.ValueMember = "PMotivoFiniquitoId"
                End If
                Operaciones()
            Else
                cmbMotivoFiniquito.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub txtGratificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGratificacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJustificacion.Focus()
        End If
    End Sub

    Private Sub txtGratificacion_LostFocus(sender As Object, e As EventArgs) Handles txtGratificacion.LostFocus
        If IsNumeric(txtGratificacion.Text) Then
            If txtGratificacion.Text = "" Then
                txtGratificacion.Text = "0"
            Else
                Validacion()
                calcularTotalesEditaGratificacion()
            End If
        Else
            Validacion()
            calcularTotales()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim continuar As Boolean = True
        Dim objSolicitudBaja As New Contabilidad.Negocios.SolicitudBajaBU

        If validarFechaDiaHoy() = False Then
            Dim objMensajeConfirma As New Tools.ConfirmarForm
            objMensajeConfirma.mensaje = "La fecha de baja es la misma fecha de hoy ¿Desea continuar?"
            If objMensajeConfirma.ShowDialog = Windows.Forms.DialogResult.OK Then
                continuar = True
            Else
                continuar = False
            End If
        End If

        If validarVacios() = True Then
            If continuar = True Then
                Dim objMensajeConfirma As New Tools.ConfirmarForm
                objMensajeConfirma.mensaje = "¿Está seguro de guardar los cambios?"
                If objMensajeConfirma.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarCambiosEditar()

                End If
            End If
        Else
            Dim objMensajeGuardar As New Tools.AdvertenciaForm
            objMensajeGuardar.mensaje = "Seleccione un motivo."
            objMensajeGuardar.ShowDialog()
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal Solicitudes As List(Of Entidades.Finiquitos), ByVal clave As String)
        Dim SumaTotal As New Double
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)
        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body {display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Solicitud de Finiquito <br> <font size=2>Usuario que Solicito : " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</font>" +
                                   " </div> <br></br>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "30%" + "'>Nombre</th>" +
                                        "<th width ='" + "15%" + "'>Departamento</th>" +
                                        "<th width ='" + "10%" + "'>Fecha de Solicitud</th>" +
                                        "<th width ='" + "10%" + "'>Fecha de Ingreso</th>" +
                                        "<th width ='" + "13%" + "'>Antiguedad</th>" +
                                        "<th width ='" + "10%" + "'>Fecha baja</th>" +
                                        "<th width ='" + "15%" + "'>Justificacion</th>" +
                                        "<th width ='" + "10%" + "'>Motivo</th>" +
                                        "<th width ='" + "10%" + "'>Aguinaldo</th>" +
                                        "<th width ='" + "10%" + "'>Vacaciones</th>" +
                                        "<th width ='" + "10%" + "'>Prima Vacacional</th>" +
                                        "<th width ='" + "10%" + "'>Total Vacaciones</th>" +
                                        "<th width ='" + "10%" + "'>Finiquito</th>" +
                                        "<th width ='" + "10%" + "'>Ahorro</th>" +
                                        "<th width ='" + "10%" + "'>Utilidades</th>" +
        "<th width ='" + "7%" + "'>Gratificacion</th>" +
        "<th width ='" + "7%" + "'>Subtotal</th>" +
        "<th width ='" + "7%" + "'>Prestamo</th>" +
        "<th width ='" + "7%" + "'>Extras</th>" +
        "<th width ='" + "7%" + "'>Total Entregar</th>" +
                                       "</thead>" +
                                       "<tbody>"
        For Each solicitud As Entidades.Finiquitos In ListaFiniquitos
            Email +=
                                        "<tr>" +
                                            "<td>" + lblNomTrabajadorDato.Text.ToString + "</td>" +
                                            "<td>" + lblDepartamentoDato.Text.ToString + "</td>" +
                                            "<td>" + Today.ToShortDateString + "</td>" +
        "<td>" + lblFechaIngresoDato.Text.ToString + "</td>" +
        "<td>" + lblAnti.Text.ToString.ToUpper + "</td>" +
        "<td>" + solicitud.PFechaBaja.ToShortDateString + "</td>" +
        "<td>" + solicitud.PJustificacion.ToString.ToUpper + "</td>" +
 "<td>" + cmbMotivoFiniquito.Text.ToString.ToUpper + "</td>" +
  "<td> $ " + txtTotalAguinaldo.Text.ToString + "</td>" +
  "<td> $ " + txtTotalVacaciones.Text.ToString + "</td>" +
   "<td>" + solicitud.PPrimaVacacional.ToString("C") + "</td>" +
    "<td> $ " + txtTotalVacTotal.Text.ToString + "</td>" +
     "<td> $" + txtLiquidacion.Text.ToString + "</td>" +
      "<td>" + solicitud.PAhorro.ToString("C") + "</td>" +
       "<td>" + solicitud.PUtilidades.ToString("C") + "</td>" +
        "<td>" + solicitud.PGratificacion.ToString("C") + "</td>" +
         "<td>" + solicitud.PSubtotal.ToString("C") + "</td>" +
          "<td>" + solicitud.PPrestamo.ToString("C") + "</td>" +
          "<td>" + txtExtras.Text.ToString + "</td>" +
           "<td>" + solicitud.PTotalEntregar.ToString("C") + "</td>"
            ' SumaTotal += solicitud.PMonto
        Next




        Email += "                 " +
"</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Solicitud de Finiquito", Email)
    End Sub


    Private Sub enviar_correoNoRecontratar(ByVal naveID As Integer, ByVal clave As String)
        Dim SumaTotal As New Double
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)
        Dim Email As String = "<html>" +
                                "<head>" +
                                  "<style type ='" + "text/css" + "'> body " +
                                  "{display: block; margin: 8px; background: #FFFFFF;}#header{	position: fixed;	height: 62px;	top: 0;	left: 0;	right: 0;	color: #003366;	font-family: Arial, Helvetica, sans-serif;	font-size: 18px;	font-weight: bold;}#leftcolumn{	float: left;	position: fixed;	width: 2%;	margin: 1%;	padding-top: 3%;	top: 0;	left: 0;	right: 0;}#content{	width: 90%;	position: fixed;	margin: 1% 5%;		padding-top: 3%;	padding-bottom: 1%;}#rightcolumn{	float: right;	width: 5%;	margin: 1%;			padding-top: 3%;}#footer{	position: fixed;	width: 100%;	heigt: 5%;	bottom: 0;	margin: 0;	padding: 0;	color: #FFFFFF;}table.tableizer-table { 	font-family: Arial, Helvetica, sans-serif;	font-size: 9px;} .tableizer-table td {	padding: 4px;	margin: 0px;	border: 1px solid #FFFFFF;	border-color: #FFFFFF;	border: 1px solid #CCCCCC;	width: 200px;} .tableizer-table tr {	padding: 4px;	margin: 0;	color: #003366;	font-weight: bold;	background-color: #transparent; 	opacity: 1;}.tableizer-table th {	background-color: #003366; 	color: #FFFFFF;	font-weight: bold;	height: 30px;	font-size: 10px;}A:link {	text-decoration:none;color:#FFFFFF;} A:visited {	text-decoration:none;color:#FFFFFF;} A:active {	text-decoration:none;color:#FFFFFF;} A:hover {	text-decoration:none;color:#006699;} </style>" +
                                  "</head>" +
                                  "<body>" +
                                   "<div id='" + "wrapper" + "'>" +
                                    "<div id='" + "header" + "'>" +
                                    "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Solicitud de Finiquito <br> <font size=2>Usuario que Solicito : " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</font>" +
                                   " </div> <br></br>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "30%" + "'>Nombre</th>" +
                                        "<th width ='" + "15%" + "'>Departamento</th>" +
                                        "<th width ='" + "10%" + "'>Fecha de Ingreso</th>" +
                                        "<th width ='" + "13%" + "'>Antiguedad</th>" +
                                        "<th width ='" + "10%" + "'>Fecha baja</th>" +
                                        "<th width ='" + "15%" + "'>Justificacion</th>" +
                                        "<th width ='" + "10%" + "'>Motivo</th>" +
                                       "</thead>" +
                                       "<tbody>" +
                                         "<tr>" +
                                            "<td>" + lblNomTrabajadorDato.Text.ToString + "</td>" +
                                            "<td>" + lblDepartamentoDato.Text.ToString + "</td>" +
                                            "<td>" + lblFechaIngresoDato.Text.ToString + "</td>" +
                                            "<td>" + lblAnti.Text.ToString.ToUpper + "</td>" +
                                            "<td>" + DPFecha.Value.ToShortDateString + "</td>" +
                                            "<td>" + txtJustificacion.Text + "</td>" +
                                            "<td>" + cmbMotivoFiniquito.Text.ToString.ToUpper + "</td>"
        ' SumaTotal += solicitud.PMonto
        Email += "                 " +
"</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Aviso de baja de persona no recontratable", Email)
    End Sub

    Private Sub txtSemana1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSemana2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSemana3_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSemana4_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSemana1_LostFocus(sender As Object, e As EventArgs) Handles txtSemana1.LostFocus
        If txtSemana1.Text.ToString = "" Then
            txtSemana1.Text = 0
        End If
    End Sub


    Private Sub txtSemana1_ValueChanged(sender As Object, e As EventArgs) Handles txtSemana1.ValueChanged
        If editarSueldo = True Then
            OperacionesCambioSueldo()
        End If
    End Sub

    Private Sub txtSemana2_LostFocus(sender As Object, e As EventArgs) Handles txtSemana2.LostFocus
        If txtSemana2.Text.ToString = "" Then
            txtSemana2.Value = 0
        End If
    End Sub

    Private Sub txtSemana2_ValueChanged(sender As Object, e As EventArgs) Handles txtSemana2.ValueChanged
        If editarSueldo = True Then
            OperacionesCambioSueldo()
        End If
    End Sub

    Private Sub txtSemana3_LostFocus(sender As Object, e As EventArgs) Handles txtSemana3.LostFocus
        If txtSemana3.Text.ToString = "" Then
            txtSemana3.Value = 0
        End If
    End Sub

    Private Sub txtSemana3_ValueChanged(sender As Object, e As EventArgs) Handles txtSemana3.ValueChanged
        If editarSueldo = True Then
            OperacionesCambioSueldo()
        End If
    End Sub

    Private Sub txtSemana4_LostFocus(sender As Object, e As EventArgs) Handles txtSemana4.LostFocus
        If txtSemana4.Text.ToString = "" Then
            txtSemana4.Value = 0
        End If
    End Sub

    Private Sub txtSemana4_ValueChanged(sender As Object, e As EventArgs) Handles txtSemana4.ValueChanged
        If editarSueldo = True Then
            OperacionesCambioSueldo()
        End If
    End Sub

    Private Sub txtExtras_KeyDown(sender As Object, e As KeyEventArgs) Handles txtExtras.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(txtExtras.Text) Then
                If txtExtras.Text = "" Then
                    txtExtras.Text = "0"
                Else
                    Validacion()
                    calcularTotalesEditaGratificacion()
                End If
            Else
                Validacion()
                calcularTotales()
            End If
        End If
    End Sub

    Private Sub txtExtras_LostFocus(sender As Object, e As EventArgs) Handles txtExtras.LostFocus
        If IsNumeric(txtExtras.Text) Then
            If txtExtras.Text = "" Then
                txtExtras.Text = "0"
            Else
                Validacion()
                calcularTotalesEditaGratificacion()
            End If
        Else
            Validacion()
            calcularTotales()
        End If
    End Sub

    Private Sub lblUtilidades_Click(sender As Object, e As EventArgs) Handles lblUtilidadesAnterior.Click

    End Sub

    Private Sub enviar_correoContadores(solicitud As Entidades.Finiquitos)
        Dim correo As New Tools.Correo
        Dim objBU As New Contabilidad.Negocios.FiniquitoFiscalBU
        Dim objNavesBU As New Framework.Negocios.NavesBU
        Dim dtDatosCorreo As New DataTable
        Dim destinatarios As String = String.Empty
        Dim correoEnvia As String = String.Empty
        Dim mensaje As String = String.Empty
        Dim asunto As String = String.Empty
        Dim nave As String = String.Empty

        nave = objNavesBU.buscarNaves(solicitud.PNaveID).PNombre
        dtDatosCorreo = objBU.consultaDatosCorreo(solicitud.PColaboradorId.PColaboradorid, solicitud.PNaveID)
        If Not dtDatosCorreo Is Nothing Then
            If dtDatosCorreo.Rows().Count > 0 Then
                If dtDatosCorreo.Rows(0)("destinatarios").ToString <> "" Then
                    mensaje = cuerpoCorreoContadores(solicitud, nave)
                    asunto = "Baja de colaborador " & nave
                    destinatarios = dtDatosCorreo.Rows(0)("destinatarios").ToString
                    correoEnvia = dtDatosCorreo.Rows(0)("correoEnvia").ToString

                    correo.EnviarCorreoHtml(destinatarios, correoEnvia, asunto, mensaje)
                End If
            End If
        End If
    End Sub

    Private Function cuerpoCorreoContadores(ByVal solicitud As Entidades.Finiquitos, ByVal nave As String) As String
        Dim mensaje As String = String.Empty
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        mensaje = "<html>" & vbCrLf
        mensaje &= "<head>" & vbCrLf
        mensaje &= "<style type ='text/css'>" & vbCrLf &
                "body {display:block; margin:8px; background:#FFFFFF;}" &
                "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                "A:link {text-decoration:none; color:#FFFFFF;}" &
                "A:visited {text-decoration:none; color:#FFFFFF;}" &
                "A:active {text-decoration:none; color:#FFFFFF;}" &
                "A:hover {text-decoration:none;color:#006699;} " & vbCrLf
        mensaje &= "</style>" & vbCrLf
        mensaje &= "</head>" & vbCrLf
        mensaje &= "<body>" & vbCrLf
        mensaje &= "<div id='wrapper'>" & vbCrLf &
                "<div id='header'>" & vbCrLf &
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Baja de Colaborador" &
                "</div>" & vbCrLf &
                "<div id='leftcolumn'></div>" & vbCrLf &
                "<div id='rightcolumn'></div>" & vbCrLf
        mensaje &= "<div id='content'>" & vbCrLf
        mensaje &= "<p>Se ha realizado la siguiente baja: </p>" & vbCrLf
        mensaje &= "<p>Colaborador <b>" & solicitud.PColaboradorId.PNombre & "</b></p>" & vbCrLf
        mensaje &= "<p>Fecha de baja <b>" & solicitud.PFechaBaja.ToString("dd/MM/yyyy") & "</b></p>" & vbCrLf
        mensaje &= "<p>Fecha de solicitud <b>" & Now.Date.ToString("dd/MM/yyyy") & "</b></p>" & vbCrLf
        mensaje &= "</div>" & vbCrLf
        mensaje &= "<div id='footer'></div>" & vbCrLf
        mensaje &= "</div>" & vbCrLf
        mensaje &= "</body>" & vbCrLf
        mensaje &= "</html>"

        Return mensaje
    End Function
End Class