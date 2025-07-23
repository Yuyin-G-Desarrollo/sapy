Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports Stimulsoft.Report
Imports Tools

Public Class DevolucionCliente_EntradaSalida_Naves

    Public negocios As New Negocios.DevolucionCliente_EntradaSalida_Nave_BU
    Dim btnSeleccion As New RepositoryItemButtonEdit
    Public dtCodigos As New DataTable
    Public dtRecibidos As New DataTable
    Public operacion As Int16 = 0
    Public folioSalida As Integer = 0
    Public IdNave As Int64 = 0
    Public operadorNave As String = ""
    Public fechaEnvio As Date
    Public fechaEstimadaRecepcionas As Date
    Public soloLectura As Boolean = False

    Public Function ValidarCodigoRepetido(codigo As String, tabla As DataTable)
        Dim partesCodigo As New List(Of String)
        partesCodigo = codigo.Split("-").ToList
        For Each row As DataRow In tabla.Rows
            For Each elemento In partesCodigo
                If elemento = row("CódigoPar").ToString Then
                    Return False
                End If
            Next
        Next
        Return True
    End Function

    Public Sub ConsultarCodigo()
        Dim codigo As String = txtCodigo.Text
        If ValidarCodigoRepetido(codigo, dtCodigos) = False Then
            lblCodigoRepetido.Visible = True
            txtCodigo.Text = ""
            txtCodigo.Select()
            Exit Sub
        Else
            lblCodigoRepetido.Visible = False
        End If

        Dim dtInfoPar As New DataTable

        If cmbProceso.SelectedIndex = 1 Then
            dtInfoPar = negocios.ConsultaCodigoPar(codigo, cmbNave.SelectedValue)
            If dtCodigos.Rows.Count = 0 Then
                dtCodigos = dtInfoPar.Clone
            End If

            Dim fila As DataRow = dtCodigos.NewRow

            For Each columna As DataColumn In dtInfoPar.Columns
                fila(columna.Caption) = dtInfoPar.Rows(0).Item(columna.Caption)
            Next

            dtCodigos.Rows.Add(fila)

            grdLecturaActual.DataSource = Nothing
            grdLecturaActual.DataSource = dtCodigos
            FormatoGrid(bgvLecturaActual)
            txtCodigo.Text = ""
            txtCodigo.Select()
            lblNumFiltrados.Text = bgvLecturaActual.DataRowCount
        Else
            If ValidarCodigoRepetido(codigo, dtRecibidos) = False Then
                lblCodigoRepetido.Visible = True
                txtCodigo.Text = ""
                txtCodigo.Select()
                Exit Sub
            Else
                lblCodigoRepetido.Visible = False
            End If
            Dim dtEnviados = grdLecturaAnterior.DataSource
            If dtRecibidos.Rows.Count = 0 Then dtRecibidos = dtEnviados.Clone
            Dim fila As DataRow
            For Each row As DataRow In dtEnviados.Rows
                If row("CódigoPar") = codigo Then
                    fila = dtRecibidos.NewRow
                    For Each columna As DataColumn In dtEnviados.Columns
                        fila(columna.Caption) = row(columna.Caption)
                    Next
                    dtRecibidos.Rows.Add(fila)
                    dtEnviados.Rows.Remove(row)
                    grdLecturaActual.DataSource = dtRecibidos
                    grdLecturaAnterior.DataSource = dtEnviados
                    FormatoGrid(bgvLecturaActual)
                    txtCodigo.Text = ""
                    txtCodigo.Select()
                    Exit Sub
                End If
            Next

            fila = dtRecibidos.NewRow
            For Each columna As DataColumn In dtEnviados.Columns
                If columna.Caption = " " Then
                    fila(columna.Caption) = False
                ElseIf columna.Caption = "CódigoPar" Then
                    fila(columna.Caption) = codigo
                ElseIf columna.Caption = "Error" Then
                    fila(columna.Caption) = "El par no se encuentra en este folio de salida"
                ElseIf columna.Caption = "Devolución" Or columna.Caption = "Talla" Or columna.Caption = "Lote" Or columna.Caption = "AñoLote" Or columna.Caption = "ProductoEstiloID" Or columna.Caption = "IdNaveSAY" Then
                    fila(columna.Caption) = 0
                Else
                    fila(columna.Caption) = "-"
                End If
            Next
            dtRecibidos.Rows.Add(fila)
            grdLecturaActual.DataSource = dtRecibidos
            FormatoGrid(bgvLecturaActual)
            txtCodigo.Text = ""
            txtCodigo.Select()
        End If

        If CInt(lblNumFiltrados.Text) = 0 Then
            cmbNave.Enabled = True
            cmbProceso.Enabled = True
        Else
            cmbNave.Enabled = False
            cmbProceso.Enabled = False
        End If
    End Sub

    Public Sub FormatoGrid(vista As GridView)
        vista.OptionsView.ColumnAutoWidth = False

        If vista.Name = "bgvLecturaAnterior" Then
            With btnSeleccion
                .Name = "BtnSeleccion"
                .Buttons(0).Image = Global.Almacen.Vista.My.Resources.Resources._1373583708_101
                .AutoHeight = False
                .TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                .Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                .Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph

                AddHandler btnSeleccion.Click, AddressOf BtnSeleccion_Clic
            End With

            If bgvLecturaAnterior.DataRowCount > 0 Then
                grdLecturaAnterior.RepositoryItems.Add(btnSeleccion)
                bgvLecturaAnterior.Columns(" ").ColumnEdit = btnSeleccion
                bgvLecturaAnterior.Columns(" ").ColumnEdit.Name = "BtnSeleccion2"
            End If

        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vista.Columns
            If soloLectura = True Then
                col.OptionsColumn.AllowEdit = False
            ElseIf col.FieldName <> " " And col.FieldName <> "Observación" Then
                col.OptionsColumn.AllowEdit = False
            End If
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        Next

        vista.Columns.ColumnByFieldName("Status").Visible = False
        vista.Columns.ColumnByFieldName("IdNaveSAY").Visible = False
        vista.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False
        vista.BestFitColumns()

        vista.IndicatorWidth = 40
    End Sub

    Public Sub ActivarDesactivarBotones(activo As Boolean)
        btnCerrar.Enabled = activo
        btnGuardar.Enabled = activo
        btnIniciar.Enabled = activo
        btnImprimir.Enabled = activo
        cmbNave.Enabled = activo
        cmbProceso.Enabled = activo
        dtpFechaEnvio.Enabled = activo
        dtpFechaEstimadaRecepcion.Enabled = activo
        btnDetener.Enabled = Not activo
        txtCodigo.Enabled = Not activo
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        e.Handled = Char.IsWhiteSpace(e.KeyChar)
        If e.KeyChar = "'" Then
            e.KeyChar = "-"
        End If
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            ConsultarCodigo()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim formAdmin As New DevolucionCliente_EntradaSalida_Naves_Administrador
        formAdmin.MdiParent = Me.MdiParent
        formAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        If cmbNave.SelectedIndex > 0 Then
            ActivarDesactivarBotones(False)
            txtCodigo.Select()
        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione una nave")
        End If

    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        ActivarDesactivarBotones(True)
    End Sub

    Public Sub ConsultaDetalles()
        If folioSalida <> 0 Then
            Dim dtPares As DataTable = negocios.ConsultaDetallesSalidas(folioSalida)
            If dtPares.Rows.Count = 0 Then Exit Sub
            If dtPares.Rows(0).Item("St").ToString = "223" Then
                grdLecturaActual.DataSource = dtPares
                FormatoGrid(bgvLecturaActual)
            Else
                grdLecturaAnterior.DataSource = dtPares
                FormatoGrid(bgvLecturaAnterior)
            End If


            txtFolioSalida.Text = folioSalida
            txtFolioSalida.Enabled = False
            cmbNave.SelectedValue = IdNave
            txtOperador.Text = operadorNave
            dtpFechaEnvio.Value = fechaEnvio
            dtpFechaEstimadaRecepcion.Value = fechaEstimadaRecepcionas
            txtOperador.ReadOnly = True
        Else
            txtFolioSalida.Text = ""
            txtFolioSalida.Enabled = True
        End If
    End Sub

    Private Sub DevolucionCliente_EntradaSalida_Naves_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtNaves As New DataTable
        dtNaves = negocios.ConsultaNaves()
        Dim newRow As DataRow = dtNaves.NewRow
        dtNaves.Rows.InsertAt(newRow, 0)
        cmbNave.DataSource = dtNaves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "IdNave"
        cmbNave.SelectedIndex = 0
        cmbProceso.SelectedIndex = operacion

        If operacion = 0 Then
            lblFechaRecepcion.Visible = True
            dtpFechaRecepcion.Visible = True
            dtpFechaEnvio.Enabled = False
            dtpFechaEstimadaRecepcion.Enabled = False
            cmbNave.Enabled = False
            cmbProceso.Enabled = False
            ConsultaDetalles()
        End If

        If soloLectura Then
            pnlBtnIniciar.Visible = False
            pnlBtnDetener.Visible = False
            Panel1.Enabled = False
            btnGuardar.Enabled = False
        End If
    End Sub

    Public Sub GenerarSalida()
        If dtpFechaEnvio.Value = dtpFechaEstimadaRecepcion.Value Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha estimada de recepción no puede ser menor o igual a la de envío")
            Exit Sub
        End If

        If bgvLecturaActual.DataRowCount = 0 Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Aún no se han capturado pares")
            Exit Sub
        End If

        If txtOperador.Text.Length = 0 Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese el nombre del operador")
            lblOperador.ForeColor = Color.Red
            Exit Sub
        Else
            lblOperador.ForeColor = Color.Black
        End If

        Dim ventanaConfirmacion As New Tools.ConfirmarForm
        ventanaConfirmacion.mensaje = "Una vez generada la salida no se podran agregar o eliminar pares" + vbCrLf + "¿Desea continuar?"
        ventanaConfirmacion.ShowDialog()

        If ventanaConfirmacion.DialogResult = DialogResult.OK Then

            Try
                Cursor = Cursors.WaitCursor
                Dim xmlDetalleSalidas As XElement = New XElement("Salidas")
                For index As Integer = 0 To bgvLecturaActual.DataRowCount - 1 Step 1
                    If CBool(bgvLecturaActual.GetRowCellValue(bgvLecturaActual.GetVisibleRowHandle(index), " ")) = True Then
                        Dim vNodo As XElement = New XElement("Salida")
                        vNodo.Add(New XAttribute("nave", cmbNave.SelectedValue))
                        vNodo.Add(New XAttribute("paresenviados", lblNumFiltrados.Text))
                        vNodo.Add(New XAttribute("paresrecibidos", 0))
                        vNodo.Add(New XAttribute("parespendientes", lblNumFiltrados.Text))
                        vNodo.Add(New XAttribute("usuariocaptura_salida", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("operadornave", txtOperador.Text))
                        vNodo.Add(New XAttribute("fechasalida", dtpFechaEnvio.Value))
                        vNodo.Add(New XAttribute("fechaestimada_recepcion", dtpFechaEstimadaRecepcion.Value))
                        vNodo.Add(New XAttribute("codigopar", bgvLecturaActual.GetRowCellValue(index, "CódigoPar")))
                        vNodo.Add(New XAttribute("devolucioncliente_id", bgvLecturaActual.GetRowCellValue(index, "Devolución")))
                        vNodo.Add(New XAttribute("recibido", 0))
                        xmlDetalleSalidas.Add(vNodo)
                    End If
                Next

                Dim dtFolio As New DataTable
                dtFolio = negocios.GenerarSalida(xmlDetalleSalidas.ToString())

                If dtFolio.Rows.Count > 0 Then
                    txtFolioSalida.Text = dtFolio.Rows(0).Item(0).ToString
                End If

                grdLecturaActual.DataSource = Nothing

                Dim ventana As New Tools.ExitoForm
                ventana.mensaje = "Salida generada exitosamente"
                ventana.ShowDialog()

                lblNumFiltrados.Text = 0
                ConsultaDetalles()
                Cursor = Cursors.Default
            Catch ex As Exception
                Dim ventanaError As New Tools.ErroresForm
                ventanaError.mensaje = "Ocurrió un error al guardar" + vbCrLf + ex.Message
                ventanaError.ShowDialog()
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Public Sub GenerarEntrada()
        If bgvLecturaAnterior.DataRowCount > 0 Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Aún hay pares faltantes para recibir")
            Exit Sub
        End If

        Try
            Cursor = Cursors.WaitCursor
            Dim xmlDetalleEntradas As XElement = New XElement("Entradas")
            For index As Integer = 0 To bgvLecturaActual.DataRowCount - 1 Step 1
                If CBool(bgvLecturaActual.GetRowCellValue(bgvLecturaActual.GetVisibleRowHandle(index), " ")) = True Then
                    Dim vNodo As XElement = New XElement("Entrada")
                    vNodo.Add(New XAttribute("foliosalida", txtFolioSalida.Text))
                    vNodo.Add(New XAttribute("usuariocaptura_entrada", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                    vNodo.Add(New XAttribute("fecha_recepcion", dtpFechaRecepcion.Value))
                    vNodo.Add(New XAttribute("paresrecibidos", bgvLecturaActual.DataRowCount))
                    vNodo.Add(New XAttribute("codigopar", bgvLecturaActual.GetRowCellValue(index, "CódigoPar")))
                    vNodo.Add(New XAttribute("observaciones", bgvLecturaActual.GetRowCellValue(index, "Observación")))
                    vNodo.Add(New XAttribute("recibido", 1))
                    xmlDetalleEntradas.Add(vNodo)
                End If
            Next

            Dim dtFolio As New DataTable
            dtFolio = negocios.GenerarEntrada(xmlDetalleEntradas.ToString())

            If dtFolio.Rows.Count > 0 Then
                Tools.Controles.Mensajes_Y_Alertas("ERROR", dtFolio.Rows(0).Item(0).ToString)
            End If

            grdLecturaActual.DataSource = Nothing

            Dim ventana As New Tools.ExitoForm
            ventana.mensaje = "Los pares fueron recibidos exitosamente"
            ventana.ShowDialog()

            lblNumFiltrados.Text = 0
            Cursor = Cursors.Default
        Catch ex As Exception
            Dim ventanaError As New Tools.ErroresForm
            ventanaError.mensaje = "Ocurrió un error al guardar" + vbCrLf + ex.Message
            ventanaError.ShowDialog()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cmbProceso.SelectedIndex = 1 Then
            GenerarSalida()
        Else
            GenerarEntrada()
        End If
    End Sub

    Private Sub bgvLecturaActual_RowStyle(sender As Object, e As RowStyleEventArgs) Handles bgvLecturaActual.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Try
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns(" ")) = "No seleccionado" Then
                    e.Appearance.ForeColor = Color.Red
                End If

                If e.RowHandle Mod 2 = 0 Then
                    e.Appearance.BackColor = Color.LightSteelBlue
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtFolioSalida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioSalida.KeyPress
        If (e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter)) And txtFolioSalida.Text.Length > 0 Then
            Dim dtInformacion As New DataTable
            dtInformacion = negocios.ConsultaDetallesSalidas(CInt(txtFolioSalida.Text))
            If dtInformacion.Rows.Count > 0 Then
                grdLecturaAnterior.DataSource = negocios.ConsultaDetallesSalidas(CInt(txtFolioSalida.Text))
                FormatoGrid(bgvLecturaAnterior)
                cmbNave.SelectedValue = dtInformacion.Rows(0).Item("IdNaveSAY")
                txtOperador.Text = dtInformacion.Rows(0).Item("Operador")
            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron resultados")
            End If

        End If
    End Sub

    Private Sub bgvLecturaActual_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvLecturaActual.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvLecturaAnterior_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvLecturaAnterior.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub BtnSeleccion_Clic(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim filaActual As Int64 = bgvLecturaAnterior.FocusedRowHandle
            Dim IdDetalle As Integer = CInt(bgvLecturaAnterior.GetRowCellValue(filaActual, "IDIncidencia"))
            Dim observacion As String = bgvLecturaAnterior.GetRowCellValue(filaActual, "Observación").ToString
            If observacion.Trim.Length > 0 Then
                Dim negocios As New Negocios.DevolucionClientesBU
                Try
                    Dim dtEnviados = grdLecturaAnterior.DataSource
                    If dtRecibidos.Rows.Count = 0 Then dtRecibidos = dtEnviados.Clone
                    Dim row As DataRow = dtEnviados.Rows(filaActual)

                    Dim fila As DataRow = dtRecibidos.NewRow
                    For Each columna As DataColumn In dtEnviados.Columns
                        fila(columna.Caption) = row(columna.Caption)
                    Next
                    dtRecibidos.Rows.Add(fila)
                    dtEnviados.Rows.Remove(row)
                    grdLecturaActual.DataSource = dtRecibidos
                    grdLecturaAnterior.DataSource = dtEnviados
                    FormatoGrid(bgvLecturaActual)
                    txtCodigo.Text = ""
                    txtCodigo.Select()
                    Exit Sub
                Catch ex As Exception
                    Dim ventanaError As New Tools.ErroresForm
                    ventanaError.mensaje = "Error " + ex.Message
                    ventanaError.ShowDialog()
                End Try
            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese observaciones que justifiquen la falta del producto")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ImprimirReporte()
        Dim dsTotalesDeSalidas As New DataSet
        Dim dtTotalesSalida As New DataTable

        Dim Operador As String
        Dim TotalPares As Integer = 0
        Dim Id_Nave As Integer

        Dim Tabla_dataSet_Recuperada As New DataTable

        Id_Nave = cmbNave.SelectedValue

        Me.Cursor = Cursors.WaitCursor

        dtTotalesSalida = negocios.ConsultaReporteSalidas(CInt(txtFolioSalida.Text))

        If dtTotalesSalida.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información.")
            Me.Cursor = Cursors.Default
            Return
        End If

        dsTotalesDeSalidas.Tables.Add(dtTotalesSalida)

        'Recuperar el Nombre del Operador
        Operador = txtOperador.Text

        Dim reportesBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes

        EntidadReporte = reportesBU.LeerReporteporClave("REPORTE_DEVOLUCION_DETALLETALLAS")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
        reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
        reporte("NombreReporte") = "SAY: REPORTE_SALIDA_NAVES_DEVOLUCION.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Recibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
        'reporte("Hora_Salida") = dtTotalesSalida.Rows(0).Item("HoraSalida").ToString
        'reporte("Fecha_Salida") = dtTotalesSalida.Rows(0).Item("FechaSalida")
        reporte("Operador") = Operador
        reporte("FolioSalida") = CInt(txtFolioSalida.Text.ToString)
        reporte("ColaboradorEntrega") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        reporte("TotalPares") = TotalPares

        reporte.Dictionary.Clear()
        reporte.RegData(dsTotalesDeSalidas)
        reporte.Dictionary.Synchronize()

        Me.Cursor = Cursors.Default

        reporte.Show()

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If txtFolioSalida.Text.Trim.Length <= 0 Then
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Ingrese un folio de salida")
            Return
        End If
        ImprimirReporte()
    End Sub

    Private Sub bgvLecturaAnterior_RowStyle(sender As Object, e As RowStyleEventArgs) Handles bgvLecturaAnterior.RowStyle
        If e.RowHandle Mod 2 = 0 Then
            e.Appearance.BackColor = Color.LightSteelBlue
        End If
    End Sub
End Class