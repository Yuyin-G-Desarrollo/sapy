Imports System.Windows.Forms

Public Class CambioPatronColaboradorForm
    Public idColaborador As Integer
    Public idNave As Integer
    Public patronOrigenId As Integer
    Public infonavit As Boolean
    Public nombre As String
    Public sdiAnterior As Double
    Public guardado As Boolean = False

    Dim patronDestinoId As Integer = 0
    Dim credInfonavit As Entidades.CreditoInfonavit = Nothing ''Crédito Infonavit
    Dim objCol As Entidades.AltaColaboradorIMSS

    Private Sub CambioPatronColaboradorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblColaborador.Text = nombre
        txtSDI.Text = sdiAnterior.ToString
        rdoInfonavitSI.Checked = infonavit
        rdoInfonavitNo.Checked = Not infonavit

        dtpFechaBaja.Value = Date.Now
        'solicitud de cambio ticket 18281
        'dtpFechaBaja.MinDate = Date.Now
        'dtpFechaBaja.MaxDate = Date.Now

        dtpFechaAlta.Value = Date.Now
        'solicitud de cambio ticket 18281
        'dtpFechaAlta.MinDate = Date.Now
        'dtpFechaAlta.MaxDate = Date.Now

        llenarComboPatron()
        validaFechaNomina()
    End Sub

    Private Sub validaFechaNomina()
        Dim objBu As New Negocios.BajaCambioPatronBU

        If objBu.validaFechaCierreNominaReal(idNave) Then
            btnAceptar.Enabled = False
            lblAdvertencia.Visible = True
        Else
            btnAceptar.Enabled = True
            lblAdvertencia.Visible = False
        End If

    End Sub

    Private Sub cargarDatosInfonavit()
        Dim objMensajeError As New Tools.ErroresForm
        Dim msjError As String = String.Empty
        Dim objCalcInfonavit As New CalculoInfonavit
        credInfonavit = New Entidades.CreditoInfonavit

        Dim porcentajeDescuento As Double = objCol.PValorDescuento / 100
        Select Case objCol.PTipoDescuentoId
            Case "0"
            Case "1" 'PORCENTAJE
                credInfonavit = objCalcInfonavit.calcularDescuentoPorcentaje(CDbl(txtSDI.Text), porcentajeDescuento, patronDestinoId, dtpFechaAlta.Value)
            Case "2" 'CUOTAFIJA
                credInfonavit = objCalcInfonavit.calcularDescuentoCoutaFija(objCol.PValorDescuento, patronDestinoId, dtpFechaAlta.Value)
            Case "3" 'VECES SALARIO MÍNIMO
                credInfonavit = objCalcInfonavit.calcularDescuentoVecesSM(objCol.PValorDescuento, patronDestinoId, dtpFechaAlta.Value)
        End Select

        credInfonavit.CINumerocredito = objCol.PNumeroCredito
        credInfonavit.CIAplicatabladisminucion = objCol.PAplicaTabla
        credInfonavit.CITipodescuentoid = objCol.PTipoDescuentoId
        credInfonavit.CIValordescuento = objCol.PValorDescuento
        credInfonavit.CIMovimientoinfonavitid = objCol.PMovimientoId

        If objCalcInfonavit.msjError <> "" Then
            objMensajeError.mensaje = objCalcInfonavit.msjError
            objMensajeError.ShowDialog()
        End If

    End Sub

    Public Sub cargarComboDepartamentoFiscal()
        Dim dtDeptoFiscal As New DataTable
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable

        cmbDeptoFiscal.DataSource = Nothing
        If patronDestinoId > 0 Then
            dtDeptoFiscal = objBu.consultaDepartamentosFiscales(patronDestinoId)

            If dtDeptoFiscal.Rows.Count > 0 Then
                cmbDeptoFiscal.DataSource = dtDeptoFiscal
                cmbDeptoFiscal.DisplayMember = "deptoFiscal"
                cmbDeptoFiscal.ValueMember = "idDeptoFiscal"

                If dtDeptoFiscal.Rows.Count = 2 Then
                    cmbDeptoFiscal.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Public Sub cargarComboPuestoFiscal()
        Dim dtPuestos As New DataTable
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable

        If patronDestinoId > 0 Then
            dtPuestos = objBu.consultaPuestosFiscales(patronDestinoId)
            cmbPuestoFiscal.DataSource = Nothing
            If dtPuestos.Rows.Count > 0 Then
                cmbPuestoFiscal.DataSource = dtPuestos
                cmbPuestoFiscal.DisplayMember = "Puesto"
                cmbPuestoFiscal.ValueMember = "IdPuesto"

                If dtPuestos.Rows.Count = 2 Then
                    cmbPuestoFiscal.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub cmbPatron_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged
        If cmbPatron.SelectedIndex > 0 Then
            patronDestinoId = cmbPatron.SelectedValue
            cargarComboDepartamentoFiscal()
            cargarComboPuestoFiscal()
            cargarFehasMovimientos()
        End If

    End Sub

    Private Sub cargarFehasMovimientos()
        Dim dtFechas As New DataTable
        Dim objBu As New Negocios.BajaCambioPatronBU

        If patronDestinoId > 0 Then
            dtFechas = objBu.obtenerFechasMovimientos(patronDestinoId)
            If Not dtFechas Is Nothing AndAlso dtFechas.Rows.Count > 0 Then
                'solicitud de cambio ticket 18281
                'dtpFechaBaja.MinDate = DateAdd(DateInterval.Day, -5, dtFechas.Rows(0)("FechaBaja"))
                'dtpFechaBaja.MaxDate = dtFechas.Rows(0)("FechaBaja")
                dtpFechaBaja.Value = dtFechas.Rows(0)("FechaBaja")

                If Date.Now >= dtFechas.Rows(0)("FechaAlta") Then
                    'solicitud de cambio ticket 18281
                    'tpFechaAlta.MinDate = dtFechas.Rows(0)("FechaAlta")
                End If
                'solicitud de cambio ticket 18281
                'dtpFechaAlta.MaxDate = DateAdd(DateInterval.Day, 6, dtFechas.Rows(0)("FechaAlta"))
                dtpFechaAlta.Value = dtFechas.Rows(0)("FechaAlta")

            End If
        End If
    End Sub

    Private Sub llenarComboPatron()
        cmbPatron.DataSource = Nothing
        If idNave > 0 Then
            Dim objBu As New Negocios.BajaCambioPatronBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatrones(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, idNave, patronOrigenId)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbPatron.DataSource = dtEmpresa
                cmbPatron.DisplayMember = "Patron"
                cmbPatron.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbPatron.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        copiarColaborador()
    End Sub

    Private Sub copiarColaborador()
        Me.Cursor = Cursors.WaitCursor
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim objCambioPatron As New Entidades.ColaboradorCambioPatron
        Dim dtResultado As DataTable
        Dim exito As Boolean = True

        If validarDatos() Then
            Try
                objMensajeConf.mensaje = "¿Está seguro de cambiar al colaborador? Este proceso no se podrá revertir."
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.BajaCambioPatronBU
                    patronDestinoId = cmbPatron.SelectedValue

                    With objCambioPatron
                        .PColaboradorId = idColaborador
                        .PPatronOrigenId = patronOrigenId
                        .PPatronDestinoid = patronDestinoId
                        .PNaveOrigenId = idNave
                        .PNaveDestinoId = idNave
                        .PFechaBaja = dtpFechaBaja.Value
                        .PFechaAlta = dtpFechaAlta.Value
                    End With

                    dtResultado = objBU.copiarColaborador(objCambioPatron) ''120820191748                    
                    If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                        If dtResultado.Rows(0).Item("Result") = "EXITO" Then
                            Dim idColaboradorN As Integer = 0
                            Dim objColContaBU As New Negocios.ColaboradoresContabilidadBU
                            Dim dtAlta As New DataTable
                            Dim idAlta As Int32 = 0
                            Dim dtDatos As New DataTable

                            objCol = New Entidades.AltaColaboradorIMSS

                            idColaboradorN = dtResultado.Rows(0).Item("colId")

                            dtDatos = objBu.obtenerDatosAlta(idColaborador, patronDestinoId)
                            If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                                Dim carpeta As String = ""
                                Dim archivo As String = ""

                                carpeta = dtDatos.Rows(0).Item("carpeta")
                                archivo = dtDatos.Rows(0).Item("archivo")

                                objCol.PNumeroCredito = dtDatos.Rows(0).Item("numeroCredito")
                                objCol.PTipoDescuentoId = dtDatos.Rows(0).Item("tipodescuentoid")
                                objCol.PAplicaTabla = dtDatos.Rows(0).Item("aplicatabladisminucion")

                                objCol.PValorDescuento = dtDatos.Rows(0).Item("valordescuento")
                                objCol.PTipoTrabajadorId = dtDatos.Rows(0).Item("tipotrabajador")
                                objCol.PTipoJornadaID = dtDatos.Rows(0).Item("tipojornada")
                                objCol.PTipoSalarioId = dtDatos.Rows(0).Item("tiposalario")
                                objCol.PUMF = dtDatos.Rows(0).Item("umf")
                                objCol.PMovimientoId = dtDatos.Rows(0).Item("movimientoinfonavitid")
                                objCol.PRutaArchivoRetencion = dtDatos.Rows(0).Item("rutaarchivoretencion")

                                ''End if anterior de obtener datos alta


                                'Alta 
                                objCol.PColaboradorId = idColaboradorN
                                objCol.PPAtronId = patronDestinoId
                                objCol.PIdNave = idNave
                                objCol.PFechaAlta = dtpFechaAlta.Value
                                objCol.PTieneCredito = infonavit
                                objCol.PSDI = txtSDI.Text
                                objCol.PDepartamentoFiscalId = cmbDeptoFiscal.SelectedValue 'cmb
                                objCol.PPuestoFiscalId = cmbPuestoFiscal.SelectedValue 'cmb

                                If infonavit Then
                                    cargarDatosInfonavit()

                                    credInfonavit.CIColaboradorid = idColaboradorN
                                    credInfonavit.CIPatronId = patronDestinoId
                                    credInfonavit.CIFechamovimiento = dtpFechaAlta.Value
                                    credInfonavit.CIFecharecepcion = Today
                                    objCol.PEntidadCreditoInfonavit = credInfonavit
                                    objCol.PCantidadDescontar = credInfonavit.CIDescuentosemanal
                                    objCol.PCargoRetencion = False ''Archivo... :\
                                    objCol.PEntidadCreditoInfonavit.CIFechaaplicacion = dtpFechaAlta.Value
                                    objCol.PEntidadCreditoInfonavit.CIRutaarchivoretencion = dtDatos.Rows(0).Item("rutaarchivoretencion")
                                End If

                                'Alta
                                dtAlta = objColContaBU.insertaAltaImss(objCol, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                                If Not dtAlta Is Nothing AndAlso dtAlta.Rows.Count > 0 Then
                                    If dtAlta.Rows(0).Item("resul") = "EXITO" Then
                                        idAlta = dtAlta.Rows(0).Item("idAlta")
                                        'Infonavit
                                        If infonavit AndAlso Not objCol.PEntidadCreditoInfonavit Is Nothing Then
                                            Dim dtInfonavit As New DataTable
                                            Dim idInfonavit As Int32 = 0
                                            dtInfonavit = objColContaBU.altaMovimientoCreditoInfonavit(objCol.PEntidadCreditoInfonavit, carpeta, archivo)
                                            If Not dtInfonavit Is Nothing AndAlso dtInfonavit.Rows.Count > 0 Then
                                                If dtInfonavit.Rows(0).Item("mensaje") = "EXITO" Then
                                                    'Actualizar Alta
                                                    idInfonavit = dtInfonavit.Rows(0).Item("idInfonavit")
                                                    objColContaBU.ActualizaInfonavitALtaImss(idInfonavit, idAlta)
                                                Else
                                                    objMensajeError.mensaje = dtInfonavit.Rows(0).Item("mensaje")
                                                    objMensajeError.ShowDialog()
                                                End If
                                            Else
                                                objMensajeError.mensaje = "Ocurrió un error al crear el movimiento de INFONAVIT, favor de comunicarse con sistemas."
                                                objMensajeError.ShowDialog()
                                            End If
                                        End If

                                        objMensajeExito.mensaje = "El colaborador ha sido cambiado exitosamente."
                                        objMensajeExito.ShowDialog()
                                        guardado = True
                                        Me.Cursor = Cursors.Default
                                        Me.Close()
                                    Else
                                        objMensajeError.mensaje = dtAlta.Rows(0).Item("Result")
                                        objMensajeError.ShowDialog()
                                    End If ''Cierra if error alta
                                Else
                                    objMensajeError.mensaje = "Ocurrió un error al crear el Alta IMSS, favor de comunicarse con sistemas."
                                    objMensajeError.ShowDialog()
                                End If ''Cierra if sin datos alta                                
                            Else
                                objMensajeError.mensaje = "Ocurrió un error al consultar los datos para crear el Alta IMSS, favor de comunicarse con sistemas."
                                objMensajeError.ShowDialog()
                            End If ''Cerrar if de obtener datos alta
                        Else
                            objMensajeError.mensaje = dtResultado.Rows(0).Item("Result")
                            objMensajeError.ShowDialog()
                        End If ''Cierra if error copiar
                    Else
                        objMensajeError.mensaje = "Error al copiar al colaborador al patrón destino."
                        objMensajeError.ShowDialog()
                    End If ''Cierra if no existe copiar
                    Me.Cursor = Cursors.Default
                End If ''Cierra If confirmación
            Catch ex As Exception
                objMensajeError.mensaje = "Error al copiar al colaborador al patrón destino."
                objMensajeError.ShowDialog()
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarDatos() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        'If cmbNave.Items.Count > 1 And cmbNave.SelectedIndex = 0 Then
        '    objMensajeAdv.mensaje = "Favor de seleccionar una Nave."
        '    objMensajeAdv.ShowDialog()
        '    Return False
        'End If

        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Patrón."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If Not IsNumeric(txtSDI.Text) Then
            objMensajeAdv.mensaje = "Favor de capturar un SDI válido."
            objMensajeAdv.ShowDialog()
            Return False
        Else
            Dim objBu As New Negocios.ColaboradoresContabilidadBU
            Dim salariominimo As Double = 0

            salariominimo = objBu.validaSDIMinimo(idColaborador)

            If salariominimo > 0 AndAlso salariominimo < CDbl(txtSDI.Text) Then
                objMensajeAdv.mensaje = "El SDI no puede ser menor al SDI minimo configurado para la nave (" + salariominimo.ToString("N2") + ") "
                objMensajeAdv.ShowDialog()
                Return False
            End If
        End If

        ''validaRetencionSemanal()!!!!!!!!

        If cmbDeptoFiscal.Items.Count > 1 And cmbDeptoFiscal.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Departamento Fiscal."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        If cmbPuestoFiscal.Items.Count > 1 And cmbPuestoFiscal.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Puesto Fiscal."
            objMensajeAdv.ShowDialog()
            Return False
        End If

        Return True
    End Function


End Class