Public Class frmCopiarSemana
    Public tablaAfectada As String
    Public id As Int32
    Public semana As String
    Public anio As Int32
    Public anioCopia As Int32
    Public semanaInicio As Int32
    Public semanaFin As Int32




    'Public Sub guardarCambios()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim objBU As New Negocios.LineasProduccionBU
    '    If tablaAfectada = "Celula" Then
    '        For i As Int32 = numSemanaInicio.Value To numSemanaFinal.Value
    '            objBU.editarCapacidadCelula(i, capacidad, id)
    '        Next
    '    ElseIf tablaAfectada = "Grupo" Then
    '        For i As Int32 = numSemanaInicio.Value To numSemanaFinal.Value
    '            objBU.editarCapacidadGrupo(i, capacidad, id)
    '        Next
    '    ElseIf tablaAfectada = "Horma" Then
    '        For i As Int32 = numSemanaInicio.Value To numSemanaFinal.Value
    '            objBU.editarCapacidadHorma(i, capacidad, id)
    '        Next
    '    ElseIf tablaAfectada = "Producto" Then
    '        For i As Int32 = numSemanaInicio.Value To numSemanaFinal.Value
    '            objBU.editarCapacidadProducto(i, capacidad, id)
    '        Next
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    Public Function colocarAnioMaximo() As Int32
        Dim objBU As New Negocios.LineasProduccionBU
        Return objBU.consultaAniosMaximoRegistrado
    End Function

    Public Function colocarAnioMinimo() As Int32
        Dim objBU As New Negocios.LineasProduccionBU
        Return objBU.consultaAniosMinimoRegistrado
    End Function

    Public Function validarMayor() As Boolean
        If numSemanaInicio.Value > numSemanaFinal.Value Then
            Return False
        End If
        Return True
    End Function

    Private Sub frmCopiarSemana_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblCelula.Text = tablaAfectada
        If tablaAfectada <> "Grupo" Then
            If semana = "Capacidad" Then
                chkCapacidadCatalogo.Checked = True
                txtSemana.Value = 1
            Else
                txtSemana.Value = semana
            End If
        Else
            chkCapacidadCatalogo.Enabled = False
            If semana = "Capacidad" Then
                txtSemana.Value = 1
            Else
                txtSemana.Value = semana
            End If
        End If

        If anio = Date.Now.Year Then
            numSemanaInicio.Minimum = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
            If semanaFin >= CInt(DatePart(DateInterval.WeekOfYear, Date.Now)) Then
                numSemanaFinal.Value = semanaFin
            Else
                numSemanaFinal.Value = 52
            End If
        Else
            numSemanaInicio.Value = semanaInicio
            numSemanaFinal.Value = semanaFin
        End If

        numAnioSeleccionado.Minimum = colocarAnioMinimo()
        numAnioSeleccionado.Maximum = colocarAnioMaximo()

        numAnioSeleccionado.Value = anio
        numAnio.Value = anio

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarMayor() = True Then
            Dim objMAdv As New Tools.ConfirmarForm
            If chkCapacidadCatalogo.Checked = True Then
                'objMAdv.mensaje = "¿Esta seguro de copiar las capacidades?"
                objMAdv.mensaje = "¿Desea copiar las capacidades de la semana origen a las semanas capturadas?"
            Else
                objMAdv.mensaje = "¿Desea copiar las capacidades desde el catálogo de " + txtSemana.Value.ToString + " a las semanas capturadas?"
            End If


            If objMAdv.ShowDialog = Windows.Forms.DialogResult.OK Then
                semanaInicio = numSemanaInicio.Value
                semanaFin = numSemanaFinal.Value
                If chkCapacidadCatalogo.Checked = True Then
                    semana = "Capacidad"
                Else
                    semana = txtSemana.Value
                End If
                anioCopia = numAnioSeleccionado.Value
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                Me.DialogResult = Windows.Forms.DialogResult.None
            End If
        Else
            Me.DialogResult = Windows.Forms.DialogResult.None
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La semana de inicio del filtro no puede ser mayor a la semana de fin."
            objMAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

 

    Private Sub txtSemana_ValueChanged(sender As Object, e As EventArgs) Handles txtSemana.ValueChanged

    End Sub

    Private Sub lblDatoSeleccionado_Click(sender As Object, e As EventArgs) Handles lblDatoSeleccionado.Click

    End Sub

    Private Sub numAnio_ValueChanged(sender As Object, e As EventArgs) Handles numAnio.ValueChanged

        If numAnio.Value = Date.Now.Year Then
            numSemanaInicio.Value = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
            numSemanaInicio.Minimum = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
            numSemanaFinal.Value = 52
            numSemanaFinal.Minimum = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
        Else
            numSemanaInicio.Minimum = 1
            numSemanaFinal.Minimum = 1
        End If
    End Sub

    Private Sub chkCapacidadCatalogo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCapacidadCatalogo.CheckedChanged
        If chkCapacidadCatalogo.Checked = True Then
            txtSemana.Enabled = False
            numAnioSeleccionado.Enabled = False
        Else
            txtSemana.Enabled = True
            numAnioSeleccionado.Enabled = True
        End If
    End Sub
End Class