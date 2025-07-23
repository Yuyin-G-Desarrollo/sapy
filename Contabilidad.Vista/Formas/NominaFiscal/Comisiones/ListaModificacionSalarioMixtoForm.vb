Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports Framework.Negocios

Public Class ListaModificacionSalarioMixtoForm
    Dim colaboradorIds As String = String.Empty
    Dim perfilContabilidad As Boolean = False

    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property
    Private Sub btnGenerarTxt_Click(sender As Object, e As EventArgs) Handles btnGenerarTxt.Click, lblGenerarTxt.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        Dim contSeleccionadas As Integer = 0
        Dim idsSolicitudes() As Integer
        Dim solicitudIdsCE As String = String.Empty

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                solicitudIdsCE &= "(" & row.Cells("ID").Value & "),"
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(4, idsSolicitudes) Then
                Dim objBU As New Negocios.ModSalarioMixtoBU
                Dim lstInformacionIdse As New List(Of Entidades.InformacionIDSE_SUA)
                Dim contExiste As Integer = 0
                Dim archivoTXT As String = String.Empty
                Dim reemplazar As Boolean = True
                Dim contGeneradas As Integer = 0
                Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
                Dim mes As String = Date.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-MX"))

                Try
                    solicitudIdsCE = solicitudIdsCE.Substring(0, solicitudIdsCE.Length - 1)
                    lstInformacionIdse = objBU.consultarInformacionIDSE(solicitudIdsCE)

                    If Not lstInformacionIdse Is Nothing Then
                        If contSeleccionadas = lstInformacionIdse.Count Then
                            For item As Integer = 0 To lstInformacionIdse.Count - 1
                                archivoTXT = lstInformacionIdse(item).IIRutaDescarga & "movtoSalIDSE_" & lstInformacionIdse(item).IINumeroSeguroSocial & "_" & lstInformacionIdse(item).IITablaId & ".dat"
                                If existeArchivo(archivoTXT) Then
                                    lstInformacionIdse(item).IIExiste = True
                                    contExiste += 1
                                End If
                            Next

                            If contExiste > 0 Then
                                Dim objMensajeConf As New Tools.ConfirmarForm
                                objMensajeConf.mensaje = "Ya existen archivos para " & contExiste & " de los registros seleccionados. ¿Desea reemplazarlos?"

                                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    reemplazar = True
                                Else
                                    reemplazar = False
                                End If
                            End If

                            For item As Integer = 0 To lstInformacionIdse.Count - 1
                                If Not lstInformacionIdse(item).IIExiste Or reemplazar Then
                                    If generarTxtIdse(lstInformacionIdse(item)) Then
                                        contGeneradas += 1
                                    End If
                                End If
                            Next

                            If contSeleccionadas = contGeneradas Then
                                If generarTxtSua(lstInformacionIdse, fecha) Then
                                    objMensajeExito.mensaje = "Los archivos se generaron correctamente."
                                    objMensajeExito.ShowDialog()
                                Else
                                    objMensajeAdv.mensaje = "El archivo para el SUA no se generó, favor de volverlo a intentar."
                                    objMensajeAdv.ShowDialog()
                                End If
                            Else
                                objMensajeAdv.mensaje = "El archivo para el SUA no se generó, favor de volverlo a intentar."
                                objMensajeAdv.ShowDialog()
                            End If
                        Else
                            objMensajeAdv.mensaje = "No se pueden generar los archivos TXT debido información incorrecta de algunos colaboradores, favor de verificar."
                            objMensajeAdv.ShowDialog()
                        End If
                    Else
                        objMensajeAdv.mensaje = "No se pueden generar los archivos TXT debido información incorrecta de los colaboradores, favor de verificar."
                        objMensajeAdv.ShowDialog()
                    End If

                Catch ex As Exception
                    objMensajeError.mensaje = "Error al generar TXT's de las solicitudes."
                    objMensajeError.ShowDialog()
                End Try
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus AUTORIZADO para Generar los TXT's."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Function generarTxtIdse(ByVal infoIdse As Entidades.InformacionIDSE_SUA) As Boolean
        Try
            Dim archivoTXT As String = String.Empty
            Dim informacion As String = String.Empty

            'archivoTXT = infoIdse.IIRutaDescarga & "movtoSalIDSE_" & infoIdse.IINumeroSeguroSocial & "_" & fecha & ".dat"
            archivoTXT = infoIdse.IIRutaDescarga & "movtoSalIDSE_" & infoIdse.IINumeroSeguroSocial & "_" & infoIdse.IITablaId & ".dat"
            If Not existeCarpeta(IO.Path.GetDirectoryName(archivoTXT)) Then
                crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
            End If

            informacion = infoIdse.IIRegistroPatronal
            informacion &= infoIdse.IINumeroSeguroSocial
            informacion &= infoIdse.IIAPaterno
            informacion &= infoIdse.IIAMaterno
            informacion &= infoIdse.IINombre
            informacion &= infoIdse.IISalarioDiario
            informacion &= "      " 'Filler
            informacion &= " " 'Filler
            informacion &= infoIdse.IIClaveTipoSalario
            informacion &= infoIdse.IIClaveTipoJornada
            informacion &= infoIdse.IIFechaMovimiento
            informacion &= "     " 'Filler
            informacion &= infoIdse.IIClaveMovimiento
            informacion &= guia
            informacion &= infoIdse.IIClaveTrabajador
            informacion &= " " 'Filler
            informacion &= infoIdse.IICurp
            informacion &= infoIdse.IIIdentificador

            'Pie del archivo
            informacion &= vbCrLf
            informacion &= "*************                                           "
            informacion &= "000001                                                                       "
            informacion &= guia
            informacion &= "                             "
            informacion &= infoIdse.IIIdentificador


            File.WriteAllText(archivoTXT, informacion.ToUpper)
            Return existeArchivo(archivoTXT)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function generarTxtSua(ByVal infoIdse As List(Of Entidades.InformacionIDSE_SUA), ByVal fecha As String) As Boolean
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = infoIdse(0).IIRutaDescarga & "movtoSalSUA_" & fecha & ".txt"
        If Not existeCarpeta(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For i As Integer = 0 To infoIdse.Count - 1
            informacion &= infoIdse(i).IIRegistroPatronal
            informacion &= infoIdse(i).IINumeroSeguroSocial
            informacion &= infoIdse(i).IIClaveMovimiento
            informacion &= infoIdse(i).IIFechaMovimiento
            informacion &= "00000000" 'Espacio para Folio incapacidad (NO APLICA)
            informacion &= "00" 'Espacio para Dias de incidencia (NO APLICA)
            informacion &= "0" & infoIdse(i).IISalarioDiario
            informacion &= vbCrLf
        Next

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        Return existeArchivo(archivoTXT)
    End Function

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub ListaModificacionSalarioMixtoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarComboEstatus()
        llenarComboEmpresa()
        configuracionPermisosBotones()

        If pPatronId <> 0 And cmbEmpresa.Items.Count > 0 Then
            If pEstatusId <> 0 Then
                cmbEstatus.SelectedValue = pEstatusId
            End If
            cmbEmpresa.SelectedValue = pPatronId
            cargarListado()
        End If
    End Sub

    Private Sub llenarComboEstatus()
        Dim objBU As New Negocios.ModificacionSalarioBU
        Dim dtEstatus As New DataTable

        dtEstatus = objBU.obtenerEstatusModificacionSalario
        If Not dtEstatus Is Nothing Then
            If dtEstatus.Rows.Count > 0 Then
                cmbEstatus.DataSource = dtEstatus
                cmbEstatus.ValueMember = "esta_estatusid"
                cmbEstatus.DisplayMember = "esta_nombre"
            Else
                cmbEstatus.DataSource = Nothing
            End If
        Else
            cmbEstatus.DataSource = Nothing
        End If
    End Sub

    Private Sub llenarComboEmpresa()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtEmpresas As New DataTable

        dtEmpresas = objBU.consultarPatronEmpresaComisiones()
        If Not dtEmpresas Is Nothing Then
            If dtEmpresas.Rows.Count > 0 Then
                cmbEmpresa.DataSource = dtEmpresas
                cmbEmpresa.ValueMember = "ID"
                cmbEmpresa.DisplayMember = "PATRON"
                'cmbEmpresa.SelectedIndex = 1
            Else
                cmbEmpresa.DataSource = Nothing
            End If
        Else
            cmbEmpresa.DataSource = Nothing
        End If
    End Sub

    Private Sub configuracionPermisosBotones()

        pnlEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_SAL_MIXTO", "EDITAR_MODSALM")
        pnlGenerarTxt.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_SAL_MIXTO", "GENERARTXT_MODSALM")
        pnlPDFAcuse.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_SAL_MIXTO", "PDFACUSE_MODSALM")
        pnlRechazar.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_SAL_MIXTO", "RECHAZAR_MODSALM")

        'Permisos menú 
        ModificaciónSalarioMixtoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_SAL_MIXTO", "MODIF_WORD")
        ModificaciónSalarioMixtoPropuestaToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("MOD_SAL_MIXTO", "CONSULTAR_PROPUESTA")

    End Sub

    Private Function validarEstatus(ByVal opcEstatus As Int16, ByVal idsSolicitudes() As Integer) As Boolean
        Dim objBU As New Negocios.ModSalarioMixtoBU
        Dim resultado As String = String.Empty

        For item As Integer = 0 To idsSolicitudes.Length - 1
            resultado = objBU.validarEstatus(idsSolicitudes(item), opcEstatus)
            If resultado <> "CORRECTO" Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click, lblEditar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("ID").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsSolicitud(0) As Integer
            idsSolicitud(0) = solicitudId
            If validarEstatus(3, idsSolicitud) Then
                Dim objForm As New EditarSolicituModSalarioMixtoForm
                If Not CheckForm(objForm) Then

                    Dim formaAltas As New EditarSolicituModSalarioMixtoForm
                    formaAltas.editar = True
                    formaAltas.solicitudId = solicitudId
                    formaAltas.ShowDialog()

                    If formaAltas.guardado Then
                        cargarListado()
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "La solicitud debe de estar en estatus SOLICITADO para Editarla."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click, lblRechazar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsSolicitudes() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(1, idsSolicitudes) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de rechazar los " & contSeleccionadas & " registros seleccionados?"

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.ModSalarioMixtoBU
                    Dim resultado As String = String.Empty
                    Dim motivoRechazo As String = String.Empty
                    Dim contRechazadas As Integer = 0
                    Dim formMotivo As New MotivoRechazoForm

                    If Not CheckForm(formMotivo) Then
                        formMotivo.ShowDialog()

                        If formMotivo.motivo <> "" Then
                            motivoRechazo = formMotivo.motivo
                        Else
                            objMensajeAdv.mensaje = "No se rechazaron las solicitudes debido a que no se ingresó el motivo de rechazo."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If


                    Try
                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            resultado = objBU.cambiarEstatus(idsSolicitudes(item), 2, motivoRechazo)

                            If resultado = "EXITO" Then
                                contRechazadas += 1
                            End If
                        Next

                        If contSeleccionadas = contRechazadas Then
                            objMensajeExito.mensaje = "Solicitudes Rechazadas correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contRechazadas = 0 Then
                            objMensajeError.mensaje = "Error no se pudieron rechazar las solicitudes."
                            objMensajeError.ShowDialog()
                        ElseIf contSeleccionadas > contRechazadas Then
                            objMensajeError.mensaje = "Algunas solicitudes seleccionadas no se pudieron rechazar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeError.ShowDialog()
                            cargarListado()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al Rechazar solicitudes."
                        objMensajeError.ShowDialog()
                    End Try
                End If
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus SOLICITADO para Rechazarlas."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
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

    Private Sub cargarListado()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            If validarFiltros() Then
                Dim objBu As New Negocios.ModSalarioMixtoBU
                Dim dtListado As New DataTable

                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim estatusId As Integer = cmbEstatus.SelectedValue
                Dim periodo As Boolean = chkPeriodo.Checked
                Dim fInicio As String = dtpFechaInicio.Value.ToShortDateString
                Dim fFin As String = dtpFechaFin.Value.ToShortDateString

                dtListado = objBu.consultarListaSolicitudesModificacionSalario(patronId, estatusId, colaboradorIds, periodo, fInicio, fFin)
                If dtListado.Rows.Count > 0 Then
                    grdListadoSolicitudes.DataSource = dtListado
                    disenioGrid()
                Else
                    grdListadoSolicitudes.DataSource = Nothing
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.Show()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de solicitudes de modificacion de salario."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If cmbEstatus.Items.Count > 1 And cmbEstatus.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Estatus."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If chkPeriodo.Checked Then
            Dim entFechaInicio As Integer = 0
            Dim entFechaFin As Integer = 0
            entFechaInicio = CInt(dtpFechaInicio.Value.ToString("yyyyMMdd"))
            entFechaFin = CInt(dtpFechaFin.Value.ToString("yyyyMMdd"))

            If entFechaFin < entFechaInicio Then
                objMensajeAdv.mensaje = "La fecha inicial no puede ser mayor a la fecha final del filtro por periodo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        With grdListadoSolicitudes.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("ColaboradorId").Hidden = True
            .Columns("modsalm_usuariosolicita").Hidden = True

            .Columns("nombreCompleto").Header.Caption = "Colaborador"
            .Columns("modsalm_bimestre").Header.Caption = "Bimestre"
            .Columns("modsalm_salariodiariofijo").Header.Caption = "Salario Diario Integrado Fijo"
            .Columns("modsalm_salariodiariovariable").Header.Caption = "Salario Diario Integrado Variable"
            .Columns("modsalm_salariodiarioneto").Header.Caption = "Salario Diario Integrado Neto"
            .Columns("user_username").Header.Caption = "Usuario Solicitó"

            .Columns("Clave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NSS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombreCompleto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("modsalm_bimestre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("modsalm_salariodiariofijo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("modsalm_salariodiariovariable").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("modsalm_salariodiarioneto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Solicitud").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("user_username").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Movimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Selección").Header.VisiblePosition = 0
            .Columns("Selección").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Fecha Movimiento").Format = "dd/MM/yyyy"
            .Columns("Fecha Solicitud").Format = "dd/MM/yyyy H:mm"
            .Columns("modsalm_salariodiariofijo").Format = "$##,##0.00"
            .Columns("modsalm_salariodiariovariable").Format = "$##,##0.00"
            .Columns("modsalm_salariodiarioneto").Format = "$##,##0.00"
            '.Columns("Excedente").Format = "$##,##0.00"

            .Columns("modsalm_salariodiariofijo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("modsalm_salariodiariovariable").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("modsalm_salariodiarioneto").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("modsalm_bimestre").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.Columns("Excedente").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            grdListadoSolicitudes.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            '.Columns("Motivo Rechazo").MaxWidth = 200

            '.Columns("Nombre(s)").CharacterCasing = CharacterCasing.Upper

        End With

        grdListadoSolicitudes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListadoSolicitudes.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListadoSolicitudes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListadoSolicitudes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        'grdListadoSolicitudes.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        'formatoColorFila()
    End Sub
    Private Sub formatoColorFila()
        Try
            For Each row As UltraGridRow In grdListadoSolicitudes.Rows
                If CDbl(row.Cells("Excedente").Value) > 0 Then
                    row.Appearance.ForeColor = Color.Red
                End If
                If row.Cells("Fecha Movimiento").Value = "01/01/1900" Then
                    row.Cells("Fecha Movimiento").Appearance.ForeColor = Color.Transparent
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnPDFAcuse_Click(sender As Object, e As EventArgs) Handles btnPDFAcuse.Click, lblPDFAcuse.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0
        Dim colaboradorId As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("ID").Value
                colaboradorId = row.Cells("ColaboradorId").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsSolicitud(0) As Integer
            idsSolicitud(0) = solicitudId
            If validarEstatus(4, idsSolicitud) Then
                Dim objForm As New ModSalarioMixtoPDFAcuseForm
                If Not CheckForm(objForm) Then

                    Dim formaSubirPdf As New ModSalarioMixtoPDFAcuseForm
                    formaSubirPdf.solicitudId = solicitudId
                    formaSubirPdf.colaboradorId = colaboradorId
                    formaSubirPdf.ShowDialog()

                    If formaSubirPdf.guardado Then
                        cargarListado()
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "La solicitudes debe de estar en estatus AUTORIZADO o REGRESADO IDSE para subir el PDF de Acuse."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click, lblExportar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdListadoSolicitudes.Rows.Count > 0 Then
            Try
                Dim grid As New UltraGrid
                grid = grdListadoSolicitudes
                grid.DisplayLayout.Bands(0).Columns("Selección").Hidden = True

                Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")
                        archivo = "Modificacion_de_Salario_Mixto_" & fecha_hora & ".xlsx"
                        gridExcelExporter.Export(grid, .SelectedPath & "\" & archivo)
                        grid.DisplayLayout.Bands(0).Columns("Selección").Hidden = False
                    End If
                    objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                    objMensajeExito.ShowDialog()
                    .Dispose()
                End With
            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbEmpresa.SelectedValue
                objForm.ShowDialog()
                colaboradorIds = String.Empty
                colaboradorIds = objForm.colaboradorIds

                If colaboradorIds <> "" Then
                    pnlArchivoCargado.Visible = True
                Else
                    pnlArchivoCargado.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargarListado()
    End Sub

    Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged
        If chkPeriodo.Checked Then
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True
        Else
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        grdListadoSolicitudes.DataSource = Nothing
        colaboradorIds = String.Empty
        pnlArchivoCargado.Visible = False
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsSolicitudes() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsSolicitudes(contSeleccionadas)
                idsSolicitudes(contSeleccionadas) = row.Cells("ID").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(1, idsSolicitudes) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                If contSeleccionadas > 1 Then
                    objMensajeConf.mensaje = "¿Está seguro de autorizar los " & contSeleccionadas & " registros seleccionados?"
                Else
                    objMensajeConf.mensaje = "¿Está seguro de autorizar el registro seleccionado?"
                End If


                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.ModSalarioMixtoBU
                    Dim resultado As String = String.Empty
                    Dim contAutorizadas As Integer = 0

                    Try
                        For item As Integer = 0 To idsSolicitudes.Length - 1
                            Try
                                resultado = objBU.cambiarEstatus(idsSolicitudes(item), 1, "")

                                If resultado = "EXITO" Then
                                    contAutorizadas += 1
                                End If

                            Catch ex As Exception
                                resultado = "ERROR"
                            End Try
                        Next

                        If contSeleccionadas = contAutorizadas Then
                            objMensajeExito.mensaje = "Solicitudes Autorizadas correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contAutorizadas = 0 Then
                            objMensajeError.mensaje = "Error no se pudieron autorizar las solicitudes."
                            objMensajeError.ShowDialog()
                        ElseIf contSeleccionadas > contAutorizadas Then
                            objMensajeError.mensaje = "Algunas solicitudes seleccionadas no se pudieron autorizar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeError.ShowDialog()
                            cargarListado()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al autorizar solicitudes."
                        objMensajeError.ShowDialog()
                    End Try
                End If
            Else
                objMensajeAdv.mensaje = "Las solicitudes deben de estar en estatus SOLICITADO para Autorizarlas."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarFiltros()
    End Sub
    Private Sub limpiarFiltros()
        grdListadoSolicitudes.DataSource = Nothing

        If cmbEmpresa.Items.Count > 1 Then
            cmbEmpresa.SelectedIndex = 0
        End If
        If cmbEstatus.Items.Count > 1 Then
            cmbEstatus.SelectedIndex = 0
        End If

        colaboradorIds = String.Empty
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        chkPeriodo.Checked = False

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click, lblAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaModSalMixtoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaModSalMixtoToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_ComisionesModificacionSalario_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_ComisionesModificacionSalario_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ModificaciónSalarioMixtoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaciónSalarioMixtoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_ComisionesModificacionSalario_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_ComisionesModificacionSalario_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ModificaciónSalarioMixtoPropuestaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaciónSalarioMixtoPropuestaToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "Contabilidad_SAY_ComisionesNominaFiscalModificacionSalario_Jul2019_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\Contabilidad_SAY_ComisionesNominaFiscalModificacionSalario_Jul2019_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click, lblVer.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim solicitudId As Integer = 0

        For Each row As UltraGridRow In grdListadoSolicitudes.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                solicitudId = row.Cells("ID").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            Dim idsSolicitud(0) As Integer
            idsSolicitud(0) = solicitudId
            Dim objForm As New EditarSolicituModSalarioMixtoForm
            If Not CheckForm(objForm) Then

                    Dim formaAltas As New EditarSolicituModSalarioMixtoForm
                    formaAltas.editar = True
                    formaAltas.versolicitud = True
                    formaAltas.solicitudId = solicitudId
                    formaAltas.ShowDialog()

                    If formaAltas.guardado Then
                        cargarListado()
                    End If
                End If            
        End If

    End Sub
End Class