Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class ColeccionFormRapido
    Public idMarca As Int32
    Private idColeccion As Int32
    Private coleccionCodigo As String
    Private codSicyCol As String = String.Empty
    Private nombreColeccion As String = String.Empty
    Private anio As Int32
    Private idCliente As Int32 = 0
    Private nombreCliente As String
    Public idFamiliaProyeccion As Integer = 0
    Public familiaProyeccion As String = ""

    Public Property PidColeccion As Int32
        Get
            Return idColeccion
        End Get
        Set(ByVal value As Int32)
            idColeccion = value
        End Set
    End Property

    Public Property PCodColeccion As String
        Get
            Return coleccionCodigo
        End Get
        Set(ByVal value As String)
            coleccionCodigo = value
        End Set
    End Property

    Public Property PCodSicyCol As String
        Get
            Return codSicyCol
        End Get
        Set(ByVal value As String)
            codSicyCol = value
        End Set
    End Property

    Public Property PNombreColeccion As String
        Get
            Return nombreColeccion
        End Get
        Set(ByVal value As String)
            nombreColeccion = value
        End Set
    End Property

    Public Property PAnio As Int32
        Get
            Return anio
        End Get
        Set(value As Int32)
            anio = value
        End Set
    End Property

    Public Property PidCliente As Int32
        Get
            Return idCliente
        End Get
        Set(value As Int32)
            idCliente = value
        End Set
    End Property

    Public Property PnombreCliente As String
        Get
            Return nombreCliente
        End Get
        Set(value As String)
            nombreCliente = value
        End Set
    End Property

    Dim idColeccionRapido As String

    Public Sub llenarlistaMarcas(ByVal idTemp As Int32)
        Dim objCole As New Programacion.Negocios.ColeccionBU
        Dim objTempBu As New Negocios.TemporadasBU
        Dim dtDatosColeProd As New DataTable

        Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(idTemp)
        Dim anio As Int32 = CInt(dtAnioCombo.Rows(0).Item(0).ToString)

        dtDatosColeProd = objCole.verColeccionesAnio(anio, idMarca)
        For contCods As Int32 = 1 To 99
            Dim codColeccion As String = ""
            Dim existe As Boolean = False
            If contCods <= 9 Then
                codColeccion = "0" + contCods.ToString
            Else
                codColeccion = contCods.ToString
            End If

            For Each rowDC As DataRow In dtDatosColeProd.Rows
                If codColeccion = rowDC.Item("coma_codigo").ToString Then
                    existe = True
                End If
            Next
            If existe = False Then
                txtCodigo.Text = codColeccion
                Exit For
            End If
        Next
    End Sub

    Public Sub llenarComboAnios()
        Dim tempBu As New Negocios.TemporadasBU
        Dim dtDatosTemporadas As New DataTable
        dtDatosTemporadas = tempBu.verTemporadasRegistradas()
        dtDatosTemporadas.Rows.InsertAt(dtDatosTemporadas.NewRow(), 0)
        cmbAnio.DataSource = dtDatosTemporadas
        cmbAnio.ValueMember = "temp_temporadaid"
        cmbAnio.DisplayMember = "temp_nombre"
    End Sub

    Public Sub LlenarTablaColeccion()
        Dim objCBU As New Programacion.Negocios.ColeccionBU
        Dim dtListaColeccion As DataTable
        dtListaColeccion = objCBU.verColeccionGridProducto(idMarca)
        If (idMarca = Nothing) Then
            btnAgregar.Enabled = False
        End If
        Me.grdColecciones.DisplayLayout.Bands(0).Columns.Add("selectColeccion", "")
        Dim colckbCr As UltraGridColumn = grdColecciones.DisplayLayout.Bands(0).Columns("selectColeccion")
        colckbCr.Style = ColumnStyle.Image
        grdColecciones.DataSource = dtListaColeccion
        With grdColecciones.DisplayLayout.Bands(0)
            .Columns("cole_coleccionid").Hidden = True
            .Columns("coma_familiaproyeccionid").Hidden = True
            .Columns("fapr_descripcion").Hidden = True
            .Columns("CODIGO").Header.Caption = "Código"
            .Columns("cole_Anio").Header.Caption = "Año"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("coma_codigosicy").Header.Caption = "SICY"
            .Columns("CODIGO").CellActivation = Activation.NoEdit
            .Columns("cole_Anio").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("coma_codigosicy").CellActivation = Activation.NoEdit
            .Columns("CODIGO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("coma_codigosicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("selectColeccion").Header.VisiblePosition = 1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdColecciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtNombreColeccion.Text = "" Or txtCodigo.Text = "" Or cmbAnio.SelectedIndex = 0) Then

            If (txtNombreColeccion.Text = "") Then
                lblNombre.ForeColor = Drawing.Color.Red
            Else
                lblNombre.ForeColor = Drawing.Color.Black
            End If

            If (txtCodigo.Text = "") Then
                lblCodigo.ForeColor = Drawing.Color.Red
            Else
                lblCodigo.ForeColor = Drawing.Color.Black
            End If

            If (cmbAnio.SelectedIndex = 0) Then
                lblAnio.ForeColor = Drawing.Color.Red
            Else
                lblAnio.ForeColor = Drawing.Color.Black
            End If
            Return False
        Else
            lblNombre.ForeColor = Drawing.Color.Black
            Return True
        End If

        Return True
    End Function

    Public Sub insertarColeccion()
        Dim objCBU As New Programacion.Negocios.ColeccionBU
        Dim dtIdMAsAltoColeccion As New DataTable
        Dim dtCodigoRapido As DataTable

        Dim coleNuevoID As Int32 = 0
        Dim EtiquetaLengua As Boolean = False

        Dim idTemporada As Int32 = cmbAnio.SelectedValue
        Dim anio As Int32 = 0
        Dim objTempBu As New Negocios.TemporadasBU
        Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(cmbAnio.SelectedValue.ToString)
        anio = CInt(dtAnioCombo.Rows(0).Item(0).ToString)

        Dim Coleccion As String = String.Empty
        Dim CodigoSicy As String = String.Empty
        Dim Codigo As String = String.Empty
        Coleccion = txtNombreColeccion.Text
        CodigoSicy = txtCodSicy.Text
        Codigo = txtCodigo.Text
        coleNuevoID = objCBU.InsertarColeccion(Coleccion, anio, True, idTemporada, EtiquetaLengua, CodigoSicy)

        dtIdMAsAltoColeccion = objCBU.VerIdMasAltocColeccion()
        'revisar aquí para que tambien inserte la clasificación
        objCBU.InsertarColeccionMarca(coleNuevoID, idMarca, Codigo, CodigoSicy, 1, anio, idCliente, "0", "", "0", 0, String.Empty)

        dtCodigoRapido = objCBU.verCodigoColeccionRegistroRapido(coleNuevoID, idMarca)
        Dim coleCod As String = dtCodigoRapido.Rows(0)("CODIGO").ToString
        Dim CodeSicyRegistrado As String = dtCodigoRapido.Rows(0)("coma_codigosicy").ToString
        Dim NombreColeccion As String = dtCodigoRapido.Rows(0)("cole_descripcion").ToString
        PidColeccion = coleNuevoID
        PCodColeccion = coleCod
        PCodSicyCol = CodeSicyRegistrado
        PNombreColeccion = NombreColeccion

        Dim mensaje As New ExitoForm
        mensaje.mensaje = "El registro se realizó con éxito."
        mensaje.ShowDialog()
        Me.Close()
    End Sub

    Private Sub ColeccionFormRapido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarTablaColeccion()
        llenarComboAnios()
    End Sub

    Private Sub txtNombreColeccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreColeccion.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombreColeccion.Text.Length < 50) Then

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombreColeccion.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdColecciones_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdColecciones.ClickCell
        If e.Cell.Column.Key = "selectColeccion" And e.Cell.Row.Index <> grdColecciones.Rows.FilterRow.Index Then
            Dim fila As Int32 = e.Cell.Row.Index
            PidColeccion = grdColecciones.Rows(fila).Cells("cole_coleccionid").Value.ToString
            PCodColeccion = grdColecciones.Rows(fila).Cells("CODIGO").Value.ToString
            PNombreColeccion = grdColecciones.Rows(fila).Cells("cole_descripcion").Value.ToString
            PCodSicyCol = grdColecciones.Rows(fila).Cells("coma_codigosicy").Value.ToString
            PAnio = grdColecciones.Rows(fila).Cells("cole_Anio").Value.ToString
            idFamiliaProyeccion = grdColecciones.Rows(fila).Cells("coma_familiaproyeccionid").Value.ToString
            familiaProyeccion = grdColecciones.Rows(fila).Cells("fapr_descripcion").Value.ToString
            Me.Close()
        End If
    End Sub

    Private Sub grdColecciones_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdColecciones.InitializeRow
        If e.Row.Cells.Exists("selectColeccion") Then
            e.Row.Cells("selectColeccion").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        pnlHeader.Height = 27

    End Sub

    Private Sub txtCodSicy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtCodSicy.Text.Length < 2) Then

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

    Private Sub cmbAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged
        If Not cmbAnio.SelectedIndex = 0 Then
            llenarlistaMarcas(CInt(cmbAnio.SelectedValue.ToString))
        Else
            txtCodigo.Text = ""
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ValidarVacio() = True Then
            insertarColeccion()
        Else
            Dim mensaje As New ExitoForm
            mensaje.mensaje = "Complete los campos obligatorios."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        pnlHeader.Height = 136
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim objClientesList As New ListaConsultaClientesForm
        objClientesList.accionFormulario = "consultaCColeccion"
        objClientesList.idMarca = idMarca
        objClientesList.ShowDialog()
        idCliente = objClientesList.pIdClienteList
        lblNombreCliente.Text = objClientesList.pNombreCliente
    End Sub
End Class