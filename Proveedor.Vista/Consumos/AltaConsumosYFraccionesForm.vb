Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win
Imports System.Windows.Forms
Imports System.Drawing
Imports Proveedores.BU
Imports System.Net

Public Class AltaConsumosYFraccionesForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim dtConsumoMuestra As New DataTable()
    Dim dtFraccionesMuestra As New DataTable()
    Dim dtConsumoProduccion As New DataTable()
    Dim dtFraccionesProduccion As New DataTable()

    Dim consumosAgregados As Integer = 0

    Public nave As Integer
    Public productoid As Integer = 0
    Public codigo As Integer
    Public descripcion As String
    Public marca As String
    Public coleccion As String
    Public grupo As String
    Public tipo As String
    Public aplicacion As String
    Public temporada As String
    Public tablaNavesHistorial As New DataTable
    Public tablaEstatus As New DataTable

    Dim sumaMateriales As Double

    Dim listaEstatus As New ValueList

    Private Sub AltaConsumosYFraccionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarNaves()
        'crearTabla()
        'AgregarFilaConsumos()
        ' AgregarFilaFracciones()
        'diseniogrdConsumos()
        ' diseniogrdFracciones()
        LlenarListasNaves()
        CONSULTAMODELO()
        crearTablaHistorialNaves()
        llenarComboEstatus()
        tablaConsumos()
        diseniogrdConsumos()
        tablaFracciones()
        diseniogrdFracciones()
    End Sub

    Public Sub tablaConsumos()
        Dim obj As New ConsumosBU
        Dim dtTablaConsumos As DataTable
        dtTablaConsumos = obj.tablaConsumos
        grdConsumos.DataSource = dtTablaConsumos
    End Sub

    Public Sub tablaFracciones()
        Dim obj As New ConsumosBU
        Dim dtTablafracciones As DataTable
        dtTablafracciones = obj.tablaFracciones
        grdFracciones.DataSource = dtTablafracciones
    End Sub

    ''' <summary>
    ''' Agregar foto del modelo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAgregarFotografia_Click(sender As Object, e As EventArgs) Handles btnAgregarFotografia.Click

        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picFotografia.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            txtFotografia.Text = "/Administracion/Proveedores/" + ofdFoto.FileName
        End If

    End Sub

    ''' <summary>
    ''' Agregar foto de suela
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAgregarSuela_Click(sender As Object, e As EventArgs) Handles btnAgregarSuela.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picSuela.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            txtSuela.Text = "/Administracion/Proveedores/" + ofdFoto.FileName
        End If
    End Sub

    ''' <summary>
    ''' Agregar foto de la caja
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAgregarCaja_Click(sender As Object, e As EventArgs) Handles btnAgregarCaja.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picCaja.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            txtCaja.Text = "/Administracion/Proveedores/" + ofdFoto.FileName
        End If
    End Sub

    ''' <summary>
    ''' Limpiar foto de modelo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuitarFotografia_Click(sender As Object, e As EventArgs) Handles btnQuitarFotografia.Click
        picFotografia.Image = Nothing
        txtFotografia.Text = ""
    End Sub

    ''' <summary>
    ''' Limpiar foto de suela
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuitarSuela_Click(sender As Object, e As EventArgs) Handles btnQuitarSuela.Click
        picSuela.Image = Nothing
        txtSuela.Text = ""
    End Sub

    ''' <summary>
    ''' Limpiar foto de caja
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnQuitarCaja_Click(sender As Object, e As EventArgs) Handles btnQuitarCaja.Click
        picCaja.Image = Nothing
        txtCaja.Text = ""
    End Sub

    ''' <summary>
    ''' Guardar registros
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtFotografia.Text = "" Then
            objAdvertencia.mensaje = "No hay fotografia del modelo registrada"
            objAdvertencia.ShowDialog()
        End If

        If txtSuela.Text = "" Then
            objAdvertencia.mensaje = "No hay fotografia de suela registrada"
            objAdvertencia.ShowDialog()
        End If

        If txtCaja.Text = "" Then
            objAdvertencia.mensaje = "No hay fotografia de caja registrada"
            objAdvertencia.ShowDialog()
        End If

        If grdConsumos.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay Consumos registrados para este producto"
            objAdvertencia.ShowDialog()
        End If

        If grdFracciones.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay fracciones registradas para este consumo"
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub LlenarNaves()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaNaves As New DataTable
        dtListaNaves = objBU.ListaNaves
        'dtListaMarcas.Rows.InsertAt(dtListaMarcas.NewRow, 0)
        cmbUNaves.DataSource = dtListaNaves
        cmbUNaves.ValueMember = "NAVE ID"
        cmbUNaves.DisplayMember = "NOMBRE"
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarListasNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Sub CONSULTAMODELO()

        Dim obj As New ConsumosBU
        Dim dtModelo As New DataTable
        If productoid <> 0 Then
            dtModelo = obj.ConsultaProductosEspecifico(productoid)
            lblCodigoClienteD.Text += " " + dtModelo.Rows(0).Item("CODIGO CLIENTE").ToString
            lblFamiliaD.Text += " " + dtModelo.Rows(0).Item("FAMILIA").ToString
            lblLineaD.Text += " " + dtModelo.Rows(0).Item("LINEA").ToString
            lblCorridaD.Text += " " + dtModelo.Rows(0).Item("CORRIDA").ToString
            lblHormaD.Text += " " + dtModelo.Rows(0).Item("HORMA").ToString
            lblForroD.Text += " " + dtModelo.Rows(0).Item("FORRO").ToString
            lblSuelaD.Text += " " + dtModelo.Rows(0).Item("SUELA").ToString
            lblPielColorD.Text += " " + dtModelo.Rows(0).Item("PIEL").ToString + " " + dtModelo.Rows(0).Item("COLOR").ToString
            lblImagen.Text = dtModelo.Rows(0).Item("IMAGEN").ToString
            lblCorteD.Text += " " + dtModelo.Rows(0).Item("CORTE").ToString

            lblCodigoD.Text += " " + codigo.ToString
            lblDescripcionD.Text += " " + descripcion.ToString
            lblMarcaD.Text += " " + marca.ToString
            lblColeccionD.Text += " " + coleccion.ToString
            lblGrupoD.Text += " " + grupo.ToString
            lblTipoD.Text += " " + tipo.ToString
            lblAplicacionD.Text += " " + aplicacion.ToString
            lblTemporadaD.Text += " " + temporada.ToString


            If lblImagen.Text <> "" Then
                Dim rutaImagen As String
                Dim nombreImagen As String


                rutaImagen = lblImagen.Text
                nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
                Try
                    'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                    'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                    Dim objFTP As New Tools.TransferenciaFTP
                    Dim Stream As System.IO.Stream
                    Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                    picFotografia.Image = Image.FromStream(Stream)
                Catch
                End Try

            ElseIf lblFotografia.Text = "" Then

                Dim imagen As String = "noimage.jpg"
                Try
                    'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                    'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                    Dim objFTP As New Tools.TransferenciaFTP
                    Dim Stream As System.IO.Stream
                    Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)

                    picFotografia.Image = Image.FromStream(Stream)
                    picFotografia.SizeMode = PictureBoxSizeMode.Normal
                Catch
                End Try
            End If
        End If
    End Sub

    Public Sub crearTabla()
        dtConsumoMuestra.Columns.Add("EXPLOSIONAR")
        dtConsumoMuestra.Columns.Add("COMPONENTE")
        dtConsumoMuestra.Columns.Add("FAMILIA")
        dtConsumoMuestra.Columns.Add("MATERIAL")
        dtConsumoMuestra.Columns.Add("UMC")
        dtConsumoMuestra.Columns.Add("CONSUMO")
        dtConsumoMuestra.Columns.Add("UMP")

        dtFraccionesMuestra.Columns.Add("FRACCIÓN")
        dtFraccionesMuestra.Columns.Add("COSTO")
        dtFraccionesMuestra.Columns.Add("PAGAR")
        dtFraccionesMuestra.Columns.Add("OBSERVACIONES")

        dtConsumoProduccion.Columns.Add("EXPLOSIONAR")
        dtConsumoProduccion.Columns.Add("COMPONENTE")
        dtConsumoProduccion.Columns.Add("FAMILIA")
        dtConsumoProduccion.Columns.Add("MATERIAL")
        dtConsumoProduccion.Columns.Add("PROVEEDOR")
        dtConsumoProduccion.Columns.Add("PRECIO COMPRA")
        dtConsumoProduccion.Columns.Add("UMC")
        dtConsumoProduccion.Columns.Add("PRECIO UMC")
        dtConsumoProduccion.Columns.Add("CONSUMO")
        dtConsumoProduccion.Columns.Add("UMP")
        dtConsumoProduccion.Columns.Add("COSTO")

        dtFraccionesProduccion.Columns.Add("COSTO")
        dtFraccionesProduccion.Columns.Add("PAGAR")
        dtFraccionesProduccion.Columns.Add("OBSERVACIONES")

        grdConsumos.DataSource = dtConsumoMuestra
        grdFracciones.DataSource = dtFraccionesMuestra
    End Sub

    'Public Sub llenarCombos()
    '    llenarComboHormas()
    '    llenarComboFamilia()
    '    llenarComboForro()
    '    llenarComboLinea()
    '    llenarComboSuela()
    '    llenarComboColor()
    '    llenarComboTemporadas()
    '    llenarComboPiel()
    'End Sub

    'Public Sub LlenarComboNavesSegunUsuario()
    '    cmbNaveDesarrolla = Tools.Controles.ComboNavesSegunUsuario(cmbNaveDesarrolla, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    'End Sub

    'Public Sub llenarComboHormas()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getHormas
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbHorma.DataSource = lstCateg
    '        cmbHorma.DisplayMember = "NOMBRE"
    '        cmbHorma.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboTemporadas()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getTemporadas
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbTemporada.DataSource = lstCateg
    '        cmbTemporada.DisplayMember = "NOMBRE"
    '        cmbTemporada.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboForro()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getForro
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbForro.DataSource = lstCateg
    '        cmbForro.DisplayMember = "NOMBRE"
    '        cmbForro.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboSuela()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getSuelas
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbSuela.DataSource = lstCateg
    '        cmbSuela.DisplayMember = "NOMBRE"
    '        cmbSuela.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboCorrida()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getHormas
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbCorrida.DataSource = lstCateg
    '        cmbCorrida.DisplayMember = "NOMBRE"
    '        cmbCorrida.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboLinea()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getLineas
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbLineaEstilo.DataSource = lstCateg
    '        cmbLineaEstilo.DisplayMember = "NOMBRE"
    '        cmbLineaEstilo.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboColor()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getColores
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbColor.DataSource = lstCateg
    '        cmbColor.DisplayMember = "NOMBRE"
    '        cmbColor.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboPiel()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getPieles
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbPiel.DataSource = lstCateg
    '        cmbPiel.DisplayMember = "NOMBRE"
    '        cmbPiel.ValueMember = "ID"
    '    End If
    'End Sub

    'Public Sub llenarComboFamilia()
    '    Dim obj As New MaterialesBU
    '    Dim lstCateg As DataTable
    '    lstCateg = obj.getFamilias
    '    If Not lstCateg.Rows.Count = 0 Then
    '        lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
    '        cmbFamilia.DataSource = lstCateg
    '        cmbFamilia.DisplayMember = "NOMBRE"
    '        cmbFamilia.ValueMember = "ID"
    '    End If
    'End Sub

    Public Sub diseniogrdConsumos()
        With grdConsumos.DisplayLayout.Bands(0)

            '.Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("UMP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("CONSUMO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.Columns("EXPLOSIONAR").Width = 70
            '.Columns("COMPONENTE").Width = 120
            '.Columns("FAMILIA").Width = 120
            '.Columns("MATERIAL").Width = 250
            '.Columns("UMC").Width = 70
            '.Columns("CONSUMO").Width = 70
            '.Columns("UMP").Width = 70
            '.Columns("EXPLOSIONAR").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns("EXPLOSIONAR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '.Columns("EXPLOSIONAR").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            '.Columns("EXPLOSIONAR").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            '.Columns("FAMILIA").Style = Infragistics.Win.UltraWinGrid.Case.Upper
            '.Columns("MATERIAL").Style = Infragistics.Win.UltraWinGrid.Case.Upper
            '.Columns("CONSUMO").Style = Infragistics.Win.UltraWinGrid.Case.Upper
            '.Columns("COMPONENTE").Style = Infragistics.Win.UltraWinGrid.Case.Upper
            '.Columns("UMP").Style = Infragistics.Win.UltraWinGrid.Case.Upper
            '.Columns("UMC").Style = Infragistics.Win.UltraWinGrid.Case.Upper

            'Dim obj As New Proveedores.BU.OrdenesDeCompra
            'Dim lsta, lsta2, lsta3 As DataTable
            'lsta = obj.ListaPaises()
            'lsta2 = obj.ListaFamilias()
            'lsta3 = obj.ListaMaterialesPorNave(2)
            'Dim listaValoresMotivos, listaValoresMotivos2, listaValoresMotivos3 As New ValueList

            'For Each rowDt As DataRow In lsta3.Rows
            '    If lsta.Rows.Count > 0 Then
            '        listaValoresMotivos3.ValueListItems.Add(rowDt.Item("ID MATERIAL"), rowDt.Item("DESCRIPCION").ToString.ToUpper.Trim)
            '    End If
            'Next
            'grdConsumos.DisplayLayout.Bands(0).Columns("MATERIAL").Style = UltraWinGrid.ColumnStyle.DropDown
            'grdConsumos.DisplayLayout.Bands(0).Columns("MATERIAL").ValueList = listaValoresMotivos3

            'For Each rowDt As DataRow In lsta2.Rows
            '    If lsta2.Rows.Count > 0 Then
            '        listaValoresMotivos2.ValueListItems.Add(rowDt.Item("ID"), rowDt.Item("Familia").ToString.ToUpper.Trim)
            '    End If
            'Next
            'grdConsumos.DisplayLayout.Bands(0).Columns("FAMILIA").Style = UltraWinGrid.ColumnStyle.DropDown
            'grdConsumos.DisplayLayout.Bands(0).Columns("FAMILIA").ValueList = listaValoresMotivos2

            .Columns("Bloq").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloq").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Bloq").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloq").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Lotear").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Lotear").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Lotear").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Lotear").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Explosionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Explosionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Explosionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Explosionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdConsumos.Rows.Count - 1
                If grdConsumos.Rows(value).Cells("Explosionar").Text = 1 Then
                    grdConsumos.Rows(value).Cells("Explosionar").Value = True
                ElseIf grdConsumos.Rows(value).Cells("Explosionar").Text = 0 Then
                    grdConsumos.Rows(value).Cells("Explosionar").Value = False
                End If
                '¡Double=Double+grdConsumos.Rows(value).Cells("Costo par").Value
            Next

            grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub diseniogrdFracciones()
        With grdFracciones.DisplayLayout.Bands(0)
            '.Columns("COSTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("PAGAR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            '.Columns("COSTO").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            '.Columns("FRACCIÓN").Width = 250
            '.Columns("COSTO").Width = 70
            '.Columns("PAGAR").Width = 70
            '.Columns("OBSERVACIONES").Width = 250

            'For value = 0 To grdFracciones.Rows.Count - 1
            '    If grdFracciones.Rows(value).Cells("Pagar").Text = 1 Then
            '        grdFracciones.Rows(value).Cells("Pagar").Value = True
            '    ElseIf grdFracciones.Rows(value).Cells("Pagar").Text = 0 Then
            '        grdFracciones.Rows(value).Cells("Pagar").Value = False
            '    End If
            'Next

            .Columns("Bloq").Width = 30
            .Columns("Pagar").Width = 30

            .Columns("Bloq").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloq").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Bloq").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloq").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Pagar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Pagar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Pagar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Pagar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Doble").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Doble").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Doble").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Doble").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs)
        AgregarFilaConsumos()
        consumosAgregados = consumosAgregados + 1
    End Sub

    Public Sub AgregarFilaConsumos()
        grdConsumos.DisplayLayout.Bands(0).AddNew()
        With grdConsumos.DisplayLayout.Bands(0)
            .Columns("EXPLOSIONAR").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("EXPLOSIONAR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("EXPLOSIONAR").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("EXPLOSIONAR").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("FAMILIA").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown
            grdConsumos.ActiveRow.Cells("EXPLOSIONAR").Value = False
        End With
    End Sub

    Public Sub AgregarFilaFracciones()
        grdFracciones.DisplayLayout.Bands(0).AddNew()
        With grdFracciones.DisplayLayout.Bands(0)
            .Columns("PAGAR").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("PAGAR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("PAGAR").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("PAGAR").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("COSTO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grdFracciones.ActiveRow.Cells("PAGAR").Value = False
        End With
    End Sub

    Private Sub grdConsumos_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles grdConsumos.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        If grdConsumos.ActiveRow.Cells("CONSUMO").Text <> "" And grdConsumos.ActiveRow.Cells("MATERIAL").Text <> "" And grdConsumos.ActiveRow.Cells("FAMILIA").Text <> "" And grdConsumos.ActiveRow.Cells("COMPONENTE").Text <> "" And VALUE = 13 Then
            AgregarFilaConsumos()
        End If
    End Sub

    Private Sub grdFracciones_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles grdFracciones.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        If grdFracciones.ActiveRow.Cells("FRACCIÓN").Text <> "" And VALUE = 13 Then
            AgregarFilaFracciones()
        End If
    End Sub

    Private Sub rdoIndirecto_CheckedChanged(sender As Object, e As EventArgs)

        grdConsumos.DataSource = dtConsumoMuestra
        lblPie.Text = "Total de Materiales Indirectos"
        lblPie.Visible = True
        lblCantidadDirectos.Visible = True

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim form As New ListaDeNavesCopiarConsumoForm
        If form.ShowDialog = Windows.Forms.DialogResult.Yes Then

        Else
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCopiarModelo.Click
        Dim form2 As New listaModelosRegistradosNaveForm
        form2.copiarconsumos = 1
        form2.lblMensaje.Text += "Seleccione el estilo del cual desea copiar sus Consumos"
        If form2.ShowDialog = Windows.Forms.DialogResult.Yes Then

        Else
        End If
    End Sub

    Private Sub tbcImagenesConsumosFracciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcImagenesConsumosFracciones.SelectedIndexChanged
        If tbcImagenesConsumosFracciones.SelectedIndex = 0 Then
            lblPie.Visible = False
            lblCantidadDirectos.Visible = False
        End If
        If tbcImagenesConsumosFracciones.SelectedIndex = 1 Then

            lblPie.Text = "Total de Materiales Directos"
            lblPie.Visible = True
            lblCantidadDirectos.Visible = True

        End If
        If tbcImagenesConsumosFracciones.SelectedIndex = 2 Then
            lblPie.Text = "Total de Fracciones"
            lblPie.TextAlign = ContentAlignment.TopRight
            lblPie.Visible = True
            lblCantidadDirectos.Visible = True
        End If
    End Sub

    Public Sub crearTablaHistorialNaves()
        tablaNavesHistorial.Columns.Add("ACTIVO")
        tablaNavesHistorial.Columns.Add("NAVE")
        tablaNavesHistorial.Columns.Add("FECHA AUTORIZACIÓN")
        tablaNavesHistorial.Columns.Add("FECHA INICIO PRODUCCIÓN")
        tablaNavesHistorial.Columns.Add("FECHA DESACTIVACIÓN")
        tablaNavesHistorial.Columns.Add("ESTATUS")

        grdNavesHistorial.DataSource = tablaNavesHistorial
        disenioNaveHistorial()
    End Sub

    Public Sub llenarComboEstatus()
        tablaEstatus.Columns.Add("ID")
        tablaEstatus.Columns.Add("ESTATUS")
        tablaEstatus.Rows.Add("0", "")
        tablaEstatus.Rows.Add("1", "AUTORIZADO")
        tablaEstatus.Rows.Add("2", "NO AUTORIZADO")
        tablaEstatus.Rows.Add("3", "INACTIVO")

        cmbEstatus.DataSource = tablaEstatus
        cmbEstatus.DisplayMember = "ESTATUS"
        cmbEstatus.ValueMember = "ID"

        listaEstatus.ValueListItems.Add("")
        listaEstatus.ValueListItems.Add("AUTORIZADO")
        listaEstatus.ValueListItems.Add("NO AUTORIZADO")
        listaEstatus.ValueListItems.Add("INACTIVO")
    End Sub

    Public Sub disenioNaveHistorial()
        With grdNavesHistorial.DisplayLayout.Bands(0)

            .Columns("NAVE").Width = 80
            .Columns("FECHA AUTORIZACIÓN").Width = 170
            .Columns("FECHA INICIO PRODUCCIÓN").Width = 170
            .Columns("ESTATUS").Width = 90

            .Columns("ACTIVO").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("ACTIVO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("ACTIVO").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("ACTIVO").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("FECHA AUTORIZACIÓN").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
            .Columns("FECHA DESACTIVACIÓN").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
            .Columns("ESTATUS").Style = UltraWinGrid.ColumnStyle.DropDown
            .Columns("ESTATUS").ValueList = listaEstatus
            .Columns("FECHA INICIO PRODUCCIÓN").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        End With
        grdNavesHistorial.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub btnAgregarNAves_Click(sender As Object, e As EventArgs) Handles btnAgregarNAves.Click
        Dim dtDatosFiltrados As New DataTable
        Dim cadena As String = cmbUNaves.Text
        Dim naves() As String
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        naves = Split(Trim(cadena), ",")

        For value = 0 To naves.Length - 1
            grdNavesHistorial.DisplayLayout.Bands(0).AddNew()
            grdNavesHistorial.ActiveRow.Cells("NAVE").Value = naves(value)
            grdNavesHistorial.ActiveRow.Cells("ACTIVO").Value = True
            grdNavesHistorial.ActiveRow.Cells("ESTATUS").Value = cmbEstatus.Text
        Next

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Dim form2 As New listaModelosRegistradosNaveForm
        form2.lblMensaje.Text += "Seleccione el estilo del cual desea copiar sus Fracciones"
        If form2.ShowDialog = Windows.Forms.DialogResult.Yes Then

        Else
        End If
    End Sub

    Private Sub grdConsumos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdConsumos.DoubleClickCell
        Dim form As New listaProveedoresConsumosForm
        Dim form2 As New ListaMaterialesForm
        If grdConsumos.ActiveRow.Cells("Proveedor").IsActiveCell = True Then
            form.ShowDialog()
        End If

        If grdConsumos.ActiveRow.Cells("Material").IsActiveCell Then
            form2.ShowDialog()
        End If
    End Sub
End Class