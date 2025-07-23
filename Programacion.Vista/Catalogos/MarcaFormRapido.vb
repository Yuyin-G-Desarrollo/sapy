Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class MarcaFormRapido
    Dim idNuevaMarca As String
    Private idmarcas As Int32
    Private MarcaNombre As String
    Private esCliente As Boolean
    Private codSicyM As String
    Private etiquetaMarca As String

    Public idcedis As Integer
    Private esLicencia As Boolean
    Public Property PIdMarca As Int32
        Get
            Return idmarcas
        End Get
        Set(ByVal value As Int32)
            idmarcas = value
        End Set
    End Property
    Public Property PMarcaNombre As String
        Get
            Return MarcaNombre
        End Get
        Set(ByVal value As String)
            MarcaNombre = value
        End Set
    End Property

    Public Property PesCliente As Boolean
        Get
            Return esCliente
        End Get
        Set(ByVal value As Boolean)
            esCliente = value
        End Set
    End Property

    Public Property PSicyMarca As String
        Get
            Return codSicyM
        End Get
        Set(ByVal value As String)
            codSicyM = value
        End Set
    End Property

    Public Property PEtiquetaM As String
        Get
            Return etiquetaMarca
        End Get
        Set(ByVal value As String)
            etiquetaMarca = value
        End Set
    End Property

    Public Property PesLicencia As Boolean
        Get
            Return esLicencia
        End Get
        Set(ByVal value As Boolean)
            esLicencia = value
        End Set
    End Property
    Public Sub LlenarTablaMarca()
        Dim objMBU As New Programacion.Negocios.MarcasBU
        Dim dtListaMacras As DataTable
        dtListaMacras = objMBU.verMarcasRapido("")
        'grdListaMarcas.DataSource = dtListaMacras
        'grdListaMarcas.Columns(1).Visible = False
        'grdListaMarcas.Columns(0).Width = 50
        'grdListaMarcas.Columns(2).Width = 50
        'grdListaMarcas.Columns(4).Width = 50
        'grdListaMarcas.Columns(5).Width = 50

        Me.grdMarcas.DisplayLayout.Bands(0).Columns.Add("selectMarcas", "")
        Dim colckbCr As UltraGridColumn = grdMarcas.DisplayLayout.Bands(0).Columns("selectMarcas")
        colckbCr.Style = ColumnStyle.Image

        grdMarcas.DataSource = dtListaMacras

        With grdMarcas.DisplayLayout.Bands(0)
            .Columns("marc_marcaid").Hidden = True
            .Columns("marc_codigo").Header.Caption = "Código"
            .Columns("marc_descripcion").Header.Caption = "Marcas"
            .Columns("Sicy").Header.Caption = "SICY"

            .Columns("marc_codigo").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("Sicy").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit

            .Columns("marc_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Sicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            .Columns("selectMarcas").Header.VisiblePosition = 1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdMarcas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub


    Private Sub MarcaFormRapido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LlenarTablaMarca()
        LlenarTablaMarcaCedis()
    End Sub

    'Private Sub grdListaMarcas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdListaMarcas.CellClick
    '    If e.RowIndex >= 0 AndAlso sender.Columns(e.ColumnIndex).GetType() = GetType(DataGridViewButtonColumn) Then
    '        idmarcas = grdListaMarcas.Item(1, e.RowIndex).Value.ToString
    '        MarcaNombre = grdListaMarcas.Item(2, e.RowIndex).Value.ToString
    '        esCliente = grdListaMarcas.Item(4, e.RowIndex).Value.ToString
    '        codSicyM = grdListaMarcas.Item(5, e.RowIndex).Value.ToString
    '        etiquetaMarca = grdListaMarcas.Item(3, e.RowIndex).Value.ToString
    '        Me.Close()
    '    End If
    'End Sub

    Public Sub registraMarcaRapido()
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim dtIdMaximo As DataTable
        Dim idMarcaRegistrado As String
        Dim dtCodigoMarca As DataTable
        GenerarClave()
        Dim objMBU As New Programacion.Negocios.MarcasBU
        Dim EntidadMarca As New Entidades.Marcas

        If (txtNombreMarca.Text <> "") Then
            EntidadMarca.PActivo = True
            EntidadMarca.PCodigo = idNuevaMarca
            EntidadMarca.PDescripcion = txtNombreMarca.Text
            EntidadMarca.PSicyCodigo = txtCodSicy.Text
            EntidadMarca.PClienteMarca = CBool(ckbEsCliente.Checked)
            objMBU.RegistrarNuevaMarca(EntidadMarca, usuario)
            dtIdMaximo = objMBU.SeleccionarMaximoId
            idMarcaRegistrado = dtIdMaximo.Rows(0)(0).ToString
            dtCodigoMarca = objMBU.verCodigoRegistrado(idMarcaRegistrado)
            idmarcas = idMarcaRegistrado
            'marc_codigo, marc_descripcion, marc_codigosicy, marc_esCliente
            MarcaNombre = dtCodigoMarca.Rows(0)("marc_codigo")
            etiquetaMarca = dtCodigoMarca.Rows(0)("marc_descripcion")
            esCliente = CBool(dtCodigoMarca.Rows(0)("marc_esCliente"))
            codSicyM = dtCodigoMarca.Rows(0)("marc_codigosicy")
            esLicencia = CBool(dtCodigoMarca.Rows(0)("marc_esLicencia"))
            Me.Close()
        End If

    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtNombreMarca.Text.Trim = Nothing) Then

            If (txtNombreMarca.Text.Trim = Nothing) Then
                lblNombre.ForeColor = Drawing.Color.Red
            Else
                lblNombre.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblNombre.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function


    Public Sub GenerarClave()
        Try
            Dim dtidMarca As DataTable

            Dim MarcaNegocios As New Programacion.Negocios.MarcasBU
            Dim dtContadrorFilas As DataTable
            dtContadrorFilas = New DataTable
            dtidMarca = New DataTable
            dtidMarca = MarcaNegocios.SeleccionarMaximoId
            dtContadrorFilas = MarcaNegocios.VerMarcas
            Dim ValidacionExistePrimero As Int32 = dtContadrorFilas.Rows.Count
            Dim NuevoCod As Int32 = ValidacionExistePrimero + 1

            Dim codigoNuevo As String = String.Empty
            Dim IdMaximo As Int32 = 0
            Dim IdNuevo As Int32 = 0

            If (ValidacionExistePrimero = 0) Then
                IdNuevo = 1
                codigoNuevo = "1"

            ElseIf (ValidacionExistePrimero > 0 And ValidacionExistePrimero < 36) Then
                If (NuevoCod >= 1 And NuevoCod <= 9) Then
                    codigoNuevo = NuevoCod.ToString
                ElseIf (NuevoCod > 9) Then
                    If (NuevoCod = 10) Then
                        codigoNuevo = "A"
                    End If
                    If (NuevoCod = 11) Then
                        codigoNuevo = "B"
                    End If
                    If (NuevoCod = 12) Then
                        codigoNuevo = "C"
                    End If
                    If (NuevoCod = 13) Then
                        codigoNuevo = "D"
                    End If
                    If (NuevoCod = 14) Then
                        codigoNuevo = "E"
                    End If
                    If (NuevoCod = 15) Then
                        codigoNuevo = "F"
                    End If
                    If (NuevoCod = 16) Then
                        codigoNuevo = "G"
                    End If
                    If (NuevoCod = 17) Then
                        codigoNuevo = "H"
                    End If
                    If (NuevoCod = 18) Then
                        codigoNuevo = "I"
                    End If
                    If (NuevoCod = 19) Then
                        codigoNuevo = "J"
                    End If
                    If (NuevoCod = 20) Then
                        codigoNuevo = "K"
                    End If
                    If (NuevoCod = 21) Then
                        codigoNuevo = "L"
                    End If
                    If (NuevoCod = 22) Then
                        codigoNuevo = "M"
                    End If
                    If (NuevoCod = 23) Then
                        codigoNuevo = "N"
                    End If
                    If (NuevoCod = 24) Then
                        codigoNuevo = "Ñ"
                    End If
                    If (NuevoCod = 25) Then
                        codigoNuevo = "O"
                    End If
                    If (NuevoCod = 26) Then
                        codigoNuevo = "P"
                    End If
                    If (NuevoCod = 27) Then
                        codigoNuevo = "Q"
                    End If
                    If (NuevoCod = 28) Then
                        codigoNuevo = "R"
                    End If
                    If (NuevoCod = 29) Then
                        codigoNuevo = "S"
                    End If
                    If (NuevoCod = 30) Then
                        codigoNuevo = "T"
                    End If
                    If (NuevoCod = 31) Then
                        codigoNuevo = "U"
                    End If
                    If (NuevoCod = 32) Then
                        codigoNuevo = "V"
                    End If
                    If (NuevoCod = 33) Then
                        codigoNuevo = "W"
                    End If
                    If (NuevoCod = 34) Then
                        codigoNuevo = "X"
                    End If
                    If (NuevoCod = 35) Then
                        codigoNuevo = "Y"
                    End If
                    If (NuevoCod = 36) Then
                        codigoNuevo = "Z"
                    End If
                    idNuevaMarca = codigoNuevo
                End If
            End If
            If (ValidacionExistePrimero >= 36) Then
                Dim dtCodigosDisponibles As DataTable
                dtCodigosDisponibles = New DataTable
                dtCodigosDisponibles = MarcaNegocios.VerCodigosDisponibles()
                If (dtCodigosDisponibles.Rows.Count > 0) Then
                    Dim DatoValidacionExistente As String = dtCodigosDisponibles.Rows(0)("marc_codigo").ToString()
                    codigoNuevo = DatoValidacionExistente.ToString
                    idNuevaMarca = codigoNuevo
                Else
                    txtNombreMarca.Text = String.Empty
                    MsgBox("No hay códigos disponibles para asignar.")
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If (ValidarVacio() = True) Then
            Dim objMensajeAceptar As New ConfirmarForm
            objMensajeAceptar.mensaje = "Esta seguro de guardar cambios."
            If objMensajeAceptar.ShowDialog = Windows.Forms.DialogResult.OK Then
                registraMarcaRapido()
                Me.Close()
            Else
            End If

        ElseIf (ValidarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub txtNombreMarca_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreMarca.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreMarca.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreMarca.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaMarca()
    End Sub

    'Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
    '    If (e.KeyCode = Keys.Enter) Then
    '        LlenarTablaMarca()
    '    End If
    'End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        txtNombreMarca.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27
    End Sub

    Private Sub grdMarcas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdMarcas.ClickCell
        'marc_marcaid, marc_codigo, marc_descripcion, marc_esCliente as 'Cliente', marc_codigosicy as 'Sicy'
        If e.Cell.Column.Key = "selectMarcas" And e.Cell.Row.Index <> grdMarcas.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            idmarcas = grdMarcas.Rows(fila).Cells("marc_marcaid").Value.ToString
            MarcaNombre = grdMarcas.Rows(fila).Cells("marc_codigo").Value.ToString
            esCliente = grdMarcas.Rows(fila).Cells("Cliente").Value.ToString
            codSicyM = grdMarcas.Rows(fila).Cells("Sicy").Value.ToString
            etiquetaMarca = grdMarcas.Rows(fila).Cells("marc_descripcion").Value.ToString
            esLicencia = grdMarcas.Rows(fila).Cells("marc_eslicencia").Value.ToString
            Me.Close()
        End If
    End Sub


    Private Sub grdMarcas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdMarcas.InitializeRow
        If e.Row.Cells.Exists("selectMarcas") Then
            e.Row.Cells("selectMarcas").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub txtCodSicy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 1) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
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

    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout

    End Sub

    Public Sub LlenarTablaMarcaCedis()
        Dim objMBU As New Programacion.Negocios.MarcasBU
        Dim dtListaMacras As DataTable
        dtListaMacras = objMBU.verMarcasCedis("", idcedis)
        'grdListaMarcas.DataSource = dtListaMacras
        'grdListaMarcas.Columns(1).Visible = False
        'grdListaMarcas.Columns(0).Width = 50
        'grdListaMarcas.Columns(2).Width = 50
        'grdListaMarcas.Columns(4).Width = 50
        'grdListaMarcas.Columns(5).Width = 50

        Me.grdMarcas.DisplayLayout.Bands(0).Columns.Add("selectMarcas", "")
        Dim colckbCr As UltraGridColumn = grdMarcas.DisplayLayout.Bands(0).Columns("selectMarcas")
        colckbCr.Style = ColumnStyle.Image

        grdMarcas.DataSource = dtListaMacras

        With grdMarcas.DisplayLayout.Bands(0)
            .Columns("marc_marcaid").Hidden = True
            .Columns("marc_codigo").Header.Caption = "Código"
            .Columns("marc_descripcion").Header.Caption = "Marcas"
            .Columns("Sicy").Header.Caption = "SICY"
            .Columns("marc_esLicencia").Header.Caption = "EsLicencia"

            .Columns("marc_codigo").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("Sicy").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit

            .Columns("marc_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Sicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            .Columns("selectMarcas").Header.VisiblePosition = 1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdMarcas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub
End Class