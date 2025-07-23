Imports Tools

Public Class RangoSubsidioEmpleoForm

    Private Sub RangoSubsidioEmpleoForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        llenarTabla()
    End Sub
    Public Sub llenarTabla()


        Dim Subsidio As New List(Of Entidades.RangoSubsidioEmpleo)
        Dim objBU As New Negocios.RangoSubsidioEmpleoBU
        Subsidio = objBU.SubsidioEmpleo()
        For Each Rango As Entidades.RangoSubsidioEmpleo In Subsidio
            AgregarFila(Rango)
        Next
    End Sub

    Public Sub AgregarFila(ByVal Rango As Entidades.RangoSubsidioEmpleo)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = Rango.PSubsidioID
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Rango.PLimiteInferior
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Rango.LimiteSuperior
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Rango.PValor
        fila.Cells.Add(celda)

        grdSubsidioempleo.Rows.Add(fila)


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        grdSubsidioempleo.Rows.Clear()
        llenarTabla()
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        If MessageBox.Show("¿Esta seguro que quiere eliminar el rango de subsidio de empleo ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Dim SubsidioEmpleo As Int32 = 0



            For Each fila As DataGridViewRow In grdSubsidioempleo.SelectedRows
                For Each columna As DataGridViewCell In fila.Cells
                    If (columna.OwningColumn.Name = "ColID") Then
                        SubsidioEmpleo = CInt(columna.Value)


                    End If



                Next
            Next

            Dim objBU As New Negocios.RangoSubsidioEmpleoBU
            objBU.Eliminar(SubsidioEmpleo)



            grdSubsidioempleo.Rows.Clear()
            llenarTabla()
        Else



        End If


    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim Subsidio As New Entidades.RangoSubsidioEmpleo

        Dim objBU As New Negocios.RangoSubsidioEmpleoBU

        For fila = 0 To grdSubsidioempleo.Rows.Count - 1

            '

            Dim superior As Double
            superior = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColLimiteSuperior").Value)

            Dim Inferior = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColLimiteInferior").Value)

            Dim Valor = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColValor").Value)

            Dim id = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColID").Value)

            Subsidio.PValor = Valor
            Subsidio.PLimiteInferior = Inferior
            Subsidio.PLimiteSuperior = superior
            Subsidio.PSubsidioID = id



            If fila > 0 Then


                Dim superiorDos As Double
                superiorDos = CDbl(grdSubsidioempleo.Rows(fila - 1).Cells("ColLimiteSuperior").Value)

                Dim InferiorDos = CDbl(grdSubsidioempleo.Rows(fila - 1).Cells("ColLimiteInferior").Value)

                Dim ValorDos = CDbl(grdSubsidioempleo.Rows(fila - 1).Cells("ColValor").Value)


                If Subsidio.PLimiteInferior > superiorDos Then
                    'Else
                    '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                    '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                    '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral

                    If grdSubsidioempleo.Rows.Count > 0 Then

                        If Subsidio.LimiteInferior < Subsidio.LimiteSuperior Then

                            'Else
                            '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                            '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                            '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral



                            If Subsidio.PLimiteInferior > grdSubsidioempleo.Rows.Count - 2 Then
                                If Subsidio.PSubsidioID = 0 Then

                                    objBU.Alta(Subsidio)


                                Else
                                    objBU.Editar(Subsidio)

                                End If
                            End If
                        End If
                    End If
                    'Else



                End If

            Else


                'End If


                Dim superiorDoss As Double
                superiorDoss = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColLimiteSuperior").Value)

                Dim InferiorDoss = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColLimiteInferior").Value)

                Dim CantidadDoss = CDbl(grdSubsidioempleo.Rows(fila).Cells("ColValor").Value)


                'If Deduccion.PLimiteInferior > superiorDoss Then

                If grdSubsidioempleo.Rows.Count > 0 Then

                    If Subsidio.LimiteInferior < Subsidio.LimiteSuperior Then
                        'Else
                        '	grdDeduccionImss.CurrentRow.Cells("ColCantidad").Style.BackColor = Color.Coral
                        '	grdDeduccionImss.CurrentRow.Cells("ColLimiteInferior").Style.BackColor = Color.Coral
                        '	grdDeduccionImss.CurrentRow.Cells("ColLimiteSuperior").Style.BackColor = Color.Coral



                        'If Deduccion.PLimiteInferior > grdDeduccionImss.Rows.Count - 2 Then
                        If Subsidio.PSubsidioID = 0 Then

                            objBU.Alta(Subsidio)


                        Else
                            objBU.Editar(Subsidio)

                        End If

                    End If
                End If
            End If
            'End If
        Next

        If grdSubsidioempleo.Rows.Count > 1 Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "REGISTRO GUARDADO" & vbCrLf & " * los campos en rojo son incorrectos"
            mensajeExito.Show()

        End If

    End Sub

End Class