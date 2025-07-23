Imports System.Windows.Forms
Imports Infragistics.Win.UltraWinGrid
Imports Framework.Negocios
Imports Tools

Public Class ListaColaboradoresContabilidadForm
    Dim idColaborador As Int32 = 0
    Dim colaborador As String = String.Empty
    Dim nss As String = String.Empty

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ListaColaboradoresContabilidadForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WindowState = FormWindowState.Maximized

        configurarPermisosBotonesEspeciales()
        cargarComboEmpresaPatron()
    End Sub

    Public Sub cargarComboEmpresaPatron()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtEmpresa As New DataTable

        dtEmpresa = objBu.consultarPatronEmpresa()
        If dtEmpresa.Rows.Count > 0 Then
            cmbPatron.DataSource = dtEmpresa
            cmbPatron.DisplayMember = "Patron"
            cmbPatron.ValueMember = "ID"
            cmbPatron.SelectedIndex = 0
        End If
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("LISTA_COLABO", "EDITAR_COLABO") Then
            pnlEditar.Visible = True
        Else
            pnlEditar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("LISTA_COLABO", "ALTA_COLABO") Then
            pnlAltas.Visible = True
        Else
            pnlAltas.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("LISTA_COLABO", "EXPORTAR_COLABO") Then
            pnlExportar.Visible = True
        Else
            pnlExportar.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("LISTA_COLABO", "EXP_COLABO") Then
            pnlConsultaExp.Visible = True
        Else
            pnlConsultaExp.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CONSOLBAJA_CONTA", "SOL_ALTASOLICITUD") Then
            pnlBajas.Visible = True
        Else
            pnlBajas.Visible = False
        End If
    End Sub

    Public Sub consultaColaboradoresContabilidad()
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtLista As New DataTable
        Dim activo As Int32 = 0
        Dim nombre As String = ""
        Dim idPatron As Int32 = 0

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        grdColaboradores.DataSource = Nothing
        If rdoActivoSI.Checked Then
            activo = 1
        Else
            activo = 0
        End If

        idPatron = cmbPatron.SelectedValue
        nombre = txtNombre.Text

        dtLista = objBu.consultaListadoColaboradores(idPatron, activo, nombre)
        If dtLista.Rows.Count > 0 Then
            grdColaboradores.DataSource = dtLista
            darFormatoGrid()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub darFormatoGrid()
        With grdColaboradores.DisplayLayout.Bands(0)

            .Columns("codr_colaboradorid").Hidden = True
            .Columns("umf").Hidden = True
            .Columns("cp").Hidden = True
            .Columns("sexo").Hidden = True
            .Columns("lugarNacimiento").Hidden = True
            .Columns("fechaNacimiento").Hidden = True
            .Columns("calle").Hidden = True
            .Columns("numero").Hidden = True
            .Columns("colonia").Hidden = True
            .Columns("entreCalles").Hidden = True
            .Columns("referencias").Hidden = True
            .Columns("sdi").Hidden = True
            .Columns("tipoTrabajador").Hidden = True
            .Columns("tipoSalario").Hidden = True
            .Columns("tipoJornada").Hidden = True
            .Columns("claveNacimiento").Hidden = True
            .Columns("puestoFiscal").Hidden = True

            .Columns("clave").Header.Caption = "Código del Empleado"
            .Columns("codr_apellidopaterno").Header.Caption = "A. Paterno"
            .Columns("codr_apellidomaterno").Header.Caption = "A. Materno"
            .Columns("codr_nombre").Header.Caption = "Nombre"
            .Columns("codr_rfc").Header.Caption = "RFC"
            .Columns("codr_curp").Header.Caption = "CURP"
            .Columns("cono_nss").Header.Caption = "NSS"
            .Columns("real_fecha").Header.Caption = "F. Alta"
            .Columns("infonavit").Header.Caption = "INFONAVIT"
            .Columns("numeroCredito").Header.Caption = "NO. Crédito"
            .Columns("infonavitFecha").Header.Caption = "Fecha Inicio"
            .Columns("tipoDescuento").Header.Caption = "Tipo Desc"
            .Columns("valordesc").Header.Caption = "Valor Desc"



            .Columns("codr_apellidopaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_apellidomaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_curp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cono_nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("real_fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("infonavit").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("numeroCredito").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("infonavitFecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoDescuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("valordesc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tipo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("valordesc").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


            .Columns("valordesc").Format = "###,###,##0.00"


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        'grdSolicitudes.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        grdColaboradores.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdColaboradores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradores.DisplayLayout.Override.RowSelectorWidth = 35
        grdColaboradores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdColaboradores.Rows(0).Selected = True


        'grdColaboradores.DisplayLayout.Bands(0).Columns("codr_apellidopaterno").Width = 130
        'grdColaboradores.DisplayLayout.Bands(0).Columns("codr_apellidomaterno").Width = 130
        'grdColaboradores.DisplayLayout.Bands(0).Columns("codr_nombre").Width = 130
        grdColaboradores.DisplayLayout.Bands(0).Columns("clave").Width = 80

        grdColaboradores.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        grdColaboradores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Public Sub editarColaborador()
        If idColaborador <= 0 Then
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleccione un colaborador valido"
            advertencia.ShowDialog()
        Else
            Dim editarCol As New AltaColaboradorContabilidadForm
            editarCol.idColaborador = idColaborador
            editarCol.Show()
        End If

    End Sub

    Public Sub exportarExcel()
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim exito As New ExitoForm
        Dim ruta As String = String.Empty
        formatoGridExportar()
        nombreDocumento = "\ListadoColaboradores"
        grid = grdColaboradores

        With fbdUbicacionArchivo

            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                ruta = .SelectedPath + nombreDocumento + fecha_hora + ".xlsx"

                gridExcelExporter.Export(grid, ruta)

                exito.mensaje = "Los datos se exportaron correctamente"
                exito.ShowDialog()
                .Dispose()
            End If
            darFormatoGrid()
        End With
    End Sub

    Public Sub formatoGridExportar()
        With grdColaboradores.DisplayLayout.Bands(0)

            .Columns("codr_colaboradorid").Hidden = True
            .Columns("umf").Hidden = False
            .Columns("cp").Hidden = False
            .Columns("sexo").Hidden = False
            .Columns("lugarNacimiento").Hidden = False
            .Columns("fechaNacimiento").Hidden = False
            .Columns("calle").Hidden = False
            .Columns("numero").Hidden = False
            .Columns("colonia").Hidden = False
            .Columns("entreCalles").Hidden = False
            .Columns("referencias").Hidden = False
            .Columns("sdi").Hidden = False
            .Columns("tipoTrabajador").Hidden = False
            .Columns("tipoSalario").Hidden = False
            .Columns("tipoJornada").Hidden = False
            .Columns("claveNacimiento").Hidden = False
            .Columns("puestoFiscal").Hidden = False

            .Columns("codr_apellidopaterno").Header.Caption = "A. Paterno"
            .Columns("codr_apellidomaterno").Header.Caption = "A. Materno"
            .Columns("codr_nombre").Header.Caption = "Nombre"
            .Columns("codr_rfc").Header.Caption = "RFC"
            .Columns("codr_curp").Header.Caption = "CURP"
            .Columns("cono_nss").Header.Caption = "NSS"
            .Columns("puestoFiscal").Header.Caption = "Ocupación"
            .Columns("real_fecha").Header.Caption = "F. Alta"
            .Columns("umf").Header.Caption = "Unidad Médica Familiar"
            .Columns("cp").Header.Caption = "Código Postal"
            .Columns("sexo").Header.Caption = "Sexo"
            .Columns("lugarNacimiento").Header.Caption = "Lugar Nacimiento"
            .Columns("fechaNacimiento").Header.Caption = "Fecha Nacimiento"
            .Columns("calle").Header.Caption = "Calle"
            .Columns("numero").Header.Caption = "Número"
            .Columns("colonia").Header.Caption = "Colonia"
            .Columns("entreCalles").Header.Caption = "Entre Calles"
            .Columns("referencias").Header.Caption = "Referencias Adicionales"
            .Columns("sdi").Header.Caption = "Salario Diario"
            .Columns("tipoTrabajador").Header.Caption = "Tipo Trabajador"
            .Columns("tipoSalario").Header.Caption = "Tipo Salario"
            .Columns("tipoJornada").Header.Caption = "Tipo Jornada"
            .Columns("claveNacimiento").Header.Caption = "Clave Nacimiento"
            .Columns("infonavit").Header.Caption = "INFONAVIT"
            .Columns("numeroCredito").Header.Caption = "NO. Crédito"
            .Columns("infonavitFecha").Header.Caption = "Fecha Inicio"
            .Columns("tipoDescuento").Header.Caption = "Tipo Desc"
            .Columns("valordesc").Header.Caption = "Valor Desc"



            .Columns("codr_apellidopaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_apellidomaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_curp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cono_nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("puestoFiscal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("real_fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("umf").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sexo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("lugarNacimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fechaNacimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("calle").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("numero").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("colonia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("entrecalles").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("referencias").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sdi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoTrabajador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoSalario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoJornada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("claveNacimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("infonavit").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("numeroCredito").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("infonavitFecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoDescuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("valordesc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit



            .Columns("valordesc").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("sdi").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


            .Columns("valordesc").Format = "###,###,##0.00"
            .Columns("sdi").Format = "###,###,##0.00"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        'grdSolicitudes.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
        grdColaboradores.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdColaboradores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradores.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradores.DisplayLayout.Override.RowSelectorWidth = 35
        grdColaboradores.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdColaboradores.Rows(0).Selected = True


        grdColaboradores.DisplayLayout.Bands(0).Columns("codr_apellidopaterno").Width = 150
        grdColaboradores.DisplayLayout.Bands(0).Columns("codr_apellidomaterno").Width = 150
        grdColaboradores.DisplayLayout.Bands(0).Columns("codr_nombre").Width = 150
        'grdColaboradores.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdColaboradores.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        grdColaboradores.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Public Sub altaColaboradorContabilidad()
        Dim nuevoCol As New AltaColaboradorContabilidadForm
        nuevoCol.Show()
    End Sub

    Public Sub abrirExpedienteColaborador()
        If idColaborador <= 0 Then
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleccione un colaborador valido"
            advertencia.ShowDialog()
        Else
            Dim exp As New ExpedienteColaboradorForm
            exp.idColaborador = idColaborador
            exp.colaborador = colaborador
            exp.nss = nss
            exp.ShowDialog()
        End If


    End Sub

    Public Sub limpiarCampos()
        grdColaboradores.DataSource = Nothing
        cmbPatron.SelectedIndex = 0
        txtNombre.Text = ""
        rdoActivoSI.Checked = True
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        consultaColaboradoresContabilidad()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            consultaColaboradoresContabilidad()
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        altaColaboradorContabilidad()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editarColaborador()
    End Sub


    Private Sub grdColaboradores_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdColaboradores.ClickCell
        Dim TipoCliente As String = ""
        Dim row As UltraGridRow = grdColaboradores.ActiveRow
        With grdColaboradores
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With


        If row.IsFilterRow Then Return

        TipoCliente = row.Cells("Tipo").Value()
        If rdoActivoSI.Checked = True Then
            If TipoCliente = "EXTERNO" Then
                btnBajaColaborador.Enabled = True
            Else
                btnBajaColaborador.Enabled = False
            End If
        Else
            btnBajaColaborador.Enabled = False
        End If

        


        idColaborador = grdColaboradores.ActiveRow.Cells("codr_colaboradorid").Value()
        colaborador = grdColaboradores.ActiveRow.Cells("codr_nombre").Value() + " " + grdColaboradores.ActiveRow.Cells("codr_apellidopaterno").Value() + " " + grdColaboradores.ActiveRow.Cells("codr_apellidomaterno").Value()
        nss = grdColaboradores.ActiveRow.Cells("cono_nss").Value()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdColaboradores.Height = 471
        grdColaboradores.Top = 115
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 118
        grdColaboradores.Height = 346
        grdColaboradores.Top = 240
    End Sub

    Private Sub btnConsultarExp_Click(sender As Object, e As EventArgs) Handles btnConsultarExp.Click
        abrirExpedienteColaborador()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        limpiarCampos()
    End Sub

    Private Sub btnBajaColaborador_Click(sender As Object, e As EventArgs) Handles btnBajaColaborador.Click
        Dim objSolicitudBaja As New Contabilidad.Negocios.SolicitudBajaBU
        Dim FormSolicutdBajas As New SolicitudBajaColaboradorExternoForm
        Dim ColaboradorID As Integer = -1
        Dim DTSolicitudBaja As DataTable

        ColaboradorID = grdColaboradores.ActiveRow.Cells("codr_colaboradorid").Value()
        DTSolicitudBaja = objSolicitudBaja.ConsultarSolicitudBajaExterno(ColaboradorID)
        If DTSolicitudBaja.Rows.Count > 0 Then
            show_message("Advertencia", "El colaborador ya cuenta con una solicitud de baja.")
        Else
            FormSolicutdBajas.ColaboradorID = ColaboradorID
            FormSolicutdBajas.Show()
        End If
    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultadoDialogo As DialogResult

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then
            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultadoDialogo = mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultadoDialogo = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultadoDialogo = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultadoDialogo = mensajeExito.ShowDialog()

        End If

        Return ResultadoDialogo
    End Function

    Private Sub grdColaboradores_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdColaboradores.DoubleClickCell
        If idColaborador <= 0 Then
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleccione un colaborador valido"
            advertencia.ShowDialog()
        Else
            Dim objForm As New AltaColaboradorContabilidadForm
            objForm.idColaborador = idColaborador
            objForm.Panel2.Enabled = False
            objForm.btnGuardar.Enabled = False
            objForm.Show()
        End If

    End Sub
End Class