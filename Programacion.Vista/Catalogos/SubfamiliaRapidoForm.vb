Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class SubfamiliaRapidoForm
    Dim idSubFamilia As Int32
    Public idSubFamiliaDato As Int32
    Public NombreSubfamilia As String
    Dim dtSubsSeleccionadas As DataTable
    Public datosPreviosSeleccion As DataTable

    Public Property PSubFamiliaId As Int32
        Get
            Return idSubFamiliaDato
        End Get
        Set(ByVal value As Int32)
            idSubFamiliaDato = value
        End Set
    End Property

    Public Property PNombreSubfmailia As String
        Get
            Return NombreSubfamilia
        End Get
        Set(ByVal value As String)
            NombreSubfamilia = value
        End Set
    End Property

    Public Property PDTSubfamilias As DataTable
        Get
            Return dtSubsSeleccionadas
        End Get
        Set(value As DataTable)
            dtSubsSeleccionadas = value
        End Set
    End Property

    Public Property PDTdatosPrevioSeleccion As DataTable
        Get
            Return datosPreviosSeleccion
        End Get
        Set(value As DataTable)
            datosPreviosSeleccion = value
        End Set
    End Property


    Public Sub LlenarTablaFamilia()
        Dim objFBU As New Programacion.Negocios.SubfamiliasBU
        Dim dtListaFamilias As DataTable

        dtListaFamilias = objFBU.verComboSubamilias("")

        Me.grdSubfamilias.DisplayLayout.Bands(0).Columns.Add("selectSubfamilia", "")
        Dim colckbCr As UltraGridColumn = grdSubfamilias.DisplayLayout.Bands(0).Columns("selectSubfamilia")
        colckbCr.Style = ColumnStyle.CheckBox

        grdSubfamilias.DataSource = dtListaFamilias

        With grdSubfamilias.DisplayLayout.Bands(0)
            .Columns("subf_Subfamiliaid").Header.Caption = "Código"
            .Columns("subf_descripcion").Header.Caption = "Aplicaciones"
            .Columns("subf_Subfamiliaid").CellActivation = Activation.NoEdit
            .Columns("subf_descripcion").CellActivation = Activation.NoEdit
            .Columns("subf_Subfamiliaid").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("selectSubfamilia").Header.VisiblePosition = 0
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdSubfamilias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        For Each rowSFDT As UltraGridRow In grdSubfamilias.Rows
            rowSFDT.Cells("selectSubfamilia").Value = False
        Next
        If Not datosPreviosSeleccion Is Nothing Then
            For Each rowSeleccionDT As UltraGridRow In grdSubfamilias.Rows
                For Each rowsSDT As DataRow In datosPreviosSeleccion.Rows
                    If rowSeleccionDT.Cells("subf_Subfamiliaid").Value.ToString = rowsSDT.Item("subf_Subfamiliaid").ToString Then
                        rowSeleccionDT.Cells("selectSubfamilia").Value = True
                    End If
                Next
            Next
        End If
    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtNombreSubamilia.Text.Trim = Nothing) Then
            If (txtNombreSubamilia.Text.Trim = Nothing) Then
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

    Public Sub AltaFamilia()
        Dim dtIdSubFam As DataTable
        Dim dtSubfamiliasSeleccionadas As New DataTable

        Dim objSub As New Programacion.Negocios.SubfamiliasBU
        Dim EnFamilia As New Entidades.Subfamilias
        EnFamilia.PDescripcion = txtNombreSubamilia.Text.Trim
        EnFamilia.PActivo = True

        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        objSub.RegistraSubfamilia(EnFamilia, usuario)
        Me.Close()
        Dim dtIdMaximo As DataTable
        dtIdMaximo = objSub.idMaxSubfamilia
        Dim idMax As Int32 = CInt(dtIdMaximo.Rows(0)(0).ToString)
        dtIdSubFam = objSub.VerCodigoSubfamiliaRapido(idMax)
        idSubFamilia = idMax
        NombreSubfamilia = dtIdSubFam.Rows(0)(1).ToString

        dtSubfamiliasSeleccionadas.Columns.Add("idSubfamilia")
        dtSubfamiliasSeleccionadas.Columns.Add("subfamiliaNombre")
        dtSubfamiliasSeleccionadas.Rows.Add()
        dtSubfamiliasSeleccionadas.Rows(0).Item("idSubfamilia") = idMax
        dtSubfamiliasSeleccionadas.Rows(0).Item("subfamiliaNombre") = NombreSubfamilia

        PDTSubfamilias = dtSubfamiliasSeleccionadas

        Me.Close()
    End Sub

    Private Sub SubfamiliaRapidoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarTablaFamilia()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If (ValidarVacio() = True) Then
            Dim objMensajeAceptar As New ConfirmarForm
            objMensajeAceptar.mensaje = "Esta seguro de guardar cambios."
            If objMensajeAceptar.ShowDialog = Windows.Forms.DialogResult.OK Then
                AltaFamilia()
            Else
                idSubFamilia = String.Empty
            End If
        ElseIf (ValidarVacio() = False) Then
            Dim mensaje As New AdvertenciaForm
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()

        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If (e.KeyCode = Keys.Enter) Then
            LlenarTablaFamilia()
        End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LlenarTablaFamilia()
    End Sub

    Private Sub txtNombreSubamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreSubamilia.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreSubamilia.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreSubamilia.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        txtNombreSubamilia.Focus()
        pnlHeader.Height = 83
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtSubfamiliasSeleccionadas As New DataTable
        dtSubfamiliasSeleccionadas.Columns.Add("idSubfamilia")
        dtSubfamiliasSeleccionadas.Columns.Add("subfamiliaNombre")

        Dim contSub As Int32
        contSub = 0
        For Each rowDTSF As UltraGridRow In grdSubfamilias.Rows

            If rowDTSF.Cells("selectSubfamilia").Value = True Then
                dtSubfamiliasSeleccionadas.Rows.Add()
                dtSubfamiliasSeleccionadas.Rows(contSub).Item("idSubfamilia") = rowDTSF.Cells("subf_Subfamiliaid").Value.ToString
                dtSubfamiliasSeleccionadas.Rows(contSub).Item("subfamiliaNombre") = rowDTSF.Cells("subf_descripcion").Value.ToString
                contSub = contSub + 1
            End If

        Next

        PDTSubfamilias = dtSubfamiliasSeleccionadas

        Me.Close()
    End Sub



End Class