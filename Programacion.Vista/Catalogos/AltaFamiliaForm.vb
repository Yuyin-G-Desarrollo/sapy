Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AltaFamiliaForm
    Dim contRegistros As Int32

    Public Sub IdNuevo()
        Dim IdCodigoFamiliaMaximo As New Programacion.Negocios.FamiliasBU
        Dim dtTabla As DataTable = IdCodigoFamiliaMaximo.ContadorFilas
        Dim DtIdMaximo As DataTable = IdCodigoFamiliaMaximo.VerIdfamiliaMasAlto
        Dim ValidacionExistePrimero As Int32 = dtTabla.Rows.Count

        'Dim nuevoCodigoContador As Int32 = dtTabla.Rows.Count
        'Dim idMaximo = DtIdMaximo.Rows(0)("Maximo").ToString
        'Dim IdNuevo As Int32 = ValidacionExistePrimero + 1
        Dim CodigoNuevo As String = String.Empty


        If (ValidacionExistePrimero = 0) Then
            CodigoNuevo = "0"
            'idMaximo = 1
            'txtCodigo.Text = CodigoNuevo
        ElseIf (ValidacionExistePrimero = 1) Then
            CodigoNuevo = "1"
            'idMaximo = 1
            'txtCodigo.Text = CodigoNuevo
            'ElseIf (ValidacionExistePrimero >= 2) Then
            '    IdNuevo = Convert.ToInt32(idMaximo)
        End If

        If (ValidacionExistePrimero > 1 And ValidacionExistePrimero < 37) Then
            If (ValidacionExistePrimero >= 2 And ValidacionExistePrimero < 10) Then
                CodigoNuevo = ValidacionExistePrimero.ToString
                txtCodigo.Text = CodigoNuevo

            ElseIf (ValidacionExistePrimero >= 10) Then
                If (ValidacionExistePrimero = 10) Then
                    CodigoNuevo = "A"
                End If
                If (ValidacionExistePrimero = 11) Then
                    CodigoNuevo = "B"
                End If
                If (ValidacionExistePrimero = 12) Then
                    CodigoNuevo = "C"
                End If
                If (ValidacionExistePrimero = 13) Then
                    CodigoNuevo = "D"
                End If
                If (ValidacionExistePrimero = 14) Then
                    CodigoNuevo = "E"
                End If
                If (ValidacionExistePrimero = 15) Then
                    CodigoNuevo = "F"
                End If
                If (ValidacionExistePrimero = 16) Then
                    CodigoNuevo = "G"
                End If
                If (ValidacionExistePrimero = 17) Then
                    CodigoNuevo = "H"
                End If
                If (ValidacionExistePrimero = 18) Then
                    CodigoNuevo = "I"
                End If
                If (ValidacionExistePrimero = 19) Then
                    CodigoNuevo = "J"
                End If
                If (ValidacionExistePrimero = 20) Then
                    CodigoNuevo = "K"
                End If
                If (ValidacionExistePrimero = 21) Then
                    CodigoNuevo = "L"
                End If
                If (ValidacionExistePrimero = 22) Then
                    CodigoNuevo = "M"
                End If
                If (ValidacionExistePrimero = 23) Then
                    CodigoNuevo = "N"
                End If
                If (ValidacionExistePrimero = 24) Then
                    CodigoNuevo = "Ñ"
                End If
                If (ValidacionExistePrimero = 25) Then
                    CodigoNuevo = "O"
                End If
                If (ValidacionExistePrimero = 26) Then
                    CodigoNuevo = "P"
                End If
                If (ValidacionExistePrimero = 27) Then
                    CodigoNuevo = "Q"
                End If
                If (ValidacionExistePrimero = 28) Then
                    CodigoNuevo = "R"
                End If
                If (ValidacionExistePrimero = 29) Then
                    CodigoNuevo = "S"
                End If
                If (ValidacionExistePrimero = 30) Then
                    CodigoNuevo = "T"
                End If
                If (ValidacionExistePrimero = 31) Then
                    CodigoNuevo = "U"
                End If
                If (ValidacionExistePrimero = 32) Then
                    CodigoNuevo = "V"
                End If
                If (ValidacionExistePrimero = 33) Then
                    CodigoNuevo = "W"
                End If
                If (ValidacionExistePrimero = 34) Then
                    CodigoNuevo = "X"
                End If
                If (ValidacionExistePrimero = 35) Then
                    CodigoNuevo = "Y"
                End If
                If (ValidacionExistePrimero = 36) Then
                    CodigoNuevo = "Z"
                End If
                txtCodigo.Text = CodigoNuevo
            End If
        End If
        If (ValidacionExistePrimero >= 37) Then
            Dim dtCodigosDisponibles As DataTable
            dtCodigosDisponibles = New DataTable
            dtCodigosDisponibles = IdCodigoFamiliaMaximo.VerCodigosDisponibles()
            Dim DatoValidacionExistente As String = dtCodigosDisponibles.Rows(0)("fami_codigo").ToString()
            CodigoNuevo = DatoValidacionExistente.ToString
            txtCodigo.Text = CodigoNuevo
        End If
        txtCodigo.Text = CodigoNuevo.ToString
        contRegistros = ValidacionExistePrimero
    End Sub


    Public Function ValidarVacio() As Boolean
        If (txtDescripcion.Text.Trim = Nothing) Then
            If (txtDescripcion.Text.Trim = Nothing) Then
                lblDescripcion.ForeColor = Drawing.Color.Red
            Else
                lblDescripcion.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblDescripcion.ForeColor = Drawing.Color.Black
            Return True
        End If

        Return True
    End Function

    Public Sub AltaFamilia()
        Dim FamiliaNegocios As New Programacion.Negocios.FamiliasBU
        Dim EnFamilia As New Entidades.Familias
        EnFamilia.PCodigo = txtCodigo.Text.Trim
        EnFamilia.PDescripcion = txtDescripcion.Text.Trim
        If (rdoActivo.Checked = True) Then
            EnFamilia.PActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            EnFamilia.PActivo = False
        End If

        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        FamiliaNegocios.RegistraFamilia(EnFamilia, usuario)
        Dim mensaje As New ExitoForm
        mensaje.mensaje = "El registro se realizó con éxito."
        mensaje.ShowDialog()
        Me.Close()
        'Dim dtContNuevo As DataTable = FamiliaNegocios.ContadorFilas
        'Dim contFilas As Int32 = CInt(dtContNuevo.Rows.Count)

        'If contFilas = (contRegistros + 1) Then
        '    Dim dtIdMaximo As DataTable
        '    Dim idMaximoFamilia As Int32 = 0
        '    dtIdMaximo = FamiliaNegocios.VerIdfamiliaMasAlto
        '    idMaximoFamilia = CInt(dtIdMaximo.Rows(0)(0).ToString)


        '    For Each rowsDT As UltraGridRow In grdTallas.Rows
        '        Dim SDF As Boolean = rowsDT.Cells("seleccionado").Value
        '        If CBool(rowsDT.Cells("seleccionado").Value) = True Then
        '            If rowsDT.Cells("talla_tallaid").Value.ToString <> "" Then
        '                FamiliaNegocios.editarFamiliaTallas(idMaximoFamilia, CInt(rowsDT.Cells("talla_tallaid").Value))
        '            End If
        '        End If
        '    Next

        '    Dim mensaje As New ExitoForm
        '    mensaje.mensaje = "El registro se realizó con éxito."
        '    mensaje.ShowDialog()
        '    Me.Close()
        'Else
        '    MsgBox("Ha ocurrido algo inesperado, la familia no pudo ser registrada.", MsgBoxStyle.Critical)
        '    Me.Close()
        'End If

    End Sub

    Public Sub llenarTablaTallas()
        Dim objFamilia As New Negocios.FamiliasBU
        Dim dtDatosTabla As DataTable
        dtDatosTabla = objFamilia.seleccionarTallasEnFamilia(0)
        grdTallas.DataSource = dtDatosTabla

        'Me.grdTallas.DisplayLayout.Bands(0).Columns.Add("tallaSeleccionada", "Selección")
        Dim colckbFr As UltraGridColumn = grdTallas.DisplayLayout.Bands(0).Columns("seleccionado")
        colckbFr.Style = ColumnStyle.CheckBox
        colckbFr.CellActivation = Activation.AllowEdit

        Dim colEnteros As UltraGridColumn = grdTallas.DisplayLayout.Bands(0).Columns("talla_enteros")
        colEnteros.Style = ColumnStyle.CheckBox
        colEnteros.CellActivation = Activation.AllowEdit

        With grdTallas.DisplayLayout.Bands(0)
            .Columns("talla_tallaid").Hidden = True
            .Columns("talla_descripcion").Header.Caption = "Tallas"
            .Columns("talla_enteros").Header.Caption = "Solo Enteros"
            .Columns("seleccionado").Header.Caption = "Selección"
            .Columns("pais_nombre").Header.Caption = "País"
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_enteros").CellActivation = Activation.NoEdit
            .Columns("pais_nombre").CellActivation = Activation.NoEdit
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdTallas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                AltaFamilia()
            End If
        Else
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser llenados."
            mensaje.ShowDialog()
        End If

    End Sub


    Private Sub AltaFamiliaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IdNuevo()
        rdoActivo.Checked = True
        lblDescripcion.ForeColor = Drawing.Color.Black
        ' ''llenarTablaTallas()
    End Sub



    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
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

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodigo.Text.Length < 10) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtCodigo.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

End Class