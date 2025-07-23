Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class temporadaFormRapido
    Dim idNuevaTemp As String
    Public idTemporada As Int32
    Public codTemporada As String
    Public NombreTemporada As String
    Public anio As String


    Public Property PidTemporada As Int32
        Get
            Return idTemporada
        End Get
        Set(ByVal value As Int32)
            idTemporada = value
        End Set
    End Property

    Public Property PCodTemporada As String
        Get
            Return codTemporada
        End Get
        Set(ByVal value As String)
            codTemporada = value
        End Set
    End Property

    Public Property PNombreTemporada As String
        Get
            Return NombreTemporada
        End Get
        Set(ByVal value As String)
            NombreTemporada = value
        End Set
    End Property

    Public Property PAnio As String
        Get
            Return anio
        End Get
        Set(ByVal value As String)
            anio = value
        End Set
    End Property

    Public Sub LlenarTablaTemporada()
        Dim objMBU As New Programacion.Negocios.TemporadasBU
        Dim dtListaTemporadas As DataTable
        dtListaTemporadas = objMBU.verComboTemporadas("")
        Me.grdTemporadas.DisplayLayout.Bands(0).Columns.Add("selectTemporada", "")
        Dim colckbCr As UltraGridColumn = grdTemporadas.DisplayLayout.Bands(0).Columns("selectTemporada")
        colckbCr.Style = ColumnStyle.Image
        grdTemporadas.DataSource = dtListaTemporadas

        With grdTemporadas.DisplayLayout.Bands(0)
            .Columns("temp_temporadaid").Hidden = True
            .Columns("temp_codigo").Header.Caption = "Código"
            .Columns("descripcion").Header.Caption = "Temporada"
            .Columns("temp_año").Header.Caption = "Año"

            .Columns("temp_codigo").CellActivation = Activation.NoEdit
            .Columns("descripcion").CellActivation = Activation.NoEdit
            .Columns("temp_año").CellActivation = Activation.NoEdit

            .Columns("temp_codigo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("temp_año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("selectTemporada").Header.VisiblePosition = 1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdTemporadas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub


    Public Sub GenerarCodigo()
        Dim objSBU As New Programacion.Negocios.TemporadasBU
        Dim dtContador As DataTable = objSBU.ContarFilasTemporadas
        Dim dtIdMaximo As DataTable = objSBU.VerMaximoIdTemporada
        Dim contador As Int32 = Convert.ToInt32(dtContador.Rows(0)(0).ToString)
        Dim idMaximo As Int32 = 0
        Dim idNuevo As Int32 = 0
        Dim idNuevoCadena As String = String.Empty

        If (contador >= 1) Then
            idMaximo = Convert.ToInt32(dtIdMaximo.Rows(0)(0).ToString)
            If (idMaximo < 99) Then
                idNuevo = idMaximo + 1
                If (idNuevo >= 1 And idNuevo <= 9) Then
                    idNuevoCadena = "0" + idNuevo.ToString
                    idNuevaTemp = idNuevoCadena
                Else
                    idNuevaTemp = idNuevo.ToString
                End If
            ElseIf (idMaximo >= 99) Then
                Dim dtCodigosDisponibles As DataTable
                dtCodigosDisponibles = objSBU.verCodigosDiscponibles
                idNuevoCadena = dtCodigosDisponibles.Rows(0)(0)
                idNuevaTemp = idNuevoCadena
            End If
        Else
            idNuevoCadena = "01"
            idNuevaTemp = idNuevoCadena
        End If
    End Sub

    Public Sub registrarTemporada()

        GenerarCodigo()
        Dim objTBU As New Programacion.Negocios.TemporadasBU
        Dim entidadTemporada As New Entidades.Temporadas
        Dim dtTemporada As DataTable
        entidadTemporada.pCodigoTemporada = idNuevaTemp
        entidadTemporada.pNombreTemporada = txtNombreTemporada.Text
        entidadTemporada.pAnioTemporada = txtAnio.Text
        entidadTemporada.pActivoTemporada = True
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objTBU.RegistrarTemporada(entidadTemporada, usuario)
        Dim dtIdMaximo As DataTable = objTBU.VerMaximoIdTemporada
        Dim idMax As Int32 = dtIdMaximo.Rows(0)(0).ToString
        dtTemporada = objTBU.VerTemporadaRegistroRapido(idMax)
        PidTemporada = idMax
        PCodTemporada = dtTemporada.Rows(0)("temp_codigo").ToString
        PNombreTemporada = dtTemporada.Rows(0)("temp_nombre").ToString
        PAnio = dtTemporada.Rows(0)("temp_año").ToString
        Me.Close()
    End Sub

    Public Function validaVacio() As Boolean

        If (txtNombreTemporada.Text = Nothing) Then
            lblNombre.ForeColor = Drawing.Color.Red
            Return False
        End If
        If (txtAnio.Text = Nothing Or txtAnio.TextLength < 4 Or txtAnio.TextLength > 4) Then
            lblAnio.ForeColor = Drawing.Color.Red
            Return False
        End If
        Return True
    End Function

    Private Sub temporadaFormRapido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarTablaTemporada()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If (validaVacio() = True) Then
            Dim objMensajeAceptar As New ConfirmarForm
            objMensajeAceptar.mensaje = "Esta seguro de guardar cambios."
            If objMensajeAceptar.ShowDialog = Windows.Forms.DialogResult.OK Then
                registrarTemporada()
                Me.Close()
            Else
            End If
        Else
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados correctamente."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub txtNombreTemporada_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreTemporada.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreTemporada.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "-")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreTemporada.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtAnio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAnio.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtAnio.Text.Length < 4) Then

            If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
                If Char.IsLower(e.KeyChar) Then
                    txtAnio.SelectedText = Char.ToUpper(e.KeyChar)
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        LlenarTablaTemporada()
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            LlenarTablaTemporada()
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        txtNombreTemporada.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27
    End Sub

    Private Sub grdTemporadas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdTemporadas.ClickCell
        If e.Cell.Column.Key = "selectTemporada" And e.Cell.Row.Index <> grdTemporadas.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PidTemporada = grdTemporadas.Rows(fila).Cells("temp_temporadaid").Value.ToString
            PCodTemporada = grdTemporadas.Rows(fila).Cells("temp_codigo").Value.ToString
            PNombreTemporada = grdTemporadas.Rows(fila).Cells("descripcion").Value.ToString
            PAnio = grdTemporadas.Rows(fila).Cells("temp_año").Value.ToString
            Me.Close()
        End If

    End Sub

    Private Sub grdTemporadas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdTemporadas.InitializeRow
        If e.Row.Cells.Exists("selectTemporada") Then
            e.Row.Cells("selectTemporada").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Function txtDescripcion() As Object
        Throw New NotImplementedException
    End Function

End Class