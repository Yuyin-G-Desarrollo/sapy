Imports Tools

Public Class FamiliaFormRapido
    Dim idFamilia As String
    Public idFamiliaDato As Int32
    Public codFamilia As String
    Public NombreFamilia As String

    Public Property PFamiliaId As Int32
        Get
            Return idFamiliaDato
        End Get
        Set(ByVal value As Int32)
            idFamiliaDato = value
        End Set
    End Property

    Public Property PCodFamilia As String
        Get
            Return codFamilia
        End Get
        Set(ByVal value As String)
            codFamilia = value
        End Set
    End Property

    Public Property PNombreFamilia As String
        Get
            Return NombreFamilia
        End Get
        Set(ByVal value As String)
            NombreFamilia = ValidarVacio()
        End Set
    End Property


    Public Sub LlenarTablaFamilia()
        Dim objFBU As New Programacion.Negocios.FamiliasBU
        Dim dtListaFamilias As DataTable
        Dim descripcion As String = txtDescripcion.Text
        dtListaFamilias = objFBU.verComboFamilias(descripcion)
        grdListaFamilias.DataSource = dtListaFamilias
        grdListaFamilias.Columns(1).Visible = False
        grdListaFamilias.Columns(0).Width = 50
        grdListaFamilias.Columns(2).Width = 50
        grdListaFamilias.Columns(2).HeaderText = "Código"
        grdListaFamilias.Columns(3).HeaderText = "Familia"
    End Sub

    Public Sub AltaFamilia()

        Dim FamiliaNegocios As New Programacion.Negocios.FamiliasBU
        Dim EnFamilia As New Entidades.Familias
        EnFamilia.PCodigo = codFamilia
        EnFamilia.PDescripcion = txtNombreFamilia.Text.Trim
        EnFamilia.PActivo = True

        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        FamiliaNegocios.RegistraFamilia(EnFamilia, usuario)
        Me.Close()
        Dim dtIdMaximo As DataTable
        dtIdMaximo = FamiliaNegocios.VerIdfamiliaMasAlto
        Dim idMax As String = dtIdMaximo.Rows(0)(0).ToString
        Dim dtCodigoFam As DataTable
        dtCodigoFam = FamiliaNegocios.VerCodigoFamiliaRapido(idMax)
        idFamilia = idMax
        codFamilia = dtCodigoFam.Rows(0)(0).ToString
        NombreFamilia = dtCodigoFam.Rows(0)(1).ToString
        Me.Close()
    End Sub

    Public Sub IdNuevo()
        Dim IdCodigoFamiliaMaximo As New Programacion.Negocios.FamiliasBU
        Dim dtTabla As DataTable = IdCodigoFamiliaMaximo.ContadorFilas
        Dim DtIdMaximo As DataTable = IdCodigoFamiliaMaximo.VerIdfamiliaMasAlto
        Dim ValidacionExistePrimero As Int32 = dtTabla.Rows.Count
        Dim CodigoNuevo As String = String.Empty


        If (ValidacionExistePrimero = 0) Then
            CodigoNuevo = "0"
        ElseIf (ValidacionExistePrimero = 1) Then
            CodigoNuevo = "1"
        End If

        If (ValidacionExistePrimero > 1 And ValidacionExistePrimero < 36) Then
            If (ValidacionExistePrimero >= 2 And ValidacionExistePrimero < 10) Then
                CodigoNuevo = ValidacionExistePrimero.ToString
                codFamilia = CodigoNuevo

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
                codFamilia = CodigoNuevo
            End If
        End If
        If (ValidacionExistePrimero >= 37) Then
            Dim dtCodigosDisponibles As DataTable
            dtCodigosDisponibles = New DataTable
            dtCodigosDisponibles = IdCodigoFamiliaMaximo.VerCodigosDisponibles()
            Dim DatoValidacionExistente As String = dtCodigosDisponibles.Rows(0)("fami_codigo").ToString()
            CodigoNuevo = DatoValidacionExistente.ToString
            codFamilia = CodigoNuevo
        End If
        codFamilia = CodigoNuevo.ToString
    End Sub



    Public Function ValidarVacio() As Boolean
        If (txtNombreFamilia.Text.Trim = Nothing) Then
            If (txtNombreFamilia.Text.Trim = Nothing) Then
                lblNombre.ForeColor = Drawing.Color.Red
            Else
                lblNombre.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblNombre.ForeColor = Drawing.Color.Black
            Return True
        End If

        Return True
    End Function

    Private Sub FamiliaFormRapido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtDescripcion.Focus()
        grdListaFamilias.RowHeadersVisible = False
        grdListaFamilias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdListaFamilias.AllowUserToAddRows = False
        LlenarTablaFamilia()
    End Sub

    Private Sub grdListaFamilias_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdListaFamilias.CellClick

        If e.RowIndex >= 0 AndAlso sender.Columns(e.ColumnIndex).GetType() = GetType(DataGridViewButtonColumn) Then
            idFamiliaDato = Convert.ToInt32(grdListaFamilias.Item(1, e.RowIndex).Value)
            codFamilia = grdListaFamilias.Item(2, e.RowIndex).Value.ToString
            NombreFamilia = grdListaFamilias.Item(3, e.RowIndex).Value.ToString
            Me.Close()

        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If (ValidarVacio() = True) Then
            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                IdNuevo()
                AltaFamilia()
            Else
                codFamilia = String.Empty
                idFamilia = String.Empty
            End If
        ElseIf (ValidarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()

        End If
    End Sub


    Private Sub txtNombreFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreFamilia.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreFamilia.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreFamilia.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        txtDescripcion.Text = String.Empty
        txtNombreFamilia.Text = String.Empty
        If (txtNombreFamilia.Visible = False) Then
            txtNombreFamilia.Visible = True
            btnAgregar.Visible = True
            txtDescripcion.Visible = False
            btnFiltrar.Visible = False
        Else
            txtNombreFamilia.Visible = False
            btnAgregar.Visible = False
            txtDescripcion.Visible = True
            btnFiltrar.Visible = True
        End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaFamilia()
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            LlenarTablaFamilia()
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtDescripcion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
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
End Class