Imports Infragistics.Win.UltraWinGrid
Imports System.Net

Public Class AltaSucursal
    Dim sucursal As New Entidades.SucursalesFacturacion
    Dim sucursalemp As New Entidades.SucursalEmpresa
    Dim sucursalusu As New Entidades.SucursalUsuario
    Public sucursalId As Integer
    Public sucursalEmpresa As Integer = 0
    Public permiso As Boolean
    Dim archivoImg As String = ""
    'Dim ftp As String = "ftp://192.168.7.16"
    Dim rutaRaiz As String = "Administracion/ConfiguracionEmpresas/"
    Dim rutaLogo As String = "Logos_sucursales"
    Dim filaE As Int32 = -1
    Dim filaUNA As Int32 = 0
    Dim filaUA As Int32 = 0
    Dim editarF As Boolean = False

    Private Sub AltaSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tools.Controles.ComboEstadosAnidado(cmbEstado, 1)
        cargarEmpresas()
        cargarReportes()
        cargarReportesRemision()
        iniciarGridEmpresas()
        cargarUsuariosNA()
        iniciarGridUsuariosA()
        cargarDatos()

        If Not permiso Then
            desabilitarCampos()
        End If
    End Sub

    Private Sub btnExaminarImagen_Click(sender As Object, e As EventArgs) Handles btnExaminarImagen.Click
        opfArchivoImg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        opfArchivoImg.Filter = "JPEG, JPG, PNG|*.jpeg; *.jpg; *.png;"
        opfArchivoImg.FilterIndex = 3
        opfArchivoImg.ShowDialog()
        archivoImg = opfArchivoImg.FileName
        abrirImagen(archivoImg)
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

    Private Sub btnAgregarEmpresa_Click(sender As Object, e As EventArgs) Handles btnAgregarEmpresa.Click
        Dim strActivo As String = ""

        If validarEmpresa() Then
            If Not editarF Then
                grdEmpresas.Rows.Band.AddNew()
                filaE = grdEmpresas.Rows.Count - 1
            End If


            If rdbFActivoSi.Checked = True Then
                strActivo = "SI"
            Else
                strActivo = "NO"
            End If

            grdEmpresas.Rows(filaE).Cells("suem_sucursalempresaid").Value = sucursalEmpresa
            grdEmpresas.Rows(filaE).Cells("suem_sucursalid").Value = sucursalId
            grdEmpresas.Rows(filaE).Cells("suem_empresaid").Value = cmbEmpresas.SelectedValue
            grdEmpresas.Rows(filaE).Cells("EMPRESA").Value = cmbEmpresas.Text
            grdEmpresas.Rows(filaE).Cells("SERIE").Value = txtSerie.Text
            If txtFolioActual.Text <> "" Then
                grdEmpresas.Rows(filaE).Cells("FOLIO ACTUAL").Value = txtFolioActual.Text
            End If
            grdEmpresas.Rows(filaE).Cells("FOLIO INICIO").Value = txtFolioInicio.Text
            grdEmpresas.Rows(filaE).Cells("FOLIO FIN").Value = txtFolioFin.Text
            grdEmpresas.Rows(filaE).Cells("ACTIVO").Value = strActivo
            If cmbReporteFacturacion.SelectedIndex = 0 Or cmbReporteFacturacion.SelectedIndex = -1 Then
                grdEmpresas.Rows(filaE).Cells("suem_reportefacturaid").Value = 0
            Else
                grdEmpresas.Rows(filaE).Cells("suem_reportefacturaid").Value = cmbReporteFacturacion.SelectedValue
            End If
            If cmbReporteFacturacion.SelectedIndex = 0 Or cmbReporteFacturacion.SelectedIndex = -1 Then
                grdEmpresas.Rows(filaE).Cells("suem_reportecancelacionid").Value = 0
            Else
                grdEmpresas.Rows(filaE).Cells("suem_reportecancelacionid").Value = cmbReporteFacturacion.SelectedValue
            End If
            grdEmpresas.Rows(filaE).Cells("suem_imprimirsucursal").Value = chkImprimeDomicilio.Checked

            limpiarCampos()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCampos()
    End Sub

    Private Sub grdEmpresas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdEmpresas.DoubleClickRow
        Try
            lblEmpresa.ForeColor = Color.Black
            lblSerie.ForeColor = Color.Black
            lblFolioInicio.ForeColor = Color.Black
            lblFolioFin.ForeColor = Color.Black
            If e.Row.Cells("suem_empresaid").Value <> 0 Then
                lblAgregar.Text = "Cambiar"
                filaE = e.Row.Index
                editarF = True
                cargarDatosFacturacion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdUsuariosNoAsignados_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdUsuariosNoAsignados.ClickCell
        grdUsuariosNoAsignados.ActiveRow.Selected = True
    End Sub

    Private Sub grdUsuariosAsignados_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdUsuariosAsignados.ClickCell
        grdUsuariosAsignados.ActiveRow.Selected = True
    End Sub

    Private Sub btnPasaAsignado_Click(sender As Object, e As EventArgs) Handles btnPasaAsignado.Click
        Dim cntFilas As Integer = 0
        Dim index As Integer = 0

        cntFilas = grdUsuariosNoAsignados.Rows.Count - 1
        While index <= cntFilas
            If grdUsuariosNoAsignados.Rows(index).Selected Then
                grdUsuariosAsignados.Rows.Band.AddNew()
                filaUA = grdUsuariosAsignados.Rows.Count - 1
                grdUsuariosAsignados.Rows(filaUA).Cells("user_usuarioid").Value = grdUsuariosNoAsignados.Rows(index).Cells("user_usuarioid").Value
                grdUsuariosAsignados.Rows(filaUA).Cells("NOMBRE").Value = grdUsuariosNoAsignados.Rows(index).Cells("NOMBRE").Value
                grdUsuariosAsignados.Rows(filaUA).Cells("USUARIO").Value = grdUsuariosNoAsignados.Rows(index).Cells("USUARIO").Value

                grdUsuariosNoAsignados.Rows(index).Delete(False)
                cntFilas = cntFilas - 1
            Else
                index = index + 1
            End If
        End While
    End Sub

    Private Sub btnQuitaAsignado_Click(sender As Object, e As EventArgs) Handles btnQuitaAsignado.Click
        Dim cntFilas As Integer = 0
        Dim index As Integer = 0

        cntFilas = grdUsuariosAsignados.Rows.Count - 1
        While index <= cntFilas
            If grdUsuariosAsignados.Rows(index).Selected Then
                grdUsuariosNoAsignados.Rows.Band.AddNew()
                filaUA = grdUsuariosNoAsignados.Rows.Count - 1
                grdUsuariosNoAsignados.Rows(filaUA).Cells("user_usuarioid").Value = grdUsuariosAsignados.Rows(index).Cells("user_usuarioid").Value
                grdUsuariosNoAsignados.Rows(filaUA).Cells("NOMBRE").Value = grdUsuariosAsignados.Rows(index).Cells("NOMBRE").Value
                grdUsuariosNoAsignados.Rows(filaUA).Cells("USUARIO").Value = grdUsuariosAsignados.Rows(index).Cells("USUARIO").Value

                grdUsuariosAsignados.Rows(index).Delete(False)
                cntFilas = cntFilas - 1
            Else
                index = index + 1
            End If
        End While
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.SucursalesBU
        Dim objEBU As New Negocios.EmpresasBU
        Dim objMensajeExito As New Tools.ExitoForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        Try
            If validarCampos() Then
                If validarDatos() Then
                    If validarLogo() Then
                        sucursal.SID = sucursalId
                        sucursal.SNombre = txtNombre.Text
                        sucursal.SCalle = txtCalle.Text
                        sucursal.SNumero = txtNumero.Text
                        sucursal.SColonia = txtColonia.Text
                        sucursal.SCp = txtCp.Text
                        sucursal.SCiudadid = cmbCiudad.SelectedValue
                        sucursal.SFacturaproductos = chkFacturaProductos.Checked
                        sucursal.SRemisiona = chkRemisiona.Checked
                        If chkRemisiona.Checked Then
                            sucursal.SReporteRemision = ddlReporteRemision.SelectedValue
                        End If
                        If rdbActivoSi.Checked Then
                            sucursal.SActivo = True
                        Else
                            sucursal.SActivo = False
                        End If
                        sucursal.SLogo = subirLogo(archivoImg)

                        sucursalId = objBU.guardarConfiguracionSucursal(sucursal)

                        If sucursalId <> 0 Then
                            For i As Integer = 0 To grdEmpresas.Rows.Count - 1
                                sucursalemp.SEId = grdEmpresas.Rows(i).Cells("suem_sucursalempresaid").Value
                                sucursalemp.SESucursalid = sucursalId
                                sucursalemp.SEEmpresaid = grdEmpresas.Rows(i).Cells("suem_empresaid").Value
                                sucursalemp.SESerie = grdEmpresas.Rows(i).Cells("SERIE").Value
                                sucursalemp.SEFolioinicio = CInt(grdEmpresas.Rows(i).Cells("FOLIO INICIO").Text)
                                sucursalemp.SEFoliofinal = CInt(grdEmpresas.Rows(i).Cells("FOLIO FIN").Value)
                                sucursalemp.SEReportefacturaid = CInt(grdEmpresas.Rows(i).Cells("suem_reportefacturaid").Value)
                                sucursalemp.SEReportecancelacionid = CInt(grdEmpresas.Rows(i).Cells("suem_reportecancelacionid").Value)
                                sucursalemp.SEImprimirsucursal = grdEmpresas.Rows(i).Cells("suem_imprimirsucursal").Value

                                If grdEmpresas.Rows(i).Cells("ACTIVO").Value = "SI" Then
                                    sucursalemp.SEActivo = True
                                Else
                                    sucursalemp.SEActivo = False
                                End If

                                objBU.guardarSucursalEmpresa(sucursalemp)
                            Next

                            For i As Integer = 0 To grdUsuariosNoAsignados.Rows.Count - 1
                                sucursalusu.SUUsuarioid = grdUsuariosNoAsignados.Rows(i).Cells("user_usuarioid").Value
                                sucursalusu.SUSucursaldid = sucursalId

                                objBU.eliminaSucursalUsuario(sucursalusu)
                            Next

                            For i As Integer = 0 To grdUsuariosAsignados.Rows.Count - 1
                                sucursalusu.SUUsuarioid = grdUsuariosAsignados.Rows(i).Cells("user_usuarioid").Value
                                sucursalusu.SUSucursaldid = sucursalId

                                If Not objBU.ExisteRegistro(sucursalusu) Then
                                    objBU.guardarSucursalUsuario(sucursalusu)
                                End If
                            Next

                            objMensajeExito.mensaje = "El registro se ha guardado con exito."
                            objMensajeExito.ShowDialog()

                            Me.Close()
                        Else
                            objMensajeAdv.mensaje = "Error al guardar el registro."
                            objMensajeAdv.ShowDialog()
                            Exit Sub
                        End If
                    End If
                End If
            Else
                objMensajeAdv.mensaje = "Existen campos obligatorios que no se han capturado."
                objMensajeAdv.ShowDialog()
            End If
        Catch
            objMensajeAdv.mensaje = "Error al guardar el registro."
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

    Private Sub cargarEmpresas()
        Dim datos As New Negocios.EmpresasBU
        Dim lstEmpresas As New DataTable

        lstEmpresas = datos.getEmpresasActivas
        If Not lstEmpresas.Rows.Count = 0 Then
            lstEmpresas.Rows.InsertAt(lstEmpresas.NewRow, 0)
            cmbEmpresas.DataSource = lstEmpresas
            cmbEmpresas.DisplayMember = "empr_nombre"
            cmbEmpresas.ValueMember = "empr_empresaid"
        End If
    End Sub

    Private Sub cargarReportes()
        Dim datos As New Negocios.EmpresasBU
        Dim lstReportes As New DataTable
        Dim lstReportesCanc As New DataTable

        lstReportes = datos.getReportes
        If Not lstReportes.Rows.Count = 0 Then
            lstReportes.Rows.InsertAt(lstReportes.NewRow, 0)
            cmbReporteFacturacion.DataSource = lstReportes
            cmbReporteFacturacion.DisplayMember = "repo_nombrereporte"
            cmbReporteFacturacion.ValueMember = "repo_reporteid"
        End If

        lstReportesCanc = datos.getReportes
        If Not lstReportesCanc.Rows.Count = 0 Then
            lstReportesCanc.Rows.InsertAt(lstReportesCanc.NewRow, 0)
            cmbReporteCancelacion.DataSource = lstReportesCanc
            cmbReporteCancelacion.DisplayMember = "repo_nombrereporte"
            cmbReporteCancelacion.ValueMember = "repo_reporteid"
        End If
    End Sub

    Private Sub cargarReportesRemision()
        Dim datos As New Negocios.EmpresasBU
        Dim lstReportes As New DataTable

        lstReportes = datos.getReportesRemision
        If Not lstReportes.Rows.Count = 0 Then
            lstReportes.Rows.InsertAt(lstReportes.NewRow, 0)
            ddlReporteRemision.DataSource = lstReportes
            ddlReporteRemision.DisplayMember = "repo_nombrereporte"
            ddlReporteRemision.ValueMember = "repo_reporteid"
        End If
    End Sub

    Private Sub abrirImagen(ByVal ruta As String)
        Try
            Dim imagen As Image

            imagen = Image.FromFile(ruta)
            ptbLogo.Image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, 140, 80))
        Catch

        End Try
    End Sub

    Private Sub iniciarGridEmpresas()
        Dim dt As New DataTable()

        dt.Columns.Add("suem_sucursalempresaid")
        dt.Columns.Add("suem_sucursalid")
        dt.Columns.Add("suem_empresaid")
        dt.Columns.Add("EMPRESA")
        dt.Columns.Add("SERIE")
        dt.Columns.Add("FOLIO ACTUAL")
        dt.Columns.Add("FOLIO INICIO")
        dt.Columns.Add("FOLIO FIN")
        dt.Columns.Add("ACTIVO")
        dt.Columns.Add("suem_reportefacturaid")
        dt.Columns.Add("suem_reportecancelacionid")
        dt.Columns.Add("suem_imprimirsucursal")

        grdEmpresas.DataSource = dt
        disenioGridEmpresas()
    End Sub

    Public Sub disenioGridEmpresas()
        With grdEmpresas.DisplayLayout.Bands(0)
            .Columns("suem_sucursalempresaid").Hidden = True
            .Columns("suem_sucursalid").Hidden = True
            .Columns("suem_empresaid").Hidden = True
            .Columns("suem_reportefacturaid").Hidden = True
            .Columns("suem_reportecancelacionid").Hidden = True
            .Columns("suem_imprimirsucursal").Hidden = True
            .Columns("suem_imprimirsucursal").Style = ColumnStyle.CheckBox

            .Columns("EMPRESA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SERIE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("FOLIO ACTUAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("FOLIO INICIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("FOLIO FIN").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdEmpresas.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("EMPRESA").Width = 250
            .Columns("SERIE").Width = 100
            .Columns("FOLIO ACTUAL").Width = 100
            .Columns("FOLIO INICIO").Width = 70
            .Columns("FOLIO FIN").Width = 70
            .Columns("ACTIVO").Width = 70

            .Columns("EMPRESA").CharacterCasing = CharacterCasing.Upper
            .Columns("SERIE").CharacterCasing = CharacterCasing.Upper
            .Columns("FOLIO ACTUAL").CharacterCasing = CharacterCasing.Upper
            .Columns("FOLIO INICIO").CharacterCasing = CharacterCasing.Upper
            .Columns("FOLIO FIN").CharacterCasing = CharacterCasing.Upper
            .Columns("ACTIVO").CharacterCasing = CharacterCasing.Upper
        End With

        grdEmpresas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdEmpresas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdEmpresas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdEmpresas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Function validarEmpresa() As Boolean
        Dim objEBU As New Negocios.EmpresasBU
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim validos As Boolean = True
        Dim esNumero As Integer = 0

        If cmbEmpresas.SelectedIndex = 0 Then
            lblEmpresa.ForeColor = Color.Red
            validos = False
        Else
            lblEmpresa.ForeColor = Color.Black
        End If

        If txtSerie.Text = "" Then
            lblSerie.ForeColor = Color.Red
            validos = False
        Else
            lblSerie.ForeColor = Color.Black
        End If

        If txtFolioInicio.Text = "" Then
            lblFolioInicio.ForeColor = Color.Red
            validos = False
        Else
            lblFolioInicio.ForeColor = Color.Black
        End If

        If txtFolioFin.Text = "" Then
            lblFolioFin.ForeColor = Color.Red
            validos = False
        Else
            lblFolioFin.ForeColor = Color.Black
        End If

        If Not validos Then
            objMensajeAdv.mensaje = "Existen campos obligatorios que no se han capturado."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If Not objEBU.validarFacturacionEmpresa(cmbEmpresas.SelectedValue) Then
            lblEmpresa.ForeColor = Color.Red
            objMensajeAdv.mensaje = "La empresa seleccionada no tiene capturados los campos necesarios para la facturación."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblEmpresa.ForeColor = Color.Black
        End If

        If revisarCaracter(txtSerie.Text) Then
            lblSerie.ForeColor = Color.Black
        Else
            lblSerie.ForeColor = Color.Red
            objMensajeAdv.mensaje = "La serie debe ser letra(s)."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

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

        Try
            esNumero = CInt(txtFolioFin.Text)
            lblFolioFin.ForeColor = Color.Black
        Catch ex As Exception
            lblFolioFin.ForeColor = Color.Red
            objMensajeAdv.mensaje = "El folio fin debe ser número entero."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End Try

        If txtFolioActual.Text <> "" Then
            If CInt(txtFolioActual.Text) >= CInt(txtFolioFin.Text) Then
                lblFolioActual.ForeColor = Color.Red
                lblFolioFin.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El folio final no puede ser menor o igual al folio actual."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblFolioActual.ForeColor = Color.Black
                lblFolioFin.ForeColor = Color.Black
            End If
        End If

        If txtFolioInicio.Text <> "" And txtFolioFin.Text <> "" Then
            If CInt(txtFolioFin.Text) <= CInt(txtFolioInicio.Text) Then
                lblFolioInicio.ForeColor = Color.Red
                lblFolioFin.ForeColor = Color.Red
                objMensajeAdv.mensaje = "El folio final no puede ser menor o igual al folio inicial."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            Else
                lblFolioInicio.ForeColor = Color.Black
                lblFolioFin.ForeColor = Color.Black
            End If
        End If

        If cmbReporteFacturacion.SelectedIndex > 0 And cmbReporteCancelacion.SelectedIndex <= 0 Then
            lblReporteCancelacion.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Se ha seleccionado una reporte de facturación pero no un reporte de cancelación. Favor de seleccionar un reporte de cancelación"
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblReporteCancelacion.ForeColor = Color.Black
        End If

        If filaE <> -1 Then
            For i As Integer = 0 To grdEmpresas.Rows.Count - 1
                Dim aux1 As Integer = CInt(grdEmpresas.Rows(i).Cells("suem_empresaid").Value)
                Dim aux2 As Integer = cmbEmpresas.SelectedValue
                If i <> filaE Then
                    If aux1 = aux2 Then
                        lblEmpresa.ForeColor = Color.Red
                        objMensajeAdv.mensaje = "La empresa seleccionada ya esta asignada a la sucursal."
                        objMensajeAdv.ShowDialog()
                        Return False
                        Exit Function
                    End If
                End If
            Next
        Else
            For i As Integer = 0 To grdEmpresas.Rows.Count - 1
                Dim aux1 As Integer = CInt(grdEmpresas.Rows(i).Cells("suem_empresaid").Value)
                Dim aux2 As Integer = cmbEmpresas.SelectedValue
                If aux1 = aux2 Then
                    lblEmpresa.ForeColor = Color.Red
                    objMensajeAdv.mensaje = "La empresa seleccionada ya esta asignada a la sucursal."
                    objMensajeAdv.ShowDialog()
                    Return False
                    Exit Function
                End If
            Next
        End If

        Return True
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

    Private Sub limpiarCampos()
        lblEmpresa.ForeColor = Color.Black
        lblSerie.ForeColor = Color.Black
        lblFolioInicio.ForeColor = Color.Black
        lblFolioFin.ForeColor = Color.Black

        cmbEmpresas.SelectedValue = 0
        txtSerie.Text = ""
        txtFolioInicio.Text = ""
        txtFolioFin.Text = ""
        txtFolioActual.Text = ""
        cmbReporteFacturacion.SelectedValue = 0
        cmbReporteCancelacion.SelectedValue = 0
        rdbFActivoSi.Checked = True
        rdbFActivoNo.Checked = False
        chkImprimeDomicilio.Checked = False
        lblAgregar.Text = "Agregar"
        filaE = 0
        editarF = False
        sucursalEmpresa = 0
    End Sub

    Private Sub cargarDatosFacturacion()
        sucursalEmpresa = grdEmpresas.Rows(filaE).Cells("suem_sucursalempresaid").Value
        cmbEmpresas.SelectedValue = grdEmpresas.Rows(filaE).Cells("suem_empresaid").Value
        txtSerie.Text = grdEmpresas.Rows(filaE).Cells("SERIE").Text
        txtFolioInicio.Text = grdEmpresas.Rows(filaE).Cells("FOLIO INICIO").Text
        txtFolioFin.Text = grdEmpresas.Rows(filaE).Cells("FOLIO FIN").Text
        txtFolioActual.Text = grdEmpresas.Rows(filaE).Cells("FOLIO ACTUAL").Text
        cmbReporteFacturacion.SelectedValue = grdEmpresas.Rows(filaE).Cells("suem_reportefacturaid").Value
        cmbReporteCancelacion.SelectedValue = grdEmpresas.Rows(filaE).Cells("suem_reportecancelacionid").Value
        If grdEmpresas.Rows(filaE).Cells("ACTIVO").Text = "SI" Then
            rdbFActivoSi.Checked = True
        Else
            rdbFActivoNo.Checked = True
        End If
        chkImprimeDomicilio.Checked = grdEmpresas.Rows(filaE).Cells("suem_imprimirsucursal").Value
    End Sub

    Private Sub cargarUsuariosNA()
        Dim objBU As New Negocios.SucursalesBU
        Dim dtUsuarios As New DataTable

        dtUsuarios = objBU.getUsuariosNA(sucursalId)
        If dtUsuarios.Rows.Count > 0 Then
            grdUsuariosNoAsignados.DataSource = dtUsuarios
            disenioGridUsuariosNA()
        Else
            iniciarGridUsuariosNA()
        End If
    End Sub

    Public Sub disenioGridUsuariosA()
        With grdUsuariosAsignados.DisplayLayout.Bands(0)
            .Columns("user_usuarioid").Hidden = True

            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("USUARIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdUsuariosNoAsignados.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("NOMBRE").Width = 250
            .Columns("USUARIO").Width = 100

            .Columns("NOMBRE").CharacterCasing = CharacterCasing.Upper
            .Columns("USUARIO").CharacterCasing = CharacterCasing.Upper
        End With

        grdUsuariosNoAsignados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdUsuariosNoAsignados.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdUsuariosNoAsignados.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdUsuariosNoAsignados.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub iniciarGridUsuariosA()
        Dim dt As New DataTable()

        dt.Columns.Add("user_usuarioid")
        dt.Columns.Add("NOMBRE")
        dt.Columns.Add("USUARIO")

        grdUsuariosAsignados.DataSource = dt
        disenioGridUsuariosA()
    End Sub

    Private Sub iniciarGridUsuariosNA()
        Dim dt As New DataTable()

        dt.Columns.Add("user_usuarioid")
        dt.Columns.Add("NOMBRE")
        dt.Columns.Add("USUARIO")

        grdUsuariosNoAsignados.DataSource = dt
        disenioGridUsuariosNA()
    End Sub

    Public Sub disenioGridUsuariosNA()
        With grdUsuariosNoAsignados.DisplayLayout.Bands(0)
            .Columns("user_usuarioid").Hidden = True

            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("USUARIO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdUsuariosNoAsignados.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("NOMBRE").Width = 250
            .Columns("USUARIO").Width = 100

            .Columns("NOMBRE").CharacterCasing = CharacterCasing.Upper
            .Columns("USUARIO").CharacterCasing = CharacterCasing.Upper
        End With

        grdUsuariosAsignados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdUsuariosAsignados.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdUsuariosAsignados.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdUsuariosAsignados.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub cargarDatos()
        Try
            If sucursalId > 0 Then
                Dim objBU As New Negocios.SucursalesBU
                Dim datos As New Entidades.SucursalesFacturacion

                datos = objBU.getDatosSucursal(sucursalId)

                txtNombre.Text = datos.SNombre
                txtCalle.Text = datos.SCalle
                txtNumero.Text = datos.SNumero
                txtColonia.Text = datos.SColonia
                txtCp.Text = datos.SCp
                cmbEstado.SelectedValue = datos.SEstadoid
                cmbCiudad.SelectedValue = datos.SCiudadid
                chkFacturaProductos.Checked = datos.SFacturaproductos
                chkRemisiona.Checked = datos.SRemisiona

                If chkRemisiona.Checked Then
                    ddlReporteRemision.SelectedValue = datos.SReporteRemision
                End If
                If datos.SActivo Then
                    rdbActivoSi.Checked = True
                Else
                    rdbActivoNo.Checked = True
                End If

                If datos.SLogo <> "" Then
                    archivoImg = datos.SLogo
                    cargarImagen(datos.SLogo)
                End If
                cargarEmpresasSuc()
                cargarUsuariosA()
            End If
        Catch ex As Exception

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

                'Carpeta = Carpeta.Replace(ftp, "")

                Stream = objFTP.StreamFile(Carpeta, nomArchivo)
                imagen = Image.FromStream(Stream)
                ptbLogo.Image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, 119, 51))
            End If
        Catch

        End Try
    End Sub

    Private Sub cargarEmpresasSuc()
        Dim objBU As New Negocios.SucursalesBU
        Dim dtSucEmpresas As New DataTable

        dtSucEmpresas = objBU.getSucEmpresas(sucursalId)
        If dtSucEmpresas.Rows.Count > 0 Then
            grdEmpresas.DataSource = dtSucEmpresas
            disenioGridEmpresas()
        End If
    End Sub

    Private Sub cargarUsuariosA()
        Dim objBU As New Negocios.SucursalesBU
        Dim dtUsuarios As New DataTable

        dtUsuarios = objBU.getUsuariosA(sucursalId)
        If dtUsuarios.Rows.Count > 0 Then
            grdUsuariosAsignados.DataSource = dtUsuarios
            disenioGridUsuariosA()
        End If
    End Sub

    Private Function validarCampos() As Boolean
        Dim validos As Boolean = True

        If txtNombre.Text = "" Then
            lblNombre.ForeColor = Color.Red
            validos = False
        Else
            lblNombre.ForeColor = Color.Black
        End If

        If txtCalle.Text = "" Then
            lblCalle.ForeColor = Color.Red
            validos = False
        Else
            lblCalle.ForeColor = Color.Black
        End If

        If txtNumero.Text = "" Then
            lblNumero.ForeColor = Color.Red
            validos = False
        Else
            lblNumero.ForeColor = Color.Black
        End If

        If txtColonia.Text = "" Then
            lblColonia.ForeColor = Color.Red
            validos = False
        Else
            lblColonia.ForeColor = Color.Black
        End If

        If txtCp.Text = "" Then
            lblCp.ForeColor = Color.Red
            validos = False
        Else
            lblCp.ForeColor = Color.Black
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

        If chkRemisiona.Checked And ddlReporteRemision.SelectedIndex <= 0 Then
            lblReporteRemision.ForeColor = Color.Red
            validos = False
        Else
            lblReporteRemision.ForeColor = Color.Black
        End If

        Return validos
    End Function

    Private Function validarDatos() As Boolean
        Dim objBU As New Negocios.SucursalesBU
        Dim datos As New Entidades.SucursalesFacturacion
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If objBU.ExisteSucursal(txtNombre.Text, sucursalId) Then
            lblNombre.ForeColor = Color.Red
            objMensajeAdv.mensaje = "Ya existe una sucursal con el mismo nombre."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        Else
            lblNombre.ForeColor = Color.Black
        End If

        Return True
    End Function

    Private Function validarLogo() As Boolean
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

        Return True
    End Function

    Private Function subirLogo(ByVal ruta As String) As String
        Dim rutaArchivo As String = ""
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim directorio As String = ""
            Dim tabla() As String
            Dim archivo As String

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaRaiz & rutaLogo

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

    Private Sub desabilitarCampos()
        btnExaminarImagen.Enabled = False
        txtNombre.Enabled = False
        txtCalle.Enabled = False
        txtNumero.Enabled = False
        txtColonia.Enabled = False
        txtCp.Enabled = False
        cmbEstado.Enabled = False
        cmbCiudad.Enabled = False
        chkFacturaProductos.Enabled = False
        rdbActivoSi.Enabled = False
        rdbActivoNo.Enabled = False

        cmbEmpresas.Enabled = False
        txtSerie.Enabled = False
        txtFolioInicio.Enabled = False
        txtFolioFin.Enabled = False
        cmbReporteFacturacion.Enabled = False
        chkImprimeDomicilio.Enabled = False
        rdbFActivoSi.Enabled = False
        rdbFActivoNo.Enabled = False
        btnAgregarEmpresa.Enabled = False
        btnLimpiar.Enabled = False
        grdEmpresas.Enabled = False

        grdUsuariosNoAsignados.Enabled = False
        grdUsuariosAsignados.Enabled = False
        btnPasaAsignado.Enabled = False
        btnQuitaAsignado.Enabled = False

        btnGuardar.Visible = False
        lblGuardar.Visible = False
    End Sub

    Private Sub cmbReporteFacturacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbReporteFacturacion.SelectedIndexChanged
        If cmbReporteFacturacion.SelectedIndex > 0 Then
            cmbReporteCancelacion.Enabled = True
        Else
            cmbReporteCancelacion.SelectedValue = 0
            cmbReporteCancelacion.Enabled = False
        End If
    End Sub

    Private Sub chkRemisiona_CheckedChanged(sender As Object, e As EventArgs) Handles chkRemisiona.CheckedChanged
        If chkRemisiona.Checked Then
            ddlReporteRemision.Enabled = True
        Else
            ddlReporteRemision.Enabled = False
        End If
    End Sub
End Class