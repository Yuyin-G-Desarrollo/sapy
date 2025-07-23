Imports Tools

Public Class ControlAsistenciaReplicarForm

    Private Sub ControlAsistenciaReplicarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If cmbNave.SelectedIndex > 0 Then
            Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoInicial, cmbNave.SelectedValue)
            Dim ObjBU As New Negocios.ControlAsistenciaReplicarBU
            Dim ObjENT As New Entidades.ControlAsistenciaReplicar
            ObjENT = ObjBU.FechaInicialPeriodo(cmbPeriodoInicial.SelectedValue)
            lblFechaInicio.Text = ObjENT.PfechaPeriodo
        End If
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        'Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoInicial, cmbNave.SelectedValue)
        ComboPeriodoReplicarNaveSegunAsistencia(cmbPeriodoInicial, cmbNave.SelectedValue)
        Dim ObjBU As New Negocios.ControlAsistenciaReplicarBU
        Dim ObjENT As New Entidades.ControlAsistenciaReplicar
        ObjENT = ObjBU.FechaInicialPeriodo(cmbPeriodoInicial.SelectedValue)
        lblFechaInicio.Text = ObjENT.PfechaPeriodo
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        grdListaIncapacidades.Rows.Clear()
        Dim ObjBU As New Nomina.Negocios.ControlAsistenciaReplicarBU
        Dim listaColaboradores As List(Of Entidades.ControlAsistenciaReplicar)
        Dim IDNave As Integer = 0
        Dim IDPeriodoInicial As Integer = 0
        Dim IDPeriodoFinal As Integer = 0
        Dim FechaInicio As DateTime
        IDNave = cmbNave.SelectedValue
        IDPeriodoInicial = cmbPeriodoInicial.SelectedValue
        IDPeriodoFinal = cmbPeriodoTermina.SelectedValue
        FechaInicio = lblFechaInicio.Text

        listaColaboradores = ObjBU.ListaColaboradorres(IDNave, FechaInicio)
        LlenarGrid(listaColaboradores, IDPeriodoInicial, IDPeriodoInicial)
    End Sub

    Public Sub LlenarGrid(ByVal Colaborador As List(Of Entidades.ControlAsistenciaReplicar), ByVal IDPeriodoInicial As Integer, ByVal idPeriodoFinal As Integer)
        Dim BD As String = ""
        Dim Servidor As String = ""

        For Each row As Entidades.ControlAsistenciaReplicar In Colaborador
            Dim ObjBU As New Negocios.ControlAsistenciaReplicarBU
            Dim listaIncidencias As New List(Of Entidades.ControlAsistenciaReplicar)

            Dim ColaboradorID As Integer = 0
            ColaboradorID = row.PColaborador.PColaboradorid
            listaIncidencias = ObjBU.IncidenciasCorteLista(IDPeriodoInicial, idPeriodoFinal, ColaboradorID)

            ''LLENADO DATOS NOMINA
            Dim ObjBUNomina As New Negocios.ColaboradorNominaBU
            Dim Nomina As New Entidades.ColaboradorNomina

            Nomina = ObjBUNomina.buscarColaborarNomina(ColaboradorID)
            BD = Nomina.PPatron.PpatronBD.Trim
            Servidor = Nomina.PPatron.PServidor.Trim

            For Each rowIncidencia As Entidades.ControlAsistenciaReplicar In listaIncidencias
                Dim PeriodoID As Integer = 0
                Dim RetardoMenor As Integer = 0
                Dim RetardoMayor As Integer = 0
                Dim Inasistencias As Double = 0
                Dim idRegistroCheck As Integer = 0
                Dim FechaIncidencia As DateTime = "01-01-1900"

                PeriodoID = rowIncidencia.PPeriodoID
                RetardoMayor = rowIncidencia.PCorteChecador.PRetardo_mayor
                RetardoMenor = rowIncidencia.PCorteChecador.PRetardo_menor
                Inasistencias = rowIncidencia.PCorteChecador.PInasistencia

                Dim listaIncidenciasDetalle As New List(Of Entidades.ControlAsistenciaReplicar)
                If RetardoMayor > 0 Then
                    listaIncidenciasDetalle = ObjBU.IncidenciasCorteDetalle(ColaboradorID, PeriodoID, 3)
                    For Each detalle As Entidades.ControlAsistenciaReplicar In listaIncidenciasDetalle

                        If detalle.PControlAsistenciaRegistroCheck.PCheck_manual <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_manual
                        ElseIf detalle.PControlAsistenciaRegistroCheck.PCheck_normal <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_normal
                        ElseIf detalle.PControlAsistenciaRegistroCheck.PCheck_automatico <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_automatico
                        End If
                        idRegistroCheck = detalle.PControlAsistenciaRegistroCheck.PId
                        grdListaIncapacidades.Rows.Add(grdListaIncapacidades.Rows.Count + 1, False, row.PColaborador.PNombreCompleto, "RETARDO MAYOR", FechaIncidencia.ToShortDateString, "RETARDOS", BD, Servidor, row.PColaborador.PColaboradoridNP, idRegistroCheck, 18)

                    Next
                End If

                If RetardoMenor > 0 Then
                    listaIncidenciasDetalle = ObjBU.IncidenciasCorteDetalle(ColaboradorID, PeriodoID, 2)
                    For Each detalle As Entidades.ControlAsistenciaReplicar In listaIncidenciasDetalle

                        If detalle.PControlAsistenciaRegistroCheck.PCheck_manual <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_manual
                        ElseIf detalle.PControlAsistenciaRegistroCheck.PCheck_normal <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_normal
                        ElseIf detalle.PControlAsistenciaRegistroCheck.PCheck_automatico <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_automatico
                        End If
                        idRegistroCheck = detalle.PControlAsistenciaRegistroCheck.PId
                        grdListaIncapacidades.Rows.Add(grdListaIncapacidades.Rows.Count + 1, False, row.PColaborador.PNombreCompleto, "RETARDO MENOR", FechaIncidencia.ToShortDateString, "RETARDOS", BD, Servidor, row.PColaborador.PColaboradoridNP, idRegistroCheck, 18)

                    Next
                End If

                If Inasistencias > 0 Then
                    listaIncidenciasDetalle = ObjBU.IncidenciasCorteDetalle(ColaboradorID, PeriodoID, 0)
                    For Each detalle As Entidades.ControlAsistenciaReplicar In listaIncidenciasDetalle

                        If detalle.PControlAsistenciaRegistroCheck.PCheck_manual <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_manual
                        ElseIf detalle.PControlAsistenciaRegistroCheck.PCheck_normal <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_normal
                        ElseIf detalle.PControlAsistenciaRegistroCheck.PCheck_automatico <> "01-01-1900" Then
                            FechaIncidencia = detalle.PControlAsistenciaRegistroCheck.PCheck_automatico
                        End If
                        idRegistroCheck = detalle.PControlAsistenciaRegistroCheck.PId
                        Dim incapacidad As Boolean = False
                        incapacidad = ValidarIncapacidad(ColaboradorID, FechaIncidencia, FechaIncidencia)
                        If incapacidad = False Then
                            grdListaIncapacidades.Rows.Add(grdListaIncapacidades.Rows.Count + 1, False, row.PColaborador.PNombreCompleto, "INASISTENCIA", FechaIncidencia.ToShortDateString, "FALTA INJUSTIFICADA", BD, Servidor, row.PColaborador.PColaboradoridNP, idRegistroCheck, 15)
                        End If
                    Next
                End If


            Next
        Next

        If BD <> "" And Servidor <> "" Then
            Dim tablaIncidencias As New List(Of Entidades.Incapacidades)
            Dim objIncidenciasBU As New Negocios.IncapacidadesReplicarBU
            Dim ent As New Entidades.IncapacidadesReplicar
            tablaIncidencias = objIncidenciasBU.TipoIncidenciaLista(BD.Trim, Servidor.Trim)

            tablaIncidencias.Insert(0, New Entidades.Incapacidades)


            With clmTipoIncidencia
                .DataSource = tablaIncidencias
                .DisplayMember = "PIncidenciaDescripcionNP"
                .ValueMember = "PIncidenciaIDNP"
            End With

        End If
        ValidarCampos()


    End Sub



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If grdListaIncapacidades.Rows.Count > 0 Then
            Dim contadorTrue As Integer = 0
            For Each row As DataGridViewRow In grdListaIncapacidades.Rows
                contadorTrue += 1
                Exit For
            Next

            If contadorTrue > 0 Then
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "¿ Está seguro de querer replicar los seleccionados? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " despues del guardado."
                If mensajeExito.ShowDialog = DialogResult.OK Then
                    Guardar()

                    grdListaIncapacidades.Rows.Clear()
                    Dim ObjBU As New Nomina.Negocios.ControlAsistenciaReplicarBU
                    Dim listaColaboradores As List(Of Entidades.ControlAsistenciaReplicar)
                    Dim IDNave As Integer = 0
                    Dim IDPeriodoInicial As Integer = 0
                    Dim IDPeriodoFinal As Integer = 0
                    Dim FechaInicio As DateTime
                    IDNave = cmbNave.SelectedValue
                    IDPeriodoInicial = cmbPeriodoInicial.SelectedValue
                    IDPeriodoFinal = cmbPeriodoTermina.SelectedValue
                    FechaInicio = lblFechaInicio.Text

                    listaColaboradores = ObjBU.ListaColaboradorres(IDNave, FechaInicio)
                    LlenarGrid(listaColaboradores, IDPeriodoInicial, IDPeriodoFinal)
                    ''Que vuelva a cargar
                End If
            End If
        End If
    End Sub


    Public Sub Guardar()
        Try


            For Each row As DataGridViewRow In grdListaIncapacidades.Rows
                If row.Cells("clmReplicar").Value = True Then
                    Dim ObjBU As New Negocios.IncapacidadesReplicarBU
                    Dim ObjEntRep As New Entidades.IncapacidadesReplicar
                    Dim idTipoIncidencia As Integer = 0
                    Dim BD As String = ""
                    Dim servidor As String = ""
                    Dim idRegistroCheck As Integer = 0
                    ''

                    Dim datos As New Entidades.Colaborador
                    datos.PColaboradoridNP = row.Cells("clmidColaboradorNP").Value
                    If row.Cells("clmIncidenciaNP").Value <> "" Then
                        If IsNothing(row.Cells("clmTipoIncidencia").Value) Then
                            idTipoIncidencia = row.Cells("clmIDIncidenciaNP").Value
                        End If
                        If Not IsNothing(row.Cells("clmTipoIncidencia").Value) Then
                            idTipoIncidencia = row.Cells("clmTipoIncidencia").Value
                        End If
                    Else
                        idTipoIncidencia = row.Cells("clmTipoIncidencia").Value
                    End If

                    ''idTipoIncidencia = row.Cells("clmTipoIncidencia").Value

                    Dim Incapacidad As New Entidades.Incapacidades
                    Incapacidad.PIncidenciaIDNP = idTipoIncidencia
                    Incapacidad.PIncapacidadFechaInicio = row.Cells("clmFechaIncidencia").Value

                    BD = row.Cells("clmDataSource").Value
                    servidor = row.Cells("clmServidor").Value
                    Dim periodo As New Entidades.IncapacidadesReplicar
                    periodo = ObjBU.PeriodoIncapacidad(row.Cells("clmFechaIncidencia").Value, BD, servidor.Trim)

                    Dim idperiodo As Integer = periodo.PIncapacidades.PIncapacidadPeriodo
                    Incapacidad.PIncapacidadPeriodo = idperiodo

                    ObjEntRep.PColaborador = datos
                    ObjEntRep.PIncapacidades = Incapacidad

                    Dim idTarjeta As Integer = 0
                    Incapacidad.PTarjetaIncapacidadID = idTarjeta
                    ObjEntRep.PIncapacidades = Incapacidad

                    If idTipoIncidencia > 0 Then
                        ObjBU.ReplicarIncapacidadesInsert2(ObjEntRep, BD.Trim, servidor.Trim)

                        Dim ObjBUCheck As New Negocios.ControlAsistenciaReplicarBU
                        idRegistroCheck = row.Cells("clmidRegistroCheck").Value
                        ''Actualizar campo replicar
                        ObjBUCheck.ActualizarReplicar(idRegistroCheck)
                    End If



                End If
            Next
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Replicado."
            mensajeExito.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbPeriodoTermina_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriodoTermina.DropDownClosed
        Dim ObjBU As New Negocios.ControlAsistenciaReplicarBU
        Dim ObjENT As New Entidades.ControlAsistenciaReplicar

        ObjENT = ObjBU.FechaInicialPeriodo(cmbPeriodoTermina.SelectedValue)
        lblFechaInicio.Text = ObjENT.PfechaPeriodo
    End Sub

    Public Function ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjEnt As New Entidades.Incapacidades
        Dim ValidarIncapacidadExistene As Boolean = False
        ObjEnt = ObjBU.ValidarIncapacidad(ColaboradorID, FechaInicio, FechaFin)
        ValidarIncapacidadExistene = ObjEnt.PValidarIncapacidad
        Return ValidarIncapacidadExistene
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdListaIncapacidades.Rows.Clear()
        cmbNave.SelectedIndex = 0
        cmbPeriodoInicial.SelectedIndex = 0

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 113
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 44
    End Sub

    Private Sub SeleccionarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarTodosToolStripMenuItem.Click

        For Each row As DataGridViewRow In grdListaIncapacidades.Rows
            row.Cells("clmReplicar").Value = True
        Next
    End Sub


    Private Sub DeseleccionarTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeseleccionarTodosToolStripMenuItem.Click
        For Each row As DataGridViewRow In grdListaIncapacidades.Rows
            row.Cells("clmReplicar").Value = False
        Next
    End Sub

    Public Sub ValidarCampos()
        For Each row As DataGridViewRow In grdListaIncapacidades.Rows
            If row.Cells("clmServidor").Value = "" Or row.Cells("clmDataSource").Value = "" Then
                row.DefaultCellStyle.BackColor = Color.Salmon
                row.Cells("clmReplicar").ReadOnly = True
            Else
                row.Cells("clmReplicar").ReadOnly = False
            End If
            If row.Cells("clmidColaboradorNP").Value = 0 Then
                row.Cells("clmReplicar").ReadOnly = True
                row.DefaultCellStyle.BackColor = Color.LightSalmon
            Else
                row.Cells("clmReplicar").ReadOnly = False
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub


    Public Shared Function ComboPeriodoReplicarNaveSegunAsistencia(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal naveID As Int32) As System.Windows.Forms.ComboBox

        Dim comboPeriodosSegunNave As New ComboBox
        comboPeriodosSegunNave = comboEntrada
        Dim tablaPeriodosSegunNave As New DataTable
        Dim objPeriodosSegunNave As New Nomina.Negocios.ControlAsistenciaReplicarBU
        tablaPeriodosSegunNave = objPeriodosSegunNave.PeriodosReplicar(naveID)
        comboPeriodosSegunNave.DataSource = tablaPeriodosSegunNave
        comboPeriodosSegunNave.DisplayMember = "pnom_Concepto"
        comboPeriodosSegunNave.ValueMember = "pnom_PeriodoNomId"

        Return comboPeriodosSegunNave

    End Function





End Class