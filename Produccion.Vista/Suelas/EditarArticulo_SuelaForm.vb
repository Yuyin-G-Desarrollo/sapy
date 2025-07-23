Imports System.Net
Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools

Public Class EditarArticulo_SuelaForm
    Public CadenaListaArticulo1 As String
    Public CadenaListaArticulo2 As String
    Public CadenaListaArticulo3 As String
    Public registros As Int32
    Public listaArticulo As Produccion_Suelas_CargarDatosSuelasEnArticulos_Form
    Dim ColorSuela As Int32 = 0
    Dim exitoMensaje As New ExitoForm
    Dim FotoPrimero As System.IO.Stream
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim rutaFtp As String = objFTP.obtenerURL
    Dim FtpUser As String = objFTP.obtenerUsuario
    Dim ftppasswd As String = objFTP.obtenerContrasena
    Dim cerrarGuardar As Boolean = False
    Public vLstIdArticulo As New List(Of ArticuloCargaSuela)

    Private Sub EditarArticulo_SuelaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim request = DirectCast(WebRequest.Create(rutaFtp), FtpWebRequest)
        request.Credentials = New NetworkCredential(FtpUser, ftppasswd)
        Dim Carpeta As String = "Programacion/Modelos/"
        Dim objFTP As New Tools.TransferenciaFTP
        Dim StreamFoto As System.IO.Stream
        Dim vArticulo As ArticuloCargaSuela

        vArticulo = vLstIdArticulo.FirstOrDefault()
        registros = vLstIdArticulo.Count

        llenarComboSuelaProgramacion()
        cmbSuela.SelectedValue = vArticulo.PIdSuelaProgramacion
        llenarComboColorSuela()
        cmbColorSuela.SelectedValue = vArticulo.PIdColorSuela
        llenarComboColorSuela2()
        cmbColorSuelaDos.SelectedValue = vArticulo.PIdColorSuela2
        llenarComboAcabadoSuela()
        cmbAcabado.SelectedValue = vArticulo.PIdAcabadoSuela
        llenarComboFamiliaSuela()
        cmbFamilia.SelectedValue = vArticulo.PIdFamiliaSuela

        StreamFoto = objFTP.StreamFile(Carpeta, vArticulo.PCadenaImagen)
        PicFoto.Image = Image.FromStream(StreamFoto)
        lblArticulo1.Text = vArticulo.PArticuloUno
        lblArticulo2.Text = vArticulo.PArticuloDos
        lblConsumoSuela.Text = vArticulo.PConsumoSuela


        If registros = 1 Then
            PicFoto.Visible = True
        ElseIf registros > 1 Then
            grdEditarArticulo.Visible = True
            gboxEditarArticulo.Visible = True
            lblArticulo1.Visible = False
            lblArticulo2.Visible = False
            lblConsumoSuela.Visible = False
            grdEditarArticulo.DataSource = vLstIdArticulo
            lblTextoArticulo.Visible = False
            lblTextoConsumo.Visible = False
            disenoGrid()
        End If


    End Sub

    Private Sub grdEditarArticulo_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEditarArticulo.InitializeLayout
        grid_diseño(grdEditarArticulo)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub disenoGrid()
        With grdEditarArticulo.DisplayLayout.Bands(0)
            .Columns("PIdArticulo").Hidden = True
            .Columns("PIdSuelaProgramacion").Hidden = True
            .Columns("PIdColorSuela").Hidden = True
            .Columns("PIdCorrida").Hidden = True
            .Columns("PCadenaImagen").Hidden = True
            .Columns("PArticuloUno").Hidden = True
            .Columns("PArticuloDos").Hidden = True
            .Columns("PIdAcabadoSuela").Hidden = True
            .Columns("PIdFamiliaSuela").Hidden = True
            .Columns("PIdColorSuela2").Hidden = True

            .Columns("PCadenaListaArticulo1").Header.Caption = "Artículos"
            .Columns("PCadenaListaArticulo1").CellActivation = Activation.NoEdit
            .Columns("PCadenaListaArticulo1").Header.VisiblePosition = 1

            .Columns("PCadenaListaArticulo2").Header.Caption = "Suela"
            .Columns("PCadenaListaArticulo2").CellActivation = Activation.NoEdit
            .Columns("PCadenaListaArticulo2").Header.VisiblePosition = 2

            .Columns("PCadenaListaArticulo5").Header.Caption = "Color"
            .Columns("PCadenaListaArticulo5").CellActivation = Activation.NoEdit
            .Columns("PCadenaListaArticulo5").Header.VisiblePosition = 3

            .Columns("PCadenaListaArticulo3").Header.Caption = "Familia"
            .Columns("PCadenaListaArticulo3").CellActivation = Activation.NoEdit
            .Columns("PCadenaListaArticulo3").Header.VisiblePosition = 4

            .Columns("PCadenaListaArticulo4").Header.Caption = "Acabado"
            .Columns("PCadenaListaArticulo4").CellActivation = Activation.NoEdit
            .Columns("PCadenaListaArticulo4").Header.VisiblePosition = 5

            .Columns("PConsumoSuela").Header.Caption = "Consumo"
            .Columns("PConsumoSuela").CellActivation = Activation.NoEdit
            .Columns("PConsumoSuela").Header.VisiblePosition = 6

        End With

        grdEditarArticulo.DisplayLayout.Bands(0).Columns("PCadenaListaArticulo1").Width = 200

    End Sub


    Public Sub llenarComboSuelaProgramacion()
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim dtSuelasProgramacion As DataTable
        dtSuelasProgramacion = objBU.verComboSuelaProgramacion()
        dtSuelasProgramacion.Rows.InsertAt(dtSuelasProgramacion.NewRow, 0)
        cmbSuela.DataSource = dtSuelasProgramacion
        cmbSuela.DisplayMember = "suel_descripcion"
        cmbSuela.ValueMember = "suel_suelaid"
    End Sub

    Public Sub llenarComboColorSuela()
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim dtColorSuela As DataTable
        dtColorSuela = objBU.verComboColorSuela()
        dtColorSuela.Rows.InsertAt(dtColorSuela.NewRow, 0)
        cmbColorSuela.DataSource = dtColorSuela
        cmbColorSuela.DisplayMember = "cosu_nombrecolor"
        cmbColorSuela.ValueMember = "cosu_colorsuelaid"
    End Sub

    Public Sub llenarComboColorSuela2()
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim dtColorSuela2 As DataTable
        dtColorSuela2 = objBU.verComboColorSuela()
        dtColorSuela2.Rows.InsertAt(dtColorSuela2.NewRow, 0)
        cmbColorSuelaDos.DataSource = dtColorSuela2
        cmbColorSuelaDos.DisplayMember = "cosu_nombrecolor"
        cmbColorSuelaDos.ValueMember = "cosu_colorsuelaid"
    End Sub

    Public Sub llenarComboAcabadoSuela()
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim dtAcabadoSuela As DataTable
        dtAcabadoSuela = objBU.verComboAcabadoSuela()
        dtAcabadoSuela.Rows.InsertAt(dtAcabadoSuela.NewRow, 0)
        cmbAcabado.DataSource = dtAcabadoSuela
        cmbAcabado.ValueMember = "tsa_suelaacabadoid"
        cmbAcabado.DisplayMember = "tsa_nombreacabado"
    End Sub

    Public Sub llenarComboFamiliaSuela()
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim dtFamiliaSuela As DataTable
        dtFamiliaSuela = objBU.verComboFamiliaSuela()
        dtFamiliaSuela.Rows.InsertAt(dtFamiliaSuela.NewRow, 0)
        cmbFamilia.DataSource = dtFamiliaSuela
        cmbFamilia.ValueMember = "tsf_suelafamiliaid"
        cmbFamilia.DisplayMember = "tsf_nombrefamilia"
    End Sub

    Public Function validarVacios() As Boolean
        If cmbSuela.SelectedValue = Nothing Or cmbColorSuela.SelectedValue = Nothing Then
            If cmbSuela.Text = Nothing Then
                lblSuela.ForeColor = Drawing.Color.Red
            Else
                lblSuela.ForeColor = Drawing.Color.Black
            End If
            If cmbColorSuela.Text = Nothing Then
                lblColorSuela.ForeColor = Drawing.Color.Red
            Else
                lblColorSuela.ForeColor = Drawing.Color.Black
            End If
            If cmbFamilia.Text = Nothing Then
                lblFamilia.ForeColor = Drawing.Color.Red
            Else
                lblFamilia.ForeColor = Drawing.Color.Black
            End If
            If cmbAcabado.Text = Nothing Then
                lblAcabado.ForeColor = Drawing.Color.Red
            Else
                lblAcabado.ForeColor = Drawing.Color.Black
            End If

            Return False
        Else
            lblSuela.ForeColor = Drawing.Color.Black
            lblColorSuela.ForeColor = Drawing.Color.Black
        End If
        Return True
    End Function

    Public Function ArmarXml() As String
        Dim vXmlArticulos As XElement = New XElement("ARTICULOS")

        If vLstIdArticulo.Count > 0 Then
            For Each item In vLstIdArticulo
                Dim vNodo As XElement = New XElement("ARTICULO")
                vNodo.Add(New XAttribute("pstilo", item.PIdArticulo))
                vNodo.Add(New XAttribute("idTalla", item.PIdCorrida))
                vNodo.Add(New XAttribute("SuelaProgramacionID", item.PIdSuelaProgramacion))
                vNodo.Add(New XAttribute("ColorSuelaID", item.PIdColorSuela))
                vNodo.Add(New XAttribute("ColorSuelaID2", item.PIdColorSuela2))
                vNodo.Add(New XAttribute("Acabado", item.PIdAcabadoSuela))
                vNodo.Add(New XAttribute("Familia", item.PIdFamiliaSuela))
                vXmlArticulos.Add(vNodo)
            Next
        End If
        Return IIf(vLstIdArticulo.Count > 0, vXmlArticulos.ToString(), Nothing)

    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim objmensaje As New Tools.ConfirmarForm


        If validarVacios() = True Then
            objmensaje.mensaje = "¿Está seguro de guardar cambios?"
            If objmensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim v As String = ArmarXml()
                objBU.ObtieneArticulo(ArmarXml())
                Me.Close()
            End If
            cerrarGuardar = True
            exitoMensaje.mensaje = "El registro se realizó con éxito."
            exitoMensaje.ShowDialog()
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Faltan de capturar campos obligatorios."
            adv.ShowDialog()
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Dim advertencia As New AdvertenciaForm
        advertencia.mensaje = "Los cambios no guardados se perderán."
        advertencia.ShowDialog()
        Me.Dispose()
    End Sub


    Private Sub EditarArticulo_SuelaForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If listaArticulo IsNot Nothing And cerrarGuardar = True Then
            listaArticulo.btnMostrar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmbSuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSuela.SelectedIndexChanged

        Try
            If cmbSuela.SelectedValue.ToString <> "" And cmbSuela.Text.ToString <> "" Then

                If cmbSuela.SelectedIndex > 0 Then
                    If vLstIdArticulo.Count() > 0 Then
                        For Each item As ArticuloCargaSuela In vLstIdArticulo
                            item.PIdSuelaProgramacion = cmbSuela.SelectedValue
                        Next
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbColorSuela_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColorSuela.SelectedIndexChanged

        Try
            If cmbColorSuela.SelectedValue.ToString <> "" And cmbColorSuela.Text.ToString <> "" Then

                If vLstIdArticulo.Count > 0 Then
                    If cmbColorSuela.SelectedIndex > 0 Then
                        For Each item As ArticuloCargaSuela In vLstIdArticulo
                            item.PIdColorSuela = cmbColorSuela.SelectedValue
                        Next
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbColorSuelaDos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColorSuelaDos.SelectedIndexChanged
        Try
            If cmbColorSuelaDos.SelectedValue.ToString <> "" And cmbColorSuelaDos.Text.ToString <> "" Then

                If cmbColorSuelaDos.SelectedIndex > 0 Then
                    If vLstIdArticulo.Count() > 0 Then
                        For Each item As ArticuloCargaSuela In vLstIdArticulo
                            item.PIdColorSuela2 = cmbColorSuelaDos.SelectedValue
                        Next
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbFamilia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFamilia.SelectedIndexChanged
        Try
            If cmbFamilia.SelectedValue.ToString <> "" And cmbFamilia.Text.ToString <> "" Then
                If cmbFamilia.SelectedIndex > 0 Then
                    If vLstIdArticulo.Count() > 0 Then
                        For Each item As ArticuloCargaSuela In vLstIdArticulo
                            item.PIdFamiliaSuela = cmbFamilia.SelectedValue
                        Next
                    End If
                End If
                End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAcabado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAcabado.SelectedIndexChanged
        Try
            If cmbAcabado.SelectedValue.ToString <> "" And cmbAcabado.Text.ToString <> "" Then
                If cmbFamilia.SelectedIndex > 0 Then
                    If vLstIdArticulo.Count() > 0 Then
                        For Each item As ArticuloCargaSuela In vLstIdArticulo
                            item.PIdAcabadoSuela = cmbAcabado.SelectedValue
                        Next
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class