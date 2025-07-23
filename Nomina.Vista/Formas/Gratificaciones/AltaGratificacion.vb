Imports Nomina.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AltaGratificacion
    Dim combobox As New ComboBox
    Dim seleccion As Int32
    Dim ListaSolicitudesIncentivos As New List(Of Entidades.SolicitudIncentivos)
    Dim row, cell As Integer
    Dim ColumnaCombo As New DataGridViewComboBoxColumn
    Dim columnaComboGratificacion2 As New DataGridViewComboBoxColumn
    Dim columnaComboGratificacion3 As New DataGridViewComboBoxColumn
    Dim dtCatMotivos As New DataTable

    Private Sub AltaGratificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        accionesInicio()
    End Sub

    Public Sub llenarGridEmpleados()
        Dim objClbdsBU As New Negocios.ColaboradoresBU
        Dim dtColaboradores As New DataTable
        Dim numero As New Int32
        numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ''Dim nave As String = ""
        ''Dim periodo As String = ""
        ''If cmbNave.SelectedIndex > 0 Then
        ''    nave = cmbNave.SelectedValue
        ''Else
        ''    nave = "0"
        ''End If

        ''If cmbPeriodo.SelectedIndex > 0 Then
        ''    periodo = cmbNave.SelectedValue
        ''Else
        ''    periodo = "0"
        ''End If
        ''If CInt(nave) > 0 Then
        ''    If CInt(periodo) > 0 Then

        dtColaboradores = objClbdsBU.BuscarEmpleadoSegunDepartamentoTabla(txtBuscarNombreIncentivo.Text, numero, cmbNave.SelectedValue, cmbPeriodo.SelectedValue)
        grdEmpleadoGratificacion.DataSource = Nothing

        If dtColaboradores.Rows.Count > 0 Then
            grdEmpleadoGratificacion.DataSource = dtColaboradores

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns.Add("MotivoUno", "MotivoUno")
            Dim colMotivoUno As UltraGridColumn = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoUno")
            colMotivoUno.Header.Caption = "Motivo"

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns.Add("MontoUno", "MontoUno")
            Dim colMontoUno As UltraGridColumn = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MontoUno")
            colMontoUno.Header.Caption = "Cantidad"
            colMontoUno.MaskInput = "nnnn.nn"

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns.Add("MotivoDos", "MotivoDos")
            Dim colMotivoDos As UltraGridColumn = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoDos")
            colMotivoDos.Header.Caption = "Motivo"

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns.Add("MontoDos", "MontoDos")
            Dim colMontoDos As UltraGridColumn = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MontoDos")
            colMontoDos.Header.Caption = "Cantidad"
            colMontoDos.MaskInput = "nnnn.nn"

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns.Add("MotivoTres", "MotivoTres")
            Dim colMotivoTres As UltraGridColumn = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoTres")
            colMotivoTres.Header.Caption = "Motivo"

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns.Add("MontoTres", "MontoTres")
            Dim colMontoTres As UltraGridColumn = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MontoTres")
            colMontoTres.Header.Caption = "Cantidad"
            colMontoTres.MaskInput = "nnnn.nn"

            Dim objIncentivoBU As New Nomina.Negocios.IncentivosBU

            dtCatMotivos = New DataTable
            dtCatMotivos = objIncentivoBU.ListaIncentivosSUsuarioConsulta(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            Dim newRow As DataRow = dtCatMotivos.NewRow
            dtCatMotivos.Rows.InsertAt(newRow, 0)
            Dim listaValoresMotivos As New ValueList

            For Each rowDt As DataRow In dtCatMotivos.Rows
                If rowDt.Item("moin_motivoincentivoid").ToString <> "20" And rowDt.Item("moin_motivoincentivoid").ToString <> "34" Then
                    listaValoresMotivos.ValueListItems.Add(rowDt.Item("moin_motivoincentivoid"), rowDt.Item("moin_nombre").ToString.ToUpper.Trim)
                End If
            Next

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoUno").Style = UltraWinGrid.ColumnStyle.DropDown
            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoUno").ValueList = listaValoresMotivos

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoDos").Style = UltraWinGrid.ColumnStyle.DropDown
            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoDos").ValueList = listaValoresMotivos

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoTres").Style = UltraWinGrid.ColumnStyle.DropDown
            grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MotivoTres").ValueList = listaValoresMotivos

            With grdEmpleadoGratificacion.DisplayLayout.Bands(0)
                .Columns("codr_colaboradorid").Hidden = True
                .Columns("labo_colaboradorlaboralid").Hidden = True
                .Columns("labo_naveid").Hidden = True
                .Columns("labo_departamentoid").Hidden = True
                .Columns("grup_grupoid").Hidden = True
                .Columns("celu_celulaid").Hidden = True
                .Columns("nave_naveid").Hidden = True
                .Columns("pues_puestoid").Hidden = True
                .Columns("codr_fechanacimiento").Hidden = True
                .Columns("labo_GanaIncentivosSiempre").Hidden = True
                .Columns("pues_puestoid").Hidden = True
                .Columns("nave_nombre").Hidden = True
                .Columns("antiguedad").Hidden = True
                .Columns("grup_name").Header.Caption = "Departamento"
                .Columns("pues_nombre").Header.Caption = "Puesto"
                .Columns("NOMBRE").Header.Caption = "Colaborador"
                .Columns("nave_nombre").Header.Caption = "Nave"
                .Columns("celu_nombre").Header.Caption = "Celula"
                .Columns("grup_name").CellActivation = Activation.NoEdit
                .Columns("pues_nombre").CellActivation = Activation.NoEdit
                .Columns("NOMBRE").CellActivation = Activation.NoEdit
                .Columns("nave_nombre").CellActivation = Activation.NoEdit
                .Columns("celu_nombre").CellActivation = Activation.NoEdit
                .Columns("MontoUno").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("MontoDos").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("MontoTres").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With

            For Each rowGrd As UltraGridRow In grdEmpleadoGratificacion.Rows
                rowGrd.Cells("MontoUno").Value = 0.0
                rowGrd.Cells("MontoDos").Value = 0.0
                rowGrd.Cells("MontoTres").Value = 0.0
            Next
            Dim sumuno As SummarySettings = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MontoUno"))
            Dim sumdos As SummarySettings = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MontoDos"))
            Dim sumtres As SummarySettings = grdEmpleadoGratificacion.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdEmpleadoGratificacion.DisplayLayout.Bands(0).Columns("MontoTres"))

            sumuno.DisplayFormat = "{0:#,##0.00}"
            sumuno.Appearance.TextHAlign = HAlign.Right
            sumdos.DisplayFormat = "{0:#,##0.00}"
            sumdos.Appearance.TextHAlign = HAlign.Right
            sumtres.DisplayFormat = "{0:#,##0.00}"
            sumtres.Appearance.TextHAlign = HAlign.Right
            'sumTotal.DisplayFormat = "{0:#,##0.00}"
            'sumTotal.Appearance.TextHAlign = HAlign.Right
            'sumTotal.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

            grdEmpleadoGratificacion.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"
            'sumuno.SummaryFooterCaption = "Total"
            'sumdos.SummaryFooterCaption = "Total"
            'sumtres.SummaryFooterCaption = "Total"
            grdEmpleadoGratificacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdEmpleadoGratificacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdEmpleadoGratificacion.DisplayLayout.Override.RowSelectorWidth = 35
            grdEmpleadoGratificacion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        End If
        ''    End If
        ''End If
    End Sub

    Public Sub accionesInicio()
        Panel3.BackColor = Color.GreenYellow
        Panel4.BackColor = Color.Salmon
        Panel5.BackColor = Color.Sienna
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        'grdBuscarEmpleado.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'grdBuscarEmpleado.Columns.Add("clmNombre", "Nombre") '0
        'grdBuscarEmpleado.Columns("clmNombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'grdBuscarEmpleado.Columns("clmNombre").ReadOnly = True
        'grdBuscarEmpleado.Columns("clmNombre").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

        ''---------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmPaterno", "Paterno") '1
        'grdBuscarEmpleado.Columns("clmPaterno").Visible = False
        ''-----------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmMaterno", "Materno") '2
        'grdBuscarEmpleado.Columns("clmMaterno").Visible = False
        ''------------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmDepartamento", "Departamento") '3
        'grdBuscarEmpleado.Columns("clmDepartamento").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'grdBuscarEmpleado.Columns("clmDepartamento").ReadOnly = True
        'grdBuscarEmpleado.Columns("clmDepartamento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ''------------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmCelula", "Celula") '3
        'grdBuscarEmpleado.Columns("clmCelula").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'grdBuscarEmpleado.Columns("clmCelula").ReadOnly = True
        'grdBuscarEmpleado.Columns("clmCelula").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        ''--------------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmIDEmpleado", "IDEmpleado") '4
        'grdBuscarEmpleado.Columns("clmIDEmpleado").Visible = False
        ''----------------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmFechaCreacion", "Fecha Creación") '5
        'grdBuscarEmpleado.Columns("clmFechaCreacion").Visible = False
        ''-------------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmPuesto", "Puesto") '6
        'grdBuscarEmpleado.Columns("clmPuesto").ReadOnly = True
        'grdBuscarEmpleado.Columns("clmPuesto").Width = 185

        '  grdBuscarEmpleado.Columns("Puesto").AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '--------------------------------------------------------
        'grdBuscarEmpleado.Columns.Add("clmIdNaveColaborador", "IdNaveColaborador") '7
        'grdBuscarEmpleado.Columns("clmIdNaveColaborador").Visible = False

        'grdBuscarEmpleado.Columns.Add("clmCantidad", "Cantidad") '8
        'grdBuscarEmpleado.Columns("clmCantidad").ReadOnly = False
        'grdBuscarEmpleado.Columns("clmCantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grdBuscarEmpleado.Columns("clmCantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'grdBuscarEmpleado.Columns("clmCantidad").DefaultCellStyle.Format = "N0"
        ' grdBuscarEmpleado.Columns.Add("Motivo", "Motivo") '9

        'Dim objIncentivoBU As New Nomina.Negocios.IncentivosBU
        'Try
        '    ColumnaCombo.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
        '    ColumnaCombo.DisplayMember = "INombre"
        '    ColumnaCombo.ValueMember = "IIncentivoId"
        '    ColumnaCombo.DataPropertyName = "IIncentivoId"

        '    'mas de una gratificacion
        '    columnaComboGratificacion2.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
        '    columnaComboGratificacion2.DisplayMember = "INombre"
        '    columnaComboGratificacion2.ValueMember = "IIncentivoId"
        '    columnaComboGratificacion2.DataPropertyName = "IIncentivoId"

        '    columnaComboGratificacion3.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
        '    columnaComboGratificacion3.DisplayMember = "INombre"
        '    columnaComboGratificacion3.ValueMember = "IIncentivoId"
        '    columnaComboGratificacion3.DataPropertyName = "IIncentivoId"
        'Catch ex As Exception

        'End Try


        ''grdBuscarEmpleado.Columns.Add(ColumnaCombo)
        'ColumnaCombo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'grdBuscarEmpleado.Columns.Add("clmCantidad2", "Cantidad") '11 cantidad gratificacion 2
        'grdBuscarEmpleado.Columns("clmCantidad2").ReadOnly = False
        'grdBuscarEmpleado.Columns("clmCantidad2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grdBuscarEmpleado.Columns("clmCantidad2").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'grdBuscarEmpleado.Columns("clmCantidad2").DefaultCellStyle.Format = "N0"

        'grdBuscarEmpleado.Columns.Add(columnaComboGratificacion2)
        'columnaComboGratificacion2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'grdBuscarEmpleado.Columns.Add("clmCantidad3", "Cantidad") '12 cantidad gratificacion 3
        'grdBuscarEmpleado.Columns("clmCantidad3").ReadOnly = False
        'grdBuscarEmpleado.Columns("clmCantidad3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'grdBuscarEmpleado.Columns("clmCantidad3").AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        'grdBuscarEmpleado.Columns("clmCantidad3").DefaultCellStyle.Format = "N0"

        'grdBuscarEmpleado.Columns.Add(columnaComboGratificacion3)
        'columnaComboGratificacion3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'combobox = Controles.ComboMotivosIncentivoSegunUsuario(combobox, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        ''llenartabla()
    End Sub

    'Public Sub AgregarFila(ByVal empleado As Entidades.Colaborador)

    '    Dim celda As DataGridViewCell
    '    Dim fila As New DataGridViewRow

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = empleado.PNombre.ToUpper + " " + empleado.PApaterno.ToUpper + " " + empleado.PAmaterno.ToUpper
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = empleado.PApaterno.ToUpper
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = empleado.PAmaterno.ToUpper
    '    fila.Cells.Add(celda)


    '    celda = New DataGridViewTextBoxCell
    '    Try
    '        celda.Value = empleado.PIDepartamento.DNombre.ToUpper
    '    Catch ex As Exception

    '    End Try

    '    fila.Cells.Add(celda)


    '    celda = New DataGridViewTextBoxCell
    '    Try
    '        celda.Value = empleado.Pcelulas.PNombre.ToUpper
    '    Catch ex As Exception
    '    End Try

    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = empleado.PColaboradorid
    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = empleado.PFechaCreacion
    '    fila.Cells.Add(celda)

    '    Dim BuscarPuesto As New Entidades.ColaboradorLaboral
    '    Dim objBusPuesto As New Negocios.ColaboradorLaboralBU
    '    BuscarPuesto = objBusPuesto.buscarInformacionLaboral(empleado.PColaboradorid)
    '    celda = New DataGridViewTextBoxCell
    '    Try
    '        celda.Value = BuscarPuesto.PPuestoId.PNombre.ToUpper
    '    Catch ex As Exception

    '    End Try

    '    fila.Cells.Add(celda)

    '    BuscarPuesto = objBusPuesto.buscarInformacionLaboral(empleado.PColaboradorid)
    '    celda = New DataGridViewTextBoxCell
    '    Try
    '        celda.Value = BuscarPuesto.PNaveId.PNaveId
    '    Catch ex As Exception

    '    End Try

    '    fila.Cells.Add(celda)

    '    celda = New DataGridViewTextBoxCell
    '    celda.Value = "0.0"
    '    fila.Cells.Add(celda)

    '    grdBuscarEmpleado.Rows.Add(fila)

    'End Sub


    'Public Sub llenartabla()


    '    Dim listaEmpleados As New List(Of Entidades.Colaborador)
    '    Dim objBU As New Negocios.ColaboradoresBU
    '    Dim numero As New Int32
    '    numero = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    '    listaEmpleados = objBU.BuscarEmpleadoSegunDepartamento(txtBuscarNombreIncentivo.Text, numero, cmbNave.SelectedValue)


    '    For Each objeto As Entidades.Colaborador In listaEmpleados
    '        Dim conteo As Int32
    '        Try
    '            'conteo += 1
    '            'If conteo = 152 Then
    '            '    MsgBox(conteo)
    '            'End If
    '            AgregarFila(objeto)
    '            grdBuscarEmpleado.Rows(conteo).Cells("clmCantidad2").Value = "0.0"
    '            grdBuscarEmpleado.Rows(conteo).Cells("clmCantidad3").Value = "0.0"
    '            conteo += 1
    '        Catch ex As Exception
    '            'conteo = conteo
    '        End Try


    '    Next


    'End Sub



    Public Sub GuardarSolicitudes()

        Dim objIncentivosBU As New Negocios.IncentivosBU
        Dim objBUFiniquito As New Negocios.FiniquitosBU
        Dim enviarCorreo As Boolean = False
        Dim total As Double = 0.0
        Dim listaIncentivos As New List(Of Entidades.SolicitudIncentivos)
        For Each grdRow As UltraGridRow In grdEmpleadoGratificacion.Rows

            If Not grdRow.Cells("MotivoUno").Value = Nothing Then

                If grdRow.Cells("MontoUno").Value > 0 And
                    grdRow.Cells("MotivoUno").Value.ToString <> "" Then
                    Dim IncentivosGrat As New Entidades.SolicitudIncentivos
                    Dim motivo, motivoGratificacion2, motivoGratificacion3 As New Entidades.Incentivos
                    IncentivosGrat.PColaboradorID = grdRow.Cells("codr_colaboradorid").Value.ToString
                    motivo.IIncentivoId = grdRow.Cells("MotivoUno").Value
                    IncentivosGrat.PMotivoID = motivo
                    IncentivosGrat.PMontoGratificacion1 = grdRow.Cells("MontoUno").Value
                    IncentivosGrat.PDescripcion = "NO SE CAPTURO DESCRIPCION"
                    total = grdRow.Cells("MontoUno").Value
                    Dim entCol As New Entidades.Colaborador
                    Dim entIncent As New Entidades.Incentivos
                    Dim entDepa As New Entidades.Departamentos

                    entCol.PNombre = grdRow.Cells("NOMBRE").Value
                    entIncent.INombre = grdRow.Cells("MotivoUno").Text
                    entDepa.DNombre = grdRow.Cells("grup_name").Value


                    IncentivosGrat.PNombreColaborador = entCol
                    IncentivosGrat.PDepartamento = entDepa
                    IncentivosGrat.PFechaSolicitud = Date.Now
                    IncentivosGrat.PNombreIncentivo = entIncent


                    '       .Columns("pues_puestoid").Hidden = True
                    '.Columns("nave_nombre").Hidden = True
                    '.Columns("antiguedad").Hidden = True
                    '.Columns("grup_name").Header.Caption = "Departamento"
                    '.Columns("pues_nombre").Header.Caption = "Puesto"
                    '.Columns("NOMBRE").Header.Caption = "Colaborador"
                    '.Columns("nave_nombre").Header.Caption = "Nave"
                    '.Columns("celu_nombre").Header.Caption = "Celula"

                    ' "<td>" + solicitud.PNombreColaborador.PNombre.ToString + "</td>" +
                    '"<td>" + solicitud.PDepartamento.DNombre + "</td>" +
                    '"<td>" + solicitud.PFechaSolicitud.ToShortDateString + "</td>" +
                    '"<td>" + solicitud.PNombreIncentivo.INombre.ToString + "</td>" +
                    '"<td>" + solicitud.PMonto.ToString("C") + "</td>"

                    If Not grdRow.Cells("MotivoDos").Value = Nothing Then
                        If grdRow.Cells("MontoDos").Value > 0 And
                            grdRow.Cells("MotivoDos").Value.ToString <> "20" And
                            grdRow.Cells("MotivoDos").Value.ToString <> "34" And
                            grdRow.Cells("MotivoDos").Value.ToString <> "" Then
                            motivoGratificacion2.IIncentivoId = grdRow.Cells("MotivoDos").Value
                            IncentivosGrat.PMotivoID2 = motivoGratificacion2
                            IncentivosGrat.PMontoGratificacion2 = grdRow.Cells("MontoDos").Value
                            total = total + grdRow.Cells("MontoDos").Value
                        End If
                    End If

                    If Not grdRow.Cells("MotivoTres").Value = Nothing Then
                        If grdRow.Cells("MontoTres").Value > 0 And
                            grdRow.Cells("MotivoTres").Value.ToString <> "20" And
                            grdRow.Cells("MotivoTres").Value.ToString <> "34" And
                            grdRow.Cells("MotivoTres").Value.ToString <> "" Then
                            motivoGratificacion3.IIncentivoId = grdRow.Cells("MotivoTres").Value
                            IncentivosGrat.PMotivoID3 = motivoGratificacion3
                            IncentivosGrat.PMontoGratificacion3 = grdRow.Cells("MontoTres").Value
                            total = total + grdRow.Cells("MontoTres").Value
                        End If
                    End If
                    IncentivosGrat.PMonto = total
                    objIncentivosBU.EnviarSolicitudIncentivo(IncentivosGrat, cmbNave.SelectedValue, cmbPeriodo.SelectedValue)
                    listaIncentivos.Add(IncentivosGrat)
                    enviarCorreo = True
                End If
            End If
        Next
        If enviarCorreo = True Then
            enviar_correo(cmbNave.SelectedValue, listaIncentivos, "ENVIO_NOTIFICACION_GRATIFICACION")
        End If

        'Dim Alerta As New Boolean
        'Dim CountAcept As Int32 = 0
        '' Dim valorCheck As Integer
        'Dim sentinela As Integer = 0
        'For Each row As DataGridViewRow In grdBuscarEmpleado.Rows 'Recorro todo el grid fila por fila
        '    ' valorCheck = CInt(row.Cells("clmNombre").Value)

        '    If grdBuscarEmpleado.Rows(sentinela).Cells(10).Value = Nothing And grdBuscarEmpleado.Rows(sentinela).Cells("clmCantidad").Value > 0 Then
        '        Alerta = True
        '    End If
        '    Dim Guardar As Boolean = True


        '    Dim cmbmotivos As New Negocios.IncentivosBU
        '    Dim cmbMotivoGratificacion2 As New Negocios.IncentivosBU
        '    Dim cmbMotivoGratificacion3 As New Negocios.IncentivosBU

        '    Dim NombreIncentivos As String = ""
        '    Dim nombreIncentivoGratificacion2 As String = ""
        '    Dim nombreIncentivoGratificacion3 As String = "" 'motivos gratificaciones

        '    NombreIncentivos = cmbmotivos.buscarNombreIncentivo(grdBuscarEmpleado.Rows(sentinela).Cells(10).Value)
        '    nombreIncentivoGratificacion2 = cmbMotivoGratificacion2.buscarNombreIncentivo(grdBuscarEmpleado.Rows(sentinela).Cells(12).Value)
        '    nombreIncentivoGratificacion3 = cmbMotivoGratificacion3.buscarNombreIncentivo(grdBuscarEmpleado.Rows(sentinela).Cells(14).Value)

        '    If grdBuscarEmpleado.Rows(sentinela).Cells("clmCantidad").Value <= 0 Then
        '        If NombreIncentivos = "TRABAJO MEDIO DIA FESTIVO" Or NombreIncentivos = "TRABAJO DIA FESTIVO" Or nombreIncentivoGratificacion2 = "TRABAJO MEDIO DIA FESTIVO" Or nombreIncentivoGratificacion2 = "TRABAJO DIA FESTIVO" Or nombreIncentivoGratificacion3 = "TRABAJO MEDIO DIA FESTIVO" Or nombreIncentivoGratificacion3 = "TRABAJO DIA FESTIVO" And grdBuscarEmpleado.Rows(sentinela).Cells(8).Value <= 0 Then
        '            Guardar = True
        '        Else
        '            Guardar = False
        '        End If

        '    End If


        '    If grdBuscarEmpleado.Rows(sentinela).Cells(10).Value > 0 And Guardar = True Then

        '        'Dim Incentivos As New Entidades.SolicitudIncentivos

        '        Incentivos.PColaboradorID = grdBuscarEmpleado.Rows(sentinela).Cells("clmIDEmpleado").Value
        '        Incentivos.PMontoGratificacion1 = grdBuscarEmpleado.Rows(sentinela).Cells("clmcantidad").Value
        '        Incentivos.PMontoGratificacion2 = grdBuscarEmpleado.Rows(sentinela).Cells("clmcantidad2").Value
        '        Incentivos.PMontoGratificacion3 = grdBuscarEmpleado.Rows(sentinela).Cells("clmcantidad3").Value

        '        If 1 <> 0 Then
        '            Incentivos.PDescripcion = "NO SE CAPTURO DESCRIPCION"
        '        Else

        '        End If


        '        If grdBuscarEmpleado.Rows(sentinela).Cells("clmCantidad").Value > 0 And grdBuscarEmpleado.Rows(sentinela).Cells(10).Value = 0 Then
        '            Alerta = True
        '        End If


        '        Dim motivo, motivoGratificacion2, motivoGratificacion3 As New Entidades.Incentivos
        '        motivo.IIncentivoId = grdBuscarEmpleado.Rows(sentinela).Cells(10).Value
        '        Incentivos.PMotivoID = motivo

        '        motivoGratificacion2.IIncentivoId = grdBuscarEmpleado.Rows(sentinela).Cells(12).Value
        '        Incentivos.PMotivoID2 = motivoGratificacion2

        '        motivoGratificacion3.IIncentivoId = grdBuscarEmpleado.Rows(sentinela).Cells(14).Value
        '        Incentivos.PMotivoID3 = motivoGratificacion3


        '        Dim objBU As New IncentivosBU
        '        'bjBU.EnviarSolicitud(Incentivos)
        '        Dim FormularioMensaje As New ExitoForm
        '        Dim FormularioError As New AdvertenciaForm
        '        Dim MensajeNegocios As String = ""
        '        MensajeNegocios = objBU.EnviarSolicitud(Incentivos, cmbNave.SelectedValue, cmbPeriodo.SelectedValue)


        ''If MensajeNegocios.Length = 0 Then



        ''    grdBuscarEmpleado.Rows(sentinela).DefaultCellStyle.BackColor = Color.GreenYellow
        ''    Dim SolicitudIncentivos As New Entidades.SolicitudIncentivos
        ''    Dim Colaborador As New Entidades.Colaborador
        ''    Colaborador.PApaterno = CStr(grdBuscarEmpleado.Rows(sentinela).Cells("clmPaterno").Value)
        ''    Colaborador.PAmaterno = grdBuscarEmpleado.Rows(sentinela).Cells("clmMaterno").Value
        ''    Colaborador.PNombre = grdBuscarEmpleado.Rows(sentinela).Cells("clmNombre").Value
        ''    SolicitudIncentivos.PNombreColaborador = Colaborador
        ''    Dim Departamento As New Entidades.Departamentos
        ''    Departamento.DNombre = grdBuscarEmpleado.Rows(sentinela).Cells("clmDepartamento").Value
        ''    SolicitudIncentivos.PDepartamento = Departamento
        ''    SolicitudIncentivos.PFechaSolicitud = Today.ToShortDateString
        ''    SolicitudIncentivos.PMontoGratificacion1 = grdBuscarEmpleado.Rows(sentinela).Cells("clmcantidad").Value 'monto1
        ''    SolicitudIncentivos.PMontoGratificacion2 = grdBuscarEmpleado.Rows(sentinela).Cells("clmCantidad2").Value 'monto2
        ''    SolicitudIncentivos.PMontoGratificacion3 = grdBuscarEmpleado.Rows(sentinela).Cells("clmCantidad3").Value 'monto2
        ''    SolicitudIncentivos.PMonto = SolicitudIncentivos.PMontoGratificacion1 + SolicitudIncentivos.PMontoGratificacion2 + SolicitudIncentivos.PMontoGratificacion3

        ''    Dim Motivoincentivo As New Entidades.Incentivos
        ''    Dim cmbmotivo As New Negocios.IncentivosBU
        ''    Dim NombreIncentivo As String = ""
        ''    NombreIncentivo = cmbmotivo.buscarNombreIncentivo(grdBuscarEmpleado.Rows(sentinela).Cells(10).Value)
        ''    Motivoincentivo.INombre = NombreIncentivo
        ''    SolicitudIncentivos.PNombreIncentivo = Motivoincentivo
        ''    ListaSolicitudesIncentivos.Add(SolicitudIncentivos)

        ''ElseIf MensajeNegocios = "El monto solicitado excede el limite del monto permitido." Then

        ''    grdBuscarEmpleado.Rows(sentinela).DefaultCellStyle.BackColor = Color.Salmon
        ''    Alerta = True

        ''Else
        ''    Alerta = True
        ''    grdBuscarEmpleado.Rows(sentinela).DefaultCellStyle.BackColor = Color.Sienna

        ''End If
        '    End If
        'sentinela += 1
        'Next
        'Dim FormularioMensajes As New ExitoForm
        'Dim FormularioErrorr As New AdvertenciaForm
        'If Alerta = False Then
        '    FormularioMensajes.mensaje = "Registro Guardado"
        '    FormularioMensajes.ShowDialog()
        '    '  Me.Close()
        'Else
        '    FormularioErrorr.mensaje = "Algunas Solicitudes no fueron capturadas correctamente"
        '    FormularioErrorr.ShowDialog()
        'End If



    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Esta seguro de guardar los cambios?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            If cmbPeriodo.SelectedIndex = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Tiene que seleccionar el periodo de nómina del cual se solicita la gratificación.")
            Else
                If cmbNave.SelectedValue > 0 And cmbPeriodo.SelectedValue > 0 Then
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        GuardarSolicitudes()
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Registro Correcto")
                        llenarGridEmpleados()
                    Catch ex As Exception
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió el siguiente error: " & ex.ToString)
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try

                    'If ListaSolicitudesIncentivos.Count > 0 Then

                    'End If

                End If
            End If
        End If
    End Sub



    Private Sub enviar_correo(ByVal naveID As Integer, ByVal Solicitudes As List(Of Entidades.SolicitudIncentivos), ByVal clave As String)
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
                                    "<img src='" + "http://www.grupoyuyin.com.mx/GRUPO_YUYIN.jpg" + "'style='" + "vertical-align:middle" + "' height='" + "57" + "' widht='" + "125" + "'> Solicitud de Gratificaciones <br>  <font size=2>Usuario que Solicito : " + Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString + "</font>" +
                                   " </div> <br></br>" +
                                    "<div id='" + "leftcolumn" + "'>" +
                                    "</div>" +
                                    "<div id='" + "rightcolumn" + "'>" +
                                    "</div>" + "<div id='" + "content" + "'>" +
                                      "<table id='" + "mi_tabla" + "' class='" + "tableizer-table" + "'>" +
                                       "<thead>" +
                                        "<tr class='" + "tableizer-firstrow" + "'>" +
                                        "<th width ='" + "20%" + "'>Nombre</th>" +
                                        "<th width ='" + "15%" + "'>Departamento</th>" +
                                        "<th width ='" + "7%" + "'>Fecha de Solicitud</th>" +
                                        "<th width ='" + "13%" + "'>Motivo</th>" +
                                        "<th width ='" + "7%" + "'>Cantidad</th>" +
                                       "</thead>" +
                                       "<tbody>"

        For Each solicitud As Entidades.SolicitudIncentivos In Solicitudes
            Email +=
                                        "<tr>" +
                                            "<td>" + solicitud.PNombreColaborador.PNombre.ToString + "</td>" +
                                            "<td>" + solicitud.PDepartamento.DNombre + "</td>" +
                                            "<td>" + solicitud.PFechaSolicitud.ToShortDateString + "</td>" +
                                            "<td>" + solicitud.PNombreIncentivo.INombre.ToString + "</td>" +
                                            "<td>" + solicitud.PMonto.ToString("C") + "</td>"

            SumaTotal += solicitud.PMonto
        Next




        Email += " " +
                   "</tr>" + "<tr> <td></td> <td></td> <td></td>  <td> Total : </td> <td>" + SumaTotal.ToString("C") + "</td> </tr>" +
                "</tbody>" +
                "</table>" +
                       "</div>" +
                       "<div id='" + "footer" + "'>" +
                       "</div>" +
                   "</div>" +
                "</body>" +
                "</html>"

        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Solicitud de Gratificacion", Email)
        'correo.EnviarCorreoHtml("gdesarrollo.ti@grupoyuyin.com.mx", "say_nomina@grupoyuyin.com.mx", "Solicitud de Gratificacion", Email)
    End Sub



    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    '    grdBuscarEmpleado.Rows.Clear()
    '    If cmbNave.SelectedValue > 0 Then
    '        llenartabla()
    '        lblNave.ForeColor = Color.Black
    '    Else
    '        lblNave.ForeColor = Color.Red
    '    End If

    '    Dim objIncentivoBU As New Nomina.Negocios.IncentivosBU
    '    Try
    '        ColumnaCombo.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
    '        ColumnaCombo.DisplayMember = "INombre"
    '        ColumnaCombo.ValueMember = "IIncentivoId"
    '        ColumnaCombo.DataPropertyName = "IIncentivoId"
    '    Catch ex As Exception

    '    End Try
    '    Me.Cursor = System.Windows.Forms.Cursors.Default



    'End Sub


    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub gpbFiltroIncentivos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpbFiltroIncentivos.Enter

    End Sub

    Private Sub btnArriba_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroIncentivos.Height = 45
    End Sub

    Private Sub btnAbajo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroIncentivos.Height = 98
    End Sub

    Private Sub grdBuscarEmpleado_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        row = e.RowIndex
        cell = e.ColumnIndex
    End Sub


    Private Sub grdBuscarEmpleado_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)



        'a = DGVReceipt.Item(cell, row).Value
    End Sub

    'Private Sub grdBuscarEmpleado_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    '    Dim cmbmotivo As New Negocios.IncentivosBU
    '    Dim NombreIncentivo As String = ""
    '    NombreIncentivo = cmbmotivo.buscarNombreIncentivo(grdBuscarEmpleado.Rows(row).Cells(10).Value)
    '    If NombreIncentivo = "TRABAJO MEDIO DIA FESTIVO" Or NombreIncentivo = "TRABAJO DIA FESTIVO" Then
    '        grdBuscarEmpleado.Rows(row).Cells("clmCantidad").Value = "0.0"
    '        grdBuscarEmpleado.Rows(row).Cells("clmCantidad").ReadOnly = True

    '    Else
    '        grdBuscarEmpleado.Rows(row).Cells("clmCantidad").ReadOnly = False
    '        Dim valor As Int32
    '        Try
    '            valor = grdBuscarEmpleado.Rows(row).Cells("clmCantidad").Value
    '        Catch ex As Exception
    '            'grdBuscarEmpleado.Rows(row).Cells("clmCantidad").Value = "0"
    '            grdBuscarEmpleado.Rows(row).Cells("clmCantidad").Value = "0.0"
    '        End Try

    '        'grdBuscarEmpleado.Rows(row).Cells("clmCantidad").Value = valor.ToString("##,###.##")

    '    End If
    '    'Dim a As String
    'End Sub

    ''Private Sub grdBuscarEmpleado_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
    ''    Try
    ''        Dim validar As TextBox = CType(e.Control, TextBox)

    ''        ' agregar el controlador de eventos para el KeyPress  
    ''        AddHandler validar.KeyPress, AddressOf validar_Keypress
    ''    Catch ex As Exception

    ''    End Try

    ''End Sub


    '    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '        ' evento Keypress  

    '        ' obtener indice de la columna  

    '        Dim columna As Integer = grdBuscarEmpleado.CurrentCell.ColumnIndex

    '        ' comprobar si la celda en edición corresponde a la columna que se requiera
    '        If columna = 8 Then
    '            ' Obtener caracter  
    '            Dim caracter As Char = e.KeyChar

    '            ' referencia a la celda  
    '            Dim txt As TextBox = CType(sender, TextBox)

    '            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
    '            ' es el separador decimal, y que no contiene ya el separador  
    '            If txt.Text.IndexOf(".") > 0 Then




    '            End If


    '            If (Char.IsNumber(caracter)) Or _
    '(caracter = ChrW(Keys.Back)) Or _
    '            (caracter = ".") And _
    '            (txt.Text.Contains(".") = False) Then

    '                e.Handled = False
    '            Else
    '                e.Handled = True



    '            End If
    '        End If
    '    End Sub

    Private Sub grdBuscarEmpleado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub grdBuscarEmpleado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nave As String = ""
        Dim periodo As String = ""
        If cmbNave.SelectedIndex > 0 Then
            nave = cmbNave.SelectedValue
        Else
            nave = "0"
        End If

        If cmbPeriodo.SelectedIndex > 0 Then
            periodo = cmbNave.SelectedValue
        Else
            periodo = "0"
        End If
        If CInt(nave) > 0 Then
            If CInt(periodo) > 0 Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                llenarGridEmpleados()
                ''grdBuscarEmpleado.Rows.Clear()
                ''If cmbNave.SelectedValue > 0 Then
                ''    llenartabla()
                ''    lblNave.ForeColor = Color.Black
                ''Else
                ''    lblNave.ForeColor = Color.Red
                ''End If

                ''Dim objIncentivoBU As New Nomina.Negocios.IncentivosBU
                ''Try
                ''    ColumnaCombo.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
                ''    ColumnaCombo.DisplayMember = "INombre"
                ''    ColumnaCombo.ValueMember = "IIncentivoId"
                ''    ColumnaCombo.DataPropertyName = "IIncentivoId"

                ''    'modificacion mas de una gratificacion
                ''    columnaComboGratificacion2.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
                ''    columnaComboGratificacion2.DisplayMember = "INombre"
                ''    columnaComboGratificacion2.ValueMember = "IIncentivoId"
                ''    columnaComboGratificacion2.DataPropertyName = "IIncentivoId"


                ''    columnaComboGratificacion3.DataSource = objIncentivoBU.ListaIncentivosSUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
                ''    columnaComboGratificacion3.DisplayMember = "INombre"
                ''    columnaComboGratificacion3.ValueMember = "IIncentivoId"
                ''    columnaComboGratificacion3.DataPropertyName = "IIncentivoId"
                ''Catch ex As Exception

                ''End Try
                Me.Cursor = System.Windows.Forms.Cursors.Default
            Else
                Dim objAdv As New Tools.AdvertenciaForm
                objAdv.mensaje = "Seleccione una periodo"
                objAdv.ShowDialog()
            End If
        Else
            Dim objAdv As New Tools.AdvertenciaForm
            objAdv.mensaje = "Seleccione una nave"
            objAdv.ShowDialog()
        End If

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Try
            grdEmpleadoGratificacion.DataSource = Nothing
            cmbPeriodo = Controles.ComboPeriodoSegunNaveIncentivos(cmbPeriodo, cmbNave.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBuscarNombreIncentivo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscarNombreIncentivo.KeyPress
        If CInt(AscW(e.KeyChar)) = CInt(Keys.Enter) Then
            Dim nave As String = ""
            Dim periodo As String = ""
            If cmbNave.SelectedIndex > 0 Then
                nave = cmbNave.SelectedValue
            Else
                nave = "0"
            End If
            If cmbPeriodo.SelectedIndex > 0 Then
                periodo = cmbNave.SelectedValue
            Else
                periodo = "0"
            End If
            If CInt(nave) > 0 Then
                If CInt(periodo) > 0 Then
                    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                    llenarGridEmpleados()
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                Else
                    Dim objAdv As New Tools.AdvertenciaForm
                    objAdv.mensaje = "Seleccione una periodo"
                    objAdv.ShowDialog()
                End If
            Else
                Dim objAdv As New Tools.AdvertenciaForm
                objAdv.mensaje = "Seleccione una nave"
                objAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdEmpleadoGratificacion_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdEmpleadoGratificacion.AfterCellUpdate
        Try

            If e.Cell.Row.IsFilterRow = False Then
                If e.Cell.Column.ToString = "MotivoUno" Then
                    If Not e.Cell.Value Is DBNull.Value Then
                        If e.Cell.Value = 34 Or e.Cell.Value = 20 Then
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoUno").Value = 0.0
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoUno").Activation = Activation.NoEdit
                        Else
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoUno").Activation = Activation.AllowEdit
                        End If
                    Else
                        grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoUno").Value = 0.0
                        grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoUno").Activation = Activation.NoEdit
                    End If
                ElseIf e.Cell.Column.ToString = "MotivoDos" Then
                    If Not e.Cell.Value Is DBNull.Value Then
                        If e.Cell.Value = 34 Or e.Cell.Value = 20 Then
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoDos").Value = 0.0
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoDos").Activation = Activation.NoEdit
                        Else
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoDos").Activation = Activation.AllowEdit
                        End If
                    Else
                        grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoDos").Value = 0.0
                        grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoDos").Activation = Activation.NoEdit
                    End If
                ElseIf e.Cell.Column.ToString = "MotivoTres" Then
                    If Not e.Cell.Value Is DBNull.Value Then
                        If e.Cell.Value = 34 Or e.Cell.Value = 20 Or e.Cell.Value.ToString = "" Then
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoTres").Value = 0.0
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoTres").Activation = Activation.NoEdit
                        Else
                            grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoTres").Activation = Activation.AllowEdit
                        End If
                    Else
                        grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoTres").Value = 0.0
                        grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MontoTres").Activation = Activation.NoEdit
                    End If
                End If

                If e.Cell.Column.ToString = "MotivoUno" Or e.Cell.Column.ToString = "MotivoDos" Or e.Cell.Column.ToString = "MotivoTres" Then
                    Dim valor As String = e.Cell.Text

                    Dim cambiar As Boolean = False
                    For Each itemO As DataRow In dtCatMotivos.Rows
                        If valor.Trim = itemO.Item("moin_nombre").ToString.Trim.ToUpper Then
                            cambiar = True
                        End If
                    Next
                    If cambiar = False Then
                        e.Cell.Value = e.Cell.OriginalValue
                    End If
                End If

            End If

        Catch ex As Exception
            e.Cell.Value = e.Cell.OriginalValue
        End Try
    End Sub

    Private Sub grdEmpleadoGratificacion_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdEmpleadoGratificacion.BeforeCellUpdate
        Try
            If e.Cell.Row.IsFilterRow = False Then
                If e.Cell.Column.ToString = "MontoUno" Or e.Cell.Column.ToString = "MontoDos" Or e.Cell.Column.ToString = "MontoTres" Then
                    If e.NewValue.ToString = "" Then
                        e.Cancel = True
                    Else
                        If e.NewValue > 0 Then
                            If e.Cell.Column.ToString = "MontoUno" Then
                                If Not grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoUno").Value Is Nothing Then
                                    If grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoUno").Value <> 34 And grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoUno").Value <> 20 Then
                                        Dim objMotInc As New Negocios.IncentivosBU
                                        Dim entIncentivo As New Entidades.Incentivos
                                        entIncentivo = objMotInc.buscarMotivoIncentivo(grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoUno").Value)
                                        If entIncentivo.IMontoMaximo > 0 Then
                                            If e.NewValue > entIncentivo.IMontoMaximo Then
                                                e.Cancel = True
                                                Dim objAdv As New Tools.AdvertenciaForm
                                                objAdv.mensaje = "La cantidad rebasa el monto máximo que se puede asignar a este incentivo."
                                                objAdv.ShowDialog()
                                            End If
                                        End If
                                    End If
                                Else
                                    e.Cancel = True
                                    Dim objAdv As New Tools.AdvertenciaForm
                                    objAdv.mensaje = "Selecciona un motivo"
                                    objAdv.ShowDialog()
                                End If
                            ElseIf e.Cell.Column.ToString = "MontoDos" Then
                                If Not grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoDos").Value.ToString = "" Then
                                    If grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoDos").Value <> 34 And grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoDos").Value <> 20 Then
                                        Dim objMotInc As New Negocios.IncentivosBU
                                        Dim entIncentivo As New Entidades.Incentivos
                                        entIncentivo = objMotInc.buscarMotivoIncentivo(grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoDos").Value)
                                        If entIncentivo.IMontoMaximo > 0 Then
                                            If e.NewValue > entIncentivo.IMontoMaximo Then
                                                e.Cancel = True
                                                Dim objAdv As New Tools.AdvertenciaForm
                                                objAdv.mensaje = "La cantidad rebasa el monto máximo que se puede asignar a este incentivo."
                                                objAdv.ShowDialog()
                                            End If
                                        End If
                                    End If
                                Else
                                    e.Cell.Value = 0
                                    Dim objAdv As New Tools.AdvertenciaForm
                                    objAdv.mensaje = "Selecciona un motivo"
                                    objAdv.ShowDialog()
                                End If
                            ElseIf e.Cell.Column.ToString = "MontoTres" Then
                                If Not grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoTres").Value.ToString = "" Then
                                    If grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoTres").Value <> 34 And grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoTres").Value <> 20 Then
                                        Dim objMotInc As New Negocios.IncentivosBU
                                        Dim entIncentivo As New Entidades.Incentivos
                                        entIncentivo = objMotInc.buscarMotivoIncentivo(grdEmpleadoGratificacion.Rows(e.Cell.Row.Index).Cells("MotivoTres").Value)
                                        If entIncentivo.IMontoMaximo > 0 Then
                                            If e.NewValue > entIncentivo.IMontoMaximo Then
                                                e.Cancel = True
                                                Dim objAdv As New Tools.AdvertenciaForm
                                                objAdv.mensaje = "La cantidad rebasa el monto máximo que se puede asignar a este incentivo."
                                                objAdv.ShowDialog()
                                            End If
                                        End If
                                    End If
                                Else
                                    e.Cell.Value = 0
                                    Dim objAdv As New Tools.AdvertenciaForm
                                    objAdv.mensaje = "Selecciona un motivo"
                                    objAdv.ShowDialog()
                                End If
                            End If

                        End If
                    End If
                End If
                'If e.Cell.Column.ToString = "MotivoUno" Or e.Cell.Column.ToString = "MotivoDos" Or e.Cell.Column.ToString = "MotivoTres" Then
                '    Dim valor As String = e.NewValue
                '    Dim cambiar As Boolean = False
                '    For Each itemO As DataRow In dtCatMotivos.Rows
                '        If valor <> "" Then
                '            If valor = itemO.Item("moin_motivoincentivoid").ToString Then
                '                cambiar = True
                '            End If
                '        End If
                '    Next
                '    If cambiar = False Then
                '        'e.Cancel = True
                '    End If
                'End If
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub grdEmpleadoGratificacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmpleadoGratificacion.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next

    End Sub

    Private Sub grdEmpleadoGratificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEmpleadoGratificacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdEmpleadoGratificacion.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdEmpleadoGratificacion.DisplayLayout.Bands(0)
            If grdEmpleadoGratificacion.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdEmpleadoGratificacion.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdEmpleadoGratificacion.ActiveCell = nextRow.Cells(grdEmpleadoGratificacion.ActiveCell.Column)
                e.Handled = True
                grdEmpleadoGratificacion.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub


End Class