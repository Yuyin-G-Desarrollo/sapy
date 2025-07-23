Imports Tools

Public Class DeduccionRealImssForm

    Private Sub imgLogo_Click(sender As System.Object, e As System.EventArgs) Handles imgLogo.Click

    End Sub
    Private Sub lblCajaColaborador_Click(sender As System.Object, e As System.EventArgs) Handles lblDeduccionImss.Click

    End Sub

    Private Sub DeduccionRealImssForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarTabla()
    End Sub
    Public Sub llenarTabla()


        Dim deduccionesImss As New List(Of Entidades.DeduccionRealImss)
        Dim objBU As New Negocios.DeduccionRealImssBU
        deduccionesImss = objBU.DeduccionRealIms()
        For Each IMSS As Entidades.DeduccionRealImss In deduccionesImss
            AgregarFila(IMSS)
        Next
    End Sub

    Public Sub AgregarFila(ByVal Imss As Entidades.DeduccionRealImss)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = Imss.PDeduccionImssID
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Imss.PLimiteInferior
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Imss.LimiteSuperior
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Imss.PCantidad
        fila.Cells.Add(celda)

        grdDeduccionImss.Rows.Add(fila)


    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        'Me.Close()
        If MessageBox.Show("¿Esta seguro que quiere eliminar el rango de deduccion del imss ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Dim imssID As Int32 = 0



            For Each fila As DataGridViewRow In grdDeduccionImss.SelectedRows
                For Each columna As DataGridViewCell In fila.Cells
                    If (columna.OwningColumn.Name = "COLID") Then
                        imssID = CInt(columna.Value)


                    End If



                Next
            Next

            Dim objBU As New Negocios.DeduccionRealImssBU
            objBU.eliminar(imssID)



            grdDeduccionImss.Rows.Clear()
            llenarTabla()
        Else



        End If


    End Sub


    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim Deduccion As New Entidades.DeduccionRealImss

        Dim objimssBU As New Negocios.DeduccionRealImssBU

        For fila = 0 To grdDeduccionImss.Rows.Count - 1

            '

            Dim superior As Double
            superior = CDbl(grdDeduccionImss.Rows(fila).Cells("ColLimiteSuperior").Value)

            Dim Inferior = CDbl(grdDeduccionImss.Rows(fila).Cells("ColLimiteInferior").Value)

            Dim Cantidad = CDbl(grdDeduccionImss.Rows(fila).Cells("ColCantidad").Value)

            Dim id = CDbl(grdDeduccionImss.Rows(fila).Cells("COLID").Value)

            Deduccion.PCantidad = Cantidad

            Deduccion.PLimiteInferior = Inferior
            Deduccion.PLimiteSuperior = superior


            Deduccion.PDeduccionImssID = id



            If fila > 0 Then


                Dim superiorDos As Double
                superiorDos = CDbl(grdDeduccionImss.Rows(fila - 1).Cells("ColLimiteSuperior").Value)

                Dim InferiorDos = CDbl(grdDeduccionImss.Rows(fila - 1).Cells("ColLimiteInferior").Value)

                Dim CantidadDos = CDbl(grdDeduccionImss.Rows(fila - 1).Cells("ColCantidad").Value)


                If Deduccion.PLimiteInferior > superiorDos Then
                    'Else
                    '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                    '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                    '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral

                    If grdDeduccionImss.Rows.Count > 0 Then

                        If Deduccion.LimiteInferior < Deduccion.LimiteSuperior Then

                            'Else
                            '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                            '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                            '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral



                            If Deduccion.PLimiteInferior > grdDeduccionImss.Rows.Count - 2 Then
                                If Deduccion.PDeduccionImssID = 0 Then

                                    objimssBU.AltasImss(Deduccion)


                                Else
                                    objimssBU.EditarImss(Deduccion)

                                End If
                            End If
                        End If
                    End If
                    'Else



                End If

            Else


                'End If


                Dim superiorDoss As Double
                superiorDoss = CDbl(grdDeduccionImss.Rows(fila).Cells("ColLimiteSuperior").Value)

                Dim InferiorDoss = CDbl(grdDeduccionImss.Rows(fila).Cells("ColLimiteInferior").Value)

                Dim CantidadDoss = CDbl(grdDeduccionImss.Rows(fila).Cells("ColCantidad").Value)


                'If Deduccion.PLimiteInferior > superiorDoss Then

                If grdDeduccionImss.Rows.Count > 0 Then

                    If Deduccion.LimiteInferior < Deduccion.LimiteSuperior Then
                        'Else
                        '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                        '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                        '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral



                        'If Deduccion.PLimiteInferior > grdDeduccionImss.Rows.Count - 2 Then
                        If Deduccion.PDeduccionImssID = 0 Then

                            objimssBU.AltasImss(Deduccion)


                        Else
                            objimssBU.EditarImss(Deduccion)

                        End If

                    End If
                End If
            End If
            'End If
        Next

        If grdDeduccionImss.Rows.Count > 1 Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "REGISTRO GUARDADO" & vbCrLf & " * los campos en rojo son incorrectos"
            mensajeExito.Show()

        End If

    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        grdDeduccionImss.Rows.Clear()
        llenarTabla()
    End Sub
End Class