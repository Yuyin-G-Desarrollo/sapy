Imports Entidades
Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Net.Mail
Imports Tools
Imports System.ComponentModel
Imports Stimulsoft.Report
Imports System.Threading

Public Class ConfirmBorradoresForm
#Region "Propiedades"
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Dim idProg As Integer = 0
    Dim idNave As Integer = 0
    Dim fechaPrograma As Date
#End Region


#Region "Eventos"
    Private Sub ConfirmBorradoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarcomboNaves()
        Me.WindowState = FormWindowState.Maximized
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("BORRADOR", "PROD_BORRADOR_ACTUALIZARLOTES") Then
            btnActualizarLotes.Visible = True
            lblTextoActualizarLotes.Visible = True
        Else
            btnActualizarLotes.Visible = False
            lblTextoActualizarLotes.Visible = False
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        Try
            If Not String.IsNullOrEmpty(cmbNave.Text) Then
                MostrarEspere(Me)
                CargarBorrador()
            Else
                MostrarMensaje(Mensajes.Warning, "Seleccione una nave")
            End If
        Catch ex As Exception
            MostrarMensaje(Mensajes.Fault, ex.Message)
        Finally
            TerminarEspere(Me)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidarEstatus() Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.mensaje = "Algunos artículos no se encuentran autorizados. ¿Desea continuar?"
            If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                GuardarBorrador()
                Guardar()
            End If
        Else
            GuardarBorrador()
            Guardar()
        End If


    End Sub

    Private Sub grdComprobantes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdBorrador.InitializeRow
        If e.Row.Cells("MotivoRechazo").Value.ToString.Trim.Length > 0 Then
            e.Row.Cells(" ").Appearance.BackColor = Color.DarkOrange
        Else
            e.Row.Cells(" ").Appearance.BackColor = Color.YellowGreen
        End If

        If e.Row.Cells("Autorizado").Value = 0 Then
            e.Row.Cells("Estatus").Appearance.ForeColor = Color.Red
        End If

        If e.Row.Cells("NoCompletar").Value.ToString.Trim.Length > 0 Then
            e.Row.Cells("Cliente").Appearance.BackColor = Color.Salmon
        End If

        'If GetStatusPrograma() <> "Revision" Then
        '    e.Row.Cells("Cortador_Piel").Activation = Activation.NoEdit
        '    e.Row.Cells("Cortador_Forro").Activation = Activation.NoEdit
        '    e.Row.Cells("Cortador_PielSint").Activation = Activation.NoEdit
        '    e.Row.Cells("Cortador_ForroSint").Activation = Activation.NoEdit
        'End If

        Try
            If e.Row.Cells("Cortador_Piel").Value = 0 Then
                e.Row.Cells("Cortador_Piel").Appearance.BackColor = Color.DarkGray
            End If
        Catch ex As Exception
            If IsDBNull(e.Row.Cells("Cortador_Piel").Value) Then
                e.Row.Cells("Cortador_Piel").Appearance.BackColor = Color.DarkGray
            End If
        End Try

        Try
            If e.Row.Cells("Cortador_PielSint").Value = 0 Then
                e.Row.Cells("Cortador_PielSint").Appearance.BackColor = Color.DarkGray
            End If
        Catch ex As Exception
            If IsDBNull(e.Row.Cells("Cortador_PielSint").Value) Then
                e.Row.Cells("Cortador_PielSint").Appearance.BackColor = Color.DarkGray
            End If
        End Try

        Try
            If e.Row.Cells("Cortador_Forro").Value = 0 Then
                e.Row.Cells("Cortador_Forro").Appearance.BackColor = Color.DarkGray
            End If
        Catch ex As Exception
            If IsDBNull(e.Row.Cells("Cortador_Forro").Value) Then
                e.Row.Cells("Cortador_Forro").Appearance.BackColor = Color.DarkGray
            End If
        End Try

        Try
            If e.Row.Cells("Cortador_ForroSint").Value = 0 Then
                e.Row.Cells("Cortador_ForroSint").Appearance.BackColor = Color.DarkGray
            End If
        Catch ex As Exception
            If IsDBNull(e.Row.Cells("Cortador_ForroSint").Value) Then
                e.Row.Cells("Cortador_ForroSint").Appearance.BackColor = Color.DarkGray
            End If
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If grdBorrador.Rows.Count > 0 Then
            exportarExcel()
        End If
    End Sub

    Private Sub grdBorrador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdBorrador.KeyPress
        If grdBorrador.Rows.Count > 0 Then
            Try
                If Not grdBorrador.ActiveCell.IsFilterRowCell Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdBorrador.DataSource = Nothing
        cmbPiel.DataSource = Nothing
        cmbForro.DataSource = Nothing
        lblEstatus.Text = "-"
        idProg = 0
        idNave = 0
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            grdBorrador.DataSource = Nothing
            cmbNave.SelectedIndex = 0
            lblEstatus.Text = "-"
            dtpFechaInicio.Value = Date.Now
            idProg = 0
            idNave = 0
            cmbPiel.DataSource = Nothing
            cmbForro.DataSource = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Private Sub chkval_CheckedChanged(sender As Object, e As EventArgs) Handles chkval.CheckedChanged
        For Each row As UltraGridRow In grdBorrador.Rows
            row.Cells("seleccion").Value = False
        Next
        If chkval.Checked Then
            For Each row As UltraGridRow In grdBorrador.Rows.GetFilteredInNonGroupByRows
                row.Cells("seleccion").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdBorrador.Rows.GetFilteredInNonGroupByRows
                row.Cells("seleccion").Value = False
            Next
        End If

        Dim datos As DataTable


    End Sub

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        If GetStatusPrograma() = "Revision" Then
            If idProg > 0 Then
                objConfirmacion.mensaje = "¿Quiere rechazar el borrador?"
                If objConfirmacion.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                    Dim motivoform As New MotivoRechazoForm
                    Dim motivoRechazo As String = ""
                    motivoform.ShowDialog()

                    If motivoform.cancelado = False Then
                        Dim obj As New ConfirmacionBorradorBU
                        Dim datosNave As New DataTable
                        Dim nombreNave As String = ""
                        datosNave = obj.getDatosNave(idNave)
                        For Each row As DataRow In datosNave.Rows
                            nombreNave = row("Nave")
                        Next
                        motivoRechazo = motivoform.motivoRechazo.ToUpper
                        Dim dprograma As New DataTable
                        Dim rechazo As String = "" 'Bandera que verifica si se puede rechazar el programa.
                        dprograma = obj.GetEstatusRechazoPrograma(idNave, idProg)
                        If dprograma.Rows.Count > 0 Then
                            rechazo = dprograma.Rows(0).Item(0)
                            If rechazo = "1" Then
                                Try
                                    Me.Cursor = Cursors.WaitCursor
                                    obj.RechazarBorrador(idNave, idProg, motivoRechazo)
                                    'EnviarCorreoArchivo(bodycorreoRechazado(motivoRechazo), "Rechazo del programa " & Format(fechaPrograma.Date, "dd/MM/AAAA"), getDestinatarios(2))
                                    EnviarCorreoArchivo(bodycorreoRechazado(motivoRechazo), nombreNave & " Rechazo del programa " & Format(fechaPrograma.Date, "dd/MM/yyyy - SAY"), "cdesarrollo.ti@grupoyuyin.com.mx,analista.ti@grupoyuyin.com.mx")
                                    objExito.mensaje = "Borrador rechazado."
                                    objExito.ShowDialog()
                                    Me.Cursor = Cursors.Default
                                    Try
                                        If cmbNave.Text <> "" Then
                                            lblNave.ForeColor = Drawing.Color.Black
                                            Me.Cursor = Cursors.WaitCursor
                                            CargarBorrador()
                                            Me.Cursor = Cursors.Default
                                        Else
                                            objMensaje.mensaje = "Seleccione una nave"
                                            objMensaje.ShowDialog()
                                            lblNave.ForeColor = Drawing.Color.Red
                                        End If
                                    Catch ex As Exception
                                        Me.Cursor = Cursors.Default
                                    End Try
                                Catch ex As Exception
                                    Me.Cursor = Cursors.Default
                                    objAdvertencia.mensaje = "Surgió algo inesperado intente de nuevo o más tarde."
                                    objAdvertencia.ShowDialog()
                                End Try
                            Else
                                objAdvertencia.mensaje = "No tiene Autorización para Rechazar el programa. Favor de comunicarse a PPCP para solicitar el Permiso."
                                objAdvertencia.ShowDialog()
                            End If
                        Else
                            objAdvertencia.mensaje = "No existe información."
                            objAdvertencia.ShowDialog()
                        End If
                    End If
                End If
            End If
        Else
            Me.Cursor = Cursors.Default
            objMensaje.mensaje = "Solo se pueden rechazar borradores en estatus de 'Revision'."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim obj As New ConfirmacionBorradorBU
        Dim datosNave As New DataTable
        Dim nombreNave As String = ""

        If Not String.IsNullOrEmpty(cmbNave.Text) Then
            datosNave = obj.getDatosNave(idNave)

            For Each row As DataRow In datosNave.Rows
                nombreNave = row("Nave")
            Next

            'If validarBorrador() Then

            If idProg > 0 Then
                If GetStatusPrograma() = "Revision" Then

                    If ValidarEstatus() Then
                        Dim objAlerta As New Tools.AdvertenciaForm
                        objConfirmacion.mensaje = "No se pueden confirmar borradores con artículos no autorizados, favor de verificar."
                        objConfirmacion.ShowDialog()
                    Else
                        Me.Cursor = Cursors.WaitCursor
                        obj.confirmarBorrador(idProg, idNave)
                        Guardar()
                        ''EnviarCorreoArchivo(bodycorreoConfirmar, "Confirmación del programa " & Format(fechaPrograma.Date, "dd/MM/AAAA"), getDestinatarios(1))
                        'EnviarCorreoArchivo(bodycorreoConfirmar, nombreNave & " Confirmación del programa " & Format(fechaPrograma.Date, "dd/MM/yyyy - SAY"), "cdesarrollo.ti@grupoyuyin.com.mx,analista.ti@grupoyuyin.com.mx")
                        Try
                            If cmbNave.Text <> "" Then
                                lblNave.ForeColor = Drawing.Color.Black
                                CargarBorrador()
                            End If
                        Catch ex As Exception
                            Me.Cursor = Cursors.Default
                        End Try
                        Me.Cursor = Cursors.Default
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    objMensaje.mensaje = "Solo se pueden confirmar borradores en estatus de 'Revision'."
                    objMensaje.ShowDialog()
                End If
            End If
            'End If
        Else
            MostrarMensaje(Mensajes.Warning, "Seleccione una nave")
        End If


    End Sub

    Private Sub cmbPielS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPielS.SelectedIndexChanged
        'Try
        '    If lblEstatus.Text = "Revision" Then
        '        'If cmbPielS.SelectedValue > 0 Then
        '        For Each row As UltraGridRow In grdBorrador.Rows
        '            If CBool(row.Cells("seleccion").Value) Then
        '                row.Cells("Cortador_PielSint").Value = cmbPielS.SelectedValue
        '            End If
        '        Next
        '        'End If
        '    End If

        'Catch ex As Exception
        'End Try
        Try
            'If GetStatusPrograma() = "Revision" Then
            AsignarCortadorGrid(Enumerados.TipoCortador.PIEL_SINTETICO)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbForroS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbForroS.SelectedIndexChanged
        'Try
        '    If lblEstatus.Text = "Revision" Then
        '        'If cmbForroS.SelectedValue > 0 Then
        '        For Each row As UltraGridRow In grdBorrador.Rows
        '            If CBool(row.Cells("seleccion").Value) Then
        '                row.Cells("Cortador_ForroSint").Value = cmbForroS.SelectedValue
        '            End If
        '        Next
        '        'End If
        '    End If

        'Catch ex As Exception
        'End Try
        Try
            'If GetStatusPrograma() = "Revision" Then
            AsignarCortadorGrid(Enumerados.TipoCortador.FORRO_SINTETICO)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPiel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPiel.SelectedIndexChanged
        'Try

        '    If lblEstatus.Text = "Revision" Then
        '        'If cmbPiel.SelectedValue > 0 Then
        '        For Each row As UltraGridRow In grdBorrador.Rows
        '            If CBool(row.Cells("seleccion").Value) Then
        '                row.Cells("Cortador_Piel").Value = cmbPiel.SelectedValue
        '            End If
        '        Next
        '        ' End If
        '    End If

        'Catch ex As Exception
        'End Try
        Try
            'If GetStatusPrograma() = "Revision" Then
            AsignarCortadorGrid(Enumerados.TipoCortador.PIEL)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbForro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbForro.SelectedIndexChanged
        'Try
        '    If lblEstatus.Text = "Revision" Then
        '        'If cmbForro.SelectedValue > 0 Then
        '        For Each row As UltraGridRow In grdBorrador.Rows
        '            If CBool(row.Cells("seleccion").Value) Then
        '                row.Cells("Cortador_Forro").Value = cmbForro.SelectedValue
        '            End If
        '        Next
        '        'End If
        '    End If

        'Catch ex As Exception
        'End Try
        Try
            'If GetStatusPrograma() = "Revision" Then
            AsignarCortadorGrid(Enumerados.TipoCortador.FORRO)
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdBorrador_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdBorrador.AfterCellUpdate
        Try
            If Not grdBorrador.ActiveCell.IsFilterRowCell Then
                If e.Cell.Text.Trim = "" Then
                    e.Cell.Value = 0
                End If
                Dim i As Integer = 0
                Do
                    If grdBorrador.Rows(i).Cells("Cortador_PielSint").Value = 0 Then
                        grdBorrador.Rows(i).Cells("Cortador_PielSint").Appearance.BackColor = Color.DarkGray
                    Else
                        grdBorrador.Rows(i).Cells("Cortador_PielSint").Appearance.BackColor = grdBorrador.Rows(i).Cells("NoLote").Appearance.BackColor
                    End If
                    If grdBorrador.Rows(i).Cells("Cortador_Piel").Value = 0 Then
                        grdBorrador.Rows(i).Cells("Cortador_Piel").Appearance.BackColor = Color.DarkGray
                    Else
                        grdBorrador.Rows(i).Cells("Cortador_Piel").Appearance.BackColor = grdBorrador.Rows(i).Cells("NoLote").Appearance.BackColor
                    End If
                    If grdBorrador.Rows(i).Cells("Cortador_Forro").Value = 0 Then
                        grdBorrador.Rows(i).Cells("Cortador_Forro").Appearance.BackColor = Color.DarkGray
                    Else
                        grdBorrador.Rows(i).Cells("Cortador_Forro").Appearance.BackColor = grdBorrador.Rows(i).Cells("NoLote").Appearance.BackColor
                    End If
                    If grdBorrador.Rows(i).Cells("Cortador_ForroSint").Value = 0 Then
                        grdBorrador.Rows(i).Cells("Cortador_ForroSint").Appearance.BackColor = Color.DarkGray
                    Else
                        grdBorrador.Rows(i).Cells("Cortador_ForroSint").Appearance.BackColor = grdBorrador.Rows(i).Cells("NoLote").Appearance.BackColor
                    End If
                    i = i + 1
                Loop While i < grdBorrador.Rows.Count
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Metodos Privados"

    Private Function GetStatusPrograma() As String
        Return lblEstatus.Text
    End Function

    Private Function estaSeleccionado(ByVal row As UltraGridRow) As Boolean
        'Return CBool(row.Cells("seleccion").Value)
        Return CBool(row.GetCellValue("seleccion"))
    End Function

    ''' <summary>
    ''' Asigna el cortador en la columna correspondiente
    ''' </summary>
    ''' <param name="tipoCortador">Tipo de cortador a asignar</param>
    ''' <remarks></remarks>
    Private Sub AsignarCortadorGrid(ByVal tipoCortador As Enumerados.TipoCortador)
        For Each row As UltraGridRow In grdBorrador.Rows
            If estaSeleccionado(row) Then
                Select Case tipoCortador
                    Case Enumerados.TipoCortador.PIEL
                        row.Cells("Cortador_Piel").Value = cmbPiel.SelectedValue
                    Case Enumerados.TipoCortador.PIEL_SINTETICO
                        row.Cells("Cortador_PielSint").Value = cmbPielS.SelectedValue
                    Case Enumerados.TipoCortador.FORRO
                        row.Cells("Cortador_Forro").Value = cmbForro.SelectedValue
                    Case Enumerados.TipoCortador.FORRO_SINTETICO
                        row.Cells("Cortador_ForroSint").Value = cmbForroS.SelectedValue
                End Select
            End If
        Next
    End Sub

    Private Sub LlenarcomboNaves()
        'cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
        'Referenciando a Tools
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub
#End Region

#Region "Metodos Públicos"

#End Region

    ''' <summary>
    ''' Obtiene el Identificador de la nave del Sicy apartir del identicador de la nave Say
    ''' </summary>
    ''' <param name="idNaveSay">Identificador de la nave de Say</param>
    ''' <returns>Identificador de la nave en Sicy</returns>
    ''' <remarks></remarks>
    Public Function getIdNaveSicy(ByVal idNaveSay As Integer) As Integer
        Dim obj As New ConfirmacionBorradorBU
        Dim idSicy = obj.ConsultarNaveSicy(idNaveSay)
        Return idSicy.Rows(0).Item(0)
    End Function

    Public Sub CargarBorrador()
        Dim obj As New ConfirmacionBorradorBU
        Dim borrador As New DataTable
        Dim idprograma As New DataTable
        Dim tmp As New DataTable
        Dim tmp2 As New DataTable
        Dim lotesList As New List(Of Integer)
        Dim totalLotes As Integer = 0
        Dim totalPares As Integer = 0

        Dim idNaveSicy = getIdNaveSicy(cmbNave.SelectedValue)
        fechaPrograma = dtpFechaInicio.Value.Date
        idprograma = obj.GetIdPrograma(idNaveSicy, dtpFechaInicio.Value.Date)

        If idprograma.Rows.Count > 0 Then
            borrador = obj.getBorrador(idNaveSicy, idprograma.Rows(0).Item(0))
            For Each row As DataRow In borrador.Rows
                totalPares += row("Pares")
                If Not lotesList.Contains(row("NoLote")) Then
                    lotesList.Add(row("NoLote"))
                    totalLotes += 1
                End If
            Next

            lblLotesText.Text = Format(totalLotes, "##,##0")
            lblParesText.Text = Format(totalPares, "##,##0")

            For Each row As DataRow In borrador.Rows
                If row("Concentrado") = 0 Then 'No es concentrado
                    tmp = obj.getDatosCliente(row("IdPrograma"), row("IdNave"), row("IdPedido"), row("idPartida"))
                    For Each row2 As DataRow In tmp.Rows
                        tmp2 = obj.verificarNoCompletarLotesCliente(row2("pltIdCliente"))
                        If tmp2.Rows.Count > 0 Then
                            row("NoCompletar") = "NO"
                        End If
                    Next
                Else
                    tmp = obj.getDatosConcentrado(row("IdPrograma"), row("IdNave"), row("Concentrado"))
                    For Each row2 As DataRow In tmp.Rows
                        tmp2 = obj.verificarNoCompletarLotesCliente(row2("pltIdCliente"))
                        If tmp2.Rows.Count > 0 Then
                            row("NoCompletar") = "NO"
                        End If
                    Next
                End If
            Next

            lblEstatus.Text = idprograma.Rows(0).Item(3)
            idProg = idprograma.Rows(0).Item(0)
            idNave = idprograma.Rows(0).Item(4)
            lblFechaConfirmacion.Text = idprograma.Rows(0).Item(5).ToString
            lblFechaloteo.Text = idprograma.Rows(0).Item(6).ToString
            grdBorrador.DataSource = Nothing
            grdBorrador.DataSource = borrador
            disenioGrid()
        Else
            objMensaje.mensaje = "No hay programa registrado para la nave o fecha seleccionada"
            objMensaje.ShowDialog()
            lblEstatus.Text = "-"
            cmbForro.DataSource = Nothing
            cmbPiel.DataSource = Nothing
            grdBorrador.DataSource = Nothing
        End If

    End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdBorrador.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        Dim contador = 0

        With grdBorrador.DisplayLayout.Bands(0)

            .Columns("Imagen").Hidden = True
            .Columns("Total").Hidden = True
            .Columns("NoCompletar").Hidden = True
            .Columns("Compl").Hidden = True
            .Columns("IdTalla").Hidden = True
            .Columns("Concentrado").Hidden = True
            .Columns("IdPrograma").Hidden = True
            .Columns("IdNave").Hidden = True
            .Columns("IdPedido").Hidden = True
            .Columns("IdPartida").Hidden = True
            .Columns("IdLote").Hidden = True
            .Columns("MotivoRechazo").Hidden = True
            .Columns("Autorizado").Hidden = True

            .Columns("No").CellActivation = Activation.NoEdit
            .Columns(" ").CellActivation = Activation.NoEdit
            .Columns("Imagen").CellActivation = Activation.NoEdit
            .Columns("IdCodigo").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("Cliente").Header.Caption = "Cliente"


            .Columns("IdModelo").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Talla").CellActivation = Activation.NoEdit
            .Columns("Pares").CellActivation = Activation.NoEdit
            .Columns("Compl").CellActivation = Activation.NoEdit
            .Columns("Total").CellActivation = Activation.NoEdit
            .Columns("Concentrado").CellActivation = Activation.NoEdit
            .Columns("IdTalla").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("IdPrograma").CellActivation = Activation.NoEdit
            .Columns("IdNave").CellActivation = Activation.NoEdit
            .Columns("IdPedido").CellActivation = Activation.NoEdit
            .Columns("IdPartida").CellActivation = Activation.NoEdit
            .Columns("IdLote").CellActivation = Activation.NoEdit
            .Columns("MotivoRechazo").CellActivation = Activation.NoEdit
            .Columns("NoLote").CellActivation = Activation.NoEdit

            .Columns(" ").Width = 10
            .Columns("No").Hidden = True
            .Columns("Imagen").Width = 40
            .Columns("IdCodigo").Width = 60
            .Columns("Coleccion").Width = 60
            .Columns("IdModelo").Width = 30
            .Columns("Color").Width = 100
            .Columns("Talla").Width = 30
            .Columns("Pares").Width = 45
            .Columns("Compl").Width = 40
            .Columns("Total").Width = 50
            .Columns("Cortador_Piel").Width = 70
            .Columns("Cortador_Forro").Width = 70
            .Columns("Cortador_PielSint").Width = 70
            .Columns("Cortador_ForroSint").Width = 70
            .Columns("Concentrado").Width = 60
            .Columns("IdTalla").Width = 30
            .Columns("Cliente").Width = 200
            .Columns("IdPrograma").Width = 35
            .Columns("IdNave").Width = 30
            .Columns("IdPedido").Width = 30
            .Columns("IdPartida").Width = 30
            .Columns("IdLote").Width = 20
            .Columns("MotivoRechazo").Width = 100
            .Columns("NoLote").Width = 20

            .Columns("No").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Concentrado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdCodigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdModelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Talla").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdTalla").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdPrograma").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdNave").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdPedido").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdPartida").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdLote").CellAppearance.TextHAlign = HAlign.Right
            .Columns("NoLote").CellAppearance.TextHAlign = HAlign.Right

            .Columns("IdCodigo").Header.Caption = "Código"
            .Columns("IdNave").Header.Caption = "Nave"
            .Columns("IdModelo").Header.Caption = "Modelo"
            .Columns("Talla").Header.Caption = "Corrida"
            .Columns("IdPrograma").Header.Caption = "Programa"
            .Columns("IdPedido").Header.Caption = "Pedido"
            .Columns("IdPartida").Header.Caption = "Partida"
            .Columns("IdLote").Header.Caption = "idLote"
            .Columns("NoLote").Header.Caption = "Lote"
            .Columns("MotivoRechazo").Header.Caption = "Motivo de" & vbCrLf & "Rechazo"
            .Columns("Cortador_Piel").Header.Caption = "Cortador" & vbCrLf & "Piel"
            .Columns("Cortador_Forro").Header.Caption = "Cortador" & vbCrLf & "Forro"
            .Columns("Cortador_ForroSint").Header.Caption = "Cortador" & vbCrLf & "Forro Sint"
            .Columns("Cortador_PielSint").Header.Caption = "Cortador" & vbCrLf & "Piel Sint"

            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Seleccion").Width = 2


            Dim listaCortadoresPiel, listaCortadoresForro As New ValueList
            Dim tablaCortadoresPiel, tablaCortadoresForro As New DataTable
            Dim listaCortadoresPielSint, listaCortadoresForroSint As New ValueList
            Dim tablaCortadoresPielSint, tablaCortadoresForroSint As New DataTable
            Dim obj As New ConfirmacionBorradorBU

            Dim idNaveSay = cmbNave.SelectedValue
            tablaCortadoresPiel = obj.getCortadores(idNaveSay, Enumerados.TipoCortador.PIEL)
            tablaCortadoresForro = obj.getCortadores(idNaveSay, Enumerados.TipoCortador.FORRO)
            tablaCortadoresPielSint = obj.getCortadores(idNaveSay, Enumerados.TipoCortador.PIEL_SINTETICO)
            tablaCortadoresForroSint = obj.getCortadores(idNaveSay, Enumerados.TipoCortador.FORRO_SINTETICO)


            cmbPiel.DataSource = tablaCortadoresPiel
            cmbPiel.DisplayMember = "codr_nombrecorto"
            cmbPiel.ValueMember = "copf_cortadorpielforroid"
            cmbForro.DataSource = tablaCortadoresForro
            cmbForro.DisplayMember = "codr_nombrecorto"
            cmbForro.ValueMember = "copf_cortadorpielforroid"
            cmbForroS.DataSource = tablaCortadoresForroSint
            cmbForroS.DisplayMember = "codr_nombrecorto"
            cmbForroS.ValueMember = "copf_cortadorpielforroid"
            cmbPielS.DataSource = tablaCortadoresPielSint
            cmbPielS.DisplayMember = "codr_nombrecorto"
            cmbPielS.ValueMember = "copf_cortadorpielforroid"

            For Each rowDt As DataRow In tablaCortadoresPiel.Rows
                If tablaCortadoresPiel.Rows.Count > 0 Then
                    listaCortadoresPiel.ValueListItems.Add(rowDt.Item("copf_cortadorpielforroid"), rowDt.Item("codr_nombrecorto").ToString.ToUpper.Trim)
                End If
            Next
            For Each rowDt As DataRow In tablaCortadoresForro.Rows
                If tablaCortadoresForro.Rows.Count > 0 Then
                    listaCortadoresForro.ValueListItems.Add(rowDt.Item("copf_cortadorpielforroid"), rowDt.Item("codr_nombrecorto").ToString.ToUpper.Trim)
                End If
            Next
            For Each rowDt As DataRow In tablaCortadoresForroSint.Rows
                If tablaCortadoresForroSint.Rows.Count > 0 Then
                    listaCortadoresForroSint.ValueListItems.Add(rowDt.Item("copf_cortadorpielforroid"), rowDt.Item("codr_nombrecorto").ToString.ToUpper.Trim)
                End If
            Next
            For Each rowDt As DataRow In tablaCortadoresPielSint.Rows
                If tablaCortadoresPielSint.Rows.Count > 0 Then
                    listaCortadoresPielSint.ValueListItems.Add(rowDt.Item("copf_cortadorpielforroid"), rowDt.Item("codr_nombrecorto").ToString.ToUpper.Trim)
                End If
            Next



            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_Piel").Style = UltraWinGrid.ColumnStyle.DropDown
            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_Piel").ValueList = listaCortadoresPiel


            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_Forro").Style = UltraWinGrid.ColumnStyle.DropDown
            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_Forro").ValueList = listaCortadoresForro


            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_ForroSint").Style = UltraWinGrid.ColumnStyle.DropDown
            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_ForroSint").ValueList = listaCortadoresForroSint

            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_PielSint").Style = UltraWinGrid.ColumnStyle.DropDown
            grdBorrador.DisplayLayout.Bands(0).Columns("Cortador_PielSint").ValueList = listaCortadoresPielSint

        End With

        grdBorrador.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdBorrador.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        For value = 0 To grdBorrador.Rows.Count - 1
            contador = contador + 1
            grdBorrador.Rows(value).Cells("No").Value = contador
        Next
    End Sub


    Private Sub LlenarCortadoresPiel()

    End Sub

    Private Sub Guardar()
        'If GetStatusPrograma() = "Revision" Then
        MostrarEspere(Me)
        'GuardarBorrador()
        Try
            If estaSeleccionadaNave() Then
                CargarBorrador()
            Else
                MostrarMensaje(Mensajes.Warning, "Seleccione una nave")
            End If
        Catch ex As Exception

        Finally
            TerminarEspere(Me)
        End Try
        'Else
        '    MostrarMensaje(Mensajes.Warning, "Solo puede guardar cambios cuando el estatus del borrardor sea en 'Revisión'.")
        'End If
    End Sub

    Private Function estaSeleccionadaNave() As Boolean
        Return Not (String.IsNullOrEmpty(cmbNave.Text))
    End Function

    'Private Sub GuardarBorrador()
    '    Dim datos As New DataTable
    '    Dim obj As New ConfirmacionBorradorBU
    '    datos = grdBorrador.DataSource
    '    Dim idcorPiel As Integer = 0
    '    Dim idCorForro As Integer = 0
    '    Dim idcorPielSint As Integer = 0
    '    Dim idCorForroSint As Integer = 0
    '    Dim idcorPielN As String = ""
    '    Dim idCorForroN As String = ""
    '    Dim idcorPielSintN As String = ""
    '    Dim idCorForroSintN As String = ""
    '    Try
    '        For Each row As DataRow In datos.Rows
    '            idcorPiel = 0
    '            idCorForro = 0
    '            If row("Concentrado") > 0 Then 'Es Concentrado
    '                Try
    '                    idcorPiel = row("Cortador_Piel")
    '                    cmbPiel.SelectedValue = idcorPiel
    '                    idcorPielN = cmbPiel.Text

    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    idCorForro = row("Cortador_Forro")
    '                    cmbForro.SelectedValue = idCorForro
    '                    idCorForroN = cmbForro.Text
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    idcorPielSint = row("Cortador_PielSint")
    '                    cmbPielS.SelectedValue = idcorPielSint
    '                    idcorPielSintN = cmbPielS.Text
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    idCorForroSint = row("Cortador_ForroSint")
    '                    cmbForroS.SelectedValue = idCorForroSint
    '                    idCorForroSintN = cmbForroS.Text
    '                Catch ex As Exception
    '                End Try
    '                obj.guardarCortadores(1, row("IdNave"), row("IdPrograma"), row("IdPedido"), row("IdPartida"), row("IdLote"), idcorPiel, idCorForro, row("Concentrado"), idcorPielSint, idCorForroSint, idcorPielN, idCorForroN, idcorPielSintN, idCorForroSintN)
    '            Else 'No es concentrado
    '                Try
    '                    idcorPiel = row("Cortador_Piel")
    '                    cmbPiel.SelectedValue = idcorPiel
    '                    idcorPielN = cmbPiel.Text

    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    idCorForro = row("Cortador_Forro")
    '                    cmbForro.SelectedValue = idCorForro
    '                    idCorForroN = cmbForro.Text
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    idcorPielSint = row("Cortador_PielSint")
    '                    cmbPielS.SelectedValue = idcorPielSint
    '                    idcorPielSintN = cmbPielS.Text
    '                Catch ex As Exception
    '                End Try
    '                Try
    '                    idCorForroSint = row("Cortador_ForroSint")
    '                    cmbForroS.SelectedValue = idCorForroSint
    '                    idCorForroSintN = cmbForroS.Text
    '                Catch ex As Exception
    '                End Try
    '                obj.guardarCortadores(0, row("IdNave"), row("IdPrograma"), row("IdPedido"), row("IdPartida"), row("IdLote"), idcorPiel, idCorForro, row("Concentrado"), idcorPielSint, idCorForroSint, idcorPielN, idCorForroN, idcorPielSintN, idCorForroSintN)
    '            End If
    '        Next
    '        objExito.mensaje = "Información guardada."
    '        objExito.ShowDialog()
    '    Catch ex As Exception
    '        objMensaje.mensaje = "Surgió algo inesperado: " & ex.Message
    '        objMensaje.ShowDialog()
    '    End Try

    'End Sub

    Private Sub GuardarBorrador()
        Dim datos As New DataTable
        Dim obj As New ConfirmacionBorradorBU

        Dim idcorPiel As Integer = 0
        Dim idCorForro As Integer = 0
        Dim idcorPielSint As Integer = 0
        Dim idCorForroSint As Integer = 0
        Dim idcorPielN As String = ""
        Dim idCorForroN As String = ""
        Dim idcorPielSintN As String = ""
        Dim idCorForroSintN As String = ""

        If chkval.Checked = True Then
            chkval.Checked = False
        End If

        'datos = grdBorrador.DataSource
        Try
            MostrarEspere(Me)
            For Each row As UltraGridRow In grdBorrador.Rows


                idcorPiel = 0
                    idCorForro = 0

                    Try
                    idcorPiel = row.GetCellValue("Cortador_Piel")
                    'cmbPiel.SelectedValue = idcorPiel
                    idcorPielN = row.GetCellText(row.Band.Columns("Cortador_Piel")).ToString()
                    'idcorPielN = cmbPiel.Text
                Catch ex As Exception
                    End Try
                    Try
                        idCorForro = row.GetCellValue("Cortador_Forro")
                    'cmbForro.SelectedValue = idCorForro
                    idCorForroN = row.GetCellText(row.Band.Columns("Cortador_Forro")).ToString()
                    'idCorForroN = cmbForro.Text
                Catch ex As Exception
                    End Try
                    Try
                        idcorPielSint = row.GetCellValue("Cortador_PielSint")
                    'cmbPielS.SelectedValue = idcorPielSint
                    idcorPielSintN = row.GetCellText(row.Band.Columns("Cortador_PielSint")).ToString()
                    'idcorPielSintN = cmbPielS.Text
                Catch ex As Exception
                    End Try
                    Try
                        idCorForroSint = row.GetCellValue("Cortador_ForroSint")
                    'cmbForroS.SelectedValue = idCorForroSint
                    idCorForroSintN = row.GetCellText(row.Band.Columns("Cortador_ForroSint")).ToString()
                    'idCorForroSintN = cmbForroS.Text
                Catch ex As Exception
                    End Try

                    If row.GetCellValue("Concentrado") > 0 Then 'Es Concentrado
                        obj.guardarCortadoresSICY(1, row.GetCellValue("IdNave"), row.GetCellValue("IdPrograma"), row.GetCellValue("IdPedido"), row.GetCellValue("IdPartida"), row.GetCellValue("IdLote"), idcorPiel, idCorForro, row.GetCellValue("Concentrado"), idcorPielSint, idCorForroSint, idcorPielN, idCorForroN, idcorPielSintN, idCorForroSintN)
                        obj.guardarCortadoresSAY(1, row.GetCellValue("IdNave"), row.GetCellValue("IdPrograma"), row.GetCellValue("IdPedido"), row.GetCellValue("IdPartida"), row.GetCellValue("IdLote"), idcorPiel, idCorForro, row.GetCellValue("Concentrado"), idcorPielSint, idCorForroSint, idcorPielN, idCorForroN, idcorPielSintN, idCorForroSintN)
                    Else 'No es concentrado
                        obj.guardarCortadoresSICY(0, row.GetCellValue("IdNave"), row.GetCellValue("IdPrograma"), row.GetCellValue("IdPedido"), row.GetCellValue("IdPartida"), row.GetCellValue("IdLote"), idcorPiel, idCorForro, row.GetCellValue("Concentrado"), idcorPielSint, idCorForroSint, idcorPielN, idCorForroN, idcorPielSintN, idCorForroSintN)
                        obj.guardarCortadoresSAY(0, row.GetCellValue("IdNave"), row.GetCellValue("IdPrograma"), row.GetCellValue("IdPedido"), row.GetCellValue("IdPartida"), row.GetCellValue("IdLote"), idcorPiel, idCorForro, row.GetCellValue("Concentrado"), idcorPielSint, idCorForroSint, idcorPielN, idCorForroN, idcorPielSintN, idCorForroSintN)
                    End If

                'End If
            Next

            MostrarMensaje(Mensajes.Success, "Información guardada.")
        Catch ex As Exception
            MostrarMensaje(Mensajes.Warning, "Surgió algo inesperado: " & ex.Message)
        Finally
            TerminarEspere(Me)
        End Try

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
                ultExportGrid.Export(grdBorrador, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub
    ''' <summary>
    ''' Tipo 1 para destinatarios confirmar borrador, tipo 2 para destinatarios rechazar borrador
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getDestinatarios(ByVal tipo As Integer)
        Dim obj As New ConfirmacionBorradorBU
        Dim destinatarios As String = ""
        Dim ban As Integer = 0
        Dim datadestinatarios As New DataTable
        datadestinatarios = obj.getDatosNave(idNave)
        If tipo = 1 Then 'Confirmacion de programa
            For Each row As DataRow In datadestinatarios.Rows
                If row("ProgramadorEmail").ToString.Length > 0 Then
                    destinatarios += row("ProgramadorEmail").ToString
                    ban = 1
                End If
                If row("EncargadoEmail").ToString.Length > 0 Then
                    If ban = 0 Then
                        destinatarios += row("EncargadoEmail").ToString
                        ban = 1
                    Else
                        destinatarios += "," & row("EncargadoEmail").ToString
                    End If

                End If
                If row("EmailCC").ToString.Length > 0 Then
                    If ban = 0 Then
                        destinatarios += row("EmailCC").ToString
                        ban = 1
                    Else
                        destinatarios += "," & row("EmailCC").ToString
                    End If
                End If
            Next
        End If
        If tipo = 2 Then 'Rechazo de programa
            For Each row As DataRow In datadestinatarios.Rows
                If row("ProgramadorEmail").ToString.Length > 0 Then
                    destinatarios += row("ProgramadorEmail").ToString
                    ban = 1
                End If
                If row("EncargadoEmail").ToString.Length > 0 Then
                    If ban = 0 Then
                        destinatarios += row("EncargadoEmail").ToString
                        ban = 1
                    Else
                        destinatarios += "," & row("EncargadoEmail").ToString
                    End If

                End If
                If row("EmailCC").ToString.Length > 0 Then
                    If ban = 0 Then
                        destinatarios += row("EmailCC").ToString
                        ban = 1
                    Else
                        destinatarios += "," & row("EmailCC").ToString
                    End If
                End If
                If row("RevisorEmail").ToString.Length > 0 Then
                    If ban = 0 Then
                        destinatarios += row("RevisorEmail").ToString
                        ban = 1
                    Else
                        destinatarios += "," & row("RevisorEmail").ToString
                    End If
                End If
            Next
        End If
        getDestinatarios = destinatarios
    End Function


    Function validarBorrador() As Boolean
        Dim datos As New DataTable
        datos = grdBorrador.DataSource

        For Each row As DataRow In datos.Rows
            Try
                If row("Cortador_Piel") = 0 And row("Cortador_PielSint") = 0 Then
                    objMensaje.mensaje = "No puede haber lotes sin cortador de piel." 'En el 2017 los vamos a vender
                    objMensaje.ShowDialog()
                    Return False
                End If
            Catch ex As Exception
                objMensaje.mensaje = "No puede haber lotes sin cortador de piel." 'En el 2017 los vamos a vender
                objMensaje.ShowDialog()
                Return False
            End Try

        Next

        For Each row As DataRow In datos.Rows
            Try
                If row("Cortador_Forro") = 0 And row("Cortador_ForroSint") = 0 Then
                    Dim objMensaje As New Tools.ConfirmarForm
                    objMensaje.mensaje = "Se encontraron lotes sin cortador de forro ¿Desea continuar con la confirmación?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Catch ex As Exception
                Dim objMensaje As New Tools.ConfirmarForm
                objMensaje.mensaje = "Se encontraron lotes sin cortador de forro ¿Desea continuar con la confirmación?"
                If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Return True
                Else
                    Return False
                End If
            End Try
        Next
        Return True
    End Function


    Function bodycorreoConfirmar()
        Dim datosNave As New DataTable
        Dim obj As New ConfirmacionBorradorBU
        Dim nombreNave As String = ""
        datosNave = obj.getDatosNave(idNave)
        For Each row As DataRow In datosNave.Rows
            nombreNave = row("nave")
        Next
        Dim Encabezado As String = ""
        'Dim Detalles As String
        Dim Pie As String = String.Empty
        Encabezado = Encabezado & "<style type='text/css'>"
        'Encabezado = Encabezado & "body {background-color: #666666; }"
        Encabezado = Encabezado & ".Estilo1 {font-family: Georgia, 'Times New Roman', Times, serif; font-weight: bold; }"
        Encabezado = Encabezado & ".Estilo10 {font-size: 16px; font-weight: bold; }"
        Encabezado = Encabezado & ".Estilo16 {font-family: Geneva, Arial, Helvetica, sans-serif; font-size: 14px; }"
        Encabezado = Encabezado & "</style></head>"

        Encabezado = Encabezado & "<body>"
        Encabezado = Encabezado & "<table width='750' border='0' align='center'>"
        Encabezado = Encabezado & "  <tr>"
        Encabezado = Encabezado & "    <td colspan='3'>&nbsp;</td>"
        Encabezado = Encabezado & "  </tr>"
        Encabezado = Encabezado & "  <tr>"
        Encabezado = Encabezado & "    <td width='3%'>&nbsp;</td>"
        Encabezado = Encabezado & "    <td width='94%'><table width='100%' border='0' align='center'>"
        Encabezado = Encabezado & "      <tr>"

        Select Case idNave
            Case 1
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/YUYIN.JPG' width='156' height='85' /></div></td>"
            Case 2
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/MERANO.JPG' width='156' height='85' /></div></td>"
            Case 3
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/JEANS.JPG' width='156' height='85' /></div></td>"
            Case 5
                'Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/ZONAX.JPG' width='156' height='85' /></div></td>"
            Case 6
                'Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://www.grupoyuyin.com/intranet/images/SanMartin.jpg' width='156' height='85' /></div></td>"
            Case 7
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/VAGABUNDO.JPG' width='156' height='85' /></div></td>"
            Case 8
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG' width='156' height='85' /></div></td>"
            Case 9
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG' width='156' height='85' /></div></td>"
            Case 10
                'Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://www.grupoyuyin.com/intranet/images/Graffiti.jpg' width='156' height='85' /></div></td>"
            Case 11
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/JEANS2.JPG' width='156' height='85' /></div></td>"
        End Select

        Encabezado = Encabezado & "        <td width='76%'><div align='right' class='Estilo1'>" & nombreNave & " AVISO CONFIRMACION DE BORRADOR A PROGRAMACION</div></td>"
        Encabezado = Encabezado & "      </tr>"
        Encabezado = Encabezado & "      <tr>"
        Encabezado = Encabezado & "        <td colspan='2'>&nbsp;</td>"
        Encabezado = Encabezado & "        </tr>"
        Encabezado = Encabezado & "      <tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "        <td  class='Estilo1'><div align='left' class='Estilo10'>Fecha</div></td>"
        Encabezado = Encabezado & "        <td ><span class='Estilo16'>" & Date.Now.ToString("dd/MM/yyyy") & "</span></td>"
        Encabezado = Encabezado & "      </tr>"
        Encabezado = Encabezado & "      <tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "        <td  class='Estilo1'><div align='left' class='Estilo10'>Programa</div></td>"
        Encabezado = Encabezado & "        <td ><span class='Estilo16'>" & fechaPrograma.ToString("dd/MM/yyyy") & "</span></td>"
        Encabezado = Encabezado & "      </tr>"
        Encabezado = Encabezado & "      <tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "        <td  class='Estilo1'><div align='left' class='Estilo10'>Realizó</div></td>"
        Encabezado = Encabezado & "        <td ><span class='Estilo16'>" & Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal & "</span></td>"
        Encabezado = Encabezado & "      </tr>"
        'Encabezado = Encabezado & "      <tr bordercolor='#FFFFFF'>"
        'Encabezado = Encabezado & "        <td bgcolor='#CCCCCC' class='Estilo1'><div align='left' class='Estilo10'>Concepto</div></td>"
        'If BuscarRechazos > 0 Then
        '    Encabezado = Encabezado & "        <td bgcolor='#CCCCCC'><span class='Estilo16'>SE HA AUTORIZADO EL BORRADOR POR LA NAVE " & UCase(dcboNave.Text) & " [CON RECHAZOS]</span></td>"
        'Else
        '    Encabezado = Encabezado & "        <td bgcolor='#CCCCCC'><span class='Estilo16'>SE HA AUTORIZADO EL BORRADOR POR LA NAVE " & UCase(dcboNave.Text) & "</span></td>"
        'End If
        'Encabezado = Encabezado & "      </tr>"
        Pie = Pie & "    </table></td>"
        Pie = Pie & "    <td width='3%'>&nbsp;</td>"
        Pie = Pie & "  </tr>"
        Pie = Pie & "  <tr>"
        'Pie = Pie & "    <td colspan='3'><div align='right' class='Estilo29'><p>&nbsp;</p><p>Programa: " & IIf((GetSetting("SICY", "Produccion", "DB") = "YUYIN"), "SICY", "SICY CALIDAD") & "</p></div></td>"
        Pie = Pie & "  </tr>"
        Pie = Pie & "</table>"
        Pie = Pie & "</body>"
        bodycorreoConfirmar = Encabezado & Pie
    End Function
    Public Sub EnviarCorreoArchivo(ByVal body As String, ByVal asunto As String, ByVal destinatarios As String)
        Dim mensaje As String = "Mensaje enviado correctamente"
        Dim cliente As New SmtpClient
        Dim smtp As New Entidades.SMTP
        Dim autenticacion As New System.Net.NetworkCredential("borrador.ppcp1@grupoyuyin.com.mx", "12345")
        cliente.Credentials = autenticacion
        cliente.Host = "smtpout.secureserver.net"
        cliente.Port = 3535
        cliente.EnableSsl = False
        'Sacar los destinatarios de cada nave
        'Dim [from] As New MailAddress("servicioselectronicos@grupoyuyin.com","servicioselectronicos@grupoyuyin.com", System.Text.Encoding.UTF8)
        Dim mailMsg As New MailMessage()
        'Asigna los destinatarios.
        For Each mail As String In destinatarios.Split(New Char() {","c})
            mailMsg.To.Add(New System.Net.Mail.MailAddress(mail))
        Next
        mailMsg.From = New System.Net.Mail.MailAddress("borrador.ppcp1@grupoyuyin.com.mx")
        mailMsg.BodyEncoding = System.Text.Encoding.UTF8
        mailMsg.Body = body
        mailMsg.Subject = asunto
        mailMsg.SubjectEncoding = System.Text.Encoding.UTF8
        mailMsg.IsBodyHtml = True
        Me.Cursor = Cursors.WaitCursor
        cliente.Send(mailMsg)
        'AddHandler cliente.SendCompleted, AddressOf SendCompletedCallback
        'Dim userState As String = "test message1"
        'cliente.SendAsync(mailMsg, userState)
        Me.Cursor = Cursors.Default
    End Sub
    Private Shared mailSent As Boolean = False
    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        'Get the unique identifier for this asynchronous operation.
        Dim token As String = CStr(e.UserState)
        Dim a As New AdvertenciaForm
        Dim x As New ExitoForm
        If e.Cancelled Then
            a.mensaje = "Mensaje cancelado."
            a.ShowDialog()
        End If
        If e.Error IsNot Nothing Then
            a.mensaje = " " + e.Error.ToString()
            a.ShowDialog()
        Else
            x.mensaje = "Mensaje enviado."
            x.ShowDialog()
        End If
        mailSent = True
        CType(sender, SmtpClient).Dispose()
    End Sub
    Function bodycorreoRechazado(ByVal motivoRechazo As String)
        Dim Encabezado As String = ""
        'Dim Detalles As String
        Dim datosNave As New DataTable
        Dim obj As New ConfirmacionBorradorBU
        Dim nombreNave As String = ""
        datosNave = obj.getDatosNave(idNave)
        For Each row As DataRow In datosNave.Rows
            nombreNave = row("nave")
        Next
        Dim Pie As String = String.Empty

        Encabezado = Encabezado & "<head>"
        Encabezado = Encabezado & "<style type='text/css'>"
        'Encabezado = Encabezado & "body {background-color: #666666; }"
        Encabezado = Encabezado & ".Estilo1 {font-family: Georgia, 'Times New Roman', Times, serif; font-weight: bold; }"
        Encabezado = Encabezado & ".Estilo10 {font-size: 14px; font-weight: bold; }"
        Encabezado = Encabezado & ".Estilo16 {font-family: Geneva, Arial, Helvetica, sans-serif; font-size: 14px; }"
        Encabezado = Encabezado & ".Estilo18 {font-size: 12px; font-weight: bold; }"
        Encabezado = Encabezado & "</style>"
        Encabezado = Encabezado & "</head>"

        Encabezado = Encabezado & "<body>"
        Encabezado = Encabezado & "<table width='80%' border='0' align='center'>"
        Encabezado = Encabezado & "<tr>"
        Encabezado = Encabezado & "<td colspan='3'>&nbsp;</td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr>"
        Encabezado = Encabezado & "<td width='3%'>&nbsp;</td>"
        Encabezado = Encabezado & "<td width='94%'><table width='100%' border='0' align='center'>"
        Encabezado = Encabezado & "<tr>"

        Select Case idNave
            Case 1
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/YUYIN.JPG' width='156' height='85' /></div></td>"
            Case 2
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/MERANO.JPG' width='156' height='85' /></div></td>"
            Case 3
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/JEANS.JPG' width='156' height='85' /></div></td>"
            Case 5
                'Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/ZONAX.JPG' width='156' height='85' /></div></td>"
            Case 6
                'Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://www.grupoyuyin.com/intranet/images/SanMartin.jpg' width='156' height='85' /></div></td>"
            Case 7
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/VAGABUNDO.JPG' width='156' height='85' /></div></td>"
            Case 8
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG' width='156' height='85' /></div></td>"
            Case 9
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/GRUPOYUYIN.JPG' width='156' height='85' /></div></td>"
            Case 10
                'Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://www.grupoyuyin.com/intranet/images/Graffiti.jpg' width='156' height='85' /></div></td>"
            Case 11
                Encabezado = Encabezado & "<td width='23%'><div align='center'><img src='http://192.168.2.158/nomina/LOGOTIPOS/JEANS2.JPG' width='156' height='85' /></div></td>"
        End Select

        Encabezado = Encabezado & "<td width='76%'><div align='right' class='Estilo1'>" & nombreNave & " RECHAZO DE BORRADOR</div></td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr>"
        Encabezado = Encabezado & "<td colspan='2'>&nbsp;</td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "<td  class='Estilo1'><div align='left' class='Estilo10'>Fecha</div></td>"
        Encabezado = Encabezado & "<td ><span class='Estilo16'>" & Date.Now.ToString("dd/MM/yyyy") & "</span></td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "<td  class='Estilo1'><div align='left' class='Estilo10'>Programa</div></td>"
        Encabezado = Encabezado & "<td ><span class='Estilo16'>" & fechaPrograma.ToString("dd/MM/yyyy") & "</span></td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "<td  class='Estilo1'><div align='left' class='Estilo10'>Realizó</div></td>"
        Encabezado = Encabezado & "<td ><span class='Estilo16'>" & Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal & "</span></td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "<td  class='Estilo1'><div align='left' class='Estilo10'>Concepto</div></td>"
        Encabezado = Encabezado & "<td ><span class='Estilo16'>SE RECHAZO EL PROGRAMA COMPLETO</span></td>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "</tr>"
        Encabezado = Encabezado & "<tr bordercolor='#FFFFFF'>"
        Encabezado = Encabezado & "<td  class='Estilo1'><div align='left' class='Estilo10'>Motivo Rechazo:</div></td>"
        Encabezado = Encabezado & "<td ><span class='Estilo16'>" & motivoRechazo & "</span></td>"
        Encabezado = Encabezado & "</tr>"

        Pie = Pie & "</table></td>"
        Pie = Pie & "<td width='3%'>&nbsp;</td>"
        Pie = Pie & "</tr>"
        Pie = Pie & "<tr>"
        Pie = Pie & "<td colspan='3'><div align='right' class='Estilo29'>"
        'Pie = Pie & "<p class='Estilo18'>Programa: " & IIf((GetSetting("SICY", "Produccion", "DB") = "YUYIN"), "SICY", "SICY CALIDAD") & "</p>"
        Pie = Pie & "</div></td>"
        Pie = Pie & "</tr>"
        Pie = Pie & "</table>"
        Pie = Pie & "</body>"
        bodycorreoRechazado = Encabezado & Pie
    End Function

    Private Sub btnImprimirPDF_Click(sender As Object, e As EventArgs) Handles btnImprimirPDF.Click

        Cursor = Cursors.WaitCursor
        Dim dsReporteBorrador As New DataSet("dsTablaBorrador")
        Dim detalleReporte As New DataTable("dtTablaBorrador")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim obj As New ConfirmacionBorradorBU
        Dim idprograma As New DataTable

        Dim idNaveSicy = getIdNaveSicy(cmbNave.SelectedValue)
        fechaPrograma = dtpFechaInicio.Value.ToShortDateString
        idprograma = obj.GetIdPrograma(idNaveSicy, dtpFechaInicio.Value.Date)

        If idprograma.Rows.Count > 0 Then

            Dim tablaCortadoresPiel, tablaCortadoresForro As New DataTable
            Dim tablaCortadoresPielSint, tablaCortadoresForroSint As New DataTable
            Dim objc As New ConfirmacionBorradorBU

            Dim idNaveSay = cmbNave.SelectedValue
            tablaCortadoresPiel = objc.getCortadores(idNaveSay, Enumerados.TipoCortador.PIEL)
            tablaCortadoresForro = objc.getCortadores(idNaveSay, Enumerados.TipoCortador.FORRO)
            tablaCortadoresPielSint = objc.getCortadores(idNaveSay, Enumerados.TipoCortador.PIEL_SINTETICO)
            tablaCortadoresForroSint = objc.getCortadores(idNaveSay, Enumerados.TipoCortador.FORRO_SINTETICO)

            detalleReporte = obj.getBorrador(idNaveSicy, idprograma.Rows(0).Item(0))

            detalleReporte.Columns.Add("CortadorPiel")
            detalleReporte.Columns.Add("CortadorPSint")
            detalleReporte.Columns.Add("CortadorF")
            detalleReporte.Columns.Add("CortadorFSint")

            For Each vRow As DataRow In detalleReporte.Rows
                For Each vR As DataRow In tablaCortadoresPiel.Rows
                    If vRow.Item("Cortador_Piel") <> 0 Then
                        If vRow.Item("Cortador_Piel") = vR.Item("copf_cortadorpielforroid") Then
                            vRow.Item("CortadorPiel") = vR.Item("codr_nombrecorto")
                        End If
                    End If

                Next
            Next

            For Each vRow As DataRow In detalleReporte.Rows
                For Each vR As DataRow In tablaCortadoresPielSint.Rows
                    If vRow.Item("Cortador_PielSint") <> 0 Then
                        If vRow.Item("Cortador_PielSint") = vR.Item("copf_cortadorpielforroid") Then
                            vRow.Item("CortadorPSint") = vR.Item("codr_nombrecorto")
                        End If
                    End If
                Next
            Next
            For Each vRow As DataRow In detalleReporte.Rows
                For Each vR As DataRow In tablaCortadoresForro.Rows
                    If vRow.Item("Cortador_Forro") <> 0 Then
                        If vRow.Item("Cortador_Forro") = vR.Item("copf_cortadorpielforroid") Then
                            vRow.Item("CortadorF") = vR.Item("codr_nombrecorto")
                        End If
                    End If
                Next
            Next

            For Each vRow As DataRow In detalleReporte.Rows
                For Each vR As DataRow In tablaCortadoresForroSint.Rows
                    If vRow.Item("Cortador_ForroSint") <> 0 Then
                        If vRow.Item("Cortador_ForroSint") = vR.Item("copf_cortadorpielforroid") Then
                            vRow.Item("CortadorFSint") = vR.Item("codr_nombrecorto")
                        End If
                    End If
                Next
            Next

            detalleReporte.TableName = "dtTablaBorrador"
            dsReporteBorrador.Tables.Add(detalleReporte)

            EntidadReporte = objReporte.LeerReporteporClave("BORRADORES_PRODUCCION")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport

            reporte.Load(archivo)
            reporte.Compile()
            reporte("dsTablaBorrador") = "dsTablaBorrador"
            reporte.Dictionary.Clear()
            reporte("log") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
            reporte("fecha") = CapitalizarCadena(fechaPrograma.ToString("dddd, dd ")) & CapitalizarCadena(fechaPrograma.ToString("MMMM")) & " de " & fechaPrograma.ToString("yyyy")
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.RegData(dsReporteBorrador)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Else
            objMensaje.mensaje = "No hay programa registrado para la nave o fecha seleccionada"
            objMensaje.ShowDialog()
            lblEstatus.Text = "-"
            cmbForro.DataSource = Nothing
            cmbPiel.DataSource = Nothing
            grdBorrador.DataSource = Nothing
        End If

        Cursor = Cursors.Default

    End Sub

    Private Function CapitalizarCadena(ByVal cadena As String) As String
        Dim curCulture As Globalization.CultureInfo = Threading.Thread.CurrentThread.CurrentCulture
        Dim tInfo As Globalization.TextInfo = curCulture.TextInfo()
        Return tInfo.ToTitleCase(cadena)
    End Function

    Private Function ValidarEstatus() As Boolean
        Dim porAutorizar As Boolean = False
        For Each row As UltraGridRow In grdBorrador.Rows.GetFilteredInNonGroupByRows
            If row.Cells("Autorizado").Value = 0 Then
                porAutorizar = True
                Exit For
            End If
        Next
        Return porAutorizar
    End Function

    Private Sub btnActualizarLotes_Click(sender As Object, e As EventArgs) Handles btnActualizarLotes.Click
        Dim actualizarLotesForm As New Produccion_Borradores_ReplicarLotesSICY_SAYForm
        actualizarLotesForm.ShowDialog()
    End Sub
End Class