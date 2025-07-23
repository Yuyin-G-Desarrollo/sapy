Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmMapaPlantaCapacidad

    Public Sub eliminarSimulacion()
        If cmbFoliosSimulacion.SelectedIndex > 0 Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Una vez eliminada la simulación ya no será posible recuperar la información." + vbCrLf + " ¿Está seguro de eliminar la simulación " + cmbFoliosSimulacion.Text + "?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objSimBU As New Negocios.SimulacionBU
                Dim item As New Object
                item = cmbFoliosSimulacion.SelectedItem
                objSimBU.eliminarSimulacion(item("ProcSimMae_ProcSimuladorID"), item("sprf_folio"))
                llenarComboFoliosSimulacion()
                grdMapa.DataSource = Nothing
                Dim objMsnExito As New Tools.ExitoForm
                objMsnExito.mensaje = "La simulación se eliminó correctamente"
                objMsnExito.ShowDialog()
            End If
        Else
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            objMensajeAdv.mensaje = "Seleccione una simulación"
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Public Sub llenarComboFoliosSimulacion()
        Dim objSimBU As New Negocios.SimulacionBU
        Dim dt As New DataTable
        dt = objSimBU.consultaFoliosSimulacion
        If dt.Rows.Count > 0 Then
            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbFoliosSimulacion.DataSource = dt
            cmbFoliosSimulacion.DisplayMember = "Descripcion"
            cmbFoliosSimulacion.ValueMember = "sprf_simulacionFolioId"
        End If
    End Sub

    Public Sub consultaSimulacionMaestro()
        Dim objBU As New Negocios.SimulacionBU
        Dim dt As New DataTable
        dt = objBU.consultaSimulacionMaestro
        If dt.Rows.Count > 0 Then
            lblSimulacionMaestro.Text = dt.Rows(0).Item("ProcSimMae_ProcSimuladorID").ToString
        End If
    End Sub

    Private Sub LlenarComboNaves()
        Try
            Dim obj As New Framework.Negocios.NavesBU
            Dim dtNaves As New DataTable
            dtNaves = obj.TablaDeNavesAuxiliares
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            With cmbNaves
                .DataSource = dtNaves
                .DisplayMember = "nave_nombre"
                .ValueMember = "id_"
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub llenarMapa()
        Dim objBU As New Negocios.ProgramasBU
        Dim anioInicio As Int32 = 0
        Dim anioFin As Int32 = 0
        Dim dt As New DataTable
        Me.Cursor = Cursors.WaitCursor
        anioInicio = numAnioInicio.Value
        anioFin = numAnioFin.Value
        Dim idNave As Int32 = 0
        Dim ordenamiento As Int32 = 1

        If cmbNaves.SelectedIndex > 0 Then
            idNave = cmbNaves.SelectedValue
        End If
        If rdoAlfabetico.Checked = True Then
            ordenamiento = 1
        ElseIf rdoPersonalizado.Checked = True Then
            ordenamiento = 2
        ElseIf rdoCreacion.Checked = True Then
            ordenamiento = 3
        End If

        If chkMapaSimulacion.Checked = True Then
            Dim item As New Object
            item = cmbFoliosSimulacion.SelectedItem
            dt = objBU.consultaMapaSimulacionSegmentado(anioInicio, anioFin, numSemanaInicio.Value, numSemanaFin.Value, idNave, chkPedidos.Checked, chkBloqueo.Checked, ordenamiento, item("ProcSimMae_ProcSimuladorID"), item("sprf_folio"))
        Else
            dt = objBU.consultaMapaSegmentado(anioInicio, anioFin, numSemanaInicio.Value, numSemanaFin.Value, idNave, chkPedidos.Checked, chkBloqueo.Checked, ordenamiento)
        End If

        If dt.Rows.Count > 0 Then
            'Dim index As Int32 = 0
            'For d As Int32 = dt.Rows.Count - 1 To 0 Step -1
            '    If dt.Rows(d).Item("Tipo").ToString = "Capacidad" Then
            '        index = dt.Rows.IndexOf(dt.Rows(d))
            '        If dt.Rows(index + 1).Item("Tipo").ToString <> "Pares" Then
            '            Dim rowN As DataRow
            '            rowN = dt.NewRow
            '            For i = 0 To dt.Columns.Count - 1
            '                If dt.Rows(d).Item(i).ToString <> "" Then
            '                    rowN.Item(i) = dt.Rows(d).Item(i).ToString
            '                Else
            '                    rowN.Item(i) = "0"
            '                End If

            '            Next
            '            For i = 1 To 52
            '                rowN.Item("S" + i.ToString) = "0"
            '            Next
            '            rowN.Item("Tipo") = "Pares"
            '            dt.Rows.InsertAt(rowN, index + 1)

            '        End If
            '    End If
            'Next
            grdMapa.DataSource = dt
            disenioGrid()
        Else
            grdMapa.DataSource = Nothing
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Function validarRangos() As Boolean
        If numAnioFin.Value < numAnioInicio.Value Or (numAnioFin.Value = numAnioInicio.Value And numSemanaFin.Value < numSemanaInicio.Value) Then
            Return False
        End If
        Dim diferencia As Int32 = 0
        diferencia = numAnioFin.Value - numAnioInicio.Value
        If diferencia > 1 Then
            Return False
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        Dim objBU As New Negocios.ProgramasBU
        Dim dtColores As New DataTable

        Dim index As Int32 = 0
        Dim capacidad As Int32 = 0
        Dim pares As Int32 = 0

        Dim columnas As Int32 = grdMapa.DisplayLayout.Bands(0).Columns.Count - 1

        For Each rowGrd As UltraGridRow In grdMapa.Rows
            For i = 7 To columnas
                If rowGrd.Cells(i).Value.ToString.Trim = "" Then
                    rowGrd.Cells(i).Value = 0
                End If
            Next
        Next

        If numAnioInicio.Value = numAnioFin.Value Then
            For Each row As UltraGridRow In grdMapa.Rows
                If row.Cells("Tipo").Value.ToString = "Porcentaje" Then
                    index = grdMapa.Rows.IndexOf(row)
                    For i As Int32 = numSemanaInicio.Value To numSemanaFin.Value
                        capacidad = grdMapa.Rows(index - 2).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        pares = grdMapa.Rows(index - 1).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        If capacidad > 0 And pares > 0 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = (CDbl((pares / capacidad) * 100).ToString("N2")).ToString + " %"
                        Else
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = "0 %"
                        End If
                    Next
                ElseIf row.Cells("Tipo").Value.ToString = "Restante" Then
                    index = grdMapa.Rows.IndexOf(row)
                    For i As Int32 = numSemanaInicio.Value To numSemanaFin.Value
                        capacidad = grdMapa.Rows(index - 3).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        pares = grdMapa.Rows(index - 2).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        If capacidad > 0 And pares > 0 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = (capacidad - pares).ToString("N0")
                        Else
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = capacidad.ToString("N0")
                        End If
                    Next
                Else
                    For i As Int32 = numSemanaInicio.Value To numSemanaFin.Value
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = CInt(row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value).ToString("N0")
                    Next
                End If
            Next

        ElseIf numAnioInicio.Value < numAnioFin.Value Then
            For Each row As UltraGridRow In grdMapa.Rows
                If row.Cells("Tipo").Value.ToString = "Porcentaje" Then
                    index = grdMapa.Rows.IndexOf(row)
                    For i As Int32 = numSemanaInicio.Value To 52
                        capacidad = grdMapa.Rows(index - 2).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        pares = grdMapa.Rows(index - 1).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        If capacidad > 0 And pares > 0 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = (CDbl((pares / capacidad) * 100).ToString("N2")).ToString + " %"
                        Else
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = "0 %"
                        End If
                    Next


                    For j As Int32 = 1 To numSemanaFin.Value
                        capacidad = grdMapa.Rows(index - 2).Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value
                        pares = grdMapa.Rows(index - 1).Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value
                        If capacidad > 0 And pares > 0 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value = (CDbl((pares / capacidad) * 100).ToString("N2")).ToString + " %"
                        Else
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value = "0 %"
                        End If
                    Next


                ElseIf row.Cells("Tipo").Value.ToString = "Restante" Then
                    index = grdMapa.Rows.IndexOf(row)
                    For i As Int32 = numSemanaInicio.Value To 52
                        capacidad = grdMapa.Rows(index - 3).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        pares = grdMapa.Rows(index - 2).Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value
                        If capacidad > 0 And pares > 0 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = (capacidad - pares).ToString("N0")
                        Else
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = capacidad.ToString("N0")
                        End If
                    Next

                    For j As Int32 = 1 To numSemanaFin.Value
                        capacidad = grdMapa.Rows(index - 3).Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value
                        pares = grdMapa.Rows(index - 2).Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value
                        If capacidad > 0 And pares > 0 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value = (capacidad - pares).ToString("N0")
                        Else
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value = capacidad.ToString("N0")
                        End If
                    Next
                Else
                    For i As Int32 = numSemanaInicio.Value To 52
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value = CInt(row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value).ToString("N0")
                    Next
                    For j As Int32 = 1 To numSemanaFin.Value
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value = CInt(row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value).ToString("N0")
                    Next

                End If
            Next
        End If

        dtColores = objBU.consultaRangoColoresMapa
        Dim r1 As Int32 = dtColores.Rows(1).Item(3)
        Dim r2 As Int32 = dtColores.Rows(2).Item(3)
        Dim r3 As Int32 = dtColores.Rows(3).Item(3)
        Dim r4 As Int32 = dtColores.Rows(4).Item(3)

        Dim color1 As Color = System.Drawing.Color.FromArgb(dtColores.Rows(1).Item(4).ToString)
        Dim color2 As Color = System.Drawing.Color.FromArgb(dtColores.Rows(2).Item(4).ToString)
        Dim color3 As Color = System.Drawing.Color.FromArgb(dtColores.Rows(3).Item(4).ToString)
        Dim color4 As Color = System.Drawing.Color.FromArgb(dtColores.Rows(4).Item(4).ToString)
        Dim colorBk As Color = System.Drawing.Color.FromArgb(dtColores.Rows(0).Item(4))


        With grdMapa.DisplayLayout.Bands(0)
            .Columns("prog_linpID").Hidden = True
            .Columns("nave_orden").Hidden = True
            .Columns("linp_idNave").Hidden = True
            .Columns("nave_idSicy").Hidden = True
            .Columns("ord").Hidden = True
            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("linp_nombre").Header.Caption = "Linea"
            .Columns("Tipo").Header.Caption = "Tipo"
            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("linp_nombre").CellActivation = Activation.NoEdit
            .Columns("Tipo").CellActivation = Activation.NoEdit
        End With

        Dim color As New Color
        color = Drawing.Color.Azure
        For Each row As UltraGridRow In grdMapa.Rows
            If (grdMapa.Rows.IndexOf(row) Mod 4) = 0 Then
                If color = Drawing.Color.White Then
                    color = colorBk
                Else
                    color = Drawing.Color.White
                End If
            End If
            row.Appearance.BackColor = color


            If numAnioInicio.Value = numAnioFin.Value Then
                For i As Int32 = numSemanaInicio.Value To numSemanaFin.Value
                    If row.Cells("Tipo").Value = "Capacidad" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Pares" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Porcentaje" Then
                        Dim valor As Double = CDbl(Replace(row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value.ToString, " %", ""))
                        If valor <= r1 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color1
                        ElseIf valor > r1 And valor <= r2 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color2
                        ElseIf valor > r2 And valor <= r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color3
                        ElseIf valor > r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color4
                        End If
                    ElseIf row.Cells("Tipo").Value = "Restante" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    End If
                Next
            ElseIf numAnioInicio.Value < numAnioFin.Value Then
                For i As Int32 = numSemanaInicio.Value To 52
                    If row.Cells("Tipo").Value = "Capacidad" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Pares" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Porcentaje" Then
                        Dim valor As Double = CDbl(Replace(row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value.ToString, " %", ""))
                        If valor <= r1 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color1
                        ElseIf valor > r1 And valor <= r2 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color2
                        ElseIf valor > r2 And valor <= r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color3
                        ElseIf valor > r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color4
                        End If
                    ElseIf row.Cells("Tipo").Value = "Restante" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    End If
                Next
                For j As Int32 = 1 To numSemanaFin.Value
                    If row.Cells("Tipo").Value = "Capacidad" Then
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Pares" Then
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Porcentaje" Then
                        Dim valor As Double = CDbl(Replace(row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value.ToString, " %", ""))
                        If valor <= r1 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color1
                        ElseIf valor > r1 And valor <= r2 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color2
                        ElseIf valor > r2 And valor <= r3 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color3
                        ElseIf valor > r3 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color4
                        End If
                    ElseIf row.Cells("Tipo").Value = "Restante" Then
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Column.Format = "N0"
                    End If
                Next
            End If


            If numAnioInicio.Value = numAnioFin.Value Then
                For i As Int32 = numSemanaInicio.Value To numSemanaFin.Value
                    If row.Cells("Tipo").Value = "Capacidad" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"


                    ElseIf row.Cells("Tipo").Value = "Pares" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Porcentaje" Then
                        Dim valor As Double = CDbl(Replace(row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value.ToString, " %", ""))

                        If valor <= r1 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color1
                        ElseIf valor > r1 And valor <= r2 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color2
                        ElseIf valor > r2 And valor <= r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color3
                        ElseIf valor > r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color4
                        End If


                    ElseIf row.Cells("Tipo").Value = "Restante" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    End If
                Next
            ElseIf numAnioInicio.Value < numAnioFin.Value Then
                For i As Int32 = numSemanaInicio.Value To 52
                    If row.Cells("Tipo").Value = "Capacidad" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Pares" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Porcentaje" Then
                        Dim valor As Double = CDbl(Replace(row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Value.ToString, " %", ""))

                        If valor <= r1 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color1
                        ElseIf valor > r1 And valor <= r2 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color2
                        ElseIf valor > r2 And valor <= r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color3
                        ElseIf valor > r3 Then
                            row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Appearance.BackColor = color4
                        End If


                    ElseIf row.Cells("Tipo").Value = "Restante" Then
                        row.Cells(numAnioInicio.Value.ToString + "-" + i.ToString).Column.Format = "N0"
                    End If
                Next
                For j As Int32 = 1 To numSemanaFin.Value
                    If row.Cells("Tipo").Value = "Capacidad" Then
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Column.Format = "N0"


                    ElseIf row.Cells("Tipo").Value = "Pares" Then
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Column.Format = "N0"
                    ElseIf row.Cells("Tipo").Value = "Porcentaje" Then
                        Dim valor As Double = CDbl(Replace(row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Value.ToString, " %", ""))

                        If valor <= r1 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color1
                        ElseIf valor > r1 And valor <= r2 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color2
                        ElseIf valor > r2 And valor <= r3 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color3
                        ElseIf valor > r3 Then
                            row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Appearance.BackColor = color4
                        End If


                    ElseIf row.Cells("Tipo").Value = "Restante" Then
                        row.Cells(numAnioFin.Value.ToString + "-" + j.ToString).Column.Format = "N0"
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub frmMapaPlantaCapacidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        numAnioInicio.Value = Date.Now.Year
        numAnioFin.Value = Date.Now.Year
        LlenarComboNaves()
        consultaSimulacionMaestro()
        llenarComboFoliosSimulacion()
        Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)
        If semanaActual > 52 Then
            If DatePart(DateInterval.Month, Date.Now) = 1 Then
                semanaActual = 1
            ElseIf DatePart(DateInterval.Month, Date.Now) = 12 Then
                semanaActual = 52
            End If
        End If
        numSemanaInicio.Value = semanaActual
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If validarRangos() = True Then
            If chkMapaSimulacion.Checked = True Then
                If cmbFoliosSimulacion.SelectedIndex > 0 Then
                    llenarMapa()
                Else
                    Dim advMns As New Tools.AdvertenciaForm
                    advMns.mensaje = "Seleccione un folio"
                    advMns.ShowDialog()
                End If
            Else
                llenarMapa()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Revise que los rangos sean correctos. El año final no puede ser menor al Inicial y el rango entre las fechas no debe ser mayor a un año."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        grbNaves.Height = 50
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbNaves.Height = 118
    End Sub

    Private Sub chkPedidos_CheckedChanged(sender As Object, e As EventArgs) Handles chkPedidos.CheckedChanged

    End Sub

    Private Sub chkBloqueo_CheckedChanged(sender As Object, e As EventArgs) Handles chkBloqueo.CheckedChanged

    End Sub

    Private Sub chkMapaSimulacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkMapaSimulacion.CheckedChanged
        If chkMapaSimulacion.Checked = True Then
            cmbFoliosSimulacion.Enabled = True
            btnEliminarSimulacion.Enabled = True
            lblEliminarSimulacion.Enabled = True
        Else
            llenarComboFoliosSimulacion()
            cmbFoliosSimulacion.Enabled = False
            btnEliminarSimulacion.Enabled = False
            lblEliminarSimulacion.Enabled = False
        End If
    End Sub

    Private Sub cmbFoliosSimulacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFoliosSimulacion.SelectedIndexChanged
        grdMapa.DataSource = Nothing
    End Sub

    Private Sub btnEliminarSimulacion_Click(sender As Object, e As EventArgs) Handles btnEliminarSimulacion.Click
        eliminarSimulacion()
    End Sub

    Private Sub grdMapa_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdMapa.DoubleClickCell
        If e.Cell.Row.IsFilterRow = False Then
            If IsNumeric(Replace(e.Cell.Column.ToString, "S", "")) Then
                If e.Cell.Row.Cells("Tipo").Value.ToString = "Porcentaje" Or e.Cell.Row.Cells("Tipo").Value.ToString = "Pares" Then
                    Dim frmSimConsDetalle As New frmConsultaSimuladosDetalle
                    If cmbFoliosSimulacion.SelectedIndex > 0 Then
                        frmSimConsDetalle.folio = cmbFoliosSimulacion.SelectedItem("sprf_folio")
                        frmSimConsDetalle.idSimulacion = cmbFoliosSimulacion.SelectedItem("ProcSimMae_ProcSimuladorID")
                        frmSimConsDetalle.simulacion = chkMapaSimulacion.Checked
                        frmSimConsDetalle.semana = Replace(e.Cell.Column.ToString, "S", "")
                        frmSimConsDetalle.anio = e.Cell.Row.Cells("anio").Value
                        frmSimConsDetalle.linea = e.Cell.Row.Cells("linp_nombre").Value
                        frmSimConsDetalle.idLinea = e.Cell.Row.Cells("prog_linpID").Value
                        frmSimConsDetalle.idNave = e.Cell.Row.Cells("linp_idNave").Value
                        frmSimConsDetalle.ShowDialog()
                    Else
                        If chkMapaSimulacion.Checked = False Then
                            frmSimConsDetalle.folio = 0
                            frmSimConsDetalle.idSimulacion = 0
                            frmSimConsDetalle.simulacion = False
                            frmSimConsDetalle.semana = Replace(e.Cell.Column.ToString, "S", "")
                            frmSimConsDetalle.anio = e.Cell.Row.Cells("anio").Value
                            frmSimConsDetalle.linea = e.Cell.Row.Cells("linp_nombre").Value
                            frmSimConsDetalle.idLinea = e.Cell.Row.Cells("prog_linpID").Value
                            frmSimConsDetalle.idNave = e.Cell.Row.Cells("linp_idNave").Value
                            frmSimConsDetalle.ShowDialog()
                        Else
                            Dim objAdv As New Tools.AdvertenciaForm
                            objAdv.mensaje = "Seleccione una simulación"
                            objAdv.ShowDialog()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdMapa_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMapa.InitializeLayout

    End Sub
End Class