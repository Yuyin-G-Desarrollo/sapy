Imports Tools

Public Class EditarTallaForm
    Dim dtDatosTallaEditar As DataTable
    Dim dtDatosComboPaises As DataTable
    Dim dtDatosComboTallas As DataTable
    Dim dtTallaInicial As DataTable
    Dim dtTallaInicialComit As DataTable
    Public idTalla As Int32
    Dim T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20 As String
    Dim EnterosInicio As Boolean
    Dim InicioInicial, FinInicial, centralInicial As String
    Dim idTallaInicialSeleccion As String
    Dim IniTXT, FinTXT, cenTXT As String
    Public nombrePais As String
    Public editando As Integer


    Public Sub TraerDatosTallaEditar()
        Dim TallaNegocio As New Programacion.Negocios.TallasBU

        dtDatosTallaEditar = TallaNegocio.verDatosTallaEditar(idTalla)

        grdTallas.DataSource = dtDatosTallaEditar
        Dim CentralDecimal As String = dtDatosTallaEditar.Rows(0)(25).ToString
        Dim InicialDecimal As String = dtDatosTallaEditar.Rows(0)("Inicio").ToString
        Dim FinDecimal As String = dtDatosTallaEditar.Rows(0)("Fin").ToString
        Dim tamanoCentral As Int32 = 0
        Dim tamanoInicial As Int32 = 0
        Dim tamanoFinal As Int32 = 0
        Dim centralD As Decimal = 0.0
        Dim InicialD As Decimal = 0.0
        Dim FinD As Decimal = 0.0
        Dim cadenaLimpiar As String
        txtCodSicy.Text = dtDatosTallaEditar.Rows(0)("talla_sicy").ToString

        cadenaLimpiar = CentralDecimal
        For Each caracter As Char In cadenaLimpiar.ToCharArray()
            If caracter <> "½" And IsNumeric(caracter) = False Then
                CentralDecimal = CentralDecimal.Replace(caracter, "")
            End If
        Next

        tamanoCentral = CentralDecimal.Length
        If (tamanoCentral > 1) Then
            If (CentralDecimal.ToString.Substring(tamanoCentral - 1, 1) = "½") Then
                centralD = CentralDecimal.ToString.Substring(0, tamanoCentral - 1) + ".5"
            Else
                centralD = CDec(CInt(CentralDecimal.ToString))
            End If
        Else
            centralD = CDec(CInt(If(CentralDecimal.ToString = "", "0", CentralDecimal.ToString)))
        End If

        cadenaLimpiar = InicialDecimal
        For Each caracter As Char In cadenaLimpiar.ToCharArray()
            If caracter <> "½" And IsNumeric(caracter) = False Then
                InicialDecimal = InicialDecimal.Replace(caracter, "")
            End If
        Next

        tamanoInicial = InicialDecimal.Length
        If (tamanoInicial > 1) Then
            If (InicialDecimal.ToString.Substring(tamanoInicial - 1, 1) = "½") Then
                InicialD = InicialDecimal.ToString.Substring(0, tamanoInicial - 1) + ".5"
            Else
                InicialD = CDec(CInt(InicialDecimal.ToString))
            End If
        Else
            InicialD = CDec(CInt(If(InicialDecimal.ToString = "", "0", InicialDecimal.ToString)))
        End If

        cadenaLimpiar = FinDecimal
        For Each caracter As Char In cadenaLimpiar.ToCharArray()
            If caracter <> "½" And IsNumeric(caracter) = False Then
                FinDecimal = FinDecimal.Replace(caracter, "")
            End If
        Next

        tamanoFinal = FinDecimal.Length
        If (tamanoFinal > 1) Then
            If (FinDecimal.ToString.Substring(tamanoFinal - 1, 1) = "½") Then
                FinD = FinDecimal.ToString.Substring(0, tamanoFinal - 1) + ".5"
            Else
                FinD = CDec(CInt(FinDecimal.ToString))
            End If
        Else
            FinD = CDec(CInt(If(FinDecimal.ToString = "", "0", FinDecimal.ToString)))
        End If

        If centralD = 0 Then
            centralD = ((FinD - InicialD) / 2) + InicialD
        End If

        If centralD - Int(centralD) <> 0.5 And centralD - Int(centralD) > 0 Then
            centralD = Int(centralD) + 0.5
        End If

        txtCentral.Value = centralD
        txtInicio.Value = InicialD
        txtFin.Value = FinD
        txtDescripcion.Text = dtDatosTallaEditar.Rows(0)(1).ToString

        'txtGrupo.Text = dtDatosTallaEditar.Rows(0)("Grupo").ToString
        cmbPaises.SelectedValue = dtDatosTallaEditar.Rows(0)("pais").ToString
        EnterosInicio = dtDatosTallaEditar.Rows(0)("EnterosT").ToString
        InicioInicial = InicialDecimal
        FinInicial = FinDecimal
        centralInicial = CentralDecimal
        IniTXT = centralD
        FinTXT = InicialD
        cenTXT = FinD

        Try
            cmbTallaPrincipal.SelectedValue = dtDatosTallaEditar.Rows(0)("tallabase").ToString
            idTallaInicialSeleccion = dtDatosTallaEditar.Rows(0)("tallabase").ToString()
        Catch ex As Exception
        End Try
        If (dtDatosTallaEditar.Rows(0)("activo") = True) Then
            rdoActivo.Checked = True
        Else
            rdoInactivo.Checked = True
        End If
        If (dtDatosTallaEditar.Rows(0)("EnterosT").ToString = "True") Then
            chkEnteros.Checked = True
        ElseIf (dtDatosTallaEditar.Rows(0)("EnterosT").ToString = "False") Then
            chkEnteros.Checked = False
        End If
        grdTallas.Columns("Talla").Visible = False
        grdTallas.Columns("Inicio").Visible = False
        grdTallas.Columns("Fin").Visible = False
        grdTallas.Columns("Tallabase").Visible = False
        grdTallas.Columns("talla_tallaid").Visible = False
        grdTallas.Columns("talla_tallacentral").Visible = False
        grdTallas.Columns("Grupo").Visible = False
        grdTallas.Columns("pais").Visible = False
        grdTallas.Columns("activo").Visible = False
        grdTallas.Columns("EnterosT").Visible = False
        grdTallas.Columns("talla_sicy").Visible = False
        grdTallas.Columns(0).Visible = False

        If (idTallaInicialSeleccion <> "") Then
            dtTallaInicial = TallaNegocio.verTallaInicialSeleccionada(idTallaInicialSeleccion)
            grdTallaInicial.DataSource = dtTallaInicial
            grdTallaInicial.Columns("Talla").Visible = False
            grdTallaInicial.Columns("Inicio").Visible = False
            grdTallaInicial.Columns("Fin").Visible = False
            grdTallaInicial.Columns("Tallabase").Visible = False
            grdTallaInicial.Columns("talla_tallaid").Visible = False
            grdTallaInicial.Columns("talla_tallacentral").Visible = False
            grdTallaInicial.Columns("Grupo").Visible = False
            grdTallaInicial.Columns("pais").Visible = False
            grdTallaInicial.Columns("activo").Visible = False
            grdTallaInicial.Columns("EnterosT").Visible = False
            grdTallas.Columns("talla_sicy").Visible = False
            grdTallaInicial.Columns(0).Visible = False
        End If

    End Sub


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

    Public Sub LlenarDatosRestaurar()
        T1 = grdTallas.Item(5, 0).Value.ToString
        T2 = grdTallas.Item(6, 0).Value.ToString
        T3 = grdTallas.Item(7, 0).Value.ToString
        T4 = grdTallas.Item(8, 0).Value.ToString
        T5 = grdTallas.Item(9, 0).Value.ToString
        T6 = grdTallas.Item(10, 0).Value.ToString
        T7 = grdTallas.Item(11, 0).Value.ToString
        T8 = grdTallas.Item(12, 0).Value.ToString
        T9 = grdTallas.Item(13, 0).Value.ToString
        T10 = grdTallas.Item(14, 0).Value.ToString
        T11 = grdTallas.Item(15, 0).Value.ToString
        T12 = grdTallas.Item(16, 0).Value.ToString
        T13 = grdTallas.Item(17, 0).Value.ToString
        T14 = grdTallas.Item(18, 0).Value.ToString
        T15 = grdTallas.Item(19, 0).Value.ToString
        T16 = grdTallas.Item(20, 0).Value.ToString
        T17 = grdTallas.Item(21, 0).Value.ToString
        T18 = grdTallas.Item(22, 0).Value.ToString
        T19 = grdTallas.Item(23, 0).Value.ToString
        T20 = grdTallas.Item(24, 0).Value.ToString
    End Sub

    Public Sub RestaurarDatos()
        If (EnterosInicio = True) Then
            chkEnteros.Checked = True
        Else
            chkEnteros.Checked = True
        End If

        txtInicio.Value = InicioInicial
        txtFin.Value = FinInicial
        txtCentral.Value = centralInicial
        grdTallas.Item(5, 0).Value = T1
        grdTallas.Item(6, 0).Value = T2
        grdTallas.Item(7, 0).Value = T3
        grdTallas.Item(8, 0).Value = T4
        grdTallas.Item(9, 0).Value = T5
        grdTallas.Item(10, 0).Value = T6
        grdTallas.Item(11, 0).Value = T7
        grdTallas.Item(12, 0).Value = T8
        grdTallas.Item(13, 0).Value = T9
        grdTallas.Item(14, 0).Value = T10
        grdTallas.Item(15, 0).Value = T11
        grdTallas.Item(16, 0).Value = T12
        grdTallas.Item(17, 0).Value = T13
        grdTallas.Item(18, 0).Value = T14
        grdTallas.Item(19, 0).Value = T15
        grdTallas.Item(20, 0).Value = T16
        grdTallas.Item(21, 0).Value = T17
        grdTallas.Item(22, 0).Value = T18
        grdTallas.Item(23, 0).Value = T19
        grdTallas.Item(24, 0).Value = T20
    End Sub
    Public Sub CambiosGrid()
        Dim TInicio As Decimal = txtInicio.Value
        Dim TFin As Decimal = txtFin.Value
        Dim TCentral As Decimal = txtCentral.Value
        Dim mensaje As New AdvertenciaForm

        If (TCentral > TInicio Or TCentral < TFin) Then
            If (TInicio < TFin) Then
                If (chkEnteros.Checked = True) Then
                    Dim Inicio As Decimal = txtInicio.Value
                    Dim Fin As Decimal = txtFin.Value
                    Dim Central As Decimal = txtCentral.Value
                    txtInicio.Value = Math.Floor(Inicio)
                    txtFin.Value = Math.Floor(Fin)
                    txtCentral.Value = Math.Floor(Central)
                    Dim Descripcion As String = String.Empty
                    Dim recorre As Int32 = 5
                    Dim contador As Int32 = 0
                    Dim tallasNuevas As Decimal = Math.Floor(Inicio)
                    Dim resta As Int32 = Math.Floor(Fin) - Math.Floor(Inicio)
                    Dim cadena As String = Math.Floor(Inicio).ToString
                    Dim inicial As Int32 = Math.Floor(Inicio)
                    Dim final As Int32 = Math.Floor(Fin)
                    Descripcion = txtDescripcion.Text
                    If (chkEnteros.Checked = False) Then
                        resta = resta * 2
                    End If

                    If (resta < 20) Then


                        Dim EspacioBorrar As Int32 = 1
                        Dim DatoTalla As Int32 = inicial
                        Dim Espacio As Int32 = 1
                        For ForBorra As Int32 = 1 To 20
                            grdTallas.Item("T" + EspacioBorrar.ToString, 0).Value = String.Empty
                            EspacioBorrar = EspacioBorrar + 1
                        Next
                        For recorre = 5 To resta + 5
                            grdTallas.Item("T" + Espacio.ToString, 0).Value = CStr(CInt(DatoTalla))
                            DatoTalla = DatoTalla + 1
                            Espacio = Espacio + 1
                        Next
                    Else
                        RestaurarDatos()
                        mensaje.mensaje = "No puede registrar mas de 20 tallas en una descripción." + vbNewLine + vbNewLine + "Revise que las tallas generadas entre la talla de inicio y fin no sean más de 20."
                        mensaje.ShowDialog()

                    End If
                ElseIf (chkEnteros.Checked = False) Then
                    Dim Inicio As Decimal = txtInicio.Value
                    Dim Fin As Decimal = txtFin.Value
                    Dim Central As Decimal = txtCentral.Value
                    'Dim Descripcion As String = String.Empty
                    Dim recorre As Int32 = 5
                    Dim contador As Int32 = 0
                    Dim resta As Decimal = Fin - Inicio
                    Dim pasos As Integer = resta / 0.5

                    If (pasos < 20) Then
                        Dim EspacioBorrar As Int32 = 1
                        Dim DatoTalla As Decimal = Inicio
                        Dim Espacio As Int32 = 1

                        For ForBorra As Int32 = 1 To 20
                            grdTallas.Item("T" + EspacioBorrar.ToString, 0).Value = String.Empty
                            EspacioBorrar = EspacioBorrar + 1
                        Next

                        Dim tamanoCadena As Int32 = 0
                        Dim cadenaTallas As String = ""

                        For recorre = 5 To pasos + 5

                            tamanoCadena = DatoTalla.ToString.Length
                            If (tamanoCadena > 1) Then
                                If (DatoTalla.ToString.Substring(tamanoCadena - 2, 2) = ".5") Then
                                    cadenaTallas = DatoTalla.ToString.Substring(0, tamanoCadena - 2) + "½"
                                Else
                                    cadenaTallas = CStr(CInt(DatoTalla.ToString))
                                End If
                            Else
                                cadenaTallas = CStr(CInt(DatoTalla.ToString))
                            End If

                            grdTallas.Item("T" + Espacio.ToString, 0).Value = cadenaTallas
                            DatoTalla = DatoTalla + 0.5
                            Espacio = Espacio + 1
                        Next

                    Else
                        RestaurarDatos()
                        mensaje.mensaje = "No puede registrar mas de 20 tallas en una descripción." + vbNewLine + vbNewLine + "Revise que las tallas generadas entre la talla de inicio y fin no sean más de 20. "
                        mensaje.ShowDialog()

                    End If
                End If
            Else
                mensaje.mensaje = "La talla de inicio no puede ser mayor a la talla final."
                mensaje.ShowDialog()
            End If
        Else
            mensaje.mensaje = "La talla central debe estar entre la talla inicio y la talla final."
            mensaje.ShowDialog()
        End If


    End Sub

    Public Sub EnviarEditar()
        Dim mensaje As New AdvertenciaForm

        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim TallaNegocio As New Programacion.Negocios.TallasBU
        Dim EntidadTalla As New Entidades.Tallas
        EntidadTalla.PTallaID = grdTallas.Item("talla_tallaid", 0).Value.ToString


        Dim tamanoTallaInicial As Int32 = txtInicio.Value.ToString.Length
        Dim tallaInicioCadena As String = ""
        Dim tamanoTallaFinal As Int32 = txtFin.Value.ToString.Length
        Dim tallaFinalCadena As String = ""
        Dim tamanoTallaCentral As Int32 = txtCentral.Value.ToString.Length
        Dim tallaCentralCadena As String = ""



        If (tamanoTallaInicial > 1) Then
            If (txtInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                tallaInicioCadena = txtInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
            Else
                tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
            End If
        Else
            tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
        End If
        EntidadTalla.PTallaInicio = tallaInicioCadena

        If (tamanoTallaFinal > 1) Then
            If (txtFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                tallaFinalCadena = txtFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
            Else
                tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
            End If
        Else
            tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
        End If
        EntidadTalla.PTallaFin = tallaFinalCadena


        If (tamanoTallaCentral > 1) Then
            If (txtCentral.Value.ToString.Substring(tamanoTallaCentral - 2, 2) = ".5") Then
                tallaCentralCadena = txtCentral.Value.ToString.Substring(0, tamanoTallaCentral - 2) + "½"
            Else
                tallaCentralCadena = CStr(CInt(txtCentral.Value.ToString))
            End If
        Else
            tallaCentralCadena = CStr(CInt(txtCentral.Value.ToString))
        End If
        EntidadTalla.PTallaCentral = tallaCentralCadena

        EntidadTalla.PTDescripcion = txtDescripcion.Text

        EntidadTalla.PTallaCentral = txtCentral.Value.ToString

        'EntidadTalla.PTallaInicio = txtInicio.Value.ToString
        'EntidadTalla.PTallaFin = txtFin.Value.ToString
        EntidadTalla.PTalla1 = grdTallas.Item("T1", 0).Value.ToString
        EntidadTalla.PTalla2 = grdTallas.Item("T2", 0).Value.ToString
        EntidadTalla.PTalla3 = grdTallas.Item("T3", 0).Value.ToString
        EntidadTalla.PTalla4 = grdTallas.Item("T4", 0).Value.ToString
        EntidadTalla.PTalla5 = grdTallas.Item("T5", 0).Value.ToString
        EntidadTalla.PTalla6 = grdTallas.Item("T6", 0).Value.ToString
        EntidadTalla.PTalla7 = grdTallas.Item("T7", 0).Value.ToString
        EntidadTalla.PTalla8 = grdTallas.Item("T8", 0).Value.ToString
        EntidadTalla.PTalla9 = grdTallas.Item("T9", 0).Value.ToString
        EntidadTalla.PTalla10 = grdTallas.Item("T10", 0).Value.ToString
        EntidadTalla.PTalla11 = grdTallas.Item("T11", 0).Value.ToString
        EntidadTalla.PTalla12 = grdTallas.Item("T12", 0).Value.ToString
        EntidadTalla.PTalla13 = grdTallas.Item("T13", 0).Value.ToString
        EntidadTalla.PTalla14 = grdTallas.Item("T14", 0).Value.ToString
        EntidadTalla.PTalla15 = grdTallas.Item("T15", 0).Value.ToString
        EntidadTalla.PTalla16 = grdTallas.Item("T16", 0).Value.ToString
        EntidadTalla.PTalla17 = grdTallas.Item("T17", 0).Value.ToString
        EntidadTalla.PTalla18 = grdTallas.Item("T18", 0).Value.ToString
        EntidadTalla.PTalla19 = grdTallas.Item("T19", 0).Value.ToString
        EntidadTalla.PTalla20 = grdTallas.Item("T20", 0).Value.ToString
        EntidadTalla.PTallaGrupo = txtGrupo.Text
        EntidadTalla.PSicyTalla = txtCodSicy.Text
        If (chkEnteros.Checked = True) Then
            EntidadTalla.PTEntero = True
        ElseIf (chkEnteros.Checked = False) Then
            EntidadTalla.PTEntero = False
        End If
        EntidadTalla.PTallaPais = cmbPaises.SelectedValue.ToString
        Try
            EntidadTalla.PTallaPrincipal = cmbTallaPrincipal.SelectedValue.ToString
        Catch ex As Exception

        End Try
        If (rdoActivo.Checked = True) Then
            EntidadTalla.PTAcvito = True
        ElseIf (rdoInactivo.Checked = True) Then
            EntidadTalla.PTAcvito = False
        End If

        TallaNegocio.EditarTallas(EntidadTalla, usuario)

    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtCentral.Value < 1 Or txtInicio.Value <= 0 Or txtFin.Value <= 0 Or txtCentral.Value.ToString = Nothing Or txtInicio.Value.ToString = Nothing Or txtFin.Value.ToString = Nothing Or cmbPaises.SelectedValue.ToString = Nothing Or txtDescripcion.Text = Nothing) Then

            'If (txtGrupo.Text = Nothing) Then
            '    lblGrupo.ForeColor = Drawing.Color.Red
            'Else
            '    lblGrupo.ForeColor = Drawing.Color.Black
            'End If
            If (txtDescripcion.Text = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblCentral.ForeColor = Drawing.Color.Black
            End If

            If (txtCentral.Value < 1 Or txtCentral.Value.ToString = Nothing) Then
                lblCentral.ForeColor = Drawing.Color.Red
            Else
                lblCentral.ForeColor = Drawing.Color.Black
            End If

            If (txtInicio.Value < 1 Or txtInicio.Value.ToString = Nothing) Then
                lblInicio.ForeColor = Drawing.Color.Red
            Else
                lblInicio.ForeColor = Drawing.Color.Black
            End If

            If (txtFin.Value < 1 Or txtFin.Value.ToString = Nothing) Then
                lblFin.ForeColor = Drawing.Color.Red
            Else
                lblFin.ForeColor = Drawing.Color.Black
            End If

            If (cmbPaises.SelectedValue.ToString = Nothing) Then
                lblPais.ForeColor = Drawing.Color.Red
            Else
                lblPais.ForeColor = Drawing.Color.Black
            End If

            Return False
        Else

            lblGrupo.ForeColor = Drawing.Color.Black
            lblInicio.ForeColor = Drawing.Color.Black
            lblCentral.ForeColor = Drawing.Color.Black
            lblFin.ForeColor = Drawing.Color.Black
            lblPais.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function

    Public Sub guardarAmarre()
        Dim objTallaBU As New Programacion.Negocios.TallasBU
        Dim dtIdTallaMax As New DataTable
        dtIdTallaMax = objTallaBU.VerIdMaximoTalla
        Dim idTallaEditar As Int32 = idTalla
        Dim tamTabAmarre As Int32 = grdTablaAmarre.ColumnCount

        objTallaBU.AlterarAmarresBU(idTalla)

        For n As Int32 = 0 To tamTabAmarre - 1
            'MsgBox("Id: " + idTallaMax.ToString + "   Descripcion: " + grdTablaAmarre.Item(n, 0).Value.ToString + "    Amarre1: " + grdTablaAmarre.Item(n, 2).Value.ToString + "    Amarre2: " + grdTablaAmarre.Item(n, 3).Value.ToString)
            objTallaBU.AltaAmarreBU(idTallaEditar, grdTablaAmarre.Item(n, 0).Value.ToString, CInt(grdTablaAmarre.Item(n, 2).Value.ToString), CInt(grdTablaAmarre.Item(n, 3).Value.ToString), Convert.ToInt32(grdTablaAmarre.Item(n, 1).Value.ToString))
        Next
        objTallaBU.AltaAmarreSicy(idTallaEditar)
    End Sub

    Private Sub grdTablaAmarre_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdTablaAmarre.EditingControlShowing
        Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
        AddHandler ValidaEntradaDatos.KeyPress, AddressOf grdTablaAmarre_KeyPress
    End Sub

    Private Sub grdTablaAmarre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdTablaAmarre.KeyPress
        Dim columnIndex As Integer = grdTablaAmarre.CurrentCell.ColumnIndex()
        Try
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub verTallaAmarre()

        Dim contMedias As Int32 = 0
        Dim objTalla As New Programacion.Negocios.TallasBU
        Dim dtDatosAmarreExiste As New DataTable
        dtDatosAmarreExiste = objTalla.VerAmarreExisteTalla(idTalla)

        For Each rowDtAmr As DataRow In dtDatosAmarreExiste.Rows
            If Not (rowDtAmr.Item(0).ToString = Nothing) Then
                contMedias = contMedias + 1
            End If
            If Not (rowDtAmr.Item(1).ToString = Nothing) Then
                contMedias = contMedias + 1
            End If
        Next

        If (contMedias > 0) Then
            ckbMedias.Checked = True
        Else
            ckbMedias.Checked = False
        End If

        cambioMediaChek()
        If (dtDatosAmarreExiste.Rows.Count > 0) Then
            Dim recorre As Int32 = 0
            For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
                If (ckbMedias.Checked = True) Then
                    grdTablaAmarre.Item(columna.Index, 2).Value = dtDatosAmarreExiste.Rows(recorre)(0).ToString
                    grdTablaAmarre.Item(columna.Index, 3).Value = dtDatosAmarreExiste.Rows(recorre)(1).ToString
                End If
                grdTablaAmarre.Item(columna.Index, 1).Value = dtDatosAmarreExiste.Rows(recorre)(2).ToString
                recorre = recorre + 1
                If (ckbMedias.Checked = False) Then
                    grdTablaAmarre.Rows(2).Visible = False
                    grdTablaAmarre.Rows(3).Visible = False
                End If
            Next
            Dim sumaTotal As Int32 = 0
            For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
                If Not (grdTablaAmarre.Rows(1).Cells(columna.Index).Value = Nothing) Then
                    sumaTotal = sumaTotal + CInt(grdTablaAmarre.Rows(1).Cells(columna.Index).Value)
                End If
            Next
            lblTotalPares.Text = sumaTotal.ToString

        End If

    End Sub

    Public Function validarAmarre() As Boolean
        Dim sumaAm As Int32 = 0
        Dim sumaAmDos As Int32 = 0
        If (ckbMedias.Checked = True) Then
            For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
                sumaAm = sumaAm + CInt(grdTablaAmarre.Item(columna.Index, 2).Value.ToString())
                sumaAmDos = sumaAmDos + CInt(grdTablaAmarre.Item(columna.Index, 3).Value.ToString())
            Next
            If (sumaAm <> 6 Or sumaAmDos <> 6) Then
                If (sumaAm <> 6) Then
                    grdTablaAmarre.Rows(2).DefaultCellStyle.ForeColor = Color.Red
                Else
                    grdTablaAmarre.Rows(2).DefaultCellStyle.ForeColor = Color.Black
                End If
                If (sumaAmDos <> 6) Then
                    grdTablaAmarre.Rows(3).DefaultCellStyle.ForeColor = Color.Red
                Else
                    grdTablaAmarre.Rows(3).DefaultCellStyle.ForeColor = Color.Black
                End If
                Return False
            Else
                grdTablaAmarre.Rows(2).DefaultCellStyle.ForeColor = Color.Black
                grdTablaAmarre.Rows(3).DefaultCellStyle.ForeColor = Color.Black
            End If
        End If

        Return True
    End Function

    Public Function validaExistenModelos() As Boolean
        Dim objTallaNe As New Negocios.TallasBU
        Dim dtModelosTalla As New DataTable

        If rdoActivo.Checked = False Then
            dtModelosTalla = objTallaNe.validaExistenModelos(idTalla)
        End If

        If dtModelosTalla.Rows.Count > 0 Then
            Dim cadena As String = "Modelos: "
            For Each row As DataRow In dtModelosTalla.Rows
                cadena += vbLf + row.Item(0).ToString + " " + row.Item(1).ToString
            Next
            MsgBox("La corrida " + txtDescripcion.Text + " no puede ser inactivada, debido a que existen " + CStr(dtModelosTalla.Rows.Count) + " modelos activos registrados con esta talla." + vbLf + cadena)
            Return False
        End If
        Return True
    End Function

    Public Sub guardarAmarreSoloToltal()
        Dim objTallaBU As New Programacion.Negocios.TallasBU
        Dim dtIdTallaMax As New DataTable
        dtIdTallaMax = objTallaBU.VerIdMaximoTalla
        Dim tamTabAmarre As Int32 = grdTablaAmarre.ColumnCount

        For n As Int32 = 0 To tamTabAmarre - 1
            objTallaBU.AltaAmarreTotal(idTalla, grdTablaAmarre.Item(n, 0).Value.ToString, CInt(grdTablaAmarre.Item(n, 1).Value.ToString))
        Next
    End Sub

    Private Sub EditarTallaForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub EditarTallaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtInicio.Controls.RemoveAt(0)
        txtCentral.Controls.RemoveAt(0)
        txtFin.Controls.RemoveAt(0)

        grdTablaAmarre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdTablaAmarre.AllowUserToAddRows = False

        LlenarComboPaises()
        LlenarComboTallasPrincipales()
        grdTallas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdTallas.AllowUserToAddRows = False
        grdTallaInicial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdTallaInicial.AllowUserToAddRows = False
        TraerDatosTallaEditar()
        LlenarDatosRestaurar()
        cmbTallaPrincipal.Enabled = False
        If nombrePais = "MÉXICO" Then
            verTallaAmarre()
            toolMensaje.SetToolTip(Me.lblGuardar, "Antes de guardar cambios" + Chr(13) + "recuerde actualizar " + Chr(13) + "los datos de la corrida.")
        Else
            pnlActualizar.Visible = False
            grdTallaInicial.Height = 232
            grdTallas.Enabled = True
            If editando = 1 Then
                grdTallas.ReadOnly = False
                btnGuardar.Enabled = True
            End If
            txtInicio.Enabled = False
            txtFin.Enabled = False
            txtCentral.Enabled = False
            cmbPaises.Enabled = False
            cmbTallaPrincipal.Enabled = False
            txtCodSicy.Enabled = False
            txtGrupo.Enabled = False
            chkEnteros.Enabled = False
            ckbMedias.Enabled = False
            If editando = 0 Then
                txtDescripcion.Enabled = False
                rdoActivo.Enabled = False
                rdoInactivo.Enabled = False
                lblGuardar.Enabled = False
                btnGuardar.Enabled = False
                btnActualizar.Visible = False
                lblActualizar.Visible = False
            End If
        End If



    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If nombrePais = "MÉXICO" Then
            CambiosGrid()
            If validaExistenModelos() = True Then
                If (ValidarVacio() = True) Then
                    If (ckbMedias.Checked = True) Then
                        If (validarAmarre() = True) Then
                            Dim objMensajeQ As New ConfirmarForm
                            objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                            If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                                EnviarEditar()
                                guardarAmarre()
                                Dim mensajeExito As New ExitoForm
                                mensajeExito.mensaje = "La edición se realizó con éxito." + vbNewLine + vbNewLine + "Talla editada: " + txtInicio.Value.ToString + "/" + txtFin.Value.ToString
                                mensajeExito.ShowDialog()
                                Me.Close()
                            Else
                            End If
                        Else
                            MsgBox("Cada media debe incluir 6 pares.")
                        End If
                    Else
                        Dim suma As Int32 = 0
                        For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
                            suma = suma + CInt(grdTablaAmarre.Rows(1).Cells(columna.Index).Value)
                        Next

                        If (suma = 0) Then
                            Dim objMensajeQ As New ConfirmarForm
                            objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                            If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                                EnviarEditar()
                                Dim objTallaBu As New Programacion.Negocios.TallasBU
                                objTallaBu.AlterarAmarresBU(idTalla)
                                Dim mensajeExito As New ExitoForm
                                mensajeExito.mensaje = "La edición se realizó con éxito." + vbNewLine + vbNewLine + "Talla editada: " + txtInicio.Value.ToString + "/" + txtFin.Value.ToString
                                mensajeExito.ShowDialog()
                                Me.Close()
                            End If
                        ElseIf (suma = 12) Then
                            Dim objMensajeQ As New ConfirmarForm
                            objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                            If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                                EnviarEditar()
                                Dim objTallaBu As New Programacion.Negocios.TallasBU
                                objTallaBu.AlterarAmarresBU(idTalla)
                                guardarAmarreSoloToltal()
                                Dim mensajeExito As New ExitoForm
                                mensajeExito.mensaje = "La edición se realizó con éxito." + vbNewLine + vbNewLine + "Talla editada: " + txtInicio.Value.ToString + "/" + txtFin.Value.ToString
                                mensajeExito.ShowDialog()
                                Me.Close()
                            End If
                        ElseIf (suma <> 0 And suma <> 12) Then
                            grdTablaAmarre.Rows(1).DefaultCellStyle.ForeColor = Color.Red
                        End If

                    End If

                ElseIf (ValidarVacio() = False) Then
                    Dim mensaje As New AdvertenciaForm
                    mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
                    mensaje.ShowDialog()
                End If
            Else
            End If

        Else

            If validaExistenModelos() = True Then
                If (ValidarVacio() = True) Then
                    Dim objMensajeQ As New ConfirmarForm
                    objMensajeQ.mensaje = "¿Esta seguro de guardar cambios?"
                    If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                        EnviarEditar()
                        Dim mensajeExito As New ExitoForm
                        mensajeExito.mensaje = "La edición se realizó con éxito." + vbNewLine + vbNewLine + "Talla editada: " + txtInicio.Value.ToString + "/" + txtFin.Value.ToString
                        mensajeExito.ShowDialog()
                        Me.Close()
                    End If
                End If

            End If
        End If

    End Sub


    Public Sub cambioMediaChek()
        btnGuardar.Enabled = False

        Dim mensaje As New AdvertenciaForm
        Dim mensajeExito As New ExitoForm
        Dim n As Int32 = 0

        If (txtCentral.Value >= txtInicio.Value And txtCentral.Value <= txtFin.Value) Then
            Dim tinicio As String = txtInicio.Value.ToString()
            Dim tfin As String = txtFin.Value.ToString()
            Dim inicioTalla As Decimal = Convert.ToDecimal(tinicio)
            Dim finTalla As Decimal = Convert.ToDecimal(tfin)
            Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            Dim contPasos As Int32 = 1
            Dim dtAmarre As New DataTable
            Dim dtColumnAmarre As New DataColumn

            If (finTalla >= inicioTalla) Then
                If (chkEnteros.Checked = False) Then
                    Dim recorre As Integer = 1
                    Dim contador As Integer = 0
                    Dim resta As Decimal = finTalla - inicioTalla
                    Dim pasos As Integer = resta / 0.5
                    Dim tallasNuevas As Decimal = inicioTalla
                    Dim tamanoTallaInicial As Int32 = txtInicio.Value.ToString.Length
                    Dim tallaInicioCadena As String = ""
                    Dim tamanoTallaFinal As Int32 = txtFin.Value.ToString.Length
                    Dim tallaFinalCadena As String = ""
                    Dim tamanoTallaCentral As Int32 = txtCentral.Value.ToString.Length
                    Dim tallaCentralCadena As String = ""

                    If (pasos < 20) Then
                        Dim datoTalla As String = ""
                        Dim tamanoCadena As Int32 = 0
                        grdTablaAmarre.ColumnCount = pasos + 1

                        For columnaA As Int32 = 0 To pasos
                            grdTablaAmarre.Columns(columnaA).HeaderText = "T" + contPasos.ToString
                            CType(Me.grdTablaAmarre.Columns(columnaA), DataGridViewTextBoxColumn).MaxInputLength = 1
                            contPasos = contPasos + 1
                        Next

                        grdTablaAmarre.RowCount = 4
                        Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "Talla"
                        Me.grdTablaAmarre.Rows(1).HeaderCell.Value = "Total"
                        Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Media 1"
                        Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 2"
                        grdTablaAmarre.Rows(0).ReadOnly = True
                        grdTablaAmarre.Rows(1).DefaultCellStyle.BackColor = Drawing.SystemColors.ControlLight

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
                            n = n + 1
                            tallasNuevas = tallasNuevas + 0.5
                        Next
                    Else
                        mensaje.mensaje = "No pueden generarse mas de 20 tallas en una descripción."
                        mensaje.ShowDialog()
                    End If

                ElseIf (chkEnteros.Checked = True) Then
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
                                CType(Me.grdTablaAmarre.Columns(columnaA), DataGridViewTextBoxColumn).MaxInputLength = 1
                                contPasos = contPasos + 1
                            Next
                            grdTablaAmarre.RowCount = 4
                            Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "Talla"
                            Me.grdTablaAmarre.Rows(1).HeaderCell.Value = "Total"
                            Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Media 1"
                            Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 2"
                            Me.grdTablaAmarre.Rows(0).ReadOnly = True
                            Me.grdTablaAmarre.Rows(1).DefaultCellStyle.BackColor = Drawing.SystemColors.ControlLight

                            For recorre = 1 To resta + 1
                                If recorre = 21 Then
                                    Exit For
                                End If
                                datoTalla = CStr(CInt(tallasNuevas))
                                grdTablaAmarre.Item(n, 0).Value = datoTalla
                                grdTablaAmarre.Item(n, 1).Value = 0
                                grdTablaAmarre.Item(n, 2).Value = 0
                                grdTablaAmarre.Item(n, 3).Value = 0
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
            ckbMedias.Checked = False
            mensaje.mensaje = "La talla central debe ser una talla con valor entre las tallas de inicio y fin."
            mensaje.ShowDialog()
        End If
        If (ckbMedias.Checked = True) Then
            Me.grdTablaAmarre.Rows(2).Visible = True
            Me.grdTablaAmarre.Rows(3).Visible = True
        Else
            Me.grdTablaAmarre.Rows(2).Visible = False
            Me.grdTablaAmarre.Rows(3).Visible = False
        End If
    End Sub


    Private Sub chkEnteros_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnteros.CheckedChanged

        ckbMedias.Checked = False
        btnGuardar.Enabled = False
        CambiosGrid()
        generartitulo()
        actualizarCheckMedias()

        'grdTablaAmarre.Rows.Clear()
        'grdTablaAmarre.Columns.Clear()
    End Sub

    Public Sub generartitulo()
        txtInicio.Value = CDec(txtInicio.Value)
        If (txtInicio.Value >= 1) Then
            Dim validaPunto As Boolean = True
            Dim cadenaText As Int32 = Len(txtInicio.Value.ToString)
            If (cadenaText > 2) Then
                If (txtInicio.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                    If Not (txtInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                        validaPunto = False
                        Dim dato As String = txtInicio.Value.ToString.Substring(0, cadenaText - 2)
                        txtInicio.Value = dato + ".5"
                    End If
                End If
            End If
            Dim tamanoTallaInicial As Int32 = txtInicio.Value.ToString.Length
            Dim tallaInicioCadena As String = ""
            Dim tamanoTallaFinal As Int32 = txtFin.Value.ToString.Length
            Dim tallaFinalCadena As String = ""

            If (tamanoTallaInicial > 1) Then
                If (txtInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                    tallaInicioCadena = txtInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                Else
                    tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                End If
            Else
                tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
            End If
            If (tamanoTallaFinal > 1) Then
                If (txtFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                    tallaFinalCadena = txtFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                Else
                    tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                End If
            Else
                tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
            End If

            txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
        Else
            txtInicio.Value = 1
        End If
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        CambiosGrid()
        actualizarCheckMedias()
        btnGuardar.Enabled = True
    End Sub


    Private Sub cmbTallaPrincipal_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTallaPrincipal.SelectionChangeCommitted
        Dim TallaNegocio As New Programacion.Negocios.TallasBU
        Dim idTallaInicialComit As String = ""
        Try
            idTallaInicialComit = cmbTallaPrincipal.SelectedValue.ToString
        Catch ex As Exception

        End Try
        If (idTallaInicialComit <> "") Then
            grdTallaInicial.DataSource = Nothing
            dtTallaInicialComit = New DataTable
            dtTallaInicialComit = TallaNegocio.verTallaInicialSeleccionada(idTallaInicialComit)
            grdTallaInicial.DataSource = dtTallaInicialComit
            grdTallaInicial.Columns("Talla").Visible = False
            grdTallaInicial.Columns("Inicio").Visible = False
            grdTallaInicial.Columns("Fin").Visible = False
            grdTallaInicial.Columns("Tallabase").Visible = False
            grdTallaInicial.Columns("talla_tallaid").Visible = False
            grdTallaInicial.Columns("talla_tallacentral").Visible = False
            grdTallaInicial.Columns("Grupo").Visible = False
            grdTallaInicial.Columns("pais").Visible = False
            grdTallaInicial.Columns("activo").Visible = False
            grdTallaInicial.Columns("EnterosT").Visible = False
            grdTallaInicial.Columns(0).Visible = False
        Else
            grdTallaInicial.DataSource = Nothing
        End If
    End Sub

    Private Sub txtInicio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInicio.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtInicio.Value = CDec(txtInicio.Value)
            If (txtInicio.Value >= 1) Then
                Dim validaPunto As Boolean = True
                Dim cadenaText As Int32 = Len(txtInicio.Value.ToString)
                If (cadenaText > 2) Then
                    If (txtInicio.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                        If Not (txtInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtInicio.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                            validaPunto = False
                            Dim dato As String = txtInicio.Value.ToString.Substring(0, cadenaText - 2)
                            txtInicio.Value = dato + ".5"
                        End If
                    End If
                End If
                Dim tamanoTallaInicial As Int32 = txtInicio.Value.ToString.Length
                Dim tallaInicioCadena As String = ""
                Dim tamanoTallaFinal As Int32 = txtFin.Value.ToString.Length
                Dim tallaFinalCadena As String = ""

                If (tamanoTallaInicial > 1) Then
                    If (txtInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                        tallaInicioCadena = txtInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                    Else
                        tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                    End If
                Else
                    tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                End If
                If (tamanoTallaFinal > 1) Then
                    If (txtFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                        tallaFinalCadena = txtFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                    Else
                        tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                    End If
                Else
                    tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                End If

                txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
            Else
                txtInicio.Value = 1
            End If
        End If
    End Sub


    Private Sub txtInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInicio.LostFocus
        'Dim validaPunto As Boolean = True
        Dim cadenaText As Int32 = Len(txtInicio.Value.ToString)
        Dim cadena As String = CStr(txtInicio.Value).Substring(cadenaText - 2, 2)
        If (CInt(txtInicio.Value) >= 1) Then

            If (cadenaText > 2) Then

                If (CStr(txtInicio.Value).Substring(cadenaText - 2, 1) = ".") Then
                    If Not (cadena.Equals(".5") Or cadena.Equals(".0")) Then
                        'validaPunto = False
                        Dim dato As String = txtInicio.Value.ToString.Substring(0, cadenaText - 2)
                        txtInicio.Value = dato + ".5"
                    End If
                End If
            End If

            Dim tamanoTallaInicial As Int32 = CStr(txtInicio.Value).Length
            Dim tallaInicioCadena As String = ""
            Dim tamanoTallaFinal As Int32 = CStr(txtFin.Value).Length
            Dim tallaFinalCadena As String = ""

            If (tamanoTallaInicial > 1) Then
                If (txtInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                    tallaInicioCadena = txtInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                Else
                    tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                End If
            Else
                tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
            End If

            If (tamanoTallaFinal > 1) Then
                If (txtFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                    tallaFinalCadena = txtFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                Else
                    tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                End If
            Else
                tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
            End If

            txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena

        Else
            txtInicio.Value = 1D
        End If
    End Sub

    Private Sub txtFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFin.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtFin.Value = CDec(txtFin.Value)

            If (txtFin.Value >= 1) Then
                Dim validaPunto As Boolean = True
                Dim cadenaText As Int32 = Len(txtFin.Value.ToString)
                If (cadenaText > 2) Then
                    If (txtFin.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                        If Not (txtFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                            validaPunto = False
                            Dim dato As String = txtFin.Value.ToString.Substring(0, cadenaText - 2)
                            txtFin.Value = dato + ".5"
                        End If
                    End If
                End If

                Dim tamanoTallaInicial As Int32 = txtInicio.Value.ToString.Length
                Dim tallaInicioCadena As String = ""
                Dim tamanoTallaFinal As Int32 = txtFin.Value.ToString.Length
                Dim tallaFinalCadena As String = ""

                If (tamanoTallaInicial > 1) Then
                    If (txtInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                        tallaInicioCadena = txtInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                    Else
                        tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                    End If
                Else
                    tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                End If
                If (tamanoTallaFinal > 1) Then
                    If (txtFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                        tallaFinalCadena = txtFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                    Else
                        tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                    End If
                Else
                    tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                End If

                txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
            Else
                txtFin.Value = 1
            End If
        End If
    End Sub

    Private Sub txtFin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFin.LostFocus
        Dim cadenaText As Int32 = Len(txtFin.Value.ToString)
        If (CInt(txtFin.Value) >= 1) Then

            If (cadenaText > 2) Then
                If (txtFin.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                    If Not (txtFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtFin.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                        Dim dato As String = txtFin.Value.ToString.Substring(0, cadenaText - 2)
                        txtFin.Value = dato + ".5"
                    End If
                End If
            End If

            Dim tamanoTallaInicial As Int32 = txtInicio.Value.ToString.Length
            Dim tallaInicioCadena As String = ""
            Dim tamanoTallaFinal As Int32 = txtFin.Value.ToString.Length
            Dim tallaFinalCadena As String = ""

            If (tamanoTallaInicial > 1) Then
                If (txtInicio.Value.ToString.Substring(tamanoTallaInicial - 2, 2) = ".5") Then
                    tallaInicioCadena = txtInicio.Value.ToString.Substring(0, tamanoTallaInicial - 2) + "½"
                Else
                    tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
                End If
            Else
                tallaInicioCadena = CStr(CInt(txtInicio.Value.ToString))
            End If

            If (tamanoTallaFinal > 1) Then
                If (txtFin.Value.ToString.Substring(tamanoTallaFinal - 2, 2) = ".5") Then
                    tallaFinalCadena = txtFin.Value.ToString.Substring(0, tamanoTallaFinal - 2) + "½"
                Else
                    tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
                End If
            Else
                tallaFinalCadena = CStr(CInt(txtFin.Value.ToString))
            End If

            txtDescripcion.Text = tallaInicioCadena + "-" + tallaFinalCadena
        Else
            txtFin.Value = 1D
        End If

    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or caracter = ChrW(Keys.Space) Or (caracter = "-") Or (caracter = "½") Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Private Sub ckbMedias_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbMedias.CheckedChanged
        'cambioMediaChek()
        'lblTotalPares.ForeColor = Color.Black
        'lblTotalPares.Text = "0"

        'grdTablaAmarre.RowCount = 4
        'Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "Talla"
        'Me.grdTablaAmarre.Rows(1).HeaderCell.Value = "Total"
        'Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Media 1"
        'Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 2"

        '   If (grdTablaAmarre.Rows.Count > 0) Then

        'grdTallas.Columns("Talla").Visible = False
        'grdTallas.Columns("Inicio").Visible = False
        'grdTallas.Columns("Fin").Visible = False
        'grdTallas.Columns("Tallabase").Visible = False
        'grdTallas.Columns("talla_tallaid").Visible = False
        'grdTallas.Columns("talla_tallacentral").Visible = False
        'grdTallas.Columns("Grupo").Visible = False
        'grdTallas.Columns("pais").Visible = False
        'grdTallas.Columns("activo").Visible = False
        'grdTallas.Columns("EnterosT").Visible = False
        'grdTallas.Columns("talla_sicy").Visible = False
        'grdTallas.Columns(0).Visible = False

        CambiosGrid()
        actualizarCheckMedias()

        '  End If
    End Sub

    Public Sub actualizarCheckMedias()
        grdTablaAmarre.Rows.Clear()
        grdTablaAmarre.Columns.Clear()

        grdTablaAmarre.RowCount = 4
        Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "Talla"
        Me.grdTablaAmarre.Rows(1).HeaderCell.Value = "Total"
        Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Media 1"
        Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 2"

        Dim colcont As Int32 = 0
        Dim nvo As Int32 = 0

        For i = 5 To 25
            Dim cosa As String = grdTallas.Rows(0).Cells(i).Value
            If (grdTallas.Rows(0).Cells(i).Value <> "") Then
                colcont = colcont + 1
            End If
        Next

        grdTablaAmarre.ColumnCount = colcont


        For i = 5 To 25
            If (grdTallas.Rows(0).Cells(i).Value <> "") Then
                grdTablaAmarre.Item(nvo, 0).Value = grdTallas.Rows(0).Cells(i).Value.ToString
                grdTablaAmarre.Item(nvo, 1).Value = 0
                grdTablaAmarre.Item(nvo, 2).Value = 0
                grdTablaAmarre.Item(nvo, 3).Value = 0
                nvo = nvo + 1
            End If
        Next

        grdTablaAmarre.Rows(0).ReadOnly = True
        grdTablaAmarre.Rows(1).DefaultCellStyle.BackColor = Drawing.SystemColors.ControlLight

        Dim conColN As Int32 = 1
        For Each colr As DataGridViewColumn In grdTablaAmarre.Columns
            colr.HeaderText = "T" + conColN.ToString
            CType(colr, DataGridViewTextBoxColumn).MaxInputLength = 1
            'grdTablaAmarre.Columns(columnaA).Width = 50
            conColN = conColN + 1
        Next

        For Each col As DataGridViewColumn In grdTablaAmarre.Columns
            grdTablaAmarre.Rows(2).Cells(col.Index).Value = grdTablaAmarre.Rows(1).Cells(col.Index).Value
        Next
        If (ckbMedias.Checked = True) Then
            Me.grdTablaAmarre.Rows(2).Visible = True
            Me.grdTablaAmarre.Rows(3).Visible = True

        ElseIf (ckbMedias.Checked = False) Then
            Me.grdTablaAmarre.Rows(2).Visible = False
            Me.grdTablaAmarre.Rows(3).Visible = False
        End If

        lblTotalPares.Text = 0
    End Sub

    Private Sub grdTablaAmarre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTablaAmarre.CellEndEdit
        If (ckbMedias.Checked = True) Then
            If (grdTablaAmarre.Rows(e.RowIndex).Cells(e.ColumnIndex).Value IsNot Nothing) Then
                If (e.RowIndex = 1) Then
                    grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                    grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                    If (grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value <> 0) Then

                        If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0) Then
                            If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value < grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                                grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value)
                            End If
                        End If
                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0) Then
                            If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value < grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                                grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                            End If
                        End If
                        If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <> 0) Then
                            grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                            grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                        End If
                        If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0) Then
                            grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value)
                        End If
                    Else
                        grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                    End If
                ElseIf (e.RowIndex = 2) Then
                    If (grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value <> 0) Then
                        If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <= grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                            grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value)
                        Else
                            grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) + CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                        End If
                    Else
                        grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                    End If
                ElseIf (e.RowIndex = 3) Then
                    If (grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value <> 0) Then
                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <= grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                            grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                        Else
                            grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) + CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                        End If
                    Else
                        grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                    End If
                End If
            Else
                grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value = 0
                grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
            End If
        End If
        Dim suma As Int32 = 0
        For Each columna As DataGridViewColumn In grdTablaAmarre.Columns
            suma = suma + CInt(grdTablaAmarre.Rows(1).Cells(columna.Index).Value)
        Next
        If Not (suma = 12 Or suma = 0) Then
            lblTotalPares.ForeColor = Color.Red
        Else
            lblTotalPares.ForeColor = Color.Black
        End If
        lblTotalPares.Text = suma.ToString
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


    Private Sub txtCentral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCentral.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            txtCentral.Value = CDec(txtCentral.Value)
            If (txtCentral.Value >= 1) Then
                Dim validaPunto As Boolean = True
                Dim cadenaText As Int32 = Len(txtCentral.Value.ToString)
                If (cadenaText > 2) Then
                    If (txtCentral.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                        If Not (txtCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                            validaPunto = False
                            Dim dato As String = txtCentral.Value.ToString.Substring(0, cadenaText - 2)
                            txtCentral.Value = dato + ".5"
                        End If
                    End If
                End If
            Else
                txtCentral.Value = 1
            End If
        End If
    End Sub

    Private Sub txtCentral_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCentral.LostFocus
        Dim cadenaText As Int32 = Len(txtCentral.Value.ToString)
        If (CInt(txtCentral.Value) >= 1) Then
            If (cadenaText > 2) Then
                If (txtCentral.Value.ToString.Substring(cadenaText - 2, 1) = ".") Then
                    If Not (txtCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".5") Or txtCentral.Value.ToString.Substring(cadenaText - 2, 2).Equals(".0")) Then
                        Dim dato As String = txtCentral.Value.ToString.Substring(0, cadenaText - 2)
                        txtCentral.Value = dato + ".5"
                    End If
                End If
            End If
        Else
            txtCentral.Value = 1
        End If
    End Sub

    Private Sub txtInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInicio.ValueChanged
        chkEnteros.Checked = False
        ckbMedias.Checked = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub txtCentral_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCentral.ValueChanged
        btnGuardar.Enabled = False
    End Sub

    Private Sub txtFin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFin.ValueChanged
        chkEnteros.Checked = False
        ckbMedias.Checked = False
        btnGuardar.Enabled = False
    End Sub

    Private Sub cmbPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaises.SelectedIndexChanged
        If cmbPaises.Text.Equals("MÉXICO") Or cmbPaises.Text.Equals("") Then
            cmbTallaPrincipal.Enabled = False
            chkEnteros.Enabled = True
            ckbMedias.Enabled = True
            txtInicio.Enabled = True
            txtCentral.Enabled = True
            txtFin.Enabled = True
            txtCodSicy.Enabled = True
        Else
            cmbTallaPrincipal.Enabled = True
            txtDescripcion.Enabled = True
            chkEnteros.Checked = False
            chkEnteros.Enabled = False
            ckbMedias.Checked = False
            ckbMedias.Enabled = False
            txtInicio.Enabled = False
            txtCentral.Enabled = False
            txtFin.Enabled = False
            'txtTallaFin.Value = 1
            'txtTallaCentral.Value = 1
            'txtTallaInicio.Value = 1
            txtCodSicy.Enabled = False

        End If
    End Sub
End Class