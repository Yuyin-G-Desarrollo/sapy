Imports Tools

Public Class IncapacidadesReplicarForm

    Private Sub IncapacidadesReplicarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Controles.ComboPatrones(cmbPatrones)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_LIST_INCA", "NOM_INCA_PATR") Then
            cmbPatrones.Visible = True
            lblPatrones.Visible = True
        End If

        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim patronID As Integer = 0
        grdListaIncapacidades.Rows.Clear()
        Dim estamal As Boolean = False
        If cmbNave.SelectedIndex = 0 Then
            lblNave.ForeColor = Color.Red
            estamal = True
            If cmbPatrones.SelectedIndex > 0 Then
                lblPatrones.ForeColor = Color.Black
                lblNave.ForeColor = Color.Black
                estamal = False
            Else
                lblPatrones.ForeColor = Color.Red
                estamal = True
            End If


        Else
            lblNave.ForeColor = Color.Black
            lblPatrones.ForeColor = Color.Black
        End If

        If cmbPatrones.SelectedIndex > 0 Then
            patronID = cmbPatrones.SelectedValue
        End If


        If estamal = False Then
            ListaIncapacidadesFiltro(cmbNave.SelectedValue, "", "FALSE", patronID, dtpFechaInicio.Value, dtpFechaFin.Value)
        End If
    End Sub

    Public Sub ListaIncapacidadesFiltro(ByVal NaveID As Integer, Colaborador As String, Estatus As String, ByVal patronid As Integer, ByVal fechaInicio As DateTime, ByVal fechafin As DateTime)
        Dim ListaIncapacidades As New List(Of Entidades.Incapacidades)
        Dim ObjBU As New Negocios.IncapacidadesBU
        Dim ObjDA As New Entidades.Incapacidades
        Dim BD As String = ""
        Dim servidor As String = ""
        Dim colaboradorID As Integer = 0

        ListaIncapacidades = ObjBU.ListaIncapacidadesFiltro(NaveID, Colaborador, Estatus, patronid, fechaInicio, fechafin)

        For Each fila As Entidades.Incapacidades In ListaIncapacidades
            ''LLENADO DATOS NOMINA
            Dim ObjBUNomina As New Negocios.ColaboradorNominaBU
            Dim Nomina As New Entidades.ColaboradorNomina
            colaboradorID = fila.PColaborador.PColaboradorid
            Nomina = ObjBUNomina.buscarColaborarNomina(colaboradorID)
            BD = Nomina.PPatron.PpatronBD.Trim
            servidor = Nomina.PPatron.PServidor.Trim
            Dim RamoSeguro As String = ""
            Dim TipoRiesgo As String = ""
            Dim TipoIncidenciaNP As String = ""
            Dim IDTipoIncicendiaNP As Integer = 0
            RamoSeguro = fila.PRamoSeguroDescripcion
            TipoRiesgo = fila.PTipoRiesgoDescripcion
            If RamoSeguro = "MATERNIDAD" Then
                TipoIncidenciaNP = "INCAPACIDAD POR MATERNIDAD"
                IDTipoIncicendiaNP = 13
            ElseIf RamoSeguro = "ENFERMEDAD GENERAL" Then
                TipoIncidenciaNP = "ENF. GRAL/ACC. FUERA TRAB."
                IDTipoIncicendiaNP = 11
            ElseIf RamoSeguro = "RIESGO DE TRABAJO" Then

                If TipoRiesgo = "ACCIDENTE DE TRABAJO" Then
                    TipoIncidenciaNP = "ACCIDENTE DE TRABAJO."
                    IDTipoIncicendiaNP = 9
                ElseIf TipoRiesgo = "ACCIDENTE DE TRAYECTO" Then
                    TipoIncidenciaNP = "ACCIDENTE DE TRAYECTO"
                    IDTipoIncicendiaNP = 10
                End If


            End If

            grdListaIncapacidades.Rows.Add( _
            fila.PIncapacidadID, _
            grdListaIncapacidades.Rows.Count + 1, _
            False, _
            fila.PColaborador.PNombre, _
            fila.PIncapacidadFolio, _
            fila.PIncapacidadFechaInicio.ToShortDateString, _
            fila.PIncapacidadFechaFin.ToShortDateString, _
            fila.PIncapacidadDiasAutorizados, _
            fila.PRamoSeguroDescripcion, _
            fila.PTipoRiesgoDescripcion, _
            fila.PControlIncapacidadDescripcion, _
            fila.PSecuelaDescripcion, _
            fila.PTipoMaternidadDescripcion, _
            fila.PIncapacidadDescripcion, _
            TipoIncidenciaNP,
            fila.PRamoDelSeguroNP, _
            fila.PTipoMaternidadNP, _
            fila.PTipoRiesgoNP, _
            fila.PColaborador.PColaboradoridNP, _
            BD, _
            servidor, _
            IDTipoIncicendiaNP, _
            fila.PControlIncapacidadIDNP, _
            fila.PSecuelaIDNP _
            )

        Next

        If BD <> "" And servidor <> "" Then


            Dim tablaIncidencias As New List(Of Entidades.Incapacidades)
            Dim objIncidenciasBU As New Negocios.IncapacidadesReplicarBU
            Dim ent As New Entidades.IncapacidadesReplicar
            tablaIncidencias = objIncidenciasBU.TipoIncidenciaLista(BD.Trim, servidor.Trim)

            tablaIncidencias.Insert(0, New Entidades.Incapacidades)
            'If tablaIncidencias.Count > 0 Then
            '    columna.DataSource = tablaIncidencias
            '    columna.DisplayMember = "PIncidenciaDescripcionNP"
            '    columna.ValueMember = "PIncidenciaIDNP"
            'End If
            Dim columna As New DataGridViewComboBoxColumn

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
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿ Está seguro de querer replicar los seleccionados? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " despues del guardado."
            If mensajeExito.ShowDialog = DialogResult.OK Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

                Guardar()
                grdListaIncapacidades.Rows.Clear()
                Dim patronID As Integer = 0
                If cmbPatrones.SelectedIndex > 0 Then
                    patronID = cmbPatrones.SelectedValue
                End If

                ListaIncapacidadesFiltro(cmbNave.SelectedValue, "", "FALSE", patronID, dtpFechaInicio.Value, dtpFechaFin.Value)
                Me.Cursor = System.Windows.Forms.Cursors.Default
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
                    Dim diasAutorizados As Integer = 0
                    ''
                    ''ID Colaborador NP
                    Dim datos As New Entidades.Colaborador
                    datos.PColaboradoridNP = row.Cells("clmIdColaboradorNP").Value

                    If row.Cells("clmIncicendiaNP").Value <> "" Then
                        If IsNothing(row.Cells("clmTipoIncidencia").Value) Then
                            idTipoIncidencia = row.Cells("clmIncidenciaNPID").Value
                        End If

                        If Not IsNothing(row.Cells("clmTipoIncidencia").Value) Then
                            idTipoIncidencia = row.Cells("clmIncidenciaNPID").Value
                        End If
                    Else
                        idTipoIncidencia = row.Cells("clmIncidenciaNPID").Value
                    End If

                    Dim Incapacidad As New Entidades.Incapacidades
                    Incapacidad.PIncidenciaIDNP = idTipoIncidencia
                    Incapacidad.PIncapacidadFolio = row.Cells("clmFolio").Value
                    Incapacidad.PIncapacidadDiasAutorizados = row.Cells("clmDiasAutorizados").Value

                    Incapacidad.PIncapacidadFechaInicio = row.Cells("clmFechaInicio").Value
                    Incapacidad.PIncapacidadFechaFin = row.Cells("clmFechaFin").Value
                    Incapacidad.PIncapacidadDescripcion = row.Cells("clmDescripcion").Value

                    If row.Cells("clmControlIncapacidadNPID").Value.ToString <> "" Then
                        Incapacidad.PControlIncapacidadIDNP = row.Cells("clmControlIncapacidadNPID").Value
                    Else
                        Incapacidad.PControlIncapacidadIDNP = 0
                    End If

                    If row.Cells("clmIncapacidadSeucelaNPID").Value.ToString <> "" Then
                        Incapacidad.PSecuelaIDNP = row.Cells("clmIncapacidadSeucelaNPID").Value
                    Else
                        Incapacidad.PSecuelaIDNP = 0
                    End If


                    If row.Cells("clmRamoSeguroNP").Value <> "" Then
                        Incapacidad.PRamoDelSeguroNP = row.Cells("clmRamoSeguroNP").Value
                    Else
                        Incapacidad.PRamoDelSeguroNP = ""
                    End If

                    If row.Cells("clmTipoRiesgoNP").Value <> "" Then
                        Incapacidad.PTipoRiesgoNP = row.Cells("clmTipoRiesgoNP").Value
                    Else
                        Incapacidad.PTipoRiesgoNP = ""
                    End If

                    If row.Cells("clmTipoMaternidadNP").Value <> "" Then
                        Incapacidad.PRamoDelSeguroNP = row.Cells("clmTipoMaternidadNP").Value
                        Incapacidad.PTipoMaternidadNP = "1"
                    Else
                        Incapacidad.PTipoMaternidadNP = "0"
                    End If

                    BD = row.Cells("clmDataSource").Value
                    servidor = row.Cells("clmServidor").Value
                    Dim periodo As New Entidades.IncapacidadesReplicar
                    periodo = ObjBU.PeriodoIncapacidad(row.Cells("clmFechaInicio").Value, BD, servidor)
                    Dim idperiodo As Integer = periodo.PIncapacidades.PIncapacidadPeriodo
                    Incapacidad.PIncapacidadPeriodo = idperiodo

                    ObjEntRep.PColaborador = datos
                    ObjEntRep.PIncapacidades = Incapacidad

                    ObjBU.ReplicarIncapacidadesInsert(ObjEntRep, BD.Trim, servidor)

                    Dim idTarjetaIncapacidad As New Entidades.IncapacidadesReplicar
                    idTarjetaIncapacidad = ObjBU.UltimaIncapacidad(BD.Trim, servidor)
                    Dim idTarjeta As Integer = idTarjetaIncapacidad.PIncapacidades.PTarjetaIncapacidadID
                    Incapacidad.PTarjetaIncapacidadID = idTarjeta
                    ObjEntRep.PIncapacidades = Incapacidad

                    Dim fechai As DateTime = row.Cells("clmFechaInicio").Value
                    Dim FechaF As DateTime = row.Cells("clmFechaFin").Value
                    diasAutorizados = (FechaF - fechai).TotalDays
                    diasAutorizados += 1

                    While diasAutorizados > 0
                        ObjBU.ReplicarIncapacidadesInsert2(ObjEntRep, BD.Trim, servidor)
                        fechai = DateAdd(DateInterval.Day, 1, fechai)
                        Incapacidad.PIncapacidadFechaInicio = fechai

                        ObjEntRep.PIncapacidades = Incapacidad
                        diasAutorizados -= 1
                    End While
                    ObjBU.ActualizarReplicar(row.Cells("clmIncapacidadID").Value)
                End If

            Next
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Colaborador Replicado."
            mensajeExito.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 44
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdListaIncapacidades.Rows.Clear()
        cmbNave.SelectedIndex = 0
        cmbPatrones.SelectedIndex = 0
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        lblNave.ForeColor = Color.Black
        lblPatrones.ForeColor = Color.Black
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 113
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
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
            If row.Cells("clmIdColaboradorNP").Value = 0 Then
                row.Cells("clmReplicar").ReadOnly = True
                row.DefaultCellStyle.BackColor = Color.LightSalmon
            Else
                row.Cells("clmReplicar").ReadOnly = False
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub



End Class