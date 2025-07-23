Imports System.Globalization
Imports System.IO
Imports System.Net
Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class Programacion_MovimientosPPCP_Articulos
    Public IdNaveSay As Integer = 0
    Public IdNaveSayOrigen As Integer = 0
    Public NombreNave As String
    Public marcadosActualmente As New List(Of Integer)
    Public marca As String = String.Empty
    Public accionForm As String
    Public fechaMenor As Date
    Public fechaMayor As Date
    Public fechaDesde As Date
    Public fechaHasta As Date
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim exportar As Integer = 0
    Public tabla As New DataTable
    Public ProductoEstiloSeleccionados As String = String.Empty
    Dim UsuarioId As Integer
    Dim Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL"
    Dim Existe As String = String.Empty
    Dim FColeccion As String = String.Empty
    Dim FCorrida As String = String.Empty
    Dim listaInicial As New List(Of String)
    Dim prioridad As Integer = 0

    Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
    Dim ContadorArticulos As Integer = 0
    Dim NumeroFilas As Integer = 0
    Public inicio As Boolean = True
    Dim BanderaDescontinuar As Boolean = False
    Dim FechaMaxUltimoPrograma As String = String.Empty

    Dim FechaGeneracionExcel As String = String.Empty
    Private Sub Programacion_MovimientosPPCP_Articulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaProgramarDesde.Value = Date.Now
        If accionForm = "Asignar Articulos" Then
            Me.Text = "Asignar Artículos"
            lblTituloPantalla.Text = "Asignar Artículos"
            lblMovimiento.Text = "Asignar"
            chFormatoNombre.Text = "Formato de Asignación"
            LlenarNave(1)
            LlenarNave(2)
            'cmbNaveDestino.Text = NombreNave
            chFiltarCorrida.Enabled = True
            chFiltarCorrida.Checked = False
        ElseIf accionForm = "Transferir Articulos" Then

            chkFechaProgramar.Visible = False
            chkFechaAsignar.Visible = False
            Me.Text = "Traspaso Artículos"
            lblTituloPantalla.Text = "Traspaso Artículos"
            lblMovimiento.Text = "Transferir"
            chFormatoNombre.Text = "Formato de Traspaso"
            LlenarNave(1) 'Origen
            'cmbNaveOrigen.Text = NombreNave
            'cmbNaveOrigen.Enabled = False
            LlenarNave(2) 'Destino
            btnMostrar.PerformClick()
            pnlTransferir.Visible = True
            'btnMostrar.Visible = False
            'lblMostrar.Visible = False
            chFiltarCorrida.Enabled = True
            chFiltarCorrida.Checked = False
        ElseIf accionForm = "Desasignar Articulos" Then

            chResumenCostos.Visible = False
            pnlTransferir.Visible = True
            lblProgramarDesde.Visible = False
            dtpProgramarDesdeTras.Visible = False
            Me.Text = "Desasignar Artículos"
            lblTituloPantalla.Text = "Desasignar Artículos"
            lblMovimiento.Text = "Desasignar"
            chFormatoNombre.Text = "Formato de Fin de Producción"
            lblNaveDestino.Text = "Nave" + vbCrLf + "Desarrollo :"
            LlenarNave(1)
            ' cmbNaveOrigen.Text = NombreNave
            'cmbNaveOrigen.Enabled = False
            grbDevolucion.Visible = True
            btnMostrar.PerformClick()
            LlenarNave(2)
            lblObservaciones.Visible = False
            'btnMostrar.Visible = False
            'lblMostrar.Visible = False
            chFiltarCorrida.Enabled = True
            chFiltarCorrida.Checked = False
        End If

        If Not System.IO.Directory.Exists(Ruta) Then
            Directory.CreateDirectory(Ruta)
        End If
    End Sub

    Private Sub LlenarNave(ByVal Accion As Integer)
        Dim DTNAves As DataTable
        Dim objBU As New MovimientosPPCPBU
        DTNAves = objBU.ConsultarNavesAux()
        'For Each x As DataRow In DTNAves.Rows
        '    If x.ItemArray(0) = IdNaveSay Then
        '        DTNAves.Rows.Remove(x)
        '        Exit For
        '    End If
        'Next
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)

        If Accion = 1 Then
            cmbNaveOrigen.DataSource = DTNAves
            cmbNaveOrigen.DisplayMember = "Nave"
            cmbNaveOrigen.ValueMember = "NaveSAYId"
        Else
            cmbNaveDestino.DataSource = DTNAves
            cmbNaveDestino.DisplayMember = "Nave"
            cmbNaveDestino.ValueMember = "NaveSAYId"
        End If


    End Sub

    Public Sub llenarMarcas()
        Dim obj As New MovimientosPPCPBU
        Dim DTMarca As New DataTable
        Dim tipo As Integer
        If accionForm = "Asignar Articulos" Then
            tipo = 1
        Else
            tipo = 2
        End If
        '   If cmbComercializadora.SelectedValue > 0 Then
        If cmbNaveOrigen.SelectedValue.ToString <> "" And cmbNaveOrigen.Text.ToString <> "" Then
            DTMarca = obj.ConsultarNavesMarca(tipo, cmbNaveOrigen.SelectedValue)
            If Not DTMarca.Rows.Count = 0 Then
                DTMarca.Rows.InsertAt(DTMarca.NewRow, 0)
                cmbMarca.DataSource = DTMarca
                cmbMarca.DisplayMember = "Marca"
                ' cmbMarca.ValueMember = "IdMarca"

            End If

        End If
    End Sub



    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New MovimientosPPCPBU
        Dim dtObtieneArticulosParaTraspaso As New DataTable
        Dim dtConsultaArticulosNoAsignados As New DataTable

        marca = cmbMarca.Text
        FColeccion = ObtenerFiltrosGrid(grdColeccion)
        FCorrida = ObtenerFiltrosGrid(grdCorrida)


        Try
            Select Case accionForm
                Case = "Asignar Articulos"
                    grdMovimientosPPCP.DataSource = Nothing
                    'Dim dtConsultaArticulosNoAsignados As New DataTable


                    If cmbNaveDestino.SelectedIndex > 0 Then
                        IdNaveSay = cmbNaveOrigen.SelectedValue

                        If FColeccion <> "" Then
                            LlenarTablaArticulos()

                            If FColeccion <> "" And FCorrida <> "" Then
                                LlenarTablaArticulosTallas()

                            End If

                        ElseIf accionForm = "Asignar Articulos" And cmbNaveOrigen.SelectedIndex <> 0 And marca <> "" And FColeccion = "" Then
                            objAdvertencia.mensaje = "Seleccione al menos una Colección"
                            objAdvertencia.ShowDialog()


                        End If

                    Else
                        objAdvertencia.mensaje = "Seleccione la Nave"
                        objAdvertencia.ShowDialog()

                        Exit Sub
                        Cursor = Cursors.Default
                    End If


                    inicio = False

                    'If dtConsultaArticulosNoAsignados.Rows.Count <> 0 Then
                    '    grdMovimientosPPCP.DataSource = dtConsultaArticulosNoAsignados
                    '    DisenioGrid()
                    '    lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")

                    'ElseIf dtConsultaArticulosNoAsignados.Rows.Count = 0 And cmbNaveDestino.SelectedIndex <> 0 And FColeccion <> "" Then
                    '    objAdvertencia.mensaje = "No existen artículos para asignar a esta nave."
                    '    objAdvertencia.ShowDialog()

                    'End If


                Case "Transferir Articulos"
                    grdMovimientosPPCP.DataSource = Nothing



                    If cmbNaveOrigen.SelectedIndex <> 0 Then
                        IdNaveSay = cmbNaveOrigen.SelectedValue

                        If FColeccion <> "" Then
                            LlenarTablaArticulosTransferir()

                            If FColeccion <> "" And FCorrida <> "" Then
                                LlenarTablaArticulosTallasTransferir()

                            End If

                        ElseIf accionForm = "Transferir Articulos" And cmbNaveOrigen.SelectedIndex <> 0 And FColeccion = "" Then
                            objAdvertencia.mensaje = "Seleccione al menos una Colección"
                            objAdvertencia.ShowDialog()
                        Else
                            objAdvertencia.mensaje = "Seleccione la Nave"
                            objAdvertencia.ShowDialog()

                        End If



                        Exit Sub
                        Cursor = Cursors.Default
                    End If

                    '    dtObtieneArticulosParaTraspaso = objBU.ObtieneArticulosParaTraspaso(ProductoEstiloSeleccionados, accionForm, IdNaveSay)

                    For Each row As DataRow In dtObtieneArticulosParaTraspaso.Rows

                        If FechaMaxUltimoPrograma = "" Then
                            FechaMaxUltimoPrograma = row.Item("Último Programa").ToString
                        Else
                            If FechaMaxUltimoPrograma < row.Item("Último Programa").ToString Then
                                FechaMaxUltimoPrograma = row.Item("Último Programa").ToString
                            End If
                        End If

                    Next

                    If FechaMaxUltimoPrograma <> "" Then
                        dtpProgramarHastaTras.MinDate = CDate(FechaMaxUltimoPrograma).ToShortDateString
                        dtpProgramarHastaTras.Value = CDate(FechaMaxUltimoPrograma).ToShortDateString
                    End If


                    If dtObtieneArticulosParaTraspaso.Rows.Count <> 0 Then
                        grdMovimientosPPCP.DataSource = dtObtieneArticulosParaTraspaso
                        DisenioGrid()
                        lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")

                    ElseIf dtObtieneArticulosParaTraspaso.Rows.Count = 0 And cmbNaveDestino.SelectedIndex <> 0 And FColeccion <> "" Then
                        objAdvertencia.mensaje = "Seleccione un artículo para el movimiento."
                        objAdvertencia.ShowDialog()

                    End If

                Case "Desasignar Articulos"



                    BanderaDescontinuar = True


                    If cmbNaveOrigen.SelectedIndex > 0 Then
                        IdNaveSay = cmbNaveOrigen.SelectedValue

                        If FColeccion <> "" Then
                            LlenarTablaArticulosTransferir()

                            If FColeccion <> "" And FCorrida <> "" Then
                                LlenarTablaArticulosTallasTransferir()


                            End If

                        ElseIf accionForm = "Desasignar Articulos" And cmbNaveOrigen.SelectedIndex <> 0 And FColeccion = "" Then
                            objAdvertencia.mensaje = "Seleccione al menos una Colección"
                            objAdvertencia.ShowDialog()
                        Else
                            objAdvertencia.mensaje = "Seleccione la Nave"
                            objAdvertencia.ShowDialog()

                        End If



                        Exit Sub
                        Cursor = Cursors.Default

                    End If

                    If dtObtieneArticulosParaTraspaso.Rows.Count > 0 Then
                        grdMovimientosPPCP.DataSource = dtObtieneArticulosParaTraspaso
                        DisenioGrid()
                        lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")

                    ElseIf dtObtieneArticulosParaTraspaso.Rows.Count = 0 And cmbNaveDestino.SelectedIndex <> 0 And FColeccion <> "" Then
                        objAdvertencia.mensaje = "Seleccione un artículo para el movimiento."
                        objAdvertencia.ShowDialog()

                    End If

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwMovimientosPPCP.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> "Seleccionar" And col.FieldName <> "Prioridad" Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        If BanderaDescontinuar = True Then

            vwMovimientosPPCP.Columns.ColumnByFieldName("Último Movimiento").Width = 100
            vwMovimientosPPCP.Columns.ColumnByFieldName("Colección").Width = 200
            vwMovimientosPPCP.Columns.ColumnByFieldName("Talla").Width = 60
        Else
            vwMovimientosPPCP.Columns.ColumnByFieldName("Prioridad").Visible = True
            vwMovimientosPPCP.Columns.ColumnByFieldName("Prioridad").Width = 120
            vwMovimientosPPCP.Columns.ColumnByFieldName("Colección").Width = 230
            vwMovimientosPPCP.Columns.ColumnByFieldName("Talla").Width = 85
        End If

        vwMovimientosPPCP.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False
        vwMovimientosPPCP.Columns.ColumnByFieldName("Seleccionar").Width = 45
        vwMovimientosPPCP.Columns.ColumnByFieldName("Marca").Width = 100

        vwMovimientosPPCP.Columns.ColumnByFieldName("Modelo SAY").Width = 60
        vwMovimientosPPCP.Columns.ColumnByFieldName("Modelo SICY").Width = 60
        vwMovimientosPPCP.Columns.ColumnByFieldName("Piel Color").Width = 200
        vwMovimientosPPCP.Columns.ColumnByFieldName("Seleccionar").Caption = " "

        DiseñoGrid.AlternarColorEnFilas(vwMovimientosPPCP)
        'vwMovimientosPPCP.BestFitColumns()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = vwMovimientosPPCP.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                vwMovimientosPPCP.SetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Seleccionar", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlMovimientosPPCP.Visible = False
        pnlBotonesExpander.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlMovimientosPPCP.Visible = True
        pnlBotonesExpander.AutoSize = True
    End Sub

    Private Sub chkFechaAsignar_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaAsignar.CheckedChanged
        If chkFechaAsignar.Checked Then
            dtpSiguienteFecha.Enabled = True
        Else
            dtpSiguienteFecha.Enabled = False
        End If
    End Sub

    Private Function ObtenerProductoEstilosSeleccionados() As String
        Dim productoEstiloSeleccionados As String = String.Empty


        NumeroFilas = vwMovimientosPPCP.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                ContadorArticulos = ContadorArticulos + 1

                If productoEstiloSeleccionados <> "" Then
                    productoEstiloSeleccionados += ","
                End If

                productoEstiloSeleccionados += vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "ProductoEstiloId").ToString

            End If
        Next

        Return productoEstiloSeleccionados
    End Function

    Private Function ObtenerOpcionesEnvio() As Integer
        Dim ExportadoEnviado As Integer = 0

        If chEnviar.Checked And chExportar.Checked Then
            ExportadoEnviado = 2 'Ambas opciones seleccionadas
        ElseIf chEnviar.Checked = False And chExportar.Checked = True Then
            ExportadoEnviado = 1 'Únicamente exportar
        ElseIf chEnviar.Checked = True And chExportar.Checked = False Then
            ExportadoEnviado = 3 'Únicamente enviar 
        End If

        Return ExportadoEnviado
    End Function

    Private Function ObtenerDevolucionHormaSuaje() As Integer
        Dim DevolverSuelaSuaje As Integer = 0

        If chboxHorma.Checked = True And chboxSuaje.Checked = False Then
            DevolverSuelaSuaje = 1 'Devuelve Horma
        ElseIf chboxSuaje.Checked = True And chboxHorma.Checked = False Then
            DevolverSuelaSuaje = 2 ' Devuelve Suaje
        ElseIf chboxHorma.Checked And chboxSuaje.Checked Then
            DevolverSuelaSuaje = 3 'Horma y Suaje
        Else
            DevolverSuelaSuaje = 0
        End If

        Return DevolverSuelaSuaje

    End Function

    Private Sub btnMovimiento_Click(sender As Object, e As EventArgs) Handles btnMovimiento.Click
        Try
            If vwMovimientosPPCP.DataRowCount > 0 Then

                Dim respuestaCorreo As String = String.Empty
                ContadorArticulos = 0
                Existe = False
                Dim RutaMovimiento As String = String.Empty
                Dim objBU As New MovimientosPPCPBU
                Dim dtResultado As New DataTable
                Dim naveDestino As Integer = 0

                ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
                naveDestino = cmbNaveDestino.SelectedValue

                If ProductoEstiloSeleccionados <> "" Then
                    Select Case accionForm
                        Case "Asignar Articulos"

                            objConfirmar.mensaje = "Se asignarán " & ContadorArticulos.ToString & " articulos a la nave " & cmbNaveDestino.Text & ". Este cambio no podrá revertirse ¿Desea continuar?"
                            If objConfirmar.ShowDialog = DialogResult.OK Then
                                Cursor = Cursors.WaitCursor
                                'Dim vXmlMovimientos As XElement = New XElement("Movimientos")

                                ExisteEnOtraNave()

                                If ValidaImagenArticulos(ProductoEstiloSeleccionados) = False Then
                                    objAdvertencia.mensaje = "Faltan imágenes por cargar, se detendrá el proceso."
                                    objAdvertencia.ShowDialog()
                                    Exit Sub
                                    Cursor = Cursors.Default
                                End If

                                If ValidarAsignacionFamiliaNave(ProductoEstiloSeleccionados, cmbNaveDestino.SelectedValue()) = False Then
                                    objAdvertencia.mensaje = "La Familia no se encuentra asignada en la nave destino."
                                    objAdvertencia.ShowDialog()
                                    Exit Sub
                                    Cursor = Cursors.Default
                                End If

                                If Existe = True Then
                                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\DUPLICIDAD"
                                Else
                                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\ASIGNACIÓN"
                                End If


                                If Not System.IO.Directory.Exists(RutaMovimiento) Then
                                    Directory.CreateDirectory(RutaMovimiento)
                                End If

                                For index As Integer = 0 To NumeroFilas Step 1
                                    If CBool(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Seleccionar")) = True Then

                                        If IsDBNull(vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")) = True Then
                                            Dim vXmlMovimientos As XElement = New XElement("Movimientos")
                                            Dim vNodo As XElement = New XElement("Movimiento")
                                            vNodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                                            vNodo.Add(New XAttribute("NaveIdSAY", naveDestino))
                                            vNodo.Add(New XAttribute("ArticulosIdSAY", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                                            vNodo.Add(New XAttribute("FechaProgramarDesde", dtpFechaProgramarDesde.Value.ToShortDateString()))
                                            vNodo.Add(New XAttribute("SiguienteFechaAsignar", dtpSiguienteFecha.Value.ToShortDateString()))
                                            vNodo.Add(New XAttribute("GuardarFechaAsignar", chkFechaAsignar.Checked))
                                            If (cmbNaveOrigen.SelectedValue >= 0 And cmbNaveOrigen.Text <> "") Then
                                                vNodo.Add(New XAttribute("NaveOrigen", cmbNaveOrigen.SelectedValue))
                                            Else
                                                objAdvertencia.mensaje = "Seleccione la nave Origen."
                                                objAdvertencia.ShowDialog()
                                                Cursor = Cursors.Default

                                            End If
                                            vNodo.Add(New XAttribute("Prioridad", vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")))
                                            vNodo.Add(New XAttribute("Existe", Existe))

                                            vXmlMovimientos.Add(vNodo)
                                            dtResultado = objBU.InsertarArticulosNave(vXmlMovimientos.ToString())
                                        Else
                                            If IsDBNull(vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")) = False Then
                                                Dim vXmlMovimientos As XElement = New XElement("Movimientos")
                                                Dim vNodo As XElement = New XElement("Movimiento")
                                                vNodo.Add(New XAttribute("UsuarioID", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                                                vNodo.Add(New XAttribute("NaveIdSAY", naveDestino))
                                                vNodo.Add(New XAttribute("ArticulosIdSAY", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                                                vNodo.Add(New XAttribute("FechaProgramarDesde", dtpFechaProgramarDesde.Value.ToShortDateString()))
                                                vNodo.Add(New XAttribute("SiguienteFechaAsignar", dtpSiguienteFecha.Value.ToShortDateString()))
                                                vNodo.Add(New XAttribute("GuardarFechaAsignar", chkFechaAsignar.Checked))
                                                If (cmbNaveOrigen.SelectedValue >= 0 And cmbNaveOrigen.Text <> "") Then
                                                    vNodo.Add(New XAttribute("NaveOrigen", cmbNaveOrigen.SelectedValue))
                                                Else
                                                    objAdvertencia.mensaje = "Seleccione la nave Origen."
                                                    objAdvertencia.ShowDialog()
                                                    Cursor = Cursors.Default

                                                End If
                                                vNodo.Add(New XAttribute("Prioridad", vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")))
                                                vNodo.Add(New XAttribute("Existe", Existe))

                                                vXmlMovimientos.Add(vNodo)
                                                dtResultado = objBU.InsertarArticulosNaveprioridad(vXmlMovimientos.ToString())
                                            End If
                                        End If
                                    End If
                                Next

                                ' dtResultado = objBU.InsertarArticulosNave(vXmlMovimientos.ToString())

                                If dtResultado.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                                    If ObtenerOpcionesEnvio() = 2 Then
                                        GenerarFormato(accionForm, 0)
                                        'If EnviarCorreo(accionForm) = True Then
                                        '    respuestaCorreo = "Envío de correo exitoso"
                                        'End If
                                    ElseIf ObtenerOpcionesEnvio() = 1 Then
                                        GenerarFormato(accionForm, 0)
                                    ElseIf ObtenerOpcionesEnvio() = 3 Then
                                        'If EnviarCorreo(accionForm) = True Then
                                        '    respuestaCorreo = "Envío de correo exitoso"
                                        'End If
                                    End If
                                    Cursor = Cursors.Default
                                    objExito.mensaje = "Datos guardados correctamente. " + respuestaCorreo
                                    objExito.ShowDialog()
                                    Me.DialogResult = DialogResult.OK
                                    Me.Dispose()
                                Else
                                    objAdvertencia.mensaje = "Ocurrió un error, intente nuevamente."
                                    objAdvertencia.ShowDialog()
                                    Cursor = Cursors.Default
                                End If
                            Else
                                Me.DialogResult = DialogResult.None
                                Cursor = Cursors.Default
                            End If
                        Case "Transferir Articulos"
                            If cmbNaveDestino.Text <> "" Then
                                objConfirmar.mensaje = "Se transferiran " & ContadorArticulos.ToString & " articulos a nave " & cmbNaveDestino.Text & " de la nave " & cmbNaveOrigen.Text & ". Este cambio no podrá revertirse ¿Desea continuar?"
                                If objConfirmar.ShowDialog = DialogResult.OK Then
                                    Cursor = Cursors.WaitCursor
                                    Dim FechaHasta As Date = dtpProgramarHastaTras.Value.ToShortDateString()
                                    Dim FechaDesde As Date = dtpProgramarDesdeTras.Value.ToShortDateString()
                                    Dim vXmlCeldasModificadas As XElement = generarXMLtranferir(IdNaveSay)

                                    Try

                                        RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\TRASPASO"

                                        'Dani solicita quitar la reestricción de las fechas para el movimiento de traspaso.
                                        'If FechaDesde > FechaHasta Then 'La fecha desde tiene que ser mayor a la fecha hasta
                                        '    objAdvertencia.mensaje = "La fecha desde no puede ser mayor a la fecha hasta."
                                        '    objAdvertencia.ShowDialog()
                                        '    Cursor = Cursors.Default
                                        '    Exit Sub

                                        'End If


                                        If ValidarAsignacionFamiliaNave(ProductoEstiloSeleccionados, cmbNaveDestino.SelectedValue()) = False Then
                                            objAdvertencia.mensaje = "La Familia no se encuentra asignada en la nave destino."
                                            objAdvertencia.ShowDialog()
                                            Exit Sub
                                            Cursor = Cursors.Default
                                        End If

                                        If Not System.IO.Directory.Exists(RutaMovimiento) Then

                                            Directory.CreateDirectory(RutaMovimiento)
                                        End If
                                        If vXmlCeldasModificadas Is Nothing Then
                                            Cursor = Cursors.Default
                                            Exit Sub
                                        Else
                                            If prioridad = 0 Then
                                                dtResultado = objBU.TransferirArticulosNave(cmbNaveDestino.SelectedValue, vXmlCeldasModificadas.ToString, FechaHasta, FechaDesde)
                                                ObtenerOpcionesEnvio()
                                            Else
                                                dtResultado = objBU.TransferirArticulosNavePrioridad(cmbNaveDestino.SelectedValue, vXmlCeldasModificadas.ToString, FechaHasta, FechaDesde)
                                                ObtenerOpcionesEnvio()
                                            End If

                                        End If

                                        If dtResultado.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                                            If ObtenerOpcionesEnvio() = 2 Then
                                                GenerarFormato(accionForm, 0)
                                                'If EnviarCorreo(accionForm) = True Then
                                                '    respuestaCorreo = "Envío de correo exitoso"
                                                'End If
                                            ElseIf ObtenerOpcionesEnvio() = 1 Then
                                                GenerarFormato(accionForm, 0) '
                                            ElseIf ObtenerOpcionesEnvio() = 3 Then
                                                'If EnviarCorreo(accionForm) = True Then
                                                '    respuestaCorreo = "Envío de correo exitoso"
                                                'End If
                                            End If
                                            Cursor = Cursors.Default
                                            objExito.mensaje = "Datos guardados correctamente. " + respuestaCorreo
                                            objExito.ShowDialog()
                                            Me.DialogResult = DialogResult.OK
                                            Me.Dispose()
                                        Else
                                            objAdvertencia.mensaje = "Ocurrió un error, intente nuevamente."
                                            objAdvertencia.ShowDialog()
                                            Cursor = Cursors.Default
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message)
                                        Cursor = Cursors.Default
                                    End Try
                                Else
                                    Me.DialogResult = DialogResult.None
                                End If
                            Else
                                'objAdvertencia.mensaje = "Debe seleccionar una nave."
                                'objAdvertencia.ShowDialog()
                            End If

                        Case "Desasignar Articulos"
                            objConfirmar.mensaje = "Se desasignaran " & ContadorArticulos.ToString & " articulos a la nave " & cmbNaveDestino.Text & ". Este cambio no podrá revertirse ¿Desea continuar?"
                            If objConfirmar.ShowDialog = DialogResult.OK Then
                                Cursor = Cursors.WaitCursor
                                Dim Fecha As Date = dtpProgramarHastaTras.Value.ToShortDateString()
                                Dim vXmlCeldasModificadas As XElement = generarXML(IdNaveSay)
                                Dim iDNaveDesarrolla As Integer = 0
                                RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\DESCONTINUAR"

                                If Not System.IO.Directory.Exists(RutaMovimiento) Then
                                    Directory.CreateDirectory(RutaMovimiento)
                                End If

                                Try
                                    If vXmlCeldasModificadas Is Nothing Then
                                        Exit Sub
                                        Cursor = Cursors.Default
                                    Else
                                        dtResultado = objBU.DesasignarArticulosNave(vXmlCeldasModificadas.ToString, Fecha, ObtenerDevolucionHormaSuaje())
                                    End If
                                    iDNaveDesarrolla = cmbNaveDestino.SelectedValue
                                    If dtResultado.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                                        If ObtenerOpcionesEnvio() = 2 Then
                                            GenerarFormato(accionForm, iDNaveDesarrolla)
                                            'If EnviarCorreo(accionForm) = True Then
                                            '    respuestaCorreo = "Envío de correo exitoso"
                                            'End If
                                        ElseIf ObtenerOpcionesEnvio() = 1 Then
                                            GenerarFormato(accionForm, iDNaveDesarrolla)
                                        ElseIf ObtenerOpcionesEnvio() = 3 Then
                                            'If EnviarCorreo(accionForm) = True Then
                                            '    respuestaCorreo = "Envío de correo exitoso"
                                            'End If
                                        End If
                                        Cursor = Cursors.Default
                                        objExito.mensaje = "Datos guardados correctamente. " + respuestaCorreo
                                        objExito.ShowDialog()
                                        Me.DialogResult = DialogResult.OK
                                        Me.Dispose()

                                    Else
                                        Cursor = Cursors.Default
                                        objAdvertencia.mensaje = "Ocurrió un error, intente nuevamente."
                                        objAdvertencia.ShowDialog()
                                    End If

                                Catch ex As Exception
                                    MessageBox.Show(ex.Message)
                                    Cursor = Cursors.Default
                                End Try
                            Else
                                Me.DialogResult = DialogResult.None
                            End If

                    End Select
                Else
                    objAdvertencia.mensaje = "Debe seleccionar al menos un artículo."
                    objAdvertencia.ShowDialog()

                End If
            Else
                objAdvertencia.mensaje = "Debe seleccionar al menos un artículo."
                objAdvertencia.ShowDialog()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Function ValidaImagenArticulos(ByVal ProductoEstilosSeleccionados As String) As Boolean
        Dim objBU As New MovimientosPPCPBU
        Dim dtValidaImagenArticulos As New DataTable
        Dim TieneFoto As Boolean = True

        dtValidaImagenArticulos = objBU.ValidaImagenArticulos(ProductoEstiloSeleccionados)

        If dtValidaImagenArticulos.Rows.Count >= 2 Then
            TieneFoto = False
        End If

        Return TieneFoto

    End Function

    Private Function ValidarAsignacionFamiliaNave(ByVal ProductoEstilosSeleccionados As String, NaveDestinoID As Integer) As Boolean
        Dim objBU As New MovimientosPPCPBU
        Dim dtValidaFamiliaAsignada As New DataTable
        Dim TieneFamiliaAsignada As Boolean = True

        dtValidaFamiliaAsignada = objBU.ValidaFamiliaAsignada(ProductoEstiloSeleccionados, NaveDestinoID)

        If dtValidaFamiliaAsignada.Rows(0)("Mensaje") = 1 Then
            TieneFamiliaAsignada = False
        End If

        Return TieneFamiliaAsignada

    End Function

    Private Sub GenerarFormato(ByVal accionForm As String, ByVal idnave As Integer)

        Dim objBU As New MovimientosPPCPBU
        Dim MasterFormato As New DataSet("MasterFormato")
        Dim dtInformacionMovimientoColecciones As New DataTable("MovimientoColecciones")
        Dim RutaMovimiento As String = String.Empty
        Dim gerente As String = String.Empty
        Dim idNaveDesarrolla As Integer = 0
        Dim idNAsignada As Integer = 0

        Select Case accionForm
            Case "Asignar Articulos"

                If Existe = True Then
                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\DUPLICIDAD"
                Else
                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\ASIGNACIÓN"
                End If

                Try
                    Cursor = Cursors.WaitCursor

                    dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientoColecciones(accionForm, ProductoEstiloSeleccionados, Existe)

                    If dtInformacionMovimientoColecciones.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormato.Tables.Add(dtInformacionMovimientoColecciones)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()

                        gerente = dtInformacionMovimientoColecciones.Rows(0).Item("GerenteDesarrollo")
                        idNaveDesarrolla = CInt(dtInformacionMovimientoColecciones.Rows(0).Item("IdNaveOrigen"))
                        idNAsignada = CInt(dtInformacionMovimientoColecciones.Rows(0).Item("IdNaveDestino"))

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormato") = "MasterFormato"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("gerente") = gerente
                        reporte("log") = Tools.Controles.ObtenerLogoNave(idNaveDesarrolla)
                        'reporte("logo") = Tools.Controles.ObtenerLogoNave(idNAsignada)
                        reporte("fechalarga") = Date.Now.ToLongDateString().ToString()
                        If Existe = True Then
                            reporte("TipoMovimiento") = "DUPLICIDAD"
                        Else
                            reporte("TipoMovimiento") = "ASIGNACIÓN"
                        End If

                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormato)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False

                        FechaGeneracionExcel = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString
                        If Existe = True Then
                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Duplicidad " + FechaGeneracionExcel + ".xls")
                            reporte.Dispose()
                        Else
                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Asignación " + FechaGeneracionExcel + ".xls")
                            reporte.Dispose()
                        End If

                        GenerarFormatoCostos(accionForm, gerente, idNaveDesarrolla, idNAsignada)
                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()
                    End If

                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    MessageBox.Show(ex.Message)
                End Try

            Case "Transferir Articulos"
                RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\TRASPASO"
                Dim dt As New DataTable
                Try
                    Cursor = Cursors.WaitCursor

                    dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientoColecciones(accionForm, ProductoEstiloSeleccionados, Existe)
                    dt = objBU.ObtenerNaveDesarrolla(ProductoEstiloSeleccionados)
                    If dtInformacionMovimientoColecciones.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormato.Tables.Add(dtInformacionMovimientoColecciones)

                        idNaveDesarrolla = dt.Rows(0).Item("NaveId")
                        gerente = dt.Rows(0).Item("GerenteDesarrollo")
                        idNAsignada = CInt(dtInformacionMovimientoColecciones.Rows(0).Item("IdNaveDestino"))

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_TRAS")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormato") = "MasterFormato"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("TipoMovimiento") = "TRASPASO"
                        reporte("gerente") = gerente
                        reporte("log") = Tools.Controles.ObtenerLogoNave(idNaveDesarrolla)
                        reporte("fechalarga") = Date.Now.ToLongDateString().ToString()

                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormato)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False

                        FechaGeneracionExcel = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString
                        reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Traspaso " + FechaGeneracionExcel + ".xls")
                        reporte.Dispose()
                        GenerarFormatoCostos(accionForm, gerente, idNaveDesarrolla, idNAsignada)
                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()
                    End If
                Catch ex As Exception
                    Cursor = Cursors.Default
                    MessageBox.Show(ex.Message)
                End Try

            Case "Desasignar Articulos"
                RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\DESCONTINUAR"
                Try
                    Cursor = Cursors.WaitCursor
                    Dim dt As New DataTable
                    dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientoColecciones(accionForm, ProductoEstiloSeleccionados, Existe)
                    dt = objBU.ConsultaLogoGerente(idnave)
                    If dtInformacionMovimientoColecciones.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormato.Tables.Add(dtInformacionMovimientoColecciones)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_DESC")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()
                        gerente = dt.Rows(0).Item("GerenteDesarrollo")

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormato") = "MasterFormato"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("gerente") = gerente
                        reporte("log") = Tools.Controles.ObtenerLogoNave(idnave)
                        reporte("fechalarga") = Date.Now.ToLongDateString().ToString()
                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormato)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False


                        FechaGeneracionExcel = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString
                        reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Fin de Producción " + FechaGeneracionExcel + ".xls")
                        reporte.Dispose()
                        Cursor = Cursors.Default
                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()
                    End If

                Catch ex As Exception
                    Cursor = Cursors.Default
                    MessageBox.Show(ex.Message)
                End Try
        End Select

    End Sub

    Private Function generarXMLtranferir(ByVal idNave As Integer)
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Dim objBU As New MovimientosPPCPBU
        Dim dtResultado As New DataTable



        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                Dim vNodo As XElement = New XElement("Celda")
                If BanderaDescontinuar = True Then
                    vNodo.Add(New XAttribute("NaveIdSAY", idNave))
                    vNodo.Add(New XAttribute("ProductoEstiloId", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                    vNodo.Add(New XAttribute("Activo", 0))
                    vNodo.Add(New XAttribute("Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                    vNodo.Add(New XAttribute("FUltimoPrograma", vwMovimientosPPCP.GetRowCellValue(index, "Último Programa")))
                    If cmbNaveDestino.SelectedIndex > 0 Then
                        vNodo.Add(New XAttribute("FNaveDestinoID", cmbNaveDestino.SelectedValue))
                    Else
                        objAdvertencia.mensaje = "Seleccione la nave desarrollo."
                        objAdvertencia.ShowDialog()
                        Exit Function
                        Cursor = Cursors.Default
                    End If

                Else

                    If IsDBNull(vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")) = True Then
                        vNodo.Add(New XAttribute("NaveIdSAY", idNave))
                        vNodo.Add(New XAttribute("ProductoEstiloId", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                        vNodo.Add(New XAttribute("Activo", 0))
                        vNodo.Add(New XAttribute("Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("Prioridad", vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")))
                        vNodo.Add(New XAttribute("FUltimoPrograma", vwMovimientosPPCP.GetRowCellValue(index, "Último Programa")))
                        vXmlCeldasModificadas.Add(vNodo)
                        prioridad = 0
                    Else
                        vNodo.Add(New XAttribute("NaveIdSAY", idNave))
                        vNodo.Add(New XAttribute("ProductoEstiloId", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                        vNodo.Add(New XAttribute("Activo", 0))
                        vNodo.Add(New XAttribute("Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("Prioridad", vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")))
                        vNodo.Add(New XAttribute("FUltimoPrograma", vwMovimientosPPCP.GetRowCellValue(index, "Último Programa")))
                        vXmlCeldasModificadas.Add(vNodo)
                        prioridad = 1

                    End If
                End If
            End If
        Next

        Return vXmlCeldasModificadas
    End Function


    Private Function generarXML(ByVal idNave As Integer)
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For index As Integer = 0 To NumeroFilas Step 1


            If CBool(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                Dim vNodo As XElement = New XElement("Celda")
                If BanderaDescontinuar = True Then
                    vNodo.Add(New XAttribute("NaveIdSAY", idNave))
                    vNodo.Add(New XAttribute("ProductoEstiloId", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                    vNodo.Add(New XAttribute("Activo", 0))
                    vNodo.Add(New XAttribute("Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                    vNodo.Add(New XAttribute("FUltimoPrograma", vwMovimientosPPCP.GetRowCellValue(index, "Último Programa")))
                    If cmbNaveDestino.SelectedIndex > 0 Then
                        vNodo.Add(New XAttribute("FNaveDestinoID", cmbNaveDestino.SelectedValue))
                    Else
                        objAdvertencia.mensaje = "Seleccione la nave desarrollo."
                        objAdvertencia.ShowDialog()
                        Exit Function
                        Cursor = Cursors.Default
                    End If
                    vXmlCeldasModificadas.Add(vNodo)
                Else
                    If IsDBNull(vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")) = True Then

                        vNodo.Add(New XAttribute("NaveIdSAY", idNave))
                        vNodo.Add(New XAttribute("ProductoEstiloId", vwMovimientosPPCP.GetRowCellValue(index, "ProductoEstiloId")))
                        vNodo.Add(New XAttribute("Activo", 0))
                        vNodo.Add(New XAttribute("Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("Prioridad", vwMovimientosPPCP.GetRowCellValue(index, "Prioridad")))
                        vNodo.Add(New XAttribute("FUltimoPrograma", vwMovimientosPPCP.GetRowCellValue(index, "Último Programa")))
                        vXmlCeldasModificadas.Add(vNodo)


                        'Else
                        '    objAdvertencia.mensaje = "Coloque la prioridad de los artículos seleccionados."
                        '    objAdvertencia.ShowDialog()
                        '    Exit Function
                        '    Cursor = Cursors.Default
                    End If
                End If
            End If


        Next
        Return vXmlCeldasModificadas
    End Function


    Private Sub GenerarFormatoCostos(ByVal accionForm As String, ByVal gerente As String, ByVal idnave As Integer, ByVal idNAsignada As Integer)
        Dim objBU As New MovimientosPPCPBU
        Dim MasterFormatoCostos As New DataSet("MasterFormatoCostos")
        Dim dtInformacionMovimientoCostos As New DataTable("dtInformacionMovimientoCostos")
        Dim RutaMovimiento As String

        Select Case accionForm
            Case "Asignar Articulos"

                If Existe = True Then
                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\DUPLICIDAD"
                Else
                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\ASIGNACIÓN"
                End If

                Try
                    Cursor = Cursors.WaitCursor

                    dtInformacionMovimientoCostos = objBU.ObtenerInformacionMovimientoColecciones_ReporteCostos(accionForm, ProductoEstiloSeleccionados, Existe)

                    If dtInformacionMovimientoCostos.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormatoCostos.Tables.Add(dtInformacionMovimientoCostos)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_COSTOS")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormatoCostos") = "MasterFormatoCostos"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("MaterialDirecto") = 0
                        reporte("MaterialIndirecto") = 0
                        reporte("ManoObra") = 0
                        reporte("DepartamentoCalidad") = 0
                        reporte("GastosGenerales") = 0
                        reporte("Utilidad") = 0
                        reporte("gerente") = gerente
                        reporte("log") = Tools.Controles.ObtenerLogoNave(idnave)
                        reporte("logo") = Tools.Controles.ObtenerLogoNave(idNAsignada)
                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormatoCostos)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False
                        If Existe = True Then
                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Duplicidad_Costos " + FechaGeneracionExcel + ".xls")
                            reporte.Dispose()
                        Else
                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Asignación_Costos " + FechaGeneracionExcel + ".xls")
                            reporte.Dispose()
                        End If

                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()
                    End If

                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    MessageBox.Show(ex.Message)
                End Try
            Case "Transferir Articulos"
                RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\TRASPASO"

                Try
                    Cursor = Cursors.WaitCursor

                    dtInformacionMovimientoCostos = objBU.ObtenerInformacionMovimientoColecciones_ReporteCostos(accionForm, ProductoEstiloSeleccionados, Existe)

                    If dtInformacionMovimientoCostos.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormatoCostos.Tables.Add(dtInformacionMovimientoCostos)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_COSTOS")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormatoCostos") = "MasterFormatoCostos"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("MaterialDirecto") = 0
                        reporte("MaterialIndirecto") = 0
                        reporte("ManoObra") = 0
                        reporte("DepartamentoCalidad") = 0
                        reporte("GastosGenerales") = 0
                        reporte("Utilidad") = 0
                        reporte("gerente") = gerente
                        reporte("log") = Tools.Controles.ObtenerLogoNave(idnave)
                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormatoCostos)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False

                        reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de Traspaso_Costos " + FechaGeneracionExcel + ".xls")
                        reporte.Dispose()
                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()
                    End If
                Catch ex As Exception
                    Cursor = Cursors.Default
                    MessageBox.Show(ex.Message)
                End Try

        End Select
    End Sub


    Private Function EnviarCorreo(ByVal accionForm As String) As Boolean
        Dim CorreoEnviado As String = String.Empty
        Dim dtResultadoDatosCorreos As New DataTable
        Dim objBU As New MovimientosPPCPBU
        Dim remitente As String = String.Empty
        Dim rutaArchivoMovimiento As String = String.Empty
        Dim rutaArchivoMovimientoCostos As String = String.Empty
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim asuntoCorreo As String = String.Empty
        Dim cadenaCorreo As String = String.Empty
        Dim entCorreo As New Entidades.DatosCorreo
        Dim CorreosDestinatario As String = String.Empty
        Dim dtCorreosDestinarios As New DataTable
        Dim correo As New Tools.Correo
        Dim StatusCorreo As Boolean = False
        Dim dtActualizarEstatusCorreo As New DataTable
        Dim RutaMovimiento As String
        Dim NumeroFilas As Integer = vwMovimientosPPCP.DataRowCount
        Dim TipoMovimiento As String = String.Empty
        Dim ColeccionNombre As String = String.Empty
        Dim lstContadorColeccionesId As New List(Of String)
        Dim FechaInicioProduccion As String = dtpFechaProgramarDesde.Value.Day.ToString + "/" + dtpFechaProgramarDesde.Value.Month.ToString + "/" + dtpFechaProgramarDesde.Value.Year.ToString
        Dim DevolverHorma As String = String.Empty
        Dim FechaFinProduccion As String = dtpProgramarHastaTras.Value.Day.ToString + "/" + dtpProgramarHastaTras.Value.Month.ToString + "/" + dtpProgramarHastaTras.Value.Year.ToString
        Dim NaveDestino As String = String.Empty

        Dim GrupoNaveNombre As String = String.Empty

        dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
        remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()


        Try

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    If lstContadorColeccionesId.Contains(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Colección").ToString()) = False Then
                        lstContadorColeccionesId.Add(vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Colección").ToString())
                        If ColeccionNombre <> "" Then
                            ColeccionNombre += ","
                        End If
                        If ObtenerDevolucionHormaSuaje() = 1 Or ObtenerDevolucionHormaSuaje() = 3 Then
                            DevolverHorma = "SI"
                        Else
                            DevolverHorma = "NO"
                        End If

                        ColeccionNombre += vwMovimientosPPCP.GetRowCellValue(vwMovimientosPPCP.GetVisibleRowHandle(index), "Colección").ToString
                    End If
                End If
            Next

            NaveDestino = IIf(cmbNaveDestino.SelectedIndex > 0, cmbNaveDestino.Text, "")

            Select Case accionForm
                Case "Asignar Articulos"
                    If Existe = True Then
                        TipoMovimiento = "DUPLICIDAD"
                    Else
                        TipoMovimiento = "ASIGNACIÓN"
                    End If
                Case "Transferir Articulos"
                    TipoMovimiento = "TRASPASO"
                Case "Desasignar Articulos"
                    TipoMovimiento = "DESCONTINUAR"

            End Select

            dtCorreosDestinarios = objBU.ObtenerCorreosDestinatario(cmbNaveOrigen.SelectedValue, cmbNaveDestino.SelectedValue)

            If dtCorreosDestinarios.Rows.Count > 0 Then

                'Dim dtObtieneCorreosporColeccion As New DataTable

                'dtObtieneCorreosporColeccion = objBU.ObtieneCorreosDesarrolladoresNaves(ColeccionNombre)

                CorreosDestinatario = String.Empty

                GrupoNaveNombre = dtCorreosDestinarios.Rows(0).Item("GrupoNaveNombre").ToString

                For Each row As DataRow In dtCorreosDestinarios.Rows
                    If CorreosDestinatario <> "" Then
                        CorreosDestinatario += ","
                    End If

                    CorreosDestinatario += row.Item("destinatarios").ToString
                Next

            End If

            RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\" + TipoMovimiento

            asuntoCorreo = "Asunto: Aviso Formato de " + StrConv(TipoMovimiento, vbProperCase) + " y Costos"
            rutaArchivoMovimiento = RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + " " + FechaGeneracionExcel + ".xls"
            rutaArchivoMovimientoCostos = RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + "_Costos " + FechaGeneracionExcel + ".xls"

            Select Case accionForm

                Case "Asignar Articulos"

                    Cursor = Cursors.WaitCursor

                    cadenaCorreo = "<html> " +
                                  " <head>" +
                                  " </head>"
                    cadenaCorreo += " <body> "
                    cadenaCorreo += " <br><p>Buen día: Les informo que se autorizó la " + StrConv(TipoMovimiento, vbProperCase) + " de la colección " + ColeccionNombre + "  a Nave " + NaveDestino + " . .</p>"
                    cadenaCorreo += " <p>Esta planeado iniciar producción el " + FechaInicioProduccion + ", para que vayan anticipando lo necesario para su entrega y producción.</p>"
                    cadenaCorreo += " <p>Favor de coordinarse para que se cuente con lo necesario para producir esta colección en las fechas solicitadas.</p> "
                    cadenaCorreo += " <br><p> Quedo a sus órdenes para cualquier duda o comentario. </p>"
                    cadenaCorreo += " <br><p> Saludos!!!! </p>"
                    cadenaCorreo += " <br><p> Atentamente " + GrupoNaveNombre + " </p>"
                    cadenaCorreo += " </body> " +
                                    " </html> "



                    If rutaArchivoMovimiento <> String.Empty Then
                        archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimiento)
                        lstArchivoAdjuntos.Add(archivoAdjunto)
                    End If

                    If rutaArchivoMovimientoCostos <> String.Empty Then
                        archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimientoCostos)
                        lstArchivoAdjuntos.Add(archivoAdjunto)
                    End If

                    entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

                    If entCorreo.CorreoEnviado = True Then

                        dtActualizarEstatusCorreo = objBU.ActualizarEstatusCorreoExportar(ProductoEstiloSeleccionados, Existe, IdNaveSay, accionForm)

                        CorreoEnviado = "S"
                        StatusCorreo = True

                    Else
                        CorreoEnviado = "N"
                        StatusCorreo = False
                    End If

                    Cursor = Cursors.Default

                Case "Transferir Articulos"

                    Cursor = Cursors.WaitCursor

                    cadenaCorreo = "<html> " +
                                  " <head>" +
                                  " </head>"
                    cadenaCorreo += " <body> "
                    cadenaCorreo += " <br><p>Buen día: Les informo que se autorizó el " + StrConv(TipoMovimiento, vbProperCase) + " de la colección " + ColeccionNombre + "  a Nave " + NaveDestino + " . .</p>"
                    cadenaCorreo += " <p>Esta planeado iniciar producción el " + FechaInicioProduccion + ", para que vayan anticipando lo necesario para su entrega y producción.</p>"
                    cadenaCorreo += " <p>Favor de coordinarse para que se cuente con lo necesario para producir esta colección en las fechas solicitadas.</p> "
                    cadenaCorreo += " <br><p> Quedo a sus órdenes para cualquier duda o comentario. </p>"
                    cadenaCorreo += " <br><p> Saludos!!!! </p>"
                    cadenaCorreo += " <br><p> Atentamente " + GrupoNaveNombre + " </p>"
                    cadenaCorreo += " </body> " +
                                        " </html> "

                    If rutaArchivoMovimiento <> String.Empty Then
                        archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimiento)
                        lstArchivoAdjuntos.Add(archivoAdjunto)
                    End If

                    If rutaArchivoMovimientoCostos <> String.Empty Then
                        archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimientoCostos)
                        lstArchivoAdjuntos.Add(archivoAdjunto)
                    End If

                    entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

                    If entCorreo.CorreoEnviado = True Then

                        dtActualizarEstatusCorreo = objBU.ActualizarEstatusCorreoExportar(ProductoEstiloSeleccionados, Existe, IdNaveSay, accionForm)

                        CorreoEnviado = "S"
                        StatusCorreo = True

                    Else
                        CorreoEnviado = "N"
                        StatusCorreo = False
                    End If

                    Cursor = Cursors.Default


                Case "Desasignar Articulos"

                    Cursor = Cursors.WaitCursor

                    asuntoCorreo = "Asunto: Aviso Formato de Fin de Producción"
                    rutaArchivoMovimiento = RutaMovimiento + "\Formato de Aviso de Fin de Producción " + FechaGeneracionExcel + ".xls"

                    cadenaCorreo = "<html> " +
                                  " <head>" +
                                  " </head>"
                    cadenaCorreo += " <body> "
                    cadenaCorreo += " <br><p>Buen día: Les informo que a partir de la fecha " + FechaFinProduccion + " la colección " + ColeccionNombre + "  se dejará de producir.  . .</p>"
                    If DevolverHorma = "SI" Then
                        cadenaCorreo += " <p>Por lo que les pido que les sea entregados los herramentales a la nave " + NaveDestino + ", en cuanto ya no los estén ocupando en la producción, para que realicen su resguardo.</p> "
                    Else
                        cadenaCorreo += " <p>Por lo que les pido que les sea entregados los suajes a la nave " + NaveDestino + ", en cuanto ya no los estén ocupando en la producción, para que realicen su resguardo.</p> "
                    End If
                    cadenaCorreo += " <br><p> Quedo a sus órdenes para cualquier duda o comentario. </p>"
                    cadenaCorreo += " <br><p> Saludos!!!! </p>"
                    cadenaCorreo += " <br><p> Atentamente " + GrupoNaveNombre + " </p>"
                    cadenaCorreo += " </body> " +
                                        " </html> "

                    If rutaArchivoMovimiento <> String.Empty Then
                        archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimiento)
                        lstArchivoAdjuntos.Add(archivoAdjunto)
                    End If

                    entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

                    If entCorreo.CorreoEnviado = True Then

                        dtActualizarEstatusCorreo = objBU.ActualizarEstatusCorreoExportar(ProductoEstiloSeleccionados, Existe, IdNaveSay, accionForm)

                        CorreoEnviado = "S"
                        StatusCorreo = True

                    Else
                        CorreoEnviado = "N"
                        StatusCorreo = False
                    End If
                    Cursor = Cursors.Default
            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Cursor = Cursors.Default
        End Try



        Return StatusCorreo
    End Function


    Private Function ExisteEnOtraNave() As Boolean
        Dim objBU As New MovimientosPPCPBU
        Dim dtExiste As New DataTable

        dtExiste = objBU.ExistEnOtraNave(ProductoEstiloSeleccionados)

        If dtExiste.Rows(0).Item("respuesta").ToString = True Then
            Existe = True
        Else
            Existe = False
        End If

        Return Existe

    End Function


    Private Sub chExportar_CheckedChanged(sender As Object, e As EventArgs) Handles chExportar.CheckedChanged
        If chExportar.Checked Then
            exportar = 1
        Else
            exportar = 0
        End If
    End Sub

    Private Sub vwMovimientosPPCP_InvalidValueException(sender As Object, e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles vwMovimientosPPCP.InvalidValueException
        Select Case vwMovimientosPPCP.FocusedColumn.FieldName
            Case "Prioridad"
                e.ErrorText = "El valor ingresado debe ser numérico y no puede ser menor a 0."
        End Select

    End Sub

    Private Sub vwMovimientosPPCP_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles vwMovimientosPPCP.ValidatingEditor
        Select Case vwMovimientosPPCP.FocusedColumn.FieldName
            Case "Prioridad"
                Dim num As Integer

                If IsNumeric(e.Value) Then
                    If Convert.ToInt32(e.Value) <= 0 Then
                        e.Valid = False
                    End If
                Else
                    If Not Integer.TryParse(e.Value, num) Then
                        e.Valid = False
                    End If
                End If
        End Select
    End Sub

    Private Sub vwMovimientosPPCP_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwMovimientosPPCP.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub


    Private Sub cmbNaveDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaveDestino.SelectedIndexChanged

        If accionForm = "Asignar Articulos" Then
            grdMovimientosPPCP.DataSource = Nothing
        Else

        End If

    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        If cmbMarca.SelectedIndex > 0 Then
            marca = cmbMarca.Text

        End If
    End Sub
    Private Sub desabilitarcorrida(sender As Object, e As EventArgs) Handles chFiltarCorrida.CheckedChanged
        If chFiltarCorrida.Checked = True Then
            btnAgregarCorrida.Enabled = True
            btnLimCorrida.Enabled = True

        ElseIf chFiltarCorrida.Checked = False Then
            btnAgregarCorrida.Enabled = False
            btnLimCorrida.Enabled = False
        End If
    End Sub

    Private Sub cmbNaveOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaveOrigen.SelectedIndexChanged
        If cmbNaveOrigen.SelectedIndex > 0 Then
            IdNaveSay = cmbNaveOrigen.SelectedValue
            cmbMarca.Enabled = True
            llenarMarcas()

        Else
            cmbMarca.Enabled = False
        End If
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub
    Private Sub grdColeccion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim listado As New FiltrosMovimientosArticulos
        Dim listaParametroID As New List(Of String)

        If accionForm = "Asignar Articulos" Then
            listado.tipo = 1
            listado.tipo_busqueda = 1
            listado.NaveSayId = cmbNaveOrigen.SelectedValue
            listado.Marca = cmbMarca.Text


            For Each row As UltraGridRow In grdColeccion.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdColeccion.DataSource = listado.listParametros
            With grdColeccion
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        Else

            listado.tipo = 2
            listado.tipo_busqueda = 1
            listado.NaveSayId = cmbNaveOrigen.SelectedValue
            listado.Marca = cmbMarca.Text


            For Each row As UltraGridRow In grdColeccion.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdColeccion.DataSource = listado.listParametros
            With grdColeccion
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With
        End If
    End Sub

    Private Sub btnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        Dim listado As New FiltrosMovimientosArticulos
        Dim listaParametroID As New List(Of String)

        If accionForm = "Asignar Articulos" Then

            listado.tipo = 1
            listado.tipo_busqueda = 2
            listado.NaveSayId = cmbNaveOrigen.SelectedValue
            listado.Marca = cmbMarca.Text
            listado.Colecciones = ObtenerFiltrosGrid(grdColeccion)


            For Each row As UltraGridRow In grdCorrida.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            If listado.listParametros.Rows.Count > 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Seleccione solo una corrida")
                listaParametroID.Clear()
                grdCorrida.DataSource = Nothing
                Return
            End If
            grdCorrida.DataSource = listado.listParametros
            With grdCorrida
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With

        Else

            listado.tipo = 2
            listado.tipo_busqueda = 2
            listado.NaveSayId = cmbNaveOrigen.SelectedValue
            listado.Marca = cmbMarca.Text
            listado.Colecciones = ObtenerFiltrosGrid(grdColeccion)


            For Each row As UltraGridRow In grdCorrida.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            grdCorrida.DataSource = listado.listParametros
            With grdCorrida
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
            End With

        End If
    End Sub
    Public Sub LlenarTablaArticulos()
        Dim objPBU As New Programacion.Negocios.MovimientosPPCPBU
        Dim dtConsultaArticulosNoAsignados As DataTable
        Dim grdActualizar As New UltraGrid

        dtConsultaArticulosNoAsignados = objPBU.ObtieneArticulosNoAsignadosPorNave(IdNaveSay, marca, FColeccion)
        inicio = False
        If dtConsultaArticulosNoAsignados.Rows.Count <> 0 Then
            grdMovimientosPPCP.DataSource = dtConsultaArticulosNoAsignados
            ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
            DisenioGrid()
            lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")
            cmbNaveOrigen.Enabled = False


        ElseIf dtConsultaArticulosNoAsignados.Rows.Count = 0 And cmbNaveDestino.SelectedIndex <> 0 And FColeccion <> "" Then
            objAdvertencia.mensaje = "No existen artículos para asignar a esta nave."
            objAdvertencia.ShowDialog()

        End If


    End Sub

    Public Sub LlenarTablaArticulosTransferir()
        Dim objPBU As New Programacion.Negocios.MovimientosPPCPBU
        Dim dtConsultaArticulosNoAsignados As DataTable
        Dim grdActualizar As New UltraGrid

        dtConsultaArticulosNoAsignados = objPBU.ObtieneArticulosParaTraspaso(FColeccion, accionForm, IdNaveSay, marca)
        inicio = False
        grdMovimientosPPCP.DataSource = dtConsultaArticulosNoAsignados
        ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
        DisenioGrid()
        lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")
        cmbNaveOrigen.Enabled = False


    End Sub


    Public Sub LlenarTablaArticulosTallas()
        Dim objPBU As New Programacion.Negocios.MovimientosPPCPBU
        Dim dtConsultaArticulosTallas As DataTable
        Dim grdActualizar As New UltraGrid


        dtConsultaArticulosTallas = objPBU.ObtieneArticulostallas(IdNaveSay, FColeccion, marca, FCorrida)
        inicio = False
        If dtConsultaArticulosTallas.Rows.Count <> 0 Then
            grdMovimientosPPCP.DataSource = dtConsultaArticulosTallas
            ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
            DisenioGrid()
            lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")
            cmbNaveOrigen.Enabled = False

        ElseIf dtConsultaArticulosTallas.Rows.Count = 0 And cmbNaveDestino.SelectedIndex <> 0 And FColeccion <> "" Then
            objAdvertencia.mensaje = "No existen artículos para asignar a esta nave."
            objAdvertencia.ShowDialog()

        End If



    End Sub

    Public Sub LlenarTablaArticulosTallasTransferir()
        Dim objPBU As New Programacion.Negocios.MovimientosPPCPBU
        Dim dtConsultaArticulosTallas As DataTable
        Dim grdActualizar As New UltraGrid


        dtConsultaArticulosTallas = objPBU.ObtieneArticulosParaTraspasoTalla(FColeccion, accionForm, IdNaveSay, marca, FCorrida)
        inicio = False
        grdMovimientosPPCP.DataSource = dtConsultaArticulosTallas
        ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
        DisenioGrid()
        lblNumFiltrados.Text = CDbl(vwMovimientosPPCP.RowCount.ToString()).ToString("n0")
        cmbNaveOrigen.Enabled = False


    End Sub




    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub btnLimCorrida_Click(sender As Object, e As EventArgs) Handles btnLimCorrida.Click
        grdCorrida.DataSource = listaInicial
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdMovimientosPPCP.DataSource = Nothing
        cmbNaveOrigen.SelectedIndex = 0
        cmbNaveOrigen.Enabled = True
        cmbNaveDestino.SelectedIndex = 0
        cmbMarca.SelectedIndex = 0
        grdColeccion.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial

    End Sub


End Class