Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports System.Drawing
Imports Tools

Public Class ConsultaDeLotesDeProgramasDeProduccionForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public tablaOrdenesdeProduccion As New DataTable
    Public idPrograma As Integer

    Private Sub ConsultaDeLotesDeProgramasDeProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCampoNaves()
        lblFechadel.Text = dtpProgramadel.Value.Date
        lblFechaal.Text = dtpProgramaal.Value.Date
        permisos()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Sub permisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ConsultaDeLotesDeProgramasDeProduccion", "IMPRIMIRORDENDEPRODUCCION") Then
            btnAlta.Visible = True
            lblOrdenProduccion.Visible = True
        Else
            btnAlta.Visible = False
            lblOrdenProduccion.Visible = False

        End If
    End Sub

    Public Sub llenarCampoNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    'Public Sub llenarComboNavesSicy()
    '    Dim obj As New catalagosBU
    '    Dim lsta As DataTable
    '    lsta = obj.listaNavesSicy()
    '    If Not lsta.Rows.Count = 0 Then
    '        lsta.Rows.InsertAt(lsta.NewRow, 0)
    '        cmbNave.DataSource = lsta
    '        cmbNave.DisplayMember = "Nave"
    '        cmbNave.ValueMember = "IdNave"
    '    End If
    'End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New catalagosBU
        Dim tabla As New DataTable
        Dim lista As New DataTable
        Dim listaIdLotes As New List(Of Integer)
        Dim lotes As Integer = 0
        Dim pares As Integer = 0

        If cmbNave.Text = "" Then
            objMensaje.mensaje = "Seleccione una nave."
            objMensaje.ShowDialog()
            lblNave.ForeColor = Drawing.Color.Red
        Else
            Me.Cursor = Cursors.WaitCursor
            lblNave.ForeColor = Drawing.Color.Black
            tabla = obj.idLoteProduccion(lblFechadel.Text, lblFechaal.Text, cmbNave.SelectedValue)
            Try
                If tabla.Rows.Count > 0 Then
                    For value = 0 To tabla.Rows.Count - 1
                        listaIdLotes.Add(tabla.Rows(value).Item("idprograma"))
                    Next

                    idPrograma = tabla.Rows(0).Item(0)
                    lista = obj.consultaLoteProduccion(listaIdLotes, cmbNave.SelectedValue)
                    'lista = obj.consultaLoteProduccion(listaIdLotes, cmbNave.SelectedValue)
                    grdLotesProduccion.DataSource = lista
                    tablaOrdenesdeProduccion = obj.consultaLoteProduccionReporte(listaIdLotes, cmbNave.SelectedValue)
                    'tablaOrdenesdeProduccion = lista
                    disenioGrdLotesProduccion()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    objMensaje.mensaje = "No hay lotes para la nave " + cmbNave.Text + " en el rango de fechas seleccionado."
                    objMensaje.ShowDialog()
                End If

                If grdLotesProduccion.Rows.Count > 0 Then
                    For value = 0 To grdLotesProduccion.Rows.Count - 1
                        pares = pares + grdLotesProduccion.Rows(value).Cells("pares").Value
                    Next
                    lotes = grdLotesProduccion.Rows.Count
                End If
                lblLotesText.Text = Format(lotes, "##,##0")
                lblParesText.Text = Format(pares, "##,##0")
            Catch ex As Exception
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub disenioGrdLotesProduccion()
        Dim band As UltraGridBand = Me.grdLotesProduccion.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdLotesProduccion.DisplayLayout.Bands(0)
            '.Columns("prod_productoid").Hidden = True
            '.Columns("prod_modelo").Header.Caption = "Modelo"

            .Columns("lote").CellActivation = Activation.NoEdit
            .Columns("idModelo").CellActivation = Activation.NoEdit
            .Columns("idCodigo").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("talla").CellActivation = Activation.NoEdit
            .Columns("color").CellActivation = Activation.NoEdit
            .Columns("pares").CellActivation = Activation.NoEdit
            .Columns("cortador").CellActivation = Activation.NoEdit
            .Columns("cortador_Forro").CellActivation = Activation.NoEdit
            .Columns("cortadorSint").CellActivation = Activation.NoEdit
            .Columns("cortador_ForroSint").CellActivation = Activation.NoEdit
            .Columns("Cliente_texto").CellActivation = Activation.NoEdit

            .Columns("año").Hidden = True
            .Columns("nave").Hidden = True
            .Columns("cliente_Nombre").Hidden = True
            .Columns("TotalPares").Hidden = True
            .Columns("TotalLotes").Hidden = True
            .Columns("primer_lote").Hidden = True
            .Columns("ultimo_lote").Hidden = True

            .Columns("lote").CellAppearance.TextHAlign = HAlign.Right
            .Columns("idModelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("pares").CellAppearance.TextHAlign = HAlign.Right
            .Columns("talla").CellAppearance.TextHAlign = HAlign.Right

            '.Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '.Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            '.Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("lote").Width = 20
            .Columns("idModelo").Width = 25
            .Columns("idCodigo").Width = 50
            .Columns("Coleccion").Width = 80
            .Columns("talla").Width = 30
            .Columns("color").Width = 90
            .Columns("pares").Width = 25
            .Columns("cortador").Width = 50
            .Columns("cortador_Forro").Width = 50
            .Columns("cortadorSint").Width = 50
            .Columns("cortador_ForroSint").Width = 50
            .Columns("Cliente_texto").Width = 150

            .Columns("lote").Header.Caption = "Lote"
            .Columns("idModelo").Header.Caption = "Modelo"
            .Columns("idCodigo").Header.Caption = "Código"
            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("talla").Header.Caption = "Corrida"
            .Columns("color").Header.Caption = "Color"
            .Columns("pares").Header.Caption = "Pares"
            .Columns("cortador").Header.Caption = "Cortador" & vbCrLf & "Piel"
            .Columns("cortadorSint").Header.Caption = "Cortador" & vbCrLf & "Piel Sint"
            .Columns("cortador_Forro").Header.Caption = "Cortador" & vbCrLf & "Forro"
            .Columns("cortador_ForroSint").Header.Caption = "Cortador" & vbCrLf & "Forro Sint"
            .Columns("Cliente_texto").Header.Caption = "Cliente"
            '.Columns("Total Materiales").Format = "##,##0.00"
            '.Columns("Total Fracciones").Format = "##,##0.00"
        End With
        grdLotesProduccion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub dtpPrograma_ValueChanged(sender As Object, e As EventArgs) Handles dtpProgramadel.ValueChanged
        lblFechadel.Text = dtpProgramadel.Value.Date
    End Sub

    Private Sub dtpProgramaal_ValueChanged(sender As Object, e As EventArgs) Handles dtpProgramaal.ValueChanged
        lblFechaal.Text = dtpProgramaal.Value.Date
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        If grdLotesProduccion.Rows.Count = 0 Then
            objMensaje.mensaje = "No hay información para mostrar"
            objMensaje.ShowDialog()
        Else
            crearReporteProduccion()
        End If
    End Sub

    Public Sub crearReporteProduccion()
        Dim Pares As Integer = 0
        Try
            For value = 0 To tablaOrdenesdeProduccion.Rows.Count - 1
                Pares = Pares + CInt(grdLotesProduccion.Rows(value).Cells("Pares").Value)
            Next

            If grdLotesProduccion.Rows.Count > 0 Then

                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PRODUCCION")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                ' Dim x = encabezado.Rows(0).Item("Folio").ToString
                ruta = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                Dim fecha As String = DateTime.Now.ToString("dd/MM/yyyy")
                Dim hora = Now.ToString("HH:mm:ss")

                reporte("log") = ruta.ToUpper.Trim.Replace(" ", "")
                reporte("crearReporteProduccion") = ""
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("fecha") = fecha.ToString
                reporte("fechaHora") = fecha.ToString + " " + hora.ToString
                reporte("TotalPares") = Pares.ToString
                reporte.RegData(tablaOrdenesdeProduccion)

                reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If grdLotesProduccion.Rows.Count > 0 Then
            exportarExcel()
        End If
    End Sub

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grdLotesProduccion, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
                'grdLotesProduccion.DataSource = Nothing
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            grdLotesProduccion.DataSource = Nothing
            cmbNave.SelectedIndex = 0
            lblLotesText.Text = 0
            lblParesText.Text = 0
            dtpProgramadel.Value = Date.Now
            dtpProgramaal.Value = Date.Now
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdLotesProduccion.DataSource = Nothing
    End Sub
End Class