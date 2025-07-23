Imports Tools

Public Class EditarCobranzaPrestamos
    Dim fechamodificacion As DateTime

    Private LISTAID As List(Of Int32)

    Public Property PLISTAID As List(Of Int32)
        Get
            Return LISTAID
        End Get
        Set(ByVal value As List(Of Int32))
            LISTAID = value
        End Set
    End Property


    Private Sub EditarCobranzaPrestamos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblEstatusSemanaNomina.Visible = False
        lblIdSemanaNomina.Visible = False
        Tools.FormatoCtrls.formato(Me)
        ''   grdPrestamos.ReadOnly = True
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            If cmbNave.SelectedIndex > 0 Then
                SemanaNomina()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        grdPrestamos.Rows.Clear()

        Try
            If lblEstatusSemanaNomina.Text = "A" Then
                Dim semanaNominaId As Integer
                semanaNominaId = lblIdSemanaNomina.Text
                Dim naveId As Integer
                naveId = cmbNave.SelectedValue
                llenarTablaConPrestamosCobradosEditar(semanaNominaId, naveId, txtColaborador.Text)
            Else
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "La semana de nómina de esta nave ya fue cerrada y no se puede editar."

                mensajeExito.Show()
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''LLENAR PRESTAMOS COBRADOS
    Public Sub llenarTablaConPrestamosCobradosEditar(ByVal semanaNominaID As Integer, ByVal naveId As Integer, ByVal Colaborador As String)
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.CobranzaPrestamosBU

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_EDITAR_PRES", "EDITARABONOS") Then

                listaConfiguracionPrestamos = prestamosBU.ListaCobranzaEditar(semanaNominaID, naveId, Colaborador)

                For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                    AgregarFilaDePrestamosCobradosEditar(objeto)

                Next

            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_EDITAR_PRES", "EDITARABONOSNEGATIVOS") Then

                For Each DATO As Int32 In LISTAID
                    listaConfiguracionPrestamos = prestamosBU.ListaCobranzaEditarNegativos(semanaNominaID, naveId, DATO)

                    For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                        AgregarFilaDePrestamosCobradosEditarNEGATIVOS(objeto)

                    Next


                Next



            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosCobradosEditar(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim numPago As Int16

        Dim interes As Double
        Dim interes2 As Double
        Dim Saldo As Double
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow
        Dim tasaInteres As Double
        Dim abonoCapital As Double
        Dim TotalSaldo As Double
        tasaInteres = Prestamos.Pinteres


        interes = 0
        interes = 7 * (tasaInteres / 30.4)
        interes = interes / 100


        numPago = Prestamos.PcobranzaPrestamos.PnumPago

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        ''ID DEL PRESTAMO
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.PcobranzaPrestamos.PPagoId
        fila.Cells.Add(celda)


        'NUMERO DE PAGO
        celda = New DataGridViewTextBoxCell
        celda.Value = numPago
        fila.Cells.Add(celda)


        ''NUMERO DE PAGO/ PAGOS
        celda = New DataGridViewTextBoxCell
        celda.Value = numPago.ToString + " / " + Prestamos.Psemanas.ToString
        fila.Cells.Add(celda)


        'NOMBRE DEL COLABORADOR
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno
        fila.Cells.Add(celda)


        ''MONTO TOTAL DEL PRESTAMOS
        celda = New DataGridViewTextBoxCell
        TotalSaldo = Prestamos.Pmontoprestamo
        celda.Value = TotalSaldo
        fila.Cells.Add(celda)


        ''SALDO ANTERIOR
        celda = New DataGridViewTextBoxCell

        celda.Value = Prestamos.PcobranzaPrestamos.PsaldoAnterior
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        interes2 = Prestamos.Pinteres
        celda.Value = interes2
        fila.Cells.Add(celda)


        ''INTERES QUE PAGARA TERMINA

        ''ABONO CAPITAL INICIA

        celda = New DataGridViewTextBoxCell
        abonoCapital = Prestamos.Pabono
        celda.Value = Prestamos.Pabono
        fila.Cells.Add(celda)


        ''ABONO CAPITAL TERMINA
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pabono + tasaInteres
        fila.Cells.Add(celda)

        'TERMINA TOTAL ABONO


        celda = New DataGridViewTextBoxCell
        Saldo = Prestamos.Psaldo
        celda.Value = Prestamos.Psaldo
        fila.Cells.Add(celda)


        ''NUEVO SALDO TERMINA
        ''LIQUIDA CON
        celda = New DataGridViewTextBoxCell
        celda.Value = interes2 + Prestamos.PcobranzaPrestamos.PsaldoAnterior
        fila.Cells.Add(celda)



        ''LIQUIDA CON

        ''RESPALDO INTERES QUE PAGARA INICIA

        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pinteres
        fila.Cells.Add(celda)


        '' RESPALDO INTERES QUE PAGARA TERMINA


        celda = New DataGridViewTextBoxCell
        celda.Value = "E"
        fila.Cells.Add(celda)


        ''el id del prestamo
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pprestamoid
        fila.Cells.Add(celda)



        grdPrestamos.Rows.Add(fila)

        For Each row As DataGridViewRow In grdPrestamos.Rows

            row.Cells(0).Style.BackColor = Color.LightGreen
            row.Cells(1).Style.BackColor = Color.LightGreen
            row.Cells(2).Style.BackColor = Color.LightGreen
            row.Cells(3).Style.BackColor = Color.LightGreen
            row.Cells(4).Style.BackColor = Color.LightGreen
            row.Cells(5).Style.BackColor = Color.LightGreen
            row.Cells(6).Style.BackColor = Color.LightGreen
            row.Cells(7).Style.BackColor = Color.LightGreen
            row.Cells(8).Style.BackColor = Color.LightGreen
            row.Cells(9).Style.BackColor = Color.LightGreen
            row.Cells("clmLiquidacion").Style.BackColor = Color.LightGreen


            row.Cells(0).ReadOnly = True
            row.Cells(1).ReadOnly = True
            row.Cells(2).ReadOnly = True
            row.Cells(3).ReadOnly = True
            row.Cells(4).ReadOnly = True
            row.Cells(5).ReadOnly = True
            row.Cells(6).ReadOnly = True
            row.Cells(7).ReadOnly = True
            row.Cells(8).ReadOnly = False



        Next



    End Sub
    ''LLENAR PRESTAMOS COBRADOS

    Public Sub AgregarFilaDePrestamosCobradosEditarNEGATIVOS(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim numPago As Int16

        Dim interes As Double
        Dim interes2 As Double
        Dim Saldo As Double
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow
        Dim tasaInteres As Double
        Dim abonoCapital As Double
        Dim TotalSaldo As Double
        tasaInteres = Prestamos.Pinteres


        interes = 0
        interes = 7 * (tasaInteres / 30.4)
        interes = interes / 100


        numPago = Prestamos.PcobranzaPrestamos.PnumPago

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        ''ID DEL PRESTAMO
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.PcobranzaPrestamos.PPagoId
        fila.Cells.Add(celda)


        'NUMERO DE PAGO
        celda = New DataGridViewTextBoxCell
        celda.Value = numPago
        fila.Cells.Add(celda)


        ''NUMERO DE PAGO/ PAGOS
        celda = New DataGridViewTextBoxCell
        celda.Value = numPago.ToString + " / " + Prestamos.Psemanas.ToString
        fila.Cells.Add(celda)


        'NOMBRE DEL COLABORADOR
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno
        fila.Cells.Add(celda)


        ''MONTO TOTAL DEL PRESTAMOS
        celda = New DataGridViewTextBoxCell
        TotalSaldo = Prestamos.Pmontoprestamo
        celda.Value = TotalSaldo
        fila.Cells.Add(celda)


        ''SALDO ANTERIOR
        celda = New DataGridViewTextBoxCell

        celda.Value = Prestamos.PcobranzaPrestamos.PsaldoAnterior
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        interes2 = Prestamos.Pinteres
        celda.Value = interes2
        fila.Cells.Add(celda)


        ''INTERES QUE PAGARA TERMINA

        ''ABONO CAPITAL INICIA

        celda = New DataGridViewTextBoxCell
        abonoCapital = Prestamos.Pabono
        celda.Value = Prestamos.Pabono
        fila.Cells.Add(celda)


        ''ABONO CAPITAL TERMINA
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pabono + tasaInteres
        fila.Cells.Add(celda)

        'TERMINA TOTAL ABONO


        celda = New DataGridViewTextBoxCell
        Saldo = Prestamos.Psaldo
        celda.Value = Prestamos.Psaldo
        fila.Cells.Add(celda)


        ''NUEVO SALDO TERMINA
        ''LIQUIDA CON
        celda = New DataGridViewTextBoxCell
        celda.Value = interes2 + Prestamos.PcobranzaPrestamos.PsaldoAnterior
        fila.Cells.Add(celda)



        ''LIQUIDA CON

        ''RESPALDO INTERES QUE PAGARA INICIA

        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pinteres
        fila.Cells.Add(celda)


        '' RESPALDO INTERES QUE PAGARA TERMINA


        celda = New DataGridViewTextBoxCell
        celda.Value = "E"
        fila.Cells.Add(celda)


        ''el id del prestamo
        celda = New DataGridViewTextBoxCell
        celda.Value = Prestamos.Pprestamoid
        fila.Cells.Add(celda)



        grdPrestamos.Rows.Add(fila)

        For Each row As DataGridViewRow In grdPrestamos.Rows

            row.Cells(0).Style.BackColor = Color.LightGreen
            row.Cells(1).Style.BackColor = Color.LightGreen
            row.Cells(2).Style.BackColor = Color.LightGreen
            row.Cells(3).Style.BackColor = Color.LightGreen
            row.Cells(4).Style.BackColor = Color.LightGreen
            row.Cells(5).Style.BackColor = Color.LightGreen
            row.Cells(6).Style.BackColor = Color.LightGreen
            row.Cells(7).Style.BackColor = Color.LightGreen
            row.Cells(8).Style.BackColor = Color.LightGreen
            row.Cells(9).Style.BackColor = Color.LightGreen
            row.Cells("clmLiquidacion").Style.BackColor = Color.LightGreen


            row.Cells(0).ReadOnly = True
            row.Cells(1).ReadOnly = True
            row.Cells(2).ReadOnly = True
            row.Cells(3).ReadOnly = True
            row.Cells(4).ReadOnly = True
            row.Cells(5).ReadOnly = True
            row.Cells(6).ReadOnly = True
            row.Cells(7).ReadOnly = True
            row.Cells(8).ReadOnly = False



        Next



    End Sub


    ''LLENAR SEMANA NOMINA ACTIVA

    Public Sub SemanaNomina()
        Try
            Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
            Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            SemanaNominaActiva = SenamaActivaBu.SemanaNominaActiva(idNave)

            For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
                SemanaActiva(objeto)

            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub SemanaActiva(ByVal SemanaActiva As Entidades.CobranzaPrestamos)

        lblIdSemanaNomina.Text = SemanaActiva.PsemanaNominaId
        lblEstatusSemanaNomina.Text = SemanaActiva.PPeriodoNominaNomina
        fechamodificacion = SemanaActiva.PfechaFinNomina


    End Sub
    ''
    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        SemanaNomina()
    End Sub




    Private Sub grdPrestamos_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrestamos.CellLeave
        Dim TotalAbono As Double = 0
        Dim estaMal As Integer = 0
        If e.ColumnIndex = 7 Then
            Try
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    If row.Cells("clmCobrado").Value = "E" Then

                        'SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                        If row.Cells("clmtotalabono").Value = 0 Then
                            row.Cells("clminteres").Value = 0
                            row.Cells("clmabonocapital").Value = 0
                            row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow
                            row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value

                        Else


                            'VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SANDO QUE TIENE
                            If (row.Cells("clmtotalabono").Value - row.Cells("clminteres").Value) > row.Cells("clmsaldoanterior").Value Then
                                row.Cells("clmtotalabono").Style.BackColor = Color.Salmon
                                row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                                estaMal = 1
                            Else


                                'VALIDA QUE NO DE UN ABONO MENOR A LOS INTERESES
                                If row.Cells("clmtotalabono").Value < row.Cells("clmInteres2").Value And row.Cells("clmtotalabono").Value > 0 Then
                                    row.Cells("clmtotalabono").Style.BackColor = Color.LightSalmon
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    estaMal = 1
                                Else

                                    row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    row.Cells("clmabonocapital").Value = row.Cells("clmtotalabono").Value - row.Cells("clmInteres2").Value
                                    row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value - row.Cells("clmabonocapital").Value
                                    TotalAbono = row.Cells("clmtotalabono").Value
                                    row.Cells("clmtotalabono").Value = TotalAbono

                                End If
                            End If
                        End If
                    End If
                Next
                If estaMal = 1 Then
                    btnGuardar.Enabled = False
                Else
                    btnGuardar.Enabled = True
                End If
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub grdPrestamos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdPrestamos.CellValueChanged
        Dim TotalAbono As Double = 0
        Dim Interes As Double = 0
        Dim Saldo As Double = 0
        Dim AbonoCapital As Double = 0
        Dim estaMal As Integer = 0

        If e.ColumnIndex = 8 Then
            Try
                For Each row As DataGridViewRow In grdPrestamos.Rows

                    If row.Cells("clmCobrado").Value = "E" Then


                        ''SI EL ABONO ES IGUAL A 0 ENTONCES NO DARA INTERES NI ABONO CAPITA.L
                        If row.Cells("clmtotalabono").Value = 0 Then
                            row.Cells("clminteres").Value = 0
                            row.Cells("clmabonocapital").Value = 0
                            row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                            row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow

                        Else

                            ''VALIDADION PARA QUE EL TOTAL DE ABONO NO SOBRE PASE EL SALDO QUE TIENE
                            If row.Cells("clmtotalabono").Value > row.Cells("clmLiquidacion").Value Then
                                row.Cells("clmtotalabono").Style.BackColor = Color.Salmon
                                row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value
                                estaMal = 1

                            Else

                                ''VALIDA QUE NO DE UN ABONO MENOR A LOS INTERESES
                                If row.Cells("clmtotalabono").Value < row.Cells("clmInteres2").Value And row.Cells("clmtotalabono").Value > 0 Then
                                    row.Cells("clmtotalabono").Style.BackColor = Color.Salmon
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    estaMal = 1
                                Else

                                    row.Cells("clmtotalabono").Style.BackColor = Color.LightYellow
                                    row.Cells("clminteres").Value = row.Cells("clmInteres2").Value
                                    row.Cells("clmabonocapital").Value = row.Cells("clmtotalabono").Value - row.Cells("clmInteres2").Value
                                    row.Cells("clmsaldo").Value = row.Cells("clmsaldoanterior").Value - row.Cells("clmabonocapital").Value
                                    TotalAbono = row.Cells("clmtotalabono").Value
                                    row.Cells("clmtotalabono").Value = TotalAbono

                                End If
                            End If
                        End If
                    End If
                Next

                If estaMal = 1 Then
                    btnGuardar.Enabled = False
                Else
                    btnGuardar.Enabled = True
                End If

            Catch ex As Exception

            End Try

        End If
    End Sub





    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorFilas As Integer = 0
        For Each dato As DataGridViewRow In grdPrestamos.Rows
            contadorFilas += 1
        Next
        If contadorFilas > 0 Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Esta seguro de querer editar el pago de los prestamos?. "

            If mensajeExito.ShowDialog = DialogResult.OK Then

                cobrarPrestamo()
            End If
        End If
    End Sub


    Public Sub cobrarPrestamo()
        Dim objBU = New Nomina.Negocios.CobranzaPrestamosBU
        Dim ObjEnt = New Entidades.CobranzaPrestamos
        Dim ObjEntSol = New Entidades.SolicitudPrestamo
        Dim objEntColaborador = New Entidades.Colaborador
        Dim mensaje As String = ""


        Try


            If grdPrestamos.CurrentRow.Cells("clmCobrado").Value = "E" Then
                For Each row As DataGridViewRow In grdPrestamos.Rows
                    If row.Cells("clmsaldo").Value < 0 Then

                        row.Cells("clmsaldo").Style.BackColor = Color.LightSalmon
                        row.Cells("clmtotalabono").Style.BackColor = Color.LightSalmon
                        mensaje = "Las filas en rojo no se guardaron por errores de configuración."
                    Else
                        ObjEntSol.Pprestamoid = CInt(row.Cells("clmprestamoid").Value)
                        ObjEnt.PPagoId = CInt(row.Cells(0).Value)
                        ObjEnt.PsemanaNominaId = CInt(lblIdSemanaNomina.Text)
                        ObjEnt.PsaldoAnterior = row.Cells("clmsaldoanterior").Value
                        ObjEntSol.Pabono = row.Cells("clmabonocapital").Value
                        ObjEntSol.Pinteres = row.Cells("clminteres").Value
                        ObjEntSol.Psaldo = row.Cells("clmsaldo").Value
                        objEntColaborador.PColaboradorid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        ObjEntSol.Pfechamodificacion = fechamodificacion
                        If CInt(row.Cells("clmsaldo").Value) = 0 Then

                            ObjEnt.Pliquidacion = 1
                        Else
                            ObjEnt.Pliquidacion = 0

                        End If


                        ObjEnt.Pcolaborador = objEntColaborador
                        ObjEnt.PSolicitudPrestamo = ObjEntSol

                        objBU.editarCobranza(ObjEnt)
                    End If

                Next
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Registro guardado." + mensaje.ToString

                mensajeExito.Show()
                grdPrestamos.Rows.Clear()

                Dim semanaNominaId As Integer
                semanaNominaId = lblIdSemanaNomina.Text
                Dim naveId As Integer
                naveId = cmbNave.SelectedValue
                llenarTablaConPrestamosCobradosEditar(semanaNominaId, naveId, txtColaborador.Text)

            End If



        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 109
    End Sub

    ''Metodo para que solo se ingresen NUMEROS y UN punto en un datagridview
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdPrestamos.EditingControlShowing
        ' referencia a la celda 


        Dim validar As TextBox = CType(e.Control, TextBox)

        ' agregar el controlador de eventos para el KeyPress  
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    ''Evento key press para validacion del datagridview
    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' evento Keypress  

        ' obtener indice de la columna  

        Dim columna As Integer = grdPrestamos.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna que se requiera
        If columna = 8 Then
            ' Obtener caracter  
            Dim caracter As Char = e.KeyChar

            ' referencia a la celda  
            Dim txt As TextBox = CType(sender, TextBox)

            ' comprobar si es un número con isNumber, si es el backspace, si el caracter  
            ' es el separador decimal, y que no contiene ya el separador  



            If (Char.IsNumber(caracter)) Or _
            (caracter = ChrW(Keys.Back)) Or _
            (caracter = ".") And _
            (txt.Text.Contains(".") = False) Then

                e.Handled = False
            Else
                e.Handled = True



            End If
        End If
    End Sub


    Private Sub txtColaborador_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColaborador.KeyPress
        Dim caracter As Char = e.KeyChar
        If (Char.IsLetter(caracter)) Or (caracter = ChrW(Keys.Back)) Or (Char.IsSeparator(caracter)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdPrestamos.Rows.Clear()
        txtColaborador.Text = ""
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()

    End Sub


End Class