Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Nomina.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ListaColaboradoresForm
    Dim AltaColaborador As New AltasColaboradoresForm
    Public IDColaborador As Int32 = 0
    Dim naveID As Integer
    Dim Consecutivoin As New Int32
    Dim Departamento As String
    Dim dtColaboradorIdCred As New DataTable

    Private Sub ListaColaboradoresForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' LlenarTabla() 'revisar este evento... 
        initcombos()
        'grdColaboradores.EnableHeadersVisualStyles = False
        'grdColaboradores.ReadOnly = True
        'IDColaborador = grdColaboradores.Rows(0).Cells("colId").Value
        WindowState = FormWindowState.Maximized

        pnlInhabilitar.Visible = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_COL_CODR", "INACTIVAR")
        permisos()
    End Sub

    Private Sub permisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_COL_CODR", "IMPRIMIR_FINIQUITO") Then
            pnlImprimirReporte.Visible = True
            pnlFechaReporte.Visible = True

        Else
            pnlImprimirReporte.Visible = False
            pnlFechaReporte.Visible = False
        End If
    End Sub

    Public Sub initcombos()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

    End Sub

    'Public Sub LlenarTabla()
    '    Consecutivoin = 1
    '    grdColaboradores.Rows.Clear()
    '    Dim objColaboradorBU As New ColaboradoresBU
    '    Dim listaColaboradores As New List(Of Entidades.Colaborador)
    '    Dim idNave = 0
    '    Dim idDepartamento = 0
    '    Dim idPuesto = 0

    '    If cmbNave.SelectedValue > 0 Then
    '        idNave = cmbNave.SelectedValue
    '    End If
    '    If cmbDepto.SelectedIndex > 0 Then
    '        idDepartamento = cmbDepto.SelectedValue
    '    End If
    '    If cmbPuesto.SelectedIndex > 0 Then
    '        idPuesto = cmbPuesto.SelectedValue
    '    End If

    '    listaColaboradores = objColaboradorBU.ListaColaboradoresFiltroCompleto _
    '        (txtNombre.Text, txtCurp.Text, txtRFC.Text, rdoActivoSi.Checked, idNave, idDepartamento, idPuesto, rdoExternoSI.Checked)
    '    For Each colaborador As Entidades.Colaborador In listaColaboradores
    '        AgregarFila(colaborador)
    '        Consecutivoin += 1
    '    Next
    '    IDColaborador = grdColaboradores.Rows(0).Cells("colId").Value
    'End Sub

    Public Sub LlenarTabla()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim objFiltros As New Entidades.FiltrosFichaColaborador
            Dim objBU As New ColaboradoresBU
            Dim idNave = 0
            Dim idDepartamento = 0
            Dim idPuesto = 0

            vwColaboradores.Columns.Clear()
            grdColaboradores.DataSource = Nothing

            If cmbNave.SelectedValue > 0 Then
                idNave = cmbNave.SelectedValue
                naveID = cmbNave.SelectedValue
            End If
            If cmbDepto.SelectedIndex > 0 Then
                idDepartamento = cmbDepto.SelectedValue
            End If
            If cmbPuesto.SelectedIndex > 0 Then
                idPuesto = cmbPuesto.SelectedValue
            End If

            With objFiltros
                .PNombre = txtNombre.Text
                .PCURP = txtCurp.Text
                .PRFC = txtRFC.Text
                .PActivo = rdoActivoSi.Checked
                .PIdNave = idNave
                .PIdDepartamento = idDepartamento
                .PIdPuesto = idPuesto
                .PExterno = rdoExternoSI.Checked
            End With

            Dim dtDatos As New DataTable
            dtDatos = objBU.ListaColaboradoresFiltroCompleto(objFiltros)

            If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                grdColaboradores.DataSource = dtDatos
                disenioGrid()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información para mostrar.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la información.")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub disenioGrid()
        Tools.DiseñoGrid.AlternarColorEnFilas(vwColaboradores)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwColaboradores)
        vwColaboradores.BestFitColumns()

        If IsNothing(vwColaboradores.Columns.FirstOrDefault(Function(x) x.FieldName = "Antiguedad")) = True Then
            vwColaboradores.Columns.AddVisible("Antiguedad").UnboundType = DevExpress.Data.UnboundColumnType.Integer
            AddHandler vwColaboradores.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            vwColaboradores.Columns.Item("Antiguedad").VisibleIndex = 9
        End If

        vwColaboradores.Columns("real_fecha").Visible = False
        vwColaboradores.Columns.ColumnByFieldName("Id").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        vwColaboradores.Columns.ColumnByFieldName("Fila").Caption = "#"
        vwColaboradores.Columns.ColumnByFieldName("Antiguedad").Caption = "Antigüedad"
        vwColaboradores.Columns.ColumnByFieldName("TipoSueldo").Caption = "Tipo Sueldo"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwColaboradores.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = vwColaboradores.GetRowHandle(e.ListSourceRowIndex)

            Dim Diastrabajados, anios, meses As Int32
            Dim cantidad As Double
            Dim texto As String

            If rdoActivoSi.Checked Then
                Diastrabajados = DateDiff("y", CDate(vwColaboradores.GetRowCellValue(vwColaboradores.GetRowHandle(e.ListSourceRowIndex), "real_fecha")), Date.Today)
                anios = Diastrabajados \ 365
                meses = (Diastrabajados Mod 365) \ 30.4

            Else
                Dim objFiniquito As New Negocios.FiniquitosBU
                Dim finiquito As New Entidades.Finiquitos
                finiquito = objFiniquito.BuscarFiniquito(vwColaboradores.GetRowCellValue(vwColaboradores.GetRowHandle(e.ListSourceRowIndex), "Id"))
                anios = finiquito.PAntiguedadAnios
                meses = finiquito.PAntiguedadMeses
            End If

            cantidad = Math.Round(anios + ((meses * 1) / 12), 2)
            texto = cantidad.ToString + " Años"

            e.Value = texto

        End If
    End Sub

    'Public Sub AgregarFila(ByVal colaborador As Entidades.Colaborador)
    '    Dim celda As DataGridViewCell
    '    Dim fila As New DataGridViewRow


    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = colaborador.PColaboradorid
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = Consecutivoin
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = colaborador.PNombre.ToUpper + " " + colaborador.PApaterno.ToUpper + " " + colaborador.PAmaterno.ToUpper
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = colaborador.pCurp
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = colaborador.PRfc
    '    fila.Cells.Add(celda)

    '    Dim laboral As New Entidades.ColaboradorLaboral
    '    Dim objLaboralBU As New Negocios.ColaboradorLaboralBU
    '    laboral = objLaboralBU.buscarInformacionLaboral(colaborador.PColaboradorid)
    '    If Not IsNothing(laboral) Then
    '        celda = New DataGridViewTextBoxCell
    '        If Not IsNothing(laboral.PNaveId) Then
    '            celda.Value = laboral.PNaveId.PNombre.ToUpper
    '        End If
    '        fila.Cells.Add(celda)

    '        celda = New DataGridViewTextBoxCell
    '        If Not IsNothing(laboral.PDepartamentoId) Then
    '            celda.Value = laboral.PDepartamentoId.DNombre.ToUpper
    '        End If
    '        fila.Cells.Add(celda)

    '        celda = New DataGridViewTextBoxCell
    '        If Not IsNothing(laboral.PDepartamentoId) Then
    '            If Not IsNothing(laboral.PPuestoId) Then
    '                celda.Value = laboral.PPuestoId.PNombre.ToUpper
    '            End If

    '        End If
    '        fila.Cells.Add(celda)
    '    End If

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = colaborador.PNaveID
    '    fila.Cells.Add(celda)


    '    Dim Diastrabajados, anios, meses As Int32
    '    Dim cantidad As Double
    '    Dim texto As String

    '    If rdoActivoSi.Checked Then
    '        Diastrabajados = DateDiff("y", CDate(colaborador.PFechaCreacion), Date.Today)
    '        anios = Diastrabajados \ 365
    '        meses = (Diastrabajados Mod 365) \ 30.4

    '    Else
    '        Dim objFiniquito As New Negocios.FiniquitosBU
    '        Dim finiquito As New Entidades.Finiquitos
    '        finiquito = objFiniquito.BuscarFiniquito(colaborador.PColaboradorid)
    '        anios = finiquito.PAntiguedadAnios
    '        meses = finiquito.PAntiguedadMeses
    '    End If

    '    cantidad = Math.Round(anios + ((meses * 1) / 12), 2)
    '    texto = cantidad.ToString + " Años"
    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = texto
    '    fila.Cells.Add(celda)

    '    grdColaboradores.Rows.Add(fila)
    'End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtNombre.Text = ""
        txtCurp.Text = ""
        txtRFC.Text = ""
        cmbNave.Text = ""
        cmbDepto.Text = ""
        cmbPuesto.Text = ""
        rdoActivoSi.Checked = True
        'grdColaboradores.Rows.Clear()
        vwColaboradores.Columns.Clear()
        grdColaboradores.DataSource = Nothing
        lblNave.ForeColor = Color.Black
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor.Current = Cursors.WaitCursor
        LlenarTabla()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        Dim formaAltas As New AltasColaboradoresForm
        formaAltas.Show()
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grbFiltros.Height = 36
        grdColaboradores.Height = 471
        grdColaboradores.Top = 115
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grbFiltros.Height = 161
        grdColaboradores.Height = 346
        grdColaboradores.Top = 240
    End Sub

    'Private Sub grdColaboradores_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 Then

    '        IDColaborador = CInt(grdColaboradores.Rows(e.RowIndex).Cells("colId").Value)
    '        naveID = CInt(grdColaboradores.Rows(e.RowIndex).Cells("clmnaveID").Value)
    '        Departamento = CStr(grdColaboradores.Rows(e.RowIndex).Cells("colDepto").Value)

    '    End If

    'End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        IDColaborador = 0

        If vwColaboradores.SelectedRowsCount > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Sólo se puede editar un colaborador a la vez.")
        Else
            Dim Fila As Integer = vwColaboradores.DataRowCount

            For item As Integer = 0 To Fila Step 1
                If CBool(vwColaboradores.IsRowSelected(vwColaboradores.GetVisibleRowHandle(item))) = True Then
                    IDColaborador = vwColaboradores.GetRowCellValue(item, "Id")
                    Departamento = vwColaboradores.GetRowCellValue(item, "Departamento")
                End If
            Next


            If IDColaborador = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione un colaborador valido")
            Else
                If Not CheckForm(AltaColaborador) Then
                    Dim formaAltas As New AltasColaboradoresForm

                    formaAltas.colaboradorId = IDColaborador
                    formaAltas.ShowDialog()

                End If
            End If

        End If
    End Sub

    'Private Sub grdColaboradores_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If e.RowIndex >= 0 Then
    '        Dim CredencialColaboradores As New CredencialColaboradorForm
    '        CredencialColaboradores.PColaboradorID = CInt(grdColaboradores.Rows(e.RowIndex).Cells("colId").Value)
    '        CredencialColaboradores.activo = rdoActivoSi.Checked
    '        CredencialColaboradores.ShowDialog()
    '    End If
    'End Sub

    Private Sub vwColaboradores_DoubleClick(sender As Object, e As EventArgs) Handles vwColaboradores.DoubleClick
        IDColaborador = 0
        'Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Doble Click")
        If vwColaboradores.SelectedRowsCount = 1 Then
            Dim Fila As Integer = vwColaboradores.DataRowCount

            For item As Integer = 0 To Fila Step 1
                If CBool(vwColaboradores.IsRowSelected(vwColaboradores.GetVisibleRowHandle(item))) = True Then
                    IDColaborador = vwColaboradores.GetRowCellValue(item, "Id")
                End If
            Next

            If IDColaborador > 0 Then
                Dim CredencialColaboradores As New CredencialColaboradorForm
                CredencialColaboradores.PColaboradorID = IDColaborador
                CredencialColaboradores.activo = rdoActivoSi.Checked
                CredencialColaboradores.ShowDialog()
            End If

        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            cmbDepto = Controles.ComboDepatamentoSegunNave(cmbDepto, cmbNave.SelectedValue.ToString)
        End If
        grdColaboradores.DataSource = Nothing
    End Sub

    Private Sub cmbDepto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepto.SelectedIndexChanged
        If cmbDepto.SelectedIndex > 0 Then
            cmbPuesto = Controles.ComboPuestosSegunDepartamento(cmbPuesto, cmbDepto.SelectedValue.ToString)
        End If
    End Sub

    Private Sub txtNombre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            LlenarTabla()
        End If
    End Sub

    Private Sub txtRFC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRFC.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            LlenarTabla()
        End If
    End Sub

    Private Sub txtCurp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCurp.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            LlenarTabla()
        End If
    End Sub

    Private Sub btnImprimirCredencial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirCredencial.Click

        If cmbNave.SelectedIndex > 0 Then
            'If IDColaborador = 0 Then
            '    Dim Advertencia As New AdvertenciaForm
            '    Advertencia.mensaje = "Seleccione un colaborador valido"
            '    Advertencia.ShowDialog()
            'Else

            ImprimirMultiplesCredenciales()

            '    If naveID = 3 Then

            '        Try
            '            Me.Cursor = Cursors.WaitCursor
            '            Dim OBJBU As New Framework.Negocios.ReportesBU
            '            Dim EntidadReporte As Entidades.Reportes
            '            Dim Credencial As New Entidades.Credenciales
            '            Dim objColaborador As New Negocios.ColaboradoresBU
            '            Credencial = objColaborador.CredencialesJeans(IDColaborador)
            '            EntidadReporte = OBJBU.LeerReporteporClave("NOM_CRED_JEANS")
            '            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '                EntidadReporte.Pnombre + ".mrt"
            '            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            '            Dim reporte As New StiReport
            '            reporte.Load(archivo)
            '            reporte.Compile()
            '            Dim Nombre As Object = reporte("Nombre")
            '            reporte("Nombre") = Credencial.Pcodr_nombre
            '            Dim apellidos As Object = reporte("Apellidos")
            '            reporte("Apellidos") = Credencial.Papellidos
            '            Dim foto As Object = reporte("Foto")
            '            reporte("Foto") = Credencial.Pfoto
            '            Dim codigo As Object = reporte("Codigo")
            '            reporte("Codigo") = Credencial.Pcodigo
            '            Dim puesto As Object = reporte("Puesto")
            '            reporte("Puesto") = Credencial.Ppues_nombre.ToUpper
            '            reporte.Render(False)
            '            reporte.Show()
            '        Catch ex As Exception
            '        Finally
            '            Me.Cursor = Cursors.Default
            '        End Try
            '        'ElseIf naveID = 5 Then
            '        '    Try
            '        '        Me.Cursor = Cursors.WaitCursor
            '        '        Dim OBJBU As New Framework.Negocios.ReportesBU
            '        '        Dim EntidadReporte As Entidades.Reportes
            '        '        EntidadReporte = OBJBU.LeerReporteporClave("NOM_CRED_JEANS2")
            '        '        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '        '            EntidadReporte.Pnombre + ".mrt"
            '        '        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            '        '        Dim reporte As New StiReport
            '        '        reporte.Load(archivo)
            '        '        reporte.Compile()
            '        '        Dim Value As Object = reporte("Colaboradorid")
            '        '        reporte("Colaboradorid") = IDColaborador
            '        '        reporte.Render(False)
            '        '        reporte.Show()
            '        '    Catch ex As Exception
            '        '    Finally
            '        '        Me.Cursor = Cursors.Default
            '        '    End Try

            '    ElseIf naveID = 43 Then
            '        Try
            '            Me.Cursor = Cursors.WaitCursor
            '            Dim OBJBU As New Framework.Negocios.ReportesBU
            '            Dim EntidadReporte As Entidades.Reportes
            '            EntidadReporte = OBJBU.LeerReporteporClave("NOM_CRED_COMER")
            '            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '                EntidadReporte.Pnombre + ".mrt"
            '            archivo = archivo.Replace(" ", "")
            '            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            '            Dim reporte As New StiReport
            '            reporte.Load(archivo)

            '            reporte.Compile()
            '            Dim url As Object = reporte("URLSOURCEHTTP")
            '            Dim objbuCred As New Negocios.CredencialesBU

            '            reporte("URLSOURCEHTTP") = objbuCred.ObtenerURLCredencial(naveID, Departamento)
            '            Dim Value As Object = reporte("Colaboradorid")
            '            reporte("Colaboradorid") = IDColaborador
            '            reporte.Render(False)
            '            reporte.Show()
            '        Catch ex As Exception
            '            MessageBox.Show(ex.ToString)
            '        Finally
            '            Me.Cursor = Cursors.Default
            '        End Try
            '    ElseIf naveID > 0 Then
            '        Dim OBJBU As New Framework.Negocios.ReportesBU
            '        Dim EntidadReporte As Entidades.Reportes
            '        Dim idColaboradorReport As New Object
            '        idColaboradorReport = IDColaborador

            '        If naveID = 52 Then

            '            EntidadReporte = OBJBU.LeerReporteporClave("CREDENCIAL_INDUSTAR")
            '            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            '                EntidadReporte.Pnombre + ".mrt"
            '            archivo = archivo.Replace(" ", "")
            '            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            '            Dim reporte As New StiReport
            '            reporte.Load(archivo)

            '            reporte.Compile()
            '            Dim url As Object = reporte("URLSOURCEHTTP")
            '            Dim objbuCred As New Negocios.CredencialesBU

            '            reporte("URLSOURCEHTTP") = objbuCred.ObtenerURLCredencial(naveID, Departamento)
            '            Dim Value As Object = reporte("Colaboradorid")
            '            reporte("Colaboradorid") = IDColaborador

            '            reporte.Render(False)
            '            reporte.Show()
            '        Else
            '            EntidadReporte = OBJBU.LeerReporteporClave("NOM_CRED_HORIZ")

            '            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            '            archivo = archivo.Replace(" ", "")
            '            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            '            Dim reporte As New StiReport
            '            reporte.Load(archivo)
            '            reporte.Compile()
            '            reporte("colaboradorID") = IDColaborador
            '            reporte.Show()
            '        End If


            '    End If
            'End If
        Else
            MsgBox("Seleccione una nave")
        End If

    End Sub

    Private Sub ImprimirMultiplesCredenciales()

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim pNave As Integer
        Dim DEPTO As String = String.Empty

        dtColaboradorIdCred = New DataTable

        dtColaboradorIdCred.Columns.Add("colaboradorID")
        dtColaboradorIdCred.Columns.Add("Nombre")
        dtColaboradorIdCred.Columns.Add("Apellidos")
        dtColaboradorIdCred.Columns.Add("Foto")
        dtColaboradorIdCred.Columns.Add("Codigo")
        dtColaboradorIdCred.Columns.Add("Puesto")
        ' dtColaboradorIdCred.Columns.Add("Departamento")
        dtColaboradorIdCred.Columns.Add("RutaImagen")
        dtColaboradorIdCred.Columns.Add("IdNave")

        'If grdColaboradores.SelectedRows.Count > 0 Then
        If vwColaboradores.SelectedRowsCount > 0 Then
            Dim Fila As Integer = vwColaboradores.DataRowCount

            For item As Integer = 0 To Fila Step 1
                If CBool(vwColaboradores.IsRowSelected(vwColaboradores.GetVisibleRowHandle(item))) = True Then
                    Dim ColaboradorIdCred As DataRow = dtColaboradorIdCred.NewRow
                    Dim entCredencial As New Entidades.Credenciales
                    Dim objColaborador As New Negocios.ColaboradoresBU
                    Dim objbuCred As New Negocios.CredencialesBU
                    Dim puesto As String = ""
                    Dim NombreColaborador As String = ""
                    Dim ApellidoColaborador As String = ""
                    Dim ColaboradorID As Integer = 0
                    Dim DtResultado As DataTable


                    entCredencial = objColaborador.CredencialesTodo(vwColaboradores.GetRowCellValue(item, "Id"))

                    If Not entCredencial.Ppues_nombre Is Nothing Then
                        puesto = entCredencial.Ppues_nombre.ToString.ToUpper
                    End If


                    If naveID = 43 Then
                        ColaboradorID = vwColaboradores.GetRowCellValue(item, "Id").ToString
                        DtResultado = objColaborador.ObtenerNombreColaboradorCredencialEspecial(ColaboradorID)


                        If DtResultado.Rows.Count > 0 Then
                            NombreColaborador = DtResultado.Rows(0).Item(0)
                            ApellidoColaborador = DtResultado.Rows(0).Item(1)
                            ColaboradorIdCred.Item("Nombre") = NombreColaborador
                            ColaboradorIdCred.Item("Apellidos") = ApellidoColaborador
                        Else
                            ColaboradorIdCred.Item("Nombre") = InsertarSaltosLineaCadena(entCredencial.Pcodr_nombre)
                            ColaboradorIdCred.Item("Apellidos") = InsertarSaltosLineaCadena(entCredencial.Papellidos)
                        End If



                        ColaboradorIdCred.Item("Foto") = entCredencial.Pfoto
                        ColaboradorIdCred.Item("Codigo") = entCredencial.Pcodigo
                        ColaboradorIdCred.Item("Puesto") = puesto
                        ' ColaboradorIdCred.Item("Departamento") = entCredencial.Pgrup_name.ToString.ToUpper
                        ColaboradorIdCred.Item("IdNave") = entCredencial.PNave
                        DEPTO = entCredencial.Pgrup_name.ToString.ToUpper

                        ColaboradorIdCred.Item("RutaImagen") = "http://192.168.2.158/nomina/Nomina/Credenciales/Comercializadora/TI/CREDENCIAL_SISTEMAS_2.png" ' objbuCred.ObtenerURLCredencial(entCredencial.PNave, entCredencial.Pgrup_name)

                        pNave = entCredencial.PNave

                        'ColaboradorIdCred.Item("RutaImagen") = objbuCred.ObtenerURLCredencial(entCredencial.PNave, entCredencial.Pgrup_name)

                        dtColaboradorIdCred.Rows.Add(ColaboradorIdCred)

                    Else

                        ColaboradorIdCred.Item("colaboradorID") = vwColaboradores.GetRowCellValue(item, "Id").ToString
                        ColaboradorIdCred.Item("Nombre") = InsertarSaltosLineaCadena(entCredencial.Pcodr_nombre)
                        ColaboradorIdCred.Item("Apellidos") = InsertarSaltosLineaCadena(entCredencial.Papellidos)
                        ColaboradorIdCred.Item("Foto") = entCredencial.Pfoto
                        ColaboradorIdCred.Item("Codigo") = entCredencial.Pcodigo
                        ColaboradorIdCred.Item("Puesto") = puesto
                        ' ColaboradorIdCred.Item("Departamento") = entCredencial.Pgrup_name.ToString.ToUpper
                        ColaboradorIdCred.Item("IdNave") = entCredencial.PNave
                        DEPTO = entCredencial.Pgrup_name.ToString.ToUpper

                        ColaboradorIdCred.Item("RutaImagen") = objbuCred.ObtenerURLCredencial(entCredencial.PNave, entCredencial.Pgrup_name)

                        pNave = entCredencial.PNave

                        'ColaboradorIdCred.Item("RutaImagen") = objbuCred.ObtenerURLCredencial(entCredencial.PNave, entCredencial.Pgrup_name)

                        dtColaboradorIdCred.Rows.Add(ColaboradorIdCred)
                    End If
                End If
            Next

            Dim dsCredencialesColaborador As New DataTable
            dsCredencialesColaborador.TableName = "dsCredencialesColaborador"
            dsCredencialesColaborador = dtColaboradorIdCred

            If pNave = 3 Then
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_CRED_JEANS")

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("Nombre") = ""
                reporte("Apellidos") = ""
                reporte("Foto") = ""
                reporte("Codigo") = "123"
                reporte("Puesto") = ""

                reporte.Dictionary.Clear()

                reporte.RegData(dsCredencialesColaborador)
                reporte.Dictionary.Synchronize()
                reporte.Show()

            ElseIf pNave = 43 Or pNave = 73 Or pNave = 82 Then
                Dim strClaveReporte As String = String.Empty
                Select Case naveID
                    Case 43
                        strClaveReporte = "NOM_CRED_COMER_2"
                    Case 73
                        strClaveReporte = "NOM_CRED_VILLA"
                    Case 82
                        strClaveReporte = "NOM_CRED_REED"
                End Select

                EntidadReporte = OBJBU.LeerReporteporClave(strClaveReporte)

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                Dim url As Object = reporte("URLSOURCEHTTP")
                Dim objbuCred As New Negocios.CredencialesBU

                Dim Value As Object = reporte("Colaboradorid")
                reporte("Colaboradorid") = IDColaborador
                reporte("nombreNave") = DEPTO

                reporte.Dictionary.Clear()
                reporte.RegData(dsCredencialesColaborador)
                reporte.Dictionary.Synchronize()
                reporte.Show()

            ElseIf pNave = 61 Then

                EntidadReporte = OBJBU.LeerReporteporClave("CREDENCIAL_INDUSTAR")

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                       EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                Dim url As Object = reporte("URLSOURCEHTTP")
                Dim objbuCred As New Negocios.CredencialesBU

                reporte("URLSOURCEHTTP") = objbuCred.ObtenerURLCredencial(pNave, Departamento)
                Dim Value As Object = reporte("Colaboradorid")
                reporte("Colaboradorid") = IDColaborador

                reporte.Dictionary.Clear()
                reporte.RegData(dsCredencialesColaborador)
                reporte.Dictionary.Synchronize()
                reporte.Show()


            Else
                Dim urlCred As String = ""
                Dim objbuCred As New Negocios.CredencialesBU
                urlCred = objbuCred.obtenerFotoCredencial(pNave)
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_CRED_HORIZ")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                archivo = archivo.Replace(" ", "")
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("UrlCredencial") = urlCred
                reporte("colaboradorID") = IDColaborador
                reporte("Nombre") = ""
                reporte("Apellidos") = ""
                reporte("Foto") = ""
                reporte("Codigo") = "123"
                reporte("Puesto") = ""

                reporte.Dictionary.Clear()
                reporte.RegData(dsCredencialesColaborador)
                reporte.Dictionary.Synchronize()
                reporte.Show()

            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione un colaborador valido")
        End If

    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtNombre.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCurp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCurp.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtCurp.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub txtRFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRFC.KeyPress
        If Char.IsLower(e.KeyChar) Then
            txtRFC.SelectedText = Char.ToUpper(e.KeyChar)
            e.Handled = True
        End If
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        LlenarTabla()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtNombre.Text = ""
        txtCurp.Text = ""
        txtRFC.Text = ""
        cmbNave.Text = ""
        cmbDepto.Text = ""
        cmbPuesto.Text = ""
        rdoActivoSi.Checked = True
        'grdColaboradores.Rows.Clear()
        vwColaboradores.Columns.Clear()
        grdColaboradores.DataSource = Nothing
        lblNave.ForeColor = Color.Black
    End Sub

    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Height = 40
        grdColaboradores.Height = 471
        grdColaboradores.Top = 115
    End Sub

    Private Sub btnAbajo_Click_1(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Height = 138
        grdColaboradores.Height = 346
        grdColaboradores.Top = 240
    End Sub

    Private Sub btnDesactivarColaborador_Click(sender As Object, e As EventArgs) Handles btnDesactivarColaborador.Click
        IDColaborador = 0

        If vwColaboradores.SelectedRowsCount > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Sólo se puede deshabilitar un colaborador a la vez.")
        Else
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿ Está seguro de inhabilitar al colaborador ? " + vbNewLine + "Posteriormente no podrá hacer modificaciones."

            If mensajeExito.ShowDialog = DialogResult.OK Then

                Dim Fila As Integer = vwColaboradores.DataRowCount

                For item As Integer = 0 To Fila Step 1
                    If CBool(vwColaboradores.IsRowSelected(vwColaboradores.GetVisibleRowHandle(item))) = True Then
                        IDColaborador = vwColaboradores.GetRowCellValue(item, "Id")
                    End If
                Next

                If IDColaborador = 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione un colaborador valido")
                Else
                    Dim objbu As New ColaboradoresBU
                    objbu.DesactivarColaborador(IDColaborador)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Colaborador Desactivado con Exito")

                End If
            End If

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

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If vwColaboradores.RowCount > 0 Then
            exportar()
        End If
    End Sub

    Private Sub exportar()
        Me.Cursor = Cursors.WaitCursor
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    Dim exportOptions = New XlsxExportOptionsEx()
                    Dim archivo As String = String.Empty
                    archivo = .SelectedPath + "\Lista_Colaboradores_" + fecha_hora + ".xlsx"

                    vwColaboradores.ExportToXlsx(archivo, exportOptions)
                    LlenarTabla()

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente.")
                    .Dispose()

                    Process.Start(archivo)

                End If
            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        ContextMenuStrip1.Show(btnImprimirReporte, 0, btnImprimirReporte.Height)
    End Sub

    Private Sub ImprimirCartaRenunciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirCartaRenunciaToolStripMenuItem.Click
        ImprimirCartaRenuncia()
    End Sub
#Region "CARTA_RENUNCIA"
    Private Sub ImprimirCartaRenuncia()
        Dim objColaborador As New Negocios.ColaboradoresBU
        If Not grdColaboradores.DataSource Is Nothing Then
            If vwColaboradores.SelectedRowsCount > 0 Then
                Dim Fila As Integer = vwColaboradores.DataRowCount

                For item As Integer = 0 To Fila Step 1
                    If CBool(vwColaboradores.IsRowSelected(vwColaboradores.GetVisibleRowHandle(item))) = True Then
                        Dim activo As Boolean
                        activo = objColaborador.BuscarColaboradorGeneral(vwColaboradores.GetRowCellValue(item, "Id").ToString).PActivo
                        If (activo) Then

                            'If (objColaborador.BuscarColaboradorGeneral() Then
                            Dim estatus As String = ""
                            'estatus = grdSolicitudes.ActiveRow.Cells("fini_estado").Value.ToString
                            Dim nombre As String = ""
                            Dim patron As String = ""
                            Dim domicilio As String = ""
                            Dim Puesto As String = ""
                            Dim IDCOlaborador As String = vwColaboradores.GetRowCellValue(item, "Id").ToString
                            Dim objBu As New ColaboradorNominaBU
                            Dim objNomina As New Entidades.ColaboradorNomina
                            Dim objlaboral As New ColaboradorLaboralBU
                            Dim entidadLaboral As New Entidades.ColaboradorLaboral
                            Dim checa As Boolean

                            entidadLaboral = objlaboral.buscarInformacionLaboral(CInt(IDCOlaborador))
                            checa = entidadLaboral.PCheca
                            Puesto = entidadLaboral.PPuestoId.PNombre
                            objNomina = objBu.buscarColaborarNomina(CInt(IDCOlaborador))
                            nombre = vwColaboradores.GetRowCellValue(item, "Colaborador").ToString
                            patron = objNomina.PPatron.Pnombre.Replace("( JEANS 1 )", "").Replace("( JEANS 2 )", "").Replace("(SUELAS)", "")
                            Dim objPatron As New PatronesBU
                            Dim entidadPatron As New Entidades.Patrones
                            entidadPatron = objPatron.buscarPatrones(objNomina.PPatron.Ppatronid)
                            domicilio = entidadPatron.Pcalle.ToUpper + " NO. " + entidadPatron.PDnumero.ToUpper + " COLONIA " + entidadPatron.Pcolonia.ToUpper

                            'If estatus = "A" Then
                            imprimirCartaRenunicaSinCantidades(nombre, patron, domicilio, Puesto, checa)

                            'Else
                            'imprimirCartaRenunicaConCantidades(nombre, patron, domicilio, Puesto)
                            'End If
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El colaboraor debe estar activo")
                        End If
                    End If
                Next
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione un colaborador valido")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Consulte a un colaborador")
        End If

    End Sub


    Public Sub imprimirCartaRenunicaSinCantidades(ByVal nombreColaborador As String, ByVal patron As String, ByVal Domicilio As String, ByVal puesto As String, ByVal checa As Boolean)

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim objBuNe As New Negocios.FiniquitosBU
        Dim ultimoDia As New Date
        Dim horario As String = ""
        EntidadReporte = OBJBU.LeerReporteporClave("NOM_REP_CARTARENUNCIA1")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreColaborador") = nombreColaborador.ToUpper
        reporte("Patron") = patron.ToUpper
        reporte("Domicilio") = Domicilio.ToUpper
        reporte("Puesto") = puesto.ToUpper

        'ultimoDia = objBuNe.ObtenerUltimoDiaTrabajado(nombreColaborador, checa)
        ultimoDia = dttFecha.Value

        'horario = objBuNe.consultarHorarioNave(cmbNave.SelectedValue)
        'If cmbNave.SelectedValue = 43 Then
        '    horario = "Lunes a Viernes, de 9:00 hrs. A 14:00 hrs. y de 16:00 hrs. A 19:00 hrs y el Sábado de 9:00 hrs. a 14:00 hrs"
        'Else
        '    horario = "Lunes a Viernes, de 8:00 hrs. A 14:00 hrs. y de 15:00 hrs. A 17:00 hrs y el Sábado de 8:00 hrs. a 13:00 hrs"
        'End If

        'reporte("horario") = horario
        reporte("UltimoDia") = ultimoDia.ToLongDateString

        reporte.Dictionary.Clear()
        reporte.Dictionary.Synchronize()
        reporte.Show()

    End Sub

#End Region

    Private Function InsertarSaltosLineaCadena(ByVal Cadena As String)

        Dim resultado As String = String.Empty

        Dim split As String() = Cadena.Trim.Split(" ")


        For Each item As String In split
            If item <> "" Then
                If resultado = String.Empty Then
                    resultado = item
                Else
                    resultado &= vbCrLf + item
                End If
            End If

        Next

        Return resultado
    End Function

End Class