Imports Tools
Imports System.Media
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Text

Public Class ReingresoDevolucionForm

    Public FolioDevolucion As Integer = 0
    Private ObjBU As New Almacen.Negocios.InspeccionCalidadBU
    Private entidad As New Entidades.infoFolioDevolucion
    Private dtParesReproceso As New DataTable

    Private Sub ReingresoDevolucionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            ActualizarPantalla()
            ObtenerParesReproceso(FolioDevolucion)
            txtLectura.Focus()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Public Sub ParesPendientesIngresar()
        Dim dtResultado As New DataTable
        Try
            dtResultado = ObjBU.ConsultaParesPendientesIngresar(FolioDevolucion)
            GrdParesPendientes.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewParesPendientes)
            viewParesPendientes.IndicatorWidth = 30
            viewParesPendientes.OptionsView.ColumnAutoWidth = True
            DiseñoGrid.EstiloColumna(viewParesPendientes, "DevolucionNaveID", "DevolucionNaveID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            lblTotalParesPendientes.Text = CDbl(dtResultado.Rows.Count).ToString("N0")
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub


    Private Sub ParesIngresados()
        Dim dtResultado As New DataTable

        Try
            dtResultado = ObjBU.ConsultaParesIngresados(FolioDevolucion)
            grdParesIngresados.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewParesIngresados)
            viewParesIngresados.IndicatorWidth = 30
            viewParesIngresados.OptionsView.ColumnAutoWidth = True
            DiseñoGrid.EstiloColumna(viewParesIngresados, "DevolucionNaveID", "DevolucionNaveID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            lblTotalParesIngresados.Text = CDbl(dtResultado.Rows.Count).ToString("N0")
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub ActualizarPantalla()

        Try
            Cursor = Cursors.WaitCursor
            ParesPendientesIngresar()
            ParesIngresados()
            ObtenerInformacionFolio()
            CargarOperadores()


            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ObtenerParesReproceso(ByVal FolioDEvolucion As Integer)
        Try
            dtParesReproceso = ObjBU.ConsultaParesDevolucion(FolioDEvolucion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ObtenerInformacionFolio()

        Try
            entidad = ObjBU.ObtenerInformacionFolioDevolucion(FolioDevolucion)

            lblFolioDevolucion.Text = entidad.DevolucionNaveID.ToString()
            lblNave.Text = entidad.Nave
            lblRecibio.Text = entidad.ColaboradorRecibio
            lblFechaEstimadaRegreso.Text = entidad.FechaEstimadaRegreso.ToShortDateString()
            lblFechaRegreso.Text = entidad.FechaRegreso.ToShortDateString()
            txtTratamiento.Text = entidad.Tratamiento.ToString()
            lblRecibio.Text = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CargarOperadores()
        Dim dtResultado As New DataTable

        Try
            dtResultado = ObjBU.ConsultaOperadoresNave(entidad.NaveID)
            cmbEntrego.DataSource = dtResultado
            cmbEntrego.DisplayMember = "Nombre"
            cmbEntrego.ValueMember = "IdOperador"

            If dtResultado.Rows.Count > 0 Then
                cmbEntrego.SelectedIndex = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Sub txtLectura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLectura.KeyPress
        Dim CadenaCapturada As String = String.Empty
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                If (LTrim(RTrim(txtLectura.Text))) = "" Then Return
                CadenaCapturada = (LTrim(RTrim(txtLectura.Text))).Replace("'", "-")
                CadenaCapturada = CadenaCapturada.TrimStart("0")
                ValidarCodigo(CadenaCapturada)



                txtLectura.Text = String.Empty
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub ValidarCodigo(ByVal CodigoLeido As String)

        Dim codigo_split = LTrim(RTrim(CodigoLeido)).Split("-")

        Try

            If codigo_split.Length = 3 Then 'Codigo Par

                'Validar que el par se encuentra en el folio de devolucion
                If dtParesReproceso.AsEnumerable().Where(Function(x) x.Item("Par") = codigo_split(2).ToString.Trim()).Count() > 0 Then
                    'Actualizar par como ingresado
                    ObjBU.IngresarParesDevolucion(FolioDevolucion, True, codigo_split(2), Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                    ActualizarPantalla()
                Else
                    ReproducrirSonidoError()
                End If

            Else
                'Validar posible codigo de atado
                If dtParesReproceso.AsEnumerable().Where(Function(x) x.Item("Atado").ToString.TrimStart("0") = CodigoLeido.TrimStart("0")).Count > 0 Then
                    'Actualizar atado como ingresado
                    ObjBU.IngresarParesDevolucion(FolioDevolucion, False, CodigoLeido.TrimStart("0"), Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                    ActualizarPantalla()
                Else
                    ReproducrirSonidoError()
                End If

            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Public Sub ReproducrirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub

    Private Sub viewParesIngresados_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewParesIngresados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub viewParesPendientes_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewParesPendientes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim Usuario As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            Usuario = cmbEntrego.Text
            ObjBU.FinalizarIngreso(FolioDevolucion, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Usuario)

            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han ingresado los pares.")
            Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Cursor = Cursors.Default
        End Try

    End Sub


End Class