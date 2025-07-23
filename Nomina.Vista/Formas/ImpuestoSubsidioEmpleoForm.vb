Imports Tools

Public Class ImpuestoSubsidioEmpleoForm

    Private Sub ImpuestoSubsidioEmpleoForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarTabla()
    End Sub
    Public Sub llenarTabla()


        Dim ImpuestoSubsidio As New List(Of Entidades.ImpuestoSubsidioEmpleo)
        Dim objBU As New Negocios.ImpuestoSubsidioEmpleoBU
        ImpuestoSubsidio = objBU.ImpuestoSubsidio()
        For Each Impuesto As Entidades.ImpuestoSubsidioEmpleo In ImpuestoSubsidio
            AgregarFila(Impuesto)
        Next
    End Sub

    Public Sub AgregarFila(ByVal Impuesto As Entidades.ImpuestoSubsidioEmpleo)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = Impuesto.PimpuestoEmpleoID
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Impuesto.PLimiteInferior
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Impuesto.PLimiteSuperior
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Impuesto.PCuotaFija
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Impuesto.PPorcentaje
        fila.Cells.Add(celda)

        grdImpuestoSubsidio.Rows.Add(fila)


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        grdImpuestoSubsidio.Rows.Clear()
        llenarTabla()

    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If MessageBox.Show("¿Esta seguro que quiere eliminar el rango de impuesto de subsidio empleo ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Dim imssID As Int32 = 0



            For Each fila As DataGridViewRow In grdImpuestoSubsidio.SelectedRows
                For Each columna As DataGridViewCell In fila.Cells
                    If (columna.OwningColumn.Name = "ColRiseId") Then
                        imssID = CInt(columna.Value)


                    End If



                Next
            Next

            Dim objBU As New Negocios.ImpuestoSubsidioEmpleoBU
            objBU.eliminar(imssID)



            grdImpuestoSubsidio.Rows.Clear()
            llenarTabla()
        Else



        End If


    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim Impuesto As New Entidades.ImpuestoSubsidioEmpleo

        Dim objSubsidioBU As New Negocios.ImpuestoSubsidioEmpleoBU

        For fila = 0 To grdImpuestoSubsidio.Rows.Count - 1

            '

            Dim superior As Double
            superior = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColLimiteSuperior").Value)
            Dim Inferior = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColLimiteInferior").Value)
            Dim Cuota = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColCuotaFija").Value)
            Dim Porcentaje = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColPorcentaje").Value)
            Dim id = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColRiseId").Value)


            Impuesto.PLimiteInferior = Inferior
            Impuesto.PLimiteSuperior = superior
            Impuesto.PCuotaFija = Cuota
            Impuesto.PPorcentaje = Porcentaje
            Impuesto.PimpuestoEmpleoID = id


            If fila > 0 Then


                Dim superiorDos As Double
                superiorDos = CDbl(grdImpuestoSubsidio.Rows(fila - 1).Cells("ColLimiteSuperior").Value)
                Dim InferiorDos = CDbl(grdImpuestoSubsidio.Rows(fila - 1).Cells("ColLimiteInferior").Value)
                Dim CuotaDos = CDbl(grdImpuestoSubsidio.Rows(fila - 1).Cells("ColCuotaFija").Value)
                Dim PorcentajeDos = CDbl(grdImpuestoSubsidio.Rows(fila - 1).Cells("ColPorcentaje").Value)

                If Impuesto.PLimiteInferior > superiorDos Then
                    'Else
                    '	grdImpuestoSubsidio.CurrentRow.Cells("ColCuotaFija").Style.BackColor = Color.Coral
                    '	grdImpuestoSubsidio.CurrentRow.Cells("ColPorcentaje").Style.BackColor = Color.Coral
                    '	grdImpuestoSubsidio.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                    '	grdImpuestoSubsidio.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral

                    If grdImpuestoSubsidio.Rows.Count > 0 Then

                        If Impuesto.LimiteInferior < Impuesto.LimiteSuperior Then

                            'Else
                            '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                            '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                            '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral


                            If Impuesto.PLimiteInferior > grdImpuestoSubsidio.Rows.Count - 2 Then
                                If Impuesto.PimpuestoEmpleoID = 0 Then

                                    objSubsidioBU.Altas(Impuesto)


                                Else
                                    objSubsidioBU.Editar(Impuesto)

                                End If
                            End If
                        End If
                    End If
                    'Else



                End If

            Else


                'End If


                Dim superiorDoss As Double
                superiorDoss = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColLimiteSuperior").Value)
                Dim InferiorDoss = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColLimiteInferior").Value)
                Dim CuotaDoss = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColCuotaFija").Value)
                Dim PorcentajeDoss = CDbl(grdImpuestoSubsidio.Rows(fila).Cells("ColPorcentaje").Value)


                'If Deduccion.PLimiteInferior > superiorDoss Then

                If grdImpuestoSubsidio.Rows.Count > 0 Then

                    If Impuesto.LimiteInferior < Impuesto.LimiteSuperior Then
                        'Else
                        '	grdImpuestoSubsidio.CurrentRow.Cells("ColCuotaFija").Style.BackColor = Color.Coral
                        '	grdImpuestoSubsidio.CurrentRow.Cells("ColPorcentaje").Style.BackColor = Color.Coral
                        '	grdImpuestoSubsidio.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                        '	grdImpuestoSubsidio.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral



                        'If Deduccion.PLimiteInferior > grdDeduccionImss.Rows.Count - 2 Then
                        If Impuesto.PimpuestoEmpleoID = 0 Then

                            objSubsidioBU.Altas(Impuesto)


                        Else
                            objSubsidioBU.Editar(Impuesto)

                        End If

                    End If
                End If
            End If
            'End If
        Next

        If grdImpuestoSubsidio.Rows.Count > 1 Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "REGISTRO GUARDADO" & vbCrLf & " * los campos en rojo son incorrectos"
            mensajeExito.Show()

        End If

    End Sub

    Private Sub grdImpuestoSubsidio_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdImpuestoSubsidio.CellContentClick

    End Sub
End Class