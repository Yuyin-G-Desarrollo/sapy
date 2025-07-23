Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ColocacionSemanal_Configuracion_ArticulosForm
    Public IdNaveSay As Integer = 0
    Public NombreNave As String
    Public marcadosActualmente As New List(Of Integer)
    Public accionForm As String
    Public fechaMenor As Date
    Public fechaMayor As Date
    Public fechaDesde As Date
    Public fechaHasta As Date
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Public tabla As New DataTable
    Public Sub disenioGrid()
        With grdListadoArticulos.DisplayLayout
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.CellSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowUpdate= DefaultableBoolean.False
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single

            If accionForm = "Asignar Articulos" Then
                .Bands(0).Columns("Seleccionar").Width = 30
                .Bands(0).Columns("Seleccionar").AllowRowFiltering = DefaultableBoolean.False
                .Bands(0).Columns("Seleccionar").Header.Caption = ""
                .Bands(0).Columns("ProductoEstiloId").Hidden = True
                .Bands(0).Columns("Seleccionar").CellActivation = Activation.AllowEdit
            Else
                .Bands(0).Columns("ccna_naveidsay").Hidden = True
                .Bands(0).Columns(" ").Hidden = True
                .Bands(0).Columns("ccna_productoestiloid").Hidden = True
                .Bands(0).Columns("PrioridadOriginal").Width = 10
                .Bands(0).Columns("ActivoOriginal").Width = 5
                .Bands(0).Columns("PrioridadOriginal").Header.Caption = "Prioridad"
                .Bands(0).Columns("ActivoOriginal").Header.Caption = "Activo"
                .Bands(0).Columns("ccna_prioridad").Hidden = True
                .Bands(0).Columns("ccna_activo").Hidden = True
                .Bands(0).Columns("ccna_siguientefechaasignar").Header.Caption = "Sig. Fecha" & vbCrLf & "Asignar"
                .Bands(0).Columns("ccna_siguientesemanaasignar").Header.Caption = "Sig. Semana" & vbCrLf & "Asignar"
                .Bands(0).Columns("SiguienteFechaAsignarOriginal").Hidden = True
                .Bands(0).Columns("ProgramarDesdeOriginal").Hidden = True
                .Bands(0).Columns("ccna_siguientefechaasignarusuario").Hidden = True
            End If
        End With
    End Sub
    Private Sub consultarArticulosNoAsignadas()
        Dim obj As New Programacion_ArticuloNave_BU
        grdListadoArticulos.DataSource = Nothing
        Try
            Dim dtConsultaFamilias As New DataTable
            dtConsultaFamilias = obj.ObtenerArticulosNoAsignadasPorNave(IdNaveSay)
            If dtConsultaFamilias.Rows.Count > 0 Then
                grdListadoArticulos.DataSource = dtConsultaFamilias
                disenioGrid()
            Else
                objAdvertencia.mensaje = "No existen Articulos para asignar a esta nave."
                objAdvertencia.ShowDialog()
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub llenarTabla()
        chkSeleccionarTodo.Visible = False
        lblNumFiltrados.Text = tabla.Rows.Count
        If tabla.Rows.Count > 0 Then
            grdListadoArticulos.DataSource = Nothing
            grdListadoArticulos.DataSource = tabla
            disenioGrid()
        Else
            objAdvertencia.mensaje = "No se han seleccionado artículos."
            objAdvertencia.ShowDialog()
        End If
        obtenerFechas()
    End Sub
    Private Function generarXML(ByVal idNave As Integer)
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For Each row As UltraGridRow In grdListadoArticulos.Rows
            Dim vNodo As XElement = New XElement("Celda")
            vNodo.Add(New XAttribute("NaveIdSAY", idNave))
            vNodo.Add(New XAttribute("ProductoEstiloId", row.Cells("ccna_productoestiloid").Value))
            vNodo.Add(New XAttribute("Activo", 0))
            vNodo.Add(New XAttribute("Usuario", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            vNodo.Add(New XAttribute("SiguienteFechaAsignar",
                                                 IIf(row.Cells("ccna_siguientefechaasignar").Value Is DBNull.Value,
                                                     "",
                                                     row.Cells("ccna_siguientefechaasignar").Value)))
            vNodo.Add(New XAttribute("ProgramarDesde",
                                                 IIf(row.Cells("Programar Desde").Value Is DBNull.Value,
                                                     "",
                                                     row.Cells("Programar Desde").Value)))
            vNodo.Add(New XAttribute("SiguienteFechaAsignarUsuario",
                                                 IIf(row.Cells("ccna_siguientefechaasignar").Value Is DBNull.Value,
                                                     "",
                                                     row.Cells("ccna_siguientefechaasignar").Value)))
            vXmlCeldasModificadas.Add(vNodo)
        Next
        Return vXmlCeldasModificadas
    End Function
    Private Function validarFecha(ByVal idNave As Integer, ByVal fecha As Date, ByVal tipoFecha As Integer)
        Dim obj As New Programacion_ArticuloNave_BU
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For Each row As UltraGridRow In grdListadoArticulos.Rows
            Dim vNodo As XElement = New XElement("Celda")
            vNodo.Add(New XAttribute("NaveIdSAY", idNave))
            vNodo.Add(New XAttribute("ProductoEstiloId", row.Cells("ccna_productoestiloid").Value))
            vXmlCeldasModificadas.Add(vNodo)
        Next
        If fecha <> New Date Then fecha = Date.Parse(obj.ValidarFecha(vXmlCeldasModificadas.ToString, fecha, tipoFecha).Rows.Item(0).ItemArray(0).ToString())
        Return fecha
    End Function
    Private Sub obtenerFechas()
        For Each row As UltraGridRow In grdListadoArticulos.Rows
            If (fechaDesde = New Date Or fechaHasta = New Date) Then
                If row.Cells("Programar hasta").Value.ToString <> "" And fechaHasta = New Date Then fechaHasta = row.Cells("Programar hasta").Value.ToShortDateString()
                If row.Cells("Programar desde").Value.ToString <> "" And fechaDesde = New Date Then fechaDesde = row.Cells("Programar desde").Value.ToShortDateString()
            Else
                If row.Cells("Programar desde").Text.ToString() <> "" Then
                    If fechaDesde < row.Cells("Programar desde").Value.ToShortDateString() Then fechaDesde = row.Cells("Programar desde").Value.ToShortDateString()
                End If
                If row.Cells("Programar hasta").Text.ToString() <> "" Then
                    If fechaHasta > row.Cells("Programar hasta").Value.ToShortDateString() Then fechaHasta = row.Cells("Programar hasta").Value.ToShortDateString()
                End If
            End If
        Next
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Select Case accionForm
            Case "Asignar Articulos"
                objConfirmar.mensaje = "Se asignarán " & lblNumFiltrados.Text & " articulos a la nave " & NombreNave & ". Este cambio no podrá revertirse ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    Dim contador As Integer = 0
                    Dim Fecha As Date = dtpFechaProgramarDesde.Value.ToShortDateString()
                    Dim SiguienteFechaAsignar As Date = dtpSiguienteFecha.Value.ToShortDateString()
                    Dim UsuarioId As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    Dim IdArticulos As String = ""
                    For Each x In marcadosActualmente
                        If contador = 0 Then
                            IdArticulos = IdArticulos & x
                            contador = contador + 1
                        Else
                            IdArticulos = IdArticulos & "," & x
                        End If
                    Next
                    Dim obj As New Programacion_ArticuloNave_BU
                    Try
                        obj.InsertarArticulosNave(UsuarioId, IdNaveSay, IdArticulos, Fecha, SiguienteFechaAsignar, chkFechaAsignar.Checked)
                        objExito.mensaje = "Datos guardados correctamente."
                        objExito.ShowDialog()
                        Me.DialogResult = DialogResult.OK
                        Me.Dispose()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Me.DialogResult = DialogResult.None
                End If
            Case "Desasignar Articulos"
                objConfirmar.mensaje = "Se desasignaran " & lblNumFiltrados.Text & " articulos a la nave " & NombreNave & ". Este cambio no podrá revertirse ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    Dim Fecha As Date = dtpFechaProgramarHasta.Value.ToShortDateString()
                    Dim vXmlCeldasModificadas As XElement = generarXML(IdNaveSay)
                    Dim obj As New Programacion_ArticuloNave_BU
                    Try
                        obj.DesasignarArticulosNave(vXmlCeldasModificadas.ToString, Fecha)
                        objExito.mensaje = "Datos guardados correctamente."
                        objExito.ShowDialog()
                        Me.DialogResult = DialogResult.OK
                        Me.Dispose()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Me.DialogResult = DialogResult.None
                End If
            Case "Transferir Articulos"
                If cmbNaves.Text <> "" Then
                    objConfirmar.mensaje = "Se transferiran " & lblNumFiltrados.Text & " articulos a nave " & cmbNaves.Text & " de la nave " & NombreNave & ". Este cambio no podrá revertirse ¿Desea continuar?"
                    If objConfirmar.ShowDialog = DialogResult.OK Then
                        Dim FechaHasta As Date = dtpFechaProgramarHastaTransferir.Value.ToShortDateString()
                        Dim FechaDesde As Date = dtpFechaProgramarDesdeTransferir.Value.ToShortDateString()
                        Dim vXmlCeldasModificadas As XElement = generarXML(IdNaveSay)
                        Dim obj As New Programacion_ArticuloNave_BU
                        Try
                            obj.TransferirArticulosNave(cmbNaves.SelectedValue, vXmlCeldasModificadas.ToString, FechaHasta, FechaDesde)
                            objExito.mensaje = "Datos guardados correctamente."
                            objExito.ShowDialog()
                            Me.DialogResult = DialogResult.OK
                            Me.Dispose()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                    Else
                        Me.DialogResult = DialogResult.None
                    End If
                Else
                    objAdvertencia.mensaje = "Debe seleccionar una nave."
                    objAdvertencia.ShowDialog()
                End If
            Case "Editar Articulos"
                objConfirmar.mensaje = "Se editarán " & lblNumFiltrados.Text & " articulos de la nave " & NombreNave & ". Este cambio no podrá revertirse ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    Dim Fecha As Date = dtpFechaProgramarDesde.Value.ToShortDateString()
                    Dim vXmlCeldasModificadas As XElement = generarXML(IdNaveSay)
                    Dim obj As New Programacion_ArticuloNave_BU
                    Try
                        obj.EditarArticulosNave(vXmlCeldasModificadas.ToString, Fecha)
                        objExito.mensaje = "Datos guardados correctamente."
                        objExito.ShowDialog()
                        Me.DialogResult = DialogResult.OK
                        Me.Dispose()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Else
                    Me.DialogResult = DialogResult.None
                End If
        End Select
    End Sub

    Private Sub Programacion_ColocacionSemanal_Configuracion_ArticulosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaProgramarDesde.Value = Date.Now
        If accionForm = "Asignar Articulos" Then
            GroupBox1.Text = "Asignar Articulos"
            lblFecha.Visible = True
            chkFechaAsignar.Visible = True
            dtpSiguienteFecha.Visible = True
            dtpSiguienteFecha.Enabled = False
            Me.Text = "Asignar Artículos"
            lblTitulo.Text = "Asignar Artículos"
            lblAsignar.Text = "Asignar"
            pnlAsignar.Visible = True
            consultarArticulosNoAsignadas()
        ElseIf accionForm = "Desasignar Articulos" Then
            Me.Text = "Desasignar Artículos"
            lblTitulo.Text = "Desasignar Artículos"
            lblAsignar.Text = "Desasignar"
            lblAsignar.Location = New Point(lblAsignar.Location.X - 10, lblAsignar.Location.Y)
            pnlDesasignar.Visible = True
            Panel5.Visible = False
            llenarTabla()
            btnAsignar.Enabled = True
            lblAsignar.Enabled = True

            fechaDesde = validarFecha(IdNaveSay, fechaDesde, 1)

            If fechaDesde <> New Date Then
                'dtpFechaProgramarHasta.Value = fechaDesde
                dtpFechaProgramarHasta.Value = Now
                dtpFechaProgramarHasta.MinDate = fechaDesde
            End If
        ElseIf accionForm = "Transferir Articulos" Then
            Me.Text = "Transferir Artículos"
            lblTitulo.Text = "Transferir Artículos"
            lblAsignar.Text = "Transferir"
            lblAsignar.Location = New Point(lblAsignar.Location.X - 3, lblAsignar.Location.Y)
            pnlTransferir.Visible = True
            Panel5.Visible = False
            lblNave.Text = NombreNave
            llenarTabla()
            btnAsignar.Enabled = True
            lblAsignar.Enabled = True
            fechaDesde = validarFecha(IdNaveSay, fechaDesde, 1)
            If fechaDesde <> New Date Then
                'dtpFechaProgramarHastaTransferir.Value = fechaDesde
                dtpFechaProgramarHastaTransferir.Value = Now
                dtpFechaProgramarHastaTransferir.MinDate = fechaDesde
                'dtpFechaProgramarDesdeTransferir.Value = fechaDesde
                dtpFechaProgramarDesdeTransferir.Value = Now
                dtpFechaProgramarDesdeTransferir.MinDate = fechaDesde
            End If
        ElseIf accionForm = "Editar Articulos" Then
            Me.Text = "Editar Articulos"
            lblTitulo.Text = "Editar Artículos"
            lblAsignar.Text = "Editar"
            chkFechaAsignar.Visible = True
            chkFechaProgramar.Visible = True
            dtpSiguienteFecha.Visible = True
            btnAsignarFecha.Visible = True
            lblAsignar.Location = New Point(lblAsignar.Location.X + 6, lblAsignar.Location.Y)
            pnlAsignar.Visible = True
            lblNave.Text = NombreNave
            llenarTabla()
            btnAsignar.Enabled = True
            lblAsignar.Enabled = True
            fechaHasta = validarFecha(IdNaveSay, fechaHasta, 1)
            If fechaHasta <> New Date Then
                dtpFechaProgramarDesde.Value = fechaHasta
                dtpFechaProgramarDesde.MaxDate = fechaHasta
            End If
        End If
        lblTitulo.Location = New Point((pnlVentas.Width - pnlTitulo.Width - lblTitulo.Width), lblTitulo.Location.Y)
        Dim objBU As New Programacion.Negocios.EtiquetasBU
        Dim DTNAves As DataTable
        DTNAves = objBU.ConsultarNavesProduccion()
        For Each x As DataRow In DTNAves.Rows
            If x.ItemArray(0) = IdNaveSay Then
                DTNAves.Rows.Remove(x)
                Exit For
            End If
        Next
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
        cmbNaves.DataSource = DTNAves
        cmbNaves.DisplayMember = "Nave"
        cmbNaves.ValueMember = "NaveSAYId"
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        marcadosActualmente = New List(Of Integer)
        If chkSeleccionarTodo.Checked Then
            For Each row In grdListadoArticulos.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = True
                lblAsignar.Enabled = True
                btnAsignar.Enabled = True
            Next
        Else
            For Each row As UltraGridRow In grdListadoArticulos.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = False
                lblAsignar.Enabled = False
                btnAsignar.Enabled = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoArticulos.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                marcados += 1
                marcadosActualmente.Add(row.Cells("ProductoEstiloId").Value)
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub grdListadoArticulos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListadoArticulos.ClickCell
        If accionForm = "Asignar Articulos" Then
            If Not Me.grdListadoArticulos.ActiveRow.IsDataRow Then Return

            If IsNothing(grdListadoArticulos.ActiveRow) Then Return
            If grdListadoArticulos.ActiveRow.Cells("Seleccionar").Value Then
                grdListadoArticulos.ActiveRow.Cells("Seleccionar").Value = False
                marcadosActualmente.Remove(grdListadoArticulos.ActiveRow.Cells("ProductoEstiloId").Value)
            Else
                marcadosActualmente.Add(grdListadoArticulos.ActiveRow.Cells("ProductoEstiloId").Value)
                grdListadoArticulos.ActiveRow.Cells("Seleccionar").Value = True
            End If


            Dim marcados As Integer
            For Each row As UltraGridRow In grdListadoArticulos.Rows
                If CBool(row.Cells("Seleccionar").Value) Then
                    marcados += 1
                End If
            Next
            lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
            If (lblNumFiltrados.Text <> "0") Then
                btnAsignar.Enabled = True
                lblAsignar.Enabled = True
            Else
                btnAsignar.Enabled = False
                lblAsignar.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnAsignarFecha_Click(sender As Object, e As EventArgs) Handles btnAsignarFecha.Click
        Me.DialogResult = DialogResult.None
        If chkFechaAsignar.Checked Or chkFechaProgramar.Checked Then
            Dim fechaAsinar As Date = dtpSiguienteFecha.Value.ToShortDateString()
            Dim fechaProgramar As Date = dtpFechaProgramarDesde.Value.ToShortDateString()

            If grdListadoArticulos.Rows.Count > 0 Then
                For Each row As UltraGridRow In grdListadoArticulos.Rows
                    If chkFechaAsignar.Checked Then
                        row.Cells("ccna_siguientefechaasignar").Value = fechaAsinar
                        row.Cells("ccna_siguientefechaasignarusuario").Value = fechaAsinar
                        row.Cells("ccna_siguientesemanaasignar").Value = DatePart("ww", fechaAsinar)
                        row.Cells("ccna_siguientefechaasignar").Activated = True
                    End If
                    If chkFechaProgramar.Checked Then
                        row.Cells("Programar Desde").Value = fechaProgramar
                        row.Cells("Programar Desde").Activated = True
                    End If
                    Dim fechaOriginalAsignar As String = row.Cells("ccna_siguientefechaasignar").Value.ToString
                    Dim fechaModificadaAsignar As String = row.Cells("SiguienteFechaAsignarOriginal").Value.ToString
                    Dim fechaOriginalProgramar As String = row.Cells("ProgramarDesdeOriginal").Value.ToString
                    Dim fechaModificadaProgramar As String = row.Cells("Programar Desde").Value.ToString
                    If fechaOriginalProgramar <> fechaModificadaProgramar Then
                        row.Cells("Programar Desde").Appearance.ForeColor = Color.DarkViolet
                    Else
                        row.Cells("Programar Desde").Appearance.ForeColor = Color.Black
                    End If
                    If fechaOriginalAsignar <> fechaModificadaAsignar Then
                        row.Cells("ccna_siguientefechaasignar").Appearance.ForeColor = Color.DarkViolet
                        row.Cells("ccna_siguientesemanaasignar").Appearance.ForeColor = Color.DarkViolet
                    Else
                        row.Cells("ccna_siguientefechaasignar").Appearance.ForeColor = Color.Black
                        row.Cells("ccna_siguientesemanaasignar").Appearance.ForeColor = Color.Black
                    End If
                Next
            Else
                objAdvertencia.mensaje = "No hay filas seleccionadas."
                objAdvertencia.ShowDialog()
            End If
        Else
            objAdvertencia.mensaje = "No se ha seleccionado ninguna fecha."
            objAdvertencia.ShowDialog()
        End If
    End Sub
    Private Sub grdListadoArticulos_AfterRowUpdate(sender As Object, e As RowEventArgs) Handles grdListadoArticulos.AfterRowUpdate

    End Sub

    Private Sub chkFechaAsignar_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaAsignar.CheckedChanged
        If chkFechaAsignar.Checked Then
            dtpSiguienteFecha.Enabled = True
        Else
            dtpSiguienteFecha.Enabled = False
        End If
    End Sub
End Class