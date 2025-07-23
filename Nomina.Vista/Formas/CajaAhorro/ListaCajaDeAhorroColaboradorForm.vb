Imports Nomina.Negocios
Imports Entidades
Imports Stimulsoft.Report
Imports Tools

Public Class ListaCajaDeAhorroColaboradorForm
    Public nave As Entidades.Naves
    Public cajaAhorroId As Integer
    Public nombrecaja As String
    Public Colaboradorid As Int32
    Public PorcentajeSalario As Double
    Public mensaje As Boolean = True
    Dim Consecutivo As Int32
    Dim listacaja As New List(Of Entidades.Colaborador)
    Dim listacajas As New List(Of Entidades.CajaColaborador)
    Dim cambio As Boolean = 0

    Public Sub ejecutarReporteCartaCajaAhorro()
        If grdCajaColaborador.RowCount > 0 Then
            Try
                Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
                Dim dttCajaAhorro As New DataTable
                Dim dsDeduccionesCaja As New DataSet
                Dim dtDeduccionesReporte As New DataTable
                Dim dtMesesAnio As New DataTable
                Dim fila As Integer
                'Dim reporte As New StiReport
                Dim dtcolaboradoresDatos = New DataTable("dtColaboradoresDatos")
                Dim dscolaboradores As New DataSet
                Dim dtcolaboradoresRelacion = New DataTable("dtcolaboradoresRelacion")
                Dim interes As String = String.Empty

                dttCajaAhorro = objCajaAhorroBU.consultaCajaAhorroActual(nave.PNaveId)
                If dttCajaAhorro.Rows.Count > 0 Then
                    dsDeduccionesCaja.Tables.Add(dtDeduccionesReporte)
                    dsDeduccionesCaja.Tables.Add(dtMesesAnio)

                    If nave.PNaveId = 43 Or nave.PNaveId = 73 Then
                        interes = "25% hasta el 50%"
                    Else
                        interes = "25%"
                    End If



                    Dim objReporte As New Framework.Negocios.ReportesBU
                    Dim entReporte As New Entidades.Reportes
                    Dim claveReporte As String = String.Empty
                    If nave.PNaveId = 43 Or nave.PNaveId = 73 Or nave.PNaveId = 82 Then
                        claveReporte = "CARTA_CAJA_AHORRO"
                    Else
                        claveReporte = "CARTA_CAJA_AHORRO_V2"
                    End If

                    entReporte = objReporte.LeerReporteporClave(claveReporte)
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()

                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(nave.PNaveId)
                    reporte("nombreNave") = lblNaves.Text
                    reporte("NombreReporte") = "SAY: CARTA_CAJA_AHORRO.mrt"
                    reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                    reporte("interes") = interes
                    ' reporte("colaborador") = nombreColaborador

                    Dim cadenaPeriodo As String = "del " + dttCajaAhorro.Rows(0).Item("AnioInicio").ToString + " a " + dttCajaAhorro.Rows(0).Item("AnioFin").ToString
                    reporte("anios") = cadenaPeriodo

                    Dim fechainicioCA As Date = dttCajaAhorro.Rows(0).Item("caja_FechaInicial").ToString
                    Dim fechafinCA As Date = dttCajaAhorro.Rows(0).Item("caja_FechaFinal").ToString
                    Dim diaInicio As String = fechainicioCA.Day.ToString
                    Dim diaFin As String = fechafinCA.Day.ToString
                    Dim diaHoy As String = Date.Now.Day.ToString
                    Dim mesInicio As String = fechainicioCA.Month.ToString
                    Dim mesFin As String = fechafinCA.Month.ToString
                    Dim meshoy As String = Date.Now.Month.ToString
                    Dim anioInicio As String = fechainicioCA.Year.ToString
                    Dim anioFin As String = fechafinCA.Year.ToString

                    If diaInicio.Length = 1 Then
                        diaInicio = "0" + diaInicio
                    End If

                    If diaFin.Length = 1 Then
                        diaFin = "0" + diaFin
                    End If

                    If diaHoy.Length = 1 Then
                        diaHoy = "0" + diaHoy
                    End If

                    If mesInicio = "1" Then
                        mesInicio = "Enero"
                    ElseIf mesInicio = "2" Then
                        mesInicio = "Febrero"
                    ElseIf mesInicio = "3" Then
                        mesInicio = "Marzo"
                    ElseIf mesInicio = "4" Then
                        mesInicio = "Abril"
                    ElseIf mesInicio = "5" Then
                        mesInicio = "Mayo"
                    ElseIf mesInicio = "6" Then
                        mesInicio = "Junio"
                    ElseIf mesInicio = "7" Then
                        mesInicio = "Julio"
                    ElseIf mesInicio = "8" Then
                        mesInicio = "Agosto"
                    ElseIf mesInicio = "9" Then
                        mesInicio = "Septiembre"
                    ElseIf mesInicio = "10" Then
                        mesInicio = "Octubre"
                    ElseIf mesInicio = "11" Then
                        mesInicio = "Noviembre"
                    ElseIf mesInicio = "12" Then
                        mesInicio = "Diciembre"
                    End If

                    If mesFin = "1" Then
                        mesFin = "Enero"
                    ElseIf mesFin = "2" Then
                        mesFin = "Febrero"
                    ElseIf mesFin = "3" Then
                        mesFin = "Marzo"
                    ElseIf mesFin = "4" Then
                        mesFin = "Abril"
                    ElseIf mesFin = "5" Then
                        mesFin = "Mayo"
                    ElseIf mesFin = "6" Then
                        mesFin = "Junio"
                    ElseIf mesFin = "7" Then
                        mesFin = "Julio"
                    ElseIf mesFin = "8" Then
                        mesFin = "Agosto"
                    ElseIf mesFin = "9" Then
                        mesFin = "Septiembre"
                    ElseIf mesFin = "10" Then
                        mesFin = "Octubre"
                    ElseIf mesFin = "11" Then
                        mesFin = "Noviembre"
                    ElseIf mesFin = "12" Then
                        mesFin = "Diciembre"
                    End If

                    If meshoy = "1" Then
                        meshoy = "Enero"
                    ElseIf meshoy = "2" Then
                        meshoy = "Febrero"
                    ElseIf meshoy = "3" Then
                        meshoy = "Marzo"
                    ElseIf meshoy = "4" Then
                        meshoy = "Abril"
                    ElseIf meshoy = "5" Then
                        meshoy = "Mayo"
                    ElseIf meshoy = "6" Then
                        meshoy = "Junio"
                    ElseIf meshoy = "7" Then
                        meshoy = "Julio"
                    ElseIf meshoy = "8" Then
                        meshoy = "Agosto"
                    ElseIf meshoy = "9" Then
                        meshoy = "Septiembre"
                    ElseIf meshoy = "10" Then
                        meshoy = "Octubre"
                    ElseIf meshoy = "11" Then
                        meshoy = "Noviembre"
                    ElseIf meshoy = "12" Then
                        meshoy = "Diciembre"
                    End If

                    If anioInicio.Length = 1 Then
                        anioInicio = "0" + anioInicio
                    End If

                    If anioFin.Length = 1 Then
                        anioFin = "0" + anioFin
                    End If

                    reporte("comenzara") = "1. Comenzará el " + diaInicio + " de " + mesInicio + " del " + anioInicio + " al " + diaFin + " de " + mesFin + " del " + anioFin + "."
                    reporte("totalsemanas") = "2. El total de semanas a ahorrar será de " + dttCajaAhorro.Rows(0).Item("Semanas").ToString + "."
                    reporte("terminara") = mesFin + " del " + anioFin + "."
                    reporte("fechadeldia") = diaHoy + " de " + meshoy + " de " + Date.Now.Year.ToString

                    dtcolaboradoresDatos.Columns.Add("nombreColaborador")
                    dtcolaboradoresRelacion.Columns.Add("nombre")
                    For fila = 0 To grdCajaColaborador.Rows.Count - 1
                        If (grdCajaColaborador.Rows(fila).Cells(2).Selected = True) Then

                            Dim nombreColaborador As String = ""
                            nombreColaborador = grdCajaColaborador.Rows(fila).Cells(2).Value.ToString
                            'idcolaborador.Rows.Add(nombreColaborador)
                            Dim rtId As DataRow = dtcolaboradoresRelacion.NewRow
                            rtId.Item(0) = nombreColaborador
                            dtcolaboradoresRelacion.Rows.Add(rtId)
                            dtcolaboradoresDatos.Rows.Add(nombreColaborador)
                        End If
                    Next

                    dscolaboradores.Tables.Add(dtcolaboradoresDatos)
                    dscolaboradores.Tables.Add(dtcolaboradoresRelacion)

                    reporte.Dictionary.Clear()
                    reporte.RegData(dscolaboradores)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()


                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.mensaje = "Nave sin caja de ahorro."
                    objMensaje.ShowDialog()
                End If
            Catch ex As Exception
                Dim objMensaje As New Tools.AdvertenciaForm
                objMensaje.mensaje = "Vuelva a intentar generar la carta."
                objMensaje.ShowDialog()
            End Try

        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "Seleccione un colaborador."
            objMensaje.ShowDialog()
        End If
    End Sub


    Private Sub ListaCajaDeAhorroColaboradorForm_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' evento Keypress  

        ' obtener indice de la columna  
        Dim columna As Integer = grdCajaColaborador.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 8 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  

            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ".") And
            (txt.Text.Contains(".") = False) Then

                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub ListaCajaDeAhorroColaboradorForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        llenarTabla()
        grdCajaColaborador.Columns("ColConsecutivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCajaColaborador.Columns("ColMontoAcumulado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCajaColaborador.Columns("ColMontoAhorrado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Dim naves As New Entidades.Naves
        Dim caja As New Entidades.CajaAhorro

        lblIdCaja.Text = cajaAhorroId.ToString
        lblNaves.Text = nave.PNombre
        lblPeriodos.Text = nombrecaja
    End Sub

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbCajaColaborador.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbCajaColaborador.Height = 143
    End Sub
    Public Sub llenarTabla()

        Dim listacaja As New List(Of Entidades.CajaColaborador)
        Dim objBU As New Negocios.CajaColaboradorBU

        listacaja = objBU.listaCajaColaborador(txtNombre.Text, rdoSi.Checked, cajaAhorroId)
        Consecutivo = 1
        For Each caja As Entidades.CajaColaborador In listacaja
            AgregarFila(caja)
            Consecutivo += 1
        Next

    End Sub
    Public Sub llenarTablaNoAsignado(ByVal LISTA As List(Of Entidades.Colaborador))

        Consecutivo = 1
        For Each cajas As Entidades.Colaborador In LISTA
            AgregarFilas(cajas)
            Consecutivo += 1
        Next

    End Sub
    Public Sub AgregarFila(ByVal caja As Entidades.CajaColaborador)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow
        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PColaborador.PColaboradorid
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Consecutivo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PColaborador.PNombre + " " + caja.PColaborador.PApaterno + " " + caja.PColaborador.PAmaterno
        fila.Cells.Add(celda)

        Dim area As New Areas
        area = caja.PAreas

        celda = New DataGridViewTextBoxCell
        celda.Value = area.PNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PDepartamento.DNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PSalario.PCantidad
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PEstatus
        fila.Cells.Add(celda)

        Dim listacaja As New List(Of Entidades.CajaColaborador)
        Dim objBU As New Negocios.CajaColaboradorBU
        Dim acumulado As Double = 0
        listacaja = objBU.listaAcumuladoCajaAhorro(cajaAhorroId, caja.PColaborador.PColaboradorid)
        For Each dato As Entidades.CajaColaborador In listacaja
            acumulado = dato.MontoAcumulado
        Next

        celda = New DataGridViewTextBoxCell
        celda.Value = acumulado
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PMontoAhorro
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = caja.PMontoMaximoAhorrar
        fila.Cells.Add(celda)


        grdCajaColaborador.Rows.Add(fila)


    End Sub
    Public Sub AgregarFilas(ByVal cajas As Entidades.Colaborador)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = cajas.PColaboradorid.ToString
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = Consecutivo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = cajas.PNombre.ToUpper + " " + cajas.PApaterno.ToUpper + " " + cajas.PAmaterno
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = cajas.PIDepartamento.DNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = cajas.PEstatus.PAreas.PNombre.ToUpper
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = cajas.Psalario.PCantidad
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = "Nuevo"
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = 0
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = cajas.PEstatus.PMontoMaximoAhorrar
        fila.Cells.Add(celda)

        grdCajaColaborador.Rows.Add(fila)


    End Sub
    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        grdCajaColaborador.Rows.Clear()


        Dim objBU As New Negocios.CajaColaboradorBU


        If rdoSi.Checked Then
            ' entrar a los colaboradores asignados 
            listacajas = objBU.listaCajaColaborador(txtNombre.Text, rdoSi.Checked, cajaAhorroId)
            llenarTabla()
            cambio = 1
        Else
            listacaja = objBU.listaCajaColaboradoresNoAsignados(txtNombre.Text, cajaAhorroId, nave.PNaveId)
            llenarTablaNoAsignado(listacaja)
            cambio = 1
        End If

        '
    End Sub


    Private Sub grdCajaColaborador_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellValueChanged
        Try
            If listacaja.Count > 0 Then
                Dim salario As Double = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value)
                Dim montoAhorrado As Double = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value)
                Dim montoMaximo As Double = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColmontoMaximo").Value)
                PorcentajeSalario = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value) * 0.1
                Dim PorcentajeSalarioMinimo = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value) * 0.05

                Dim respuesta = ValidarMontoAhorrados(salario, montoAhorrado, montoMaximo, PorcentajeSalario, PorcentajeSalarioMinimo)
                If respuesta.Count > 0 Then
                    If respuesta.Item(0) = 0 Then
                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = respuesta.Item(1)
                        cambio = 0
                    End If
                End If

            End If

        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "Error de sistema: " + ex.ToString)

        End Try

    End Sub


    'Private Sub grdCajaColaborador_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellValueChanged
    '    Dim Advertencia As New AdvertenciaForm
    '    Try
    '        Dim salario As Double = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value)
    '        Dim montoAhorrado As Double = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value)
    '        Dim montoMaximo As Double = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColmontoMaximo").Value)
    '        PorcentajeSalario = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value) * 0.1
    '        Dim PorcentajeSalarioMinimo = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value) * 0.05

    '        If nave.PNaveId = 73 Then
    '            If montoAhorrado < PorcentajeSalarioMinimo Then
    '                Advertencia.mensaje = " El monto no supera el límite permitido, 5% del sueldo ($" + PorcentajeSalarioMinimo.ToString + ")"
    '                grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = PorcentajeSalarioMinimo
    '                Advertencia.ShowDialog()
    '            Else

    '                'If salario >= 3001 Then
    '                'If montoAhorrado > PorcentajeSalario Then
    '                If montoAhorrado > montoMaximo Then
    '                    Advertencia.mensaje = " El monto excede el límite permitido ($" + montoMaximo.ToString + ")"
    '                    grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = montoMaximo
    '                    Advertencia.ShowDialog()
    '                End If
    '                'ElseIf salario >= 2501 And salario <= 3000 Then
    '                '    If montoAhorrado > 300 Then
    '                '        Advertencia.mensaje = " El monto excede el límite permitido ($300)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 300
    '                '        Advertencia.ShowDialog()
    '                '    End If
    '                'ElseIf salario >= 2001 And salario <= 2500 Then
    '                '    If montoAhorrado > 250 Then
    '                '        Advertencia.mensaje = " El monto excede el límite permitido ($250)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 250
    '                '        Advertencia.ShowDialog()
    '                '    End If
    '                'ElseIf salario >= 1501 And salario <= 2000 Then
    '                '    If montoAhorrado > 200 Then
    '                '        Advertencia.mensaje = " El monto excede el límite permitido ($200)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 200
    '                '        Advertencia.ShowDialog()
    '                '    End If
    '                'ElseIf salario >= 1001 And salario <= 1500 Then
    '                '    If montoAhorrado > 150 Then
    '                '        Advertencia.mensaje = " El monto excede el límite permitido ($150)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 150
    '                '        Advertencia.ShowDialog()
    '                '    End If
    '                'ElseIf salario >= 700 And salario <= 1000 Then
    '                '    If montoAhorrado > 100 Then
    '                '        Advertencia.mensaje = " El monto excede el límite permitido ($100)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 100
    '                '        Advertencia.ShowDialog()
    '                '    End If
    '                'End If


    '            End If
    '        Else
    '            If nave.PNaveId = 43 Or nave.PNaveId = 82 Then
    '                Dim montoMin = salario * 0.05
    '                Dim montoMax = salario * 0.1

    '                If montoAhorrado > montoMax Then
    '                    Advertencia.mensaje = " El monto excede el límite permitido ($" + montoMax.ToString + ")"
    '                    grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = montoMax
    '                    Advertencia.ShowDialog()
    '                End If
    '                If montoAhorrado < montoMin Then
    '                    Advertencia.mensaje = " El monto no supera el límite permitido ($" + montoMin.ToString + ")"
    '                    grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = montoMin
    '                    Advertencia.ShowDialog()
    '                End If
    '            Else
    '                ''validacion monto ahorro permitido naves
    '                'If salario <= 1000 Then
    '                '    If montoAhorrado > 100 Then
    '                '        Advertencia.mensaje = " El monto excede el límite permitido ($100)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 100
    '                '        Advertencia.ShowDialog()
    '                '    End If
    '                '    If montoAhorrado < 35 Then
    '                '        Advertencia.mensaje = " El monto no supera el límite permitido ($35)"
    '                '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 35
    '                '        Advertencia.ShowDialog()
    '                '    End If

    '                If salario >= 1000 And salario <= 1500 Then
    '                    If montoAhorrado > 100 Then
    '                        Advertencia.mensaje = " El monto excede el límite permitido ($100)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 100
    '                        Advertencia.ShowDialog()
    '                    End If
    '                    If montoAhorrado < 35 Then
    '                        Advertencia.mensaje = " El monto no supera el límite permitido ($35)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 35
    '                        Advertencia.ShowDialog()
    '                    End If

    '                ElseIf salario >= 1501 And salario <= 2000 Then
    '                    If montoAhorrado > 200 Then
    '                        Advertencia.mensaje = " El monto excede el límite permitido ($200)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 200
    '                        Advertencia.ShowDialog()
    '                    End If
    '                    If montoAhorrado < 50 Then
    '                        Advertencia.mensaje = " El monto no supera el límite permitido ($50)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 50
    '                        Advertencia.ShowDialog()
    '                    End If

    '                ElseIf salario >= 2001 And salario <= 2500 Then
    '                    If montoAhorrado > 300 Then
    '                        Advertencia.mensaje = " El monto excede el límite permitido ($300)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 300
    '                        Advertencia.ShowDialog()
    '                    End If
    '                    If montoAhorrado < 75 Then
    '                        Advertencia.mensaje = " El monto no supera el límite permitido ($75)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 75
    '                        Advertencia.ShowDialog()
    '                    End If

    '                ElseIf salario >= 2501 And salario <= 3000 Then
    '                    If montoAhorrado > 400 Then
    '                        Advertencia.mensaje = " El monto excede el límite permitido ($400)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 400
    '                        Advertencia.ShowDialog()
    '                    End If
    '                    If montoAhorrado < 100 Then
    '                        Advertencia.mensaje = " El monto no supera el límite permitido ($100)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 100
    '                        Advertencia.ShowDialog()
    '                    End If

    '                ElseIf salario >= 3001 Then
    '                    If montoAhorrado > 500 Then
    '                        Advertencia.mensaje = " El monto excede el límite permitido ($500)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 500
    '                        Advertencia.ShowDialog()
    '                    End If
    '                    If montoAhorrado < 125 Then
    '                        Advertencia.mensaje = " El monto no supera el límite permitido ($125)"
    '                        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 125
    '                        Advertencia.ShowDialog()
    '                    End If
    '                End If
    '            End If
    '        End If

    '        'If salario >= 3000 Then
    '        '    If montoAhorrado > 300 Then
    '        '        Advertencia.mensaje = " El monto excede el límite permitido ($300)"
    '        '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 300
    '        '        Advertencia.ShowDialog()
    '        '    End If
    '        'ElseIf salario >= 2500 And salario < 3000 Then
    '        '    If montoAhorrado > 275 Then
    '        '        Advertencia.mensaje = " El monto excede el límite permitido ($275)"
    '        '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 275
    '        '        Advertencia.ShowDialog()
    '        '    End If
    '        'ElseIf salario >= 2000 And salario < 2500 Then
    '        '    If montoAhorrado > 250 Then
    '        '        Advertencia.mensaje = " El monto excede el límite permitido ($250)"
    '        '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 250
    '        '        Advertencia.ShowDialog()
    '        '    End If
    '        'ElseIf salario >= 1500 And salario < 2000 Then
    '        '    If montoAhorrado > 200 Then
    '        '        Advertencia.mensaje = " El monto excede el límite permitido ($200)"
    '        '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 200
    '        '        Advertencia.ShowDialog()
    '        '    End If
    '        'ElseIf salario >= 1000 And salario < 1500 Then
    '        '    If montoAhorrado > 150 Then
    '        '        Advertencia.mensaje = " El monto excede el límite permitido ($150)"
    '        '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 150
    '        '        Advertencia.ShowDialog()
    '        '    End If

    '        'ElseIf salario >= 700 And salario < 1000 Then
    '        '    If montoAhorrado > 100 Then
    '        '        Advertencia.mensaje = " El monto excede el límite permitido ($100)"
    '        '        grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 100
    '        '        Advertencia.ShowDialog()
    '        '    End If

    '        'End If

    '        'If PorcentajeSalario > 0 Then
    '        'If PorcentajeSalario < 300 Then
    '        'If (CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value) > PorcentajeSalario) Then
    '        '    Advertencia.MdiParent = MdiParent
    '        '    Advertencia.mensaje = " El monto excede el limite permitido "
    '        '    Advertencia.Show()
    '        '    grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value = 0
    '        'End If

    '        'Else
    '        '    If (CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value) > 300) Then
    '        '        Advertencia.MdiParent = MdiParent
    '        '        Advertencia.mensaje = "Monto debe ser menor a 300 "
    '        '        Advertencia.Show()
    '        '        grdCajaColaborador.Rows(e.RowIndex).Cells("ColMontoAhorrado").Value = 0
    '        '    End If

    '        'End If

    '        'If e.ColumnIndex = 8 Then
    '        '    Dim cajaAhorro As Double
    '        '    For Each row As DataGridViewRow In grdCajaColaborador.Rows
    '        '        Try
    '        '            cajaAhorro = grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value
    '        '            grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = cajaAhorro
    '        '        Catch ex As Exception

    '        '        End Try
    '        '    Next
    '        'End If

    '        'End If
    '    Catch ex As Exception
    '        'grdCajaColaborador.CurrentRow.Cells("ColMontoAhorrado").Value = 0
    '    End Try
    'End Sub







    Public Sub Insert(ByVal Index As Int32)

        Dim objCajaBU As New CajaColaboradorBU
        Dim caja As New Entidades.CajaColaborador
        Dim MontoAhorro, MontoAcumulado As Double
        Dim Status As String
        Dim IdColaborador As Int32

        IdColaborador = grdCajaColaborador.Rows(Index).Cells(0).Value
        MontoAhorro = grdCajaColaborador.Rows(Index).Cells(8).Value
        MontoAcumulado = grdCajaColaborador.Rows(Index).Cells(7).Value
        Status = grdCajaColaborador.Rows(Index).Cells(6).Value

        objCajaBU.Insert(IdColaborador, MontoAcumulado, MontoAhorro, Status)

    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        grdCajaColaborador.Rows.Clear()
        txtNombre.Text = ""
    End Sub

    Private Sub btnSaveAndClose_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAndClose.Click

        Dim cajaColaborador As New Entidades.CajaColaborador
        Dim Colaborador As New Entidades.Colaborador
        Dim CajaAhorro As New Entidades.CajaAhorro

        Dim objcajaBU As New Negocios.CajaColaboradorBU

        For fila = 0 To grdCajaColaborador.Rows.Count - 1
            Dim monto As Double
            monto = CDbl(grdCajaColaborador.Rows(fila).Cells("ColMontoAhorrado").Value)
            Dim idColaborador = CInt(grdCajaColaborador.Rows(fila).Cells("ColColaboradorId").Value)

            Colaborador.PColaboradorid = idColaborador
            cajaColaborador.Colaborador = Colaborador

            CajaAhorro.pCajaAhorroId = cajaAhorroId
            cajaColaborador.PcajaAhorro = CajaAhorro

            cajaColaborador.PMontoAhorro = monto
            cajaColaborador.PEstatus = "A"


            If rdoNo.Checked = True Then
                If monto > 0 Then
                    If rdoSi.Checked Then
                        objcajaBU.EditarCajas(cajaColaborador)

                    Else
                        objcajaBU.GuardarCajas(cajaColaborador)

                    End If
                End If
            Else
                objcajaBU.EditarCajas(cajaColaborador)
            End If
        Next
        If grdCajaColaborador.Rows.Count >= 1 Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Registro guardado."
            mensajeExito.Show()
            grdCajaColaborador.Rows.Clear()
            txtNombre.Text = ""
            Dim listacaja As New List(Of Entidades.Colaborador)
            Dim objBU As New Negocios.CajaColaboradorBU

            If rdoSi.Checked = True Then

                llenarTabla()
            Else
                listacaja = objBU.listaCajaColaboradoresNoAsignados(txtNombre.Text, cajaAhorroId, nave.PNaveId)
                llenarTablaNoAsignado(listacaja)
            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim mensajeExito As New ConfirmarForm
        mensajeExito.mensaje = "¿Está seguro que quiere salir sin guardar cambios?"

        If mensajeExito.ShowDialog = DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdCajaColaborador.EditingControlShowing
        ' referencia a la celda 

        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  

        Dim columna As Integer = grdCajaColaborador.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 8 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  


            If (Char.IsNumber(caracter)) Or
            (caracter = ChrW(Keys.Back)) Or
            (caracter = ".") And
            (txt.Text.Contains(".") = False) Then

                e.Handled = False
            Else
                e.Handled = True


            End If
        End If
    End Sub


    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetter(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then
            'Or e.KeyChar = "-" Then

            e.Handled = False
        End If
    End Sub

    Private Sub rdoSi_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles rdoSi.CheckedChanged
        If rdoNo.Checked = True Then
            grdCajaColaborador.Rows.Clear()
        Else
            If rdoSi.Checked = True Then
                grdCajaColaborador.Rows.Clear()
            End If
        End If
    End Sub

    Private Sub grdCajaColaborador_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdCajaColaborador.CellEnter
        If e.RowIndex >= 0 Then
            PorcentajeSalario = CDbl(grdCajaColaborador.Rows(e.RowIndex).Cells("ColSalario").Value) * 0.1
        End If
    End Sub

    Private Sub CartaCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CartaCajaDeAhorroToolStripMenuItem.Click
        ejecutarReporteCartaCajaAhorro()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        menuImprimir.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub

    Private Function ValidarMontoAhorrados(salario, montoAhorrado, montoMaximo, PorcentajeSalario, PorcentajeSalarioMinimo) As ArrayList
        Dim respuesta As New ArrayList()

        If nave.PNaveId = 73 Or nave.PNaveId = 82 Or nave.PNaveId = 43 Then

            If montoAhorrado < PorcentajeSalarioMinimo Then
                Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto mínimo a ahorrar es del 5% del sueldo $" + PorcentajeSalarioMinimo.ToString())
                respuesta.Add(0)
                respuesta.Add(PorcentajeSalarioMinimo)
                Return respuesta
            ElseIf montoAhorrado > montoMaximo Then
                Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto máximo a ahorrar es del 10% del sueldo $" + montoMaximo.ToString())
                respuesta.Add(0)
                respuesta.Add(montoMaximo)
                Return respuesta
            End If
        Else
            If salario >= 1001 And salario <= 1500 Then
                If montoAhorrado > 100 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto máximo a ahorrar es de: $100 ")
                    respuesta.Add(0)
                    respuesta.Add(100)
                    Return respuesta
                End If
                If montoAhorrado < 35 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto mínimo a ahorrar es de: $35")
                    respuesta.Add(0)
                    respuesta.Add(35)
                    Return respuesta
                End If

            ElseIf salario >= 1501 And salario <= 2000 Then
                If montoAhorrado > 200 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto máximo a ahorrar es de: $200")
                    respuesta.Add(0)
                    respuesta.Add(200)
                    Return respuesta
                End If
                If montoAhorrado < 50 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto mínimo a ahorrar es de: $50")
                    respuesta.Add(0)
                    respuesta.Add(50)
                    Return respuesta
                End If

            ElseIf salario >= 2001 And salario <= 2500 Then
                If montoAhorrado > 300 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto máximo a ahorrar es de:  $300")
                    respuesta.Add(0)
                    respuesta.Add(300)
                    Return respuesta
                End If
                If montoAhorrado < 75 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto mínimo a ahorrar es de: $75")
                    respuesta.Add(0)
                    respuesta.Add(75)
                    Return respuesta
                End If

            ElseIf salario >= 2501 And salario <= 3000 Then
                If montoAhorrado > 400 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto máximo a ahorrar es de: $400")
                    respuesta.Add(0)
                    respuesta.Add(400)
                    Return respuesta
                End If
                If montoAhorrado < 100 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto mínimo a ahorrar es de: $100")
                    respuesta.Add(0)
                    respuesta.Add(100)
                    Return respuesta
                End If

            ElseIf salario >= 3001 Then
                If montoAhorrado > 500 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto máximo a ahorrar es de: $500")
                    respuesta.Add(0)
                    respuesta.Add(500)
                    Return respuesta
                End If
                If montoAhorrado < 125 Then
                    Tools.MostrarMensaje(Tools.Mensajes.Fault, "El monto mínimo a ahorrar es de: $125")
                    respuesta.Add(0)
                    respuesta.Add(125)
                    Return respuesta
                End If
            ElseIf salario = 0 Then
                Tools.MostrarMensaje(Tools.Mensajes.Fault, "No se puede calcular debido a que es por destajo")
                respuesta.Add(0)
                respuesta.Add(0)
                Return respuesta
            End If
            respuesta.Add(1)
            Return respuesta
        End If
        Return respuesta
    End Function
End Class