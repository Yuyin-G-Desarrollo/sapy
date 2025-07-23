Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AgregarEditarEventosForm

    Public EventoID As Integer = -1
    Public EsEventoActivo As Boolean = False
    Private objEventoBU As New Negocios.CatalogoEventoBU
    Private ObjEntidadEvento As New Entidades.Evento

    Private Sub AgregarEditarEventosForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LimpiarInterfaz()
        If EventoID >= 0 Then
            CargarInformacionEvento()
        Else
            rdoActivoSi.Checked = True
            lblActivo.Visible = False
            rdoActivoSi.Visible = False
            rdoActivoNo.Visible = False
        End If
        RestriccionesInterfaz()
    End Sub

    Private Function ObtieneNumeroSemana(ByVal Fecha As Date) As String
        Dim NumeroSemana As Integer = 0
        Dim FormatoNumeroSemana As String = String.Empty
        NumeroSemana = DatePart(DateInterval.WeekOfYear, Fecha)
        FormatoNumeroSemana = "SEMANA " + NumeroSemana.ToString() + "-" + Fecha.Year.ToString()
        Return FormatoNumeroSemana
    End Function

    Private Sub CargarInformacionEvento()
        
        Dim FechaNula As Date = Nothing
        ObjEntidadEvento = objEventoBU.ObtenerInformacionEvento(EventoID)
        txtEventoNombre.Text = ObjEntidadEvento.ENombre
        txtLugarEvento.Text = ObjEntidadEvento.ELugar
        txtAbreviatura.Text = ObjEntidadEvento.EAbreviatura

        If ObjEntidadEvento.EFechaInicioEvento <> FechaNula Then
            dtpFechaInicioEvento.Value = ObjEntidadEvento.EFechaInicioEvento
        End If

        If ObjEntidadEvento.EFEchaFinEvento <> FechaNula Then
            dtpFechaFinEvento.Value = ObjEntidadEvento.EFEchaFinEvento
        End If

        If ObjEntidadEvento.EFechaEntregaColeccionesNuevas <> FechaNula Then
            dtpFechaColNueva.Value = ObjEntidadEvento.EFechaEntregaColeccionesNuevas
        End If

        If ObjEntidadEvento.EFechaEntregaColeccionesVigentes <> FechaNula Then
            dtpFechaVigencia.Value = ObjEntidadEvento.EFechaEntregaColeccionesVigentes
        End If


        txtNumeroSemanaNueva.Text = ObtieneNumeroSemana(dtpFechaColNueva.Value)
        txtNumeroSemanaVigente.Text = ObtieneNumeroSemana(dtpFechaVigencia.Value)
        If ObjEntidadEvento.EActivo = True Then
            rdoActivoSi.Checked = True
            rdoActivoNo.Checked = False
        Else
            rdoActivoSi.Checked = False
            rdoActivoNo.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' Si es un nuevo evento la fecha minima del registgro de este el mismo dia, y estara hablitada la captura
    ''' Si es una edicion y el evento es activo se habilitara los campos de fecha en caso contrario se deshabilitaran los campos de fecha
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RestriccionesInterfaz()
        If EventoID < 0 Then
            dtpFechaColNueva.MinDate = Date.Now.ToShortDateString
            dtpFechaFinEvento.MinDate = Date.Now.ToShortDateString
            dtpFechaInicioEvento.MinDate = Date.Now.ToShortDateString
            dtpFechaVigencia.MinDate = Date.Now.ToShortDateString
            DesBloquearFechas(True)
        Else
            If EsEventoActivo = True Then
                If ObjEntidadEvento.EFechaInicioEvento < Date.Now Then
                    dtpFechaInicioEvento.MinDate = ObjEntidadEvento.EFechaInicioEvento
                Else
                    dtpFechaInicioEvento.MinDate = Date.Now.ToShortDateString
                End If

                If ObjEntidadEvento.EFEchaFinEvento < Date.Now Then
                    dtpFechaFinEvento.MinDate = ObjEntidadEvento.EFEchaFinEvento
                Else
                    dtpFechaFinEvento.MinDate = Date.Now.ToShortDateString
                End If

                If ObjEntidadEvento.EFechaEntregaColeccionesNuevas < Date.Now Then
                    dtpFechaColNueva.MinDate = ObjEntidadEvento.EFechaEntregaColeccionesNuevas
                Else
                    dtpFechaColNueva.MinDate = Date.Now.ToShortDateString
                End If

                If ObjEntidadEvento.EFechaEntregaColeccionesVigentes < Date.Now Then
                    dtpFechaVigencia.MinDate = ObjEntidadEvento.EFechaEntregaColeccionesVigentes
                Else
                    dtpFechaVigencia.MinDate = Date.Now.ToShortDateString
                End If

            Else
                txtEventoNombre.Enabled = False
                txtAbreviatura.Enabled = False
                txtLugarEvento.Enabled = False
                rdoActivoSi.Enabled = False
                rdoActivoNo.Enabled = False
                btnGuardarEvento.Visible = False
                lblGuardar.Visible = False

            End If
            DesBloquearFechas(EsEventoActivo)
        End If
    End Sub

    Private Sub DesBloquearFechas(ByVal Activar As Boolean)
        dtpFechaColNueva.Enabled = Activar
        dtpFechaFinEvento.Enabled = Activar
        dtpFechaInicioEvento.Enabled = Activar
        dtpFechaVigencia.Enabled = Activar
    End Sub

    Private Sub LimpiarInterfaz()
        txtEventoNombre.Text = String.Empty
        txtLugarEvento.Text = String.Empty
        txtAbreviatura.Text = String.Empty
        dtpFechaColNueva.Value = Date.Now
        dtpFechaFinEvento.Value = Date.Now
        dtpFechaInicioEvento.Value = Date.Now
        dtpFechaVigencia.Value = Date.Now
        rdoActivoSi.Checked = True
        rdoActivoNo.Checked = False
    End Sub

    Private Sub btnCerrarEvento_Click(sender As Object, e As EventArgs) Handles btnCerrarEvento.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardarEvento_Click(sender As Object, e As EventArgs) Handles btnGuardarEvento.Click
      
        If (ValidaVacion() = True And ValidacionFecha() = True) Then
            If ComprobarEventoActivo() = True Then
                If show_message("Confirmar", "Ya existe un evento activo ¿Esta seguro de guardar cambios?") = Windows.Forms.DialogResult.OK Then
                    GuardarRegistro()
                    If EventoID < 0 Then
                        show_message("Exito", "El Evento se agregó correctamente.")
                    Else
                        show_message("Exito", "El Evento se actualizó correctamente.")
                    End If
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                If show_message("Confirmar", "Ya existe un evento activo ¿Esta seguro de guardar cambios?") = Windows.Forms.DialogResult.OK Then
                    GuardarRegistro()
                    If EventoID < 0 Then
                        show_message("Exito", "El Evento se agregó correctamente.")
                    Else
                        show_message("Exito", "El Evento se actualizó correctamente.")
                    End If
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If

        ElseIf (ValidaVacion() = False) Then
            show_message("Advertencia", "Los campos marcados en rojo deben ser completados.")

        ElseIf ValidacionFecha() = False Then
            show_message("Advertencia", "La fecha fin del evento tiene que ser mayor" + Chr(13) + " o igual a la fecha de inicio ")
        End If


    End Sub

    Private Function ValidacionFecha() As Boolean
        Dim ResultadoValidacion As Boolean = True

        If dtpFechaFinEvento.Value < dtpFechaInicioEvento.Value Then
            lblInicioEvento.ForeColor = Color.Red
            lblFinEvento.ForeColor = Color.Red           
            ResultadoValidacion = False
        Else
            lblInicioEvento.ForeColor = Color.Black
            lblFinEvento.ForeColor = Color.Black
        End If

        Return ResultadoValidacion
    End Function


    Private Function ComprobarEventoActivo() As Boolean
        Dim EventoNegocios As New Ventas.Negocios.CatalogoEventoBU
        Return EventoNegocios.ComprobarEventoActivo(EventoID)
    End Function

    Public Function ValidaVacion() As Boolean
        Dim ResultadoValidacion As Boolean = True

        If (txtEventoNombre.Text = Nothing) Then
            lblNombreEvento.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblNombreEvento.ForeColor = Drawing.Color.Black
        End If

        If (txtAbreviatura.Text = Nothing) Then
            lblAbreviaturaEvento.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblAbreviaturaEvento.ForeColor = Drawing.Color.Black
        End If

        If (txtLugarEvento.Text = Nothing) Then
            lblLugarEvento.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblLugarEvento.ForeColor = Drawing.Color.Black
        End If

        If (dtpFechaInicioEvento.Value = Nothing) Then
            lblInicioEvento.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblInicioEvento.ForeColor = Drawing.Color.Black
        End If

        If (dtpFechaFinEvento.Value = Nothing) Then
            lblFinEvento.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblFinEvento.ForeColor = Drawing.Color.Black
        End If

        If (dtpFechaVigencia.Value = Nothing) Then
            lblFechaEntregaColVigente.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblFechaEntregaColVigente.ForeColor = Drawing.Color.Black
        End If

        If (dtpFechaColNueva.Value = Nothing) Then
            lblFechaEntregaColNuevas.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblFechaEntregaColNuevas.ForeColor = Drawing.Color.Black
        End If

        If (txtNumeroSemanaNueva.Text = Nothing) Then
            lblFechaEntregaColNuevas.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblFechaEntregaColNuevas.ForeColor = Drawing.Color.Black
        End If

        If (txtNumeroSemanaVigente.Text = Nothing) Then
            lblFechaEntregaColVigente.ForeColor = Drawing.Color.Red
            ResultadoValidacion = False
        Else
            lblFechaEntregaColVigente.ForeColor = Drawing.Color.Black
        End If


        Return ResultadoValidacion
    End Function

    Public Sub GuardarRegistro()
        Dim EntidadEvento As New Entidades.Evento
        Dim EventoNegocios As New Ventas.Negocios.CatalogoEventoBU
        Dim usuario As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If EventoID = -1 Then
            EntidadEvento.ENombre = txtEventoNombre.Text.Trim()
            EntidadEvento.ELugar = txtLugarEvento.Text.Trim()
            EntidadEvento.EFechaInicioEvento = dtpFechaInicioEvento.Value
            EntidadEvento.EFEchaFinEvento = dtpFechaFinEvento.Value
            EntidadEvento.EFechaEntregaColeccionesNuevas = dtpFechaColNueva.Value
            EntidadEvento.EFechaEntregaColeccionesVigentes = dtpFechaVigencia.Value
            EntidadEvento.EActivo = rdoActivoSi.Checked
            EntidadEvento.EUsuarioCreoId = usuario
            EntidadEvento.EAbreviatura = txtAbreviatura.Text.Trim()
            EntidadEvento.EParesPedidos = 0
            EntidadEvento.EConsecutivoVisitante = 0
            EventoNegocios.GuardarEvento(EntidadEvento)
        Else
            EntidadEvento = EventoNegocios.ObtenerInformacionEvento(EventoID)
            EntidadEvento.ENombre = txtEventoNombre.Text.Trim()
            EntidadEvento.ELugar = txtLugarEvento.Text.Trim()
            EntidadEvento.EFechaInicioEvento = dtpFechaInicioEvento.Value
            EntidadEvento.EFEchaFinEvento = dtpFechaFinEvento.Value
            EntidadEvento.EFechaEntregaColeccionesNuevas = dtpFechaColNueva.Value
            EntidadEvento.EFechaEntregaColeccionesVigentes = dtpFechaVigencia.Value
            EntidadEvento.EActivo = rdoActivoSi.Checked
            EntidadEvento.EUsuarioModificoId = usuario
            EntidadEvento.EEventoId = EventoID
            EntidadEvento.EAbreviatura = txtAbreviatura.Text.Trim()
            EventoNegocios.EditarEvento(EntidadEvento)
        End If
        Me.Close()
    End Sub

    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim ResultDialog As DialogResult

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            ResultDialog = mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            ResultDialog = mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            ResultDialog = mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            ResultDialog = mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            ResultDialog = mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            ResultDialog = mensajeExito.ShowDialog()

        End If
        Return ResultDialog
    End Function

    Private Sub dtpFechaVigencia_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaVigencia.ValueChanged
        txtNumeroSemanaVigente.Text = ObtieneNumeroSemana(dtpFechaVigencia.Value)
    End Sub

    Private Sub dtpFechaColNueva_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaColNueva.ValueChanged
        txtNumeroSemanaNueva.Text = ObtieneNumeroSemana(dtpFechaColNueva.Value)
    End Sub
End Class