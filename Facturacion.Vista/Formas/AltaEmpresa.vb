Imports System.Net
Imports Facturacion.Negocios
Public Class AltaEmpresa
    Dim empresa As New Entidades.EmpresasFacturacion
    Public empresaId As Int32
    Public permiso As Boolean
    Dim archivoImg As String = ""
    Dim archivoCer As String = ""
    Dim archivoKey As String = ""
    'Dim ftp As String = "ftp://192.168.7.16"
    Dim diaActual As Date
    Dim rutaRaiz As String = "Administracion/ConfiguracionEmpresas/"
    Dim rfcViejo As String = ""

    Private Sub AltaEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtFCRutaPDF.Text = ftp & "/" & rutaRaiz
        'txtFCRutaXML.Text = ftp & "/" & rutaRaiz
        'txtFPRutaPDF.Text = ftp & "/" & rutaRaiz
        'txtFPRutaXML.Text = ftp & "/" & rutaRaiz

        txtFCRutaPDF.Text = rutaRaiz
        txtFCRutaXML.Text = rutaRaiz
        txtFPRutaPDF.Text = rutaRaiz
        txtFPRutaXML.Text = rutaRaiz
        Tools.Controles.ComboEstadosAnidado(cmbEstado, 1)
        cargarReportes()
        cargarDatos()

        If Not permiso Then
            desabilitarCampos()
        End If

        tbcEmpresas.TabPages.Remove(tbpFacturacionCalzado)
        tbcEmpresas.TabPages.Remove(tbpFacturacionProductos)
    End Sub

    Private Sub btnExaminarImagen_Click(sender As Object, e As EventArgs) Handles btnExaminarImagen.Click
        opfArchivoImg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        opfArchivoImg.Filter = "JPEG, JPG, PNG|*.jpeg; *.jpg; *.png;"
        opfArchivoImg.FilterIndex = 3
        opfArchivoImg.ShowDialog()
        archivoImg = opfArchivoImg.FileName
        abrirImagen(archivoImg)
    End Sub

    Private Sub txtRFC_TextChanged(sender As Object, e As EventArgs) Handles txtRFC.TextChanged
        txtFCRutaPDF.Text = ""
        txtFCRutaXML.Text = ""
        txtFPRutaPDF.Text = ""
        txtFPRutaXML.Text = ""

        txtFCRutaPDF.Text = rutaRaiz & txtRFC.Text & "/"
        txtFCRutaXML.Text = rutaRaiz & txtRFC.Text & "/"
        txtFPRutaPDF.Text = rutaRaiz & txtRFC.Text & "/"
        txtFPRutaXML.Text = rutaRaiz & txtRFC.Text & "/"

        'txtFCRutaPDF.Text = ftp & "/" & rutaRaiz & txtRFC.Text & "/"
        'txtFCRutaXML.Text = ftp & "/" & rutaRaiz & txtRFC.Text & "/"
        'txtFPRutaPDF.Text = ftp & "/" & rutaRaiz & txtRFC.Text & "/"
        'txtFPRutaXML.Text = ftp & "/" & rutaRaiz & txtRFC.Text & "/"
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        Try
            cmbCiudad = Tools.Controles.ComboCiudadesMayusculas(cmbCiudad, cmbEstado.SelectedValue)

            If cmbEstado.SelectedValue <> 0 Then
                cmbCiudad.Enabled = True
            Else
                cmbCiudad.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExaminarCer_Click(sender As Object, e As EventArgs) Handles btnExaminarCer.Click
        opfArchivoCer.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        opfArchivoCer.Filter = "CER|*.cer;"
        opfArchivoCer.FilterIndex = 3
        opfArchivoCer.ShowDialog()
        archivoCer = opfArchivoCer.FileName
        txtRutaCertificado.Text = archivoCer
    End Sub

    Private Sub btnExaminarKey_Click(sender As Object, e As EventArgs) Handles btnExaminarKey.Click
        opfArchivoKey.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        opfArchivoKey.Filter = "KEY|*.key;"
        opfArchivoKey.FilterIndex = 3
        opfArchivoKey.ShowDialog()
        archivoKey = opfArchivoKey.FileName
        txtRutaKey.Text = archivoKey
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.EmpresasBU
        Dim objFac As New Negocios.FacturaBU
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeConf As New Tools.ConfirmarForm

        Try
            If validarCampos() Then
                If validarDatos() Then
                    If validarArchivos() Then
                        If empresaId = 0 Then
                            objMensajeConf.mensaje = "Una vez guardados la razón social y el RFC no podrán ser modificados. ¿Continuar guardando?"
                            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Else
                                Exit Sub
                            End If
                        End If
                        empresa.EId = empresaId
                        empresa.ENombre = txtNombre.Text
                        empresa.ERazonsocial = txtRazonSocial.Text
                        empresa.ECalle = txtCalle.Text
                        empresa.EColonia = txtColonia.Text
                        empresa.ECp = txtCP.Text
                        empresa.ERegimen = txtRegimen.Text
                        empresa.EClaveRegimen = txtClaveRegimen.Text
                        empresa.ERfc = txtRFC.Text
                        empresa.EActivo = chkActiva.Checked
                        empresa.EArrendamiento = chkArrendamiento.Checked
                        empresa.ENumero = txtNumero.Text
                        empresa.ECiudadid = cmbCiudad.SelectedValue
                        empresa.ECurp = txtCurp.Text

                        empresa.ERutacertificado = subirArchivo(archivoCer)
                        empresa.ERutakey = subirArchivo(archivoKey)
                        empresa.EWebservice = txtRutaWS.Text
                        empresa.EContrasenaws = txtContrasenaWS.Text
                        empresa.EIdentificadorPax = txtIdentificadorWS.Text
                        If txtFolioInicio.Text <> "" Then
                            empresa.EFoliosinicio = txtFolioInicio.Text
                        End If
                        If txtFolioActual.Text <> "" Then
                            empresa.EFolioactual = txtFolioActual.Text
                        End If
                        If txtFolioFinal.Text <> "" Then
                            empresa.EFoliosFin = txtFolioFinal.Text
                        End If
                        empresa.ENumerocertificado = txtNoCertificado.Text
                        empresa.ECertificadovigenciainicio = CDate(dtpVigenciaInicio.Value)
                        empresa.ECertificadovigenciafin = CDate(dtpVigenciaFin.Value)
                        empresa.EContrasenacertificado = txtContrasenaCertificado.Text
                        empresa.EUsuariows = txtUsuarioWS.Text

                        If txtFCRutaPDF.Text <> "" Then
                            empresa.ERutapdfcalzado = txtFCRutaPDF.Text
                        End If
                        If txtFCRutaXML.Text <> "" Then
                            empresa.ERutaxmlcalzado = txtFCRutaXML.Text
                        End If
                        If txtMaxRenglones.Text <> "" Then
                            empresa.ERenglones = txtMaxRenglones.Text
                        End If
                        If txtSerie.Text <> "" Then
                            empresa.ESerie = txtSerie.Text
                        End If
                        If txtFCFolioActual.Text <> "" Then
                            empresa.EFolioactualcalzado = txtFCFolioActual.Text
                        End If
                        If cmbFCReporteFactura.SelectedIndex = 0 Or cmbFCReporteFactura.SelectedIndex = -1 Then
                            empresa.EReportecalzadoid = Nothing
                        Else
                            empresa.EReportecalzadoid = cmbFCReporteFactura.SelectedValue
                        End If
                        If cmbFCReporteCancelacion.SelectedIndex = 0 Or cmbFCReporteCancelacion.SelectedIndex = -1 Then
                            empresa.EReportecanccalzadoid = Nothing
                        Else
                            empresa.EReportecanccalzadoid = cmbFCReporteCancelacion.SelectedValue
                        End If

                        If txtFPRutaPDF.Text <> "" Then
                            empresa.ERutapdfproductos = txtFPRutaPDF.Text
                        End If
                        If txtFPRutaXML.Text <> "" Then
                            empresa.ERutaxmlproductos = txtFPRutaXML.Text
                        End If
                        If cmbFPReporteFactura.SelectedIndex = 0 Or cmbFPReporteFactura.SelectedIndex = -1 Then
                            empresa.EReporteproductosid = Nothing
                        Else
                            empresa.EReporteproductosid = cmbFPReporteFactura.SelectedValue
                        End If
                        If cmbFPReporteCancelacion.SelectedIndex = 0 Or cmbFPReporteCancelacion.SelectedIndex = -1 Then
                            empresa.EReportecancproductosid = Nothing
                        Else
                            empresa.EReportecancproductosid = cmbFPReporteCancelacion.SelectedValue
                        End If

                        empresa.ERutalogo = subirArchivo(archivoImg)
                        'empresa.ECadenacertificado = objFac.obtenerCertificado(empresa.ERutacertificado, IO.Path.GetDirectoryName(empresa.ERutacertificado & ".pem"))
                        empresa.ECadenacertificado = objFac.obtenerCertificado(empresa.ERutacertificado)

                        If empresa.ECadenacertificado <> "" Then
                            objBU.guardarConfiguracionEmpresa(empresa)

                            objMensajeExito.mensaje = "El registro se ha guardado con exito."
                            objMensajeExito.ShowDialog()

                            Me.Close()
                        Else
                            objMensajeAdv.mensaje = "Error al obtener la cadena del certificado. Favor de verificar que los datos esten correctos."
                            objMensajeAdv.ShowDialog()
                        End If
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "Existen campos obligatorios que no se han capturado."
                objMensajeAdv.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeAdv.mensaje = "Error al guardar los datos de la empresa."
            objMensajeAdv.ShowDialog()
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim objMensajeAdv As New Tools.ConfirmarForm

        objMensajeAdv.mensaje = "¿Realmente quiere cerrar la ventana?, los datos capturados se perderan al cerrar"
        If objMensajeAdv.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub cargarReportes()
        Dim datos As New Negocios.EmpresasBU
        Dim lstReportesFC As New DataTable
        Dim lstReportesFCC As New DataTable
        Dim lstReportesFP As New DataTable
        Dim lstReportesFPC As New DataTable

        lstReportesFC = datos.getReportes
        If Not lstReportesFC.Rows.Count = 0 Then
            lstReportesFC.Rows.InsertAt(lstReportesFC.NewRow, 0)
            cmbFCReporteFactura.DataSource = lstReportesFC
            cmbFCReporteFactura.DisplayMember = "repo_nombrereporte"
            cmbFCReporteFactura.ValueMember = "repo_reporteid"
        End If

        lstReportesFCC = datos.getReportes
        If Not lstReportesFCC.Rows.Count = 0 Then
            lstReportesFCC.Rows.InsertAt(lstReportesFCC.NewRow, 0)
            cmbFCReporteCancelacion.DataSource = lstReportesFCC
            cmbFCReporteCancelacion.DisplayMember = "repo_nombrereporte"
            cmbFCReporteCancelacion.ValueMember = "repo_reporteid"
        End If


        lstReportesFP = datos.getReportes
        If Not lstReportesFP.Rows.Count = 0 Then
            lstReportesFP.Rows.InsertAt(lstReportesFP.NewRow, 0)
            cmbFPReporteFactura.DataSource = lstReportesFP
            cmbFPReporteFactura.DisplayMember = "repo_nombrereporte"
            cmbFPReporteFactura.ValueMember = "repo_reporteid"
        End If

        lstReportesFPC = datos.getReportes
        If Not lstReportesFPC.Rows.Count = 0 Then
            lstReportesFPC.Rows.InsertAt(lstReportesFPC.NewRow, 0)
            cmbFPReporteCancelacion.DataSource = lstReportesFPC
            cmbFPReporteCancelacion.DisplayMember = "repo_nombrereporte"
            cmbFPReporteCancelacion.ValueMember = "repo_reporteid"
        End If
    End Sub

    Private Sub cargarDatos()
        Try
            If empresaId > 0 Then
                Dim objBU As New Negocios.EmpresasBU
                Dim datos As New Entidades.EmpresasFacturacion

                datos = objBU.getDatosEmpresa(empresaId)

                txtRazonSocial.Text = datos.ERazonsocial
                txtNombre.Text = datos.ENombre
                txtCalle.Text = datos.ECalle
                txtColonia.Text = datos.EColonia
                txtRFC.Text = datos.ERfc
                rfcViejo = datos.ERfc
                If datos.ENumero <> "" Then
                    txtNumero.Text = datos.ENumero
                End If
                txtCP.Text = datos.ECp
                txtRegimen.Text = datos.ERegimen
                txtClaveRegimen.Text = datos.EClaveRegimen
                cmbEstado.SelectedValue = datos.EEstadoid
                cmbCiudad.SelectedValue = datos.ECiudadid
                txtCurp.Text = datos.ECurp
                chkActiva.Checked = datos.EActivo
                chkArrendamiento.Checked = datos.EArrendamiento

                txtRutaCertificado.Text = datos.ERutacertificado
                archivoCer = datos.ERutacertificado
                txtRutaKey.Text = datos.ERutakey
                archivoKey = datos.ERutakey
                txtRutaWS.Text = datos.EWebservice
                txtContrasenaWS.Text = datos.EContrasenaws
                txtIdentificadorWS.Text = datos.EIdentificadorPax
                If datos.EFoliosinicio <> 0 Then
                    txtFolioInicio.Text = datos.EFoliosinicio
                End If
                If datos.EFolioactual <> 0 Then
                    txtFolioActual.Text = datos.EFolioactual
                End If
                If datos.EFoliosFin <> 0 Then
                    txtFolioFinal.Text = datos.EFoliosFin
                End If
                txtNoCertificado.Text = datos.ENumerocertificado
                dtpVigenciaInicio.Text = datos.ECertificadovigenciainicio
                dtpVigenciaFin.Text = datos.ECertificadovigenciafin
                txtContrasenaCertificado.Text = datos.EContrasenacertificado
                txtUsuarioWS.Text = datos.EUsuariows

                txtFCRutaPDF.Text = datos.ERutapdfcalzado
                txtFCRutaXML.Text = datos.ERutaxmlcalzado
                If datos.ERenglones <> 0 Then
                    txtMaxRenglones.Text = datos.ERenglones
                End If
                txtSerie.Text = datos.ESerie
                If datos.EFolioactualcalzado <> 0 Then
                    txtFCFolioActual.Text = datos.EFolioactualcalzado
                End If
                cmbFCReporteFactura.SelectedValue = datos.EReportecalzadoid
                cmbFCReporteCancelacion.SelectedValue = datos.EReportecanccalzadoid

                txtFPRutaPDF.Text = datos.ERutapdfproductos
                txtFPRutaXML.Text = datos.ERutaxmlproductos
                cmbFPReporteFactura.SelectedValue = datos.EReporteproductosid
                cmbFPReporteCancelacion.SelectedValue = datos.EReportecancproductosid

                If datos.ERutalogo <> "" Then
                    archivoImg = datos.ERutalogo
                    cargarImagen(datos.ERutalogo)
                End If

                'txtRazonSocial.Enabled = False
                txtRFC.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function validarCampos() As Boolean
        Dim validos As Boolean = True

        If txtRazonSocial.Text.Trim = "" Then
            lblRazonSocial.ForeColor = Color.Red
            validos = False
        Else
            lblRazonSocial.ForeColor = Color.Black
        End If

        If txtNombre.Text.Trim = "" Then
            lblNombre.ForeColor = Color.Red
            validos = False
        Else
            lblNombre.ForeColor = Color.Black
        End If

        If txtCalle.Text.Trim = "" Then
            lblCalle.ForeColor = Color.Red
            validos = False
        Else
            lblCalle.ForeColor = Color.Black
        End If

        If txtColonia.Text.Trim = "" Then
            lblColonia.ForeColor = Color.Red
            validos = False
        Else
            lblColonia.ForeColor = Color.Black
        End If

        If txtCP.Text.Trim = "" Then
            lblCp.ForeColor = Color.Red
            validos = False
        Else
            lblCp.ForeColor = Color.Black
        End If

        If txtRegimen.Text.Trim = "" Then
            lblRegimen.ForeColor = Color.Red
            validos = False
        Else
            lblRegimen.ForeColor = Color.Black
        End If

        If txtClaveRegimen.Text.Trim = "" Then
            lblClaveRegimen.ForeColor = Color.Red
            validos = False
        Else
            lblClaveRegimen.ForeColor = Color.Black
        End If

        If txtClaveRegimen.Text.Trim = "" Then
            lblClaveRegimen.ForeColor = Color.Red
            validos = False
        Else
            lblClaveRegimen.ForeColor = Color.Black
        End If

        If txtRFC.Text.Trim = "" Then
            lblRFC.ForeColor = Color.Red
            validos = False
        Else
            lblRFC.ForeColor = Color.Black
        End If

        If txtNumero.Text.Trim = "" Then
            lblNumero.ForeColor = Color.Red
            validos = False
        Else
            lblNumero.ForeColor = Color.Black
        End If

        If cmbEstado.SelectedValue = 0 Then
            lblEstado.ForeColor = Color.Red
            validos = False
        Else
            lblEstado.ForeColor = Color.Black
        End If

        If cmbCiudad.SelectedValue = 0 Then
            lblCiudad.ForeColor = Color.Red
            validos = False
        Else
            lblCiudad.ForeColor = Color.Black
        End If

        If txtRFC.Text.Trim.Length = 13 And txtCurp.Text.Trim = "" Then
            lblCurp.ForeColor = Color.Red
            validos = False
        Else
            lblCurp.ForeColor = Color.Black
        End If


        If txtRutaCertificado.Text.Trim = "" Then
            lblRutaCertificado.ForeColor = Color.Red
            validos = False
        Else
            lblRutaCertificado.ForeColor = Color.Black
        End If

        If txtRutaKey.Text.Trim = "" Then
            lblRutaKey.ForeColor = Color.Red
            validos = False
        Else
            lblRutaKey.ForeColor = Color.Black
        End If

        If txtRutaWS.Text.Trim = "" Then
            lblRutaWS.ForeColor = Color.Red
            validos = False
        Else
            lblRutaWS.ForeColor = Color.Black
        End If

        If txtContrasenaWS.Text.Trim = "" Then
            lblContrasenaWS.ForeColor = Color.Red
            validos = False
        Else
            lblContrasenaWS.ForeColor = Color.Black
        End If

        'If txtIdentificadorWS.Text = "" Then
        '    lblIdentificadorWS.ForeColor = Color.Red
        '    validos = False
        'Else
        '    lblIdentificadorWS.ForeColor = Color.Black
        'End If

        If txtNoCertificado.Text.Trim = "" Then
            lblNoCertificado.ForeColor = Color.Red
            validos = False
        Else
            lblNoCertificado.ForeColor = Color.Black
        End If

        If txtContrasenaCertificado.Text.Trim = "" Then
            lblContrasenaCertificado.ForeColor = Color.Red
            validos = False
        Else
            lblContrasenaCertificado.ForeColor = Color.Black
        End If

        If txtUsuarioWS.Text.Trim = "" Then
            lblUsuarioWS.ForeColor = Color.Red
            validos = False
        Else
            lblUsuarioWS.ForeColor = Color.Black
        End If

        Return validos
    End Function

    Private Function validarDatos() As Boolean
        Dim objBU As New Negocios.EmpresasBU
        Dim datos As New Entidades.EmpresasFacturacion
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim esNumero As Integer = 0
        Dim auxDA As Integer
        Dim auxVI As Integer
        Dim auxVF As Integer

        diaActual = obtenerFechaActual()
        auxDA = CInt(diaActual.ToString("yyyyMMdd"))
        auxVI = CInt(dtpVigenciaInicio.Value.ToString("yyyyMMdd"))
        auxVF = CInt(dtpVigenciaFin.Value.ToString("yyyyMMdd"))

        If txtFolioInicio.Text <> "" Then
            Try
                esNumero = CInt(txtFolioInicio.Text)
                lblFolioInicio.ForeColor = Color.Black
            Catch ex As Exception
                lblFolioInicio.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El folio inicio debe ser número entero."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End Try
        End If

        If txtFolioFinal.Text <> "" Then
            Try
                esNumero = CInt(txtFolioFinal.Text)
                lblFolioFinal.ForeColor = Color.Black
            Catch ex As Exception
                lblFolioFinal.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El folio fin debe ser número entero."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End Try
        End If

        If txtMaxRenglones.Text <> "" Then
            Try
                esNumero = CInt(txtMaxRenglones.Text)
                lblMaxRenglones.ForeColor = Color.Black
            Catch ex As Exception
                lblMaxRenglones.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El máximo de renglones debe ser número entero."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End Try
        End If

        If txtSerie.Text <> "" Then
            If revisarCaracter(txtSerie.Text) Then
                lblSerie.ForeColor = Color.Black
            Else
                lblSerie.ForeColor = Color.Red
                objMensajeAdv.mensaje = "La serie debe ser letra(s)."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        If empresaId = 0 Then

            If objBU.ExisteRegistro(1, txtNombre.Text, empresaId) Then
                lblNombre.ForeColor = Color.Red
                objMensajeAdv.mensaje = "Ya existe una empresa con el mismo nombre."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblRazonSocial.ForeColor = Color.Black
            End If

            If objBU.ExisteRegistro(2, txtRFC.Text, empresaId) Then
                lblRFC.ForeColor = Color.Red
                objMensajeAdv.mensaje = "Ya existe una empresa con el mismo RFC."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblRFC.ForeColor = Color.Black
            End If
        End If

        If auxVI > auxDA Then
            lblVigenciaInicio.ForeColor = Color.Red
            objMensajeAdv.mensaje = "La vigencia inicio no puede ser una fecha futura."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblVigenciaInicio.ForeColor = Color.Black
        End If

        If auxVF <= auxVI Then
            lblVigenciaInicio.ForeColor = Color.Red
            lblVigenciaFin.ForeColor = Color.Red
            objMensajeAdv.mensaje = "La vigencia fin no puede ser una fecha menor o igual a la vigencia inicio."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblVigenciaFin.ForeColor = Color.Black
            lblVigenciaInicio.ForeColor = Color.Black
        End If

        If txtFolioActual.Text <> "" Then
            If CInt(txtFolioActual.Text) >= CInt(txtFolioFinal.Text) Then
                lblFolioActual.ForeColor = Color.Red
                lblFolioFinal.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El folio final no puede ser menor o igual al folio actual."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblFolioActual.ForeColor = Color.Black
                lblFolioFinal.ForeColor = Color.Black
            End If
        End If

        If txtFolioInicio.Text <> "" And txtFolioFinal.Text <> "" Then
            If CInt(txtFolioFinal.Text) <= CInt(txtFolioInicio.Text) Then
                lblFolioInicio.ForeColor = Color.Red
                lblFolioFinal.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El folio final no puede ser menor o igual al folio inicial."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblFolioInicio.ForeColor = Color.Black
                lblFolioFinal.ForeColor = Color.Black
            End If
        End If

        If cmbFCReporteFactura.SelectedIndex > 0 And cmbFCReporteCancelacion.SelectedIndex <= 0 Then
            lblFCReporteCancelacion.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Se ha seleccionado una reporte de facturación de calzado pero no un reporte de cancelación. Favor de seleccionar un reporte de cancelación"
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblFCReporteCancelacion.ForeColor = Color.Black
        End If

        If cmbFPReporteFactura.SelectedIndex > 0 And cmbFPReporteCancelacion.SelectedIndex <= 0 Then
            lblFPReporteCancelacion.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Se ha seleccionado una reporte de facturación de productos pero no un reporte de cancelación. Favor de seleccionar un reporte de cancelación"
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblFPReporteCancelacion.ForeColor = Color.Black
        End If

        Return True
    End Function

    Private Function validarArchivos() As Boolean
        Dim extension As String = ""
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If archivoImg <> "" Then
            extension = System.IO.Path.GetExtension(archivoImg)
            If extension.ToUpper <> ".JPEG" And extension.ToUpper <> ".JPG" And extension.ToUpper <> ".PNG" Then
                objMensajeAdv.mensaje = "La imagen del logo debe ser en formato JPEG, JPG o PNG."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        extension = System.IO.Path.GetExtension(archivoCer)
        If extension.ToUpper <> ".CER" Then
            lblRutaCertificado.ForeColor = Color.Red
            objMensajeAdv.mensaje = "El archivo seleccionado no es un certificado válido."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblRutaCertificado.ForeColor = Color.Black
        End If

        extension = System.IO.Path.GetExtension(archivoKey)
        If extension.ToUpper <> ".KEY" Then
            lblRutaKey.ForeColor = Color.Red
            objMensajeAdv.mensaje = "El archivo seleccionado no es una llave válida."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblRutaKey.ForeColor = Color.Black
        End If

        Return True
    End Function

    Private Function obtenerFechaActual() As Date
        Dim fechaAct As Date
        Dim objBU As New Negocios.EmpresasBU

        fechaAct = objBU.obtenerFechaActual()

        Return fechaAct
    End Function

    Private Function revisarCaracter(ByVal cadena As String) As Boolean
        Dim esLetra As Boolean = True

        For i As Integer = 0 To cadena.Length - 1
            If Asc(cadena.Chars(i)) < 65 Then
                esLetra = False
            Else
                If Asc(cadena.Chars(i)) > 90 Then
                    esLetra = False
                Else
                    esLetra = True
                End If
            End If
        Next

        Return esLetra
    End Function

    Private Function subirArchivo(ByVal ruta As String) As String
        Dim rutaArchivo As String = ""
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim directorio As String = ""
            Dim tabla() As String
            Dim archivo As String

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaRaiz & txtRFC.Text

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorio, ruta)
                ruta = ruta.Replace("\", "/")
                tabla = Split(ruta, "/")
                archivo = tabla(UBound(tabla))
                rutaArchivo = UCase(directorio & "/" & archivo)
                'rutaArchivo = ftp & "/" & directorio & "/" & archivo
            End If

            Return rutaArchivo
        Catch
            Return rutaArchivo
        End Try
    End Function

    Private Sub abrirImagen(ByVal ruta As String)
        Try
            'Dim objFTP As New Tools.TransferenciaFTP
            Dim imagen As Image

            imagen = Image.FromFile(ruta)
            ptbLogo.Image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, 119, 51))
        Catch

        End Try
    End Sub

    Private Sub cargarImagen(ByVal ruta As String)
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim Stream As System.IO.Stream
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            Dim Carpeta As String = ""
            Dim nomArchivo As String = ""
            Dim tabla() As String
            Dim imagen As Image

            If ruta <> "" Then
                tabla = Split(ruta, "/")
                For n = 0 To UBound(tabla, 1)
                    If n = UBound(tabla) Then
                        nomArchivo = tabla(n)
                    Else
                        Carpeta += tabla(n) + "/"
                    End If
                Next

                Carpeta = Carpeta.Replace(objFTP.obtenerURL, "")

                Stream = objFTP.StreamFile(Carpeta, nomArchivo)
                imagen = Image.FromStream(Stream)
                ptbLogo.Image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, 119, 51))
            End If
        Catch

        End Try
    End Sub

    Private Sub desabilitarCampos()
        pnlGeneral.Enabled = False
        pnlFacturaGeneral.Enabled = False
        pnlFacturacionCalzado.Enabled = False
        pnlFacturacionProductos.Enabled = False

        btnGuardar.Visible = False
        lblGuardar.Visible = False
    End Sub

    Private Sub cmbFCReporteFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFCReporteFactura.SelectedIndexChanged
        If cmbFCReporteFactura.SelectedIndex > 0 Then
            cmbFCReporteCancelacion.Enabled = True
        Else
            cmbFCReporteCancelacion.SelectedValue = 0
            cmbFCReporteCancelacion.Enabled = False
        End If
    End Sub

    Private Sub cmbFPReporteFactura_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFPReporteFactura.SelectedIndexChanged
        If cmbFPReporteFactura.SelectedIndex > 0 Then
            cmbFPReporteCancelacion.Enabled = True
        Else
            cmbFPReporteCancelacion.SelectedValue = 0
            cmbFPReporteCancelacion.Enabled = False
        End If
    End Sub
End Class