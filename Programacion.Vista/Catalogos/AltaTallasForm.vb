Imports System.Text.RegularExpressions
Imports Tools

Public Class AltaTallasForm

    Dim dtDatosComboPaises As DataTable
    Dim dtDatosComboTallas As DataTable
    Dim ValidaTam As Int32

    Public Sub LlenarComboPaises()
        Dim TallaNegocios As New Programacion.Negocios.TallasBU
        cmbPaises.DataSource = Nothing
        dtDatosComboPaises = New DataTable
        dtDatosComboPaises = TallaNegocios.VerPaisesTallas
        dtDatosComboPaises.Rows.InsertAt(dtDatosComboPaises.NewRow, 0)

        cmbPaises.DataSource = dtDatosComboPaises
        cmbPaises.ValueMember = "pais_paisid"
        cmbPaises.DisplayMember = "pais_nombre"
    End Sub

    Public Sub LlenarComboTallasPrincipales()
        Dim TallaNegocios As New Programacion.Negocios.TallasBU
        cmbTallaPrincipal.DataSource = Nothing
        dtDatosComboTallas = New DataTable
        dtDatosComboTallas = TallaNegocios.VerTallasPrincipales
        dtDatosComboTallas.Rows.InsertAt(dtDatosComboTallas.NewRow, 0)

        cmbTallaPrincipal.DataSource = dtDatosComboTallas
        cmbTallaPrincipal.ValueMember = "talla_tallaid"
        cmbTallaPrincipal.DisplayMember = "pais"

    End Sub

    Public Function ValidarVacio() As Boolean

        If (cmbTallaPrincipal.SelectedValue.ToString = Nothing And cmbPaises.Text <> "MÉXICO") Then
            lblTallaPrincipal.ForeColor = Drawing.Color.Red
            Return False
        End If

        If (txtTallaCentral.Value < 1 Or txtTallaInicio.Value <= 0 Or txtTallaFin.Value <= 0 Or txtTallaCentral.Value.ToString = Nothing Or txtTallaInicio.Value.ToString = Nothing Or txtTallaFin.Value.ToString = Nothing Or cmbPaises.SelectedValue.ToString = Nothing) Then

            If (txtTallaCentral.Value < 1 Or txtTallaCentral.Value.ToString = Nothing) Then
                lblTallaCentral.ForeColor = Drawing.Color.Red
            Else
                lblTallaCentral.ForeColor = Drawing.Color.Black
            End If

            If (txtTallaInicio.Value < 1 Or txtTallaInicio.Value.ToString = Nothing) Then
                lblTallaInicio.ForeColor = Drawing.Color.Red
            Else
                lblTallaInicio.ForeColor = Drawing.Color.Black
            End If

            If (txtTallaFin.Value < 1 Or txtTallaFin.Value.ToString = Nothing) Then
                lblTallaFin.ForeColor = Drawing.Color.Red
            Else
                lblTallaFin.ForeColor = Drawing.Color.Black
            End If

            If (cmbPaises.SelectedValue.ToString = Nothing) Then
                lblPais.ForeColor = Drawing.Color.Red
            Else
                lblPais.ForeColor = Drawing.Color.Black
            End If

            Return False
        Else
            lblTallaCentral.ForeColor = Drawing.Color.Black
            lblTallaInicio.ForeColor = Drawing.Color.Black
            lblTallaFin.ForeColor = Drawing.Color.Black
            lblPais.ForeColor = Drawing.Color.Black
        End If

        Return True
    End Function

    Public Sub ContadorEnteros()
        Dim mensaje As New AdvertenciaForm
        Dim mensajeExito As New ExitoForm
        'Dim dtTallasPais As DataTable
        If (txtTallaCentral.Value >= txtTallaInicio.Value And txtTallaCentral.Value <= txtTallaFin.Value) Then
            Dim tinicio As String = txtTallaInicio.Value.ToString()
            Dim tfin As String = txtTallaFin.Value.ToString()
            Dim inicioTalla As Decimal = Convert.ToDecimal(tinicio)
            Dim finTalla As Decimal = Convert.ToDecimal(tfin)
            Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Dim TallaNegocios As New Programacion.Negocios.TallasBU

            'Si es una talla extranjera se toman los valores de la descripción CHECAR ESTE MOVIMIENTO
            If cmbPaises.Text <> "MÉXICO" Then
                tinicio = txtDescripcion.Text.Substring(0, txtDescripcion.Text.IndexOf("-"))
                tfin = txtDescripcion.Text.Substring(txtDescripcion.Text.IndexOf("-") + 1, (txtDescripcion.Text.Length - txtDescripcion.Text.IndexOf("-") - 1))
                inicioTalla = Convert.ToDecimal(tinicio)
                finTalla = Convert.ToDecimal(tfin)
            End If

            If (finTalla >= inicioTalla) Then
                If (chkEntero.Checked = False) Then
                    Dim EntidadTallas As New Entidades.Tallas
                    Dim Descripcion As String = ""
                    Dim recorre As Integer = 1
                    Dim contador As Integer = 0
                    Dim resta As Decimal = finTalla - inicioTalla
                    Dim pasos As Integer = resta / 0.5
                    Dim tallasNuevas As Decimal = inicioTalla
                    Dim tamanoTallaInicial As Int32 = txtTallaInicio.Value.ToString.Length
                    Dim tallaInicioCadena As String = ""
                    Dim tamanoTallaFinal As Int32 = txtTallaFin.Value.ToString.Length
                    Dim tallaFinalCadena As String = ""
                    Dim tamanoTallaCentral As Int32 = txtTallaCentral.Value.ToString.Length
                    Dim tallaCentralCadena As String = ""

                    If (tamanoTallaInicial > 1) Then
                        If (txtTallaInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                            tallaInicioCadena = txtTallaInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                        Else
                            tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                        End If
                    Else
                        tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                    End If


                    EntidadTallas.PTallaInicio = tallaInicioCadena

                    If (tamanoTallaFinal > 1) Then
                        If (txtTallaFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                            tallaFinalCadena = txtTallaFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                        Else
                            tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                        End If
                    Else
                        tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                    End If
                    EntidadTallas.PTallaFin = tallaFinalCadena
                    If (tamanoTallaCentral > 1) Then
                        If (txtTallaCentral.Value.ToString.Substring(tamanoTallaCentral - 2, 2) = ".5") Then
                            tallaCentralCadena = txtTallaCentral.Value.ToString.Substring(0, tamanoTallaCentral - 2) + "½"
                        Else
                            tallaCentralCadena = CStr(CInt(txtTallaCentral.Value.ToString))
                        End If
                    Else
                        tallaCentralCadena = CStr(CInt(txtTallaCentral.Value.ToString))
                    End If
                    EntidadTallas.PTallaCentral = tallaCentralCadena

                    'Si la talla es extranjera los valores de inicio, central y fin se toman en base a esa talla
                    If cmbPaises.Text <> "MÉXICO" Then
                        EntidadTallas.PTallaInicio = inicioTalla
                        EntidadTallas.PTallaCentral = inicioTalla + (finTalla - inicioTalla) / 2
                        EntidadTallas.PTallaFin = finTalla
                    End If

                    Descripcion = txtDescripcion.Text
                    EntidadTallas.PTDescripcion = Descripcion

                    EntidadTallas.PTallaGrupo = txtGrupo.Text
                    EntidadTallas.PSicyTalla = txtCodSicy.Text
                    If (rdoActivo.Checked = True) Then
                        EntidadTallas.PTAcvito = True
                    ElseIf (rdoInactivo.Checked = False) Then
                        EntidadTallas.PTAcvito = False
                    End If
                    If (chkEntero.Checked = True) Then
                        EntidadTallas.PTEntero = True
                    ElseIf (chkEntero.Checked = False) Then
                        EntidadTallas.PTEntero = False
                    End If
                    Try
                        EntidadTallas.PTallaPais = cmbPaises.SelectedValue
                        EntidadTallas.PTallaPrincipal = cmbTallaPrincipal.SelectedValue
                    Catch ex As Exception
                        EntidadTallas.PTallaPrincipal = ""
                    End Try

                    'dtTallasPais = TallaNegocios.VerificarTallasInsertadasPorPais(EntidadTallas.PTallaPais, EntidadTallas.PTallaPrincipal)
                    'If Integer.Parse(dtTallasPais.Rows(0).Item(0).ToString()) = 0 Then
                    If (pasos < 20) Then
                        TallaNegocios.RegistrarTalla(EntidadTallas, usuario)
                        Dim dtIdmaximoTallas As DataTable = TallaNegocios.VerIdMaximoTalla
                        Dim idTalla As Int32 = Convert.ToInt32(dtIdmaximoTallas.Rows(0)("idMAx").ToString)
                        Dim datoTalla As String = ""
                        Dim tamanoCadena As Int32 = 0
                        Dim valorTallaExtranjera As String
                        For recorre = 1 To pasos + 1
                            tamanoCadena = tallasNuevas.ToString.Length
                            If (tamanoCadena > 1) Then
                                If (tallasNuevas.ToString.Substring(tamanoCadena - 2, 2) = ".5") Then
                                    datoTalla = tallasNuevas.ToString.Substring(0, tamanoCadena - 2) + "½"
                                Else
                                    datoTalla = CStr(CInt(tallasNuevas.ToString))
                                End If
                            Else
                                datoTalla = CStr(CInt(tallasNuevas.ToString))
                            End If

                            'Tomar los valores de la talla extranjera capturados por el usuario directo del dataGrid
                            Try
                                If cmbPaises.Text <> "MÉXICO" Then
                                    valorTallaExtranjera = Convert.ToString(grdTablaAmarre.Rows(1).Cells(recorre - 1).Value)
                                    valorTallaExtranjera = Replace(valorTallaExtranjera, ".5", "½")
                                    If (valorTallaExtranjera <> Nothing) Then
                                        datoTalla = valorTallaExtranjera
                                    Else
                                        MsgBox("Valores talla extranjera incorrectos")
                                        'MODIFICACIONES PENDIENTES 16/12/16 VERIFICAR POR QUE NO SALE COMPLETAMENTE
                                        Exit Sub
                                        Exit For
                                        Exit Try
                                    End If
                                End If
                            Catch ex As Exception

                            End Try


                            TallaNegocios.insertarTallas(recorre, datoTalla, idTalla)
                            tallasNuevas = tallasNuevas + 0.5
                        Next
                        If cmbPaises.Text <> "MÉXICO" Then
                            mensajeExito.mensaje = "El registro se realizó con éxito." + vbNewLine + vbNewLine + "Talla registrada: " + Replace(txtDescripcion.Text, "-", "/")
                        Else
                            mensajeExito.mensaje = "El registro se realizó con éxito." + vbNewLine + vbNewLine + "Talla registrada: " + txtTallaInicio.Value.ToString + "/" + txtTallaFin.Value.ToString
                        End If
                        mensajeExito.ShowDialog()
                        Me.Close()
                    Else
                        mensaje.mensaje = "No puede registrar mas de 20 tallas en una descripción."
                        mensaje.ShowDialog()
                    End If
                    'Else
                    '    mensaje.mensaje = "Ya existe una corrida para este país y talla base"
                    '    mensaje.ShowDialog()
                    'End If

                ElseIf (chkEntero.Checked = True) Then
                    If (Math.Round(inicioTalla) <= Math.Round(finTalla)) Then
                        Dim EntidadTallas As New Entidades.Tallas
                        Dim Descripcion As String = ""
                        Dim recorre As Int32 = 1
                        Dim contador As Int32 = 0
                        Dim tallasNuevas As Decimal = Math.Round(inicioTalla)
                        Dim resta As Int32 = Math.Round(finTalla) - Math.Round(inicioTalla)
                        Dim cadena As String = Math.Round(inicioTalla).ToString
                        Dim inicio As Int32 = Math.Round(inicioTalla)
                        Dim fin As Int32 = Math.Round(finTalla)
                        Descripcion = txtDescripcion.Text
                        EntidadTallas.PTDescripcion = Descripcion
                        EntidadTallas.PTallaInicio = CStr(CInt(inicio))
                        EntidadTallas.PTallaFin = CStr(CInt(fin))
                        EntidadTallas.PTallaCentral = CStr(CInt(txtTallaCentral.Value.ToString))

                        If cmbPaises.Text <> "MÉXICO" Then
                            EntidadTallas.PTallaCentral = CStr(inicio + (fin - inicio) / 2)
                        End If

                        EntidadTallas.PTallaGrupo = txtGrupo.Text
                        EntidadTallas.PSicyTalla = txtCodSicy.Text
                        If (rdoActivo.Checked = True) Then
                            EntidadTallas.PTAcvito = True
                        ElseIf (rdoInactivo.Checked = False) Then
                            EntidadTallas.PTAcvito = False
                        End If
                        If (chkEntero.Checked = True) Then
                            EntidadTallas.PTEntero = True
                        ElseIf (chkEntero.Checked = False) Then
                            EntidadTallas.PTEntero = False
                        End If
                        Try
                            EntidadTallas.PTallaPais = cmbPaises.SelectedValue
                            EntidadTallas.PTallaPrincipal = ""
                            If cmbPaises.Text <> "MÉXICO" Then
                                EntidadTallas.PTallaPrincipal = cmbTallaPrincipal.SelectedValue
                            End If
                        Catch ex As Exception
                            EntidadTallas.PTallaPrincipal = ""
                        End Try
                        'dtTallasPais = TallaNegocios.VerificarTallasInsertadasPorPais(EntidadTallas.PTallaPais, EntidadTallas.PTallaPrincipal)
                        'If Integer.Parse(dtTallasPais.Rows(0).Item(0).ToString()) = 0 Then
                        If (resta <= 20) Then
                            TallaNegocios.RegistrarTalla(EntidadTallas, usuario)
                            Dim dtIdmaximoTallas As DataTable = TallaNegocios.VerIdMaximoTalla
                            Dim idTalla As Int32 = Convert.ToInt32(dtIdmaximoTallas.Rows(0)("idMAx").ToString)
                            Dim datoTalla As String = ""
                            For recorre = 1 To resta + 1
                                If recorre = 21 Then
                                    Exit For
                                End If
                                datoTalla = CStr(CInt(tallasNuevas))
                                TallaNegocios.insertarTallas(recorre, datoTalla, idTalla)
                                tallasNuevas = tallasNuevas + 1
                            Next
                            mensajeExito.mensaje = "El registro se realizó con éxito." + vbNewLine + vbNewLine + "Talla registrada: " + inicio.ToString + "/" + fin.ToString
                            mensajeExito.ShowDialog()
                        Else
                            mensaje.mensaje = "No puede registrar mas de 20 tallas en una descripción."
                            mensaje.ShowDialog()
                        End If
                        'Else
                        '    mensaje.mensaje = "Ya existe una corrida para este país y talla base"
                        '    mensaje.ShowDialog()
                        'End If
                        Me.Close()
                    ElseIf (Math.Round(inicioTalla) > Math.Round(finTalla)) Then
                        mensaje.mensaje = "La talla de inicio no puede ser mayor a la talla final."
                        mensaje.ShowDialog()
                    End If
                End If

            ElseIf (finTalla < inicioTalla) Then
                mensaje.mensaje = "La talla de inicio no puede ser mayor a la talla final."
                mensaje.ShowDialog()
            End If
        Else
            mensaje.mensaje = "La talla central debe ser una talla con valor entre las tallas de inicio y fin."
            mensaje.ShowDialog()
        End If
    End Sub

    Public Sub guardarAmarre()
        Dim objTallaBU As New Programacion.Negocios.TallasBU
        Dim dtIdTallaMax As New DataTable
        dtIdTallaMax = objTallaBU.VerIdMaximoTalla
        Dim idTallaMax As Int32 = CInt(dtIdTallaMax.Rows(0)(0).ToString)
        Dim tamTabAmarre As Int32 = grdTablaAmarre.ColumnCount

        For n As Int32 = 0 To tamTabAmarre - 1
            objTallaBU.AltaAmarreBU(idTallaMax, grdTablaAmarre.Item(n, 0).Value.ToString, CInt(grdTablaAmarre.Item(n, 2).Value.ToString), CInt(grdTablaAmarre.Item(n, 3).Value.ToString), CInt(grdTablaAmarre.Item(n, 1).Value.ToString))
        Next
        objTallaBU.AltaAmarreSicy(idTallaMax)
    End Sub

    Public Sub guardarAmarreSoloToltal()
        Dim objTallaBU As New Programacion.Negocios.TallasBU
        Dim dtIdTallaMax As New DataTable
        dtIdTallaMax = objTallaBU.VerIdMaximoTalla
        Dim idTallaMax As Int32 = CInt(dtIdTallaMax.Rows(0)(0).ToString)
        Dim tamTabAmarre As Int32 = grdTablaAmarre.ColumnCount
        For n As Int32 = 0 To tamTabAmarre - 1
            objTallaBU.AltaAmarreTotal(idTallaMax, grdTablaAmarre.Item(n, 0).Value.ToString, CInt(grdTablaAmarre.Item(n, 2).Value.ToString))
        Next
    End Sub

    Private Sub grdTablaAmarre_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdTablaAmarre.EditingControlShowing
        Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
        AddHandler ValidaEntradaDatos.KeyPress, AddressOf grdTablaAmarre_KeyPress
    End Sub


    Public Function validarAmarre() As Boolean
        Dim sumaAm As Int32 = 0
        Dim sumaAmDos As Int32 = 0
        If (ckbMedias.Checked = True) Then
            For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
                sumaAm = sumaAm + CInt(grdTablaAmarre.Item(columna.Index, 3).Value.ToString())
                sumaAmDos = sumaAmDos + CInt(grdTablaAmarre.Item(columna.Index, 4).Value.ToString())
            Next
            If (sumaAm <> 6 Or sumaAmDos <> 6) Then
                If (sumaAm <> 6) Then
                    grdTablaAmarre.Rows(3).DefaultCellStyle.ForeColor = Color.Red
                Else
                    grdTablaAmarre.Rows(3).DefaultCellStyle.ForeColor = Color.Black
                End If
                If (sumaAmDos <> 6) Then
                    grdTablaAmarre.Rows(4).DefaultCellStyle.ForeColor = Color.Red
                Else
                    grdTablaAmarre.Rows(4).DefaultCellStyle.ForeColor = Color.Black
                End If
                Return False
            Else
                grdTablaAmarre.Rows(3).DefaultCellStyle.ForeColor = Color.Black
                grdTablaAmarre.Rows(4).DefaultCellStyle.ForeColor = Color.Black
            End If
        End If

        Return True
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        'Expresion regular para evaluar que la descripción tenga dos dígitos-dos dígitos
        Dim patron As String = "^[0-9]{1,2}" + "\-" + "[0-9]{1,2}$"
        Dim comprobacion As Match = Regex.Match(Replace(txtDescripcion.Text, "½", ""), patron, RegexOptions.IgnoreCase)
        Dim mensaje As New AdvertenciaForm
        Dim confirmacion As New ConfirmarForm

        If comprobacion.Success Then

        Else

            mensaje.mensaje = "Ingrese una descripción de talla correcta." & vbCrLf & "dd-dd"
            mensaje.ShowDialog()
            Exit Sub
        End If


        If (ValidarVacio() = True) Then
            If (ckbMedias.Checked = True) Then

                If (validarAmarre() = True) Then
                    'If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                    confirmacion.mensaje = "¿Esta seguro de guardar cambios?"
                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ContadorEnteros()
                        If (ckbMedias.Checked = True) Then
                            guardarAmarre()
                        End If
                    Else
                    End If
                Else
                    'MsgBox("Cada media debe incluir 6 amarres.")
                    mensaje.mensaje = "Cada media debe incluir 6 pares"
                    mensaje.ShowDialog()
                End If

            Else
                Dim suma As Int32 = 0
                For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
                    suma = suma + CInt(grdTablaAmarre.Rows(2).Cells(columna.Index).Value)
                Next

                If (suma = 0) Then
                    'If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                    confirmacion.mensaje = "¿Esta seguro de guardar cambios?"
                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ContadorEnteros()
                    End If
                ElseIf (suma = 12) Then
                    'If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                    confirmacion.mensaje = "¿Esta seguro de guardar cambios?"
                    If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                        ContadorEnteros()
                        guardarAmarreSoloToltal()
                    End If
                ElseIf (suma <> 0 And suma <> 12) Then
                    grdTablaAmarre.Rows(2).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If

        ElseIf (ValidarVacio() = False) Then
            'Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
        'MsgBox(txtDescripcion.Text + " " + txtGrupo.Text + " " + txtTallaInicio.Value.ToString + " " + txtTallaFin.Value.ToString + " " + txtTallaCentral.Value.ToString + " " + cmbPaises.SelectedValue.ToString + " " + cmbTallaPrincipal.SelectedValue)
    End Sub


    Private Sub AltaTallasForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'WindowState = FormWindowState.Maximized
        txtTallaInicio.Controls.RemoveAt(0)
        txtTallaFin.Controls.RemoveAt(0)
        txtTallaCentral.Controls.RemoveAt(0)
        grdTablaAmarre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdTablaAmarre.AllowUserToAddRows = False
        txtGrupo.Text = String.Empty
        txtTallaFin.Value = 1
        txtTallaCentral.Value = 1
        txtTallaInicio.Value = 1
        rdoActivo.Checked = True
        LlenarComboPaises()
        LlenarComboTallasPrincipales()
        chkEntero.Checked = True
        ckbMedias.Checked = True

        Dim objColeBU As New Negocios.ColeccionBU
        txtCodSicy.Text = objColeBU.EncontrarColeccionSICY(5)(0)(0)

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub chkEntero_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEntero.CheckedChanged
        grdTablaAmarre.Rows.Clear()
        grdTablaAmarre.Columns.Clear()
        'ckbMedias.Checked = False
        Dim Inicio As Decimal = txtTallaInicio.Value
        Dim Fin As Decimal = txtTallaFin.Value
        Dim Central As Decimal = txtTallaCentral.Value
        If (chkEntero.Checked = True) Then
            txtTallaInicio.Value = Math.Floor(Inicio)
            txtTallaFin.Value = Math.Floor(Fin)
            txtTallaCentral.Value = Math.Floor(Central)

            If cmbPaises.Text.Equals("MEXICO") Then
                txtDescripcion.Text = CStr(CInt(txtTallaInicio.Value)) + "-" + CStr(CInt(txtTallaFin.Value))
            End If
        End If
        lblTotalPares.Text = "0"
        lblTotalPares.ForeColor = Color.Black
        movimientoTabla()
    End Sub


    Private Sub txtGrupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrupo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtGrupo.Text.Length < 10) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "/")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtGrupo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs)
        Dim messageBoxVB As New System.Text.StringBuilder()
        messageBoxVB.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow)
        messageBoxVB.AppendLine()
        MessageBox.Show(messageBoxVB.ToString(), "Popup Event")
    End Sub



    Private Sub ckbMedias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbMedias.CheckedChanged
        If (grdTablaAmarre.Rows.Count > 0) Then
            If (ckbMedias.Checked = True) Then
                Me.grdTablaAmarre.Rows(3).Visible = True
                Me.grdTablaAmarre.Rows(4).Visible = True
                For Each col As DataGridViewColumn In grdTablaAmarre.Columns
                    grdTablaAmarre.Rows(3).Cells(col.Index).Value = grdTablaAmarre.Rows(2).Cells(col.Index).Value
                Next
            ElseIf (ckbMedias.Checked = False) Then
                Me.grdTablaAmarre.Rows(3).Visible = False
                Me.grdTablaAmarre.Rows(4).Visible = False
            End If
        End If
    End Sub

    Private Sub txtTallaFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTallaFin.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtTallaFin.Value = CDec(txtTallaFin.Value)

            If (txtTallaFin.Value >= 1) Then
                Dim validaPunto As Boolean = True
                Dim cadenaText As Int32 = Len(txtTallaFin.Value.ToString)
                If (cadenaText > 2) Then
                    If (txtTallaFin.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                        If Not (txtTallaFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                            validaPunto = False
                            Dim dato As String = txtTallaFin.Value.ToString.Substring(0, cadenaText - 2)
                            txtTallaFin.Value = dato + ".5"
                        End If
                    End If
                End If

                Dim tamanoTallaInicial As Int32 = txtTallaInicio.Value.ToString.Length
                Dim tallaInicioCadena As String = ""
                Dim tamanoTallaFinal As Int32 = txtTallaFin.Value.ToString.Length
                Dim tallaFinalCadena As String = ""

                If (tamanoTallaInicial > 1) Then
                    If (txtTallaInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                        tallaInicioCadena = txtTallaInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                    Else
                        tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                    End If
                Else
                    tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                End If
                If (tamanoTallaFinal > 1) Then
                    If (txtTallaFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                        tallaFinalCadena = txtTallaFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                    Else
                        tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                    End If
                Else
                    tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                End If

                txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
            Else
                txtTallaFin.Value = 1
            End If
        End If
    End Sub


    Private Sub txtTallaFin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTallaFin.LostFocus
        Dim cadenaText As Int32 = Len(txtTallaFin.Value.ToString)
        If (CInt(txtTallaFin.Value) >= 1) Then

            If (cadenaText > 2) Then
                If (txtTallaFin.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                    If Not (txtTallaFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                        'validaPunto = False
                        Dim dato As String = txtTallaFin.Value.ToString.Substring(0, cadenaText - 2)
                        txtTallaFin.Value = dato + ".5"
                    End If
                End If
            End If

            Dim tamanoTallaInicial As Int32 = txtTallaInicio.Value.ToString.Length
            Dim tallaInicioCadena As String = ""
            Dim tamanoTallaFinal As Int32 = txtTallaFin.Value.ToString.Length
            Dim tallaFinalCadena As String = ""

            If (tamanoTallaInicial > 1) Then
                If (txtTallaInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                    tallaInicioCadena = txtTallaInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                Else
                    tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                End If
            Else
                tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
            End If

            If (tamanoTallaFinal > 1) Then
                If (txtTallaFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                    tallaFinalCadena = txtTallaFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                Else
                    tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                End If
            Else
                tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
            End If

            txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
        Else
            txtTallaFin.Value = 1D
        End If
    End Sub

    Private Sub txtTallaInicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTallaInicio.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtTallaInicio.Value = CDec(txtTallaInicio.Value)
            If (txtTallaInicio.Value >= 1) Then
                Dim validaPunto As Boolean = True
                Dim cadenaText As Int32 = Len(txtTallaInicio.Value.ToString)
                If (cadenaText > 2) Then
                    If (txtTallaInicio.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                        If Not (txtTallaInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                            validaPunto = False
                            Dim dato As String = txtTallaInicio.Value.ToString.Substring(0, cadenaText - 2)
                            txtTallaInicio.Value = dato + ".5"
                        End If
                    End If
                End If
                Dim tamanoTallaInicial As Int32 = txtTallaInicio.Value.ToString.Length
                Dim tallaInicioCadena As String = ""
                Dim tamanoTallaFinal As Int32 = txtTallaFin.Value.ToString.Length
                Dim tallaFinalCadena As String = ""

                If (tamanoTallaInicial > 1) Then
                    If (txtTallaInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                        tallaInicioCadena = txtTallaInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                    Else
                        tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                    End If
                Else
                    tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
                End If

                If (tamanoTallaFinal > 1) Then
                    If (txtTallaFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                        tallaFinalCadena = txtTallaFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                    Else
                        tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                    End If
                Else
                    tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
                End If

                txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
            Else
                txtTallaInicio.Value = 1
            End If
        End If
    End Sub

    Private Sub txtTallaInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTallaInicio.LostFocus
        Dim tamanoTallaInicial As Int32 = txtTallaInicio.Value.ToString.Length
        Dim tallaInicioCadena As String = ""
        Dim tamanoTallaFinal As Int32 = txtTallaFin.Value.ToString.Length
        Dim tallaFinalCadena As String = ""

        Dim cadenaText As Int32 = Len(txtTallaInicio.Value.ToString)
        If (cadenaText > 2) Then
            If (txtTallaInicio.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                If Not (txtTallaInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                    'If Not (txtTallaFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                    Dim dato As String = txtTallaInicio.Value.ToString.Substring(0, cadenaText - 2)
                    txtTallaInicio.Value = dato + ".5"
                End If
            End If
        End If

        If (tamanoTallaInicial > 1) Then
            If (txtTallaInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                tallaInicioCadena = txtTallaInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
            Else
                tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
            End If
        Else
            tallaInicioCadena = CStr(CInt(txtTallaInicio.Value.ToString))
        End If

        If (tamanoTallaFinal > 1) Then
            If (txtTallaFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                tallaFinalCadena = txtTallaFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
            Else
                tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
            End If
        Else
            tallaFinalCadena = CStr(CInt(txtTallaFin.Value.ToString))
        End If

        txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
    End Sub

    Private Sub grdTablaAmarre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTablaAmarre.CellEndEdit
        'If (grdTablaAmarre.IsCurrentCellDirty) Then
        '    grdTablaAmarre.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'End If
        If (ckbMedias.Checked = True) Then
            If (grdTablaAmarre.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing) Then
                If (e.RowIndex = 2) Then
                    grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                    grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0
                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0) Then

                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0) Then
                            If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value < grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) Then
                                grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                                'Else
                                '    grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value
                            End If
                        End If
                        If (grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0) Then
                            If (grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value < grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) Then
                                grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value)
                                'Else
                                '    grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value
                            End If
                        End If
                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value <> 0) Then
                            grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                            grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0
                        End If
                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0 And grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0) Then
                            grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value)
                        End If
                    Else
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0
                    End If
                ElseIf (e.RowIndex = 3) Then
                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0) Then

                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <= grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) Then
                            grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value)
                        Else
                            grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value) + CInt(grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value)
                        End If

                    Else
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0
                    End If

                ElseIf (e.RowIndex = 4) Then

                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0) Then
                        If (grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value <= grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) Then
                            grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value)
                        Else
                            grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value) + CInt(grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value)

                        End If
                    Else
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0
                    End If

                End If
            Else
                grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                grdTablaAmarre.Rows(4).Cells(e.ColumnIndex).Value = 0
            End If
        End If

        Dim suma As Int32 = 0
        For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
            suma = suma + CInt(grdTablaAmarre.Rows(2).Cells(columna.Index).Value)
        Next
        lblTotalPares.Text = suma.ToString
        If Not (suma = 12 Or suma = 0) Then
            lblTotalPares.ForeColor = Color.Red
        Else
            lblTotalPares.ForeColor = Color.Black
        End If

    End Sub

    Private Sub grdTablaAmarre_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTablaAmarre.CellValueChanged


    End Sub


    Private Sub grdTablaAmarre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdTablaAmarre.KeyPress
        Dim columnIndex As Integer = grdTablaAmarre.CurrentCell.ColumnIndex()
        Try
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ".") Then
                If caracter = "." And txt.Text.Contains(".") = True Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "-") Or (caracter = "½") Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtDescripcion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtCodSicy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 10) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "-") Or caracter = "½") Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validarAmarre()
    End Sub

    Private Sub txtTallaCentral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTallaCentral.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtTallaCentral.Value = CDec(txtTallaCentral.Value)
            If (txtTallaCentral.Value >= 1) Then
                Dim validaPunto As Boolean = True
                Dim cadenaText As Int32 = Len(txtTallaCentral.Value.ToString)
                If (cadenaText > 2) Then
                    If (txtTallaCentral.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                        If Not (txtTallaCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                            validaPunto = False
                            Dim dato As String = txtTallaCentral.Value.ToString.Substring(0, cadenaText - 2)
                            txtTallaCentral.Value = dato + ".5"
                        End If
                    End If
                End If
            Else
                txtTallaCentral.Value = 1
            End If
        End If
    End Sub

    Private Sub txtTallaCentral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTallaCentral.LostFocus
        Dim cadenaText As Int32 = Len(txtTallaCentral.Value.ToString)
        If (CInt(txtTallaCentral.Value) >= 1) Then
            If (cadenaText > 2) Then
                If (txtTallaCentral.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                    If Not (txtTallaCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtTallaCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                        Dim dato As String = txtTallaCentral.Value.ToString.Substring(0, cadenaText - 2)
                        txtTallaCentral.Value = dato + ".5"
                    End If
                End If
            End If
        Else
            txtTallaCentral.Value = 1
        End If
    End Sub

    Private Sub txtTallaInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTallaInicio.ValueChanged
        'chkEntero.Checked = True
        lblTotalPares.Text = "0"
        lblTotalPares.ForeColor = Color.Black
        movimientoTabla()
    End Sub

    Private Sub txtTallaFin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTallaFin.ValueChanged
        'chkEntero.Checked = True
        lblTotalPares.Text = "0"
        lblTotalPares.ForeColor = Color.Black
        movimientoTabla()

    End Sub

    Private Sub txtTallaCentral_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTallaCentral.ValueChanged
        'chkEntero.Checked = False
        'ckbMedias.Checked = False

    End Sub

    Public Sub movimientoTabla()

        'ckbMedias.Checked = False
        If (txtTallaFin.Value > txtTallaInicio.Value) Then

            Dim mensaje As New AdvertenciaForm
            Dim mensajeExito As New ExitoForm
            Dim n As Int32 = 0

            Dim tinicio As String = txtTallaInicio.Value.ToString()
            Dim tfin As String = txtTallaFin.Value.ToString()
            Dim inicioTalla As Decimal = Convert.ToDecimal(tinicio)
            Dim finTalla As Decimal = Convert.ToDecimal(tfin)
            Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            Dim contPasos As Int32 = 1
            Dim dtAmarre As New DataTable
            Dim dtColumnAmarre As New DataColumn

            If (finTalla >= inicioTalla) Then
                If (chkEntero.Checked = False) Then
                    Dim recorre As Integer = 1
                    Dim contador As Integer = 0
                    Dim resta As Decimal = finTalla - inicioTalla
                    Dim pasos As Integer = resta / 0.5
                    Dim tallasNuevas As Decimal = inicioTalla
                    Dim tamanoTallaInicial As Int32 = txtTallaInicio.Value.ToString.Length
                    Dim tallaInicioCadena As String = ""
                    Dim tamanoTallaFinal As Int32 = txtTallaFin.Value.ToString.Length
                    Dim tallaFinalCadena As String = ""
                    Dim tamanoTallaCentral As Int32 = txtTallaCentral.Value.ToString.Length
                    Dim tallaCentralCadena As String = ""

                    If (pasos < 20) Then
                        Dim datoTalla As String = ""
                        Dim tamanoCadena As Int32 = 0

                        grdTablaAmarre.ColumnCount = pasos + 1

                        For columnaA As Int32 = 0 To pasos
                            grdTablaAmarre.Columns(columnaA).HeaderText = "T" + contPasos.ToString
                            CType(Me.grdTablaAmarre.Columns(columnaA), DataGridViewTextBoxColumn).MaxInputLength = 5
                            'grdTablaAmarre.Columns(columnaA).Width = 50
                            contPasos = contPasos + 1
                        Next

                        grdTablaAmarre.RowCount = 5
                        Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "MÉXICO"
                        Me.grdTablaAmarre.Rows(1).HeaderCell.Value = cmbPaises.Text
                        Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Total"
                        Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 1"
                        Me.grdTablaAmarre.Rows(4).HeaderCell.Value = "Media 2"

                        grdTablaAmarre.RowHeadersWidth = 150


                        grdTablaAmarre.Rows(2).DefaultCellStyle.ForeColor = Color.Black
                        If (ckbMedias.Checked = False) Then
                            Me.grdTablaAmarre.Rows(3).Visible = False
                            Me.grdTablaAmarre.Rows(4).Visible = False
                        End If
                        If cmbPaises.Text.Equals("MÉXICO") Or cmbPaises.Text.Equals("") Then
                            Me.grdTablaAmarre.Rows(1).Visible = False
                        Else
                            Me.grdTablaAmarre.Rows(2).Visible = False
                        End If

                        grdTablaAmarre.Rows(0).ReadOnly = True
                        grdTablaAmarre.Rows(2).DefaultCellStyle.BackColor = Drawing.SystemColors.ControlLight

                        For recorre = 1 To pasos + 1
                            tamanoCadena = tallasNuevas.ToString.Length
                            If (tamanoCadena > 1) Then
                                If (tallasNuevas.ToString.Substring(tamanoCadena - 2, 2) = ".5") Then
                                    datoTalla = tallasNuevas.ToString.Substring(0, tamanoCadena - 2) + "½"
                                Else
                                    datoTalla = CStr(CInt(tallasNuevas.ToString))
                                End If
                            Else
                                datoTalla = CStr(CInt(tallasNuevas.ToString))
                            End If

                            grdTablaAmarre.Item(n, 0).Value = datoTalla
                            grdTablaAmarre.Item(n, 1).Value = 0
                            grdTablaAmarre.Item(n, 2).Value = 0
                            grdTablaAmarre.Item(n, 3).Value = 0
                            grdTablaAmarre.Item(n, 4).Value = 0
                            n = n + 1
                            tallasNuevas = tallasNuevas + 0.5
                        Next
                    Else
                        mensaje.mensaje = "No puede registrar mas de 20 tallas en una descripción."
                        mensaje.ShowDialog()
                    End If

                ElseIf (chkEntero.Checked = True) Then
                    If (Math.Round(inicioTalla) <= Math.Round(finTalla)) Then

                        Dim recorre As Int32 = 1
                        Dim contador As Int32 = 0
                        Dim tallasNuevas As Decimal = Math.Round(inicioTalla)
                        Dim resta As Int32 = Math.Round(finTalla) - Math.Round(inicioTalla)
                        Dim cadena As String = Math.Round(inicioTalla).ToString
                        Dim inicio As Int32 = Math.Round(inicioTalla)
                        Dim fin As Int32 = Math.Round(finTalla)

                        If (resta <= 20) Then
                            Dim datoTalla As String = ""
                            grdTablaAmarre.ColumnCount = resta + 1
                            For columnaA As Int32 = 0 To resta
                                grdTablaAmarre.Columns(columnaA).HeaderText = "T" + contPasos.ToString
                                CType(Me.grdTablaAmarre.Columns(columnaA), DataGridViewTextBoxColumn).MaxInputLength = 2
                                'grdTablaAmarre.Columns(columnaA).Width = 50
                                contPasos = contPasos + 1
                            Next
                            grdTablaAmarre.RowCount = 5
                            Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "MÉXICO"
                            Me.grdTablaAmarre.Rows(1).HeaderCell.Value = cmbPaises.Text
                            Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Total"
                            Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 1"
                            Me.grdTablaAmarre.Rows(4).HeaderCell.Value = "Media 2"

                            grdTablaAmarre.Rows(2).DefaultCellStyle.ForeColor = Color.Black
                            If (ckbMedias.Checked = False) Then
                                Me.grdTablaAmarre.Rows(3).Visible = False
                                Me.grdTablaAmarre.Rows(4).Visible = False
                            End If
                            If cmbPaises.Text.Equals("MÉXICO") Or cmbPaises.Text.Equals("") Then
                                Me.grdTablaAmarre.Rows(1).Visible = False
                            Else
                                Me.grdTablaAmarre.Rows(2).Visible = False
                            End If


                            grdTablaAmarre.Rows(0).ReadOnly = True
                            grdTablaAmarre.Rows(2).DefaultCellStyle.BackColor = Drawing.SystemColors.ControlLight
                            For recorre = 1 To resta + 1
                                If recorre = 21 Then
                                    Exit For
                                End If
                                datoTalla = CStr(CInt(tallasNuevas))
                                grdTablaAmarre.Item(n, 0).Value = datoTalla
                                grdTablaAmarre.Item(n, 1).Value = 0
                                grdTablaAmarre.Item(n, 2).Value = 0
                                grdTablaAmarre.Item(n, 3).Value = 0
                                grdTablaAmarre.Item(n, 4).Value = 0
                                tallasNuevas = tallasNuevas + 1
                                n = n + 1
                            Next
                        Else
                            ckbMedias.Checked = False
                            mensaje.mensaje = "No pueden generarse mas de 20 tallas en una descripción."
                            mensaje.ShowDialog()
                        End If
                    ElseIf (Math.Round(inicioTalla) > Math.Round(finTalla)) Then
                        ckbMedias.Checked = False
                        mensaje.mensaje = "La talla de inicio no puede ser mayor a la talla final."
                        mensaje.ShowDialog()
                    End If
                End If
            ElseIf (finTalla < inicioTalla) Then
                ckbMedias.Checked = False
                mensaje.mensaje = "La talla de inicio no puede ser mayor a la talla final."
                mensaje.ShowDialog()
            End If
        Else
            grdTablaAmarre.Rows.Clear()
            grdTablaAmarre.Columns.Clear()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub cmbTallaPrincipal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTallaPrincipal.SelectedIndexChanged
        llenarTallaInicioFin()

        'Se cambia el ValueMember a talla_enteros para marcar el checkbox o desmarcarlo dependiendo el valor y despues se regresa al original.
        cmbTallaPrincipal.ValueMember = "talla_enteros"
        verificarEntero(cmbTallaPrincipal.SelectedValue.ToString)

        cmbTallaPrincipal.ValueMember = "talla_sicy"
        txtCodSicy.Text = cmbTallaPrincipal.SelectedValue.ToString

        cmbTallaPrincipal.ValueMember = "talla_tallaid"
    End Sub

    '01/12/16 Marco Arredondo COMIENZA
    'Función para llenar automaticamente las cajas de texto de talla inicio, talla fin y talla central
    Public Sub llenarTallaInicioFin()
        Dim tallaBase, tallaInicio, tallaFin As String

        tallaBase = cmbTallaPrincipal.Text

        If tallaBase.Length > 0 And tallaBase.Length < 18 Then

            'Calculo de las tallas de acuerdo al valor del ComboBox guardado en tallaBase
            tallaInicio = tallaBase.Substring(0, tallaBase.IndexOf("-"))
            tallaFin = tallaBase.Substring(tallaBase.IndexOf("-") + 1, tallaBase.IndexOf(" ") - 1)

            txtTallaInicio.Value = tallaInicio.Replace("½", ".5")
            txtTallaFin.Value = tallaFin.Replace("½", ".5")

            'Cálculo de la talla central, se toman dos caracteres solamente, al final se remplaza el valor decimal .5 con el ½ para conservar el formato.
            txtTallaCentral.Value = CInt(tallaInicio.Replace("½", ".0")) + ((CInt(tallaFin.Replace("½", ".0")) - CInt(tallaInicio.Replace("½", ".0"))) / 2)
            'txtTallaCentral.Value = txtTallaCentral.Text


        End If

    End Sub

    Public Sub verificarEntero(ByVal tallaEnteros As String)
        If (tallaEnteros.Equals("True")) Then
            chkEntero.Checked = True
        Else
            chkEntero.Checked = False
        End If
    End Sub

    Private Sub cmbPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaises.SelectedIndexChanged
        'Activación y desactivación de controles dependiendo si la corrida es mexicana 
        If cmbPaises.Text.Equals("MÉXICO") Or cmbPaises.Text.Equals("") Then
            cmbTallaPrincipal.Enabled = False
            cmbTallaPrincipal.Text = ""
            txtDescripcion.Text = ""
            txtDescripcion.Enabled = False
            chkEntero.Enabled = True
            ckbMedias.Enabled = True
            txtTallaInicio.Enabled = True
            txtTallaCentral.Enabled = True
            txtTallaFin.Enabled = True
            txtCodSicy.Enabled = True
        Else
            cmbTallaPrincipal.Enabled = True
            txtDescripcion.Text = ""
            txtDescripcion.Enabled = True
            chkEntero.Checked = False
            chkEntero.Enabled = False
            ckbMedias.Checked = False
            ckbMedias.Enabled = False
            txtTallaInicio.Enabled = False
            txtTallaCentral.Enabled = False
            txtTallaFin.Enabled = False
            'txtTallaFin.Value = 1
            'txtTallaCentral.Value = 1
            'txtTallaInicio.Value = 1
            txtCodSicy.Enabled = False

        End If
        If cmbTallaPrincipal.Items.Count > 0 Then
            cmbTallaPrincipal.SelectedIndex = 0
        End If
        'txtCodSicy.Text = ""
        txtTallaFin.Value = 1
        txtTallaCentral.Value = 1
        txtTallaInicio.Value = 1

        movimientoTabla()

    End Sub


End Class