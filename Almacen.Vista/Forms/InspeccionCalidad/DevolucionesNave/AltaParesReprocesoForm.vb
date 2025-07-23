Imports Tools
Imports System.Media

Public Class AltaParesReprocesoForm

    Private dtParesDevolucion As New DataTable
    Private FolioReprocesoID As Integer = 0
    Private objBU As New Negocios.InspeccionCalidadBU
    Private NaveId As Integer = 0

    Private Sub AltaParesReprocesoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ActivarControles(True)
            InicializarTabla()
            CargarNaves()
            dtmFechaEstimaRegreso.MinDate = Date.Now
            dtmFechaEstimaRegreso.Value = Date.Now.AddDays(2)
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Public Sub InicializarTabla()

        dtParesDevolucion.Columns.Add("Atado")
        dtParesDevolucion.Columns.Add("Par")
        dtParesDevolucion.Columns.Add("Lote")
        dtParesDevolucion.Columns.Add("Pedido")
        dtParesDevolucion.Columns.Add("Cliente")
        dtParesDevolucion.Columns.Add("Modelo")
        dtParesDevolucion.Columns.Add("Talla")
        dtParesDevolucion.Columns.Add("Calce")
        dtParesDevolucion.Columns.Add("Descripcion")
        dtParesDevolucion.Columns.Add("AtadoCompleto")

    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Try

            If cmbNave.SelectedIndex >= 0 And txtTratamiento.Text <> String.Empty Then
                ActivarControles(False)
                NaveId = cmbNave.SelectedValue
            Else
                If cmbNave.SelectedIndex < 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado una nave.")
                Else
                    If txtTratamiento.Text = String.Empty Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha capturado un tratamiento.")
                    End If
                End If
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Public Sub ActivarControles(ByVal Activar As Boolean)

        If Activar = True Then
            btnDetener.Enabled = False
            btnIniciar.Enabled = True
            btnLimpiar.Enabled = True
            cmbNave.Enabled = True
            cmbEntrego.Enabled = True
            txtLectura.Enabled = False
            dtmFechaEstimaRegreso.Enabled = True
            txtTratamiento.Enabled = True
            btnGuardar.Enabled = True
            btnCerrar.Enabled = True
        Else
            btnIniciar.Enabled = False
            btnDetener.Enabled = True
            btnLimpiar.Enabled = False
            cmbNave.Enabled = False
            cmbEntrego.Enabled = False
            txtLectura.Enabled = True
            dtmFechaEstimaRegreso.Enabled = False
            txtTratamiento.Enabled = False
            btnGuardar.Enabled = False
            btnCerrar.Enabled = False
        End If
    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        ActivarControles(True)
        If dtParesDevolucion.Rows.Count > 0 Then
            cmbNave.Enabled = False
        Else
            cmbNave.Enabled = True
        End If


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            dtParesDevolucion.Rows.Clear()
            CargarGrid()
            If dtParesDevolucion.Rows.Count > 0 Then
                cmbNave.Enabled = False
            Else
                cmbNave.Enabled = True
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dim confirmar As New Tools.ConfirmarForm

        If FolioReprocesoID = 0 Then
            confirmar.mensaje = "No se ha guardado el folio de reproceso ¿Desea continuar?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim FolioDevolucionId As Integer = 0


        Try
            Cursor = Cursors.WaitCursor

            If dtParesDevolucion.Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay pares capturados para realizar la devolución.")
            Else
                FolioDevolucionId = objBU.GuardarEncabezadoFolioAlta(NaveId, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, dtmFechaEstimaRegreso.Value.ToShortDateString(), dtParesDevolucion.Rows.Count, txtTratamiento.Text)

                If FolioDevolucionId > 0 Then
                    'Guardar Pares por atado
                    Dim Atados = dtParesDevolucion.AsEnumerable.Where(Function(y) y.Item("AtadoCompleto") = 1).Select(Function(x) x.Item("Atado")).Distinct.ToList()
                    For Each Fila As String In Atados
                        objBU.GuardarParesFolioAlta(FolioDevolucionId, Fila, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, True)
                    Next

                    'Guardar Pares por PAR X PAR
                    Dim Pares = dtParesDevolucion.AsEnumerable.Where(Function(y) y.Item("AtadoCompleto") = 0).Select(Function(x) x.Item("Par")).Distinct.ToList()
                    For Each Fila As String In Pares
                        objBU.GuardarParesFolioAlta(FolioDevolucionId, Fila, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, False)
                    Next

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han generado el folio de devolución " + FolioDevolucionId.ToString())
                End If

                Me.Close()
            End If
            Cursor = Cursors.Default

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub txtLectura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLectura.KeyPress
        Dim CadenaCapturada As String = String.Empty

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then

                If (LTrim(RTrim(txtLectura.Text))) = "" Then Return

                CadenaCapturada = (LTrim(RTrim(txtLectura.Text))).Replace("'", "-")
                CadenaCapturada = CadenaCapturada.TrimStart("0")

                ValidarCodigoLeido(CadenaCapturada)

                'If CadenaCapturada.Contains("-") = True Then
                '    ReproducrirSonidoError()
                '    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Código Invalido.")
                'Else
                '    ValidarCodigoLeido(CadenaCapturada)
                'End If

                txtLectura.Text = ""
                txtLectura.Focus()
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Public Sub ReproducrirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub

    Private Sub ValidarCodigoLeido(ByVal CodigoLeido As String)
        Dim EsCodigoValido As Boolean = False
        Dim dtInfoAtado As DataTable
        Dim EsCodigoPar As Boolean = False

        Dim codigo_split = LTrim(RTrim(CodigoLeido)).Split("-") ''parte la cadena


        If codigo_split.Length = 3 Then
            CodigoLeido = codigo_split(2).Trim()
            EsCodigoPar = True
            EsCodigoValido = objBU.DevlucionValidaAtado_Alta(CodigoLeido, NaveId, True)
        Else
            EsCodigoValido = objBU.DevlucionValidaAtado_Alta(CodigoLeido, NaveId, False)
        End If


        If EsCodigoValido = True Then
            If EsCodigoPar = True Then
                If dtParesDevolucion.AsEnumerable().Where(Function(x) x.Item("Par").ToString.TrimStart("0") = CodigoLeido).Count = 0 Then
                    dtInfoAtado = objBU.DevlucionObtenerInformacionAtado_Alta(CodigoLeido, True)

                    If dtInfoAtado.Rows.Count > 0 Then

                        For Each item As DataRow In dtInfoAtado.Rows
                            With item
                                dtParesDevolucion.Rows.Add(
                                        .Item("Atado"),
                                        .Item("Par"),
                                        .Item("Lote"),
                                        .Item("Pedido"),
                                        .Item("Cliente"),
                                        .Item("Modelo"),
                                        .Item("Talla"),
                                        .Item("Calce"),
                                        .Item("Descripcion"),
                                           0)


                            End With
                        Next
                    End If
                    CargarGrid()

                End If
            Else
                If dtParesDevolucion.AsEnumerable().Where(Function(x) x.Item("Atado").ToString.TrimStart("0") = CodigoLeido).Count > 0 Then

                    Dim Atados = dtParesDevolucion.AsEnumerable().Where(Function(x) x.Item("Atado").ToString.TrimStart("0")).ToList

                    For Each Fila As DataRow In Atados
                        dtParesDevolucion.Rows.Remove(Fila)
                    Next

                End If



                dtInfoAtado = objBU.DevlucionObtenerInformacionAtado_Alta(CodigoLeido, False)

                    If dtInfoAtado.Rows.Count > 0 Then

                        For Each item As DataRow In dtInfoAtado.Rows
                            With item
                            dtParesDevolucion.Rows.Add(
                                        .Item("Atado"),
                                        .Item("Par"),
                                        .Item("Lote"),
                                        .Item("Pedido"),
                                        .Item("Cliente"),
                                        .Item("Modelo"),
                                        .Item("Talla"),
                                        .Item("Calce"),
                                        .Item("Descripcion"),
                                        1)
                        End With
                        Next

                    End If
                    CargarGrid()


                End If


        Else
            ReproducrirSonidoError()
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Asegurese que el atado no este proyectado o en reproceso en otro folio.")
        End If

    End Sub

    Private Sub CargarGrid()
        Try
            grdParesReproceso.DataSource = dtParesDevolucion
            DiseñoGrid.DiseñoBaseGrid(viewParesReproceso)
            viewParesReproceso.OptionsView.ColumnAutoWidth = True
            lblTotalParesDevolucion.Text = CDbl(dtParesDevolucion.Rows.Count).ToString("N0")

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Public Sub CargarNaves()

        Dim dtResultado As New DataTable
        Try
            dtResultado = objBU.ConsultaNavesDevolucion_Alta()
            cmbNave.DataSource = dtResultado
            cmbNave.ValueMember = "IdNave"
            cmbNave.DisplayMember = "Nave"

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        Dim dtResultado As New DataTable
        Try
            If cmbNave.SelectedIndex >= 0 Then
                dtResultado = objBU.ConsultaOperadoresNave(cmbNave.SelectedValue)
                cmbEntrego.DataSource = dtResultado
                cmbEntrego.DisplayMember = "Nombre"
                cmbEntrego.ValueMember = "IdOperador"
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class