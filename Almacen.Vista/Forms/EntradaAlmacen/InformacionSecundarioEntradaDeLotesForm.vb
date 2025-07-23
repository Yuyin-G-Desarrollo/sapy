Imports Almacen.Negocios
Imports Tools

Public Class InformacionSecundarioEntradaDeLotesForm
    Public folio As Int64
    Public IdNave As Integer
    Public Estado_SalidaNave As String
    Public Nave_Valida As Boolean 'TRUE PARA NAVE VALIDA, FALSE PARA NAVE INVALIDA
    Dim campos_vacios As Boolean
    Dim dtTabla As New DataTable
    Dim NuevaPantalla As Boolean = False
    Public EstadoFolioSalidaNaveID As Integer = 0

    Public fecha_Inicio As String
    Public fecha_fin As String
    Public Reporte As Boolean = False
    Public NumeroAlmacen As Integer = 0
    Public ComercializadoraId As Integer = 0

    Private Sub InformacionSecundarioEntradaDeLotesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cmbAlmacen.SelectedIndex = 0
        CargarComercializadora()

        If Reporte = False Then
            txtFolio.Select()
        Else
            Me.ControlBox = False

            cboxNave = Tools.Controles.ComboNaves_IdSicy(cboxNave)

            DateStart.Visible = True
            dateFin.Visible = True
            lblFechaInicio.Visible = True
            lblFechaFin.Visible = True
            cboxNave.Visible = True
            lblNave.Visible = True

            lblFolio.Visible = False
            txtFolio.Visible = False

            DateStart.Value = Now.Date
            DateStart.MaxDate = Now.Date
            dateFin.Value = Now.Date
            dateFin.MaxDate = Now.Date
            cboxNave.SelectedValue = IdNave
            cmbAlmacen.SelectedValue = NumeroAlmacen
        End If

    End Sub

    Private Sub validar_campos_vacios()
        If txtFolio.Text = "" Then
            campos_vacios = True
            lblFolio.ForeColor = Color.Red
        Else
            campos_vacios = False
            lblFolio.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Validar_Folio_De_Lote(ByVal IdSAlidaNave As Integer, ByVal Id_NAve As Integer)
        Dim objBU As New EntradaProductoBU


        If NuevaPantalla = True Then
            Dim objBUEntrada As New SalidasAlmacenBU
            ' dtTabla = objBUEntrada.ValidaFolioEntrada(IdSAlidaNave, Id_NAve)

            If dtTabla.Rows.Count = 0 Then
                EstadoFolioSalidaNaveID = 0
            Else
                EstadoFolioSalidaNaveID = dtTabla.Rows(0).Item(0)
            End If

            If dtTabla.Rows.Count = 0 Then
                Nave_Valida = False
            ElseIf IsDBNull(dtTabla.Rows(0).Item(1)) Then
                Nave_Valida = False
            Else
                Nave_Valida = True
            End If
        Else
            dtTabla = objBU.VerificarSalidaNaveEmbarcada(IdSAlidaNave, Id_NAve)

            If dtTabla.Rows.Count = 0 Then
                Estado_SalidaNave = "INVALIDO"

            ElseIf IsDBNull(dtTabla.Rows(0).Item(0)) Then
                Estado_SalidaNave = "INVALIDO"

            ElseIf dtTabla.Rows(0).Item(0) = "EN PROCESO" Then
                Estado_SalidaNave = "EN PROCESO"

            ElseIf dtTabla.Rows(0).Item(0) = "EMBARCADO" Then
                Estado_SalidaNave = "EMBARCADO"

            ElseIf dtTabla.Rows(0).Item(0) = "INGRESANDO" Then
                Estado_SalidaNave = "INGRESANDO"
            Else
                Estado_SalidaNave = "ENTREGADO"
            End If

            If dtTabla.Rows.Count = 0 Then
                Nave_Valida = False
            ElseIf IsDBNull(dtTabla.Rows(0).Item(1)) Then
                Nave_Valida = False
            Else
                Nave_Valida = True
            End If

        End If




    End Sub

    Private Function validarCamposVacios() As Boolean
        If cboxNave.SelectedIndex = 0 Then
            lblNave.ForeColor = Color.Red

            Dim formaError As New ErroresForm
            formaError.StartPosition = FormStartPosition.CenterScreen
            formaError.mensaje = "Selecciona una nave"
            formaError.ShowDialog()

            Return True
        Else
            lblNave.ForeColor = Color.Black
            IdNave = cboxNave.SelectedValue
            Return False
        End If
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Reporte = False Then
            Terminar_Captura_Folio()
        Else
            Dim CampoVacio As Boolean
            'validamos campos vacios
            CampoVacio = validarCamposVacios()

            If CampoVacio = False Then
                fecha_Inicio = DateStart.Value.ToShortDateString + " 00:00:00"
                fecha_fin = DateStart.Value.ToShortDateString + " 23:59:59"

                fecha_Inicio = DateTime.Parse(fecha_Inicio).ToString("dd/MM/yyyy HH:mm:ss")
                fecha_fin = DateTime.Parse(fecha_fin).ToString("dd/MM/yyyy HH:mm:ss")
                NumeroAlmacen = CInt(cmbAlmacen.Text)
                ComercializadoraId = cmbComercializadora.SelectedValue
                Me.Close()
            Else
                Return
            End If

        End If

    End Sub

    Private Sub Terminar_Captura_Folio()
        If txtFolio.Text = "" Then
            Me.Close()
        Else
            folio = Convert.ToInt64(txtFolio.Text)
            Validar_Folio_De_Lote(folio, IdNave)
            Dim FORMA_ADVERTENCIAS As New AdvertenciaForm
            FORMA_ADVERTENCIAS.StartPosition = FormStartPosition.CenterScreen

            If Estado_SalidaNave = "INVALIDO" Then
                FORMA_ADVERTENCIAS.mensaje = "El folio introducido no es valido."
                FORMA_ADVERTENCIAS.ShowDialog()

            ElseIf Nave_Valida = False Then
                FORMA_ADVERTENCIAS.mensaje = "El folio introducido no corresponde con un folio para la nave seleccionada, seleccione la nave correcta para este folio o introduzca un folio asignado a la nave seleccionada."
                FORMA_ADVERTENCIAS.ShowDialog()

            ElseIf Estado_SalidaNave = "EN PROCESO" Then
                FORMA_ADVERTENCIAS.mensaje = "El folio introducido pertenece a un proceso de salida de nave que aun no ha sido concluido, para poder darle entrada este proceso debe de ser concluido."
                FORMA_ADVERTENCIAS.ShowDialog()

            ElseIf Estado_SalidaNave = "ENTREGADO" Then
                FORMA_ADVERTENCIAS.mensaje = "La mercancia del folio introducido ya fue ingresada al almacen, no es posible volver a darle ingreso."
                FORMA_ADVERTENCIAS.ShowDialog()

            Else
                Dim FORMA_EXITO As New ExitoForm
                FORMA_EXITO.StartPosition = FormStartPosition.CenterScreen
                FORMA_EXITO.mensaje = "Folio valido"
                FORMA_EXITO.ShowDialog()
                Me.Close()
            End If
        End If

    End Sub



    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Terminar_Captura_Folio()
        Else
            e.Handled = txtNumericoSinDecimales(txtFolio, e.KeyChar, True)
        End If

    End Sub

    Public Function txtNumericoSinDecimales(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = False Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CargarComercializadora()
        Dim dtInformacionCentroDistribucion As DataTable
        Dim objbu As New Almacen.Negocios.AlmacenBU
        Dim dtNumeroAlmacenes As DataTable

        dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        cmbComercializadora.DataSource = dtInformacionCentroDistribucion
        cmbComercializadora.DisplayMember = "Nave"
        cmbComercializadora.ValueMember = "NaveSAYID"

        If cmbComercializadora.SelectedIndex = 0 Then
            dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cmbComercializadora.SelectedValue)
            cmbAlmacen.DataSource = dtNumeroAlmacenes
            cmbAlmacen.ValueMember = "NumeroAlmacen"
            cmbAlmacen.DisplayMember = "NumeroAlmacen"
            cmbAlmacen.SelectedIndex = 0
        End If

    End Sub


End Class