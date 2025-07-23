Imports Framework
Imports Entidades
Imports Produccion.Negocios
Imports C1.Win.C1FlexGrid

Public Class ListaAdmonAvancesForm

    Private frmFormE As New AdmonAvancesDetalleForm
    Dim objUsuarioSesion As Usuarios

    Private Sub ListaPatronesForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitComps()
    End Sub

    Private Sub ConsultarAvanceLotes()
        Dim ListaLotesAvances As New List(Of LotesAvances)
        Dim objBU As New LotesAvancesBU
        Dim strEstatus As String = ""

        If rblLotesAtrasados.Checked Then
            strEstatus = "ATRASADO"
        ElseIf rblLotesProceso.Checked Then
            strEstatus = "PROCESO"
        ElseIf rblLotesTerminados.Checked Then
            strEstatus = "TERMINADO"
        End If

        ListaLotesAvances = objBU.ListaLotesAvances(cmbNave.SelectedValue, IIf(chkFechaPrograma.Checked, 1, 0), dtpFechaProgramacionDe.Value, dtpFechaProgramacionA.Value,
                                                    strEstatus, Val(txtNoLote.Text), cmbDepartamento.SelectedValue, cmbCelula.SelectedValue,
                                                    IIf(chkFechaAvance.Checked, 1, 0), dtpFechaAvanceDe.Value, dtpFechaAvanceA.Value)

        ConfigurarGrid(ListaLotesAvances)

        For Each lote As LotesAvances In ListaLotesAvances
            AgregarFila(lote)
        Next

    End Sub

    Private Sub ConfigurarGrid(ByVal LotesAvances As List(Of LotesAvances))

        grdAvances.Cols(1).Caption = "Año"
        grdAvances.Cols(2).Caption = "Nave"
        grdAvances.Cols(3).Caption = "Lote"
        grdAvances.Cols(4).Caption = "Modelo"
        grdAvances.Cols(5).Caption = "Colección"
        grdAvances.Cols(6).Caption = "Talla"
        grdAvances.Cols(7).Caption = "Color"
        grdAvances.Cols(8).Caption = "Pares"
        grdAvances.Cols(9).Caption = "Observaciones"

        grdAvances.Cols(10).Caption = "IdD1"
        grdAvances.Cols(11).Caption = "D2"

        grdAvances.Cols(12).Caption = "IdD2"
        grdAvances.Cols(13).Caption = "D2"

        grdAvances.Cols(14).Caption = "IdD3"
        grdAvances.Cols(15).Caption = "D3"

        grdAvances.Cols(16).Caption = "IdD4"
        grdAvances.Cols(17).Caption = "D4"

        grdAvances.Cols(18).Caption = "IdD5"
        grdAvances.Cols(19).Caption = "D5"

        grdAvances.Cols(20).Caption = "EMBARQUE"
        grdAvances.Cols(21).Caption = "FechaLote"

        If cmbDepartamento.SelectedIndex = 0 Then
            grdAvances.Cols(20).Visible = True
        Else
            If cmbDepartamento.SelectedValue = 999 Then
                grdAvances.Cols(20).Visible = True
            Else
                grdAvances.Cols(20).Visible = False
            End If
        End If

        If LotesAvances.Count > 0 Then
            grdAvances.Cols(11).Caption = LotesAvances(0).PD1
            grdAvances.Cols(11).Visible = True
            grdAvances.Cols(13).Caption = LotesAvances(0).PD2
            grdAvances.Cols(13).Visible = True
            grdAvances.Cols(15).Caption = LotesAvances(0).PD3
            grdAvances.Cols(15).Visible = True
            grdAvances.Cols(17).Caption = LotesAvances(0).PD4
            grdAvances.Cols(17).Visible = True
            grdAvances.Cols(19).Caption = LotesAvances(0).PD5
            grdAvances.Cols(19).Visible = True

            If LotesAvances(0).PIdD1 = 0 Then
                grdAvances.Cols(11).Visible = False
            End If

            If LotesAvances(0).PIdD2 = 0 Then
                grdAvances.Cols(13).Visible = False
            End If

            If LotesAvances(0).PIdD3 = 0 Then
                grdAvances.Cols(15).Visible = False
            End If

            If LotesAvances(0).PIdD4 = 0 Then
                grdAvances.Cols(17).Visible = False
            End If

            If LotesAvances(0).PIdD5 = 0 Then
                grdAvances.Cols(19).Visible = False
            End If

            If rblLotesAtrasados.Checked = True Then
                grdAvances.Cols(22).Visible = True
            Else
                grdAvances.Cols(22).Visible = False
            End If

        End If

    End Sub

    Public Sub AgregarFila(ByVal lote As LotesAvances)

        grdAvances.AddItem("" & ControlChars.Tab & lote.PAño & ControlChars.Tab & lote.PNave & ControlChars.Tab & lote.PLote & ControlChars.Tab & lote.PModelo & ControlChars.Tab & lote.PColeccion & ControlChars.Tab & lote.PTalla & ControlChars.Tab & lote.PColor & ControlChars.Tab & lote.PPares & ControlChars.Tab & lote.PObservaciones &
                           ControlChars.Tab & lote.PIdD1 & ControlChars.Tab & IIf((lote.PFD1) = "01/01/1900", "", FormatDateTime(lote.PFD1, DateFormat.ShortDate)) &
                           ControlChars.Tab & lote.PIdD2 & ControlChars.Tab & IIf((lote.PFD2) = "01/01/1900", "", FormatDateTime(lote.PFD2, DateFormat.ShortDate)) &
                           ControlChars.Tab & lote.PIdD3 & ControlChars.Tab & IIf((lote.PFD3) = "01/01/1900", "", FormatDateTime(lote.PFD3, DateFormat.ShortDate)) &
                           ControlChars.Tab & lote.PIdD4 & ControlChars.Tab & IIf((lote.PFD4) = "01/01/1900", "", FormatDateTime(lote.PFD4, DateFormat.ShortDate)) &
                           ControlChars.Tab & lote.PIdD5 & ControlChars.Tab & IIf((lote.PFD5) = "01/01/1900", "", FormatDateTime(lote.PFD5, DateFormat.ShortDate)) &
                           ControlChars.Tab & IIf((lote.PFechaEmbarque) = "01/01/1900", "", lote.PFechaEmbarque) & ControlChars.Tab & lote.PFechaLote)

    End Sub

    Public Sub InitComps()

        objUsuarioSesion = SesionUsuario.UsuarioSesion

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, objUsuarioSesion.PUserUsuarioid)
        cmbDepartamento = Controles.ComboDepartamentosSegunNave(cmbDepartamento, cmbNave.SelectedValue)

        dtpFechaProgramacionDe.Value = Now.Date
        dtpFechaProgramacionA.Value = Now.Date

        dtpFechaAvanceDe.Value = Now.Date
        dtpFechaAvanceA.Value = Now.Date

        chkFechaAvance.Checked = False
        dtpFechaAvanceDe.Enabled = False
        dtpFechaAvanceA.Enabled = False

        txtNoLote.Text = String.Empty

        rblTodoLotes.Checked = True

    End Sub

    Private Sub txtNombreDelPatron_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoLote.KeyPress
        e.Handled = True
        If Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If
    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbLotesAvances.Height = 39
        grdAvances.Height = 502
        grdAvances.Top = 122
    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbLotesAvances.Height = 175
        grdAvances.Height = 366
        grdAvances.Top = 258
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Cursor.Current = Cursors.WaitCursor
        grdAvances.Rows.Count = 1
        ConsultarAvanceLotes()
        CalcularTotales()
        GenerarResumen()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub GenerarResumen()
        Dim objdeptoBU As New DepartamentosSICYBU
        Dim tabladepartamentos As New List(Of Departamentos)
        Dim tablaprogramas As New DataTable
        Dim objDepto As New Departamentos

        Dim i As Integer
        Dim j As Integer
        Dim x As Int16

        Dim FilaEncabezadoDeptos As Integer
        Dim FilaEncabezadoSubDeptos As Integer

        Dim intTamañoColumnas As Int32 = 0

        Dim ParesResumenPrograma As Long = 0
        Dim TotalParesPrograma As Long = 0

        grdResumen.Rows.Count = 3       ' Asigna Numero de Filas.
        grdResumen.Rows.Fixed = 3       ' Asigna Filas de Encabezados.
        FilaEncabezadoDeptos = 1        ' Fila en la que se asignaran los Encabezados de los Departamentos.
        FilaEncabezadoSubDeptos = 2     ' Fila en la que se asignaran los Encabezados de las Celulas y Bandas.
        i = 0
        j = 0

        tabladepartamentos = objdeptoBU.ListaDepartamentosSegunNave(cmbNave.SelectedValue)
        tablaprogramas = objdeptoBU.ListaProgramasNave(cmbNave.SelectedValue, dtpFechaProgramacionDe.Value, dtpFechaProgramacionA.Value)

        If tabladepartamentos.Count = 0 Then
            MessageBox.Show("No existe información de Departamentos para construir el Resumen de Avances", "Resumen de Avances", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If tablaprogramas.Rows.Count = 0 Then
            MessageBox.Show("No existe informacion de Programas para construir el Resumen de Avances", "Resumen de Avances", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If tabladepartamentos.Count > 0 Then

            grdResumen.Cols.Count = (tabladepartamentos.Count + tabladepartamentos.Count + 4)
            intTamañoColumnas = ((grdResumen.Width) / (tabladepartamentos.Count + 4))

            grdResumen.SetData(FilaEncabezadoSubDeptos, i, "PROGRAMA")
            grdResumen.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            grdResumen.Cols(i).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            grdResumen.Cols(i).Width = intTamañoColumnas

            grdResumen.SetData(FilaEncabezadoSubDeptos, i + 1, "LOTES")
            grdResumen.Cols(i + 1).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            grdResumen.Cols(i + 1).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            grdResumen.Cols(i + 1).Width = intTamañoColumnas

            grdResumen.SetData(FilaEncabezadoSubDeptos, i + 2, "PARES")
            grdResumen.Cols(i + 2).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            grdResumen.Cols(i + 2).TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
            grdResumen.Cols(i + 2).Width = intTamañoColumnas

            i = i + 3

            grdResumen.AllowMerging = AllowMergingEnum.FixedOnly
            grdResumen.Rows(0).AllowMerging = True
            grdResumen.Rows(FilaEncabezadoDeptos).AllowMerging = True
            Dim rng As CellRange = grdResumen.GetCellRange(FilaEncabezadoDeptos, j, FilaEncabezadoDeptos, i - 1)
            rng.Data = "RESUMEN DE PROGRAMAS"

            j = j + 3

            For Each objDepto In tabladepartamentos
                grdResumen.SetData(FilaEncabezadoSubDeptos, i, objDepto.DNombre)
                grdResumen.Cols(i).TextAlign = TextAlignEnum.CenterCenter
                grdResumen.Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
                grdResumen.Cols(i).Width = intTamañoColumnas
                i = i + 1
                grdResumen.SetData(FilaEncabezadoSubDeptos, i, objDepto.Ddepartamentoid)
                grdResumen.Cols(i).TextAlign = TextAlignEnum.CenterCenter
                grdResumen.Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
                grdResumen.Cols(i).Visible = False
                i = i + 1
            Next

            grdResumen.SetData(FilaEncabezadoSubDeptos, i, "EMBARQUE")
            grdResumen.Cols(i).TextAlign = TextAlignEnum.CenterCenter
            grdResumen.Cols(i).TextAlignFixed = TextAlignEnum.CenterCenter
            grdResumen.Cols(i).Width = intTamañoColumnas

            rng = grdResumen.GetCellRange(FilaEncabezadoDeptos, j, FilaEncabezadoDeptos, i)
            rng.Data = "INFORMACIÓN DE AVANCES"

            rng = grdResumen.GetCellRange(0, 0, 0, grdResumen.Cols.Count - 1)
            rng.Data = "RESUMEN DE AVANCES DE PROGRAMAS"

            If tablaprogramas.Rows.Count > 0 Then
                For Each fPrograma As DataRow In tablaprogramas.Rows
                    grdResumen.AddItem("")
                    grdResumen.SetData(grdResumen.Rows.Count - 1, 0, FormatDateTime(fPrograma("Fecha"), DateFormat.ShortDate))
                    grdResumen.SetData(grdResumen.Rows.Count - 1, 1, objdeptoBU.InfoAvancesProgramaPares(cmbNave.SelectedValue, fPrograma("Fecha"), "Lotes", ""))
                    grdResumen.SetData(grdResumen.Rows.Count - 1, 2, objdeptoBU.InfoAvancesProgramaPares(cmbNave.SelectedValue, fPrograma("Fecha"), "Pares", ""))
                    TotalParesPrograma = grdResumen.GetData(grdResumen.Rows.Count - 1, 2)

                    grdResumen.AddItem("")
                    grdResumen.SetData(grdResumen.Rows.Count - 1, 2, "Pendientes")

                    For x = 4 To grdResumen.Cols.Count - 1 Step 2
                        If x <= grdResumen.Cols.Count - 1 Then
                            grdResumen.SetData(grdResumen.Rows.Count - 2, x - 1, objdeptoBU.InfoAvancesProgramaPares(cmbNave.SelectedValue, fPrograma("Fecha"), "Depto", grdResumen.GetData(2, x)))
                            grdResumen.SetData(grdResumen.Rows.Count - 1, x - 1, (TotalParesPrograma - objdeptoBU.InfoAvancesProgramaPares(cmbNave.SelectedValue, fPrograma("Fecha"), "Depto", grdResumen.GetData(2, x))))
                        End If
                    Next

                    grdResumen.SetData(grdResumen.Rows.Count - 2, grdResumen.Cols.Count - 1, objdeptoBU.InfoAvancesProgramaPares(cmbNave.SelectedValue, fPrograma("Fecha"), "Embarque", ""))
                    grdResumen.SetData(grdResumen.Rows.Count - 1, grdResumen.Cols.Count - 1, (TotalParesPrograma - objdeptoBU.InfoAvancesProgramaPares(cmbNave.SelectedValue, fPrograma("Fecha"), "Embarque", "")))
                    'TotalParesPrograma()
                Next
            End If

        End If

    End Sub

    Private Sub CalcularTotales()
        Dim i As Int32
        Dim intTotalPares As Int32 = 0
        Dim intAuxTotalxDep As Int32
        Dim intTotalDepartamentos As New List(Of Int32)
        Dim strNombresDepartamentos As New List(Of String)

        lblTotales.Text = ""

        intAuxTotalxDep = 0
        If grdAvances.Cols(11).IsVisible = True Then
            strNombresDepartamentos.Add(grdAvances.Cols(11).Caption)
            For i = 1 To grdAvances.Rows.Count - 1
                If grdAvances.GetData(i, 11) <> "" Then
                    intAuxTotalxDep = intAuxTotalxDep + CInt(grdAvances.GetData(i, 8))
                End If
            Next
            intTotalDepartamentos.Add(intAuxTotalxDep)
        End If


        intAuxTotalxDep = 0
        If grdAvances.Cols(13).IsVisible = True Then
            strNombresDepartamentos.Add(grdAvances.Cols(13).Caption)
            For i = 1 To grdAvances.Rows.Count - 1
                If grdAvances.GetData(i, 13) <> "" Then
                    intAuxTotalxDep = intAuxTotalxDep + CInt(grdAvances.GetData(i, 8))
                End If
            Next
            intTotalDepartamentos.Add(intAuxTotalxDep)
        End If

        intAuxTotalxDep = 0
        If grdAvances.Cols(15).IsVisible = True Then
            strNombresDepartamentos.Add(grdAvances.Cols(15).Caption)
            For i = 1 To grdAvances.Rows.Count - 1
                If grdAvances.GetData(i, 15) <> "" Then
                    intAuxTotalxDep = intAuxTotalxDep + CInt(grdAvances.GetData(i, 8))
                End If
            Next
            intTotalDepartamentos.Add(intAuxTotalxDep)
        End If

        intAuxTotalxDep = 0
        If grdAvances.Cols(17).IsVisible = True Then
            strNombresDepartamentos.Add(grdAvances.Cols(17).Caption)
            For i = 1 To grdAvances.Rows.Count - 1
                If grdAvances.GetData(i, 17) <> "" Then
                    intAuxTotalxDep = intAuxTotalxDep + CInt(grdAvances.GetData(i, 8))
                End If
            Next
            intTotalDepartamentos.Add(intAuxTotalxDep)
        End If

        intAuxTotalxDep = 0
        If grdAvances.Cols(19).IsVisible = True Then
            strNombresDepartamentos.Add(grdAvances.Cols(19).Caption)
            For i = 1 To grdAvances.Rows.Count - 1
                If grdAvances.GetData(i, 19) <> "" Then
                    intAuxTotalxDep = intAuxTotalxDep + CInt(grdAvances.GetData(i, 8))
                End If
            Next
            intTotalDepartamentos.Add(intAuxTotalxDep)
        End If

        intAuxTotalxDep = 0
        If grdAvances.Cols(20).IsVisible = True Then
            strNombresDepartamentos.Add(grdAvances.Cols(20).Caption)
            For i = 1 To grdAvances.Rows.Count - 1
                If grdAvances.GetData(i, 20) <> "" Then
                    intAuxTotalxDep = intAuxTotalxDep + CInt(grdAvances.GetData(i, 8))
                End If
            Next
            intTotalDepartamentos.Add(intAuxTotalxDep)
        End If

        Dim T As TimeSpan

        If grdAvances.Rows.Count > 1 Then
            If rblLotesAtrasados.Checked = True Then
                For i = 1 To grdAvances.Rows.Count - 1
                    T = Now.Date - CDate(grdAvances.GetData(i, 21))
                    grdAvances.SetData(i, 22, (T.Days - 3) & " Dia(s)")
                Next
            End If
        End If


        i = 0
        For Each Depto As Int32 In intTotalDepartamentos
            lblTotales.Text = lblTotales.Text + strNombresDepartamentos(i) + ": " + Depto.ToString + "          "
            i = i + 1
        Next

        For i = 1 To grdAvances.Rows.Count - 1
            intTotalPares = intTotalPares + CInt(grdAvances.GetData(i, 8))
        Next

        lblTotales.Text = "Total de Pares: " + CStr(intTotalPares) + "          " + lblTotales.Text

        lblTotales.Text = lblTotales.Text.Trim

    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        Cursor.Current = Cursors.WaitCursor
        grdAvances.Rows.Count = 1
        grdAvances.Cols(11).Caption = "D1"
        grdAvances.Cols(11).Visible = True
        grdAvances.Cols(13).Caption = "D2"
        grdAvances.Cols(13).Visible = True
        grdAvances.Cols(15).Caption = "D3"
        grdAvances.Cols(15).Visible = True
        grdAvances.Cols(17).Caption = "D4"
        grdAvances.Cols(17).Visible = True
        grdAvances.Cols(19).Caption = "D5"
        grdAvances.Cols(19).Visible = True
        InitComps()
        lblTotales.Text = "Total de Pares: 0"
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub chkFechaAvance_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFechaAvance.CheckedChanged
        If chkFechaAvance.Checked Then
            dtpFechaAvanceDe.Enabled = True
            dtpFechaAvanceA.Enabled = True
        Else
            dtpFechaAvanceDe.Enabled = False
            dtpFechaAvanceA.Enabled = False
        End If
    End Sub

    Private Sub cmbNave_Validated(sender As Object, e As System.EventArgs) Handles cmbNave.Validated
        cmbDepartamento.DataSource = Nothing
        cmbDepartamento.Items.Clear()
        cmbCelula.DataSource = Nothing
        cmbCelula.Items.Clear()
        cmbDepartamento = Controles.ComboDepartamentosSegunNave(cmbDepartamento, CInt(cmbNave.SelectedValue))
    End Sub

    Private Sub cmbDepartamento_Validated(sender As Object, e As System.EventArgs) Handles cmbDepartamento.Validated
        If cmbDepartamento.SelectedIndex > 0 Then
            cmbCelula = Controles.ComboCelulasSegunDepartamento(cmbCelula, CInt(cmbNave.SelectedValue), CInt(cmbDepartamento.SelectedValue))
        End If
    End Sub

    Private Sub grdAvances_AfterEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles grdAvances.AfterEdit
        grdAvances.SetData(e.Row, e.Col, grdAvances.GetData(e.Row, e.Col).ToString.ToUpper)
        If grdAvances.GetData(e.Row, e.Col).ToString.Length > 0 Then
            GuardarObservacionLote(grdAvances.GetData(e.Row, 1), grdAvances.GetData(e.Row, 2), grdAvances.GetData(e.Row, 3), grdAvances.GetData(e.Row, e.Col))
        End If
    End Sub

    Private Sub grdAvances_DoubleClick(sender As Object, e As System.EventArgs) Handles grdAvances.DoubleClick
        If grdAvances.Row <= 0 Then Exit Sub
        If grdAvances.Col = 9 Then Exit Sub
        frmFormE = New AdmonAvancesDetalleForm
        With frmFormE
            .SeleccionarItem(CInt(grdAvances.GetData(grdAvances.Row, 1)), CInt(grdAvances.GetData(grdAvances.Row, 2)), CInt(grdAvances.GetData(grdAvances.Row, 3)))
            .ShowDialog()
        End With
        frmFormE.Close()
        frmFormE = Nothing
    End Sub

    Private Sub grdAvances_EnterCell(sender As Object, e As System.EventArgs) Handles grdAvances.EnterCell
        If grdAvances.Row <= 0 Then Exit Sub
        If grdAvances.Col = 9 Then
            grdAvances.AllowEditing = True
        Else
            grdAvances.AllowEditing = False
        End If
    End Sub

    Private Sub GuardarObservacionLote(ByVal vAño As Int32, ByVal vNave As Int32, ByVal vLote As Int32, ByVal vObservaciones As String)
        Dim objBU As New LotesAvancesBU
        Dim objLote As New Lote

        objLote.PLoteAño = vAño
        objLote.PLoteNave = vNave
        objLote.PLoteNumero = vLote
        objLote.PLoteObservacion = vObservaciones

        objBU.GuardarObsLote(objLote)

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        ImpresionReporte()
    End Sub

    Private Sub ImpresionReporte(Optional ByVal vExportarPDF As Boolean = False, Optional ByVal vExportarEXCEL As Boolean = False)

        If grdAvances.Rows.Count > 1 Then

            Dim dtInforReporte As New DataTable
            Dim intCol As Int16 = 0
            Dim ColActual As Int16 = 1
            Dim ColocarTitulo As Boolean = False

            Cursor = Cursors.WaitCursor

            dtInforReporte.Columns.Add("Usuario", GetType(String))
            dtInforReporte.Columns.Add("Nave", GetType(String))
            dtInforReporte.Columns.Add("FechaInicio", GetType(String))
            dtInforReporte.Columns.Add("FechaFin", GetType(String))

            dtInforReporte.Columns.Add("Departamento", GetType(String))
            dtInforReporte.Columns.Add("Celula", GetType(String))

            dtInforReporte.Columns.Add("Estatus", GetType(String))

            dtInforReporte.Columns.Add("FechaAvanceInicio", GetType(String))
            dtInforReporte.Columns.Add("FechaAvanceFin", GetType(String))

            dtInforReporte.Columns.Add("FechaLote", GetType(String))
            dtInforReporte.Columns.Add("Lote", GetType(Integer))
            dtInforReporte.Columns.Add("Modelo", GetType(String))
            dtInforReporte.Columns.Add("Coleccion", GetType(String))
            dtInforReporte.Columns.Add("Talla", GetType(String))
            dtInforReporte.Columns.Add("Color", GetType(String))
            dtInforReporte.Columns.Add("Pares", GetType(Integer))
            dtInforReporte.Columns.Add("Observaciones", GetType(String))

            dtInforReporte.Columns.Add("TituloD1", GetType(String))
            dtInforReporte.Columns.Add("ValorD1", GetType(String))

            dtInforReporte.Columns.Add("TituloD2", GetType(String))
            dtInforReporte.Columns.Add("ValorD2", GetType(String))

            dtInforReporte.Columns.Add("TituloD3", GetType(String))
            dtInforReporte.Columns.Add("ValorD3", GetType(String))

            dtInforReporte.Columns.Add("TituloD4", GetType(String))
            dtInforReporte.Columns.Add("ValorD4", GetType(String))

            dtInforReporte.Columns.Add("TituloD5", GetType(String))
            dtInforReporte.Columns.Add("ValorD5", GetType(String))

            dtInforReporte.Columns.Add("MostrarEmbarque", GetType(Byte))
            dtInforReporte.Columns.Add("Embarque", GetType(String))

            dtInforReporte.Columns.Add("MostrarAtrasoLote", GetType(Byte))
            dtInforReporte.Columns.Add("AtrasoLote", GetType(String))

            Dim Renglon As DataRow

            For Each Filagrid As C1.Win.C1FlexGrid.Row In grdAvances.Rows

                If Filagrid.Index > 0 Then

                    Renglon = dtInforReporte.NewRow()

                    'Información Encabezado
                    Renglon("Usuario") = objUsuarioSesion.PUserUsername.ToUpper
                    Renglon("Nave") = cmbNave.Text
                    Renglon("FechaInicio") = FormatDateTime(dtpFechaProgramacionDe.Value, DateFormat.ShortDate).ToUpper
                    Renglon("FechaFin") = FormatDateTime(dtpFechaProgramacionA.Value, DateFormat.ShortDate).ToUpper
                    Renglon("Departamento") = cmbDepartamento.Text
                    Renglon("Celula") = cmbCelula.Text

                    If rblLotesAtrasados.Checked = True Then
                        Renglon("Estatus") = "LOTES ATRASADOS"
                    ElseIf rblLotesProceso.Checked = True Then
                        Renglon("Estatus") = "LOTES EN PROCESO"
                    ElseIf rblLotesTerminados.Checked = True Then
                        Renglon("Estatus") = "LOTES TERMINADO"
                    Else
                        Renglon("Estatus") = "TODOS LOS LOTES"
                    End If

                    If chkFechaAvance.Checked = True Then
                        Renglon("FechaAvanceInicio") = FormatDateTime(dtpFechaAvanceDe.Value, DateFormat.ShortDate).ToUpper
                        Renglon("FechaAvanceFin") = FormatDateTime(dtpFechaAvanceA.Value, DateFormat.ShortDate).ToUpper
                    Else
                        Renglon("FechaAvanceInicio") = ""
                        Renglon("FechaAvanceFin") = ""
                    End If

                    'Información del Lote
                    Renglon("FechaLote") = FormatDateTime(Filagrid(21), DateFormat.ShortDate).ToString
                    Renglon("Lote") = Filagrid(3).ToString
                    Renglon("Modelo") = Filagrid(4).ToString
                    Renglon("Coleccion") = Filagrid(5).ToString
                    Renglon("Talla") = Filagrid(6).ToString
                    Renglon("Color") = Filagrid(7).ToString
                    Renglon("Pares") = Filagrid(8).ToString
                    Renglon("Observaciones") = Filagrid(9).ToString

                    'Información de los Departamentos
                    ColActual = 1

                    For intCol = 11 To 19 Step 2
                        If grdAvances.Cols(intCol).IsVisible = True Then
                            Renglon("TituloD" & ColActual) = grdAvances.Cols(intCol).Caption
                            Renglon("ValorD" & ColActual) = Filagrid(intCol).ToString
                            ColActual += 1
                        End If
                    Next

                    If grdAvances.Cols(20).IsVisible = True Then
                        Renglon("MostrarEmbarque") = 1
                        Renglon("Embarque") = Filagrid(20).ToString
                    Else
                        Renglon("MostrarEmbarque") = 0
                    End If

                    If grdAvances.Cols(22).IsVisible = True Then
                        Renglon("MostrarAtrasoLote") = 1
                        Renglon("AtrasoLote") = Filagrid(22).ToString
                    Else
                        Renglon("MostrarAtrasoLote") = 0
                    End If

                    'Agregar Fila
                    dtInforReporte.Rows.Add(Renglon)
                End If
            Next

            'Mandar Imprimir
            Dim frmVistaPrevia As New ReportesVistaPreviaForm
            Dim vReporte As New rptAvanceLotesProduccion

            With frmVistaPrevia
                If .Imprimir(vReporte, dtInforReporte, vExportarPDF, vExportarEXCEL) Then
                    .ShowDialog()
                    .Close()
                End If
            End With

            frmVistaPrevia = Nothing

            Cursor = Cursors.Default

        End If

    End Sub

    Private Sub cmbDepartamento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        If cmbDepartamento.SelectedIndex > 0 Then
            chkFechaAvance.Enabled = True
        Else
            chkFechaAvance.Enabled = False
        End If
    End Sub

    Private Sub btnExpPDF_Click(sender As System.Object, e As System.EventArgs) Handles btnExpPDF.Click
        ImpresionReporte(True)
    End Sub

    Private Sub btnExpExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExpExcel.Click
        ImpresionReporte(False, True)
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNave.SelectedIndexChanged

    End Sub

    Private Sub btnAbajoResumen_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajoResumen.Click
        grbResumen.Height = 35
        btnAbajoResumen.Top = 12
        btnArribaResumen.Top = 12
    End Sub

    Private Sub btnArribaResumen_Click(sender As System.Object, e As System.EventArgs) Handles btnArribaResumen.Click
        grbResumen.Height = 155
        btnAbajoResumen.Top = 12
        btnArribaResumen.Top = 12
    End Sub

    Private Sub C1FlexGrid1_Click(sender As System.Object, e As System.EventArgs) Handles grdResumen.Click

    End Sub
End Class

